Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmCustomer
	Inherits System.Windows.Forms.Form
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim mbChangedByCode As Boolean
    Dim mvBookMark As Integer
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
    Dim mbDataChanged As Boolean
    Dim gID As Integer

    Dim txtFields As New List(Of TextBox)
    Dim txtFloat As New List(Of TextBox)
    Dim chkFields As New List(Of CheckBox)
	
	Private Sub loadLanguage()
		
		'frmCustomer = No Code      [Edit Customer Details]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmCustomer.Caption = rsLang("LanguageLayoutLnk_Description"): frmCustomer.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1282 'Statement|Checked
		If rsLang.RecordCount Then cmdStatement.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdStatement.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1010 'General|Checked
		If rsLang.RecordCount Then _lbl_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1284 'Invoice Name|Checked
		If rsLang.RecordCount Then _lblLabels_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lblLabels_3 = No Code     [Department]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_3.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1286 'Responsible Person Name|Checked
		If rsLang.RecordCount Then _lblLabels_4.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_4.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1287 'Surname|Checked
		If rsLang.RecordCount Then _lblLabels_5.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_5.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1288 'Telephone|Checked
		If rsLang.RecordCount Then _lblLabels_8.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_8.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1290 'Email|Checked
		If rsLang.RecordCount Then _lblLabels_10.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_10.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1291 'Physical Address|Checked
		If rsLang.RecordCount Then _lblLabels_6.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_6.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1292 'Postal Address|Checked
		If rsLang.RecordCount Then _lblLabels_7.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_7.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1319 'Financials|Checked
		If rsLang.RecordCount Then _lbl_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1293 'Credit Limit|Checked
		If rsLang.RecordCount Then _lblLabels_12.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_12.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1295 'Current|Checked
		If rsLang.RecordCount Then _lblLabels_13.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_13.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1297 '60 Days|Checked
		If rsLang.RecordCount Then _lblLabels_15.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_15.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1299 '120 Days|Checked
		If rsLang.RecordCount Then _lblLabels_17.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_17.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1301 'Sale Channel|Checked
		If rsLang.RecordCount Then _lblLabels_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1294 'Terms|Checked
		If rsLang.RecordCount Then _lblLabels_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1296 '30 Days|Checked
		If rsLang.RecordCount Then _lblLabels_14.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_14.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1298 '90 Days|Checked
		If rsLang.RecordCount Then _lblLabels_16.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_16.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1300 '150 Days|Checked
		If rsLang.RecordCount Then _lblLabels_18.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_18.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1302 'Automatically Print a Statement at Month end|
		If rsLang.RecordCount Then chkFields(19).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : chkFields(19).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1303 'Disable this customer from Point of Sale|
		If rsLang.RecordCount Then _chkFields_11.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _chkFields_11.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lblLabels_11 = No Code    [VAT Number]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_11.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_11.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmCustomer.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
	End Sub
	
	Private Sub buildDataControls()
		doDataControl((Me.cmbChannel), "SELECT ChannelID, Channel_Name FROM Channel ORDER BY ChannelID", "Customer_ChannelID", "ChannelID", "Channel_Name")
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
		gID = 0
		
		Dim cBitA As Boolean
		Dim cBitF As Boolean
		If id Then
			'checkcustid = id
			adoPrimaryRS = getRS("select * from Customer WHERE CustomerID = " & id)
			cmbTerms.SelectedIndex = adoPrimaryRS.Fields("Customer_Terms").Value
			mbAddNewFlag = False
			gID = id
			
			If 8 And frmMenu.gBit Then cBitA = True
			If 16 And frmMenu.gBit Then cBitF = True
			If cBitA = True And cBitF = True Then
                _txtFloat_13.Enabled = True
                _txtFloat_14.Enabled = True
                _txtFloat_15.Enabled = True
                _txtFloat_16.Enabled = True
                _txtFloat_17.Enabled = True
                _txtFloat_18.Enabled = True
			End If
			
		Else
			adoPrimaryRS = getRS("select * from Customer")
			adoPrimaryRS.AddNew()
			Me.Text = Me.Text & " [New record]"
			mbAddNewFlag = True
			cmbTerms.SelectedIndex = 0
			Me.cmbChannel.BoundText = CStr(0)
		End If
		'    If adoPrimaryRS.BOF Or adoPrimaryRS.EOF Then
		'    Else
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
            'txtFloat_Leave(txtFloat.Item((oText.Index)), New System.EventArgs())
        Next oText
		'Bind the check boxes to the data provider
        For Each oCheck In chkFields
            oCheck.DataBindings.Add(adoPrimaryRS)
        Next oCheck
		cmbTerms.DataSource = adoPrimaryRS
		buildDataControls()
		mbDataChanged = False
		If mbAddNewFlag = True Then
			For	Each oCheck In Me.chkFields
				oCheck.CheckState = System.Windows.Forms.CheckState.Unchecked
			Next oCheck
			cmbChannel.BoundText = "1"
		End If
		
		loadLanguage()
		ShowDialog()
		'    End If
	End Sub
	
    Private Sub cmbChannel_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles cmbChannel.KeyPress
        If mbEditFlag Or mbAddNewFlag Then Exit Sub
        If eventArgs.KeyChar = ChrW(27) Then
            eventArgs.KeyChar = ChrW(0)
            adoPrimaryRS.Move(0)
            cmdClose_Click(cmdClose, New System.EventArgs())
        End If
    End Sub

    Private Sub cmdStatement_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStatement.Click
        'On Error Resume Next
        If mbAddNewFlag Then
            MsgBox("There is no statement for a new customer.", MsgBoxStyle.Exclamation, "New Customer")
        Else
            report_CustomerStatement(adoPrimaryRS.Fields("CustomerID").Value)
        End If
    End Sub

    Private Sub frmCustomer_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtFields.AddRange(New TextBox() {_txtFields_0, _txtFields_2, _txtFields_3, _txtFields_4, _
                                         _txtFields_5, _txtFields_6, _txtFields_7, _txtFields_8, _
                                         _txtFields_9, _txtFields_10})
        txtFloat.AddRange(New TextBox() {_txtFloat_12, _txtFloat_13, _txtFloat_14, _txtFloat_15, _
                                        _txtFloat_16, _txtFloat_17, _txtFloat_18})
        chkFields.AddRange(New CheckBox() {_chkFields_11, _chkFields_19})
        Dim tb As New TextBox
        Dim cb As New CheckBox
        For Each tb In txtFields
            AddHandler tb.Enter, AddressOf txtFields_Enter
        Next
        For Each tb In txtFloat
            AddHandler tb.Enter, AddressOf txtFloat_Enter
            AddHandler tb.KeyPress, AddressOf txtFloat_KeyPress
            AddHandler tb.Leave, AddressOf txtFloat_Leave
        Next
    End Sub

    'UPGRADE_WARNING: Event frmCustomer.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub frmCustomer_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        Dim cmdLast As New Button
        Dim cmdNext As New Button
        Dim lblStatus As New Label
        On Error Resume Next
        lblStatus.Width = pixelToTwips(Me.Width, True) - 1500
        cmdNext.Left = lblStatus.Width + 700
        cmdLast.Left = cmdNext.Left + 340
    End Sub

    Private Sub frmCustomer_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If mbEditFlag Or mbAddNewFlag Then Exit Sub
        On Error Resume Next

        Select Case KeyCode
            Case System.Windows.Forms.Keys.Escape
                KeyCode = 0
                System.Windows.Forms.Application.DoEvents()
                adoPrimaryRS.Move(0)
                cmdClose_Click(cmdClose, New System.EventArgs())
        End Select
    End Sub

    Private Sub frmCustomer_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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
            For Each oText In Me.txtFloat
                If oText.Text = "" Then oText.Text = "0"
               oText.Text = oText.Text * 100
                'txtFloat_Leave(txtFloat.Item(oText.Index), New System.EventArgs())
                AddHandler oText.Leave, AddressOf txtFloat_Leave
            Next oText
            mbDataChanged = False

            Me.Close()
        End If
    End Sub

    'UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Function update_Renamed() As Boolean
        On Error GoTo UpdateErr
        update_Renamed = True
        If _txtFields_4.Text = "" Then
            MsgBox("A Customer First Name is required.", MsgBoxStyle.Information, "CUSTOMER DETAILS")
            _txtFields_4.Focus()
            update_Renamed = False
            Exit Function
        End If
        If _txtFields_5.Text = "" Then
            MsgBox("A Customer surname Name is required.", MsgBoxStyle.Information, "CUSTOMER DETAILS")
            _txtFields_5.Focus()
            update_Renamed = False
            Exit Function
        End If
        If _txtFields_2.Text = "" Then
            _txtFields_2.Text = _txtFields_4.Text & " " & _txtFields_5.Text
        End If
        adoPrimaryRS.Fields("Customer_Terms").Value = CInt(cmbTerms.SelectedIndex)
        If mbAddNewFlag Then
            '        adoPrimaryRS.UpdateBatch adAffectAll
            adoPrimaryRS.MoveLast() 'move to the new record
        Else
            adoPrimaryRS.Move(0)
        End If
        adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll)

        mbEditFlag = False
        mbAddNewFlag = False
        mbDataChanged = False

        Exit Function
UpdateErr:
        MsgBox(Err.Description)
        '    update = False
    End Function

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Dim rs As ADODB.Recordset
        Dim bCashless As Boolean

        If gID And txtFloat(13).Enabled = True Then
            rs = getRS("SELECT SUM(CustomerTransaction.CustomerTransaction_Amount) As sumTran, SUM(CustomerTransaction.CustomerTransaction_Allocated) As sumAlloc From CustomerTransaction WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" & gID & "));")
            If rs.RecordCount > 0 Then
                If System.Math.Round(IIf(IsDbNull(rs.Fields("sumTran").Value), 0, rs.Fields("sumTran").Value) - IIf(IsDbNull(rs.Fields("sumAlloc").Value), 0, rs.Fields("sumAlloc").Value), 2) <> System.Math.Round(CDec(txtFloat(13).Text) + CDec(txtFloat(14).Text) + CDec(txtFloat(15).Text) + CDec(txtFloat(16).Text) + CDec(txtFloat(17).Text) + CDec(txtFloat(18).Text), 2) Then
                    MsgBox("Aging does not match with total Balance! " & IIf(IsDbNull(rs.Fields("sumTran").Value), 0, rs.Fields("sumTran").Value) - IIf(IsDbNull(rs.Fields("sumAlloc").Value), 0, rs.Fields("sumAlloc").Value), MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
                    MyGotFocusNumeric(_txtFloat_13)
                    _txtFloat_13.Focus()
                    Exit Sub
                End If
            End If
        End If

        rs = getRS("Select Company_CashLess FROM Company;")
        If rs.RecordCount > 0 Then
            bCashless = rs.Fields("Company_CashLess").Value
        End If

        If bCashless = True Then
            If gID Then
                rs = getRS("Select Customer_InvoiceName FROM Customer WHERE Customer_InvoiceName = '" & _txtFields_2.Text & "' AND CustomerID <> " & gID & ";")
                If rs.RecordCount > 0 Then
                    MsgBox("Customer [ " & _txtFields_2.Text & " ] as an Invoice Name already exist.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
                    Exit Sub
                End If
            Else
                rs = getRS("Select Customer_InvoiceName FROM Customer WHERE Customer_InvoiceName = '" & _txtFields_2.Text & "'")
                If rs.RecordCount > 0 Then
                    MsgBox("Customer [ " & _txtFields_2.Text & " ] as an Invoice Name already exist.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
                    Exit Sub
                End If
            End If
        End If

        cmdClose.Focus()
        System.Windows.Forms.Application.DoEvents()
        '    update
        If update_Renamed() Then
            Me.Close()
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

    Private Sub txtFloat_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim txt As New TextBox
        txt = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txt, txtFloat)
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
        Dim txt As New TextBox
        txt = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txt, txtFloat)
        MyLostFocus(txtFloat(Index), 2)
    End Sub
End Class