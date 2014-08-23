Option Strict Off
Option Explicit On
Friend Class frmIncrementQuantity
	Inherits System.Windows.Forms.Form
	Dim gIncrementID As Integer
	Dim gQuantity As Integer
	
	Private Sub loadLanguage()
		
		'frmIncrementQuantity = No Code [Edit Increment Quantity]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmIncrementQuantity.Caption = rsLang("LanguageLayoutLnk_Description"): frmIncrementQuantity.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lbl_1 = No Code               [Increment Name]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2145 'Shrink Size|Checked
		If rsLang.RecordCount Then _lblLabels_9.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_9.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1151 'Price|Checked
		If rsLang.RecordCount Then _lbl_3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmIncrementQuantity.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub loadData()
		Dim rs As ADODB.Recordset
		If gQuantity Then
			rs = getRS("SELECT IncrementQuantity.*, Increment.Increment_Name FROM Increment INNER JOIN IncrementQuantity ON Increment.IncrementID = IncrementQuantity.IncrementQuantity_IncrementID WHERE (((IncrementQuantity.IncrementQuantity_IncrementID)=" & gIncrementID & ") AND ((IncrementQuantity.IncrementQuantity_Quantity)=" & gQuantity & "));")
			If rs.RecordCount Then
				lblStockItem.Text = rs.Fields("Increment_Name").Value
				txtPrice.Text = CStr(rs.Fields("IncrementQuantity_Price").Value * 100)
				txtPrice_Leave(txtPrice, New System.EventArgs())
				txtQuantity.Text = CStr(gQuantity)
				txtQuantity_Leave(txtQuantity, New System.EventArgs())
			Else
				Me.Close()
				Exit Sub
			End If
		Else
			rs = getRS("SELECT Increment.* From Increment WHERE (((Increment.IncrementID)=" & gIncrementID & "));")
			If rs.RecordCount Then
				lblStockItem.Text = rs.Fields("Increment_Name").Value
				txtPrice.Text = CStr(0)
				txtPrice_Leave(txtPrice, New System.EventArgs())
				txtQuantity.Text = CStr(gQuantity)
				txtQuantity_Leave(txtQuantity, New System.EventArgs())
			Else
				Me.Close()
				Exit Sub
			End If
		End If
	End Sub
	Public Sub loadItem(ByRef incrementID As Integer, ByRef quantity As Integer)
		gIncrementID = incrementID
		gQuantity = quantity
		loadData()
		
		loadLanguage()
		ShowDialog()
	End Sub
	Private Sub frmIncrementQuantity_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
		Dim lBit As Short
		update_Renamed = True
		Me.cmdClose.Focus()
		System.Windows.Forms.Application.DoEvents()
		cnnDB.Execute("DELETE IncrementQuantity.* From IncrementQuantity WHERE (((IncrementQuantity.IncrementQuantity_IncrementID)=" & gIncrementID & ") AND ((IncrementQuantity.IncrementQuantity_Quantity)=" & gQuantity & "));")
		cnnDB.Execute("DELETE IncrementQuantity.* From IncrementQuantity WHERE (((IncrementQuantity.IncrementQuantity_IncrementID)=" & gIncrementID & ") AND ((IncrementQuantity.IncrementQuantity_Quantity)=" & txtQuantity.Text & "));")
		If CShort(txtQuantity.Text) > 1 Then
			cnnDB.Execute("INSERT INTO IncrementQuantity ( IncrementQuantity_IncrementID, IncrementQuantity_Quantity, IncrementQuantity_Price ) SELECT " & gIncrementID & ", " & txtQuantity.Text & ", " & txtPrice.Text & ";")
		End If
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
	
	Private Sub txtQuantity_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQuantity.Enter
        MyGotFocusNumeric(txtQuantity)
	End Sub
	
	Private Sub txtQuantity_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtQuantity.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        MyKeyPressNegative(txtQuantity, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtQuantity_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQuantity.Leave
        MyLostFocus(txtQuantity, 0)
	End Sub
End Class