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
	internal partial class frmItemItem : System.Windows.Forms.Form
	{
		List<Button> cmdClear = new List<Button>();
		List<Button> cmdStockItem = new List<Button>();
		List<Label> lblItem = new List<Label>();
		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2390;
			//Compare Stock Item to Stock Item|Checked
			if (modRecordSet.rsLang.RecordCount){My.MyProject.Forms.frmItem.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;My.MyProject.Forms.frmItem.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2391;
			//Select Stock Items|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//cmdClear(1) = No Code  [Clear]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdClear(1).Caption = rsLang("LanguageLayoutLnk_Description"): cmdClear(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdClear(2) = No Code  [Clear]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdClear(2).Caption = rsLang("LanguageLayoutLnk_Description"): cmdClear(2).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdClear(3) = No Code  [Clear]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdClear(3).Caption = rsLang("LanguageLayoutLnk_Description"): cmdClear(3).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdClear(4) = No Code  [Clear]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdClear(4).Caption = rsLang("LanguageLayoutLnk_Description"): cmdClear(4).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdClear(5) = No Code  [Clear]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdClear(5).Caption = rsLang("LanguageLayoutLnk_Description"): cmdClear(5).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdClear(6) = No Code  [Clear]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdClear(6).Caption = rsLang("LanguageLayoutLnk_Description"): cmdClear(6).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdClear(7) = No Code  [Clear]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdClear(7).Caption = rsLang("LanguageLayoutLnk_Description"): cmdClear(7).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdClear(8) = No Code  [Clear]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdClear(8).Caption = rsLang("LanguageLayoutLnk_Description"): cmdClear(8).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdClear(9) = No Code  [Clear]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdClear(9).Caption = rsLang("LanguageLayoutLnk_Description"): cmdClear(9).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdClear(10) = No Code  [Clear]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdClear(10).Caption = rsLang("LanguageLayoutLnk_Description"): cmdClear(10).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2382;
			//Sales Quantity|Checked
			if (modRecordSet.rsLang.RecordCount){_optDataType_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_optDataType_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2382;
			//Sales Value|Checked
			if (modRecordSet.rsLang.RecordCount){_optDataType_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_optDataType_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1269;
			//Load Report|Checked
			if (modRecordSet.rsLang.RecordCount){cmdLoad.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdLoad.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmItemItem.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		//Handles cmdClear.Click
		private void cmdClear_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			Button btn = new Button();
			btn = (Button)eventSender;
			int Index = GetIndex.GetIndexer(ref btn, ref cmdClear);
			modReport.cnnDBreport.Execute("UPDATE Link SET Link.Link_Name = '', Link.Link_SQL = '' WHERE (((Link.LinkID)=" + Index + ") AND ((Link.Link_SectionID)=3) AND ((Link.Link_PersonID)=" + modRecordSet.gPersonID + "));");
			modReport.cnnDBreport.Execute("DELETE LinkDataItem.* From LinkDataItem WHERE (((LinkDataItem.LinkDataItem_LinkID)=" + Index + ") AND ((LinkDataItem.LinkDataItem_SectionID)=3) AND ((LinkDataItem.LinkDataItem_PersonID)=" + modRecordSet.gPersonID + "));");
			modReport.cnnDBreport.Execute("DELETE LinkData.LinkData_LinkID, LinkData.LinkData_SectionID, LinkData.LinkData_PersonID, LinkData.* From LinkData WHERE (((LinkData.LinkData_LinkID)=" + Index + ") AND ((LinkData.LinkData_SectionID)=3) AND ((LinkData.LinkData_PersonID)=" + modRecordSet.gPersonID + "));");
			lblItem[Index].Text = "";

		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		//Handles cmdStockItem.Click
		private void cmdStockItem_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			Button btn = new Button();
			btn = (Button)eventSender;
			int Index = GetIndex.GetIndexer(ref btn, ref cmdStockItem);
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
				rs = modReport.getRSreport(ref "SELECT Link.Link_SQL, Link.Link_SectionID From Link WHERE (((Link.Link_SQL)='StockItemID=" + lID + "') AND ((Link.Link_SectionID)=3));");
				if (rs.RecordCount) {
				} else {
					rs.Close();

					rs = modRecordSet.getRS(ref "SELECT * FROM StockItem WHERE StockItemID=" + lID);
					modReport.cnnDBreport.Execute("UPDATE Link SET Link.Link_Name = ' " + Strings.Replace(rs.Fields("StockItem_Name").Value, "'", "''") + "', Link.Link_SQL = 'StockItemID=" + lID + "' WHERE (((Link.LinkID)=" + Index + ") AND ((Link.Link_SectionID)=3) AND ((Link.Link_PersonID)=" + modRecordSet.gPersonID + "));");
					modReport.cnnDBreport.Execute("DELETE LinkDataItem.* From LinkDataItem WHERE (((LinkDataItem.LinkDataItem_LinkID)=" + Index + ") AND ((LinkDataItem.LinkDataItem_SectionID)=3) AND ((LinkDataItem.LinkDataItem_PersonID)=" + modRecordSet.gPersonID + "));");
					modReport.cnnDBreport.Execute("DELETE LinkData.LinkData_LinkID, LinkData.LinkData_SectionID, LinkData.LinkData_PersonID, LinkData.* From LinkData WHERE (((LinkData.LinkData_LinkID)=" + Index + ") AND ((LinkData.LinkData_SectionID)=3) AND ((LinkData.LinkData_PersonID)=" + modRecordSet.gPersonID + "));");
					modReport.cnnDBreport.Execute("INSERT INTO LinkData ( LinkData_LinkID, LinkData_SectionID, LinkData_PersonID, LinkData_FieldName, LinkData_SQL, LinkData_Heading ) SELECT " + Index + ", 3, aftData.ftData_PersonID, aftData.ftData_FieldName, aftData.ftData_SQL, aftData.ftData_Heading From aftData WHERE (((aftData.ftData_PersonID)=" + modRecordSet.gPersonID + "));");
					modReport.cnnDBreport.Execute("INSERT INTO LinkDataItem ( LinkDataItem_LinkID, LinkDataItem_SectionID, LinkDataItem_PersonID, LinkDataItem_FieldName, LinkDataItem_ID ) SELECT " + Index + ", 3, aftDataItem.ftDataItem_PersonID, aftDataItem.ftDataItem_FieldName, aftDataItem.ftDataItem_ID From aftDataItem WHERE (((aftDataItem.ftDataItem_PersonID)=" + modRecordSet.gPersonID + "));");
					lblItem[Index].Text = rs.Fields("StockItem_Name").Value;
				}
			}
		}

		private void setup()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			short x = 0;
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
			rs = modReport.getRSreport(ref "SELECT Link.LinkID, Link.Link_Name From Link WHERE (((Link.Link_SectionID)=3) AND ((Link.Link_PersonID)=" + modRecordSet.gPersonID + "));");
			while (!(rs.EOF)) {
				lblItem[rs.Fields("LinkID").Value].Text = rs.Fields("Link_Name").Value;
				rs.moveNext();
			}
		}

		private void loadQTY()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsData = default(ADODB.Recordset);
			//Dim Report As New cryItemItemCompareQty
			//ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryItemItemCompareQty.rpt");
			ReportNone.Load("cryNoRecords.rpt");
			modReport.cnnDBreport.Execute("DELETE LinkItem.* FROM LinkItem;");
			rs = modReport.getRSreport(ref "SELECT * FROM Link Where Link_SectionID=3");
			while (!(rs.EOF)) {
				if (!string.IsNullOrEmpty(rs.Fields("Link_SQL").Value)) {
					modReport.cnnDBreport.Execute("INSERT INTO LinkItem ( LinkItem_LinkID, LinkItem_DayEndID, LinkItem_Value ) SELECT " + rs.Fields("LinkID").Value + ", DayEndStockItemLnk.DayEndStockItemLnk_DayEndID, DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales FROM DayEndStockItemLnk INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID WHERE " + rs.Fields("Link_SQL").Value + ";");
				}
				rs.moveNext();
			}

			modReport.cnnDBreport.Execute("INSERT INTO LinkItem ( LinkItem_LinkID, LinkItem_DayEndID, LinkItem_Value ) SELECT theJoin.LinkID, theJoin.DayEndID, 0 FROM LinkItem RIGHT JOIN [SELECT Link.LinkID, DayEnd.DayEndID From Link, DayEnd WHERE (((Link.Link_SQL)<>'') AND ((Link.Link_SectionID)=3))]. AS theJoin ON (LinkItem.LinkItem_DayEndID = theJoin.DayEndID) AND (LinkItem.LinkItem_LinkID = theJoin.LinkID) WHERE (((LinkItem.LinkItem_LinkID) Is Null));");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayEnd", rs.Fields("Report_Heading"));
			rs.Close();
			rs = modReport.getRSreport(ref "SELECT [Link].[LinkID], [Link].[Link_Name], Sum([LinkItem].[LinkItem_Value]) AS SumOfLinkItem_Value FROM Link INNER JOIN LinkItem ON [Link].[LinkID]=[LinkItem].[LinkItem_LinkID] WHERE ((([Link].[Link_SQL])<>'') And (([Link].[Link_SectionID])=3)) GROUP BY [Link].[LinkID], [Link].[Link_Name] ORDER BY [Link].[LinkID];");

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
			rsData = modReport.getRSreport(ref "SELECT LinkItem.*, Format([DayEnd_Date],'yyyy mm dd ddd') AS dateName, DayEnd.DayEnd_Date FROM DayEnd INNER JOIN LinkItem ON DayEnd.DayEndID = LinkItem.LinkItem_DayEndID ORDER BY DayEnd.DayEnd_Date;");
			if (rsData.BOF | rsData.EOF) {
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

			Report.Database.Tables(1).SetDataSource(rs);
			Report.Database.Tables(2).SetDataSource(rsData);
			System.Windows.Forms.Application.DoEvents();
			//Report.VerifyOnEveryPrint = True
			System.Windows.Forms.Application.DoEvents();
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}
		private void loadValue()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsData = default(ADODB.Recordset);
			//Dim Report As New cryItemItemCompareValue
			//ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryItemItemCompareValue.rpt");
			ReportNone.Load("cryNoRecords.rpt");
			modReport.cnnDBreport.Execute("DELETE LinkItem.* FROM LinkItem;");
			rs = modReport.getRSreport(ref "SELECT * FROM Link Where Link_SectionID=3");
			while (!(rs.EOF)) {
				if (!string.IsNullOrEmpty(rs.Fields("Link_SQL").Value)) {
					modReport.cnnDBreport.Execute("INSERT INTO LinkItem ( LinkItem_LinkID, LinkItem_DayEndID, LinkItem_Value ) SELECT " + rs.Fields("LinkID").Value + ", Sale.Sale_DayEndID, Sum([SaleItem_Quantity]*[SaleItem_Price]) FROM (SaleItem INNER JOIN aStockItem ON SaleItem.SaleItem_StockItemID = aStockItem.StockItemID) INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID Where " + rs.Fields("Link_SQL").Value + " GROUP BY Sale.Sale_DayEndID;");
				}
				rs.moveNext();
			}

			modReport.cnnDBreport.Execute("INSERT INTO LinkItem ( LinkItem_LinkID, LinkItem_DayEndID, LinkItem_Value ) SELECT theJoin.LinkID, theJoin.DayEndID, 0 FROM LinkItem RIGHT JOIN [SELECT Link.LinkID, DayEnd.DayEndID From Link, DayEnd WHERE (((Link.Link_SQL)<>'') AND ((Link.Link_SectionID)=3))]. AS theJoin ON (LinkItem.LinkItem_DayEndID = theJoin.DayEndID) AND (LinkItem.LinkItem_LinkID = theJoin.LinkID) WHERE (((LinkItem.LinkItem_LinkID) Is Null));");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayEnd", rs.Fields("Report_Heading"));
			rs.Close();
			rs = modReport.getRSreport(ref "SELECT [Link].[LinkID], [Link].[Link_Name], Sum([LinkItem].[LinkItem_Value]) AS SumOfLinkItem_Value FROM Link INNER JOIN LinkItem ON [Link].[LinkID]=[LinkItem].[LinkItem_LinkID] WHERE ((([Link].[Link_SQL])<>'') And (([Link].[Link_SectionID])=3)) GROUP BY [Link].[LinkID], [Link].[Link_Name] ORDER BY [Link].[LinkID];");

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
			rsData = modReport.getRSreport(ref "SELECT LinkItem.*, Format([DayEnd_Date],'yyyy mm dd ddd') AS dateName, DayEnd.DayEnd_Date FROM DayEnd INNER JOIN LinkItem ON DayEnd.DayEndID = LinkItem.LinkItem_DayEndID ORDER BY DayEnd.DayEnd_Date;");
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
			System.Windows.Forms.Application.DoEvents();
			//Report.VerifyOnEveryPrint = True
			System.Windows.Forms.Application.DoEvents();
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		private void cmdLoad_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (_optDataType_0.Checked) {
				loadQTY();
			} else {
				loadValue();
			}
		}

		private void frmItemItem_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void frmItemItem_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdClear.AddRange(new Button[] {
				_cmdClear_1,
				_cmdClear_2,
				_cmdClear_3,
				_cmdClear_4,
				_cmdClear_5,
				_cmdClear_6,
				_cmdClear_7,
				_cmdClear_8,
				_cmdClear_9,
				_cmdClear_10
			});
			cmdStockItem.AddRange(new Button[] {
				_cmdStockItem_1,
				_cmdStockItem_2,
				_cmdStockItem_3,
				_cmdStockItem_4,
				_cmdStockItem_5,
				_cmdStockItem_6,
				_cmdStockItem_7,
				_cmdStockItem_8,
				_cmdStockItem_9,
				_cmdStockItem_10
			});
			lblItem.AddRange(new Label[] {
				_lblItem_1,
				_lblItem_2,
				_lblItem_3,
				_lblItem_4,
				_lblItem_5,
				_lblItem_6,
				_lblItem_7,
				_lblItem_8,
				_lblItem_9,
				_lblItem_10
			});
			Button bt = new Button();
			foreach (Button bt_loopVariable in cmdClear) {
				bt = bt_loopVariable;
				bt.Click += cmdClear_Click;
			}
			foreach (Button bt_loopVariable in cmdStockItem) {
				bt = bt_loopVariable;
				bt.Click += cmdStockItem_Click;
			}
			modRecordSet.openConnection();
			modReport.openConnectionReport();

			loadLanguage();
			setup();
		}
	}
}
