Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmPOSSecurity
	Inherits System.Windows.Forms.Form
	Dim loading As Boolean
	Dim gID As Short
	Dim gLastIndex As Short
	
	Private Sub loadLanguage()
		
		'frmPOSSecurity = No Code   [Employee Point Of Sales Permissions]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmPOSSecurity.Caption = rsLang("LanguageLayoutLnk_Description"): frmPOSSecurity.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'Label1(2) = No Code        [Name]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1(2).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(2).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1(1) = No Code        [Permissions]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1(1).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1(0) = No Code        [Sale Channel Access]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1(0).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkPosSecurity = No Code   [Select All]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkPosSecurity.Caption = rsLang("LanguageLayoutLnk_Description"): chkPosSecurity.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmPOSSecurity.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	'UPGRADE_WARNING: Event chkPosSecurity.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkPosSecurity_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkPosSecurity.CheckStateChanged
		Dim j As Short
		Dim rstIn As Short
		Dim rstIn1 As Short
		
		
		rstIn = lstSecurity.Items.Count - 1
		rstIn1 = lstChannel.Items.Count - 1
		
		If chkPosSecurity.CheckState = 1 Then
			
			For j = 0 To rstIn
				lstSecurity.SetItemChecked(j, True)
			Next 
			
			For j = 0 To rstIn1
				lstChannel.SetItemChecked(j, True)
			Next 
			
		Else
			For j = 0 To rstIn
				lstSecurity.SetItemChecked(j, False)
			Next 
			
			For j = 0 To rstIn1
				lstChannel.SetItemChecked(j, False)
			Next 
			
		End If
		
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	
	Public Sub loadItem(ByRef id As Integer)
        Dim x As Integer
		Dim rs As ADODB.Recordset
		Dim lValue As Integer
		
		loading = True
		gID = id
		rs = getRS("SELECT DISPLAY_Person.PersonID, DISPLAY_Person.Person_Name, IIf([Person_SecurityBitPOS] Is Null,0,[Person_SecurityBitPOS]) AS [bit] From DISPLAY_Person WHERE (((DISPLAY_Person.PersonID)=" & id & "));")
		
		lValue = rs.Fields("bit").Value
		
        _Label1_2.Text = "Point Of Sale Access Rights for '" & rs.Fields("Person_Name").Value & "'"
		rs = getRS("SELECT SecurityBit.SecurityBit_Value, SecurityBit.SecurityBit_Name From SecurityBit Where (((SecurityBit.SecurityBit_Type) = 0)) ORDER BY SecurityBit.SecurityBitID;")

        Dim m As Integer
		Do Until rs.EOF
			
            m = lstSecurity.Items.Add(New LBI(rs.Fields("SecurityBit_Name").Value, rs.Fields("SecurityBit_Value").Value))
			
			If rs.Fields("SecurityBit_Value").Value And lValue Then
                lstSecurity.SetItemChecked(m, True)
			Else
				lstSecurity.SetItemChecked(m, False)
			End If
			
			rs.moveNext()
			
		Loop 
		
		rs = getRS("SELECT Channel.ChannelID, Channel.Channel_Name FROM Channel ORDER BY Channel.ChannelID;")
		Do Until rs.EOF
            lstChannel.Items.Add(New LBI(rs.Fields("Channel_Name").Value, rs.Fields("ChannelID").Value))
			rs.moveNext()
		Loop 
		
		rs = getRS("SELECT PersonChannelLnk.PersonChannelLnk_ChannelID From PersonChannelLnk WHERE (((PersonChannelLnk.PersonChannelLnk_PersonID)=" & gID & "));")
		Do Until rs.EOF
			For x = 0 To lstChannel.Items.Count - 1
                If GetItemData(lstChannel, x) = rs.Fields("PersonChannelLnk_ChannelID").Value Then
                    lstChannel.SetItemChecked(x, True)
                End If
			Next x
			rs.moveNext()
		Loop 
		
		loading = False
		
		loadLanguage()
		Me.ShowDialog()
	End Sub
	Private Sub frmPOSSecurity_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub frmPOSSecurity_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		Dim x As Short
		Dim bit As Integer
		For x = 0 To Me.lstSecurity.Items.Count - 1
			If lstSecurity.GetItemChecked(x) Then
                bit = bit + GetItemData(lstSecurity, x)
			End If
		Next x
		cnnDB.Execute("UPDATE Person SET Person.Person_SecurityBitPOS = " & bit & " WHERE (((Person.PersonID)=" & gID & "));")
	End Sub
	
	'UPGRADE_WARNING: ListBox event lstChannel.ItemCheck has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Private Sub lstChannel_ItemCheck(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ItemCheckEventArgs) Handles lstChannel.ItemCheck
		If loading Then Exit Sub
        cnnDB.Execute("DELETE FROM PersonChannelLnk WHERE (PersonChannelLnk_PersonID = " & gID & ") AND (PersonChannelLnk_ChannelID = " & CInt(lstChannel.SelectedIndex) & ")")
		
		If lstChannel.GetItemChecked(eventArgs.Index) Then
            cnnDB.Execute("INSERT INTO PersonChannelLnk (PersonChannelLnk_PersonID, PersonChannelLnk_ChannelID) VALUES (" & gID & ", " & CInt(lstChannel.SelectedIndex) & ")")
		Else
		End If
		
	End Sub
End Class