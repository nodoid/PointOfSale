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
using Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6;
namespace _4PosBackOffice.NET
{
	internal partial class frmPrintLocation : System.Windows.Forms.Form
	{
		int gID;

		private void loadLanguage()
		{

			//Note: Form Caption has a spelling mistake!
			//frmPrintLocation = No Code     [Select a Printer for the Print Location]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmPrintLocation.Caption = rsLang("LanguageLayoutLnk_Description"): frmPrintLocation.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1 = No Code               [Print Location Name]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//cmdNext = No Code              [Save]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdNext.Caption = rsLang("LanguageLayoutLnk_Description"): cmdNext.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmPrintLocation.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public void loadItem(ref int lID)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			Printer lPrn = null;
			gID = lID;
			if (gID) {
				rs = modRecordSet.getRS(ref "SELECT * FROM PrintLocation WHERE PrintLocationID=" + lID);
				this.txtName.Text = rs.Fields("PrintLocation_Name").Value;
			}
			rs = modRecordSet.getRS(ref "SELECT PrintLocationPrinterLnk.* From PrintLocationPrinterLnk WHERE (((PrintLocationPrinterLnk.PrintLocationPrinterLnk_PrintLocationID)=" + gID + "));");
			lstPrinter.Items.Clear();
			int m = 0;
			foreach (Printer lPrn_loopVariable in GlobalModule.Printers) {
				lPrn = lPrn_loopVariable;
				if (Strings.InStr(1, lPrn.DeviceName, " ")) {
				} else {
					rs.filter = "PrintLocationPrinterLnk_PrinterName = '" + lPrn.DeviceName + "'";
					m = lstPrinter.Items.Add((lPrn.DeviceName));
					if (rs.RecordCount) {
						//UPGRADE_ISSUE: ListBox property lstPrinter.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
						lstPrinter.SetItemChecked(m, true);
					}
				}
			}

			loadLanguage();
			ShowDialog();
		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdNext_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			Printer lPrinter = null;
			bool lPrinterName = false;
			ADODB.Recordset rs = default(ADODB.Recordset);
			short x = 0;
			//    On Local Error Resume Next
			if (gID) {
				modRecordSet.cnnDB.Execute("UPDATE PrintLocation SET PrintLocation.PrintLocation_Name = '" + Strings.Replace(txtName.Text, "'", "''") + "' WHERE (((PrintLocation.PrintLocationID)=" + gID + "));");
			} else {
				modRecordSet.cnnDB.Execute("INSERT INTO PrintLocation ( PrintLocation_Name, PrintLocation_Disabled ) SELECT '" + Strings.Replace(txtName.Text, "'", "''") + "', False");
				rs = modRecordSet.getRS(ref "SELECT Max(PrintLocation.PrintLocationID) AS MaxOfPrintLocationID FROM PrintLocation;");
				gID = rs.Fields(0).Value;
			}
			modRecordSet.cnnDB.Execute("DELETE PrintLocationPrinterLnk.* From PrintLocationPrinterLnk WHERE (((PrintLocationPrinterLnk.PrintLocationPrinterLnk_PrintLocationID)=" + gID + "));");
			for (x = 0; x <= this.lstPrinter.Items.Count - 1; x++) {
				if (lstPrinter.GetItemChecked(x)) {
					modRecordSet.cnnDB.Execute("INSERT INTO PrintLocationPrinterLnk ( PrintLocationPrinterLnk_PrintLocationID, PrintLocationPrinterLnk_PrinterName ) SELECT " + gID + ", '" + Strings.Replace(GID.GetItemString(ref lstPrinter, ref x), "'", "''") + "';");
				}
			}




			this.Close();
		}

		private void frmPrintLocation_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void lstPrinter_DoubleClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdNext_Click(cmdNext, new System.EventArgs());
		}

		private void lstPrinter_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 13) {
				cmdNext_Click(cmdNext, new System.EventArgs());
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtName_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocus(ref txtName);
		}
	}
}
