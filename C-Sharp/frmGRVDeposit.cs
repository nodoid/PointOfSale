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
	internal partial class frmGRVDeposit : System.Windows.Forms.Form
	{
//Option Explicit

//Dim lDOM As DOMDocument
//Dim gDOMOrder As DOMDocument
		bool loading;
		public short orderType;

		const short colName = 0;
		const short colType = 1;
		const short colQuantity = 2;
		const short colPackSize = 3;
		const short colExclusivePrice = 4;
		const short colExclusiveAmount = 5;
		const short colInclusivePrice = 6;
		const short colInclusiveAmount = 7;

		private void loadLanguage()
		{

			//frmGRVDeposit = No Code    [Deposit Returns Form]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmGRVDeposit.Caption = rsLang("LanguageLayoutLnk_Description"): frmGRVDeposit.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1148;
			//Delete|Checked
			if (modRecordSet.rsLang.RecordCount){cmdDelete.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdDelete.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//Note: DB Entry 1579 does not contain "<<" chars!
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1579;
			//Back|Checked
			if (modRecordSet.rsLang.RecordCount){cmdBack.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdBack.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1005;
			//Next|Checked
			if (modRecordSet.rsLang.RecordCount){cmdNext.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdNext.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lblSupplier = No Code/Dynamic/NA?

			//lblReturns = No Code       [PURCHASES]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblReturns.Caption = rsLang("LanguageLayoutLnk_Description"): lblReturns.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1685;
			//Sub Totals|Checked
			if (modRecordSet.rsLang.RecordCount){frmTotals.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;frmTotals.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lbl(8) = No Code           [No Of Cases]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lbl(8).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(8).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_0 = No Code           [Exclusive Amount]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lbl(9) = No Code           [Inclusive Amount]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lbl(9).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(9).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmGRVDeposit.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void getOrder()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			short ltype = 0;
			//    sql = "SELECT " & orderType & " AS depositType, GRV.GRVID, DISPLAY_SupplierDeposit.SupplierDepositLnk_SupplierID, DISPLAY_SupplierDeposit.SupplierDepositLnk_DepositID, DISPLAY_SupplierDeposit.SupplierDepositLnk_Type, DISPLAY_SupplierDeposit.SupplierDepositLnk_Name, DISPLAY_SupplierDeposit.Deposit_Quantity, DISPLAY_SupplierDeposit.Deposit_UnitCost, DISPLAY_SupplierDeposit.Deposit_CaseCost, DISPLAY_SupplierDeposit.Vat_Amount FROM DISPLAY_SupplierDeposit INNER JOIN (PurchaseOrder INNER JOIN GRV ON PurchaseOrder.PurchaseOrderID = GRV.GRV_PurchaseOrderID) ON DISPLAY_SupplierDeposit.SupplierDepositLnk_SupplierID = PurchaseOrder.PurchaseOrder_SupplierID Where (((DISPLAY_SupplierDeposit.SupplierDepositLnk_Type = 3) And (DISPLAY_SupplierDeposit.Deposit_UnitCost <> 0) And (DISPLAY_SupplierDeposit.Deposit_Quantity <> 1)) Or ((DISPLAY_SupplierDeposit.SupplierDepositLnk_Type = 2) And (DISPLAY_SupplierDeposit.Deposit_Quantity <> 1)) Or (DISPLAY_SupplierDeposit.Deposit_Quantity = 1)) and "
			//    sql = sql & "(((GRV.GRVID) = " & frmGRV.adoPrimaryRS("GRVID") & ") And ((GRV.GRV_GRVStatusID) = 1)) ORDER BY DISPLAY_SupplierDeposit.SupplierDepositLnk_Name;"

			sql = "SELECT " + orderType + " AS depositType, GRV.GRVID, DISPLAY_SupplierDeposit.SupplierDepositLnk_SupplierID, DISPLAY_SupplierDeposit.SupplierDepositLnk_DepositID, DISPLAY_SupplierDeposit.SupplierDepositLnk_Type, DISPLAY_SupplierDeposit.SupplierDepositLnk_Name, DISPLAY_SupplierDeposit.Deposit_Quantity, DISPLAY_SupplierDeposit.Deposit_UnitCost, DISPLAY_SupplierDeposit.Deposit_CaseCost, DISPLAY_SupplierDeposit.Vat_Amount FROM Deposit INNER JOIN (DISPLAY_SupplierDeposit INNER JOIN (PurchaseOrder INNER JOIN GRV ON PurchaseOrder.PurchaseOrderID = GRV.GRV_PurchaseOrderID) ON DISPLAY_SupplierDeposit.SupplierDepositLnk_SupplierID = PurchaseOrder.PurchaseOrder_SupplierID) ON Deposit.DepositID = DISPLAY_SupplierDeposit.SupplierDepositLnk_DepositID ";
			sql = sql + "Where (((DISPLAY_SupplierDeposit.SupplierDepositLnk_Type = 3) And (DISPLAY_SupplierDeposit.Deposit_UnitCost <> 0) And (DISPLAY_SupplierDeposit.Deposit_Quantity <> 1)) Or ((DISPLAY_SupplierDeposit.SupplierDepositLnk_Type = 2) And (DISPLAY_SupplierDeposit.Deposit_Quantity <> 1)) Or (DISPLAY_SupplierDeposit.Deposit_Quantity = 1)) And ";
			sql = sql + "(((GRV.GRVID) = " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") And ((GRV.GRV_GRVStatusID) = 1)) and deposit_disabled = 0 ORDER BY DISPLAY_SupplierDeposit.SupplierDepositLnk_Name;";

			rs = modRecordSet.getRS(ref sql);

			decimal lDeposit = default(decimal);
			short x = 0;
			loading = true;
			var _with1 = gridItem;
			_with1.RowCount = rs.RecordCount + 1;
			x = 0;
			while (!(rs.EOF)) {
				x = x + 1;
				_with1.set_RowData(x, rs.Fields("SupplierDepositLnk_DepositID").Value);
				_with1.set_TextMatrix(x, colName, rs.Fields("SupplierDepositLnk_Name").Value);
				_with1.set_TextMatrix(x, colQuantity, Strings.FormatNumber(0, 0));
				switch (Convert.ToInt16(rs.Fields("SupplierDepositLnk_Type").Value)) {
					case 1:
						lDeposit = Convert.ToDecimal(rs.Fields("Deposit_UnitCost").Value);
						_with1.set_TextMatrix(x, colType, "Unit");
						break;
					case 2:
						lDeposit = Convert.ToDecimal(rs.Fields("Deposit_CaseCost").Value);
						_with1.set_TextMatrix(x, colType, "Crate-Empty");
						break;
					case 3:
						lDeposit = Convert.ToDecimal(rs.Fields("Deposit_UnitCost").Value) * Convert.ToDecimal(rs.Fields("Deposit_Quantity").Value) + Convert.ToDecimal(rs.Fields("Deposit_CaseCost").Value);
						_with1.set_TextMatrix(x, colType, "Case-Full");
						break;

				}
				_with1.set_TextMatrix(x, colPackSize, Strings.FormatNumber(rs.Fields("Deposit_Quantity").Value, 0));
				_with1.set_TextMatrix(x, colExclusivePrice, Strings.FormatNumber(0 - lDeposit, 2));
				_with1.set_TextMatrix(x, colExclusiveAmount, Strings.FormatNumber(0, 2));
				_with1.set_TextMatrix(x, colInclusivePrice, Strings.FormatNumber(0 - (lDeposit * (1 + rs.Fields("Vat_Amount").Value / 100)), 2));
				_with1.set_TextMatrix(x, colInclusiveAmount, Strings.FormatNumber(0, 2));
				_with1.row = x;
				_with1.Col = colName;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 222));
				_with1.Col = colType;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 222));
				_with1.Col = colPackSize;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 222));
				_with1.Col = colExclusivePrice;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 222));
				_with1.Col = colExclusiveAmount;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(255, 200, 200));
				_with1.Col = colInclusivePrice;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 222));
				_with1.Col = colInclusiveAmount;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(255, 200, 200));
				rs.moveNext();
			}
			_with1.Col = colQuantity;
			rs.Close();
			sql = "SELECT GRVDeposit.GRVDeposit_GRVID, GRVDeposit.GRVDeposit_DepositID, GRVDeposit.GRVDeposit_Return, GRVDeposit.GRVDeposit_Type, GRVDeposit.GRVDeposit_Quantity From GRVDeposit WHERE (((GRVDeposit.GRVDeposit_GRVID)=" + _4PosBackOffice.NET.My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVDeposit.GRVDeposit_Return)=" + orderType + "));";
			rs = modRecordSet.getRS(ref ref sql);
			while (!(rs.EOF)) {
				for (x = 1; x <= _with1.RowCount - 1; x++) {
					if (_with1.get_RowData(x) == rs.Fields("GRVDeposit_DepositID").Value) {

						switch (_with1.get_TextMatrix(x, colType)) {
							case "Unit":
								ltype = 1;
								break;
							case "Crate-Empty":
								ltype = 2;
								break;
							case "Case-Full":
								ltype = 3;
								break;
						}
						if (ltype == rs.Fields("GRVDeposit_Type").Value) {
							_with1.set_TextMatrix(x, colQuantity, Strings.FormatNumber(rs.Fields("GRVDeposit_Quantity").Value, 0));
							_with1.set_TextMatrix(x, colExclusiveAmount, Strings.FormatNumber(Convert.ToDouble(_with1.get_TextMatrix(x, colExclusivePrice)) * Convert.ToDouble(_with1.get_TextMatrix(x, colQuantity)), 2));
							_with1.set_TextMatrix(x, colInclusiveAmount, Strings.FormatNumber(Convert.ToDouble(_with1.get_TextMatrix(x, colInclusivePrice)) * Convert.ToDouble(_with1.get_TextMatrix(x, colQuantity)), 2));
						}
					}
				}
				rs.moveNext();
			}

			doTotals();
			loading = false;
		}

		private void setup()
		{
			loading = true;
			lblSupplier.Text = My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("Supplier_Name").Value + "(" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("PurchaseOrder_Reference").Value + ")";
			var _with2 = gridItem;
			gridItem.ColumnCount = 8;
			gridItem.RowCount = 1;
			gridItem.row = 0;
			gridItem.Col = colName;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colName, ref ref "Description");
			gridItem.set_colAlignment(ref ref colName, ref ref 1);
			gridItem.set_ColWidth(ref ref colName, ref ref 2500);
			gridItem.Col = colType;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colType, ref ref "Type");
			gridItem.set_colAlignment(ref ref colType, ref ref 1);
			gridItem.set_ColWidth(ref ref colType, ref ref 900);
			gridItem.Col = colQuantity;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colQuantity, ref ref "QTY");
			gridItem.set_colAlignment(ref ref colQuantity, ref ref 7);
			gridItem.set_ColWidth(ref ref colQuantity, ref ref 600);
			gridItem.Col = colPackSize;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colPackSize, ref ref "");
			gridItem.set_colAlignment(ref ref colPackSize, ref ref 7);
			gridItem.set_ColWidth(ref ref colPackSize, ref ref 900);
			gridItem.Col = colExclusivePrice;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colExclusivePrice, ref ref "Excl Price");
			gridItem.set_colAlignment(ref ref colExclusivePrice, ref ref 7);
			gridItem.set_ColWidth(ref ref colExclusivePrice, ref ref 1000);
			gridItem.Col = colExclusiveAmount;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colExclusiveAmount, ref ref "Excl Amt");
			gridItem.set_colAlignment(ref ref colExclusiveAmount, ref ref 7);
			gridItem.set_ColWidth(ref ref colExclusiveAmount, ref ref 1100);
			gridItem.Col = colInclusivePrice;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colInclusivePrice, ref ref "Incl Price");
			gridItem.set_colAlignment(ref ref colInclusivePrice, ref ref 7);
			gridItem.set_ColWidth(ref ref colInclusivePrice, ref ref 1000);
			gridItem.Col = colInclusiveAmount;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colInclusiveAmount, ref ref "Incl Amt");
			gridItem.set_colAlignment(ref ref colInclusiveAmount, ref ref 7);
			gridItem.set_ColWidth(ref ref colInclusiveAmount, ref ref 1100);
			gridItem.CellFontBold = true;
			loading = false;
		}


		private void cmdBack_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (orderType) {
				this.loadDeposits(ref 0);
			} else {
				this.Close();
			}

		}

		private void cmdDelete_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short ltype = 0;
			if (gridItem.row) {
				if (Interaction.MsgBox("Are you sure you wish to delete the deposit item '" + gridItem.get_TextMatrix(ref gridItem.row, ref 0) + "' from this order?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Delete Line Item") == MsgBoxResult.Yes) {
					switch (gridItem.get_TextMatrix(ref gridItem.row, ref colType)) {
						case "Unit":
							ltype = 1;
							break;
						case "Crate-Empty":
							ltype = 2;
							break;
						case "Case-Full":
							ltype = 3;
							break;
					}

					modRecordSet.cnnDB.Execute("DELETE FROM GRVDeposit Where (GRVDeposit_GRVID = " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") And (GRVDeposit_DepositID = " + gridItem.get_RowData(ref gridItem.row) + ") And (GRVDeposit_Type = " + ltype + ") And (GRVDeposit.GRVDeposit_Return=" + orderType + ");");

					getOrder();
					if (gridItem.RowCount > 1) {
						gridItem.row = 1;
						gridItem_EnterCell(gridItem, new System.EventArgs());
					} else {
						txtEdit.Visible = false;
					}
				}
			}
		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
			System.Windows.Forms.Application.DoEvents();
			My.MyProject.Forms.frmGRVitem.Close();
			System.Windows.Forms.Application.DoEvents();
			My.MyProject.Forms.frmGRV.Close();
		}

		private void doTotals()
		{
			decimal lDepositEInclusive = default(decimal);
			short x = 0;
			short lQuantity = 0;
			decimal lDepositExclusive = default(decimal);
			decimal lDepositInclusive = default(decimal);
			lDepositExclusive = 0;
			lDepositEInclusive = 0;
			lQuantity = 0;
			for (x = 1; x <= gridItem.RowCount - 1; x++) {
				lDepositExclusive = lDepositExclusive + Convert.ToDecimal(gridItem.get_TextMatrix(ref x, ref colExclusiveAmount));
				lDepositInclusive = lDepositInclusive + Convert.ToDecimal(gridItem.get_TextMatrix(ref x, ref colInclusiveAmount));
				lQuantity = lQuantity + Convert.ToInt16(gridItem.get_TextMatrix(ref x, ref colQuantity));

			}

			lblQuantity.Text = Strings.FormatNumber(lQuantity, 0);
			lblDepositExclusive.Text = Strings.FormatNumber(lDepositExclusive, 2);
			lblDepositInclusive.Text = Strings.FormatNumber(lDepositInclusive, 2);
		}


		private void cmdNext_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (orderType) {
				My.MyProject.Forms.frmGRVSummary.loadSummary();
			} else {
				this.loadDeposits(ref 1);
			}
		}

		private void frmGRVDeposit_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			int x = 0;
			frmTotals.Top = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(ClientRectangle.Height, false) - sizeConvertors.pixelToTwips(frmTotals.Height, false), false);
			frmTotals.Left = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(ClientRectangle.Width, true) - sizeConvertors.pixelToTwips(frmTotals.Width, true), true);
			gridItem.Height = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(ClientRectangle.Height, false) - sizeConvertors.pixelToTwips(gridItem.Top, false) - sizeConvertors.pixelToTwips(frmTotals.Height, false), false);
			gridItem.Width = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(ClientRectangle.Width, true) - sizeConvertors.pixelToTwips(gridItem.Left, true), true);
			int lWidth = 0;
			lWidth = sizeConvertors.pixelToTwips(gridItem.Width, true) - 450;
			for (x = 0; x <= gridItem.ColumnCount - 1; x++) {
				if (x == colName) {
				} else {
					lWidth = lWidth - gridItem.get_ColWidth(ref x);
				}
			}
			if (lWidth > 200) {
				gridItem.set_ColWidth(ref colName, ref lWidth);
			} else {
				gridItem.set_ColWidth(ref colName, ref 2000);
			}

			lblReturns.Top = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(frmTotals.Top, false) + (sizeConvertors.pixelToTwips(frmTotals.Height, false) - sizeConvertors.pixelToTwips(lblReturns.Height, false)) / 2, false);
			lblReturns.Left = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(frmTotals.Left, true) - sizeConvertors.pixelToTwips(lblReturns.Width, true) - 100, true);
			lblReturns.Visible = orderType;


			gridItem_EnterCell(gridItem, new System.EventArgs());
		}

		private void update_Renamed()
		{
			if (loading)
				return;
			//    Dim lNode As IXMLDOMNode
			short x = 0;
			string sql = null;
			short ltype = 0;
			if (string.IsNullOrEmpty(txtEdit.Text))
				txtEdit.Text = "0";
			if (txtEdit.Text != txtEdit.Tag) {
				switch (gridItem.Col) {
					case colQuantity:
						switch (gridItem.get_TextMatrix(ref gridItem.row, ref colType)) {
							case "Unit":
								ltype = 1;
								break;
							case "Crate-Empty":
								ltype = 2;
								break;
							case "Case-Full":
								ltype = 3;
								break;
						}
						sql = "DELETE FROM GRVDeposit Where (GRVDeposit_GRVID = " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") And (GRVDeposit_DepositID = " + gridItem.get_RowData(ref gridItem.row) + ") And (GRVDeposit_Type = " + ltype + ") And (GRVDeposit.GRVDeposit_Return=" + orderType + ");";
						modRecordSet.cnnDB.Execute(sql);
						if (Convert.ToInt16(txtEdit.Text) != 0) {
							sql = "INSERT INTO GRVDeposit (GRVDeposit_GRVID, GRVDeposit_DepositID, GRVDeposit_Type, GRVDeposit_Return, GRVDeposit_Quantity) VALUES ";
							sql = sql + "(" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ", " + gridItem.get_RowData(ref gridItem.row) + ", " + ltype + ", " + orderType + ", " + Convert.ToInt16(txtEdit.Text) + ")";
							modRecordSet.cnnDB.Execute(sql);
						}
						gridItem.set_TextMatrix(ref gridItem.row, ref colQuantity, ref txtEdit.Text);
						txtEdit.Tag = txtEdit.Text;
						break;
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
			if (loading)
				return;
			int lValue = 0;
			var _with3 = gridItem;
			if (_with3.row) {
				if (string.IsNullOrEmpty(txtEdit.Text))
					lValue = 0;
				else
					lValue = Convert.ToInt32(txtEdit.Text);
				_with3.set_TextMatrix(_with3.row, colQuantity, lValue);
				_with3.set_TextMatrix(_with3.row, colExclusiveAmount, Strings.FormatNumber(Convert.ToDouble(_with3.get_TextMatrix(_with3.row, colExclusivePrice)) * lValue, 2));
				_with3.set_TextMatrix(_with3.row, colInclusiveAmount, Strings.FormatNumber(Convert.ToDouble(_with3.get_TextMatrix(_with3.row, colInclusivePrice)) * lValue, 2));
			}

			doTotals();
		}

		private void txtEdit_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			update_Renamed();
		}


		public void loadDeposits(ref short ltype)
		{

			//ResizeForm frmGRVDeposit, frmGRVDeposit.Width, frmGRVDeposit.Height, 2

			orderType = ltype;
			setup();
			getOrder();
			if (gridItem.RowCount) {
				loading = true;
				gridItem.Col = 0;
				gridItem.row = 0;
				loading = false;
				if (gridItem.RowCount > 1) {
					gridItem.Col = 1;
					gridItem.row = 1;
					txtEdit.Visible = true;
				} else {
					txtEdit.Visible = false;
				}
			}
			frmGRVDeposit_Resize(this, new System.EventArgs());

			loadLanguage();
			if (this.Visible) {
			} else {
				ShowDialog();
			}
		}

		private void gridItem_EnterCell(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			if (loading)
				return;
			var _with4 = gridItem;
			if (_with4.Col != colQuantity) {
				_with4.Col = colQuantity;
				return;
			}
			if (_with4.row) {
				txtEdit.SetBounds(sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with4.Left, true) + _with4.CellLeft, true), sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with4.Top, false) + _with4.CellTop, false), sizeConvertors.twipsToPixels(_with4.CellWidth, true), sizeConvertors.twipsToPixels(_with4.CellHeight, false));
				loading = true;
				txtEdit.Text = _with4.Text;
				txtEdit.Text = Strings.Replace(_with4.Text, ".", "");
				txtEdit.Text = Strings.Replace(_with4.Text, ",", "");
				if (txtEdit.Text == "000")
					txtEdit.Text = "0";
				txtEdit.Tag = txtEdit.Text;
				if (Strings.Left(gridItem.get_TextMatrix(ref ref gridItem.row, ref ref colName), 4) == "*** ") {

				} else {
					_with4.set_TextMatrix(_with4.row, colName, "*** " + _with4.get_TextMatrix(_with4.row, colName));
				}
				loading = false;
				txtEdit.Visible = true;
				if (this.Visible)
					txtEdit.Focus();
			}
		}

		private void gridItem_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtEdit_Enter(txtEdit, new System.EventArgs());
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
			if (Strings.Left(gridItem.get_TextMatrix(ref gridItem.row, ref colName), 4) == "*** ") {
				gridItem.set_TextMatrix(ref gridItem.row, ref colName, ref Strings.Mid(gridItem.get_TextMatrix(ref gridItem.row, ref colName), 5));
			}
		}

		private void txtEdit_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtEdit.SelectionStart = 0;
			txtEdit.SelectionLength = 999;
		}

		private void txtEdit_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			var _with5 = this.gridItem;
			switch (KeyCode) {
				case 27:
					//ESC
					txtEdit.Visible = false;
					_with5.Focus();
					break;
				case 13:
					//ENTER
					_with5.Focus();
					System.Windows.Forms.Application.DoEvents();
					moveNext(ref ref 1);
					break;
				case 37:
					//Left arrow
					if (txtEdit.SelectionStart == 0 & txtEdit.SelectionLength == 0) {
						_with5.Focus();
						System.Windows.Forms.Application.DoEvents();
						moveNext(ref ref -1);
					}
					break;
				case 39:
					//Right arrow
					if (txtEdit.SelectionStart == Strings.Len(txtEdit.Text)) {
						_with5.Focus();
						System.Windows.Forms.Application.DoEvents();
						moveNext(ref ref 1);
					}
					break;
				case 38:
					//Up arrow
					_with5.Focus();
					System.Windows.Forms.Application.DoEvents();
					moveNext(ref ref -1);
					break;
				case 40:
					//Down arrow
					_with5.Focus();
					System.Windows.Forms.Application.DoEvents();
					moveNext(ref ref 1);
					break;
			}
		}
		private bool moveNext(ref short direction)
		{
			short x = 0;
			short y = 0;

			x = gridItem.row + direction;

			if (x >= gridItem.RowCount | x < gridItem.FixedRows) {
			} else {
				gridItem.row = x;
			}

			txtEdit.SelectionStart = 0;
			txtEdit.SelectionLength = 999;
			txtEdit.Focus();

			return true;
		}

		private void txtEdit_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
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
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
	}
}
