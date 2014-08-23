Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmGRV
	Inherits System.Windows.Forms.Form
	Public WithEvents adoPrimaryRS As ADODB.Recordset
	Dim gFilter As String
	Dim gRS As ADODB.Recordset
	Dim gFilterSQL As String
	Dim gID As Integer
    Dim bIsVoucher As Boolean
    Dim lblLabels As New List(Of Label)
    Dim lblData As New List(Of Label)
	Private Sub loadLanguage()
		
		'NOTE: Form Caption has a Spelling Mistake!
		'frmGRV = No Code       [Process a 'Goods Receiving Voucher']
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmGRV.Caption = rsLang("LanguageLayoutLnk_Description"): frmGRV.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1559 'Select a Supplier to Transact with|Checked
        If rsLang.RecordCount Then _frmMode_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _frmMode_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1432 'Supplier Details|Checked
		If rsLang.RecordCount Then _lbl_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1442 'Supplier Name|Checked
		If rsLang.RecordCount Then _lblLabels_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1288 'Telephone|Checked
		If rsLang.RecordCount Then _lblLabels_8.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_8.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1289 'Fax|Checked
		If rsLang.RecordCount Then _lblLabels_9.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_9.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1457 'Account Number|Checked
		If rsLang.RecordCount Then lblLabels(36).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lblLabels(36).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1609 'Order Reference|Checked
		If rsLang.RecordCount Then _lblLabels_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1459 'GRV Template|Checked
		If rsLang.RecordCount Then _lbl_4.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_4.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1650 'Invoice Details|Checked
		If rsLang.RecordCount Then _lbl_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'cmdNewGT = No Code     [Create New GRV Template]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdNewGT.Caption = rsLang("LanguageLayoutLnk_Description"): cmdNewGT.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1651 'Number| Checked
		If rsLang.RecordCount Then _lbl_5.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_5.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1652 'Total| Checked
		If rsLang.RecordCount Then _lbl_6.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_6.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1426 'Date|Checked
		If rsLang.RecordCount Then _lbl_7.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_7.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1654 'Load GRV|Checked
		If rsLang.RecordCount Then cmdLoad.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdLoad.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdBack.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdBack.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1005 'Next|Checked
		If rsLang.RecordCount Then cmdNext.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdNext.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmGRV.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Sub Create(ByRef purchaseOrder As Integer, Optional ByRef import As Boolean = False, Optional ByRef isVoucher As Boolean = False)
        Dim sql As String
		
		On Error GoTo Error_Create
		
		gID = purchaseOrder
		bIsVoucher = isVoucher
		
		Dim oLabel As System.Windows.Forms.Label
		Dim x As Short
		Dim rs As ADODB.Recordset
		Dim rs1 As ADODB.Recordset
		
		rs = getRS("SELECT GRV.GRV_PurchaseOrderID, GRV.GRV_GRVStatusID From GRV WHERE (((GRV.GRV_PurchaseOrderID)=" & gID & ") AND ((GRV.GRV_GRVStatusID)=1));")
		If rs.BOF Or rs.EOF Then
			rs.Close()
			cnnDB.Execute("INSERT INTO GRV ( GRV_PurchaseOrderID, GRV_DayEndID, GRV_GRVStatusID, GRV_Date, GRV_InvoiceDate, GRV_InvoiceNumber, GRV_InvoiceInclusive, GRV_InvoiceVat, GRV_InvoiceDiscount, GRV_Ullage, GRV_SundriesPlus, GRV_SundriesMinus, GRV_Terms ) SELECT " & gID & ", Company.Company_DayEndID, 1 AS status, Now(), Now(), '', 0, 0, 0, 0, 0, 0, 1 FROM Company;")
			cnnDB.Execute("INSERT INTO GRVItem ( GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date ) SELECT GRV.GRVID, PurchaseOrderItem.PurchaseOrderItem_StockItemID, 0 AS return, PurchaseOrderItem.PurchaseOrderItem_PackSize, PurchaseOrderItem.PurchaseOrderItem_Quantity, PurchaseOrderItem.PurchaseOrderItem_Quantity, PurchaseOrderItem.PurchaseOrderItem_ContentCost, 0, 0, 0, Now() FROM PurchaseOrderItem INNER JOIN (GRV INNER JOIN PurchaseOrder ON GRV.GRV_PurchaseOrderID = PurchaseOrder.PurchaseOrderID) ON PurchaseOrderItem.PurchaseOrderItem_PurchaseOrderID = PurchaseOrder.PurchaseOrderID WHERE (((PurchaseOrder.PurchaseOrderID)=" & gID & ") AND ((GRV.GRV_GRVStatusID)=1));")
			
			cnnDB.Execute("UPDATE GRV INNER JOIN (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) ON GRV.GRVID = GRVItem.GRVItem_GRVID SET GRVItem.GRVItem_Name = [StockItem]![StockItem_Name], GRVItem.GRVItem_Code = '' WHERE ((([GRV].[GRV_PurchaseOrderID])=" & gID & ") AND (([GRV].[GRV_GRVStatusID])=1));")
			cnnDB.Execute("UPDATE (CatalogueChannelLnk INNER JOIN ((GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) ON (GRVItem.GRVItem_PackSize = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = StockItem.StockItemID)) INNER JOIN GRV ON GRVItem.GRVItem_GRVID = GRV.GRVID SET GRVItem.GRVItem_VatRate = [Vat_Amount], GRVItem.GRVItem_Price = [CatalogueChannelLnk_PriceSystem] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((GRV.GRV_PurchaseOrderID)=" & gID & "));")
			'cnnDB.Execute "UPDATE (CatalogueChannelLnk INNER JOIN ((GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) ON (GRVItem.GRVItem_PackSize = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = StockItem.StockItemID)) INNER JOIN GRV ON GRVItem.GRVItem_GRVID = GRV.GRVID SET GRVItem.GRVItem_VatRate = Vat.Vat_Amount, GRVItem.GRVItem_Price = CatalogueChannelLnk.CatalogueChannelLnk_PriceSystem WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((GRV.GRV_PurchaseOrderID)=" & gID & "));"
			
			'Set rs1 = getRS("SELECT Vat.Vat_Amount FROM GRV INNER JOIN (GRVItem INNER JOIN (StockItem INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) ON GRV.GRVID = GRVItem.GRVItem_GRVID WHERE (((GRV.GRV_PurchaseOrderID)=" & gID & "));")
			'If rs1.RecordCount > 0 Then
			'    cnnDB.Execute "UPDATE GRV INNER JOIN GRVItem ON GRV.GRVID = GRVItem.GRVItem_GRVID SET GRVItem.GRVItem_VatRate = " & rs1("Vat_Amount") & " WHERE (((GRV.GRV_PurchaseOrderID)=" & gID & "));"
			'End If
			'rs1.Close
			'changed above with below
			cnnDB.Execute("UPDATE ((GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) INNER JOIN GRV ON GRVItem.GRVItem_GRVID = GRV.GRVID SET GRVItem.GRVItem_VatRate = [Vat_Amount] WHERE (((GRV.GRV_PurchaseOrderID)=" & gID & "));")
			
			'cnnDB.Execute "UPDATE (PriceChannelLnk INNER JOIN ((GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) ON (GRVItem.GRVItem_PackSize = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = StockItem.StockItemID)) INNER JOIN GRV ON GRVItem.GRVItem_GRVID = GRV.GRVID SET GRVItem.GRVItem_VatRate = [Vat_Amount], GRVItem.GRVItem_Price = [CatalogueChannelLnk_PriceSystem] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((GRV.GRV_PurchaseOrderID)=" & gID & "));"
			
			'update selling price
			sql = "UPDATE (GRVItem INNER JOIN GRV ON GRVItem.GRVItem_GRVID = GRV.GRVID) INNER JOIN PriceChannelLnk ON GRVItem.GRVItem_StockItemID = PriceChannelLnk.PriceChannelLnk_StockItemID SET GRVItem.GRVItem_Price = PriceChannelLnk.PriceChannelLnk_Price WHERE (((PriceChannelLnk.PriceChannelLnk_Quantity)=1) AND ((PriceChannelLnk.PriceChannelLnk_ChannelID)=1) AND ((GRV.GRV_PurchaseOrderID)=" & gID & "));"
			'sql = "UPDATE GRVItem INNER JOIN PriceChannelLnk ON PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID SET GRVItem.GRVItem_Price = PriceChannelLnk.PriceChannelLnk_Price WHERE ((PriceChannelLnk.PriceChannelLnk_Quantity=1) AND (PriceChannelLnk.PriceChannelLnk_ChannelID=1) AND (GRVItem.GRVItem_GRVID)=" & gID & ");"
			cnnDB.Execute(sql)
			
		Else
			rs.Close()
		End If
		
		adoPrimaryRS = getRS("SELECT Supplier.*, PurchaseOrder.*, GRV.* FROM GRV INNER JOIN (PurchaseOrder INNER JOIN Supplier ON PurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) ON GRV.GRV_PurchaseOrderID = PurchaseOrder.PurchaseOrderID WHERE (((PurchaseOrder.PurchaseOrderID)=" & gID & ") AND ((GRV.GRV_GRVStatusID)=1));")
		If import Then
			sql = "INSERT INTO GRVItem ( GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_Quantity, GRVItem_QuantityOrder, GRVItem_ContentCost, GRVItem_DepositCost, GRVItem_DiscountAmount ) "
			sql = sql & "SELECT " & adoPrimaryRS.Fields("GRVID").Value & ", StockItem.StockItemID, 0, StockItem.StockItem_Name, StockItem.StockItem_SupplierCode, StockItem.StockItem_Quantity, Sum(GRVimport.GRVimport_Quantity) AS SumOfGRVimport_Quantity, 0, Last(GRVimport.GRVimport_Cost) AS LastOfGRVimport_Cost, [Deposit_UnitCost]*[Deposit_Quantity]+[Deposit_CaseCost], 0 FROM ((Catalogue INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID) INNER JOIN GRVimport ON Catalogue.Catalogue_Barcode = GRVimport.GRVimport_Barcode) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID GROUP BY " & adoPrimaryRS.Fields("GRVID").Value & ", StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_SupplierCode, StockItem.StockItem_Quantity, [Deposit_UnitCost]*[Deposit_Quantity]+[Deposit_CaseCost];"
			
			sql = "INSERT INTO GRVItem ( GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_Quantity, GRVItem_QuantityOrder, GRVItem_ContentCost, GRVItem_DepositCost, GRVItem_DiscountAmount, GRVItem_Line ) "
			sql = sql & "SELECT " & adoPrimaryRS.Fields("GRVID").Value & ", StockItem.StockItemID, 0 AS Expr2, StockItem.StockItem_Name, StockItem.StockItem_SupplierCode, Catalogue.Catalogue_Quantity, Sum(GRVimport.GRVimport_Quantity) AS SumOfGRVimport_Quantity, 0 AS Expr3, Last(GRVimport.GRVimport_Cost) AS LastOfGRVimport_Cost, [Deposit_UnitCost]*[Deposit_Quantity]+[Deposit_CaseCost] AS Expr4, 0 AS Expr5, First(GRVimport.GRVimport_Key) AS FirstOfGRVimport_Key FROM ((Catalogue INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID) INNER JOIN GRVimport ON Catalogue.Catalogue_Barcode = GRVimport.GRVimport_Barcode) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID GROUP BY " & adoPrimaryRS.Fields("GRVID").Value & ", StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_SupplierCode, Catalogue.Catalogue_Quantity, [Deposit_UnitCost]*[Deposit_Quantity]+[Deposit_CaseCost];"
			
			'sql = "INSERT INTO GRVItem ( GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_Quantity, GRVItem_QuantityOrder, GRVItem_ContentCost, GRVItem_DepositCost, GRVItem_DiscountAmount, GRVItem_Line, GRVItem_Price ) "
			'sql = sql & "SELECT " & adoPrimaryRS("GRVID") & ", StockItem.StockItemID, 0 AS Expr2, StockItem.StockItem_Name, StockItem.StockItem_SupplierCode, Catalogue.Catalogue_Quantity, Sum(GRVimport.GRVimport_Quantity) AS SumOfGRVimport_Quantity, 0 AS Expr3, Last(GRVimport.GRVimport_Cost) AS LastOfGRVimport_Cost, [Deposit_UnitCost]*[Deposit_Quantity]+[Deposit_CaseCost] AS Expr4, 0 AS Expr5, Last(GRVimport.GRVimport_Key) AS LastOfGRVimport_Key, StockItem_ActualCost FROM ((Catalogue INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID) INNER JOIN GRVimport ON Catalogue.Catalogue_Barcode = GRVimport.GRVimport_Barcode) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID GROUP BY StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_SupplierCode, Catalogue.Catalogue_Quantity, [Deposit_UnitCost]*[Deposit_Quantity]+[Deposit_CaseCost];"
			
			x = 1
			
			rs = getRS("SELECT * FROM GRVitem ORDER BY GRVitem_Line")
			
			cnnDB.Execute(sql)
			
			Do Until rs.EOF
				rs.Fields("GRVitem_Line").Value = x
				rs.update()
				x = x + 1
				rs.moveNext()
			Loop 
		End If
        Dim bind As New BindingSource
        bind.DataSource = adoPrimaryRS
        For Each oLabel In lblData
            oLabel.DataBindings.Add(bind.DataSource)
        Next(oLabel)
		txtInvoiceNo.DataBindings.Add(bind.DataSource)
        txtInvoiceTotal.DataBindings.Add(bind.DataSource)
        txtInvoiceTotal.Text = CStr(CDbl(txtInvoiceTotal.Text) * 100)
		txtInvoiceTotal_Leave(txtInvoiceTotal, New System.EventArgs())
		
		buildDataControls()
		MonthView1.DataBindings.Add(adoPrimaryRS)
		
		cmdBack.Text = "&Back"
		cmdNext.Text = "E&xit"
		If Me.Visible Then txtInvoiceNo.Focus()
		If bolAirTimeGRV = True Then
			tmrAutoGRV.Enabled = True
		End If
		
		If import Then
			sql = "UPDATE ((Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_Quantity = StockItem.StockItem_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)) INNER JOIN GRVItem ON (GRVItem.GRVItem_StockItemID = StockItem.StockItemID) AND (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize) SET GRVItem.GRVItem_StockItemQuantity = [CatalogueChannelLnk_Quantity], GRVItem.GRVItem_Price = [CatalogueChannelLnk_Price] WHERE (((GRVItem.GRVItem_GRVID)=" & adoPrimaryRS.Fields("GRVID").Value & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((StockItem.StockItem_PackSizeID)=[StockItem_Quantity]));"
			cnnDB.Execute(sql)
			
			sql = "UPDATE (StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID SET GRVItem.GRVItem_VatRate = [Vat_Amount] WHERE (((GRVItem.GRVItem_GRVID)=" & adoPrimaryRS.Fields("GRVID").Value & "));"
			cnnDB.Execute(sql)
			
			'update selling price
			sql = "UPDATE GRVItem INNER JOIN PriceChannelLnk ON PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID SET GRVItem.GRVItem_Price = PriceChannelLnk.PriceChannelLnk_Price WHERE ((PriceChannelLnk.PriceChannelLnk_Quantity=1) AND (PriceChannelLnk.PriceChannelLnk_ChannelID=1) AND (GRVItem.GRVItem_GRVID)=" & adoPrimaryRS.Fields("GRVID").Value & ");"
			cnnDB.Execute(sql)
		End If
		
		If sGRVSales <> "" Then
			sGRVSales = "DONE"
		Else
			loadLanguage()
			ShowDialog()
		End If
		
		Exit Sub
Error_Create: 
		Resume Next
	End Sub
	
	Private Sub buildDataControls()
		'    doDataControl Me.cmbChannel, "SELECT ChannelID, Channel_Name FROM Channel ORDER BY ChannelID", "Customer_ChannelID", "ChannelID", "Channel_Name"
		doDataControl((Me.cmbTemplate), "SELECT GRVTemplateID, GRVTemplate_Name FROM GRVTemplate ORDER BY GRVTemplate_Name", "Supplier_GRVtype", "GRVTemplate_Name", "GRVTemplate_Name")
		'doDataControl Me.cmbKeyboard, "SELECT KeyboardLayout.KeyboardLayoutID, KeyboardLayout.KeyboardLayout_Name FROM KeyboardLayout ORDER BY KeyboardLayout_Name", "POS_Keyboard", "KeyboardLayoutID", "KeyboardLayout_Name"
	End Sub
	
    Private Sub doDataControl(ByRef dataControl As myDataGridView, ByRef sql As String, ByRef DataField As String, ByRef boundColumn As String, ByRef listField As String)
        Dim rs As ADODB.Recordset
        rs = getRS(sql)
        Dim bind As New BindingSource
        bind.DataSource = rs
        'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'dataControl.DataSource = rs
        dataControl.DataBindings.Add(bind.DataSource)
        dataControl.DataBindings.Add(adoPrimaryRS)
        dataControl.DataField = DataField
        dataControl.boundColumn = boundColumn
        dataControl.Columns.Add(listField, "")
    End Sub
	
	Private Sub cmdExit_Click()
		bolFNVegGRV = False
		Me.Close()
	End Sub
	
	Private Sub cmdBack_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBack.Click
		bolFNVegGRV = False
		Me.Close()
	End Sub
	
	Private Sub cmdLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLoad.Click
		Dim rs As ADODB.Recordset
		rs = getRS("SELECT GRV.GRV_InvoiceNumber, GRV.GRV_InvoiceDate, GRV.GRV_GRVStatusID FROM (GRV INNER JOIN GRV AS GRV_1 ON GRV.GRV_InvoiceNumber = GRV_1.GRV_InvoiceNumber) INNER JOIN (PurchaseOrder INNER JOIN PurchaseOrder AS PurchaseOrder_1 ON PurchaseOrder.PurchaseOrder_SupplierID = PurchaseOrder_1.PurchaseOrder_SupplierID) ON (GRV.GRV_PurchaseOrderID = PurchaseOrder.PurchaseOrderID) AND (GRV_1.GRV_PurchaseOrderID = PurchaseOrder_1.PurchaseOrderID) WHERE (((GRV.GRV_InvoiceNumber)='" & Me.txtInvoiceNo.Text & "') AND ((GRV.GRVID)<>[GRV_1]![GRVID]) AND ((GRV_1.GRVID)=" & adoPrimaryRS.Fields("GRVID").Value & "));")
		If rs.RecordCount Then
			If MsgBox("An Invoice Number of '" & rs.Fields("GRV_InvoiceNumber").Value & "' already exist for this supplier!" & vbCrLf & vbCrLf & "Do you wish to continue?", MsgBoxStyle.DefaultButton2 + MsgBoxStyle.YesNo + MsgBoxStyle.Question, "DUPLICATE INVOICE NUMBER") = MsgBoxResult.No Then
				Exit Sub
			End If
		End If
		update_Renamed()
		If bolAirTimeGRV = True Then
			cnnDB.Execute("UPDATE GRV SET GRV_InvoiceNumber = '" & VB.Left(Me.txtInvoiceNo.Text, 20) & "' WHERE GRVID=" & adoPrimaryRS.Fields("GRVID").Value & ";")
		End If
		If bolFNVegGRV = True Then
			frmGRVitemFnV.loadItem(0)
		Else
			frmGRVitem.loadItem(0)
		End If
		'    frmGRVitem.Show 1, Me
	End Sub
	
	Private Sub cmdNewGT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNewGT.Click
        Dim form As New frmGRVTemplate
        form.Show()
		buildDataControls()
	End Sub
	
	Private Sub cmdNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNext.Click
		update_Renamed()
		Me.Close()
	End Sub
	
	
	Private Sub frmGRV_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim form As New frmGRVTemplate
		If Shift = 7 And KeyCode = 67 Then
            form.Show()
			KeyCode = 0
		End If
	End Sub
	
	Private Sub frmGRV_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 27 Then
			KeyAscii = 0
			cmdBack_Click(cmdBack, New System.EventArgs())
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub frmGRV_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'    gRS.Close
	End Sub
	
	Private Sub MonthView1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MonthView1.Enter
        MonthView1.BackColor = System.Drawing.ColorTranslator.FromOle(-2147483624)
	End Sub
	
	Private Sub MonthView1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MonthView1.Leave
        MonthView1.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
		
	End Sub
	
	Private Sub tmrAutoGRV_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrAutoGRV.Tick
		If bolAirTimeGRV = True Then
			tmrAutoGRV.Enabled = False
			txtInvoiceNo.Text = Replace(CStr(Now), " ", "")
			txtInvoiceNo.Text = Replace(txtInvoiceNo.Text, "/", "")
			txtInvoiceNo.Text = Replace(txtInvoiceNo.Text, ":", "")
			
			If bIsVoucher Then
				txtInvoiceNo.Text = "4Voucher" & Replace(txtInvoiceNo.Text, ":", "")
			Else
				txtInvoiceNo.Text = "4AIR" & Replace(txtInvoiceNo.Text, ":", "")
			End If
			
			cmdLoad.Focus()
			cmdLoad_Click(cmdLoad, New System.EventArgs())
		End If
	End Sub
	
	Private Sub txtInvoiceNo_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtInvoiceNo.Enter
		txtInvoiceNo.SelectionStart = 0
		txtInvoiceNo.SelectionLength = 999
	End Sub
	
	Private Sub txtInvoiceTotal_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtInvoiceTotal.Enter
        MyGotFocusNumeric(txtInvoiceTotal)
	End Sub
	
	Private Sub txtInvoiceTotal_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtInvoiceTotal.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        MyKeyPress(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtInvoiceTotal_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtInvoiceTotal.Leave
        MyLostFocus(txtInvoiceTotal, 2)
	End Sub
	
	Private Sub txtSearch_MyGotFocus()
        'Dim txtSearch As New TextBox
        'txtSearch.Start = 0
        'txtSearch.Length = 999
	End Sub
	
	Private Sub update_Renamed()
		'  On Error GoTo UpdateErr
		adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll)
		Exit Sub
UpdateErr: 
		MsgBox(Err.Description)
	End Sub

    Private Sub frmGRV_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        lblLabels.AddRange(New Label() {_lblLabels_0, _lblLabels_2, _lblLabels_36, _
                                       _lblLabels_8, _lblLabels_9})
        lblData.AddRange(New Label() {_lblData_0, _lblData_1, _lblData_2, _lblData_3, _
                                     _lblData_7})
    End Sub
End Class