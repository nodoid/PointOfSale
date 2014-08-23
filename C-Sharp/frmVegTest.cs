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
	internal partial class frmVegTest : System.Windows.Forms.Form
	{

//serialization
		ADODB.Recordset adoPrimaryRS;
		bool mbChangedByCode;
		int mvBookMark;
		bool mbEditFlag;
		bool mbAddNewFlag;
		bool mbDataChanged;
		int gID;
		int k_posID;
		bool k_posNew;
		List<TextBox> txtEdit = new List<TextBox>();

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

		object[] fox = new object[9];
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
		bool bFinish;
		decimal cPackVol;

		string testName;
		string testType;
		int testID;
		int[] StockItemLineID;

		public void Reset_frmEncStrings()
		{
			string strMsg = null;

			arData = null;
			arPWord = null;
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
			ADODB.Recordset rsLoad = default(ADODB.Recordset);
			int lGRVID = 0;

			My.MyProject.Forms.frmVegTestSelect.loadTest(ref testType, ref testID);
			cPackVol = 0;
			reType:

			if (testType == "exit") {
				this.Close();
				return;

			} else if (testType == "new") {
				testName = Interaction.InputBox("Please enter short Name/Title for Veg Production Test.", "Please enter short Name/Title for Veg Production Test.");
				if (string.IsNullOrEmpty(testName))
					goto reType;

				lID = My.MyProject.Forms.frmStockList.getItem();
				//lGRVID = frmVegTestGRV.getGRVID

				if (lID != 0) {
					//On Local Error Resume Next
					rs = modRecordSet.getRS(ref "SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity From WarehouseStockItemLnk WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID)=" + lID + ") AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));");
					if (rs.RecordCount) {
						if (rs.Fields("WarehouseStockItemLnk_Quantity").Value > 0) {
							AvailGRV.Text = Strings.FormatNumber(rs.Fields("WarehouseStockItemLnk_Quantity").Value, 2);
							//txtZ.Text = FormatNumber(rs("GRVItem_QuantityTotalKG"), 2)
							//lblA = FormatNumber(rs("GRVItem_QuantityUsedKG"), 2)
							lblB.Text = AvailGRV.Text;
						} else {
							Interaction.MsgBox("Insufficient Qty in Main Stock Item!");
							this.Close();
							return;
						}
					} else {
						Interaction.MsgBox("Main Stock Item doest not have Qty to be used!");
						this.Close();
						return;
					}

					//txtR.Text = FormatNumber(rs("GRVItem_ActualCost") / rs("GRVItem_PackSizeVol"), 4)
					//cPackVol = rs("GRVItem_PackSizeVol")
					sql = "INSERT INTO VegTest ( VegTest_DayEndID, VegTest_VegTestStatusID, VegTest_Date, VegTest_MainItemID, VegTest_PersonID, VegTest_Desc, VegTest_PricePerKg, VegTest_WeightCarcass, VegTest_RequiredGP, VegTest_VAT, VegTest_Notes, VegTest_GRVID, VegTest_PackSize ) ";
					sql = sql + "SELECT Company.Company_DayEndID, 1 AS status, Now(), " + lID + ", " + My.MyProject.Forms.frmMenu.lblUser.Tag + ", '" + Strings.Left(Strings.Replace(testName, "'", "''"), 49) + "', " + 0 + ", 0, 0, 0, '', " + 0 + ", " + 0 + " FROM Company;";
					modRecordSet.cnnDB.Execute(sql);
					rs = modRecordSet.getRS(ref "SELECT Max(VegTestID) AS id FROM VegTest;");
					testID = rs.Fields("id").Value;

					loadItem(lID);
				}

			} else if (testType == "load") {
				rs = modRecordSet.getRS(ref "SELECT * FROM VegTest WHERE VegTestID = " + testID + ";");
				if (rs.RecordCount) {

					rsLoad = modRecordSet.getRS(ref "SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity From WarehouseStockItemLnk WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID)=" + rs.Fields("VegTest_MainItemID").Value + ") AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));");
					if (rsLoad.RecordCount) {
						if (rsLoad.Fields("WarehouseStockItemLnk_Quantity").Value > 0) {
							AvailGRV.Text = Strings.FormatNumber(rsLoad.Fields("WarehouseStockItemLnk_Quantity").Value, 2);
							lblB.Text = AvailGRV.Text;
						} else {
							Interaction.MsgBox("Insufficient Qty in Main Stock Item!");
							this.Close();
							return;
						}
					} else {
						Interaction.MsgBox("Main Stock Item is not part of Selected Market/GRV!");
						this.Close();
						return;
					}

					//txtR.Text = FormatNumber(rsLoad("GRVItem_ActualCost") / rs("VegTest_PackSize"), 2)
					//cPackVol = rs("VegTest_PackSize")
					loadItemSAVE(rs.Fields("VegTest_MainItemID").Value);
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

			//Set rs = getRS("SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & gStockItemID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
			rs = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, StockItem.StockItem_Name, RecipeStockitemLnk.RecipeStockitemLnk_Quantity, [StockItem_ListCost]/[StockItem_Quantity] AS cost, PriceChannelLnk.PriceChannelLnk_Price FROM (RecipeStockitemLnk INNER JOIN StockItem ON RecipeStockitemLnk.RecipeStockitemLnk_StockitemID = StockItem.StockItemID) INNER JOIN PriceChannelLnk ON StockItem.StockItemID = PriceChannelLnk.PriceChannelLnk_StockItemID Where (((RecipeStockitemLnk.RecipeStockitemLnk_RecipeID) = " + gStockItemID + ") And ((StockItem.StockItem_Discontinued) = False) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = 1) And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1)) ORDER BY StockItem.StockItem_Name;");
			if (rs.RecordCount) {
				//lblStockItem.Caption = rs("StockItem_Name")
				//lblPromotion.Caption = rs("Promotion_Name")
				//txtPrice.Text = rs("CatalogueChannelLnk_Price") * 100
				//txtPrice_LostFocus
				//cmbQuantity.Tag = rs("CatalogueChannelLnk_Quantity")
				lblContentExclusive.Text = My.MyProject.Forms.frmMenu.lblUser.Text;
				getRecItems();
				ShowDialog();
			} else {
				this.Close();
				return;
			}

		}

		public void loadItem(ref int stockitemID, ref int quantity = 0)
		{
			int colQuantity = 0;
			TextBox oText = new TextBox();

			modBResolutions.ResizeForm(ref this, ref sizeConvertors.pixelToTwips(this.Width, true), ref sizeConvertors.pixelToTwips(this.Height, false), ref 2);

			setup();
			frmVegTest_Resize(this, new System.EventArgs());

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

		//Private Sub CreateVegItems(csvBarcode As String, csvPRG As String, csvDESC As String, csvSell As Currency, csvCost As Currency, csvSTG_RPG As String, csvVAT As String)
		private void CreateVegItems(ref int sID, ref decimal sSellPrice, ref decimal sPackVol, ref int lgetNewID)
		{
			bool newATItem = false;
			string sql = null;
			int gBrandItem = 0;
			int gStockItem = 0;

			System.Windows.Forms.Application.DoEvents();
			gStockItem = 0;
			gBrandItem = 0;
			 // ERROR: Not supported in C#: OnErrorStatement

			//Dim rsSupp          As Recordset
			//Dim rsDep          As Recordset
			//Dim rsPriceG          As Recordset
			//Dim rsStockG          As Recordset
			//Dim rsReportG          As Recordset
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsCostPrice = default(ADODB.Recordset);
			decimal aCost = default(decimal);
			decimal sPrice = default(decimal);

			sql = "SELECT StockItem.StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_ListCost, StockItem.StockItem_ActualCost, Catalogue.Catalogue_Barcode ";
			sql = sql + "FROM (StockItem INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID ";
			sql = sql + "WHERE (((StockItem.StockItemID)=" + sID + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)=1) AND ((Catalogue.Catalogue_Quantity)=1));";
			rsCostPrice = modRecordSet.getRS(ref sql);

			sql = "INSERT INTO StockItem ( StockItem_BrandItemID, StockItem_SupplierID, StockItem_ShrinkID, StockItem_PackSizeID, StockItem_PricingGroupID, StockItem_StockGroupID, StockItem_VatID, StockItem_DepositID, StockItem_Name, StockItem_ReceiptName, StockItem_Quantity, StockItem_ListCost, StockItem_ActualCost, StockItem_MinimumStock, StockItem_MaximumStock, StockItem_OrderQuantity, StockItem_OrderRounding, StockItem_OrderDynamic, StockItem_Disabled, StockItem_Discontinued, StockItem_SupplierCode, StockItem_ActualCostChange, StockItem_PriceSetID, StockItem_LastCost, StockItem_Parameters, StockItem_Fractions, StockItem_NegSale, StockItem_VariablePrice, StockItem_NonWeighted, StockItem_PrintLocationID, StockItem_RecipeType, StockItem_PrintGroupID, StockItem_SerialTracker, StockItem_SBarcode, StockItem_SShelf, StockItem_ReportID, StockItemOrderType, StockItem_ATItem, StockItem_ATStockTypeID, StockItem_ExpiryDays ) ";
			sql = sql + "SELECT StockItem.StockItem_BrandItemID, StockItem.StockItem_SupplierID, StockItem.StockItem_ShrinkID, StockItem.StockItem_PackSizeID, StockItem.StockItem_PricingGroupID, StockItem.StockItem_StockGroupID, StockItem.StockItem_VatID, StockItem.StockItem_DepositID, [StockItem].[StockItem_Name] & ' # " + Strings.Format(DateAndTime.Today, "dd/mm") + "' AS StockItemName, [StockItem].[StockItem_ReceiptName] & ' # " + Strings.Format(DateAndTime.Today, "dd/mm") + "' AS StockItemReceiptName, StockItem.StockItem_Quantity, " + (Convert.ToDecimal((sPackVol == 0 ? 1 : sPackVol) * Convert.ToDecimal(txtR.Text))) + " AS StockItemListCost, " + (Convert.ToDecimal((sPackVol == 0 ? 1 : sPackVol) * Convert.ToDecimal(txtR.Text))) + " AS StockItemActualCost, StockItem.StockItem_MinimumStock, StockItem.StockItem_MaximumStock, StockItem.StockItem_OrderQuantity, StockItem.StockItem_OrderRounding, StockItem.StockItem_OrderDynamic, StockItem.StockItem_Disabled, StockItem.StockItem_Discontinued, ";
			//sql = sql & "SELECT StockItem.StockItem_BrandItemID, StockItem.StockItem_SupplierID, StockItem.StockItem_ShrinkID, StockItem.StockItem_PackSizeID, StockItem.StockItem_PricingGroupID, StockItem.StockItem_StockGroupID, StockItem.StockItem_VatID, StockItem.StockItem_DepositID, [StockItem].[StockItem_Name] & ' # " & Format(Date, "dd/mm") & "' AS StockItemName, [StockItem].[StockItem_ReceiptName] & ' # " & Format(Date, "dd/mm") & "' AS StockItemReceiptName, StockItem.StockItem_Quantity, " & CCur(txtR.Text) & " AS StockItemListCost, " & CCur(txtR.Text) & " AS StockItemActualCost, StockItem.StockItem_MinimumStock, StockItem.StockItem_MaximumStock, StockItem.StockItem_OrderQuantity, StockItem.StockItem_OrderRounding, StockItem.StockItem_OrderDynamic, StockItem.StockItem_Disabled, StockItem.StockItem_Discontinued, StockItem.StockItem_SupplierCode, StockItem.StockItem_ActualCostChange, StockItem.StockItem_PriceSetID, "
			sql = sql + "StockItem.StockItem_SupplierCode, StockItem.StockItem_ActualCostChange, StockItem.StockItem_PriceSetID, StockItem.StockItem_LastCost, StockItem.StockItem_Parameters, StockItem.StockItem_Fractions, StockItem.StockItem_NegSale, StockItem.StockItem_VariablePrice, StockItem.StockItem_NonWeighted, StockItem.StockItem_PrintLocationID, StockItem.StockItem_RecipeType, StockItem.StockItem_PrintGroupID, StockItem.StockItem_SerialTracker, StockItem.StockItem_SBarcode, StockItem.StockItem_SShelf, StockItem.StockItem_ReportID, StockItem.StockItemOrderType, StockItem.StockItem_ATItem, StockItem.StockItem_ATStockTypeID, StockItem.StockItem_ExpiryDays ";
			sql = sql + "From StockItem WHERE (((StockItem.StockItemID)=" + sID + "));";
			//sql = "INSERT INTO StockItem (StockItem_BrandItemID, StockItem_SupplierID, StockItem_ShrinkID, StockItem_PackSizeID, StockItem_PricingGroupID, StockItem_StockGroupID, StockItem_VatID, StockItem_DepositID, StockItem_Name, StockItem_ReceiptName, StockItem_Quantity, StockItem_ListCost, StockItem_ActualCost, StockItem_MinimumStock, StockItem_MaximumStock, StockItem_OrderQuantity, StockItem_OrderRounding, StockItem_OrderDynamic, StockItem_Disabled, StockItem_Discontinued, StockItem_QuickKey, StockItem_NegSale, StockItem_PrintLocationID, StockItem_SerialTracker, StockItem_ReportID, StockItem_ATItem, StockItem_ATStockTypeID) VALUES ("
			//sql = sql & gBrandItem & ", " & 2 & ", " & 1 & ", " & 1 & ", " & rsPriceG(0) & ", " & rsStockG(0) & ", 2, " & rsDep(0) & ", '" & csvDESC & "', '" & csvDESC & "', " & Replace(1, ",", "") & ", " & Replace(aCost, ",", "") & ", " & Replace(aCost, ",", "") & ", 0, 0, " & CCur(1) & ", 1, 0, 0, 0, '" & csvBarcode & "', True, 1, True, " & rsReportG(0) & ", True, 0)"
			Debug.Print(sql);
			modRecordSet.cnnDB.Execute(sql);

			sql = "SELECT Max(StockItem.StockItemID) AS id FROM StockItem;";
			rs = modRecordSet.getRS(ref sql);
			gStockItem = rs.Fields("id").Value;
			lgetNewID = gStockItem;
			modRecordSet.cnnDB.Execute("UPDATE StockItem, Company SET StockItem.StockItem_LastCost = [Company_DayEndID] WHERE (((StockItem.StockItemID)=" + gStockItem + "));");
			modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN BrandItemSupplier ON (StockItem.StockItem_SupplierID = BrandItemSupplier.BrandItemSupplier_SupplierID) AND (StockItem.StockItem_BrandItemID = BrandItemSupplier.BrandItemSupplier_BrandItemID) SET StockItem.StockItem_SupplierCode = [BrandItemSupplier]![BrandItemSupplier_Code] WHERE (((StockItem.StockItemID)=" + gStockItem + "));");
			//Multi Warehouse change
			//cnnDB.Execute "INSERT INTO DayEndStockItemLnk ( DayEndStockItemLnk_DayEndID, DayEndStockItemLnk_StockItemID, DayEndStockItemLnk_Quantity, DayEndStockItemLnk_QuantitySales, DayEndStockItemLnk_QuantityShrink, DayEndStockItemLnk_QuantityGRV, DayEndStockItemLnk_ListCost, DayEndStockItemLnk_ActualCost, DayEndStockItemLnk_Warehouse ) SELECT Company.Company_DayEndID, " & gStockItem & " AS stock, 0, 0, 0, 0, " & rsCostPrice("StockItem_ListCost") & ", " & rsCostPrice("StockItem_ListCost") & ", Warehouse.WarehouseID FROM Company, Warehouse;"
			modRecordSet.cnnDB.Execute("INSERT INTO DayEndStockItemLnk ( DayEndStockItemLnk_DayEndID, DayEndStockItemLnk_StockItemID, DayEndStockItemLnk_Quantity, DayEndStockItemLnk_QuantitySales, DayEndStockItemLnk_QuantityShrink, DayEndStockItemLnk_QuantityGRV, DayEndStockItemLnk_ListCost, DayEndStockItemLnk_ActualCost, DayEndStockItemLnk_Warehouse ) SELECT Company.Company_DayEndID, " + gStockItem + " AS stock, 0, 0, 0, 0, " + (Convert.ToDecimal((sPackVol == 0 ? 1 : sPackVol) * Convert.ToDecimal(txtR.Text))) + ", " + (Convert.ToDecimal((sPackVol == 0 ? 1 : sPackVol) * Convert.ToDecimal(txtR.Text))) + ", Warehouse.WarehouseID FROM Company, Warehouse;");
			modRecordSet.cnnDB.Execute("INSERT INTO WarehouseStockItemLnk ( WarehouseStockItemLnk_WarehouseID, WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk_Quantity ) SELECT Warehouse.WarehouseID, " + gStockItem + ", 0 FROM Warehouse;");
			modRecordSet.cnnDB.Execute("INSERT INTO tempStockItem ( tempStockItemID ) SELECT StockItem.StockItemID FROM tempStockItem RIGHT JOIN StockItem ON tempStockItem.tempStockItemID = StockItem.StockItemID WHERE (((tempStockItem.tempStockItemID) Is Null) AND ((StockItem.StockItemID)=" + gStockItem + "));");
			modRecordSet.cnnDB.Execute("DELETE FROM systemStockItemPricing;");
			modRecordSet.cnnDB.Execute("INSERT INTO systemStockItemPricing ( systemStockItemPricing ) VALUES (" + gStockItem + ")");

			//cnnDB.Execute "INSERT INTO Catalogue (Catalogue_StockItemID,Catalogue_Quantity,Catalogue_Barcode) VALUES (" & gStockItem & ",1,'" & buildItemBarcode(gStockItem, 1) & "')"
			//UPGRADE_WARNING: Couldn't resolve default property of object gStockItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modRecordSet.cnnDB.Execute("INSERT INTO Catalogue (Catalogue_StockItemID,Catalogue_Quantity,Catalogue_Barcode) VALUES (" + gStockItem + ",1,'" + rsCostPrice.Fields("Catalogue_Barcode").Value + Strings.Format(DateAndTime.Today, "ddmmyy") + "')");

			//Override
			modRecordSet.cnnDB.Execute("INSERT INTO PriceChannelLnk ( PriceChannelLnk_StockItemID, PriceChannelLnk_Quantity, PriceChannelLnk_ChannelID, PriceChannelLnk_Price ) VALUES (" + gStockItem + "," + 1 + ",1," + sSellPrice + ")");
			modRecordSet.cnnDB.Execute("UPDATE PriceChannelLnk SET PriceChannelLnk_Price=" + sSellPrice + " WHERE PriceChannelLnk_StockItemID = " + gStockItem + ";");
			newATItem = true;
			frmUpdateCatalogue catalog = new frmUpdateCatalogue();
			catalog.Show();

			return;
			cErrorHndlr:
			Interaction.MsgBox(Err().Description);
			 // ERROR: Not supported in C#: ResumeStatement


		}

		private void cmdProc_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int QtyD_P_GRV = 0;
			int QtyD_P = 0;
			short x = 0;
			//If txtR.Text = "" Then txtR.Text = 0
			//If CCur(txtR.Text) > 0 Then
			//Else
			//    MsgBox "Please enter the Price Per Kg."
			//    txtR.SetFocus
			//    Exit Sub
			//End If

			loading = true;
			bFinish = true;
			 // ERROR: Not supported in C#: OnErrorStatement

			//If gridItem.Col = 1 Then
			//    rowNo = gridItem.row
			QtyD_P = 0;
			QtyD_P_GRV = 0;
			var _with1 = gridItem;
			for (x = 1; x <= (_with1.RowCount - 1); x++) {
				_with1.row = x;
				_with1.Col = 3;
				QtyD_P = QtyD_P + Convert.ToDecimal(_with1.Text);
			}
			TotalQTY.Text = Strings.FormatNumber(QtyD_P, 2);
			//TotalQTY = FormatNumber(QtyD_P_GRV, 4)
			//If TotalQTY > AvailGRV Then
			//    MsgBox "Insufficient Qty in Main Stock Item! Please correct your last entered QTY."
			//End If
			//gridItem.row = rowNo
			//End If

			loading = false;

			if (string.IsNullOrEmpty(TotalQTY.Text))
				TotalQTY.Text = Convert.ToString(0);
			if (Convert.ToDecimal(TotalQTY.Text) > 0) {
			} else {
				Interaction.MsgBox("Please enter the QTY you wish to make.");
				bFinish = false;
				return;
			}

			if (string.IsNullOrEmpty(lblB.Text))
				lblB.Text = Convert.ToString(0);
			//txtZ.Text = AvailGRV
			if (Convert.ToDecimal(TotalQTY.Text) > Convert.ToDecimal(lblB.Text)) {
				Interaction.MsgBox("Total QTY after production is more then Available Market/GRV QTY. Call Your Supervisor for Override?", MsgBoxStyle.Question + MsgBoxStyle.ApplicationModal + MsgBoxStyle.DefaultButton1, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				if (My.MyProject.Forms.frmOverride.sOverride(ref 0)) {
					//update the GRV processer person id
					//cnnDB.Execute "UPDATE GRV SET GRV.GRV_OverridePersonID = " & lMgrID & " WHERE (((GRV.GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & "));"
				} else {
					Interaction.MsgBox("You do not have Supervisor rights. Call Your Supervisor for Override?", MsgBoxStyle.Question + MsgBoxStyle.ApplicationModal + MsgBoxStyle.DefaultButton1, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					bFinish = false;
					return;
				}
				//Exit Sub
			}

			//Serial chk
			if (checkSecurity() == true) {
				cmdTotal_Click(cmdTotal, new System.EventArgs());
				if (updateProc())
					this.Close();
			} else {
				if (timeOver()) {
					Interaction.MsgBox("Your 4VEG Production Software has expired." + Constants.vbCrLf + "Please contact your 4POS representative or www.4pos.co.za.", MsgBoxStyle.Critical, "4VEG Production is not Registered");
					bFinish = false;
					return;
				} else {
					cmdTotal_Click(cmdTotal, new System.EventArgs());
					if (updateProc())
						this.Close();
				}
			}

			bFinish = false;

		}

		private bool updateProc()
		{
			bool functionReturnValue = false;
			string strFldName = null;
			 // ERROR: Not supported in C#: OnErrorStatement


			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rj = default(ADODB.Recordset);
			ADODB.Recordset RSadoPrimary = default(ADODB.Recordset);
			ADODB.Recordset rsBarcode = default(ADODB.Recordset);
			Scripting.FileSystemObject FSO = new Scripting.FileSystemObject();
			string sql = null;
			decimal lQuantity = default(decimal);
			int getNewID = 0;

			//If checkSecurity = True Then
			//    'for Security Code
			//    If bolSecurityCode = True Then
			//        'loadCustom
			//Set rs = getRS("SELECT * from VegTestItem Where VegTestItem_VegTestID = " & testID & ";")
			rs = modRecordSet.getRS(ref "SELECT VegTestItem.*, StockItem.StockItemID, StockItem.StockItem_SBarcode FROM VegTestItem INNER JOIN StockItem ON VegTestItem.VegTestItem_StockItemID = StockItem.StockItemID WHERE (((VegTestItem.VegTestItem_VegTestID)=" + testID + "));");
			if (rs.RecordCount > 0) {
				//UPGRADE_WARNING: Couldn't resolve default property of object strFldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				strFldName = "HandHeldID Number,Handheld_Barcode Text(50), Quantity Currency";
				modRecordSet.cnnDB.Execute("CREATE TABLE " + "HandheldVegTest" + " (" + strFldName + ")");
				System.Windows.Forms.Application.DoEvents();
				sql = "INSERT INTO HandheldVegTest (HandHeldID,Handheld_Barcode,Quantity) VALUES (" + gStockItemID + ", 0, " + (0 - (Convert.ToDecimal(TotalQTY.Text))) + ")";
				modRecordSet.cnnDB.Execute(sql);
				System.Windows.Forms.Application.DoEvents();
				while (rs.EOF == false) {
					if (rs.Fields("VegTestItem_PerWeightYield").Value > 0) {
						getNewID = 0;
						if (rs.Fields("StockItem_SBarcode").Value == true) {
							getNewID = rs.Fields("VegTestItem_StockItemID").Value;
							//create new
							//CreateVegItems rs("VegTestItem_StockItemID"), rs("VegTestItem_ActualSellPriceIncl"), rs("VegTestItem_PackSize"), getNewID   ' csvSplit(0), csvSplit(1), csvSplit(2), CCur(csvSplit(3)), CCur(csvSplit(4)), csvSplit(6), csvSplit(7)
						} else {
							getNewID = rs.Fields("VegTestItem_StockItemID").Value;
						}
						//Stock Adjustment
						sql = "INSERT INTO HandheldVegTest (HandHeldID,Handheld_Barcode,Quantity) VALUES (" + getNewID + ", 0, " + (rs.Fields("VegTestItem_PerWeightYield")).Value + ")";
						modRecordSet.cnnDB.Execute(sql);
					}
					rs.moveNext();
				}
			} else {
				Interaction.MsgBox("This Product does not have any Recipe.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				return functionReturnValue;
			}
			//    Else
			//        MsgBox "New Stock Items cannot be added due to Security Restrictions." & vbCrLf & "Please contact your 4POS representative or www.4pos.co.za.", vbCritical, "4POS Expired"
			//        Exit Function
			//    End If
			//    'for Security Code
			//Else
			//    Set rs = getRS("SELECT * From Company")
			//    If rs.RecordCount Then
			//        If IsNull(rs("Company_TerminateDate")) Then
			//            cnnDB.Execute "UPDATE Company SET Company_TerminateDate = #" & Date & "#;"
			//            Set rs = getRS("SELECT * From Company")
			//        End If
			//        If Date >= CDate(rs("Company_TerminateDate") + 15) Then
			//            MsgBox "New Stock Items may only be added with registered versions of your 4POS system." & vbCrLf & "Please contact your 4POS representative or www.4pos.co.za.", vbCritical, "4POS Expired"
			//            Exit Function
			//        Else
			//            'loadCustom
			//            Set rs = getRS("SELECT * from VegTestItem Where VegTestItem_VegTestID = " & testID & ";")
			//            If rs.RecordCount > 0 Then
			//                    strFldName = "HandHeldID Number,Handheld_Barcode Text(50), Quantity Currency"
			//                    cnnDB.Execute "CREATE TABLE " & "HandheldVegTest" & " (" & strFldName & ")"
			//                    DoEvents
			//                    sql = "INSERT INTO HandheldVegTest (HandHeldID,Handheld_Barcode,Quantity) VALUES (" & gStockItemID & ", 0, " & (0 - (CCur(TotalQTY.Text) / cPackVol)) & ")"
			//                    cnnDB.Execute sql
			//                    DoEvents
			//                    Do While rs.EOF = False
			//                        If rs("VegTestItem_CutWeight") > 0 Then
			//                            getNewID = 0
			//                            'create new
			//                            CreateVegItems rs("VegTestItem_StockItemID"), rs("VegTestItem_ActualSellPriceIncl"), rs("VegTestItem_PackSize"), getNewID  ' csvSplit(0), csvSplit(1), csvSplit(2), CCur(csvSplit(3)), CCur(csvSplit(4)), csvSplit(6), csvSplit(7)
			//                            'Stock Adjustment
			//                            sql = "INSERT INTO HandheldVegTest (HandHeldID,Handheld_Barcode,Quantity) VALUES (" & getNewID & ", 0, " & (rs("VegTestItem_CutWeight")) & ")"
			//                            cnnDB.Execute sql
			//                        End If
			//                        rs.moveNext
			//                    Loop
			//            Else
			//                MsgBox "This Product does not have any Recipe.", vbApplicationModal + vbInformation + vbOKOnly, App.title
			//                Exit Function
			//            End If
			//        End If
			//    End If
			//End If
			//MsgBox "Items activated"

			//---------------------------------------------
			modRecordSet.cnnDB.Execute("INSERT INTO StockGroup (StockGroup_Name) VALUES ('HandheldVegTest')");
			modApplication.stTableName = "HandheldVegTest";
			rj = modRecordSet.getRS(ref "SELECT StockGroup.StockGroupID, StockGroup.StockGroup_Name From StockGroup WHERE StockGroup.StockGroup_Name = 'HandheldVegTest';");
			gID = rj.Fields("StockGroupID").Value;

			//snap shot
			modRecordSet.cnnDB.Execute("UPDATE Company SET Company.Company_StockTakeDate = now();");
			//Multi Warehouse change
			modRecordSet.cnnDB.Execute("DELETE FROM StockTake WHERE (StockTake_WarehouseID > 0)");
			modRecordSet.cnnDB.Execute("INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment ) SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, 0 AS quantity, 0 AS adjustment FROM WarehouseStockItemLnk;");
			modRecordSet.cnnDB.Execute("UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)>0));");
			//Multi Warehouse change
			// cnnDB.Execute "UPDATE StockTake SET StockTake.StockTake_Adjustment = [StockTake]![StockTake_Quantity];"
			modRecordSet.cnnDB.Execute("DELETE FROM StockTakeDeposit");
			modRecordSet.cnnDB.Execute("INSERT INTO StockTakeDeposit ( StockTakeDeposit_WarehouseID, StockTakeDeposit_DepositID, StockTakeDeposit_DepositTypeID, StockTakeDeposit_Quantity, StockTakeDeposit_Adjustment ) SELECT WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity FROM WarehouseDepositItemLnk INNER JOIN DISPLAY_Deposits ON (DISPLAY_Deposits.type = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = DISPLAY_Deposits.DepositID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID = DISPLAY_Deposits.WarehouseID);");
			//snap shot

			RSadoPrimary = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, " + modApplication.stTableName + ".Quantity, StockItem.StockItem_Quantity," + modApplication.stTableName + ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" + modApplication.stTableName + " INNER JOIN StockItem ON " + modApplication.stTableName + ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " + gID + ") And ((Warehouse.WarehouseID) = 2)) ORDER BY StockItem.StockItem_Name");
			if (RSadoPrimary.RecordCount > 0) {
				while (RSadoPrimary.EOF == false) {
					lQuantity = RSadoPrimary.Fields("Quantity").Value;
					//lQuantity = RSadoPrimary("Quantity") - RSadoPrimary("StockTake_Quantity").OriginalValue
					modRecordSet.cnnDB.Execute("UPDATE StockTake SET StockTake.StockTake_Quantity = " + lQuantity + " WHERE (((StockTake.StockTake_StockItemID)=" + RSadoPrimary.Fields("StockTake_StockItemID").Value + ") AND ((StockTake.StockTake_WarehouseID)=2));");
					modRecordSet.cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" + lQuantity + ") WHERE (((StockTake.StockTake_StockItemID)=" + RSadoPrimary.Fields("StockTake_StockItemID").Value + ") AND ((StockTake.StockTake_WarehouseID)=2));");
					//cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = 0 WHERE (((StockTake.StockTake_StockItemID)=" & RSadoPrimary("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
					modRecordSet.cnnDB.Execute("UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" + lQuantity + ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" + RSadoPrimary.Fields("StockTake_StockItemID").Value + "));");
					RSadoPrimary.moveNext();
				}
			}

			//Update POS
			//Set rsPri = getRS("SELECT GRVItem.GRVItem_StockItemID, (GRVItem.GRVItem_Quantity*GRVItem_PackSize) AS GRVItem_Quantity, StockItem.StockItem_SBarcode,StockItem.StockItem_SShelf FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE GRVItem_GRVID = " & Val(frmGRV.adoPrimaryRS("GRVID")) & " AND (StockItem_SBarcode = True Or StockItem_SShelf = True)")
			//Set rsBarcode = getRS("SELECT HandheldVegTest.HandHeldID AS GRVItem_StockItemID, HandheldVegTest.Quantity AS GRVItem_Quantity, StockItem.StockItem_SBarcode, StockItem.StockItem_SShelf FROM HandheldVegTest INNER JOIN StockItem ON HandheldVegTest.HandHeldID = StockItem.StockItemID WHERE (((HandheldVegTest.Quantity)>0));")
			rsBarcode = modRecordSet.getRS(ref "SELECT HandheldVegTest.HandHeldID AS GRVItem_StockItemID, HandheldVegTest.Quantity AS GRVItem_Quantity, StockItem.StockItem_SBarcode, StockItem.StockItem_SShelf FROM HandheldVegTest INNER JOIN StockItem ON HandheldVegTest.HandHeldID = StockItem.StockItemID WHERE (((HandheldVegTest.Quantity)>0) AND ((StockItem.StockItem_SBarcode)=True)) OR (((StockItem.StockItem_SShelf)=True));");
			//Write file
			if (rsBarcode.RecordCount) {
				if (FSO.FileExists(modRecordSet.serverPath + "ShelfBarcode.dat"))
					FSO.DeleteFile(modRecordSet.serverPath + "ShelfBarcode.dat", true);
				rsBarcode.save(modRecordSet.serverPath + "ShelfBarcode.dat", ADODB.PersistFormatEnum.adPersistADTG);
				modApplication.grvPrin = true;
				//If MsgBox("Do you want to do Shelf/Barcode Printing on flagged StockItems?", vbQuestion + vbYesNo + vbApplicationModal + vbDefaultButton1, App.title) = vbYes Then

				modApplication.blMEndUpdatePOS = true;
				modApplication.blChangeOnlyUpdatePOS = true;
				My.MyProject.Forms.frmUpdatePOScriteria.ShowDialog();
				modApplication.blChangeOnlyUpdatePOS = false;
				modApplication.blMEndUpdatePOS = false;

				My.MyProject.Forms.frmBarcode.ShowDialog();
			}

			modRecordSet.cnnDB.Execute("DROP TABLE HandheldVegTest");
			modRecordSet.cnnDB.Execute("DELETE * FROM StockGroup WHERE StockGroup_Name ='HandheldVegTest'");
			modRecordSet.cnnDB.Execute("UPDATE VegTest SET VegTest_VegTestStatusID = 3 WHERE (VegTestID = " + testID + ")");
			//cnnDB.Execute "UPDATE VegTest INNER JOIN GRVItem ON (VegTest.VegTest_GRVID = GRVItem.GRVItem_GRVID) AND (VegTest.VegTest_MainItemID = GRVItem.GRVItem_StockItemID) SET GRVItem.GRVItem_QuantityUsedKG = " & CCur(TotalQTY.Text) & " WHERE (((VegTest.VegTestID)=" & testID & "));"

			Interaction.MsgBox("Veg Production Test process has been completed.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
			functionReturnValue = true;
			return functionReturnValue;
			UpdateErr:

			Interaction.MsgBox(Err().Description);
			functionReturnValue = true;
			return functionReturnValue;
		}

		private string getSerialNumber()
		{
			string functionReturnValue = null;
			Scripting.FileSystemObject FSO = new Scripting.FileSystemObject();
			Scripting.Folder fsoFolder = default(Scripting.Folder);
			Scripting.Drive fsoDrive = default(Scripting.Drive);
			functionReturnValue = "";
			if (FSO.FolderExists(modRecordSet.serverPath)) {
				fsoFolder = FSO.GetFolder(modRecordSet.serverPath);
				functionReturnValue = Convert.ToString(fsoFolder.Drive.SerialNumber);
			}
			return functionReturnValue;
		}

		private string Encrypt(string secret, string password)
		{
			int l = 0;
			short x = 0;
			string Char_Renamed = null;
			l = Strings.Len(password);
			for (x = 1; x <= Strings.Len(secret); x++) {
				Char_Renamed = Convert.ToString(Strings.Asc(Strings.Mid(password, (x % l) - l * Convert.ToInt16((x % l) == 0), 1)));
				Strings.Mid(secret, x, 1) = Strings.Chr(Strings.Asc(Strings.Mid(secret, x, 1)) ^ Char_Renamed);
			}
			return secret;
		}

		private bool bolSecurityCode()
		{
			bool functionReturnValue = false;
			string lCode = null;
			string leCode = null;
			string lPassword = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			short x = 0;

			short intDate = 0;
			short intYear = 0;
			short intMonth = 0;

			string stPass = null;
			string givPass = null;

			 // ERROR: Not supported in C#: OnErrorStatement


			functionReturnValue = false;
			if (modRecordSet.openConnection()) {
				rs = modRecordSet.getRS(ref "SELECT * From Company");
				if (rs.RecordCount) {
					if (Information.IsNumeric(rs.Fields("Company_PosString").Value)) {
						modApplication.gSecKey = rs.Fields("Company_PosString").Value;
						if (Strings.Len(rs.Fields("Company_PosString").Value) == 13) {
							functionReturnValue = true;
							return functionReturnValue;
						}
					}

					//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					if (Information.IsDBNull(rs.Fields("Company_PosString").Value) | rs.Fields("Company_PosString").Value == "0") {
						functionReturnValue = true;
						return functionReturnValue;
					}

					if (Information.IsNumeric(rs.Fields("Company_PosString").Value)) {
						intYear = Convert.ToInt16(Strings.Left(rs.Fields("Company_PosString").Value, 2));
						intMonth = Convert.ToInt16(Strings.Mid(rs.Fields("Company_PosString").Value, 3, 2));
						intDate = Convert.ToInt16(Strings.Mid(rs.Fields("Company_PosString").Value, 5, 2));

						if ((intDate / 2) == System.Math.Round(intDate / 2)) {
							intDate = intDate / 2;
						} else {
							return functionReturnValue;
						}


						if ((intMonth / 2) == System.Math.Round(intMonth / 2)) {
							intMonth = intMonth / 2;
						} else {
							return functionReturnValue;
						}


						if ((intYear / 2) == System.Math.Round(intYear / 2)) {
							intYear = intYear / 2;
						} else {
							return functionReturnValue;
						}

						stPass = "20";
						if (Strings.Len(Convert.ToString(intYear)) == 1)
							stPass = stPass + "0" + intYear + "/";
						else
							stPass = stPass + intYear + "/";
						if (Strings.Len(Convert.ToString(intMonth)) == 1)
							stPass = stPass + "0" + intMonth + "/";
						else
							stPass = stPass + intMonth + "/";
						if (Strings.Len(Convert.ToString(intDate)) == 1)
							stPass = stPass + "0" + intDate;
						else
							stPass = stPass + intDate;

						if (Information.IsDate(stPass)) {
							if (Convert.ToDateTime(stPass) >= DateAndTime.Today) {
								functionReturnValue = true;
								return functionReturnValue;
							}
						}

						//If Left(rs("Company_PosString"), 2) >= Year(Date) And Mid(rs("Company_PosString"), 3, 2) >= Month(Date) And Mid(rs("Company_PosString"), 5) >= Day(Date) Then
						//    bolSecurityCode = True
						//    Exit Function
						//Else
						//    Exit Function
						//End If

					} else {
						return functionReturnValue;
					}

				}
			} else {
				Interaction.MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS");
				System.Environment.Exit(0);
			}
			return functionReturnValue;
			Hell_Error:

			Interaction.MsgBox(Err().Number + " - " + Err().Description, MsgBoxStyle.Exclamation);
			return functionReturnValue;
			return functionReturnValue;
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
			object strTmp = null;
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
					//strTmp = cCrypto.ConvertStringFromHex(Left(rs("Company_ResMS"), 6))
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
					if (cCrypto.Decrypt(2, 1)) {
						System.Windows.Forms.Application.DoEvents();
						arData = cCrypto.OutputData.Clone();
						strSerial = cCrypto.ByteArrayToString(arData);
					}


					if (Strings.Left(strSerial, 3) == "veg") {
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
								if (Convert.ToDateTime(stPass) >= (System.Date.FromOADate(DateAndTime.Today.ToOADate() - 31))) {
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
			string lCode = null;
			string leCode = null;
			string lPassword = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			short x = 0;
			functionReturnValue = false;
			//If openConnection() Then
			rs = modRecordSet.getRS(ref "SELECT * From Company");

			if (rs.RecordCount) {
				//if old database don't chk secuirty
				if (rs.Fields.Count <= 55){functionReturnValue = false;return functionReturnValue;}

				if (rs.Fields("Company_ResMN").Value < 5) {
					if (rs.Fields("Company_ResMN").Value == 2)
						Interaction.MsgBox("You have 1 more Calculations to run before the demo software expires." + Constants.vbCrLf + "Please contact your 4POS representative or www.4pos.co.za.", MsgBoxStyle.Critical, "4VEG Production is not Registered");
					modRecordSet.cnnDB.Execute("UPDATE Company SET Company_ResMN = Company_ResMN+1;");
					functionReturnValue = false;
				} else if (rs.Fields("Company_ResMN").Value >= 5) {
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

		private bool checkSecurityPOS()
		{
			bool functionReturnValue = false;
			string lCode = null;
			string leCode = null;
			string lPassword = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			short x = 0;
			functionReturnValue = false;
			if (modRecordSet.openConnection()) {
				rs = modRecordSet.getRS(ref "SELECT * From Company");
				if (rs.RecordCount) {
					if (Information.IsNumeric(rs.Fields("Company_Code").Value)) {
						modApplication.gSecKey = rs.Fields("Company_Code").Value;

						if (Strings.Len(rs.Fields("Company_Code").Value) == 13) {
							functionReturnValue = true;
							return functionReturnValue;
						}
					}
					lPassword = "pospospospos";
					lCode = getSerialNumber();
					if (lCode == "0" & Strings.LCase(Strings.Left(modRecordSet.serverPath, 3)) != "c:\\" & !string.IsNullOrEmpty(rs.Fields("Company_Code").Value)) {
						functionReturnValue = true;
					} else {
						leCode = Encrypt(lCode, lPassword);
						for (x = 1; x <= Strings.Len(leCode); x++) {
							if (Strings.Asc(Strings.Mid(leCode, x, 1)) < 33) {
								leCode = Strings.Left(leCode, x - 1) + Strings.Chr(33) + Strings.Mid(leCode, x + 1);
							}
						}

						if (rs.Fields("Company_Code").Value == leCode) {
							//If IsNull(rs("Company_TerminateDate")) Then
							functionReturnValue = true;
							return functionReturnValue;
							//Else
							//    If Date > rs("Company_TerminateDate") Then
							//        cnnDB.Execute "UPDATE Company SET Company.Company_Code = '';"
							//        checkSecurityPOS = False
							//   End If
							//End If
						} else {
							//txtCompany.Text = rs("Company_Name")
							//txtCompany.SelStart = 0
							//txtCompany.SelLength = 999
							//show 1
						}

					}
				} else {
					Interaction.MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS");
					System.Environment.Exit(0);
				}
			} else {
				Interaction.MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS");
				System.Environment.Exit(0);
			}
			return functionReturnValue;
		}


		private bool updateProc_OLD()
		{
			bool functionReturnValue = false;
			string strFldName = null;
			 // ERROR: Not supported in C#: OnErrorStatement


			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rj = default(ADODB.Recordset);
			ADODB.Recordset RSadoPrimary = default(ADODB.Recordset);
			string sql = null;
			decimal lQuantity = default(decimal);

			rs = modRecordSet.getRS(ref "SELECT * from VegTestItem Where VegTestItem_VegTestID = " + testID + ";");

			if (rs.RecordCount > 0) {
				strFldName = "HandHeldID Number,Handheld_Barcode Text(50), Quantity Currency";
				modRecordSet.cnnDB.Execute("CREATE TABLE " + "HandheldVegTest" + " (" + strFldName + ")");
				System.Windows.Forms.Application.DoEvents();
				sql = "INSERT INTO HandheldVegTest (HandHeldID,Handheld_Barcode,Quantity) VALUES (" + gStockItemID + ", 0, " + (0 - Convert.ToDecimal(txtZ.Text)) + ")";
				modRecordSet.cnnDB.Execute(sql);
				System.Windows.Forms.Application.DoEvents();

				while (rs.EOF == false) {
					sql = "INSERT INTO HandheldVegTest (HandHeldID,Handheld_Barcode,Quantity) VALUES (" + rs.Fields("VegTestItem_StockItemID").Value + ", 0, " + (rs.Fields("VegTestItem_CutWeight")).Value + ")";
					modRecordSet.cnnDB.Execute(sql);
					rs.moveNext();
				}

			} else {
				Interaction.MsgBox("This Product does not have any Recipe.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				return functionReturnValue;
			}
			modRecordSet.cnnDB.Execute("INSERT INTO StockGroup (StockGroup_Name) VALUES ('HandheldVegTest')");
			modApplication.stTableName = "HandheldVegTest";
			rj = modRecordSet.getRS(ref "SELECT StockGroup.StockGroupID, StockGroup.StockGroup_Name From StockGroup WHERE StockGroup.StockGroup_Name = 'HandheldVegTest';");
			gID = rj.Fields("StockGroupID").Value;

			//snap shot
			modRecordSet.cnnDB.Execute("UPDATE Company SET Company.Company_StockTakeDate = now();");
			modRecordSet.cnnDB.Execute("DELETE FROM StockTake WHERE (StockTake_WarehouseID = 2)");
			modRecordSet.cnnDB.Execute("INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment ) SELECT StockItem.StockItemID, 2 AS warehouse, 0 AS quantity, 0 AS adjustment FROM StockItem;");
			modRecordSet.cnnDB.Execute("UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));");
			modRecordSet.cnnDB.Execute("DELETE FROM StockTakeDeposit");
			modRecordSet.cnnDB.Execute("INSERT INTO StockTakeDeposit ( StockTakeDeposit_WarehouseID, StockTakeDeposit_DepositID, StockTakeDeposit_DepositTypeID, StockTakeDeposit_Quantity, StockTakeDeposit_Adjustment ) SELECT WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity FROM WarehouseDepositItemLnk INNER JOIN DISPLAY_Deposits ON (DISPLAY_Deposits.type = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = DISPLAY_Deposits.DepositID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID = DISPLAY_Deposits.WarehouseID);");
			//snap shot

			//Set RSadoPrimary = getRS("SELECT StockItem.StockItem_Name, " & stTableName & ".Quantity, StockItem.StockItem_Quantity," & stTableName & ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" & stTableName & " INNER JOIN StockItem ON " & stTableName & ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " & gID & ") And ((Warehouse.WarehouseID) = 2) And ((StockItem.StockItem_Disabled) = False) And ((StockItem.StockItem_Discontinued) = False)) ORDER BY StockItem.StockItem_Name")
			RSadoPrimary = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, " + modApplication.stTableName + ".Quantity, StockItem.StockItem_Quantity," + modApplication.stTableName + ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" + modApplication.stTableName + " INNER JOIN StockItem ON " + modApplication.stTableName + ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " + gID + ") And ((Warehouse.WarehouseID) = 2)) ORDER BY StockItem.StockItem_Name");
			if (RSadoPrimary.RecordCount > 0) {
				while (RSadoPrimary.EOF == false) {
					lQuantity = RSadoPrimary.Fields("Quantity").Value;
					//lQuantity = RSadoPrimary("Quantity") - RSadoPrimary("StockTake_Quantity").OriginalValue
					modRecordSet.cnnDB.Execute("UPDATE StockTake SET StockTake.StockTake_Quantity = " + lQuantity + " WHERE (((StockTake.StockTake_StockItemID)=" + RSadoPrimary.Fields("StockTake_StockItemID").Value + ") AND ((StockTake.StockTake_WarehouseID)=2));");
					modRecordSet.cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" + lQuantity + ") WHERE (((StockTake.StockTake_StockItemID)=" + RSadoPrimary.Fields("StockTake_StockItemID").Value + ") AND ((StockTake.StockTake_WarehouseID)=2));");
					//cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = 0 WHERE (((StockTake.StockTake_StockItemID)=" & RSadoPrimary("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
					modRecordSet.cnnDB.Execute("UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" + lQuantity + ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" + RSadoPrimary.Fields("StockTake_StockItemID").Value + "));");
					RSadoPrimary.moveNext();
				}
			}

			modRecordSet.cnnDB.Execute("DROP TABLE HandheldVegTest");
			modRecordSet.cnnDB.Execute("DELETE * FROM StockGroup WHERE StockGroup_Name ='HandheldVegTest'");

			modRecordSet.cnnDB.Execute("UPDATE VegTest SET VegTest_VegTestStatusID = 3 WHERE (VegTestID = " + testID + ")");
			Interaction.MsgBox("Veg Production Test process has been completed.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);

			functionReturnValue = true;
			return functionReturnValue;
			UpdateErr:

			Interaction.MsgBox(Err().Description);
			functionReturnValue = true;
			return functionReturnValue;
		}

		private void updatePrice()
		{
			modRecordSet.cnnDB.Execute("UPDATE VegTestItem INNER JOIN CatalogueChannelLnk ON VegTestItem.VegTestItem_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Price = VegTestItem.VegTestItem_MRelatedSellPrice WHERE (((VegTestItem.VegTestItem_VegTestID)=" + testID + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=2));");
			modRecordSet.cnnDB.Execute("UPDATE VegTestItem INNER JOIN CatalogueChannelLnk ON VegTestItem.VegTestItem_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Price = VegTestItem.VegTestItem_ActualSellPriceIncl WHERE (((VegTestItem.VegTestItem_VegTestID)=" + testID + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));");
		}

		private void cmdReg_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (My.MyProject.Forms.frmVegTestCode.setupCode() == true) {
				this.Text = Strings.Left(this.Text, Strings.Len(this.Text) - Strings.Len(" - Trial"));
				cmdReg.Visible = false;
			}
		}

		private void cmdTotal_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			decimal QtyD_P = default(decimal);
			 // ERROR: Not supported in C#: OnErrorStatement

			loading = true;
			bFinish = true;
			//Serial chk
			//If checkSecurity = True Then
			//Else
			//    If timeOver Then
			//        MsgBox "Your 4VEG Production Software has expired." & vbCrLf & "Please contact your 4POS representative or www.4pos.co.za.", vbCritical, "4VEG Production is not Registered"
			//        Exit Sub
			//    End If
			//End If

			cmdTotal.Enabled = false;
			//update VegTest master
			modRecordSet.cnnDB.Execute("UPDATE VegTest SET VegTest_PricePerKg = " + Strings.FormatNumber(Convert.ToDecimal(txtR.Text), 4) + ", VegTest_WeightCarcass = " + Strings.FormatNumber(Convert.ToDecimal(txtZ.Text), 4) + ", VegTest_RequiredGP = " + Strings.FormatNumber(Convert.ToDecimal(txtReqGP.Text), 2) + ", VegTest_VAT = " + Strings.FormatNumber(Convert.ToDecimal(txtVAT.Text), 4) + " WHERE (VegTestID = " + testID + ")");

			//lblA.Caption = FormatNumber(CCur(txtR.Text) * CCur(txtZ.Text), 4)

			//lblGP_Y.Caption = FormatNumber(CCur(1 - (CCur(txtReqGP.Text / 100))), 4)


			var _with2 = gridItem;
			for (x = 1; x <= (_with2.RowCount - 1); x++) {
				_with2.row = x;
				_with2.Col = 2;
				modRecordSet.cnnDB.Execute("UPDATE VegTestItem SET VegTestItem_PerWeightYield = " + Strings.FormatNumber(Convert.ToDecimal(_with2.Text), 2) + " WHERE ((VegTestItem_VegTestID = " + testID + ") AND (VegTestItem_StockItemID = " + _with2.get_RowData(x) + ") AND (VegTestItem_Line = " + x + "));");
			}

			QtyD_P = 0;
			var _with3 = gridItem;
			for (x = 1; x <= (_with3.RowCount - 1); x++) {
				_with3.row = x;
				_with3.Col = 3;
				QtyD_P = QtyD_P + Convert.ToDouble(Strings.FormatNumber(Convert.ToDecimal(_with3.Text), 2));
				modRecordSet.cnnDB.Execute("UPDATE VegTestItem SET VegTestItem_MRSellingratio = " + Strings.FormatNumber(Convert.ToDecimal(_with3.Text), 2) + " WHERE ((VegTestItem_VegTestID = " + testID + ") AND (VegTestItem_StockItemID = " + _with3.get_RowData(x) + ") AND (VegTestItem_Line = " + x + "));");
			}
			TotalQTY.Text = Strings.FormatNumber(QtyD_P, 2);

			var _with4 = gridItem;
			for (x = 1; x <= (_with4.RowCount - 1); x++) {
				_with4.row = x;
				_with4.Col = 1;
				//QtyD_P = QtyD_P + CCur(.Text)   ' .TextMatrix(.row, 1) = FormatNumber(CCur(_txtEdit_1.Text) / 100, 4)
				modRecordSet.cnnDB.Execute("UPDATE VegTestItem SET VegTestItem_CutWeight = " + Strings.FormatNumber(Convert.ToDecimal(_with4.Text), 4) + " WHERE ((VegTestItem_VegTestID = " + testID + ") AND (VegTestItem_StockItemID = " + _with4.get_RowData(x) + ") AND (VegTestItem_Line = " + x + "));");
			}
			//lblP.Caption = FormatNumber(QtyD_P, 4)


			//lblB.Caption = FormatNumber(CCur(txtZ.Text) - CCur(lblP.Caption), 4)


			//lblC.Caption = FormatNumber(CCur(lblA.Caption) / CCur(lblP.Caption), 4)


			//lblB_Z.Caption = FormatNumber(CCur(lblB.Caption) / CCur(txtZ.Text), 4)


			//lblX.Caption = FormatNumber(CCur((CCur(txtVAT.Text / 100) + 1)), 4)


			//With gridItem
			//    For x = 1 To (.RowCount - 1)
			//        .row = x
			//        .Col = 1
			//        .TextMatrix(.row, 3) = FormatNumber((CCur(.Text) / CCur(txtZ.Text)) * 100, 4)
			//        '.Col = 3
			//        'QtyD_P = QtyD_P + CCur(.Text)
			//    Next
			//End With
			//QtyD_P = 0
			var _with5 = gridItem;
			for (x = 1; x <= (_with5.RowCount - 1); x++) {
				_with5.row = x;
				_with5.Col = 4;
				//QtyD_P = QtyD_P + CCur(.Text)
				//cnnDB.Execute "UPDATE VegTestItem SET VegTestItem_PerWeightYield = " & FormatNumber(CCur(.Text), 4) & " WHERE ((VegTestItem_VegTestID = " & testID & ") AND (VegTestItem_StockItemID = " & .RowData(x) & ") AND (VegTestItem_Line = " & x & "));"
				modRecordSet.cnnDB.Execute("UPDATE VegTestItem SET VegTestItem_ActualSellPriceIncl = " + Strings.FormatNumber(Convert.ToDecimal(_with5.Text), 2) + " WHERE ((VegTestItem_VegTestID = " + testID + ") AND (VegTestItem_StockItemID = " + _with5.get_RowData(x) + ") AND (VegTestItem_Line = " + x + "));");
			}
			//lblTotalF.Caption = FormatNumber(QtyD_P, 4)
			//total req

			QtyD_P = 0;
			var _with6 = gridItem;
			for (x = 1; x <= (_with6.RowCount - 1); x++) {
				_with6.row = x;
				_with6.Col = 5;
				//QtyD_P = QtyD_P + CCur(.Text)
				QtyD_P = QtyD_P + Convert.ToDouble(Strings.FormatNumber(Convert.ToDecimal(_with6.Text), 2));
				//cnnDB.Execute "UPDATE VegTestItem SET VegTestItem_MRelatedTO = " & FormatNumber(CCur(.Text), 4) & " WHERE ((VegTestItem_VegTestID = " & testID & ") AND (VegTestItem_StockItemID = " & .RowData(x) & ") AND (VegTestItem_Line = " & x & "));"
				modRecordSet.cnnDB.Execute("UPDATE VegTestItem SET VegTestItem_TOActualSellExcl = " + Strings.FormatNumber(Convert.ToDecimal(_with6.Text), 2) + " WHERE ((VegTestItem_VegTestID = " + testID + ") AND (VegTestItem_StockItemID = " + _with6.get_RowData(x) + ") AND (VegTestItem_Line = " + x + "));");
			}
			txtReqGP.Text = Strings.FormatNumber(QtyD_P, 2);
			//total req


			decimal S_A_Q = default(decimal);
			//S_A_Q = FormatNumber(CCur(lblA.Caption) / CCur(lblTotalQ.Caption), 4)


			var _with7 = gridItem;
			for (x = 1; x <= (_with7.RowCount - 1); x++) {
				_with7.row = x;
				_with7.Col = 6;
				//.TextMatrix(.row, 4) = FormatNumber((CCur(.Text) / CCur(lblC.Caption)) * CCur(lblGP_Y.Caption), 4)
				//.TextMatrix(.row, 4) = FormatNumber((CCur(.Text) / CCur(lblC.Caption)) * CCur(S_A_Q), 4)
				modRecordSet.cnnDB.Execute("UPDATE VegTestItem SET VegTestItem_MRelatedSellPrice = " + Strings.FormatNumber(Convert.ToDecimal(_with7.Text), 2) + " WHERE ((VegTestItem_VegTestID = " + testID + ") AND (VegTestItem_StockItemID = " + _with7.get_RowData(x) + ") AND (VegTestItem_Line = " + x + "));");
			}
			QtyD_P = 0;
			var _with8 = gridItem;
			for (x = 1; x <= (_with8.RowCount - 1); x++) {
				_with8.row = x;
				_with8.Col = 7;
				QtyD_P = QtyD_P + Convert.ToDouble(Strings.FormatNumber(Convert.ToDecimal(_with8.Text), 2));
				//cnnDB.Execute "UPDATE VegTestItem SET VegTestItem_MRSellingratio = " & FormatNumber(CCur(.Text), 4) & " WHERE ((VegTestItem_VegTestID = " & testID & ") AND (VegTestItem_StockItemID = " & .RowData(x) & ") AND (VegTestItem_Line = " & x & "));"
				modRecordSet.cnnDB.Execute("UPDATE VegTestItem SET VegTestItem_TOSuggSellPriceExcl = " + Strings.FormatNumber(Convert.ToDecimal(_with8.Text), 2) + " WHERE ((VegTestItem_VegTestID = " + testID + ") AND (VegTestItem_StockItemID = " + _with8.get_RowData(x) + ") AND (VegTestItem_Line = " + x + "));");
			}
			lblGP_Y.Text = Strings.FormatNumber(QtyD_P, 2);
			//total req


			var _with9 = gridItem;
			for (x = 1; x <= (_with9.RowCount - 1); x++) {
				_with9.row = x;
				_with9.Col = 8;
				//.TextMatrix(.row, 7) = FormatNumber(CCur(lblC.Caption) * CCur(.Text), 4)
				//cnnDB.Execute "UPDATE VegTestItem SET VegTestItem_PrimalCostkgExclVAT = " & FormatNumber(CCur(lblC.Caption) * CCur(.Text), 4) & " WHERE ((VegTestItem_VegTestID = " & testID & ") AND (VegTestItem_StockItemID = " & .RowData(x) & ") AND (VegTestItem_Line = " & x & "));"
				modRecordSet.cnnDB.Execute("UPDATE VegTestItem SET VegTestItem_SuggSellPriceIncl = " + Strings.FormatNumber(Convert.ToDecimal(_with9.Text), 2) + " WHERE ((VegTestItem_VegTestID = " + testID + ") AND (VegTestItem_StockItemID = " + _with9.get_RowData(x) + ") AND (VegTestItem_Line = " + x + "));");
			}

			if (Convert.ToDecimal(txtReqGP.Text) > 0 & Convert.ToDecimal(lblGP_Y.Text) > 0) {
				lblB_Z.Text = Convert.ToString(100 - ((Convert.ToDecimal(txtReqGP.Text) / Convert.ToDecimal(lblGP_Y.Text)) * 100));
			}

			cmdTotal.Enabled = true;
			//temporary
			loading = false;
			bFinish = false;

		}

		private void frmVegTest_Load(object sender, System.EventArgs e)
		{
			txtEdit.AddRange(new TextBox[] {
				_txtEdit_0,
				_txtEdit_1,
				_txtEdit_2
			});
		}



		//UPGRADE_WARNING: Event frmVegTest.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void frmVegTest_Resize(System.Object eventSender, System.EventArgs eventArgs)
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
			if (TotalQTY.Visible) {
				TotalQTY.Top = sizeConvertors.twipsToPixels(lTop, false);
				_lblTotal_5.Top = sizeConvertors.twipsToPixels(lTop, false);
				lTop = lTop + sizeConvertors.pixelToTwips(TotalQTY.Height, false) + 30;
			}

			frmTotals.Height = sizeConvertors.twipsToPixels(lTop + 100, false);

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

			gridItem.Height = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(ClientRectangle.Height, false) - sizeConvertors.pixelToTwips(gridItem.Top, false) - sizeConvertors.pixelToTwips(frmTotals.Height, false), false);
			//gridItem.Height = picForm.ScaleHeight - gridItem.Top - frmTotals.Height
			gridItem.Width = frmTotals.Width;
			// ScaleWidth - gridItem.Left
			//gridItem.Width = picForm.ScaleWidth - gridItem.Left

			lWidth = sizeConvertors.pixelToTwips(gridItem.Width, true) - 450;
			for (x = 0; x <= gridItem.Col - 1; x++) {
				lWidth = lWidth - gridItem.get_ColWidth(ref x);
			}
			lWidth = lWidth + gridItem.get_ColWidth(ref 0);
			if (lWidth > 200) {
				gridItem.set_ColWidth(ref 0, ref 6000);
				//lWidth
			} else {
				gridItem.set_ColWidth(ref 0, ref 6000);
			}
			//gridItem_EnterCell
			if (gridItem.RowCount > 1) {
				gridItem.Height = sizeConvertors.twipsToPixels((gridItem.RowCount * gridItem.get_RowHeight(ref 1)) + (gridItem.get_RowHeight(ref 0) - 100), false);
				// ScaleHeight - gridItem.Top - frmTotals.Height
			}
			gridItem.Top = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(gridItem.Top, false) + 20, false);
			picTotal.Top = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(gridItem.Top, false) + sizeConvertors.pixelToTwips(gridItem.Height, false), false);
			//+ 20
			picTotal.Left = gridItem.Left;
		}

		private void setup()
		{
			loading = true;
			//    Dim lDOM As DOMDocument
			//    Dim lNode As IXMLDOMNode
			//    Dim lNodeList As IXMLDOMNodeList
			//lblSupplier.Caption = frmGRV.adoPrimaryRS("Supplier_Name") & "(" & frmGRV.adoPrimaryRS("PurchaseOrder_Reference") & ")"
			//lblReturns.Visible = orderType

			var _with10 = gridItem;
			gridItem.RowCount = 1;
			gridItem.row = 0;

			gridItem.Col = 9;

			gridItem.set_RowHeight(ref ref 0, ref ref 650);
			//430
			gridItem.Col = 1;
			//colTotalExclusive
			//gridItem.CellFontBold = True
			gridItem.set_TextMatrix(ref ref 0, ref ref 1, ref ref "New QTY");
			//"Cut Weight"
			gridItem.set_colAlignment(ref ref 1, ref ref 7);
			gridItem.set_ColWidth(ref ref 1, ref ref 1000);

			gridItem.Col = 2;
			//colTotalInclusive
			//gridItem.CellFontBold = True
			gridItem.set_TextMatrix(ref ref 0, ref ref 2, ref ref "Qty Packed");
			gridItem.set_colAlignment(ref ref 2, ref ref 7);
			gridItem.set_ColWidth(ref ref 2, ref ref 1000);

			gridItem.Col = 3;
			//colExclusive
			//gridItem.CellFontBold = True
			gridItem.set_TextMatrix(ref ref 0, ref ref 3, ref ref "Bags Used");
			gridItem.set_colAlignment(ref ref 3, ref ref 7);
			gridItem.set_ColWidth(ref ref 3, ref ref 1000);

			gridItem.Col = 4;
			//colInclusive
			//gridItem.CellFontBold = True
			gridItem.set_TextMatrix(ref ref 0, ref ref 4, ref ref "COST");
			gridItem.set_colAlignment(ref ref 4, ref ref 7);
			gridItem.set_ColWidth(ref ref 4, ref ref 1000);


			gridItem.Col = 5;
			//colVAT
			//gridItem.CellFontBold = True
			gridItem.set_TextMatrix(ref ref 0, ref ref 5, ref ref "Total Cost");
			gridItem.set_colAlignment(ref ref 5, ref ref 7);
			gridItem.set_ColWidth(ref ref 5, ref ref 1000);

			gridItem.Col = 6;
			//colCode
			//gridItem.CellFontBold = True
			gridItem.set_TextMatrix(ref ref 0, ref ref 6, ref ref "SELLING");
			gridItem.set_colAlignment(ref ref 6, ref ref 7);
			gridItem.set_ColWidth(ref ref 6, ref ref 1000);

			gridItem.Col = 7;
			//colName
			//gridItem.CellFontBold = True
			gridItem.set_TextMatrix(ref ref 0, ref ref 7, ref ref "Total Selling");
			gridItem.set_colAlignment(ref ref 7, ref ref 7);
			gridItem.set_ColWidth(ref ref 7, ref ref 1000);

			gridItem.Col = 8;
			//colBrokenPack
			//gridItem.CellFontBold = True
			gridItem.set_TextMatrix(ref ref 0, ref ref 8, ref ref "GP%");
			gridItem.set_colAlignment(ref ref 8, ref ref 7);
			gridItem.set_ColWidth(ref ref 8, ref ref 1000);


			loading = false;
		}

		private void getRecItems(ref bool retInfo = false)
		{
			int colQuantity = 0;
			decimal colPosPrice = default(decimal);
			decimal colChannelPrice = default(decimal);
			string colName = null;
			decimal colTotalInclusive = default(decimal);
			decimal colTotalExclusive = default(decimal);
			decimal colInclusive = default(decimal);
			decimal colExclusive = default(decimal);
			int colOnOrder = 0;
			decimal colDiscountPercentage = default(decimal);
			int colDiscountLine = 0;
			int colDiscount = 0;
			decimal colContentTotalInclusive = default(decimal);
			decimal colContentTotalExclusive = default(decimal);
			decimal colDepositTotalInclusive = default(decimal);
			decimal colDepositTotalExclusive = default(decimal);
			decimal colDepositInclusive = default(decimal);
			decimal colDepositExclusive = default(decimal);
			decimal colContentInclusive = default(decimal);
			decimal colContentExclusive = default(decimal);
			int colPackSize = 0;
			decimal colFractions = default(decimal);
			string sql = null;
			string gGRVFieldOrder = null;
			int gFieldOrder = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rs1 = default(ADODB.Recordset);
			decimal CurTot = default(decimal);
			System.Windows.Forms.TextBox oText = new System.Windows.Forms.TextBox();
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

			if (retInfo == true) {
				rs = modRecordSet.getRS(ref "SELECT VegTestItem.VegTestItem_StockItemID AS StockItemID, VegTestItem.VegTestItem_Name AS StockItem_Name, VegTestItem.* From VegTestItem Where (((VegTestItem.VegTestItem_VegTestID) = " + testID + ")) ORDER BY VegTestItem.VegTestItem_Line;");
			} else {
				sql = "SELECT StockItem.StockItemID, StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk_1.CatalogueChannelLnk_Price AS POSCatalogueChannelLnk_Price, CatalogueChannelLnk_1.CatalogueChannelLnk_ChannelID, PackSize.PackSize_Volume, * ";
				//changes for CHANNEL 6 price        sql = sql & "FROM (((StockItem INNER JOIN RecipeStockitemLnk ON StockItem.StockItemID = RecipeStockitemLnk.RecipeStockitemLnk_StockitemID) INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) INNER JOIN CatalogueChannelLnk AS CatalogueChannelLnk_1 ON StockItem.StockItemID = CatalogueChannelLnk_1.CatalogueChannelLnk_StockItemID) INNER JOIN PackSize ON StockItem.StockItem_PackSizeID = PackSize.PackSizeID WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=2) AND ((CatalogueChannelLnk_1.CatalogueChannelLnk_ChannelID)=1) AND ((RecipeStockitemLnk.RecipeStockitemLnk_RecipeID)=" & gStockItemID & ") AND ((StockItem.StockItem_Disabled)=0) AND ((StockItem.StockItem_Discontinued)=0));"
				sql = sql + "FROM (((StockItem INNER JOIN RecipeStockitemLnk ON StockItem.StockItemID = RecipeStockitemLnk.RecipeStockitemLnk_StockitemID) INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) INNER JOIN CatalogueChannelLnk AS CatalogueChannelLnk_1 ON StockItem.StockItemID = CatalogueChannelLnk_1.CatalogueChannelLnk_StockItemID) INNER JOIN PackSize ON StockItem.StockItem_PackSizeID = PackSize.PackSizeID WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=2) AND ((CatalogueChannelLnk_1.CatalogueChannelLnk_ChannelID)=6) AND ((RecipeStockitemLnk.RecipeStockitemLnk_RecipeID)=" + gStockItemID + ") AND ((StockItem.StockItem_Disabled)=0) AND ((StockItem.StockItem_Discontinued)=0));";
				//Set rs = getRS(sql)
				rs = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, StockItem.StockItem_Name, RecipeStockitemLnk.RecipeStockitemLnk_Quantity, [StockItem_ListCost]/[StockItem_Quantity] AS cost, PriceChannelLnk.PriceChannelLnk_Price FROM (RecipeStockitemLnk INNER JOIN StockItem ON RecipeStockitemLnk.RecipeStockitemLnk_StockitemID = StockItem.StockItemID) INNER JOIN PriceChannelLnk ON StockItem.StockItemID = PriceChannelLnk.PriceChannelLnk_StockItemID Where (((RecipeStockitemLnk.RecipeStockitemLnk_RecipeID) = " + gStockItemID + ") And ((StockItem.StockItem_Discontinued) = False) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = 1) And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1)) ORDER BY StockItem.StockItem_Name;");
				//Set rs = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk_1.CatalogueChannelLnk_Price AS POSCatalogueChannelLnk_Price, CatalogueChannelLnk_1.CatalogueChannelLnk_ChannelID, * FROM ((StockItem INNER JOIN RecipeStockitemLnk ON StockItem.StockItemID = RecipeStockitemLnk.RecipeStockitemLnk_StockitemID) INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) INNER JOIN CatalogueChannelLnk AS CatalogueChannelLnk_1 ON StockItem.StockItemID = CatalogueChannelLnk_1.CatalogueChannelLnk_StockItemID WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=2) AND ((CatalogueChannelLnk_1.CatalogueChannelLnk_ChannelID)=1) AND ((RecipeStockitemLnk.RecipeStockitemLnk_RecipeID)=" & gStockItemID & ") AND ((StockItem.StockItem_Disabled)=0) AND ((StockItem.StockItem_Discontinued)=0));")
			}

			if (rs.RecordCount > 0) {
			} else {
				Interaction.MsgBox("This Product does not have any Recipe.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				return;
			}

			loading = true;
			var _with11 = gridItem;
			_with11.Visible = false;
			//            xsl:Sort select="" data-type="text" order="asending"
			_with11.RowCount = rs.RecordCount + 1;
			//ReDim StockItemLineID(Rows)
			x = 0;
			while (!(rs.EOF)) {
				x = x + 1;
				_with11.row = x;
				_with11.set_RowData(x, rs.Fields("StockItemID").Value);
				//StockItemLineID(x) = rs("StockItemID")


				if (retInfo == true) {
				} else {
					sql = "INSERT INTO VegTestItem ( VegTestItem_VegTestID, VegTestItem_StockItemID, VegTestItem_Name, VegTestItem_CutWeight, VegTestItem_MRelatedSellPrice, VegTestItem_ActualSellPriceIncl, VegTestItem_Line ) ";
					sql = sql + "SELECT " + testID + ", " + rs.Fields("StockItemID").Value + ", '" + Strings.Replace(rs.Fields("StockItem_Name").Value, "'", "''") + "', " + rs.Fields("RecipeStockitemLnk_Quantity").Value + ", " + Convert.ToDecimal(rs.Fields("PriceChannelLnk_Price").Value) + ", " + Convert.ToDecimal(rs.Fields("cost").Value) + ", " + x + " FROM Company;";
					Debug.Print(sql);
					modRecordSet.cnnDB.Execute(sql);
				}

				_with11.Col = colFractions;
				_with11.set_TextMatrix(x, colFractions, 0);
				//rs("StockItem_Fractions")

				_with11.Col = colPackSize;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 222));
				_with11.Col = colContentExclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 222));
				_with11.Col = colContentInclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(212, 212, 212));

				_with11.Col = colDepositExclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 222));
				_with11.Col = colDepositInclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(212, 212, 212));

				_with11.Col = colDepositTotalExclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(220, 220, 255));
				_with11.Col = colDepositTotalInclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(200, 200, 255));

				_with11.Col = colContentTotalExclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(220, 220, 255));
				_with11.Col = colContentTotalInclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(200, 200, 255));

				_with11.Col = colDiscount;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 200));
				_with11.Col = colDiscountLine;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 200));
				_with11.Col = colDiscountPercentage;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 200));
				_with11.Col = colOnOrder;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(222, 222, 222));

				_with11.Col = colExclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(220, 255, 220));
				_with11.Col = colInclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(200, 255, 200));

				_with11.Col = colTotalExclusive;
				gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(Information.RGB(220, 255, 220));
				_with11.Col = colTotalInclusive;
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
					_with11.set_TextMatrix(x, colName, rs.Fields("StockItem_Name").Value);

					_with11.set_TextMatrix(x, 1, Strings.FormatNumber(rs.Fields("VegTestItem_CutWeight").Value, 4));
					_with11.set_TextMatrix(x, 2, rs.Fields("VegTestItem_PerWeightYield").Value);
					_with11.set_TextMatrix(x, 3, Strings.FormatNumber(rs.Fields("VegTestItem_MRSellingratio").Value, 2));

					_with11.set_TextMatrix(x, 4, Strings.FormatNumber(rs.Fields("VegTestItem_ActualSellPriceIncl").Value, 2));
					_with11.set_TextMatrix(x, 5, Strings.FormatNumber(rs.Fields("VegTestItem_TOActualSellExcl").Value, 2));

					_with11.set_TextMatrix(x, 6, Strings.FormatNumber(rs.Fields("VegTestItem_MRelatedSellPrice").Value, 2));
					_with11.set_TextMatrix(x, 7, Strings.FormatNumber(rs.Fields("VegTestItem_TOSuggSellPriceExcl").Value, 2));
					_with11.set_TextMatrix(x, 8, Strings.FormatNumber(rs.Fields("VegTestItem_SuggSellPriceIncl").Value, 2));

				} else {
					_with11.set_TextMatrix(x, colName, rs.Fields("StockItem_Name").Value);
					_with11.set_TextMatrix(x, 1, Strings.FormatNumber(rs.Fields("RecipeStockitemLnk_Quantity").Value, 4));
					_with11.set_TextMatrix(x, 2, "0");
					_with11.set_TextMatrix(x, 3, "0.00");
					_with11.set_TextMatrix(x, 4, Strings.FormatNumber(rs.Fields("cost").Value, 2));
					_with11.set_TextMatrix(x, 5, "0.00");
					_with11.set_TextMatrix(x, 6, Strings.FormatNumber(rs.Fields("PriceChannelLnk_Price").Value, 2));
					_with11.set_TextMatrix(x, 7, "0.00");
					_with11.set_TextMatrix(x, 8, "0.00");
				}

				displayLine(ref ref x);
				rs.moveNext();
			}
			_with11.Col = colQuantity;
			_with11.Visible = true;
			loading = false;
			//doTotals

			picTotal.Top = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(gridItem.Top, false) + sizeConvertors.pixelToTwips(gridItem.Height, false) + 20, false);
		}

		private void displayLine(ref object row)
		{
			decimal lDiscount = default(decimal);
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

		private void gridItem_KeyPress(System.Object eventSender, KeyPressEventArgs eventArgs)
		{
			switch (eventArgs.KeyChar) {
				case Strings.Chr(40):
					eventArgs.KeyChar = Strings.Chr(0);
					break;
			}

		}

		private void gridItem_EnterCell(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			if (loading)
				return;
			loading = true;
			var _with12 = gridItem;
			if (_with12.row) {
				//colContentExclusive Then
				if (_with12.Col == 2 | _with12.Col == 3) {
					_txtEdit_1.SetBounds(sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with12.Left, true) + _with12.CellLeft, true), sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with12.Top, false) + _with12.CellTop, false), sizeConvertors.twipsToPixels(_with12.CellWidth, true), sizeConvertors.twipsToPixels(_with12.CellHeight, false));
					_txtEdit_1.Text = _with12.Text;
					_txtEdit_1.Tag = _txtEdit_1.Text;
					_txtEdit_1.Visible = true;
					_txtEdit_1.Text = Strings.Replace(_txtEdit_1.Text, ",", "");
					_txtEdit_1.Text = Strings.Replace(_txtEdit_1.Text, ".", "");
					_txtEdit_1.SelectionStart = 0;
					_txtEdit_1.SelectionLength = 9999;
					if (this.Visible)
						_txtEdit_1.Focus();
					//ElseIf .Col = 2 Or .Col = 17 Then
					//    _txtEdit_1.Move .Left + .CellLeft, .Top + .CellTop, .CellWidth, .CellHeight
					//    _txtEdit_1.Text = .Text
					//    _txtEdit_1.Tag = _txtEdit_1.Text
					//    _txtEdit_1.Visible = True
					//    _txtEdit_1.Text = Replace(_txtEdit_1.Text, ",", "")
					//    _txtEdit_1.Text = Replace(_txtEdit_1.Text, ".", "")
					//    _txtEdit_1.SelStart = 0
					//    _txtEdit_1.SelLength = 9999
					//    If Me.Visible Then _txtEdit_1.SetFocus
					//ElseIf .Col = 15 Then
					//    _txtEdit_1.Move .Left + .CellLeft, .Top + .CellTop, .CellWidth, .CellHeight
					//    _txtEdit_1.Text = .Text
					//    _txtEdit_1.Tag = _txtEdit_1.Text
					//    _txtEdit_1.Visible = True
					//    _txtEdit_1.Text = Replace(_txtEdit_1.Text, ",", "")
					//    _txtEdit_1.Text = Replace(_txtEdit_1.Text, ".", "")
					//    _txtEdit_1.SelStart = 0
					//    _txtEdit_1.SelLength = 9999
					//    If Me.Visible Then _txtEdit_1.SetFocus
				} else {
					_txtEdit_1.Visible = false;
				}
			}
			loading = false;

			return;
			gridItem_Err:
			 // ERROR: Not supported in C#: ResumeStatement

		}

		private void gridItem_LeaveCell(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (loading)
				return;
			if (bFinish)
				return;
			if (cmdTotal.Enabled == false)
				return;
			//MsgBox gridItem.row & "  " & gridItem.Col
			 // ERROR: Not supported in C#: OnErrorStatement


			if (gridItem.Col == 2) {
				gridItem.set_TextMatrix(ref gridItem.row, ref 3, ref Strings.FormatNumber(Convert.ToDecimal(gridItem.Text) * Convert.ToDecimal(gridItem.get_TextMatrix(ref gridItem.row, ref 1)), 2));
				gridItem.set_TextMatrix(ref gridItem.row, ref 5, ref Strings.FormatNumber(Convert.ToDecimal(gridItem.Text) * Convert.ToDecimal(gridItem.get_TextMatrix(ref gridItem.row, ref 4)), 2));
				gridItem.set_TextMatrix(ref gridItem.row, ref 7, ref Strings.FormatNumber(Convert.ToDecimal(gridItem.Text) * Convert.ToDecimal(gridItem.get_TextMatrix(ref gridItem.row, ref 6)), 2));
				if (Convert.ToDecimal(gridItem.get_TextMatrix(ref gridItem.row, ref 5)) > 0 & Convert.ToDecimal(gridItem.get_TextMatrix(ref gridItem.row, ref 7)) > 0) {
					gridItem.set_TextMatrix(ref gridItem.row, ref 8, ref Strings.FormatNumber(100 - ((Convert.ToDecimal(gridItem.get_TextMatrix(ref gridItem.row, ref 5)) / Convert.ToDecimal(gridItem.get_TextMatrix(ref gridItem.row, ref 7)) * 100)), 2));
				}

			} else if (gridItem.Col == 15) {
			}

		}

		//UPGRADE_WARNING: Event txtEdit.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void txtEdit_TextChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim Index As Short = txtEdit.GetIndex(eventSender)
			decimal colPrice = default(decimal);
			decimal colFractions = default(decimal);
			int colQuantity = 0;
			if (loading)
				return;
			string lString = null;
			int lValue = 0;
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

			var _with13 = gridItem;
			lString = txtEdit[Index].Text;
			if (lString == ".")
				lString = "0.";
			if (_with13.row) {
				if (string.IsNullOrEmpty(lString))
					lString = "0";
				//If CCur(lString) = 0 Then lString = ""
				if (Information.IsNumeric(lString)) {
					switch (Index) {
						case 0:
							if (Convert.ToBoolean(_with13.get_TextMatrix(_with13.row, colFractions))) {
								_with13.set_TextMatrix(_with13.row, colQuantity, Strings.FormatNumber(lString, 4));
							} else {
								_with13.set_TextMatrix(_with13.row, colQuantity, Strings.FormatNumber(lString, 0));
							}
							break;
						case 1:
							if (_with13.Col == 2) {
								//.TextMatrix(.row, 1) = FormatNumber(CCur(lString) / 100, 2)
								_with13.set_TextMatrix(_with13.row, 2, Convert.ToDecimal(lString));
							} else if (_with13.Col == 3) {
								_with13.set_TextMatrix(_with13.row, 3, Strings.FormatNumber(Convert.ToDecimal(lString) / 100, 2));
								//ElseIf .Col = 17 Then
								//    .TextMatrix(.row, 17) = FormatNumber(CCur(lString) / 100, 2)
								//ElseIf .Col = 15 Then
								//    .TextMatrix(.row, 15) = FormatNumber(CCur(lString) / 100, 2)
							}
							break;
						case 2:
							//UPGRADE_WARNING: Couldn't resolve default property of object colPrice. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							_with13.set_TextMatrix(_with13.row, colPrice, Strings.FormatNumber(Convert.ToDecimal(lString) / 100, 2));
							break;
					}
				}
				//displayLine .row
			}
			//doTotals
		}

		private void txtEdit_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim Index As Short = txtEdit.GetIndex(eventSender)
			modUtilities.MyGotFocusNumeric(ref _txtEdit_1);
		}

		private void txtEdit_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			//Dim Index As Short = txtEdit.GetIndex(eventSender)
			switch (KeyAscii) {
				case Strings.Asc(Constants.vbCr):
					gridItem.Focus();
					_txtEdit_1.Visible = false;
					//update
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
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtEdit_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim Index As Short = txtEdit.GetIndex(eventSender)
			//update
			calcP();
		}

		private void txtEdit_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			//Dim Index As Short = txtEdit.GetIndex(eventSender)
			if (KeyCode == 40) {
				//update
				loading = true;
				calcP();
				loading = true;
				moveNext(ref 1, ref 1);
				loading = false;
			} else if (KeyCode == 38) {
				//update
				loading = true;
				calcP();
				loading = true;
				moveNext(ref 1, ref -1);
				loading = false;
			}


		}

		private bool moveNext(ref int Index, ref short direction)
		{
			string a = null;
			short x = 0;
			short y = 0;
			 // ERROR: Not supported in C#: OnErrorStatement


			x = gridItem.row + direction;
			if (x >= gridItem.RowCount | x < gridItem.FixedRows) {
			} else {
				gridItem.row = x;
			}

			var _with14 = gridItem;
			if (_with14.row) {
				//colContentExclusive Then
				if (_with14.Col == 2) {
					_txtEdit_1.SetBounds(sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with14.Left, true) + _with14.CellLeft, true), sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with14.Top, false) + _with14.CellTop, false), sizeConvertors.twipsToPixels(_with14.CellWidth, true), sizeConvertors.twipsToPixels(_with14.CellHeight, false));
					a = Convert.ToDecimal(_with14.Text);
					//If Me.Visible Then _txtEdit_1.SetFocus
					loading = true;
					_txtEdit_1.Text = a;
					//_txtEdit_1.Tag = _txtEdit_1.Text
					_txtEdit_1.Visible = true;
					//_txtEdit_1.Text = Replace(_txtEdit_1.Text, ",", "")
					//_txtEdit_1.Text = Replace(_txtEdit_1.Text, ".", "")
					//_txtEdit_1.SelStart = 0
					//_txtEdit_1.SelLength = 9999
					loading = false;
				} else if (_with14.Col == 3) {
					_txtEdit_1.SetBounds(sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with14.Left, true) + _with14.CellLeft, true), sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with14.Top, false) + _with14.CellTop, false), sizeConvertors.twipsToPixels(_with14.CellWidth, true), sizeConvertors.twipsToPixels(_with14.CellHeight, false));
					a = Convert.ToDecimal(_with14.Text);
					//If Me.Visible Then _txtEdit_1.SetFocus
					loading = true;
					//UPGRADE_WARNING: Couldn't resolve default property of object a. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					_txtEdit_1.Text = a;
					_txtEdit_1.Visible = true;
					loading = false;
					//ElseIf .Col = 15 Then
					//    _txtEdit_1.Move .Left + .CellLeft, .Top + .CellTop, .CellWidth, .CellHeight
					//    a = CCur(.Text)
					//    'If Me.Visible Then _txtEdit_1.SetFocus
					//    loading = True
					//    _txtEdit_1.Text = a
					//    _txtEdit_1.Visible = True
					//    loading = False
					//ElseIf .Col = 2 Then
					//    _txtEdit_1.Move .Left + .CellLeft, .Top + .CellTop, .CellWidth, .CellHeight
					//    If CCur(.Text) = 0 Then _txtEdit_1.Text = "" Else _txtEdit_1.Text = CCur(.Text) '* 100
					//ElseIf .Col = 11 Then
					//    _txtEdit_1.Move .Left + .CellLeft, .Top + .CellTop, .CellWidth, .CellHeight
					//    If CCur(.Text) = 0 Then _txtEdit_1.Text = "" Else _txtEdit_1.Text = CCur(.Text) '* 100
				} else {
					_txtEdit_1.Visible = false;
				}
			}
			//txtEdit(Index).SelStart = 0
			//txtEdit(Index).SelLength = 999
			cmdPrint.Focus();
			if (txtEdit[Index].Visible)
				txtEdit[Index].Focus();
			return true;
		}

		private void calcP()
		{
			decimal QtyD_P = default(decimal);
			decimal QtyD_P_GRV = default(decimal);
			int rowNo = 0;
			loading = true;
			 // ERROR: Not supported in C#: OnErrorStatement

			if (gridItem.Col == 2) {
				rowNo = gridItem.row;
				QtyD_P = 0;
				QtyD_P_GRV = 0;
				var _with15 = gridItem;
				for (x = 1; x <= (_with15.RowCount - 1); x++) {
					_with15.row = x;
					_with15.Col = 2;
					QtyD_P = QtyD_P + Convert.ToDecimal(_with15.Text);
					if (gridItem.row == rowNo) {
						gridItem.set_TextMatrix(ref ref gridItem.row, ref ref 3, ref ref Strings.FormatNumber(Convert.ToDecimal(gridItem.get_TextMatrix(ref ref gridItem.row, ref ref 2)) * Convert.ToDecimal(gridItem.get_TextMatrix(ref ref gridItem.row, ref ref 1)), 2));
						gridItem.set_TextMatrix(ref ref gridItem.row, ref ref 5, ref ref Strings.FormatNumber(Convert.ToDecimal(gridItem.get_TextMatrix(ref ref gridItem.row, ref ref 2)) * Convert.ToDecimal(gridItem.get_TextMatrix(ref ref gridItem.row, ref ref 4)), 2));
						gridItem.set_TextMatrix(ref ref gridItem.row, ref ref 7, ref ref Strings.FormatNumber(Convert.ToDecimal(gridItem.get_TextMatrix(ref ref gridItem.row, ref ref 2)) * Convert.ToDecimal(gridItem.get_TextMatrix(ref ref gridItem.row, ref ref 6)), 2));
						if (Convert.ToDecimal(gridItem.get_TextMatrix(ref ref gridItem.row, ref ref 5)) > 0 & Convert.ToDecimal(gridItem.get_TextMatrix(ref ref gridItem.row, ref ref 7)) > 0) {
							gridItem.set_TextMatrix(ref ref gridItem.row, ref ref 8, ref ref Strings.FormatNumber(100 - ((Convert.ToDecimal(gridItem.get_TextMatrix(ref ref gridItem.row, ref ref 5)) / Convert.ToDecimal(gridItem.get_TextMatrix(ref ref gridItem.row, ref ref 7)) * 100)), 2));
						}
						//gridItem.TextMatrix(gridItem.row, 14) = FormatNumber((CCur(.Text) * CCur(gridItem.TextMatrix(gridItem.row, 13))), 2)
						//gridItem.TextMatrix(gridItem.row, 15) = FormatNumber((CCur(.Text) * CCur(gridItem.TextMatrix(gridItem.row, 13))), 2)
					}
					QtyD_P_GRV = QtyD_P_GRV + Convert.ToDouble(gridItem.get_TextMatrix(ref ref gridItem.row, ref ref 3));
					//(CCur(.Text) * CCur(gridItem.TextMatrix(gridItem.row, 13)))

				}
				//lblP.Caption = FormatNumber(QtyD_P, 4)
				TotalQTY.Text = Strings.FormatNumber(QtyD_P_GRV, 4);
				//If TotalQTY > AvailGRV Then
				//    MsgBox "Insufficient Qty in Main Stock Item! Please correct your last entered QTY."
				//End If
				gridItem.row = rowNo;
			} else if (gridItem.Col == 3) {
				rowNo = gridItem.row;
				//QtyD_P = 0
				QtyD_P_GRV = 0;
				var _with16 = gridItem;
				for (x = 1; x <= (_with16.RowCount - 1); x++) {
					_with16.row = x;
					_with16.Col = 3;
					//QtyD_P = QtyD_P + CCur(.Text)
					//gridItem.TextMatrix(gridItem.row, 14) = FormatNumber((CCur(.Text) * CCur(gridItem.TextMatrix(gridItem.row, 13))), 2)
					//gridItem.TextMatrix(gridItem.row, 15) = FormatNumber((CCur(.Text) * CCur(gridItem.TextMatrix(gridItem.row, 13))), 2)
					QtyD_P_GRV = QtyD_P_GRV + Convert.ToDecimal(_with16.Text);

				}
				//lblP.Caption = FormatNumber(QtyD_P, 4)
				TotalQTY.Text = Strings.FormatNumber(QtyD_P_GRV, 4);
				//If TotalQTY > AvailGRV Then
				//    MsgBox "Insufficient Qty in Main Stock Item! Please correct your last entered QTY."
				//End If
				gridItem.row = rowNo;
			}
			loading = false;
		}
		//UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
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
					gridItem.set_TextMatrix(ref gridItem.row, ref 1, ref Convert.ToDecimal(_txtEdit_1.Text));
					break;
				case 2:
					gridItem.set_TextMatrix(ref gridItem.row, ref 2, ref Strings.FormatNumber(_txtEdit_1.Text, 2));
					break;
				case 17:
					//11
					gridItem.set_TextMatrix(ref gridItem.row, ref 17, ref Strings.FormatNumber(_txtEdit_1.Text, 2));
					break;
			}
			//End If
		}



		private void txtR_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			//MyGotFocusNumericMEAT txtR
			modUtilities.MyGotFocusNumeric(ref txtR);
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
			modUtilities.MyLostFocus(ref txtR, ref 2);
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
			TextBox oText = new TextBox();

			modBResolutions.ResizeForm(ref this, ref sizeConvertors.pixelToTwips(this.Width, true), ref sizeConvertors.pixelToTwips(this.Height, false), ref 2);

			setup();
			frmVegTest_Resize(this, new System.EventArgs());

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
			ADODB.Recordset rj = default(ADODB.Recordset);

			//Set rs = getRS("SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & gStockItemID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
			rs = modRecordSet.getRS(ref "SELECT VegTest.*, StockItem.StockItem_Name, Person.Person_FirstName, Person.Person_LastName FROM (VegTest INNER JOIN StockItem ON VegTest.VegTest_MainItemID = StockItem.StockItemID) INNER JOIN Person ON VegTest.VegTest_PersonID = Person.PersonID WHERE (((VegTest.VegTestID)=" + testID + "));");

			if (rs.RecordCount) {
				lblContentExclusive.Text = rs.Fields("Person_FirstName").Value + " " + rs.Fields("Person_LastName").Value;
				txtR.Text = Strings.FormatNumber(rs.Fields("VegTest_PricePerKg").Value, 4);
				txtZ.Text = Strings.FormatNumber(rs.Fields("VegTest_WeightCarcass").Value, 4);
				txtReqGP.Text = Strings.FormatNumber(rs.Fields("VegTest_RequiredGP").Value, 4);
				txtVAT.Text = Strings.FormatNumber(rs.Fields("VegTest_VAT").Value, 4);
				getRecItems(ref true);
				cmdTotal_ClickSAVE();
				if (rs.Fields("VegTest_VegTestStatusID").Value == 3) {
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

			bFinish = true;
			loading = true;

			QtyD_P = 0;
			var _with17 = gridItem;
			for (x = 1; x <= (_with17.RowCount - 1); x++) {
				_with17.row = x;
				_with17.Col = 3;
				QtyD_P = QtyD_P + Convert.ToDouble(Strings.FormatNumber(Convert.ToDecimal(_with17.Text), 2));
				//cnnDB.Execute "UPDATE VegTestItem SET VegTestItem_MRSellingratio = " & FormatNumber(CCur(.Text), 2) & " WHERE ((VegTestItem_VegTestID = " & testID & ") AND (VegTestItem_StockItemID = " & .RowData(x) & ") AND (VegTestItem_Line = " & x & "));"
			}
			TotalQTY.Text = Strings.FormatNumber(QtyD_P, 2);

			QtyD_P = 0;
			var _with18 = gridItem;
			for (x = 1; x <= (_with18.RowCount - 1); x++) {
				_with18.row = x;
				_with18.Col = 5;
				//QtyD_P = QtyD_P + CCur(.Text)
				QtyD_P = QtyD_P + Convert.ToDouble(Strings.FormatNumber(Convert.ToDecimal(_with18.Text), 2));
				//cnnDB.Execute "UPDATE VegTestItem SET VegTestItem_MRelatedTO = " & FormatNumber(CCur(.Text), 4) & " WHERE ((VegTestItem_VegTestID = " & testID & ") AND (VegTestItem_StockItemID = " & .RowData(x) & ") AND (VegTestItem_Line = " & x & "));"
				//cnnDB.Execute "UPDATE VegTestItem SET VegTestItem_TOActualSellExcl = " & FormatNumber(CCur(.Text), 2) & " WHERE ((VegTestItem_VegTestID = " & testID & ") AND (VegTestItem_StockItemID = " & .RowData(x) & ") AND (VegTestItem_Line = " & x & "));"
			}
			txtReqGP.Text = Strings.FormatNumber(QtyD_P, 2);

			QtyD_P = 0;
			var _with19 = gridItem;
			for (x = 1; x <= (_with19.RowCount - 1); x++) {
				_with19.row = x;
				_with19.Col = 7;
				QtyD_P = QtyD_P + Convert.ToDouble(Strings.FormatNumber(Convert.ToDecimal(_with19.Text), 2));
				//cnnDB.Execute "UPDATE VegTestItem SET VegTestItem_MRSellingratio = " & FormatNumber(CCur(.Text), 4) & " WHERE ((VegTestItem_VegTestID = " & testID & ") AND (VegTestItem_StockItemID = " & .RowData(x) & ") AND (VegTestItem_Line = " & x & "));"
				//cnnDB.Execute "UPDATE VegTestItem SET VegTestItem_TOSuggSellPriceExcl = " & FormatNumber(CCur(.Text), 2) & " WHERE ((VegTestItem_VegTestID = " & testID & ") AND (VegTestItem_StockItemID = " & .RowData(x) & ") AND (VegTestItem_Line = " & x & "));"
			}
			lblGP_Y.Text = Strings.FormatNumber(QtyD_P, 2);

			if (Convert.ToDecimal(txtReqGP.Text) > 0 & Convert.ToDecimal(lblGP_Y.Text) > 0) {
				lblB_Z.Text = Convert.ToString(100 - ((Convert.ToDecimal(txtReqGP.Text) / Convert.ToDecimal(lblGP_Y.Text)) * 100));
			}


			//total req
			loading = false;
			bFinish = false;
		}
	}
}
