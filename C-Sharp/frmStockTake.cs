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
	internal partial class frmStockTake : System.Windows.Forms.Form
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
		bool blHandHeld;
		string gFilter;
		string gFilterSQL;
		int gID;
			//Multi Warehouse change
		int lMWNo;

		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1221;
			//Stock Take Adjustments|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//DUPLICATE DB ENTRIES! Item 1591 and 1705

			//lblHeading = No Code   [Using the "Stock Item Selector"...]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblHeading.Caption = rsLang("LanguageLayoutLnk_Description"): lblHeading.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1085;
			//Print|Checked
			if (modRecordSet.rsLang.RecordCount){cmdPrint.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPrint.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmStockTake.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public void loadItem(ref int id)
		{
			if (id) {
			} else {
				return;
			}

			My.MyProject.Forms.frmStockTakeSnapshot.remoteSnapShot();
			System.Windows.Forms.Application.DoEvents();

			ADODB.Recordset rs = default(ADODB.Recordset);
			gID = id;
			lMWNo = My.MyProject.Forms.frmMWSelect.getMWNo();
			//Multi Warehouse change
			rs = modRecordSet.getRS(ref "SELECT StockGroup.StockGroupID, StockGroup.StockGroup_Name From StockGroup WHERE (((StockGroup.StockGroupID)=" + gID + "));");
			lblHeading.Text = rs.Fields("StockGroup_Name").Value;
			getNamespace();

			mbDataChanged = false;

			loadLanguage();
			ShowDialog();
		}
		private void cmdFilter_Click()
		{
			My.MyProject.Forms.frmFilter.loadFilter(ref gFilter);
			getNamespace();
		}
		private void getNamespace()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rj = default(ADODB.Recordset);
			blHandHeld = false;
			//Initialize for StockGroup handheld

			rs = modRecordSet.getRS(ref "SELECT StockGroup_Name FROM StockGroup WHERE StockGroupID =" + gID);

			if (Strings.UCase(Strings.Mid(rs.Fields("StockGroup_Name").Value, 1, 8)) == "HANDHELD") {
				blHandHeld = true;
				modApplication.stTableName = rs.Fields("StockGroup_Name").Value;

				//Set adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, " & stTableName & ".Quantity, StockItem.StockItem_Quantity," & stTableName & ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" & stTableName & " INNER JOIN StockItem ON " & stTableName & ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " & gID & ") And ((Warehouse.WarehouseID) = 2) And ((StockItem.StockItem_Disabled) = False) And ((StockItem.StockItem_Discontinued) = False)) ORDER BY StockItem.StockItem_Name")
				//Multi Warehouse change
				adoPrimaryRS = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, " + modApplication.stTableName + ".Quantity, StockItem.StockItem_Quantity," + modApplication.stTableName + ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" + modApplication.stTableName + " INNER JOIN StockItem ON " + modApplication.stTableName + ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " + gID + ") And ((Warehouse.WarehouseID) = " + lMWNo + ") And ((StockItem.StockItem_Disabled) = False) And ((StockItem.StockItem_Discontinued) = False)) ORDER BY StockItem.StockItem_Name");
			} else {
				//Multi Warehouse change
				//Set adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where StockGroup.StockGroupID = " & gID & " And StockTake.StockTake_WarehouseID = 2  AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ORDER BY StockItem.StockItem_Name;")
				adoPrimaryRS = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where StockGroup.StockGroupID = " + gID + " And StockTake.StockTake_WarehouseID = " + lMWNo + " AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ORDER BY StockItem.StockItem_Name;");
				//Multi Warehouse change
			}

			//Display the list of Titles in the DataCombo
			grdDataGrid.DataSource = adoPrimaryRS;
			grdDataGrid.Columns[0].HeaderText = "Stock Name";
			grdDataGrid.Columns[0].DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft;
			grdDataGrid.Columns[0].Frozen = true;

			grdDataGrid.Columns[1].HeaderText = "Quantity";
			grdDataGrid.Columns[1].DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgRight;
			grdDataGrid.Columns[1].Width = sizeConvertors.twipsToPixels(900, true);
			//UPGRADE_WARNING: Couldn't resolve default property of object grdDataGrid.Columns().DataFormat.Type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			grdDataGrid.Columns[1].DefaultCellStyle.Format = 1;
			//grdDataGrid.Columns(1).NumberFormat = "#,##0.0000"
			grdDataGrid.Columns[1].Frozen = false;

			grdDataGrid.Columns[2].Visible = false;
			grdDataGrid.Columns[3].Visible = false;
			grdDataGrid.Columns[4].Visible = false;

			if (blHandHeld == true) {
				grdDataGrid.Columns[5].Visible = false;
				grdDataGrid.Columns[1].Frozen = true;
			}

			frmStockTake_Resize(this, new System.EventArgs());
			mbDataChanged = false;

		}
		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (blHandHeld == true) {
				update_Renamed();
				Update_Handheld();
				modApplication.report_HandHeldScanner();
			} else {
				update_Renamed();
				modApplication.report_StockTake(ref gID, ref lMWNo);
			}

		}

		private void cmdPrintDiff_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (blHandHeld == true) {
				Interaction.MsgBox("No difference report for Handheld Capturing.");
			} else {
				update_Renamed();
				modApplication.report_StockTakeDiff(ref gID, ref lMWNo);
			}
		}

//UPGRADE_WARNING: Event frmStockTake.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void frmStockTake_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			//This will resize the grid when the form is resized
			System.Windows.Forms.Application.DoEvents();
			grdDataGrid.Height = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(this.ClientRectangle.Height, false) - 30 - sizeConvertors.pixelToTwips(picButtons.Height, false), false);
			grdDataGrid.Columns[0].Width = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(grdDataGrid.Width, true) - 900 - 580, true);

		}
		private void frmStockTake_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 27) {
				KeyAscii = 0;
				cmdClose_Click(cmdClose, new System.EventArgs());
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmStockTake_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
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
			decimal lQuantity = default(decimal);
			//Long

			if (blHandHeld == true) {
				if (adoPrimaryRS.Fields("Quantity").OriginalValue != adoPrimaryRS.Fields("Quantity").Value) {
					lQuantity = adoPrimaryRS.Fields("Quantity").Value;
					modRecordSet.cnnDB.Execute("UPDATE " + modApplication.stTableName + " SET Quantity = " + lQuantity + " WHERE " + modApplication.stTableName + ".HandHeldID = " + adoPrimaryRS.Fields("StockTake_StockItemID").Value);
					doDiskFlush();
				}

			} else {
				if (Convert.ToDecimal(adoPrimaryRS.Fields("StockTake_Quantity").OriginalValue) != Convert.ToDecimal(adoPrimaryRS.Fields("StockTake_Quantity").Value)) {
					//lQuantity = adoPrimaryRS("StockTake_Quantity") '- adoPrimaryRS("StockTake_Quantity").OriginalValue

					//*
					lQuantity = adoPrimaryRS.Fields("StockTake_Quantity").Value - adoPrimaryRS.Fields("StockTake_Quantity").OriginalValue;
					//cnnDB.Execute "UPDATE StockTake SET StockTake.StockTake_Quantity = [StockTake]![StockTake_Quantity]+(" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"

					//Multi Warehouse change
					//cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
					//cnnDB.Execute "UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" & lQuantity & ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & "));"
					modRecordSet.cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" + lQuantity + ") WHERE (((StockTake.StockTake_StockItemID)=" + adoPrimaryRS.Fields("StockTake_StockItemID").Value + ") AND ((StockTake.StockTake_WarehouseID)=" + lMWNo + "));");
					modRecordSet.cnnDB.Execute("UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" + lQuantity + ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" + adoPrimaryRS.Fields("StockTake_StockItemID").Value + ") AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" + lMWNo + "));");
					//Multi Warehouse change

					//*
					//cnnDB.Execute "UPDATE StockTake SET StockTake.StockTake_Quantity = [StockTake]![StockTake_Quantity]+(" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
					//cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = (" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
					//cnnDB.Execute "UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = (" & lQuantity & ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & "));"
					doDiskFlush();
				}

			}

		}
		public void Update_Handheld()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			decimal lQuantity = default(decimal);

			//Set adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, " & stTableName & ".Quantity, StockItem.StockItem_Quantity," & stTableName & ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" & stTableName & " INNER JOIN StockItem ON " & stTableName & ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " & gID & ") And ((Warehouse.WarehouseID) = 2) And ((StockItem.StockItem_Disabled) = False) And ((StockItem.StockItem_Discontinued) = False)) ORDER BY StockItem.StockItem_Name")
			//Multi Warehouse change
			adoPrimaryRS = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, " + modApplication.stTableName + ".Quantity, StockItem.StockItem_Quantity," + modApplication.stTableName + ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" + modApplication.stTableName + " INNER JOIN StockItem ON " + modApplication.stTableName + ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " + gID + ") And ((Warehouse.WarehouseID) = " + lMWNo + ") And ((StockItem.StockItem_Disabled) = False) And ((StockItem.StockItem_Discontinued) = False)) ORDER BY StockItem.StockItem_Name");
			//Set adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name," & stTableName & ".Quantity,StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID,StockItem.StockItem_Quantity,StockTake.StockTake_WarehouseID," & stTableName & ".HandHeldID FROM " & _
			//'                  "(StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN " & stTableName & " ON StockItem.StockItemID = " & stTableName & ".HandHeldID WHERE StockTake.StockTake_WarehouseID = 2 AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ORDER BY StockItem.StockItem_Name;")
			if (adoPrimaryRS.RecordCount > 0) {
				while (adoPrimaryRS.EOF == false) {
					lQuantity = adoPrimaryRS.Fields("Quantity").Value - adoPrimaryRS.Fields("StockTake_Quantity").OriginalValue;
					//cnnDB.Execute "UPDATE StockTake SET StockTake.StockTake_Quantity = " & lQuantity & " WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
					//cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
					//OLD'cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = " & lQuantity & " WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
					//cnnDB.Execute "UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" & lQuantity & ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & "));"
					//Multi Warehouse change
					modRecordSet.cnnDB.Execute("UPDATE StockTake SET StockTake.StockTake_Quantity = " + lQuantity + " WHERE (((StockTake.StockTake_StockItemID)=" + adoPrimaryRS.Fields("StockTake_StockItemID").Value + ") AND ((StockTake.StockTake_WarehouseID)=" + lMWNo + "));");
					modRecordSet.cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" + lQuantity + ") WHERE (((StockTake.StockTake_StockItemID)=" + adoPrimaryRS.Fields("StockTake_StockItemID").Value + ") AND ((StockTake.StockTake_WarehouseID)=" + lMWNo + "));");
					modRecordSet.cnnDB.Execute("UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" + lQuantity + ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" + adoPrimaryRS.Fields("StockTake_StockItemID").Value + ") AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" + lMWNo + "));");
					adoPrimaryRS.moveNext();
				}
			}
			doDiskFlush();
		}
		private void doDiskFlush()
		{
			return;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			object hkey = null;
			int lRetVal = 0;
			string vValue = null;
			string lPath = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			int lID = 0;
			int lCompanyID = 0;
			string lString = null;
			string lKey = null;
			lID = adoPrimaryRS.Fields("StockTake_StockItemID").Value;
			//UPGRADE_WARNING: Couldn't resolve default property of object hkey. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lRetVal = modUtilities.RegOpenKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\4POS", 0, modUtilities.KEY_QUERY_VALUE, ref hkey);
			//UPGRADE_WARNING: Couldn't resolve default property of object hkey. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lRetVal = modUtilities.QueryValueEx(hkey, "master", ref vValue);
			//UPGRADE_WARNING: Couldn't resolve default property of object hkey. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modUtilities.RegCloseKey(hkey);
			if (string.IsNullOrEmpty(vValue)) {
				return;
			} else {
				lPath = vValue;
			}

			rs = modRecordSet.getRS(ref "SELECT Company.CompanyID, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, DayEndStockItemLnk.DayEndStockItemLnk_DayEndID, DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink FROM Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" + lID + "));");


		}

		private void cmdCancel_Click()
		{
			 // ERROR: Not supported in C#: OnErrorStatement


			mbEditFlag = false;
			mbAddNewFlag = false;
			adoPrimaryRS.CancelUpdate();
			//UPGRADE_WARNING: Couldn't resolve default property of object mvBookMark. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (mvBookMark > 0) {
				//UPGRADE_WARNING: Couldn't resolve default property of object mvBookMark. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				adoPrimaryRS.Bookmark = mvBookMark;
			} else {
				adoPrimaryRS.MoveFirst();
			}
			mbDataChanged = false;

		}

//UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private void update_Renamed()
		{
			 // ERROR: Not supported in C#: OnErrorStatement


			adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll);

			if (mbAddNewFlag) {
				adoPrimaryRS.MoveLast();
				//Move to the new record
			}

			mbEditFlag = false;
			mbAddNewFlag = false;
			mbDataChanged = false;

			return;
			UpdateErr:


			if (blHandHeld == true)
				return;
			Interaction.MsgBox(Err().Description);


		}

		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object Erro = null;
			switch (Erro) {
				case  // ERROR: Case labels with binary operators are unsupported : LessThan
0:
					 // ERROR: Not supported in C#: ErrorStatement

					break;
				case 1:
					goto ERRP;
					break;
			}

			if (blHandHeld == true) {
				update_Renamed();
				Update_Handheld();
			} else {
				update_Renamed();
			}
			//Multi Warehouse change
			//Set adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where StockGroup.StockGroupID = 1 And StockTake.StockTake_WarehouseID = 2  AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ORDER BY StockItem.StockItem_Name;")
			adoPrimaryRS = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where StockGroup.StockGroupID = 1 And StockTake.StockTake_WarehouseID = " + lMWNo + " AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ORDER BY StockItem.StockItem_Name;");
			//Multi Warehouse change
			this.Close();
			ERRP:
			if (blHandHeld == true)
				return;

		}

		private void goFirst()
		{
			 // ERROR: Not supported in C#: OnErrorStatement


			adoPrimaryRS.MoveFirst();
			mbDataChanged = false;

			return;
			GoFirstError:


			Interaction.MsgBox(Err().Description);
		}

		private void goLast()
		{
			 // ERROR: Not supported in C#: OnErrorStatement


			adoPrimaryRS.MoveLast();
			mbDataChanged = false;
			return;
			GoLastError:

			Interaction.MsgBox(Err().Description);
		}

		//Private Sub grdDataGrid_CellValueChanged(ByVal eventSender As System.Object, ByVal eventArgs As AxMSDataGridLib.DDataGridEvents_CellValueChangedEvent) Handles grdDataGrid.CellValueChanged
		//    If grdDataGrid.Columns(ColIndex).DataFormat.Format = "#,##0.00" Then
		//       grdDataGrid.Columns(ColIndex).DataFormat = 0
		//    End If

		//End Sub
	}
}
