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
	internal partial class frmPromotionItem : System.Windows.Forms.Form
	{
		int gStockItemID;
		int gPromotionID;
		int gQuantity;

		private void loadLanguage()
		{

			//frmPromotionItem = No Code     [Edit Promotion Item]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmPromotionItem.Caption = rsLang("LanguageLayoutLnk_Description"): frmPromotionItem.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1139;
			//Promotion Name|Checked
			if (modRecordSet.rsLang.RecordCount){_LBL_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_LBL_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1935;
			//Stock Item Name|Checked
			if (modRecordSet.rsLang.RecordCount){_LBL_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_LBL_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2145;
			//Shrink Size|Checked
			if (modRecordSet.rsLang.RecordCount){_LBL_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_LBL_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1151;
			//Price|Checked
			if (modRecordSet.rsLang.RecordCount){_LBL_3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_LBL_3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmPromotionItem.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void loadData()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			if (gQuantity) {

				rs = modRecordSet.getRS(ref "SELECT PromotionItem.*, StockItem.StockItem_Name, Promotion.Promotion_Name FROM Promotion INNER JOIN (PromotionItem INNER JOIN StockItem ON PromotionItem.PromotionItem_StockItemID = StockItem.StockItemID) ON Promotion.PromotionID = PromotionItem.PromotionItem_PromotionID WHERE PromotionItem.PromotionItem_PromotionID=" + gPromotionID + " AND PromotionItem.PromotionItem_StockItemID=" + gStockItemID + " AND PromotionItem.PromotionItem_Quantity=" + gQuantity);
				if (rs.RecordCount) {
					lblStockItem.Text = rs.Fields("StockItem_Name").Value;
					lblPromotion.Text = rs.Fields("Promotion_Name").Value;
					txtPrice.Text = Convert.ToString(rs.Fields("PromotionItem_Price").Value * 100);
					txtPrice_Leave(txtPrice, new System.EventArgs());
					cmbQuantity.Tag = gQuantity;
				} else {
					this.Close();
					return;
				}
			} else {
				rs = modRecordSet.getRS(ref "SELECT Promotion.Promotion_Name, StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM Promotion, StockItem INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID WHERE (((Promotion.PromotionID)=" + gPromotionID + ") AND ((StockItem.StockItemID)=" + gStockItemID + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));");
				if (rs.RecordCount) {
					lblStockItem.Text = rs.Fields("StockItem_Name").Value;
					lblPromotion.Text = rs.Fields("Promotion_Name").Value;
					txtPrice.Text = Convert.ToString(rs.Fields("CatalogueChannelLnk_Price").Value * 100);
					txtPrice_Leave(txtPrice, new System.EventArgs());
					cmbQuantity.Tag = rs.Fields("CatalogueChannelLnk_Quantity").Value;
				} else {
					this.Close();
					return;
				}

			}
			rs = modRecordSet.getRS(ref "SELECT Catalogue.Catalogue_Quantity From Catalogue Where (((Catalogue.Catalogue_StockItemID) = " + gStockItemID + ") And ((Catalogue.Catalogue_Disabled) = 0)) ORDER BY Catalogue.Catalogue_Quantity;");
			cmbQuantity.Items.Clear();
			while (!(rs.EOF)) {
				cmbQuantity.Items.Add(rs.Fields("Catalogue_Quantity").Value);
				if (cmbQuantity.Tag == rs.Fields("Catalogue_Quantity").Value) {
					cmbQuantity.SelectedIndex = cmbQuantity.SelectedIndex;
				}
				rs.moveNext();
			}
		}
		public void loadItem(ref int promotionID, ref int stockitemID, ref int quantity = 0)
		{
			gStockItemID = stockitemID;
			gPromotionID = promotionID;
			gQuantity = quantity;
			loadData();

			loadLanguage();
			ShowDialog();
		}
		private void frmPromotionItem_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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
			ADODB.Recordset adoPrimaryRS = new ADODB.Recordset();
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

			functionReturnValue = true;
			modRecordSet.cnnDB.Execute("DELETE PromotionItem.* From PromotionItem WHERE (((PromotionItem.PromotionItem_PromotionID)=" + gPromotionID + ") AND ((PromotionItem.PromotionItem_StockItemID)=" + gStockItemID + ") AND ((PromotionItem.PromotionItem_Quantity)=" + gQuantity + "));");
			modRecordSet.cnnDB.Execute("DELETE PromotionItem.* From PromotionItem WHERE (((PromotionItem.PromotionItem_PromotionID)=" + gPromotionID + ") AND ((PromotionItem.PromotionItem_StockItemID)=" + gStockItemID + ") AND ((PromotionItem.PromotionItem_Quantity)=" + Convert.ToString(this.cmbQuantity.SelectedIndex) + "));");

			modRecordSet.cnnDB.Execute("INSERT INTO PromotionItem ( PromotionItem_PromotionID, PromotionItem_StockItemID, PromotionItem_Quantity, PromotionItem_Price ) SELECT " + gPromotionID + " , " + gStockItemID + ", " + Convert.ToString(this.cmbQuantity.SelectedIndex) + ", " + Convert.ToDecimal(this.txtPrice.Text));
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
	}
}
