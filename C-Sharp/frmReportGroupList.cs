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
	internal partial class frmReportGroupList : System.Windows.Forms.Form
	{
		short gSection;
		string gFilter;
		ADODB.Recordset gRS;
		string gFilterSQL;
		bool gAll;
		int gID;

		private void loadLanguage()
		{

			//frmReportGroupList = No Code       [Select a Report Group]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmReportGroupList.Caption = rsLang("LanguageLayoutLnk_Description"): frmReportGroupList.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

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
			//UPGRADE_ISSUE: Form property frmReportGroupList.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public int getItem()
		{
			cmdNew.Visible = false;

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
			//*
			if (gSection) {
				//Exit form and set indicator to suggest all
				gID = -1;
			} else {
				My.MyProject.Forms.frmNewReportGroup.loadItem(ref 0);
			}
			doSearch();

			//*

			//frmNewReportGroup.loadItem 0
			//doSearch
		}

		private void DataList1_DblClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (cmdNew.Visible) {
				if (!string.IsNullOrEmpty(DataList1.BoundText)) {
					My.MyProject.Forms.frmNewReportGroup.loadItem(ref Convert.ToInt32(DataList1.BoundText));
				}
				doSearch();
			} else {
				if (string.IsNullOrEmpty(DataList1.BoundText)) {
					gID = 0;
				} else {
					gID = Convert.ToInt32(DataList1.BoundText);
				}
				//*
				switch (gSection) {
					case 0:
						this.Close();
						break;
					case 1:
						modApplication.report_StockTake(gID);
						break;
					case 2:
						My.MyProject.Forms.frmStockTake.loadItem(ref gID);
						break;
					case 3:
						modApplication.report_StockQuantityData(ref gID);
						break;
					case 4:
						//New to do StockItem by group
						modApplication.report_StockValueByDept(ref gID);
						break;
				}
			}
			//*

			// Unload Me
			//End If
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
			object mnuHand = null;
			object grpDelete = null;
			//*
			ADODB.Recordset rs = default(ADODB.Recordset);

			 // ERROR: Not supported in C#: OnErrorStatement

			if (!string.IsNullOrEmpty(DataList1.BoundText)) {
				rs = modRecordSet.getRS(ref "SELECT ReportGroup_Name FROM ReportGroup WHERE ReportID =" + Conversion.Val(DataList1.BoundText));
				if (Strings.UCase(Strings.Mid(rs.Fields("ReportGroup_Name").Value, 1, 8)) == "HANDHELD") {
					//UPGRADE_WARNING: Couldn't resolve default property of object grpDelete. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					grpDelete = Strings.Trim(rs.Fields("ReportGroup_Name").Value);
					if (eventArgs.Button == 2) {
						//UPGRADE_ISSUE: Form method frmReportGroupList.PopupMenu was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						//Call PopupMenu(mnuHand)
						return;
					}
				}
			}

			//*
		}

		public void frmReportGroupList_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			//*
			//If KeyCode = 36 Then
			//        gAll = Not gAll
			//        doSearch
			//        KeyCode = False
			//End If
			//*
		}

		private void frmReportGroupList_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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
		private void frmReportGroupList_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			//*
			//    doSearch
			//*
		}

		private void frmReportGroupList_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
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
				//*
				case 36:
					gAll = !gAll;
					doSearch();
					KeyCode = false;
					break;
				//*
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
				lString = "WHERE (ReportGroup_Name LIKE '%" + Strings.Replace(lString, " ", "%' AND ReportGroup_Name LIKE '%") + "%')";
			}

			//*
			if (gAll) {
			} else {
				if (string.IsNullOrEmpty(lString)) {
					lString = " WHERE ReportGroup_Disabled = 0 ";
				} else {
					lString = lString + " AND ReportGroup_Disabled = 0 ";
				}
			}
			//*

			gRS = modRecordSet.getRS(ref "SELECT DISTINCT ReportID, ReportGroup_Name FROM [ReportGroup] " + lString + " ORDER BY ReportGroup_Name");

			//Display the list of Titles in the DataCombo
			DataList1.DataSource = gRS;
			DataList1.listField = "ReportGroup_Name";

			//Bind the DataCombo to the ADO Recordset
			//UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
			DataList1.DataSource = gRS;
			DataList1.boundColumn = "ReportID";

		}

		public void loadItem(ref short section)
		{
			//*
			gSection = section;
			if (gSection) {
				cmdNew.Text = "&All";
				cmdNew.Visible = false;
			}
			doSearch();

			loadLanguage();
			this.ShowDialog();
			//*
		}
		public void loadItem1(ref short section)
		{
			//*
			gSection = section;
			if (gSection) {
				cmdNew.Text = "&All";
				cmdNew.Visible = false;
			}
			doSearch();
			//*
		}
		private void mnuDel_Click()
		{
			string grpDelete = null;
			//*
			short intres = 0;

			intres = Interaction.MsgBox("Do you want to delete this 'HANDHELD SCANNER' group", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Question + MsgBoxStyle.YesNo, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
			if (intres == MsgBoxResult.Yes) {
				modRecordSet.cnnDB.Execute("DROP TABLE " + grpDelete);
				modRecordSet.cnnDB.Execute("DELETE * FROM ReportGroup WHERE ReportGroup_Name ='" + grpDelete + "'");
				loadItem1(ref 2);
			}
			//*
		}
	}
}
