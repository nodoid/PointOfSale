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
	internal partial class frmVegTestStockBack : System.Windows.Forms.Form
	{
		int gStockItemID;
		int gPromotionID;
		decimal gQuantity;
		int WHFromA;
		int WHToB;

		private void loadData()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);

			rs = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, StockItem.StockItem_Name, PackSize.PackSize_Volume FROM StockItem INNER JOIN PackSize ON StockItem.StockItem_PackSizeID = PackSize.PackSizeID WHERE (((StockItem.StockItemID)=" + gStockItemID + "));");
			if (rs.RecordCount) {
				lblStockItem.Text = rs.Fields("StockItem_Name").Value;
				txtQty.Text = Strings.FormatNumber(gQuantity, 4);
				txtPrice.Text = Strings.FormatNumber(gQuantity * (rs.Fields("PackSize_Volume").Value == 0 ? 1 : rs.Fields("PackSize_Volume").Value), 2);
				this.Height = sizeConvertors.twipsToPixels(4785, false);
				ShowDialog();
			}

		}

//Public Sub loadItem(promotionID As Long, stockitemID As Long, Optional quantity As Long)
		public void loadItem(ref int stockitemID, ref decimal quantity = 0, ref int WHFrom = 0, ref int WHTo = 0)
		{
			gStockItemID = stockitemID;
			//gPromotionID = promotionID
			gQuantity = quantity;
			//WHFromA = WHFrom
			//WHToB = WHTo
			//lblPComp.Caption = frmStockTransferWH.lblWHA.Caption
			loadData();

			//show 1

		}



		private void cmdSelectChild_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int lID = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);

			lID = 0;
			lID = My.MyProject.Forms.frmStockList.getItem();
			if (lID != 0) {
				rs = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, StockItem.StockItem_Name, PackSize.PackSize_Volume FROM StockItem INNER JOIN PackSize ON StockItem.StockItem_PackSizeID = PackSize.PackSizeID WHERE (((StockItem.StockItemID)=" + lID + "));");
				if (rs.RecordCount) {
					lblStockItemB.Text = rs.Fields("StockItem_Name").Value;
					lblStockItemB.Tag = rs.Fields("StockItemID").Value;
					txtQtyB.Text = Strings.FormatNumber(Convert.ToDecimal(txtPrice.Text) / (rs.Fields("PackSize_Volume").Value == 0 ? 1 : rs.Fields("PackSize_Volume").Value), 2);
					txtPriceB.Text = Strings.FormatNumber(txtPrice.Text, 4);
				} else {
					//    MsgBox "Insufficient Qty!"
					//    Exit Sub
				}
				//
			}
		}

		private void frmVegTestStockBack_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

			rs = modRecordSet.getRS(ref "SELECT * FROM HandheldVegReceive;");
			if (rs.RecordCount) {
			}

			return;
			Err_ChkTransTable:
			if (Err().Number == -2147217865 & Err().Description == "[Microsoft][ODBC Microsoft Access Driver] The Microsoft Jet database engine cannot find the input table or query 'HandheldVegReceive'.  Make sure it exists and that its name is spelled correctly.") {
				strFldName = "HandHeldID Number,Handheld_Barcode Text(50), Quantity Currency";
				modRecordSet.cnnDB.Execute("CREATE TABLE HandheldVegReceive (" + strFldName + ")");
				System.Windows.Forms.Application.DoEvents();
				rs = modRecordSet.getRS(ref "SELECT * FROM HandheldVegReceive;");
				if (rs.RecordCount) {
				}

				goto ChkTransTable;
			}

		}

		private bool update_Renamed()
		{
			bool functionReturnValue = false;
			int gID = 0;
			ADODB.Recordset rj = default(ADODB.Recordset);
			ADODB.Recordset RSadoPrimary = default(ADODB.Recordset);
			string sql = null;
			decimal lQuantity = default(decimal);

			 // ERROR: Not supported in C#: OnErrorStatement


			ChkHandheldWHTransfer();
			modRecordSet.cnnDB.Execute("DELETE * FROM HandheldVegReceive;");

			sql = "INSERT INTO HandheldVegReceive (HandHeldID,Handheld_Barcode,Quantity) VALUES (" + gStockItemID + ", 0, " + (0 - Convert.ToDecimal(txtQty.Text)) + ")";
			modRecordSet.cnnDB.Execute(sql);
			System.Windows.Forms.Application.DoEvents();

			sql = "INSERT INTO HandheldVegReceive (HandHeldID,Handheld_Barcode,Quantity) VALUES (" + Convert.ToInt32(lblStockItemB.Tag) + ", 0, " + Convert.ToDecimal(txtQtyB.Text) + ")";
			modRecordSet.cnnDB.Execute(sql);
			System.Windows.Forms.Application.DoEvents();

			//---------------------------------------------
			modRecordSet.cnnDB.Execute("INSERT INTO StockGroup (StockGroup_Name) VALUES ('HandheldVegReceive')");
			modApplication.stTableName = "HandheldVegReceive";
			rj = modRecordSet.getRS(ref "SELECT StockGroup.StockGroupID, StockGroup.StockGroup_Name From StockGroup WHERE StockGroup.StockGroup_Name = 'HandheldVegReceive';");
			gID = rj.Fields("StockGroupID").Value;

			//snap shot
			modRecordSet.cnnDB.Execute("UPDATE Company SET Company.Company_StockTakeDate = now();");
			//Multi Warehouse change
			modRecordSet.cnnDB.Execute("DELETE FROM StockTake WHERE (StockTake_WarehouseID > 0)");
			modRecordSet.cnnDB.Execute("INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment ) SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, 0 AS quantity, 0 AS adjustment FROM WarehouseStockItemLnk;");
			modRecordSet.cnnDB.Execute("UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)>0));");
			//Multi Warehouse change
			// cnnDB.Execute "UPDATE StockTake SET StockTake.StockTake_Adjustment = [StockTake]![StockTake_Quantity];"
			modRecordSet.cnnDB.Execute("DELETE FROM StockTakeDeposit");
			modRecordSet.cnnDB.Execute("INSERT INTO StockTakeDeposit ( StockTakeDeposit_WarehouseID, StockTakeDeposit_DepositID, StockTakeDeposit_DepositTypeID, StockTakeDeposit_Quantity, StockTakeDeposit_Adjustment ) SELECT WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity FROM WarehouseDepositItemLnk INNER JOIN DISPLAY_Deposits ON (DISPLAY_Deposits.type = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = DISPLAY_Deposits.DepositID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID = DISPLAY_Deposits.WarehouseID);");
			//snap shot

			RSadoPrimary = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, " + modApplication.stTableName + ".Quantity, StockItem.StockItem_Quantity," + modApplication.stTableName + ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" + modApplication.stTableName + " INNER JOIN StockItem ON " + modApplication.stTableName + ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " + gID + ") And ((Warehouse.WarehouseID) = 2)) ORDER BY StockItem.StockItem_Name");
			if (RSadoPrimary.RecordCount > 0) {
				while (RSadoPrimary.EOF == false) {
					lQuantity = RSadoPrimary.Fields("Quantity").Value;
					modRecordSet.cnnDB.Execute("UPDATE StockTake SET StockTake.StockTake_Quantity = " + lQuantity + " WHERE (((StockTake.StockTake_StockItemID)=" + RSadoPrimary.Fields("StockTake_StockItemID").Value + ") AND ((StockTake.StockTake_WarehouseID)=2));");
					modRecordSet.cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" + lQuantity + ") WHERE (((StockTake.StockTake_StockItemID)=" + RSadoPrimary.Fields("StockTake_StockItemID").Value + ") AND ((StockTake.StockTake_WarehouseID)=2));");
					modRecordSet.cnnDB.Execute("UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" + lQuantity + ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" + RSadoPrimary.Fields("StockTake_StockItemID").Value + "));");
					RSadoPrimary.MoveNext();
				}
			}

			modRecordSet.cnnDB.Execute("DROP TABLE HandheldVegReceive;");
			modRecordSet.cnnDB.Execute("DELETE * FROM StockGroup WHERE StockGroup_Name ='HandheldVegReceive';");

			Interaction.MsgBox("Receiving Stock for Veg Production has been completed.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);

			functionReturnValue = true;
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
				Interaction.MsgBox("Insufficient Qty!");
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
	}
}
