Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmBOSecurity
	Inherits System.Windows.Forms.Form
	Dim loading As Boolean
	Dim gID As Short
	Dim gLastIndex As Short
	
	Private Sub loadLanguage()
		
		'frmBOSecurity = No Code    [Employee Back Office Permissions]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmBOSecurity.Caption = rsLang("LanguageLayoutLnk_Description"): frmBOSecurity.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1010 'General|
		If rsLang.RecordCount Then lbl.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'chkSelectAll = No Code     [Select All]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkSelectAll.Caption = rsLang("LanguageLayoutLnk_Description"): chkSelectAll.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmBOSecurity.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	'UPGRADE_WARNING: Event chkSelectAll.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkSelectAll_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkSelectAll.CheckStateChanged
		Dim j As Short
		Dim rstIn As Short
		
		rstIn = lstSecurity.Items.Count - 1
		
		If chkSelectAll.CheckState = 1 Then
			For j = 0 To rstIn
				lstSecurity.SetItemChecked(j, True)
			Next 
			
		Else
			For j = 0 To rstIn
				lstSecurity.SetItemChecked(j, False)
			Next 
		End If
		
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	
	Public Sub loadItem(ByRef id As Integer)
		Dim rs As ADODB.Recordset
		Dim lValue As Integer
        Dim bSecChk As Boolean
        Dim tmp As String
		loading = True
		gID = id
		bSecChk = False
		
		Dim rsRpt As ADODB.Recordset
		rsRpt = getRS("SELECT Company_SecurityPerm From Company")
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(rsRpt.Fields("Company_SecurityPerm").Value) Then
		ElseIf rsRpt.Fields("Company_SecurityPerm").Value = 0 Then 
		Else
			bSecChk = True
		End If
		
		rs = getRS("SELECT DISPLAY_Person.PersonID, DISPLAY_Person.Person_Name, IIf([Person_SecurityBit] Is Null,0,[Person_SecurityBit]) AS [bit] From DISPLAY_Person WHERE (((DISPLAY_Person.PersonID)=" & id & "));")
		lValue = rs.Fields("bit").Value
		
		lbl.Text = "&1. Permissions for '" & rs.Fields("Person_Name").Value & "'"
		rs = getRS("SELECT SecurityBit.SecurityBit_Value, SecurityBit.SecurityBit_Name From SecurityBit Where (((SecurityBit.SecurityBit_Type) = 1)) ORDER BY SecurityBit.SecurityBitID;")
        Dim m As Integer
        Do Until rs.EOF
            If bSecChk Then
                If rs.Fields("SecurityBit_Value").Value And frmMenu.gBit Then
                    tmp = rs.Fields("SecurityBit_Name").Value & ", " & rs.Fields("SecurityBit_Value").Value
                    m = lstSecurity.Items.Add(tmp)
                    If rs.Fields("SecurityBit_Value").Value And lValue Then
                        lstSecurity.SetItemChecked(m, True)
                    Else
                        lstSecurity.SetItemChecked(m, False)
                    End If
                End If
            Else
                tmp = rs.Fields("SecurityBit_Name").Value & ", " & rs.Fields("SecurityBit_Value").Value
                m = lstSecurity.Items.Add(tmp)
                If rs.Fields("SecurityBit_Value").Value And lValue Then
                     lstSecurity.SetItemChecked(m, True)
                Else
                   lstSecurity.SetItemChecked(m, False)
                End If

            End If
            rs.MoveNext()
        Loop
		
		
		loading = False
		
		loadLanguage()
		Me.ShowDialog()
	End Sub
	
	Private Sub frmBOSecurity_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.Escape
				KeyAscii = 0
				System.Windows.Forms.Application.DoEvents()
				cmdExit_Click(cmdExit, New System.EventArgs())
		End Select
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub frmBOSecurity_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		Dim x As Short
		Dim bit As Integer
		For x = 0 To Me.lstSecurity.Items.Count - 1
			If lstSecurity.GetItemChecked(x) Then
                bit = bit + CShort(x)
			End If
		Next x
		cnnDB.Execute("UPDATE Person SET Person.Person_SecurityBit = " & bit & " WHERE (((Person.PersonID)=" & gID & "));")
	End Sub
End Class