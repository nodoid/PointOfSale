Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmSet
	Inherits System.Windows.Forms.Form
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim mbChangedByCode As Boolean
	Dim mvBookMark As Integer
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
	
	Dim gID As Integer
    Dim isNewRec As Integer

    Dim txtFields As New List(Of TextBox)
    Dim txtFloat As New List(Of TextBox)
    Dim txtInteger As New List(Of TextBox)
    Dim chkFields As New List(Of CheckBox)
    Dim lblCG As New List(Of Label)
	
	Private Sub loadLanguage()
		
		'frmSet = No Code   [Edit Stock Set Details]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmSet.Caption = rsLang("LanguageLayoutLnk_Description"): frmSet.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1100 'Emulate Pricing|Checked
		If rsLang.RecordCount Then cmdEmulate.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdEmulate.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1101 'Allocate Stock Items|Checked
		If rsLang.RecordCount Then cmdAllocate.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdAllocate.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1085 'Print|Checked
		If rsLang.RecordCount Then cmdPrint.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrint.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1010 'General|Checked
		If rsLang.RecordCount Then _lbl_5.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_5.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1105 'Set Name|Checked
		If rsLang.RecordCount Then _lblLabels_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1013 'Deposit|Checked
		If rsLang.RecordCount Then _lblLabels_11.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_11.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1107 'Number of Units in the Set|Checked
		If rsLang.RecordCount Then _lblLabels_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1108 'Disable this Set|Checked
		If rsLang.RecordCount Then _chkFields_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _chkFields_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1109 'Pricing Per Sale Channel|Checked
		If rsLang.RecordCount Then _lbl_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1110 'This Stock Set is locked to the following Stock Item|Checked
		If rsLang.RecordCount Then chkStockItem.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : chkStockItem.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lblStockitem = No Code/Dynamic!
		'lblCG(0) = Dynamic
		'lblCG(1) = Dynamic
		'lblCG(2) = Dynamic
		'lblCG(3) = Dynamic
		'lblCG(4) = Dynamic
		'lblCG(5) = Dynamic
		'lblCG(6) = Dynamic
		'lblCG(7) = Dynamic
		'lblCG(8) = Dynamic
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmSet.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub buildDataControls()
		Dim rs As ADODB.Recordset
		'doDataControl Me.cmbDeposit, "SELECT DepositID, Deposit_Name FROM Deposit WHERE ((LEFT((Deposit.Deposit_Name),3)<>'Non')) ORDER BY Deposit_Name", "Set_DepositID", "DepositID", "Deposit_Name"
		doDataControl((Me.cmbDeposit), "SELECT DepositID, Deposit_Name FROM Deposit WHERE ((Deposit.Deposit_Disabled) <> True) ORDER BY Deposit_Name", "Set_DepositID", "DepositID", "Deposit_Name")
		If adoPrimaryRS.Fields("Set_StockitemID").Value > 0 Then
			chkStockItem.Tag = adoPrimaryRS.Fields("Set_StockitemID").Value
			chkStockItem.CheckState = System.Windows.Forms.CheckState.Checked
			chkStockItem.Tag = ""
			'        Set rs = getRS("SELECT * FROM StockItem WHERE StockItemID=" & adoPrimaryRS("Set_StockitemID"))
			'        If rs.RecordCount Then
			'            lblStockItem.Caption = rs("StockItem_Name")
			'        End If
			
		End If
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
        Dim oText As New TextBox
        Dim oCheck As New CheckBox
		On Error Resume Next
		
		isNewRec = id
		If id Then
			adoPrimaryRS = getRS("select * from [Set] WHERE SetID = " & id)
		Else
			adoPrimaryRS = getRS("select * from [Set]")
			adoPrimaryRS.AddNew()
			Me.Text = Me.Text & " [New record]"
			mbAddNewFlag = True
		End If
		setup()
        For Each oText In txtFields
            oText.DataBindings.Add(adoPrimaryRS)
            oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize
        Next oText
        For Each oText In txtInteger
            oText.DataBindings.Add(adoPrimaryRS)
            AddHandler oText.Leave, AddressOf txtInteger_Leave
        Next oText
        For Each oText In txtFloat
            oText.DataBindings.Add(adoPrimaryRS)
            If oText.Text = "" Then oText.Text = "0"
            oText.Text = CStr(CDbl(oText.Text) * 100)
            AddHandler oText.Leave, AddressOf txtFloat_Leave
        Next oText
        '    For Each oText In Me.txtFloatNegative
        '        Set oText.DataBindings.Add(adoPrimaryRS)
		'        If oText.Text = "" Then oText.Text = "0"
		'        oText.Text = oText.Text * 100
		'        txtFloatNegative_LostFocus oText.Index
		'    Next
		'Bind the check boxes to the data provider
		For	Each oCheck In Me.chkFields
			oCheck.DataBindings.Add(adoPrimaryRS)
		Next oCheck
		buildDataControls()
		mbDataChanged = False
		setup()
		
		loadLanguage()
		ShowDialog()
	End Sub
	
	Private Sub setup()
		Dim rs As ADODB.Recordset
		Dim x As Short
		rs = getRS("SELECT Channel_Code FROM Channel ORDER BY ChannelID")
		rs.MoveFirst()
		For x = 0 To 7
			Me.lblCG(x).Text = rs.Fields("Channel_Code").Value & ":"
			rs.moveNext()
		Next 
		
	End Sub
	
	Private Sub chkStockItem_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkStockItem.CheckStateChanged
		Dim lID As Integer
		Dim rs As ADODB.Recordset
		If chkStockItem.CheckState Then
			For lID = 0 To 7
				Me.txtFloat(lID).Enabled = False
				Me.txtFloat(lID).Text = "0.00"
			Next 
			If chkStockItem.Tag <> "" Then
				lID = CInt(chkStockItem.Tag)
			Else
				lID = frmStockList.getItem
			End If
			If lID = 0 Then
				chkStockItem.CheckState = System.Windows.Forms.CheckState.Unchecked
			Else
				Me._txtFields_1.Text = CStr(lID)
				rs = getRS("SELECT * FROM StockItem WHERE StockItemID=" & lID)
				If rs.RecordCount Then
					lblStockItem.Text = rs.Fields("StockItem_Name").Value
					rs.Close()
					rs = getRS("SELECT StockItem.StockItem_DepositID, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM CatalogueChannelLnk INNER JOIN StockItem ON CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = StockItem.StockItemID WHERE (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = " & lID & ") AND (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = " & Me._txtInteger_0.Text & ") AND CatalogueChannelLnk.CatalogueChannelLnk_ChannelID <> 9")
					Do Until rs.EOF
						txtFloat(rs.Fields("CatalogueChannelLnk_ChannelID").Value - 1).Text = CStr(rs.Fields("CatalogueChannelLnk_Price").Value * 100)
						txtFloat_Leave(txtFloat.Item(rs.Fields("CatalogueChannelLnk_ChannelID").Value - 1), New System.EventArgs())
						rs.moveNext()
					Loop 
				End If
				
			End If
			
		Else
			Me._txtFields_1.Text = CStr(0)
			lblStockItem.Text = "[No Stock Item ...]"
			Me._txtFloat_0.Enabled = True
			Me._txtFloat_1.Enabled = True
			Me._txtFloat_2.Enabled = True
			Me.txtFloat(3).Enabled = True
			Me.txtFloat(4).Enabled = True
			Me.txtFloat(5).Enabled = True
			Me.txtFloat(6).Enabled = True
			Me.txtFloat(7).Enabled = True
		End If
	End Sub
	
    Private Sub cmbDeposit_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As KeyEventArgs) Handles cmbDeposit.KeyDown
        If mbEditFlag Or mbAddNewFlag Then Exit Sub
        If eventArgs.KeyCode = 27 Then
            'eventArgs.KeyChar = ChrW(0)
            adoPrimaryRS.Move(0)
            cmdClose_Click(cmdClose, New System.EventArgs())
        End If

    End Sub

    Private Sub cmdAllocate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAllocate.Click
        If IsDbNull(adoPrimaryRS.Fields("SetID").Value) Then
            If update_Renamed() Then
            Else
                Exit Sub
            End If
        End If

        frmSetItem.loadItem(adoPrimaryRS.Fields("SetID").Value)
    End Sub

    Private Sub cmdEmulate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEmulate.Click
        Dim lID As Integer
        Dim rs As ADODB.Recordset
        If _txtInteger_0.Text = "0" Then
            MsgBox("Insert the Set quantity first", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            _txtInteger_0.Focus()
            Exit Sub
        End If

        lID = frmStockList.getItem
        If lID <> 0 Then
            rs = getRS("SELECT StockItem.StockItem_DepositID, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM CatalogueChannelLnk INNER JOIN StockItem ON CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = StockItem.StockItemID WHERE (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = " & lID & ") AND (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = " & Me._txtInteger_0.Text & ") AND CatalogueChannelLnk.CatalogueChannelLnk_ChannelID <> 9")
            If rs.BOF Or rs.EOF Then
                MsgBox("Set quantity no found!", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            Else
                Do Until rs.EOF
                    txtFloat(rs.Fields("CatalogueChannelLnk_ChannelID").Value - 1).Text = CStr(rs.Fields("CatalogueChannelLnk_Price").Value * 100)
                    txtFloat_Leave(txtFloat.Item(rs.Fields("CatalogueChannelLnk_ChannelID").Value - 1), New System.EventArgs())

                    rs.moveNext()
                Loop
            End If

        End If

    End Sub


    Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
        report_Sets()
    End Sub

    Private Sub frmSet_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub frmSet_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        Dim cmdLast As New Button
        Dim cmdNext As New Button
        Dim lblStatus As New Label
        On Error Resume Next
        lblStatus.Width = pixelToTwips(Me.Width, True) - 1500
        cmdNext.Left = lblStatus.Width + 700
        cmdLast.Left = cmdNext.Left + 340
    End Sub



    Private Sub frmSet_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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

            For Each oText In Me.txtInteger
                AddHandler oText.Leave, AddressOf txtInteger_Leave
           Next oText
            For Each oText In Me.txtFloat
                If oText.Text = "" Then oText.Text = "0"
                oText.Text = oText.Text * 100
                AddHandler oText.Leave, AddressOf txtFloat_Leave
            Next oText
            mbDataChanged = False
        End If
    End Sub

    Private Function update_Renamed() As Boolean
        On Error GoTo UpdateErr
        update_Renamed = True
        adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll)
        '    adoPrimaryRS.save
        If mbAddNewFlag Then
            adoPrimaryRS.MoveLast() 'move to the new record
        Else
            adoPrimaryRS.Move(0)
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
        cmdClose.Focus()
        System.Windows.Forms.Application.DoEvents()

        If cmbDeposit.BoundText = "" Then
            MsgBox("Please choose deposit!!", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
            cmbDeposit.Focus()
            Exit Sub
        End If

        If isNewRec Then
            rs = getRS("Select * FROM [Set] WHERE Set_DepositID = " & cmbDeposit.BoundText & " AND SetID <> " & isNewRec & ";")
            If rs.RecordCount > 0 Then
                MsgBox("Deposit already being used, Please choose different deposit!!", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
                cmbDeposit.Focus()
                Exit Sub
            End If
        Else
            'New set being added
            'if new add validation
            rs = getRS("Select * FROM [Set] WHERE Set_DepositID = " & cmbDeposit.BoundText & ";")
            If rs.RecordCount > 0 Then
                MsgBox("Deposit already being used, Please choose different deposit!!", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
                cmbDeposit.Focus()
                Exit Sub
            End If
            'exit sub
        End If

        If update_Renamed() Then
            Me.Close()
        End If
    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtFields.Enter
        Dim txt As New TextBox
        txt = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txt, txtFields)
        MyGotFocus(txtFields(Index))
    End Sub

    Private Sub txtInteger_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _txtInteger_0.Enter
        Dim txt As New TextBox
        txt = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txt, txtInteger)
        MyGotFocusNumeric(txtInteger(Index))
    End Sub

    Private Sub txtInteger_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles _txtInteger_0.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'Dim Index As Short = txtInteger.GetIndex(eventSender)
        MyKeyPress(KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtInteger_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _txtInteger_0.Leave
        Dim txt As New TextBox
        txt = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txt, txtInteger)
        MyLostFocus(txtInteger(Index), 0)
    End Sub

    Private Sub txtFloat_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtFloat.Enter
        Dim txt As New TextBox
        txt = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txt, txtFloat)
        MyGotFocusNumeric(txtFloat(Index))
    End Sub

    Private Sub txtFloat_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) 'Handles txtFloat.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'Dim Index As Short = txtFloat.GetIndex(eventSender)
        MyKeyPress(KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtFloat_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtFloat.Leave
        Dim txt As New TextBox
        txt = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txt, txtFloat)
        MyLostFocus(txtFloat(Index), 2)
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

    Private Sub frmSet_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        chkFields.AddRange(New CheckBox() {_chkFields_2})
        txtFields.AddRange(New TextBox() {_txtFields_0, _txtFields_1})
        txtFloat.AddRange(New TextBox() {_txtFloat_0, _txtFloat_1, _txtFloat_2, _txtFloat_3, _
                                         _txtFloat_4, _txtFloat_5, _txtFloat_6, _txtFloat_7})
        lblCG.AddRange(New Label() {_lblCG_0, _lblCG_1, _lblCG_2, _lblCG_3, _lblCG_4, _lblCG_5, _
                                   _lblCG_6, _lblCG_7})
        Dim tb As New TextBox
        For Each tb In txtFields
            AddHandler tb.Enter, AddressOf txtFields_Enter
        Next
        For Each tb In txtFloat
            AddHandler tb.Enter, AddressOf txtFloat_Enter
            AddHandler tb.KeyPress, AddressOf txtFloat_KeyPress
        Next
    End Sub
End Class