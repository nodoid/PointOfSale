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
	internal partial class frmLangList : System.Windows.Forms.Form
	{
		string gFilter;
		ADODB.Recordset gRS;
		string gFilterSQL;
		int gID;
		short gSection;
		bool gAll;
		public void loadItem(ref short section)
		{
			gSection = section;
			if (gSection)
				cmdNew.Visible = false;
			doSearch();
			this.ShowDialog();
		}
		public int getItem()
		{
			cmdNew.Visible = false;
			this.ShowDialog();
			return gID;
		}
		private void getNamespace()
		{
		}

		private void cmdBOMenu_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmLangMenu.loadItem(ref 0);
		}

		private void cmdDel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			short intres = 0;


			if (!string.IsNullOrEmpty(DataList1.Columns.ToString())) {
				if (Interaction.MsgBox("Do you want to delete this '" + DataList1.Columns.ToString() + "' language?", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Question + MsgBoxStyle.YesNo, _4PosBackOffice.NET.My.MyProject.Application.Info.Title) == MsgBoxResult.Yes) {
				} else {
					return;
				}

				rs = modRecordSet.getRS(ref "SELECT * FROM LanguageLayout;");
				if (rs.RecordCount > 1) {
					modRecordSet.cnnDB.Execute("DELETE * FROM LanguageLayout WHERE LanguageLayoutID =" + Conversion.Val(DataList1.Columns.ToString()) + ";");
				} else {
					Interaction.MsgBox("Couldn't delete '" + DataList1.Columns.ToString() + "'. Atleast one Language is required.");
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

		private void cmdImport_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmLangImport.ShowDialog();
			doSearch();
		}

		private void cmdNew_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			modRecordSet.cnnDB.Execute("INSERT INTO LanguageLayout ( LanguageLayout_Name ) SELECT 'New Language';");
			rs = modRecordSet.getRS(ref "SELECT Max(LanguageLayout.LanguageLayoutID) AS MaxOfLanguageLayoutID FROM LanguageLayout;");
			My.MyProject.Forms.frmLang.loadItem(ref rs.Fields("MaxOfLanguageLayoutID").Value);
			doSearch();
		}
		private void DataList1_DblClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (cmdNew.Visible) {
				if (!string.IsNullOrEmpty(DataList1.Columns.ToString())) {
					My.MyProject.Forms.frmLang.loadItem(ref DataList1.Columns.ToString());
				}
				doSearch();
			} else {
				if (string.IsNullOrEmpty(DataList1.Columns.ToString())) {
					gID = 0;
				} else {
					gID = Convert.ToInt32(DataList1.Columns.ToString());
				}
				this.Close();
			}
		}

		private void DataList1_KeyPress(System.Object eventSender, KeyPressEventArgs eventArgs)
		{
			switch (eventArgs.KeyChar) {
				case Strings.Chr(13):
					DataList1_DblClick(DataList1, new System.EventArgs());
					eventArgs.KeyChar = Strings.Chr(0);
					break;
				case Strings.Chr(27):
					this.Close();
					eventArgs.KeyChar = Strings.Chr(0);
					break;
			}

		}

		private void frmLangList_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			if (KeyCode == 36) {
				gAll = !gAll;
				doSearch();
				KeyCode = false;
			}
		}

		private void frmLangList_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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
		private void frmLangList_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			doSearch();
		}
		private void frmLangList_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
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
			lString = " WHERE (LanguageLayout_Name LIKE '%" + Strings.Replace(lString, " ", "%' AND LanguageLayout_Name LIKE '%") + "%')";
			gRS = modRecordSet.getRS(ref "SELECT LanguageLayout.LanguageLayoutID, LanguageLayout.LanguageLayout_Name FROM LanguageLayout " + lString + " ORDER BY LanguageLayout_Name");

			//Display the list of Titles in the DataCombo
			DataList1.DataBindings.Add(gRS);
			DataList1.Columns.Add("LanguageLayout_Name", "");

			//Bind the DataCombo to the ADO Recordset
			//UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
			DataList1.DataSource = gRS;
			DataList1.Columns.Add("LanguageLayoutID", "");

		}
	}
}
