Option Strict Off
Option Explicit On
Imports StdFormat
Friend Class frmStockMultiName
	Inherits System.Windows.Forms.Form
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim mbChangedByCode As Boolean
	Dim mvBookMark As Integer
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
	
	Dim gFilter As String
	Dim gFilterSQL As String
	
	Private Sub loadLanguage()
		
		'frmStockMultiName = No Code    [Edit Stock Item Names]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmStockMultiName.Caption = rsLang("LanguageLayoutLnk_Description"): frmStockMultiName.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblHeading = No Code           [Using the "Stock Item Selector"...]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblHeading.Caption = rsLang("LanguageLayoutLnk_Description"): lblHeading.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1006 'Filter|Checked
		If rsLang.RecordCount Then cmdFilter.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdFilter.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1085 'Print|Checked
		If rsLang.RecordCount Then cmdPrint.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrint.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
        'UPGRADE_ISSUE: Form property frmStockMultiName.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub cmdFilter_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFilter.Click
		frmFilter.loadFilter(gFilter)
		getNamespace()
	End Sub
	
	Private Sub getNamespace()
		Dim lString As Object
		If gFilter = "" Then
			Me.lblHeading.Text = ""
		Else
			frmFilter.buildCriteria(gFilter)
			Me.lblHeading.Text = frmFilter.gHeading
		End If
		gFilterSQL = frmFilter.gCriteria
		If gFilterSQL = "" Then
			'UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lString = " WHERE StockItem.StockItem_Disabled=0 AND StockItem.StockItem_Discontinued=0 "
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lString = gFilterSQL & " AND StockItem.StockItem_Disabled=0 AND StockItem.StockItem_Discontinued=0 "
		End If
		
		'UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		adoPrimaryRS = getRS("SELECT StockItem_Name,StockItem_ReceiptName FROM StockItem " & lString & " ORDER BY StockItem_Name")
		'Display the list of Titles in the DataCombo
		
		grdDataGrid.DataSource = adoPrimaryRS
        grdDataGrid.Columns(0).HeaderText = "Stock Name"
        grdDataGrid.Columns(0).DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft
		
        grdDataGrid.Columns(1).HeaderText = "Receipt Name"
        grdDataGrid.Columns(1).DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft
        grdDataGrid.Columns(1).Width = twipsToPixels(2000, True)
		frmStockMultiName_Resize(Me, New System.EventArgs())
		mbDataChanged = False
		
	End Sub

	Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
		Dim rs As ADODB.Recordset
        Dim ltype As Boolean
        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryStockItemName.rpt")
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtTilte", Me.Text)
        Report.SetParameterValue("txtFilter", Me.lblHeading.Text)
		rs.Close()
		'Report.Database.SetDataSource(adoPrimaryRS, 3)
        Report.Database.Tables(1).SetDataSource(adoPrimaryRS)
		'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTilte").ToString
		frmReportShow.CRViewer1.ReportSource = Report
		frmReportShow.mReport = Report : frmReportShow.sMode = "0"
		frmReportShow.CRViewer1.Refresh()
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		frmReportShow.ShowDialog()
		
	End Sub
	
	Private Sub frmStockMultiName_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub frmStockMultiName_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim myfmt = New StdDataFormat
		myfmt.Type = FormatType.fmtCustom
		gFilter = "stockitem"
		getNamespace()
		mbDataChanged = False
		
		loadLanguage()
	End Sub
	
	Private Sub frmStockMultiName_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		On Error Resume Next
		'This will resize the grid when the form is resized
		System.Windows.Forms.Application.DoEvents()
        grdDataGrid.Height = twipsToPixels(pixelToTwips(Me.ClientRectangle.Height, False) - 30 - _
                                          pixelToTwips(picButtons.Height, False), False)
        grdDataGrid.Columns(0).Width = twipsToPixels(pixelToTwips(grdDataGrid.Width, True) - 2000 - _
                                                    580, True)
		
	End Sub
	
	Private Sub frmStockMultiName_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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
	
	Private Sub cmdCancel_Click()
		On Error Resume Next
		
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
	
    'Private Sub grdDataGrid_CellValueChanged(ByVal eventSender As System.Object, ByVal eventArgs As DataColumnChangeEventArgs) Handles grdDataGrid.ColumnDisplayIndexChanged
    '    If grdDataGrid.Columns(ColIndex).DataFormat.Format = "#,##0.00" Then
    '       grdDataGrid.Columns(ColIndex).DataFormat = 0
    '    End If

    'End Sub
End Class