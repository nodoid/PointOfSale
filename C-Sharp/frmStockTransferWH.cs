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
	internal partial class frmStockTransferWH : System.Windows.Forms.Form
	{
		private ADODB.Recordset withEventsField_adoPrimaryRS;
		public ADODB.Recordset adoPrimaryRS {
			get { return withEventsField_adoPrimaryRS; }
			set {
				if (withEventsField_adoPrimaryRS != null) {
					withEventsField_adoPrimaryRS.MoveComplete -= adoPrimaryRS_MoveComplete;
					withEventsField_adoPrimaryRS.WillChangeRecord -= adoPrimaryRS_WillChangeRecord;
				}
				withEventsField_adoPrimaryRS = value;
				if (withEventsField_adoPrimaryRS != null) {
					withEventsField_adoPrimaryRS.MoveComplete += adoPrimaryRS_MoveComplete;
					withEventsField_adoPrimaryRS.WillChangeRecord += adoPrimaryRS_WillChangeRecord;
				}
			}
		}
		bool mbChangedByCode;
		int mvBookMark;
		bool mbEditFlag;
		bool mbAddNewFlag;
		bool mbDataChanged;
		int gID;
		int p_Prom;
		bool p_Prom1;
		public string loadDBStr;
//Multi Warehouse change
		public int lWHA;
		public int lWHB;

		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1787;
			//Stock Transfer Details|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1085;
			//Print|Checked
			if (modRecordSet.rsLang.RecordCount){cmdPrint.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPrint.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1789;
			//Transfer|Checked
			if (modRecordSet.rsLang.RecordCount){cmdTransfer.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdTransfer.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1790;
			//Transfer From|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_5.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_5.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1801;
			//Transfer To|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1139;
			//Promotion Name|Checked
			if (modRecordSet.rsLang.RecordCount){lblWHA.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lblWHA.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1139;
			//Promotion Name|Checked
			if (modRecordSet.rsLang.RecordCount){lblWHB.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lblWHB.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1802;
			//Select wharehouse transfer from|checked
			if (modRecordSet.rsLang.RecordCount){cmdSelWHA.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdSelWHA.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1803;
			//Select wharehouse transfer to|Checked
			if (modRecordSet.rsLang.RecordCount){cmdSelWHB.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdSelWHB.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1147;
			//Add|Checked
			if (modRecordSet.rsLang.RecordCount){cmdAdd.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdAdd.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1148;
			//Delete|Checked
			if (modRecordSet.rsLang.RecordCount){cmdDelete.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdDelete.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmStockTransferWH.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void buildDataControls()
		{
			//    doDataControl Me.cmbChannel, "SELECT ChannelID, Channel_Name FROM Channel ORDER BY ChannelID", "Customer_ChannelID", "ChannelID", "Channel_Name"
		}

		private void doDataControl(ref myDataGridView dataControl, ref string sql, ref string DataField, ref string boundColumn, ref string listField)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref sql);
			//UPGRADE_WARNING: Couldn't resolve default property of object dataControl.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dataControl.DataSource = rs;
			//UPGRADE_ISSUE: Control method dataControl.DataSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			dataControl.DataSource = adoPrimaryRS;
			//UPGRADE_ISSUE: Control method dataControl.DataField was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			dataControl.DataField = DataField;
			//UPGRADE_WARNING: Couldn't resolve default property of object dataControl.boundColumn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dataControl.boundColumn = boundColumn;
			//UPGRADE_WARNING: Couldn't resolve default property of object dataControl.listField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dataControl.listField = listField;
		}

		public void loadItem(ref int id)
		{
			//Dim oText As System.Windows.Forms.TextBox
			//Dim oDate As DateTimePicker
			//Dim oCheck As System.Windows.Forms.CheckBox

			loadLanguage();
			ShowDialog();
		}
		private void setup()
		{
		}

		private void chkFields_Click(ref short Index)
		{

		}

		private void cmdAdd_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int lID = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);

			lID = My.MyProject.Forms.frmStockList.getItem();
			if (lID != 0) {
				 // ERROR: Not supported in C#: OnErrorStatement

				My.MyProject.Forms.frmStockTransferItemWH.loadItem(ref lID, ref , ref lWHA, ref lWHB);
				loadItems(lID);
			}
		}
		private void cmdDelete_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int lID = 0;
			if (lvStockT.FocusedItem == null) {
			} else {
				if (Interaction.MsgBox("Are you sure you wish to remove  '" + lvStockT.FocusedItem.Text + "'  from this Transfer?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "DELETE") == MsgBoxResult.Yes) {
					lID = Convert.ToInt32(Strings.Split(lvStockT.FocusedItem.Name, "_")[0]);
					modRecordSet.cnnDB.Execute("DELETE HandheldWHTransfer.* From HandheldWHTransfer WHERE HandheldWHTransfer.HandHeldID=" + lID + " AND HandheldWHTransfer.Quantity=" + Strings.Split(lvStockT.FocusedItem.Name, "_")[1] + ";");
					loadItems();
				}
			}

		}

		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//update
			//report_Promotion
		}


		private void cmdSelComp_Click()
		{
			object lblSComp = null;
			//frmSelComp.show 1
			ADODB.Connection cn = default(ADODB.Connection);
			ADODB.Recordset rj = default(ADODB.Recordset);

			loadDBStr = My.MyProject.Forms.frmSelComp.loadDB();

			if (string.IsNullOrEmpty(loadDBStr)) {
			} else {
				cn = modRecordSet.openSComp(ref loadDBStr);
				if (cn == null) {
				} else {

					rj = modRecordSet.getRSwaitron(ref "SELECT Company_Name FROM Company;", ref cn);
					//UPGRADE_WARNING: Couldn't resolve default property of object lblSComp.Caption. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lblSComp.Caption = rj.Fields("Company_Name").Value;

					cmdAdd.Enabled = true;
					cmdDelete.Enabled = true;
				}

			}
		}

		private void cmdSelWHA_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rj = default(ADODB.Recordset);
			lWHA = My.MyProject.Forms.frmMWSelect.getMWNo();
			//Multi Warehouse change
			if (lWHA > 1) {
				rj = modRecordSet.getRS(ref "SELECT * FROM Warehouse WHERE WarehouseID=" + lWHA + ";");
				lblWHA.Text = rj.Fields("Warehouse_Name").Value;
				cmdSelWHA.Enabled = false;
				cmdSelWHB.Enabled = true;
			}
		}

		private void cmdSelWHB_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rj = default(ADODB.Recordset);
			lWHB = My.MyProject.Forms.frmMWSelect.getMWNo();
			//Multi Warehouse change
			if (lWHB == lWHA){Interaction.MsgBox("Cannot select same warehouse at both ends.");return;
}
			if (lWHB > 1) {
				rj = modRecordSet.getRS(ref "SELECT * FROM Warehouse WHERE WarehouseID=" + lWHB + ";");
				lblWHB.Text = rj.Fields("Warehouse_Name").Value;
				cmdSelWHB.Enabled = false;
				//cmdSelWHB.Enabled = True

				cmdAdd.Enabled = true;
				cmdDelete.Enabled = true;
			}
		}

		private void cmdTransfer_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rsID = default(ADODB.Recordset);
			ADODB.Recordset rs = default(ADODB.Recordset);
			short x = 0;
			ADODB.Connection cn = default(ADODB.Connection);
			ADODB.Recordset rsChk = default(ADODB.Recordset);
			string errPosition = null;
			int gID = 0;
			decimal lQuantity = default(decimal);

			 // ERROR: Not supported in C#: OnErrorStatement

			errPosition = "Start";

			if (lvStockT.Items.Count > 0) {
				errPosition = "1";

				//cnnDB.Execute "INSERT INTO StockGroup (StockGroup_Name) VALUES ('HandheldWHTransfer')"
				modApplication.stTableName = "HandheldWHTransfer";
				//Set rj = getRS("SELECT StockGroup.StockGroupID, StockGroup.StockGroup_Name From StockGroup WHERE StockGroup.StockGroup_Name = 'HandheldWHTransfer';")
				//gID = rj("StockGroupID")

				errPosition = "2";
				//'Multi Warehouse change
				//cnnDB.Execute "UPDATE Company SET Company.Company_StockTakeDate = now();"
				//cnnDB.Execute "DELETE FROM StockTake WHERE (StockTake_WarehouseID > 0)"
				//cnnDB.Execute "INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment ) SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, 0 AS quantity, 0 AS adjustment FROM WarehouseStockItemLnk;"
				//cnnDB.Execute "UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)>0));"
				//'Multi Warehouse change
				//cnnDB.Execute "DELETE FROM StockTakeDeposit"
				//cnnDB.Execute "INSERT INTO StockTakeDeposit ( StockTakeDeposit_WarehouseID, StockTakeDeposit_DepositID, StockTakeDeposit_DepositTypeID, StockTakeDeposit_Quantity, StockTakeDeposit_Adjustment ) SELECT WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity FROM WarehouseDepositItemLnk INNER JOIN DISPLAY_Deposits ON (DISPLAY_Deposits.type = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = DISPLAY_Deposits.DepositID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID = DISPLAY_Deposits.WarehouseID);"
				//'Multi Warehouse change
				//'snap shot

				errPosition = "3";
				//Warehouse From
				adoPrimaryRS = modRecordSet.getRS(ref "SELECT * FROM " + modApplication.stTableName + " Where ((HandheldWHTransfer.WHouseID)=" + lWHA + ")");
				//Set adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, " & stTableName & ".Quantity, StockItem.StockItem_Quantity," & stTableName & ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" & stTableName & " INNER JOIN StockItem ON " & stTableName & ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " & gID & ") And ((Warehouse.WarehouseID) = " & lWHA & ") AND ((HandheldWHTransfer.WHouseID)=" & lWHA & ")) ORDER BY StockItem.StockItem_Name")
				if (adoPrimaryRS.RecordCount > 0) {
					while (adoPrimaryRS.EOF == false) {
						lQuantity = adoPrimaryRS.Fields("Quantity").Value;
						//cnnDB.Execute "UPDATE StockTake SET StockTake.StockTake_Quantity = " & lQuantity & " WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=" & lWHA & "));"
						//cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=" & lWHA & "));"
						//cnnDB.Execute "UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" & lQuantity & ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & lWHA & "));"

						modRecordSet.cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN " + modApplication.stTableName + " ON (" + modApplication.stTableName + ".WHouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = " + modApplication.stTableName + ".HandHeldID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" + lQuantity + ") WHERE (((" + modApplication.stTableName + ".HandHeldID)=" + adoPrimaryRS.Fields("HandHeldID").Value + ") AND ((" + modApplication.stTableName + ".WHouseID)=" + lWHA + "));");
						modRecordSet.cnnDB.Execute("UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityTransafer = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityTransafer]+(" + lQuantity + ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" + adoPrimaryRS.Fields("HandHeldID").Value + ") AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" + lWHA + "));");
						adoPrimaryRS.moveNext();
					}
				}


				//Warehouse To
				adoPrimaryRS = modRecordSet.getRS(ref "SELECT * FROM " + modApplication.stTableName + " Where ((HandheldWHTransfer.WHouseID)=" + lWHB + ")");
				//Set adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, " & stTableName & ".Quantity, StockItem.StockItem_Quantity," & stTableName & ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" & stTableName & " INNER JOIN StockItem ON " & stTableName & ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " & gID & ") And ((Warehouse.WarehouseID) = " & lWHA & ") AND ((HandheldWHTransfer.WHouseID)=" & lWHB & ")) ORDER BY StockItem.StockItem_Name")
				if (adoPrimaryRS.RecordCount > 0) {
					while (adoPrimaryRS.EOF == false) {
						lQuantity = adoPrimaryRS.Fields("Quantity").Value;
						//cnnDB.Execute "UPDATE StockTake SET StockTake.StockTake_Quantity = " & lQuantity & " WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=" & lWHB & "));"
						//cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=" & lWHB & "));"
						//cnnDB.Execute "UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" & lQuantity & ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & lWHB & "));"

						modRecordSet.cnnDB.Execute("INSERT INTO StockTransferWH ( StockTransferWH_Date, StockTransferWH_DayEndID, StockTransferWH_PersonID, StockTransferWH_WHFrom, StockTransferWH_WHTo, StockTransferWH_StockItemID, StockTransferWH_Qty ) SELECT Now() AS [date], Company.Company_DayEndID, " + My.MyProject.Forms.frmMenu.lblUser.Tag + ", " + lWHA + ", " + lWHB + ", " + adoPrimaryRS.Fields("HandHeldID").Value + ", " + adoPrimaryRS.Fields("Quantity").Value + " FROM Company;");
						modRecordSet.cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN " + modApplication.stTableName + " ON (" + modApplication.stTableName + ".WHouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = " + modApplication.stTableName + ".HandHeldID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" + lQuantity + ") WHERE (((" + modApplication.stTableName + ".HandHeldID)=" + adoPrimaryRS.Fields("HandHeldID").Value + ") AND ((" + modApplication.stTableName + ".WHouseID)=" + lWHB + "));");
						modRecordSet.cnnDB.Execute("UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityTransafer = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityTransafer]+(" + lQuantity + ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" + adoPrimaryRS.Fields("HandHeldID").Value + ") AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" + lWHB + "));");
						adoPrimaryRS.moveNext();
					}
				}

				errPosition = "4";
				report_WHTransfer();

				modRecordSet.cnnDB.Execute("DROP TABLE HandheldWHTransfer");
				//cnnDB.Execute "DELETE * FROM StockGroup WHERE StockGroup_Name ='HandheldWHTransfer'"

				Interaction.MsgBox("Stock Transfer process has been completed.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly + MsgBoxStyle.DefaultButton2, "Completed");
				this.Close();
			} else {
			}

			return;
			ErrTransfer:
			Interaction.MsgBox("Error at position no. " + errPosition + " Err Number " + Err().Number + " " + Err().Description);
			 // ERROR: Not supported in C#: ResumeStatement

		}

		private void report_WHTransfer()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = default(CrystalDecisions.CrystalReports.Engine.ReportDocument);
			Report.Load("cryWHTransfer.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT Company.Company_Name FROM Company;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();

			Report.SetParameterValue("txtFrom", lblWHA.Text);
			Report.SetParameterValue("txtTo", lblWHB.Text);
			Report.SetParameterValue("txtPerson", My.MyProject.Forms.frmMenu.lblUser);

			sql = "SELECT HandheldWHTransfer.HandHeldID, StockItem.StockItem_Name, HandheldWHTransfer.Quantity";
			sql = sql + " FROM HandheldWHTransfer INNER JOIN StockItem ON HandheldWHTransfer.HandHeldID = StockItem.StockItemID WHERE (((HandheldWHTransfer.WHouseID)=" + lWHB + "));";
			Debug.Print(sql);
			rs = modRecordSet.getRS(ref sql);

			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = default(CrystalDecisions.CrystalReports.Engine.ReportDocument);
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			Report.Database.Tables(1).SetDataSource(rs);

			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		private void frmStockTransferWH_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			lvStockT.Columns.Clear();
			lvStockT.Columns.Add("", "Stock Item", Convert.ToInt32(sizeConvertors.twipsToPixels(5050, true)));
			lvStockT.Columns.Add("QTY", Convert.ToInt32(sizeConvertors.twipsToPixels(800, true)), System.Windows.Forms.HorizontalAlignment.Right);
			//lvStockT.ColumnHeaders.Add , , "Price", 1440, 1
			loadLanguage();
			//Dim rj As Recordset
			//Set rj = getRS("SELECT Company_Name FROM Company;")
			//lblPComp.Caption = rj("Company_Name")
			lblWHA.Text = "Select Warehouse Transfer From";
			cmdSelWHA.Enabled = true;

			lblWHB.Text = "Select Warehouse Transfer To";
			cmdSelWHB.Enabled = false;

			cmdAdd.Enabled = false;
			cmdDelete.Enabled = false;
			//cmdTransfer.Enabled = False
			ChkHandheldWHTransfer();
			modRecordSet.cnnDB.Execute("DELETE * from HandheldWHTransfer;");
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

		private void loadItems(ref int lID = 0, ref short quantity = 0)
		{
			System.Windows.Forms.ListViewItem listItem = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			lvStockT.Items.Clear();
			rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, HandheldWHTransfer.* FROM HandheldWHTransfer INNER JOIN StockItem ON HandheldWHTransfer.HandHeldID = StockItem.StockItemID WHERE HandheldWHTransfer.WHouseID = " + lWHB + " ORDER BY StockItem.StockItem_Name;");
			while (!(rs.EOF)) {

				listItem = lvStockT.Items.Add(rs.Fields("HandHeldID").Value + "_" + rs.Fields("Quantity").Value, rs.Fields("StockItem_Name").Value, "");
				//UPGRADE_WARNING: Lower bound of collection listItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				if (listItem.SubItems.Count > 1) {
					listItem.SubItems[1].Text = rs.Fields("Quantity").Value;
				} else {
					listItem.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("Quantity").Value));
				}
				if (rs.Fields("HandHeldID").Value == lID & rs.Fields("Quantity").Value == quantity)
					listItem.Selected = true;
				rs.moveNext();
			}
		}

//UPGRADE_WARNING: Event frmStockTransferWH.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void frmStockTransferWH_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			Button cmdLast = new Button();
			Button cmdNext = new Button();
			Label lblStatus = new Label();
			 // ERROR: Not supported in C#: OnErrorStatement

			lblStatus.Width = sizeConvertors.pixelToTwips(this.Width, true) - 1500;
			cmdNext.Left = lblStatus.Width + 700;
			cmdLast.Left = cmdNext.Left + 340;
		}

		private void frmStockTransferWH_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (mbEditFlag | mbAddNewFlag)
				goto EventExitSub;

			switch (KeyAscii) {
				case System.Windows.Forms.Keys.Escape:
					KeyAscii = 0;
					adoPrimaryRS.Move(0);

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

		private void frmStockTransferWH_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
		}

		private void adoPrimaryRS_MoveComplete(ADODB.EventReasonEnum adReason, ADODB.Error pError, ref ADODB.EventStatusEnum adStatus, ADODB.Recordset pRecordset)
		{
			//This will display the current record position for this recordset
		}

		private void adoPrimaryRS_WillChangeRecord(ADODB.EventReasonEnum adReason, int cRecords, ref ADODB.EventStatusEnum adStatus, ADODB.Recordset pRecordset)
		{
			//This is where you put validation code
			//This event gets called when the following actions occur
			bool bCancel = false;
			switch (adReason) {
				case ADODB.EventReasonEnum.adRsnAddNew:
					break;
				case ADODB.EventReasonEnum.adRsnClose:
					break;
				case ADODB.EventReasonEnum.adRsnDelete:
					break;
				case ADODB.EventReasonEnum.adRsnFirstChange:
					break;
				case ADODB.EventReasonEnum.adRsnMove:
					break;
				case ADODB.EventReasonEnum.adRsnRequery:
					break;
				case ADODB.EventReasonEnum.adRsnResynch:
					break;
				case ADODB.EventReasonEnum.adRsnUndoAddNew:
					break;
				case ADODB.EventReasonEnum.adRsnUndoDelete:
					break;
				case ADODB.EventReasonEnum.adRsnUndoUpdate:
					break;
				case ADODB.EventReasonEnum.adRsnUpdate:
					break;
			}

			if (bCancel)
				adStatus = ADODB.EventStatusEnum.adStatusCancel;
		}
		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//    On Error Resume Next
			//    If mbAddNewFlag Then
			this.Close();
			//    Else
			//        mbEditFlag = False
			//        mbAddNewFlag = False
			//        adoPrimaryRS.CancelUpdate
			//        If mvBookMark > 0 Then
			//            adoPrimaryRS.Bookmark = mvBookMark
			//        Else
			//            adoPrimaryRS.MoveFirst
			//        End If
			//        mbDataChanged = False
			//    End If
		}

//UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private bool update_Renamed()
		{
			bool functionReturnValue = false;
			 // ERROR: Not supported in C#: OnErrorStatement

			functionReturnValue = true;
			adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll);
			if (mbAddNewFlag) {
				adoPrimaryRS.MoveLast();
				//move to the new record
			}

			mbEditFlag = false;
			mbAddNewFlag = false;
			mbDataChanged = false;
			return functionReturnValue;
			UpdateErr:

			Interaction.MsgBox(Err().Description);
			functionReturnValue = false;
			return functionReturnValue;
		}

		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdClose.Focus();
			//DoEvents
			//If update() Then
			//   If _chkFields_1.value = 0 Then
			//      cnnDB.Execute "UPDATE Promotion SET Promotion_StartDate = #" & DTFields(0).value & "#, Promotion_EndDate = #" & DTFields(1).value & "#, Promotion_StartTime = #" & DTFields(2).value & "# ,Promotion_EndTime =#" & DTFields(3).value & "# WHERE PromotionID = " & p_Prom & ";"
			//   End If
			//   Unload Me
			//End If
		}

		private void Label1_Click()
		{

		}

		private void lvStockT_DoubleClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			int lID = 0;
			short lQty = 0;
			if (lvStockT.FocusedItem == null) {
			} else {
				lID = Convert.ToInt32(Strings.Split(lvStockT.FocusedItem.Name, "_")[0]);
				lQty = Convert.ToInt16(Strings.Split(lvStockT.FocusedItem.Name, "_")[1]);

				My.MyProject.Forms.frmStockTransferItemWH.loadItem(ref lID, ref Convert.ToInt16(lQty), ref lWHA, ref lWHB);
				loadItems(ref lID, ref lQty);
			}
		}

		private void lvStockT_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 13) {
				lvStockT_DoubleClick(lvStockT, new System.EventArgs());
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}


		private void txtInteger_MyGotFocus(ref short Index)
		{
			//    MyGotFocusNumeric txtInteger(Index)
		}

		private void txtInteger_KeyPress(ref short Index, ref short KeyAscii)
		{
			//    KeyPress KeyAscii
		}

		private void txtInteger_MyLostFocus(ref short Index)
		{
			//    LostFocus txtInteger(Index), 0
		}

		private void txtFloat_MyGotFocus(ref short Index)
		{
			//    MyGotFocusNumeric txtFloat(Index)
		}

		private void txtFloat_KeyPress(ref short Index, ref short KeyAscii)
		{
			//    KeyPress KeyAscii
		}

		private void txtFloat_MyLostFocus(ref short Index)
		{
			//    MyGotFocusNumeric txtFloat(Index), 2
		}

		private void txtFloatNegative_MyGotFocus(ref short Index)
		{
			//    MyGotFocusNumeric txtFloatNegative(Index)
		}

		private void txtFloatNegative_KeyPress(ref short Index, ref short KeyAscii)
		{
			//    KeyPressNegative txtFloatNegative(Index), KeyAscii
		}

		private void txtFloatNegative_MyLostFocus(ref short Index)
		{
			//    LostFocus txtFloatNegative(Index), 2
		}
	}
}
