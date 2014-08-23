Option Strict Off
Option Explicit On
Friend Class frmGRVItemQuick
	Inherits System.Windows.Forms.Form
	Dim adoPrimaryRS As ADODB.Recordset
	
	Private Sub loadLanguage()
		
		'frmGRVItemQuick = No Code      [GRV Quick Edit]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmGRVItemQuick.Caption = rsLang("LanguageLayoutLnk_Description"): frmGRVItemQuick.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblName = No Code/Dynamic/NA?
		
		'chkBreakPack = No Code         [Break Pack]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkBreakPack.Caption = rsLang("LanguageLayoutLnk_Description"): chkBreakPack.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_0 = No Code               [Quantity]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1151 'Price|Checked
		If rsLang.RecordCount Then _lbl_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1662 'Discount|Checked
		If rsLang.RecordCount Then Label1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lbl_1 = No Code               [Surcharges]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1217 'Proceed|Checked
		If rsLang.RecordCount Then cmdProceed.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdProceed.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmGRVItemQuick.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	'UPGRADE_WARNING: Event chkBreakPack.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkBreakPack_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkBreakPack.CheckStateChanged
		If chkBreakPack.CheckState Then
			Me.txtPrice.Tag = adoPrimaryRS.Fields("StockItem_UnitCost").Value
		Else
			Me.txtPrice.Tag = adoPrimaryRS.Fields("StockItem_ListCost").Value
		End If
		Select Case frmGRVitem.activePrice
			Case 0
				Me.txtPrice.Text = FormatNumber(Me.txtPrice.Tag, 2)
			Case 1
				Me.txtPrice.Text = FormatNumber(CDec(txtPrice.Tag) * (1 + CDbl(frmGRVitem.gridItem.get_TextMatrix(frmGRVitem.gridItem.row, frmGRVitem.colVAT)) / 100), 2)
				
			Case 2
				Me.txtPrice.Text = FormatNumber(CDec(Me.txtPrice.Tag) + CDec(frmGRVitem.gridItem.get_TextMatrix(frmGRVitem.gridItem.row, frmGRVitem.colDepositExclusive)), 2)
			Case 3
				Me.txtPrice.Text = FormatNumber((CDec(Me.txtPrice.Tag) + CDec(frmGRVitem.gridItem.get_TextMatrix(frmGRVitem.gridItem.row, frmGRVitem.colDepositExclusive))) * (1 + CDbl(frmGRVitem.gridItem.get_TextMatrix(frmGRVitem.gridItem.row, frmGRVitem.colVAT)) / 100), 2)
		End Select
	End Sub
	
	Private Sub chkBreakPack_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles chkBreakPack.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 27 Then
			Me.Close()
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub cmdProceed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdProceed.Click
        Dim sql As String
		Dim dirty As Boolean
		dirty = False
		Dim lPrice, lDiscount As Decimal
		If CDbl(chkBreakPack.Tag) <> CShort(chkBreakPack.CheckState) Then dirty = True
		If CDbl(txtQuantity.Tag) <> CShort(txtQuantity.Text) Then dirty = True
		If CDbl(txtPrice.Tag) <> CDec(txtPrice.Text) Then dirty = True
		If CDbl(txtDiscountMinus.Tag) <> CDec(txtDiscountMinus.Text) Then dirty = True
		If CDbl(txtDiscountPlus.Tag) <> CDec(txtDiscountPlus.Text) Then dirty = True
		
		If dirty Then
			Select Case frmGRVitem.activePrice
				Case 0
					lPrice = CDec(Me.txtPrice.Text)
				Case 1
					lPrice = CDec(txtPrice.Tag) / (1 + CDbl(frmGRVitem.gridItem.get_TextMatrix(frmGRVitem.gridItem.row, frmGRVitem.colVAT)) / 100)
				Case 2
					lPrice = (CDec(txtPrice.Tag) - CDec(frmGRVitem.gridItem.get_TextMatrix(frmGRVitem.gridItem.row, frmGRVitem.colDepositExclusive)))
				Case 3
					lPrice = (CDec(txtPrice.Tag) - CDec(frmGRVitem.gridItem.get_TextMatrix(frmGRVitem.gridItem.row, frmGRVitem.colDepositInclusive))) / (1 + CDbl(frmGRVitem.gridItem.get_TextMatrix(frmGRVitem.gridItem.row, frmGRVitem.colVAT)) / 100)
			End Select
			lDiscount = CDec(txtDiscountPlus.Text) - CDec(txtDiscountMinus.Text)
			If frmGRVitem.gridItem.get_ColWidth(frmGRVitem.colDiscount) Then
			ElseIf frmGRVitem.gridItem.get_ColWidth(frmGRVitem.colDiscountLine) Then 
				lDiscount = lDiscount / CShort(txtQuantity.Text)
			ElseIf frmGRVitem.gridItem.get_ColWidth(frmGRVitem.colDiscountPercentage) Then 
				lDiscount = CDec(frmGRVitem.gridItem.get_TextMatrix(frmGRVitem.gridItem.row, frmGRVitem.colContentExclusive)) * lDiscount / 100
			End If
			If frmGRVitem.activePrice = 1 Or frmGRVitem.activePrice = 3 Then
				lDiscount = lDiscount / (1 + CDbl(frmGRVitem.gridItem.get_TextMatrix(frmGRVitem.gridItem.row, frmGRVitem.colVAT)) / 100)
			End If
			
			If chkBreakPack.CheckState Then
				lPrice = lPrice * CShort(adoPrimaryRS.Fields("StockItem_Quantity").Value)
				sql = "UPDATE GRVItem SET GRVItem_PackSize = 1, GRVItem_Quantity = " & txtQuantity.Text & ", GRVItem_ContentCost = " & lPrice & ", GRVItem_DiscountAmount = " & lDiscount & " WHERE  (GRVItem_GRVID = " & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") And (GRVItem_StockItemID = " & frmGRVitem.gridItem.get_RowData(frmGRVitem.gridItem.row) & ") And (GRVItem_return = " & frmGRVitem.orderType & ")"
			Else
				sql = "UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_PackSize = [StockItem]![StockItem_OrderQuantity], GRVItem.GRVItem_Quantity = " & CShort(txtQuantity.Text) & ", GRVItem.GRVItem_ContentCost = " & lPrice & ", GRVItem.GRVItem_DiscountAmount = " & lDiscount & "  WHERE  (GRVItem_GRVID = " & frmGRV.adoPrimaryRS.Fields("GRVID").Value & ") And (GRVItem_StockItemID = " & frmGRVitem.gridItem.get_RowData(frmGRVitem.gridItem.row) & ") And (GRVItem_return = " & frmGRVitem.orderType & ")"
				
				
			End If
			cnnDB.Execute(sql)
			frmGRVitem.gridItem.set_TextMatrix(frmGRVitem.gridItem.row, frmGRVitem.colCode, "RELOAD")
		End If
		Me.Close()
	End Sub
	
	Private Sub frmGRVItemQuick_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		adoPrimaryRS = getRS("SELECT  StockItem_ListCost, StockItem_ListCost / StockItem_Quantity AS StockItem_UnitCost, StockItem_Quantity From StockItem Where (StockItemID = " & frmGRVitem.gridItem.get_RowData(frmGRVitem.gridItem.row) & ")")
		If adoPrimaryRS.BOF Or adoPrimaryRS.EOF Then
			Me.Close()
		Else
			loadLanguage()
			
			Me.lblName.Text = frmGRVitem.gridItem.get_TextMatrix(frmGRVitem.gridItem.row, frmGRVitem.colName)
			If frmGRVitem.gridItem.get_TextMatrix(frmGRVitem.gridItem.row, frmGRVitem.colBrokenPack) = "X" Then
				chkBreakPack.CheckState = System.Windows.Forms.CheckState.Checked
			Else
				chkBreakPack.CheckState = System.Windows.Forms.CheckState.Unchecked
			End If
			chkBreakPack.Tag = chkBreakPack.CheckState
			Me.txtQuantity.Text = frmGRVitem.gridItem.get_TextMatrix(frmGRVitem.gridItem.row, frmGRVitem.colQuantity)
			Me.txtDiscountMinus.Text = FormatNumber(0, 2)
			If frmGRVitem.gridItem.get_ColWidth(frmGRVitem.colDiscount) Then
				Me.txtDiscountPlus.Text = FormatNumber(frmGRVitem.gridItem.get_TextMatrix(frmGRVitem.gridItem.row, frmGRVitem.colDiscount), 2)
			ElseIf frmGRVitem.gridItem.get_ColWidth(frmGRVitem.colDiscountLine) Then 
				Me.txtDiscountPlus.Text = FormatNumber(frmGRVitem.gridItem.get_TextMatrix(frmGRVitem.gridItem.row, frmGRVitem.colDiscountLine), 2)
			ElseIf frmGRVitem.gridItem.get_ColWidth(frmGRVitem.colDiscountPercentage) Then 
				Me.txtDiscountPlus.Text = FormatNumber(frmGRVitem.gridItem.get_TextMatrix(frmGRVitem.gridItem.row, frmGRVitem.colDiscountPercentage), 2)
			Else
				Me.txtDiscountPlus.Text = CStr(0)
			End If
			chkBreakPack_CheckStateChanged(chkBreakPack, New System.EventArgs())
			txtQuantity.Tag = CShort(txtQuantity.Text)
			txtPrice.Tag = CDec(txtPrice.Text)
			txtDiscountMinus.Tag = CDec(txtDiscountMinus.Text)
			txtDiscountPlus.Tag = CDec(txtDiscountPlus.Text)
		End If
	End Sub
	
	Private Sub txtDiscountMinus_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtDiscountMinus.Enter
        MyGotFocusNumeric(txtDiscountMinus)
	End Sub
	
	Private Sub txtDiscountMinus_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscountMinus.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 27 Then
			Me.Close()
		Else
            MyKeyPress(KeyAscii)
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtDiscountMinus_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtDiscountMinus.Leave
        MyLostFocus(txtDiscountMinus, 2)
	End Sub
	
	Private Sub txtDiscountPlus_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtDiscountPlus.Enter
		MyGotFocusNumeric(txtDiscountPlus)
	End Sub
	
	Private Sub txtDiscountPlus_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscountPlus.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 27 Then
			Me.Close()
		Else
            MyKeyPress(KeyAscii)
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtDiscountPlus_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtDiscountPlus.Leave
        MyLostFocus(txtDiscountPlus, 2)
	End Sub
	Private Sub txtPrice_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPrice.Enter
        MyGotFocusNumeric(txtPrice)
	End Sub
	
	Private Sub txtPrice_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtPrice.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 27 Then
			Me.Close()
		Else
            MyKeyPress(KeyAscii)
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtPrice_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPrice.Leave
        MyLostFocus(txtPrice, 2)
	End Sub
	
	Private Sub txtQuantity_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQuantity.Enter
        MyGotFocusNumeric(txtQuantity)
	End Sub
	
	Private Sub txtQuantity_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtQuantity.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 27 Then
			Me.Close()
		Else
            MyKeyPress(KeyAscii)
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtQuantity_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQuantity.Leave
        MyLostFocus(txtQuantity, 0)
	End Sub
End Class