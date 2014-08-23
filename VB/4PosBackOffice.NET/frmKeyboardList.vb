Option Strict Off
Option Explicit On
Friend Class frmKeyboardList
	Inherits System.Windows.Forms.Form
	Dim gFilter As String
	Dim gRS As ADODB.Recordset
	Dim gFilterSQL As String
	Dim gID As Integer
	Dim gSection As Short
	Dim gAll As Boolean
	
	Private Sub loadLanguage()
		
		'frmKeyboardList = No Code  [Select a Keyboard]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmKeyboard.Caption = rsLang("LanguageLayoutLnk_Description"): frmKeyboard.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1080 'Search|Checked
		If rsLang.RecordCount Then lbl.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1065 'New|Checked
		If rsLang.RecordCount Then cmdNew.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdNew.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmKeyboardList.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Sub loadItem(ByRef section As Short)
		gSection = section
		If gSection Then cmdNew.Visible = False
		doSearch()
		
		loadLanguage()
		Me.ShowDialog()
	End Sub
	Public Function getItem() As Integer
		cmdNew.Visible = False
		
		loadLanguage()
		Me.ShowDialog()
		getItem = gID
	End Function
	Private Sub getNamespace()
	End Sub
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	Private Sub cmdNamespace_Click()
		frmFilter.loadFilter(gFilter)
		getNamespace()
	End Sub
	Private Sub cmdNew_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNew.Click
		Dim rs As ADODB.Recordset
		cnnDB.Execute("INSERT INTO KeyboardLayout ( KeyboardLayout_Name ) SELECT 'New Keyboard';")
		rs = getRS("SELECT Max(KeyboardLayout.KeyboardLayoutID) AS MaxOfKeyboardLayoutID FROM KeyboardLayout;")
        frmKeyboard.loadItem(rs.Fields("MaxOfKeyboardLayoutID").Value)
		doSearch()
	End Sub
	Private Sub DataList1_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DataList1.DoubleClick
		If cmdNew.Visible Then
			If DataList1.BoundText <> "" Then
				frmKeyboard.loadItem((DataList1.BoundText))
			End If
			doSearch()
		Else
			If DataList1.BoundText = "" Then
				gID = 0
			Else
				gID = CInt(DataList1.BoundText)
			End If
			Me.Close()
		End If
	End Sub
	
	Private Sub DataList1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles DataList1.KeyPress
        Select Case eventArgs.KeyChar
            Case ChrW(13)
                DataList1_DblClick(DataList1, New System.EventArgs())
                eventArgs.KeyChar = ChrW(0)
            Case ChrW(27)
                Me.Close()
                eventArgs.KeyChar = ChrW(0)
        End Select
		
	End Sub
	
	Private Sub frmKeyboardList_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KeyCode = 36 Then
			gAll = Not gAll
			doSearch()
			KeyCode = False
		End If
	End Sub
	
	Private Sub frmKeyboardList_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.Escape
				KeyAscii = 0
				cmdExit_Click(cmdExit, New System.EventArgs())
		End Select
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	Private Sub frmKeyboardList_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		doSearch()
	End Sub
	Private Sub frmKeyboardList_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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
				Me.DataList1.Focus()
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
	Private Sub doSearch()
		Dim sql As String
		Dim lString As String
		
		lString = Trim(txtSearch.Text)
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = " WHERE (KeyboardLayout_Name LIKE '%" & Replace(lString, " ", "%' AND KeyboardLayout_Name LIKE '%") & "%')"
		gRS = getRS("SELECT KeyboardLayout.KeyboardLayoutID, KeyboardLayout.KeyboardLayout_Name FROM KeyboardLayout " & lString & " ORDER BY KeyboardLayout_Name")
		
		'Display the list of Titles in the DataCombo
		DataList1.DataSource = gRS
		DataList1.listField = "KeyboardLayout_Name"
		
		'Bind the DataCombo to the ADO Recordset
		'UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
		DataList1.DataSource = gRS
		DataList1.boundColumn = "KeyboardLayoutID"
		
	End Sub
End Class