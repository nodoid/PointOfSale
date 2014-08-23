Option Strict Off
Option Explicit On
Friend Class frmShrink
    Inherits System.Windows.Forms.Form
    Dim txtInteger As New List(Of TextBox)
	Private Sub loadLanguage()
		
		'frmShrink = No code    [Add a Shrink]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmShrink.Caption = rsLang("LanguageLayoutLnk_Description"): frmShrink.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdShrinkAdd = No Code [Add Shrink]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdShrinkAdd.Caption = rsLang("LanguageLayoutLnk_Description"): cmdShrinkAdd.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmShrink.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	
	Private Sub cmdShrinkAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdShrinkAdd.Click
        Dim lAmount As Short
		Dim x As Short
		Dim lString As String
		Dim rs As ADODB.Recordset
		lAmount = 1
		lString = "1"
        For x = 0 To txtInteger.Count
            If CShort(txtInteger(x).Text) <> 0 Then
                lString = lString & "x" & txtInteger(x).Text
               If CShort(txtInteger(x).Text) <= lAmount Then
                    MsgBox(CShort(txtInteger(x).Text) & " is less than or equal to " & lAmount & ".", MsgBoxStyle.Exclamation, "Error")
                    Exit Sub
                Else
                    lAmount = CShort(txtInteger(x).Text)
                End If
            End If
        Next x
		'    lString = Mid(lString, 2)
		rs = getRS("SELECT TOP 100 PERCENT Shrink.Shrink_Name From Shrink WHERE (((Shrink.Shrink_Name)='" & lString & "'));")
		If rs.RecordCount Then
			MsgBox("Shrink size '" & lString & "' already loaded!", MsgBoxStyle.Exclamation, "Error")
		Else
			cnnDB.Execute("INSERT INTO shrink ( Shrink_Name, Shrink_SystemID ) SELECT TOP 100 PERCENT '" & lString & "' AS Expr1, 0 AS Expr2;")
			rs = getRS("SELECT TOP 100 PERCENT Max(Shrink.ShrinkID) AS MaxOfShrinkID FROM Shrink;")
			lAmount = rs.Fields(0).Value
			cnnDB.Execute("INSERT INTO ShrinkItem ( ShrinkItem_ShrinkID, ShrinkItem_Quantity, ShrinkItem_Code ) SELECT TOP 100 PERCENT " & lAmount & " AS Expr1, 1  AS Expr2, '' AS Expr3;")
            For x = 0 To txtInteger.Count
                If CShort(txtInteger(x).Text) <> 0 Then
                   cnnDB.Execute("INSERT INTO ShrinkItem ( ShrinkItem_ShrinkID, ShrinkItem_Quantity, ShrinkItem_Code ) SELECT TOP 100 PERCENT " & lAmount & " AS Expr1, " & txtInteger(x).Text & " AS Expr2, '' AS Expr3;")
                End If
            Next x
			Me.Close()
		End If
	End Sub
	
	Private Sub frmShrink_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 27 Then Me.Close()
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub frmShrink_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        txtInteger.AddRange(New TextBox() {_txtInteger_0, _txtInteger_1, _txtInteger_2, _txtInteger_3, _
                                          _txtInteger_4, _txtInteger_5})
        Dim tb As New TextBox
        For Each tb In txtInteger
            AddHandler tb.Enter, AddressOf txtInteger_Enter
            AddHandler tb.Leave, AddressOf txtInteger_Leave
            AddHandler tb.KeyPress, AddressOf txtInteger_KeyPress
        Next
        loadLanguage()
	End Sub
	
    Private Sub txtInteger_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtInteger.Enter
        Dim txt As New TextBox
        txt = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txt, txtInteger)
        MyGotFocusNumeric(txtInteger(Index))
    End Sub
	
    Private Sub txtInteger_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) 'Handles txtInteger.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'Dim Index As Short = txtInteger.GetIndex(eventSender)
        MyKeyPress(KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub txtInteger_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtInteger.Leave
        Dim txt As New TextBox
        txt = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txt, txtInteger)
        MyLostFocus(txtInteger(Index), 0)
    End Sub
End Class