Option Strict Off
Option Explicit On
Friend Class frmStockTake
	Inherits System.Windows.Forms.Form
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim mbChangedByCode As Boolean
	Dim mvBookMark As Integer
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
	Dim blHandHeld As Boolean
	Dim gFilter As String
	Dim gFilterSQL As String
	Dim gID As Integer
	Dim lMWNo As Integer 'Multi Warehouse change
	
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1221 'Stock Take Adjustments|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'DUPLICATE DB ENTRIES! Item 1591 and 1705
		
		'lblHeading = No Code   [Using the "Stock Item Selector"...]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblHeading.Caption = rsLang("LanguageLayoutLnk_Description"): lblHeading.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1085 'Print|Checked
		If rsLang.RecordCount Then cmdPrint.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrint.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmStockTake.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Sub loadItem(ByRef id As Integer)
		If id Then 
		Else 
			Exit Sub
		End If
		
		frmStockTakeSnapshot.remoteSnapShot()
		System.Windows.Forms.Application.DoEvents()
		
		Dim rs As ADODB.Recordset
		gID = id
		lMWNo = frmMWSelect.getMWNo 'Multi Warehouse change
		rs = getRS("SELECT StockGroup.StockGroupID, StockGroup.StockGroup_Name From StockGroup WHERE (((StockGroup.StockGroupID)=" & gID & "));")
		lblHeading.Text = rs.Fields("StockGroup_Name").Value
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
		Dim rs As ADODB.Recordset
		Dim rj As ADODB.Recordset
		blHandHeld = False 'Initialize for StockGroup handheld
		
		rs = getRS("SELECT StockGroup_Name FROM StockGroup WHERE StockGroupID =" & gID)
		
		If UCase(Mid(rs.Fields("StockGroup_Name").Value, 1, 8)) = "HANDHELD" Then
			blHandHeld = True
			stTableName = rs.Fields("StockGroup_Name").Value
			
			'Set adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, " & stTableName & ".Quantity, StockItem.StockItem_Quantity," & stTableName & ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" & stTableName & " INNER JOIN StockItem ON " & stTableName & ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " & gID & ") And ((Warehouse.WarehouseID) = 2) And ((StockItem.StockItem_Disabled) = False) And ((StockItem.StockItem_Discontinued) = False)) ORDER BY StockItem.StockItem_Name")
			'Multi Warehouse change
			adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, " & stTableName & ".Quantity, StockItem.StockItem_Quantity," & stTableName & ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" & stTableName & " INNER JOIN StockItem ON " & stTableName & ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " & gID & ") And ((Warehouse.WarehouseID) = " & lMWNo & ") And ((StockItem.StockItem_Disabled) = False) And ((StockItem.StockItem_Discontinued) = False)) ORDER BY StockItem.StockItem_Name")
		Else
			'Multi Warehouse change
			'Set adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where StockGroup.StockGroupID = " & gID & " And StockTake.StockTake_WarehouseID = 2  AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ORDER BY StockItem.StockItem_Name;")
			adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where StockGroup.StockGroupID = " & gID & " And StockTake.StockTake_WarehouseID = " & lMWNo & " AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ORDER BY StockItem.StockItem_Name;")
			'Multi Warehouse change
		End If
		
		'Display the list of Titles in the DataCombo
		grdDataGrid.DataSource = adoPrimaryRS
		grdDataGrid.Columns(0).HeaderText = "Stock Name"
		grdDataGrid.Columns(0).DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft
		grdDataGrid.Columns(0).Frozen = True
		
		grdDataGrid.Columns(1).HeaderText = "Quantity"
		grdDataGrid.Columns(1).DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgRight
        grdDataGrid.Columns(1).Width = twipsToPixels(900, True)
		'UPGRADE_WARNING: Couldn't resolve default property of object grdDataGrid.Columns().DataFormat.Type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        grdDataGrid.Columns(1).DefaultCellStyle.Format = 1
        'grdDataGrid.Columns(1).NumberFormat = "#,##0.0000"
		grdDataGrid.Columns(1).Frozen = False
		
		grdDataGrid.Columns(2).Visible = False
		grdDataGrid.Columns(3).Visible = False
		grdDataGrid.Columns(4).Visible = False
		
		If blHandHeld = True Then
			grdDataGrid.Columns(5).Visible = False
			grdDataGrid.Columns(1).Frozen = True
		End If
		
		frmStockTake_Resize(Me, New System.EventArgs())
		mbDataChanged = False
		
	End Sub
	Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
		
		If blHandHeld = True Then
			update_Renamed()
			Update_Handheld()
			report_HandHeldScanner()
		Else
			update_Renamed()
			report_StockTake(gID, lMWNo)
		End If
		
	End Sub
	
	Private Sub cmdPrintDiff_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrintDiff.Click
		If blHandHeld = True Then
			MsgBox("No difference report for Handheld Capturing.")
		Else
			update_Renamed()
			report_StockTakeDiff(gID, lMWNo)
		End If
	End Sub
	
	'UPGRADE_WARNING: Event frmStockTake.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmStockTake_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		On Error Resume Next
		'This will resize the grid when the form is resized
		System.Windows.Forms.Application.DoEvents()
        grdDataGrid.Height = twipsToPixels(pixelToTwips(Me.ClientRectangle.Height, False) - 30 - pixelToTwips(picButtons.Height, False), False)
        grdDataGrid.Columns(0).Width = twipsToPixels(pixelToTwips(grdDataGrid.Width, True) - 900 - 580, True)
		
	End Sub
	Private Sub frmStockTake_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub frmStockTake_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
	End Sub
	
	Private Sub adoPrimaryRS_MoveComplete(ByVal adReason As ADODB.EventReasonEnum, ByVal pError As ADODB.Error, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.MoveComplete
		'This will display the current record position for this recordset
	End Sub
	Private Sub adoPrimaryRS_WillChangeRecord(ByVal adReason As ADODB.EventReasonEnum, ByVal cRecords As Integer, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.WillChangeRecord
		Dim lQuantity As Decimal 'Long
		
		If blHandHeld = True Then
			If adoPrimaryRS.Fields("Quantity").OriginalValue <> adoPrimaryRS.Fields("Quantity").Value Then
				lQuantity = adoPrimaryRS.Fields("Quantity").Value
				cnnDB.Execute("UPDATE " & stTableName & " SET Quantity = " & lQuantity & " WHERE " & stTableName & ".HandHeldID = " & adoPrimaryRS.Fields("StockTake_StockItemID").Value)
				doDiskFlush()
			End If
			
		Else
			If CDec(adoPrimaryRS.Fields("StockTake_Quantity").OriginalValue) <> CDec(adoPrimaryRS.Fields("StockTake_Quantity").Value) Then
				'lQuantity = adoPrimaryRS("StockTake_Quantity") '- adoPrimaryRS("StockTake_Quantity").OriginalValue
				
				'*
                lQuantity = adoPrimaryRS.Fields("StockTake_Quantity").Value - adoPrimaryRS.Fields("StockTake_Quantity").OriginalValue
				'cnnDB.Execute "UPDATE StockTake SET StockTake.StockTake_Quantity = [StockTake]![StockTake_Quantity]+(" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
				
				'Multi Warehouse change
				'cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
				'cnnDB.Execute "UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" & lQuantity & ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & "));"
				cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS.Fields("StockTake_StockItemID").Value & ") AND ((StockTake.StockTake_WarehouseID)=" & lMWNo & "));")
				cnnDB.Execute("UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" & lQuantity & ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & adoPrimaryRS.Fields("StockTake_StockItemID").Value & ") AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & lMWNo & "));")
				'Multi Warehouse change
				
				'*
				'cnnDB.Execute "UPDATE StockTake SET StockTake.StockTake_Quantity = [StockTake]![StockTake_Quantity]+(" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
				'cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = (" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
				'cnnDB.Execute "UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = (" & lQuantity & ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & "));"
				doDiskFlush()
			End If
			
		End If
		
	End Sub
	Sub Update_Handheld()
		Dim rs As ADODB.Recordset
		Dim sql As String
		Dim lQuantity As Decimal
		
		'Set adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, " & stTableName & ".Quantity, StockItem.StockItem_Quantity," & stTableName & ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" & stTableName & " INNER JOIN StockItem ON " & stTableName & ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " & gID & ") And ((Warehouse.WarehouseID) = 2) And ((StockItem.StockItem_Disabled) = False) And ((StockItem.StockItem_Discontinued) = False)) ORDER BY StockItem.StockItem_Name")
		'Multi Warehouse change
		adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, " & stTableName & ".Quantity, StockItem.StockItem_Quantity," & stTableName & ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" & stTableName & " INNER JOIN StockItem ON " & stTableName & ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " & gID & ") And ((Warehouse.WarehouseID) = " & lMWNo & ") And ((StockItem.StockItem_Disabled) = False) And ((StockItem.StockItem_Discontinued) = False)) ORDER BY StockItem.StockItem_Name")
		'Set adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name," & stTableName & ".Quantity,StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID,StockItem.StockItem_Quantity,StockTake.StockTake_WarehouseID," & stTableName & ".HandHeldID FROM " & _
		''                  "(StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN " & stTableName & " ON StockItem.StockItemID = " & stTableName & ".HandHeldID WHERE StockTake.StockTake_WarehouseID = 2 AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ORDER BY StockItem.StockItem_Name;")
		If adoPrimaryRS.RecordCount > 0 Then
			Do While adoPrimaryRS.EOF = False
				lQuantity = adoPrimaryRS.Fields("Quantity").Value - adoPrimaryRS.Fields("StockTake_Quantity").OriginalValue
				'cnnDB.Execute "UPDATE StockTake SET StockTake.StockTake_Quantity = " & lQuantity & " WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
				'cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
				'OLD'cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = " & lQuantity & " WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
				'cnnDB.Execute "UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" & lQuantity & ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & "));"
				'Multi Warehouse change
				cnnDB.Execute("UPDATE StockTake SET StockTake.StockTake_Quantity = " & lQuantity & " WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS.Fields("StockTake_StockItemID").Value & ") AND ((StockTake.StockTake_WarehouseID)=" & lMWNo & "));")
				cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS.Fields("StockTake_StockItemID").Value & ") AND ((StockTake.StockTake_WarehouseID)=" & lMWNo & "));")
				cnnDB.Execute("UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" & lQuantity & ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & adoPrimaryRS.Fields("StockTake_StockItemID").Value & ") AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & lMWNo & "));")
				adoPrimaryRS.moveNext()
			Loop 
		End If
		doDiskFlush()
	End Sub
	Private Sub doDiskFlush()
		Exit Sub
		Dim fso As New Scripting.FileSystemObject
		Dim hkey As Object
		Dim lRetVal As Integer
		Dim vValue As String
		Dim lPath As String
		Dim rs As ADODB.Recordset
		Dim lID, lCompanyID As Integer
		Dim lString As String
		Dim lKey As String
		lID = adoPrimaryRS.Fields("StockTake_StockItemID").Value
		'UPGRADE_WARNING: Couldn't resolve default property of object hkey. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\4POS", 0, KEY_QUERY_VALUE, hkey)
		'UPGRADE_WARNING: Couldn't resolve default property of object hkey. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		lRetVal = QueryValueEx(hkey, "master", vValue)
		'UPGRADE_WARNING: Couldn't resolve default property of object hkey. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		RegCloseKey(hkey)
		If vValue = "" Then
			Exit Sub
		Else
			lPath = vValue
		End If
		
		rs = getRS("SELECT Company.CompanyID, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, DayEndStockItemLnk.DayEndStockItemLnk_DayEndID, DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink FROM Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & lID & "));")
		
		
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
			adoPrimaryRS.MoveLast() 'Move to the new record
		End If
		
		mbEditFlag = False
		mbAddNewFlag = False
		mbDataChanged = False
		
		Exit Sub
		
UpdateErr: 
		
		If blHandHeld = True Then Exit Sub
		MsgBox(Err.Description)
		
		
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Dim Erro As Object
		Select Case Erro
			Case Is < 0
				Error(5)
			Case 1
				GoTo ERRP
		End Select
		
		If blHandHeld = True Then
			update_Renamed()
			Update_Handheld()
		Else
			update_Renamed()
		End If
		'Multi Warehouse change
		'Set adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where StockGroup.StockGroupID = 1 And StockTake.StockTake_WarehouseID = 2  AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ORDER BY StockItem.StockItem_Name;")
		adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where StockGroup.StockGroupID = 1 And StockTake.StockTake_WarehouseID = " & lMWNo & " AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ORDER BY StockItem.StockItem_Name;")
		'Multi Warehouse change
		Me.Close()
ERRP: 
		If blHandHeld = True Then Exit Sub
		
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