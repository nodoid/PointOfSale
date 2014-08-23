Option Strict Off
Option Explicit On
Friend Class frmStockBreak
	Inherits System.Windows.Forms.Form
	Dim gParent, gChild As Integer
	
	Private Sub loadLanguage()
		
		'frmStockBreak = No Code    [Maintain Stock Item Conversion]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmStockBreak.Caption = rsLang("LanguageLayoutLnk_Description"): frmStockBreak.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1085 'Print|
		If rsLang.RecordCount Then cmdPrint.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrint.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
        '_lbl_0 = No Code           [Convert one unit of]
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
        '_lbl_1 = No Code           [to]
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
        '_lbl_2 = No Code           [units of]
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkDisabled = No Code      [Disable this Stock Item Conversion]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkDisabled.Caption = rsLang("LanguageLayoutLnk_Description"): chkDisabled.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
        'UPGRADE_ISSUE: Form property frmStockBreak.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        Dim lChild As Integer
        Dim lParent As Integer
		If lParent = 0 Then
			Me.Close()
		Else
			loadItem(lParent & "_" & lChild)
		End If
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		If CShort(Me.txtQuantity.Text) < 2 Then
			MsgBox("Quantity must be greater than one(1)!", MsgBoxStyle.Exclamation, "ERROR")
			txtQuantity.Focus()
			Exit Sub
		End If
		If Me.lblParent.Tag = "" Then
			MsgBox("A Parent Stock item is required!", MsgBoxStyle.Exclamation, "ERROR")
			cmdParent.Focus()
			Exit Sub
		End If
		If Me.lblChild.Tag = "" Then
			MsgBox("A Child Stock item is required!", MsgBoxStyle.Exclamation, "ERROR")
			cmdChild.Focus()
			Exit Sub
		End If
		If gParent = 0 Then
		Else
			cnnDB.Execute("DELETE StockBreak.* From StockBreak WHERE (((StockBreak.StockBreak_ParentID)=" & gParent & ") AND ((StockBreak.StockBreak_ChildID)=" & gChild & "));")
		End If
		cnnDB.Execute("DELETE StockBreak.* From StockBreak WHERE (((StockBreak.StockBreak_ParentID)=" & lblParent.Tag & ") AND ((StockBreak.StockBreak_ChildID)=" & lblChild.Tag & "));")
		cnnDB.Execute("INSERT INTO StockBreak ( StockBreak_ParentID, StockBreak_ChildID, StockBreak_Quantity, StockBreak_Disabled ) SELECT " & lblParent.Tag & " AS lParent, " & lblChild.Tag & " AS lChild, " & CShort(Me.txtQuantity.Text) & " AS lQty, " & CShort(Me.chkDisabled.CheckState) & " AS lDisabled;")
		
		Me.Close()
	End Sub
	
	
	Private Sub cmdParent_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdParent.Click
		Dim lID As Integer
		lID = frmStockList.getItem
		If lID <> 0 Then
			Me.lblParent.Tag = lID
			Me.lblParent.Text = getStockName(CInt(Me.lblParent.Tag))
		End If
	End Sub
	Private Sub cmdChild_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdChild.Click
		Dim lID As Integer
		lID = frmStockList.getItem
		If lID <> 0 Then
			Me.lblChild.Tag = lID
			Me.lblChild.Text = getStockName(CInt(Me.lblChild.Tag))
		End If
	End Sub
	
	Private Function getStockName(ByRef lID As Integer) As String
		Dim rs As ADODB.Recordset
		If lID <> 0 Then
			rs = getRS("SELECT StockItem.StockItem_Name FROM StockItem WHERE (StockItemID = " & lID & ")")
			If rs.BOF Or rs.EOF Then
			Else
				getStockName = rs.Fields("StockItem_Name").Value
			End If
        End If
        getStockName = ""
	End Function
	
	
	Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
		report_StockBreak()
	End Sub
	
	Private Sub frmStockBreak_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.Escape
				KeyAscii = 0
				cmdExit_Click(cmdExit, New System.EventArgs())
		End Select
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Public Sub loadItem(ByRef lKey As String)
		Dim rs As ADODB.Recordset
		On Error Resume Next
		If lKey <> "" Then
			Me.lblParent.Tag = CInt(Split(lKey, "_")(0))
			gParent = CInt(lblParent.Tag)
			Me.lblParent.Text = getStockName(CInt(Me.lblParent.Tag))
			Me.lblChild.Tag = CInt(Split(lKey, "_")(1))
			gChild = CInt(lblChild.Tag)
			Me.lblChild.Text = getStockName(CInt(Me.lblChild.Tag))
			rs = getRS("SELECT StockBreak.* From StockBreak WHERE (((StockBreak.StockBreak_ParentID)=" & gParent & ") AND ((StockBreak.StockBreak_ChildID)=" & gChild & "));")
			If rs.RecordCount Then
				txtQuantity.Text = rs.Fields("StockBreak_Quantity").Value
				
				Me.chkDisabled.CheckState = System.Math.Abs(CShort(rs.Fields("StockBreak_Disabled" & 0).Value))
			Else
				txtQuantity.Text = CStr(0)
				Me.chkDisabled.CheckState = False
			End If
		Else
			gParent = 0
			gChild = 0
			txtQuantity.Text = CStr(0)
			Me.chkDisabled.CheckState = False
		End If
		
		loadLanguage()
		Me.ShowDialog()
	End Sub
	
	Private Sub txtQuantity_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQuantity.Enter
        MyGotFocusNumeric(txtQuantity)
	End Sub
	
	Private Sub txtQuantity_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtQuantity.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        MyKeyPress(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtQuantity_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQuantity.Leave
        MyLostFocus(txtQuantity, 0)
	End Sub
End Class