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
	internal partial class frmOrderItemQuick : System.Windows.Forms.Form
	{
		ADODB.Recordset adoPrimaryRS;

		private void loadLanguage()
		{

			//frmOrderItemQuick = No Code      [GRV Quick Edit]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmOrderItemQuick.Caption = rsLang("LanguageLayoutLnk_Description"): frmOrderItemQuick.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblName = No Code/Dynamic/NA?

			//chkBreakPack = No Code         [Break Pack]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkBreakPack.Caption = rsLang("LanguageLayoutLnk_Description"): chkBreakPack.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_0 = No Code               [Quantity]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//    rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1151 'Price|Checked
			//    If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
			//
			//    rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1662 'Discount|Checked
			//    If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
			//
			//_lbl_1 = No Code               [Surcharges]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//    rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1217 'Proceed|Checked
			//    If rsLang.RecordCount Then cmdProceed.Caption = rsLang("LanguageLayoutLnk_Description"): cmdProceed.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
			//
			//    rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
			//    If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp("Help_ContextID")

		}

		private void chkBreakPack_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//If chkBreakPack.value Then
			// Me.txtMin.Tag = adoPrimaryRS.Fields("StockItem_UnitCost").Value
			// Else
			// Me.txtMin.Tag = adoPrimaryRS.Fields("StockItem_ListCost").Value
			// End If

			switch (My.MyProject.Forms.frmGRVitem.activePrice) {
				case 0:
					this.txtMin.Text = Strings.FormatNumber(this.txtMin.Tag, 2);
					break;
				case 1:
					this.txtMin.Text = Strings.FormatNumber(Convert.ToDecimal(txtMin.Tag) * (1 + Convert.ToDouble(My.MyProject.Forms.frmGRVitem.gridItem.get_TextMatrix(ref My.MyProject.Forms.frmGRVitem.gridItem.row, ref My.MyProject.Forms.frmGRVitem.colVAT)) / 100), 2);

					break;
				case 2:
					this.txtMin.Text = Strings.FormatNumber(Convert.ToDecimal(this.txtMin.Tag) + Convert.ToDecimal(My.MyProject.Forms.frmGRVitem.gridItem.get_TextMatrix(ref My.MyProject.Forms.frmGRVitem.gridItem.row, ref My.MyProject.Forms.frmGRVitem.colDepositExclusive)), 2);
					break;
				case 3:
					this.txtMin.Text = Strings.FormatNumber((Convert.ToDecimal(this.txtMin.Tag) + Convert.ToDecimal(My.MyProject.Forms.frmGRVitem.gridItem.get_TextMatrix(ref My.MyProject.Forms.frmGRVitem.gridItem.row, ref My.MyProject.Forms.frmGRVitem.colDepositExclusive))) * (1 + Convert.ToDouble(My.MyProject.Forms.frmGRVitem.gridItem.get_TextMatrix(ref My.MyProject.Forms.frmGRVitem.gridItem.row, ref My.MyProject.Forms.frmGRVitem.colVAT)) / 100), 2);
					break;
			}
		}

		private void chkBreakPack_KeyPress(ref short KeyAscii)
		{
			if (KeyAscii == 27) {
				this.Close();
			}

		}

		private void cmdProceed_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string sql = null;
			bool dirty = false;
			dirty = false;
			decimal lPrice = default(decimal);
			decimal lDiscount = default(decimal);

			if (Convert.ToDouble(txtCost.Tag) != Convert.ToDecimal(txtCost.Text))
				dirty = true;
			if (Convert.ToDouble(txtMin.Tag) != Convert.ToInt16(txtMin.Text))
				dirty = true;
			if (Convert.ToDouble(txtMax.Tag) != Convert.ToInt16(txtMax.Text))
				dirty = true;

			if (dirty) {
				sql = "UPDATE MinMaxStockItemLnk SET MinMaxStockItemLnk_Minimum = " + Convert.ToInt16(txtMin.Text) + " Where (MinMaxStockItemLnk_MinMaxID = 1) And (MinMaxStockItemLnk_StockItemID = " + Convert.ToInt16(this.lblName.Tag) + ")";
				modRecordSet.cnnDB.Execute(sql);

				modRecordSet.cnnDB.Execute("UPDATE StockItem SET StockItem.StockItem_MinimumStock = " + Convert.ToInt16(txtMin.Text) + ", StockItem_OrderRounding = " + Convert.ToInt16(txtMax.Text) + " WHERE StockItemID = " + Convert.ToInt16(this.lblName.Tag) + ";");
			}
			this.Close();
		}

		private void frmOrderItemQuick_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (!string.IsNullOrEmpty(My.MyProject.Forms.frmOrderWizard.Tag)) {
				loadLanguage();

				this.lblName.Tag = Strings.Split(My.MyProject.Forms.frmOrderWizard.Tag, "|")[0];
				this.lblName.Text = Strings.Split(My.MyProject.Forms.frmOrderWizard.Tag, "|")[1];

				this.txtCost.Text = Strings.Split(My.MyProject.Forms.frmOrderWizard.Tag, "|")[2];
				this.txtMin.Text = Strings.Split(My.MyProject.Forms.frmOrderWizard.Tag, "|")[4];
				this.txtMax.Text = Strings.Split(My.MyProject.Forms.frmOrderWizard.Tag, "|")[3];

				txtCost.Tag = Convert.ToDecimal(txtCost.Text);
				txtMin.Tag = Convert.ToDecimal(txtMin.Text);
				txtMax.Tag = Convert.ToDecimal(txtMax.Text);

			} else {
				this.Close();
			}
		}

		private void txtMax_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtMax);
		}

		private void txtMax_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void txtMax_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtMax, ref 0);
		}
		private void txtMin_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtMin);
		}

		private void txtMin_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void txtMin_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtMin, ref 0);
		}

		private void txtCost_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtCost);
		}

		private void txtCost_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void txtCost_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtCost, ref 2);
		}
	}
}
