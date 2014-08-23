Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmFloatRepre
	Inherits System.Windows.Forms.Form
	Dim g_Default As Integer 'Save Default ....
	Dim g_Defailt2 As Integer
	Dim grsKey_ID As Integer
	Dim g_FloatU As Integer
	Dim g_Enough As Boolean
	Dim g_NewKy As Boolean
	Dim g_FloatU_1 As Boolean
	Dim g_floatSet As Boolean
	Dim grsKeyboard As Boolean

    Dim txtFloat As New List(Of TextBox)

	Private Sub loadLanguage()

		'frmFloatRepre = No Code    [Denomination Details]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmFloatRepre.Caption = rsLang("LanguageLayoutLnk_Description"): frmFloatRepre.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then Command1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Command1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'Label1 = No Code           [Float Details]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label3 = No Code           [Float Name]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label3.Caption = rsLang("LanguageLayoutLnk_Description"): Label3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label5 = No Code           [Float Type]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label5.Caption = rsLang("LanguageLayoutLnk_Description"): COMPONENT(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label9 = No Code           [Float Value]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label9.Caption = rsLang("LanguageLayoutLnk_Description"): Label9.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label4 = No Code           [Float Pack]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label4.Caption = rsLang("LanguageLayoutLnk_Description"): Label4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label8 = No Code           [Change Float Type]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label8.Caption = rsLang("LanguageLayoutLnk_Description"): Label8.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkDisable = No Code       [Float Disabled]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkDisable.Caption = rsLang("LanguageLayoutLnk_Description"): chkDisable.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label2 = No Code           [Preset Details]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label2.Caption = rsLang("LanguageLayoutLnk_Description"): Label2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkKey = No Code           [Float set as a Fast Preset Tender on POS]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkKey.Caption = rsLang("LanguageLayoutLnk_Description"): chkKey.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label6 = No Code           [Keyboard Name]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label6.Caption = rsLang("LanguageLayoutLnk_Description"): Label6.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label7 = No Code           [Keyboard Key(s)]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label7.Caption = rsLang("LanguageLayoutLnk_Description"): Label7.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmFloatRepre.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Sub loadItem(ByRef id As Integer)
		Dim rs As ADODB.Recordset
		Dim rt As ADODB.Recordset
		Dim rk As ADODB.Recordset
		
		g_floatSet = False
		
		rs = getRS("SELECT * FROM [Float] WHERE Float.Float_Unit = " & CInt(id) & ";")
		If rs.RecordCount Then
			
			g_FloatU = CInt(id)
			_txtFloat_0.Text = rs.Fields("Float_Name").Value
			'_txtFloat_1.Text = rs("Float_Pack")
			_txtFloat_1.Text = FormatNumber(rs.Fields("Float_Pack").Value)
			g_Defailt2 = CDbl(FormatNumber(rs.Fields("Float_Pack").Value)) * 100
			
			'If rs("Float_Type") = True Then
			'   _txtFloat_2.Text = "Note"
			If rs.Fields("Float_Type").Value = True Then
				_txtFloat_2.Text = "Note"
				Me.cbmChangeType.SelectedIndex = 1
			Else
				_txtFloat_2.Text = "Coin"
				Me.cbmChangeType.SelectedIndex = 0
			End If
			'Do presets....
			rt = getRS("SELECT Float.*, tblPresetTender.* FROM tblPresetTender INNER JOIN [Float] ON tblPresetTender.tblValue = Float.Float_Unit WHERE Float.Float_Unit = " & CInt(id) & ";")
			If rt.RecordCount Then
				rk = getRS("SELECT keyboard.keyboard_Name,keyboard.keyboard_Description, keyboard.keyboard_Show,keyboard.keyboardID FROM tblPresetTender INNER JOIN keyboard ON tblPresetTender.tblKey = keyboard.KeyboardID WHERE tblPresetTender.tblValue = " & CInt(id) & ";")
				If rk.RecordCount Then
                    g_Enough = False
                    _txtKey_0.Text = rk.Fields("keyboard_Name").Value
					grsKey_ID = rk.Fields("keyboardID").Value
					
					rk = getRS("SELECT KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_Description FROM KeyboardKeyboardLayoutLnk WHERE KeyboardKeyboardLayoutLnk_KeyboardID = " & rk.Fields("keyboardID").Value & ";")
					'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If IsDbNull(rk.Fields("KeyboardKeyboardLayoutLnk_Description").Value) Then
					Else
                        _txtKey_1.Text = rk.Fields("KeyboardKeyboardLayoutLnk_Description").Value
					End If
					
					If rt.Fields("tblActivated").Value = True Then
						g_FloatU_1 = True
						chkKey.CheckState = System.Windows.Forms.CheckState.Checked : chkKey.Tag = 1
					Else
						g_FloatU_1 = False
						chkKey.CheckState = System.Windows.Forms.CheckState.Unchecked : chkKey.Tag = 0
					End If
				Else
					g_Enough = True
				End If
			Else
				'Check if there is option for new Preset....
				rt = getRS("SELECT * FROM tblPresetTender WHERE tblKey >= 5000 AND tblActivated = False")
				
				If rt.RecordCount Then
					g_Enough = True
					g_FloatU_1 = False
					chkKey.CheckState = System.Windows.Forms.CheckState.Unchecked : chkKey.Tag = 0
                    _txtKey_0.Enabled = False
                    _txtKey_1.Enabled = False
				Else
					g_Enough = True
					g_FloatU_1 = False
					chkKey.CheckState = System.Windows.Forms.CheckState.Unchecked : chkKey.Tag = 0
					chkKey.Enabled = False
                    _txtKey_0.Enabled = False
                    _txtKey_1.Enabled = False
				End If
				
			End If
			
			
			g_Default = rs.Fields("Float_unit").Value
            _txtFloat_3.Text = FormatNumber(rs.Fields("Float_unit").Value / 100)
			
			If rs.Fields("Float_Disabled").Value = True Then
				chkDisable.CheckState = System.Windows.Forms.CheckState.Checked : chkDisable.Tag = 1
			Else
				chkDisable.CheckState = System.Windows.Forms.CheckState.Unchecked : chkDisable.Tag = 0
			End If
			
		End If
		g_floatSet = True
		
		loadLanguage()
		ShowDialog()
	End Sub
	Private Sub chkKey_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkKey.CheckStateChanged
        Dim st1 As String
        Dim grsKeyID As String
		Dim rs As ADODB.Recordset
		
		On Error Resume Next
		
		If g_floatSet = True Then
			If g_Enough = False Then
				Exit Sub
			End If
			
			If g_Enough = True Then
				rs = getRS("SELECT * FROM tblPresetTender WHERE tblKey >= 5000 AND tblActivated = False")
				If rs.RecordCount Then
					grsKeyID = rs.Fields("tblkey").Value
                    _txtKey_0.Text = Me._txtFloat_0.Text
					grsKey_ID = rs.Fields("tblKey").Value
					g_NewKy = True
				Else
					st1 = "You've already allocated enough presets on your POS."
					st1 = st1 & "To allocate a new one please disable anyone."
					MsgBox(st1, MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "New Preset")
					Exit Sub
				End If
			End If
		End If
	End Sub
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Dim dValue_1 As Integer
		Dim stType As Short
		Dim rj As ADODB.Recordset
		On Error Resume Next
		
        If _txtKey_1.Text <> "" Then
            If _txtKey_0.Text = "" Then
                MsgBox("Keyboard Name is a required filed", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Preset Tender")
                Exit Sub
            Else
                If g_Enough = True Then
                Else
                    cnnDB.Execute("UPDATE Keyboard Set keyboard_Name = '" & Replace(_txtKey_0.Text, "'", "''") & "', keyboard_Description = '" & Replace(_txtKey_0.Text, "'", "''") & "' WHERE keyboardID = " & grsKey_ID & ";")
                    cnnDB.Execute("UPDATE tblPresetTender SET tblDescription ='" & Replace(_txtKey_0.Text, "'", "''") & "',tblActivated = " & Val(CStr(Me.chkKey.CheckState)) & " WHERE tblKey = " & grsKey_ID & ";")
                End If
            End If
        End If
		
		If _txtFloat_0.Text <> "" Then
            dValue_1 = CInt(CDbl(FormatNumber(_txtFloat_3.Text)) * 100)
			If Me.cbmChangeType.Text <> "" Then
				If Me.cbmChangeType.Text = "Coin" Then stType = 0 Else stType = 1
				cnnDB.Execute("UPDATE [Float] Set Float.Float_Type = " & stType & ", Float.Float_Name = '" & Replace(Me._txtFloat_0.Text, "'", "''") & "', Float.Float_Disabled = " & Val(CStr(Me.chkDisable.CheckState)) & ", Float.Float_Pack = " & CInt(_txtFloat_1.Text) & " WHERE Float.Float_Unit = " & g_FloatU & ";")
			Else
				cnnDB.Execute("UPDATE [Float] Set Float.Float_Name = '" & Replace(Me._txtFloat_0.Text, "'", "''") & "', Float.Float_Disabled = " & Val(CStr(Me.chkDisable.CheckState)) & ", Float.Float_Pack = " & CInt(_txtFloat_1.Text) & " WHERE Float.Float_Unit = " & g_FloatU & ";")
			End If
			
			If g_Default = dValue_1 Then
				
			ElseIf dValue_1 = 0 Then 
			Else
				rj = getRS("SELECT * FROM [Float] WHERE Float.Float_Unit = " & dValue_1 & ";")
				If rj.RecordCount Then
					MsgBox("Denomination with this Float Unit/Amount exist already, New Amount would not be updated", MsgBoxStyle.Information + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OKOnly, "New Denomination")
				Else
					cnnDB.Execute("UPDATE [Float] Set Float.Float_Unit = " & dValue_1 & " WHERE Float.Float_Unit = " & g_FloatU & ";")
				End If
			End If
			
		End If
		
		If g_FloatU_1 = True Then
			
			If g_Enough = True Then
			Else
				
				cnnDB.Execute("UPDATE tblPresetTender SET tblActivated = " & Val(CStr(Me.chkKey.CheckState)) & " WHERE tblKey = " & grsKey_ID & ";")
			End If
			
		End If
		
		If g_NewKy = True Then
            cnnDB.Execute("UPDATE Keyboard Set keyboard_Name = '" & Replace(_txtKey_0.Text, "'", "''") & "', keyboard_Description = '" & Replace(_txtKey_0.Text, "'", "''") & "', keyboard_Show = 1 WHERE keyboardID = " & grsKey_ID & ";")
            cnnDB.Execute("UPDATE tblPresetTender SET tblDescription ='" & Replace(_txtKey_0.Text, "'", "''") & "',tblValue =" & g_FloatU & ", tblActivated = 1 WHERE tblKey = " & grsKey_ID & ";")
			g_NewKy = False
		End If
		
		Me.Close()
	End Sub
    Sub LostFocus1(ByRef lControl As Control, ByRef lDecimal As Integer)
        If lControl.Text = "" Then Exit Sub
        If lDecimal Then
            lControl.Text = lControl.Text / 100
        End If
        'lControl.Text = FormatNumber(lControl.Text, lDecimal)
        lControl.Text = FormatNumber(lControl.Text)
    End Sub
	
	
    Private Sub txtFloat_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim index As Integer
        Dim n As TextBox
        n = DirectCast(eventSender, TextBox)
        index = GetIndexer(n, txtFloat)
        If Index = 1 Or Index = 3 Then
            MyGotFocusNumeric(txtFloat(index))
        End If
    End Sub
    Private Sub txtFloat_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim index As Integer
        Dim n As TextBox
        n = DirectCast(eventSender, TextBox)
        index = GetIndexer(n, txtFloat)
        If Index = 1 Or Index = 3 Then
            MyKeyPress(KeyAscii)
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub txtFloat_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim index As Integer
        Dim n As TextBox
        n = DirectCast(eventSender, TextBox)
        index = GetIndexer(n, txtFloat)
        Dim g_Defailt As String
        If Index = 1 Then
            If _txtFloat_1.Text = "" Then
                _txtFloat_1.Text = CStr(g_Defailt2)
            End If

            If _txtFloat_1.Text <> "" Then
                If CDbl(FormatNumber(_txtFloat_1.Text)) = 0 Then
                    _txtFloat_1.Text = CStr(g_Defailt2)
                ElseIf CInt(CDbl(FormatNumber(_txtFloat_1.Text)) / 100) = 0 Then
                    _txtFloat_1.Text = CStr(g_Defailt2)
                End If
            End If
            LostFocus1(_txtFloat_1, 2)
        End If

        If Index = 3 Then
            If txtFloat(3).Text = "" Then
                txtFloat(3).Text = CStr(g_Default)
            End If

            If txtFloat(3).Text <> "" Then
                If CDbl(FormatNumber(txtFloat(3).Text)) = 0 Then
                    txtFloat(3).Text = CStr(g_Default)
                ElseIf CInt(CDbl(FormatNumber(txtFloat(3).Text)) / 100) = 0 Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object g_Defailt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    txtFloat(3).Text = g_Defailt
                End If

            End If
            LostFocus1(txtFloat(3), 2)
        End If


    End Sub

    Private Sub frmFloatRepre_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtFloat.AddRange(New TextBox() {_txtFloat_0, _txtFloat_1, _txtFloat_2, _txtFloat_3})
        Dim tb As New TextBox
        For Each tb In txtFloat
            AddHandler tb.Enter, AddressOf txtFloat_Enter
            AddHandler tb.KeyPress, AddressOf txtFloat_KeyPress
            AddHandler tb.Leave, AddressOf txtFloat_Leave
        Next
    End Sub
End Class