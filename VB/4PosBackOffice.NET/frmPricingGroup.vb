Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmPricingGroup
	Inherits System.Windows.Forms.Form
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim mbChangedByCode As Boolean
	Dim mvBookMark As Integer
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
	Dim pRid As Short
	Dim gID As Integer
    'Dim WithEvents lblLabels As New List(Of Label)
    Dim txtFields As New List(Of TextBox)
    Dim txtFloat As New List(Of TextBox)
    Dim txtInteger As New List(Of TextBox)
    Dim txtFloatNegative As New List(Of TextBox)
    Dim lblCG As New List(Of Label)

	Private Sub loadLanguage()
		
		'frmPricingGroup = No Code  [Edit Pricing Group Details]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmPricingGroup.Caption = rsLang("LanguageLayoutLnk_Description"): frmPricingGroup.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'cmdMatrix = No Code        [Pricing Matrix]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdMatrix.Caption = rsLang("LanguageLayoutLnk_Description"): cmdMatrix.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'DB Entry needs "&" for accelerator key
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1085 'Print|Checked
		If rsLang.RecordCount Then cmdPrint.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrint.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1010 'General|Checked
		If rsLang.RecordCount Then _lbl_5.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_5.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1066 'Pricing Group Name|Checked
        If rsLang.RecordCount Then _lblLabels_38.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_38.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1067 'Pricing Rules|Checked
		If rsLang.RecordCount Then _lbl_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lbl(10) = No Code          [When a Stock Item value is over]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lbl(10).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(10).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lbl(18) = No Code          [round all amounts below]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lbl(18).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(18).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'========================================================================================
		'NOTE: For multi-currency support the word "RAND" must be removed from the labels below!!
		'Recommend generating the sentence from two DB entries, and use a fixed variable to
		'stores the currency of choice inserted in the middle before applying it to the component.
		'
		'   E.g.    firstPart       = rsLang.filter = & 1234;
		'           lastPart        = rsLang.Filter = & 1235;
		'           _lbl_3.Caption  = firstPart + ' ' + currency + ' ' + lastPart;
		'========================================================================================
		
		'_lbl_3 = No Code           [cents to the lower <Rand> value]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_3.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_2 = No Code           [value, then remove]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'NOTE: Same problem as _lbl_3 applies here!!!
		'_lbl_4 = No Code           [cents from the rounded stock item <Rand> value]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_4.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1068 'Default Pricing Markup Percentage|Checked
		If rsLang.RecordCount Then _lbl_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lblLabels(34) = No Code (Closest match 2105, but grammar wrong for use)
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblLabels(34).Caption = rsLang("LanguageLayoutLnk_Description"): lblLabels(34).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblLabels(33) = No Code    [Case/Carton]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblLabels(33).Caption = rsLang("LanguageLayoutLnk_Description"): lblLabels(33).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblCG(0) = Dynamic
		'lblCG(1) = Dynamic
		'lblCG(2) = Dynamic
		'lblCG(3) = Dynamic
		'lblCG(4) = Dynamic
		'lblCG(5) = Dynamic
		'lblCG(6) = Dynamic
		'lblCG(7) = Dynamic
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1069 'Disabled Pricing Group|Checked
		If rsLang.RecordCount Then Label1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1070 'Disable this Pricing Group|Checked
		If rsLang.RecordCount Then chkPricing.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : chkPricing.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmPricingGroup.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub buildDataControls()
		'    doDataControl Me.cmbChannel, "SELECT ChannelID, Channel_Name FROM Channel ORDER BY ChannelID", "Customer_ChannelID", "ChannelID", "Channel_Name"
	End Sub
	
    Private Sub doDataControl(ByRef dataControl As myDataGridView, ByRef sql As String, ByRef DataField As String, ByRef boundColumn As String, ByRef listField As String)
        'Dim rs As ADODB.Recordset
        'rs = getRS(sql)
        'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'dataControl.DataBindings.Add(rs)
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
		Dim oText As System.Windows.Forms.TextBox
		Dim oCheck As System.Windows.Forms.CheckBox
		On Error Resume Next
		If id Then
			pRid = id
			adoPrimaryRS = getRS("select PricingGroupID,PricingGroup_Name,PricingGroup_RemoveCents,PricingGroup_RoundAfter,PricingGroup_RoundDown,PricingGroup_Unit1,PricingGroup_Case1,PricingGroup_Unit2,PricingGroup_Case2,PricingGroup_Unit3,PricingGroup_Case3,PricingGroup_Unit4,PricingGroup_Case4,PricingGroup_Unit5,PricingGroup_Case5,PricingGroup_Unit6,PricingGroup_Case6,PricingGroup_Unit7,PricingGroup_Case7,PricingGroup_Unit8,PricingGroup_Case8,PricingGroup_Disabled from PricingGroup WHERE PricingGroupID = " & id)
		Else
			adoPrimaryRS = getRS("select * from PricingGroup")
			adoPrimaryRS.AddNew()
			Me.Text = Me.Text & " [New record]"
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
		Next oText
		For	Each oText In Me.txtFloat
			oText.DataBindings.Add(adoPrimaryRS)
			If oText.Text = "" Then oText.Text = "0"
            oText.Text = CStr(CDbl(oText.Text) * 100)
            AddHandler oText.Leave, AddressOf txtFloat_Leave
		Next oText
		For	Each oText In Me.txtFloatNegative
			 oText.DataBindings.Add(adoPrimaryRS)
			If oText.Text = "" Then oText.Text = "0"
            oText.Text = CStr(CDbl(oText.Text) * 100)
            AddHandler oText.Leave, AddressOf txtFloatNegative_Leave
		Next oText
		
		If CShort(adoPrimaryRS.Fields("PricingGroup_Disabled").Value) Then
			Me.chkPricing.CheckState = System.Windows.Forms.CheckState.Checked
			Me.chkPricing.Tag = 1
		Else
			Me.chkPricing.Tag = 0
		End If
		
		buildDataControls()
		mbDataChanged = False
		
		loadLanguage()
		ShowDialog()
	End Sub
	
	Private Sub setup()
		Dim rs As ADODB.Recordset
		Dim x As Short
		rs = getRS("SELECT Channel_Code FROM Channel ORDER BY ChannelID")
		rs.MoveFirst()
		For x = 0 To 7
			Me.lblCG(x).Text = rs.Fields("Channel_Code").Value
			rs.moveNext()
		Next 
	End Sub
	
	Private Sub Command1_Click()
		
	End Sub
	
	Private Sub cmdMatrix_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMatrix.Click
		cmdMatrix.Focus()
		System.Windows.Forms.Application.DoEvents()
		update_Renamed()
		Cursor = System.Windows.Forms.Cursors.WaitCursor
		frmPricingMatrix.loadMatrix(adoPrimaryRS.Fields("PricingGroupID").Value)
        Cursor = System.Windows.Forms.Cursors.Default
        Dim form As frmPricingMatrix
        form.Show()
	End Sub
	
	Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
		report_PricingGroup()
    End Sub

    Private Sub frmPricingGroup_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtFields.AddRange(New TextBox() {_txtFields_28})
        txtFloat.AddRange(New TextBox() {_txtFloat_1})
        txtInteger.AddRange(New TextBox() {_txtInteger_0, _txtInteger_2})
        txtFloatNegative.AddRange(New TextBox() {_txtFloatNegative_0, _txtFloatNegative_1, _
                                                 _txtFloatNegative_2, _txtFloatNegative_3, _
                                                 _txtFloatNegative_4, _txtFloatNegative_5, _
                                                 _txtFloatNegative_6, _txtFloatNegative_7, _
                                                 _txtFloatNegative_8, _txtFloatNegative_9, _
                                                 _txtFloatNegative_10, _txtFloatNegative_11, _
                                                 _txtFloatNegative_12, _txtFloatNegative_13, _
                                                 _txtFloatNegative_14, _txtFloatNegative_15})
        lblCG.AddRange(New Label() {_lblCG_0, _lblCG_1, _lblCG_2, _lblCG_3, _lblCG_4, _
                                    _lblCG_5, _lblCG_6, _lblCG_7})
        AddHandler _txtFields_28.Enter, AddressOf txtFields_Enter
        AddHandler _txtFloat_1.Enter, AddressOf txtFloat_Enter
        AddHandler _txtFloat_1.KeyPress, AddressOf txtFloat_KeyPress

        Dim tb As New TextBox
        For Each tb In txtInteger
            AddHandler tb.Enter, AddressOf txtInteger_Enter
            AddHandler tb.KeyPress, AddressOf txtInteger_KeyPress
        Next
        For Each tb In txtFloatNegative
            AddHandler tb.Enter, AddressOf txtFloatNegative_Enter
            AddHandler tb.KeyPress, AddressOf txtFloatNegative_KeyPress
        Next

    End Sub

	
	'UPGRADE_WARNING: Event frmPricingGroup.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmPricingGroup_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        Dim cmdLast As Button
        Dim cmdnext As Button
        Dim lblStatus As Label
		On Error Resume Next
		'UPGRADE_WARNING: Couldn't resolve default property of object lblStatus.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        lblStatus.Width = pixelToTwips(Me.Width, True) - 1500
		'UPGRADE_WARNING: Couldn't resolve default property of object cmdnext.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object lblStatus.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		cmdnext.Left = lblStatus.Width + 700
		'UPGRADE_WARNING: Couldn't resolve default property of object cmdLast.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object cmdnext.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		cmdLast.Left = cmdnext.Left + 340
	End Sub
	Private Sub frmPricingGroup_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub frmPricingGroup_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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
        Dim oText As New TextBox
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
			For	Each oText In Me.txtInteger
				'UPGRADE_WARNING: Couldn't resolve default property of object oText.Index. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'txtInteger_Leave(txtInteger.Item(oText.Index), New System.EventArgs())
			Next oText
			For	Each oText In Me.txtFloat
				'UPGRADE_WARNING: Couldn't resolve default property of object oText.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If oText.Text = "" Then oText.Text = "0"
				'UPGRADE_WARNING: Couldn't resolve default property of object oText.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				oText.Text = oText.Text * 100
				'UPGRADE_WARNING: Couldn't resolve default property of object oText.Index. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'txtFloat_Leave(txtFloat.Item(oText.Index), New System.EventArgs())
			Next oText
			For	Each oText In Me.txtFloatNegative
				'UPGRADE_WARNING: Couldn't resolve default property of object oText.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If oText.Text = "" Then oText.Text = "0"
				'UPGRADE_WARNING: Couldn't resolve default property of object oText.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				oText.Text = oText.Text * 100
				'UPGRADE_WARNING: Couldn't resolve default property of object oText.Index. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'txtFloatNegative_Leave(txtFloatNegative.Item(oText.Index), New System.EventArgs())
			Next oText
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
			For x = 1 To 8
				If adoPrimaryRS.Fields("PricingGroup_Unit" & x).Value <> adoPrimaryRS.Fields("PricingGroup_Unit" & x).OriginalValue Then lDirty = True
				If adoPrimaryRS.Fields("PricingGroup_Case" & x).Value <> adoPrimaryRS.Fields("PricingGroup_Case" & x).OriginalValue Then lDirty = True
			Next x
			If adoPrimaryRS.Fields("PricingGroup_RemoveCents").Value <> adoPrimaryRS.Fields("PricingGroup_RemoveCents").OriginalValue Then lDirty = True
			If adoPrimaryRS.Fields("PricingGroup_RoundAfter").Value <> adoPrimaryRS.Fields("PricingGroup_RoundAfter").OriginalValue Then lDirty = True
			If adoPrimaryRS.Fields("PricingGroup_RoundDown").Value <> adoPrimaryRS.Fields("PricingGroup_RoundDown").OriginalValue Then lDirty = True
			If lDirty Then
				cnnDB.Execute("INSERT INTO tempStockItem ( tempStockItemID ) SELECT StockItem.StockItemID FROM StockItem LEFT JOIN tempStockItem ON StockItem.StockItemID = tempStockItem.tempStockItemID WHERE (((StockItem.StockItem_PricingGroupID)=" & adoPrimaryRS.Fields("PricingGroupID").Value & ") AND ((tempStockItem.tempStockItemID) Is Null));")
			End If
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
		
		If CDbl(Me.chkPricing.Tag) <> Me.chkPricing.CheckState Then
			cnnDB.Execute("UPDATE PricingGroup SET PricingGroup_Disabled = " & Val(CStr(Me.chkPricing.CheckState)) & " WHERE PricingGroupID = " & pRid)
		End If
		If update_Renamed() Then
			Me.Close()
		End If
	End Sub
	
    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Integer
        Dim txBox As New TextBox
        txBox = DirectCast(eventSender, TextBox)
        Index = GetIndexer(txBox, txtFields)
        MyGotFocus(txtFields(Index))
    End Sub
	
    Private Sub txtInteger_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Integer
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Index = GetIndexer(txtBox, txtInteger)
        MyGotFocusNumeric(txtInteger(Index))
    End Sub
	
    Private Sub txtInteger_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'Dim Index As Short = txtInteger.GetIndex(eventSender)
        MyKeyPress(KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub txtInteger_Leave(ByVal eventSender As System.Object, ByVal eventArgs As EventArgs)
        Dim Index As Integer
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Index = GetIndexer(txtBox, txtInteger)
        MyLostFocus(txtInteger(Index), 0)
    End Sub
	
    Private Sub txtFloat_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Integer
        Dim textBox As New TextBox
        textBox = DirectCast(eventSender, TextBox)
        Index = GetIndexer(textBox, txtFloat)
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
        Dim Index As Integer
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Index = GetIndexer(txtBox, txtFloat)
        MyLostFocus(txtFloat(Index), 2)
    End Sub
	
    Private Sub txtFloatNegative_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Integer
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Index = GetIndexer(txtBox, txtFloatNegative)
        MyGotFocusNumeric(txtFloatNegative(Index))
    End Sub
	
    Private Sub txtFloatNegative_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Integer
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Index = GetIndexer(txtBox, txtFloatNegative)
        MyKeyPressNegative(txtFloatNegative(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub txtFloatNegative_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Integer
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Index = GetIndexer(txtBox, txtFloatNegative)
        MyLostFocus(txtFloatNegative(Index), 2)
    End Sub
End Class