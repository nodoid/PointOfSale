using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using DpSdkEngLib;
using DPSDKOPSLib;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
 // ERROR: Not supported in C#: OptionDeclaration
using Microsoft.VisualBasic.PowerPacks;
namespace _4PosBackOffice.NET
{
	internal partial class frmStockSales : System.Windows.Forms.Form
	{
		public short reportType;
		List<RadioButton> optType = new List<RadioButton>();
		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2211;
			//Stock Item Sales Listing|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2212;
			//Group Report By|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1776;
			//Supplier|Checked
			if (modRecordSet.rsLang.RecordCount){optType[1].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;optType[1].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1021;
			//Pricing Group|Checked
			if (modRecordSet.rsLang.RecordCount){optType[2].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;optType[2].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1022;
			//Stock Group|Checked
			if (modRecordSet.rsLang.RecordCount){optType[3].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;optType[3].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2145;
			//Shrink Size|Checked
			if (modRecordSet.rsLang.RecordCount){optType[4].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;optType[4].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2217;
			//Stock Item (Filter)|Checked
			if (modRecordSet.rsLang.RecordCount){optType[0].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;optType[0].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2218;
			//Filter (For Stock Item)|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1006;
			//Filter|Checked
			if (modRecordSet.rsLang.RecordCount){cmdGroup.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdGroup.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1269;
			//Load Report|Checked
			if (modRecordSet.rsLang.RecordCount){cmdLoad.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdLoad.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmStockSales.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdGroup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			int lID = 0;
			modReport.cnnDBreport.Execute("DELETE aftDataItem.* From aftDataItem WHERE (((aftDataItem.ftDataItem_PersonID)=" + modRecordSet.gPersonID + "));");
			modReport.cnnDBreport.Execute("DELETE aftData.* From aftData WHERE (((aftData.ftData_PersonID)=" + modRecordSet.gPersonID + "));");
			modReport.cnnDBreport.Execute("INSERT INTO aftData ( ftData_PersonID, ftData_FieldName, ftData_SQL, ftData_Heading ) SELECT LinkData.LinkData_PersonID, LinkData.LinkData_FieldName, LinkData.LinkData_SQL, LinkData.LinkData_Heading From LinkData WHERE (((LinkData.LinkData_LinkID)=2) AND ((LinkData.LinkData_SectionID)=1) AND ((LinkData.LinkData_PersonID)=" + modRecordSet.gPersonID + "));");
			modReport.cnnDBreport.Execute("INSERT INTO aftDataItem ( ftDataItem_PersonID, ftDataItem_FieldName, ftDataItem_ID ) SELECT LinkDataItem.LinkDataItem_PersonID, LinkDataItem.LinkDataItem_FieldName, LinkDataItem.LinkDataItem_ID From LinkDataItem WHERE (((LinkDataItem.LinkDataItem_LinkID)=2) AND ((LinkDataItem.LinkDataItem_SectionID)=1) AND ((LinkDataItem.LinkDataItem_PersonID)=" + modRecordSet.gPersonID + "));");
			My.MyProject.Forms.frmFilter.Close();
			My.MyProject.Forms.frmFilter.buildCriteria(ref "StockItem");
			My.MyProject.Forms.frmFilter.loadFilter(ref "StockItem");
			My.MyProject.Forms.frmFilter.buildCriteria(ref "StockItem");

			modReport.cnnDBreport.Execute("UPDATE Link SET Link.Link_Name = '" + Strings.Replace(My.MyProject.Forms.frmFilter.gHeading, "'", "''") + "', Link.Link_SQL = '" + Strings.Replace(My.MyProject.Forms.frmFilter.gCriteria, "'", "''") + "' WHERE (((Link.LinkID)=2) AND ((Link.Link_SectionID)=1) AND ((Link.Link_PersonID)=" + modRecordSet.gPersonID + "));");
			modReport.cnnDBreport.Execute("DELETE LinkDataItem.* From LinkDataItem WHERE (((LinkDataItem.LinkDataItem_LinkID)=2) AND ((LinkDataItem.LinkDataItem_SectionID)=1) AND ((LinkDataItem.LinkDataItem_PersonID)=" + modRecordSet.gPersonID + "));");
			modReport.cnnDBreport.Execute("DELETE LinkData.* From LinkData WHERE (((LinkData.LinkData_LinkID)=2) AND ((LinkData.LinkData_SectionID)=1) AND ((LinkData.LinkData_PersonID)=" + modRecordSet.gPersonID + "));");
			modReport.cnnDBreport.Execute("INSERT INTO LinkData ( LinkData_LinkID, LinkData_SectionID, LinkData_PersonID, LinkData_FieldName, LinkData_SQL, LinkData_Heading ) SELECT 2, 1, aftData.ftData_PersonID, aftData.ftData_FieldName, aftData.ftData_SQL, aftData.ftData_Heading From aftData WHERE (((aftData.ftData_PersonID)=" + modRecordSet.gPersonID + "));");
			modReport.cnnDBreport.Execute("INSERT INTO LinkDataItem ( LinkDataItem_LinkID, LinkDataItem_SectionID, LinkDataItem_PersonID, LinkDataItem_FieldName, LinkDataItem_ID ) SELECT 2, 1, aftDataItem.ftDataItem_PersonID, aftDataItem.ftDataItem_FieldName, aftDataItem.ftDataItem_ID From aftDataItem WHERE (((aftDataItem.ftDataItem_PersonID)=" + modRecordSet.gPersonID + "));");
			lblGroup.Text = My.MyProject.Forms.frmFilter.gHeading;
		}

		private void setup()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modReport.getRSreport(ref "SELECT Link.Link_PersonID From Link WHERE (((Link.Link_PersonID)=" + modRecordSet.gPersonID + "));");
			if (rs.BOF | rs.EOF) {
				modReport.cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 1, 1, " + modRecordSet.gPersonID + ", '', '';");
				modReport.cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 2, 1, " + modRecordSet.gPersonID + ", '', '';");
				modReport.cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 1, 2, " + modRecordSet.gPersonID + ", '', '';");
				modReport.cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 2, 2, " + modRecordSet.gPersonID + ", '', '';");
				modReport.cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 1, 3, " + modRecordSet.gPersonID + ", '', '';");
				modReport.cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 2, 3, " + modRecordSet.gPersonID + ", '', '';");
				modReport.cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 3, 3, " + modRecordSet.gPersonID + ", '', '';");
				modReport.cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 4, 3, " + modRecordSet.gPersonID + ", '', '';");
				modReport.cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 5, 3, " + modRecordSet.gPersonID + ", '', '';");
				modReport.cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 6, 3, " + modRecordSet.gPersonID + ", '', '';");
				modReport.cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 7, 3, " + modRecordSet.gPersonID + ", '', '';");
				modReport.cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 8, 3, " + modRecordSet.gPersonID + ", '', '';");
				modReport.cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 9, 3, " + modRecordSet.gPersonID + ", '', '';");
				modReport.cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 10, 3, " + modRecordSet.gPersonID + ", '', '';");
			}

			rs = modReport.getRSreport(ref "SELECT Link.Link_Name From Link WHERE (((Link.LinkID)=2) AND ((Link.Link_SectionID)=1) AND ((Link.Link_PersonID)=" + modRecordSet.gPersonID + "));");
			lblGroup.Text = rs.Fields("Link_Name").Value;
		}


		private void loadStockSales(ref short ltype)
		{
			object rs = null;
			ADODB.Recordset rsSales = default(ADODB.Recordset);
			ADODB.Recordset rsStock = default(ADODB.Recordset);
			ADODB.Recordset rsGroup = default(ADODB.Recordset);
			string sql = null;
			ADODB.Recordset rsData = default(ADODB.Recordset);
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = default(CrystalDecisions.CrystalReports.Engine.ReportDocument);
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = default(CrystalDecisions.CrystalReports.Engine.ReportDocument);
			ReportNone.Load("cryNoRecords.rpt");
			string lOrder = null;
			switch (reportType) {
				case 0:
					Report.Load("cryStockSales.rpt");
					break;
				case 1:
					Report.Load("cryStockSalesCompare.rpt");
					break;
			}
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs("Company_Name"));
			Report.SetParameterValue("txtDayEnd", rs("Report_Heading"));
			rs.Close();
			rs = modReport.getRSreport(ref "SELECT * FROM Link Where LinkID=2 AND Link_SectionID=1");
			sql = "SELECT aStockItem.StockItemID, aStockItem.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity FROM aStockItem INNER JOIN (SELECT SaleItem.SaleItem_StockItemID, Sum([SaleItem_Price]*[SaleItem_Quantity]) AS inclusiveSum, Sum(([SaleItem_Price]/(1+([SaleItem_Vat]/100))*[SaleItem_Quantity])) AS exclusiveSum, Sum([SaleItem_DepositCost]*[SaleItem_Quantity]) AS depositSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_Quantity],[SaleItem_Quantity])*[SaleItem_ShrinkQuantity]) AS quantitySum, Sum([SaleItem_ListCost]*[SaleItem_Quantity]) AS listCostSum, Sum([SaleItem_actualCost]*[SaleItem_Quantity]) AS actualCostSum ";
			sql = sql + "FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID ";
			switch (ltype) {
				case 0:
					Report.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString + " by Stock Item");
					Report.SetParameterValue("txtFilter", Strings.Replace(rs("Link_Name"), "''", "'"));
					Report.SetParameterValue("txtGroup", "Stock Item");

					sql = "SELECT aStockItem.StockItemID AS GroupID, Sum(stockSales.inclusive) AS inclusive, Sum(stockSales.exclusive) AS exclusive, Sum(stockSales.content) AS content, Sum(stockSales.listProfit) AS listProfit, Sum(stockSales.actualProfit) AS actualProfit, Sum(stockSales.quantity) AS quantity, Sum(stockSales.listCost) AS listCost, Sum(stockSales.actualCost) AS actualCost, Sum(stockSales.depositSum) AS depositSum, Sum(stockSales.listGP) AS listGP, Sum(stockSales.actualGP) AS actualGP ";
					sql = sql + "FROM aStockItem INNER JOIN (SELECT SaleItem.SaleItem_StockItemID, Sum([SaleItem_Price]*[SaleItem_Quantity]) AS inclusive, Sum(([SaleItem_Price]/(1+([SaleItem_Vat]/100))*[SaleItem_Quantity])) AS exclusive, Sum((([SaleItem_Price]/(1+([SaleItem_Vat]/100))-[SaleItem_DepositCost])*[SaleItem_Quantity])) AS content, Sum((([SaleItem_Price]/(1+([SaleItem_Vat]/100))-[SaleItem_DepositCost]-[SaleItem_ListCost])*[SaleItem_Quantity])) AS listProfit, Sum((([SaleItem_Price]/(1+([SaleItem_Vat]/100))-[SaleItem_DepositCost]-[SaleItem_ActualCost])*[SaleItem_Quantity])) AS actualProfit, Sum(IIf([SaleItem_Reversal],0-[SaleItem_Quantity],[SaleItem_Quantity])*[SaleItem_ShrinkQuantity]) AS quantity, Sum([SaleItem_ListCost]*[SaleItem_Quantity]) AS listCost, Sum([SaleItem_actualCost]*[SaleItem_Quantity]) AS actualCost, Sum([SaleItem_DepositCost]*[SaleItem_Quantity]) AS depositSum, Sum(0) AS listGP, Sum(0) AS actualGP FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN ";
					sql = sql + "(Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY SaleItem.SaleItem_StockItemID) AS stockSales ON aStockItem.StockItemID = stockSales.SaleItem_StockItemID GROUP BY aStockItem.StockItemID;";
					sql = "SELECT aStockItem.StockItemID AS GroupID, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]) AS content, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]-[StockList]![listCostSum]) AS listProfit, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]-[StockList]![actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(StockList.depositSum) AS depositSum FROM StockList INNER JOIN aStockItem ON StockList.SaleItem_StockItemID = aStockItem.StockItemID GROUP BY aStockItem.StockItemID;";

					rsSales = modReport.getRSreport(ref sql);

					sql = "SELECT stockOpen.StockItemID AS GroupID, Sum(stockOpen.openQty) AS openQty, Sum(stockOpen.openList) AS openList, Sum(stockOpen.openActual) AS openActual, Sum(stockClose.closeList) AS closeList, Sum(stockClose.closeActual) AS closeActual, Sum(stockClose.closeQty) AS closeQty, Sum(stockMovement.listSales) AS listSales, Sum(stockMovement.listShrink) AS listShrink, Sum(stockMovement.listGRV) AS listGRV, Sum(stockMovement.actualSales) AS actualSales, Sum(stockMovement.actualShrink) AS actualShrink, Sum(stockMovement.actualGRV) AS actualGRV, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantitySales) AS SumOfDayEndStockItemLnk_QuantitySales, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantityGRV) AS SumOfDayEndStockItemLnk_QuantityGRV ";
					sql = sql + "FROM (SELECT aStockItem.StockItemID, IIf(IsNull([openQtyTot]),0,[openQtyTot]) AS openQty, IIf(IsNull([openListTot]),0,[openListTot]) AS openList, IIf(IsNull([openActualTot]),0 ";
					sql = sql + ",[openActualTot]) AS openActual FROM aStockItem LEFT JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, DayEndStockItemLnk.DayEndStockItemLnk_Quantity AS openQtyTot, [DayEndStockItemLnk.DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk!DayEndStockItemLnk_ListCost] AS openListTot, [DayEndStockItemLnk!DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk!DayEndStockItemLnk_ActualCost] AS openActualTot FROM DayEndStockItemLnk INNER JOIN Report ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Report.Report_DayEndStartID) AS [%$##@_Alias] ON aStockItem.StockItemID = [%$##@_Alias].DayEndStockItemLnk_StockItemID) AS stockOpen RIGHT JOIN ((aStockItem INNER JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, Sum(([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost])) AS listSales, Sum(([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost])) AS listShrink, ";
					sql = sql + "Sum(([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost])) AS listGRV, Sum(([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_actualCost])) AS actualSales, Sum(([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_actualCost])) AS actualShrink, Sum(([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_actualCost])) AS actualGRV, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales) AS SumOfDayEndStockItemLnk_QuantitySales, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV) AS SumOfDayEndStockItemLnk_QuantityGRV From DayEndStockItemLnk GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) AS stockMovement ON aStockItem.StockItemID = stockMovement.DayEndStockItemLnk_StockItemID) INNER JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, ";
					sql = sql + "([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ListCost] AS closeList, ([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ActualCost] AS closeActual, ([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV]) AS closeQty FROM Report INNER JOIN DayEndStockItemLnk ON Report.Report_DayEndEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) AS stockClose ON aStockItem.StockItemID = stockClose.DayEndStockItemLnk_StockItemID) ON stockOpen.StockItemID = aStockItem.StockItemID GROUP BY stockOpen.StockItemID;";

					rsStock = modReport.getRSreport(ref sql);

					if (string.IsNullOrEmpty(rs("Link_SQL"))) {
						Report.ReportDefinition.Sections("Section2").SectionFormat.EnableSuppress = true;
						sql = "";
					} else {
						sql = rs("Link_SQL");
					}

					rsGroup = modReport.getRSreport(ref "SELECT aStockItem.StockItemID AS groupID, aStockItem.StockItem_Name AS groupName From aStockItem " + sql + " ORDER BY aStockItem.StockItem_Name;");
					break;
				case 4:
					Report.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString + " by Shrink");
					Report.SetParameterValue("txtGroup", "Shrink");
					Report.ReportDefinition.Sections("Section2").SectionFormat.EnableSuppress = true;
					sql = "SELECT aStockItem.StockItem_ShrinkID AS GroupID, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]) AS content, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]-[StockList]![listCostSum]) AS listProfit, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]-[StockList]![actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(StockList.depositSum) AS depositSum FROM StockList INNER JOIN aStockItem ON StockList.SaleItem_StockItemID = aStockItem.StockItemID GROUP BY aStockItem.StockItem_ShrinkID;";
					rsSales = modReport.getRSreport(ref sql);

					sql = "SELECT aStockItem.StockItem_ShrinkID AS GroupID, Sum(stockOpen.openQty) AS openQty, Sum(stockOpen.openList) AS openList, Sum(stockOpen.openActual) AS openActual, Sum(stockClose.closeList) AS closeList, Sum(stockClose.closeActual) AS closeActual, Sum(stockClose.closeQty) AS closeQty, Sum(stockMovement.listSales) AS listSales, Sum(stockMovement.listShrink) AS listShrink, Sum(stockMovement.listGRV) AS listGRV, Sum(stockMovement.actualSales) AS actualSales, Sum(stockMovement.actualShrink) AS actualShrink, Sum(stockMovement.actualGRV) AS actualGRV, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantitySales) AS SumOfDayEndStockItemLnk_QuantitySales, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantityGRV) AS SumOfDayEndStockItemLnk_QuantityGRV ";
					sql = sql + "FROM (SELECT aStockItem.StockItemID, IIf(IsNull([openQtyTot]),0,[openQtyTot]) AS openQty, IIf(IsNull([openListTot]),0,[openListTot]) AS openList, IIf(IsNull([openActualTot]),0,[openActualTot]) AS openActual ";
					sql = sql + "FROM aStockItem LEFT JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, DayEndStockItemLnk.DayEndStockItemLnk_Quantity AS openQtyTot, [DayEndStockItemLnk.DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk!DayEndStockItemLnk_ListCost] AS openListTot, [DayEndStockItemLnk!DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk!DayEndStockItemLnk_ActualCost] AS openActualTot FROM DayEndStockItemLnk ";
					sql = sql + "INNER JOIN Report ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Report.Report_DayEndStartID) AS [%$##@_Alias] ON aStockItem.StockItemID = [%$##@_Alias].DayEndStockItemLnk_StockItemID) AS stockOpen RIGHT JOIN ((aStockItem INNER JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, Sum(([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost])) AS listSales, Sum(([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost])) AS listShrink, Sum(([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost])) AS listGRV, Sum(([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_actualCost])) AS actualSales, Sum(([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_actualCost])) AS actualShrink, Sum(([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_actualCost])) AS actualGRV, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales) AS SumOfDayEndStockItemLnk_QuantitySales, ";
					sql = sql + "Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV) AS SumOfDayEndStockItemLnk_QuantityGRV From DayEndStockItemLnk GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) AS stockMovement ON aStockItem.StockItemID = stockMovement.DayEndStockItemLnk_StockItemID) INNER JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, ([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ListCost] AS closeList, ([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ActualCost] AS closeActual, ([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV]) AS closeQty FROM Report INNER JOIN DayEndStockItemLnk ON ";
					sql = sql + "Report.Report_DayEndEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) AS stockClose ON aStockItem.StockItemID = stockClose.DayEndStockItemLnk_StockItemID) ON stockOpen.StockItemID = aStockItem.StockItemID GROUP BY aStockItem.StockItem_ShrinkID;";

					rsStock = modReport.getRSreport(ref sql);

					rsGroup = modReport.getRSreport(ref "SELECT aShrink.ShrinkID AS groupID, aShrink.Shrink_Name AS groupName From aShrink ORDER BY aShrink.Shrink_Name;");
					break;
				case 3:
					Report.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString + " by Stock Group");
					Report.SetParameterValue("txtGroup", "Stock Group");
					Report.ReportDefinition.Sections("Section2").SectionFormat.EnableSuppress = true;
					sql = "SELECT aStockItem.StockItem_StockGroupID AS GroupID, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]) AS content, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]-[StockList]![listCostSum]) AS listProfit, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]-[StockList]![actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(StockList.depositSum) AS depositSum FROM StockList INNER JOIN aStockItem ON StockList.SaleItem_StockItemID = aStockItem.StockItemID GROUP BY aStockItem.StockItem_StockGroupID;";
					rsSales = modReport.getRSreport(ref sql);

					sql = "SELECT aStockItem.StockItem_StockGroupID AS GroupID, Sum(stockOpen.openQty) AS openQty, Sum(stockOpen.openList) AS openList, Sum(stockOpen.openActual) AS openActual, Sum(stockClose.closeList) AS closeList, Sum(stockClose.closeActual) AS closeActual, Sum(stockClose.closeQty) AS closeQty, Sum(stockMovement.listSales) AS listSales, Sum(stockMovement.listShrink) AS listShrink, Sum(stockMovement.listGRV) AS listGRV, Sum(stockMovement.actualSales) AS actualSales, Sum(stockMovement.actualShrink) AS actualShrink, Sum(stockMovement.actualGRV) AS actualGRV, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantitySales) AS SumOfDayEndStockItemLnk_QuantitySales, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantityGRV) AS SumOfDayEndStockItemLnk_QuantityGRV ";
					sql = sql + "FROM (SELECT aStockItem.StockItemID, IIf(IsNull([openQtyTot]),0,[openQtyTot]) AS openQty, IIf(IsNull([openListTot]),0,[openListTot]) AS openList, IIf(IsNull([openActualTot]),0,[openActualTot]) AS openActual ";
					sql = sql + "FROM aStockItem LEFT JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, DayEndStockItemLnk.DayEndStockItemLnk_Quantity AS openQtyTot, [DayEndStockItemLnk.DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk!DayEndStockItemLnk_ListCost] AS openListTot, [DayEndStockItemLnk!DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk!DayEndStockItemLnk_ActualCost] AS openActualTot FROM DayEndStockItemLnk ";
					sql = sql + "INNER JOIN Report ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Report.Report_DayEndStartID) AS [%$##@_Alias] ON aStockItem.StockItemID = [%$##@_Alias].DayEndStockItemLnk_StockItemID) AS stockOpen RIGHT JOIN ((aStockItem INNER JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, Sum(([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost])) AS listSales, Sum(([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost])) AS listShrink, Sum(([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost])) AS listGRV, Sum(([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_actualCost])) AS actualSales, Sum(([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_actualCost])) AS actualShrink, Sum(([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_actualCost])) AS actualGRV, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales) AS SumOfDayEndStockItemLnk_QuantitySales, ";
					sql = sql + "Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV) AS SumOfDayEndStockItemLnk_QuantityGRV From DayEndStockItemLnk GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) AS stockMovement ON aStockItem.StockItemID = stockMovement.DayEndStockItemLnk_StockItemID) INNER JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, ([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ListCost] AS closeList, ([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ActualCost] AS closeActual, ([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV]) AS closeQty FROM Report INNER JOIN DayEndStockItemLnk ON ";
					sql = sql + "Report.Report_DayEndEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) AS stockClose ON aStockItem.StockItemID = stockClose.DayEndStockItemLnk_StockItemID) ON stockOpen.StockItemID = aStockItem.StockItemID GROUP BY aStockItem.StockItem_StockGroupID;";

					rsStock = modReport.getRSreport(ref sql);

					rsGroup = modReport.getRSreport(ref "SELECT aStockGroup.StockGroupID AS groupID, aStockGroup.StockGroup_Name AS groupName From aStockGroup ORDER BY aStockGroup.StockGroup_Name;");
					break;
				case 2:
					Report.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString + " by Pricing Group");
					Report.SetParameterValue("txtGroup", "Pricing Group");
					Report.ReportDefinition.Sections("Section2").SectionFormat.EnableSuppress = true;
					sql = "SELECT aStockItem.StockItem_PricingGroupID AS GroupID, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]) AS content, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]-[StockList]![listCostSum]) AS listProfit, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]-[StockList]![actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(StockList.depositSum) AS depositSum FROM StockList INNER JOIN aStockItem ON StockList.SaleItem_StockItemID = aStockItem.StockItemID GROUP BY aStockItem.StockItem_PricingGroupID;";
					rsSales = modReport.getRSreport(ref sql);

					sql = "SELECT aStockItem.StockItem_PricingGroupID AS GroupID, Sum(stockOpen.openQty) AS openQty, Sum(stockOpen.openList) AS openList, Sum(stockOpen.openActual) AS openActual, Sum(stockClose.closeList) AS closeList, Sum(stockClose.closeActual) AS closeActual, Sum(stockClose.closeQty) AS closeQty, Sum(stockMovement.listSales) AS listSales, Sum(stockMovement.listShrink) AS listShrink, Sum(stockMovement.listGRV) AS listGRV, Sum(stockMovement.actualSales) AS actualSales, Sum(stockMovement.actualShrink) AS actualShrink, Sum(stockMovement.actualGRV) AS actualGRV, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantitySales) AS SumOfDayEndStockItemLnk_QuantitySales, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantityGRV) AS SumOfDayEndStockItemLnk_QuantityGRV ";
					sql = sql + "FROM (SELECT aStockItem.StockItemID, IIf(IsNull([openQtyTot]),0,[openQtyTot]) AS openQty, IIf(IsNull([openListTot]),0,[openListTot]) AS openList, IIf(IsNull([openActualTot]),0,[openActualTot]) AS openActual ";
					sql = sql + "FROM aStockItem LEFT JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, DayEndStockItemLnk.DayEndStockItemLnk_Quantity AS openQtyTot, [DayEndStockItemLnk.DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk!DayEndStockItemLnk_ListCost] AS openListTot, [DayEndStockItemLnk!DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk!DayEndStockItemLnk_ActualCost] AS openActualTot FROM DayEndStockItemLnk ";
					sql = sql + "INNER JOIN Report ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Report.Report_DayEndStartID) AS [%$##@_Alias] ON aStockItem.StockItemID = [%$##@_Alias].DayEndStockItemLnk_StockItemID) AS stockOpen RIGHT JOIN ((aStockItem INNER JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, Sum(([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost])) AS listSales, Sum(([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost])) AS listShrink, Sum(([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost])) AS listGRV, Sum(([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_actualCost])) AS actualSales, Sum(([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_actualCost])) AS actualShrink, Sum(([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_actualCost])) AS actualGRV, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales) AS SumOfDayEndStockItemLnk_QuantitySales, ";
					sql = sql + "Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV) AS SumOfDayEndStockItemLnk_QuantityGRV From DayEndStockItemLnk GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) AS stockMovement ON aStockItem.StockItemID = stockMovement.DayEndStockItemLnk_StockItemID) INNER JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, ([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ListCost] AS closeList, ([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ActualCost] AS closeActual, ([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV]) AS closeQty FROM Report INNER JOIN DayEndStockItemLnk ON ";
					sql = sql + "Report.Report_DayEndEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) AS stockClose ON aStockItem.StockItemID = stockClose.DayEndStockItemLnk_StockItemID) ON stockOpen.StockItemID = aStockItem.StockItemID GROUP BY aStockItem.StockItem_PricingGroupID;";

					rsStock = modReport.getRSreport(ref sql);

					rsGroup = modReport.getRSreport(ref "SELECT aPricingGroup.PricingGroupID AS groupID, aPricingGroup.PricingGroup_Name AS groupName From aPricingGroup ORDER BY aPricingGroup.PricingGroup_Name;");
					break;
				case 1:
					Report.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString + " by Supplier");
					Report.SetParameterValue("txtGroup", "Supplier");
					Report.ReportDefinition.Sections("Section2").SectionFormat.EnableSuppress = true;
					sql = "SELECT aStockItem.StockItem_SupplierID AS GroupID, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]) AS content, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]-[StockList]![listCostSum]) AS listProfit, Sum([StockList]![exclusiveSum]-[StockList]![depositSum]-[StockList]![actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(StockList.depositSum) AS depositSum FROM StockList INNER JOIN aStockItem ON StockList.SaleItem_StockItemID = aStockItem.StockItemID GROUP BY aStockItem.StockItem_SupplierID;";
					rsSales = modReport.getRSreport(ref sql);

					sql = "SELECT aStockItem.StockItem_SupplierID AS GroupID, Sum(stockOpen.openQty) AS openQty, Sum(stockOpen.openList) AS openList, Sum(stockOpen.openActual) AS openActual, Sum(stockClose.closeList) AS closeList, Sum(stockClose.closeActual) AS closeActual, Sum(stockClose.closeQty) AS closeQty, Sum(stockMovement.listSales) AS listSales, Sum(stockMovement.listShrink) AS listShrink, Sum(stockMovement.listGRV) AS listGRV, Sum(stockMovement.actualSales) AS actualSales, Sum(stockMovement.actualShrink) AS actualShrink, Sum(stockMovement.actualGRV) AS actualGRV, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantitySales) AS SumOfDayEndStockItemLnk_QuantitySales, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum(stockMovement.SumOfDayEndStockItemLnk_QuantityGRV) AS SumOfDayEndStockItemLnk_QuantityGRV ";
					sql = sql + "FROM (SELECT aStockItem.StockItemID, IIf(IsNull([openQtyTot]),0,[openQtyTot]) AS openQty, IIf(IsNull([openListTot]),0,[openListTot]) AS openList, IIf(IsNull([openActualTot]),0,[openActualTot]) AS openActual ";
					sql = sql + "FROM aStockItem LEFT JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, DayEndStockItemLnk.DayEndStockItemLnk_Quantity AS openQtyTot, [DayEndStockItemLnk.DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk!DayEndStockItemLnk_ListCost] AS openListTot, [DayEndStockItemLnk!DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk!DayEndStockItemLnk_ActualCost] AS openActualTot FROM DayEndStockItemLnk ";
					sql = sql + "INNER JOIN Report ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Report.Report_DayEndStartID) AS [%$##@_Alias] ON aStockItem.StockItemID = [%$##@_Alias].DayEndStockItemLnk_StockItemID) AS stockOpen RIGHT JOIN ((aStockItem INNER JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, Sum(([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost])) AS listSales, Sum(([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost])) AS listShrink, Sum(([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost])) AS listGRV, Sum(([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_actualCost])) AS actualSales, Sum(([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_actualCost])) AS actualShrink, Sum(([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_actualCost])) AS actualGRV, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales) AS SumOfDayEndStockItemLnk_QuantitySales, ";
					sql = sql + "Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV) AS SumOfDayEndStockItemLnk_QuantityGRV From DayEndStockItemLnk GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) AS stockMovement ON aStockItem.StockItemID = stockMovement.DayEndStockItemLnk_StockItemID) INNER JOIN (SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, ([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ListCost] AS closeList, ([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ActualCost] AS closeActual, ([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV]) AS closeQty FROM Report INNER JOIN DayEndStockItemLnk ON ";
					sql = sql + "Report.Report_DayEndEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) AS stockClose ON aStockItem.StockItemID = stockClose.DayEndStockItemLnk_StockItemID) ON stockOpen.StockItemID = aStockItem.StockItemID GROUP BY aStockItem.StockItem_SupplierID;";

					rsStock = modReport.getRSreport(ref sql);

					rsGroup = modReport.getRSreport(ref "SELECT Supplier.SupplierID AS groupID, Supplier.Supplier_Name AS groupName From Supplier ORDER BY Supplier.Supplier_Name;");
					break;

			}

			if (rsSales.BOF | rsSales.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			if (rsStock.BOF | rsStock.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			if (rsGroup.BOF | rsGroup.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.Database.Tables(1).SetDataSource(rsSales);
			Report.Database.Tables(2).SetDataSource(rsStock);
			Report.Database.Tables(3).SetDataSource(rsGroup);
			//Report.VerifyOnEveryPrint = True
			//frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();



		}

		private void cmdLoad_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short x = 0;
			for (x = 0; x <= optType.Count; x++) {
				if (optType[x].Checked) {
					loadStockSales(ref x);
					return;
				}
			}

		}

		private void frmStockSales_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 27) {
				KeyAscii = 0;
				this.Close();
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmStockSales_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			optType.AddRange(new RadioButton[] {
				_optType_0,
				_optType_1,
				_optType_2,
				_optType_3,
				_optType_4
			});
			loadLanguage();

			setup();
		}
	}
}
