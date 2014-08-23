Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmStockTransferItemWH
	Inherits System.Windows.Forms.Form
	Dim gStockItemID As Integer
	Dim gPromotionID As Integer
	Dim gQuantity As Integer
	Dim WHFromA As Integer
	Dim WHToB As Integer
	
	Private Sub loadLanguage()
		
		'frmStockTransferItemWH = No Code   [Edit Stock Transfer Item]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmStockTransferItemWH.Caption = rsLang("LanguageLayoutLnk_Description"): frmStockTransferItemWH.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
        If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1139 'Promotion Name|Checked
		If rsLang.RecordCount Then lblPComp.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lblPComp.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1935 'Stock Item Name|Checked
		If rsLang.RecordCount Then _lbl_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lbl_2 = No Code                   [Item Qty]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1151 'Price|Checked
		If rsLang.RecordCount Then _lbl_3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmStockTransferItemWH.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub loadData()
		Dim rs As ADODB.Recordset
		Dim rj As ADODB.Recordset
		
		rs = getRS("SELECT StockItem.StockItem_Name, StockItem_Quantity FROM StockItem WHERE ((StockItem.StockItemID)=" & gStockItemID & ");")
		If rs.RecordCount Then
			lblStockItem.Text = rs.Fields("StockItem_Name").Value
			txtPSize.Text = rs.Fields("StockItem_Quantity").Value
            Me.Height = twipsToPixels(2520, False)
			
			loadLanguage()
			ShowDialog()
		End If

	End Sub
	
	'Public Sub loadItem(promotionID As Long, stockitemID As Long, Optional quantity As Long)
	Public Sub loadItem(ByRef stockitemID As Integer, Optional ByRef quantity As Integer = 0, Optional ByRef WHFrom As Integer = 0, Optional ByRef WHTo As Integer = 0)
		gStockItemID = stockitemID
		'gPromotionID = promotionID
		gQuantity = quantity
		WHFromA = WHFrom
		WHToB = WHTo
		lblPComp.Text = frmStockTransferWH.lblWHA.Text
		loadData()
		
		'show 1
		
	End Sub
	
	Private Sub cmdPack_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPack.Click
		If CDbl(txtPSize.Text) <> 1 Then
			cmdPack.Tag = txtPSize.Text
			txtPSize.Text = CStr(1)
		Else
			If cmdPack.Tag <> "" Then txtPSize.Text = cmdPack.Tag
		End If
		
		If txtQtyT.Text = "" Then txtQtyT.Text = "0"
		If IsNumeric(txtQtyT.Text) Then 
		Else 
			txtQtyT.Text = "0"
		End If
		txtQty.Text = CStr(CDbl(txtQtyT.Text) * CDbl(txtPSize.Text))
		
		txtQtyT.Focus()
	End Sub
	
	Private Sub frmStockTransferItemWH_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub ChkHandheldWHTransfer()
		Dim rs As ADODB.Recordset
		Dim strFldName As String
		
ChkTransTable: 
		
		On Error GoTo Err_ChkTransTable
		rs = getRS("SELECT * FROM HandheldWHTransfer;")
		If rs.RecordCount Then
		End If
		
		Exit Sub
Err_ChkTransTable: 
		If Err.Number = -2147217865 And Err.Description = "[Microsoft][ODBC Microsoft Access Driver] The Microsoft Jet database engine cannot find the input table or query 'HandheldWHTransfer'.  Make sure it exists and that its name is spelled correctly." Then
			strFldName = "HandHeldID Number,Handheld_Barcode Text(50), Quantity Currency, WHouseID Number"
			cnnDB.Execute("CREATE TABLE HandheldWHTransfer (" & strFldName & ")")
			System.Windows.Forms.Application.DoEvents()
			rs = getRS("SELECT * FROM HandheldWHTransfer;")
			If rs.RecordCount Then
			End If
			
			GoTo ChkTransTable
		End If
		
	End Sub
	
	'UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Function update_Renamed() As Boolean
        Dim sql As String
		On Error GoTo UpdateErr
		
		ChkHandheldWHTransfer()
		
		'UPGRADE_WARNING: Couldn't resolve default property of object sql. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		sql = "INSERT INTO HandheldWHTransfer (HandHeldID,Handheld_Barcode,Quantity,WHouseID) VALUES (" & gStockItemID & ", 0, " & (0 - CDec(txtQty.Text)) & "," & WHFromA & ")"
		'UPGRADE_WARNING: Couldn't resolve default property of object sql. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		cnnDB.Execute(sql)
		System.Windows.Forms.Application.DoEvents()
		
		'UPGRADE_WARNING: Couldn't resolve default property of object sql. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		sql = "INSERT INTO HandheldWHTransfer (HandHeldID,Handheld_Barcode,Quantity,WHouseID) VALUES (" & gStockItemID & ", 0, " & CDec(txtQty.Text) & "," & WHToB & ")"
		'UPGRADE_WARNING: Couldn't resolve default property of object sql. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		cnnDB.Execute(sql)
		System.Windows.Forms.Application.DoEvents()
		
		update_Renamed = True
		Exit Function
UpdateErr: 
		MsgBox(Err.Description)
		update_Renamed = True
		
	End Function
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Dim sql As String
		cmdClose.Focus()
		System.Windows.Forms.Application.DoEvents()
		If CDec(txtQtyT.Text) > 0 Then
		Else
			txtQtyT.Focus()
			Exit Sub
		End If
		
		Dim rs As ADODB.Recordset
		'UPGRADE_WARNING: Couldn't resolve default property of object sql. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		sql = "SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS Warehouse_StockItemQuantity From WarehouseStockItemLnk Where (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) = " & frmStockTransferWH.lWHA & ")) GROUP BY WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID HAVING (((WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID)=" & gStockItemID & "));"
		rs = getRS(sql)
		If rs.RecordCount Then
			If rs.Fields("Warehouse_StockItemQuantity").Value < CDec(txtQty.Text) Then
				MsgBox("Insufficient Qty in '" & frmStockTransferWH.lblWHA.Text & "'")
				txtQtyT.Focus()
				Exit Sub
			End If
		Else
			MsgBox("Insufficient Qty in '" & frmStockTransferWH.lblWHA.Text & "'")
			txtQtyT.Focus()
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