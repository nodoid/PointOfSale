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
namespace _4PosBackOffice.NET
{
	internal partial class frmReportPriceList : System.Windows.Forms.Form
	{

		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1171;
			//Price List|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1172;
			//Report Options|Checked
			if (modRecordSet.rsLang.RecordCount){_Frame1_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_Frame1_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1173;
			//Group on|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1174;
			//Page Break after each Group|
			if (modRecordSet.rsLang.RecordCount){chkPageBreak.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;chkPageBreak.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//chkQty = No code       [Show Total Quantity]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkQty.Caption = rsLang("LanguageLayoutLnk_Description"): chkQty.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Frame1(1) = No Code    [Report Sort Order]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Frame1(1).Caption = rsLang("LanguageLayoutLnk_Description"): Frame1(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2158;
			//Sort Field|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2159;
			//Sort Order|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1178;
			//Report Filter|Checked
			if (modRecordSet.rsLang.RecordCount){_Frame1_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_Frame1_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1006;
			//Filter|Checked
			if (modRecordSet.rsLang.RecordCount){cmdGroup.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdGroup.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1179;
			//Channel Filter|Checked
			if (modRecordSet.rsLang.RecordCount){Frame2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Frame2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2176;
			//Channel|Checked
			if (modRecordSet.rsLang.RecordCount){Label1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1181;
			//Show/Print Report|Checked
			if (modRecordSet.rsLang.RecordCount){cmdLoad.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdLoad.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmReportPriceList.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdGroup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
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

		private void cmdLoad_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			ADODB.Recordset rsData = default(ADODB.Recordset);

			//Dim Report As New cryPricelistRealNoGroup 'cryPricelistReal
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = default(CrystalDecisions.CrystalReports.Engine.ReportDocument);
			switch (this.cmbGroup.SelectedIndex) {
				case 0:
					Report.Load("cryPricelistReal.rpt");
					chkPageBreak.Enabled = true;
					break;
				case 1:
					Report.Load("cryPricelistReal.rpt");
					chkPageBreak.Enabled = true;
					break;
				case 2:
					Report.Load("cryPricelistReal.rpt");
					chkPageBreak.Enabled = true;
					break;
				case 3:
					Report.Load("cryPricelistRealNoGroup.rpt");
					chkPageBreak.Enabled = false;
					break;
			}

			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = default(CrystalDecisions.CrystalReports.Engine.ReportDocument);
			ReportNone.Load("cryNoRecords.rpt");
			string lOrder = null;
			string lWhere = null;
			switch (this.cmbSortField.SelectedIndex) {
				case 0:
					lOrder = "StockItem.StockItem_Name";
					break;
				case 1:
					lOrder = "[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100)";
					break;
				case 2:
					lOrder = "POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price";
					break;
				case 3:
					lOrder = "([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100))";
					break;
				case 4:
					lOrder = "IIf([POSCatalogueChannelLnk_Price],([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100))/[POSCatalogueChannelLnk_Price]*100)";
					break;
			}
			if (this.cmbSort.SelectedIndex)
				lOrder = lOrder + " DESC";
			lOrder = " ORDER BY " + lOrder + ", StockItem.StockItem_Name, Catalogue.Catalogue_Quantity";

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();
			rs = modReport.getRSreport(ref "SELECT * FROM Link Where LinkID=2 AND Link_SectionID=1");
			Report.SetParameterValue("txtFilter", Strings.Replace(rs.Fields("Link_Name").Value, "''", "'"));

			//sql = "SELECT PricingGroup.PricingGroup_Name AS Department, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Catalogue.Catalogue_Quantity, StockItem.StockItem_ListCost, Vat.Vat_Amount, POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost] AS cost, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost] AS exclusiveCost, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100) AS inclusiveCost, IIf([POSCatalogueChannelLnk_Price],([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100))/[POSCatalogueChannelLnk_Price]*100) AS gpPercentage, ([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100)) AS profit "
			//sql = sql & "FROM Vat INNER JOIN (POSCatalogueChannelLnk INNER JOIN ((StockItem INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) ON (POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity = Catalogue.Catalogue_Quantity) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID = Catalogue.Catalogue_StockItemID)) ON Vat.VatID = StockItem.StockItem_VatID "

			//with w/h =2 qty
			//sql = "SELECT PricingGroup.PricingGroup_Name AS Department, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Catalogue.Catalogue_Quantity, StockItem.StockItem_ListCost, Vat.Vat_Amount, POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost] AS cost, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost] AS exclusiveCost, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100) AS inclusiveCost, IIf([POSCatalogueChannelLnk_Price],([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100))/[POSCatalogueChannelLnk_Price]*100) AS gpPercentage, ([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100)) AS profit, WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity "
			//sql = sql & "FROM (Vat INNER JOIN (POSCatalogueChannelLnk INNER JOIN ((StockItem INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) ON (POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID = Catalogue.Catalogue_StockItemID) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity = Catalogue.Catalogue_Quantity)) ON Vat.VatID = StockItem.StockItem_VatID) INNER JOIN WarehouseStockItemLnk ON StockItem.StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID "

			//with all W/H qty
			if (chkQty.Enabled == false) {
				sql = "SELECT PricingGroup.PricingGroup_Name AS Department, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Catalogue.Catalogue_Quantity, StockItem.StockItem_ListCost, Vat.Vat_Amount, POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost] AS cost, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost] AS exclusiveCost, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100) AS inclusiveCost, IIf([POSCatalogueChannelLnk_Price],([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100))/[POSCatalogueChannelLnk_Price]*100) AS gpPercentage, ([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100)) AS profit, 0 AS SumOfWarehouseStockItemLnk_Quantity ";
				sql = sql + "FROM (Vat INNER JOIN (POSCatalogueChannelLnk INNER JOIN ((StockItem INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) ON (POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID = Catalogue.Catalogue_StockItemID) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity = Catalogue.Catalogue_Quantity)) ON Vat.VatID = StockItem.StockItem_VatID) INNER JOIN WarehouseStockItemLnk ON StockItem.StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID ";
			} else {
				if (chkQty.CheckState) {
					sql = "SELECT PricingGroup.PricingGroup_Name AS Department, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Catalogue.Catalogue_Quantity, StockItem.StockItem_ListCost, Vat.Vat_Amount, POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost] AS cost, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost] AS exclusiveCost, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100) AS inclusiveCost, IIf([POSCatalogueChannelLnk_Price],([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100))/[POSCatalogueChannelLnk_Price]*100) AS gpPercentage, ([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100)) AS profit, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity ";
					sql = sql + "FROM (Vat INNER JOIN (POSCatalogueChannelLnk INNER JOIN ((StockItem INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) ON (POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID = Catalogue.Catalogue_StockItemID) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity = Catalogue.Catalogue_Quantity)) ON Vat.VatID = StockItem.StockItem_VatID) INNER JOIN WarehouseStockItemLnk ON StockItem.StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID ";
				} else {
					sql = "SELECT PricingGroup.PricingGroup_Name AS Department, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Catalogue.Catalogue_Quantity, StockItem.StockItem_ListCost, Vat.Vat_Amount, POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost] AS cost, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost] AS exclusiveCost, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100) AS inclusiveCost, IIf([POSCatalogueChannelLnk_Price],([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100))/[POSCatalogueChannelLnk_Price]*100) AS gpPercentage, ([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100)) AS profit, 0 AS SumOfWarehouseStockItemLnk_Quantity ";
					sql = sql + "FROM (Vat INNER JOIN (POSCatalogueChannelLnk INNER JOIN ((StockItem INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) ON (POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID = Catalogue.Catalogue_StockItemID) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity = Catalogue.Catalogue_Quantity)) ON Vat.VatID = StockItem.StockItem_VatID) INNER JOIN WarehouseStockItemLnk ON StockItem.StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID ";
				}
			}

			switch (this.cmbGroup.SelectedIndex) {
				case 0:
					Report.SetParameterValue("txtTitle", "Price List - by Pricing Group");
					break;
				case 1:
					sql = Strings.Replace(sql, "PricingGroup", "StockGroup");
					Report.SetParameterValue("txtTitle", "Price List - by Stock Group");
					break;
				case 2:
					sql = Strings.Replace(sql, "PricingGroup", "Supplier");
					Report.SetParameterValue("txtTitle", "Price List - by Supplier");
					break;
				case 3:
					Report.SetParameterValue("txtTitle", "Price List - by Stock Name");
					break;
			}

			if (chkPageBreak.Enabled == true) {
				if (this.chkPageBreak.CheckState) {
					Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = true;
				} else {
					Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = false;
				}
			} else {
				Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = false;
			}

			//new code
			Report.SetParameterValue("txtChannel", "For " + cmbChannel.CtlText);

			if (string.IsNullOrEmpty(rs.Fields("Link_SQL").Value)) {
				//sql = sql & "Where (POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID = 1) And (StockItem.StockItem_Disabled = 0) And ((StockItem.StockItem_Discontinued = 0) OR (Catalogue.Catalogue_Disabled = 0)) "
				sql = sql + "Where (POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID = " + this.cmbChannel.BoundText + " ) And (StockItem.StockItem_Disabled = 0) And ((StockItem.StockItem_Discontinued = 0) OR (Catalogue.Catalogue_Disabled = 0)) ";
				//chnaged for QTY 29 June 2010   sql = sql & "Where (WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID = 2) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID = " & Me.cmbChannel.BoundText & " ) And (StockItem.StockItem_Disabled = 0) And ((StockItem.StockItem_Discontinued = 0) OR (Catalogue.Catalogue_Disabled = 0)) "
			} else {
				//sql = sql & rs("Link_SQL") & " AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID = 1) And ((StockItem.StockItem_Disabled = 0) OR (StockItem.StockItem_Discontinued = 0)) And (Catalogue.Catalogue_Disabled = 0) "
				sql = sql + rs.Fields("Link_SQL").Value + " AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID = " + this.cmbChannel.BoundText + " ) And ((StockItem.StockItem_Disabled = 0) OR (StockItem.StockItem_Discontinued = 0)) And (Catalogue.Catalogue_Disabled = 0) ";
				//chnaged for QTY 29 June 2010   sql = sql & rs("Link_SQL") & " AND (WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID = 2) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID = " & Me.cmbChannel.BoundText & " ) And ((StockItem.StockItem_Disabled = 0) OR (StockItem.StockItem_Discontinued = 0)) And (Catalogue.Catalogue_Disabled = 0) "
			}


			sql = sql + "GROUP BY PricingGroup.PricingGroup_Name, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Catalogue.Catalogue_Quantity, StockItem.StockItem_ListCost, Vat.Vat_Amount, POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price, [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost], [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost], [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100), IIf([POSCatalogueChannelLnk_Price],([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100))/[POSCatalogueChannelLnk_Price]*100), ([POSCatalogueChannelLnk_Price]-[Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ListCost]*(1+[Vat_Amount]/100)) ";
			switch (this.cmbGroup.SelectedIndex) {
				case 0:
					Report.SetParameterValue("txtTitle", "Price List - by Pricing Group");
					break;
				case 1:
					sql = Strings.Replace(sql, "PricingGroup", "StockGroup");
					Report.SetParameterValue("txtTitle", "Price List - by Stock Group");
					break;
				case 2:
					sql = Strings.Replace(sql, "PricingGroup", "Supplier");
					Report.SetParameterValue("txtTitle", "Price List - by Supplier");
					break;
				case 3:
					Report.SetParameterValue("txtTitle", "Price List - by Stock Name");
					break;
			}

			sql = sql + lOrder;
			Debug.Print(sql);
			rs = modRecordSet.getRS(ref sql);

			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			//Report.VerifyOnEveryPrint = True
			Report.Database.Tables(1).SetDataSource(rs);
			//Report.Database.SetDataSource(rs, 3)
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();



		}



		private void frmReportPriceList_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void frmReportPriceList_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			int StockTakePrinter = 0;
			int StockTakeAdministrator = 0;
			StockTakeAdministrator = 2;
			StockTakePrinter = 4;

			setup();
			this.cmbGroup.SelectedIndex = 0;
			this.cmbSort.SelectedIndex = 0;
			this.cmbSortField.SelectedIndex = 0;

			if (StockTakeAdministrator & My.MyProject.Forms.frmMenu.gBit) {
				chkQty.Enabled = true;
			} else {
				chkQty.Enabled = false;
			}

			loadLanguage();

			buildDataControls();
		}

		private void optType_Click(ref short Index)
		{
			if (Index) {
				cmbGroup.Enabled = true;
			} else {
				cmbGroup.Enabled = false;
			}
			this.chkPageBreak.Enabled = (Index == 1);
		}

//new code
		private void buildDataControls()
		{
			doDataControl(ref (this.cmbChannel), ref "SELECT ChannelID, Channel_Name FROM Channel ORDER BY ChannelID", ref "ChannelID", ref "Channel_Name");
			cmbChannel.BoundText = Convert.ToString(1);
		}

		private void doDataControl(ref myDataGridView dataControl, ref string sql, ref string boundColumn, ref string listField)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref sql);
			dataControl.DataSource = rs;
			dataControl.boundColumn = boundColumn;
			dataControl.listField = listField;
		}
	}
}
