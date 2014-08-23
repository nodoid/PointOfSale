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
	internal partial class frmGRVitemFnV : System.Windows.Forms.Form
	{
//Option Explicit

//Dim gDOM As DOMDocument
//Dim gDOMOrder As DOMDocument
		bool loading;

		public short colName;
		public short colQuantity;
		public short colPackSize;
		public short colDiscountLine;
		public short colDiscount;
		public short colDiscountPercentage;
		public short colOnOrder;

		public short colCode;
		public short colContentExclusive;
		public short colContentInclusive;
		public short colContentTotalExclusive;
		public short colContentTotalInclusive;
		public short colDepositExclusive;
		public short colDepositInclusive;
		public short colDepositTotalExclusive;
		public short colDepositTotalInclusive;
		public short colTotalExclusive;
		public short colTotalInclusive;
		public short colExclusive;
		public short colInclusive;
		public short colPrice;
		public short colBrokenPack;
		public short colVAT;
		public short colFractions;
		public bool lockLine;

		bool gStockItems;
		public short orderType;
		public short activePrice;
		public bool gQuickKey;
//Public gNodeTemplate As IXMLDOMNode
		public string gFieldDisplay;
		public string gFieldOrder;
		public string gFieldOrderDefault;
		public string gFieldDisplayDefault;
		public string gGRVFieldOrder;

		bool gFractions;
		List<TextBox> txtEdit = new List<TextBox>();

		ADODB.Recordset rsPackSize;
		bool bFNVegPackSize;

		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1657;
			//GRV Processing Form|Checked
			if (modRecordSet.rsLang.RecordCount){My.MyProject.Forms.frmGRVitem.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;My.MyProject.Forms.frmGRVitem.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1583;
			//All Stock Items|Checked
			if (modRecordSet.rsLang.RecordCount){cmdStockItem.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdStockItem.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1148;
			//Delete|Checked
			if (modRecordSet.rsLang.RecordCount){cmdDelete.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdDelete.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1585;
			//Break / Build Pack|Checked
			if (modRecordSet.rsLang.RecordCount){cmdPack.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPack.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1661;
			//Change Price|Checked
			if (modRecordSet.rsLang.RecordCount){cmdPrice.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPrice.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1662;
			//Discount|Checked
			if (modRecordSet.rsLang.RecordCount){cmdDiscount.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdDiscount.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1663;
			//Quick Edit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdQuick.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdQuick.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1664;
			//Change VAT|Checked
			if (modRecordSet.rsLang.RecordCount){cmdVat.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdVat.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1665;
			//Print Order|Checked
			if (modRecordSet.rsLang.RecordCount){cmdPrintOrder.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPrintOrder.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1666;
			//Print GRV|Checked
			if (modRecordSet.rsLang.RecordCount){cmdPrintGRV.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPrintGRV.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1586;
			//Edit stock Item|Checked
			if (modRecordSet.rsLang.RecordCount){cmdEdit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdEdit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1668;
			//New Stock Item|Checked
			if (modRecordSet.rsLang.RecordCount){cmdNew.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdNew.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

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

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1591;
			//Stock Item Selector|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1838;
			//Barcode|Checked
			if (modRecordSet.rsLang.RecordCount){Label1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1080;
			//Search|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1714;
			//RETURNS|Checked
			if (modRecordSet.rsLang.RecordCount){lblReturns.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lblReturns.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1685;
			//Sub Totals|Checked
			if (modRecordSet.rsLang.RecordCount){frmTotals.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;frmTotals.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lbl(8) = No Code           [No of Cases]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lbl(8).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(8).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1717;
			//Broken Packs|
			if (modRecordSet.rsLang.RecordCount){_lbl_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lblTotal_0 = No Code      [Exclusive Content]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblTotal_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblTotal_1 = No Code      [Inclusive Content]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblTotal_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblTotal_2 = No Code      [Exclusive Deposit]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblTotal_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblTotal_3 = No Code      [Inclusive Deposit]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblTotal_3.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1688;
			//Exclusive Total|Checked
			if (modRecordSet.rsLang.RecordCount){_lblTotal_4.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblTotal_4.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1689;
			//Inclusive Total|Checked
			if (modRecordSet.rsLang.RecordCount){_lblTotal_5.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblTotal_5.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmGRVitemFnV.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}


		private void getOrder()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rs1 = default(ADODB.Recordset);
			decimal CurTot = default(decimal);
			System.Windows.Forms.TextBox oText = null;
			foreach (TextBox oText_loopVariable in txtEdit) {
				oText = oText_loopVariable;
				oText.Visible = false;
			}
			//    Dim lNode As IXMLDOMNode
			//    Dim lNodeList As IXMLDOMNodeList
			string lCode = null;
			if (string.IsNullOrEmpty(gGRVFieldOrder)) {
				lCode = gFieldOrder;
			} else {
				lCode = gGRVFieldOrder;
			}
			short x = 0;
			decimal lDeposit = default(decimal);
			rs = modRecordSet.getRS(ref "SELECT GRVItem.*, StockItem.*, Vat.Vat_Amount, Deposit.* FROM ((GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=" + orderType + ")) ORDER BY " + lCode + ";");


			loading = true;
			var _with1 = gridItem;
			_with1.Visible = false;
			//            xsl:Sort select="" data-type="text" order="asending
			_with1.RowCount = rs.RecordCount + 1;
			x = 0;
			while (!(rs.EOF)) {
				x = x + 1;
				_with1.row = x;
				_with1.set_RowData(x, rs.Fields("StockItemID").Value);
				_with1.Col = colFractions;
				_with1.set_TextMatrix(x, colFractions, rs.Fields("StockItem_Fractions").Value);

				_with1.Col = colPackSize;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 222));
				_with1.Col = colContentExclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 222));
				_with1.Col = colContentInclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(212, 212, 212));

				_with1.Col = colDepositExclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 222));
				_with1.Col = colDepositInclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(212, 212, 212));

				_with1.Col = colDepositTotalExclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(220, 220, 255));
				_with1.Col = colDepositTotalInclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(200, 200, 255));

				_with1.Col = colContentTotalExclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(220, 220, 255));
				_with1.Col = colContentTotalInclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(200, 200, 255));

				_with1.Col = colDiscount;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 200));
				_with1.Col = colDiscountLine;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 200));
				_with1.Col = colDiscountPercentage;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 200));
				_with1.Col = colOnOrder;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 222));

				_with1.Col = colExclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(220, 255, 220));
				_with1.Col = colInclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(200, 255, 200));

				_with1.Col = colTotalExclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(220, 255, 220));
				_with1.Col = colTotalInclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(200, 255, 200));


				if (gStockItems) {
					_with1.set_TextMatrix(x, colName, rs.Fields("StockItem_Name").Value);
				} else {
					if (Information.IsDBNull(rs.Fields(gFieldDisplay).Value)) {
						_with1.set_TextMatrix(x, colName, rs.Fields("StockItem_Name").Value);
					} else {
						_with1.set_TextMatrix(x, colName, rs.Fields("StockItem_Name").Value);
						// .TextMatrix(x, colName) = rs(gFieldDisplay)
					}
				}

				rs1 = modRecordSet.getRS(ref ref "SELECT PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk WHERE ((PriceChannelLnk.PriceChannelLnk_Quantity=1) AND (PriceChannelLnk.PriceChannelLnk_ChannelID=1) AND (PriceChannelLnk.PriceChannelLnk_StockItemID=" + rs.Fields("StockItemID").Value + "));");

				//Selling Price here
				if (rs1.RecordCount == 1) {
					_with1.set_TextMatrix(x, colPrice, Strings.FormatNumber(rs.Fields("GRVItem_Price").Value, 2));
					//FormatNumber(rs1("PriceChannelLnk_Price"), 2)

					//cnnDB.Execute "UPDATE GRVItem SET GRVItem_Price = " & FormatNumber(rs1("PriceChannelLnk_Price"), 2) & " Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS("GRVID") & ") And (GRVItem_StockItemID = " & rs("StockItemID") & ") And (GRVItem_Return = " & orderType & ")"
				} else {
					_with1.set_TextMatrix(x, colPrice, 0);
					//cnnDB.Execute "UPDATE GRVItem SET GRVItem_Price = " & FormatNumber(0, 2) & " Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS("GRVID") & ") And (GRVItem_StockItemID = " & rs("StockItemID") & ") And (GRVItem_Return = " & orderType & ")"
				}

				_with1.set_TextMatrix(x, colCode, "" + rs.Fields("GRVItem_Code").Value);
				_with1.set_TextMatrix(x, colVAT, Strings.FormatNumber(rs.Fields("GRVitem_VatRate").Value, 2));

				_with1.set_TextMatrix(x, colOnOrder, Strings.FormatNumber(rs.Fields("GRVItem_QuantityOrder").Value, 0));

				//Check for person security to not show Order QTY
				if (8192 & _4PosBackOffice.NET.My.MyProject.Forms.frmMenu.gBit) {
					if (rs.Fields("StockItem_Fractions").Value) {
						_with1.set_TextMatrix(x, colQuantity, Strings.FormatNumber(rs.Fields("GRVItem_Quantity").Value, 4));
					} else {
						_with1.set_TextMatrix(x, colQuantity, Strings.FormatNumber(rs.Fields("GRVItem_Quantity").Value, 0));
					}
				} else {
					if (rs.Fields("StockItem_Fractions").Value) {
						_with1.set_TextMatrix(x, colQuantity, Strings.FormatNumber(0, 4));
					} else {
						_with1.set_TextMatrix(x, colQuantity, Strings.FormatNumber(0, 0));
					}
				}
				//Check for person security to not show Order QTY

				_with1.set_TextMatrix(x, colPackSize, Strings.FormatNumber(rs.Fields("GRVItem_PackSize").Value, 0));

				if (_with1.get_TextMatrix(x, colPackSize) != Strings.FormatNumber(rs.Fields("StockItem_Quantity").Value, 0)) {
					_with1.Col = colPackSize;
					gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(255, 200, 200));
					_with1.set_TextMatrix(x, colBrokenPack, "X");
				} else {
					_with1.set_TextMatrix(x, colBrokenPack, "");
				}
				_with1.set_TextMatrix(x, colDiscount, Strings.FormatNumber(rs.Fields("GRVItem_DiscountAmount").Value, 4));
				if (this.activePrice == 1 | activePrice == 3) {
					_with1.set_TextMatrix(x, colDiscount, Convert.ToDecimal(_with1.get_TextMatrix(x, colDiscount)) * (1 + Convert.ToDouble(_with1.get_TextMatrix(x, colVAT)) / 100));
				}
				if (Convert.ToDecimal(_with1.get_TextMatrix(x, colDiscount)) != 0) {
					_with1.Col = colDiscount;
					gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(255, 200, 200));
					_with1.Col = colDiscountLine;
					gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(255, 200, 200));
					_with1.Col = colDiscountPercentage;
					gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(255, 200, 200));
				}
				if (rs.Fields("GRVItem_ContentCost").Value != rs.Fields("StockItem_ListCost").Value) {
					_with1.set_TextMatrix(x, colContentExclusive, Strings.FormatNumber(rs.Fields("GRVItem_ContentCost").Value, 2));
					// / rs("StockItem_Quantity") * rs("GRVItem_PackSize"), 2)
					//If .TextMatrix(x, colBrokenPack) = "X" Then .TextMatrix(x, colContentExclusive) = FormatNumber(rs("GRVItem_ContentCost") / FormatNumber(rs("StockItem_Quantity"), 0), 2)
				} else {
					_with1.set_TextMatrix(x, colContentExclusive, Strings.FormatNumber(rs.Fields("StockItem_ListCost").Value, 2));
					//FormatNumber(rs("GRVItem_ContentCost") / rs("StockItem_Quantity") * rs("GRVItem_PackSize"), 2)
				}
				if (_with1.get_TextMatrix(x, colBrokenPack) == "X")
					_with1.set_TextMatrix(x, colContentExclusive, Strings.FormatNumber(rs.Fields("GRVItem_ContentCost").Value / Convert.ToDouble(Strings.FormatNumber(rs.Fields("StockItem_Quantity").Value, 0)), 2));
				//cnnDB.Execute "UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_PackSize = [StockItem]![StockItem_Quantity], GRVItem.GRVItem_ContentCost = [StockItem]![StockItem_ListCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_StockItemID)=" & gridItem.RowData(gridItem.row) & ") AND ((GRVItem.GRVItem_Return)=" & orderType & "));"
				//Else
				//cnnDB.Execute "UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_PackSize = 1, GRVItem.GRVItem_ContentCost = [StockItem]![StockItem_ListCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_StockItemID)=" & gridItem.RowData(gridItem.row) & ") AND ((GRVItem.GRVItem_Return)=" & orderType & "));"
				//End If
				if (Convert.ToDecimal(rs.Fields("StockItem_ListCost").Value) != Convert.ToDecimal(rs.Fields("GRVItem_ContentCost").Value)) {
					_with1.Col = colContentExclusive;
					_with1.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(255, 200, 200));
					_with1.Col = colContentInclusive;
					_with1.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(255, 200, 200));
					_with1.Col = colExclusive;
					_with1.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(255, 200, 200));
					_with1.Col = colInclusive;
					_with1.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(255, 200, 200));
				}
				lDeposit = 0;
				lDeposit = rs.Fields("Deposit_UnitCost").Value * rs.Fields("GRVItem_PackSize").Value;
				if (rs.Fields("StockItem_Quantity").Value == rs.Fields("GRVItem_PackSize").Value) {
					lDeposit = lDeposit + rs.Fields("Deposit_CaseCost").Value;
				}
				if (colDepositExclusive) {
					_with1.set_TextMatrix(x, colDepositExclusive, Strings.FormatNumber(lDeposit, 2));
				} else {
					_with1.set_TextMatrix(x, colContentExclusive, Strings.FormatNumber(Convert.ToDecimal(_with1.get_TextMatrix(x, colContentExclusive)) + lDeposit, 2));
				}

				//total selling and gp

				displayLine(ref ref x);
				rs.moveNext();
			}
			_with1.Col = colQuantity;
			_with1.Visible = true;
			loading = false;
			doTotals();

		}

		private void displayLine(ref int row)
		{
			decimal lDiscount = default(decimal);
			var _with2 = gridItem;
			lDiscount = Convert.ToDecimal(_with2.get_TextMatrix(row, colDiscount));
			if (activePrice == 1 | activePrice == 3) {
				lDiscount = lDiscount / (1 + Convert.ToDouble(_with2.get_TextMatrix(row, colVAT)) / 100);
			}
			_with2.set_TextMatrix(row, colDepositTotalExclusive, Strings.FormatNumber(Convert.ToDouble(_with2.get_TextMatrix(row, colDepositExclusive)) * Convert.ToDouble(_with2.get_TextMatrix(row, colQuantity)), 2));
			_with2.set_TextMatrix(row, colContentTotalExclusive, Strings.FormatNumber((Convert.ToDouble(_with2.get_TextMatrix(row, colContentExclusive)) - lDiscount) * Convert.ToDouble(_with2.get_TextMatrix(row, colQuantity)), 2));

			_with2.set_TextMatrix(row, colTotalExclusive, Strings.FormatNumber(Convert.ToDecimal(_with2.get_TextMatrix(row, colContentTotalExclusive)) + Convert.ToDecimal(_with2.get_TextMatrix(row, colDepositTotalExclusive)), 2));
			_with2.set_TextMatrix(row, colExclusive, Strings.FormatNumber(Convert.ToDecimal(_with2.get_TextMatrix(row, colContentExclusive)) + Convert.ToDecimal(_with2.get_TextMatrix(row, colDepositExclusive)), 2));

			_with2.set_TextMatrix(row, colContentInclusive, Strings.FormatNumber(Convert.ToDecimal(_with2.get_TextMatrix(row, colContentExclusive)) + Convert.ToDecimal(_with2.get_TextMatrix(row, colContentExclusive)) * Convert.ToDecimal(_with2.get_TextMatrix(row, colVAT)) / 100, 2));
			_with2.set_TextMatrix(row, colDepositInclusive, Strings.FormatNumber(Convert.ToDecimal(_with2.get_TextMatrix(row, colDepositExclusive)) + Convert.ToDecimal(_with2.get_TextMatrix(row, colDepositExclusive)) * Convert.ToDecimal(_with2.get_TextMatrix(row, colVAT)) / 100, 2));
			_with2.set_TextMatrix(row, colContentTotalInclusive, Strings.FormatNumber(Convert.ToDecimal(_with2.get_TextMatrix(row, colContentTotalExclusive)) + Convert.ToDecimal(_with2.get_TextMatrix(row, colContentTotalExclusive)) * Convert.ToDecimal(_with2.get_TextMatrix(row, colVAT)) / 100, 2));
			_with2.set_TextMatrix(row, colDepositTotalInclusive, Strings.FormatNumber(Convert.ToDecimal(_with2.get_TextMatrix(row, colDepositTotalExclusive)) + Convert.ToDecimal(_with2.get_TextMatrix(row, colDepositTotalExclusive)) * Convert.ToDecimal(_with2.get_TextMatrix(row, colVAT)) / 100, 2));

			_with2.set_TextMatrix(row, colTotalInclusive, Strings.FormatNumber(Convert.ToDecimal(_with2.get_TextMatrix(row, colTotalExclusive)) + Convert.ToDecimal(_with2.get_TextMatrix(row, colTotalExclusive)) * Convert.ToDecimal(_with2.get_TextMatrix(row, colVAT)) / 100, 2));

			_with2.set_TextMatrix(row, colInclusive, Strings.FormatNumber(Convert.ToDecimal(_with2.get_TextMatrix(row, colExclusive)) + Convert.ToDecimal(_with2.get_TextMatrix(row, colExclusive)) * Convert.ToDecimal(_with2.get_TextMatrix(row, colVAT)) / 100, 2));
			if (Convert.ToDecimal(gridItem.get_TextMatrix(ref ref gridItem.row, ref ref colContentExclusive)) == 0) {
				gridItem.set_TextMatrix(ref ref gridItem.row, ref ref colDiscountPercentage, ref ref 0);
			} else {
				gridItem.set_TextMatrix(ref ref gridItem.row, ref ref colDiscountPercentage, ref ref Strings.FormatNumber(Convert.ToDecimal(_with2.get_TextMatrix(row, colDiscount)) / Convert.ToDecimal(gridItem.get_TextMatrix(ref ref gridItem.row, ref ref colContentExclusive)) * 100, 2));
			}
			gridItem.set_TextMatrix(ref ref gridItem.row, ref ref colDiscountLine, ref ref Strings.FormatNumber(Convert.ToDecimal(_with2.get_TextMatrix(row, colDiscount)) * Convert.ToDouble(gridItem.get_TextMatrix(ref ref gridItem.row, ref ref colQuantity)), 2));

			_with2.set_TextMatrix(row, colDepositTotalExclusive, Strings.FormatNumber(Convert.ToDouble(_with2.get_TextMatrix(row, colPrice)) * Convert.ToDouble(_with2.get_TextMatrix(row, colQuantity)), 2));
			if (Convert.ToDouble(_with2.get_TextMatrix(row, colContentTotalExclusive)) > 0 & Convert.ToDouble(_with2.get_TextMatrix(row, colDepositTotalExclusive)) > 0) {
				_with2.set_TextMatrix(row, colDepositTotalInclusive, Strings.FormatNumber(100 - ((Convert.ToDouble(_with2.get_TextMatrix(row, colContentTotalExclusive)) / Convert.ToDouble(_with2.get_TextMatrix(row, colDepositTotalExclusive))) * 100), 2));
			}

		}

		private void getNamespace()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string lString = null;
			string lWhere1 = null;
			lString = Strings.Trim(txtSearch.Text);
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");


			if (string.IsNullOrEmpty(Strings.Trim(txtSearch.Text))) {
				lString = "";
			} else {
				lWhere1 = "(StockItem_SupplierCode LIKE '%" + Strings.Replace(lString, " ", "%' AND StockItem_SupplierCode LIKE '%") + "%')";
				lString = "(StockItem_Name LIKE '%" + Strings.Replace(lString, " ", "%' AND StockItem_Name LIKE '%") + "%')";
				lString = lString + " OR " + lWhere1;
			}

			if (string.IsNullOrEmpty(lString)) {
				lString = " StockItem.StockItem_Discontinued=0 ";
			} else {
				lString = " StockItem.StockItem_Discontinued=0 AND " + lString;
			}

			if (gStockItems) {
				if (!string.IsNullOrEmpty(lString))
					lString = " WHERE " + lString;
				rs = modRecordSet.getRS(ref "SELECT TOP 100 PERCENT StockItem.StockItemID, StockItem.StockItem_Name AS name From StockItem " + lString + " ORDER BY StockItem.StockItem_Name;");
			} else {
				if (!string.IsNullOrEmpty(lString))
					lString = " AND " + lString;
				rs = modRecordSet.getRS(ref "SELECT TOP 100 PERCENT StockItemID, StockItem_Name as name From StockItem Where (StockItem_SupplierID = " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("SupplierID").Value + ") " + lString + " ORDER BY StockItem_Name");
			}
			lstWorkspace.Items.Clear();
			string lName = null;
			if (rs.RecordCount) {
				while (!(rs.EOF)) {
					lstWorkspace.Items.Add(rs.Fields("name").Value + " " + rs.Fields("StockItemID").Value);
					rs.moveNext();
				}
			} else {
				if (Information.IsNumeric(txtSearch.Text)) {
					rs = modRecordSet.getRS(ref "SELECT TOP 100 PERCENT StockItem.StockItemID, StockItem.StockItem_Name as Name, Catalogue.Catalogue_Quantity FROM StockItem INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID Where (((Catalogue.Catalogue_Barcode) = '" + txtSearch.Text + "')) GROUP BY StockItem.StockItemID, StockItem.StockItem_Name, Catalogue.Catalogue_Quantity ORDER BY StockItem.StockItem_Name;");

					while (!(rs.EOF)) {
						lstWorkspace.Items.Add(rs.Fields("name").Value + " " + rs.Fields("StockItemID").Value);
						rs.moveNext();
					}
					if (lstWorkspace.Items.Count) {
						lstWorkspace.SelectedIndex = 0;
						lstWorkspace_DoubleClick(lstWorkspace, new System.EventArgs());
						this._txtEdit_0.Focus();
						return;
					}
				}
			}
			if (lstWorkspace.Items.Count) {
				lstWorkspace.SelectedIndex = 0;
				 // ERROR: Not supported in C#: OnErrorStatement

				lstWorkspace.Focus();
			}
		}

		private void setup()
		{
			loading = true;
			//    Dim lDOM As DOMDocument
			//    Dim lNode As IXMLDOMNode
			//    Dim lNodeList As IXMLDOMNodeList
			lblSupplier.Text = My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("Supplier_Name").Value + "(" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("PurchaseOrder_Reference").Value + ")";
			lblReturns.Visible = orderType;

			var _with3 = gridItem;
			gridItem.row = 0;

			gridItem.Col = 24;

			gridItem.set_RowHeight(ref ref 0, ref ref 430);
			gridItem.Col = colTotalExclusive;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colTotalExclusive, ref ref "Total Excl");
			gridItem.set_colAlignment(ref ref colTotalExclusive, ref ref 7);
			gridItem.set_ColWidth(ref ref colTotalExclusive, ref ref 900);

			gridItem.Col = colTotalInclusive;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colTotalInclusive, ref ref "Total Incl");
			gridItem.set_colAlignment(ref ref colTotalInclusive, ref ref 7);
			gridItem.set_ColWidth(ref ref colTotalInclusive, ref ref 900);

			gridItem.Col = colExclusive;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colExclusive, ref ref "Item Excl");
			gridItem.set_colAlignment(ref ref colExclusive, ref ref 7);
			gridItem.set_ColWidth(ref ref colExclusive, ref ref 900);

			gridItem.Col = colInclusive;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colInclusive, ref ref "Item Incl");
			gridItem.set_colAlignment(ref ref colInclusive, ref ref 7);
			gridItem.set_ColWidth(ref ref colInclusive, ref ref 900);


			gridItem.Col = colVAT;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colVAT, ref ref "VAT");
			gridItem.set_colAlignment(ref ref colVAT, ref ref 7);
			gridItem.set_ColWidth(ref ref colVAT, ref ref 500);

			gridItem.Col = colCode;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colCode, ref ref "Code");
			gridItem.set_colAlignment(ref ref colCode, ref ref 7);
			gridItem.set_ColWidth(ref ref colCode, ref ref 800);

			gridItem.Col = colName;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colName, ref ref "Description");
			gridItem.set_colAlignment(ref ref colName, ref ref 1);
			gridItem.set_ColWidth(ref ref colName, ref ref 2500);

			gridItem.Col = colBrokenPack;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colBrokenPack, ref ref "B");
			gridItem.set_colAlignment(ref ref colBrokenPack, ref ref 7);
			gridItem.set_ColWidth(ref ref colBrokenPack, ref ref 250);

			gridItem.Col = colDiscount;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colDiscount, ref ref "Disc. Item");
			gridItem.set_colAlignment(ref ref colDiscount, ref ref 7);
			gridItem.set_ColWidth(ref ref colDiscount, ref ref 800);
			gridItem.Col = colDiscountLine;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colDiscountLine, ref ref "Disc. Line");
			gridItem.set_colAlignment(ref ref colDiscountLine, ref ref 7);
			gridItem.set_ColWidth(ref ref colDiscountLine, ref ref 800);

			gridItem.Col = colDiscountPercentage;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colDiscountPercentage, ref ref "Disc. Percent");
			gridItem.set_colAlignment(ref ref colDiscountPercentage, ref ref 7);
			gridItem.set_ColWidth(ref ref colDiscountPercentage, ref ref 800);

			gridItem.Col = colOnOrder;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colOnOrder, ref ref "Ord");
			gridItem.set_colAlignment(ref ref colOnOrder, ref ref 7);
			gridItem.set_ColWidth(ref ref colOnOrder, ref ref 500);

			gridItem.Col = colQuantity;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colQuantity, ref ref "QTY");
			gridItem.set_colAlignment(ref ref colQuantity, ref ref 7);
			gridItem.set_ColWidth(ref ref colQuantity, ref ref 800);

			gridItem.Col = colPackSize;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colPackSize, ref ref "P");
			gridItem.set_colAlignment(ref ref colPackSize, ref ref 7);
			gridItem.set_ColWidth(ref ref colPackSize, ref ref 300);

			gridItem.Col = colContentExclusive;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colContentExclusive, ref ref "Content Excl");
			gridItem.set_colAlignment(ref ref colContentExclusive, ref ref 7);
			gridItem.set_ColWidth(ref ref colContentExclusive, ref ref 900);

			gridItem.Col = colPrice;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colPrice, ref ref "Selling");
			gridItem.set_colAlignment(ref ref colPrice, ref ref 7);
			gridItem.set_ColWidth(ref ref colPrice, ref ref 900);

			gridItem.Col = colContentInclusive;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colContentInclusive, ref ref "Content Incl");
			gridItem.set_colAlignment(ref ref colContentInclusive, ref ref 7);
			gridItem.set_ColWidth(ref ref colContentInclusive, ref ref 900);

			gridItem.Col = colContentTotalExclusive;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colContentTotalExclusive, ref ref "Total Con Excl");
			gridItem.set_colAlignment(ref ref colContentTotalExclusive, ref ref 7);
			gridItem.set_ColWidth(ref ref colContentTotalExclusive, ref ref 900);

			gridItem.Col = colContentTotalInclusive;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colContentTotalInclusive, ref ref "Total Con Incl");
			gridItem.set_colAlignment(ref ref colContentTotalInclusive, ref ref 7);
			gridItem.set_ColWidth(ref ref colContentTotalInclusive, ref ref 900);

			gridItem.Col = colDepositExclusive;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colDepositExclusive, ref ref "Deposit Excl");
			gridItem.set_colAlignment(ref ref colDepositExclusive, ref ref 7);
			gridItem.set_ColWidth(ref ref colDepositExclusive, ref ref 900);

			gridItem.Col = colDepositInclusive;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colDepositInclusive, ref ref "Deposit Incl");
			gridItem.set_colAlignment(ref ref colDepositInclusive, ref ref 7);
			gridItem.set_ColWidth(ref ref colDepositInclusive, ref ref 900);

			gridItem.Col = colDepositTotalExclusive;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colDepositTotalExclusive, ref ref "Total Selling");
			//"Total Dep Excl"
			gridItem.set_colAlignment(ref ref colDepositTotalExclusive, ref ref 7);
			gridItem.set_ColWidth(ref ref colDepositTotalExclusive, ref ref 900);

			gridItem.Col = colDepositTotalInclusive;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colDepositTotalInclusive, ref ref "GP%");
			//"Total Dep Incl"
			gridItem.set_colAlignment(ref ref colDepositTotalInclusive, ref ref 7);
			gridItem.set_ColWidth(ref ref colDepositTotalInclusive, ref ref 900);

			gridItem.Col = colFractions;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colFractions, ref ref "");
			gridItem.set_colAlignment(ref ref colFractions, ref ref 7);
			gridItem.set_ColWidth(ref ref colFractions, ref ref 1);

			loading = false;
		}

		private void cmdBack_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdBack.Focus();
			System.Windows.Forms.Application.DoEvents();
			if (orderType == 1) {
				orderType = 0;
				loadItem(ref false);
				frmGRVitemFnV_Resize(this, new System.EventArgs());
			} else {
				this.Close();
			}

		}

		private void cmdEditPackSize_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int id = 0;
			short x = 0;
			string sql = null;
			string lString = null;
			if (gridItem.row) {
				lString = Interaction.InputBox("Enter the Pack Size Volume for item '" + gridItem.get_TextMatrix(ref gridItem.row, ref colName) + "'.", "Enter Pack Size Volume", Strings.FormatNumber(Convert.ToDouble(txtPackSize.Text) * 100, 0, TriState.False, TriState.False, TriState.False));
				if (Information.IsNumeric(lString)) {
					if (Strings.InStr(lString, ".")) {
					} else {
						lString = Convert.ToString(Convert.ToDouble(lString) / 100);
					}
					id = gridItem.get_RowData(ref gridItem.row);
					modRecordSet.cnnDB.Execute("UPDATE GRVItem SET GRVItem.GRVItem_PackSizeVol = " + lString + " WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_StockItemID)=" + gridItem.get_RowData(ref gridItem.row) + ") AND ((GRVItem.GRVItem_Return)=" + orderType + "));");
					txtPackSize.Text = Strings.FormatNumber(lString, 2);
					//getOrder
					//X = findItem(id)
					//If X Then
					//    gridItem.row = X
					//    gridItem.Col = colQuantity
					//    _txtEdit_0.Visible = True
					//    gridItem_EnterCell
					//End If
				}
			}
		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modApplication.bolFNVegGRV = false;
			cmdExit.Focus();
			System.Windows.Forms.Application.DoEvents();
			this.Close();
			System.Windows.Forms.Application.DoEvents();
			My.MyProject.Forms.frmGRV.Close();
		}

		private void doTotals()
		{
			short x = 0;
			lblContentExclusive.Tag = 0;
			lblContentInclusive.Tag = 0;
			lblDepositExclusive.Tag = 0;
			lblDepositInclusive.Tag = 0;
			lblQuantity.Tag = 0;
			lblBrokenPack.Tag = 0;
			for (x = 1; x <= gridItem.RowCount - 1; x++) {
				lblContentExclusive.Tag = Convert.ToDouble(lblContentExclusive.Tag) + Convert.ToDecimal(gridItem.get_TextMatrix(ref x, ref colContentTotalExclusive));
				lblContentInclusive.Tag = Convert.ToDouble(lblContentInclusive.Tag) + Convert.ToDecimal(gridItem.get_TextMatrix(ref x, ref colContentTotalInclusive));
				//lblDepositExclusive.Tag = lblDepositExclusive.Tag + CCur(gridItem.TextMatrix(x, colDepositTotalExclusive))
				lblDepositInclusive.Tag = Convert.ToDouble(lblDepositInclusive.Tag) + Convert.ToDecimal(gridItem.get_TextMatrix(ref x, ref colDepositTotalExclusive));
				if (string.IsNullOrEmpty(gridItem.get_TextMatrix(ref x, ref colBrokenPack))) {
					//lblQuantity.Tag = lblQuantity.Tag + CInt(gridItem.TextMatrix(x, colQuantity))
					lblQuantity.Tag = Convert.ToDouble(lblQuantity.Tag) + Convert.ToDecimal(gridItem.get_TextMatrix(ref x, ref colQuantity));
				} else {
					//lblBrokenPack.Tag = lblBrokenPack.Tag + CInt(gridItem.TextMatrix(x, colQuantity))
					lblBrokenPack.Tag = Convert.ToDouble(lblBrokenPack.Tag) + Convert.ToDecimal(gridItem.get_TextMatrix(ref x, ref colQuantity));
				}

			}
			lblContentExclusive.Text = Strings.FormatNumber(lblContentExclusive.Tag, 2);
			lblContentInclusive.Text = Strings.FormatNumber(lblContentInclusive.Tag, 2);

			lblDepositInclusive.Text = Strings.FormatNumber(lblDepositInclusive.Tag, 2);
			if (Convert.ToDecimal(lblDepositInclusive.Tag) > 0 & Convert.ToDecimal(lblDepositInclusive.Tag) > 0) {
				lblDepositExclusive.Text = Strings.FormatNumber(100 - ((Convert.ToDecimal(lblContentExclusive.Tag) / Convert.ToDecimal(lblDepositInclusive.Tag)) * 100), 2);
			}
			//lblTotalExclusive.Caption = FormatNumber(CCur(lblContentExclusive.Tag) + CCur(lblDepositExclusive.Tag), 2)
			//lblTotalInclusive.Caption = FormatNumber(CCur(lblContentInclusive.Tag) + CCur(lblDepositInclusive.Tag), 2)
			lblTotalExclusive.Text = Strings.FormatNumber(Convert.ToDecimal(lblContentExclusive.Tag), 2);
			lblTotalInclusive.Text = Strings.FormatNumber(Convert.ToDecimal(lblContentInclusive.Tag), 2);


			lblQuantity.Text = Strings.FormatNumber(lblQuantity.Tag, 0);
			lblBrokenPack.Text = Strings.FormatNumber(lblBrokenPack.Tag, 0);
		}

		private void cmdNew_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modApplication.bGRVNewItemBarcode = true;
			frmStockItemNew form = new frmStockItemNew();
			form.Show();
			modApplication.bGRVNewItemBarcode = false;
		}

		private void cmdNext_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdNext.Focus();
			System.Windows.Forms.Application.DoEvents();

			//go direct to summary
			My.MyProject.Forms.frmGRVSummaryFnV.loadSummary();
			return;
			if (orderType == 0) {
				loadItem(ref true);
				frmGRVitemFnV_Resize(this, new System.EventArgs());

			} else {
				ADODB.Recordset rs = default(ADODB.Recordset);
				rs = modRecordSet.getRS(ref "SELECT SupplierDepositLnk.SupplierDepositLnk_SupplierID From SupplierDepositLnk WHERE (((SupplierDepositLnk.SupplierDepositLnk_SupplierID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("SupplierID").Value + "));");
				if (rs.BOF | rs.EOF) {
					My.MyProject.Forms.frmGRVSummary.loadSummary();

				} else {
					My.MyProject.Forms.frmGRVDeposit.loadDeposits(ref 0);
				}
			}
		}

		private void cmdPriceBOM_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (gridItem.row) {
				My.MyProject.Forms.frmStockMultiPrice.changePrice(ref gridItem.get_RowData(ref gridItem.row));
			}
		}

		private void cmdPrintOrder_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modApplication.report_PurchaseOrder(ref My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("PurchaseOrderID").Value);
			System.Windows.Forms.TextBox oText = null;
			foreach (TextBox oText_loopVariable in txtEdit) {
				oText = oText_loopVariable;
				if (oText.Visible)
					oText.Focus();
				break; // TODO: might not be correct. Was : Exit For
			}
		}

		private void cmdQuick_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (gridItem.row) {
				quickEdit();
			}
		}

		private void cmdStockItem_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short id = 0;
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

		private void cmdSort_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short x = 0;
			short id = 0;
			id = gridItem.get_RowData(ref gridItem.row);
			if (gFieldDisplayDefault == "BrandItemSupplier_Name") {
				if (gFieldDisplay == "StockItem_Name") {
					gFieldDisplay = "BrandItemSupplier_Name";
					gFieldOrder = gFieldOrderDefault;
				} else {
					gFieldDisplay = "StockItem_Name";
					gFieldOrder = "StockItem_Name";
				}
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

		private void setupGRV(ref string lDefaultType = "")
		{

			//Dim lNode As IXMLDOMNode
			short x = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			string ltype = null;
			if (string.IsNullOrEmpty(lDefaultType)) {
				rs = modRecordSet.getRS(ref "SELECT GRVTemplate.GRVTemplate_Name FROM Supplier INNER JOIN GRVTemplate ON Supplier.Supplier_GRVtype = GRVTemplate.GRVTemplate_Name WHERE (((Supplier.SupplierID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("SupplierID").Value + "));");
				if (rs.BOF | rs.EOF) {
					rs = modRecordSet.getRS(ref "SELECT Count(SupplierDepositLnk.SupplierDepositLnk_SupplierID) AS CountOfSupplierDepositLnk_SupplierID From SupplierDepositLnk WHERE (((SupplierDepositLnk.SupplierDepositLnk_SupplierID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("SupplierID").Value + "));");
					if (rs.Fields(0).Value) {
						ltype = "DefaultDeposit";
					} else {
						ltype = "Default";
					}

				} else {
					ltype = rs.Fields("GRVTemplate_Name").Value;
				}
				if (rs.State)
					rs.Close();
			} else {
				ltype = lDefaultType;
			}
			rs = modRecordSet.getRS(ref "SELECT * FROM GRVTemplate WHERE GRVTemplate_Name = '" + Strings.Replace(ltype, "'", "''") + "'");
			if (rs.RecordCount) {
			} else {
				ltype = "Default";
				rs = modRecordSet.getRS(ref "SELECT * FROM GRVTemplate WHERE GRVTemplate_Name = '" + Strings.Replace(ltype, "'", "''") + "'");
			}
			gQuickKey = rs.Fields("GRVTemplate_LaunchQuickKey").Value;
			activePrice = rs.Fields("GRVTemplate_PriceType").Value;
			if (rs.Fields("GRVTemplate_SortKey").Value == "brand") {
				gFieldDisplay = "BrandItemSupplier_Name";
				if (rs.Fields("GRVTemplate_SortOrder").Value == "code") {
					gFieldOrder = "BrandItemSupplier_Code";
				} else {
					gFieldOrder = "StockItem_Name";
				}
			} else {
				gFieldDisplay = "StockItem_Name";
				gFieldOrder = "StockItem_Name";
			}
			if (rs.Fields("GRVTemplate_SortType").Value) {
				gGRVFieldOrder = "GRVItem_Date";
			} else {
				gGRVFieldOrder = "";
			}

			gFieldOrderDefault = gFieldOrder;
			gFieldDisplayDefault = gFieldDisplay;
			rs = modRecordSet.getRS(ref "SELECT theJoin.GRVTemplateList_Code, IIf([GRVTemplateItem_Order] Is Null,99,[GRVTemplateItem_Order]) AS orderList, IIf([GRVTemplateItem_Order] Is Null,False,True) AS visible FROM GRVTemplateItem RIGHT JOIN [SELECT GRVTemplate.GRVTemplateID, GRVTemplate.GRVTemplate_Name, GRVTemplateList.GRVTemplateListID, GRVTemplateList.GRVTemplateList_Code From GRVTemplate, GRVTemplateList]. AS theJoin ON (GRVTemplateItem.GRVTemplateItem_GRVTemplateID = theJoin.GRVTemplateID) AND (GRVTemplateItem.GRVTemplateItem_GRVTemplateListID = theJoin.GRVTemplateListID) Where (((theJoin.GRVTemplate_Name) = '" + Strings.Replace(ltype, "'", "''") + "')) ORDER BY IIf([GRVTemplateItem_Order] Is Null,99,[GRVTemplateItem_Order]);");

			x = -1;
			while (!(rs.EOF)) {
				x = x + 1;
				Debug.Print(rs.Fields("GRVTemplateList_Code").Value);
				switch (Strings.LCase(rs.Fields("GRVTemplateList_Code").Value)) {
					case "colcode":
						colCode = x;
						break;
					case "colname":
						colName = x;
						break;
					case "colonorder":
						colOnOrder = x;
						break;
					case "colquantity":
						colQuantity = x;
						break;
					case "colbrokenpack":
						colBrokenPack = x;
						break;
					case "colpacksize":
						colPackSize = x;
						break;
					case "colcontentexclusive":
						colContentExclusive = x;
						break;
					case "colcontentinclusive":
						colContentInclusive = x;
						break;
					case "colcontenttotalexclusive":
						colContentTotalExclusive = x;
						break;
					case "colprice":
						colPrice = x;
						break;
					case "colcontenttotalinclusive":
						colContentTotalInclusive = x;
						break;
					case "coldepositexclusive":
						colDepositExclusive = x;
						break;
					case "coldepositinclusive":
						colDepositInclusive = x;
						break;
					case "coldeposittotalexclusive":
						colDepositTotalExclusive = x;
						break;
					case "coldeposittotalinclusive":
						colDepositTotalInclusive = x;
						break;
					case "coldiscountline":
						colDiscountLine = x;
						break;
					case "coldiscount":
						colDiscount = x;
						break;
					case "coldiscountpercentage":
						colDiscountPercentage = x;
						break;
					case "coltotalexclusive":
						colTotalExclusive = x;
						break;
					case "coltotalinclusive":
						colTotalInclusive = x;
						break;
					case "colexclusive":
						colExclusive = x;
						break;
					case "colinclusive":
						colInclusive = x;
						break;
					case "colvat":
						colVAT = x;
						break;
					case "colprice":
						colPrice = x;
						break;
				}
				rs.moveNext();
			}
			colFractions = 23;
			setup();

			rs.MoveFirst();
			while (!(rs.EOF)) {
				if (rs.Fields("visible").Value) {
				} else {
					switch (Strings.LCase(rs.Fields("GRVTemplateList_Code").Value)) {

						case "colcode":
							gridItem.set_ColWidth(ref colCode, ref 0);
							break;
						case "colonorder":
							gridItem.set_ColWidth(ref colOnOrder, ref 0);
							break;
						case "colquantity":
							gridItem.set_ColWidth(ref colQuantity, ref 0);
							break;
						case "colbrokenpack":
							gridItem.set_ColWidth(ref colBrokenPack, ref 0);
							break;
						case "colpacksize":
							gridItem.set_ColWidth(ref colPackSize, ref 0);
							break;
						case "colcontentexclusive":
							gridItem.set_ColWidth(ref colContentExclusive, ref 0);
							break;
						case "colcontentinclusive":
							gridItem.set_ColWidth(ref colContentInclusive, ref 0);
							break;
						case "colcontenttotalexclusive":
							gridItem.set_ColWidth(ref colContentTotalExclusive, ref 0);
							break;
						case "colcontenttotalinclusive":
							gridItem.set_ColWidth(ref colContentTotalInclusive, ref 0);
							break;
						case "coldepositexclusive":
							gridItem.set_ColWidth(ref colDepositExclusive, ref 0);
							break;
						case "coldepositinclusive":
							gridItem.set_ColWidth(ref colDepositInclusive, ref 0);
							break;
						//Case "coldeposittotalexclusive": gridItem.ColWidth(colDepositTotalExclusive) = 0
						//Case "coldeposittotalinclusive": gridItem.ColWidth(colDepositTotalInclusive) = 0
						case "coldiscountline":
							gridItem.set_ColWidth(ref colDiscountLine, ref 0);
							break;
						case "coldiscount":
							gridItem.set_ColWidth(ref colDiscount, ref 0);
							break;
						case "coldiscountpercentage":
							gridItem.set_ColWidth(ref colDiscountPercentage, ref 0);
							break;
						case "coltotalexclusive":
							gridItem.set_ColWidth(ref colTotalExclusive, ref 0);
							break;
						case "coltotalinclusive":
							gridItem.set_ColWidth(ref colTotalInclusive, ref 0);
							break;
						case "colexclusive":
							gridItem.set_ColWidth(ref colExclusive, ref 0);
							break;
						case "colinclusive":
							gridItem.set_ColWidth(ref colInclusive, ref 0);
							break;
						case "colvat":
							gridItem.set_ColWidth(ref colVAT, ref 0);
							break;
						case "colprice":
							gridItem.set_ColWidth(ref colPrice, ref 0);
							break;
					}
				}
				rs.moveNext();
			}
			lblContentExclusive.Visible = Convert.ToBoolean(gridItem.get_ColWidth(ref colContentTotalExclusive));
			lblContentInclusive.Visible = Convert.ToBoolean(gridItem.get_ColWidth(ref colContentTotalInclusive));
			lblDepositExclusive.Visible = Convert.ToBoolean(gridItem.get_ColWidth(ref colDepositTotalExclusive));
			lblDepositInclusive.Visible = Convert.ToBoolean(gridItem.get_ColWidth(ref colDepositTotalInclusive));
			lblTotalExclusive.Visible = Convert.ToBoolean(gridItem.get_ColWidth(ref colTotalExclusive));
			lblTotalInclusive.Visible = Convert.ToBoolean(gridItem.get_ColWidth(ref colTotalInclusive));
			lblTotalInclusive.Visible = Convert.ToBoolean(gridItem.get_ColWidth(ref colPrice));
			_lblTotal_0.Visible = lblContentExclusive.Visible;
			_lblTotal_1.Visible = lblContentInclusive.Visible;
			_lblTotal_2.Visible = lblDepositExclusive.Visible;
			_lblTotal_3.Visible = lblDepositInclusive.Visible;
			_lblTotal_4.Visible = lblTotalExclusive.Visible;
			_lblTotal_5.Visible = lblTotalInclusive.Visible;

			//Check for person security to not show Order QTY
			if (8192 & My.MyProject.Forms.frmMenu.gBit) {
			} else {
				gridItem.set_ColWidth(ref colOnOrder, ref 0);
			}
			//Check for person security to not show Order QTY

			frmGRVitemFnV_Resize(this, new System.EventArgs());
		}

		private void quickEdit()
		{

			short id = 0;
			short x = 0;
			My.MyProject.Forms.frmGRVItemQuick.ShowDialog();
			if (gridItem.get_TextMatrix(ref gridItem.row, ref colCode) == "RELOAD") {
				id = gridItem.get_RowData(ref gridItem.row);
				getOrder();
				x = findItem(ref id);
				if (x) {
					gridItem.row = x;
					gridItem.Col = colQuantity;
					_txtEdit_0.Visible = true;
					gridItem_EnterCell(gridItem, new System.EventArgs());
				}
				txtSearch.Focus();
			}
		}

		public void loadItem(ref bool returns)
		{
			TextBox oText = new TextBox();

			//ResizeForm frmGRVitem, frmGRVitem.Width, frmGRVitem.Height, 2

			if (returns) {
				orderType = 1;
			} else {
				orderType = 0;
			}

			loading = true;
			setupGRV();

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
				}
			}
			loading = false;

			cmdSort.Left = 0;
			cmdStockItem.Left = 0;
			if (modApplication.bolAirTimeGRV == true) {
				tmrAutoGRV.Enabled = true;
			}

			rsPackSize = modRecordSet.getRS(ref "SELECT Company_FNVegShowVol FROM Company;");
			bFNVegPackSize = rsPackSize.Fields("Company_FNVegShowVol").Value;

			//update TotalQtyKG
			modRecordSet.cnnDB.Execute("UPDATE (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN PackSize ON StockItem.StockItem_PackSizeID = PackSize.PackSizeID SET GRVItem_PackSizeVol=IIf(GRVItem_PackSizeVol=0,PackSize.PackSize_Volume,GRVItem_PackSizeVol) WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + "));");

			loadLanguage();
			if (this.Visible) {
			} else {
				this.ShowDialog();
			}

		}
		private void cmdVAT_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short id = 0;
			short x = 0;
			string sql = null;
			string lString = null;
			if (gridItem.row) {
				lString = Interaction.InputBox("Enter the VAT percentage for item '" + gridItem.get_TextMatrix(ref gridItem.row, ref colName) + "'.", "Enter VAT", Strings.FormatNumber(Convert.ToDouble(gridItem.get_TextMatrix(ref gridItem.row, ref colVAT)) * 100, 0, TriState.False, TriState.False, TriState.False));
				if (Information.IsNumeric(lString)) {
					if (Strings.InStr(lString, ".")) {
					} else {
						lString = Convert.ToString(Convert.ToDouble(lString) / 100);
					}
					id = gridItem.get_RowData(ref gridItem.row);
					modRecordSet.cnnDB.Execute("UPDATE GRVItem SET GRVItem.GRVItem_VatRate = " + lString + " WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_StockItemID)=" + gridItem.get_RowData(ref gridItem.row) + ") AND ((GRVItem.GRVItem_Return)=" + orderType + "));");

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

		}

		private void frmGRVitemFnV_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			string lString = null;
			if (Shift == 7 & KeyCode == 80) {
				lString = Interaction.InputBox("GRV Template Name", "TEMPLATE");
				if (!string.IsNullOrEmpty(lString)) {
					setup();
					setupGRV(ref lString);
					getOrder();
				}
			}
		}

		private void frmGRVitemFnV_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 27) {
				KeyAscii = 0;
				cmdBack_Click(cmdBack, new System.EventArgs());
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmGRVitemFnV_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtEdit.AddRange(new TextBox[] {
				_txtEdit_0,
				_txtEdit_1,
				_txtEdit_2
			});
			TextBox tb = new TextBox();
			foreach (TextBox tb_loopVariable in txtEdit) {
				tb = tb_loopVariable;
				tb.Enter += txtEdit_Enter;
				tb.KeyPress += txtEdit_KeyPress;
				tb.Leave += txtEdit_Leave;
				tb.TextChanged += txtEdit_TextChanged;
			}
			//*frmstocklist must not be displayed when you access frmstockitem from  frmGRVitem and exit stockitem,so that's what the code does
			modApplication.Holdquantity = 0;
			My.MyProject.Forms.frmGRVitem.lblQuantity.Tag = 0;

			//BO Security permission check
			if (1 & My.MyProject.Forms.frmMenu.gBit) {
			} else {
				cmdEdit.Enabled = false;
			}
			if (1 & My.MyProject.Forms.frmMenu.gBit) {
			} else {
				cmdNew.Enabled = false;
			}
			//*
		}

//UPGRADE_WARNING: Event frmGRVitemFnV.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void frmGRVitemFnV_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			short x = 0;
			short lWidth = 0;
			int lTop = 0;
			lTop = 120;
			if (lblContentExclusive.Visible) {
				lblContentExclusive.Top = sizeConvertors.twipsToPixels(lTop, false);
				_lblTotal_0.Top = sizeConvertors.twipsToPixels(lTop, false);
				lTop = lTop + sizeConvertors.pixelToTwips(lblContentExclusive.Height, false) + 30;
			}
			if (lblContentInclusive.Visible) {
				lblContentInclusive.Top = sizeConvertors.twipsToPixels(lTop, false);
				_lblTotal_1.Top = sizeConvertors.twipsToPixels(lTop, false);
				lTop = lTop + sizeConvertors.pixelToTwips(lblContentInclusive.Height, false) + 30;
			}
			if (lblDepositExclusive.Visible) {
				lblDepositExclusive.Top = sizeConvertors.twipsToPixels(lTop, false);
				_lblTotal_2.Top = sizeConvertors.twipsToPixels(lTop, false);
				lTop = lTop + sizeConvertors.pixelToTwips(lblDepositExclusive.Height, false) + 30;
			}
			if (lblDepositInclusive.Visible) {
				lblDepositInclusive.Top = sizeConvertors.twipsToPixels(lTop, false);
				_lblTotal_3.Top = sizeConvertors.twipsToPixels(lTop, false);
				lTop = lTop + sizeConvertors.pixelToTwips(lblDepositInclusive.Height, false) + 30;
			}
			if (lblTotalExclusive.Visible) {
				lblTotalExclusive.Top = sizeConvertors.twipsToPixels(lTop, false);
				_lblTotal_4.Top = sizeConvertors.twipsToPixels(lTop, false);
				lTop = lTop + sizeConvertors.pixelToTwips(lblTotalExclusive.Height, false) + 30;
			}
			if (lblTotalInclusive.Visible) {
				lblTotalInclusive.Top = sizeConvertors.twipsToPixels(lTop, false);
				_lblTotal_5.Top = sizeConvertors.twipsToPixels(lTop, false);
				lTop = lTop + sizeConvertors.pixelToTwips(lblTotalInclusive.Height, false) + 30;
			}
			frmTotals.Height = sizeConvertors.twipsToPixels(lTop + 30, false);

			frmTotals.Top = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(ClientRectangle.Height, false) - sizeConvertors.pixelToTwips(frmTotals.Height, false), false);
			frmTotals.Left = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(ClientRectangle.Width, true) - sizeConvertors.pixelToTwips(frmTotals.Width, true), true);
			lblReturns.Top = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(frmTotals.Top, false) + (sizeConvertors.pixelToTwips(frmTotals.Height, false) - sizeConvertors.pixelToTwips(lblReturns.Height, false)) / 2, false);
			lblReturns.Left = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(frmTotals.Left, true) - sizeConvertors.pixelToTwips(lblReturns.Width, true) - 100, true);
			lblReturns.Visible = orderType;

			frmFNVeg.Top = frmTotals.Top;
			frmFNVeg.Left = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(frmTotals.Left, true) - sizeConvertors.pixelToTwips(frmFNVeg.Width, true) - 200, true);
			if (bFNVegPackSize & orderType == 0)
				frmFNVeg.Visible = true;
			else
				frmFNVeg.Visible = false;

			lstWorkspace.Height = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(ClientRectangle.Height, false) - sizeConvertors.pixelToTwips(lstWorkspace.Top, false), false);
			gridItem.Height = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(ClientRectangle.Height, false) - sizeConvertors.pixelToTwips(gridItem.Top, false) - sizeConvertors.pixelToTwips(frmTotals.Height, false), false);
			gridItem.Width = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(ClientRectangle.Width, true) - sizeConvertors.pixelToTwips(gridItem.Left, true), true);
			lWidth = sizeConvertors.pixelToTwips(gridItem.Width, true) - 450;
			for (x = 0; x <= gridItem.Col - 1; x++) {
				lWidth = lWidth - gridItem.get_ColWidth(ref x);
			}
			lWidth = lWidth + gridItem.get_ColWidth(ref colName);
			if (lWidth > 200) {
				gridItem.set_ColWidth(ref colName, ref lWidth);
			} else {
				gridItem.set_ColWidth(ref colName, ref 2000);
			}
			gridItem_EnterCell(gridItem, new System.EventArgs());
		}

		private void frmGRVitemFnV_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			//*frmstocklist must not be displayed when you access frmstockitem from  frmGRVitem and exit stockitem,so that's what the code does
			My.MyProject.Forms.frmGRVitem.lblQuantity.Tag = -1;
			modApplication.Holdquantity = Convert.ToInt32(My.MyProject.Forms.frmGRVitem.lblQuantity.Tag);
			My.MyProject.Forms.frmGRVitem.lblQuantity.Tag = 0;
			//*
		}

		private void gridItem_ClickEvent(System.Object eventSender, System.EventArgs eventArgs)
		{
			gridItem.set_ColWidth(ref 23, ref 1);
		}

		private void lstWorkspace_DoubleClick(System.Object eventSender, KeyPressEventArgs eventArgs)
		{
			string sql = null;
			ADODB.Recordset rsCQty = default(ADODB.Recordset);
			string rsSql = null;
			decimal lDeposit = default(decimal);
			short x = 0;

			if (lstWorkspace.SelectedIndex != -1) {

				update_Renamed();
				//UPGRADE_WARNING: Couldn't resolve default property of object findItem(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				x = findItem(ref Convert.ToInt16(lstWorkspace.SelectedIndex));

				if (x) {
					gridItem.row = x;
				} else {
					//            cnnDB.Execute "INSERT INTO GRVItem ( GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date ) SELECT " & frmGRV.adoPrimaryRS("GRVID") & " AS grvid, StockItem.StockItemID, " & orderType & " AS return, StockItem.StockItem_Name, '' AS code, StockItem.StockItem_OrderQuantity, 0, 0 AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date] FROM StockItem WHERE (((StockItem.StockItemID)=" & lstWorkspace.ItemData(lstWorkspace.ListIndex) & "));"
					//            cnnDB.Execute "UPDATE (((GRVItem INNER JOIN GRV ON GRVItem.GRVItem_GRVID = GRV.GRVID) INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN PurchaseOrder ON GRV.GRV_PurchaseOrderID = PurchaseOrder.PurchaseOrderID) INNER JOIN BrandItemSupplier ON (BrandItemSupplier.BrandItemSupplier_SupplierID = PurchaseOrder.PurchaseOrder_SupplierID) AND (StockItem.StockItem_BrandItemID = BrandItemSupplier.BrandItemSupplier_BrandItemID) SET GRVItem.GRVItem_Name = [BrandItemSupplier]![BrandItemSupplier_Name], GRVItem.GRVItem_Code = [BrandItemSupplier]![BrandItemSupplier_Code] WHERE (((GRVItem.GRVItem_StockItemID)=" & lstWorkspace.ItemData(lstWorkspace.ListIndex) & ") AND ((GRVItem.GRVItem_Return)=" & orderType & ") AND ((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & "));"
					 // ERROR: Not supported in C#: OnErrorStatement


					sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_Price ) SELECT " + this.gridItem.RowCount + ", " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + " AS grvid, StockItem.StockItemID, " + orderType + " AS return, StockItem.StockItem_Name, '' AS code, StockItem.StockItem_Quantity, StockItem.StockItem_OrderQuantity, 0 AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))";
					sql = sql + " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + Convert.ToInt64(lstWorkspace.SelectedIndex) + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));";

					modRecordSet.cnnDB.Execute(sql);

					sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_Price ) ";
					sql = sql + "SELECT " + this.gridItem.RowCount + ", " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + " AS grvid, StockItem.StockItemID, " + orderType + " AS return, StockItem.StockItem_Name, '' AS code, StockItem.StockItem_Quantity, StockItem.StockItem_OrderQuantity, 0 AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 FROM StockItem WHERE (((StockItem.StockItemID)=" + Convert.ToInt64(lstWorkspace.SelectedIndex) + "));";

					modRecordSet.cnnDB.Execute(sql);

					sql = "UPDATE ((Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_Quantity = StockItem.StockItem_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)) INNER JOIN GRVItem ON (GRVItem.GRVItem_StockItemID = StockItem.StockItemID) AND (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize) SET GRVItem.GRVItem_StockItemQuantity = [CatalogueChannelLnk_Quantity], GRVItem.GRVItem_Price = [CatalogueChannelLnk_Price] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((StockItem.StockItemID)=" + Convert.ToInt64(lstWorkspace.SelectedIndex) + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((GRVItem.GRVItem_Return)=" + orderType + ") AND ((StockItem.StockItem_PackSizeID)=[StockItem_Quantity]));";
					modRecordSet.cnnDB.Execute(sql);

					sql = "UPDATE (StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID SET GRVItem.GRVItem_VatRate = [Vat_Amount] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=" + orderType + ") AND ((GRVItem.GRVItem_StockItemID)=" + Convert.ToInt64(lstWorkspace.SelectedIndex) + "));";

					modRecordSet.cnnDB.Execute(sql);

					//update selling price
					sql = "UPDATE GRVItem INNER JOIN PriceChannelLnk ON PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID SET GRVItem.GRVItem_Price = PriceChannelLnk.PriceChannelLnk_Price WHERE ((PriceChannelLnk.PriceChannelLnk_Quantity=1) AND (PriceChannelLnk.PriceChannelLnk_ChannelID=1) AND (GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + " AND GRVItem.GRVItem_Line =" + this.gridItem.RowCount + ");";
					modRecordSet.cnnDB.Execute(sql);

					//update TotalQtyKG
					modRecordSet.cnnDB.Execute("UPDATE (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN PackSize ON StockItem.StockItem_PackSizeID = PackSize.PackSizeID SET GRVItem_PackSizeVol=IIf(GRVItem_PackSizeVol=0,PackSize.PackSize_Volume,GRVItem_PackSizeVol) WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + "));");

					getOrder();
					System.Windows.Forms.Application.DoEvents();
					//UPGRADE_WARNING: Couldn't resolve default property of object findItem(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					x = findItem(ref Convert.ToInt64(lstWorkspace.SelectedIndex));
					if (x) {
						gridItem.row = x;
						gridItem.Col = colQuantity;
						_txtEdit_0.Visible = true;
						gridItem_EnterCell(gridItem, new System.EventArgs());
						System.Windows.Forms.Application.DoEvents();
						if (gQuickKey)
							quickEdit();
					}
				}
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
				} else {
					functionReturnValue = 0;
				}

			}

			return x;
			return functionReturnValue;
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

//UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private void update_Renamed()
		{
			if (loading)
				return;
			//    Dim lNode As IXMLDOMNode
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
			ADODB.Recordset rsStockItem_PriceSetID = default(ADODB.Recordset);
			ADODB.Recordset rs = default(ADODB.Recordset);
			if (lUpdate) {
				switch (gridItem.Col) {
					case colQuantity:
						System.Windows.Forms.Application.DoEvents();
						modRecordSet.cnnDB.Execute("UPDATE GRVItem SET GRVItem_Quantity = " + _txtEdit_0.Text + " Where (GRVItem_GRVID = " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") And (GRVItem_StockItemID = " + gridItem.get_RowData(ref gridItem.row) + ") And (GRVItem_Return = " + orderType + ")");
						gridItem.set_TextMatrix(ref gridItem.row, ref colQuantity, ref _txtEdit_0.Text);
						_txtEdit_0.Tag = _txtEdit_0.Text;
						break;
					case colContentExclusive:
						//If oText.Text <> oText.Tag Then
						//check if stockitem is part of priceset
						rsStockItem_PriceSetID = modRecordSet.getRS(ref "SELECT * FROM StockItem WHERE StockItemID = " + gridItem.get_RowData(ref gridItem.row));
						//rsStockItem("StockItem_PriceSetID")
						if (rsStockItem_PriceSetID.Fields("StockItem_PriceSetID").Value > 0) {

							//check if stockitem is child or parent
							rs = modRecordSet.getRS(ref "SELECT * FROM PriceSet WHERE PriceSetID = " + rsStockItem_PriceSetID.Fields("StockItem_PriceSetID").Value);
							if (rsStockItem_PriceSetID.Fields("StockItemID").Value == rs.Fields("PriceSet_StockItemID").Value) {
								//parent
								Interaction.MsgBox("This is Primary Stock Item of Pricing Set, changing of price will effect on all Child Stock Item those are part of this set.", MsgBoxStyle.Exclamation);
								System.Windows.Forms.Application.DoEvents();
								//cnnDB.Execute "UPDATE GRVItem SET GRVItem_ContentCost = " & (CCur(_txtEdit_1.Text) / 100) & " Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS("GRVID") & ") And (GRVItem_StockItemID = " & gridItem.RowData(gridItem.row) & ") And (GRVItem_Return = " & orderType & ")"
								if (gridItem.get_TextMatrix(ref gridItem.row, ref colBrokenPack) == "X") {
									modRecordSet.cnnDB.Execute("UPDATE GRVItem SET GRVItem_ContentCost = " + (Convert.ToDecimal(Convert.ToDouble(_txtEdit_1.Text) * rsStockItem_PriceSetID.Fields("StockItem_Quantity").Value) / 100) + " Where (GRVItem_GRVID = " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") And (GRVItem_StockItemID = " + gridItem.get_RowData(ref gridItem.row) + ") And (GRVItem_Return = " + orderType + ")");
								} else {
									modRecordSet.cnnDB.Execute("UPDATE GRVItem SET GRVItem_ContentCost = " + (Convert.ToDecimal(_txtEdit_1.Text) / 100) + " Where (GRVItem_GRVID = " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") And (GRVItem_StockItemID = " + gridItem.get_RowData(ref gridItem.row) + ") And (GRVItem_Return = " + orderType + ")");
								}
								gridItem.set_TextMatrix(ref gridItem.row, ref colContentExclusive, ref Strings.FormatNumber(Convert.ToDecimal(_txtEdit_1.Text) / 100, 2));
								_txtEdit_1.Tag = _txtEdit_1.Text;
							} else {
								//child
								//ParentPriceID = rs("PriceSet_StockItemID")
								//If cmdUndoFocus = False Then
								if (Interaction.MsgBox("This is Child Stock Item of Pricing Set, changing of price of this Item will effect on Primary Stock Item and all Child Stock Item those are part of this set. " + Constants.vbCrLf + "Do you want to change ?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes) {
									//ChildPriceChang = False
									//ParentPriceChang = True
									System.Windows.Forms.Application.DoEvents();
									//cnnDB.Execute "UPDATE GRVItem SET GRVItem_ContentCost = " & (CCur(_txtEdit_1.Text) / 100) & " Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS("GRVID") & ") And (GRVItem_StockItemID = " & gridItem.RowData(gridItem.row) & ") And (GRVItem_Return = " & orderType & ")"
									if (gridItem.get_TextMatrix(ref gridItem.row, ref colBrokenPack) == "X") {
										modRecordSet.cnnDB.Execute("UPDATE GRVItem SET GRVItem_ContentCost = " + (Convert.ToDecimal(Convert.ToDouble(_txtEdit_1.Text) * rsStockItem_PriceSetID.Fields("StockItem_Quantity").Value) / 100) + " Where (GRVItem_GRVID = " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") And (GRVItem_StockItemID = " + gridItem.get_RowData(ref gridItem.row) + ") And (GRVItem_Return = " + orderType + ")");
									} else {
										modRecordSet.cnnDB.Execute("UPDATE GRVItem SET GRVItem_ContentCost = " + (Convert.ToDecimal(_txtEdit_1.Text) / 100) + " Where (GRVItem_GRVID = " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") And (GRVItem_StockItemID = " + gridItem.get_RowData(ref gridItem.row) + ") And (GRVItem_Return = " + orderType + ")");
									}
									gridItem.set_TextMatrix(ref gridItem.row, ref colContentExclusive, ref Strings.FormatNumber(Convert.ToDecimal(_txtEdit_1.Text) / 100, 2));
									_txtEdit_1.Tag = _txtEdit_1.Text;

									modRecordSet.cnnDB.Execute("UPDATE StockItem SET StockItem_ListCost = " + (Convert.ToDecimal(_txtEdit_1.Text) / 100) + " Where (StockItemID = " + rs.Fields("PriceSet_StockItemID").Value + ")");
								} else {
									//ChildPriceChang = True
									gridItem.set_TextMatrix(ref gridItem.row, ref colContentExclusive, ref Strings.FormatNumber(Convert.ToDecimal(Convert.ToDouble(_txtEdit_1.Tag) * 100), 2));
									_txtEdit_1.Text = Strings.FormatNumber(Convert.ToDecimal(Convert.ToDouble(_txtEdit_1.Tag) * 100), 2);
									//_txtEdit_1.Tag
								}
								//End If
							}
							rs.Close();
							rsStockItem_PriceSetID.Close();
						} else {
							System.Windows.Forms.Application.DoEvents();
							if (gridItem.get_TextMatrix(ref gridItem.row, ref colBrokenPack) == "X") {
								modRecordSet.cnnDB.Execute("UPDATE GRVItem SET GRVItem_ContentCost = " + (Convert.ToDecimal(Convert.ToDouble(_txtEdit_1.Text) * rsStockItem_PriceSetID.Fields("StockItem_Quantity").Value) / 100) + " Where (GRVItem_GRVID = " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") And (GRVItem_StockItemID = " + gridItem.get_RowData(ref gridItem.row) + ") And (GRVItem_Return = " + orderType + ")");
							} else {
								modRecordSet.cnnDB.Execute("UPDATE GRVItem SET GRVItem_ContentCost = " + (Convert.ToDecimal(_txtEdit_1.Text) / 100) + " Where (GRVItem_GRVID = " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") And (GRVItem_StockItemID = " + gridItem.get_RowData(ref gridItem.row) + ") And (GRVItem_Return = " + orderType + ")");
							}

							gridItem.set_TextMatrix(ref gridItem.row, ref colContentExclusive, ref Strings.FormatNumber(Convert.ToDecimal(_txtEdit_1.Text) / 100, 2));
							_txtEdit_1.Tag = _txtEdit_1.Text;
							rsStockItem_PriceSetID.Close();
						}
						break;
					//End If

					case colPrice:
						System.Windows.Forms.Application.DoEvents();
						modRecordSet.cnnDB.Execute("UPDATE GRVItem SET GRVItem_Price = " + (Convert.ToDecimal(_txtEdit_2.Text) / 100) + " Where (GRVItem_GRVID = " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") And (GRVItem_StockItemID = " + gridItem.get_RowData(ref gridItem.row) + ") And (GRVItem_Return = " + orderType + ")");
						gridItem.set_TextMatrix(ref gridItem.row, ref colPrice, ref Strings.FormatNumber(Convert.ToDecimal(_txtEdit_2.Text) / 100, 2));
						_txtEdit_2.Tag = _txtEdit_2.Text;
						break;
				}
			}
		}


		private void cmdPack_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int id = 0;
			short x = 0;

			id = gridItem.get_RowData(ref gridItem.row);
			string sql = null;
			if (gridItem.row) {
				if (Convert.ToDouble(this.gridItem.get_TextMatrix(ref gridItem.row, ref colPackSize)) == 1) {
					modRecordSet.cnnDB.Execute("UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_PackSize = [StockItem]![StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_StockItemID)=" + gridItem.get_RowData(ref gridItem.row) + ") AND ((GRVItem.GRVItem_Return)=" + orderType + "));");
				} else {
					modRecordSet.cnnDB.Execute("UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_PackSize = 1 WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_StockItemID)=" + gridItem.get_RowData(ref gridItem.row) + ") AND ((GRVItem.GRVItem_Return)=" + orderType + "));");
				}
				getOrder();
				//UPGRADE_WARNING: Couldn't resolve default property of object findItem(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				x = findItem(ref id);
				if (x) {
					gridItem.row = x;
					gridItem.Col = colQuantity;
					_txtEdit_0.Visible = true;
					gridItem_EnterCell(gridItem, new System.EventArgs());
				}
			}
		}

		private void cmdDelete_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			System.Windows.Forms.TextBox oText = null;
			if (gridItem.row) {
				if (Interaction.MsgBox("Are you sure you wish to delete the order item '" + gridItem.get_TextMatrix(ref gridItem.row, ref colName) + "' from this order?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Delete Line Item") == MsgBoxResult.Yes) {
					modRecordSet.cnnDB.Execute("DELETE FROM GRVItem Where (GRVItem_GRVID = " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") And (GRVItem_StockItemID = " + gridItem.get_RowData(ref gridItem.row) + ") And (GRVItem_Return = " + orderType + ")");
					getOrder();
					if (gridItem.RowCount > 1) {
						gridItem.row = 1;
						gridItem_EnterCell(gridItem, new System.EventArgs());
					} else {
						foreach (TextBox oText_loopVariable in txtEdit) {
							oText = oText_loopVariable;
							oText.Visible = false;
						}
					}
				}
			}
		}


		private void cmdDiscount_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int id = 0;
			short x = 0;
			string lString = null;
			string sql = null;
			if (gridItem.row) {
				id = gridItem.get_RowData(ref gridItem.row);
				if (gridItem.get_ColWidth(ref colDiscount)) {
					lString = Interaction.InputBox("Enter the Item Discount for item '" + gridItem.get_TextMatrix(ref gridItem.row, ref colName) + "'.", "Enter Discount", Strings.FormatNumber(Convert.ToDouble(gridItem.get_TextMatrix(ref gridItem.row, ref colDiscount)) * 100, 0, TriState.False, TriState.False, TriState.False));
					if (Information.IsNumeric(lString)) {
						if (Strings.InStr(lString, ".")) {
						} else {
							lString = lString / 100;
						}
						doDiscount(ref (Convert.ToDecimal(lString)));
					}
				} else if (gridItem.get_ColWidth(ref colDiscountLine)) {
					lString = Interaction.InputBox("Enter the Line Discount for item '" + gridItem.get_TextMatrix(ref gridItem.row, ref colName) + "'.", "Enter Discount", Strings.Replace(gridItem.get_TextMatrix(ref gridItem.row, ref colDiscountLine), ",", ""));
					if (Information.IsNumeric(lString)) {
						if (Strings.InStr(lString, ".")) {
						} else {
							lString = lString / 100;
						}
						if (Convert.ToDecimal(gridItem.get_TextMatrix(ref gridItem.row, ref colQuantity))) {
							doDiscount(ref (Convert.ToDecimal(lString) / Convert.ToDecimal(gridItem.get_TextMatrix(ref gridItem.row, ref colQuantity))));
						} else {
							doDiscount(ref (0));
						}
					}
				} else if (gridItem.get_ColWidth(ref colDiscountPercentage)) {
					lString = Interaction.InputBox("Enter the Percentage Discount for item '" + gridItem.get_TextMatrix(ref gridItem.row, ref colName) + "'.", "Enter Discount", Strings.Replace(gridItem.get_TextMatrix(ref gridItem.row, ref colDiscountPercentage), ",", ""));
					if (Information.IsNumeric(lString)) {
						if (Strings.InStr(lString, ".")) {
						} else {
							lString = lString / 100;
						}
						if (Convert.ToDecimal(gridItem.get_TextMatrix(ref gridItem.row, ref colQuantity))) {
							doDiscount(ref Convert.ToDecimal(gridItem.get_TextMatrix(ref gridItem.row, ref colContentExclusive)) * lString / 100);
						} else {
							doDiscount(ref (0));
						}
					}
				} else {
					Interaction.MsgBox("No Discount Given for this Supplier!", MsgBoxStyle.Exclamation, "GRV - " + lblSupplier.Text);
				}
			}
		}


		private void doDiscount(ref decimal lDiscount)
		{
			string lString = null;
			string sql = null;
			decimal lDiscountActual = default(decimal);
			lDiscountActual = lDiscount;
			//   If FormatNumber(lDiscount, 2) <> gridItem.TextMatrix(gridItem.row, colDiscount) Then
			if (activePrice == 1 | activePrice == 3) {
				lDiscountActual = lDiscountActual / (1 + Convert.ToDouble(gridItem.get_TextMatrix(ref gridItem.row, ref colVAT)) / 100);
			}
			sql = "UPDATE GRVItem SET GRVItem_DiscountAmount = " + Convert.ToDecimal(lDiscountActual) + " Where (GRVItem_GRVID = " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") And (GRVItem_StockItemID = " + gridItem.get_RowData(ref gridItem.row) + ") And (GRVItem_return = " + orderType + ")";
			modRecordSet.cnnDB.Execute(sql);
			loading = true;
			gridItem.set_TextMatrix(ref gridItem.row, ref colDiscount, ref Strings.FormatNumber(lDiscount, 4));
			displayLine(ref (gridItem.row));
			gridItem.Col = colDiscount;
			if (Convert.ToDecimal(gridItem.get_TextMatrix(ref gridItem.row, ref colDiscount)) == 0) {
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 200));
			} else {
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(255, 200, 200));
			}
			gridItem.Col = colDiscountLine;
			if (Convert.ToDecimal(gridItem.get_TextMatrix(ref gridItem.row, ref colDiscount)) == 0) {
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 200));
			} else {
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(255, 200, 200));
			}
			gridItem.Col = colDiscountPercentage;
			if (Convert.ToDecimal(gridItem.get_TextMatrix(ref gridItem.row, ref colDiscount)) == 0) {
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 200));
			} else {
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(255, 200, 200));
			}
			gridItem.set_TextMatrix(ref gridItem.row, ref colDiscountLine, ref Strings.FormatNumber(lDiscount * Convert.ToDouble(gridItem.get_TextMatrix(ref gridItem.row, ref colQuantity)), 2));
			gridItem.set_TextMatrix(ref gridItem.row, ref colDiscountPercentage, ref Strings.FormatNumber(Convert.ToDecimal(gridItem.get_TextMatrix(ref gridItem.row, ref colDiscount)) / Convert.ToDecimal(gridItem.get_TextMatrix(ref gridItem.row, ref colContentExclusive)) * 100, 2));
			gridItem.Col = colQuantity;
			loading = false;

			doTotals();
			//    End If
			System.Windows.Forms.TextBox oText = null;
			foreach (TextBox oText_loopVariable in txtEdit) {
				oText = oText_loopVariable;
				if (oText.Visible)
					oText.Focus();
				break; // TODO: might not be correct. Was : Exit For
			}
		}

		private void cmdPrice_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int id = 0;
			string lString = null;
			string sql = null;
			short x = 0;
			System.Windows.Forms.TextBox oText = null;
			if (gridItem.row) {
				id = gridItem.get_RowData(ref gridItem.row);
				switch (activePrice) {
					case 0:
						lString = Interaction.InputBox("Enter the New Price for item '" + gridItem.get_TextMatrix(ref gridItem.row, ref colName) + "'.", "Enter New Price", gridItem.get_TextMatrix(ref gridItem.row, ref colContentExclusive));
						break;
					case 1:
						lString = Interaction.InputBox("Enter the New Price for item '" + gridItem.get_TextMatrix(ref gridItem.row, ref colName) + "'.", "Enter New Price", gridItem.get_TextMatrix(ref gridItem.row, ref colContentInclusive));
						break;
					case 2:
						lString = Interaction.InputBox("Enter the New Price for item '" + gridItem.get_TextMatrix(ref gridItem.row, ref colName) + "'.", "Enter New Price", gridItem.get_TextMatrix(ref gridItem.row, ref colExclusive));
						break;
					case 3:
						lString = Interaction.InputBox("Enter the New Price for item '" + gridItem.get_TextMatrix(ref gridItem.row, ref colName) + "'.", "Enter New Price", gridItem.get_TextMatrix(ref gridItem.row, ref colInclusive));
						break;
				}
				if (Information.IsNumeric(lString)) {
					if (Strings.InStr(lString, ".")) {
					} else {
						lString = lString / 100;
					}
					switch (activePrice) {
						case 0:
							break;
						case 1:
							lString = Convert.ToDecimal(lString) / (1 + Convert.ToDecimal(gridItem.get_TextMatrix(ref gridItem.row, ref colVAT)) / 100);
							break;
						case 2:
							lString = Convert.ToDecimal(lString) - Convert.ToDecimal(gridItem.get_TextMatrix(ref gridItem.row, ref colDepositExclusive));
							break;
						case 3:
							lString = Convert.ToDecimal(lString) / (1 + Convert.ToDecimal(gridItem.get_TextMatrix(ref gridItem.row, ref colVAT)) / 100) - Convert.ToDecimal(gridItem.get_TextMatrix(ref gridItem.row, ref colDepositExclusive));
							break;

					}
					if (Strings.FormatNumber(lString, 2) != gridItem.get_TextMatrix(ref gridItem.row, ref colContentExclusive)) {
						modRecordSet.cnnDB.Execute("UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_ContentCost = [StockItem].[StockItem_Quantity]/[GRVItem].[GRVItem_PackSize]*" + Convert.ToDecimal(lString) + " WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_StockItemID)=" + gridItem.get_RowData(ref gridItem.row) + ") AND ((GRVItem.GRVItem_Return)=" + orderType + "));");

						loading = true;
						gridItem.set_TextMatrix(ref gridItem.row, ref colContentExclusive, ref Strings.FormatNumber(lString, 2));
						displayLine(ref (gridItem.row));
						gridItem.Col = colContentExclusive;
						gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(255, 200, 200));
						gridItem.Col = colContentInclusive;
						gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(255, 200, 200));
						gridItem.Col = colExclusive;
						gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(255, 200, 200));
						gridItem.Col = colInclusive;
						gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(255, 200, 200));
						gridItem.Col = colQuantity;
						loading = false;
						doTotals();
					}

					foreach (TextBox oText_loopVariable in txtEdit) {
						oText = oText_loopVariable;
						if (oText.Visible)
							oText.Focus();
						break; // TODO: might not be correct. Was : Exit For
					}
				} else if (string.IsNullOrEmpty(lString)) {
					modRecordSet.cnnDB.Execute("UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_ContentCost = [StockItem]![StockItem_ListCost] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_StockItemID)=" + gridItem.get_RowData(ref gridItem.row) + ") AND ((GRVItem.GRVItem_Return)=" + orderType + "));");
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
		}


		private void cmdPrintGRV_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			update_Renamed();
			modApplication.report_GRV(ref My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value);
			System.Windows.Forms.TextBox oText = null;
			foreach (TextBox oText_loopVariable in txtEdit) {
				oText = oText_loopVariable;
				if (oText.Visible)
					oText.Focus();
				break; // TODO: might not be correct. Was : Exit For
			}
		}


		private void cmdEdit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int id = 0;
			short x = 0;

			modApplication.bGRVNewItemBarcode = true;

			if (gridItem.get_RowData(ref gridItem.row) != 0) {
				id = gridItem.get_RowData(ref gridItem.row);
				My.MyProject.Forms.frmStockItem.loadItem(ref id);
				My.MyProject.Forms.frmStockItem.Show();
				getOrder();
				x = findItem(ref id);
				if (x) {
					gridItem.row = x;
					gridItem.Col = colQuantity;
					_txtEdit_0.Visible = true;
					gridItem_EnterCell(gridItem, new System.EventArgs());
				}

			}

			modApplication.bGRVNewItemBarcode = false;
		}

		private void Picture2_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdExit.Left = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(Picture2.ClientRectangle.Width, true) - sizeConvertors.pixelToTwips(cmdExit.Width, true) - 30, true);
			cmdNext.Left = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(cmdExit.Left, true) - sizeConvertors.pixelToTwips(cmdNext.Width, true) - 150, true);
			cmdBack.Left = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(cmdNext.Left, true) - sizeConvertors.pixelToTwips(cmdBack.Width, true) - 45, true);
		}

		private void tmrAutoGRV_Tick(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (modApplication.bolAirTimeGRV == true) {
				tmrAutoGRV.Enabled = false;
				cmdNext.Focus();
				cmdNext_Click(cmdNext, new System.EventArgs());
			}
		}

//UPGRADE_WARNING: Event txtEdit.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void txtEdit_TextChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim Index As Short = txtEdit.GetIndex(eventSender)
			int Index = 0;
			TextBox n = new TextBox();
			n = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref n, ref txtEdit);
			if (loading)
				return;
			string lString = null;
			int lValue = 0;
			var _with5 = gridItem;
			lString = txtEdit[Index].Text;
			if (lString == ".")
				lValue = Convert.ToInt32("0.");
			if (_with5.row) {
				if (string.IsNullOrEmpty(lString))
					lString = "0";
				if (Information.IsNumeric(lString)) {
					switch (Index) {
						case 0:
							if (Convert.ToBoolean(_with5.get_TextMatrix(_with5.row, colFractions))) {
								_with5.set_TextMatrix(_with5.row, colQuantity, Strings.FormatNumber(lString, 4));
							} else {
								_with5.set_TextMatrix(_with5.row, colQuantity, Strings.FormatNumber(lString, 0));
							}
							break;
						case 1:
							_with5.set_TextMatrix(_with5.row, colContentExclusive, Strings.FormatNumber(Convert.ToDecimal(lString) / 100, 2));
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

		private void txtEdit_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim Index As Short = txtEdit.GetIndex(eventSender)
			update_Renamed();
		}

		private void doSearchBC()
		{
			ADODB.Recordset rj = default(ADODB.Recordset);
			//Dim sql As String
			string lString = null;

			 // ERROR: Not supported in C#: OnErrorStatement


			lString = Strings.Trim(txtBCode.Text);
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");

			int lID = 0;
			string sql = null;
			ADODB.Recordset rsCQty = default(ADODB.Recordset);
			string rsSql = null;
			decimal lDeposit = default(decimal);
			int x = 0;
			if (string.IsNullOrEmpty(Strings.Trim(lString))) {

			} else {

				txtBCode.SelectionStart = 0;
				txtBCode.SelectionLength = 999;

				rj = modRecordSet.getRS(ref "SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Barcode, StockItem.StockItemID, StockItem.StockItem_Name FROM Catalogue INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID WHERE (((Catalogue.Catalogue_Barcode)='" + lString + "') AND ((Catalogue.Catalogue_Disabled)=False));");
				if (rj.RecordCount > 0) {
					txtSearch.Text = rj.Fields("StockItem_Name").Value;

					lID = rj.Fields("Catalogue_StockItemID").Value;
					//DataList1.BoundText

					//If lstWorkspace.ListIndex <> -1 Then


					update_Renamed();
					x = findItem(ref rj.Fields("Catalogue_StockItemID").Value);
					//findItem(lstWorkspace.ItemData(lstWorkspace.ListIndex))

					if (x) {
						gridItem.row = x;
					} else {

						 // ERROR: Not supported in C#: OnErrorStatement


						sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_Price ) SELECT " + this.gridItem.RowCount + ", " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + " AS grvid, StockItem.StockItemID, " + orderType + " AS return, StockItem.StockItem_Name, '' AS code, StockItem.StockItem_Quantity, StockItem.StockItem_OrderQuantity, 0 AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))";
						sql = sql + " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + rj.Fields("Catalogue_StockItemID").Value + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));";

						modRecordSet.cnnDB.Execute(sql);

						sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_Price ) ";
						sql = sql + "SELECT " + this.gridItem.RowCount + ", " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + " AS grvid, StockItem.StockItemID, " + orderType + " AS return, StockItem.StockItem_Name, '' AS code, StockItem.StockItem_Quantity, StockItem.StockItem_OrderQuantity, 0 AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 FROM StockItem WHERE (((StockItem.StockItemID)=" + rj.Fields("Catalogue_StockItemID").Value + "));";

						modRecordSet.cnnDB.Execute(sql);

						sql = "UPDATE ((Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_Quantity = StockItem.StockItem_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)) INNER JOIN GRVItem ON (GRVItem.GRVItem_StockItemID = StockItem.StockItemID) AND (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize) SET GRVItem.GRVItem_StockItemQuantity = [CatalogueChannelLnk_Quantity], GRVItem.GRVItem_Price = [CatalogueChannelLnk_Price] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((StockItem.StockItemID)=" + rj.Fields("Catalogue_StockItemID").Value + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((GRVItem.GRVItem_Return)=" + orderType + ") AND ((StockItem.StockItem_PackSizeID)=[StockItem_Quantity]));";
						modRecordSet.cnnDB.Execute(sql);

						sql = "UPDATE (StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID SET GRVItem.GRVItem_VatRate = [Vat_Amount] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=" + orderType + ") AND ((GRVItem.GRVItem_StockItemID)=" + rj.Fields("Catalogue_StockItemID").Value + "));";

						modRecordSet.cnnDB.Execute(sql);

						//update selling price
						sql = "UPDATE GRVItem INNER JOIN PriceChannelLnk ON PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID SET GRVItem.GRVItem_Price = PriceChannelLnk.PriceChannelLnk_Price WHERE ((PriceChannelLnk.PriceChannelLnk_Quantity=1) AND (PriceChannelLnk.PriceChannelLnk_ChannelID=1) AND (GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + " AND GRVItem.GRVItem_Line =" + this.gridItem.RowCount + ");";
						modRecordSet.cnnDB.Execute(sql);

						getOrder();
						System.Windows.Forms.Application.DoEvents();
						//UPGRADE_WARNING: Couldn't resolve default property of object findItem(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						x = findItem(ref rj.Fields("Catalogue_StockItemID").Value);
						if (x) {
							gridItem.row = x;
							gridItem.Col = colQuantity;
							_txtEdit_0.Visible = true;
							gridItem_EnterCell(gridItem, new System.EventArgs());
							System.Windows.Forms.Application.DoEvents();
							if (gQuickKey)
								quickEdit();
						}
					}
					//End If


				}
			}

		}

		private void txtBCode_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtBCode.SelectionStart = 0;
			txtBCode.SelectionLength = 999;
		}

		private void txtBCode_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			switch (KeyCode) {
				case 40:
					if (lstWorkspace.Items.Count) {
						if (lstWorkspace.SelectedIndex == -1) {
							lstWorkspace.SelectedIndex = 0;
						}
					}
					this.lstWorkspace.Focus();
					break;

			}
		}

		private void txtBCode_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case 13:
					doSearchBC();
					break;
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
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
					if (lstWorkspace.Items.Count) {
						if (lstWorkspace.SelectedIndex == -1) {
							lstWorkspace.SelectedIndex = 0;
						}
					}
					this.lstWorkspace.Focus();
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

		private void gridItem_EnterCell(System.Object eventSender, DataGridViewCellEventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			if (loading)
				return;
			loading = true;
			var _with6 = gridItem;
			if (_with6.row) {

				if (_with6.Col == colContentExclusive) {
					_txtEdit_1.SetBounds(sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with6.Left, true) + _with6.CellLeft, true), sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with6.Top, false) + _with6.CellTop, false), sizeConvertors.twipsToPixels(_with6.CellWidth, true), sizeConvertors.twipsToPixels(_with6.CellHeight, false));
					_txtEdit_1.Text = _with6.Text;
					_txtEdit_1.Tag = _txtEdit_1.Text;
					_txtEdit_1.Visible = true;
					_txtEdit_1.SelectionStart = 0;
					_txtEdit_1.SelectionLength = 9999;
					if (this.Visible)
						_txtEdit_1.Focus();
				} else {
					_txtEdit_1.Visible = false;
				}
				if (_with6.Col == colPrice) {
					if (Convert.ToInt16(_with6.Text) == 0) {
						Interaction.MsgBox("Matrix Selling price cannot be changed!", MsgBoxStyle.Critical);
						loading = false;
						txtSearch.Focus();
						return;
					}
					_txtEdit_2.SetBounds(sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with6.Left, true) + _with6.CellLeft, true), sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with6.Top, false) + _with6.CellTop, false), sizeConvertors.twipsToPixels(_with6.CellWidth, true), sizeConvertors.twipsToPixels(_with6.CellHeight, false));
					_txtEdit_2.Text = _with6.Text;
					_txtEdit_2.Tag = _txtEdit_2.Text;
					_txtEdit_2.Visible = true;
					_txtEdit_2.SelectionStart = 0;
					_txtEdit_2.SelectionLength = 9999;
					if (this.Visible)
						_txtEdit_2.Focus();
				} else {
					_txtEdit_2.Visible = false;
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
			}
			loading = false;
			if (bFNVegPackSize & orderType == 0) {
				//Set rsPackSize = getRS("SELECT StockItem.StockItemID, PackSize.PackSize_Volume FROM StockItem INNER JOIN PackSize ON StockItem.StockItem_PackSizeID = PackSize.PackSizeID WHERE (((StockItem.StockItemID)=" & gridItem.RowData(gridItem.row) & "));")
				rsPackSize = modRecordSet.getRS(ref "SELECT GRVItem.GRVItem_PackSizeVol FROM GRVItem WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_StockItemID)=" + gridItem.get_RowData(ref gridItem.row) + ") AND ((GRVItem.GRVItem_Return)=" + orderType + "));");
				txtPackSize.Text = Strings.FormatNumber(rsPackSize.Fields("GRVItem_PackSizeVol").Value, 2);
			}
			return;
			gridItem_Err:
			 // ERROR: Not supported in C#: ResumeStatement

		}
		private void gridItem_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			//    txtEdit_GotFocus
		}

		private void gridItem_KeyPress(System.Object eventSender, KeyPressEventArgs eventArgs)
		{
			switch (eventArgs.KeyChar) {
				case Strings.Chr(40):
					eventArgs.KeyChar = Strings.Chr(0);
					break;
			}

		}

		private void gridItem_LeaveCell(System.Object eventSender, DataGridViewCellEventArgs eventArgs)
		{
			update_Renamed();
		}



		private void txtEdit_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim Index As Short = txtEdit.GetIndex(eventSender)
			TextBox txtEdit = (TextBox)eventSender;
			txtEdit.SelectionStart = 0;
			txtEdit.SelectionLength = 999;

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

			return true;
		}

		private void txtEdit_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			//Dim Index As Short = txtEdit.GetIndex(eventSender)
			TextBox txtBox = (TextBox)eventSender;
			string lNewText = null;
			// Delete carriage returns to get rid of beep
			// and only allow numbers.
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
					if (txtBox.TabIndex == _txtEdit_0.TabIndex) {
						if (Convert.ToBoolean(gridItem.get_TextMatrix(ref gridItem.row, ref colFractions))) {
						} else {
							KeyAscii = 0;
							goto EventExitSub;
						}
					}

					if (Strings.Chr(KeyAscii) == ".") {
						lNewText = txtBox.Text;
						if (txtBox.SelectionLength) {
							lNewText = Strings.Left(txtBox.Text, txtBox.SelectionStart) + Strings.Mid(txtBox.Text, txtBox.SelectionStart + txtBox.SelectionLength + 1);
						}
						if (Strings.InStr(lNewText, ".")) {
							KeyAscii = 0;
						} else {
						}
					} else {
						KeyAscii = 0;
					}

					break;
			}
			EventExitSub:
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
	}
}
