Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmDeposit
	Inherits System.Windows.Forms.Form
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim mbChangedByCode As Boolean
    Dim mvBookMark As Integer
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
	
	Dim gID As Integer
	
    Dim gVAT As Decimal

    Dim txtFields As New List(Of TextBox)
    Dim txtFloat As New List(Of TextBox)
    Dim txtHide As New List(Of TextBox)
    Dim txtInteger As New List(Of TextBox)
    Dim chkFields As New List(Of CheckBox)
	Private Sub loadLanguage()
		
		'NOTE: DB Entry 1083 has invalid text
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1083 'Edit Deposit Details
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1085 'Print|Checked
		If rsLang.RecordCount Then cmdPrint.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrint.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1010 'General|Checked
		If rsLang.RecordCount Then _lbl_5.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_5.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1009 'Display Name|Checked
        If rsLang.RecordCount Then _lblLabels_38.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_38.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1011 'Receipt Name|Checked
		If rsLang.RecordCount Then _lblLabels_3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1012 'POS Quick Key|Checked
		If rsLang.RecordCount Then _lblLabels_4.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_4.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lblLabels_2 = No Code     [VAT]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1091 'Number of Bottles in a Case|Checked
		If rsLang.RecordCount Then _lblLabels_5.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_5.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1092 'Disable this Deposit|Checked
		If rsLang.RecordCount Then _chkFields_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _chkFields_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1093 'Pricing|Checked
		If rsLang.RecordCount Then _lbl_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lblLabels_8 = No Code     [Bottles]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_8.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_8.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblLabels_9 = No Code     [Case]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_9.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_9.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'NOTE: DB Entry 1094 contains invalid text
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1094 'Inclusive Price|Check
		If rsLang.RecordCount Then _lblLabels_6.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_6.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1095 'Special Price|Check
		If rsLang.RecordCount Then _lblLabels_7.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_7.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmDeposit.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub buildDataControls()
		doDataControl((Me.cmbVat), "SELECT VatID, Vat_Name FROM Vat ORDER BY Vat_Name", "Deposit_VatID", "VatID", "Vat_Name")
	End Sub
	
    Private Sub doDataControl(ByRef dataControl As myDataGridView, ByRef sql As String, ByRef DataField As String, ByRef boundColumn As String, ByRef listField As String)
        Dim rs As ADODB.Recordset
        rs = getRS(sql)
        'dataControl.DataSource = rs
        dataControl.DataSource = adoPrimaryRS
        dataControl.DataField = DataField
        dataControl.boundColumn = boundColumn
        dataControl.listField = listField
    End Sub
	
	Public Sub loadItem(ByRef id As Integer)
		Dim oText As System.Windows.Forms.TextBox
		Dim oCheck As System.Windows.Forms.CheckBox
		On Error Resume Next
		If id Then
			gID = id
			adoPrimaryRS = getRS("select * from Deposit WHERE DepositID = " & id)
		Else
			gID = 0
			adoPrimaryRS = getRS("select * from Deposit")
			adoPrimaryRS.AddNew()
			Me.Text = Me.Text & " [New record]"
			
			mbAddNewFlag = True
		End If
		setup()
        For Each oText In txtFields
            oText.DataBindings.Add(adoPrimaryRS)
            oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize
        Next oText
        For Each oText In txtHide
            oText.DataBindings.Add(adoPrimaryRS)
        Next oText
        For Each oText In txtInteger
            oText.DataBindings.Add(adoPrimaryRS)
            AddHandler oText.Leave, AddressOf txtInteger_Leave
            'txtInteger_Leave(txtInteger.Item((oText.Index)), New System.EventArgs())
        Next oText
        For Each oText In txtFloat
            oText.DataBindings.Add(adoPrimaryRS)

            If oText.Text = "" Then oText.Text = "0"
            oText.Text = CStr(CDbl(oText.Text) * 100)
            AddHandler oText.Leave, AddressOf txtFloat_Leave
            'txtFloat_Leave(txtFloat.Item((oText.Index)), New System.EventArgs())
        Next oText
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
		'    Dim rs As Recordset
		'    Dim X As Integer
		'    Set rs = getRS("SELECT Channel_Code FROM Channel ORDER BY ChannelID")
		'    rs.MoveFirst
		'    For X = 0 To 7
		'        Me.lblCG(X).Caption = rs("Channel_Code")
		'        rs.moveNext
		'    Next
	End Sub
	
	Private Sub Command1_Click()
		
	End Sub
	
    Private Sub cmbVat_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As KeyEventArgs) Handles cmbVat.KeyDown
        If mbEditFlag Or mbAddNewFlag Then Exit Sub
        If eventArgs.KeyCode = 27 Then
            'eventArgs.KeyCode = 0
            adoPrimaryRS.Move(0)
            cmdClose_Click(cmdClose, New System.EventArgs())
        End If
    End Sub
	
	Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
		report_Deposits()
    End Sub

    Private Sub frmDeposit_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtFields.AddRange(New TextBox() {_txtFields_3, _txtFields_4, _txtFields_28})
        txtFloat.AddRange(New TextBox() {_txtFloat_0, _txtFloat_1, _txtFloat_2, _txtFloat_3})
        txtHide.AddRange(New TextBox() {_txtHide_0, _txtHide_1})
        txtInteger.AddRange(New TextBox() {_txtInteger_5})
        chkFields.AddRange(New CheckBox() {_chkFields_1})
        Dim tb As New TextBox
        Dim cb As New CheckBox
        For Each tb In txtFields
            AddHandler tb.Enter, AddressOf txtFields_Enter
            AddHandler tb.Leave, AddressOf txtFields_Leave
        Next
        For Each tb In txtFloat
            AddHandler tb.Enter, AddressOf txtFloat_Enter
            AddHandler tb.KeyPress, AddressOf txtFloat_KeyPress
        Next
        For Each tb In txtInteger
            AddHandler tb.Enter, AddressOf txtInteger_Enter
            AddHandler tb.KeyPress, AddressOf txtInteger_KeyPress
        Next
    End Sub
	
	Private Sub frmDeposit_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        Dim cmdLast As New Button
        Dim cmdNext As New Button
        Dim lblStatus As New Label
		On Error Resume Next
        lblStatus.Width = pixelToTwips(Me.Width, True) - 1500
		cmdNext.Left = lblStatus.Width + 700
		cmdLast.Left = cmdNext.Left + 340
	End Sub
	
	Private Sub frmDeposit_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.Escape
				KeyAscii = 0
				cmdClose.Focus()
				System.Windows.Forms.Application.DoEvents()
				adoPrimaryRS.Move(0)
				cmdClose_Click(cmdClose, New System.EventArgs())
		End Select
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub frmDeposit_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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
            For Each oText In txtInteger
                AddHandler oText.Leave, AddressOf txtInteger_Leave
                'txtInteger_Leave(txtInteger.Item(oText.Index), New System.EventArgs())
            Next oText
            For Each oText In txtFloat
                If oText.Text = "" Then oText.Text = "0"
                oText.Text = oText.Text * 100
                AddHandler oText.Leave, AddressOf txtFloat_Leave
                'txtFloat_Leave(txtFloat.Item(oText.Index), New System.EventArgs())
            Next oText
			mbDataChanged = False
		End If
	End Sub
	
	Private Function update_Renamed() As Boolean
		On Error GoTo UpdateErr
		update_Renamed = True
		Dim rs As ADODB.Recordset
		Dim sql As String
		rs = getRS("SELECT * FROM Vat WHERE VatID = " & cmbVat.BoundText)
		If rs.BOF Or rs.EOF Then
			gVAT = 0
		Else
			gVAT = rs.Fields("Vat_Amount").Value
		End If
		txtHide(0).Text = CStr(CDbl(_txtFloat_0.Text) / (1 + gVAT / 100))
		txtHide(1).Text = CStr(CDbl(_txtFloat_1.Text) / (1 + gVAT / 100))
		System.Windows.Forms.Application.DoEvents()
		If mbAddNewFlag Then
			adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll)
			adoPrimaryRS.MoveLast() 'move to the new record
		Else
			If adoPrimaryRS.Fields("Deposit_UnitPrice1").Value <> adoPrimaryRS.Fields("Deposit_UnitPrice1").OriginalValue Or adoPrimaryRS.Fields("Deposit_CasePrice1").Value <> adoPrimaryRS.Fields("Deposit_CasePrice1").OriginalValue Then
				cnnDB.Execute("INSERT INTO tempStockItem ( tempStockItemID ) SELECT StockItem.StockItemID FROM StockItem LEFT JOIN tempStockItem ON StockItem.StockItemID = tempStockItem.tempStockItemID WHERE (((tempStockItem.tempStockItemID) Is Null) AND ((StockItem.StockItem_DepositID)=" & adoPrimaryRS.Fields("DepositID").Value & "));")
			End If
			adoPrimaryRS.Move(0)
			adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll)
			
		End If
		cnnDB.Execute("INSERT INTO WarehouseDepositItemLnk ( WarehouseDepositItemLnk_WarehouseID, WarehouseDepositItemLnk_DepositID, WarehouseDepositItemLnk_DepositTypeID, WarehouseDepositItemLnk_Quantity ) SELECT DISPLAY_Deposits.WarehouseID, DISPLAY_Deposits.DepositID, DISPLAY_Deposits.type, 0 AS quantity FROM WarehouseDepositItemLnk RIGHT JOIN DISPLAY_Deposits ON (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID = DISPLAY_Deposits.type) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID = DISPLAY_Deposits.WarehouseID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = DISPLAY_Deposits.DepositID) WHERE (((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID) Is Null));")
		sql = "INSERT INTO DayEndDepositItemLnk ( DayEndDepositItemLnk_DayEndID, DayEndDeposittemLnk_DepositID, DayEndDeposittemLnk_DepositType, DayEndDepositItemLnk_Quantity, DayEndDepositItemLnk_QuantitySales, DayEndDepositItemLnk_QuantityShrink, DayEndDepositItemLnk_UnitCost, DayEndDepositItemLnk_CaseCost, DayEndDepositItemLnk_CaseQuantity ) SELECT DISPLAY_DepositDayEnd.Company_DayEndID, DISPLAY_DepositDayEnd.DepositID, DISPLAY_DepositDayEnd.type, 0 AS Expr1, 0 AS Expr2, 0 AS Expr3, Deposit.Deposit_UnitCost, Deposit.Deposit_CaseCost, Deposit.Deposit_Quantity FROM DayEndDepositItemLnk RIGHT JOIN (Deposit INNER JOIN DISPLAY_DepositDayEnd ON Deposit.DepositID = DISPLAY_DepositDayEnd.DepositID) ON (DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType = DISPLAY_DepositDayEnd.type) AND (DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = DISPLAY_DepositDayEnd.DepositID) AND (DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID = DISPLAY_DepositDayEnd.Company_DayEndID) "
		sql = sql & "WHERE (((DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) Is Null));"
		cnnDB.Execute(sql)
		
		
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
		
		If txtFields(28).Text = "" Or _txtFields_3.Text = "" Then
			MsgBox("Deposit display name/receipt name cannot be empty", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Deposits")
			Exit Sub
		End If
		
		If Val(txtInteger(5).Text) = 0 Then
			MsgBox("Number of Bottles In a case cannot be zero", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Deposits")
			Exit Sub
		End If
		
		If VB.Left(LCase(txtFields(28).Text), 3) <> "non" Then
			If _txtFields_4.Text = "" Then
				MsgBox("Deposit 'POS Quick Key' cannot be empty", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Deposits")
				Exit Sub
			End If
			
			'        If _txtFloat_0.Text = 0 Then
			'           MsgBox "Bottle 'Inclusive Price' cannot be empty", vbApplicationModal + vbInformation + vbOKOnly, "Deposits"
			'           Exit Sub
			'        End If
			'
			'        If _txtFloat_1.Text = 0 Then
			'           MsgBox "Bottle 'Inclusive Price' cannot be empty", vbApplicationModal + vbInformation + vbOKOnly, "Deposits"
			'           Exit Sub
			'        End If
		End If
		
		If gID = 0 Then
			rs = getRS("Select * FROM Deposit WHERE Deposit_Name = '" & Trim(txtFields(28).Text) & "'")
			If rs.RecordCount > 0 Then
				MsgBox("Deposit Name [ " & Trim(txtFields(28).Text) & " ] exist already, Chooose another Deposit Name", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
				Exit Sub
			End If
			
			rs = getRS("Select * FROM Deposit WHERE ((Deposit.Deposit_Disabled) <> True) AND Deposit_Key = '" & Trim(_txtFields_4.Text) & "'")
			If rs.RecordCount > 0 Then
				MsgBox("POS Quick Key [ " & Trim(_txtFields_4.Text) & " ] exist already, Chooose another POS Quick Key", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
				Exit Sub
			End If
			
		Else
			rs = getRS("Select * FROM Deposit WHERE ((Deposit.Deposit_Disabled) <> True) AND DepositID <> " & gID & " AND Deposit_Name = '" & Trim(txtFields(28).Text) & "'")
			If rs.RecordCount > 0 Then
				MsgBox("Deposit Name [ " & Trim(txtFields(28).Text) & " ] exist already, Chooose another Deposit Name", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
				Exit Sub
			End If
			
			rs = getRS("Select * FROM Deposit WHERE ((Deposit.Deposit_Disabled) <> True) AND DepositID <> " & gID & " AND Deposit_Key = '" & Trim(_txtFields_4.Text) & "'")
			If rs.RecordCount > 0 Then
				MsgBox("POS Quick Key [ " & Trim(_txtFields_4.Text) & " ] exist already, Chooose another POS Quick Key", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
				Exit Sub
			End If
			
			If _chkFields_1.CheckState Then
				rs = getRS("Select * FROM [Set] WHERE Set_DepositID = " & gID & " AND Set_Disabled=False")
				If rs.RecordCount > 0 Then
					MsgBox("This Deposit is being used in Stock Set(s). Please 'Disable' this Stock Set(s) first in order to disable the Deposit.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
					Exit Sub
				End If
				
				rs = getRS("Select * FROM StockItem WHERE StockItem_DepositID = " & gID & " AND StockItem_Disabled=False;")
				If rs.RecordCount > 0 Then
					MsgBox("This Deposit is being used in Stock Item(s). Please 'Disable' those Stock Item(s) first in order to disable this Deposit.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
					Exit Sub
				End If
			End If
			
		End If
		
		If update_Renamed() Then
			Me.Close()
		End If
		
	End Sub
	
    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtFields.Enter
        Dim Index As Integer
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Index = GetIndexer(txtBox, txtFields)
        MyGotFocus(txtFields(Index))
    End Sub
	
    Private Sub txtFields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) ' Handles txtFields.Leave
        Dim txt As TextBox
        txt = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txt, txtFields)
        '*Code that put the Display Name text in the Receipt Name Textbox when Display Name Loses Focus
        If _txtFields_3.Text = "" Then
            _txtFields_3.Text = _txtFields_28.Text
        End If
    End Sub
	
    Private Sub txtInteger_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtInteger.Enter
        Dim Index As Integer
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Index = GetIndexer(txtBox, txtInteger)
        MyGotFocusNumeric(txtInteger(Index))
    End Sub
	
    Private Sub txtInteger_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) 'Handles txtInteger.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'Dim Index As Short = txtInteger.GetIndex(eventSender)
        MyKeyPress(KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub txtInteger_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) ' Handles txtInteger.Leave
        Dim Index As Integer
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Index = GetIndexer(txtBox, txtInteger)
        MyLostFocus(txtInteger(Index), 0)
    End Sub
	
    Private Sub txtFloat_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtFloat.Enter
        Dim Index As Integer
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Index = GetIndexer(txtBox, txtFloat)
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
        Dim Index As Integer
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Index = GetIndexer(txtBox, txtFloat)
        MyLostFocus(txtFloat(Index), 2)
    End Sub
End Class