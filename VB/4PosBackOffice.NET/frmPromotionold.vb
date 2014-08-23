Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmPromotion
	Inherits System.Windows.Forms.Form
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim mbChangedByCode As Boolean
    Dim mvBookMark As Integer
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
	Dim gID As Integer
	Dim p_Prom As Integer
	Dim p_Prom1 As Boolean

    Dim chkFields As New List(Of CheckBox)
    Dim txtFields As New List(Of TextBox)
    Dim DTFields As New List(Of DateTimePicker)

	Private Sub loadLanguage()
		
		'frmPromotion = No Code [Edit Promotion Details]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmPromotion.Caption = rsLang("LanguageLayoutLnk_Description"): frmPromotion.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1085 'Print|Checked
		If rsLang.RecordCount Then cmdPrint.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrint.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1010 'General|Checked
        If rsLang.RecordCount Then _lbl_5.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_5.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1139 'Promotion Name|Checked
        If rsLang.RecordCount Then _lblLabels_38.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_38.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1140 'Start Date|Checked
        If rsLang.RecordCount Then _lblLabels_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1141 'End Date|Checked
        If rsLang.RecordCount Then _lblLabels_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1142 'From Time|Checked
		If rsLang.RecordCount Then Label1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1143 'To Time|Checked
		If rsLang.RecordCount Then Label2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2463 'Disabled|Checked
        If rsLang.RecordCount Then _chkFields_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _chkFields_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1145 'Apply only to POS channel|Checked
        If rsLang.RecordCount Then _chkFields_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _chkFields_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1146 'Only for Specific Time|Checked
        If rsLang.RecordCount Then _chkFields_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _chkFields_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1147 'Add|Checked
		If rsLang.RecordCount Then cmdAdd.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdAdd.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1148 'Delete|Checked
		If rsLang.RecordCount Then cmddelete.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmddelete.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmPromotion.HelpContextID was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub buildDataControls()
		'    doDataControl Me.cmbChannel, "SELECT ChannelID, Channel_Name FROM Channel ORDER BY ChannelID", "Customer_ChannelID", "ChannelID", "Channel_Name"
	End Sub
	
    Private Sub doDataControl(ByRef dataControl As myDataGridView, ByRef sql As String, ByRef DataField As String, ByRef boundColumn As String, ByRef listField As String)
        'Dim rs As ADODB.Recordset
        'rs = getRS(sql)
        'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.RowSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
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
        Dim oDate As New DateTimePicker
		Dim oCheck As System.Windows.Forms.CheckBox
		
		On Error Resume Next
		If id Then
			p_Prom = id
			adoPrimaryRS = getRS("select Promotion.* from Promotion WHERE PromotionID = " & id)
		Else
			adoPrimaryRS = getRS("select * from Promotion")
			adoPrimaryRS.AddNew()
			Me.Text = Me.Text & " [New record]"
			mbAddNewFlag = True
		End If
		setup()
		For	Each oText In Me.txtFields
			oText.DataBindings.Add(adoPrimaryRS)
            oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize
		Next oText
		
		For	Each oDate In Me.DTFields
			oDate.DataBindings.Add(adoPrimaryRS)
		Next oDate
		
		'adoPrimaryRS("Promotion_SpeTime")
		'Bind the check boxes to the data provider
		For	Each oCheck In Me.chkFields
			oCheck.DataBindings.Add(adoPrimaryRS)
		Next oCheck
		buildDataControls()
		mbDataChanged = False
		loadItems()
		
		loadLanguage()
		ShowDialog()
	End Sub
	Private Sub setup()
	End Sub
	Private Sub cmdAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAdd.Click
		Dim lID As Integer
		Dim rs As ADODB.Recordset
		
		lID = frmStockList.getItem
		If lID <> 0 Then
			On Error Resume Next
			'cnnDB.Execute "INSERT INTO PromotionItem ( PromotionItem_PromotionID, PromotionItem_StockItemID, PromotionItem_Quantity, PromotionItem_Price ) SELECT " & adoPrimaryRS("PromotionID") & " AS [Set], CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, 1,CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)=" & lID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)=1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));"
			frmPromotionItem.loadItem(adoPrimaryRS.Fields("PromotionID").Value, lID)
			loadItems(lID)
		End If
	End Sub
	Private Sub cmdDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDelete.Click
		Dim lID As Integer
		If lvPromotion.FocusedItem Is Nothing Then
		Else
			If MsgBox("Are you sure you wish to remove " & lvPromotion.FocusedItem.Text & " from this Promotion?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "DELETE") = MsgBoxResult.Yes Then
				lID = CInt(Split(lvPromotion.FocusedItem.Name, "_")(0))
				cnnDB.Execute("DELETE PromotionItem.* From PromotionItem WHERE PromotionItem.PromotionItem_PromotionID=" & adoPrimaryRS.Fields("PromotionID").Value & " AND PromotionItem.PromotionItem_StockItemID=" & lID & " AND PromotionItem.PromotionItem_Quantity=" & Split(lvPromotion.FocusedItem.Name, "_")(1) & ";")
				loadItems()
			End If
		End If
		
	End Sub
	
	Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
		update_Renamed()
		report_Promotion()
	End Sub
	
	
	
	Private Sub frmPromotion_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        chkFields.AddRange(New CheckBox() {_chkFields_0, _chkFields_1, _chkFields_2})
        txtFields.AddRange(New TextBox() {_txtFields_0})
        DTFields.AddRange(New DateTimePicker() {_DTFields_0, _DTFields_1, _DTFields_2, _
                                                _DTFields_3})
        lvPromotion.Columns.Clear()
        lvPromotion.Columns.Add("", "Stock Item", CInt(twipsToPixels(4050, True)))
        lvPromotion.Columns.Add("QTY", CInt(twipsToPixels(800, True)), System.Windows.Forms.HorizontalAlignment.Right)
        lvPromotion.Columns.Add("Price", CInt(twipsToPixels(1440, True)), System.Windows.Forms.HorizontalAlignment.Right)
	End Sub
	
	Private Sub loadItems(Optional ByRef lID As Integer = 0, Optional ByRef quantity As Short = 0)
		Dim listItem As System.Windows.Forms.ListViewItem
		Dim rs As ADODB.Recordset
		lvPromotion.Items.Clear()
		rs = getRS("SELECT StockItem.StockItem_Name, PromotionItem.* FROM PromotionItem INNER JOIN StockItem ON PromotionItem.PromotionItem_StockItemID = StockItem.StockItemID Where (((PromotionItem.PromotionItem_PromotionID) = " & adoPrimaryRS.Fields("PromotionID").Value & ")) ORDER BY StockItem.StockItem_Name, PromotionItem.PromotionItem_Quantity;")
		Do Until rs.EOF
			listItem = lvPromotion.Items.Add(rs.Fields("PromotionItem_StockItemID").Value & "_" & rs.Fields("PromotionItem_Quantity").Value, rs.Fields("Stockitem_Name").Value, "")
			'UPGRADE_WARNING: Lower bound of collection listItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If listItem.SubItems.Count > 1 Then
				listItem.SubItems(1).Text = rs.Fields("PromotionItem_Quantity").Value
			Else
				listItem.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("PromotionItem_Quantity").Value))
			End If
			'UPGRADE_WARNING: Lower bound of collection listItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If listItem.SubItems.Count > 2 Then
				listItem.SubItems(2).Text = FormatNumber(rs.Fields("PromotionItem_Price").Value, 2)
			Else
				listItem.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("PromotionItem_Price").Value, 2)))
			End If
			If rs.Fields("PromotionItem_StockItemID").Value = lID And rs.Fields("PromotionItem_Quantity").Value = quantity Then listItem.Selected = True
			rs.moveNext()
		Loop 
	End Sub
	'UPGRADE_WARNING: Event frmPromotion.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmPromotion_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        Dim cmdLast As New Button
        Dim cmdnext As New Button
        Dim lblStatus As New Label
		On Error Resume Next
		 lblStatus.Width = pixelToTwips(Me.Width, True) - 1500
		cmdnext.Left = lblStatus.Width + 700
		cmdLast.Left = cmdnext.Left + 340
	End Sub
	
	Private Sub frmPromotion_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub frmPromotion_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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
		cmdClose.Focus()
		System.Windows.Forms.Application.DoEvents()
		If update_Renamed() Then
			If chkFields(1).CheckState = 0 Then
				cnnDB.Execute("UPDATE Promotion SET Promotion_StartDate = #" & DTFields(0).value & "#, Promotion_EndDate = #" & DTFields(1).value & "#, Promotion_StartTime = #" & DTFields(2).value & "# ,Promotion_EndTime =#" & DTFields(3).value & "# WHERE PromotionID = " & p_Prom & ";")
			End If
			Me.Close()
		End If
	End Sub
	Private Sub lvPromotion_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvPromotion.DoubleClick
		Dim lID As Integer
		Dim lQty As Short
		If lvPromotion.FocusedItem Is Nothing Then
		Else
			lID = CInt(Split(lvPromotion.FocusedItem.Name, "_")(0))
			lQty = CShort(Split(lvPromotion.FocusedItem.Name, "_")(1))
			
			frmPromotionItem.loadItem(adoPrimaryRS.Fields("PromotionID").Value, lID, CShort(lQty))
			loadItems(lID, lQty)
		End If
	End Sub
	
	Private Sub lvPromotion_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles lvPromotion.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Then
			lvPromotion_DoubleClick(lvPromotion, New System.EventArgs())
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _txtFields_0.Enter
        Dim Index As Integer
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Index = GetIndexer(txtBox, txtFields)
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
		'    MyGotFocusNumeric txtFloat(Index), 2
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