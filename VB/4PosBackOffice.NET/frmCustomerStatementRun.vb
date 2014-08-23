Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmCustomerStatementRun
	Inherits System.Windows.Forms.Form
	Dim loading As Boolean
	Dim gID As Short
	Dim gLastIndex As Short
	Dim gMonth As Short
	Dim cnnDBStatement As New ADODB.Connection
	
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1391 'Customer Statement Run|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1085 'Print|Checked
		If rsLang.RecordCount Then cmdPrint.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrint.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1393 'Clear All|Checked
		If rsLang.RecordCount Then cmdClear.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClear.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1395 'Customers|Checked
		If rsLang.RecordCount Then lbl.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmCustomerStatementRun.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub cmdClear_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClear.Click
        Dim x As Integer
		For x = 0 To lstCustomer.Items.Count - 1
			lstCustomer.SetItemChecked(x, False)
		Next x
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	
	Public Sub loadItem()
		Dim rs As ADODB.Recordset
		Dim lValue As Integer
		loading = True
		rs = getRS("SELECT Company_MonthendID FROM Company;")
		gMonth = rs.Fields("Company_MonthendID").Value '- 1
		If gMonth < 1 Then gMonth = 1
		rs = getRS("SELECT Customer.CustomerID, Customer.Customer_InvoiceName, Customer.Customer_PrintStatement From Customer WHERE Customer_Disabled = 0 ORDER BY Customer.Customer_InvoiceName;")
        Dim m As Integer
		Do Until rs.EOF
            m = lstCustomer.Items.Add(New LBI(rs.Fields("Customer_InvoiceName").Value, rs.Fields("CustomerID").Value))
            lstCustomer.SetItemChecked(m, rs.Fields("Customer_PrintStatement").Value)
			rs.moveNext()
		Loop 
		rs.MoveFirst()
		lstCustomer.SelectedIndex = 0
		loading = False
		
		loadLanguage()
		Me.ShowDialog()
	End Sub
	
	Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
		Dim fso As New Scripting.FileSystemObject
		Dim x As Short
		Dim strDBPath As String
		
		strDBPath = serverPath & "month" & gMonth & ".mdb"
		'If FSO.FileExists(strDBPath) Then
		
		'   With cnnDBStatement
		'        .Provider = "MSDataShape"
		'        cnnDBStatement.Open "Data Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & strDBPath & ";User Id=liquid;Password=lqd;Jet OLEDB:System Database=" & serverPath & "Secured.mdw"
		'   End With
		'
		'    For x = 0 To lstCustomer.ListCount - 1
		'         If lstCustomer.Selected(x) Then
		'            CustomerStatement lstCustomer.ItemData(x)
		'         End If
		'    Next x
		'    cnnDBStatement.Close
		'  Else
		
		With cnnDBStatement
			.Provider = "MSDataShape"
			cnnDBStatement.Open("Data Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & serverPath & "pricing.mdb" & ";User Id=liquid;Password=lqd;Jet OLEDB:System Database=" & serverPath & "Secured.mdw")
		End With
		
		For x = 0 To lstCustomer.Items.Count - 1
			If lstCustomer.GetItemChecked(x) Then
                CustomerStatement(CInt(lstCustomer.SelectedIndex))
			End If
		Next x
		cnnDBStatement.Close()
		'MsgBox "Database [month" & gMonth & ".mdb] could not be found", vbApplicationModal + vbInformation + vbOKOnly, App.title
		'Exit Sub
		' End If
		
		
		
	End Sub
	Private Sub CustomerStatement(ByRef id As Integer)
        Dim rsInterest As ADODB.Recordset
        Dim rsTransaction As ADODB.Recordset
        Dim rsCompany As ADODB.Recordset
        Dim lNumber As Integer
        Dim lAddress As String
		Dim rs As New ADODB.Recordset
		Dim sql As String
        'Dim Report As New cryCustomerStatement
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryCustomerStatement.rpt")
		Dim lDate As Date
		rs = getRS("SELECT MonthEnd.MonthEnd_Date From MonthEnd WHERE (((MonthEnd.MonthEndID)=" & gMonth & "));")
		'rs.Open "SELECT MonthEnd.MonthEnd_Date From MonthEnd WHERE (((MonthEnd.MonthEndID)=" & gMonth & "));", cnnDBStatement, adOpenStatic, adLockReadOnly, adCmdText
		'Report.txtStatementDate.SetText Format(rs("MonthEnd_Date"), "dd mmm yyyy")
        Report.SetParameterValue("txtStatementDate", Format(Today, "dd mmm yyyy"))
		lDate = rs.Fields("MonthEnd_Date").Value
		
		rs.Close()
		rs = getRS("SELECT * FROM Company")
		lDate = System.Date.FromOADate(lDate.ToOADate + 10)
		lDate = DateSerial(Year(lDate), Month(lDate), 1)
		lDate = System.Date.FromOADate(lDate + rs.Fields("Company_PaymentDay").Value - 1)
		'Report.txtPaymentDate.SetText Format(lDate, "dd mmm yyyy")
		
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
        Report.Database.Tables(2).SetDataSource(rsCompany)
		
		rsTransaction = New ADODB.Recordset
		'rsTransaction.Open "SELECT CustomerTransaction.*, TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" & id & "));", cnnDBStatement, adOpenStatic, adLockReadOnly, adCmdText
		rsTransaction.Open("SELECT CustomerTransaction.CustomerTransactionID, CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_Reference, CustomerTransaction.CustomerTransaction_PersonName," & " TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" & id & "));", cnnDBStatement, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
		
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
		
		rsInterest = New ADODB.Recordset
		rsInterest.Open("SELECT * FROM Interest WHERE (((CustomerID)=" & id & ")) and (Debit>0);", cnnDBStatement, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
		
		'If rsInterest.BOF Or rsInterest.EOF Then
		If rsInterest.RecordCount > 0 Then
			'Report.Field20.Top = 280
			'Report.Field21.Top = 280
			'Report.Field22.Top = 280
			'Report.Field23.Top = 280
			
            Report.Database.Tables(4).SetDataSource(rsInterest)
		Else
			rsInterest = New ADODB.Recordset
			rsInterest.Open("SELECT 0 AS CustomerID, 0 AS CDate, 0 AS Description, 0 AS Debit, 0 AS Credit, 0 AS SumIntBal ;", cnnDBStatement, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
			'Report.Field20.Suppress = True
			'Report.Field21.Suppress = True
			'Report.Field22.Suppress = True
			'Report.Field23.Suppress = True
            Report.Database.Tables(4).SetDataSource(rsInterest)
			
			'Exit Sub
			'Set rsInterest = New Recordset
			'rsInterest.Open "SELECT * FROM Interest WHERE (((CustomerID)=" & id & "));", cnnDBStatement, adOpenStatic, adLockReadOnly, adCmdText
		End If
		
        'Report.PrintOut(False, 1)
        Report.PrintToPrinter(1, False, 0, 0)
		
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default	
	End Sub
	
	Private Sub frmCustomerStatementRun_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.Escape
				KeyAscii = 0
				System.Windows.Forms.Application.DoEvents()
				cmdExit_Click(cmdExit, New System.EventArgs())
		End Select
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	Private Sub frmCustomerStatementRun_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Dim x As Short
        'Dim bit As Integer
		'    For x = 0 To Me.lstCustomer.ListCount - 1
		'        If lstCustomer.Selected(x) Then
		'            bit = bit + lstCustomer.ItemData(x)
		'        End If
		'    Next x
		'    cnnDB.Execute "UPDATE Person SET Person.Person_SecurityBit = " & bit & " WHERE (((Person.PersonID)=" & gID & "));"
	End Sub
End Class