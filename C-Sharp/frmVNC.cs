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
	internal partial class frmVNC : System.Windows.Forms.Form
	{
		List<RadioButton> optType = new List<RadioButton>();
		private void loadLanguage()
		{

			//frmVNC = No Code           [View another computer]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmVNC.Caption = rsLang("LanguageLayoutLnk_Description"): frmVNC.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1(0) = No Code        [There are two modes that can be activated a description of each follows:]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(0).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//optType(0) = No Code       [&View mode]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then optType(0).Caption = rsLang("LanguageLayoutLnk_Description"): optType(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1(2) = No Code        [You can only view the activity on the computer. No intervention is permitted.]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(2).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(2).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//optType(1) = No Code       [&Edit mode]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then optType(1).Caption = rsLang("LanguageLayoutLnk_Description"): optType(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1(3) = No Code        [You can control the mouse and keyboard activity from your own computer. ]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(3).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(3).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmVNC.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void loadVNC(ref int id)
		{
			string lPath = null;
			lPath = _4PosBackOffice.NET.My.MyProject.Application.Info.DirectoryPath;
			lPath = "c:\\4POS";
			//UPGRADE_WARNING: Lower bound of collection Me.lvPOS.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			shellConnection(ref this.lvPOS.FocusedItem.SubItems[2].Text);
			if (Strings.Right(lPath, 1) != "\\")
				lPath = lPath + "\\";
			if (optType[0].Checked) {
				Interaction.Shell(lPath + "vncviewer.exe -config " + lPath + id + "_v.vnc");
			} else {
				Interaction.Shell(lPath + "vncviewer.exe -config " + lPath + id + "_e.vnc");
			}
		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void frmVNC_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void frmVNC_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			optType.AddRange(new RadioButton[] {
				_optType_0,
				_optType_1
			});
			RadioButton rb = new RadioButton();
			_optType_0.CheckedChanged += optType_CheckedChanged;
			_optType_1.CheckedChanged += optType_CheckedChanged;
			ADODB.Recordset rs = default(ADODB.Recordset);
			short x = 0;
			System.Windows.Forms.ListViewItem lItem = null;
			lvPOS.Items.Clear();
			rs = modRecordSet.getRS(ref "SELECT * FROM POS ORDER BY POSID");
			while (!(rs.EOF)) {
				//UPGRADE_WARNING: Lower bound of collection lvPOS.ListItems.ImageList has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				lItem = lvPOS.Items.Add("POS" + rs.Fields("POSID").Value, rs.Fields("POS_Name").Value + " (" + rs.Fields("POS_IPAddress").Value + ")", 1);
				//UPGRADE_WARNING: Lower bound of collection lItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				if (lItem.SubItems.Count > 1) {
					lItem.SubItems[1].Text = rs.Fields("POS_Name").Value;
				} else {
					lItem.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("POS_Name").Value));
				}
				//UPGRADE_WARNING: Lower bound of collection lItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				if (lItem.SubItems.Count > 2) {
					lItem.SubItems[2].Text = rs.Fields("POS_IPAddress").Value;
				} else {
					lItem.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("POS_IPAddress").Value));
				}
				//UPGRADE_WARNING: Lower bound of collection lItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				if (lItem.SubItems.Count > 3) {
					lItem.SubItems[3].Text = rs.Fields("POS_Disabled").Value;
				} else {
					lItem.SubItems.Insert(3, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("POS_Disabled").Value));
				}
				rs.moveNext();
			}

			loadLanguage();
		}

		private void lvPOS_DoubleClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			string lPath = null;
			string[] lArray = null;
			if (lvPOS.FocusedItem == null) {
			} else {
				lPath = this.lvPOS.FocusedItem.SubItems[2].Text;
				if (Strings.LCase(this.lvPOS.FocusedItem.SubItems[2].Text) == "localhost") {
					if (Strings.LCase(Strings.Left(modRecordSet.serverPath, 3)) == "c:\\") {
						return;
					} else {
						lArray = Strings.Split(modRecordSet.serverPath, "\\");
						lPath = lArray[2];
					}
				}
				shellConnection(ref lPath);


			}
		}

		private void lvPOS_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 13) {
				lvPOS_DoubleClick(lvPOS, new System.EventArgs());
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

//UPGRADE_WARNING: Event optType.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void optType_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.Checked) {
				//Dim Index As Short = optType.GetIndex(eventSender)
				this.lvPOS.Focus();
			}
		}

		private void shellConnection(ref string host)
		{
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			Scripting.TextStream lStream = default(Scripting.TextStream);
			if (fso.FileExists("C:\\4POS\\connect.vnc"))
				fso.DeleteFile("C:\\4POS\\connect.vnc");
			lStream = fso.OpenTextFile("C:\\4POS\\connect.vnc", Scripting.IOMode.ForWriting, true);
			lStream.WriteLine("[connection]");
			lStream.WriteLine("host=" + host);
			lStream.WriteLine("Port=5900");
			lStream.WriteLine("password=vnc");
			lStream.WriteLine("[Options]");
			lStream.WriteLine("use_encoding_0 = 1");
			lStream.WriteLine("use_encoding_1 = 1");
			lStream.WriteLine("use_encoding_2 = 1");
			lStream.WriteLine("use_encoding_3 = 0");
			lStream.WriteLine("use_encoding_4 = 1");
			lStream.WriteLine("use_encoding_5 = 1");
			lStream.WriteLine("preferred_encoding = 16");
			lStream.WriteLine("restricted = 0");
			if (this.optType[1].Checked) {
				lStream.WriteLine("viewonly = 0");
			} else {
				lStream.WriteLine("viewonly = 1");
			}
			lStream.WriteLine("fullscreen = 0");
			lStream.WriteLine("8 Bit = 0");
			lStream.WriteLine("shared=0");
			lStream.WriteLine("swapmouse = 0");
			lStream.WriteLine("belldeiconify = 0");
			lStream.WriteLine("emulate3 = 1");
			lStream.WriteLine("emulate3timeout = 100");
			lStream.WriteLine("emulate3fuzz = 4");
			lStream.WriteLine("disableclipboard = 1");
			lStream.WriteLine("localcursor = 1");
			lStream.WriteLine("scale_num = 1");
			lStream.WriteLine("scale_den = 1");
			lStream.WriteLine("use_encoding_6 = 0");
			lStream.WriteLine("use_encoding_7 = 0");
			lStream.WriteLine("use_encoding_8 = 0");
			lStream.WriteLine("use_encoding_9 = 0");
			lStream.WriteLine("use_encoding_10 = 0");
			lStream.WriteLine("use_encoding_11 = 0");
			lStream.WriteLine("use_encoding_12 = 0");
			lStream.WriteLine("use_encoding_13 = 0");
			lStream.WriteLine("use_encoding_14 = 0");
			lStream.WriteLine("use_encoding_15 = 0");
			lStream.WriteLine("use_encoding_16 = 1");
			lStream.WriteLine("autoDetect = 1");
			lStream.Close();

			System.Windows.Forms.Application.DoEvents();
			System.Windows.Forms.Application.DoEvents();
			Interaction.Shell("C:\\4POS\\vncviewer.exe -config C:\\4POS\\connect.vnc", AppWinStyle.NormalFocus);

		}
	}
}
