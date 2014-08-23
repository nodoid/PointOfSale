Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmMakeRepairItem
	Inherits System.Windows.Forms.Form
	Dim gStockItemID As Integer
	Dim gPromotionID As Integer
	Dim gQuantity As Integer
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1255 'Make Finished Product|Checked
		If rsLang.RecordCount Then frmMakeFinishItem.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : frmMakeFinishItem.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lblPComp = No Code     [Please enter the Qty you wish to make]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblPComp.Caption = rsLang("LanguageLayoutLnk_Description"): lblPComp.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1935 'Stock Item Name|Checked
		If rsLang.RecordCount Then _lbl_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lbl_2 = No Code       [Item Qty]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1151 'Price|Checked
		If rsLang.RecordCount Then _lbl_3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmMakeRepairItem.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Sub makeItem()
		Dim lID As Integer
		Dim rs As ADODB.Recordset
		
		lID = frmStockList.getItem
		If lID <> 0 Then
			On Error Resume Next
			loadItem(lID) 'adoPrimaryRS("PromotionID"), lID
		End If
	End Sub
	Private Sub loadData()
		Dim rs As ADODB.Recordset
		Dim rj As ADODB.Recordset
		
		rs = getRS("SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & gStockItemID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
		If rs.RecordCount Then
			lblStockItem.Text = rs.Fields("StockItem_Name").Value
			'lblPromotion.Caption = rs("Promotion_Name")
			txtPrice.Text = CStr(rs.Fields("CatalogueChannelLnk_Price").Value * 100)
			txtPrice_Leave(txtPrice, New System.EventArgs())
			'cmbQuantity.Tag = rs("CatalogueChannelLnk_Quantity")
			
			loadLanguage()
			ShowDialog()
		Else
			Me.Close()
			Exit Sub
		End If
		
	End Sub
	
	'Public Sub loadItem(promotionID As Long, stockitemID As Long, Optional quantity As Long)
	Public Sub loadItem(ByRef stockitemID As Integer, Optional ByRef quantity As Integer = 0)
		gStockItemID = stockitemID
		'gPromotionID = promotionID
		gQuantity = quantity
		'lblPComp.Caption = frmStockTransfer.lblPComp.Caption
		loadData()
		
		'show 1
		
	End Sub
	Private Sub frmMakeRepairItem_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim mbAddNewFlag As Boolean
        Dim mbEditFlag As Boolean
		If mbEditFlag Or mbAddNewFlag Then GoTo EventExitSub
		
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.Escape
				KeyAscii = 0
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
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        Dim mbDataChanged As Boolean
        Dim mvBookMark As Integer
        Dim adoPrimaryRS As ADODB.Recordset
        Dim mbAddNewFlag As Boolean
        Dim mbEditFlag As Boolean
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
		Me.Close()
	End Sub
	
	'UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Function update_Renamed() As Boolean
        Dim gID As Integer
        Dim strFldName As String
		On Error GoTo UpdateErr
		
		Dim rs As ADODB.Recordset
		Dim rj As ADODB.Recordset
		Dim adoPrimaryRS As ADODB.Recordset
		Dim sql As String
		Dim lQuantity As Decimal ' Long
		
		rs = getRS("SELECT * from RecipeStockitemLnk Where RecipeStockitemLnk_RecipeID = " & gStockItemID & ";")
		If rs.RecordCount > 0 Then
			'If MsgBox("You have " & rs.RecordCount & " enabled items in database. Do you want to make them Zero?", vbOKCancel) = vbOK Then
			
			strFldName = "HandHeldID Number,Handheld_Barcode Text(50), Quantity Currency"
			cnnDB.Execute("CREATE TABLE " & "HandheldMakeFinish" & " (" & strFldName & ")")
			System.Windows.Forms.Application.DoEvents()
			sql = "INSERT INTO HandheldMakeFinish (HandHeldID,Handheld_Barcode,Quantity) VALUES (" & gStockItemID & ", 0, " & CDec(txtQty.Text) & ")"
			cnnDB.Execute(sql)
			System.Windows.Forms.Application.DoEvents()
			
			Do While rs.EOF = False
				sql = "INSERT INTO HandheldMakeFinish (HandHeldID,Handheld_Barcode,Quantity) VALUES (" & rs.Fields("RecipeStockitemLnk_StockitemID").Value & ", 0, " & (0 - (rs.Fields("RecipeStockitemLnk_Quantity").Value * CDec(txtQty.Text))) & ")"
				cnnDB.Execute(sql)
				rs.moveNext()
			Loop 
			
			'Else
			'    Exit Sub
			'End If
		Else
			MsgBox("This Product does not have any Recipe.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
			Exit Function
		End If
		cnnDB.Execute("INSERT INTO StockGroup (StockGroup_Name) VALUES ('HandheldMakeFinish')")
		stTableName = "HandheldMakeFinish"
		rj = getRS("SELECT StockGroup.StockGroupID, StockGroup.StockGroup_Name From StockGroup WHERE StockGroup.StockGroup_Name = 'HandheldMakeFinish';")
		gID = rj.Fields("StockGroupID").Value
		
		'snap shot
		cnnDB.Execute("UPDATE Company SET Company.Company_StockTakeDate = now();")
		cnnDB.Execute("DELETE FROM StockTake WHERE (StockTake_WarehouseID = 2)")
		cnnDB.Execute("INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment ) SELECT StockItem.StockItemID, 2 AS warehouse, 0 AS quantity, 0 AS adjustment FROM StockItem;")
		cnnDB.Execute("UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));")
		cnnDB.Execute("DELETE FROM StockTakeDeposit")
		cnnDB.Execute("INSERT INTO StockTakeDeposit ( StockTakeDeposit_WarehouseID, StockTakeDeposit_DepositID, StockTakeDeposit_DepositTypeID, StockTakeDeposit_Quantity, StockTakeDeposit_Adjustment ) SELECT WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity FROM WarehouseDepositItemLnk INNER JOIN DISPLAY_Deposits ON (DISPLAY_Deposits.type = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = DISPLAY_Deposits.DepositID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID = DISPLAY_Deposits.WarehouseID);")
		'snap shot
		
		'Set adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, " & stTableName & ".Quantity, StockItem.StockItem_Quantity," & stTableName & ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" & stTableName & " INNER JOIN StockItem ON " & stTableName & ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " & gID & ") And ((Warehouse.WarehouseID) = 2) And ((StockItem.StockItem_Disabled) = False) And ((StockItem.StockItem_Discontinued) = False)) ORDER BY StockItem.StockItem_Name")
		adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, " & stTableName & ".Quantity, StockItem.StockItem_Quantity," & stTableName & ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" & stTableName & " INNER JOIN StockItem ON " & stTableName & ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " & gID & ") And ((Warehouse.WarehouseID) = 2)) ORDER BY StockItem.StockItem_Name")
		If adoPrimaryRS.RecordCount > 0 Then
			Do While adoPrimaryRS.EOF = False
				lQuantity = adoPrimaryRS.Fields("Quantity").Value
				'lQuantity = adoPrimaryRS("Quantity") - adoPrimaryRS("StockTake_Quantity").OriginalValue
				cnnDB.Execute("UPDATE StockTake SET StockTake.StockTake_Quantity = " & lQuantity & " WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS.Fields("StockTake_StockItemID").Value & ") AND ((StockTake.StockTake_WarehouseID)=2));")
				cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS.Fields("StockTake_StockItemID").Value & ") AND ((StockTake.StockTake_WarehouseID)=2));")
				'cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = 0 WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
				cnnDB.Execute("UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" & lQuantity & ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & adoPrimaryRS.Fields("StockTake_StockItemID").Value & "));")
				adoPrimaryRS.moveNext()
			Loop 
		End If
		
		cnnDB.Execute("DROP TABLE HandheldMakeFinish")
		cnnDB.Execute("DELETE * FROM StockGroup WHERE StockGroup_Name ='HandheldMakeFinish'")
		MsgBox("Make Finished Product process has been completed.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
		
		
		update_Renamed = True
		
		Exit Function
UpdateErr: 
		MsgBox(Err.Description)
		update_Renamed = True
	End Function
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		cmdClose.Focus()
		System.Windows.Forms.Application.DoEvents()
		
		If CDec(txtQty.Text) > 0 Then
		Else
			txtQty.Focus()
			Exit Sub
		End If
		
		If CDec(txtQtyTaken.Text) > 0 Then
		Else
			txtQtyTaken.Focus()
			Exit Sub
		End If
		
		If CDec(txtQty.Text) > CDec(txtQtyTaken.Text) Then
			MsgBox("Cannot make more then taken Qty.")
			txtQtyTaken.Focus()
			Exit Sub
		End If
		
		If updateProc() Then
			Me.Close()
		End If
	End Sub
	
	Private Function updateProc() As Boolean
        Dim AsHoldOriginal As Decimal
        Dim gID As Integer
        Dim strFldName As String
		On Error GoTo UpdateErr
		
		Dim rs As ADODB.Recordset
		Dim rj As ADODB.Recordset
		Dim RSadoPrimary As ADODB.Recordset
		Dim rsBarcode As ADODB.Recordset
		Dim fso As New Scripting.FileSystemObject
		Dim sql As String
		Dim lQuantity As Decimal
		Dim getNewID As Integer
		
		'Set rs = getRS("SELECT VegTestItem.*, StockItem.StockItemID, StockItem.StockItem_SBarcode FROM VegTestItem INNER JOIN StockItem ON VegTestItem.VegTestItem_StockItemID = StockItem.StockItemID WHERE (((VegTestItem.VegTestItem_VegTestID)=" & testID & "));")
		'If rs.RecordCount > 0 Then
		strFldName = "HandHeldID Number,Handheld_Barcode Text(50), Quantity Currency"
		cnnDB.Execute("CREATE TABLE " & "HandheldVegTest" & " (" & strFldName & ")")
		System.Windows.Forms.Application.DoEvents()
		sql = "INSERT INTO HandheldVegTest (HandHeldID,Handheld_Barcode,Quantity) VALUES (" & gStockItemID & ", 0, " & (0 - (CDec(txtQtyTaken.Text) - CDec(txtQty.Text))) & ")"
		cnnDB.Execute(sql)
		System.Windows.Forms.Application.DoEvents()
		'       Do While rs.EOF = False
		'           If rs("VegTestItem_PerWeightYield") > 0 Then
		'               getNewID = 0
		'               If rs("StockItem_SBarcode") = True Then
		'                   getNewID = rs("VegTestItem_StockItemID")
		'                   'create new
		'                   'CreateVegItems rs("VegTestItem_StockItemID"), rs("VegTestItem_ActualSellPriceIncl"), rs("VegTestItem_PackSize"), getNewID   ' csvSplit(0), csvSplit(1), csvSplit(2), CCur(csvSplit(3)), CCur(csvSplit(4)), csvSplit(6), csvSplit(7)
		'               Else
		'                   getNewID = rs("VegTestItem_StockItemID")
		'               End If
		'               'Stock Adjustment
		'               sql = "INSERT INTO HandheldVegTest (HandHeldID,Handheld_Barcode,Quantity) VALUES (" & getNewID & ", 0, " & (rs("VegTestItem_PerWeightYield")) & ")"
		'               cnnDB.Execute sql
		'           End If
		'           rs.moveNext
		'       Loop
		'Else
		'   MsgBox "This Product does not have any Recipe.", vbApplicationModal + vbInformation + vbOKOnly, App.title
		'   Exit Function
		'End If
		
		'---------------------------------------------
		cnnDB.Execute("INSERT INTO StockGroup (StockGroup_Name) VALUES ('HandheldVegTest')")
		stTableName = "HandheldVegTest"
		rj = getRS("SELECT StockGroup.StockGroupID, StockGroup.StockGroup_Name From StockGroup WHERE StockGroup.StockGroup_Name = 'HandheldVegTest';")
		gID = rj.Fields("StockGroupID").Value
		
		'snap shot
		cnnDB.Execute("UPDATE Company SET Company.Company_StockTakeDate = now();")
		'Multi Warehouse change
		cnnDB.Execute("DELETE FROM StockTake WHERE (StockTake_WarehouseID > 0)")
		cnnDB.Execute("INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment ) SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, 0 AS quantity, 0 AS adjustment FROM WarehouseStockItemLnk;")
		cnnDB.Execute("UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)>0));")
		'Multi Warehouse change
		' cnnDB.Execute "UPDATE StockTake SET StockTake.StockTake_Adjustment = [StockTake]![StockTake_Quantity];"
		cnnDB.Execute("DELETE FROM StockTakeDeposit")
		cnnDB.Execute("INSERT INTO StockTakeDeposit ( StockTakeDeposit_WarehouseID, StockTakeDeposit_DepositID, StockTakeDeposit_DepositTypeID, StockTakeDeposit_Quantity, StockTakeDeposit_Adjustment ) SELECT WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity FROM WarehouseDepositItemLnk INNER JOIN DISPLAY_Deposits ON (DISPLAY_Deposits.type = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = DISPLAY_Deposits.DepositID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID = DISPLAY_Deposits.WarehouseID);")
		'snap shot
		
		RSadoPrimary = getRS("SELECT StockItem.StockItem_Name, " & stTableName & ".Quantity, StockItem.StockItem_Quantity," & stTableName & ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" & stTableName & " INNER JOIN StockItem ON " & stTableName & ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " & gID & ") And ((Warehouse.WarehouseID) = 2)) ORDER BY StockItem.StockItem_Name")
		If RSadoPrimary.RecordCount > 0 Then
			Do While RSadoPrimary.EOF = False
				
				AsHoldOriginal = RSadoPrimary.Fields("StockTake_Adjustment").Value
				'Setting the StockTake_Adjustment to it's original value
				RSadoPrimary.Fields("StockTake_Adjustment").Value = 0
				lQuantity = AsHoldOriginal + RSadoPrimary.Fields("StockTake_Quantity").OriginalValue
				
				lQuantity = RSadoPrimary.Fields("Quantity").Value
				
				lQuantity = RSadoPrimary.Fields("Quantity").Value + RSadoPrimary.Fields("StockTake_Quantity").OriginalValue
				
				cnnDB.Execute("INSERT INTO StockTakeDetail ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment, StockTake_DayEndID, StockTake_Note, StockTake_DateTime ) SELECT " & RSadoPrimary.Fields("StockTake_StockItemID").Value & ", 2, " & lQuantity & ", " & RSadoPrimary.Fields("Quantity").Value & ", Company_DayEndID, '" & "4VEG Repair" & " ', #" & Now & "# FROM Company;")
				
				cnnDB.Execute("UPDATE StockTake SET StockTake.StockTake_Quantity = " & lQuantity & " WHERE (((StockTake.StockTake_StockItemID)=" & RSadoPrimary.Fields("StockTake_StockItemID").Value & ") AND ((StockTake.StockTake_WarehouseID)=2));")
				'cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]-(" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & RSadoPrimary("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
				cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = " & lQuantity & " WHERE (((StockTake.StockTake_StockItemID)=" & RSadoPrimary.Fields("StockTake_StockItemID").Value & ") AND ((StockTake.StockTake_WarehouseID)=2));")
				'cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = 0 WHERE (((StockTake.StockTake_StockItemID)=" & RSadoPrimary("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
				cnnDB.Execute("UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" & RSadoPrimary.Fields("Quantity").Value & ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & RSadoPrimary.Fields("StockTake_StockItemID").Value & "));")
				RSadoPrimary.moveNext()
			Loop 
		End If
		
		'Update POS
		'Set rsPri = getRS("SELECT GRVItem.GRVItem_StockItemID, (GRVItem.GRVItem_Quantity*GRVItem_PackSize) AS GRVItem_Quantity, StockItem.StockItem_SBarcode,StockItem.StockItem_SShelf FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE GRVItem_GRVID = " & Val(frmGRV.adoPrimaryRS("GRVID")) & " AND (StockItem_SBarcode = True Or StockItem_SShelf = True)")
		'Set rsBarcode = getRS("SELECT HandheldVegTest.HandHeldID AS GRVItem_StockItemID, HandheldVegTest.Quantity AS GRVItem_Quantity, StockItem.StockItem_SBarcode, StockItem.StockItem_SShelf FROM HandheldVegTest INNER JOIN StockItem ON HandheldVegTest.HandHeldID = StockItem.StockItemID WHERE (((HandheldVegTest.Quantity)>0));")
		rsBarcode = getRS("SELECT HandheldVegTest.HandHeldID AS GRVItem_StockItemID, " & CDec(txtQty.Text) & " AS GRVItem_Quantity, StockItem.StockItem_SBarcode, StockItem.StockItem_SShelf FROM HandheldVegTest INNER JOIN StockItem ON HandheldVegTest.HandHeldID = StockItem.StockItemID WHERE (((HandheldVegTest.Quantity)<>0) AND ((StockItem.StockItem_SBarcode)=True)) OR (((StockItem.StockItem_SShelf)=True));")
		'Write file
		If rsBarcode.RecordCount Then
			If fso.FileExists(serverPath & "ShelfBarcode.dat") Then fso.DeleteFile(serverPath & "ShelfBarcode.dat", True)
			rsBarcode.save(serverPath & "ShelfBarcode.dat", ADODB.PersistFormatEnum.adPersistADTG)
			grvPrin = True
			'If MsgBox("Do you want to do Shelf/Barcode Printing on flagged StockItems?", vbQuestion + vbYesNo + vbApplicationModal + vbDefaultButton1, App.title) = vbYes Then
			
			blMEndUpdatePOS = True
			blChangeOnlyUpdatePOS = True
			frmUpdatePOScriteria.ShowDialog()
			blChangeOnlyUpdatePOS = False
			blMEndUpdatePOS = False
			
			frmBarcode.ShowDialog()
		End If
		
		cnnDB.Execute("DROP TABLE HandheldVegTest")
		cnnDB.Execute("DELETE * FROM StockGroup WHERE StockGroup_Name ='HandheldVegTest'")
		'cnnDB.Execute "UPDATE VegTest SET VegTest_VegTestStatusID = 3 WHERE (VegTestID = " & testID & ")"
		'cnnDB.Execute "UPDATE VegTest INNER JOIN GRVItem ON (VegTest.VegTest_GRVID = GRVItem.GRVItem_GRVID) AND (VegTest.VegTest_MainItemID = GRVItem.GRVItem_StockItemID) SET GRVItem.GRVItem_QuantityUsedKG = " & CCur(TotalQTY.Text) & " WHERE (((VegTest.VegTestID)=" & testID & "));"
		
		MsgBox("Repair process has been completed.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
		updateProc = True
		
		Exit Function
UpdateErr: 
		MsgBox(Err.Description)
		Resume Next
		'updateProc = True
	End Function
	
	Private Sub txtPrice_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPrice.Enter
        MyGotFocusNumeric(txtPrice)
	End Sub
	
	Private Sub txtPrice_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtPrice.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        MyKeyPressNegative(txtPrice, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
    Private Sub txtPrice_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPrice.Leave
        MyLostFocus(txtPrice, 2)
    End Sub
	
    Private Sub txtPrice_MyGotFocus(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        MyGotFocusNumeric(txtPrice)
    End Sub
	
    Private Sub txtPrice_MyLostFocus(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        MyLostFocus(txtPrice, 2)
    End Sub
	
	Private Sub txtQty_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQty.Enter
        MyGotFocusNumeric(txtQty)
	End Sub
	
	Private Sub txtQty_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        MyKeyPress(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtQty_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQty.Leave
        MyLostFocus(txtQty, 0)
	End Sub
	
	Private Sub txtQtyTaken_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQtyTaken.Enter
        MyGotFocusNumeric(txtQtyTaken)
	End Sub
	
	Private Sub txtQtyTaken_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtQtyTaken.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        MyKeyPress(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtQtyTaken_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQtyTaken.Leave
        MyLostFocus(txtQtyTaken, 0)
	End Sub

    Private Sub frmMakeRepairItem_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub
End Class