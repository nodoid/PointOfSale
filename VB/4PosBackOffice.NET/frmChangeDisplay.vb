Option Strict Off
Option Explicit On
Friend Class frmChangeDisplay
	Inherits System.Windows.Forms.Form
	Private Sub loadLanguage()
		
		'Label1 = No Code       [Enter the desired display name]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblName = No Code      [Enter the desired display name]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblName.Caption = rsLang("LanguageLayoutLnk_Description"): lblName.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdSubmit = No Code    [Accept]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdSubmit.Caption = rsLang("LanguageLayoutLnk_Description"): cmdSubmit.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Command1 = No Code     [Decline]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Command1.Caption = rsLang("LanguageLayoutLnk_Description"): Command1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmChangeDisplay.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub cmdSubmit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSubmit.Click
		If txtNumber.Text <> "" Then
			If Val(txtNumber.Text) = 0 Or Val(txtNumber.Text) > 100 Then
				MsgBox("Keyboard key display should be between 1 and 100", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
				Exit Sub
				
			Else
				InKeyboard = Val(txtNumber.Text)
				Me.Close()
			End If
		Else
			MsgBox("Please enter your display key number", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
			Exit Sub
		End If
		
	End Sub
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		InKeyboard = 200
		Me.Close()
	End Sub
	
	Private Sub txtNumber_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtNumber.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Then
			cmdSubmit_Click(cmdSubmit, New System.EventArgs())
			GoTo EventExitSub
		End If
		
		If IsNumeric(Chr(KeyAscii)) Or KeyAscii = 8 Then
		Else
			KeyAscii = 0
		End If
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class