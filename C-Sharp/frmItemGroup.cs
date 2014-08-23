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
	internal partial class frmItemGroup : System.Windows.Forms.Form
	{
		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2375;
			//Stock Item / Stock Group Compare|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2113;
			//Select Stock Item|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2378;
			//Get Stock Item|Checked
			if (modRecordSet.rsLang.RecordCount){cmdStockItem.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdStockItem.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2379;
			//Select a Group|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2380;
			//Get a Group|Checked
			if (modRecordSet.rsLang.RecordCount){cmdGroup.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdGroup.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2382;
			//Sales Quantity|Checked
			if (modRecordSet.rsLang.RecordCount){_optDataType_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_optDataType_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2383;
			//Sales Value|Checked
			if (modRecordSet.rsLang.RecordCount){_optDataType_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_optDataType_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1269;
			//Load Report|Checked
			if (modRecordSet.rsLang.RecordCount){cmdLoad.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdLoad.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmItemGroup.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
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

		private void cmdStockItem_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			int lID = 0;
			modReport.cnnDBreport.Execute("DELETE aftDataItem.* From aftDataItem WHERE (((aftDataItem.ftDataItem_PersonID)=" + modRecordSet.gPersonID + "));");
			modReport.cnnDBreport.Execute("DELETE aftData.* From aftData WHERE (((aftData.ftData_PersonID)=" + modRecordSet.gPersonID + "));");
			modReport.cnnDBreport.Execute("INSERT INTO aftData ( ftData_PersonID, ftData_FieldName, ftData_SQL, ftData_Heading ) SELECT LinkData.LinkData_PersonID, LinkData.LinkData_FieldName, LinkData.LinkData_SQL, LinkData.LinkData_Heading From LinkData WHERE (((LinkData.LinkData_LinkID)=1) AND ((LinkData.LinkData_SectionID)=1) AND ((LinkData.LinkData_PersonID)=" + modRecordSet.gPersonID + "));");
			modReport.cnnDBreport.Execute("INSERT INTO aftDataItem ( ftDataItem_PersonID, ftDataItem_FieldName, ftDataItem_ID ) SELECT LinkDataItem.LinkDataItem_PersonID, LinkDataItem.LinkDataItem_FieldName, LinkDataItem.LinkDataItem_ID From LinkDataItem WHERE (((LinkDataItem.LinkDataItem_LinkID)=1) AND ((LinkDataItem.LinkDataItem_SectionID)=1) AND ((LinkDataItem.LinkDataItem_PersonID)=" + modRecordSet.gPersonID + "));");

			My.MyProject.Forms.frmFilter.buildCriteria(ref "StockItem");
			My.MyProject.Forms.frmFilter.Close();
			lID = My.MyProject.Forms.frmStockList.getItem();
			if (lID) {
				My.MyProject.Forms.frmFilter.buildCriteria(ref "StockItem");
				rs = modRecordSet.getRS(ref "SELECT * FROM StockItem WHERE StockItemID=" + lID);
				modReport.cnnDBreport.Execute("UPDATE Link SET Link.Link_Name = ' " + Strings.Replace(rs.Fields("StockItem_Name").Value, "'", "''") + "', Link.Link_SQL = 'StockItemID=" + lID + "' WHERE (((Link.LinkID)=1) AND ((Link.Link_SectionID)=1) AND ((Link.Link_PersonID)=" + modRecordSet.gPersonID + "));");
				modReport.cnnDBreport.Execute("DELETE LinkDataItem.* From LinkDataItem WHERE (((LinkDataItem.LinkDataItem_LinkID)=1) AND ((LinkDataItem.LinkDataItem_SectionID)=1) AND ((LinkDataItem.LinkDataItem_PersonID)=" + modRecordSet.gPersonID + "));");
				modReport.cnnDBreport.Execute("DELETE LinkData.LinkData_LinkID, LinkData.LinkData_SectionID, LinkData.LinkData_PersonID, LinkData.* From LinkData WHERE (((LinkData.LinkData_LinkID)=1) AND ((LinkData.LinkData_SectionID)=1) AND ((LinkData.LinkData_PersonID)=" + modRecordSet.gPersonID + "));");
				modReport.cnnDBreport.Execute("INSERT INTO LinkData ( LinkData_LinkID, LinkData_SectionID, LinkData_PersonID, LinkData_FieldName, LinkData_SQL, LinkData_Heading ) SELECT 1, 1, aftData.ftData_PersonID, aftData.ftData_FieldName, aftData.ftData_SQL, aftData.ftData_Heading From aftData WHERE (((aftData.ftData_PersonID)=" + modRecordSet.gPersonID + "));");
				modReport.cnnDBreport.Execute("INSERT INTO LinkDataItem ( LinkDataItem_LinkID, LinkDataItem_SectionID, LinkDataItem_PersonID, LinkDataItem_FieldName, LinkDataItem_ID ) SELECT 1, 1, aftDataItem.ftDataItem_PersonID, aftDataItem.ftDataItem_FieldName, aftDataItem.ftDataItem_ID From aftDataItem WHERE (((aftDataItem.ftDataItem_PersonID)=" + modRecordSet.gPersonID + "));");
				lblItem.Text = rs.Fields("StockItem_Name").Value;
			}
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

			rs = modReport.getRSreport(ref "SELECT Link.Link_Name From Link WHERE (((Link.LinkID)=1) AND ((Link.Link_SectionID)=1) AND ((Link.Link_PersonID)=" + modRecordSet.gPersonID + "));");
			lblItem.Text = rs.Fields("Link_Name").Value;
			rs = modReport.getRSreport(ref "SELECT Link.Link_Name From Link WHERE (((Link.LinkID)=2) AND ((Link.Link_SectionID)=1) AND ((Link.Link_PersonID)=" + modRecordSet.gPersonID + "));");
			lblGroup.Text = rs.Fields("Link_Name").Value;
		}

		private void cmdLoad_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsData = default(ADODB.Recordset);
			//Dim Report As New cryItemGroupCompare
			//ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryItemGroupCompare.rpt");
			ReportNone.Load("cryNoRecords");
			modReport.cnnDBreport.Execute("DELETE LinkItem.* FROM LinkItem;");
			rs = modReport.getRSreport(ref "SELECT * FROM Link Where LinkID=1 AND Link_SectionID=1");
			modReport.cnnDBreport.Execute("INSERT INTO LinkItem ( LinkItem_LinkID, LinkItem_DayEndID, LinkItem_Value ) SELECT 1, DayEndStockItemLnk.DayEndStockItemLnk_DayEndID, DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales FROM DayEndStockItemLnk INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID WHERE " + rs.Fields("Link_SQL").Value + ";");
			rs = modReport.getRSreport(ref "SELECT * FROM Link Where LinkID=2 AND Link_SectionID=1");
			modReport.cnnDBreport.Execute("INSERT INTO LinkItem ( LinkItem_LinkID, LinkItem_DayEndID, LinkItem_Value ) SELECT 2, DayEndStockItemLnk.DayEndStockItemLnk_DayEndID, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales) AS SumOfDayEndStockItemLnk_QuantitySales FROM DayEndStockItemLnk INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID " + rs.Fields("Link_SQL").Value + " GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_DayEndID;");

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayEnd", rs.Fields("Report_Heading"));
			rs.Close();
			rs = modReport.getRSreport(ref "SELECT Link.* From Link Where (((Link.Link_SectionID) = 1)) ORDER BY Link.Link_SectionID;");
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
			rsData = modReport.getRSreport(ref "SELECT LinkItem.*, Format([DayEnd_Date],'ddd dd mmm\", \"yyyy') AS dateName, DayEnd.DayEnd_Date FROM DayEnd INNER JOIN LinkItem ON DayEnd.DayEndID = LinkItem.LinkItem_DayEndID;");
			if (rsData.BOF | rsData.EOF) {
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

			Report.Database.Tables(1).SetDataSource(rs);
			Report.Database.Tables(2).SetDataSource(rsData);
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		private void frmItemGroup_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void frmItemGroup_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			modRecordSet.openConnection();
			modReport.openConnectionReport();

			loadLanguage();
			setup();
		}
	}
}
