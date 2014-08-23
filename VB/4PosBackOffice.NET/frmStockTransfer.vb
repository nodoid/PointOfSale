Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmStockTransfer
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
		'If rsLang.RecordCount Then lblPComp.Caption = rsLang("LanguageLayoutLnk_Description"): lblPComp.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1139 'Promotion Name|Checked
		'If rsLang.RecordCount Then lblSComp.Caption = rsLang("LanguageLayoutLnk_Description"): lblSComp.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1147 'Add|Checked
		If rsLang.RecordCount Then cmdAdd.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdAdd.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1148 'Delete|Checked
		If rsLang.RecordCount Then cmdDelete.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdDelete.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'cmdSelComp = No Code   [Select Company to Transfer]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdSelComp.Caption = rsLang("LanguageLayoutLnk_Description"): cmdSelComp.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmStockTransfer.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub buildDataControls()
		'    doDataControl Me.cmbChannel, "SELECT ChannelID, Channel_Name FROM Channel ORDER BY ChannelID", "Customer_ChannelID", "ChannelID", "Channel_Name"
	End Sub
	
    Private Sub doDataControl(ByRef dataControl As myDataGridView, ByRef sql As String, ByRef DataField As String, ByRef boundColumn As String, ByRef listField As String)
        'Dim rs As ADODB.Recordset
        'rs = getRS(sql)
        'dataControl.DataSource = rs
        'dataControl.DataSource = adoPrimaryRS
        ' dataControl.DataField = DataField
        ' dataControl.boundColumn = boundColumn
        ' dataControl.listField = listField
    End Sub
	
	Public Sub loadItem(ByRef id As Integer)
        Dim oText As New System.Windows.Forms.TextBox
        Dim oDate As New DateTimePicker
        Dim oCheck As New System.Windows.Forms.CheckBox
		
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
			'cnnDB.Execute "INSERT INTO PromotionItem ( PromotionItem_PromotionID, PromotionItem_StockItemID, PromotionItem_Quantity, PromotionItem_Price ) SELECT " & adoPrimaryRS("PromotionID") & " AS [Set], CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, 1,CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)=" & lID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)=1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));"
			frmStockTransferItem.loadItem(lID) 'adoPrimaryRS("PromotionID"), lID
			loadItems(lID)
		End If
	End Sub
	Private Sub cmdDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDelete.Click
		Dim lID As Integer
		If lvStockT.FocusedItem Is Nothing Then
		Else
			If MsgBox("Are you sure you wish to remove  '" & lvStockT.FocusedItem.Text & "'  from this Transfer?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "DELETE") = MsgBoxResult.Yes Then
				lID = CInt(Split(lvStockT.FocusedItem.Name, "_")(0))
				cnnDB.Execute("DELETE StockTransferGRV.* From StockTransferGRV WHERE StockTransferGRV.StockTransfer_StockItemID=" & lID & " AND StockTransferGRV.StockTransfer_Quantity=" & Split(lvStockT.FocusedItem.Name, "_")(1) & ";")
				loadItems()
			End If
		End If
		
	End Sub
	
	Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
		'update
		'report_Promotion
	End Sub
	
	
	Private Sub cmdSelComp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSelComp.Click
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
				lblSComp.Text = rj.Fields("Company_Name").Value
				
				cmdAdd.Enabled = True
				cmdDelete.Enabled = True
			End If
			
		End If
	End Sub
	
	Private Sub cmdTransfer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdTransfer.Click
        Dim grvNo As Integer
        Dim sql As String
		Dim rsID As ADODB.Recordset
		Dim rs As ADODB.Recordset
		Dim x As Short
		Dim cn As ADODB.Connection
		Dim rsChk As ADODB.Recordset
		Dim errPosition As String
		
		On Error GoTo ErrTransfer
		errPosition = "Start"
		
		If lvStockT.Items.Count > 0 Then
			errPosition = "1"
			sql = "INSERT INTO PurchaseOrder ( PurchaseOrder_SupplierID, PurchaseOrder_DayEndID, PurchaseOrder_PersonID, PurchaseOrder_DateCreated, PurchaseOrder_PurchaseOrderStatusID, PurchaseOrder_Reference, PurchaseOrder_AttentionLine ) "
			sql = sql & "SELECT 2, Company.Company_DayEndID, " & gPersonID & ", Now(), 1, '" & Format(Now, "yyyy mmm dd") & " (Blind)', '' FROM Company;"
			cnnDB.Execute(sql,  , ADODB.ExecuteOptionEnum.adExecuteNoRecords)
			
			errPosition = "2"
			rsID = getRS("SELECT Max(PurchaseOrder.PurchaseOrderID) AS id FROM PurchaseOrder;")
			grvNo = "Trsnfr#-" & rsID.Fields("id").Value
			sql = "INSERT INTO GRV ( GRV_PurchaseOrderID, GRV_DayEndID, GRV_GRVStatusID, GRV_Date, GRV_InvoiceDate, GRV_InvoiceNumber, GRV_InvoiceInclusive, GRV_InvoiceVat, GRV_InvoiceDiscount, GRV_Ullage, GRV_SundriesPlus, GRV_SundriesMinus, GRV_Terms ) SELECT " & rsID.Fields("id").Value & ", Company.Company_DayEndID, 1 AS status, Now(), Now(), 'Trsnfr#-" & rsID.Fields("id").Value & "', 0, 0, 0, 0, 0, 0, 1 FROM Company;"
			cnnDB.Execute(sql, , ADODB.ExecuteOptionEnum.adExecuteNoRecords)
			If rsID.State Then rsID.Close()
			rsID = getRS("SELECT Max(GRV.GRVID) AS id FROM GRV;")
			
			x = 1
			rs = getRS("SELECT StockItem.StockItem_Name, StockTransferGRV.* FROM StockTransferGRV INNER JOIN StockItem ON StockTransferGRV.StockTransfer_StockItemID = StockItem.StockItemID ORDER BY StockItem.StockItem_Name, StockTransferGRV.StockTransfer_Quantity;")
			Do Until rs.EOF
				errPosition = "3"
				rsChk = getRS("SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & rs.Fields("StockTransfer_StockItemID").Value & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
				If rsChk.RecordCount Then
					
					errPosition = "4"
					'changed again 04-oct- sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID("id") & " AS grvid, StockItem.StockItemID, 1 AS return, StockItem.StockItem_Name, '' AS code, StockItem.StockItem_Quantity, 1, " & rs("StockTransfer_Quantity") & " AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
					sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID.Fields("id").Value & " AS grvid, StockItem.StockItemID, 1 AS return, StockItem.StockItem_Name, '' AS code, 1, 1, " & rs.Fields("StockTransfer_Quantity").Value & " AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
					sql = sql & " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & rs.Fields("StockTransfer_StockItemID").Value & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));"
					Debug.Print(sql)
					cnnDB.Execute(sql)
					
					'update selling price
					sql = "UPDATE GRVItem INNER JOIN PriceChannelLnk ON PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID SET GRVItem.GRVItem_Price = PriceChannelLnk.PriceChannelLnk_Price WHERE ((PriceChannelLnk.PriceChannelLnk_Quantity=1) AND (PriceChannelLnk.PriceChannelLnk_ChannelID=1) AND (GRVItem.GRVItem_GRVID)=" & rsID.Fields("id").Value & " AND GRVItem.GRVItem_Line =" & x & ");"
					cnnDB.Execute(sql)
				Else
					
					errPosition = "5"
					If rs.Fields("StockTransfer_Pack").Value = 1 Then
						'changed Packsize to SuppQty as Markus said it should always xfer singles(11-may-11 naresh)
						sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID.Fields("id").Value & " AS grvid, StockItem.StockItemID, 1 AS return, StockItem.StockItem_Name, '' AS code, 1, 1, " & rs.Fields("StockTransfer_Quantity").Value & " AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
						sql = sql & " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & rs.Fields("StockTransfer_StockItemID").Value & ") AND ((Catalogue.Catalogue_Quantity)=1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));"
					Else
						'changed Packsize to SuppQty as Markus said it should always xfer singles(11-may-11 naresh)
						sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID.Fields("id").Value & " AS grvid, StockItem.StockItemID, 1 AS return, StockItem.StockItem_Name, '' AS code, 1, 1, " & rs.Fields("StockTransfer_Quantity").Value & " AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
						sql = sql & " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & rs.Fields("StockTransfer_StockItemID").Value & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));"
					End If
					Debug.Print(sql)
					cnnDB.Execute(sql)
					
					'update selling price
					sql = "UPDATE GRVItem INNER JOIN PriceChannelLnk ON PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID SET GRVItem.GRVItem_Price = PriceChannelLnk.PriceChannelLnk_Price WHERE ((PriceChannelLnk.PriceChannelLnk_Quantity=1) AND (PriceChannelLnk.PriceChannelLnk_ChannelID=1) AND (GRVItem.GRVItem_GRVID)=" & rsID.Fields("id").Value & " AND GRVItem.GRVItem_Line =" & x & ");"
					cnnDB.Execute(sql)
				End If
				
				x = x + 1
				rs.moveNext()
			Loop 
			
			
			If loadDBStr = "" Then
			Else
				cn = openSComp(loadDBStr)
				errPosition = "6"
				If cn Is Nothing Then
				Else
					
					errPosition = "7"
					sql = "INSERT INTO PurchaseOrder ( PurchaseOrder_SupplierID, PurchaseOrder_DayEndID, PurchaseOrder_PersonID, PurchaseOrder_DateCreated, PurchaseOrder_PurchaseOrderStatusID, PurchaseOrder_Reference, PurchaseOrder_AttentionLine ) "
					sql = sql & "SELECT 2, Company.Company_DayEndID, " & gPersonID & ", Now(), 1, '" & Format(Now, "yyyy mmm dd") & " (Blind)', '' FROM Company;"
					cn.Execute(sql,  , ADODB.ExecuteOptionEnum.adExecuteNoRecords)
					
					errPosition = "8"
					rsID = getRSwaitron("SELECT Max(PurchaseOrder.PurchaseOrderID) AS id FROM PurchaseOrder;", cn)
					sql = "INSERT INTO GRV ( GRV_PurchaseOrderID, GRV_DayEndID, GRV_GRVStatusID, GRV_Date, GRV_InvoiceDate, GRV_InvoiceNumber, GRV_InvoiceInclusive, GRV_InvoiceVat, GRV_InvoiceDiscount, GRV_Ullage, GRV_SundriesPlus, GRV_SundriesMinus, GRV_Terms ) SELECT " & rsID.Fields("id").Value & ", Company.Company_DayEndID, 1 AS status, Now(), Now(), 'Trsnfr#-" & rsID.Fields("id").Value & "', 0, 0, 0, 0, 0, 0, 1 FROM Company;"
					cn.Execute(sql,  , ADODB.ExecuteOptionEnum.adExecuteNoRecords)
					
					If rsID.State Then rsID.Close()
					rsID = getRSwaitron("SELECT Max(GRV.GRVID) AS id FROM GRV;", cn)
					
					x = 1
					rs = getRS("SELECT StockItem.StockItem_Name, StockTransferGRV.* FROM StockTransferGRV INNER JOIN StockItem ON StockTransferGRV.StockTransfer_StockItemID = StockItem.StockItemID ORDER BY StockItem.StockItem_Name, StockTransferGRV.StockTransfer_Quantity;")
					Do Until rs.EOF
						
						errPosition = "9"
						'Set rsChk = getRS("SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & rs("StockTransfer_StockItemID") & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
						rsChk = getRSwaitron("SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & rs.Fields("StockTransfer_StockItemID").Value & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));", cn)
						If rsChk.RecordCount Then
							
							errPosition = "10"
							'list cost will also change 04-oct      sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID("id") & " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, 1, 1, " & rs("StockTransfer_Quantity") & " AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
							sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID.Fields("id").Value & " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, 1, 1, " & rs.Fields("StockTransfer_Quantity").Value & " AS quantity, " & rs.Fields("StockTransfer_Price").Value & " AS ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
							sql = sql & " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & rs.Fields("StockTransfer_StockItemID").Value & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));"
							cn.Execute(sql)
							
							'update selling price
							sql = "UPDATE GRVItem INNER JOIN PriceChannelLnk ON PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID SET GRVItem.GRVItem_Price = PriceChannelLnk.PriceChannelLnk_Price WHERE ((PriceChannelLnk.PriceChannelLnk_Quantity=1) AND (PriceChannelLnk.PriceChannelLnk_ChannelID=1) AND (GRVItem.GRVItem_GRVID)=" & rsID.Fields("id").Value & " AND GRVItem.GRVItem_Line =" & x & ");"
							cn.Execute(sql)
						Else
							
							errPosition = "11"
							If rs.Fields("StockTransfer_Pack").Value = 1 Then
								'changed Packsize to SuppQty as Markus said it should always xfer singles(11-may-11 naresh)
								'changed again 04-oct- sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID("id") & " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, StockItem.StockItem_Quantity, 1, " & rs("StockTransfer_Quantity") & " AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
								sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID.Fields("id").Value & " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, 1, 1, " & rs.Fields("StockTransfer_Quantity").Value & " AS quantity, " & rs.Fields("StockTransfer_Price").Value & " AS ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
								sql = sql & " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & rs.Fields("StockTransfer_StockItemID").Value & ") AND ((Catalogue.Catalogue_Quantity)=1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));"
							Else
								'changed Packsize to SuppQty as Markus said it should always xfer singles(11-may-11 naresh)
								'changed again 04-oct- sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID("id") & " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, StockItem.StockItem_Quantity, 1, " & rs("StockTransfer_Quantity") & " AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
								sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID.Fields("id").Value & " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, 1, 1, " & rs.Fields("StockTransfer_Quantity").Value & " AS quantity, " & rs.Fields("StockTransfer_Price").Value & " AS ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
								sql = sql & " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & rs.Fields("StockTransfer_StockItemID").Value & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));"
							End If
							Debug.Print(sql)
							cn.Execute(sql)
							
							'update selling price
							sql = "UPDATE GRVItem INNER JOIN PriceChannelLnk ON PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID SET GRVItem.GRVItem_Price = PriceChannelLnk.PriceChannelLnk_Price WHERE ((PriceChannelLnk.PriceChannelLnk_Quantity=1) AND (PriceChannelLnk.PriceChannelLnk_ChannelID=1) AND (GRVItem.GRVItem_GRVID)=" & rsID.Fields("id").Value & " AND GRVItem.GRVItem_Line =" & x & ");"
							cn.Execute(sql)
							'sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID("id") & " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, 1, 1, " & rs("StockTransfer_Quantity") & " AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
							'sql = sql & " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & rs("StockTransfer_StockItemID") & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));"
							'cn.Execute sql
						End If
						Debug.Print(sql)
						x = x + 1
						rs.moveNext()
					Loop 
					
				End If
				
			End If
			
			MsgBox("GRV on both Locations has been created with InvoiceNumber " & grvNo & ". Please process ASAP.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly + MsgBoxStyle.DefaultButton2, "Completed")
			Me.Close()
		Else
		End If
		
		Exit Sub
ErrTransfer: 
		MsgBox("Error at position no. " & errPosition & " Err Number " & Err.Number & " " & Err.Description)
		Resume Next
	End Sub
	
	Private Sub frmStockTransfer_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		lvStockT.Columns.Clear()
        lvStockT.Columns.Add("", "Stock Item", CInt(twipsToPixels(4050, True)))
        lvStockT.Columns.Add("QTY", CInt(twipsToPixels(800, True)), System.Windows.Forms.HorizontalAlignment.Right)
        lvStockT.Columns.Add("Price", CInt(twipsToPixels(1440, True)), System.Windows.Forms.HorizontalAlignment.Right)
		
		Dim rj As ADODB.Recordset
		rj = getRS("SELECT Company_Name FROM Company;")
		lblPComp.Text = rj.Fields("Company_Name").Value
		
		lblSComp.Text = "Select Company to Transfer"
		cmdAdd.Enabled = False
		cmdDelete.Enabled = False
		'cmdTransfer.Enabled = False
		loadLanguage()
		
		cnnDB.Execute("DELETE * from StockTransferGRV;")
	End Sub
	
	Private Sub loadItems(Optional ByRef lID As Integer = 0, Optional ByRef quantity As Short = 0)
		Dim listItem As System.Windows.Forms.ListViewItem
		Dim rs As ADODB.Recordset
		lvStockT.Items.Clear()
		rs = getRS("SELECT StockItem.StockItem_Name, StockTransferGRV.* FROM StockTransferGRV INNER JOIN StockItem ON StockTransferGRV.StockTransfer_StockItemID = StockItem.StockItemID ORDER BY StockItem.StockItem_Name, StockTransferGRV.StockTransfer_Quantity;")
		Do Until rs.EOF
			
			listItem = lvStockT.Items.Add(rs.Fields("StockTransfer_StockItemID").Value & "_" & rs.Fields("StockTransfer_Quantity").Value, rs.Fields("Stockitem_Name").Value, "")
			'UPGRADE_WARNING: Lower bound of collection listItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If listItem.SubItems.Count > 1 Then
				listItem.SubItems(1).Text = rs.Fields("StockTransfer_Quantity").Value
			Else
				listItem.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("StockTransfer_Quantity").Value))
			End If
			'UPGRADE_WARNING: Lower bound of collection listItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If listItem.SubItems.Count > 2 Then
				listItem.SubItems(2).Text = FormatNumber(rs.Fields("StockTransfer_Price").Value, 2)
			Else
				listItem.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("StockTransfer_Price").Value, 2)))
			End If
			If rs.Fields("StockTransfer_StockItemID").Value = lID And rs.Fields("StockTransfer_Quantity").Value = quantity Then listItem.Selected = True
			rs.moveNext()
		Loop 
	End Sub
	
	'UPGRADE_WARNING: Event frmStockTransfer.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmStockTransfer_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        Dim cmdLast As New Button
        Dim cmdNext As New Button
        Dim lblStatus As New Label
		On Error Resume Next
		lblStatus.Width = pixelToTwips(Me.Width, True) - 1500
		cmdNext.Left = lblStatus.Width + 700
		cmdLast.Left = cmdNext.Left + 340
	End Sub
	
	Private Sub frmStockTransfer_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub frmStockTransfer_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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
			
			frmStockTransferItem.loadItem(lID, CShort(lQty))
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