Option Strict Off
Option Explicit On
Friend Class frmDepositTake
	Inherits System.Windows.Forms.Form
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim mbChangedByCode As Boolean
    Dim mvBookMark As Integer
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
	
	Dim gFilter As String
	Dim gFilterSQL As String
	Private fmtBooleanData As StdFormat.StdDataFormat
	
	Private Sub loadLanguage()
		
		'frmDepositTake = No Code   [Deposit Stock Take Adjustments]
		''rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmDepositTake.Caption = rsLang("LanguageLayoutLnk_Description"): frmDepositTake.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblHeading = No Code       [Deposit Stock Take List]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblHeading.Caption = rsLang("LanguageLayoutLnk_Description"): lblHeading.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1085 'Print|Checked
		If rsLang.RecordCount Then cmdPrint.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrint.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmDepositTake.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Sub loadItem()
		frmStockTakeSnapshot.remoteSnapShot()
		System.Windows.Forms.Application.DoEvents()
		
		getNamespace()
		mbDataChanged = False
		
		loadLanguage()
		ShowDialog()
	End Sub
	
	
	Private Sub cmdFilter_Click()
		frmFilter.loadFilter(gFilter)
		getNamespace()
	End Sub
	
	Private Sub getNamespace()
		
		adoPrimaryRS = getRS("SELECT Deposit.Deposit_Name, StockTakeDeposit_DepositTypeID, StockTakeDeposit.StockTakeDeposit_Quantity, StockTakeDeposit_DepositTypeID, StockTakeDeposit.StockTakeDeposit_WarehouseID, StockTakeDeposit.StockTakeDeposit_DepositID FROM Deposit INNER JOIN StockTakeDeposit ON Deposit.DepositID = StockTakeDeposit.StockTakeDeposit_DepositID Where (((StockTakeDeposit.StockTakeDeposit_WarehouseID) = 2)) ORDER BY Deposit.Deposit_Name, StockTakeDeposit.StockTakeDeposit_DepositTypeID;")
		
		'Display the list of Titles in the DataCombo
        grdDataGrid.DataSource = adoPrimaryRS
        grdDataGrid.Columns(0).HeaderText = "Stock Name"
        grdDataGrid.Columns(0).DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft
        grdDataGrid.Columns(0).Frozen = True
		
        grdDataGrid.Columns(1).HeaderText = "Type"
        grdDataGrid.Columns(1).Frozen = True
        grdDataGrid.Columns(1).Width = twipsToPixels(900, True)
        grdDataGrid.Columns(1).DefaultCellStyle.Format = fmtBooleanData
		
		
        grdDataGrid.Columns(2).HeaderText = "Quantity"
        grdDataGrid.Columns(2).DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgRight
        grdDataGrid.Columns(2).Width = twipsToPixels(900, True)
		'UPGRADE_WARNING: Couldn't resolve default property of object grdDataGrid.Columns().DataFormat.Type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'grdDataGrid.Columns(2).DefaultCellStyle.FormatProvid = 1
        grdDataGrid.Columns(2).DefaultCellStyle.Format = "#,##0"
        grdDataGrid.Columns(2).Frozen = False
		
		grdDataGrid.Columns(5).Visible = False
		grdDataGrid.Columns(3).Visible = False
		grdDataGrid.Columns(4).Visible = False
		
		frmDepositTake_Resize(Me, New System.EventArgs())
		mbDataChanged = False
		
	End Sub
	
	
	
	Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
		report_DepositTake()
	End Sub
	
	Private Sub frmDepositTake_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		fmtBooleanData = New StdFormat.StdDataFormat
		fmtBooleanData.Type = StdFormat.FormatType.fmtBoolean
		fmtBooleanData.TrueValue = "Crate"
		fmtBooleanData.FalseValue = "Bottle"
		fmtBooleanData.NullValue = ""
		
	End Sub
	Private Sub frmDepositTake_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	'UPGRADE_WARNING: Event frmDepositTake.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmDepositTake_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		On Error Resume Next
		'This will resize the grid when the form is resized
		System.Windows.Forms.Application.DoEvents()
        grdDataGrid.Height = twipsToPixels(pixelToTwips(Me.ClientRectangle.Height, False) _
                                          - 30 - pixelToTwips(picButtons.Height, False), False)
        grdDataGrid.Columns(0).Width = twipsToPixels(pixelToTwips(grdDataGrid.Width, True) _
                                                    - 1800 - 580, True)
		
	End Sub
	
	Private Sub frmDepositTake_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
	End Sub
	
	Private Sub adoPrimaryRS_MoveComplete(ByVal adReason As ADODB.EventReasonEnum, ByVal pError As ADODB.Error, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.MoveComplete
		'This will display the current record position for this recordset
	End Sub
	
	Private Sub adoPrimaryRS_WillChangeRecord(ByVal adReason As ADODB.EventReasonEnum, ByVal cRecords As Integer, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.WillChangeRecord
        Dim lQuantity As Integer
		If adoPrimaryRS.Fields("StockTakeDeposit_Quantity").OriginalValue <> adoPrimaryRS.Fields("StockTakeDeposit_Quantity").Value Then
            lQuantity = CInt(adoPrimaryRS.Fields("StockTakeDeposit_Quantity").Value) - CInt(adoPrimaryRS.Fields("StockTakeDeposit_Quantity").OriginalValue)
			cnnDB.Execute("UPDATE WarehouseDepositItemLnk SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk]![WarehouseDepositItemLnk_Quantity]+(" & lQuantity & ") WHERE (((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=" & adoPrimaryRS.Fields("StockTakeDeposit_WarehouseID").Value & ") AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID)=" & adoPrimaryRS.Fields("StockTakeDeposit_DepositID").Value & ") AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=" & adoPrimaryRS.Fields(1).Value & "));")
			
			cnnDB.Execute("UPDATE Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityShrink = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityShrink]+" & lQuantity & " WHERE (((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID)=" & adoPrimaryRS.Fields("StockTakeDeposit_DepositID").Value & ") AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=" & adoPrimaryRS.Fields(1).Value & "));")
			
			doDiskFlush()
			
		End If
	End Sub
	Private Sub doDiskFlush()
		Exit Sub
		Dim fso As New Scripting.FileSystemObject
        Dim hkey As Integer
		Dim lRetVal As Integer
		Dim vValue As String
		Dim lPath As String
		Dim rs As ADODB.Recordset
		Dim lID, lCompanyID As Integer
		Dim lString As String
		Dim lKey As String
		Dim lDepositType As Short
		lID = adoPrimaryRS.Fields("StockTakeDeposit_DepositID").Value
		lDepositType = adoPrimaryRS.Fields(1).Value
		lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\4POS", 0, KEY_QUERY_VALUE, hkey)
		lRetVal = QueryValueEx(hkey, "master", vValue)
		RegCloseKey(hkey)
		If vValue = "" Then
			Exit Sub
		Else
			lPath = vValue
		End If
		rs = getRS("SELECT Company.CompanyID, DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID, DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID, DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityShrink, DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType FROM Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID WHERE (((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID)=" & lID & ") AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=" & lDepositType & "));")
		
		'If rs.RecordCount Then
		'Key = rs("CompanyID") & "_" & rs("DayEndDeposittemLnk_DepositID") & "_" & rs("DayEndDepositItemLnk_DayEndID") & "_" & CInt(lDepositType + 1)
		'lCompanyID = rs("CompanyID")
		'If fso.FileExists(lPath & lCompanyID & "\" & Key & ".stk") Then fso.DeleteFile lPath & lCompanyID & "\" & Key & ".stk"
		'If rs("DayEndDepositItemLnk_QuantityShrink") Then
		'Set lTextstream = fso.OpenTextFile(lPath & lCompanyID & "\" & Key & ".stk", ForWriting, True)
		'lTextstream.Write rs("DayEndDepositItemLnk_QuantityShrink")
		'lTextstream.Close
		'End If
		'End If
		
	End Sub
	Private Sub cmdCancel_Click()
		On Error Resume Next
		
		mbEditFlag = False
		mbAddNewFlag = False
		adoPrimaryRS.CancelUpdate()
		If mvBookMark > 0 Then
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
	
    'Private Sub grdDataGrid_CellValueChanged(ByVal eventSender As System.Object, ByVal eventArgs As AxMSDataGridLib.DDataGridEvents_CellValueChangedEvent) Handles grdDataGrid.CellValueChanged
    '    If grdDataGrid.Columns(ColIndex).DataFormat.Format = "#,##0.00" Then
    '       grdDataGrid.Columns(ColIndex).DataFormat = 0
    '    End If

    'End Sub
End Class