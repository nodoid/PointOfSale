Option Strict Off
Option Explicit On
Friend Class frmFloatLister
	Inherits System.Windows.Forms.Form
	Dim gFilter As String
	Dim gRS As ADODB.Recordset
	Dim gFilterSQL As String
	Dim gID As Integer
	
	Private Sub loadLanguage()
		
		'frmFloatLister = No Code       [Denomination]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmFloatLister.Caption = rsLang("LanguageLayoutLnk_Description"): frmFloatLister.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1065 'New|Checked
		If rsLang.RecordCount Then cmdNew.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdNew.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then Command2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Command2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmFloatLister.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Function getItem() As Integer
		'cmdNew.Visible = False
		
		loadLanguage()
		Me.ShowDialog()
		getItem = gID
	End Function
	Private Sub getNamespace()
	End Sub
	Private Sub cmdExit_Click()
		Me.Close()
	End Sub
	Private Sub cmdNamespace_Click()
		frmFilter.loadFilter(gFilter)
		getNamespace()
	End Sub
	Private Sub cmdNew_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNew.Click
		frmNewDenomination.loadItem()
		doSearch()
	End Sub
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		Me.Close()
	End Sub
    Private Sub DataList1_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DataList1.DoubleClick
        If cmdNew.Visible Then
            If DataList1.CurrentCell.ToString <> "" Then
                frmFloatRepre.loadItem(CInt(DataList1.CurrentCell.Value))
            End If
            doSearch()
        Else
            If DataList1.CurrentCell.ToString = "" Then
                gID = 0
            Else
                gID = CInt(DataList1.CurrentCell.Value)
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
	Private Sub frmFloatLister_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		doSearch()
	End Sub
	
	Private Sub frmFloatLister_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		gRS.Close()
	End Sub
	Private Sub doSearch()
        'Dim sql As String
        'Dim lString As String
        'Dim column As DataColumn
		gRS = getRS("SELECT Float.Float_Unit, Float.Float_Pack, Float.Float_Name, Float.Float_Type,Float.Float_Disabled From [float] ORDER BY Float.Float_Unit, Float.Float_Type;")
		'Display the list of Titles in the DataCombo
        'Dim bind As New BindingSource
        'bind.DataSource = gRS
        DataList1.DataSource = gRS
        DataList1.Columns.Add("Float_Name", "")
        'DataList1.listField = "Float_Name"
		
		'Bind the DataCombo to the ADO Recordset
		'UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
		DataList1.DataSource = gRS
        DataList1.Columns.Add("Float_Unit", "")
		
	End Sub
End Class