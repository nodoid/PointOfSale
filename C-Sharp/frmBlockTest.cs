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
using System.Runtime.InteropServices;
 // ERROR: Not supported in C#: OptionDeclaration
 // ERROR: Not supported in C#: OptionDeclaration
using VB = Microsoft.VisualBasic;
namespace _4PosBackOffice.NET
{
	internal partial class frmBlockTest : System.Windows.Forms.Form
	{

//serialization
		ADODB.Recordset adoPrimaryRS;
		bool mbChangedByCode;
		bool mvBookMark;
		bool mbEditFlag;
		bool mbAddNewFlag;
		bool mbDataChanged;
		int gID;
		int k_posID;
		bool k_posNew;
		bool flag;
		float y;
		short c;
		short YY;
		short x;
		[DllImport("gdi32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int BitBlt(int hDestDC, int x, int y, int nWidth, int nHeight, int hSrcDC, int xSrc, int ySrc, int dwRop);

		System.Drawing.Image obj = new System.Drawing.Bitmap(1, 1);
		[DllImport("kernel32", EntryPoint = "GetDriveTypeA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int GetDriveType(string nDrive);

		int[] fox;
		string usb_drv;
		string yourdrive;
		bool CDKey;
//Option Explicit

		private byte[] arData;
		private byte[] arPWord;
		private short m_intCipher;
//serialization

		int gStockItemID;
		int gPromotionID;
		int gQuantity;
		bool loading;

		string testName;
		string testType;
		int testID;
		int[] StockItemLineID;

		int[,] selectTest;
		List<TextBox> txtEdit = new List<TextBox>();

		private void loadLanguage()
		{

			//frmBlockTest = No Code         [4MEAT Block Tester]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmBlockTest.Caption = rsLang("LanguageLayoutLnk_Description"): frmBlockTest.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1085;
			//Print|Checked
			if (modRecordSet.rsLang.RecordCount){cmdPrint.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPrint.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1332;
			//Process|Checked
			if (modRecordSet.rsLang.RecordCount){cmdProc.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdProc.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//cmdReg = No Code               [Register 4MEAT]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0
			//If rsLang.RecordCount Then cmdReg.Caption = rsLang("LanguageLayoutLnk_Description"): cmdReg.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//NOTE: frmTotals has a spelling mistake in the caption!!!
			//frmTotals = No Code            [General Information]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmTotals.Caption = rsLang("LanguageLayoutLnk_Description"): frmTotals.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblTotal_0 = No Code          [Person Cutting]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0
			//If rsLang.RecordCount Then _lblTotal_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblTotal_1 = No Code          [Price Per Kg]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblTotal_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblTotal_2 = No Code          [Weight of Carcass]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblTotal_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblTotal_3 = No code          [Cost of Carcass]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblTotal_3.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//NOTE: Label Caption needs "&&"
			//_lblTotal_4 = No Code          [Weight Loss && Cutting Loss]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblTotal_4.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblTotal_5 = No Code          [Effective Price per Kg after loss]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblTotal_5.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblTotal_10 = No Code         [Required GP]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblTotal_10.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_10.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblTotal_9 = No Code          [1 - GP%]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblTotal_9.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_9.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblTotal_8 = No Code          [B/Z]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblTotal_8.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_8.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblTotal_7 = No Code          [VAT]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblTotal_7.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_7.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblTotal_6 = No Code          [X - VAT + 1]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblTotal_6.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_6.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdTotal = No Code             [Calculate]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdTotal.Caption = rsLang("LanguageLayoutLnk_Description"): cmdTotal.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblTotal_11 = No Code         [Weight after Cutting && W.Loss - P]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblTotal_11.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_11.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblTotal_12 = No Code         [F]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblTotal_12.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_12.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblTotal_14 = No Code         [G]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblTotal_14.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_14.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblTotal_15 = No Code         [H]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblTotal_15.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_15.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblTotal_13 = No Code         [Q]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblTotal_13.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_13.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblLabel(16) = No Code         [L]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblTotal_16.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_16.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmBlockTest.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmBlockTest.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public void Reset_frmEncStrings()
		{
			arData = null;
			arPWord = null;
		}

		private void cmdLoadNext_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			decimal selectTestWeight = default(decimal);
			ADODB.Recordset rsTest = default(ADODB.Recordset);
			int x = 0;
			int y = 0;
			 // ERROR: Not supported in C#: OnErrorStatement


			for (x = 0; x <= Information.UBound(selectTest); x++) {
				if (selectTest[x, 2] == -1) {
					selectTestWeight = selectTestWeight + Convert.ToDecimal(selectTest[x, 3]);

					rsTest = modRecordSet.getRS(ref "SELECT BlockTestItem.BlockTestItem_StockItemID AS StockItemID, BlockTestItem.BlockTestItem_CutWeight From BlockTestItem Where (((BlockTestItem.BlockTestItem_BlockTestID) = " + selectTest[x, 0] + ")) ORDER BY BlockTestItem.BlockTestItem_Line;");
					if (rsTest.RecordCount) {
						while (!(rsTest.EOF)) {
							var _with1 = gridItem;
							for (y = 1; y <= (_with1.RowCount - 1); y++) {
								_with1.row = y;
								if (_with1.get_RowData(y) == rsTest.Fields("StockItemID").Value) {
									_with1.set_TextMatrix(_with1.row, 1, _with1.get_TextMatrix(_with1.row, 1) + rsTest.Fields("BlockTestItem_CutWeight").Value);
									break; // TODO: might not be correct. Was : Exit For
								}
							}
							rsTest.moveNext();
						}
					}
				}
			}

			 // ERROR: Not supported in C#: OnErrorStatement

			var _with2 = gridItem;
			for (y = 1; y <= (_with2.RowCount - 1); y++) {
				_with2.row = y;
				//If .RowData(y) = rsTest("StockItemID") Then
				_with2.set_TextMatrix(_with2.row, 1, Strings.FormatNumber((Convert.ToDouble(_with2.get_TextMatrix(_with2.row, 1)) / selectTestWeight) * Convert.ToDecimal(txtZ.Text), 3));
				//    Exit For
				//End If
			}

			cmdTotal.Visible = true;
			gridItem.Visible = true;
			picTotal.Visible = true;
			cmdLoadNext.Visible = false;

		}

//UPGRADE_NOTE: Form_Initialize was upgraded to Form_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private void Form_Initialize_Renamed()
		{
			//ChDrive App.Path
			//ChDir App.Path
			basCryptoProcs.Initial_settings();
			Reset_frmEncStrings();
		}


		public void makeItem()
		{
			string sql = null;
			int lID = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);

			My.MyProject.Forms.frmBlockTestSelect.loadTest(ref testType, ref testID);
			reType:

			if (testType == "exit") {
				this.Close();
				return;

			} else if (testType == "select") {
				testName = Interaction.InputBox("Please enter short Name/Title for Block Test.", "Please enter short Name/Title for Block Test.");
				if (string.IsNullOrEmpty(testName))
					goto reType;

				lID = My.MyProject.Forms.frmStockList.getItem();
				if (lID != 0) {
					//On Local Error Resume Next
					sql = "INSERT INTO BlockTest ( BlockTest_DayEndID, BlockTest_BlockTestStatusID, BlockTest_Date, BlockTest_MainItemID, BlockTest_PersonID, BlockTest_Desc, BlockTest_PricePerKg, BlockTest_WeightCarcass, BlockTest_RequiredGP, BlockTest_VAT, BlockTest_Notes ) ";
					sql = sql + "SELECT Company.Company_DayEndID, 1 AS status, Now(), " + lID + ", " + My.MyProject.Forms.frmMenu.lblUser.Tag + ", '" + Strings.Left(Strings.Replace(testName, "'", "''"), 49) + "', 0, 0, 0, 0, '' FROM Company;";
					modRecordSet.cnnDB.Execute(sql);
					rs = modRecordSet.getRS(ref "SELECT Max(BlockTestID) AS id FROM BlockTest;");
					testID = rs.Fields("id").Value;

					My.MyProject.Forms.frmBlockTestFilterSelect.loadItem(ref lID, ref selectTest[testType, testID], ref testID);

					loadItem(lID);
				}

			} else if (testType == "new") {
				testName = Interaction.InputBox("Please enter short Name/Title for Block Test.", "Please enter short Name/Title for Block Test.");
				if (string.IsNullOrEmpty(testName))
					goto reType;

				lID = My.MyProject.Forms.frmStockList.getItem();
				if (lID != 0) {
					//On Local Error Resume Next
					sql = "INSERT INTO BlockTest ( BlockTest_DayEndID, BlockTest_BlockTestStatusID, BlockTest_Date, BlockTest_MainItemID, BlockTest_PersonID, BlockTest_Desc, BlockTest_PricePerKg, BlockTest_WeightCarcass, BlockTest_RequiredGP, BlockTest_VAT, BlockTest_Notes ) ";
					sql = sql + "SELECT Company.Company_DayEndID, 1 AS status, Now(), " + lID + ", " + My.MyProject.Forms.frmMenu.lblUser.Tag + ", '" + Strings.Left(Strings.Replace(testName, "'", "''"), 49) + "', 0, 0, 0, 0, '' FROM Company;";
					modRecordSet.cnnDB.Execute(sql);
					rs = modRecordSet.getRS(ref "SELECT Max(BlockTestID) AS id FROM BlockTest;");
					testID = rs.Fields("id").Value;

					loadItem(lID);
				}

			} else if (testType == "load") {
				rs = modRecordSet.getRS(ref "SELECT * FROM BlockTest WHERE BlockTestID = " + testID + ";");
				if (rs.RecordCount) {
					loadItemSAVE(rs.Fields("BlockTest_MainItemID").Value);
					//lID

				} else {
					Interaction.MsgBox("Problem while loading Test");
				}
			}

		}

		private void loadData()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rj = default(ADODB.Recordset);

			 // ERROR: Not supported in C#: OnErrorStatement


			rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + gStockItemID + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));");
			if (rs.RecordCount) {
				//lblStockItem.Caption = rs("StockItem_Name")
				//lblPromotion.Caption = rs("Promotion_Name")
				//txtPrice.Text = rs("CatalogueChannelLnk_Price") * 100
				//txtPrice_LostFocus
				//cmbQuantity.Tag = rs("CatalogueChannelLnk_Quantity")
				lblContentExclusive.Text = My.MyProject.Forms.frmMenu.lblUser.Text;
				getRecItems();

				loadLanguage();

				if (testType == "select") {
					cmdTotal.Visible = false;
					gridItem.Visible = false;
					picTotal.Visible = false;
					cmdLoadNext.Visible = true;
				}

				ShowDialog();
			} else {
				this.Close();
				return;
			}

		}

		public void loadItem(ref int stockitemID, ref int quantity = 0)
		{
			int colQuantity = 0;
			System.Windows.Forms.TextBox oText = null;

			modBResolutions.ResizeForm(ref this, ref sizeConvertors.pixelToTwips(this.Width, true), ref sizeConvertors.pixelToTwips(this.Height, false), ref 2);

			setup();
			frmBlockTest_Resize(this, new System.EventArgs());

			//Serial chk
			if (checkSecurity() == true) {
			} else {
				this.Text = this.Text + " - Trial";
				cmdReg.Visible = true;
			}

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

			gStockItemID = stockitemID;
			gQuantity = quantity;

			ADODB.Recordset rsVat = default(ADODB.Recordset);
			rsVat = modRecordSet.getRS(ref "SELECT Vat.Vat_Amount FROM StockItem INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID WHERE (((StockItem.StockItemID)=" + gStockItemID + "));");
			if (rsVat.RecordCount)
				txtVAT.Text = Strings.FormatNumber(rsVat.Fields("Vat_Amount").Value, 4);

			loadData();

		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Printer.Orientation = Or_Landscape
			//Printer.PaintPicture picForm.Picture, 0, 0 ',  x, y
			//gObject.PaintPicture Picture1.Picture, ((gWidth - x) / 2), 0, x, y
			Picture2.Visible = false;
			cmdTotal.Visible = false;
			this.PrintForm1.Print(this, Microsoft.VisualBasic.PowerPacks.Printing.PrintForm.PrintOption.CompatibleModeClientAreaOnly);

			Picture2.Visible = true;
			cmdTotal.Visible = true;
		}

		private void cmdProc_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (updateProc())
				this.Close();
		}

		private bool updateProc()
		{
			bool functionReturnValue = false;
			string strFldName = null;
			 // ERROR: Not supported in C#: OnErrorStatement


			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rj = default(ADODB.Recordset);
			ADODB.Recordset adoPrimaryRS = default(ADODB.Recordset);
			string sql = null;
			decimal lQuantity = default(decimal);

			rs = modRecordSet.getRS(ref "SELECT * from BlockTestItem Where BlockTestItem_BlockTestID = " + testID + ";");

			if (rs.RecordCount > 0) {
				strFldName = "HandHeldID Number,Handheld_Barcode Text(50), Quantity Currency";
				modRecordSet.cnnDB.Execute("CREATE TABLE " + "HandheldBlockTest" + " (" + strFldName + ")");
				System.Windows.Forms.Application.DoEvents();
				sql = "INSERT INTO HandheldBlockTest (HandHeldID,Handheld_Barcode,Quantity) VALUES (" + gStockItemID + ", 0, " + (0 - Convert.ToDecimal(txtZ.Text)) + ")";
				modRecordSet.cnnDB.Execute(sql);
				System.Windows.Forms.Application.DoEvents();

				while (rs.EOF == false) {
					sql = "INSERT INTO HandheldBlockTest (HandHeldID,Handheld_Barcode,Quantity) VALUES (" + rs.Fields("BlockTestItem_StockItemID").Value + ", 0, " + (rs.Fields("BlockTestItem_CutWeight")).Value + ")";
					modRecordSet.cnnDB.Execute(sql);
					rs.moveNext();
				}

			} else {
				Interaction.MsgBox("This Product does not have any Recipe.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				functionReturnValue = false;
				return functionReturnValue;
			}
			modRecordSet.cnnDB.Execute("INSERT INTO StockGroup (StockGroup_Name) VALUES ('HandheldBlockTest')");
			modApplication.stTableName = "HandheldBlockTest";
			rj = modRecordSet.getRS(ref "SELECT StockGroup.StockGroupID, StockGroup.StockGroup_Name From StockGroup WHERE StockGroup.StockGroup_Name = 'HandheldBlockTest';");
			gID = rj.Fields("StockGroupID").Value;

			//snap shot
			modRecordSet.cnnDB.Execute("UPDATE Company SET Company.Company_StockTakeDate = now();");
			modRecordSet.cnnDB.Execute("DELETE FROM StockTake WHERE (StockTake_WarehouseID = 2)");
			modRecordSet.cnnDB.Execute("INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment ) SELECT StockItem.StockItemID, 2 AS warehouse, 0 AS quantity, 0 AS adjustment FROM StockItem;");
			modRecordSet.cnnDB.Execute("UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));");
			modRecordSet.cnnDB.Execute("DELETE FROM StockTakeDeposit");
			modRecordSet.cnnDB.Execute("INSERT INTO StockTakeDeposit ( StockTakeDeposit_WarehouseID, StockTakeDeposit_DepositID, StockTakeDeposit_DepositTypeID, StockTakeDeposit_Quantity, StockTakeDeposit_Adjustment ) SELECT WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity FROM WarehouseDepositItemLnk INNER JOIN DISPLAY_Deposits ON (DISPLAY_Deposits.type = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = DISPLAY_Deposits.DepositID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID = DISPLAY_Deposits.WarehouseID);");
			//snap shot

			//Set adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, " & stTableName & ".Quantity, StockItem.StockItem_Quantity," & stTableName & ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" & stTableName & " INNER JOIN StockItem ON " & stTableName & ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " & gID & ") And ((Warehouse.WarehouseID) = 2) And ((StockItem.StockItem_Disabled) = False) And ((StockItem.StockItem_Discontinued) = False)) ORDER BY StockItem.StockItem_Name")
			adoPrimaryRS = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, " + modApplication.stTableName + ".Quantity, StockItem.StockItem_Quantity," + modApplication.stTableName + ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" + modApplication.stTableName + " INNER JOIN StockItem ON " + modApplication.stTableName + ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " + gID + ") And ((Warehouse.WarehouseID) = 2)) ORDER BY StockItem.StockItem_Name");
			if (adoPrimaryRS.RecordCount > 0) {
				while (adoPrimaryRS.EOF == false) {
					lQuantity = adoPrimaryRS.Fields("Quantity").Value;
					//lQuantity = adoPrimaryRS("Quantity") - adoPrimaryRS("StockTake_Quantity").OriginalValue
					modRecordSet.cnnDB.Execute("UPDATE StockTake SET StockTake.StockTake_Quantity = " + lQuantity + " WHERE (((StockTake.StockTake_StockItemID)=" + adoPrimaryRS.Fields("StockTake_StockItemID").Value + ") AND ((StockTake.StockTake_WarehouseID)=2));");
					modRecordSet.cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" + lQuantity + ") WHERE (((StockTake.StockTake_StockItemID)=" + adoPrimaryRS.Fields("StockTake_StockItemID").Value + ") AND ((StockTake.StockTake_WarehouseID)=2));");
					//cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = 0 WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
					modRecordSet.cnnDB.Execute("UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" + lQuantity + ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" + adoPrimaryRS.Fields("StockTake_StockItemID").Value + "));");
					adoPrimaryRS.moveNext();
				}
			}

			modRecordSet.cnnDB.Execute("DROP TABLE HandheldBlockTest");
			modRecordSet.cnnDB.Execute("DELETE * FROM StockGroup WHERE StockGroup_Name ='HandheldBlockTest'");

			modRecordSet.cnnDB.Execute("UPDATE BlockTest SET BlockTest_BlockTestStatusID = 3 WHERE (BlockTestID = " + testID + ")");
			Interaction.MsgBox("Block Test process has been completed.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);

			functionReturnValue = true;
			return functionReturnValue;
			UpdateErr:

			Interaction.MsgBox(Err().Description);
			functionReturnValue = true;
			return functionReturnValue;
		}

		private void updatePrice()
		{
			modRecordSet.cnnDB.Execute("UPDATE BlockTestItem INNER JOIN CatalogueChannelLnk ON BlockTestItem.BlockTestItem_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Price = BlockTestItem.BlockTestItem_MRelatedSellPrice WHERE (((BlockTestItem.BlockTestItem_BlockTestID)=" + testID + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=2));");
			modRecordSet.cnnDB.Execute("UPDATE BlockTestItem INNER JOIN CatalogueChannelLnk ON BlockTestItem.BlockTestItem_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Price = BlockTestItem.BlockTestItem_ActualSellPriceIncl WHERE (((BlockTestItem.BlockTestItem_BlockTestID)=" + testID + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));");
		}

		private void cmdReg_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (My.MyProject.Forms.frmBlockTestCode.setupCode() == true) {
				this.Text = Strings.Left(this.Text, Strings.Len(this.Text) - Strings.Len(" - Trial"));
				cmdReg.Visible = false;
			}
		}

		private void cmdTotal_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			decimal QtyD_P = default(decimal);
			int x = 0;
			 // ERROR: Not supported in C#: OnErrorStatement


			//Serial chk

			if (checkSecurity() == true) {
			} else {
				if (timeOver()) {
					Interaction.MsgBox("Your 4MEAT Software has expired." + Constants.vbCrLf + "Please contact your 4POS representative or www.4pos.co.za.", MsgBoxStyle.Critical, "4MEAT is not Registered");
					return;
				}
			}

			cmdTotal.Enabled = false;
			//update BlockTest master
			modRecordSet.cnnDB.Execute("UPDATE BlockTest SET BlockTest_PricePerKg = " + Strings.FormatNumber(Convert.ToDecimal(txtR.Text), 4) + ", BlockTest_WeightCarcass = " + Strings.FormatNumber(Convert.ToDecimal(txtZ.Text), 4) + ", BlockTest_RequiredGP = " + Strings.FormatNumber(Convert.ToDecimal(txtReqGP.Text), 2) + ", BlockTest_VAT = " + Strings.FormatNumber(Convert.ToDecimal(txtVAT.Text), 4) + " WHERE (BlockTestID = " + testID + ")");


			lblA.Text = Strings.FormatNumber(Convert.ToDecimal(txtR.Text) * Convert.ToDecimal(txtZ.Text), 4);


			lblGP_Y.Text = Strings.FormatNumber(Convert.ToDecimal(1 - (Convert.ToDecimal(Convert.ToDouble(txtReqGP.Text) / 100))), 4);

			var _with3 = gridItem;
			for (x = 1; x <= (_with3.RowCount - 1); x++) {
				_with3.row = x;
				_with3.Col = 2;
				modRecordSet.cnnDB.Execute("UPDATE BlockTestItem SET BlockTestItem_MRelatedSellPrice = " + Strings.FormatNumber(Convert.ToDecimal(_with3.Text), 2) + " WHERE ((BlockTestItem_BlockTestID = " + testID + ") AND (BlockTestItem_StockItemID = " + _with3.get_RowData(x) + ") AND (BlockTestItem_Line = " + x + "));");
			}

			var _with4 = gridItem;
			for (x = 1; x <= (_with4.RowCount - 1); x++) {
				_with4.row = x;
				_with4.Col = 11;
				modRecordSet.cnnDB.Execute("UPDATE BlockTestItem SET BlockTestItem_ActualSellPriceIncl = " + Strings.FormatNumber(Convert.ToDecimal(_with4.Text), 2) + " WHERE ((BlockTestItem_BlockTestID = " + testID + ") AND (BlockTestItem_StockItemID = " + _with4.get_RowData(x) + ") AND (BlockTestItem_Line = " + x + "));");
			}

			var _with5 = gridItem;
			for (x = 1; x <= (_with5.RowCount - 1); x++) {
				_with5.row = x;
				_with5.Col = 1;
				QtyD_P = QtyD_P + Convert.ToDecimal(_with5.Text);
				//.TextMatrix(.row, 1) = FormatNumber(CCur(_txtEdit_1.Text) / 100, 4)
				modRecordSet.cnnDB.Execute("UPDATE BlockTestItem SET BlockTestItem_CutWeight = " + Strings.FormatNumber(Convert.ToDecimal(_with5.Text), 3) + " WHERE ((BlockTestItem_BlockTestID = " + testID + ") AND (BlockTestItem_StockItemID = " + _with5.get_RowData(x) + ") AND (BlockTestItem_Line = " + x + "));");
			}
			lblP.Text = Strings.FormatNumber(QtyD_P, 4);


			lblB.Text = Strings.FormatNumber(Convert.ToDecimal(txtZ.Text) - Convert.ToDecimal(lblP.Text), 4);


			lblC.Text = Strings.FormatNumber(Convert.ToDecimal(lblA.Text) / Convert.ToDecimal(lblP.Text), 4);


			lblB_Z.Text = Strings.FormatNumber(Convert.ToDecimal(lblB.Text) / Convert.ToDecimal(txtZ.Text), 4);


			lblX.Text = Strings.FormatNumber(Convert.ToDecimal(Convert.ToDecimal(Convert.ToDouble(txtVAT.Text) / 100) + 1), 4);


			var _with6 = gridItem;
			for (x = 1; x <= (_with6.RowCount - 1); x++) {
				_with6.row = x;
				_with6.Col = 1;
				_with6.set_TextMatrix(_with6.row, 3, Strings.FormatNumber((Convert.ToDecimal(_with6.Text) / Convert.ToDecimal(txtZ.Text)) * 100, 4));
				//.Col = 3
				//QtyD_P = QtyD_P + CCur(.Text)
			}
			QtyD_P = 0;
			var _with7 = gridItem;
			for (x = 1; x <= (_with7.RowCount - 1); x++) {
				_with7.row = x;
				_with7.Col = 3;
				QtyD_P = QtyD_P + Convert.ToDecimal(_with7.Text);
				//cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_PerWeightYield = " & FormatNumber(CCur(.Text), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
				modRecordSet.cnnDB.Execute("UPDATE BlockTestItem SET BlockTestItem_PerWeightYield = " + Convert.ToDecimal(_with7.Text) + " WHERE ((BlockTestItem_BlockTestID = " + testID + ") AND (BlockTestItem_StockItemID = " + _with7.get_RowData(x) + ") AND (BlockTestItem_Line = " + x + "));");
			}
			lblTotalF.Text = Strings.FormatNumber(QtyD_P, 4);
			//total req


			decimal D_E = default(decimal);
			var _with8 = gridItem;
			for (x = 1; x <= (_with8.RowCount - 1); x++) {
				_with8.row = x;
				_with8.Col = 1;
				D_E = Convert.ToDecimal(_with8.Text);
				_with8.Col = 2;
				D_E = D_E * Convert.ToDecimal(_with8.Text);
				_with8.set_TextMatrix(_with8.row, 6, Strings.FormatNumber(D_E, 4));
			}
			QtyD_P = 0;
			var _with9 = gridItem;
			for (x = 1; x <= (_with9.RowCount - 1); x++) {
				_with9.row = x;
				_with9.Col = 6;
				QtyD_P = QtyD_P + Convert.ToDecimal(_with9.Text);
				//QtyD_P = FormatNumber(CCur(.Text), 4)
				//cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_MRelatedTO = " & FormatNumber(CCur(.Text), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
				modRecordSet.cnnDB.Execute("UPDATE BlockTestItem SET BlockTestItem_MRelatedTO = " + Convert.ToDecimal(_with9.Text) + " WHERE ((BlockTestItem_BlockTestID = " + testID + ") AND (BlockTestItem_StockItemID = " + _with9.get_RowData(x) + ") AND (BlockTestItem_Line = " + x + "));");
			}
			lblTotalQ.Text = Strings.FormatNumber(QtyD_P, 4);
			//total req


			decimal S_A_Q = default(decimal);
			S_A_Q = Convert.ToDecimal(Strings.FormatNumber(Convert.ToDecimal(lblA.Text) / Convert.ToDecimal(lblTotalQ.Text), 4));


			var _with10 = gridItem;
			for (x = 1; x <= (_with10.RowCount - 1); x++) {
				_with10.row = x;
				_with10.Col = 2;
				//.TextMatrix(.row, 4) = FormatNumber((CCur(.Text) / CCur(lblC.Caption)) * CCur(lblGP_Y.Caption), 4)
				_with10.set_TextMatrix(_with10.row, 4, Strings.FormatNumber((Convert.ToDecimal(_with10.Text) / Convert.ToDecimal(lblC.Text)) * Convert.ToDecimal(S_A_Q), 4));
			}
			QtyD_P = 0;
			var _with11 = gridItem;
			for (x = 1; x <= (_with11.RowCount - 1); x++) {
				_with11.row = x;
				_with11.Col = 4;
				QtyD_P = QtyD_P + Convert.ToDecimal(_with11.Text);
				//cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_MRSellingratio = " & FormatNumber(CCur(.Text), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
				modRecordSet.cnnDB.Execute("UPDATE BlockTestItem SET BlockTestItem_MRSellingratio = " + Convert.ToDecimal(_with11.Text) + " WHERE ((BlockTestItem_BlockTestID = " + testID + ") AND (BlockTestItem_StockItemID = " + _with11.get_RowData(x) + ") AND (BlockTestItem_Line = " + x + "));");
			}
			lblTotalG.Text = Strings.FormatNumber(QtyD_P, 4);
			//total req


			var _with12 = gridItem;
			for (x = 1; x <= (_with12.RowCount - 1); x++) {
				_with12.row = x;
				_with12.Col = 4;
				_with12.set_TextMatrix(_with12.row, 7, Strings.FormatNumber(Convert.ToDecimal(lblC.Text) * Convert.ToDecimal(_with12.Text), 4));
				//cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_PrimalCostkgExclVAT = " & FormatNumber(CCur(lblC.Caption) * CCur(.Text), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
				modRecordSet.cnnDB.Execute("UPDATE BlockTestItem SET BlockTestItem_PrimalCostkgExclVAT = " + (Convert.ToDecimal(lblC.Text) * Convert.ToDecimal(_with12.Text)) + " WHERE ((BlockTestItem_BlockTestID = " + testID + ") AND (BlockTestItem_StockItemID = " + _with12.get_RowData(x) + ") AND (BlockTestItem_Line = " + x + "));");
			}


			decimal J_D = default(decimal);
			var _with13 = gridItem;
			for (x = 1; x <= (_with13.RowCount - 1); x++) {
				_with13.row = x;
				_with13.Col = 7;
				J_D = Convert.ToDecimal(_with13.Text);
				_with13.Col = 1;
				J_D = J_D * Convert.ToDecimal(_with13.Text);
				_with13.set_TextMatrix(_with13.row, 5, Strings.FormatNumber(J_D, 4));
			}
			QtyD_P = 0;
			var _with14 = gridItem;
			for (x = 1; x <= (_with14.RowCount - 1); x++) {
				_with14.row = x;
				_with14.Col = 5;
				QtyD_P = QtyD_P + Convert.ToDecimal(_with14.Text);
				//cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_CostkgTO = " & FormatNumber(CCur(.Text), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
				modRecordSet.cnnDB.Execute("UPDATE BlockTestItem SET BlockTestItem_CostkgTO = " + Convert.ToDecimal(_with14.Text) + " WHERE ((BlockTestItem_BlockTestID = " + testID + ") AND (BlockTestItem_StockItemID = " + _with14.get_RowData(x) + ") AND (BlockTestItem_Line = " + x + "));");
			}
			lblTotalH.Text = Strings.FormatNumber(QtyD_P, 4);
			//total req


			var _with15 = gridItem;
			for (x = 1; x <= (_with15.RowCount - 1); x++) {
				_with15.row = x;
				_with15.Col = 7;
				_with15.set_TextMatrix(_with15.row, 8, Strings.FormatNumber(Convert.ToDecimal(_with15.Text) / Convert.ToDecimal(lblGP_Y.Text), 4));
				//cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_SuggSellPriceExcl = " & FormatNumber(CCur(.Text) / CCur(lblGP_Y.Caption), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
				modRecordSet.cnnDB.Execute("UPDATE BlockTestItem SET BlockTestItem_SuggSellPriceExcl = " + (Convert.ToDecimal(_with15.Text) / Convert.ToDecimal(lblGP_Y.Text)) + " WHERE ((BlockTestItem_BlockTestID = " + testID + ") AND (BlockTestItem_StockItemID = " + _with15.get_RowData(x) + ") AND (BlockTestItem_Line = " + x + "));");
			}


			decimal K_D = default(decimal);
			var _with16 = gridItem;
			for (x = 1; x <= (_with16.RowCount - 1); x++) {
				_with16.row = x;
				_with16.Col = 8;
				K_D = Convert.ToDecimal(_with16.Text);
				_with16.Col = 1;
				K_D = K_D * Convert.ToDecimal(_with16.Text);
				_with16.set_TextMatrix(_with16.row, 9, Strings.FormatNumber(K_D, 4));
			}
			QtyD_P = 0;
			var _with17 = gridItem;
			for (x = 1; x <= (_with17.RowCount - 1); x++) {
				_with17.row = x;
				_with17.Col = 9;
				QtyD_P = QtyD_P + Convert.ToDecimal(_with17.Text);
				//cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_TOSuggSellPriceExcl = " & FormatNumber(CCur(.Text), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
				modRecordSet.cnnDB.Execute("UPDATE BlockTestItem SET BlockTestItem_TOSuggSellPriceExcl = " + Convert.ToDecimal(_with17.Text) + " WHERE ((BlockTestItem_BlockTestID = " + testID + ") AND (BlockTestItem_StockItemID = " + _with17.get_RowData(x) + ") AND (BlockTestItem_Line = " + x + "));");
			}
			lblTotalL.Text = Strings.FormatNumber(QtyD_P, 4);
			lblTotalLP.Text = Strings.FormatNumber(((Convert.ToDecimal(lblTotalH.Text) - QtyD_P) / QtyD_P) * 100, 4);
			if (Convert.ToDecimal(lblTotalLP.Text) < 0)
				lblTotalLP.Text = Convert.ToString(0 - Convert.ToDecimal(lblTotalLP.Text));
			//total req


			var _with18 = gridItem;
			for (x = 1; x <= (_with18.RowCount - 1); x++) {
				_with18.row = x;
				_with18.Col = 8;
				_with18.set_TextMatrix(_with18.row, 10, Strings.FormatNumber(Convert.ToDecimal(_with18.Text) * Convert.ToDecimal(lblX.Text), 4));
				//cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_SuggSellPriceIncl = " & FormatNumber(CCur(.Text) * CCur(lblX.Caption), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
				modRecordSet.cnnDB.Execute("UPDATE BlockTestItem SET BlockTestItem_SuggSellPriceIncl = " + (Convert.ToDecimal(_with18.Text) * Convert.ToDecimal(lblX.Text)) + " WHERE ((BlockTestItem_BlockTestID = " + testID + ") AND (BlockTestItem_StockItemID = " + _with18.get_RowData(x) + ") AND (BlockTestItem_Line = " + x + "));");
			}


			decimal N_X_D = default(decimal);
			var _with19 = gridItem;
			for (x = 1; x <= (_with19.RowCount - 1); x++) {
				_with19.row = x;
				_with19.Col = 11;
				N_X_D = (Convert.ToDecimal(_with19.Text) / Convert.ToDecimal(lblX.Text));
				_with19.Col = 1;
				N_X_D = N_X_D * Convert.ToDecimal(_with19.Text);
				_with19.set_TextMatrix(_with19.row, 12, Strings.FormatNumber(N_X_D, 4));
			}
			QtyD_P = 0;
			var _with20 = gridItem;
			for (x = 1; x <= (_with20.RowCount - 1); x++) {
				_with20.row = x;
				_with20.Col = 12;
				QtyD_P = QtyD_P + Convert.ToDecimal(_with20.Text);
				//cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_TOActualSellExcl = " & FormatNumber(CCur(.Text), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
				modRecordSet.cnnDB.Execute("UPDATE BlockTestItem SET BlockTestItem_TOActualSellExcl = " + Convert.ToDecimal(_with20.Text) + " WHERE ((BlockTestItem_BlockTestID = " + testID + ") AND (BlockTestItem_StockItemID = " + _with20.get_RowData(x) + ") AND (BlockTestItem_Line = " + x + "));");
			}
			lblTotalO.Text = Strings.FormatNumber(QtyD_P, 4);
			lblTotalOP.Text = Strings.FormatNumber(((Convert.ToDecimal(lblTotalH.Text) - QtyD_P) / QtyD_P) * 100, 4);
			if (Convert.ToDecimal(lblTotalOP.Text) < 0)
				lblTotalOP.Text = Convert.ToString(0 - Convert.ToDecimal(lblTotalOP.Text));
			//total req

			cmdTotal.Enabled = true;
			//temporary


		}

		private void frmBlockTest_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (mbEditFlag | mbAddNewFlag)
				goto EventExitSub;

			switch (KeyAscii) {
				case System.Windows.Forms.Keys.Escape:
					KeyAscii = 0;
					cmdExit.Focus();
					System.Windows.Forms.Application.DoEvents();
					cmdExit_Click(cmdExit, new System.EventArgs());
					break;
			}
			EventExitSub:
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmBlockTest_Load(object sender, System.EventArgs e)
		{
			txtEdit.AddRange(new TextBox[] {
				_txtEdit_0,
				_txtEdit_1,
				_txtEdit_2
			});
			TextBox te = new TextBox();
			foreach (TextBox te_loopVariable in txtEdit) {
				te = te_loopVariable;
				te.TextChanged += txtEdit_TextChanged;
				te.Enter += txtEdit_Enter;
				te.KeyDown += txtEdit_KeyDown;
				te.KeyPress += txtEdit_KeyPress;
				te.Leave += txtEdit_Leave;
			}
		}

		private void frmBlockTest_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			short x = 0;
			short lWidth = 0;
			int lTop = 0;
			lTop = 420;
			if (lblContentExclusive.Visible) {
				lblContentExclusive.Top = sizeConvertors.twipsToPixels(lTop, false);
				_lblTotal_0.Top = sizeConvertors.twipsToPixels(lTop, false);
				lTop = lTop + sizeConvertors.pixelToTwips(lblContentExclusive.Height, false) + 30;
			}
			if (txtR.Visible) {
				txtR.Top = sizeConvertors.twipsToPixels(lTop, false);
				_lblTotal_1.Top = sizeConvertors.twipsToPixels(lTop, false);
				lTop = lTop + sizeConvertors.pixelToTwips(txtR.Height, false) + 30;
			}
			if (txtZ.Visible) {
				txtZ.Top = sizeConvertors.twipsToPixels(lTop, false);
				_lblTotal_2.Top = sizeConvertors.twipsToPixels(lTop, false);
				lTop = lTop + sizeConvertors.pixelToTwips(txtZ.Height, false) + 30;
			}
			if (lblA.Visible) {
				lblA.Top = sizeConvertors.twipsToPixels(lTop, false);
				_lblTotal_3.Top = sizeConvertors.twipsToPixels(lTop, false);
				lTop = lTop + sizeConvertors.pixelToTwips(lblA.Height, false) + 30;
			}
			if (lblB.Visible) {
				lblB.Top = sizeConvertors.twipsToPixels(lTop, false);
				_lblTotal_4.Top = sizeConvertors.twipsToPixels(lTop, false);
				lTop = lTop + sizeConvertors.pixelToTwips(lblB.Height, false) + 30;
			}
			if (lblC.Visible) {
				lblC.Top = sizeConvertors.twipsToPixels(lTop, false);
				_lblTotal_5.Top = sizeConvertors.twipsToPixels(lTop, false);
				lTop = lTop + sizeConvertors.pixelToTwips(lblC.Height, false) + 30;
			}
			frmTotals.Height = sizeConvertors.twipsToPixels(lTop + 30, false);

			//frmTotals.Top = ScaleHeight - frmTotals.Height
			//frmTotals.Left = ScaleWidth - frmTotals.Width
			//lblReturns.Top = frmTotals.Top + (frmTotals.Height - lblReturns.Height) / 2
			//lblReturns.Left = frmTotals.Left - lblReturns.Width - 100
			//lblReturns.Visible = orderType
			//lstWorkspace.Height = ScaleHeight - lstWorkspace.Top

			//picForm.Top = 800
			//picForm.Left = 40
			//picForm.Height = ScaleHeight - picForm.Top '- frmTotals.Height
			//picForm.Width = ScaleWidth - picForm.Left

			//gridItem.Height = ScaleHeight - gridItem.Top - frmTotals.Height
			//gridItem.Height = picForm.ScaleHeight - gridItem.Top - frmTotals.Height
			gridItem.Width = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(ClientRectangle.Width, true) - sizeConvertors.pixelToTwips(gridItem.Left, true), true);
			//gridItem.Width = picForm.ScaleWidth - gridItem.Left

			lWidth = sizeConvertors.pixelToTwips(gridItem.Width, true) - 450;
			for (x = 0; x <= gridItem.Col - 1; x++) {
				lWidth = lWidth - gridItem.get_ColWidth(ref x);
			}
			lWidth = lWidth + gridItem.get_ColWidth(ref 0);
			if (lWidth > 200) {
				gridItem.set_ColWidth(ref 0, ref lWidth);
			} else {
				gridItem.set_ColWidth(ref 0, ref 2000);
			}
			//gridItem_EnterCell
			if (gridItem.RowCount > 1) {
				//gridItem.Height = (gridItem.RowCount * gridItem.RowHeight(1)) + (gridItem.RowHeight(0) - 100)   ' ScaleHeight - gridItem.Top - frmTotals.Height
			}
			gridItem.Top = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(gridItem.Top, false) + 20, false);
			picTotal.Top = sizeConvertors.twipsToPixels((sizeConvertors.pixelToTwips(ClientRectangle.Height, false) - sizeConvertors.pixelToTwips(picTotal.Height, false)) - 100, false);
			//gridItem.Top + gridItem.Height  '+ 20
			gridItem.Height = sizeConvertors.twipsToPixels((sizeConvertors.pixelToTwips(picTotal.Top, false) - 60) - sizeConvertors.pixelToTwips(gridItem.Top, false), false);
			//(gridItem.Top - frmTotals.Height)
			picTotal.Left = gridItem.Left;
		}

		private void setup()
		{
			int colFractions = 0;
			int colDepositTotalInclusive = 0;
			int colDepositTotalExclusive = 0;
			int colDepositInclusive = 0;
			int colDepositExclusive = 0;
			int colContentTotalInclusive = 0;
			int colContentTotalExclusive = 0;
			int colContentInclusive = 0;
			int colPrice = 0;
			int colContentExclusive = 0;
			int colPackSize = 0;
			int colQuantity = 0;
			loading = true;
			//    Dim lDOM As DOMDocument
			//    Dim lNode As IXMLDOMNode
			//    Dim lNodeList As IXMLDOMNodeList
			//lblSupplier.Caption = frmGRV.adoPrimaryRS("Supplier_Name") & "(" & frmGRV.adoPrimaryRS("PurchaseOrder_Reference") & ")"
			//lblReturns.Visible = orderType

			var _with21 = gridItem;
			gridItem.RowCount = 1;
			gridItem.row = 0;

			gridItem.Col = 13;

			gridItem.set_RowHeight(ref ref 0, ref ref 650);
			//430
			gridItem.Col = 1;
			//colTotalExclusive
			//gridItem.CellFontBold = True
			gridItem.set_TextMatrix(ref ref 0, ref ref 1, ref ref "Cut Weight");
			gridItem.set_colAlignment(ref ref 1, ref ref 7);
			gridItem.set_ColWidth(ref ref 1, ref ref 1000);

			gridItem.Col = 2;
			//colTotalInclusive
			//gridItem.CellFontBold = True
			gridItem.set_TextMatrix(ref ref 0, ref ref 2, ref ref "M Related Selling Prices");
			gridItem.set_colAlignment(ref ref 2, ref ref 7);
			gridItem.set_ColWidth(ref ref 2, ref ref 1000);

			gridItem.Col = 3;
			//colExclusive
			//gridItem.CellFontBold = True
			gridItem.set_TextMatrix(ref ref 0, ref ref 3, ref ref "% of Weight (Yield)");
			gridItem.set_colAlignment(ref ref 3, ref ref 7);
			gridItem.set_ColWidth(ref ref 3, ref ref 1000);

			gridItem.Col = 4;
			//colInclusive
			//gridItem.CellFontBold = True
			gridItem.set_TextMatrix(ref ref 0, ref ref 4, ref ref "MR Selling ratio to R/kg");
			gridItem.set_colAlignment(ref ref 4, ref ref 7);
			gridItem.set_ColWidth(ref ref 4, ref ref 1000);


			gridItem.Col = 5;
			//colVAT
			//gridItem.CellFontBold = True
			gridItem.set_TextMatrix(ref ref 0, ref ref 5, ref ref "Cost x kg TO");
			gridItem.set_colAlignment(ref ref 5, ref ref 7);
			gridItem.set_ColWidth(ref ref 5, ref ref 1000);

			gridItem.Col = 6;
			//colCode
			//gridItem.CellFontBold = True
			gridItem.set_TextMatrix(ref ref 0, ref ref 6, ref ref "M Related TO");
			gridItem.set_colAlignment(ref ref 6, ref ref 7);
			gridItem.set_ColWidth(ref ref 6, ref ref 1000);

			gridItem.Col = 7;
			//colName
			//gridItem.CellFontBold = True
			gridItem.set_TextMatrix(ref ref 0, ref ref 7, ref ref "Primal Cost /kg Excl VAT");
			gridItem.set_colAlignment(ref ref 7, ref ref 7);
			gridItem.set_ColWidth(ref ref 7, ref ref 1000);

			gridItem.Col = 8;
			//colBrokenPack
			//gridItem.CellFontBold = True
			gridItem.set_TextMatrix(ref ref 0, ref ref 8, ref ref "Suggested Selling Prices Excl VAT");
			gridItem.set_colAlignment(ref ref 8, ref ref 7);
			gridItem.set_ColWidth(ref ref 8, ref ref 1000);

			gridItem.Col = 9;
			//colDiscount
			//gridItem.CellFontBold = True
			gridItem.set_TextMatrix(ref ref 0, ref ref 9, ref ref "TO Suggested Selling Prices Excl VAT");
			gridItem.set_colAlignment(ref ref 9, ref ref 7);
			gridItem.set_ColWidth(ref ref 9, ref ref 1000);

			gridItem.Col = 10;
			//colDiscountLine
			//gridItem.CellFontBold = True
			gridItem.set_TextMatrix(ref ref 0, ref ref 10, ref ref "Suggested Selling Prices Incl VAT");
			gridItem.set_colAlignment(ref ref 10, ref ref 7);
			gridItem.set_ColWidth(ref ref 10, ref ref 1000);

			gridItem.Col = 11;
			//colDiscountPercentage
			//gridItem.CellFontBold = True
			gridItem.set_TextMatrix(ref ref 0, ref ref 11, ref ref "Actual Selling Prices Incl VAT");
			gridItem.set_colAlignment(ref ref 11, ref ref 7);
			gridItem.set_ColWidth(ref ref 11, ref ref 1000);

			gridItem.Col = 12;
			//colOnOrder
			//gridItem.CellFontBold = True
			gridItem.set_TextMatrix(ref ref 0, ref ref 12, ref ref "TO at Actual Selling Excl VAT");
			gridItem.set_colAlignment(ref ref 12, ref ref 7);
			gridItem.set_ColWidth(ref ref 12, ref ref 1000);

			gridItem.Col = colQuantity;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colQuantity, ref ref "QTY");
			gridItem.set_colAlignment(ref ref colQuantity, ref ref 7);
			gridItem.set_ColWidth(ref ref colQuantity, ref ref 1000);

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
			gridItem.set_TextMatrix(ref ref 0, ref ref colDepositTotalExclusive, ref ref "Total Dep Excl");
			gridItem.set_colAlignment(ref ref colDepositTotalExclusive, ref ref 7);
			gridItem.set_ColWidth(ref ref colDepositTotalExclusive, ref ref 900);

			gridItem.Col = colDepositTotalInclusive;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colDepositTotalInclusive, ref ref "Total Dep Incl");
			gridItem.set_colAlignment(ref ref colDepositTotalInclusive, ref ref 7);
			gridItem.set_ColWidth(ref ref colDepositTotalInclusive, ref ref 900);

			gridItem.Col = colFractions;
			gridItem.CellFontBold = true;
			gridItem.set_TextMatrix(ref ref 0, ref ref colFractions, ref ref "");
			gridItem.set_colAlignment(ref ref colFractions, ref ref 7);
			gridItem.set_ColWidth(ref ref colFractions, ref ref 1);

			loading = false;
		}

		private void getRecItems(ref bool retInfo = false)
		{
			int colQuantity = 0;
			int colPosPrice = 0;
			int colChannelPrice = 0;
			int colName = 0;
			int colTotalInclusive = 0;
			int colTotalExclusive = 0;
			int colInclusive = 0;
			int colExclusive = 0;
			int colOnOrder = 0;
			int colDiscountPercentage = 0;
			int colDiscountLine = 0;
			int colDiscount = 0;
			int colContentTotalInclusive = 0;
			int colContentTotalExclusive = 0;
			int colDepositTotalInclusive = 0;
			int colDepositTotalExclusive = 0;
			int colDepositInclusive = 0;
			int colDepositExclusive = 0;
			int colContentInclusive = 0;
			int colContentExclusive = 0;
			int colPackSize = 0;
			int colFractions = 0;
			string sql = null;
			string gGRVFieldOrder = "";
			string gFieldOrder = "";
			ADODB.Recordset rs = default(ADODB.Recordset);
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

			if (retInfo == true) {
				rs = modRecordSet.getRS(ref "SELECT BlockTestItem.BlockTestItem_StockItemID AS StockItemID, BlockTestItem.BlockTestItem_Name AS StockItem_Name, BlockTestItem.BlockTestItem_MRelatedSellPrice AS CatalogueChannelLnk_Price, BlockTestItem.BlockTestItem_ActualSellPriceIncl AS POSCatalogueChannelLnk_Price, BlockTestItem.BlockTestItem_CutWeight, BlockTestItem.BlockTestItem_PerWeightYield, BlockTestItem.BlockTestItem_MRSellingratio, BlockTestItem.BlockTestItem_CostkgTO, BlockTestItem.BlockTestItem_MRelatedTO, BlockTestItem.BlockTestItem_PrimalCostkgExclVAT, BlockTestItem.BlockTestItem_SuggSellPriceExcl, BlockTestItem.BlockTestItem_TOSuggSellPriceExcl, BlockTestItem.BlockTestItem_SuggSellPriceIncl, BlockTestItem.BlockTestItem_TOActualSellExcl From BlockTestItem Where (((BlockTestItem.BlockTestItem_BlockTestID) = " + testID + ")) ORDER BY BlockTestItem.BlockTestItem_Line;");
			} else {
				//Set rs = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price, POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price, POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID, * FROM ((StockItem INNER JOIN RecipeStockitemLnk ON StockItem.StockItemID = RecipeStockitemLnk.RecipeStockitemLnk_StockitemID) INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) INNER JOIN POSCatalogueChannelLnk ON StockItem.StockItemID = POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID WHERE (((RecipeStockitemLnk.RecipeStockitemLnk_RecipeID)=" & gStockItemID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=2) AND ((POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID)=1) AND ((StockItem.StockItem_Disabled)=0) AND ((StockItem.StockItem_Discontinued)=0));")
				rs = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk_1.CatalogueChannelLnk_Price AS POSCatalogueChannelLnk_Price, CatalogueChannelLnk_1.CatalogueChannelLnk_ChannelID, * FROM ((StockItem INNER JOIN RecipeStockitemLnk ON StockItem.StockItemID = RecipeStockitemLnk.RecipeStockitemLnk_StockitemID) INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) INNER JOIN CatalogueChannelLnk AS CatalogueChannelLnk_1 ON StockItem.StockItemID = CatalogueChannelLnk_1.CatalogueChannelLnk_StockItemID WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=2) AND ((CatalogueChannelLnk_1.CatalogueChannelLnk_ChannelID)=1) AND ((RecipeStockitemLnk.RecipeStockitemLnk_RecipeID)=" + gStockItemID + ") AND ((StockItem.StockItem_Disabled)=0) AND ((StockItem.StockItem_Discontinued)=0));");
			}


			if (rs.RecordCount > 0) {
			} else {
				Interaction.MsgBox("This Product does not have any Recipe.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				return;
			}

			loading = true;
			var _with22 = gridItem;
			_with22.Visible = false;
			//            xsl:Sort select="" data-type="text" order="asending"
			_with22.RowCount = rs.RecordCount + 1;
			//ReDim StockItemLineID(Rows)
			x = 0;
			while (!(rs.EOF)) {
				x = x + 1;
				_with22.row = x;
				_with22.set_RowData(x, rs.Fields("StockItemID").Value);
				//StockItemLineID(x) = rs("StockItemID")


				if (retInfo == true) {
				} else {
					sql = "INSERT INTO BlockTestItem ( BlockTestItem_BlockTestID, BlockTestItem_StockItemID, BlockTestItem_Name, BlockTestItem_MRelatedSellPrice, BlockTestItem_ActualSellPriceIncl, BlockTestItem_Line ) ";
					sql = sql + "SELECT " + testID + ", " + rs.Fields("StockItemID").Value + ", '" + Strings.Replace(rs.Fields("StockItem_Name").Value, "'", "''") + "', " + Strings.FormatNumber(rs.Fields("CatalogueChannelLnk_Price").Value, 2) + ", " + Strings.FormatNumber(rs.Fields("POSCatalogueChannelLnk_Price").Value, 2) + ", " + x + " FROM Company;";
					modRecordSet.cnnDB.Execute(sql);
				}

				_with22.Col = colFractions;
				_with22.set_TextMatrix(x, colFractions, 0);
				//rs("StockItem_Fractions")

				_with22.Col = colPackSize;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 222));
				_with22.Col = colContentExclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 222));
				_with22.Col = colContentInclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(212, 212, 212));

				_with22.Col = colDepositExclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 222));
				_with22.Col = colDepositInclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(212, 212, 212));

				_with22.Col = colDepositTotalExclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(220, 220, 255));
				_with22.Col = colDepositTotalInclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(200, 200, 255));

				_with22.Col = colContentTotalExclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(220, 220, 255));
				_with22.Col = colContentTotalInclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(200, 200, 255));

				_with22.Col = colDiscount;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 200));
				_with22.Col = colDiscountLine;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 200));
				_with22.Col = colDiscountPercentage;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 200));
				_with22.Col = colOnOrder;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 222));

				_with22.Col = colExclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(220, 255, 220));
				_with22.Col = colInclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(200, 255, 200));

				_with22.Col = colTotalExclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(220, 255, 220));
				_with22.Col = colTotalInclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(200, 255, 200));

				colName = 0;
				colChannelPrice = 2;
				colPosPrice = 11;

				//If gStockItemID Then
				//    .TextMatrix(x, colName) = rs("StockItem_Name")
				//    .TextMatrix(x, 1) = "0.00"
				//    .TextMatrix(x, colChannelPrice) = FormatNumber(rs("CatalogueChannelLnk_Price"), 2)
				//    .TextMatrix(x, colPosPrice) = FormatNumber(rs("POSCatalogueChannelLnk_Price"), 2)
				//Else
				//    If IsNull(rs(gFieldDisplay)) Then
				//        .TextMatrix(x, colName) = rs("StockItem_Name")
				//    Else
				//        .TextMatrix(x, colName) = rs("StockItem_Name")
				//      ' .TextMatrix(x, colName) = rs(gFieldDisplay)
				//    End If
				//End If

				if (retInfo == true) {
					_with22.set_TextMatrix(x, colName, rs.Fields("StockItem_Name").Value);
					_with22.set_TextMatrix(x, colChannelPrice, Strings.FormatNumber(rs.Fields("CatalogueChannelLnk_Price").Value, 2));
					_with22.set_TextMatrix(x, colPosPrice, Strings.FormatNumber(rs.Fields("POSCatalogueChannelLnk_Price").Value, 2));
					_with22.set_TextMatrix(x, 1, Strings.FormatNumber(rs.Fields("BlockTestItem_CutWeight").Value, 3));
					_with22.set_TextMatrix(x, 3, Strings.FormatNumber(rs.Fields("BlockTestItem_PerWeightYield").Value, 4));
					_with22.set_TextMatrix(x, 4, Strings.FormatNumber(rs.Fields("BlockTestItem_MRSellingratio").Value, 4));
					_with22.set_TextMatrix(x, 5, Strings.FormatNumber(rs.Fields("BlockTestItem_CostkgTO").Value, 4));
					_with22.set_TextMatrix(x, 6, Strings.FormatNumber(rs.Fields("BlockTestItem_MRelatedTO").Value, 4));
					_with22.set_TextMatrix(x, 7, Strings.FormatNumber(rs.Fields("BlockTestItem_PrimalCostkgExclVAT").Value, 4));
					_with22.set_TextMatrix(x, 8, Strings.FormatNumber(rs.Fields("BlockTestItem_SuggSellPriceExcl").Value, 4));
					_with22.set_TextMatrix(x, 9, Strings.FormatNumber(rs.Fields("BlockTestItem_TOSuggSellPriceExcl").Value, 4));
					_with22.set_TextMatrix(x, 10, Strings.FormatNumber(rs.Fields("BlockTestItem_SuggSellPriceIncl").Value, 4));
					_with22.set_TextMatrix(x, 12, Strings.FormatNumber(rs.Fields("BlockTestItem_TOActualSellExcl").Value, 4));
				} else {
					_with22.set_TextMatrix(x, colName, rs.Fields("StockItem_Name").Value);
					_with22.set_TextMatrix(x, 1, "0.00");
					_with22.set_TextMatrix(x, colChannelPrice, Strings.FormatNumber(rs.Fields("CatalogueChannelLnk_Price").Value, 2));
					_with22.set_TextMatrix(x, colPosPrice, Strings.FormatNumber(rs.Fields("POSCatalogueChannelLnk_Price").Value, 2));
				}

				displayLine(ref ref x);
				rs.MoveNext();
			}
			_with22.Col = colQuantity;
			_with22.Visible = true;
			loading = false;
			//doTotals

			picTotal.Top = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(gridItem.Top, false) + sizeConvertors.pixelToTwips(gridItem.Height, false) + 20, false);
		}

		private void displayLine(ref object row)
		{
			//Dim lDiscount As Decimal
			// With gridItem
			//lDiscount = .TextMatrix(row, colDiscount)
			//If activePrice = 1 Or activePrice = 3 Then
			//    lDiscount = lDiscount / (1 + .TextMatrix(row, colVAT) / 100)
			//End If
			//.TextMatrix(row, colDepositTotalExclusive) = FormatNumber(.TextMatrix(row, colDepositExclusive) * .TextMatrix(row, colQuantity), 2)
			//.TextMatrix(row, colContentTotalExclusive) = FormatNumber((.TextMatrix(row, colContentExclusive) - lDiscount) * .TextMatrix(row, colQuantity), 2)

			//.TextMatrix(row, colTotalExclusive) = FormatNumber(CCur(.TextMatrix(row, colContentTotalExclusive)) + CCur(.TextMatrix(row, colDepositTotalExclusive)), 2)
			//.TextMatrix(row, colExclusive) = FormatNumber(CCur(.TextMatrix(row, colContentExclusive)) + CCur(.TextMatrix(row, colDepositExclusive)), 2)

			//.TextMatrix(row, colContentInclusive) = FormatNumber(CCur(.TextMatrix(row, colContentExclusive)) + CCur(.TextMatrix(row, colContentExclusive)) * CCur(.TextMatrix(row, colVAT)) / 100, 2)
			//.TextMatrix(row, colDepositInclusive) = FormatNumber(CCur(.TextMatrix(row, colDepositExclusive)) + CCur(.TextMatrix(row, colDepositExclusive)) * CCur(.TextMatrix(row, colVAT)) / 100, 2)
			//.TextMatrix(row, colContentTotalInclusive) = FormatNumber(CCur(.TextMatrix(row, colContentTotalExclusive)) + CCur(.TextMatrix(row, colContentTotalExclusive)) * CCur(.TextMatrix(row, colVAT)) / 100, 2)
			//.TextMatrix(row, colDepositTotalInclusive) = FormatNumber(CCur(.TextMatrix(row, colDepositTotalExclusive)) + CCur(.TextMatrix(row, colDepositTotalExclusive)) * CCur(.TextMatrix(row, colVAT)) / 100, 2)

			//.TextMatrix(row, colTotalInclusive) = FormatNumber(CCur(.TextMatrix(row, colTotalExclusive)) + CCur(.TextMatrix(row, colTotalExclusive)) * CCur(.TextMatrix(row, colVAT)) / 100, 2)

			//.TextMatrix(row, colInclusive) = FormatNumber(CCur(.TextMatrix(row, colExclusive)) + CCur(.TextMatrix(row, colExclusive)) * CCur(.TextMatrix(row, colVAT)) / 100, 2)
			//If CCur(gridItem.TextMatrix(gridItem.row, colContentExclusive)) = 0 Then
			//    gridItem.TextMatrix(gridItem.row, colDiscountPercentage) = 0
			//Else
			//    gridItem.TextMatrix(gridItem.row, colDiscountPercentage) = FormatNumber(CCur(.TextMatrix(row, colDiscount)) / CCur(gridItem.TextMatrix(gridItem.row, colContentExclusive)) * 100, 2)
			//End If
			//gridItem.TextMatrix(gridItem.row, colDiscountLine) = FormatNumber(CCur(.TextMatrix(row, colDiscount)) * gridItem.TextMatrix(gridItem.row, colQuantity), 2)

			//End With

		}

		private void gridItem_EnterCell(System.Object eventSender, EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			if (loading)
				return;
			loading = true;
			var _with23 = gridItem;
			if (_with23.row) {
				//colContentExclusive Then
				if (_with23.Col == 1) {
					_txtEdit_1.SetBounds(sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with23.Left, true) + _with23.CellLeft, true), sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with23.Top, false) + _with23.CellTop, false), sizeConvertors.twipsToPixels(_with23.CellWidth, true), sizeConvertors.twipsToPixels(_with23.CellHeight, false));
					_txtEdit_1.Text = _with23.Text;
					_txtEdit_1.Tag = _txtEdit_1.Text;
					_txtEdit_1.Visible = true;
					_txtEdit_1.SelectionStart = 0;
					_txtEdit_1.SelectionLength = 9999;
					if (this.Visible)
						_txtEdit_1.Focus();
				} else if (_with23.Col == 2 | _with23.Col == 11) {
					_txtEdit_1.SetBounds(sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with23.Left, true) + _with23.CellLeft, true), sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with23.Top, false) + _with23.CellTop, false), sizeConvertors.twipsToPixels(_with23.CellWidth, true), sizeConvertors.twipsToPixels(_with23.CellHeight, false));
					_txtEdit_1.Text = _with23.Text;
					_txtEdit_1.Tag = _txtEdit_1.Text;
					_txtEdit_1.Visible = true;
					_txtEdit_1.SelectionStart = 0;
					_txtEdit_1.SelectionLength = 9999;
					if (this.Visible)
						_txtEdit_1.Focus();
				} else {
					_txtEdit_1.Visible = false;
				}
			}
			loading = false;

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

		private void gridItem_LeaveCell(System.Object eventSender, System.EventArgs eventArgs)
		{
			//update
		}

		private bool moveNext(ref int Index, ref int direction)
		{
			int x = 0;
			int y = 0;
			 // ERROR: Not supported in C#: OnErrorStatement


			x = gridItem.row + direction;
			if (x >= gridItem.RowCount | x < gridItem.FixedRows) {
			} else {
				gridItem.row = x;
			}

			var _with24 = gridItem;
			if (_with24.Row) {
				//colContentExclusive Then
				if (_with24.Col == 1) {
					_txtEdit_1.SetBounds(sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with24.Left, true) + _with24.CellLeft, true), sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with24.Top, false) + _with24.CellTop, false), sizeConvertors.twipsToPixels(_with24.CellWidth, true), sizeConvertors.twipsToPixels(_with24.CellHeight, false));
					//_txtEdit_1.Text = CCur(.Text) * 100
					if (Convert.ToDecimal(_with24.Text) == 0)
						_txtEdit_1.Text = "";
					else
						_txtEdit_1.Text = Convert.ToString(Convert.ToDecimal(_with24.Text));
					//* 100
					//_txtEdit_1.Tag = _txtEdit_1.Text
					//_txtEdit_1.Visible = True
					//_txtEdit_1.SelStart = 0
					//_txtEdit_1.SelLength = 9999
					//If Me.Visible Then _txtEdit_1.SetFocus
				} else if (_with24.Col == 2) {
					_txtEdit_1.SetBounds(sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with24.Left, true) + _with24.CellLeft, true), sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with24.Top, false) + _with24.CellTop, false), sizeConvertors.twipsToPixels(_with24.CellWidth, true), sizeConvertors.twipsToPixels(_with24.CellHeight, false));
					if (Convert.ToDecimal(_with24.Text) == 0)
						_txtEdit_1.Text = "";
					else
						_txtEdit_1.Text = Convert.ToString(Convert.ToDecimal(_with24.Text));
					//* 100
				} else if (_with24.Col == 11) {
					_txtEdit_1.SetBounds(sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with24.Left, true) + _with24.CellLeft, true), sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with24.Top, false) + _with24.CellTop, false), sizeConvertors.twipsToPixels(_with24.CellWidth, true), sizeConvertors.twipsToPixels(_with24.CellHeight, false));
					if (Convert.ToDecimal(_with24.Text) == 0)
						_txtEdit_1.Text = "";
					else
						_txtEdit_1.Text = Convert.ToString(Convert.ToDecimal(_with24.Text));
					//* 100
				} else {
					_txtEdit_1.Visible = false;
				}
			}
			//txtEdit(Index).SelectionStart = 0
			//txtEdit(Index).SelectionLength = 999
			//If txtEdit(Index).Visible Then txtEdit(Index).Focus()

			return true;
		}

		private void txtEdit_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			//Dim Index As Short = txtEdit.GetIndex(eventSender)

			int Index = 0;
			TextBox m = new TextBox();
			TextBox n = new TextBox();
			n = (TextBox)eventSender;
			Index = 0;
			foreach (TextBox m_loopVariable in txtEdit) {
				m = m_loopVariable;
				if (m.Name != n.Name) {
					Index = Index + 1;
				}
			}

			if (KeyCode == 40) {
				loading = true;
				calcP();
				moveNext(ref 1, ref 1);
				loading = false;
				//txtEdit(Index).SelStart = 0
				//txtEdit(Index).SelLength = 999
			} else if (KeyCode == 38) {
				loading = true;
				calcP();
				moveNext(ref 1, ref -1);
				loading = false;
				//txtEdit(Index).SelStart = 0
				//txtEdit(Index).SelLength = 999
			}

		}

		private void txtEdit_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			//Dim Index As Short = txtEdit.GetIndex(eventSender)
			int Index = 0;
			TextBox m = new TextBox();
			TextBox n = new TextBox();
			n = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref n, ref txtEdit);

			// Delete carriage returns to get rid of beep
			// and only allow numbers.
			switch (KeyAscii) {
				case Strings.Asc(Constants.vbCr):
					gridItem.Focus();
					update_Renamed();
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
					break;
				//If Index = 0 Then
				//    If CBool(gridItem.TextMatrix(gridItem.row, colFractions)) Then
				//    Else
				//        KeyAscii = 0
				//        Exit Sub
				//    End If
				//End If



			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtEdit_TextChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim Index As Short = txtEdit.GetIndex(eventSender)
			int Index = 0;
			TextBox m = new TextBox();
			TextBox n = new TextBox();
			n = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref n, ref txtEdit);
			int colPrice = 0;
			int colFractions = 0;
			int colQuantity = 0;
			if (loading)
				return;
			string lString = null;
			var _with25 = gridItem;
			lString = txtEdit[Index].Text;
			if (lString == ".")
				lString = "0.";
			if (_with25.Row) {
				if (string.IsNullOrEmpty(lString))
					lString = "0";
				if (Convert.ToDecimal(lString) == 0)
					lString = "";
				if (Information.IsNumeric(lString)) {
					switch (Index) {
						case 0:
							if (Convert.ToBoolean(_with25.get_TextMatrix(_with25.Row, colFractions))) {
								_with25.set_TextMatrix(_with25.Row, colQuantity, Strings.FormatNumber(lString, 4));
							} else {
								_with25.set_TextMatrix(_with25.Row, colQuantity, Strings.FormatNumber(lString, 0));
							}
							break;
						case 1:
							if (_with25.Col == 1) {
								_with25.set_TextMatrix(_with25.Row, 1, Strings.FormatNumber(lString, 3));
							} else if (_with25.Col == 2) {
								_with25.set_TextMatrix(_with25.Row, 2, Strings.FormatNumber(lString, 2));
							} else if (_with25.Col == 11) {
								_with25.set_TextMatrix(_with25.Row, 11, Strings.FormatNumber(lString, 2));
							}
							break;
						case 2:
							_with25.set_TextMatrix(_with25.Row, colPrice, Strings.FormatNumber(Convert.ToDecimal(lString) / 100, 2));
							break;
					}
				}
				//displayLine .row
			}
			//doTotals
		}

		private void txtEdit_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim Index As Short = txtEdit.GetIndex(eventSender)
			update_Renamed();
			calcP();
		}

		private void calcP()
		{
			decimal QtyD_P = default(decimal);
			int rowNo = 0;
			short x = 0;
			loading = true;
			 // ERROR: Not supported in C#: OnErrorStatement

			if (gridItem.Col == 1) {
				rowNo = gridItem.row;
				QtyD_P = 0;
				var _with26 = gridItem;
				for (x = 1; x <= (_with26.RowCount - 1); x++) {
					_with26.row = x;
					_with26.Col = 1;
					QtyD_P = QtyD_P + Convert.ToDecimal(_with26.Text);
				}
				lblP.Text = Strings.FormatNumber(QtyD_P, 4);
				gridItem.row = rowNo;
			}
			loading = false;
		}
		private void update_Renamed()
		{
			if (loading)
				return;
			//    Dim lNode As IXMLDOMNode
			//Dim x As Integer
			//Dim sql As String
			decimal QtyD_P = default(decimal);
			 // ERROR: Not supported in C#: OnErrorStatement


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
			//If lUpdate Then
			switch (gridItem.Col) {
				case 1:
					//colContentExclusive
					//gridItem.TextMatrix(gridItem.row, 1) = FormatNumber(CCur(_txtEdit_1.Text) / 100, 2)
					gridItem.set_TextMatrix(ref gridItem.row, ref 1, ref Strings.FormatNumber(_txtEdit_1.Text, 3));
					break;
				//_txtEdit_1.Tag = _txtEdit_1.Text
				case 2:
					gridItem.set_TextMatrix(ref gridItem.row, ref 2, ref Strings.FormatNumber(_txtEdit_1.Text, 2));
					break;
				case 11:
					gridItem.set_TextMatrix(ref gridItem.row, ref 11, ref Strings.FormatNumber(_txtEdit_1.Text, 2));
					break;
			}
			//End If
		}

		private void txtEdit_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim Index As Short = txtEdit.GetIndex(eventSender)
			//txtEdit(Index).SelStart = 0
			//txtEdit(Index).SelLength = 999
			 // ERROR: Not supported in C#: OnErrorStatement

			var _with27 = gridItem;
			if (_with27.Row) {
				//colContentExclusive Then
				if (_with27.Col == 1) {
					_txtEdit_1.SetBounds(sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with27.Left, true) + _with27.CellLeft, true), sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with27.Top, false) + _with27.CellTop, false), sizeConvertors.twipsToPixels(_with27.CellWidth, true), sizeConvertors.twipsToPixels(_with27.CellHeight, false));
					//_txtEdit_1.Text = CCur(.Text) * 100
					if (Convert.ToDecimal(_with27.Text) == 0)
						_txtEdit_1.Text = "";
					else
						_txtEdit_1.Text = Convert.ToString(Convert.ToDecimal(_with27.Text));
					//* 100
					//_txtEdit_1.Tag = _txtEdit_1.Text
					//_txtEdit_1.Visible = True
					//_txtEdit_1.SelStart = 0
					//_txtEdit_1.SelLength = 9999
					//If Me.Visible Then _txtEdit_1.SetFocus
				} else if (_with27.Col == 2) {
					_txtEdit_1.SetBounds(sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with27.Left, true) + _with27.CellLeft, true), sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with27.Top, false) + _with27.CellTop, false), sizeConvertors.twipsToPixels(_with27.CellWidth, true), sizeConvertors.twipsToPixels(_with27.CellHeight, false));
					if (Convert.ToDecimal(_with27.Text) == 0)
						_txtEdit_1.Text = "";
					else
						_txtEdit_1.Text = Convert.ToString(Convert.ToDecimal(_with27.Text));
					//* 100
				} else if (_with27.Col == 11) {
					_txtEdit_1.SetBounds(sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with27.Left, true) + _with27.CellLeft, true), sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with27.Top, false) + _with27.CellTop, false), sizeConvertors.twipsToPixels(_with27.CellWidth, true), sizeConvertors.twipsToPixels(_with27.CellHeight, false));
					if (Convert.ToDecimal(_with27.Text) == 0)
						_txtEdit_1.Text = "";
					else
						_txtEdit_1.Text = Convert.ToString(Convert.ToDecimal(_with27.Text));
					//* 100
				} else {
					_txtEdit_1.Visible = false;
				}
			}
			//txtEdit(Index).SelStart = 0
			//txtEdit(Index).SelLength = 999
		}

		private void txtR_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumericMEAT(ref txtR);
		}

		private void txtR_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			//If KeyAscii = 27 Then
			//    'Unload Me
			//Else
			//    KeyPress KeyAscii
			//End If
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtR_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			//LostFocus txtR, 2
		}

		private void txtReqGP_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumericMEAT(ref txtReqGP);
		}

		private void txtVAT_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumericMEAT(ref txtVAT);
		}

		private void txtZ_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumericMEAT(ref txtZ);
		}

		private void txtZ_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			//If KeyAscii = 27 Then
			//    'Unload Me
			//Else
			//    KeyPress KeyAscii
			//End If
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtZ_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			//LostFocus txtZ, 2
		}

		public void loadItemSAVE(ref int stockitemID, ref int quantity = 0)
		{
			int colQuantity = 0;
			System.Windows.Forms.TextBox oText = null;

			modBResolutions.ResizeForm(ref this, ref sizeConvertors.pixelToTwips(this.Width, true), ref sizeConvertors.pixelToTwips(this.Height, false), ref 2);

			setup();
			frmBlockTest_Resize(this, new System.EventArgs());

			//Serial chk
			if (checkSecurity() == true) {
			} else {
				this.Text = this.Text + " - Trial";
				cmdReg.Visible = true;
			}

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

			gStockItemID = stockitemID;
			gQuantity = quantity;
			loadDataSAVE();
		}

		private void loadDataSAVE()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);

			//Set rs = getRS("SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & gStockItemID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
			rs = modRecordSet.getRS(ref "SELECT BlockTest.*, StockItem.StockItem_Name, Person.Person_FirstName, Person.Person_LastName FROM (BlockTest INNER JOIN StockItem ON BlockTest.BlockTest_MainItemID = StockItem.StockItemID) INNER JOIN Person ON BlockTest.BlockTest_PersonID = Person.PersonID WHERE (((BlockTest.BlockTestID)=" + testID + "));");

			if (rs.RecordCount) {
				lblContentExclusive.Text = rs.Fields("Person_FirstName").Value + " " + rs.Fields("Person_LastName").Value;
				txtR.Text = Strings.FormatNumber(rs.Fields("BlockTest_PricePerKg").Value, 4);
				txtZ.Text = Strings.FormatNumber(rs.Fields("BlockTest_WeightCarcass").Value, 4);
				txtReqGP.Text = Strings.FormatNumber(rs.Fields("BlockTest_RequiredGP").Value, 4);
				txtVAT.Text = Strings.FormatNumber(rs.Fields("BlockTest_VAT").Value, 4);
				getRecItems(ref true);
				cmdTotal_ClickSAVE();
				if (rs.Fields("BlockTest_BlockTestStatusID").Value == 3) {
					txtR.ReadOnly = true;
					txtZ.ReadOnly = true;
					txtReqGP.ReadOnly = true;
					txtVAT.ReadOnly = true;

					gridItem.Enabled = false;
					cmdProc.Enabled = false;
					cmdTotal.Enabled = false;
				}
				ShowDialog();
			} else {
				this.Close();
				return;
			}
		}


		private void cmdTotal_ClickSAVE()
		{
			decimal QtyD_P = default(decimal);
			 // ERROR: Not supported in C#: OnErrorStatement


			lblA.Text = Strings.FormatNumber(Convert.ToDecimal(txtR.Text) * Convert.ToDecimal(txtZ.Text), 4);


			lblGP_Y.Text = Strings.FormatNumber(Convert.ToDecimal(1 - (Convert.ToDecimal(Convert.ToDouble(txtReqGP.Text) / 100))), 4);


			var _with28 = gridItem;
			for (x = 1; x <= (_with28.RowCount - 1); x++) {
				_with28.Row = x;
				_with28.Col = 1;
				QtyD_P = QtyD_P + Convert.ToDecimal(_with28.Text);
				// .TextMatrix(.row, 1) = FormatNumber(CCur(_txtEdit_1.Text) / 100, 4)
				//cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_CutWeight = " & FormatNumber(CCur(.Text), 3) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
			}
			lblP.Text = Strings.FormatNumber(QtyD_P, 4);


			lblB.Text = Strings.FormatNumber(Convert.ToDecimal(txtZ.Text) - Convert.ToDecimal(lblP.Text), 4);


			lblC.Text = Strings.FormatNumber(Convert.ToDecimal(lblA.Text) / Convert.ToDecimal(lblP.Text), 4);


			lblB_Z.Text = Strings.FormatNumber(Convert.ToDecimal(lblB.Text) / Convert.ToDecimal(txtZ.Text), 4);


			lblX.Text = Strings.FormatNumber(Convert.ToDecimal(Convert.ToDecimal(Convert.ToDouble(txtVAT.Text) / 100) + 1), 4);


			//With gridItem
			//    For x = 1 To (.RowCount - 1)
			//        .row = x
			//        .Col = 1
			//        .TextMatrix(.row, 3) = FormatNumber((CCur(.Text) / CCur(txtZ.Text)) * 100, 4)
			//        '.Col = 3
			//        'QtyD_P = QtyD_P + CCur(.Text)
			//    Next
			//End With
			QtyD_P = 0;
			var _with29 = gridItem;
			for (x = 1; x <= (_with29.RowCount - 1); x++) {
				_with29.Row = x;
				_with29.Col = 3;
				QtyD_P = QtyD_P + Convert.ToDecimal(_with29.Text);
				//        cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_PerWeightYield = " & FormatNumber(CCur(.Text), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
			}
			lblTotalF.Text = Strings.FormatNumber(QtyD_P, 4);
			//total req


			//Dim D_E As Currency
			//With gridItem
			//    For x = 1 To (.RowCount - 1)
			//        .row = x
			//        .Col = 1
			//        D_E = CCur(.Text)
			//        .Col = 2
			//        D_E = D_E * CCur(.Text)
			//        .TextMatrix(.row, 6) = FormatNumber(D_E, 4)
			//    Next
			//End With
			QtyD_P = 0;
			var _with30 = gridItem;
			for (x = 1; x <= (_with30.RowCount - 1); x++) {
				_with30.Row = x;
				_with30.Col = 6;
				QtyD_P = QtyD_P + Convert.ToDecimal(_with30.Text);
				//        cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_MRelatedTO = " & FormatNumber(CCur(.Text), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
			}
			lblTotalQ.Text = Strings.FormatNumber(QtyD_P, 4);
			//total req


			decimal S_A_Q = default(decimal);
			S_A_Q = Convert.ToDecimal(Strings.FormatNumber(Convert.ToDecimal(lblA.Text) / Convert.ToDecimal(lblTotalQ.Text), 4));
			//
			//With gridItem
			//    For x = 1 To (.RowCount - 1)
			//        .row = x
			//        .Col = 2
			//        '.TextMatrix(.row, 4) = FormatNumber((CCur(.Text) / CCur(lblC.Caption)) * CCur(lblGP_Y.Caption), 4)
			//        .TextMatrix(.row, 4) = FormatNumber((CCur(.Text) / CCur(lblC.Caption)) * CCur(S_A_Q), 4)
			//    Next
			//End With
			QtyD_P = 0;
			var _with31 = gridItem;
			for (x = 1; x <= (_with31.RowCount - 1); x++) {
				_with31.Row = x;
				_with31.Col = 4;
				QtyD_P = QtyD_P + Convert.ToDecimal(_with31.Text);
				//        cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_MRSellingratio = " & FormatNumber(CCur(.Text), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
			}
			lblTotalG.Text = Strings.FormatNumber(QtyD_P, 4);
			//total req


			//With gridItem
			//    For x = 1 To (.RowCount - 1)
			//        .row = x
			//        .Col = 4
			//        .TextMatrix(.row, 7) = FormatNumber(CCur(lblC.Caption) * CCur(.Text), 4)
			//        cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_PrimalCostkgExclVAT = " & FormatNumber(CCur(lblC.Caption) * CCur(.Text), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
			//    Next
			//End With


			//Dim J_D As Currency
			//With gridItem
			//    For x = 1 To (.RowCount - 1)
			//        .row = x
			//        .Col = 7
			//        J_D = CCur(.Text)
			//        .Col = 1
			//        J_D = J_D * CCur(.Text)
			//        .TextMatrix(.row, 5) = FormatNumber(J_D, 4)
			//    Next
			//End With
			QtyD_P = 0;
			var _with32 = gridItem;
			for (x = 1; x <= (_with32.RowCount - 1); x++) {
				_with32.Row = x;
				_with32.Col = 5;
				QtyD_P = QtyD_P + Convert.ToDecimal(_with32.Text);
				//        cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_CostkgTO = " & FormatNumber(CCur(.Text), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
			}
			lblTotalH.Text = Strings.FormatNumber(QtyD_P, 4);
			//total req


			//With gridItem
			//    For x = 1 To (.RowCount - 1)
			//        .row = x
			//        .Col = 7
			//        .TextMatrix(.row, 8) = FormatNumber(CCur(.Text) / CCur(lblGP_Y.Caption), 4)
			//        cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_SuggSellPriceExcl = " & FormatNumber(CCur(.Text) / CCur(lblGP_Y.Caption), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
			//    Next
			//End With


			//Dim K_D As Currency
			//With gridItem
			//    For x = 1 To (.RowCount - 1)
			//        .row = x
			//        .Col = 8
			//        K_D = CCur(.Text)
			//        .Col = 1
			//        K_D = K_D * CCur(.Text)
			//        .TextMatrix(.row, 9) = FormatNumber(K_D, 4)
			//    Next
			//End With
			QtyD_P = 0;
			var _with33 = gridItem;
			for (x = 1; x <= (_with33.RowCount - 1); x++) {
				_with33.Row = x;
				_with33.Col = 9;
				QtyD_P = QtyD_P + Convert.ToDecimal(_with33.Text);
				//        cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_TOSuggSellPriceExcl = " & FormatNumber(CCur(.Text), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
			}
			lblTotalL.Text = Strings.FormatNumber(QtyD_P, 4);
			//total req


			//With gridItem
			//    For x = 1 To (.RowCount - 1)
			//        .row = x
			//        .Col = 8
			//        .TextMatrix(.row, 10) = FormatNumber(CCur(.Text) * CCur(lblX.Caption), 4)
			//        cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_SuggSellPriceIncl = " & FormatNumber(CCur(.Text) * CCur(lblX.Caption), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
			//    Next
			//End With


			//Dim N_X_D As Currency
			//With gridItem
			//    For x = 1 To (.RowCount - 1)
			//        .row = x
			//        .Col = 11
			//        N_X_D = (CCur(.Text) / CCur(lblX.Caption))
			//        .Col = 1
			//        N_X_D = N_X_D * CCur(.Text)
			//        .TextMatrix(.row, 12) = FormatNumber(N_X_D, 4)
			//    Next
			//End With
			QtyD_P = 0;
			var _with34 = gridItem;
			for (x = 1; x <= (_with34.RowCount - 1); x++) {
				_with34.Row = x;
				_with34.Col = 12;
				QtyD_P = QtyD_P + Convert.ToDecimal(_with34.Text);
				//        cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_TOActualSellExcl = " & FormatNumber(CCur(.Text), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
			}
			_lblTotal_0.Text = Strings.FormatNumber(QtyD_P, 4);
			//total req

		}

		private string getSerialNumber()
		{
			string functionReturnValue = null;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			Scripting.Folder fsoFolder = default(Scripting.Folder);
			functionReturnValue = "";
			if (fso.FolderExists(modRecordSet.serverPath)) {
				fsoFolder = fso.GetFolder(modRecordSet.serverPath);
				functionReturnValue = Convert.ToString(fsoFolder.Drive.SerialNumber);
			}
			return functionReturnValue;
		}

		private string Encrypt(string secret, string PassWord)
		{
			int l = 0;
			short x = 0;
			string Char_Renamed = null;
			l = Strings.Len(PassWord);
			for (x = 1; x <= Strings.Len(secret); x++) {
				Char_Renamed = Convert.ToString(Strings.Asc(Strings.Mid(PassWord, (x % l) - l * Convert.ToInt16((x % l) == 0), 1)));
				Strings.Mid(secret, x, 1) = Strings.Chr(Strings.Asc(Strings.Mid(secret, x, 1)) ^ Char_Renamed);
			}
			return secret;
		}

		private bool checkSecurity()
		{
			bool functionReturnValue = false;
			int intMonth = 0;
			int intYear = 0;
			string lCode = null;
			string leCode = null;
			string lPassword = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			short x = 0;
			functionReturnValue = false;
			string strSerial = null;
			string strTmp = null;
			short intDate = 0;
			string dtDate = null;
			string dtMonth = null;
			string dtYear = null;
			string stPass = null;
			// clsCryptoAPI
			clsCryptoAPI cCrypto = null;
			if (modRecordSet.openConnection()) {
				rs = modRecordSet.getRS(ref "SELECT * From Company");

				if (rs.RecordCount) {
					//if old database don't chk secuirty
					if (rs.Fields.Count <= 55){functionReturnValue = true;return functionReturnValue;}

					if (Information.IsDBNull(rs.Fields("Company_ResMS").Value)){functionReturnValue = false;return functionReturnValue;}


					cCrypto = new clsCryptoAPI();
					//clsCryptoAPI
					System.Windows.Forms.Application.DoEvents();
					strTmp = cCrypto.ConvertStringFromHex(Strings.Left(rs.Fields("Company_ResMS").Value, Strings.Len(rs.Fields("Company_ResMS").Value) - 5));
					System.Windows.Forms.Application.DoEvents();
					arData = cCrypto.StringToByteArray(strTmp);
					System.Windows.Forms.Application.DoEvents();
					arPWord = cCrypto.StringToByteArray(Conversion.Val(Strings.Right(rs.Fields("Company_ResMS").Value, 5)));
					System.Windows.Forms.Application.DoEvents();
					cCrypto.PassWord = arPWord;
					System.Windows.Forms.Application.DoEvents();
					cCrypto.InputData = System.Text.UnicodeEncoding.Unicode.GetString(arData);
					System.Windows.Forms.Application.DoEvents();

					// Decrypt the data input from the encrypted text box
					//If cCrypto.Decrypt(g_intHashType, m_intCipher) Then
					//UPGRADE_WARNING: Couldn't resolve default property of object cCrypto.Decrypt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (cCrypto.Decrypt(2, 1)) {
						System.Windows.Forms.Application.DoEvents();
						//UPGRADE_WARNING: Couldn't resolve default property of object cCrypto.OutputData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						arData = cCrypto.OutputData.Clone();
						//UPGRADE_WARNING: Couldn't resolve default property of object cCrypto.ByteArrayToString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						strSerial = cCrypto.ByteArrayToString(arData);
					}


					if (Strings.Left(strSerial, 3) == "met") {
						//Create date password

						if (Information.IsNumeric(Strings.Mid(strSerial, 4, Strings.Len(strSerial)))) {
							functionReturnValue = true;
							goto jumpOut;

							strSerial = Strings.Mid(strSerial, 4, Strings.Len(strSerial));
							intYear = Strings.Mid(strSerial, 5, 2);
							intMonth = Strings.Mid(strSerial, 3, 2);
							intDate = Convert.ToInt16(Strings.Left(strSerial, 2));

							if ((intDate / 2) == System.Math.Round(intDate / 2)) {
								intDate = intDate / 2;
							} else {
								goto jumpOut;
							}

							if ((intMonth / 3) == System.Math.Round(intMonth / 3)) {
								intMonth = intMonth / 3;
							} else {
								goto jumpOut;
							}

							if ((intYear / 4) == System.Math.Round(intYear / 4)) {
								intYear = intYear / 4;
							} else {
								goto jumpOut;
							}

							stPass = "20";
							if (Strings.Len(Convert.ToString(intYear)) == 1) {
								stPass = stPass + "0" + intYear + "/";
							} else {
								stPass = stPass + intYear + "/";
							}
							if (Strings.Len(Convert.ToString(intMonth)) == 1) {
								stPass = stPass + "0" + intMonth + "/";
							} else {
								stPass = stPass + intMonth + "/";
							}
							if (Strings.Len(Convert.ToString(intDate)) == 1)
								stPass = stPass + "0" + intDate;
							else
								stPass = stPass + intDate;

							if (Information.IsDate(stPass)) {
								if (Convert.ToDateTime(stPass) >= (System.DateTime.FromOADate(DateAndTime.Today.ToOADate() - 31))) {
									functionReturnValue = true;
								}
							}

						} else {
							//MsgBox "Not a Valid 4MEAT Key!", vbCritical
						}
					} else {
						//MsgBox "Not a Valid 4MEAT Key!", vbCritical
					}
					jumpOut:
					//UPGRADE_NOTE: Object cCrypto may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					cCrypto = null;
					// Free the Crypto class from memory
					strTmp = new string(Strings.Chr(0), 250);
					return functionReturnValue;
					// overwrite data in temp variable

				} else {
					Interaction.MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS");
					//End
				}
			} else {
				Interaction.MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS");
				//End
			}
			return functionReturnValue;
		}

		private bool timeOver()
		{
			bool functionReturnValue = false;
			ADODB.Recordset rs = default(ADODB.Recordset);

			functionReturnValue = false;
			//If openConnection() Then
			rs = modRecordSet.getRS(ref "SELECT * From Company");

			if (rs.RecordCount) {
				//if old database don't chk secuirty
				if (rs.Fields.Count <= 55){functionReturnValue = false;return functionReturnValue;}

				if (rs.Fields("Company_ResMN").Value < 20) {
					if (rs.Fields("Company_ResMN").Value == 11)
						Interaction.MsgBox("You have 7 more Calculations to run before the demo software expires." + Constants.vbCrLf + "Please contact your 4POS representative or www.4pos.co.za.", MsgBoxStyle.Critical, "4MEAT is not Registered");
					modRecordSet.cnnDB.Execute("UPDATE Company SET Company_ResMN = Company_ResMN+1;");
					functionReturnValue = false;
				} else if (rs.Fields("Company_ResMN").Value >= 20) {
					functionReturnValue = true;
				}
				return functionReturnValue;

			} else {
				Interaction.MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS");
				//End
			}
			return functionReturnValue;
			//Else
			//    MsgBox "Unable to locate the '4POS Application Suite' database.", vbCritical, "4POS"
			//    End
			//End If
		}
	}
}
