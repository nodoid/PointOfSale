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
	internal partial class frmStockPricing : System.Windows.Forms.Form
	{

		object gVAT;
		decimal gRoundAfter;
		int gRemoveUnits;
		short gRoundDownUnits;
		bool loading;
		int gStockItemID;
		short gChannelID;
		bool gNoPrice;
		bool gCaseToUnit;
		decimal gPriceChannel1;
		ADODB.Recordset rsStockItem;

		decimal priceBox;
		bool ChildPriceChang;
		bool ParentPriceChang;
		bool cmdUndoFocus;

		short ParentPriceID;
		List<GroupBox> frmItem = new List<GroupBox>();
		List<Label> lblSelection = new List<Label>();
		private void loadLanguage()
		{

			//NOTE: DB Entry 1074 needs "&" for accelerator key!
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdUndo.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdUndo.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//NOTE: DB Entry 1838 needs "&" for accelerator key!
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1838;
			//Barcode|Checked
			if (modRecordSet.rsLang.RecordCount){cmdbarcode.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdbarcode.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//cmdDetails = No Code           [Details]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdDetails.Caption = rsLang("LanguageLayoutLnk_Description"): cmdDetails.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdHistory = No Code           [History]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdDetails.Caption = rsLang("LanguageLayoutLnk_Description"): cmdDetails.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdNext = No Code              [&Next Item >]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdNext.Caption = rsLang("LanguageLayoutLnk_Description"): cmdNext.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//NOTE: DB Entry 1004 needs "&" for accelerator key
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1149;
			//Stock Item|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_7.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_7.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lblStockItemName = No Code/Dynamic

			//_lbl_4 = No Code               [Sales Channel]
			//(Closest match 2349, but grammar wrong for use)
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_4.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1021;
			//Pricing Group|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_15.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_15.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lbl(16) = No Code              [Pricing Rule]
			//(Closest match 1067, but grammar wrong for use)
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lbl(16).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(16).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//frmItem(0) = No Code/Dynamic/NA?

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1027;
			//List Cost|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lbl_5 = No Code               [Matrix %]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_5.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_6 = No Code               [Prop %]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_6.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_6.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_2 = No Code               [Unit Deposit]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_3 = No Code               [Case Deposit]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_3.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblVatName = No Code           [VAT at 14%]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblVatName.Caption = rsLang("LanguageLayoutLnk_Description"): lblVatName.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lbl(8) = No Code               [Markup Price]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lbl(8).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(8).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lbl(9) = No Code               [Override Price]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lbl(9).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(9).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1151;
			//Price|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_10.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_10.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lbl(11) = No Code              [Markup %]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lbl(11).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(11).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_0 = No Code               [GP %]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1995;
			//Actual|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_18.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_18.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1028;
			//Actual Cost|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_12.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_12.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lbl(13) = No Code              [Profit Amount]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lbl(13).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(13).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lbl(14) = No Code (Uses same code as lbl(11))
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lbl(14).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(14).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lbl(17) = No Code              [Margin %]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lbl(17).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(17).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblPriceSet = No Code/Dynamic? [No Action]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblPriceSet.Caption = rsLang("LanguageLayoutLnk_Description"): lblPriceSet.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmStockPricing.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

//Dim WithEvents adoPrimaryRS As Recordset
//UPGRADE_WARNING: Event cmbChannel.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void cmbChannel_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (loading)
				return;
			doChannel();
			System.Windows.Forms.Application.DoEvents();
			if (this.Visible) {
				cmbChannel.Focus();
			}
		}

		public void loadItem(ref int id)
		{
			int blCust = 0;
			int ctSelling = 0;
			bool visable = false;
			ADODB.Recordset rsProp = default(ADODB.Recordset);
			loading = true;
			ADODB.Recordset rsChannel = default(ADODB.Recordset);
			ADODB.Recordset rsQuantity = default(ADODB.Recordset);
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;

			short x = 0;
			decimal lQuantity = default(decimal);
			decimal lDepositQuantity = default(decimal);
			decimal lCost = default(decimal);
			decimal lActualCost = default(decimal);
			decimal lDepositUnit = default(decimal);
			decimal lDepositPack = default(decimal);

			sql = "INSERT INTO Catalogue ( Catalogue_StockItemID, Catalogue_Quantity, Catalogue_Barcode, Catalogue_Deposit, Catalogue_Content, Catalogue_Disabled ) ";
			sql = sql + "SELECT theJoin.StockItemID, theJoin.ShrinkItem_Quantity, 'CODE' AS Expr1, 0 AS deposit, 0 AS content, 0 AS disabled FROM [SELECT StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity FROM ShrinkItem INNER JOIN ";
			sql = sql + "StockItem ON ShrinkItem.ShrinkItem_ShrinkID = StockItem.StockItem_ShrinkID]. AS theJoin LEFT JOIN Catalogue ON (theJoin.ShrinkItem_Quantity = Catalogue.Catalogue_Quantity) AND (theJoin.StockItemID = Catalogue.Catalogue_StockItemID) ";
			sql = sql + "WHERE (((theJoin.StockItemID)=" + id + ") AND ((Catalogue.Catalogue_StockItemID) Is Null));";
			modRecordSet.cnnDB.Execute(sql);

			sql = "SELECT StockItem.StockItemID, StockItem.StockItem_PackSizeID, StockItem.StockItem_Name, StockItem.StockItem_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_ActualCost, StockItem.StockItem_PriceSetID, Deposit.Deposit_UnitCost, Deposit.Deposit_CaseCost, Vat.Vat_Amount, Supplier.Supplier_Name, PricingGroup.PricingGroupID, PricingGroup.PricingGroup_Name, PricingGroup.PricingGroup_RemoveCents, PricingGroup.PricingGroup_RoundAfter, PricingGroup.PricingGroup_RoundDown, PricingGroup.PricingGroup_Unit1, PricingGroup.PricingGroup_Case1, PricingGroup.PricingGroup_Unit2, PricingGroup.PricingGroup_Case2, PricingGroup.PricingGroup_Unit3, PricingGroup.PricingGroup_Case3, PricingGroup.PricingGroup_Unit4, PricingGroup.PricingGroup_Case4, PricingGroup.PricingGroup_Unit5, PricingGroup.PricingGroup_Case5, PricingGroup.PricingGroup_Unit6, PricingGroup.PricingGroup_Case6, PricingGroup.PricingGroup_Unit7, PricingGroup.PricingGroup_Case7, PricingGroup.PricingGroup_Unit8, PricingGroup.PricingGroup_Case8 ";
			sql = sql + "FROM (((StockItem INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Supplier ON StockItem.StockItem_SupplierID = Supplier.SupplierID WHERE (((StockItem.StockItemID)=" + id + "));";
			rsStockItem = modRecordSet.getRS(ref sql);

			rsChannel = modRecordSet.getRS(ref "SELECT ChannelID, Channel_Name From Channel WHERE (Channel_Disabled = 0) AND (ChannelID <> 9) ORDER BY ChannelID");

			rsQuantity = modRecordSet.getRS(ref "SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, Catalogue.Catalogue_Barcode, Catalogue.Catalogue_Deposit, Catalogue.Catalogue_Content, Catalogue.Catalogue_Disabled, ShrinkItem.ShrinkItem_Code FROM Catalogue INNER JOIN (StockItem INNER JOIN ShrinkItem ON StockItem.StockItem_ShrinkID = ShrinkItem.ShrinkItem_ShrinkID) ON (ShrinkItem.ShrinkItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID) Where (((Catalogue.Catalogue_StockItemID) = " + id + ")) ORDER BY Catalogue.Catalogue_Quantity;");

			rsProp = modRecordSet.getRS(ref "SELECT PropChannelLnk.PropChannelLnk_Quantity, PropChannelLnk.PropChannelLnk_ChannelID, PropChannelLnk.PropChannelLnk_Markup From PropChannelLnk WHERE (((PropChannelLnk.PropChannelLnk_StockItemID)=" + id + "));");
			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			if (Information.IsDBNull(rsStockItem.Fields("StockItem_PriceSetID").Value)) {
			} else {
				rs = modRecordSet.getRS(ref "SELECT PriceSet.PriceSetID, [PriceSet_Name] & '(' & [StockItem_Name] & ')' AS priceSet_FullName, PriceSet.PriceSet_StockItemID FROM StockItem INNER JOIN PriceSet ON StockItem.StockItem_PriceSetID = PriceSet.PriceSetID WHERE (((StockItem.StockItemID)=" + id + ") AND ((PriceSet.PriceSet_Disabled)=0));");
				if (rs.RecordCount) {
					if (rs.Fields("PriceSet_StockItemID").Value == id) {
						lblPriceSet.Text = "Primary Pricing Set Item";
						lblPriceSet.Visible = true;
						lblPriceSet.BackColor = System.Drawing.Color.Red;
						lblPriceSet.ForeColor = System.Drawing.Color.White;
					} else {
						_txtProp_0.Enabled = false;
						_txtPrice_0.Enabled = false;
						lblPriceSet.Text = "Child Pricing Set Item";
						lblPriceSet.Visible = true;
						lblPriceSet.BackColor = System.Drawing.Color.Yellow;
						lblPriceSet.ForeColor = System.Drawing.Color.Black;
					}
				}
			}
			saveData();
			if (rsStockItem.BOF | rsStockItem.EOF) {
			} else {
				gStockItemID = id;
				gChannelID = 0;
				_txtCost_0.Enabled = false;
				//        _txtVariableCost_0.Enabled = False
				_txtCost_0.BackColor = System.Drawing.ColorTranslator.FromOle(-2147483633);
				_txtVariableCost_0.BackColor = System.Drawing.ColorTranslator.FromOle(-2147483633);
				for (x = 0; x <= frmItem.Count - 1; x++) {
					//txtCost.Unload(x)
					//lblMatrix.Unload(x)
					//txtProp.Unload(x)
					//lblDepositUnit.Unload(x)
					//lblDepositPack.Unload(x)
					//lblVat.Unload(x)
					//lblMarkup.Unload(x)
					//lblGP.Unload(x)
					//txtPrice.Unload(x)
					//lblPrice.Unload(x)
					//lblPercent.Unload(x)
					//lnProfit.Unload(x))
					//txtVariableCost.Unload(x)
					//lblProfitAmount.Unload(x)
					//lblProfitPrecent.Unload(x)
					//lblSection.Unload(x)
					//frmItem.Unload(x)
					//lblGPActual.Unload(x)
				}
				lblVatName.Text = "VAT at " + Strings.FormatNumber(rsStockItem.Fields("Vat_Amount").Value, 2) + "%";
				gVAT = 1 + rsStockItem.Fields("Vat_Amount").Value / 100;
				gRoundAfter = 0;
				gRemoveUnits = 0;
				gRoundDownUnits = 0;
				gRoundAfter = rsStockItem.Fields("PricingGroup_RoundAfter").Value;
				gRemoveUnits = rsStockItem.Fields("PricingGroup_RemoveCents").Value;
				gRoundDownUnits = rsStockItem.Fields("PricingGroup_RoundDown").Value;
				lblPricingGroup.Text = rsStockItem.Fields("PricingGroup_Name").Value;
				lblPricingGroup.Tag = rsStockItem.Fields("PricingGroupID").Value;
				lblPricingGroupRule.Text = " When a Stock Item value is over " + Strings.FormatNumber(gRoundAfter, 2) + " round all amounts below " + gRoundDownUnits + " cents to the lower Rand value, else the amount is rounded to the next highest Rand, then remove " + gRemoveUnits + " cents from the rounded stock item Rand value.";
				lblPricingGroupRule.Tag = lblPricingGroupRule.Text;
				lblStockItemName.Text = rsStockItem.Fields("StockItem_Name").Value;
				lCost = rsStockItem.Fields("StockItem_ListCost").Value;
				lActualCost = rsStockItem.Fields("StockItem_ActualCost").Value;
				lQuantity = rsStockItem.Fields("StockItem_Quantity").Value;
				lDepositUnit = rsStockItem.Fields("Deposit_UnitCost").Value;
				lDepositPack = rsStockItem.Fields("Deposit_CaseCost").Value;
				lDepositQuantity = lQuantity;
				x = -1;

				while (!(rsQuantity.EOF)) {
					x = x + 1;
					//UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (x) {
						//frmItem.Load(x)
						//UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						frmItem[x].Left = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(frmItem[0].Left, true) + (sizeConvertors.pixelToTwips(frmItem[0].Width, true) + 100) * x, true);
						frmItem[x].Visible = true;
						//loadControl(txtCost, x)
						//loadControl(lblMatrix, x)
						//loadControl(picLine, x)
						//loadControl(txtProp, x)
						//loadControl(lblDepositUnit, x)
						//loadControl(lblDepositPack, x)
						//loadControl(lblVat, x)
						//loadControl(lblMarkup, x)
						//loadControl(lblGP, x)
						//loadControl(txtPrice, x)
						//loadControl(lblPrice, x)
						//loadControl(lblPercent, x)
						//loadControl(lnProfit, x)
						//loadControl(txtVariableCost, x)
						//loadControl(lblProfitAmount, x)
						//loadControl(lblProfitPrecent, x)
						//loadControl(lblSection, x)
						//loadControl(lblGPActual, x)
					}
					_lblSection_0.BackColor = System.Drawing.ColorTranslator.FromOle(65280);
					_lblSection_0.Text = "Matrix";
					_frmItem_0.Text = rsQuantity.Fields("ShrinkItem_Code").Value + " (" + rsQuantity.Fields("Catalogue_Quantity").Value + ")";
					_frmItem_0.Tag = rsQuantity.Fields("Catalogue_Quantity").Value;
					_lblDepositUnit_0.Text = Strings.FormatNumber(Convert.ToDouble(frmItem[x].Tag) * lDepositUnit, 2);
					if (lDepositQuantity) {
						_lblDepositPack_0.Text = Strings.FormatNumber(Convert.ToInt16(Convert.ToDouble(frmItem[x].Tag) / lDepositQuantity - 0.49) * lDepositPack, 2);
					} else {
						_lblDepositPack_0.Text = "0.00";
					}
					_txtCost_0.Text = Strings.FormatNumber(lCost / lQuantity * Convert.ToDouble(frmItem[x].Tag), 2);
					_txtCost_0.Tag = _txtCost_0.Text;
					_txtVariableCost_0.Text = Strings.FormatNumber(lActualCost / lQuantity * Convert.ToDouble(frmItem[x].Tag), 2);
					_txtVariableCost_0.Tag = _txtVariableCost_0.Text;

					if (lQuantity == Convert.ToDouble(_frmItem_0.Tag)) {
						_txtCost_0.Enabled = true;
						_txtCost_0.BackColor = System.Drawing.Color.White;
						//_txtVariableCost_0.Enabled = True
						_txtVariableCost_0.BackColor = System.Drawing.Color.White;
					}
					rsQuantity.MoveNext();
				}
				if (x < 3)
					x = 3;
				this.Width = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(frmItem[0].Left, true) + (x + 1) * (sizeConvertors.pixelToTwips(frmItem[0].Width, true) + 100) + 250, true);
				this.lblPricingGroupRule.Width = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(this.Width, true) - sizeConvertors.pixelToTwips(this.lblPricingGroupRule.Left, true) - 250 - 100, true);
				cmbChannel.Items.Clear();
				while (!(rsChannel.EOF)) {
					cmbChannel.Items.Add(new LBI(rsChannel.Fields("Channel_Name").Value, rsChannel.Fields("ChannelID").Value));
					rsChannel.MoveNext();
				}
				cmbChannel.SelectedIndex = 0;
				gChannelID = Convert.ToInt32(cmbChannel.SelectedIndex);
				doChannel();
				if (visable)
					_txtProp_0.Focus();
			}

			loadLanguage();

			loading = false;

			if (blCust == true) {
				_txtPrice_0.Text = Strings.FormatNumber(ctSelling, 2);
				blCust = false;
			}

		}
		private void saveData()
		{
			short x = 0;
			string sql = null;
			if (gStockItemID) {
				modApplication.RecipeCost();
				saveChannel();
				for (x = 0; x <= frmItem.Count - 1; x++) {
					if (_txtCost_0.Enabled) {
						if (_txtCost_0.Text != _txtCost_0.Tag) {
							sql = "UPDATE StockItem SET StockItem_ListCost = " + Strings.Replace(_txtCost_0.Text, ",", "") + " WHERE StockItemID=" + gStockItemID;
							modRecordSet.cnnDB.Execute(sql);
							if (ParentPriceChang == true) {
								sql = "UPDATE StockItem SET StockItem_ListCost = " + Strings.Replace(_txtCost_0.Text, ",", "") + " WHERE StockItemID=" + ParentPriceID;
								modRecordSet.cnnDB.Execute(sql);
							}
						}
						_txtCost_0.Tag = _txtCost_0.Text;
						if (_txtVariableCost_0.Text != _txtVariableCost_0.Tag) {
							sql = "UPDATE StockItem SET StockItem_ActualCost = " + Strings.Replace(_txtVariableCost_0.Text, ",", "") + " WHERE StockItemID=" + gStockItemID;
							modRecordSet.cnnDB.Execute(sql);
							if (ParentPriceChang == true) {
								sql = "UPDATE StockItem SET StockItem_ActualCost = " + Strings.Replace(this._txtVariableCost_0.Text, ",", "") + " WHERE StockItemID=" + ParentPriceID;
								modRecordSet.cnnDB.Execute(sql);
							}
						}
						this._txtVariableCost_0.Tag = this._txtVariableCost_0.Text;
					}
				}
				if (loading) {
				} else {
					if (!string.IsNullOrEmpty(sql)) {
						sql = "INSERT INTO tempStockItem (tempStockItemID) SELECT StockItem.StockItemID FROM tempStockItem RIGHT OUTER JOIN StockItem ON tempStockItem.tempStockItemID = StockItem.StockItemID Where (StockItem.StockItemID = " + gStockItemID + ") And (tempStockItem.tempStockItemID Is Null)";
						modRecordSet.cnnDB.Execute(sql);
					}
				}
			}

		}
		private void saveChannel()
		{
			short x = 0;
			string sql = null;
			if (gStockItemID) {
				if (gChannelID) {
					if (this.Visible)
						this.cmdExit.Focus();
					System.Windows.Forms.Application.DoEvents();

					for (x = 0; x <= frmItem.Count - 1; x++) {


						if (_txtProp_0.Text != _txtProp_0.Tag) {
							sql = "DELETE FROM PropChannelLnk WHERE PropChannelLnk_Quantity=" + frmItem[x].Tag + " AND PropChannelLnk_ChannelID=" + gChannelID + " AND PropChannelLnk_StockItemID=" + gStockItemID;
							modRecordSet.cnnDB.Execute(sql);
							if (!string.IsNullOrEmpty(_txtProp_0.Text)) {
								sql = "INSERT INTO PropChannelLnk (PropChannelLnk_StockItemID, PropChannelLnk_Quantity, PropChannelLnk_ChannelID, PropChannelLnk_Markup) VALUES (" + gStockItemID + ", " + frmItem[x].Tag + ", " + gChannelID + ", " + Strings.Replace(_txtProp_0.Text, ",", "") + ")";
								modRecordSet.cnnDB.Execute(sql);
							}
							_txtProp_0.Tag = _txtProp_0.Text;
						}
						if (_txtPrice_0.Text != _txtPrice_0.Tag) {
							sql = "DELETE FROM PriceChannelLnk WHERE PriceChannelLnk_Quantity=" + frmItem[x].Tag + " AND PriceChannelLnk_ChannelID=" + gChannelID + " AND PriceChannelLnk_StockItemID=" + gStockItemID;
							modRecordSet.cnnDB.Execute(sql);
							if (!string.IsNullOrEmpty(_txtPrice_0.Text)) {
								sql = "INSERT INTO PriceChannelLnk (PriceChannelLnk_StockItemID, PriceChannelLnk_Quantity, PriceChannelLnk_ChannelID, PriceChannelLnk_Price) VALUES (" + gStockItemID + ", " + frmItem[x].Tag + ", " + gChannelID + ", " + Strings.Replace(_txtPrice_0.Text, ",", "") + ")";
								modRecordSet.cnnDB.Execute(sql);
							}
							_txtPrice_0.Tag = _txtPrice_0.Text;
						}
					}
					if (loading) {
					} else {
						if (!string.IsNullOrEmpty(sql)) {
							sql = "INSERT INTO tempStockItem (tempStockItemID) SELECT StockItem.StockItemID FROM tempStockItem RIGHT OUTER JOIN StockItem ON tempStockItem.tempStockItemID = StockItem.StockItemID Where (StockItem.StockItemID = " + gStockItemID + ") And (tempStockItem.tempStockItemID Is Null)";
							modRecordSet.cnnDB.Execute(sql);
						}

						if (System.Drawing.ColorTranslator.ToOle(lblPriceSet.BackColor) == System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)) {
							modRecordSet.cnnDB.Execute("UPDATE (StockItem INNER JOIN PriceSet ON StockItem.StockItem_PriceSetID = PriceSet.PriceSetID) INNER JOIN StockItem AS StockItem_1 ON PriceSet.PriceSet_StockItemID = StockItem_1.StockItemID SET StockItem.StockItem_ShrinkID = [StockItem_1]![StockItem_ShrinkID], StockItem.StockItem_PricingGroupID = [StockItem_1]![StockItem_PricingGroupID], StockItem.StockItem_VatID = [StockItem_1]![StockItem_VatID], StockItem.StockItem_DepositID = [StockItem_1]![StockItem_DepositID], StockItem.StockItem_Quantity = [StockItem_1]![StockItem_Quantity], StockItem.StockItem_ListCost = [StockItem_1]![StockItem_ListCost] WHERE (((PriceSet.PriceSet_Disabled)=0) AND ((StockItem.StockItemID)<>[StockItem_1]![StockItemID]) AND (StockItem_1.StockItemID)=" + rsStockItem.Fields("StockitemID").Value + ");");
							modRecordSet.cnnDB.Execute("DELETE PropChannelLnk.* FROM (StockItem INNER JOIN PriceSet ON StockItem.StockItem_PriceSetID = PriceSet.PriceSetID) INNER JOIN PropChannelLnk ON StockItem.StockItemID = PropChannelLnk.PropChannelLnk_StockItemID WHERE (((PriceSet.PriceSet_Disabled)=0) AND ((StockItem.StockItemID)<>[PriceSet]![PriceSet_StockItemID]) AND ((PriceSet.PriceSetID)=" + rsStockItem.Fields("Stockitem_PriceSetID").Value + "));");
							modRecordSet.cnnDB.Execute("DELETE PriceChannelLnk.* FROM (StockItem INNER JOIN PriceSet ON StockItem.StockItem_PriceSetID = PriceSet.PriceSetID) INNER JOIN PriceChannelLnk ON StockItem.StockItemID = PriceChannelLnk.PriceChannelLnk_StockItemID WHERE (((PriceSet.PriceSet_Disabled)=0) AND ((StockItem.StockItemID)<>[PriceSet]![PriceSet_StockItemID]) AND ((PriceSet.PriceSetID)=" + rsStockItem.Fields("Stockitem_PriceSetID").Value + "));");
							modRecordSet.cnnDB.Execute("INSERT INTO PriceChannelLnk ( PriceChannelLnk_StockItemID, PriceChannelLnk_Quantity, PriceChannelLnk_ChannelID, PriceChannelLnk_Price ) SELECT StockItem.StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price FROM (StockItem INNER JOIN PriceSet ON StockItem.StockItem_PriceSetID = PriceSet.PriceSetID) INNER JOIN PriceChannelLnk ON PriceSet.PriceSet_StockItemID = PriceChannelLnk.PriceChannelLnk_StockItemID WHERE (((StockItem.StockItemID)<>[PriceSet]![PriceSet_StockItemID]) AND ((PriceSet.PriceSet_Disabled)=0) AND ((PriceSet.PriceSetID)=" + rsStockItem.Fields("Stockitem_PriceSetID").Value + "));");
							modRecordSet.cnnDB.Execute("INSERT INTO PropChannelLnk ( PropChannelLnk_StockItemID, PropChannelLnk_Quantity, PropChannelLnk_ChannelID, PropChannelLnk_Markup ) SELECT StockItem.StockItemID, PropChannelLnk.PropChannelLnk_Quantity, PropChannelLnk.PropChannelLnk_ChannelID, PropChannelLnk.PropChannelLnk_Markup FROM (StockItem INNER JOIN PriceSet ON StockItem.StockItem_PriceSetID = PriceSet.PriceSetID) INNER JOIN PropChannelLnk ON PriceSet.PriceSet_StockItemID = PropChannelLnk.PropChannelLnk_StockItemID WHERE (((StockItem.StockItemID)<>[PriceSet]![PriceSet_StockItemID]) AND ((PriceSet.PriceSet_Disabled)=0) AND ((PriceSet.PriceSetID)=" + rsStockItem.Fields("Stockitem_PriceSetID").Value + "));");
							modRecordSet.cnnDB.Execute("INSERT INTO tempStockItem ( tempStockItemID ) SELECT StockItem.StockItemID FROM tempStockItem RIGHT JOIN StockItem ON tempStockItem.tempStockItemID = StockItem.StockItemID WHERE (((tempStockItem.tempStockItemID) Is Null) AND ((StockItem.StockItem_PriceSetID)=" + rsStockItem.Fields("Stockitem_PriceSetID").Value + "));");

						}

					}
				}
			}
		}

		private decimal calcPrice(ref short Index)
		{
			decimal functionReturnValue = default(decimal);
			int lPrice = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			decimal lMarkup = default(decimal);
			decimal lDeposit = default(decimal);
			decimal lPrivr = default(decimal);
			decimal lCost = default(decimal);
			decimal lQty = default(decimal);
			lQty = Convert.ToInt16(frmItem[Index].Tag);
			rs = modRecordSet.getRS(ref "SELECT PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk WHERE (((PriceChannelLnk.PriceChannelLnk_StockItemID)=" + gStockItemID + ") AND ((PriceChannelLnk.PriceChannelLnk_ChannelID)=1) AND ((PriceChannelLnk.PriceChannelLnk_Quantity)=" + lQty + "));");
			if (rs.RecordCount) {
				functionReturnValue = rs.Fields(0).Value;
			} else {
				rs = modRecordSet.getRS(ref "SELECT PropChannelLnk.PropChannelLnk_Markup From PropChannelLnk WHERE (((PropChannelLnk.PropChannelLnk_StockItemID)=" + gStockItemID + ") AND ((PropChannelLnk.PropChannelLnk_Quantity)=" + lQty + ") AND ((PropChannelLnk.PropChannelLnk_ChannelID)=1));");
				if (rs.RecordCount) {
					lMarkup = rs.Fields(0).Value;
				} else {
					if (lQty > 1) {
						lMarkup = rsStockItem.Fields("PricingGroup_Case1").Value;
					} else {
						lMarkup = rsStockItem.Fields("PricingGroup_Unit1").Value;
					}
				}
				lDeposit = Convert.ToDecimal(_lblDepositPack_0.Text) + Convert.ToDecimal(_lblDepositUnit_0.Text);
				lCost = Convert.ToDecimal(_txtCost_0.Text);
				lMarkup = 1 + lMarkup / 100;
				lPrice = (lCost * lMarkup + lDeposit) * gVAT + 0.0049;

				if (lPrice > gRoundAfter & gNoPrice == false) {
					if (lPrice * 100 % 100 <= gRoundDownUnits) {
						if (Strings.InStr(lPrice, "."))
							lPrice = Convert.ToDecimal(Strings.Left(lPrice, Strings.InStr(lPrice, ".")));
						lPrice = lPrice;
					} else {
						if (Strings.InStr(lPrice, "."))
							lPrice = Convert.ToDecimal(Strings.Left(lPrice, Strings.InStr(lPrice, ".")));
						lPrice = lPrice + 1;
					}
					lPrice = lPrice - gRemoveUnits / 100;
				} else {
					lPrice = System.Math.Round(lPrice + 0.045, 1);
				}


				functionReturnValue = lPrice;
			}
			return functionReturnValue;

		}

		private void doChannel()
		{
			short x = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			saveChannel();
			gChannelID = Convert.ToInt32(cmbChannel.SelectedIndex);
			rs = modRecordSet.getRS(ref "SELECT * FROM Channel WHERE ChannelID = " + gChannelID);
			gNoPrice = rs.Fields("Channel_NoPricing").Value;
			gCaseToUnit = rs.Fields("Channel_ShrinkIncrement").Value;
			if (Information.IsDBNull(rs.Fields("Channel_MarkupType").Value)) {
				lblPricingGroupRule.Text = lblPricingGroupRule.Tag;
				gPriceChannel1 = -1;
			} else {
				if (rs.Fields("Channel_MarkupType").Value) {
					lblPricingGroupRule.Text = "This sale channel has been set to the default sale channels price plus the percentage defined in the department.";

					gPriceChannel1 = 0;
				} else {
					lblPricingGroupRule.Text = lblPricingGroupRule.Tag;
					gPriceChannel1 = -1;
				}
			}
			rs.Close();
			if (gPriceChannel1 != -1) {
				rs = modRecordSet.getRS(ref "SELECT * FROM Channel WHERE ChannelID = " + gChannelID);
			}
			if (cmbChannel.SelectedIndex != -1) {
				for (x = 0; x <= frmItem.Count - 1; x++) {
					if (gPriceChannel1 == -1) {
						_lblMatrix_0.Tag = "";
					} else {
						//Set rs = getRS("SELECT CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)=" & frmItem(x).Tag & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)=" & gStockItemID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
						_lblMatrix_0.Tag = calcPrice(ref x);
					}

					rs = modRecordSet.getRS(ref "SELECT PricingGroupChannelLnk.PricingGroupChannelLnk_Markup From PricingGroupChannelLnk WHERE (((PricingGroupChannelLnk.PricingGroupChannelLnk_PricingGroupID)=" + rsStockItem.Fields("PricingGroupID").Value + ") AND ((PricingGroupChannelLnk.PricingGroupChannelLnk_Quantity)=" + frmItem[x].Tag + ") AND ((PricingGroupChannelLnk.PricingGroupChannelLnk_PackSizeID)=" + rsStockItem.Fields("StockItem_PackSizeID").Value + ") AND ((PricingGroupChannelLnk.PricingGroupChannelLnk_ChannelID)=" + gChannelID + "));");

					//_lblMatrix_0.Font = FontStyle.Bold
					if (rs.BOF | rs.EOF) {
						if (Convert.ToInt16(frmItem[x].Tag) > 1) {
							_lblMatrix_0.Text = Strings.FormatNumber(rsStockItem.Fields("PricingGroup_Case" + gChannelID).Value, 2);
						} else {
							_lblMatrix_0.Text = Strings.FormatNumber(rsStockItem.Fields("PricingGroup_Unit" + gChannelID).Value, 2);
						}
					} else {
						_lblMatrix_0.Text = Strings.FormatNumber(rs.Fields("PricingGroupChannelLnk_Markup").Value, 2);
					}


					rs = modRecordSet.getRS(ref "SELECT PropChannelLnk.PropChannelLnk_Markup From PropChannelLnk WHERE (((PropChannelLnk.PropChannelLnk_StockItemID)=" + gStockItemID + ") AND ((PropChannelLnk.PropChannelLnk_Quantity)=" + frmItem[x].Tag + ") AND ((PropChannelLnk.PropChannelLnk_ChannelID)=" + gChannelID + "));");
					if (rs.BOF | rs.EOF) {
						_txtProp_0.Text = "";
					} else {
						_txtProp_0.Text = Strings.FormatNumber(rs.Fields("PropChannelLnk_Markup").Value, 2);
					}
					rs.Close();
					_txtProp_0.Tag = _txtProp_0.Text;
					rs = modRecordSet.getRS(ref "SELECT PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk WHERE (((PriceChannelLnk.PriceChannelLnk_StockItemID)=" + gStockItemID + ") AND ((PriceChannelLnk.PriceChannelLnk_Quantity)=" + frmItem[x].Tag + ") AND ((PriceChannelLnk.PriceChannelLnk_ChannelID)=" + gChannelID + "));");

					if (rs.BOF | rs.EOF) {
						_txtPrice_0.Text = "";

					} else {

						_txtPrice_0.Text = Strings.FormatNumber(rs.Fields("PriceChannelLnk_Price").Value, 2);
					}



					rs.Close();
					_txtPrice_0.Tag = _txtPrice_0.Text;
					Calculate(ref x);
				}
			}
		}

		private void loadControl(ref object lControl, ref int Index)
		{
			lControl.Load(Index);
			lControl(Index).Container = frmItem[Index];
			lControl(Index).Visible = true;
		}
		private void Calculate(ref short Index)
		{
			decimal templPrice = default(decimal);
			decimal lCost = default(decimal);
			decimal lDeposit = default(decimal);
			decimal lMarkup = default(decimal);
			decimal lPrice = default(decimal);

			 // ERROR: Not supported in C#: OnErrorStatement


			lDeposit = Convert.ToDecimal(_lblDepositPack_0.Text) + Convert.ToDecimal(_lblDepositUnit_0.Text);
			lCost = Convert.ToDecimal(_txtCost_0.Text);
			_lblSection_0.BackColor = System.Drawing.ColorTranslator.FromOle(65280);
			_lblSection_0.ForeColor = System.Drawing.Color.Black;
			_lblSection_0.Text = "Matrix";

			lMarkup = Convert.ToDecimal(_lblMatrix_0.Text);
			if (!string.IsNullOrEmpty(_txtProp_0.Text)) {
				lMarkup = _txtProp_0.Text;
				_lblSection_0.BackColor = System.Drawing.ColorTranslator.FromOle(33023);
				_lblSection_0.ForeColor = System.Drawing.Color.White;
				_lblSection_0.Text = "Propped";
			}
			lMarkup = 1 + lMarkup / 100;
			//    Me.lblVat(Index).Caption = FormatNumber((lCost * lMarkup + lDeposit) * gVat) - (lCost * lMarkup + lDeposit)
			lPrice = (lCost * lMarkup + lDeposit) * gVAT + 0.0049;
			templPrice = Convert.ToDouble(Convert.ToString(lPrice)) * 100;
			templPrice = Convert.ToInt16(templPrice);
			lPrice = templPrice / 100;
			_lblMarkup_0.Text = Strings.FormatNumber(lPrice);
			if (!string.IsNullOrEmpty(_lblMatrix_0.Tag)) {
				lPrice = Convert.ToDecimal(_lblMatrix_0.Tag);

				lPrice = lPrice * lMarkup;
				_lblMarkup_0.Text = Strings.FormatNumber(lPrice);
			} else {
				if (lPrice > gRoundAfter & gNoPrice == false) {
					if (lPrice * 100 % 100 <= gRoundDownUnits) {
						if (Strings.InStr(Convert.ToString(lPrice), "."))
							lPrice = Convert.ToDecimal(Strings.Left(Convert.ToString(lPrice), Strings.InStr(Convert.ToString(lPrice), ".")));
						lPrice = lPrice;
					} else {
						if (Strings.InStr(Convert.ToString(lPrice), "."))
							lPrice = Convert.ToDecimal(Strings.Left(Convert.ToString(lPrice), Strings.InStr(Convert.ToString(lPrice), ".")));
						lPrice = lPrice + 1;
					}
					lPrice = lPrice - gRemoveUnits / 100;
				} else {
					lPrice = System.Math.Round(lPrice + 0.045, 1);
				}

				if (gCaseToUnit) {
					if (Index) {
						lPrice = System.Math.Round(Convert.ToDecimal(_lblPrice_0.Text) - (Convert.ToDecimal(_lblDepositUnit_0.Text) + Convert.ToDecimal(_lblDepositPack_0.Text)) * gVAT, 2) * Convert.ToDouble(_frmItem_0.Tag) + (lDeposit * gVAT);
					}
				}
			}

			if (!string.IsNullOrEmpty(_txtPrice_0.Text)) {
				lPrice = Convert.ToDecimal(_txtPrice_0.Text);
				_lblSection_0.BackColor = System.Drawing.ColorTranslator.FromOle(255);
				_lblSection_0.ForeColor = System.Drawing.Color.White;
				_lblSection_0.Text = "Over-ride";
			}

			_lblPrice_0.Text = Strings.FormatNumber(lPrice);
			_lblVat_0.Text = Strings.FormatNumber(lPrice - lPrice / gVAT, 2);

			if (lCost == 0) {
				_lblPercent_0.Text = Strings.FormatNumber("0", 2);
				_lblProfitPrecent_0.Text = Strings.FormatNumber("0", 2);
				_lblProfitAmount_0.Text = Strings.FormatNumber("0", 2);
			} else {
				_lblPercent_0.Text = Strings.FormatNumber((((lPrice / gVAT - lDeposit) / lCost) - 1) * 100, 4) + "%";
				if ((lPrice - lDeposit) == 0) {
					_lblGP_0.Text = Strings.FormatNumber(0, 2);
				} else {
					_lblGP_0.Text = Strings.FormatNumber((((lPrice / gVAT - lDeposit) - lCost) / (lPrice / gVAT - lDeposit)) * 100, 4) + "%";
				}
				if ((lPrice / gVAT - lDeposit) * 100) {
					//UPGRADE_WARNING: Couldn't resolve default property of object gVAT. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					_lblGPActual_0.Text = Strings.FormatNumber((((lPrice / gVAT - lDeposit) - Convert.ToDecimal(_txtVariableCost_0.Text)) / (lPrice / gVAT - lDeposit)) * 100, 4) + "%";
				} else {
					_lblGPActual_0.Text = Strings.FormatNumber(0, 4) + "%";
				}

				_lblProfitPrecent_0.Text = Strings.FormatNumber((((lPrice / gVAT - lDeposit) - Convert.ToDecimal(_txtVariableCost_0.Text)) / Convert.ToDecimal(_txtVariableCost_0.Text)) * 100, 4) + "%";
				_lblProfitAmount_0.Text = Strings.FormatNumber((lPrice / gVAT - lDeposit) - Convert.ToDecimal(_txtVariableCost_0.Text), 2);
			}
		}

		//UPGRADE_NOTE: GotFocus was upgraded to GotFocus_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private void GotFocus_Renamed(ref object lControl)
		{
			//UPGRADE_WARNING: Couldn't resolve default property of object lControl.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//    lControl.Text = Replace(lControl.Text, ",", "")
			//UPGRADE_WARNING: Couldn't resolve default property of object lControl.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//   lControl.Text = Replace(lControl.Text, ".", "")
			//UPGRADE_WARNING: Couldn't resolve default property of object lControl.SelStart. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//  lControl.SelStart = 0
			//UPGRADE_WARNING: Couldn't resolve default property of object lControl.SelLength. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object lControl.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			// lControl.SelLength = Len(lControl.Text)
		}

		//UPGRADE_NOTE: KeyPress was upgraded to KeyPress_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private void KeyPress_Renamed(ref short KeyAscii)
		{
			// Select Case KeyAscii
			//     Case Asc(vbCr)
			// KeyAscii = 0
			//    Case 8
			//    Case 48 To 57
			//    Case Else
			//KeyAscii = 0
			//End Select
		}

		//UPGRADE_NOTE: LostFocus was upgraded to LostFocus_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private void LostFocus_Renamed(ref object lControl, ref object lDecimal)
		{
			//UPGRADE_WARNING: Couldn't resolve default property of object lControl.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//If lControl.Text = "" Then Exit Sub
			//UPGRADE_WARNING: Couldn't resolve default property of object lDecimal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//If lDecimal Then

			//UPGRADE_WARNING: Couldn't resolve default property of object lControl.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			// lControl.Text = lControl.Text / 100
			// End If
			//UPGRADE_WARNING: Couldn't resolve default property of object lControl.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object lDecimal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//lControl.Text = FormatNumber(lControl.Text, lDecimal)
		}

		private void cmdbarcode_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Here a public function barcode is called from a form named frmStockItem
			LoadItemses();

		}


		private void cmdDetails_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdDetails.Focus();
			System.Windows.Forms.Application.DoEvents();
			int lID = 0;
			lID = gStockItemID;
			this.Close();
			My.MyProject.Forms.frmStockItem.loadItem(ref lID);
			My.MyProject.Forms.frmStockItem.ShowDialog();
		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdExit.Focus();
			System.Windows.Forms.Application.DoEvents();
			saveData();
			this.Close();

			//  'if edited item is for stockitem from frmstocklist
			//    If HoldP <> "" And frmStockItemNew.txtReceipt.Text = "" Then
			//    frmStockList.editItem 0
			//    HoldP = frmStockItem.txttemphold.Text
			//    frmStockList.show 1
			//    Exit Sub
			//   'if Edited item is for frmstockPricing from frmstocklist
			//    ElseIf hold = "" And frmStockItemNew.txtReceipt.Text = "" Then
			//    frmStockList.editItem 1
			//    frmStockList.show 1
			//    Exit Sub
			//    End If

		}
		private void cmdHistory_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int lID = 0;
			lID = gStockItemID;
			My.MyProject.Forms.frmStockItemHistory.loadItem(ref lID);
		}

		private void cmdNext_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//cmdClose_Click
			if (My.MyProject.Forms.frmStockList.Visible == true) {
				if (modApplication.blNextItem == true) {
					cmdExit_Click(cmdExit, new System.EventArgs());
				} else if (modApplication.blNextItem == false) {
					cmdExit_Click(cmdExit, new System.EventArgs());
					My.MyProject.Forms.frmStockList.DataList1_DblClickS();
				}
			}
		}

		private void cmdUndo_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdUndoFocus = true;
			short x = 0;
			System.Windows.Forms.Application.DoEvents();
			cmdUndo.Focus();
			System.Windows.Forms.Application.DoEvents();
			for (x = 0; x <= frmItem.Count - 1; x++) {
				_txtCost_0.Text = _txtCost_0.Tag;
				_txtPrice_0.Text = _txtPrice_0.Tag;
				_txtProp_0.Text = _txtProp_0.Tag;
				_txtVariableCost_0.Text = _txtVariableCost_0.Tag;
				Calculate(ref x);
			}
			System.Windows.Forms.Application.DoEvents();
			cmdUndoFocus = false;
		}

		private void Command1_Click()
		{
			loadItem(ref gStockItemID);
		}

		private void frmStockPricing_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			switch (KeyCode) {
				case System.Windows.Forms.Keys.Escape:
					cmdExit_Click(cmdExit, new System.EventArgs());
					break;
			}
		}





		//UPGRADE_WARNING: Event frmStockPricing.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void frmStockPricing_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdExit.Left = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(this.ClientRectangle.Width, true) - sizeConvertors.pixelToTwips(cmdExit.Width, true) - 120, true);
		}

		private void frmStockPricing_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			loading = true;


			saveData();
			modRecordSet.cnnDB.Execute("DELETE PropChannelLnk.PropChannelLnk_Markup From PropChannelLnk WHERE (((PropChannelLnk.PropChannelLnk_Markup)=0));");
			gStockItemID = 0;
			gChannelID = 0;
			loading = false;

		}


		private void txtCost_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref _txtCost_0);
			priceBox = Convert.ToDecimal(_txtCost_0.Text);
			//    Calculate Index
		}

		private void txtCost_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			//Dim Index As Short = txtCost.GetIndex(eventSender)
			modUtilities.MyKeyPress(ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtCost_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			int Index = 0;


			ChildPriceChang = false;
			ADODB.Recordset rs = default(ADODB.Recordset);
			if (priceBox != Convert.ToDouble(_txtCost_0.Text)) {
				//check if stockitem is part of priceset
				if (rsStockItem.Fields("StockItem_PriceSetID").Value > 0) {
					//check if stockitem is child or parent
					rs = modRecordSet.getRS(ref "SELECT * FROM PriceSet WHERE PriceSetID = " + rsStockItem.Fields("StockItem_PriceSetID").Value);
					if (rsStockItem.Fields("StockItemID").Value == rs.Fields("PriceSet_StockItemID").Value) {
						//parent
						Interaction.MsgBox("This is Primary Stock Item of Pricing Set, changing of price will effect on all Child Stock Item those are part of this set.", MsgBoxStyle.Exclamation);
					} else {
						//child
						ParentPriceID = rs.Fields("PriceSet_StockItemID").Value;
						if (cmdUndoFocus == false) {
							if (Interaction.MsgBox("This is Child Stock Item of Pricing Set, changing of price of this Item will effect on Primary Stock Item and all Child Stock Item those are part of this set. " + Constants.vbCrLf + "Do you want to change ?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes) {
								ChildPriceChang = false;
								ParentPriceChang = true;
							} else {
								ChildPriceChang = true;
							}
						}
					}
					rs.Close();
				}
			}

			modUtilities.MyLostFocus(ref _txtCost_0, ref 2);
			short x = 0;
			decimal lValue = default(decimal);
			lValue = Convert.ToDecimal(Strings.Replace(_txtCost_0.Text, ",", "")) / Convert.ToDouble(_frmItem_0.Tag);
			for (x = 0; x <= frmItem.Count - 1; x++) {
				if (x != Index) {
					_txtCost_0.Text = Strings.FormatNumber(lValue * Convert.ToDouble(_frmItem_0.Tag), 2);
					Calculate(ref x);
				}
			}
			Calculate(ref Index);

			if (ChildPriceChang == true)
				cmdUndo_Click(cmdUndo, new System.EventArgs());

			System.Windows.Forms.Application.DoEvents();
		}

		private void txtfields1_Change()
		{
			//If Index = 14 Then Index = 0
			//If Index = 0 Then Index = 14

			//GotFocus txtfields1(Index)
		}


		private void txtfields1_Click()
		{
		}

		private void txtPrice_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim Index As Short = txtPrice.GetIndex(eventSender)
			if (!string.IsNullOrEmpty(_txtPrice_0.Text)) {
				modUtilities.MyGotFocusNumeric(ref _txtPrice_0);
			}
		}

		private void txtPrice_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			//Dim Index As Short = txtPrice.GetIndex(eventSender)
			modUtilities.MyKeyPress(ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtPrice_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim Index As Short = txtPrice.GetIndex(eventSender)
			if (!string.IsNullOrEmpty(_txtPrice_0.Text)) {
				modUtilities.MyLostFocus(ref _txtPrice_0, ref 2);
			}
			Calculate(ref 0);
		}

		private void txtProp_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim Index As Short = txtProp.GetIndex(eventSender)
			if (!string.IsNullOrEmpty(_txtProp_0.Text)) {
				modUtilities.MyGotFocusNumeric(ref _txtProp_0);
			}
		}

		private void txtProp_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			//Dim Index As Short = txtProp.GetIndex(eventSender)
			short lCurrentX = 0;
			switch (KeyAscii) {
				case 45:
					//-
					if (Strings.InStr(_txtProp_0.Text, "-")) {
					} else {
						lCurrentX = _txtProp_0.SelectionStart + 1;
						_txtProp_0.Text = "-" + _txtProp_0.Text;
						_txtProp_0.SelectionStart = lCurrentX;

					}
					KeyAscii = 0;
					break;
				case 43:
					//+
					if (Strings.InStr(_txtProp_0.Text, "-")) {
						lCurrentX = _txtProp_0.SelectionStart - 1;
						_txtProp_0.Text = Strings.Right(_txtProp_0.Text, Strings.Len(_txtProp_0.Text) - 1);
						if (lCurrentX < 0)
							lCurrentX = 0;
						_txtProp_0.SelectionStart = lCurrentX;

					}
					KeyAscii = 0;
					break;
				default:
					KeyPress_Renamed(ref KeyAscii);
					break;
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtProp_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim Index As Short = txtProp.GetIndex(eventSender)
			if (!string.IsNullOrEmpty(_txtProp_0.Text)) {
				modUtilities.MyLostFocus(ref _txtProp_0, ref 2);
			}
			Calculate(ref 0);
		}

		private void txtVariableCost_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim Index As Short = txtVariableCost.GetIndex(eventSender)
			modUtilities.MyGotFocusNumeric(ref _txtVariableCost_0);
		}

		private void txtVariableCost_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			//Dim Index As Short = txtVariableCost.GetIndex(eventSender)
			modUtilities.MyKeyPress(ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtVariableCost_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim Index As Short = txtVariableCost.GetIndex(eventSender)
			modUtilities.MyLostFocus(ref _txtVariableCost_0, ref 2);
			short x = 0;
			decimal lValue = default(decimal);
			lValue = Convert.ToDecimal(Strings.Replace(_txtVariableCost_0.Text, ",", "")) / Convert.ToDouble(_frmItem_0.Tag);
			for (x = 0; x <= frmItem.Count - 1; x++) {
				if (x != 0) {
					_txtVariableCost_0.Text = Strings.FormatNumber(lValue * Convert.ToDouble(_frmItem_0.Tag), 2);
					Calculate(ref x);
				}
			}
			Calculate(ref 0);
		}
		public void LoadItemses()
		{
			//*
			My.MyProject.Forms.frmStockBarcode.loadItem(ref rsStockItem.Fields("StockItemID").Value);
			frmStockBarcode form = null;
			form.Show();
			//*
		}

		private void frmStockPricing_Load(object sender, System.EventArgs e)
		{
			frmItem.AddRange(new GroupBox[] { _frmItem_0 });
			lblSelection.AddRange(new Label[] { _lblSection_0 });
		}
	}
}
