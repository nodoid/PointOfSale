Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmStockPricing
	Inherits System.Windows.Forms.Form
	
	Dim gVAT As Object
	Dim gRoundAfter As Decimal
    Dim gRemoveUnits As Integer
	Dim gRoundDownUnits As Short
	Dim loading As Boolean
	Dim gStockItemID As Integer
	Dim gChannelID As Short
	Dim gNoPrice As Boolean
	Dim gCaseToUnit As Boolean
	Dim gPriceChannel1 As Decimal
	Dim rsStockItem As ADODB.Recordset
	
	Dim priceBox As Decimal
	Dim ChildPriceChang As Boolean
	Dim ParentPriceChang As Boolean
	Dim cmdUndoFocus As Boolean
	Dim ParentPriceID As Short

    Dim frmItem As New List(Of GroupBox)
    Dim lblSelection As New List(Of Label)
	Private Sub loadLanguage()
		
		'NOTE: DB Entry 1074 needs "&" for accelerator key!
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdundo.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdundo.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'NOTE: DB Entry 1838 needs "&" for accelerator key!
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1838 'Barcode|Checked
		If rsLang.RecordCount Then cmdbarcode.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdbarcode.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'cmdDetails = No Code           [Details]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdDetails.Caption = rsLang("LanguageLayoutLnk_Description"): cmdDetails.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdHistory = No Code           [History]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdDetails.Caption = rsLang("LanguageLayoutLnk_Description"): cmdDetails.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdNext = No Code              [&Next Item >]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdNext.Caption = rsLang("LanguageLayoutLnk_Description"): cmdNext.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'NOTE: DB Entry 1004 needs "&" for accelerator key
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1149 'Stock Item|Checked
		If rsLang.RecordCount Then _lbl_7.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_7.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lblStockItemName = No Code/Dynamic
		
		'_lbl_4 = No Code               [Sales Channel]
		'(Closest match 2349, but grammar wrong for use)
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_4.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1021 'Pricing Group|Checked
        If rsLang.RecordCount Then _lbl_15.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_15.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lbl(16) = No Code              [Pricing Rule]
		'(Closest match 1067, but grammar wrong for use)
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lbl(16).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(16).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'frmItem(0) = No Code/Dynamic/NA?
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1027 'List Cost|Checked
		If rsLang.RecordCount Then _lbl_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lbl_5 = No Code               [Matrix %]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_5.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_6 = No Code               [Prop %]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_6.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_6.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_2 = No Code               [Unit Deposit]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_3 = No Code               [Case Deposit]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_3.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblVatName = No Code           [VAT at 14%]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblVatName.Caption = rsLang("LanguageLayoutLnk_Description"): lblVatName.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lbl(8) = No Code               [Markup Price]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lbl(8).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(8).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lbl(9) = No Code               [Override Price]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lbl(9).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(9).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1151 'Price|Checked
        If rsLang.RecordCount Then _lbl_10.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_10.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lbl(11) = No Code              [Markup %]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lbl(11).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(11).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_0 = No Code               [GP %]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1995 'Actual|Checked
        If rsLang.RecordCount Then _lbl_18.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_18.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1028 'Actual Cost|Checked
        If rsLang.RecordCount Then _lbl_12.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_12.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lbl(13) = No Code              [Profit Amount]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lbl(13).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(13).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lbl(14) = No Code (Uses same code as lbl(11))
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lbl(14).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(14).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lbl(17) = No Code              [Margin %]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lbl(17).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(17).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblPriceSet = No Code/Dynamic? [No Action]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblPriceSet.Caption = rsLang("LanguageLayoutLnk_Description"): lblPriceSet.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmStockPricing.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	'Dim WithEvents adoPrimaryRS As Recordset
	'UPGRADE_WARNING: Event cmbChannel.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cmbChannel_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbChannel.SelectedIndexChanged
		If loading Then Exit Sub
		doChannel()
		System.Windows.Forms.Application.DoEvents()
		If Me.Visible Then
			cmbChannel.Focus()
		End If
	End Sub
	
	Public Sub loadItem(ByRef id As Integer)
        Dim blCust As Integer
        Dim ctSelling As Integer
        Dim visable As Boolean
        Dim rsProp As ADODB.Recordset
		loading = True
		Dim rsChannel As ADODB.Recordset
		Dim rsQuantity As ADODB.Recordset
		Dim rs As ADODB.Recordset
		Dim sql As String
		
        Dim x As Short
		Dim lQuantity, lDepositQuantity As Decimal
		Dim lCost, lActualCost As Decimal
		Dim lDepositUnit, lDepositPack As Decimal
		
		sql = "INSERT INTO Catalogue ( Catalogue_StockItemID, Catalogue_Quantity, Catalogue_Barcode, Catalogue_Deposit, Catalogue_Content, Catalogue_Disabled ) "
		sql = sql & "SELECT theJoin.StockItemID, theJoin.ShrinkItem_Quantity, 'CODE' AS Expr1, 0 AS deposit, 0 AS content, 0 AS disabled FROM [SELECT StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity FROM ShrinkItem INNER JOIN "
		sql = sql & "StockItem ON ShrinkItem.ShrinkItem_ShrinkID = StockItem.StockItem_ShrinkID]. AS theJoin LEFT JOIN Catalogue ON (theJoin.ShrinkItem_Quantity = Catalogue.Catalogue_Quantity) AND (theJoin.StockItemID = Catalogue.Catalogue_StockItemID) "
		sql = sql & "WHERE (((theJoin.StockItemID)=" & id & ") AND ((Catalogue.Catalogue_StockItemID) Is Null));"
		cnnDB.Execute(sql)
		
		sql = "SELECT StockItem.StockItemID, StockItem.StockItem_PackSizeID, StockItem.StockItem_Name, StockItem.StockItem_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_ActualCost, StockItem.StockItem_PriceSetID, Deposit.Deposit_UnitCost, Deposit.Deposit_CaseCost, Vat.Vat_Amount, Supplier.Supplier_Name, PricingGroup.PricingGroupID, PricingGroup.PricingGroup_Name, PricingGroup.PricingGroup_RemoveCents, PricingGroup.PricingGroup_RoundAfter, PricingGroup.PricingGroup_RoundDown, PricingGroup.PricingGroup_Unit1, PricingGroup.PricingGroup_Case1, PricingGroup.PricingGroup_Unit2, PricingGroup.PricingGroup_Case2, PricingGroup.PricingGroup_Unit3, PricingGroup.PricingGroup_Case3, PricingGroup.PricingGroup_Unit4, PricingGroup.PricingGroup_Case4, PricingGroup.PricingGroup_Unit5, PricingGroup.PricingGroup_Case5, PricingGroup.PricingGroup_Unit6, PricingGroup.PricingGroup_Case6, PricingGroup.PricingGroup_Unit7, PricingGroup.PricingGroup_Case7, PricingGroup.PricingGroup_Unit8, PricingGroup.PricingGroup_Case8 "
		sql = sql & "FROM (((StockItem INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Supplier ON StockItem.StockItem_SupplierID = Supplier.SupplierID WHERE (((StockItem.StockItemID)=" & id & "));"
		rsStockItem = getRS(sql)
		
		rsChannel = getRS("SELECT ChannelID, Channel_Name From Channel WHERE (Channel_Disabled = 0) AND (ChannelID <> 9) ORDER BY ChannelID")
		
		rsQuantity = getRS("SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, Catalogue.Catalogue_Barcode, Catalogue.Catalogue_Deposit, Catalogue.Catalogue_Content, Catalogue.Catalogue_Disabled, ShrinkItem.ShrinkItem_Code FROM Catalogue INNER JOIN (StockItem INNER JOIN ShrinkItem ON StockItem.StockItem_ShrinkID = ShrinkItem.ShrinkItem_ShrinkID) ON (ShrinkItem.ShrinkItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID) Where (((Catalogue.Catalogue_StockItemID) = " & id & ")) ORDER BY Catalogue.Catalogue_Quantity;")
		
		rsProp = getRS("SELECT PropChannelLnk.PropChannelLnk_Quantity, PropChannelLnk.PropChannelLnk_ChannelID, PropChannelLnk.PropChannelLnk_Markup From PropChannelLnk WHERE (((PropChannelLnk.PropChannelLnk_StockItemID)=" & id & "));")
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(rsStockItem.Fields("StockItem_PriceSetID").Value) Then
		Else
			rs = getRS("SELECT PriceSet.PriceSetID, [PriceSet_Name] & '(' & [StockItem_Name] & ')' AS priceSet_FullName, PriceSet.PriceSet_StockItemID FROM StockItem INNER JOIN PriceSet ON StockItem.StockItem_PriceSetID = PriceSet.PriceSetID WHERE (((StockItem.StockItemID)=" & id & ") AND ((PriceSet.PriceSet_Disabled)=0));")
			If rs.RecordCount Then
				If rs.Fields("PriceSet_StockItemID").Value = id Then
					lblPriceSet.Text = "Primary Pricing Set Item"
					lblPriceSet.Visible = True
					lblPriceSet.BackColor = System.Drawing.Color.Red
					lblPriceSet.ForeColor = System.Drawing.Color.White
				Else
					_txtProp_0.Enabled = False
					_txtPrice_0.Enabled = False
					lblPriceSet.Text = "Child Pricing Set Item"
					lblPriceSet.Visible = True
					lblPriceSet.BackColor = System.Drawing.Color.Yellow
					lblPriceSet.ForeColor = System.Drawing.Color.Black
				End If
			End If
		End If
		saveData()
		If rsStockItem.BOF Or rsStockItem.EOF Then
		Else
			gStockItemID = id
			gChannelID = 0
			_txtCost_0.Enabled = False
			'        _txtVariableCost_0.Enabled = False
			_txtCost_0.BackColor = System.Drawing.ColorTranslator.FromOle(-2147483633)
			_txtVariableCost_0.BackColor = System.Drawing.ColorTranslator.FromOle(-2147483633)
            For x = 0 To frmItem.Count - 1
                'txtCost.Unload(x)
                'lblMatrix.Unload(x)
                'txtProp.Unload(x)
                'lblDepositUnit.Unload(x)
                'lblDepositPack.Unload(x)
                'lblVat.Unload(x)
                'lblMarkup.Unload(x)
                'lblGP.Unload(x)
                'txtPrice.Unload(x)
                'lblPrice.Unload(x)
                'lblPercent.Unload(x)
                'lnProfit.Unload(x))
                'txtVariableCost.Unload(x)
                'lblProfitAmount.Unload(x)
                'lblProfitPrecent.Unload(x)
                'lblSection.Unload(x)
                'frmItem.Unload(x)
                'lblGPActual.Unload(x)
            Next
			lblVatName.Text = "VAT at " & FormatNumber(rsStockItem.Fields("Vat_Amount").Value, 2) & "%"
			gVAT = 1 + rsStockItem.Fields("Vat_Amount").Value / 100
			gRoundAfter = 0
			gRemoveUnits = 0
			gRoundDownUnits = 0
			gRoundAfter = rsStockItem.Fields("PricingGroup_RoundAfter").Value
			gRemoveUnits = rsStockItem.Fields("PricingGroup_RemoveCents").Value
			gRoundDownUnits = rsStockItem.Fields("PricingGroup_RoundDown").Value
			lblPricingGroup.Text = rsStockItem.Fields("PricingGroup_Name").Value
			lblPricingGroup.Tag = rsStockItem.Fields("PricingGroupID").Value
			lblPricingGroupRule.Text = " When a Stock Item value is over " & FormatNumber(gRoundAfter, 2) & " round all amounts below " & gRoundDownUnits & " cents to the lower Rand value, else the amount is rounded to the next highest Rand, then remove " & gRemoveUnits & " cents from the rounded stock item Rand value."
			lblPricingGroupRule.Tag = lblPricingGroupRule.Text
			lblStockItemName.Text = rsStockItem.Fields("StockItem_Name").Value
			lCost = rsStockItem.Fields("StockItem_ListCost").Value
			lActualCost = rsStockItem.Fields("StockItem_ActualCost").Value
			lQuantity = rsStockItem.Fields("StockItem_Quantity").Value
			lDepositUnit = rsStockItem.Fields("Deposit_UnitCost").Value
			lDepositPack = rsStockItem.Fields("Deposit_CaseCost").Value
			lDepositQuantity = lQuantity
			x = -1
			
			Do Until rsQuantity.EOF
				x = x + 1
				'UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If x Then
                    'frmItem.Load(x)
					'UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    frmItem(x).Left = twipsToPixels(pixelToTwips(frmItem(0).Left, True) + (pixelToTwips(frmItem(0).Width, True) + 100) * x, True)
					frmItem(x).Visible = True
                    'loadControl(txtCost, x)
                    'loadControl(lblMatrix, x)
                    'loadControl(picLine, x)
                    'loadControl(txtProp, x)
                    'loadControl(lblDepositUnit, x)
                    'loadControl(lblDepositPack, x)
                    'loadControl(lblVat, x)
                    'loadControl(lblMarkup, x)
                    'loadControl(lblGP, x)
                    'loadControl(txtPrice, x)
                    'loadControl(lblPrice, x)
                    'loadControl(lblPercent, x)
                    'loadControl(lnProfit, x)
                    'loadControl(txtVariableCost, x)
                    'loadControl(lblProfitAmount, x)
                    'loadControl(lblProfitPrecent, x)
                    'loadControl(lblSection, x)
                    'loadControl(lblGPActual, x)
				End If
                _lblSection_0.BackColor = System.Drawing.ColorTranslator.FromOle(65280)
                _lblSection_0.Text = "Matrix"
                _frmItem_0.Text = rsQuantity.Fields("ShrinkItem_Code").Value & " (" & rsQuantity.Fields("Catalogue_Quantity").Value & ")"
                _frmItem_0.Tag = rsQuantity.Fields("Catalogue_Quantity").Value
                _lblDepositUnit_0.Text = FormatNumber(CDbl(frmItem(x).Tag) * lDepositUnit, 2)
				If lDepositQuantity Then
                    _lblDepositPack_0.Text = FormatNumber(CShort(CDbl(frmItem(x).Tag) / lDepositQuantity - 0.49) * lDepositPack, 2)
				Else
                    _lblDepositPack_0.Text = "0.00"
				End If
                _txtCost_0.Text = FormatNumber(lCost / lQuantity * CDbl(frmItem(x).Tag), 2)
                _txtCost_0.Tag = _txtCost_0.Text
                _txtVariableCost_0.Text = FormatNumber(lActualCost / lQuantity * CDbl(frmItem(x).Tag), 2)
                _txtVariableCost_0.Tag = _txtVariableCost_0.Text
				
                If lQuantity = CDbl(_frmItem_0.Tag) Then
                    _txtCost_0.Enabled = True
                    _txtCost_0.BackColor = System.Drawing.Color.White
                    '_txtVariableCost_0.Enabled = True
                    _txtVariableCost_0.BackColor = System.Drawing.Color.White
                End If
                rsQuantity.MoveNext()
            Loop
            If x < 3 Then x = 3
            Me.Width = twipsToPixels(pixelToTwips(frmItem(0).Left, True) + (x + 1) * (pixelToTwips(frmItem(0).Width, True) + 100) + 250, True)
            Me.lblPricingGroupRule.Width = twipsToPixels(pixelToTwips(Me.Width, True) - pixelToTwips(Me.lblPricingGroupRule.Left, True) - 250 - 100, True)
            cmbChannel.Items.Clear()
            Do Until rsChannel.EOF
                cmbChannel.Items.Add(New LBI(rsChannel.Fields("Channel_Name").Value, rsChannel.Fields("ChannelID").Value))
                rsChannel.MoveNext()
            Loop
            cmbChannel.SelectedIndex = 0
            gChannelID = CInt(cmbChannel.SelectedIndex)
            doChannel()
            If visable Then _txtProp_0.Focus()
        End If

        loadLanguage()

        loading = False

        If blCust = True Then
            _txtPrice_0.Text = FormatNumber(ctSelling, 2)
            blCust = False
        End If

    End Sub
    Private Sub saveData()
        Dim x As Short
        Dim sql As String
        If gStockItemID Then
            RecipeCost()
            saveChannel()
            For x = 0 To frmItem.Count - 1
                If _txtCost_0.Enabled Then
                    If _txtCost_0.Text <> _txtCost_0.Tag Then
                        sql = "UPDATE StockItem SET StockItem_ListCost = " & Replace(_txtCost_0.Text, ",", "") & " WHERE StockItemID=" & gStockItemID
                        cnnDB.Execute(sql)
                        If ParentPriceChang = True Then
                            sql = "UPDATE StockItem SET StockItem_ListCost = " & Replace(_txtCost_0.Text, ",", "") & " WHERE StockItemID=" & ParentPriceID
                            cnnDB.Execute(sql)
                        End If
                    End If
                    _txtCost_0.Tag = _txtCost_0.Text
                    If _txtVariableCost_0.Text <> _txtVariableCost_0.Tag Then
                        sql = "UPDATE StockItem SET StockItem_ActualCost = " & Replace(_txtVariableCost_0.Text, ",", "") & " WHERE StockItemID=" & gStockItemID
                        cnnDB.Execute(sql)
                        If ParentPriceChang = True Then
                            sql = "UPDATE StockItem SET StockItem_ActualCost = " & Replace(Me._txtVariableCost_0.Text, ",", "") & " WHERE StockItemID=" & ParentPriceID
                            cnnDB.Execute(sql)
                        End If
                    End If
                    Me._txtVariableCost_0.Tag = Me._txtVariableCost_0.Text
                End If
            Next
            If loading Then
            Else
                If sql <> "" Then
                    sql = "INSERT INTO tempStockItem (tempStockItemID) SELECT StockItem.StockItemID FROM tempStockItem RIGHT OUTER JOIN StockItem ON tempStockItem.tempStockItemID = StockItem.StockItemID Where (StockItem.StockItemID = " & gStockItemID & ") And (tempStockItem.tempStockItemID Is Null)"
                    cnnDB.Execute(sql)
                End If
            End If
        End If

    End Sub
    Private Sub saveChannel()
        Dim x As Short
        Dim sql As String
        If gStockItemID Then
            If gChannelID Then
                If Me.Visible Then Me.cmdExit.Focus()
                System.Windows.Forms.Application.DoEvents()
                For x = 0 To frmItem.Count - 1


                    If _txtProp_0.Text <> _txtProp_0.Tag Then

                        sql = "DELETE FROM PropChannelLnk WHERE PropChannelLnk_Quantity=" & frmItem(x).Tag & " AND PropChannelLnk_ChannelID=" & gChannelID & " AND PropChannelLnk_StockItemID=" & gStockItemID
                        cnnDB.Execute(sql)
                        If _txtProp_0.Text <> "" Then
                            sql = "INSERT INTO PropChannelLnk (PropChannelLnk_StockItemID, PropChannelLnk_Quantity, PropChannelLnk_ChannelID, PropChannelLnk_Markup) VALUES (" & gStockItemID & ", " & frmItem(x).Tag & ", " & gChannelID & ", " & Replace(_txtProp_0.Text, ",", "") & ")"
                            cnnDB.Execute(sql)
                        End If
                        _txtProp_0.Tag = _txtProp_0.Text
                    End If
                    If _txtPrice_0.Text <> _txtPrice_0.Tag Then
                        sql = "DELETE FROM PriceChannelLnk WHERE PriceChannelLnk_Quantity=" & frmItem(x).Tag & " AND PriceChannelLnk_ChannelID=" & gChannelID & " AND PriceChannelLnk_StockItemID=" & gStockItemID
                        cnnDB.Execute(sql)
                        If _txtPrice_0.Text <> "" Then
                            sql = "INSERT INTO PriceChannelLnk (PriceChannelLnk_StockItemID, PriceChannelLnk_Quantity, PriceChannelLnk_ChannelID, PriceChannelLnk_Price) VALUES (" & gStockItemID & ", " & frmItem(x).Tag & ", " & gChannelID & ", " & Replace(_txtPrice_0.Text, ",", "") & ")"
                            cnnDB.Execute(sql)
                        End If
                        _txtPrice_0.Tag = _txtPrice_0.Text
                    End If
                Next
                If loading Then
                Else
                    If sql <> "" Then
                        sql = "INSERT INTO tempStockItem (tempStockItemID) SELECT StockItem.StockItemID FROM tempStockItem RIGHT OUTER JOIN StockItem ON tempStockItem.tempStockItemID = StockItem.StockItemID Where (StockItem.StockItemID = " & gStockItemID & ") And (tempStockItem.tempStockItemID Is Null)"
                        cnnDB.Execute(sql)
                    End If
                    If System.Drawing.ColorTranslator.ToOle(lblPriceSet.BackColor) = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red) Then

                        cnnDB.Execute("UPDATE (StockItem INNER JOIN PriceSet ON StockItem.StockItem_PriceSetID = PriceSet.PriceSetID) INNER JOIN StockItem AS StockItem_1 ON PriceSet.PriceSet_StockItemID = StockItem_1.StockItemID SET StockItem.StockItem_ShrinkID = [StockItem_1]![StockItem_ShrinkID], StockItem.StockItem_PricingGroupID = [StockItem_1]![StockItem_PricingGroupID], StockItem.StockItem_VatID = [StockItem_1]![StockItem_VatID], StockItem.StockItem_DepositID = [StockItem_1]![StockItem_DepositID], StockItem.StockItem_Quantity = [StockItem_1]![StockItem_Quantity], StockItem.StockItem_ListCost = [StockItem_1]![StockItem_ListCost] WHERE (((PriceSet.PriceSet_Disabled)=0) AND ((StockItem.StockItemID)<>[StockItem_1]![StockItemID]) AND (StockItem_1.StockItemID)=" & rsStockItem.Fields("StockitemID").Value & ");")
                        cnnDB.Execute("DELETE PropChannelLnk.* FROM (StockItem INNER JOIN PriceSet ON StockItem.StockItem_PriceSetID = PriceSet.PriceSetID) INNER JOIN PropChannelLnk ON StockItem.StockItemID = PropChannelLnk.PropChannelLnk_StockItemID WHERE (((PriceSet.PriceSet_Disabled)=0) AND ((StockItem.StockItemID)<>[PriceSet]![PriceSet_StockItemID]) AND ((PriceSet.PriceSetID)=" & rsStockItem.Fields("Stockitem_PriceSetID").Value & "));")
                        cnnDB.Execute("DELETE PriceChannelLnk.* FROM (StockItem INNER JOIN PriceSet ON StockItem.StockItem_PriceSetID = PriceSet.PriceSetID) INNER JOIN PriceChannelLnk ON StockItem.StockItemID = PriceChannelLnk.PriceChannelLnk_StockItemID WHERE (((PriceSet.PriceSet_Disabled)=0) AND ((StockItem.StockItemID)<>[PriceSet]![PriceSet_StockItemID]) AND ((PriceSet.PriceSetID)=" & rsStockItem.Fields("Stockitem_PriceSetID").Value & "));")
                        cnnDB.Execute("INSERT INTO PriceChannelLnk ( PriceChannelLnk_StockItemID, PriceChannelLnk_Quantity, PriceChannelLnk_ChannelID, PriceChannelLnk_Price ) SELECT StockItem.StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price FROM (StockItem INNER JOIN PriceSet ON StockItem.StockItem_PriceSetID = PriceSet.PriceSetID) INNER JOIN PriceChannelLnk ON PriceSet.PriceSet_StockItemID = PriceChannelLnk.PriceChannelLnk_StockItemID WHERE (((StockItem.StockItemID)<>[PriceSet]![PriceSet_StockItemID]) AND ((PriceSet.PriceSet_Disabled)=0) AND ((PriceSet.PriceSetID)=" & rsStockItem.Fields("Stockitem_PriceSetID").Value & "));")
                        cnnDB.Execute("INSERT INTO PropChannelLnk ( PropChannelLnk_StockItemID, PropChannelLnk_Quantity, PropChannelLnk_ChannelID, PropChannelLnk_Markup ) SELECT StockItem.StockItemID, PropChannelLnk.PropChannelLnk_Quantity, PropChannelLnk.PropChannelLnk_ChannelID, PropChannelLnk.PropChannelLnk_Markup FROM (StockItem INNER JOIN PriceSet ON StockItem.StockItem_PriceSetID = PriceSet.PriceSetID) INNER JOIN PropChannelLnk ON PriceSet.PriceSet_StockItemID = PropChannelLnk.PropChannelLnk_StockItemID WHERE (((StockItem.StockItemID)<>[PriceSet]![PriceSet_StockItemID]) AND ((PriceSet.PriceSet_Disabled)=0) AND ((PriceSet.PriceSetID)=" & rsStockItem.Fields("Stockitem_PriceSetID").Value & "));")
                        cnnDB.Execute("INSERT INTO tempStockItem ( tempStockItemID ) SELECT StockItem.StockItemID FROM tempStockItem RIGHT JOIN StockItem ON tempStockItem.tempStockItemID = StockItem.StockItemID WHERE (((tempStockItem.tempStockItemID) Is Null) AND ((StockItem.StockItem_PriceSetID)=" & rsStockItem.Fields("Stockitem_PriceSetID").Value & "));")

                    End If

                End If
            End If
        End If
    End Sub

    Private Function calcPrice(ByRef Index As Short) As Decimal
        Dim lPrice As Integer
        Dim rs As ADODB.Recordset
        Dim lMarkup As Decimal
        Dim lDeposit As Decimal
        Dim lPrivr As Decimal
        Dim lCost As Decimal
        Dim lQty As Decimal
        lQty = CShort(frmItem(Index).Tag)
        rs = getRS("SELECT PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk WHERE (((PriceChannelLnk.PriceChannelLnk_StockItemID)=" & gStockItemID & ") AND ((PriceChannelLnk.PriceChannelLnk_ChannelID)=1) AND ((PriceChannelLnk.PriceChannelLnk_Quantity)=" & lQty & "));")
        If rs.RecordCount Then
            calcPrice = rs.Fields(0).Value
        Else
            rs = getRS("SELECT PropChannelLnk.PropChannelLnk_Markup From PropChannelLnk WHERE (((PropChannelLnk.PropChannelLnk_StockItemID)=" & gStockItemID & ") AND ((PropChannelLnk.PropChannelLnk_Quantity)=" & lQty & ") AND ((PropChannelLnk.PropChannelLnk_ChannelID)=1));")
            If rs.RecordCount Then
                lMarkup = rs.Fields(0).Value
            Else
                If lQty > 1 Then
                    lMarkup = rsStockItem.Fields("PricingGroup_Case1").Value
                Else
                    lMarkup = rsStockItem.Fields("PricingGroup_Unit1").Value
                End If
            End If
            lDeposit = CDec(_lblDepositPack_0.Text) + CDec(_lblDepositUnit_0.Text)
            lCost = CDec(_txtCost_0.Text)
            lMarkup = 1 + lMarkup / 100
            lPrice = (lCost * lMarkup + lDeposit) * gVAT + 0.0049

            If lPrice > gRoundAfter And gNoPrice = False Then
                If lPrice * 100 Mod 100 <= gRoundDownUnits Then
                    If InStr(lPrice, ".") Then lPrice = CDec(VB.Left(lPrice, InStr(lPrice, ".")))
                    lPrice = lPrice
                Else
                    If InStr(lPrice, ".") Then lPrice = CDec(VB.Left(lPrice, InStr(lPrice, ".")))
                    lPrice = lPrice + 1
                End If
                lPrice = lPrice - gRemoveUnits / 100
            Else
                lPrice = System.Math.Round(lPrice + 0.045, 1)
            End If


            calcPrice = lPrice
        End If

    End Function

    Private Sub doChannel()
        Dim x As Short
        Dim rs As ADODB.Recordset
        saveChannel()
        gChannelID = CInt(cmbChannel.SelectedIndex)
        rs = getRS("SELECT * FROM Channel WHERE ChannelID = " & gChannelID)
        gNoPrice = rs.Fields("Channel_NoPricing").Value
        gCaseToUnit = rs.Fields("Channel_ShrinkIncrement").Value
        If IsDBNull(rs.Fields("Channel_MarkupType").Value) Then
            lblPricingGroupRule.Text = lblPricingGroupRule.Tag
            gPriceChannel1 = -1
        Else
            If rs.Fields("Channel_MarkupType").Value Then
                lblPricingGroupRule.Text = "This sale channel has been set to the default sale channels price plus the percentage defined in the department."

                gPriceChannel1 = 0
            Else
                lblPricingGroupRule.Text = lblPricingGroupRule.Tag
                gPriceChannel1 = -1
            End If
        End If
        rs.Close()
        If gPriceChannel1 <> -1 Then
            rs = getRS("SELECT * FROM Channel WHERE ChannelID = " & gChannelID)
        End If
        If cmbChannel.SelectedIndex <> -1 Then
            For x = 0 To frmItem.Count - 1
                If gPriceChannel1 = -1 Then
                    _lblMatrix_0.Tag = ""
                Else
                    'Set rs = getRS("SELECT CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)=" & frmItem(x).Tag & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)=" & gStockItemID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
                    _lblMatrix_0.Tag = calcPrice(x)
                End If

                rs = getRS("SELECT PricingGroupChannelLnk.PricingGroupChannelLnk_Markup From PricingGroupChannelLnk WHERE (((PricingGroupChannelLnk.PricingGroupChannelLnk_PricingGroupID)=" & rsStockItem.Fields("PricingGroupID").Value & ") AND ((PricingGroupChannelLnk.PricingGroupChannelLnk_Quantity)=" & frmItem(x).Tag & ") AND ((PricingGroupChannelLnk.PricingGroupChannelLnk_PackSizeID)=" & rsStockItem.Fields("StockItem_PackSizeID").Value & ") AND ((PricingGroupChannelLnk.PricingGroupChannelLnk_ChannelID)=" & gChannelID & "));")

                '_lblMatrix_0.Font = FontStyle.Bold
                If rs.BOF Or rs.EOF Then
                    If CShort(frmItem(x).Tag) > 1 Then
                        _lblMatrix_0.Text = FormatNumber(rsStockItem.Fields("PricingGroup_Case" & gChannelID).Value, 2)
                    Else
                        _lblMatrix_0.Text = FormatNumber(rsStockItem.Fields("PricingGroup_Unit" & gChannelID).Value, 2)
                    End If
                Else
                    _lblMatrix_0.Text = FormatNumber(rs.Fields("PricingGroupChannelLnk_Markup").Value, 2)
                End If


                rs = getRS("SELECT PropChannelLnk.PropChannelLnk_Markup From PropChannelLnk WHERE (((PropChannelLnk.PropChannelLnk_StockItemID)=" & gStockItemID & ") AND ((PropChannelLnk.PropChannelLnk_Quantity)=" & frmItem(x).Tag & ") AND ((PropChannelLnk.PropChannelLnk_ChannelID)=" & gChannelID & "));")
                If rs.BOF Or rs.EOF Then
                    _txtProp_0.Text = ""
                Else
                    _txtProp_0.Text = FormatNumber(rs.Fields("PropChannelLnk_Markup").Value, 2)
                End If
                rs.Close()
                _txtProp_0.Tag = _txtProp_0.Text
                rs = getRS("SELECT PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk WHERE (((PriceChannelLnk.PriceChannelLnk_StockItemID)=" & gStockItemID & ") AND ((PriceChannelLnk.PriceChannelLnk_Quantity)=" & frmItem(x).Tag & ") AND ((PriceChannelLnk.PriceChannelLnk_ChannelID)=" & gChannelID & "));")

                If rs.BOF Or rs.EOF Then
                    _txtPrice_0.Text = ""
                Else


                    _txtPrice_0.Text = FormatNumber(rs.Fields("PriceChannelLnk_Price").Value, 2)
                End If



                rs.Close()
                _txtPrice_0.Tag = _txtPrice_0.Text
                Calculate(x)
            Next
        End If
    End Sub

    Private Sub loadControl(ByRef lControl As Object, ByRef Index As Integer)
        lControl.Load(Index)
        lControl(Index).Container = frmItem(Index)
        lControl(Index).Visible = True
    End Sub
    Private Sub Calculate(ByRef Index As Short)
        Dim templPrice As Decimal
        Dim lCost As Decimal
        Dim lDeposit As Decimal
        Dim lMarkup As Decimal
        Dim lPrice As Decimal

        On Error Resume Next

        lDeposit = CDec(_lblDepositPack_0.Text) + CDec(_lblDepositUnit_0.Text)
        lCost = CDec(_txtCost_0.Text)
        _lblSection_0.BackColor = System.Drawing.ColorTranslator.FromOle(65280)
        _lblSection_0.ForeColor = System.Drawing.Color.Black
        _lblSection_0.Text = "Matrix"

        lMarkup = CDec(_lblMatrix_0.Text)
        If _txtProp_0.Text <> "" Then
            lMarkup = _txtProp_0.Text
            _lblSection_0.BackColor = System.Drawing.ColorTranslator.FromOle(33023)
            _lblSection_0.ForeColor = System.Drawing.Color.White
            _lblSection_0.Text = "Propped"
        End If
        lMarkup = 1 + lMarkup / 100
        '    Me.lblVat(Index).Caption = FormatNumber((lCost * lMarkup + lDeposit) * gVat) - (lCost * lMarkup + lDeposit)
        lPrice = (lCost * lMarkup + lDeposit) * gVAT + 0.0049
        templPrice = CDbl(CStr(lPrice)) * 100
        templPrice = CShort(templPrice)
        lPrice = templPrice / 100
        _lblMarkup_0.Text = FormatNumber(lPrice)
        If _lblMatrix_0.Tag <> "" Then
            lPrice = CDec(_lblMatrix_0.Tag)

            lPrice = lPrice * lMarkup
            _lblMarkup_0.Text = FormatNumber(lPrice)
        Else
            If lPrice > gRoundAfter And gNoPrice = False Then
                If lPrice * 100 Mod 100 <= gRoundDownUnits Then
                    If InStr(CStr(lPrice), ".") Then lPrice = CDec(VB.Left(CStr(lPrice), InStr(CStr(lPrice), ".")))
                    lPrice = lPrice
                Else
                    If InStr(CStr(lPrice), ".") Then lPrice = CDec(VB.Left(CStr(lPrice), InStr(CStr(lPrice), ".")))
                    lPrice = lPrice + 1
                End If
                lPrice = lPrice - gRemoveUnits / 100
            Else
                lPrice = System.Math.Round(lPrice + 0.045, 1)
            End If

            If gCaseToUnit Then
                If Index Then
                    lPrice = System.Math.Round(CDec(_lblPrice_0.Text) - (CDec(_lblDepositUnit_0.Text) + CDec(_lblDepositPack_0.Text)) * gVAT, 2) * CDbl(_frmItem_0.Tag) + (lDeposit * gVAT)
                End If
            End If
        End If

        If _txtPrice_0.Text <> "" Then
            lPrice = CDec(_txtPrice_0.Text)
            _lblSection_0.BackColor = System.Drawing.ColorTranslator.FromOle(255)
            _lblSection_0.ForeColor = System.Drawing.Color.White
            _lblSection_0.Text = "Over-ride"
        End If

        _lblPrice_0.Text = FormatNumber(lPrice)
        _lblVat_0.Text = FormatNumber(lPrice - lPrice / gVAT, 2)

        If lCost = 0 Then
            _lblPercent_0.Text = FormatNumber("0", 2)
            _lblProfitPrecent_0.Text = FormatNumber("0", 2)
            _lblProfitAmount_0.Text = FormatNumber("0", 2)
        Else
            _lblPercent_0.Text = FormatNumber((((lPrice / gVAT - lDeposit) / lCost) - 1) * 100, 4) & "%"
            If (lPrice - lDeposit) = 0 Then
                _lblGP_0.Text = FormatNumber(0, 2)
            Else
                _lblGP_0.Text = FormatNumber((((lPrice / gVAT - lDeposit) - lCost) / (lPrice / gVAT - lDeposit)) * 100, 4) & "%"
            End If
            If (lPrice / gVAT - lDeposit) * 100 Then
                'UPGRADE_WARNING: Couldn't resolve default property of object gVAT. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                _lblGPActual_0.Text = FormatNumber((((lPrice / gVAT - lDeposit) - CDec(_txtVariableCost_0.Text)) / (lPrice / gVAT - lDeposit)) * 100, 4) & "%"
            Else
                _lblGPActual_0.Text = FormatNumber(0, 4) & "%"
            End If

            _lblProfitPrecent_0.Text = FormatNumber((((lPrice / gVAT - lDeposit) - CDec(_txtVariableCost_0.Text)) / CDec(_txtVariableCost_0.Text)) * 100, 4) & "%"
            _lblProfitAmount_0.Text = FormatNumber((lPrice / gVAT - lDeposit) - CDec(_txtVariableCost_0.Text), 2)
        End If
    End Sub

    'UPGRADE_NOTE: GotFocus was upgraded to GotFocus_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub GotFocus_Renamed(ByRef lControl As Object)
        'UPGRADE_WARNING: Couldn't resolve default property of object lControl.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    lControl.Text = Replace(lControl.Text, ",", "")
        'UPGRADE_WARNING: Couldn't resolve default property of object lControl.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '   lControl.Text = Replace(lControl.Text, ".", "")
        'UPGRADE_WARNING: Couldn't resolve default property of object lControl.SelStart. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '  lControl.SelStart = 0
        'UPGRADE_WARNING: Couldn't resolve default property of object lControl.SelLength. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object lControl.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ' lControl.SelLength = Len(lControl.Text)
    End Sub

    'UPGRADE_NOTE: KeyPress was upgraded to KeyPress_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub KeyPress_Renamed(ByRef KeyAscii As Short)
        ' Select Case KeyAscii
        '     Case Asc(vbCr)
        ' KeyAscii = 0
        '    Case 8
        '    Case 48 To 57
        '    Case Else
        'KeyAscii = 0
        'End Select
    End Sub

    'UPGRADE_NOTE: LostFocus was upgraded to LostFocus_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub LostFocus_Renamed(ByRef lControl As Object, ByRef lDecimal As Object)
        'UPGRADE_WARNING: Couldn't resolve default property of object lControl.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If lControl.Text = "" Then Exit Sub
        'UPGRADE_WARNING: Couldn't resolve default property of object lDecimal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If lDecimal Then

        'UPGRADE_WARNING: Couldn't resolve default property of object lControl.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ' lControl.Text = lControl.Text / 100
        ' End If
        'UPGRADE_WARNING: Couldn't resolve default property of object lControl.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object lDecimal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'lControl.Text = FormatNumber(lControl.Text, lDecimal)
    End Sub

    Private Sub cmdbarcode_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdbarcode.Click
        'Here a public function barcode is called from a form named frmStockItem
        Call LoadItemses()

    End Sub


    Private Sub cmdDetails_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDetails.Click
        cmdDetails.Focus()
        System.Windows.Forms.Application.DoEvents()
        Dim lID As Integer
        lID = gStockItemID
        Me.Close()
        frmStockItem.loadItem(lID)
        frmStockItem.ShowDialog()
    End Sub

    Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
        cmdExit.Focus()
        System.Windows.Forms.Application.DoEvents()
        saveData()
        Me.Close()

        '  'if edited item is for stockitem from frmstocklist
        '    If HoldP <> "" And frmStockItemNew.txtReceipt.Text = "" Then
        '    frmStockList.editItem 0
        '    HoldP = frmStockItem.txttemphold.Text
        '    frmStockList.show 1
        '    Exit Sub
        '   'if Edited item is for frmstockPricing from frmstocklist
        '    ElseIf hold = "" And frmStockItemNew.txtReceipt.Text = "" Then
        '    frmStockList.editItem 1
        '    frmStockList.show 1
        '    Exit Sub
        '    End If

    End Sub
    Private Sub cmdHistory_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdHistory.Click
        Dim lID As Integer
        lID = gStockItemID
        frmStockItemHistory.loadItem(lID)
    End Sub

    Private Sub cmdNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNext.Click
        If frmStockList.Visible = True Then 'cmdClose_Click
            If blNextItem = True Then
                cmdExit_Click(cmdExit, New System.EventArgs())
            ElseIf blNextItem = False Then
                cmdExit_Click(cmdExit, New System.EventArgs())
                frmStockList.DataList1_DblClickS()
            End If
        End If
    End Sub

    Private Sub cmdUndo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUndo.Click
        cmdUndoFocus = True
        Dim x As Short
        System.Windows.Forms.Application.DoEvents()
        cmdUndo.Focus()
        System.Windows.Forms.Application.DoEvents()
        For x = 0 To frmItem.Count - 1
            _txtCost_0.Text = _txtCost_0.Tag
            _txtPrice_0.Text = _txtPrice_0.Tag
            _txtProp_0.Text = _txtProp_0.Tag
            _txtVariableCost_0.Text = _txtVariableCost_0.Tag
            Calculate(x)
        Next
        System.Windows.Forms.Application.DoEvents()
        cmdUndoFocus = False
    End Sub

    Private Sub Command1_Click()
        loadItem(gStockItemID)
    End Sub

    Private Sub frmStockPricing_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KeyCode
            Case System.Windows.Forms.Keys.Escape
                cmdExit_Click(cmdExit, New System.EventArgs())
        End Select
    End Sub





    'UPGRADE_WARNING: Event frmStockPricing.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub frmStockPricing_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        cmdExit.Left = twipsToPixels(pixelToTwips(Me.ClientRectangle.Width, True) - pixelToTwips(cmdExit.Width, True) - 120, True)
    End Sub

    Private Sub frmStockPricing_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        loading = True


        saveData()
        cnnDB.Execute("DELETE PropChannelLnk.PropChannelLnk_Markup From PropChannelLnk WHERE (((PropChannelLnk.PropChannelLnk_Markup)=0));")
        gStockItemID = 0
        gChannelID = 0
        loading = False

    End Sub

    Private Sub txtCost_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _txtCost_0.Enter

        MyGotFocusNumeric(_txtCost_0)
        priceBox = CDec(_txtCost_0.Text)
        '    Calculate Index
    End Sub

    Private Sub txtCost_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles _txtCost_0.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'Dim Index As Short = txtCost.GetIndex(eventSender)
        MyKeyPress(KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtCost_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _txtCost_0.Leave
        Dim Index As Integer = 0


        ChildPriceChang = False
        Dim rs As ADODB.Recordset
        If priceBox <> CDbl(_txtCost_0.Text) Then
            'check if stockitem is part of priceset
            If rsStockItem.Fields("StockItem_PriceSetID").Value > 0 Then
                'check if stockitem is child or parent
                rs = getRS("SELECT * FROM PriceSet WHERE PriceSetID = " & rsStockItem.Fields("StockItem_PriceSetID").Value)
                If rsStockItem.Fields("StockItemID").Value = rs.Fields("PriceSet_StockItemID").Value Then
                    'parent
                    MsgBox("This is Primary Stock Item of Pricing Set, changing of price will effect on all Child Stock Item those are part of this set.", MsgBoxStyle.Exclamation)
                Else
                    'child
                    ParentPriceID = rs.Fields("PriceSet_StockItemID").Value
                    If cmdUndoFocus = False Then
                        If MsgBox("This is Child Stock Item of Pricing Set, changing of price of this Item will effect on Primary Stock Item and all Child Stock Item those are part of this set. " & vbCrLf & "Do you want to change ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            ChildPriceChang = False
                            ParentPriceChang = True
                        Else
                            ChildPriceChang = True
                        End If
                    End If
                End If
                rs.Close()
            End If
        End If

        MyLostFocus(_txtCost_0, 2)
        Dim x As Short
        Dim lValue As Decimal
        lValue = CDec(Replace(_txtCost_0.Text, ",", "")) / CDbl(_frmItem_0.Tag)
        For x = 0 To frmItem.Count - 1
            If x <> Index Then
                _txtCost_0.Text = FormatNumber(lValue * CDbl(_frmItem_0.Tag), 2)
                Calculate(x)
            End If
        Next
        Calculate(Index)

        If ChildPriceChang = True Then cmdUndo_Click(cmdUndo, New System.EventArgs())

        System.Windows.Forms.Application.DoEvents()
    End Sub

    Private Sub txtfields1_Change()
        'If Index = 14 Then Index = 0
        'If Index = 0 Then Index = 14

        'GotFocus txtfields1(Index)
    End Sub

    Private Sub txtfields1_Click()

    End Sub

    Private Sub txtPrice_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _txtPrice_0.Enter
        'Dim Index As Short = txtPrice.GetIndex(eventSender)
        If _txtPrice_0.Text <> "" Then
            MyGotFocusNumeric(_txtPrice_0)
        End If
    End Sub

    Private Sub txtPrice_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles _txtPrice_0.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'Dim Index As Short = txtPrice.GetIndex(eventSender)
        MyKeyPress(KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPrice_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _txtPrice_0.Leave
        'Dim Index As Short = txtPrice.GetIndex(eventSender)
        If _txtPrice_0.Text <> "" Then
            MyLostFocus(_txtPrice_0, 2)
        End If
        Calculate(0)
    End Sub

    Private Sub txtProp_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _txtProp_0.Enter
        'Dim Index As Short = txtProp.GetIndex(eventSender)
        If _txtProp_0.Text <> "" Then
            MyGotFocusNumeric(_txtProp_0)
        End If
    End Sub

    Private Sub txtProp_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles _txtProp_0.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'Dim Index As Short = txtProp.GetIndex(eventSender)
        Dim lCurrentX As Short
        Select Case KeyAscii
            Case 45 '-
                If InStr(_txtProp_0.Text, "-") Then
                Else
                    lCurrentX = _txtProp_0.SelectionStart + 1
                    _txtProp_0.Text = "-" & _txtProp_0.Text
                    _txtProp_0.SelectionStart = lCurrentX

                End If
                KeyAscii = 0
            Case 43 '+
                If InStr(_txtProp_0.Text, "-") Then
                    lCurrentX = _txtProp_0.SelectionStart - 1
                    _txtProp_0.Text = VB.Right(_txtProp_0.Text, Len(_txtProp_0.Text) - 1)
                    If lCurrentX < 0 Then lCurrentX = 0
                    _txtProp_0.SelectionStart = lCurrentX

                End If
                KeyAscii = 0
            Case Else
                KeyPress_Renamed(KeyAscii)
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtProp_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _txtProp_0.Leave
        'Dim Index As Short = txtProp.GetIndex(eventSender)
        If _txtProp_0.Text <> "" Then
            MyLostFocus(_txtProp_0, 2)
        End If
        Calculate(0)
    End Sub

    Private Sub txtVariableCost_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _txtVariableCost_0.Enter
        'Dim Index As Short = txtVariableCost.GetIndex(eventSender)
        MyGotFocusNumeric(_txtVariableCost_0)
    End Sub

    Private Sub txtVariableCost_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles _txtVariableCost_0.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'Dim Index As Short = txtVariableCost.GetIndex(eventSender)
        MyKeyPress(KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtVariableCost_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _txtVariableCost_0.Leave
        'Dim Index As Short = txtVariableCost.GetIndex(eventSender)
        MyLostFocus(_txtVariableCost_0, 2)
        Dim x As Short
        Dim lValue As Decimal
        lValue = CDec(Replace(_txtVariableCost_0.Text, ",", "")) / CDbl(_frmItem_0.Tag)
        For x = 0 To frmItem.Count - 1
            If x <> 0 Then
                _txtVariableCost_0.Text = FormatNumber(lValue * CDbl(_frmItem_0.Tag), 2)
                Calculate(x)
            End If
        Next
        Calculate(0)
    End Sub
	Public Sub LoadItemses()
		'*
        frmStockBarcode.loadItem(rsStockItem.Fields("StockItemID").Value)
        Dim form As frmStockBarcode
        form.Show()
		'*
	End Sub

    Private Sub frmStockPricing_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        frmItem.AddRange(New GroupBox() {_frmItem_0})
        lblSelection.AddRange(New Label() {_lblSection_0})
    End Sub
End Class