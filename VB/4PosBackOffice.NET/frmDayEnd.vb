Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmDayEnd
	Inherits System.Windows.Forms.Form
	Private Const MAX_PATH As Short = 260
	Private Declare Function GetWindowsDirectory Lib "kernel32"  Alias "GetWindowsDirectoryA"(ByVal lpBuffer As String, ByVal nSize As Integer) As Integer
	Private Declare Function GetSystemDirectory Lib "kernel32"  Alias "GetSystemDirectoryA"(ByVal lpBuffer As String, ByVal nSize As Integer) As Integer
	
	Private Structure PROCESS_INFORMATION
		Dim hProcess As Integer
		Dim hThread As Integer
		Dim dwProcessID As Integer
		Dim dwThreadID As Integer
	End Structure
	
	Const mdPricingGroup As Short = 0
	Const mdDepartment As Short = 1
	Const mdPackSize As Short = 2
	
	Dim gMode As Short
	Dim lCNT As Short
	
	Const mdPOS As Short = 0
	Const mdTransactions As Short = 1
	Const mdConfirm As Short = 2
	Const mdComplete As Short = 3
	Const mdSecurity As Short = 4
    Dim frmMode As New List(Of GroupBox)
	Dim bolAutoDE_Error As Boolean
	
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1261 'Day End Run|
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'Label3 = No Code           [Please Wait, Stock Update Progress...]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label3.Caption = rsLang("LanguageLayoutLnk_Description"): Label3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdBack.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdBack.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'NOTE: DB Entry 1005 doesn't have ">>" chars
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1005 'Next|Checked
		If rsLang.RecordCount Then cmdNext.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdNext.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'frmMode(4) = No Code       [Demo Version Notification]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmMode(4).Caption = rsLang("LanguageLayoutLnk_Description"): frmMode(4).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblText = No Code          [The 4POS Application........]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblText.Caption = rsLang("LanguageLayoutLnk_Description"): lblText.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblDemo = No Code
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then COMPONENT(0).Caption = rsLang("LanguageLayoutLnk_Description"): COMPONENT(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'frmMode(0) = No Code       [No Cashup Declarations]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmMode(0).Caption = rsLang("LanguageLayoutLnk_Description"): frmMode(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1(0) = No Code         [The Following Point of Sales devices have not been declared]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label(0).Caption = rsLang("LanguageLayoutLnk_Description"): Label(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1(3) = No Code         [All active]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label(3).Caption = rsLang("LanguageLayoutLnk_Description"): Label(3).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'frmMode(2) = No Code       [Confirm Day End Run]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmMode(2).Caption = rsLang("LanguageLayoutLnk_Description"): frmMode(2).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1(1) = No Code        [Use the date selector to select the correct date for your day end.]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1(1).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1(2) = No Code        [As part of the "Day End" run, the integrity of your database will be checked and a backup made.]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1(2).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(2).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label2 = No Code           [Please ensure that there are no other users using the system before pressing the "Next" button!]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label2.Caption = rsLang("LanguageLayoutLnk_Description"): Label2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'frmMode(1) = No Code       [No POS Transactions]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmMode(1).Caption = rsLang("LanguageLayoutLnk_Description"): frmMode(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1(5) = No Code        [There have been no Point of Sale transaction since the last Day end procedure was run]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1(5).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(5).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1(4) = No Code        [There is no need to run your Day end Procedure.]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1(4).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(4).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'frmMode(3) = No Code       [Day End Run Complete]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmMode(3).Caption = rsLang("LanguageLayoutLnk_Description"): frmMode(3).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmDayEnd.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
    Private Sub doMode(ByRef mode As Short)
        Dim strFldName As String
        Dim st1 As String
        On Error GoTo ErrHandlerr

        Dim gParameters As Integer
        Dim bHOAutoUpload As Boolean

        Dim rsBit As ADODB.Recordset
        Dim rs As ADODB.Recordset
        gMode = mode

        Dim x As Integer
        Dim gMonth As Integer
        Dim dayStart, dayEnd As Integer
        Dim sql As String

        Dim errDesc As String

        Const gParPastelReport As Short = 128 'Pastel CSV's
        Const gCopySalesToHQ As Short = 1024 'Sales to HQ
        Const gZeroStock_DayEnd As Short = 4096


        For x = 0 To frmMode.Count - 1
            frmMode(x).Visible = False
        Next

        frmMode(gMode).Left = frmMode(0).Left
        frmMode(gMode).Top = frmMode(0).Top
        frmMode(gMode).Visible = True

        errDesc = "Starting Point"

        Dim cn As New ADODB.Connection
        Dim bDCChk As Boolean
        Dim rsDCChk As ADODB.Recordset
        Dim rsRep As ADODB.Recordset
        Dim rsHO As ADODB.Recordset
        Dim fso As New Scripting.FileSystemObject
        Dim lTextstream As Scripting.TextStream
        Dim lString As String
        'Dim Report As New cryOpenTable
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryOpenTable")
        Select Case gMode
            Case mdPOS
                errDesc = "mdPOS Point"

                'Check for open table...
                cn = openConnectionInstance("waitron.mdb")
                If cn Is Nothing Then
                    MsgBox("The Day End cannot be successfully executed as the Waitron Database is unable to connect to the 4POS BackOffice server." & vbCrLf & "Please ensure that the database is at correct location." & vbCrLf & vbCrLf & "If this error persists please contact the '4POS' representative.", MsgBoxStyle.Critical, "Server Off-line")
                    Exit Sub
                End If

                'Clear WaitronTable
                cn.Execute("DELETE * FROM WaitronTable;")

                'Dry Cleaning Customer Check
                bDCChk = False
                rsDCChk = getRS("SELECT * FROM Company;")
                If rsDCChk.RecordCount Then
                    If rsDCChk.Fields.Count >= 60 Then
                        If rsDCChk.Fields("Company_DCCustomer").Value Then
                            bDCChk = True
                        End If
                    End If
                End If
                'Dry Cleaning Customer Check

                rs = getRSwaitron("SELECT * FROM OpenTable", cn)
                If rs.RecordCount > 0 And bDCChk = False Then
                    st1 = "You cannot do Day End now, because there are still some Open Table" & vbCrLf & vbCrLf ' on this machine
                    st1 = st1 & "Make sure all Waitron's had cashout to all their table(s)" & vbCrLf & vbCrLf
                    st1 = st1 & "Click OK to see table(s) list"
                    MsgBox(st1, MsgBoxStyle.Exclamation, "Day End Warning")

                    'Dim sql As String

                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                    rsRep = getRS("SELECT * FROM Company")
                    'Report.txtCompanyName.SetText rsRep("Company_Name")
                    rsRep.Close()

                    sql = "SELECT OpenTable.OpenTable_TableID, OpenTable.OpenTable_WaitronID, OpenTable.OpenTable_Text, OpenTable.OpenTable_Date, OpenTable.OpenTable_GuestCount, TableTranactionItem.TableTranactionItem_lineNo, TableTranactionItem.TableTranactionItem_name, TableTranactionItem.TableTranactionItem_quantity, TableTranactionItem.TableTranactionItem_price, Person.Person_FirstName, Person.Person_LastName "
                    sql = sql & "FROM (OpenTable OpenTable INNER JOIN Person Person ON OpenTable.OpenTable_WaitronID = Person.PersonID) INNER JOIN TableTranactionItem TableTranactionItem ON OpenTable.OpenTable_TableID = TableTranactionItem.TableTranactionItem_TableID ORDER BY OpenTable.OpenTable_TableID ASC;"

                    rsRep = getRSwaitron(sql, cn)

                    'If rs.BOF Or rs.EOF Then
                    '    ReportNone.Load("cryNoRecords.rpt")
                    '    ReportNone.txtCompanyName.SetText Report.txtCompanyName.Text
                    '    ReportNone.txtTitle.SetText Report.txtTitle.Text
                    '    frmReportShow.caption = ReportNone.txtTitle.Text
                    '    frmReportShow.CRViewer1.ReportSource = ReportNone
                    '    Set frmReportShow.mReport = ReportNone: frmReportShow.sMode = "0"
                    '    frmReportShow.CRViewer1.ViewReport
                    '    Screen.MousePointer = vbDefault
                    '    frmReportShow.Show 1
                    '    Exit Sub
                    'End If

                    Report.Database.Tables(0).SetDataSource(rsRep)
                    'UPGRADE_WARNING: Couldn't resolve default property of object Report.VerifyOnEveryPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'Report.VerifyOnEveryPrint = True
                    'frmReportShow.caption = Report.txtTitle.Text
                    frmReportShow.CRViewer1.ReportSource = Report
                    frmReportShow.mReport = Report : frmReportShow.sMode = "0"
                    frmReportShow.CRViewer1.Refresh()
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                    frmReportShow.ShowDialog()

                    System.Windows.Forms.Application.DoEvents()

                    Me.cmdNext.Enabled = False
                    frmMode(0).Visible = False
                    Exit Sub

                Else
                    'if there is no record
                    If bDCChk = False Then
                        'delete OpenTable
                        cn.Execute("DELETE * FROM OpenTable;")
                        cn.Execute("DROP TABLE OpenTable;")
                        'create OpenTable
                        strFldName = "OpenTable_WaitronID Number NOT NULL, "
                        strFldName = strFldName & "OpenTable_TableID Number NOT NULL, "
                         strFldName = strFldName & "OpenTable_Text Text(50), "
                        strFldName = strFldName & "OpenTable_X Number, "
                        strFldName = strFldName & "OpenTable_Y Number, "
                        strFldName = strFldName & "OpenTable_Date DateTime, "
                       strFldName = strFldName & "OpenTable_Complete YesNo, "
                        strFldName = strFldName & "OpenTable_GuestCount Number, "
                        strFldName = strFldName & "OpenTable_Delivery YesNo, "
                        strFldName = strFldName & "OpenTable_TelNumber Text(50), "
                        strFldName = strFldName & "OpenTable_ID AUTOINCREMENT, "
                        strFldName = strFldName & "OpenTable_Discount Currency, "
                        strFldName = strFldName & "OpenTable_DiscountReason Text(50), "
                        strFldName = strFldName & "OpenTable_VoidReason Text(50), "
                        strFldName = strFldName & "OpenTable_FLTableID Number, "
                        strFldName = strFldName & "OpenTable_Printed YesNo"
                        Debug.Print(strFldName)
                        cn.Execute("CREATE TABLE OpenTable (" & strFldName & ")")
                        System.Windows.Forms.Application.DoEvents()
                    End If
                End If
                'Check for open table...

                rs = getRS("SELECT DISTINCT TOP 100 PERCENT POS.POSID, POS.POS_Name FROM POS INNER JOIN Sale ON POS.POSID = Sale.Sale_PosID AND POS.POS_DeclarationID = Sale.Sale_DeclarationID Where (POS.POS_Disabled = 0) ORDER BY POS.POS_Name")
                Me.lstPOS.Items.Clear()
                Do Until rs.EOF
                    lstPOS.Items.Add(New LBI(rs.Fields("POS_Name").Value, rs.Fields("POSID").Value))
                    rs.MoveNext()
                Loop
                If lstPOS.Items.Count Then
                    lstPOS.SelectedIndex = -1
                    lstPOS.Visible = True
                    Me.cmdNext.Enabled = False
                Else
                    doMode(mdTransactions)
                End If

            Case mdTransactions
                errDesc = "mdTransactions Point"
                rs = getRS("SELECT Count(Sale.SaleID) AS CountOfSaleID FROM Sale INNER JOIN Company ON Sale.Sale_DayEndID = Company.Company_DayEndID;")
                If rs.BOF Or rs.EOF Then
                    Me.cmdNext.Enabled = False
                Else
                    If rs.Fields(0).Value = 0 Then
                        Me.cmdNext.Enabled = False
                    Else
                        doMode(mdConfirm)
                    End If
                End If

            Case mdConfirm
                calDayEnd.SetDate(Now)
                If Hour(TimeOfDay) < 12 Then
                    calDayEnd.SetDate(System.DateTime.FromOADate(Today.ToOADate - 1))
                End If

                If bolAutoDE = True Then
                    If bolAutoDE_Error = False Then
                        doMode(mdComplete)
                    Else
                        Me.cmdNext.Enabled = True
                    End If
                Else
                    Me.cmdNext.Enabled = True
                End If
            Case mdComplete
                errDesc = "mdComplete Point"
                rsBit = getRS("SELECT * FROM Company")
                gParameters = CInt(0 & rsBit.Fields("Company_DayEndBit").Value)

                 bHOAutoUpload = IIf(IsDBNull(rsBit.Fields("Company_HOLink").Value), False, rsBit.Fields("Company_HOLink").Value)

                If bolAutoDE = True Then
                Else
                    If gParameters And gParPastelReport Then
                        frmMenu.Automaticload()
                        blpastel = True
                        report_VATPASTEL()
                        ExportToCSVFile()
                    End If
                End If

                rs = getRS("SELECT DayEnd_Date FROM DayEnd ORDER BY DayEnd_Date DESC;")
                If rs.RecordCount > 1 Then
                    rs.MoveNext()
                    If DateSerial(DateAndTime.Year(calDayEnd.SelectionStart), DateAndTime.Month(calDayEnd.SelectionStart), DateAndTime.Day(calDayEnd.SelectionStart)) <= rs.Fields(0).Value Then
                        MsgBox("You may not do a day end run for a previous day!" & vbCrLf & vbCrLf & "The last day end run was on the " & Format(rs.Fields(0).Value, "ddd, dd-mmm-yyyy") & "!", MsgBoxStyle.Exclamation, "DAYEND RUN")
                        bolAutoDE_Error = True
                        doMode(mdConfirm)
                        Exit Sub
                    End If
                End If

                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                modUpdate = 1

                updateStockMovement()

                errDesc = "After updateStockMovement Point"

                'Multi Warehouse change     cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN (Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2) AND (([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]+[DayEndStockItemLnk_QuantityShrink]-[DayEndStockItemLnk_QuantityGRV])<>[WarehouseStockItemLnk_Quantity]));"
                'Tranfer change             cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN (Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AND WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID = DayEndStockItemLnk.DayEndStockItemLnk_Warehouse SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2) AND (([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]+[DayEndStockItemLnk_QuantityShrink]-[DayEndStockItemLnk_QuantityGRV])<>[WarehouseStockItemLnk_Quantity]));"
                cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN (Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AND WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID = DayEndStockItemLnk.DayEndStockItemLnk_Warehouse SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV]+[DayEndStockItemLnk_QuantityTransafer] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2) AND (([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]+[DayEndStockItemLnk_QuantityShrink]-[DayEndStockItemLnk_QuantityGRV]-[DayEndStockItemLnk_QuantityTransafer])<>[WarehouseStockItemLnk_Quantity]));")

                sql = "INSERT INTO StockitemHistory ( StockitemHistory_StockItemID, StockitemHistory_Value, StockitemHistory_Day1, StockitemHistory_Day2, StockitemHistory_Day3, StockitemHistory_Day4, StockitemHistory_Day5, StockitemHistory_Day6, StockitemHistory_Day7, StockitemHistory_Day8, StockitemHistory_Day9, StockitemHistory_Day10, StockitemHistory_Day11, StockitemHistory_Day12, StockitemHistory_Week1, StockitemHistory_Week2, StockitemHistory_Week3, StockitemHistory_Week4, StockitemHistory_Week5, StockitemHistory_Week6, StockitemHistory_Week7, StockitemHistory_Week8, StockitemHistory_Week9, StockitemHistory_Week11, StockitemHistory_Month1, StockitemHistory_Month2, StockitemHistory_Month3, StockitemHistory_Month4, StockitemHistory_Month5, StockitemHistory_Month6, StockitemHistory_Month7, StockitemHistory_Month8, StockitemHistory_Month9, StockitemHistory_Month10, StockitemHistory_Month11, StockitemHistory_Month12 ) "
                sql = sql & "SELECT StockItem.StockItemID, 0 AS Expr2, 0 AS Expr3, 0 AS Expr4, 0 AS Expr5, 0 AS Expr6, 0 AS Expr7, 0 AS Expr8, 0 AS Expr9, 0 AS Expr10, 0 AS Expr11, 0 AS Expr12, 0 AS Expr13, 0 AS Expr14, 0 AS Expr15, 0 AS Expr16, 0 AS Expr17, 0 AS Expr18, 0 AS Expr19, 0 AS Expr20, 0 AS Expr21, 0 AS Expr22, 0 AS Expr23, 0 AS Expr24, 0 AS Expr25, 0 AS Expr26, 0 AS Expr27, 0 AS Expr28, 0 AS Expr29, 0 AS Expr30, 0 AS Expr31, 0 AS Expr32, 0 AS Expr33, 0 AS Expr34, 0 AS Expr35, 0 AS Expr1 FROM StockItem LEFT JOIN StockitemHistory ON StockItem.StockItemID = StockitemHistory.StockitemHistory_StockItemID WHERE (((StockitemHistory.StockitemHistory_StockItemID) Is Null));"
                cnnDB.Execute(sql)

                'add temporary table for StockitemHistory
                ChkStockitemHistoryTable()
                System.Windows.Forms.Application.DoEvents()
                sql = "INSERT INTO StockitemHistory777 ( StockItemID, QuantitySales ) "
                sql = sql & "SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales) AS Exp1 FROM Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID;"
                cnnDB.Execute(sql)
                'add temporary table for StockitemHistory
                Dim dated As Date
                dated = calDayEnd.SelectionRange.Start
                'cnnDB.Execute "UPDATE Company INNER JOIN (StockitemHistory INNER JOIN DayEndStockItemLnk ON StockitemHistory.StockitemHistory_StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID SET StockitemHistory.StockitemHistory_Day1 = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantitySales];"
                cnnDB.Execute("UPDATE StockitemHistory INNER JOIN StockitemHistory777 ON StockitemHistory.StockitemHistory_StockItemID = StockitemHistory777.StockItemID SET StockitemHistory.StockitemHistory_Day1 = [StockitemHistory777]![QuantitySales];")
                'cnnDB.Execute "UPDATE Company INNER JOIN (StockitemHistory INNER JOIN DayEndStockItemLnk ON StockitemHistory.StockitemHistory_StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID SET StockitemHistory.StockitemHistory_Week1 = [StockitemHistory]![StockitemHistory_Week1]+[DayEndStockItemLnk]![DayEndStockItemLnk_QuantitySales];"
                cnnDB.Execute("UPDATE StockitemHistory INNER JOIN StockitemHistory777 ON StockitemHistory.StockitemHistory_StockItemID = StockitemHistory777.StockItemID SET StockitemHistory.StockitemHistory_Week1 = [StockitemHistory]![StockitemHistory_Week1]+[StockitemHistory777]![QuantitySales];")
                'cnnDB.Execute "UPDATE Company INNER JOIN (StockitemHistory INNER JOIN DayEndStockItemLnk ON StockitemHistory.StockitemHistory_StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID SET StockitemHistory.StockitemHistory_Month1 = [StockitemHistory]![StockitemHistory_Month1]+[DayEndStockItemLnk]![DayEndStockItemLnk_QuantitySales];"
                cnnDB.Execute("UPDATE StockitemHistory INNER JOIN StockitemHistory777 ON StockitemHistory.StockitemHistory_StockItemID = StockitemHistory777.StockItemID SET StockitemHistory.StockitemHistory_Month1 = [StockitemHistory]![StockitemHistory_Month1]+[StockitemHistory777]![QuantitySales];")
                sql = "UPDATE StockitemHistory SET StockitemHistory.StockitemHistory_Day12 = [StockitemHistory]![StockitemHistory_Day11], StockitemHistory.StockitemHistory_Day11 = [StockitemHistory]![StockitemHistory_Day10], StockitemHistory.StockitemHistory_Day10 = [StockitemHistory]![StockitemHistory_Day9], StockitemHistory.StockitemHistory_Day9 = [StockitemHistory]![StockitemHistory_Day8], StockitemHistory.StockitemHistory_Day8 = [StockitemHistory]![StockitemHistory_Day7], StockitemHistory.StockitemHistory_Day7 = [StockitemHistory]![StockitemHistory_Day6], StockitemHistory.StockitemHistory_Day6 = [StockitemHistory]![StockitemHistory_Day5], StockitemHistory.StockitemHistory_Day5 = [StockitemHistory]![StockitemHistory_Day4], "
                sql = sql & "StockitemHistory.StockitemHistory_Day4 = [StockitemHistory]![StockitemHistory_Day3], StockitemHistory.StockitemHistory_Day3 = [StockitemHistory]![StockitemHistory_Day2], StockitemHistory.StockitemHistory_Day2 = [StockitemHistory]![StockitemHistory_Day1], StockitemHistory.StockitemHistory_Day1 = 0;"
                cnnDB.Execute(sql)

                cnnDB.Execute("UPDATE (Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN StockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = StockItem.StockItemID SET DayEndStockItemLnk.DayEndStockItemLnk_ListCost = [StockItem]![StockItem_ListCost]/[StockItem]![StockItem_Quantity], DayEndStockItemLnk.DayEndStockItemLnk_ActualCost = [StockItem]![StockItem_ActualCost]/[StockItem]![StockItem_Quantity];")
                cnnDB.Execute("INSERT INTO DayEnd ( DayEndID, DayEnd_MonthEndID, DayEnd_Date ) SELECT Company.Company_DayEndID, Company.Company_MonthEndID, #" & dated.Month & "# FROM Company LEFT JOIN DayEnd ON Company.Company_DayEndID = DayEnd.DayEndID WHERE (((DayEnd.DayEndID) Is Null));")
                cnnDB.Execute("UPDATE Company INNER JOIN DayEnd ON Company.Company_DayEndID = DayEnd.DayEndID SET DayEnd.DayEnd_MonthEndID = [Company]![Company_MonthEndID], DayEnd.DayEnd_Date = #" & dated.Day & "#;")
                cnnDB.Execute("UPDATE Company SET Company.Company_DayEndID = [Company]![Company_DayEndID]+1;")
                If LCase(Format(Me.calDayEnd.SelectionRange.Start.Day + 1, "ddd")) = "sun" Then
                    'If LCase(Format(System.DateTime.FromOADate(dated.ToOADate + 1)), "ddd", 1, FirstWeekOfYear.FirstFullWeek) = "sun" Then
                    cnnDB.Execute("INSERT INTO DayEnd ( DayEndID, DayEnd_MonthEndID, DayEnd_Date ) SELECT Company.Company_DayEndID, Company.Company_MonthEndID, #" & System.DateTime.FromOADate(dated.ToOADate + 1) & "# FROM Company LEFT JOIN DayEnd ON Company.Company_DayEndID = DayEnd.DayEndID WHERE (((DayEnd.DayEndID) Is Null));")
                    sql = "UPDATE StockitemHistory SET StockitemHistory.StockitemHistory_Week12 = [StockitemHistory]![StockitemHistory_Week11], StockitemHistory.StockitemHistory_Week11 = [StockitemHistory]![StockitemHistory_Week10], StockitemHistory.StockitemHistory_Week10 = [StockitemHistory]![StockitemHistory_Week9], StockitemHistory.StockitemHistory_Week9 = [StockitemHistory]![StockitemHistory_Week8], StockitemHistory.StockitemHistory_Week8 = [StockitemHistory]![StockitemHistory_Week7], StockitemHistory.StockitemHistory_Week7 = [StockitemHistory]![StockitemHistory_Week6], StockitemHistory.StockitemHistory_Week6 = [StockitemHistory]![StockitemHistory_Week5], StockitemHistory.StockitemHistory_Week5 = [StockitemHistory]![StockitemHistory_Week4], "
                    sql = sql & "StockitemHistory.StockitemHistory_Week4 = [StockitemHistory]![StockitemHistory_Week3], StockitemHistory.StockitemHistory_Week3 = [StockitemHistory]![StockitemHistory_Week2], StockitemHistory.StockitemHistory_Week2 = [StockitemHistory]![StockitemHistory_Week1], StockitemHistory.StockitemHistory_Week1 = 0;"
                    cnnDB.Execute(sql)
                Else
                    cnnDB.Execute("INSERT INTO DayEnd ( DayEndID, DayEnd_MonthEndID, DayEnd_Date ) SELECT Company.Company_DayEndID, Company.Company_MonthEndID, #" & System.DateTime.FromOADate(dated.ToOADate + 1) & "# FROM Company LEFT JOIN DayEnd ON Company.Company_DayEndID = DayEnd.DayEndID WHERE (((DayEnd.DayEndID) Is Null));")
                End If
                'delete from dayendstocklink AND dayend depositlink   for that dayend
                rs = getRS("SELECT Company_DayEndID FROM Company;")
                If rs.RecordCount > 1 Then
                    cnnDB.Execute("DELETE * FROM DayEndStockItemLnk WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)=" & rs.Fields("Company_DayEndID").Value & "));")
                    cnnDB.Execute("DELETE * FROM DayEndDepositItemLnk WHERE (((DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID)=" & rs.Fields("Company_DayEndID").Value & "));")
                End If


                'On Local Error Resume Next
                'Multi Warehouse change    cnnDB.Execute "INSERT INTO DayEndStockItemLnk ( DayEndStockItemLnk_DayEndID, DayEndStockItemLnk_StockItemID, DayEndStockItemLnk_Quantity, DayEndStockItemLnk_QuantitySales, DayEndStockItemLnk_QuantityShrink, DayEndStockItemLnk_QuantityGRV, DayEndStockItemLnk_ListCost, DayEndStockItemLnk_ActualCost ) SELECT Company.Company_DayEndID, StockItem.StockItemID, 0 AS Expr1, 0 AS Expr2, 0 AS Expr3, 0 AS Expr4, [StockItem]![StockItem_ListCost]/[StockItem]![StockItem_Quantity], [StockItem]![StockItem_ActualCost]/[StockItem]![StockItem_Quantity] FROM Company, StockItem;"
                cnnDB.Execute("INSERT INTO DayEndStockItemLnk ( DayEndStockItemLnk_DayEndID, DayEndStockItemLnk_StockItemID, DayEndStockItemLnk_Quantity, DayEndStockItemLnk_QuantitySales, DayEndStockItemLnk_QuantityShrink, DayEndStockItemLnk_QuantityGRV, DayEndStockItemLnk_ListCost, DayEndStockItemLnk_ActualCost, DayEndStockItemLnk_Warehouse ) SELECT Company.Company_DayEndID, StockItem.StockItemID, 0 AS Expr1, 0 AS Expr2, 0 AS Expr3, 0 AS Expr4, [StockItem]![StockItem_ListCost]/[StockItem]![StockItem_Quantity], [StockItem]![StockItem_ActualCost]/[StockItem]![StockItem_Quantity], Warehouse.WarehouseID FROM Company, StockItem, Warehouse;")
                'On Local Error GoTo 0
                'Multi Warehouse change     cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN (DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID) ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID SET DayEndStockItemLnk.DayEndStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=1 Or (WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));"
                cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN (DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID) ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AND WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID = DayEndStockItemLnk.DayEndStockItemLnk_Warehouse SET DayEndStockItemLnk.DayEndStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=1 Or (WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));")
                sql = "INSERT INTO DayEndDepositItemLnk ( DayEndDepositItemLnk_DayEndID, DayEndDeposittemLnk_DepositID, DayEndDeposittemLnk_DepositType, DayEndDepositItemLnk_Quantity, DayEndDepositItemLnk_QuantitySales, DayEndDepositItemLnk_QuantityShrink, DayEndDepositItemLnk_QuantityGRV, DayEndDepositItemLnk_UnitCost, DayEndDepositItemLnk_CaseCost, DayEndDepositItemLnk_CaseQuantity ) SELECT DISPLAY_DepositDayEnd.Company_DayEndID, DISPLAY_DepositDayEnd.DepositID, DISPLAY_DepositDayEnd.type, 0, 0, 0, 0, Deposit.Deposit_UnitCost, Deposit.Deposit_CaseCost, Deposit.Deposit_Quantity FROM DayEndDepositItemLnk RIGHT JOIN (Deposit INNER JOIN DISPLAY_DepositDayEnd ON Deposit.DepositID = DISPLAY_DepositDayEnd.DepositID) ON (DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType = DISPLAY_DepositDayEnd.type) AND (DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = DISPLAY_DepositDayEnd.DepositID) AND (DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID = DISPLAY_DepositDayEnd.Company_DayEndID) "
                sql = sql & "WHERE (((DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) Is Null));"
                cnnDB.Execute(sql)

                errDesc = "Middle Point"

                rs = getRS("SELECT [Company_DayEndID]-1 AS theDayend FROM Company;")
                rs = getRS("SELECT Min(DayEnd.DayEndID) AS minDay, Max(DayEnd_1.DayEndID) AS MaxDay FROM (Company INNER JOIN DayEnd AS DayEnd_1 ON Company.Company_MonthEndID = DayEnd_1.DayEnd_MonthEndID) INNER JOIN DayEnd ON Company.Company_MonthEndID = DayEnd.DayEnd_MonthEndID;")
                dayStart = rs.Fields("minDay").Value
                dayEnd = rs.Fields("MaxDay").Value
                rs.Close()

                cnnDB.Execute("UPDATE DayEndStockItemLnk SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV = 0;")
                cnnDB.Execute("UPDATE (DayEndStockItemLnk INNER JOIN GRVItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = GRVItem.GRVItem_StockItemID) INNER JOIN GRV ON (DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = GRV.GRV_DayEndID) AND (GRVItem.GRVItem_GRVID = GRV.GRVID) SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV = [DayEndStockItemLnk_QuantityGRV]+IIf([GRVItem]![GRVItem_Return],0-[GRVItem_PackSize]*[GRVItem_Quantity],[GRVItem_PackSize]*[GRVItem_Quantity]) WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=2) AND ((GRV.GRV_GRVStatusID)=3));")

                For x = dayStart To dayEnd
                    'Multi Warehouse change     cnnDB.Execute "UPDATE DayEndStockItemLnk AS dayEndToday INNER JOIN DayEndStockItemLnk AS Tomarrow ON dayEndToday.DayEndStockItemLnk_StockItemID = Tomarrow.DayEndStockItemLnk_StockItemID SET Tomarrow.DayEndStockItemLnk_Quantity = [dayEndToday]![DayEndStockItemLnk_Quantity]-[dayEndToday]![DayEndStockItemLnk_QuantitySales]-[dayEndToday]![DayEndStockItemLnk_QuantityShrink]+[dayEndToday]![DayEndStockItemLnk_QuantityGRV] WHERE (((dayEndToday.DayEndStockItemLnk_DayEndID)=" & x & ") AND ((Tomarrow.DayEndStockItemLnk_DayEndID)=[dayendtoday]![DayEndStockItemLnk_DayEndID]+1));"
                    'Tranfer change             cnnDB.Execute "UPDATE DayEndStockItemLnk AS dayEndToday INNER JOIN DayEndStockItemLnk AS Tomarrow ON dayEndToday.DayEndStockItemLnk_StockItemID = Tomarrow.DayEndStockItemLnk_StockItemID AND dayEndToday.DayEndStockItemLnk_Warehouse = Tomarrow.DayEndStockItemLnk_Warehouse SET Tomarrow.DayEndStockItemLnk_Quantity = [dayEndToday]![DayEndStockItemLnk_Quantity]-[dayEndToday]![DayEndStockItemLnk_QuantitySales]-[dayEndToday]![DayEndStockItemLnk_QuantityShrink]+[dayEndToday]![DayEndStockItemLnk_QuantityGRV] WHERE (((dayEndToday.DayEndStockItemLnk_DayEndID)=" & x & ") AND ((Tomarrow.DayEndStockItemLnk_DayEndID)=[dayendtoday]![DayEndStockItemLnk_DayEndID]+1));"
                    cnnDB.Execute("UPDATE DayEndStockItemLnk AS dayEndToday INNER JOIN DayEndStockItemLnk AS Tomarrow ON dayEndToday.DayEndStockItemLnk_StockItemID = Tomarrow.DayEndStockItemLnk_StockItemID AND dayEndToday.DayEndStockItemLnk_Warehouse = Tomarrow.DayEndStockItemLnk_Warehouse SET Tomarrow.DayEndStockItemLnk_Quantity = [dayEndToday]![DayEndStockItemLnk_Quantity]-[dayEndToday]![DayEndStockItemLnk_QuantitySales]-[dayEndToday]![DayEndStockItemLnk_QuantityShrink]+[dayEndToday]![DayEndStockItemLnk_QuantityGRV]+[dayEndToday]![DayEndStockItemLnk_QuantityTransafer] WHERE (((dayEndToday.DayEndStockItemLnk_DayEndID)=" & x & ") AND ((Tomarrow.DayEndStockItemLnk_DayEndID)=[dayendtoday]![DayEndStockItemLnk_DayEndID]+1));")
                Next x

                'Multi Warehouse change     cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN (Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2) AND (([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]+[DayEndStockItemLnk_QuantityShrink]-[DayEndStockItemLnk_QuantityGRV])<>[WarehouseStockItemLnk_Quantity]));"
                'Tranfer change             cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN (Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AND WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID = DayEndStockItemLnk.DayEndStockItemLnk_Warehouse SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2) AND (([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]+[DayEndStockItemLnk_QuantityShrink]-[DayEndStockItemLnk_QuantityGRV])<>[WarehouseStockItemLnk_Quantity]));"
                cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN (Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AND WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID = DayEndStockItemLnk.DayEndStockItemLnk_Warehouse SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV]+[DayEndStockItemLnk_QuantityTransafer] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)>1) AND (([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]+[DayEndStockItemLnk_QuantityShrink]-[DayEndStockItemLnk_QuantityGRV]-[DayEndStockItemLnk_QuantityTransafer])<>[WarehouseStockItemLnk_Quantity]));")
                cnnDB.Execute("UPDATE (DayEndDepositItemLnk AS DayEndDepositItemLnk_1 INNER JOIN Company ON DayEndDepositItemLnk_1.DayEndDepositItemLnk_DayEndID = Company.Company_DayEndID) INNER JOIN DayEndDepositItemLnk ON (DayEndDepositItemLnk_1.DayEndDeposittemLnk_DepositID = DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID) AND (DayEndDepositItemLnk_1.DayEndDeposittemLnk_DepositType = DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType) SET DayEndDepositItemLnk_1.DayEndDepositItemLnk_Quantity = [DayEndDepositItemLnk!DayEndDepositItemLnk_Quantity]+[DayEndDepositItemLnk!DayEndDepositItemLnk_QuantityShrink]-[DayEndDepositItemLnk!DayEndDepositItemLnk_QuantitySales]+[DayEndDepositItemLnk!DayEndDepositItemLnk_QuantityGRV] WHERE (((DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID)=[Company_DayEndID]-1));")

                'clear Make finish check for sale qty
                cnnDB.Execute("UPDATE StockItem SET StockItem.StockItem_MakeFinishItem = 0 WHERE StockItemID > 0;")

                If bolAutoDE = True Then
                Else
                    loadDayEndReport(dayEnd - 1)
                End If
                Me.cmdNext.Visible = False
                System.Windows.Forms.Application.DoEvents()

                'blMontheEnd = False
                errDesc = "End Point"
                'On Local Error Resume Next  'Prevent crushes for month End
                If gParameters And gCopySalesToHQ Then
                    'Do Collect Sales....
                    CollectSalesHQ()
                Else

                    'autoupload report
                    'get HO info
                    rsHO = getRS("Select Comp_ID FROM CompanyEmails;")
                    If rsHO.RecordCount > 0 Then
                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rsHO.Fields("Comp_ID").Value) Then
                        Else
                            If rsHO.Fields("Comp_ID").Value = 0 Then
                                If bHOAutoUpload Then
                                    cmdHO_Click()
                                End If
                            End If
                        End If
                    End If
                End If

                System.Windows.Forms.Application.DoEvents()
                cmdPrintSlip_Click()
                System.Windows.Forms.Application.DoEvents()

                If gParameters And gZeroStock_DayEnd Then
                    System.Windows.Forms.Application.DoEvents()
                    Label3.Text = "Please Wait, Reseting Stock to Zero..."
                    Label3.Visible = True
                    EmulateSnapShot()
                    System.Windows.Forms.Application.DoEvents()
                    System.Windows.Forms.Application.DoEvents()
                    Label3.Text = "Reseting Stock Complete..."
                End If

                Me.Cursor = System.Windows.Forms.Cursors.Default
                If VB.Day(System.DateTime.FromOADate(calDayEnd.SelectionStart.ToOADate + 1)) = 1 Then
                    Select Case MsgBox("This is the last day of the month!" & vbCrLf & vbCrLf & "Do you want to do the Month End Now?", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, "Month End Run")
                        Case MsgBoxResult.Yes
                            'blMontheEnd = True
                            frmMonthEnd.ShowDialog()
                    End Select
                End If

                If bolAutoDE = True Then
                    lString = serverPath & "data\4POSInterface\4POSAUTODEDONE.txt"
                    If fso.FileExists(lString) Then fso.DeleteFile(lString, True)
                    lTextstream = fso.OpenTextFile(lString, Scripting.IOMode.ForWriting, True)
                    lTextstream.Write("DONE")
                    lTextstream.Close()
                    End
                    'Unload Me
                End If
        End Select

        Exit Sub
ErrHandlerr:
        MsgBox("Error while DayEnd on " & errDesc & " : " & Err.Number & " : " & Err.Description & " : " & Err.Source)
        Resume Next
    End Sub
	
	Private Sub cmdHO_Click()
		Dim fso As New Scripting.FileSystemObject
		
		'Set variables
		bActiveSession = False
		hOpen = 0
		hConnection = 0
		dwType = FTP_TRANSFER_TYPE_BINARY
		prgCol = "4POS-HQ_"
		NomeFileLog = prgCol & CStr(Format(Now, "ddmmyyyy")) & CStr(Format(Now, "hhmm")) & ".log"
		
		'Check for Zipit file
		If GetSystemPath <> "" Then
			If fso.FileExists(GetSystemPath & "\zipit.dll") Then 
			Else 
				MsgBox("Install headoffice first.") : Exit Sub
			End If
		End If
		
		If LCase(VB.Left(serverPath, 3)) <> "c:\" Then
			MsgBox("4POS HeadOffice Sync Engine must be run on the server", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine")
			Exit Sub
		End If
        Dim ServerN, sqlLinkPath As String
		ServerN = "http://www.4pos.co.za/4HeadOffice/4posheadoffice.pos"
		sqlLinkPath = "http://www.4pos.co.za/4HeadOffice/4posheadoffice.dsl"
		tipftp = CStr(1)
		
        'get HO info
        Dim BranchType, branchID As Integer
        Dim HOfficeID As String
		Dim rs As ADODB.Recordset
		rs = getRS("Select Comp_ID, Comp_Email1, Comp_Email2 FROM CompanyEmails;")
		If rs.RecordCount > 0 Then
			If IsDbNull(rs.Fields("Comp_ID").Value) Then MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine") : Exit Sub
			BranchType = rs.Fields("Comp_ID").Value
			If BranchType = 1 Then Exit Sub 'check if it is Headoffice
			If IsDbNull(rs.Fields("Comp_Email1").Value) Then MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine") : Exit Sub
			If IsNumeric(rs.Fields("Comp_Email1").Value) Then 
			Else 
				MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine") : Exit Sub
			End If
			If CShort(rs.Fields("Comp_Email1").Value) > 0 Then 
			Else 
				MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine") : Exit Sub
			End If
			HOfficeID = rs.Fields("Comp_Email1").Value
			If IsDbNull(rs.Fields("Comp_Email2").Value) Then MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine") : Exit Sub
			If IsNumeric(rs.Fields("Comp_Email2").Value) Then 
			Else 
				MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine") : Exit Sub
			End If
			If CShort(rs.Fields("Comp_Email2").Value) > 0 Then 
			Else 
				MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine") : Exit Sub
			End If
			BranchID = rs.Fields("Comp_Email2").Value
		Else
			MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine")
			Exit Sub
		End If
		
		'CaricaDati  'read the file
		'frmMainHO.Text1.Text = ""
		'frmMainHO.Label1(1).Caption = ""
		'UPGRADE_ISSUE: Load statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"'
        'Load(frmMainHO)
        'PreparaForm
		'frmFTP.Show vbModal
		frmMainHO.tmrAutoDE.Enabled = True
		frmMainHO.ShowDialog() 'vbModal
	End Sub
	
    Public Function GetSystemPath() As String
        Dim strFolder As String
        Dim lngResult As Integer
        strFolder = New String(Chr(0), MAX_PATH)
        lngResult = GetSystemDirectory(strFolder, MAX_PATH)
        If lngResult <> 0 Then
            GetSystemPath = VB.Left(strFolder, InStr(strFolder, Chr(0)) - 1)
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object GetSystemPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            GetSystemPath = ""
        End If
    End Function
	
    Private Function GetWinPath() As String
        Dim strFolder As String
        Dim lngResult As Integer
        strFolder = New String(Chr(0), MAX_PATH)
        lngResult = GetWindowsDirectory(strFolder, MAX_PATH)
        If lngResult <> 0 Then
            GetWinPath = VB.Left(strFolder, InStr(strFolder, Chr(0)) - 1)
        Else
            GetWinPath = ""
        End If
    End Function
	
	Private Function getRegKey(ByRef lKey As Object) As String
        Dim hkey As Integer
		Dim lRetVal As Integer
		Dim vValue As String
		lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\4POS\pos", 0, KEY_QUERY_VALUE, hkey)
		lRetVal = QueryValueEx(hkey, lKey, vValue)
		
		RegCloseKey(hkey)
		getRegKey = vValue
	End Function
	
	Private Sub cmdPrintSlip_Click()
        'Dim Object_Renamed As Object
        Dim rightX As Short
        Dim lString As String
        Dim y As Short
        Dim lRetVal As Integer
        Dim hkey As Integer
        Dim vValue As Integer
        Dim Printer As New Printing.PrintDocument
        Dim gFontSize As Integer
        Dim gValue As Integer
        Dim gFontName As String
		Dim rsPrinter As ADODB.Recordset
		Dim rs As ADODB.Recordset
		Dim TheBarcodePrName As String
		Dim lPrinter As String
        Dim lPrn As New Printing.PrintDocument
        Dim lPrnType As New Printing.PrintDocument
		Dim gObject As Object
		'On Local Error Resume Next
		Const characters As Short = 32
		Dim gWidth As Integer
		Dim gLeft As Integer
		Dim gRight As Integer
		
		rs = getRS("SELECT Company_PrintDayEndSlip from Company;")
		If rs.RecordCount Then
			If rs.Fields("Company_PrintDayEndSlip").Value Then
				
			Else
				Exit Sub
			End If
		Else
			Exit Sub
		End If
		
		On Error Resume Next
		gFontName = getRegKey("printerPOSfontName")
		If gFontName = "" Then gFontName = "Courier"
		gValue = getRegKey("printerPOSfontSize")
		If gValue = "" Then
			gFontSize = 10
		Else
			gFontSize = CShort(gValue)
		End If
		
		gValue = getRegKey("printerPOSleft")
		On Error Resume Next
		'UPGRADE_WARNING: Couldn't resolve default property of object gValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If gValue = "" Then
			gLeft = 0
		Else
			gLeft = CInt(gValue) * twipsPerPixel(True)
		End If
		gValue = getRegKey("printerPOSright")
		If gValue = "" Then
			gRight = 0
		Else
			gRight = CInt(gValue) * twipsPerPixel(True)
		End If
		
		vValue = ""
		lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\4POS\pos", 0, KEY_QUERY_VALUE, hkey)
		lRetVal = QueryValueEx(hkey, "printerPOS", vValue)
		RegCloseKey(hkey)
		If vValue = "" Then vValue = "0"
		
		If vValue <> "0" Then
			If vValue = "[Not Installed]" Then
				Exit Sub
			End If
			
            For Each lPrn In Printing.PrinterSettings.InstalledPrinters
                'If rsPrinter("PrinterName") = (lPrn.DeviceName) Then
               If LCase(lPrn.PrinterSettings.PrinterName) = LCase(vValue) Then
                    Printer = lPrn
                    lPrinter = vValue
                    Exit For
                End If
            Next lPrn

            gWidth = Printer.PrinterSettings.DefaultPageSettings.PrintableArea.Width
            If gWidth = 2724 Then
            Else
                gWidth = 3600
            End If

            gObject = Printer

            On Error Resume Next
            gObject.FontBold = True
            gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.CurrentY. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.TextWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.PSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'gObject.PSet(New Point[](((gWidth - gRight) - gObject.TextWidth(" ")) / 2, gObject.CurrentY))
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.Print(" ")

            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.CurrentY. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.TextWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.PSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'gObject.PSet(New Point[](((gWidth - gRight) - gObject.TextWidth(frmMenu.lblCompany.Text)) / 2, gObject.CurrentY))
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.Print(frmMenu.lblCompany.Text)

            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.Print(" ")

            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.CurrentY. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.TextWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.PSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'gObject.PSet(New Point[](((gWidth - gRight) - gObject.TextWidth("Day End Completed")) / 2, gObject.CurrentY))
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.Print("Day End Completed")
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.Print(" ")

            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.FontUnderline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.FontUnderline = True
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.CurrentY. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object y. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            y = gObject.CurrentY
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.FontBold. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.FontBold = True
            'UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            lString = "Manager" & " :"
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.Print(lString)
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.FontBold. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.FontBold = False
            'UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            lString = frmMenu.lblUser.Text
            'gObject.PSet (1800, y)
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.PSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'gObject.PSet(New Point[](IIf(gWidth = 2724, 1050, 1800), y)) '1350
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.Print(lString)

            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.FontUnderline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.FontUnderline = True
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.CurrentY. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object y. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            y = gObject.CurrentY
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.FontBold. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.FontBold = True
            'UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            lString = "Date" & " :"
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.Print(lString)
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.FontBold. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.FontBold = False
            'UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            lString = Format(Now, "ddd dd mm,yyyy hh:nn")
            'gObject.PSet (1800, y)
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.PSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'gObject.PSet(New Point[](IIf(gWidth = 2724, 1050, 1800), y)) '1350
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.Print(lString)

            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.FontUnderline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.FontUnderline = False

            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.CurrentY. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object rightX. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.Line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'gObject.Line((0, gObject.CurrentY) - ((gObject.Width - gRight) - rightX, gObject.CurrentY + 1))
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.CurrentY. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.PSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'gObject.PSet(New Point[](0, gObject.CurrentY + 30))
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)

            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.Print(" ")
            'UPGRADE_WARNING: Couldn't resolve default property of object Object.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'Object_Renamed.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)

            'For x = 1 To 6
            '    gObject.Print " "
            'Next x
            'UPGRADE_WARNING: Couldn't resolve default property of object gObject.EndDoc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gObject.EndDoc()

        End If
	End Sub
	
	Private Sub ChkStockitemHistoryTable()
		Dim rs As ADODB.Recordset
		Dim strFldName As String
		
ChkTransTable: 
		
		On Error GoTo Err_ChkTransTable
		rs = getRS("SELECT * FROM StockitemHistory777;")
		If rs.RecordCount Then
			cnnDB.Execute("DELETE FROM StockitemHistory777")
		End If
		
		Exit Sub
Err_ChkTransTable: 
		If Err.Number = -2147217865 And Err.Description = "[Microsoft][ODBC Microsoft Access Driver] The Microsoft Jet database engine cannot find the input table or query 'StockitemHistory777'.  Make sure it exists and that its name is spelled correctly." Then
			strFldName = "StockItemID Number, QuantitySales Currency"
			cnnDB.Execute("CREATE TABLE " & "StockitemHistory777" & " (" & strFldName & ")")
			System.Windows.Forms.Application.DoEvents()
			rs = getRS("SELECT * FROM StockitemHistory777;")
			If rs.RecordCount Then
				cnnDB.Execute("DELETE FROM StockitemHistory777")
			End If
			
			GoTo ChkTransTable
		End If
		
	End Sub
	
	Private Sub cmdBack_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBack.Click
		If gMode = mdComplete Then
		End If
		Me.Close()
	End Sub
	
	Private Sub cmdNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNext.Click
		Select Case gMode
			Case mdSecurity
				doMode(mdPOS)
			Case mdPOS
				doMode(mdConfirm)
			Case mdConfirm
				doMode(mdComplete)
		End Select
	End Sub
	
	Private Sub frmDayEnd_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Width = twipsToPixels(pixelToTwips(Me.frmMode(0).Left, True) + _
                             pixelToTwips(frmMode(0).Width, True) + 250, True)
        Height = twipsToPixels(pixelToTwips(Me.cmdBack.Top, False) + _
                              pixelToTwips(cmdBack.Height, False) + 250 + 240, False)
        frmMode.AddRange(New GroupBox() {_frmMode_0, _frmMode_1, _frmMode_2, _frmMode_3, _
                                        _frmMode_4})
        Dim gb As New GroupBox
        For Each gb In frmMode
            AddHandler gb.KeyPress, AddressOf frmDayEnd_KeyPress
        Next
		bolAutoDE_Error = False
		loadLanguage()
		If checkSecurity() Then
		End If
	End Sub
    Private Sub frmDayEnd_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 27 Then
            KeyAscii = 0
            cmdBack_Click(cmdBack, New System.EventArgs())
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
	
	Private Function Encrypt(ByVal secret As String, ByVal password As String) As String
		Dim l As Integer
		Dim x As Short
		Dim Char_Renamed As String
		l = Len(password)
		For x = 1 To Len(secret)
			Char_Renamed = CStr(Asc(Mid(password, (x Mod l) - l * CShort((x Mod l) = 0), 1)))
			Mid(secret, x, 1) = Chr(Asc(Mid(secret, x, 1)) Xor Char_Renamed)
		Next 
		Encrypt = secret
	End Function
	
	Private Function bolSecurityCode() As Boolean
		Dim lCode As String
		Dim leCode As String
		Dim lPassword As String
		Dim rs As ADODB.Recordset
		Dim x As Short
		
		Dim intDate As Short
		Dim intYear As Short
		Dim intMonth As Short
		
		Dim stPass As String
		Dim givPass As String
		
		On Error GoTo Hell_Error
		
		bolSecurityCode = False
		If openConnection() Then
			rs = getRS("SELECT * From Company")
			If rs.RecordCount Then
				If IsNumeric(rs.Fields("Company_PosString").Value) Then
					gSecKey = rs.Fields("Company_PosString").Value
					If Len(rs.Fields("Company_PosString").Value) = 13 Then
						bolSecurityCode = True
						Exit Function
					End If
				End If
				
				If IsDbNull(rs.Fields("Company_PosString").Value) Or rs.Fields("Company_PosString").Value = "0" Then
					bolSecurityCode = True
					Exit Function
				End If
				
				If IsNumeric(rs.Fields("Company_PosString").Value) Then
					intYear = CShort(VB.Left(rs.Fields("Company_PosString").Value, 2))
					intMonth = CShort(Mid(rs.Fields("Company_PosString").Value, 3, 2))
					intDate = CShort(Mid(rs.Fields("Company_PosString").Value, 5, 2))
					
					If (intDate / 2) = System.Math.Round(intDate / 2) Then
						intDate = intDate / 2
					Else
						Exit Function
					End If
					
					
					If (intMonth / 2) = System.Math.Round(intMonth / 2) Then
						intMonth = intMonth / 2
					Else
						Exit Function
					End If
					
					
					If (intYear / 2) = System.Math.Round(intYear / 2) Then
						intYear = intYear / 2
					Else
						Exit Function
					End If
					
					stPass = "20"
					If Len(CStr(intYear)) = 1 Then stPass = stPass & "0" & intYear & "/" Else stPass = stPass & intYear & "/"
					If Len(CStr(intMonth)) = 1 Then stPass = stPass & "0" & intMonth & "/" Else stPass = stPass & intMonth & "/"
					If Len(CStr(intDate)) = 1 Then stPass = stPass & "0" & intDate Else stPass = stPass & intDate
					
					If IsDate(stPass) Then
						If CDate(stPass) >= Today Then
							bolSecurityCode = True
							Exit Function
						End If
					End If
					
					'If Left(rs("Company_PosString"), 2) >= Year(Date) And Mid(rs("Company_PosString"), 3, 2) >= Month(Date) And Mid(rs("Company_PosString"), 5) >= Day(Date) Then
					'    bolSecurityCode = True
					'    Exit Function
					'Else
					'    Exit Function
					'End If
					
				Else
					Exit Function
				End If
				
			End If
		Else
			MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS")
			End
		End If
		
		Exit Function
Hell_Error: 
		MsgBox(Err.Number & " - " & Err.Description, MsgBoxStyle.Exclamation)
		Exit Function
	End Function
	
	Private Function checkSecurity() As Boolean
		Dim lCode As String
		Dim leCode As String
		Dim lPassword As String
		Dim rs As ADODB.Recordset
		Dim x As Short
		checkSecurity = False
		lPassword = "pospospospos"
		'only for 4AIR
		If LCase(VB.Left(serverPath, 3)) = "d:\" And LCase(frmMenu.lblCompany.Text) = "4air" Then
			'only for 4AIR
			checkSecurity = True
			doMode(mdPOS)
			Exit Function
		ElseIf LCase(VB.Left(serverPath, 3)) <> "c:\" Then 
			lblDemo.Text = ""
			frmMode(4).Text = ""
			lblText.Text = "Due to security implications the Day End run may only be run from the Main 4POS Server."
			
			lblDemo.ForeColor = System.Drawing.Color.Red
			Me.cmdNext.Enabled = False
			doMode(mdSecurity)
			Exit Function
		End If
		lCode = getSerialNumber
		leCode = Encrypt(lCode, lPassword)
		For x = 1 To Len(leCode)
			If Asc(Mid(leCode, x, 1)) < 33 Then
				leCode = VB.Left(leCode, x - 1) & Chr(33) & Mid(leCode, x + 1)
			End If
		Next x
		
		rs = getRS("SELECT * From Company WHERE Company_Code = '" & Replace(leCode, "'", "''") & "';")
		If rs.RecordCount Then
			checkSecurity = True
			
			'for Security Code
			If bolSecurityCode = True Then
				doMode(mdPOS)
			Else
				lblDemo.Text = "You cannot do more Day Ends due to Security Restrictions. Please Contact 4POS!"
				lblDemo.ForeColor = System.Drawing.Color.Red
				Me.cmdNext.Enabled = False
			End If
			'for Security Code
		Else
			rs = getRS("SELECT * From Company;")
			
			If IsNumeric(rs.Fields("Company_Code").Value) And Len(rs.Fields("Company_Code").Value) = 13 Then
				checkSecurity = True
				
				'for Security Code
				If bolSecurityCode = True Then
					doMode(mdPOS)
				Else
					lblDemo.Text = "You cannot do more Day Ends due to Security Restrictions. Please Contact 4POS!"
					lblDemo.ForeColor = System.Drawing.Color.Red
					Me.cmdNext.Enabled = False
				End If
				'for Security Code
			Else
				rs = getRS("SELECT Max(DayEnd.DayEndID) AS maxID FROM DayEnd;")
				doMode(mdSecurity)
				
				If rs.BOF Or rs.EOF Then
					x = 9
				Else
					x = 10 - rs.Fields("maxID").Value
				End If
				
				If x < 0 Then
					lblDemo.Text = "Your Software has expired. Please Contact 4POS to register!"
					lblDemo.ForeColor = System.Drawing.Color.Red
					Me.cmdNext.Enabled = False
				Else
					lblDemo.Text = "After this Day End run you will have " & x & " more Day End runs before the demo software expires."
					Me.cmdNext.Enabled = True
				End If
			End If
		End If
		
	End Function
	
	Private Sub frmDayEnd_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		Dim fso As New Scripting.FileSystemObject
		Dim lTextstream As Scripting.TextStream
		Dim lString As String
		If bolAutoDE = True Then
			lString = serverPath & "data\4POSInterface\4POSAUTODE.txt"
			If fso.FileExists(lString) Then fso.DeleteFile(lString, True)
			lString = serverPath & "data\4POSInterface\4POSAUTODEDONE.txt"
			If fso.FileExists(lString) Then fso.DeleteFile(lString, True)
			lTextstream = fso.OpenTextFile(lString, Scripting.IOMode.ForWriting, True)
			lTextstream.Write("DONE")
			lTextstream.Close()
			End
			'Unload Me
		End If
	End Sub
End Class