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
	internal partial class frmMonthendList : System.Windows.Forms.Form
	{
		string gFilter;
		ADODB.Recordset gRS;
		string gFilterSQL;
		int gID;
		short gSection;

		private void loadLanguage()
		{

			//frmMonthendList = No Code  [Select a Month End]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmMonthendList.Caption = rsLang("LanguageLayoutLnk_Description"): frmMonthendList.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmMonthendList.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public int getItem(ref short Section)
		{
			//cmdNew.Visible = False
			gSection = Section;

			loadLanguage();
			doSearch();

			this.ShowDialog();
			return gID;

		}

		private void getNamespace()
		{
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

		private void DataList1_DblClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (!string.IsNullOrEmpty(DataList1.BoundText)) {
				if (gSection == 7) {
					if (DataList1.CtlText == "Current") {
						gID = 0;
					} else {
						gID = Convert.ToInt32(DataList1.BoundText);
					}
					this.Close();
				} else {
					My.MyProject.Forms.frmMonthendBudget.loadItem(ref Convert.ToInt32(DataList1.BoundText));
				}
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
		private void frmMonthendList_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case System.Windows.Forms.Keys.Escape:
					KeyAscii = 0;
					cmdExit_Click(cmdExit, new System.EventArgs());
					break;
			}

			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		public void loadItem(ref short Section)
		{
			Button cmdNew = new Button();
			gSection = Section;
			if (gSection)
				cmdNew.Visible = false;
			doSearch();

			loadLanguage();
			this.ShowDialog();
		}

		private void frmMonthendList_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			gRS.Close();
		}

		private void txtSearch_MyGotFocus(System.Object eventSender, System.EventArgs eventArgs)
		{
			// txtSearch.SelStart = 0
			// txtSearch.SelLength = 999
		}

		private void txtSearch_KeyDown(ref short KeyCode, ref short Shift)
		{
			switch (KeyCode) {
				case 40:
					this.DataList1.Focus();
					break;
			}
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

			gRS = modRecordSet.getRS(ref "SELECT MonthEnd.MonthEndID, IIf([MonthEndID]=[Company_MonthEndID],'Current',[Company_MonthEndID]-[MonthEndID] & ' month/s ago') AS theMonth From MonthEnd, Company ORDER BY MonthEnd.MonthEndID DESC;");
			//Display the list of Titles in the DataCombo
			DataList1.DataSource = gRS;
			DataList1.listField = "theMonth";


			//Bind the DataCombo to the ADO Recordset
			DataList1.DataSource = gRS;
			DataList1.boundColumn = "MonthEndID";

		}
	}
}
