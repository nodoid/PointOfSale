Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmWH
	Inherits System.Windows.Forms.Form
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim mbChangedByCode As Boolean
	Dim mvBookMark As Integer
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
	Dim gID As Integer
	Dim k_posID As Integer
	Dim k_posNew As Boolean
	Dim bolLoad As Boolean
    Dim txtFields As New List(Of TextBox)
    Dim txtInteger As New List(Of TextBox)

	Private Sub loadLanguage()
		
		'frmWH = No Code            [Edit Warehouse Details]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmWH.Caption = rsLang("LanguageLayoutLnk_Description"): frmWH.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1010 'General|Checked
		If rsLang.RecordCount Then _lbl_5.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_5.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lblLabels_1 = No Code     [Warehouse Name]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblLabels_2 = No Code     [Warehouse Number]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmWH.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Sub loadItem(ByRef id As Integer)
		Dim oText As System.Windows.Forms.TextBox
		Dim oCheck As System.Windows.Forms.CheckBox
		On Error Resume Next
		
		If id Then
			k_posNew = False
			k_posID = id 'Get Warehouse ID...
			adoPrimaryRS = getRS("select * from Warehouse WHERE WarehouseID = " & id)
		Else
			k_posNew = True
			adoPrimaryRS = getRS("select * from Warehouse")
			adoPrimaryRS.AddNew()
			Me.Text = Me.Text & " [New record]"
			_txtInteger_0.Enabled = True
			mbAddNewFlag = True
		End If
		
		setup()
		For	Each oText In Me.txtFields
			oText.DataBindings.Add(adoPrimaryRS)
			oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize
		Next oText
		For	Each oText In Me.txtInteger
            oText.DataBindings.Add(adoPrimaryRS)
            AddHandler oText.Leave, AddressOf txtInteger_Leave
			'txtInteger_Leave(txtInteger.Item((oText.Index)), New System.EventArgs())
		Next oText
		
		bolLoad = True
		If id Then
			
		End If
		bolLoad = False
		
		mbDataChanged = False
		
		loadLanguage()
		ShowDialog()
	End Sub
	
	Private Sub setup()
    End Sub

    Private Sub frmWH_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtFields.AddRange(New TextBox() {_txtFields_1, _txtFields_10})
        txtInteger.AddRange(New TextBox() {_txtInteger_0})
        AddHandler _txtFields_1.Enter, AddressOf txtFields_Enter
        AddHandler _txtFields_10.Enter, AddressOf txtFields_Enter
    End Sub
	
	
	'UPGRADE_WARNING: Event frmWH.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmWH_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		On Error Resume Next
		'lblStatus.Width = Me.Width - 1500
		'cmdnext.Left = lblStatus.Width + 700
		'cmdLast.Left = cmdnext.Left + 340
	End Sub
	Private Sub frmWH_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.Escape
				KeyAscii = 0
				System.Windows.Forms.Application.DoEvents()
				'            adoPrimaryRS.Move 0
				cmdClose_Click(cmdClose, New System.EventArgs())
		End Select
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub frmWH_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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
			adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll)
			adoPrimaryRS.MoveLast() 'move to the new record
		End If
		
		mbEditFlag = False
		mbAddNewFlag = False
		mbDataChanged = False
		
		Exit Function
UpdateErr: 
		If Err.Number = CDbl("-2147217900") Then
			MsgBox("Warehouse Number [ " & Val(_txtInteger_0.Text) & " ] exist already, Chooose another number", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
			update_Renamed = False
			_txtInteger_0.Focus()
		Else
			MsgBox(Err.Number & Err.Description)
			update_Renamed = False
		End If
	End Function
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Dim rs As ADODB.Recordset
		Dim rj As ADODB.Recordset
		
		If k_posNew = True Then
			'-------------------------
			rs = getRS("Select * FROM Warehouse WHERE Warehouse_Name = '" & Trim(_txtFields_1.Text) & "'")
			If rs.RecordCount > 0 Then
				MsgBox("Warehouse Name [ " & _txtFields_1.Text & " ] exist already, Chooose another name", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
				Exit Sub
			End If
			
			rs = getRS("Select * FROM Warehouse WHERE WarehouseID = " & Val(_txtInteger_0.Text))
			If rs.RecordCount > 0 Then
				MsgBox("Warehouse Number [ " & Val(_txtInteger_0.Text) & " ] exist already, Chooose another number", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
				Exit Sub
			End If
			'-------------------------
		Else
			rs = getRS("Select * FROM Warehouse WHERE WarehouseID <> " & k_posID & " AND Warehouse_Name = '" & Trim(_txtFields_1.Text) & "'")
			If rs.RecordCount > 0 Then
				MsgBox("Warehouse Name [ " & _txtFields_1.Text & " ] exist already, Chooose another name", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
				Exit Sub
			End If
		End If
		
		If _txtFields_1.Text = "" Then
			MsgBox("Warehouse Name cannot be blank, enter Warehouse name", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
			Exit Sub
		End If
		If Val(_txtInteger_0.Text) < 2 Then
			MsgBox("Please enter another Warehouse Number other than 0 or 1", MsgBoxStyle.Information + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OKOnly, My.Application.Info.Title)
			Exit Sub
		End If
		
		
		cmdClose.Focus()
		System.Windows.Forms.Application.DoEvents()
		
		If update_Renamed() Then
			If k_posNew = True Then
				rs = getRS("SELECT Max(Warehouse.WarehouseID) AS id FROM Warehouse;")
				If rs.RecordCount > 0 Then
					'a = rs("id")
					cnnDB.Execute("INSERT INTO WarehouseStockItemLnk ( WarehouseStockItemLnk_WarehouseID, WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk_Quantity ) SELECT Warehouse.WarehouseID, StockItem.StockItemID, 0 FROM Warehouse, StockItem WHERE (((Warehouse.WarehouseID)=" & rs.Fields("id").Value & "));")
					cnnDB.Execute("INSERT INTO DayEndStockItemLnk ( DayEndStockItemLnk_DayEndID, DayEndStockItemLnk_StockItemID, DayEndStockItemLnk_Quantity, DayEndStockItemLnk_QuantitySales, DayEndStockItemLnk_QuantityShrink, DayEndStockItemLnk_QuantityGRV, DayEndStockItemLnk_ListCost, DayEndStockItemLnk_ActualCost, DayEndStockItemLnk_Warehouse ) SELECT Company.Company_DayEndID, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, 0 AS Expr1, 0 AS Expr2, 0 AS Expr3, 0 AS Expr4, DayEndStockItemLnk.DayEndStockItemLnk_ListCost, DayEndStockItemLnk.DayEndStockItemLnk_ActualCost, Warehouse.WarehouseID FROM Warehouse, Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID GROUP BY Company.Company_DayEndID, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, DayEndStockItemLnk.DayEndStockItemLnk_ListCost, DayEndStockItemLnk.DayEndStockItemLnk_ActualCost, Warehouse.WarehouseID HAVING (((Warehouse.WarehouseID)=" & rs.Fields("id").Value & "));")
				End If
			End If
			k_posNew = False
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
End Class