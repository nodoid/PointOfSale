Option Strict Off
Option Explicit On
Friend Class frmLoading
	Inherits System.Windows.Forms.Form
	Private Sub loadLanguage()
		
		'frmLoading = No Code   [Loading...]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmLoading.Caption = rsLang("LanguageLayoutLnk_Description"): frmLoading.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
End Class