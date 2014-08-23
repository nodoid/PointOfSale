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
	internal partial class frmStockGroupList : System.Windows.Forms.Form
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

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1219;
			//Select a Stock Group|Checked
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
			//UPGRADE_ISSUE: Form property frmStockGroupList.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public int getItem()
		{
			cmdNew.Text = "&All";
			cmdNew.Visible = false;
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
			if (gSection) {
				//Exit form and set indicator to suggest all
				gID = -1;
			} else {
				My.MyProject.Forms.frmStockGroup.loadItem(ref 0);
			}
			doSearch();
		}

		private void DataList1_DblClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			object rs = null;

			if (cmdNew.Visible) {
				if (!string.IsNullOrEmpty(DataList1.BoundText)) {
					My.MyProject.Forms.frmStockGroup.loadItem(ref Convert.ToInt32(DataList1.BoundText));
				}
				doSearch();
			} else {
				if (string.IsNullOrEmpty(DataList1.BoundText)) {
					gID = 0;
				} else {
					gID = Convert.ToInt32(DataList1.BoundText);
				}
				switch (gSection) {
					case 0:
						this.Close();
						break;
					case 1:
						modApplication.report_StockTake(gID);
						break;
					case 2:
						My.MyProject.Forms.frmStockTake.loadItem(ref gID);
						if (!string.IsNullOrEmpty(DataList1.BoundText)) {
							rs = modRecordSet.getRS(ref "SELECT StockGroup_Name FROM StockGroup WHERE StockGroupID =" + Conversion.Val(DataList1.BoundText));
							//UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							if (Strings.UCase(Strings.Mid(rs("StockGroup_Name"), 1, 8)) == "HANDHELD") {
								//UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								grpDelete = Strings.Trim(rs("StockGroup_Name"));

								modRecordSet.cnnDB.Execute("DROP TABLE " + grpDelete);
								modRecordSet.cnnDB.Execute("DELETE * FROM StockGroup WHERE StockGroup_Name ='" + grpDelete + "'");
								loadItem1(ref 2);
							}
						}
						break;
					case 3:
						modApplication.report_StockQuantityData(ref gID);
						break;
					case 4:
						//New to do StockItem by group
						modApplication.report_StockValueByDept(ref gID);
						break;
					case 5:
						//New to do the Addition of the StockTake
						My.MyProject.Forms.frmStockTakeAdd.loadItem(ref gID);
						break;
					//delete group and table
					//cnnDB.Execute "DROP TABLE " & DataList1.BoundText
					//cnnDB.Execute "DELETE from StockGroup WHERE StockGroup_Name = '" & DataList1.BoundText & "'"
					//On Error Resume Next
					//If DataList1.BoundText <> "" Then
					//    Set rs = getRS("SELECT StockGroup_Name FROM StockGroup WHERE StockGroupID =" & Val(DataList1.BoundText))
					//    If UCase(Mid$(rs("StockGroup_Name"), 1, 8)) = "HANDHELD" Then
					//        grpDelete = Trim(rs("StockGroup_Name"))
					//
					//        cnnDB.Execute "DROP TABLE " & grpDelete
					//        cnnDB.Execute "DELETE * FROM StockGroup WHERE StockGroup_Name ='" & grpDelete & "'"
					//        loadItem1 2
					//    End If
					//End If
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
				rs = modRecordSet.getRS(ref "SELECT StockGroup_Name FROM StockGroup WHERE StockGroupID =" + Conversion.Val(DataList1.BoundText));
				if (Strings.UCase(Strings.Mid(rs.Fields("StockGroup_Name").Value, 1, 8)) == "HANDHELD") {
					grpDelete = Strings.Trim(rs.Fields("StockGroup_Name").Value);
					if (eventArgs.Button == 2) {
						//UPGRADE_ISSUE: Form method frmStockGroupList.PopupMenu was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						//Call PopupMenu(mnuHand)
						return;
					}
				}
			}

		}

		private void frmStockGroupList_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			if (KeyCode == 36) {
				gAll = !gAll;
				doSearch();
				KeyCode = false;
			}
		}

		private void frmStockGroupList_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

			loadLanguage();
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

		private void frmStockGroupList_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			gRS.Close();
		}

		public void mnuDel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short intres = 0;

			intres = Interaction.MsgBox("Do you want to delete this 'HANDHELD SCANNER' group", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Question + MsgBoxStyle.YesNo, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
			if (intres == MsgBoxResult.Yes) {
				modRecordSet.cnnDB.Execute("DROP TABLE " + grpDelete);
				modRecordSet.cnnDB.Execute("DELETE * FROM StockGroup WHERE StockGroup_Name ='" + grpDelete + "'");
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
			DataList1.listField = "StockGRoup_Name";

			//Bind the DataCombo to the ADO Recordset
			//UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
			DataList1.DataSource = gRS;
			DataList1.boundColumn = "StockGRoupID";

		}
	}
}
