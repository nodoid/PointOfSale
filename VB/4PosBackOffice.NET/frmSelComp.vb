Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmSelComp
	Inherits System.Windows.Forms.Form
	' Registry API functions
	Private Declare Function SQLConfigDataSource Lib "ODBCCP32.DLL" (ByVal hwndParent As Integer, ByVal fRequest As Integer, ByVal lpszDriver As String, ByVal lpszAttributes As String) As Integer
	
	Const ODBC_ADD_DSN As Short = 1 ' Add data source
	Const ODBC_REMOVE_DSN As Short = 3 ' Delete data source
	
	Private Structure STARTUPINFO
		Dim cb As Integer
		Dim lpReserved As String
		Dim lpDesktop As String
		Dim lpTitle As String
		Dim dwX As Integer
		Dim dwY As Integer
		Dim dwXSize As Integer
		Dim dwYSize As Integer
		Dim dwXCountChars As Integer
		Dim dwYCountChars As Integer
		Dim dwFillAttribute As Integer
		Dim dwFlags As Integer
		Dim wShowWindow As Short
		Dim cbReserved2 As Short
		Dim lpReserved2 As Integer
		Dim hStdInput As Integer
		Dim hStdOutput As Integer
		Dim hStdError As Integer
	End Structure
	
	Private Structure PROCESS_INFORMATION
		Dim hProcess As Integer
		Dim hThread As Integer
		Dim dwProcessID As Integer
		Dim dwThreadID As Integer
	End Structure
	
	Private Declare Function WaitForSingleObject Lib "kernel32" (ByVal hHandle As Integer, ByVal dwMilliseconds As Integer) As Integer
	
	'UPGRADE_WARNING: Structure PROCESS_INFORMATION may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	'UPGRADE_WARNING: Structure STARTUPINFO may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function CreateProcessA Lib "kernel32" (ByVal lpApplicationName As String, ByVal lpCommandLine As String, ByVal lpProcessAttributes As Integer, ByVal lpThreadAttributes As Integer, ByVal bInheritHandles As Integer, ByVal dwCreationFlags As Integer, ByVal lpEnvironment As Integer, ByVal lpCurrentDirectory As String, ByRef lpStartupInfo As STARTUPINFO, ByRef lpProcessInformation As PROCESS_INFORMATION) As Integer
	
	Private Declare Function CloseHandle Lib "kernel32" (ByVal hObject As Integer) As Integer
	
	Private Declare Function GetExitCodeProcess Lib "kernel32" (ByVal hProcess As Integer, ByRef lpExitCode As Integer) As Integer
	
	Private Const NORMAL_PRIORITY_CLASS As Integer = &H20
	Private Const INFINITE As Short = -1
	
	
	Dim cnnDBmaster As ADODB.Connection
	Dim cnnDBWaitron As ADODB.Connection
	Dim gMasterPath As String
	
	Dim gSecurityCode As String
	Dim gSecKey As String
    Dim Label1 As New List(Of Label)
	Dim loadDBStr As String
	
	Private Sub loadLanguage()
		
		'frmSelComp = No Code    [4POS Company Loader...]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmSelComp.Caption = rsLang("LanguageLayoutLnk_Description"): frmSelComp.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmSelComp.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
    Private Function ExecCmd(ByRef cmdline As String) As Integer
        Dim ret As Integer
        Dim proc As PROCESS_INFORMATION
        Dim start As STARTUPINFO

        ' Initialize the STARTUPINFO structure:
        start.cb = Len(start)

        ' Start the shelled application:
        ret = CreateProcessA(vbNullString, cmdline, 0, 0, 1, NORMAL_PRIORITY_CLASS, 0, vbNullString, start, proc)

        ' Wait for the shelled application to finish:
        ret = WaitForSingleObject(proc.hProcess, INFINITE)
        Call GetExitCodeProcess(proc.hProcess, ret)
        Call CloseHandle(proc.hThread)
        Call CloseHandle(proc.hProcess)
        ExecCmd = ret
    End Function
	Private Function AddDSN(ByVal strDSN As String, ByVal strDescription As String, ByRef strDB As String, Optional ByRef delete As Boolean = False) As Boolean
		
		'------------------------------------
		'Usage:
		' AddDSN "MyDSN", "This is a test", "C:\test\myDB.mdb"
		'------------------------------------
		
		On Error GoTo Hell
		
		'Set the Driver Name
		Dim strDriver As String
		Dim strFolder As String
		strFolder = strDB
		Do Until VB.Right(strFolder, 1) = "\"
			strFolder = VB.Left(strFolder, Len(strFolder) - 1)
		Loop 
		strDriver = "Microsoft Access Driver (*.mdb)"
		
		'Build the attributes - Attributes must be Null separated
		Dim strAttributes As String
		strAttributes = strAttributes & "DESCRIPTION=" & strDescription & Chr(0)
		strAttributes = strAttributes & "DSN=" & strDSN & Chr(0)
		'strAttributes = strAttributes & "DATABASE=" & strDB & Chr(0)
		strAttributes = strAttributes & "DBQ=" & strDB & Chr(0)
		strAttributes = strAttributes & "systemDB=" & strFolder & "Secured.mdw" & Chr(0)
		strAttributes = strAttributes & "UID=liquid" & Chr(0)
		strAttributes = strAttributes & "PWD=lqd" & Chr(0)
		
		'Create DSN
		AddDSN = SQLConfigDataSource(0, ODBC_REMOVE_DSN, strDriver, strAttributes)
		If delete Then 
		Else 
			AddDSN = SQLConfigDataSource(0, ODBC_ADD_DSN, strDriver, strAttributes)
		End If
		'AddDSN = True
		Exit Function
		
Hell: 
		AddDSN = False
		MsgBox(Err.Description)
	End Function
	Public Function getRSMaster(ByRef sql As Object) As ADODB.Recordset
		getRSMaster = New ADODB.Recordset
		getRSMaster.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		getRSMaster.Open(sql, cnnDBmaster, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
	End Function
	
    Private Function getMasterDB() As Boolean
        On Error GoTo openConnection_Error
        'UPGRADE_WARNING: Couldn't resolve default property of object getMasterDB. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        getMasterDB = True
        cnnDBmaster = New ADODB.Connection
        cnnDBmaster.Open("4posMaster")
        'gMasterPath = Split(Split(cnnDBmaster.ConnectionString, ";DBQ=")(1), ";")(0)
        'gMasterPath = Split(LCase(gMasterPath), "4posmaster.mdb")(0) '

        'win 7
        Dim fso As New Scripting.FileSystemObject
        Dim textstream As Scripting.TextStream
        Dim lString As String
        If Win7Ver() = True Then
            'If fso.FileExists("C:\4POS\4POSWinPath.txt") Then
            '    Set textstream = fso.OpenTextFile("C:\4POS\4POSWinPath.txt", ForReading, True)
            '    lString = textstream.ReadAll
            '    serverPath = lString '& "pricing.mdb"
            'Else
            '    serverPath = "C:\4POSServer\" '"pricing.mdb"
            'End If
            gMasterPath = "c:\4posmaster\"
            getMasterDB = True
            Exit Function
        End If
        'win 7

        gMasterPath = Split(Split(cnnDBmaster.ConnectionString, ";DBQ=")(1), ";")(0)
        gMasterPath = Split(LCase(gMasterPath), "4posmaster.mdb")(0) '

        Exit Function
openConnection_Error:
        getMasterDB = False
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
	Private Sub cmdBuild_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBuild.Click
        Dim x As Integer
        Dim TMPgMasterPath As String
		Dim rs As ADODB.Recordset
		Dim fso As New Scripting.FileSystemObject
		Dim lDir As String
		If MsgBox("A data instruction will prepare a download for each store of the latest stock and pricing data." & vbCrLf & vbCrLf & "Are you sure you wish to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Prepare Download") = MsgBoxResult.Yes Then
			
			TMPgMasterPath = gMasterPath
			gMasterPath = "c:\4POSServer\"
			
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
			rs = getRSMaster("SELECT 1 as MasterID, #" & Today & "# as Master_DateReplica")
			rs.save(gMasterPath & "Data\Master.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM Catalogue")
			rs.save(gMasterPath & "Data\catalogue.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM PriceSet")
			rs.save(gMasterPath & "Data\PriceSet.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM Channel ORDER BY ChannelID")
			rs.save(gMasterPath & "Data\channel.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM Deposit ORDER BY DepositID")
			rs.save(gMasterPath & "Data\Deposit.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM PackSize ORDER BY PackSizeID")
			rs.save(gMasterPath & "Data\PackSize.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM Person ORDER BY PersonID")
			rs.save(gMasterPath & "Data\Person.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM PersonChannelLnk")
			rs.save(gMasterPath & "Data\PersonChannelLnk.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM PriceChannelLnk")
			rs.save(gMasterPath & "Data\PriceChannelLnk.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM PricingGroup ORDER BY PricingGroupID")
			rs.save(gMasterPath & "Data\PricingGroup.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM PricingGroupChannelLnk")
			rs.save(gMasterPath & "Data\PricingGroupChannelLnk.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM PropChannelLnk")
			rs.save(gMasterPath & "Data\PropChannelLnk.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM [Set] ORDER BY SetID")
			rs.save(gMasterPath & "Data\Set.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM SetItem")
			rs.save(gMasterPath & "Data\SetItem.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM Shrink ORDER BY ShrinkID")
			rs.save(gMasterPath & "Data\Shrink.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM ShrinkItem")
			rs.save(gMasterPath & "Data\ShrinkItem.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM StockGroup ORDER BY StockGroupID")
			rs.save(gMasterPath & "Data\StockGroup.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM StockItem ORDER BY StockItemID")
			rs.save(gMasterPath & "Data\stockitem.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM Supplier ORDER BY SupplierID")
			rs.save(gMasterPath & "Data\Supplier.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM SupplierDepositLnk")
			rs.save(gMasterPath & "Data\SupplierDepositLnk.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM Promotion")
			rs.save(gMasterPath & "Data\Promotion.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM PromotionItem")
			rs.save(gMasterPath & "Data\PromotionItem.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM StockBreak")
			rs.save(gMasterPath & "Data\StockBreak.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM RecipeStockItemLnk")
			rs.save(gMasterPath & "Data\RecipeStockItemLnk.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM CashTransaction")
			rs.save(gMasterPath & "Data\CashTransaction.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM Increment")
			rs.save(gMasterPath & "Data\Increment.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM IncrementStockItemLnk")
			rs.save(gMasterPath & "Data\IncrementStockItemLnk.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM IncrementQuantity")
			rs.save(gMasterPath & "Data\IncrementQuantity.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM Message")
			rs.save(gMasterPath & "Data\Message.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM MessageItem")
			rs.save(gMasterPath & "Data\MessageItem.rs", ADODB.PersistFormatEnum.adPersistADTG)
			rs = getRS("SELECT * FROM StockItemMessageLnk")
			rs.save(gMasterPath & "Data\StockItemMessageLnk.rs", ADODB.PersistFormatEnum.adPersistADTG)
			openConnectionWaitron()
			rs = getRSwaitron("SELECT * FROM POSMenu")
			rs.save(gMasterPath & "Data\POSMenu.rs", ADODB.PersistFormatEnum.adPersistADTG)
			
			ExecCmd(gMasterPath & "wzzip.exe " & gMasterPath & "Data\data.zip " & gMasterPath & "Data\*.*")
			
			If fso.FileExists(gMasterPath & "Data.zip") Then fso.DeleteFile(gMasterPath & "Data.zip", True)
			
			fso.CopyFile(gMasterPath & "Data\data.zip", gMasterPath & "Data.zip", True)
			
			rs = getRSMaster("SELECT locationCompany_1.locationCompanyID, locationCompany.locationCompany_Email FROM locationCompany INNER JOIN (locationCompany AS locationCompany_1 INNER JOIN location ON locationCompany_1.locationCompany_LocationID = location.locationID) ON locationCompany.locationCompany_LocationID = location.locationID WHERE (((locationCompany_1.locationCompanyID)=" & lblCompany.Tag & "));")
			
			On Error Resume Next
            'MAPISession1.SignOn()
            'MAPIMessages1.SessionID = MAPISession1.SessionID
            'MAPIMessages1.Compose()
			x = -1
			On Error Resume Next
			Do Until rs.EOF
				
				If rs.Fields("locationCompany_Email").Value <> "" Then
					x = x + 1
                    'MAPIMessages1.RecipIndex = x
                    'MAPIMessages1.RecipDisplayName = rs.Fields("locationCompany_Email").Value
                    'MAPIMessages1.ResolveName()
				End If
				
				rs.moveNext()
			Loop 
			rs = getRSMaster("SELECT locationAudit.locationAuditID, locationAudit.locationAudit_Email FROM locationCompany INNER JOIN locationAudit ON locationCompany.locationCompany_LocationID = locationAudit.locationAudit_LocationID WHERE (((locationCompany.locationCompanyID)=" & lblCompany.Tag & "));")
			Do Until rs.EOF
				x = x + 1
                'MAPIMessages1.RecipIndex = x
                'MAPIMessages1.RecipDisplayName = rs.Fields("locationAudit_Email").Value
                'MAPIMessages1.ResolveName()
				rs.moveNext()
			Loop 
            'MAPIMessages1.MsgSubject = "4POS Data"
            'MAPIMessages1.MsgNoteText = "4POS Pricing update as at " & Format(Now, "ddd, dd-mmm-yyyy hh:nn")
            'MAPIMessages1.AttachmentType = MSMAPI.AttachTypeConstants.mapData
            'MAPIMessages1.AttachmentName = "data.zip"
            'MAPIMessages1.AttachmentPathName = gMasterPath & "data.zip"
            'MAPIMessages1.Send()
            'MAPISession1.SignOff()
			
			gMasterPath = TMPgMasterPath
		End If
		Me.Cursor = System.Windows.Forms.Cursors.Default
	End Sub
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdCompany_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCompany.Click
		cnnDBmaster.Execute("UPDATE locationCompany SET locationCompany.locationCompany_Name = '" & Replace(txtCompany.Text, "'", "''") & "' WHERE (((locationCompany.locationCompanyID)=" & lblCompany.Tag & "));")
		loadCompanies()
		lvLocation.FocusedItem = lvLocation.Items.Item("k" & lblCompany.Tag)
		lblCompany.Text = lvLocation.FocusedItem.Text & " - " & lvLocation.FocusedItem.SubItems(1).Text
		
	End Sub
	
	Private Sub cmdDatabase_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDatabase.Click
		Me.CDmasterOpen.Title = "Select the path to " & lvLocation.FocusedItem.SubItems(1).Text & " application database ..."
		CDmasterOpen.Filter = "Application Data Base|pricing.mdb"
		CDmasterOpen.FileName = ""
		Me.CDmasterOpen.ShowDialog()
		If CDmasterOpen.FileName = "" Then
		Else
			lblCompany.Tag = Mid(lvLocation.FocusedItem.Name, 2)
			cnnDBmaster.Execute("UPDATE locationCompany SET locationCompany.locationCompany_Path = '" & Replace(CDmasterOpen.FileName, "'", "''") & "' WHERE (((locationCompany.locationCompanyID)=" & Mid(lvLocation.FocusedItem.Name, 2) & "));")
			loadCompanies()
			lvLocation.FocusedItem = lvLocation.Items.Item("k" & lblCompany.Tag)
			lvLocation_DoubleClick(lvLocation, New System.EventArgs())
			cmdCompany_Click(cmdCompany, New System.EventArgs())
		End If
		
	End Sub
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		Dim rs As ADODB.Recordset
		Dim fso As New Scripting.FileSystemObject
		Dim createDayend As Boolean
		On Error Resume Next
		rs = getRS("SELECT * FROM Person WHERE (Person_UserID = '" & Replace(Me.txtUserName.Text, "'", "''") & "') AND (Person_Password = '" & Replace(Me.txtPassword.Text, "'", "''") & "')")
		If rs.BOF Or rs.EOF Then
			MsgBox("Invalid User Name or Password, try again!", MsgBoxStyle.Exclamation, "Login")
			txtPassword.Focus()
		Else
			If CInt(rs.Fields("Person_SecurityBit").Value & "0") Then
				Me.Close()
				frmMenu.lblUser.Text = rs.Fields("Person_FirstName").Value & " " & rs.Fields("Person_LastName").Value
				frmMenu.lblUser.Tag = rs.Fields("PersonID").Value
				frmMenu.gBit = rs.Fields("Person_SecurityBit").Value
				frmMenu.loadMenu("stock")
				If fso.FileExists(serverPath & "report" & frmMenu.lblUser.Tag & ".mdb") Then
				Else
					fso.CopyFile(serverPath & "templateReport.mdb", serverPath & "report" & frmMenu.lblUser.Tag & ".mdb")
					createDayend = True
				End If
				If openConnectionReport() Then
				Else
					MsgBox("Unable to locate the Report Database!" & vbCrLf & vbCrLf & "The Update Controller wil terminate.", MsgBoxStyle.Critical, "SERVER ERROR")
					End
				End If
				If createDayend Then
					cnnDBreport.Execute("DELETE * FROM Report")
					cnnDBreport.Execute("INSERT INTO Report ( ReportID, Report_DayEndStartID, Report_DayEndEndID, Report_Heading ) SELECT 1 AS reportKey, Max(aDayEnd.DayEndID) AS MaxOfDayEndID, Max(aDayEnd.DayEndID) AS MaxOfDayEndID1, 'From ' & Format(Max([aDayEnd].[DayEnd_Date]),'ddd dd mmm yyyy') & ' to ' & Format(Max([aDayEnd].[DayEnd_Date]),'ddd dd mmm yyyy') & ' covering a dayend range of 1 days' AS theHeading FROM aDayEnd;")
					frmUpdateDayEnd.ShowDialog()
				End If
				
				rs = getRSreport("SELECT DayEnd.DayEnd_Date AS fromDate, DayEnd_1.DayEnd_Date AS toDate FROM (Report INNER JOIN DayEnd ON Report.Report_DayEndStartID = DayEnd.DayEndID) INNER JOIN DayEnd AS DayEnd_1 ON Report.Report_DayEndEndID = DayEnd_1.DayEndID;")
				If rs.RecordCount Then
                    frmMenu._DTPicker1_0.Format = DateTimePickerFormat.Custom
                    frmMenu._DTPicker1_0.CustomFormat = String.Format("{0} {1} {2}", Format(rs.Fields("fromDate").Value, "yyyy"), _
                    Format(rs.Fields("fromDate").Value, "m"), _
                    Format(rs.Fields("fromDate").Value, "d"))
                    frmMenu._DTPicker1_1.Format = DateTimePickerFormat.Custom
                    frmMenu._DTPicker1_1.CustomFormat = String.Format("{0} {1} {2}", Format(rs.Fields("toDate").Value, "yyyy"), _
                    Format(rs.Fields("toDate").Value, "m"), _
                    Format(rs.Fields("toDate").Value, "d"))
				End If
				frmMenu.setDayEndRange()
				frmMenu.lblDayEndCurrent.Text = frmMenu.lblDayEnd.Text
			Else
				MsgBox("You do not have the correct permissions to access the 4POS Office Application, try again!", MsgBoxStyle.Exclamation, "Login")
				Me.txtUserName.Focus()
				System.Windows.Forms.SendKeys.Send("{Home}+{End}")
			End If
		End If
		
		
		
	End Sub
	
	Private Sub BuildRegistrationKey()
		Dim x As Short
		Dim lCode, leCode As String
		gSecurityCode = UCase(txtCompany.Text) & "XDFHWPGMIJ"
		gSecurityCode = Replace(gSecurityCode, " ", "")
		gSecurityCode = Replace(gSecurityCode, "'", "")
		gSecurityCode = Replace(gSecurityCode, """", "")
		gSecurityCode = Replace(gSecurityCode, ",", "")
		For x = 1 To 10
			gSecurityCode = VB.Left(gSecurityCode, x) & Replace(Mid(gSecurityCode, x + 1), Mid(gSecurityCode, x, 1), "")
		Next x
		gSecurityCode = VB.Left(gSecurityCode, 10)
		lCode = getSerialNumber
		leCode = ""
		On Error Resume Next
		For x = 1 To Len(lCode)
			leCode = leCode & Mid(gSecurityCode, CDbl(Mid(lCode, x, 1)) + 1, 1)
		Next x
		On Error GoTo 0
		lblCode.Text = leCode
		
	End Sub
	
	Private Sub Command1_Click()
		If checkSecurity() Then
			Me.frmRegister.Visible = False
		Else
			Me.frmRegister.Visible = True
			BuildRegistrationKey()
		End If
	End Sub
	
	Private Sub cmdRegistration_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRegistration.Click
        Dim lCode As String
        Dim lPassword As String
        Dim x As Integer
		Dim rs As ADODB.Recordset
		Dim lNewString As String
		Dim fso As New Scripting.FileSystemObject
		Const securtyStringReply As String = "9487203516"
		
		If MsgBox("By Clicking 'Yes' you confirm that your company name is correct and you understand the licensing agreement." & vbCrLf & vbCrLf & "Do you wish to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "REGISTRATION") = MsgBoxResult.Yes Then
			If Len(gSecKey) = 12 Then
				lNewString = ""
                For x = 0 To Len(txtKey.Text)
                    If IsNumeric(Mid(txtKey.Text, x, 1)) Then
                        lNewString = lNewString & InStr(securtyStringReply, Mid(txtKey.Text, x, 1)) - 1
                    End If
                Next x
				cmdCompany_Click(cmdCompany, New System.EventArgs())
				Exit Sub
			Else
				lNewString = ""
                For x = 0 To Len(txtKey.Text)
                    If IsNumeric(Mid(txtKey.Text, x, 1)) Then
                        lNewString = lNewString & InStr(securtyStringReply, Mid(txtKey.Text, x, 1)) - 1
                    End If
                Next x
				If lNewString <> "" Then
					If System.Math.Abs(CDbl(lNewString)) = System.Math.Abs(CDbl(getSerialNumber())) Then
						lPassword = "pospospospos"
						lCode = getSerialNumber
						If lCode <> "" Then
							lCode = Encrypt(lCode, lPassword)
							cmdCompany_Click(cmdCompany, New System.EventArgs())
							cnnDB.Execute("UPDATE Company SET Company.Company_Code = '" & Replace(lCode, "'", "''") & "';")
							frmRegister.Visible = False
						End If
						
						Exit Sub
					End If
				End If
			End If
		End If
		MsgBox("The 'Activation key' is invalid!", MsgBoxStyle.Exclamation, "4POS REGISTRATION")
	End Sub
	Private Sub frmSelComp_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Label1.AddRange(New Label() {_Label1_0, _Label1_1, _Label1_2, _Label1_2, _Label1_3, _Label1_4})

        'Dim iret As Long
		'Dim lHandle As Long
		'Dim rs As Recordset
		'Dim fso As New FileSystemObject
		'Dim lFile As String
		
		'If getMasterDB() Then
		'    loadCompanies
		'Else
		'    MsgBox "System could not find Master Database." & vbCrLf & vbCrLf & "Please restart this application", vbInformation, "Company Select"
		'    Unload Me
		'End If
		
	End Sub
	
	'Private Sub Label3_Click()
	'    Dim rs As Recordset
	'        Set rs = getRS("SELECT * FROM aTransactionItem")
	'        If rs.RecordCount = 0 Then
	'        rs.save gMasterPath & "Data\aTransactionItem.rs", adPersistADTG
	'        End If
	'End Sub
	Public Function loadDB() As String
		Dim iret As Integer
		Dim lHandle As Integer
		Dim rs As ADODB.Recordset
		Dim fso As New Scripting.FileSystemObject
		Dim lFile As String
		
		loadDBStr = ""
		If getMasterDB() Then
			loadCompanies()
			Me.ShowDialog()
			loadDB = loadDBStr
			'If Me.lvLocation.SelectedItem.SubItems(2) = "" Then
			'Else
			'    loadDB = Me.lvLocation.SelectedItem.SubItems(2)
			'    Unload Me
			'End If
		Else
			MsgBox("System could not find Master Database." & vbCrLf & vbCrLf & "Please restart this application", MsgBoxStyle.Information, "Company Select")
			loadDB = ""
			Me.Close()
		End If
	End Function
	
	Private Sub lvLocation_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvLocation.DoubleClick
        Dim lArray As String()
		Dim x As Short
		Dim rs As ADODB.Recordset
		Dim lListitem As System.Windows.Forms.ListViewItem
		Dim lPath As String
		Dim cn As ADODB.Connection
		
		cn = openSComp(Me.lvLocation.FocusedItem.SubItems(2).Text)
		If cn Is Nothing Then
		Else
			loadDBStr = Me.lvLocation.FocusedItem.SubItems(2).Text
			'Exit Sub
			Me.Close()
			Exit Sub
		End If
		
		lblCompany.Text = "..."
		lblCompany.Tag = ""
		lblPath.Text = "..."
		lblDir.Text = "..."
        For x = 0 To Label1.Count
            Label1(x).Enabled = False
        Next x
		Me.txtUserName.Enabled = False
		txtPassword.Enabled = False
		Me.cmdOK.Enabled = False
		cmdCompany.Enabled = False
		cmdBuild.Enabled = False
		cmdDatabase.Enabled = False
		
		Me.CDmasterOpen.Title = "Select the path to " & lvLocation.FocusedItem.SubItems(1).Text & " application database ..."
		CDmasterOpen.Filter = "Application Data Base|pricing.mdb"
		CDmasterOpen.FileName = ""
		Me.CDmasterOpen.ShowDialog()
		If CDmasterOpen.FileName = "" Then
		Else
			lblCompany.Tag = Mid(lvLocation.FocusedItem.Name, 2)
			cnnDBmaster.Execute("UPDATE locationCompany SET locationCompany.locationCompany_Path = '" & Replace(CDmasterOpen.FileName, "'", "''") & "' WHERE (((locationCompany.locationCompanyID)=" & Mid(lvLocation.FocusedItem.Name, 2) & "));")
			loadCompanies()
			lvLocation.FocusedItem = lvLocation.Items.Item("k" & lblCompany.Tag)
			'lvLocation_DblClick
		End If
	End Sub
	
	Private Sub loadCompanies()
		Dim rs As New ADODB.Recordset
		Dim lListitem As System.Windows.Forms.ListViewItem
		rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		If openConnection Then
		End If
		rs.Open("SELECT locationCompany.locationCompanyID, location.location_Name, locationCompany.locationCompany_Name, locationCompany.locationCompany_Path FROM location INNER JOIN locationCompany ON location.locationID = locationCompany.locationCompany_LocationID ORDER BY location.location_Name, locationCompany.locationCompany_Name;", cnnDBmaster, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
		Me.lvLocation.Items.Clear()
		If rs.RecordCount Then
			Do Until rs.EOF
				lListitem = lvLocation.Items.Add("k" & rs.Fields("locationCompanyID").Value, rs.Fields("locationCompany_Name").Value, 2)
				'UPGRADE_WARNING: Lower bound of collection lListitem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lListitem.SubItems.Count > 1 Then
					lListitem.SubItems(1).Text = rs.Fields("location_Name").Value & ""
				Else
					lListitem.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("location_Name").Value & ""))
				End If
				If lListitem.SubItems.Count > 2 Then
					lListitem.SubItems(2).Text = rs.Fields("locationCompany_Path").Value & ""
				Else
					lListitem.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("locationCompany_Path").Value & ""))
				End If
				If LCase(rs.Fields("locationCompany_Path").Value & "") = LCase(serverPath & "pricing.mdb") Then
					lListitem.Selected = True
					'lvLocation_DblClick
				End If
				rs.moveNext()
			Loop 
		End If
	End Sub
	
	Private Sub txtCompany_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCompany.Enter
		txtCompany.SelectionStart = 0
		txtCompany.SelectionLength = 9999
	End Sub
	Private Sub txtCompany_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCompany.Leave
		If Trim(txtCompany.Text) <> "" Then
			cnnDB.Execute("UPDATE Company SET Company_Name = '" & Replace(txtCompany.Text, "'", "''") & "'")
		End If
		BuildRegistrationKey()
	End Sub
	
	Private Sub txtKey_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtKey.Enter
		txtKey.SelectionStart = 0
		txtKey.SelectionLength = 9999
	End Sub
	Private Sub txtPassword_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPassword.Enter
		txtPassword.SelectionStart = 0
		txtPassword.SelectionLength = 9999
	End Sub
	Private Sub txtPassword_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Then
			KeyAscii = 0
			cmdOK_Click(cmdOK, New System.EventArgs())
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	Private Sub txtUserName_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtUserName.Enter
		txtUserName.SelectionStart = 0
		txtUserName.SelectionLength = 9999
	End Sub
	Private Sub txtUserName_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtUserName.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Then
			KeyAscii = 0
			txtPassword.Focus()
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	Private Function getSerialNumber() As String
		Dim fso As New Scripting.FileSystemObject
		Dim fsoFolder As Scripting.Folder
		Dim fsoDrive As Scripting.Drive
		getSerialNumber = ""
		If fso.FolderExists(serverPath) Then
			fsoFolder = fso.GetFolder(serverPath)
			getSerialNumber = CStr(fsoFolder.Drive.SerialNumber)
		End If
	End Function
	Private Function Encrypt(ByVal secret As String, ByVal PassWord As String) As String
		Dim l As Integer
		Dim x As Short
		Dim Char_Renamed As String
		l = Len(PassWord)
		For x = 1 To Len(secret)
			Char_Renamed = CStr(Asc(Mid(PassWord, (x Mod l) - l * CShort((x Mod l) = 0), 1)))
			Mid(secret, x, 1) = Chr(Asc(Mid(secret, x, 1)) Xor Char_Renamed)
		Next 
		Encrypt = secret
	End Function
	Public Function checkSecurity() As Boolean
		Dim lCode As String
		Dim leCode As String
		Dim lPassword As String
		Dim rs As ADODB.Recordset
		Dim x As Short
		checkSecurity = False
		rs = getRS("SELECT * From Company")
		If rs.RecordCount Then
			gSecKey = rs.Fields("Company_Code").Value & ""
			If IsNumeric(rs.Fields("Company_Code").Value) Then
				If Len(rs.Fields("Company_Code").Value) = 13 Then
					
					checkSecurity = True
					Exit Function
				End If
			End If
			lPassword = "pospospospos"
			lCode = getSerialNumber
			If lCode = "0" And LCase(VB.Left(serverPath, 3)) <> "c:\" And rs.Fields("Company_Code").Value <> "" Then
				checkSecurity = True
			Else
				leCode = Encrypt(lCode, lPassword)
				For x = 1 To Len(leCode)
					If Asc(Mid(leCode, x, 1)) < 33 Then
						leCode = VB.Left(leCode, x - 1) & Chr(33) & Mid(leCode, x + 1)
					End If
				Next x
				
				
				If rs.Fields("Company_Code").Value = leCode Then
					'If IsNull(rs("Company_TerminateDate")) Then
					checkSecurity = True
					'Else
					'    If Date > rs("Company_TerminateDate") Then
					'        cnnDB.Execute "UPDATE Company SET Company.Company_Code = '';"
					'        checkSecurity = False
					Exit Function
					'   End If
					'End If
				Else
					txtCompany.Text = rs.Fields("Company_Name").Value
					txtCompany.SelectionStart = 0
					txtCompany.SelectionLength = 999
				End If
				
			End If
		Else
			MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS")
			End
		End If
	End Function
End Class