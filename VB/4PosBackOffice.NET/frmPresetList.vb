Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmPresetList
	Inherits System.Windows.Forms.Form
	Dim gID As Integer
	Dim gFilter As String
	Dim gFilterSQL As String
	Dim gRS As ADODB.Recordset
	
	Private Sub loadLanguage()
		
		'frmPresetList = No Code    [Denomination List]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmPresetList.Caption = rsLang("LanguageLayoutLnk_Description"): frmPresetList.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1 = No Code           [Available Presets]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Function getItem() As Integer
		
		loadLanguage()
		Me.ShowDialog()
		getItem = gID
	End Function
	
	Private Sub getNamespace()
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		subRearangePreset()
		
		Me.Close()
	End Sub
	Sub subRearangePreset()
		
	End Sub
	
	Private Sub cmdNamespace_Click()
		frmFilter.loadFilter(gFilter)
		getNamespace()
	End Sub
	
	Private Sub cmdNew_Click()
		frmPrintGroup.loadItem(0)
		doSearch()
	End Sub
	
	Private Sub DataList1_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DataList1.DoubleClick
        'Dim frmPresetTender As Object
        'Dim frmPreset As frmPresetTender
        'If DataList1.BoundText <> "" Then
        ' gRS.Filter = "Float_Unit = " & DataList1.BoundText
        ' frmPreset.loadItem(CInt(DataList1.BoundText), gRS.Fields("Float_Name"))
        ' doSearch()
        '	End If

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
	
	Private Sub frmPresetList_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		doSearch()
	End Sub
	Private Sub frmPresetList_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		gRS.Close()
	End Sub
    Private Sub txtSearch_MyGotFocus(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'txtSearch.SelectionStart = 0
        'txtSearch.SelectionLength = 999
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

		Dim rk As ADODB.Recordset
        Dim bind As BindingSource = New BindingSource
		gRS = getRS("SELECT Float.Float_Unit, Float.Float_Pack, Float.Float_Name, Float.Float_Type,Float.Float_Disabled From [float] WHERE Float.Float_Type = True AND Float_Disabled = False ORDER BY Float.Float_Unit, Float.Float_Type;")
		
		'Display the list of Titles in the DataCombo
		DataList1.DataSource = gRS
		DataList1.listField = "Float_Name"
		
		'Bind the DataCombo to the ADO Recordset
        bind.DataSource = gRS
        DataList1.DataBindings.Add(bind.DataSource)
		DataList1.boundColumn = "Float_Unit"
		
		Label2.Text = ""
		Do While gRS.EOF = False
			rk = getRS("SELECT keyboard.keyboard_Name,keyboard.keyboard_Description, keyboard.keyboard_Show,keyboard.keyboardID FROM tblPresetTender INNER JOIN keyboard ON tblPresetTender.tblKey = keyboard.KeyboardID WHERE tblPresetTender.tblValue = " & gRS.Fields("Float_Unit").Value & ";")
			If rk.RecordCount Then
				Label2.Text = Label2.Text & gRS.Fields("Float_Name").Value & " :"
			End If
			gRS.moveNext()
		Loop 
		
	End Sub
End Class