Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmGRVitemFnV
	Inherits System.Windows.Forms.Form
	'Option Explicit
	
	'Dim gDOM As DOMDocument
	'Dim gDOMOrder As DOMDocument
	Dim loading As Boolean
	
	Public colName As Short
	Public colQuantity As Short
	Public colPackSize As Short
	Public colDiscountLine As Short
	Public colDiscount As Short
	Public colDiscountPercentage As Short
	Public colOnOrder As Short
	
	Public colCode As Short
	Public colContentExclusive As Short
	Public colContentInclusive As Short
	Public colContentTotalExclusive As Short
	Public colContentTotalInclusive As Short
	Public colDepositExclusive As Short
	Public colDepositInclusive As Short
	Public colDepositTotalExclusive As Short
	Public colDepositTotalInclusive As Short
	Public colTotalExclusive As Short
	Public colTotalInclusive As Short
	Public colExclusive As Short
	Public colInclusive As Short
	Public colPrice As Short
	Public colBrokenPack As Short
	Public colVAT As Short
	Public colFractions As Short
	Public lockLine As Boolean
	
	Dim gStockItems As Boolean
	Public orderType As Short
	Public activePrice As Short
	Public gQuickKey As Boolean
	'Public gNodeTemplate As IXMLDOMNode
	Public gFieldDisplay, gFieldOrder, gFieldOrderDefault, gFieldDisplayDefault As String
	Public gGRVFieldOrder As String
	Dim gFractions As Boolean

    Dim txtEdit As New List(Of TextBox)
	
	Dim rsPackSize As ADODB.Recordset
	Dim bFNVegPackSize As Boolean
	
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1657 'GRV Processing Form|Checked
		If rsLang.RecordCount Then frmGRVitem.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : frmGRVitem.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1583 'All Stock Items|Checked
		If rsLang.RecordCount Then cmdStockItem.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdStockItem.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1148 'Delete|Checked
		If rsLang.RecordCount Then cmdDelete.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdDelete.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1585 'Break / Build Pack|Checked
		If rsLang.RecordCount Then cmdPack.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPack.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1661 'Change Price|Checked
		If rsLang.RecordCount Then cmdPrice.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrice.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1662 'Discount|Checked
		If rsLang.RecordCount Then cmdDiscount.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdDiscount.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1663 'Quick Edit|Checked
		If rsLang.RecordCount Then cmdQuick.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdQuick.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1664 'Change VAT|Checked
		If rsLang.RecordCount Then cmdVat.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdVat.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1665 'Print Order|Checked
		If rsLang.RecordCount Then cmdPrintOrder.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrintOrder.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1666 'Print GRV|Checked
		If rsLang.RecordCount Then cmdPrintGRV.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrintGRV.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1586 'Edit stock Item|Checked
		If rsLang.RecordCount Then cmdEdit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdEdit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1668 'New Stock Item|Checked
		If rsLang.RecordCount Then cmdNew.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdNew.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1579 'Back|Checked
		If rsLang.RecordCount Then cmdBack.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdBack.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1005 'Next|Checked
		If rsLang.RecordCount Then cmdNext.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdNext.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lblSupplier = No Code/Dynamic/NA?
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1591 'Stock Item Selector|Checked
        If rsLang.RecordCount Then _lbl_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1838 'Barcode|Checked
		If rsLang.RecordCount Then Label1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1080 'Search|Checked
        If rsLang.RecordCount Then _lbl_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1714 'RETURNS|Checked
		If rsLang.RecordCount Then lblReturns.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lblReturns.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1685 'Sub Totals|Checked
		If rsLang.RecordCount Then frmTotals.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : frmTotals.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lbl(8) = No Code           [No of Cases]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lbl(8).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(8).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1717 'Broken Packs|
        If rsLang.RecordCount Then _lbl_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lblTotal_0 = No Code      [Exclusive Content]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblTotal_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblTotal_1 = No Code      [Inclusive Content]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblTotal_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblTotal_2 = No Code      [Exclusive Deposit]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblTotal_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblTotal_3 = No Code      [Inclusive Deposit]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblTotal_3.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1688 'Exclusive Total|Checked
		If rsLang.RecordCount Then _lblTotal_4.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblTotal_4.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1689 'Inclusive Total|Checked
		If rsLang.RecordCount Then _lblTotal_5.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblTotal_5.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
        'UPGRADE_ISSUE: Form property frmGRVitemFnV.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	
	Private Sub getOrder()
		Dim rs As ADODB.Recordset
		Dim rs1 As ADODB.Recordset
		Dim CurTot As Decimal
		Dim oText As System.Windows.Forms.TextBox
		For	Each oText In txtEdit
			oText.Visible = False
		Next oText
		'    Dim lNode As IXMLDOMNode
		'    Dim lNodeList As IXMLDOMNodeList
		Dim lCode As String
		If gGRVFieldOrder = "" Then
			lCode = gFieldOrder
		Else
			lCode = gGRVFieldOrder
		End If
		Dim x As Short
		Dim lDeposit As Decimal
		rs = getRS("SELECT GRVItem.*, StockItem.*, Vat.Vat_Amount, Deposit.* FROM ((GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=" & orderType & ")) ORDER BY " & lCode & ";")
		
		
		loading = True
		With gridItem
			.Visible = False
            '            xsl:Sort select="" data-type="text" order="asending
            .RowCount = rs.RecordCount + 1
			x = 0
			Do Until rs.EOF
				x = x + 1
				.row = x
				.set_RowData(x, rs.Fields("StockItemID").Value)
				.Col = colFractions
				.set_TextMatrix(x, colFractions, rs.Fields("StockItem_Fractions").Value)
				
				.Col = colPackSize
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(222, 222, 222))
				.Col = colContentExclusive
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(222, 222, 222))
				.Col = colContentInclusive
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(212, 212, 212))
				
				.Col = colDepositExclusive
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(222, 222, 222))
				.Col = colDepositInclusive
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(212, 212, 212))
				
				.Col = colDepositTotalExclusive
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(220, 220, 255))
				.Col = colDepositTotalInclusive
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(200, 200, 255))
				
				.Col = colContentTotalExclusive
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(220, 220, 255))
				.Col = colContentTotalInclusive
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(200, 200, 255))
				
				.Col = colDiscount
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(222, 222, 200))
				.Col = colDiscountLine
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(222, 222, 200))
				.Col = colDiscountPercentage
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(222, 222, 200))
				.Col = colOnOrder
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(222, 222, 222))
				
				.Col = colExclusive
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(220, 255, 220))
				.Col = colInclusive
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(200, 255, 200))
				
				.Col = colTotalExclusive
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(220, 255, 220))
				.Col = colTotalInclusive
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(200, 255, 200))
				
				
				If gStockItems Then
					.set_TextMatrix(x, colName, rs.Fields("StockItem_Name").Value)
				Else
					If IsDbNull(rs.Fields(gFieldDisplay).Value) Then
						.set_TextMatrix(x, colName, rs.Fields("StockItem_Name").Value)
					Else
						.set_TextMatrix(x, colName, rs.Fields("StockItem_Name").Value)
						' .TextMatrix(x, colName) = rs(gFieldDisplay)
					End If
				End If
				
				rs1 = getRS("SELECT PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk WHERE ((PriceChannelLnk.PriceChannelLnk_Quantity=1) AND (PriceChannelLnk.PriceChannelLnk_ChannelID=1) AND (PriceChannelLnk.PriceChannelLnk_StockItemID=" & rs.Fields("StockItemID").Value & "));")
				
				'Selling Price here
				If rs1.RecordCount = 1 Then
					.set_TextMatrix(x, colPrice, FormatNumber(rs.Fields("GRVItem_Price").Value, 2)) 'FormatNumber(rs1("PriceChannelLnk_Price"), 2)
					
					'cnnDB.Execute "UPDATE GRVItem SET GRVItem_Price = " & FormatNumber(rs1("PriceChannelLnk_Price"), 2) & " Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS("GRVID") & ") And (GRVItem_StockItemID = " & rs("StockItemID") & ") And (GRVItem_Return = " & orderType & ")"
				Else
					.set_TextMatrix(x, colPrice, 0)
					'cnnDB.Execute "UPDATE GRVItem SET GRVItem_Price = " & FormatNumber(0, 2) & " Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS("GRVID") & ") And (GRVItem_StockItemID = " & rs("StockItemID") & ") And (GRVItem_Return = " & orderType & ")"
				End If
				
				.set_TextMatrix(x, colCode, "" & rs.Fields("GRVItem_Code").Value)
				.set_TextMatrix(x, colVAT, FormatNumber(rs.Fields("GRVitem_VatRate").Value, 2))
				
				.set_TextMatrix(x, colOnOrder, FormatNumber(rs.Fields("GRVItem_QuantityOrder").Value, 0))
				
				'Check for person security to not show Order QTY
				If 8192 And frmMenu.gBit Then
					If rs.Fields("StockItem_Fractions").Value Then
						.set_TextMatrix(x, colQuantity, FormatNumber(rs.Fields("GRVItem_Quantity").Value, 4))
					Else
						.set_TextMatrix(x, colQuantity, FormatNumber(rs.Fields("GRVItem_Quantity").Value, 0))
					End If
				Else
					If rs.Fields("StockItem_Fractions").Value Then
						.set_TextMatrix(x, colQuantity, FormatNumber(0, 4))
					Else
						.set_TextMatrix(x, colQuantity, FormatNumber(0, 0))
					End If
				End If
				'Check for person security to not show Order QTY
				
				.set_TextMatrix(x, colPackSize, FormatNumber(rs.Fields("GRVItem_PackSize").Value, 0))
				
				If .get_TextMatrix(x, colPackSize) <> FormatNumber(rs.Fields("StockItem_Quantity").Value, 0) Then
					.Col = colPackSize
					gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 200, 200))
					.set_TextMatrix(x, colBrokenPack, "X")
				Else
					.set_TextMatrix(x, colBrokenPack, "")
				End If
				.set_TextMatrix(x, colDiscount, FormatNumber(rs.Fields("GRVItem_DiscountAmount").Value, 4))
				If Me.activePrice = 1 Or activePrice = 3 Then
					.set_TextMatrix(x, colDiscount, CDec(.get_TextMatrix(x, colDiscount)) * (1 + CDbl(.get_TextMatrix(x, colVAT)) / 100))
				End If
				If CDec(.get_TextMatrix(x, colDiscount)) <> 0 Then
					.Col = colDiscount
					gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 200, 200))
					.Col = colDiscountLine
					gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 200, 200))
					.Col = colDiscountPercentage
					gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 200, 200))
				End If
				If rs.Fields("GRVItem_ContentCost").Value <> rs.Fields("StockItem_ListCost").Value Then
					.set_TextMatrix(x, colContentExclusive, FormatNumber(rs.Fields("GRVItem_ContentCost").Value, 2)) ' / rs("StockItem_Quantity") * rs("GRVItem_PackSize"), 2)
					'If .TextMatrix(x, colBrokenPack) = "X" Then .TextMatrix(x, colContentExclusive) = FormatNumber(rs("GRVItem_ContentCost") / FormatNumber(rs("StockItem_Quantity"), 0), 2)
				Else
					.set_TextMatrix(x, colContentExclusive, FormatNumber(rs.Fields("StockItem_ListCost").Value, 2)) 'FormatNumber(rs("GRVItem_ContentCost") / rs("StockItem_Quantity") * rs("GRVItem_PackSize"), 2)
				End If
				If .get_TextMatrix(x, colBrokenPack) = "X" Then .set_TextMatrix(x, colContentExclusive, FormatNumber(rs.Fields("GRVItem_ContentCost").Value / CDbl(FormatNumber(rs.Fields("StockItem_Quantity").Value, 0)), 2))
				'cnnDB.Execute "UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_PackSize = [StockItem]![StockItem_Quantity], GRVItem.GRVItem_ContentCost = [StockItem]![StockItem_ListCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_StockItemID)=" & gridItem.RowData(gridItem.row) & ") AND ((GRVItem.GRVItem_Return)=" & orderType & "));"
				'Else
				'cnnDB.Execute "UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_PackSize = 1, GRVItem.GRVItem_ContentCost = [StockItem]![StockItem_ListCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_StockItemID)=" & gridItem.RowData(gridItem.row) & ") AND ((GRVItem.GRVItem_Return)=" & orderType & "));"
				'End If
				If CDec(rs.Fields("StockItem_ListCost").Value) <> CDec(rs.Fields("GRVItem_ContentCost").Value) Then
					.Col = colContentExclusive
					.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 200, 200))
					.Col = colContentInclusive
					.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 200, 200))
					.Col = colExclusive
					.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 200, 200))
					.Col = colInclusive
					.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 200, 200))
				End If
				lDeposit = 0
				lDeposit = rs.Fields("Deposit_UnitCost").Value * rs.Fields("GRVItem_PackSize").Value
				If rs.Fields("StockItem_Quantity").Value = rs.Fields("GRVItem_PackSize").Value Then
					lDeposit = lDeposit + rs.Fields("Deposit_CaseCost").Value
				End If
				If colDepositExclusive Then
					.set_TextMatrix(x, colDepositExclusive, FormatNumber(lDeposit, 2))
				Else
					.set_TextMatrix(x, colContentExclusive, FormatNumber(CDec(.get_TextMatrix(x, colContentExclusive)) + lDeposit, 2))
				End If
				
				'total selling and gp
				
				displayLine(x)
				rs.moveNext()
			Loop 
			.Col = colQuantity
			.Visible = True
		End With
		loading = False
		doTotals()
		
	End Sub
	
    Private Sub displayLine(ByRef row As Integer)
        Dim lDiscount As Decimal
        With gridItem
            lDiscount = CDec(.get_TextMatrix(row, colDiscount))
            If activePrice = 1 Or activePrice = 3 Then
                lDiscount = lDiscount / (1 + CDbl(.get_TextMatrix(row, colVAT)) / 100)
            End If
            .set_TextMatrix(row, colDepositTotalExclusive, FormatNumber(CDbl(.get_TextMatrix(row, colDepositExclusive)) * CDbl(.get_TextMatrix(row, colQuantity)), 2))
            .set_TextMatrix(row, colContentTotalExclusive, FormatNumber((CDbl(.get_TextMatrix(row, colContentExclusive)) - lDiscount) * CDbl(.get_TextMatrix(row, colQuantity)), 2))

            .set_TextMatrix(row, colTotalExclusive, FormatNumber(CDec(.get_TextMatrix(row, colContentTotalExclusive)) + CDec(.get_TextMatrix(row, colDepositTotalExclusive)), 2))
            .set_TextMatrix(row, colExclusive, FormatNumber(CDec(.get_TextMatrix(row, colContentExclusive)) + CDec(.get_TextMatrix(row, colDepositExclusive)), 2))

            .set_TextMatrix(row, colContentInclusive, FormatNumber(CDec(.get_TextMatrix(row, colContentExclusive)) + CDec(.get_TextMatrix(row, colContentExclusive)) * CDec(.get_TextMatrix(row, colVAT)) / 100, 2))
            .set_TextMatrix(row, colDepositInclusive, FormatNumber(CDec(.get_TextMatrix(row, colDepositExclusive)) + CDec(.get_TextMatrix(row, colDepositExclusive)) * CDec(.get_TextMatrix(row, colVAT)) / 100, 2))
            .set_TextMatrix(row, colContentTotalInclusive, FormatNumber(CDec(.get_TextMatrix(row, colContentTotalExclusive)) + CDec(.get_TextMatrix(row, colContentTotalExclusive)) * CDec(.get_TextMatrix(row, colVAT)) / 100, 2))
            .set_TextMatrix(row, colDepositTotalInclusive, FormatNumber(CDec(.get_TextMatrix(row, colDepositTotalExclusive)) + CDec(.get_TextMatrix(row, colDepositTotalExclusive)) * CDec(.get_TextMatrix(row, colVAT)) / 100, 2))

            .set_TextMatrix(row, colTotalInclusive, FormatNumber(CDec(.get_TextMatrix(row, colTotalExclusive)) + CDec(.get_TextMatrix(row, colTotalExclusive)) * CDec(.get_TextMatrix(row, colVAT)) / 100, 2))

            .set_TextMatrix(row, colInclusive, FormatNumber(CDec(.get_TextMatrix(row, colExclusive)) + CDec(.get_TextMatrix(row, colExclusive)) * CDec(.get_TextMatrix(row, colVAT)) / 100, 2))
            If CDec(gridItem.get_TextMatrix(gridItem.row, colContentExclusive)) = 0 Then
                gridItem.set_TextMatrix(gridItem.row, colDiscountPercentage, 0)
            Else
                gridItem.set_TextMatrix(gridItem.row, colDiscountPercentage, FormatNumber(CDec(.get_TextMatrix(row, colDiscount)) / CDec(gridItem.get_TextMatrix(gridItem.row, colContentExclusive)) * 100, 2))
            End If
            gridItem.set_TextMatrix(gridItem.row, colDiscountLine, FormatNumber(CDec(.get_TextMatrix(row, colDiscount)) * CDbl(gridItem.get_TextMatrix(gridItem.row, colQuantity)), 2))

            .set_TextMatrix(row, colDepositTotalExclusive, FormatNumber(CDbl(.get_TextMatrix(row, colPrice)) * CDbl(.get_TextMatrix(row, colQuantity)), 2))
            If CDbl(.get_TextMatrix(row, colContentTotalExclusive)) > 0 And CDbl(.get_TextMatrix(row, colDepositTotalExclusive)) > 0 Then
                .set_TextMatrix(row, colDepositTotalInclusive, FormatNumber(100 - ((CDbl(.get_TextMatrix(row, colContentTotalExclusive)) / CDbl(.get_TextMatrix(row, colDepositTotalExclusive))) * 100), 2))
            End If
        End With

    End Sub
	
	Private Sub getNamespace()
		Dim rs As ADODB.Recordset
		Dim lString As String
		Dim lWhere1 As String
		lString = Trim(txtSearch.Text)
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		
		
		If Trim(txtSearch.Text) = "" Then
			lString = ""
		Else
			lWhere1 = "(StockItem_SupplierCode LIKE '%" & Replace(lString, " ", "%' AND StockItem_SupplierCode LIKE '%") & "%')"
			lString = "(StockItem_Name LIKE '%" & Replace(lString, " ", "%' AND StockItem_Name LIKE '%") & "%')"
			lString = lString & " OR " & lWhere1
		End If
		
		If lString = "" Then
			lString = " StockItem.StockItem_Discontinued=0 "
		Else
			lString = " StockItem.StockItem_Discontinued=0 AND " & lString
		End If
		
		If gStockItems Then
			If lString <> "" Then lString = " WHERE " & lString
			rs = getRS("SELECT TOP 100 PERCENT StockItem.StockItemID, StockItem.StockItem_Name AS name From StockItem " & lString & " ORDER BY StockItem.StockItem_Name;")
		Else
			If lString <> "" Then lString = " AND " & lString
			rs = getRS("SELECT TOP 100 PERCENT StockItemID, StockItem_Name as name From StockItem Where (StockItem_SupplierID = " & frmGRV.adoPrimaryRS.Fields("SupplierID").Value & ") " & lString & " ORDER BY StockItem_Name")
		End If
		lstWorkspace.Items.Clear()
		Dim lName As String
		If rs.RecordCount Then
			Do Until rs.EOF
                lstWorkspace.Items.Add(rs.Fields("name").Value & " " & rs.Fields("StockItemID").Value)
				rs.moveNext()
			Loop 
		Else
			If IsNumeric(txtSearch.Text) Then
				rs = getRS("SELECT TOP 100 PERCENT StockItem.StockItemID, StockItem.StockItem_Name as Name, Catalogue.Catalogue_Quantity FROM StockItem INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID Where (((Catalogue.Catalogue_Barcode) = '" & txtSearch.Text & "')) GROUP BY StockItem.StockItemID, StockItem.StockItem_Name, Catalogue.Catalogue_Quantity ORDER BY StockItem.StockItem_Name;")
				
				Do Until rs.EOF
                    lstWorkspace.Items.Add(rs.Fields("name").Value & " " & rs.Fields("StockItemID").Value)
					rs.moveNext()
				Loop 
				If lstWorkspace.Items.Count Then
					lstWorkspace.SelectedIndex = 0
					lstWorkspace_DoubleClick(lstWorkspace, New System.EventArgs())
                    Me._txtEdit_0.Focus()
					Exit Sub
				End If
			End If
		End If
		If lstWorkspace.Items.Count Then
			lstWorkspace.SelectedIndex = 0
			On Error Resume Next
			lstWorkspace.Focus()
		End If
	End Sub
	
	Private Sub setup()
		loading = True
		'    Dim lDOM As DOMDocument
		'    Dim lNode As IXMLDOMNode
		'    Dim lNodeList As IXMLDOMNodeList
		lblSupplier.Text = frmGRV.adoPrimaryRS.Fields("Supplier_Name").Value & "(" & frmGRV.adoPrimaryRS.Fields("PurchaseOrder_Reference").Value & ")"
		lblReturns.Visible = orderType
		
		With gridItem
			gridItem.row = 0
			
            gridItem.Col = 24
			
			gridItem.set_RowHeight(0, 430)
			gridItem.Col = colTotalExclusive
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colTotalExclusive, "Total Excl")
			gridItem.set_ColAlignment(colTotalExclusive, 7)
			gridItem.set_ColWidth(colTotalExclusive, 900)
			
			gridItem.Col = colTotalInclusive
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colTotalInclusive, "Total Incl")
			gridItem.set_ColAlignment(colTotalInclusive, 7)
			gridItem.set_ColWidth(colTotalInclusive, 900)
			
			gridItem.Col = colExclusive
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colExclusive, "Item Excl")
			gridItem.set_ColAlignment(colExclusive, 7)
			gridItem.set_ColWidth(colExclusive, 900)
			
			gridItem.Col = colInclusive
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colInclusive, "Item Incl")
			gridItem.set_ColAlignment(colInclusive, 7)
			gridItem.set_ColWidth(colInclusive, 900)
			
			
			gridItem.Col = colVAT
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colVAT, "VAT")
			gridItem.set_ColAlignment(colVAT, 7)
			gridItem.set_ColWidth(colVAT, 500)
			
			gridItem.Col = colCode
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colCode, "Code")
			gridItem.set_ColAlignment(colCode, 7)
			gridItem.set_ColWidth(colCode, 800)
			
			gridItem.Col = colName
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colName, "Description")
			gridItem.set_ColAlignment(colName, 1)
			gridItem.set_ColWidth(colName, 2500)
			
			gridItem.Col = colBrokenPack
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colBrokenPack, "B")
			gridItem.set_ColAlignment(colBrokenPack, 7)
			gridItem.set_ColWidth(colBrokenPack, 250)
			
			gridItem.Col = colDiscount
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colDiscount, "Disc. Item")
			gridItem.set_ColAlignment(colDiscount, 7)
			gridItem.set_ColWidth(colDiscount, 800)
			gridItem.Col = colDiscountLine
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colDiscountLine, "Disc. Line")
			gridItem.set_ColAlignment(colDiscountLine, 7)
			gridItem.set_ColWidth(colDiscountLine, 800)
			
			gridItem.Col = colDiscountPercentage
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colDiscountPercentage, "Disc. Percent")
			gridItem.set_ColAlignment(colDiscountPercentage, 7)
			gridItem.set_ColWidth(colDiscountPercentage, 800)
			
			gridItem.Col = colOnOrder
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colOnOrder, "Ord")
			gridItem.set_ColAlignment(colOnOrder, 7)
			gridItem.set_ColWidth(colOnOrder, 500)
			
			gridItem.Col = colQuantity
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colQuantity, "QTY")
			gridItem.set_ColAlignment(colQuantity, 7)
			gridItem.set_ColWidth(colQuantity, 800)
			
			gridItem.Col = colPackSize
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colPackSize, "P")
			gridItem.set_ColAlignment(colPackSize, 7)
			gridItem.set_ColWidth(colPackSize, 300)
			
			gridItem.Col = colContentExclusive
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colContentExclusive, "Content Excl")
			gridItem.set_ColAlignment(colContentExclusive, 7)
			gridItem.set_ColWidth(colContentExclusive, 900)
			
			gridItem.Col = colPrice
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colPrice, "Selling")
			gridItem.set_ColAlignment(colPrice, 7)
			gridItem.set_ColWidth(colPrice, 900)
			
			gridItem.Col = colContentInclusive
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colContentInclusive, "Content Incl")
			gridItem.set_ColAlignment(colContentInclusive, 7)
			gridItem.set_ColWidth(colContentInclusive, 900)
			
			gridItem.Col = colContentTotalExclusive
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colContentTotalExclusive, "Total Con Excl")
			gridItem.set_ColAlignment(colContentTotalExclusive, 7)
			gridItem.set_ColWidth(colContentTotalExclusive, 900)
			
			gridItem.Col = colContentTotalInclusive
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colContentTotalInclusive, "Total Con Incl")
			gridItem.set_ColAlignment(colContentTotalInclusive, 7)
			gridItem.set_ColWidth(colContentTotalInclusive, 900)
			
			gridItem.Col = colDepositExclusive
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colDepositExclusive, "Deposit Excl")
			gridItem.set_ColAlignment(colDepositExclusive, 7)
			gridItem.set_ColWidth(colDepositExclusive, 900)
			
			gridItem.Col = colDepositInclusive
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colDepositInclusive, "Deposit Incl")
			gridItem.set_ColAlignment(colDepositInclusive, 7)
			gridItem.set_ColWidth(colDepositInclusive, 900)
			
			gridItem.Col = colDepositTotalExclusive
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colDepositTotalExclusive, "Total Selling") '"Total Dep Excl"
			gridItem.set_ColAlignment(colDepositTotalExclusive, 7)
			gridItem.set_ColWidth(colDepositTotalExclusive, 900)
			
			gridItem.Col = colDepositTotalInclusive
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colDepositTotalInclusive, "GP%") '"Total Dep Incl"
			gridItem.set_ColAlignment(colDepositTotalInclusive, 7)
			gridItem.set_ColWidth(colDepositTotalInclusive, 900)
			
			gridItem.Col = colFractions
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colFractions, "")
			gridItem.set_ColAlignment(colFractions, 7)
			gridItem.set_ColWidth(colFractions, 1)
			
		End With
		loading = False
	End Sub
	
	Private Sub cmdBack_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBack.Click
		cmdBack.Focus()
		System.Windows.Forms.Application.DoEvents()
		If orderType = 1 Then
			orderType = 0
			loadItem(False)
			frmGRVitemFnV_Resize(Me, New System.EventArgs())
		Else
			Me.Close()
		End If
		
	End Sub
	
	Private Sub cmdEditPackSize_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEditPackSize.Click
		Dim id As Integer
		Dim x As Short
		Dim sql As String
		Dim lString As String
		If gridItem.row Then
			lString = InputBox("Enter the Pack Size Volume for item '" & gridItem.get_TextMatrix(gridItem.row, colName) & "'.", "Enter Pack Size Volume", FormatNumber(CDbl(txtPackSize.Text) * 100, 0, TriState.False, TriState.False, TriState.False))
			If IsNumeric(lString) Then
				If InStr(lString, ".") Then 
				Else 
					lString = CStr(CDbl(lString) / 100)
				End If
				id = gridItem.get_RowData(gridItem.row)
				cnnDB.Execute("UPDATE GRVItem SET GRVItem.GRVItem_PackSizeVol = " & lString & " WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_StockItemID)=" & gridItem.get_RowData(gridItem.row) & ") AND ((GRVItem.GRVItem_Return)=" & orderType & "));")
				txtPackSize.Text = FormatNumber(lString, 2)
				'getOrder
				'X = findItem(id)
				'If X Then
				'    gridItem.row = X
				'    gridItem.Col = colQuantity
				'    _txtEdit_0.Visible = True
				'    gridItem_EnterCell
				'End If
			End If
		End If
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		bolFNVegGRV = False
		cmdExit.Focus()
		System.Windows.Forms.Application.DoEvents()
		Me.Close()
		System.Windows.Forms.Application.DoEvents()
		frmGRV.Close()
	End Sub
	
	Private Sub doTotals()
		Dim x As Short
		lblContentExclusive.Tag = 0
		lblContentInclusive.Tag = 0
		lblDepositExclusive.Tag = 0
		lblDepositInclusive.Tag = 0
		lblQuantity.Tag = 0
		lblBrokenPack.Tag = 0
        For x = 1 To gridItem.RowCount - 1
            lblContentExclusive.Tag = CDbl(lblContentExclusive.Tag) + CDec(gridItem.get_TextMatrix(x, colContentTotalExclusive))
            lblContentInclusive.Tag = CDbl(lblContentInclusive.Tag) + CDec(gridItem.get_TextMatrix(x, colContentTotalInclusive))
            'lblDepositExclusive.Tag = lblDepositExclusive.Tag + CCur(gridItem.TextMatrix(x, colDepositTotalExclusive))
            lblDepositInclusive.Tag = CDbl(lblDepositInclusive.Tag) + CDec(gridItem.get_TextMatrix(x, colDepositTotalExclusive))
            If gridItem.get_TextMatrix(x, colBrokenPack) = "" Then
                'lblQuantity.Tag = lblQuantity.Tag + CInt(gridItem.TextMatrix(x, colQuantity))
                lblQuantity.Tag = CDbl(lblQuantity.Tag) + CDec(gridItem.get_TextMatrix(x, colQuantity))
            Else
                'lblBrokenPack.Tag = lblBrokenPack.Tag + CInt(gridItem.TextMatrix(x, colQuantity))
                lblBrokenPack.Tag = CDbl(lblBrokenPack.Tag) + CDec(gridItem.get_TextMatrix(x, colQuantity))
            End If

        Next x
		lblContentExclusive.Text = FormatNumber(lblContentExclusive.Tag, 2)
		lblContentInclusive.Text = FormatNumber(lblContentInclusive.Tag, 2)
		
		lblDepositInclusive.Text = FormatNumber(lblDepositInclusive.Tag, 2)
		If CDec(lblDepositInclusive.Tag) > 0 And CDec(lblDepositInclusive.Tag) > 0 Then
			lblDepositExclusive.Text = FormatNumber(100 - ((CDec(lblContentExclusive.Tag) / CDec(lblDepositInclusive.Tag)) * 100), 2)
		End If
		'lblTotalExclusive.Caption = FormatNumber(CCur(lblContentExclusive.Tag) + CCur(lblDepositExclusive.Tag), 2)
		'lblTotalInclusive.Caption = FormatNumber(CCur(lblContentInclusive.Tag) + CCur(lblDepositInclusive.Tag), 2)
		lblTotalExclusive.Text = FormatNumber(CDec(lblContentExclusive.Tag), 2)
		lblTotalInclusive.Text = FormatNumber(CDec(lblContentInclusive.Tag), 2)
		
		
		lblQuantity.Text = FormatNumber(lblQuantity.Tag, 0)
		lblBrokenPack.Text = FormatNumber(lblBrokenPack.Tag, 0)
	End Sub
	
	Private Sub cmdNew_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNew.Click
        bGRVNewItemBarcode = True
        Dim form As New frmStockItemNew
        form.Show()
		bGRVNewItemBarcode = False
	End Sub
	
	Private Sub cmdNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNext.Click
		cmdNext.Focus()
		System.Windows.Forms.Application.DoEvents()
		
		'go direct to summary
		frmGRVSummaryFnV.loadSummary()
		Exit Sub
		If orderType = 0 Then
			loadItem(True)
			frmGRVitemFnV_Resize(Me, New System.EventArgs())
			
        Else
            Dim rs As ADODB.Recordset
            rs = getRS("SELECT SupplierDepositLnk.SupplierDepositLnk_SupplierID From SupplierDepositLnk WHERE (((SupplierDepositLnk.SupplierDepositLnk_SupplierID)=" & frmGRV.adoPrimaryRS.Fields("SupplierID").Value & "));")
            If rs.BOF Or rs.EOF Then
                frmGRVSummary.loadSummary()

            Else
                frmGRVDeposit.loadDeposits(0)
            End If
		End If
	End Sub
	
	Private Sub cmdPriceBOM_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPriceBOM.Click
		If gridItem.row Then
			frmStockMultiPrice.changePrice(gridItem.get_RowData(gridItem.row))
		End If
	End Sub
	
	Private Sub cmdPrintOrder_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrintOrder.Click
		report_PurchaseOrder(frmGRV.adoPrimaryRS.Fields("PurchaseOrderID").Value)
		Dim oText As System.Windows.Forms.TextBox
		For	Each oText In txtEdit
			If oText.Visible Then oText.Focus()
			Exit For
		Next oText
	End Sub
	
	Private Sub cmdQuick_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdQuick.Click
		If gridItem.row Then
			quickEdit()
		End If
	End Sub
	
	Private Sub cmdStockItem_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStockItem.Click
        Dim id As Short
		Dim sql As String
		Dim x As Short
		id = gridItem.get_RowData(gridItem.row)
		If gStockItems Then
			gStockItems = False
			cmdStockItem.Text = "All Stoc&k Items"
		Else
			gStockItems = True
			cmdStockItem.Text = "Supplier Stoc&k Items"
			
		End If
		getNamespace()
		getOrder()
		x = findItem(id)
		If x Then
			gridItem.row = x
			gridItem.Col = colQuantity
            _txtEdit_0.Visible = True
			gridItem_EnterCell(gridItem, New System.EventArgs())
		End If
	End Sub
	
	Private Sub cmdSort_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSort.Click
		Dim x As Short
        Dim id As Short
		id = gridItem.get_RowData(gridItem.row)
		If gFieldDisplayDefault = "BrandItemSupplier_Name" Then
			If gFieldDisplay = "StockItem_Name" Then
				gFieldDisplay = "BrandItemSupplier_Name"
				gFieldOrder = gFieldOrderDefault
			Else
				gFieldDisplay = "StockItem_Name"
				gFieldOrder = "StockItem_Name"
			End If
		End If
		getNamespace()
		getOrder()
		x = findItem(id)
		If x Then
			gridItem.row = x
			gridItem.Col = colQuantity
            _txtEdit_0.Visible = True
			gridItem_EnterCell(gridItem, New System.EventArgs())
		End If
	End Sub
	
	Private Sub setupGRV(Optional ByRef lDefaultType As String = "")
		
		'Dim lNode As IXMLDOMNode
		Dim x As Short
		Dim rs As ADODB.Recordset
		Dim ltype As String
		If lDefaultType = "" Then
			rs = getRS("SELECT GRVTemplate.GRVTemplate_Name FROM Supplier INNER JOIN GRVTemplate ON Supplier.Supplier_GRVtype = GRVTemplate.GRVTemplate_Name WHERE (((Supplier.SupplierID)=" & frmGRV.adoPrimaryRS.Fields("SupplierID").Value & "));")
			If rs.BOF Or rs.EOF Then
				rs = getRS("SELECT Count(SupplierDepositLnk.SupplierDepositLnk_SupplierID) AS CountOfSupplierDepositLnk_SupplierID From SupplierDepositLnk WHERE (((SupplierDepositLnk.SupplierDepositLnk_SupplierID)=" & frmGRV.adoPrimaryRS.Fields("SupplierID").Value & "));")
				If rs.Fields(0).Value Then
					ltype = "DefaultDeposit"
				Else
					ltype = "Default"
				End If
				
			Else
				ltype = rs.Fields("GRVTemplate_Name").Value
			End If
			If rs.State Then rs.Close()
		Else
			ltype = lDefaultType
		End If
		rs = getRS("SELECT * FROM GRVTemplate WHERE GRVTemplate_Name = '" & Replace(ltype, "'", "''") & "'")
		If rs.RecordCount Then
		Else
			ltype = "Default"
			rs = getRS("SELECT * FROM GRVTemplate WHERE GRVTemplate_Name = '" & Replace(ltype, "'", "''") & "'")
		End If
		gQuickKey = rs.Fields("GRVTemplate_LaunchQuickKey").Value
		activePrice = rs.Fields("GRVTemplate_PriceType").Value
		If rs.Fields("GRVTemplate_SortKey").Value = "brand" Then
			gFieldDisplay = "BrandItemSupplier_Name"
			If rs.Fields("GRVTemplate_SortOrder").Value = "code" Then
				gFieldOrder = "BrandItemSupplier_Code"
			Else
				gFieldOrder = "StockItem_Name"
			End If
		Else
			gFieldDisplay = "StockItem_Name"
			gFieldOrder = "StockItem_Name"
		End If
		If rs.Fields("GRVTemplate_SortType").Value Then
			gGRVFieldOrder = "GRVItem_Date"
		Else
			gGRVFieldOrder = ""
		End If
		
		gFieldOrderDefault = gFieldOrder
		gFieldDisplayDefault = gFieldDisplay
		rs = getRS("SELECT theJoin.GRVTemplateList_Code, IIf([GRVTemplateItem_Order] Is Null,99,[GRVTemplateItem_Order]) AS orderList, IIf([GRVTemplateItem_Order] Is Null,False,True) AS visible FROM GRVTemplateItem RIGHT JOIN [SELECT GRVTemplate.GRVTemplateID, GRVTemplate.GRVTemplate_Name, GRVTemplateList.GRVTemplateListID, GRVTemplateList.GRVTemplateList_Code From GRVTemplate, GRVTemplateList]. AS theJoin ON (GRVTemplateItem.GRVTemplateItem_GRVTemplateID = theJoin.GRVTemplateID) AND (GRVTemplateItem.GRVTemplateItem_GRVTemplateListID = theJoin.GRVTemplateListID) Where (((theJoin.GRVTemplate_Name) = '" & Replace(ltype, "'", "''") & "')) ORDER BY IIf([GRVTemplateItem_Order] Is Null,99,[GRVTemplateItem_Order]);")
		
		x = -1
		Do Until rs.EOF
			x = x + 1
			Debug.Print(rs.Fields("GRVTemplateList_Code").Value)
			Select Case LCase(rs.Fields("GRVTemplateList_Code").Value)
				Case "colcode" : colCode = x
				Case "colname" : colName = x
				Case "colonorder" : colOnOrder = x
				Case "colquantity" : colQuantity = x
				Case "colbrokenpack" : colBrokenPack = x
				Case "colpacksize" : colPackSize = x
				Case "colcontentexclusive" : colContentExclusive = x
				Case "colcontentinclusive" : colContentInclusive = x
				Case "colcontenttotalexclusive" : colContentTotalExclusive = x
				Case "colprice" : colPrice = x
				Case "colcontenttotalinclusive" : colContentTotalInclusive = x
				Case "coldepositexclusive" : colDepositExclusive = x
				Case "coldepositinclusive" : colDepositInclusive = x
				Case "coldeposittotalexclusive" : colDepositTotalExclusive = x
				Case "coldeposittotalinclusive" : colDepositTotalInclusive = x
				Case "coldiscountline" : colDiscountLine = x
				Case "coldiscount" : colDiscount = x
				Case "coldiscountpercentage" : colDiscountPercentage = x
				Case "coltotalexclusive" : colTotalExclusive = x
				Case "coltotalinclusive" : colTotalInclusive = x
				Case "colexclusive" : colExclusive = x
				Case "colinclusive" : colInclusive = x
				Case "colvat" : colVAT = x
				Case "colprice" : colPrice = x
			End Select
			rs.moveNext()
		Loop 
		colFractions = 23
		setup()
		
		rs.MoveFirst()
		Do Until rs.EOF
			If rs.Fields("visible").Value Then
			Else
				Select Case LCase(rs.Fields("GRVTemplateList_Code").Value)
					
					Case "colcode" : gridItem.set_ColWidth(colCode, 0)
					Case "colonorder" : gridItem.set_ColWidth(colOnOrder, 0)
					Case "colquantity" : gridItem.set_ColWidth(colQuantity, 0)
					Case "colbrokenpack" : gridItem.set_ColWidth(colBrokenPack, 0)
					Case "colpacksize" : gridItem.set_ColWidth(colPackSize, 0)
					Case "colcontentexclusive" : gridItem.set_ColWidth(colContentExclusive, 0)
					Case "colcontentinclusive" : gridItem.set_ColWidth(colContentInclusive, 0)
					Case "colcontenttotalexclusive" : gridItem.set_ColWidth(colContentTotalExclusive, 0)
					Case "colcontenttotalinclusive" : gridItem.set_ColWidth(colContentTotalInclusive, 0)
					Case "coldepositexclusive" : gridItem.set_ColWidth(colDepositExclusive, 0)
					Case "coldepositinclusive" : gridItem.set_ColWidth(colDepositInclusive, 0)
						'Case "coldeposittotalexclusive": gridItem.ColWidth(colDepositTotalExclusive) = 0
						'Case "coldeposittotalinclusive": gridItem.ColWidth(colDepositTotalInclusive) = 0
					Case "coldiscountline" : gridItem.set_ColWidth(colDiscountLine, 0)
					Case "coldiscount" : gridItem.set_ColWidth(colDiscount, 0)
					Case "coldiscountpercentage" : gridItem.set_ColWidth(colDiscountPercentage, 0)
					Case "coltotalexclusive" : gridItem.set_ColWidth(colTotalExclusive, 0)
					Case "coltotalinclusive" : gridItem.set_ColWidth(colTotalInclusive, 0)
					Case "colexclusive" : gridItem.set_ColWidth(colExclusive, 0)
					Case "colinclusive" : gridItem.set_ColWidth(colInclusive, 0)
					Case "colvat" : gridItem.set_ColWidth(colVAT, 0)
					Case "colprice" : gridItem.set_ColWidth(colPrice, 0)
				End Select
			End If
			rs.moveNext()
		Loop 
		lblContentExclusive.Visible = CBool(gridItem.get_ColWidth(colContentTotalExclusive))
		lblContentInclusive.Visible = CBool(gridItem.get_ColWidth(colContentTotalInclusive))
		lblDepositExclusive.Visible = CBool(gridItem.get_ColWidth(colDepositTotalExclusive))
		lblDepositInclusive.Visible = CBool(gridItem.get_ColWidth(colDepositTotalInclusive))
		lblTotalExclusive.Visible = CBool(gridItem.get_ColWidth(colTotalExclusive))
		lblTotalInclusive.Visible = CBool(gridItem.get_ColWidth(colTotalInclusive))
		lblTotalInclusive.Visible = CBool(gridItem.get_ColWidth(colPrice))
        _lblTotal_0.Visible = lblContentExclusive.Visible
        _lblTotal_1.Visible = lblContentInclusive.Visible
        _lblTotal_2.Visible = lblDepositExclusive.Visible
        _lblTotal_3.Visible = lblDepositInclusive.Visible
        _lblTotal_4.Visible = lblTotalExclusive.Visible
        _lblTotal_5.Visible = lblTotalInclusive.Visible
		
		'Check for person security to not show Order QTY
		If 8192 And frmMenu.gBit Then
		Else
			gridItem.set_ColWidth(colOnOrder, 0)
		End If
		'Check for person security to not show Order QTY
		
		frmGRVitemFnV_Resize(Me, New System.EventArgs())
	End Sub
	
	Private Sub quickEdit()
		
        Dim id, x As Short
		frmGRVItemQuick.ShowDialog()
		If gridItem.get_TextMatrix(gridItem.row, colCode) = "RELOAD" Then
			id = gridItem.get_RowData(gridItem.row)
			getOrder()
			x = findItem(id)
			If x Then
				gridItem.row = x
				gridItem.Col = colQuantity
                _txtEdit_0.Visible = True
				gridItem_EnterCell(gridItem, New System.EventArgs())
			End If
			txtSearch.Focus()
		End If
	End Sub
	
	Public Sub loadItem(ByRef returns As Boolean)
        Dim oText As New TextBox
		
		'ResizeForm frmGRVitem, frmGRVitem.Width, frmGRVitem.Height, 2
		
		If returns Then
			orderType = 1
		Else
			orderType = 0
		End If
		
		loading = True
		setupGRV()
		
		getNamespace()
		getOrder()
		
        If gridItem.RowCount Then
            loading = True
            gridItem.Col = 0
            gridItem.row = 0
            loading = False
            For Each oText In txtEdit
                oText.Visible = False
            Next oText
            If gridItem.RowCount > 1 Then
                gridItem.Col = colQuantity
                gridItem.row = 1
                _txtEdit_0.Visible = True
            Else
            End If
        End If
		loading = False
		
		cmdSort.Left = 0
		cmdStockItem.Left = 0
		If bolAirTimeGRV = True Then
			tmrAutoGRV.Enabled = True
		End If
		
		rsPackSize = getRS("SELECT Company_FNVegShowVol FROM Company;")
		bFNVegPackSize = rsPackSize.Fields("Company_FNVegShowVol").Value
		
		'update TotalQtyKG
		cnnDB.Execute("UPDATE (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN PackSize ON StockItem.StockItem_PackSizeID = PackSize.PackSizeID SET GRVItem_PackSizeVol=IIf(GRVItem_PackSizeVol=0,PackSize.PackSize_Volume,GRVItem_PackSizeVol) WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & "));")
		
		loadLanguage()
		If Me.Visible Then 
		Else 
			Me.ShowDialog()
		End If
		
	End Sub
	Private Sub cmdVAT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdVAT.Click
        Dim id As Short
		Dim x As Short
		Dim sql As String
		Dim lString As String
		If gridItem.row Then
			lString = InputBox("Enter the VAT percentage for item '" & gridItem.get_TextMatrix(gridItem.row, colName) & "'.", "Enter VAT", FormatNumber(CDbl(gridItem.get_TextMatrix(gridItem.row, colVAT)) * 100, 0, TriState.False, TriState.False, TriState.False))
			If IsNumeric(lString) Then
				If InStr(lString, ".") Then 
				Else 
					lString = CStr(CDbl(lString) / 100)
				End If
				id = gridItem.get_RowData(gridItem.row)
				cnnDB.Execute("UPDATE GRVItem SET GRVItem.GRVItem_VatRate = " & lString & " WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_StockItemID)=" & gridItem.get_RowData(gridItem.row) & ") AND ((GRVItem.GRVItem_Return)=" & orderType & "));")
				
				getOrder()
				x = findItem(id)
				If x Then
					gridItem.row = x
					gridItem.Col = colQuantity
                    _txtEdit_0.Visible = True
					gridItem_EnterCell(gridItem, New System.EventArgs())
				End If
			End If
		End If
		
	End Sub
	
	Private Sub frmGRVitemFnV_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim lString As String
		If Shift = 7 And KeyCode = 80 Then
			lString = InputBox("GRV Template Name", "TEMPLATE")
			If lString <> "" Then
				setup()
				setupGRV(lString)
				getOrder()
			End If
		End If
	End Sub
	
	Private Sub frmGRVitemFnV_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub frmGRVitemFnV_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        txtEdit.AddRange(New TextBox() {_txtEdit_0, _txtEdit_1, _txtEdit_2})
        Dim tb As New TextBox
        For Each tb In txtEdit
            AddHandler tb.Enter, AddressOf txtEdit_Enter
            AddHandler tb.KeyPress, AddressOf txtEdit_KeyPress
            AddHandler tb.Leave, AddressOf txtEdit_Leave
            AddHandler tb.TextChanged, AddressOf txtEdit_TextChanged
        Next
        '*frmstocklist must not be displayed when you access frmstockitem from  frmGRVitem and exit stockitem,so that's what the code does
		Holdquantity = 0
		frmGRVitem.lblQuantity.Tag = 0
		
		'BO Security permission check
		If 1 And frmMenu.gBit Then 
		Else 
			cmdEdit.Enabled = False
		End If
		If 1 And frmMenu.gBit Then 
		Else 
			cmdNew.Enabled = False
		End If
		'*
	End Sub
	
	'UPGRADE_WARNING: Event frmGRVitemFnV.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmGRVitemFnV_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		Dim x As Short
		Dim lWidth As Short
		Dim lTop As Integer
		lTop = 120
		If lblContentExclusive.Visible Then
            lblContentExclusive.Top = twipsToPixels(lTop, False)
            _lblTotal_0.Top = twipsToPixels(lTop, False)
            lTop = lTop + pixelToTwips(lblContentExclusive.Height, False) + 30
		End If
		If lblContentInclusive.Visible Then
            lblContentInclusive.Top = twipsToPixels(lTop, False)
            _lblTotal_1.Top = twipsToPixels(lTop, False)
            lTop = lTop + pixelToTwips(lblContentInclusive.Height, False) + 30
		End If
		If lblDepositExclusive.Visible Then
            lblDepositExclusive.Top = twipsToPixels(lTop, False)
            _lblTotal_2.Top = twipsToPixels(lTop, False)
            lTop = lTop + pixelToTwips(lblDepositExclusive.Height, False) + 30
		End If
		If lblDepositInclusive.Visible Then
            lblDepositInclusive.Top = twipsToPixels(lTop, False)
            _lblTotal_3.Top = twipsToPixels(lTop, False)
            lTop = lTop + pixelToTwips(lblDepositInclusive.Height, False) + 30
		End If
		If lblTotalExclusive.Visible Then
            lblTotalExclusive.Top = twipsToPixels(lTop, False)
            _lblTotal_4.Top = twipsToPixels(lTop, False)
            lTop = lTop + pixelToTwips(lblTotalExclusive.Height, False) + 30
		End If
		If lblTotalInclusive.Visible Then
            lblTotalInclusive.Top = twipsToPixels(lTop, False)
            _lblTotal_5.Top = twipsToPixels(lTop, False)
            lTop = lTop + pixelToTwips(lblTotalInclusive.Height, False) + 30
		End If
        frmTotals.Height = twipsToPixels(lTop + 30, False)
		
        frmTotals.Top = twipsToPixels(pixelToTwips(ClientRectangle.Height, False) - _
                                     pixelToTwips(frmTotals.Height, False), False)
        frmTotals.Left = twipsToPixels(pixelToTwips(ClientRectangle.Width, True) - _
                                      pixelToTwips(frmTotals.Width, True), True)
        lblReturns.Top = twipsToPixels(pixelToTwips(frmTotals.Top, False) + _
                                      (pixelToTwips(frmTotals.Height, False) - _
                                       pixelToTwips(lblReturns.Height, False)) / 2, False)
        lblReturns.Left = twipsToPixels(pixelToTwips(frmTotals.Left, True) - _
                                       pixelToTwips(lblReturns.Width, True) - 100, True)
		lblReturns.Visible = orderType
		
		frmFNVeg.Top = frmTotals.Top
        frmFNVeg.Left = twipsToPixels(pixelToTwips(frmTotals.Left, True) - _
                                     pixelToTwips(frmFNVeg.Width, True) - 200, True)
		If bFNVegPackSize And orderType = 0 Then frmFNVeg.Visible = True Else frmFNVeg.Visible = False
		
        lstWorkspace.Height = twipsToPixels(pixelToTwips(ClientRectangle.Height, False) - _
                                           pixelToTwips(lstWorkspace.Top, False), False)
        gridItem.Height = twipsToPixels(pixelToTwips(ClientRectangle.Height, False) - _
                                       pixelToTwips(gridItem.Top, False) - _
                                       pixelToTwips(frmTotals.Height, False), False)
        gridItem.Width = twipsToPixels(pixelToTwips(ClientRectangle.Width, True) - _
                                      pixelToTwips(gridItem.Left, True), True)
        lWidth = pixelToTwips(gridItem.Width, True) - 450
        For x = 0 To gridItem.Col - 1
            lWidth = lWidth - gridItem.get_ColWidth(x)
        Next
		lWidth = lWidth + gridItem.get_ColWidth(colName)
		If lWidth > 200 Then
			gridItem.set_ColWidth(colName, lWidth)
		Else
			gridItem.set_ColWidth(colName, 2000)
		End If
		gridItem_EnterCell(gridItem, New System.EventArgs())
	End Sub
	
	Private Sub frmGRVitemFnV_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		On Error Resume Next
		'*frmstocklist must not be displayed when you access frmstockitem from  frmGRVitem and exit stockitem,so that's what the code does
		frmGRVitem.lblQuantity.Tag = -1
		Holdquantity = CInt(frmGRVitem.lblQuantity.Tag)
		frmGRVitem.lblQuantity.Tag = 0
		'*
	End Sub
	
    Private Sub gridItem_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles gridItem.CellClick
        gridItem.set_ColWidth(23, 1)
    End Sub
	
    Private Sub lstWorkspace_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles lstWorkspace.DoubleClick
        Dim sql As String
        Dim rsCQty As ADODB.Recordset
        Dim rsSql As String
        Dim lDeposit As Decimal
        Dim x As Short
        If lstWorkspace.SelectedIndex <> -1 Then


            update_Renamed()
            'UPGRADE_WARNING: Couldn't resolve default property of object findItem(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            x = findItem(CShort(lstWorkspace.SelectedIndex))

            If x Then
                gridItem.row = x
            Else
                '            cnnDB.Execute "INSERT INTO GRVItem ( GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date ) SELECT " & frmGRV.adoPrimaryRS("GRVID") & " AS grvid, StockItem.StockItemID, " & orderType & " AS return, StockItem.StockItem_Name, '' AS code, StockItem.StockItem_OrderQuantity, 0, 0 AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date] FROM StockItem WHERE (((StockItem.StockItemID)=" & lstWorkspace.ItemData(lstWorkspace.ListIndex) & "));"
                '            cnnDB.Execute "UPDATE (((GRVItem INNER JOIN GRV ON GRVItem.GRVItem_GRVID = GRV.GRVID) INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN PurchaseOrder ON GRV.GRV_PurchaseOrderID = PurchaseOrder.PurchaseOrderID) INNER JOIN BrandItemSupplier ON (BrandItemSupplier.BrandItemSupplier_SupplierID = PurchaseOrder.PurchaseOrder_SupplierID) AND (StockItem.StockItem_BrandItemID = BrandItemSupplier.BrandItemSupplier_BrandItemID) SET GRVItem.GRVItem_Name = [BrandItemSupplier]![BrandItemSupplier_Name], GRVItem.GRVItem_Code = [BrandItemSupplier]![BrandItemSupplier_Code] WHERE (((GRVItem.GRVItem_StockItemID)=" & lstWorkspace.ItemData(lstWorkspace.ListIndex) & ") AND ((GRVItem.GRVItem_Return)=" & orderType & ") AND ((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & "));"
                On Error Resume Next

                sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_Price ) SELECT " & Me.gridItem.RowCount & ", " & frmGRV.adoPrimaryRS.Fields("GRVID").Value & " AS grvid, StockItem.StockItemID, " & orderType & " AS return, StockItem.StockItem_Name, '' AS code, StockItem.StockItem_Quantity, StockItem.StockItem_OrderQuantity, 0 AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
                sql = sql & " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & CLng(lstWorkspace.SelectedIndex) & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));"

                cnnDB.Execute(sql)

                sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_Price ) "
                sql = sql & "SELECT " & Me.gridItem.RowCount & ", " & frmGRV.adoPrimaryRS.Fields("GRVID").Value & " AS grvid, StockItem.StockItemID, " & orderType & " AS return, StockItem.StockItem_Name, '' AS code, StockItem.StockItem_Quantity, StockItem.StockItem_OrderQuantity, 0 AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 FROM StockItem WHERE (((StockItem.StockItemID)=" & CLng(lstWorkspace.SelectedIndex) & "));"

                cnnDB.Execute(sql)

                sql = "UPDATE ((Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_Quantity = StockItem.StockItem_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)) INNER JOIN GRVItem ON (GRVItem.GRVItem_StockItemID = StockItem.StockItemID) AND (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize) SET GRVItem.GRVItem_StockItemQuantity = [CatalogueChannelLnk_Quantity], GRVItem.GRVItem_Price = [CatalogueChannelLnk_Price] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((StockItem.StockItemID)=" & CLng(lstWorkspace.SelectedIndex) & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((GRVItem.GRVItem_Return)=" & orderType & ") AND ((StockItem.StockItem_PackSizeID)=[StockItem_Quantity]));"
                cnnDB.Execute(sql)

                sql = "UPDATE (StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID SET GRVItem.GRVItem_VatRate = [Vat_Amount] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=" & orderType & ") AND ((GRVItem.GRVItem_StockItemID)=" & CLng(lstWorkspace.SelectedIndex) & "));"

                cnnDB.Execute(sql)

                'update selling price
                sql = "UPDATE GRVItem INNER JOIN PriceChannelLnk ON PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID SET GRVItem.GRVItem_Price = PriceChannelLnk.PriceChannelLnk_Price WHERE ((PriceChannelLnk.PriceChannelLnk_Quantity=1) AND (PriceChannelLnk.PriceChannelLnk_ChannelID=1) AND (GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & " AND GRVItem.GRVItem_Line =" & Me.gridItem.RowCount & ");"
                cnnDB.Execute(sql)

                'update TotalQtyKG
                cnnDB.Execute("UPDATE (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN PackSize ON StockItem.StockItem_PackSizeID = PackSize.PackSizeID SET GRVItem_PackSizeVol=IIf(GRVItem_PackSizeVol=0,PackSize.PackSize_Volume,GRVItem_PackSizeVol) WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & "));")

                getOrder()
                System.Windows.Forms.Application.DoEvents()
                'UPGRADE_WARNING: Couldn't resolve default property of object findItem(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                x = findItem(CLng(lstWorkspace.SelectedIndex))
                If x Then
                    gridItem.row = x
                    gridItem.Col = colQuantity
                    _txtEdit_0.Visible = True
                    gridItem_EnterCell(gridItem, New System.EventArgs())
                    System.Windows.Forms.Application.DoEvents()
                    If gQuickKey Then quickEdit()
                End If
            End If
        End If



    End Sub
    Private Function findItem(ByRef id As String) As Integer
        Dim x As Integer
        With gridItem

            For x = 1 To .RowCount - 1

                If .get_RowData(x) = id Then
                    findItem = x
                    Exit For
                Else
                    findItem = 0
                End If

            Next x

        End With
        Return x
    End Function
	
	Private Sub lstWorkspace_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles lstWorkspace.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Then
			lstWorkspace_DoubleClick(lstWorkspace, New System.EventArgs())
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub lstWorkspace_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles lstWorkspace.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Select Case KeyCode
			Case 38
				If lstWorkspace.SelectedIndex = 0 Then
					Me.txtSearch.Focus()
				End If
		End Select
		
	End Sub
	
	'UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub update_Renamed()
		If loading Then Exit Sub
		'    Dim lNode As IXMLDOMNode
		Dim x As Short
		Dim sql As String
		Dim oText As System.Windows.Forms.TextBox
		Dim lUpdate As Boolean
		For	Each oText In txtEdit
			If oText.Text = "" Then oText.Text = "0"
			If oText.Text <> oText.Tag Then
				lUpdate = True
			End If
		Next oText
		Dim rsStockItem_PriceSetID As ADODB.Recordset
		Dim rs As ADODB.Recordset
		If lUpdate Then
			Select Case gridItem.Col
				Case colQuantity
					System.Windows.Forms.Application.DoEvents()
					cnnDB.Execute("UPDATE GRVItem SET GRVItem_Quantity = " & _txtEdit_0.Text & " Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") And (GRVItem_StockItemID = " & gridItem.get_RowData(gridItem.row) & ") And (GRVItem_Return = " & orderType & ")")
					gridItem.set_TextMatrix(gridItem.row, colQuantity, _txtEdit_0.Text)
					_txtEdit_0.Tag = _txtEdit_0.Text
				Case colContentExclusive
					'If oText.Text <> oText.Tag Then
					'check if stockitem is part of priceset
					rsStockItem_PriceSetID = getRS("SELECT * FROM StockItem WHERE StockItemID = " & gridItem.get_RowData(gridItem.row))
					If rsStockItem_PriceSetID.Fields("StockItem_PriceSetID").Value > 0 Then 'rsStockItem("StockItem_PriceSetID")
						
						'check if stockitem is child or parent
						rs = getRS("SELECT * FROM PriceSet WHERE PriceSetID = " & rsStockItem_PriceSetID.Fields("StockItem_PriceSetID").Value)
						If rsStockItem_PriceSetID.Fields("StockItemID").Value = rs.Fields("PriceSet_StockItemID").Value Then
							'parent
							MsgBox("This is Primary Stock Item of Pricing Set, changing of price will effect on all Child Stock Item those are part of this set.", MsgBoxStyle.Exclamation)
							System.Windows.Forms.Application.DoEvents()
							'cnnDB.Execute "UPDATE GRVItem SET GRVItem_ContentCost = " & (CCur(_txtEdit_1.Text) / 100) & " Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS("GRVID") & ") And (GRVItem_StockItemID = " & gridItem.RowData(gridItem.row) & ") And (GRVItem_Return = " & orderType & ")"
							If gridItem.get_TextMatrix(gridItem.row, colBrokenPack) = "X" Then
                                cnnDB.Execute("UPDATE GRVItem SET GRVItem_ContentCost = " & (CDec(CDbl(_txtEdit_1.Text) * rsStockItem_PriceSetID.Fields("StockItem_Quantity").Value) / 100) & " Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") And (GRVItem_StockItemID = " & gridItem.get_RowData(gridItem.row) & ") And (GRVItem_Return = " & orderType & ")")
							Else
                                cnnDB.Execute("UPDATE GRVItem SET GRVItem_ContentCost = " & (CDec(_txtEdit_1.Text) / 100) & " Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") And (GRVItem_StockItemID = " & gridItem.get_RowData(gridItem.row) & ") And (GRVItem_Return = " & orderType & ")")
							End If
                            gridItem.set_TextMatrix(gridItem.row, colContentExclusive, FormatNumber(CDec(_txtEdit_1.Text) / 100, 2))
                            _txtEdit_1.Tag = _txtEdit_1.Text
						Else
							'child
							'ParentPriceID = rs("PriceSet_StockItemID")
							'If cmdUndoFocus = False Then
							If MsgBox("This is Child Stock Item of Pricing Set, changing of price of this Item will effect on Primary Stock Item and all Child Stock Item those are part of this set. " & vbCrLf & "Do you want to change ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
								'ChildPriceChang = False
								'ParentPriceChang = True
								System.Windows.Forms.Application.DoEvents()
								'cnnDB.Execute "UPDATE GRVItem SET GRVItem_ContentCost = " & (CCur(_txtEdit_1.Text) / 100) & " Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS("GRVID") & ") And (GRVItem_StockItemID = " & gridItem.RowData(gridItem.row) & ") And (GRVItem_Return = " & orderType & ")"
								If gridItem.get_TextMatrix(gridItem.row, colBrokenPack) = "X" Then
                                    cnnDB.Execute("UPDATE GRVItem SET GRVItem_ContentCost = " & (CDec(CDbl(_txtEdit_1.Text) * rsStockItem_PriceSetID.Fields("StockItem_Quantity").Value) / 100) & " Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") And (GRVItem_StockItemID = " & gridItem.get_RowData(gridItem.row) & ") And (GRVItem_Return = " & orderType & ")")
								Else
									cnnDB.Execute("UPDATE GRVItem SET GRVItem_ContentCost = " & (CDec(_txtEdit_1.Text) / 100) & " Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") And (GRVItem_StockItemID = " & gridItem.get_RowData(gridItem.row) & ") And (GRVItem_Return = " & orderType & ")")
								End If
                                gridItem.set_TextMatrix(gridItem.row, colContentExclusive, FormatNumber(CDec(_txtEdit_1.Text) / 100, 2))
                                _txtEdit_1.Tag = _txtEdit_1.Text
								
                                cnnDB.Execute("UPDATE StockItem SET StockItem_ListCost = " & (CDec(_txtEdit_1.Text) / 100) & " Where (StockItemID = " & rs.Fields("PriceSet_StockItemID").Value & ")")
							Else
								'ChildPriceChang = True
                                gridItem.set_TextMatrix(gridItem.row, colContentExclusive, FormatNumber(CDec(CDbl(_txtEdit_1.Tag) * 100), 2))
                                _txtEdit_1.Text = FormatNumber(CDec(CDbl(_txtEdit_1.Tag) * 100), 2) '_txtEdit_1.Tag
							End If
							'End If
						End If
						rs.Close()
						rsStockItem_PriceSetID.Close()
					Else
						System.Windows.Forms.Application.DoEvents()
						If gridItem.get_TextMatrix(gridItem.row, colBrokenPack) = "X" Then
                            cnnDB.Execute("UPDATE GRVItem SET GRVItem_ContentCost = " & (CDec(CDbl(_txtEdit_1.Text) * rsStockItem_PriceSetID.Fields("StockItem_Quantity").Value) / 100) & " Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") And (GRVItem_StockItemID = " & gridItem.get_RowData(gridItem.row) & ") And (GRVItem_Return = " & orderType & ")")
						Else
                            cnnDB.Execute("UPDATE GRVItem SET GRVItem_ContentCost = " & (CDec(_txtEdit_1.Text) / 100) & " Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") And (GRVItem_StockItemID = " & gridItem.get_RowData(gridItem.row) & ") And (GRVItem_Return = " & orderType & ")")
						End If
						
						gridItem.set_TextMatrix(gridItem.row, colContentExclusive, FormatNumber(CDec(_txtEdit_1.Text) / 100, 2))
                        _txtEdit_1.Tag = _txtEdit_1.Text
						rsStockItem_PriceSetID.Close()
					End If
					'End If
					
				Case colPrice
					System.Windows.Forms.Application.DoEvents()
                    cnnDB.Execute("UPDATE GRVItem SET GRVItem_Price = " & (CDec(_txtEdit_2.Text) / 100) & " Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") And (GRVItem_StockItemID = " & gridItem.get_RowData(gridItem.row) & ") And (GRVItem_Return = " & orderType & ")")
                    gridItem.set_TextMatrix(gridItem.row, colPrice, FormatNumber(CDec(_txtEdit_2.Text) / 100, 2))
                    _txtEdit_2.Tag = _txtEdit_2.Text
			End Select
		End If
	End Sub
	
	
	Private Sub cmdPack_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPack.Click
		Dim id As Integer
		Dim x As Short
		
		id = gridItem.get_RowData(gridItem.row)
		Dim sql As String
		If gridItem.row Then
			If CDbl(Me.gridItem.get_TextMatrix(gridItem.row, colPackSize)) = 1 Then
				cnnDB.Execute("UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_PackSize = [StockItem]![StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_StockItemID)=" & gridItem.get_RowData(gridItem.row) & ") AND ((GRVItem.GRVItem_Return)=" & orderType & "));")
			Else
				cnnDB.Execute("UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_PackSize = 1 WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_StockItemID)=" & gridItem.get_RowData(gridItem.row) & ") AND ((GRVItem.GRVItem_Return)=" & orderType & "));")
			End If
			getOrder()
			'UPGRADE_WARNING: Couldn't resolve default property of object findItem(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			x = findItem(id)
			If x Then
				gridItem.row = x
				gridItem.Col = colQuantity
                _txtEdit_0.Visible = True
				gridItem_EnterCell(gridItem, New System.EventArgs())
			End If
		End If
	End Sub
	
	Private Sub cmdDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDelete.Click
		Dim oText As System.Windows.Forms.TextBox
		If gridItem.row Then
			If MsgBox("Are you sure you wish to delete the order item '" & gridItem.get_TextMatrix(gridItem.row, colName) & "' from this order?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Delete Line Item") = MsgBoxResult.Yes Then
				cnnDB.Execute("DELETE FROM GRVItem Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") And (GRVItem_StockItemID = " & gridItem.get_RowData(gridItem.row) & ") And (GRVItem_Return = " & orderType & ")")
				getOrder()
                If gridItem.RowCount > 1 Then
                    gridItem.row = 1
                    gridItem_EnterCell(gridItem, New System.EventArgs())
                Else
                    For Each oText In txtEdit
                        oText.Visible = False
                    Next oText
                End If
			End If
		End If
	End Sub
	
	
	Private Sub cmdDiscount_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDiscount.Click
		Dim id As Integer
		Dim x As Short
        Dim lString As String
		Dim sql As String
		If gridItem.row Then
			id = gridItem.get_RowData(gridItem.row)
			If gridItem.get_ColWidth(colDiscount) Then
				lString = InputBox("Enter the Item Discount for item '" & gridItem.get_TextMatrix(gridItem.row, colName) & "'.", "Enter Discount", FormatNumber(CDbl(gridItem.get_TextMatrix(gridItem.row, colDiscount)) * 100, 0, TriState.False, TriState.False, TriState.False))
				If IsNumeric(lString) Then
					If InStr(lString, ".") Then
					Else
						lString = lString / 100
					End If
					doDiscount((CDec(lString)))
				End If
			ElseIf gridItem.get_ColWidth(colDiscountLine) Then 
				lString = InputBox("Enter the Line Discount for item '" & gridItem.get_TextMatrix(gridItem.row, colName) & "'.", "Enter Discount", Replace(gridItem.get_TextMatrix(gridItem.row, colDiscountLine), ",", ""))
				If IsNumeric(lString) Then
					If InStr(lString, ".") Then
					Else
						lString = lString / 100
					End If
					If CDec(gridItem.get_TextMatrix(gridItem.row, colQuantity)) Then
						doDiscount((CDec(lString) / CDec(gridItem.get_TextMatrix(gridItem.row, colQuantity))))
					Else
						doDiscount((0))
					End If
				End If
			ElseIf gridItem.get_ColWidth(colDiscountPercentage) Then 
				lString = InputBox("Enter the Percentage Discount for item '" & gridItem.get_TextMatrix(gridItem.row, colName) & "'.", "Enter Discount", Replace(gridItem.get_TextMatrix(gridItem.row, colDiscountPercentage), ",", ""))
				If IsNumeric(lString) Then
					If InStr(lString, ".") Then
					Else
						lString = lString / 100
					End If
					If CDec(gridItem.get_TextMatrix(gridItem.row, colQuantity)) Then
						doDiscount(CDec(gridItem.get_TextMatrix(gridItem.row, colContentExclusive)) * lString / 100)
					Else
						doDiscount((0))
					End If
				End If
			Else
				MsgBox("No Discount Given for this Supplier!", MsgBoxStyle.Exclamation, "GRV - " & lblSupplier.Text)
			End If
		End If
	End Sub
	
	
    Private Sub doDiscount(ByRef lDiscount As Decimal)
        Dim lString, sql As String
        Dim lDiscountActual As Decimal
        lDiscountActual = lDiscount
        '   If FormatNumber(lDiscount, 2) <> gridItem.TextMatrix(gridItem.row, colDiscount) Then
        If activePrice = 1 Or activePrice = 3 Then
            lDiscountActual = lDiscountActual / (1 + CDbl(gridItem.get_TextMatrix(gridItem.row, colVAT)) / 100)
        End If
        sql = "UPDATE GRVItem SET GRVItem_DiscountAmount = " & CDec(lDiscountActual) & " Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") And (GRVItem_StockItemID = " & gridItem.get_RowData(gridItem.row) & ") And (GRVItem_return = " & orderType & ")"
        cnnDB.Execute(sql)
        loading = True
        gridItem.set_TextMatrix(gridItem.row, colDiscount, FormatNumber(lDiscount, 4))
        displayLine((gridItem.row))
        gridItem.Col = colDiscount
        If CDec(gridItem.get_TextMatrix(gridItem.row, colDiscount)) = 0 Then
            gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(222, 222, 200))
        Else
            gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 200, 200))
        End If
        gridItem.Col = colDiscountLine
        If CDec(gridItem.get_TextMatrix(gridItem.row, colDiscount)) = 0 Then
            gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(222, 222, 200))
        Else
            gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 200, 200))
        End If
        gridItem.Col = colDiscountPercentage
        If CDec(gridItem.get_TextMatrix(gridItem.row, colDiscount)) = 0 Then
            gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(222, 222, 200))
        Else
            gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 200, 200))
        End If
        gridItem.set_TextMatrix(gridItem.row, colDiscountLine, FormatNumber(lDiscount * CDbl(gridItem.get_TextMatrix(gridItem.row, colQuantity)), 2))
        gridItem.set_TextMatrix(gridItem.row, colDiscountPercentage, FormatNumber(CDec(gridItem.get_TextMatrix(gridItem.row, colDiscount)) / CDec(gridItem.get_TextMatrix(gridItem.row, colContentExclusive)) * 100, 2))
        gridItem.Col = colQuantity
        loading = False

        doTotals()
        '    End If
        Dim oText As System.Windows.Forms.TextBox
        For Each oText In txtEdit
            If oText.Visible Then oText.Focus()
            Exit For
        Next oText
    End Sub
	
	Private Sub cmdPrice_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrice.Click
		Dim id As Integer
        Dim lString As String
		Dim sql As String
		Dim x As Short
		Dim oText As System.Windows.Forms.TextBox
		If gridItem.row Then
			id = gridItem.get_RowData(gridItem.row)
			Select Case activePrice
				Case 0
					lString = InputBox("Enter the New Price for item '" & gridItem.get_TextMatrix(gridItem.row, colName) & "'.", "Enter New Price", gridItem.get_TextMatrix(gridItem.row, colContentExclusive))
				Case 1
					lString = InputBox("Enter the New Price for item '" & gridItem.get_TextMatrix(gridItem.row, colName) & "'.", "Enter New Price", gridItem.get_TextMatrix(gridItem.row, colContentInclusive))
				Case 2
					lString = InputBox("Enter the New Price for item '" & gridItem.get_TextMatrix(gridItem.row, colName) & "'.", "Enter New Price", gridItem.get_TextMatrix(gridItem.row, colExclusive))
				Case 3
					lString = InputBox("Enter the New Price for item '" & gridItem.get_TextMatrix(gridItem.row, colName) & "'.", "Enter New Price", gridItem.get_TextMatrix(gridItem.row, colInclusive))
			End Select
			If IsNumeric(lString) Then
				If InStr(lString, ".") Then
				Else
					lString = lString / 100
				End If
				Select Case activePrice
					Case 0
					Case 1
						lString = CDec(lString) / (1 + CDec(gridItem.get_TextMatrix(gridItem.row, colVAT)) / 100)
					Case 2
						lString = CDec(lString) - CDec(gridItem.get_TextMatrix(gridItem.row, colDepositExclusive))
					Case 3
						lString = CDec(lString) / (1 + CDec(gridItem.get_TextMatrix(gridItem.row, colVAT)) / 100) - CDec(gridItem.get_TextMatrix(gridItem.row, colDepositExclusive))
						
				End Select
				If FormatNumber(lString, 2) <> gridItem.get_TextMatrix(gridItem.row, colContentExclusive) Then
					cnnDB.Execute("UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_ContentCost = [StockItem].[StockItem_Quantity]/[GRVItem].[GRVItem_PackSize]*" & CDec(lString) & " WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_StockItemID)=" & gridItem.get_RowData(gridItem.row) & ") AND ((GRVItem.GRVItem_Return)=" & orderType & "));")
					
					loading = True
					gridItem.set_TextMatrix(gridItem.row, colContentExclusive, FormatNumber(lString, 2))
					displayLine((gridItem.row))
					gridItem.Col = colContentExclusive
					gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 200, 200))
					gridItem.Col = colContentInclusive
					gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 200, 200))
					gridItem.Col = colExclusive
					gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 200, 200))
					gridItem.Col = colInclusive
					gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 200, 200))
					gridItem.Col = colQuantity
					loading = False
					doTotals()
				End If
				
				For	Each oText In txtEdit
					If oText.Visible Then oText.Focus()
					Exit For
				Next oText
				ElseIf lString = "" Then 
				cnnDB.Execute("UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_ContentCost = [StockItem]![StockItem_ListCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_StockItemID)=" & gridItem.get_RowData(gridItem.row) & ") AND ((GRVItem.GRVItem_Return)=" & orderType & "));")
				getOrder()
				x = findItem(id)
				If x Then
					gridItem.row = x
					gridItem.Col = colQuantity
                    _txtEdit_0.Visible = True
					gridItem_EnterCell(gridItem, New System.EventArgs())
				End If
			End If
		End If
	End Sub
	
	
	Private Sub cmdPrintGRV_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrintGRV.Click
		
		update_Renamed()
		report_GRV(frmGRV.adoPrimaryRS.Fields("GRVID").Value)
		Dim oText As System.Windows.Forms.TextBox
		For	Each oText In txtEdit
			If oText.Visible Then oText.Focus()
			Exit For
		Next oText
	End Sub
	
	
	Private Sub cmdEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEdit.Click
		Dim id As Integer
		Dim x As Short
		
		bGRVNewItemBarcode = True
		
		If gridItem.get_RowData(gridItem.row) <> 0 Then
			id = gridItem.get_RowData(gridItem.row)
			frmStockItem.loadItem(id)
            frmStockItem.Show()
			getOrder()
			x = findItem(id)
			If x Then
				gridItem.row = x
				gridItem.Col = colQuantity
                _txtEdit_0.Visible = True
				gridItem_EnterCell(gridItem, New System.EventArgs())
			End If
			
		End If
		
		bGRVNewItemBarcode = False
	End Sub
	
	Private Sub Picture2_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Picture2.Resize
        cmdExit.Left = twipsToPixels(pixelToTwips(Picture2.ClientRectangle.Width, True) - _
                                    pixelToTwips(cmdExit.Width, True) - 30, True)
        cmdNext.Left = twipsToPixels(pixelToTwips(cmdExit.Left, True) - _
                                    pixelToTwips(cmdNext.Width, True) - 150, True)
        cmdBack.Left = twipsToPixels(pixelToTwips(cmdNext.Left, True) - _
                                    pixelToTwips(cmdBack.Width, True) - 45, True)
	End Sub
	
	Private Sub tmrAutoGRV_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrAutoGRV.Tick
		If bolAirTimeGRV = True Then
			tmrAutoGRV.Enabled = False
			cmdNext.Focus()
			cmdNext_Click(cmdNext, New System.EventArgs())
		End If
	End Sub
	
	'UPGRADE_WARNING: Event txtEdit.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub txtEdit_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'Dim Index As Short = txtEdit.GetIndex(eventSender)
        Dim Index As Integer
        Dim n As New TextBox
        n = DirectCast(eventSender, TextBox)
        Index = GetIndexer(n, txtEdit)
        If loading Then Exit Sub
        Dim lString As String
        Dim lValue As Integer
        With gridItem
            lString = txtEdit(Index).Text
            If lString = "." Then lValue = CInt("0.")
            If .row Then
                If lString = "" Then lString = "0"
                If IsNumeric(lString) Then
                    Select Case Index
                        Case 0
                            If CBool(.get_TextMatrix(.row, colFractions)) Then
                                .set_TextMatrix(.row, colQuantity, FormatNumber(lString, 4))
                            Else
                                .set_TextMatrix(.row, colQuantity, FormatNumber(lString, 0))
                            End If
                        Case 1
                            .set_TextMatrix(.row, colContentExclusive, FormatNumber(CDec(lString) / 100, 2))
                        Case 2
                            .set_TextMatrix(.row, colPrice, FormatNumber(CDec(lString) / 100, 2))
                    End Select
                End If
                displayLine(.row)
            End If
        End With
        doTotals()
    End Sub
	
    Private Sub txtEdit_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'Dim Index As Short = txtEdit.GetIndex(eventSender)
        update_Renamed()
    End Sub
	
	Private Sub doSearchBC()
		Dim rj As ADODB.Recordset
		'Dim sql As String
		Dim lString As String
		
		On Error Resume Next
		
		lString = Trim(txtBCode.Text)
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		
		Dim lID As Integer
		Dim sql As String
		Dim rsCQty As ADODB.Recordset
		Dim rsSql As String
		Dim lDeposit As Decimal
        Dim x As Integer
		If Trim(lString) = "" Then
			
		Else
			
			txtBCode.SelectionStart = 0
			txtBCode.SelectionLength = 999
			
			rj = getRS("SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Barcode, StockItem.StockItemID, StockItem.StockItem_Name FROM Catalogue INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID WHERE (((Catalogue.Catalogue_Barcode)='" & lString & "') AND ((Catalogue.Catalogue_Disabled)=False));")
			If rj.RecordCount > 0 Then
				txtSearch.Text = rj.Fields("StockItem_Name").Value
				
				lID = rj.Fields("Catalogue_StockItemID").Value 'DataList1.BoundText
				
				'If lstWorkspace.ListIndex <> -1 Then
				
				
				update_Renamed()
				x = findItem(rj.Fields("Catalogue_StockItemID").Value) 'findItem(lstWorkspace.ItemData(lstWorkspace.ListIndex))
				
				If x Then
					gridItem.row = x
				Else
					
					On Error Resume Next
					
                    sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_Price ) SELECT " & Me.gridItem.RowCount & ", " & frmGRV.adoPrimaryRS.Fields("GRVID").Value & " AS grvid, StockItem.StockItemID, " & orderType & " AS return, StockItem.StockItem_Name, '' AS code, StockItem.StockItem_Quantity, StockItem.StockItem_OrderQuantity, 0 AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
					sql = sql & " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & rj.Fields("Catalogue_StockItemID").Value & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));"
					
					cnnDB.Execute(sql)
					
					sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_Price ) "
                    sql = sql & "SELECT " & Me.gridItem.RowCount & ", " & frmGRV.adoPrimaryRS.Fields("GRVID").Value & " AS grvid, StockItem.StockItemID, " & orderType & " AS return, StockItem.StockItem_Name, '' AS code, StockItem.StockItem_Quantity, StockItem.StockItem_OrderQuantity, 0 AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 FROM StockItem WHERE (((StockItem.StockItemID)=" & rj.Fields("Catalogue_StockItemID").Value & "));"
					
					cnnDB.Execute(sql)
					
					sql = "UPDATE ((Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_Quantity = StockItem.StockItem_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)) INNER JOIN GRVItem ON (GRVItem.GRVItem_StockItemID = StockItem.StockItemID) AND (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize) SET GRVItem.GRVItem_StockItemQuantity = [CatalogueChannelLnk_Quantity], GRVItem.GRVItem_Price = [CatalogueChannelLnk_Price] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((StockItem.StockItemID)=" & rj.Fields("Catalogue_StockItemID").Value & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((GRVItem.GRVItem_Return)=" & orderType & ") AND ((StockItem.StockItem_PackSizeID)=[StockItem_Quantity]));"
					cnnDB.Execute(sql)
					
					sql = "UPDATE (StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID SET GRVItem.GRVItem_VatRate = [Vat_Amount] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_Return)=" & orderType & ") AND ((GRVItem.GRVItem_StockItemID)=" & rj.Fields("Catalogue_StockItemID").Value & "));"
					
					cnnDB.Execute(sql)
					
					'update selling price
                    sql = "UPDATE GRVItem INNER JOIN PriceChannelLnk ON PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID SET GRVItem.GRVItem_Price = PriceChannelLnk.PriceChannelLnk_Price WHERE ((PriceChannelLnk.PriceChannelLnk_Quantity=1) AND (PriceChannelLnk.PriceChannelLnk_ChannelID=1) AND (GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & " AND GRVItem.GRVItem_Line =" & Me.gridItem.RowCount & ");"
					cnnDB.Execute(sql)
					
					getOrder()
					System.Windows.Forms.Application.DoEvents()
					'UPGRADE_WARNING: Couldn't resolve default property of object findItem(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    x = findItem(rj.Fields("Catalogue_StockItemID").Value)
					If x Then
						gridItem.row = x
						gridItem.Col = colQuantity
                        _txtEdit_0.Visible = True
						gridItem_EnterCell(gridItem, New System.EventArgs())
						System.Windows.Forms.Application.DoEvents()
						If gQuickKey Then quickEdit()
					End If
				End If
				'End If
				
				
			End If
		End If
		
	End Sub
	
	Private Sub txtBCode_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtBCode.Enter
		txtBCode.SelectionStart = 0
		txtBCode.SelectionLength = 999
	End Sub
	
	Private Sub txtBCode_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtBCode.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Select Case KeyCode
			Case 40
				If lstWorkspace.Items.Count Then
					If lstWorkspace.SelectedIndex = -1 Then
						lstWorkspace.SelectedIndex = 0
					End If
				End If
				Me.lstWorkspace.Focus()
				
		End Select
	End Sub
	
	Private Sub txtBCode_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtBCode.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case KeyAscii
			Case 13
				doSearchBC()
		End Select
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
				If lstWorkspace.Items.Count Then
					If lstWorkspace.SelectedIndex = -1 Then
						lstWorkspace.SelectedIndex = 0
					End If
				End If
				Me.lstWorkspace.Focus()
				
		End Select
	End Sub
	
	Private Sub txtSearch_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case KeyAscii
			Case 13
				doSearch()
		End Select
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub doSearch()
		getNamespace()
		
	End Sub
	
    Private Sub gridItem_EnterCell(ByVal eventSender As System.Object, ByVal eventArgs As DataGridViewCellEventArgs) Handles gridItem.CellEnter
        On Error GoTo gridItem_Err
        If loading Then Exit Sub
        loading = True
        With gridItem
            If .row Then
                If .Col = colContentExclusive Then

                    _txtEdit_1.SetBounds(twipsToPixels(pixelToTwips(.Left, True) + .CellLeft, True), _
                                         twipsToPixels(pixelToTwips(.Top, False) + .CellTop, False), _
                                         twipsToPixels(.CellWidth, True), _
                                         twipsToPixels(.CellHeight, False))
                    _txtEdit_1.Text = .Text
                    _txtEdit_1.Tag = _txtEdit_1.Text
                    _txtEdit_1.Visible = True
                    _txtEdit_1.SelectionStart = 0
                    _txtEdit_1.SelectionLength = 9999
                    If Me.Visible Then _txtEdit_1.Focus()
                Else
                    _txtEdit_1.Visible = False
                End If
                If .Col = colPrice Then
                    If CShort(.Text) = 0 Then
                        MsgBox("Matrix Selling price cannot be changed!", MsgBoxStyle.Critical)
                        loading = False
                        txtSearch.Focus()
                        Exit Sub
                    End If
                    _txtEdit_2.SetBounds(twipsToPixels(pixelToTwips(.Left, True) + .CellLeft, True), _
                                         twipsToPixels(pixelToTwips(.Top, False) + .CellTop, False), _
                                         twipsToPixels(.CellWidth, True), _
                                         twipsToPixels(.CellHeight, False))
                    _txtEdit_2.Text = .Text
                    _txtEdit_2.Tag = _txtEdit_2.Text
                    _txtEdit_2.Visible = True
                    _txtEdit_2.SelectionStart = 0
                    _txtEdit_2.SelectionLength = 9999
                    If Me.Visible Then _txtEdit_2.Focus()
                Else
                    _txtEdit_2.Visible = False
                End If
                If .Col = colQuantity Then
                    _txtEdit_0.SetBounds(twipsToPixels(pixelToTwips(.Left, True) + .CellLeft, True), _
                                         twipsToPixels(pixelToTwips(.Top, False) + .CellTop, False), _
                                         twipsToPixels(.CellWidth, True), _
                                         twipsToPixels(.CellHeight, False))
                    _txtEdit_0.Text = .Text
                    intQTY = CShort(.Text)
                    _txtEdit_0.Tag = _txtEdit_0.Text
                    _txtEdit_0.Visible = True
                    _txtEdit_0.SelectionStart = 0
                    _txtEdit_0.SelectionLength = 9999
                    If Me.Visible Then _txtEdit_0.Focus()
                Else
                    _txtEdit_0.Visible = False
                End If
            End If
        End With
        loading = False
        If bFNVegPackSize And orderType = 0 Then
            'Set rsPackSize = getRS("SELECT StockItem.StockItemID, PackSize.PackSize_Volume FROM StockItem INNER JOIN PackSize ON StockItem.StockItem_PackSizeID = PackSize.PackSizeID WHERE (((StockItem.StockItemID)=" & gridItem.RowData(gridItem.row) & "));")
            rsPackSize = getRS("SELECT GRVItem.GRVItem_PackSizeVol FROM GRVItem WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVItem.GRVItem_StockItemID)=" & gridItem.get_RowData(gridItem.row) & ") AND ((GRVItem.GRVItem_Return)=" & orderType & "));")
            txtPackSize.Text = FormatNumber(rsPackSize.Fields("GRVItem_PackSizeVol").Value, 2)
        End If
        Exit Sub
gridItem_Err:
        Resume Next
    End Sub
	Private Sub gridItem_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles gridItem.Enter
		'    txtEdit_GotFocus
	End Sub
	
    Private Sub gridItem_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles gridItem.KeyPress
        Select Case eventArgs.KeyChar
            Case Chr(40)
                eventArgs.KeyChar = Chr(0)
        End Select

    End Sub
	
    Private Sub gridItem_LeaveCell(ByVal eventSender As System.Object, ByVal eventArgs As DataGridViewCellEventArgs) Handles gridItem.CellLeave
        update_Renamed()
    End Sub
	
	
	
    Private Sub txtEdit_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'Dim Index As Short = txtEdit.GetIndex(eventSender)
        Dim txtEdit As TextBox = CType(eventSender, TextBox)
        txtEdit.SelectionStart = 0
        txtEdit.SelectionLength = 999

    End Sub
	
    Private Function moveNext(ByRef Index As Integer, ByRef direction As Integer) As Integer
        Dim x As Short
        Dim y As Short

        x = gridItem.row + direction

        If x >= gridItem.RowCount Or x < gridItem.FixedRows Then
        Else
            gridItem.row = x
        End If

        txtEdit(Index).SelectionStart = 0
        txtEdit(Index).SelectionLength = 999

        If txtEdit(Index).Visible Then txtEdit(Index).Focus()

        moveNext = True
    End Function
	
    Private Sub txtEdit_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'Dim Index As Short = txtEdit.GetIndex(eventSender)
        Dim txtBox As TextBox = CType(eventSender, TextBox)
        Dim lNewText As String
        ' Delete carriage returns to get rid of beep
        ' and only allow numbers.
        Select Case KeyAscii
            Case Asc(vbCr)
                KeyAscii = 0
            Case 8
            Case 48 To 57
            Case Else
                If txtBox.TabIndex = _txtEdit_0.TabIndex Then
                    If CBool(gridItem.get_TextMatrix(gridItem.row, colFractions)) Then
                    Else
                        KeyAscii = 0
                        GoTo EventExitSub
                    End If
                End If

                If Chr(KeyAscii) = "." Then
                    lNewText = txtBox.Text
                    If txtBox.SelectionLength Then
                        lNewText = VB.Left(txtBox.Text, txtBox.SelectionStart) & _
                            Mid(txtBox.Text, txtBox.SelectionStart + _
                                txtBox.SelectionLength + 1)
                    End If
                    If InStr(lNewText, ".") Then
                        KeyAscii = 0
                    Else
                    End If
                Else
                    KeyAscii = 0
                End If

        End Select
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
End Class