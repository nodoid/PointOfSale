Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmPriceSet
	Inherits System.Windows.Forms.Form
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim mbChangedByCode As Boolean
    Dim mvBookMark As Integer
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
	Dim gID As Integer
    Dim txtFields As New List(Of TextBox)
    Dim chkFields As New List(Of CheckBox)
	Private Sub loadLanguage()
		
		'DB Line Entry Faulty!!! Contains wrong/invalid words!!!
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1124 'Edit Pricing Set Details|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1126 'Print all|Checked
		If rsLang.RecordCount Then cmdPrintAll.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrintAll.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1085 'Print|Checked
		If rsLang.RecordCount Then cmdPrint.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrint.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1010 'General|Checked
		If rsLang.RecordCount Then _lbl_5.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_5.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1130 'Price Set Name|Checked
		If rsLang.RecordCount Then _lblLabels_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1108 'Disable this Set|Checked
		If rsLang.RecordCount Then _chkFields_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _chkFields_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1131 'Primary Stock Item|Checked
		If rsLang.RecordCount Then _lblLabels_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lblStockItem = No Code/Dynamic!
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1704 'Edit|Checked
		If rsLang.RecordCount Then cmdEdit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdEdit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmPriceSet.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub buildDataControls()
		'doDataControl Me.cmbDeposit, "SELECT DepositID, Deposit_Name FROM Deposit ORDER BY Deposit_Name", "Set_DepositID", "DepositID", "Deposit_Name"
	End Sub
	Private Sub doDataControl(ByRef dataControl As System.Windows.Forms.Control, ByRef sql As String, ByRef DataField As String, ByRef boundColumn As String, ByRef listField As String)
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
        Dim rs As ADODB.Recordset
        Dim lID As Integer
		Dim oText As System.Windows.Forms.TextBox
		Dim oCheck As System.Windows.Forms.CheckBox
		On Error Resume Next
		If id Then
			adoPrimaryRS = getRS("SELECT PriceSet.PriceSetID, PriceSet.PriceSet_Name, PriceSet.PriceSet_StockItemID, PriceSet.PriceSet_Disabled From PriceSet WHERE (((PriceSet.PriceSetID)=" & id & "));")
		Else
			adoPrimaryRS = getRS("select * from [PriceSet]")
			adoPrimaryRS.AddNew()
			Me.Text = Me.Text & "[New Record]"
			mbAddNewFlag = True
		End If
		setup()
		
        For Each oText In txtFields
            oText.DataBindings.Add(adoPrimaryRS)
            oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize
        Next oText
		
		'Bind the check boxes to the data provider
        For Each oCheck In chkFields
            lID = adoPrimaryRS.Fields("PriceSet_StockItemID").Value
            If lID <> 0 Then
                rs = getRS("SELECT StockItem.StockItem_Name FROM StockItem WHERE (StockItemID = " & lID & ")")
                If rs.BOF Or rs.EOF Then
                    Me.lblStockItem.Text = "No Stock Item Selected ..."
                    Me.lblStockItem.Tag = 0
                Else
                    Me.lblStockItem.Text = rs("StockItem_Name")
                    Me.lblStockItem.Tag = lID
                End If

            End If
            oCheck.DataBindings.Add(adoPrimaryRS)
        Next oCheck
		If _chkFields_0.CheckState = 2 Then _chkFields_0.CheckState = System.Windows.Forms.CheckState.Unchecked
		buildDataControls()
		mbDataChanged = False
		setup()
		
		loadLanguage()
		ShowDialog()
	End Sub
	
	Private Sub setup()
	End Sub
	
	Private Sub cmbDeposit_KeyDown(ByRef KeyCode As Short, ByRef Shift As Short)
		If mbEditFlag Or mbAddNewFlag Then Exit Sub
		If KeyCode = 27 Then
			KeyCode = 0
			adoPrimaryRS.Move(0)
			cmdClose_Click(cmdClose, New System.EventArgs())
		End If
		
	End Sub
    Private Sub cmdEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEdit.Click
        '* Disable the Pricing Set button when frmpricesetlist is open
        frmStockItem.cmdpriceselist.Enabled = False

        '*Code that refuses you access to frmstockitem before you add the new primary stockitem
        If Me.lblStockItem.Tag = "" Then
            MsgBox("Please Select the Primary Stock Item", MsgBoxStyle.Information)
            Exit Sub
        End If
        '*
        If CBool(Me.lblStockItem.Tag) Then
            frmStockItem.loadItem(CInt(Me.lblStockItem.Tag))
            Dim form As frmStockItem
            form.Show()

        End If

    End Sub
	
    Private Sub cmdEmulate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEmulate.Click
        Dim lID As Integer
        Dim rs As ADODB.Recordset

        'lID = frmStockList.getItem
        lID = frmStockList2.getItem
        If lID <> 0 Then
            rs = getRS("SELECT StockItem.StockItem_Name FROM StockItem WHERE (StockItemID = " & lID & ")")
            If rs.BOF Or rs.EOF Then
                MsgBox("Stock Item Not Found!", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            Else
                Me.lblStockItem.Text = rs.Fields("StockItem_Name").Value
                Me.lblStockItem.Tag = lID
            End If

        End If

    End Sub
	
    Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
        cmdPrint.Focus()

        System.Windows.Forms.Application.DoEvents()
        update_Renamed()
        report_SelectPriceSets()
    End Sub
	
    Private Sub cmdPrintAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrintAll.Click
        cmdPrintAll.Focus()
        System.Windows.Forms.Application.DoEvents()
        update_Renamed()
        report_PriceSets()
    End Sub
	
    Private Sub frmPriceSet_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
	
	 Private Sub frmPriceSet_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim cmdLast As New Button
        Dim cmdnext As New Button
        Dim lblStatus As Label
        On Error Resume Next
        lblStatus.Width = pixelToTwips(Me.Width, True) - 1500
        cmdnext.Left = lblStatus.Width + 700
        cmdLast.Left = cmdnext.Left + 340
    End Sub
    Private Sub frmPriceSet_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        txtholdvalue.Text = _txtFields_0.Text
        Holdvalue = txtholdvalue.Text

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
		update_Renamed = True
		adoPrimaryRS.Fields("PriceSet_StockItemID").Value = Me.lblStockItem.Tag
		adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll)
		'   adoPrimaryRS.save
		If mbAddNewFlag Then
			adoPrimaryRS.MoveLast() 'move to the new record
		Else
			adoPrimaryRS.Move(0)
		End If
		If IsDbNull(adoPrimaryRS.Fields("PriceSet_StockItemID").Value) Then
		Else
			cnnDB.Execute("UPDATE StockItem SET StockItem.StockItem_PriceSetID = " & adoPrimaryRS.Fields("PriceSetID").Value & " WHERE (((StockItem.StockItemID)=" & adoPrimaryRS.Fields("PriceSet_StockItemID").Value & "));")
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
	
	Public Sub CheckFields()
		'*Disable the emulate and edit buttons when Price Set Name = Nothing
		'frmPriceSet._txtFields_0.Text = Hcheck
		If Trim(Me._txtFields_0.Text) = "" Then
			Me.cmdEmulate.Enabled = False
			Me.cmdEdit.Enabled = False
		ElseIf Trim(Me._txtFields_0.Text) <> "" Then 
			Me.cmdEmulate.Enabled = True
			Me.cmdEdit.Enabled = True
		End If
		'*
	End Sub
	
	'UPGRADE_WARNING: Event txtFields.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub txtFields_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _txtFields_0.TextChanged
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txtBox, txtFields)
        Call CheckFields()
    End Sub
	
    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _txtFields_0.Enter
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txtBox, txtFields)
        MyGotFocus(txtFields(Index))
        Call CheckFields()
    End Sub

    Private Sub frmPriceSet_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtFields.AddRange(New TextBox() {_txtFields_0})
        chkFields.AddRange(New CheckBox() {_chkFields_0})
    End Sub
End Class