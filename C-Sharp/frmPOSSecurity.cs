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
	internal partial class frmPOSSecurity : System.Windows.Forms.Form
	{
		bool loading;
		short gID;
		short gLastIndex;

		private void loadLanguage()
		{

			//frmPOSSecurity = No Code   [Employee Point Of Sales Permissions]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmPOSSecurity.Caption = rsLang("LanguageLayoutLnk_Description"): frmPOSSecurity.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//Label1(2) = No Code        [Name]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(2).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(2).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1(1) = No Code        [Permissions]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(1).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1(0) = No Code        [Sale Channel Access]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(0).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkPosSecurity = No Code   [Select All]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkPosSecurity.Caption = rsLang("LanguageLayoutLnk_Description"): chkPosSecurity.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmPOSSecurity.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

//UPGRADE_WARNING: Event chkPosSecurity.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void chkPosSecurity_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			short j = 0;
			short rstIn = 0;
			short rstIn1 = 0;


			rstIn = lstSecurity.Items.Count - 1;
			rstIn1 = lstChannel.Items.Count - 1;

			if (chkPosSecurity.CheckState == 1) {

				for (j = 0; j <= rstIn; j++) {
					lstSecurity.SetItemChecked(j, true);
				}

				for (j = 0; j <= rstIn1; j++) {
					lstChannel.SetItemChecked(j, true);
				}

			} else {
				for (j = 0; j <= rstIn; j++) {
					lstSecurity.SetItemChecked(j, false);
				}

				for (j = 0; j <= rstIn1; j++) {
					lstChannel.SetItemChecked(j, false);
				}

			}

		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		public void loadItem(ref int id)
		{
			int x = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			int lValue = 0;

			loading = true;
			gID = id;
			rs = modRecordSet.getRS(ref "SELECT DISPLAY_Person.PersonID, DISPLAY_Person.Person_Name, IIf([Person_SecurityBitPOS] Is Null,0,[Person_SecurityBitPOS]) AS [bit] From DISPLAY_Person WHERE (((DISPLAY_Person.PersonID)=" + id + "));");

			lValue = rs.Fields("bit").Value;

			_Label1_2.Text = "Point Of Sale Access Rights for '" + rs.Fields("Person_Name").Value + "'";
			rs = modRecordSet.getRS(ref "SELECT SecurityBit.SecurityBit_Value, SecurityBit.SecurityBit_Name From SecurityBit Where (((SecurityBit.SecurityBit_Type) = 0)) ORDER BY SecurityBit.SecurityBitID;");

			int m = 0;
			while (!(rs.EOF)) {

				m = lstSecurity.Items.Add(new LBI(rs.Fields("SecurityBit_Name").Value, rs.Fields("SecurityBit_Value").Value));

				if (rs.Fields("SecurityBit_Value").Value & lValue) {
					lstSecurity.SetItemChecked(m, true);
				} else {
					lstSecurity.SetItemChecked(m, false);
				}

				rs.moveNext();

			}

			rs = modRecordSet.getRS(ref "SELECT Channel.ChannelID, Channel.Channel_Name FROM Channel ORDER BY Channel.ChannelID;");
			while (!(rs.EOF)) {
				lstChannel.Items.Add(new LBI(rs.Fields("Channel_Name").Value, rs.Fields("ChannelID").Value));
				rs.moveNext();
			}

			rs = modRecordSet.getRS(ref "SELECT PersonChannelLnk.PersonChannelLnk_ChannelID From PersonChannelLnk WHERE (((PersonChannelLnk.PersonChannelLnk_PersonID)=" + gID + "));");
			while (!(rs.EOF)) {
				for (x = 0; x <= lstChannel.Items.Count - 1; x++) {
					if (GID.GetItemData(ref lstChannel, ref x) == rs.Fields("PersonChannelLnk_ChannelID").Value) {
						lstChannel.SetItemChecked(x, true);
					}
				}
				rs.moveNext();
			}

			loading = false;

			loadLanguage();
			this.ShowDialog();
		}
		private void frmPOSSecurity_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void frmPOSSecurity_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			short x = 0;
			int bit = 0;
			for (x = 0; x <= this.lstSecurity.Items.Count - 1; x++) {
				if (lstSecurity.GetItemChecked(x)) {
					bit = bit + GID.GetItemData(ref lstSecurity, ref x);
				}
			}
			modRecordSet.cnnDB.Execute("UPDATE Person SET Person.Person_SecurityBitPOS = " + bit + " WHERE (((Person.PersonID)=" + gID + "));");
		}

//UPGRADE_WARNING: ListBox event lstChannel.ItemCheck has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		private void lstChannel_ItemCheck(System.Object eventSender, System.Windows.Forms.ItemCheckEventArgs eventArgs)
		{
			if (loading)
				return;
			modRecordSet.cnnDB.Execute("DELETE FROM PersonChannelLnk WHERE (PersonChannelLnk_PersonID = " + gID + ") AND (PersonChannelLnk_ChannelID = " + Convert.ToInt32(lstChannel.SelectedIndex) + ")");

			if (lstChannel.GetItemChecked(eventArgs.Index)) {
				modRecordSet.cnnDB.Execute("INSERT INTO PersonChannelLnk (PersonChannelLnk_PersonID, PersonChannelLnk_ChannelID) VALUES (" + gID + ", " + Convert.ToInt32(lstChannel.SelectedIndex) + ")");
			} else {
			}

		}
	}
}
