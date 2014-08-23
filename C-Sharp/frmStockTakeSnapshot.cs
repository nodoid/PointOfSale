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
	internal partial class frmStockTakeSnapshot : System.Windows.Forms.Form
	{
		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1215;
			//Stock Take Snapshot|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lblInstruction = No Code   [The "Create Theoretical Stock Take Snapshot" process.......]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblInstruction.Caption = rsLang("LanguageLayoutLnk_Description"): lblInstruction.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lbl = No Code              [Please note that.......]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lbl.Caption = rsLang("LanguageLayoutLnk_Description"): lbl.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1217;
			//Proceed|Checked
			if (modRecordSet.rsLang.RecordCount){cmdProceed.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdProceed.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmStockTakeSnapshot.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public void remoteSnapShot()
		{
			Timer1.Enabled = true;
			ShowDialog();
		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}
		private void cmdProceed_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.cmdExit.Enabled = false;
			this.cmdProceed.Visible = false;
			lblInstruction.Text = "Busy updating ..." + Constants.vbCrLf + Constants.vbCrLf + "Please be patient.";
			lbl.Visible = false;
			System.Windows.Forms.Application.DoEvents();
			modRecordSet.cnnDB.Execute("UPDATE Company SET Company.Company_StockTakeDate = now();");
			//Multi Warehouse change
			//cnnDB.Execute "DELETE FROM StockTake WHERE (StockTake_WarehouseID = 2)"
			//cnnDB.Execute "INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment ) SELECT StockItem.StockItemID, 2 AS warehouse, 0 AS quantity, 0 AS adjustment FROM StockItem;"
			//cnnDB.Execute "UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));"
			modRecordSet.cnnDB.Execute("DELETE FROM StockTake WHERE (StockTake_WarehouseID > 0)");
			//changed below 2 lines for StockTake Print Difference
			modRecordSet.cnnDB.Execute("INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment, StockTake_QuantityOrig ) SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, 0 AS quantity, 0 AS adjustment, 0 AS quantityOrig FROM WarehouseStockItemLnk;");
			modRecordSet.cnnDB.Execute("UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity], StockTake.StockTake_QuantityOrig = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)>0));");
			//Multi Warehouse change
			// cnnDB.Execute "UPDATE StockTake SET StockTake.StockTake_Adjustment = [StockTake]![StockTake_Quantity];"
			modRecordSet.cnnDB.Execute("DELETE FROM StockTakeDeposit");
			modRecordSet.cnnDB.Execute("INSERT INTO StockTakeDeposit ( StockTakeDeposit_WarehouseID, StockTakeDeposit_DepositID, StockTakeDeposit_DepositTypeID, StockTakeDeposit_Quantity, StockTakeDeposit_Adjustment ) SELECT WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity FROM WarehouseDepositItemLnk INNER JOIN DISPLAY_Deposits ON (DISPLAY_Deposits.type = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = DISPLAY_Deposits.DepositID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID = DISPLAY_Deposits.WarehouseID);");
			lblInstruction.Text = "Your 'Theoretical Stock Snapshot' has been created.";
			this.cmdExit.Enabled = true;
			cmdExit.Focus();
		}
		private void frmStockTakeSnapshot_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 27) {
				KeyAscii = 0;
				this.Close();
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmStockTakeSnapshot_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			loadLanguage();
		}

		private void Timer1_Tick(System.Object eventSender, System.EventArgs eventArgs)
		{
			Timer1.Enabled = false;
			System.Windows.Forms.Application.DoEvents();

			this.cmdExit.Enabled = false;
			this.cmdProceed.Visible = false;
			lblInstruction.Text = "Busy updating ..." + Constants.vbCrLf + Constants.vbCrLf + "Please be patient.";
			lbl.Visible = false;
			System.Windows.Forms.Application.DoEvents();
			modRecordSet.cnnDB.Execute("UPDATE Company SET Company.Company_StockTakeDate = now();");
			//Multi Warehouse change
			//cnnDB.Execute "DELETE FROM StockTake WHERE (StockTake_WarehouseID = 2)"
			//cnnDB.Execute "INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment ) SELECT StockItem.StockItemID, 2 AS warehouse, 0 AS quantity, 0 AS adjustment FROM StockItem;"
			//cnnDB.Execute "UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));"
			modRecordSet.cnnDB.Execute("DELETE FROM StockTake WHERE (StockTake_WarehouseID > 0)");
			//changed below 2 lines for StockTake Print Difference
			modRecordSet.cnnDB.Execute("INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment, StockTake_QuantityOrig ) SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, 0 AS quantity, 0 AS adjustment, 0 AS quantityOrig FROM WarehouseStockItemLnk;");
			modRecordSet.cnnDB.Execute("UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity], StockTake.StockTake_QuantityOrig = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)>0));");
			//Multi Warehouse change
			// cnnDB.Execute "UPDATE StockTake SET StockTake.StockTake_Adjustment = [StockTake]![StockTake_Quantity];"
			modRecordSet.cnnDB.Execute("DELETE FROM StockTakeDeposit");
			modRecordSet.cnnDB.Execute("INSERT INTO StockTakeDeposit ( StockTakeDeposit_WarehouseID, StockTakeDeposit_DepositID, StockTakeDeposit_DepositTypeID, StockTakeDeposit_Quantity, StockTakeDeposit_Adjustment ) SELECT WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity FROM WarehouseDepositItemLnk INNER JOIN DISPLAY_Deposits ON (DISPLAY_Deposits.type = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = DISPLAY_Deposits.DepositID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID = DISPLAY_Deposits.WarehouseID);");
			lblInstruction.Text = "Your 'Theoretical Stock Snapshot' has been created.";
			this.cmdExit.Enabled = true;
			cmdExit.Focus();

			this.Close();
		}
	}
}
