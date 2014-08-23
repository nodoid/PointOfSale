Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmSupplierTransaction
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

    Dim txtFields As New List(Of TextBox)
    Dim txtFloat As New List(Of TextBox)

	Private Sub loadLanguage()
		
		'frmSupplierTransaction = No Code   [Supplier Transaction]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmSupplierTransaction.Caption = rsLang("LanguageLayoutLnk_Description"): frmSupplierTransaction.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1282 'Statement|Checked
		If rsLang.RecordCount Then cmdStatement.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdStatement.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1010 'General|Checked
		If rsLang.RecordCount Then _lbl_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1442 'Supplier Name|Checked
		If rsLang.RecordCount Then _lblLabels_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1288 'Telephone|Checked
		If rsLang.RecordCount Then _lblLabels_8.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_8.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1289 'Fax|Checked
		If rsLang.RecordCount Then _lblLabels_9.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_9.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1291 'Physical Address|Checked
		If rsLang.RecordCount Then _lblLabels_6.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_6.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1292 'Postal Address|Checked
		If rsLang.RecordCount Then _lblLabels_7.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_7.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1448 'Aging|Checked
		If rsLang.RecordCount Then _lbl_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
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
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1496 'Period|Checked
		If rsLang.RecordCount Then _lbl_3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lbl_2 = No Code
		'DB Entry 2406 closest match, but grammar wrong for use!
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1327 'Narrative|Checked
		If rsLang.RecordCount Then _lblLabels_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1328 'Notes|Checked
		If rsLang.RecordCount Then _lblLabels_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1499 'Amount Paid|Checked
		If rsLang.RecordCount Then _lblLabels_11.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_11.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1330 'Settlement|Checked
		If rsLang.RecordCount Then lblSettl.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lblSettl.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1331 'Total Amount|Checked
		If rsLang.RecordCount Then Label3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1332 'Process|Checked
		If rsLang.RecordCount Then cmdProcess.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdProcess.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmSupplierTransaction.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub buildDataControls()
		'    doDataControl Me.cmbChannel, "SELECT ChannelID, Channel_Name FROM Channel ORDER BY ChannelID", "Customer_ChannelID", "ChannelID", "Channel_Name"
	End Sub
	
	Private Sub doDataControl(ByRef dataControl As System.Windows.Forms.Control, ByRef sql As String, ByRef DataField As String, ByRef boundColumn As String, ByRef listField As String)
        'Dim rs As ADODB.Recordset
        'rs = getRS(sql)
		'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'dataControl.DataSource = rs
		'UPGRADE_ISSUE: Control method dataControl.DataSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        'dataControl.DataBindings.Add(adoPrimaryRS)
		'UPGRADE_ISSUE: Control method dataControl.DataField was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        'dataControl.DataField = DataField
		'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.boundColumn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'dataControl.boundColumn = boundColumn
		'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.listField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'dataControl.listField = listField
	End Sub
	Public Sub loadItem(ByRef id As Integer, ByRef section As Short)
		Dim oText As System.Windows.Forms.TextBox
		Dim oCheck As System.Windows.Forms.CheckBox
		On Error Resume Next
		
		Me.lblSettl.Visible = True
		Me.txtSettlement.Visible = True
		
		If id Then
			adoPrimaryRS = getRS("select SupplierID,Supplier_Name,Supplier_PostalAddress,Supplier_PhysicalAddress,Supplier_Telephone,Supplier_Facimile,Supplier_RepresentativeName,Supplier_RepresentativeNumber,Supplier_ShippingCode,Supplier_OrderAttentionLine,Supplier_Ullage,Supplier_discountCOD,Supplier_discount15days,Supplier_discount30days,Supplier_discount60days,Supplier_discount90days,Supplier_discount120days,Supplier_discountSmartCard,Supplier_discountDefault,Supplier_Current,Supplier_30Days,Supplier_60Days,Supplier_90Days,Supplier_120Days from Supplier WHERE SupplierID = " & id)
		Else
			adoPrimaryRS = getRS("select * from Supplier")
			adoPrimaryRS.AddNew()
			Me.Text = Me.Text & " [New record]"
			mbAddNewFlag = True
		End If
		gSection = section
		Select Case gSection
			Case sec_Payment
				Me.Text = "Account Payment"
			Case sec_Debit
				Me.lblSettl.Visible = False
				Me.txtSettlement.Visible = False
				Me._lblLabels_11.Text = "Debit Journal"
				Me.Text = "Debit Journal-Increase amount owing"
			Case sec_Credit
				Me.lblSettl.Visible = False
				Me.txtSettlement.Visible = False
				Me._lblLabels_11.Text = "Credit Journal"
				Me.Text = "Credit Journal-Decrease amount owing"
			Case Else
				Me.Close()
				Exit Sub
		End Select
		_lbl_2.Text = "&2. Transaction (" & Me.Text & ")"
		Me.cmbPeriod.SelectedIndex = 0
		'    If adoPrimaryRS.BOF Or adoPrimaryRS.EOF Then
		'    Else
		For	Each oText In Me.txtFields
			oText.DataBindings.Add(adoPrimaryRS)
			oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize
		Next oText
		'        For Each oText In Me.txtInteger
		'            Set oText.DataBindings.Add(adoPrimaryRS)
		'            txtInteger_LostFocus oText.Index
		'        Next
		For	Each oText In Me.txtFloat
			oText.DataBindings.Add(adoPrimaryRS)
			If oText.Text = "" Then oText.Text = "0"
            oText.Text = CStr(CDbl(oText.Text) * 100)
            AddHandler oText.Leave, AddressOf txtFloat_Leave
		Next oText
		'        For Each oText In Me.txtFloatNegative
		'            Set oText.DataBindings.Add(adoPrimaryRS)
		'            If oText.Text = "" Then oText.Text = "0"
		'            oText.Text = oText.Text * 100
		'            txtFloatNegative_LostFocus oText.Index
		'        Next
		'Bind the check boxes to the data provider
		'        For Each oCheck In Me.chkFields
		'            Set oCheck.DataBindings.Add(adoPrimaryRS)
		'        Next
		buildDataControls()
		mbDataChanged = False
		
		loadLanguage()
		ShowDialog()
		'    End If
	End Sub
	Private Sub cmdProcess_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdProcess.Click
        Dim days150 As Integer
        Dim days120 As Integer
        Dim days90 As Integer
        Dim days60 As Integer
        Dim days30 As Integer
        Dim current As Integer
        Dim amount As Integer
		Dim sql As String
		Dim rs As ADODB.Recordset
		Dim id As String
		Dim lAmount As Decimal
		Dim lField As String
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
		sql = "INSERT INTO SupplierTransaction ( SupplierTransaction_SupplierID, SupplierTransaction_PersonID, SupplierTransaction_TransactionTypeID, SupplierTransaction_MonthEndID, SupplierTransaction_MonthEndIDFor, SupplierTransaction_DayEndID, SupplierTransaction_ReferenceID, SupplierTransaction_Date, SupplierTransaction_Description, SupplierTransaction_Amount, SupplierTransaction_Reference ) "
		Select Case gSection
			Case sec_Payment
				lAmount = CDec(0 - CDec(Me.txtAmount.Text))
				sql = sql & "SELECT " & adoPrimaryRS.Fields("SupplierID").Value & " AS supplier, " & gPersonID & " AS person, 3 AS transType, Company.Company_MonthEndID, " & Me.cmbPeriod.SelectedIndex & " AS monthFor, Company.Company_DayEndID, 0 as [referenceID], Now() AS [date], '" & Replace(Me.txtNotes.Text, "'", "''") & "' AS notes, " & lAmount & " AS amount, '" & Replace(Me.txtNarrative.Text, "'", "''") & "' AS reference FROM Company;"
			Case sec_Debit
				lAmount = CDec(Me.txtAmount.Text)
				sql = sql & "SELECT " & adoPrimaryRS.Fields("SupplierID").Value & " AS supplier, " & gPersonID & " AS person, 4 AS transType, Company.Company_MonthEndID, " & Me.cmbPeriod.SelectedIndex & " AS monthFor, Company.Company_DayEndID, 0 as [referenceID], Now() AS [date], '" & Replace(Me.txtNotes.Text, "'", "''") & "' AS notes, " & lAmount & " AS amount, '" & Replace(Me.txtNarrative.Text, "'", "''") & "' AS reference FROM Company;"
			Case sec_Credit
				lAmount = CDec(0 - CDec(Me.txtAmount.Text))
				sql = sql & "SELECT " & adoPrimaryRS.Fields("SupplierID").Value & " AS supplier, " & gPersonID & " AS person, 5 AS transType, Company.Company_MonthEndID, " & Me.cmbPeriod.SelectedIndex & " AS monthFor, Company.Company_DayEndID, 0 as [referenceID], Now() AS [date], '" & Replace(Me.txtNotes.Text, "'", "''") & "' AS notes, " & lAmount & " AS amount, '" & Replace(Me.txtNarrative.Text, "'", "''") & "' AS reference FROM Company;"
		End Select
		cnnDB.Execute(sql)
		
		rs = getRS("SELECT MAX(SupplierTransactionID) AS id From SupplierTransaction")
		If rs.BOF Or rs.EOF Then
		Else
			id = rs.Fields("id").Value
			cnnDB.Execute("UPDATE Supplier INNER JOIN SupplierTransaction ON Supplier.SupplierID = SupplierTransaction.SupplierTransaction_SupplierID SET Supplier.Supplier_Current = 0 WHERE (((SupplierTransaction.SupplierTransactionID)=" & id & ") AND ((Supplier.Supplier_Current) Is Null));")
			cnnDB.Execute("UPDATE Supplier INNER JOIN SupplierTransaction ON Supplier.SupplierID = SupplierTransaction.SupplierTransaction_SupplierID SET Supplier.Supplier_30Days = 0 WHERE (((SupplierTransaction.SupplierTransactionID)=" & id & ") AND ((Supplier.Supplier_30Days) Is Null));")
			cnnDB.Execute("UPDATE Supplier INNER JOIN SupplierTransaction ON Supplier.SupplierID = SupplierTransaction.SupplierTransaction_SupplierID SET Supplier.Supplier_60Days = 0 WHERE (((SupplierTransaction.SupplierTransactionID)=" & id & ") AND ((Supplier.Supplier_60Days) Is Null));")
			cnnDB.Execute("UPDATE Supplier INNER JOIN SupplierTransaction ON Supplier.SupplierID = SupplierTransaction.SupplierTransaction_SupplierID SET Supplier.Supplier_90Days = 0 WHERE (((SupplierTransaction.SupplierTransactionID)=" & id & ") AND ((Supplier.Supplier_90Days) Is Null));")
			cnnDB.Execute("UPDATE Supplier INNER JOIN SupplierTransaction ON Supplier.SupplierID = SupplierTransaction.SupplierTransaction_SupplierID SET Supplier.Supplier_120Days = 0 WHERE (((SupplierTransaction.SupplierTransactionID)=" & id & ") AND ((Supplier.Supplier_120Days) Is Null));")
			'cnnDB.Execute "UPDATE Supplier INNER JOIN SupplierTransaction ON Supplier.SupplierID = SupplierTransaction.SupplierTransaction_SupplierID SET Supplier.Customer_150Days = 0 WHERE (((SupplierTransaction.SupplierTransactionID)=" & id & ") AND ((Supplier.Supplier_150Days) Is Null));"
			
			'Set rs = getRS("SELECT SupplierTransaction.SupplierTransaction_SupplierID, SupplierTransaction.SupplierTransaction_Amount, Supplier.Supplier_Current, Supplier.Supplier_30Days, Supplier.Supplier_60Days, Supplier.Supplier_90Days, Supplier.Supplier_120Days, Supplier.Supplier_150Days FROM Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID Where (((CustomerTransaction.CustomerTransactionID) = " & id & "));")
			rs = getRS("SELECT SupplierTransaction.SupplierTransaction_SupplierID, SupplierTransaction.SupplierTransaction_Amount, Supplier.Supplier_Current, Supplier.Supplier_30Days, Supplier.Supplier_60Days, Supplier.Supplier_90Days, Supplier.Supplier_120Days FROM Supplier INNER JOIN SupplierTransaction ON Supplier.SupplierID = SupplierTransaction.SupplierTransaction_SupplierID Where (((SupplierTransaction.SupplierTransactionID) = " & id & "));")
			amount = rs.Fields("SupplierTransaction_Amount").Value
			current = rs.Fields("Supplier_Current").Value
			days30 = rs.Fields("Supplier_30Days").Value
			days60 = rs.Fields("Supplier_60Days").Value
			days90 = rs.Fields("Supplier_90Days").Value
			days120 = rs.Fields("Supplier_120Days").Value
			'days150 = rs("Supplier_150Days")
			days150 = 0
			'MsgBox amount & " - " & current & " - " & days30 & " - " & days60 & " - " & days90 & " - " & days120 & " - " & days150
			
            Select Case CInt(cmbPeriod.SelectedIndex)
                Case 0
                    lField = "Supplier_Current"
                    current = current + amount

                Case 1
                    lField = "Supplier_30Days"
                    If amount < 0 Then
                        days30 = days30 + amount
                        If (days30 < 0) Then
                            amount = days30
                            days30 = 0
                        Else
                            amount = 0
                        End If
                    End If
                    current = current + amount

                Case 2
                    lField = "Supplier_60Days"
                    If amount < 0 Then
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

                Case 3
                    lField = "Supplier_90Days"
                    If amount < 0 Then
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

                Case 4
                    lField = "Supplier_120Days"
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

            End Select
			'cnnDB.Execute "UPDATE Supplier SET Supplier." & lField & " = [Supplier]![" & lField & "]+(" & lAmount & ") WHERE (((Supplier.SupplierID)=" & adoPrimaryRS("SupplierID") & "));"
			'MsgBox current & " - " & days30 & " - " & days60 & " - " & days90 & " - " & days120 & " - " & days150
			cnnDB.Execute("UPDATE Supplier SET Supplier.Supplier_Current = " & current & ", Supplier.Supplier_30Days = " & days30 & ", Supplier.Supplier_60Days = " & days60 & ", Supplier.Supplier_90Days = " & days90 & ", Supplier.Supplier_120Days = " & days120 & " WHERE (((Supplier.SupplierID)=" & rs.Fields("SupplierTransaction_SupplierID").Value & "));")
		End If
		
		If Val(txtSettlement.Text) <> 0 Then
			sql = "INSERT INTO SupplierTransaction ( SupplierTransaction_SupplierID, SupplierTransaction_PersonID, SupplierTransaction_TransactionTypeID, SupplierTransaction_MonthEndID, SupplierTransaction_MonthEndIDFor, SupplierTransaction_DayEndID, SupplierTransaction_ReferenceID, SupplierTransaction_Date, SupplierTransaction_Description, SupplierTransaction_Amount, SupplierTransaction_Reference ) "
			Select Case gSection
				Case sec_Payment
					lAmount = CDec(0 - CDec(Me.txtSettlement.Text))
					sql = sql & "SELECT " & adoPrimaryRS.Fields("SupplierID").Value & " AS supplier, " & gPersonID & " AS person, 8 AS transType, Company.Company_MonthEndID, " & Me.cmbPeriod.SelectedIndex & " AS monthFor, Company.Company_DayEndID, 0 as [referenceID], Now() AS [date], '" & Replace(Me.txtNotes.Text, "'", "''") & "' AS notes, " & lAmount & " AS amount, '" & Replace(Me.txtNarrative.Text, "'", "''") & "' AS reference FROM Company;"
				Case sec_Debit
					lAmount = CDec(Me.txtSettlement.Text)
					sql = sql & "SELECT " & adoPrimaryRS.Fields("SupplierID").Value & " AS supplier, " & gPersonID & " AS person, 8 AS transType, Company.Company_MonthEndID, " & Me.cmbPeriod.SelectedIndex & " AS monthFor, Company.Company_DayEndID, 0 as [referenceID], Now() AS [date], '" & Replace(Me.txtNotes.Text, "'", "''") & "' AS notes, " & lAmount & " AS amount, '" & Replace(Me.txtNarrative.Text, "'", "''") & "' AS reference FROM Company;"
				Case sec_Credit
					lAmount = CDec(0 - CDec(Me.txtSettlement.Text))
					sql = sql & "SELECT " & adoPrimaryRS.Fields("SupplierID").Value & " AS supplier, " & gPersonID & " AS person, 8 AS transType, Company.Company_MonthEndID, " & Me.cmbPeriod.SelectedIndex & " AS monthFor, Company.Company_DayEndID, 0 as [referenceID], Now() AS [date], '" & Replace(Me.txtNotes.Text, "'", "''") & "' AS notes, " & lAmount & " AS amount, '" & Replace(Me.txtNarrative.Text, "'", "''") & "' AS reference FROM Company;"
			End Select
			cnnDB.Execute(sql)
			
			rs = getRS("SELECT MAX(SupplierTransactionID) AS id From SupplierTransaction")
			If rs.BOF Or rs.EOF Then
			Else
				id = rs.Fields("id").Value
				cnnDB.Execute("UPDATE Supplier INNER JOIN SupplierTransaction ON Supplier.SupplierID = SupplierTransaction.SupplierTransaction_SupplierID SET Supplier.Supplier_Current = 0 WHERE (((SupplierTransaction.SupplierTransactionID)=" & id & ") AND ((Supplier.Supplier_Current) Is Null));")
				cnnDB.Execute("UPDATE Supplier INNER JOIN SupplierTransaction ON Supplier.SupplierID = SupplierTransaction.SupplierTransaction_SupplierID SET Supplier.Supplier_30Days = 0 WHERE (((SupplierTransaction.SupplierTransactionID)=" & id & ") AND ((Supplier.Supplier_30Days) Is Null));")
				cnnDB.Execute("UPDATE Supplier INNER JOIN SupplierTransaction ON Supplier.SupplierID = SupplierTransaction.SupplierTransaction_SupplierID SET Supplier.Supplier_60Days = 0 WHERE (((SupplierTransaction.SupplierTransactionID)=" & id & ") AND ((Supplier.Supplier_60Days) Is Null));")
				cnnDB.Execute("UPDATE Supplier INNER JOIN SupplierTransaction ON Supplier.SupplierID = SupplierTransaction.SupplierTransaction_SupplierID SET Supplier.Supplier_90Days = 0 WHERE (((SupplierTransaction.SupplierTransactionID)=" & id & ") AND ((Supplier.Supplier_90Days) Is Null));")
				cnnDB.Execute("UPDATE Supplier INNER JOIN SupplierTransaction ON Supplier.SupplierID = SupplierTransaction.SupplierTransaction_SupplierID SET Supplier.Supplier_120Days = 0 WHERE (((SupplierTransaction.SupplierTransactionID)=" & id & ") AND ((Supplier.Supplier_120Days) Is Null));")
				
				rs = getRS("SELECT SupplierTransaction.SupplierTransaction_SupplierID, SupplierTransaction.SupplierTransaction_Amount, Supplier.Supplier_Current, Supplier.Supplier_30Days, Supplier.Supplier_60Days, Supplier.Supplier_90Days, Supplier.Supplier_120Days FROM Supplier INNER JOIN SupplierTransaction ON Supplier.SupplierID = SupplierTransaction.SupplierTransaction_SupplierID Where (((SupplierTransaction.SupplierTransactionID) = " & id & "));")
				amount = rs.Fields("SupplierTransaction_Amount").Value
				current = rs.Fields("Supplier_Current").Value
				days30 = rs.Fields("Supplier_30Days").Value
				days60 = rs.Fields("Supplier_60Days").Value
				days90 = rs.Fields("Supplier_90Days").Value
				days120 = rs.Fields("Supplier_120Days").Value
				days150 = 0
				
                Select Case CInt(cmbPeriod.SelectedIndex)
                    Case 0
                        lField = "Supplier_Current"
                        current = current + amount

                    Case 1
                        lField = "Supplier_30Days"
                        If amount < 0 Then
                            days30 = days30 + amount
                            If (days30 < 0) Then
                                amount = days30
                                days30 = 0
                            Else
                                amount = 0
                            End If
                        End If
                        current = current + amount

                    Case 2
                        lField = "Supplier_60Days"
                        If amount < 0 Then
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

                    Case 3
                        lField = "Supplier_90Days"
                        If amount < 0 Then
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

                    Case 4
                        lField = "Supplier_120Days"
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

                End Select
				cnnDB.Execute("UPDATE Supplier SET Supplier.Supplier_Current = " & current & ", Supplier.Supplier_30Days = " & days30 & ", Supplier.Supplier_60Days = " & days60 & ", Supplier.Supplier_90Days = " & days90 & ", Supplier.Supplier_120Days = " & days120 & " WHERE (((Supplier.SupplierID)=" & rs.Fields("SupplierTransaction_SupplierID").Value & "));")
			End If
			
			
		End If
		cmdStatement_Click(cmdStatement, New System.EventArgs())
		Me.Close()
		
	End Sub
	
	Private Sub cmdProcess_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdProcess.Enter
		txtTotalAmount.Text = FormatNumber(CDec(txtAmount.Text) + CDec(txtSettlement.Text), 2)
		
	End Sub
	
	Private Sub cmdStatement_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStatement.Click
		report_SupplierStatement(adoPrimaryRS.Fields("SupplierID").Value)
    End Sub

    Private Sub frmSupplierTransaction_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtFields.AddRange(New TextBox() {_txtFields_2, _txtFields_6, _txtFields_7, _
                                         _txtFields_8, _txtFields_9})
        txtFloat.AddRange(New TextBox() {_txtFloat_13, _txtFloat_14, _txtFloat_15, _
                                        _txtFloat_16, _txtFloat_17})
        Dim tb As New TextBox
        For Each tb In txtFields
            AddHandler tb.Enter, AddressOf txtFields_Enter
        Next
        For Each tb In txtFloat
            AddHandler tb.Enter, AddressOf txtFloat_Enter
            AddHandler tb.KeyPress, AddressOf txtFloat_KeyPress
        Next
    End Sub
	
	'UPGRADE_WARNING: Event frmSupplierTransaction.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmSupplierTransaction_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        Dim cmdLast As New Button
        Dim cmdNext As New Button
        Dim lblStatus As New Label
		On Error Resume Next
		lblStatus.Width = pixelToTwips(Me.Width, True) - 1500
		cmdNext.Left = lblStatus.Width + 700
		cmdLast.Left = cmdNext.Left + 340
	End Sub
	
	Private Sub frmSupplierTransaction_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
	
	Private Sub frmSupplierTransaction_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
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
	
	
	Private Sub cmdCancel_Click()
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
			mbDataChanged = False
		End If
	End Sub
	
	'UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
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
    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Integer
        Dim n As New TextBox
        n = DirectCast(eventSender, TextBox)
        Index = GetIndexer(n, txtFields)
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
	
    Private Sub txtFloat_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Integer
        Dim n As New TextBox
        n = DirectCast(eventSender, TextBox)
        Index = GetIndexer(n, txtFloat)
        MyGotFocusNumeric(txtFloat(Index))
    End Sub
	
    Private Sub txtFloat_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'Dim Index As Short = txtFloat.GetIndex(eventSender)
        MyKeyPress(KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub txtFloat_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Integer
        Dim n As New TextBox
        n = DirectCast(eventSender, TextBox)
        Index = GetIndexer(n, txtFloat)
        MyLostFocus(txtFloat(Index), 2)
    End Sub
	
	Private Sub txtFloatNegative_MyGotFocus(ByRef Index As Short)
		'    MyGotFocusNumeric txtFloatNegative(Index)
	End Sub
	
	Private Sub txtFloatNegative_KeyPress(ByRef Index As Short, ByRef KeyAscii As Short)
		'    KeyPressNegative txtFloatNegative(Index), KeyAscii
	End Sub
	
	Private Sub txtFloatNegative_MyLostFocus(ByRef Index As Short)
		'    LostFocus txtFloatNegative(Index), 2
	End Sub
	
	Private Sub txtNarrative_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtNarrative.Enter
        MyGotFocus(txtNarrative)
	End Sub
	
	Private Sub txtNotes_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtNotes.Enter
        MyGotFocus(txtNotes)
	End Sub
	
	Private Sub txtAmount_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtAmount.Enter
        MyGotFocusNumeric(txtAmount)
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
	Private Sub txtSettlement_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSettlement.Enter
        MyGotFocusNumeric(txtSettlement)
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