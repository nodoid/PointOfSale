Option Strict Off
Option Explicit On
Friend Class frmStockValSelect
	Inherits System.Windows.Forms.Form
	Dim gFilter As String
	Dim gRS As ADODB.Recordset
	Dim gFilterSQL As String
	Dim gID As Integer
	Dim gSection As Short
	Dim gAll As Boolean
	Dim grpDelete As String
	
	Private Sub loadLanguage()
		
		'frmStockValSelect = No Code    [Stock Value Report]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmStockValSelect.Caption = rsLang("LanguageLayoutLnk_Description"): frmStockValSelect.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1238 'Select option for Detail/Summary|Checked
		If rsLang.RecordCount Then lblHeading.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lblHeading.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1080 'Search|Checked
		If rsLang.RecordCount Then lbl.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1240 'Select Group|Checked
		If rsLang.RecordCount Then ckbGrp.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : ckbGrp.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1242 'Detail|Checked
		If rsLang.RecordCount Then optDel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : optDel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1243 'Summary|Checked
		If rsLang.RecordCount Then optSum.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : optSum.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1085 'Print|Checked
		If rsLang.RecordCount Then cmdshow.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdshow.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
        'UPGRADE_ISSUE: Form property frmStockValSelect.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	'UPGRADE_WARNING: Event ckbGrp.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub ckbGrp_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ckbGrp.CheckStateChanged
		txtSearch.Enabled = ckbGrp.CheckState
		DataList1.Enabled = ckbGrp.CheckState
		lstFilter.Enabled = ckbGrp.CheckState
	End Sub
	
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	
	
	Private Sub cmdShow_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdShow.Click
		Dim x As Short
		
		gFilterSQL = ""
		For x = 0 To lstFilter.Items.Count - 1
			If lstFilter.GetItemChecked(x) Then
				'Set gRS = getRS("SELECT StockGRoupID, StockGRoup_Name FROM StockGRoup WHERE StockGRoup_Name = '" & lstFilter.ItemData(x) & "'")
                gFilterSQL = gFilterSQL & " OR ((StockGroup.StockGroupID)=" & CLng(lstFilter.SelectedItem(x)) & ")"
			End If
		Next  '((StockGroup.StockGroupID)=6)
		gFilterSQL = Mid(gFilterSQL, 5)
		
		If ckbGrp.CheckState = 1 Then
			If optDel.Checked = True Then
				report_StockValuebyGX((gFilterSQL)) '(gID)
			ElseIf optSum.Checked = True Then 
				report_StockValuebyGS((gFilterSQL)) '(gID)
			End If
		Else
			If optDel.Checked = True Then
				report_StockValuebyGX((""))
			ElseIf optSum.Checked = True Then 
				report_StockValuebyGS((""))
			End If
		End If
	End Sub
	
	
	Private Sub doSearch()
        Dim x As Short
		Dim sql As String
		Dim lString As String
		lString = Trim(txtSearch.Text)
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		If lString = "" Then
		Else
			lString = "WHERE (StockGRoup_Name LIKE '%" & Replace(lString, " ", "%' AND StockGRoup_Name LIKE '%") & "%')"
			
		End If
		If gAll Then
		Else
			If lString = "" Then
				lString = " WHERE StockGroup_Disabled = 0 "
			Else
				lString = lString & " AND StockGroup_Disabled = 0 "
			End If
		End If
		
		gRS = getRS("SELECT DISTINCT StockGRoupID, StockGRoup_Name FROM StockGRoup " & lString & " ORDER BY StockGRoup_Name")
		
		'Display the list of Titles in the DataCombo
        DataList1.DataSource = gRS
		'Set lstFilter.DataSource = gRS
		DataList1.listField = "StockGRoup_Name"
		
		'Bind the DataCombo to the ADO Recordset
		'UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
		DataList1.DataSource = gRS
		DataList1.boundColumn = "StockGRoupID"
        Dim m As Integer
		lstFilter.Items.Clear()
		For x = 0 To (gRS.RecordCount - 1)
			'If InStr(UCase(gArray(x, 1)), UCase(Me.txtSearch.Text)) Then
			lstFilter.Items.Add(gRS.Fields("StockGRoup_Name").Value) 'gArray(x, 1)
            m = lstFilter.Items.Add(New SetItemData(lstFilter.SelectedIndex, gRS.Fields("StockGRoupID").Value))
            lstFilter.SetItemChecked(m, 0)
			gRS.moveNext()
			'End If
		Next 
		
	End Sub
	
    Private Sub DataList1_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As KeyEventArgs) Handles DataList1.Click
        If DataList1.BoundText = "" Then
            gID = 0
        Else
            gID = CInt(DataList1.BoundText)
        End If
    End Sub
	
	Private Sub frmStockValSelect_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		txtSearch.Enabled = ckbGrp.CheckState
		DataList1.Enabled = ckbGrp.CheckState
		lstFilter.Enabled = ckbGrp.CheckState
		
		loadLanguage()
		
		doSearch()
	End Sub
	
	
	Private Sub frmStockValSelect_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		gRS.Close()
	End Sub
	
	
	Private Sub txtSearch_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSearch.Enter
		txtSearch.SelectionStart = 0
		txtSearch.SelectionLength = 999
	End Sub
	
	Private Sub txtSearch_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Select Case KeyCode
			Case 40
				'Me.DataList1.SetFocus
				Me.lstFilter.Focus()
		End Select
	End Sub
	
	Private Sub txtSearch_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case KeyAscii
			Case 13
				doSearch()
				KeyAscii = 0
		End Select
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class