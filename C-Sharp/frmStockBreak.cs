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
	internal partial class frmStockBreak : System.Windows.Forms.Form
	{
		int gParent;
		int gChild;

		private void loadLanguage()
		{

			//frmStockBreak = No Code    [Maintain Stock Item Conversion]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmStockBreak.Caption = rsLang("LanguageLayoutLnk_Description"): frmStockBreak.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1085;
			//Print|
			if (modRecordSet.rsLang.RecordCount){cmdPrint.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPrint.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lbl_0 = No Code           [Convert one unit of]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_1 = No Code           [to]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_2 = No Code           [units of]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkDisabled = No Code      [Disable this Stock Item Conversion]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkDisabled.Caption = rsLang("LanguageLayoutLnk_Description"): chkDisabled.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmStockBreak.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int lChild = 0;
			int lParent = 0;
			if (lParent == 0) {
				this.Close();
			} else {
				loadItem(ref lParent + "_" + lChild);
			}
		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (Convert.ToInt16(this.txtQuantity.Text) < 2) {
				Interaction.MsgBox("Quantity must be greater than one(1)!", MsgBoxStyle.Exclamation, "ERROR");
				txtQuantity.Focus();
				return;
			}
			if (string.IsNullOrEmpty(this.lblParent.Tag)) {
				Interaction.MsgBox("A Parent Stock item is required!", MsgBoxStyle.Exclamation, "ERROR");
				cmdParent.Focus();
				return;
			}
			if (string.IsNullOrEmpty(this.lblChild.Tag)) {
				Interaction.MsgBox("A Child Stock item is required!", MsgBoxStyle.Exclamation, "ERROR");
				cmdChild.Focus();
				return;
			}
			if (gParent == 0) {
			} else {
				modRecordSet.cnnDB.Execute("DELETE StockBreak.* From StockBreak WHERE (((StockBreak.StockBreak_ParentID)=" + gParent + ") AND ((StockBreak.StockBreak_ChildID)=" + gChild + "));");
			}
			modRecordSet.cnnDB.Execute("DELETE StockBreak.* From StockBreak WHERE (((StockBreak.StockBreak_ParentID)=" + lblParent.Tag + ") AND ((StockBreak.StockBreak_ChildID)=" + lblChild.Tag + "));");
			modRecordSet.cnnDB.Execute("INSERT INTO StockBreak ( StockBreak_ParentID, StockBreak_ChildID, StockBreak_Quantity, StockBreak_Disabled ) SELECT " + lblParent.Tag + " AS lParent, " + lblChild.Tag + " AS lChild, " + Convert.ToInt16(this.txtQuantity.Text) + " AS lQty, " + Convert.ToInt16(this.chkDisabled.CheckState) + " AS lDisabled;");

			this.Close();
		}


		private void cmdParent_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int lID = 0;
			lID = My.MyProject.Forms.frmStockList.getItem();
			if (lID != 0) {
				this.lblParent.Tag = lID;
				this.lblParent.Text = getStockName(ref Convert.ToInt32(this.lblParent.Tag));
			}
		}
		private void cmdChild_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int lID = 0;
			lID = My.MyProject.Forms.frmStockList.getItem();
			if (lID != 0) {
				this.lblChild.Tag = lID;
				this.lblChild.Text = getStockName(ref Convert.ToInt32(this.lblChild.Tag));
			}
		}

		private string getStockName(ref int lID)
		{
			string functionReturnValue = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			if (lID != 0) {
				rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name FROM StockItem WHERE (StockItemID = " + lID + ")");
				if (rs.BOF | rs.EOF) {
				} else {
					functionReturnValue = rs.Fields("StockItem_Name").Value;
				}
			}
			functionReturnValue = "";
			return functionReturnValue;
		}


		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modApplication.report_StockBreak();
		}

		private void frmStockBreak_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case System.Windows.Forms.Keys.Escape:
					KeyAscii = 0;
					cmdExit_Click(cmdExit, new System.EventArgs());
					break;
			}

			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		public void loadItem(ref string lKey)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			 // ERROR: Not supported in C#: OnErrorStatement

			if (!string.IsNullOrEmpty(lKey)) {
				this.lblParent.Tag = Convert.ToInt32(Strings.Split(lKey, "_")[0]);
				gParent = Convert.ToInt32(lblParent.Tag);
				this.lblParent.Text = getStockName(ref Convert.ToInt32(this.lblParent.Tag));
				this.lblChild.Tag = Convert.ToInt32(Strings.Split(lKey, "_")[1]);
				gChild = Convert.ToInt32(lblChild.Tag);
				this.lblChild.Text = getStockName(ref Convert.ToInt32(this.lblChild.Tag));
				rs = modRecordSet.getRS(ref "SELECT StockBreak.* From StockBreak WHERE (((StockBreak.StockBreak_ParentID)=" + gParent + ") AND ((StockBreak.StockBreak_ChildID)=" + gChild + "));");
				if (rs.RecordCount) {
					txtQuantity.Text = rs.Fields("StockBreak_Quantity").Value;

					this.chkDisabled.CheckState = System.Math.Abs(Convert.ToInt16(rs.Fields("StockBreak_Disabled" + 0).Value));
				} else {
					txtQuantity.Text = Convert.ToString(0);
					this.chkDisabled.CheckState = false;
				}
			} else {
				gParent = 0;
				gChild = 0;
				txtQuantity.Text = Convert.ToString(0);
				this.chkDisabled.CheckState = false;
			}

			loadLanguage();
			this.ShowDialog();
		}

		private void txtQuantity_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtQuantity);
		}

		private void txtQuantity_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			modUtilities.MyKeyPress(ref KeyAscii);
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
