Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmMainHO
	Inherits System.Windows.Forms.Form
	'Option Explicit
	
	Private Const STRING_SIZE As Short = 128
	Private Const INTERNET_OPEN_TYPE_DIRECT As Short = 1
	Private Const INTERNET_FLAG_NO_CACHE_WRITE As Integer = &H4000000
	'
	Private Declare Function InternetOpen Lib "wininet"  Alias "InternetOpenA"(ByVal sAgent As String, ByVal lAccessType As Integer, ByVal sProxyName As String, ByVal sProxyBypass As String, ByVal lFlags As Integer) As Integer
	'
	Private Declare Function InternetCloseHandle Lib "wininet" (ByRef hInet As Integer) As Integer
	'
	Private Declare Function InternetReadFile Lib "wininet" (ByVal hFile As Integer, ByVal sBuffer As String, ByVal lNumBytesToRead As Integer, ByRef lNumberOfBytesRead As Integer) As Short
	'
	Private Declare Function InternetOpenUrl Lib "wininet"  Alias "InternetOpenUrlA"(ByVal hInternetSession As Integer, ByVal lpszUrl As String, ByVal lpszHeaders As String, ByVal dwHeadersLength As Integer, ByVal dwFlags As Integer, ByVal dwContext As Integer) As Integer
	'
	'
	'
	Dim fso As New Scripting.FileSystemObject
	Dim ErrTextstream As Scripting.TextStream
	Dim tempStatus As String
	
	Private Declare Function InternetAttemptConnect Lib "wininet" (ByVal dwReserved As Integer) As Integer
	Dim WithEvents myWinSock As CSocketMaster
	Dim a As New clsRC4 ' clsBlowfish
	
	Dim gMasterPath As String
	Dim cnnDBWaitron As ADODB.Connection
	Private Const gPathHO As String = "C:\4POS\headoffice\"
	Dim rsWebDB As ADODB.Recordset
	
	Dim gDayEndStart As Integer
	Dim gDayEndEnd As Integer
	Dim gCNT As Short

    Public cmdPulsante As New List(Of Button)
    Dim DTPicker1 As New List(Of DateTimePicker)
	Private Function SendAPIRequest(ByVal strUrl As String) As String
		Dim hOpen, hFile As Integer
		Dim ret As Integer
        Dim sBuffer As String
		Dim iResult As Short
		Dim sData As String
		
		On Error GoTo AutoErrorHndlr
		
		hOpen = InternetOpen("VB Program", 1, vbNullString, vbNullString, 0)
		If hOpen = 0 Then
			MsgBox("Error opening Internet connection")
			Exit Function
		End If
		
		hFile = InternetOpenUrl(hOpen, strUrl, vbNullString, 0, INTERNET_FLAG_NO_CACHE_WRITE, 0)
		If hFile = 0 Then
			'MsgBox "Error opening Web page"
			lbl11.Text = "Error opening Web page"
			'lstStatus.AddItem lbl11
			'lstStatus.ListIndex = lstStatus.ListCount - 1
			'lstStatus.ListIndex = -1
		Else
            InternetReadFile(hFile, sBuffer, STRING_SIZE, ret)
            sData = sBuffer
			Do While ret <> 0
                InternetReadFile(hFile, sBuffer, STRING_SIZE, ret)
                sData = sData & Mid(sBuffer, 1, ret)
			Loop 
		End If
		
		InternetCloseHandle(hFile)
		InternetCloseHandle(hOpen)
		SendAPIRequest = sData
		sData = ""
		
		Exit Function
AutoErrorHndlr: 
		'TEST PURPOSE
		tempStatus = "SendAPIRequest" & " - " & Err.Number & " - " & Err.Description & vbCrLf
		If fso.FileExists(gPathHO & "\4HOfficeStatusErrLog.log") Then
			ErrTextstream = fso.OpenTextFile(gPathHO & "\4HOfficeStatusErrLog.log", Scripting.IOMode.ForAppending, True)
		Else
			ErrTextstream = fso.OpenTextFile(gPathHO & "\4HOfficeStatusErrLog.log", Scripting.IOMode.ForWriting, True)
		End If
		ErrTextstream.Write(tempStatus)
		ErrTextstream.Close()
		'TEST PURPOSE
		Resume Next
	End Function
	
	Private Sub updateStatus(ByRef sStatus As String)
		Text1.Text = Text1.Text & sStatus & vbCrLf
		Text1.Refresh()
		Text1.SelectionStart = Len(Text1.Text)
	End Sub
	
	'Private Sub updateLOG(Log_BranchID As Long, Log_HeadOfficeID As Long, Log_User As String, Log_Action As String, Log_Remarks As String)
	Private Sub updateLOG(ByRef Log_Action As String, ByRef Log_Remarks As String)
        Dim sql As String
		If sqlDBcn Is Nothing Then
		Else
			sql = "INSERT INTO Log (Log_BranchID, Log_HeadOfficeID, Log_Date, Log_User, Log_Action, Log_Remarks) " & "VALUES     (" & IIf(BranchType = "0", CInt(BranchID), 0) & ", " & IIf(BranchType = "1", CInt(HOfficeID), 0) & ", '" & Now & "', '" & frmMenu.lblUser.Text & "', '" & Log_Action & "', '" & Log_Remarks & " ')"
			sqlDBcn.Execute(sql)
		End If
	End Sub
	
	Private Sub cmdClear_Click()
		lbl11.Text = "-/-"
		lbl22.Text = "-/-"
		lbl33.Text = "-/-"
		lbl44.Text = "-/-"
		lbl55.Text = "-/-"
		lbl66.Text = "-/-"
		'lbl77 = "-/-"
		'lbl88 = "-/-"
		
		'lstStatus.Clear
		Text1.Text = ""
        _Label1_1.Text = "-/-"
		'txtCustOrder.Text = ""
		'txtBalStatus.Text = ""
		'txtBalRes.Text = ""
		'txtWSDLOrder.Text = ""
		'txtWSDLOrder_Log.Text = ""
		'txtWSDLPOFile.Text = ""
		'txtGRVFile.Text = ""
		'txtCartID.Text = ""
		'txtRespnse.Text = ""
		'txtCredit.Text = ""
		'txtCellNo.Text = ""
		'Text1Copy.Text = ""
		'txtCustOrderCopy.Text = ""
		'txtPrevOrder = ""
		
		'tmr1ChkNewOrder.Enabled = False
		'tmr2FoundDL.Enabled = False
		'tmr3ChkStkLvl.Enabled = False
		'tmr4POfileWSDL.Enabled = False
		'tmr5GRV.Enabled = False
		'tmr6ScanOrder.Enabled = False
		'tmr7Controller.Enabled = False
	End Sub
	
	Private Sub cmdBookIN_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBookIN.Click
		bBranchChange = False
		
		cmdClear_Click()
		cmdPulsante_Click(cmdPulsante.Item(0), New System.EventArgs())
		cmdPulsante_Click(cmdPulsante.Item(9), New System.EventArgs())
		cmdPulsante_Click(cmdPulsante.Item(1), New System.EventArgs())
		
		MsgBox("Process Finished.")
	End Sub
	
	Private Sub cmdBookOut_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBookOut.Click
		bBranchChange = False
		
		cmdClear_Click()
		cmdPulsante_Click(cmdPulsante.Item(0), New System.EventArgs())
		cmdPulsante_Click(cmdPulsante.Item(8), New System.EventArgs())
		cmdPulsante_Click(cmdPulsante.Item(1), New System.EventArgs())
		
		MsgBox("Process Finished.")
	End Sub
	
	Private Sub cmdCheckWOrder_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCheckWOrder.Click
		bBranchChange = False
		
		If BranchType = "0" Then
			MsgBox("Option not allowed.")
			Exit Sub
		End If
		
		cmdClear_Click()
		cmdPulsante_Click(cmdPulsante.Item(0), New System.EventArgs())
		cmdPulsante_Click(cmdPulsante.Item(6), New System.EventArgs())
		cmdPulsante_Click(cmdPulsante.Item(1), New System.EventArgs())
		
		MsgBox("Process Finished.")
	End Sub
	
	Private Sub cmdClearLock_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClearLock.Click
		If MsgBox("Are you sure you wish to clear the lock file? It may create problem if other branch/headoffice is busy at the moment.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
			cmdClear_Click()
			cmdPulsante_Click(cmdPulsante.Item(0), New System.EventArgs())
			DownLoadFile_DownTxt(True)
			System.Windows.Forms.Application.DoEvents()
			DownLoadFile_DownTxt(True)
			cmdPulsante_Click(cmdPulsante.Item(1), New System.EventArgs())
			
			System.Windows.Forms.Application.DoEvents()
			cmdPulsante_Click(cmdPulsante.Item(0), New System.EventArgs())
			DownLoadFile_DownTxt(True, True)
			System.Windows.Forms.Application.DoEvents()
			DownLoadFile_DownTxt(True, True)
			cmdPulsante_Click(cmdPulsante.Item(1), New System.EventArgs())
			
			MsgBox("Process Finished.")
		End If
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	
	Private Sub cmdToday_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdToday.Click
		Dim rs As ADODB.Recordset
		rs = getRS("SELECT DayEnd.DayEndID, DayEnd.DayEnd_Date From DayEnd, Company WHERE (((DayEnd.DayEndID)=[Company]![Company_DayEndID]-1));")
		If rs.RecordCount Then
            _DTPicker1_0.Value = rs.Fields("DayEnd_Date").Value
            _DTPicker1_1.Value = rs.Fields("DayEnd_Date").Value
			setDayEndRangeHO()
		Else
			'cmdToday_Click
		End If
        '_DTPicker1_1.SetFocus
    End Sub

    Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
        bBranchChange = False

        If BranchType = "1" Then
            MsgBox("Option not allowed.")
            Exit Sub
        End If

        cmdClear_Click()
        Text1.Text = Text1.Text & "Uploading Product Performance reports" & vbCrLf
        Text1.Refresh()
        Text1.SelectionStart = Len(Text1.Text)
        cmdPulsante_Click(cmdPulsante.Item(0), New System.EventArgs())

        picInner.Width = 0
        gCNT = 0
        System.Windows.Forms.Application.DoEvents()
        picOuter.Visible = True
        uploadProductPerformance()
        picOuter.Visible = False

        cmdPulsante_Click(cmdPulsante.Item(1), New System.EventArgs())

        MsgBox("Process Finished.")
    End Sub

    Private Sub DTPicker1_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim dtp As New DateTimePicker
        dtp = DirectCast(eventSender, DateTimePicker)
        Dim Index As Integer = GetIndexer(dtp, DTPicker1)
        setDayEndRangeHO()
        'MsgBox gDayEndStart
    End Sub

    Private Sub setDayEndRangeHO()
        Dim lDate As Date
        Dim lDateString As String
        Dim lDateArray() As String
        Dim lDateStart As Date
        Dim lDateEnd As Date
        Dim rs As ADODB.Recordset
        On Error Resume Next

        _DTPicker1_0.Value = _DTPicker1_1.Value
        lDateStart = _DTPicker1_0.Value
        lDateEnd = _DTPicker1_1.Value
        lDateStart = CDate(VB.Left(CStr(lDateStart), 10))
        lDateEnd = CDate(VB.Left(CStr(lDateEnd), 10))

        If lDateStart >= lDateEnd Then
            lDateStart = _DTPicker1_1.Value
            lDateEnd = _DTPicker1_0.Value
        End If
        lDateStart = CDate(VB.Left(CStr(lDateStart), 10))
        lDateEnd = CDate(VB.Left(CStr(lDateEnd), 10))

        rs = getRS("SELECT DayEnd.DayEndID From DayEnd Where (((DayEnd.DayEnd_Date) >= #" & lDateStart & " 00:00:00#)) ORDER BY DayEnd.DayEnd_Date;")
        If rs.BOF Or rs.EOF Then
            rs.Close()
            rs = getRS("SELECT Max(DayEnd.DayEndID) AS DayEndID FROM DayEnd;")

        End If
        gDayEndStart = rs.Fields("DayEndID").Value
        rs.Close()

        rs = getRS("SELECT DayEnd.DayEndID From DayEnd Where (((DayEnd.DayEnd_Date) <= #" & lDateEnd & " 23:59:59#)) ORDER BY DayEnd.DayEnd_Date DESC;")
        If rs.BOF Or rs.EOF Then
            rs.Close()
            rs = getRS("SELECT Min(DayEnd.DayEndID) AS DayEndID FROM DayEnd;")

        End If
        gDayEndEnd = rs.Fields("DayEndID").Value
        rs.Close()

        rs = getRS("SELECT Count(DayEnd.DayEndID) AS [count], Min(DayEnd.DayEnd_Date) AS fromDate, Max(DayEnd.DayEnd_Date) AS toDate From DayEnd WHERE (((DayEnd.DayEndID)>= " & gDayEndStart & ") AND ((DayEnd.DayEndID) <= " & gDayEndEnd & "));")
        '
        '    lblDayEnd.Caption = "From " & Format(rs("fromDate"), "ddd dd mmm yyyy")
        '    lblDayEnd.Caption = lblDayEnd.Caption & " to "
        '    lblDayEnd.Caption = lblDayEnd.Caption & Format(rs("toDate"), "ddd dd mmm yyyy")
        '    lblDayEnd.Caption = lblDayEnd.Caption & " covering " & rs("count") & " day-end/s."
        '_DTPicker1_0. = Format(rs.Fields("fromDate").Value, "yyyy")
        '_DTPicker1_0.Month = Format(rs.Fields("fromDate").Value, "m")
        '_DTPicker1_0.Day = Format(rs.Fields("fromDate").Value, "d")
        '_DTPicker1_1.Year = Format(rs.Fields("toDate").Value, "yyyy")
        '_DTPicker1_1.Month = Format(rs.Fields("toDate").Value, "m")
        '_DTPicker1_1.Day = Format(rs.Fields("toDate").Value, "d")
    End Sub

    Private Sub cmdUpReport_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpReport.Click

        bBranchChange = False

        If BranchType = "1" Then
            MsgBox("Option not allowed.")
            Exit Sub
        End If

        cmdClear_Click()
        Text1.Text = Text1.Text & "Uploading Day End reports" & vbCrLf
        Text1.Refresh()
        Text1.SelectionStart = Len(Text1.Text)
        cmdPulsante_Click(cmdPulsante.Item(0), New System.EventArgs())
        cmdPulsante_Click(cmdPulsante.Item(10), New System.EventArgs())
        cmdPulsante_Click(cmdPulsante.Item(1), New System.EventArgs())


        cmdClear_Click()
        Text1.Text = Text1.Text & "Uploading Product Performance reports" & vbCrLf
        Text1.Refresh()
        Text1.SelectionStart = Len(Text1.Text)
        cmdPulsante_Click(cmdPulsante.Item(0), New System.EventArgs())

        picInner.Width = 0
        gCNT = 0
        System.Windows.Forms.Application.DoEvents()
        picOuter.Visible = True
        uploadProductPerformance()
        picOuter.Visible = False

        cmdPulsante_Click(cmdPulsante.Item(1), New System.EventArgs())

        MsgBox("Process Finished.")
    End Sub

    Private Sub uploadProductPerformance()
        Dim sql As String
        frmMenu._DTPicker1_0.Value = _DTPicker1_1.Value
        frmMenu.setDayEndRange()
        frmMenu._DTPicker1_1.Value = _DTPicker1_1.Value
        frmMenu.setDayEndRange()
        frmMenu.cmdLoad_Click(Nothing, New System.EventArgs())

        Dim rs As ADODB.Recordset
        'sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity,"
        'sql = sql & "Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name  ORDER BY StockItem_Name;"
        sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.actualCostSum, StockList.listCostSum, StockList.exclusiveSum, StockList.inclusiveSum, StockList.depositSum, StockList.quantitySum, StockList.Sale_ChannelID, aStockGroup.StockGroup_Name, aPricingGroup.PricingGroup_Name "
        sql = sql & "FROM (StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID) INNER JOIN aPricingGroup ON aStockItem1.StockItem_PricingGroupID = aPricingGroup.PricingGroupID;"
        rs = getRSreport(sql)
        If rs.BOF Or rs.EOF Then
            'MsgBox "No data found for Product Performance reports."
            Text1.Text = Text1.Text & "No data found for Product Performance reports." & vbCrLf
            Text1.Refresh()
            Text1.SelectionStart = Len(Text1.Text)
        Else

            sqlDBcn.Execute("DELETE FROM ProductPerform Where (BranchID = " & CInt(BranchID) & ") And (HeadOfficeID = " & CInt(HOfficeID) & ") And (DayEndDate = '" & Format(_DTPicker1_1.Value, "short date") & "')")

            Do Until rs.EOF

                sql = "INSERT INTO ProductPerform (BranchID, HeadOfficeID, DayEndDate, StockItemID, StockItemName, actualCostSum, listCostSum, exclusiveSum, inclusiveSum, depositSum, quantitySum, ChannelID, StockGroupName, PricingGroupName) " & "VALUES     (" & CInt(BranchID) & ", " & CInt(HOfficeID) & ", '" & Format(_DTPicker1_1.Value, "short date") & "', " & rs.Fields("StockItemID").Value & ", '" & rs.Fields("StockItem_Name").Value & "', " & rs.Fields("actualCostSum").Value & ", " & rs.Fields("listCostSum").Value & ", " & rs.Fields("exclusiveSum").Value & ", " & rs.Fields("inclusiveSum").Value & ", " & rs.Fields("depositSum").Value & ", " & rs.Fields("quantitySum").Value & ", " & rs.Fields("Sale_ChannelID").Value & ", '" & rs.Fields("StockGroup_Name").Value & "', '" & rs.Fields("PricingGroup_Name").Value & " ')"
                Debug.Print(sql)
                sqlDBcn.Execute(sql)

                moveItem()

                rs.MoveNext()
            Loop
        End If
    End Sub

    Private Sub moveItem()
        If pixelToTwips(picInner.Width, True) > pixelToTwips(picOuter.Width, True) Then picInner.Width = 0 : gCNT = 0

        gCNT = gCNT + 1
        picInner.Width = twipsToPixels(CShort(pixelToTwips(picOuter.Width, True) / 31 * gCNT) + 100, True)
        System.Windows.Forms.Application.DoEvents()
    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        Dim lString As String
        Dim sql As String
        Dim rsWebDBs As ADODB.Recordset
        bBranchChange = False

        Dim ret As String
        Dim dtDate As String
        Dim dtMonth As String
        Dim stPass As String
        If BranchType = "1" Then
            'UPGRADE_WARNING: Add a delegate for AddressOf TimerProc Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"'
            'SetTimer(Handle.ToInt32, NV_INPUTBOX, 10, TimerProc)
            ret = InputBox("Enter Password")
            'Construct password...........
            If Len(VB.Day(Today)) = 1 Then dtDate = "0" & Str(VB.Day(Today)) Else dtDate = Trim(Str(VB.Day(Today)))
            dtDate = Replace(dtDate, " ", "")
            If Len(Month(Today)) = 1 Then dtMonth = "0" & Str(Month(Today)) Else dtMonth = Trim(Str(Month(Today)))
            dtMonth = Replace(dtMonth, " ", "")

            'Create password
            stPass = dtDate & "##" & dtMonth
            stPass = Replace(stPass, " ", "")

            If Trim(ret) = stPass Then
                bBranchChange = True
            Else
                MsgBox("Incorrect password was entered!!!", MsgBoxStyle.Exclamation, "Incorrect Passwords")
                Exit Sub
            End If
        End If

        cmdClear_Click()
        cmdPulsante_Click(cmdPulsante.Item(0), New System.EventArgs())
        cmdPulsante_Click(cmdPulsante.Item(7), New System.EventArgs())
        cmdPulsante_Click(cmdPulsante.Item(1), New System.EventArgs())

        If BranchType = "0" Then
            cmdPulsante_Click(cmdPulsante.Item(0), New System.EventArgs())

            rsWebDBs = New ADODB.Recordset
            sql = "SELECT * FROM GRVSale WHERE (GRVSale_HeadOfficeID = " & CShort(HOfficeID) & ") AND (GRVSale_BranchID = " & CShort(BranchID) & ") AND (GRVSale_Done = 'False');"
            With rsWebDBs
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenForwardOnly
                .LockType = ADODB.LockTypeEnum.adLockBatchOptimistic
                .Source = sql
                .ActiveConnection = sqlDBcn
                .Open()
                .ActiveConnection = Nothing
            End With
            If rsWebDBs.RecordCount Then
tryCheckZip:
                If fso.FileExists(serverPath & "data.zip") Then
                    MsgBox("There are 'Sale to GRV' outstanding to be processed. Please click 'OK' once 4POS Domain Controller finished with Pricing update.")
                    GoTo tryCheckZip
                End If

                lString = Replace(CStr(Now), " ", "_")
                lString = Replace(lString, "/", "-")
                lString = Replace(lString, ":", "")
                If fso.FolderExists(gPathHO & "download\" & lString) Then
                Else
                    fso.CreateFolder(gPathHO & "download\" & lString)
                End If

                Do Until rsWebDBs.EOF

                    cmdPulsante_Click(cmdPulsante.Item(1), New System.EventArgs())
                    cmdPulsante_Click(cmdPulsante.Item(0), New System.EventArgs())
                    DownLoadFile_GRV(False, CStr(Split(rsWebDBs("GRVSale_Path"), "/grv/")(1)), gPathHO & "download\" & lString, True)
                    sGRVSales = gPathHO & "download\" & lString & "\" & CStr(Split(rsWebDBs("GRVSale_Path"), "/grv/")(1))
                    'frmGRVimport.Tag = lString
                    frmGRVimport.ShowDialog()

                    If sGRVSales = "DONE" Then
                        sql = "UPDATE GRVSale SET GRVSale_Done = 'True' WHERE (GRVSaleID = " & rsWebDBs("GRVSaleID").Value & ");"
                        sqlDBcn.Execute(sql)
                    End If

                    sGRVSales = ""
                    rsWebDBs.MoveNext()
                Loop

            End If
            cmdPulsante_Click(cmdPulsante.Item(1), New System.EventArgs())
        End If

        sGRVSales = ""
        MsgBox("Process Finished.")
    End Sub

    Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
        On Error GoTo AutoErrorHndlr

        closeConnection()
        End
        Me.Close()

        Exit Sub
AutoErrorHndlr:
        'TEST PURPOSE
        tempStatus = "cmdExit_Click" & " - " & Err.Number & " - " & Err.Description & vbCrLf
        If fso.FileExists("d:\4AIR\4AIRStatusErrLog.log") Then
            ErrTextstream = fso.OpenTextFile("d:\4AIR\4AIRStatusErrLog.log", Scripting.IOMode.ForAppending, True)
        Else
            ErrTextstream = fso.OpenTextFile("d:\4AIR\4AIRStatusErrLog.log", Scripting.IOMode.ForWriting, True)
        End If
        ErrTextstream.Write(tempStatus)
        ErrTextstream.Close()
        'TEST PURPOSE
        'a = SendAPIRequest("http://www.bulksmsportal.co.za/httppost4.aspx?type=singlesms&username=" & "compupos" & "&password=" & "compupos" & "&Number=" & "0726633429" & "&Message=" & tempStatus & "&CustomerID=123")
        Resume Next
    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
    End Sub

    Private Sub frmMainHO_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        cmdPulsante.AddRange(New Button() {_cmdPulsante_0, _cmdPulsante_1, _cmdPulsante_2, _
                                          _cmdPulsante_3, _cmdPulsante_4, _cmdPulsante_5, _
                                          _cmdPulsante_6, _cmdPulsante_7})
        DTPicker1.AddRange(New DateTimePicker() {_DTPicker1_0, _DTPicker1_1})
        Dim bt As New Button
        Dim dt As New DateTimePicker
        For Each bt In cmdPulsante
            AddHandler bt.Click, AddressOf cmdPulsante_Click
        Next
        For Each dt In DTPicker1
            AddHandler dt.ValueChanged, AddressOf DTPicker1_Change
        Next
        'If App.PrevInstance = True Then End

        Dim lString As String
        On Error GoTo AutoErrorHndlr
        bUploadReport = False

        If fso.FolderExists(gPathHO) Then
        Else
            fso.CreateFolder(gPathHO)
        End If

        If fso.FolderExists(gPathHO & "upload") Then
        Else
            fso.CreateFolder(gPathHO & "upload")
        End If

        If fso.FolderExists(gPathHO & "download") Then
        Else
            fso.CreateFolder(gPathHO & "download")
        End If

        If BranchType = "0" Then
            Me.Text = Me.Text & " - BRANCH"
        Else
            Me.Text = Me.Text & " - HEAD OFFICE"
        End If

        'If openConnection Then
        lbl8.Text = serverPath
        'Else
        '    MsgBox "Couldn't find Pricing database.", vbExclamation
        '    End
        'End If

        cmdClear_Click()
        cmdToday_Click(cmdToday, New System.EventArgs())

        Exit Sub

        Exit Sub
AutoErrorHndlr:
        'TEST PURPOSE
        tempStatus = "Form_Load" & " - " & Err.Number & " - " & Err.Description & vbCrLf
        If fso.FileExists(My.Application.Info.DirectoryPath & "\4POSHOStatusErrLog.log") Then
            ErrTextstream = fso.OpenTextFile(My.Application.Info.DirectoryPath & "\4POSHOStatusErrLog.log", Scripting.IOMode.ForAppending, True)
        Else
            ErrTextstream = fso.OpenTextFile(My.Application.Info.DirectoryPath & "\4POSHOStatusErrLog.log", Scripting.IOMode.ForWriting, True)
        End If
        ErrTextstream.Write(tempStatus)
        ErrTextstream.Close()
        'TEST PURPOSE
        Resume Next
    End Sub

    Public Sub SleepFor(ByVal Seconds As Double)
        ' "Sleep" for the specified number of seconds.
        Dim EndTime As Date
        EndTime = DateAdd(Microsoft.VisualBasic.DateInterval.Second, Seconds, Now)
        Do
            System.Windows.Forms.Application.DoEvents()
        Loop Until Now >= EndTime
    End Sub

    Private Sub Automatico()

        cmdPulsante_Click(cmdPulsante.Item(0), New System.EventArgs())
        cmdPulsante_Click(cmdPulsante.Item(6), New System.EventArgs())
        cmdPulsante_Click(cmdPulsante.Item(7), New System.EventArgs())
        cmdPulsante_Click(cmdPulsante.Item(1), New System.EventArgs())
    End Sub

    Public Sub DownLoadFile_GRV(Optional ByRef delRemote As Boolean = False, Optional ByRef fname As String = "", Optional ByRef fpath As String = "", Optional ByRef dirUD As Boolean = False)
        'Declare Variables
        Dim bRet, bret1 As Boolean
        Dim bret2 As Boolean
        Dim szDirRemote, szFileRemote, szFileLocal As String
        Dim szTempString As String
        Dim nPos, nTemp As Integer
        Dim hFind As Integer
        Dim findfile As WIN32_FIND_DATA
        Dim errore As Short
        Dim Count As Short
        'Total Files Wrong
        errore = 0
        'Total Files
        Count = 0
        'Checking the Connection
        dirrecv = dirsend & "/grv"
        If bActiveSession Then
            'Set the current directory
            If dirUD Then
                Call FtpSetCurrentDirectory(hConnection, dirrecv)
            Else
                Call FtpSetCurrentDirectory(hConnection, dirsend)
            End If
            'Beginning to Look for files
            System.Windows.Forms.Application.DoEvents()
            hFind = FtpFindFirstFile(hConnection, fname, findfile, 0, 0)
            If hFind = 0 Then
                Text1.Text = Text1.Text & "No file found ..." & vbCrLf
                Exit Sub
            End If
            Count = 1
            szFileRemote = fname 'Trim(Mid(findfile.cFileName, 1, InStr(1, findfile.cFileName, Chr(0), vbTextCompare) - 1))
            _Label1_1.Text = szFileRemote
            _Label1_1.Refresh()
            bRet = FtpGetFile(hConnection, szFileRemote, fpath & "/" & szFileRemote, False, INTERNET_FLAG_RELOAD, dwType, 0)
            If bRet = False Then
                'File Log'
                Text1.Text = Text1.Text & "Error while Downloading File " & szFileRemote & " : " & CStr(Err.LastDllError) & vbCrLf
                Text1.Refresh()
                Text1.SelectionStart = Len(Text1.Text)
                errore = errore + 1
                updateLOG("DOWNLOAD_ERROR_POINT_1", CStr(Err.LastDllError))
            Else
                If delRemote = True Then
                    bret2 = FtpDeleteFile(hConnection, szFileRemote)
                End If
            End If
            'If bRet = False Then ErrorOut cstr(Err.LastDllError), "FtpGetFile"
            'bret1 = InternetFindNextFile(hFind, findfile)
            'While bret1 <> False
            '    szFileRemote = Trim(Mid(findfile.cFileName, 1, InStr(1, findfile.cFileName, Chr(0), vbTextCompare) - 1))
            '    Count = Count + 1
            '    _Label1_1.Caption = szFileRemote
            '    _Label1_1.Refresh
            '    bRet = FtpGetFile(hConnection, szFileRemote, dirrecv & "/" & szFileRemote, False, _
            ''    INTERNET_FLAG_RELOAD, dwType, 0)
            '    If bRet = False Then
            '        'File Log'
            '        Text1.Text = Text1.Text + "Error DownLoad File " + szFileRemote + " : " + CStr(Err.LastDllError) + vbCrLf
            '        Text1.Refresh
            '        Text1.SelStart = Len(Text1.Text)
            '        errore = errore + 1
            '    Else
            '        bret2 = FtpDeleteFile(hConnection, szFileRemote)
            '    End If
            '    bret1 = InternetFindNextFile(hFind, findfile)
            'Wend
            '_Label1_1.Caption = ""
            'File Log'
            If errore = 0 Then
                Text1.Text = Text1.Text & "Downloading completed successfully ..." & vbCrLf
                Text1.Refresh()
                Text1.SelectionStart = Len(Text1.Text)
                lbl44.Text = "DONE"
                updateLOG("DOWNLOAD_COMPLETED_1", "NILL")
            Else
                Text1.Text = Text1.Text & "Download didn't Complete ..." & vbCrLf
                Text1.Refresh()
                Text1.SelectionStart = Len(Text1.Text)
                updateLOG("DOWNLOAD_NOT_COMPLETED_1", "NILL")
            End If
            Text1.Text = Text1.Text & "Total file(s) : " & CStr(Count) & vbCrLf
            Text1.Refresh()
            Text1.SelectionStart = Len(Text1.Text)
            Text1.Text = Text1.Text & "Error in file(s) : " & CStr(errore) & vbCrLf
            Text1.Refresh()
            Text1.SelectionStart = Len(Text1.Text)
        End If
    End Sub

    Public Sub DownLoadFile_DownFile(Optional ByRef delRemote As Boolean = False, Optional ByRef fname As String = "", Optional ByRef dirUD As Boolean = False)
        'Declare Variables
        Dim bRet, bret1 As Boolean
        Dim bret2 As Boolean
        Dim szDirRemote, szFileRemote, szFileLocal As String
        Dim szTempString As String
        Dim nPos, nTemp As Integer
        Dim hFind As Integer
        Dim findfile As WIN32_FIND_DATA
        Dim errore As Short
        Dim Count As Short
        'Total Files Wrong
        errore = 0
        'Total Files
        Count = 0
        'Checking the Connection
        If bActiveSession Then
            'Set the current directory
            If dirUD Then
                Call FtpSetCurrentDirectory(hConnection, dirrecv)
            Else
                Call FtpSetCurrentDirectory(hConnection, dirsend)
            End If
            'Beginning to Look for files
            System.Windows.Forms.Application.DoEvents()
            hFind = FtpFindFirstFile(hConnection, fname, findfile, 0, 0)
            If hFind = 0 Then
                Text1.Text = Text1.Text & "No file found ..." & vbCrLf
                Exit Sub
            End If
            Count = 1
            szFileRemote = fname 'Trim(Mid(findfile.cFileName, 1, InStr(1, findfile.cFileName, Chr(0), vbTextCompare) - 1))
            _Label1_1.Text = szFileRemote
            _Label1_1.Refresh()
            bRet = FtpGetFile(hConnection, szFileRemote, gPathHO & "/" & szFileRemote, False, INTERNET_FLAG_RELOAD, dwType, 0)
            If bRet = False Then
                'File Log'
                Text1.Text = Text1.Text & "Error while Downloading File " & szFileRemote & " : " & CStr(Err.LastDllError) & vbCrLf
                Text1.Refresh()
                Text1.SelectionStart = Len(Text1.Text)
                errore = errore + 1
                updateLOG("DOWNLOAD_ERROR_POINT_1", CStr(Err.LastDllError))
            Else
                If delRemote = True Then
                    bret2 = FtpDeleteFile(hConnection, szFileRemote)
                End If
            End If
            'If bRet = False Then ErrorOut cstr(Err.LastDllError), "FtpGetFile"
            'bret1 = InternetFindNextFile(hFind, findfile)
            'While bret1 <> False
            '    szFileRemote = Trim(Mid(findfile.cFileName, 1, InStr(1, findfile.cFileName, Chr(0), vbTextCompare) - 1))
            '    Count = Count + 1
            '    _Label1_1.Caption = szFileRemote
            '    _Label1_1.Refresh
            '    bRet = FtpGetFile(hConnection, szFileRemote, dirrecv & "/" & szFileRemote, False, _
            ''    INTERNET_FLAG_RELOAD, dwType, 0)
            '    If bRet = False Then
            '        'File Log'
            '        Text1.Text = Text1.Text + "Error DownLoad File " + szFileRemote + " : " + CStr(Err.LastDllError) + vbCrLf
            '        Text1.Refresh
            '        Text1.SelStart = Len(Text1.Text)
            '        errore = errore + 1
            '    Else
            '        bret2 = FtpDeleteFile(hConnection, szFileRemote)
            '    End If
            '    bret1 = InternetFindNextFile(hFind, findfile)
            'Wend
            '_Label1_1.Caption = ""
            'File Log'
            If errore = 0 Then
                Text1.Text = Text1.Text & "Downloading completed successfully ..." & vbCrLf
                Text1.Refresh()
                Text1.SelectionStart = Len(Text1.Text)
                lbl44.Text = "DONE"
                updateLOG("DOWNLOAD_COMPLETED_1", "NILL")
            Else
                Text1.Text = Text1.Text & "Download didn't Complete ..." & vbCrLf
                Text1.Refresh()
                Text1.SelectionStart = Len(Text1.Text)
                updateLOG("DOWNLOAD_NOT_COMPLETED_1", "NILL")
            End If
            Text1.Text = Text1.Text & "Total file(s) : " & CStr(Count) & vbCrLf
            Text1.Refresh()
            Text1.SelectionStart = Len(Text1.Text)
            Text1.Text = Text1.Text & "Error in file(s) : " & CStr(errore) & vbCrLf
            Text1.Refresh()
            Text1.SelectionStart = Len(Text1.Text)
        End If
    End Sub

    Public Sub DownLoadFile_DownTxt(Optional ByRef delRemote As Boolean = False, Optional ByRef dirUD As Boolean = False)
        'Declare Variables
        Dim bRet, bret1 As Boolean
        Dim bret2 As Boolean
        Dim szDirRemote, szFileRemote, szFileLocal As String
        Dim szTempString As String
        Dim nPos, nTemp As Integer
        Dim hFind As Integer
        Dim findfile As WIN32_FIND_DATA
        Dim errore As Short
        Dim Count As Short
        'Total Files Wrong
        errore = 0
        'Total Files
        Count = 0
        'Checking the Connection
        If bActiveSession Then
            'Set the current directory
            If dirUD Then
                Call FtpSetCurrentDirectory(hConnection, dirrecv)
            Else
                Call FtpSetCurrentDirectory(hConnection, dirsend)
            End If
            'Beginning to Look for files
            hFind = FtpFindFirstFile(hConnection, "4pos_download.txt", findfile, 0, 0)
            If hFind = 0 Then
                Text1.Text = Text1.Text & "No one else is busy Downloading/Uploading ..." & vbCrLf
                Exit Sub
            End If
            Count = 1
            szFileRemote = "4pos_download.txt" 'Trim(Mid(findfile.cFileName, 1, InStr(1, findfile.cFileName, Chr(0), vbTextCompare) - 1))
            _Label1_1.Text = szFileRemote
            _Label1_1.Refresh()
            bRet = FtpGetFile(hConnection, szFileRemote, gPathHO & "/" & szFileRemote, False, INTERNET_FLAG_RELOAD, dwType, 0)
            If bRet = False Then
                'File Log'
                Text1.Text = Text1.Text & "Error while Downloading File " & szFileRemote & " : " & CStr(Err.LastDllError) & vbCrLf
                Text1.Refresh()
                Text1.SelectionStart = Len(Text1.Text)
                errore = errore + 1
            Else
                If delRemote = True Then
                    bret2 = FtpDeleteFile(hConnection, szFileRemote)
                End If
            End If
            'If bRet = False Then ErrorOut cstr(Err.LastDllError), "FtpGetFile"
            'bret1 = InternetFindNextFile(hFind, findfile)
            'While bret1 <> False
            '    szFileRemote = Trim(Mid(findfile.cFileName, 1, InStr(1, findfile.cFileName, Chr(0), vbTextCompare) - 1))
            '    Count = Count + 1
            '    _Label1_1.Caption = szFileRemote
            '    _Label1_1.Refresh
            '    bRet = FtpGetFile(hConnection, szFileRemote, dirrecv & "/" & szFileRemote, False, _
            ''    INTERNET_FLAG_RELOAD, dwType, 0)
            '    If bRet = False Then
            '        'File Log'
            '        Text1.Text = Text1.Text + "Error DownLoad File " + szFileRemote + " : " + CStr(Err.LastDllError) + vbCrLf
            '        Text1.Refresh
            '        Text1.SelStart = Len(Text1.Text)
            '        errore = errore + 1
            '    Else
            '        bret2 = FtpDeleteFile(hConnection, szFileRemote)
            '    End If
            '    bret1 = InternetFindNextFile(hFind, findfile)
            'Wend
            '_Label1_1.Caption = ""
            'File Log'
            If errore = 0 Then
                Text1.Text = Text1.Text & "Downloading completed successfully ..." & vbCrLf
                Text1.Refresh()
                Text1.SelectionStart = Len(Text1.Text)
                lbl44.Text = "DONE"
            Else
                Text1.Text = Text1.Text & "Download didn't Complete ..." & vbCrLf
                Text1.Refresh()
                Text1.SelectionStart = Len(Text1.Text)
            End If
            Text1.Text = Text1.Text & "Total file(s) : " & CStr(Count) & vbCrLf
            Text1.Refresh()
            Text1.SelectionStart = Len(Text1.Text)
            Text1.Text = Text1.Text & "Error in File(s) : " & CStr(errore) & vbCrLf
            Text1.Refresh()
            Text1.SelectionStart = Len(Text1.Text)
        End If
    End Sub

    Public Sub DownLoadFile_UpTxt(Optional ByRef delRemote As Boolean = False, Optional ByRef dirUD As Boolean = False)
        'Declare Variables
        Dim bRet, bret1 As Boolean
        Dim bret2 As Boolean
        Dim szDirRemote, szFileRemote, szFileLocal As String
        Dim szTempString As String
        Dim nPos, nTemp As Integer
        Dim hFind As Integer
        Dim findfile As WIN32_FIND_DATA
        Dim errore As Short
        Dim Count As Short
        'Total Files Wrong
        errore = 0
        'Total Files
        Count = 0
        'Checking the Connection
        If bActiveSession Then
            'Set the current directory
            If dirUD Then
                Call FtpSetCurrentDirectory(hConnection, dirrecv)
            Else
                Call FtpSetCurrentDirectory(hConnection, dirsend)
            End If
            'Beginning to Look for files
            hFind = FtpFindFirstFile(hConnection, "4pos_upload.txt", findfile, 0, 0)
            If hFind = 0 Then
                Text1.Text = Text1.Text & "No one else is busy Downloading/Uploading ..." & vbCrLf
                Exit Sub
            End If
            Count = 1
            szFileRemote = "4pos_upload.txt" 'Trim(Mid(findfile.cFileName, 1, InStr(1, findfile.cFileName, Chr(0), vbTextCompare) - 1))
            _Label1_1.Text = szFileRemote
            _Label1_1.Refresh()
            bRet = FtpGetFile(hConnection, szFileRemote, gPathHO & "download\" & "/" & szFileRemote, False, INTERNET_FLAG_RELOAD, dwType, 0)
            If bRet = False Then
                'File Log'
                Text1.Text = Text1.Text & "Error while Downloading File " & szFileRemote & " : " & CStr(Err.LastDllError) & vbCrLf
                Text1.Refresh()
                Text1.SelectionStart = Len(Text1.Text)
                errore = errore + 1
            Else
                If delRemote = True Then
                    bret2 = FtpDeleteFile(hConnection, szFileRemote)
                End If
            End If
            'If bRet = False Then ErrorOut cstr(Err.LastDllError), "FtpGetFile"
            'bret1 = InternetFindNextFile(hFind, findfile)
            'While bret1 <> False
            '    szFileRemote = Trim(Mid(findfile.cFileName, 1, InStr(1, findfile.cFileName, Chr(0), vbTextCompare) - 1))
            '    Count = Count + 1
            '    _Label1_1.Caption = szFileRemote
            '    _Label1_1.Refresh
            '    bRet = FtpGetFile(hConnection, szFileRemote, dirrecv & "/" & szFileRemote, False, _
            ''    INTERNET_FLAG_RELOAD, dwType, 0)
            '    If bRet = False Then
            '        'File Log'
            '        Text1.Text = Text1.Text + "Error DownLoad File " + szFileRemote + " : " + CStr(Err.LastDllError) + vbCrLf
            '        Text1.Refresh
            '        Text1.SelStart = Len(Text1.Text)
            '        errore = errore + 1
            '    Else
            '        bret2 = FtpDeleteFile(hConnection, szFileRemote)
            '    End If
            '    bret1 = InternetFindNextFile(hFind, findfile)
            'Wend
            '_Label1_1.Caption = ""
            'File Log'
            If errore = 0 Then
                Text1.Text = Text1.Text & "Downloading completed successfully ..." & vbCrLf
                Text1.Refresh()
                Text1.SelectionStart = Len(Text1.Text)
                lbl44.Text = "DONE"
            Else
                Text1.Text = Text1.Text & "Download didn't Complete ..." & vbCrLf
                Text1.Refresh()
                Text1.SelectionStart = Len(Text1.Text)
            End If
            Text1.Text = Text1.Text & "Total file(s) : " & CStr(Count) & vbCrLf
            Text1.Refresh()
            Text1.SelectionStart = Len(Text1.Text)
            Text1.Text = Text1.Text & "Error in File(s) : " & CStr(errore) & vbCrLf
            Text1.Refresh()
            Text1.SelectionStart = Len(Text1.Text)
        End If
    End Sub

    Public Sub DownLoadFile()
        Dim lDir As String
        Dim szFileConPath As String
        Dim dirsendLocal As String
        'Declare Variables
        Dim bRet, bret1 As Boolean
        Dim bret2 As Boolean
        Dim szDirRemote, szFileRemote, szFileLocal As String
        Dim szTempString As String
        Dim nPos, nTemp As Integer
        Dim hFind As Integer
        Dim findfile As WIN32_FIND_DATA
        Dim errore As Short
        Dim Count As Short
        Dim lString As String
        Dim lStringToday As String
        'Total Files Wrong
        errore = 0
        'Total Files
        Count = 0

        updateStatus("Starting Download")
        updateLOG("DOWNLOAD_START_POINT", "NILL")

        'Checking the Connection
        Dim zLimsU As New CGUnzipFiles
        If bActiveSession Then
            'Set the current directory
            Call FtpSetCurrentDirectory(hConnection, dirrecv)

            If fso.FileExists(gPathHO & "4pos_download.txt") Then fso.DeleteFile(gPathHO & "4pos_download.txt", True)
            dwType = FTP_TRANSFER_TYPE_ASCII
            'DownLoadFile
            DownLoadFile_DownTxt(False, True)
            If fso.FileExists(gPathHO & "4pos_download.txt") Then
                'MsgBox "One of branch/headoffice still busy."
                'Exit Sub
            End If

            tempStatus = BranchID & "|" & Now
            ErrTextstream = fso.OpenTextFile(gPathHO & "4pos_download.txt", Scripting.IOMode.ForWriting, True)
            ErrTextstream.Write(tempStatus)
            ErrTextstream.Close()

            dirsendLocal = gPathHO
            szFileLocal = "4pos_download.txt"
            _Label1_1.Text = szFileLocal
            _Label1_1.Refresh()
            System.Windows.Forms.Application.DoEvents()
            szFileConPath = dirsendLocal + szFileLocal
            szFileRemote = szFileLocal
            If (szDirRemote = "") Then szDirRemote = "\"
            rcd(szDirRemote)

            bRet = FtpPutFile(hConnection, szFileConPath, szFileRemote, dwType, 0)
            If bRet = False Then
                'File Log'
                '            Text1.Text = Text1.Text + "Error while Uploading File : " + CStr(Err.LastDllError) + vbCrLf
                '            Text1.Refresh
                '            DoEvents
                '            Text1.SelStart = Len(Text1.Text)
                '            errore = errore + 1
            End If

            lStringToday = Replace(CStr(Now), " ", "_")
            lStringToday = Replace(lStringToday, "/", "-")
            lStringToday = Replace(lStringToday, ":", "")
            If fso.FolderExists(gPathHO & "download\" & lStringToday) Then
            Else
                fso.CreateFolder(gPathHO & "download\" & lStringToday)
            End If

            fso.CopyFile(serverPath & "pricing.mdb", gPathHO & "download\" & lStringToday & "\pricing.mdb", True)
            fso.CopyFile(serverPath & "waitron.mdb", gPathHO & "download\" & lStringToday & "\waitron.mdb", True)

            If fso.FileExists(gPathHO & "download\" & "4pos_upload.txt") Then fso.DeleteFile(gPathHO & "download\" & "4pos_upload.txt", True)
            dwType = FTP_TRANSFER_TYPE_ASCII
            DownLoadFile_UpTxt(False, True)
            If fso.FileExists(gPathHO & "download\" & "4pos_upload.txt") Then
                fso.MoveFile(gPathHO & "download\" & "4pos_upload.txt", gPathHO & "download\" & lStringToday & "\4pos_upload.txt")
                ErrTextstream = fso.OpenTextFile(gPathHO & "download\" & lStringToday & "\4pos_upload.txt", Scripting.IOMode.ForReading, True)
                lString = ErrTextstream.ReadAll
                ErrTextstream.Close()
            Else
                MsgBox("Upload information file not found on server. Please upload from HO again.")
                Exit Sub
            End If

            'Beginning to Look for files
            System.Windows.Forms.Application.DoEvents()
            cmdPulsante_Click(cmdPulsante.Item(1), New System.EventArgs())
            cmdPulsante_Click(cmdPulsante.Item(0), New System.EventArgs())
            System.Windows.Forms.Application.DoEvents()
            Call FtpSetCurrentDirectory(hConnection, dirrecv)
            System.Windows.Forms.Application.DoEvents()
            dwType = FTP_TRANSFER_TYPE_BINARY

            '        If BranchType = "1" Then
            '            DownLoadFile_DownFile False, lString, True ' & "_hqsales*.zip"
            '
            '                Count = 1
            '                If fso.FileExists(gPathHO & lString) Then fso.MoveFile gPathHO & lString, gPathHO & "download\" & lStringToday & "\" & lString
            '                If fso.FolderExists(serverPath & "SalesTransaction") Then
            '                Else
            '                    fso.CreateFolder serverPath & "SalesTransaction"
            '                End If
            '                lDir = Dir(serverPath & "SalesTransaction\*.*")
            '                Do Until lDir = ""
            '                    fso.DeleteFile serverPath & "SalesTransaction\" & lDir, True
            '                    lDir = Dir()
            '                Loop
            '                If fso.FileExists(gPathHO & "download\" & lStringToday & "\" & lString) Then fso.CopyFile gPathHO & "download\" & lStringToday & "\" & lString, serverPath & ("hqsales" & Split(lString, "hqsales")(1)), True
            '
            '                Dim zLims As New ZipIt.CGUnzipFiles
            '                zLims.HonorDirectories = False
            '                zLims.Unzip serverPath & ("hqsales" & Split(lString, "hqsales")(1)), serverPath & "SalesTransaction"
            '
            '        Else
            'hFind = FtpFindFirstFile(hConnection, lString & "_data.zip", findfile, 0, 0)
            DownLoadFile_DownFile(False, lString & "_data.zip", True)

            Count = 1
            If fso.FileExists(gPathHO & lString & "_data.zip") Then fso.MoveFile(gPathHO & lString & "_data.zip", gPathHO & "download\" & lStringToday & "\" & lString & "_data.zip")
            If fso.FolderExists(serverPath & "update") Then
            Else
                fso.CreateFolder(serverPath & "update")
            End If
            lDir = Dir(serverPath & "update\*.*")
            Do Until lDir = ""
                fso.DeleteFile(serverPath & "update\" & lDir, True)
                lDir = Dir()
            Loop
            If fso.FileExists(gPathHO & "download\" & lStringToday & "\" & lString & "_data.zip") Then fso.CopyFile(gPathHO & "download\" & lStringToday & "\" & lString & "_data.zip", serverPath & "data.zip", True)

            zLimsU.HonorDirectories = False
            zLimsU.Unzip(serverPath & "data.zip", serverPath & "update")
            '        End If

            System.Windows.Forms.Application.DoEvents()
            cmdPulsante_Click(cmdPulsante.Item(1), New System.EventArgs())
            cmdPulsante_Click(cmdPulsante.Item(0), New System.EventArgs())
            System.Windows.Forms.Application.DoEvents()
            Call FtpSetCurrentDirectory(hConnection, dirrecv)
            System.Windows.Forms.Application.DoEvents()
            dwType = FTP_TRANSFER_TYPE_ASCII
            DownLoadFile_DownTxt(True, True)
            System.Windows.Forms.Application.DoEvents()
            DownLoadFile_DownTxt(True, True)

            _Label1_1.Text = ""
            'File Log'
            If errore = 0 Then
                Text1.Text = Text1.Text & "Downloading completed successfully ..." & vbCrLf
                Text1.Refresh()
                Text1.SelectionStart = Len(Text1.Text)
                lbl44.Text = "DONE"

                updateLOG("DOWNLOAD_COMPLETED", "NILL")
            Else
                Text1.Text = Text1.Text & "Download didn't Complete ..." & vbCrLf
                Text1.Refresh()
                Text1.SelectionStart = Len(Text1.Text)
                updateLOG("DOWNLOAD_NOT_COMPLETED", "NILL")
            End If
            Text1.Text = Text1.Text & "Total file(s) : " & CStr(Count) & vbCrLf
            Text1.Refresh()
            Text1.SelectionStart = Len(Text1.Text)
            Text1.Text = Text1.Text & "Error in File(s) : " & CStr(errore) & vbCrLf
            Text1.Refresh()
            Text1.SelectionStart = Len(Text1.Text)
        End If
    End Sub


    Private Sub DisconnettiServer()
        'Connect to Server Closed
        If hConnection <> 0 Then InternetCloseHandle(hConnection)
        hConnection = 0

        If sqlDBcn Is Nothing Then
        Else
            If sqlDBcn.State Then
                updateLOG("DISCONNECTED", "NILL")
                sqlDBcn.Close()
            End If
        End If
    End Sub


    Private Sub DisconnettiInternet()
        'Closing Internet
        If hOpen <> 0 Then InternetCloseHandle(hOpen)
        lbl66.Text = "DONE"
        hOpen = 0
    End Sub

    Private Sub rcd(ByRef pszDir As String)
        Dim sPathFromRoot As String
        Dim bRet As Boolean
        If pszDir <> "" Then
            If InStr(1, pszDir, server) Then
                sPathFromRoot = Mid(pszDir, Len(server) + 1, Len(pszDir) - Len(server))
            Else
                sPathFromRoot = pszDir
            End If
            If sPathFromRoot = "" Then sPathFromRoot = "/"
            bRet = FtpSetCurrentDirectory(hConnection, sPathFromRoot)
        End If
    End Sub
    Private Sub ScriviFileLog()

        Dim iFile As Short
        iFile = FreeFile()
        FileOpen(iFile, NomeFileLog, OpenMode.Append)
        PrintLine(iFile, Text1.Text)
        FileClose(iFile)

    End Sub

    Public Function getRSMaster(ByRef sql As Object) As ADODB.Recordset
        Dim cnnDBmaster As Object
        getRSMaster = New ADODB.Recordset
        getRSMaster.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        getRSMaster.Open(sql, cnnDBmaster, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
    End Function

    Public Function openConnectionWaitron() As Boolean
        On Error GoTo openConnection_Error
        Dim createDayend As Boolean
        Dim strDBPath As String
        createDayend = False
        openConnectionWaitron = True
        cnnDBWaitron = New ADODB.Connection
        strDBPath = serverPath & "Waitron.mdb"
        With cnnDBWaitron
            .Provider = "Microsoft.ACE.OLEDB.12.0"
            .Properties("Jet OLEDB:System Database").Value = serverPath & "Secured.mdw"
            .Open(strDBPath, "liquid", "lqd")
        End With
        Exit Function

openConnection_Error:
        openConnectionWaitron = False

    End Function
    Public Sub closeConnectionWaitron()
        cnnDBWaitron.Close()
        cnnDBWaitron = Nothing
    End Sub
    Public Function getRSwaitron(ByRef sql As Object) As ADODB.Recordset
        getRSwaitron = New ADODB.Recordset
        getRSwaitron.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        getRSwaitron.Open(sql, cnnDBWaitron, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
    End Function

    Private Sub cmdBuild_Click(Optional ByRef zipPath As String = "")
        Dim szFileLocal As String
        Dim TMPgMasterPath As String
        Dim rs As ADODB.Recordset
        'Dim fso As New FileSystemObject
        Dim lDir As String
        On Error GoTo buildError
        'If MsgBox("A data instruction will prepare a download for each store of the latest stock and pricing data." & vbCrLf & vbCrLf & "Are you sure you wish to continue?", vbQuestion + vbYesNo + vbDefaultButton2, "Prepare Download") = vbYes Then

        TMPgMasterPath = gMasterPath
        gMasterPath = gPathHO & "upload\" & zipPath & "\" 'serverPath '"c:\4POSServer\"

        If fso.FolderExists(gMasterPath & "Data\") Then
        Else
            fso.CreateFolder(gMasterPath & "Data\")
        End If
        lDir = Dir(gMasterPath & "data\*.*")
        Do Until lDir = ""
            fso.DeleteFile(gMasterPath & "data\" & lDir, True)
            lDir = Dir()
        Loop
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        System.Windows.Forms.Application.DoEvents()
        rs = getRS("SELECT 1 as MasterID, #" & Today & "# as Master_DateReplica")
        rs.Save(gMasterPath & "Data\Master.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM Catalogue")
        rs.Save(gMasterPath & "Data\catalogue.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM PriceSet")
        rs.Save(gMasterPath & "Data\PriceSet.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM Channel ORDER BY ChannelID")
        rs.Save(gMasterPath & "Data\channel.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM Deposit ORDER BY DepositID")
        rs.Save(gMasterPath & "Data\Deposit.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM PackSize ORDER BY PackSizeID")
        rs.Save(gMasterPath & "Data\PackSize.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM Person ORDER BY PersonID")
        rs.Save(gMasterPath & "Data\Person.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM PersonChannelLnk")
        rs.Save(gMasterPath & "Data\PersonChannelLnk.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM PriceChannelLnk")
        rs.Save(gMasterPath & "Data\PriceChannelLnk.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM PricingGroup ORDER BY PricingGroupID")
        rs.Save(gMasterPath & "Data\PricingGroup.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM PricingGroupChannelLnk")
        rs.Save(gMasterPath & "Data\PricingGroupChannelLnk.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM PropChannelLnk")
        rs.Save(gMasterPath & "Data\PropChannelLnk.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM [Set] ORDER BY SetID")
        rs.Save(gMasterPath & "Data\Set.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM SetItem")
        rs.Save(gMasterPath & "Data\SetItem.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM Shrink ORDER BY ShrinkID")
        rs.Save(gMasterPath & "Data\Shrink.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM ShrinkItem")
        rs.Save(gMasterPath & "Data\ShrinkItem.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM StockGroup ORDER BY StockGroupID")
        rs.Save(gMasterPath & "Data\StockGroup.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM StockItem ORDER BY StockItemID")
        rs.Save(gMasterPath & "Data\stockitem.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM Supplier ORDER BY SupplierID")
        rs.Save(gMasterPath & "Data\Supplier.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM SupplierDepositLnk")
        rs.Save(gMasterPath & "Data\SupplierDepositLnk.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM Promotion")
        rs.Save(gMasterPath & "Data\Promotion.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM PromotionItem")
        rs.Save(gMasterPath & "Data\PromotionItem.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM StockBreak")
        rs.Save(gMasterPath & "Data\StockBreak.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM RecipeStockItemLnk")
        rs.Save(gMasterPath & "Data\RecipeStockItemLnk.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM CashTransaction")
        rs.Save(gMasterPath & "Data\CashTransaction.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM Increment")
        rs.Save(gMasterPath & "Data\Increment.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM IncrementStockItemLnk")
        rs.Save(gMasterPath & "Data\IncrementStockItemLnk.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM IncrementQuantity")
        rs.Save(gMasterPath & "Data\IncrementQuantity.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM Message")
        rs.Save(gMasterPath & "Data\Message.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM MessageItem")
        rs.Save(gMasterPath & "Data\MessageItem.rs", ADODB.PersistFormatEnum.adPersistADTG)
        rs = getRS("SELECT * FROM StockItemMessageLnk")
        rs.Save(gMasterPath & "Data\StockItemMessageLnk.rs", ADODB.PersistFormatEnum.adPersistADTG)
        openConnectionWaitron()
        rs = getRSwaitron("SELECT * FROM POSMenu")
        rs.Save(gMasterPath & "Data\POSMenu.rs", ADODB.PersistFormatEnum.adPersistADTG)

        'ExecCmd gMasterPath & "wzzip.exe " & gMasterPath & "Data\data.zip " & gMasterPath & "Data\*.*"
        If fso.FileExists(gMasterPath & zipPath & "_data.zip") Then fso.DeleteFile(gMasterPath & zipPath & "_data.zip", True)

        Dim zLims As New CGZipFiles
        zLims.ZipFileName = gMasterPath & zipPath & "_data.zip"
        'zLims.RecurseFolders = False
        szFileLocal = Dir(gMasterPath & "Data\*.*")
        While szFileLocal <> ""
            zLims.AddFile(gMasterPath & "Data\" & szFileLocal)
            szFileLocal = Dir()
        End While
        zLims.MakeZipFile()

        'fso.CopyFile gMasterPath & "Data\data.zip", gMasterPath & "Data.zip", True

        '        Set rs = getRSMaster("SELECT locationCompany_1.locationCompanyID, locationCompany.locationCompany_Email FROM locationCompany INNER JOIN (locationCompany AS locationCompany_1 INNER JOIN location ON locationCompany_1.locationCompany_LocationID = location.locationID) ON locationCompany.locationCompany_LocationID = location.locationID WHERE (((locationCompany_1.locationCompanyID)=" & lblCompany.Tag & "));")
        '
        '        On Local Error Resume Next
        '        MAPISession1.SignOn
        '        MAPIMessages1.SessionID = MAPISession1.SessionID
        '        MAPIMessages1.Compose
        '        x = -1
        '        On Local Error Resume Next
        '        Do Until rs.EOF
        '
        '            If rs("locationCompany_Email") <> "" Then
        '                x = x + 1
        '                MAPIMessages1.RecipIndex = x
        '                MAPIMessages1.RecipDisplayName = rs("locationCompany_Email")
        '                MAPIMessages1.ResolveName
        '            End If
        '
        '            rs.MoveNext
        '        Loop
        '        Set rs = getRSMaster("SELECT locationAudit.locationAuditID, locationAudit.locationAudit_Email FROM locationCompany INNER JOIN locationAudit ON locationCompany.locationCompany_LocationID = locationAudit.locationAudit_LocationID WHERE (((locationCompany.locationCompanyID)=" & lblCompany.Tag & "));")
        '        Do Until rs.EOF
        '            x = x + 1
        '            MAPIMessages1.RecipIndex = x
        '            MAPIMessages1.RecipDisplayName = rs("locationAudit_Email")
        '            MAPIMessages1.ResolveName
        '            rs.MoveNext
        '        Loop
        '        MAPIMessages1.MsgSubject = "4POS Data"
        '        MAPIMessages1.MsgNoteText = "4POS Pricing update as at " & Format(Now(), "ddd, dd-mmm-yyyy hh:nn")
        '        MAPIMessages1.AttachmentType = mapData
        '        MAPIMessages1.AttachmentName = "data.zip"
        '        MAPIMessages1.AttachmentPathName = gMasterPath & "data.zip"
        '        MAPIMessages1.Send
        '        MAPISession1.SignOff

        gMasterPath = TMPgMasterPath
        'End If
        Me.Cursor = System.Windows.Forms.Cursors.Default

        Exit Sub
buildError:
        If Err.Number = 53 Then
            MsgBox("Please ensure if you have 'WinZip Command Line Support Add-On' installed on your system.")
        Else
            MsgBox(Err.Number & " " & Err.Description)
        End If
        Resume Next
    End Sub

    Private Sub UpLoad()
        Dim sql As String
        Dim bRet As Boolean
        Dim szDirRemote, szFileRemote, szFileLocal As String
        Dim szTempString As String
        Dim szFileConPath As String
        Dim errore As Short
        Dim Count As Short
        Dim dirsendLocal As String
        Dim lString As String
        Dim zipname As String

        Count = 0
        errore = 0

        updateStatus("Starting Upload")
        updateLOG("UPLOAD_START_POINT", "NILL")

        If bActiveSession Then
            szTempString = server + dirsend ''dirserv
            szDirRemote = VB.Right(szTempString, Len(szTempString) - Len(server))

            'If BranchType = "1" Then

            If fso.FileExists(gPathHO & "4pos_download.txt") Then fso.DeleteFile(gPathHO & "4pos_download.txt", True)
            dwType = FTP_TRANSFER_TYPE_ASCII
            'DownLoadFile
            DownLoadFile_DownTxt()
            If fso.FileExists(gPathHO & "4pos_download.txt") Then
                'MsgBox "One of branch/headoffice still busy."
                'Exit Sub
            End If

            tempStatus = BranchID & "|" & Now
            ErrTextstream = fso.OpenTextFile(gPathHO & "4pos_download.txt", Scripting.IOMode.ForWriting, True)
            ErrTextstream.Write(tempStatus)
            ErrTextstream.Close()

            dirsendLocal = gPathHO
            szFileLocal = "4pos_download.txt"
            _Label1_1.Text = szFileLocal
            _Label1_1.Refresh()
            System.Windows.Forms.Application.DoEvents()
            szFileConPath = dirsendLocal & szFileLocal
            szFileRemote = szFileLocal
            If (szDirRemote = "") Then szDirRemote = "\"
            rcd(szDirRemote)

            bRet = FtpPutFile(hConnection, szFileConPath, szFileRemote, dwType, 0)
            If bRet = False Then
                'File Log'
                Text1.Text = Text1.Text & "Error while Uploading File : " & CStr(Err.LastDllError) & vbCrLf
                Text1.Refresh()
                System.Windows.Forms.Application.DoEvents()
                Text1.SelectionStart = Len(Text1.Text)
                errore = errore + 1
            End If

            zipname = ""
            If BranchType = "1" Then

                lString = Replace(CStr(Now), " ", "_")
                lString = Replace(lString, "/", "-")
                lString = Replace(lString, ":", "")

                If fso.FolderExists(gPathHO & "upload\" & lString) Then
                Else
                    fso.CreateFolder(gPathHO & "upload\" & lString)
                End If

                dwType = FTP_TRANSFER_TYPE_BINARY
                cmdBuild_Click(lString)

                dirsendLocal = gPathHO & "upload\" & lString & "\" 'serverPath
                szFileLocal = lString & "_data.zip"

                Count = Count + 1
                _Label1_1.Text = szFileLocal
                _Label1_1.Refresh()
                System.Windows.Forms.Application.DoEvents()
                szFileConPath = dirsendLocal & szFileLocal
                szFileRemote = szFileLocal
                If (szDirRemote = "") Then szDirRemote = "\"
                rcd(szDirRemote)
                bRet = FtpPutFile(hConnection, szFileConPath, szFileRemote, dwType, 0)
                If bRet = False Then
                    'File Log'
                    Text1.Text = Text1.Text & "Error while Uploading File : " & CStr(Err.LastDllError) & vbCrLf
                    Text1.Refresh()
                    System.Windows.Forms.Application.DoEvents()
                    Text1.SelectionStart = Len(Text1.Text)
                    errore = errore + 1

                    updateLOG("UPLOAD_ERROR_POINT_1", CStr(Err.LastDllError))
                End If

                'File Log'
                If errore = 0 Then
                    Text1.Text = Text1.Text & "Uploading completed successfully ..." & vbCrLf
                    Text1.Refresh()
                    Text1.SelectionStart = Len(Text1.Text)
                    lbl33.Text = "DONE"

                    updateLOG("UPLOAD_COMPLETED", "NILL")
                    sql = "UPDATE HeadOffice SET HeadOffice_LastLoginUser='" & frmMenu.lblUser.Text & "', HeadOffice_LastLoginBranch=(SELECT Branch_Name FROM Branch WHERE BranchID=" & CInt(BranchID) & "), HeadOffice_LastUpdate='" & Now & "' WHERE HeadOfficeID=" & CInt(HOfficeID) & ";"
                    sqlDBcn.Execute(sql)
                Else
                    Text1.Text = Text1.Text & "Upload didn't Complete ..." & vbCrLf
                    Text1.Refresh()

                    updateLOG("UPLOAD_NOT_COMPLETED", "NILL")
                End If
                Text1.Text = Text1.Text & "Total file(s) : " & CStr(Count) & vbCrLf
                Text1.Refresh()
                Text1.SelectionStart = Len(Text1.Text)
                Text1.Text = Text1.Text & "Error in File(s) : " & CStr(errore) & vbCrLf
                Text1.Refresh()
                Text1.SelectionStart = Len(Text1.Text)
                _Label1_1.Text = ""

            Else

                '                    lString = Replace(Now, " ", "_")
                '                    lString = Replace(lString, "/", "-")
                '                    lString = Replace(lString, ":", "")
                '
                '                    If fso.FolderExists(gPathHO & "upload\" & lString) Then Else fso.CreateFolder gPathHO & "upload\" & lString
                '
                '                    dwType = FTP_TRANSFER_TYPE_BINARY
                '                    If copyFilesFromPoints(lString) Then Else Exit Sub
                '
                '                    Dim rj        As Recordset
                '                    'Dim zipName   As String
                '                    Set rj = getRS("SELECT * FROM CompanyEmails")
                '                    If rj.RecordCount Then
                '                         zipname = lString & "_hqsales" & rj("Comp_ID") & ".zip"
                '                    Else
                '                         zipname = lString & "_hqsales.zip"
                '                    End If
                '
                '                     If fso.FileExists(gPathHO & "upload\" & lString & "\" & zipname) Then fso.DeleteFile gPathHO & "upload\" & lString & "\" & zipname, True
                '
                '                     Dim zLims As New ZipIt.CGZipFiles
                '                     zLims.ZipFileName = gPathHO & "upload\" & lString & "\" & zipname
                '                     zLims.RecurseFolders = False
                '
                '                    szFileLocal = Dir(gPathHO & "upload\" & lString & "\" & "HQSales\*.*")
                '                    While szFileLocal <> ""
                '                        zLims.AddFile gPathHO & "upload\" & lString & "\" & "HQSales\" & szFileLocal
                '                        szFileLocal = Dir
                '                    Wend
                '                    zLims.MakeZipFile
                '
                '                    dirsendLocal = gPathHO & "upload\" & lString & "\"
                '                    szFileLocal = zipname
                '
                '                    Count = Count + 1
                '                    _Label1_1.Caption = szFileLocal
                '                    _Label1_1.Refresh
                '                    DoEvents
                '                    szFileConPath = dirsendLocal + szFileLocal
                '                    szFileRemote = szFileLocal
                '                    If (szDirRemote = "") Then szDirRemote = "\"
                '                    rcd szDirRemote
                '                    bRet = FtpPutFile(hConnection, szFileConPath, szFileRemote, _
                ''                     dwType, 0)
                '                    If bRet = False Then
                '                        'File Log'
                '                        Text1.Text = Text1.Text + "Error while Uploading File : " + CStr(Err.LastDllError) + vbCrLf
                '                        Text1.Refresh
                '                        DoEvents
                '                        Text1.SelStart = Len(Text1.Text)
                '                        errore = errore + 1
                '                    End If
                '
                '                    'File Log'
                '                    If errore = 0 Then
                '                        Text1.Text = Text1.Text + "Uploading completed successfully ..." + vbCrLf
                '                        Text1.Refresh
                '                        Text1.SelStart = Len(Text1.Text)
                '                        lbl33 = "DONE"
                '                    Else
                '                        Text1.Text = Text1.Text + "Upload didn't Complete ..." + vbCrLf
                '                        Text1.Refresh
                '
                '                    End If
                '                    Text1.Text = Text1.Text + "Total file(s) : " + CStr(Count) + vbCrLf
                '                    Text1.Refresh
                '                    Text1.SelStart = Len(Text1.Text)
                '                    Text1.Text = Text1.Text + "Error in File(s) : " + CStr(errore) + vbCrLf
                '                    Text1.Refresh
                '                    Text1.SelStart = Len(Text1.Text)
                '                    _Label1_1.Caption = ""


            End If

            If fso.FileExists(gPathHO & "upload\" & "4pos_upload.txt") Then fso.DeleteFile(gPathHO & "upload\" & "4pos_upload.txt", True)
            dwType = FTP_TRANSFER_TYPE_ASCII

            tempStatus = IIf(zipname = "", lString, zipname) 'Now()
            ErrTextstream = fso.OpenTextFile(gPathHO & "upload\" & "4pos_upload.txt", Scripting.IOMode.ForWriting, True)
            ErrTextstream.Write(tempStatus)
            ErrTextstream.Close()

            dirsendLocal = gPathHO & "upload\"
            szFileLocal = "4pos_upload.txt"
            _Label1_1.Text = szFileLocal
            _Label1_1.Refresh()
            System.Windows.Forms.Application.DoEvents()
            szFileConPath = dirsendLocal & szFileLocal
            szFileRemote = szFileLocal
            If (szDirRemote = "") Then szDirRemote = "\"
            rcd(szDirRemote)

            bRet = FtpPutFile(hConnection, szFileConPath, szFileRemote, dwType, 0)
            If bRet = False Then
                'File Log'
                Text1.Text = Text1.Text & "Error while Uploading File : " & CStr(Err.LastDllError) & vbCrLf
                Text1.Refresh()
                System.Windows.Forms.Application.DoEvents()
                Text1.SelectionStart = Len(Text1.Text)
                errore = errore + 1
                updateLOG("UPLOAD_ERROR_POINT_2", CStr(Err.LastDllError))
            End If

            DownLoadFile_DownTxt(True)
            System.Windows.Forms.Application.DoEvents()
            DownLoadFile_DownTxt(True)
            '-------------------------------------------------------------------
            'Else
            'End If




        End If

        updateStatus("Finishing Upload")
        updateLOG("UPLOAD_END_POINT", "NILL")
    End Sub


    Private Function copyFilesFromPoints(Optional ByRef zipPath As String = "") As Boolean
        Dim sFiles As Boolean
        Dim f_File As String
        Dim ldir1 As String
        Dim strFile As String
        Dim rj As ADODB.Recordset
        Dim fso As New Scripting.FileSystemObject
        Dim DTPDate As Date

        sFiles = False
        'UPGRADE_WARNING: Couldn't resolve default property of object DTPicker1().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        DTPDate = _DTPicker1_0.Value
        gMasterPath = gPathHO & "upload\" & zipPath & "\"

        f_File = Trim(Str(Year(DTPDate))) & "\" & Trim(Str(Month(DTPDate))) & "\" & Trim(Str(VB.Day(DTPDate)))

        rj = getRS("SELECT POS_Name FROM POS WHERE POS_Disabled = False AND POS_KitchenMonitor = False;")

        If rj.RecordCount Then
            'If FSO.FolderExists(serverPath & "HQSales") Then Else FSO.CreateFolder serverPath & "HQSales"
            If fso.FolderExists(gMasterPath & "HQSales") Then
            Else
                fso.CreateFolder(gMasterPath & "HQSales")
            End If

            'Make sure the HQSales file is empty...
            ldir1 = Dir(gMasterPath & "HQSales\*.*")
            Do Until ldir1 = ""
                fso.DeleteFile(gMasterPath & "HQSales\" & ldir1, True)
                ldir1 = Dir()
            Loop

            Do While rj.EOF = False
                If LCase(rj.Fields("POS_Name").Value) = "localhost" Then
                    If fso.FolderExists(serverPath & "data\Server\" & f_File) Then
                        ldir1 = Dir(serverPath & "data\Server\" & f_File & "\*.*")
                        Do Until ldir1 = ""
                            fso.CopyFile(serverPath & "data\Server\" & f_File & "\" & ldir1, gMasterPath & "HQSales\" & ldir1, True)
                            ldir1 = Dir()
                            sFiles = True
                        Loop
                    End If
                Else
                    If fso.FolderExists(serverPath & "data\" & rj.Fields("POS_Name").Value & "\" & f_File) Then
                        ldir1 = Dir(serverPath & "data\" & rj.Fields("POS_Name").Value & "\" & f_File & "\*.*")
                        Do Until ldir1 = ""
                            fso.CopyFile(serverPath & "data\" & rj.Fields("POS_Name").Value & "\" & f_File & "\" & ldir1, gMasterPath & "HQSales\" & ldir1, True)
                            ldir1 = Dir()
                            sFiles = True
                        Loop

                    End If
                End If
                rj.MoveNext()
            Loop
        End If

        If sFiles = True Then
            copyFilesFromPoints = True
        Else
            copyFilesFromPoints = False
        End If

    End Function

    Private Function ConnessioneInternet() As Boolean
        '***********************
        'Internet connection
        '***********************
        hOpen = InternetOpen(scUserAgent, INTERNET_OPEN_TYPE_DIRECT, vbNullString, vbNullString, 0)
        If hOpen = 0 Then
            'File Log'
            ConnessioneInternet = False
            Exit Function
        Else
            'File Log'
            lbl11.Text = "DONE"
            ConnessioneInternet = True
            Exit Function
        End If
    End Function

    Private Function ConnessioneServer() As Boolean
        Dim sql As String
        Dim j As String
        Dim s As String
        Dim x As Integer
        Dim y As Integer

        Dim nflag As Integer
        If CDbl(tipftp) = 1 Then
            nflag = INTERNET_FLAG_PASSIVE
        Else
            nflag = 0
        End If

        Dim getServer As String
        Dim ServerU As String
        Dim ServerP As String

        getServer = SendAPIRequest(ServerN)
        Debug.Print(getServer)
        If Trim(getServer) = "" Then
            lbl11.Text = "No server Found!"
            bActiveSession = False
            ConnessioneServer = False
            Exit Function
        Else
            y = 0
            For x = 1 To Len(getServer)
                If y = 2 Then
                    s = s & " " & Mid(getServer, x, 1)
                    y = 0
                Else
                    s = s & Mid(getServer, x, 1)
                End If
                y = y + 1
            Next
            Text2.Text = s
            Text3.Text = HexToStr(Text2.Text)
            For x = 1 To Len(Text3.Text)
                If x = 3 Then
                    's = s & "1" & Mid(Text1, x, 1)
                ElseIf x = 8 Then
                    's = s & "1" & Mid(Text1, x, 1)
                Else
                    j = j & Mid(Text3.Text, x, 1)
                End If
            Next
            Text4.Text = j
            Text4.Text = a.DecryptString(Text4.Text, "786YaAllah0zoi", True)

            If InStr(1, Trim(Text4.Text), "|") Then
                If UBound(Split(Text4.Text, "|")) = 2 Then
                    server = Split(Text4.Text, "|")(0)
                    ServerU = Split(Text4.Text, "|")(1)
                    ServerP = Split(Text4.Text, "|")(2)
                Else
                    bActiveSession = False
                    ConnessioneServer = False
                    Exit Function
                End If
            Else
                bActiveSession = False
                ConnessioneServer = False
                Exit Function
            End If
        End If


        getServer = SendAPIRequest(sqlLinkPath)
        Debug.Print(getServer)
        If Trim(getServer) = "" Then
            lbl11.Text = "No server Found!"
            bActiveSession = False
            ConnessioneServer = False
            Exit Function
        Else
            y = 0
            s = ""
            j = ""
            For x = 1 To Len(getServer)
                If y = 2 Then
                    s = s & " " & Mid(getServer, x, 1)
                    y = 0
                Else
                    s = s & Mid(getServer, x, 1)
                End If
                y = y + 1
            Next
            Text2.Text = s
            Text3.Text = HexToStr(Text2.Text)
            For x = 1 To Len(Text3.Text)
                If x = 3 Then
                    's = s & "1" & Mid(Text1, x, 1)
                ElseIf x = 8 Then
                    's = s & "1" & Mid(Text1, x, 1)
                Else
                    j = j & Mid(Text3.Text, x, 1)
                End If
            Next
            Text4.Text = j
            Text4.Text = a.DecryptString(Text4.Text, "786YaAllah0zoi", True)

            If InStr(1, Trim(Text4.Text), "|") Then
                If UBound(Split(Text4.Text, "|")) = 3 Then
                    sqlServer = Split(Text4.Text, "|")(0)
                    sqlDBase = Split(Text4.Text, "|")(1)
                    sqlUser = Split(Text4.Text, "|")(2)
                    sqlPassWord = Split(Text4.Text, "|")(3)
                Else
                    bActiveSession = False
                    ConnessioneServer = False
                    Exit Function
                End If
            Else
                bActiveSession = False
                ConnessioneServer = False
                Exit Function
            End If
        End If

        hConnection = InternetConnect(hOpen, server, INTERNET_INVALID_PORT_NUMBER, ServerU, ServerP, INTERNET_SERVICE_FTP, nflag, 0)
        If hConnection = 0 Then
            bActiveSession = False
            ConnessioneServer = False
            Exit Function
        Else

            'sql
            sqlDBcn = New ADODB.Connection
            sqlDBcn.ConnectionString = "PROVIDER=MSDASQL;driver={SQL Server};server=" & sqlServer & ";uid=" & sqlUser & ";pwd=" & sqlPassWord & ";database=" & sqlDBase & ";"
            sqlDBcn.Open()
            If sqlDBcn Is Nothing Then
                Text1.Text = Text1.Text & "Error in Data Server Connection : " & CStr(CStr(Err.LastDllError)) & vbCrLf
                Text1.Refresh()
                Text1.SelectionStart = Len(Text1.Text)
                bActiveSession = False
                ConnessioneServer = False
                Exit Function
            Else
                If sqlDBcn.State Then
                    'cnWebSql.Close
                Else
                    Text1.Text = Text1.Text & "Error in Data Server Connection : " & CStr(CStr(Err.LastDllError)) & vbCrLf
                    Text1.Refresh()
                    Text1.SelectionStart = Len(Text1.Text)
                    bActiveSession = False
                    ConnessioneServer = False
                    Exit Function
                End If
            End If

            'HEADOFFICE ------------------------
            rsWebDB = New ADODB.Recordset
            sql = "SELECT HeadOffice_Path FROM HeadOffice WHERE (HeadOffice.HeadOfficeID = " & CShort(HOfficeID) & ");"
            With rsWebDB
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenForwardOnly
                .LockType = ADODB.LockTypeEnum.adLockBatchOptimistic
                .let_Source(sql)
                .ActiveConnection = sqlDBcn
                .Open()
                .let_ActiveConnection(Nothing)
            End With
            If rsWebDB.RecordCount Then
                If IsDBNull(rsWebDB.Fields("HeadOffice_Path").Value) Then
                    updateStatus("Web path not found for Headoffice # " & HOfficeID)
                    bActiveSession = False
                    ConnessioneServer = False
                    Exit Function
                Else
                    If BranchType = "1" Then
                        dirsend = rsWebDB.Fields("HeadOffice_Path").Value
                        dirrecv = rsWebDB.Fields("HeadOffice_Path").Value
                    Else
                        dirrecv = rsWebDB.Fields("HeadOffice_Path").Value
                    End If
                    dirserv = "/httpsdocs/HeadOffice"
                End If
            Else
                updateStatus("No information found for Headoffice # " & HOfficeID)
                bActiveSession = False
                ConnessioneServer = False
                Exit Function
            End If

            'BRANCH ------------------------
            rsWebDB = New ADODB.Recordset
            sql = "SELECT Branch_Path FROM Branch WHERE (Branch.BranchID = " & CShort(BranchID) & ");"
            With rsWebDB
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenForwardOnly
                .LockType = ADODB.LockTypeEnum.adLockBatchOptimistic
                .let_Source(sql)
                .ActiveConnection = sqlDBcn
                .Open()
                .let_ActiveConnection(Nothing)
            End With
            If rsWebDB.RecordCount Then
                If IsDBNull(rsWebDB.Fields("Branch_Path").Value) Then
                    updateStatus("Web path not found for Branch # " & HOfficeID)
                    bActiveSession = False
                    ConnessioneServer = False
                    Exit Function
                Else
                    If BranchType = "0" Then
                        dirsend = rsWebDB.Fields("Branch_Path").Value
                    Else
                        'dirrecv = rsWebDB("Branch_Path")
                    End If
                    dirserv = "/httpdocs/HeadOffice"
                End If
            Else
                updateStatus("No information found for Branch # " & HOfficeID)
                bActiveSession = False
                ConnessioneServer = False
                Exit Function
            End If

            updateLOG("CONNECTED", "NILL")

            'ftp
            bActiveSession = True
            ConnessioneServer = True
            lbl22.Text = "DONE"
            Exit Function
        End If

    End Function

    Private Sub cmdPulsante_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Integer
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Index = GetIndexer(txtBox, cmdPulsante)
        Dim sql As String
        Dim frmSetup As Object

        Dim lString As String
        Dim bGetFail As Boolean
        Dim lDir As String
        Select Case Index

            Case 0
                '***********************
                'Connet
                '***********************
                Text1.Text = Text1.Text & "***************************************************************" & vbCrLf
                Text1.Text = Text1.Text & "Date           : " & Format(Now, "dd/mm/yyyy") & vbCrLf
                Text1.Text = Text1.Text & "Time           : " & Format(Now, "hh:mm:ss") & vbCrLf
                'Text1.Text = Text1.Text + "User           : " + prgCol + vbCrLf
                Text1.Text = Text1.Text & "***************************************************************" & vbCrLf
                Text1.Text = Text1.Text & "Starting Internet Connection ..." & vbCrLf
                Text1.Refresh()
                Text1.SelectionStart = Len(Text1.Text)
                If Not ConnessioneInternet() Then
                    Text1.Text = Text1.Text & "Error with Internet Connection : " & CStr(Err.LastDllError) & vbCrLf
                    Text1.Refresh()
                    Text1.SelectionStart = Len(Text1.Text)
                    Exit Sub
                Else
                    Text1.Text = Text1.Text & "Internet Connection Complete ..." & vbCrLf
                    Text1.Refresh()
                    Text1.SelectionStart = Len(Text1.Text)
                    'File Log'
                    Text1.Text = Text1.Text & "Starting Server Connection ..." & vbCrLf
                    Text1.Refresh()
                    Text1.SelectionStart = Len(Text1.Text)
                    If Not ConnessioneServer() Then
                        'File Log'
                        Text1.Text = Text1.Text & "Error with Server Connection : " & CStr(CStr(Err.LastDllError)) & vbCrLf
                        Text1.Refresh()
                        Text1.SelectionStart = Len(Text1.Text)
                        Exit Sub
                    Else
                        'File Log'
                        Text1.Text = Text1.Text & "Server Connection Complete ..." & vbCrLf
                        Text1.Refresh()
                        Text1.SelectionStart = Len(Text1.Text)
                    End If
                    PreparaForm()
                End If
            Case 1
                '***********************
                'Disconnet
                '***********************
                DisconnettiServer()
                DisconnettiInternet()
                Text1.Text = Text1.Text & "Server Disconnection Complete ..." & vbCrLf
                Text1.Text = Text1.Text & "*************************Fine*******************************" & vbCrLf
                Text1.Refresh()
                Text1.SelectionStart = Len(Text1.Text)
                ScriviFileLog()
                bActiveSession = False
                PreparaForm()
            Case 2
                '***********************
                'Setup INI
                '***********************
                Dim frm As New frmSet
                frmSetup.Show()
            Case 3
                '*******************************************
                'For automatic loading and saving
                '*******************************************
                Automatico()
                End
            Case 4
                '***********************
                'exit
                '***********************
                End
            Case 5
                '***********************
                'Opening Log Files
                '***********************
                Shell("notepad.exe " & NomeFileLog, AppWinStyle.NormalFocus)
            Case 6
                '***********************
                'UpLoad
                '***********************
                PreparaForm("UpLoad")

                updateLOG("UPLOAD_LOGGED_IN", "NILL")
                'check
                updateStatus("Checking for database booking...")

                rsWebDB = New ADODB.Recordset
                sql = "SELECT HeadOffice.*, (SELECT Branch_Name FROM Branch WHERE BranchID=" & CInt(BranchID) & ") AS sBranch FROM HeadOffice WHERE (HeadOffice.HeadOfficeID = " & CShort(HOfficeID) & ");"
                With rsWebDB
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenForwardOnly
                    .LockType = ADODB.LockTypeEnum.adLockBatchOptimistic
                    .let_Source(sql)
                    .ActiveConnection = sqlDBcn
                    .Open()
                    'UPGRADE_NOTE: Object rsWebDB.ActiveConnection may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                    .let_ActiveConnection(Nothing)
                End With
                If rsWebDB.RecordCount Then
                    If rsWebDB.Fields("HeadOffice_BookedOut").Value Then
                        If UCase(rsWebDB.Fields("HeadOffice_BookedOutUser").Value) <> UCase(frmMenu.lblUser.Text) Then
                            updateStatus("The database has been booked out by " & UCase(rsWebDB.Fields("HeadOffice_BookedOutUser").Value))
                            updateStatus(" at " & UCase(rsWebDB.Fields("HeadOffice_BookedOutBranch").Value) & " on " & rsWebDB.Fields("HeadOffice_BookedOutDate").Value)
                            updateStatus("Please ask relevant person to Book it in. If this is you then click Book In.")
                            Exit Sub
                        Else
                            If BranchType = "1" Then
                                If UCase(rsWebDB.Fields("HeadOffice_BookedOutBranch").Value) = UCase(UCase(rsWebDB.Fields("HeadOffice_Name").Value)) Then
                                Else
                                    updateStatus("The database has been booked out by " & UCase(rsWebDB.Fields("HeadOffice_BookedOutUser").Value))
                                    updateStatus(" at " & UCase(rsWebDB.Fields("HeadOffice_BookedOutBranch").Value) & " on " & rsWebDB.Fields("HeadOffice_BookedOutDate").Value)
                                    updateStatus("Please ask relevant person to Book it in. If this is you then click Book In.")
                                    Exit Sub
                                End If
                            Else
                                If UCase(rsWebDB.Fields("HeadOffice_BookedOutBranch").Value) = UCase(UCase(rsWebDB.Fields("sBranch").Value)) Then
                                Else
                                    updateStatus("The database has been booked out by " & UCase(rsWebDB.Fields("HeadOffice_BookedOutUser").Value))
                                    updateStatus(" at " & UCase(rsWebDB.Fields("HeadOffice_BookedOutBranch").Value) & " on " & rsWebDB.Fields("HeadOffice_BookedOutDate").Value)
                                    updateStatus("Please ask relevant person to Book it in. If this is you then click Book In.")
                                    Exit Sub
                                End If
                            End If
                        End If
                    Else
                        If BranchType = "1" Then
                            sql = "UPDATE HeadOffice SET HeadOffice_BookedOut=1, HeadOffice_BookedOutUser='" & frmMenu.lblUser.Text & "', HeadOffice_BookedOutBranch=HeadOffice_Name, HeadOffice_BookedOutDate='" & Now & "' WHERE HeadOfficeID=" & CInt(HOfficeID) & ";"
                        Else
                            sql = "UPDATE HeadOffice SET HeadOffice_BookedOut=1, HeadOffice_BookedOutUser='" & frmMenu.lblUser.Text & "', HeadOffice_BookedOutBranch=(SELECT Branch_Name FROM Branch WHERE BranchID=" & CInt(BranchID) & "), HeadOffice_BookedOutDate='" & Now & "' WHERE HeadOfficeID=" & CInt(HOfficeID) & ";"
                        End If
                        sqlDBcn.Execute(sql)
                        updateLOG("BOOKED_OUT", "NILL")
                        updateStatus("Database booked out to you...")
                    End If
                Else
                    updateStatus("No information found for Headoffice.")
                    Exit Sub
                End If

                UpLoad()
                sql = "UPDATE HeadOffice SET HeadOffice_BookedOut=0 WHERE HeadOfficeID=" & CInt(HOfficeID) & ";"
                sqlDBcn.Execute(sql)
                updateLOG("BOOKED_IN", "NILL")
                updateStatus("Database booked in...")

                updateLOG("UPLOAD_LOGGED_OUT", "NILL")
                PreparaForm("UpLoadFine")
            Case 7
                '***********************
                'DownLoad
                '***********************
                PreparaForm("DownLoad")

                updateLOG("DOWNLOAD_LOGGED_IN", "NILL")
                'check
                updateStatus("Checking for database booking...")

                rsWebDB = New ADODB.Recordset
                sql = "SELECT HeadOffice.*, (SELECT Branch_Name FROM Branch WHERE BranchID=" & CInt(BranchID) & ") AS sBranch FROM HeadOffice WHERE (HeadOffice.HeadOfficeID = " & CShort(HOfficeID) & ");"
                With rsWebDB
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenForwardOnly
                    .LockType = ADODB.LockTypeEnum.adLockBatchOptimistic
                    .let_Source(sql)
                    .ActiveConnection = sqlDBcn
                    .Open()
                    .let_ActiveConnection(Nothing)
                End With
                If rsWebDB.RecordCount Then
                    If rsWebDB.Fields("HeadOffice_BookedOut").Value Then
                        updateStatus("The database has been booked out by " & UCase(rsWebDB.Fields("HeadOffice_BookedOutUser").Value))
                        updateStatus(" at " & UCase(rsWebDB.Fields("HeadOffice_BookedOutBranch").Value) & " on " & rsWebDB.Fields("HeadOffice_BookedOutDate").Value)
                        updateStatus("Please ask relevant person to Book it in. If this is you then click Book In.")
                        Exit Sub
                    Else
                        If BranchType = "1" Then
                            sql = "UPDATE HeadOffice SET HeadOffice_BookedOut=1, HeadOffice_BookedOutUser='" & frmMenu.lblUser.Text & "', HeadOffice_BookedOutBranch=HeadOffice_Name, HeadOffice_BookedOutDate='" & Now & "' WHERE HeadOfficeID=" & CInt(HOfficeID) & ";"
                        Else
                            sql = "UPDATE HeadOffice SET HeadOffice_BookedOut=1, HeadOffice_BookedOutUser='" & frmMenu.lblUser.Text & "', HeadOffice_BookedOutBranch=(SELECT Branch_Name FROM Branch WHERE BranchID=" & CInt(BranchID) & "), HeadOffice_BookedOutDate='" & Now & "' WHERE HeadOfficeID=" & CInt(HOfficeID) & ";"
                        End If
                        sqlDBcn.Execute(sql)
                        updateLOG("BOOKED_OUT", "NILL")
                        updateStatus("Database booked out to you...")
                    End If
                Else
                    updateStatus("No information found for Headoffice.")
                    Exit Sub
                End If

                DownLoadFile()

                If BranchType = "0" Then
                    sql = "UPDATE HeadOffice SET HeadOffice_BookedOut=0 WHERE HeadOfficeID=" & CInt(HOfficeID) & ";"
                    sqlDBcn.Execute(sql)
                    updateLOG("BOOKED_IN", "NILL")
                    updateStatus("Database booked in...")

                    sql = "UPDATE Branch SET Branch_LastDLoadUser='" & frmMenu.lblUser.Text & "', Branch_LastDLoad='" & Now & "' WHERE BranchID=" & CInt(BranchID) & ";"
                    sqlDBcn.Execute(sql)
                Else
                End If
                '            If MsgBox("Do you want to book-out this database to you?", vbYesNo) = vbNo Then
                '                sql = "UPDATE HeadOffice SET HeadOffice_BookedOut=0;"
                '                sqlDBcn.Execute sql
                '                updateLOG "BOOKED_IN", "NILL"
                '                updateStatus "Database booked in..."
                '            End If

                updateLOG("DOWNLOAD_LOGGED_OUT", "NILL")

                DisconnettiServer()
                If ConnessioneServer() Then
                End If
                PreparaForm("DownLoadFine")

                'book out
            Case 8

                updateLOG("BOOKOUT_LOGGED_IN", "NILL")
                'check
                updateStatus("Checking for database booking...")

                rsWebDB = New ADODB.Recordset
                sql = "SELECT HeadOffice.*, (SELECT Branch_Name FROM Branch WHERE BranchID=" & CInt(BranchID) & ") AS sBranch FROM HeadOffice WHERE (HeadOffice.HeadOfficeID = " & CShort(HOfficeID) & ");"
                With rsWebDB
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenForwardOnly
                    .LockType = ADODB.LockTypeEnum.adLockBatchOptimistic
                    .let_Source(sql)
                    .ActiveConnection = sqlDBcn
                    .Open()
                    .let_ActiveConnection(Nothing)
                End With
                If rsWebDB.RecordCount Then
                    If rsWebDB.Fields("HeadOffice_BookedOut").Value Then
                        updateStatus("The database has been booked out by " & UCase(rsWebDB.Fields("HeadOffice_BookedOutUser").Value))
                        updateStatus(" at " & UCase(rsWebDB.Fields("HeadOffice_BookedOutBranch").Value) & " on " & rsWebDB.Fields("HeadOffice_BookedOutDate").Value)
                        updateStatus("Please ask relevant person to Book it in. If this is you then click Book In.")
                        Exit Sub
                    Else
                        If BranchType = "1" Then
                            sql = "UPDATE HeadOffice SET HeadOffice_BookedOut=1, HeadOffice_BookedOutUser='" & frmMenu.lblUser.Text & "', HeadOffice_BookedOutBranch=HeadOffice_Name, HeadOffice_BookedOutDate='" & Now & "' WHERE HeadOfficeID=" & CInt(HOfficeID) & ";"
                        Else
                            sql = "UPDATE HeadOffice SET HeadOffice_BookedOut=1, HeadOffice_BookedOutUser='" & frmMenu.lblUser.Text & "', HeadOffice_BookedOutBranch=(SELECT Branch_Name FROM Branch WHERE BranchID=" & CInt(BranchID) & "), HeadOffice_BookedOutDate='" & Now & "' WHERE HeadOfficeID=" & CInt(HOfficeID) & ";"
                        End If
                        sqlDBcn.Execute(sql)
                        updateLOG("BOOKED_OUT", "NILL")
                        updateStatus("Database booked out to you...")
                    End If
                Else
                    updateStatus("No information found for Headoffice.")
                    Exit Sub
                End If

                updateLOG("BOOKOUT_LOGGED_OUT", "NILL")

                'book In
            Case 9

                updateLOG("BOOKIN_LOGGED_IN", "NILL")
                'check
                updateStatus("Checking for database booking...")

                rsWebDB = New ADODB.Recordset
                sql = "SELECT HeadOffice.*, (SELECT Branch_Name FROM Branch WHERE BranchID=" & CInt(BranchID) & ") AS sBranch FROM HeadOffice WHERE (HeadOffice.HeadOfficeID = " & CShort(HOfficeID) & ");"
                With rsWebDB
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenForwardOnly
                    .LockType = ADODB.LockTypeEnum.adLockBatchOptimistic
                    .let_Source(sql)
                    .ActiveConnection = sqlDBcn
                    .Open()
                    .let_ActiveConnection(Nothing)
                End With
                If rsWebDB.RecordCount Then
                    If rsWebDB.Fields("HeadOffice_BookedOut").Value Then
                        If UCase(rsWebDB.Fields("HeadOffice_BookedOutUser").Value) <> UCase(frmMenu.lblUser.Text) Then
                            updateStatus("The database has been booked out by " & UCase(rsWebDB.Fields("HeadOffice_BookedOutUser").Value))
                            updateStatus(" at " & UCase(rsWebDB.Fields("HeadOffice_BookedOutBranch").Value) & " on " & rsWebDB.Fields("HeadOffice_BookedOutDate").Value)
                            updateStatus("Please ask relevant person to Book it in. If this is you then click Book In.")
                        Else
                            If BranchType = "1" Then
                                If UCase(rsWebDB.Fields("HeadOffice_BookedOutBranch").Value) = UCase(UCase(rsWebDB.Fields("HeadOffice_Name").Value)) Then
                                    sql = "UPDATE HeadOffice SET HeadOffice_BookedOut=0 WHERE HeadOfficeID=" & CInt(HOfficeID) & ";"
                                    sqlDBcn.Execute(sql)
                                    updateLOG("BOOKED_IN", "NILL")
                                    updateStatus("Database booked in.")
                                Else
                                    updateStatus("The database has been booked out by " & UCase(rsWebDB.Fields("HeadOffice_BookedOutUser").Value))
                                    updateStatus(" at " & UCase(rsWebDB.Fields("HeadOffice_BookedOutBranch").Value) & " on " & rsWebDB.Fields("HeadOffice_BookedOutDate").Value)
                                    updateStatus("Please ask relevant person to Book it in. If this is you then click Book In.")
                                End If
                            Else
                                If UCase(rsWebDB.Fields("HeadOffice_BookedOutBranch").Value) = UCase(UCase(rsWebDB.Fields("sBranch").Value)) Then
                                    sql = "UPDATE HeadOffice SET HeadOffice_BookedOut=0 WHERE HeadOfficeID=" & CInt(HOfficeID) & ";"
                                    sqlDBcn.Execute(sql)
                                    updateLOG("BOOKED_IN", "NILL")
                                    updateStatus("Database booked in.")
                                Else
                                    updateStatus("The database has been booked out by " & UCase(rsWebDB.Fields("HeadOffice_BookedOutUser").Value))
                                    updateStatus(" at " & UCase(rsWebDB.Fields("HeadOffice_BookedOutBranch").Value) & " on " & rsWebDB.Fields("HeadOffice_BookedOutDate").Value)
                                    updateStatus("Please ask relevant person to Book it in. If this is you then click Book In.")
                                End If
                            End If
                        End If
                    Else
                        updateLOG("BOOKED_IN_ALREADY", "NILL")
                        updateStatus("Database already booked in.")
                    End If
                Else
                    updateStatus("No information found for Headoffice.")
                    Exit Sub
                End If

                updateLOG("BOOKIN_LOGGED_OUT", "NILL")


                'reports
            Case 10
                updateLOG("REPORTS_LOGGED_IN", "NILL")
                'check
                updateStatus("Checking reports data for selected day end...")

                bUploadReport = True



                lString = Replace(CStr(CDate(_DTPicker1_1.Value)), " ", "_")
                lString = Replace(lString, "/", "-")
                lString = Replace(lString, ":", "")

                lString = Year(CDate(_DTPicker1_1.Value)) & "-"
                lString = lString & IIf(Len(Month(CDate(_DTPicker1_1.Value))) = 1, "0" & Month(CDate(_DTPicker1_1.Value)), Month(CDate(_DTPicker1_1.Value))) & "-"
                lString = lString & IIf(Len(VB.Day(CDate(_DTPicker1_1.Value))) = 1, "0" & VB.Day(CDate(_DTPicker1_1.Value)), VB.Day(CDate(_DTPicker1_1.Value)))

                bGetFail = False
                If fso.FolderExists(gPathHO & "upload\" & lString) Then
                Else
                    fso.CreateFolder(gPathHO & "upload\" & lString)
                End If
                lDir = Dir(gPathHO & "upload\" & lString & "\*.*")
                Do Until lDir = ""
                    fso.DeleteFile(gPathHO & "upload\" & lString & "\" & lDir, True)
                    lDir = Dir()
                    System.Windows.Forms.Application.DoEvents()
                Loop

                If fso.FolderExists(gPathHO & "upload\" & lString & "\done") Then
                Else
                    fso.CreateFolder(gPathHO & "upload\" & lString & "\done")
                End If
                lDir = Dir(gPathHO & "upload\" & lString & "\done\*.*")
                Do Until lDir = ""
                    fso.DeleteFile(gPathHO & "upload\" & lString & "\done\" & lDir, True)
                    lDir = Dir()
                    System.Windows.Forms.Application.DoEvents()
                Loop

                loadDayEndReport(gDayEndEnd, gPathHO & "upload\" & lString & "\" & lString & ".html", bGetFail)

                bUploadReport = False
                If bGetFail Then
                    updateStatus("Reports data for selected day end not found...")
                    updateLOG("REPORTS_DATA_FAIL", "NILL")
                Else
                    updateStatus("Reports data found for selected day end...")
                    updateLOG("REPORTS_DATA_DONE", "NILL")

                    updateStatus("Starting Report Upload")
                    updateLOG("UPLOAD_RPT_START_POINT", "NILL")


                    lDir = Dir(gPathHO & "upload\" & lString & "\*.*")
                    Do Until lDir = ""
                        UpLoad_Report(gPathHO & "upload\" & lString & "\", lDir, IIf(VB.Right(lDir, 3) = "tml", False, True))
                        fso.MoveFile(gPathHO & "upload\" & lString & "\" & lDir, gPathHO & "upload\" & lString & "\done\" & lDir)
                        lDir = Dir()
                        System.Windows.Forms.Application.DoEvents()
                    Loop

                    updateStatus("Finishing RPT Upload")
                    updateLOG("UPLOAD_END_POINT", "NILL")
                End If

                updateLOG("REPORTS_LOGGED_OUT", "NILL")
        End Select
    End Sub

    Private Sub UpLoad_Report(ByRef sPath As String, ByRef sFName As String, ByRef bType As Boolean)
        Dim sql As String
        Dim bRet As Boolean
        Dim szDirRemote, szFileRemote, szFileLocal As String
        Dim szTempString As String
        Dim szFileConPath As String
        Dim errore As Short
        Dim Count As Short
        Dim dirsendLocal As String
        Dim lString As String
        Dim zipname As String

        Count = 0
        errore = 0

        If bActiveSession Then
            szTempString = server + dirsend ''dirserv
            szDirRemote = VB.Right(szTempString, Len(szTempString) - Len(server))

            '        lString = Replace(Now, " ", "_")
            '        lString = Replace(lString, "/", "-")
            '        lString = Replace(lString, ":", "")
            '        If fso.FolderExists(gPathHO & "upload\" & lString) Then Else fso.CreateFolder gPathHO & "upload\" & lString

            If bType Then
                dwType = FTP_TRANSFER_TYPE_BINARY
            Else
                dwType = FTP_TRANSFER_TYPE_ASCII
            End If
            'cmdBuild_Click lString

            dirsendLocal = sPath 'gPathHO & "upload\" & lString & "\" 'serverPath
            szFileLocal = sFName 'lString & "_data.zip"

            Count = Count + 1
            _Label1_1.Text = szFileLocal
            _Label1_1.Refresh()
            System.Windows.Forms.Application.DoEvents()
            szFileConPath = dirsendLocal & szFileLocal
            szFileRemote = szFileLocal
            If (szDirRemote = "") Then szDirRemote = "\"
            rcd(szDirRemote)
            bRet = FtpPutFile(hConnection, szFileConPath, szFileRemote, dwType, 0)
            If bRet = False Then
                'File Log'
                Text1.Text = Text1.Text & "Error while Uploading File : " & sFName & " " & CStr(Err.LastDllError) & vbCrLf
                Text1.Refresh()
                System.Windows.Forms.Application.DoEvents()
                Text1.SelectionStart = Len(Text1.Text)
                errore = errore + 1

                updateLOG("UPLOAD_RPT_ERROR_POINT_1 " & sFName, CStr(Err.LastDllError))
            End If

            'File Log'
            If errore = 0 Then
                Text1.Text = Text1.Text & "Uploading completed successfully ..." & vbCrLf
                Text1.Refresh()
                Text1.SelectionStart = Len(Text1.Text)
                lbl33.Text = "DONE"

                updateLOG("UPLOAD_RPT_COMPLETED", "NILL")
                sql = "UPDATE Branch SET Branch_LastLoginUser='" & frmMenu.lblUser.Text & "', Branch_LastUpdate='" & Now & "' WHERE BranchID=" & CInt(BranchID) & ";"
                sqlDBcn.Execute(sql)
            Else
                Text1.Text = Text1.Text & "Upload didn't Complete ..." & vbCrLf
                Text1.Refresh()

                updateLOG("UPLOAD_RPT_NOT_COMPLETED", "NILL")
            End If
            Text1.Text = Text1.Text & "Total file(s) : " & CStr(Count) & vbCrLf
            Text1.Refresh()
            Text1.SelectionStart = Len(Text1.Text)
            Text1.Text = Text1.Text & "Error in File(s) : " & CStr(errore) & vbCrLf
            Text1.Refresh()
            Text1.SelectionStart = Len(Text1.Text)
            _Label1_1.Text = ""
        End If

    End Sub
	
	Private Sub tmrAutoDE_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrAutoDE.Tick
		tmrAutoDE.Enabled = False
		cmdCheckWOrder.Enabled = False
		Command2.Enabled = False
		cmdClose.Enabled = False
		cmdToday.Enabled = False
		cmdUpReport.Enabled = False
		cmdBookOut.Enabled = False
		cmdBookIN.Enabled = False
		
		bBranchChange = False
		
		If BranchType = "1" Then
			MsgBox("Option not allowed.")
			Me.Close()
		End If
		
		cmdClear_Click()
		cmdPulsante_Click(cmdPulsante.Item(0), New System.EventArgs())
		cmdPulsante_Click(cmdPulsante.Item(10), New System.EventArgs())
		cmdPulsante_Click(cmdPulsante.Item(1), New System.EventArgs())
		
		System.Windows.Forms.Application.DoEvents()
		Me.Close()
	End Sub
End Class