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
	internal partial class frmPrintLocationList : System.Windows.Forms.Form
	{
		string gFilter;
		ADODB.Recordset gRS;
		string gFilterSQL;
		int gID;

		private void loadLanguage()
		{

			//frmPrintLocationList = No Code     [Select a Printer Location]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmPrintLocationList.Caption = rsLang("LanguageLayoutLnk_Description"): frmPrintLocationList.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1080;
			//Search|Checked
			if (modRecordSet.rsLang.RecordCount){lbl.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1065;
			//New|Checked
			if (modRecordSet.rsLang.RecordCount){cmdNew.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdNew.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmPrintLocationList.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public int getItem()
		{

			loadLanguage();
			this.ShowDialog();
			return gID;
		}

		private void getNamespace()
		{
		}

		private void cmdDel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			short intres = 0;

			if (!string.IsNullOrEmpty(DataList1.BoundText)) {
				//UPGRADE_NOTE: Text was upgraded to CtlText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
				if (Interaction.MsgBox("Do you want to delete this '" + DataList1.CtlText + "'  Print Location?", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Question + MsgBoxStyle.YesNo, _4PosBackOffice.NET.My.MyProject.Application.Info.Title) == MsgBoxResult.Yes) {
				} else {
					return;
				}

				rs = modRecordSet.getRS(ref "SELECT * FROM PrintLocation;");
				if (rs.RecordCount > 1) {
					modRecordSet.cnnDB.Execute("DELETE * FROM PrintLocation WHERE PrintLocationID =" + Conversion.Val(DataList1.BoundText) + ";");
				} else {
					//UPGRADE_NOTE: Text was upgraded to CtlText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
					Interaction.MsgBox("Couldn't delete '" + DataList1.CtlText + "'. Atleast one Print Location is required.");
				}
				doSearch();
			}
		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdNamespace_Click()
		{
			My.MyProject.Forms.frmFilter.loadFilter(ref gFilter);
			getNamespace();
		}

		private void cmdNew_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmPrintLocation.loadItem(ref 0);
			doSearch();
		}

		private void DataList1_DblClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (cmdNew.Visible) {
				if (!string.IsNullOrEmpty(DataList1.BoundText)) {
					My.MyProject.Forms.frmPrintLocation.loadItem(ref Convert.ToInt32(DataList1.BoundText));
				}
				doSearch();
			} else {
				if (string.IsNullOrEmpty(DataList1.BoundText)) {
					gID = 0;
				} else {
					gID = Convert.ToInt32(DataList1.BoundText);
				}
				this.Close();
			}
		}

		private void DataList1_KeyPress(System.Object eventSender, KeyPressEventArgs eventArgs)
		{
			switch (eventArgs.KeyChar) {
				case Strings.ChrW(13):
					DataList1_DblClick(DataList1, new System.EventArgs());
					eventArgs.KeyChar = Strings.ChrW(0);
					break;
				case Strings.ChrW(27):
					this.Close();
					eventArgs.KeyChar = Strings.ChrW(0);
					break;
			}

		}

		private void frmPrintLocationList_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			doSearch();
		}

		private void frmPrintLocationList_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
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
			if (string.IsNullOrEmpty(lString)) {
			} else {
				lString = "WHERE (PrintLocation_Name LIKE '%" + Strings.Replace(lString, " ", "%' AND PrintLocation_Name LIKE '%") + "%')";
			}
			gRS = modRecordSet.getRS(ref "SELECT DISTINCT * FROM PrintLocation " + lString + " ORDER BY PrintLocation_Name");
			//Display the list of Titles in the DataCombo
			DataList1.DataSource = gRS;
			DataList1.listField = "PrintLocation_Name";


			//Bind the DataCombo to the ADO Recordset
			//UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
			DataList1.DataSource = gRS;
			DataList1.boundColumn = "PrintLocationID";

		}
	}
}
