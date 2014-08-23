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
	internal partial class frmStockBarcode : System.Windows.Forms.Form
	{
		int gID;

		private void loadLanguage()
		{

			//frmStockBarcode = No Code  [Maintain Stock Item Barcodes]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmStockBarcode.Caption = rsLang("LanguageLayoutLnk_Description"): frmStockBarcode.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//cmdBuildBarcodes = No Code [&Build Barcode]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdBuildBarcode.Caption = rsLang("LanguageLayoutLnk_Description"): cmdBuildBarcode.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdBuildSPLU = No Code     [Build Scale PLU]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdBuildSPLU.Caption = rsLang("LanguageLayoutLnk_Description"): cmdBuildSPLU.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//NOTE: DB entry 1004 requires "&" for accelerator key!!!!
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lblHeading = No Code/Dynamic/NA!

			//_lbl_2 = No Code           [Barcodes]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//NOTE: DB Entry 2192 wrong case: "shrink" instead of "shrink"!!!
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2192;
			//shrink|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_13.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_13.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lbl(12) = No Code          [Bar Code]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lbl(12).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(12).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1195;
			//Disable|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_14.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_14.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lblBarcode(0) = No Code    [Bonne]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblBarcode(0).Caption = rsLang("LanguageLayoutLnk_Description"): lblBarcode(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmStockBarcode.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public void loadItem(ref int id)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			short x = 0;
			gID = id;
			rs = modRecordSet.getRS(ref "SELECT StockItem_Name FROM StockItem WHERE StockItemID = " + gID);
			if (rs.EOF | rs.EOF) {
			} else {
				lblHeading.Text = rs.Fields("StockItem_Name").Value;
			}

			sql = "INSERT INTO Catalogue ( Catalogue_StockItemID, Catalogue_Quantity, Catalogue_Barcode, Catalogue_Deposit, Catalogue_Content, Catalogue_Disabled ) ";
			sql = sql + "SELECT theJoin.StockItemID, theJoin.ShrinkItem_Quantity, 'CODE' AS Expr1, 0 AS deposit, 0 AS content, 0 AS disabled FROM [SELECT StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity FROM ShrinkItem INNER JOIN ";
			sql = sql + "StockItem ON ShrinkItem.ShrinkItem_ShrinkID = StockItem.StockItem_ShrinkID]. AS theJoin LEFT JOIN Catalogue ON (theJoin.ShrinkItem_Quantity = Catalogue.Catalogue_Quantity) AND (theJoin.StockItemID = Catalogue.Catalogue_StockItemID) ";
			sql = sql + "WHERE (((theJoin.StockItemID)=" + id + ") AND ((Catalogue.Catalogue_StockItemID) Is Null));";

			modRecordSet.cnnDB.Execute(sql);

			rs = modRecordSet.getRS(ref "SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, Catalogue.Catalogue_Barcode, Catalogue.Catalogue_Deposit, Catalogue.Catalogue_Content, Catalogue.Catalogue_Disabled, ShrinkItem.ShrinkItem_Code FROM Catalogue INNER JOIN (StockItem INNER JOIN ShrinkItem ON StockItem.StockItem_ShrinkID = ShrinkItem.ShrinkItem_ShrinkID) ON (ShrinkItem.ShrinkItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID) Where (((Catalogue.Catalogue_StockItemID) = " + gID + ")) ORDER BY Catalogue.Catalogue_Quantity;");
			//Set rs = getRS("SELECT Catalogue.Catalogue_Quantity, Catalogue.Catalogue_Barcode, Catalogue.Catalogue_Disabled From Catalogue Where (((Catalogue.Catalogue_StockItemID) = " & gID & ")) ORDER BY Catalogue.Catalogue_Quantity;")
			//For x = 1 To lblBarcode.Count - 1
			//lblBarcode.Unload(x)
			//txtBarcode.Unload(x)
			//chkBarcode.Unload(x)
			//Next 

			x = -1;
			while (!(rs.EOF)) {
				x = x + 1;
				if (x) {
					//txtBarcode.Load(x)
					_txtBarcode_0.Top = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_txtBarcode_0.Top, false) + sizeConvertors.pixelToTwips(_txtBarcode_0.Height, false) + 30, false);
					_txtBarcode_0.Visible = true;
					_txtBarcode_0.TabIndex = _txtBarcode_0.TabIndex + 1;
					//lblBarcode.Load(x)
					_lblBarcode_0.Top = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_txtBarcode_0.Top, false) + sizeConvertors.pixelToTwips(_txtBarcode_0.Height, false) + 60, false);
					_lblBarcode_0.Visible = true;
					_lblBarcode_0.BringToFront();

					//chkBarcode.Load(x)
					_chkBarcode_0.Top = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_txtBarcode_0.Top, false) + sizeConvertors.pixelToTwips(_txtBarcode_0.Height, false) + 90, false);
					_chkBarcode_0.Visible = true;
				}
				_lblBarcode_0.Text = rs.Fields("Catalogue_Quantity").Value;
				_txtBarcode_0.Text = rs.Fields("Catalogue_Barcode").Value;
				_txtBarcode_0.Tag = _txtBarcode_0.Text;
				_chkBarcode_0.CheckState = System.Math.Abs(Convert.ToInt16(rs.Fields("Catalogue_Disabled").Value));
				_chkBarcode_0.Tag = _chkBarcode_0.CheckState;
				rs.MoveNext();
			}
			Shape1.Height = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_lblBarcode_0.Top, false) + sizeConvertors.pixelToTwips(_lblBarcode_0.Height, false) + 240 - sizeConvertors.pixelToTwips(Shape1.Top, false), false);
			Height = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(Shape1.Top, false) + sizeConvertors.pixelToTwips(Shape1.Height, false) + 560, false);


		}

		private void cmdBuildBarcodes_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modApplication.buildBarcodes(ref gID);
			loadItem(ref gID);
		}

		private void cmdBuildSPLU_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rsChk = default(ADODB.Recordset);

			rsChk = modRecordSet.getRS(ref "SELECT TOP 1 Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, Catalogue.Catalogue_Barcode From Catalogue Where (((CDbl(IIf(IsNumeric([Catalogue].[Catalogue_Barcode]), [Catalogue].[Catalogue_Barcode], 0))) > 0 And (CDbl(IIf(IsNumeric([Catalogue].[Catalogue_Barcode]), [Catalogue].[Catalogue_Barcode], 0))) < 99999)) ORDER BY CLng(Catalogue.Catalogue_Barcode) DESC;");
			if (rsChk.RecordCount) {
				_txtBarcode_0.Text = Convert.ToString(Convert.ToDouble(rsChk.Fields("Catalogue_Barcode").Value) + 1);
			} else {
				_txtBarcode_0.Text = Convert.ToString(1);
			}

		}

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim x As Short
			//For x = 0 To txtBarcode.UBound
			_txtBarcode_0.Text = _txtBarcode_0.Tag;
			_chkBarcode_0.CheckState = Convert.ToInt16(_chkBarcode_0.Tag);
			//Next
		}

		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short x = 0;
			ADODB.Recordset rsChk = default(ADODB.Recordset);


			if (modApplication.bGRVNewItemBarcode == true) {
				//For x = 0 To txtBarcode.UBound
				//Set rsChk = getRS("SELECT Catalogue_Barcode FROM Catalogue WHERE Catalogue_Barcode = '" & Replace(_txtBarcode_0.Text, "'", "''") & "' AND Catalogue_StockItemID <> " & gID & " AND Catalogue_Disabled=False;")
				rsChk = modRecordSet.getRS(ref "SELECT Catalogue.Catalogue_Barcode, StockItem.StockItem_Name FROM StockItem INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID WHERE (((Catalogue.Catalogue_Barcode)='" + Strings.Replace(_txtBarcode_0.Text, "'", "''") + "') AND ((Catalogue.Catalogue_StockItemID)<>" + gID + ") AND ((Catalogue.Catalogue_Disabled)=False) AND ((StockItem.StockItem_Disabled)=False) AND ((StockItem.StockItem_Discontinued)=False));");
				if (rsChk.RecordCount) {
					Interaction.MsgBox("'" + rsChk.Fields("Catalogue_Barcode").Value + "'  Barcode has already been used by  '" + rsChk.Fields("StockItem_Name").Value + "' , Please type in different Barcode or use Build Barcode option.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					return;
				}
				//If _txtBarcode_0.Text <> _txtBarcode_0.Tag Then
				//    sql = "UPDATE Catalogue SET Catalogue_Barcode = '" & Replace(_txtBarcode_0.Text, "'", "''") & "' WHERE Catalogue_StockItemID = " & gID & " AND Catalogue_Quantity = " & _lblBarcode_0.Caption
				//    cnnDB.Execute sql
				//End If
				//If _chkBarcode_0.value <> _chkBarcode_0.Tag Then
				//    sql = "UPDATE Catalogue SET Catalogue_Disabled = '" & _chkBarcode_0.value & "' WHERE Catalogue_StockItemID = " & gID & " AND Catalogue_Quantity = " & _lblBarcode_0.Caption
				//    cnnDB.Execute sql
				//End If
				//Next

				this.Close();
			} else {
				this.Close();
			}

		}
		private void frmStockBarcode_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case System.Windows.Forms.Keys.Escape:
					KeyAscii = 0;
					System.Windows.Forms.Application.DoEvents();
					cmdClose_Click(cmdClose, new System.EventArgs());
					break;
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmStockBarcode_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			loadLanguage();
		}

		private void frmStockBarcode_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			short x = 0;
			string sql = null;
			//For x = 0 To txtBarcode.UBound
			if (_txtBarcode_0.Text != _txtBarcode_0.Tag) {
				sql = "UPDATE Catalogue SET Catalogue_Barcode = '" + Strings.Replace(_txtBarcode_0.Text, "'", "''") + "' WHERE Catalogue_StockItemID = " + gID + " AND Catalogue_Quantity = " + _lblBarcode_0.Text;
				modRecordSet.cnnDB.Execute(sql);
			}
			if (_chkBarcode_0.CheckState != Convert.ToDouble(_chkBarcode_0.Tag)) {
				sql = "UPDATE Catalogue SET Catalogue_Disabled = '" + _chkBarcode_0.CheckState + "' WHERE Catalogue_StockItemID = " + gID + " AND Catalogue_Quantity = " + _lblBarcode_0.Text;
				modRecordSet.cnnDB.Execute(sql);
			}
			// Next

		}

		//Handles txtBarcode.Enter
		private void txtBarcode_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim Index As Short = txtBarcode.GetIndex(eventSender)
			TextBox txtBox = new TextBox();
			txtBox = (TextBox)eventSender;
			txtBox.SelectionStart = 0;
			txtBox.SelectionLength = Strings.Len(txtBox.Text);

		}
	}
}
