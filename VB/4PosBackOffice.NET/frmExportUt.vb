Option Strict Off
Option Explicit On
Friend Class frmExportUt
	Inherits System.Windows.Forms.Form
	Private WithEvents ex As DatabaseExport
	
	Private Sub loadLanguage()
		
		'NOTE: Form Caption has a spelling Mistake!
		'frmExportUt = No Code      [Export Utilities]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmExportUt.Caption = rsLang("LanguageLayoutLnk_Description"): frmExportUt.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2424 'File Path|Checked
		If rsLang.RecordCount Then Label1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'NOTE: DB Entry 2483 missing "!"
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2483 'Export Now|Checked
		If rsLang.RecordCount Then cmdExportNow.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExportNow.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmExportUt.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub cmdBrowse_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBrowse.Click
		Dim strSelect As String
		
		ex = New DatabaseExport
		
		strSelect = "CSV"
		
		Select Case strSelect
			
			Case "CSV"
				
                If ex.ShowSave(cmdlgSave, DatabaseExport.DatabaseExportEnum.CSV) Then
                    Text1.Text = ex.FilePath
                End If
		End Select
		
	End Sub
	Private Function isClean() As Boolean
		
		If Text1.Text = "" Then
			MsgBox("Please enter file name and the destination!" & vbCrLf & "FOR CSV", MsgBoxStyle.Exclamation, "Exporter Utitities")
			isClean = True
		Else
			isClean = False
		End If
		
	End Function
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	Private Sub cmdExportNow_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExportNow.Click
		Dim fso As New Scripting.FileSystemObject
		'Set ex = New DatabaseExport
		
		If Text1.Text = "" Then
			MsgBox("Please Enter file destination", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
			Exit Sub
		Else
			If fso.FileExists(Text1.Text) = True Then
				If MsgBox("File Exists, Do you wan to overwrite it?", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) = MsgBoxResult.Yes Then
					ex.FilePath = Text1.Text
					If isClean = False Then ex.ExportToCSV()
				Else
					Exit Sub
				End If
				Me.Close()
			Else
				If isClean = False Then ex.ExportToCSV()
				Me.Close()
			End If
		End If
		
	End Sub
	Private Sub ex_ExportStarted(ByVal ExportingFormat As DatabaseExport.DatabaseExportEnum) Handles ex.ExportStarted
		Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
		Debug.Print(IIf(ExportingFormat = DatabaseExport.DatabaseExportEnum.CSV, "CSV", IIf(ExportingFormat = DatabaseExport.DatabaseExportEnum.HTML, "HTML", "Excel")))
	End Sub
	Private Sub ex_ExportComplete(ByVal Success As Boolean, ByVal ExportingFormat As DatabaseExport.DatabaseExportEnum) Handles ex.ExportComplete
		If Success = True Then
			MsgBox("Export Completed!", MsgBoxStyle.OKOnly + MsgBoxStyle.Information + MsgBoxStyle.ApplicationModal, "Export Utilies")
			
		Else
			MsgBox("Export Completed!", MsgBoxStyle.OKOnly + MsgBoxStyle.Information + MsgBoxStyle.ApplicationModal, "Export Utilies")
		End If
		Me.Close()
	End Sub
	
	'Sub loaditem()
	
	'ex.ExportToCSV
	
	'End Sub
	Private Sub frmExportUt_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		loadLanguage()
	End Sub
End Class