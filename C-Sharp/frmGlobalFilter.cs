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
	internal partial class frmGlobalFilter : System.Windows.Forms.Form
	{
		int gID;
		string gFilter;
		string gFilterSQL;

		short gSection;
		ADODB.Recordset gRS;

		int gSect;
		int g_UpdateID;
		string g_SectString;

//Update Sequence...
		bool gAll;
		bool gLoad;
		bool c_Scale;
		bool c_Barcode;
		bool c_cmbUpPrint;
		bool c_PosOveride;
		bool c_NonWeighted;
		bool c_chkDisabled;
		bool c_chkDisconti;
		bool c_cmbUpPricing;
		bool c_cmbSupplier;
		bool c_AllowFraction;
		bool c_SerialTracing;
		bool c_ReportGroups;

		bool c_UndoPosOveride;

		List<RadioButton> OprBarcode = new List<RadioButton>();

		private void loadLanguage()
		{
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2431;
			//Global Update|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2432;
			//Global Cost|Checked
			if (modRecordSet.rsLang.RecordCount){Command1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Command1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1006;
			//Filter|Checked
			if (modRecordSet.rsLang.RecordCount){Frame1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Frame1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lblHeading = No Code   [Using the "Stock Item Selector".....]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblHeading.Caption = rsLang("LanguageLayoutLnk_Description"): lblHeading.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1006;
			//Filter|Checked
			if (modRecordSet.rsLang.RecordCount){Command3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Command3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2499;
			//Field(s) to Update|Checked
			if (modRecordSet.rsLang.RecordCount){Frame2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Frame2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1032;
			//This is a scale product|Checked
			if (modRecordSet.rsLang.RecordCount){chkScale.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;chkScale.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1033;
			//This is a scale item non-weight|Checked
			if (modRecordSet.rsLang.RecordCount){chkNonWeigted.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;chkNonWeigted.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1034;
			//Allow fractions|Checked
			if (modRecordSet.rsLang.RecordCount){chkAllowFractions.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;chkAllowFractions.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2453;
			//POS Price Override (SQ)|Checked
			if (modRecordSet.rsLang.RecordCount){chkPosOveride.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;chkPosOveride.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1037;
			//Serial Tracking|Checked
			if (modRecordSet.rsLang.RecordCount){chkSerialTracking.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;chkSerialTracking.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//NOTE: BD Entry 2455 needs a "&&" for correct display!
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2455;
			//Shelf & Barcode Printing|
			if (modRecordSet.rsLang.RecordCount){Label4.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label4.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2456;
			//Shelf|Checked
			if (modRecordSet.rsLang.RecordCount){OprBarcode[0].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;OprBarcode[0].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1838;
			//Barcode|Checked
			if (modRecordSet.rsLang.RecordCount){OprBarcode[1].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;OprBarcode[1].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2458;
			//None|Checked
			if (modRecordSet.rsLang.RecordCount){OprBarcode[2].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;OprBarcode[2].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2459;
			//New Supplier|Checked
			if (modRecordSet.rsLang.RecordCount){Label6.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label6.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2460;
			//New Pricing group|Checked
			if (modRecordSet.rsLang.RecordCount){Label5.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label5.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2461;
			//New Printing Location|Checked
			if (modRecordSet.rsLang.RecordCount){Label3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//Label1 = No Code       [Report Groups]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2463;
			//Disabled|Checked
			if (modRecordSet.rsLang.RecordCount){chkDisable.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;chkDisable.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2464;
			//Update|Checked
			if (modRecordSet.rsLang.RecordCount){cmdUpdate.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdUpdate.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2465;
			//Discontinued|Checked
			if (modRecordSet.rsLang.RecordCount){chkDiscontinued.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;chkDiscontinued.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2466;
			//Undo changes|Checked
			if (modRecordSet.rsLang.RecordCount){Frame3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Frame3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2467;
			//Undo POS Price Overide|Checked
			if (modRecordSet.rsLang.RecordCount){chkUndoPosOveride.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;chkUndoPosOveride.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2468;
			//Undo Update|Checked
			if (modRecordSet.rsLang.RecordCount){cmdUndo.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdUndo.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmGlobalFilter.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void chkAllowFractions_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (chkAllowFractions.CheckState == 1)
				c_AllowFraction = true;
		}
		private void chkNonWeigted_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (chkNonWeigted.CheckState == 1)
				c_NonWeighted = true;
		}
		private void chkPosOveride_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (chkPosOveride.CheckState == 1)
				c_PosOveride = true;
		}
		private void chkUndoPosOveride_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (chkUndoPosOveride.CheckState == 1)
				c_UndoPosOveride = true;
		}
		private void chkScale_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (chkScale.CheckState == 1)
				c_Scale = true;
		}
		private void chkSerialTracking_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (chkSerialTracking.CheckState == 1)
				c_SerialTracing = true;
		}

		private void cmbReportGroups_Change(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (!string.IsNullOrEmpty(cmbReportGroups.BoundText))
				c_ReportGroups = true;
		}

		private void cmbUpPricing_Change(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (!string.IsNullOrEmpty(cmbUpPricing.BoundText))
				c_cmbUpPricing = true;

		}

		private void cmbUpPrinting_Change(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (!string.IsNullOrEmpty(cmbUpPrinting.Text))
				c_cmbUpPrint = true;
		}

		private void cmdUndo_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (c_UndoPosOveride == true) {
				modRecordSet.cnnDB.Execute("Delete StockitemOverwrite.* From StockitemOverwrite ");

			} else {
				Interaction.MsgBox("Check the Undo POS Price Overide ", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Global Update");
				return;
			}

			Interaction.MsgBox("Update Completed Succesfully", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Global Update");

		}

		private void cmdUpdate_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string stString = null;
			ADODB.Recordset rj = default(ADODB.Recordset);

			if (c_Scale == true)
				modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN gGlobalUpdate ON StockItem.StockItemID = gGlobalUpdate.gStockItemID SET StockItem_VariablePrice = " + this.chkScale.CheckState + ";");

			if (c_NonWeighted == true)
				modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN gGlobalUpdate ON StockItem.StockItemID = gGlobalUpdate.gStockItemID SET StockItem_NonWeighted = " + this.chkNonWeigted.CheckState + ";");

			if (c_AllowFraction == true)
				modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN gGlobalUpdate ON StockItem.StockItemID = gGlobalUpdate.gStockItemID SET StockItem_Fractions = " + this.chkAllowFractions.CheckState + ";");

			if (c_SerialTracing == true)
				modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN gGlobalUpdate ON StockItem.StockItemID = gGlobalUpdate.gStockItemID SET StockItem_SerialTracker = " + this.chkSerialTracking.CheckState + ";");

			if (c_ReportGroups == true)
				modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN gGlobalUpdate ON StockItem.StockItemID = gGlobalUpdate.gStockItemID SET StockItem_ReportID = " + Conversion.Val(this.cmbReportGroups.BoundText) + ";");

			if (c_cmbUpPrint == true) {
				modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN gGlobalUpdate ON StockItem.StockItemID = gGlobalUpdate.gStockItemID SET StockItem_PrintLocationID = " + this.cmbUpPrinting.BoundText + ";");
				cmbUpPrinting.BoundText = "";
			}

			if (c_cmbUpPricing == true) {
				modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN gGlobalUpdate ON StockItem.StockItemID = gGlobalUpdate.gStockItemID SET StockItem_PricingGroupID = " + Conversion.Val(this.cmbUpPricing.BoundText) + ";");
				cmbUpPricing.BoundText = "";
			}

			if (c_cmbSupplier == true) {
				modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN gGlobalUpdate ON StockItem.StockItemID = gGlobalUpdate.gStockItemID SET StockItem_SupplierID = " + this.cmpUpSupplier.BoundText + ";");
				this.cmpUpSupplier.BoundText = "";
			}

			if (c_Barcode == true) {
				if (OprBarcode[0].Checked == true) {
					stString = "Shelf";
					modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN gGlobalUpdate ON StockItem.StockItemID = gGlobalUpdate.gStockItemID SET StockItem_SShelf = True;");
					//cnnDB.Execute "UPDATE StockItem INNER JOIN gGlobalUpdate ON StockItem.StockItemID = gGlobalUpdate.gStockItemID SET StockItem_SBarcode = 'Shelf';"
				} else if (OprBarcode[1].Checked == true) {
					stString = "Barcode";
					modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN gGlobalUpdate ON StockItem.StockItemID = gGlobalUpdate.gStockItemID SET StockItem_SBarcode = True;");
					//cnnDB.Execute "UPDATE StockItem INNER JOIN gGlobalUpdate ON StockItem.StockItemID = gGlobalUpdate.gStockItemID SET StockItem_SBarcode = 'Barcode';"
				} else if (OprBarcode[2].Checked == true) {
					stString = "";
					modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN gGlobalUpdate ON StockItem.StockItemID = gGlobalUpdate.gStockItemID SET StockItem.StockItem_SShelf=False, StockItem.StockItem_SBarcode=False ;");
					//cnnDB.Execute "UPDATE StockItem INNER JOIN gGlobalUpdate ON StockItem.StockItemID = gGlobalUpdate.gStockItemID SET StockItem_SBarcode = Null;"
				}
			}

			if (c_PosOveride == true) {
				rj = modRecordSet.getRS(ref "SELECT * FROM gGlobalUpdate;");
				if (rj.RecordCount) {
					rj.MoveFirst();
					while (rj.EOF == false) {
						modRecordSet.cnnDB.Execute("Delete StockitemOverwrite.* From StockitemOverwrite WHERE (((StockitemOverwrite.StockitemOverwriteID)=" + rj.Fields("gStockItemID").Value + "));");
						modRecordSet.cnnDB.Execute("INSERT INTO StockitemOverwrite ( StockitemOverwriteID ) SELECT " + rj.Fields("gStockItemID").Value + ";");
						rj.MoveNext();
					}
				}
			}


			c_Scale = false;
			c_Barcode = false;
			c_cmbUpPrint = false;
			c_PosOveride = false;
			c_UndoPosOveride = false;
			//As Boolean
			c_chkDisabled = false;
			c_chkDisconti = false;
			c_NonWeighted = false;
			c_cmbUpPricing = false;
			c_AllowFraction = false;
			c_SerialTracing = false;
			c_ReportGroups = false;

			Interaction.MsgBox("Update Completed Succesfully", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Global Update");
			Frame2.Enabled = false;

		}
		private void cmpUpSupplier_Change(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (!string.IsNullOrEmpty(this.cmpUpSupplier.BoundText)) {
				c_cmbSupplier = true;
			}

		}
		private void Command1_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmGlobalCost.ShowDialog();
		}

		private void Command2_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modRecordSet.cnnDB.Execute("DELETE * FROM gGlobalUpdate;");
			this.Close();
		}
		private void Command3_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modBResolutions.g_Updatep = true;
			My.MyProject.Forms.frmFilter.loadFilter(ref gFilter);
			gLoad = true;
			getNamespace();
		}


		private void Command4_Click()
		{
		}

		private void frmGlobalFilter_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case System.Windows.Forms.Keys.Escape:
					KeyAscii = 0;
					this.Close();
					break;
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
		private void buildDataControls()
		{
			//4 Updating purposes...
			doDataControl(ref (this.cmbUpPricing), ref "SELECT PricingGroupID, PricingGroup_Name FROM PricingGroup ORDER BY PricingGroup_Name", ref "StockItem_PricingGroupID", ref "PricingGroupID", ref "PricingGroup_Name");
			doDataControl(ref (this.cmpUpSupplier), ref "SELECT SupplierID, Supplier_Name FROM Supplier WHERE Supplier_Disabled=False ORDER BY Supplier_Name", ref "StockItem_SupplierID", ref "SupplierID", ref "Supplier_Name");
			doDataControl(ref (this.cmbUpPrinting), ref "SELECT PrintLocation.* From PrintLocation WHERE (((PrintLocation.PrintLocation_Disabled)=False));", ref "StockItem_PrintLocationID", ref "PrintLocationID", ref "PrintLocation_Name");
			//New Report ID
			doDataControl(ref (this.cmbReportGroups), ref "SELECT ReportGroup.* From ReportGroup WHERE (((ReportGroup.ReportGroup_Disabled)=False));", ref "StockItem_ReportID", ref "ReportID", ref "ReportGroup_Name");

		}
		private void doDataControl(ref myDataGridView dataControl, ref string sql, ref string DataField, ref string boundColumn, ref string listField)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref sql);
			dataControl.DataSource = rs;
			dataControl.boundColumn = boundColumn;
			dataControl.listField = listField;
		}

		//Handles OprBarcode.CheckedChanged
		private void OprBarcode_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.Checked) {
				RadioButton rb = new RadioButton();
				rb = (RadioButton)eventSender;
				int Index = GetIndex.GetIndexer(ref rb, ref OprBarcode);
				c_Barcode = true;

			}
		}

		private void doSearch()
		{
			ADODB.Recordset rj = default(ADODB.Recordset);
			string sql = null;
			string lString = null;

			lString = gFilterSQL;
			if (gAll) {
			} else {
				if (string.IsNullOrEmpty(lString)) {
					lString = " WHERE StockItem.StockItem_Disabled = 0 Or StockItem.StockItem_Discontinued = 0 ";
				} else {
					lString = lString + " AND (StockItem.StockItem_Disabled = 0 Or StockItem.StockItem_Discontinued = 0) ";
				}
			}

			g_SectString = lString;

			gRS = modRecordSet.getRS(ref "SELECT DISTINCT StockItemID, StockItem_Name FROM StockItem " + lString + " ORDER BY StockItem_Name");
			if (gRS.RecordCount > 0 & gLoad == true) {
				My.MyProject.Forms.frmStockItemByGroup.loadItem(ref "SELECT DISTINCT StockItemID, StockItem_Name FROM StockItem " + lString + " ORDER BY StockItem_Name");
				Frame2.Enabled = true;
			}
		}
		private void getNamespace()
		{
			if (string.IsNullOrEmpty(gFilter)) {
				this.lblHeading.Text = "";
			} else {
				My.MyProject.Forms.frmFilter.buildCriteria(ref gFilter);
				this.lblHeading.Text = My.MyProject.Forms.frmFilter.gHeading;
			}
			gFilterSQL = My.MyProject.Forms.frmFilter.gCriteria;
			doSearch();
		}
		public void editItem(ref short lSection)
		{
			modRecordSet.cnnDB.Execute("DELETE ftData.* From ftData");
			modRecordSet.cnnDB.Execute("DELETE ftDataItem.* From ftDataItem");
			buildDataControls();
			gSection = lSection;
			gFilter = "StockItem";
			gLoad = false;
			getNamespace();

			loadLanguage();
			ShowDialog();
		}

		private void frmGlobalFilter_Load(object sender, System.EventArgs e)
		{
			OprBarcode.AddRange(new RadioButton[] {
				_OprBarcode_0,
				_OprBarcode_1,
				_OprBarcode_2
			});
			RadioButton rb = new RadioButton();
			foreach (RadioButton rb_loopVariable in OprBarcode) {
				rb = rb_loopVariable;
				rb.CheckedChanged += OprBarcode_CheckedChanged;
			}
		}
	}
}
