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
	internal partial class frmChangeDisplay : System.Windows.Forms.Form
	{
		private void loadLanguage()
		{

			//Label1 = No Code       [Enter the desired display name]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblName = No Code      [Enter the desired display name]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblName.Caption = rsLang("LanguageLayoutLnk_Description"): lblName.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdSubmit = No Code    [Accept]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdSubmit.Caption = rsLang("LanguageLayoutLnk_Description"): cmdSubmit.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Command1 = No Code     [Decline]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Command1.Caption = rsLang("LanguageLayoutLnk_Description"): Command1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmChangeDisplay.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdSubmit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (!string.IsNullOrEmpty(txtNumber.Text)) {
				if (Conversion.Val(txtNumber.Text) == 0 | Conversion.Val(txtNumber.Text) > 100) {
					Interaction.MsgBox("Keyboard key display should be between 1 and 100", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					return;

				} else {
					modApplication.InKeyboard = Conversion.Val(txtNumber.Text);
					this.Close();
				}
			} else {
				Interaction.MsgBox("Please enter your display key number", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				return;
			}

		}
		private void Command1_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modApplication.InKeyboard = 200;
			this.Close();
		}

		private void txtNumber_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 13) {
				cmdSubmit_Click(cmdSubmit, new System.EventArgs());
				goto EventExitSub;
			}

			if (Information.IsNumeric(Strings.Chr(KeyAscii)) | KeyAscii == 8) {
			} else {
				KeyAscii = 0;
			}
			EventExitSub:
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
	}
}
