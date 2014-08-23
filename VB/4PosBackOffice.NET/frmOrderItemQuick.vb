Option Strict Off
Option Explicit On
Friend Class frmOrderItemQuick
	Inherits System.Windows.Forms.Form
	Dim adoPrimaryRS As ADODB.Recordset
	
	Private Sub loadLanguage()
		
		'frmOrderItemQuick = No Code      [GRV Quick Edit]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmOrderItemQuick.Caption = rsLang("LanguageLayoutLnk_Description"): frmOrderItemQuick.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblName = No Code/Dynamic/NA?
		
		'chkBreakPack = No Code         [Break Pack]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkBreakPack.Caption = rsLang("LanguageLayoutLnk_Description"): chkBreakPack.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_0 = No Code               [Quantity]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'    rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1151 'Price|Checked
		'    If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		'
		'    rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1662 'Discount|Checked
		'    If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		'
		'_lbl_1 = No Code               [Surcharges]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'    rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1217 'Proceed|Checked
		'    If rsLang.RecordCount Then cmdProceed.Caption = rsLang("LanguageLayoutLnk_Description"): cmdProceed.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		'
		'    rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'    If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp("Help_ContextID")
		
	End Sub
	
    Private Sub chkBreakPack_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'If chkBreakPack.value Then
        ' Me.txtMin.Tag = adoPrimaryRS.Fields("StockItem_UnitCost").Value
        ' Else
        ' Me.txtMin.Tag = adoPrimaryRS.Fields("StockItem_ListCost").Value
        ' End If

        Select Case frmGRVitem.activePrice
            Case 0
                Me.txtMin.Text = FormatNumber(Me.txtMin.Tag, 2)
            Case 1
                Me.txtMin.Text = FormatNumber(CDec(txtMin.Tag) * (1 + CDbl(frmGRVitem.gridItem.get_TextMatrix(frmGRVitem.gridItem.row, frmGRVitem.colVAT)) / 100), 2)

            Case 2
                Me.txtMin.Text = FormatNumber(CDec(Me.txtMin.Tag) + CDec(frmGRVitem.gridItem.get_TextMatrix(frmGRVitem.gridItem.row, frmGRVitem.colDepositExclusive)), 2)
            Case 3
                Me.txtMin.Text = FormatNumber((CDec(Me.txtMin.Tag) + CDec(frmGRVitem.gridItem.get_TextMatrix(frmGRVitem.gridItem.row, frmGRVitem.colDepositExclusive))) * (1 + CDbl(frmGRVitem.gridItem.get_TextMatrix(frmGRVitem.gridItem.row, frmGRVitem.colVAT)) / 100), 2)
        End Select
    End Sub
	
	Private Sub chkBreakPack_KeyPress(ByRef KeyAscii As Short)
		If KeyAscii = 27 Then
			Me.Close()
		End If
		
	End Sub
	
	Private Sub cmdProceed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdProceed.Click
        Dim sql As String
		Dim dirty As Boolean
		dirty = False
		Dim lPrice, lDiscount As Decimal
		
		If CDbl(txtCost.Tag) <> CDec(txtCost.Text) Then dirty = True
		If CDbl(txtMin.Tag) <> CShort(txtMin.Text) Then dirty = True
		If CDbl(txtMax.Tag) <> CShort(txtMax.Text) Then dirty = True
		
		If dirty Then
			sql = "UPDATE MinMaxStockItemLnk SET MinMaxStockItemLnk_Minimum = " & CShort(txtMin.Text) & " Where (MinMaxStockItemLnk_MinMaxID = 1) And (MinMaxStockItemLnk_StockItemID = " & CShort(Me.lblName.Tag) & ")"
			cnnDB.Execute(sql)
			
			cnnDB.Execute("UPDATE StockItem SET StockItem.StockItem_MinimumStock = " & CShort(txtMin.Text) & ", StockItem_OrderRounding = " & CShort(txtMax.Text) & " WHERE StockItemID = " & CShort(Me.lblName.Tag) & ";")
		End If
		Me.Close()
	End Sub
	
	Private Sub frmOrderItemQuick_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		If frmOrderWizard.Tag <> "" Then
			loadLanguage()
			
			Me.lblName.Tag = Split(frmOrderWizard.Tag, "|")(0)
			Me.lblName.Text = Split(frmOrderWizard.Tag, "|")(1)
			
			Me.txtCost.Text = Split(frmOrderWizard.Tag, "|")(2)
			Me.txtMin.Text = Split(frmOrderWizard.Tag, "|")(4)
			Me.txtMax.Text = Split(frmOrderWizard.Tag, "|")(3)
			
			txtCost.Tag = CDec(txtCost.Text)
			txtMin.Tag = CDec(txtMin.Text)
			txtMax.Tag = CDec(txtMax.Text)
			
		Else
			Me.Close()
		End If
	End Sub
	
	Private Sub txtMax_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMax.Enter
        MyGotFocusNumeric(txtMax)
	End Sub
	
	Private Sub txtMax_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtMax.KeyPress
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
	
	Private Sub txtMax_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMax.Leave
        MyLostFocus(txtMax, 0)
	End Sub
	Private Sub txtMin_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMin.Enter
        MyGotFocusNumeric(txtMin)
	End Sub
	
	Private Sub txtMin_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtMin.KeyPress
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
	
	Private Sub txtMin_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMin.Leave
        MyLostFocus(txtMin, 0)
	End Sub
	
	Private Sub txtCost_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCost.Enter
        MyGotFocusNumeric(txtCost)
	End Sub
	
	Private Sub txtCost_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCost.KeyPress
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
	
	Private Sub txtCost_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCost.Leave
        MyLostFocus(txtCost, 2)
	End Sub
End Class