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
	internal partial class frmShrink : System.Windows.Forms.Form
	{
		List<TextBox> txtInteger = new List<TextBox>();
		private void loadLanguage()
		{

			//frmShrink = No code    [Add a Shrink]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmShrink.Caption = rsLang("LanguageLayoutLnk_Description"): frmShrink.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdShrinkAdd = No Code [Add Shrink]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdShrinkAdd.Caption = rsLang("LanguageLayoutLnk_Description"): cmdShrinkAdd.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmShrink.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdShrinkAdd_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short lAmount = 0;
			short x = 0;
			string lString = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			lAmount = 1;
			lString = "1";
			for (x = 0; x <= txtInteger.Count; x++) {
				if (Convert.ToInt16(txtInteger[x].Text) != 0) {
					lString = lString + "x" + txtInteger[x].Text;
					if (Convert.ToInt16(txtInteger[x].Text) <= lAmount) {
						Interaction.MsgBox(Convert.ToInt16(txtInteger[x].Text) + " is less than or equal to " + lAmount + ".", MsgBoxStyle.Exclamation, "Error");
						return;
					} else {
						lAmount = Convert.ToInt16(txtInteger[x].Text);
					}
				}
			}
			//    lString = Mid(lString, 2)
			rs = modRecordSet.getRS(ref "SELECT TOP 100 PERCENT Shrink.Shrink_Name From Shrink WHERE (((Shrink.Shrink_Name)='" + lString + "'));");
			if (rs.RecordCount) {
				Interaction.MsgBox("Shrink size '" + lString + "' already loaded!", MsgBoxStyle.Exclamation, "Error");
			} else {
				modRecordSet.cnnDB.Execute("INSERT INTO shrink ( Shrink_Name, Shrink_SystemID ) SELECT TOP 100 PERCENT '" + lString + "' AS Expr1, 0 AS Expr2;");
				rs = modRecordSet.getRS(ref "SELECT TOP 100 PERCENT Max(Shrink.ShrinkID) AS MaxOfShrinkID FROM Shrink;");
				lAmount = rs.Fields(0).Value;
				modRecordSet.cnnDB.Execute("INSERT INTO ShrinkItem ( ShrinkItem_ShrinkID, ShrinkItem_Quantity, ShrinkItem_Code ) SELECT TOP 100 PERCENT " + lAmount + " AS Expr1, 1  AS Expr2, '' AS Expr3;");
				for (x = 0; x <= txtInteger.Count; x++) {
					if (Convert.ToInt16(txtInteger[x].Text) != 0) {
						modRecordSet.cnnDB.Execute("INSERT INTO ShrinkItem ( ShrinkItem_ShrinkID, ShrinkItem_Quantity, ShrinkItem_Code ) SELECT TOP 100 PERCENT " + lAmount + " AS Expr1, " + txtInteger[x].Text + " AS Expr2, '' AS Expr3;");
					}
				}
				this.Close();
			}
		}

		private void frmShrink_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 27)
				this.Close();
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmShrink_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtInteger.AddRange(new TextBox[] {
				_txtInteger_0,
				_txtInteger_1,
				_txtInteger_2,
				_txtInteger_3,
				_txtInteger_4,
				_txtInteger_5
			});
			TextBox tb = new TextBox();
			foreach (TextBox tb_loopVariable in txtInteger) {
				tb = tb_loopVariable;
				tb.Enter += txtInteger_Enter;
				tb.Leave += txtInteger_Leave;
				tb.KeyPress += txtInteger_KeyPress;
			}
			loadLanguage();
		}

		//Handles txtInteger.Enter
		private void txtInteger_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txt = new TextBox();
			txt = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txt, ref txtInteger);
			modUtilities.MyGotFocusNumeric(ref txtInteger[Index]);
		}

		//Handles txtInteger.KeyPress
		private void txtInteger_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			//Dim Index As Short = txtInteger.GetIndex(eventSender)
			modUtilities.MyKeyPress(ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		//Handles txtInteger.Leave
		private void txtInteger_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txt = new TextBox();
			txt = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txt, ref txtInteger);
			modUtilities.MyLostFocus(ref txtInteger[Index], ref 0);
		}
	}
}
