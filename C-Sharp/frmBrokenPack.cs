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

	internal partial class frmBrokenPack : System.Windows.Forms.Form
	{
		private void loadLanguage()
		{

			//frmBrokenPack = No Caption?

			//Recomend changing image text to lablels

			//WARNING: Label caption still contains old name "Liquid"!!!
			//_Label2_0 = No Code    [Some suppliers do not allow you to order.......]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _Label2_0.Caption = rsLang("LanguageLayoutLnk_Description"): _Label2_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1006;
			//Filter|Checked
			if (modRecordSet.rsLang.RecordCount){cmdFilter.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdFilter.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_Label2_1 = No Code    [If you have not sold that proportion of a case.......]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _Label2_1.Caption = rsLang("LanguageLayoutLnk_Description"): _Label2_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1085;
			//Print
			if (modRecordSet.rsLang.RecordCount){cmdPrint.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPrint.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//cmdBuild = No Code     [Execute]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdBuild.Caption = rsLang("LanguageLayoutLnk_Description"): cmdBuild.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmBrokenPack.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdBuild_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string gCriteria = null;
			string sql = null;
			decimal lValue = default(decimal);
			if (Interaction.MsgBox("By selecting 'Yes' you will alter the 'break pack' parameter of several stock items." + Constants.vbCrLf + Constants.vbCrLf + "Are you sure you wish to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "CONTINUE") == MsgBoxResult.Yes) {
				modRecordSet.cnnDB.Execute("UPDATE StockItem SET StockItem.StockItem_OrderQuantity = [StockItem]![StockItem_Quantity];");
				if (this.cmbSize.SelectedIndex) {
					switch (this.cmbSize.SelectedIndex) {
						case 1:
							lValue = 1;
							break;
						case 2:
							lValue = 0.75;
							break;
						case 3:
							lValue = 0.666666;
							break;
						case 4:
							lValue = 0.5;
							break;
						case 5:
							lValue = 0.33333;
							break;
						case 6:
							lValue = 0.25;
							break;
						case 7:
							break;
					}

					My.MyProject.Forms.frmFilterOrder.buildCriteria(ref "order");
					sql = "UPDATE StockItem INNER JOIN StockitemHistory ON StockItem.StockItemID = StockitemHistory.StockitemHistory_StockItemID SET StockItem.StockItem_OrderQuantity = 1 WHERE ((([StockitemHistory_Day2]+[StockitemHistory_Day3]+[StockitemHistory_Day4]+[StockitemHistory_Day5]+[StockitemHistory_Day6]+[StockitemHistory_Day7]+[StockitemHistory_Day8]+[StockitemHistory_Day9]+[StockitemHistory_Day10]+[StockitemHistory_Day11])<cInt([StockItem]![StockItem_Quantity]*" + lValue + ")) AND ((StockItem.StockItem_Quantity)<>1))";
					//UPGRADE_WARNING: Couldn't resolve default property of object gCriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (!string.IsNullOrEmpty(gCriteria)) {
						//UPGRADE_WARNING: Couldn't resolve default property of object gCriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						sql = sql + gCriteria;
					}
					modRecordSet.cnnDB.Execute(sql);
				}
				this.Close();
			}
		}

		private void cmdFilter_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmFilterOrder.loadFilter(ref "order");
			My.MyProject.Forms.frmFilterOrder.buildCriteria(ref "order");
			this.lblHeading.Text = My.MyProject.Forms.frmFilterOrder.gHeading;
		}

		private void Command1_Click()
		{

		}

		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string sql = null;
			decimal lValue = default(decimal);
			ADODB.Recordset rs = default(ADODB.Recordset);
			//Dim Report As New cryBrokenPack
			ReportDocument Report = default(ReportDocument);
			Report.Load("cryBrokenPack.rpt");
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtCompanyName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();
			switch (this.cmbSize.SelectedIndex) {
				case 0:
					lValue = 1;
					break;
				case 1:
					lValue = 1;
					break;
				case 2:
					lValue = 0.75;
					break;
				case 3:
					lValue = 0.666666;
					break;
				case 4:
					lValue = 0.5;
					break;
				case 5:
					lValue = 0.33333;
					break;
				case 6:
					lValue = 0.25;
					break;
				case 7:
					break;
			}

			My.MyProject.Forms.frmFilterOrder.buildCriteria(ref "order");
			sql = "SELECT StockItem.StockItem_Name, [StockitemHistory_Day2]+[StockitemHistory_Day3]+[StockitemHistory_Day4]+[StockitemHistory_Day5]+[StockitemHistory_Day6]+[StockitemHistory_Day7]+[StockitemHistory_Day8]+[StockitemHistory_Day9]+[StockitemHistory_Day10]+[StockitemHistory_Day11] AS HistoryQTY, StockItem.StockItem_Quantity, StockItem.StockItem_OrderDynamic, StockItem.StockItem_OrderRounding, StockItem.StockItem_OrderQuantity FROM StockItem INNER JOIN StockitemHistory ON StockItem.StockItemID = StockitemHistory.StockitemHistory_StockItemID Where ((([StockitemHistory_Day2] + [StockitemHistory_Day3] + [StockitemHistory_Day4] + [StockitemHistory_Day5] + [StockitemHistory_Day6] + [StockitemHistory_Day7] + [StockitemHistory_Day8] + [StockitemHistory_Day9] + [StockitemHistory_Day10] + [StockitemHistory_Day11]) < [StockItem]![StockItem_Quantity] * " + lValue + ") And ((StockItem.StockItem_Quantity) <> 1) And ((StockItem.StockItem_OrderQuantity) <> 1)) " + My.MyProject.Forms.frmFilterOrder.gCriteria + " ";
			sql = sql + "ORDER BY StockItem.StockItem_Name;";
			rs = modRecordSet.getRS(ref sql);
			//ReportNone.Load("cryNoRecords.rpt")
			ReportDocument ReportNone = default(ReportDocument);
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				//UPGRADE_WARNING: Couldn't resolve default property of object ReportNone.txtTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
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
			Report.SetDataSource(rs);
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

		private void frmBrokenPack_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void frmBrokenPack_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmFilterOrder.buildCriteria(ref "order");

			this.lblHeading.Text = My.MyProject.Forms.frmFilterOrder.gHeading;
			this.cmbSize.SelectedIndex = 0;

			loadLanguage();
		}
	}
}
