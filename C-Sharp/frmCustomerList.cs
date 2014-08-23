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
	internal partial class frmCustomerList : System.Windows.Forms.Form
	{
		string gFilter;
		ADODB.Recordset gRS;
		string gFilterSQL;
		short gSection;
		bool gAll;
		int gID;

		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1306;
			//Select a Customer|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

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
			//UPGRADE_ISSUE: Form property frmCustomerList.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public int getItem(ref short Section)
		{
			gSection = Section;
			cmdNew.Visible = false;

			if (Section == 8)
				gID = 0;
			doSearch();
			loadLanguage();

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

		private void cmdNew_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmCustomer.loadItem(ref 0);
			doSearch();
		}

		private void DataList1_DblClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (!string.IsNullOrEmpty(DataList1.BoundText)) {
				switch (gSection) {
					case 0:
						My.MyProject.Forms.frmCustomer.loadItem(ref Convert.ToInt32(DataList1.BoundText));
						break;
					case 1:
						My.MyProject.Forms.frmCustomerTransaction.loadItem(ref Convert.ToInt32(DataList1.BoundText), ref 0);
						break;
					case 2:
						My.MyProject.Forms.frmCustomerTransaction.loadItem(ref Convert.ToInt32(DataList1.BoundText), ref 1);
						break;
					case 3:
						My.MyProject.Forms.frmCustomerTransaction.loadItem(ref Convert.ToInt32(DataList1.BoundText), ref 2);
						break;
					case 4:
						My.MyProject.Forms.frmCustomerTransactionNotes.loadItem(ref Convert.ToInt32(DataList1.BoundText), ref 3);
						break;
					case 5:
						My.MyProject.Forms.frmCustomerTransactionNotes.loadItem(ref Convert.ToInt32(DataList1.BoundText), ref 4);
						break;
					case 6:
						My.MyProject.Forms.frmCustomerHistory.loadItem(ref Convert.ToInt32(DataList1.BoundText));
						break;
					case 7:
						My.MyProject.Forms.frmCustomerAllocPayment.loadItem(ref Convert.ToInt32(DataList1.BoundText));
						break;
					case 8:
						gID = Convert.ToInt32(DataList1.BoundText);
						this.Close();
						break;
				}
			}
			doSearch();
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

		public void loadItem(ref short Section)
		{
			gSection = Section;
			if (gSection)
				cmdNew.Visible = false;
			doSearch();

			loadLanguage();
			ShowDialog();

		}

		private void frmCustomerList_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			gRS.Close();
		}
		private void frmCustomerList_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 27) {
				KeyAscii = 0;
				cmdExit_Click(cmdExit, new System.EventArgs());
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmCustomerList_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			if (KeyCode == 36) {
				gAll = !gAll;
				doSearch();
				KeyCode = false;
			}
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
			lString = Strings.Replace(lString, "'", "");
			if (string.IsNullOrEmpty(lString)) {
			} else {
				lString = "WHERE (Customer_InvoiceName LIKE '%" + Strings.Replace(lString, " ", "%' AND Customer_InvoiceName LIKE '%") + "%')";
			}
			if (gAll) {
			} else {
				if (string.IsNullOrEmpty(lString)) {
					lString = " WHERE Customer_Disabled = 0 ";
				} else {
					lString = lString + " AND Customer_Disabled = 0 ";
				}
			}
			gRS = modRecordSet.getRS(ref "SELECT DISTINCT CustomerID, Customer_InvoiceName FROM Customer " + lString + " ORDER BY Customer_InvoiceName");
			//Display the list of Titles in the DataCombo
			DataList1.DataSource = gRS;
			DataList1.listField = "Customer_InvoiceName";

			//Bind the DataCombo to the ADO Recordset
			DataList1.DataSource = gRS;
			DataList1.boundColumn = "CustomerID";

		}
	}
}
