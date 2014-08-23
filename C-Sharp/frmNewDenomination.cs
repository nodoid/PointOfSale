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
	internal partial class frmNewDenomination : System.Windows.Forms.Form
	{
		private void loadLanguage()
		{

			//frmNewDenomination = No Code   [New Denomination]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmNewDenomination.Caption = rsLang("LanguageLayoutLnk_Description"): frmDenomination.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|
			if (modRecordSet.rsLang.RecordCount){Command2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Command2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|
			if (modRecordSet.rsLang.RecordCount){Command1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Command1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//Label1 = No Code               [Name]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label4 = No Code               [Unit/Amount]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label4.Caption = rsLang("LanguageLayoutLnk_Description"): Label4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label2 = No Code               [Pack]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label2.Caption = rsLang("LanguageLayoutLnk_Description"): Label2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1248;
			//Type|Checked
			if (modRecordSet.rsLang.RecordCount){Label3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//optCoin(0) = No Code           [Coin]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then optCoin(0).Caption = rsLang("LanguageLayoutLnk_Description"): optCoin(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//optCoin(1) = No Code           [Note]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then optCoin(1).Caption = rsLang("LanguageLayoutLnk_Description"): optCoin(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Check1 = No Code               [Disable Denominations]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Check1.Caption = rsLang("LanguageLayoutLnk_Description"): Check1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmNewDenomination.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void Command1_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			short dValue = 0;
			int dValue_1 = 0;

			 // ERROR: Not supported in C#: OnErrorStatement


			if (string.IsNullOrEmpty(txtName.Text)) {
				Interaction.MsgBox("Denomination decription is a required field", MsgBoxStyle.Information + MsgBoxStyle.OkOnly + MsgBoxStyle.ApplicationModal, "New Denomination");
				return;
			}

			if (string.IsNullOrEmpty(txtUnit.Text) | Conversion.Val(txtUnit.Text) == 0) {
				Interaction.MsgBox("Denomination Unit Value is a required field", MsgBoxStyle.Information + MsgBoxStyle.OkOnly + MsgBoxStyle.ApplicationModal, "New Denomination");
				return;
			}

			if (string.IsNullOrEmpty(txtPack.Text) | Conversion.Val(txtPack.Text) == 0) {
				Interaction.MsgBox("Denomination Pack Value is a required field", MsgBoxStyle.Information + MsgBoxStyle.OkOnly + MsgBoxStyle.ApplicationModal, "New Denomination");
				return;
			}

			if (_optCoin_0.Checked == false & _optCoin_1.Checked == false) {
				Interaction.MsgBox("Please specify if Denomination is a Coin/Notes", MsgBoxStyle.Information + MsgBoxStyle.OkOnly + MsgBoxStyle.ApplicationModal, "New Denomination");
				return;
			}

			if (_optCoin_0.Checked == true)
				dValue = 0;
			else
				dValue = 1;

			dValue_1 = Convert.ToInt32(Convert.ToDouble(Strings.FormatNumber(txtUnit.Text)) * 100);

			rs = modRecordSet.getRS(ref "SELECT * FROM [Float] Where Float.Float_Unit = " + dValue_1 + ";");

			if (rs.RecordCount) {
				Interaction.MsgBox("Denomination with this float Unit/Amount exist already!!!", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "New Denomination");
			} else {
				if (Convert.ToInt32(txtPack.Text) == 0) {
					Interaction.MsgBox("Denomination float pack must be greater or equal to 1", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "New Denomination");
					return;
				} else {
					modRecordSet.cnnDB.Execute("INSERT INTO [Float] (Float_Unit,Float_Name,Float_Pack,Float_Type) VALUES (" + dValue_1 + ",'" + Strings.Replace(txtName.Text, "'", "''") + "'," + Convert.ToInt32(txtPack.Text) + "," + dValue + ")");
				}

			}
			this.Close();
		}
		public void loadItem()
		{
			loadLanguage();
			ShowDialog();
		}
		private void Command2_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}
		public void LostFocus1(ref Label lControl, ref bool lDecimal)
		{
			if (string.IsNullOrEmpty(lControl.Text))
				return;
			if (lDecimal) {
				lControl.Text = lControl.Text / 100;
			}
			lControl.Text = Strings.FormatNumber(lControl.Text);
		}

		private void frmNewDenomination_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			loadLanguage();
		}

		private void txtPack_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtPack);
		}
		private void txtPack_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			modUtilities.MyKeyPress(ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtPack_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtPack, ref 2);
		}
		private void txtUnit_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtUnit);
		}
		private void txtUnit_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			modUtilities.MyKeyPress(ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
		private void txtUnit_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtUnit, ref 2);
		}
	}
}
