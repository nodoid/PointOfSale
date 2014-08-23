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
	internal partial class frmPrinter : System.Windows.Forms.Form
	{
		bool gSelect;
		List<RadioButton> optType = new List<RadioButton>();
		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1810;
			//Select a Printer|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1811;
			//NOTE: Please select your printer type before clicking "next"|Checked
			if (modRecordSet.rsLang.RecordCount){Frame1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Frame1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1812;
			//A4 Printer|Checked
			if (modRecordSet.rsLang.RecordCount){_optType_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_optType_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1813;
			//Argox Printer|Checked
			if (modRecordSet.rsLang.RecordCount){_optType_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_optType_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1814;
			//Other barcode printer|
			if (modRecordSet.rsLang.RecordCount){_optType_3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_optType_3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1005;
			//Next|Checked
			if (modRecordSet.rsLang.RecordCount){cmdNext.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdNext.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmPrinter.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public string selectPrinter()
		{
			string functionReturnValue = null;
			string TheSelectedPrinterStr = null;
			Printer Printer = new Printer();
			Printer lPrn = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			Printer lPrnType = null;

			 // ERROR: Not supported in C#: OnErrorStatement

			rs = modRecordSet.getRS(ref "SELECT * FROM PrinterOftenUsed");

			lstPrinter.Items.Clear();
			foreach (Printer lPrn_loopVariable in GlobalModule.Printers) {
				lPrn = lPrn_loopVariable;
				lstPrinter.Items.Add((lPrn.DeviceName));
			}

			if (lstPrinter.Items.Count) {
				if (rs.RecordCount > 0) {
					lstPrinter.SelectedIndex = rs.Fields("PrinterIndex").Value;

					if (rs.Fields("PrinterType").Value == 0) {
						lPrnType = GlobalModule.Printers[lstPrinter.SelectedIndex];
						if (Strings.InStr(Strings.LCase(lPrnType.DeviceName), "label")) {
							optType[2].Checked = true;
						} else if (Printer.Width <= 9000) {
							optType[3].Checked = true;
						} else {
							optType[1].Checked = true;
						}
					} else if (rs.Fields("PrinterType").Value > 0) {
						optType[rs.Fields("PrinterType").Value].Checked = true;
					}
				} else {
					optType[1].Checked = true;
				}

				loadLanguage();
				ShowDialog();
			} else {
				functionReturnValue = "";
				optType[1].Checked = true;
			}

			if (gSelect) {
				functionReturnValue = Printer.DeviceName;
				TheSelectedPrinterStr = Printer.DeviceName;
				modApplication.MyNewPrLabel = functionReturnValue;
			} else {
				functionReturnValue = "";
			}
			selectPrinterErr:

			 // ERROR: Not supported in C#: ResumeStatement

			return functionReturnValue;
		}
		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}
		private void cmdNext_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			Printer Printer = new Printer();
			Printer lPrinter = null;
			bool lPrinterName = false;
			//added by jonas
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rst = default(ADODB.Recordset);
			short prnType = 0;

			prnType = 0;
			if (optType[1].Checked == true)
				prnType = 1;
			if (optType[2].Checked == true)
				prnType = 2;
			if (optType[3].Checked == true)
				prnType = 3;

			rs = new ADODB.Recordset();
			rst = modRecordSet.getRS(ref "SELECT * FROM PrinterOftenUsed");
			if (rst.RecordCount < 1) {
				rs = modRecordSet.getRS(ref "INSERT INTO PrinterOftenUsed(PrinterIndex,LabelIndex,ShelfIndex,PrinterType)VALUES(" + lstPrinter.SelectedIndex + "," + -1 + "," + -1 + "," + prnType + ")");
			} else {
				rs = modRecordSet.getRS(ref "SELECT * FROM PrinterOftenUsed");
				rs = modRecordSet.getRS(ref "UPDATE PrinterOftenUsed SET PrinterIndex=" + lstPrinter.SelectedIndex + ", PrinterType=" + prnType + " WHERE PrinterIndex=" + rs.Fields("PrinterIndex").Value + "");
			}
			//added by jonas
			if (lstPrinter.SelectedIndex != -1) {
				if (optType[1].Checked == false & optType[2].Checked == false & optType[3].Checked == false) {
					Interaction.MsgBox("You are required to select Printer Type in order to proceed next. [A4 will be used as default].", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information, "Printing");
					return;
				} else {
					Printer = GlobalModule.Printers[lstPrinter.SelectedIndex];
					gSelect = true;
				}

			} else {
				Interaction.MsgBox("You are required to select Printer in order to proceed NEXT. Or No printer installed.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information, "Printing");
				return;
			}
			this.Close();
		}
		private void frmPrinter_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void frmPrinter_Load(object sender, System.EventArgs e)
		{
			optType.AddRange(new RadioButton[] {
				_optType_0,
				_optType_1,
				_optType_2,
				_optType_3
			});
		}
	}
}
