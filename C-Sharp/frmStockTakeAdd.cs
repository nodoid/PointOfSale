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
using Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6;
namespace _4PosBackOffice.NET
{
	internal partial class frmStockTakeAdd : System.Windows.Forms.Form
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

		public void loadLanguage()
		{

			//Note: Form Caption Grammer Wrong!
			//frmStockTakeAdd = No Code  [Stock Take Add (This option will only Add stock to your quantities and is NOT a Stock Take!)]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmStockTakeAdd.Caption = rsLang("LanguageLayoutLnk_Description"): frmStockTakeAdd.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblHeading = No Code       [Using the "Stock Item Selector"...]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblHeading.Caption = rsLang("LanguageLayoutLnk_Description"): lblHeading.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1085;
			//Print|Checked
			if (modRecordSet.rsLang.RecordCount){cmdPrint.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPrint.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1427;
			//Reference|Checked
			if (modRecordSet.rsLang.RecordCount){lbl.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmStockTakeAdd.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public void loadItem(ref int id)
		{
			if (id) {
			} else {
				return;
			}
			ADODB.Recordset rs = default(ADODB.Recordset);

			//Dim lMWNo As Long
			//lMWNo = frmMWSelect.getMWNo
			//If lMWNo > 1 Then
			//    Set rsWH = getRS("SELECT * FROM Warehouse WHERE WarehouseID=" & lMWNo & ";")
			//    Report.txtWH.SetText rsWH("Warehouse_Name")
			//End If

			gID = id;
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
				adoPrimaryRS = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, " + modApplication.stTableName + ".Quantity, StockItem.StockItem_Quantity," + modApplication.stTableName + ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" + modApplication.stTableName + " INNER JOIN StockItem ON " + modApplication.stTableName + ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " + gID + ") And ((Warehouse.WarehouseID) = 2) And ((StockItem.StockItem_Disabled) = False) And ((StockItem.StockItem_Discontinued) = False)) ORDER BY StockItem.StockItem_Name");

			} else {
				//  Set adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where StockGroup.StockGroupID = " & gID & " And StockTake.StockTake_WarehouseID = 2  AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ORDER BY StockItem.StockItem_Name;")
				adoPrimaryRS = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, StockTake.StockTake_Adjustment, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where StockGroup.StockGroupID = " + gID + " And StockTake.StockTake_WarehouseID = 2  AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ORDER BY StockItem.StockItem_Name;");

			}

			//Display the list of Titles in the DataCombo
			grdDataGrid1.DataSource = adoPrimaryRS;
			grdDataGrid1.Columns[0].HeaderText = "Stock Name";
			grdDataGrid1.Columns[0].DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft;
			grdDataGrid1.Columns[0].Frozen = true;

			grdDataGrid1.Columns[1].HeaderText = "Quantity";
			grdDataGrid1.Columns[1].DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgRight;
			grdDataGrid1.Columns[1].Width = sizeConvertors.twipsToPixels(900, true);
			//UPGRADE_WARNING: Couldn't resolve default property of object grdDataGrid1.Columns().DataFormat.Type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			grdDataGrid1.Columns[1].DefaultCellStyle.Format = 1;
			//grdDataGrid1.Columns(1).NumberFormat = "#,##0.0000"
			grdDataGrid1.Columns[1].Frozen = false;

			grdDataGrid1.Columns[2].Visible = false;
			grdDataGrid1.Columns[3].Visible = false;
			grdDataGrid1.Columns[4].Visible = false;
			grdDataGrid1.Columns[5].Visible = false;
			//grdDataGrid1.Columns(6).Visible = False

			if (blHandHeld == true) {
				grdDataGrid1.Columns[5].Visible = false;
			}

			frmStockTakeAdd_Resize(this, new System.EventArgs());
			mbDataChanged = false;

		}
		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (blHandHeld == true) {
				modApplication.report_HandHeldScanner();
			} else {
				modApplication.report_StockTake(gID);
			}

		}

		private string getRegKey(ref string lKey)
		{
			int hkey = 0;
			int lRetVal = 0;
			int vValue = 0;
			lRetVal = modUtilities.RegOpenKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\4POS\\pos", 0, modUtilities.KEY_QUERY_VALUE, ref hkey);
			lRetVal = modUtilities.QueryValueEx(hkey, lKey, ref vValue);
			modUtilities.RegCloseKey(hkey);
			return vValue;
		}

		private void cmdPrintSlip_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			Printer Object_Renamed = new Printer();
			short rightX = 0;
			string lString = null;
			short y = 0;
			string lRetVal = null;
			int hkey = 0;
			object vValue = null;
			Printer Printer = new Printer();
			int gFontSize = 0;
			string gValue = null;
			string gFontName = null;
			string sql = null;
			ADODB.Recordset rsPrinter = default(ADODB.Recordset);
			ADODB.Recordset rs = default(ADODB.Recordset);
			string TheBarcodePrName = null;
			string lPrinter = null;
			Printer lPrn = null;
			Printer lPrnType = null;
			Printer gObject = null;
			//On Local Error Resume Next
			const short characters = 32;
			int gWidth = 0;
			int gLeft = 0;
			int gRight = 0;

			rs = modRecordSet.getRS(ref "SELECT Company_PrintDayEndSlip from Company;");
			if (rs.RecordCount) {
				if (rs.Fields("Company_PrintDayEndSlip").Value) {

				} else {
					return;
				}
			} else {
				return;
			}

			if (blHandHeld == true) {
				sql = "SELECT " + modApplication.stTableName + ".HandHeldID,StockItem.StockItem_Name," + modApplication.stTableName + ".Quantity,StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID,StockItem.StockItem_Quantity,StockTake.StockTake_WarehouseID," + modApplication.stTableName + ".HandHeldID FROM " + "(StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN " + modApplication.stTableName + " ON StockItem.StockItemID = " + modApplication.stTableName + ".HandHeldID WHERE StockTake.StockTake_WarehouseID = 2 AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ORDER BY StockItem.StockItem_Name;";
				rs = modRecordSet.getRS(ref sql);
				if (rs.BOF | rs.EOF) {
					return;
				}
			} else {
				sql = "SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_Adjustment, StockTake.StockTake_QuantityOrig, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity ";
				sql = sql + "FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_Adjustment) <> 0) And ((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " + gID + ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_Adjustment) <> 0) And ((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " + gID + ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_Adjustment) <> 0) And ((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " + gID + ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;";
				rs = modRecordSet.getRS(ref sql);
				if (rs.BOF | rs.EOF) {
					return;
				}
			}

			 // ERROR: Not supported in C#: OnErrorStatement


			gFontName = getRegKey(ref "printerPOSfontName");
			if (string.IsNullOrEmpty(gFontName))
				gFontName = "Courier";
			gValue = getRegKey(ref "printerPOSfontSize");
			if (string.IsNullOrEmpty(gValue)) {
				gFontSize = 10;
			} else {
				gFontSize = Convert.ToInt16(gValue);
			}

			gValue = getRegKey(ref "printerPOSleft");
			 // ERROR: Not supported in C#: OnErrorStatement

			if (string.IsNullOrEmpty(gValue)) {
				gLeft = 0;
			} else {
				gLeft = Convert.ToInt32(gValue) * Printer.TwipsPerPixelX;
			}
			gValue = getRegKey(ref "printerPOSright");
			if (string.IsNullOrEmpty(gValue)) {
				gRight = 0;
			} else {
				gRight = Convert.ToInt32(gValue) * Printer.TwipsPerPixelX;
			}

			vValue = "";
			lRetVal = modUtilities.RegOpenKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\4POS\\pos", 0, modUtilities.KEY_QUERY_VALUE, ref hkey);
			lRetVal = modUtilities.QueryValueEx(hkey, "printerPOS", ref vValue);
			modUtilities.RegCloseKey(hkey);
			if (string.IsNullOrEmpty(vValue))
				vValue = "0";

			if (vValue != "0") {
				if (vValue == "[Not Installed]") {
					return;
				}

				foreach (Printer lPrn_loopVariable in GlobalModule.Printers) {
					lPrn = lPrn_loopVariable;
					if (Strings.LCase(lPrn.DeviceName) == Strings.LCase(vValue)) {
						Printer = lPrn;
						lPrinter = vValue;
						break; // TODO: might not be correct. Was : Exit For
					}
				}

				gWidth = Printer.Width;
				if (gWidth == 2724) {
				} else {
					gWidth = 3600;
				}

				gObject = Printer;


				 // ERROR: Not supported in C#: OnErrorStatement

				gObject.FontBold = true;
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
				//gObject.PSet(New Point(((gWidth - gRight) - gObject.TextWidth(" ")) / 2, gObject.CurrentY))
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
				gObject.Print(" ");

				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
				//gObject.PSet(New Point(((gWidth - gRight) - gObject.TextWidth(frmMenu.lblCompany.Text)) / 2, gObject.CurrentY))
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
				gObject.Print(My.MyProject.Forms.frmMenu.lblCompany.Text);

				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
				gObject.Print(" ");

				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
				//gObject.PSet(New Point(((gWidth - gRight) - gObject.TextWidth("Stock Addition")) / 2, gObject.CurrentY))
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
				gObject.Print("Stock Addition");
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
				gObject.Print(" ");

				gObject.FontUnderline = true;
				y = gObject.CurrentY;
				gObject.FontBold = true;
				lString = "Reference" + " :";
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
				gObject.Print(lString);
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
				gObject.FontBold = false;
				lString = txtSARef.Text;
				//gObject.PSet (1800, y)
				//gObject.PSet(New Point(IIf(gWidth = 2724, 1050, 1800), y)) '1350
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
				gObject.Print(lString);

				gObject.FontUnderline = true;
				y = gObject.CurrentY;
				gObject.FontBold = true;
				lString = "Date" + " :";
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
				gObject.Print(lString);
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
				gObject.FontBold = false;
				lString = Strings.Format(DateAndTime.Now, "ddd dd mm,yyyy hh:nn");
				//gObject.PSet (1800, y)
				//gObject.PSet(New Point(IIf(gWidth = 2724, 1050, 1800), y)) '1350
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
				gObject.Print(lString);

				gObject.FontUnderline = false;

				//gObject.Line((0, gObject.CurrentY) - ((gObject.Width - gRight) - rightX, gObject.CurrentY + 1))

				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
				//gObject.PSet(New Point(0, gObject.CurrentY + 30))
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);

				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
				gObject.Print(" ");
				Object_Renamed.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);

				while (!(rs.EOF)) {

					y = gObject.CurrentY;
					gObject.FontBold = true;
					lString = rs.Fields("StockItem_Name").Value;
					gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
					gObject.Print(lString);
					gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);

					y = gObject.CurrentY;
					gObject.FontBold = false;
					lString = rs.Fields("StockTake_Adjustment").Value;
					gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
					gObject.Print(lString);
					gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);

					//gObject.FontBold = False
					//lString = rs("StockTake_Quantity")
					//gObject.PSet (IIf(gWidth = 2724, 1050, 1800), y) '1350
					//gObject.ForeColor = vbBlack
					//gObject.Print lString

					gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
					gObject.Print(" ");
					Object_Renamed.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);

					rs.moveNext();
				}

				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
				//gObject.Line(0, (gObject.CurrentY - ((gObject.Width - gRight) - rightX, gObject.CurrentY + 1)

				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
				//gObject.PSet(New Point(0, gObject.CurrentY + 30))
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
				//For x = 1 To 6
				//    gObject.Print " "
				//Next x
				gObject.EndDoc();

			}
		}

		private void frmStockTakeAdd_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			//This will resize the grid when the form is resized
			System.Windows.Forms.Application.DoEvents();
			grdDataGrid1.Height = grdDataGrid.ClientRectangle.Height;
			// Me.ScaleHeight - 50 - picButtons.Height - txtSARef.Height
			grdDataGrid1.Columns[0].Width = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(grdDataGrid1.Width, true) - 900 - 580, true);

		}
		private void frmStockTakeAdd_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void frmStockTakeAdd_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			//
		}

		private void adoPrimaryRS_MoveComplete(ADODB.EventReasonEnum adReason, ADODB.Error pError, ref ADODB.EventStatusEnum adStatus, ADODB.Recordset pRecordset)
		{
			//This will display the current record position for this recordset
		}

		private void adoPrimaryRS_WillChangeRecord(ADODB.EventReasonEnum adReason, int cRecords, ref ADODB.EventStatusEnum adStatus, ADODB.Recordset pRecordset)
		{

			//*
			//cnnDB.Execute "SELECT * FROM StockTake"
			//*Updating the StockTake_Add field
			// cnnDB.Execute "UPDATE StockTake SET StockTake.StockTake_Add = " & adoPrimaryRS("StockTake_Adjustment") & " WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
			//check = adoPrimaryRS("StockTake_Add")

			//*

		}

		public void Update_Handheld()
		{
			int lQuantity = 0;

			adoPrimaryRS = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, " + modApplication.stTableName + ".Quantity, StockItem.StockItem_Quantity," + modApplication.stTableName + ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" + modApplication.stTableName + " INNER JOIN StockItem ON " + modApplication.stTableName + ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " + gID + ") And ((Warehouse.WarehouseID) = 2) And ((StockItem.StockItem_Disabled) = False) And ((StockItem.StockItem_Discontinued) = False)) ORDER BY StockItem.StockItem_Name");

			//Set adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name," & stTableName & ".Quantity,StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID,StockItem.StockItem_Quantity,StockTake.StockTake_WarehouseID," & stTableName & ".HandHeldID FROM " & _
			//'                  "(StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN " & stTableName & " ON StockItem.StockItemID = " & stTableName & ".HandHeldID WHERE StockTake.StockTake_WarehouseID = 2 AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ORDER BY StockItem.StockItem_Name;")

			if (adoPrimaryRS.RecordCount > 0) {
				while (adoPrimaryRS.EOF == false) {
					lQuantity = adoPrimaryRS.Fields("Quantity").Value;

					modRecordSet.cnnDB.Execute("UPDATE StockTake SET StockTake.StockTake_Quantity = " + lQuantity + " WHERE (((StockTake.StockTake_StockItemID)=" + adoPrimaryRS.Fields("StockTake_StockItemID").Value + ") AND ((StockTake.StockTake_WarehouseID)=2));");
					modRecordSet.cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = " + lQuantity + " WHERE (((StockTake.StockTake_StockItemID)=" + adoPrimaryRS.Fields("StockTake_StockItemID").Value + ") AND ((StockTake.StockTake_WarehouseID)=2));");
					modRecordSet.cnnDB.Execute("UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" + lQuantity + ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" + adoPrimaryRS.Fields("StockTake_StockItemID").Value + "));");
					adoPrimaryRS.moveNext();
				}
			}
			doDiskFlush();
		}
		private void doDiskFlush()
		{
			//Exit Sub
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			int hkey = 0;
			int lRetVal = 0;
			int vValue = 0;
			string lPath = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			int lID = 0;
			lID = adoPrimaryRS.Fields("StockTake_StockItemID").Value;
			lRetVal = modUtilities.RegOpenKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\4POS", 0, modUtilities.KEY_QUERY_VALUE, ref hkey);
			lRetVal = modUtilities.QueryValueEx(hkey, "master", ref vValue);
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
			 // ERROR: Not supported in C#: OnErrorStatement


			if (blHandHeld == true) {
				update_Renamed();
				Update_Handheld();
			} else {
				update_Renamed();
			}
			//Set adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where StockGroup.StockGroupID = 1 And StockTake.StockTake_WarehouseID = 2  AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ORDER BY StockItem.StockItem_Name;")

			cmdPrintSlip_Click(cmdPrintSlip, new System.EventArgs());
			//*/

			decimal lQuantity = default(decimal);
			decimal AsHoldOriginal = default(decimal);

			//AsHoldOriginal = adoPrimaryRS("StockTake_Quantity").OriginalValue


			adoPrimaryRS.MoveFirst();
			if (blHandHeld == true) {
				if (adoPrimaryRS.Fields("Quantity").OriginalValue != adoPrimaryRS.Fields("Quantity").Value) {
					lQuantity = adoPrimaryRS.Fields("Quantity").Value;
					modRecordSet.cnnDB.Execute("UPDATE " + modApplication.stTableName + " SET Quantity = " + lQuantity + " WHERE " + modApplication.stTableName + ".HandHeldID = " + adoPrimaryRS.Fields("StockTake_StockItemID").Value);
					doDiskFlush();
				}

			} else {

				//cnnDB.Execute "SELECT * FROM StockTake"
				adoPrimaryRS.MoveFirst();
				//* Adding stock to quantity

				while (!(adoPrimaryRS.EOF)) {

					if (adoPrimaryRS.Fields("StockTake_Adjustment").Value > 0 | adoPrimaryRS.Fields("StockTake_Adjustment").Value < 0) {
						AsHoldOriginal = adoPrimaryRS.Fields("StockTake_Adjustment").Value;
						//Setting the StockTake_Adjustment to it's original value
						adoPrimaryRS.Fields("StockTake_Adjustment").Value = 0;
						lQuantity = AsHoldOriginal + adoPrimaryRS.Fields("StockTake_Quantity").OriginalValue;
						//Adding the Cases in stock and Current units in stock
						modRecordSet.cnnDB.Execute("INSERT INTO StockTakeDetail ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment, StockTake_DayEndID, StockTake_Note, StockTake_DateTime ) SELECT " + adoPrimaryRS.Fields("StockTake_StockItemID").Value + ", 2, " + lQuantity + ", " + AsHoldOriginal + ", Company_DayEndID, '" + Strings.Replace(txtSARef.Text, "'", "''") + "', #" + DateAndTime.Now + "# FROM Company;");
						//*
						//lQuantity = AsHoldOriginal - adoPrimaryRS("StockTake_Quantity").OriginalValue
						modRecordSet.cnnDB.Execute("UPDATE StockTake SET StockTake.StockTake_Quantity = (" + lQuantity + ") WHERE (((StockTake.StockTake_StockItemID)=" + adoPrimaryRS.Fields("StockTake_StockItemID").Value + ") AND ((StockTake.StockTake_WarehouseID)=2));");
						modRecordSet.cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = (" + lQuantity + ") WHERE (((StockTake.StockTake_StockItemID)=" + adoPrimaryRS.Fields("StockTake_StockItemID").Value + ") AND ((StockTake.StockTake_WarehouseID)=2));");
						modRecordSet.cnnDB.Execute("UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" + AsHoldOriginal + ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" + adoPrimaryRS.Fields("StockTake_StockItemID").Value + "));");
						//*
						// cnnDB.Execute "UPDATE StockTake SET StockTake.StockTake_Quantity = (" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
						// cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = (" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
						//cnnDB.Execute "UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = (" & lQuantity & ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & "));"
						// cnnDB.Execute "UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = DayEndStockItemLnk_QuantityShrink -(" & AsHoldOriginal & "),DayEndStockItemLnk_AddQuantityShrink =(" & AsHoldOriginal & ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & "));"

						doDiskFlush();

					}
					adoPrimaryRS.moveNext();
				}

			}

			//*/


			//Set adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where StockGroup.StockGroupID = 1 And StockTake.StockTake_WarehouseID = 2  AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ORDER BY StockItem.StockItem_Name;")

			this.Close();

			return;
			ERRP:
			//If adoPrimaryRS.EOF Then
			//Else
			//MsgBox Err.Description
			//Resume Next
			if (blHandHeld == true)
				return;
			//End If
			this.Close();
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

		private void grdDataGrid1_CellValueChanged(System.Object eventSender, DataGridViewCellEventArgs eventArgs)
		{
			//    If grdDataGrid1.Columns(ColIndex).DataFormat.Format = "#,##0.00" Then
			//       grdDataGrid1.Columns(ColIndex).DataFormat = 0
			//    End If

		}
	}
}
