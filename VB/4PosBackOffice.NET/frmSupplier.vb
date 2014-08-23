Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmSupplier
	Inherits System.Windows.Forms.Form
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim mbChangedByCode As Boolean
    Dim mvBookMark As Integer
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean

    Dim txtFloat As New List(Of TextBox)
    Dim txtFields As New List(Of TextBox)
    Dim txtFloatNegative As New List(Of TextBox)
    Dim chkFields As New List(Of CheckBox)

	Dim gID As Integer
	
	Private Sub loadLanguage()
		
		'NOTE: DB Entry 1437 contains invalid text!!!
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1437 'Edit Supplier Details|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1282 'Statement|Checked
		If rsLang.RecordCount Then cmdStatement.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdStatement.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1010 'General|Checked
		If rsLang.RecordCount Then _lbl_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1442 'Supplier Name|Checked
		If rsLang.RecordCount Then _lblLabels_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1288 'Telephone|Checked
		If rsLang.RecordCount Then _lblLabels_8.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_8.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1289 'Fax|Checked
		If rsLang.RecordCount Then _lblLabels_9.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_9.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1291 'Physical Address|Checked
		If rsLang.RecordCount Then _lblLabels_6.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_6.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1292 'Postal Address|Checked
		If rsLang.RecordCount Then _lblLabels_7.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_7.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1447 'Disable this Supplier|Checked
		If rsLang.RecordCount Then _chkFields_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _chkFields_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1448 'Aging|Checked
		If rsLang.RecordCount Then _lbl_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1295 'Current|Checked
		If rsLang.RecordCount Then _lblLabels_13.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_13.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1297 '60 Days|Checked
		If rsLang.RecordCount Then _lblLabels_15.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_15.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1299 '120 Days|Checked
		If rsLang.RecordCount Then _lblLabels_17.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_17.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1296 '30 Days|Checked
		If rsLang.RecordCount Then _lblLabels_14.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_14.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1298 '90 Days|Checked
		If rsLang.RecordCount Then _lblLabels_16.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_16.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1454 'Ordering Details|Checked
		If rsLang.RecordCount Then _lbl_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1455 'Representative Name|Checked
        If rsLang.RecordCount Then _lblLabels_38.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_38.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1456 'Reperesentative Number|Checked
        If rsLang.RecordCount Then _lblLabels_37.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_37.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1457 'Account number|Checked
        If rsLang.RecordCount Then _lblLabels_36.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_36.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1458 'Default Order Attention Line Text|Checked
        If rsLang.RecordCount Then _lblLabels_35.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_35.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1459 'GRV Template|Checked
		If rsLang.RecordCount Then _lbl_4.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_4.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1460 'Payment Terms|Checked
		If rsLang.RecordCount Then _lbl_3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1461 'Ullage Discount|Checked
        If rsLang.RecordCount Then _lblLabels_33.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_33.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1462 'C.O.D|Checked
        If rsLang.RecordCount Then _lblLabels_32.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_32.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1296 '30 Days|Checked
        If rsLang.RecordCount Then _lblLabels_30.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_30.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1298 '90 Days|Checked
        If rsLang.RecordCount Then _lblLabels_28.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_28.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1468 'Smart Card|Checked
        If rsLang.RecordCount Then _lblLabels_26.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_26.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lblLabels(31) = No Code    [15 Days]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblLabels(31).Caption = rsLang("LanguageLayoutLnk_Description"): lblLabels(31).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1297 '60 Days|Checked
        If rsLang.RecordCount Then _lblLabels_29.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_29.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1299 '120 Days|Checked
        If rsLang.RecordCount Then _lblLabels_27.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_27.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmSupplier.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub buildDataControls()
		'    doDataControl Me.cmbChannel, "SELECT ChannelID, Channel_Name FROM Channel ORDER BY ChannelID", "Customer_ChannelID", "ChannelID", "Channel_Name"
		doDataControl((Me.cmbTemplate), "SELECT GRVTemplateID, GRVTemplate_Name FROM GRVTemplate ORDER BY GRVTemplate_Name", "Supplier_GRVtype", "GRVTemplate_Name", "GRVTemplate_Name")
		'doDataControl Me.cmbKeyboard, "SELECT KeyboardLayout.KeyboardLayoutID, KeyboardLayout.KeyboardLayout_Name FROM KeyboardLayout ORDER BY KeyboardLayout_Name", "POS_Keyboard", "KeyboardLayoutID", "KeyboardLayout_Name"
	End Sub
	
    Private Sub doDataControl(ByRef dataControl As myDataGridView, ByRef sql As String, ByRef DataField As String, ByRef boundColumn As String, ByRef listField As String)
        Dim rs As ADODB.Recordset
        rs = getRS(sql)
        dataControl.DataSource = rs
       dataControl.DataSource = adoPrimaryRS
        dataControl.DataField = DataField
        dataControl.boundColumn = boundColumn
        dataControl.listField = listField
    End Sub
	
	Public Sub loadItem(ByRef id As Integer)
		Dim oText As System.Windows.Forms.TextBox
		Dim oCheck As System.Windows.Forms.CheckBox
		On Error Resume Next
		
		gID = id
		
		Dim cBitA As Boolean
		Dim cBitF As Boolean
		If id Then
			adoPrimaryRS = getRS("select * from Supplier WHERE SupplierID = " & id)
			
			If 32 And frmMenu.gBit Then cBitA = True
			If 64 And frmMenu.gBit Then cBitF = True
			If cBitA = True And cBitF = True Then
                _txtFloat_13.Enabled = True
                _txtFloat_14.Enabled = True
                _txtFloat_15.Enabled = True
                _txtFloat_16.Enabled = True
                _txtFloat_17.Enabled = True
			End If
			
		Else
			adoPrimaryRS = getRS("select * from Supplier")
			adoPrimaryRS.AddNew()
			Me.Text = Me.Text & " [New record]"
			mbAddNewFlag = True
		End If
		'    If adoPrimaryRS.BOF Or adoPrimaryRS.EOF Then
		'    Else
		On Error Resume Next
        For Each oText In txtFields
            oText.DataBindings.Add(adoPrimaryRS)
            oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize
        Next oText
		'        For Each oText In Me.txtInteger
		'            Set oText.DataBindings.Add(adoPrimaryRS)
		'            txtInteger_LostFocus oText.Index
		'        Next
        For Each oText In txtFloat
            oText.DataBindings.Add(adoPrimaryRS)
            If oText.Text = "" Then oText.Text = "0"
            oText.Text = CStr(CDbl(oText.Text) * 100)
            AddHandler oText.Leave, AddressOf txtFloat_Leave
        Next oText
        For Each oText In txtFloatNegative
            oText.DataBindings.Add(adoPrimaryRS)
            If oText.Text = "" Then oText.Text = "0"
            oText.Text = CStr(CDbl(oText.Text) * 100)
            AddHandler oText.Leave, AddressOf txtFloatNegative_Leave
        Next oText
		'Bind the check boxes to the data provider
		For	Each oCheck In Me.chkFields
            oCheck.DataBindings.Add(adoPrimaryRS)
		Next oCheck
		buildDataControls()
		mbDataChanged = False
		
		loadLanguage()
		ShowDialog()
		'    End If
	End Sub
	
	Private Sub cmdStatement_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStatement.Click
		If mbAddNewFlag Then
			MsgBox("There is no statement for a new supplier.", MsgBoxStyle.Exclamation, "New Supplier")
		Else
			report_SupplierStatement(adoPrimaryRS.Fields("SupplierID").Value)
		End If
    End Sub

    Private Sub frmSupplier_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtFloat.AddRange(New TextBox() {_txtFloat_13, _txtFloat_14, _txtFloat_15, _txtFloat_16, _
                                         _txtFloat_17})
        txtFields.AddRange(New TextBox() {_txtFields_1, _txtFields_2, _txtFields_6, _txtFields_7, _
                                          _txtFields_8, _txtFields_9, _txtFields_26, _txtFields_27, _
                                          _txtFields_28})
        txtFloatNegative.AddRange(New TextBox() {_txtFloatNegative_11, _txtFloatNegative_12, _
                                                 _txtFloatNegative_13, _txtFloatNegative_14, _
                                                 _txtFloatNegative_15, _txtFloatNegative_16, _
                                                 _txtFloatNegative_17, _txtFloatNegative_18})
        chkFields.AddRange(New CheckBox() {_chkFields_1})
        Dim tb As New TextBox
        For Each tb In txtFields
            AddHandler tb.Enter, AddressOf txtFields_Enter
        Next
        For Each tb In txtFloat
            AddHandler tb.Enter, AddressOf txtFloat_Enter
            AddHandler tb.KeyPress, AddressOf txtFloat_KeyPress
        Next
        For Each tb In txtFloatNegative
            AddHandler tb.Enter, AddressOf txtFloatNegative_Enter
            AddHandler tb.KeyPress, AddressOf txtFloatNegative_KeyPress
        Next
    End Sub
	
	'UPGRADE_WARNING: Event frmSupplier.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmSupplier_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        Dim cmdLast As New Button
        Dim cmdNext As New Button
        Dim lblStatus As New Label
		On Error Resume Next
		lblStatus.Width = pixelToTwips(Me.Width, True) - 1500
		cmdNext.Left = lblStatus.Width + 700
		cmdLast.Left = cmdNext.Left + 340
	End Sub
	
	Private Sub frmSupplier_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If mbEditFlag Or mbAddNewFlag Then Exit Sub
		
		Select Case KeyCode
			Case System.Windows.Forms.Keys.Escape
				KeyCode = 0
				System.Windows.Forms.Application.DoEvents()
				adoPrimaryRS.Move(0)
				cmdClose_Click(cmdClose, New System.EventArgs())
		End Select
	End Sub
	
	Private Sub frmSupplier_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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
        Dim oText As New TextBox
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
            For Each oText In txtFloat
                If oText.Text = "" Then oText.Text = "0"
                oText.Text = oText.Text * 100
                'txtFloat_Leave(txtFloat.Item(oText.Index), New System.EventArgs())
            Next oText
			For	Each oText In Me.txtFloatNegative
				If oText.Text = "" Then oText.Text = "0"
				oText.Text = oText.Text * 100
				'txtFloatNegative_Leave(txtFloatNegative.Item(oText.Index), New System.EventArgs())
			Next oText
			mbDataChanged = False
			
			Me.Close()
		End If
	End Sub
	Private Function update_Renamed() As Boolean
		On Error GoTo UpdateErr
		update_Renamed = True
		If _txtFields_2.Text = "" Then
			MsgBox("A Supplier's Name is required.", MsgBoxStyle.Information, "Suppler's Details")
			_txtFields_2.Focus()
			update_Renamed = False
			Exit Function
		End If
		
		update_Renamed = True
		'adoPrimaryRS.UpdateBatch adAffectAll
		'If mbAddNewFlag Then
		'    adoPrimaryRS.MoveLast              'move to the new record
		'End If
		
		'mbEditFlag = False
		'mbAddNewFlag = False
		'mbDataChanged = False
		
		
		If mbAddNewFlag Then
			adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll)
			adoPrimaryRS.MoveLast() 'move to the new record
		Else
			adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll)
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
		
		If gID And txtFloat(13).Enabled = True Then
			rs = getRS("SELECT SUM(SupplierTransaction.SupplierTransaction_Amount) As sumTran From SupplierTransaction WHERE (((SupplierTransaction.SupplierTransaction_SupplierID)=" & gID & "));")
			If rs.RecordCount > 0 Then
				If System.Math.Round(IIf(IsDbNull(rs.Fields("sumTran").Value), 0, rs.Fields("sumTran").Value), 2) <> System.Math.Round(CDec(txtFloat(13).Text) + CDec(txtFloat(14).Text) + CDec(txtFloat(15).Text) + CDec(txtFloat(16).Text) + CDec(txtFloat(17).Text), 2) Then
					MsgBox("Aging does not match with total Balance!", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
                    MyGotFocusNumeric(_txtFloat_13)
                    _txtFloat_13.Focus()
					Exit Sub
				End If
			End If
		End If
		
		cmdClose.Focus()
		System.Windows.Forms.Application.DoEvents()
		If update_Renamed() Then
			Me.Close()
		End If
	End Sub
	
    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim txtbox As New TextBox
        txtbox = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txtbox, txtFields)
        MyGotFocus(txtFields(Index))
    End Sub
	
    Private Sub txtFloat_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim txtbox As New TextBox
        txtbox = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txtbox, txtFloat)
        MyGotFocusNumeric(txtFloat(Index))
    End Sub
	
    Private Sub txtFloat_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'Dim Index As Short = txtFloat.GetIndex(eventSender)
        MyKeyPress(KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub txtFloat_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim txtbox As New TextBox
        txtbox = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txtbox, txtFloat)
        MyLostFocus(txtFloat(Index), 2)
    End Sub
	
    Private Sub txtFloatNegative_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim txtbox As New TextBox
        txtbox = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txtbox, txtFloatNegative)
        MyGotFocusNumeric(txtFloatNegative(Index))
    End Sub
	
    Private Sub txtFloatNegative_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim txtbox As New TextBox
        txtbox = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txtbox, txtFloatNegative)
        MyKeyPressNegative(txtFloatNegative(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub txtFloatNegative_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim txtbox As New TextBox
        txtbox = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txtbox, txtFloatNegative)
        MyLostFocus(txtFloatNegative(Index), 2)
    End Sub
End Class