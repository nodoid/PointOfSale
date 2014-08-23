Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmVNC
    Inherits System.Windows.Forms.Form
    Dim WithEvents optType As New List(Of RadioButton)
	Private Sub loadLanguage()
		
		'frmVNC = No Code           [View another computer]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmVNC.Caption = rsLang("LanguageLayoutLnk_Description"): frmVNC.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1(0) = No Code        [There are two modes that can be activated a description of each follows:]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1(0).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'optType(0) = No Code       [&View mode]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then optType(0).Caption = rsLang("LanguageLayoutLnk_Description"): optType(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1(2) = No Code        [You can only view the activity on the computer. No intervention is permitted.]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1(2).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(2).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'optType(1) = No Code       [&Edit mode]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then optType(1).Caption = rsLang("LanguageLayoutLnk_Description"): optType(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1(3) = No Code        [You can control the mouse and keyboard activity from your own computer. ]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1(3).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(3).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmVNC.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
    Private Sub loadVNC(ByRef id As Integer)
        Dim lPath As String
        lPath = My.Application.Info.DirectoryPath
        lPath = "c:\4POS"
        'UPGRADE_WARNING: Lower bound of collection Me.lvPOS.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
        shellConnection(Me.lvPOS.FocusedItem.SubItems(2).Text)
        If VB.Right(lPath, 1) <> "\" Then lPath = lPath & "\"
        If optType(0).Checked Then
           Shell(lPath & "vncviewer.exe -config " & lPath & id & "_v.vnc")
        Else
            Shell(lPath & "vncviewer.exe -config " & lPath & id & "_e.vnc")
        End If
    End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	
	Private Sub frmVNC_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 27 Then
			KeyAscii = 0
			cmdExit_Click(cmdExit, New System.EventArgs())
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub frmVNC_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        optType.AddRange(New RadioButton() {_optType_0, _optType_1})
        Dim rb As New RadioButton
        AddHandler _optType_0.CheckedChanged, AddressOf optType_CheckedChanged
        AddHandler _optType_1.CheckedChanged, AddressOf optType_CheckedChanged
        Dim rs As ADODB.Recordset
		Dim x As Short
		Dim lItem As System.Windows.Forms.ListViewItem
		lvPOS.Items.Clear()
		rs = getRS("SELECT * FROM POS ORDER BY POSID")
		Do Until rs.EOF
			'UPGRADE_WARNING: Lower bound of collection lvPOS.ListItems.ImageList has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			lItem = lvPOS.Items.Add("POS" & rs.Fields("POSID").Value, rs.Fields("POS_Name").Value & " (" & rs.Fields("POS_IPAddress").Value & ")", 1)
			'UPGRADE_WARNING: Lower bound of collection lItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lItem.SubItems.Count > 1 Then
				lItem.SubItems(1).Text = rs.Fields("POS_Name").Value
			Else
				lItem.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("POS_Name").Value))
			End If
			'UPGRADE_WARNING: Lower bound of collection lItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lItem.SubItems.Count > 2 Then
				lItem.SubItems(2).Text = rs.Fields("POS_IPAddress").Value
			Else
				lItem.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("POS_IPAddress").Value))
			End If
			'UPGRADE_WARNING: Lower bound of collection lItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lItem.SubItems.Count > 3 Then
				lItem.SubItems(3).Text = rs.Fields("POS_Disabled").Value
			Else
				lItem.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("POS_Disabled").Value))
			End If
			rs.moveNext()
		Loop 
		
		loadLanguage()
	End Sub
	
	Private Sub lvPOS_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvPOS.DoubleClick
		Dim lPath As String
        Dim lArray As String()
		If lvPOS.FocusedItem Is Nothing Then
		Else
			lPath = Me.lvPOS.FocusedItem.SubItems(2).Text
			If LCase(Me.lvPOS.FocusedItem.SubItems(2).Text) = "localhost" Then
				If LCase(VB.Left(serverPath, 3)) = "c:\" Then
					Exit Sub
				Else
                    lArray = Split(serverPath, "\")
					lPath = lArray(2)
				End If
			End If
			shellConnection(lPath)
			
			
		End If
	End Sub
	
	Private Sub lvPOS_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles lvPOS.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Then
			lvPOS_DoubleClick(lvPOS, New System.EventArgs())
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'UPGRADE_WARNING: Event optType.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub optType_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If eventSender.Checked Then
            'Dim Index As Short = optType.GetIndex(eventSender)
            Me.lvPOS.Focus()
        End If
    End Sub
	
    Private Sub shellConnection(ByRef host As String)
        Dim fso As New Scripting.FileSystemObject
        Dim lStream As Scripting.TextStream
        If fso.FileExists("C:\4POS\connect.vnc") Then fso.DeleteFile("C:\4POS\connect.vnc")
        lStream = fso.OpenTextFile("C:\4POS\connect.vnc", Scripting.IOMode.ForWriting, True)
        lStream.WriteLine("[connection]")
        lStream.WriteLine("host=" & host)
        lStream.WriteLine("Port=5900")
        lStream.WriteLine("password=vnc")
        lStream.WriteLine("[Options]")
        lStream.WriteLine("use_encoding_0 = 1")
        lStream.WriteLine("use_encoding_1 = 1")
        lStream.WriteLine("use_encoding_2 = 1")
        lStream.WriteLine("use_encoding_3 = 0")
        lStream.WriteLine("use_encoding_4 = 1")
        lStream.WriteLine("use_encoding_5 = 1")
        lStream.WriteLine("preferred_encoding = 16")
        lStream.WriteLine("restricted = 0")
        If Me.optType(1).Checked Then
            lStream.WriteLine("viewonly = 0")
        Else
            lStream.WriteLine("viewonly = 1")
        End If
        lStream.WriteLine("fullscreen = 0")
        lStream.WriteLine("8 Bit = 0")
        lStream.WriteLine("shared=0")
        lStream.WriteLine("swapmouse = 0")
        lStream.WriteLine("belldeiconify = 0")
        lStream.WriteLine("emulate3 = 1")
        lStream.WriteLine("emulate3timeout = 100")
        lStream.WriteLine("emulate3fuzz = 4")
        lStream.WriteLine("disableclipboard = 1")
        lStream.WriteLine("localcursor = 1")
        lStream.WriteLine("scale_num = 1")
        lStream.WriteLine("scale_den = 1")
        lStream.WriteLine("use_encoding_6 = 0")
        lStream.WriteLine("use_encoding_7 = 0")
        lStream.WriteLine("use_encoding_8 = 0")
        lStream.WriteLine("use_encoding_9 = 0")
        lStream.WriteLine("use_encoding_10 = 0")
        lStream.WriteLine("use_encoding_11 = 0")
        lStream.WriteLine("use_encoding_12 = 0")
        lStream.WriteLine("use_encoding_13 = 0")
        lStream.WriteLine("use_encoding_14 = 0")
        lStream.WriteLine("use_encoding_15 = 0")
        lStream.WriteLine("use_encoding_16 = 1")
        lStream.WriteLine("autoDetect = 1")
        lStream.Close()

        System.Windows.Forms.Application.DoEvents()
        System.Windows.Forms.Application.DoEvents()
        Shell("C:\4POS\vncviewer.exe -config C:\4POS\connect.vnc", AppWinStyle.NormalFocus)

    End Sub
End Class