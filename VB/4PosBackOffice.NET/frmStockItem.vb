Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmStockItem
	Inherits System.Windows.Forms.Form
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim gRSpriceSet As ADODB.Recordset
	Dim mbChangedByCode As Boolean
    Dim mvBookMark As Integer
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
	
	Dim gID As Integer
	Dim gUpdate As Boolean
	Dim ChkC As Boolean

    Dim txtInteger As New List(Of TextBox)
    Dim txtFloat As New List(Of TextBox)
    Dim txtFields As New List(Of TextBox)
    Dim chkFields As New List(Of CheckBox)
    Dim Frame1 As New List(Of GroupBox)
    Dim optRecipeType As New List(Of RadioButton)
    Dim cmdNew As New List(Of Button)
    Dim cmdMove As New List(Of Button)

	Private Sub buildDataControls()
		doDataControl((Me.cmbShrink), "SELECT ShrinkID, Shrink_Name FROM Shrink ORDER BY Shrink_Name", "StockItem_ShrinkID", "ShrinkID", "Shrink_Name")
		doDataControl((Me.cmbPricingGroup), "SELECT PricingGroupID, PricingGroup_Name FROM PricingGroup WHERE PricingGroup_Disabled = 0 ORDER BY PricingGroup_Name", "StockItem_PricingGroupID", "PricingGroupID", "PricingGroup_Name")
		doDataControl((Me.cmbSupplier), "SELECT SupplierID, Supplier_Name FROM Supplier WHERE Supplier_Disabled=False ORDER BY Supplier_Name", "StockItem_SupplierID", "SupplierID", "Supplier_Name")
		doDataControl((Me.cmbVat), "SELECT VatID, Vat_Name FROM Vat ORDER BY Vat_Name", "StockItem_VatID", "VatID", "Vat_Name")
		doDataControl((Me.cmbDeposit), "SELECT DepositID, Deposit_Name FROM Deposit WHERE Deposit_Disabled=False ORDER BY Deposit_Name", "StockItem_DepositID", "DepositID", "Deposit_Name")
		doDataControl((Me.cmbStockGroup), "SELECT StockGroupID, StockGroup_Name FROM StockGroup WHERE StockGroup_Disabled=False ORDER BY StockGroup_Name", "StockItem_StockGroupID", "StockGroupID", "StockGroup_Name")
		doDataControl((Me.cmbPriceSet), "SELECT PriceSet.PriceSetID, [PriceSet_Name] & '(' & [StockItem_Name] & ')' AS priceSet_FullName FROM PriceSet INNER JOIN StockItem ON PriceSet.PriceSet_StockItemID = StockItem.StockItemID Where (((PriceSet.PriceSet_Disabled) = 0)) ORDER BY PriceSet.PriceSet_Name;", "StockItem_PriceSetID", "PriceSetID", "priceSet_FullName")
		doDataControl((Me.cmbPrintLocation), "SELECT PrintLocation.* From PrintLocation WHERE (((PrintLocation.PrintLocation_Disabled)=False));", "StockItem_PrintLocationID", "PrintLocationID", "PrintLocation_Name")
		doDataControl((Me.cmbPrintGroup), "SELECT PrintGroupID, PrintGroup_Name FROM PrintGroup ORDER BY PrintGroup_Name", "StockItem_PrintGroupID", "PrintGroupID", "PrintGroup_Name")
		'for report group
		doDataControl((Me.cmbReportGroup), "SELECT ReportID,ReportGroup_Name FROM ReportGroup WHERE ReportGroup_Disabled = False ORDER BY ReportGroup_Name", "StockItem_ReportID", "ReportID", "ReportGroup_Name")
		'for pack size
		doDataControl((Me.cmbPackSize), "SELECT PackSizeID, PackSize_Name FROM PackSize ORDER BY PackSize_Name", "StockItem_PackSizeID", "PackSizeID", "PackSize_Name")
		
		'doDataControl Me.cmbReportGroup, "SELECT ReportID,ReportGroup_Name FROM ReportGroup WHERE ReportGroup_Disable = False ORDER BY ReportGroup_Name", "StockItem_ReportID", "ReportID", "ReportGroup_Name"
	End Sub
	
    Private Sub doDataControl(ByRef dataControl As myDataGridView, ByRef sql As String, ByRef DataField As String, ByRef boundColumn As String, ByRef listField As String)
        Dim rs As ADODB.Recordset

        rs = getRS(sql)
        dataControl.DataSource = rs
        dataControl.DataSource = adoPrimaryRS
        dataControl.DataField = DataField
        dataControl.boundColumn = boundColumn
        dataControl.listField = listField
    End Sub
	Public Sub loadItem(ByRef id As Integer)
		Dim sql As String
		Dim InSt As String
		Dim oText As System.Windows.Forms.TextBox
		Dim lItem As System.Windows.Forms.ListViewItem
		Dim oCheck As System.Windows.Forms.CheckBox
		Dim rsj As ADODB.Recordset
		Dim rs As ADODB.Recordset
		Dim InStc As String
		Dim d_Sold As String
		Dim j As Short
		Dim sql1 As String
		Dim rsN As ADODB.Recordset
		Dim Insk As String
		Dim Rsp1 As ADODB.Recordset
		Dim rsSerial As ADODB.Recordset
		
		On Error Resume Next
		rs = getRS("SELECT StockitemOverwrite.StockitemOverwriteID From StockitemOverwrite WHERE (((StockitemOverwrite.StockitemOverwriteID)=" & id & "));")
		If rs.RecordCount Then Me.chkSQ.CheckState = System.Windows.Forms.CheckState.Checked Else chkSQ.CheckState = System.Windows.Forms.CheckState.Unchecked
		rs.Close()
		adoPrimaryRS = getRS("SELECT * FROM StockItem WHERE StockItemID = " & id)
		
		If adoPrimaryRS.BOF Or adoPrimaryRS.EOF Then
		Else
			gID = id
			If adoPrimaryRS.Fields("StockItem_OrderQuantity").Value = adoPrimaryRS.Fields("StockItem_Quantity").Value Then
				Me.cmbReorder.SelectedIndex = 1
			Else
				Me.cmbReorder.SelectedIndex = 0
			End If
			If adoPrimaryRS.Fields("StockItemOrderType").Value = 1 Then Me.cmbReorder.SelectedIndex = 1 Else Me.cmbReorder.SelectedIndex = 0
			
			For	Each oText In Me.txtFields
				oText.DataBindings.Add(adoPrimaryRS)
                oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize
			Next oText
			For	Each oText In Me.txtInteger
                oText.DataBindings.Add(adoPrimaryRS)
                AddHandler oText.Leave, AddressOf txtInteger_Leave
			Next oText
			For	Each oText In Me.txtFloat
				oText.DataBindings.Add(adoPrimaryRS)
                oText.Text = CStr(CDbl(oText.Text) * 100)
                AddHandler oText.Leave, AddressOf txtFloat_Leave
			Next oText
			'Bind the check boxes to the data provider
			For	Each oCheck In Me.chkFields
				oCheck.DataBindings.Add(adoPrimaryRS)
				oCheck.Tag = oCheck.CheckState
			Next oCheck
			buildDataControls()
			
			If cmbPriceSet.BoundText = "" Then
				chkPriceSet.CheckState = System.Windows.Forms.CheckState.Unchecked
			Else
				chkPriceSet.CheckState = System.Windows.Forms.CheckState.Checked
			End If
			
			'New Serial Tracker Code.....
            If adoPrimaryRS.Fields("StockItem_SerialTracker").Value Then _chkFields_1.Tag = 1 Else _chkFields_1.Tag = 0
            If adoPrimaryRS.Fields("StockItem_ATItem").Value Then _chkFields_6.Tag = 1 Else _chkFields_6.Tag = 0

            'Shelf & Barcode printing
            '  If IsNull(adoPrimaryRS("StockItem_SBarcode")) Then
            '   OptPrint(2).value = True
            'If LCase(adoPrimaryRS("StockItem_SBarcode")) = "shelf" Then
            '   optPrint(0).value = True
            'ElseIf LCase(adoPrimaryRS("StockItem_SBarcode")) = "barcode" Then
            '   optPrint(1).value = True
            'End If

            '* Shelf and barcode printing
            If CBool(LCase(adoPrimaryRS.Fields("StockItem_SShelf").Value)) = True And CBool(LCase(adoPrimaryRS.Fields("StockItem_SBarcode").Value)) = True Then
                chkshelf.CheckState = System.Windows.Forms.CheckState.Checked
                chkbarcode.CheckState = System.Windows.Forms.CheckState.Checked

            ElseIf CBool(LCase(adoPrimaryRS.Fields("StockItem_SShelf").Value)) = True And CBool(LCase(adoPrimaryRS.Fields("StockItem_SBarcode").Value)) = False Then
                chkshelf.CheckState = System.Windows.Forms.CheckState.Checked
                chkbarcode.CheckState = System.Windows.Forms.CheckState.Unchecked

            ElseIf CBool(LCase(adoPrimaryRS.Fields("StockItem_SBarcode").Value)) = True And CBool(LCase(adoPrimaryRS.Fields("StockItem_SShelf").Value)) = False Then
                chkbarcode.CheckState = System.Windows.Forms.CheckState.Checked
                chkshelf.CheckState = System.Windows.Forms.CheckState.Unchecked

            ElseIf CBool(LCase(adoPrimaryRS.Fields("StockItem_SShelf").Value)) = False And CBool(LCase(adoPrimaryRS.Fields("StockItem_SBarcode").Value)) = False Then
                chkshelf.CheckState = System.Windows.Forms.CheckState.Unchecked
                chkbarcode.CheckState = System.Windows.Forms.CheckState.Unchecked

            ElseIf CBool(LCase(adoPrimaryRS.Fields("StockItem_SShelf").Value)) = False Then
                chkshelf.CheckState = System.Windows.Forms.CheckState.Unchecked

            ElseIf CBool(LCase(adoPrimaryRS.Fields("StockItem_SBarcode").Value)) = False Then
                chkbarcode.CheckState = System.Windows.Forms.CheckState.Unchecked
            End If
            '*

            mbDataChanged = False
            With FGRecipe
                .Visible = False
                .RowCount = 1
                .Col = 4
                .Col = 0
                .row = 0
                .Text = "Product"
                .set_ColAlignment(0, 1)
                .set_ColWidth(0, 2000)
                .CellFontBold = True
                .Col = 1
                .Text = "Total Cost"
                .set_ColAlignment(1, 7)
                .set_ColWidth(1, 1000)
                .CellFontBold = True
                .Col = 2
                .Text = "Quantity"
                .set_ColAlignment(2, 7)
                .set_ColWidth(2, 750)
                .CellFontBold = True
                .Col = 3
                .Text = "Line Cost"
                .set_ColAlignment(3, 7)
                .set_ColWidth(3, 1000)
                .CellFontBold = True
                .Visible = Not Me._optRecipeType_0.Checked
            End With

            If _txtFields_1.Text = "" Then _txtFields_1.Text = CStr(0)

            optRecipeType(CShort(_txtFields_1.Text)).Checked = True
            loadRecipe()

            loadMessage()
            loadTree()

            'Assing serial number
            sql = "SELECT * FROM SerialTracking WHERE Serial_StockItemID = " & id

            If adoPrimaryRS.Fields("StockItem_SerialTracker").Value Then
                rsSerial = getRS("SELECT * FROM SerialTracking WHERE Serial_StockItemID = " & id)

                'Get serial Details...
                If rsSerial.RecordCount > 0 Then
                    Do While rsSerial.EOF = False
                        lItem = lstvSerial.Items.Add(rsSerial.Fields("Serial_SerialNumber").Value)
                        If Rsp1.RecordCount > 0 Then
                            lItem.SubItems.Add(rsSerial.Fields("Serial_SupplierName").Value)
                        Else
                            lItem.SubItems.Add("Default Suppier")
                        End If
                        lItem.SubItems.Add(rsSerial.Fields("Serial_DatePurchases").Value)
                        'If rsSerial("Serial_Instock") = True Then
                        If rsSerial.Fields("Serial_Instock").Value = True Or rsSerial.Fields("Serial_Status").Value = "Returned" Then
                            InStc = "No"
                            d_Sold = Str(rsSerial.Fields("Serial_DateSold").Value)
                            Insk = rsSerial.Fields("Serial_InvoiceNumber").Value
                        Else
                            InStc = "Yes"
                        End If
                        lItem.SubItems.Add(InStc)
                        lItem.SubItems.Add(d_Sold)
                        lItem.SubItems.Add(Insk)
                        d_Sold = ""
                        Insk = ""

                        rsSerial.MoveNext()
                    Loop
                    cmbShrink.Enabled = False
                End If
            End If

            'Stock item found
        End If
    End Sub

    Private Sub cmdUpdate_Click()
        update_Renamed()
    End Sub

    'UPGRADE_WARNING: Event chkFields.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub chkFields_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles chkFields.CheckStateChanged
        Dim chk As New CheckBox
        chk = DirectCast(eventSender, CheckBox)
        Dim Index As Integer = GetIndexer(chk, chkFields)
        If Index = 13 Then
            If _chkFields_12.CheckState = 1 And _chkFields_13.CheckState = 1 Then
                blNextItem = True
                'ElseIf _chkFields_12.value = 1 And _chkFields_12.value = 1 Then
                'ElseIf _chkFields_12.value = 1 And _chkFields_12.value = 1 Then
            Else
                blNextItem = False
            End If

        End If
    End Sub

    'UPGRADE_WARNING: Event chkPriceSet.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub chkPriceSet_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkPriceSet.CheckStateChanged
        If chkPriceSet.CheckState = 1 Then
            If gRSpriceSet Is Nothing Then
            Else
                If gRSpriceSet.Fields("StockItemID").Value = adoPrimaryRS.Fields("StockItemID").Value Then
                    _txtInteger_0.Enabled = True
                    _txtFloat_0.Enabled = True
                    _txtFloat_1.Enabled = True
                    _txtInteger_0.Enabled = True
                    cmbDeposit.Enabled = True
                    cmbPricingGroup.Enabled = True
                    cmbShrink.Enabled = True
                    cmbVat.Enabled = True
                    cmbPriceSet.Enabled = False
                    chkPriceSet.Enabled = False
                    lblPriceSet.Text = "Primary Pricing Set Item"
                    lblPriceSet.Visible = True
                    lblPriceSet.BackColor = System.Drawing.Color.Red
                    lblPriceSet.ForeColor = System.Drawing.Color.White
                    Exit Sub
                End If
            End If
            _txtInteger_0.Enabled = False
            _txtFloat_0.Enabled = False
            _txtFloat_1.Enabled = False
            _txtInteger_0.Enabled = False

            cmbDeposit.Enabled = False
            cmbPricingGroup.Enabled = False
            cmbShrink.Enabled = False
            cmbVat.Enabled = False

            cmbPriceSet.Enabled = True
            lblPriceSet.Text = "Child Pricing Set Item"
            lblPriceSet.Visible = True
            lblPriceSet.BackColor = System.Drawing.Color.Yellow
            lblPriceSet.ForeColor = System.Drawing.Color.Black
        Else
            _txtInteger_0.Enabled = True
            _txtFloat_0.Enabled = True
            _txtFloat_1.Enabled = True

            cmbDeposit.Enabled = True
            cmbPricingGroup.Enabled = True
            cmbShrink.Enabled = True
            cmbVat.Enabled = True
            cmbPriceSet.Enabled = False
            adoPrimaryRS.Fields("StockItem_PriceSetID").Value = 0
            lblPriceSet.Visible = False
        End If
        Exit Sub
        System.Windows.Forms.Application.DoEvents()
        If gRSpriceSet Is Nothing Then
        Else
            If gRSpriceSet.Fields("StockItemID").Value = adoPrimaryRS.Fields("StockItemID").Value Then
                MsgBox("Primary")
                Exit Sub
            End If
        End If
        If cmbPricingGroup.BoundText <> "" Then
            Me.cmbPriceSet.Enabled = True
            _txtInteger_0.Enabled = False
            _txtFloat_0.Enabled = False
            cmbDeposit.Enabled = False
            cmbPricingGroup.Enabled = False
            cmbShrink.Enabled = False
            _chkFields_1.Enabled = False
            '        If gRSpriceSet Is Nothing Then
            '        Else
            '            cmbPricingGroup.BoundText = gRSpriceSet("StockItem_PricingGroupID")
            '        End If
        Else
            Me.cmbPriceSet.Enabled = False
            cmbPriceSet.BoundText = ""
            _txtInteger_0.Enabled = True
            _txtFloat_0.Enabled = True
            cmbDeposit.Enabled = True
            cmbPricingGroup.Enabled = True
            cmbShrink.Enabled = True
            _chkFields_1.Enabled = True
        End If
    End Sub

    Private Sub cmbDeposit_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As KeyEventArgs) Handles cmbDeposit.KeyDown
        If eventArgs.KeyCode = 27 Then
            'eventArgs.KeyCode = 0
            adoPrimaryRS.Move(0)
            cmdClose_Click(cmdClose, New System.EventArgs())
        End If
    End Sub


    Private Sub cmbPackSize_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As KeyEventArgs) Handles cmbPackSize.KeyDown
        If eventArgs.KeyCode = 27 Then
            'eventArgs.KeyCode = 0
            adoPrimaryRS.Move(0)
            cmdClose_Click(cmdClose, New System.EventArgs())
        End If
    End Sub

    Private Sub cmbPriceSet_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbPriceSet.CellValueChanged
        If gUpdate Then Exit Sub
        If cmbPriceSet.BoundText <> "" Then
            gRSpriceSet = getRS("SELECT StockItem.* FROM PriceSet INNER JOIN StockItem ON PriceSet.PriceSet_StockItemID = StockItem.StockItemID WHERE (((PriceSet.PriceSetID)=" & cmbPriceSet.BoundText & "));")
            '        chkPriceSet_Click
        End If
    End Sub

    Private Sub cmbPriceSet_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As KeyEventArgs) Handles cmbPriceSet.KeyDown
        If eventArgs.KeyCode = 27 Then
            'eventArgs.KeyCode = 0
            adoPrimaryRS.Move(0)
            cmdClose_Click(cmdClose, New System.EventArgs())
        End If
    End Sub

    Private Sub cmbPricingGroup_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As KeyEventArgs) Handles cmbPricingGroup.KeyDown
        If eventArgs.KeyCode = 27 Then
            'eventArgs.KeyCode = 0
            adoPrimaryRS.Move(0)
            cmdClose_Click(cmdClose, New System.EventArgs())
        End If
    End Sub



    Private Sub cmbReportGroup_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As KeyEventArgs) Handles cmbReportGroup.KeyDown
        If eventArgs.keyCode = 27 Then
            'eventArgs.keyCode = 0
            update_Renamed()
            '        adoPrimaryRS.Move 0
            cmdClose_Click(cmdClose, New System.EventArgs())
        End If

    End Sub

    Private Sub cmbShrink_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As KeyEventArgs) Handles cmbShrink.KeyDown
        If eventArgs.keyCode = 27 Then
            'eventArgs.keyCode = 0
            adoPrimaryRS.Move(0)
            cmdClose_Click(cmdClose, New System.EventArgs())
        End If
    End Sub

    Private Sub cmbStockGroup_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As KeyEventArgs) Handles cmbStockGroup.KeyDown
        If eventArgs.keyCode = 27 Then
            'eventArgs.keyCode = 0
            update_Renamed()
            '        adoPrimaryRS.Move 0
            cmdClose_Click(cmdClose, New System.EventArgs())
        End If
    End Sub

    Private Sub cmbSupplier_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As KeyEventArgs) Handles cmbSupplier.KeyDown
        If eventArgs.keyCode = 27 Then
            'eventArgs.keyCode = 0
            adoPrimaryRS.Move(0)
            cmdClose_Click(cmdClose, New System.EventArgs())
        End If
    End Sub

    Private Sub cmbVat_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As KeyEventArgs) Handles cmbVat.KeyDown
        If eventArgs.keyCode = 27 Then
            'eventArgs.keyCode = 0
            adoPrimaryRS.Move(0)
            cmdClose_Click(cmdClose, New System.EventArgs())
        End If
    End Sub

    Private Sub cmdbarcodeItem_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdbarcodeItem.Click
        '* Check if Display name is empty and refuses to exit
        If Trim(Me._txtFields_7.Text) = "" Then
            MsgBox("The Display Name TextBox must not be Empty", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information, "Edit Stock Item Details")
            'frmStockItem._txtFields_7.Text = frmStockItem.txtholdname.Text
            Me._txtFields_7.Focus()
            Exit Sub
        ElseIf IsNumeric(Me._txtFields_7.Text) = True Then
            MsgBox("The Display Name TextBox must not be a Number", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information, "Edit Stock Item Details")
            'frmStockItem._txtFields_7.Text = frmStockItem.txtholdname.Text
            Me._txtFields_7.Focus()
            Exit Sub
        ElseIf Trim(Me._txtFields_8.Text) = "" Then
            MsgBox("The Receipt Name TextBox must not be Empty", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information, "Edit Stock Item Details")
            ' frmStockItem._txtFields_8.Text = frmStockItem.txtholdname.Text
            Me._txtFields_8.Focus()
            Exit Sub
        ElseIf IsNumeric(Me._txtFields_8.Text) = True Then
            MsgBox("The Receipt Name TextBox must not be a Number", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information, "Edit Stock Item Details")
            'frmStockItem._txtFields_8.Text = frmStockItem.txtholdname.Text
            Me._txtFields_8.Focus()
            Exit Sub
        End If
        update_Renamed()
        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        '*
        'Here a public function barcode is called.
        Call barcodeItem()
        '*
    End Sub

    Private Sub cmdDeposit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDeposit.Click
        frmDepositList.loadItem(0)
        doDataControl((Me.cmbDeposit), "SELECT DepositID, Deposit_Name FROM Deposit WHERE Deposit_Disabled=False ORDER BY Deposit_Name", "StockItem_DepositID", "DepositID", "Deposit_Name")
    End Sub

    Private Sub cmdDuplicate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDuplicate.Click

        'Here a public function Duplicate_codes_report is called.
        Call Duplicate_codes_report()

    End Sub

    Private Sub cmdHistory_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdHistory.Click
        frmStockItemHistory.loadItem(adoPrimaryRS.Fields("StockItemID").Value)
    End Sub

    Private Sub cmdNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNext.Click
        If frmStockList.Visible = True Then
            If blNextItem = True Then
                cmdClose_Click(cmdClose, New System.EventArgs())
            ElseIf blNextItem = False Then
                cmdClose_Click(cmdClose, New System.EventArgs())
                frmStockList.DataList1_DblClickS()
            End If
        End If
    End Sub

    Private Sub cmdPackSize_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPackSize.Click
        frmPackSizeList.loadItem()
        doDataControl((Me.cmbPackSize), "SELECT PackSizeID, PackSize_Name FROM PackSize ORDER BY PackSize_Name", "StockItem_PackSizeID", "PackSizeID", "PackSize_Name")
    End Sub

    Private Sub cmdpriceselist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdpriceselist.Click
        '* Display frmpricesetlist
        Dim asID As Short
        asID = adoPrimaryRS.Fields("StockItemID").Value

        Me.Hide()
        frmPriceSetList.ShowDialog()

        '*
    End Sub

    Private Sub cmdPricingGroup_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPricingGroup.Click
        frmPricingGroupList.getItem()
        doDataControl((Me.cmbPricingGroup), "SELECT PricingGroupID, PricingGroup_Name FROM PricingGroup ORDER BY PricingGroup_Name", "StockItem_PricingGroupID", "PricingGroupID", "PricingGroup_Name")
    End Sub

    Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
        report_BOM(" WHERE receipeID=" & adoPrimaryRS.Fields("StockItemID").Value)
    End Sub

    Private Sub cmdPrintGroup_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrintGroup.Click
        frmPrintGroupList.getItem()
        doDataControl((Me.cmbPrintGroup), "SELECT PrintGroupID, PrintGroup_Name FROM PrintGroup ORDER BY PrintGroup_Name", "StockItem_PrintGroupID", "PrintGroupID", "PrintGroup_Name")
    End Sub

    Private Sub cmdPrintLocation_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrintLocation.Click
        frmPrintLocationList.getItem()
        doDataControl((Me.cmbPrintLocation), "SELECT PrintLocation.* From PrintLocation WHERE (((PrintLocation.PrintLocation_Disabled)=False));", "StockItem_PrintLocationID", "PrintLocationID", "PrintLocation_Name")
    End Sub

    Private Sub cmdRecipeAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRecipeAdd.Click
        Dim x As Short
        Dim lKey As Integer
        Dim rs As ADODB.Recordset
        lKey = frmStockList2.getItem
        FGRecipe.Visible = False
        System.Windows.Forms.Application.DoEvents()
        FGRecipe.Visible = True
        If lKey <> 0 Then


            If lKey <> adoPrimaryRS.Fields("StockItemID").Value Then
                rs = getRS("SELECT * From RecipeStockitemLnk WHERE (((RecipeStockitemLnk.RecipeStockitemLnk_RecipeID)=" & adoPrimaryRS.Fields("StockItemID").Value & ") AND ((RecipeStockitemLnk.RecipeStockitemLnk_StockitemID)=" & lKey & "));")


                If rs.RecordCount Then
                Else
                    rs.AddNew()
                    rs.Fields("RecipeStockitemLnk_RecipeID").Value = adoPrimaryRS.Fields("StockItemID").Value
                    rs.Fields("RecipeStockitemLnk_StockitemID").Value = lKey
                    rs.Fields("RecipeStockitemLnk_Quantity").Value = 1
                    rs.Update()
                End If

                FGRecipe_LeaveCell(FGRecipe, New System.EventArgs())
                loadRecipe()
                With FGRecipe
                    For x = 1 To .RowCount - 1
                        If FGRecipe.get_RowData(x) = lKey Then
                            .row = x
                            .Col = 2
                            FGRecipe_EnterCell(FGRecipe, New System.EventArgs())
                            Exit For
                        End If
                    Next
                End With
            End If
        End If

    End Sub

    Private Sub cmdReportGroup_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdReportGroup.Click
        frmReportGroupList.loadItem(0)
        doDataControl((Me.cmbReportGroup), "SELECT ReportID, ReportGroup_Name FROM ReportGroup WHERE ReportGroup_Disabled=False ORDER BY ReportGroup_Name", "StockItem_ReportID", "ReportID", "ReportGroup_Name")
        'doDataControl Me.cmbStockGroup, "SELECT StockGroupID, StockGroup_Name FROM StockGroup WHERE StockGroup_Disabled=False ORDER BY StockGroup_Name", "StockItem_StockGroupID", "StockGroupID", "StockGroup_Name"

    End Sub

    Private Sub cmdShrink_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdShrink.Click
        frmShrink.ShowDialog()
        doDataControl((Me.cmbShrink), "SELECT ShrinkID, Shrink_Name FROM Shrink ORDER BY Shrink_Name", "StockItem_ShrinkID", "ShrinkID", "Shrink_Name")
    End Sub

    Private Sub cmdStockGroup_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStockGroup.Click
        frmStockGroupList.loadItem(0)
        doDataControl((Me.cmbStockGroup), "SELECT StockGroupID, StockGroup_Name FROM StockGroup WHERE StockGroup_Disabled=False ORDER BY StockGroup_Name", "StockItem_StockGroupID", "StockGroupID", "StockGroup_Name")
    End Sub

    Private Sub cmdSupplier_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSupplier.Click
        frmSupplierList.loadItem(0)
        doDataControl((Me.cmbSupplier), "SELECT SupplierID, Supplier_Name FROM Supplier WHERE Supplier_Disabled=False ORDER BY Supplier_Name", "StockItem_SupplierID", "SupplierID", "Supplier_Name")
    End Sub

    Private Sub cmdVAT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdVAT.Click
        frmVATList.loadItem()
        doDataControl((Me.cmbVat), "SELECT VatID, Vat_Name FROM Vat ORDER BY Vat_Name", "StockItem_VatID", "VatID", "Vat_Name")
    End Sub
    Public Function Command1_Click() As Object
        '    Command1.SetFocus
        ' DoEvents
        frmStockBarcode.loadItem(adoPrimaryRS.Fields("StockItemID").Value)
        Dim form As New frmStockBarcode
        form.Show()
    End Function

    Private Sub Command2_Click()

    End Sub

    Private Sub FGRecipe_EnterCell(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles FGRecipe.CellEnter
        Dim lString As String
        With FGRecipe
            If .Visible And .Col = 2 Then
                txtQuantity.Left = twipsToPixels(pixelToTwips(.Left, True) + .CellLeft, True)
                txtQuantity.Top = twipsToPixels(pixelToTwips(.Top, False) + .CellTop, False)
                txtQuantity.Width = twipsToPixels(.CellWidth, True)
                txtQuantity.Height = twipsToPixels(.CellHeight, False)
                txtQuantity.Text = .Text
                If txtQuantity.Text = "" Then txtQuantity.Text = "0"
                txtQuantity.Tag = CDec(txtQuantity.Text)
                txtQuantity.SelectionStart = 0
                txtQuantity.SelectionLength = 999
                txtQuantity.Visible = True
                txtQuantity.Focus()
            Else
                txtQuantity.Visible = False
            End If

        End With

    End Sub

    Private Sub FGRecipe_LeaveCell(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles FGRecipe.LeaveCell
        Dim x As Short
        Dim lAmount As Double
        '    On Local Error Resume Next
        If txtQuantity.Visible Then
            If txtQuantity.Text = "" Then txtQuantity.Text = "0"
            FGRecipe.Text = FormatNumber(txtQuantity.Text, 4)

            If CDec(txtQuantity.Text) <> CDec(txtQuantity.Tag) Then
                If CDec(txtQuantity.Text) = 0 Then
                    txtQuantity.Visible = False
                    cnnDB.Execute("DELETE RecipeStockitemLnk.* From RecipeStockitemLnk WHERE RecipeStockitemLnk_RecipeID=" & adoPrimaryRS.Fields("StockItemID").Value & " AND RecipeStockitemLnk_StockitemID=" & FGRecipe.get_RowData(FGRecipe.row) & ";")
                    loadRecipe()
                Else
                    cnnDB.Execute("UPDATE RecipeStockitemLnk SET RecipeStockitemLnk_Quantity = " & CDec(txtQuantity.Text) & " WHERE RecipeStockitemLnk_RecipeID=" & adoPrimaryRS.Fields("StockItemID").Value & " AND RecipeStockitemLnk_StockitemID=" & FGRecipe.get_RowData(FGRecipe.row) & ";")
                    FGRecipe.set_TextMatrix(FGRecipe.row, 3, FormatNumber(CDec(FGRecipe.get_TextMatrix(FGRecipe.row, 1)) * CDec(FGRecipe.get_TextMatrix(FGRecipe.row, 2)), 2))
                    lAmount = 0
                    For x = 1 To FGRecipe.RowCount - 1
                        lAmount = lAmount + CDbl(FGRecipe.get_TextMatrix(x, 3))
                    Next x
                    Me.lblRecipeCost.Text = FormatNumber(lAmount, 2)
                End If
            End If
        End If

    End Sub
    Private Sub loadRecipe()
        Dim rs As ADODB.Recordset
        Dim x As Integer
        Dim lAmount As Double
        '    Set rs = getRS("SELECT ProductReceipt.ProductReceipt_ProductChildID, ProductReceipt.ProductReceipt_Quantity, Product.Product_Name, [Product_CostLast]/[Product_SupplierQuantity] AS cost FROM ProductReceipt INNER JOIN Product ON ProductReceipt.ProductReceipt_ProductChildID = Product.ProductID WHERE (((ProductReceipt.ProductReceipt_ProductID)=" & gID & ") AND ((Product.Product_Discontinued)=False)) ORDER BY Product.Product_Name;")
        rs = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_Name, RecipeStockitemLnk.RecipeStockitemLnk_Quantity, [StockItem_ListCost]/[StockItem_Quantity] AS cost FROM RecipeStockitemLnk INNER JOIN StockItem ON RecipeStockitemLnk.RecipeStockitemLnk_StockitemID = StockItem.StockItemID Where (((RecipeStockitemLnk.RecipeStockitemLnk_RecipeID) = " & adoPrimaryRS.Fields("StockItemID").Value & ") And ((StockItem.StockItem_Discontinued) = False)) ORDER BY StockItem.StockItem_Name;")
        With FGRecipe
            .RowCount = rs.RecordCount + 1
            x = 1
            Do Until rs.EOF
                .set_TextMatrix(x, 0, rs.Fields("StockItem_Name").Value)
                .set_TextMatrix(x, 2, FormatNumber(rs.Fields("RecipeStockitemLnk_Quantity").Value, 4))
                .set_TextMatrix(x, 1, FormatNumber(rs.Fields("Cost").Value, 2))
                .set_TextMatrix(x, 3, FormatNumber(CDec(.get_TextMatrix(x, 1)) * CDec(.get_TextMatrix(x, 2)), 2))
                .set_RowData(x, rs.Fields("StockItemID").Value)
                'lAmount = lAmount + CDbl(FGRecipe.TextMatrix(x, 1))
                lAmount = lAmount + CDbl(FGRecipe.get_TextMatrix(x, 3))

                x = x + 1
                rs.MoveNext()
            Loop
            lblRecipeCost.Text = FormatNumber(lAmount, 2)

        End With
    End Sub


    'UPGRADE_ISSUE: Label event lblRecipeCost.Change was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    Private Sub lblRecipeCost_Change()
        If CShort(_txtFields_1.Text) Then
            _txtFloat_0.Text = lblRecipeCost.Text
            _txtFloat_1.Text = lblRecipeCost.Text
            _txtInteger_0.Text = CStr(1)
        End If
    End Sub

    'UPGRADE_WARNING: Event optRecipeType.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub optRecipeType_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles optRecipeType.CheckedChanged
        If eventSender.Checked Then
            Dim txt As New RadioButton
            txt = DirectCast(eventSender, RadioButton)
            Dim Index As Integer = GetIndexer(txt, optRecipeType)
            _txtFields_1.Text = CStr(Index)
            FGRecipe.Visible = Index
            cmdRecipeAdd.Visible = Index
            lblRecipeCost.Visible = Index
            cmdPrint.Visible = Index
            If Index Then
                _txtFloat_0.Enabled = False
                _txtFloat_1.Enabled = False
                _txtInteger_0.Enabled = False
                _txtFloat_0.Text = lblRecipeCost.Text
                _txtFloat_1.Text = lblRecipeCost.Text
                _txtInteger_0.Text = CStr(1)
            Else
                _txtFloat_0.Enabled = True
                _txtFloat_1.Enabled = True
                _txtInteger_0.Enabled = True
                FGRecipe.Col = 0
                FGRecipe.row = 0
                txtQuantity.Visible = False
            End If
        End If
    End Sub
    Private Sub TabStrip1_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles TabStrip1.ClickEvent
        Dim x As Short
        _Frame1_0.Visible = _Frame1_1.Visible = _Frame1_2.Visible = _Frame1_3.Visible = False

        With lstvSerial
            .Columns.Item(0).Width = twipsToPixels(1500, True)
            .Columns.Item(1).Width = twipsToPixels(1500, True)
            .Columns.Item(2).Width = twipsToPixels(1500, True)
            .Columns.Item(3).Width = twipsToPixels(1500, True)
        End With
        '.ColumnHeaders(3).Width = (lstvSerial.Width / 4) - 30
    End Sub
    Private Sub txtQuantity_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQuantity.Enter
        MyGotFocusNumericNew(txtQuantity)
    End Sub
    Private Sub txtQuantity_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtQuantity.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        MyKeyPress(KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub txtQuantity_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQuantity.Leave
        MyLostFocusNew(txtQuantity, 4)
        FGRecipe_LeaveCell(FGRecipe, New System.EventArgs())
    End Sub

    Private Sub txtQuantity_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtQuantity.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case 40
                KeyCode = 0
                FGRecipe_LeaveCell(FGRecipe, New System.EventArgs())
                If FGRecipe.row + 1 = FGRecipe.RowCount Then
                Else
                    FGRecipe.row = FGRecipe.row + 1
                End If
            Case 38
                KeyCode = 0
                If FGRecipe.row - 1 = 0 Then
                Else
                    FGRecipe.row = FGRecipe.row - 1
                End If
        End Select
    End Sub

    Private Sub frmStockItem_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Escape
                KeyAscii = 0
                cmdClose_Click(cmdClose, New System.EventArgs())
        End Select

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub frmStockItem_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim x As Short
        Frame1.AddRange(New GroupBox() {_Frame1_0, _Frame1_1, _Frame1_2, _Frame1_3})
        txtFields.AddRange(New TextBox() {_txtFields_0, _txtFields_1, _txtFields_7, _txtFields_8, _
                                          _txtFields_14})
        txtInteger.AddRange(New TextBox() {_txtInteger_0, _txtInteger_1, _txtInteger_2, _txtInteger_3, _
                                           _txtInteger_4})
        txtFloat.AddRange(New TextBox() {_txtFloat_0, _txtFloat_1})
        chkFields.AddRange(New CheckBox() {_chkFields_0, _chkFields_1, _chkFields_2, _chkFields_3, _
                                           _chkFields_4, _chkFields_5, _chkFields_6, _chkFields_12, _
                                           _chkFields_13})
        optRecipeType.AddRange(New RadioButton() {_optRecipeType_0, _optRecipeType_1, _optRecipeType_2, _
                                                  _optRecipeType_3})
        cmdNew.AddRange(New Button() {_cmdNew_0, _cmdNew_1, _cmdNew_2})
        cmdMove.AddRange(New Button() {_cmdMove_0, _cmdMove_1})
        Dim tb As New TextBox
        Dim cb As New CheckBox
        Dim rb As New RadioButton
        Dim bt As New Button
        For Each bt In cmdNew
            AddHandler bt.Click, AddressOf cmdNew_Click
        Next
        For Each bt In cmdMove
            AddHandler bt.Click, AddressOf cmdMove_Click
        Next
        For Each rb In optRecipeType
            AddHandler rb.CheckedChanged, AddressOf optRecipeType_CheckedChanged
        Next
        For Each cb In chkFields
            AddHandler cb.CheckedChanged, AddressOf chkFields_CheckStateChanged
        Next
        For Each tb In txtFields
            AddHandler tb.Enter, AddressOf txtFields_Enter
        Next
        For Each tb In txtFloat
            AddHandler tb.Enter, AddressOf txtFloat_Enter
            AddHandler tb.KeyPress, AddressOf txtFloat_KeyPress
            AddHandler tb.Leave, AddressOf txtFloat_Leave
        Next
        For Each tb In txtInteger
            AddHandler tb.Enter, AddressOf txtInteger_Enter
            AddHandler tb.KeyPress, AddressOf txtInteger_KeyPress
            AddHandler tb.Leave, AddressOf txtInteger_Leave
        Next
        ChkC = True 'Serial Fla
        'For x = 1 To Frame1.UBound
        _Frame1_1.Left = _Frame1_2.Left = _Frame1_3.Left = _Frame1_0.Left
        _Frame1_1.Top = _Frame1_2.Top = _Frame1_3.Top = _Frame1_0.Top
        _Frame1_1.Height = _Frame1_2.Height = _Frame1_3.Height = _Frame1_0.Height
        _Frame1_1.Width = _Frame1_2.Width = _Frame1_3.Width = _Frame1_0.Width
        Frame1(x).Visible = False
        Frame1(x).BringToFront()
        'Next
        TVMessage.ImageList = ILtree
        TreeView1.ImageList = ILtree

        '*frmstocklist must not be displayed when you access frmstockitem from  frmGRVitem and exit stockitem,so that's what the code does
        If frmStockList.DataList1.BoundText <> "" Then
            Holdquantity = -1
        End If

        loadLanguage()
    End Sub

    Private Sub loadLanguage()
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1586
        'If rsLang.RecordCount Then frmStockItem.Caption = rsLang("LanguageLayoutLnk_Description"): frmStockItem.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
        '
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1009
        If rsLang.RecordCount Then _lblLabels_7.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_7.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
        '
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1010
        If rsLang.RecordCount Then _Frame2_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _Frame2_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1011
        If rsLang.RecordCount Then _lblLabels_8.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_8.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1012
        If rsLang.RecordCount Then _lblLabels_14.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_14.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1013
        If rsLang.RecordCount Then _lblLabels_6.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_6.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1014
        If rsLang.RecordCount Then _lblLabels_5.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_5.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1015
        If rsLang.RecordCount Then _lblLabels_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1016
        If rsLang.RecordCount Then _lblLabels_12.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_12.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 2463
        If rsLang.RecordCount Then _chkFields_12.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _chkFields_12.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 2465
        If rsLang.RecordCount Then _chkFields_13.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _chkFields_13.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1017
        If rsLang.RecordCount Then _lblLabels_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1018
        If rsLang.RecordCount Then _lblLabels_13.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_13.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1019
        If rsLang.RecordCount Then _lblLabels_16.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_16.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value


        '============================= New SourceCode ============================

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1020 'Groupings|Checked
        If rsLang.RecordCount Then _Frame2_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _Frame2_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1021 'Pricing Grou|Checked
        If rsLang.RecordCount Then _lblLabels_3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1022 'Stock Group|Checked
        If rsLang.RecordCount Then _lblLabels_4.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_4.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1023 'Report Group|Checked
        If rsLang.RecordCount Then _lblLabels_15.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_15.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1024 'Pricing and Shrinks|Checked
        If rsLang.RecordCount Then _Frame2_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _Frame2_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1025 'Sale Shrinks|Checked
        If rsLang.RecordCount Then _lblLabels_11.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_11.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1026 'Suppliers Quantity|Checked
        If rsLang.RecordCount Then _lblLabels_9.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_9.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1027 'List Cost|Checked
        If rsLang.RecordCount Then _lblLabels_10.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_10.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1028 'Actual Cost|Checked
        If rsLang.RecordCount Then _lblLabels_11.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_11.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1029 'Ordering Rules|Checked
        If rsLang.RecordCount Then _Frame2_3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _Frame2_3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        '_chkFields_0 = NO CODE     [Check this box to exclude this Stock Item when using the Ordering Wizard]
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then _chkFields_0.Caption = rsLang("LanguageLayoutLnk_Description"): _chkFields_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

        '_lbl_4 = NO CODE           [When the Stock goes below]
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then _lbl_4.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

        '_lbl_5 = NO CODE           [units,]
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then _lbl_5.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

        '_lbl_0 = NO CODE           [Re-order a]
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

        '_lbl_7 = 1008 match with wrong case!
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1008 'Checked
        If rsLang.RecordCount Then _lbl_7.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_7.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1030 'Pricing Set|Checked
        If rsLang.RecordCount Then _Frame2_4.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _Frame2_4.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        'chkPriceSet = NO CODE      [This Item is parto f a Pricing Set]
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then chkPriceSet.Caption = rsLang("LanguageLayoutLnk_Description"): chkPriceSet.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

        'lblPriceSet = NO CODE      [No Action]
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then lblPriceSet.Caption = rsLang("LanguageLayoutLnk_Description"): lblPriceSet.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1031 'Parameters|Checked
        If rsLang.RecordCount Then _Frame2_5.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _Frame2_5.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1032 'This is a scale Product|Checked
        If rsLang.RecordCount Then _chkFields_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _chkFields_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1033 'This is a scale item Non Weight|Checked
        If rsLang.RecordCount Then _chkFields_4.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _chkFields_4.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1034 'Allow Fractions|Checked
        If rsLang.RecordCount Then _chkFields_3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _chkFields_3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1035 'Do not allow negative stock|Checked
        If rsLang.RecordCount Then _chkFields_5.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _chkFields_5.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 2453 'POS Price Override (SQ)|Checked
        If rsLang.RecordCount Then chkSQ.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : chkSQ.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1037 'Serial Tracking|Checked
        If rsLang.RecordCount Then Frame3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Frame3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 2362 'Yes|Checked
        If rsLang.RecordCount Then _chkFields_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _chkFields_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        'Frame6 = NO CODE           []

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 2362 'Yes|Checked
        If rsLang.RecordCount Then _chkFields_6.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _chkFields_6.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        'NOTE: DB Entry 2455 needs a "&&" to display correctly!
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 2455 'Shelf & Barcode Printing|Checked
        If rsLang.RecordCount Then Frame5.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Frame5.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 2456 'Shelf|Checked
        If rsLang.RecordCount Then chkshelf.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : chkshelf.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1838 'Barcode|Checked
        If rsLang.RecordCount Then chkbarcode.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : chkbarcode.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        '============================= End Frame(1) ==============================

        '_optRecipeType_0 = NO CODE [Not a Bill Of Material]
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then _optRecipeType_0.Caption = rsLang("LanguageLayoutLnk_Description"): _optRecipeType_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

        '_optRecipeType_1 = NO CODE [Production]
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then COMPONENT(0).Caption = rsLang("LanguageLayoutLnk_Description"): COMPONENT(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1043 'At time of Sale|Checked
        If rsLang.RecordCount Then _optRecipeType_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _optRecipeType_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        '_optRecipeType_3 = NO CODE [This product makes other products]
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then _optRecipeType_3.Caption = rsLang("LanguageLayoutLnk_Description"): _optRecipeType_3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

        'cmdPrint = NO CODE         [Print Bill of Material]
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then cmdPrint.Caption = rsLang("LanguageLayoutLnk_Description"): cmdPrint.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

        'cmdRecipeAdd = NO CODE     [Add Stock Item]
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then cmdRecipeAdd.Caption = rsLang("LanguageLayoutLnk_Description"): cmdRecipeAdd.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

        'txtQuantity = NO CODE      []
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then COMPONENT(0).Caption = rsLang("LanguageLayoutLnk_Description"): COMPONENT(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

        '============================= END Frame(2) ==============================

        'NOTE: DB Entry 1188 missing "<<" chars
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1188 'Checked
        If rsLang.RecordCount Then cmdAllocate.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdAllocate.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        'NOTE: DB Entry 1047 = missing ">>" chars
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1047 'Checked
        If rsLang.RecordCount Then cmdDeallocate.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdDeallocate.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1048 'New Message|Checked
        If rsLang.RecordCount Then _cmdNew_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _cmdNew_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1049 'New Child|Checked
        If rsLang.RecordCount Then _cmdNew_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _cmdNew_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        'NOTE: DB Entry 1050 Differs from current caption, but DB Grammar better!
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1050 'New Child from existing stock|Checked
        If rsLang.RecordCount Then _cmdNew_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _cmdNew_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1051 'Move Up|Checked
        If rsLang.RecordCount Then _cmdMove_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _cmdMove_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1052 'Move Down|Checked
        If rsLang.RecordCount Then _cmdMove_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _cmdMove_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1053 'Delete Item|Checked
        If rsLang.RecordCount Then cmdDelete.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdDelete.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        '============================= End Frame(3) ==============================

        rsHelp.Filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
        'UPGRADE_ISSUE: Form property frmStockItem.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value

    End Sub

    Private Sub loadLanguage_OLD()
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1586
        'If rsLang.RecordCount Then frmStockItem.Caption = rsLang("LanguageLayoutLnk_Description"): frmStockItem.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
        '
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1009
        If rsLang.RecordCount Then _lblLabels_7.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_7.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
        '
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1010
        If rsLang.RecordCount Then _Frame2_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _Frame2_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1011
        If rsLang.RecordCount Then _lblLabels_8.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_8.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1012
        If rsLang.RecordCount Then _lblLabels_14.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_14.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1013
        If rsLang.RecordCount Then _lblLabels_6.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_6.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1014
        If rsLang.RecordCount Then _lblLabels_5.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_5.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1015
        If rsLang.RecordCount Then _lblLabels_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1016
        If rsLang.RecordCount Then _lblLabels_12.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_12.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 2463
        If rsLang.RecordCount Then _chkFields_12.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _chkFields_12.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 2465
        If rsLang.RecordCount Then _chkFields_13.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _chkFields_13.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1017
        If rsLang.RecordCount Then _lblLabels_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1018
        If rsLang.RecordCount Then _lblLabels_13.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_13.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1019
        If rsLang.RecordCount Then _lblLabels_16.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_16.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1019
        If rsLang.RecordCount Then _lblLabels_16.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_16.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

    End Sub

    'UPGRADE_WARNING: Event frmStockItem.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub frmStockItem_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        Dim cmdLast As New Button
        Dim lblStatus As New Label
        On Error Resume Next
        'UPGRADE_WARNING: Couldn't resolve default property of object lblStatus.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        lblStatus.Width = pixelToTwips(Me.Width, True) - 1500
        'UPGRADE_WARNING: Couldn't resolve default property of object lblStatus.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        cmdNext.Left = twipsToPixels(lblStatus.Width + 700, True)
        'UPGRADE_WARNING: Couldn't resolve default property of object cmdLast.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        cmdLast.Left = pixelToTwips(cmdNext.Left, True) + 340
        '*
        'here a public function loaditems is called to loaditems in frmstockItem When frmpricesetlist unloads

        'frmStockItem.txtholdname.Text = frmStockItem._txtFields_7.Text

        If Holdvalue <> "" Then
            Call loadItems()
            Holdvalue = ""
        End If
        '*
    End Sub

    Private Sub cmdDetails_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDetails.Click
        Dim lID As Integer
        cmdDetails.Focus()
        System.Windows.Forms.Application.DoEvents()

        lID = adoPrimaryRS.Fields("StockItemID").Value
        Me.Close()
        frmStockPricing.loadItem(lID)
        frmStockPricing.ShowDialog()
    End Sub

    Private Sub frmStockItem_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        update_Renamed()
        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        '*
        txttemphold.Text = Me._txtFields_8.Text
        HoldP = txttemphold.Text
        Me.txttemphold.Text = ""

        '*
    End Sub

    Private Sub adoPrimaryRS_MoveComplete(ByVal adReason As ADODB.EventReasonEnum, ByVal pError As ADODB.Error, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.MoveComplete
        'This will display the current record position for this recordset
    End Sub

    Private Sub cmdRefresh_Click()
        On Error GoTo RefreshErr
        adoPrimaryRS.Requery()
        Exit Sub
RefreshErr:
        MsgBox(Err.Description)
    End Sub

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        Dim oText As New TextBox
        On Error Resume Next

        mbEditFlag = False
        mbAddNewFlag = False
        adoPrimaryRS.CancelUpdate()
        'UPGRADE_WARNING: Couldn't resolve default property of object mvBookMark. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If mvBookMark > 0 Then
            'UPGRADE_WARNING: Couldn't resolve default property of object mvBookMark. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            adoPrimaryRS.Bookmark = mvBookMark
        Else
            adoPrimaryRS.MoveFirst()
        End If
        mbDataChanged = False
        For Each oText In Me.txtInteger
            'txtInteger_Leave(txtInteger.Item(oText.Index), New System.EventArgs())
        Next oText
        For Each oText In Me.txtFloat
            'UPGRADE_WARNING: Couldn't resolve default property of object oText.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If oText.Text = "" Then oText.Text = "0"
            'UPGRADE_WARNING: Couldn't resolve default property of object oText.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            oText.Text = oText.Text * 100
            'txtFloat_Leave(txtFloat.Item(oText.Index), New System.EventArgs())
        Next oText
    End Sub

    'UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub update_Renamed()
        On Error GoTo UpdateErr
        gUpdate = True
        Me.cmdClose.Focus()
        System.Windows.Forms.Application.DoEvents()
        Dim rs As ADODB.Recordset


        If _txtInteger_0.Text = "0" Then _txtInteger_0.Text = "1"
        If cmbReorder.SelectedIndex Then
            _txtInteger_2.Text = _txtInteger_0.Text
            cnnDB.Execute("UPDATE StockItem SET StockItemOrderType = 1 WHERE StockItemID = " & adoPrimaryRS.Fields("StockItemID").Value & ";")

        Else
            _txtInteger_2.Text = CStr(1)
            cnnDB.Execute("UPDATE StockItem SET StockItemOrderType = 0 WHERE StockItemID = " & adoPrimaryRS.Fields("StockItemID").Value & ";")
        End If

        If adoPrimaryRS.Fields("StockItem_ListCost").OriginalValue <> adoPrimaryRS.Fields("StockItem_ListCost").Value Then
            rs = getRS("SELECT Company.Company_DayEndID FROM Company;")
            adoPrimaryRS.Fields("StockItem_LastCost").Value = rs.Fields(0).Value
        End If

        If _chkFields_2.CheckState <> CDbl(_chkFields_2.Tag) Then
            cnnDB.Execute("UPDATE Scale SET Scale.Scale_Update = True;")
        End If
        '* Update Barcode and Shelf
        If chkshelf.CheckState = 1 And chkbarcode.CheckState = 1 Then

            cnnDB.Execute("UPDATE StockItem SET StockItem_SShelf = true WHERE StockItemID = " & adoPrimaryRS.Fields("StockItemID").Value & ";")
            cnnDB.Execute("UPDATE StockItem SET StockItem_SBarcode = true WHERE StockItemID = " & adoPrimaryRS.Fields("StockItemID").Value & ";")

        End If

        If chkshelf.CheckState = 0 And chkbarcode.CheckState = 0 Then

            cnnDB.Execute("UPDATE StockItem SET StockItem_SShelf = false WHERE StockItemID = " & adoPrimaryRS.Fields("StockItemID").Value & ";")
            cnnDB.Execute("UPDATE StockItem SET StockItem_SBarcode = false WHERE StockItemID = " & adoPrimaryRS.Fields("StockItemID").Value & ";")

        End If

        If chkshelf.CheckState = 0 Then cnnDB.Execute("UPDATE StockItem SET StockItem_SShelf = false WHERE StockItemID = " & adoPrimaryRS.Fields("StockItemID").Value & ";")
        If chkbarcode.CheckState = 0 Then cnnDB.Execute("UPDATE StockItem SET StockItem_SBarcode = false WHERE StockItemID = " & adoPrimaryRS.Fields("StockItemID").Value & ";")

        If chkshelf.CheckState = 1 Then cnnDB.Execute("UPDATE StockItem SET StockItem_SShelf = true WHERE StockItemID = " & adoPrimaryRS.Fields("StockItemID").Value & ";")
        If chkbarcode.CheckState = 1 Then cnnDB.Execute("UPDATE StockItem SET StockItem_SBarcode = true WHERE StockItemID = " & adoPrimaryRS.Fields("StockItemID").Value & ";")
        'If OptPrint(0).value = True Then cnnDB.Execute "UPDATE StockItem SET StockItem_SBarcode = 'shelf' WHERE StockItemID = " & adoPrimaryRS("StockItemID") & ";"
        'If OptPrint(1).value = True Then cnnDB.Execute "UPDATE StockItem SET StockItem_SBarcode = 'barcode' WHERE StockItemID = " & adoPrimaryRS("StockItemID") & ";"
        'If OptPrint(2).value = True Then cnnDB.Execute "UPDATE StockItem SET StockItem_SBarcode = NULL WHERE StockItemID = " & adoPrimaryRS("StockItemID") & ";"
        '*

        'New code to update serial tracker...
        'Code for...
        If _chkFields_1.CheckState <> CDbl(_chkFields_1.Tag) Then
            If adoPrimaryRS.Fields("StockItem_ShrinkID").Value = 1 Then cnnDB.Execute("UPDATE StockItem SET StockItem_SerialTracker = " & _chkFields_1.CheckState & " WHERE StockItemID = " & adoPrimaryRS.Fields("StockItemID").Value & ";")
        End If

        If cmbPriceSet.BoundText = "" Then
            'UPGRADE_ISSUE: VBControlExtender property cmbPriceSet.DataField is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
            cmbPriceSet.DataField = ""
        End If

        adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll)
        adoPrimaryRS.Move(0) 'move to the new record

        'UPGRADE_ISSUE: VBControlExtender property cmbPriceSet.DataField is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
        cmbPriceSet.DataField = "StockItem_PriceSetID"

        cnnDB.Execute("INSERT INTO tempStockItem ( tempStockItemID ) SELECT StockItem.StockItemID FROM tempStockItem RIGHT JOIN StockItem ON tempStockItem.tempStockItemID = StockItem.StockItemID WHERE (((tempStockItem.tempStockItemID) Is Null) AND ((StockItem.StockItemID)=" & adoPrimaryRS.Fields("StockItemID").Value & "));")

        If gRSpriceSet Is Nothing Then
        Else
            If gRSpriceSet.Fields("StockItemID").Value = adoPrimaryRS.Fields("StockItemID").Value Then
                cnnDB.Execute("UPDATE (StockItem INNER JOIN PriceSet ON StockItem.StockItem_PriceSetID = PriceSet.PriceSetID) INNER JOIN StockItem AS StockItem_1 ON PriceSet.PriceSet_StockItemID = StockItem_1.StockItemID SET StockItem.StockItem_ShrinkID = [StockItem_1]![StockItem_ShrinkID], StockItem.StockItem_PricingGroupID = [StockItem_1]![StockItem_PricingGroupID], StockItem.StockItem_VatID = [StockItem_1]![StockItem_VatID], StockItem.StockItem_DepositID = [StockItem_1]![StockItem_DepositID], StockItem.StockItem_Quantity = [StockItem_1]![StockItem_Quantity], StockItem.StockItem_ListCost = [StockItem_1]![StockItem_ListCost] WHERE (((PriceSet.PriceSet_Disabled)=0) AND ((StockItem.StockItemID)<>[StockItem_1]![StockItemID]) AND (StockItem_1.StockItemID)=" & adoPrimaryRS.Fields("StockitemID").Value & ");")
                cnnDB.Execute("DELETE PropChannelLnk.* FROM (StockItem INNER JOIN PriceSet ON StockItem.StockItem_PriceSetID = PriceSet.PriceSetID) INNER JOIN PropChannelLnk ON StockItem.StockItemID = PropChannelLnk.PropChannelLnk_StockItemID WHERE (((PriceSet.PriceSet_Disabled)=0) AND ((StockItem.StockItemID)<>[PriceSet]![PriceSet_StockItemID]) AND ((PriceSet.PriceSetID)=" & adoPrimaryRS.Fields("Stockitem_PriceSetID").Value & "));")
                cnnDB.Execute("DELETE PriceChannelLnk.* FROM (StockItem INNER JOIN PriceSet ON StockItem.StockItem_PriceSetID = PriceSet.PriceSetID) INNER JOIN PriceChannelLnk ON StockItem.StockItemID = PriceChannelLnk.PriceChannelLnk_StockItemID WHERE (((PriceSet.PriceSet_Disabled)=0) AND ((StockItem.StockItemID)<>[PriceSet]![PriceSet_StockItemID]) AND ((PriceSet.PriceSetID)=" & adoPrimaryRS.Fields("Stockitem_PriceSetID").Value & "));")
                cnnDB.Execute("INSERT INTO PriceChannelLnk ( PriceChannelLnk_StockItemID, PriceChannelLnk_Quantity, PriceChannelLnk_ChannelID, PriceChannelLnk_Price ) SELECT StockItem.StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price FROM (StockItem INNER JOIN PriceSet ON StockItem.StockItem_PriceSetID = PriceSet.PriceSetID) INNER JOIN PriceChannelLnk ON PriceSet.PriceSet_StockItemID = PriceChannelLnk.PriceChannelLnk_StockItemID WHERE (((StockItem.StockItemID)<>[PriceSet]![PriceSet_StockItemID]) AND ((PriceSet.PriceSet_Disabled)=0) AND ((PriceSet.PriceSetID)=" & adoPrimaryRS.Fields("Stockitem_PriceSetID").Value & "));")
                cnnDB.Execute("INSERT INTO PropChannelLnk ( PropChannelLnk_StockItemID, PropChannelLnk_Quantity, PropChannelLnk_ChannelID, PropChannelLnk_Markup ) SELECT StockItem.StockItemID, PropChannelLnk.PropChannelLnk_Quantity, PropChannelLnk.PropChannelLnk_ChannelID, PropChannelLnk.PropChannelLnk_Markup FROM (StockItem INNER JOIN PriceSet ON StockItem.StockItem_PriceSetID = PriceSet.PriceSetID) INNER JOIN PropChannelLnk ON PriceSet.PriceSet_StockItemID = PropChannelLnk.PropChannelLnk_StockItemID WHERE (((StockItem.StockItemID)<>[PriceSet]![PriceSet_StockItemID]) AND ((PriceSet.PriceSet_Disabled)=0) AND ((PriceSet.PriceSetID)=" & adoPrimaryRS.Fields("Stockitem_PriceSetID").Value & "));")
                cnnDB.Execute("INSERT INTO tempStockItem ( tempStockItemID ) SELECT StockItem.StockItemID FROM tempStockItem RIGHT JOIN StockItem ON tempStockItem.tempStockItemID = StockItem.StockItemID WHERE (((tempStockItem.tempStockItemID) Is Null) AND ((StockItem.StockItem_PriceSetID)=" & adoPrimaryRS.Fields("Stockitem_PriceSetID").Value & "));")

            End If
        End If

        cnnDB.Execute("Delete StockitemOverwrite.* From StockitemOverwrite WHERE (((StockitemOverwrite.StockitemOverwriteID)=" & adoPrimaryRS.Fields("StockitemID").Value & "));")
        If chkSQ.CheckState Then cnnDB.Execute("INSERT INTO StockitemOverwrite ( StockitemOverwriteID ) SELECT " & adoPrimaryRS.Fields("StockitemID").Value & ";")

        mbEditFlag = False
        mbAddNewFlag = False
        mbDataChanged = False
        gUpdate = False
        RecipeCost()

        Exit Sub
UpdateErr:
        gUpdate = False
    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        cmdClose.Focus()
        '* Check if Display name is empty and refuses to exit
        If Trim(Me._txtFields_7.Text) = "" Then
            MsgBox("The Display Name TextBox must not be Empty", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information, "Edit Stock Item Details")
            'frmStockItem._txtFields_7.Text = frmStockItem.txtholdname.Text
            Me._txtFields_7.Focus()
            Exit Sub
        ElseIf IsNumeric(Me._txtFields_7.Text) = True Then
            MsgBox("The Display Name TextBox must not be a Number", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information, "Edit Stock Item Details")
            'frmStockItem._txtFields_7.Text = frmStockItem.txtholdname.Text
            Me._txtFields_7.Focus()
            Exit Sub
        ElseIf Trim(Me._txtFields_8.Text) = "" Then
            MsgBox("The Receipt Name TextBox must not be Empty", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information, "Edit Stock Item Details")
            ' frmStockItem._txtFields_8.Text = frmStockItem.txtholdname.Text
            Me._txtFields_8.Focus()
            Exit Sub
        ElseIf IsNumeric(Me._txtFields_8.Text) = True Then
            MsgBox("The Receipt Name TextBox must not be a Number", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information, "Edit Stock Item Details")
            'frmStockItem._txtFields_8.Text = frmStockItem.txtholdname.Text
            Me._txtFields_8.Focus()
            Exit Sub
        End If

        '*
        System.Windows.Forms.Application.DoEvents()
        Me.Close()

        '*Display frmStockList
        '*frmstocklist must not be displayed when you access frmstockitem from  frmGRVitem and exit stockitem,so that's what the code does

        '    If Holdquantity = 0 Or frmPriceSet.lblStockItem.Tag <> "" Then
        '    ElseIf Holdquantity = -1 Or frmPriceSet.lblStockItem.Tag <> "" Then
        '    frmStockList.editItem 0
        '    HoldP = frmStockItem.txttemphold.Text
        '    frmStockList.show 1
        '    End If

        '*

    End Sub
    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtFields.Enter
        Dim txt As New TextBox
        txt = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txt, txtFields)

        'If Index = 14 Then Index = 0
        'If Index = 0 Then Index = 14

        MyGotFocus(txtFields(Index))
    End Sub

    Private Sub txtInteger_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtInteger.Enter
        Dim txt As New TextBox
        txt = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txt, txtInteger)
        MyGotFocusNumeric(txtInteger(Index))
    End Sub

    Private Sub txtInteger_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) 'Handles txtInteger.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'Dim Index As Short = txtInteger.GetIndex(eventSender)
        MyKeyPress(KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtInteger_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtInteger.Leave
        Dim txt As New TextBox
        txt = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txt, txtInteger)
        MyLostFocus(txtInteger(Index), 0)
    End Sub

    Private Sub txtFloat_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtFloat.Enter
        Dim txt As New TextBox
        txt = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txt, txtFloat)
        MyGotFocusNumeric(txtFloat(Index))
    End Sub

    Private Sub txtFloat_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) 'Handles txtFloat.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'Dim Index As Short = txtFloat.GetIndex(eventSender)
        MyKeyPress(KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtFloat_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtFloat.Leave
        Dim txt As New TextBox
        txt = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txt, txtFloat)
        MyLostFocus(txtFloat(Index), 2)
    End Sub

    Private Sub loadMessage()
        Dim lNode As System.Windows.Forms.TreeNode
        Dim rs As ADODB.Recordset
        Dim RSitem As ADODB.Recordset
        rs = getRS("SELECT Message.* From Message ORDER BY Message.Message_Name;")
        RSitem = getRS("SELECT MessageItem.* From MessageItem ORDER BY MessageItem_Order;")
        '    On Local Error Resume Next
        TVMessage.Nodes.Clear()
        If rs.RecordCount Then
            rs.MoveFirst()
            Do Until rs.EOF
                lNode = TVMessage.Nodes.Add("m" & rs.Fields("MessageID").Value, rs.Fields("Message_Name").Value, 1)
                RSitem.Filter = "MessageItem_MessageID=" & rs.Fields("MessageID").Value
                If RSitem.RecordCount Then
                    RSitem.MoveFirst()
                    Do Until RSitem.EOF
                        'UPGRADE_WARNING: Add method behavior has changed Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DBD08912-7C17-401D-9BE9-BA85E7772B99"'
                        lNode = TVMessage.Nodes.Find("m" & rs.Fields("MessageID").Value, True)(0).Nodes.Add("i" & RSitem.Fields("MessageItemID").Value, RSitem.Fields("MessageItem_Name").Value, 2)
                        RSitem.MoveNext()
                    Loop
                End If
                rs.MoveNext()
            Loop
        End If
    End Sub

    Private Sub loadTree()
        Dim RSitem As ADODB.Recordset
        Dim rs As ADODB.Recordset
        Dim lNode As System.Windows.Forms.TreeNode
        TreeView1.Nodes.Clear()
        TreeView1.Nodes.Add("m0", "Product", 3)
        deleteUnallocated()
        RSitem = getRS("SELECT MessageItem.* From MessageItem ORDER BY MessageItem_Order;")
        rs = getRS("SELECT Message.MessageID, Message.Message_Name, StockItemMessageLnk.* FROM Message INNER JOIN StockItemMessageLnk ON Message.MessageID = StockItemMessageLnk.StockItemMessageLnk_MessageID Where (((StockItemMessageLnk.StockItemMessageLnk_StockItemID) = " & gID & ")) ORDER BY StockItemMessageLnk.StockItemMessageLnk_ParentID, StockItemMessageLnk.StockItemMessageLnk_Level, StockItemMessageLnk.StockItemMessageLnk_Order;")
        Do Until rs.EOF
            'UPGRADE_WARNING: Add method behavior has changed Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DBD08912-7C17-401D-9BE9-BA85E7772B99"'
            lNode = TreeView1.Nodes.Find("m" & rs.Fields("StockItemMessageLnk_ParentID").Value, True)(0).Nodes.Add("m" & rs.Fields("StockItemMessageLnkID").Value, rs.Fields("Message_Name").Value, 1)
            'UPGRADE_WARNING: Couldn't resolve default property of object RSitem.filter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            RSitem.filter = "MessageItem_MessageID=" & rs.Fields("MessageID").Value
            'UPGRADE_WARNING: Couldn't resolve default property of object RSitem.RecordCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If RSitem.RecordCount Then
                'UPGRADE_WARNING: Couldn't resolve default property of object RSitem.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                RSitem.MoveFirst()
                'UPGRADE_WARNING: Couldn't resolve default property of object RSitem.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Do Until RSitem.EOF
                    'UPGRADE_WARNING: Couldn't resolve default property of object RSitem(MessageItem_Name). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object RSitem(MessageItemID). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Add method behavior has changed Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DBD08912-7C17-401D-9BE9-BA85E7772B99"'
                    lNode = TreeView1.Nodes.Find("m" & rs.Fields("StockItemMessageLnkID").Value, True)(0).Nodes.Add("i" & RSitem("MessageItemID").Value & "_" & rs.Fields("StockItemMessageLnkID").Value, RSitem("MessageItem_Name").Value, 2)
                    'UPGRADE_WARNING: Couldn't resolve default property of object RSitem.moveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    RSitem.moveNext()
                Loop
            End If
            rs.MoveNext()
        Loop
        TreeView1.Nodes.Item("m0").Expand()
        'UPGRADE_ISSUE: MSComctlLib.Node property TreeView1.Nodes.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        TreeView1.Nodes.Item("m0").Checked = True
    End Sub
    Private Sub deleteUnallocated()
        Dim rs As ADODB.Recordset
        rs = getRS("SELECT StockItemMessageLnk.StockItemMessageLnkID FROM StockItemMessageLnk AS StockItemMessageLnk_1 RIGHT JOIN StockItemMessageLnk ON (StockItemMessageLnk_1.StockItemMessageLnkID = StockItemMessageLnk.StockItemMessageLnk_ParentID) AND (StockItemMessageLnk_1.StockItemMessageLnk_StockItemID = StockItemMessageLnk.StockItemMessageLnk_StockItemID) WHERE (((StockItemMessageLnk_1.StockItemMessageLnkID) Is Null) AND ((StockItemMessageLnk.StockItemMessageLnk_ParentID)<>0));")
        Do While rs.RecordCount
            cnnDB.Execute("DELETE * FROM StockItemMessageLnk WHERE StockItemMessageLnkID=" & rs.Fields("StockItemMessageLnkID").Value)
            rs = getRS("SELECT StockItemMessageLnk.StockItemMessageLnkID FROM StockItemMessageLnk AS StockItemMessageLnk_1 RIGHT JOIN StockItemMessageLnk ON (StockItemMessageLnk_1.StockItemMessageLnkID = StockItemMessageLnk.StockItemMessageLnk_ParentID) AND (StockItemMessageLnk_1.StockItemMessageLnk_StockItemID = StockItemMessageLnk.StockItemMessageLnk_StockItemID) WHERE (((StockItemMessageLnk_1.StockItemMessageLnkID) Is Null) AND ((StockItemMessageLnk.StockItemMessageLnk_ParentID)<>0));")
        Loop

    End Sub

    Private Sub cmdDeallocate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDeallocate.Click
        Dim lNode As System.Windows.Forms.TreeNode
        Dim lKey As String
        If TreeView1.SelectedNode Is Nothing Then
        Else
            If TreeView1.SelectedNode.Name <> "m0" Then
                lNode = TreeView1.SelectedNode
                cnnDB.Execute("DELETE StockItemMessageLnk.* From StockItemMessageLnk WHERE (((StockItemMessageLnk.StockItemMessageLnkID)=" & Mid(lNode.Name, 2) & "));")
                'UPGRADE_ISSUE: MSComctlLib.Node property Parent.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
                'lNode.Parent.Selected = True
                lNode.Parent.Checked = True
                TreeView1.Nodes.RemoveAt(lNode.Name)
            End If
        End If


    End Sub

    Private Sub cmdDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDelete.Click
        Dim rs As ADODB.Recordset
        If TVMessage.SelectedNode Is Nothing Then
        Else
            If VB.Left(TVMessage.SelectedNode.Name, 1) = "i" Then
                rs = getRS("SELECT MessageItem.MessageItemID FROM MessageItem AS MessageItem_1, MessageItem WHERE (((MessageItem_1.MessageItemID)=" & Mid(TVMessage.SelectedNode.Name, 2) & ") AND ((MessageItem.MessageItem_Order)>[MessageItem_1]![MessageItem_Order]));")
                Do Until rs.EOF
                    cnnDB.Execute("UPDATE MessageItem SET MessageItem_Order = [MessageItem_Order]-1 WHERE (((MessageItemID)=" & rs.Fields("MessageItemID").Value & "));")
                    rs.MoveNext()
                Loop
                cnnDB.Execute("DELETE MessageItem.* From MessageItem WHERE (((MessageItemID)=" & Mid(TVMessage.SelectedNode.Name, 2) & "));")
            Else
                cnnDB.Execute("DELETE MessageItem.* From MessageItem WHERE (((MessageItem.MessageItem_MessageID)=" & Mid(TVMessage.SelectedNode.Name, 2) & "));")
                cnnDB.Execute("DELETE Message.* From Message WHERE (((Message.MessageID)=" & Mid(TVMessage.SelectedNode.Name, 2) & "));")
                cnnDB.Execute("DELETE StockItemMessageLnk.* From StockItemMessageLnk WHERE (((StockItemMessageLnk.StockItemMessageLnk_MessageID)=" & Mid(TVMessage.SelectedNode.Name, 2) & "));")
                loadTree()
            End If
            'UPGRADE_WARNING: MSComctlLib.Nodes method TVMessage.Nodes.Remove has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            TVMessage.Nodes.RemoveAt((TVMessage.SelectedNode.Name))

        End If
    End Sub

    Private Sub cmdMove_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles cmdMove.Click
        Dim btn As New Button
        btn = DirectCast(eventSender, Button)
        Dim Index As Integer = GetIndexer(btn, cmdMove)
        On Error Resume Next
        Dim lKey As String
        lKey = TVMessage.SelectedNode.Name
        If VB.Left(lKey, 1) = "i" Then
            If Index Then
                If TVMessage.SelectedNode.LastNode.Name = TVMessage.SelectedNode.Name Then
                    Exit Sub
                Else
                    cnnDB.Execute("UPDATE MessageItem SET MessageItem_Order = [MessageItem_Order]-1 WHERE (((MessageItemID)=" & Mid(TVMessage.SelectedNode.NextNode.Name, 2) & "));")
                    cnnDB.Execute("UPDATE MessageItem SET MessageItem_Order = [MessageItem_Order]+1 WHERE (((MessageItemID)=" & Mid(TVMessage.SelectedNode.Name, 2) & "));")

                End If
            Else
                If TVMessage.SelectedNode.FirstNode.Name = TVMessage.SelectedNode.Name Then
                    Exit Sub
                Else
                    cnnDB.Execute("UPDATE MessageItem SET MessageItem_Order = [MessageItem_Order]+1 WHERE (((MessageItemID)=" & Mid(TVMessage.SelectedNode.PrevNode.Name, 2) & "));")
                    cnnDB.Execute("UPDATE MessageItem SET MessageItem_Order = [MessageItem_Order]-1 WHERE (((MessageItemID)=" & Mid(TVMessage.SelectedNode.Name, 2) & "));")
                End If
            End If
            TVMessage.Visible = False
            loadMessage()
            'UPGRADE_ISSUE: MSComctlLib.Node property TVMessage.Nodes.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
            TVMessage.Nodes.Item(lKey).Checked = True
            TVMessage.Visible = True
        End If
    End Sub

    Private Sub cmdNew_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles cmdNew.Click
        Dim txt As New Button
        txt = DirectCast(eventSender, Button)
        Dim Index As Integer = GetIndexer(txt, cmdNew)
        Dim lIndex As Integer
        Dim lString As String
        Dim rs As ADODB.Recordset
        Dim lNode As System.Windows.Forms.TreeNode
        'UPGRADE_WARNING: Couldn't resolve default property of object lIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        lIndex = 0
        If Index = 1 Then
            If TVMessage.SelectedNode Is Nothing Then
            Else
                If VB.Left(TVMessage.SelectedNode.Name, 1) = "m" Then lNode = TVMessage.SelectedNode Else lNode = TVMessage.SelectedNode.Parent

                lString = InputBox("Enter Child Message Description for '" & lNode.Text & "'.", "NEW CHILD MESSAGE")
                If lString <> "" Then
                    rs = getRS("SELECT MessageItem.MessageItem_MessageID From MessageItem WHERE (((MessageItem.MessageItem_MessageID)=" & Mid(lNode.Name, 2) & "));")
                    cnnDB.Execute("INSERT INTO MessageItem ( MessageItem_MessageID, MessageItem_Name, MessageItem_Order ) SELECT " & Mid(lNode.Name, 2) & ", '" & Replace(lString, "'", "''") & "', " & rs.RecordCount + 1 & ";")
                    rs = getRS("SELECT Max(MessageItemID) AS MaxOfMessageID FROM MessageItem;")
                    lNode = TVMessage.Nodes.Find(lNode.Name, True)(0).Nodes.Add("i" & rs.Fields(0).Value, lString, 2)
                    lNode.Expand()
                    TVMessage.SelectedNode = lNode
                End If
            End If

        ElseIf Index = 2 Then
            If TVMessage.SelectedNode Is Nothing Then
            Else
                If VB.Left(TVMessage.SelectedNode.Name, 1) = "m" Then lNode = TVMessage.SelectedNode Else lNode = TVMessage.SelectedNode.Parent

                If frmStockChildMessage.makeItem(CInt(Mid(lNode.Name, 2))) = False Then
                Else
                    'lString = InputBox("Enter Child Message Description for '" & lNode.Text & "'.", "NEW CHILD MESSAGE")
                    'If lString <> "" Then
                    'Set rs = getRS("SELECT MessageItem.MessageItem_MessageID From MessageItem WHERE (((MessageItem.MessageItem_MessageID)=" & Mid(lNode.Key, 2) & "));")
                    'cnnDB.Execute "INSERT INTO MessageItem ( MessageItem_MessageID, MessageItem_Name, MessageItem_Order ) SELECT " & Mid(lNode.Key, 2) & ", '" & Replace(lString, "'", "''") & "', " & rs.RecordCount + 1 & ";"
                    rs = getRS("SELECT Max(MessageItemID) AS MaxOfMessageID FROM MessageItem;")
                    rs = getRS("SELECT * FROM MessageItem WHERE MessageItemID = " & rs.Fields(0).Value & ";")
                    lNode = TVMessage.Nodes.Find(lNode.Name, True)(0).Nodes.Add("i" & rs.Fields(0).Value, rs.Fields(2).Value, 2)
                    lNode.Expand()
                    TVMessage.SelectedNode = lNode
                    'End If
                End If
            End If

        ElseIf Index = 0 Then
            lString = InputBox("Enter Message Description", "NEW MESSAGE")
            If lString <> "" Then
                cnnDB.Execute("INSERT INTO Message ( Message_Name, Message_Type ) SELECT '" & Replace(lString, "'", "''") & "', 0")
                rs = getRS("SELECT Max(Message.MessageID) AS MaxOfMessageID FROM Message;")
                TVMessage.Nodes.Add("m" & rs.Fields(0).Value, lString, 1)
                TVMessage.SelectedNode = TVMessage.Nodes.Item("m" & rs.Fields(0).Value)
            End If
        End If
    End Sub

    Private Sub cmdAllocate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAllocate.Click
        Dim rs As ADODB.Recordset
        Dim lOrder, lLevel As Short
        Dim lNode As System.Windows.Forms.TreeNode
        Dim lKey As String
        lNode = TreeView1.SelectedNode
        On Error Resume Next
        lKey = lNode.Name
        If MsgBox("Are you sure you wish to make '" & Me.TVMessage.SelectedNode.Text & "' a child of '" & TreeView1.SelectedNode.Text & "'?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "CREATE ALLOCATION") = MsgBoxResult.Yes Then

            Do Until lNode.Name = "m0"
                lLevel = lLevel + 1
                lNode = lNode.Parent
            Loop
            rs = getRS("SELECT StockItemMessageLnk.StockItemMessageLnk_StockItemID From StockItemMessageLnk WHERE (((StockItemMessageLnk.StockItemMessageLnk_StockItemID)=" & gID & ") AND ((StockItemMessageLnk.StockItemMessageLnk_ParentID)=0));")
            lOrder = rs.RecordCount + 1
            lNode = TreeView1.SelectedNode
            cnnDB.Execute("INSERT INTO StockItemMessageLnk ( StockItemMessageLnk_StockItemID, StockItemMessageLnk_MessageID, StockItemMessageLnk_ParentID, StockItemMessageLnk_Order, StockItemMessageLnk_Level ) SELECT " & gID & " AS lID, " & Mid(Me.TVMessage.SelectedNode.Name, 2) & " AS mess, " & Mid(TreeView1.SelectedNode.Name, 2) & " AS parent, " & lOrder & " AS ord, " & lLevel & ";")
            If Err.Number Then
            Else
                loadTree()
                'UPGRADE_ISSUE: MSComctlLib.Node property TreeView1.Nodes.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
                TreeView1.Nodes.Item(lKey).Checked = True
                TreeView1.Nodes.Item(lKey).Expand()
            End If
        End If
    End Sub
    Public Function barcodeItem() As Object
        '*
        'DoEvents
        frmStockBarcode.loadItem(adoPrimaryRS.Fields("StockItemID").Value)
        Dim frm As New frmStockBarcode
        frm.Show()
        
    End Function
    Public Function Duplicate_codes_report() As Object
        ' cmdDuplicate.SetFocus
        System.Windows.Forms.Application.DoEvents()
        adoPrimaryRS.Move(0)
        update_Renamed()
        report_StockItemDuplicateCodes()
    End Function
    Public Function loadItems() As Object
        Dim id As Integer

        '* Loads information on frmstockitem when frmpricesetlist unloads

        Dim sql As String
        Dim InSt As String
        Dim oText As System.Windows.Forms.TextBox
        Dim lItem As System.Windows.Forms.ListViewItem
        Dim oCheck As System.Windows.Forms.CheckBox
        Dim rsj As ADODB.Recordset
        Dim rs As ADODB.Recordset
        Dim InStc As String
        Dim d_Sold As String
        Dim j As Short
        Dim sql1 As String
        Dim rsN As ADODB.Recordset
        Dim Insk As String
        Dim Rsp1 As ADODB.Recordset
        Dim rsSerial As ADODB.Recordset

        On Error Resume Next

        'UPGRADE_WARNING: Couldn't resolve default property of object id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        id = adoPrimaryRS.Fields("StockItemID").Value
        'UPGRADE_WARNING: Couldn't resolve default property of object id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        rs = getRS("SELECT StockitemOverwrite.StockitemOverwriteID From StockitemOverwrite WHERE (((StockitemOverwrite.StockitemOverwriteID)=" & id & "));")
        'If Not rs Is Nothing Then Me.chkSQ.value = 1 Else chkSQ.value = 0
        If rs.RecordCount Then Me.chkSQ.CheckState = System.Windows.Forms.CheckState.Checked Else chkSQ.CheckState = System.Windows.Forms.CheckState.Unchecked
        rs.Close()

        'UPGRADE_WARNING: Couldn't resolve default property of object id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        adoPrimaryRS = getRS("SELECT * FROM StockItem WHERE StockItemID = " & id)

        If adoPrimaryRS.BOF Or adoPrimaryRS.EOF Then
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gID = id
            If adoPrimaryRS.Fields("StockItem_OrderQuantity").Value = adoPrimaryRS.Fields("StockItem_Quantity").Value Then
                Me.cmbReorder.SelectedIndex = 1
            Else
                Me.cmbReorder.SelectedIndex = 0
            End If
            If adoPrimaryRS.Fields("StockItemOrderType").Value = 1 Then Me.cmbReorder.SelectedIndex = 1 Else Me.cmbReorder.SelectedIndex = 0

            For Each oText In Me.txtFields
                'UPGRADE_ISSUE: TextBox property oText.DataSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
                oText.DataBindings.Add(adoPrimaryRS)
                'UPGRADE_ISSUE: TextBox property oText.DataField was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
                'UPGRADE_WARNING: TextBox property oText.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize
            Next oText
            For Each oText In Me.txtInteger
                'UPGRADE_ISSUE: TextBox property oText.DataSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
                oText.DataBindings.Add(adoPrimaryRS)
                'txtInteger_Leave(txtInteger.Item((oText.Index)), New System.EventArgs())
            Next oText
            For Each oText In Me.txtFloat
                'UPGRADE_ISSUE: TextBox property oText.DataSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
                oText.DataBindings.Add(adoPrimaryRS)
                oText.Text = CStr(CDbl(oText.Text) * 100)
                'txtFloat_Leave(txtFloat.Item((oText.Index)), New System.EventArgs())
            Next oText
            'Bind the check boxes to the data provider
            For Each oCheck In Me.chkFields
                'UPGRADE_ISSUE: CheckBox property oCheck.DataSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
                oCheck.DataBindings.Add(adoPrimaryRS)
                oCheck.Tag = oCheck.CheckState
            Next oCheck
            buildDataControls()

            If cmbPriceSet.BoundText = "" Then
                chkPriceSet.CheckState = System.Windows.Forms.CheckState.Unchecked
            Else
                chkPriceSet.CheckState = System.Windows.Forms.CheckState.Checked
            End If

            'New Serial Tracker Code.....
            If adoPrimaryRS.Fields("StockItem_SerialTracker").Value Then _chkFields_1.Tag = 1 Else _chkFields_1.Tag = 0

            'Shelf & Barcode printing
            'If IsNull(adoPrimaryRS("StockItem_SBarcode")) Then
            '    OptPrint(2).value = True
            If CBool(LCase(adoPrimaryRS.Fields("StockItem_SShelf").Value)) = True And CBool(LCase(adoPrimaryRS.Fields("StockItem_SBarcode").Value)) = True Then
                chkshelf.CheckState = System.Windows.Forms.CheckState.Checked
                chkbarcode.CheckState = System.Windows.Forms.CheckState.Checked

            ElseIf CBool(LCase(adoPrimaryRS.Fields("StockItem_SShelf").Value)) = True And CBool(LCase(adoPrimaryRS.Fields("StockItem_SBarcode").Value)) = False Then
                chkshelf.CheckState = System.Windows.Forms.CheckState.Checked
                chkbarcode.CheckState = System.Windows.Forms.CheckState.Unchecked

            ElseIf CBool(LCase(adoPrimaryRS.Fields("StockItem_SBarcode").Value)) = True And CBool(LCase(adoPrimaryRS.Fields("StockItem_SShelf").Value)) = False Then
                chkbarcode.CheckState = System.Windows.Forms.CheckState.Checked
                chkshelf.CheckState = System.Windows.Forms.CheckState.Unchecked

            ElseIf CBool(LCase(adoPrimaryRS.Fields("StockItem_SShelf").Value)) = False And CBool(LCase(adoPrimaryRS.Fields("StockItem_SBarcode").Value)) = False Then
                chkshelf.CheckState = System.Windows.Forms.CheckState.Unchecked
                chkbarcode.CheckState = System.Windows.Forms.CheckState.Unchecked

            ElseIf CBool(LCase(adoPrimaryRS.Fields("StockItem_SShelf").Value)) = False Then
                chkshelf.CheckState = System.Windows.Forms.CheckState.Unchecked

            ElseIf CBool(LCase(adoPrimaryRS.Fields("StockItem_SBarcode").Value)) = False Then
                chkbarcode.CheckState = System.Windows.Forms.CheckState.Unchecked
            End If


            mbDataChanged = False
            With FGRecipe
                .Visible = False
                .RowCount = 1
                .ColumnCount = 4
                .Col = 0
                .row = 0
                .Text = "Product"
                .set_ColAlignment(0, 1)
                .set_ColWidth(0, 2000)
                .CellFontBold = True
                .Col = 1
                .Text = "Total Cost"
                .set_ColAlignment(1, 7)
                .set_ColWidth(1, 1000)
                .CellFontBold = True
                .Col = 2
                .Text = "Quantity"
                .set_ColAlignment(2, 7)
                .set_ColWidth(2, 750)
                .CellFontBold = True
                .Col = 3
                .Text = "Line Cost"
                .set_ColAlignment(3, 7)
                .set_ColWidth(3, 1000)
                .CellFontBold = True
                .Visible = Not Me._optRecipeType_0.Checked
            End With

            If _txtFields_1.Text = "" Then _txtFields_1.Text = CStr(0)

            optRecipeType(CShort(_txtFields_1.Text)).Checked = True
            loadRecipe()

            loadMessage()
            loadTree()

            'Assing serial number
            'UPGRADE_WARNING: Couldn't resolve default property of object id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            sql = "SELECT * FROM SerialTracking WHERE Serial_StockItemID = " & id

            If adoPrimaryRS.Fields("StockItem_SerialTracker").Value Then
                'UPGRADE_WARNING: Couldn't resolve default property of object id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                rsSerial = getRS("SELECT * FROM SerialTracking WHERE Serial_StockItemID = " & id)

                'Get serial Details...
                If rsSerial.RecordCount > 0 Then
                    Do While rsSerial.EOF = False
                        lItem = lstvSerial.Items.Add(rsSerial.Fields("Serial_SerialNumber").Value)
                        If Rsp1.RecordCount > 0 Then
                            lItem.SubItems.Add(rsSerial.Fields("Serial_SupplierName").Value)
                        Else
                            lItem.SubItems.Add("Default Suppier")
                        End If
                        lItem.SubItems.Add(rsSerial.Fields("Serial_DatePurchases").Value)
                        'If rsSerial("Serial_Instock") = True Then
                        If rsSerial.Fields("Serial_Instock").Value = True Or rsSerial.Fields("Serial_Status").Value = "Returned" Then
                            InStc = "No"
                            d_Sold = Str(rsSerial.Fields("Serial_DateSold").Value)
                            Insk = rsSerial.Fields("Serial_InvoiceNumber").Value
                        Else
                            InStc = "Yes"
                        End If
                        lItem.SubItems.Add(InStc)
                        lItem.SubItems.Add(d_Sold)
                        lItem.SubItems.Add(Insk)
                        d_Sold = ""
                        Insk = ""

                        rsSerial.MoveNext()
                    Loop
                    cmbShrink.Enabled = False
                End If
            End If

            'Stock item found
        End If


        '*
    End Function
End Class