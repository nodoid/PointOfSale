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
using VB = Microsoft.VisualBasic;
using Microsoft.VisualBasic.PowerPacks;
namespace _4PosBackOffice.NET
{
	internal partial class frmMakeFinishItem : System.Windows.Forms.Form
	{
		int gStockItemID;
		int gPromotionID;
		int gQuantity;
		bool bApplyChk;

		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1255;
			//Make Finished Product|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

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
			//UPGRADE_ISSUE: Form property frmMakeFinishItem.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public void makeItem()
		{
			int lID = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);

			bApplyChk = false;
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

			rs = modRecordSet.getRS(ref "SELECT Company_MakeFinishSaleChk FROM Company;");
			if (rs.RecordCount) {
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (Information.IsDBNull(rs.Fields("Company_MakeFinishSaleChk").Value)) {
				} else {
					if (rs.Fields("Company_MakeFinishSaleChk").Value) {
						bApplyChk = true;
					}
				}
			}

			rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, StockItem_MakeFinishItem, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + gStockItemID + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));");
			if (rs.RecordCount) {
				lblStockItem.Text = rs.Fields("StockItem_Name").Value;
				//lblPromotion.Caption = rs("Promotion_Name")
				txtPrice.Text = Convert.ToString(rs.Fields("CatalogueChannelLnk_Price").Value * 100);
				txtPrice_Leave(txtPrice, new System.EventArgs());
				//cmbQuantity.Tag = rs("CatalogueChannelLnk_Quantity")

				if (bApplyChk) {
					//sales qty
					if (rs.Fields("StockItem_MakeFinishItem").Value == 1) {
						lblSaleQty.ForeColor = System.Drawing.Color.Red;
						lblSaleQty.Text = "Option only allowed once per Day End.";
						chkSaleQTY.Enabled = false;
					} else {
						lblSaleQty.ForeColor = System.Drawing.Color.Black;
						lblSaleQty.Text = "[ 0 ]";
						chkSaleQTY.Enabled = true;
						//Set rs = getRS("SELECT SUM(SaleItem.SaleItem_Quantity*SaleItem.SaleItem_ShrinkQuantity) as tQTY from SaleItem WHERE (((SaleItem.SaleItem_StockItemID)=" & gStockItemID & "));")
						rs = modRecordSet.getRS(ref "SELECT Sum(SaleItem.SaleItem_Quantity*SaleItem.SaleItem_ShrinkQuantity) AS tQTY FROM Company INNER JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON Company.Company_DayEndID = Sale.Sale_DayEndID WHERE (((SaleItem.SaleItem_StockItemID)=" + gStockItemID + "));");
						if (rs.RecordCount) {
							//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
							if (Information.IsDBNull(rs.Fields("tQTY").Value)) {
								lblSaleQty.Text = "[ 0 ]";
							} else {
								lblSaleQty.Text = "[ " + rs.Fields("tQTY").Value + " ]";
							}
						}
					}
				} else {
					lblSaleQty.Visible = false;
					chkSaleQTY.Visible = false;
				}

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
		private void frmMakeFinishItem_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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
			string strIn = null;
			int y = 0;
			string[] arrBOMDetail = null;
			string arrBOMMaster = null;
			int x = 0;
			string strFldName = null;
			string cTemp = null;
			 // ERROR: Not supported in C#: OnErrorStatement


			ADODB.Recordset rWHs = default(ADODB.Recordset);
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rj = default(ADODB.Recordset);
			ADODB.Recordset adoPrimaryRS = default(ADODB.Recordset);
			string sql = null;
			decimal lQuantity = default(decimal);
			// Long
			decimal saleQTY = default(decimal);

			if (bApplyChk) {
				if (lblSaleQty.Text == "Option only allowed once per Day End.") {
					saleQTY = 0;
				} else if (chkSaleQTY.Enabled == false) {
				} else {
					if (lblSaleQty.Text != "[ 0 ]") {
						cTemp = Strings.Replace(lblSaleQty.Text, "[", "");
						cTemp = Strings.Replace(cTemp, "]", "");
						cTemp = Strings.Replace(cTemp, " ", "");
						saleQTY = Convert.ToDecimal(cTemp);
					}
				}
			}

			rs = modRecordSet.getRS(ref "SELECT * from RecipeStockitemLnk Where RecipeStockitemLnk_RecipeID = " + gStockItemID + ";");
			if (rs.RecordCount > 0) {
				//If MsgBox("You have " & rs.RecordCount & " enabled items in database. Do you want to make them Zero?", vbOKCancel) = vbOK Then

				if (chkSaleQTY.CheckState == 1) {
					if (Convert.ToDecimal(txtQty.Text) <= saleQTY) {
						Interaction.MsgBox("Make QTY should be bigger then Sale QTY when 'Apply Sales Qty' option is selected.");
						return functionReturnValue;
					}

					if (Interaction.MsgBox("You have entered '" + Convert.ToDecimal(txtQty.Text) + "' unit(s) to make and you already sold '" + saleQTY + "' for current day." + Constants.vbCrLf + Constants.vbCrLf + "You have selected 'Apply Sales Qty'. Do you wish to make '" + System.Math.Abs(Convert.ToDecimal(txtQty.Text) - saleQTY) + "' unit(s)?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes) {
						txtQty.Text = Convert.ToString(System.Math.Abs(Convert.ToDecimal(txtQty.Text) - saleQTY));
					} else {
						return functionReturnValue;
					}
				}

				strFldName = "HandHeldID Number,Handheld_Barcode Currency, Quantity Currency";
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

			for (x = 1; x <= 5; x++) {
				rs = modRecordSet.getRS(ref "SELECT RecipeStockitemLnk.RecipeStockitemLnk_RecipeID FROM HandheldMakeFinish INNER JOIN RecipeStockitemLnk ON HandheldMakeFinish.HandHeldID = RecipeStockitemLnk.RecipeStockitemLnk_RecipeID Where (((HandheldMakeFinish.quantity) < 0)) GROUP BY RecipeStockitemLnk.RecipeStockitemLnk_RecipeID;");
				if (rs.RecordCount > 0) {
					arrBOMMaster = "";
					while (rs.EOF == false) {
						rWHs = modRecordSet.getRS(ref "SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS Warehouse_StockItemQuantity, Sum(HandheldMakeFinish.Quantity) AS SumOfQuantity FROM WarehouseStockItemLnk INNER JOIN HandheldMakeFinish ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = HandheldMakeFinish.HandHeldID Where (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) = 2)) GROUP BY WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID HAVING (((WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID)=" + rs.Fields("RecipeStockitemLnk_RecipeID").Value + "));");
						if (rWHs.Fields("Warehouse_StockItemQuantity").Value > 0) {
							if (rWHs.Fields("Warehouse_StockItemQuantity").Value >= (0 - rWHs.Fields("SumOfQuantity").Value)) {
								sql = "UPDATE HandheldMakeFinish SET Handheld_Barcode=" + rWHs.Fields("SumOfQuantity").Value + ", Quantity=0 WHERE HandHeldID = " + rs.Fields("RecipeStockitemLnk_RecipeID").Value + ";";
								modRecordSet.cnnDB.Execute(sql);
								System.Windows.Forms.Application.DoEvents();
							} else {
								sql = "UPDATE HandheldMakeFinish SET Handheld_Barcode=" + (0 - rWHs.Fields("Warehouse_StockItemQuantity").Value) + ", Quantity=" + (rWHs.Fields("Warehouse_StockItemQuantity").Value + rWHs.Fields("SumOfQuantity").Value) + " WHERE HandHeldID = " + rs.Fields("RecipeStockitemLnk_RecipeID").Value + ";";
								modRecordSet.cnnDB.Execute(sql);
								System.Windows.Forms.Application.DoEvents();
								arrBOMMaster = arrBOMMaster + rs.Fields("RecipeStockitemLnk_RecipeID").Value + ",";
							}
						} else {
							arrBOMMaster = arrBOMMaster + rs.Fields("RecipeStockitemLnk_RecipeID").Value + ",";
						}
						rs.moveNext();
					}
					if (!string.IsNullOrEmpty(arrBOMMaster))
						arrBOMMaster = Strings.Left(arrBOMMaster, Strings.Len(arrBOMMaster) - 1);
				}

				rs = modRecordSet.getRS(ref "SELECT RecipeStockitemLnk.*, HandheldMakeFinish.Quantity FROM HandheldMakeFinish INNER JOIN RecipeStockitemLnk ON HandheldMakeFinish.HandHeldID = RecipeStockitemLnk.RecipeStockitemLnk_RecipeID WHERE (((HandheldMakeFinish.Quantity)<0));");
				if (rs.RecordCount > 0) {
					while (rs.EOF == false) {
						sql = "INSERT INTO HandheldMakeFinish (HandHeldID,Handheld_Barcode,Quantity) VALUES (" + rs.Fields("RecipeStockitemLnk_StockitemID").Value + ", 0, " + ((rs.Fields("RecipeStockitemLnk_Quantity").Value * rs.Fields("Quantity").Value)) + ")";
						modRecordSet.cnnDB.Execute(sql);
						rs.moveNext();
					}

					arrBOMDetail = Strings.Split(arrBOMMaster, ",");
					for (y = 0; y <= Information.UBound(arrBOMDetail); y++) {
						sql = "UPDATE HandheldMakeFinish SET Quantity=0 WHERE HandHeldID = " + Convert.ToInt32(arrBOMDetail[y]) + ";";
						modRecordSet.cnnDB.Execute(sql);
						System.Windows.Forms.Application.DoEvents();
					}
				}
			}
			sql = "UPDATE HandheldMakeFinish SET Quantity=Handheld_Barcode WHERE Handheld_Barcode<>0;";
			modRecordSet.cnnDB.Execute(sql);
			System.Windows.Forms.Application.DoEvents();
			sql = "UPDATE HandheldMakeFinish SET Handheld_Barcode=0 WHERE Handheld_Barcode<>0;";
			modRecordSet.cnnDB.Execute(sql);
			System.Windows.Forms.Application.DoEvents();

			//chkDuplicate:
			strFldName = "HandHeldID Number,Handheld_Barcode Currency, Quantity Currency";
			modRecordSet.cnnDB.Execute("CREATE TABLE " + "Handheld777" + " (" + strFldName + ")");
			System.Windows.Forms.Application.DoEvents();

			rj = modRecordSet.getRS(ref "SELECT * FROM HandheldMakeFinish;");
			while (rj.EOF == false) {

				if (Information.IsDBNull(rj.Fields("HandHeldID").Value)) {
				} else {
					rs = modRecordSet.getRS(ref "SELECT * FROM Handheld777 WHERE HandHeldID=" + rj.Fields("HandHeldID").Value + ";");
					if (rs.RecordCount > 0) {
						strIn = "UPDATE Handheld777 SET Quantity = " + (rs.Fields("Quantity").Value + rj.Fields("Quantity").Value) + " WHERE HandHeldID=" + rj.Fields("HandHeldID").Value + ";";
					} else {
						strIn = "INSERT INTO Handheld777 (HandHeldID,Handheld_Barcode,Quantity) VALUES (" + rj.Fields("HandHeldID").Value + ", 0, " + rj.Fields("Quantity").Value + ")";
					}
					modRecordSet.cnnDB.Execute(strIn);
				}
				rj.moveNext();
			}

			modRecordSet.cnnDB.Execute("DELETE * FROM HandheldMakeFinish;");
			modRecordSet.cnnDB.Execute("INSERT INTO HandheldMakeFinish SELECT * FROM Handheld777;");
			modRecordSet.cnnDB.Execute("DROP TABLE Handheld777;");
			//chkDuplicate:

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

			modRecordSet.cnnDB.Execute("UPDATE StockItem SET StockItem.StockItem_MakeFinishItem = 1 WHERE StockItemID=" + gStockItemID + ";");
			modRecordSet.cnnDB.Execute("DROP TABLE HandheldMakeFinish");
			modRecordSet.cnnDB.Execute("DELETE * FROM StockGroup WHERE StockGroup_Name ='HandheldMakeFinish'");
			Interaction.MsgBox("Make Finished Product process has been completed.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);


			functionReturnValue = true;
			return functionReturnValue;
			UpdateErr:

			Interaction.MsgBox(Err().Description);
			functionReturnValue = true;
			 // ERROR: Not supported in C#: ResumeStatement

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

		private void txtPriceS_MyGotFocus()
		{
			object txtPriceS = null;
			modUtilities.MyGotFocusNumeric(ref txtPriceS);
		}

		private void txtPriceS_MyLostFocus()
		{
			object txtPriceS = null;
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
