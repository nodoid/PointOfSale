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
	internal partial class frmStockValSelect : System.Windows.Forms.Form
	{
		string gFilter;
		ADODB.Recordset gRS;
		string gFilterSQL;
		int gID;
		short gSection;
		bool gAll;
		string grpDelete;

		private void loadLanguage()
		{

			//frmStockValSelect = No Code    [Stock Value Report]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmStockValSelect.Caption = rsLang("LanguageLayoutLnk_Description"): frmStockValSelect.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1238;
			//Select option for Detail/Summary|Checked
			if (modRecordSet.rsLang.RecordCount){lblHeading.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lblHeading.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1080;
			//Search|Checked
			if (modRecordSet.rsLang.RecordCount){lbl.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1240;
			//Select Group|Checked
			if (modRecordSet.rsLang.RecordCount){ckbGrp.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;ckbGrp.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1242;
			//Detail|Checked
			if (modRecordSet.rsLang.RecordCount){optDel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;optDel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1243;
			//Summary|Checked
			if (modRecordSet.rsLang.RecordCount){optSum.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;optSum.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1085;
			//Print|Checked
			if (modRecordSet.rsLang.RecordCount){cmdShow.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdShow.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmStockValSelect.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

//UPGRADE_WARNING: Event ckbGrp.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void ckbGrp_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtSearch.Enabled = ckbGrp.CheckState;
			DataList1.Enabled = ckbGrp.CheckState;
			lstFilter.Enabled = ckbGrp.CheckState;
		}


		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}


		private void cmdShow_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short x = 0;

			gFilterSQL = "";
			for (x = 0; x <= lstFilter.Items.Count - 1; x++) {
				if (lstFilter.GetItemChecked(x)) {
					//Set gRS = getRS("SELECT StockGRoupID, StockGRoup_Name FROM StockGRoup WHERE StockGRoup_Name = '" & lstFilter.ItemData(x) & "'")
					gFilterSQL = gFilterSQL + " OR ((StockGroup.StockGroupID)=" + Convert.ToInt64(lstFilter.SelectedItem(x)) + ")";
				}
			}
			//((StockGroup.StockGroupID)=6)
			gFilterSQL = Strings.Mid(gFilterSQL, 5);

			if (ckbGrp.CheckState == 1) {
				if (optDel.Checked == true) {
					modApplication.report_StockValuebyGX(ref (gFilterSQL));
					//(gID)
				} else if (optSum.Checked == true) {
					modApplication.report_StockValuebyGS(ref (gFilterSQL));
					//(gID)
				}
			} else {
				if (optDel.Checked == true) {
					modApplication.report_StockValuebyGX(ref (""));
				} else if (optSum.Checked == true) {
					modApplication.report_StockValuebyGS(ref (""));
				}
			}
		}


		private void doSearch()
		{
			short x = 0;
			string sql = null;
			string lString = null;
			lString = Strings.Trim(txtSearch.Text);
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			if (string.IsNullOrEmpty(lString)) {
			} else {
				lString = "WHERE (StockGRoup_Name LIKE '%" + Strings.Replace(lString, " ", "%' AND StockGRoup_Name LIKE '%") + "%')";

			}
			if (gAll) {
			} else {
				if (string.IsNullOrEmpty(lString)) {
					lString = " WHERE StockGroup_Disabled = 0 ";
				} else {
					lString = lString + " AND StockGroup_Disabled = 0 ";
				}
			}

			gRS = modRecordSet.getRS(ref "SELECT DISTINCT StockGRoupID, StockGRoup_Name FROM StockGRoup " + lString + " ORDER BY StockGRoup_Name");

			//Display the list of Titles in the DataCombo
			DataList1.DataSource = gRS;
			//Set lstFilter.DataSource = gRS
			DataList1.listField = "StockGRoup_Name";

			//Bind the DataCombo to the ADO Recordset
			//UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
			DataList1.DataSource = gRS;
			DataList1.boundColumn = "StockGRoupID";
			int m = 0;
			lstFilter.Items.Clear();
			for (x = 0; x <= (gRS.RecordCount - 1); x++) {
				//If InStr(UCase(gArray(x, 1)), UCase(Me.txtSearch.Text)) Then
				lstFilter.Items.Add(gRS.Fields("StockGRoup_Name").Value);
				//gArray(x, 1)
				m = lstFilter.Items.Add(new SetItemData(lstFilter.SelectedIndex, gRS.Fields("StockGRoupID").Value));
				lstFilter.SetItemChecked(m, 0);
				gRS.moveNext();
				//End If
			}

		}

		private void DataList1_ClickEvent(System.Object eventSender, KeyEventArgs eventArgs)
		{
			if (string.IsNullOrEmpty(DataList1.BoundText)) {
				gID = 0;
			} else {
				gID = Convert.ToInt32(DataList1.BoundText);
			}
		}

		private void frmStockValSelect_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtSearch.Enabled = ckbGrp.CheckState;
			DataList1.Enabled = ckbGrp.CheckState;
			lstFilter.Enabled = ckbGrp.CheckState;

			loadLanguage();

			doSearch();
		}


		private void frmStockValSelect_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
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
					//Me.DataList1.SetFocus
					this.lstFilter.Focus();
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
	}
}
