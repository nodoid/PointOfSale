Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmStockSales
	Inherits System.Windows.Forms.Form
	Public reportType As Short
    Dim WithEvents optType As New List(Of RadioButton)
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2211 'Stock Item Sales Listing|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2212 'Group Report By|Checked
		If rsLang.RecordCount Then _lbl_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1776 'Supplier|Checked
		If rsLang.RecordCount Then optType(1).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : optType(1).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1021 'Pricing Group|Checked
		If rsLang.RecordCount Then optType(2).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : optType(2).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1022 'Stock Group|Checked
		If rsLang.RecordCount Then optType(3).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : optType(3).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2145 'Shrink Size|Checked
		If rsLang.RecordCount Then optType(4).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : optType(4).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2217 'Stock Item (Filter)|Checked
		If rsLang.RecordCount Then optType(0).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : optType(0).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2218 'Filter (For Stock Item)|Checked
		If rsLang.RecordCount Then _lbl_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1006 'Filter|Checked
		If rsLang.RecordCount Then cmdGroup.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdGroup.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1269 'Load Report|Checked
		If rsLang.RecordCount Then cmdLoad.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdLoad.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmStockSales.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
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
	
	
	Private Sub loadStockSales(ByRef ltype As Short)
		Dim rs As Object
		Dim rsSales As ADODB.Recordset
		Dim rsStock As ADODB.Recordset
		Dim rsGroup As ADODB.Recordset
		Dim sql As String
		Dim rsData As ADODB.Recordset
        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As CrystalDecisions.CrystalReports.Engine.ReportDocument
		ReportNone.Load("cryNoRecords.rpt")
		Dim lOrder As String
		Select Case reportType
			Case 0
                Report.Load("cryStockSales.rpt")
			Case 1
                Report.Load("cryStockSalesCompare.rpt")
		End Select
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs("Company_Name"))
        Report.SetParameterValue("txtDayEnd", rs("Report_Heading"))
		rs.Close()
		rs = getRSreport("SELECT * FROM Link Where LinkID=2 AND Link_SectionID=1")
		sql = "SELECT aStockItem.StockItemID, aStockItem.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity FROM aStockItem INNER JOIN (SELECT SaleItem.SaleItem_StockItemID, Sum([SaleItem_Price]*[SaleItem_Quantity]) AS inclusiveSum, Sum(([SaleItem_Price]/(1+([SaleItem_Vat]/100))*[SaleItem_Quantity])) AS exclusiveSum, Sum([SaleItem_DepositCost]*[SaleItem_Quantity]) AS depositSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_Quantity],[SaleItem_Quantity])*[SaleItem_ShrinkQuantity]) AS quantitySum, Sum([SaleItem_ListCost]*[SaleItem_Quantity]) AS listCostSum, Sum([SaleItem_actualCost]*[SaleItem_Quantity]) AS actualCostSum "
		sql = sql & "FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID "
		Select Case ltype
			Case 0
                Report.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString & " by Stock Item")
                Report.SetParameterValue("txtFilter", Replace(rs("Link_Name"), "''", "'"))
                Report.SetParameterValue("txtGroup", "Stock Item")
				
				sql = "SELECT aStockItem.StockItemID AS GroupID, Sum(stockSales.inclusive) AS inclusive, Sum(stockSales.exclusive) AS exclusive, Sum(stockSales.content) AS content, Sum(stockSales.listProfit) AS listProfit, Sum(stockSales.actualProfit) AS actualProfit, Sum(stockSales.quantity) AS quantity, Sum(stockSales.listCost) AS listCost, Sum(stockSales.actualCost) AS actualCost, Sum(stockSales.depositSum) AS depositSum, Sum(stockSales.listGP) AS listGP, Sum(stockSales.actualGP) AS actualGP "
				sql = sql & "FROM aStockItem INNER JOIN (SELECT SaleItem.SaleItem_StockItemID, Sum([SaleItem_Price]*[SaleItem_Quantity]) AS inclusive, Sum(([SaleItem_Price]/(1+([SaleItem_Vat]/100))*[SaleItem_Quantity])) AS exclusive, Sum((([SaleItem_Price]/(1+([SaleItem_Vat]/100))-[SaleItem_DepositCost])*[SaleItem_Quantity])) AS content, Sum((([SaleItem_Price]/(1+([SaleItem_Vat]/100))-[SaleItem_DepositCost]-[SaleItem_ListCost])*[SaleItem_Quantity])) AS listProfit, Sum((([SaleItem_Price]/(1+([SaleItem_Vat]/100))-[SaleItem_DepositCost]-[SaleItem_ActualCost])*[SaleItem_Quantity])) AS actualProfit, Sum(IIf([SaleItem_Reversal],0-[SaleItem_Quantity],[SaleItem_Quantity])*[SaleItem_ShrinkQuantity]) AS quantity, Sum([SaleItem_ListCost]*[SaleItem_Quantity]) AS listCost, Sum([SaleItem_actualCost]*[SaleItem_Quantity]) AS actualCost, Sum([SaleItem_DepositCost]*[SaleItem_Quantity]) AS depositSum, Sum(0) AS listGP, Sum(0) AS actualGP FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN "
				sql = sql & "(Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY SaleItem.SaleItem_StockItemID) AS stockSales ON aStockItem.StockItemID = stockSales.SaleItem_StockItemID GROUP BY aStockItem.StockItemID;"
				sql = "SELECT aStockItem.StockItemID AS GroupID, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]) AS content, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]-[StockList]![listCostSum]) AS listProfit, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]-[StockList]![actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(StockList.depositSum) AS depositSum FROM StockList INNER JOIN aStockItem ON StockList.SaleItem_StockItemID = aStockItem.StockItemID GROUP BY aStockItem.StockItemID;"
				
				rsSales = getRSreport(sql)
				
				sql = "SELECT stockOpen.StockItemID AS GroupID, Sum(stockOpen.openQty) AS openQty, Sum(stockOpen.openList) AS openList, Sum(stockOpen.openActual) AS openActual, Sum(stockClose.closeList) AS closeList, Sum(stockClose.closeActual) AS closeActual, Sum(stockClose.closeQty) AS closeQty, Sum(stockMovement.listSales) AS listSales, Sum(stockMovement.listShrink) AS listShrink, Sum(stockMovement.listGRV) AS listGRV, Sum(stockMovement.actualSales) AS actualSales, Sum(stockMovement.actualShrink) AS actualShrink, Sum(stockMovement.actualGRV) AS actualGRV, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantitySales) AS SumOfDayEndStockItemLnk_QuantitySales, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantityGRV) AS SumOfDayEndStockItemLnk_QuantityGRV "
				sql = sql & "FROM (SELECT aStockItem.StockItemID, IIf(IsNull([openQtyTot]),0,[openQtyTot]) AS openQty, IIf(IsNull([openListTot]),0,[openListTot]) AS openList, IIf(IsNull([openActualTot]),0 "
				sql = sql & ",[openActualTot]) AS openActual FROM aStockItem LEFT JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, DayEndStockItemLnk.DayEndStockItemLnk_Quantity AS openQtyTot, [DayEndStockItemLnk.DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk!DayEndStockItemLnk_ListCost] AS openListTot, [DayEndStockItemLnk!DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk!DayEndStockItemLnk_ActualCost] AS openActualTot FROM DayEndStockItemLnk INNER JOIN Report ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Report.Report_DayEndStartID) AS [%$##@_Alias] ON aStockItem.StockItemID = [%$##@_Alias].DayEndStockItemLnk_StockItemID) AS stockOpen RIGHT JOIN ((aStockItem INNER JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, Sum(([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost])) AS listSales, Sum(([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost])) AS listShrink, "
				sql = sql & "Sum(([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost])) AS listGRV, Sum(([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_actualCost])) AS actualSales, Sum(([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_actualCost])) AS actualShrink, Sum(([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_actualCost])) AS actualGRV, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales) AS SumOfDayEndStockItemLnk_QuantitySales, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV) AS SumOfDayEndStockItemLnk_QuantityGRV From DayEndStockItemLnk GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) AS stockMovement ON aStockItem.StockItemID = stockMovement.DayEndStockItemLnk_StockItemID) INNER JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, "
				sql = sql & "([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ListCost] AS closeList, ([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ActualCost] AS closeActual, ([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV]) AS closeQty FROM Report INNER JOIN DayEndStockItemLnk ON Report.Report_DayEndEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) AS stockClose ON aStockItem.StockItemID = stockClose.DayEndStockItemLnk_StockItemID) ON stockOpen.StockItemID = aStockItem.StockItemID GROUP BY stockOpen.StockItemID;"
				
				rsStock = getRSreport(sql)
				
				If rs("Link_SQL") = "" Then
                    Report.ReportDefinition.Sections("Section2").SectionFormat.EnableSuppress = True
					sql = ""
				Else
					sql = rs("Link_SQL")
				End If
				
				rsGroup = getRSreport("SELECT aStockItem.StockItemID AS groupID, aStockItem.StockItem_Name AS groupName From aStockItem " & sql & " ORDER BY aStockItem.StockItem_Name;")
			Case 4
                Report.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString & " by Shrink")
                Report.SetParameterValue("txtGroup", "Shrink")
                Report.ReportDefinition.Sections("Section2").SectionFormat.EnableSuppress = True
				sql = "SELECT aStockItem.StockItem_ShrinkID AS GroupID, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]) AS content, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]-[StockList]![listCostSum]) AS listProfit, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]-[StockList]![actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(StockList.depositSum) AS depositSum FROM StockList INNER JOIN aStockItem ON StockList.SaleItem_StockItemID = aStockItem.StockItemID GROUP BY aStockItem.StockItem_ShrinkID;"
				rsSales = getRSreport(sql)
				
				sql = "SELECT aStockItem.StockItem_ShrinkID AS GroupID, Sum(stockOpen.openQty) AS openQty, Sum(stockOpen.openList) AS openList, Sum(stockOpen.openActual) AS openActual, Sum(stockClose.closeList) AS closeList, Sum(stockClose.closeActual) AS closeActual, Sum(stockClose.closeQty) AS closeQty, Sum(stockMovement.listSales) AS listSales, Sum(stockMovement.listShrink) AS listShrink, Sum(stockMovement.listGRV) AS listGRV, Sum(stockMovement.actualSales) AS actualSales, Sum(stockMovement.actualShrink) AS actualShrink, Sum(stockMovement.actualGRV) AS actualGRV, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantitySales) AS SumOfDayEndStockItemLnk_QuantitySales, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantityGRV) AS SumOfDayEndStockItemLnk_QuantityGRV "
				sql = sql & "FROM (SELECT aStockItem.StockItemID, IIf(IsNull([openQtyTot]),0,[openQtyTot]) AS openQty, IIf(IsNull([openListTot]),0,[openListTot]) AS openList, IIf(IsNull([openActualTot]),0,[openActualTot]) AS openActual "
				sql = sql & "FROM aStockItem LEFT JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, DayEndStockItemLnk.DayEndStockItemLnk_Quantity AS openQtyTot, [DayEndStockItemLnk.DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk!DayEndStockItemLnk_ListCost] AS openListTot, [DayEndStockItemLnk!DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk!DayEndStockItemLnk_ActualCost] AS openActualTot FROM DayEndStockItemLnk "
				sql = sql & "INNER JOIN Report ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Report.Report_DayEndStartID) AS [%$##@_Alias] ON aStockItem.StockItemID = [%$##@_Alias].DayEndStockItemLnk_StockItemID) AS stockOpen RIGHT JOIN ((aStockItem INNER JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, Sum(([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost])) AS listSales, Sum(([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost])) AS listShrink, Sum(([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost])) AS listGRV, Sum(([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_actualCost])) AS actualSales, Sum(([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_actualCost])) AS actualShrink, Sum(([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_actualCost])) AS actualGRV, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales) AS SumOfDayEndStockItemLnk_QuantitySales, "
				sql = sql & "Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV) AS SumOfDayEndStockItemLnk_QuantityGRV From DayEndStockItemLnk GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) AS stockMovement ON aStockItem.StockItemID = stockMovement.DayEndStockItemLnk_StockItemID) INNER JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, ([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ListCost] AS closeList, ([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ActualCost] AS closeActual, ([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV]) AS closeQty FROM Report INNER JOIN DayEndStockItemLnk ON "
				sql = sql & "Report.Report_DayEndEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) AS stockClose ON aStockItem.StockItemID = stockClose.DayEndStockItemLnk_StockItemID) ON stockOpen.StockItemID = aStockItem.StockItemID GROUP BY aStockItem.StockItem_ShrinkID;"
				
				rsStock = getRSreport(sql)
				
				rsGroup = getRSreport("SELECT aShrink.ShrinkID AS groupID, aShrink.Shrink_Name AS groupName From aShrink ORDER BY aShrink.Shrink_Name;")
			Case 3
                Report.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString & " by Stock Group")
                Report.SetParameterValue("txtGroup", "Stock Group")
                Report.ReportDefinition.Sections("Section2").SectionFormat.EnableSuppress = True
				sql = "SELECT aStockItem.StockItem_StockGroupID AS GroupID, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]) AS content, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]-[StockList]![listCostSum]) AS listProfit, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]-[StockList]![actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(StockList.depositSum) AS depositSum FROM StockList INNER JOIN aStockItem ON StockList.SaleItem_StockItemID = aStockItem.StockItemID GROUP BY aStockItem.StockItem_StockGroupID;"
				rsSales = getRSreport(sql)
				
				sql = "SELECT aStockItem.StockItem_StockGroupID AS GroupID, Sum(stockOpen.openQty) AS openQty, Sum(stockOpen.openList) AS openList, Sum(stockOpen.openActual) AS openActual, Sum(stockClose.closeList) AS closeList, Sum(stockClose.closeActual) AS closeActual, Sum(stockClose.closeQty) AS closeQty, Sum(stockMovement.listSales) AS listSales, Sum(stockMovement.listShrink) AS listShrink, Sum(stockMovement.listGRV) AS listGRV, Sum(stockMovement.actualSales) AS actualSales, Sum(stockMovement.actualShrink) AS actualShrink, Sum(stockMovement.actualGRV) AS actualGRV, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantitySales) AS SumOfDayEndStockItemLnk_QuantitySales, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantityGRV) AS SumOfDayEndStockItemLnk_QuantityGRV "
				sql = sql & "FROM (SELECT aStockItem.StockItemID, IIf(IsNull([openQtyTot]),0,[openQtyTot]) AS openQty, IIf(IsNull([openListTot]),0,[openListTot]) AS openList, IIf(IsNull([openActualTot]),0,[openActualTot]) AS openActual "
				sql = sql & "FROM aStockItem LEFT JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, DayEndStockItemLnk.DayEndStockItemLnk_Quantity AS openQtyTot, [DayEndStockItemLnk.DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk!DayEndStockItemLnk_ListCost] AS openListTot, [DayEndStockItemLnk!DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk!DayEndStockItemLnk_ActualCost] AS openActualTot FROM DayEndStockItemLnk "
				sql = sql & "INNER JOIN Report ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Report.Report_DayEndStartID) AS [%$##@_Alias] ON aStockItem.StockItemID = [%$##@_Alias].DayEndStockItemLnk_StockItemID) AS stockOpen RIGHT JOIN ((aStockItem INNER JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, Sum(([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost])) AS listSales, Sum(([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost])) AS listShrink, Sum(([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost])) AS listGRV, Sum(([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_actualCost])) AS actualSales, Sum(([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_actualCost])) AS actualShrink, Sum(([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_actualCost])) AS actualGRV, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales) AS SumOfDayEndStockItemLnk_QuantitySales, "
				sql = sql & "Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV) AS SumOfDayEndStockItemLnk_QuantityGRV From DayEndStockItemLnk GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) AS stockMovement ON aStockItem.StockItemID = stockMovement.DayEndStockItemLnk_StockItemID) INNER JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, ([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ListCost] AS closeList, ([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ActualCost] AS closeActual, ([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV]) AS closeQty FROM Report INNER JOIN DayEndStockItemLnk ON "
				sql = sql & "Report.Report_DayEndEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) AS stockClose ON aStockItem.StockItemID = stockClose.DayEndStockItemLnk_StockItemID) ON stockOpen.StockItemID = aStockItem.StockItemID GROUP BY aStockItem.StockItem_StockGroupID;"
				
				rsStock = getRSreport(sql)
				
				rsGroup = getRSreport("SELECT aStockGroup.StockGroupID AS groupID, aStockGroup.StockGroup_Name AS groupName From aStockGroup ORDER BY aStockGroup.StockGroup_Name;")
			Case 2
                Report.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString & " by Pricing Group")
                Report.SetParameterValue("txtGroup", "Pricing Group")
                Report.ReportDefinition.Sections("Section2").SectionFormat.EnableSuppress = True
				sql = "SELECT aStockItem.StockItem_PricingGroupID AS GroupID, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]) AS content, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]-[StockList]![listCostSum]) AS listProfit, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]-[StockList]![actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(StockList.depositSum) AS depositSum FROM StockList INNER JOIN aStockItem ON StockList.SaleItem_StockItemID = aStockItem.StockItemID GROUP BY aStockItem.StockItem_PricingGroupID;"
				rsSales = getRSreport(sql)
				
				sql = "SELECT aStockItem.StockItem_PricingGroupID AS GroupID, Sum(stockOpen.openQty) AS openQty, Sum(stockOpen.openList) AS openList, Sum(stockOpen.openActual) AS openActual, Sum(stockClose.closeList) AS closeList, Sum(stockClose.closeActual) AS closeActual, Sum(stockClose.closeQty) AS closeQty, Sum(stockMovement.listSales) AS listSales, Sum(stockMovement.listShrink) AS listShrink, Sum(stockMovement.listGRV) AS listGRV, Sum(stockMovement.actualSales) AS actualSales, Sum(stockMovement.actualShrink) AS actualShrink, Sum(stockMovement.actualGRV) AS actualGRV, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantitySales) AS SumOfDayEndStockItemLnk_QuantitySales, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantityGRV) AS SumOfDayEndStockItemLnk_QuantityGRV "
				sql = sql & "FROM (SELECT aStockItem.StockItemID, IIf(IsNull([openQtyTot]),0,[openQtyTot]) AS openQty, IIf(IsNull([openListTot]),0,[openListTot]) AS openList, IIf(IsNull([openActualTot]),0,[openActualTot]) AS openActual "
				sql = sql & "FROM aStockItem LEFT JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, DayEndStockItemLnk.DayEndStockItemLnk_Quantity AS openQtyTot, [DayEndStockItemLnk.DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk!DayEndStockItemLnk_ListCost] AS openListTot, [DayEndStockItemLnk!DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk!DayEndStockItemLnk_ActualCost] AS openActualTot FROM DayEndStockItemLnk "
				sql = sql & "INNER JOIN Report ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Report.Report_DayEndStartID) AS [%$##@_Alias] ON aStockItem.StockItemID = [%$##@_Alias].DayEndStockItemLnk_StockItemID) AS stockOpen RIGHT JOIN ((aStockItem INNER JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, Sum(([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost])) AS listSales, Sum(([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost])) AS listShrink, Sum(([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost])) AS listGRV, Sum(([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_actualCost])) AS actualSales, Sum(([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_actualCost])) AS actualShrink, Sum(([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_actualCost])) AS actualGRV, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales) AS SumOfDayEndStockItemLnk_QuantitySales, "
				sql = sql & "Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV) AS SumOfDayEndStockItemLnk_QuantityGRV From DayEndStockItemLnk GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) AS stockMovement ON aStockItem.StockItemID = stockMovement.DayEndStockItemLnk_StockItemID) INNER JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, ([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ListCost] AS closeList, ([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ActualCost] AS closeActual, ([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV]) AS closeQty FROM Report INNER JOIN DayEndStockItemLnk ON "
				sql = sql & "Report.Report_DayEndEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) AS stockClose ON aStockItem.StockItemID = stockClose.DayEndStockItemLnk_StockItemID) ON stockOpen.StockItemID = aStockItem.StockItemID GROUP BY aStockItem.StockItem_PricingGroupID;"
				
				rsStock = getRSreport(sql)
				
				rsGroup = getRSreport("SELECT aPricingGroup.PricingGroupID AS groupID, aPricingGroup.PricingGroup_Name AS groupName From aPricingGroup ORDER BY aPricingGroup.PricingGroup_Name;")
			Case 1
                Report.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString & " by Supplier")
                Report.SetParameterValue("txtGroup", "Supplier")
                Report.ReportDefinition.Sections("Section2").SectionFormat.EnableSuppress = True
				sql = "SELECT aStockItem.StockItem_SupplierID AS GroupID, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]) AS content, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]-[StockList]![listCostSum]) AS listProfit, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]-[StockList]![actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(StockList.depositSum) AS depositSum FROM StockList INNER JOIN aStockItem ON StockList.SaleItem_StockItemID = aStockItem.StockItemID GROUP BY aStockItem.StockItem_SupplierID;"
				rsSales = getRSreport(sql)
				
				sql = "SELECT aStockItem.StockItem_SupplierID AS GroupID, Sum(stockOpen.openQty) AS openQty, Sum(stockOpen.openList) AS openList, Sum(stockOpen.openActual) AS openActual, Sum(stockClose.closeList) AS closeList, Sum(stockClose.closeActual) AS closeActual, Sum(stockClose.closeQty) AS closeQty, Sum(stockMovement.listSales) AS listSales, Sum(stockMovement.listShrink) AS listShrink, Sum(stockMovement.listGRV) AS listGRV, Sum(stockMovement.actualSales) AS actualSales, Sum(stockMovement.actualShrink) AS actualShrink, Sum(stockMovement.actualGRV) AS actualGRV, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantitySales) AS SumOfDayEndStockItemLnk_QuantitySales, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantityGRV) AS SumOfDayEndStockItemLnk_QuantityGRV "
				sql = sql & "FROM (SELECT aStockItem.StockItemID, IIf(IsNull([openQtyTot]),0,[openQtyTot]) AS openQty, IIf(IsNull([openListTot]),0,[openListTot]) AS openList, IIf(IsNull([openActualTot]),0,[openActualTot]) AS openActual "
				sql = sql & "FROM aStockItem LEFT JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, DayEndStockItemLnk.DayEndStockItemLnk_Quantity AS openQtyTot, [DayEndStockItemLnk.DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk!DayEndStockItemLnk_ListCost] AS openListTot, [DayEndStockItemLnk!DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk!DayEndStockItemLnk_ActualCost] AS openActualTot FROM DayEndStockItemLnk "
				sql = sql & "INNER JOIN Report ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Report.Report_DayEndStartID) AS [%$##@_Alias] ON aStockItem.StockItemID = [%$##@_Alias].DayEndStockItemLnk_StockItemID) AS stockOpen RIGHT JOIN ((aStockItem INNER JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, Sum(([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost])) AS listSales, Sum(([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost])) AS listShrink, Sum(([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost])) AS listGRV, Sum(([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_actualCost])) AS actualSales, Sum(([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_actualCost])) AS actualShrink, Sum(([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_actualCost])) AS actualGRV, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales) AS SumOfDayEndStockItemLnk_QuantitySales, "
				sql = sql & "Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV) AS SumOfDayEndStockItemLnk_QuantityGRV From DayEndStockItemLnk GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) AS stockMovement ON aStockItem.StockItemID = stockMovement.DayEndStockItemLnk_StockItemID) INNER JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, ([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ListCost] AS closeList, ([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ActualCost] AS closeActual, ([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV]) AS closeQty FROM Report INNER JOIN DayEndStockItemLnk ON "
				sql = sql & "Report.Report_DayEndEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) AS stockClose ON aStockItem.StockItemID = stockClose.DayEndStockItemLnk_StockItemID) ON stockOpen.StockItemID = aStockItem.StockItemID GROUP BY aStockItem.StockItem_SupplierID;"
				
				rsStock = getRSreport(sql)
				
				rsGroup = getRSreport("SELECT Supplier.SupplierID AS groupID, Supplier.Supplier_Name AS groupName From Supplier ORDER BY Supplier.Supplier_Name;")
				
		End Select
		
		If rsSales.BOF Or rsSales.EOF Then
			ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
			ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
			frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
			frmReportShow.CRViewer1.ReportSource = ReportNone
			frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
			frmReportShow.CRViewer1.Refresh()
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			frmReportShow.ShowDialog()
			Exit Sub
		End If
		
		If rsStock.BOF Or rsStock.EOF Then
			ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
			ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
			frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
			frmReportShow.CRViewer1.ReportSource = ReportNone
			frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
			frmReportShow.CRViewer1.Refresh()
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			frmReportShow.ShowDialog()
			Exit Sub
		End If
		
		If rsGroup.BOF Or rsGroup.EOF Then
			ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
			ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
			frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
			frmReportShow.CRViewer1.ReportSource = ReportNone
			frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
			frmReportShow.CRViewer1.Refresh()
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			frmReportShow.ShowDialog()
			Exit Sub
		End If
		
        Report.Database.Tables(1).SetDataSource(rsSales)
        Report.Database.Tables(2).SetDataSource(rsStock)
        Report.Database.Tables(3).SetDataSource(rsGroup)
		'Report.VerifyOnEveryPrint = True
		'frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
		frmReportShow.CRViewer1.ReportSource = Report
		frmReportShow.mReport = Report : frmReportShow.sMode = "0"
		frmReportShow.CRViewer1.Refresh()
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		frmReportShow.ShowDialog()
		
		
		
	End Sub
	
	Private Sub cmdLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLoad.Click
		Dim x As Short
        For x = 0 To optType.Count
            If optType(x).Checked Then
                loadStockSales(x)
                Exit Sub
            End If
        Next x
		
	End Sub
	
	Private Sub frmStockSales_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub frmStockSales_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        optType.AddRange(New RadioButton() {_optType_0, _optType_1, _optType_2, _optType_3, _
                                           _optType_4})
        loadLanguage()

		setup()
	End Sub
End Class