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
	internal partial class frmMakeRepairItem : System.Windows.Forms.Form
	{
		int gStockItemID;
		int gPromotionID;
		int gQuantity;
		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1255;
			//Make Finished Product|Checked
			if (modRecordSet.rsLang.RecordCount){My.MyProject.Forms.frmMakeFinishItem.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;My.MyProject.Forms.frmMakeFinishItem.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lblPComp = No Code     [Please enter the Qty you wish to make]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblPComp.Caption = rsLang("LanguageLayoutLnk_Description"): lblPComp.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1935;
			//Stock Item Name|Checked
			if (modRecordSet.rsLang.RecordCount){_LBL_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_LBL_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lbl_2 = No Code       [Item Qty]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1151;
			//Price|Checked
			if (modRecordSet.rsLang.RecordCount){_LBL_3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_LBL_3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmMakeRepairItem.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public void makeItem()
		{
			int lID = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);

			lID = My.MyProject.Forms.frmStockList.getItem();
			if (lID != 0) {
				 // ERROR: Not supported in C#: OnErrorStatement

				loadItem(lID);
				//adoPrimaryRS("PromotionID"), lID
			}
		}
		private void loadData()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rj = default(ADODB.Recordset);

			rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + gStockItemID + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));");
			if (rs.RecordCount) {
				lblStockItem.Text = rs.Fields("StockItem_Name").Value;
				//lblPromotion.Caption = rs("Promotion_Name")
				txtPrice.Text = Convert.ToString(rs.Fields("CatalogueChannelLnk_Price").Value * 100);
				txtPrice_Leave(txtPrice, new System.EventArgs());
				//cmbQuantity.Tag = rs("CatalogueChannelLnk_Quantity")

				loadLanguage();
				ShowDialog();
			} else {
				this.Close();
				return;
			}

		}

//Public Sub loadItem(promotionID As Long, stockitemID As Long, Optional quantity As Long)
		public void loadItem(ref int stockitemID, ref int quantity = 0)
		{
			gStockItemID = stockitemID;
			//gPromotionID = promotionID
			gQuantity = quantity;
			//lblPComp.Caption = frmStockTransfer.lblPComp.Caption
			loadData();

			//show 1

		}
		private void frmMakeRepairItem_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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
			this.Close();
		}

//UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private bool update_Renamed()
		{
			bool functionReturnValue = false;
			int gID = 0;
			string strFldName = null;
			 // ERROR: Not supported in C#: OnErrorStatement


			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rj = default(ADODB.Recordset);
			ADODB.Recordset adoPrimaryRS = default(ADODB.Recordset);
			string sql = null;
			decimal lQuantity = default(decimal);
			// Long

			rs = modRecordSet.getRS(ref "SELECT * from RecipeStockitemLnk Where RecipeStockitemLnk_RecipeID = " + gStockItemID + ";");
			if (rs.RecordCount > 0) {
				//If MsgBox("You have " & rs.RecordCount & " enabled items in database. Do you want to make them Zero?", vbOKCancel) = vbOK Then

				strFldName = "HandHeldID Number,Handheld_Barcode Text(50), Quantity Currency";
				modRecordSet.cnnDB.Execute("CREATE TABLE " + "HandheldMakeFinish" + " (" + strFldName + ")");
				System.Windows.Forms.Application.DoEvents();
				sql = "INSERT INTO HandheldMakeFinish (HandHeldID,Handheld_Barcode,Quantity) VALUES (" + gStockItemID + ", 0, " + Convert.ToDecimal(txtQty.Text) + ")";
				modRecordSet.cnnDB.Execute(sql);
				System.Windows.Forms.Application.DoEvents();

				while (rs.EOF == false) {
					sql = "INSERT INTO HandheldMakeFinish (HandHeldID,Handheld_Barcode,Quantity) VALUES (" + rs.Fields("RecipeStockitemLnk_StockitemID").Value + ", 0, " + (0 - (rs.Fields("RecipeStockitemLnk_Quantity").Value * Convert.ToDecimal(txtQty.Text))) + ")";
					modRecordSet.cnnDB.Execute(sql);
					rs.moveNext();
				}

				//Else
				//    Exit Sub
				//End If
			} else {
				Interaction.MsgBox("This Product does not have any Recipe.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				return functionReturnValue;
			}
			modRecordSet.cnnDB.Execute("INSERT INTO StockGroup (StockGroup_Name) VALUES ('HandheldMakeFinish')");
			modApplication.stTableName = "HandheldMakeFinish";
			rj = modRecordSet.getRS(ref "SELECT StockGroup.StockGroupID, StockGroup.StockGroup_Name From StockGroup WHERE StockGroup.StockGroup_Name = 'HandheldMakeFinish';");
			gID = rj.Fields("StockGroupID").Value;

			//snap shot
			modRecordSet.cnnDB.Execute("UPDATE Company SET Company.Company_StockTakeDate = now();");
			modRecordSet.cnnDB.Execute("DELETE FROM StockTake WHERE (StockTake_WarehouseID = 2)");
			modRecordSet.cnnDB.Execute("INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment ) SELECT StockItem.StockItemID, 2 AS warehouse, 0 AS quantity, 0 AS adjustment FROM StockItem;");
			modRecordSet.cnnDB.Execute("UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));");
			modRecordSet.cnnDB.Execute("DELETE FROM StockTakeDeposit");
			modRecordSet.cnnDB.Execute("INSERT INTO StockTakeDeposit ( StockTakeDeposit_WarehouseID, StockTakeDeposit_DepositID, StockTakeDeposit_DepositTypeID, StockTakeDeposit_Quantity, StockTakeDeposit_Adjustment ) SELECT WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity FROM WarehouseDepositItemLnk INNER JOIN DISPLAY_Deposits ON (DISPLAY_Deposits.type = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = DISPLAY_Deposits.DepositID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID = DISPLAY_Deposits.WarehouseID);");
			//snap shot

			//Set adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, " & stTableName & ".Quantity, StockItem.StockItem_Quantity," & stTableName & ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" & stTableName & " INNER JOIN StockItem ON " & stTableName & ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " & gID & ") And ((Warehouse.WarehouseID) = 2) And ((StockItem.StockItem_Disabled) = False) And ((StockItem.StockItem_Discontinued) = False)) ORDER BY StockItem.StockItem_Name")
			adoPrimaryRS = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, " + modApplication.stTableName + ".Quantity, StockItem.StockItem_Quantity," + modApplication.stTableName + ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" + modApplication.stTableName + " INNER JOIN StockItem ON " + modApplication.stTableName + ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " + gID + ") And ((Warehouse.WarehouseID) = 2)) ORDER BY StockItem.StockItem_Name");
			if (adoPrimaryRS.RecordCount > 0) {
				while (adoPrimaryRS.EOF == false) {
					lQuantity = adoPrimaryRS.Fields("Quantity").Value;
					//lQuantity = adoPrimaryRS("Quantity") - adoPrimaryRS("StockTake_Quantity").OriginalValue
					modRecordSet.cnnDB.Execute("UPDATE StockTake SET StockTake.StockTake_Quantity = " + lQuantity + " WHERE (((StockTake.StockTake_StockItemID)=" + adoPrimaryRS.Fields("StockTake_StockItemID").Value + ") AND ((StockTake.StockTake_WarehouseID)=2));");
					modRecordSet.cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" + lQuantity + ") WHERE (((StockTake.StockTake_StockItemID)=" + adoPrimaryRS.Fields("StockTake_StockItemID").Value + ") AND ((StockTake.StockTake_WarehouseID)=2));");
					//cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = 0 WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
					modRecordSet.cnnDB.Execute("UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" + lQuantity + ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" + adoPrimaryRS.Fields("StockTake_StockItemID").Value + "));");
					adoPrimaryRS.moveNext();
				}
			}

			modRecordSet.cnnDB.Execute("DROP TABLE HandheldMakeFinish");
			modRecordSet.cnnDB.Execute("DELETE * FROM StockGroup WHERE StockGroup_Name ='HandheldMakeFinish'");
			Interaction.MsgBox("Make Finished Product process has been completed.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);


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
				txtQty.Focus();
				return;
			}

			if (Convert.ToDecimal(txtQtyTaken.Text) > 0) {
			} else {
				txtQtyTaken.Focus();
				return;
			}

			if (Convert.ToDecimal(txtQty.Text) > Convert.ToDecimal(txtQtyTaken.Text)) {
				Interaction.MsgBox("Cannot make more then taken Qty.");
				txtQtyTaken.Focus();
				return;
			}

			if (updateProc()) {
				this.Close();
			}
		}

		private bool updateProc()
		{
			bool functionReturnValue = false;
			decimal AsHoldOriginal = default(decimal);
			int gID = 0;
			string strFldName = null;
			 // ERROR: Not supported in C#: OnErrorStatement


			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rj = default(ADODB.Recordset);
			ADODB.Recordset RSadoPrimary = default(ADODB.Recordset);
			ADODB.Recordset rsBarcode = default(ADODB.Recordset);
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			string sql = null;
			decimal lQuantity = default(decimal);
			int getNewID = 0;

			//Set rs = getRS("SELECT VegTestItem.*, StockItem.StockItemID, StockItem.StockItem_SBarcode FROM VegTestItem INNER JOIN StockItem ON VegTestItem.VegTestItem_StockItemID = StockItem.StockItemID WHERE (((VegTestItem.VegTestItem_VegTestID)=" & testID & "));")
			//If rs.RecordCount > 0 Then
			strFldName = "HandHeldID Number,Handheld_Barcode Text(50), Quantity Currency";
			modRecordSet.cnnDB.Execute("CREATE TABLE " + "HandheldVegTest" + " (" + strFldName + ")");
			System.Windows.Forms.Application.DoEvents();
			sql = "INSERT INTO HandheldVegTest (HandHeldID,Handheld_Barcode,Quantity) VALUES (" + gStockItemID + ", 0, " + (0 - (Convert.ToDecimal(txtQtyTaken.Text) - Convert.ToDecimal(txtQty.Text))) + ")";
			modRecordSet.cnnDB.Execute(sql);
			System.Windows.Forms.Application.DoEvents();
			//       Do While rs.EOF = False
			//           If rs("VegTestItem_PerWeightYield") > 0 Then
			//               getNewID = 0
			//               If rs("StockItem_SBarcode") = True Then
			//                   getNewID = rs("VegTestItem_StockItemID")
			//                   'create new
			//                   'CreateVegItems rs("VegTestItem_StockItemID"), rs("VegTestItem_ActualSellPriceIncl"), rs("VegTestItem_PackSize"), getNewID   ' csvSplit(0), csvSplit(1), csvSplit(2), CCur(csvSplit(3)), CCur(csvSplit(4)), csvSplit(6), csvSplit(7)
			//               Else
			//                   getNewID = rs("VegTestItem_StockItemID")
			//               End If
			//               'Stock Adjustment
			//               sql = "INSERT INTO HandheldVegTest (HandHeldID,Handheld_Barcode,Quantity) VALUES (" & getNewID & ", 0, " & (rs("VegTestItem_PerWeightYield")) & ")"
			//               cnnDB.Execute sql
			//           End If
			//           rs.moveNext
			//       Loop
			//Else
			//   MsgBox "This Product does not have any Recipe.", vbApplicationModal + vbInformation + vbOKOnly, App.title
			//   Exit Function
			//End If

			//---------------------------------------------
			modRecordSet.cnnDB.Execute("INSERT INTO StockGroup (StockGroup_Name) VALUES ('HandheldVegTest')");
			modApplication.stTableName = "HandheldVegTest";
			rj = modRecordSet.getRS(ref "SELECT StockGroup.StockGroupID, StockGroup.StockGroup_Name From StockGroup WHERE StockGroup.StockGroup_Name = 'HandheldVegTest';");
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

					AsHoldOriginal = RSadoPrimary.Fields("StockTake_Adjustment").Value;
					//Setting the StockTake_Adjustment to it's original value
					RSadoPrimary.Fields("StockTake_Adjustment").Value = 0;
					lQuantity = AsHoldOriginal + RSadoPrimary.Fields("StockTake_Quantity").OriginalValue;

					lQuantity = RSadoPrimary.Fields("Quantity").Value;

					lQuantity = RSadoPrimary.Fields("Quantity").Value + RSadoPrimary.Fields("StockTake_Quantity").OriginalValue;

					modRecordSet.cnnDB.Execute("INSERT INTO StockTakeDetail ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment, StockTake_DayEndID, StockTake_Note, StockTake_DateTime ) SELECT " + RSadoPrimary.Fields("StockTake_StockItemID").Value + ", 2, " + lQuantity + ", " + RSadoPrimary.Fields("Quantity").Value + ", Company_DayEndID, '" + "4VEG Repair" + " ', #" + DateAndTime.Now + "# FROM Company;");

					modRecordSet.cnnDB.Execute("UPDATE StockTake SET StockTake.StockTake_Quantity = " + lQuantity + " WHERE (((StockTake.StockTake_StockItemID)=" + RSadoPrimary.Fields("StockTake_StockItemID").Value + ") AND ((StockTake.StockTake_WarehouseID)=2));");
					//cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]-(" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & RSadoPrimary("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
					modRecordSet.cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = " + lQuantity + " WHERE (((StockTake.StockTake_StockItemID)=" + RSadoPrimary.Fields("StockTake_StockItemID").Value + ") AND ((StockTake.StockTake_WarehouseID)=2));");
					//cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = 0 WHERE (((StockTake.StockTake_StockItemID)=" & RSadoPrimary("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
					modRecordSet.cnnDB.Execute("UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" + RSadoPrimary.Fields("Quantity").Value + ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" + RSadoPrimary.Fields("StockTake_StockItemID").Value + "));");
					RSadoPrimary.moveNext();
				}
			}

			//Update POS
			//Set rsPri = getRS("SELECT GRVItem.GRVItem_StockItemID, (GRVItem.GRVItem_Quantity*GRVItem_PackSize) AS GRVItem_Quantity, StockItem.StockItem_SBarcode,StockItem.StockItem_SShelf FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE GRVItem_GRVID = " & Val(frmGRV.adoPrimaryRS("GRVID")) & " AND (StockItem_SBarcode = True Or StockItem_SShelf = True)")
			//Set rsBarcode = getRS("SELECT HandheldVegTest.HandHeldID AS GRVItem_StockItemID, HandheldVegTest.Quantity AS GRVItem_Quantity, StockItem.StockItem_SBarcode, StockItem.StockItem_SShelf FROM HandheldVegTest INNER JOIN StockItem ON HandheldVegTest.HandHeldID = StockItem.StockItemID WHERE (((HandheldVegTest.Quantity)>0));")
			rsBarcode = modRecordSet.getRS(ref "SELECT HandheldVegTest.HandHeldID AS GRVItem_StockItemID, " + Convert.ToDecimal(txtQty.Text) + " AS GRVItem_Quantity, StockItem.StockItem_SBarcode, StockItem.StockItem_SShelf FROM HandheldVegTest INNER JOIN StockItem ON HandheldVegTest.HandHeldID = StockItem.StockItemID WHERE (((HandheldVegTest.Quantity)<>0) AND ((StockItem.StockItem_SBarcode)=True)) OR (((StockItem.StockItem_SShelf)=True));");
			//Write file
			if (rsBarcode.RecordCount) {
				if (fso.FileExists(modRecordSet.serverPath + "ShelfBarcode.dat"))
					fso.DeleteFile(modRecordSet.serverPath + "ShelfBarcode.dat", true);
				rsBarcode.save(modRecordSet.serverPath + "ShelfBarcode.dat", ADODB.PersistFormatEnum.adPersistADTG);
				modApplication.grvPrin = true;
				//If MsgBox("Do you want to do Shelf/Barcode Printing on flagged StockItems?", vbQuestion + vbYesNo + vbApplicationModal + vbDefaultButton1, App.title) = vbYes Then

				modApplication.blMEndUpdatePOS = true;
				modApplication.blChangeOnlyUpdatePOS = true;
				My.MyProject.Forms.frmUpdatePOScriteria.ShowDialog();
				modApplication.blChangeOnlyUpdatePOS = false;
				modApplication.blMEndUpdatePOS = false;

				My.MyProject.Forms.frmBarcode.ShowDialog();
			}

			modRecordSet.cnnDB.Execute("DROP TABLE HandheldVegTest");
			modRecordSet.cnnDB.Execute("DELETE * FROM StockGroup WHERE StockGroup_Name ='HandheldVegTest'");
			//cnnDB.Execute "UPDATE VegTest SET VegTest_VegTestStatusID = 3 WHERE (VegTestID = " & testID & ")"
			//cnnDB.Execute "UPDATE VegTest INNER JOIN GRVItem ON (VegTest.VegTest_GRVID = GRVItem.GRVItem_GRVID) AND (VegTest.VegTest_MainItemID = GRVItem.GRVItem_StockItemID) SET GRVItem.GRVItem_QuantityUsedKG = " & CCur(TotalQTY.Text) & " WHERE (((VegTest.VegTestID)=" & testID & "));"

			Interaction.MsgBox("Repair process has been completed.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
			functionReturnValue = true;
			return functionReturnValue;
			UpdateErr:

			Interaction.MsgBox(Err().Description);
			 // ERROR: Not supported in C#: ResumeStatement

			return functionReturnValue;
			//updateProc = True
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

		private void txtPrice_MyGotFocus(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtPrice);
		}

		private void txtPrice_MyLostFocus(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtPrice, ref 2);
		}

		private void txtQty_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtQty);
		}

		private void txtQty_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			modUtilities.MyKeyPress(ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtQty_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtQty, ref 0);
		}

		private void txtQtyTaken_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtQtyTaken);
		}

		private void txtQtyTaken_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			modUtilities.MyKeyPress(ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtQtyTaken_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtQtyTaken, ref 0);
		}


		private void frmMakeRepairItem_Load(object sender, System.EventArgs e)
		{
		}
	}
}
