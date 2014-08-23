Option Strict Off
Option Explicit On
Friend Class frmGRVPromotionItem
	Inherits System.Windows.Forms.Form
	Dim gStockItemID As Integer
	Dim gPromotionID As Integer
	Dim gQuantity As Integer
	
	Private Sub loadLanguage()
		
		'frmPromotionItem = No Code     [Edit Promotion Item]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmPromotionItem.Caption = rsLang("LanguageLayoutLnk_Description"): frmPromotionItem.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1139 'Promotion Name|Checked
		If rsLang.RecordCount Then _lbl_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1935 'Stock Item Name|Checked
		If rsLang.RecordCount Then _lbl_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2145 'Shrink Size|Checked
		If rsLang.RecordCount Then _lbl_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1151 'Price|Checked
		If rsLang.RecordCount Then _lbl_3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmGRVPromotionItem.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub loadData()
		Dim rs As ADODB.Recordset
		If gQuantity Then
			
			rs = getRS("SELECT GRVPromotionItem.*, StockItem.StockItem_Name, GRVPromotion.Promotion_Name FROM GRVPromotion INNER JOIN (GRVPromotionItem INNER JOIN StockItem ON GRVPromotionItem.PromotionItem_StockItemID = StockItem.StockItemID) ON GRVPromotion.PromotionID = GRVPromotionItem.PromotionItem_PromotionID WHERE GRVPromotionItem.PromotionItem_PromotionID=" & gPromotionID & " AND GRVPromotionItem.PromotionItem_StockItemID=" & gStockItemID & " AND GRVPromotionItem.PromotionItem_Quantity=" & gQuantity)
			If rs.RecordCount Then
				lblStockItem.Text = rs.Fields("StockItem_Name").Value
				lblPromotion.Text = rs.Fields("Promotion_Name").Value
				txtPrice.Text = CStr(rs.Fields("PromotionItem_Price").Value * 100)
				txtPrice_Leave(txtPrice, New System.EventArgs())
				cmbQuantity.Tag = gQuantity
			Else
				Me.Close()
				Exit Sub
			End If
		Else
			'Set rs = getRS("SELECT GRVPromotion.Promotion_Name, StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM Promotion, StockItem INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID WHERE (((Promotion.PromotionID)=" & gPromotionID & ") AND ((StockItem.StockItemID)=" & gStockItemID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
			rs = getRS("SELECT GRVPromotion.Promotion_Name, StockItem.StockItem_Name, StockItem.StockItem_Quantity, StockItem.StockItem_ListCost from GRVPromotion, StockItem WHERE (((GRVPromotion.PromotionID)=" & gPromotionID & ") AND ((StockItem.StockItemID)=" & gStockItemID & "));")
			If rs.RecordCount Then
				lblStockItem.Text = rs.Fields("StockItem_Name").Value
				lblPromotion.Text = rs.Fields("Promotion_Name").Value
				txtPrice.Text = CStr(rs.Fields("StockItem_ListCost").Value * 100)
				txtPrice_Leave(txtPrice, New System.EventArgs())
				cmbQuantity.Tag = rs.Fields("StockItem_Quantity").Value
			Else
				Me.Close()
				Exit Sub
			End If
			
		End If
		rs = getRS("SELECT StockItem.StockItem_Quantity From StockItem Where (((StockItem.StockItemID) = " & gStockItemID & "));")
        cmbQuantity.Items.Clear()
        Dim m As Integer
		Do Until rs.EOF
            m = cmbQuantity.Items.Add(rs.Fields("StockItem_Quantity").Value)
			If cmbQuantity.Tag = rs.Fields("StockItem_Quantity").Value Then
				cmbQuantity.SelectedIndex = m
			End If
			rs.moveNext()
		Loop 
	End Sub
	Public Sub loadItem(ByRef promotionID As Integer, ByRef stockitemID As Integer, Optional ByRef quantity As Integer = 0)
		gStockItemID = stockitemID
		gPromotionID = promotionID
		gQuantity = quantity
		loadData()
		
		loadLanguage()
		ShowDialog()
	End Sub
	Private Sub frmGRVPromotionItem_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim mbAddNewFlag As Boolean
        Dim mbEditFlag As Boolean
		If mbEditFlag Or mbAddNewFlag Then GoTo EventExitSub
		
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.Escape
				KeyAscii = 0
				cmdClose.Focus()
				System.Windows.Forms.Application.DoEvents()
				cmdClose_Click(cmdClose, New System.EventArgs())
		End Select
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub cmdCancel_Click()
        Dim mbDataChanged As Boolean
        Dim mvBookMark As Integer
        Dim adoPrimaryRS As ADODB.Recordset
        Dim mbAddNewFlag As Boolean
        Dim mbEditFlag As Boolean
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
	
	Private Function update_Renamed() As Boolean
		On Error GoTo UpdateErr
		update_Renamed = True
		cnnDB.Execute("DELETE GRVPromotionItem.* From GRVPromotionItem WHERE (((GRVPromotionItem.PromotionItem_PromotionID)=" & gPromotionID & ") AND ((GRVPromotionItem.PromotionItem_StockItemID)=" & gStockItemID & ") AND ((GRVPromotionItem.PromotionItem_Quantity)=" & gQuantity & "));")
        cnnDB.Execute("DELETE GRVPromotionItem.* From GRVPromotionItem WHERE (((GRVPromotionItem.PromotionItem_PromotionID)=" & gPromotionID & ") AND ((GRVPromotionItem.PromotionItem_StockItemID)=" & gStockItemID & ") AND ((GRVPromotionItem.PromotionItem_Quantity)=" & CStr(Me.cmbQuantity.SelectedIndex) & "));")
		'cnnDB.Execute "DELETE GRVPromotionItem.* From GRVPromotionItem WHERE (((GRVPromotionItem.PromotionItem_PromotionID)=" & gPromotionID & ") AND ((GRVPromotionItem.PromotionItem_StockItemID)=" & gStockItemID & ") AND ((GRVPromotionItem.PromotionItem_Quantity)=" & 0 & "));"
		
        cnnDB.Execute("INSERT INTO GRVPromotionItem ( PromotionItem_PromotionID, PromotionItem_StockItemID, PromotionItem_Quantity, PromotionItem_Price ) SELECT " & gPromotionID & " , " & gStockItemID & ", " & CStr(Me.cmbQuantity.SelectedIndex) & ", " & CDec(Me.txtPrice.Text))
		
		
		Exit Function
UpdateErr: 
		MsgBox(Err.Description)
		update_Renamed = True
	End Function
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		cmdClose.Focus()
		System.Windows.Forms.Application.DoEvents()
		If update_Renamed() Then
			Me.Close()
		End If
	End Sub
	Private Sub txtPrice_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPrice.Enter
        MyGotFocusNumeric(txtPrice)
	End Sub
	
	Private Sub txtPrice_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtPrice.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        MyKeyPressNegative(txtPrice, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtPrice_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPrice.Leave
        MyLostFocus(txtPrice, 2)
	End Sub
End Class