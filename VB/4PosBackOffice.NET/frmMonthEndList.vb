Option Strict Off
Option Explicit On
Friend Class frmMonthendList
	Inherits System.Windows.Forms.Form
	Dim gFilter As String
	Dim gRS As ADODB.Recordset
	Dim gFilterSQL As String
	Dim gID As Integer
	Dim gSection As Short
	
	Private Sub loadLanguage()
		
		'frmMonthendList = No Code  [Select a Month End]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmMonthendList.Caption = rsLang("LanguageLayoutLnk_Description"): frmMonthendList.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmMonthendList.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Function getItem(ByRef Section As Short) As Integer
		'cmdNew.Visible = False
		gSection = Section
		
		loadLanguage()
		doSearch()
		
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
	
    Private Sub DataList1_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DataList1.DoubleClick
        If DataList1.BoundText <> "" Then
            If gSection = 7 Then
                If DataList1.CtlText = "Current" Then
                    gID = 0
                Else
                    gID = CInt(DataList1.BoundText)
                End If
                Me.Close()
            Else
                frmMonthendBudget.loadItem(CInt(DataList1.BoundText))
            End If
        End If
    End Sub
	
    Private Sub DataList1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles MyBase.KeyPress
        Select Case eventArgs.KeyChar
            Case ChrW(13)
                DataList1_DblClick(DataList1, New System.EventArgs())
                eventArgs.KeyChar = ChrW(0)
            Case ChrW(27)
                Me.Close()
                eventArgs.KeyChar = ChrW(0)
        End Select

    End Sub
	Private Sub frmMonthendList_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Public Sub loadItem(ByRef Section As Short)
        Dim cmdNew As New Button
		gSection = Section
		If gSection Then cmdNew.Visible = False
		doSearch()
		
		loadLanguage()
		Me.ShowDialog()
	End Sub
	
    Private Sub frmMonthendList_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        gRS.Close()
    End Sub
	
    Private Sub txtSearch_MyGotFocus(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        ' txtSearch.SelStart = 0
        ' txtSearch.SelLength = 999
    End Sub
	
	Private Sub txtSearch_KeyDown(ByRef KeyCode As Short, ByRef Shift As Short)
		Select Case KeyCode
			Case 40
				Me.DataList1.Focus()
		End Select
	End Sub
	
	Private Sub txtSearch_KeyPress(ByRef KeyAscii As Short)
		Select Case KeyAscii
			Case 13
				doSearch()
				KeyAscii = 0
		End Select
	End Sub
	
	Private Sub doSearch()
		Dim sql As String
		Dim lString As String
		
		gRS = getRS("SELECT MonthEnd.MonthEndID, IIf([MonthEndID]=[Company_MonthEndID],'Current',[Company_MonthEndID]-[MonthEndID] & ' month/s ago') AS theMonth From MonthEnd, Company ORDER BY MonthEnd.MonthEndID DESC;")
		'Display the list of Titles in the DataCombo
		DataList1.DataSource = gRS
		DataList1.listField = "theMonth"
		
		
		'Bind the DataCombo to the ADO Recordset
		DataList1.DataSource = gRS
		DataList1.boundColumn = "MonthEndID"
		
	End Sub
End Class