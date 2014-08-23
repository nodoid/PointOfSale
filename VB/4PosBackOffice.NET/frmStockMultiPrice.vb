Option Strict Off
Option Explicit On
Friend Class frmStockMultiPrice
	Inherits System.Windows.Forms.Form
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim mbChangedByCode As Boolean
    Dim mvBookMark As Boolean
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
	
	Dim gFilter As String
	Dim gFilterSQL As String
    Dim WithEvents myfmt As StdFormat.StdDataFormat
	
	Private Sub loadLanguage()
		
		'frmStockMultiPrice = No Code   [Edit Stock Item Micro Pricing]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmStockMultiPrice.Caption = rsLang("LanguageLayoutLnk_Description"): frmStockMultiPrice.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblHeading = No Code           [Using the "Stock Item Selector"...]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblHeading.Caption = rsLang("LanguageLayoutLnk_Description"): lblHeading.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
        '_lbl_0 = No Label              [For which Sale Channel]
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
        '_lbl_1 = No Label              [And for what Quantity]
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1006 'Filter|Checked
		If rsLang.RecordCount Then cmdFilter.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdFilter.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1085 'Print|Checked
		If rsLang.RecordCount Then cmdPrint.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrint.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
        'UPGRADE_ISSUE: Form property frmStockMultiPrice.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
    Private Sub myfmt_UnFormat(ByVal DataValue As StdFormat.StdDataValue) Handles myfmt.UnFormat
        With DataValue
            If IsNumeric(.value) Then
                If InStr(.value, ".") Then
                    .value = FormatNumber(.value, 2)
                Else
                    .value = FormatNumber(.value / 100, 2)
                End If
            End If
        End With
    End Sub
	
	Private Sub adoPrimaryRS_FieldChangeComplete(ByVal cFields As Integer, ByVal Fields As Object, ByVal pError As ADODB.Error, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.FieldChangeComplete
		Dim sql As String
		sql = "DELETE From PriceChannelLnk WHERE (((PriceChannelLnk.PriceChannelLnk_StockItemID)=" & adoPrimaryRS.Fields("CatalogueChannelLnk_StockItemID").Value & ") AND ((PriceChannelLnk.PriceChannelLnk_Quantity)=" & adoPrimaryRS.Fields("CatalogueChannelLnk_Quantity").Value & ") AND ((PriceChannelLnk.PriceChannelLnk_ChannelID)=" & adoPrimaryRS.Fields("CatalogueChannelLnk_ChannelID").Value & "));"
		cnnDB.Execute(sql)
		
		
		sql = "INSERT INTO PriceChannelLnk ( PriceChannelLnk_StockItemID, PriceChannelLnk_Quantity, PriceChannelLnk_ChannelID, PriceChannelLnk_Price ) SELECT CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, " & pRecordset.Fields("CatalogueChannelLnk_Price").Value & " AS Price From CatalogueChannelLnk WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)=" & pRecordset.Fields("CatalogueChannelLnk_StockItemID").Value & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)=" & pRecordset.Fields("CatalogueChannelLnk_Quantity").Value & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=" & pRecordset.Fields("CatalogueChannelLnk_ChannelID").Value & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_PriceSystem)<>" & pRecordset.Fields("CatalogueChannelLnk_Price").Value & "));"
		
		cnnDB.Execute(sql)
	End Sub
	
    Private Sub cmbChannel_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles cmbChannel.Change
        getNamespace()
    End Sub
	
    Private Sub cmbShrink_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As ColumnClickEventArgs) Handles cmbShrink.Click
        getNamespace()
    End Sub
	
	Private Sub cmdFilter_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFilter.Click
		frmFilter.loadFilter(gFilter)
		getNamespace()
	End Sub
	
	Private Sub getNamespace()
		If cmbShrink.BoundText = "" Or cmbChannel.BoundText = "" Then Exit Sub
		Dim lString As String
		lString = " CatalogueChannelLnk.CatalogueChannelLnk_Quantity=" & Me.cmbShrink.BoundText & " AND CatalogueChannelLnk.CatalogueChannelLnk_ChannelID=" & Me.cmbChannel.BoundText & " AND StockItem.StockItem_Disabled=0 AND StockItem.StockItem_Discontinued=0 "
		If gFilter = "" Then
			Me.lblHeading.Text = ""
		Else
			frmFilter.buildCriteria(gFilter)
			Me.lblHeading.Text = frmFilter.gHeading
		End If
		gFilterSQL = frmFilter.gCriteria
		If gFilterSQL = "" Then
			lString = " WHERE " & lString
		Else
			lString = gFilterSQL & " AND " & lString
		End If
		'    If gFilterSQL = "" Then
		'        lString = " WHERE StockItem.StockItem_Disabled=0 AND StockItem.StockItem_Discontinued=0 "
		'    Else
		'        lString = gFilterSQL & " AND StockItem.StockItem_Disabled=0 AND StockItem.StockItem_Discontinued=0 "
		'    End If
		
		adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID FROM (Catalogue INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID) INNER JOIN CatalogueChannelLnk ON (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) " & lString & " ORDER BY StockItem.StockItem_Name;")
		
		'Display the list of Titles in the DataCombo
		grdDataGrid.DataSource = adoPrimaryRS
        grdDataGrid.Columns(0).HeaderText = "Stock Name"
        grdDataGrid.Columns(0).DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft
        grdDataGrid.Columns(0).Frozen = True

        grdDataGrid.Columns(1).HeaderText = "Price"
        grdDataGrid.Columns(1).DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgRight
        grdDataGrid.Columns(1).Width = twipsToPixels(900, True)
        grdDataGrid.Columns(1).DefaultCellStyle.Format = CType(myfmt, StdFormat.StdDataFormat)
        'grdDataGrid.Columns(1).NumberFormat = "#,##0.00"
		
		grdDataGrid.Columns(2).Visible = False
		grdDataGrid.Columns(3).Visible = False
		grdDataGrid.Columns(4).Visible = False
		
		frmStockMultiPrice_Resize(Me, New System.EventArgs())
		mbDataChanged = False
		
	End Sub
	
	
	
	Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
		Dim rs As ADODB.Recordset
		Dim sql As String
        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryStockItemPrice.rpt")
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
		rs.Close()
        Report.SetParameterValue("txtFilter", lblHeading.Text)
        Report.SetParameterValue("txtTitle1", "Where Sales Channel = " & cmbChannel.CtlText)
		
        'Report.Database.SetDataSource(adoPrimaryRS, 3)
        Report.Database.Tables(1).SetDataSource(adoPrimaryRS)
		'Report.VerifyOnEveryPrint = True
		frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
		frmReportShow.CRViewer1.ReportSource = Report
		frmReportShow.mReport = Report : frmReportShow.sMode = "0"
		frmReportShow.CRViewer1.Refresh()
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		frmReportShow.ShowDialog()
	End Sub
	
	Private Sub buildDataControls()
		doDataControl((Me.cmbChannel), "SELECT ChannelID, Channel_Name FROM Channel WHERE ChannelID <> 9 ORDER BY ChannelID", "ChannelID", "Channel_Name")
		doDataControl((Me.cmbShrink), "SELECT DISTINCT ShrinkItem.ShrinkItem_Quantity From ShrinkItem ORDER BY ShrinkItem.ShrinkItem_Quantity;", "ShrinkItem_Quantity", "ShrinkItem_Quantity")
		cmbChannel.BoundText = CStr(1)
		cmbShrink.BoundText = CStr(1)
	End Sub
	
    Private Sub doDataControl(ByRef dataControl As myDataGridView, ByRef sql As String, ByRef boundColumn As String, ByRef listField As String)
        Dim rs As ADODB.Recordset
        rs = getRS(sql)
        'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        dataControl.DataSource = rs
        'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.boundColumn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        dataControl.boundColumn = boundColumn
        'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.listField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        dataControl.listField = listField
    End Sub
	
	Private Sub frmStockMultiPrice_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		myfmt = New StdFormat.StdDataFormat
		myfmt.Type = StdFormat.FormatType.fmtCustom
		buildDataControls()
		gFilter = "stockitem"
		getNamespace()
		mbDataChanged = False
		
		loadLanguage()
	End Sub
	
	Public Sub changePrice(ByRef mainID As Integer)
		myfmt = New StdFormat.StdDataFormat
		myfmt.Type = StdFormat.FormatType.fmtCustom
		buildDataControls()
		gFilter = "stockitem"
		
		mbDataChanged = False
		
		cmbChannel.BoundText = CStr(6)
		cmbChannel.Enabled = False
		cmdFilter.Enabled = False
		cmbShrink.Enabled = False
		
		getNamespaceCP(mainID)
		
		loadLanguage()
		ShowDialog()
	End Sub
	
	'UPGRADE_NOTE: mID was upgraded to mID_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub getNamespaceCP(ByRef mID_Renamed As Integer)
		Dim sql As Object
		If cmbShrink.BoundText = "" Or cmbChannel.BoundText = "" Then Exit Sub
		Dim lString As String
		lString = " CatalogueChannelLnk.CatalogueChannelLnk_Quantity=" & Me.cmbShrink.BoundText & " AND CatalogueChannelLnk.CatalogueChannelLnk_ChannelID=" & Me.cmbChannel.BoundText & " AND StockItem.StockItem_Disabled=0 AND StockItem.StockItem_Discontinued=0 "
		If gFilter = "" Then
			Me.lblHeading.Text = ""
		Else
			frmFilter.buildCriteria(gFilter)
			Me.lblHeading.Text = frmFilter.gHeading
		End If
		gFilterSQL = frmFilter.gCriteria
		If gFilterSQL = "" Then
			lString = " WHERE " & lString
		Else
			lString = gFilterSQL & " AND " & lString
		End If
		'    If gFilterSQL = "" Then
		'        lString = " WHERE StockItem.StockItem_Disabled=0 AND StockItem.StockItem_Discontinued=0 "
		'    Else
		'        lString = gFilterSQL & " AND StockItem.StockItem_Disabled=0 AND StockItem.StockItem_Discontinued=0 "
		'    End If
		'UPGRADE_WARNING: Couldn't resolve default property of object sql. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		sql = "SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID FROM (Catalogue INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID) INNER JOIN CatalogueChannelLnk ON (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) " & lString & " ORDER BY StockItem.StockItem_Name;"
		Debug.Print(sql)
		'UPGRADE_WARNING: Couldn't resolve default property of object sql. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		sql = "SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID FROM RecipeStockitemLnk INNER JOIN ((Catalogue INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID) INNER JOIN CatalogueChannelLnk ON Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) ON RecipeStockitemLnk.RecipeStockitemLnk_StockitemID = StockItem.StockItemID Where (((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 6) And ((RecipeStockitemLnk.RecipeStockitemLnk_RecipeID) = " & mID_Renamed & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;"
		adoPrimaryRS = getRS(sql)
		
		'Display the list of Titles in the DataCombo
		grdDataGrid.DataSource = adoPrimaryRS
        grdDataGrid.Columns(0).HeaderText = "Stock Name"
        grdDataGrid.Columns(0).DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft
        grdDataGrid.Columns(0).Frozen = True
		
        grdDataGrid.Columns(1).HeaderText = "Price"
        grdDataGrid.Columns(1).DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgRight
        grdDataGrid.Columns(1).Width = twipsToPixels(900, True)
        grdDataGrid.Columns(1).DefaultCellStyle.Format = myfmt
        'grdDataGrid.Columns(1).NumberFormat = "#,##0.00"
		
		grdDataGrid.Columns(2).Visible = False
		grdDataGrid.Columns(3).Visible = False
		grdDataGrid.Columns(4).Visible = False
		
		frmStockMultiPrice_Resize(Me, New System.EventArgs())
		mbDataChanged = False
		
	End Sub
	
	Private Sub frmStockMultiPrice_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 27 Then
			KeyAscii = 0
			cmdClose_Click(cmdClose, New System.EventArgs())
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'UPGRADE_WARNING: Event frmStockMultiPrice.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmStockMultiPrice_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		On Error Resume Next
		'This will resize the grid when the form is resized
		System.Windows.Forms.Application.DoEvents()
        grdDataGrid.Height = twipsToPixels(pixelToTwips(Me.ClientRectangle.Height, False) - 30 - _
                                          pixelToTwips(picButtons.Height, False), False)
        grdDataGrid.Columns(0).Width = twipsToPixels(pixelToTwips(grdDataGrid.Width, True) - 900 - _
                                                    580, True)
		
	End Sub
	
	Private Sub frmStockMultiPrice_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
	End Sub
	
	Private Sub adoPrimaryRS_MoveComplete(ByVal adReason As ADODB.EventReasonEnum, ByVal pError As ADODB.Error, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.MoveComplete
		'This will display the current record position for this recordset
	End Sub
	
	Private Sub adoPrimaryRS_WillChangeRecord(ByVal adReason As ADODB.EventReasonEnum, ByVal cRecords As Integer, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.WillChangeRecord
		'This is where you put validation code
		'This event gets called when the following actions occur

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
		
		'bCancel = True
		'  adStatus = adStatusCantDeny
	End Sub
	
	Private Sub cmdCancel_Click()
		On Error Resume Next
		
		mbEditFlag = False
		mbAddNewFlag = False
		adoPrimaryRS.CancelUpdate()
		If mvBookMark > 0 Then
			'UPGRADE_WARNING: Couldn't resolve default property of object mvBookMark. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			adoPrimaryRS.Bookmark = mvBookMark
		Else
			adoPrimaryRS.MoveFirst()
		End If
		mbDataChanged = False
		
	End Sub
	
	'UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub update_Renamed()
		On Error GoTo UpdateErr
		
		adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll)
		
		If mbAddNewFlag Then
			adoPrimaryRS.MoveLast() 'move to the new record
		End If
		
		mbEditFlag = False
		mbAddNewFlag = False
		mbDataChanged = False
		
		Exit Sub
UpdateErr: 
		MsgBox(Err.Description)
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		update_Renamed()
		Me.Close()
	End Sub
	
	Private Sub goFirst()
		On Error GoTo GoFirstError
		
		adoPrimaryRS.MoveFirst()
		mbDataChanged = False
		
		Exit Sub
		
GoFirstError: 
		MsgBox(Err.Description)
	End Sub
	
	Private Sub goLast()
		On Error GoTo GoLastError
		
		adoPrimaryRS.MoveLast()
		mbDataChanged = False
		
		Exit Sub
		
GoLastError: 
		MsgBox(Err.Description)
	End Sub
	
    Private Sub grdDataGrid_CellValueChanged(ByVal eventSender As System.Object, ByVal eventArgs As DataGridViewCellEventArgs) Handles grdDataGrid.CellValueChanged

        '    If grdDataGrid.Columns(ColIndex).DataFormat.Format = "#,##0.00" Then
        '       grdDataGrid.Columns(ColIndex).DataFormat = 0
        '    End If

    End Sub
End Class