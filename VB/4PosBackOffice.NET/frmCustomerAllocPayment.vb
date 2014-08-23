Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmCustomerAllocPayment
	Inherits System.Windows.Forms.Form
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim mbChangedByCode As Boolean
	Dim mvBookMark As Integer
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
	Dim gID As Integer
	
	Dim gMonthEnd As Short
	Dim gLoading As Boolean
	Dim bSelectPayment As Boolean

    Dim txtFields As New List(Of TextBox)
    Dim txtFloat As New List(Of TextBox)
    Dim chkFields As New List(Of CheckBox)

	Private Sub loadLanguage()
		
		'frmCustomerAllocPayment = No Code  [Payment Allocation]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmCustomerAllocPayment.Caption = rsLang("LanguageLayoutLnk_Description"): frmCustomerAllocPayment.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1188 'Allocate|Checked
		If rsLang.RecordCount Then cmdShowHistory.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdShowHistory.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1085 'Print|Checked
		If rsLang.RecordCount Then cmdInv.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdInv.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1282 'Statement|Checked
		If rsLang.RecordCount Then cmdStatement.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdStatement.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
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
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1294 'Terms|Checked
		If rsLang.RecordCount Then _lblLabels_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1296 '30 Days|Checked
		If rsLang.RecordCount Then _lblLabels_14.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_14.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1298 '90 Days|Checked
		If rsLang.RecordCount Then _lblLabels_16.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_16.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1300 '150 Days|Checked
		If rsLang.RecordCount Then _lblLabels_18.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_18.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lbl_7 = No Code                   [Payments]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lbl(17).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(17).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lbl(8) = No Code                   [Invoices - Unallocated]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lbl(8).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(8).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lbl(9) = No Code                   [Invoices - Allocated]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lbl(9).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(9).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdAllocateFull = No Code          [Allocate Full Payment]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdAllocateFull.Caption = rsLang("LanguageLayoutLnk_Description"): cmdAllocateFull.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdAllocate = No Code              [Allocate Partial]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdAllocate.Caption = rsLang("LanguageLayoutLnk_Description"): cmdAllocate.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmCustomerAllocPayment.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub loadData()
		Dim sql As String
		Dim cn As ADODB.Connection
		Dim rs As New ADODB.Recordset
        Dim x As Short
        Dim tmp As String
		'If openConnection() Then
		'    frmMain.lblPath.Caption = serverPath
		'    closeConnection
		'End If
		
		cn = openConnectionInstance()
		If cn Is Nothing Then
			Me.Close()
			Exit Sub
		Else
			
			sql = "SELECT Company.Company_MonthEndID FROM Company;"
			rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
			gMonthEnd = rs.Fields("Company_MonthEndID").Value
            cmbMonth.Items.Add(New LBI("This Month", gMonthEnd))
			
            For x = 2 To gMonthEnd
                tmp = (x - 1).ToString & " Months Ago"
                cmbMonth.Items.Add(New LBI(tmp, gMonthEnd - x + 1))
            Next
			cmbMonth.SelectedIndex = 0
			
            cmbPOS.Items.Add(New LBI("[All Point Of Sale]", 0))
            For x = 1 To 12
                tmp = "Point of Sale " & x.ToString
                cmbPOS.Items.Add(New LBI(tmp, x))
            Next x
			cmbPOS.SelectedIndex = 0
		End If
		
		cmdsearch_Click_Payment()
		cmdsearch_Click(cmdsearch, New System.EventArgs())
		cmdsearch_Click_Alloc()
		cmdAllocate.Focus()
	End Sub
	
    Private Sub cmdAllocate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim tempAmount As Decimal
        'On Error Resume Next
        Dim cn As ADODB.Connection
        Dim x As Short
        Dim databaseName As String
        Dim lID As Integer
        Dim rs As ADODB.Recordset
        Dim rsItems As ADODB.Recordset
        Dim sql As String
        Dim cAlloc As Decimal
        'Screen.MousePointer = vbHourglass

        If lvPayment.FocusedItem Is Nothing Then
            MsgBox("Select Payment to Allocate!")
            Exit Sub
        End If

        If lvTransaction.FocusedItem Is Nothing Then
            MsgBox("Select Invoice to be Allocate!")
            Exit Sub
        End If


        If (0 - CDbl(lvPayment.FocusedItem.SubItems(6).Text)) > 0 Then
            If MsgBox("Are you sure you wish to Allocate " & vbCrLf & vbCrLf & lvPayment.FocusedItem.SubItems(2).Text & " | " & lvPayment.FocusedItem.Text & " | " & lvPayment.FocusedItem.SubItems(1).Text & " | R " & lvPayment.FocusedItem.SubItems(6).Text & vbCrLf & vbCrLf & " TO " & vbCrLf & vbCrLf & lvTransaction.FocusedItem.SubItems(2).Text & " | " & lvTransaction.FocusedItem.Text & " | " & lvTransaction.FocusedItem.SubItems(1).Text & " | R " & lvTransaction.FocusedItem.SubItems(6).Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                tempAmount = 0
                tempAmount = frmCustomerAllocPaymentAmount.getAmount(CDec(lvPayment.FocusedItem.SubItems(6).Text))

                If CDec(tempAmount) = CDec(lvTransaction.FocusedItem.SubItems(6).Text) Then
                    tempAmount = CDec(tempAmount)
                ElseIf CDec(tempAmount) > CDec(lvTransaction.FocusedItem.SubItems(6).Text) Then
                    tempAmount = CDec(lvTransaction.FocusedItem.SubItems(6).Text)
                ElseIf CDec(tempAmount) < CDec(lvTransaction.FocusedItem.SubItems(6).Text) Then
                    tempAmount = CDec(tempAmount)
                End If

                sql = "INSERT INTO CustomerTransactionAlloc ( CustomerTransactionAlloc_CustomerID, CustomerTransactionAlloc_MainID, CustomerTransactionAlloc_ChildID, CustomerTransactionAlloc_Date, CustomerTransactionAlloc_Description, CustomerTransactionAlloc_Amount, CustomerTransactionAlloc_Reference, CustomerTransactionAlloc_PersonName )"
                'sql = sql & "SELECT " & adoPrimaryRS("CustomerID") & " AS Customer, " & Replace(Split(Me.lvPayment.SelectedItem.Key, "_")(0), "K", "") & " AS mID, " & Replace(Split(Me.lvTransaction.SelectedItem.Key, "_")(0), "K", "") & " AS cID, #" & Now() & "# AS [Datea], 'Allocations' AS Descs, " & CCur((0 - lvPayment.SelectedItem.SubItems(4))) & " AS amount, 'Allocation' AS reference, 'System' AS person FROM Company;"
                sql = sql & "SELECT " & adoPrimaryRS.Fields("CustomerID").Value & " AS Customer, " & Replace(Split(Me.lvPayment.FocusedItem.Name, "_")(0), "K", "") & " AS mID, " & Replace(Split(Me.lvTransaction.FocusedItem.Name, "_")(0), "K", "") & " AS cID, #" & Now & "# AS [Datea], 'Allocations' AS Descs, " & CDec(tempAmount) & " AS amount, 'Allocation' AS reference, 'System' AS person FROM Company;"
                cnnDB.Execute(sql)
                'cnnDB.Execute "UPDATE CustomerTransaction SET CustomerTransaction_Main = 0, CustomerTransaction_Child = 0, CustomerTransaction_Allocated = " & CCur((lvPayment.SelectedItem.SubItems(4))) & " WHERE (((CustomerTransaction.CustomerTransactionID)=" & Replace(Split(Me.lvPayment.SelectedItem.Key, "_")(0), "K", "") & "));"
                cnnDB.Execute("UPDATE CustomerTransaction SET CustomerTransaction_Main = 0, CustomerTransaction_Child = 0, CustomerTransaction_Allocated = CustomerTransaction_Allocated+" & CDec(0 - tempAmount) & " WHERE (((CustomerTransaction.CustomerTransactionID)=" & Replace(Split(Me.lvPayment.FocusedItem.Name, "_")(0), "K", "") & "));")
                'cnnDB.Execute "UPDATE CustomerTransaction SET CustomerTransaction_Main = " & Replace(Split(Me.lvPayment.SelectedItem.Key, "_")(0), "K", "") & ", CustomerTransaction_Child = 1, CustomerTransaction_Allocated = " & CCur((0 - lvPayment.SelectedItem.SubItems(4))) & " WHERE (((CustomerTransaction.CustomerTransactionID)=" & Replace(Split(Me.lvTransaction.SelectedItem.Key, "_")(0), "K", "") & "));"
                cnnDB.Execute("UPDATE CustomerTransaction SET CustomerTransaction_Main = " & Replace(Split(Me.lvPayment.FocusedItem.Name, "_")(0), "K", "") & ", CustomerTransaction_Child = 1, CustomerTransaction_Allocated = CustomerTransaction_Allocated+" & CDec(tempAmount) & " WHERE (((CustomerTransaction.CustomerTransactionID)=" & Replace(Split(Me.lvTransaction.FocusedItem.Name, "_")(0), "K", "") & "));")
            End If
        Else
            MsgBox("Insufficient funds.")
            Exit Sub
        End If

        cmdsearch_Click_Payment()
        System.Windows.Forms.Application.DoEvents()
        cmdsearch_Click(cmdSearch, New System.EventArgs())
        System.Windows.Forms.Application.DoEvents()
        cmdsearch_Click_Alloc()
        System.Windows.Forms.Application.DoEvents()
        cmdAllocate.Focus()

        'If MsgBox("Are you sure you wish to Allocate " & vbCrLf & vbCrLf & lvPayment.SelectedItem.SubItems(2) & " | " & lvPayment.SelectedItem & " | " & lvPayment.SelectedItem.SubItems(1) & " | R " & lvPayment.SelectedItem.SubItems(4) & vbCrLf & vbCrLf & " TO " & vbCrLf & vbCrLf & lvTransaction.SelectedItem.SubItems(2) & " | " & lvTransaction.SelectedItem & " | " & lvTransaction.SelectedItem.SubItems(1) & " | R " & lvTransaction.SelectedItem.SubItems(3), vbYesNo) = vbYes Then
        '    'aC = InputBox("Please enter the amount you with to Allocate.", "Please enter the amount you with to Allocate.", FormatNumber((0 - lvPayment.SelectedItem.SubItems(4)), 2))
        '
        '
        '    If IsNumeric(aC) Then
        '        cAlloc = aC
        '    Else
        '        MsgBox "Enter the correct amount."
        '    End If
        '    If cAlloc > 0 Then
        '
        '    Else
        '        MsgBox "Enter the correct amount."
        '    End If
        'End If
        cmdsearch_Click_Payment()
        System.Windows.Forms.Application.DoEvents()
        cmdsearch_Click(cmdSearch, New System.EventArgs())
        System.Windows.Forms.Application.DoEvents()
        cmdsearch_Click_Alloc()
        System.Windows.Forms.Application.DoEvents()
        cmdAllocate.Focus()
    End Sub
	
    Private Sub cmdAllocateFull_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim tempAmount As Object
        'On Error Resume Next
        Dim cn As ADODB.Connection
        Dim x As Short
        Dim databaseName As String
        Dim lID As Integer
        Dim rs As ADODB.Recordset
        Dim rsItems As ADODB.Recordset
        Dim sql As String
        Dim cAlloc As Decimal
        'Screen.MousePointer = vbHourglass

        If lvPayment.FocusedItem Is Nothing Then
            MsgBox("Select Payment to Allocate!")
            Exit Sub
        End If

        If lvTransaction.FocusedItem Is Nothing Then
            MsgBox("Select Invoice to be Allocated!")
            Exit Sub
        End If

        'If Split(Me.lvTransaction.SelectedItem.Key, "_")(2) = 0 Then MsgBox "There is no Sale document attached!", vbInformation: Screen.MousePointer = vbNormal: Exit Sub
        'lID = Split(Me.lvTransaction.SelectedItem.Key, "_")(2)
        tempAmount = 0
        If CDec(0 - CDbl(lvPayment.FocusedItem.SubItems(6).Text)) = CDec(lvTransaction.FocusedItem.SubItems(6).Text) Then
            tempAmount = CDec(0 - CDbl(lvPayment.FocusedItem.SubItems(6).Text))
        ElseIf CDec(0 - CDbl(lvPayment.FocusedItem.SubItems(6).Text)) > CDec(lvTransaction.FocusedItem.SubItems(6).Text) Then
            tempAmount = CDec(lvTransaction.FocusedItem.SubItems(6).Text)
        ElseIf CDec(0 - CDbl(lvPayment.FocusedItem.SubItems(6).Text)) < CDec(lvTransaction.FocusedItem.SubItems(6).Text) Then
            tempAmount = CDec(0 - CDbl(lvPayment.FocusedItem.SubItems(6).Text))
        End If

        If (0 - CDbl(lvPayment.FocusedItem.SubItems(6).Text)) > 0 Then
            'If (0 - lvPayment.SelectedItem.SubItems(6)) >= lvTransaction.SelectedItem.SubItems(6) Then
            If MsgBox("Are you sure you wish to Allocate " & vbCrLf & vbCrLf & lvPayment.FocusedItem.SubItems(2).Text & " | " & lvPayment.FocusedItem.Text & " | " & lvPayment.FocusedItem.SubItems(1).Text & " | R " & lvPayment.FocusedItem.SubItems(6).Text & vbCrLf & vbCrLf & " TO " & vbCrLf & vbCrLf & lvTransaction.FocusedItem.SubItems(2).Text & " | " & lvTransaction.FocusedItem.Text & " | " & lvTransaction.FocusedItem.SubItems(1).Text & " | R " & lvTransaction.FocusedItem.SubItems(6).Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                sql = "INSERT INTO CustomerTransactionAlloc ( CustomerTransactionAlloc_CustomerID, CustomerTransactionAlloc_MainID, CustomerTransactionAlloc_ChildID, CustomerTransactionAlloc_Date, CustomerTransactionAlloc_Description, CustomerTransactionAlloc_Amount, CustomerTransactionAlloc_Reference, CustomerTransactionAlloc_PersonName )"
                'sql = sql & "SELECT " & adoPrimaryRS("CustomerID") & " AS Customer, " & Replace(Split(Me.lvPayment.SelectedItem.Key, "_")(0), "K", "") & " AS mID, " & Replace(Split(Me.lvTransaction.SelectedItem.Key, "_")(0), "K", "") & " AS cID, #" & Now() & "# AS [Datea], 'Allocations' AS Descs, " & CCur((0 - lvPayment.SelectedItem.SubItems(4))) & " AS amount, 'Allocation' AS reference, 'System' AS person FROM Company;"
                sql = sql & "SELECT " & adoPrimaryRS.Fields("CustomerID").Value & " AS Customer, " & Replace(Split(Me.lvPayment.FocusedItem.Name, "_")(0), "K", "") & " AS mID, " & Replace(Split(Me.lvTransaction.FocusedItem.Name, "_")(0), "K", "") & " AS cID, #" & Now & "# AS [Datea], 'Allocations' AS Descs, " & CDec(tempAmount) & " AS amount, 'Allocation' AS reference, 'System' AS person FROM Company;"
                cnnDB.Execute(sql)
                'cnnDB.Execute "UPDATE CustomerTransaction SET CustomerTransaction_Main = 0, CustomerTransaction_Child = 0, CustomerTransaction_Allocated = " & CCur((lvPayment.SelectedItem.SubItems(4))) & " WHERE (((CustomerTransaction.CustomerTransactionID)=" & Replace(Split(Me.lvPayment.SelectedItem.Key, "_")(0), "K", "") & "));"
                cnnDB.Execute("UPDATE CustomerTransaction SET CustomerTransaction_Main = 0, CustomerTransaction_Child = 0, CustomerTransaction_Allocated = CustomerTransaction_Allocated+" & CDec(0 - tempAmount) & " WHERE (((CustomerTransaction.CustomerTransactionID)=" & Replace(Split(Me.lvPayment.FocusedItem.Name, "_")(0), "K", "") & "));")
                'cnnDB.Execute "UPDATE CustomerTransaction SET CustomerTransaction_Main = " & Replace(Split(Me.lvPayment.SelectedItem.Key, "_")(0), "K", "") & ", CustomerTransaction_Child = 1, CustomerTransaction_Allocated = " & CCur((0 - lvPayment.SelectedItem.SubItems(4))) & " WHERE (((CustomerTransaction.CustomerTransactionID)=" & Replace(Split(Me.lvTransaction.SelectedItem.Key, "_")(0), "K", "") & "));"
                cnnDB.Execute("UPDATE CustomerTransaction SET CustomerTransaction_Main = " & Replace(Split(Me.lvPayment.FocusedItem.Name, "_")(0), "K", "") & ", CustomerTransaction_Child = 1, CustomerTransaction_Allocated = CustomerTransaction_Allocated+" & CDec(tempAmount) & " WHERE (((CustomerTransaction.CustomerTransactionID)=" & Replace(Split(Me.lvTransaction.FocusedItem.Name, "_")(0), "K", "") & "));")
            End If
        Else
            MsgBox("Insufficient funds.")
            Exit Sub
        End If

        cmdsearch_Click_Payment()
        System.Windows.Forms.Application.DoEvents()
        cmdsearch_Click(cmdSearch, New System.EventArgs())
        System.Windows.Forms.Application.DoEvents()
        cmdsearch_Click_Alloc()
        System.Windows.Forms.Application.DoEvents()
        cmdAllocate.Focus()

        cmdsearch_Click_Payment()
        System.Windows.Forms.Application.DoEvents()
        cmdsearch_Click(cmdSearch, New System.EventArgs())
        System.Windows.Forms.Application.DoEvents()
        cmdsearch_Click_Alloc()
        System.Windows.Forms.Application.DoEvents()
        cmdAllocate.Focus()
    End Sub
	
    Private Sub cmdInv_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim personID As Integer
        Dim posID As Integer
        Dim lArray As String()
        Dim lAddress As String

        'On Error Resume Next
        Dim cn As ADODB.Connection
        Dim x As Short
        Dim databaseName As String
        Dim lID As Integer
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim rs As ADODB.Recordset
        Dim rsItems As ADODB.Recordset
        Dim sql As String
        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        If lvTransaction.FocusedItem Is Nothing Then Exit Sub
        'lID = Mid(Split(Me.lvTransaction.SelectedItem.Key, "_")(0), 2)
        If CDbl(Split(Me.lvTransaction.FocusedItem.Name, "_")(2)) = 0 Then
            MsgBox("There is no Sale document attached!", MsgBoxStyle.Information)
            System.Windows.Forms.Cursor.Current = Cursors.Default : Exit Sub
        End If
        lID = CInt(Split(Me.lvTransaction.FocusedItem.Name, "_")(2))
        'If openConnection() Then
        '    frmMain.lblPath.Caption = serverPath
        '    closeConnection
        'End If
        'Set cn = openConnectionInstance()
        'lMonth = cmbMonth.ItemData(cmbMonth.ListIndex)
        'Dim lLineitem As lineitem
        'If lMonth = gMonthEnd Then
        '    databaseName = ""
        'Else
        '    databaseName = "Month" & lMonth & ".mdb"
        'End If
        databaseName = Split(Me.lvTransaction.FocusedItem.Name, "_")(1)

        cn = openConnectionInstance(databaseName)
        If cn Is Nothing Then
            Exit Sub
        End If

        Dim lTransaction As New transaction
        Dim lLineitem As lineItem
        Dim lCustomer As New customer
        Dim lSpecial As New transactionSpecial
        If CDbl(Split(Me.lvTransaction.FocusedItem.Name, "_")(3)) = 2 Then
            'sale
            'Dim Report As New cryReceipt
            'Set Report = New cryReceipt

            rs = New ADODB.Recordset
            sql = "SELECT Sale.* From Sale WHERE (((SaleID)=" & lID & "));"
            rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
            If rs.RecordCount Then

                lTransaction.cashierID = rs.Fields("Sale_PersonID").Value
                lTransaction.channelID = rs.Fields("Sale_ChannelID").Value
                lTransaction.managerID = rs.Fields("Sale_ManagerID").Value
                lTransaction.paymentDiscount = rs.Fields("Sale_Discount").Value
                lTransaction.paymentSlip = rs.Fields("Sale_Slip").Value
                lTransaction.paymentSubTotal = rs.Fields("Sale_SubTotal").Value
                lTransaction.paymentTender = rs.Fields("Sale_Tender").Value
                lTransaction.paymentTotal = rs.Fields("Sale_Total").Value
                lTransaction.paymentType = rs.Fields("Sale_PaymentType").Value
                lTransaction.posID = rs.Fields("Sale_POSID").Value
                lTransaction.transactionDate = rs.Fields("Sale_DatePOS").Value
                lTransaction.transactionID = rs.Fields("Sale_Reference").Value & ""
                lTransaction.transactionType = "Sale"
                'If prPrevSerial_p = True Then strSerial = rs("Sale_Serialref")
                rs.Close()

                rs = getRS("SELECT * FROM Company")
                lTransaction.companyName = rs.Fields("Company_Name").Value 'gParameters.companyName
                lTransaction.footer = " " 'gParameters.footer & ""
                lTransaction.heading1 = rs.Fields("Company_PhysicalAddress").Value 'gParameters.heading1 & ""
                lTransaction.heading2 = " " 'gParameters.heading2 & ""
                lTransaction.heading3 = " " 'gParameters.heading3 & ""
                lTransaction.taxNumber = rs.Fields("Company_TaxNumber").Value 'gParameters.taxNumber & ""
                rs.Close()


                sql = "SELECT [Person_FirstName] & ' ' & [Person_LastName] AS personName From Person WHERE (((PersonID)=" & lTransaction.cashierID & "));"
                rs = getRS(sql)
                'rs.Open sql, cn, adOpenStatic, adLockReadOnly, adCmdText
                If rs.RecordCount Then
                    lTransaction.cashierName = rs.Fields("personName").Value & ""
                End If
                rs.Close()

                sql = "SELECT [Person_FirstName] & ' ' & [Person_LastName] AS personName From Person WHERE (((PersonID)=" & lTransaction.managerID & "));"
                rs = getRS(sql)
                'rs.Open sql, cn, adOpenStatic, adLockReadOnly, adCmdText
                If rs.RecordCount Then
                    lTransaction.managerName = rs.Fields("personName").Value & ""
                End If
                rs.Close()

                sql = "SELECT POS_Name From POS WHERE (((POS.POSID)=" & lTransaction.posID & "));"
                rs = getRS(sql)
                'rs.Open sql, cn, adOpenStatic, adLockReadOnly, adCmdText
                If rs.RecordCount Then
                    lTransaction.posName = rs.Fields("POS_Name").Value & ""
                End If
                rs.Close()

                'sql = "SELECT SaleItem.*, StockItem.StockItem_Name AS longName, StockItem.StockItem_ReceiptName AS receiptName, Catalogue.Catalogue_Barcode AS code,'Sale' as saleType FROM (StockItem INNER JOIN SaleItem ON StockItem.StockItemID = SaleItem.SaleItem_StockItemID) INNER JOIN Catalogue ON (Catalogue.Catalogue_Quantity = SaleItem.SaleItem_ShrinkQuantity) AND (SaleItem.SaleItem_StockItemID = Catalogue.Catalogue_StockItemID) WHERE (((SaleItem.SaleItem_DepositType)=0) AND ((SaleItem.SaleItem_SaleID)=" & lID & "))"
                'sql = sql & " UNION "
                'sql = sql & "SELECT SaleItem.*, Deposit.Deposit_Name AS longName, Deposit.Deposit_ReceiptName AS receiptName, Deposit.Deposit_Key AS code,'Deposit' as saleType FROM Deposit INNER JOIN SaleItem ON Deposit.DepositID = SaleItem.SaleItem_StockItemID WHERE (((SaleItem.SaleItem_DepositType)<>0) AND ((SaleItem.SaleItem_SaleID)=" & lID & "));"
                sql = "SELECT SaleItem.*, 'Sale' AS saleType From SaleItem Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_SaleID) = " & lID & "))"
                sql = sql & " UNION "
                sql = sql & "SELECT SaleItem.*, 'Deposit' AS saleType From SaleItem WHERE (((SaleItem.SaleItem_DepositType)<>0) AND ((SaleItem.SaleItem_SaleID)=" & lID & "));"
                rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
                Do Until rs.EOF
                    lLineitem = New lineItem
                    lLineitem.build = 0
                    lLineitem.depositType = rs.Fields("SaleItem_DepositType").Value
                    lLineitem.id = rs.Fields("SaleItem_StockItemID").Value
                    lLineitem.lineNo = rs.Fields("SaleItem_LineNo").Value
                    lLineitem.originalPrice = rs.Fields("SaleItem_PriceOriginal").Value
                    lLineitem.price = rs.Fields("SaleItem_Price").Value
                    lLineitem.quantity = rs.Fields("SaleItem_Quantity").Value
                    lLineitem.reversal = rs.Fields("SaleItem_Reversal").Value
                    lLineitem.revoke = rs.Fields("SaleItem_Revoke").Value
                    lLineitem.setBuild = rs.Fields("SaleItem_SetID").Value
                    lLineitem.shrink = rs.Fields("SaleItem_ShrinkQuantity").Value
                    lLineitem.vat = rs.Fields("SaleItem_Vat").Value
                    lLineitem.transactionType = rs.Fields("SaleType").Value & ""
                    'lLineitem.code = rs("Code") & ""
                    Select Case lLineitem.depositType
                        Case 0
                            sql = "SELECT StockItem.StockItem_Name AS longName, StockItem.StockItem_ReceiptName AS receiptName From StockItem WHERE (((StockItemID)=" & rs.Fields("SaleItem_StockItemID").Value & "));"
                            rsItems = getRS(sql)
                            If rsItems.RecordCount Then
                                lLineitem.name = rs.Fields("SaleItem_ShrinkQuantity").Value & " x " & rsItems.Fields("longName").Value
                                lLineitem.receiptName = rs.Fields("SaleItem_ShrinkQuantity").Value & "x" & rsItems.Fields("receiptName").Value
                            End If
                            rsItems.Close()
                            sql = "SELECT Catalogue.Catalogue_Barcode AS code FROM Catalogue WHERE (Catalogue.Catalogue_Quantity = " & rs.Fields("SaleItem_ShrinkQuantity").Value & ") AND (Catalogue.Catalogue_StockItemID = " & rs.Fields("SaleItem_StockItemID").Value & ");"
                            rsItems = getRS(sql)
                            If rsItems.RecordCount Then
                                lLineitem.code = rsItems.Fields("Code").Value & ""
                            End If
                            rsItems.Close()
                        Case 1
                            sql = "SELECT Deposit.Deposit_Name AS longName, Deposit.Deposit_ReceiptName AS receiptName, Deposit.Deposit_Key AS code From Deposit WHERE (((DepositID)=" & rs.Fields("SaleItem_StockItemID").Value & "));"
                            rsItems = getRS(sql)
                            If rsItems.RecordCount Then
                                lLineitem.name = rs.Fields("longName").Value & "-Unit"
                                lLineitem.receiptName = rs.Fields("receiptName").Value & "(U)"
                                lLineitem.code = rsItems.Fields("Code").Value & ""
                            End If
                            rsItems.Close()
                        Case 2
                            sql = "SELECT Deposit.Deposit_Name AS longName, Deposit.Deposit_ReceiptName AS receiptName, Deposit.Deposit_Key AS code From Deposit WHERE (((DepositID)=" & rs.Fields("SaleItem_StockItemID").Value & "));"
                            rsItems = getRS(sql)
                            If rsItems.RecordCount Then
                                lLineitem.name = rs.Fields("longName").Value & "-Empty Crate"
                                lLineitem.receiptName = rs.Fields("receiptName").Value & "(E)"
                                lLineitem.code = rsItems.Fields("Code").Value & ""
                            End If
                            rsItems.Close()
                        Case 3
                            sql = "SELECT Deposit.Deposit_Name AS longName, Deposit.Deposit_ReceiptName AS receiptName, Deposit.Deposit_Key AS code From Deposit WHERE (((DepositID)=" & rs.Fields("SaleItem_StockItemID").Value & "));"
                            rsItems = getRS(sql)
                            If rsItems.RecordCount Then
                                lLineitem.name = rs.Fields("longName").Value & "-Full Case"
                                lLineitem.receiptName = rs.Fields("receiptName").Value & "(F)"
                                lLineitem.code = rsItems.Fields("Code").Value & ""
                            End If
                            rsItems.Close()
                    End Select
                    lTransaction.lineItems.Add(lLineitem)
                    rs.MoveNext()
                Loop
                rs.Close()

                sql = "SELECT Customer.*, CustomerTransaction.* FROM (CustomerTransaction INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) INNER JOIN Customer ON CustomerTransaction.CustomerTransaction_CustomerID = Customer.CustomerID WHERE (((Sale.SaleID)=" & lID & "));"
                rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
                If rs.RecordCount Then
                    lCustomer.channelID = lTransaction.channelID
                    lCustomer.creditLimit = rs.Fields("Customer_ChannelID").Value
                    lCustomer.department = rs.Fields("Customer_DepartmentName").Value & ""
                    lCustomer.fax = rs.Fields("Customer_Fax").Value & ""
                    lCustomer.Key = rs.Fields("CustomerID").Value
                    lCustomer.name = rs.Fields("Customer_InvoiceName").Value & ""
                    lCustomer.outstanding = 0
                    lCustomer.person = rs.Fields("Customer_FirstName").Value & " " & rs.Fields("Customer_Surname").Value
                    lCustomer.physical = rs.Fields("Customer_PhysicalAddress").Value & ""
                    lCustomer.postal = rs.Fields("Customer_PostalAddress").Value & ""
                    lCustomer.signed_Renamed = rs.Fields("CustomerTransaction_PersonName").Value
                    lCustomer.telephone = rs.Fields("Customer_Telephone").Value & ""
                    lCustomer.terms = CShort(rs.Fields("Customer_Terms").Value & "")
                    lCustomer.tax = rs.Fields("Customer_VatNumber").Value & ""
                    If rs.Fields("CustomerTransaction_TransactionTypeID").Value = 3 Then
                        lTransaction.transactionType = "Payment"
                        lTransaction.paymentDiscount = 0
                    End If
                    lTransaction.customer_Renamed = lCustomer
                End If
                rs.Close()
                sql = "SELECT Consignment.* FROM Consignment INNER JOIN Sale ON Consignment.Consignment_SaleID = Sale.SaleID WHERE (((Sale.SaleID)=" & lID & "));"
                rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
                If rs.BOF And rs.EOF Then
                Else
                    lSpecial.address = rs.Fields("Consignment_Address").Value
                    lSpecial.mobile = rs.Fields("Consignment_Mobile").Value
                    lSpecial.name = rs.Fields("Consignment_Name").Value
                    lSpecial.quote = 0
                    lSpecial.saleID = lID
                    lSpecial.telephone = rs.Fields("Consignment_Number").Value
                    lSpecial.transactionType = "Consignment"
                    lTransaction.transactionSpecial_Renamed = lSpecial
                End If
                rs.Close()

                sql = "SELECT Consignment.* FROM Consignment INNER JOIN Sale ON Consignment.Consignment_CompleteSaleID = Sale.SaleID WHERE (((Sale.SaleID)=" & lID & "));"
                rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
                If rs.BOF And rs.EOF Then
                Else
                    lSpecial.address = rs.Fields("Consignment_Address").Value
                    lSpecial.mobile = rs.Fields("Consignment_Mobile").Value
                    lSpecial.name = rs.Fields("Consignment_Name").Value
                    lSpecial.quote = 0
                    lSpecial.saleID = lID
                    lSpecial.telephone = rs.Fields("Consignment_Number").Value
                    lSpecial.transactionType = "Consignment Complete"
                    lTransaction.transactionSpecial_Renamed = lSpecial
                End If

                printTransactionA4(lTransaction)
            End If

        ElseIf CDbl(Split(Me.lvTransaction.FocusedItem.Name, "_")(3)) = 3 Then
            'payment
            'Dim Report As New cryPayment
            Report.Load("cryPayment.rpt")
            rs = getRS("SELECT * FROM Company")
            Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
            If IsDBNull(rs.Fields("Company_PhysicalAddress").Value) Then
            Else
                lAddress = Replace(rs.Fields("Company_PhysicalAddress").Value, vbCrLf, ", ")
                If VB.Right(lAddress, 2) = ", " Then
                    lAddress = VB.Left(lAddress, Len(lAddress) - 2)
                End If
            End If
            Report.SetParameterValue("txtCompanyDetails1", lAddress)
            If IsDBNull(rs.Fields("Company_Telephone").Value) Then
            Else
                Report.SetParameterValue("txtCompanyDetails2", rs.Fields("Company_Telephone"))
            End If
            If IsDBNull(rs.Fields("Company_TaxNumber").Value) Then
            Else
                Report.SetParameterValue("txtCompanyDetails4", "TAX NO :" & rs.Fields("Company_TaxNumber").Value)
            End If
            'If lTransaction.heading2 <> "" Then
            '    Report.txtCompanyDetails2.SetText lTransaction.heading2
            '    If lTransaction.heading3 <> "" Then
            '        Report.txtCompanyDetails3.SetText lTransaction.heading3
            '
            '    Else
            '        If lTransaction.taxNumber <> "" Then
            '            Report.txtCompanyDetails4.SetText "TAX NO :" & lTransaction.taxNumber
            '        End If
            '    End If
            'Else
            '    If lTransaction.heading3 <> "" Then
            '        Report.txtCompanyDetails2.SetText lTransaction.heading3
            '    Else
            '        If lTransaction.taxNumber <> "" Then
            '            Report.txtCompanyDetails2.SetText "TAX NO :" & lTransaction.taxNumber
            '        End If
            '    End If
            'End If
            rs.Close()
            Report.SetParameterValue("txtCustomer", _txtFields_2.Text)
            If _txtFields_6.Text <> "" Then
                lArray = Split(_txtFields_6.Text, vbCrLf)
                Report.SetParameterValue("txtCustAddress1", lArray(0))
                If UBound(lArray) >= 1 Then Report.SetParameterValue("txtCustAddress2", lArray(1))
                If UBound(lArray) >= 2 Then Report.SetParameterValue("txtCustAddress3", lArray(2))
                If UBound(lArray) >= 3 Then Report.SetParameterValue("txtCustAddress4", lArray(3))

            End If
            If _txtFields_0.Text <> "" Then Report.SetParameterValue("txtCustAddress5", "TAX NO: " & _txtFields_0.Text)

            'If LCase(databaseName) = "pricing.mdb" Then
            '    sql = "SELECT Sale.SaleID, POS.POS_Name, Person.Person_FirstName, Person.Person_LastName, Sale.Sale_Date, Sale.Sale_DatePOS, Sale.Sale_Reference, Sale.Sale_Total, Sale.Sale_Tender FROM (Sale INNER JOIN POS ON Sale.Sale_PosID = POS.POSID) INNER JOIN Person ON Sale.Sale_PersonID = Person.PersonID WHERE (((Sale.SaleID)=" & lID & "));"
            'Else
            '    sql = "SELECT Sale.SaleID, POS.POS_Name, M_Person.Person_FirstName, M_Person.Person_LastName, Sale.Sale_Date, Sale.Sale_DatePOS, Sale.Sale_Reference, Sale.Sale_Total, Sale.Sale_Tender FROM (Sale INNER JOIN POS ON Sale.Sale_PosID = POS.POSID) INNER JOIN M_Person ON Sale.Sale_PersonID = M_Person.PersonID WHERE (((Sale.SaleID)=" & lID & "));"
            'End If
            'sql = "SELECT Sale.SaleID, POS.POS_Name, Person.Person_FirstName, Person.Person_LastName, Sale.Sale_Date, Sale.Sale_DatePOS, Sale.Sale_Reference, Sale.Sale_Total, Sale.Sale_Tender FROM (Sale INNER JOIN POS ON Sale.Sale_PosID = POS.POSID) INNER JOIN Person ON Sale.Sale_PersonID = Person.PersonID WHERE (((Sale.SaleID)=" & lID & "));"
            sql = "SELECT Sale.* From Sale WHERE (((SaleID)=" & lID & "));"
            rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
            If rs.RecordCount Then

                posID = rs.Fields("Sale_PosID").Value
                personID = rs.Fields("Sale_PersonID").Value
                Report.SetParameterValue("txtInvoiceNumber", rs.Fields("Sale_Reference"))
                Report.SetParameterValue("txtInvoiceDate", Format(rs.Fields("Sale_DatePOS").Value, "dd mmm yyyy hh:mm"))
                'Report.txtPOS.SetText rs("POS_Name")
                'Report.txtCashier.SetText rs("Person_FirstName") & rs("Person_LastName")
                Report.SetParameterValue("txtAmount", FormatNumber(rs.Fields("Sale_Total").Value, 2))
                Report.SetParameterValue("txtChange", FormatNumber(rs.Fields("Sale_Tender").Value - rs.Fields("Sale_Total").Value, 2)) ' lTransaction.paymentTotal - lTransaction.paymentTender, 2)
                Report.SetParameterValue("txtTender", FormatNumber(rs.Fields("Sale_Tender").Value, 2)) '  lTransaction.paymentTender, 2)
                'Report.txtPaidBy.SetText lTransaction.customer.signed
                Report.ReportDefinition.Sections("txtPaidBy").SectionFormat.EnableSuppress = True
                rs.Close()

                sql = "SELECT [Person_FirstName] & ' ' & [Person_LastName] AS personName From Person WHERE (((PersonID)=" & personID & "));"
                rs = getRS(sql)
                If rs.RecordCount Then
                    Report.SetParameterValue("txtCashier", rs.Fields("personName").Value & "")
                End If
                rs.Close()

                sql = "SELECT POS_Name From POS WHERE (((POS.POSID)=" & posID & "));"
                rs = getRS(sql)
                If rs.RecordCount Then
                    Report.SetParameterValue("txtPOS", rs.Fields("POS_Name").Value & "")
                End If
                rs.Close()


                sql = "SELECT CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_ReferenceID From CustomerTransaction WHERE (((CustomerTransaction.CustomerTransaction_TransactionTypeID)=8) AND ((CustomerTransaction.CustomerTransaction_ReferenceID)=" & lID & "));"
                Debug.Print(sql)
                rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
                If rs.RecordCount Then
                    Report.SetParameterValue("txtSettlement", FormatNumber(rs.Fields("CustomerTransaction_Amount").Value, 2))
                Else
                    Report.SetParameterValue("txtSettlement", FormatNumber("0.00", 2))
                End If

                frmReportShow.Text = "Customer Statement"
                frmReportShow.CRViewer1.ReportSource = Report
                frmReportShow.mReport = Report : frmReportShow.sMode = "0"
                frmReportShow.CRViewer1.Refresh()
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                frmReportShow.ShowDialog()
            Else
                ReportNone.Load("cryNoRecords.rpt")
                ReportNone.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
                ReportNone.SetParameterValue("txtTitle", "Customer Statement")
                'UPGRADE_WARNING: Couldn't resolve default property of object ReportNone.txtTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
                frmReportShow.CRViewer1.ReportSource = ReportNone
                frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
                frmReportShow.CRViewer1.Refresh()
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                frmReportShow.ShowDialog()
                Exit Sub
            End If

        End If
    End Sub
	
	Private Sub cmdsearch_Click_AllocByID(ByRef PId As Integer)
        Dim prPrevSerial_p As Boolean
		Dim x As Integer
		Dim sql As String
		Dim databaseName As String
		Dim y As Short
		Dim lMonth As Short
		Dim cn As ADODB.Connection
		Dim rs As New ADODB.Recordset
		
		bSelectPayment = True
		If gLoading Then Exit Sub
		gLoading = True
		Cursor = System.Windows.Forms.Cursors.WaitCursor
		System.Windows.Forms.Application.DoEvents()
        lMonth = CShort(cmbMonth.SelectedIndex)
		If lMonth = gMonthEnd Then
			databaseName = "pricing.mdb"
		Else
			databaseName = "Month" & lMonth & ".mdb"
		End If
		'If openConnection() Then
		'    frmMain.lblPath.Caption = serverPath
		'    closeConnection
		'End If
		
		cn = openConnectionInstance(databaseName)
		If cn Is Nothing Then
			Exit Sub
		End If
		Dim lString As String
		Dim lCustomerString As String
		Dim lStockString As String
		Dim lPosString As String
		If Me.cmbPOS.SelectedIndex Then lPosString = " AND (Sale_PosID=" & cmbPOS.SelectedIndex & ")"
		lString = Trim(txtCustomer.Text)
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		
		'If lString <> "" Then
		'lString = "(Customer_InvoiceName LIKE '%" & Replace(lString, " ", "%' AND Customer_InvoiceName LIKE '%") & "%')"
		lString = "(CustomerID = " & adoPrimaryRS.Fields("CustomerID").Value & ")"
		'Else
		'    lString = ""
		'End If
		lCustomerString = lString
		If lCustomerString <> "" Then lCustomerString = " AND (" & lCustomerString & ") "
		
		
		'Cater for one at a time
		If Trim(Me.txtStock.Text) <> "" Then
			y = 1
			lString = Trim(Me.txtStock.Text)
			lString = Replace(lString, "  ", " ")
			lString = Replace(lString, "  ", " ")
			lString = Replace(lString, "  ", " ")
			lString = Replace(lString, "  ", " ")
			lString = Replace(lString, "  ", " ")
			lString = Replace(lString, "  ", " ")
		End If
		If Trim(Me.txtSerial.Text) <> "" Then
			prPrevSerial_p = True
			y = 2
			lString = Trim(Me.txtSerial.Text)
			lString = Replace(lString, "  ", " ")
			lString = Replace(lString, "  ", " ")
			lString = Replace(lString, "  ", " ")
			lString = Replace(lString, "  ", " ")
			lString = Replace(lString, "  ", " ")
			lString = Replace(lString, "  ", " ")
		End If
		
		
		If lString <> "" Then
			'By StockItem........
			If y = 1 Then lString = "(StockItem_Name LIKE '%" & Replace(lString, " ", "%' AND StockItem_Name LIKE '%") & "%')"
			
			'By Serial Number......
			If y = 2 Then lString = "(Sale.Sale_Serialref LIKE '" & Replace(lString, " ", "%' AND Sale.Sale_Serialref LIKE '%") & "%')"
		Else
			lString = ""
		End If
		
		lStockString = lString
		If lStockString <> "" Then lStockString = " AND (" & lStockString & ") AND (SaleItem.SaleItem_DepositType=0)"
		
		If lCustomerString = "" Then
			If lStockString = "" Then
				sql = "SELECT DISTINCT Sale.Sale_Reference, Sale.SaleID, Sale.Sale_PosID, Sale.Sale_DatePOS, Sale.Sale_Total, Sale.Sale_Tender, Sale.Sale_PaymentType From Sale Where ((Sale.Sale_PaymentType > 0) " & lPosString & " )ORDER BY Sale.SaleID DESC;"
			Else
				'By StockItem........
				If y = 1 Then sql = "SELECT DISTINCT Sale.Sale_Reference, Sale.SaleID, Sale.Sale_PosID, Sale.Sale_DatePOS, Sale.Sale_Total, Sale.Sale_Tender, Sale.Sale_PaymentType FROM (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN StockItem ON SaleItem.SaleItem_StockItemID = StockItem.StockItemID WHERE (((Sale.Sale_PaymentType) > 0) " & lStockString & lPosString & " ) ORDER BY Sale.SaleID DESC;"
				
				'By Serial Number......
				If y = 2 Then sql = "SELECT DISTINCT Sale.Sale_Reference, Sale.SaleID, Sale.Sale_PosID, Sale.Sale_DatePOS, Sale.Sale_Total, Sale.Sale_Tender, Sale.Sale_PaymentType FROM (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) WHERE (((Sale.Sale_PaymentType) > 0) " & lStockString & lPosString & " ) ORDER BY Sale.SaleID DESC;"
				
			End If
		Else
			If lStockString = "" Then
				sql = "SELECT DISTINCT Sale.Sale_Reference, Sale.SaleID, Sale.Sale_PosID, Sale.Sale_DatePOS, Sale.Sale_Total, Sale.Sale_Tender, Sale.Sale_PaymentType FROM Customer INNER JOIN (CustomerTransaction INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID Where (((Sale.Sale_PaymentType) > 0) " & lCustomerString & lPosString & " ) ORDER BY Sale.SaleID DESC;"
			Else
				sql = "SELECT DISTINCT Sale.Sale_Reference, Sale.SaleID, Sale.Sale_PosID, Sale.Sale_DatePOS, Sale.Sale_Total, Sale.Sale_Tender, Sale.Sale_PaymentType FROM (SaleItem INNER JOIN (Customer INNER JOIN (CustomerTransaction INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN StockItem ON SaleItem.SaleItem_StockItemID = StockItem.StockItemID Where (((Sale.Sale_PaymentType) > 0) " & lCustomerString & lStockString & lPosString & " )  ORDER BY Sale.SaleID DESC;"
				sql = "SELECT DISTINCT Sale.Sale_Reference, Sale.SaleID, Sale.Sale_PosID, Sale.Sale_DatePOS, Sale.Sale_Total, Sale.Sale_Tender, Sale.Sale_PaymentType FROM StockItem, Customer INNER JOIN (CustomerTransaction INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID Where (((Sale.Sale_PaymentType) > 0) And ((Customer.CustomerID) = " & adoPrimaryRS.Fields("CustomerID").Value & ")) ORDER BY Sale.SaleID DESC;"
			End If
		End If
		sql = "SELECT DISTINCT Sale.Sale_Reference, Sale.SaleID, Sale.Sale_PosID, Sale.Sale_DatePOS, Sale.Sale_Total, Sale.Sale_Tender, Sale.Sale_PaymentType FROM StockItem, Customer INNER JOIN (CustomerTransaction INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID Where (((Sale.Sale_PaymentType) > 0) And ((Customer.CustomerID) = " & adoPrimaryRS.Fields("CustomerID").Value & ")) ORDER BY Sale.SaleID DESC;"
		
		sql = "SELECT CustomerTransaction.CustomerTransactionID, CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_Reference, CustomerTransaction.CustomerTransaction_PersonName, CustomerTransaction.CustomerTransaction_Main, CustomerTransaction.CustomerTransaction_Child, CustomerTransaction.CustomerTransaction_Allocated," & " TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" & adoPrimaryRS.Fields("CustomerID").Value & ")) ORDER BY CustomerTransaction.CustomerTransactionID DESC;"
		
		sql = "SELECT CustomerTransactionAlloc.CustomerTransactionAllocID, CustomerTransactionAlloc.CustomerTransactionAlloc_MainID, CustomerTransactionAlloc.CustomerTransactionAlloc_Amount, CustomerTransaction.CustomerTransactionID, CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_Reference, " & "CustomerTransaction.CustomerTransaction_PersonName, CustomerTransaction.CustomerTransaction_Main, CustomerTransaction.CustomerTransaction_Child, CustomerTransaction.CustomerTransaction_Allocated, TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit FROM CustomerTransactionAlloc INNER JOIN (CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID) ON CustomerTransactionAlloc.CustomerTransactionAlloc_ChildID = CustomerTransaction.CustomerTransactionID WHERE (((CustomerTransactionAlloc.CustomerTransactionAlloc_MainID)=" & PId & "));"
		Debug.Print(sql)
		rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
		
		lvTransAlloc.Items.Clear()
		lblcount.Text = "0 of 0"
		
		Dim lvItem As System.Windows.Forms.ListViewItem
		x = 0
		lvTransAlloc.Visible = False
		Do Until rs.EOF
			x = x + 1
			If gLoading Then
			Else
				Exit Do
			End If
			lblcount.Text = x & " of " & rs.RecordCount
			System.Windows.Forms.Application.DoEvents()
			'If rs("CustomerTransaction_Reference") = "Month End" Then
			If rs.Fields("TransactionType_Name").Value = "B/Forward" Then
				If IIf(IsDbNull(rs.Fields("debit").Value), 0, rs.Fields("debit").Value) = rs.Fields("CustomerTransaction_Allocated").Value And IIf(IsDbNull(rs.Fields("credit").Value), 0, rs.Fields("credit").Value) = 0 Then
					'Else
                    lvItem = lvTransAlloc.Items.Add("K" & rs.Fields("CustomerTransactionAllocID").Value & "_" & databaseName & "_" & rs.Fields("CustomerTransaction_ReferenceID").Value & "_" & rs.Fields("CustomerTransaction_TransactionTypeID").Value, Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "")
					If lvItem.SubItems.Count > 1 Then
						lvItem.SubItems(1).Text = rs.Fields("CustomerTransaction_Reference").Value
					Else
						lvItem.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("CustomerTransaction_Reference").Value))
					End If
					If lvItem.SubItems.Count > 2 Then
						lvItem.SubItems(2).Text = rs.Fields("TransactionType_Name").Value
					Else
						lvItem.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("TransactionType_Name").Value))
					End If
					'Select Case rs("Sale_PaymentType")
					'   Case 1
					'        lvItem.SubItems(2) = "Cash"
					'    Case 2
					'        lvItem.SubItems(2) = "CR Card"
					'    Case 3
					'        lvItem.SubItems(2) = "DR Card"
					'    Case 4
					'        lvItem.SubItems(2) = "Cheque"
					'    Case 5
					'        lvItem.SubItems(2) = "Account"
					'    Case 7
					'        lvItem.SubItems(2) = "Split Tender"
					'    Case Else
					'        lvItem.SubItems(2) = "Cash"
					'End Select
					If lvItem.SubItems.Count > 3 Then
						lvItem.SubItems(3).Text = FormatNumber(rs.Fields("debit").Value, 4)
					Else
						lvItem.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("debit").Value, 4)))
					End If
					If lvItem.SubItems.Count > 4 Then
						lvItem.SubItems(4).Text = FormatNumber(rs.Fields("credit").Value, 4)
					Else
						lvItem.SubItems.Insert(4, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("credit").Value, 4)))
					End If
					If lvItem.SubItems.Count > 5 Then
						lvItem.SubItems(5).Text = FormatNumber(rs.Fields("CustomerTransactionAlloc_Amount").Value, 4)
					Else
						lvItem.SubItems.Insert(5, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("CustomerTransactionAlloc_Amount").Value, 4)))
					End If
				End If
			ElseIf rs.Fields("TransactionType_Name").Value = "Invoice" Then 
				'If IIf(IsNull(rs("debit")), 0, rs("debit")) = rs("CustomerTransaction_Allocated") Then
				'Else
                lvItem = lvTransAlloc.Items.Add("K" & rs.Fields("CustomerTransactionAllocID").Value & "_" & databaseName & "_" & rs.Fields("CustomerTransaction_ReferenceID").Value & "_" & rs.Fields("CustomerTransaction_TransactionTypeID").Value, Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "")
				If lvItem.SubItems.Count > 1 Then
					lvItem.SubItems(1).Text = rs.Fields("CustomerTransaction_Reference").Value
				Else
					lvItem.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("CustomerTransaction_Reference").Value))
				End If
				If lvItem.SubItems.Count > 2 Then
					lvItem.SubItems(2).Text = rs.Fields("TransactionType_Name").Value
				Else
					lvItem.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("TransactionType_Name").Value))
				End If
				If lvItem.SubItems.Count > 3 Then
					lvItem.SubItems(3).Text = FormatNumber(rs.Fields("debit").Value, 4)
				Else
					lvItem.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("debit").Value, 4)))
				End If
				If lvItem.SubItems.Count > 4 Then
					lvItem.SubItems(4).Text = FormatNumber(rs.Fields("credit").Value, 4)
				Else
					lvItem.SubItems.Insert(4, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("credit").Value, 4)))
				End If
				If lvItem.SubItems.Count > 5 Then
					lvItem.SubItems(5).Text = FormatNumber(rs.Fields("CustomerTransactionAlloc_Amount").Value, 4)
				Else
					lvItem.SubItems.Insert(5, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("CustomerTransactionAlloc_Amount").Value, 4)))
				End If
				'End If
			ElseIf rs.Fields("TransactionType_Name").Value = "Interest" Then 
				'If IIf(IsNull(rs("debit")), 0, rs("debit")) = rs("CustomerTransaction_Allocated") Then
				'Else
                lvItem = lvTransAlloc.Items.Add("K" & rs.Fields("CustomerTransactionAllocID").Value & "_" & databaseName & "_" & rs.Fields("CustomerTransaction_ReferenceID").Value & "_" & rs.Fields("CustomerTransaction_TransactionTypeID").Value, Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "")
				If lvItem.SubItems.Count > 1 Then
					lvItem.SubItems(1).Text = rs.Fields("CustomerTransaction_Reference").Value
				Else
					lvItem.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("CustomerTransaction_Reference").Value))
				End If
				If lvItem.SubItems.Count > 2 Then
					lvItem.SubItems(2).Text = rs.Fields("TransactionType_Name").Value
				Else
					lvItem.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("TransactionType_Name").Value))
				End If
				If lvItem.SubItems.Count > 3 Then
					lvItem.SubItems(3).Text = FormatNumber(rs.Fields("debit").Value, 4)
				Else
					lvItem.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("debit").Value, 4)))
				End If
				If lvItem.SubItems.Count > 4 Then
					lvItem.SubItems(4).Text = FormatNumber(rs.Fields("credit").Value, 4)
				Else
					lvItem.SubItems.Insert(4, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("credit").Value, 4)))
				End If
				If lvItem.SubItems.Count > 5 Then
					lvItem.SubItems(5).Text = FormatNumber(rs.Fields("CustomerTransactionAlloc_Amount").Value, 4)
				Else
					lvItem.SubItems.Insert(5, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("CustomerTransactionAlloc_Amount").Value, 4)))
				End If
				'End If
			ElseIf rs.Fields("TransactionType_Name").Value = "Debit Journal" Then 
				'If IIf(IsNull(rs("debit")), 0, rs("debit")) = rs("CustomerTransaction_Allocated") Then
				'Else
                lvItem = lvTransAlloc.Items.Add("K" & rs.Fields("CustomerTransactionAllocID").Value & "_" & databaseName & "_" & rs.Fields("CustomerTransaction_ReferenceID").Value & "_" & rs.Fields("CustomerTransaction_TransactionTypeID").Value, Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "")
				If lvItem.SubItems.Count > 1 Then
					lvItem.SubItems(1).Text = rs.Fields("CustomerTransaction_Reference").Value
				Else
					lvItem.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("CustomerTransaction_Reference").Value))
				End If
				If lvItem.SubItems.Count > 2 Then
					lvItem.SubItems(2).Text = rs.Fields("TransactionType_Name").Value
				Else
					lvItem.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("TransactionType_Name").Value))
				End If
				If lvItem.SubItems.Count > 3 Then
					lvItem.SubItems(3).Text = FormatNumber(rs.Fields("debit").Value, 4)
				Else
					lvItem.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("debit").Value, 4)))
				End If
				If lvItem.SubItems.Count > 4 Then
					lvItem.SubItems(4).Text = FormatNumber(rs.Fields("credit").Value, 4)
				Else
					lvItem.SubItems.Insert(4, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("credit").Value, 4)))
				End If
				If lvItem.SubItems.Count > 5 Then
					lvItem.SubItems(5).Text = FormatNumber(rs.Fields("CustomerTransactionAlloc_Amount").Value, 4)
				Else
					lvItem.SubItems.Insert(5, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("CustomerTransactionAlloc_Amount").Value, 4)))
				End If
				'End If
			End If
			rs.moveNext()
		Loop 
		lvTransAlloc.Visible = True
		lvTransAlloc.Refresh()
		Cursor = System.Windows.Forms.Cursors.Default
		gLoading = False
	End Sub
	
	Private Sub cmdsearch_Click_Alloc()
		Dim x As Integer
		Dim sql As String
		Dim databaseName As String
		Dim y As Short
		Dim lMonth As Short
		Dim cn As ADODB.Connection
		Dim rs As New ADODB.Recordset
		
		bSelectPayment = False
		If gLoading Then Exit Sub
		gLoading = True
		Cursor = System.Windows.Forms.Cursors.WaitCursor
		System.Windows.Forms.Application.DoEvents()
		'lMonth = cmbMonth.ItemData(cmbMonth.ListIndex)
		'If lMonth = gMonthEnd Then
		databaseName = "pricing.mdb"
		'Else
		'    databaseName = "Month" & lMonth & ".mdb"
		'End If
		
		'Set cn = openConnectionInstance(databaseName)
		'If cn Is Nothing Then
		'    Exit Sub
		'End If
		Dim lString As String
		
		sql = "SELECT CustomerTransaction.CustomerTransactionID, CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_Reference, CustomerTransaction.CustomerTransaction_PersonName, CustomerTransaction.CustomerTransaction_Main, CustomerTransaction.CustomerTransaction_Child, CustomerTransaction.CustomerTransaction_Allocated," & " TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" & adoPrimaryRS.Fields("CustomerID").Value & ")) ORDER BY CustomerTransaction.CustomerTransactionID DESC;"
		Debug.Print(sql)
		'rs.Open sql, cnnDB, adOpenStatic, adLockReadOnly, adCmdText
		rs = getRS(sql)
		
		lvTransAlloc.Items.Clear()
		lblcount.Text = "0 of 0"
		
		Dim lvItemAlloc As System.Windows.Forms.ListViewItem
		x = 0
		lvTransAlloc.Visible = False
		Do Until rs.EOF
			x = x + 1
			If gLoading Then
			Else
				Exit Do
			End If
			lblcount.Text = x & " of " & rs.RecordCount
			System.Windows.Forms.Application.DoEvents()
			'If rs("CustomerTransaction_Reference") = "Month End" Then
			If rs.Fields("TransactionType_Name").Value = "B/Forward" Then
				If IIf(IsDbNull(rs.Fields("debit").Value), 0, rs.Fields("debit").Value) = rs.Fields("CustomerTransaction_Allocated").Value And IIf(IsDbNull(rs.Fields("credit").Value), 0, rs.Fields("credit").Value) = 0 Then
					'Else
                    lvItemAlloc = lvTransAlloc.Items.Add("K" & rs.Fields("CustomerTransactionID").Value & "_" & databaseName & "_" & rs.Fields("CustomerTransaction_ReferenceID").Value & "_" & rs.Fields("CustomerTransaction_TransactionTypeID").Value, Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "")
					If lvItemAlloc.SubItems.Count > 1 Then
						lvItemAlloc.SubItems(1).Text = rs.Fields("CustomerTransaction_Reference").Value
					Else
						lvItemAlloc.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("CustomerTransaction_Reference").Value))
					End If
					If lvItemAlloc.SubItems.Count > 2 Then
						lvItemAlloc.SubItems(2).Text = rs.Fields("TransactionType_Name").Value
					Else
						lvItemAlloc.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("TransactionType_Name").Value))
					End If
					'Select Case rs("Sale_PaymentType")
					'   Case 1
					'        lvItemAlloc.SubItems(2) = "Cash"
					'    Case 2
					'        lvItemAlloc.SubItems(2) = "CR Card"
					'    Case 3
					'        lvItemAlloc.SubItems(2) = "DR Card"
					'    Case 4
					'        lvItemAlloc.SubItems(2) = "Cheque"
					'    Case 5
					'        lvItemAlloc.SubItems(2) = "Account"
					'    Case 7
					'        lvItemAlloc.SubItems(2) = "Split Tender"
					'    Case Else
					'        lvItemAlloc.SubItems(2) = "Cash"
					'End Select
					If lvItemAlloc.SubItems.Count > 3 Then
						lvItemAlloc.SubItems(3).Text = FormatNumber(rs.Fields("debit").Value, 4)
					Else
						lvItemAlloc.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("debit").Value, 4)))
					End If
					If lvItemAlloc.SubItems.Count > 4 Then
						lvItemAlloc.SubItems(4).Text = FormatNumber(rs.Fields("credit").Value, 4)
					Else
						lvItemAlloc.SubItems.Insert(4, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("credit").Value, 4)))
					End If
					If lvItemAlloc.SubItems.Count > 5 Then
						lvItemAlloc.SubItems(5).Text = FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)
					Else
						lvItemAlloc.SubItems.Insert(5, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)))
					End If
				End If
			ElseIf rs.Fields("TransactionType_Name").Value = "Invoice" Then 
				If IIf(IsDbNull(rs.Fields("debit").Value), 0, rs.Fields("debit").Value) = rs.Fields("CustomerTransaction_Allocated").Value And IIf(IsDbNull(rs.Fields("credit").Value), 0, rs.Fields("credit").Value) = 0 Then
					'Else
                    lvItemAlloc = lvTransAlloc.Items.Add("K" & rs.Fields("CustomerTransactionID").Value & "_" & databaseName & "_" & rs.Fields("CustomerTransaction_ReferenceID").Value & "_" & rs.Fields("CustomerTransaction_TransactionTypeID").Value, Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "")
					If lvItemAlloc.SubItems.Count > 1 Then
						lvItemAlloc.SubItems(1).Text = rs.Fields("CustomerTransaction_Reference").Value
					Else
						lvItemAlloc.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("CustomerTransaction_Reference").Value))
					End If
					If lvItemAlloc.SubItems.Count > 2 Then
						lvItemAlloc.SubItems(2).Text = rs.Fields("TransactionType_Name").Value
					Else
						lvItemAlloc.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("TransactionType_Name").Value))
					End If
					If lvItemAlloc.SubItems.Count > 3 Then
						lvItemAlloc.SubItems(3).Text = FormatNumber(rs.Fields("debit").Value, 4)
					Else
						lvItemAlloc.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("debit").Value, 4)))
					End If
					If lvItemAlloc.SubItems.Count > 4 Then
						lvItemAlloc.SubItems(4).Text = FormatNumber(rs.Fields("credit").Value, 4)
					Else
						lvItemAlloc.SubItems.Insert(4, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("credit").Value, 4)))
					End If
					If lvItemAlloc.SubItems.Count > 5 Then
						lvItemAlloc.SubItems(5).Text = FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)
					Else
						lvItemAlloc.SubItems.Insert(5, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)))
					End If
				End If
			ElseIf rs.Fields("TransactionType_Name").Value = "Interest" Then 
				If IIf(IsDbNull(rs.Fields("debit").Value), 0, rs.Fields("debit").Value) = rs.Fields("CustomerTransaction_Allocated").Value And IIf(IsDbNull(rs.Fields("credit").Value), 0, rs.Fields("credit").Value) = 0 Then
					'Else
                    lvItemAlloc = lvTransAlloc.Items.Add("K" & rs.Fields("CustomerTransactionID").Value & "_" & databaseName & "_" & rs.Fields("CustomerTransaction_ReferenceID").Value & "_" & rs.Fields("CustomerTransaction_TransactionTypeID").Value, Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "")
					If lvItemAlloc.SubItems.Count > 1 Then
						lvItemAlloc.SubItems(1).Text = rs.Fields("CustomerTransaction_Reference").Value
					Else
						lvItemAlloc.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("CustomerTransaction_Reference").Value))
					End If
					If lvItemAlloc.SubItems.Count > 2 Then
						lvItemAlloc.SubItems(2).Text = rs.Fields("TransactionType_Name").Value
					Else
						lvItemAlloc.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("TransactionType_Name").Value))
					End If
					If lvItemAlloc.SubItems.Count > 3 Then
						lvItemAlloc.SubItems(3).Text = FormatNumber(rs.Fields("debit").Value, 4)
					Else
						lvItemAlloc.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("debit").Value, 4)))
					End If
					If lvItemAlloc.SubItems.Count > 4 Then
						lvItemAlloc.SubItems(4).Text = FormatNumber(rs.Fields("credit").Value, 4)
					Else
						lvItemAlloc.SubItems.Insert(4, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("credit").Value, 4)))
					End If
					If lvItemAlloc.SubItems.Count > 5 Then
						lvItemAlloc.SubItems(5).Text = FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)
					Else
						lvItemAlloc.SubItems.Insert(5, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)))
					End If
				End If
			ElseIf rs.Fields("TransactionType_Name").Value = "Debit Journal" Then 
				If IIf(IsDbNull(rs.Fields("debit").Value), 0, rs.Fields("debit").Value) = rs.Fields("CustomerTransaction_Allocated").Value Then
					'Else
                    lvItemAlloc = lvTransAlloc.Items.Add("K" & rs.Fields("CustomerTransactionID").Value & "_" & databaseName & "_" & rs.Fields("CustomerTransaction_ReferenceID").Value & "_" & rs.Fields("CustomerTransaction_TransactionTypeID").Value, Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "")
					If lvItemAlloc.SubItems.Count > 1 Then
						lvItemAlloc.SubItems(1).Text = rs.Fields("CustomerTransaction_Reference").Value
					Else
						lvItemAlloc.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("CustomerTransaction_Reference").Value))
					End If
					If lvItemAlloc.SubItems.Count > 2 Then
						lvItemAlloc.SubItems(2).Text = rs.Fields("TransactionType_Name").Value
					Else
						lvItemAlloc.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("TransactionType_Name").Value))
					End If
					If lvItemAlloc.SubItems.Count > 3 Then
						lvItemAlloc.SubItems(3).Text = FormatNumber(rs.Fields("debit").Value, 4)
					Else
						lvItemAlloc.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("debit").Value, 4)))
					End If
					If lvItemAlloc.SubItems.Count > 4 Then
						lvItemAlloc.SubItems(4).Text = FormatNumber(rs.Fields("credit").Value, 4)
					Else
						lvItemAlloc.SubItems.Insert(4, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("credit").Value, 4)))
					End If
					If lvItemAlloc.SubItems.Count > 5 Then
						lvItemAlloc.SubItems(5).Text = FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)
					Else
						lvItemAlloc.SubItems.Insert(5, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)))
					End If
				End If
			End If
			rs.moveNext()
		Loop 
		lvTransAlloc.Visible = True
		'lvTransAlloc.Refresh
		Cursor = System.Windows.Forms.Cursors.Default
		gLoading = False
	End Sub
	
	Private Sub cmdsearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdsearch.Click
		Dim x As Integer
		Dim sql As String
		Dim databaseName As String
		Dim y As Short
		Dim lMonth As Short
		Dim cn As ADODB.Connection
		Dim rs As New ADODB.Recordset
		
		
		If gLoading Then Exit Sub
		gLoading = True
		Cursor = System.Windows.Forms.Cursors.WaitCursor
		System.Windows.Forms.Application.DoEvents()
		'lMonth = cmbMonth.ItemData(cmbMonth.ListIndex)
		'If lMonth = gMonthEnd Then
		databaseName = "pricing.mdb"
		'Else
		'    databaseName = "Month" & lMonth & ".mdb"
		'End If
		'If openConnection() Then
		'    frmMain.lblPath.Caption = serverPath
		'    closeConnection
		'End If
		
		'Set cn = openConnectionInstance(databaseName)
		'If cn Is Nothing Then
		'    Exit Sub
		'End If
		'Dim lString As String
		
		System.Windows.Forms.Application.DoEvents()
		If rs.State Then rs.Close()
		sql = "SELECT CustomerTransaction.CustomerTransactionID, CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_Reference, CustomerTransaction.CustomerTransaction_PersonName, CustomerTransaction.CustomerTransaction_Main, CustomerTransaction.CustomerTransaction_Child, CustomerTransaction.CustomerTransaction_Allocated," & " TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" & adoPrimaryRS.Fields("CustomerID").Value & ")) ORDER BY CustomerTransaction.CustomerTransactionID DESC;"
		Debug.Print(sql)
		'rs.Open sql, cn, adOpenStatic, adLockReadOnly, adCmdText
		rs = getRS(sql)
		
		lvTransaction.Items.Clear()
		lblcount.Text = "0 of 0"
		
		Dim lvItemTran As System.Windows.Forms.ListViewItem
		x = 0
		lvTransaction.Visible = False
		Do Until rs.EOF
			x = x + 1
			If gLoading Then
			Else
				Exit Do
			End If
			lblcount.Text = x & " of " & rs.RecordCount
			System.Windows.Forms.Application.DoEvents()
			'If rs("CustomerTransaction_Reference") = "Month End" Then
			If rs.Fields("TransactionType_Name").Value = "B/Forward" Then
				If IIf(IsDbNull(rs.Fields("debit").Value), 0, rs.Fields("debit").Value) = rs.Fields("CustomerTransaction_Allocated").Value Then
				ElseIf IIf(IsDbNull(rs.Fields("credit").Value), 0, rs.Fields("credit").Value) = rs.Fields("CustomerTransaction_Allocated").Value And IIf(IsDbNull(rs.Fields("credit").Value), 0, rs.Fields("credit").Value) < 0 Then 
				Else
                    lvItemTran = lvTransaction.Items.Add("K" & rs.Fields("CustomerTransactionID").Value & "_" & databaseName & "_" & rs.Fields("CustomerTransaction_ReferenceID").Value & "_" & rs.Fields("CustomerTransaction_TransactionTypeID").Value, Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "")
					If lvItemTran.SubItems.Count > 1 Then
						lvItemTran.SubItems(1).Text = rs.Fields("CustomerTransaction_Reference").Value
					Else
						lvItemTran.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("CustomerTransaction_Reference").Value))
					End If
					If lvItemTran.SubItems.Count > 2 Then
						lvItemTran.SubItems(2).Text = rs.Fields("TransactionType_Name").Value
					Else
						lvItemTran.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("TransactionType_Name").Value))
					End If
					'Select Case rs("Sale_PaymentType")
					'   Case 1
					'        lvItemTran.SubItems(2) = "Cash"
					'    Case 2
					'        lvItemTran.SubItems(2) = "CR Card"
					'    Case 3
					'        lvItemTran.SubItems(2) = "DR Card"
					'    Case 4
					'        lvItemTran.SubItems(2) = "Cheque"
					'    Case 5
					'        lvItemTran.SubItems(2) = "Account"
					'    Case 7
					'        lvItemTran.SubItems(2) = "Split Tender"
					'    Case Else
					'        lvItemTran.SubItems(2) = "Cash"
					'End Select
					If lvItemTran.SubItems.Count > 3 Then
						lvItemTran.SubItems(3).Text = FormatNumber(rs.Fields("debit").Value, 4)
					Else
						lvItemTran.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("debit").Value, 4)))
					End If
					If lvItemTran.SubItems.Count > 4 Then
						lvItemTran.SubItems(4).Text = FormatNumber(rs.Fields("credit").Value, 4)
					Else
						lvItemTran.SubItems.Insert(4, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("credit").Value, 4)))
					End If
					If lvItemTran.SubItems.Count > 5 Then
						lvItemTran.SubItems(5).Text = FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)
					Else
						lvItemTran.SubItems.Insert(5, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)))
					End If
					If lvItemTran.SubItems.Count > 6 Then
						lvItemTran.SubItems(6).Text = FormatNumber(IIf((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0, 0 - ((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), (rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)
					Else
						lvItemTran.SubItems.Insert(6, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(IIf((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0, 0 - ((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), (rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)))
					End If
				End If
			ElseIf rs.Fields("TransactionType_Name").Value = "Invoice" Then 
				If IIf(IsDbNull(rs.Fields("debit").Value), 0, rs.Fields("debit").Value) = rs.Fields("CustomerTransaction_Allocated").Value Then
				ElseIf rs.Fields("CustomerTransaction_Allocated").Value < 0 Then 
				Else
                    lvItemTran = lvTransaction.Items.Add("K" & rs.Fields("CustomerTransactionID").Value & "_" & databaseName & "_" & rs.Fields("CustomerTransaction_ReferenceID").Value & "_" & rs.Fields("CustomerTransaction_TransactionTypeID").Value, Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "")
                    If lvItemTran.SubItems.Count > 1 Then
                        lvItemTran.SubItems(1).Text = rs.Fields("CustomerTransaction_Reference").Value
                    Else
                        lvItemTran.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("CustomerTransaction_Reference").Value))
                    End If
                    If lvItemTran.SubItems.Count > 2 Then
                        lvItemTran.SubItems(2).Text = rs.Fields("TransactionType_Name").Value
                    Else
                        lvItemTran.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("TransactionType_Name").Value))
                    End If
                    If lvItemTran.SubItems.Count > 3 Then
                        lvItemTran.SubItems(3).Text = FormatNumber(rs.Fields("debit").Value, 4)
                    Else
                        lvItemTran.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("debit").Value, 4)))
                    End If
                    If lvItemTran.SubItems.Count > 4 Then
                        lvItemTran.SubItems(4).Text = FormatNumber(rs.Fields("credit").Value, 4)
                    Else
                        lvItemTran.SubItems.Insert(4, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("credit").Value, 4)))
                    End If
                    If lvItemTran.SubItems.Count > 5 Then
                        lvItemTran.SubItems(5).Text = FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)
                    Else
                        lvItemTran.SubItems.Insert(5, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)))
                    End If
                    If lvItemTran.SubItems.Count > 6 Then
                        lvItemTran.SubItems(6).Text = FormatNumber(IIf((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0, 0 - ((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), (rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)
                    Else
                        lvItemTran.SubItems.Insert(6, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(IIf((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0, 0 - ((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), (rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)))
                    End If
                End If
            ElseIf rs.Fields("TransactionType_Name").Value = "Interest" Then
                If IIf(IsDbNull(rs.Fields("debit").Value), 0, rs.Fields("debit").Value) = rs.Fields("CustomerTransaction_Allocated").Value Then
                ElseIf rs.Fields("CustomerTransaction_Allocated").Value < 0 Then
                Else
                    lvItemTran = lvTransaction.Items.Add("K" & rs.Fields("CustomerTransactionID").Value & "_" & databaseName & "_" & rs.Fields("CustomerTransaction_ReferenceID").Value & "_" & rs.Fields("CustomerTransaction_TransactionTypeID").Value, Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "")
                    If lvItemTran.SubItems.Count > 1 Then
                        lvItemTran.SubItems(1).Text = rs.Fields("CustomerTransaction_Reference").Value
                    Else
                        lvItemTran.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("CustomerTransaction_Reference").Value))
                    End If
                   If lvItemTran.SubItems.Count > 2 Then
                        lvItemTran.SubItems(2).Text = rs.Fields("TransactionType_Name").Value
                    Else
                        lvItemTran.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("TransactionType_Name").Value))
                    End If
                    If lvItemTran.SubItems.Count > 3 Then
                        lvItemTran.SubItems(3).Text = FormatNumber(rs.Fields("debit").Value, 4)
                    Else
                        lvItemTran.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("debit").Value, 4)))
                    End If
                    If lvItemTran.SubItems.Count > 4 Then
                        lvItemTran.SubItems(4).Text = FormatNumber(rs.Fields("credit").Value, 4)
                    Else
                        lvItemTran.SubItems.Insert(4, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("credit").Value, 4)))
                    End If
                    If lvItemTran.SubItems.Count > 5 Then
                        lvItemTran.SubItems(5).Text = FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)
                    Else
                        lvItemTran.SubItems.Insert(5, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)))
                    End If
                    If lvItemTran.SubItems.Count > 6 Then
                        lvItemTran.SubItems(6).Text = FormatNumber(IIf((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0, 0 - ((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), (rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)
                    Else
                        lvItemTran.SubItems.Insert(6, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(IIf((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0, 0 - ((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), (rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)))
                    End If
                End If
            ElseIf rs.Fields("TransactionType_Name").Value = "Debit Journal" Then
                If IIf(IsDbNull(rs.Fields("debit").Value), 0, rs.Fields("debit").Value) = rs.Fields("CustomerTransaction_Allocated").Value Then
                Else
                    lvItemTran = lvTransaction.Items.Add("K" & rs.Fields("CustomerTransactionID").Value & "_" & databaseName & "_" & rs.Fields("CustomerTransaction_ReferenceID").Value & "_" & rs.Fields("CustomerTransaction_TransactionTypeID").Value, Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "")
                    If lvItemTran.SubItems.Count > 1 Then
                        lvItemTran.SubItems(1).Text = rs.Fields("CustomerTransaction_Reference").Value
                    Else
                        lvItemTran.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("CustomerTransaction_Reference").Value))
                    End If
                    If lvItemTran.SubItems.Count > 2 Then
                        lvItemTran.SubItems(2).Text = rs.Fields("TransactionType_Name").Value
                    Else
                        lvItemTran.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("TransactionType_Name").Value))
                    End If
                     If lvItemTran.SubItems.Count > 3 Then
                        lvItemTran.SubItems(3).Text = FormatNumber(rs.Fields("debit").Value, 4)
                    Else
                        lvItemTran.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("debit").Value, 4)))
                    End If
                    If lvItemTran.SubItems.Count > 4 Then
                        lvItemTran.SubItems(4).Text = FormatNumber(rs.Fields("credit").Value, 4)
                    Else
                        lvItemTran.SubItems.Insert(4, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("credit").Value, 4)))
                    End If
                    If lvItemTran.SubItems.Count > 5 Then
                        lvItemTran.SubItems(5).Text = FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)
                    Else
                        lvItemTran.SubItems.Insert(5, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)))
                    End If
                    If lvItemTran.SubItems.Count > 6 Then
                        lvItemTran.SubItems(6).Text = FormatNumber(IIf((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0, 0 - ((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), (rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)
                    Else
                        lvItemTran.SubItems.Insert(6, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(IIf((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0, 0 - ((rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), (rs.Fields("debit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)))
                    End If
                End If
            End If
            rs.moveNext()
        Loop
        lvTransaction.Visible = True
        'lvTransaction.Refresh
        Cursor = System.Windows.Forms.Cursors.Default
        gLoading = False
    End Sub

    Private Sub cmdsearch_Click_Payment()
        Dim x As Integer
        Dim sql As String
        Dim databaseName As String
        Dim y As Short
        Dim lMonth As Short
        Dim cn As ADODB.Connection
        Dim rs As New ADODB.Recordset


        If gLoading Then Exit Sub
        gLoading = True
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        System.Windows.Forms.Application.DoEvents()
        'lMonth = cmbMonth.ItemData(cmbMonth.ListIndex)
        'If lMonth = gMonthEnd Then
        databaseName = "pricing.mdb"
        'Else
        '    databaseName = "Month" & lMonth & ".mdb"
        'End If
        'If openConnection() Then
        '    frmMain.lblPath.Caption = serverPath
        '    closeConnection
        'End If

        'Set cn = openConnectionInstance(databaseName)
        'If cn Is Nothing Then
        '    Exit Sub
        'End If
        'Dim lString As String

        sql = "SELECT CustomerTransaction.CustomerTransactionID, CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_Reference, CustomerTransaction.CustomerTransaction_PersonName, CustomerTransaction.CustomerTransaction_Main, CustomerTransaction.CustomerTransaction_Child, CustomerTransaction.CustomerTransaction_Allocated," & " TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" & adoPrimaryRS.Fields("CustomerID").Value & ")) ORDER BY CustomerTransaction.CustomerTransactionID DESC;"
        Debug.Print(sql)
        'rs.Open sql, cn, adOpenStatic, adLockReadOnly, adCmdText
        rs = getRS(sql)

        lvPayment.Items.Clear()
        'Exit Sub
        lblcount.Text = "0 of 0"

        Dim lvItemPay As System.Windows.Forms.ListViewItem
        x = 0
        lvPayment.Visible = False
        Do Until rs.EOF
            x = x + 1
            If gLoading Then
            Else
                Exit Do
            End If
            lblcount.Text = x & " of " & rs.RecordCount
            System.Windows.Forms.Application.DoEvents()
            'If rs("CustomerTransaction_Reference") = "Month End" Then
            If rs.Fields("TransactionType_Name").Value = "B/Forward" Then
                'If IIf(IsNull(rs("credit")), 0, rs("credit")) >= IIf(IsNull(rs("CustomerTransaction_Allocated")), 0, rs("CustomerTransaction_Allocated")) Then
                If IIf(IsDbNull(rs.Fields("credit").Value), 0, rs.Fields("credit").Value) = 0 Then
                Else
                    lvItemPay = lvPayment.Items.Add("K" & rs.Fields("CustomerTransactionID").Value & "_" & databaseName & "_" & rs.Fields("CustomerTransaction_ReferenceID").Value & "_" & rs.Fields("CustomerTransaction_TransactionTypeID").Value, Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "")
                    If lvItemPay.SubItems.Count > 1 Then
                        lvItemPay.SubItems(1).Text = rs.Fields("CustomerTransaction_Reference").Value
                    Else
                        lvItemPay.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("CustomerTransaction_Reference").Value))
                    End If
                    If lvItemPay.SubItems.Count > 2 Then
                        lvItemPay.SubItems(2).Text = rs.Fields("TransactionType_Name").Value
                    Else
                        lvItemPay.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("TransactionType_Name").Value))
                    End If
                    If lvItemPay.SubItems.Count > 3 Then
                        lvItemPay.SubItems(3).Text = FormatNumber(rs.Fields("debit").Value, 4)
                    Else
                        lvItemPay.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("debit").Value, 4)))
                    End If
                    If lvItemPay.SubItems.Count > 4 Then
                        lvItemPay.SubItems(4).Text = FormatNumber(rs.Fields("credit").Value, 4)
                    Else
                        lvItemPay.SubItems.Insert(4, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("credit").Value, 4)))
                    End If
                    If lvItemPay.SubItems.Count > 5 Then
                        lvItemPay.SubItems(5).Text = FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)
                    Else
                        lvItemPay.SubItems.Insert(5, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)))
                    End If
                    If lvItemPay.SubItems.Count > 6 Then
                        lvItemPay.SubItems(6).Text = FormatNumber(IIf((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0, ((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 0 - (rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)
                    Else
                        lvItemPay.SubItems.Insert(6, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(IIf((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0, ((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 0 - (rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)))
                    End If
                End If
            ElseIf rs.Fields("TransactionType_Name").Value = "Payment" Then
                'If IIf(IsNull(rs("credit")), 0, rs("credit")) >= IIf(IsNull(rs("CustomerTransaction_Allocated")), 0, rs("CustomerTransaction_Allocated")) Then
                If IIf(IsDbNull(rs.Fields("credit").Value), 0, rs.Fields("credit").Value) = 0 Then
                Else
                    lvItemPay = lvPayment.Items.Add("K" & rs.Fields("CustomerTransactionID").Value & "_" & databaseName & "_" & rs.Fields("CustomerTransaction_ReferenceID").Value & "_" & rs.Fields("CustomerTransaction_TransactionTypeID").Value, Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "")
                    If lvItemPay.SubItems.Count > 1 Then
                        lvItemPay.SubItems(1).Text = rs.Fields("CustomerTransaction_Reference").Value
                    Else
                        lvItemPay.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("CustomerTransaction_Reference").Value))
                    End If
                    If lvItemPay.SubItems.Count > 2 Then
                        lvItemPay.SubItems(2).Text = rs.Fields("TransactionType_Name").Value
                    Else
                        lvItemPay.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("TransactionType_Name").Value))
                    End If
                    'Select Case rs("Sale_PaymentType")
                    '   Case 1
                    '        lvItemPay.SubItems(2) = "Cash"
                    '    Case 2
                    '        lvItemPay.SubItems(2) = "CR Card"
                    '    Case 3
                    '        lvItemPay.SubItems(2) = "DR Card"
                    '    Case 4
                    '        lvItemPay.SubItems(2) = "Cheque"
                    '    Case 5
                    '        lvItemPay.SubItems(2) = "Account"
                    '    Case 7
                    '        lvItemPay.SubItems(2) = "Split Tender"
                    '    Case Else
                    '        lvItemPay.SubItems(2) = "Cash"
                    'End Select
                    If lvItemPay.SubItems.Count > 3 Then
                        lvItemPay.SubItems(3).Text = FormatNumber(rs.Fields("debit").Value, 4)
                    Else
                        lvItemPay.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("debit").Value, 4)))
                    End If
                    If lvItemPay.SubItems.Count > 4 Then
                        lvItemPay.SubItems(4).Text = FormatNumber(rs.Fields("credit").Value, 4)
                    Else
                        lvItemPay.SubItems.Insert(4, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("credit").Value, 4)))
                    End If
                    If lvItemPay.SubItems.Count > 5 Then
                        lvItemPay.SubItems(5).Text = FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)
                    Else
                        lvItemPay.SubItems.Insert(5, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)))
                    End If
                    If lvItemPay.SubItems.Count > 6 Then
                        lvItemPay.SubItems(6).Text = FormatNumber(IIf((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0, ((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 0 - (rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)
                    Else
                        lvItemPay.SubItems.Insert(6, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(IIf((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0, ((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 0 - (rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)))
                    End If
                End If

            ElseIf rs.Fields("TransactionType_Name").Value = "Credit Journal" Then
                'If IIf(IsNull(rs("credit")), 0, rs("credit")) >= rs("CustomerTransaction_Allocated") Then
                If IIf(IsDbNull(rs.Fields("credit").Value), 0, rs.Fields("credit").Value) = 0 Then
                Else
                    lvItemPay = lvPayment.Items.Add("K" & rs.Fields("CustomerTransactionID").Value & "_" & databaseName & "_" & rs.Fields("CustomerTransaction_ReferenceID").Value & "_" & rs.Fields("CustomerTransaction_TransactionTypeID").Value, Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "")
                    If lvItemPay.SubItems.Count > 1 Then
                        lvItemPay.SubItems(1).Text = rs.Fields("CustomerTransaction_Reference").Value
                    Else
                        lvItemPay.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("CustomerTransaction_Reference").Value))
                    End If
                    If lvItemPay.SubItems.Count > 2 Then
                        lvItemPay.SubItems(2).Text = rs.Fields("TransactionType_Name").Value
                    Else
                        lvItemPay.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("TransactionType_Name").Value))
                    End If
                    If lvItemPay.SubItems.Count > 3 Then
                        lvItemPay.SubItems(3).Text = FormatNumber(rs.Fields("debit").Value, 4)
                    Else
                        lvItemPay.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("debit").Value, 4)))
                    End If
                    If lvItemPay.SubItems.Count > 4 Then
                        lvItemPay.SubItems(4).Text = FormatNumber(rs.Fields("credit").Value, 4)
                    Else
                        lvItemPay.SubItems.Insert(4, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("credit").Value, 4)))
                    End If
                    If lvItemPay.SubItems.Count > 5 Then
                        lvItemPay.SubItems(5).Text = FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)
                    Else
                        lvItemPay.SubItems.Insert(5, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)))
                    End If
                    If lvItemPay.SubItems.Count > 6 Then
                        lvItemPay.SubItems(6).Text = FormatNumber(IIf((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0, ((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 0 - (rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)
                    Else
                        lvItemPay.SubItems.Insert(6, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(IIf((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0, ((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 0 - (rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)))
                    End If
                End If

            ElseIf rs.Fields("TransactionType_Name").Value = "Invoice" Then
                'If IIf(IsNull(rs("credit")), 0, rs("credit")) >= rs("CustomerTransaction_Allocated") Then
                If IIf(IsDbNull(rs.Fields("credit").Value), 0, rs.Fields("credit").Value) = 0 Then
                Else
                    lvItemPay = lvPayment.Items.Add("K" & rs.Fields("CustomerTransactionID").Value & "_" & databaseName & "_" & rs.Fields("CustomerTransaction_ReferenceID").Value & "_" & rs.Fields("CustomerTransaction_TransactionTypeID").Value, Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "")
                    If lvItemPay.SubItems.Count > 1 Then
                        lvItemPay.SubItems(1).Text = rs.Fields("CustomerTransaction_Reference").Value
                    Else
                        lvItemPay.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("CustomerTransaction_Reference").Value))
                    End If
                    If lvItemPay.SubItems.Count > 2 Then
                        lvItemPay.SubItems(2).Text = rs.Fields("TransactionType_Name").Value
                    Else
                        lvItemPay.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("TransactionType_Name").Value))
                    End If
                    If lvItemPay.SubItems.Count > 3 Then
                        lvItemPay.SubItems(3).Text = FormatNumber(rs.Fields("debit").Value, 4)
                    Else
                        lvItemPay.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("debit").Value, 4)))
                    End If
                    If lvItemPay.SubItems.Count > 4 Then
                        lvItemPay.SubItems(4).Text = FormatNumber(rs.Fields("credit").Value, 4)
                    Else
                        lvItemPay.SubItems.Insert(4, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("credit").Value, 4)))
                    End If
                    If lvItemPay.SubItems.Count > 5 Then
                        lvItemPay.SubItems(5).Text = FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)
                    Else
                        lvItemPay.SubItems.Insert(5, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)))
                    End If
                    If lvItemPay.SubItems.Count > 6 Then
                        lvItemPay.SubItems(6).Text = FormatNumber(IIf((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0, ((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 0 - (rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)
                    Else
                        lvItemPay.SubItems.Insert(6, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(IIf((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0, ((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 0 - (rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)))
                    End If
                End If

            ElseIf rs.Fields("TransactionType_Name").Value = "Interest" Then
                'If IIf(IsNull(rs("credit")), 0, rs("credit")) >= rs("CustomerTransaction_Allocated") Then
                If IIf(IsDbNull(rs.Fields("credit").Value), 0, rs.Fields("credit").Value) = 0 Then
                Else
                    lvItemPay = lvPayment.Items.Add("K" & rs.Fields("CustomerTransactionID").Value & "_" & databaseName & "_" & rs.Fields("CustomerTransaction_ReferenceID").Value & "_" & rs.Fields("CustomerTransaction_TransactionTypeID").Value, Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "")
                    If lvItemPay.SubItems.Count > 1 Then
                        lvItemPay.SubItems(1).Text = rs.Fields("CustomerTransaction_Reference").Value
                    Else
                        lvItemPay.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("CustomerTransaction_Reference").Value))
                    End If
                    If lvItemPay.SubItems.Count > 2 Then
                        lvItemPay.SubItems(2).Text = rs.Fields("TransactionType_Name").Value
                    Else
                        lvItemPay.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("TransactionType_Name").Value))
                    End If
                    If lvItemPay.SubItems.Count > 3 Then
                        lvItemPay.SubItems(3).Text = FormatNumber(rs.Fields("debit").Value, 4)
                    Else
                        lvItemPay.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("debit").Value, 4)))
                    End If
                    If lvItemPay.SubItems.Count > 4 Then
                        lvItemPay.SubItems(4).Text = FormatNumber(rs.Fields("credit").Value, 4)
                    Else
                        lvItemPay.SubItems.Insert(4, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("credit").Value, 4)))
                    End If
                    If lvItemPay.SubItems.Count > 5 Then
                        lvItemPay.SubItems(5).Text = FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)
                    Else
                        lvItemPay.SubItems.Insert(5, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)))
                    End If
                    If lvItemPay.SubItems.Count > 6 Then
                        lvItemPay.SubItems(6).Text = FormatNumber(IIf((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0, ((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 0 - (rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)
                    Else
                        lvItemPay.SubItems.Insert(6, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(IIf((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0, ((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 0 - (rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)))
                    End If
                End If

            ElseIf rs.Fields("TransactionType_Name").Value = "Settlement" Then
                'If IIf(IsNull(rs("credit")), 0, rs("credit")) >= rs("CustomerTransaction_Allocated") Then
                If IIf(IsDbNull(rs.Fields("credit").Value), 0, rs.Fields("credit").Value) = 0 Then
                Else
                    lvItemPay = lvPayment.Items.Add("K" & rs.Fields("CustomerTransactionID").Value & "_" & databaseName & "_" & rs.Fields("CustomerTransaction_ReferenceID").Value & "_" & rs.Fields("CustomerTransaction_TransactionTypeID").Value, Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "")
                    If lvItemPay.SubItems.Count > 1 Then
                        lvItemPay.SubItems(1).Text = rs.Fields("CustomerTransaction_Reference").Value
                    Else
                        lvItemPay.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("CustomerTransaction_Reference").Value))
                    End If
                    If lvItemPay.SubItems.Count > 2 Then
                        lvItemPay.SubItems(2).Text = rs.Fields("TransactionType_Name").Value
                    Else
                        lvItemPay.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("TransactionType_Name").Value))
                    End If
                    If lvItemPay.SubItems.Count > 3 Then
                        lvItemPay.SubItems(3).Text = FormatNumber(rs.Fields("debit").Value, 4)
                    Else
                        lvItemPay.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("debit").Value, 4)))
                    End If
                    If lvItemPay.SubItems.Count > 4 Then
                        lvItemPay.SubItems(4).Text = FormatNumber(rs.Fields("credit").Value, 4)
                    Else
                        lvItemPay.SubItems.Insert(4, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("credit").Value, 4)))
                    End If
                    If lvItemPay.SubItems.Count > 5 Then
                        lvItemPay.SubItems(5).Text = FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)
                    Else
                        lvItemPay.SubItems.Insert(5, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("CustomerTransaction_Allocated").Value, 4)))
                    End If
                    If lvItemPay.SubItems.Count > 6 Then
                        lvItemPay.SubItems(6).Text = FormatNumber(IIf((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0, ((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 0 - (rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)
                    Else
                        lvItemPay.SubItems.Insert(6, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(IIf((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value) < 0, ((rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 0 - (rs.Fields("credit").Value - rs.Fields("CustomerTransaction_Allocated").Value)), 4)))
                    End If
                End If

            End If
            rs.moveNext()
        Loop
        lvPayment.Visible = True
        'lvPayment.Refresh
        Cursor = System.Windows.Forms.Cursors.Default
        gLoading = False
    End Sub


    Private Sub buildDataControls()
        doDataControl((Me.cmbChannel), "SELECT ChannelID, Channel_Name FROM Channel ORDER BY ChannelID", "Customer_ChannelID", "ChannelID", "Channel_Name")
    End Sub

    Private Sub doDataControl(ByRef dataControl As myDataGridView, ByRef sql As String, ByRef DataField As String, ByRef boundColumn As String, ByRef listField As String)
        Dim rs As ADODB.Recordset
        rs = getRS(sql)
        'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'dataControl.DataSource = rs
        dataControl.DataBindings.Add(adoPrimaryRS)
        dataControl.DataField = DataField
        dataControl.boundColumn = boundColumn
        dataControl.listField = listField
    End Sub
    Public Sub loadItem(ByRef id As Integer)
        Dim oText As System.Windows.Forms.TextBox
        Dim oCheck As System.Windows.Forms.CheckBox
        On Error Resume Next
        gLoading = False

        If id Then
            'checkcustid = id
            adoPrimaryRS = getRS("select * from Customer WHERE CustomerID = " & id)
            cmbTerms.SelectedIndex = adoPrimaryRS.Fields("Customer_Terms").Value
            mbAddNewFlag = False
        Else
            'Set adoPrimaryRS = getRS("select * from Customer")
            'adoPrimaryRS.AddNew
            'Me.Caption = Me.Caption & " [New record]"
            'mbAddNewFlag = True
            'cmbTerms.ListIndex = 0
            'Me.cmbChannel.BoundText = 0
        End If
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
        For Each oText In Me.txtFloat
            oText.DataBindings.Add(adoPrimaryRS)
            If oText.Text = "" Then oText.Text = "0"
            oText.Text = CStr(CDbl(oText.Text) * 100)
            AddHandler oText.Leave, AddressOf txtFloat_Leave
            'txtFloat_Leave(txtFloat.Item((oText.Index)), New System.EventArgs())
        Next oText
        'Bind the check boxes to the data provider
        For Each oCheck In Me.chkFields
            oCheck.DataBindings.Add(adoPrimaryRS)
        Next oCheck
        cmbTerms.DataSource = adoPrimaryRS
        buildDataControls()
        mbDataChanged = False
        If mbAddNewFlag = True Then
            For Each oCheck In Me.chkFields
                oCheck.CheckState = System.Windows.Forms.CheckState.Unchecked
            Next oCheck
            cmbChannel.BoundText = "1"
        End If

        loadData()

        loadLanguage()
        ShowDialog()
        '    End If
    End Sub

    Private Sub cmbChannel_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As KeyEventArgs) Handles cmbChannel.KeyDown
        If mbEditFlag Or mbAddNewFlag Then Exit Sub
        If eventArgs.KeyCode = 27 Then
            'eventArgs = 0
            adoPrimaryRS.Move(0)
            cmdClose_Click(cmdClose, New System.EventArgs())
        End If
    End Sub

    Private Sub cmdShowHistory_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdShowHistory.Click
        Dim i As Integer
        Dim x As Integer
        Dim sql As String
        Dim databaseName As String
        Dim y As Short
        Dim lMonth As Short
        Dim cn As ADODB.Connection
        Dim rs As New ADODB.Recordset

        On Error GoTo ErrShowHistory

        If cmdShowHistory.Text = "&Show Full History" Then
            cmdShowHistory.Text = "&Show Current Month"
        Else
            cmdShowHistory.Text = "&Show Full History"
            cmdsearch_Click(cmdsearch, New System.EventArgs())
            Exit Sub
        End If

        If gLoading Then Exit Sub
        gLoading = True
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        System.Windows.Forms.Application.DoEvents()

        y = cmbMonth.Items.Count - 1
        lvTransaction.Items.Clear()
        lblcount.Text = "0 of 0"
        lvTransaction.Visible = False

        Dim lPosString As String
        Dim lvItem As System.Windows.Forms.ListViewItem
        For i = 0 To y '(cmbMonth.ListCount - 1)

            lMonth = CInt(cmbMonth.Items(i))
            If lMonth = gMonthEnd Then
                databaseName = "pricing.mdb"
            Else
                databaseName = "Month" & lMonth & ".mdb"
            End If

            cn = openConnectionInstance(databaseName)
            If cn Is Nothing Then
                GoTo nextMonth 'Exit Sub
            End If
            'Dim lString As String
            'Dim lCustomerString As String
            'Dim lStockString As String
            If Me.cmbPOS.SelectedIndex Then lPosString = " AND (Sale_PosID=" & cmbPOS.SelectedIndex & ")"

            sql = "SELECT CustomerTransaction.CustomerTransactionID, CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_Reference, CustomerTransaction.CustomerTransaction_PersonName," & " TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" & adoPrimaryRS.Fields("CustomerID").Value & ")) ORDER BY CustomerTransaction.CustomerTransactionID DESC;"
            Debug.Print(sql)
            rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)

            x = 0
            'lvTransaction.Visible = False
            Do Until rs.EOF
                x = x + 1
                If gLoading Then
                Else
                    Exit Do
                End If
                lblcount.Text = x & " of " & rs.RecordCount
                System.Windows.Forms.Application.DoEvents()
                If rs.Fields("CustomerTransaction_Reference").Value <> "Month End" Then
                    lvItem = lvTransaction.Items.Add("K" & rs.Fields("CustomerTransactionID").Value & "_" & databaseName & "_" & rs.Fields("CustomerTransaction_ReferenceID").Value & "_" & rs.Fields("CustomerTransaction_TransactionTypeID").Value, Format(rs.Fields("CustomerTransaction_Date").Value, "yyyy mmm dd hh:mm"), "")
                    If lvItem.SubItems.Count > 1 Then
                        lvItem.SubItems(1).Text = rs.Fields("CustomerTransaction_Reference").Value
                    Else
                        lvItem.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("CustomerTransaction_Reference").Value))
                    End If
                    If lvItem.SubItems.Count > 2 Then
                        lvItem.SubItems(2).Text = rs.Fields("TransactionType_Name").Value
                    Else
                        lvItem.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("TransactionType_Name").Value))
                    End If
                    If lvItem.SubItems.Count > 3 Then
                        lvItem.SubItems(3).Text = FormatNumber(rs.Fields("debit").Value, 4)
                    Else
                        lvItem.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("debit").Value, 4)))
                    End If
                    If lvItem.SubItems.Count > 4 Then
                        lvItem.SubItems(4).Text = FormatNumber(rs.Fields("credit").Value, 4)
                    Else
                        lvItem.SubItems.Insert(4, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("credit").Value, 4)))
                    End If
                End If
                rs.moveNext()
            Loop
            'lvTransaction.Visible = True
            rs.Close()
nextMonth:
        Next

        lvTransaction.Visible = True
        Cursor = System.Windows.Forms.Cursors.Default
        gLoading = False


        Exit Sub
ErrShowHistory:
        If InStr(LCase(Err.Description), "not a valid path") Then
            MsgBox(Err.Number & " - " & Err.Description)
            Exit Sub
        Else
            MsgBox(Err.Number & " - " & Err.Description)
            Exit Sub
        End If
    End Sub

    Private Sub cmdStatement_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStatement.Click
        'On Error Resume Next
        If mbAddNewFlag Then
            MsgBox("There is no statement for a new customer.", MsgBoxStyle.Exclamation, "New Customer")
        Else
            report_CustomerStatement(adoPrimaryRS.Fields("CustomerID").Value)
        End If
    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        'On Error Resume Next
        Dim cn As ADODB.Connection
        Dim x As Short
        Dim databaseName As String
        Dim lID As Integer
        Dim rs As ADODB.Recordset
        Dim rsItems As ADODB.Recordset
        Dim sql As String
        Dim cAlloc As Decimal
        'Screen.MousePointer = vbHourglass

        If bSelectPayment = True Then
        Else
            MsgBox("Select Payment first to continue!")
            Exit Sub
        End If

        If lvTransAlloc.FocusedItem Is Nothing Then
            MsgBox("Select Invoice to Un-Allocated!")
            Exit Sub
        End If

        'If Split(Me.lvTransaction.SelectedItem.Key, "_")(2) = 0 Then MsgBox "There is no Sale document attached!", vbInformation: Screen.MousePointer = vbNormal: Exit Sub
        lID = CInt(Replace(Split(Me.lvTransAlloc.FocusedItem.Name, "_")(0), "K", ""))
        'tempAmount = 0
        'If CCur((0 - lvPayment.SelectedItem.SubItems(6))) = CCur((lvTransaction.SelectedItem.SubItems(6))) Then
        '    tempAmount = CCur((0 - lvPayment.SelectedItem.SubItems(6)))
        'ElseIf CCur((0 - lvPayment.SelectedItem.SubItems(6))) > CCur((lvTransaction.SelectedItem.SubItems(6))) Then
        '    tempAmount = CCur((lvTransaction.SelectedItem.SubItems(6)))
        'ElseIf CCur((0 - lvPayment.SelectedItem.SubItems(6))) < CCur((lvTransaction.SelectedItem.SubItems(6))) Then
        '    tempAmount = CCur((0 - lvPayment.SelectedItem.SubItems(6)))
        'End If

        'If (0 - lvPayment.SelectedItem.SubItems(6)) > 0 Then
        'If (0 - lvPayment.SelectedItem.SubItems(6)) >= lvTransaction.SelectedItem.SubItems(6) Then
        sql = "Select * From CustomerTransactionAlloc Where CustomerTransactionAllocID = " & lID & ";"
        Debug.Print(sql)
        rs = getRS(sql)
        If rs.RecordCount Then
            If MsgBox("Are you sure you wish to Un-Allocate " & vbCrLf & vbCrLf & lvTransAlloc.FocusedItem.SubItems(2).Text & " | " & lvTransAlloc.FocusedItem.Text & " | " & lvTransAlloc.FocusedItem.SubItems(1).Text & " | R " & lvTransAlloc.FocusedItem.SubItems(3).Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                'cnnDB.Execute "UPDATE CustomerTransaction SET CustomerTransaction_Main = 0, CustomerTransaction_Child = 0, CustomerTransaction_Allocated = " & CCur((lvPayment.SelectedItem.SubItems(4))) & " WHERE (((CustomerTransaction.CustomerTransactionID)=" & Replace(Split(Me.lvPayment.SelectedItem.Key, "_")(0), "K", "") & "));"
                cnnDB.Execute("UPDATE CustomerTransaction SET CustomerTransaction_Main = 0, CustomerTransaction_Child = 0, CustomerTransaction_Allocated = CustomerTransaction_Allocated+" & CDec(rs.Fields("CustomerTransactionAlloc_Amount").Value) & " WHERE (((CustomerTransaction.CustomerTransactionID)=" & rs.Fields("CustomerTransactionAlloc_MainID").Value & "));")
                'cnnDB.Execute "UPDATE CustomerTransaction SET CustomerTransaction_Main = " & Replace(Split(Me.lvPayment.SelectedItem.Key, "_")(0), "K", "") & ", CustomerTransaction_Child = 1, CustomerTransaction_Allocated = " & CCur((0 - lvPayment.SelectedItem.SubItems(4))) & " WHERE (((CustomerTransaction.CustomerTransactionID)=" & Replace(Split(Me.lvTransaction.SelectedItem.Key, "_")(0), "K", "") & "));"
                cnnDB.Execute("UPDATE CustomerTransaction SET CustomerTransaction_Main = 0, CustomerTransaction_Child = 0, CustomerTransaction_Allocated = CustomerTransaction_Allocated-" & CDec(rs.Fields("CustomerTransactionAlloc_Amount").Value) & " WHERE (((CustomerTransaction.CustomerTransactionID)=" & rs.Fields("CustomerTransactionAlloc_ChildID").Value & "));")

                sql = "DELETE FROM CustomerTransactionAlloc Where CustomerTransactionAllocID = " & lID & ";"
                cnnDB.Execute(sql)
            End If
        End If
        'Else
        '    MsgBox "Insufficient funds."
        '    Exit Sub
        'End If

        cmdsearch_Click_Payment()
        System.Windows.Forms.Application.DoEvents()
        cmdsearch_Click(cmdsearch, New System.EventArgs())
        System.Windows.Forms.Application.DoEvents()
        cmdsearch_Click_Alloc()
        System.Windows.Forms.Application.DoEvents()
        cmdAllocate.Focus()

        cmdsearch_Click_Payment()
        System.Windows.Forms.Application.DoEvents()
        cmdsearch_Click(cmdsearch, New System.EventArgs())
        System.Windows.Forms.Application.DoEvents()
        cmdsearch_Click_Alloc()
        System.Windows.Forms.Application.DoEvents()
        cmdAllocate.Focus()
    End Sub

    Private Sub frmCustomerAllocPayment_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtFields.AddRange(New TextBox() {_txtFields_0, _txtFields_2, _txtFields_3, _txtFields_4, _
                                          _txtFields_5, _txtFields_6, _txtFields_7, _txtFields_8,
                                          _txtFields_9, _txtFields_10})
        txtFloat.AddRange(New TextBox() {_txtFloat_12, _txtFloat_13, _txtFloat_15, _txtFloat_16, _
                                         _txtFloat_17, _txtFloat_18})
        chkFields.AddRange(New CheckBox() {_chkFields_11, _chkFields_19})
        Dim tb As New TextBox
        For Each tb In txtFields
            AddHandler tb.Enter, AddressOf txtFields_Enter
        Next
        For Each tb In txtFloat
            AddHandler tb.Enter, AddressOf txtFloat_Enter
            AddHandler tb.KeyPress, AddressOf txtFloat_KeyPress
        Next
    End Sub

   Private Sub frmCustomerAllocPayment_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        Dim cmdLast As New Button
        Dim cmdNext As New Button
        Dim lblStatus As New Label
        On Error Resume Next
        lblStatus.Width = pixelToTwips(Me.Width, True) - 1500
        cmdNext.Left = lblStatus.Width + 700
        cmdLast.Left = cmdNext.Left + 340
    End Sub

    Private Sub frmCustomerAllocPayment_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub frmCustomerAllocPayment_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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
            For Each oText In Me.txtFloat
                If oText.Text = "" Then oText.Text = "0"
                oText.Text = oText.Text * 100
                'txtFloat_Leave(txtFloat.Item(oText.Index), New System.EventArgs())
            Next oText
            mbDataChanged = False
        End If
    End Sub

    Private Function update_Renamed() As Boolean
        On Error GoTo UpdateErr
        update_Renamed = True
        If _txtFields_4.Text = "" Then
            MsgBox("A Customer First Name is required.", MsgBoxStyle.Information, "CUSTOMER DETAILS")
            _txtFields_4.Focus()
            update_Renamed = False
            Exit Function
        End If
        If _txtFields_5.Text = "" Then
            MsgBox("A Customer surname Name is required.", MsgBoxStyle.Information, "CUSTOMER DETAILS")
            _txtFields_5.Focus()
            update_Renamed = False
            Exit Function
        End If
        If _txtFields_2.Text = "" Then
            _txtFields_2.Text = _txtFields_4.Text & " " & _txtFields_5.Text
        End If
        adoPrimaryRS.Fields("Customer_Terms").Value = CInt(cmbTerms.Items(cmbTerms.SelectedIndex))
        If mbAddNewFlag Then
            '        adoPrimaryRS.UpdateBatch adAffectAll
            adoPrimaryRS.MoveLast() 'move to the new record
        Else
            adoPrimaryRS.Move(0)
        End If
        adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll)

        mbEditFlag = False
        mbAddNewFlag = False
        mbDataChanged = False

        Exit Function
UpdateErr:
        MsgBox(Err.Description)
        '    update = False
    End Function

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        cmdClose.Focus()
        System.Windows.Forms.Application.DoEvents()
        '    update
        If update_Renamed() Then
            Me.Close()
        End If
    End Sub

    Private Sub lvPayment_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvPayment.Click
        If lvPayment.FocusedItem Is Nothing Then
            'MsgBox "Select Invoice to be Allocated!"
            Exit Sub
        End If
        cmdsearch_Click_AllocByID(CInt(Replace(Split(Me.lvPayment.FocusedItem.Name, "_")(0), "K", "")))
    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
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

    Private Sub txtFloat_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Integer
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Index = GetIndexer(txtBox, txtFloat)
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
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Index = GetIndexer(txtBox, txtFloat)
        MyLostFocus(txtFloat(Index), 2)
    End Sub



    Private Sub printTransactionA4(ByRef lTransaction As transaction)
        Dim typeQuote As String
        Dim typeAccountPayment As String
        Dim typeConsignment As String
        Dim typeConsignmentReturn As String
        Dim typeAccountSaleCOD As String
        Dim typeAccountSale As String
        Dim lRetVal As Integer
        Dim hkey As Integer
        Dim vValue As String
        Dim lnVat As Decimal
        Dim gPath As String
        Dim rs As ADODB.Recordset
       Dim customer_Renamed As customer
        Dim sql As String
        Dim rsNew As New ADODB.Recordset
        'Dim rsNew2                  As New Recordset

        Dim lineitem_Renamed As lineItem
        Dim lString As String
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim lPaymentType As Short
        Dim lArray As String()
        Dim TCurrency As Decimal

        Dim QuoteTotal As Decimal

        On Error GoTo ptA4
        'Set which invoice is required
        Dim sPrintGST As String
        sPrintGST = ""
        QuoteTotal = 0
        'lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\4POS\pos", 0, KEY_QUERY_VALUE, hkey)
        'lRetVal = QueryValueEx(hkey, "printGST", sPrintGST)
        'RegCloseKey (hkey)
        'If sPrintGST = "" Then sPrintGST = "0"

        ' If gParameters.A4Exclusive = True Then
        '     Set Report = New cryReceipt1
        ' ElseIf sPrintGST = "1" Then
        '     Set Report = New cryReceipt1
        ' Else
        Report.Load("cryReceipt.rpt")
        ' End If

        'lPaymentType = getPaymentType(lTransaction)

        'If lPaymentType And typeAccountPayment Then
        '    printTransactionPaymentA4 lTransaction
        '    Exit Sub
        'End If
        'Dim lnVat               As Currency
        gPath = "C:\4POS\pos\"
        Dim lVatAmount As Integer
        Dim lAmount As Integer

        rsNew.Open(gPath & "data\item.rs", , ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic) ', adOpenStatic, adLockOptimistic
        lnVat = 0
        'a = rsNew.RecordCount
        'rsNew.Close

        'rsNew2.source = rsNew.source

        'rsNew("transactionItem_quantity").Type = rsNew("transactionItem_price").Type
        'rsNew("transactionItem_quantity").DefinedSize = rsNew("transactionItem_price").DefinedSize
        'rsNew2("transactionItem_quantity").Attributes = rsNew("transactionItem_price").Attributes
        'rsNew2("transactionItem_quantity").NumericScale = rsNew("transactionItem_price").NumericScale
        'rsNew2("transactionItem_quantity").Precision = rsNew("transactionItem_price").Precision


        For Each lineitem_Renamed In lTransaction.lineItems
            rsNew.AddNew()
            If lineitem_Renamed.revoke Then
            Else
                rsNew.Fields("transactionItem_build").Value = lineitem_Renamed.build
                rsNew.Fields("transactionItem_code").Value = lineitem_Renamed.code
                rsNew.Fields("transactionItem_depositType").Value = lineitem_Renamed.depositType
                rsNew.Fields("transactionItem_id").Value = lineitem_Renamed.id
                rsNew.Fields("transactionItem_lineNo").Value = lineitem_Renamed.lineNo
                rsNew.Fields("transactionItem_name").Value = lineitem_Renamed.name
                rsNew.Fields("transactionItem_originalPrice").Value = lineitem_Renamed.originalPrice
                rsNew.Fields("transactionItem_price").Value = lineitem_Renamed.price
                rsNew.Fields("transactionItem_quantity").Value = lineitem_Renamed.quantity
                rsNew.Fields("transactionItem_receiptName").Value = LTrim(Mid(lineitem_Renamed.receiptName, InStr(1, lineitem_Renamed.receiptName, "x") + 1, Len(lineitem_Renamed.receiptName))) 'lineitem.receiptName
                rsNew.Fields("transactionItem_reversal").Value = lineitem_Renamed.reversal
                rsNew.Fields("transactionItem_revoke").Value = lineitem_Renamed.revoke
                rsNew.Fields("transactionItem_set").Value = lineitem_Renamed.setBuild
                rsNew.Fields("transactionItem_shrink").Value = lineitem_Renamed.shrink
                rsNew.Fields("transactionItem_type").Value = lineitem_Renamed.transactionType
                rsNew.Fields("transactionItem_vat").Value = lineitem_Renamed.vat

                If lineitem_Renamed.vat > 0 Then lnVat = lnVat + ((lineitem_Renamed.quantity * lineitem_Renamed.price) - ((lineitem_Renamed.quantity * lineitem_Renamed.price) / (1 + (lineitem_Renamed.vat / 100))))
                QuoteTotal = QuoteTotal + (lineitem_Renamed.quantity * lineitem_Renamed.price)
                'If gParameters.A4Exclusive = True Then TCurrency = TCurrency + ((lineitem.quantity * lineitem.price) / (1 + (lineitem.vat) / 100))
                'TCurrency = 0 'TCurrency + ((lineitem.quantity * lineitem.price) / (1 + (lineitem.vat) / 100))
                rsNew.update()
            End If
        Next lineitem_Renamed

        'rsNew.MoveFirst
        'vValue = rsNew("transactionItem_quantity")
        vValue = ""
        lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\4POS\pos", 0, KEY_QUERY_VALUE, hkey)
       lRetVal = QueryValueEx(hkey, "A4Items", vValue)
        RegCloseKey(hkey)
        If vValue = "" Then vValue = "0"
        If vValue = "1" Then
            rsNew.Sort = "transactionItem_receiptName"
        ElseIf vValue = "0" Then
        End If

        Report.Database.Tables(1).SetDataSource(rsNew)
        'Report.Database.Tables(2).SetDataSource rsNew, 3
        Report.SetParameterValue("txtCompanyName", lTransaction.companyName)
        Report.SetParameterValue("txtCompanyDetails1", lTransaction.heading1)

        If lTransaction.heading2 <> "" Then
            Report.SetParameterValue("txtCompanyDetails2", lTransaction.heading2)
            If lTransaction.heading3 <> "" Then
                Report.SetParameterValue("txtCompanyDetails3", lTransaction.heading3)

                'If gParameters.tr_PrintInvoice = False Then
                If lTransaction.taxNumber <> "" Then
                    Report.SetParameterValue("txtCompanyDetails4", "TAX NO :" & lTransaction.taxNumber)
                End If
                'End If
            Else
                'If gParameters.tr_PrintInvoice = False Then
                If lTransaction.taxNumber <> "" Then
                    Report.SetParameterValue("txtCompanyDetails3", "TAX NO :" & lTransaction.taxNumber)
                End If
                'End If
            End If
        Else
            If lTransaction.heading3 <> "" Then
                Report.SetParameterValue("txtCompanyDetails2", lTransaction.heading3)
                'If gParameters.tr_PrintInvoice = False Then
                If lTransaction.taxNumber <> "" Then
                    Report.SetParameterValue("txtCompanyDetails3", "TAX NO :" & lTransaction.taxNumber)
                End If
                'End If

            Else
                'If gParameters.tr_PrintInvoice = False Then
                If lTransaction.taxNumber <> "" Then
                    Report.SetParameterValue("txtCompanyDetails2", "TAX NO :" & lTransaction.taxNumber)
                End If
                'End If
            End If
        End If

        lString = lString & lTransaction.heading1 & Chr(13)
        lString = lString & lTransaction.heading2 & Chr(13)
        lString = lString & lTransaction.heading3 & Chr(13)
        If lTransaction.taxNumber <> "" Then lString = lString & "TAX NO :" & lTransaction.taxNumber
        lString = Replace(lString, Chr(13) & Chr(13), Chr(13))
        lString = Replace(lString, Chr(13) & Chr(13), Chr(13))

        Report.SetParameterValue("txtInvoiceNumber", lTransaction.transactionID)
        Report.SetParameterValue("txtInvoiceDate", Format(lTransaction.transactionDate, "dd mmm yyyy hh:mm"))
        Report.SetParameterValue("txtPOS", lTransaction.posName)
        Report.SetParameterValue("txtCashier", lTransaction.cashierName)
        If LCase(lTransaction.transactionType) = "deposit credit" Then
            Report.SetParameterValue("txtType", "DEPOSIT CREDIT")
            Report.SetParameterValue("txtTypeSpecial", "")
            Report.SetParameterValue("txtInvoiceNumber", "[" & lTransaction.transactionID & "]")
        Else
            If lTransaction.transactionSpecial_Renamed Is Nothing Then
                If lTransaction.customer_Renamed Is Nothing Then
                    Report.SetParameterValue("txtCustomer", "Cash Sale")
                    Select Case lTransaction.paymentType
                        Case CStr(1)
                            Report.SetParameterValue("txtCustomer", "Cash Sale")
                        Case CStr(2)
                            Report.SetParameterValue("txtCustomer", "Credit Card Sale")
                        Case CStr(3)
                            Report.SetParameterValue("txtCustomer", "Debit Card Sale")
                        Case CStr(4)
                            Report.SetParameterValue("txtCustomer", "Cheque Sale")
                        Case CStr(7)
                            Report.SetParameterValue("txtCustomer", "Split Tender")
                        Case Else
                            Report.SetParameterValue("txtCustomer", "Cash Sale")
                    End Select
                    Report.SetParameterValue("txtType", "TAX INVOICE")
                    Report.SetParameterValue("txtTypeSpecial", "")
                Else
                    Report.SetParameterValue("txtSigned", lTransaction.customer_Renamed.signed_Renamed)
                    Report.SetParameterValue("txtCustomer", lTransaction.customer_Renamed.name)
                    If lTransaction.customer_Renamed.physical <> "" Then
                        lArray = Split(lTransaction.customer_Renamed.physical, vbCrLf)
                        Report.SetParameterValue("txtCustAddress1", lArray(0))
                        If UBound(lArray) >= 1 Then Report.SetParameterValue("txtCustAddress2", lArray(1))
                        If UBound(lArray) >= 2 Then Report.SetParameterValue("txtCustAddress3", lArray(2))
                        If UBound(lArray) >= 3 Then Report.SetParameterValue("txtCustAddress4", lArray(3))

                    End If
                    If lTransaction.customer_Renamed.tax <> "" Then Report.SetParameterValue("txtCustAddress5", "TAX NO: " & lTransaction.customer_Renamed.tax)
                    'Report.txtCustomerAddress.SetText lTransaction.customer.name & Chr(13) & Chr(13) & Replace(lTransaction.customer.physical, Chr(10), "") & Chr(13) & Chr(13) & "TAX NO: " & lTransaction.customer.tax
                    Report.SetParameterValue("txtType", "TAX INVOICE")
                    If lTransaction.customer_Renamed.terms Then
                        Report.SetParameterValue("txtTypeSpecial", "Account Sale")
                    Else
                        Report.SetParameterValue("txtTypeSpecial", "Cash Sale")
                    End If
                End If
            Else
                Report.SetParameterValue("txtType", "")
                Report.SetParameterValue("txtTypeSpecial", "")
                If lPaymentType And typeQuote Then
                    Report.SetParameterValue("txtType", "QUOTE")
                    If lPaymentType And typeConsignment Then
                        If lPaymentType And typeAccountSale Or lPaymentType And typeAccountSaleCOD Then
                            Report.SetParameterValue("txtTypeSpecial", "Account Consignment")
                        Else
                            Report.SetParameterValue("txtTypeSpecial", "Consignment")
                        End If
                    ElseIf lPaymentType And typeConsignmentReturn Then
                        If lPaymentType And typeAccountSale Or lPaymentType And typeAccountSaleCOD Then
                            Report.SetParameterValue("txtTypeSpecial", "Account Consignment Return Quote")
                        Else
                            Report.SetParameterValue("txtTypeSpecial", "Consignment Return")
                        End If
                    Else
                        If lPaymentType And typeAccountSale Or lPaymentType And typeAccountSaleCOD Then
                            Report.SetParameterValue("txtTypeSpecial", "Account")
                        Else
                            Report.SetParameterValue("txtTypeSpecial", "")
                        End If
                    End If
                ElseIf lPaymentType And typeConsignment Then
                    If lPaymentType And typeAccountSale Or lPaymentType And typeAccountSaleCOD Then
                        Report.SetParameterValue("txtType", "Account Consignment Sale")
                    Else
                        Report.SetParameterValue("txtType", "Consignment Sale")
                    End If
                ElseIf lPaymentType And typeConsignmentReturn Then
                    If lPaymentType And typeAccountSale Or lPaymentType And typeAccountSaleCOD Then
                        Report.SetParameterValue("txtType", "Account Consignment Return")
                    Else
                        Report.SetParameterValue("txtType", "Consignment Return")
                    End If
                ElseIf lPaymentType And typeAccountSale Then
                    Report.SetParameterValue("txtType", "Account Sale")
                ElseIf lPaymentType And typeAccountPayment Then
                    Report.SetParameterValue("txtType", "Account Payment")
                End If

                If lTransaction.customer_Renamed Is Nothing Then
                    If lTransaction.transactionSpecial_Renamed.address <> "" Then
                        lArray = Split(lTransaction.transactionSpecial_Renamed.address, vbCrLf)
                        Report.SetParameterValue("txtCustAddress1", lArray(0))
                        If UBound(lArray) >= 1 Then Report.SetParameterValue("txtCustAddress2", lArray(1))
                        If UBound(lArray) >= 2 Then Report.SetParameterValue("txtCustAddress3", lArray(2))
                        If UBound(lArray) >= 3 Then Report.SetParameterValue("txtCustAddress4", lArray(3))

                    End If
                    Report.SetParameterValue("txtSigned", lTransaction.transactionSpecial_Renamed.name)
                    Report.SetParameterValue("txtCustomer", lTransaction.transactionSpecial_Renamed.name)
                Else
                    If lTransaction.customer_Renamed.tax <> "" Then lTransaction.customer_Renamed.physical = lTransaction.customer_Renamed.physical
                    If lTransaction.customer_Renamed.physical <> "" Then
                        lArray = Split(lTransaction.customer_Renamed.physical, vbCrLf)
                        Report.SetParameterValue("txtCustAddress1", lArray(0))
                        If UBound(lArray) >= 1 Then Report.SetParameterValue("txtCustAddress2", lArray(1))
                        If UBound(lArray) >= 2 Then Report.SetParameterValue("txtCustAddress3", lArray(2))
                        If UBound(lArray) >= 3 Then Report.SetParameterValue("txtCustAddress4", lArray(3))
                    End If
                    Report.SetParameterValue("txtSigned.", lTransaction.customer_Renamed.signed_Renamed)
                    Report.SetParameterValue("txtCustomer", lTransaction.customer_Renamed.name)
                End If
            End If
        End If
        'do report reference.....
        If lTransaction.CardRefer <> "" Then
            Report.SetParameterValue("txtCard", "Card Reference : " & lTransaction.CardRefer)
            'ElseIf gParameters.CardRefer = True Then
            '    Report.txtCard.SetText "Card Reference : " & stCard
        End If

        If lTransaction.OrderRefer <> "" Then
            Report.SetParameterValue("txtOrder", "Order Reference : " & lTransaction.OrderRefer)
            'ElseIf gParameters.OrderRefer = True Then
            '    Report.txtOrder.SetText "Order Reference : " & stOrder
        End If

        If lTransaction.SerialRefer <> "" Then
            Report.SetParameterValue("txtSerial", "Serial Reference : " & lTransaction.SerialRefer)
            'ElseIf gParameters.SerialRefer = True Then
            '    Report.txtSerial.SetText "Serial Reference : " & stSerial
        End If

        Report.SetParameterValue("txtDiscount", FormatNumber(lTransaction.paymentDiscount, 2))
        'If gParameters.A4Exclusive = True Then
        '   Report.txtAText.SetText FormatNumber(TCurrency - lTransaction.paymentDiscount, 2)
        'End If

        'If frmMain.lblChange.Caption = "" Then frmMain.lblChange.Caption = "0.00"

        If lPaymentType And typeQuote Then
            Report.SetParameterValue("txtTender", FormatNumber("0.00", 2))
        Else
            Report.SetParameterValue("txtTender", FormatNumber(lTransaction.paymentTender, 2)) '  lTransaction.paymentTender, 2)
        End If
        Report.SetParameterValue("txtVAT", FormatNumber(lnVat, 2))
        Report.SetParameterValue("txtChange", FormatNumber("0.00", 2))

        'Report.txtTotal.SetText FormatNumber(lTransaction.paymentTotal, 2)
        If lPaymentType And typeQuote Then
            'FIXED: it was calculating twice    Report.txtTotal.SetText FormatNumber((QuoteTotal - lTransaction.paymentDiscount), 2)
            Report.SetParameterValue("txtTotal", FormatNumber(QuoteTotal, 2))
            'a = QuoteTotal
        Else
            Report.SetParameterValue("txtTotal", FormatNumber(lTransaction.paymentTotal, 2))
        End If

        If lPaymentType And typeQuote Or lPaymentType And typeConsignment Or lPaymentType And typeConsignmentReturn Or lPaymentType And typeAccountSale Then
            Report.ReportDefinition.Sections("Section7").SectionFormat.EnableSuppress = True
        End If

        'New banking details
        Dim rsCompBank As ADODB.Recordset
        rsCompBank = getRS("select * from Company;")
        If rsCompBank.RecordCount Then
            If IsDbNull(rsCompBank.Fields("Company_BankName").Value) Then
            Else
                Report.SetParameterValue("txtBankName", rsCompBank.Fields("Company_BankName"))
            End If
            If IsDbNull(rsCompBank.Fields("Company_BranchName").Value) Then
            Else
                Report.SetParameterValue("txtBranchName", rsCompBank.Fields("Company_BranchName"))
            End If
            If IsDbNull(rsCompBank.Fields("Company_BranchCode").Value) Then
            Else
                Report.SetParameterValue("txtBranchCode", rsCompBank.Fields("Company_BranchCode"))
            End If
            If IsDbNull(rsCompBank.Fields("Company_AccountNumber").Value) Then
            Else
                Report.SetParameterValue("txtAccountNumber", rsCompBank.Fields("Company_AccountNumber"))
            End If
        End If
        '...................

        'Report.selectPrinter "", Printer.DeviceName, ""
        ''Report.VerifyOnEveryPrint = True
        'Report.PrintOut False
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        frmReportShow.ShowDialog()

        Exit Sub
ptA4:
        MsgBox(Err.Number & Err.Description)
        Resume Next
    End Sub
End Class