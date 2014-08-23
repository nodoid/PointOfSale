Option Strict Off
Option Explicit On
Friend Class frmKeyboardGet
	Inherits System.Windows.Forms.Form
	Dim gKeyCode, gShift As Short
	Private Sub loadLanguage()
		
		'frmKeyboardGet = No Code   [Press the Desired Key Combination]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmKeyboardGet.Caption = rsLang("LanguageLayoutLnk_Description"): frmKeyboardGet.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblKey = No Code/Dynamic/NA?
		
		'cmdAccept = No Code        [Accept]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdAccept.Caption = rsLang("LanguageLayoutLnk_Description"): cmdAccept.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Command1 = No Code         [Decline]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Command1.Caption = rsLang("LanguageLayoutLnk_Description"): Command1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmKeyboardGet.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Sub getKeyboardValue(ByRef lName As String, ByRef KeyCode As Short, ByRef Shift As Short)
		lblName.Text = lName
		lblKey.Text = frmKeyboard.getKeyDescription(KeyCode, Shift)
		ShowDialog()
		KeyCode = gKeyCode
		Shift = gShift
	End Sub
	
	Private Sub cmdAccept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAccept.Click
		Me.Close()
		
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Me.Close()
		gKeyCode = 0
		gShift = 0
	End Sub
	
	Private Sub Text1_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles Text1.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Select Case KeyCode
			Case 16, 17, 18
			Case Else
				lblKey.Text = frmKeyboard.getKeyDescription(KeyCode, Shift)
				gKeyCode = KeyCode
				gShift = Shift
		End Select
		KeyCode = 0
	End Sub
	
	Private Sub Text1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Text1.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = 0
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class