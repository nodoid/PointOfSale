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
	internal partial class frmTopSelect : System.Windows.Forms.Form
	{
		List<RadioButton> optType = new List<RadioButton>();
		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2149;
			//Product Performance|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1172;
			//Report Options|Checked
			if (modRecordSet.rsLang.RecordCount){_Frame1_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_Frame1_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2152;
			//Normal Item Listing|Checked
			if (modRecordSet.rsLang.RecordCount){_optType_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_optType_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2153;
			//Items per Group|Checked
			if (modRecordSet.rsLang.RecordCount){_optType_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_optType_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2154;
			//Group Totals|Checked
			if (modRecordSet.rsLang.RecordCount){_optType_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_optType_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1173;
			//Group On|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1174;
			//Page break after each group|Checked
			if (modRecordSet.rsLang.RecordCount){chkPageBreak.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;chkPageBreak.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1175;
			//Report Sort Order|Checked
			if (modRecordSet.rsLang.RecordCount){_Frame1_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_Frame1_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

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

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1181;
			//Show/Print Report|Checked
			if (modRecordSet.rsLang.RecordCount){cmdLoad.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdLoad.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmTopSelect.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
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
			My.MyProject.Forms.frmFilter.buildCriteria(ref "Sale");
			My.MyProject.Forms.frmFilter.loadFilter(ref "Sale");
			My.MyProject.Forms.frmFilter.buildCriteria(ref "Sale");

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
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = default(CrystalDecisions.CrystalReports.Engine.ReportDocument);

			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = default(CrystalDecisions.CrystalReports.Engine.ReportDocument);
			ReportNone.Load("cryNoRecords.rpt");
			string lOrder = null;

			CrystalDecisions.CrystalReports.Engine.DatabaseFieldDefinition CRXDatabaseField = default(CrystalDecisions.CrystalReports.Engine.DatabaseFieldDefinition);

			switch (this.cmbSortField.SelectedIndex) {
				case 0:
					lOrder = "StockItem_Name";
					break;
				case 1:
					lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]";
					break;
				case 2:
					lOrder = "[exclusiveSum]-[depositSum]";
					break;
				case 3:
					lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]";
					break;
				case 4:
					lOrder = "IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum])";
					break;
				case 5:
					lOrder = "StockList.quantitySum";
					break;

			}

			if (this.cmbSort.SelectedIndex)
				lOrder = lOrder + " DESC";
			lOrder = " ORDER BY " + lOrder;

			//UPGRADE_NOTE: Object Report may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			Report = null;

			if (_optType_0.Checked) {
				Report.Load("cryStockitemTop1.rpt");
			} else if (_optType_1.Checked) {
				Report.Load("cryStockitemTopByGroup.rpt");
			} else {
				Report.Load("cryStockitemTopGroup.rpt");
			}
			while (Report.DataDefinition.SortFields.Count) {
				//'Report.RecordSortFields.delete(1)
			}

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();
			rs = modReport.getRSreport(ref "SELECT * FROM Link Where LinkID=2 AND Link_SectionID=1");
			Report.SetParameterValue("txtFilter", Strings.Replace(rs.Fields("Link_Name").Value, "''", "'"));

			if (_optType_0.Checked) {
				if (!string.IsNullOrEmpty(rs.Fields("Link_SQL").Value)) {
					sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID ";
				} else {
					switch (this.cmbSortField.SelectedIndex) {
						case 0:
							sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department ";
							sql = sql + "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name ";
							break;
						case 1:
							sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department ";
							sql = sql + "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) ";
							break;
						//lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
						case 2:
							sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department ";
							sql = sql + "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]) ";
							break;
						//lOrder = "[exclusiveSum]-[depositSum]"
						case 3:
							sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department ";
							sql = sql + "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) ";
							break;
						//lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
						case 4:
							sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department ";
							sql = sql + "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]) ";
							break;
						//lOrder = "IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum])"
						case 5:
							sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department ";
							sql = sql + "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, StockList.quantitySum ";
							break;
						//lOrder = "StockList.quantitySum"
					}

				}

			} else if (_optType_1.Checked) {
				if (!string.IsNullOrEmpty(rs.Fields("Link_SQL").Value)) {
					sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID ";
				} else {
					switch (this.cmbSortField.SelectedIndex) {
						case 0:
							sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department ";
							sql = sql + "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name ";
							break;
						case 1:
							sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department ";
							sql = sql + "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) ";
							break;
						//lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
						case 2:
							sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department ";
							sql = sql + "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]) ";
							break;
						//lOrder = "[exclusiveSum]-[depositSum]"
						case 3:
							sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department ";
							sql = sql + "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) ";
							break;
						//lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
						case 4:
							sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department ";
							sql = sql + "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]) ";
							break;
						//lOrder = "IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum])"
						case 5:
							sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department ";
							sql = sql + "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, StockList.quantitySum ";
							break;
						//lOrder = "StockList.quantitySum"
					}
					//sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
					//sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
				}
				switch (this.cmbGroup.SelectedIndex) {
					case 0:
						sql = Strings.Replace(sql, "StockGroup", "PricingGroup");
						Report.SetParameterValue("txtTitle", "Product Performance - by Pricing Group");
						break;
					case 1:
						Report.SetParameterValue("txtTitle", "Product Performance - by Stock Group");
						break;
					case 2:
						sql = Strings.Replace(sql, "StockGroup", "Supplier");
						sql = Strings.Replace(sql, "aSupplier", "Supplier");
						Report.SetParameterValue("txtTitle", "Product Performance - by Supplier");
						break;
					case 3:
						sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aReportGroup1.ReportGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aReportGroup1 ON aStockItem1.StockItem_ReportID = aReportGroup1.ReportID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID ";
						Report.SetParameterValue("txtTitle", "Product Performance - by Report Group");
						break;
				}

				if (this.chkPageBreak.CheckState) {
					Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = true;
				} else {
					Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = false;
				}

			} else {
				//If rs("Link_SQL") <> "" Then
				sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID ";
				//Else
				//    sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
				//    sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
				//End If
				switch (this.cmbGroup.SelectedIndex) {
					case 0:
						sql = Strings.Replace(sql, "StockGroup", "PricingGroup");
						Report.SetParameterValue("txtTitle", "Product Performance - by Pricing Group");
						break;
					case 1:
						Report.SetParameterValue("txtTitle", "Product Performance - by Stock Group");
						break;
					case 2:
						sql = Strings.Replace(sql, "StockGroup", "Supplier");
						sql = Strings.Replace(sql, "aSupplier", "Supplier");
						Report.SetParameterValue("txtTitle", "Product Performance - by Supplier");
						break;
					case 3:
						sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aReportGroup1.ReportGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aReportGroup1 ON aStockItem1.StockItem_ReportID = aReportGroup1.ReportID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID ";
						Report.SetParameterValue("txtTitle", "Product Performance - by Report Group");
						break;
				}

				if (this.chkPageBreak.CheckState) {
					Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = true;
				} else {
					Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = false;
				}
			}

			//for customer
			//SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aCustomer.Customer_InvoiceName AS department
			//FROM aCustomer INNER JOIN (CustomerTransaction INNER JOIN (Sale INNER JOIN (SaleItem INNER JOIN (StockList INNER JOIN aStockItem1 ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID) ON SaleItem.SaleItem_StockItemID = StockList.SaleItem_StockItemID) ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID
			//WHERE (((aCustomer.CustomerID)=2) AND ((CustomerTransaction.CustomerTransaction_TransactionTypeID)=2)) OR (((CustomerTransaction.CustomerTransaction_TransactionTypeID)=3));

			if (string.IsNullOrEmpty(rs.Fields("Link_SQL").Value)) {
			} else {
				sql = sql + rs.Fields("Link_SQL").Value;
			}

			sql = sql + lOrder;
			Debug.Print(sql);
			rs = modReport.getRSreport(ref sql);

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

			//        Report.ExportOptions.DiskFileName = "C:\4POSServer\PerfumeGarden\test.html"
			//        Report.ExportOptions.HTMLFileName = "C:\4POSServer\PerfumeGarden\test.html"
			//        Report.ExportOptions.DestinationType = crEDTDiskFile
			//        Report.ExportOptions.FormatType = crEFTExplorer32Extend
			//        Report.Export False
			//        Screen.MousePointer = vbDefault

			//Report.VerifyOnEveryPrint = True
			Report.Database.Tables(1).SetDataSource(rs);
			//Report.Database.SetDataSource(rs, 3)
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();

		}

		private void cmdLoad_Click__OLD()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			ADODB.Recordset rsData = default(ADODB.Recordset);
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = default(CrystalDecisions.CrystalReports.Engine.ReportDocument);
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = default(CrystalDecisions.CrystalReports.Engine.ReportDocument);
			ReportNone.Load("cryNoRecords.rpt");
			string lOrder = null;

			CrystalDecisions.CrystalReports.Engine.DatabaseFieldDefinition CRXDatabaseField = default(CrystalDecisions.CrystalReports.Engine.DatabaseFieldDefinition);

			switch (this.cmbSortField.SelectedIndex) {
				case 0:
					lOrder = "StockItem_Name";
					break;
				case 1:
					lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]";
					break;
				case 2:
					lOrder = "[exclusiveSum]-[depositSum]";
					break;
				case 3:
					lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]";
					break;
				case 4:
					lOrder = "IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum])";
					break;
				case 5:
					lOrder = "StockList.quantitySum";

					break;
			}

			if (this.cmbSort.SelectedIndex)
				lOrder = lOrder + " DESC";
			lOrder = " ORDER BY " + lOrder;

			//UPGRADE_NOTE: Object Report may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			Report = null;

			if (_optType_0.Checked) {
				Report.Load("cryStockitemTop1.rpt");
			} else if (_optType_1.Checked) {
				Report.Load("cryStockitemTopByGroup.rpt");
			} else {
				Report.Load("cryStockitemTopGroup.rpt");
			}
			while (Report.DataDefinition.SortFields.Count) {
				//Report.RecordSortFields.delete(1)
			}

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();
			rs = modReport.getRSreport(ref "SELECT * FROM Link Where LinkID=2 AND Link_SectionID=1");
			Report.SetParameterValue("txtFilter", Strings.Replace(rs.Fields("Link_Name").Value, "''", "'"));

			if (_optType_0.Checked) {
				sql = "SELECT aStockItem.StockItemID, aStockItem.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem INNER JOIN aStockGroup ON aStockItem.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem.StockItemID ";
			} else {
				sql = "SELECT aStockItem.StockItemID, aStockItem.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem INNER JOIN aStockGroup ON aStockItem.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem.StockItemID ";
				switch (this.cmbGroup.SelectedIndex) {
					case 0:
						sql = Strings.Replace(sql, "StockGroup", "PricingGroup");
						Report.SetParameterValue("txtTitle", "Product Performance - by Pricing Group");
						break;
					case 1:
						Report.SetParameterValue("txtTitle", "Product Performance - by Stock Group");
						break;
					case 2:
						sql = Strings.Replace(sql, "StockGroup", "Supplier");
						sql = Strings.Replace(sql, "aSupplier", "Supplier");
						Report.SetParameterValue("txtTitle", "Product Performance - by Supplier");

						break;
				}

				if (this.chkPageBreak.CheckState) {
					Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = true;
				} else {
					Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = false;
				}
			}

			if (string.IsNullOrEmpty(rs.Fields("Link_SQL").Value)) {
			} else {
				sql = sql + rs.Fields("Link_SQL").Value;
			}

			sql = sql + lOrder;
			//Debug.Print sql
			rs = modReport.getRSreport(ref sql);

			if (rs.BOF | rs.EOF) {
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

			//Report.VerifyOnEveryPrint = True
			Report.Database.Tables(1).SetDataSource(rs);
			//Report.Database.SetDataSource(rs, 3)
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();

		}

		private void frmTopSelect_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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
		private void frmTopSelect_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			optType.AddRange(new RadioButton[] {
				_optType_0,
				_optType_1,
				_optType_2
			});
			RadioButton rb = new RadioButton();
			foreach (RadioButton rb_loopVariable in optType) {
				rb = rb_loopVariable;
				rb.CheckedChanged += optType_CheckedChanged;
			}
			setup();
			loadLanguage();
			this.cmbGroup.SelectedIndex = 0;
			this.cmbSort.SelectedIndex = 0;
			this.cmbSortField.SelectedIndex = 0;
		}

		private void optType_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.Checked) {
				int Index = 0;
				RadioButton rb = new RadioButton();
				rb = (RadioButton)eventSender;
				Index = GetIndex.GetIndexer(ref rb, ref optType);
				if (Index) {
					cmbGroup.Enabled = true;
				} else {
					cmbGroup.Enabled = false;
				}
				this.chkPageBreak.Enabled = (Index == 1);
			}
		}
	}
}
