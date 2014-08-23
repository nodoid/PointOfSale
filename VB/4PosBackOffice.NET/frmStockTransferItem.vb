Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmStockTransferItem
	Inherits System.Windows.Forms.Form
	Dim gStockItemID As Integer
	Dim gPromotionID As Integer
	Dim gQuantity As Integer
	
	Private Sub loadLanguage()
		
		'frmStockTransferItem = No Code     [Edit Stock Transfer Item]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmStockTransferItem.Caption = rsLang("LanguageLayoutLnk_Description"): frmStockTransferItem.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1139 'Promotion Name|Checked
		'If rsLang.RecordCount Then lblPComp.Caption = rsLang("LanguageLayoutLnk_Description"): lblPComp.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1935 'Stock Item Name|Checked
		If rsLang.RecordCount Then _lbl_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lbl_2 = No Code                   [Item Qty]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label2 = No Code                   [Please verify Products from both Locations]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label2.Caption = rsLang("LanguageLayoutLnk_Description"): Label2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1139 'Promotion Name|Checked
		'If rsLang.RecordCount Then lblSComp.Caption = rsLang("LanguageLayoutLnk_Description"): lblSComp.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1935 'Stock Item Name|Checked
		If rsLang.RecordCount Then _lbl_5.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_5.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1151 'Price|Checked
		If rsLang.RecordCount Then _lbl_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmStockTransferItem.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub loadData()
		Dim rs As ADODB.Recordset
		Dim rj As ADODB.Recordset
		
		Dim cn As ADODB.Connection
		Dim rt As ADODB.Recordset
		If gQuantity Then
			
			rs = getRS("SELECT StockTransferGRV.*, StockItem.StockItem_Name, StockItem.StockItem_Quantity, StockItem.StockItem_ListCost FROM StockTransferGRV INNER JOIN StockItem ON StockTransferGRV.StockTransfer_StockItemID = StockItem.StockItemID WHERE StockTransferGRV.StockTransfer_StockItemID=" & gStockItemID & " AND StockTransferGRV.StockTransfer_Quantity=" & gQuantity)
			'Set rs = getRS("SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & gStockItemID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
			If rs.RecordCount Then
				lblStockItem.Text = rs.Fields("StockItem_Name").Value
				'lblPromotion.Caption = rs("Promotion_Name")
				txtPrice.Text = CStr(rs.Fields("StockItem_ListCost").Value * 100)
				txtPrice.Tag = rs.Fields("StockItem_ListCost").Value
				txtPrice_Leave(txtPrice, New System.EventArgs())
				'cmbQuantity.Tag = gQuantity
				txtPSize.Text = rs.Fields("StockItem_Quantity").Value
				txtQtyT.Text = rs.Fields("StockTransfer_Quantity").Value '* 100
				
				If CDbl(txtPSize.Text) <> 1 Then
					txtPrice.Text = FormatNumber(CDec(txtPrice.Tag) / CDec(txtPSize.Text), 2)
				End If
				'txtQty.SetFocus
                Me.Height = twipsToPixels(2850, False)
				
				loadLanguage()
				ShowDialog()
			Else
				Me.Close()
				Exit Sub
			End If
		Else
			'Set rs = getRS("SELECT Promotion.Promotion_Name, StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM Promotion, StockItem INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID WHERE (((Promotion.PromotionID)=" & gPromotionID & ") AND ((StockItem.StockItemID)=" & gStockItemID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
			'Set rs = getRS("SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM StockItem INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID WHERE (((StockItem.StockItemID)=" & gStockItemID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
			
			rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_Quantity, StockItem.StockItem_ListCost, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & gStockItemID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
			'Set rs = getRS("SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & gStockItemID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
			If rs.RecordCount Then
			Else
				'MsgBox "Supplier Qty is different from Catalogue Qty. Be advised wizard will transfer in singles!"
				txtPack.Text = CStr(0)
				rs.Close()
				rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_Quantity, StockItem.StockItem_ListCost, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & gStockItemID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
			End If
			If rs.RecordCount Then
				lblStockItem.Text = rs.Fields("StockItem_Name").Value
				'lblPromotion.Caption = rs("Promotion_Name")
				txtPrice.Text = CStr(rs.Fields("StockItem_ListCost").Value * 100) 'rs("CatalogueChannelLnk_Price") * 100
				txtPrice.Tag = rs.Fields("StockItem_ListCost").Value
				txtPrice_Leave(txtPrice, New System.EventArgs())
				'cmbQuantity.Tag = rs("CatalogueChannelLnk_Quantity")
				txtPSize.Text = rs.Fields("StockItem_Quantity").Value
				
				If CDbl(txtPSize.Text) <> 1 Then
					txtPrice.Text = FormatNumber(CDec(txtPrice.Tag) / CDec(txtPSize.Text), 2)
				End If
				
				rj = getRS("SELECT Catalogue_StockItemID, Catalogue_Barcode FROM Catalogue Where Catalogue_StockItemID = " & gStockItemID & " AND Catalogue_Quantity=1 Order By Catalogue_Quantity;")
				If rs.RecordCount Then
					If frmStockTransfer.loadDBStr = "" Then
						MsgBox("Please setup first other location to transfer!")
						Me.Close()
					Else
						cn = openSComp(frmStockTransfer.loadDBStr)
						If cn Is Nothing Then
							MsgBox("Please setup first other location to transfer!")
							Me.Close()
						Else
							
							lblSComp.Text = frmStockTransfer.lblSComp.Text
							'Set rT = getRSwaitron("SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price, Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Barcode FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((Catalogue.Catalogue_Barcode)='" & rj("Catalogue_Barcode") & "') AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));", cn)
							rt = getRSwaitron("SELECT StockItem.StockItem_Name, Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Barcode FROM Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID) WHERE (((Catalogue.Catalogue_Barcode)='" & rj.Fields("Catalogue_Barcode").Value & "'));", cn)
							If rt.RecordCount Then
								lblStockItemS.Text = rt.Fields("StockItem_Name").Value
								'txtPriceS.Text = rT("CatalogueChannelLnk_Price") * 100
								'txtPriceS_LostFocus
								
                                Me.Height = twipsToPixels(4215, False) '3810
								
								loadLanguage()
								ShowDialog()
								
							Else
								'MsgBox "Barcode not found for  '" & UCase(rs("StockItem_Name")) & "'  in  '" & UCase(lblSComp.Caption) & "'  you wish to transfer the stock!"
								MsgBox("No corresponding Barcode found for  '" & UCase(rs.Fields("StockItem_Name").Value) & "'  in the receiving company. A transfer cannot be done at this time!")
								Me.Close()
							End If
						End If
					End If
					
				Else
					MsgBox("No Barcode for the current item!")
					Me.Close()
				End If
				
			Else
				MsgBox("Could not load Stock Item. Please check Supplier Qty, Barcode for Stock Item.!")
				Me.Close()
				Exit Sub
			End If
		End If

	End Sub
	
	'Public Sub loadItem(promotionID As Long, stockitemID As Long, Optional quantity As Long)
	Public Sub loadItem(ByRef stockitemID As Integer, Optional ByRef quantity As Integer = 0)
		gStockItemID = stockitemID
		'gPromotionID = promotionID
		gQuantity = quantity
		lblPComp.Text = frmStockTransfer.lblPComp.Text
		loadData()
		
		'show 1
		
	End Sub
	
	Private Sub cmdPack_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPack.Click
		If CDbl(txtPSize.Text) <> 1 Then
			cmdPack.Tag = txtPSize.Text
			txtPSize.Text = CStr(1)
			'txtPrice = FormatNumber(CCur(txtPrice.Tag) / CCur(cmdPack.Tag), 2)
		Else
			If cmdPack.Tag <> "" Then txtPSize.Text = cmdPack.Tag
			'txtPrice = FormatNumber(txtPrice.Tag, 2)
		End If
		
		If txtQtyT.Text = "" Then txtQtyT.Text = "0"
		If IsNumeric(txtQtyT.Text) Then 
		Else 
			txtQtyT.Text = "0"
		End If
		txtQty.Text = CStr(CDbl(txtQtyT.Text) * CDbl(txtPSize.Text))
		
		txtQtyT.Focus()
	End Sub
	
	Private Sub frmStockTransferItem_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim mbAddNewFlag As Object
		Dim mbEditFlag As Object
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
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		On Error Resume Next
		'If mbAddNewFlag Then
		Me.Close()
		'Else
		'mbEditFlag = False
		'mbAddNewFlag = False
		'adoPrimaryRS.CancelUpdate
		'If mvBookMark > 0 Then
		'    adoPrimaryRS.Bookmark = mvBookMark
		'Else
		'    adoPrimaryRS.MoveFirst
		'End If
		'mbDataChanged = False
		'End If
	End Sub
	
	'UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Function update_Renamed() As Boolean
		On Error GoTo UpdateErr
		update_Renamed = True
		cnnDB.Execute("DELETE StockTransferGRV.* From StockTransferGRV WHERE (((StockTransferGRV.StockTransfer_StockItemID)=" & gStockItemID & ") AND ((StockTransferGRV.StockTransfer_Quantity)=" & gQuantity & "));")
		cnnDB.Execute("DELETE StockTransferGRV.* From StockTransferGRV WHERE (((StockTransferGRV.StockTransfer_StockItemID)=" & gStockItemID & "));")
		
		'OLD     cnnDB.Execute "INSERT INTO StockTransferGRV ( StockTransfer_StockItemID, StockTransfer_Quantity, StockTransfer_Price ) SELECT " & gStockItemID & ", " & CCur(Me.txtQty.Text) & ", " & CCur(Me.txtPrice.Text)
		cnnDB.Execute("INSERT INTO StockTransferGRV ( StockTransfer_StockItemID, StockTransfer_Quantity, StockTransfer_Price, StockTransfer_Pack ) SELECT " & gStockItemID & ", " & CDec(Me.txtQty.Text) & ", " & CDec(Me.txtPrice.Text) & ", " & Me.txtPack.Text)
		
		Exit Function
UpdateErr: 
		MsgBox(Err.Description)
		update_Renamed = True
	End Function
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		cmdClose.Focus()
		System.Windows.Forms.Application.DoEvents()
		If CDec(txtQty.Text) > 0 Then
		Else
			txtQty.Focus()
			Exit Sub
		End If
		
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
	
	Private Sub txtPriceS_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPriceS.Enter
		MyGotFocusNumeric(txtPriceS)
	End Sub
	
	Private Sub txtPriceS_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPriceS.Leave
		MyLostFocus(txtPriceS, 2)
	End Sub
	
	Private Sub txtQty_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case KeyAscii
			Case Asc(vbCr)
				KeyAscii = 0
			Case 8
			Case 48 To 57
				
		End Select
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtQty_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQty.Enter
		'MyGotFocusNumeric txtQty
		txtQty.SelectionStart = 0
		txtQty.SelectionLength = Len(txtQty.Text)
	End Sub
	
	Private Sub txtQty_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQty.Leave
		' LostFocus txtQty, 2
	End Sub
	
	'UPGRADE_WARNING: Event txtQtyT.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtQtyT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQtyT.TextChanged
		If txtQtyT.Text = "" Then txtQty.Text = CStr(0) : Exit Sub
		If txtQtyT.Text = "0" Then txtQty.Text = CStr(0) : Exit Sub
		If IsNumeric(txtQtyT.Text) Then 
		Else 
			txtQty.Text = CStr(0) : Exit Sub
		End If
		txtQty.Text = CStr(CDbl(txtQtyT.Text) * CDbl(txtPSize.Text))
	End Sub
	
	Private Sub txtQtyT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtQtyT.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case KeyAscii
			Case Asc(vbCr)
				KeyAscii = 0
			Case 8, 46
			Case 48 To 57
			Case Else
				KeyAscii = 0
		End Select
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtQtyT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQtyT.Enter
		'MyGotFocusNumeric txtQty
		txtQtyT.SelectionStart = 0
		txtQtyT.SelectionLength = Len(txtQtyT.Text)
	End Sub
	
	Private Sub txtQtyT_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQtyT.Leave
		' LostFocus txtQty, 2
	End Sub
End Class