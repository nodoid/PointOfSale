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
	internal partial class frmPayoutGroupList : System.Windows.Forms.Form
	{
		string gFilter;
		ADODB.Recordset gRS;
		string gFilterSQL;
		int gID;
		short gSection;
		bool gAll;
		string grpDelete;

		public int getItem()
		{
			cmdNew.Text = "&All";
			cmdNew.Visible = false;
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

		private void cmdNew_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (gSection) {
				//Exit form and set indicator to suggest all
				gID = -1;
			} else {
				My.MyProject.Forms.frmPayoutGroup.loadItem(ref 0);
			}
			doSearch();
		}


		private void DataList1_DblClick(System.Object eventSender, KeyPressEventArgs eventArgs)
		{
			if (cmdNew.Visible) {
				if (!string.IsNullOrEmpty(DataList1.BoundText)) {
					My.MyProject.Forms.frmPayoutGroup.loadItem(ref Convert.ToInt32(DataList1.BoundText));
				}
				doSearch();
			} else {
				//If DataList1.BoundText = "" Then
				//    gID = 0
				//Else
				//    gID = DataList1.BoundText
				//End If
				switch (gSection) {
					case 0:
						gID = Convert.ToInt32(DataList1.BoundText);
						this.Close();
						break;
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
		private void DataList1_MouseDown(System.Object eventSender, MouseEventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);

			 // ERROR: Not supported in C#: OnErrorStatement

			if (!string.IsNullOrEmpty(DataList1.BoundText)) {
				rs = modRecordSet.getRS(ref "SELECT PayoutGroup_Name FROM PayoutGroup WHERE PayoutGroupID =" + Conversion.Val(DataList1.BoundText));
				if (Strings.UCase(Strings.Mid(rs.Fields("PayoutGroup_Name").Value, 1, 8)) == "HANDHELD") {
					grpDelete = Strings.Trim(rs.Fields("PayoutGroup_Name").Value);
					if (eventArgs.Button == System.Windows.Forms.MouseButtons.Right) {
						//UPGRADE_ISSUE: Form method frmPayoutGroupList.PopupMenu was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						//Call PopupMenu(mnuHand)

						return;
					}
				}
			}

		}

		private void frmPayoutGroupList_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			if (KeyCode == 36) {
				gAll = !gAll;
				doSearch();
				KeyCode = false;
			}
		}

		private void frmPayoutGroupList_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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
		public void loadItem(ref short section)
		{
			gSection = section;
			if (gSection) {
				cmdNew.Text = "&All";
				cmdNew.Visible = false;
			}
			doSearch();
			this.ShowDialog();
		}
		public void loadItem1(ref short section)
		{
			gSection = section;
			if (gSection) {
				cmdNew.Text = "&All";
				cmdNew.Visible = false;
			}
			doSearch();

		}

		private void frmPayoutGroupList_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			gRS.Close();
		}

		public void mnuDel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short intres = 0;

			intres = Interaction.MsgBox("Do you want to delete this 'HANDHELD SCANNER' group", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Question + MsgBoxStyle.YesNo, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
			if (intres == MsgBoxResult.Yes) {
				modRecordSet.cnnDB.Execute("DROP TABLE " + grpDelete);
				modRecordSet.cnnDB.Execute("DELETE * FROM PayoutGroup WHERE PayoutGroup_Name ='" + grpDelete + "'");
				loadItem1(ref 2);
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
			if (string.IsNullOrEmpty(lString)) {
			} else {
				lString = "WHERE (PayoutGroup_Name LIKE '%" + Strings.Replace(lString, " ", "%' AND PayoutGroup_Name LIKE '%") + "%')";

			}
			if (gAll) {
			} else {
				if (string.IsNullOrEmpty(lString)) {
					lString = " WHERE PayoutGroup_Disabled = 0 ";
				} else {
					lString = lString + " AND PayoutGroup_Disabled = 0 ";
				}
			}

			gRS = modRecordSet.getRS(ref "SELECT DISTINCT PayoutGroupID, PayoutGroup_Name FROM PayoutGroup " + lString + " ORDER BY PayoutGroup_Name");

			//Display the list of Titles in the DataCombo
			DataList1.DataSource = gRS;
			DataList1.listField = "PayoutGroup_Name";

			//Bind the DataCombo to the ADO Recordset
			//UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
			DataList1.DataSource = gRS;
			DataList1.boundColumn = "PayoutGroupID";

		}
	}
}
