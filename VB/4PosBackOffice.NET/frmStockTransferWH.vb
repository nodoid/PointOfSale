Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmStockTransferWH
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
	Public loadDBStr As String
	'Multi Warehouse change
	Public lWHA As Integer
	Public lWHB As Integer
	
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1787 'Stock Transfer Details|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1085 'Print|Checked
		If rsLang.RecordCount Then cmdPrint.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrint.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1789 'Transfer|Checked
		If rsLang.RecordCount Then cmdTransfer.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdTransfer.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1790 'Transfer From|Checked
		If rsLang.RecordCount Then _lbl_5.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_5.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1801 'Transfer To|Checked
		If rsLang.RecordCount Then _lbl_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1139 'Promotion Name|Checked
		If rsLang.RecordCount Then lblWHA.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lblWHA.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1139 'Promotion Name|Checked
		If rsLang.RecordCount Then lblWHB.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lblWHB.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1802 'Select wharehouse transfer from|checked
		If rsLang.RecordCount Then cmdSelWHA.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdSelWHA.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1803 'Select wharehouse transfer to|Checked
		If rsLang.RecordCount Then cmdSelWHB.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdSelWHB.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1147 'Add|Checked
		If rsLang.RecordCount Then cmdAdd.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdAdd.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1148 'Delete|Checked
		If rsLang.RecordCount Then cmdDelete.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdDelete.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmStockTransferWH.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub buildDataControls()
		'    doDataControl Me.cmbChannel, "SELECT ChannelID, Channel_Name FROM Channel ORDER BY ChannelID", "Customer_ChannelID", "ChannelID", "Channel_Name"
	End Sub
	
    Private Sub doDataControl(ByRef dataControl As myDataGridView, ByRef sql As String, ByRef DataField As String, ByRef boundColumn As String, ByRef listField As String)
        Dim rs As ADODB.Recordset
        rs = getRS(sql)
        'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        dataControl.DataSource = rs
        'UPGRADE_ISSUE: Control method dataControl.DataSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        dataControl.DataSource = adoPrimaryRS
        'UPGRADE_ISSUE: Control method dataControl.DataField was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        dataControl.DataField = DataField
        'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.boundColumn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        dataControl.boundColumn = boundColumn
        'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.listField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        dataControl.listField = listField
    End Sub
	
	Public Sub loadItem(ByRef id As Integer)
        'Dim oText As System.Windows.Forms.TextBox
        'Dim oDate As DateTimePicker
        'Dim oCheck As System.Windows.Forms.CheckBox
		
		loadLanguage()
		ShowDialog()
	End Sub
	Private Sub setup()
	End Sub
	
	Private Sub chkFields_Click(ByRef Index As Short)
		
	End Sub
	
	Private Sub cmdAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAdd.Click
		Dim lID As Integer
		Dim rs As ADODB.Recordset
		
		lID = frmStockList.getItem
		If lID <> 0 Then
			On Error Resume Next
			frmStockTransferItemWH.loadItem(lID,  , lWHA, lWHB)
			loadItems(lID)
		End If
	End Sub
	Private Sub cmdDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDelete.Click
		Dim lID As Integer
		If lvStockT.FocusedItem Is Nothing Then
		Else
			If MsgBox("Are you sure you wish to remove  '" & lvStockT.FocusedItem.Text & "'  from this Transfer?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "DELETE") = MsgBoxResult.Yes Then
				lID = CInt(Split(lvStockT.FocusedItem.Name, "_")(0))
				cnnDB.Execute("DELETE HandheldWHTransfer.* From HandheldWHTransfer WHERE HandheldWHTransfer.HandHeldID=" & lID & " AND HandheldWHTransfer.Quantity=" & Split(lvStockT.FocusedItem.Name, "_")(1) & ";")
				loadItems()
			End If
		End If
		
	End Sub
	
	Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
		'update
		'report_Promotion
	End Sub
	
	
	Private Sub cmdSelComp_Click()
		Dim lblSComp As Object
		'frmSelComp.show 1
		Dim cn As ADODB.Connection
		Dim rj As ADODB.Recordset
		
		loadDBStr = frmSelComp.loadDB
		
		If loadDBStr = "" Then
		Else
			cn = openSComp(loadDBStr)
			If cn Is Nothing Then
			Else
				
				rj = getRSwaitron("SELECT Company_Name FROM Company;", cn)
				'UPGRADE_WARNING: Couldn't resolve default property of object lblSComp.Caption. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lblSComp.Caption = rj.Fields("Company_Name").Value
				
				cmdAdd.Enabled = True
				cmdDelete.Enabled = True
			End If
			
		End If
	End Sub
	
	Private Sub cmdSelWHA_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSelWHA.Click
		Dim rj As ADODB.Recordset
		lWHA = frmMWSelect.getMWNo 'Multi Warehouse change
		If lWHA > 1 Then
			rj = getRS("SELECT * FROM Warehouse WHERE WarehouseID=" & lWHA & ";")
			lblWHA.Text = rj.Fields("Warehouse_Name").Value
			cmdSelWHA.Enabled = False
			cmdSelWHB.Enabled = True
		End If
	End Sub
	
	Private Sub cmdSelWHB_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSelWHB.Click
		Dim rj As ADODB.Recordset
		lWHB = frmMWSelect.getMWNo 'Multi Warehouse change
		If lWHB = lWHA Then MsgBox("Cannot select same warehouse at both ends.") : Exit Sub
		If lWHB > 1 Then
			rj = getRS("SELECT * FROM Warehouse WHERE WarehouseID=" & lWHB & ";")
			lblWHB.Text = rj.Fields("Warehouse_Name").Value
			cmdSelWHB.Enabled = False
			'cmdSelWHB.Enabled = True
			
			cmdAdd.Enabled = True
			cmdDelete.Enabled = True
		End If
	End Sub
	
	Private Sub cmdTransfer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdTransfer.Click
		Dim rsID As ADODB.Recordset
		Dim rs As ADODB.Recordset
		Dim x As Short
		Dim cn As ADODB.Connection
		Dim rsChk As ADODB.Recordset
		Dim errPosition As String
		Dim gID As Integer
		Dim lQuantity As Decimal
		
		On Error GoTo ErrTransfer
		errPosition = "Start"
		
		If lvStockT.Items.Count > 0 Then
			errPosition = "1"
			
			'cnnDB.Execute "INSERT INTO StockGroup (StockGroup_Name) VALUES ('HandheldWHTransfer')"
			stTableName = "HandheldWHTransfer"
			'Set rj = getRS("SELECT StockGroup.StockGroupID, StockGroup.StockGroup_Name From StockGroup WHERE StockGroup.StockGroup_Name = 'HandheldWHTransfer';")
			'gID = rj("StockGroupID")
			
			errPosition = "2"
			''Multi Warehouse change
			'cnnDB.Execute "UPDATE Company SET Company.Company_StockTakeDate = now();"
			'cnnDB.Execute "DELETE FROM StockTake WHERE (StockTake_WarehouseID > 0)"
			'cnnDB.Execute "INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment ) SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, 0 AS quantity, 0 AS adjustment FROM WarehouseStockItemLnk;"
			'cnnDB.Execute "UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)>0));"
			''Multi Warehouse change
			'cnnDB.Execute "DELETE FROM StockTakeDeposit"
			'cnnDB.Execute "INSERT INTO StockTakeDeposit ( StockTakeDeposit_WarehouseID, StockTakeDeposit_DepositID, StockTakeDeposit_DepositTypeID, StockTakeDeposit_Quantity, StockTakeDeposit_Adjustment ) SELECT WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity FROM WarehouseDepositItemLnk INNER JOIN DISPLAY_Deposits ON (DISPLAY_Deposits.type = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = DISPLAY_Deposits.DepositID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID = DISPLAY_Deposits.WarehouseID);"
			''Multi Warehouse change
			''snap shot
			
			errPosition = "3"
			'Warehouse From
			adoPrimaryRS = getRS("SELECT * FROM " & stTableName & " Where ((HandheldWHTransfer.WHouseID)=" & lWHA & ")")
			'Set adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, " & stTableName & ".Quantity, StockItem.StockItem_Quantity," & stTableName & ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" & stTableName & " INNER JOIN StockItem ON " & stTableName & ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " & gID & ") And ((Warehouse.WarehouseID) = " & lWHA & ") AND ((HandheldWHTransfer.WHouseID)=" & lWHA & ")) ORDER BY StockItem.StockItem_Name")
			If adoPrimaryRS.RecordCount > 0 Then
				Do While adoPrimaryRS.EOF = False
					lQuantity = adoPrimaryRS.Fields("Quantity").Value
					'cnnDB.Execute "UPDATE StockTake SET StockTake.StockTake_Quantity = " & lQuantity & " WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=" & lWHA & "));"
					'cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=" & lWHA & "));"
					'cnnDB.Execute "UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" & lQuantity & ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & lWHA & "));"
					
					cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN " & stTableName & " ON (" & stTableName & ".WHouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = " & stTableName & ".HandHeldID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" & lQuantity & ") WHERE (((" & stTableName & ".HandHeldID)=" & adoPrimaryRS.Fields("HandHeldID").Value & ") AND ((" & stTableName & ".WHouseID)=" & lWHA & "));")
					cnnDB.Execute("UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityTransafer = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityTransafer]+(" & lQuantity & ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & adoPrimaryRS.Fields("HandHeldID").Value & ") AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & lWHA & "));")
					adoPrimaryRS.moveNext()
				Loop 
			End If
			
			
			'Warehouse To
			adoPrimaryRS = getRS("SELECT * FROM " & stTableName & " Where ((HandheldWHTransfer.WHouseID)=" & lWHB & ")")
			'Set adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, " & stTableName & ".Quantity, StockItem.StockItem_Quantity," & stTableName & ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" & stTableName & " INNER JOIN StockItem ON " & stTableName & ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " & gID & ") And ((Warehouse.WarehouseID) = " & lWHA & ") AND ((HandheldWHTransfer.WHouseID)=" & lWHB & ")) ORDER BY StockItem.StockItem_Name")
			If adoPrimaryRS.RecordCount > 0 Then
				Do While adoPrimaryRS.EOF = False
					lQuantity = adoPrimaryRS.Fields("Quantity").Value
					'cnnDB.Execute "UPDATE StockTake SET StockTake.StockTake_Quantity = " & lQuantity & " WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=" & lWHB & "));"
					'cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=" & lWHB & "));"
					'cnnDB.Execute "UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" & lQuantity & ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & lWHB & "));"
					
					cnnDB.Execute("INSERT INTO StockTransferWH ( StockTransferWH_Date, StockTransferWH_DayEndID, StockTransferWH_PersonID, StockTransferWH_WHFrom, StockTransferWH_WHTo, StockTransferWH_StockItemID, StockTransferWH_Qty ) SELECT Now() AS [date], Company.Company_DayEndID, " & frmMenu.lblUser.Tag & ", " & lWHA & ", " & lWHB & ", " & adoPrimaryRS.Fields("HandHeldID").Value & ", " & adoPrimaryRS.Fields("Quantity").Value & " FROM Company;")
					cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN " & stTableName & " ON (" & stTableName & ".WHouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = " & stTableName & ".HandHeldID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" & lQuantity & ") WHERE (((" & stTableName & ".HandHeldID)=" & adoPrimaryRS.Fields("HandHeldID").Value & ") AND ((" & stTableName & ".WHouseID)=" & lWHB & "));")
					cnnDB.Execute("UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityTransafer = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityTransafer]+(" & lQuantity & ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & adoPrimaryRS.Fields("HandHeldID").Value & ") AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & lWHB & "));")
					adoPrimaryRS.moveNext()
				Loop 
			End If
			
			errPosition = "4"
			report_WHTransfer()
			
			cnnDB.Execute("DROP TABLE HandheldWHTransfer")
			'cnnDB.Execute "DELETE * FROM StockGroup WHERE StockGroup_Name ='HandheldWHTransfer'"
			
			MsgBox("Stock Transfer process has been completed.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly + MsgBoxStyle.DefaultButton2, "Completed")
			Me.Close()
		Else
		End If
		
		Exit Sub
ErrTransfer: 
		MsgBox("Error at position no. " & errPosition & " Err Number " & Err.Number & " " & Err.Description)
		Resume Next
	End Sub
	
	Private Sub report_WHTransfer()
		Dim rs As ADODB.Recordset
        Dim sql As String
        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryWHTransfer.rpt")
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		rs = getRS("SELECT Company.Company_Name FROM Company;")
		Report.SetParameterValue("txtCompanyName",rs.Fields("Company_Name"))
		rs.Close()
		
        Report.SetParameterValue("txtFrom", lblWHA.Text)
        Report.SetParameterValue("txtTo", lblWHB.Text)
        Report.SetParameterValue("txtPerson", frmMenu.lblUser)
		
		sql = "SELECT HandheldWHTransfer.HandHeldID, StockItem.StockItem_Name, HandheldWHTransfer.Quantity"
		sql = sql & " FROM HandheldWHTransfer INNER JOIN StockItem ON HandheldWHTransfer.HandHeldID = StockItem.StockItemID WHERE (((HandheldWHTransfer.WHouseID)=" & lWHB & "));"
		Debug.Print(sql)
		rs = getRS(sql)
		
		Dim ReportNone As CrystalDecisions.CrystalReports.Engine.ReportDocument
		ReportNone.Load("cryNoRecords.rpt")
		If rs.BOF Or rs.EOF Then
			ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
			ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
			frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
			frmReportShow.CRViewer1.ReportSource = ReportNone
			frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
			frmReportShow.CRViewer1.Refresh()
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			frmReportShow.ShowDialog()
			Exit Sub
		End If
		Report.Database.Tables(1).SetDataSource(rs)
		
		'Report.VerifyOnEveryPrint = True
		frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
		frmReportShow.CRViewer1.ReportSource = Report
		frmReportShow.mReport = Report : frmReportShow.sMode = "0"
		frmReportShow.CRViewer1.Refresh()
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		frmReportShow.ShowDialog()
	End Sub
	
	Private Sub frmStockTransferWH_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		lvStockT.Columns.Clear()
        lvStockT.Columns.Add("", "Stock Item", CInt(twipsToPixels(5050, True)))
        lvStockT.Columns.Add("QTY", CInt(twipsToPixels(800, True)), System.Windows.Forms.HorizontalAlignment.Right)
		'lvStockT.ColumnHeaders.Add , , "Price", 1440, 1
		loadLanguage()
		'Dim rj As Recordset
		'Set rj = getRS("SELECT Company_Name FROM Company;")
		'lblPComp.Caption = rj("Company_Name")
		lblWHA.Text = "Select Warehouse Transfer From"
		cmdSelWHA.Enabled = True
		
		lblWHB.Text = "Select Warehouse Transfer To"
		cmdSelWHB.Enabled = False
		
		cmdAdd.Enabled = False
		cmdDelete.Enabled = False
		'cmdTransfer.Enabled = False
		ChkHandheldWHTransfer()
		cnnDB.Execute("DELETE * from HandheldWHTransfer;")
	End Sub
	
	Private Sub ChkHandheldWHTransfer()
		Dim rs As ADODB.Recordset
		Dim strFldName As String
		
ChkTransTable: 
		
		On Error GoTo Err_ChkTransTable
		rs = getRS("SELECT * FROM HandheldWHTransfer;")
		If rs.RecordCount Then
		End If
		
		Exit Sub
Err_ChkTransTable: 
		If Err.Number = -2147217865 And Err.Description = "[Microsoft][ODBC Microsoft Access Driver] The Microsoft Jet database engine cannot find the input table or query 'HandheldWHTransfer'.  Make sure it exists and that its name is spelled correctly." Then
			strFldName = "HandHeldID Number,Handheld_Barcode Text(50), Quantity Currency, WHouseID Number"
			cnnDB.Execute("CREATE TABLE HandheldWHTransfer (" & strFldName & ")")
			System.Windows.Forms.Application.DoEvents()
			rs = getRS("SELECT * FROM HandheldWHTransfer;")
			If rs.RecordCount Then
			End If
			
			GoTo ChkTransTable
		End If
		
	End Sub
	
	Private Sub loadItems(Optional ByRef lID As Integer = 0, Optional ByRef quantity As Short = 0)
		Dim listItem As System.Windows.Forms.ListViewItem
		Dim rs As ADODB.Recordset
		lvStockT.Items.Clear()
		rs = getRS("SELECT StockItem.StockItem_Name, HandheldWHTransfer.* FROM HandheldWHTransfer INNER JOIN StockItem ON HandheldWHTransfer.HandHeldID = StockItem.StockItemID WHERE HandheldWHTransfer.WHouseID = " & lWHB & " ORDER BY StockItem.StockItem_Name;")
		Do Until rs.EOF
			
			listItem = lvStockT.Items.Add(rs.Fields("HandHeldID").Value & "_" & rs.Fields("Quantity").Value, rs.Fields("StockItem_Name").Value, "")
			'UPGRADE_WARNING: Lower bound of collection listItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If listItem.SubItems.Count > 1 Then
				listItem.SubItems(1).Text = rs.Fields("Quantity").Value
			Else
				listItem.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("Quantity").Value))
			End If
			If rs.Fields("HandHeldID").Value = lID And rs.Fields("Quantity").Value = quantity Then listItem.Selected = True
			rs.moveNext()
		Loop 
	End Sub
	
	'UPGRADE_WARNING: Event frmStockTransferWH.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmStockTransferWH_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        Dim cmdLast As New Button
        Dim cmdNext As New Button
        Dim lblStatus As New Label
		On Error Resume Next
		lblStatus.Width = pixelToTwips(Me.Width, True) - 1500
		cmdNext.Left = lblStatus.Width + 700
		cmdLast.Left = cmdNext.Left + 340
	End Sub
	
	Private Sub frmStockTransferWH_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub frmStockTransferWH_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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
		'    On Error Resume Next
		'    If mbAddNewFlag Then
		Me.Close()
		'    Else
		'        mbEditFlag = False
		'        mbAddNewFlag = False
		'        adoPrimaryRS.CancelUpdate
		'        If mvBookMark > 0 Then
		'            adoPrimaryRS.Bookmark = mvBookMark
		'        Else
		'            adoPrimaryRS.MoveFirst
		'        End If
		'        mbDataChanged = False
		'    End If
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
		'DoEvents
		'If update() Then
		'   If _chkFields_1.value = 0 Then
		'      cnnDB.Execute "UPDATE Promotion SET Promotion_StartDate = #" & DTFields(0).value & "#, Promotion_EndDate = #" & DTFields(1).value & "#, Promotion_StartTime = #" & DTFields(2).value & "# ,Promotion_EndTime =#" & DTFields(3).value & "# WHERE PromotionID = " & p_Prom & ";"
		'   End If
		'   Unload Me
		'End If
	End Sub
	
	Private Sub Label1_Click()
		
	End Sub
	
	Private Sub lvStockT_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvStockT.DoubleClick
		Dim lID As Integer
		Dim lQty As Short
		If lvStockT.FocusedItem Is Nothing Then
		Else
			lID = CInt(Split(lvStockT.FocusedItem.Name, "_")(0))
			lQty = CShort(Split(lvStockT.FocusedItem.Name, "_")(1))
			
			frmStockTransferItemWH.loadItem(lID, CShort(lQty), lWHA, lWHB)
			loadItems(lID, lQty)
		End If
	End Sub
	
	Private Sub lvStockT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles lvStockT.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Then
			lvStockT_DoubleClick(lvStockT, New System.EventArgs())
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
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