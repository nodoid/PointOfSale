Option Strict Off
Option Explicit On
Friend Class frmNewDenomination
	Inherits System.Windows.Forms.Form
	Private Sub loadLanguage()
		
		'frmNewDenomination = No Code   [New Denomination]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmNewDenomination.Caption = rsLang("LanguageLayoutLnk_Description"): frmDenomination.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|
		If rsLang.RecordCount Then Command2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Command2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|
		If rsLang.RecordCount Then Command1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Command1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'Label1 = No Code               [Name]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label4 = No Code               [Unit/Amount]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label4.Caption = rsLang("LanguageLayoutLnk_Description"): Label4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label2 = No Code               [Pack]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label2.Caption = rsLang("LanguageLayoutLnk_Description"): Label2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1248 'Type|Checked
		If rsLang.RecordCount Then Label3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'optCoin(0) = No Code           [Coin]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then optCoin(0).Caption = rsLang("LanguageLayoutLnk_Description"): optCoin(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'optCoin(1) = No Code           [Note]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then optCoin(1).Caption = rsLang("LanguageLayoutLnk_Description"): optCoin(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Check1 = No Code               [Disable Denominations]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Check1.Caption = rsLang("LanguageLayoutLnk_Description"): Check1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmNewDenomination.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Dim rs As ADODB.Recordset
		Dim dValue As Short
		Dim dValue_1 As Integer
		
		On Error Resume Next
		
		If txtName.Text = "" Then
			MsgBox("Denomination decription is a required field", MsgBoxStyle.Information + MsgBoxStyle.OKOnly + MsgBoxStyle.ApplicationModal, "New Denomination")
			Exit Sub
		End If
		
		If txtUnit.Text = "" Or Val(txtUnit.Text) = 0 Then
			MsgBox("Denomination Unit Value is a required field", MsgBoxStyle.Information + MsgBoxStyle.OKOnly + MsgBoxStyle.ApplicationModal, "New Denomination")
			Exit Sub
		End If
		
		If txtPack.Text = "" Or Val(txtPack.Text) = 0 Then
			MsgBox("Denomination Pack Value is a required field", MsgBoxStyle.Information + MsgBoxStyle.OKOnly + MsgBoxStyle.ApplicationModal, "New Denomination")
			Exit Sub
		End If
		
        If _optCoin_0.Checked = False And _optCoin_1.Checked = False Then
            MsgBox("Please specify if Denomination is a Coin/Notes", MsgBoxStyle.Information + MsgBoxStyle.OkOnly + MsgBoxStyle.ApplicationModal, "New Denomination")
            Exit Sub
        End If
		
        If _optCoin_0.Checked = True Then dValue = 0 Else dValue = 1
		
		dValue_1 = CInt(CDbl(FormatNumber(txtUnit.Text)) * 100)
		
		rs = getRS("SELECT * FROM [Float] Where Float.Float_Unit = " & dValue_1 & ";")
		
		If rs.RecordCount Then
			MsgBox("Denomination with this float Unit/Amount exist already!!!", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "New Denomination")
		Else
			If CInt(txtPack.Text) = 0 Then
				MsgBox("Denomination float pack must be greater or equal to 1", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "New Denomination")
				Exit Sub
			Else
				cnnDB.Execute("INSERT INTO [Float] (Float_Unit,Float_Name,Float_Pack,Float_Type) VALUES (" & dValue_1 & ",'" & Replace(txtName.Text, "'", "''") & "'," & CInt(txtPack.Text) & "," & dValue & ")")
			End If
			
		End If
		Me.Close()
	End Sub
	Sub loadItem()
		loadLanguage()
		ShowDialog()
	End Sub
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		Me.Close()
	End Sub
    Sub LostFocus1(ByRef lControl As Label, ByRef lDecimal As Boolean)
        If lControl.Text = "" Then Exit Sub
        If lDecimal Then
            lControl.Text = lControl.Text / 100
        End If
        lControl.Text = FormatNumber(lControl.Text)
    End Sub
	
	Private Sub frmNewDenomination_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		loadLanguage()
	End Sub
	
	Private Sub txtPack_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPack.Enter
        MyGotFocusNumeric(txtPack)
	End Sub
	Private Sub txtPack_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtPack.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        MyKeyPress(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtPack_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPack.Leave
        MyLostFocus(txtPack, 2)
	End Sub
	Private Sub txtUnit_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtUnit.Enter
        MyGotFocusNumeric(txtUnit)
	End Sub
	Private Sub txtUnit_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtUnit.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        MyKeyPress(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	Private Sub txtUnit_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtUnit.Leave
        MyLostFocus(txtUnit, 2)
	End Sub
End Class