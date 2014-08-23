Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmPerson
	Inherits System.Windows.Forms.Form
	Dim gID As Integer
	Dim InOper As Short
	Dim perIden As Short
	Dim mvBookMark As Integer
	Dim inController As Boolean
	Dim blCChanged As Boolean
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
	Dim mbChangedByCode As Boolean
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
    Dim txtFields As List(Of TextBox)
    Dim chkFields As List(Of CheckBox)

	Private Sub loadLanguage()
		
		'frmPerson = No Code        [Edit Employee Details]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmPerson.Caption = rsLang("LanguageLayoutLnk_Description"): frmPerson.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'cmdBOsecurity = No Code    [Back Office Permissions]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdBOsecurity.Caption = rsLang("LanguageLayoutLnk_Description"): cmdBOsecurity.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdPOSsecurity = No Code   [Point Of Sale Security]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdPOSsecurity.Caption = rsLang("LanguageLayoutLnk_Description"): cmdPOSsecurity.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdFPR = No Code           [Finger Print Registration]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdFPR.Caption = rsLang("LanguageLayoutLnk_Description"): cmdFPR.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1010 'General|Checked
		If rsLang.RecordCount Then _lbl_5.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_5.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lblLabels_2 = No Code     [First Name]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1287 'Surname|Checked
		If rsLang.RecordCount Then _lblLabels_4.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_4.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lblLabels_7 = No Code     [Cell]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_7.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_7.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblLabels_5 = No Code     [Position]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_5.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblLabels_13 = No Code    [ID Number]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_13.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_13.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1288 'Telephone|Checked
		If rsLang.RecordCount Then _lblLabels_8.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_8.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lbl_0 = No Code           [Security]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'frmSecurity(0) = No Code   [Back Office Logon]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmSecurity(0).Caption = rsLang("LanguageLayoutLnk_Description"): frmSecurity(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblLabels_10 = No Code    [User ID]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_10.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_10.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2490 'Password|Checked
		If rsLang.RecordCount Then _lblLabels_11.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_11.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'Frame1 = No Code           [Commission %]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Frame1.Caption = rsLang("LanguageLayoutLnk_Description"): Frame1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'frmSecurity(1) = No Code   [Point Of Sale Logon]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmSecurity(1).Caption = rsLang("LanguageLayoutLnk_Description"): frmSecurity(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblLabels_12 = No Code    [Access Scan ID]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_12.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_12.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1 = No Code           [This is a barcode used.......]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2136 'Build|
		If rsLang.RecordCount Then cmdBuild.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdBuild.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lblLabels_0 = No Code     [Default Till/Drawer]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkController = No Code    [Permit this person to terminate controller]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkController.Caption = rsLang("LanguageLayoutLnk_Description"): chkController.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_chkFields_2 = No Code     [Disable this person from using the application suite]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkFields_2.Caption = rsLang("LanguageLayoutLnk_Description"): _chkFields_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmPerson.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub buildDataControls()
		
	End Sub
	
    Private Sub doDataControl(ByRef dataControl As myDataGridView, ByRef sql As String, ByRef DataField As String, ByRef boundColumn As String, ByRef listField As String)
        'Dim rs As ADODB.Recordset
        'rs = getRS(sql)
        'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'dataControl.DataSource = rs
        'UPGRADE_ISSUE: Control method dataControl.DataSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        'dataControl.DataSource = adoPrimaryRS
        'UPGRADE_ISSUE: Control method dataControl.DataField was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        'dataControl.DataField = DataField
        'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.boundColumn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'dataControl.boundColumn = boundColumn
        'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.listField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'dataControl.listField = listField
    End Sub
	
	Public Sub loadItem(ByRef id As Integer)
		Dim rsP As ADODB.Recordset
		Dim oText As System.Windows.Forms.TextBox
		Dim oCheck As System.Windows.Forms.CheckBox
		On Error Resume Next
		
		InOper = id
		inController = False
		
		
		
		If id Then
			adoPrimaryRS = getRS("select PersonID,Person_Title,Person_FirstName,Person_LastName,Person_Position,Person_Cell,Person_Telephone,Person_UserID,Person_Password,Person_QuickAccess,Person_IDNo,Person_Disabled,Person_Drawer from Person WHERE PersonID = " & id)
			rsP = getRS("SELECT * FROM Person WHERE PersonID = " & id)
			txtComm.Text = FormatNumber(rsP.Fields("Person_Comm").Value, 2)
			'for duplication access id
			_txtFields_12.Text = rsP.Fields("Person_QuickAccess").Value
			
			rsP = getRS("SELECT Controller_Permission FROM ControllerPermission WHERE Controller_PersonID = " & id)
			If rsP.RecordCount = 0 Then
				inController = True
				cnnDB.Execute("INSERT INTO ControllerPermission (Controller_PersonID,Controller_Permission) VALUES (" & id & ",0)")
				Me.chkController.CheckState = System.Windows.Forms.CheckState.Unchecked
				Me.chkController.Tag = 0
			Else
				If rsP.Fields("Controller_Permission").Value = True Then
					Me.chkController.CheckState = System.Windows.Forms.CheckState.Checked : Me.chkController.Tag = 1
				Else
					Me.chkController.CheckState = System.Windows.Forms.CheckState.Unchecked : Me.chkController.Tag = 0
				End If
			End If
			_lbl_1.Text = "Employee No. " & id
		Else
			adoPrimaryRS = getRS("select * from Person")
			adoPrimaryRS.AddNew()
			Me.Text = Me.Text & " [New record]"
			mbAddNewFlag = True
			_lbl_1.Text = "Employee No. " & " [New record]"
		End If
		
		setup()
		
		For	Each oText In Me.txtFields
			oText.DataBindings.Add(adoPrimaryRS)
			oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize
		Next oText
		
		perIden = id
		
		On Error Resume Next
		If id Then
			cmbDraw.SelectedIndex = adoPrimaryRS.Fields("Person_Drawer").Value
		Else
			cmbDraw.SelectedIndex = 0
		End If
		
		For	Each oCheck In Me.chkFields
			oCheck.DataBindings.Add(adoPrimaryRS)
		Next oCheck
		
		buildDataControls()
		mbDataChanged = False
		
		loadLanguage()
		ShowDialog()
	End Sub
	
	Private Sub setup()
	End Sub
	Private Sub cmdBOsecurity_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBOsecurity.Click
		If update_Renamed() Then frmBOSecurity.loadItem(adoPrimaryRS.Fields("PersonID").Value)
	End Sub
	
	Private Sub cmdBuild_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBuild.Click
		Dim tt As String
		Dim lCode As String
		lCode = VB.Right("888888888888" & Replace(CStr(CDec(Now.ToOADate)), ".", ""), 12)
		tt = addCheckSum(lCode)
		_txtFields_12.Text = tt
	End Sub
	
	Private Sub cmdFPR_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFPR.Click
		On Error GoTo FPA_Error
		
		'SDK Selection
		Dim rsSDK As ADODB.Recordset
		rsSDK = getRS("SELECT Company_FingerSDK FROM Company")
		If rsSDK.RecordCount Then
			If IIf(IsDbNull(rsSDK.Fields("Company_FingerSDK").Value), 0, rsSDK.Fields("Company_FingerSDK").Value) = 0 Then
				If update_Renamed() Then frmPersonFPReg.loadItem(adoPrimaryRS.Fields("PersonID").Value)
			Else
				If update_Renamed() Then frmPersonFPRegOT.loadItem(adoPrimaryRS.Fields("PersonID").Value)
				frmPersonFPVerifyOT.loadItem((adoPrimaryRS.Fields("PersonID").Value))
			End If
		Else
			If update_Renamed() Then frmPersonFPReg.loadItem(adoPrimaryRS.Fields("PersonID").Value)
		End If
		'SDK Selection
		
		Exit Sub
FPA_Error: 
		If Err.Number = 429 Then
			MsgBox("Driver/Device missing for Finger Print Reader", MsgBoxStyle.Critical)
		Else
			MsgBox(Err.Number & " " & Err.Description, MsgBoxStyle.Critical)
			Resume Next
		End If
	End Sub
	
	Private Sub cmdPOSsecurity_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPOSsecurity.Click
		If update_Renamed() Then frmPOSSecurity.loadItem(adoPrimaryRS.Fields("PersonID").Value)
    End Sub

    Private Sub frmPerson_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtFields.AddRange(New TextBox() {_txtFields_1, _txtFields_2, _txtFields_4, _txtFields_5, _
                                          _txtFields_7, _txtFields_8, _txtFields_10, _txtFields_11, _
                                          _txtFields_12, _txtFields_13})
        chkFields.AddRange(New CheckBox() {_chkFields_2})
        Dim tb As New TextBox
        For Each tb In txtFields
            AddHandler tb.Enter, AddressOf txtFields_Enter
        Next

    End Sub
	
	'UPGRADE_WARNING: Event frmPerson.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmPerson_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        Dim cmdLast As New Button
        Dim cmdNext As New Button
        Dim lblStatus As New Label
		On Error Resume Next
		lblStatus.Width = pixelToTwips(Me.Width, True) - 1500
        cmdNext.Left = lblStatus.Width + 700
		cmdLast.Left = cmdNext.Left + 340
	End Sub
	
	Private Sub frmPerson_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If mbEditFlag Or mbAddNewFlag Then GoTo EventExitSub
		
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.Escape
				KeyAscii = 0
				adoPrimaryRS.Move(0)
				
				cmdClose.Focus()
				System.Windows.Forms.Application.DoEvents()
				cmdClose_Click(cmdClose, New System.EventArgs())
		End Select
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub frmPerson_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
	End Sub
	
	Private Sub adoPrimaryRS_MoveComplete(ByVal adReason As ADODB.EventReasonEnum, ByVal pError As ADODB.Error, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.MoveComplete
		'This will display the current record position for this recordset
	End Sub
	
	Private Sub adoPrimaryRS_WillChangeRecord(ByVal adReason As ADODB.EventReasonEnum, ByVal cRecords As Integer, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.WillChangeRecord
		'This is where you put validation code
		'This event gets called when the following actions occur
		Dim bCancel As Boolean
		Select Case adReason
			Case ADODB.EventReasonEnum.adRsnAddNew
			Case ADODB.EventReasonEnum.adRsnClose
			Case ADODB.EventReasonEnum.adRsnDelete
			Case ADODB.EventReasonEnum.adRsnFirstChange
			Case ADODB.EventReasonEnum.adRsnMove
			Case ADODB.EventReasonEnum.adRsnRequery
			Case ADODB.EventReasonEnum.adRsnResynch
			Case ADODB.EventReasonEnum.adRsnUndoAddNew
			Case ADODB.EventReasonEnum.adRsnUndoDelete
			Case ADODB.EventReasonEnum.adRsnUndoUpdate
			Case ADODB.EventReasonEnum.adRsnUpdate
		End Select
		
		If bCancel Then adStatus = ADODB.EventStatusEnum.adStatusCancel
	End Sub
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		On Error Resume Next
		If mbAddNewFlag Then
			Me.Close()
		Else
			mbEditFlag = False
			mbAddNewFlag = False
			adoPrimaryRS.CancelUpdate()
			'UPGRADE_WARNING: Couldn't resolve default property of object mvBookMark. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If mvBookMark > 0 Then
				'UPGRADE_WARNING: Couldn't resolve default property of object mvBookMark. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				adoPrimaryRS.Bookmark = mvBookMark
			Else
				adoPrimaryRS.MoveFirst()
			End If
			mbDataChanged = False
		End If
	End Sub
	'UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Function update_Renamed() As Boolean
		On Error GoTo UpdateErr
		update_Renamed = True
		adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll)
		If mbAddNewFlag Then
			adoPrimaryRS.MoveLast() 'move to the new record
		End If
		
		mbEditFlag = False
		mbAddNewFlag = False
		mbDataChanged = False
		Exit Function
UpdateErr: 
		MsgBox(Err.Description)
		update_Renamed = False
	End Function
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Dim rs As ADODB.Recordset
		Dim rsValue As String
		
		
		If InOper <> 0 Then
			'for old employee
			If inController = True Then
				cnnDB.Execute("UPDATE Person SET Person_Comm = " & Val(rsValue) & " WHERE PersonID = " & perIden)
				cnnDB.Execute("UPDATE ControllerPermission SET Controller_Permission = " & Val(CStr(Me.chkController.CheckState)) & " WHERE Controller_PersonID = " & perIden)
			Else
				
				cnnDB.Execute("UPDATE Person SET Person_Comm = " & Val(txtComm.Text) & " WHERE PersonID = " & perIden)
				If Me.chkController.CheckState <> CDbl(Me.chkController.Tag) Then
					cnnDB.Execute("UPDATE ControllerPermission SET Controller_Permission = " & Val(CStr(Me.chkController.CheckState)) & " WHERE Controller_PersonID = " & perIden)
				End If
			End If
			
			cnnDB.Execute("UPDATE Person SET Person_Drawer = " & cmbDraw.SelectedIndex & " WHERE PersonID = " & perIden)
			
			'for duplication access id
			rs = getRS("Select * FROM Person WHERE Person_QuickAccess = '" & Trim(_txtFields_12.Text) & "' AND PersonID <> " & perIden & ";")
			If rs.RecordCount > 0 Then
				MsgBox("Access Scan ID already being used, Please choose another!!", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
				_txtFields_12.Focus()
				Exit Sub
			End If
			cnnDB.Execute("UPDATE Person SET Person_QuickAccess = '" & _txtFields_12.Text & "' WHERE PersonID = " & perIden)
			
		Else
			
			'New employee being added
			rsValue = txtComm.Text
			'if new add validation
			rs = getRS("Select * FROM Person WHERE Person_QuickAccess = '" & Trim(_txtFields_12.Text) & "'")
			If rs.RecordCount > 0 Then
				MsgBox("Access Scan ID already being used, Please choose another!!", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
				_txtFields_12.Focus()
				Exit Sub
			End If
			'exit sub
		End If
		
		cmdClose.Focus()
		System.Windows.Forms.Application.DoEvents()
		If update_Renamed() Then
			
			If InOper = 0 Then
				rs = getRS("SELECT MAX(PersonID) FROM Person")
				
				'if new add access code
				cnnDB.Execute("UPDATE Person SET Person_QuickAccess = '" & _txtFields_12.Text & "' WHERE PersonID = " & rs.Fields(0).Value)
				
				cnnDB.Execute("UPDATE Person SET Person_Comm = " & Val(rsValue) & " WHERE PersonID = " & rs.Fields(0).Value)
				cnnDB.Execute("INSERT INTO ControllerPermission (Controller_PersonID,Controller_Permission) VALUES (" & rs.Fields(0).Value & "," & Me.chkController.CheckState & ")")
				
				cnnDB.Execute("UPDATE Person SET Person_Drawer = " & cmbDraw.SelectedIndex & " WHERE PersonID = " & rs.Fields(0).Value)
			End If
			Me.Close()
		End If
		
		
	End Sub
	
	Private Sub txtComm_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtComm.Enter
		MyGotFocusNumeric(txtComm.Text())
	End Sub
	
	Private Sub txtComm_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtComm.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		MyKeyPress(KeyAscii)
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	Private Sub txtComm_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtComm.Leave
        MyLostFocus(txtComm, 2)
	End Sub
	
    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) '
        Dim txt As New TextBox
        txt = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txt, txtFields)
        MyGotFocus(txtFields(Index))
    End Sub

    Private Sub txtInteger_MyGotFocus(ByRef Index As Short)
        '    MyGotFocusNumeric txtInteger(Index)
    End Sub

    Private Sub txtInteger_KeyPress(ByRef Index As Short, ByRef KeyAscii As Short)
        '    KeyPress KeyAscii
    End Sub

    Private Sub txtInteger_MyLostFocus(ByRef Index As Short)
        '    LostFocus txtInteger(Index), 0
    End Sub

    Private Sub txtFloat_MyGotFocus(ByRef Index As Short)
        '    MyGotFocusNumeric txtFloat(Index)
    End Sub

    Private Sub txtFloat_KeyPress(ByRef Index As Short, ByRef KeyAscii As Short)
        '    KeyPress KeyAscii
    End Sub

    Private Sub txtFloat_MyLostFocus(ByRef Index As Short)
        '    LostFocus txtFloat(Index), 2
    End Sub

    Private Sub txtFloatNegative_MyGotFocus(ByRef Index As Short)
        '    MyGotFocusNumeric txtFloatNegative(Index)
    End Sub
	
	Private Sub txtFloatNegative_KeyPress(ByRef Index As Short, ByRef KeyAscii As Short)
		'    KeyPressNegative txtFloatNegative(Index), KeyAscii
	End Sub
	
	Private Sub txtFloatNegative_MyLostFocus(ByRef Index As Short)
		'    LostFocus txtFloatNegative(Index), 2
	End Sub
End Class