Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Friend Class frmStockTakeAdd
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
	
	Public Sub loadLanguage()
		
		'Note: Form Caption Grammer Wrong!
		'frmStockTakeAdd = No Code  [Stock Take Add (This option will only Add stock to your quantities and is NOT a Stock Take!)]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmStockTakeAdd.Caption = rsLang("LanguageLayoutLnk_Description"): frmStockTakeAdd.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblHeading = No Code       [Using the "Stock Item Selector"...]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblHeading.Caption = rsLang("LanguageLayoutLnk_Description"): lblHeading.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1085 'Print|Checked
		If rsLang.RecordCount Then cmdPrint.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrint.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1427 'Reference|Checked
		If rsLang.RecordCount Then lbl.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
        'UPGRADE_ISSUE: Form property frmStockTakeAdd.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Sub loadItem(ByRef id As Integer)
		If id Then 
		Else 
			Exit Sub
		End If
		Dim rs As ADODB.Recordset
		
		'Dim lMWNo As Long
		'lMWNo = frmMWSelect.getMWNo
		'If lMWNo > 1 Then
		'    Set rsWH = getRS("SELECT * FROM Warehouse WHERE WarehouseID=" & lMWNo & ";")
		'    Report.txtWH.SetText rsWH("Warehouse_Name")
		'End If
		
		gID = id
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
			adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, " & stTableName & ".Quantity, StockItem.StockItem_Quantity," & stTableName & ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" & stTableName & " INNER JOIN StockItem ON " & stTableName & ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " & gID & ") And ((Warehouse.WarehouseID) = 2) And ((StockItem.StockItem_Disabled) = False) And ((StockItem.StockItem_Discontinued) = False)) ORDER BY StockItem.StockItem_Name")
			
		Else
			'  Set adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where StockGroup.StockGroupID = " & gID & " And StockTake.StockTake_WarehouseID = 2  AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ORDER BY StockItem.StockItem_Name;")
			adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, StockTake.StockTake_Adjustment, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where StockGroup.StockGroupID = " & gID & " And StockTake.StockTake_WarehouseID = 2  AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ORDER BY StockItem.StockItem_Name;")
			
		End If
		
		'Display the list of Titles in the DataCombo
		grdDataGrid1.DataSource = adoPrimaryRS
		grdDataGrid1.Columns(0).HeaderText = "Stock Name"
		grdDataGrid1.Columns(0).DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft
		grdDataGrid1.Columns(0).Frozen = True
		
		grdDataGrid1.Columns(1).HeaderText = "Quantity"
		grdDataGrid1.Columns(1).DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgRight
        grdDataGrid1.Columns(1).Width = twipsToPixels(900, True)
		'UPGRADE_WARNING: Couldn't resolve default property of object grdDataGrid1.Columns().DataFormat.Type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        grdDataGrid1.Columns(1).DefaultCellStyle.Format = 1
        'grdDataGrid1.Columns(1).NumberFormat = "#,##0.0000"
		grdDataGrid1.Columns(1).Frozen = False
		
		grdDataGrid1.Columns(2).Visible = False
		grdDataGrid1.Columns(3).Visible = False
		grdDataGrid1.Columns(4).Visible = False
		grdDataGrid1.Columns(5).Visible = False
		'grdDataGrid1.Columns(6).Visible = False
		
		If blHandHeld = True Then
			grdDataGrid1.Columns(5).Visible = False
		End If
		
		frmStockTakeAdd_Resize(Me, New System.EventArgs())
		mbDataChanged = False
		
	End Sub
	Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
		
		If blHandHeld = True Then
			report_HandHeldScanner()
		Else
			report_StockTake(gID)
		End If
		
	End Sub
	
    Private Function getRegKey(ByRef lKey As String) As String
        Dim hkey As Integer
        Dim lRetVal As Integer
        Dim vValue As Integer
        lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\4POS\pos", 0, KEY_QUERY_VALUE, hkey)
        lRetVal = QueryValueEx(hkey, lKey, vValue)
        RegCloseKey(hkey)
        getRegKey = vValue
    End Function
	
	Private Sub cmdPrintSlip_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrintSlip.Click
        Dim Object_Renamed As New Printer
        Dim rightX As Short
        Dim lString As String
        Dim y As Short
        Dim lRetVal As String
        Dim hkey As Integer
		Dim vValue As Object
		Dim Printer As New Printer
        Dim gFontSize As Integer
        Dim gValue As String
        Dim gFontName As String
        Dim sql As String
		Dim rsPrinter As ADODB.Recordset
		Dim rs As ADODB.Recordset
		Dim TheBarcodePrName As String
		Dim lPrinter As String
		Dim lPrn As Printer
		Dim lPrnType As Printer
        Dim gObject As Printer
		'On Local Error Resume Next
		Const characters As Short = 32
		Dim gWidth As Integer
		Dim gLeft As Integer
		Dim gRight As Integer
		
		rs = getRS("SELECT Company_PrintDayEndSlip from Company;")
		If rs.RecordCount Then
			If rs.Fields("Company_PrintDayEndSlip").Value Then
				
			Else
				Exit Sub
			End If
		Else
			Exit Sub
		End If
		
		If blHandHeld = True Then
			sql = "SELECT " & stTableName & ".HandHeldID,StockItem.StockItem_Name," & stTableName & ".Quantity,StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID,StockItem.StockItem_Quantity,StockTake.StockTake_WarehouseID," & stTableName & ".HandHeldID FROM " & "(StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN " & stTableName & " ON StockItem.StockItemID = " & stTableName & ".HandHeldID WHERE StockTake.StockTake_WarehouseID = 2 AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ORDER BY StockItem.StockItem_Name;"
			rs = getRS(sql)
			If rs.BOF Or rs.EOF Then
				Exit Sub
			End If
		Else
			sql = "SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_Adjustment, StockTake.StockTake_QuantityOrig, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity "
			sql = sql & "FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_Adjustment) <> 0) And ((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & gID & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_Adjustment) <> 0) And ((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & gID & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_Adjustment) <> 0) And ((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & gID & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;"
			rs = getRS(sql)
			If rs.BOF Or rs.EOF Then
				Exit Sub
			End If
		End If
		
		On Error Resume Next

        gFontName = getRegKey("printerPOSfontName")
		If gFontName = "" Then gFontName = "Courier"
        gValue = getRegKey("printerPOSfontSize")
		If gValue = "" Then
			gFontSize = 10
		Else
			gFontSize = CShort(gValue)
		End If
		
		gValue = getRegKey("printerPOSleft")
		On Error Resume Next
		If gValue = "" Then
			gLeft = 0
		Else
			gLeft = CInt(gValue) * Printer.TwipsPerPixelX
		End If
		gValue = getRegKey("printerPOSright")
		If gValue = "" Then
			gRight = 0
		Else
			gRight = CInt(gValue) * Printer.TwipsPerPixelX
		End If
		
		vValue = ""
		lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\4POS\pos", 0, KEY_QUERY_VALUE, hkey)
		lRetVal = QueryValueEx(hkey, "printerPOS", vValue)
		RegCloseKey(hkey)
		If vValue = "" Then vValue = "0"
		
		If vValue <> "0" Then
			If vValue = "[Not Installed]" Then
				Exit Sub
			End If
			
			For	Each lPrn In Printers
				If LCase(lPrn.DeviceName) = LCase(vValue) Then
					Printer = lPrn
					lPrinter = vValue
					Exit For
				End If
			Next lPrn
			
			gWidth = Printer.Width
			If gWidth = 2724 Then 
			Else 
				gWidth = 3600
			End If
			
			gObject = Printer
			
			
			On Error Resume Next
			gObject.FontBold = True
            gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
			'gObject.PSet(New Point(((gWidth - gRight) - gObject.TextWidth(" ")) / 2, gObject.CurrentY))
			gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
			gObject.Print(" ")
			
			gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            'gObject.PSet(New Point(((gWidth - gRight) - gObject.TextWidth(frmMenu.lblCompany.Text)) / 2, gObject.CurrentY))
			gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
			gObject.Print(frmMenu.lblCompany.Text)
			
			gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
			gObject.Print(" ")
			
			gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
			'gObject.PSet(New Point(((gWidth - gRight) - gObject.TextWidth("Stock Addition")) / 2, gObject.CurrentY))
			gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
			gObject.Print("Stock Addition")
			gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
			gObject.Print(" ")
			
			gObject.FontUnderline = True
			y = gObject.CurrentY
			gObject.FontBold = True
			lString = "Reference" & " :"
			gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
			gObject.Print(lString)
			gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
			gObject.FontBold = False
			lString = txtSARef.Text
			'gObject.PSet (1800, y)
			'gObject.PSet(New Point(IIf(gWidth = 2724, 1050, 1800), y)) '1350
			gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
			gObject.Print(lString)
			
			gObject.FontUnderline = True
			y = gObject.CurrentY
			gObject.FontBold = True
			lString = "Date" & " :"
			gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
			gObject.Print(lString)
			gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
			gObject.FontBold = False
			lString = Format(Now, "ddd dd mm,yyyy hh:nn")
			'gObject.PSet (1800, y)
			'gObject.PSet(New Point(IIf(gWidth = 2724, 1050, 1800), y)) '1350
			gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
			gObject.Print(lString)
			
			gObject.FontUnderline = False
			
            'gObject.Line((0, gObject.CurrentY) - ((gObject.Width - gRight) - rightX, gObject.CurrentY + 1))

            gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
			'gObject.PSet(New Point(0, gObject.CurrentY + 30))
			gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
			
			gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
			gObject.Print(" ")
			Object_Renamed.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
			
			Do Until rs.EOF
				
				y = gObject.CurrentY
				gObject.FontBold = True
				lString = rs.Fields("StockItem_Name").Value
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
				gObject.Print(lString)
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
				
				y = gObject.CurrentY
				gObject.FontBold = False
				lString = rs.Fields("StockTake_Adjustment").Value
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                gObject.Print(lString)
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
				
				'gObject.FontBold = False
				'lString = rs("StockTake_Quantity")
				'gObject.PSet (IIf(gWidth = 2724, 1050, 1800), y) '1350
				'gObject.ForeColor = vbBlack
				'gObject.Print lString
				
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
				gObject.Print(" ")
				Object_Renamed.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
				
				rs.moveNext()
			Loop 
			
			gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
			'gObject.Line(0, (gObject.CurrentY - ((gObject.Width - gRight) - rightX, gObject.CurrentY + 1)

            gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
			'gObject.PSet(New Point(0, gObject.CurrentY + 30))
			gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
			'For x = 1 To 6
			'    gObject.Print " "
			'Next x
			gObject.EndDoc()
			
		End If
	End Sub
	
	Private Sub frmStockTakeAdd_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		On Error Resume Next
		'This will resize the grid when the form is resized
		System.Windows.Forms.Application.DoEvents()
		grdDataGrid1.Height = grdDataGrid.ClientRectangle.Height ' Me.ScaleHeight - 50 - picButtons.Height - txtSARef.Height
        grdDataGrid1.Columns(0).Width = twipsToPixels(pixelToTwips(grdDataGrid1.Width, True) - 900 - 580, True)
		
	End Sub
	Private Sub frmStockTakeAdd_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub frmStockTakeAdd_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		'
	End Sub
	
	Private Sub adoPrimaryRS_MoveComplete(ByVal adReason As ADODB.EventReasonEnum, ByVal pError As ADODB.Error, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.MoveComplete
		'This will display the current record position for this recordset
	End Sub
	
	Private Sub adoPrimaryRS_WillChangeRecord(ByVal adReason As ADODB.EventReasonEnum, ByVal cRecords As Integer, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.WillChangeRecord
		
		'*
		'cnnDB.Execute "SELECT * FROM StockTake"
		'*Updating the StockTake_Add field
		' cnnDB.Execute "UPDATE StockTake SET StockTake.StockTake_Add = " & adoPrimaryRS("StockTake_Adjustment") & " WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
		'check = adoPrimaryRS("StockTake_Add")
		
		'*
		
	End Sub
	Sub Update_Handheld()

		Dim lQuantity As Integer
		
		adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, " & stTableName & ".Quantity, StockItem.StockItem_Quantity," & stTableName & ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" & stTableName & " INNER JOIN StockItem ON " & stTableName & ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " & gID & ") And ((Warehouse.WarehouseID) = 2) And ((StockItem.StockItem_Disabled) = False) And ((StockItem.StockItem_Discontinued) = False)) ORDER BY StockItem.StockItem_Name")
		
		'Set adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name," & stTableName & ".Quantity,StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID,StockItem.StockItem_Quantity,StockTake.StockTake_WarehouseID," & stTableName & ".HandHeldID FROM " & _
		''                  "(StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN " & stTableName & " ON StockItem.StockItemID = " & stTableName & ".HandHeldID WHERE StockTake.StockTake_WarehouseID = 2 AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ORDER BY StockItem.StockItem_Name;")
		
		If adoPrimaryRS.RecordCount > 0 Then
			Do While adoPrimaryRS.EOF = False
				lQuantity = adoPrimaryRS.Fields("Quantity").Value
				
				cnnDB.Execute("UPDATE StockTake SET StockTake.StockTake_Quantity = " & lQuantity & " WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS.Fields("StockTake_StockItemID").Value & ") AND ((StockTake.StockTake_WarehouseID)=2));")
				cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = " & lQuantity & " WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS.Fields("StockTake_StockItemID").Value & ") AND ((StockTake.StockTake_WarehouseID)=2));")
				cnnDB.Execute("UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" & lQuantity & ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & adoPrimaryRS.Fields("StockTake_StockItemID").Value & "));")
				adoPrimaryRS.moveNext()
			Loop 
		End If
		doDiskFlush()
	End Sub
	Private Sub doDiskFlush()
        'Exit Sub
        Dim fso As New Scripting.FileSystemObject
        Dim hkey As Integer
		Dim lRetVal As Integer
        Dim vValue As Integer
		Dim lPath As String
		Dim rs As ADODB.Recordset
        Dim lID As Integer
		lID = adoPrimaryRS.Fields("StockTake_StockItemID").Value
		lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "Software\4POS", 0, KEY_QUERY_VALUE, hkey)
		lRetVal = QueryValueEx(hkey, "master", vValue)
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
		On Error GoTo ERRP
		
		If blHandHeld = True Then
			update_Renamed()
			Update_Handheld()
		Else
			update_Renamed()
		End If
		'Set adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where StockGroup.StockGroupID = 1 And StockTake.StockTake_WarehouseID = 2  AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ORDER BY StockItem.StockItem_Name;")
		
		cmdPrintSlip_Click(cmdPrintSlip, New System.EventArgs())
		'*/
		
		Dim lQuantity As Decimal
		Dim AsHoldOriginal As Decimal
		
		'AsHoldOriginal = adoPrimaryRS("StockTake_Quantity").OriginalValue
		
		
		adoPrimaryRS.MoveFirst()
		If blHandHeld = True Then
			If adoPrimaryRS.Fields("Quantity").OriginalValue <> adoPrimaryRS.Fields("Quantity").Value Then
				lQuantity = adoPrimaryRS.Fields("Quantity").Value
				cnnDB.Execute("UPDATE " & stTableName & " SET Quantity = " & lQuantity & " WHERE " & stTableName & ".HandHeldID = " & adoPrimaryRS.Fields("StockTake_StockItemID").Value)
				doDiskFlush()
			End If
			
		Else
			
			'cnnDB.Execute "SELECT * FROM StockTake"
			adoPrimaryRS.MoveFirst()
			'* Adding stock to quantity
			
			Do Until adoPrimaryRS.EOF
				
				If adoPrimaryRS.Fields("StockTake_Adjustment").Value > 0 Or adoPrimaryRS.Fields("StockTake_Adjustment").Value < 0 Then
					AsHoldOriginal = adoPrimaryRS.Fields("StockTake_Adjustment").Value
					'Setting the StockTake_Adjustment to it's original value
					adoPrimaryRS.Fields("StockTake_Adjustment").Value = 0
					lQuantity = AsHoldOriginal + adoPrimaryRS.Fields("StockTake_Quantity").OriginalValue
					'Adding the Cases in stock and Current units in stock
					cnnDB.Execute("INSERT INTO StockTakeDetail ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment, StockTake_DayEndID, StockTake_Note, StockTake_DateTime ) SELECT " & adoPrimaryRS.Fields("StockTake_StockItemID").Value & ", 2, " & lQuantity & ", " & AsHoldOriginal & ", Company_DayEndID, '" & Replace(txtSARef.Text, "'", "''") & "', #" & Now & "# FROM Company;")
					'*
					'lQuantity = AsHoldOriginal - adoPrimaryRS("StockTake_Quantity").OriginalValue
					cnnDB.Execute("UPDATE StockTake SET StockTake.StockTake_Quantity = (" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS.Fields("StockTake_StockItemID").Value & ") AND ((StockTake.StockTake_WarehouseID)=2));")
					cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = (" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS.Fields("StockTake_StockItemID").Value & ") AND ((StockTake.StockTake_WarehouseID)=2));")
					cnnDB.Execute("UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" & AsHoldOriginal & ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & adoPrimaryRS.Fields("StockTake_StockItemID").Value & "));")
					'*
					' cnnDB.Execute "UPDATE StockTake SET StockTake.StockTake_Quantity = (" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
					' cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = (" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
					'cnnDB.Execute "UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = (" & lQuantity & ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & "));"
					' cnnDB.Execute "UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = DayEndStockItemLnk_QuantityShrink -(" & AsHoldOriginal & "),DayEndStockItemLnk_AddQuantityShrink =(" & AsHoldOriginal & ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & "));"
					
					doDiskFlush()
					
				End If
				adoPrimaryRS.moveNext()
			Loop 
			
		End If
		
		'*/
		
		
		'Set adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where StockGroup.StockGroupID = 1 And StockTake.StockTake_WarehouseID = 2  AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ORDER BY StockItem.StockItem_Name;")
		
		Me.Close()
		
		Exit Sub
ERRP: 
		'If adoPrimaryRS.EOF Then
		'Else
		'MsgBox Err.Description
		'Resume Next
		If blHandHeld = True Then Exit Sub
		'End If
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
	
    Private Sub grdDataGrid1_CellValueChanged(ByVal eventSender As System.Object, ByVal eventArgs As DataGridViewCellEventArgs) Handles grdDataGrid1.CellValueChanged
        '    If grdDataGrid1.Columns(ColIndex).DataFormat.Format = "#,##0.00" Then
        '       grdDataGrid1.Columns(ColIndex).DataFormat = 0
        '    End If

    End Sub
End Class