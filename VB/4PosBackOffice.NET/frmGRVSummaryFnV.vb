Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmGRVSummaryFnV
	Inherits System.Windows.Forms.Form
	'Option Explicit
	Dim intComp As Short
	Dim arrMainItems() As Integer
	Dim bLoading As Boolean
    Dim WithEvents Frame1 As New List(Of GroupBox)
    Dim WithEvents lbl As New List(Of Label)
    Dim WithEvents optClose As New List(Of RadioButton)
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1720 'GRV Summary and Process|
		If rsLang.RecordCount Then frmGRVSummary.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : frmGRVSummary.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1579 'Back|Checked
		If rsLang.RecordCount Then cmdBack.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdBack.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'Picture1 = No Code/Dynamic/NA?
		
		'frmMain = No Code
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmMain.Caption = rsLang("LanguageLayoutLnk_Description"): frmMain.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1722 'Purchased Content / Liquid|Checked
		If rsLang.RecordCount Then Frame1(0).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Frame1(0).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		'lbl(32) = No code      [No of Lines]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lbl(32).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(32).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lbl(20) = No Code      [Contents Value]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lbl(20).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(20).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1725 'Line Item Discount|Checked
		If rsLang.RecordCount Then lbl(21).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl(21).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		
		'NOTE: DB Entry 1726 Contains 2x different Entries!!!!
		'----> Second entry clashes with DB Entry 1460!
		
		
		'First entry of 1726 is fit for use, but disabled to verify if fixed
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1726 'Content Sub Total|
		'If rsLang.RecordCount Then lbl(31).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(31).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1460 'Payment Terms|Checked
		If rsLang.RecordCount Then lbl(19).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl(19).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1727 'Account Discount|Checked
		If rsLang.RecordCount Then lblDiscountName.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lblDiscountName.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1728 'Ullage @|Checked
		If rsLang.RecordCount Then Label2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1729 'Sundry Plusses|Checked
		If rsLang.RecordCount Then lbl(10).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl(10).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1731 'Sundry Minuses|Checked
		If rsLang.RecordCount Then lbl(11).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl(11).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1751 'Exclusive|Checked
		If rsLang.RecordCount Then lbl(22).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl(22).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lbl(29) = No Code      [VAT]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lbl(29).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(29).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1753 'Inclusive|Checked
		If rsLang.RecordCount Then lbl(30).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl(30).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1735 'Deposits with Purchases|
		If rsLang.RecordCount Then Frame1(1).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Frame1(1).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1736 'Deposit Value|Checked
		If rsLang.RecordCount Then _lbl_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lbl(13) = No Code      [VAT]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lbl(13).Caption = rsLang("LanguageLayoutLnk_Description"): lb(13).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1753 'Inclusive|Checked
		If rsLang.RecordCount Then lbl(14).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl(14).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'Frame1(5) = No Code    [Purchased Deposits]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Frame1(5).Caption = rsLang("LanguageLayoutLnk_Description"): Frame1(5).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1736 'Deposit Value|Checked
		If rsLang.RecordCount Then lbl(35).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl(35).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lbl(34) = No Code      [VAT]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		If rsLang.RecordCount Then lbl(34).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl(34).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1753 'Inclusive|Checked
		If rsLang.RecordCount Then lbl(33).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl(33).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1742 'Out Bound VAT|Checked
		If rsLang.RecordCount Then lbl(8).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl(8).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1743 'Purchases Inclusive|Checked
		If rsLang.RecordCount Then _lbl_6.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_6.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1744 'Desired Invoice Value|Checked
		If rsLang.RecordCount Then _lbl_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1746 'Difference|Checked
		If rsLang.RecordCount Then lbl(18).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl(18).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1747 'Credited Content / Liquid|Checked
		If rsLang.RecordCount Then Frame1(3).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Frame1(3).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lbl(37) = No Code      [No Of Lines]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then COMPONENT(0).Caption = rsLang("LanguageLayoutLnk_Description"): COMPONENT(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_1 = No Code       [Contents Value]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1725 'Line Item Discount|Checked
		If rsLang.RecordCount Then _lbl_3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1751 'Exclusive\Checked
		If rsLang.RecordCount Then _lbl_4.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_4.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lbl_5 = No Code       [VAT]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_5.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1753 'Inclusive|Checked
		If rsLang.RecordCount Then lbl(12).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl(12).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1754 'Deposits with Credits|Checked
		If rsLang.RecordCount Then Frame1(4).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Frame1(4).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1758 'Credits VAT|Checked
		If rsLang.RecordCount Then lbl(26).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl(26).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1759 'Credits Inclusive|Checked
		If rsLang.RecordCount Then lbl(25).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl(25).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1760 'Returned Deposits|Checked
		If rsLang.RecordCount Then Frame1(2).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Frame1(2).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1736 'Deposit Value|Checked
		If rsLang.RecordCount Then lbl(17).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl(17).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lbl(16) = No Code      [VAT]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lbl(16).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(16).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1753 'Inclusive|Checked
		If rsLang.RecordCount Then lbl(15).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl(15).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1764 'In Bound VAT|Checked
		If rsLang.RecordCount Then lbl(28).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl(28).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1765 'Credit Inclusive|Checked
		If rsLang.RecordCount Then lbl(27).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl(27).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1766 'Nett Invoice Value|Checked
		If rsLang.RecordCount Then _lbl_7.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_7.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'frmProcess = No Code   [Process this 'Goods Receiving Voucher']
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmProcess.Caption = rsLang("LanguageLayoutLnk_Description"): frmProcess.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1768 'This Purchase Order has been delivered in full|Checked
		If rsLang.RecordCount Then optClose(0).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : optClose(0).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1328 'Notes|Checked
		If rsLang.RecordCount Then Label3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1332 'Process|Checked
		If rsLang.RecordCount Then cmdNext.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdNext.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmGRVSummaryFnV.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Sub doTotals()
		Dim lContent, lDeposit As Decimal
        Dim lQuantity As Integer
		Dim lContentReturn, lDepositReturn As Decimal
		Me.lblDiscount.Text = FormatNumber(0 - CDec(lblContentExclusiveIn.Text) * CDec(txtDiscount.Text) / 100, 2)
		lblUllage.Text = FormatNumber(0 - CDec(lblContentExclusiveIn.Text) * CDbl(Me.txtUllage.Text) / 100, 2)
		lblExclusiveIn.Text = FormatNumber(CDec(lblContentExclusiveIn.Text) + CDec(Me.lblDiscount.Text) + CDec(lblUllage.Text) + CDec(txtPlus.Text) - CDec(txtMinus.Text), 2)
		lblVATin.Text = FormatNumber(CDec(lblExclusiveIn.Text) * CDec(lblVatRateIn.Text) / 100, 2)
		lblInclusiveIn.Text = FormatNumber(CDec(lblExclusiveIn.Text) + CDec(lblVATin.Text), 2)
		Me.lblOutBoundVat.Text = FormatNumber(CDec(lblVATin.Text) + CDec(lblDepositVatIn.Text) + CDec(lblDepositReturnVatIn.Text), 2)
		Me.lblOutBound.Text = FormatNumber(CDec(lblInclusiveIn.Text) + CDec(lblDepositInclusiveIn.Text) + CDec(lblDepositReturnInclusiveIn.Text), 2)
		
		lblDifference.Text = FormatNumber(CDec(lblOutBound.Text) - CDec(lblTotalOriginal.Text), 2)
		Me.lblTotal.Text = FormatNumber(CDec(lblOutBound.Text) - CDec(lblInBound.Text), 2)
	End Sub
	Private Sub cmbPayment_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbPayment.SelectedIndexChanged
		Dim lString As String
		If cmbPayment.SelectedIndex <> -1 Then
            Select Case CInt(cmbPayment.SelectedIndex)
                Case 0
                    lString = "Supplier_discountCOD"
                Case 1
                    lString = "Supplier_discount15days"
                Case 2
                    lString = "Supplier_discount30days"
                Case 3
                    lString = "Supplier_discount60days"
                Case 4
                    lString = "Supplier_discount90days"
                Case 5
                    lString = "Supplier_discount120days"
                Case 6
                    lString = "Supplier_discountSmartCard"
            End Select
			If IsDbNull(frmGRV.adoPrimaryRS.Fields(lString).Value) Then
				Me.txtDiscount.Text = FormatNumber("0", 2)
			Else
				Me.txtDiscount.Text = FormatNumber(frmGRV.adoPrimaryRS.Fields(lString).Value * 100, 2)
			End If
		Else
			Me.txtDiscount.Text = FormatNumber("0", 2)
		End If
		txtDiscount_Leave(txtDiscount, New System.EventArgs())
	End Sub
	Private Sub cmdBack_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBack.Click
		saveDetails()
		Me.Close()
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		bolFNVegGRV = False
		Me.Close()
		frmGRVDeposit.Close()
		frmGRVitemFnV.Close()
		frmGRV.Close()
	End Sub
	
	Private Sub CreateVegItems(ByRef sID As Integer, ByRef lgetNewID As Integer)
        Dim newATItem As Integer
        Dim sql As String
        Dim gBrandItem As Integer
        Dim gStockItem As Integer
		
		System.Windows.Forms.Application.DoEvents()
		gStockItem = 0
		gBrandItem = 0
		On Error GoTo cErrorHndlr
		'Dim rsSupp          As Recordset
		'Dim rsDep          As Recordset
		'Dim rsPriceG          As Recordset
		'Dim rsStockG          As Recordset
		'Dim rsReportG          As Recordset
		Dim rs As ADODB.Recordset
		Dim rsCostPrice As ADODB.Recordset
		Dim rsSellPrice As ADODB.Recordset
		Dim aCost As Decimal
		Dim sPrice As Decimal
		
		sql = "SELECT StockItem.StockItemID, StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_ListCost, StockItem.StockItem_ActualCost, Catalogue.Catalogue_Barcode "
		sql = sql & "FROM (StockItem INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID "
		sql = sql & "WHERE (((StockItem.StockItemID)=" & sID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)=1) AND ((Catalogue.Catalogue_Quantity)=1));"
		rsCostPrice = getRS(sql)
		
		'new chck to skip K/B items
		If VB.Right(rsCostPrice.Fields("StockItem_Name").Value, 3) = "k/b" Then
			lgetNewID = sID
			Exit Sub
		End If
		
		sql = "INSERT INTO StockItem ( StockItem_BrandItemID, StockItem_SupplierID, StockItem_ShrinkID, StockItem_PackSizeID, StockItem_PricingGroupID, StockItem_StockGroupID, StockItem_VatID, StockItem_DepositID, StockItem_Name, StockItem_ReceiptName, StockItem_Quantity, StockItem_ListCost, StockItem_ActualCost, StockItem_MinimumStock, StockItem_MaximumStock, StockItem_OrderQuantity, StockItem_OrderRounding, StockItem_OrderDynamic, StockItem_Disabled, StockItem_Discontinued, StockItem_SupplierCode, StockItem_ActualCostChange, StockItem_PriceSetID, StockItem_LastCost, StockItem_Parameters, StockItem_Fractions, StockItem_NegSale, StockItem_VariablePrice, StockItem_NonWeighted, StockItem_PrintLocationID, StockItem_RecipeType, StockItem_PrintGroupID, StockItem_SerialTracker, StockItem_SBarcode, StockItem_SShelf, StockItem_ReportID, StockItemOrderType, StockItem_ATItem, StockItem_ATStockTypeID, StockItem_ExpiryDays ) "
		sql = sql & "SELECT StockItem.StockItem_BrandItemID, StockItem.StockItem_SupplierID, StockItem.StockItem_ShrinkID, StockItem.StockItem_PackSizeID, StockItem.StockItem_PricingGroupID, StockItem.StockItem_StockGroupID, StockItem.StockItem_VatID, StockItem.StockItem_DepositID, [StockItem].[StockItem_Name] & ' # " & Format(Today, "dd/mm") & "' AS StockItemName, [StockItem].[StockItem_ReceiptName] & ' # " & Format(Today, "dd/mm") & "' AS StockItemReceiptName, StockItem.StockItem_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_ActualCost, StockItem.StockItem_MinimumStock, StockItem.StockItem_MaximumStock, StockItem.StockItem_OrderQuantity, StockItem.StockItem_OrderRounding, StockItem.StockItem_OrderDynamic, StockItem.StockItem_Disabled, StockItem.StockItem_Discontinued, "
		'sql = sql & "SELECT StockItem.StockItem_BrandItemID, StockItem.StockItem_SupplierID, StockItem.StockItem_ShrinkID, StockItem.StockItem_PackSizeID, StockItem.StockItem_PricingGroupID, StockItem.StockItem_StockGroupID, StockItem.StockItem_VatID, StockItem.StockItem_DepositID, [StockItem].[StockItem_Name] & ' # " & Format(Date, "dd/mm") & "' AS StockItemName, [StockItem].[StockItem_ReceiptName] & ' # " & Format(Date, "dd/mm") & "' AS StockItemReceiptName, StockItem.StockItem_Quantity, " & CCur(txtR.Text) & " AS StockItemListCost, " & CCur(txtR.Text) & " AS StockItemActualCost, StockItem.StockItem_MinimumStock, StockItem.StockItem_MaximumStock, StockItem.StockItem_OrderQuantity, StockItem.StockItem_OrderRounding, StockItem.StockItem_OrderDynamic, StockItem.StockItem_Disabled, StockItem.StockItem_Discontinued, StockItem.StockItem_SupplierCode, StockItem.StockItem_ActualCostChange, StockItem.StockItem_PriceSetID, "
		sql = sql & "StockItem.StockItem_SupplierCode, StockItem.StockItem_ActualCostChange, StockItem.StockItem_PriceSetID, StockItem.StockItem_LastCost, StockItem.StockItem_Parameters, StockItem.StockItem_Fractions, StockItem.StockItem_NegSale, StockItem.StockItem_VariablePrice, StockItem.StockItem_NonWeighted, StockItem.StockItem_PrintLocationID, StockItem.StockItem_RecipeType, StockItem.StockItem_PrintGroupID, StockItem.StockItem_SerialTracker, StockItem.StockItem_SBarcode, StockItem.StockItem_SShelf, StockItem.StockItem_ReportID, StockItem.StockItemOrderType, StockItem.StockItem_ATItem, StockItem.StockItem_ATStockTypeID, StockItem.StockItem_ExpiryDays "
		sql = sql & "From StockItem WHERE (((StockItem.StockItemID)=" & sID & "));"
		'sql = "INSERT INTO StockItem (StockItem_BrandItemID, StockItem_SupplierID, StockItem_ShrinkID, StockItem_PackSizeID, StockItem_PricingGroupID, StockItem_StockGroupID, StockItem_VatID, StockItem_DepositID, StockItem_Name, StockItem_ReceiptName, StockItem_Quantity, StockItem_ListCost, StockItem_ActualCost, StockItem_MinimumStock, StockItem_MaximumStock, StockItem_OrderQuantity, StockItem_OrderRounding, StockItem_OrderDynamic, StockItem_Disabled, StockItem_Discontinued, StockItem_QuickKey, StockItem_NegSale, StockItem_PrintLocationID, StockItem_SerialTracker, StockItem_ReportID, StockItem_ATItem, StockItem_ATStockTypeID) VALUES ("
		'sql = sql & gBrandItem & ", " & 2 & ", " & 1 & ", " & 1 & ", " & rsPriceG(0) & ", " & rsStockG(0) & ", 2, " & rsDep(0) & ", '" & csvDESC & "', '" & csvDESC & "', " & Replace(1, ",", "") & ", " & Replace(aCost, ",", "") & ", " & Replace(aCost, ",", "") & ", 0, 0, " & CCur(1) & ", 1, 0, 0, 0, '" & csvBarcode & "', True, 1, True, " & rsReportG(0) & ", True, 0)"
		Debug.Print(sql)
		cnnDB.Execute(sql)
		
		sql = "SELECT Max(StockItem.StockItemID) AS id FROM StockItem;"
		rs = getRS(sql)
		gStockItem = rs.Fields("id").Value
		lgetNewID = gStockItem
		cnnDB.Execute("UPDATE StockItem, Company SET StockItem.StockItem_LastCost = [Company_DayEndID] WHERE (((StockItem.StockItemID)=" & gStockItem & "));")
		cnnDB.Execute("UPDATE StockItem INNER JOIN BrandItemSupplier ON (StockItem.StockItem_SupplierID = BrandItemSupplier.BrandItemSupplier_SupplierID) AND (StockItem.StockItem_BrandItemID = BrandItemSupplier.BrandItemSupplier_BrandItemID) SET StockItem.StockItem_SupplierCode = [BrandItemSupplier]![BrandItemSupplier_Code] WHERE (((StockItem.StockItemID)=" & gStockItem & "));")
		'Multi Warehouse change
		cnnDB.Execute("INSERT INTO DayEndStockItemLnk ( DayEndStockItemLnk_DayEndID, DayEndStockItemLnk_StockItemID, DayEndStockItemLnk_Quantity, DayEndStockItemLnk_QuantitySales, DayEndStockItemLnk_QuantityShrink, DayEndStockItemLnk_QuantityGRV, DayEndStockItemLnk_ListCost, DayEndStockItemLnk_ActualCost, DayEndStockItemLnk_Warehouse ) SELECT Company.Company_DayEndID, " & gStockItem & " AS stock, 0, 0, 0, 0, " & rsCostPrice.Fields("StockItem_ListCost").Value & ", " & rsCostPrice.Fields("StockItem_ActualCost").Value & ", Warehouse.WarehouseID FROM Company, Warehouse;")
		'cnnDB.Execute "INSERT INTO DayEndStockItemLnk ( DayEndStockItemLnk_DayEndID, DayEndStockItemLnk_StockItemID, DayEndStockItemLnk_Quantity, DayEndStockItemLnk_QuantitySales, DayEndStockItemLnk_QuantityShrink, DayEndStockItemLnk_QuantityGRV, DayEndStockItemLnk_ListCost, DayEndStockItemLnk_ActualCost, DayEndStockItemLnk_Warehouse ) SELECT Company.Company_DayEndID, " & gStockItem & " AS stock, 0, 0, 0, 0, " & (CCur(IIf(sPackVol = 0, 1, sPackVol) * CCur(txtR.Text))) & ", " & (CCur(IIf(sPackVol = 0, 1, sPackVol) * CCur(txtR.Text))) & ", Warehouse.WarehouseID FROM Company, Warehouse;"
		cnnDB.Execute("INSERT INTO WarehouseStockItemLnk ( WarehouseStockItemLnk_WarehouseID, WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk_Quantity ) SELECT Warehouse.WarehouseID, " & gStockItem & ", 0 FROM Warehouse;")
		cnnDB.Execute("INSERT INTO tempStockItem ( tempStockItemID ) SELECT StockItem.StockItemID FROM tempStockItem RIGHT JOIN StockItem ON tempStockItem.tempStockItemID = StockItem.StockItemID WHERE (((tempStockItem.tempStockItemID) Is Null) AND ((StockItem.StockItemID)=" & gStockItem & "));")
		cnnDB.Execute("DELETE FROM systemStockItemPricing;")
		cnnDB.Execute("INSERT INTO systemStockItemPricing ( systemStockItemPricing ) VALUES (" & gStockItem & ")")
		
		'cnnDB.Execute "INSERT INTO Catalogue (Catalogue_StockItemID,Catalogue_Quantity,Catalogue_Barcode) VALUES (" & gStockItem & ",1,'" & buildItemBarcode(gStockItem, 1) & "')"
		cnnDB.Execute("INSERT INTO Catalogue (Catalogue_StockItemID,Catalogue_Quantity,Catalogue_Barcode) VALUES (" & gStockItem & ",1,'" & rsCostPrice.Fields("Catalogue_Barcode").Value & Format(Today, "ddmmyy") & "')")
		
		'Override
		rsSellPrice = getRS("SELECT PriceChannelLnk.PriceChannelLnk_Price, PriceChannelLnk.PriceChannelLnk_StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID From PriceChannelLnk WHERE (((PriceChannelLnk.PriceChannelLnk_StockItemID)=" & sID & ") AND ((PriceChannelLnk.PriceChannelLnk_Quantity)=1) AND ((PriceChannelLnk.PriceChannelLnk_ChannelID)=1));")
		cnnDB.Execute("INSERT INTO PriceChannelLnk ( PriceChannelLnk_StockItemID, PriceChannelLnk_Quantity, PriceChannelLnk_ChannelID, PriceChannelLnk_Price ) VALUES (" & gStockItem & "," & 1 & ",1," & rsSellPrice.Fields("PriceChannelLnk_Price").Value & ")")
		cnnDB.Execute("UPDATE PriceChannelLnk SET PriceChannelLnk_Price=" & rsSellPrice.Fields("PriceChannelLnk_Price").Value & " WHERE PriceChannelLnk_StockItemID = " & gStockItem & ";")
		newATItem = True
        Dim form As frmUpdateCatalogue
        form.Show()
		
		Exit Sub
cErrorHndlr: 
		'MsgBox Err.Description
		Resume Next
		
	End Sub
	
	Private Sub cmdNextFnV_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNextFnV.Click
        Dim x As Short
		
		Dim rsGrvOrig As ADODB.Recordset
		Dim rsGrvBOM As ADODB.Recordset
		Dim rsGrvStockDesc As ADODB.Recordset
		Dim getNewID As Integer
		Dim getNewIDBOM As Integer
		If MsgBox("You are about to commit this 'Goods Receiving Voucher' into Stock." & vbCrLf & "Are you sure you wish to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Commit GRV") = MsgBoxResult.Yes Then
			
			'create master item copy
			
			cmdNextFnV.Visible = False
			cmdExit.Visible = False
			cmdBack.Visible = False
			
			rsGrvOrig = getRS("SELECT GRVItem.GRVItem_StockItemID, GRVItem_QuantityOrder, GRVItem.GRVItem_Quantity FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE GRVItem_GRVID = " & Val(frmGRV.adoPrimaryRS.Fields("GRVID").Value) & ";")
			If rsGrvOrig.RecordCount Then ReDim arrMainItems(rsGrvOrig.RecordCount - 1)
			x = 0
			Do Until rsGrvOrig.EOF
				
				getNewID = 0
				'FGRecipe.Tag = 0
				'create new main
				CreateVegItems(rsGrvOrig.Fields("GRVItem_StockItemID").Value, getNewID)
				cnnDB.Execute("UPDATE GRVItem SET GRVItem.GRVItem_StockItemID = " & getNewID & " WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_StockItemID)=" & rsGrvOrig.Fields("GRVItem_StockItemID").Value & "));")
				
				rsGrvStockDesc = getRS("SELECT StockItem.StockItem_Name From StockItem WHERE (((StockItem.StockItemID)=" & getNewID & "));")
				cnnDB.Execute("UPDATE GRVItem SET GRVItem.GRVItem_Name = '" & rsGrvStockDesc.Fields("StockItem_Name").Value & "' WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_StockItemID)=" & getNewID & "));")
				
				arrMainItems(x) = getNewID
				'create BOM item copy
				rsGrvBOM = getRS("SELECT RecipeStockitemLnk.RecipeStockitemLnk_RecipeID, RecipeStockitemLnk.RecipeStockitemLnk_StockitemID, RecipeStockitemLnk.RecipeStockitemLnk_Quantity From RecipeStockitemLnk WHERE (((RecipeStockitemLnk.RecipeStockitemLnk_RecipeID)=" & rsGrvOrig.Fields("GRVItem_StockItemID").Value & "));")
				If rsGrvBOM.RecordCount Then
					Do Until rsGrvBOM.EOF
						'create new bom
						getNewIDBOM = 0
						CreateVegItems(rsGrvBOM.Fields("RecipeStockitemLnk_StockitemID").Value, getNewIDBOM)
						
						cnnDB.Execute("INSERT INTO RecipeStockitemLnk ( RecipeStockitemLnk_RecipeID, RecipeStockitemLnk_StockitemID, RecipeStockitemLnk_Quantity ) VALUES (" & getNewID & "," & getNewIDBOM & "," & rsGrvBOM.Fields("RecipeStockitemLnk_Quantity").Value & ")")
						
						rsGrvBOM.moveNext()
					Loop 
				End If
				x = x + 1
				rsGrvOrig.moveNext()
			Loop 
			
			bLoading = True
			Frame1(6).Visible = True
			With FGRecipe
				.Visible = True
                .RowCount = 1
                .ColumnCount = 5
				.Col = 0
				.row = 0
				.Text = "Product"
				.set_ColAlignment(0, 1)
				.set_ColWidth(0, 4000)
				.CellFontBold = True
				.Col = 1
				.Text = "Master QTY"
				.set_ColAlignment(1, 7)
				.set_ColWidth(1, 1400)
				.CellFontBold = True
				.Col = 2
				.Text = "New Quantity"
				.set_ColAlignment(2, 7)
				.set_ColWidth(2, 1400)
				.CellFontBold = True
				.Col = 3
				.Text = "Cost"
				.set_ColAlignment(3, 7)
				.set_ColWidth(3, 1000)
				.CellFontBold = True
				.Col = 4
				.Text = "Price"
				.set_ColAlignment(4, 7)
				.set_ColWidth(4, 1000)
				.CellFontBold = True
				'.Visible = Not Me._optRecipeType_0.value
			End With
			FGRecipe.Visible = True
			bLoading = False
			
			If arrMainItems(0) <> 0 Then
				rsGrvOrig = getRS("SELECT StockItem.StockItem_Name From StockItem WHERE (((StockItem.StockItemID)=" & arrMainItems(0) & "));")
				Label5.Text = rsGrvOrig.Fields("StockItem_Name").Value
				FGRecipe.Tag = arrMainItems(0)
				loadRecipe(arrMainItems(0))
			End If
		End If
		
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Dim rsGrvOrig As ADODB.Recordset
		
		If CShort(Text1.Text) <= 0 Then
			Text1.Text = CStr(0)
			MsgBox("First Record")
		Else
			Text1.Text = CStr(CShort(Text1.Text) - 1)
			
			rsGrvOrig = getRS("SELECT StockItem.StockItem_Name From StockItem WHERE (((StockItem.StockItemID)=" & arrMainItems(0) & "));")
			Label5.Text = rsGrvOrig.Fields("StockItem_Name").Value
			FGRecipe.Tag = arrMainItems(CShort(Text1.Text))
			loadRecipe(arrMainItems(CShort(Text1.Text)))
		End If
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		Dim rsGrvOrig As ADODB.Recordset
		
		If CShort(Text1.Text) >= UBound(arrMainItems) Then
			'Text1.Text = 0
			MsgBox("Last Record")
		Else
			Text1.Text = CStr(CShort(Text1.Text) + 1)
			
			rsGrvOrig = getRS("SELECT StockItem.StockItem_Name From StockItem WHERE (((StockItem.StockItemID)=" & arrMainItems(0) & "));")
			Label5.Text = rsGrvOrig.Fields("StockItem_Name").Value
			FGRecipe.Tag = arrMainItems(CShort(Text1.Text))
			loadRecipe(arrMainItems(CShort(Text1.Text)))
		End If
	End Sub
	
    Private Sub FGRecipe_EnterCell(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If bLoading = True Then Exit Sub
        Dim lString As String
        With FGRecipe
            If .Visible Then
                If .Col = 2 Or .Col = 3 Or .Col = 4 Then
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
                End If
            Else
                txtQuantity.Visible = False
            End If

        End With

    End Sub
	
    Private Sub FGRecipe_LeaveCell(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim x As Short
        Dim lAmount As Double
        '    On Local Error Resume Next
        If txtQuantity.Visible Then
            If txtQuantity.Text = "" Then txtQuantity.Text = "0"
            FGRecipe.Text = FormatNumber(txtQuantity.Text, 4)

            If CDec(txtQuantity.Text) <> CDec(txtQuantity.Tag) Then
                If CDec(txtQuantity.Text) = 0 Then
                    txtQuantity.Visible = False
                    'cnnDB.Execute "DELETE RecipeStockitemLnk.* From RecipeStockitemLnk WHERE RecipeStockitemLnk_RecipeID=" & CInt(FGRecipe.Tag) & " AND RecipeStockitemLnk_StockitemID=" & FGRecipe.RowData(FGRecipe.row) & ";"
                    loadRecipe(CShort(FGRecipe.Tag))
                Else
                    If FGRecipe.Col = 2 Then
                        cnnDB.Execute("UPDATE RecipeStockitemLnk SET RecipeStockitemLnk_Quantity = " & CDec(txtQuantity.Text) & " WHERE RecipeStockitemLnk_RecipeID=" & CShort(FGRecipe.Tag) & " AND RecipeStockitemLnk_StockitemID=" & FGRecipe.get_RowData(FGRecipe.row) & ";")
                    End If

                    If FGRecipe.Col = 3 Then
                        cnnDB.Execute("UPDATE StockItem SET StockItem_ListCost = " & CDec(txtQuantity.Text) & ", StockItem_ActualCost = " & CDec(txtQuantity.Text) & " WHERE StockItemID=" & FGRecipe.get_RowData(FGRecipe.row) & ";")
                    End If

                    If FGRecipe.Col = 4 Then
                        cnnDB.Execute("UPDATE PriceChannelLnk SET PriceChannelLnk_Price=" & CDec(txtQuantity.Text) & " WHERE PriceChannelLnk_StockItemID = " & FGRecipe.get_RowData(FGRecipe.row) & ";")
                    End If

                    'FGRecipe.TextMatrix(FGRecipe.row, FGRecipe.Col) = FormatNumber(CCur(FGRecipe.TextMatrix(FGRecipe.row, 1)) * CCur(FGRecipe.TextMatrix(FGRecipe.row, 2)), 2)
                    'lAmount = 0
                    'For x = 1 To FGRecipe.RowCount - 1
                    '   lAmount = lAmount + CDbl(FGRecipe.TextMatrix(x, 3))
                    'Next x
                    'Me.lblRecipeCost.Caption = FormatNumber(lAmount, 2)
                End If
            End If
        End If

    End Sub
	
	Private Sub loadRecipe(ByRef mainID As Integer)
		Dim rs As ADODB.Recordset
		Dim x As Integer
		Dim lAmount As Double
		'    Set rs = getRS("SELECT ProductReceipt.ProductReceipt_ProductChildID, ProductReceipt.ProductReceipt_Quantity, Product.Product_Name, [Product_CostLast]/[Product_SupplierQuantity] AS cost FROM ProductReceipt INNER JOIN Product ON ProductReceipt.ProductReceipt_ProductChildID = Product.ProductID WHERE (((ProductReceipt.ProductReceipt_ProductID)=" & gID & ") AND ((Product.Product_Discontinued)=False)) ORDER BY Product.Product_Name;")
		'Set rs = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_Name, RecipeStockitemLnk.RecipeStockitemLnk_Quantity, [StockItem_ListCost]/[StockItem_Quantity] AS cost FROM RecipeStockitemLnk INNER JOIN StockItem ON RecipeStockitemLnk.RecipeStockitemLnk_StockitemID = StockItem.StockItemID Where (((RecipeStockitemLnk.RecipeStockitemLnk_RecipeID) = " & mainID & ") And ((StockItem.StockItem_Discontinued) = False)) ORDER BY StockItem.StockItem_Name;")
		rs = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_Name, RecipeStockitemLnk.RecipeStockitemLnk_Quantity, [StockItem_ListCost]/[StockItem_Quantity] AS cost, PriceChannelLnk.PriceChannelLnk_Price FROM (RecipeStockitemLnk INNER JOIN StockItem ON RecipeStockitemLnk.RecipeStockitemLnk_StockitemID = StockItem.StockItemID) INNER JOIN PriceChannelLnk ON StockItem.StockItemID = PriceChannelLnk.PriceChannelLnk_StockItemID Where (((RecipeStockitemLnk.RecipeStockitemLnk_RecipeID) = " & mainID & ") And ((StockItem.StockItem_Discontinued) = False) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = 1) And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1)) ORDER BY StockItem.StockItem_Name;")
		
		With FGRecipe
            .RowCount = rs.RecordCount + 1
			x = 1
			Do Until rs.EOF
				.set_TextMatrix(x, 0, rs.Fields("StockItem_Name").Value)
				.set_TextMatrix(x, 1, FormatNumber(rs.Fields("RecipeStockitemLnk_Quantity").Value, 4))
				.set_TextMatrix(x, 2, FormatNumber(rs.Fields("RecipeStockitemLnk_Quantity").Value, 4))
				.set_TextMatrix(x, 3, FormatNumber(rs.Fields("Cost").Value, 2))
				.set_TextMatrix(x, 4, FormatNumber(rs.Fields("PriceChannelLnk_Price").Value, 4))
				'.TextMatrix(x, 3) = FormatNumber(CCur(.TextMatrix(x, 1)) * CCur(.TextMatrix(x, 2)), 2)
				.set_RowData(x, rs.Fields("StockItemID").Value)
				'lAmount = lAmount + CDbl(FGRecipe.TextMatrix(x, 1))
				lAmount = lAmount + CDbl(FGRecipe.get_TextMatrix(x, 3))
				
				x = x + 1
				rs.moveNext()
			Loop 
			lblRecipeCost.Text = FormatNumber(lAmount, 2)
			
		End With
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
	
	Private Sub cmdNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNext.Click
        Dim GRVInvoiceNumber As Integer
        Dim PurchaseOrderSupplierID As Integer
        Dim xx As Integer
		Dim gID As Short
		Dim sql As String
		Dim ltype As String
		Dim iSer As Boolean
		Dim rs As ADODB.Recordset
		Dim rsC As ADODB.Recordset
		Dim rk As ADODB.Recordset
		Dim rj As ADODB.Recordset
		Dim rsPri As ADODB.Recordset
		Dim rBit As ADODB.Recordset
		Dim gParameter As Integer
		Const gActualAndList_U As Short = 2048
		Const gLeaveListAct_U As Short = 8192
		Dim fso As New Scripting.FileSystemObject
		
		
		rBit = getRS("SELECT Company_DayEndBit FROM Company")
		gParameter = CInt(0 & rBit.Fields("Company_DayEndBit").Value)
		
		grvPrin = False
		'If MsgBox("You are about to commit this 'Goods Receiving Voucher' into Stock." & vbCrLf & "Are you sure you wish to continue?", vbQuestion + vbYesNo + vbDefaultButton2, "Commit GRV") = vbYes Then
		iSer = False
		intCurr = 0
		
		'update TotalQtyKG
		'cnnDB.Execute "UPDATE (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN PackSize ON StockItem.StockItem_PackSizeID = PackSize.PackSizeID SET GRVItem_QuantityTotalKG = PackSize_Volume*GRVItem_Quantity, GRVItem_QuantityUsedKG=0, GRVItem_PackSizeVol=PackSize.PackSize_Volume WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & "));"
		cnnDB.Execute("UPDATE (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN PackSize ON StockItem.StockItem_PackSizeID = PackSize.PackSizeID SET GRVItem_QuantityTotalKG = IIf(GRVItem_PackSizeVol=0,PackSize.PackSize_Volume,GRVItem_PackSizeVol)*GRVItem_Quantity, GRVItem_QuantityUsedKG=0, GRVItem_PackSizeVol=IIf(GRVItem_PackSizeVol=0,PackSize.PackSize_Volume,GRVItem_PackSizeVol) WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & "));")
		
		'update the GRV processer person id
		cnnDB.Execute("UPDATE GRV SET GRV.GRV_PersonID = " & frmMenu.lblUser.Tag & " WHERE (((GRV.GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & "));")
		
		'Check for person security to not show Order QTY
		Dim QtyChkOver As Boolean
		Dim rsQtyOver As ADODB.Recordset
		Dim lMgrID As Integer
		
		lMgrID = 0
		If 8192 And frmMenu.gBit Then
		Else
			QtyChkOver = False
			rsQtyOver = getRS("SELECT GRVItem.GRVItem_StockItemID, GRVItem_QuantityOrder, GRVItem.GRVItem_Quantity FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE GRVItem_GRVID = " & Val(frmGRV.adoPrimaryRS.Fields("GRVID").Value) & ";")
			Do Until rsQtyOver.EOF
				If rsQtyOver.Fields("GRVItem_Quantity").Value > 0 Then
					If rsQtyOver.Fields("GRVItem_Quantity").Value <> rsQtyOver.Fields("GRVItem_QuantityOrder").Value Then
						QtyChkOver = True
					End If
				End If
				rsQtyOver.moveNext()
			Loop 
			If QtyChkOver Then
				MsgBox("GRV Qty for some items is not same as Actual Ordered Qty. Call Your Supervisor for Override?", MsgBoxStyle.Question + MsgBoxStyle.ApplicationModal + MsgBoxStyle.DefaultButton1, My.Application.Info.Title)
				If frmOverride.sOverride(lMgrID) Then
					'update the GRV processer person id
					cnnDB.Execute("UPDATE GRV SET GRV.GRV_OverridePersonID = " & lMgrID & " WHERE (((GRV.GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & "));")
				Else
					Exit Sub
				End If
				
			End If
		End If
		'Check for person security to not show Order QTY
		
		'Do you want.......
		Gr_ID = Val(frmGRV.adoPrimaryRS.Fields("GRVID").Value)
		Gr_ID = frmGRV.adoPrimaryRS.Fields("GRVID").Value
		sql = "SELECT * FROM GRVItem WHERE GRVItem_Return = 0 AND GRVItem_GRVID = " & Val(frmGRV.adoPrimaryRS.Fields("GRVID").Value)
		
		For xx = 0 To 100
			tempStockItem(xx) = ""
			intArrayName(xx) = ""
			intArraySCode(xx) = 0
		Next 
		
		'New sql
		sql = "SELECT StockItem.StockItem_SerialTracker, GRVItem.* FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE (((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_GRVID)= " & Val(frmGRV.adoPrimaryRS.Fields("GRVID").Value) & "));"
		rs_St = getRS(sql)
		rs_St.filter = "StockItem_SerialTracker = 1"
		If rs_St.RecordCount Then
			iSer = True
		End If
		If iSer = True Then
			Grv_Unload = False
			frmSerialNumber.ShowDialog()
		End If
		
		Dim rsPur As ADODB.Recordset
		Dim rsQty As ADODB.Recordset
		Dim cQty As Decimal
		Dim QtyChk As Boolean
		Dim rsID As ADODB.Recordset
		Dim rsSTransGRV As ADODB.Recordset
		Dim x As Short
		Dim rsChk As ADODB.Recordset
		If Grv_Unload = True Then
			saveDetails()
			Me.Close()
		Else
			
			
			saveDetails()
			cnnDB.BeginTrans()
			
			SaveIntoTable() 'Save serial number's into tables
			
			
            cnnDB.Execute("UPDATE GRV, Company SET GRV.GRV_ContentExclusive = " & CDec(lblContentExclusiveIn.Text) & ", GRV.GRV_DayEndID = [Company]![Company_DayEndID], GRV.GRV_GRVStatusID = 3, GRV.GRV_Date = Now(), GRV.GRV_InvoiceInclusive = " & CDec(Me.lblTotal.Text) & ", GRV_InvoiceVat = " & CDec(CDec(Me.lblOutBoundVat.Text) - CDec(Me.lblInBoundVat.Text)) & ", GRV.GRV_InvoiceDiscount = " & CDec(Me.lblDiscount.Text) & ", GRV.GRV_Ullage = " & CDec(Me.txtUllage.Text) & ", GRV.GRV_SundriesPlus = " & CDec(Me.txtPlus.Text) & ", GRV.GRV_SundriesMinus = " & CDec(0 - CDec(Me.txtMinus.Text)) & ", GRV.GRV_Terms = " & CInt(cmbPayment.SelectedIndex) & " WHERE (((GRV.GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & "));")
			cnnDB.Execute("UPDATE Warehouse INNER JOIN (GRVItem INNER JOIN WarehouseStockItemLnk ON GRVItem.GRVItem_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID SET GRVItem.GRVItem_WarehouseQuantity = [GRVItem]![GRVItem_WarehouseQuantity]+[WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((Warehouse.Warehouse_Saleable)<>0));")
			cnnDB.Execute("UPDATE (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID SET GRVItem.GRVItem_DepositCost = [Deposit_UnitCost]*[GRVItem_PackSize] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & "));")
			cnnDB.Execute("UPDATE (GRVItem INNER JOIN StockItem ON (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize) AND (GRVItem.GRVItem_StockItemID = StockItem.StockItemID)) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID SET GRVItem.GRVItem_DepositCost = [GRVItem_DepositCost]+[Deposit_CaseCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & "));")
			'cnnDB.Execute "UPDATE Vat INNER JOIN (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) ON Vat.VatID = StockItem.StockItem_VatID SET GRVItem.GRVItem_VatRate = [Vat]![Vat_Amount] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & "));"
			cnnDB.Execute("UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET GRVItem.GRVItem_OldActualCost = [StockItem]![StockItem_ActualCost], GRVItem.GRVItem_StockItemQuantity = [StockItem]![StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & "));")
			
			'Do Actual Cost
			cnnDB.Execute("UPDATE GRVItem SET GRVItem.GRVItem_ActualCost = [GRVItem_ContentCost]-[GRVItem_DiscountAmount] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & "));")
			cnnDB.Execute("UPDATE GRV INNER JOIN GRVItem ON GRV.GRVID = GRVItem.GRVItem_GRVID SET GRVItem.GRVItem_ActualCost = ([GRVItem_ActualCost]+([GRVItem_ActualCost]*(([GRV_InvoiceDiscount]+[GRV_Ullage]+[GRV_SundriesPlus]+[GRV_SundriesMinus])/([GRV_ContentExclusive]+0.0001)))) WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=0));")
			
			'sql = "INSERT INTO PriceChannelLnk (PriceChannelLnk_StockItemID, PriceChannelLnk_Quantity, PriceChannelLnk_ChannelID, PriceChannelLnk_Price) VALUES (" & gStockItemID & ", " & frmItem(x).Tag & ", " & gChannelID & ", " & Replace(txtPrice(x).Text, ",", "") & ")"
			'cnnDB.Execute "UPDATE PriceChannelLnk INNER JOIN GRVItem ON (PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID) AND (GRVItem.GRVItem_StockItemQuantity = PriceChannelLnk.PriceChannelLnk_Quantity) SET PriceChannelLnk.PriceChannelLnk_Price = ([GRVItem_Price]) WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0));"
			'cnnDB.Execute "UPDATE PriceChannelLnk INNER JOIN GRVItem ON ((PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID) AND (PriceChannelLnk.PriceChannelLnk_Quantity=1) AND (PriceChannelLnk.PriceChannelLnk_ChannelID=1)) SET PriceChannelLnk.PriceChannelLnk_Price = ([GRVItem_Price]) WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0));"
			cnnDB.Execute("UPDATE PriceChannelLnk INNER JOIN GRVItem ON ((PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID)) SET PriceChannelLnk.PriceChannelLnk_Price = ([GRVItem_Price]) WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=0) AND ((PriceChannelLnk.PriceChannelLnk_Quantity)=1)  AND ((PriceChannelLnk.PriceChannelLnk_ChannelID)=1));")
			
			'to check for Actual cost
			rsC = getRS("SELECT Company_GRVCost FROM Company;")
			If rsC.Fields("Company_GRVCost").Value = True Then
				
				
				'If gParameter And gActualAndList_U = 2048 Then
				'    'Actual Update...
				'    cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = (((([StockItem_ActualCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
				'    cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
				'
				'    'cnnDB.Execute "UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_ContentCost = (GRVItem.GRVItem_ContentCost * StockItem.StockItem_Quantity) Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS("GRVID") & ") And (GRVItem_Return=0)"
				'    'cnnDB.Execute "UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_ContentCost = (GRVItem.GRVItem_ContentCost * GRVItem.GRVItem_Quantity) Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS("GRVID") & ") And (GRVItem_Return=0)"
				'    'List Update...
				'    cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ListCost = (((([StockItem_ListCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
				'    cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ListCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
				'
				' commented due to changes option
				'Else
				'
				'    cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = (((([StockItem_ActualCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
				'    cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
				'End If
				'cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = (((([StockItem_ActualCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
				'cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
				
				'to check for Actual cost >>> cnnDB.Execute "UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_WarehouseQuantity)<=0) AND ((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((StockItem.StockItem_ActualCostChange)<>True));"
				
			Else
				
				
				'If gParameter And gActualAndList_U = 2048 Then
				If System.Math.Abs(CInt(CBool(rBit.Fields("Company_DayEndBit").Value And gActualAndList_U))) Then
					'Actual Update...
					cnnDB.Execute("UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = (((([StockItem_ActualCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));")
					cnnDB.Execute("UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));")
					
					'cnnDB.Execute "UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_ContentCost = (GRVItem.GRVItem_ContentCost * StockItem.StockItem_Quantity) Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS("GRVID") & ") And (GRVItem_Return=0)"
					'cnnDB.Execute "UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_ContentCost = (GRVItem.GRVItem_ContentCost * GRVItem.GRVItem_Quantity) Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS("GRVID") & ") And (GRVItem_Return=0)"
					'List Update...
					cnnDB.Execute("UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ListCost = (((([StockItem_ListCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));")
					cnnDB.Execute("UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ListCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));")
					
				Else
					'commened for wronge calculation and changed to LIST COST in below line cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = (((([StockItem_ActualCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
					cnnDB.Execute("UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = (((([StockItem_ActualCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));")
					cnnDB.Execute("UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));")
				End If
				'cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = (((([StockItem_ActualCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
				'cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
				
				'commenting due to Wronge formula of sundries
				cnnDB.Execute("UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_WarehouseQuantity)<=0) AND ((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((StockItem.StockItem_ActualCostChange)<>True));")
				
				
			End If
			'end of to check for Actual cost
			
			'Warehouse StockItem
			cnnDB.Execute("UPDATE GRVItem INNER JOIN WarehouseStockItemLnk ON GRVItem.GRVItem_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk_Quantity]+[GRVItem_PackSize]*[GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));")
			cnnDB.Execute("UPDATE GRVItem INNER JOIN WarehouseStockItemLnk ON GRVItem.GRVItem_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk_Quantity]-[GRVItem_PackSize]*[GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=1) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));")
			
			cnnDB.Execute("UPDATE PurchaseOrderItem INNER JOIN (GRV INNER JOIN GRVItem ON GRV.GRVID = GRVItem.GRVItem_GRVID) ON (PurchaseOrderItem.PurchaseOrderItem_StockItemID = GRVItem.GRVItem_StockItemID) AND (PurchaseOrderItem.PurchaseOrderItem_PurchaseOrderID = GRV.GRV_PurchaseOrderID) SET PurchaseOrderItem.PurchaseOrderItem_QuantityDelivered = [GRVItem_Quantity]*[GRVItem_PackSize]+[PurchaseOrderItem_QuantityDelivered] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=0));")
			
			'cnnDB.Execute "UPDATE (Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN GRVItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = GRVItem.GRVItem_StockItemID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV = [DayEndStockItemLnk_QuantityGRV]+[GRVItem_PackSize]*[GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0));"
			'cnnDB.Execute "UPDATE (Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN GRVItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = GRVItem.GRVItem_StockItemID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV = [DayEndStockItemLnk_QuantityGRV]-[GRVItem_PackSize]*[GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=1));"
			
			'Stock item Deposits
			cnnDB.Execute("UPDATE ((Deposit INNER JOIN WarehouseDepositItemLnk ON Deposit.DepositID = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID) INNER JOIN StockItem ON Deposit.DepositID = StockItem.StockItem_DepositID) INNER JOIN GRVItem ON (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize) AND (StockItem.StockItemID = GRVItem.GRVItem_StockItemID) SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_Quantity]+[GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=0) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=1) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2));")
			cnnDB.Execute("UPDATE ((Deposit INNER JOIN WarehouseDepositItemLnk ON Deposit.DepositID = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID) INNER JOIN StockItem ON Deposit.DepositID = StockItem.StockItem_DepositID) INNER JOIN GRVItem ON (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize) AND (StockItem.StockItemID = GRVItem.GRVItem_StockItemID) SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_Quantity]-[GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=1) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=1) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2));")
			
			'cnnDB.Execute "UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN ((Deposit INNER JOIN StockItem ON Deposit.DepositID = StockItem.StockItem_DepositID) INNER JOIN GRVItem ON (StockItem.StockItemID = GRVItem.GRVItem_StockItemID) AND (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize)) ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = Deposit.DepositID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]+[GRVItem]![GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=1));"
			'cnnDB.Execute "UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN ((Deposit INNER JOIN StockItem ON Deposit.DepositID = StockItem.StockItem_DepositID) INNER JOIN GRVItem ON (StockItem.StockItemID = GRVItem.GRVItem_StockItemID) AND (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize)) ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = Deposit.DepositID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]-[GRVItem]![GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)<>0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=1));"
			
			'deposits
			cnnDB.Execute("UPDATE Vat INNER JOIN (SupplierDepositLnk INNER JOIN ((PurchaseOrder INNER JOIN GRV ON PurchaseOrder.PurchaseOrderID = GRV.GRV_PurchaseOrderID) INNER JOIN (Deposit INNER JOIN GRVDeposit ON Deposit.DepositID = GRVDeposit.GRVDeposit_DepositID) ON GRV.GRVID = GRVDeposit.GRVDeposit_GRVID) ON (SupplierDepositLnk.SupplierDepositLnk_Type = GRVDeposit.GRVDeposit_Type) AND (SupplierDepositLnk.SupplierDepositLnk_DepositID = Deposit.DepositID) AND (SupplierDepositLnk.SupplierDepositLnk_SupplierID = PurchaseOrder.PurchaseOrder_SupplierID)) ON Vat.VatID = Deposit.Deposit_VatID SET GRVDeposit.GRVDeposit_Name = [SupplierDepositLnk]![SupplierDepositLnk_Name], GRVDeposit.GRVDeposit_UnitCost = [Deposit]![Deposit_UnitCost], GRVDeposit.GRVDeposit_CaseCost = [Deposit]![Deposit_CaseCost], GRVDeposit.GRVDeposit_CaseQuantity = [Deposit]![Deposit_Quantity], GRVDeposit.GRVDeposit_VatRate = [Vat]![Vat_Amount] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & "));")
			
			'units
			cnnDB.Execute("UPDATE WarehouseDepositItemLnk INNER JOIN GRVDeposit ON WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_Quantity]-[GRVDeposit_Quantity]*[GRVDeposit_CaseQuantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=0) AND ((GRVDeposit.GRVDeposit_Type)=1 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=0));")
			cnnDB.Execute("UPDATE WarehouseDepositItemLnk INNER JOIN GRVDeposit ON WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_Quantity]+[GRVDeposit_Quantity]*[GRVDeposit_CaseQuantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=0) AND ((GRVDeposit.GRVDeposit_Type)=1 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=1));")
			
			'cnnDB.Execute "UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN GRVDeposit ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]-[GRVDeposit_Quantity]*[GRVDeposit_CaseQuantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVDeposit.GRVDeposit_Type)=1 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=0));"
			'cnnDB.Execute "UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN GRVDeposit ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]+[GRVDeposit_Quantity]*[GRVDeposit_CaseQuantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVDeposit.GRVDeposit_Type)=1 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)<>0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=0));"
			
			'cnnDB.Execute "UPDATE WarehouseDepositItemLnk INNER JOIN GRVDeposit ON WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_DepositTypeID]-[GRVDeposit_Quantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=1) AND ((GRVDeposit.GRVDeposit_Type)=2 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=0));"
			'cnnDB.Execute "UPDATE WarehouseDepositItemLnk INNER JOIN GRVDeposit ON WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_DepositTypeID]+[GRVDeposit_Quantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=1) AND ((GRVDeposit.GRVDeposit_Type)=2 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=1));"
			'FIXED: was not updating Case QTY correct
			cnnDB.Execute("UPDATE WarehouseDepositItemLnk INNER JOIN GRVDeposit ON WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_Quantity]-[GRVDeposit_Quantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=1) AND ((GRVDeposit.GRVDeposit_Type)=2 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=0));")
			cnnDB.Execute("UPDATE WarehouseDepositItemLnk INNER JOIN GRVDeposit ON WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_Quantity]+[GRVDeposit_Quantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=1) AND ((GRVDeposit.GRVDeposit_Type)=2 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=1));")
			
			'cnnDB.Execute "UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN GRVDeposit ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]-[GRVDeposit_Quantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVDeposit.GRVDeposit_Type)=2 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=1));"
			'cnnDB.Execute "UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN GRVDeposit ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]+[GRVDeposit_Quantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVDeposit.GRVDeposit_Type)=2 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)<>0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=1));"
			
			
			If Me.optClose(0).Checked Then
				cnnDB.Execute("UPDATE GRV INNER JOIN PurchaseOrder ON GRV.GRV_PurchaseOrderID = PurchaseOrder.PurchaseOrderID SET PurchaseOrder.PurchaseOrder_PurchaseOrderStatusID = 3 WHERE (((GRV.GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & "));")
			End If
			cnnDB.Execute("INSERT INTO SupplierTransaction ( SupplierTransaction_SupplierID, SupplierTransaction_TransactionTypeID, SupplierTransaction_MonthEndID, SupplierTransaction_MonthEndIDFor, SupplierTransaction_DayEndID, SupplierTransaction_ReferenceID, SupplierTransaction_Date, SupplierTransaction_Description, SupplierTransaction_Amount, SupplierTransaction_Reference ) SELECT PurchaseOrder.PurchaseOrder_SupplierID, 2 AS transType, DayEnd.DayEnd_MonthEndID, DayEnd.DayEnd_MonthEndID, GRV.GRV_DayEndID, GRV.GRVID, GRV.GRV_InvoiceDate, '' AS [Desc], GRV.GRV_InvoiceInclusive, GRV.GRV_InvoiceNumber FROM DayEnd INNER JOIN (PurchaseOrder INNER JOIN GRV ON PurchaseOrder.PurchaseOrderID = GRV.GRV_PurchaseOrderID) ON DayEnd.DayEndID = GRV.GRV_DayEndID Where (((GRV.GRVID) = " & frmGRV.adoPrimaryRS.Fields("GRVID").Value & "));")
			cnnDB.Execute("UPDATE GRV INNER JOIN (Supplier INNER JOIN PurchaseOrder ON Supplier.SupplierID = PurchaseOrder.PurchaseOrder_SupplierID) ON GRV.GRV_PurchaseOrderID = PurchaseOrder.PurchaseOrderID SET Supplier.Supplier_Current = [Supplier]![Supplier_Current]+[GRV]![GRV_InvoiceInclusive] WHERE (((GRV.GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & "));")
			
			'to check for Actual cost
			rsC = getRS("SELECT Company_GRVCost FROM Company;")
			If rsC.Fields("Company_GRVCost").Value = True Then
				cnnDB.Execute("UPDATE Company, GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET StockItem.StockItem_LastCost = [Company_DayEndID], StockItem.StockItem_ActualCost = [GRVItem_ContentCost] WHERE (((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_ContentCost)<>[StockItem_ListCost]) AND ((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & "));")
			Else
				'If gParameter And gLeaveListAct_U = 8192 Then
				If System.Math.Abs(CInt(CBool(rBit.Fields("Company_DayEndBit").Value And gLeaveListAct_U))) Then
				Else
					cnnDB.Execute("UPDATE Company, GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET StockItem.StockItem_LastCost = [Company_DayEndID], StockItem.StockItem_ListCost = [GRVItem_ContentCost] WHERE (((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_ContentCost)<>[StockItem_ListCost]) AND ((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & "));")
				End If
			End If
			
			cnnDB.Execute("INSERT INTO systemStockItemPricing ( systemStockItemPricing ) SELECT PriceChannelLnk.PriceChannelLnk_StockItemID FROM systemStockItemPricing RIGHT JOIN (PriceChannelLnk INNER JOIN GRVItem ON (PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID) AND (PriceChannelLnk.PriceChannelLnk_Quantity = GRVItem.GRVItem_PackSize)) ON systemStockItemPricing.systemStockItemPricing = PriceChannelLnk.PriceChannelLnk_StockItemID WHERE (((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((PriceChannelLnk.PriceChannelLnk_ChannelID)=1) AND ((systemStockItemPricing.systemStockItemPricing) Is Null) AND ((PriceChannelLnk.PriceChannelLnk_Price)<>[GRVItem_Price]));")
			'cnnDB.Execute "UPDATE PriceChannelLnk INNER JOIN GRVItem ON (PriceChannelLnk.PriceChannelLnk_Quantity = GRVItem.GRVItem_PackSize) AND (PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID) SET PriceChannelLnk.PriceChannelLnk_Price = [GRVItem_Price] WHERE (((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((PriceChannelLnk.PriceChannelLnk_ChannelID)=1) AND ((PriceChannelLnk.PriceChannelLnk_Price)<>[GRVItem_Price]));"
			
			FlushMemoryArrays() 'Reset arrays
			intCurr = 0
			
			
			cnnDB.CommitTrans()
			
			doDiskFlush()
			
			report_GRV(frmGRV.adoPrimaryRS.Fields("GRVID").Value)
			
			'check for Order QTY
			
			cnnDB.Execute("DELETE * from StockTransferGRV;")
			QtyChk = False
			rsQty = getRS("SELECT GRVItem.GRVItem_StockItemID, GRVItem_QuantityOrder, GRVItem.GRVItem_Quantity FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE GRVItem_GRVID = " & Val(frmGRV.adoPrimaryRS.Fields("GRVID").Value) & ";")
			Do Until rsQty.EOF
				If rsQty.Fields("GRVItem_Quantity").Value > 0 Then
					If rsQty.Fields("GRVItem_Quantity").Value < rsQty.Fields("GRVItem_QuantityOrder").Value Then
						cQty = rsQty.Fields("GRVItem_QuantityOrder").Value - rsQty.Fields("GRVItem_Quantity").Value
						cnnDB.Execute("INSERT INTO StockTransferGRV ( StockTransfer_StockItemID, StockTransfer_Quantity, StockTransfer_Price ) SELECT " & rsQty.Fields("GRVItem_StockItemID").Value & ", " & cQty & ", " & 0)
						QtyChk = True
					End If
				End If
				rsQty.moveNext()
			Loop 
			
			If QtyChk = True Then
				
				PurchaseOrderSupplierID = 2
				GRVInvoiceNumber = "BackOrder"
				rsPur = getRS("SELECT PurchaseOrder.PurchaseOrder_SupplierID, GRV.GRV_InvoiceNumber, GRV.GRVID FROM PurchaseOrder INNER JOIN GRV ON PurchaseOrder.PurchaseOrderID = GRV.GRV_PurchaseOrderID WHERE (((GRV.GRVID)=" & Val(frmGRV.adoPrimaryRS.Fields("GRVID").Value) & "));")
				If rsPur.RecordCount Then
					PurchaseOrderSupplierID = rsPur.Fields("PurchaseOrder_SupplierID").Value
					GRVInvoiceNumber = rsPur.Fields("GRV_InvoiceNumber").Value
				End If
				
				If MsgBox("GRV Qty for some items is less then Actual Ordered Qty. Do you want to log an Order for balance Qty?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.ApplicationModal + MsgBoxStyle.DefaultButton1, My.Application.Info.Title) = MsgBoxResult.Yes Then
					sql = "INSERT INTO PurchaseOrder ( PurchaseOrder_SupplierID, PurchaseOrder_DayEndID, PurchaseOrder_PersonID, PurchaseOrder_DateCreated, PurchaseOrder_PurchaseOrderStatusID, PurchaseOrder_Reference, PurchaseOrder_AttentionLine ) "
					sql = sql & "SELECT " & PurchaseOrderSupplierID & ", Company.Company_DayEndID, " & gPersonID & ", Now(), 1, '" & Format(Now, "yyyy mmm dd") & " (Balance Order)', '' FROM Company;"
					cnnDB.Execute(sql,  , ADODB.ExecuteOptionEnum.adExecuteNoRecords)
					
					rsID = getRS("SELECT Max(PurchaseOrder.PurchaseOrderID) AS id FROM PurchaseOrder;")
					sql = "INSERT INTO GRV ( GRV_PurchaseOrderID, GRV_DayEndID, GRV_GRVStatusID, GRV_Date, GRV_InvoiceDate, GRV_InvoiceNumber, GRV_InvoiceInclusive, GRV_InvoiceVat, GRV_InvoiceDiscount, GRV_Ullage, GRV_SundriesPlus, GRV_SundriesMinus, GRV_Terms ) SELECT " & rsID.Fields("id").Value & ", Company.Company_DayEndID, 1 AS status, Now(), Now(), '" & (GRVInvoiceNumber & "_" & rsID.Fields("id").Value) & "', 0, 0, 0, 0, 0, 0, 1 FROM Company;"
					cnnDB.Execute(sql,  , ADODB.ExecuteOptionEnum.adExecuteNoRecords)
					If rsID.State Then rsID.Close()
					rsID = getRS("SELECT Max(GRV.GRVID) AS id FROM GRV;")
					
					x = 1
					'Set rsSTransGRV = getRS("SELECT StockItem.StockItem_Name, StockTransferGRV.* FROM StockTransferGRV INNER JOIN StockItem ON StockTransferGRV.StockTransfer_StockItemID = StockItem.StockItemID ORDER BY StockItem.StockItem_Name, StockTransferGRV.StockTransfer_Quantity;")
					rsSTransGRV = getRS("SELECT StockItem.StockItem_Name, StockTransferGRV.*, GRVItem.GRVItem_PackSize FROM (StockTransferGRV INNER JOIN StockItem ON StockTransferGRV.StockTransfer_StockItemID = StockItem.StockItemID) INNER JOIN GRVItem ON StockTransferGRV.StockTransfer_StockItemID = GRVItem.GRVItem_StockItemID Where (((GRVItem.GRVItem_GRVID) = " & Val(frmGRV.adoPrimaryRS.Fields("GRVID").Value) & ")) ORDER BY StockItem.StockItem_Name, StockTransferGRV.StockTransfer_Quantity;")
					Do Until rsSTransGRV.EOF
						
						rsChk = getRS("SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & rsSTransGRV.Fields("StockTransfer_StockItemID").Value & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
						If rsChk.RecordCount Then
							sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID.Fields("id").Value & " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, " & rsSTransGRV.Fields("GRVItem_PackSize").Value & " AS PackSize, " & rsSTransGRV.Fields("StockTransfer_Quantity").Value & " AS QuantityOrder, " & rsSTransGRV.Fields("StockTransfer_Quantity").Value & " AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
							sql = sql & " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & rsSTransGRV.Fields("StockTransfer_StockItemID").Value & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));"
							cnnDB.Execute(sql)
						Else
							sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID.Fields("id").Value & " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, " & rsSTransGRV.Fields("GRVItem_PackSize").Value & " AS PackSize, " & rsSTransGRV.Fields("StockTransfer_Quantity").Value & " AS QuantityOrder, " & rsSTransGRV.Fields("StockTransfer_Quantity").Value & " AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
							sql = sql & " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & rsSTransGRV.Fields("StockTransfer_StockItemID").Value & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));"
							cnnDB.Execute(sql)
						End If
						
						x = x + 1
						rsSTransGRV.moveNext()
					Loop 
				End If
			End If
			
			'run time error removal of type mismatch
			'Set rsPri = getRS("SELECT GRVItem.GRVItem_StockItemID, GRVItem.GRVItem_Quantity, StockItem.StockItem_SBarcode FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE GRVItem_GRVID = " & Val(frmGRV.adoPrimaryRS("GRVID")) & " AND (StockItem_SBarcode = 'shelf' Or StockItem_SBarcode = 'barcode')")
			'Set rsPri = getRS("SELECT GRVItem.GRVItem_StockItemID, GRVItem.GRVItem_Quantity, StockItem.StockItem_SBarcode FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE GRVItem_GRVID = " & Val(frmGRV.adoPrimaryRS("GRVID")) & " AND (StockItem_SBarcode = True Or StockItem_SShelf = True)")
			rsPri = getRS("SELECT GRVItem.GRVItem_StockItemID, (GRVItem.GRVItem_Quantity*GRVItem_PackSize) AS GRVItem_Quantity, StockItem.StockItem_SBarcode,StockItem.StockItem_SShelf FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE GRVItem_GRVID = " & Val(frmGRV.adoPrimaryRS.Fields("GRVID").Value) & " AND (StockItem_SBarcode = True Or StockItem_SShelf = True)")
			'Write file
			If rsPri.RecordCount Then
				If fso.FileExists(serverPath & "ShelfBarcode.dat") Then fso.DeleteFile(serverPath & "ShelfBarcode.dat", True)
				rsPri.save(serverPath & "ShelfBarcode.dat", ADODB.PersistFormatEnum.adPersistADTG)
				grvPrin = True
				If MsgBox("Do you want to do Shelf/Barcode Printing on flagged StockItems?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.ApplicationModal + MsgBoxStyle.DefaultButton1, My.Application.Info.Title) = MsgBoxResult.Yes Then
					
					'For Auto UpdatePOS on MonthEnd
					'If MsgBox("You are requested to do UpdatePOS at this stage, to run some Reports." & vbCrLf & vbCrLf & "NOTE: If you have changed Prices for some items, UpdatePOS will update Terminals." & vbCrLf & vbCrLf & "If you want to Run UpdatePOS now select 'YES' or click 'NO' If you don't want to change the prices on terminals.", vbYesNo) = vbYes Then
					blMEndUpdatePOS = True
					frmUpdatePOScriteria.ShowDialog()
					'Else
					'    blMEndUpdatePOS = False
					'End If
					blMEndUpdatePOS = False
					
					frmBarcode.ShowDialog()
				End If
			End If
			cmdExit_Click(cmdExit, New System.EventArgs())
		End If
		'End If
	End Sub
	
	Private Sub cmdNext_Click_Auto()
        Dim GRVInvoiceNumber As Integer
        Dim PurchaseOrderSupplierID As Integer
		Dim gID As Short
		Dim sql As String
		Dim ltype As String
		Dim iSer As Boolean
		Dim rs As ADODB.Recordset
		Dim rsC As ADODB.Recordset
		Dim rk As ADODB.Recordset
		Dim rj As ADODB.Recordset
		Dim rsPri As ADODB.Recordset
		Dim rBit As ADODB.Recordset
		Dim gParameter As Integer
		Const gActualAndList_U As Short = 2048
		Const gLeaveListAct_U As Short = 8192
		Dim fso As New Scripting.FileSystemObject
		
		
		rBit = getRS("SELECT Company_DayEndBit FROM Company")
		gParameter = CInt(0 & rBit.Fields("Company_DayEndBit").Value)
		
		grvPrin = False
		'If MsgBox("You are about to commit this 'Goods Receiving Voucher' into Stock." & vbCrLf & "Are you sure you wish to continue?", vbQuestion + vbYesNo + vbDefaultButton2, "Commit GRV") = vbYes Then
		iSer = False
		intCurr = 0
		
		'Do you want.......
		Gr_ID = Val(frmGRV.adoPrimaryRS.Fields("GRVID").Value)
		Gr_ID = frmGRV.adoPrimaryRS.Fields("GRVID").Value
		sql = "SELECT * FROM GRVItem WHERE GRVItem_Return = 0 AND GRVItem_GRVID = " & Val(frmGRV.adoPrimaryRS.Fields("GRVID").Value)
		
		'New sql
		sql = "SELECT StockItem.StockItem_SerialTracker, GRVItem.* FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE (((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_GRVID)= " & Val(frmGRV.adoPrimaryRS.Fields("GRVID").Value) & "));"
		rs_St = getRS(sql)
		rs_St.filter = "StockItem_SerialTracker = 1"
		'      If rs_St.RecordCount Then
		'         iSer = True
		'      End If
		'      If iSer = True Then
		Grv_Unload = False
		'         frmSerialNumber.show 1
		'      End If
		cnnDB.Execute("UPDATE SerialTracking SET Serial_GRV_ID = " & Gr_ID & ", Serial_Status = 'Received' WHERE Serial_Status = 'GRV_START';")
		Dim rsPur As ADODB.Recordset
		Dim rsQty As ADODB.Recordset
		Dim cQty As Decimal
		Dim QtyChk As Boolean
		Dim rsID As ADODB.Recordset
		Dim rsSTransGRV As ADODB.Recordset
		Dim x As Short
		Dim rsChk As ADODB.Recordset
		If Grv_Unload = True Then
			saveDetails()
			Me.Close()
		Else
			
			
			saveDetails()
			cnnDB.BeginTrans()
			
			SaveIntoTable() 'Save serial number's into tables
			
			
            cnnDB.Execute("UPDATE GRV, Company SET GRV.GRV_ContentExclusive = " & CDec(lblContentExclusiveIn.Text) & ", GRV.GRV_DayEndID = [Company]![Company_DayEndID], GRV.GRV_GRVStatusID = 3, GRV.GRV_Date = Now(), GRV.GRV_InvoiceInclusive = " & CDec(Me.lblTotal.Text) & ", GRV_InvoiceVat = " & CDec(CDec(Me.lblOutBoundVat.Text) - CDec(Me.lblInBoundVat.Text)) & ", GRV.GRV_InvoiceDiscount = " & CDec(Me.lblDiscount.Text) & ", GRV.GRV_Ullage = " & CDec(Me.txtUllage.Text) & ", GRV.GRV_SundriesPlus = " & CDec(Me.txtPlus.Text) & ", GRV.GRV_SundriesMinus = " & CDec(0 - CDec(Me.txtMinus.Text)) & ", GRV.GRV_Terms = " & CInt(cmbPayment.SelectedIndex) & " WHERE (((GRV.GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & "));")
			cnnDB.Execute("UPDATE Warehouse INNER JOIN (GRVItem INNER JOIN WarehouseStockItemLnk ON GRVItem.GRVItem_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID SET GRVItem.GRVItem_WarehouseQuantity = [GRVItem]![GRVItem_WarehouseQuantity]+[WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((Warehouse.Warehouse_Saleable)<>0));")
			cnnDB.Execute("UPDATE (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID SET GRVItem.GRVItem_DepositCost = [Deposit_UnitCost]*[GRVItem_PackSize] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & "));")
			cnnDB.Execute("UPDATE (GRVItem INNER JOIN StockItem ON (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize) AND (GRVItem.GRVItem_StockItemID = StockItem.StockItemID)) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID SET GRVItem.GRVItem_DepositCost = [GRVItem_DepositCost]+[Deposit_CaseCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & "));")
			'cnnDB.Execute "UPDATE Vat INNER JOIN (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) ON Vat.VatID = StockItem.StockItem_VatID SET GRVItem.GRVItem_VatRate = [Vat]![Vat_Amount] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & "));"
			cnnDB.Execute("UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET GRVItem.GRVItem_OldActualCost = [StockItem]![StockItem_ActualCost], GRVItem.GRVItem_StockItemQuantity = [StockItem]![StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & "));")
			
			'Do Actual Cost
			cnnDB.Execute("UPDATE GRVItem SET GRVItem.GRVItem_ActualCost = [GRVItem_ContentCost]-[GRVItem_DiscountAmount] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & "));")
			cnnDB.Execute("UPDATE GRV INNER JOIN GRVItem ON GRV.GRVID = GRVItem.GRVItem_GRVID SET GRVItem.GRVItem_ActualCost = ([GRVItem_ActualCost]+([GRVItem_ActualCost]*(([GRV_InvoiceDiscount]+[GRV_Ullage]+[GRV_SundriesPlus]+[GRV_SundriesMinus])/([GRV_ContentExclusive]+0.0001)))) WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=0));")
			
			'sql = "INSERT INTO PriceChannelLnk (PriceChannelLnk_StockItemID, PriceChannelLnk_Quantity, PriceChannelLnk_ChannelID, PriceChannelLnk_Price) VALUES (" & gStockItemID & ", " & frmItem(x).Tag & ", " & gChannelID & ", " & Replace(txtPrice(x).Text, ",", "") & ")"
			'cnnDB.Execute "UPDATE PriceChannelLnk INNER JOIN GRVItem ON (PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID) AND (GRVItem.GRVItem_StockItemQuantity = PriceChannelLnk.PriceChannelLnk_Quantity) SET PriceChannelLnk.PriceChannelLnk_Price = ([GRVItem_Price]) WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0));"
			'cnnDB.Execute "UPDATE PriceChannelLnk INNER JOIN GRVItem ON ((PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID) AND (PriceChannelLnk.PriceChannelLnk_Quantity=1) AND (PriceChannelLnk.PriceChannelLnk_ChannelID=1)) SET PriceChannelLnk.PriceChannelLnk_Price = ([GRVItem_Price]) WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0));"
			cnnDB.Execute("UPDATE PriceChannelLnk INNER JOIN GRVItem ON ((PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID)) SET PriceChannelLnk.PriceChannelLnk_Price = ([GRVItem_Price]) WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=0) AND ((PriceChannelLnk.PriceChannelLnk_Quantity)=1)  AND ((PriceChannelLnk.PriceChannelLnk_ChannelID)=1));")
			
			'to check for Actual cost
			rsC = getRS("SELECT Company_GRVCost FROM Company;")
			If rsC.Fields("Company_GRVCost").Value = True Then
				
				
				'If gParameter And gActualAndList_U = 2048 Then
				'    'Actual Update...
				'    cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = (((([StockItem_ActualCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
				'    cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
				'
				'    'cnnDB.Execute "UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_ContentCost = (GRVItem.GRVItem_ContentCost * StockItem.StockItem_Quantity) Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS("GRVID") & ") And (GRVItem_Return=0)"
				'    'cnnDB.Execute "UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_ContentCost = (GRVItem.GRVItem_ContentCost * GRVItem.GRVItem_Quantity) Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS("GRVID") & ") And (GRVItem_Return=0)"
				'    'List Update...
				'    cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ListCost = (((([StockItem_ListCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
				'    cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ListCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
				'
				' commented due to changes option
				'Else
				'
				'    cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = (((([StockItem_ActualCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
				'    cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
				'End If
				'cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = (((([StockItem_ActualCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
				'cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
				
				'to check for Actual cost >>> cnnDB.Execute "UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_WarehouseQuantity)<=0) AND ((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((StockItem.StockItem_ActualCostChange)<>True));"
				
			Else
				
				
				'If gParameter And gActualAndList_U = 2048 Then
				If System.Math.Abs(CInt(CBool(rBit.Fields("Company_DayEndBit").Value And gActualAndList_U))) Then
					'Actual Update...
					cnnDB.Execute("UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = (((([StockItem_ActualCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));")
					cnnDB.Execute("UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));")
					
					'cnnDB.Execute "UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_ContentCost = (GRVItem.GRVItem_ContentCost * StockItem.StockItem_Quantity) Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS("GRVID") & ") And (GRVItem_Return=0)"
					'cnnDB.Execute "UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_ContentCost = (GRVItem.GRVItem_ContentCost * GRVItem.GRVItem_Quantity) Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS("GRVID") & ") And (GRVItem_Return=0)"
					'List Update...
					cnnDB.Execute("UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ListCost = (((([StockItem_ListCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));")
					cnnDB.Execute("UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ListCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));")
					
				Else
					'commened for wronge calculation and changed to LIST COST in below line cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = (((([StockItem_ActualCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
					cnnDB.Execute("UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = (((([StockItem_ActualCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));")
					cnnDB.Execute("UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));")
				End If
				'cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = (((([StockItem_ActualCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
				'cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
				
				'commenting due to Wronge formula of sundries
				cnnDB.Execute("UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_WarehouseQuantity)<=0) AND ((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((StockItem.StockItem_ActualCostChange)<>True));")
				
				
			End If
			'end of to check for Actual cost
			
			'Warehouse StockItem
			cnnDB.Execute("UPDATE GRVItem INNER JOIN WarehouseStockItemLnk ON GRVItem.GRVItem_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk_Quantity]+[GRVItem_PackSize]*[GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));")
			cnnDB.Execute("UPDATE GRVItem INNER JOIN WarehouseStockItemLnk ON GRVItem.GRVItem_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk_Quantity]-[GRVItem_PackSize]*[GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=1) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));")
			
			cnnDB.Execute("UPDATE PurchaseOrderItem INNER JOIN (GRV INNER JOIN GRVItem ON GRV.GRVID = GRVItem.GRVItem_GRVID) ON (PurchaseOrderItem.PurchaseOrderItem_StockItemID = GRVItem.GRVItem_StockItemID) AND (PurchaseOrderItem.PurchaseOrderItem_PurchaseOrderID = GRV.GRV_PurchaseOrderID) SET PurchaseOrderItem.PurchaseOrderItem_QuantityDelivered = [GRVItem_Quantity]*[GRVItem_PackSize]+[PurchaseOrderItem_QuantityDelivered] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=0));")
			
			'cnnDB.Execute "UPDATE (Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN GRVItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = GRVItem.GRVItem_StockItemID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV = [DayEndStockItemLnk_QuantityGRV]+[GRVItem_PackSize]*[GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0));"
			'cnnDB.Execute "UPDATE (Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN GRVItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = GRVItem.GRVItem_StockItemID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV = [DayEndStockItemLnk_QuantityGRV]-[GRVItem_PackSize]*[GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=1));"
			
			'Stock item Deposits
			cnnDB.Execute("UPDATE ((Deposit INNER JOIN WarehouseDepositItemLnk ON Deposit.DepositID = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID) INNER JOIN StockItem ON Deposit.DepositID = StockItem.StockItem_DepositID) INNER JOIN GRVItem ON (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize) AND (StockItem.StockItemID = GRVItem.GRVItem_StockItemID) SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_Quantity]+[GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=0) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=1) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2));")
			cnnDB.Execute("UPDATE ((Deposit INNER JOIN WarehouseDepositItemLnk ON Deposit.DepositID = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID) INNER JOIN StockItem ON Deposit.DepositID = StockItem.StockItem_DepositID) INNER JOIN GRVItem ON (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize) AND (StockItem.StockItemID = GRVItem.GRVItem_StockItemID) SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_Quantity]-[GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=1) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=1) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2));")
			
			'cnnDB.Execute "UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN ((Deposit INNER JOIN StockItem ON Deposit.DepositID = StockItem.StockItem_DepositID) INNER JOIN GRVItem ON (StockItem.StockItemID = GRVItem.GRVItem_StockItemID) AND (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize)) ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = Deposit.DepositID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]+[GRVItem]![GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=1));"
			'cnnDB.Execute "UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN ((Deposit INNER JOIN StockItem ON Deposit.DepositID = StockItem.StockItem_DepositID) INNER JOIN GRVItem ON (StockItem.StockItemID = GRVItem.GRVItem_StockItemID) AND (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize)) ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = Deposit.DepositID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]-[GRVItem]![GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)<>0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=1));"
			
			'deposits
			cnnDB.Execute("UPDATE Vat INNER JOIN (SupplierDepositLnk INNER JOIN ((PurchaseOrder INNER JOIN GRV ON PurchaseOrder.PurchaseOrderID = GRV.GRV_PurchaseOrderID) INNER JOIN (Deposit INNER JOIN GRVDeposit ON Deposit.DepositID = GRVDeposit.GRVDeposit_DepositID) ON GRV.GRVID = GRVDeposit.GRVDeposit_GRVID) ON (SupplierDepositLnk.SupplierDepositLnk_Type = GRVDeposit.GRVDeposit_Type) AND (SupplierDepositLnk.SupplierDepositLnk_DepositID = Deposit.DepositID) AND (SupplierDepositLnk.SupplierDepositLnk_SupplierID = PurchaseOrder.PurchaseOrder_SupplierID)) ON Vat.VatID = Deposit.Deposit_VatID SET GRVDeposit.GRVDeposit_Name = [SupplierDepositLnk]![SupplierDepositLnk_Name], GRVDeposit.GRVDeposit_UnitCost = [Deposit]![Deposit_UnitCost], GRVDeposit.GRVDeposit_CaseCost = [Deposit]![Deposit_CaseCost], GRVDeposit.GRVDeposit_CaseQuantity = [Deposit]![Deposit_Quantity], GRVDeposit.GRVDeposit_VatRate = [Vat]![Vat_Amount] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & "));")
			
			'units
			cnnDB.Execute("UPDATE WarehouseDepositItemLnk INNER JOIN GRVDeposit ON WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_Quantity]-[GRVDeposit_Quantity]*[GRVDeposit_CaseQuantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=0) AND ((GRVDeposit.GRVDeposit_Type)=1 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=0));")
			cnnDB.Execute("UPDATE WarehouseDepositItemLnk INNER JOIN GRVDeposit ON WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_Quantity]+[GRVDeposit_Quantity]*[GRVDeposit_CaseQuantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=0) AND ((GRVDeposit.GRVDeposit_Type)=1 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=1));")
			
			'cnnDB.Execute "UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN GRVDeposit ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]-[GRVDeposit_Quantity]*[GRVDeposit_CaseQuantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVDeposit.GRVDeposit_Type)=1 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=0));"
			'cnnDB.Execute "UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN GRVDeposit ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]+[GRVDeposit_Quantity]*[GRVDeposit_CaseQuantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVDeposit.GRVDeposit_Type)=1 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)<>0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=0));"
			
			'cnnDB.Execute "UPDATE WarehouseDepositItemLnk INNER JOIN GRVDeposit ON WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_DepositTypeID]-[GRVDeposit_Quantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=1) AND ((GRVDeposit.GRVDeposit_Type)=2 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=0));"
			'cnnDB.Execute "UPDATE WarehouseDepositItemLnk INNER JOIN GRVDeposit ON WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_DepositTypeID]+[GRVDeposit_Quantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=1) AND ((GRVDeposit.GRVDeposit_Type)=2 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=1));"
			'FIXED: was not updating Case QTY correct
			cnnDB.Execute("UPDATE WarehouseDepositItemLnk INNER JOIN GRVDeposit ON WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_Quantity]-[GRVDeposit_Quantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=1) AND ((GRVDeposit.GRVDeposit_Type)=2 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=0));")
			cnnDB.Execute("UPDATE WarehouseDepositItemLnk INNER JOIN GRVDeposit ON WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_Quantity]+[GRVDeposit_Quantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=1) AND ((GRVDeposit.GRVDeposit_Type)=2 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=1));")
			
			'cnnDB.Execute "UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN GRVDeposit ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]-[GRVDeposit_Quantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVDeposit.GRVDeposit_Type)=2 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=1));"
			'cnnDB.Execute "UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN GRVDeposit ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]+[GRVDeposit_Quantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVDeposit.GRVDeposit_Type)=2 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)<>0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=1));"
			
			
			If Me.optClose(0).Checked Then
				cnnDB.Execute("UPDATE GRV INNER JOIN PurchaseOrder ON GRV.GRV_PurchaseOrderID = PurchaseOrder.PurchaseOrderID SET PurchaseOrder.PurchaseOrder_PurchaseOrderStatusID = 3 WHERE (((GRV.GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & "));")
			End If
			cnnDB.Execute("INSERT INTO SupplierTransaction ( SupplierTransaction_SupplierID, SupplierTransaction_TransactionTypeID, SupplierTransaction_MonthEndID, SupplierTransaction_MonthEndIDFor, SupplierTransaction_DayEndID, SupplierTransaction_ReferenceID, SupplierTransaction_Date, SupplierTransaction_Description, SupplierTransaction_Amount, SupplierTransaction_Reference ) SELECT PurchaseOrder.PurchaseOrder_SupplierID, 2 AS transType, DayEnd.DayEnd_MonthEndID, DayEnd.DayEnd_MonthEndID, GRV.GRV_DayEndID, GRV.GRVID, GRV.GRV_InvoiceDate, '' AS [Desc], GRV.GRV_InvoiceInclusive, GRV.GRV_InvoiceNumber FROM DayEnd INNER JOIN (PurchaseOrder INNER JOIN GRV ON PurchaseOrder.PurchaseOrderID = GRV.GRV_PurchaseOrderID) ON DayEnd.DayEndID = GRV.GRV_DayEndID Where (((GRV.GRVID) = " & frmGRV.adoPrimaryRS.Fields("GRVID").Value & "));")
			cnnDB.Execute("UPDATE GRV INNER JOIN (Supplier INNER JOIN PurchaseOrder ON Supplier.SupplierID = PurchaseOrder.PurchaseOrder_SupplierID) ON GRV.GRV_PurchaseOrderID = PurchaseOrder.PurchaseOrderID SET Supplier.Supplier_Current = [Supplier]![Supplier_Current]+[GRV]![GRV_InvoiceInclusive] WHERE (((GRV.GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & "));")
			
			'to check for Actual cost
			rsC = getRS("SELECT Company_GRVCost FROM Company;")
			If rsC.Fields("Company_GRVCost").Value = True Then
				cnnDB.Execute("UPDATE Company, GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET StockItem.StockItem_LastCost = [Company_DayEndID], StockItem.StockItem_ActualCost = [GRVItem_ContentCost] WHERE (((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_ContentCost)<>[StockItem_ListCost]) AND ((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & "));")
			Else
				'If gParameter And gLeaveListAct_U = 8192 Then
				If System.Math.Abs(CInt(CBool(rBit.Fields("Company_DayEndBit").Value And gLeaveListAct_U))) Then
				Else
					cnnDB.Execute("UPDATE Company, GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET StockItem.StockItem_LastCost = [Company_DayEndID], StockItem.StockItem_ListCost = [GRVItem_ContentCost] WHERE (((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_ContentCost)<>[StockItem_ListCost]) AND ((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & "));")
				End If
			End If
			
			cnnDB.Execute("INSERT INTO systemStockItemPricing ( systemStockItemPricing ) SELECT PriceChannelLnk.PriceChannelLnk_StockItemID FROM systemStockItemPricing RIGHT JOIN (PriceChannelLnk INNER JOIN GRVItem ON (PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID) AND (PriceChannelLnk.PriceChannelLnk_Quantity = GRVItem.GRVItem_PackSize)) ON systemStockItemPricing.systemStockItemPricing = PriceChannelLnk.PriceChannelLnk_StockItemID WHERE (((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((PriceChannelLnk.PriceChannelLnk_ChannelID)=1) AND ((systemStockItemPricing.systemStockItemPricing) Is Null) AND ((PriceChannelLnk.PriceChannelLnk_Price)<>[GRVItem_Price]));")
			'cnnDB.Execute "UPDATE PriceChannelLnk INNER JOIN GRVItem ON (PriceChannelLnk.PriceChannelLnk_Quantity = GRVItem.GRVItem_PackSize) AND (PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID) SET PriceChannelLnk.PriceChannelLnk_Price = [GRVItem_Price] WHERE (((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((PriceChannelLnk.PriceChannelLnk_ChannelID)=1) AND ((PriceChannelLnk.PriceChannelLnk_Price)<>[GRVItem_Price]));"
			
			FlushMemoryArrays() 'Reset arrays
			intCurr = 0
			
			
			cnnDB.CommitTrans()
			
			doDiskFlush()
			
			report_GRV(frmGRV.adoPrimaryRS.Fields("GRVID").Value)
			
			'check for Order QTY
			
			cnnDB.Execute("DELETE * from StockTransferGRV;")
			QtyChk = False
			rsQty = getRS("SELECT GRVItem.GRVItem_StockItemID, GRVItem_QuantityOrder, GRVItem.GRVItem_Quantity FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE GRVItem_GRVID = " & Val(frmGRV.adoPrimaryRS.Fields("GRVID").Value) & ";")
			Do Until rsQty.EOF
				If rsQty.Fields("GRVItem_Quantity").Value > 0 Then
					If rsQty.Fields("GRVItem_Quantity").Value < rsQty.Fields("GRVItem_QuantityOrder").Value Then
						cQty = rsQty.Fields("GRVItem_QuantityOrder").Value - rsQty.Fields("GRVItem_Quantity").Value
						cnnDB.Execute("INSERT INTO StockTransferGRV ( StockTransfer_StockItemID, StockTransfer_Quantity, StockTransfer_Price ) SELECT " & rsQty.Fields("GRVItem_StockItemID").Value & ", " & cQty & ", " & 0)
						QtyChk = True
					End If
				End If
				rsQty.moveNext()
			Loop 
			
			If QtyChk = True Then
				
				PurchaseOrderSupplierID = 2
				GRVInvoiceNumber = "BackOrder"
				rsPur = getRS("SELECT PurchaseOrder.PurchaseOrder_SupplierID, GRV.GRV_InvoiceNumber, GRV.GRVID FROM PurchaseOrder INNER JOIN GRV ON PurchaseOrder.PurchaseOrderID = GRV.GRV_PurchaseOrderID WHERE (((GRV.GRVID)=" & Val(frmGRV.adoPrimaryRS.Fields("GRVID").Value) & "));")
				If rsPur.RecordCount Then
					PurchaseOrderSupplierID = rsPur.Fields("PurchaseOrder_SupplierID").Value
					GRVInvoiceNumber = rsPur.Fields("GRV_InvoiceNumber").Value
				End If
				
				If MsgBox("GRV Qty for some items is less then Actual Ordered Qty. Do you want to log an Order for balance Qty?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.ApplicationModal + MsgBoxStyle.DefaultButton1, My.Application.Info.Title) = MsgBoxResult.Yes Then
					sql = "INSERT INTO PurchaseOrder ( PurchaseOrder_SupplierID, PurchaseOrder_DayEndID, PurchaseOrder_PersonID, PurchaseOrder_DateCreated, PurchaseOrder_PurchaseOrderStatusID, PurchaseOrder_Reference, PurchaseOrder_AttentionLine ) "
					sql = sql & "SELECT " & PurchaseOrderSupplierID & ", Company.Company_DayEndID, " & gPersonID & ", Now(), 1, '" & Format(Now, "yyyy mmm dd") & " (Balance Order)', '' FROM Company;"
					cnnDB.Execute(sql,  , ADODB.ExecuteOptionEnum.adExecuteNoRecords)
					
					rsID = getRS("SELECT Max(PurchaseOrder.PurchaseOrderID) AS id FROM PurchaseOrder;")
					sql = "INSERT INTO GRV ( GRV_PurchaseOrderID, GRV_DayEndID, GRV_GRVStatusID, GRV_Date, GRV_InvoiceDate, GRV_InvoiceNumber, GRV_InvoiceInclusive, GRV_InvoiceVat, GRV_InvoiceDiscount, GRV_Ullage, GRV_SundriesPlus, GRV_SundriesMinus, GRV_Terms ) SELECT " & rsID.Fields("id").Value & ", Company.Company_DayEndID, 1 AS status, Now(), Now(), '" & (GRVInvoiceNumber & "_" & rsID.Fields("id").Value) & "', 0, 0, 0, 0, 0, 0, 1 FROM Company;"
					cnnDB.Execute(sql,  , ADODB.ExecuteOptionEnum.adExecuteNoRecords)
					If rsID.State Then rsID.Close()
					rsID = getRS("SELECT Max(GRV.GRVID) AS id FROM GRV;")
					
					x = 1
					'Set rsSTransGRV = getRS("SELECT StockItem.StockItem_Name, StockTransferGRV.* FROM StockTransferGRV INNER JOIN StockItem ON StockTransferGRV.StockTransfer_StockItemID = StockItem.StockItemID ORDER BY StockItem.StockItem_Name, StockTransferGRV.StockTransfer_Quantity;")
					rsSTransGRV = getRS("SELECT StockItem.StockItem_Name, StockTransferGRV.*, GRVItem.GRVItem_PackSize FROM (StockTransferGRV INNER JOIN StockItem ON StockTransferGRV.StockTransfer_StockItemID = StockItem.StockItemID) INNER JOIN GRVItem ON StockTransferGRV.StockTransfer_StockItemID = GRVItem.GRVItem_StockItemID Where (((GRVItem.GRVItem_GRVID) = " & Val(frmGRV.adoPrimaryRS.Fields("GRVID").Value) & ")) ORDER BY StockItem.StockItem_Name, StockTransferGRV.StockTransfer_Quantity;")
					Do Until rsSTransGRV.EOF
						
						rsChk = getRS("SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & rsSTransGRV.Fields("StockTransfer_StockItemID").Value & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
						If rsChk.RecordCount Then
							sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID.Fields("id").Value & " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, " & rsSTransGRV.Fields("GRVItem_PackSize").Value & " AS PackSize, " & rsSTransGRV.Fields("StockTransfer_Quantity").Value & " AS QuantityOrder, " & rsSTransGRV.Fields("StockTransfer_Quantity").Value & " AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
							sql = sql & " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & rsSTransGRV.Fields("StockTransfer_StockItemID").Value & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));"
							cnnDB.Execute(sql)
						Else
							sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID.Fields("id").Value & " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, " & rsSTransGRV.Fields("GRVItem_PackSize").Value & " AS PackSize, " & rsSTransGRV.Fields("StockTransfer_Quantity").Value & " AS QuantityOrder, " & rsSTransGRV.Fields("StockTransfer_Quantity").Value & " AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
							sql = sql & " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & rsSTransGRV.Fields("StockTransfer_StockItemID").Value & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));"
							cnnDB.Execute(sql)
						End If
						
						x = x + 1
						rsSTransGRV.moveNext()
					Loop 
				End If
			End If
			
			'run time error removal of type mismatch
			'Set rsPri = getRS("SELECT GRVItem.GRVItem_StockItemID, GRVItem.GRVItem_Quantity, StockItem.StockItem_SBarcode FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE GRVItem_GRVID = " & Val(frmGRV.adoPrimaryRS("GRVID")) & " AND (StockItem_SBarcode = 'shelf' Or StockItem_SBarcode = 'barcode')")
			'Set rsPri = getRS("SELECT GRVItem.GRVItem_StockItemID, GRVItem.GRVItem_Quantity, StockItem.StockItem_SBarcode FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE GRVItem_GRVID = " & Val(frmGRV.adoPrimaryRS("GRVID")) & " AND (StockItem_SBarcode = True Or StockItem_SShelf = True)")
			rsPri = getRS("SELECT GRVItem.GRVItem_StockItemID, (GRVItem.GRVItem_Quantity*GRVItem_PackSize) AS GRVItem_Quantity, StockItem.StockItem_SBarcode,StockItem.StockItem_SShelf FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE GRVItem_GRVID = " & Val(frmGRV.adoPrimaryRS.Fields("GRVID").Value) & " AND (StockItem_SBarcode = True Or StockItem_SShelf = True)")
			'Write file
			If rsPri.RecordCount Then
				If fso.FileExists(serverPath & "ShelfBarcode.dat") Then fso.DeleteFile(serverPath & "ShelfBarcode.dat", True)
				rsPri.save(serverPath & "ShelfBarcode.dat", ADODB.PersistFormatEnum.adPersistADTG)
				grvPrin = True
				If MsgBox("Do you want to do Shelf/Barcode Printing on flagged StockItems?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.ApplicationModal + MsgBoxStyle.DefaultButton1, My.Application.Info.Title) = MsgBoxResult.Yes Then
					
					'For Auto UpdatePOS on MonthEnd
					'If MsgBox("You are requested to do UpdatePOS at this stage, to run some Reports." & vbCrLf & vbCrLf & "NOTE: If you have changed Prices for some items, UpdatePOS will update Terminals." & vbCrLf & vbCrLf & "If you want to Run UpdatePOS now select 'YES' or click 'NO' If you don't want to change the prices on terminals.", vbYesNo) = vbYes Then
					blMEndUpdatePOS = True
					frmUpdatePOScriteria.ShowDialog()
					'Else
					'    blMEndUpdatePOS = False
					'End If
					blMEndUpdatePOS = False
					
					frmBarcode.ShowDialog()
				End If
			End If
			cmdExit_Click(cmdExit, New System.EventArgs())
		End If
		'End If
	End Sub
	
	Private Sub doDiskFlush()
        Dim lTextstream As Scripting.TextStream
        Dim Key As String
		Dim fso As New Scripting.FileSystemObject
        Dim hkey As Integer
		Dim lRetVal As Integer
		Dim vValue As String
		Dim lPath As String
		Dim rs As ADODB.Recordset
		Dim GRVID, lCompanyID As Integer
		Dim lString As String
		Dim lKey As String
		Dim lCNT As Integer
		
		GRVID = frmGRV.adoPrimaryRS.Fields("GRVID").Value
		lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\4POS", 0, KEY_QUERY_VALUE, hkey)
		lRetVal = QueryValueEx(hkey, "master", vValue)
		RegCloseKey(hkey)
		
		
		If vValue = "" Then
			Exit Sub
		Else
			lPath = vValue
		End If
		
		
		rs = getRS("SELECT 'grv' AS type, Company.CompanyID, PurchaseOrder.PurchaseOrder_SupplierID, GRV.GRVID, GRV.GRV_DayEndID, GRV.GRV_GRVStatusID, GRV.GRV_Date, GRV.GRV_InvoiceNumber, GRV.GRV_InvoiceDate, GRV.GRV_InvoiceInclusive, GRV.GRV_InvoiceVat, GRV.GRV_InvoiceDiscount, GRV.GRV_Ullage, GRV.GRV_SundriesPlus, GRV.GRV_SundriesMinus, GRV.GRV_ContentExclusive, GRV.GRV_Terms, GRV.GRV_Notes FROM Company, GRV INNER JOIN PurchaseOrder ON GRV.GRV_PurchaseOrderID = PurchaseOrder.PurchaseOrderID WHERE (((GRV.GRVID)=" & GRVID & ") AND ((GRV.GRV_GRVStatusID)=3));")
		If rs.RecordCount Then
			Key = rs.Fields("CompanyID").Value & "_" & rs.Fields("PurchaseOrder_SupplierID").Value & "_"
			lCompanyID = rs.Fields("CompanyID").Value
			lString = getDelimeter(rs)
			rs = getRS("SELECT 'item' AS type, GRVItem.* From GRVItem WHERE (((GRVItem.GRVItem_GRVID)=" & GRVID & "));")
			If rs.RecordCount Then lString = lString & Chr(255) & getDelimeter(rs)
			
			rs = getRS("SELECT 'deposit' AS type, GRVDeposit.* From GRVDeposit WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & GRVID & "));")
			If rs.RecordCount Then lString = lString & Chr(255) & getDelimeter(rs)
			lCNT = 1
			Do While fso.FileExists(serverPath & Key & lCNT & ".grv")
				lCNT = lCNT + 1
			Loop 
			
            lTextstream = fso.OpenTextFile(serverPath & Key & lCNT & ".grv", Scripting.IOMode.ForWriting, True)
			lTextstream.Write(lString)
			lTextstream.Close()
		End If
	End Sub
	
	Private Function getDelimeter(ByRef rs As ADODB.Recordset) As String
        Dim lString1 As String
		Dim lString2 As String
		Dim lField As ADODB.Field
		lString1 = ""
		Do Until rs.EOF
			lString2 = ""
			For	Each lField In rs.Fields
				If IsDbNull(lField.Value) Then
					lString2 = lString2 & Chr(254) & Chr(253)
				Else
					Select Case lField.Type
						Case 7
							lString2 = lString2 & Chr(254) & Format(lField.value, "yyyy/MM/dd")
						Case 202
							lString2 = lString2 & Chr(254) & lField.value
						Case Else
							lString2 = lString2 & Chr(254) & lField.value
					End Select
				End If
			Next lField
			lString1 = lString1 & Chr(255) & Mid(lString2, 2)
			rs.moveNext()
		Loop 
		If lString1 = "" Then
			getDelimeter = ""
		Else
			getDelimeter = Mid(lString1, 2)
		End If
	End Function
	
	Private Sub saveDetails()
		Dim sql As String
		If Me.Visible Then
			'Me.cmdNext.SetFocus
			System.Windows.Forms.Application.DoEvents()
			sql = "UPDATE GRV SET GRV_SundriesPlus = " & CDec(Me.txtPlus.Text) & ", GRV_SundriesMinus = " & CDec(Me.txtMinus.Text) & ", GRV_Notes = '" & Replace(txtNotes.Text, "'", "''") & "' Where (GRVID = " & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ")"
			cnnDB.Execute(sql)
			
		End If
	End Sub
	Sub FlushMemoryArrays()
		Dim p As Short
		
		For p = 0 To 100
			intArrayName(p) = ""
			intArraySCode(p) = 0
			tempStockItem(p) = ""
		Next 
	End Sub
	
	Private Sub setTotals()
        Dim sql As String
		Dim lExclusive, lVat As Decimal
		Dim rs As ADODB.Recordset
		Dim oLabel As System.Windows.Forms.Label
		
		lblLinesIn.Text = CStr(0)
		lblVatRateIn.Text = "0.00"
		lblDiscountLineIn.Text = "0.00"
		lblLinesOut.Text = CStr(0)
		lblVatRateOut.Text = "0.00"
		lblDiscountLineOut.Text = "0.00"
		lblInclusiveOut.Text = "0.00"
		'    Set rs = getRS("SELECT Sum([GRVItem_PackSize]/[StockItem_Quantity]*[GRVItem_ContentCost]*[GRVItem_Quantity]-[GRVItem_DiscountAmount]*[GRVItem_Quantity]) AS exclusive, Sum([GRVItem_DiscountAmount]*[GRVItem_Quantity]) AS discount, Sum(([GRVItem_PackSize]/[StockItem_Quantity]*[GRVItem_ContentCost]*[GRVItem_Quantity]-[GRVItem_DiscountAmount]*[GRVItem_Quantity])*([Vat_Amount]/100)) AS vat, GRVItem.GRVItem_Return, Count(GRVItem.GRVItem_GRVID) AS itemCount FROM (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID Where (((GRVItem.GRVItem_GRVID) = " & frmGRV.adoPrimaryRS("GRVID") & ")) GROUP BY GRVItem.GRVItem_Return HAVING (((GRVItem.GRVItem_Return)=0));")
		rs = getRS("SELECT Sum([GRVItem_PackSize]/[StockItem_Quantity]*[GRVItem_ContentCost]*[GRVItem_Quantity]-[GRVItem_DiscountAmount]*[GRVItem_Quantity]) AS exclusive, Sum([GRVItem_DiscountAmount]*[GRVItem_Quantity]) AS discount, Sum(([GRVItem_PackSize]/[StockItem_Quantity]*[GRVItem_ContentCost]*[GRVItem_Quantity]-[GRVItem_DiscountAmount]*[GRVItem_Quantity])*([GRVItem_VatRate]/100)) AS vat, GRVItem.GRVItem_Return, Count(GRVItem.GRVItem_GRVID) AS itemCount FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID Where (((GRVItem.GRVItem_GRVID) = " & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ")) GROUP BY GRVItem.GRVItem_Return HAVING (((GRVItem.GRVItem_Return)=0));")
		If rs.BOF Or rs.EOF Then
		Else
			lVat = rs.Fields("vat").Value
			lblLinesIn.Text = rs.Fields("itemCount").Value
			lExclusive = rs.Fields("exclusive").Value
			If lExclusive Then
				lblVatRateIn.Text = FormatNumber(lVat / lExclusive * 100, 2)
			Else
				lblVatRateIn.Text = FormatNumber(0, 2)
			End If
			
			lblContentExclusiveIn.Text = FormatNumber(lExclusive, 2)
			Me.lblDiscountLineIn.Text = FormatNumber(rs.Fields("discount").Value, 2)
			Me.lblContentIn.Text = FormatNumber(CDec(lblContentExclusiveIn.Text) + CDec(lblDiscountLineIn.Text), 2)
		End If
		'    Set rs = getRS("SELECT Sum([GRVItem_PackSize]/[StockItem_Quantity]*[GRVItem_ContentCost]*[GRVItem_Quantity]-[GRVItem_DiscountAmount]*[GRVItem_Quantity]) AS exclusive, Sum([GRVItem_DiscountAmount]*[GRVItem_Quantity]) AS discount, Sum(([GRVItem_PackSize]/[StockItem_Quantity]*[GRVItem_ContentCost]*[GRVItem_Quantity]-[GRVItem_DiscountAmount]*[GRVItem_Quantity])*([Vat_Amount]/100)) AS vat, GRVItem.GRVItem_Return, Count(GRVItem.GRVItem_GRVID) AS itemCount FROM (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID Where (((GRVItem.GRVItem_GRVID) = " & frmGRV.adoPrimaryRS("GRVID") & ")) GROUP BY GRVItem.GRVItem_Return HAVING (((GRVItem.GRVItem_Return)=1));")
		rs = getRS("SELECT Sum([GRVItem_PackSize]/[StockItem_Quantity]*[GRVItem_ContentCost]*[GRVItem_Quantity]-[GRVItem_DiscountAmount]*[GRVItem_Quantity]) AS exclusive, Sum([GRVItem_DiscountAmount]*[GRVItem_Quantity]) AS discount, Sum(([GRVItem_PackSize]/[StockItem_Quantity]*[GRVItem_ContentCost]*[GRVItem_Quantity]-[GRVItem_DiscountAmount]*[GRVItem_Quantity])*([GRVItem_VatRate]/100)) AS vat, GRVItem.GRVItem_Return, Count(GRVItem.GRVItem_GRVID) AS itemCount FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID Where (((GRVItem.GRVItem_GRVID) = " & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ")) GROUP BY GRVItem.GRVItem_Return HAVING (((GRVItem.GRVItem_Return)=1));")
		If rs.BOF Or rs.EOF Then
		Else
			lVat = rs.Fields("vat").Value
			lblLinesIn.Text = rs.Fields("itemCount").Value
			lExclusive = rs.Fields("exclusive").Value
			If lExclusive Then
				lblVatRateOut.Text = FormatNumber(lVat / lExclusive * 100, 2)
			Else
				lblVatRateOut.Text = FormatNumber(0, 2)
			End If
			lblExclusiveOut.Text = FormatNumber(lExclusive, 2)
			lblDiscountLineOut.Text = FormatNumber(rs.Fields("discount").Value, 2)
			lblContentOut.Text = FormatNumber(CDec(lblExclusiveOut.Text) + CDec(lblDiscountLineOut.Text), 2)
			lblVATout.Text = FormatNumber(CDec(lblExclusiveOut.Text) * CDec(lblVatRateOut.Text) / 100, 2)
			lblInclusiveOut.Text = FormatNumber(CDec(lblExclusiveOut.Text) + CDec(lblVATout.Text), 2)
			
		End If
		Me.lblDepositIn.Text = "0.00"
		Me.lblDepositVatIn.Text = "0.00"
		Me.lblDepositVatRateIn.Text = "0.00"
		Me.lblDepositInclusiveIn.Text = "0.00"
		Me.lblDepositOut.Text = "0.00"
		Me.lblDepositVatOut.Text = "0.00"
		Me.lblDepositVatRateOut.Text = "0.00"
		Me.lblDepositInclusiveOut.Text = "0.00"
		
		sql = "SELECT GRVItem.GRVItem_Return, Sum(((Abs([StockItem_Quantity]=[GRVItem_PackSize])*[Deposit_CaseCost])+([Deposit_UnitCost]*[GRVItem_PackSize]))*[GRVItem_Quantity]) AS exclusive, Sum((((Abs([StockItem_Quantity]=[GRVItem_PackSize])*[Deposit_CaseCost])+([Deposit_UnitCost]*[GRVItem_PackSize]))*[GRVItem_Quantity])*([Vat_Amount]/100)) AS vat, Avg(Vat.Vat_Amount) AS AvgOfVat_Amount, Count(GRVItem.GRVItem_GRVID) AS CountOfGRVItem_GRVID FROM ((GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID Where (((Deposit.Deposit_UnitCost) <> 0) And ((GRVItem.GRVItem_GRVID) = " & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ")) Or (((Deposit.Deposit_CaseCost) <> 0) And ((GRVItem.GRVItem_GRVID) = " & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ")) GROUP BY GRVItem.GRVItem_Return HAVING (GRVItem.GRVItem_Return=0);"
		
		rs = getRS(sql)
		
		If rs.BOF Or rs.EOF Then
		Else
			lVat = rs.Fields("vat").Value
			lExclusive = rs.Fields("exclusive").Value
			If lExclusive Then
				lblDepositVatRateIn.Text = FormatNumber(lVat / lExclusive * 100, 2)
			Else
				lblDepositVatRateIn.Text = FormatNumber(0, 2)
			End If
			lblDepositIn.Text = FormatNumber(lExclusive, 2)
			lblDepositVatIn.Text = FormatNumber(lVat, 2)
			lblDepositInclusiveIn.Text = FormatNumber(lExclusive + lVat, 2)
		End If
		
		sql = "SELECT GRVItem.GRVItem_Return, Sum(((Abs([StockItem_Quantity]=[GRVItem_PackSize])*[Deposit_CaseCost])+([Deposit_UnitCost]*[GRVItem_PackSize]))*[GRVItem_Quantity]) AS exclusive, Sum((((Abs([StockItem_Quantity]=[GRVItem_PackSize])*[Deposit_CaseCost])+([Deposit_UnitCost]*[GRVItem_PackSize]))*[GRVItem_Quantity])*([Vat_Amount]/100)) AS vat, Avg(Vat.Vat_Amount) AS AvgOfVat_Amount, Count(GRVItem.GRVItem_GRVID) AS CountOfGRVItem_GRVID FROM ((GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID Where (((Deposit.Deposit_UnitCost) <> 0) And ((GRVItem.GRVItem_GRVID) = " & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ")) Or (((Deposit.Deposit_CaseCost) <> 0) And ((GRVItem.GRVItem_GRVID) = " & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ")) GROUP BY GRVItem.GRVItem_Return HAVING (GRVItem.GRVItem_Return=1);"
		rs = getRS(sql)
		
		If rs.BOF Or rs.EOF Then
		Else
			lVat = rs.Fields("vat").Value
			lExclusive = rs.Fields("exclusive").Value
			If lExclusive = 0 Then
				lblDepositVatRateOut.Text = FormatNumber(0, 2)
			Else
				lblDepositVatRateOut.Text = FormatNumber(lVat / lExclusive * 100, 2)
			End If
			lblDepositOut.Text = FormatNumber(lExclusive, 2)
			lblDepositVatOut.Text = FormatNumber(lVat, 2)
			lblDepositInclusiveOut.Text = FormatNumber(lExclusive + lVat, 2)
		End If
		Me.lblDepositReturnOut.Text = "0.00"
		Me.lblDepositReturnVatOut.Text = "0.00"
		Me.lblDepositReturnVatRateOut.Text = "0.00"
		Me.lblDepositReturnInclusiveOut.Text = "0.00"
		
		sql = "SELECT Sum((IIf([GRVDeposit_Type]=1,[Deposit_UnitCost],0)+IIf([GRVDeposit_Type]=2,[Deposit_CaseCost],0)+IIf([GRVDeposit_Type]=3,[Deposit_UnitCost]*[Deposit_Quantity]+[Deposit_CaseCost],0))*[GRVDeposit_Quantity]) AS exclusive, Sum((IIf([GRVDeposit_Type]=1,[Deposit_UnitCost],0)+IIf([GRVDeposit_Type]=2,[Deposit_CaseCost],0)+IIf([GRVDeposit_Type]=3,[Deposit_UnitCost]*[Deposit_Quantity]+[Deposit_CaseCost],0))*[GRVDeposit_Quantity]*[Vat_Amount]/100) AS vat, Count(GRVDeposit.GRVDeposit_GRVID) AS itemCount FROM (Deposit INNER JOIN GRVDeposit ON Deposit.DepositID = GRVDeposit.GRVDeposit_DepositID) INNER JOIN Vat ON Deposit.Deposit_VatID = Vat.VatID WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVDeposit.GRVDeposit_Return)=0));"
		rs = getRS(sql)
		If rs.BOF Or rs.EOF Then
		Else
            If IsDBNull(rs.Fields("vat").Value) Then
                lVat = 0
                lExclusive = 0
                lblDepositReturnVatRateOut.Text = FormatNumber(0, 2)
            Else
                lVat = rs.Fields("vat").Value
                lExclusive = rs.Fields("exclusive").Value
                If lExclusive = 0 Then
                    lblDepositReturnVatRateOut.Text = FormatNumber(0, 2)
                Else
                    lblDepositReturnVatRateOut.Text = FormatNumber(lVat / lExclusive * 100, 2)
                End If
            End If
			lblDepositReturnOut.Text = FormatNumber(lExclusive, 2)
			lblDepositReturnVatOut.Text = FormatNumber(lVat, 2)
			lblDepositReturnInclusiveOut.Text = FormatNumber(lExclusive + lVat, 2)
		End If
		
		sql = "SELECT Sum((IIf([GRVDeposit_Type]=1,[Deposit_UnitCost],0)+IIf([GRVDeposit_Type]=2,[Deposit_CaseCost],0)+IIf([GRVDeposit_Type]=3,[Deposit_UnitCost]*[Deposit_Quantity]+[Deposit_CaseCost],0))*[GRVDeposit_Quantity]) AS exclusive, Sum((IIf([GRVDeposit_Type]=1,[Deposit_UnitCost],0)+IIf([GRVDeposit_Type]=2,[Deposit_CaseCost],0)+IIf([GRVDeposit_Type]=3,[Deposit_UnitCost]*[Deposit_Quantity]+[Deposit_CaseCost],0))*[GRVDeposit_Quantity]*[Vat_Amount]/100) AS vat, Count(GRVDeposit.GRVDeposit_GRVID) AS itemCount FROM (Deposit INNER JOIN GRVDeposit ON Deposit.DepositID = GRVDeposit.GRVDeposit_DepositID) INNER JOIN Vat ON Deposit.Deposit_VatID = Vat.VatID WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVDeposit.GRVDeposit_Return)=1));"
		rs = getRS(sql)
		If rs.BOF Or rs.EOF Then
		Else
			If IsDbNull(rs.Fields("vat").Value) Then
				lVat = 0
				lExclusive = 0
				lblDepositReturnVatRateIn.Text = FormatNumber(0, 2)
			Else
				lVat = rs.Fields("vat").Value
				lExclusive = rs.Fields("exclusive").Value
				If lExclusive = 0 Then
					lblDepositReturnVatRateIn.Text = FormatNumber(0, 2)
				Else
					lblDepositReturnVatRateIn.Text = FormatNumber(lVat / lExclusive * 100, 2)
				End If
			End If
			lblDepositReturnIn.Text = FormatNumber(lExclusive, 2)
			lblDepositReturnVatIn.Text = FormatNumber(lVat, 2)
			lblDepositReturnInclusiveIn.Text = FormatNumber(lExclusive + lVat, 2)
		End If
		Me.lblCredit.Text = FormatNumber(CDec(lblInclusiveOut.Text) + CDec(lblDepositInclusiveOut.Text), 2)
		Me.lblCreditVat.Text = FormatNumber(CDec(Me.lblVATout.Text) + CDec(lblDepositVatOut.Text), 2)
		Me.lblInBoundVat.Text = FormatNumber(CDec(Me.lblCreditVat.Text) + CDec(lblDepositReturnVatOut.Text), 2)
		Me.lblInBound.Text = FormatNumber(CDec(Me.lblCredit.Text) + CDec(lblDepositReturnInclusiveOut.Text), 2)
		
	End Sub
	
	
	Public Sub loadSummary()
		Dim rs As ADODB.Recordset
		
        ResizeForm(frmGRVSummary, pixelToTwips(frmGRVSummary.Width, True), _
                   pixelToTwips(frmGRVSummary.Height, False), 2)
		
		
		rs = getRS("SELECT * FROM GRV WHERE GRVID = " & frmGRV.adoPrimaryRS.Fields("GRVID").Value)
		setTotals()
		
		Me.lblSupplier.Text = frmGRVitem.lblSupplier.Text
		
		Me.frmMain.Text = "Summary for Invoice # '" & frmGRV.adoPrimaryRS.Fields("GRV_InvoiceNumber").Value & "'"
		If IsDbNull(frmGRV.adoPrimaryRS.Fields("Supplier_Ullage").Value) Then
			Me.txtUllage.Text = FormatNumber("0", 2)
		Else
			Me.txtUllage.Text = FormatNumber(frmGRV.adoPrimaryRS.Fields("Supplier_Ullage").Value, 2)
		End If
		Me.txtDiscount.Text = FormatNumber("0", 2)
		Me.txtMinus.Text = FormatNumber(rs.Fields("GRV_SundriesMinus").Value, 2)
		Me.txtPlus.Text = FormatNumber(rs.Fields("GRV_SundriesPlus").Value, 2)
		lblTotalOriginal.Text = FormatNumber(rs.Fields("GRV_InvoiceInclusive").Value, 2)
		If IsDbNull(rs.Fields("GRV_Notes").Value) Then
			txtNotes.Text = ""
		Else
			Me.txtNotes.Text = rs.Fields("GRV_Notes").Value
		End If
		Me.cmbPayment.SelectedIndex = 0
		cmbPayment_SelectedIndexChanged(cmbPayment, New System.EventArgs())
		doTotals()
		If bolAirTimeGRV = True Then
			tmrAutoGRV.Enabled = True
		End If
		
		loadLanguage()
		ShowDialog()
	End Sub
	Sub SaveIntoTable()
        Dim sql As String
		'Save all details into serial tables
		Dim rs As ADODB.Recordset
		Dim intK As Short
		Dim intP As Short
		Dim Grv_qty As Short
		Dim Grv_Track As Short
		Dim UpLoop As Short
		Dim SItem As String
		
		Grv_qty = 0
		Grv_Track = 0
		
		For intK = 0 To intCurr - 1
			sql = "SELECT * FROM GRVItem WHERE GRVItem_StockItemID = " & intArraySCode(intK) & " AND GRVItem_Return = 0 AND GRVItem_GRVID = " & Gr_ID
			rs = getRS(sql)
			
			Grv_qty = (rs.Fields("GRVItem_Quantity").Value - 1)
			UpLoop = Grv_Track + Grv_qty
			If rs.RecordCount = 1 Then
				For intP = Grv_Track To UpLoop
					If Mid(Trim(tempStockItem(intP)), 1, 2) = "RT" Then
						'Returned
						SItem = Trim(VB.Right(Trim(tempStockItem(intP)), Len(Trim(tempStockItem(intP))) - 2))
						sql = "INSERT INTO SerialTracking (Serial_StockItemID,Serial_SerialNumber,Serial_SupplierName,Serial_DatePurchases,Serial_Status,Serial_GRV_ID) " & "VALUES (" & Val(CStr(intArraySCode(intK))) & ",'" & SItem & "','" & Split(lblSupplier.Text, "(")(0) & "',#" & CDate(Today) & "#,'Returned'" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ")"
						
					Else
						'Received
						SItem = Trim(VB.Right(Trim(tempStockItem(intP)), Len(Trim(tempStockItem(intP))) - 2))
						'sql = "INSERT INTO SerialTracking (Serial_StockItemID,Serial_SerialNumber,Serial_SupplierName,Serial_DatePurchases,Serial_Status,Serial_GRV_ID) " & "VALUES (" & Val(CStr(intArraySCode(intK))) & ",'" & SItem & "','" & Split(lblSupplier.Text, "(")(0) & "',#" & CDate(Today) & "#,'Received'," & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ")"
					End If
					
					cnnDB.Execute(sql)
					
				Next 
				
				Grv_Track = intP 'Grv_qty + 1
			End If
			
			
		Next 
	End Sub
	
	
	
	Private Sub frmGRVSummaryFnV_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		saveDetails()
	End Sub
	
	
	Private Sub Picture2_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Picture2.Resize
        cmdExit.Left = twipsToPixels(pixelToTwips(Picture2.ClientRectangle.Width, True) - _
                                    pixelToTwips(cmdExit.Width, True) - 30, True)
        cmdBack.Left = twipsToPixels(pixelToTwips(cmdExit.Left, True) - _
                                    pixelToTwips(cmdBack.Width, True) - _
                                    pixelToTwips(cmdBack.Width, True) - 150 - 45, True)
		
	End Sub
	
	Private Sub tmrAutoGRV_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrAutoGRV.Tick
		If bolAirTimeGRV = True Then
			tmrAutoGRV.Enabled = False
			cmdNext.Focus()
			cmdNext_Click_Auto()
		End If
	End Sub
	
	Private Sub txtDiscount_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtDiscount.Enter
        MyGotFocusNumeric(txtDiscount)
	End Sub
	
	Private Sub txtDiscount_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscount.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        MyKeyPress(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtDiscount_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtDiscount.Leave
        MyLostFocus(txtDiscount, 2)
		doTotals()
	End Sub
	
	Private Sub txtMinus_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMinus.Enter
        MyGotFocusNumeric(txtMinus)
	End Sub
	
	Private Sub txtMinus_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtMinus.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        MyKeyPress(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtMinus_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMinus.Leave
        MyLostFocus(txtMinus, 2)
		doTotals()
	End Sub
	
	
	Private Sub txtPlus_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPlus.Enter
        MyGotFocusNumeric(txtPlus)
	End Sub
	
	Private Sub txtPlus_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtPlus.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        MyKeyPress(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtPlus_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPlus.Leave
        MyLostFocus(txtPlus, 2)
		doTotals()
	End Sub
	
	
	Private Sub txtUllage_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtUllage.Enter
        MyGotFocusNumeric(txtUllage)
	End Sub
	
	Private Sub txtUllage_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtUllage.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        MyKeyPress(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtUllage_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtUllage.Leave
        MyLostFocus(txtUllage, 2)
		doTotals()
	End Sub

    Private Sub frmGRVSummaryFnV_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Frame1.AddRange(New GroupBox() {_Frame1_0, _Frame1_1, _Frame1_2, _Frame1_3, _
                                        _Frame1_4, _Frame1_5, _Frame1_6})
        optClose.AddRange(New RadioButton() {_optClose_0})
        lbl.AddRange(New Label() {_lbl_0, _lbl_1, _lbl_2, _lbl_3, _lbl_4, _lbl_5, _lbl_6, _
                                  _lbl_7, _lbl_8, _lbl_9, _lbl_10, _lbl_11, _lbl_12, _lbl_13, _
                                  _lbl_14, _lbl_15, _lbl_16, _lbl_17, _lbl_18, _lbl_19, _lbl_20, _
                                  _lbl_21, _lbl_22, _lbl_23, _lbl_24, _lbl_25, _lbl_26, _lbl_27, _
                                  _lbl_28, _lbl_29, _lbl_30, _lbl_31, _lbl_32, _lbl_33, _lbl_34, _
                                  _lbl_35, _lbl_37})
    End Sub
End Class