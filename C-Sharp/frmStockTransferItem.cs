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
using Microsoft.VisualBasic.PowerPacks;
namespace _4PosBackOffice.NET
{
	internal partial class frmStockTransferItem : System.Windows.Forms.Form
	{
		int gStockItemID;
		int gPromotionID;
		int gQuantity;

		private void loadLanguage()
		{

			//frmStockTransferItem = No Code     [Edit Stock Transfer Item]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmStockTransferItem.Caption = rsLang("LanguageLayoutLnk_Description"): frmStockTransferItem.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1139;
			//Promotion Name|Checked
			//If rsLang.RecordCount Then lblPComp.Caption = rsLang("LanguageLayoutLnk_Description"): lblPComp.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1935;
			//Stock Item Name|Checked
			if (modRecordSet.rsLang.RecordCount){_LBL_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_LBL_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lbl_2 = No Code                   [Item Qty]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label2 = No Code                   [Please verify Products from both Locations]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label2.Caption = rsLang("LanguageLayoutLnk_Description"): Label2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1139;
			//Promotion Name|Checked
			//If rsLang.RecordCount Then lblSComp.Caption = rsLang("LanguageLayoutLnk_Description"): lblSComp.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1935;
			//Stock Item Name|Checked
			if (modRecordSet.rsLang.RecordCount){_LBL_5.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_LBL_5.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1151;
			//Price|Checked
			if (modRecordSet.rsLang.RecordCount){_LBL_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_LBL_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmStockTransferItem.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void loadData()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rj = default(ADODB.Recordset);

			ADODB.Connection cn = default(ADODB.Connection);
			ADODB.Recordset rt = default(ADODB.Recordset);
			if (gQuantity) {

				rs = modRecordSet.getRS(ref "SELECT StockTransferGRV.*, StockItem.StockItem_Name, StockItem.StockItem_Quantity, StockItem.StockItem_ListCost FROM StockTransferGRV INNER JOIN StockItem ON StockTransferGRV.StockTransfer_StockItemID = StockItem.StockItemID WHERE StockTransferGRV.StockTransfer_StockItemID=" + gStockItemID + " AND StockTransferGRV.StockTransfer_Quantity=" + gQuantity);
				//Set rs = getRS("SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & gStockItemID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
				if (rs.RecordCount) {
					lblStockItem.Text = rs.Fields("StockItem_Name").Value;
					//lblPromotion.Caption = rs("Promotion_Name")
					txtPrice.Text = Convert.ToString(rs.Fields("StockItem_ListCost").Value * 100);
					txtPrice.Tag = rs.Fields("StockItem_ListCost").Value;
					txtPrice_Leave(txtPrice, new System.EventArgs());
					//cmbQuantity.Tag = gQuantity
					txtPSize.Text = rs.Fields("StockItem_Quantity").Value;
					txtQtyT.Text = rs.Fields("StockTransfer_Quantity").Value;
					//* 100

					if (Convert.ToDouble(txtPSize.Text) != 1) {
						txtPrice.Text = Strings.FormatNumber(Convert.ToDecimal(txtPrice.Tag) / Convert.ToDecimal(txtPSize.Text), 2);
					}
					//txtQty.SetFocus
					this.Height = sizeConvertors.twipsToPixels(2850, false);

					loadLanguage();
					ShowDialog();
				} else {
					this.Close();
					return;
				}
			} else {
				//Set rs = getRS("SELECT Promotion.Promotion_Name, StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM Promotion, StockItem INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID WHERE (((Promotion.PromotionID)=" & gPromotionID & ") AND ((StockItem.StockItemID)=" & gStockItemID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
				//Set rs = getRS("SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM StockItem INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID WHERE (((StockItem.StockItemID)=" & gStockItemID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")

				rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, StockItem.StockItem_Quantity, StockItem.StockItem_ListCost, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + gStockItemID + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));");
				//Set rs = getRS("SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & gStockItemID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
				if (rs.RecordCount) {
				} else {
					//MsgBox "Supplier Qty is different from Catalogue Qty. Be advised wizard will transfer in singles!"
					txtPack.Text = Convert.ToString(0);
					rs.Close();
					rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, StockItem.StockItem_Quantity, StockItem.StockItem_ListCost, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + gStockItemID + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));");
				}
				if (rs.RecordCount) {
					lblStockItem.Text = rs.Fields("StockItem_Name").Value;
					//lblPromotion.Caption = rs("Promotion_Name")
					txtPrice.Text = Convert.ToString(rs.Fields("StockItem_ListCost").Value * 100);
					//rs("CatalogueChannelLnk_Price") * 100
					txtPrice.Tag = rs.Fields("StockItem_ListCost").Value;
					txtPrice_Leave(txtPrice, new System.EventArgs());
					//cmbQuantity.Tag = rs("CatalogueChannelLnk_Quantity")
					txtPSize.Text = rs.Fields("StockItem_Quantity").Value;

					if (Convert.ToDouble(txtPSize.Text) != 1) {
						txtPrice.Text = Strings.FormatNumber(Convert.ToDecimal(txtPrice.Tag) / Convert.ToDecimal(txtPSize.Text), 2);
					}

					rj = modRecordSet.getRS(ref "SELECT Catalogue_StockItemID, Catalogue_Barcode FROM Catalogue Where Catalogue_StockItemID = " + gStockItemID + " AND Catalogue_Quantity=1 Order By Catalogue_Quantity;");
					if (rs.RecordCount) {
						if (string.IsNullOrEmpty(My.MyProject.Forms.frmStockTransfer.loadDBStr)) {
							Interaction.MsgBox("Please setup first other location to transfer!");
							this.Close();
						} else {
							cn = modRecordSet.openSComp(ref My.MyProject.Forms.frmStockTransfer.loadDBStr);
							if (cn == null) {
								Interaction.MsgBox("Please setup first other location to transfer!");
								this.Close();
							} else {

								lblSComp.Text = My.MyProject.Forms.frmStockTransfer.lblSComp.Text;
								//Set rT = getRSwaitron("SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price, Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Barcode FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((Catalogue.Catalogue_Barcode)='" & rj("Catalogue_Barcode") & "') AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));", cn)
								rt = modRecordSet.getRSwaitron(ref "SELECT StockItem.StockItem_Name, Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Barcode FROM Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID) WHERE (((Catalogue.Catalogue_Barcode)='" + rj.Fields("Catalogue_Barcode").Value + "'));", ref cn);
								if (rt.RecordCount) {
									lblStockItemS.Text = rt.Fields("StockItem_Name").Value;
									//txtPriceS.Text = rT("CatalogueChannelLnk_Price") * 100
									//txtPriceS_LostFocus

									this.Height = sizeConvertors.twipsToPixels(4215, false);
									//3810

									loadLanguage();
									ShowDialog();

								} else {
									//MsgBox "Barcode not found for  '" & UCase(rs("StockItem_Name")) & "'  in  '" & UCase(lblSComp.Caption) & "'  you wish to transfer the stock!"
									Interaction.MsgBox("No corresponding Barcode found for  '" + Strings.UCase(rs.Fields("StockItem_Name").Value) + "'  in the receiving company. A transfer cannot be done at this time!");
									this.Close();
								}
							}
						}

					} else {
						Interaction.MsgBox("No Barcode for the current item!");
						this.Close();
					}

				} else {
					Interaction.MsgBox("Could not load Stock Item. Please check Supplier Qty, Barcode for Stock Item.!");
					this.Close();
					return;
				}
			}

		}

//Public Sub loadItem(promotionID As Long, stockitemID As Long, Optional quantity As Long)
		public void loadItem(ref int stockitemID, ref int quantity = 0)
		{
			gStockItemID = stockitemID;
			//gPromotionID = promotionID
			gQuantity = quantity;
			lblPComp.Text = My.MyProject.Forms.frmStockTransfer.lblPComp.Text;
			loadData();

			//show 1

		}

		private void cmdPack_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (Convert.ToDouble(txtPSize.Text) != 1) {
				cmdPack.Tag = txtPSize.Text;
				txtPSize.Text = Convert.ToString(1);
				//txtPrice = FormatNumber(CCur(txtPrice.Tag) / CCur(cmdPack.Tag), 2)
			} else {
				if (!string.IsNullOrEmpty(cmdPack.Tag))
					txtPSize.Text = cmdPack.Tag;
				//txtPrice = FormatNumber(txtPrice.Tag, 2)
			}

			if (string.IsNullOrEmpty(txtQtyT.Text))
				txtQtyT.Text = "0";
			if (Information.IsNumeric(txtQtyT.Text)) {
			} else {
				txtQtyT.Text = "0";
			}
			txtQty.Text = Convert.ToString(Convert.ToDouble(txtQtyT.Text) * Convert.ToDouble(txtPSize.Text));

			txtQtyT.Focus();
		}

		private void frmStockTransferItem_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			object mbAddNewFlag = null;
			object mbEditFlag = null;
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

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			//If mbAddNewFlag Then
			this.Close();
			//Else
			//mbEditFlag = False
			//mbAddNewFlag = False
			//adoPrimaryRS.CancelUpdate
			//If mvBookMark > 0 Then
			//    adoPrimaryRS.Bookmark = mvBookMark
			//Else
			//    adoPrimaryRS.MoveFirst
			//End If
			//mbDataChanged = False
			//End If
		}

//UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private bool update_Renamed()
		{
			bool functionReturnValue = false;
			 // ERROR: Not supported in C#: OnErrorStatement

			functionReturnValue = true;
			modRecordSet.cnnDB.Execute("DELETE StockTransferGRV.* From StockTransferGRV WHERE (((StockTransferGRV.StockTransfer_StockItemID)=" + gStockItemID + ") AND ((StockTransferGRV.StockTransfer_Quantity)=" + gQuantity + "));");
			modRecordSet.cnnDB.Execute("DELETE StockTransferGRV.* From StockTransferGRV WHERE (((StockTransferGRV.StockTransfer_StockItemID)=" + gStockItemID + "));");

			//OLD     cnnDB.Execute "INSERT INTO StockTransferGRV ( StockTransfer_StockItemID, StockTransfer_Quantity, StockTransfer_Price ) SELECT " & gStockItemID & ", " & CCur(Me.txtQty.Text) & ", " & CCur(Me.txtPrice.Text)
			modRecordSet.cnnDB.Execute("INSERT INTO StockTransferGRV ( StockTransfer_StockItemID, StockTransfer_Quantity, StockTransfer_Price, StockTransfer_Pack ) SELECT " + gStockItemID + ", " + Convert.ToDecimal(this.txtQty.Text) + ", " + Convert.ToDecimal(this.txtPrice.Text) + ", " + this.txtPack.Text);
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
			if (Convert.ToDecimal(txtQty.Text) > 0) {
			} else {
				txtQty.Focus();
				return;
			}

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

		private void txtPriceS_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtPriceS);
		}

		private void txtPriceS_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtPriceS, ref 2);
		}

		private void txtQty_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case Strings.Asc(Constants.vbCr):
					KeyAscii = 0;
					break;
				case 8:
					break;
				case 48:
				case 49:
				case 50:
				case 51:
				case 52:
				case 53:
				case 54:
				case 55:
				case 56:
				case 57:
					break;

			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtQty_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			//MyGotFocusNumeric txtQty
			txtQty.SelectionStart = 0;
			txtQty.SelectionLength = Strings.Len(txtQty.Text);
		}

		private void txtQty_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			// LostFocus txtQty, 2
		}

//UPGRADE_WARNING: Event txtQtyT.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void txtQtyT_TextChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (string.IsNullOrEmpty(txtQtyT.Text)){txtQty.Text = Convert.ToString(0);return;
}
			if (txtQtyT.Text == "0"){txtQty.Text = Convert.ToString(0);return;
}
			if (Information.IsNumeric(txtQtyT.Text)) {
			} else {
				txtQty.Text = Convert.ToString(0);
				return;
			}
			txtQty.Text = Convert.ToString(Convert.ToDouble(txtQtyT.Text) * Convert.ToDouble(txtPSize.Text));
		}

		private void txtQtyT_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case Strings.Asc(Constants.vbCr):
					KeyAscii = 0;
					break;
				case 8:
				case 46:
					break;
				case 48:
				case 49:
				case 50:
				case 51:
				case 52:
				case 53:
				case 54:
				case 55:
				case 56:
				case 57:
					break;
				default:
					KeyAscii = 0;
					break;
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtQtyT_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			//MyGotFocusNumeric txtQty
			txtQtyT.SelectionStart = 0;
			txtQtyT.SelectionLength = Strings.Len(txtQtyT.Text);
		}

		private void txtQtyT_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			// LostFocus txtQty, 2
		}
	}
}
