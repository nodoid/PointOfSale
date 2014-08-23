Option Strict Off
Option Explicit On
Friend Class frmOverride
	Inherits System.Windows.Forms.Form
	Dim slocalOR As Boolean
	Dim slocalMgrID As Integer
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	
	Private Sub frmOverride_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		txtPassword.Text = ""
	End Sub
	
	Public Function sOverride(ByRef sMgrID As Integer) As Boolean
		slocalMgrID = 0
		slocalOR = False
		ShowDialog()
		sMgrID = slocalMgrID
		sOverride = slocalOR
	End Function
	
	Private Sub txtPassword_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim rs As ADODB.Recordset
		slocalOR = False
		On Error Resume Next
		Select Case KeyAscii
			Case 13
				'Dim user As user
				KeyAscii = 0
				rs = getRS("SELECT * FROM Person WHERE (Person_QuickAccess = '" & Replace(Me.txtPassword.Text, "'", "''") & "')")
				If rs.BOF Or rs.EOF Then
					lblError.Text = "Invalid Security Code!"
					txtPassword.SelectionStart = 0
					txtPassword.SelectionLength = 999
					GoTo EventExitSub
				Else
					'MsgBox "Login 1"
					If CInt(rs.Fields("Person_SecurityBit").Value & "0") Then
						If 8192 And rs.Fields("Person_SecurityBit").Value Then
							slocalOR = True
							slocalMgrID = rs.Fields("PersonID").Value
							Me.Close()
						Else
							lblError.Text = "Call Your Supervisor!"
							txtPassword.SelectionStart = 0
							txtPassword.SelectionLength = 999
							GoTo EventExitSub
						End If
					End If
				End If
			Case 27
				KeyAscii = 0
				Me.Close()
		End Select
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class