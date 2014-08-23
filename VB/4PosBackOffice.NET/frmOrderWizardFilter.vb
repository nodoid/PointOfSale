Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmOrderWizardFilter
	Inherits System.Windows.Forms.Form
	Public gDayEndStart As Integer
	Public gDayEndEnd As String
	Public gFilter As String
	'Dim gNodeFilter As IXMLDOMNode
    Public gFilterSQL As String
    Dim MonthView As New List(Of MonthCalendar)
	
	Private Sub loadLanguage()

		'Label2 = No Code       [When Calculating your ordering levels.......]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label2.Caption = rsLang("LanguageLayoutLnk_Description"): Label2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1(0) = No Code    [Day End Criteria]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1(0).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_5 = No Code       [From Date]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_5.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_3 = No Code       [To Date]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_3.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_1 = No Code       [Calculated Day End Criteria]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1(1) = No Code    [Wizard Rules]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1(1).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_0 = No Code       [Forecast my stock holding for]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_2 = No Code       ["Day Ends" and then guarantee no re-order]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_4 = No Code       [level will be below]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_4.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkDynamic = No Code   [Automatically re-calculate start and end dates based on current "Day End" date]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkDynamic.Caption = rsLang("LanguageLayoutLnk_Description"): chkDynamic.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1006 'Filter|Checked
        If rsLang.RecordCount Then _Label1_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _Label1_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1006 'Filter|Checked
		If rsLang.RecordCount Then cmdFilter.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdFilter.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmOrderWizardFilter.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub save()
		Dim lStart, lEnd As Short
		Dim rs As ADODB.Recordset
		
		If Me.chkDynamic.CheckState Then
			rs = getRS("SELECT " & gDayEndEnd & " - MAX(DayEndID) AS id From DayEnd")
			
			lStart = rs.Fields("id").Value
		Else
			lStart = CShort(gDayEndEnd)
		End If
		
		lEnd = CDbl(gDayEndEnd) - gDayEndStart + 1
		
		
		cnnDB.Execute("UPDATE MinMax SET MinMax_DayEndIDStart = " & lStart & ", MinMax_DayEndIDBack = " & lEnd & ", MinMax_DaysForward = " & Me.txtDays.Text & ", MinMax_Minimum = " & Me.txtMinimum.Text & " Where (MinMaxID = 1)")
		
		Me.Close()
	End Sub
	
	Public Sub setDayEndRange()
		Dim lDate As Date
		Dim lDateString As String
		Dim lDateArray() As String
		Dim rs As ADODB.Recordset
		Dim lDateStart As Date
		Dim lDateEnd As Date
		On Error Resume Next
        lDateStart = _MonthView1_0.SelectionStart
        lDateEnd = _MonthView1_1.SelectionEnd
		
        If _MonthView1_0.SelectionStart > _MonthView1_1.SelectionEnd Then
            lDateStart = _MonthView1_1.SelectionStart
            lDateEnd = _MonthView1_0.SelectionEnd
        End If
		rs = getRS("SELECT TOP 1 DayEndID, DayEnd_Date AS [date] From DayEnd WHERE (DayEnd_Date >= #" & lDateStart & "#) ORDER BY DayEnd_Date")
		If rs.BOF Or rs.EOF Then
			rs.Close()
			rs = getRS("SELECT TOP 1 DayEndID, DayEnd_Date AS [date] From DayEnd ORDER BY DayEndID DESC")
			gDayEndStart = rs.Fields("DayEndID").Value
		Else
			gDayEndStart = rs.Fields("DayEndID").Value
		End If
		rs.Close()
		
		rs = getRS("SELECT TOP 1 DayEndID, DayEnd_Date AS [date] From DayEnd WHERE (DayEnd_Date <= #" & lDateEnd & "#) ORDER BY DayEnd_Date DESC")
		If rs.BOF Or rs.EOF Then
			rs.Close()
			rs = getRS("SELECT TOP 1 DayEndID, DayEnd_Date AS [date] From DayEnd ORDER BY DayEndID DESC")
			gDayEndEnd = rs.Fields("DayEndID").Value
		Else
			gDayEndEnd = rs.Fields("DayEndID").Value
		End If
		rs.Close()
		
		rs = getRS("SELECT TOP 100 PERCENT COUNT(*) AS [count], MIN(DayEnd_Date) AS fromDate, MAX(DayEnd_Date) AS toDate From DayEnd WHERE (DayEndID >= " & gDayEndStart & " AND DayEndID <= " & gDayEndEnd & ")")
		If rs.BOF Or rs.EOF Then
		Else
			lDateString = Format(rs.Fields("fromDate").Value, "dddd dd,mmm yyyy")
			lblDayEnd.Text = "Day End date Range From "
			lblDayEnd.Text = lblDayEnd.Text & lDateString
			lDateString = Format(rs.Fields("toDate").Value, "dddd dd,mmm yyyy")
			lblDayEnd.Text = lblDayEnd.Text & " to "
			lblDayEnd.Text = lblDayEnd.Text & lDateString
			lblDayEnd.Text = lblDayEnd.Text & " covering a dayend range of "
			lblDayEnd.Text = lblDayEnd.Text & rs.Fields("count").Value & " days."
		End If
	End Sub
	
	
	Private Sub cmdFilter_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFilter.Click
		frmFilter.loadFilter(gFilter)
		frmFilter.buildCriteria(gFilter)
		lblFilter.Text = frmFilter.gHeading
		gFilterSQL = frmFilter.gCriteria
	End Sub
	
	Private Sub setup()
        Dim lDate As Date
		Dim rs As ADODB.Recordset
		Dim lStart, lEnd As Integer
		rs = getRS("SELECT * FROM MinMax WHERE (MinMaxID = 1)")
		If rs.BOF Or rs.EOF Then
		Else
			lStart = rs.Fields("MinMax_DayEndIDStart").Value
			lEnd = rs.Fields("MinMax_DayEndIDBack").Value
			Me.txtMinimum.Text = rs.Fields("MinMax_Minimum").Value
			Me.txtDays.Text = rs.Fields("MinMax_DaysForward").Value
			rs.Close()
			If lStart < 1 Then
				Me.chkDynamic.CheckState = System.Windows.Forms.CheckState.Checked
				rs = getRS("SELECT [Company].[Company_DayEndID]-(-1*[MinMax].[MinMax_DayEndIDStart]) AS id FROM Company, MinMax Where (MinMax.MinMaxID = 1)")
				lStart = rs.Fields("id").Value - 1
			Else
				Me.chkDynamic.CheckState = System.Windows.Forms.CheckState.Unchecked
			End If
			rs = getRS("SELECT DayEnd_Date FROM DayEnd Where (DayEndID = " & lStart & ")")
            If rs.RecordCount Then _MonthView1_1 = rs.Fields("DayEnd_Date").Value
			
			rs = getRS("SELECT DayEnd_Date FROM DayEnd Where (DayEndID = " & lStart - lEnd + 1 & ")")
			If rs.RecordCount Then
				lDate = rs.Fields("DayEnd_Date").Value
                _MonthView1_0 = rs.Fields("DayEnd_Date").Value
			End If
		End If
		
		setDayEndRange()
	End Sub
	
	
	Private Sub frmOrderWizardFilter_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 27 Then
			KeyAscii = 0
			save()
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub frmOrderWizardFilter_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'    Dim gDOMFilter As New DOMDocument
        MonthView.AddRange(New MonthCalendar() {_MonthView1_0, _MonthView1_1})
        Dim mc As New MonthCalendar
        For Each mc In MonthView
            AddHandler mc.Enter, AddressOf MonthView1_Enter
            AddHandler mc.Leave, AddressOf MonthView1_Leave
            AddHandler mc.DateChanged, AddressOf MonthView1_SelChange
        Next
        gFilter = "stockitem"
        getNamespace()

        loadLanguage()
        setup()

    End Sub
	
    Private Sub MonthView1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim mv As New MonthCalendar
        mv = DirectCast(eventSender, MonthCalendar)
        Dim Index As Integer = GetIndexer(mv, MonthView)
        If Index Then
            '        MonthView1(1).MonthBackColor = RGB(255, 255, 255)
            _MonthView1_1.BackColor = System.Drawing.ColorTranslator.FromOle(-2147483624)
        Else
            '        MonthView1(0).MonthBackColor = RGB(255, 255, 255)
            _MonthView1_0.BackColor = System.Drawing.ColorTranslator.FromOle(-2147483624)
        End If
    End Sub
	
    Private Sub MonthView1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim mv As New MonthCalendar
        mv = DirectCast(eventSender, MonthCalendar)
        Dim Index As Integer = GetIndexer(mv, MonthView)
        '    If Index Then
        _MonthView1_1.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        '        MonthView1(0).MonthBackColor = -2147483624
        '    Else
        _MonthView1_0.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        '        MonthView1(1).MonthBackColor = -2147483624
        '    End If
    End Sub
	
    Private Sub MonthView1_SelChange(ByVal eventSender As System.Object, ByVal eventArgs As DateRangeEventArgs)
        'Dim Index As Short = MonthView1.GetIndex(eventSender)
        setDayEndRange()
    End Sub
	
	Private Sub txtDays_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtDays.Enter
        MyGotFocusNumeric(txtDays)
	End Sub
	
	Private Sub txtDays_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtDays.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        MyKeyPress(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtDays_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtDays.Leave
        MyLostFocus(txtDays, 0)
	End Sub
	
	Private Sub txtMinimum_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMinimum.Enter
        MyGotFocusNumeric(txtMinimum)
	End Sub
	
	Private Sub txtMinimum_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtMinimum.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        MyKeyPress(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtMinimum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMinimum.Leave
        MyLostFocus(txtMinimum, 0)
	End Sub
	
	Private Sub getNamespace()
		If gFilter = "" Then
			Me.lblFilter.Text = ""
		Else
			frmFilter.buildCriteria(gFilter)
			Me.lblFilter.Text = frmFilter.gHeading
		End If
		gFilterSQL = frmFilter.gCriteria
		'    doSearch
	End Sub
End Class