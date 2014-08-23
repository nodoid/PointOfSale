Option Strict Off
Option Explicit On
Friend Class frmDayEndList
	Inherits System.Windows.Forms.Form
	Dim gFilter As String
	Dim gRS As ADODB.Recordset
	Dim gFilterSQL As String
	Dim gID As Integer
	Dim gSection As Short
	Dim mID_Renamed As Integer
	
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1265 'Select a Day End|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmDayEndList.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Function getItem() As Integer
        Dim cmdNew As New Button
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
	
	Private Sub cmdPrev_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrev.Click
		Dim sql As String
		Dim lString As String
		
		mID_Renamed = 0
		mID_Renamed = frmMonthendList.getItem(7)
		If mID_Renamed Then
			gRS = getRS("SELECT DayEnd.DayEndID, Format([DayEnd_Date],'ddd dd mmm yyyy') AS theDay FROM DayEnd WHERE DayEnd.DayEnd_MonthEndID = " & mID_Renamed & " ORDER BY DayEnd.DayEndID DESC;")
			'Display the list of Titles in the DataCombo
			DataList1.DataSource = gRS
			DataList1.listField = "theDay"
			
			'Bind the DataCombo to the ADO Recordset
			'UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
			DataList1.DataSource = gRS
			DataList1.boundColumn = "DayEndID"
		Else
			gRS = getRS("SELECT DayEnd.DayEndID, Format([DayEnd_Date],'ddd dd mmm yyyy') AS theDay FROM Company AS Company_1 INNER JOIN (Company RIGHT JOIN DayEnd ON Company.Company_DayEndID = DayEnd.DayEndID) ON Company_1.Company_MonthEndID = DayEnd.DayEnd_MonthEndID Where (((Company.CompanyID) Is Null)) ORDER BY DayEnd.DayEndID DESC;")
			'Display the list of Titles in the DataCombo
			DataList1.DataSource = gRS
			DataList1.listField = "theDay"
			
			'Bind the DataCombo to the ADO Recordset
			DataList1.DataSource = gRS
			DataList1.boundColumn = "DayEndID"
		End If
	End Sub
	
	Private Sub DataList1_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DataList1.DoubleClick
		If DataList1.BoundText <> "" Then
			If mID_Renamed <> 0 Then
				loadDayEndReportPrev(CInt(DataList1.BoundText), mID_Renamed)
			Else
				loadDayEndReport(CInt(DataList1.BoundText))
			End If
		End If
	End Sub
	
	
	
	Private Sub DataList1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles DataList1.KeyPress
		Dim lDate As String
        Select Case eventArgs.KeyChar
            Case ChrW(13)
                DataList1_DblClick(DataList1, New System.EventArgs())
                eventArgs.KeyChar = ChrW(0)
            Case ChrW(27)
                Me.Close()
                eventArgs.KeyChar = ChrW(0)
            Case ChrW(100)
                If DataList1.BoundText <> "" Then
                    lDate = InputBox("Enter New Date", "NEW DATE", CStr(Today))
                    If lDate <> "" Then
                        On Error Resume Next
                        cnnDB.Execute("UPDATE DayEnd SET DayEnd.DayEnd_Date = #" & lDate & "# WHERE (((DayEnd.DayEndID)=" & DataList1.BoundText & "));")
                        doSearch()
                    End If
                End If

        End Select
		
	End Sub
	Private Sub frmDayEndList_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Public Sub loadItem(ByRef section As Short)
        Dim cmdNew As New Button
		gSection = section
		If gSection Then cmdNew.Visible = False
		
		doSearch()
		If System.Drawing.ColorTranslator.ToOle(frmMenu.lblUser.ForeColor) = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow) Then cmdPrev.Visible = False
		loadLanguage()
		Me.ShowDialog()
	End Sub
	
	Private Sub frmDayEndList_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		mID_Renamed = 0
	End Sub
	
	Private Sub frmDayEndList_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		gRS.Close()
	End Sub
	
    'Private Sub txtSearch_MyGotFocus(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    ' Dim txtSearch As New TextBox
    '     txtSearch.SelStart = 0
    '    txtSearch.SelLength = 999
    'End Sub

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

        gRS = getRS("SELECT DayEnd.DayEndID, Format([DayEnd_Date],'ddd dd mmm yyyy') AS theDay FROM Company AS Company_1 INNER JOIN (Company RIGHT JOIN DayEnd ON Company.Company_DayEndID = DayEnd.DayEndID) ON Company_1.Company_MonthEndID = DayEnd.DayEnd_MonthEndID Where (((Company.CompanyID) Is Null)) ORDER BY DayEnd.DayEndID DESC;")
        'Display the list of Titles in the DataCombo
        DataList1.DataSource = gRS
        DataList1.listField = "theDay"


        'Bind the DataCombo to the ADO Recordset
        DataList1.DataSource = gRS
        DataList1.boundColumn = "DayEndID"

    End Sub
End Class