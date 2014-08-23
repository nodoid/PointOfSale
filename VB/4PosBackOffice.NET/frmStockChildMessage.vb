Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmStockChildMessage
	Inherits System.Windows.Forms.Form
	Dim gStockItemID As Integer
	Dim gPromotionID As Integer
	Dim gQuantity As Integer
	Dim fDone As Boolean
	
	Private Sub loadLanguage()
		
		'frmStockChildMessage = No Code     [New Child Message]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmStockChildMessage.Caption = rsLang("LanguageLayoutLnk_Description"): frmStockChildMessage.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lblPComp = No Code [Please specify if you wish this stock item to be cherge on sale]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblPComp.Caption = rsLang("LanguageLayoutLnk_Description"): lblPComp.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1935 'Stock Item Name|Checked
        If rsLang.RecordCount Then _LBL_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _LBL_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'chkCharge = No Code                [Charge on Sale]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkCharge.Caption = rsLang("LanguageLayoutLnk_Description"): chkCharge.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1151 'Price|Checked
        If rsLang.RecordCount Then _LBL_3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _LBL_3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
        '_lbl_2 = No Code                   [Chargable Item?]
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
        'UPGRADE_ISSUE: Form property frmStockChildMessage.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Function makeItem(ByRef childID As Integer) As Boolean
		Dim lID As Integer
		Dim rs As ADODB.Recordset
		
		fDone = False
		lID = frmStockList2.getItem
		If lID <> 0 Then
			On Error Resume Next
			loadItem(lID, childID) 'adoPrimaryRS("PromotionID"), lID
		End If
		
		makeItem = fDone
	End Function
	Private Sub loadData()
		Dim rs As ADODB.Recordset
		
		rs = getRS("SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & gStockItemID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
		If rs.RecordCount Then
			lblStockItem.Text = rs.Fields("StockItem_Name").Value
			'lblPromotion.Caption = rs("Promotion_Name")
			txtPrice.Text = CStr(rs.Fields("CatalogueChannelLnk_Price").Value * 100)
			txtPrice_Leave(txtPrice, New System.EventArgs())
			'cmbQuantity.Tag = rs("CatalogueChannelLnk_Quantity")
			
			loadLanguage()
			ShowDialog()
		Else
			Me.Close()
			Exit Sub
		End If
		
	End Sub
	
	'Public Sub loadItem(promotionID As Long, stockitemID As Long, Optional quantity As Long)
	Public Sub loadItem(ByRef stockitemID As Integer, Optional ByRef promotionID As Integer = 0)
		gStockItemID = stockitemID
		gPromotionID = promotionID
		'gQuantity = quantity
		'lblPComp.Caption = frmStockTransfer.lblPComp.Caption
		loadData()
		
		'show 1
		
	End Sub
	Private Sub frmStockChildMessage_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		On Error Resume Next
		fDone = False
		Me.Close()
	End Sub
	
	'UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Function update_Renamed() As Boolean
		On Error GoTo UpdateErr
		
		Dim rs As ADODB.Recordset
		Dim rj As ADODB.Recordset
		Dim adoPrimaryRS As ADODB.Recordset
		Dim sql As String
		Dim lQuantity As Decimal ' Long
		
		rs = getRS("SELECT MessageItem.MessageItem_MessageID From MessageItem WHERE (((MessageItem.MessageItem_MessageID)=" & gPromotionID & "));")
		cnnDB.Execute("INSERT INTO MessageItem ( MessageItem_MessageID, MessageItem_Name, MessageItem_Order, MessageItem_StockitemID, MessageItem_Charge ) SELECT " & gPromotionID & ", '" & Replace(lblStockItem.Text, "'", "''") & "', " & rs.RecordCount + 1 & ", " & gStockItemID & ", " & chkCharge.CheckState & ";")
		
		MsgBox("New Child Message from Stock process has been completed.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
		
		
		update_Renamed = True
		
		Exit Function
UpdateErr: 
		MsgBox(Err.Description)
		update_Renamed = True
	End Function
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		cmdClose.Focus()
		System.Windows.Forms.Application.DoEvents()
		
		'If CCur(txtQty.Text) > 0 Then
		'Else
		'    txtQty.SetFocus
		'    Exit Sub
		'End If
		
		If update_Renamed() Then
			fDone = True
			Me.Close()
		End If
	End Sub
	
	Private Sub txtPrice_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPrice.Enter
        MyGotFocusNumeric(txtPrice)
	End Sub
	
	Private Sub txtPrice_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtPrice.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'MyKeyPressNegative(txtPrice, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtPrice_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPrice.Leave
        MyLostFocus(txtPrice, 2)
	End Sub
	
	Private Sub txtPriceS_MyGotFocus()
        Dim txtPriceS As New TextBox
        MyGotFocusNumeric(txtPriceS)
	End Sub
	
	Private Sub txtPriceS_MyLostFocus()
        Dim txtPriceS As New TextBox
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
End Class