Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmGRVDeposit
	Inherits System.Windows.Forms.Form
	'Option Explicit
	
	'Dim lDOM As DOMDocument
	'Dim gDOMOrder As DOMDocument
	Dim loading As Boolean
	Public orderType As Short
	
	Const colName As Short = 0
	Const colType As Short = 1
	Const colQuantity As Short = 2
	Const colPackSize As Short = 3
	Const colExclusivePrice As Short = 4
	Const colExclusiveAmount As Short = 5
	Const colInclusivePrice As Short = 6
	Const colInclusiveAmount As Short = 7
	
	Private Sub loadLanguage()
		
		'frmGRVDeposit = No Code    [Deposit Returns Form]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmGRVDeposit.Caption = rsLang("LanguageLayoutLnk_Description"): frmGRVDeposit.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1148 'Delete|Checked
		If rsLang.RecordCount Then cmdDelete.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdDelete.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'Note: DB Entry 1579 does not contain "<<" chars!
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1579 'Back|Checked
		If rsLang.RecordCount Then cmdBack.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdBack.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1005 'Next|Checked
		If rsLang.RecordCount Then cmdNext.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdNext.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lblSupplier = No Code/Dynamic/NA?
		
		'lblReturns = No Code       [PURCHASES]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblReturns.Caption = rsLang("LanguageLayoutLnk_Description"): lblReturns.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1685 'Sub Totals|Checked
		If rsLang.RecordCount Then frmTotals.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : frmTotals.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lbl(8) = No Code           [No Of Cases]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lbl(8).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(8).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_0 = No Code           [Exclusive Amount]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lbl(9) = No Code           [Inclusive Amount]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lbl(9).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(9).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmGRVDeposit.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub getOrder()
		Dim rs As ADODB.Recordset
		Dim sql As String
		Dim ltype As Short
		'    sql = "SELECT " & orderType & " AS depositType, GRV.GRVID, DISPLAY_SupplierDeposit.SupplierDepositLnk_SupplierID, DISPLAY_SupplierDeposit.SupplierDepositLnk_DepositID, DISPLAY_SupplierDeposit.SupplierDepositLnk_Type, DISPLAY_SupplierDeposit.SupplierDepositLnk_Name, DISPLAY_SupplierDeposit.Deposit_Quantity, DISPLAY_SupplierDeposit.Deposit_UnitCost, DISPLAY_SupplierDeposit.Deposit_CaseCost, DISPLAY_SupplierDeposit.Vat_Amount FROM DISPLAY_SupplierDeposit INNER JOIN (PurchaseOrder INNER JOIN GRV ON PurchaseOrder.PurchaseOrderID = GRV.GRV_PurchaseOrderID) ON DISPLAY_SupplierDeposit.SupplierDepositLnk_SupplierID = PurchaseOrder.PurchaseOrder_SupplierID Where (((DISPLAY_SupplierDeposit.SupplierDepositLnk_Type = 3) And (DISPLAY_SupplierDeposit.Deposit_UnitCost <> 0) And (DISPLAY_SupplierDeposit.Deposit_Quantity <> 1)) Or ((DISPLAY_SupplierDeposit.SupplierDepositLnk_Type = 2) And (DISPLAY_SupplierDeposit.Deposit_Quantity <> 1)) Or (DISPLAY_SupplierDeposit.Deposit_Quantity = 1)) and "
		'    sql = sql & "(((GRV.GRVID) = " & frmGRV.adoPrimaryRS("GRVID") & ") And ((GRV.GRV_GRVStatusID) = 1)) ORDER BY DISPLAY_SupplierDeposit.SupplierDepositLnk_Name;"
		
		sql = "SELECT " & orderType & " AS depositType, GRV.GRVID, DISPLAY_SupplierDeposit.SupplierDepositLnk_SupplierID, DISPLAY_SupplierDeposit.SupplierDepositLnk_DepositID, DISPLAY_SupplierDeposit.SupplierDepositLnk_Type, DISPLAY_SupplierDeposit.SupplierDepositLnk_Name, DISPLAY_SupplierDeposit.Deposit_Quantity, DISPLAY_SupplierDeposit.Deposit_UnitCost, DISPLAY_SupplierDeposit.Deposit_CaseCost, DISPLAY_SupplierDeposit.Vat_Amount FROM Deposit INNER JOIN (DISPLAY_SupplierDeposit INNER JOIN (PurchaseOrder INNER JOIN GRV ON PurchaseOrder.PurchaseOrderID = GRV.GRV_PurchaseOrderID) ON DISPLAY_SupplierDeposit.SupplierDepositLnk_SupplierID = PurchaseOrder.PurchaseOrder_SupplierID) ON Deposit.DepositID = DISPLAY_SupplierDeposit.SupplierDepositLnk_DepositID "
		sql = sql & "Where (((DISPLAY_SupplierDeposit.SupplierDepositLnk_Type = 3) And (DISPLAY_SupplierDeposit.Deposit_UnitCost <> 0) And (DISPLAY_SupplierDeposit.Deposit_Quantity <> 1)) Or ((DISPLAY_SupplierDeposit.SupplierDepositLnk_Type = 2) And (DISPLAY_SupplierDeposit.Deposit_Quantity <> 1)) Or (DISPLAY_SupplierDeposit.Deposit_Quantity = 1)) And "
		sql = sql & "(((GRV.GRVID) = " & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") And ((GRV.GRV_GRVStatusID) = 1)) and deposit_disabled = 0 ORDER BY DISPLAY_SupplierDeposit.SupplierDepositLnk_Name;"
		
		rs = getRS(sql)
		
		Dim lDeposit As Decimal
		Dim x As Short
		loading = True
		With gridItem
			.RowCount = rs.RecordCount + 1
			x = 0
			Do Until rs.EOF
				x = x + 1
				.set_RowData(x, rs.Fields("SupplierDepositLnk_DepositID").Value)
				.set_TextMatrix(x, colName, rs.Fields("SupplierDepositLnk_Name").Value)
				.set_TextMatrix(x, colQuantity, FormatNumber(0, 0))
				Select Case CShort(rs.Fields("SupplierDepositLnk_Type").Value)
					Case 1
						lDeposit = CDec(rs.Fields("Deposit_UnitCost").Value)
						.set_TextMatrix(x, colType, "Unit")
					Case 2
						lDeposit = CDec(rs.Fields("Deposit_CaseCost").Value)
						.set_TextMatrix(x, colType, "Crate-Empty")
					Case 3
						lDeposit = CDec(rs.Fields("Deposit_UnitCost").Value) * CDec(rs.Fields("Deposit_Quantity").Value) + CDec(rs.Fields("Deposit_CaseCost").Value)
						.set_TextMatrix(x, colType, "Case-Full")
						
				End Select
				.set_TextMatrix(x, colPackSize, FormatNumber(rs.Fields("Deposit_Quantity").Value, 0))
				.set_TextMatrix(x, colExclusivePrice, FormatNumber(0 - lDeposit, 2))
				.set_TextMatrix(x, colExclusiveAmount, FormatNumber(0, 2))
				.set_TextMatrix(x, colInclusivePrice, FormatNumber(0 - (lDeposit * (1 + rs.Fields("Vat_Amount").Value / 100)), 2))
				.set_TextMatrix(x, colInclusiveAmount, FormatNumber(0, 2))
				.row = x
				.Col = colName
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(222, 222, 222))
				.Col = colType
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(222, 222, 222))
				.Col = colPackSize
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(222, 222, 222))
				.Col = colExclusivePrice
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(222, 222, 222))
				.Col = colExclusiveAmount
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 200, 200))
				.Col = colInclusivePrice
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(222, 222, 222))
				.Col = colInclusiveAmount
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 200, 200))
				rs.moveNext()
			Loop 
			.Col = colQuantity
			rs.Close()
			sql = "SELECT GRVDeposit.GRVDeposit_GRVID, GRVDeposit.GRVDeposit_DepositID, GRVDeposit.GRVDeposit_Return, GRVDeposit.GRVDeposit_Type, GRVDeposit.GRVDeposit_Quantity From GRVDeposit WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") AND ((GRVDeposit.GRVDeposit_Return)=" & orderType & "));"
			rs = getRS(sql)
			Do Until rs.EOF
				For x = 1 To .RowCount - 1
					If .get_RowData(x) = rs.Fields("GRVDeposit_DepositID").Value Then
						
						Select Case .get_TextMatrix(x, colType)
							Case "Unit"
								ltype = 1
							Case "Crate-Empty"
								ltype = 2
							Case "Case-Full"
								ltype = 3
						End Select
						If ltype = rs.Fields("GRVDeposit_Type").Value Then
							.set_TextMatrix(x, colQuantity, FormatNumber(rs.Fields("GRVDeposit_Quantity").Value, 0))
							.set_TextMatrix(x, colExclusiveAmount, FormatNumber(CDbl(.get_TextMatrix(x, colExclusivePrice)) * CDbl(.get_TextMatrix(x, colQuantity)), 2))
							.set_TextMatrix(x, colInclusiveAmount, FormatNumber(CDbl(.get_TextMatrix(x, colInclusivePrice)) * CDbl(.get_TextMatrix(x, colQuantity)), 2))
						End If
					End If
				Next x
				rs.moveNext()
			Loop 
			
		End With
		doTotals()
		loading = False
	End Sub
	
	Private Sub setup()
		loading = True
		lblSupplier.Text = frmGRV.adoPrimaryRS.Fields("Supplier_Name").Value & "(" & frmGRV.adoPrimaryRS.Fields("PurchaseOrder_Reference").Value & ")"
		With gridItem
            gridItem.ColumnCount = 8
			gridItem.RowCount = 1
			gridItem.row = 0
			gridItem.Col = colName
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colName, "Description")
			gridItem.set_ColAlignment(colName, 1)
			gridItem.set_ColWidth(colName, 2500)
			gridItem.Col = colType
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colType, "Type")
			gridItem.set_ColAlignment(colType, 1)
			gridItem.set_ColWidth(colType, 900)
			gridItem.Col = colQuantity
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colQuantity, "QTY")
			gridItem.set_ColAlignment(colQuantity, 7)
			gridItem.set_ColWidth(colQuantity, 600)
			gridItem.Col = colPackSize
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colPackSize, "")
			gridItem.set_ColAlignment(colPackSize, 7)
			gridItem.set_ColWidth(colPackSize, 900)
			gridItem.Col = colExclusivePrice
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colExclusivePrice, "Excl Price")
			gridItem.set_ColAlignment(colExclusivePrice, 7)
			gridItem.set_ColWidth(colExclusivePrice, 1000)
			gridItem.Col = colExclusiveAmount
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colExclusiveAmount, "Excl Amt")
			gridItem.set_ColAlignment(colExclusiveAmount, 7)
			gridItem.set_ColWidth(colExclusiveAmount, 1100)
			gridItem.Col = colInclusivePrice
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colInclusivePrice, "Incl Price")
			gridItem.set_ColAlignment(colInclusivePrice, 7)
			gridItem.set_ColWidth(colInclusivePrice, 1000)
			gridItem.Col = colInclusiveAmount
			gridItem.CellFontBold = True
			gridItem.set_TextMatrix(0, colInclusiveAmount, "Incl Amt")
			gridItem.set_ColAlignment(colInclusiveAmount, 7)
			gridItem.set_ColWidth(colInclusiveAmount, 1100)
			gridItem.CellFontBold = True
		End With
		loading = False
	End Sub
	
	
	Private Sub cmdBack_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBack.Click
		If orderType Then
			Me.loadDeposits(0)
		Else
			Me.Close()
		End If
		
	End Sub
	
	Private Sub cmdDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDelete.Click
		Dim ltype As Short
		If gridItem.row Then
			If MsgBox("Are you sure you wish to delete the deposit item '" & gridItem.get_TextMatrix(gridItem.row, 0) & "' from this order?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Delete Line Item") = MsgBoxResult.Yes Then
				Select Case gridItem.get_TextMatrix(gridItem.row, colType)
					Case "Unit"
						ltype = 1
					Case "Crate-Empty"
						ltype = 2
					Case "Case-Full"
						ltype = 3
				End Select
				
				cnnDB.Execute("DELETE FROM GRVDeposit Where (GRVDeposit_GRVID = " & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") And (GRVDeposit_DepositID = " & gridItem.get_RowData(gridItem.row) & ") And (GRVDeposit_Type = " & ltype & ") And (GRVDeposit.GRVDeposit_Return=" & orderType & ");")
				
				getOrder()
				If gridItem.RowCount > 1 Then
					gridItem.row = 1
					gridItem_EnterCell(gridItem, New System.EventArgs())
				Else
					txtEdit.Visible = False
				End If
			End If
		End If
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
		System.Windows.Forms.Application.DoEvents()
		frmGRVitem.Close()
		System.Windows.Forms.Application.DoEvents()
		frmGRV.Close()
	End Sub
	
	Private Sub doTotals()
        Dim lDepositEInclusive As Decimal
        Dim x As Short
		Dim lQuantity As Short
		Dim lDepositExclusive, lDepositInclusive As Decimal
		lDepositExclusive = 0
		lDepositEInclusive = 0
		lQuantity = 0
		For x = 1 To gridItem.RowCount - 1
			lDepositExclusive = lDepositExclusive + CDec(gridItem.get_TextMatrix(x, colExclusiveAmount))
			lDepositInclusive = lDepositInclusive + CDec(gridItem.get_TextMatrix(x, colInclusiveAmount))
			lQuantity = lQuantity + CShort(gridItem.get_TextMatrix(x, colQuantity))
			
		Next x
		
		lblQuantity.Text = FormatNumber(lQuantity, 0)
		lblDepositExclusive.Text = FormatNumber(lDepositExclusive, 2)
		lblDepositInclusive.Text = FormatNumber(lDepositInclusive, 2)
	End Sub
	
	
	Private Sub cmdNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNext.Click
		If orderType Then
			frmGRVSummary.loadSummary()
		Else
			Me.loadDeposits(1)
		End If
	End Sub
	
	Private Sub frmGRVDeposit_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		Dim x As Integer
        frmTotals.Top = twipsToPixels(pixelToTwips(ClientRectangle.Height, False) - pixelToTwips(frmTotals.Height, False), False)
        frmTotals.Left = twipsToPixels(pixelToTwips(ClientRectangle.Width, True) - pixelToTwips(frmTotals.Width, True), True)
        gridItem.Height = twipsToPixels(pixelToTwips(ClientRectangle.Height, False) - pixelToTwips(gridItem.Top, False) - pixelToTwips(frmTotals.Height, False), False)
        gridItem.Width = twipsToPixels(pixelToTwips(ClientRectangle.Width, True) - pixelToTwips(gridItem.Left, True), True)
		Dim lWidth As Integer
        lWidth = pixelToTwips(gridItem.Width, True) - 450
        For x = 0 To gridItem.ColumnCount - 1
            If x = colName Then
            Else
                lWidth = lWidth - gridItem.get_ColWidth(x)
            End If
        Next
		If lWidth > 200 Then
			gridItem.set_ColWidth(colName, lWidth)
		Else
			gridItem.set_ColWidth(colName, 2000)
		End If
		
        lblReturns.Top = twipsToPixels(pixelToTwips(frmTotals.Top, False) + (pixelToTwips(frmTotals.Height, False) - pixelToTwips(lblReturns.Height, False)) / 2, False)
        lblReturns.Left = twipsToPixels(pixelToTwips(frmTotals.Left, True) - pixelToTwips(lblReturns.Width, True) - 100, True)
		lblReturns.Visible = orderType
		
		
		gridItem_EnterCell(gridItem, New System.EventArgs())
	End Sub
	
	Private Sub update_Renamed()
		If loading Then Exit Sub
		'    Dim lNode As IXMLDOMNode
		Dim x As Short
		Dim sql As String
		Dim ltype As Short
		If txtEdit.Text = "" Then txtEdit.Text = "0"
		If txtEdit.Text <> txtEdit.Tag Then
			Select Case gridItem.Col
				Case colQuantity
					Select Case gridItem.get_TextMatrix(gridItem.row, colType)
						Case "Unit"
							ltype = 1
						Case "Crate-Empty"
							ltype = 2
						Case "Case-Full"
							ltype = 3
					End Select
					sql = "DELETE FROM GRVDeposit Where (GRVDeposit_GRVID = " & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") And (GRVDeposit_DepositID = " & gridItem.get_RowData(gridItem.row) & ") And (GRVDeposit_Type = " & ltype & ") And (GRVDeposit.GRVDeposit_Return=" & orderType & ");"
					cnnDB.Execute(sql)
					If CShort(txtEdit.Text) <> 0 Then
						sql = "INSERT INTO GRVDeposit (GRVDeposit_GRVID, GRVDeposit_DepositID, GRVDeposit_Type, GRVDeposit_Return, GRVDeposit_Quantity) VALUES "
						sql = sql & "(" & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ", " & gridItem.get_RowData(gridItem.row) & ", " & ltype & ", " & orderType & ", " & CShort(txtEdit.Text) & ")"
						cnnDB.Execute(sql)
					End If
					gridItem.set_TextMatrix(gridItem.row, colQuantity, txtEdit.Text)
					txtEdit.Tag = txtEdit.Text
			End Select
		End If
	End Sub
	
	
	
	
	Private Sub picButtons_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles picButtons.Resize
        cmdExit.Left = twipsToPixels(pixelToTwips(picButtons.ClientRectangle.Width, True) - pixelToTwips(cmdExit.Width, True) - 30, True)
        cmdNext.Left = twipsToPixels(pixelToTwips(cmdExit.Left, True) - pixelToTwips(cmdNext.Width, True) - 150, True)
        cmdBack.Left = twipsToPixels(pixelToTwips(cmdNext.Left, True) - pixelToTwips(cmdBack.Width, True) - 45, True)
		
	End Sub
	
	Private Sub txtEdit_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtEdit.TextChanged
		If loading Then Exit Sub
		Dim lValue As Integer
		With gridItem
			If .row Then
				If txtEdit.Text = "" Then lValue = 0 Else lValue = CInt(txtEdit.Text)
				.set_TextMatrix(.row, colQuantity, lValue)
				.set_TextMatrix(.row, colExclusiveAmount, FormatNumber(CDbl(.get_TextMatrix(.row, colExclusivePrice)) * lValue, 2))
				.set_TextMatrix(.row, colInclusiveAmount, FormatNumber(CDbl(.get_TextMatrix(.row, colInclusivePrice)) * lValue, 2))
			End If
		End With
		
		doTotals()
	End Sub
	
	Private Sub txtEdit_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtEdit.Leave
		update_Renamed()
	End Sub
	
	
	Public Sub loadDeposits(ByRef ltype As Short)
		
		'ResizeForm frmGRVDeposit, frmGRVDeposit.Width, frmGRVDeposit.Height, 2
		
		orderType = ltype
		setup()
		getOrder()
		If gridItem.RowCount Then
			loading = True
			gridItem.Col = 0
			gridItem.row = 0
			loading = False
			If gridItem.RowCount > 1 Then
				gridItem.Col = 1
				gridItem.row = 1
				txtEdit.Visible = True
			Else
				txtEdit.Visible = False
			End If
		End If
		frmGRVDeposit_Resize(Me, New System.EventArgs())
		
		loadLanguage()
		If Me.Visible Then 
		Else 
			ShowDialog()
		End If
	End Sub
	
    Private Sub gridItem_EnterCell(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles gridItem.Enter
        On Error Resume Next
        If loading Then Exit Sub
        With gridItem
            If .Col <> colQuantity Then
                .Col = colQuantity
                Exit Sub
            End If
            If .row Then
                txtEdit.SetBounds(twipsToPixels(pixelToTwips(.Left, True) + .CellLeft, True), _
                                  twipsToPixels(pixelToTwips(.Top, False) + .CellTop, False), _
                                  twipsToPixels(.CellWidth, True), _
                                  twipsToPixels(.CellHeight, False))
                loading = True
                txtEdit.Text = .Text
                txtEdit.Text = Replace(.Text, ".", "")
                txtEdit.Text = Replace(.Text, ",", "")
                If txtEdit.Text = "000" Then txtEdit.Text = "0"
                txtEdit.Tag = txtEdit.Text
                If VB.Left(gridItem.get_TextMatrix(gridItem.row, colName), 4) = "*** " Then
                Else

                    .set_TextMatrix(.row, colName, "*** " & .get_TextMatrix(.row, colName))
                End If
                loading = False
                txtEdit.Visible = True
                If Me.Visible Then txtEdit.Focus()
            End If
        End With
    End Sub
	
	Private Sub gridItem_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles gridItem.Enter
		txtEdit_Enter(txtEdit, New System.EventArgs())
	End Sub
	
    Private Sub gridItem_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles gridItem.KeyPress
        Select Case eventArgs.KeyChar
            Case ChrW(40)
                eventArgs.KeyChar = ChrW(0)
        End Select

    End Sub
	
    Private Sub gridItem_LeaveCell(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles gridItem.Leave
        update_Renamed()
        If VB.Left(gridItem.get_TextMatrix(gridItem.row, colName), 4) = "*** " Then
            gridItem.set_TextMatrix(gridItem.row, colName, Mid(gridItem.get_TextMatrix(gridItem.row, colName), 5))
        End If
    End Sub

	Private Sub txtEdit_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtEdit.Enter
		txtEdit.SelectionStart = 0
		txtEdit.SelectionLength = 999
	End Sub
	
	Private Sub txtEdit_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtEdit.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		With Me.gridItem
			Select Case KeyCode
				Case 27 'ESC
					txtEdit.Visible = False
					.Focus()
				Case 13 'ENTER
					.Focus()
					System.Windows.Forms.Application.DoEvents()
					moveNext(1)
				Case 37 'Left arrow
					If txtEdit.SelectionStart = 0 And txtEdit.SelectionLength = 0 Then
						.Focus()
						System.Windows.Forms.Application.DoEvents()
						moveNext(-1)
					End If
				Case 39 'Right arrow
					If txtEdit.SelectionStart = Len(txtEdit.Text) Then
						.Focus()
						System.Windows.Forms.Application.DoEvents()
						moveNext(1)
					End If
				Case 38 'Up arrow
					.Focus()
					System.Windows.Forms.Application.DoEvents()
					moveNext(-1)
				Case 40 'Down arrow
					.Focus()
					System.Windows.Forms.Application.DoEvents()
					moveNext(1)
			End Select
		End With
	End Sub
    Private Function moveNext(ByRef direction As Short) As Boolean
        Dim x As Short
        Dim y As Short

        x = gridItem.row + direction

        If x >= gridItem.RowCount Or x < gridItem.FixedRows Then
        Else
            gridItem.row = x
        End If

        txtEdit.SelectionStart = 0
        txtEdit.SelectionLength = 999
        txtEdit.Focus()

        moveNext = True
    End Function
	
	Private Sub txtEdit_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtEdit.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
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
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class