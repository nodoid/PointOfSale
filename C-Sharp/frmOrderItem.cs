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
	internal partial class frmOrderItem : System.Windows.Forms.Form
	{
//Option Explicit

//Dim gDOM As DOMDocument
//Dim gDOMOrder As DOMDocument
		bool loading;
		ADODB.Recordset rsOrder;
		short colName;
		short colQuantity;
		short colPackSize;
		short colMinimum;
		short colMaximum;
		short colStock;
		short colOnOrder;
		short colContentUnit;
		short colDepositUnit;
		short colContentTotal;
		short colDepositTotal;
		short colGrandTotal;

		bool vatDeposit;
		bool vatContent;
		bool vatTotal;
		bool showTotal;

		bool gStockItems;
		int Grow;

			//Sort stock items on Order alphabetically
		bool bSortOrder;
			//load the VAT for all items to calculate
		ADODB.Recordset rsVatMaster;

		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1582;
			//Order Form|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1583;
			//All Stock Items|Checked
			if (modRecordSet.rsLang.RecordCount){cmdStockItem.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdStockItem.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1148;
			//Delete|Checked
			if (modRecordSet.rsLang.RecordCount){cmdDelete.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdDelete.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1585;
			//Break / Build Pack
			if (modRecordSet.rsLang.RecordCount){cmdPack.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPack.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1579;
			//Back|Checked
			if (modRecordSet.rsLang.RecordCount){cmdBack.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdBack.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1005;
			//Next|Checked
			if (modRecordSet.rsLang.RecordCount){cmdNext.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdNext.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lblSupplier = No Code / Dynamic!

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1591;
			//Stock Item Selector|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1080;
			//Search|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_7.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_7.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1685;
			//Sub Totals|Checked
			if (modRecordSet.rsLang.RecordCount){frmTotals.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;frmTotals.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lbl(8) = No Code   [No Of Cases]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lbl(8).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(8).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1717;
			//Broken Packs|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1736;
			//Deposit Value|Checked
			if (modRecordSet.rsLang.RecordCount){lbl[9].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl[9].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lbl(10) = No Code  [Contents Value]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lbl(10).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(10).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_1 = No Code   [Total Value]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmOrderItem.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void getOrder()
		{
			//    Dim lNode As IXMLDOMNode
			//    Dim lNodeList As IXMLDOMNodeList
			short x = 0;
			if (bSortOrder) {
				rsOrder = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_Quantity, StockItem.StockItem_MinimumStock, StockItem.StockItem_OrderQuantity, StockItem.StockItem_OrderRounding, TempOrderItem.TempOrderItem_ContentCost, TempOrderItem.TempOrderItem_Quantity, TempOrderItem.TempOrderItem_PackSize, WAREHOUSE_Stock.Warehouse_StockItemQuantity, ORDER_onOrder.onOrder, Deposit.Deposit_UnitCost, Deposit.Deposit_CaseCost FROM (((TempOrderItem INNER JOIN StockItem ON TempOrderItem.TempOrderItem_StockItemID = StockItem.StockItemID) INNER JOIN ORDER_onOrder ON StockItem.StockItemID = ORDER_onOrder.StockItemID) INNER JOIN WAREHOUSE_Stock ON StockItem.StockItemID = WAREHOUSE_Stock.WarehouseStockItemLnk_StockItemID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID Where (((TempOrderItem.TempOrderItem_SupplierID) = " + My.MyProject.Forms.frmOrder.adoPrimaryRS.Fields("SupplierID").Value + ")) ORDER BY StockItem.StockItem_Name;");
			} else {
				rsOrder = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_Quantity, StockItem.StockItem_MinimumStock, StockItem.StockItem_OrderQuantity, StockItem.StockItem_OrderRounding, TempOrderItem.TempOrderItem_ContentCost, TempOrderItem.TempOrderItem_Quantity, TempOrderItem.TempOrderItem_PackSize, WAREHOUSE_Stock.Warehouse_StockItemQuantity, ORDER_onOrder.onOrder, Deposit.Deposit_UnitCost, Deposit.Deposit_CaseCost FROM (((TempOrderItem INNER JOIN StockItem ON TempOrderItem.TempOrderItem_StockItemID = StockItem.StockItemID) INNER JOIN ORDER_onOrder ON StockItem.StockItemID = ORDER_onOrder.StockItemID) INNER JOIN WAREHOUSE_Stock ON StockItem.StockItemID = WAREHOUSE_Stock.WarehouseStockItemLnk_StockItemID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID Where (((TempOrderItem.TempOrderItem_SupplierID) = " + My.MyProject.Forms.frmOrder.adoPrimaryRS.Fields("SupplierID").Value + "));");
				// ORDER BY StockItem.StockItem_Name
			}

			decimal lDeposit = default(decimal);
			loading = true;
			var _with1 = gridItem;
			_with1.Visible = false;
			_with1.RowCount = rsOrder.RecordCount + 1;
			x = 0;
			while (!(rsOrder.EOF)) {
				x = x + 1;
				_with1.row = x;
				_with1.set_RowData(x, rsOrder.Fields("StockItemID").Value);
				_with1.Col = colPackSize;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 222));
				_with1.Col = colContentUnit;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(255, 255, 255));
				_with1.Col = colDepositUnit;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 222));
				_with1.Col = colDepositTotal;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(255, 200, 200));
				_with1.Col = colContentTotal;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(255, 200, 200));
				_with1.Col = colMinimum;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 200));
				_with1.Col = colMaximum;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 200));
				_with1.Col = colStock;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 200));
				_with1.Col = colOnOrder;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 222));
				if (showTotal) {
					_with1.Col = colGrandTotal;
					gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(200, 255, 200));
				}

				_with1.set_TextMatrix(x, 0, rsOrder.Fields("StockItem_Name").Value);
				_with1.set_TextMatrix(x, colMinimum, Strings.FormatNumber(rsOrder.Fields("StockItem_MinimumStock").Value, 0));
				_with1.set_TextMatrix(x, colOnOrder, Strings.FormatNumber(rsOrder.Fields("OnOrder").Value, 0));
				_with1.set_TextMatrix(x, colStock, Strings.FormatNumber(rsOrder.Fields("Warehouse_StockItemQuantity").Value, 0));
				_with1.set_TextMatrix(x, colQuantity, Strings.FormatNumber(rsOrder.Fields("TempOrderItem_Quantity").Value, 0));
				_with1.set_TextMatrix(x, colPackSize, Strings.FormatNumber(rsOrder.Fields("TempOrderItem_PackSize").Value, 0));
				if (rsOrder.Fields("TempOrderItem_PackSize").Value != rsOrder.Fields("StockItem_Quantity").Value) {
					_with1.Col = colPackSize;
					gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(255, 200, 200));
					_with1.set_TextMatrix(x, 1, "X");
				} else {
					_with1.set_TextMatrix(x, 1, "");
				}
				_with1.set_TextMatrix(x, colContentUnit, Strings.FormatNumber((Information.IsDBNull(rsOrder.Fields("TempOrderItem_ContentCost").Value) ? 0 : rsOrder.Fields("TempOrderItem_ContentCost").Value) * rsOrder.Fields("TempOrderItem_PackSize").Value / rsOrder.Fields("StockItem_Quantity").Value, 2));
				lDeposit = rsOrder.Fields("Deposit_UnitCost").Value * rsOrder.Fields("TempOrderItem_PackSize").Value;
				if (rsOrder.Fields("TempOrderItem_PackSize").Value == rsOrder.Fields("StockItem_Quantity").Value) {
					lDeposit = lDeposit + rsOrder.Fields("Deposit_CaseCost").Value;
				}
				_with1.set_TextMatrix(x, colDepositUnit, Strings.FormatNumber(lDeposit, 2));
				//                .TextMatrix(x, colDepositTotal) = FormatNumber(.TextMatrix(x, colDepositUnit) * .TextMatrix(x, colQuantity), 2)
				//                .TextMatrix(x, colContentTotal) = FormatNumber(.TextMatrix(x, colContentUnit) * .TextMatrix(x, colQuantity), 2)
				displayLine(ref ref x);
				rsOrder.moveNext();
			}
			_with1.Col = colQuantity;
			_with1.Visible = true;

			loading = false;
			doTotals();
		}
		private void displayLine(ref short row)
		{
			var _with2 = gridItem;
			_with2.set_TextMatrix(row, colDepositTotal, Strings.FormatNumber(Convert.ToDouble(_with2.get_TextMatrix(row, colDepositUnit)) * Convert.ToDouble(_with2.get_TextMatrix(row, colQuantity)), 2));
			_with2.set_TextMatrix(row, colContentTotal, Strings.FormatNumber(Convert.ToDouble(_with2.get_TextMatrix(row, colContentUnit)) * Convert.ToDouble(_with2.get_TextMatrix(row, colQuantity)), 2));
			if (showTotal) {
				_with2.set_TextMatrix(row, colGrandTotal, Strings.FormatNumber(Convert.ToDecimal(_with2.get_TextMatrix(row, colContentTotal)) + Convert.ToDecimal(_with2.get_TextMatrix(row, colDepositTotal)), 2));
				if (vatTotal) {
					rsVatMaster.Filter = "StockItemID=" + _with2.get_RowData(row);
					if (rsVatMaster.RecordCount) {
						_with2.set_TextMatrix(row, colGrandTotal, Strings.FormatNumber(Convert.ToDecimal(_with2.get_TextMatrix(row, colGrandTotal)) * (rsVatMaster.Fields("Vat_Amount").Value == 0 ? 1 : (1 + rsVatMaster.Fields("Vat_Amount").Value / 100)), 2));
					} else {
						_with2.set_TextMatrix(row, colGrandTotal, Strings.FormatNumber(Convert.ToDecimal(_with2.get_TextMatrix(row, colGrandTotal)) * 1.14, 2));
					}
					//14HERE
				}
			}

		}

		private void getNamespace()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string lString = null;
			lString = Strings.Trim(txtSearch.Text);
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");

			if (string.IsNullOrEmpty(Strings.Trim(txtSearch.Text))) {
				lString = " StockItem.StockItem_Discontinued = 0 ";
			} else {
				lString = " StockItem.StockItem_Discontinued = 0  AND (StockItem_Name LIKE '%" + Strings.Replace(lString, " ", "%' AND StockItem_Name LIKE '%") + "%')";
			}

			if (gStockItems) {
				if (!string.IsNullOrEmpty(lString))
					lString = " WHERE " + lString;
				rs = modRecordSet.getRS(ref "SELECT TOP 100 PERCENT StockItemID, StockItem_Name FROM StockItem " + lString + "ORDER BY StockItem_Name");
			} else {
				if (!string.IsNullOrEmpty(lString))
					lString = " AND " + lString;

				rs = modRecordSet.getRS(ref "SELECT TOP 100 PERCENT StockItemID, StockItem_Name From StockItem Where (StockItem_SupplierID = " + My.MyProject.Forms.frmOrder.adoPrimaryRS.Fields("SupplierID").Value + ") " + lString + "ORDER BY StockItem_Name");
			}
			lstWorkspace.Items.Clear();
			while (!(rs.EOF)) {
				lstWorkspace.Items.Add(new LBI(rs.Fields("StockItem_Name").Value + "", rs.Fields("StockItemID").Value));
				rs.moveNext();
			}
		}

		private void setup()
		{
			loading = true;
			lblSupplier.Text = My.MyProject.Forms.frmOrder.adoPrimaryRS.Fields("Supplier_Name").Value;

			var _with3 = gridItem;
			if (showTotal) {
				gridItem.ColumnCount = 13;
				gridItem.Col = colGrandTotal;
				gridItem.CellFontBold = true;
				gridItem.set_TextMatrix(ref ref 0, ref ref colGrandTotal, ref ref "Total");
				gridItem.set_colAlignment(ref ref colGrandTotal, ref ref 7);
				gridItem.set_ColWidth(ref ref colGrandTotal, ref ref 900);
			} else {
				gridItem.ColumnCount = 12;
				frmTotals.Width = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(lblContent.Left, true) + sizeConvertors.pixelToTwips(lblContent.Width, true) + 100, true);
			}
			gridItem.RowCount = 1;
			gridItem.row = 0;
			gridItem.Col = 0;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref 0, ref ref "Description");
			gridItem.set_colAlignment(ref ref 0, ref ref 1);
			gridItem.set_ColWidth(ref ref 0, ref ref 2500);
			gridItem.Col = 1;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref 1, ref ref "B");
			gridItem.set_colAlignment(ref ref 1, ref ref 1);
			gridItem.set_ColWidth(ref ref 1, ref ref 200);

			gridItem.Col = colMinimum;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colMinimum, ref ref "Min");
			gridItem.set_colAlignment(ref ref colMinimum, ref ref 7);
			gridItem.set_ColWidth(ref ref colMinimum, ref ref 550);
			gridItem.Col = colMaximum;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colMaximum, ref ref "Max");
			gridItem.set_colAlignment(ref ref colMaximum, ref ref 7);
			gridItem.set_ColWidth(ref ref colMaximum, ref ref 550);
			gridItem.Col = colStock;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colStock, ref ref "Curr");
			gridItem.set_colAlignment(ref ref colStock, ref ref 7);
			gridItem.set_ColWidth(ref ref colStock, ref ref 550);
			gridItem.Col = colOnOrder;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colOnOrder, ref ref "Order");
			gridItem.set_colAlignment(ref ref colOnOrder, ref ref 7);
			gridItem.set_ColWidth(ref ref colOnOrder, ref ref 550);

			gridItem.Col = colQuantity;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colQuantity, ref ref "QTY");
			gridItem.set_colAlignment(ref ref colQuantity, ref ref 7);
			gridItem.set_ColWidth(ref ref colQuantity, ref ref 600);
			gridItem.Col = colPackSize;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colPackSize, ref ref "");
			gridItem.set_colAlignment(ref ref colPackSize, ref ref 7);
			gridItem.set_ColWidth(ref ref colPackSize, ref ref 500);
			gridItem.Col = colContentUnit;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colContentUnit, ref ref "Unit Con");
			gridItem.set_colAlignment(ref ref colContentUnit, ref ref 7);
			gridItem.set_ColWidth(ref ref colContentUnit, ref ref 900);
			gridItem.Col = colDepositUnit;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colDepositUnit, ref ref "Unit Dep");
			gridItem.set_colAlignment(ref ref colDepositUnit, ref ref 7);
			gridItem.set_ColWidth(ref ref colDepositUnit, ref ref 900);
			gridItem.Col = colDepositTotal;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colDepositTotal, ref ref "Dep Value");
			gridItem.set_colAlignment(ref ref colDepositTotal, ref ref 7);
			gridItem.set_ColWidth(ref ref colDepositTotal, ref ref 1000);
			gridItem.Col = colContentTotal;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colContentTotal, ref ref "Con Value");
			gridItem.set_colAlignment(ref ref colContentTotal, ref ref 7);
			gridItem.set_ColWidth(ref ref colContentTotal, ref ref 1000);
			loading = false;
		}

		private void cmdBack_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdBack.Focus();
			System.Windows.Forms.Application.DoEvents();
			this.Close();
		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdBack.Focus();
			System.Windows.Forms.Application.DoEvents();
			this.Close();
			System.Windows.Forms.Application.DoEvents();
			My.MyProject.Forms.frmOrder.Close();
		}


		private void doTotals()
		{
			int x = 0;
			int lQuantity = 0;
			short lBrokenPack = 0;
			decimal lContent = default(decimal);
			decimal lDeposit = default(decimal);
			decimal lTotal = default(decimal);
			lContent = 0;
			lDeposit = 0;
			lQuantity = 0;
			lTotal = 0;
			lBrokenPack = 0;
			if (showTotal) {
				for (x = 1; x <= gridItem.RowCount - 1; x++) {
					lContent = lContent + Convert.ToDecimal(gridItem.get_TextMatrix(ref x, ref colContentTotal));
					lDeposit = lDeposit + Convert.ToDecimal(gridItem.get_TextMatrix(ref x, ref colDepositTotal));
					if (string.IsNullOrEmpty(gridItem.get_TextMatrix(ref x, ref 1))) {
						lQuantity = lQuantity + Convert.ToInt16(gridItem.get_TextMatrix(ref x, ref colQuantity));
					} else {
						lBrokenPack = lBrokenPack + Convert.ToInt16(gridItem.get_TextMatrix(ref x, ref colQuantity));
					}
					lTotal = lTotal + Convert.ToDecimal(gridItem.get_TextMatrix(ref x, ref colGrandTotal));
				}
			} else {
				for (x = 1; x <= gridItem.RowCount - 1; x++) {
					lContent = lContent + Convert.ToDecimal(gridItem.get_TextMatrix(ref x, ref colContentTotal));
					lDeposit = lDeposit + Convert.ToDecimal(gridItem.get_TextMatrix(ref x, ref colDepositTotal));
					lQuantity = lQuantity + Convert.ToInt16(gridItem.get_TextMatrix(ref x, ref colQuantity));
				}
			}
			lblQuantity.Text = Strings.FormatNumber(lQuantity, 0);
			lblContent.Text = Strings.FormatNumber(lContent, 2);
			lblDeposit.Text = Strings.FormatNumber(lDeposit, 2);
			lblTotal.Text = Strings.FormatNumber(lTotal, 2);
			lblBrokenPack.Text = Convert.ToString(lBrokenPack);

		}

		private void cmdNext_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdNext.Focus();
			System.Windows.Forms.Application.DoEvents();
			My.MyProject.Forms.frmOrderSummary.ShowDialog();
		}


		private void cmdPriceBOM_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (gridItem.row) {
				My.MyProject.Forms.frmStockMultiPrice.changePrice(ref gridItem.get_RowData(ref gridItem.row));
			}
		}

		private void cmdStockItem_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int id = 0;
			string lString = null;
			string sql = null;
			short x = 0;
			id = gridItem.get_RowData(ref gridItem.row);
			if (gStockItems) {
				gStockItems = false;
				cmdStockItem.Text = "All Stoc&k Items";
			} else {
				gStockItems = true;
				cmdStockItem.Text = "Supplier Stoc&k Items";

			}
			getNamespace();
			getOrder();
			x = findItem(ref id);
			if (x) {
				gridItem.row = x;
				gridItem.Col = colQuantity;
				_txtEdit_0.Visible = true;
				gridItem_EnterCell(gridItem, new System.EventArgs());
			}
		}
		private int findItem(ref string id)
		{
			int functionReturnValue = 0;
			int x = 0;
			var _with4 = gridItem;


			for (x = 1; x <= _with4.RowCount - 1; x++) {
				if (_with4.get_RowData(x) == id) {
					functionReturnValue = x;
					break; // TODO: might not be correct. Was : Exit For
				}

			}

			return functionReturnValue;
			return functionReturnValue;
		}


		private void frmOrderItem_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			short x = 0;
			short lWidth = 0;
			frmTotals.Top = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(ClientRectangle.Height, false) - sizeConvertors.pixelToTwips(frmTotals.Height, false), false);
			frmTotals.Left = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(ClientRectangle.Width, true) - sizeConvertors.pixelToTwips(frmTotals.Width, true), true);
			lstWorkspace.Height = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(ClientRectangle.Height, false) - sizeConvertors.pixelToTwips(lstWorkspace.Top, false), false);
			gridItem.Height = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(ClientRectangle.Height, false) - sizeConvertors.pixelToTwips(gridItem.Top, false) - sizeConvertors.pixelToTwips(frmTotals.Height, false), false);
			gridItem.Width = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(ClientRectangle.Width, true) - sizeConvertors.pixelToTwips(gridItem.Left, true), true);
			lWidth = sizeConvertors.pixelToTwips(gridItem.Width, true) - 450;
			for (x = 1; x <= gridItem.ColumnCount - 1; x++) {
				lWidth = lWidth - gridItem.get_ColWidth(ref x);
			}
			if (lWidth > 200) {
				gridItem.set_ColWidth(ref 0, ref lWidth);
			} else {
				gridItem.set_ColWidth(ref 0, ref 2000);
			}
			gridItem_EnterCell(gridItem, new System.EventArgs());
		}

		private void frmOrderItem_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

		}

		private void lstWorkspace_DoubleClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			string lKey = null;
			decimal lDeposit = default(decimal);
			short x = 0;
			string sql = null;
			ADODB.Recordset rsSql = default(ADODB.Recordset);
			if (lstWorkspace.SelectedIndex != -1) {
				//        Dim lDOM As DOMDocument
				//        Dim lNode As IXMLDOMNode
				//        Dim lNodeList As IXMLDOMNodeList
				update_Renamed();
				loading = true;
				x = findItem(ref Convert.ToInt64(lstWorkspace.SelectedIndex));
				if (x) {
					gridItem.row = x;

				} else {
					lKey = DateAndTime.Year(DateAndTime.Today) + Strings.Right("0" + DateAndTime.Month(DateAndTime.Today), 2) + Strings.Right("0" + DateAndTime.Day(DateAndTime.Today), 2) + Strings.Right("0" + DateAndTime.Hour(DateAndTime.TimeOfDay), 2) + Strings.Right("0" + DateAndTime.Minute(DateAndTime.TimeOfDay), 2) + Strings.Right("0" + DateAndTime.Second(DateAndTime.TimeOfDay), 2);

					sql = "INSERT INTO TempOrderItem (TempOrderItem_SupplierID, TempOrderItem_StockItemID, TempOrderItem_PackSize, TempOrderItem_QuantityRequired, TempOrderItem_Quantity, TempOrderItem_ContentCost) ";
					sql = sql + "SELECT " + My.MyProject.Forms.frmOrder.adoPrimaryRS.Fields("SupplierID").Value + " AS supplierID, StockItemID, StockItem_OrderQuantity, 0, 0, StockItem_ListCost From StockItem WHERE (StockItemID = " + Convert.ToInt32(lstWorkspace.SelectedIndex) + ")";
					modRecordSet.cnnDB.Execute(sql);

					//update Cost price from GRV Deals
					rsSql = modRecordSet.getRS(ref "SELECT GRVPromotion.PromotionID, GRVPromotionItem.PromotionItem_StockItemID, GRVPromotionItem.PromotionItem_Price, GRVPromotion.Promotion_StartDate, GRVPromotion.Promotion_EndDate FROM GRVPromotion INNER JOIN GRVPromotionItem ON GRVPromotion.PromotionID = GRVPromotionItem.PromotionItem_PromotionID WHERE (((GRVPromotionItem.PromotionItem_StockItemID)=" + Convert.ToInt32(lstWorkspace.SelectedIndex) + ") AND ((GRVPromotion.Promotion_StartDate)<=#" + Strings.Format(DateAndTime.Today, "yyyy/MM/dd") + "#) AND ((GRVPromotion.Promotion_EndDate)>=#" + Strings.Format(DateAndTime.Today, "yyyy/MM/dd") + "#));");
					if (rsSql.RecordCount > 0) {
						if (Information.IsDBNull(rsSql.Fields("PromotionItem_Price").Value)) {
						} else {
							sql = "UPDATE TempOrderItem SET TempOrderItem.TempOrderItem_ContentCost = " + rsSql.Fields("PromotionItem_Price").Value + " Where (TempOrderItem_SupplierID = " + My.MyProject.Forms.frmOrder.adoPrimaryRS.Fields("SupplierID").Value + ") And (TempOrderItem_StockItemID = " + Convert.ToInt32(lstWorkspace.SelectedIndex) + ");";
							modRecordSet.cnnDB.Execute(sql);
						}
					}
					//update Cost price from GRV Deals

					getOrder();
					System.Windows.Forms.Application.DoEvents();
					x = findItem(ref lstWorkspace, ref lstWorkspace.SelectedIndex);
					if (x) {
						gridItem.row = x;
						gridItem.Col = colQuantity;
						_txtEdit_0.Visible = true;
						//gridItem_EnterCell
					}
				}
			}
			loading = false;
			gridItem_EnterCell(gridItem, new System.EventArgs());

		}
		private int findItem(ref ListBox myList, ref int myIndex)
		{
			myList.SelectedIndex = myIndex;
			return myList.SelectedIndex;
		}
		private void lstWorkspace_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 13) {
				lstWorkspace_DoubleClick(lstWorkspace, new System.EventArgs());
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void lstWorkspace_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			switch (KeyCode) {
				case 38:
					if (lstWorkspace.SelectedIndex == 0) {
						this.txtSearch.Focus();
					}
					break;
			}

		}

		private void update_Renamed()
		{
			if (loading)
				return;
			//   Dim lNode As IXMLDOMNode
			short x = 0;
			string sql = null;
			System.Windows.Forms.TextBox oText = null;
			bool lUpdate = false;
			foreach (TextBox oText_loopVariable in txtEdit) {
				oText = oText_loopVariable;
				if (string.IsNullOrEmpty(oText.Text))
					oText.Text = "0";
				if (oText.Text != oText.Tag) {
					lUpdate = true;
				}
			}
			//If txtEdit.Text = "" Then txtEdit.Text = "0"
			//If txtEdit.Text <> txtEdit.Tag Then
			if (lUpdate) {
				switch (gridItem.Col) {
					case colQuantity:
						if (Grow == gridItem.row) {
							sql = "UPDATE TempOrderItem SET TempOrderItem_Quantity = " + _txtEdit_0.Text + " Where (TempOrderItem_SupplierID = " + My.MyProject.Forms.frmOrder.adoPrimaryRS.Fields("SupplierID").Value + ") And (TempOrderItem_StockItemID = " + gridItem.get_RowData(ref gridItem.row) + ")";
							modRecordSet.cnnDB.Execute(sql);
							gridItem.set_TextMatrix(ref gridItem.row, ref colQuantity, ref _txtEdit_0.Text);
						} else {
						}
						break;
					case colContentUnit:
						if (Grow == gridItem.row) {
							sql = "UPDATE TempOrderItem SET TempOrderItem_ContentCost = " + Strings.FormatNumber(Convert.ToDecimal(_txtEdit_1.Text) / 100, 2) + " Where (TempOrderItem_SupplierID = " + My.MyProject.Forms.frmOrder.adoPrimaryRS.Fields("SupplierID").Value + ") And (TempOrderItem_StockItemID = " + gridItem.get_RowData(ref gridItem.row) + ")";
							modRecordSet.cnnDB.Execute(sql);
							gridItem.set_TextMatrix(ref gridItem.row, ref colContentUnit, ref Strings.FormatNumber(Convert.ToDecimal(_txtEdit_1.Text) / 100, 2));
						} else {
						}
						break;
					//gridItem.TextMatrix(gridItem.row, colContentUnit) = FormatNumber(CCur(_txtEdit_1.Text) / 100, 2)
					//_txtEdit_1.Tag = _txtEdit_1.Text
				}
			}
		}

		private void cmdPack_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int id = 0;
			int x = 0;

			id = gridItem.get_RowData(ref gridItem.row);
			if (Convert.ToDouble(gridItem.get_TextMatrix(ref gridItem.row, ref colPackSize)) == 1) {
				modRecordSet.cnnDB.Execute("UPDATE TempOrderItem INNER JOIN StockItem ON TempOrderItem.TempOrderItem_StockItemID = StockItem.StockItemID SET TempOrderItem.TempOrderItem_Quantity = CInt(([TempOrderItem_QuantityRequired]+([StockItem_OrderQuantity]-1)/2)/[StockItem_Quantity]), TempOrderItem.TempOrderItem_PackSize = [StockItem]![StockItem_Quantity] WHERE (((TempOrderItem.TempOrderItem_SupplierID)=" + My.MyProject.Forms.frmOrder.adoPrimaryRS.Fields("SupplierID").Value + ") AND ((TempOrderItem.TempOrderItem_StockItemID)=" + id + "));");
			} else {
				modRecordSet.cnnDB.Execute("UPDATE TempOrderItem SET TempOrderItem.TempOrderItem_Quantity = [TempOrderItem]![TempOrderItem_QuantityRequired], TempOrderItem.TempOrderItem_PackSize = 1 WHERE (((TempOrderItem.TempOrderItem_SupplierID)=" + My.MyProject.Forms.frmOrder.adoPrimaryRS.Fields("SupplierID").Value + ") AND ((TempOrderItem.TempOrderItem_StockItemID)=" + id + "));");

			}
			getOrder();
			x = findItem(ref id);
			if (x) {
				gridItem.row = x;
				gridItem.Col = colQuantity;
				_txtEdit_0.Visible = true;
				gridItem_EnterCell(gridItem, new System.EventArgs());
			}
		}

		private void cmdDelete_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			System.Windows.Forms.TextBox oText = null;
			if (gridItem.row) {
				if (Interaction.MsgBox("Are you sure you wish to delete the order item '" + gridItem.get_TextMatrix(ref gridItem.row, ref 0) + "' from this order?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Delete Line Item") == MsgBoxResult.Yes) {
					modRecordSet.cnnDB.Execute("DELETE FROM TempOrderItem Where (TempOrderItem_SupplierID = " + My.MyProject.Forms.frmOrder.adoPrimaryRS.Fields("SupplierID").Value + ") And (TempOrderItem_StockItemID = " + gridItem.get_RowData(ref gridItem.row) + ")");
					getOrder();
					if (gridItem.RowCount > 1) {
						gridItem.row = 1;
						gridItem_EnterCell(gridItem, new System.EventArgs());
					} else {
						//txtEdit.Visible = False
						foreach (TextBox oText_loopVariable in txtEdit) {
							oText = oText_loopVariable;
							oText.Visible = false;
						}
					}
				}
			}
		}

		private void cmdEdit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int id = 0;
			int x = 0;
			frmStockItem form = null;
			if (gridItem.get_RowData(ref gridItem.row) != 0) {
				id = gridItem.get_RowData(ref gridItem.row);
				My.MyProject.Forms.frmStockItem.loadItem(ref gridItem.get_RowData(ref gridItem.row));
				form.Show();
				getOrder();
				x = findItem(ref id);
				if (x) {
					gridItem.row = x;
					gridItem.Col = colQuantity;
					_txtEdit_0.Visible = true;
					gridItem_EnterCell(gridItem, new System.EventArgs());
				}

			}
		}

		private void picButtons_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdExit.Left = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(picButtons.ClientRectangle.Width, true) - sizeConvertors.pixelToTwips(cmdExit.Width, true) - 30, true);
			cmdNext.Left = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(cmdExit.Left, true) - sizeConvertors.pixelToTwips(cmdNext.Width, true) - 150, true);
			cmdBack.Left = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(cmdNext.Left, true) - sizeConvertors.pixelToTwips(cmdBack.Width, true) - 45, true);

		}

		private void txtEdit_TextChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			int Index = 0;
			TextBox txtBox = new TextBox();
			txtBox = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref txtBox, ref txtEdit);
			decimal colPrice = default(decimal);
			if (loading)
				return;
			string lString = null;
			int lValue = 0;
			var _with5 = gridItem;
			lString = txtBox.Text;
			if (lString == ".")
				lValue = Convert.ToInt32("0.");
			if (_with5.row) {
				if (string.IsNullOrEmpty(lString))
					lString = "0";
				if (Information.IsNumeric(lString)) {
					switch (Index) {
						case 0:
							//If CBool(.TextMatrix(.row, colFractions)) Then
							//    .TextMatrix(.row, colQuantity) = FormatNumber(lString, 4)
							//Else
							_with5.set_TextMatrix(_with5.row, colQuantity, Strings.FormatNumber(lString, 0));
							break;
						//End If
						case 1:
							_with5.set_TextMatrix(_with5.row, colContentUnit, Strings.FormatNumber(Convert.ToDecimal(lString) / 100, 2));
							break;
						case 2:
							_with5.set_TextMatrix(_with5.row, colPrice, Strings.FormatNumber(Convert.ToDecimal(lString) / 100, 2));
							break;
					}
				}
				displayLine(ref ref _with5.row);
			}
			doTotals();
		}

		private void txtEdit_Change_OLD()
		{
			//    If loading Then Exit Sub
			//    With gridItem
			//        Dim lValue As Long
			//        If .row Then
			//            If txtEdit.Text = "" Then lValue = 0 Else lValue = txtEdit.Text
			//            .TextMatrix(.row, colQuantity) = lValue
			//'            .TextMatrix(.row, colDepositTotal) = FormatNumber(.TextMatrix(.row, colDepositUnit) * lValue, 2)
			//'            .TextMatrix(.row, colContentTotal) = FormatNumber(.TextMatrix(.row, colContentUnit) * lValue, 2)
			//            displayLine .row
			//        End If
			//    End With
			//    doTotals
		}

		private void txtEdit_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = txtEdit.GetIndex(eventSender);
			update_Renamed();
		}

		private void txtSearch_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtSearch.SelectionStart = 0;
			txtSearch.SelectionLength = 999;
		}

		private void txtSearch_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			switch (KeyCode) {
				case 40:
					this.lstWorkspace.Focus();
					if (lstWorkspace.Items.Count) {
						if (lstWorkspace.SelectedIndex == -1) {
							lstWorkspace.SelectedIndex = 0;
						}
					}
					break;
			}
		}

		private void txtSearch_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case 13:
					doSearch();
					break;
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void doSearch()
		{
			getNamespace();
		}


		private void frmOrderItem_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox oText = new TextBox();
			//    Dim lNode As IXMLDOMNode
			//    Select Case frmOrder.gTransactionType
			//        Case 1
			//            colMinimum = 2
			//            colMaximum = 3
			//            colStock = 4
			//            colQuantity = 5
			//            colPackSize = 6
			//            colContentUnit = 7
			//            colDepositUnit = 8
			//            colDepositTotal = 9
			//            colContentTotal = 10
			//            colGrandTotal = 12
			//            colOnOrder = 11
			//            vatDeposit = False
			//            vatContent = False
			//            vatTotal = False
			//            showTotal = True
			//        Case 4, 5
			//            colMinimum = 2
			//            colMaximum = 3
			//            colStock = 4
			//            colQuantity = 5
			//            colPackSize = 6
			//            colContentUnit = 7
			//            colDepositUnit = 8
			//            colDepositTotal = 9
			//            colContentTotal = 10
			//            colGrandTotal = 12
			//            colOnOrder = 11
			//            vatDeposit = False
			//            vatContent = False
			//            vatTotal = True
			//            showTotal = True
			//        Case Else
			colQuantity = 2;
			colPackSize = 3;
			colContentUnit = 4;
			colDepositUnit = 5;
			colDepositTotal = 6;
			colContentTotal = 7;
			colMinimum = 8;
			colMaximum = 9;
			colStock = 10;
			colGrandTotal = 12;
			colOnOrder = 11;
			vatDeposit = false;
			vatContent = false;
			vatTotal = true;
			showTotal = true;
			//    End Select

			loadLanguage();

			//Sort stock items on Order alphabetically
			ADODB.Recordset rs = default(ADODB.Recordset);
			bSortOrder = false;
			rs = modRecordSet.getRS(ref "select Company_SortOrderItems from Company");
			if (rs.RecordCount) {
				if (rs.Fields("Company_SortOrderItems").Value == -1) {
					bSortOrder = true;
				}
			}
			//Sort stock items on Order alphabetically

			//BO Security permission check
			if (1 & My.MyProject.Forms.frmMenu.gBit) {
			} else {
				cmdEdit.Enabled = false;
			}


			//load the VAT for all items to calculate
			rsVatMaster = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, Vat.Vat_Amount FROM StockItem INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID;");

			setup();
			getNamespace();
			getOrder();
			if (gridItem.RowCount) {
				loading = true;
				gridItem.Col = 0;
				gridItem.row = 0;
				loading = false;
				foreach (TextBox oText_loopVariable in txtEdit) {
					oText = oText_loopVariable;
					oText.Visible = false;
				}
				if (gridItem.RowCount > 1) {
					gridItem.Col = colQuantity;
					gridItem.row = 1;
					_txtEdit_0.Visible = true;
				} else {
					_txtEdit_0.Visible = false;
				}
			}

		}

		private void gridItem_EnterCell(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (loading)
				return;
			var _with6 = gridItem;
			//If .Col <> colQuantity Then
			//    .Col = colQuantity
			//    Exit Sub
			//End If
			if (_with6.row) {
				//        update

				if (_with6.Col == colContentUnit) {
					_txtEdit_1.SetBounds(sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with6.Left, true) + _with6.CellLeft, true), sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with6.Top, false) + _with6.CellTop, false), sizeConvertors.twipsToPixels(_with6.CellWidth, true), sizeConvertors.twipsToPixels(_with6.CellHeight, false));
					_txtEdit_1.Text = Strings.Replace(_with6.Text, ".", "");
					_txtEdit_1.Tag = _txtEdit_1.Text;
					_txtEdit_1.Visible = true;
					_txtEdit_1.SelectionStart = 0;
					_txtEdit_1.SelectionLength = 9999;
					if (this.Visible)
						_txtEdit_1.Focus();
				} else {
					_txtEdit_1.Visible = false;
				}
				if (_with6.Col == colQuantity) {
					_txtEdit_0.SetBounds(sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with6.Left, true) + _with6.CellLeft, true), sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with6.Top, false) + _with6.CellTop, false), sizeConvertors.twipsToPixels(_with6.CellWidth, true), sizeConvertors.twipsToPixels(_with6.CellHeight, false));
					_txtEdit_0.Text = _with6.Text;
					modApplication.intQTY = Convert.ToInt16(_with6.Text);
					_txtEdit_0.Tag = _txtEdit_0.Text;
					_txtEdit_0.Visible = true;
					_txtEdit_0.SelectionStart = 0;
					_txtEdit_0.SelectionLength = 9999;
					if (this.Visible)
						_txtEdit_0.Focus();
				} else {
					_txtEdit_0.Visible = false;
				}
				//            txtEdit.Move .Left + .CellLeft, .Top + .CellTop, .CellWidth, .CellHeight
				//loading = True
				//            txtEdit.Text = .Text
				//            txtEdit.Text = Replace(.Text, ".", "")
				//            txtEdit.Text = Replace(.Text, ",", "")
				//            If txtEdit.Text = "000" Then txtEdit.Text = "0"
				//            txtEdit.Tag = txtEdit.Text
				Grow = _with6.row;

				//loading = False
				//            txtEdit.Tag = txtEdit.Text
				//            txtEdit.Visible = True
				//            If Me.Visible Then txtEdit.SetFocus
			}
		}

		private void gridItem_EnterCell_OLD()
		{
			//    If loading Then Exit Sub
			//    With gridItem
			//        If .Col <> colQuantity Then
			//            .Col = colQuantity
			//            Exit Sub
			//        End If
			//        If .row Then
			//    '        update
			//            txtEdit.Move .Left + .CellLeft, .Top + .CellTop, .CellWidth, .CellHeight
			//loading = True
			//            txtEdit.Text = .Text
			//            txtEdit.Text = Replace(.Text, ".", "")
			//            txtEdit.Text = Replace(.Text, ",", "")
			//            If txtEdit.Text = "000" Then txtEdit.Text = "0"
			//            txtEdit.Tag = txtEdit.Text
			//            gRow = .row
			//
			//loading = False
			//            txtEdit.Tag = txtEdit.Text
			//            txtEdit.Visible = True
			//            If Me.Visible Then txtEdit.SetFocus
			//         End If
			//    End With
		}

		private void gridItem_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			//txtEdit_GotFocus
		}

		private void gridItem_KeyPress(System.Object eventSender, KeyPressEventArgs eventArgs)
		{
			switch (eventArgs.KeyChar) {
				case Strings.ChrW(40):
					eventArgs.KeyChar = Strings.ChrW(0);
					break;
			}

		}

		private void gridItem_LeaveCell(System.Object eventSender, System.EventArgs eventArgs)
		{
			update_Renamed();
		}



		private void txtEdit_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim Index As Short = txtEdit.GetIndex(eventSender)
			TextBox txtBox = new TextBox();
			txtBox = (TextBox)eventSender;
			txtBox.SelectionStart = 0;
			txtBox.SelectionLength = 999;
		}

		private void txtEdit_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short Shift = eventArgs.KeyCode;
			short Index = eventArgs.KeyData / 0x10000;
			TextBox txtBox = new TextBox();
			txtBox = (TextBox)eventSender;
			short KeyCode = txtEdit.GetIndex(eventSender);
			var _with7 = this.gridItem;
			switch (KeyCode) {
				case 27:
					//ESC
					txtBox.Visible = false;
					_with7.Focus();
					break;
				case 13:
					//ENTER
					_with7.Focus();
					System.Windows.Forms.Application.DoEvents();
					moveNext(ref ref Index, ref ref 1);
					break;
				case 37:
					//Left arrow
					if (txtBox.SelectionStart == 0 & txtBox.SelectionLength == 0) {
						_with7.Focus();
						System.Windows.Forms.Application.DoEvents();
						moveNext(ref ref Index, ref ref -1);
					}
					break;
				case 39:
					//Right arrow
					if (txtBox.SelectionStart == Strings.Len(txtBox.Text)) {
						_with7.Focus();
						System.Windows.Forms.Application.DoEvents();
						moveNext(ref ref Index, ref ref 1);
					}
					break;
				case 38:
					//Up arrow
					_with7.Focus();
					System.Windows.Forms.Application.DoEvents();
					moveNext(ref ref Index, ref ref -1);
					break;
				case 40:
					//Down arrow
					_with7.Focus();
					System.Windows.Forms.Application.DoEvents();
					moveNext(ref ref Index, ref ref 1);
					break;
			}
		}

		private int moveNext(ref int Index, ref int direction)
		{
			short x = 0;
			short y = 0;

			x = gridItem.row + direction;

			if (x >= gridItem.RowCount | x < gridItem.FixedRows) {
			} else {
				gridItem.row = x;
			}

			txtEdit[Index].SelectionStart = 0;
			txtEdit[Index].SelectionLength = 999;

			if (txtEdit[Index].Visible)
				txtEdit[Index].Focus();

			//UPGRADE_WARNING: Couldn't resolve default property of object moveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			return true;
		}

		private object moveNext_OLD(ref object direction)
		{
			//    Dim x, y As Integer
			//
			//    x = gridItem.row + direction
			//
			//    If x >= gridItem.RowCount Or x < gridItem.FixedRows Then
			//    Else
			//        gridItem.row = x
			//    End If
			//
			//    txtEdit.SelStart = 0
			//    txtEdit.SelLength = 999
			//    txtEdit.SetFocus
			//
			//    moveNext = True
		}

		private void txtEdit_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short Index = Strings.Asc(eventArgs.KeyChar);
			short KeyAscii = txtEdit.GetIndex(eventSender);
			//
			// Delete carriage returns to get rid of beep
			// and only allow numbers.
			//
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
				default:
					KeyAscii = 0;
					break;
			}
			eventArgs.KeyChar = Strings.Chr(Index);
			if (Index == 0) {
				eventArgs.Handled = true;
			}
		}
	}
}
