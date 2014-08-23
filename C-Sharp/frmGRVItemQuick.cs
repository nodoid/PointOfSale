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
	internal partial class frmGRVItemQuick : System.Windows.Forms.Form
	{
		ADODB.Recordset adoPrimaryRS;

		private void loadLanguage()
		{

			//frmGRVItemQuick = No Code      [GRV Quick Edit]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmGRVItemQuick.Caption = rsLang("LanguageLayoutLnk_Description"): frmGRVItemQuick.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblName = No Code/Dynamic/NA?

			//chkBreakPack = No Code         [Break Pack]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkBreakPack.Caption = rsLang("LanguageLayoutLnk_Description"): chkBreakPack.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_0 = No Code               [Quantity]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1151;
			//Price|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1662;
			//Discount|Checked
			if (modRecordSet.rsLang.RecordCount){Label1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lbl_1 = No Code               [Surcharges]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1217;
			//Proceed|Checked
			if (modRecordSet.rsLang.RecordCount){cmdProceed.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdProceed.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmGRVItemQuick.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

//UPGRADE_WARNING: Event chkBreakPack.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void chkBreakPack_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (chkBreakPack.CheckState) {
				this.txtPrice.Tag = adoPrimaryRS.Fields("StockItem_UnitCost").Value;
			} else {
				this.txtPrice.Tag = adoPrimaryRS.Fields("StockItem_ListCost").Value;
			}
			switch (My.MyProject.Forms.frmGRVitem.activePrice) {
				case 0:
					this.txtPrice.Text = Strings.FormatNumber(this.txtPrice.Tag, 2);
					break;
				case 1:
					this.txtPrice.Text = Strings.FormatNumber(Convert.ToDecimal(txtPrice.Tag) * (1 + Convert.ToDouble(My.MyProject.Forms.frmGRVitem.gridItem.get_TextMatrix(ref My.MyProject.Forms.frmGRVitem.gridItem.row, ref My.MyProject.Forms.frmGRVitem.colVAT)) / 100), 2);
					break;

				case 2:
					this.txtPrice.Text = Strings.FormatNumber(Convert.ToDecimal(this.txtPrice.Tag) + Convert.ToDecimal(My.MyProject.Forms.frmGRVitem.gridItem.get_TextMatrix(ref My.MyProject.Forms.frmGRVitem.gridItem.row, ref My.MyProject.Forms.frmGRVitem.colDepositExclusive)), 2);
					break;
				case 3:
					this.txtPrice.Text = Strings.FormatNumber((Convert.ToDecimal(this.txtPrice.Tag) + Convert.ToDecimal(My.MyProject.Forms.frmGRVitem.gridItem.get_TextMatrix(ref My.MyProject.Forms.frmGRVitem.gridItem.row, ref My.MyProject.Forms.frmGRVitem.colDepositExclusive))) * (1 + Convert.ToDouble(My.MyProject.Forms.frmGRVitem.gridItem.get_TextMatrix(ref My.MyProject.Forms.frmGRVitem.gridItem.row, ref My.MyProject.Forms.frmGRVitem.colVAT)) / 100), 2);
					break;
			}
		}

		private void chkBreakPack_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 27) {
				this.Close();
			}

			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void cmdProceed_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string sql = null;
			bool dirty = false;
			dirty = false;
			decimal lPrice = default(decimal);
			decimal lDiscount = default(decimal);
			if (Convert.ToDouble(chkBreakPack.Tag) != Convert.ToInt16(chkBreakPack.CheckState))
				dirty = true;
			if (Convert.ToDouble(txtQuantity.Tag) != Convert.ToInt16(txtQuantity.Text))
				dirty = true;
			if (Convert.ToDouble(txtPrice.Tag) != Convert.ToDecimal(txtPrice.Text))
				dirty = true;
			if (Convert.ToDouble(txtDiscountMinus.Tag) != Convert.ToDecimal(txtDiscountMinus.Text))
				dirty = true;
			if (Convert.ToDouble(txtDiscountPlus.Tag) != Convert.ToDecimal(txtDiscountPlus.Text))
				dirty = true;

			if (dirty) {
				switch (My.MyProject.Forms.frmGRVitem.activePrice) {
					case 0:
						lPrice = Convert.ToDecimal(this.txtPrice.Text);
						break;
					case 1:
						lPrice = Convert.ToDecimal(txtPrice.Tag) / (1 + Convert.ToDouble(My.MyProject.Forms.frmGRVitem.gridItem.get_TextMatrix(ref My.MyProject.Forms.frmGRVitem.gridItem.row, ref My.MyProject.Forms.frmGRVitem.colVAT)) / 100);
						break;
					case 2:
						lPrice = (Convert.ToDecimal(txtPrice.Tag) - Convert.ToDecimal(My.MyProject.Forms.frmGRVitem.gridItem.get_TextMatrix(ref My.MyProject.Forms.frmGRVitem.gridItem.row, ref My.MyProject.Forms.frmGRVitem.colDepositExclusive)));
						break;
					case 3:
						lPrice = (Convert.ToDecimal(txtPrice.Tag) - Convert.ToDecimal(My.MyProject.Forms.frmGRVitem.gridItem.get_TextMatrix(ref My.MyProject.Forms.frmGRVitem.gridItem.row, ref My.MyProject.Forms.frmGRVitem.colDepositInclusive))) / (1 + Convert.ToDouble(My.MyProject.Forms.frmGRVitem.gridItem.get_TextMatrix(ref My.MyProject.Forms.frmGRVitem.gridItem.row, ref My.MyProject.Forms.frmGRVitem.colVAT)) / 100);
						break;
				}
				lDiscount = Convert.ToDecimal(txtDiscountPlus.Text) - Convert.ToDecimal(txtDiscountMinus.Text);
				if (My.MyProject.Forms.frmGRVitem.gridItem.get_ColWidth(ref My.MyProject.Forms.frmGRVitem.colDiscount)) {
				} else if (My.MyProject.Forms.frmGRVitem.gridItem.get_ColWidth(ref My.MyProject.Forms.frmGRVitem.colDiscountLine)) {
					lDiscount = lDiscount / Convert.ToInt16(txtQuantity.Text);
				} else if (My.MyProject.Forms.frmGRVitem.gridItem.get_ColWidth(ref My.MyProject.Forms.frmGRVitem.colDiscountPercentage)) {
					lDiscount = Convert.ToDecimal(My.MyProject.Forms.frmGRVitem.gridItem.get_TextMatrix(ref My.MyProject.Forms.frmGRVitem.gridItem.row, ref My.MyProject.Forms.frmGRVitem.colContentExclusive)) * lDiscount / 100;
				}
				if (My.MyProject.Forms.frmGRVitem.activePrice == 1 | My.MyProject.Forms.frmGRVitem.activePrice == 3) {
					lDiscount = lDiscount / (1 + Convert.ToDouble(My.MyProject.Forms.frmGRVitem.gridItem.get_TextMatrix(ref My.MyProject.Forms.frmGRVitem.gridItem.row, ref My.MyProject.Forms.frmGRVitem.colVAT)) / 100);
				}

				if (chkBreakPack.CheckState) {
					lPrice = lPrice * Convert.ToInt16(adoPrimaryRS.Fields("StockItem_Quantity").Value);
					sql = "UPDATE GRVItem SET GRVItem_PackSize = 1, GRVItem_Quantity = " + txtQuantity.Text + ", GRVItem_ContentCost = " + lPrice + ", GRVItem_DiscountAmount = " + lDiscount + " WHERE  (GRVItem_GRVID = " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") And (GRVItem_StockItemID = " + My.MyProject.Forms.frmGRVitem.gridItem.get_RowData(ref My.MyProject.Forms.frmGRVitem.gridItem.row) + ") And (GRVItem_return = " + My.MyProject.Forms.frmGRVitem.orderType + ")";
				} else {
					sql = "UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_PackSize = [StockItem]![StockItem_OrderQuantity], GRVItem.GRVItem_Quantity = " + Convert.ToInt16(txtQuantity.Text) + ", GRVItem.GRVItem_ContentCost = " + lPrice + ", GRVItem.GRVItem_DiscountAmount = " + lDiscount + "  WHERE  (GRVItem_GRVID = " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") And (GRVItem_StockItemID = " + My.MyProject.Forms.frmGRVitem.gridItem.get_RowData(ref My.MyProject.Forms.frmGRVitem.gridItem.row) + ") And (GRVItem_return = " + My.MyProject.Forms.frmGRVitem.orderType + ")";


				}
				modRecordSet.cnnDB.Execute(sql);
				My.MyProject.Forms.frmGRVitem.gridItem.set_TextMatrix(ref My.MyProject.Forms.frmGRVitem.gridItem.row, ref My.MyProject.Forms.frmGRVitem.colCode, ref "RELOAD");
			}
			this.Close();
		}

		private void frmGRVItemQuick_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			adoPrimaryRS = modRecordSet.getRS(ref "SELECT  StockItem_ListCost, StockItem_ListCost / StockItem_Quantity AS StockItem_UnitCost, StockItem_Quantity From StockItem Where (StockItemID = " + My.MyProject.Forms.frmGRVitem.gridItem.get_RowData(ref My.MyProject.Forms.frmGRVitem.gridItem.row) + ")");
			if (adoPrimaryRS.BOF | adoPrimaryRS.EOF) {
				this.Close();
			} else {
				loadLanguage();

				this.lblName.Text = My.MyProject.Forms.frmGRVitem.gridItem.get_TextMatrix(ref My.MyProject.Forms.frmGRVitem.gridItem.row, ref My.MyProject.Forms.frmGRVitem.colName);
				if (My.MyProject.Forms.frmGRVitem.gridItem.get_TextMatrix(ref My.MyProject.Forms.frmGRVitem.gridItem.row, ref My.MyProject.Forms.frmGRVitem.colBrokenPack) == "X") {
					chkBreakPack.CheckState = System.Windows.Forms.CheckState.Checked;
				} else {
					chkBreakPack.CheckState = System.Windows.Forms.CheckState.Unchecked;
				}
				chkBreakPack.Tag = chkBreakPack.CheckState;
				this.txtQuantity.Text = My.MyProject.Forms.frmGRVitem.gridItem.get_TextMatrix(ref My.MyProject.Forms.frmGRVitem.gridItem.row, ref My.MyProject.Forms.frmGRVitem.colQuantity);
				this.txtDiscountMinus.Text = Strings.FormatNumber(0, 2);
				if (My.MyProject.Forms.frmGRVitem.gridItem.get_ColWidth(ref My.MyProject.Forms.frmGRVitem.colDiscount)) {
					this.txtDiscountPlus.Text = Strings.FormatNumber(My.MyProject.Forms.frmGRVitem.gridItem.get_TextMatrix(ref My.MyProject.Forms.frmGRVitem.gridItem.row, ref My.MyProject.Forms.frmGRVitem.colDiscount), 2);
				} else if (My.MyProject.Forms.frmGRVitem.gridItem.get_ColWidth(ref My.MyProject.Forms.frmGRVitem.colDiscountLine)) {
					this.txtDiscountPlus.Text = Strings.FormatNumber(My.MyProject.Forms.frmGRVitem.gridItem.get_TextMatrix(ref My.MyProject.Forms.frmGRVitem.gridItem.row, ref My.MyProject.Forms.frmGRVitem.colDiscountLine), 2);
				} else if (My.MyProject.Forms.frmGRVitem.gridItem.get_ColWidth(ref My.MyProject.Forms.frmGRVitem.colDiscountPercentage)) {
					this.txtDiscountPlus.Text = Strings.FormatNumber(My.MyProject.Forms.frmGRVitem.gridItem.get_TextMatrix(ref My.MyProject.Forms.frmGRVitem.gridItem.row, ref My.MyProject.Forms.frmGRVitem.colDiscountPercentage), 2);
				} else {
					this.txtDiscountPlus.Text = Convert.ToString(0);
				}
				chkBreakPack_CheckStateChanged(chkBreakPack, new System.EventArgs());
				txtQuantity.Tag = Convert.ToInt16(txtQuantity.Text);
				txtPrice.Tag = Convert.ToDecimal(txtPrice.Text);
				txtDiscountMinus.Tag = Convert.ToDecimal(txtDiscountMinus.Text);
				txtDiscountPlus.Tag = Convert.ToDecimal(txtDiscountPlus.Text);
			}
		}

		private void txtDiscountMinus_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtDiscountMinus);
		}

		private void txtDiscountMinus_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 27) {
				this.Close();
			} else {
				modUtilities.MyKeyPress(ref KeyAscii);
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtDiscountMinus_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtDiscountMinus, ref 2);
		}

		private void txtDiscountPlus_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtDiscountPlus);
		}

		private void txtDiscountPlus_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 27) {
				this.Close();
			} else {
				modUtilities.MyKeyPress(ref KeyAscii);
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtDiscountPlus_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtDiscountPlus, ref 2);
		}
		private void txtPrice_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtPrice);
		}

		private void txtPrice_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 27) {
				this.Close();
			} else {
				modUtilities.MyKeyPress(ref KeyAscii);
			}
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
			if (KeyAscii == 27) {
				this.Close();
			} else {
				modUtilities.MyKeyPress(ref KeyAscii);
			}
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
