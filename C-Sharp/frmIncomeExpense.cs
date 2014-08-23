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
	internal partial class frmIncomeExpense : System.Windows.Forms.Form
	{
		int gMonth;

		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1267;
			//Income and Expense Report|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lbl = No Code      [Select the Month-end Period for the Report]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lbl.Caption = rsLang("LanguageLayoutLnk_Description"): lbl.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1269;
			//Load Report|Checked
			if (modRecordSet.rsLang.RecordCount){cmdLoad.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdLoad.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmIncomeExpense.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdLoad_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string sql = null;
			ADODB.Connection lConn = default(ADODB.Connection);
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsPurchase = default(ADODB.Recordset);
			ADODB.Recordset rsSales = default(ADODB.Recordset);
			ADODB.Recordset rsStock = default(ADODB.Recordset);
			ADODB.Recordset rsCompany = default(ADODB.Recordset);
			//Dim Report As New cryIncomeExpense
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryIncomeExpense.rpt");
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			if (cmbMonthEnd.SelectedIndex) {
				lConn = modRecordSet.openConnectionInstance(ref "month" + gMonth - cmbMonthEnd.SelectedIndex + ".mdb");
				if (lConn == null)
					return;
				rsStock = new ADODB.Recordset();
				rsStock.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
				sql = "SELECT DayEndStockItemLnk.DayEndStockItemLnk_DayEndID, Sum([DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk_ListCost]-[DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost]-[DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]+[DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost]) AS total, Sum([DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk_ListCost]) AS opening, Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost]) AS sales, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS shrink, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost]) AS grv From DayEndStockItemLnk GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_DayEndID;";

				rsStock.Open(sql, lConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
				rsSales = new ADODB.Recordset();
				rsSales.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
				//UPGRADE_WARNING: Couldn't resolve default property of object sql. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sql = "SELECT [M_DayEnd].[DayEndID], [M_DayEnd].[DayEnd_Date], Sum([Declaration].[Declaration_Total]) AS SumOfSale_Total FROM Declaration INNER JOIN M_DayEnd ON [Declaration].[Declaration_DayEndID]=[M_DayEnd].[DayEndID] GROUP BY [M_DayEnd].[DayEndID], [M_DayEnd].[DayEnd_Date];";

				rsSales.Open(sql, lConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
			} else {

				modApplication.modUpdate = 3;

				modApplication.updateStockMovement();

				sql = "SELECT DayEnd.DayEndID, DayEnd.DayEnd_Date, Sum(Declaration.Declaration_Total) AS SumOfSale_Total FROM Company, Declaration INNER JOIN DayEnd ON Declaration.Declaration_DayEndID = DayEnd.DayEndID Where (((DayEnd.DayEndID) <> [Company]![Company_DayEndID])) GROUP BY DayEnd.DayEndID, DayEnd.DayEnd_Date Union SELECT DayEnd.DayEndID, DayEnd.DayEnd_Date, Sum([SaleItem_Price]*[SaleItem_Quantity]) AS SumOfSale_Total FROM Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN ((Sale INNER JOIN (Company INNER JOIN DayEnd ON Company.Company_DayEndID = DayEnd.DayEndID) ON Sale.Sale_DayEndID = DayEnd.DayEndID) INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = 0)) GROUP BY Consignment.ConsignmentID, Consignment_1.ConsignmentID, DayEnd.DayEndID, DayEnd.DayEnd_Date  ";
				sql = sql + "HAVING (((Consignment.ConsignmentID) Is Null) AND ((Consignment_1.ConsignmentID) Is Null));";
				rsSales = modRecordSet.getRS(ref sql);

				rsStock = modRecordSet.getRS(ref "SELECT DayEndStockItemLnk.DayEndStockItemLnk_DayEndID, Sum([DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk_ListCost]-[DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost]-[DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]+[DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost]) AS total, Sum([DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk_ListCost]) AS opening, Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost]) AS sales, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS shrink, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost]) AS grv From DayEndStockItemLnk GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_DayEndID;");

			}

			rsPurchase = modRecordSet.getRS(ref "SELECT DayEnd.DayEndID, DayEnd.DayEnd_Date, Sum(grvPosted.GRV_InvoiceInclusive) AS SumOfGRV_InvoiceInclusive, ([MonthEnd_BudgetSales]/[MonthEnd_Days]) AS saleBudget, ([MonthEnd_BudgetPurchases]/[MonthEnd_Days]) AS purchaseBudget FROM [SELECT GRV.* From GRV WHERE (((GRV.GRV_GRVStatusID)=3))]. AS grvPosted RIGHT JOIN (DayEnd INNER JOIN MonthEnd ON DayEnd.DayEnd_MonthEndID = MonthEnd.MonthEndID) ON grvPosted.GRV_DayEndID = DayEnd.DayEndID Where (((MonthEnd.MonthEndID) = " + gMonth - cmbMonthEnd.SelectedIndex + ")) GROUP BY DayEnd.DayEndID, DayEnd.DayEnd_Date, ([MonthEnd_BudgetSales]/[MonthEnd_Days]), ([MonthEnd_BudgetPurchases]/[MonthEnd_Days]);");



			rsCompany = modRecordSet.getRS(ref "SELECT MonthEnd.* From MonthEnd WHERE (((MonthEnd.MonthEndID)=" + gMonth - cmbMonthEnd.SelectedIndex + "));");

			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();
			//ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rsPurchase.BOF | rsPurchase.EOF) {
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
			//Report.Database.SetDataSource(rs)
			Report.Database.Tables(1).SetDataSource(rsPurchase);
			Report.Database.Tables(2).SetDataSource(rsSales);
			Report.Database.Tables(3).SetDataSource(rsStock);
			Report.Database.Tables(4).SetDataSource(rsCompany);
			//UPGRADE_WARNING: Couldn't resolve default property of object Report.VerifyOnEveryPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();


			if (lConn == null) {
			} else {
				lConn.Close();
			}
		}

		private void frmIncomeExpense_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void frmIncomeExpense_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = new ADODB.Recordset();
			cmbMonthEnd.Items.Clear();
			rs = modRecordSet.getRS(ref "SELECT Min(DayEnd.DayEnd_Date) AS MinOfDayEnd_Date, Max(DayEnd_1.DayEnd_Date) AS MaxOfDayEnd_Date, Company.Company_MonthEndID, MonthEnd.MonthEndID FROM Company, (DayEnd AS DayEnd_1 INNER JOIN MonthEnd ON DayEnd_1.DayEnd_MonthEndID = MonthEnd.MonthEndID) INNER JOIN DayEnd ON MonthEnd.MonthEndID = DayEnd.DayEnd_MonthEndID GROUP BY Company.Company_MonthEndID, MonthEnd.MonthEndID ORDER BY MonthEnd.MonthEndID DESC");
			gMonth = rs.Fields("Company_MonthEndID").Value;
			while (!(rs.EOF)) {
				if (rs.Fields("Company_MonthEndID").Value == rs.Fields("MonthEndID").Value) {
					cmbMonthEnd.Items.Add("Current Month");
				} else {
					cmbMonthEnd.Items.Add((rs.Fields("Company_MonthEndID").Value - rs.Fields("MonthEndID").Value) + " Month/s ago starting on the " + Strings.Format(rs.Fields("MinOfDayEnd_Date").Value, "dd MM yyyy") + " and ending on the " + Strings.Format(rs.Fields("MaxOfDayEnd_Date").Value, "dd MM yyyy") + ".");
				}
				rs.moveNext();
			}
			cmbMonthEnd.SelectedIndex = 0;

			loadLanguage();
		}
	}
}
