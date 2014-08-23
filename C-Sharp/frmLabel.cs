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
	internal partial class frmLabel : System.Windows.Forms.Form
	{
		private void loadLanguage()
		{

			//frmLabel = No Code [Select Label Format]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmLabel.Caption = rsLang("LanguageLayoutLnk_Description"): frmLabel.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1005;
			//Next|Checked
			if (modRecordSet.rsLang.RecordCount){cmdNext.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdNext.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmLabel.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdNext_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//    Dim lNode As IXMLDOMNode
			ADODB.Recordset rs = default(ADODB.Recordset);
			if (lstLayout.SelectedIndex == -1) {
			} else {
				rs = modRecordSet.getRS(ref "SELECT Label.* From Label WHERE (((Label.LabelID)=" + Convert.ToInt32(lstLayout.SelectedIndex) + "));");
				modBarcode.gLabelName = rs.Fields("Label_Name").Value;
				modBarcode.gLabelColumns = rs.Fields("Label_Columns").Value;
				modBarcode.gLabelLeft = rs.Fields("Label_Left").Value;
				modBarcode.gLabelHeight = rs.Fields("Label_Height").Value;
				modBarcode.gLabelWidth = rs.Fields("Label_Width").Value;
			}
			this.Close();
		}

		private void frmLabel_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 27) {
				cmdExit_Click(cmdExit, new System.EventArgs());
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmLabel_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			//    Dim lNode As IXMLDOMNode
			//    Dim lNodeList As IXMLDOMNodeList
			ADODB.Recordset rs = default(ADODB.Recordset);

			this.lstLayout.Items.Clear();
			if (isBarcodePrinter() == Convert.ToBoolean("1")) {
				rs = modRecordSet.getRS(ref "SELECT Label.LabelID, Label.Label_Name From Label Where (((Label.Label_Type) <> 0)) ORDER BY Label.Label_Name;");
			} else {
				rs = modRecordSet.getRS(ref "SELECT Label.LabelID, Label.Label_Name From Label Where (((Label.Label_Type) = 0)) ORDER BY Label.Label_Name;");
			}
			while (!(rs.EOF)) {
				lstLayout.Items.Add(new LBI(rs.Fields("Label_Name").Value, rs.Fields("LabelID").Value));

				rs.moveNext();
			}
			if (lstLayout.Items.Count)
				lstLayout.SelectedIndex = 0;
			//    lstDeposit_Click

			loadLanguage();
		}

		private void lstLayout_DoubleClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdNext_Click(cmdNext, new System.EventArgs());
		}

		private void lstLayout_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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
	}
}
