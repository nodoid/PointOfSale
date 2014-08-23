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
	internal partial class frmGroupSales : System.Windows.Forms.Form
	{
		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2181;
			//Group Sales Profitability Order Criteria|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2182;
			//Select the Majour Break Group|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2183;
			//Select the Minor Break Group|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//NOTE: DB Entry 1269 doesn't have ">>" Chars!
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1269;
			//Load Report|Checked
			if (modRecordSet.rsLang.RecordCount){cmdLoad.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdLoad.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmGroupSales.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void setup()
		{
			this.cmbMajor.Items.Clear();
			cmbMajor.Items.Add("Supplier");
			cmbMajor.Items.Add("Pricing Group");
			cmbMajor.Items.Add("Stock Group");
			cmbMajor.Items.Add("Deposit Type");
			cmbMajor.Items.Add("Shrink Type");
			cmbMajor.SelectedIndex = 2;

			this.cmbMinor.Items.Clear();
			cmbMinor.Items.Add("None");
			cmbMinor.Items.Add("Supplier");
			cmbMinor.Items.Add("Pricing Group");
			cmbMinor.Items.Add("Stock Group");
			cmbMinor.Items.Add("Deposit Type");
			cmbMinor.Items.Add("Shrink Type");
			cmbMinor.SelectedIndex = 0;
		}

		private void cmdLoad_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsMajor = default(ADODB.Recordset);
			ADODB.Recordset rsMinor = default(ADODB.Recordset);
			string majorSQL = null;
			string majorSQLgroup = null;
			string minorSQL = null;
			string minorSQLgroup = null;
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			string sql = null;
			if (Strings.LCase(Convert.ToString(cmbMajor.SelectedIndex)) == Strings.LCase(Convert.ToString(cmbMinor.SelectedIndex))) {
				cmbMinor.SelectedIndex = 0;
				System.Windows.Forms.Application.DoEvents();
			}
			switch (Strings.LCase(Convert.ToString(cmbMajor.SelectedIndex))) {
				case "supplier":
					majorSQL = "SELECT Supplier.SupplierID AS sectionAkey, Supplier.Supplier_Name AS sectionAname FROM Supplier ORDER BY Supplier.Supplier_Name;";
					majorSQLgroup = "aStockItem.StockItem_SupplierID";
					break;
				case "pricing group":
					majorSQL = "SELECT aPricingGroup.PricingGroupID AS sectionAkey, aPricingGroup.PricingGroup_Name AS sectionAname FROM aPricingGroup;";
					majorSQLgroup = "aStockItem.StockItem_PricingGroupID";
					break;
				case "stock group":
					majorSQL = "SELECT aStockGroup.StockGroupID AS sectionAkey, aStockGroup.StockGroup_Name AS sectionAname FROM aStockGroup;";
					majorSQLgroup = "aStockItem.StockItem_StockGroupID";
					break;
				case "deposit type":
					majorSQL = "SELECT aDeposit.DepositID AS sectionAkey, aDeposit.Deposit_Name AS sectionAname FROM aDeposit;";
					majorSQLgroup = "aStockItem.StockItem_DepositID";
					break;
				case "shrink type":
					majorSQL = "SELECT aShrink.ShrinkID AS sectionAkey, aShrink.Shrink_Name AS sectionAname FROM aShrink;";
					majorSQLgroup = "aStockItem.StockItem_ShrinkID";
					break;
			}
			switch (Strings.LCase(Convert.ToString(cmbMinor.SelectedIndex))) {
				case "supplier":
					minorSQL = "SELECT Supplier.SupplierID AS sectionAkey, Supplier.Supplier_Name AS sectionAname FROM Supplier;";
					minorSQLgroup = "aStockItem.StockItem_SupplierID";
					break;
				case "pricing group":
					minorSQL = "SELECT aPricingGroup.PricingGroupID AS sectionAkey, aPricingGroup.PricingGroup_Name AS sectionAname FROM aPricingGroup;";
					minorSQLgroup = "aStockItem.StockItem_PricingGroupID";
					break;
				case "stock group":
					minorSQL = "SELECT aStockGroup.StockGroupID AS sectionAkey, aStockGroup.StockGroup_Name AS sectionAname FROM aStockGroup;";
					minorSQLgroup = "aStockItem.StockItem_StockGroupID";
					break;
				case "deposit type":
					minorSQL = "SELECT aDeposit.DepositID AS sectionAkey, aDeposit.Deposit_Name AS sectionAname FROM aDeposit;";
					minorSQLgroup = "aStockItem.StockItem_DepositID";
					break;
				case "shrink type":
					minorSQL = "SELECT aShrink.ShrinkID AS sectionAkey, aShrink.Shrink_Name AS sectionAname FROM aShrink;";
					minorSQLgroup = "aStockItem.StockItem_ShrinkID";
					break;
			}
			if (string.IsNullOrEmpty(minorSQL)) {
				Report.Load("cryGroupSalesMajor.rpt");
				sql = "SELECT " + majorSQLgroup + " AS sectionB, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost FROM StockList INNER JOIN ";
				sql = sql + "aStockItem ON StockList.SaleItem_StockItemID = aStockItem.StockItemID GROUP BY " + majorSQLgroup + ";";

			} else {
				Report.Load("cryGroupSalesMinor.rpt");
				sql = "SELECT " + majorSQLgroup + " AS sectionA, " + minorSQLgroup + " AS sectionB, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost FROM StockList INNER JOIN ";
				sql = sql + "aStockItem ON StockList.SaleItem_StockItemID = aStockItem.StockItemID GROUP BY " + majorSQLgroup + ", " + minorSQLgroup + ";";
			}
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayEnd", rs.Fields("Report_Heading"));
			rs.Close();
			rs = modReport.getRSreport(ref sql);
			//ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
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
			if (string.IsNullOrEmpty(minorSQL)) {
				rsMajor = modReport.getRSreport(ref majorSQL);
				Report.Database.Tables(1).SetDataSource(rs);
				Report.Database.Tables(2).SetDataSource(rsMajor);
				Report.SetParameterValue("txtTitle", "Group Sales Profit Summary by " + Convert.ToString(cmbMajor.SelectedIndex));
			} else {
				rsMajor = modReport.getRSreport(ref majorSQL);
				Report.Database.Tables(1).SetDataSource(rsMajor);
				Report.Database.Tables(2).SetDataSource(rs);

				rsMinor = modReport.getRSreport(ref minorSQL);
				Report.Database.Tables(3).SetDataSource(rsMinor);
				Report.SetParameterValue("txtTitle", "Group Sales Profit Summary by " + Convert.ToString(cmbMajor.SelectedIndex) + " by " + GID.GetItemString(ref cmbMinor, ref cmbMinor.SelectedIndex));
			}

			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();


		}

		private void frmGroupSales_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void frmGroupSales_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			loadLanguage();
			setup();
		}
	}
}
