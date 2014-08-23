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
	internal partial class frmStockTransferItemWH : System.Windows.Forms.Form
	{
		int gStockItemID;
		int gPromotionID;
		int gQuantity;
		int WHFromA;
		int WHToB;

		private void loadLanguage()
		{

			//frmStockTransferItemWH = No Code   [Edit Stock Transfer Item]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmStockTransferItemWH.Caption = rsLang("LanguageLayoutLnk_Description"): frmStockTransferItemWH.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1139;
			//Promotion Name|Checked
			if (modRecordSet.rsLang.RecordCount){lblPComp.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lblPComp.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1935;
			//Stock Item Name|Checked
			if (modRecordSet.rsLang.RecordCount){_LBL_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_LBL_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lbl_2 = No Code                   [Item Qty]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1151;
			//Price|Checked
			if (modRecordSet.rsLang.RecordCount){_LBL_3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_LBL_3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmStockTransferItemWH.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void loadData()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rj = default(ADODB.Recordset);

			rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, StockItem_Quantity FROM StockItem WHERE ((StockItem.StockItemID)=" + gStockItemID + ");");
			if (rs.RecordCount) {
				lblStockItem.Text = rs.Fields("StockItem_Name").Value;
				txtPSize.Text = rs.Fields("StockItem_Quantity").Value;
				this.Height = sizeConvertors.twipsToPixels(2520, false);

				loadLanguage();
				ShowDialog();
			}

		}

//Public Sub loadItem(promotionID As Long, stockitemID As Long, Optional quantity As Long)
		public void loadItem(ref int stockitemID, ref int quantity = 0, ref int WHFrom = 0, ref int WHTo = 0)
		{
			gStockItemID = stockitemID;
			//gPromotionID = promotionID
			gQuantity = quantity;
			WHFromA = WHFrom;
			WHToB = WHTo;
			lblPComp.Text = My.MyProject.Forms.frmStockTransferWH.lblWHA.Text;
			loadData();

			//show 1

		}

		private void cmdPack_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (Convert.ToDouble(txtPSize.Text) != 1) {
				cmdPack.Tag = txtPSize.Text;
				txtPSize.Text = Convert.ToString(1);
			} else {
				if (!string.IsNullOrEmpty(cmdPack.Tag))
					txtPSize.Text = cmdPack.Tag;
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

		private void frmStockTransferItemWH_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void ChkHandheldWHTransfer()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string strFldName = null;
			ChkTransTable:


			 // ERROR: Not supported in C#: OnErrorStatement

			rs = modRecordSet.getRS(ref "SELECT * FROM HandheldWHTransfer;");
			if (rs.RecordCount) {
			}

			return;
			Err_ChkTransTable:
			if (Err().Number == -2147217865 & Err().Description == "[Microsoft][ODBC Microsoft Access Driver] The Microsoft Jet database engine cannot find the input table or query 'HandheldWHTransfer'.  Make sure it exists and that its name is spelled correctly.") {
				strFldName = "HandHeldID Number,Handheld_Barcode Text(50), Quantity Currency, WHouseID Number";
				modRecordSet.cnnDB.Execute("CREATE TABLE HandheldWHTransfer (" + strFldName + ")");
				System.Windows.Forms.Application.DoEvents();
				rs = modRecordSet.getRS(ref "SELECT * FROM HandheldWHTransfer;");
				if (rs.RecordCount) {
				}

				goto ChkTransTable;
			}

		}

//UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private bool update_Renamed()
		{
			bool functionReturnValue = false;
			string sql = null;
			 // ERROR: Not supported in C#: OnErrorStatement


			ChkHandheldWHTransfer();

			//UPGRADE_WARNING: Couldn't resolve default property of object sql. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			sql = "INSERT INTO HandheldWHTransfer (HandHeldID,Handheld_Barcode,Quantity,WHouseID) VALUES (" + gStockItemID + ", 0, " + (0 - Convert.ToDecimal(txtQty.Text)) + "," + WHFromA + ")";
			//UPGRADE_WARNING: Couldn't resolve default property of object sql. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modRecordSet.cnnDB.Execute(sql);
			System.Windows.Forms.Application.DoEvents();

			//UPGRADE_WARNING: Couldn't resolve default property of object sql. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			sql = "INSERT INTO HandheldWHTransfer (HandHeldID,Handheld_Barcode,Quantity,WHouseID) VALUES (" + gStockItemID + ", 0, " + Convert.ToDecimal(txtQty.Text) + "," + WHToB + ")";
			//UPGRADE_WARNING: Couldn't resolve default property of object sql. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modRecordSet.cnnDB.Execute(sql);
			System.Windows.Forms.Application.DoEvents();

			functionReturnValue = true;
			return functionReturnValue;
			UpdateErr:
			Interaction.MsgBox(Err().Description);
			functionReturnValue = true;
			return functionReturnValue;

		}

		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string sql = null;
			cmdClose.Focus();
			System.Windows.Forms.Application.DoEvents();
			if (Convert.ToDecimal(txtQtyT.Text) > 0) {
			} else {
				txtQtyT.Focus();
				return;
			}

			ADODB.Recordset rs = default(ADODB.Recordset);
			//UPGRADE_WARNING: Couldn't resolve default property of object sql. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			sql = "SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS Warehouse_StockItemQuantity From WarehouseStockItemLnk Where (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) = " + My.MyProject.Forms.frmStockTransferWH.lWHA + ")) GROUP BY WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID HAVING (((WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID)=" + gStockItemID + "));";
			rs = modRecordSet.getRS(ref sql);
			if (rs.RecordCount) {
				if (rs.Fields("Warehouse_StockItemQuantity").Value < Convert.ToDecimal(txtQty.Text)) {
					Interaction.MsgBox("Insufficient Qty in '" + My.MyProject.Forms.frmStockTransferWH.lblWHA.Text + "'");
					txtQtyT.Focus();
					return;
				}
			} else {
				Interaction.MsgBox("Insufficient Qty in '" + My.MyProject.Forms.frmStockTransferWH.lblWHA.Text + "'");
				txtQtyT.Focus();
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
