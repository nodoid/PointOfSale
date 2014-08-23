Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmOrderItem
	Inherits System.Windows.Forms.Form
	'Option Explicit
	
	'Dim gDOM As DOMDocument
	'Dim gDOMOrder As DOMDocument
	Dim loading As Boolean
	Dim rsOrder As ADODB.Recordset
	Dim colName As Short
	Dim colQuantity As Short
	Dim colPackSize As Short
	Dim colMinimum As Short
	Dim colMaximum As Short
	Dim colStock As Short
	Dim colOnOrder As Short
	Dim colContentUnit As Short
	Dim colDepositUnit As Short
	Dim colContentTotal As Short
	Dim colDepositTotal As Short
	Dim colGrandTotal As Short
	
	Dim vatDeposit As Boolean
	Dim vatContent As Boolean
	Dim vatTotal As Boolean
	Dim showTotal As Boolean
	
	Dim gStockItems As Boolean
	Dim Grow As Integer
	
	Dim bSortOrder As Boolean 'Sort stock items on Order alphabetically
	Dim rsVatMaster As ADODB.Recordset 'load the VAT for all items to calculate
	
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1582 'Order Form|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1583 'All Stock Items|Checked
		If rsLang.RecordCount Then cmdStockItem.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdStockItem.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1148 'Delete|Checked
		If rsLang.RecordCount Then cmdDelete.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdDelete.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1585 'Break / Build Pack
		If rsLang.RecordCount Then cmdPack.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPack.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1579 'Back|Checked
		If rsLang.RecordCount Then cmdBack.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdBack.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1005 'Next|Checked
		If rsLang.RecordCount Then cmdNext.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdNext.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lblSupplier = No Code / Dynamic!
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1591 'Stock Item Selector|Checked
		If rsLang.RecordCount Then _lbl_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1080 'Search|Checked
		If rsLang.RecordCount Then _lbl_7.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_7.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1685 'Sub Totals|Checked
		If rsLang.RecordCount Then frmTotals.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : frmTotals.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lbl(8) = No Code   [No Of Cases]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lbl(8).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(8).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1717 'Broken Packs|Checked
		If rsLang.RecordCount Then _lbl_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1736 'Deposit Value|Checked
		If rsLang.RecordCount Then lbl(9).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl(9).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lbl(10) = No Code  [Contents Value]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lbl(10).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(10).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_1 = No Code   [Total Value]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmOrderItem.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub getOrder()
		'    Dim lNode As IXMLDOMNode
		'    Dim lNodeList As IXMLDOMNodeList
		Dim x As Short
		If bSortOrder Then
			rsOrder = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_Quantity, StockItem.StockItem_MinimumStock, StockItem.StockItem_OrderQuantity, StockItem.StockItem_OrderRounding, TempOrderItem.TempOrderItem_ContentCost, TempOrderItem.TempOrderItem_Quantity, TempOrderItem.TempOrderItem_PackSize, WAREHOUSE_Stock.Warehouse_StockItemQuantity, ORDER_onOrder.onOrder, Deposit.Deposit_UnitCost, Deposit.Deposit_CaseCost FROM (((TempOrderItem INNER JOIN StockItem ON TempOrderItem.TempOrderItem_StockItemID = StockItem.StockItemID) INNER JOIN ORDER_onOrder ON StockItem.StockItemID = ORDER_onOrder.StockItemID) INNER JOIN WAREHOUSE_Stock ON StockItem.StockItemID = WAREHOUSE_Stock.WarehouseStockItemLnk_StockItemID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID Where (((TempOrderItem.TempOrderItem_SupplierID) = " & frmOrder.adoPrimaryRS.Fields("SupplierID").Value & ")) ORDER BY StockItem.StockItem_Name;")
		Else
			rsOrder = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_Quantity, StockItem.StockItem_MinimumStock, StockItem.StockItem_OrderQuantity, StockItem.StockItem_OrderRounding, TempOrderItem.TempOrderItem_ContentCost, TempOrderItem.TempOrderItem_Quantity, TempOrderItem.TempOrderItem_PackSize, WAREHOUSE_Stock.Warehouse_StockItemQuantity, ORDER_onOrder.onOrder, Deposit.Deposit_UnitCost, Deposit.Deposit_CaseCost FROM (((TempOrderItem INNER JOIN StockItem ON TempOrderItem.TempOrderItem_StockItemID = StockItem.StockItemID) INNER JOIN ORDER_onOrder ON StockItem.StockItemID = ORDER_onOrder.StockItemID) INNER JOIN WAREHOUSE_Stock ON StockItem.StockItemID = WAREHOUSE_Stock.WarehouseStockItemLnk_StockItemID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID Where (((TempOrderItem.TempOrderItem_SupplierID) = " & frmOrder.adoPrimaryRS.Fields("SupplierID").Value & "));") ' ORDER BY StockItem.StockItem_Name
		End If
		
		Dim lDeposit As Decimal
		loading = True
		With gridItem
			.Visible = False
            .RowCount = rsOrder.RecordCount + 1
            x = 0
            Do Until rsOrder.EOF
                x = x + 1
                .row = x
                .set_RowData(x, rsOrder.Fields("StockItemID").Value)
                .Col = colPackSize
                gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(222, 222, 222))
                .Col = colContentUnit
                gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
                .Col = colDepositUnit
                gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(222, 222, 222))
                .Col = colDepositTotal
                gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 200, 200))
                .Col = colContentTotal
                gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 200, 200))
                .Col = colMinimum
                gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(222, 222, 200))
                .Col = colMaximum
                gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(222, 222, 200))
                .Col = colStock
                gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(222, 222, 200))
                .Col = colOnOrder
                gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(222, 222, 222))
                If showTotal Then
                    .Col = colGrandTotal
                    gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(200, 255, 200))
                End If

                .set_TextMatrix(x, 0, rsOrder.Fields("StockItem_Name").Value)
                .set_TextMatrix(x, colMinimum, FormatNumber(rsOrder.Fields("StockItem_MinimumStock").Value, 0))
                .set_TextMatrix(x, colOnOrder, FormatNumber(rsOrder.Fields("OnOrder").Value, 0))
                .set_TextMatrix(x, colStock, FormatNumber(rsOrder.Fields("Warehouse_StockItemQuantity").Value, 0))
                .set_TextMatrix(x, colQuantity, FormatNumber(rsOrder.Fields("TempOrderItem_Quantity").Value, 0))
                .set_TextMatrix(x, colPackSize, FormatNumber(rsOrder.Fields("TempOrderItem_PackSize").Value, 0))
                If rsOrder.Fields("TempOrderItem_PackSize").Value <> rsOrder.Fields("StockItem_Quantity").Value Then
                    .Col = colPackSize
                    gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 200, 200))
                    .set_TextMatrix(x, 1, "X")
                Else
                    .set_TextMatrix(x, 1, "")
                End If
                .set_TextMatrix(x, colContentUnit, FormatNumber(IIf(IsDbNull(rsOrder.Fields("TempOrderItem_ContentCost").Value), 0, rsOrder.Fields("TempOrderItem_ContentCost").Value) * rsOrder.Fields("TempOrderItem_PackSize").Value / rsOrder.Fields("StockItem_Quantity").Value, 2))
                lDeposit = rsOrder.Fields("Deposit_UnitCost").Value * rsOrder.Fields("TempOrderItem_PackSize").Value
                If rsOrder.Fields("TempOrderItem_PackSize").Value = rsOrder.Fields("StockItem_Quantity").Value Then
                    lDeposit = lDeposit + rsOrder.Fields("Deposit_CaseCost").Value
                End If
                .set_TextMatrix(x, colDepositUnit, FormatNumber(lDeposit, 2))
                '                .TextMatrix(x, colDepositTotal) = FormatNumber(.TextMatrix(x, colDepositUnit) * .TextMatrix(x, colQuantity), 2)
                '                .TextMatrix(x, colContentTotal) = FormatNumber(.TextMatrix(x, colContentUnit) * .TextMatrix(x, colQuantity), 2)
                displayLine(x)
                rsOrder.moveNext()
            Loop
            .Col = colQuantity
            .Visible = True
        End With

        loading = False
        doTotals()
    End Sub
    Private Sub displayLine(ByRef row As Short)
        With gridItem
            .set_TextMatrix(row, colDepositTotal, FormatNumber(CDbl(.get_TextMatrix(row, colDepositUnit)) * CDbl(.get_TextMatrix(row, colQuantity)), 2))
            .set_TextMatrix(row, colContentTotal, FormatNumber(CDbl(.get_TextMatrix(row, colContentUnit)) * CDbl(.get_TextMatrix(row, colQuantity)), 2))
            If showTotal Then
                .set_TextMatrix(row, colGrandTotal, FormatNumber(CDec(.get_TextMatrix(row, colContentTotal)) + CDec(.get_TextMatrix(row, colDepositTotal)), 2))
                If vatTotal Then
                    rsVatMaster.Filter = "StockItemID=" & .get_RowData(row)
                    If rsVatMaster.RecordCount Then
                        .set_TextMatrix(row, colGrandTotal, FormatNumber(CDec(.get_TextMatrix(row, colGrandTotal)) * IIf(rsVatMaster.Fields("Vat_Amount").Value = 0, 1, (1 + rsVatMaster.Fields("Vat_Amount").Value / 100)), 2))
                    Else
                        .set_TextMatrix(row, colGrandTotal, FormatNumber(CDec(.get_TextMatrix(row, colGrandTotal)) * 1.14, 2))
                    End If
                    '14HERE
                End If
            End If
        End With

    End Sub

    Private Sub getNamespace()
        Dim rs As ADODB.Recordset
        Dim lString As String
        lString = Trim(txtSearch.Text)
        lString = Replace(lString, "  ", " ")
        lString = Replace(lString, "  ", " ")
        lString = Replace(lString, "  ", " ")
        lString = Replace(lString, "  ", " ")
        lString = Replace(lString, "  ", " ")
        lString = Replace(lString, "  ", " ")

        If Trim(txtSearch.Text) = "" Then
            lString = " StockItem.StockItem_Discontinued = 0 "
        Else
            lString = " StockItem.StockItem_Discontinued = 0  AND (StockItem_Name LIKE '%" & Replace(lString, " ", "%' AND StockItem_Name LIKE '%") & "%')"
        End If

        If gStockItems Then
            If lString <> "" Then lString = " WHERE " & lString
            rs = getRS("SELECT TOP 100 PERCENT StockItemID, StockItem_Name FROM StockItem " & lString & "ORDER BY StockItem_Name")
        Else
            If lString <> "" Then lString = " AND " & lString

            rs = getRS("SELECT TOP 100 PERCENT StockItemID, StockItem_Name From StockItem Where (StockItem_SupplierID = " & frmOrder.adoPrimaryRS.Fields("SupplierID").Value & ") " & lString & "ORDER BY StockItem_Name")
        End If
        lstWorkspace.Items.Clear()
        Do Until rs.EOF
            lstWorkspace.Items.Add(New LBI(rs.Fields("StockItem_Name").Value & "", rs.Fields("StockItemID").Value))
            rs.moveNext()
        Loop
    End Sub

    Private Sub setup()
        loading = True
        lblSupplier.Text = frmOrder.adoPrimaryRS.Fields("Supplier_Name").Value

        With gridItem
            If showTotal Then
                gridItem.ColumnCount = 13
                gridItem.Col = colGrandTotal
                gridItem.CellFontBold = True
                gridItem.set_TextMatrix(0, colGrandTotal, "Total")
                gridItem.set_ColAlignment(colGrandTotal, 7)
                gridItem.set_ColWidth(colGrandTotal, 900)
            Else
                gridItem.ColumnCount = 12
                frmTotals.Width = twipsToPixels(pixelToTwips(lblContent.Left, True) + pixelToTwips(lblContent.Width, True) + 100, True)
            End If
            gridItem.RowCount = 1
            gridItem.row = 0
            gridItem.Col = 0
            gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, 0, "Description")
            gridItem.set_ColAlignment(0, 1)
            gridItem.set_ColWidth(0, 2500)
            gridItem.Col = 1
            gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, 1, "B")
            gridItem.set_ColAlignment(1, 1)
            gridItem.set_ColWidth(1, 200)

            gridItem.Col = colMinimum
            gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, colMinimum, "Min")
            gridItem.set_ColAlignment(colMinimum, 7)
            gridItem.set_ColWidth(colMinimum, 550)
            gridItem.Col = colMaximum
            gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, colMaximum, "Max")
            gridItem.set_ColAlignment(colMaximum, 7)
            gridItem.set_ColWidth(colMaximum, 550)
            gridItem.Col = colStock
            gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, colStock, "Curr")
            gridItem.set_ColAlignment(colStock, 7)
            gridItem.set_ColWidth(colStock, 550)
            gridItem.Col = colOnOrder
            gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, colOnOrder, "Order")
            gridItem.set_ColAlignment(colOnOrder, 7)
            gridItem.set_ColWidth(colOnOrder, 550)

            gridItem.Col = colQuantity
            gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, colQuantity, "QTY")
            gridItem.set_ColAlignment(colQuantity, 7)
            gridItem.set_ColWidth(colQuantity, 600)
            gridItem.Col = colPackSize
            gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, colPackSize, "")
            gridItem.set_ColAlignment(colPackSize, 7)
            gridItem.set_ColWidth(colPackSize, 500)
            gridItem.Col = colContentUnit
            gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, colContentUnit, "Unit Con")
            gridItem.set_ColAlignment(colContentUnit, 7)
            gridItem.set_ColWidth(colContentUnit, 900)
            gridItem.Col = colDepositUnit
            gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, colDepositUnit, "Unit Dep")
            gridItem.set_ColAlignment(colDepositUnit, 7)
            gridItem.set_ColWidth(colDepositUnit, 900)
            gridItem.Col = colDepositTotal
            gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, colDepositTotal, "Dep Value")
            gridItem.set_ColAlignment(colDepositTotal, 7)
            gridItem.set_ColWidth(colDepositTotal, 1000)
            gridItem.Col = colContentTotal
            gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, colContentTotal, "Con Value")
            gridItem.set_ColAlignment(colContentTotal, 7)
            gridItem.set_ColWidth(colContentTotal, 1000)
        End With
        loading = False
    End Sub

    Private Sub cmdBack_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBack.Click
        cmdBack.Focus()
        System.Windows.Forms.Application.DoEvents()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
        cmdBack.Focus()
        System.Windows.Forms.Application.DoEvents()
        Me.Close()
        System.Windows.Forms.Application.DoEvents()
        frmOrder.Close()
    End Sub


    Private Sub doTotals()
        Dim x, lQuantity As Integer
        Dim lBrokenPack As Short
        Dim lContent, lDeposit As Decimal
        Dim lTotal As Decimal
        lContent = 0
        lDeposit = 0
        lQuantity = 0
        lTotal = 0
        lBrokenPack = 0
        If showTotal Then
            For x = 1 To gridItem.RowCount - 1
                lContent = lContent + CDec(gridItem.get_TextMatrix(x, colContentTotal))
                lDeposit = lDeposit + CDec(gridItem.get_TextMatrix(x, colDepositTotal))
                If gridItem.get_TextMatrix(x, 1) = "" Then
                    lQuantity = lQuantity + CShort(gridItem.get_TextMatrix(x, colQuantity))
                Else
                    lBrokenPack = lBrokenPack + CShort(gridItem.get_TextMatrix(x, colQuantity))
                End If
                lTotal = lTotal + CDec(gridItem.get_TextMatrix(x, colGrandTotal))
            Next x
        Else
            For x = 1 To gridItem.RowCount - 1
                lContent = lContent + CDec(gridItem.get_TextMatrix(x, colContentTotal))
                lDeposit = lDeposit + CDec(gridItem.get_TextMatrix(x, colDepositTotal))
                lQuantity = lQuantity + CShort(gridItem.get_TextMatrix(x, colQuantity))
            Next x
        End If
        lblQuantity.Text = FormatNumber(lQuantity, 0)
        lblContent.Text = FormatNumber(lContent, 2)
        lblDeposit.Text = FormatNumber(lDeposit, 2)
        lblTotal.Text = FormatNumber(lTotal, 2)
        lblBrokenPack.Text = CStr(lBrokenPack)

    End Sub

    Private Sub cmdNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNext.Click
        cmdNext.Focus()
        System.Windows.Forms.Application.DoEvents()
        frmOrderSummary.ShowDialog()
    End Sub


    Private Sub cmdPriceBOM_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPriceBOM.Click
        If gridItem.row Then
            frmStockMultiPrice.changePrice(gridItem.get_RowData(gridItem.row))
        End If
    End Sub

    Private Sub cmdStockItem_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStockItem.Click
        Dim id As Integer
        Dim lString As String
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
    Private Function findItem(ByRef id As String) As Integer
        Dim x As Integer
        With gridItem

            For x = 1 To .RowCount - 1

                If .get_RowData(x) = id Then
                    findItem = x
                    Exit For
                End If

            Next x

        End With
        Return findItem
    End Function


    Private Sub frmOrderItem_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        Dim x As Short
        Dim lWidth As Short
        frmTotals.Top = twipsToPixels(pixelToTwips(ClientRectangle.Height, False) - pixelToTwips(frmTotals.Height, False), False)
        frmTotals.Left = twipsToPixels(pixelToTwips(ClientRectangle.Width, True) - pixelToTwips(frmTotals.Width, True), True)
        lstWorkspace.Height = twipsToPixels(pixelToTwips(ClientRectangle.Height, False) - pixelToTwips(lstWorkspace.Top, False), False)
        gridItem.Height = twipsToPixels(pixelToTwips(ClientRectangle.Height, False) - pixelToTwips(gridItem.Top, False) - pixelToTwips(frmTotals.Height, False), False)
        gridItem.Width = twipsToPixels(pixelToTwips(ClientRectangle.Width, True) - pixelToTwips(gridItem.Left, True), True)
        lWidth = pixelToTwips(gridItem.Width, True) - 450
        For x = 1 To gridItem.ColumnCount - 1
            lWidth = lWidth - gridItem.get_ColWidth(x)
        Next
        If lWidth > 200 Then
            gridItem.set_ColWidth(0, lWidth)
        Else
            gridItem.set_ColWidth(0, 2000)
        End If
        gridItem_EnterCell(gridItem, New System.EventArgs())
    End Sub

    Private Sub frmOrderItem_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error Resume Next
    End Sub

    Private Sub lstWorkspace_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstWorkspace.DoubleClick
        Dim lKey As String
        Dim lDeposit As Decimal
        Dim x As Short
        Dim sql As String
        Dim rsSql As ADODB.Recordset
        If lstWorkspace.SelectedIndex <> -1 Then
            '        Dim lDOM As DOMDocument
            '        Dim lNode As IXMLDOMNode
            '        Dim lNodeList As IXMLDOMNodeList
            update_Renamed()
            loading = True
            x = findItem(CLng(lstWorkspace.SelectedIndex))
            If x Then
                gridItem.row = x

            Else
                lKey = Year(Today) & VB.Right("0" & Month(Today), 2) & VB.Right("0" & VB.Day(Today), 2) & VB.Right("0" & Hour(TimeOfDay), 2) & VB.Right("0" & Minute(TimeOfDay), 2) & VB.Right("0" & Second(TimeOfDay), 2)

                sql = "INSERT INTO TempOrderItem (TempOrderItem_SupplierID, TempOrderItem_StockItemID, TempOrderItem_PackSize, TempOrderItem_QuantityRequired, TempOrderItem_Quantity, TempOrderItem_ContentCost) "
                sql = sql & "SELECT " & frmOrder.adoPrimaryRS.Fields("SupplierID").Value & " AS supplierID, StockItemID, StockItem_OrderQuantity, 0, 0, StockItem_ListCost From StockItem WHERE (StockItemID = " & CInt(lstWorkspace.SelectedIndex) & ")"
                cnnDB.Execute(sql)

                'update Cost price from GRV Deals
                rsSql = getRS("SELECT GRVPromotion.PromotionID, GRVPromotionItem.PromotionItem_StockItemID, GRVPromotionItem.PromotionItem_Price, GRVPromotion.Promotion_StartDate, GRVPromotion.Promotion_EndDate FROM GRVPromotion INNER JOIN GRVPromotionItem ON GRVPromotion.PromotionID = GRVPromotionItem.PromotionItem_PromotionID WHERE (((GRVPromotionItem.PromotionItem_StockItemID)=" & CInt(lstWorkspace.SelectedIndex) & ") AND ((GRVPromotion.Promotion_StartDate)<=#" & Format(Today, "yyyy/MM/dd") & "#) AND ((GRVPromotion.Promotion_EndDate)>=#" & Format(Today, "yyyy/MM/dd") & "#));")
                If rsSql.RecordCount > 0 Then
                    If IsDbNull(rsSql.Fields("PromotionItem_Price").Value) Then
                    Else
                        sql = "UPDATE TempOrderItem SET TempOrderItem.TempOrderItem_ContentCost = " & rsSql.Fields("PromotionItem_Price").Value & " Where (TempOrderItem_SupplierID = " & frmOrder.adoPrimaryRS.Fields("SupplierID").Value & ") And (TempOrderItem_StockItemID = " & CInt(lstWorkspace.SelectedIndex) & ");"
                        cnnDB.Execute(sql)
                    End If
                End If
                'update Cost price from GRV Deals

                getOrder()
                System.Windows.Forms.Application.DoEvents()
                x = findItem(lstWorkspace, lstWorkspace.SelectedIndex)
                If x Then
                    gridItem.row = x
                    gridItem.Col = colQuantity
                    _txtEdit_0.Visible = True
                    'gridItem_EnterCell
                End If
            End If
        End If
        loading = False
        gridItem_EnterCell(gridItem, New System.EventArgs())

    End Sub
    Private Function findItem(ByRef myList As ListBox, ByRef myIndex As Integer) As Integer
        myList.SelectedIndex = myIndex
        Return myList.SelectedIndex
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

    Private Sub update_Renamed()
        If loading Then Exit Sub
        '   Dim lNode As IXMLDOMNode
        Dim x As Short
        Dim sql As String
        Dim oText As System.Windows.Forms.TextBox
        Dim lUpdate As Boolean
        For Each oText In txtEdit
            If oText.Text = "" Then oText.Text = "0"
            If oText.Text <> oText.Tag Then
                lUpdate = True
            End If
        Next oText
        'If txtEdit.Text = "" Then txtEdit.Text = "0"
        'If txtEdit.Text <> txtEdit.Tag Then
        If lUpdate Then
            Select Case gridItem.Col
                Case colQuantity
                    If Grow = gridItem.row Then
                        sql = "UPDATE TempOrderItem SET TempOrderItem_Quantity = " & _txtEdit_0.Text & " Where (TempOrderItem_SupplierID = " & frmOrder.adoPrimaryRS.Fields("SupplierID").Value & ") And (TempOrderItem_StockItemID = " & gridItem.get_RowData(gridItem.row) & ")"
                        cnnDB.Execute(sql)
                        gridItem.set_TextMatrix(gridItem.row, colQuantity, _txtEdit_0.Text)
                    Else
                    End If
                Case colContentUnit
                    If Grow = gridItem.row Then
                        sql = "UPDATE TempOrderItem SET TempOrderItem_ContentCost = " & FormatNumber(CDec(_txtEdit_1.Text) / 100, 2) & " Where (TempOrderItem_SupplierID = " & frmOrder.adoPrimaryRS.Fields("SupplierID").Value & ") And (TempOrderItem_StockItemID = " & gridItem.get_RowData(gridItem.row) & ")"
                        cnnDB.Execute(sql)
                        gridItem.set_TextMatrix(gridItem.row, colContentUnit, FormatNumber(CDec(_txtEdit_1.Text) / 100, 2))
                    Else
                    End If
                    'gridItem.TextMatrix(gridItem.row, colContentUnit) = FormatNumber(CCur(_txtEdit_1.Text) / 100, 2)
                    '_txtEdit_1.Tag = _txtEdit_1.Text
            End Select
        End If
    End Sub

    Private Sub cmdPack_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPack.Click
        Dim id As Integer
        Dim x As Integer

        id = gridItem.get_RowData(gridItem.row)
        If CDbl(gridItem.get_TextMatrix(gridItem.row, colPackSize)) = 1 Then
            cnnDB.Execute("UPDATE TempOrderItem INNER JOIN StockItem ON TempOrderItem.TempOrderItem_StockItemID = StockItem.StockItemID SET TempOrderItem.TempOrderItem_Quantity = CInt(([TempOrderItem_QuantityRequired]+([StockItem_OrderQuantity]-1)/2)/[StockItem_Quantity]), TempOrderItem.TempOrderItem_PackSize = [StockItem]![StockItem_Quantity] WHERE (((TempOrderItem.TempOrderItem_SupplierID)=" & frmOrder.adoPrimaryRS.Fields("SupplierID").Value & ") AND ((TempOrderItem.TempOrderItem_StockItemID)=" & id & "));")
        Else
            cnnDB.Execute("UPDATE TempOrderItem SET TempOrderItem.TempOrderItem_Quantity = [TempOrderItem]![TempOrderItem_QuantityRequired], TempOrderItem.TempOrderItem_PackSize = 1 WHERE (((TempOrderItem.TempOrderItem_SupplierID)=" & frmOrder.adoPrimaryRS.Fields("SupplierID").Value & ") AND ((TempOrderItem.TempOrderItem_StockItemID)=" & id & "));")

        End If
        getOrder()
        x = findItem(id)
        If x Then
            gridItem.row = x
            gridItem.Col = colQuantity
            _txtEdit_0.Visible = True
            gridItem_EnterCell(gridItem, New System.EventArgs())
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDelete.Click
        Dim oText As System.Windows.Forms.TextBox
        If gridItem.row Then
            If MsgBox("Are you sure you wish to delete the order item '" & gridItem.get_TextMatrix(gridItem.row, 0) & "' from this order?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Delete Line Item") = MsgBoxResult.Yes Then
                cnnDB.Execute("DELETE FROM TempOrderItem Where (TempOrderItem_SupplierID = " & frmOrder.adoPrimaryRS.Fields("SupplierID").Value & ") And (TempOrderItem_StockItemID = " & gridItem.get_RowData(gridItem.row) & ")")
                getOrder()
                If gridItem.RowCount > 1 Then
                    gridItem.row = 1
                    gridItem_EnterCell(gridItem, New System.EventArgs())
                Else
                    'txtEdit.Visible = False
                    For Each oText In txtEdit
                        oText.Visible = False
                    Next oText
                End If
            End If
        End If
    End Sub

    Private Sub cmdEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEdit.Click
        Dim id As Integer
        Dim x As Integer
        Dim form As frmStockItem
        If gridItem.get_RowData(gridItem.row) <> 0 Then
            id = gridItem.get_RowData(gridItem.row)
            frmStockItem.loadItem(gridItem.get_RowData(gridItem.row))
            form.Show()
            getOrder()
            x = findItem(id)
            If x Then
                gridItem.row = x
                gridItem.Col = colQuantity
                _txtEdit_0.Visible = True
                gridItem_EnterCell(gridItem, New System.EventArgs())
            End If

        End If
    End Sub

    Private Sub picButtons_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles picButtons.Resize
        cmdExit.Left = twipsToPixels(pixelToTwips(picButtons.ClientRectangle.Width, True) - pixelToTwips(cmdExit.Width, True) - 30, True)
        cmdNext.Left = twipsToPixels(pixelToTwips(cmdExit.Left, True) - pixelToTwips(cmdNext.Width, True) - 150, True)
        cmdBack.Left = twipsToPixels(pixelToTwips(cmdNext.Left, True) - pixelToTwips(cmdBack.Width, True) - 45, True)

    End Sub

    Private Sub txtEdit_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtEdit.TextChanged
        Dim Index As Integer
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Index = GetIndexer(txtBox, txtEdit)
        Dim colPrice As Decimal
        If loading Then Exit Sub
        Dim lString As String
        Dim lValue As Integer
        With gridItem
            lString = txtBox.Text
            If lString = "." Then lValue = CInt("0.")
            If .row Then
                If lString = "" Then lString = "0"
                If IsNumeric(lString) Then
                    Select Case Index
                        Case 0
                            'If CBool(.TextMatrix(.row, colFractions)) Then
                            '    .TextMatrix(.row, colQuantity) = FormatNumber(lString, 4)
                            'Else
                            .set_TextMatrix(.row, colQuantity, FormatNumber(lString, 0))
                            'End If
                        Case 1
                            .set_TextMatrix(.row, colContentUnit, FormatNumber(CDec(lString) / 100, 2))
                        Case 2
                            .set_TextMatrix(.row, colPrice, FormatNumber(CDec(lString) / 100, 2))
                    End Select
                End If
                displayLine(.row)
            End If
        End With
        doTotals()
    End Sub

    Private Sub txtEdit_Change_OLD()
        '    If loading Then Exit Sub
        '    With gridItem
        '        Dim lValue As Long
        '        If .row Then
        '            If txtEdit.Text = "" Then lValue = 0 Else lValue = txtEdit.Text
        '            .TextMatrix(.row, colQuantity) = lValue
        ''            .TextMatrix(.row, colDepositTotal) = FormatNumber(.TextMatrix(.row, colDepositUnit) * lValue, 2)
        ''            .TextMatrix(.row, colContentTotal) = FormatNumber(.TextMatrix(.row, colContentUnit) * lValue, 2)
        '            displayLine .row
        '        End If
        '    End With
        '    doTotals
    End Sub

    Private Sub txtEdit_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtEdit.Leave
        Dim Index As Short = txtEdit.GetIndex(eventSender)
        update_Renamed()
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
                Me.lstWorkspace.Focus()
                If lstWorkspace.Items.Count Then
                    If lstWorkspace.SelectedIndex = -1 Then
                        lstWorkspace.SelectedIndex = 0
                    End If
                End If
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


    Private Sub frmOrderItem_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim oText As New TextBox
        '    Dim lNode As IXMLDOMNode
        '    Select Case frmOrder.gTransactionType
        '        Case 1
        '            colMinimum = 2
        '            colMaximum = 3
        '            colStock = 4
        '            colQuantity = 5
        '            colPackSize = 6
        '            colContentUnit = 7
        '            colDepositUnit = 8
        '            colDepositTotal = 9
        '            colContentTotal = 10
        '            colGrandTotal = 12
        '            colOnOrder = 11
        '            vatDeposit = False
        '            vatContent = False
        '            vatTotal = False
        '            showTotal = True
        '        Case 4, 5
        '            colMinimum = 2
        '            colMaximum = 3
        '            colStock = 4
        '            colQuantity = 5
        '            colPackSize = 6
        '            colContentUnit = 7
        '            colDepositUnit = 8
        '            colDepositTotal = 9
        '            colContentTotal = 10
        '            colGrandTotal = 12
        '            colOnOrder = 11
        '            vatDeposit = False
        '            vatContent = False
        '            vatTotal = True
        '            showTotal = True
        '        Case Else
        colQuantity = 2
        colPackSize = 3
        colContentUnit = 4
        colDepositUnit = 5
        colDepositTotal = 6
        colContentTotal = 7
        colMinimum = 8
        colMaximum = 9
        colStock = 10
        colGrandTotal = 12
        colOnOrder = 11
        vatDeposit = False
        vatContent = False
        vatTotal = True
        showTotal = True
        '    End Select

        loadLanguage()

        'Sort stock items on Order alphabetically
        Dim rs As ADODB.Recordset
        bSortOrder = False
        rs = getRS("select Company_SortOrderItems from Company")
        If rs.RecordCount Then
            If rs.Fields("Company_SortOrderItems").Value = -1 Then
                bSortOrder = True
            End If
        End If
        'Sort stock items on Order alphabetically

        'BO Security permission check
        If 1 And frmMenu.gBit Then
        Else
            cmdEdit.Enabled = False
        End If


        'load the VAT for all items to calculate
        rsVatMaster = getRS("SELECT StockItem.StockItemID, Vat.Vat_Amount FROM StockItem INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID;")

        setup()
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
                _txtEdit_0.Visible = False
            End If
        End If

    End Sub

    Private Sub gridItem_EnterCell(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles gridItem.Enter
        If loading Then Exit Sub
        With gridItem
            'If .Col <> colQuantity Then
            '    .Col = colQuantity
            '    Exit Sub
            'End If
            If .row Then
                '        update
                If .Col = colContentUnit Then

                    _txtEdit_1.SetBounds(twipsToPixels(pixelToTwips(.Left, True) + .CellLeft, True), _
                                         twipsToPixels(pixelToTwips(.Top, False) + .CellTop, False), _
                                         twipsToPixels(.CellWidth, True), twipsToPixels(.CellHeight, False))
                    _txtEdit_1.Text = Replace(.Text, ".", "")
                    _txtEdit_1.Tag = _txtEdit_1.Text
                    _txtEdit_1.Visible = True
                    _txtEdit_1.SelectionStart = 0
                    _txtEdit_1.SelectionLength = 9999
                    If Me.Visible Then _txtEdit_1.Focus()
                Else
                    _txtEdit_1.Visible = False
                End If
                If .Col = colQuantity Then
                    _txtEdit_0.SetBounds(twipsToPixels(pixelToTwips(.Left, True) + .CellLeft, True), _
                                         twipsToPixels(pixelToTwips(.Top, False) + .CellTop, False), _
                                         twipsToPixels(.CellWidth, True), twipsToPixels(.CellHeight, False))
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
                '            txtEdit.Move .Left + .CellLeft, .Top + .CellTop, .CellWidth, .CellHeight
                'loading = True
                '            txtEdit.Text = .Text
                '            txtEdit.Text = Replace(.Text, ".", "")
                '            txtEdit.Text = Replace(.Text, ",", "")
                '            If txtEdit.Text = "000" Then txtEdit.Text = "0"
                '            txtEdit.Tag = txtEdit.Text
                Grow = .row

                'loading = False
                '            txtEdit.Tag = txtEdit.Text
                '            txtEdit.Visible = True
                '            If Me.Visible Then txtEdit.SetFocus
            End If
        End With
    End Sub

    Private Sub gridItem_EnterCell_OLD()
        '    If loading Then Exit Sub
        '    With gridItem
        '        If .Col <> colQuantity Then
        '            .Col = colQuantity
        '            Exit Sub
        '        End If
        '        If .row Then
        '    '        update
        '            txtEdit.Move .Left + .CellLeft, .Top + .CellTop, .CellWidth, .CellHeight
        'loading = True
        '            txtEdit.Text = .Text
        '            txtEdit.Text = Replace(.Text, ".", "")
        '            txtEdit.Text = Replace(.Text, ",", "")
        '            If txtEdit.Text = "000" Then txtEdit.Text = "0"
        '            txtEdit.Tag = txtEdit.Text
        '            gRow = .row
        '
        'loading = False
        '            txtEdit.Tag = txtEdit.Text
        '            txtEdit.Visible = True
        '            If Me.Visible Then txtEdit.SetFocus
        '         End If
        '    End With
    End Sub

    Private Sub gridItem_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles gridItem.Enter
        'txtEdit_GotFocus
    End Sub

    Private Sub gridItem_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles gridItem.KeyPress
        Select Case eventArgs.KeyChar
            Case ChrW(40)
                eventArgs.KeyChar = ChrW(0)
        End Select

    End Sub

    Private Sub gridItem_LeaveCell(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles gridItem.Leave
        update_Renamed()
    End Sub



    Private Sub txtEdit_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtEdit.Enter
        'Dim Index As Short = txtEdit.GetIndex(eventSender)
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        txtBox.SelectionStart = 0
        txtBox.SelectionLength = 999
    End Sub

    Private Sub txtEdit_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtEdit.KeyDown
        Dim Shift As Short = eventArgs.KeyCode
        Dim Index As Short = eventArgs.KeyData \ &H10000
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Dim KeyCode As Short = txtEdit.GetIndex(eventSender)
        With Me.gridItem
            Select Case KeyCode
                Case 27 'ESC
                    txtBox.Visible = False
                    .Focus()
                Case 13 'ENTER
                    .Focus()
                    System.Windows.Forms.Application.DoEvents()
                    moveNext(Index, 1)
                Case 37 'Left arrow
                    If txtBox.SelectionStart = 0 And txtBox.SelectionLength = 0 Then
                        .Focus()
                        System.Windows.Forms.Application.DoEvents()
                        moveNext(Index, -1)
                    End If
                Case 39 'Right arrow
                    If txtBox.SelectionStart = Len(txtBox.Text) Then
                        .Focus()
                        System.Windows.Forms.Application.DoEvents()
                        moveNext(Index, 1)
                    End If
                Case 38 'Up arrow
                    .Focus()
                    System.Windows.Forms.Application.DoEvents()
                    moveNext(Index, -1)
                Case 40 'Down arrow
                    .Focus()
                    System.Windows.Forms.Application.DoEvents()
                    moveNext(Index, 1)
            End Select
        End With
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

        'UPGRADE_WARNING: Couldn't resolve default property of object moveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        moveNext = True
    End Function

    Private Function moveNext_OLD(ByRef direction As Object) As Object
        '    Dim x, y As Integer
        '
        '    x = gridItem.row + direction
        '
        '    If x >= gridItem.RowCount Or x < gridItem.FixedRows Then
        '    Else
        '        gridItem.row = x
        '    End If
        '
        '    txtEdit.SelStart = 0
        '    txtEdit.SelLength = 999
        '    txtEdit.SetFocus
        '
        '    moveNext = True
    End Function
	
	Private Sub txtEdit_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtEdit.KeyPress
		Dim Index As Short = Asc(eventArgs.KeyChar)
		Dim KeyAscii As Short = txtEdit.GetIndex(eventSender)
		'
		' Delete carriage returns to get rid of beep
		' and only allow numbers.
		'
		Select Case KeyAscii
			Case Asc(vbCr)
				KeyAscii = 0
			Case 8
			Case 48 To 57
			Case Else
				KeyAscii = 0
		End Select
		eventArgs.KeyChar = Chr(Index)
		If Index = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class