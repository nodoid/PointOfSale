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
	internal partial class frmRegisterAgree : System.Windows.Forms.Form
	{
		private void loadLanguage()
		{

			//frmRegisterAgree = No Code [Registration Wizard]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmRegisterAgree.Caption = rsLang("LanguageLayoutLnk_Description"): frmRegisterAgree.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1 = No Code           [                Changed.......]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label3 = No Code           [We have found that you have.......]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label3.Caption = rsLang("LanguageLayoutLnk_Description"): Label3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Text1 = No Code    --> EULA Text Box
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Text1.Caption = rsLang("LanguageLayoutLnk_Description"): Text1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Command1 = No Code         [I Do not Agree]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Command1.Caption = rsLang("LanguageLayoutLnk_Description"): Command1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Command2 = No Code         [I Agree]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Command2.Caption = rsLang("LanguageLayoutLnk_Description"): Command2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmRegisterAgree.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void Command1_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modApplication.blChkSecu = false;
			this.Close();
		}

		private void Command2_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modApplication.blChkSecu = true;
			this.Close();
		}


		public bool blChkSecure()
		{
			//frmAgree.Visible = True
			ShowDialog();

		}
	}
}
