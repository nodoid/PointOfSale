Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmMakeFinishItem
	Inherits System.Windows.Forms.Form
	Dim gStockItemID As Integer
	Dim gPromotionID As Integer
	Dim gQuantity As Integer
	Dim bApplyChk As Boolean
	
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1255 'Make Finished Product|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
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
		'UPGRADE_ISSUE: Form property frmMakeFinishItem.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Sub makeItem()
		Dim lID As Integer
		Dim rs As ADODB.Recordset
		
		bApplyChk = False
		lID = frmStockList.getItem
		If lID <> 0 Then
			On Error Resume Next
			loadItem(lID) 'adoPrimaryRS("PromotionID"), lID
		End If
	End Sub
	Private Sub loadData()
		Dim rs As ADODB.Recordset
		Dim rj As ADODB.Recordset
		
		rs = getRS("SELECT Company_MakeFinishSaleChk FROM Company;")
		If rs.RecordCount Then
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rs.Fields("Company_MakeFinishSaleChk").Value) Then
			Else
				If rs.Fields("Company_MakeFinishSaleChk").Value Then
					bApplyChk = True
				End If
			End If
		End If
		
		rs = getRS("SELECT StockItem.StockItem_Name, StockItem_MakeFinishItem, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & gStockItemID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
		If rs.RecordCount Then
			lblStockItem.Text = rs.Fields("StockItem_Name").Value
			'lblPromotion.Caption = rs("Promotion_Name")
			txtPrice.Text = CStr(rs.Fields("CatalogueChannelLnk_Price").Value * 100)
			txtPrice_Leave(txtPrice, New System.EventArgs())
			'cmbQuantity.Tag = rs("CatalogueChannelLnk_Quantity")
			
			If bApplyChk Then
				'sales qty
				If rs.Fields("StockItem_MakeFinishItem").Value = 1 Then
					lblSaleQty.ForeColor = System.Drawing.Color.Red
					lblSaleQty.Text = "Option only allowed once per Day End."
					chkSaleQTY.Enabled = False
				Else
					lblSaleQty.ForeColor = System.Drawing.Color.Black
					lblSaleQty.Text = "[ 0 ]"
					chkSaleQTY.Enabled = True
					'Set rs = getRS("SELECT SUM(SaleItem.SaleItem_Quantity*SaleItem.SaleItem_ShrinkQuantity) as tQTY from SaleItem WHERE (((SaleItem.SaleItem_StockItemID)=" & gStockItemID & "));")
					rs = getRS("SELECT Sum(SaleItem.SaleItem_Quantity*SaleItem.SaleItem_ShrinkQuantity) AS tQTY FROM Company INNER JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON Company.Company_DayEndID = Sale.Sale_DayEndID WHERE (((SaleItem.SaleItem_StockItemID)=" & gStockItemID & "));")
					If rs.RecordCount Then
						'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If IsDbNull(rs.Fields("tQTY").Value) Then
							lblSaleQty.Text = "[ 0 ]"
						Else
							lblSaleQty.Text = "[ " & rs.Fields("tQTY").Value & " ]"
						End If
					End If
				End If
			Else
				lblSaleQty.Visible = False
				chkSaleQTY.Visible = False
			End If
			
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
	Private Sub frmMakeFinishItem_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
        Dim strIn As String
        Dim y As Integer
        Dim arrBOMDetail As String()
        Dim arrBOMMaster As String
        Dim x As Integer
        Dim strFldName As String
        Dim cTemp As String
		On Error GoTo UpdateErr
		
		Dim rWHs As ADODB.Recordset
		Dim rs As ADODB.Recordset
		Dim rj As ADODB.Recordset
		Dim adoPrimaryRS As ADODB.Recordset
		Dim sql As String
		Dim lQuantity As Decimal ' Long
		Dim saleQTY As Decimal
		
		If bApplyChk Then
			If lblSaleQty.Text = "Option only allowed once per Day End." Then
				saleQTY = 0
			ElseIf chkSaleQTY.Enabled = False Then 
			Else
				If lblSaleQty.Text <> "[ 0 ]" Then
					cTemp = Replace(lblSaleQty.Text, "[", "")
					cTemp = Replace(cTemp, "]", "")
					cTemp = Replace(cTemp, " ", "")
					saleQTY = CDec(cTemp)
				End If
			End If
		End If
		
		rs = getRS("SELECT * from RecipeStockitemLnk Where RecipeStockitemLnk_RecipeID = " & gStockItemID & ";")
		If rs.RecordCount > 0 Then
			'If MsgBox("You have " & rs.RecordCount & " enabled items in database. Do you want to make them Zero?", vbOKCancel) = vbOK Then
			
			If chkSaleQTY.CheckState = 1 Then
				If CDec(txtqty.Text) <= saleQTY Then
					MsgBox("Make QTY should be bigger then Sale QTY when 'Apply Sales Qty' option is selected.")
					Exit Function
				End If
				
				If MsgBox("You have entered '" & CDec(txtqty.Text) & "' unit(s) to make and you already sold '" & saleQTY & "' for current day." & vbCrLf & vbCrLf & "You have selected 'Apply Sales Qty'. Do you wish to make '" & System.Math.Abs(CDec(txtqty.Text) - saleQTY) & "' unit(s)?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
					txtqty.Text = CStr(System.Math.Abs(CDec(txtqty.Text) - saleQTY))
				Else
					Exit Function
				End If
			End If
			
			strFldName = "HandHeldID Number,Handheld_Barcode Currency, Quantity Currency"
			cnnDB.Execute("CREATE TABLE " & "HandheldMakeFinish" & " (" & strFldName & ")")
			System.Windows.Forms.Application.DoEvents()
			sql = "INSERT INTO HandheldMakeFinish (HandHeldID,Handheld_Barcode,Quantity) VALUES (" & gStockItemID & ", 0, " & CDec(txtqty.Text) & ")"
			cnnDB.Execute(sql)
			System.Windows.Forms.Application.DoEvents()
			
			Do While rs.EOF = False
				sql = "INSERT INTO HandheldMakeFinish (HandHeldID,Handheld_Barcode,Quantity) VALUES (" & rs.Fields("RecipeStockitemLnk_StockitemID").Value & ", 0, " & (0 - (rs.Fields("RecipeStockitemLnk_Quantity").Value * CDec(txtqty.Text))) & ")"
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
		
		For x = 1 To 5
			rs = getRS("SELECT RecipeStockitemLnk.RecipeStockitemLnk_RecipeID FROM HandheldMakeFinish INNER JOIN RecipeStockitemLnk ON HandheldMakeFinish.HandHeldID = RecipeStockitemLnk.RecipeStockitemLnk_RecipeID Where (((HandheldMakeFinish.quantity) < 0)) GROUP BY RecipeStockitemLnk.RecipeStockitemLnk_RecipeID;")
			If rs.RecordCount > 0 Then
				arrBOMMaster = ""
				Do While rs.EOF = False
					rWHs = getRS("SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS Warehouse_StockItemQuantity, Sum(HandheldMakeFinish.Quantity) AS SumOfQuantity FROM WarehouseStockItemLnk INNER JOIN HandheldMakeFinish ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = HandheldMakeFinish.HandHeldID Where (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) = 2)) GROUP BY WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID HAVING (((WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID)=" & rs.Fields("RecipeStockitemLnk_RecipeID").Value & "));")
					If rWHs.Fields("Warehouse_StockItemQuantity").Value > 0 Then
						If rWHs.Fields("Warehouse_StockItemQuantity").Value >= (0 - rWHs.Fields("SumOfQuantity").Value) Then
							sql = "UPDATE HandheldMakeFinish SET Handheld_Barcode=" & rWHs.Fields("SumOfQuantity").Value & ", Quantity=0 WHERE HandHeldID = " & rs.Fields("RecipeStockitemLnk_RecipeID").Value & ";"
							cnnDB.Execute(sql)
							System.Windows.Forms.Application.DoEvents()
						Else
							sql = "UPDATE HandheldMakeFinish SET Handheld_Barcode=" & (0 - rWHs.Fields("Warehouse_StockItemQuantity").Value) & ", Quantity=" & (rWHs.Fields("Warehouse_StockItemQuantity").Value + rWHs.Fields("SumOfQuantity").Value) & " WHERE HandHeldID = " & rs.Fields("RecipeStockitemLnk_RecipeID").Value & ";"
							cnnDB.Execute(sql)
							System.Windows.Forms.Application.DoEvents()
							arrBOMMaster = arrBOMMaster & rs.Fields("RecipeStockitemLnk_RecipeID").Value & ","
						End If
					Else
						arrBOMMaster = arrBOMMaster & rs.Fields("RecipeStockitemLnk_RecipeID").Value & ","
					End If
					rs.moveNext()
				Loop 
				If arrBOMMaster <> "" Then arrBOMMaster = VB.Left(arrBOMMaster, Len(arrBOMMaster) - 1)
			End If
			
			rs = getRS("SELECT RecipeStockitemLnk.*, HandheldMakeFinish.Quantity FROM HandheldMakeFinish INNER JOIN RecipeStockitemLnk ON HandheldMakeFinish.HandHeldID = RecipeStockitemLnk.RecipeStockitemLnk_RecipeID WHERE (((HandheldMakeFinish.Quantity)<0));")
			If rs.RecordCount > 0 Then
				Do While rs.EOF = False
					sql = "INSERT INTO HandheldMakeFinish (HandHeldID,Handheld_Barcode,Quantity) VALUES (" & rs.Fields("RecipeStockitemLnk_StockitemID").Value & ", 0, " & ((rs.Fields("RecipeStockitemLnk_Quantity").Value * rs.Fields("Quantity").Value)) & ")"
					cnnDB.Execute(sql)
					rs.moveNext()
				Loop 
				
				arrBOMDetail = Split(arrBOMMaster, ",")
				For y = 0 To UBound(arrBOMDetail)
					sql = "UPDATE HandheldMakeFinish SET Quantity=0 WHERE HandHeldID = " & CInt(arrBOMDetail(y)) & ";"
					cnnDB.Execute(sql)
					System.Windows.Forms.Application.DoEvents()
				Next 
			End If
		Next 
		sql = "UPDATE HandheldMakeFinish SET Quantity=Handheld_Barcode WHERE Handheld_Barcode<>0;"
		cnnDB.Execute(sql)
		System.Windows.Forms.Application.DoEvents()
		sql = "UPDATE HandheldMakeFinish SET Handheld_Barcode=0 WHERE Handheld_Barcode<>0;"
		cnnDB.Execute(sql)
		System.Windows.Forms.Application.DoEvents()
		
		'chkDuplicate:
		strFldName = "HandHeldID Number,Handheld_Barcode Currency, Quantity Currency"
		cnnDB.Execute("CREATE TABLE " & "Handheld777" & " (" & strFldName & ")")
		System.Windows.Forms.Application.DoEvents()
		
		rj = getRS("SELECT * FROM HandheldMakeFinish;")
		Do While rj.EOF = False
			
			If IsDbNull(rj.Fields("HandHeldID").Value) Then
			Else
				rs = getRS("SELECT * FROM Handheld777 WHERE HandHeldID=" & rj.Fields("HandHeldID").Value & ";")
				If rs.RecordCount > 0 Then
					strIn = "UPDATE Handheld777 SET Quantity = " & (rs.Fields("Quantity").Value + rj.Fields("Quantity").Value) & " WHERE HandHeldID=" & rj.Fields("HandHeldID").Value & ";"
				Else
					strIn = "INSERT INTO Handheld777 (HandHeldID,Handheld_Barcode,Quantity) VALUES (" & rj.Fields("HandHeldID").Value & ", 0, " & rj.Fields("Quantity").Value & ")"
				End If
				cnnDB.Execute(strIn)
			End If
			rj.moveNext()
		Loop 
		
		cnnDB.Execute("DELETE * FROM HandheldMakeFinish;")
		cnnDB.Execute("INSERT INTO HandheldMakeFinish SELECT * FROM Handheld777;")
		cnnDB.Execute("DROP TABLE Handheld777;")
		'chkDuplicate:
		
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
		
		cnnDB.Execute("UPDATE StockItem SET StockItem.StockItem_MakeFinishItem = 1 WHERE StockItemID=" & gStockItemID & ";")
		cnnDB.Execute("DROP TABLE HandheldMakeFinish")
		cnnDB.Execute("DELETE * FROM StockGroup WHERE StockGroup_Name ='HandheldMakeFinish'")
		MsgBox("Make Finished Product process has been completed.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
		
		
		update_Renamed = True
		
		Exit Function
UpdateErr: 
		MsgBox(Err.Description)
		update_Renamed = True
		Resume Next
	End Function
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		cmdClose.Focus()
		System.Windows.Forms.Application.DoEvents()
		
		If CDec(txtqty.Text) > 0 Then
		Else
			txtqty.Focus()
			Exit Sub
		End If
		
		If update_Renamed() Then
			Me.Close()
		End If
	End Sub
	
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
	
	Private Sub txtPriceS_MyGotFocus()
		Dim txtPriceS As Object
        MyGotFocusNumeric(txtPriceS)
	End Sub
	
	Private Sub txtPriceS_MyLostFocus()
		Dim txtPriceS As Object
        MyLostFocus(txtPriceS, 2)
	End Sub
	
	Private Sub txtQty_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case KeyAscii
			Case Asc(vbCr)
				KeyAscii = 0
			Case 8
			Case 48 To 57
				
		End Select
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtQty_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQty.Enter
		'MyGotFocusNumeric txtQty
		txtqty.SelectionStart = 0
		txtqty.SelectionLength = Len(txtqty.Text)
	End Sub
	
	Private Sub txtQty_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQty.Leave
		' LostFocus txtQty, 2
	End Sub
End Class