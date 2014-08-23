Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmPriceList
	Inherits System.Windows.Forms.Form
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim mbChangedByCode As Boolean
    Dim mvBookMark As Integer
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
    Dim txtFields As New List(Of TextBox)
    Dim chkFields As New List(Of CheckBox)
	Dim gID As Integer
	
	Private Sub loadLanguage()
		
		'frmPriceList = No Code     [Edit Price List]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmPriceList.Caption = rsLang("LanguageLayoutLnk_Description"): frmPriceList.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1188 'Allocate|Checked
		If rsLang.RecordCount Then cmdAllocate.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdAllocate.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1085 'Print|Checked
		If rsLang.RecordCount Then cmdPrint.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrint.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1010 'General|Checked
		If rsLang.RecordCount Then _lbl_5.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_5.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1192 'Price List Name|Checked
        If rsLang.RecordCount Then _lblLabels_38.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_38.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1193 'COD Channel Name|Checked
		If rsLang.RecordCount Then _lblLabels_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1194 'Delivery Channel Name|Checked
		If rsLang.RecordCount Then chkChannel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : chkChannel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2463 'Disabled|Checked
		If rsLang.RecordCount Then _chkFields_12.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _chkFields_12.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmPriceList.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub buildDataControls()
		Dim rs As ADODB.Recordset
		rs = getRS("SELECT * FROM Channel ORDER BY ChannelID")
		cmbCOD.Items.Clear()
        cmbDelivery.Items.Clear()
        Dim x As Integer
		Do Until rs.EOF
            x = cmbCOD.Items.Add(New LBI(rs.Fields("Channel_Name").Value, rs.Fields("ChannelID").Value))
			If adoPrimaryRS.Fields("Pricelist_CODChannelID").Value = rs.Fields("ChannelID").Value Then 
                cmbCOD.SelectedIndex = x
			End If
            cmbDelivery.Items.Add(New LBI(rs.Fields("Channel_Name").Value, rs.Fields("ChannelID").Value))
			If adoPrimaryRS.Fields("Pricelist_DeliveryChannelID").Value = rs.Fields("ChannelID").Value Then 
				cmbDelivery.SelectedIndex = x
			End If
			rs.moveNext()
			
		Loop 
		
		
		'    doDataControl Me.cmbChannel, "SELECT ChannelID, Channel_Name FROM Channel ORDER BY ChannelID", "Customer_ChannelID", "ChannelID", "Channel_Name"
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
		Dim oText As System.Windows.Forms.TextBox
		Dim oCheck As System.Windows.Forms.CheckBox
		On Error Resume Next
		If id Then
			adoPrimaryRS = getRS("select * from Pricelist WHERE PricelistID = " & id)
		Else
			adoPrimaryRS = getRS("select * from Pricelist")
			adoPrimaryRS.AddNew()
			Me.Text = Me.Text & " [New record]"
			mbAddNewFlag = True
		End If
		setup()
        For Each oText In txtFields
            oText.DataBindings.Add(adoPrimaryRS)
            oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize
        Next oText
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
		If Me.cmbDelivery.SelectedIndex = -1 Then
			chkChannel.CheckState = System.Windows.Forms.CheckState.Unchecked
			cmbDelivery.Enabled = False
		Else
			chkChannel.CheckState = System.Windows.Forms.CheckState.Checked
			cmbDelivery.Enabled = True
		End If
		
		loadLanguage()
		ShowDialog()
	End Sub
	
	Private Sub setup()
	End Sub
	
	'UPGRADE_WARNING: Event chkChannel.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub chkChannel_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        cmbDelivery.Enabled = (chkChannel.CheckState)

    End Sub
	
    Private Sub cmdAllocate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If update_Renamed() Then
            frmPricelistItem.loadItem(adoPrimaryRS.Fields("PricelistID").Value)
        End If
    End Sub
	
    Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim rs As ADODB.Recordset
        Dim rsCompany As ADODB.Recordset
        Dim sql As String
        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
        update_Renamed()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rsCompany = getRS("SELECT * FROM Company")
        If Me.chkChannel.CheckState Then
            Report.Load("cryPriceList.rpt")

            sql = "SELECT Pricelist.Pricelist_Name, StockItem.StockItem_Name, Max(codCase.CatalogueChannelLnk_Price) AS codCase, Max(codCase.CatalogueChannelLnk_Quantity) AS codQuantity, codSingle.CatalogueChannelLnk_Price AS codSingle, Max(deliveryCase.CatalogueChannelLnk_Quantity) AS delQuantity, Max(deliveryCase.CatalogueChannelLnk_Price) AS delCase, deliverySingle.CatalogueChannelLnk_Price AS delSingle"
            sql = sql & " FROM ShrinkItem INNER JOIN"
            sql = sql & " (CatalogueChannelLnk AS deliverySingle INNER JOIN (CatalogueChannelLnk AS deliveryCase INNER JOIN ((CatalogueChannelLnk AS codCase INNER JOIN (StockItem INNER JOIN (PricelistStockItemLnk INNER JOIN Pricelist ON PricelistStockItemLnk.PricelistStockitemLnk_PricelistID = Pricelist.PricelistID) ON StockItem.StockItemID = PricelistStockItemLnk.PricelistStockitemLnk_StockitemID) ON (codCase.CatalogueChannelLnk_ChannelID = Pricelist.Pricelist_CODChannelID) AND (codCase.CatalogueChannelLnk_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk AS codSingle ON (StockItem.StockItemID = codSingle.CatalogueChannelLnk_StockItemID) AND (Pricelist.Pricelist_CODChannelID = codSingle.CatalogueChannelLnk_ChannelID)) ON (deliveryCase.CatalogueChannelLnk_StockItemID = StockItem.StockItemID) AND (deliveryCase.CatalogueChannelLnk_ChannelID = Pricelist.Pricelist_DeliveryChannelID)) ON (deliverySingle.CatalogueChannelLnk_ChannelID = Pricelist.Pricelist_DeliveryChannelID)"
            sql = sql & " AND (deliverySingle.CatalogueChannelLnk_StockItemID = StockItem.StockItemID)) ON (ShrinkItem.ShrinkItem_Quantity = codCase.CatalogueChannelLnk_Quantity) AND (ShrinkItem.ShrinkItem_Quantity = deliveryCase.CatalogueChannelLnk_Quantity) AND (ShrinkItem.ShrinkItem_ShrinkID = StockItem.StockItem_ShrinkID)"
            sql = sql & " Where (((codSingle.CatalogueChannelLnk_Quantity) = 1) And ((Pricelist.Pricelist_Disabled) = 0) And ((deliverySingle.CatalogueChannelLnk_Quantity) = 1))"
            sql = sql & " GROUP BY Pricelist.Pricelist_Name, StockItem.StockItem_Name, codSingle.CatalogueChannelLnk_Price, deliverySingle.CatalogueChannelLnk_Price"
            sql = sql & " ORDER BY Pricelist.Pricelist_Name, StockItem.StockItem_Name;"
        Else
            Report.Load("cryPriceListSingle.rpt")
            sql = "SELECT Pricelist.Pricelist_Name, StockItem.StockItem_Name, Max(codCase.CatalogueChannelLnk_Price) AS codCase, Max(codCase.CatalogueChannelLnk_Quantity) AS codQuantity, codSingle.CatalogueChannelLnk_Price AS codSingle, StockItem.StockItemID "
            sql = sql & "FROM ((CatalogueChannelLnk AS codCase INNER JOIN (StockItem INNER JOIN (PricelistStockItemLnk INNER JOIN Pricelist ON PricelistStockItemLnk.PricelistStockitemLnk_PricelistID = Pricelist.PricelistID) ON StockItem.StockItemID = PricelistStockItemLnk.PricelistStockitemLnk_StockitemID) ON (codCase.CatalogueChannelLnk_StockItemID = StockItem.StockItemID) AND (codCase.CatalogueChannelLnk_ChannelID = Pricelist.Pricelist_CODChannelID)) INNER JOIN CatalogueChannelLnk AS codSingle ON (Pricelist.Pricelist_CODChannelID = codSingle.CatalogueChannelLnk_ChannelID) AND (StockItem.StockItemID = codSingle.CatalogueChannelLnk_StockItemID)) INNER JOIN ShrinkItem ON (ShrinkItem.ShrinkItem_Quantity = codCase.CatalogueChannelLnk_Quantity) AND (StockItem.StockItem_ShrinkID = ShrinkItem.ShrinkItem_ShrinkID) "
            sql = sql & "Where (((codSingle.CatalogueChannelLnk_Quantity) = 1) And ((Pricelist.Pricelist_Disabled) = 0)) GROUP BY Pricelist.Pricelist_Name, StockItem.StockItem_Name, codSingle.CatalogueChannelLnk_Price, StockItem.StockItemID ORDER BY Pricelist.Pricelist_Name, StockItem.StockItem_Name;"
        End If


        rs = getRS(sql)
        If rs.BOF Or rs.EOF Then
            MsgBox("No Price allocated!", MsgBoxStyle.Exclamation, "PRICE LIST")
            Exit Sub
        End If

        If Me.chkChannel.CheckState Then
            Report.SetParameterValue("Text3", cmbCOD.Text)
            Report.SetParameterValue("Text4", cmbDelivery.Text)
        Else
            Report.SetParameterValue("Text3", cmbCOD.Text)
        End If

        Report.Database.Tables(1).SetDataSource(rs)
        Report.Database.Tables(2).SetDataSource(rsCompany)
        Report.SetParameterValue("txtCompanyName", rsCompany.Fields("Company_Name"))
       frmReportShow.Text = "Price List"
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()

    End Sub
	
	'UPGRADE_WARNING: Event frmPriceList.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub frmPriceList_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim cmdLast As New Button
        Dim cmdNext As New Button
        Dim lblStatus As New Label
        On Error Resume Next
        lblStatus.Width = pixelToTwips(Me.Width, True) - 1500
        cmdNext.Left = lblStatus.Width + 700
        cmdLast.Left = cmdNext.Left + 340
    End Sub
	
    Private Sub frmPriceList_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs)
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
	
    Private Sub frmPriceList_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs)
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
	
	
    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
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
        adoPrimaryRS.Fields("Pricelist_CODChannelID").Value = CInt(cmbCOD.SelectedIndex)
		If chkChannel.CheckState Then
            adoPrimaryRS.Fields("Pricelist_DeliveryChannelID").Value = CInt(cmbDelivery.SelectedIndex)
		Else
			adoPrimaryRS.Fields("Pricelist_DeliveryChannelID").Value = 0
		End If
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
	
    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        cmdClose.Focus()
        System.Windows.Forms.Application.DoEvents()
        If update_Renamed() Then
            Me.Close()
        End If
    End Sub
	
    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtFields.Enter
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txtBox, txtFields)
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

    Private Sub frmPriceList_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtFields.AddRange(New TextBox() {_txtFields_0})
        AddHandler _txtFields_0.Enter, AddressOf txtFields_Enter
        chkFields.AddRange(New CheckBox() {_chkFields_12})
    End Sub
End Class