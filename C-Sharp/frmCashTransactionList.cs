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
	internal partial class frmCashTransaction : System.Windows.Forms.Form
	{
		ADODB.Recordset gRS;
		int gID;

		private void loadLanguage()
		{

			//frmCashTransacion = No Code    [Cash Transactions]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmCashTransaction.Caption = rsLang("LanguageLayoutLnk_Description"): frmCashTransaction.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1085;
			//Print|Checked
			if (modRecordSet.rsLang.RecordCount){cmdPrint.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPrint.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1147;
			//Add|Checked
			if (modRecordSet.rsLang.RecordCount){cmdNew.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdNew.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1148;
			//Delete|Checked
			if (modRecordSet.rsLang.RecordCount){cmdDelete.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdDelete.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmCashTransaction.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdDelete_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string lQty = null;
			int lID = 0;
			if (lvItem.FocusedItem == null) {
			} else {
				if (Interaction.MsgBox("Are you sure you wish to remove " + lvItem.FocusedItem.Text + " as a cash transaction?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "DELETE") == MsgBoxResult.Yes) {
					lID = Convert.ToInt32(Strings.Split(lvItem.FocusedItem.Name, "_")[0]);
					//UPGRADE_WARNING: Couldn't resolve default property of object lQty. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lQty = Strings.Split(lvItem.FocusedItem.Name, "_")[1];
					//UPGRADE_WARNING: Couldn't resolve default property of object lQty. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modRecordSet.cnnDB.Execute("DELETE CashTransaction.* FROM CashTransaction WHERE (((CashTransaction.CashTransaction_StockItemID)=" + lID + ") AND ((CashTransaction.CashTransaction_Shrink)=" + lQty + "));");
					doSearch();
				}
			}

		}

		private void cmdExit_Click()
		{
			this.Close();
		}

		private void cmdNew_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int lID = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);

			lID = My.MyProject.Forms.frmStockList.getItem();
			if (lID != 0) {
				 // ERROR: Not supported in C#: OnErrorStatement

				My.MyProject.Forms.frmCashTransactionItem.loadItem(ref lID, ref 0);
				doSearch();
			}

		}

		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsQty = default(ADODB.Recordset);
			ADODB.Recordset RSitem = default(ADODB.Recordset);
			bool ltype = false;
			//Dim Report As New cryCashTransaction
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryCashTransaction.rpt");
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtCompanyName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();

			rs = modRecordSet.getRS(ref "SELECT * FROM Channel ORDER BY ChannelID");
			while (!(rs.EOF)) {
				switch (rs.Fields("ChannelID").Value) {
					case 1:
						Report.SetParameterValue("txtCS1", rs.Fields("Channel_Code"));
						break;
					case 2:
						Report.SetParameterValue("txtCS2", rs.Fields("Channel_Code"));
						break;
					case 3:
						Report.SetParameterValue("txtCS3", rs.Fields("Channel_Code"));
						break;
					case 4:
						Report.SetParameterValue("txtCS4", rs.Fields("Channel_Code"));
						break;
					case 5:
						Report.SetParameterValue("txtCS5", rs.Fields("Channel_Code"));
						break;
					case 6:
						Report.SetParameterValue("txtCS6", rs.Fields("Channel_Code"));
						break;
					case 7:
						Report.SetParameterValue("txtCS7", rs.Fields("Channel_Code"));
						break;
					case 8:
						Report.SetParameterValue("txtCS8", rs.Fields("Channel_Code"));
						break;
				}
				rs.moveNext();
			}
			rs.Close();

			rs = modRecordSet.getRS(ref "SELECT CashTransaction.*, StockItem.StockItem_Name FROM StockItem INNER JOIN CashTransaction ON StockItem.StockItemID = CashTransaction.CashTransaction_StockItemID;");
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
				//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

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

		private void frmCashTransaction_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case System.Windows.Forms.Keys.Escape:
					KeyAscii = 0;
					cmdExit_Click();
					break;
			}

			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		public void loadItem()
		{
			lvItem.Columns.Clear();
			lvItem.Columns.Add("", "Stock Item", Convert.ToInt32(sizeConvertors.twipsToPixels(4050, true)));
			lvItem.Columns.Add("QTY", Convert.ToInt32(sizeConvertors.twipsToPixels(800, true)), System.Windows.Forms.HorizontalAlignment.Right);
			lvItem.Columns.Add("Price", Convert.ToInt32(sizeConvertors.twipsToPixels(1440, true)), System.Windows.Forms.HorizontalAlignment.Right);
			doSearch();

			loadLanguage();
			this.ShowDialog();
		}

		private void frmCashTransaction_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			gRS.Close();
		}


		private void txtSearch_KeyPress(ref short KeyAscii)
		{
			switch (KeyAscii) {
				case 13:
					doSearch();
					KeyAscii = 0;
					break;
			}
		}

		private void doSearch()
		{
			string sql = null;
			string lString = null;
			System.Windows.Forms.ListViewItem lLI = null;
			gRS = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, CashTransaction.CashTransaction_StockItemID, CashTransaction.CashTransaction_Shrink, StockItem.StockItem_PriceSetID, CashTransaction.CashTransaction_Type, CashTransaction_Amount FROM CashTransaction INNER JOIN StockItem ON CashTransaction.CashTransaction_StockItemID = StockItem.StockItemID ORDER BY StockItem.StockItem_Name;");

			//Display the list of Titles in the DataCombo
			lvItem.Items.Clear();
			while (!(gRS.EOF)) {
				lLI = lvItem.Items.Add(gRS.Fields("CashTransaction_StockItemID").Value + "_" + gRS.Fields("CashTransaction_Shrink").Value, gRS.Fields("StockItem_Name").Value, "");
				//UPGRADE_WARNING: Lower bound of collection lLI has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				if (lLI.SubItems.Count > 1) {
					lLI.SubItems[1].Text = gRS.Fields("CashTransaction_Shrink").Value;
				} else {
					lLI.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, gRS.Fields("CashTransaction_Shrink").Value));
				}
				//UPGRADE_WARNING: Lower bound of collection lLI has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				if (lLI.SubItems.Count > 2) {
					lLI.SubItems[2].Text = Strings.FormatNumber(gRS.Fields("CashTransaction_Amount").Value, 2);
				} else {
					lLI.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(gRS.Fields("CashTransaction_Amount").Value, 2)));
				}
				gRS.moveNext();
			}

		}


		private void lvItem_DoubleClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			int lID = 0;
			short lQty = 0;
			if (lvItem.FocusedItem == null) {
			} else {
				lID = Convert.ToInt32(Strings.Split(lvItem.FocusedItem.Name, "_")[0]);
				lQty = Convert.ToInt16(Strings.Split(lvItem.FocusedItem.Name, "_")[1]);

				My.MyProject.Forms.frmCashTransactionItem.loadItem(ref lID, ref Convert.ToInt16(lQty));
				doSearch();
			}

		}

		private void lvItem_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 13) {
				lvItem_DoubleClick(lvItem, new System.EventArgs());
			}

			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
	}
}
