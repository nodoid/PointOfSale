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
using VB = Microsoft.VisualBasic;
namespace _4PosBackOffice.NET
{
	internal partial class frmPOSlist : System.Windows.Forms.Form
	{
		string gFilter;
		ADODB.Recordset gRS;
		string gFilterSQL;
		int gID;
		short gSection;

		private void loaLanguage()
		{

			//frmPOSlist = No Code   [Select a Point Of Sale]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmPOSlist.Caption = rsLang("LanguageLayoutLnk_Description"): frmPOSlist.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1080;
			//Search|Checked
			if (modRecordSet.rsLang.RecordCount){lbl.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1065;
			//New|Checked
			if (modRecordSet.rsLang.RecordCount){cmdNew.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdNew.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

		}

		public int getItem()
		{
			cmdNew.Visible = false;

			loaLanguage();
			this.ShowDialog();
			return gID;

		}
		public int doAction(ref short lSection)
		{
			gSection = lSection;
			this.ShowDialog();
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

		private string getSerialNumber()
		{
			string functionReturnValue = null;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			Scripting.Folder fsoFolder = default(Scripting.Folder);
			Scripting.Drive fsoDrive = default(Scripting.Drive);
			functionReturnValue = "";
			if (fso.FolderExists(modRecordSet.serverPath)) {
				fsoFolder = fso.GetFolder(modRecordSet.serverPath);
				functionReturnValue = Convert.ToString(fsoFolder.Drive.SerialNumber);
			}
			return functionReturnValue;
		}

		private string Encrypt(string secret, string PassWord)
		{
			int l = 0;
			short x = 0;
			string Char_Renamed = null;
			l = Strings.Len(PassWord);
			for (x = 0; x <= Strings.Len(secret); x++) {
				Char_Renamed = Convert.ToString(Strings.Asc(Strings.Mid(PassWord, (x % l) - l * Convert.ToInt16((x % l) == 0), 1)));
				Strings.Mid(secret, x, 1) = Strings.Chr(Strings.Asc(Strings.Mid(secret, x, 1)) ^ Char_Renamed);
			}
			return secret;
		}

		private bool checkSecurity()
		{
			bool functionReturnValue = false;
			string lCode = null;
			string leCode = null;
			string lPassword = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			short x = 0;
			functionReturnValue = false;
			if (modRecordSet.openConnection()) {
				rs = modRecordSet.getRS(ref "SELECT * From Company");
				if (rs.RecordCount) {
					if (Information.IsNumeric(rs.Fields("Company_Code").Value)) {
						modApplication.gSecKey = rs.Fields("Company_Code").Value;
						if (Strings.Len(rs.Fields("Company_Code").Value) == 13) {

							functionReturnValue = true;
							return functionReturnValue;
						}
					}
					lPassword = "pospospospos";
					lCode = getSerialNumber();
					if (lCode == "0" & Strings.LCase(Strings.Left(modRecordSet.serverPath, 3)) != "c:\\" & !string.IsNullOrEmpty(rs.Fields("Company_Code").Value)) {
						functionReturnValue = true;
					} else {
						leCode = Encrypt(lCode, lPassword);
						for (x = 1; x <= Strings.Len(leCode); x++) {
							if (Strings.Asc(Strings.Mid(leCode, x, 1)) < 33) {
								leCode = Strings.Left(leCode, x - 1) + Strings.Chr(33) + Strings.Mid(leCode, x + 1);
							}
						}

						if (rs.Fields("Company_Code").Value == leCode) {
							//If IsNull(rs("Company_TerminateDate")) Then
							functionReturnValue = true;
							return functionReturnValue;
							//Else
							//    If Date > rs("Company_TerminateDate") Then
							//        cnnDB.Execute "UPDATE Company SET Company.Company_Code = '';"
							//        checkSecurity = False
							//   End If
							//End If
						} else {
							//txtCompany.Text = rs("Company_Name")
							//txtCompany.SelStart = 0
							//txtCompany.SelLength = 999
							//show 1
						}

					}
				} else {
					Interaction.MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS");
					System.Environment.Exit(0);
				}
			} else {
				Interaction.MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS");
				System.Environment.Exit(0);
			}
			return functionReturnValue;
		}

		private void cmdNew_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (checkSecurity() == true) {
				if (My.MyProject.Forms.frmPOSCode.setupCode() == true) {
					modApplication.nwPOS = true;
					My.MyProject.Forms.frmPOS.loadItem(ref 0);
					doSearch();
				}
			} else {
				Interaction.MsgBox("New POS units may only be added with registered versions of your 4POS system." + Constants.vbCrLf + "Please contact your 4POS representative or www.4pos.co.za.", MsgBoxStyle.Critical, "Software is not Registered");
			}
		}

		private void DataList1_DblClick(System.Object eventSender, KeyEventArgs eventArgs)
		{
			if (!string.IsNullOrEmpty(DataList1.BoundText)) {
				if (gSection) {
					switch (gSection) {
						case 1:
							modApplication.report_POS(ref Convert.ToInt32(DataList1.BoundText));
							break;
					}
					return;
				} else {
					My.MyProject.Forms.frmPOS.loadItem(ref Convert.ToInt32(DataList1.BoundText));
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
		private void frmPOSlist_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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
		private void frmPOSlist_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			modApplication.nwPOS = false;

			loaLanguage();
			doSearch();


		}

		private void frmPOSlist_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
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
				lString = "WHERE (Pos_Name LIKE '%" + Strings.Replace(lString, " ", "%' AND Pos_Name LIKE '%") + "%')";
			}
			gRS = modRecordSet.getRS(ref "SELECT DISTINCT PosID, Pos_Name FROM Pos " + lString + " ORDER BY PosID");
			//Display the list of Titles in the DataCombo
			DataList1.DataSource = gRS;
			DataList1.listField = "Pos_Name";


			//Bind the DataCombo to the ADO Recordset
			//UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
			DataList1.DataSource = gRS;
			DataList1.boundColumn = "PosID";

		}
	}
}
