Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmCustomerTransactionNotes
	Inherits System.Windows.Forms.Form
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim mbChangedByCode As Boolean
	Dim mvBookMark As Integer
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
	
	Dim gID As Integer
	Dim gSection As Short
	
	Const sec_Payment As Short = 0
	Const sec_Debit As Short = 1
	Const sec_Credit As Short = 2
	Const sec_DebitNote As Short = 3
	Const sec_CreditNote As Short = 4

    Dim txtFields As New List(Of TextBox)
    Dim txtfloat As New List(Of TextBox)

	Private Sub loadLanguage()
		
		'frmCustomerTransactionNotes= No Code    [Customer Transaction]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmCustomerTransactionNotes.Caption = rsLang("LanguageLayoutLnk_Description"): frmCustomerTransactionNotes.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1010 'General|Checked
		If rsLang.RecordCount Then _lbl_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1284 'Invoice Name|Checked
		If rsLang.RecordCount Then _lblLabels_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1285 'Department|Checked
		If rsLang.RecordCount Then _lblLabels_3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1286 'Responsible Person Name|Checked
		If rsLang.RecordCount Then _lblLabels_4.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_4.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1287 'Surname|Checked
		If rsLang.RecordCount Then _lblLabels_5.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_5.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1288 'Telephone|Checked
		If rsLang.RecordCount Then _lblLabels_8.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_8.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1289 'Fax|Checked
		If rsLang.RecordCount Then _lblLabels_9.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_9.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1290 'Email|Checked
		If rsLang.RecordCount Then _lblLabels_10.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_10.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1291 'Physical Address|Checked
		If rsLang.RecordCount Then _lblLabels_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_6.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1292 'Postal Address|Checked
		If rsLang.RecordCount Then _lblLabels_7.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_7.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1319 'Financials|Checked
		If rsLang.RecordCount Then _lbl_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1293 'Credit Limit|Checked
		If rsLang.RecordCount Then _lblLabels_12.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_12.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1295 'Current|Checked
		If rsLang.RecordCount Then _lblLabels_13.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_13.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1297 '60 Days|Checked
		If rsLang.RecordCount Then _lblLabels_15.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_15.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1299 '120 Days|Checked
		If rsLang.RecordCount Then _lblLabels_17.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_17.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1296 '30 Days|Checked
		If rsLang.RecordCount Then _lblLabels_14.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_14.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1298 '90 Days|Checked
		If rsLang.RecordCount Then _lblLabels_16.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_16.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1300 '150 Days|Checked
		If rsLang.RecordCount Then _lblLabels_18.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_18.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lbl_2 = No Code                   [Transaction]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1327 'Narrative|Checked
		If rsLang.RecordCount Then _lblLabels_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1328 'Notes|Checked
		If rsLang.RecordCount Then _lblLabels_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1329 'Amount|Checked
		If rsLang.RecordCount Then _lblLabels_11.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_11.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1330 'Settlement|Checked
		If rsLang.RecordCount Then lblSett.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lblSett.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1331 'Settlement|Checked
		If rsLang.RecordCount Then Label2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1332 'Process|Checked
		If rsLang.RecordCount Then cmdProcess.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdProcess.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmCustomerTransactionNotes.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Sub loadItem(ByRef id As Integer, ByRef section As Short)
		Dim oText As System.Windows.Forms.TextBox
		Dim oCheck As System.Windows.Forms.CheckBox
		On Error Resume Next
		
		Me.lblSett.Visible = True
		Me.txtSettlement.Visible = True
		
		If id Then
			adoPrimaryRS = getRS("select * from Customer WHERE CustomerID = " & id)
		Else
			Me.Close()
			Exit Sub
		End If
		gSection = section
		Select Case gSection
			Case sec_DebitNote
				Me.lblSett.Visible = False
				Me.txtSettlement.Visible = False
				Me.Text = " Debit Note"
			Case sec_CreditNote
				Me.lblSett.Visible = False
				Me.txtSettlement.Visible = False
				Me.Text = "Credit note"
			Case Else
				Me.Close()
				Exit Sub
		End Select
		_lbl_2.Text = "&3. Transaction (" & Me.Text & ")"
		'    If adoPrimaryRS.BOF Or adoPrimaryRS.EOF Then
		'    Else
        For Each oText In txtFields
            oText.DataBindings.Add(adoPrimaryRS)
            oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize
        Next oText
		'        For Each oText In Me.txtInteger
		'            Set oText.DataBindings.Add(adoPrimaryRS)
		'            txtInteger_LostFocus oText.Index
		'        Next
        For Each oText In txtfloat
            oText.DataBindings.Add(adoPrimaryRS)
            If oText.Text = "" Then oText.Text = "0"
            oText.Text = CStr(CDbl(oText.Text) * 100)
            AddHandler oText.Leave, AddressOf txtFloat_Leave
            'txtFloat_Leave(txtfloat.Item((oText.Index)), New System.EventArgs())
        Next oText
		'Bind the check boxes to the data provider
		'        For Each oCheck In Me.chkFields
		'            Set oCheck.DataBindings.Add(adoPrimaryRS)
		'        Next
        'buildDataControls()
		mbDataChanged = False
		
		loadLanguage()
		ShowDialog()
		'    End If
	End Sub
	
	Private Sub cmdProcess_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdProcess.Click
        Dim amount As Decimal
		Dim sql As String
		Dim sql1 As String
		Dim rs As ADODB.Recordset
		Dim id As String
		Dim days120, days60, current, lAmount, days30, days90, days150 As Decimal
		System.Windows.Forms.Application.DoEvents()
		If txtNarrative.Text = "" Then
			MsgBox("Narrative is a mandarory field", MsgBoxStyle.Exclamation, Me.Text)
			txtNarrative.Focus()
			Exit Sub
		End If
		If CDec(txtAmount.Text) = 0 Then
			MsgBox("Amount is a mandarory field", MsgBoxStyle.Exclamation, Me.Text)
			txtAmount.Focus()
			Exit Sub
		End If
		
		sql = "INSERT INTO CustomerTransaction ( CustomerTransaction_CustomerID, CustomerTransaction_TransactionTypeID, CustomerTransaction_DayEndID, CustomerTransaction_MonthEndID, CustomerTransaction_ReferenceID, CustomerTransaction_Date, CustomerTransaction_Description, CustomerTransaction_Amount, CustomerTransaction_Reference, CustomerTransaction_PersonName )"
		Select Case gSection
			Case sec_Payment
				sql = sql & "SELECT " & adoPrimaryRS.Fields("CustomerID").Value & " AS Customer, 3 AS [type], Company.Company_DayEndID, Company.Company_MonthEndID, 0 AS referenceID, Now() AS [Date], '" & Replace(Me.txtNotes.Text, "'", "''") & "' AS description, " & CDec(0 - CDec(Me.txtAmount.Text)) & " AS amount, '" & Replace(Me.txtNarrative.Text, "'", "''") & "' AS reference, 'System' AS person FROM Company;"
			Case sec_Debit
				sql = sql & "SELECT " & adoPrimaryRS.Fields("CustomerID").Value & " AS Customer, 4 AS [type], Company.Company_DayEndID, Company.Company_MonthEndID, 0 AS referenceID, Now() AS [Date], '" & Replace(Me.txtNotes.Text, "'", "''") & "' AS description, " & CDec(Me.txtAmount.Text) & " AS amount, '" & Replace(Me.txtNarrative.Text, "'", "''") & "' AS reference, 'System' AS person FROM Company;"
			Case sec_Credit
				sql = sql & "SELECT " & adoPrimaryRS.Fields("CustomerID").Value & " AS Customer, 5 AS [type], Company.Company_DayEndID, Company.Company_MonthEndID, 0 AS referenceID, Now() AS [Date], '" & Replace(Me.txtNotes.Text, "'", "''") & "' AS description, " & CDec(0 - CDec(Me.txtAmount.Text)) & " AS amount, '" & Replace(Me.txtNarrative.Text, "'", "''") & "' AS reference, 'System' AS person FROM Company;"
			Case sec_DebitNote
				sql = sql & "SELECT " & adoPrimaryRS.Fields("CustomerID").Value & " AS Customer, 7 AS [type], Company.Company_DayEndID, Company.Company_MonthEndID, 0 AS referenceID, Now() AS [Date], '" & Replace(Me.txtNotes.Text, "'", "''") & "' AS description, " & CDec(Me.txtAmount.Text) & " AS amount, '" & Replace(Me.txtNarrative.Text, "'", "''") & "' AS reference, 'System' AS person FROM Company;"
			Case sec_CreditNote
				sql = sql & "SELECT " & adoPrimaryRS.Fields("CustomerID").Value & " AS Customer, 6 AS [type], Company.Company_DayEndID, Company.Company_MonthEndID, 0 AS referenceID, Now() AS [Date], '" & Replace(Me.txtNotes.Text, "'", "''") & "' AS description, " & CDec(0 - CDec(Me.txtAmount.Text)) & " AS amount, '" & Replace(Me.txtNarrative.Text, "'", "''") & "' AS reference, 'System' AS person FROM Company;"
				
		End Select
		
		cnnDB.Execute(sql)
		
		rs = getRS("SELECT MAX(CustomerTransactionID) AS id From CustomerTransaction")
		If rs.BOF Or rs.EOF Then
		Else
			id = rs.Fields("id").Value
			cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_Current = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_Current) Is Null));")
			cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_30Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_30Days) Is Null));")
			cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_60Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_60Days) Is Null));")
			cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_90Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_90Days) Is Null));")
			cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_120Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_120Days) Is Null));")
			cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_150Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_150Days) Is Null));")
			
			rs = getRS("SELECT CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_Amount, Customer.Customer_Current, Customer.Customer_30Days, Customer.Customer_60Days, Customer.Customer_90Days, Customer.Customer_120Days, Customer.Customer_150Days FROM Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID Where (((CustomerTransaction.CustomerTransactionID) = " & id & "));")
			
			amount = rs.Fields("CustomerTransaction_Amount").Value
			current = rs.Fields("Customer_Current").Value
			days30 = rs.Fields("Customer_30Days").Value
			days60 = rs.Fields("Customer_60Days").Value
			days90 = rs.Fields("Customer_90Days").Value
			days120 = rs.Fields("Customer_120Days").Value
			days150 = rs.Fields("Customer_150Days").Value
			If amount < 0 Then
				days150 = days150 + amount
				If (days150 < 0) Then
					amount = days150
					days150 = 0
				Else
					amount = 0
				End If
				days120 = days120 + amount
				If (days120 < 0) Then
					amount = days120
					days120 = 0
				Else
					amount = 0
				End If
				days90 = days90 + amount
				If (days90 < 0) Then
					amount = days90
					days90 = 0
				Else
					amount = 0
				End If
				days60 = days60 + amount
				If (days60 < 0) Then
					amount = days60
					days60 = 0
				Else
					amount = 0
				End If
				days30 = days30 + amount
				If (days30 < 0) Then
					amount = days30
					days30 = 0
				Else
					amount = 0
				End If
			End If
			current = current + amount
			cnnDB.Execute("UPDATE Customer SET Customer.Customer_Current = " & current & ", Customer.Customer_30Days = " & days30 & ", Customer.Customer_60Days = " & days60 & ", Customer.Customer_90Days = " & days90 & ", Customer.Customer_120Days = " & days120 & ", Customer.Customer_150Days = 0" & days150 & " WHERE (((Customer.CustomerID)=" & rs.Fields("CustomerTransaction_CustomerID").Value & "));")
		End If
		
		
		If Val(txtSettlement.Text) > 0 Then
			sql1 = "INSERT INTO CustomerTransaction ( CustomerTransaction_CustomerID, CustomerTransaction_TransactionTypeID, CustomerTransaction_DayEndID, CustomerTransaction_MonthEndID, CustomerTransaction_ReferenceID, CustomerTransaction_Date, CustomerTransaction_Description, CustomerTransaction_Amount, CustomerTransaction_Reference, CustomerTransaction_PersonName )"
			sql1 = sql1 & "SELECT " & adoPrimaryRS.Fields("CustomerID").Value & " AS Customer, 8 AS [type], Company.Company_DayEndID, Company.Company_MonthEndID, 0 AS referenceID, Now() AS [Date], '" & Replace(Me.txtNotes.Text, "'", "''") & "' AS description, " & CDec(0 - CDec(Me.txtSettlement.Text)) & " AS amount,'" & Replace(Me.txtNarrative.Text, "'", "''") & "', 'System' AS person FROM Company;"
			
			cnnDB.Execute(sql1)
			
			rs = getRS("SELECT MAX(CustomerTransactionID) AS id From CustomerTransaction")
			
			If rs.BOF Or rs.EOF Then
			Else
				id = rs.Fields("id").Value
				cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_Current = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_Current) Is Null));")
				cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_30Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_30Days) Is Null));")
				cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_60Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_60Days) Is Null));")
				cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_90Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_90Days) Is Null));")
				cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_120Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_120Days) Is Null));")
				cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_150Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_150Days) Is Null));")
				
				rs = getRS("SELECT CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_Amount, Customer.Customer_Current, Customer.Customer_30Days, Customer.Customer_60Days, Customer.Customer_90Days, Customer.Customer_120Days, Customer.Customer_150Days FROM Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID Where (((CustomerTransaction.CustomerTransactionID) = " & id & "));")
				amount = rs.Fields("CustomerTransaction_Amount").Value
				current = rs.Fields("Customer_Current").Value
				days30 = rs.Fields("Customer_30Days").Value
				days60 = rs.Fields("Customer_60Days").Value
				days90 = rs.Fields("Customer_90Days").Value
				days120 = rs.Fields("Customer_120Days").Value
				days150 = rs.Fields("Customer_150Days").Value
				If amount < 0 Then
					days150 = days150 + amount
					If (days150 < 0) Then
						amount = days150
						days150 = 0
					Else
						amount = 0
					End If
					
					days120 = days120 + amount
					If (days120 < 0) Then
						amount = days120
						days120 = 0
					Else
						amount = 0
					End If
					
					days90 = days90 + amount
					If (days90 < 0) Then
						amount = days90
						days90 = 0
					Else
						amount = 0
					End If
					
					days60 = days60 + amount
					If (days60 < 0) Then
						amount = days60
						days60 = 0
					Else
						amount = 0
					End If
					
					days30 = days30 + amount
					If (days30 < 0) Then
						amount = days30
						days30 = 0
					Else
						amount = 0
					End If
				End If
				current = amount
				cnnDB.Execute("UPDATE Customer SET Customer.Customer_Current = " & current & ", Customer.Customer_30Days = " & days30 & ", Customer.Customer_60Days = " & days60 & ", Customer.Customer_90Days = " & days90 & ", Customer.Customer_120Days = " & days120 & ", Customer.Customer_150Days = 0" & days150 & " WHERE (((Customer.CustomerID)=" & rs.Fields("CustomerTransaction_CustomerID").Value & "));")
			End If
		End If
		
		cmdStatement_Click()
		Me.Close()
		
	End Sub
	Private Sub cmdProcess_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdProcess.Enter
		txtTotalAmount.Text = FormatNumber(CDec(txtAmount.Text) + CDec(txtSettlement.Text), 2)
	End Sub
	
	Private Sub cmdStatement_Click()
		report_CustomerNotes(adoPrimaryRS.Fields("CustomerID").Value, gSection)
    End Sub

    Private Sub frmCustomerTransactionNotes_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtFields.AddRange(New TextBox() {_txtFields_2, _txtFields_3, _txtFields_4, _txtFields_5, _
                                          _txtFields_6, _txtFields_7, _txtFields_8, _txtFields_9, _
                                          _txtFields_10})
        txtfloat.AddRange(New TextBox() {_txtFloat_12, _txtFloat_13, _txtFloat_14, _txtFloat_15, _
                                         _txtFloat_16, _txtFloat_17, _txtFloat_18})
        Dim tb As New TextBox
        For Each tb In txtFields
            AddHandler tb.Enter, AddressOf txtFields_Enter
        Next
        For Each tb In txtfloat
            AddHandler tb.Enter, AddressOf txtFloat_Enter
            AddHandler tb.KeyPress, AddressOf txtFloat_KeyPress
        Next
    End Sub
	
	Private Sub frmCustomerTransactionNotes_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        Dim cmdLast As New Button
        Dim cmdnext As New Button
        Dim lblStatus As New Label
		On Error Resume Next
		lblStatus.Width = pixelToTwips(Me.Width, True) - 1500
		cmdnext.Left = lblStatus.Width + 700
		cmdLast.Left = cmdnext.Left + 340
	End Sub
	
	Private Sub frmCustomerTransactionNotes_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If mbEditFlag Or mbAddNewFlag Then Exit Sub
		
		Select Case KeyCode
			Case System.Windows.Forms.Keys.Escape
				KeyCode = 0
				System.Windows.Forms.Application.DoEvents()
				adoPrimaryRS.Move(0)
				cmdClose_Click(cmdClose, New System.EventArgs())
		End Select
	End Sub
	
	Private Sub frmCustomerTransactionNotes_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
	End Sub
	
	Private Sub adoPrimaryRS_MoveComplete(ByVal adReason As ADODB.EventReasonEnum, ByVal pError As ADODB.Error, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.MoveComplete
		'This will display the current record position for this recordset
	End Sub
	
	Private Sub adoPrimaryRS_WillChangeRecord(ByVal adReason As ADODB.EventReasonEnum, ByVal cRecords As Integer, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.WillChangeRecord
		'This is where you put validation code
		'This event gets called when the following actions occur
		Dim bCancel As Boolean
		Select Case adReason
			Case ADODB.EventReasonEnum.adRsnAddNew
			Case ADODB.EventReasonEnum.adRsnClose
			Case ADODB.EventReasonEnum.adRsnDelete
			Case ADODB.EventReasonEnum.adRsnFirstChange
			Case ADODB.EventReasonEnum.adRsnMove
			Case ADODB.EventReasonEnum.adRsnRequery
			Case ADODB.EventReasonEnum.adRsnResynch
			Case ADODB.EventReasonEnum.adRsnUndoAddNew
			Case ADODB.EventReasonEnum.adRsnUndoDelete
			Case ADODB.EventReasonEnum.adRsnUndoUpdate
			Case ADODB.EventReasonEnum.adRsnUpdate
		End Select
		
		If bCancel Then adStatus = ADODB.EventStatusEnum.adStatusCancel
	End Sub
	
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        Dim oText As New TextBox
		On Error Resume Next
		If mbAddNewFlag Then
			Me.Close()
		Else
			mbEditFlag = False
			mbAddNewFlag = False
			adoPrimaryRS.CancelUpdate()
			If mvBookMark > 0 Then
				adoPrimaryRS.Bookmark = mvBookMark
			Else
				adoPrimaryRS.MoveFirst()
			End If
            For Each oText In txtfloat
                If oText.Text = "" Then oText.Text = "0"
                oText.Text = oText.Text * 100
                AddHandler oText.Leave, AddressOf txtFloat_Leave
                'txtFloat_Leave(txtfloat.Item(oText.Index), New System.EventArgs())
            Next oText
			mbDataChanged = False
		End If
	End Sub
	
	Private Function update_Renamed() As Boolean
		On Error GoTo UpdateErr
		update_Renamed = True
		Exit Function
		'    If _txtFields_2.Text = "" Then
		'        _txtFields_2.Text = "[Customer]"
		'    End If
		
		adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll)
		If mbAddNewFlag Then
			adoPrimaryRS.MoveLast() 'move to the new record
		End If
		
		mbEditFlag = False
		mbAddNewFlag = False
		mbDataChanged = False
		
		Exit Function
UpdateErr: 
		MsgBox(Err.Description)
		update_Renamed = False
	End Function
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		cmdClose.Focus()
		System.Windows.Forms.Application.DoEvents()
		If update_Renamed() Then
			Me.Close()
		End If
	End Sub
	
	Private Sub txtAmount_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtAmount.Enter
        MyGotFocusNumeric(txtAmount.Text())
	End Sub
	
	Private Sub txtAmount_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        MyKeyPress(KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtAmount_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtAmount.Leave
        MyLostFocus(txtAmount, 2)
    End Sub
    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtFields.Enter
        Dim Index As Integer
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Index = GetIndexer(txtBox, txtFields)
        MyGotFocus(txtFields(Index))
    End Sub

    Private Sub txtInteger_MyGotFocus(ByRef Index As Short)
        '    MyGotFocusNumeric txtInteger(Index)
    End Sub

    Private Sub txtInteger_KeyPress(ByRef Index As Short, ByRef KeyAscii As Short)
        '    KeyPress KeyAscii
    End Sub

    Private Sub txtInteger_MyLostFocus(ByRef Index As Short)
        '    LostFocus txtInteger(Index), 0
    End Sub

    Private Sub txtFloat_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtFloat.Enter
        Dim Index As Integer
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Index = GetIndexer(txtBox, txtfloat)
        MyGotFocusNumeric(txtfloat(Index))
    End Sub

    Private Sub txtFloat_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) 'Handles txtfloat.
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'Dim Index As Short = txtFloat.GetIndex(eventSender)
        MyKeyPress(KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtFloat_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtFloat.Leave
        Dim Index As Integer
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Index = GetIndexer(txtBox, txtfloat)
        MyLostFocus(txtfloat(Index), 2)
    End Sub

    Private Sub txtNarrative_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtNarrative.Enter
        MyGotFocus(txtNarrative.Text())
    End Sub

    Private Sub txtNotes_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtNotes.Enter
        MyGotFocus(txtNotes.Text())
    End Sub
    Private Sub txtSettlement_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSettlement.Enter
        MyGotFocusNumeric(txtSettlement.Text())
    End Sub

    Private Sub txtSettlement_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtSettlement.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        MyKeyPress(KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	Private Sub txtSettlement_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSettlement.Leave
        MyLostFocus(txtSettlement, 2)
	End Sub
End Class