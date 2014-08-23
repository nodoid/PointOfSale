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
	internal partial class frmIncrementQuantity : System.Windows.Forms.Form
	{
		int gIncrementID;
		int gQuantity;

		private void loadLanguage()
		{

			//frmIncrementQuantity = No Code [Edit Increment Quantity]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmIncrementQuantity.Caption = rsLang("LanguageLayoutLnk_Description"): frmIncrementQuantity.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lbl_1 = No Code               [Increment Name]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2145;
			//Shrink Size|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_9.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_9.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1151;
			//Price|Checked
			if (modRecordSet.rsLang.RecordCount){_LBL_3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_LBL_3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmIncrementQuantity.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void loadData()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			if (gQuantity) {
				rs = modRecordSet.getRS(ref "SELECT IncrementQuantity.*, Increment.Increment_Name FROM Increment INNER JOIN IncrementQuantity ON Increment.IncrementID = IncrementQuantity.IncrementQuantity_IncrementID WHERE (((IncrementQuantity.IncrementQuantity_IncrementID)=" + gIncrementID + ") AND ((IncrementQuantity.IncrementQuantity_Quantity)=" + gQuantity + "));");
				if (rs.RecordCount) {
					lblStockItem.Text = rs.Fields("Increment_Name").Value;
					txtPrice.Text = Convert.ToString(rs.Fields("IncrementQuantity_Price").Value * 100);
					txtPrice_Leave(txtPrice, new System.EventArgs());
					txtQuantity.Text = Convert.ToString(gQuantity);
					txtQuantity_Leave(txtQuantity, new System.EventArgs());
				} else {
					this.Close();
					return;
				}
			} else {
				rs = modRecordSet.getRS(ref "SELECT Increment.* From Increment WHERE (((Increment.IncrementID)=" + gIncrementID + "));");
				if (rs.RecordCount) {
					lblStockItem.Text = rs.Fields("Increment_Name").Value;
					txtPrice.Text = Convert.ToString(0);
					txtPrice_Leave(txtPrice, new System.EventArgs());
					txtQuantity.Text = Convert.ToString(gQuantity);
					txtQuantity_Leave(txtQuantity, new System.EventArgs());
				} else {
					this.Close();
					return;
				}
			}
		}
		public void loadItem(ref int incrementID, ref int quantity)
		{
			gIncrementID = incrementID;
			gQuantity = quantity;
			loadData();

			loadLanguage();
			ShowDialog();
		}
		private void frmIncrementQuantity_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			bool mbAddNewFlag = false;
			bool mbEditFlag = false;
			if (mbEditFlag | mbAddNewFlag)
				goto EventExitSub;

			switch (KeyAscii) {
				case System.Windows.Forms.Keys.Escape:
					KeyAscii = 0;
					cmdClose.Focus();
					System.Windows.Forms.Application.DoEvents();
					cmdClose_Click(cmdClose, new System.EventArgs());
					break;
			}
			EventExitSub:
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void cmdCancel_Click()
		{
			bool mbDataChanged = false;
			int mvBookMark = 0;
			ADODB.Recordset adoPrimaryRS = default(ADODB.Recordset);
			bool mbAddNewFlag = false;
			bool mbEditFlag = false;
			 // ERROR: Not supported in C#: OnErrorStatement

			if (mbAddNewFlag) {
				this.Close();
			} else {
				mbEditFlag = false;
				mbAddNewFlag = false;
				adoPrimaryRS.CancelUpdate();
				if (mvBookMark > 0) {
					adoPrimaryRS.Bookmark = mvBookMark;
				} else {
					adoPrimaryRS.MoveFirst();
				}
				mbDataChanged = false;
			}
		}

		private bool update_Renamed()
		{
			bool functionReturnValue = false;
			 // ERROR: Not supported in C#: OnErrorStatement

			short lBit = 0;
			functionReturnValue = true;
			this.cmdClose.Focus();
			System.Windows.Forms.Application.DoEvents();
			modRecordSet.cnnDB.Execute("DELETE IncrementQuantity.* From IncrementQuantity WHERE (((IncrementQuantity.IncrementQuantity_IncrementID)=" + gIncrementID + ") AND ((IncrementQuantity.IncrementQuantity_Quantity)=" + gQuantity + "));");
			modRecordSet.cnnDB.Execute("DELETE IncrementQuantity.* From IncrementQuantity WHERE (((IncrementQuantity.IncrementQuantity_IncrementID)=" + gIncrementID + ") AND ((IncrementQuantity.IncrementQuantity_Quantity)=" + txtQuantity.Text + "));");
			if (Convert.ToInt16(txtQuantity.Text) > 1) {
				modRecordSet.cnnDB.Execute("INSERT INTO IncrementQuantity ( IncrementQuantity_IncrementID, IncrementQuantity_Quantity, IncrementQuantity_Price ) SELECT " + gIncrementID + ", " + txtQuantity.Text + ", " + txtPrice.Text + ";");
			}
			return functionReturnValue;
			UpdateErr:
			Interaction.MsgBox(Err().Description);
			functionReturnValue = true;
			return functionReturnValue;
		}

		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdClose.Focus();
			System.Windows.Forms.Application.DoEvents();
			if (update_Renamed()) {
				this.Close();
			}
		}
		private void txtPrice_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtPrice);
		}

		private void txtPrice_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			modUtilities.MyKeyPressNegative(ref txtPrice, ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtPrice_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtPrice, ref 2);
		}

		private void txtQuantity_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtQuantity);
		}

		private void txtQuantity_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			modUtilities.MyKeyPressNegative(ref txtQuantity, ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtQuantity_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtQuantity, ref 0);
		}
	}
}
