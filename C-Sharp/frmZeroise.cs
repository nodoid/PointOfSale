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
namespace _4PosBackOffice.NET
{
	internal partial class frmZeroise : System.Windows.Forms.Form
	{
		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2487;
			//Zeroising Stock|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2488;
			//Please Enter the password to continue|checked
			if (modRecordSet.rsLang.RecordCount){lblHeading.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lblHeading.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2490;
			//Password|Checked
			if (modRecordSet.rsLang.RecordCount){Label2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmZeroise.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}


		private void frmZeroise_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			loadLanguage();
		}

		private void txtPassword_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			string dtDate = null;
			string dtMonth = null;
			string stPass = null;

			//Construct password...........
			if (KeyAscii == 13) {
				if (Strings.Len(DateAndTime.Day(DateAndTime.Today)) == 1)
					dtDate = "0" + Conversion.Str(DateAndTime.Day(DateAndTime.Today));
				else
					dtDate = Strings.Trim(Conversion.Str(DateAndTime.Day(DateAndTime.Today)));
				if (Strings.Len(DateAndTime.Month(DateAndTime.Today)) == 1)
					dtMonth = "0" + Conversion.Str(DateAndTime.Month(DateAndTime.Today));
				else
					dtMonth = Strings.Trim(Conversion.Str(DateAndTime.Month(DateAndTime.Today)));

				//Create password
				stPass = dtDate + "##" + dtMonth;
				stPass = Strings.Replace(stPass, " ", "");

				if (Strings.Trim(txtPassword.Text) == stPass) {
					//ZeroiseStock
					Update_Handheld();
				} else {
					Interaction.MsgBox("Incorrect password was entered!!!", MsgBoxStyle.Exclamation, "Incorrect Passwords");
				}

			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}


		public void ZeroiseStock()
		{
			ADODB.Recordset rj = default(ADODB.Recordset);
			ADODB.Recordset rs = default(ADODB.Recordset);

			rj = modRecordSet.getRS(ref "SELECT * FROM WarehouseStockItemLnk WHERE WarehouseStockItemLnk_WarehouseID > 0");

			if (rj.RecordCount > 0) {
				if (Interaction.MsgBox("You have " + rj.RecordCount + " entries in database. Do you want to make them Zero?", MsgBoxStyle.OkCancel) == MsgBoxResult.Ok) {
					modRecordSet.cnnDB.Execute("UPDATE WarehouseStockItemLnk SET WarehouseStockItemLnk_Quantity = 0 WHERE WarehouseStockItemLnk_WarehouseID > 0");
					Interaction.MsgBox("Stock process has been completed.");
				}
			} else {
				Interaction.MsgBox("You don't have any stock.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
			}
		}


		public void Update_Handheld()
		{
			int gID = 0;
			string strFldName = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rj = default(ADODB.Recordset);
			ADODB.Recordset adoPrimaryRS = default(ADODB.Recordset);
			string sql = null;
			decimal lQuantity = default(decimal);
			ADODB.Recordset rsWH = default(ADODB.Recordset);
			 // ERROR: Not supported in C#: OnErrorStatement

			rs = modRecordSet.getRS(ref "SELECT * from StockItem;");
			//Where (StockItem.StockItem_Disabled = False) And (StockItem.StockItem_Discontinued = False);")
			if (rs.RecordCount > 0) {
				if (Interaction.MsgBox("You have " + rs.RecordCount + " items in database. Do you want to make them Zero?", MsgBoxStyle.OkCancel) == MsgBoxResult.Ok) {
					errCreateAgain:
					strFldName = "HandHeldID Number,Handheld_Barcode Text(50), Quantity Currency";
					modRecordSet.cnnDB.Execute("CREATE TABLE " + "Handheld777" + " (" + strFldName + ")");
					System.Windows.Forms.Application.DoEvents();
					while (rs.EOF == false) {
						sql = "INSERT INTO Handheld777 (HandHeldID,Handheld_Barcode,Quantity) VALUES (" + rs.Fields("StockItemID").Value + ", 0, 0)";
						//sql = "INSERT INTO Handheld777 (HandHeldID,Handheld_Barcode,Quantity) SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID, 0 AS Barcode, WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity AS quantity FROM WarehouseStockItemLnk WHERE ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2);"
						modRecordSet.cnnDB.Execute(sql);
						rs.moveNext();
					}

				} else {
					return;
				}
			} else {
				Interaction.MsgBox("You don't have any stock.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				return;
			}
			modRecordSet.cnnDB.Execute("INSERT INTO StockGroup (StockGroup_Name) VALUES ('Handheld777')");
			modApplication.stTableName = "Handheld777";
			rj = modRecordSet.getRS(ref "SELECT StockGroup.StockGroupID, StockGroup.StockGroup_Name From StockGroup WHERE StockGroup.StockGroup_Name = 'Handheld777';");
			gID = rj.Fields("StockGroupID").Value;

			//snap shot
			//cnnDB.Execute "UPDATE Company SET Company.Company_StockTakeDate = now();"
			//cnnDB.Execute "DELETE FROM StockTake WHERE (StockTake_WarehouseID = 2)"
			//cnnDB.Execute "INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment ) SELECT StockItem.StockItemID, 2 AS warehouse, 0 AS quantity, 0 AS adjustment FROM StockItem;"
			//cnnDB.Execute "UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));"
			//cnnDB.Execute "DELETE FROM StockTakeDeposit"
			//cnnDB.Execute "INSERT INTO StockTakeDeposit ( StockTakeDeposit_WarehouseID, StockTakeDeposit_DepositID, StockTakeDeposit_DepositTypeID, StockTakeDeposit_Quantity, StockTakeDeposit_Adjustment ) SELECT WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity FROM WarehouseDepositItemLnk INNER JOIN DISPLAY_Deposits ON (DISPLAY_Deposits.type = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = DISPLAY_Deposits.DepositID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID = DISPLAY_Deposits.WarehouseID);"
			//snap shot
			//NEW snap shot
			modRecordSet.cnnDB.Execute("UPDATE Company SET Company.Company_StockTakeDate = now();");
			//Multi Warehouse change
			modRecordSet.cnnDB.Execute("DELETE FROM StockTake WHERE (StockTake_WarehouseID > 0)");
			modRecordSet.cnnDB.Execute("INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment ) SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, 0 AS quantity, 0 AS adjustment FROM WarehouseStockItemLnk;");
			modRecordSet.cnnDB.Execute("UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)>0));");
			//Multi Warehouse change
			modRecordSet.cnnDB.Execute("DELETE FROM StockTakeDeposit");
			modRecordSet.cnnDB.Execute("INSERT INTO StockTakeDeposit ( StockTakeDeposit_WarehouseID, StockTakeDeposit_DepositID, StockTakeDeposit_DepositTypeID, StockTakeDeposit_Quantity, StockTakeDeposit_Adjustment ) SELECT WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity FROM WarehouseDepositItemLnk INNER JOIN DISPLAY_Deposits ON (DISPLAY_Deposits.type = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = DISPLAY_Deposits.DepositID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID = DISPLAY_Deposits.WarehouseID);");
			//NEW snap shot

			rsWH = modRecordSet.getRS(ref "SELECT * from Warehouse;");
			if (rsWH.RecordCount > 0) {
				while (rsWH.EOF == false) {
					adoPrimaryRS = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, " + modApplication.stTableName + ".Quantity, StockItem.StockItem_Quantity," + modApplication.stTableName + ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" + modApplication.stTableName + " INNER JOIN StockItem ON " + modApplication.stTableName + ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " + gID + ") And ((Warehouse.WarehouseID) = " + rsWH.Fields("WarehouseID").Value + ")) ORDER BY StockItem.StockItem_Name");
					if (adoPrimaryRS.RecordCount > 0) {
						while (adoPrimaryRS.EOF == false) {
							lQuantity = adoPrimaryRS.Fields("Quantity").Value;
							lQuantity = adoPrimaryRS.Fields("Quantity").Value - adoPrimaryRS.Fields("StockTake_Quantity").OriginalValue;
							modRecordSet.cnnDB.Execute("UPDATE StockTake SET StockTake.StockTake_Quantity = " + lQuantity + " WHERE (((StockTake.StockTake_StockItemID)=" + adoPrimaryRS.Fields("StockTake_StockItemID").Value + ") AND ((StockTake.StockTake_WarehouseID)=" + rsWH.Fields("WarehouseID").Value + "));");
							//cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
							modRecordSet.cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = 0 WHERE (((StockTake.StockTake_StockItemID)=" + adoPrimaryRS.Fields("StockTake_StockItemID").Value + ") AND ((StockTake.StockTake_WarehouseID)=" + rsWH.Fields("WarehouseID").Value + "));");
							modRecordSet.cnnDB.Execute("UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" + lQuantity + ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" + adoPrimaryRS.Fields("StockTake_StockItemID").Value + ") AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" + rsWH.Fields("WarehouseID").Value + "));");
							adoPrimaryRS.moveNext();
						}
					}
					rsWH.moveNext();
				}
			}

			modRecordSet.cnnDB.Execute("DROP TABLE Handheld777");
			modRecordSet.cnnDB.Execute("DELETE * FROM StockGroup WHERE StockGroup_Name ='Handheld777'");

			Interaction.MsgBox("Stock process has been completed.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);

			return;
			Err_Update_Handheld:
			Debug.Print(Err().Description);
			if (Err().Description == "[Microsoft][ODBC Microsoft Access Driver] Table 'Handheld777' already exists.") {
				modRecordSet.cnnDB.Execute("DROP TABLE Handheld777");
				goto errCreateAgain;
			} else if (Err().Description == "Table 'Handheld777' already exists.") {
				modRecordSet.cnnDB.Execute("DROP TABLE Handheld777");
				goto errCreateAgain;
			} else {
				Interaction.MsgBox(Err().Description);
			}
		}
	}
}
