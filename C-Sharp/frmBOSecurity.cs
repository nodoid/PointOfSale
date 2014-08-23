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
using Microsoft.VisualBasic.PowerPacks;
namespace _4PosBackOffice.NET
{
	internal partial class frmBOSecurity : System.Windows.Forms.Form
	{
		bool loading;
		short gID;
		short gLastIndex;

		private void loadLanguage()
		{

			//frmBOSecurity = No Code    [Employee Back Office Permissions]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmBOSecurity.Caption = rsLang("LanguageLayoutLnk_Description"): frmBOSecurity.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1010;
			//General|
			if (modRecordSet.rsLang.RecordCount){lbl.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//chkSelectAll = No Code     [Select All]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkSelectAll.Caption = rsLang("LanguageLayoutLnk_Description"): chkSelectAll.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmBOSecurity.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

//UPGRADE_WARNING: Event chkSelectAll.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void chkSelectAll_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			short j = 0;
			short rstIn = 0;

			rstIn = lstSecurity.Items.Count - 1;

			if (chkSelectAll.CheckState == 1) {
				for (j = 0; j <= rstIn; j++) {
					lstSecurity.SetItemChecked(j, true);
				}

			} else {
				for (j = 0; j <= rstIn; j++) {
					lstSecurity.SetItemChecked(j, false);
				}
			}

		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		public void loadItem(ref int id)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			int lValue = 0;
			bool bSecChk = false;
			string tmp = null;
			loading = true;
			gID = id;
			bSecChk = false;

			ADODB.Recordset rsRpt = default(ADODB.Recordset);
			rsRpt = modRecordSet.getRS(ref "SELECT Company_SecurityPerm From Company");
			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			if (Information.IsDBNull(rsRpt.Fields("Company_SecurityPerm").Value)) {
			} else if (rsRpt.Fields("Company_SecurityPerm").Value == 0) {
			} else {
				bSecChk = true;
			}

			rs = modRecordSet.getRS(ref "SELECT DISPLAY_Person.PersonID, DISPLAY_Person.Person_Name, IIf([Person_SecurityBit] Is Null,0,[Person_SecurityBit]) AS [bit] From DISPLAY_Person WHERE (((DISPLAY_Person.PersonID)=" + id + "));");
			lValue = rs.Fields("bit").Value;

			lbl.Text = "&1. Permissions for '" + rs.Fields("Person_Name").Value + "'";
			rs = modRecordSet.getRS(ref "SELECT SecurityBit.SecurityBit_Value, SecurityBit.SecurityBit_Name From SecurityBit Where (((SecurityBit.SecurityBit_Type) = 1)) ORDER BY SecurityBit.SecurityBitID;");
			int m = 0;
			while (!(rs.EOF)) {
				if (bSecChk) {
					if (rs.Fields("SecurityBit_Value").Value & My.MyProject.Forms.frmMenu.gBit) {
						tmp = rs.Fields("SecurityBit_Name").Value + ", " + rs.Fields("SecurityBit_Value").Value;
						m = lstSecurity.Items.Add(tmp);
						if (rs.Fields("SecurityBit_Value").Value & lValue) {
							lstSecurity.SetItemChecked(m, true);
						} else {
							lstSecurity.SetItemChecked(m, false);
						}
					}
				} else {
					tmp = rs.Fields("SecurityBit_Name").Value + ", " + rs.Fields("SecurityBit_Value").Value;
					m = lstSecurity.Items.Add(tmp);
					if (rs.Fields("SecurityBit_Value").Value & lValue) {
						lstSecurity.SetItemChecked(m, true);
					} else {
						lstSecurity.SetItemChecked(m, false);
					}

				}
				rs.MoveNext();
			}


			loading = false;

			loadLanguage();
			this.ShowDialog();
		}

		private void frmBOSecurity_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case System.Windows.Forms.Keys.Escape:
					KeyAscii = 0;
					System.Windows.Forms.Application.DoEvents();
					cmdExit_Click(cmdExit, new System.EventArgs());
					break;
			}

			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmBOSecurity_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			short x = 0;
			int bit = 0;
			for (x = 0; x <= this.lstSecurity.Items.Count - 1; x++) {
				if (lstSecurity.GetItemChecked(x)) {
					bit = bit + Convert.ToInt16(x);
				}
			}
			modRecordSet.cnnDB.Execute("UPDATE Person SET Person.Person_SecurityBit = " + bit + " WHERE (((Person.PersonID)=" + gID + "));");
		}
	}
}
