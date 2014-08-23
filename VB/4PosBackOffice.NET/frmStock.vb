Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmStock
	Inherits System.Windows.Forms.Form
	Dim gCNT As Short
	
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2128 'All StockItems GRV, Sales & Shrink Analysis|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1006 'Filter|Checked
		If rsLang.RecordCount Then _lbl_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1006 'Filter|Checked
		If rsLang.RecordCount Then cmdGroup.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdGroup.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1269 'Load report|Checked
		If rsLang.RecordCount Then cmdLoad.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdLoad.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmStock.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub moveItem()
        If pixelToTwips(picInner.Width, True) > pixelToTwips(picOuter.Width, True) Then picInner.Width = 0 : gCNT = 0
		
		gCNT = gCNT + 1
        picInner.Width = twipsToPixels(CShort(pixelToTwips(picOuter.Width, True) / 31 * gCNT) + 100, True)
		System.Windows.Forms.Application.DoEvents()
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	
	Private Sub cmdGroup_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGroup.Click
		Dim rs As ADODB.Recordset
		Dim lID As Integer
		cnnDBreport.Execute("DELETE aftDataItem.* From aftDataItem WHERE (((aftDataItem.ftDataItem_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("DELETE aftData.* From aftData WHERE (((aftData.ftData_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("INSERT INTO aftData ( ftData_PersonID, ftData_FieldName, ftData_SQL, ftData_Heading ) SELECT LinkData.LinkData_PersonID, LinkData.LinkData_FieldName, LinkData.LinkData_SQL, LinkData.LinkData_Heading From LinkData WHERE (((LinkData.LinkData_LinkID)=2) AND ((LinkData.LinkData_SectionID)=1) AND ((LinkData.LinkData_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("INSERT INTO aftDataItem ( ftDataItem_PersonID, ftDataItem_FieldName, ftDataItem_ID ) SELECT LinkDataItem.LinkDataItem_PersonID, LinkDataItem.LinkDataItem_FieldName, LinkDataItem.LinkDataItem_ID From LinkDataItem WHERE (((LinkDataItem.LinkDataItem_LinkID)=2) AND ((LinkDataItem.LinkDataItem_SectionID)=1) AND ((LinkDataItem.LinkDataItem_PersonID)=" & gPersonID & "));")
		frmFilter.Close()
		frmFilter.buildCriteria("StockItem")
		frmFilter.loadFilter("StockItem")
		frmFilter.buildCriteria("StockItem")
		
		cnnDBreport.Execute("UPDATE Link SET Link.Link_Name = '" & Replace(frmFilter.gHeading, "'", "''") & "', Link.Link_SQL = '" & Replace(frmFilter.gCriteria, "'", "''") & "' WHERE (((Link.LinkID)=2) AND ((Link.Link_SectionID)=1) AND ((Link.Link_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("DELETE LinkDataItem.* From LinkDataItem WHERE (((LinkDataItem.LinkDataItem_LinkID)=2) AND ((LinkDataItem.LinkDataItem_SectionID)=1) AND ((LinkDataItem.LinkDataItem_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("DELETE LinkData.* From LinkData WHERE (((LinkData.LinkData_LinkID)=2) AND ((LinkData.LinkData_SectionID)=1) AND ((LinkData.LinkData_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("INSERT INTO LinkData ( LinkData_LinkID, LinkData_SectionID, LinkData_PersonID, LinkData_FieldName, LinkData_SQL, LinkData_Heading ) SELECT 2, 1, aftData.ftData_PersonID, aftData.ftData_FieldName, aftData.ftData_SQL, aftData.ftData_Heading From aftData WHERE (((aftData.ftData_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("INSERT INTO LinkDataItem ( LinkDataItem_LinkID, LinkDataItem_SectionID, LinkDataItem_PersonID, LinkDataItem_FieldName, LinkDataItem_ID ) SELECT 2, 1, aftDataItem.ftDataItem_PersonID, aftDataItem.ftDataItem_FieldName, aftDataItem.ftDataItem_ID From aftDataItem WHERE (((aftDataItem.ftDataItem_PersonID)=" & gPersonID & "));")
		lblGroup.Text = frmFilter.gHeading
	End Sub
	
	Private Sub setup()
		Dim rs As ADODB.Recordset
		rs = getRSreport("SELECT Link.Link_PersonID From Link WHERE (((Link.Link_PersonID)=" & gPersonID & "));")
		If rs.BOF Or rs.EOF Then
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 1, 1, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 2, 1, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 1, 2, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 2, 2, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 1, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 2, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 3, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 4, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 5, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 6, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 7, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 8, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 9, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 10, 3, " & gPersonID & ", '', '';")
		End If
		
		rs = getRSreport("SELECT Link.Link_Name From Link WHERE (((Link.LinkID)=2) AND ((Link.Link_SectionID)=1) AND ((Link.Link_PersonID)=" & gPersonID & "));")
		lblGroup.Text = rs.Fields("Link_Name").Value
	End Sub
	
	Private Sub loadStockQuantity()
		Dim rs As ADODB.Recordset
		Dim rsStock As ADODB.Recordset
		Dim rsGroup As ADODB.Recordset
		Dim sql As String
		Dim rsData As ADODB.Recordset
		Dim rsOpen As ADODB.Recordset
		Dim rsWH As ADODB.Recordset
        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryStockQuantityAllItems.rpt")
		Dim ReportNone As CrystalDecisions.CrystalReports.Engine.ReportDocument
		ReportNone.Load("cryNoRecords.rpt")
		
		'Multi Warehouse change
		Dim lMWNo As Integer
		lMWNo = frmMWSelect.getMWNo
		If lMWNo > 1 Then
			rsWH = getRS("SELECT * FROM Warehouse WHERE WarehouseID=" & lMWNo & ";")
            Report.SetParameterValue("txtWH", rsWH.Fields("Warehouse_Name"))
		End If
		'Multi Warehouse change
		
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
		Report.SetParameterValue("txtCompanyName",rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
		rs.Close()
		rs = getRSreport("SELECT * FROM Link Where LinkID=2 AND Link_SectionID=1")
		If rs.Fields("Link_Name").Value = "" Then
            Report.ReportDefinition.Sections("Section2").SectionFormat.EnableSuppress = True
		Else
            Report.SetParameterValue("txtFilter", Replace(rs.Fields("Link_Name").Value, "''", "'"))
		End If
		
		If rs.Fields("Link_Name").Value = "" Then
			moveItem()
			
			'adding query information in TEMP table, due to less info abt SALES QTY in RECIEPT
			sql = ""
			cnnDBreport.Execute("DELETE * FROM stockQuantitySumTemp;")
			'1
			'sql = "SELECT [Sale_PosID] & '_' & [Sale_Reference] & '*' AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aStockItem.StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, Sum([SaleItem_Quantity]*[SaleItem_ShrinkQuantity]) AS saleQuantity, 0 AS shrinkQuantity FROM ((aStockItem INNER JOIN SaleItem ON aStockItem.StockItemID = SaleItem.SaleItem_StockItemID) INNER JOIN (DayEnd INNER JOIN Sale ON DayEnd.DayEndID = Sale.Sale_DayEndID) ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN DayEndStockItemLnk ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AND SaleItem.SaleItem_WarehouseID = DayEndStockItemLnk.DayEndStockItemLnk_Warehouse "
			sql = "SELECT [Sale_PosID] & '_' & [Sale_Reference] & '*' AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aStockItem.StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, Sum([SaleItem_Quantity]*[SaleItem_ShrinkQuantity]) AS saleQuantity, 0 AS shrinkQuantity FROM ((aStockItem INNER JOIN SaleItem ON aStockItem.StockItemID = SaleItem.SaleItem_StockItemID) INNER JOIN (DayEnd INNER JOIN Sale ON DayEnd.DayEndID = Sale.Sale_DayEndID) ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN DayEndStockItemLnk ON (DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) AND (SaleItem.SaleItem_WarehouseID = DayEndStockItemLnk.DayEndStockItemLnk_Warehouse) AND (aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)"
			'Multi Warehouse change     sql = sql & "GROUP BY [Sale_PosID] & '_' & [Sale_Reference] & '*', aStockItem.StockItemID, aStockItem.StockItem_Name, aStockItem.StockItemID;"
			sql = sql & "GROUP BY [Sale_PosID] & '_' & [Sale_Reference] & '*', aStockItem.StockItemID, aStockItem.StockItem_Name, aStockItem.StockItemID, SaleItem.SaleItem_WarehouseID, SaleItem.SaleItem_Revoke, SaleItem.SaleItem_Reversal HAVING (((SaleItem.SaleItem_WarehouseID)=" & lMWNo & ") AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)=0));"
			'sql = sql & "GROUP BY [Sale_PosID] & '_' & [Sale_Reference] & '*', aStockItem.StockItemID, aStockItem.StockItem_Name, aStockItem.StockItemID, SaleItem.SaleItem_WarehouseID HAVING (((SaleItem.SaleItem_WarehouseID)=2) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)=0));"
			Debug.Print(sql)
			cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
			moveItem()
			
			'2
			'sql = "SELECT [Sale_PosID] & '_' & [Sale_Reference] & '*' AS posname, (SELECT First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) FROM DayEndStockItemLnk WHERE aSaleItemReciept1.SaleItemReciept_StockitemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) AS FirstOfDayEndStockItemLnk_Quantity, aSaleItemReciept1.SaleItemReciept_StockitemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, [SaleItemReciept_Quantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity "
			'changed on 11-12-2012 (if sell more then 1 it was multiplying 2 times) Hogshead
			sql = "SELECT [Sale_PosID] & '_' & [Sale_Reference] & '*' AS posname, (SELECT First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) FROM DayEndStockItemLnk WHERE aSaleItemReciept1.SaleItemReciept_StockitemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) AS FirstOfDayEndStockItemLnk_Quantity, aSaleItemReciept1.SaleItemReciept_StockitemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, [SaleItemReciept_Quantity] AS saleQuantity, 0 AS shrinkQuantity "
			sql = sql & "FROM (((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN aSaleItemReciept1 ON SaleItem.SaleItemID = aSaleItemReciept1.SaleItemReciept_SaleItemID) INNER JOIN DayEnd ON Sale.Sale_DayEndID = DayEnd.DayEndID) INNER JOIN aStockItem ON aSaleItemReciept1.SaleItemReciept_StockitemID = aStockItem.StockItemID "
			'Multi Warehouse change     sql = sql & "WHERE (((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)=0));"
			sql = sql & "WHERE (((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)=0) AND ((SaleItem.SaleItem_WarehouseID)=" & lMWNo & "));"
			cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
			moveItem()
			
			'3
			sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN ((DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) ON SaleItem.SaleItem_StockItemID = aStockItem.StockItemID "
			'Multi Warehouse change     sql = sql & "GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity], 0, SaleItem.SaleItem_Revoke, SaleItem.SaleItem_Reversal, SaleItem.SaleItem_Recipe HAVING (((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)<>0) AND ((SaleItem.SaleItem_Recipe)=0));"
			sql = sql & "GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity], 0, SaleItem.SaleItem_Revoke, SaleItem.SaleItem_Reversal, SaleItem.SaleItem_Recipe, SaleItem.SaleItem_WarehouseID HAVING (((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)<>0) AND ((SaleItem.SaleItem_Recipe)=0) AND ((SaleItem.SaleItem_WarehouseID)=" & lMWNo & "));"
			cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
			moveItem()
			
			'4
			'sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0-[SaleItemReciept_Quantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM ((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN aSaleItemReciept1 ON SaleItem.SaleItemID = aSaleItemReciept1.SaleItemReciept_SaleItemID) INNER JOIN ((DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) ON aSaleItemReciept1.SaleItemReciept_StockitemID = aStockItem.StockItemID "
			'changed on 11-12-2012 (if sell more then 1 it was multiplying 2 times) Hogshead
			sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0-[SaleItemReciept_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM ((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN aSaleItemReciept1 ON SaleItem.SaleItemID = aSaleItemReciept1.SaleItemReciept_SaleItemID) INNER JOIN ((DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) ON aSaleItemReciept1.SaleItemReciept_StockitemID = aStockItem.StockItemID "
			'Multi Warehouse change     sql = sql & "GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0-[SaleItemReciept_Quantity]*[SaleItem_Quantity], 0, SaleItem.SaleItem_Recipe, SaleItem.SaleItem_Revoke, SaleItem.SaleItem_Reversal HAVING (((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)<>0));"
			sql = sql & "GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0-[SaleItemReciept_Quantity], 0, SaleItem.SaleItem_Recipe, SaleItem.SaleItem_Revoke, SaleItem.SaleItem_Reversal, SaleItem.SaleItem_WarehouseID HAVING (((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)<>0) AND ((SaleItem.SaleItem_WarehouseID)=" & lMWNo & "));"
			cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
			moveItem()
			
			If lMWNo = 2 Then
				'5
				'sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aGRVItem.GRVItem_StockItemID AS stockItem, aStockItem.StockItem_Name as name, [GRVItem_PackSize]*[GRVItem_Quantity] AS grvQuantity, 0 AS saleQuantity, 0 AS shrinkQuantity FROM (((aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aStockItem ON aGRVItem.GRVItem_StockItemID = aStockItem.StockItemID) INNER JOIN DayEndStockItemLnk ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aSale INNER JOIN aSaleItem ON aSale.SaleID = aSaleItem.SaleItem_SaleID "
				'sql = sql & "GROUP BY aGRVItem.GRVItem_StockItemID, aStockItem.StockItem_Name, [GRVItem_PackSize]*[GRVItem_Quantity], 0, 0, aGRVItem.GRVItem_Return, aGRV.GRV_GRVStatusID HAVING (((aGRVItem.GRVItem_Return)=0) AND ((aGRV.GRV_GRVStatusID)=3));"
				'cnnDBreport.Execute "INSERT INTO stockQuantitySumTemp " & sql
				'above is old line commented on 20-sep-2011 when GRV quantiy was wrong on 4AIR
				sql = "SELECT aGRVItem.GRVItem_StockItemID & '_' & '*' AS posname, 0 AS FirstOfDayEndStockItemLnk_Quantity, aGRVItem.GRVItem_StockItemID AS stockItem, aStockItem.StockItem_Name as name, [GRVItem_PackSize]*[GRVItem_Quantity] AS grvQuantity, 0 AS saleQuantity, 0 AS shrinkQuantity "
				sql = sql & "FROM ((aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aStockItem ON aGRVItem.GRVItem_StockItemID = aStockItem.StockItemID "
				sql = sql & "WHERE (((aGRVItem.GRVItem_Return)=0) AND ((aGRV.GRV_GRVStatusID)=3));"
				cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
				Debug.Print(sql)
				moveItem()
				'6
				'sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aGRVItem.GRVItem_StockItemID AS stockitem, aStockItem.StockItem_Name AS name, 0-([GRVItem_PackSize]*[GRVItem_Quantity]) AS grvQuantity, 0 AS saleQuantity, 0 AS shrinkQuantity FROM aStockItem INNER JOIN (DayEndStockItemLnk INNER JOIN (aSale INNER JOIN ((aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) ON aSale.Sale_DayEndID = DayEnd.DayEndID) ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = DayEnd.DayEndID) ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID Where (((aGRVItem.GRVItem_Return) <> 0) And ((aGRV.GRV_GRVStatusID) = 3)) "
				'sql = sql & "GROUP BY aGRVItem.GRVItem_StockItemID, aStockItem.StockItem_Name, 0-([GRVItem_PackSize]*[GRVItem_Quantity]), 0, 0;"
				'lines commented
				'query have problem when tested on Garlito's DB it was messing up StockItemID, GRV quantity
				sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aGRVItem.GRVItem_StockItemID AS stockItem, aStockItem.StockItem_Name as name, 0-([GRVItem_PackSize]*[GRVItem_Quantity]) AS grvQuantity, 0 AS saleQuantity, 0 AS shrinkQuantity FROM (((aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aStockItem ON aGRVItem.GRVItem_StockItemID = aStockItem.StockItemID) INNER JOIN DayEndStockItemLnk ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aSale INNER JOIN aSaleItem ON aSale.SaleID = aSaleItem.SaleItem_SaleID "
				sql = sql & "GROUP BY aGRVItem.GRVItem_StockItemID, aStockItem.StockItem_Name, [GRVItem_PackSize]*[GRVItem_Quantity], 0, 0, aGRVItem.GRVItem_Return, aGRV.GRV_GRVStatusID HAVING (((aGRVItem.GRVItem_Return)<>0) AND ((aGRV.GRV_GRVStatusID)=3));"
				cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
				Debug.Print(sql)
				moveItem()
			End If
			
			'7
			'Multi Warehouse change     sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) As FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0 AS saleQuantity, DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink AS shrinkQuantity FROM ((DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) INNER JOIN aSale ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aSale.Sale_DayEndID GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0, DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink HAVING (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink)<>0));"
			sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) As FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0 AS saleQuantity, DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink AS shrinkQuantity FROM ((DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) INNER JOIN aSale ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aSale.Sale_DayEndID GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0, DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse "
			sql = sql & "HAVING (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink)<>0) AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & lMWNo & "));"
			cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
			moveItem()
			
			'DayEndStockItemLnk_QuantityTransafer
			'8
			sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) As FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0 AS saleQuantity, 0 AS shrinkQuantity, DayEndStockItemLnk.DayEndStockItemLnk_QuantityTransafer AS xferQuantity  FROM ((DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) INNER JOIN aSale ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aSale.Sale_DayEndID GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0, 0, DayEndStockItemLnk.DayEndStockItemLnk_QuantityTransafer, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse "
			sql = sql & "HAVING (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityTransafer)<>0) AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & lMWNo & "));"
			cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
			moveItem()
fetchData: 
			System.Windows.Forms.Application.DoEvents()
			rsStock = getRSreport("SELECT 0 AS posname, FirstOfDayEndStockItemLnk_Quantity, stockitem, name, Sum(grvQuantity) AS grvQuantity, Sum(saleQuantity) AS saleQuantity, Sum(shrinkQuantity) AS shrinkQuantity, Sum(xferQuantity) AS xferQuantity FROM stockQuantitySumTemp GROUP BY 0, FirstOfDayEndStockItemLnk_Quantity, stockitem, name;")
			If rsStock.RecordCount Then
				Do While rsStock.EOF = False
					System.Windows.Forms.Application.DoEvents()
					rsData = getRSreport("SELECT First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity From DayEndStockItemLnk GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse HAVING (((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & lMWNo & ") AND ((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & rsStock.Fields("stockitem").Value & "));")
					If rsData.RecordCount Then
						'If rsStock("stockitem") = 4 Then MsgBox " "
						cnnDBreport.Execute("UPDATE stockQuantitySumTemp SET stockQuantitySumTemp.FirstOfDayEndStockItemLnk_Quantity = " & rsData.Fields("FirstOfDayEndStockItemLnk_Quantity").Value & " WHERE stockQuantitySumTemp.stockitem = " & rsStock.Fields("stockitem").Value & ";")
					End If
					System.Windows.Forms.Application.DoEvents()
					rsStock.moveNext()
					moveItem()
				Loop 
			Else
				'9
				sql = "SELECT 'No Movement' AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0 AS saleQuantity, 0 AS shrinkQuantity, 0 AS xferQuantity FROM (DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0, 0, DayEndStockItemLnk.DayEndStockItemLnk_Quantity, 0, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse "
				sql = sql & "HAVING (((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & lMWNo & "));"
				cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
				GoTo fetchData
			End If
			
			'add shrinkage cost and priece
			System.Windows.Forms.Application.DoEvents()
			'sql = "SELECT aStockItem.StockItemID, aStockItem.StockItem_Name, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS list, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actual, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse, CatalogueChannelLnk.CatalogueChannelLnk_Price"
			sql = "SELECT aStockItem.StockItemID, aStockItem.StockItem_Name, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, DayEndStockItemLnk_ListCost AS list, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actual, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse, CatalogueChannelLnk.CatalogueChannelLnk_Price"
			sql = sql & " FROM (DayEndStockItemLnk LEFT JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) INNER JOIN CatalogueChannelLnk ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID Where (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0)) GROUP BY aStockItem.StockItemID, aStockItem.StockItem_Name, DayEndStockItemLnk_ListCost, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price Having (((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse) = " & lMWNo & ") And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1)) ORDER BY aStockItem.StockItem_Name;"
			rsStock = getRSreport(sql)
			If rsStock.RecordCount Then
				Do While rsStock.EOF = False
					System.Windows.Forms.Application.DoEvents()
					cnnDBreport.Execute("UPDATE stockQuantitySumTemp SET stockQuantitySumTemp.shrinkCost = stockQuantitySumTemp.shrinkQuantity*" & rsStock.Fields("list").Value & ", stockQuantitySumTemp.shrinkSell = stockQuantitySumTemp.shrinkQuantity*" & rsStock.Fields("CatalogueChannelLnk_Price").Value & " WHERE (((stockQuantitySumTemp.shrinkQuantity)<>0) AND ((stockQuantitySumTemp.stockitem)=" & rsStock.Fields("StockItemID").Value & "));")
					System.Windows.Forms.Application.DoEvents()
					rsStock.moveNext()
					moveItem()
				Loop 
			End If
			
			sql = "SELECT 0 AS posname, FirstOfDayEndStockItemLnk_Quantity, stockitem, name, Sum(grvQuantity) AS grvQuantity, Sum(saleQuantity) AS saleQuantity, Sum(shrinkQuantity) AS shrinkQuantity, Sum(xferQuantity) AS xferQuantity, Sum(shrinkCost) AS shrinkCost, Sum(shrinkSell) AS shrinkSell FROM stockQuantitySumTemp GROUP BY 0, FirstOfDayEndStockItemLnk_Quantity, stockitem, name;"
			'adding query information in TEMP table, due to less info abt SALES QTY in RECIEPT
			
		Else
			
			moveItem()
			
			'adding query information in TEMP table, due to less info abt SALES QTY in RECIEPT
			sql = ""
			cnnDBreport.Execute("DELETE * FROM stockQuantitySumTemp;")
			'1
			'sql = "SELECT [Sale_PosID] & '_' & [Sale_Reference] & '*' AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aStockItem.StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, Sum([SaleItem_Quantity]*[SaleItem_ShrinkQuantity]) AS saleQuantity, 0 AS shrinkQuantity FROM ((aStockItem INNER JOIN SaleItem ON aStockItem.StockItemID = SaleItem.SaleItem_StockItemID) INNER JOIN (DayEnd INNER JOIN Sale ON DayEnd.DayEndID = Sale.Sale_DayEndID) ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN DayEndStockItemLnk ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AND SaleItem.SaleItem_WarehouseID = DayEndStockItemLnk.DayEndStockItemLnk_Warehouse "
			sql = "SELECT [Sale_PosID] & '_' & [Sale_Reference] & '*' AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aStockItem.StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, Sum([SaleItem_Quantity]*[SaleItem_ShrinkQuantity]) AS saleQuantity, 0 AS shrinkQuantity FROM ((aStockItem INNER JOIN SaleItem ON aStockItem.StockItemID = SaleItem.SaleItem_StockItemID) INNER JOIN (DayEnd INNER JOIN Sale ON DayEnd.DayEndID = Sale.Sale_DayEndID) ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN DayEndStockItemLnk ON (DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) AND (SaleItem.SaleItem_WarehouseID = DayEndStockItemLnk.DayEndStockItemLnk_Warehouse) AND (aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)"
			sql = sql & rs.Fields("Link_SQL").Value
			'Multi Warehouse change     sql = sql & " AND (((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_Reversal) = 0) And ((SaleItem.SaleItem_Recipe) = 0))"
			sql = sql & " AND (((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_Reversal) = 0) And ((SaleItem.SaleItem_Recipe) = 0) AND ((SaleItem.SaleItem_WarehouseID)=" & lMWNo & "))"
			sql = sql & "GROUP BY [Sale_PosID] & '_' & [Sale_Reference] & '*', aStockItem.StockItemID, aStockItem.StockItem_Name, aStockItem.StockItemID;"
			Debug.Print(sql)
			cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
			moveItem()
			
			'2
			'sql = "SELECT [Sale_PosID] & '_' & [Sale_Reference] & '*' AS posname, (SELECT First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) FROM DayEndStockItemLnk WHERE aSaleItemReciept1.SaleItemReciept_StockitemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) AS FirstOfDayEndStockItemLnk_Quantity, aSaleItemReciept1.SaleItemReciept_StockitemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, [SaleItemReciept_Quantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity "
			'changed on 11-12-2012 (if sell more then 1 it was multiplying 2 times) Hogshead
			sql = "SELECT [Sale_PosID] & '_' & [Sale_Reference] & '*' AS posname, (SELECT First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) FROM DayEndStockItemLnk WHERE aSaleItemReciept1.SaleItemReciept_StockitemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) AS FirstOfDayEndStockItemLnk_Quantity, aSaleItemReciept1.SaleItemReciept_StockitemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, [SaleItemReciept_Quantity] AS saleQuantity, 0 AS shrinkQuantity "
			sql = sql & "FROM (((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN aSaleItemReciept1 ON SaleItem.SaleItemID = aSaleItemReciept1.SaleItemReciept_SaleItemID) INNER JOIN DayEnd ON Sale.Sale_DayEndID = DayEnd.DayEndID) INNER JOIN aStockItem ON aSaleItemReciept1.SaleItemReciept_StockitemID = aStockItem.StockItemID "
			'sql = sql & "WHERE (((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)=0));"
			sql = sql & rs.Fields("Link_SQL").Value
			'Multi Warehouse change     sql = sql & " AND  (((SaleItem.SaleItem_Recipe) <> 0) And ((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_Reversal) = 0))"
			sql = sql & " AND  (((SaleItem.SaleItem_Recipe) <> 0) And ((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_Reversal) = 0) AND ((SaleItem.SaleItem_WarehouseID)=" & lMWNo & "))"
			cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
			moveItem()
			
			'3
			sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN ((DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) ON SaleItem.SaleItem_StockItemID = aStockItem.StockItemID "
			sql = sql & rs.Fields("Link_SQL").Value
			'Multi Warehouse change     sql = sql & " and (((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_Reversal) <> 0) And ((SaleItem.SaleItem_Recipe) = 0))"
			sql = sql & " and (((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_Reversal) <> 0) And ((SaleItem.SaleItem_Recipe) = 0) AND ((SaleItem.SaleItem_WarehouseID)=" & lMWNo & "))"
			sql = sql & "GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity], 0, SaleItem.SaleItem_Revoke, SaleItem.SaleItem_Reversal, SaleItem.SaleItem_Recipe;"
			cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
			Debug.Print(sql)
			moveItem()
			
			'4
			'sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0-[SaleItemReciept_Quantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM ((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN aSaleItemReciept1 ON SaleItem.SaleItemID = aSaleItemReciept1.SaleItemReciept_SaleItemID) INNER JOIN ((DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) ON aSaleItemReciept1.SaleItemReciept_StockitemID = aStockItem.StockItemID "
			'changed on 11-12-2012 (if sell more then 1 it was multiplying 2 times) Hogshead
			sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0-[SaleItemReciept_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM ((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN aSaleItemReciept1 ON SaleItem.SaleItemID = aSaleItemReciept1.SaleItemReciept_SaleItemID) INNER JOIN ((DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) ON aSaleItemReciept1.SaleItemReciept_StockitemID = aStockItem.StockItemID "
			sql = sql & rs.Fields("Link_SQL").Value
			'Multi Warehouse change     sql = sql & " AND (((SaleItem.SaleItem_Recipe) <> 0) And ((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_Reversal) <> 0))"
			sql = sql & " AND (((SaleItem.SaleItem_Recipe) <> 0) And ((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_Reversal) <> 0) AND ((SaleItem.SaleItem_WarehouseID)=" & lMWNo & "))"
			sql = sql & "GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0-[SaleItemReciept_Quantity], 0, SaleItem.SaleItem_Recipe, SaleItem.SaleItem_Revoke, SaleItem.SaleItem_Reversal;"
			cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
			Debug.Print(sql)
			moveItem()
			
			If lMWNo = 2 Then
				'5
				sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aGRVItem.GRVItem_StockItemID AS stockItem, aStockItem.StockItem_Name as name, [GRVItem_PackSize]*[GRVItem_Quantity] AS grvQuantity, 0 AS saleQuantity, 0 AS shrinkQuantity FROM (((aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aStockItem ON aGRVItem.GRVItem_StockItemID = aStockItem.StockItemID) INNER JOIN DayEndStockItemLnk ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aSale INNER JOIN aSaleItem ON aSale.SaleID = aSaleItem.SaleItem_SaleID "
				sql = sql & rs.Fields("Link_SQL").Value
				sql = sql & " AND  (((aGRVItem.GRVItem_Return) = 0) And ((aGRV.GRV_GRVStatusID) = 3))"
				sql = sql & "GROUP BY aGRVItem.GRVItem_StockItemID, aStockItem.StockItem_Name, [GRVItem_PackSize]*[GRVItem_Quantity], 0, 0, aGRVItem.GRVItem_Return, aGRV.GRV_GRVStatusID;"
				cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
				Debug.Print(sql)
				moveItem()
				'6
				'sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aGRVItem.GRVItem_StockItemID AS stockitem, aStockItem.StockItem_Name AS name, 0-([GRVItem_PackSize]*[GRVItem_Quantity]) AS grvQuantity, 0 AS saleQuantity, 0 AS shrinkQuantity FROM aStockItem INNER JOIN (DayEndStockItemLnk INNER JOIN (aSale INNER JOIN ((aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) ON aSale.Sale_DayEndID = DayEnd.DayEndID) ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = DayEnd.DayEndID) ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID "
				'sql = sql & rs("Link_SQL")
				'sql = sql & " AND  (((aGRVItem.GRVItem_Return) <> 0) And ((aGRV.GRV_GRVStatusID) = 3))"
				'sql = sql & "GROUP BY aGRVItem.GRVItem_StockItemID, aStockItem.StockItem_Name, 0-([GRVItem_PackSize]*[GRVItem_Quantity]), 0, 0;"
				'lines commented
				'query have problem when tested on Garlito's DB it was messing up StockItemID, GRV quantity
				sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aGRVItem.GRVItem_StockItemID AS stockItem, aStockItem.StockItem_Name as name, 0-([GRVItem_PackSize]*[GRVItem_Quantity]) AS grvQuantity, 0 AS saleQuantity, 0 AS shrinkQuantity FROM (((aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aStockItem ON aGRVItem.GRVItem_StockItemID = aStockItem.StockItemID) INNER JOIN DayEndStockItemLnk ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aSale INNER JOIN aSaleItem ON aSale.SaleID = aSaleItem.SaleItem_SaleID "
				sql = sql & rs.Fields("Link_SQL").Value
				sql = sql & " AND  (((aGRVItem.GRVItem_Return) <> 0) And ((aGRV.GRV_GRVStatusID) = 3))"
				sql = sql & "GROUP BY aGRVItem.GRVItem_StockItemID, aStockItem.StockItem_Name, 0-([GRVItem_PackSize]*[GRVItem_Quantity]), 0, 0;"
				cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
				Debug.Print(sql)
				moveItem()
			End If
			
			'7
			sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) As FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0 AS saleQuantity, DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink AS shrinkQuantity FROM ((DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) INNER JOIN aSale ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aSale.Sale_DayEndID "
			sql = sql & rs.Fields("Link_SQL").Value
			'Multi Warehouse change     sql = sql & " AND (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0))"
			sql = sql & " AND (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0) AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & lMWNo & "))"
			sql = sql & " GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0, DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink "
			cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
			Debug.Print(sql)
			moveItem()
			
			'DayEndStockItemLnk_QuantityTransafer
			'8
			sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) As FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0 AS saleQuantity, 0 AS shrinkQuantity, DayEndStockItemLnk.DayEndStockItemLnk_QuantityTransafer AS xferQuantity FROM ((DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) INNER JOIN aSale ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aSale.Sale_DayEndID "
			sql = sql & rs.Fields("Link_SQL").Value
			'Multi Warehouse change     sql = sql & " AND (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0))"
			sql = sql & " AND (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityTransafer) <> 0) AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & lMWNo & "))"
			sql = sql & " GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0, 0, DayEndStockItemLnk.DayEndStockItemLnk_QuantityTransafer "
			cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
			Debug.Print(sql)
			moveItem()
			
fetchDataF: 
			System.Windows.Forms.Application.DoEvents()
			rsStock = getRSreport("SELECT 0 AS posname, FirstOfDayEndStockItemLnk_Quantity, stockitem, name, Sum(grvQuantity) AS grvQuantity, Sum(saleQuantity) AS saleQuantity, Sum(shrinkQuantity) AS shrinkQuantity, Sum(xferQuantity) AS xferQuantity FROM stockQuantitySumTemp GROUP BY 0, FirstOfDayEndStockItemLnk_Quantity, stockitem, name;")
			If rsStock.RecordCount Then
				Do While rsStock.EOF = False
					System.Windows.Forms.Application.DoEvents()
					rsData = getRSreport("SELECT First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity From DayEndStockItemLnk GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse HAVING (((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & lMWNo & ") AND ((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & rsStock.Fields("stockitem").Value & "));")
					If rsData.RecordCount Then
						cnnDBreport.Execute("UPDATE stockQuantitySumTemp SET stockQuantitySumTemp.FirstOfDayEndStockItemLnk_Quantity = " & rsData.Fields("FirstOfDayEndStockItemLnk_Quantity").Value & " WHERE stockQuantitySumTemp.stockitem = " & rsStock.Fields("stockitem").Value & ";")
					End If
					System.Windows.Forms.Application.DoEvents()
					rsStock.moveNext()
					moveItem()
				Loop 
			Else
				'9
				sql = "SELECT 'No Movement' AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) As FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0 AS saleQuantity, 0 AS shrinkQuantity, 0 AS xferQuantity FROM (DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID "
				sql = sql & rs.Fields("Link_SQL").Value
				'Multi Warehouse change     sql = sql & " AND (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0))"
				sql = sql & " AND (((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & lMWNo & "))"
				sql = sql & " GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0, 0, 0 "
				cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
				GoTo fetchDataF
			End If
			
			'add shrinkage cost and priece
			System.Windows.Forms.Application.DoEvents()
			sql = "SELECT aStockItem.StockItemID, aStockItem.StockItem_Name, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS list, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actual, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse, CatalogueChannelLnk.CatalogueChannelLnk_Price"
			sql = sql & " FROM (DayEndStockItemLnk LEFT JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) INNER JOIN CatalogueChannelLnk ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID Where (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0)) GROUP BY aStockItem.StockItemID, aStockItem.StockItem_Name, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price Having (((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse) = " & lMWNo & ") And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1)) ORDER BY aStockItem.StockItem_Name;"
			rsStock = getRSreport(sql)
			If rsStock.RecordCount Then
				Do While rsStock.EOF = False
					System.Windows.Forms.Application.DoEvents()
					cnnDBreport.Execute("UPDATE stockQuantitySumTemp SET stockQuantitySumTemp.shrinkCost = " & rsStock.Fields("list").Value & ", stockQuantitySumTemp.shrinkSell = " & rsStock.Fields("CatalogueChannelLnk_Price").Value & " WHERE stockQuantitySumTemp.stockitem = " & rsStock.Fields("StockItemID").Value & ";")
					System.Windows.Forms.Application.DoEvents()
					rsStock.moveNext()
					moveItem()
				Loop 
			End If
			
			'sql = "SELECT 0 AS posname, FirstOfDayEndStockItemLnk_Quantity, stockitem, name, Sum(grvQuantity) AS grvQuantity, Sum(saleQuantity) AS saleQuantity, Sum(shrinkQuantity) AS shrinkQuantity, Sum(xferQuantity) AS xferQuantity FROM stockQuantitySumTemp GROUP BY 0, FirstOfDayEndStockItemLnk_Quantity, stockitem, name;"
			sql = "SELECT 0 AS posname, FirstOfDayEndStockItemLnk_Quantity, stockitem, name, Sum(grvQuantity) AS grvQuantity, Sum(saleQuantity) AS saleQuantity, Sum(shrinkQuantity) AS shrinkQuantity, Sum(xferQuantity) AS xferQuantity, Sum(shrinkCost) AS shrinkCost, Sum(shrinkSell) AS shrinkSell FROM stockQuantitySumTemp GROUP BY 0, FirstOfDayEndStockItemLnk_Quantity, stockitem, name;"
			'adding query information in TEMP table, due to less info abt SALES QTY in RECIEPT
			moveItem()
			
		End If
		Debug.Print(sql)
		rs = getRSreport(sql)
		
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
	
	Private Sub cmdLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLoad.Click
		picInner.Width = 0
		gCNT = 0
		System.Windows.Forms.Application.DoEvents()
		
		picOuter.Visible = True
		cmdLoad.Visible = False
		cmdExit.Visible = False
		
		loadStockQuantity()
		
		picOuter.Visible = False
		cmdLoad.Visible = True
		cmdExit.Visible = True
		Exit Sub
	End Sub
	
	Private Sub frmStock_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 27 Then
			KeyAscii = 0
			Me.Close()
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub frmStock_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		picInner.Width = 0
		setup()
		
		loadLanguage()
	End Sub
	
	Private Sub loadStockQuantity_OLD()
		Dim rs As ADODB.Recordset
		Dim rsStock As ADODB.Recordset
		Dim rsGroup As ADODB.Recordset
		Dim sql As String
		Dim rsData As ADODB.Recordset
		Dim rsOpen As ADODB.Recordset
		Dim rsWH As ADODB.Recordset
        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryStockQuantityAllItems.rpt")
		Dim ReportNone As CrystalDecisions.CrystalReports.Engine.ReportDocument
		ReportNone.Load("cryNoRecords.rpt")
		
		'Multi Warehouse change
		Dim lMWNo As Integer
		lMWNo = frmMWSelect.getMWNo
		If lMWNo > 1 Then
			rsWH = getRS("SELECT * FROM Warehouse WHERE WarehouseID=" & lMWNo & ";")
            Report.SetParameterValue("txtWH", rsWH.Fields("Warehouse_Name"))
		End If
		'Multi Warehouse change
		
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
		Report.SetParameterValue("txtCompanyName",rs.Fields("Company_Name"))
		rs.Close()
		rs = getRSreport("SELECT * FROM Link Where LinkID=2 AND Link_SectionID=1")
		If rs.Fields("Link_Name").Value = "" Then
            Report.ReportDefinition.Sections("Section2").SectionFormat.EnableSuppress = True
		Else
            Report.SetParameterValue("txtFilter", Replace(rs.Fields("Link_Name").Value, "''", "'"))
		End If
		
		If rs.Fields("Link_Name").Value = "" Then
			'1
			sql = " SELECT [Sale_PosID] & '_' & [Sale_Reference] & '*' AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aStockItem.StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, Sum([SaleItem_Quantity]*[SaleItem_ShrinkQuantity]) AS saleQuantity, 0 AS shrinkQuantity FROM ((aStockItem INNER JOIN SaleItem ON aStockItem.StockItemID = SaleItem.SaleItem_StockItemID) INNER JOIN (DayEnd INNER JOIN Sale ON DayEnd.DayEndID = Sale.Sale_DayEndID) ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN DayEndStockItemLnk ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID"
			sql = sql & " GROUP BY [Sale_PosID] & '_' & [Sale_Reference] & '*', aStockItem.StockItemID, aStockItem.StockItem_Name, aStockItem.StockItemID Union"
			
			'2
			sql = sql & " SELECT [Sale_PosID] & '_' & [Sale_Reference] & '*' AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aSaleItemReciept1.SaleItemReciept_StockitemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, [SaleItemReciept_Quantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM (((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN aSaleItemReciept1 ON SaleItem.SaleItemID = aSaleItemReciept1.SaleItemReciept_SaleItemID) INNER JOIN aStockItem ON aSaleItemReciept1.SaleItemReciept_StockitemID = aStockItem.StockItemID) INNER JOIN DayEndStockItemLnk ON aSaleItemReciept1.SaleItemReciept_StockitemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID"
			sql = sql & " GROUP BY [Sale_PosID] & '_' & [Sale_Reference] & '*', aSaleItemReciept1.SaleItemReciept_StockitemID, aStockItem.StockItem_Name, 0, [SaleItemReciept_Quantity]*[SaleItem_Quantity], 0, SaleItem.SaleItem_Recipe, SaleItem.SaleItem_Revoke, SaleItem.SaleItem_Reversal HAVING (((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)=0)) Union "
			
			'3
			sql = sql & " SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN ((DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) ON SaleItem.SaleItem_StockItemID = aStockItem.StockItemID "
			sql = sql & " GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity], 0, SaleItem.SaleItem_Revoke, SaleItem.SaleItem_Reversal, SaleItem.SaleItem_Recipe HAVING (((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)<>0) AND ((SaleItem.SaleItem_Recipe)=0))Union "
			
			'4
			sql = sql & " SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0-[SaleItemReciept_Quantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM ((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN aSaleItemReciept1 ON SaleItem.SaleItemID = aSaleItemReciept1.SaleItemReciept_SaleItemID) INNER JOIN ((DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) ON aSaleItemReciept1.SaleItemReciept_StockitemID = aStockItem.StockItemID"
			sql = sql & " GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0-[SaleItemReciept_Quantity]*[SaleItem_Quantity], 0, SaleItem.SaleItem_Recipe, SaleItem.SaleItem_Revoke, SaleItem.SaleItem_Reversal HAVING (((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)<>0))Union "
			
			'5
			sql = sql & " SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aGRVItem.GRVItem_StockItemID AS stockItem, aStockItem.StockItem_Name as name, [GRVItem_PackSize]*[GRVItem_Quantity] AS grvQuantity, 0 AS saleQuantity, 0 AS shrinkQuantity FROM (((aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aStockItem ON aGRVItem.GRVItem_StockItemID = aStockItem.StockItemID) INNER JOIN DayEndStockItemLnk ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aSale INNER JOIN aSaleItem ON aSale.SaleID = aSaleItem.SaleItem_SaleID "
			sql = sql & " GROUP BY aGRVItem.GRVItem_StockItemID, aStockItem.StockItem_Name, [GRVItem_PackSize]*[GRVItem_Quantity], 0, 0, aGRVItem.GRVItem_Return, aGRV.GRV_GRVStatusID HAVING (((aGRVItem.GRVItem_Return)=0) AND ((aGRV.GRV_GRVStatusID)=3)) Union"
			
			'6
			sql = sql & " SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aGRVItem.GRVItem_StockItemID AS stockitem, aStockItem.StockItem_Name AS name, 0-([GRVItem_PackSize]*[GRVItem_Quantity]) AS grvQuantity, 0 AS saleQuantity, 0 AS shrinkQuantity FROM aStockItem INNER JOIN (DayEndStockItemLnk INNER JOIN (aSale INNER JOIN ((aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) ON aSale.Sale_DayEndID = DayEnd.DayEndID) ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = DayEnd.DayEndID) ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID Where (((aGRVItem.GRVItem_Return) <> 0) And ((aGRV.GRV_GRVStatusID) = 3))"
			sql = sql & " GROUP BY aGRVItem.GRVItem_StockItemID, aStockItem.StockItem_Name, 0-([GRVItem_PackSize]*[GRVItem_Quantity]), 0, 0 Union "
			
			'7
			sql = sql & " SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) As FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0 AS saleQuantity, DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink AS shrinkQuantity FROM ((DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) INNER JOIN aSale ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aSale.Sale_DayEndID GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0, DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink HAVING (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink)<>0));"
			moveItem()
			
			'adding query information in TEMP table, due to less info abt SALES QTY in RECIEPT
			sql = ""
			cnnDBreport.Execute("DELETE * FROM stockQuantitySumTemp;")
			'1
			'sql = "SELECT [Sale_PosID] & '_' & [Sale_Reference] & '*' AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aStockItem.StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, Sum([SaleItem_Quantity]*[SaleItem_ShrinkQuantity]) AS saleQuantity, 0 AS shrinkQuantity FROM ((aStockItem INNER JOIN SaleItem ON aStockItem.StockItemID = SaleItem.SaleItem_StockItemID) INNER JOIN (DayEnd INNER JOIN Sale ON DayEnd.DayEndID = Sale.Sale_DayEndID) ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN DayEndStockItemLnk ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AND SaleItem.SaleItem_WarehouseID = DayEndStockItemLnk.DayEndStockItemLnk_Warehouse "
			sql = "SELECT [Sale_PosID] & '_' & [Sale_Reference] & '*' AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aStockItem.StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, Sum([SaleItem_Quantity]*[SaleItem_ShrinkQuantity]) AS saleQuantity, 0 AS shrinkQuantity FROM ((aStockItem INNER JOIN SaleItem ON aStockItem.StockItemID = SaleItem.SaleItem_StockItemID) INNER JOIN (DayEnd INNER JOIN Sale ON DayEnd.DayEndID = Sale.Sale_DayEndID) ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN DayEndStockItemLnk ON (DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) AND (SaleItem.SaleItem_WarehouseID = DayEndStockItemLnk.DayEndStockItemLnk_Warehouse) AND (aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)"
			'Multi Warehouse change     sql = sql & "GROUP BY [Sale_PosID] & '_' & [Sale_Reference] & '*', aStockItem.StockItemID, aStockItem.StockItem_Name, aStockItem.StockItemID;"
			sql = sql & "GROUP BY [Sale_PosID] & '_' & [Sale_Reference] & '*', aStockItem.StockItemID, aStockItem.StockItem_Name, aStockItem.StockItemID, SaleItem.SaleItem_WarehouseID, SaleItem.SaleItem_Revoke, SaleItem.SaleItem_Reversal HAVING (((SaleItem.SaleItem_WarehouseID)=" & lMWNo & ") AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)=0));"
			'sql = sql & "GROUP BY [Sale_PosID] & '_' & [Sale_Reference] & '*', aStockItem.StockItemID, aStockItem.StockItem_Name, aStockItem.StockItemID, SaleItem.SaleItem_WarehouseID HAVING (((SaleItem.SaleItem_WarehouseID)=2) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)=0));"
			Debug.Print(sql)
			cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
			moveItem()
			
			'2
			sql = "SELECT [Sale_PosID] & '_' & [Sale_Reference] & '*' AS posname, (SELECT First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) FROM DayEndStockItemLnk WHERE aSaleItemReciept1.SaleItemReciept_StockitemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) AS FirstOfDayEndStockItemLnk_Quantity, aSaleItemReciept1.SaleItemReciept_StockitemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, [SaleItemReciept_Quantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity "
			sql = sql & "FROM (((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN aSaleItemReciept1 ON SaleItem.SaleItemID = aSaleItemReciept1.SaleItemReciept_SaleItemID) INNER JOIN DayEnd ON Sale.Sale_DayEndID = DayEnd.DayEndID) INNER JOIN aStockItem ON aSaleItemReciept1.SaleItemReciept_StockitemID = aStockItem.StockItemID "
			'Multi Warehouse change     sql = sql & "WHERE (((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)=0));"
			sql = sql & "WHERE (((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)=0) AND ((SaleItem.SaleItem_WarehouseID)=" & lMWNo & "));"
			cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
			moveItem()
			
			'3
			sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN ((DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) ON SaleItem.SaleItem_StockItemID = aStockItem.StockItemID "
			'Multi Warehouse change     sql = sql & "GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity], 0, SaleItem.SaleItem_Revoke, SaleItem.SaleItem_Reversal, SaleItem.SaleItem_Recipe HAVING (((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)<>0) AND ((SaleItem.SaleItem_Recipe)=0));"
			sql = sql & "GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity], 0, SaleItem.SaleItem_Revoke, SaleItem.SaleItem_Reversal, SaleItem.SaleItem_Recipe, SaleItem.SaleItem_WarehouseID HAVING (((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)<>0) AND ((SaleItem.SaleItem_Recipe)=0) AND ((SaleItem.SaleItem_WarehouseID)=" & lMWNo & "));"
			cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
			moveItem()
			
			'4
			sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0-[SaleItemReciept_Quantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM ((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN aSaleItemReciept1 ON SaleItem.SaleItemID = aSaleItemReciept1.SaleItemReciept_SaleItemID) INNER JOIN ((DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) ON aSaleItemReciept1.SaleItemReciept_StockitemID = aStockItem.StockItemID "
			'Multi Warehouse change     sql = sql & "GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0-[SaleItemReciept_Quantity]*[SaleItem_Quantity], 0, SaleItem.SaleItem_Recipe, SaleItem.SaleItem_Revoke, SaleItem.SaleItem_Reversal HAVING (((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)<>0));"
			sql = sql & "GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0-[SaleItemReciept_Quantity]*[SaleItem_Quantity], 0, SaleItem.SaleItem_Recipe, SaleItem.SaleItem_Revoke, SaleItem.SaleItem_Reversal, SaleItem.SaleItem_WarehouseID HAVING (((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)<>0) AND ((SaleItem.SaleItem_WarehouseID)=" & lMWNo & "));"
			cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
			moveItem()
			
			If lMWNo = 2 Then
				'5
				sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aGRVItem.GRVItem_StockItemID AS stockItem, aStockItem.StockItem_Name as name, [GRVItem_PackSize]*[GRVItem_Quantity] AS grvQuantity, 0 AS saleQuantity, 0 AS shrinkQuantity FROM (((aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aStockItem ON aGRVItem.GRVItem_StockItemID = aStockItem.StockItemID) INNER JOIN DayEndStockItemLnk ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aSale INNER JOIN aSaleItem ON aSale.SaleID = aSaleItem.SaleItem_SaleID "
				sql = sql & "GROUP BY aGRVItem.GRVItem_StockItemID, aStockItem.StockItem_Name, [GRVItem_PackSize]*[GRVItem_Quantity], 0, 0, aGRVItem.GRVItem_Return, aGRV.GRV_GRVStatusID HAVING (((aGRVItem.GRVItem_Return)=0) AND ((aGRV.GRV_GRVStatusID)=3));"
				cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
				moveItem()
				'6
				'sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aGRVItem.GRVItem_StockItemID AS stockitem, aStockItem.StockItem_Name AS name, 0-([GRVItem_PackSize]*[GRVItem_Quantity]) AS grvQuantity, 0 AS saleQuantity, 0 AS shrinkQuantity FROM aStockItem INNER JOIN (DayEndStockItemLnk INNER JOIN (aSale INNER JOIN ((aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) ON aSale.Sale_DayEndID = DayEnd.DayEndID) ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = DayEnd.DayEndID) ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID Where (((aGRVItem.GRVItem_Return) <> 0) And ((aGRV.GRV_GRVStatusID) = 3)) "
				'sql = sql & "GROUP BY aGRVItem.GRVItem_StockItemID, aStockItem.StockItem_Name, 0-([GRVItem_PackSize]*[GRVItem_Quantity]), 0, 0;"
				'lines commented
				'query have problem when tested on Garlito's DB it was messing up StockItemID, GRV quantity
				sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aGRVItem.GRVItem_StockItemID AS stockItem, aStockItem.StockItem_Name as name, 0-([GRVItem_PackSize]*[GRVItem_Quantity]) AS grvQuantity, 0 AS saleQuantity, 0 AS shrinkQuantity FROM (((aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aStockItem ON aGRVItem.GRVItem_StockItemID = aStockItem.StockItemID) INNER JOIN DayEndStockItemLnk ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aSale INNER JOIN aSaleItem ON aSale.SaleID = aSaleItem.SaleItem_SaleID "
				sql = sql & "GROUP BY aGRVItem.GRVItem_StockItemID, aStockItem.StockItem_Name, [GRVItem_PackSize]*[GRVItem_Quantity], 0, 0, aGRVItem.GRVItem_Return, aGRV.GRV_GRVStatusID HAVING (((aGRVItem.GRVItem_Return)<>0) AND ((aGRV.GRV_GRVStatusID)=3));"
				cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
				moveItem()
			End If
			
			'7
			'Multi Warehouse change     sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) As FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0 AS saleQuantity, DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink AS shrinkQuantity FROM ((DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) INNER JOIN aSale ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aSale.Sale_DayEndID GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0, DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink HAVING (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink)<>0));"
			sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) As FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0 AS saleQuantity, DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink AS shrinkQuantity FROM ((DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) INNER JOIN aSale ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aSale.Sale_DayEndID GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0, DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse "
			sql = sql & "HAVING (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink)<>0) AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & lMWNo & "));"
			cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
			moveItem()
			
			'DayEndStockItemLnk_QuantityTransafer
			'8
			sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) As FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0 AS saleQuantity, 0 AS shrinkQuantity, DayEndStockItemLnk.DayEndStockItemLnk_QuantityTransafer AS xferQuantity  FROM ((DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) INNER JOIN aSale ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aSale.Sale_DayEndID GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0, 0, DayEndStockItemLnk.DayEndStockItemLnk_QuantityTransafer, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse "
			sql = sql & "HAVING (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityTransafer)<>0) AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & lMWNo & "));"
			cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
			moveItem()
fetchData: 
			System.Windows.Forms.Application.DoEvents()
			rsStock = getRSreport("SELECT 0 AS posname, FirstOfDayEndStockItemLnk_Quantity, stockitem, name, Sum(grvQuantity) AS grvQuantity, Sum(saleQuantity) AS saleQuantity, Sum(shrinkQuantity) AS shrinkQuantity, Sum(xferQuantity) AS xferQuantity FROM stockQuantitySumTemp GROUP BY 0, FirstOfDayEndStockItemLnk_Quantity, stockitem, name;")
			If rsStock.RecordCount Then
				Do While rsStock.EOF = False
					System.Windows.Forms.Application.DoEvents()
					rsData = getRSreport("SELECT First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity From DayEndStockItemLnk GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse HAVING (((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & lMWNo & ") AND ((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & rsStock.Fields("stockitem").Value & "));")
					If rsData.RecordCount Then
						cnnDBreport.Execute("UPDATE stockQuantitySumTemp SET stockQuantitySumTemp.FirstOfDayEndStockItemLnk_Quantity = " & rsData.Fields("FirstOfDayEndStockItemLnk_Quantity").Value & " WHERE stockQuantitySumTemp.stockitem = " & rsStock.Fields("stockitem").Value & ";")
					End If
					System.Windows.Forms.Application.DoEvents()
					rsStock.moveNext()
					moveItem()
				Loop 
			Else
				'9
				sql = "SELECT 'No Movement' AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0 AS saleQuantity, 0 AS shrinkQuantity, 0 AS xferQuantity FROM (DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0, 0, DayEndStockItemLnk.DayEndStockItemLnk_Quantity, 0, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse "
				sql = sql & "HAVING (((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & lMWNo & "));"
				cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
				GoTo fetchData
			End If
			sql = "SELECT 0 AS posname, FirstOfDayEndStockItemLnk_Quantity, stockitem, name, Sum(grvQuantity) AS grvQuantity, Sum(saleQuantity) AS saleQuantity, Sum(shrinkQuantity) AS shrinkQuantity, Sum(xferQuantity) AS xferQuantity FROM stockQuantitySumTemp GROUP BY 0, FirstOfDayEndStockItemLnk_Quantity, stockitem, name;"
			'adding query information in TEMP table, due to less info abt SALES QTY in RECIEPT
			
		Else
			
			'1
			sql = " SELECT [Sale_PosID] & '_' & [Sale_Reference] & '*' AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aStockItem.StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, Sum([SaleItem_Quantity]*[SaleItem_ShrinkQuantity]) AS saleQuantity, 0 AS shrinkQuantity FROM ((aStockItem INNER JOIN SaleItem ON aStockItem.StockItemID = SaleItem.SaleItem_StockItemID) INNER JOIN (DayEnd INNER JOIN Sale ON DayEnd.DayEndID = Sale.Sale_DayEndID) ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN DayEndStockItemLnk ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID"
			sql = sql & rs.Fields("Link_SQL").Value
			sql = sql & " AND (((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_Reversal) = 0) And ((SaleItem.SaleItem_Recipe) = 0))"
			sql = sql & " GROUP BY [Sale_PosID] & '_' & [Sale_Reference] & '*', aStockItem.StockItemID, aStockItem.StockItem_Name, aStockItem.StockItemID Union "
			
			'aSaleItemReciept changed to aSaleItemReciept1
			'query was showing less/wrong info due to less rec in aSaleItemReciept
			'2
			sql = sql & " SELECT [Sale_PosID] & '_' & [Sale_Reference] & '*' AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aSaleItemReciept1.SaleItemReciept_StockitemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, [SaleItemReciept_Quantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM (((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN aSaleItemReciept1 ON SaleItem.SaleItemID = aSaleItemReciept1.SaleItemReciept_SaleItemID) INNER JOIN aStockItem ON aSaleItemReciept1.SaleItemReciept_StockitemID = aStockItem.StockItemID) INNER JOIN DayEndStockItemLnk ON aSaleItemReciept1.SaleItemReciept_StockitemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID"
			'sql = sql & " SELECT [Sale_PosID] & '_' & [Sale_Reference] & '*' AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aSaleItemReciept.SaleItemReciept_StockitemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, [SaleItemReciept_Quantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM (((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN aSaleItemReciept ON SaleItem.SaleItemID = aSaleItemReciept.SaleItemReciept_SaleItemID) INNER JOIN aStockItem ON aSaleItemReciept.SaleItemReciept_StockitemID = aStockItem.StockItemID) INNER JOIN DayEndStockItemLnk ON aSaleItemReciept.SaleItemReciept_StockitemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID"
			sql = sql & rs.Fields("Link_SQL").Value
			sql = sql & " AND  (((SaleItem.SaleItem_Recipe) <> 0) And ((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_Reversal) = 0))"
			sql = sql & " GROUP BY [Sale_PosID] & '_' & [Sale_Reference] & '*', aSaleItemReciept1.SaleItemReciept_StockitemID, aStockItem.StockItem_Name, 0, [SaleItemReciept_Quantity]*[SaleItem_Quantity], 0 Union "
			'sql = sql & " GROUP BY [Sale_PosID] & '_' & [Sale_Reference] & '*', aSaleItemReciept.SaleItemReciept_StockitemID, aStockItem.StockItem_Name, 0, [SaleItemReciept_Quantity]*[SaleItem_Quantity], 0 Union "
			
			'3
			sql = sql & " SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN ((DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) ON SaleItem.SaleItem_StockItemID = aStockItem.StockItemID"
			sql = sql & rs.Fields("Link_SQL").Value
			sql = sql & " and (((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_Reversal) <> 0) And ((SaleItem.SaleItem_Recipe) = 0))"
			sql = sql & " GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity], 0 Union "
			
			'4
			sql = sql & " SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0-[SaleItemReciept_Quantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM ((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN aSaleItemReciept1 ON SaleItem.SaleItemID = aSaleItemReciept1.SaleItemReciept_SaleItemID) INNER JOIN ((DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) ON aSaleItemReciept1.SaleItemReciept_StockitemID = aStockItem.StockItemID "
			'sql = sql & " SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0-[SaleItemReciept_Quantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM ((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN aSaleItemReciept ON SaleItem.SaleItemID = aSaleItemReciept.SaleItemReciept_SaleItemID) INNER JOIN ((DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) ON aSaleItemReciept.SaleItemReciept_StockitemID = aStockItem.StockItemID "
			sql = sql & rs.Fields("Link_SQL").Value
			sql = sql & " AND (((SaleItem.SaleItem_Recipe) <> 0) And ((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_Reversal) <> 0))"
			sql = sql & " GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0-[SaleItemReciept_Quantity]*[SaleItem_Quantity], 0 Union "
			
			'5
			sql = sql & " SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aGRVItem.GRVItem_StockItemID AS stockItem, aStockItem.StockItem_Name, [GRVItem_PackSize]*[GRVItem_Quantity] AS grvQuantity, 0 AS saleQuantity, 0 AS shrinkQuantity FROM (((aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aStockItem ON aGRVItem.GRVItem_StockItemID = aStockItem.StockItemID) INNER JOIN DayEndStockItemLnk ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aSale INNER JOIN aSaleItem ON aSale.SaleID = aSaleItem.SaleItem_SaleID"
			sql = sql & rs.Fields("Link_SQL").Value
			sql = sql & " AND  (((aGRVItem.GRVItem_Return) = 0) And ((aGRV.GRV_GRVStatusID) = 3))"
			sql = sql & " GROUP BY aGRVItem.GRVItem_StockItemID, aStockItem.StockItem_Name, [GRVItem_PackSize]*[GRVItem_Quantity], 0, 0 Union"
			
			'6
			sql = sql & " SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aGRVItem.GRVItem_StockItemID AS stockitem, aStockItem.StockItem_Name AS name, 0-([GRVItem_PackSize]*[GRVItem_Quantity]) AS grvQuantity, 0 AS saleQuantity, 0 AS shrinkQuantity FROM aStockItem INNER JOIN (DayEndStockItemLnk INNER JOIN (aSale INNER JOIN ((aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) ON aSale.Sale_DayEndID = DayEnd.DayEndID) ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = DayEnd.DayEndID) ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID"
			sql = sql & rs.Fields("Link_SQL").Value
			sql = sql & " AND  (((aGRVItem.GRVItem_Return) <> 0) And ((aGRV.GRV_GRVStatusID) = 3))"
			sql = sql & " GROUP BY aGRVItem.GRVItem_StockItemID, aStockItem.StockItem_Name, 0-([GRVItem_PackSize]*[GRVItem_Quantity]), 0, 0 Union "
			
			'7
			sql = sql & " SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) As FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0 AS saleQuantity, DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink AS shrinkQuantity FROM ((DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) INNER JOIN aSale ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aSale.Sale_DayEndID "
			sql = sql & rs.Fields("Link_SQL").Value
			sql = sql & " AND (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0))"
			sql = sql & " GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0, DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink "
			moveItem()
			
			
			'adding query information in TEMP table, due to less info abt SALES QTY in RECIEPT
			sql = ""
			cnnDBreport.Execute("DELETE * FROM stockQuantitySumTemp;")
			'1
			'sql = "SELECT [Sale_PosID] & '_' & [Sale_Reference] & '*' AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aStockItem.StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, Sum([SaleItem_Quantity]*[SaleItem_ShrinkQuantity]) AS saleQuantity, 0 AS shrinkQuantity FROM ((aStockItem INNER JOIN SaleItem ON aStockItem.StockItemID = SaleItem.SaleItem_StockItemID) INNER JOIN (DayEnd INNER JOIN Sale ON DayEnd.DayEndID = Sale.Sale_DayEndID) ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN DayEndStockItemLnk ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AND SaleItem.SaleItem_WarehouseID = DayEndStockItemLnk.DayEndStockItemLnk_Warehouse "
			sql = "SELECT [Sale_PosID] & '_' & [Sale_Reference] & '*' AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aStockItem.StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, Sum([SaleItem_Quantity]*[SaleItem_ShrinkQuantity]) AS saleQuantity, 0 AS shrinkQuantity FROM ((aStockItem INNER JOIN SaleItem ON aStockItem.StockItemID = SaleItem.SaleItem_StockItemID) INNER JOIN (DayEnd INNER JOIN Sale ON DayEnd.DayEndID = Sale.Sale_DayEndID) ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN DayEndStockItemLnk ON (DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) AND (SaleItem.SaleItem_WarehouseID = DayEndStockItemLnk.DayEndStockItemLnk_Warehouse) AND (aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)"
			sql = sql & rs.Fields("Link_SQL").Value
			'Multi Warehouse change     sql = sql & " AND (((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_Reversal) = 0) And ((SaleItem.SaleItem_Recipe) = 0))"
			sql = sql & " AND (((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_Reversal) = 0) And ((SaleItem.SaleItem_Recipe) = 0) AND ((SaleItem.SaleItem_WarehouseID)=" & lMWNo & "))"
			sql = sql & "GROUP BY [Sale_PosID] & '_' & [Sale_Reference] & '*', aStockItem.StockItemID, aStockItem.StockItem_Name, aStockItem.StockItemID;"
			Debug.Print(sql)
			cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
			moveItem()
			
			'2
			sql = "SELECT [Sale_PosID] & '_' & [Sale_Reference] & '*' AS posname, (SELECT First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) FROM DayEndStockItemLnk WHERE aSaleItemReciept1.SaleItemReciept_StockitemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) AS FirstOfDayEndStockItemLnk_Quantity, aSaleItemReciept1.SaleItemReciept_StockitemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, [SaleItemReciept_Quantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity "
			sql = sql & "FROM (((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN aSaleItemReciept1 ON SaleItem.SaleItemID = aSaleItemReciept1.SaleItemReciept_SaleItemID) INNER JOIN DayEnd ON Sale.Sale_DayEndID = DayEnd.DayEndID) INNER JOIN aStockItem ON aSaleItemReciept1.SaleItemReciept_StockitemID = aStockItem.StockItemID "
			'sql = sql & "WHERE (((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)=0));"
			sql = sql & rs.Fields("Link_SQL").Value
			'Multi Warehouse change     sql = sql & " AND  (((SaleItem.SaleItem_Recipe) <> 0) And ((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_Reversal) = 0))"
			sql = sql & " AND  (((SaleItem.SaleItem_Recipe) <> 0) And ((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_Reversal) = 0) AND ((SaleItem.SaleItem_WarehouseID)=" & lMWNo & "))"
			cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
			moveItem()
			
			'3
			sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN ((DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) ON SaleItem.SaleItem_StockItemID = aStockItem.StockItemID "
			sql = sql & rs.Fields("Link_SQL").Value
			'Multi Warehouse change     sql = sql & " and (((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_Reversal) <> 0) And ((SaleItem.SaleItem_Recipe) = 0))"
			sql = sql & " and (((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_Reversal) <> 0) And ((SaleItem.SaleItem_Recipe) = 0) AND ((SaleItem.SaleItem_WarehouseID)=" & lMWNo & "))"
			sql = sql & "GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity], 0, SaleItem.SaleItem_Revoke, SaleItem.SaleItem_Reversal, SaleItem.SaleItem_Recipe;"
			cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
			Debug.Print(sql)
			moveItem()
			
			'4
			sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0-[SaleItemReciept_Quantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM ((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN aSaleItemReciept1 ON SaleItem.SaleItemID = aSaleItemReciept1.SaleItemReciept_SaleItemID) INNER JOIN ((DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) ON aSaleItemReciept1.SaleItemReciept_StockitemID = aStockItem.StockItemID "
			sql = sql & rs.Fields("Link_SQL").Value
			'Multi Warehouse change     sql = sql & " AND (((SaleItem.SaleItem_Recipe) <> 0) And ((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_Reversal) <> 0))"
			sql = sql & " AND (((SaleItem.SaleItem_Recipe) <> 0) And ((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_Reversal) <> 0) AND ((SaleItem.SaleItem_WarehouseID)=" & lMWNo & "))"
			sql = sql & "GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0-[SaleItemReciept_Quantity]*[SaleItem_Quantity], 0, SaleItem.SaleItem_Recipe, SaleItem.SaleItem_Revoke, SaleItem.SaleItem_Reversal;"
			cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
			Debug.Print(sql)
			moveItem()
			
			If lMWNo = 2 Then
				'5
				sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aGRVItem.GRVItem_StockItemID AS stockItem, aStockItem.StockItem_Name as name, [GRVItem_PackSize]*[GRVItem_Quantity] AS grvQuantity, 0 AS saleQuantity, 0 AS shrinkQuantity FROM (((aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aStockItem ON aGRVItem.GRVItem_StockItemID = aStockItem.StockItemID) INNER JOIN DayEndStockItemLnk ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aSale INNER JOIN aSaleItem ON aSale.SaleID = aSaleItem.SaleItem_SaleID "
				sql = sql & rs.Fields("Link_SQL").Value
				sql = sql & " AND  (((aGRVItem.GRVItem_Return) = 0) And ((aGRV.GRV_GRVStatusID) = 3))"
				sql = sql & "GROUP BY aGRVItem.GRVItem_StockItemID, aStockItem.StockItem_Name, [GRVItem_PackSize]*[GRVItem_Quantity], 0, 0, aGRVItem.GRVItem_Return, aGRV.GRV_GRVStatusID;"
				cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
				Debug.Print(sql)
				moveItem()
				'6
				'sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aGRVItem.GRVItem_StockItemID AS stockitem, aStockItem.StockItem_Name AS name, 0-([GRVItem_PackSize]*[GRVItem_Quantity]) AS grvQuantity, 0 AS saleQuantity, 0 AS shrinkQuantity FROM aStockItem INNER JOIN (DayEndStockItemLnk INNER JOIN (aSale INNER JOIN ((aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) ON aSale.Sale_DayEndID = DayEnd.DayEndID) ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = DayEnd.DayEndID) ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID "
				'sql = sql & rs("Link_SQL")
				'sql = sql & " AND  (((aGRVItem.GRVItem_Return) <> 0) And ((aGRV.GRV_GRVStatusID) = 3))"
				'sql = sql & "GROUP BY aGRVItem.GRVItem_StockItemID, aStockItem.StockItem_Name, 0-([GRVItem_PackSize]*[GRVItem_Quantity]), 0, 0;"
				'lines commented
				'query have problem when tested on Garlito's DB it was messing up StockItemID, GRV quantity
				sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity, aGRVItem.GRVItem_StockItemID AS stockItem, aStockItem.StockItem_Name as name, 0-([GRVItem_PackSize]*[GRVItem_Quantity]) AS grvQuantity, 0 AS saleQuantity, 0 AS shrinkQuantity FROM (((aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aStockItem ON aGRVItem.GRVItem_StockItemID = aStockItem.StockItemID) INNER JOIN DayEndStockItemLnk ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aSale INNER JOIN aSaleItem ON aSale.SaleID = aSaleItem.SaleItem_SaleID "
				sql = sql & rs.Fields("Link_SQL").Value
				sql = sql & " AND  (((aGRVItem.GRVItem_Return) <> 0) And ((aGRV.GRV_GRVStatusID) = 3))"
				sql = sql & "GROUP BY aGRVItem.GRVItem_StockItemID, aStockItem.StockItem_Name, 0-([GRVItem_PackSize]*[GRVItem_Quantity]), 0, 0;"
				cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
				Debug.Print(sql)
				moveItem()
			End If
			
			'7
			sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) As FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0 AS saleQuantity, DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink AS shrinkQuantity FROM ((DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) INNER JOIN aSale ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aSale.Sale_DayEndID "
			sql = sql & rs.Fields("Link_SQL").Value
			'Multi Warehouse change     sql = sql & " AND (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0))"
			sql = sql & " AND (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0) AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & lMWNo & "))"
			sql = sql & " GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0, DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink "
			cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
			Debug.Print(sql)
			moveItem()
			
			'DayEndStockItemLnk_QuantityTransafer
			'8
			sql = "SELECT First([Sale_PosID] & '_' & [Sale_Reference] & '*') AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) As FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0 AS saleQuantity, 0 AS shrinkQuantity, DayEndStockItemLnk.DayEndStockItemLnk_QuantityTransafer AS xferQuantity FROM ((DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) INNER JOIN aSale ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aSale.Sale_DayEndID "
			sql = sql & rs.Fields("Link_SQL").Value
			'Multi Warehouse change     sql = sql & " AND (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0))"
			sql = sql & " AND (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityTransafer) <> 0) AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & lMWNo & "))"
			sql = sql & " GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0, 0, DayEndStockItemLnk.DayEndStockItemLnk_QuantityTransafer "
			cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
			Debug.Print(sql)
			moveItem()
			
fetchDataF: 
			System.Windows.Forms.Application.DoEvents()
			rsStock = getRSreport("SELECT 0 AS posname, FirstOfDayEndStockItemLnk_Quantity, stockitem, name, Sum(grvQuantity) AS grvQuantity, Sum(saleQuantity) AS saleQuantity, Sum(shrinkQuantity) AS shrinkQuantity, Sum(xferQuantity) AS xferQuantity FROM stockQuantitySumTemp GROUP BY 0, FirstOfDayEndStockItemLnk_Quantity, stockitem, name;")
			If rsStock.RecordCount Then
				Do While rsStock.EOF = False
					System.Windows.Forms.Application.DoEvents()
					rsData = getRSreport("SELECT First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity From DayEndStockItemLnk GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse HAVING (((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & lMWNo & ") AND ((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & rsStock.Fields("stockitem").Value & "));")
					If rsData.RecordCount Then
						cnnDBreport.Execute("UPDATE stockQuantitySumTemp SET stockQuantitySumTemp.FirstOfDayEndStockItemLnk_Quantity = " & rsData.Fields("FirstOfDayEndStockItemLnk_Quantity").Value & " WHERE stockQuantitySumTemp.stockitem = " & rsStock.Fields("stockitem").Value & ";")
					End If
					System.Windows.Forms.Application.DoEvents()
					rsStock.moveNext()
					moveItem()
				Loop 
			Else
				'9
				sql = "SELECT 'No Movement' AS posname, First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) As FirstOfDayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, aStockItem.StockItem_Name AS name, 0 AS grvQuantity, 0 AS saleQuantity, 0 AS shrinkQuantity, 0 AS xferQuantity FROM (DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID "
				sql = sql & rs.Fields("Link_SQL").Value
				'Multi Warehouse change     sql = sql & " AND (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0))"
				sql = sql & " AND (((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & lMWNo & "))"
				sql = sql & " GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem.StockItem_Name, 0, 0, 0, 0 "
				cnnDBreport.Execute("INSERT INTO stockQuantitySumTemp " & sql)
				GoTo fetchDataF
			End If
			sql = "SELECT 0 AS posname, FirstOfDayEndStockItemLnk_Quantity, stockitem, name, Sum(grvQuantity) AS grvQuantity, Sum(saleQuantity) AS saleQuantity, Sum(shrinkQuantity) AS shrinkQuantity, Sum(xferQuantity) AS xferQuantity FROM stockQuantitySumTemp GROUP BY 0, FirstOfDayEndStockItemLnk_Quantity, stockitem, name;"
			'adding query information in TEMP table, due to less info abt SALES QTY in RECIEPT
			moveItem()
			
		End If
		rs = getRSreport(sql)
		
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
End Class