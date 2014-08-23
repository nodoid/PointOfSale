Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmCustomerStatement
	Inherits System.Windows.Forms.Form
	Dim gMonth As Short
	Dim cnnDBStatement As New ADODB.Connection
	
	Dim gRS As ADODB.Recordset
	
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1391 'Customer Statement Run|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1085 'Print|Checked
		If rsLang.RecordCount Then cmdPrint.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrint.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'chkFields = No Code        [Do not print Payment Date on Statement]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkFields.Caption = rsLang("LanguageLayoutLnk_Description"): chkFields.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1080 'Search|Checked
		If rsLang.RecordCount Then lbl.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	
	Private Sub cmdNew_Click()
		frmCustomer.loadItem(0)
		doSearch()
	End Sub
	Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
		Dim fso As New Scripting.FileSystemObject
		Dim strDBPath As String
		If DataList1.BoundText <> "" Then
			
			If Me.cmbMonthEnd.SelectedIndex = 0 Then MsgBox("Please select Month from List and then click PRINT.", MsgBoxStyle.Exclamation) : Exit Sub
			strDBPath = serverPath & "month" & gMonth - Me.cmbMonthEnd.SelectedIndex & ".mdb"
			If fso.FileExists(strDBPath) Then
				With cnnDBStatement
					.Provider = "MSDataShape"
					cnnDBStatement.Open("Data Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & strDBPath & ";User Id=liquid;Password=lqd;Jet OLEDB:System Database=" & serverPath & "Secured.mdw")
					
				End With
				CustomerStatement(CInt(DataList1.BoundText))
				cnnDBStatement.Close()
			Else
				MsgBox("There is no previous month statement for this Customer", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OKOnly + MsgBoxStyle.Information, My.Application.Info.Title)
				Me.Close()
			End If
			
			'strDBPath = serverPath & "month" & gMonth - Me.cmbMonth.ListIndex & ".mdb"
			'If fso.FileExists(strDBPath) Then
			'   With cnnDBStatement
			'        .Provider = "MSDataShape"
			'        cnnDBStatement.Open "Data Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & strDBPath & ";User Id=liquid;Password=lqd;Jet OLEDB:System Database=" & serverPath & "Secured.mdw"
			'
			'   End With
			'   CustomerStatement DataList1.BoundText
			'   cnnDBStatement.Close
			'Else
			'   MsgBox "There is no previous month statement for this Customer", vbApplicationModal + vbOKOnly + vbInformation, App.title
			'   Unload Me
			'End If
		End If
	End Sub

	Private Sub CustomerStatement(ByRef id As Integer)
        Dim rsInterest As ADODB.Recordset
        Dim rsCustTransCheck As ADODB.Recordset
        Dim rsTransaction As ADODB.Recordset
        Dim rsCompany As ADODB.Recordset
        Dim lNumber As String
        Dim lAddress As String
		Dim rs As New ADODB.Recordset
        Dim sql As String

        'Dim Report As New cryCustomerStatement_AGING 'cryCustomerStatement
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryCustomerStatement_AGING.rpt")
		Dim lDate As Date
		rs = getRS("SELECT MonthEnd.MonthEnd_Date From MonthEnd WHERE (((MonthEnd.MonthEndID)=" & gMonth - (Me.cmbMonthEnd.SelectedIndex - 1) & "));")
        Report.SetParameterValue("txtStatementDate", Format(rs.Fields("MonthEnd_Date").Value, "dd mmm yyyy"))
		lDate = rs.Fields("MonthEnd_Date").Value
		
		rs.Close()
		rs = getRS("SELECT * FROM Company")
		lDate = System.Date.FromOADate(lDate.ToOADate + 10)
		lDate = System.Date.FromOADate(lDate.ToOADate - VB.Day(lDate)) + rs.Fields("Company_PaymentDay").Value
		If chkFields.CheckState Then
            Report.SetParameterValue("txtPaymentDate", " ")
            Report.SetParameterValue("Text7", " ")
		Else
            Report.SetParameterValue("txtPaymentDate", Format(lDate, "dd mmm yyyy"))
		End If
		lAddress = Replace(rs.Fields("Company_PhysicalAddress").Value, vbCrLf, ", ")
		If VB.Right(lAddress, 2) = ", " Then
            lAddress = VB.Left(lAddress, Len(lAddress) - 2)
        End If
        Report.Database.Tables(1).SetDataSource(rs)
        Report.SetParameterValue("txtAddress", lAddress)
		lNumber = ""
		If rs.Fields("Company_Telephone").Value <> "" Then lNumber = lNumber & "Tel: " & rs.Fields("Company_Telephone").Value
		If rs.Fields("Company_Fax").Value <> "" Then
			If lNumber <> "" Then lNumber = lNumber & " / "
			lNumber = lNumber & "Fax: " & rs.Fields("Company_Fax").Value
		End If
		If rs.Fields("Company_Email").Value <> "" Then
			If lNumber <> "" Then lNumber = lNumber & " / "
			lNumber = lNumber & "Email: " & rs.Fields("Company_Email").Value
		End If
        Report.SetParameterValue("txtNumbers", lNumber)
		
		'New banking details
		If IsDbNull(rs.Fields("Company_BankName").Value) Then
        Else
            Report.SetParameterValue("txtBankName", rs.Fields("Company_BankName"))
        End If
		
		If IsDbNull(rs.Fields("Company_BranchName").Value) Then
        Else
            Report.SetParameterValue("txtBranchName", rs.Fields("Company_BranchName"))
        End If
		
		If IsDbNull(rs.Fields("Company_BranchCode").Value) Then
        Else
            Report.SetParameterValue("txtBranchCode", rs.Fields("Company_BranchCode"))
        End If
		
		If IsDbNull(rs.Fields("Company_AccountNumber").Value) Then
        Else
            Report.SetParameterValue("txtAccountNumber", rs.Fields("Company_AccountNumber"))
        End If
		'...................
		
		rsCompany = New ADODB.Recordset
		rsCompany.Open("SELECT * FROM Customer Where CustomerID = " & id, cnnDBStatement, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
        Report.SetParameterValue("txtDaysCurr", "R " & FormatNumber(rsCompany("Customer_Current"), 2))
        Report.SetParameterValue("txtDays30", "R " & FormatNumber(rsCompany("Customer_30Days"), 2))
        Report.SetParameterValue("txtDays60", "R " & FormatNumber(rsCompany("Customer_60Days"), 2))
        Report.SetParameterValue("txtDays90", "R " & FormatNumber(rsCompany("Customer_90Days"), 2))
        Report.SetParameterValue("txtDays120", "R " & FormatNumber(rsCompany("Customer_120Days"), 2))
        Report.SetParameterValue("txtDays150", "R " & FormatNumber(rsCompany("Customer_150Days"), 2))
		rsCompany.Close()
		
		rsCompany.Open("SELECT * FROM Customer Where CustomerID = " & id, cnnDB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
        Report.Database.Tables(2).SetDataSource(rsCompany)
		
		rsTransaction = New ADODB.Recordset
		'rsTransaction.Open "SELECT CustomerTransaction.CustomerTransactionID, CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_Reference, CustomerTransaction.CustomerTransaction_PersonName," & _
		''" TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" & id & "));", cnnDBStatement, adOpenStatic, adLockReadOnly, adCmdText
		'changed for OPEN ITEM
		'rsTransaction.Open "SELECT CustomerTransaction.CustomerTransactionID, CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_Reference, CustomerTransaction.CustomerTransaction_PersonName," & _
		''" TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" & id & "));", cnnDBStatement, adOpenStatic, adLockReadOnly, adCmdText
		rsCustTransCheck = New ADODB.Recordset
		rsCustTransCheck.Open("SELECT * FROM CustomerTransaction Where CustomerTransaction_CustomerID = " & id, cnnDBStatement, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
		If rsCustTransCheck.Fields.Count <= 12 Then
            rsTransaction.Open("SELECT CustomerTransaction.CustomerTransactionID, CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_Reference, CustomerTransaction.CustomerTransaction_PersonName," & " TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit, 0, 0, 0 FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" & id & "));", cnnDBStatement, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
        Else
            rsTransaction.Open("SELECT CustomerTransaction.CustomerTransactionID, CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount-IIf(IsNull([CustomerTransaction.CustomerTransaction_Allocated]),0,[CustomerTransaction.CustomerTransaction_Allocated]), CustomerTransaction.CustomerTransaction_Reference & IIf([CustomerTransaction.CustomerTransaction_Allocated]<>[CustomerTransaction_Amount] AND [CustomerTransaction.CustomerTransaction_Allocated]<>0,'   (P)',Null), CustomerTransaction.CustomerTransaction_PersonName, TransactionType.TransactionType_Name," & " IIf(([CustomerTransaction_Amount]-IIf(IsNull([CustomerTransaction.CustomerTransaction_Allocated]),0,[CustomerTransaction.CustomerTransaction_Allocated]))>0,([CustomerTransaction_Amount]-IIf(IsNull([CustomerTransaction.CustomerTransaction_Allocated]),0,[CustomerTransaction.CustomerTransaction_Allocated])),Null) AS debit," & " IIf(([CustomerTransaction_Amount]-IIf(IsNull([CustomerTransaction.CustomerTransaction_Allocated]),0,[CustomerTransaction.CustomerTransaction_Allocated]))<0,([CustomerTransaction_Amount]-IIf(IsNull([CustomerTransaction.CustomerTransaction_Allocated]),0,[CustomerTransaction.CustomerTransaction_Allocated])),Null) AS credit, CustomerTransaction.CustomerTransaction_Main, CustomerTransaction.CustomerTransaction_Child, CustomerTransaction.CustomerTransaction_Allocated FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" & id & ") AND ((CustomerTransaction.CustomerTransaction_Amount-IIf(IsNull([CustomerTransaction.CustomerTransaction_Allocated]),0,[CustomerTransaction.CustomerTransaction_Allocated]))<>0));", cnnDBStatement, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
        End If
		'Report.Database.Tables(3).SetDataSource rsTransaction, 3
		If rsTransaction.BOF Or rsTransaction.EOF Then
            rsTransaction = New ADODB.Recordset
            rsTransaction.Open("SELECT 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0," & " 0, 0 AS debit, 0 AS credit;", cnnDBStatement, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
            Report.Database.Tables(3).SetDataSource(rsTransaction)
            'Exit Sub
        Else
            Report.Database.Tables(3).SetDataSource(rsTransaction)
        End If
		
		If rsTransaction.BOF Or rsTransaction.EOF Then
            Exit Sub
        End If
		
		
		'Set rsInterest = New Recordset
		'rsInterest.Open ("SELECT * FROM Interest WHERE (((CustomerID)=" & id & ")) and (Debit>0);"), cnnDBStatement, adOpenStatic, adLockReadOnly, adCmdText
		rsInterest = getRS("SELECT * FROM Interest WHERE (((CustomerID)=" & id & ")) and (Debit>0);")
		
		'If rsInterest.BOF Or rsInterest.EOF Then
		If rsInterest.RecordCount > 0 Then
            Report.ReportDefinition.ReportObjects("Field20").Top = 280
            Report.ReportDefinition.ReportObjects("Field21").Top = 280
            Report.ReportDefinition.ReportObjects("Field22").Top = 280
            Report.ReportDefinition.ReportObjects("Field23").Top = 280

            Report.Database.Tables(4).SetDataSource(rsInterest)

        Else
            'Set rsInterest = New Recordset
            'rsInterest.Open "SELECT 0 AS CustomerID, 0 AS CDate, 0 AS Description, 0 AS Debit, 0 AS Credit, 0 AS SumIntBal ;", cnnDBStatement, adOpenStatic, adLockReadOnly, adCmdText
            rsInterest = getRS("SELECT 0 AS CustomerID, 0 AS CDate, 0 AS Description, 0 AS Debit, 0 AS Credit, 0 AS SumIntBal ;")
            Report.ReportDefinition.Sections("Field20").SectionFormat.EnableSuppress = True
            Report.ReportDefinition.Sections("Field21").SectionFormat.EnableSuppress = True
            Report.ReportDefinition.Sections("Field22").SectionFormat.EnableSuppress = True
            Report.ReportDefinition.Sections("Field23").SectionFormat.EnableSuppress = True
            Report.Database.Tables(4).SetDataSource(rsInterest)

            'Exit Sub
            'Set rsInterest = New Recordset
            'rsInterest.Open "SELECT * FROM Interest WHERE (((CustomerID)=" & id & "));", cnnDBStatement, adOpenStatic, adLockReadOnly, adCmdText
        End If
		
		If rs.Fields("Company_DebtorPrintBal").Value = True Then
            Dim tObj As CrystalDecisions.CrystalReports.Engine.TextObject = Report.ReportDefinition.ReportObjects("Text5")
            tObj.Color = Color.White
		End If
		
        frmReportShow.CRViewer1.ReportSource = Report
		frmReportShow.mReport = Report : frmReportShow.sMode = "0"
		'    frmReportShow.CRViewer1.PrintReport
		frmReportShow.CRViewer1.Refresh()
		'    Unload frmReportShow
		
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		frmReportShow.ShowDialog()
		
	End Sub
	
	
	Private Sub DataList1_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DataList1.DoubleClick
		cmdPrint_Click(cmdPrint, New System.EventArgs())
	End Sub
	
    Private Sub DataList1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles DataList1.KeyPress
        Select Case eventArgs.KeyChar
            Case ChrW(13)
                DataList1_DblClick(DataList1, New System.EventArgs())
                eventArgs.KeyChar = ChrW(0)
            Case ChrW(27)
                Me.Close()
                eventArgs.KeyChar = ChrW(0)
        End Select

    End Sub


    Private Sub frmCustomerStatement_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim loading As Boolean
        Dim rs As ADODB.Recordset
        loading = True
        rs = getRS("SELECT Company_MonthendID FROM Company;")
        gMonth = rs.Fields("Company_MonthendID").Value - 1
        cmbMonth.SelectedIndex = 0
        doSearch()
        loadLanguage()
        'Dim rs As New Recordset
        cmbMonthEnd.Items.Clear()
        rs = getRS("SELECT Min(DayEnd.DayEnd_Date) AS MinOfDayEnd_Date, Max(DayEnd_1.DayEnd_Date) AS MaxOfDayEnd_Date, Company.Company_MonthEndID, MonthEnd.MonthEndID FROM Company, (DayEnd AS DayEnd_1 INNER JOIN MonthEnd ON DayEnd_1.DayEnd_MonthEndID = MonthEnd.MonthEndID) INNER JOIN DayEnd ON MonthEnd.MonthEndID = DayEnd.DayEnd_MonthEndID GROUP BY Company.Company_MonthEndID, MonthEnd.MonthEndID ORDER BY MonthEnd.MonthEndID DESC")
        gMonth = rs.Fields("Company_MonthEndID").Value
        Do Until rs.EOF
            If rs.Fields("Company_MonthEndID").Value = rs.Fields("MonthEndID").Value Then
                cmbMonthEnd.Items.Add("Select Month")
            Else
                cmbMonthEnd.Items.Add((rs.Fields("Company_MonthEndID").Value - rs.Fields("MonthEndID").Value) & " Month/s ago  ( " & Format(rs.Fields("MinOfDayEnd_Date").Value, "dd-MM-yyyy") & "   /   " & Format(rs.Fields("MaxOfDayEnd_Date").Value, "dd-MM-yyyy") & " )")
            End If
            rs.moveNext()
        Loop
        cmbMonthEnd.SelectedIndex = 0
    End Sub

    Private Sub frmCustomerStatement_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        gRS.Close()
    End Sub
    Private Sub frmCustomerStatement_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 27 Then
            KeyAscii = 0
            cmdExit_Click(cmdExit, New System.EventArgs())
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub txtSearch_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSearch.Enter
        txtSearch.SelectionStart = 0
        txtSearch.SelectionLength = 999
    End Sub

    Private Sub txtSearch_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case 40
                Me.DataList1.Focus()
        End Select
    End Sub

    Private Sub txtSearch_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Select Case KeyAscii
            Case 13
                doSearch()
                KeyAscii = 0
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
	Private Sub doSearch()
        Dim lString As String
        Dim bind As BindingSource = New BindingSource
		lString = Trim(txtSearch.Text)
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		If lString = "" Then
		Else
			lString = "AND (Customer_InvoiceName LIKE '%" & Replace(lString, " ", "%' AND Customer_InvoiceName LIKE '%") & "%')"
		End If
		gRS = getRS("SELECT DISTINCT CustomerID, Customer_InvoiceName FROM Customer WHERE Customer_Disabled = 0 " & lString & " ORDER BY Customer_InvoiceName")
        'Display the list of Titles in the DataCombo
		DataList1.DataSource = gRS
		DataList1.listField = "Customer_InvoiceName"
		
		
		'Bind the DataCombo to the ADO Recordset
        'DataList1.DataSource = gRS
        bind.DataSource = gRS
        DataList1.DataBindings.Add(bind.DataSource)
		DataList1.boundColumn = "CustomerID"
		
	End Sub
End Class