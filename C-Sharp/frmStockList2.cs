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
	internal partial class frmStockList2 : System.Windows.Forms.Form
	{
		string gFilter;
		ADODB.Recordset gRS;
		string gFilterSQL;
		short gSection;
		int gID;
		bool gAll;

		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2113;
			//Select a Stock Item|Checked
			if (modRecordSet.rsLang.RecordCount){My.MyProject.Forms.frmStockList.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;My.MyProject.Forms.frmStockList.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1080;
			//Search|Checked
			if (modRecordSet.rsLang.RecordCount){lbl.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1006;
			//Filter|Checked
			if (modRecordSet.rsLang.RecordCount){cmdNamespace.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdNamespace.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lblHeading = No Code   [Using the "Stock Item Selector"...]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblHeading.Caption = rsLang("LanguageLayoutLnk_Description"): lblHeading.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmStockList2.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

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
			doSearch();
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

		private void DataList1_DblClick(System.Object eventSender, KeyPressEventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			if (string.IsNullOrEmpty(DataList1.BoundText))
				return;
			int lID = 0;
			lID = Convert.ToInt32(DataList1.BoundText);
			switch (gSection) {
				case -1:
					gID = Convert.ToInt32(DataList1.BoundText);
					this.Close();
					break;
				case 0:
					My.MyProject.Forms.frmStockItem.loadItem(ref Convert.ToInt32(DataList1.BoundText));
					frmStockItem formItem = null;
					formItem.Show();
					break;
				case 1:
					My.MyProject.Forms.frmStockPricing.loadItem(ref Convert.ToInt32(DataList1.BoundText));
					frmStockPricing formPrice = null;
					formPrice.Show();
					break;
				case 2:
					modApplication.report_StockQuantity(ref Convert.ToInt32(DataList1.BoundText));
					break;
			}
			gRS.Requery();
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			DataList1.CtlRefresh();
		}

		private void DataList1_KeyPress(System.Object eventSender, KeyPressEventArgs eventArgs)
		{
			switch (eventArgs.KeyChar) {
				case Strings.ChrW(13):
					DataList1_DblClick(DataList1, new System.EventArgs());
					eventArgs.KeyChar = Strings.ChrW(0);
					break;
			}
		}

		public int getItem()
		{
			editItem(ref -1);

			loadLanguage();
			ShowDialog();
			return gID;
		}
		public void editItem(ref short lSection)
		{
			gSection = lSection;
			gFilter = "StockItem";
			getNamespace();
		}


		private void frmStockList2_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			if (KeyCode == 36) {
				gAll = !gAll;
				doSearch();
				KeyCode = false;
			}
		}

		private void frmStockList2_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void frmStockList2_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			gRS.Close();

		}

		private void txtSearch_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtSearch.SelectionStart = 0;
			txtSearch.SelectionLength = 999;
		}

		private void txtSearch_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			switch (KeyCode) {
				case 40:
					this.DataList1.Focus();
					break;
			}
		}

		private void txtSearch_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case 13:
					doSearch();
					KeyAscii = 0;
					break;
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void doSearch()
		{
			string sql = null;
			string lString = null;
			lString = Strings.Trim(txtSearch.Text);
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");

			if (string.IsNullOrEmpty(Strings.Trim(txtSearch.Text))) {
				lString = gFilterSQL;
			} else {
				lString = "(StockItem_Name LIKE '%" + Strings.Replace(lString, " ", "%' AND StockItem_Name LIKE '%") + "%')";
				if (string.IsNullOrEmpty(gFilterSQL)) {
					lString = " WHERE " + lString;
				} else {
					lString = gFilterSQL + " AND " + lString;
				}
			}
			if (gAll) {
			} else {
				if (string.IsNullOrEmpty(lString)) {
					lString = " WHERE StockItem.StockItem_Disabled = 0 Or StockItem.StockItem_Discontinued = 0 ";
				} else {
					lString = lString + " AND (StockItem.StockItem_Disabled = 0 Or StockItem.StockItem_Discontinued = 0) ";
				}
			}
			gRS = modRecordSet.getRS(ref "SELECT DISTINCT StockItemID, StockItem_Name FROM StockItem " + lString + " ORDER BY StockItem_Name");
			if (gRS.RecordCount) {
			} else {
				if (string.IsNullOrEmpty(Strings.Trim(txtSearch.Text))) {
				} else {
					if (Information.IsNumeric(txtSearch.Text)) {
						lString = Strings.Trim(txtSearch.Text);
						lString = Strings.Replace(lString, "  ", " ");
						lString = Strings.Replace(lString, "  ", " ");
						lString = Strings.Replace(lString, "  ", " ");
						lString = Strings.Replace(lString, "  ", " ");
						lString = Strings.Replace(lString, "  ", " ");
						lString = Strings.Replace(lString, "  ", " ");
						lString = "WHERE (Catalogue_Barcode LIKE '%" + Strings.Replace(lString, " ", "%' AND StockItem_Name LIKE '%") + "%')";
						if (gAll) {
						} else {
							lString = lString + " AND StockItem.StockItem_Disabled = 0 And StockItem.StockItem_Discontinued = 0 ";
						}

						gRS = modRecordSet.getRS(ref "SELECT DISTINCT StockItem.StockItemID, StockItem.StockItem_Name FROM Catalogue INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID " + lString + " ORDER BY StockItem.StockItem_Name;");
					}
				}
			}
			//Display the list of Titles in the DataCombo
			DataList1.DataSource = gRS;
			DataList1.listField = "StockItem_Name";


			//Bind the DataCombo to the ADO Recordset
			//UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
			DataList1.DataSource = gRS;
			DataList1.boundColumn = "StockItemID";

		}
	}
}
