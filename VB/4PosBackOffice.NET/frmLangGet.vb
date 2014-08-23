Option Strict Off
Option Explicit On
Friend Class frmLangGet
	Inherits System.Windows.Forms.Form
	Dim gName, gScreen As String
	Dim gRTL As Boolean
	
	Public Sub getLanguageValue(ByRef lName As String, ByRef bRTL As Boolean, ByRef sScreen As String)
		'lblName.Caption = lName
		'lblKey.Caption = frmKeyboard.getKeyDescription(KeyCode, Shift)
		txtTrans.Text = lName
		If bRTL = True Then chkRTL.CheckState = System.Windows.Forms.CheckState.Checked Else chkRTL.CheckState = System.Windows.Forms.CheckState.Unchecked
		txtTrans.SelectionStart = 0
		txtTrans.SelectionLength = 9999
		'txtTrans.SetFocus
		ShowDialog()
		lName = gName
		bRTL = gRTL
		sScreen = sScreen
	End Sub
	
	Private Sub cmdAccept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAccept.Click
		gName = txtTrans.Text
		gRTL = chkRTL.CheckState
		'gScreen = sScreen
		Me.Close()
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Me.Close()
		gName = ""
		gRTL = chkRTL.CheckState
	End Sub
	
	Private Sub Text1_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles Text1.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		'    Select Case KeyCode
		'        Case 16, 17, 18
		'        Case Else
		'            lblKey.Caption = frmKeyboard.getKeyDescription(KeyCode, Shift)
		'            gKeyCode = KeyCode
		'            gShift = Shift
		'    End Select
		'    KeyCode = 0
	End Sub
	
	Private Sub Text1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Text1.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'    KeyAscii = 0
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class