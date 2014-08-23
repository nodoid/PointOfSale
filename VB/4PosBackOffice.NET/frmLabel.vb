Option Strict Off
Option Explicit On
Friend Class frmLabel
	Inherits System.Windows.Forms.Form
	Private Sub loadLanguage()
		
		'frmLabel = No Code [Select Label Format]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmLabel.Caption = rsLang("LanguageLayoutLnk_Description"): frmLabel.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1005 'Next|Checked
		If rsLang.RecordCount Then cmdnext.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdnext.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmLabel.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	
	Private Sub cmdNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNext.Click
		'    Dim lNode As IXMLDOMNode
		Dim rs As ADODB.Recordset
		If lstLayout.SelectedIndex = -1 Then
		Else
            rs = getRS("SELECT Label.* From Label WHERE (((Label.LabelID)=" & CInt(lstLayout.SelectedIndex) & "));")
			gLabelName = rs.Fields("Label_Name").Value
			gLabelColumns = rs.Fields("Label_Columns").Value
			gLabelLeft = rs.Fields("Label_Left").Value
			gLabelHeight = rs.Fields("Label_Height").Value
			gLabelWidth = rs.Fields("Label_Width").Value
		End If
		Me.Close()
	End Sub
	
	Private Sub frmLabel_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 27 Then
			cmdExit_Click(cmdExit, New System.EventArgs())
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub frmLabel_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'    Dim lNode As IXMLDOMNode
		'    Dim lNodeList As IXMLDOMNodeList
		Dim rs As ADODB.Recordset
		
		Me.lstLayout.Items.Clear()
		If isBarcodePrinter = CBool("1") Then
			rs = getRS("SELECT Label.LabelID, Label.Label_Name From Label Where (((Label.Label_Type) <> 0)) ORDER BY Label.Label_Name;")
		Else
			rs = getRS("SELECT Label.LabelID, Label.Label_Name From Label Where (((Label.Label_Type) = 0)) ORDER BY Label.Label_Name;")
		End If
		Do Until rs.EOF
            lstLayout.Items.Add(New LBI(rs.Fields("Label_Name").Value, rs.Fields("LabelID").Value))
			
			rs.moveNext()
		Loop 
		If lstLayout.Items.Count Then lstLayout.SelectedIndex = 0
		'    lstDeposit_Click
		
		loadLanguage()
	End Sub
	
	Private Sub lstLayout_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstLayout.DoubleClick
		cmdNext_Click(cmdNext, New System.EventArgs())
	End Sub
	
	Private Sub lstLayout_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles lstLayout.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Then
			cmdNext_Click(cmdNext, New System.EventArgs())
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class