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
	internal partial class frmKeyboardGet : System.Windows.Forms.Form
	{
		short gKeyCode;
		short gShift;
		private void loadLanguage()
		{

			//frmKeyboardGet = No Code   [Press the Desired Key Combination]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmKeyboardGet.Caption = rsLang("LanguageLayoutLnk_Description"): frmKeyboardGet.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblKey = No Code/Dynamic/NA?

			//cmdAccept = No Code        [Accept]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdAccept.Caption = rsLang("LanguageLayoutLnk_Description"): cmdAccept.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Command1 = No Code         [Decline]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Command1.Caption = rsLang("LanguageLayoutLnk_Description"): Command1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmKeyboardGet.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public void getKeyboardValue(ref string lName, ref short KeyCode, ref short Shift)
		{
			lblName.Text = lName;
			lblKey.Text = My.MyProject.Forms.frmKeyboard.getKeyDescription(ref KeyCode, ref Shift);
			ShowDialog();
			KeyCode = gKeyCode;
			Shift = gShift;
		}

		private void cmdAccept_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();

		}

		private void Command1_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
			gKeyCode = 0;
			gShift = 0;
		}

		private void Text1_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			switch (KeyCode) {
				case 16:
				case 17:
				case 18:
					break;
				default:
					lblKey.Text = My.MyProject.Forms.frmKeyboard.getKeyDescription(ref KeyCode, ref Shift);
					gKeyCode = KeyCode;
					gShift = Shift;
					break;
			}
			KeyCode = 0;
		}

		private void Text1_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			KeyAscii = 0;
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
	}
}
