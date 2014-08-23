Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmChannel
	Inherits System.Windows.Forms.Form
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim mbChangedByCode As Boolean
    Dim mvBookMark As Integer
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean

    Dim txtFields As New List(Of TextBox)
    Dim optType As New List(Of RadioButton)
    Dim chkFields As New List(Of CheckBox)
	Dim gID As Integer
	
	Private Sub loadLanguage()
        'frmChannel = No Code       [Edit Sale Channel Details]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmChannel.Caption = rsLang("LanguageLayoutLnk_Description"): frmChannel.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1010 'General|Checked
		If rsLang.RecordCount Then _lbl_5.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_5.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lblLabels_1 = No Code     [Name]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblLabels_2 = No Code     [Short Name]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_chkFields_3 = No Code     [Disable this sale Channel on the POS]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkFields_3.Caption = rsLang("LanguageLayoutLnk_Description"): _chkFields_3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_chkFields_4 = No Code     [Do not use Pricing Strategy when doing pricing update]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0
		'If rsLang.RecordCount Then _chkFields_4.Caption = rsLang("LanguageLayoutLnk_Description"): _chkFields_4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_chkFields_5 = No Code     [Treat a case/carton price as the unit price when doing the price update]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkFields_5.Caption = rsLang("LanguageLayoutLnk_Description"): _chkFields_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1(0) = No Code        [When doing the pricing calculation this sale channel relationship to the first sale channel is]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1(0).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1(1) = No Code        [When calculating exit price percentages, prices are calculated as]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1(1).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'optType(0) = No Code       [Cost plus pricing group group percentage]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then optType(0).Caption = rsLang("LanguageLayoutLnk_Description"): optType(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'optType(1) = No Code       [Price of Default sales channel plus pricing group percentage]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then optType(1).Caption = rsLang("LanguageLayoutLnk_Description"): optType(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmChannel.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub buildDataControls()
		'    doDataControl Me.cmbChannel, "SELECT ChannelID, Channel_Name FROM Channel ORDER BY ChannelID", "Customer_ChannelID", "ChannelID", "Channel_Name"
	End Sub
	
    Private Sub doDataControl(ByRef dataControl As myDataGridView, ByRef sql As String, ByRef DataField As String, ByRef boundColumn As String, ByRef listField As String)
        'Dim rs As ADODB.Recordset
        'rs = getRS(sql)
        'dataControl.DataSource = rs
        'dataControl.DataSource = adoPrimaryRS
        'dataControl.DataField = DataField
        'dataControl.boundColumn = boundColumn
        'dataControl.listField = listField
    End Sub
	
	Public Sub loadItem(ByRef id As Integer)
		Dim oText As System.Windows.Forms.TextBox
		Dim oCheck As System.Windows.Forms.CheckBox
		On Error Resume Next
		If id Then
			adoPrimaryRS = getRS("select * from Channel WHERE ChannelID = " & id)
			'        If IsNull(adoPrimaryRS("Channel_PriceToChannel1")) Then
			'            cmbChannelPrice.ListIndex = 0
			'        Else
			Select Case adoPrimaryRS.Fields("Channel_PriceToChannel1").Value
				Case -1
					cmbChannelPrice.SelectedIndex = 1
				Case 1
					cmbChannelPrice.SelectedIndex = 2
				Case Else
					cmbChannelPrice.SelectedIndex = 0
			End Select
			'        End If
		Else
			adoPrimaryRS = getRS("select * from POS")
			adoPrimaryRS.AddNew()
			Me.Text = Me.Text & " [New record]"
			mbAddNewFlag = True
        End If

		setup()
        For Each oText In txtFields
             oText.DataBindings.Add(adoPrimaryRS)
            oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize
        Next oText
		Me.optType(CShort(_txtFields_0.Text)).Checked = True
		If id = 1 Then
            _optType_0.Enabled = False
            _optType_1.Enabled = False
		End If
		'    For Each oText In Me.txtInteger
        '        Set oText.DataBindings.Add(adoPrimaryRS)
        '        txtInteger_LostFocus oText.Index
        '    Next
        '    For Each oText In Me.txtFloat
        '        Set oText.DataBindings.Add(adoPrimaryRS)
        '        If oText.Text = "" Then oText.Text = "0"
        '        oText.Text = oText.Text * 100
        '        txtFloat_LostFocus oText.Index
        '    Next
        '    For Each oText In Me.txtFloatNegative
        '        Set oText.DataBindings.Add(adoPrimaryRS)
		'        If oText.Text = "" Then oText.Text = "0"
		'        oText.Text = oText.Text * 100
		'        txtFloatNegative_LostFocus oText.Index
		'    Next
		'Bind the check boxes to the data provider
        For Each oCheck In chkFields
            oCheck.DataBindings.Add(adoPrimaryRS)
        Next oCheck
		buildDataControls()
		mbDataChanged = False
		
		loadLanguage()
		ShowDialog()
	End Sub
	
	Private Sub setup()
	End Sub
	
	Private Sub Command1_Click()
		
    End Sub

    Private Sub frmChannel_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtFields.AddRange(New TextBox() {_txtFields_0, _txtFields_1, _txtFields_2})
        optType.AddRange(New RadioButton() {_optType_0, _optType_1})
        chkFields.AddRange(New CheckBox() {_chkFields_3, _chkFields_4, _chkFields_5})
        Dim txt As New TextBox
        Dim rb As New RadioButton
        For Each txt In txtFields
            AddHandler txt.Enter, AddressOf txtFields_Enter
        Next
        For Each rb In optType
            AddHandler rb.CheckedChanged, AddressOf optType_CheckedChanged
        Next
    End Sub
	
	'UPGRADE_WARNING: Event frmChannel.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmChannel_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        Dim cmdLast As New Button
        Dim cmdnext As New Button
        Dim lblStatus As New Label
		On Error Resume Next
		lblStatus.Width = pixelToTwips(Me.Width, True) - 1500
		cmdnext.Left = lblStatus.Width + 700
		cmdLast.Left = cmdnext.Left + 340
	End Sub
    Private Sub frmChannel_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Escape
                KeyAscii = 0
                System.Windows.Forms.Application.DoEvents()
                adoPrimaryRS.Move(0)
                cmdClose_Click(cmdClose, New System.EventArgs())
        End Select

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
	Private Sub frmChannel_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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
			If mvBookMark > 0 Then
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
		Dim lDirty As Boolean
		Dim x As Short
		lDirty = False
		update_Renamed = True
		If mbAddNewFlag Then
			adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll)
			adoPrimaryRS.MoveLast() 'move to the new record
		Else
            adoPrimaryRS.Fields("Channel_PriceToChannel1").Value = CDec(cmbChannelPrice.SelectedIndex)
			
			adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll)
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
		cmdClose.Focus()
		System.Windows.Forms.Application.DoEvents()
		If update_Renamed() Then
			Me.Close()
		End If
	End Sub
	
	'UPGRADE_WARNING: Event optType.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub optType_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If eventSender.Checked Then
            Dim opt As New RadioButton
            opt = DirectCast(eventSender, RadioButton)
            Dim Index As Integer = GetIndexer(opt, optType)
            Me._txtFields_0.Text = CStr(Index)
        End If
    End Sub
	
    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
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