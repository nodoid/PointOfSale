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
	internal partial class frmcalendar : System.Windows.Forms.Form
	{
		private void loadLanguage()
		{

			//frmcalendar = No Code  [Calendar]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmcalendar.Caption = rsLang("LanguageLayoutLnk_Description"): frmcalendar.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmcalendar.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}


		private void Calendar1_DblClick(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (modApplication.HForPriceC == 1) {
				modApplication.HCalDate = this.Calendar1.SelectionRange.Start.Year + "/" + this.Calendar1.SelectionRange.Start.Month + "/" + this.Calendar1.SelectionRange.Start.Day;
				My.MyProject.Forms.frmpricechange.txtstartdate.Text = modApplication.HCalDate;
				modApplication.HForPriceC = 0;
				this.Close();
			} else if (modApplication.HForPriceC == 2) {
				modApplication.HCalDate = this.Calendar1.SelectionRange.Start.Year + "/" + this.Calendar1.SelectionRange.Start.Month + "/" + this.Calendar1.SelectionRange.Start.Day;
				My.MyProject.Forms.frmpricechange.txtenddate.Text = modApplication.HCalDate;
				modApplication.HForPriceC = 0;
				this.Close();
			}
		}

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();

		}

		private void cmdOK_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (modApplication.HForPriceC == 1) {

				modApplication.HCalDate = this.Calendar1.SelectionRange.Start.Year + "/" + this.Calendar1.SelectionRange.Start.Month + "/" + this.Calendar1.SelectionRange.Start.Day;
				My.MyProject.Forms.frmpricechange.txtstartdate.Text = modApplication.HCalDate;
				modApplication.HForPriceC = 0;
				this.Close();
			} else if (modApplication.HForPriceC == 2) {
				modApplication.HCalDate = this.Calendar1.SelectionRange.Start.Year + "/" + this.Calendar1.SelectionRange.Start.Month + "/" + this.Calendar1.SelectionRange.Start.Day;
				My.MyProject.Forms.frmpricechange.txtenddate.Text = modApplication.HCalDate;
				modApplication.HForPriceC = 0;
				this.Close();
			}
		}

		private void frmcalendar_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 13) {
				cmdOK_Click(cmdok, new System.EventArgs());
			} else if (KeyAscii == 27) {
				cmdCancel_Click(cmdcancel, new System.EventArgs());
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmcalendar_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Calendar1.SetDate(DateAndTime.Today);
		}
	}
}
