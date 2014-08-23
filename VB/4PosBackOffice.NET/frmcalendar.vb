Option Strict Off
Option Explicit On
Friend Class frmcalendar
	Inherits System.Windows.Forms.Form
	Private Sub loadLanguage()
		
		'frmcalendar = No Code  [Calendar]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmcalendar.Caption = rsLang("LanguageLayoutLnk_Description"): frmcalendar.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmcalendar.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
    Private Sub Calendar1_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

        If HForPriceC = 1 Then

            HCalDate = Me.Calendar1.SelectionRange.Start.Year & "/" & Me.Calendar1.SelectionRange.Start.Month & "/" & Me.Calendar1.SelectionRange.Start.Day
            frmpricechange.txtstartdate.Text = HCalDate
            HForPriceC = 0
            Me.Close()
        ElseIf HForPriceC = 2 Then
            HCalDate = Me.Calendar1.SelectionRange.Start.Year & "/" & Me.Calendar1.SelectionRange.Start.Month & "/" & Me.Calendar1.SelectionRange.Start.Day
            frmpricechange.txtenddate.Text = HCalDate
            HForPriceC = 0
            Me.Close()
        End If
    End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
		
	End Sub
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		
		If HForPriceC = 1 Then
			
            HCalDate = Me.Calendar1.SelectionRange.Start.Year & "/" & Me.Calendar1.SelectionRange.Start.Month & "/" & Me.Calendar1.SelectionRange.Start.Day
            frmpricechange.txtstartdate.Text = HCalDate
            HForPriceC = 0
            Me.Close()
        ElseIf HForPriceC = 2 Then
            HCalDate = Me.Calendar1.SelectionRange.Start.Year & "/" & Me.Calendar1.SelectionRange.Start.Month & "/" & Me.Calendar1.SelectionRange.Start.Day
            frmpricechange.txtenddate.Text = HCalDate
            HForPriceC = 0
            Me.Close()
		End If
	End Sub
	
	Private Sub frmcalendar_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Then
			cmdOK_Click(cmdOK, New System.EventArgs())
		ElseIf KeyAscii = 27 Then 
			cmdCancel_Click(cmdCancel, New System.EventArgs())
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub frmcalendar_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.Calendar1.SetDate(Today)
	End Sub
End Class