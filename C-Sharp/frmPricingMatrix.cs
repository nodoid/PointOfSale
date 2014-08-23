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
	internal partial class frmPricingMatrix : System.Windows.Forms.Form
	{
		bool loading;
		int gID;
		object[] gDataArray;
		List<Label> lblColorFixed = new List<Label>();
		List<Label> lblcolor = new List<Label>();
		List<TextBox> txtUnit = new List<TextBox>();
		List<TextBox> txtCase = new List<TextBox>();

		private void loadLanguage()
		{

			//frmPricingMatrix = No Code [Detailed Pricing Matrices]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmPricingMatrix.Caption = rsLang("LanguageLayoutLnk_Description"): frmPricingMatrix.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Function Unknown!
			//Command1 = No Code     []
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Command1.Caption = rsLang("LanguageLayoutLnk_Description"): Command1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1085;
			//Print|Checked
			if (modRecordSet.rsLang.RecordCount){cmdPrint.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPrint.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//Note: Field is Dynamic with Default as below!
			//lblHeading = No Code   [Default Pricing Matrix for each Channel]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblHeading.Caption = rsLang("LanguageLayoutLnk_Description"): lblHeading.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_2 = No Code       [Unit Markup]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_5 = No Code       [Case/Carton Markup]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_5.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblPricingGroup(1) = No Code
			//lblPricingGroup(2) = No Code
			//lblPricingGroup(3) = No Code
			//lblPricingGroup(4) = No Code
			//lblPricingGroup(5) = No Code
			//lblPricingGroup(6) = No Code
			//lblPricingGroup(7) = No Code
			//lblPricingGroup(8) = No Code

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmPricingMatrix.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void setup()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			short x = 0;
			rs = modRecordSet.getRS(ref "SELECT Channel_Code FROM Channel ORDER BY ChannelID");
			var _with1 = gridItem;
			_with1.RowCount = 2;
			_with1.Col = 10;
			// Set FixedRows to 0 so you can use AddItem. You can't
			// use AddItem with a FixedRow. You have to use the Text property
			_with1.FixedRows = 0;
			//.MergeCells = MSFlexGridLib.MergeCellsSettings.flexMergeFree 'Set the MergeCells property.
			_with1.row = 0;
			_with1.Col = 0;
			_with1.set_ColWidth(0, 1300);
			_with1.set_ColWidth(1, 700);
			_with1.set_ColWidth(2, 700);
			_with1.set_ColWidth(3, 700);
			_with1.set_ColWidth(4, 700);
			_with1.set_ColWidth(5, 700);
			_with1.set_ColWidth(6, 700);
			_with1.set_ColWidth(7, 700);
			_with1.set_ColWidth(8, 700);
			_with1.set_ColWidth(9, 700);
			_with1.set_TextMatrix(0, 0, "Pack");
			_with1.set_TextMatrix(0, 0, "QTY");
			rs.MoveFirst();
			for (x = 0; x <= 7; x++) {
				_with1.set_TextMatrix(0, x + 2, rs.Fields("Channel_Code").Value);
				rs.moveNext();
			}
			_with1.FixedCols = 2;
			_with1.FixedRows = 1;

		}

		private void setup_NEW()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			short x = 0;
			rs = modRecordSet.getRS(ref "SELECT Channel_Code FROM Channel ORDER BY ChannelID");
			var _with2 = gridItem;
			_with2.RowCount = 2;
			_with2.Col = 10;
			// Set FixedRows to 0 so you can use AddItem. You can't
			// use AddItem with a FixedRow. You have to use the Text property
			_with2.FixedRows = 0;
			//.MergeCells = MSFlexGridLib.MergeCellsSettings.flexMergeFree 'Set the MergeCells property.
			_with2.row = 0;
			_with2.Col = 0;
			_with2.set_ColWidth(0, 1300);
			_with2.set_ColWidth(1, 700);
			_with2.set_ColWidth(2, 700);
			_with2.set_ColWidth(3, 700);
			_with2.set_ColWidth(4, 700);
			_with2.set_ColWidth(5, 700);
			_with2.set_ColWidth(6, 700);
			_with2.set_ColWidth(7, 700);
			_with2.set_ColWidth(8, 700);
			_with2.set_ColWidth(9, 700);
			_with2.set_TextMatrix(0, 0, "Pack");
			//.TextMatrix(0, 0) = "SHRINKS"
			_with2.set_TextMatrix(0, 0, " ");
			_with2.set_TextMatrix(0, 1, "QTY");
			rs.MoveFirst();
			for (x = 0; x <= 7; x++) {
				_with2.set_TextMatrix(0, x + 2, rs.Fields("Channel_Code").Value);
				rs.moveNext();
			}
			_with2.FixedCols = 2;
			_with2.FixedRows = 1;

		}

		public void loadMatrix(ref int id)
		{
			loading = true;
			int x = 0;
			int lCNT = 0;
			short lDepositQuantity = 0;
			ADODB.Recordset rsMaster = default(ADODB.Recordset);
			ADODB.Recordset rs = default(ADODB.Recordset);
			int lPackSizeID = 0;
			bool lColour = false;
			gID = id;
			setup();
			rs = modRecordSet.getRS(ref "SELECT PricingGroup.* From PricingGroup WHERE (((PricingGroup.PricingGroupID)=" + gID + "));");
			if (rs.BOF | rs.EOF) {
				this.Close();
				System.Environment.Exit(0);
			} else {
				lblHeading.Text = rs.Fields("PricingGroup_Name").Value;
				for (x = 1; x <= 8; x++) {
					txtUnit[x].Text = Strings.FormatNumber(rs.Fields("PricingGroup_Unit" + x).Value, 2);
					txtCase[x].Text = Strings.FormatNumber(rs.Fields("PricingGroup_Case" + x).Value, 2);
				}

			}
			rs.Close();
			rsMaster = modRecordSet.getRS(ref "SELECT shrink.PricingGroup, PackSize.PackSizeID, PackSize.PackSize_Name, shrink.Quantity FROM [SELECT StockItem.StockItem_PricingGroupID AS PricingGroup, ShrinkItem.ShrinkItem_Quantity AS Quantity, StockItem.StockItem_PackSizeID AS PackSizeID FROM StockItem INNER JOIN ShrinkItem ON StockItem.StockItem_ShrinkID = ShrinkItem.ShrinkItem_ShrinkID GROUP BY StockItem.StockItem_PricingGroupID, ShrinkItem.ShrinkItem_Quantity, StockItem.StockItem_PackSizeID]. AS shrink LEFT JOIN PackSize ON shrink.PackSizeID = PackSize.PackSizeID Where (((shrink.PricingGroup) = " + gID + ")) ORDER BY PackSize.PackSize_Volume, PackSize.PackSizeID, shrink.Quantity;");
			txtEdit.Visible = false;
			var _with3 = gridItem;
			_with3.RowCount = 1;
			_with3.Visible = false;
			lCNT = -1;
			while (!(rsMaster.EOF)) {
				if (lPackSizeID != rsMaster.Fields("PackSizeID").Value) {
					lColour = !lColour;
					_with3.Rows.Add(rsMaster.Fields("PackSize_Name").Value);
					lPackSizeID = rsMaster.Fields("PackSizeID").Value;
				} else {
					_with3.Rows.Add("");
				}
				_with3.row = _with3.RowCount - 1;
				_with3.Col = 0;
				_with3.CellBackColor = lblColorFixed[System.Math.Abs(Convert.ToInt16(lColour))].BackColor;
				_with3.Col = 1;
				_with3.CellBackColor = lblColorFixed[System.Math.Abs(Convert.ToInt16(lColour))].BackColor;
				_with3.Text = rsMaster.Fields("quantity").Value;
				_with3.set_RowData(_with3.row, rsMaster.Fields("PackSizeID").Value);
				for (x = 1; x <= 8; x++) {
					//UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					_with3.Col = x + 1;
					//UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					rs = modRecordSet.getRS(ref ref "SELECT PricingGroupChannelLnk.PricingGroupChannelLnk_Markup From PricingGroupChannelLnk WHERE (((PricingGroupChannelLnk.PricingGroupChannelLnk_PricingGroupID)=" + gID + ") AND ((PricingGroupChannelLnk.PricingGroupChannelLnk_PackSizeID)=" + rsMaster.Fields("PackSizeID").Value + ") AND ((PricingGroupChannelLnk.PricingGroupChannelLnk_Quantity)=" + rsMaster.Fields("quantity").Value + ") AND ((PricingGroupChannelLnk.PricingGroupChannelLnk_ChannelID)=" + x + "));");
					if (rs.BOF | rs.EOF) {
						_with3.CellBackColor = lblcolor[System.Math.Abs(Convert.ToInt16(lColour))].BackColor;
						if (rsMaster.Fields("quantity").Value == 1) {
							_with3.Text = txtUnit[x].Text;
						} else {
							_with3.Text = txtCase[x].Text;
						}
					} else {
						_with3.CellBackColor = lblColorChanged.BackColor;
						_with3.Text = Strings.FormatNumber(rs.Fields("PricingGroupChannelLnk_Markup").Value, 2);
					}
					rs.Close();
				}
				rsMaster.moveNext();
			}

			_with3.Visible = true;


			loading = false;
			if (gridItem.RowCount > 1) {
				gridItem.row = 1;
				gridItem.Col = 2;
			} else {
				txtEdit.Visible = false;
			}
			loading = false;
		}


		public void loadMatrix_NEW(ref int id)
		{
			loading = true;
			int x = 0;
			int lCNT = 0;
			short lDepositQuantity = 0;
			ADODB.Recordset rsMaster = default(ADODB.Recordset);
			ADODB.Recordset rs = default(ADODB.Recordset);
			int lPackSizeID = 0;
			bool lColour = false;
			gID = id;
			setup();
			rs = modRecordSet.getRS(ref "SELECT PricingGroup.* From PricingGroup WHERE (((PricingGroup.PricingGroupID)=" + gID + "));");
			if (rs.BOF | rs.EOF) {
				this.Close();
				System.Environment.Exit(0);
			} else {
				lblHeading.Text = rs.Fields("PricingGroup_Name").Value;
				for (x = 1; x <= 8; x++) {
					//UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					txtUnit[x].Text = Strings.FormatNumber(rs.Fields("PricingGroup_Unit" + x).Value, 2);
					//UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					txtCase[x].Text = Strings.FormatNumber(rs.Fields("PricingGroup_Case" + x).Value, 2);
				}

			}
			rs.Close();
			//Old PM
			//Set rsMaster = getRS("SELECT shrink.PricingGroup, PackSize.PackSizeID, PackSize.PackSize_Name, shrink.Quantity FROM [SELECT StockItem.StockItem_PricingGroupID AS PricingGroup, ShrinkItem.ShrinkItem_Quantity AS Quantity, StockItem.StockItem_PackSizeID AS PackSizeID FROM StockItem INNER JOIN ShrinkItem ON StockItem.StockItem_ShrinkID = ShrinkItem.ShrinkItem_ShrinkID GROUP BY StockItem.StockItem_PricingGroupID, ShrinkItem.ShrinkItem_Quantity, StockItem.StockItem_PackSizeID]. AS shrink LEFT JOIN PackSize ON shrink.PackSizeID = PackSize.PackSizeID Where (((shrink.PricingGroup) = " & gID & ")) ORDER BY PackSize.PackSize_Volume, PackSize.PackSizeID, shrink.Quantity;")

			//New PM
			rsMaster = modRecordSet.getRS(ref "SELECT PricingGroup.PricingGroupID AS PricingGroup, Shrink.ShrinkID AS ShrinkID, Shrink.Shrink_Name AS Shrink_Name, ShrinkItem.ShrinkItem_Quantity AS Quantity FROM ((Shrink INNER JOIN ShrinkItem ON Shrink.ShrinkID = ShrinkItem.ShrinkItem_ShrinkID) INNER JOIN StockItem ON Shrink.ShrinkID = StockItem.StockItem_ShrinkID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID GROUP BY PricingGroup.PricingGroupID, Shrink.ShrinkID, Shrink.Shrink_Name, ShrinkItem.ShrinkItem_Quantity HAVING (((PricingGroup.PricingGroupID)=" + gID + ")) ORDER BY ShrinkItem.ShrinkItem_Quantity;");

			txtEdit.Visible = false;
			var _with4 = gridItem;
			_with4.RowCount = 1;
			_with4.Visible = false;
			//UPGRADE_WARNING: Couldn't resolve default property of object lCNT. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lCNT = -1;
			while (!(rsMaster.EOF)) {

				if (_with4.row > 0) {
					for (x = 0; x <= _with4.row; x++) {
						//UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (gridItem.get_TextMatrix(ref ref x, ref ref 1) == rsMaster.Fields("quantity").Value)
							goto skipRow;
					}
				}
				//If lPackSizeID <> rsMaster("PackSizeID") Then
				if (lPackSizeID != rsMaster.Fields("ShrinkID").Value) {
					lColour = !lColour;
					//.AddItem rsMaster("PackSize_Name")
					//.AddItem rsMaster("Shrink_Name")
					_with4.Rows.Add("");
					//lPackSizeID = rsMaster("PackSizeID")
					lPackSizeID = rsMaster.Fields("ShrinkID").Value;
				} else {
					_with4.Rows.Add("");
				}
				_with4.row = _with4.RowCount - 1;
				_with4.Col = 0;
				_with4.CellBackColor = lblColorFixed[System.Math.Abs(Convert.ToInt16(lColour))].BackColor;
				_with4.Col = 1;
				_with4.CellBackColor = lblColorFixed[System.Math.Abs(Convert.ToInt16(lColour))].BackColor;
				_with4.Text = rsMaster.Fields("quantity").Value;
				//.RowData(.row) = rsMaster("PackSizeID")
				_with4.set_RowData(_with4.row, rsMaster.Fields("ShrinkID").Value);
				for (x = 1; x <= 8; x++) {
					//UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					_with4.Col = x + 1;
					//Set rs = getRS("SELECT PricingGroupChannelLnk.PricingGroupChannelLnk_Markup From PricingGroupChannelLnk WHERE (((PricingGroupChannelLnk.PricingGroupChannelLnk_PricingGroupID)=" & gID & ") AND ((PricingGroupChannelLnk.PricingGroupChannelLnk_PackSizeID)=" & rsMaster("PackSizeID") & ") AND ((PricingGroupChannelLnk.PricingGroupChannelLnk_Quantity)=" & rsMaster("quantity") & ") AND ((PricingGroupChannelLnk.PricingGroupChannelLnk_ChannelID)=" & x & "));")
					//Set rs = getRS("SELECT PricingGroupChannelLnk.PricingGroupChannelLnk_Markup From PricingGroupChannelLnk WHERE (((PricingGroupChannelLnk.PricingGroupChannelLnk_PricingGroupID)=" & gID & ") AND ((PricingGroupChannelLnk.PricingGroupChannelLnk_PackSizeID)=" & rsMaster("ShrinkID") & ") AND ((PricingGroupChannelLnk.PricingGroupChannelLnk_Quantity)=" & rsMaster("quantity") & ") AND ((PricingGroupChannelLnk.PricingGroupChannelLnk_ChannelID)=" & x & "));")
					//UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					rs = modRecordSet.getRS(ref ref "SELECT PricingGroupChannelLnk.PricingGroupChannelLnk_Markup From PricingGroupChannelLnk WHERE (((PricingGroupChannelLnk.PricingGroupChannelLnk_PricingGroupID)=" + gID + ") AND ((PricingGroupChannelLnk.PricingGroupChannelLnk_Quantity)=" + rsMaster.Fields("quantity").Value + ") AND ((PricingGroupChannelLnk.PricingGroupChannelLnk_ChannelID)=" + x + "));");
					if (rs.BOF | rs.EOF) {
						_with4.CellBackColor = lblcolor[System.Math.Abs(Convert.ToInt16(lColour))].BackColor;
						if (rsMaster.Fields("quantity").Value == 1) {
							_with4.Text = txtUnit[x].Text;
						} else {
							_with4.Text = txtCase[x].Text;
						}
					} else {
						_with4.CellBackColor = lblColorChanged.BackColor;
						_with4.Text = Strings.FormatNumber(rs.Fields("PricingGroupChannelLnk_Markup").Value, 2);
					}
					rs.Close();
				}
				skipRow:

				rsMaster.moveNext();
			}

			_with4.Visible = true;


			loading = false;
			if (gridItem.RowCount > 1) {
				gridItem.row = 1;
				gridItem.Col = 2;
			} else {
				txtEdit.Visible = false;
			}
			loading = false;
		}


		private void save()
		{
			int lCol = 0;
			int colorInActive = 0;
			string sql = null;
			decimal lAmountDefault = default(decimal);
			short lQuantity = 0;
			if (loading)
				return;
			if (gridItem.row) {
				if (string.IsNullOrEmpty(gridItem.get_TextMatrix(ref gridItem.row, ref 1)))
					return;
				lQuantity = Convert.ToInt16(gridItem.get_TextMatrix(ref gridItem.row, ref 1));
				if (lQuantity > 1) {
					lAmountDefault = Convert.ToDecimal(this.txtCase[this.gridItem.Col - 1].Text);
				} else {
					lAmountDefault = Convert.ToDecimal(this.txtUnit[this.gridItem.Col - 1].Text);
				}
				if (txtEdit.Text != txtEdit.Tag) {
					txtEdit.Tag = txtEdit.Text;

					if (string.IsNullOrEmpty(txtEdit.Text)) {
						txtEdit.Text = Strings.FormatNumber(lAmountDefault * 100, 0, TriState.False, TriState.False, TriState.False);
						if (string.IsNullOrEmpty(txtEdit.Text)) {
							txtEdit.Text = "0";
						}
					}
					modRecordSet.cnnDB.Execute("INSERT INTO tempStockItem ( tempStockItemID ) SELECT StockItem.StockItemID FROM StockItem LEFT JOIN tempStockItem ON StockItem.StockItemID = tempStockItem.tempStockItemID WHERE (((StockItem.StockItem_PricingGroupID)=" + gID + ") AND ((tempStockItem.tempStockItemID) Is Null) AND ((StockItem.StockItem_PackSizeID)=" + gridItem.get_RowData(ref gridItem.row) + "));");
					gridItem.Text = Strings.FormatNumber(Convert.ToDouble(txtEdit.Text) / 100, 2, TriState.False, TriState.False, TriState.False);
					sql = "DELETE FROM PricingGroupChannelLnk WHERE (PricingGroupChannelLnk_PricingGroupID = " + gID + ") AND (PricingGroupChannelLnk_PackSizeID = " + gridItem.get_RowData(ref gridItem.row) + ") AND (PricingGroupChannelLnk_Quantity = " + lQuantity + ") AND (PricingGroupChannelLnk_ChannelID = " + gridItem.Col - 1 + ")";
					modRecordSet.cnnDB.Execute(sql);
					if (lAmountDefault == Convert.ToDecimal(gridItem.Text)) {
						//UPGRADE_WARNING: Couldn't resolve default property of object colorInActive. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(colorInActive);
						loading = true;
						//UPGRADE_WARNING: Couldn't resolve default property of object lCol. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						lCol = gridItem.Col;
						gridItem.Col = 0;
						if (System.Drawing.ColorTranslator.ToOle(gridItem.CellBackColor) == System.Drawing.ColorTranslator.ToOle(this.lblColorFixed[0].BackColor)) {
							//UPGRADE_WARNING: Couldn't resolve default property of object lCol. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							gridItem.Col = lCol;
							gridItem.CellBackColor = this.lblcolor[0].BackColor;

						} else {
							//UPGRADE_WARNING: Couldn't resolve default property of object lCol. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							gridItem.Col = lCol;
							gridItem.CellBackColor = this.lblcolor[1].BackColor;
						}

						loading = false;
					} else {
						sql = "INSERT INTO PricingGroupChannelLnk (PricingGroupChannelLnk_PricingGroupID, PricingGroupChannelLnk_PackSizeID, PricingGroupChannelLnk_Quantity, PricingGroupChannelLnk_ChannelID, PricingGroupChannelLnk_Markup) VALUES (" + gID + ", " + gridItem.get_RowData(ref gridItem.row) + ", " + lQuantity + ", " + gridItem.Col - 1 + ", " + gridItem.Text + ");";
						modRecordSet.cnnDB.Execute(sql);
						gridItem.CellBackColor = this.lblColorChanged.BackColor;
					}
					sql = "INSERT INTO tempStockItem (tempStockItemID) SELECT StockItem.StockItemID FROM StockItem LEFT JOIN tempStockItem ON StockItem.StockItemID = tempStockItem.tempStockItemID WHERE (((StockItem.StockItem_PackSizeID)=" + gridItem.get_RowData(ref gridItem.row) + ") AND ((StockItem.StockItem_PricingGroupID)=" + gID + ") AND ((tempStockItem.tempStockItemID) Is Null));";
					modRecordSet.cnnDB.Execute(sql);
				}

			}
		}


		private void save_NEW()
		{
			int lCol = 0;
			int colorInActive = 0;
			string sql = null;
			decimal lAmountDefault = default(decimal);
			short lQuantity = 0;
			if (loading)
				return;
			if (gridItem.row) {
				if (string.IsNullOrEmpty(gridItem.get_TextMatrix(ref gridItem.row, ref 1)))
					return;
				lQuantity = Convert.ToInt16(gridItem.get_TextMatrix(ref gridItem.row, ref 1));
				if (lQuantity > 1) {
					lAmountDefault = Convert.ToDecimal(this.txtCase[this.gridItem.Col - 1].Text);
				} else {
					lAmountDefault = Convert.ToDecimal(this.txtUnit[this.gridItem.Col - 1].Text);
				}
				if (txtEdit.Text != txtEdit.Tag) {
					txtEdit.Tag = txtEdit.Text;

					if (string.IsNullOrEmpty(txtEdit.Text)) {
						txtEdit.Text = Strings.FormatNumber(lAmountDefault * 100, 0, TriState.False, TriState.False, TriState.False);
						if (string.IsNullOrEmpty(txtEdit.Text)) {
							txtEdit.Text = "0";
						}
					}
					//cnnDB.Execute "INSERT INTO tempStockItem ( tempStockItemID ) SELECT StockItem.StockItemID FROM StockItem LEFT JOIN tempStockItem ON StockItem.StockItemID = tempStockItem.tempStockItemID WHERE (((StockItem.StockItem_PricingGroupID)=" & gID & ") AND ((tempStockItem.tempStockItemID) Is Null) AND ((StockItem.StockItem_PackSizeID)=" & gridItem.RowData(gridItem.row) & "));"
					modRecordSet.cnnDB.Execute("INSERT INTO tempStockItem ( tempStockItemID ) SELECT StockItem.StockItemID FROM StockItem LEFT JOIN tempStockItem ON StockItem.StockItemID = tempStockItem.tempStockItemID WHERE (((StockItem.StockItem_PricingGroupID)=" + gID + ") AND ((tempStockItem.tempStockItemID) Is Null));");
					gridItem.Text = Strings.FormatNumber(Convert.ToDouble(txtEdit.Text) / 100, 2, TriState.False, TriState.False, TriState.False);
					//sql = "DELETE FROM PricingGroupChannelLnk WHERE (PricingGroupChannelLnk_PricingGroupID = " & gID & ") AND (PricingGroupChannelLnk_PackSizeID = " & gridItem.RowData(gridItem.row) & ") AND (PricingGroupChannelLnk_Quantity = " & lQuantity & ") AND (PricingGroupChannelLnk_ChannelID = " & gridItem.Col - 1 & ")"
					sql = "DELETE FROM PricingGroupChannelLnk WHERE (PricingGroupChannelLnk_PricingGroupID = " + gID + ") AND (PricingGroupChannelLnk_Quantity = " + lQuantity + ") AND (PricingGroupChannelLnk_ChannelID = " + gridItem.Col - 1 + ")";
					modRecordSet.cnnDB.Execute(sql);
					if (lAmountDefault == Convert.ToDecimal(gridItem.Text)) {
						//UPGRADE_WARNING: Couldn't resolve default property of object colorInActive. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(colorInActive);
						loading = true;
						//UPGRADE_WARNING: Couldn't resolve default property of object lCol. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						lCol = gridItem.Col;
						gridItem.Col = 0;
						if (System.Drawing.ColorTranslator.ToOle(gridItem.CellBackColor) == System.Drawing.ColorTranslator.ToOle(this.lblColorFixed[0].BackColor)) {
							//UPGRADE_WARNING: Couldn't resolve default property of object lCol. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							gridItem.Col = lCol;
							gridItem.CellBackColor = this.lblcolor[0].BackColor;

						} else {
							//UPGRADE_WARNING: Couldn't resolve default property of object lCol. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							gridItem.Col = lCol;
							gridItem.CellBackColor = this.lblcolor[1].BackColor;
						}

						loading = false;
					} else {
						//sql = "INSERT INTO PricingGroupChannelLnk (PricingGroupChannelLnk_PricingGroupID, PricingGroupChannelLnk_PackSizeID, PricingGroupChannelLnk_Quantity, PricingGroupChannelLnk_ChannelID, PricingGroupChannelLnk_Markup) VALUES (" & gID & ", " & gridItem.RowData(gridItem.row) & ", " & lQuantity & ", " & gridItem.Col - 1 & ", " & gridItem.Text & ");"
						sql = "INSERT INTO PricingGroupChannelLnk (PricingGroupChannelLnk_PricingGroupID, PricingGroupChannelLnk_PackSizeID, PricingGroupChannelLnk_Quantity, PricingGroupChannelLnk_ChannelID, PricingGroupChannelLnk_Markup) VALUES (" + gID + ", " + 0 + ", " + lQuantity + ", " + gridItem.Col - 1 + ", " + gridItem.Text + ");";
						modRecordSet.cnnDB.Execute(sql);
						gridItem.CellBackColor = this.lblColorChanged.BackColor;
					}
					//sql = "INSERT INTO tempStockItem (tempStockItemID) SELECT StockItem.StockItemID FROM StockItem LEFT JOIN tempStockItem ON StockItem.StockItemID = tempStockItem.tempStockItemID WHERE (((StockItem.StockItem_PackSizeID)=" & gridItem.RowData(gridItem.row) & ") AND ((StockItem.StockItem_PricingGroupID)=" & gID & ") AND ((tempStockItem.tempStockItemID) Is Null));"
					sql = "INSERT INTO tempStockItem (tempStockItemID) SELECT StockItem.StockItemID FROM StockItem LEFT JOIN tempStockItem ON StockItem.StockItemID = tempStockItem.tempStockItemID WHERE ((StockItem.StockItem_PricingGroupID)=" + gID + ") AND ((tempStockItem.tempStockItemID) Is Null);";
					modRecordSet.cnnDB.Execute(sql);
				}

			}
		}


		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			save();
			this.Close();
		}

		private void cmdPricingGroup_Click()
		{
		}

		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//If frmPrint.loadHTM("PricingGroupMatrix", "id=" & lstPricingGroup.ItemData(lstPricingGroup.ListIndex), "PricingMatrix") Then
			//    frmPrint.show 1
			//Else
			//    MsgBox "Unable to display report!", vbExclamation, "Report Error"
			//End If

			modApplication.report_PricingMatrixNew(ref gID);
		}

		private void cmdStockItem_Click()
		{
			object lstPricingGroup = null;
			object frmPrint = null;
			//UPGRADE_WARNING: Couldn't resolve default property of object lstPricingGroup.ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object lstPricingGroup.ItemData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object frmPrint.loadHTM. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (frmPrint.loadHTM("PricingGroupStockItem", "id=" + lstPricingGroup.ItemData(lstPricingGroup.ListIndex), "PricingGroupStockItem")) {
				//UPGRADE_WARNING: Couldn't resolve default property of object frmPrint.show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				frmPrint.show(1);
			} else {
				Interaction.MsgBox("Unable to display report!", MsgBoxStyle.Exclamation, "Report Error");
			}
		}




		private void cmdClose_Click()
		{

		}

		private void Command1_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modApplication.report_PricingMatrix(ref gID);
		}

		private void frmPricingMatrix_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case System.Windows.Forms.Keys.Escape:
					KeyAscii = 0;
					cmdExit_Click(cmdExit, new System.EventArgs());
					break;
			}

			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmPricingMatrix_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			lblcolor.AddRange(new Label[] {
				_lblcolor_0,
				_lblcolor_1
			});
			lblColorFixed.AddRange(new Label[] {
				_lblColorFixed_0,
				_lblColorFixed_1
			});
			txtCase.AddRange(new TextBox[] {
				_txtCase_1,
				_txtCase_2,
				_txtCase_3,
				_txtCase_4,
				_txtCase_5,
				_txtCase_6,
				_txtCase_7,
				_txtCase_8
			});
			txtUnit.AddRange(new TextBox[] {
				_txtUnit_1,
				_txtUnit_2,
				_txtUnit_3,
				_txtUnit_4,
				_txtUnit_5,
				_txtUnit_6,
				_txtUnit_7,
				_txtUnit_8
			});
			loadLanguage();
		}

		//Handles gridItem.EnterCell
		private void gridItem_EnterCell(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (loading)
				return;
			var _with5 = gridItem;
			if (_with5.row) {
			} else {
				return;
			}
			txtEdit.SetBounds(sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with5.Left, true) + _with5.CellLeft, true), sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with5.Top, false) + _with5.CellTop, false), sizeConvertors.twipsToPixels(_with5.CellWidth, true), sizeConvertors.twipsToPixels(_with5.CellHeight, false));
			txtEdit.Text = Strings.Replace(_with5.Text, ".", "");
			if (txtEdit.Text == "000")
				txtEdit.Text = "0";
			txtEdit.Tag = txtEdit.Text;
			txtEdit.Visible = true;
			if (this.Visible)
				txtEdit.Focus();

		}

		private void gridItem_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtEdit_Enter(txtEdit, new System.EventArgs());
		}

		private void gridItem_KeyPress(System.Object eventSender, KeyPressEventArgs eventArgs)
		{
			int direction = 0;
			direction = 0;
			switch (eventArgs.KeyChar) {
				case Strings.ChrW(40):
					eventArgs.KeyChar = Strings.ChrW(0);
					break;
			}

		}

		//Handles gridItem.LeaveCell
		private void gridItem_LeaveCell(System.Object eventSender, System.EventArgs eventArgs)
		{
			save();
		}



		private void lblHeading_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modApplication.report_PricingMatrix(ref gID);
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
			bool bDoNotEdit = false;
			var _with6 = this.gridItem;
			switch (KeyCode) {
				case 27:
					//ESC
					txtEdit.Visible = false;
					_with6.Focus();
					break;
				case 13:
					//ENTER
					_with6.Focus();
					System.Windows.Forms.Application.DoEvents();
					moveNext(ref ref 1);
					break;
				case 37:
					//Left arrow
					if (txtEdit.SelectionStart == 0 & txtEdit.SelectionLength == 0 | txtEdit.SelectedText == txtEdit.Text) {
						_with6.Focus();
						System.Windows.Forms.Application.DoEvents();
						if (_with6.Col > _with6.FixedCols) {
							bDoNotEdit = true;
							_with6.Col = _with6.Col - 1;
							bDoNotEdit = false;
						}
					}
					break;
				case 39:
					//Right arrow
					if (txtEdit.SelectionStart == Strings.Len(txtEdit.Text) | txtEdit.SelectedText == txtEdit.Text) {
						_with6.Focus();
						System.Windows.Forms.Application.DoEvents();
						if (_with6.Col < _with6.ColumnCount - 1) {
							bDoNotEdit = true;
							_with6.Col = _with6.Col + 1;
							bDoNotEdit = false;
						}
					}

					break;
				case 38:
					//Up arrow
					_with6.Focus();
					System.Windows.Forms.Application.DoEvents();
					if (_with6.row > _with6.FixedRows) {
						bDoNotEdit = true;
						_with6.row = _with6.row - 1;
						bDoNotEdit = false;

					}
					break;
				case 40:
					//Down arrow
					_with6.Focus();
					System.Windows.Forms.Application.DoEvents();
					if (_with6.row < _with6.RowCount - 1) {
						bDoNotEdit = true;
						_with6.row = _with6.row + 1;
						bDoNotEdit = false;
					}
					break;
			}
		}
		private bool moveNext(ref int direction)
		{
			short x = 0;
			short y = 0;
			x = gridItem.Col + direction;
			if (x >= gridItem.Col) {
				gridItem.Col = 1;
				if (gridItem.row < gridItem.RowCount - 1) {
					y = gridItem.row + 1;
					gridItem.TopRow = gridItem.TopRow + 1;
					gridItem.row = y;
				}
				System.Windows.Forms.Application.DoEvents();
			} else {
				gridItem.Col = gridItem.Col + 1;
			}
			return true;
		}


		private void txtEdit_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			//
			// Delete carriage returns to get rid of beep
			// and only allow numbers.
			//
			short lCurrentX = 0;
			switch (KeyAscii) {

				case Strings.Asc(Constants.vbCr):

					KeyAscii = 0;
					break;
				case 8:
				case 46:
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
				case 45:
					//-
					if (Strings.InStr(txtEdit.Text, "-")) {
					} else {
						lCurrentX = txtEdit.SelectionStart + 1;
						txtEdit.Text = "-" + txtEdit.Text;
						txtEdit.SelectionStart = lCurrentX;

					}
					KeyAscii = 0;
					break;
				case 43:
					//+
					if (Strings.InStr(txtEdit.Text, "-")) {
						lCurrentX = txtEdit.SelectionStart - 1;
						txtEdit.Text = Strings.Right(txtEdit.Text, Strings.Len(txtEdit.Text) - 1);
						if (lCurrentX < 0)
							lCurrentX = 0;
						txtEdit.SelectionStart = lCurrentX;

					}
					KeyAscii = 0;
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
