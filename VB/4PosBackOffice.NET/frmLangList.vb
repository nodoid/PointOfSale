Option Strict Off
Option Explicit On
Friend Class frmLangList
	Inherits System.Windows.Forms.Form
	Dim gFilter As String
	Dim gRS As ADODB.Recordset
	Dim gFilterSQL As String
	Dim gID As Integer
	Dim gSection As Short
	Dim gAll As Boolean
	Public Sub loadItem(ByRef section As Short)
		gSection = section
		If gSection Then cmdNew.Visible = False
		doSearch()
		Me.ShowDialog()
	End Sub
	Public Function getItem() As Integer
		cmdNew.Visible = False
		Me.ShowDialog()
		getItem = gID
	End Function
	Private Sub getNamespace()
	End Sub
	
	Private Sub cmdBOMenu_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBOMenu.Click
		frmLangMenu.loadItem(0)
	End Sub
	
	Private Sub cmdDel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDel.Click
		Dim rs As ADODB.Recordset
		Dim intres As Short
		
        If DataList1.Columns.ToString <> "" Then

            If MsgBox("Do you want to delete this '" & DataList1.Columns.ToString & "' language?", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Application.Info.Title) = MsgBoxResult.Yes Then
            Else
                Exit Sub
            End If

            rs = getRS("SELECT * FROM LanguageLayout;")
            If rs.RecordCount > 1 Then
                cnnDB.Execute("DELETE * FROM LanguageLayout WHERE LanguageLayoutID =" & Val(DataList1.Columns.ToString) & ";")
            Else
                MsgBox("Couldn't delete '" & DataList1.Columns.ToString & "'. Atleast one Language is required.")
            End If
            doSearch()
        End If
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	Private Sub cmdNamespace_Click()
		frmFilter.loadFilter(gFilter)
		getNamespace()
	End Sub
	
	Private Sub cmdImport_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdImport.Click
		frmLangImport.ShowDialog()
		doSearch()
	End Sub
	
	Private Sub cmdNew_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNew.Click
		Dim rs As ADODB.Recordset
		cnnDB.Execute("INSERT INTO LanguageLayout ( LanguageLayout_Name ) SELECT 'New Language';")
		rs = getRS("SELECT Max(LanguageLayout.LanguageLayoutID) AS MaxOfLanguageLayoutID FROM LanguageLayout;")
        frmLang.loadItem(rs.Fields("MaxOfLanguageLayoutID").Value)
		doSearch()
	End Sub
    Private Sub DataList1_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DataList1.DoubleClick
        If cmdNew.Visible Then
            If DataList1.Columns.ToString <> "" Then
                frmLang.loadItem(DataList1.Columns.ToString)
            End If
            doSearch()
        Else
            If DataList1.Columns.ToString = "" Then
                gID = 0
            Else
                gID = CInt(DataList1.Columns.ToString)
            End If
            Me.Close()
        End If
    End Sub
	
    Private Sub DataList1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles DataList1.KeyPress
        Select Case eventArgs.KeyChar
            Case Chr(13)
                DataList1_DblClick(DataList1, New System.EventArgs())
                eventArgs.KeyChar = Chr(0)
            Case Chr(27)
                Me.Close()
                eventArgs.KeyChar = Chr(0)
        End Select

    End Sub
	
	Private Sub frmLangList_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KeyCode = 36 Then
			gAll = Not gAll
			doSearch()
			KeyCode = False
		End If
	End Sub
	
	Private Sub frmLangList_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	Private Sub frmLangList_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		doSearch()
	End Sub
	Private Sub frmLangList_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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
		lString = " WHERE (LanguageLayout_Name LIKE '%" & Replace(lString, " ", "%' AND LanguageLayout_Name LIKE '%") & "%')"
		gRS = getRS("SELECT LanguageLayout.LanguageLayoutID, LanguageLayout.LanguageLayout_Name FROM LanguageLayout " & lString & " ORDER BY LanguageLayout_Name")
		
		'Display the list of Titles in the DataCombo
        DataList1.DataBindings.Add(gRS)
        DataList1.Columns.Add("LanguageLayout_Name", "")
		
		'Bind the DataCombo to the ADO Recordset
		'UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
		DataList1.DataSource = gRS
        DataList1.Columns.Add("LanguageLayoutID", "")
		
	End Sub
End Class