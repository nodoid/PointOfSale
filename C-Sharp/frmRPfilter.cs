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
	internal partial class frmRPfilter : System.Windows.Forms.Form
	{
		string gFilter;
		string gFilterSQL;
		string gReport;

		private void loadLanguage()
		{

			//frmRPfilter = No Code  [Select the filter for your Report]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmRPfilter.Caption = rsLang("LanguageLayoutLnk_Description"): frmRPfilter.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblHeading = No Code   [Using the "Stock Item Selector"...]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblHeading.Caption = rsLang("LanguageLayoutLnk_Description"): lblHeading.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1006;
			//Filter|Checked
			if (modRecordSet.rsLang.RecordCount){cmdNamespace.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdNamespace.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1085;
			//Print|Checked
			if (modRecordSet.rsLang.RecordCount){cmdPrint.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPrint.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmRPfilter.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public void loadItem(ref string Report)
		{
			getNamespace();
			switch (Strings.LCase(Report)) {
				case "recipe":
					gReport = Report;
					this.Text = "Bill Of Material Listing";
					gFilter = "stockitem";
					System.Windows.Forms.Application.DoEvents();
					getNamespace();

					loadLanguage();
					ShowDialog();
					break;
				case "stockitemgrouping":
					gReport = Report;
					this.Text = "Stock Item Grouping Details";
					gFilter = "stockitem";
					System.Windows.Forms.Application.DoEvents();
					getNamespace();

					loadLanguage();
					ShowDialog();
					break;
				case "stockitemorderlevels":
					gReport = Report;
					this.Text = "Stock Item Re-order Levels";
					gFilter = "stockitem";
					System.Windows.Forms.Application.DoEvents();
					getNamespace();

					loadLanguage();
					ShowDialog();
					break;
			}
		}
		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdNamespace_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmFilter.loadFilter(ref gFilter);
			getNamespace();
		}

		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			switch (Strings.LCase(gReport)) {
				case "recipe":
					modApplication.report_BOM(ref gFilterSQL);
					break;
				case "stockitemgrouping":
					stockitemGroup();
					break;
				case "stockitemorderlevels":
					stockitemOrderLevels();
					break;
			}
		}

		private void frmRPfilter_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			getNamespace();
		}

		private void frmRPfilter_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case System.Windows.Forms.Keys.Escape:
					this.Close();
					KeyAscii = 0;
					break;
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void getNamespace()
		{
			if (string.IsNullOrEmpty(gFilter)) {
				this.lblHeading.Text = "";
			} else {
				My.MyProject.Forms.frmFilter.buildCriteria(ref gFilter);
				this.lblHeading.Text = My.MyProject.Forms.frmFilter.gHeading;
			}
			gFilterSQL = My.MyProject.Forms.frmFilter.gCriteria;
		}


		private void stockitemGroup()
		{
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = default(CrystalDecisions.CrystalReports.Engine.ReportDocument);
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			Report.Load("cryStockItemGrouping.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtTitle", this.Text);
			Report.SetParameterValue("txtFilter", this.lblHeading.Text);
			rs.Close();
			sql = "SELECT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_ReceiptName, StockItem.StockItem_Quantity, StockItem.StockItem_ListCost , Deposit.Deposit_Name, StockGroup.StockGroup_Name, Shrink.Shrink_Name, Supplier.Supplier_Name, PricingGroup.PricingGroup_Name FROM (((Deposit INNER JOIN (StockItem INNER JOIN Supplier ON StockItem.StockItem_SupplierID = Supplier.SupplierID) ON Deposit.DepositID = StockItem.StockItem_DepositID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN Shrink ON StockItem.StockItem_ShrinkID = Shrink.ShrinkID ";
			sql = sql + gFilterSQL + " ORDER BY StockItem.StockItem_Name;";
			rs = modRecordSet.getRS(ref sql);
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = default(CrystalDecisions.CrystalReports.Engine.ReportDocument);
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
			//Report.Database.SetDataSource(rs, 3)
			Report.Database.Tables(1).SetDataSource(rs);
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


		private void stockitemOrderLevels()
		{
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = default(CrystalDecisions.CrystalReports.Engine.ReportDocument);
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			Report.Load("cryStockItemORderLevels.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtTitle", this.Text);
			Report.SetParameterValue("txtFilter", this.lblHeading.Text);
			rs.Close();
			sql = "SELECT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_Quantity, StockItem.StockItem_MinimumStock, [StockItem_MinimumStock]/[StockItem_Quantity] AS minimumCase, StockItem.StockItem_OrderQuantity, StockItem.StockItem_OrderRounding, StockItem.StockItem_OrderDynamic, [StockItem_Quantity]=[StockItem_OrderQuantity] AS brokenPack FROM StockItem ";
			sql = sql + gFilterSQL + " ORDER BY StockItem.StockItem_Name;";
			rs = modRecordSet.getRS(ref sql);
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = default(CrystalDecisions.CrystalReports.Engine.ReportDocument);
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			//Report.Database.SetDataSource(rs, 3)
			Report.Database.Tables(1).SetDataSource(rs);
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}
	}
}
