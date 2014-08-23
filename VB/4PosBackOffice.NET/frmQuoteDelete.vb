Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmQuoteDelete
	Inherits System.Windows.Forms.Form
	Private Sub loadLanguage()
		
		'frmQuoteDelete = No Code   [Delete Unwanted Quotes]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmQuoteDelete.Caption = rsLang("LanguageLayoutLnk_Description"): frmQuoteDelete.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1148
		If rsLang.RecordCount Then cmdDelete.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdDelete.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'Label1 = No Code           [Affected Stock Items]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmQuoteDelete.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub cmdDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDelete.Click
		Dim lPath As String
		Dim fso As New Scripting.FileSystemObject
		Dim lvItem As System.Windows.Forms.ListViewItem
		lPath = serverPath & "quote/"
		For	Each lvItem In Me.lvData.Items
			If lvItem.Checked Then
				If fso.FileExists(lPath & Mid(lvItem.Name, 2)) Then
					fso.DeleteFile(lPath & Mid(lvItem.Name, 2))
				End If
				cnnDB.Execute("DELETE Quote.* From Quote WHERE (((Quote.Quote_Document)='" & Mid(lvItem.Name, 2) & "'));")
			End If
			
		Next lvItem
		getData()
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	
	
	Private Sub getData()
		Dim sql As String
		Dim lFilter As String
		Dim rs As ADODB.Recordset
		Dim lvItem As System.Windows.Forms.ListViewItem
		sql = "SELECT Quote.Quote_Document, Quote.Quote_Name, Quote.Quote_Total, Quote.Quote_Reference, Format([Quote_Date],'ddd dd mmm yyyy') AS theDate From Quote ORDER BY Quote.Quote_Date;"
		rs = getRS(sql)
		lvData.Items.Clear()
		Do Until rs.EOF
			lvItem = lvData.Items.Add("K" & rs.Fields("Quote_Document").Value, rs.Fields("Quote_Document").Value, "")
			lvItem.Checked = False
			'UPGRADE_WARNING: Lower bound of collection lvItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
            If lvItem.SubItems.Count > 0 Then
                lvItem.SubItems(0).Text = rs.Fields("Quote_Name").Value
            Else
                lvItem.SubItems.Insert(0, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("Quote_Name").Value))
            End If
			'UPGRADE_WARNING: Lower bound of collection lvItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
            If lvItem.SubItems.Count > 1 Then
                lvItem.SubItems(1).Text = FormatNumber(rs.Fields("Quote_Total").Value, 1)
            Else
                lvItem.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("Quote_Total").Value, 2)))
            End If
			'UPGRADE_WARNING: Lower bound of collection lvItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
            If lvItem.SubItems.Count > 2 Then
                lvItem.SubItems(2).Text = rs.Fields("theDate").Value
            Else
                lvItem.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("theDate").Value))
            End If
			rs.moveNext()
		Loop 
	End Sub
	
	
	Private Sub frmQuoteDelete_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 27 Then
			KeyAscii = 0
			Me.Close()
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub frmQuoteDelete_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim lvHeader As System.Windows.Forms.ColumnHeader
		'UPGRADE_ISSUE: Load statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"'
        'Load(frmOrderWizardFilter)
        lvData.Columns.Add("Document", CInt(twipsToPixels(700, True)), System.Windows.Forms.HorizontalAlignment.Left)
        lvData.Columns.Add("Name", CInt(twipsToPixels(2500, True)), System.Windows.Forms.HorizontalAlignment.Left)
        lvData.Columns.Add("Total", CInt(twipsToPixels(1200, True)), System.Windows.Forms.HorizontalAlignment.Right)
        lvData.Columns.Add("Date", CInt(twipsToPixels(1600, True)), System.Windows.Forms.HorizontalAlignment.Right)
		
		loadLanguage()
		
		getData()
	End Sub
	
	Private Sub frmQuoteDelete_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		Dim x As Short
		Dim lWidth As Integer
		For x = 2 To lvData.Columns.Count
            lWidth = lWidth + pixelToTwips(lvData.Columns.Item(x).Width, True)
		Next 
        lvData.Columns.Item(0).Width = twipsToPixels(pixelToTwips(lvData.Width, True) - lWidth - 320, True)
	End Sub
End Class