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
using VB = Microsoft.VisualBasic;
namespace _4PosBackOffice.NET
{
	static class modApplication
	{
		[DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		public static extern void ExitProcess(int uExitCode);
//changes from jonas for Price change report
		public static string Te_Names;
		public static string MyFTypess;
		public static short ForNewPChange;
		public static string HCalDate;
		public static short HForPriceC;

//for label printing
		public static short TheType;
		public static short TheSelectedPrinterNew;
		public static int TheErr;
		public static string TheNames;
		public static short MyFAlign;
		public static short RecSel;
		public struct Labelss
		{
			public int widthh;
			public int heightt;
		}
		public static short IntDesign;
		public static short IntDesign1;
		public static string NewLabelName;
		public static string SelectLabelName;
		public static short LaIDHold;
		public static short MyLIDWHole;
		public static string MyNewPrLabel;
//changes from jonas for Price change report

//To keep track of month end routine
		public static int holdid;
		public static double Intpercen;
		public static string IntPeriod;
		public static string checkcustid;
		public static int holddel;
		public static int Holdquantity;
		public static string Holdvalue;
		public static string HoldP;
		public static string Hold_text;
		public static int modUpdate;
		public static string gSecKey;
		public static string[] tempStockItem = new string[101];
		public static string stTableName;
		public static string[] intArrayName = new string[101];
		public static string strLocation;
		public static short intQTY;
		public static short rInt;
		public static short InKeyboard;
		public static short Gr_ID;
		public static short[] intArraySCode = new short[101];
		public static short intCurr;
		public static short exUt_variable;
		public static short grvPrinType;
		public static bool Grv_Unload;
		public static bool nwPOS;
		public static bool inTableCrea;
		public static bool grvPrin;
			//to print scale barcode
		public static bool scaleBCPrint;
//Public blMontheEnd        As Boolean

			//For Auto UpdatePOS on MonthEnd
		public static bool blMEndUpdatePOS;
			//For Auto UpdatePOS on MonthEnd
		public static bool blChangeOnlyUpdatePOS;
		public static bool blNextItem;
		public static ADODB.Recordset rs_St;
			//security check
		public static bool blChkSecu;

//stock holding report from multiple companies
		public static string[] arrCompChk;
		public static bool bolCompChk;

			//to check for duplicate barcode when create new item from GRV
		public static bool bGRVNewItemBarcode;

//Air Time Auto GRV
		public static bool bolAirTimeGRV;
		public static string strAirTimeFile;

//Fruit and Veg GRV
		public static bool bolFNVegGRV;

//Auto DayEnd from Controller
		public static bool bolAutoDE;
		public static System.DateTime dateDayEnd;

//Piracy check
		public static System.DateTime loginDate;
		public static System.DateTime instalDate;
//Piracy check

		public static bool posDemo()
		{
			bool bPosDemo = false;
			ADODB.Recordset rs = default(ADODB.Recordset);

			 // ERROR: Not supported in C#: OnErrorStatement


			bPosDemo = false;
			rs = modRecordSet.getRS(ref "SELECT Company.Company_Name FROM Company;");
			if (rs.RecordCount) {
				if (Information.IsDBNull(rs.Fields("Company_Name").Value)) {
					bPosDemo = true;
					goto skipEnd;
				} else if (Strings.Left(Strings.UCase(rs.Fields("Company_Name").Value), 4) == "4POS") {
					bPosDemo = true;
					goto skipEnd;
				}
			}

			bPosDemo = false;
			rs = modRecordSet.getRS(ref "SELECT Count([SaleID]) AS cSaleID FROM Sale;");
			if (rs.Fields("cSaleID").Value > 1) {
			} else {
				rs = modRecordSet.getRS(ref "SELECT Count([DayEndID]) AS cDayEnd FROM DayEnd;");
				if (rs.Fields("cDayEnd").Value > 1) {
				} else {
					bPosDemo = true;
					goto skipEnd;
				}
			}
			skipEnd:

			return bPosDemo;
		}

		public static void getLoginDate()
		{
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();

			//Piracy check
			loginDate = DateAndTime.Today;
			Scripting.Folder fsoFolder = default(Scripting.Folder);
			if (fso.FolderExists(modRecordSet.serverPath)) {
				fsoFolder = fso.GetFolder(modRecordSet.serverPath);
				//getSerialNumber = fsoFolder.Drive.SerialNumber
				instalDate = fsoFolder.DateCreated;
			}
		}

		public static bool getBanList(ref string compName)
		{
			short x = 0;
			string[] sBanList = null;
			//new ban check
			bool bFound = false;

			bFound = false;
			sBanList = new string[44];
			sBanList[0] = "Hey day chicken_REMOVED";
			//removed 10-Nov-2011  "Hey day chicken"
			sBanList[1] = "Heyday Chicken_REMOVED";
			//removed 10-Nov-2011  "Heyday Chicken"
			sBanList[2] = "Hay Day Chicken_REMOVED";
			//removed 10-Nov-2011  "Hay Day Chicken"
			sBanList[3] = "Hayday Chicken_REMOVED";
			//removed 10-Nov-2011  "Hayday Chicken"
			sBanList[4] = "Bloemhof Drankwinkel";
			//list of 04-oct
			sBanList[5] = "FOOD & GOODS SUPERMARKET";
			sBanList[6] = "FOOD AND GOODS SUPERMARKET";
			sBanList[7] = "LOBAY SUPERMARKET";
			sBanList[8] = "MABENA'S SUPERMARKET";
			sBanList[9] = "MABENA SUPERMARKET";
			sBanList[10] = "PHILLY'S PUB";
			sBanList[11] = "PHILLY PUB";
			sBanList[12] = "COLTRANE'S TUCK SHOP";
			sBanList[13] = "COLTRANE TUCK SHOP";
			sBanList[14] = "OUDSTAD BUTCHERY";
			sBanList[15] = "PEACE SUPERSAVE(FORMERLY FOOD BAZAAR)";
			sBanList[16] = "PEACE SUPERSAVE";
			sBanList[17] = "AMBRO'S EATING HOUSE";
			sBanList[18] = "AMBRO EATING HOUSE";
			sBanList[19] = "IKA SUPERMARKET";
			sBanList[20] = "MOONEYES TUCKSHOP";
			sBanList[21] = "SELLO'S EATING HOUSE";
			sBanList[22] = "SELLO EATING HOUSE";
			sBanList[23] = "SELLO'S TUCKSHOP";
			sBanList[24] = "SELLO TUCKSHOP";
			sBanList[25] = "SOMETHING TASTY TUCKSHOP";
			sBanList[26] = "SIPHO'S BOTTLE STORE";
			sBanList[27] = "SIPHOS BOTTLE STORE";
			sBanList[28] = "BRO-DANS TUCKSHOP";
			sBanList[29] = "BRO DANS TUCKSHOP";
			sBanList[30] = "LAKE'S TUCKSHOP";
			sBanList[31] = "LAKE TUCKSHOP";
			sBanList[32] = "MONAKAMOTA SHOP";
			sBanList[33] = "THREEDOOR TAVERN";
			sBanList[34] = "JAKKALS SUPERMARKET";
			sBanList[35] = "LIFESTYLE PUB";
			sBanList[36] = "MATSHENGELANE GARAGE SHOP";
			sBanList[37] = "MOLEBOGENG SUPERMARKET";
			sBanList[38] = "BRO PHILLS BAR";
			sBanList[39] = "ALPHA TUCKSHOP";
			sBanList[40] = "GREEN LINE";
			sBanList[41] = "GREEN_LINE";
			sBanList[42] = "DIE STOEP";
			sBanList[43] = "DIE_STOEP";

			for (x = 0; x <= Information.UBound(sBanList); x++) {
				if (Strings.LCase(compName) == Strings.LCase(sBanList[x]))
					bFound = true;
				if (Strings.InStr(Strings.LCase(compName), Strings.LCase(sBanList[x])))
					bFound = true;
			}

			return bFound;

		}

		public static bool getBanCDKey()
		{
			bool functionReturnValue = false;
			short x = 0;
			string[] sBanList = null;
			//new ban check
			bool bFound = false;
			ADODB.Recordset rs = default(ADODB.Recordset);

			bFound = false;
			sBanList = new string[2];
			sBanList[0] = "372B97AFDEE79CCE5E00842";
			sBanList[1] = "372B97AFDEE79CCE5E00842";
			rs = modRecordSet.getRS(ref "Select * FROM POS;");
			if (!string.IsNullOrEmpty(rs.ToString)) {

				for (x = 0; x <= Information.UBound(sBanList); x++) {

					while (rs.EOF == false) {
						if (Strings.InStr(1, rs.Fields("POS_Code").Value.ToString, Strings.Chr(255))) {
							if (Strings.LCase(Strings.Split(rs.Fields("POS_Code").Value, Strings.Chr(255))[1]) == Strings.LCase(sBanList[x])) {
								functionReturnValue = true;
								return functionReturnValue;
							}
						}
						rs.MoveNext();
					}

				}
			}
			functionReturnValue = bFound;
			return functionReturnValue;

		}

		public static void RecipeCost()
		{
			short x = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			for (x = 1; x <= 3; x++) {
				rs = modRecordSet.getRS(ref "SELECT RecipeStockitemLnk.RecipeStockitemLnk_RecipeID, Sum([RecipeStockitemLnk_Quantity]/[Stockitem].[StockItem_Quantity]*[StockItem]![StockItem_ListCost]) AS cost FROM StockItem AS StockItem_1 INNER JOIN (RecipeStockitemLnk INNER JOIN StockItem ON RecipeStockitemLnk.RecipeStockitemLnk_StockitemID = StockItem.StockItemID) ON StockItem_1.StockItemID = RecipeStockitemLnk.RecipeStockitemLnk_RecipeID Where (((StockItem_1.StockItem_RecipeType) = 2)) GROUP BY RecipeStockitemLnk.RecipeStockitemLnk_RecipeID;");
				//Bill of material looping delay...
				while (!(rs.EOF)) {
					modRecordSet.cnnDB.Execute("UPDATE StockItem SET StockItem.StockItem_ListCost = " + rs.Fields("cost").Value + " WHERE (((StockItem.StockItemID)=" + rs.Fields("RecipeStockitemLnk_RecipeID").Value + "));");
					rs.moveNext();
				}
			}
		}
		private static void Mains()
		{
			int iret = 0;
			int lHandle = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();

			if (fso.FileExists("C:\\4POS\\pos\\data.ug")) {
				if (fso.FileExists("C:\\4POS\\pos\\4POSupgrade.exe")) {
					Interaction.Shell("C:\\4POS\\pos\\4POSupgrade.exe", AppWinStyle.NormalFocus);
				} else {
					Interaction.MsgBox("An upgrade is required, but the upgrade unility can not be located!" + Constants.vbCrLf + Constants.vbCrLf + "Please contact a 4POS representative to assist you in resolving this problem.", MsgBoxStyle.Critical, "UPGRADE");
				}
				System.Environment.Exit(0);
			}

			modUtilities.setShortDateFormat();
			 // ERROR: Not supported in C#: OnErrorStatement

			if (string.IsNullOrEmpty(Interaction.Command())) {
				My.MyProject.Forms.frmLogin.Show();
			} else {
				My.MyProject.Forms.frmMaster.Show();
			}
		}
		public static void updateStockMovement()
		{
			string Path = null;
			string strDBPath = null;
			int lDayend = 0;
			string sql = null;
			ADODB.Connection cn = default(ADODB.Connection);
			ADODB.Recordset rs = default(ADODB.Recordset);
			 // ERROR: Not supported in C#: OnErrorStatement

			string errDesc = null;

			System.Windows.Forms.Application.DoEvents();
			if (modUpdate == 1) {
				My.MyProject.Forms.frmDayEnd.Label3.Text = "Please Wait, Stock Update progress...";
				My.MyProject.Forms.frmDayEnd.Label3.Visible = true;
			}
			System.Windows.Forms.Application.DoEvents();
			System.Windows.Forms.Application.DoEvents();

			errDesc = "Starting Point";

			modRecordSet.cnnDB.Execute("UPDATE Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales = 0, DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV = 0;");
			modRecordSet.cnnDB.Execute("UPDATE DayEndDepositItemLnk INNER JOIN Company ON DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID = Company.Company_DayEndID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantitySales = 0, DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = 0;");
			//Multi Warehouse change
			//cnnDB.Execute "UPDATE Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN ((DayEndStockItemLnk INNER JOIN (Sale INNER JOIN company ON Sale.Sale_DayEndID = company.Company_DayEndID) ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = company.Company_DayEndID) INNER JOIN SaleItem ON (DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = SaleItem.SaleItem_StockItemID) AND (Sale.SaleID = SaleItem.SaleItem_SaleID)) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantitySales]+(IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) WHERE (((SaleItem.SaleItem_Recipe)=0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_DepositType)=0) AND ((Consignment.ConsignmentID) Is Null) AND ((Consignment_1.ConsignmentID) Is Null));"
			sql = "UPDATE Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN ((DayEndStockItemLnk INNER JOIN (Sale INNER JOIN company ON Sale.Sale_DayEndID = company.Company_DayEndID) ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = company.Company_DayEndID) INNER JOIN SaleItem ON (DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = SaleItem.SaleItem_StockItemID) AND (DayEndStockItemLnk.DayEndStockItemLnk_Warehouse = SaleItem.SaleItem_WarehouseID) AND (Sale.SaleID = SaleItem.SaleItem_SaleID)) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantitySales]+(IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) ";
			sql = sql + "WHERE (((SaleItem.SaleItem_Recipe)=0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_DepositType)=0) AND ((Consignment.ConsignmentID) Is Null) AND ((Consignment_1.ConsignmentID) Is Null));";
			modRecordSet.cnnDB.Execute(sql);

			//sql = "UPDATE SaleItemReciept INNER JOIN (Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN ((DayEndStockItemLnk INNER JOIN (Sale INNER JOIN company ON Sale.Sale_DayEndID = company.Company_DayEndID) ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = company.Company_DayEndID) INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID) ON (SaleItemReciept.SaleItemReciept_StockitemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) AND (SaleItemReciept.SaleItemReciept_SaleItemID = SaleItem.SaleItemID) SET DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantitySales]+(IIf([SaleItem_Reversal],0-[SaleItemReciept_Quantity]*[SaleItem_Quantity],[SaleItemReciept_Quantity]*[SaleItem_Quantity])) "
			sql = "UPDATE SaleItemReciept INNER JOIN (Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN ((DayEndStockItemLnk INNER JOIN (Sale INNER JOIN company ON Sale.Sale_DayEndID = company.Company_DayEndID) ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = company.Company_DayEndID) INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID AND DayEndStockItemLnk.DayEndStockItemLnk_Warehouse = SaleItem.SaleItem_WarehouseID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID) ON (SaleItemReciept.SaleItemReciept_StockitemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) AND (SaleItemReciept.SaleItemReciept_SaleItemID = SaleItem.SaleItemID) SET DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantitySales]+(IIf([SaleItem_Reversal],0-[SaleItemReciept_Quantity]*[SaleItem_Quantity],[SaleItemReciept_Quantity]*[SaleItem_Quantity])) ";
			sql = sql + "WHERE (((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_DepositType)=0) AND ((Consignment.ConsignmentID) Is Null) AND ((Consignment_1.ConsignmentID) Is Null));";
			modRecordSet.cnnDB.Execute(sql);
			//Multi Warehouse change

			//Multi Warehouse change     cnnDB.Execute "UPDATE ((StockItem INNER JOIN (DayEndStockItemLnk INNER JOIN GRVItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = GRVItem.GRVItem_StockItemID) ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID) INNER JOIN GRV ON (GRVItem.GRVItem_GRVID = GRV.GRVID) AND (DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = GRV.GRV_DayEndID)) INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV = [DayEndStockItemLnk_QuantityGRV]+IIf([GRVItem]![GRVItem_Return],0-[GRVItem_PackSize]*[GRVItem_Quantity],[GRVItem_PackSize]*[GRVItem_Quantity]) WHERE (((GRV.GRV_GRVStatusID)=3));"
			modRecordSet.cnnDB.Execute("UPDATE ((StockItem INNER JOIN (DayEndStockItemLnk INNER JOIN GRVItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = GRVItem.GRVItem_StockItemID) ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID) INNER JOIN GRV ON (GRVItem.GRVItem_GRVID = GRV.GRVID) AND (DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = GRV.GRV_DayEndID)) INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV = [DayEndStockItemLnk_QuantityGRV]+IIf([GRVItem]![GRVItem_Return],0-[GRVItem_PackSize]*[GRVItem_Quantity],[GRVItem_PackSize]*[GRVItem_Quantity]) WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=2) AND ((GRV.GRV_GRVStatusID)=3));");
			modRecordSet.cnnDB.Execute("UPDATE GRV INNER JOIN ((Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN ((Deposit INNER JOIN StockItem ON Deposit.DepositID = StockItem.StockItem_DepositID) INNER JOIN GRVItem ON (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize) AND (StockItem.StockItemID = GRVItem.GRVItem_StockItemID)) ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = Deposit.DepositID) ON (GRV.GRVID = GRVItem.GRVItem_GRVID) AND (GRV.GRV_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]+(IIf([GRVItem]![GRVItem_Return],0-[GRVItem]![GRVItem_Quantity],[GRVItem]![GRVItem_Quantity])) WHERE (((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=1) AND ((GRV.GRV_GRVStatusID)=3));");
			modRecordSet.cnnDB.Execute("UPDATE GRV INNER JOIN ((Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN ((Deposit INNER JOIN StockItem ON Deposit.DepositID = StockItem.StockItem_DepositID) INNER JOIN GRVItem ON (StockItem.StockItemID = GRVItem.GRVItem_StockItemID) AND (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize)) ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = Deposit.DepositID) ON (GRV.GRV_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) AND (GRV.GRVID = GRVItem.GRVItem_GRVID) SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]+(IIf([GRVItem]![GRVItem_Return],0-[GRVItem]![GRVItem_Quantity],[GRVItem]![GRVItem_Quantity]))*[Deposit_Quantity] WHERE (((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=0) AND ((GRV.GRV_GRVStatusID)=3));");

			modRecordSet.cnnDB.Execute("UPDATE GRV INNER JOIN ((Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN GRVDeposit ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID) ON (GRV.GRVID = GRVDeposit.GRVDeposit_GRVID) AND (GRV.GRV_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]-IIf([GRVDeposit]![GRVDeposit_Return],0-[GRVDeposit_Quantity]*[GRVDeposit_CaseQuantity],[GRVDeposit_Quantity]*[GRVDeposit_CaseQuantity]) WHERE (((GRVDeposit.GRVDeposit_Type)=1 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=0) AND ((GRV.GRV_GRVStatusID)=3));");
			modRecordSet.cnnDB.Execute("UPDATE ((Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN GRVDeposit ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID) INNER JOIN GRV ON (GRV.GRV_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) AND (GRVDeposit.GRVDeposit_GRVID = GRV.GRVID) SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]-IIf([GRVDeposit_Return],0-[GRVDeposit_Quantity],[GRVDeposit_Quantity]) WHERE (((GRVDeposit.GRVDeposit_Type)=2 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=1) AND ((GRV.GRV_GRVStatusID)=3));");

			modRecordSet.cnnDB.Execute("UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) ON (SaleItem.SaleItem_StockItemID = DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID) AND (Company.Company_DayEndID = Sale.Sale_DayEndID) SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantitySales = [DayEndDepositItemLnk_QuantitySales]-[SaleItem_Quantity] WHERE (((SaleItem.SaleItem_DepositType)=1) AND ((SaleItem.SaleItem_Revoke)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=0) AND ((SaleItem.SaleItem_Reversal)<>0));");
			modRecordSet.cnnDB.Execute("UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) ON (SaleItem.SaleItem_StockItemID = DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID) AND (Company.Company_DayEndID = Sale.Sale_DayEndID) SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantitySales = [DayEndDepositItemLnk_QuantitySales]+[SaleItem_Quantity] WHERE (((SaleItem.SaleItem_DepositType)=1) AND ((SaleItem.SaleItem_Revoke)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=0) AND ((SaleItem.SaleItem_Reversal)=0));");

			modRecordSet.cnnDB.Execute("UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) ON (SaleItem.SaleItem_StockItemID = DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID) AND (Company.Company_DayEndID = Sale.Sale_DayEndID) SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantitySales = [DayEndDepositItemLnk_QuantitySales]-[SaleItem_Quantity] WHERE (((SaleItem.SaleItem_DepositType)=2 Or (SaleItem.SaleItem_DepositType)=3) AND ((SaleItem.SaleItem_Revoke)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=1) AND ((SaleItem.SaleItem_Reversal)<>0));");
			modRecordSet.cnnDB.Execute("UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) ON (SaleItem.SaleItem_StockItemID = DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID) AND (Company.Company_DayEndID = Sale.Sale_DayEndID) SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantitySales = [DayEndDepositItemLnk_QuantitySales]+[SaleItem_Quantity] WHERE (((SaleItem.SaleItem_DepositType)=2 Or (SaleItem.SaleItem_DepositType)=3) AND ((SaleItem.SaleItem_Revoke)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=1) AND ((SaleItem.SaleItem_Reversal)=0));");

			errDesc = "Middle Point";

			modRecordSet.cnnDB.Execute("UPDATE Deposit INNER JOIN ((Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) ON (SaleItem.SaleItem_StockItemID = DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID) AND (Company.Company_DayEndID = Sale.Sale_DayEndID)) ON Deposit.DepositID = DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantitySales = [DayEndDepositItemLnk_QuantitySales]-([SaleItem_Quantity]*[Deposit_Quantity]) WHERE (((SaleItem.SaleItem_DepositType)=3) AND ((SaleItem.SaleItem_Revoke)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=0) AND ((SaleItem.SaleItem_Reversal)<>0));");
			modRecordSet.cnnDB.Execute("UPDATE Deposit INNER JOIN ((Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) ON (SaleItem.SaleItem_StockItemID = DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID) AND (Company.Company_DayEndID = Sale.Sale_DayEndID)) ON Deposit.DepositID = DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantitySales = [DayEndDepositItemLnk_QuantitySales]+([SaleItem_Quantity]*[Deposit_Quantity]) WHERE (((SaleItem.SaleItem_DepositType)=3) AND ((SaleItem.SaleItem_Revoke)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=0) AND ((SaleItem.SaleItem_Reversal)=0));");

			modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN (Deposit INNER JOIN ((Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) ON Company.Company_DayEndID = Sale.Sale_DayEndID) ON Deposit.DepositID = DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID) ON (SaleItem.SaleItem_StockItemID = StockItem.StockItemID) AND (StockItem.StockItem_DepositID = Deposit.DepositID) SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantitySales = [DayEndDepositItemLnk_QuantitySales]-([SaleItem_Quantity]*CInt([SaleItem_ShrinkQuantity]/[Deposit_Quantity]+0.04999)) WHERE (((SaleItem.SaleItem_DepositType)=0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=1) AND ((SaleItem.SaleItem_Reversal)=0));");
			modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN (Deposit INNER JOIN ((Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) ON Company.Company_DayEndID = Sale.Sale_DayEndID) ON Deposit.DepositID = DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID) ON (SaleItem.SaleItem_StockItemID = StockItem.StockItemID) AND (StockItem.StockItem_DepositID = Deposit.DepositID) SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantitySales = [DayEndDepositItemLnk_QuantitySales]+([SaleItem_Quantity]*CInt([SaleItem_ShrinkQuantity]/[Deposit_Quantity]+0.04999)) WHERE (((SaleItem.SaleItem_DepositType)=0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=1) AND ((SaleItem.SaleItem_Reversal)<>0));");

			modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN (Deposit INNER JOIN ((Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) ON Company.Company_DayEndID = Sale.Sale_DayEndID) ON Deposit.DepositID = DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID) ON (SaleItem.SaleItem_StockItemID = StockItem.StockItemID) AND (StockItem.StockItem_DepositID = Deposit.DepositID) SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantitySales = [DayEndDepositItemLnk_QuantitySales]-([SaleItem_Quantity]*[SaleItem_ShrinkQuantity]) WHERE (((SaleItem.SaleItem_DepositType)=0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=0) AND ((SaleItem.SaleItem_Reversal)=0));");
			modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN (Deposit INNER JOIN ((Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) ON Company.Company_DayEndID = Sale.Sale_DayEndID) ON Deposit.DepositID = DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID) ON (SaleItem.SaleItem_StockItemID = StockItem.StockItemID) AND (StockItem.StockItem_DepositID = Deposit.DepositID) SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantitySales = [DayEndDepositItemLnk_QuantitySales]+([SaleItem_Quantity]*[SaleItem_ShrinkQuantity]) WHERE (((SaleItem.SaleItem_DepositType)=0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=0) AND ((SaleItem.SaleItem_Reversal)<>0));");

			if (modUpdate == 1) {
				My.MyProject.Forms.frmDayEnd.Label3.Visible = false;
			}


			if (Strings.Left(modRecordSet.serverPath, 3) == "c:\\") {
				rs = modRecordSet.getRS(ref "SELECT Company.Company_DayEndID FROM Company;");
				lDayend = rs.Fields(0).Value;
				modRecordSet.dltDayEndID = lDayend;
				cn = modRecordSet.openConnectionInstance(ref "templatereport.mdb");
				if (cn == null) {
				} else {
					tryAgainPassword:

					errDesc = "TemplateReport Point";
					cn.Execute("DELETE aDayEnd.* From aDayEnd WHERE (((aDayEnd.DayEndID)=" + lDayend + "));");
					cn.Execute("DELETE aDayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID From aDayEndDepositItemLnk WHERE (((aDayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID)=" + lDayend + "));");
					sql = "INSERT INTO aDayEndDepositItemLnk ( DayEndDepositItemLnk_DayEndID, DayEndDeposittemLnk_DepositID, DayEndDeposittemLnk_DepositType, DayEndDepositItemLnk_Quantity, DayEndDepositItemLnk_QuantitySales, DayEndDepositItemLnk_QuantityShrink, DayEndDepositItemLnk_QuantityGRV, DayEndDepositItemLnk_QuantityRecipe, DayEndDepositItemLnk_QuantityTransfer, DayEndDepositItemLnk_UnitCost, DayEndDepositItemLnk_CaseCost, DayEndDepositItemLnk_CaseQuantity ) ";
					sql = sql + "SELECT aDayEndDepositItemLnk1.DayEndDepositItemLnk_DayEndID, aDayEndDepositItemLnk1.DayEndDeposittemLnk_DepositID, aDayEndDepositItemLnk1.DayEndDeposittemLnk_DepositType, aDayEndDepositItemLnk1.DayEndDepositItemLnk_Quantity, aDayEndDepositItemLnk1.DayEndDepositItemLnk_QuantitySales, aDayEndDepositItemLnk1.DayEndDepositItemLnk_QuantityShrink, aDayEndDepositItemLnk1.DayEndDepositItemLnk_QuantityGRV, aDayEndDepositItemLnk1.DayEndDepositItemLnk_QuantityRecipe, aDayEndDepositItemLnk1.DayEndDepositItemLnk_QuantityTransfer, aDayEndDepositItemLnk1.DayEndDepositItemLnk_UnitCost, aDayEndDepositItemLnk1.DayEndDepositItemLnk_CaseCost, aDayEndDepositItemLnk1.DayEndDepositItemLnk_CaseQuantity From aDayEndDepositItemLnk1 WHERE (((aDayEndDepositItemLnk1.DayEndDepositItemLnk_DayEndID)=" + lDayend + "));";
					cn.Execute(sql);

					cn.Execute("DELETE aGRVDeposit.* FROM aGRVDeposit INNER JOIN aGRV ON aGRVDeposit.GRVDeposit_GRVID = aGRV.GRVID WHERE (((aGRV.GRV_DayEndID)=" + lDayend + "));");
					cn.Execute("DELETE aGRVitem.* FROM aGRVitem INNER JOIN aGRV ON aGRVitem.GRVItem_GRVID = aGRV.GRVID WHERE (((aGRV.GRV_DayEndID)=" + lDayend + "));");
					cn.Execute("DELETE aGRV.* From aGRV WHERE (((aGRV.GRV_DayEndID)=" + lDayend + "));");
					cn.Execute("DELETE aPurchaseOrder.* From aPurchaseOrder WHERE (((aPurchaseOrder.PurchaseOrder_DayEndID)=" + lDayend + "));");

					cn.Execute("INSERT INTO aDayEnd SELECT aDayEnd1.* From aDayEnd1 WHERE (((aDayEnd1.DayEndID)=" + lDayend + "));");

					cn.Execute("INSERT INTO aPurchaseOrder SELECT aPurchaseOrder1.* From aPurchaseOrder1 WHERE (((aPurchaseOrder1.PurchaseOrder_DayEndID)=" + lDayend + "));");
					cn.Execute("INSERT INTO agrv SELECT aGRV1.* From aGRV1 WHERE (((aGRV1.GRV_DayEndID)=" + lDayend + "));");
					cn.Execute("INSERT INTO aGRVItem SELECT aGRVItem1.* FROM aGRVItem1 INNER JOIN aGRV1 ON aGRVItem1.GRVItem_GRVID = aGRV1.GRVID WHERE (((aGRV1.GRV_DayEndID)=" + lDayend + "));");
					cn.Execute("INSERT INTO aGRVDeposit SELECT aGRVDeposit1.* FROM aGRVDeposit1 INNER JOIN aGRV1 ON aGRVDeposit1.GRVDeposit_GRVID = aGRV1.GRVID WHERE (((aGRV1.GRV_DayEndID)=" + lDayend + "));");

				}
			}

			return;
			ErrHandlerr:
			if (Err().Description == "Not a valid password.") {

				modRecordSet.cnnDB.Close();
				modRecordSet.cnnDB = null;
				modRecordSet.cnnDB = new ADODB.Connection();
				strDBPath = modRecordSet.serverPath + "pricing.mdb";
				Path = strDBPath + ";Jet " + "OLEDB:Database Password=lqd";
				//cnnDB.CursorLocation = adUseClient
				modRecordSet.cnnDB.Open("Provider=Microsoft.ACE.OLEDB.12.0;Mode=Share Deny Read|Share Deny Write;Persist Security Info=False;Data Source= " + Path);
				modRecordSet.cnnDB.Execute("ALTER DATABASE PASSWORD Null " + " " + "lqd");
				modRecordSet.cnnDB.Close();
				modRecordSet.cnnDB = null;
				modRecordSet.openConnection();

				goto tryAgainPassword;
				//Resume Next
			} else {
				Interaction.MsgBox("Error while UpdateStockMovement on " + errDesc + " : " + Err().Number + " : " + Err().Description + " : " + Err().Source);
				 // ERROR: Not supported in C#: ResumeStatement

			}
		}
		private static void linkTables()
		{
			ADOX.Catalog cat = default(ADOX.Catalog);
			ADOX.Table tbl = default(ADOX.Table);
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();

			if (fso.FileExists(strLocation)) {
			} else {
				return;
			}

			cat = new ADOX.Catalog();
			short x = 0;
			// Open the catalog.
			cat.let_ActiveConnection(modReport.cnnDBConsReport);

			for (x = cat.Tables.Count - 1; x >= 0; x += -1) {
				switch (Strings.LCase(cat.Tables(x).Name)) {
					case "acustomertransaction":
					case "adayendstockitemlnk":
					case "adeclaration":
					case "asale":
					case "asaleitem":
					case "asuppliertransaction":
						cat.Tables.delete(cat.Tables(x).Name);
						break;
				}
			}
			tbl = new ADOX.Table();
			tbl.Name = "aCustomerTransaction";
			tbl.ParentCatalog = cat;
			tbl.Properties("Jet OLEDB:Link Datasource").Value = strLocation;
			tbl.Properties("Jet OLEDB:Remote Table Name").Value = "CustomerTransaction";
			tbl.Properties("Jet OLEDB:Create Link").Value = true;
			cat.Tables.Append(tbl);

			tbl = new ADOX.Table();
			tbl.Name = "aDayEndStockItemLnk";
			tbl.ParentCatalog = cat;
			tbl.Properties("Jet OLEDB:Link Datasource").Value = strLocation;
			tbl.Properties("Jet OLEDB:Remote Table Name").Value = "DayEndStockItemLnk";
			tbl.Properties("Jet OLEDB:Create Link").Value = true;
			cat.Tables.Append(tbl);

			tbl = new ADOX.Table();
			tbl.Name = "aDeclaration";
			tbl.ParentCatalog = cat;
			tbl.Properties("Jet OLEDB:Link Datasource").Value = strLocation;
			tbl.Properties("Jet OLEDB:Remote Table Name").Value = "Declaration";
			tbl.Properties("Jet OLEDB:Create Link").Value = true;
			cat.Tables.Append(tbl);


			tbl = new ADOX.Table();
			tbl.Name = "aSale";
			tbl.ParentCatalog = cat;
			tbl.Properties("Jet OLEDB:Link Datasource").Value = strLocation;
			tbl.Properties("Jet OLEDB:Remote Table Name").Value = "Sale";
			tbl.Properties("Jet OLEDB:Create Link").Value = true;
			cat.Tables.Append(tbl);

			tbl = new ADOX.Table();
			tbl.Name = "aSaleItem";
			tbl.ParentCatalog = cat;
			tbl.Properties("Jet OLEDB:Link Datasource").Value = strLocation;
			tbl.Properties("Jet OLEDB:Remote Table Name").Value = "SaleItem";
			tbl.Properties("Jet OLEDB:Create Link").Value = true;
			cat.Tables.Append(tbl);
			//
			tbl = new ADOX.Table();
			tbl.Name = "aSupplierTransaction";
			tbl.ParentCatalog = cat;
			tbl.Properties("Jet OLEDB:Link Datasource").Value = strLocation;
			tbl.Properties("Jet OLEDB:Remote Table Name").Value = "SupplierTransaction";
			tbl.Properties("Jet OLEDB:Create Link").Value = true;
			cat.Tables.Append(tbl);

			cat.Tables.Refresh();

			cat = null;

		}

		private static void linkFirstTable(ref string Source)
		{
			ADOX.Catalog cat = default(ADOX.Catalog);
			ADOX.Table tbl = default(ADOX.Table);
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			if (fso.FileExists(strLocation)) {
			} else {
				return;
			}

			cat = new ADOX.Catalog();
			short x = 0;
			//Open the catalog.

			//MsgBox StrLocRep

			cat.let_ActiveConnection(modReport.cnnDBConsReport);

			for (x = cat.Tables.Count - 1; x >= 0; x += -1) {
				switch (Strings.LCase(cat.Tables(x).Name)) {
					case "adayendstockitemlnk":
						cat.Tables.delete(cat.Tables(x).Name);
						break;
				}
			}

			tbl = new ADOX.Table();

			tbl.Name = "aDayEndStockItemLnk";
			tbl.ParentCatalog = cat;
			tbl.Properties("Jet OLEDB:Link Datasource").Value = strLocation;
			tbl.Properties("Jet OLEDB:Remote Table Name").Value = "DayEndStockItemLnk";
			tbl.Properties("Jet OLEDB:Create Link").Value = true;
			cat.Tables.Append(tbl);
			cat.Tables.Refresh();

			cat = null;

		}
		private static void beginConsUpdate()
		{
			int gTotal = 0;
			bool gModeReport = false;
			int gCNT = 0;
			//picInner.Width = 0
			gCNT = 0;
			System.Windows.Forms.Application.DoEvents();
			short x = 0;
			string sql = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			bool lMode = false;

			gModeReport = false;

			modReport.cnnDBConsReport.Execute("DELETE * FROM DayEnd");
			modReport.cnnDBConsReport.Execute("INSERT INTO dayend ( DayEndID, DayEnd_MonthEndID, DayEnd_Date ) SELECT aDayEnd.DayEndID, aDayEnd.DayEnd_MonthEndID, aDayEnd.DayEnd_Date From aDayEnd, Report WHERE (((aDayEnd.DayEndID)>=[Report]![Report_DayEndStartID] And (aDayEnd.DayEndID)<=[Report]![Report_DayEndEndID]));");

			modReport.cnnDBConsReport.Execute("DELETE DayEndStockItemLnkFirst.* FROM DayEndStockItemLnkFirst;");

			rs = modReport.getRSreport1(ref "SELECT aDayEnd.*, aCompany.Company_DayEndID, aCompany.Company_MonthEndID From aDayEnd, Report, aCompany WHERE (((aDayEnd.DayEndID)=[Report]![Report_DayEndStartID]-1));");

			if (rs.RecordCount) {
				if (rs.Fields("DayEnd_MonthEndID").Value == rs.Fields("Company_MonthEndID").Value) {
					//linkFirstTable "pricing"
				} else {
					//linkFirstTable "month" & rs("DayEnd_MonthEndID")
				}

				modReport.cnnDBConsReport.Execute("DELETE * FROM DayEndStockItemLnkFirst");
				modReport.cnnDBConsReport.Execute("INSERT INTO DayEndStockItemLnkFirst SELECT aDayEndStockItemLnk.* FROM Report, aDayEndStockItemLnk INNER JOIN aDayEnd ON aDayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aDayEnd.DayEndID WHERE (((aDayEnd.DayEndID)=[Report]![Report_DayEndStartID]-1));");

			}

			rs.Close();

			rs = modReport.getRSreport1(ref "SELECT DISTINCT DayEnd.DayEnd_MonthEndID, aCompany.Company_MonthEndID FROM DayEnd, aCompany;");

			gTotal = 9 + rs.RecordCount * 9;

			modReport.cnnDBConsReport.Execute("DELETE Payout.* FROM Payout;");
			modReport.cnnDBConsReport.Execute("INSERT INTO Payout SELECT aPayout.* From Report, aPayout WHERE (((aPayout.Payout_DayEndID)>=[Report]![Report_DayEndStartID] And (aPayout.Payout_DayEndID)<=[Report]![Report_DayEndEndID]));");


			modReport.cnnDBConsReport.Execute("DELETE * FROM DayEndStockItemLnk");

			modReport.cnnDBConsReport.Execute("DELETE * FROM DayEndDepositItemLnk");

			modReport.cnnDBConsReport.Execute("DELETE SaleItem.* FROM SaleItem;");


			modReport.cnnDBConsReport.Execute("DELETE Sale.* FROM Sale;");

			modReport.cnnDBConsReport.Execute("DELETE CustomerTransaction.* FROM CustomerTransaction;");

			modReport.cnnDBConsReport.Execute("DELETE Declaration.* FROM Declaration;");

			modReport.cnnDBConsReport.Execute("DELETE SupplierTransaction.* FROM SupplierTransaction;");

			modReport.cnnDBConsReport.Execute("INSERT INTO DayEndStockItemLnk SELECT aDayEndStockItemLnk.* FROM aDayEndStockItemLnk INNER JOIN DayEnd ON aDayEndStockItemLnk.DayEndStockItemLnk_DayEndID = DayEnd.DayEndID;");

			 // ERROR: Not supported in C#: OnErrorStatement

			modReport.cnnDBConsReport.Execute("INSERT INTO DayEndDepositItemLnk SELECT aDayEndDepositItemLnk.* FROM aDayEndDepositItemLnk INNER JOIN DayEnd ON aDayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID = DayEnd.DayEndID;");

			modReport.cnnDBConsReport.Execute("INSERT INTO sale SELECT aSale.* FROM [SELECT aSale.* FROM aSale LEFT JOIN Sale ON aSale.SaleID = Sale.SaleID WHERE (((Sale.SaleID) Is Null))]. AS aSale, Report WHERE (((aSale.Sale_DayEndID)>=[Report]![Report_DayEndStartID] And (aSale.Sale_DayEndID)<=[Report]![Report_DayEndEndID]));");

			modReport.cnnDBConsReport.Execute("INSERT INTO SaleItem SELECT aSaleItem.* FROM (aSaleItem INNER JOIN Sale ON aSaleItem.SaleItem_SaleID = Sale.SaleID) LEFT JOIN SaleItem ON aSaleItem.SaleItemID = SaleItem.SaleItemID WHERE (((SaleItem.SaleItemID) Is Null));");

			modReport.cnnDBConsReport.Execute("INSERT INTO CustomerTransaction SELECT aCustomerTransaction.* From Report, aCustomerTransaction WHERE (((aCustomerTransaction.CustomerTransaction_DayEndID)>=[Report]![Report_DayEndStartID] And (aCustomerTransaction.CustomerTransaction_DayEndID)<=[Report]![Report_DayEndEndID]));");


			sql = "INSERT INTO SupplierTransaction ( SupplierTransactionID, SupplierTransaction_SupplierID, SupplierTransaction_PersonID, SupplierTransaction_TransactionTypeID, SupplierTransaction_MonthEndID, SupplierTransaction_MonthEndIDFor, SupplierTransaction_DayEndID, SupplierTransaction_ReferenceID, SupplierTransaction_Date, SupplierTransaction_Description, SupplierTransaction_Amount, SupplierTransaction_Reference )";
			sql = sql + "SELECT aSupplierTransaction.SupplierTransactionID, aSupplierTransaction.SupplierTransaction_SupplierID, aSupplierTransaction.SupplierTransaction_PersonID, aSupplierTransaction.SupplierTransaction_TransactionTypeID, aSupplierTransaction.SupplierTransaction_MonthEndID, aSupplierTransaction.SupplierTransaction_MonthEndIDFor, aSupplierTransaction.SupplierTransaction_DayEndID, aSupplierTransaction.SupplierTransaction_ReferenceID, aSupplierTransaction.SupplierTransaction_Date, aSupplierTransaction.SupplierTransaction_Description, aSupplierTransaction.SupplierTransaction_Amount, aSupplierTransaction.SupplierTransaction_Reference FROM aSupplierTransaction INNER JOIN DayEnd ON aSupplierTransaction.SupplierTransaction_DayEndID = DayEnd.DayEndID;";

			sql = "INSERT INTO SupplierTransaction ( SupplierTransactionID, SupplierTransaction_SupplierID, SupplierTransaction_PersonID, SupplierTransaction_TransactionTypeID, SupplierTransaction_MonthEndID, SupplierTransaction_MonthEndIDFor, SupplierTransaction_DayEndID, SupplierTransaction_ReferenceID, SupplierTransaction_Date, SupplierTransaction_Description, SupplierTransaction_Amount, SupplierTransaction_Reference ) ";
			sql = sql + "SELECT [SupplierTransaction_MonthEndID] & [SupplierTransactionID] AS Expr1, aSupplierTransaction.SupplierTransaction_SupplierID, aSupplierTransaction.SupplierTransaction_PersonID, aSupplierTransaction.SupplierTransaction_TransactionTypeID, aSupplierTransaction.SupplierTransaction_MonthEndID, aSupplierTransaction.SupplierTransaction_MonthEndIDFor, aSupplierTransaction.SupplierTransaction_DayEndID, aSupplierTransaction.SupplierTransaction_ReferenceID, aSupplierTransaction.SupplierTransaction_Date, aSupplierTransaction.SupplierTransaction_Description, aSupplierTransaction.SupplierTransaction_Amount, aSupplierTransaction.SupplierTransaction_Reference FROM aSupplierTransaction INNER JOIN DayEnd ON aSupplierTransaction.SupplierTransaction_DayEndID = DayEnd.DayEndID;";

			modReport.cnnDBConsReport.Execute(sql);

			modReport.cnnDBConsReport.Execute("INSERT INTO Declaration SELECT aDeclaration.* From Report, aDeclaration WHERE (((aDeclaration.Declaration_DayEndID)>=[Report]![Report_DayEndStartID] And (aDeclaration.Declaration_DayEndID)<=[Report]![Report_DayEndEndID]));");

			modReport.cnnDBConsReport.Execute("UPDATE aCompany INNER JOIN (DayEndStockItemLnk INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) ON aCompany.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_ListCost = [aStockItem]![StockItem_ListCost]/[aStockItem]![StockItem_Quantity], DayEndStockItemLnk.DayEndStockItemLnk_ActualCost = [aStockItem]![StockItem_ActualCost]/[aStockItem]![StockItem_Quantity];");

			modReport.cnnDBConsReport.Execute("UPDATE Report SET Report.Report_Type = " + lMode + ";");

			rs = modReport.getRSreport1(ref "SELECT DayEnd.DayEndID FROM aCompany INNER JOIN DayEnd ON aCompany.Company_DayEndID = DayEnd.DayEndID;");

			if (rs.RecordCount) {
				modReport.cnnDBConsReport.Execute("UPDATE Report SET Report.Report_Heading = [Report_Heading] & '(*)';");

				modReport.cnnDBConsReport.Execute("UPDATE aCompany INNER JOIN DayEndStockItemLnk ON aCompany.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales = 0, DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV = 0;");
				modReport.cnnDBConsReport.Execute("UPDATE aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN ((DayEndStockItemLnk INNER JOIN (Sale INNER JOIN aCompany ON Sale.Sale_DayEndID = aCompany.Company_DayEndID) ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aCompany.Company_DayEndID) INNER JOIN SaleItem ON (DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = SaleItem.SaleItem_StockItemID) AND (Sale.SaleID = SaleItem.SaleItem_SaleID)) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantitySales]+(IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) WHERE (((SaleItem.SaleItem_Recipe)=0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_DepositType)=0) AND ((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null));");

				sql = "UPDATE aSaleItemReciept INNER JOIN (aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN ((DayEndStockItemLnk INNER JOIN (Sale INNER JOIN aCompany ON Sale.Sale_DayEndID = aCompany.Company_DayEndID) ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aCompany.Company_DayEndID) INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID) ON (aSaleItemReciept.SaleItemReciept_StockitemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) AND (aSaleItemReciept.SaleItemReciept_SaleItemID = SaleItem.SaleItemID) SET DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantitySales]+(IIf([SaleItem_Reversal],0-[SaleItemReciept_Quantity]*[SaleItem_Quantity],[SaleItemReciept_Quantity]*[SaleItem_Quantity])) ";
				sql = sql + "WHERE (((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_DepositType)=0) AND ((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null));";

				modReport.cnnDBConsReport.Execute(sql);

				modReport.cnnDBConsReport.Execute("UPDATE aGRV INNER JOIN ((aCompany INNER JOIN DayEndStockItemLnk ON aCompany.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aGRVItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aGRVItem.GRVItem_StockItemID) ON (DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aGRV.GRV_DayEndID) AND (aGRV.GRVID = aGRVItem.GRVItem_GRVID) SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV = [DayEndStockItemLnk_QuantityGRV]+IIf([aGRVItem]![GRVItem_Return],0-[GRVItem_PackSize]*[GRVItem_Quantity],[GRVItem_PackSize]*[GRVItem_Quantity]) WHERE (((aGRV.GRV_GRVStatusID)=3));");
			}

		}

		public static void ExportStockOrlando()
		{
			string dbText = null;
			string sql = null;
			string stFileName = null;
			string lOrder = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsData = default(ADODB.Recordset);

			//Exporting file...
			string lne = null;
			short n = 0;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			//
			//    frmStockTakeSnapshot.remoteSnapShot
			//    DoEvents

			int lMWNo = 0;
			lMWNo = 0;
			if (Interaction.MsgBox("Do you wish to export consolidated quantities for all warehouses?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes) {
				sql = "SELECT Catalogue.Catalogue_Barcode AS BAR_CODE, StockItem.StockItem_Name AS PRODUCT_DESCRIPTION, StockItem.StockItem_ActualCost AS COST, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS STOCK, StockGroup.StockGroup_Name AS DEPT FROM WarehouseStockItemLnk INNER JOIN ((StockItem INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID GROUP BY Catalogue.Catalogue_Barcode, StockItem.StockItem_Name, StockItem.StockItem_ActualCost, StockGroup.StockGroup_Name, Catalogue.Catalogue_Quantity, StockItem.StockItem_Disabled, StockItem.StockItem_Discontinued HAVING (((Catalogue.Catalogue_Barcode)<>'') AND ((Catalogue.Catalogue_Quantity)=1) AND ((StockItem.StockItem_Disabled)=False) AND ((StockItem.StockItem_Discontinued)=False));";
			} else {
				lMWNo = My.MyProject.Forms.frmMWSelect.getMWNo();
				if (lMWNo != 0) {
					sql = "SELECT Catalogue.Catalogue_Barcode AS BAR_CODE, StockItem.StockItem_Name AS PRODUCT_DESCRIPTION, StockItem.StockItem_ActualCost AS COST, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS STOCK, StockGroup.StockGroup_Name AS DEPT FROM WarehouseStockItemLnk INNER JOIN ((StockItem INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID ";
					sql = sql + "GROUP BY Catalogue.Catalogue_Barcode, StockItem.StockItem_Name, StockItem.StockItem_ActualCost, StockGroup.StockGroup_Name, Catalogue.Catalogue_Quantity, StockItem.StockItem_Disabled, StockItem.StockItem_Discontinued, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID HAVING (((Catalogue.Catalogue_Barcode)<>'') AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=" + lMWNo + ") AND ((Catalogue.Catalogue_Quantity)=1) AND ((StockItem.StockItem_Disabled)=False) AND ((StockItem.StockItem_Discontinued)=False));";
				} else {
					return;
				}
			}

			string ptbl = null;
			string t_Day = null;
			string t_Mon = null;

			if (Strings.Len(Strings.Trim(Conversion.Str(DateAndTime.Day(DateAndTime.Today)))) == 1)
				t_Day = "0" + Strings.Trim(Convert.ToString(DateAndTime.Day(DateAndTime.Today)));
			else
				t_Day = Convert.ToString(DateAndTime.Day(DateAndTime.Today));
			if (Strings.Len(Strings.Trim(Conversion.Str(DateAndTime.Month(DateAndTime.Today)))) == 1)
				t_Mon = "0" + Strings.Trim(Convert.ToString(DateAndTime.Month(DateAndTime.Today)));
			else
				t_Mon = Conversion.Str(DateAndTime.Month(DateAndTime.Today));

			ptbl = modRecordSet.serverPath + "4POSStockExp" + Strings.Trim(Convert.ToString(DateAndTime.Year(DateAndTime.Today))) + Strings.Trim(t_Mon) + Strings.Trim(t_Day);

			if (fso.FileExists(ptbl + ".csv"))
				fso.DeleteFile((ptbl + ".csv"));

			FileSystem.FileOpen(1, ptbl + ".csv", OpenMode.Output);
			//Open serverPath & "ProductPerformace.csv" For Output As #1

			rs = modRecordSet.getRS(ref sql);
			//Write Out CSV
			if (rs.BOF | rs.EOF) {
				Interaction.MsgBox("There are no recods to export.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Export Stock");
				System.Windows.Forms.Cursor.Current = Cursors.Default;
				return;
			} else {
				//First line as column headings
				for (n = 0; n <= rs.Fields.Count - 1; n++) {
					lne = lne + Strings.Chr(34) + rs.Fields(n).Name + Strings.Chr(34) + ",";
				}
				lne = lne + Strings.Chr(34) + "NEW_STOCK" + Strings.Chr(34);

				//Print #1, lne

				while (!rs.EOF) {
					lne = "";
					for (n = 0; n <= rs.Fields.Count - 1; n++) {

						if (rs.Fields(n).Type == dbText) {
							lne = lne + Strings.Chr(34) + rs.Fields(n).Value + Strings.Chr(34) + ",";
						} else {
							//If n = 0 Then
							//  lne = lne & "'" & rs(n) & "'" & ","
							//Else
							lne = lne + rs.Fields(n).Value + ",";
							//End If
						}
					}
					lne = Strings.Left(lne, Strings.Len(lne) - 1);
					//get rid of last comma
					lne = lne + ",0";
					FileSystem.PrintLine(1, lne);
					rs.moveNext();
				}

				FileSystem.FileClose(1);
				Interaction.MsgBox("Stock CSV File was successfully exported to : " + ptbl + ".csv");
			}
			System.Windows.Forms.Cursor.Current = Cursors.Default;
		}

//Public Sub ImportStockOrlando()
//
//
//    frmStockTakeAdd.loadItem gID
//
//    Set rs = getRS("SELECT StockGroup_Name FROM StockGroup WHERE StockGroupID =" & Val(DataList1.BoundText))
//    If UCase(mID$(rs("StockGroup_Name"), 1, 8)) = "HANDHELD" Then
//        grpDelete = Trim(rs("StockGroup_Name"))
//
//        cnnDB.Execute "DROP TABLE " & grpDelete
//        cnnDB.Execute "DELETE * FROM StockGroup WHERE StockGroup_Name ='" & grpDelete & "'"
//        loadItem1 2
//    End If
//End Sub


		public static void doMenuForms(ref string lName)
		{
			object frmBuildWizard = null;
			object frmRecipeList = null;
			object frmBackOfficeSetup = null;
			object frmProductPerfomance = null;
			ADODB.Recordset rs = default(ADODB.Recordset);

			Debug.Print(lName);

			ADODB.Recordset rsWH = default(ADODB.Recordset);
			switch (Strings.LCase(lName)) {
				case "frmexportstockorlando":
					ExportStockOrlando();
					break;
				case "frmimportstockorlando":
					exUt_variable = 1;
					My.MyProject.Forms.frmImportStock.loadItems(ref 1);
					break;
				case "frmmaintainfloatcents":
					My.MyProject.Forms.frmFloatLister.ShowDialog();
					break;
				case "frmexportproductperf":
					My.MyProject.Forms.frmExportProductPerfomace.ShowDialog();
					break;
				case "frmglobalupdates":
					My.MyProject.Forms.frmGlobalFilter.editItem(ref 0);
					break;
				case "frmmaintainscaleweights":
					My.MyProject.Forms.frmMaintainWeight.loadItem(ref 0);
					break;
				case "frmstockitembarcodesfile":
					 // ERROR: Not supported in C#: OnErrorStatement

					grvPrin = true;
					My.MyProject.Forms.frmBarcode.ShowDialog();
					break;
				case "frmmaintaincurreny":
					My.MyProject.Forms.frmCurrencySetup.loadItem(ref 0);
					break;
				case "frmmaintainpastelprinting":
					My.MyProject.Forms.frmPastelVariables.loadItem(ref 0);
					break;
				case "frmhandheldutilities":
					exUt_variable = 1;
					My.MyProject.Forms.frmExport.loadItems(ref 1);
					break;
				case "frmstocktakecsv":
					//Jonas
					My.MyProject.Forms.frmStockTakeCSV.ShowDialog();
					break;
				case "frmstocktakeliq":
					My.MyProject.Forms.frmStockTakeLIQ.ShowDialog();
					break;
				case "frmzeroise":
					//exUt_variable = 1
					My.MyProject.Forms.frmZeroise.ShowDialog();
					break;
				case "frmpastelexportfile":
					modBResolutions.blpastel = true;
					report_VATPASTEL();
					ExportToCSVFile();
					break;
				case "frmpastelaccounting":
					modBResolutions.blpastel = false;
					report_VATPASTEL();
					break;
				case "frmcreatebarcodes":
					//Jonas Wrote Barcode design
					 // ERROR: Not supported in C#: OnErrorStatement

					My.MyProject.Forms.frmDesign.ShowDialog();
					break;
				case "frmpricechangerep":
					//Jonas wrote rep for Price change
					//frmpricechange.show 1
					report_NewPriceChange();
					break;
				case "frmrecipeutilities":
					exUt_variable = 2;
					My.MyProject.Forms.frmExport.loadItems(ref 2);
					break;
				case "frmconsolidatedperformance":
					frmProductPerfomance.show(1);
					break;
				case "frmvatreporting":
					report_VATrepporting();
					break;
				case "frmdayhourlyreport":
					report_HourlyDayReport();
					break;
				case "frmhourlyreport":
					report_HourlyReport();
					break;
				case "report_bom":
					My.MyProject.Forms.frmRPfilter.loadItem(ref "recipe");
					break;
				case "frmprintlocation":
					My.MyProject.Forms.frmPrintLocationList.ShowDialog();
					break;
				case "report_pricelistreal":
					My.MyProject.Forms.frmReportPriceList.ShowDialog();
					break;
				case "report_printstockserials":
					report_PrintStockSerialsRPT();
					break;
				case "dobackofficemode":
					if (Strings.UCase(Interaction.InputBox("Input Access Code", "Access Code", "")) == "4POSADMIN") {
						frmBackOfficeSetup.show(1);
					}
					break;
				case "report_dayend":
					My.MyProject.Forms.frmDayEndList.loadItem(ref 0);
					break;
				case "frmcashtransaction":
					My.MyProject.Forms.frmCashTransaction.loadItem();
					break;
				case "frmincrement":
					My.MyProject.Forms.frmIncrementList.loadItem();
					break;
				case "frmpacksize":
					My.MyProject.Forms.frmPackSizeList.loadItem();
					break;
				case "frmrecipe":
					frmRecipeList.show(1);
					break;
				case "frmmonthendlist":
					My.MyProject.Forms.frmMonthendList.loadItem(ref 0);
					break;
				case "frmpricelist":
					My.MyProject.Forms.frmPricelistList.loadItem(ref 0);
					break;
				case "frmpricelistfilter":
					My.MyProject.Forms.frmPricelistFilterList.loadItem(ref 0);
					break;
				case "frmincomeexpense":
					My.MyProject.Forms.frmIncomeExpense.ShowDialog();
					break;
				case "frmstockbreak":
					My.MyProject.Forms.frmStockBreakList.loadItem(ref 0);
					break;
				case "frmstockbreakshrink":
					My.MyProject.Forms.frmStockBreakShrink.loadItem(ref 0);
					break;
				case "frmvnc":
					My.MyProject.Forms.frmVNC.ShowDialog();
					break;
				case "frmpromotion":
					My.MyProject.Forms.frmPromotionList.loadItem(ref 0);
					break;
				case "frmgrvpromotion":
					My.MyProject.Forms.frmGRVPromotionList.loadItem(ref 0);
					break;
				case "frmpriceset":
					My.MyProject.Forms.frmPriceSetList.ShowDialog();
					break;
				case "report_stockvalue":
					//report_StockValue
					//report_StockValuebyG
					//report_StockValueByDept (35)
					My.MyProject.Forms.frmStockValSelect.ShowDialog();
					break;
				case "report_stockvaluebydept":
					//4 Now pricing group
					My.MyProject.Forms.frmStockGroupList.loadItem(ref 4);
					break;
				case "report_depositvalue":
					report_DepositValue();
					break;
				case "frmdepositvalrepdb":
					report_DepositValue_FromRepDB();
					break;
				case "report_stocknegative":
					report_StockNegative();
					break;
				case "report_stockitemfixedactual":
					report_StockItemFixedActual();
					break;
				case "report_stockitembrokenpack":
					report_StockItemBrokenPack();
					break;
				case "report_stockitemdisabled":
					report_StockItemDisabled();
					break;
				case "report_stockitemdiscontinued":
					report_StockItemDiscontinued();
					break;
				case "frmquotedelete":
					My.MyProject.Forms.frmQuoteDelete.ShowDialog();
					break;
				case "frmsupplierstatement":
					My.MyProject.Forms.frmSupplierStatement.ShowDialog();
					break;
				case "frmcustomerstatement":
					My.MyProject.Forms.frmCustomerStatement.ShowDialog();
					break;
				case "report_pricinggroup":
					report_PricingGroup();
					break;
				case "report_pricingmatrix":
					break;
				//report_PricingMatrix
				case "report_deposits":
					report_Deposits();
					break;
				case "report_sets":
					report_Sets();
					break;
				case "frmdayend":
					My.MyProject.Forms.frmDayEnd.ShowDialog();
					break;
				case "frmmonthend":
					My.MyProject.Forms.frmMonthEnd.ShowDialog();
					break;
				case "frmcalculateinterest":
					My.MyProject.Forms.frmCompanySetup.CalcIntPeriod();
					break;
				case "frmcustomerstatementrun":
					My.MyProject.Forms.frmCustomerStatementRun.loadItem();
					break;
				case "frmstocktakesnapshot":
					My.MyProject.Forms.frmStockTakeSnapshot.ShowDialog();
					break;
				case "frmstocktakeprint":
					My.MyProject.Forms.frmStockGroupList.loadItem(ref 1);
					break;
				case "frmkeyboard":
					My.MyProject.Forms.frmKeyboardList.loadItem(ref 0);
					break;
				case "frmlanguage":
					My.MyProject.Forms.frmLangList.loadItem(ref 0);
					break;
				case "frmstockprint":
					//bolCompChk = frmSelCompChk.loadDB(arrCompChk())
					My.MyProject.Forms.frmStockGroupList.loadItem(ref 3);
					break;
				case "frmstocktakeedit":
					My.MyProject.Forms.frmStockGroupList.loadItem(ref 2);
					break;
				case "frmstocktakeedits":
					My.MyProject.Forms.frmStockGroupList.loadItem(ref 5);
					break;
				case "frmpossetup":
					My.MyProject.Forms.frmPOSsetup.loadItem();
					break;
				case "frmcompanysetup":
					My.MyProject.Forms.frmCompanySetup.loadItem();
					break;
				case "frmbuildbarcodes":
					buildBarcodes();
					Interaction.MsgBox("Done", MsgBoxStyle.Information, "Build All Barcodes");
					break;
				case "frmrpstockitemoverride":
					report_StockItemOverride();
					break;
				case "frmupdateposcriteria":
					My.MyProject.Forms.frmUpdatePOScriteria.ShowDialog();
					break;
				case "frmrpstockitempropped":
					report_StockItemPropped();
					break;
				case "frmrpstockduplicatecodes":
					report_StockItemDuplicateCodes();
					break;
				case "frmrpfilter stockitemgrouping":
					My.MyProject.Forms.frmRPfilter.loadItem(ref "stockitemGrouping");
					break;
				case "frmrpfilter stockitemorderlevels":
					My.MyProject.Forms.frmRPfilter.loadItem(ref "stockitemOrderLevels");
					break;
				case "frmrppricecompare":
					My.MyProject.Forms.frmRPpriceCompare.ShowDialog();
					break;
				case "frmstockmulticost":
					My.MyProject.Forms.frmStockMultiCost.ShowDialog();
					break;
				case "frmstockmultiprice":
					My.MyProject.Forms.frmStockMultiPrice.ShowDialog();
					break;
				case "frmstockmultibarcode":
					My.MyProject.Forms.frmStockMultiBarcode.ShowDialog();
					break;
				case "frmstockmultiname":
					My.MyProject.Forms.frmStockMultiName.ShowDialog();
					break;
				case "frmstockitemnew":
					My.MyProject.Forms.frmStockItemNew.ShowDialog();
					break;
				case "frmstockitem":
					My.MyProject.Forms.frmStockList.editItem(ref 0);
					My.MyProject.Forms.frmStockList.ShowDialog();
					break;
				case "frmperson":
					My.MyProject.Forms.frmPersonList.ShowDialog();
					break;
				case "frmstockprice":
					My.MyProject.Forms.frmStockList.editItem(ref 1);
					My.MyProject.Forms.frmStockList.ShowDialog();
					break;
				case "frmmakefinishitem":
					My.MyProject.Forms.frmMakeFinishItem.makeItem();
					break;
				case "frmblocktest":
					My.MyProject.Forms.frmBlockTest.makeItem();
					break;
				case "frmvegproduction":
					My.MyProject.Forms.frmVegTest.makeItem();
					break;
				case "frmcustomer":
					My.MyProject.Forms.frmCustomerList.loadItem(ref 0);
					break;
				case "frmcustomerhistory":
					My.MyProject.Forms.frmCustomerList.loadItem(ref 6);
					break;
				case "frmallocatepayment":
					rs = modRecordSet.getRS(ref "SELECT Company_OpenDebtor From Company;");
					if (rs.RecordCount) {
						if (rs.Fields("Company_OpenDebtor").Value == true) {
							My.MyProject.Forms.frmCustomerList.loadItem(ref 7);
						} else {
							Interaction.MsgBox("In order to use this option you need to Select 'OPEN ITEM DEBTOR' option under 'Store Setup and Security' -> 'General Parameters'");
						}
					} else {
						Interaction.MsgBox("Please download the latest 4POS upgrades!");
					}
					break;

				case "frmcustomerpayment":
					My.MyProject.Forms.frmCustomerList.loadItem(ref 1);
					break;
				case "frmcustomerdebit":
					My.MyProject.Forms.frmCustomerList.loadItem(ref 2);
					break;
				case "frmcustomercredit":
					My.MyProject.Forms.frmCustomerList.loadItem(ref 3);
					break;
				case "frmcustomerdebitnote":
					My.MyProject.Forms.frmCustomerList.loadItem(ref 4);
					break;
				case "frmcustomercreditnote":
					My.MyProject.Forms.frmCustomerList.loadItem(ref 5);
					break;

				case "frmzeroisecd":
					My.MyProject.Forms.frmZeroiseCD.ShowDialog();
					break;
				case "frmzeroiseed":
					My.MyProject.Forms.frmZeroiseED.ShowDialog();
					break;

				case "frmsupplier":
					My.MyProject.Forms.frmSupplierList.loadItem(ref 0);
					break;
				case "frmsupplierpayment":
					My.MyProject.Forms.frmSupplierList.loadItem(ref 1);
					break;
				case "frmsupplierdebit":
					My.MyProject.Forms.frmSupplierList.loadItem(ref 2);
					break;
				case "frmsuppliercredit":
					My.MyProject.Forms.frmSupplierList.loadItem(ref 3);
					break;
				case "frmsupplierdeposit":
					My.MyProject.Forms.frmSupplierList.loadItem(ref 4);
					break;
				case "frmchannel":
					My.MyProject.Forms.frmChannelList.ShowDialog();
					break;
				case "frmpos":
					My.MyProject.Forms.frmPOSlist.ShowDialog();
					break;
				case "frmwh":
					My.MyProject.Forms.frmWHlist.ShowDialog();
					break;
				case "frmpayoutreason":
					My.MyProject.Forms.frmPayoutGroupList.loadItem(ref 0);
					break;
				case "frmpricinggroup":
					My.MyProject.Forms.frmPricingGroupList.ShowDialog();
					break;
				case "frmstockgroup":
					My.MyProject.Forms.frmStockGroupList.loadItem(ref 0);
					break;
				case "frmdeposit":
					My.MyProject.Forms.frmDepositList.ShowDialog();
					break;
				case "frmdeposittakeprint":
					report_DepositTake();
					break;
				case "frmdeposittakeedit":
					My.MyProject.Forms.frmDepositTake.loadItem();
					break;
				case "frmpricingmatrix":
					My.MyProject.Forms.frmPricingMatrix.ShowDialog();
					break;
				case "frmset":
					My.MyProject.Forms.frmSetList.ShowDialog();
					break;
				case "frmreportgroups":
					My.MyProject.Forms.frmReportGroupList.ShowDialog();
					break;
				case "frmstocktransfer":
					My.MyProject.Forms.frmStockTransfer.ShowDialog();
					break;
				case "frmstocktransfermw":
					//Multi Warehouse change     frmStockTransfer.show 1
					My.MyProject.Forms.frmStockTransferWH.ShowDialog();
					break;
				case "frmorder":
					My.MyProject.Forms.frmOrder.ShowDialog();
					break;
				case "frmorderprint":
					My.MyProject.Forms.frmOrderPrint.ShowDialog();
					break;
				case "frmgrv":
					My.MyProject.Forms.frmGRVselect.loadItem();
					break;
				case "frmgrvprint":
					My.MyProject.Forms.frmGRVprint.ShowDialog();
					break;
				case "frmorderwizard":
					My.MyProject.Forms.frmOrderWizard.ShowDialog();
					break;
				case "frmgrvblind":
					My.MyProject.Forms.frmGRVblind.ShowDialog();
					break;
				case "frmstockitembarcodes":
					 // ERROR: Not supported in C#: OnErrorStatement

					//*Removes the error "Object was unloaded" on Security Access Barcoodes Submenu
					grvPrin = false;
					My.MyProject.Forms.frmBarcode.ShowDialog();
					break;
				case "frmstockitembarcodesscale":
					 // ERROR: Not supported in C#: OnErrorStatement

					//*Removes the error "Object was unloaded" on Security Access Barcoodes Submenu
					grvPrin = false;
					scaleBCPrint = true;
					My.MyProject.Forms.frmBarcode.ShowDialog();
					scaleBCPrint = false;
					break;
				case "frmpersonbarcodes":
					 // ERROR: Not supported in C#: OnErrorStatement

					My.MyProject.Forms.frmBarcodePerson.ShowDialog();
					break;
				case "report_stocksalesshrink":
					My.MyProject.Forms.frmStockSalesShrink.ShowDialog();
					break;
				case "report_stockitemsales":
					rsWH = modRecordSet.getRS(ref "SELECT COUNT(WarehouseID) AS COUNTWarehouseID FROM Warehouse;");
					if (rsWH.RecordCount) {
						if (Information.IsDBNull(rsWH.Fields("COUNTWarehouseID").Value)) {
						} else {
							if (rsWH.Fields("COUNTWarehouseID").Value > 1) {
								Interaction.MsgBox("This report cannot work with multiple Warehouses.");
								return;
							}
						}
					}

					My.MyProject.Forms.frmStockSales.reportType = 0;
					My.MyProject.Forms.frmStockSales.Text = "Stock Item Sales Listing Order";
					My.MyProject.Forms.frmStockSales.ShowDialog();
					break;
				case "report_stocksalescompare":
					My.MyProject.Forms.frmStockSales.reportType = 1;
					My.MyProject.Forms.frmStockSales.Text = "Stock Item Sales Comparision Listing Order";
					My.MyProject.Forms.frmStockSales.ShowDialog();
					break;
				case "frmbasketvalue":
					report_BasketValue();
					break;
				case "report_grvdetails":
					report_GRVDetails();
					break;
				case "report_profitbydayend":
					report_ProfitByDayEnd();
					break;
				case "report_stocktakenote":
					report_StockTakeNotes();
					break;
				case "frmstockvalrepdb":
					report_StockValuebyGX_RepDB(ref "");
					break;
				case "report_stockmovementbyday":
					report_StockMovementByDay();
					break;
				case "report_stockquantity":
					//report_StockQuantity
					My.MyProject.Forms.frmStockList2.editItem(ref 2);
					My.MyProject.Forms.frmStockList2.ShowDialog();
					break;
				case "report_stockquantityall":
					// bongie made report
					My.MyProject.Forms.frmStock.ShowDialog();
					break;
				case "report_stockcostvariance":
					report_StockCostVariance(ref 0);
					break;
				case "report_stockcostvarianceactual":
					report_StockCostVariance(ref 1);
					break;
				case "frmgroupsales":
					My.MyProject.Forms.frmGroupSales.ShowDialog();
					break;
				case "doreportmode":
					break;
				//            doReportMode
				case "frmbuildwizard":
					frmBuildWizard.show(1);
					break;
				case "frmpostransactionlist":
					My.MyProject.Forms.frmPOSreport.ShowDialog();
					break;
				case "frmrevoketransactionlist":
					report_RevokeTransactionlist();
					break;
				case "frmproductperformanceemployee":
					report_ProductPerformanceEmployee();
					break;
				case "frmproductperformancecustomer":
					report_ProductPerformanceCustomerByGroup();
					break;
				case "frmdealcomparison":
					report_ProductPerformanceGRVDeals();
					break;
				case "frmwaitrontotals":
					report_WaitronTotals();
					break;
				case "report_suppliertransactions":
					report_SupplierTransactions();
					break;
				case "frmtopselect":
					My.MyProject.Forms.frmTopSelect.ShowDialog();
					break;
				//frmTopSelectCustomer.show 1
				case "frmtopselectnon":
					My.MyProject.Forms.frmTopSelectNon.ShowDialog();
					break;
				case "frmtopselectgrv":
					My.MyProject.Forms.frmTopSelectGRV.ShowDialog();
					break;
				case "frmitemitem":
					My.MyProject.Forms.frmItemItem.ShowDialog();
					break;
				case "frmitem":
					My.MyProject.Forms.frmItem.ShowDialog();
					break;
				case "report_stockbreaktransaction":
					report_StockBreakTransaction();
					break;
				case "report_salescube":
					report_SalesCube();
					break;
				case "report_banking":
					report_Banking();
					break;
				case "report_shrinkage":
					report_Shrinkage();
					break;
				case "report_payout":
					report_Payout();
					break;
				case "report_payoutreason":
					report_PayoutReason();
					break;
				case "report_outage":
					report_Outage();
					break;
				case "report_discount":
					report_Discount();
					break;
				//report_Gratuity
				case "report_gratuity":
					report_Gratuity();
					break;
				case "report_deposit":
					report_Deposit();
					break;
				case "report_customermovement":
					report_CustomerMovement();
					break;
				case "report_customermovementcd":
					report_CustomerMovementCD();
					break;
				case "frmitemgroup":
					My.MyProject.Forms.frmItemGroup.ShowDialog();
					break;
				case "report_customerbalance":
					report_CustomerBalance();
					break;
				case "report_supplierbalance":
					report_SupplierBalance();
					break;
				case "report_pos1":
					report_POS(ref 1);
					break;
				case "report_pos2":
					report_POS(ref 2);
					break;
				case "report_pos3":
					report_POS(ref 3);
					break;
				case "report_pos4":
					report_POS(ref 4);
					break;
				case "report_pos5":
					report_POS(ref 5);
					break;
				case "report_pos6":
					report_POS(ref 6);
					break;
				case "report_pos7":
					report_POS(ref 7);
					break;
				case "report_pos8":
					report_POS(ref 8);
					break;
				case "report_pos9":
					report_POS(ref 9);
					break;
				case "report_pos10":
					report_POS(ref 10);
					break;
				case "report_pos11":
					report_POS(ref 11);
					break;
				case "report_pos12":
					report_POS(ref 12);
					break;
				case "buildscalefile":
					buildScaleFile();
					break;

			}

		}


		private static void buildScaleFile()
		{
			ADODB.Recordset rsScale = default(ADODB.Recordset);
			ADODB.Recordset rsData = default(ADODB.Recordset);
			string lString = null;
			string lFormat = null;
			string HeadingString1 = null;
			string HeadingString2 = null;
			string lWeighted = null;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			Scripting.TextStream lTextstream = default(Scripting.TextStream);
			 // ERROR: Not supported in C#: OnErrorStatement

			rsScale = modRecordSet.getRS(ref "SELECT Scale.* FROM Scale;");
			while (!(rsScale.EOF)) {
				rsData = modRecordSet.getRS(ref "SELECT Right('0000'+[Catalogue_Barcode],4) AS code, Format([CatalogueChannelLnk_Price],'Fixed') AS price, StockItem.StockItem_Name, StockGroup.StockGroup_Name, StockItem.StockItem_NonWeighted FROM (StockItem INNER JOIN (CatalogueChannelLnk INNER JOIN Catalogue ON (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = Catalogue.Catalogue_Quantity) AND (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = Catalogue.Catalogue_StockItemID)) ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((Catalogue.Catalogue_Quantity)=1) AND ((StockItem.StockItem_Disabled)=False) AND ((StockItem.StockItem_VariablePrice)=True));");
				switch (rsScale.Fields("Scale_format").Value) {
					case 0:
						rsData.MoveFirst();
						while (!(rsData.EOF)) {

							HeadingString1 = Strings.Left(rsData.Fields("Stockitem_Name").Value, 16);
							HeadingString2 = "";
							if (Strings.Len(rsData.Fields("Stockitem_Name").Value) > 16) {
								while (!(Strings.Right(HeadingString1, 1) == " ")) {
									HeadingString1 = Strings.Left(HeadingString1, Strings.Len(HeadingString1) - 1);
								}
								HeadingString2 = Strings.Mid(rsData.Fields("Stockitem_Name").Value, Strings.Len(HeadingString1) + 1);
							}
							HeadingString1 = Strings.Left(HeadingString1 + new string(" ", 16), 16);
							HeadingString2 = Strings.Left(HeadingString2 + new string(" ", 16), 16);
							if (rsData.Fields("StockItem_NonWeighted").Value)
								lWeighted = "01";
							else
								lWeighted = "00";
							lString = lString + Constants.vbCrLf + "#" + rsData.Fields("code").Value + "$" + rsData.Fields("price").Value + "%#000%$" + lWeighted + "%(A" + HeadingString1 + "%)A" + HeadingString2 + "%[" + Strings.Left(rsData.Fields("StockGroup_Name").Value + new string(" ", 15), 15);
							rsData.moveNext();
						}
						break;
					case 1:
						rsData.MoveFirst();
						while (!(rsData.EOF)) {

							HeadingString1 = Strings.Left(rsData.Fields("Stockitem_Name").Value, 22);
							HeadingString2 = "";
							if (Strings.Len(rsData.Fields("Stockitem_Name").Value) > 22) {
								while (!(Strings.Right(HeadingString1, 1) == " " | string.IsNullOrEmpty(HeadingString1))) {
									HeadingString1 = Strings.Left(HeadingString1, Strings.Len(HeadingString1) - 1);
								}
								HeadingString2 = Strings.Mid(rsData.Fields("Stockitem_Name").Value, Strings.Len(HeadingString1) + 1);
							}
							HeadingString1 = Strings.Left(HeadingString1 + new string(" ", 22), 22);
							HeadingString2 = Strings.Left(HeadingString2 + new string(" ", 21), 21);
							if (rsData.Fields("StockItem_NonWeighted").Value)
								lWeighted = "01";
							else
								lWeighted = "00";
							lString = lString + Constants.vbCrLf + " %*0 #" + rsData.Fields("code").Value + " $" + Strings.Right("00000" + Strings.Replace(rsData.Fields("price").Value, ".", ""), 5) + " %#000 %$" + lWeighted + "%&" + rsScale.Fields("ScaleID").Value + rsData.Fields("code").Value + " %(A" + HeadingString1 + " %)A" + HeadingString2 + " %[" + Strings.Left(rsData.Fields("StockGroup_Name").Value + new string(" ", 15), 15) + " %]" + new string(" ", 15) + " %~";
							rsData.moveNext();
						}
						break;
				}
				if (fso.FileExists(rsScale.Fields("Scale_Path").Value))
					fso.DeleteFile(rsScale.Fields("Scale_Path").Value);
				if (Strings.Len(lString)) {
					lTextstream = fso.CreateTextFile(rsScale.Fields("Scale_Path").Value, true);
					lTextstream.Write(Strings.Mid(lString, 3));
					lTextstream.Close();
				}
				rsScale.moveNext();
			}
		}

		public static void loadDayEndReportPrev(ref int id, ref int monthId)
		{
			int lTotal = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsBanking = default(ADODB.Recordset);
			ADODB.Recordset rsPayout = default(ADODB.Recordset);
			ADODB.Recordset rsSupplier = default(ADODB.Recordset);
			ADODB.Recordset rsShrink = default(ADODB.Recordset);
			ADODB.Recordset rsCustomer = default(ADODB.Recordset);
			ADODB.Recordset rsQuote = default(ADODB.Recordset);
			ADODB.Recordset rsConsignment = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryDayEndForm
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryDayEndForm.rpt");
			int gParameters = 0;
			const short gParChannel = 1;
			const short gParStock = 2;
			const short gParShrink = 4;
			const short gParSupplier = 8;
			const short gParCustomer = 16;
			const short gParQuote = 32;
			const short gParConsignment = 64;
			const short gParPastelReport = 128;
			//Pastel Variable

			ADODB.Connection cn = default(ADODB.Connection);
			short x = 0;
			string databaseName = null;

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			gParameters = Convert.ToInt32(0 + rs.Fields("Company_DayEndBit").Value);
			rs.Close();

			rs = modRecordSet.getRS(ref "SELECT * FROM DayEnd WHERE DayEndID = " + id);
			//ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			Report.Database.Tables(1).SetDataSource(rs);
			databaseName = "month" + monthId + ".mdb";
			cn = modRecordSet.openConnectionInstance(ref Convert.ToString(databaseName));
			if (cn == null) {
				return;
			}

			if (My.MyProject.Forms.frmMenu.gSuper == true) {
				sql = "SELECT POS.POSID, POS.POS_Name, Sum(Declaration.Declaration_Cash) AS SumOfDeclaration_Cash, Sum(Declaration.Declaration_CashServer) AS SumOfDeclaration_CashServer, Sum(Declaration.Declaration_CashCount) AS SumOfDeclaration_CashCount, Sum(Declaration.Declaration_Cheque) AS SumOfDeclaration_Cheque, Sum(Declaration.Declaration_ChequeServer) AS SumOfDeclaration_ChequeServer, Sum(Declaration.Declaration_ChequeCount) AS SumOfDeclaration_ChequeCount, Sum(Declaration.Declaration_Card) AS SumOfDeclaration_Card, Sum(Declaration.Declaration_CardServer) AS SumOfDeclaration_CardServer, Sum(Declaration.Declaration_CardCount) AS SumOfDeclaration_CardCount, Sum(Declaration.Declaration_Payout) AS SumOfDeclaration_Payout, Sum(Declaration.Declaration_PayoutServer) AS SumOfDeclaration_PayoutServer, Sum(Declaration.Declaration_PayoutCount) AS SumOfDeclaration_PayoutCount FROM Declaration INNER JOIN POS ON Declaration.Declaration_POSID = POS.POSID Where (((Declaration.Declaration_DayEndID) = " + id + ")) ";
				sql = sql + "GROUP BY POS.POSID, POS.POS_Name;";
			} else {
				sql = "SELECT POS.POSID, POS.POS_Name, Sum(IIf(IIf(IsNull(Declaration.Declaration_CashDrop),0,Declaration.Declaration_CashDrop)=0,Declaration.Declaration_Cash,Declaration.Declaration_CashDrop)) AS SumOfDeclaration_Cash, Sum(IIf(IIf(IsNull(Declaration.Declaration_CashServerDrop),0,Declaration.Declaration_CashServerDrop)=0,Declaration.Declaration_CashServer,Declaration.Declaration_CashServerDrop)) AS SumOfDeclaration_CashServer, Sum(IIf(IIf(IsNull(Declaration.Declaration_CashCountDrop),0,Declaration.Declaration_CashCountDrop)=0,Declaration.Declaration_CashCount,Declaration.Declaration_CashCountDrop)) AS SumOfDeclaration_CashCount, ";
				sql = sql + "Sum(Declaration.Declaration_Cheque) AS SumOfDeclaration_Cheque, Sum(Declaration.Declaration_ChequeServer) AS SumOfDeclaration_ChequeServer, Sum(Declaration.Declaration_ChequeCount) AS SumOfDeclaration_ChequeCount, Sum(Declaration.Declaration_Card) AS SumOfDeclaration_Card, Sum(Declaration.Declaration_CardServer) AS SumOfDeclaration_CardServer, Sum(Declaration.Declaration_CardCount) AS SumOfDeclaration_CardCount, Sum(Declaration.Declaration_Payout) AS SumOfDeclaration_Payout, Sum(Declaration.Declaration_PayoutServer) AS SumOfDeclaration_PayoutServer, Sum(Declaration.Declaration_PayoutCount) AS SumOfDeclaration_PayoutCount FROM Declaration INNER JOIN POS ON Declaration.Declaration_POSID = POS.POSID Where (((Declaration.Declaration_DayEndID) = " + id + ")) ";
				sql = sql + "GROUP BY POS.POSID, POS.POS_Name;";
			}
			Debug.Print(sql);
			//Set rsBanking = getRS(sql)
			rsBanking = new ADODB.Recordset();
			rsBanking.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);

			//Set rsPayout = getRS("select * from Payout WHERE Payout_DayEndID = " & id)
			rsPayout = new ADODB.Recordset();
			sql = "select * from M_Payout WHERE Payout_DayEndID = " + id;
			rsPayout.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);

			if (rsBanking.RecordCount == 0) {
				Report.ReportDefinition.Sections("Section2").SectionFormat.EnableSuppress = true;
				Report.ReportDefinition.Sections("Section3").SectionFormat.EnableSuppress = true;
			} else {
				Report.ReportDefinition.Sections("Section2").SectionFormat.EnableSuppress = false;
				Report.ReportDefinition.Sections("Section3").SectionFormat.EnableSuppress = false;
				Report.OpenSubreport("Subreport1").Database.Tables(1).SetDataSource(rsBanking);
				Report.OpenSubreport("Subreport2").Database.Tables(1).SetDataSource(rsBanking);
			}
			if (rsPayout.RecordCount == 0) {
				Report.ReportDefinition.Sections("Section4").SectionFormat.EnableSuppress = true;
			} else {
				Report.ReportDefinition.Sections("Section4").SectionFormat.EnableSuppress = false;
				Report.OpenSubreport("Subreport4").Database.Tables(1).SetDataSource(rsPayout);
			}

			//************************************
			//*** Sales Channels
			//************************************

			if (gParameters & gParChannel) {
				rs = modRecordSet.getRS(ref "SELECT * FROM Channel");

				while (!(rs.EOF)) {
					switch (rs.Fields("ChannelID").Value) {
						case 1:
							Report.SetParameterValue("txtSC1", rs.Fields("Channel_Code"));
							break;
						case 2:
							Report.SetParameterValue("txtSC2", rs.Fields("Channel_Code"));
							break;
						case 3:
							Report.SetParameterValue("txtSC3", rs.Fields("Channel_Code"));
							break;
						case 4:
							Report.SetParameterValue("txtSC4", rs.Fields("Channel_Code"));
							break;
						case 5:
							Report.SetParameterValue("txtSC5", rs.Fields("Channel_Code"));
							break;
						case 6:
							Report.SetParameterValue("txtSC6", rs.Fields("Channel_Code"));
							break;
						case 7:
							Report.SetParameterValue("txtSC7", rs.Fields("Channel_Code"));
							break;
						case 8:
							Report.SetParameterValue("txtSC8", rs.Fields("Channel_Code"));
							break;
						case 9:
							Report.SetParameterValue("txtSC9", rs.Fields("Channel_Code"));
							break;
					}
					rs.moveNext();
				}
				rs.Close();

				//Set rs = getRS("SELECT Sum(Sale.Sale_Discount) AS amount FROM Consignment RIGHT JOIN (Consignment AS Consignment_1 RIGHT JOIN Sale ON Consignment_1.Consignment_SaleID = Sale.SaleID) ON Consignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((Consignment.ConsignmentID) Is Null) AND ((Consignment_1.ConsignmentID) Is Null) AND ((Sale.Sale_PaymentType)<>5));")
				//Set rs = New Recordset
				if (rs.State)
					rs.Close();
				sql = "SELECT Sum(Sale.Sale_Discount) AS amount FROM Consignment RIGHT JOIN (Consignment AS Consignment_1 RIGHT JOIN Sale ON Consignment_1.Consignment_SaleID = Sale.SaleID) ON Consignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((Consignment.ConsignmentID) Is Null) AND ((Consignment_1.ConsignmentID) Is Null) AND ((Sale.Sale_PaymentType)<>5));";
				rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);
				if (Information.IsDBNull(rs.Fields("amount").Value)) {
					Report.SetParameterValue("txtSCmDiscount", "0.00");
				} else {
					if (rs.RecordCount) {
						Report.SetParameterValue("txtSCmDiscount", Strings.FormatNumber(0 - rs.Fields("amount").Value, 2));
					} else {
						Report.SetParameterValue("txtSCmDiscount", "0.00");
					}
				}
				rs.Close();

				//Set rs = getRS("SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS SCTotal, Sale.Sale_ChannelID FROM Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = False) And ((Consignment.ConsignmentID) Is Null) And ((Consignment_1.ConsignmentID) Is Null) And ((Sale.Sale_DayEndID) = " & id & ")) GROUP BY Sale.Sale_ChannelID;")
				//Set rs = New Recordset
				if (rs.State)
					rs.Close();
				sql = "SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS SCTotal, Sale.Sale_ChannelID FROM Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = False) And ((Consignment.ConsignmentID) Is Null) And ((Consignment_1.ConsignmentID) Is Null) And ((Sale.Sale_DayEndID) = " + id + ")) GROUP BY Sale.Sale_ChannelID;";
				rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);
				lTotal = Convert.ToDecimal(Report.ParameterFields("txtSCmDiscount").ToString);
				while (!(rs.EOF)) {
					switch (rs.Fields("Sale_ChannelID").Value) {
						case 1:
							Report.SetParameterValue("txtSCm1", Strings.FormatNumber(rs.Fields("SCTotal").Value, 2));
							break;
						case 2:
							Report.SetParameterValue("txtSCm2", Strings.FormatNumber(rs.Fields("SCTotal").Value, 2));
							break;
						case 3:
							Report.SetParameterValue("txtSCm3", Strings.FormatNumber(rs.Fields("SCTotal").Value, 2));
							break;
						case 4:
							Report.SetParameterValue("txtSCm4", Strings.FormatNumber(rs.Fields("SCTotal").Value, 2));
							break;
						case 5:
							Report.SetParameterValue("txtSCm5", Strings.FormatNumber(rs.Fields("SCTotal").Value, 2));
							break;
						case 6:
							Report.SetParameterValue("txtSCm6", Strings.FormatNumber(rs.Fields("SCTotal").Value, 2));
							break;
						case 7:
							Report.SetParameterValue("txtSCm7", Strings.FormatNumber(rs.Fields("SCTotal").Value, 2));
							break;
						case 8:
							Report.SetParameterValue("txtSCm8", Strings.FormatNumber(rs.Fields("SCTotal").Value, 2));
							break;
						case 9:
							Report.SetParameterValue("txtSCm9", Strings.FormatNumber(rs.Fields("SCTotal").Value, 2));
							break;
					}
					lTotal = lTotal + rs.Fields("SCTotal").Value;
					rs.moveNext();
				}
				Report.SetParameterValue("txtSCmTotal", Strings.FormatNumber(lTotal, 2));
			} else {
				Report.ReportDefinition.Sections("Section5").SectionFormat.EnableSuppress = true;
			}

			if (gParameters & gParStock) {
				//*******************************************
				//***Stock Movement
				//*******************************************
				//Set rs = getRS("SELECT Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost]) AS listSales, Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ActualCost]) AS actualSales, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS listShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actualShrink, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost]) AS listGRV, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ActualCost]) AS actualGRV From DayEndStockItemLnk WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)=" & id & "));")
				if (rs.State)
					rs.Close();
				sql = "SELECT Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost]) AS listSales, Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ActualCost]) AS actualSales, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS listShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actualShrink, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost]) AS listGRV, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ActualCost]) AS actualGRV From DayEndStockItemLnk WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)=" + id + "));";
				rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);
				if (rs.RecordCount) {
					Report.SetParameterValue("txtSHRL", Strings.FormatNumber(rs.Fields("listShrink").Value, 2));
					Report.SetParameterValue("txtSHRA", Strings.FormatNumber(rs.Fields("actualShrink").Value, 2));
					Report.SetParameterValue("txtGRVL", Strings.FormatNumber(rs.Fields("listGRV").Value, 2));

					Report.SetParameterValue("txtGRVA", Strings.FormatNumber(rs.Fields("actualGRV").Value, 2));
					Report.SetParameterValue("txtSaleL", Strings.FormatNumber(rs.Fields("listSales").Value, 2));
					Report.SetParameterValue("txtSaleA", Strings.FormatNumber(rs.Fields("actualSales").Value, 2));
				}

				//Set rs = getRS("SELECT Sum(([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ListCost]) AS list, Sum(([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_actualCost]) AS actual From DayEndStockItemLnk WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)=" & id & "));")
				if (rs.State)
					rs.Close();
				sql = "SELECT Sum(([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ListCost]) AS list, Sum(([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_actualCost]) AS actual From DayEndStockItemLnk WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)=" + id + "));";
				rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);

				if (rs.RecordCount) {
					Report.SetParameterValue("txtSHLclose", Strings.FormatNumber(rs.Fields("list").Value, 2));
					Report.SetParameterValue("txtSHAclose", Strings.FormatNumber(rs.Fields("actual").Value, 2));
				}

				rs = modRecordSet.getRSwaitron(ref "SELECT Sum([DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk_ListCost]) AS list, Sum([DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk_actualCost]) AS actual From DayEndStockItemLnk WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)=" + id + "));", ref cn);
				if (rs.RecordCount) {
					Report.SetParameterValue("txtSHLopen", Strings.FormatNumber(rs.Fields("list").Value, 2));
					Report.SetParameterValue("txtSHAopen", Strings.FormatNumber(rs.Fields("actual").Value, 2));
				} else {
					Report.SetParameterValue("txtSHLopen", Strings.FormatNumber(0, 2));
					Report.SetParameterValue("txtSHAopen", Strings.FormatNumber(0, 2));
				}

				rs = modRecordSet.getRSwaitron(ref "SELECT Sum(([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ListCost]) AS list, Sum(([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_actualCost]) AS actual From DayEndStockItemLnk WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)=" + id - 1 + "));", ref cn);
				if (rs.RecordCount) {
					Report.SetParameterValue("txtSHLPrevclose", Strings.FormatNumber(rs.Fields("list").Value, 2));
					Report.SetParameterValue("txtSHAPrevclose", Strings.FormatNumber(rs.Fields("actual").Value, 2));
				} else {
					Report.SetParameterValue("txtSHLPrevclose", Strings.FormatNumber(0, 2));
					Report.SetParameterValue("txtSHAPrevclose", Strings.FormatNumber(0, 2));
				}
				if (string.IsNullOrEmpty(Report.ParameterFields("txtSHLPrevclose").ToString))
					Report.SetParameterValue("txtSHLPrevclose", Report.ParameterFields("txtSHLopen").ToString);
				if (string.IsNullOrEmpty(Report.ParameterFields("txtSHAPrevclose").ToString))
					Report.SetParameterValue("txtSHAPrevclose", Report.ParameterFields("txtSHAopen").ToString);
				if (string.IsNullOrEmpty(Report.ParameterFields("txtSHLopen").ToString)) {
					if (string.IsNullOrEmpty(Report.ParameterFields("txtSHLPrevclose").ToString)) {
						Report.SetParameterValue("txtSVarianceL", Strings.FormatNumber(0, 2));
					} else {
						Report.SetParameterValue("txtSVarianceL", Strings.FormatNumber(0 - Convert.ToDecimal(Report.ParameterFields("txtSHLPrevclose").ToString), 2));
					}
				} else {
					if (string.IsNullOrEmpty(Report.ParameterFields("txtSHLPrevclose").ToString)) {
						Report.SetParameterValue("txtSVarianceL", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtSHLopen").ToString), 2));
					} else {
						Report.SetParameterValue("txtSVarianceL", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtSHLopen").ToString) - Convert.ToDecimal(Report.ParameterFields("txtSHLPrevclose").ToString), 2));
					}
				}

				if (string.IsNullOrEmpty(Report.ParameterFields("txtSHAopen").ToString)) {
					if (string.IsNullOrEmpty(Report.ParameterFields("txtSHAPrevclose").ToString)) {
						Report.SetParameterValue("txtSVarianceL", Strings.FormatNumber(0, 2));
					} else {
						Report.SetParameterValue("txtSVarianceL", Strings.FormatNumber(0 - Convert.ToDecimal(Report.ParameterFields("txtSHAPrevclose").ToString), 2));
					}
				} else {
					if (string.IsNullOrEmpty(Report.ParameterFields("txtSHAPrevclose").ToString)) {
						Report.SetParameterValue("txtSVarianceL", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtSHAopen").ToString), 2));
					} else {
						Report.SetParameterValue("txtSVarianceL", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtSHAopen").ToString) - Convert.ToDecimal(Report.ParameterFields("txtSHAPrevclose").ToString), 2));
					}
				}

			} else {
				Report.ReportDefinition.Sections("Section6").SectionFormat.EnableSuppress = true;
			}

			if (gParameters & gParShrink) {
				rsShrink = modRecordSet.getRSwaitron(ref "SELECT StockItem.StockItem_Name, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS list, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actual FROM DayEndStockItemLnk INNER JOIN StockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = StockItem.StockItemID Where (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0) And ((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) = " + id + ")) GROUP BY StockItem.StockItem_Name ORDER BY StockItem.StockItem_Name;", ref cn);

				if (rsShrink.RecordCount == 0) {
					Report.ReportDefinition.Sections("Section7").SectionFormat.EnableSuppress = true;
				} else {
					Report.ReportDefinition.Sections("Section7").SectionFormat.EnableSuppress = false;
					Report.OpenSubreport("Subreport4").Database.Tables(1).SetDataSource(rsShrink);
				}
			} else {
				Report.ReportDefinition.Sections("Section7").SectionFormat.EnableSuppress = true;
			}

			if (gParameters & gParSupplier) {
				rsSupplier = modRecordSet.getRSwaitron(ref "SELECT Supplier.Supplier_Name, SupplierTransaction.* FROM SupplierTransaction INNER JOIN Supplier ON SupplierTransaction.SupplierTransaction_SupplierID = Supplier.SupplierID Where (((SupplierTransaction.SupplierTransaction_DayEndID) = " + id + ") And ((SupplierTransaction.SupplierTransaction_TransactionTypeID) = 2 Or (SupplierTransaction.SupplierTransaction_TransactionTypeID) = 3)) ORDER BY SupplierTransaction.SupplierTransaction_DayEndID, SupplierTransaction.SupplierTransactionID;", ref cn);
				if (rsSupplier.RecordCount == 0) {
					Report.ReportDefinition.Sections("Section8").SectionFormat.EnableSuppress = true;
				} else {
					Report.ReportDefinition.Sections("Section8").SectionFormat.EnableSuppress = false;
					Report.OpenSubreport("Subreport5").Database.Tables(1).SetDataSource(rsSupplier);
				}
			} else {
				Report.ReportDefinition.Sections("Section8").SectionFormat.EnableSuppress = true;
			}

			if (gParameters & gParCustomer) {
				rsCustomer = modRecordSet.getRSwaitron(ref "SELECT Customer.Customer_InvoiceName, TransactionType.TransactionType_Name, CustomerTransaction.CustomerTransaction_Reference, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_Description, TransactionType.TransactionTypeID FROM (CustomerTransaction INNER JOIN Customer ON CustomerTransaction.CustomerTransaction_CustomerID = Customer.CustomerID) INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID Where (((CustomerTransaction.CustomerTransaction_DayEndID) = " + id + ")) ORDER BY Customer.Customer_InvoiceName, CustomerTransaction.CustomerTransaction_Date;", ref cn);
				if (rsCustomer.RecordCount == 0) {
					Report.ReportDefinition.Sections("Section9").SectionFormat.EnableSuppress = true;
				} else {
					Report.ReportDefinition.Sections("Section9").SectionFormat.EnableSuppress = false;
					Report.OpenSubreport("Subreport6").Database.Tables(1).SetDataSource(rsCustomer);
				}
			} else {
				Report.ReportDefinition.Sections("Section9").SectionFormat.EnableSuppress = true;
			}

			//    If gParameters And gParQuote Then
			//        Set rsQuote = getRS("SELECT Quote.* From Quote Where (((Quote.Quote_DayEndID) = " & id & ")) ORDER BY Quote.Quote_Name;")
			//        If rsQuote.RecordCount = 0 Then
			//            Report.Section10.Suppress = True
			//        Else
			//            Report.Section10.Suppress = False
			//            Report.Subreport7.OpenSubreport.Database.Tables(1).SetDataSource rsQuote, 3
			//        End If
			//    Else
			//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section10. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Report.ReportDefinition.Sections("Section10").SectionFormat.EnableSuppress = true;
			//    End If

			if (gParameters & gParQuote) {
				rsConsignment = modRecordSet.getRSwaitron(ref "SELECT Consignment.*, Sale.Sale_Total AS saleAmount,0 as completeAmount,0 as returnAmount FROM Consignment INNER JOIN Sale ON Consignment.Consignment_SaleID = Sale.SaleID Where (((Consignment.Consignment_DayEndID) = " + id + ")) Union SELECT Consignment.*, 0 AS saleAmount, [saleComplete]![Sale_Total] AS completeAmount, [SaleReturned]![Sale_Total]+[saleComplete]![Sale_Total] AS returnAmount FROM (Consignment INNER JOIN Sale AS SaleReturned ON Consignment.Consignment_ReversalSaleID = SaleReturned.SaleID) INNER JOIN Sale AS saleComplete ON Consignment.Consignment_CompleteSaleID = saleComplete.SaleID WHERE (((Consignment.Consignment_DayEndID)=" + id + "));", ref cn);
				if (rsConsignment.RecordCount == 0) {
					Report.ReportDefinition.Sections("Section11").SectionFormat.EnableSuppress = true;
				} else {
					Report.ReportDefinition.Sections("Section11").SectionFormat.EnableSuppress = false;
					Report.OpenSubreport("Subreport8").Database.Tables(1).SetDataSource(rsConsignment);
				}
			} else {
				Report.ReportDefinition.Sections("Section11").SectionFormat.EnableSuppress = true;
			}

			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();

		}

		public static void loadDayEndReport(ref int id, ref string sPath = "", ref bool bFAIL = false)
		{
			int lTotal = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsBanking = default(ADODB.Recordset);
			ADODB.Recordset rsPayout = default(ADODB.Recordset);
			ADODB.Recordset rsSupplier = default(ADODB.Recordset);
			ADODB.Recordset rsShrink = default(ADODB.Recordset);
			ADODB.Recordset rsCustomer = default(ADODB.Recordset);
			ADODB.Recordset rsQuote = default(ADODB.Recordset);
			ADODB.Recordset rsConsignment = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryDayEnd
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			int gParameters = 0;
			const short gParChannel = 1;
			const short gParStock = 2;
			const short gParShrink = 4;
			const short gParSupplier = 8;
			const short gParCustomer = 16;
			const short gParQuote = 32;
			const short gParConsignment = 64;
			const short gParPastelReport = 128;
			//Pastel Variable

			Report.Load("cryDatEnd");
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtCompanyName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			gParameters = Convert.ToInt32(0 + rs.Fields("Company_DayEndBit").Value);
			rs.Close();

			//change translation for report
			//
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1974;
			//UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport1_Text9. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modRecordSet.rsLang.RecordCount)
				Report.SetParameterValue("Subreport1_Text9", Strings.Replace(modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value, Constants.vbCrLf, " "));
			//
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1975;
			//UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport1_Text8. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modRecordSet.rsLang.RecordCount)
				Report.SetParameterValue("Subreport1_Text8", Strings.Replace(modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value, Constants.vbCrLf, " "));
			//
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1974;
			//UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport2_Text4. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modRecordSet.rsLang.RecordCount)
				Report.SetParameterValue("Subreport2_Text4", Strings.Replace(modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value, Constants.vbCrLf, " "));
			//
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1975;
			//UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport2_Text3. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modRecordSet.rsLang.RecordCount)
				Report.SetParameterValue("Subreport2_Text3", Strings.Replace(modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value, Constants.vbCrLf, " "));
			//
			//change translation for report

			rs = modRecordSet.getRS(ref "SELECT * FROM DayEnd WHERE DayEndID = " + id);
			//UPGRADE_ISSUE: cryNoRecords object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords");
			//'ReportNone.Load("cryNoRecords.rpt")
			if (rs.BOF | rs.EOF) {
				if (Module1.bUploadReport == true) {
					bFAIL = true;
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtCompanyName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object ReportNone.txtCompanyName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName"));
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object ReportNone.txtTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle"));
					//UPGRADE_WARNING: Couldn't resolve default property of object ReportNone.txtTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
					//UPGRADE_WARNING: Couldn't resolve default property of object frmReportShow.CRViewer1.ReportSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object ReportNone. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
					My.MyProject.Forms.frmReportShow.mReport = ReportNone;
					My.MyProject.Forms.frmReportShow.sMode = "0";
					My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
					//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
					My.MyProject.Forms.frmReportShow.ShowDialog();
				}
				return;
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object Report.Database. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'

			Report.Database.Tables(1).SetDataSource(rs);
			if (My.MyProject.Forms.frmMenu.gSuper == true) {
				sql = "SELECT POS.POSID, POS.POS_Name, Sum(Declaration.Declaration_Cash) AS SumOfDeclaration_Cash, Sum(Declaration.Declaration_CashServer) AS SumOfDeclaration_CashServer, Sum(Declaration.Declaration_CashCount) AS SumOfDeclaration_CashCount, Sum(Declaration.Declaration_Cheque) AS SumOfDeclaration_Cheque, Sum(Declaration.Declaration_ChequeServer) AS SumOfDeclaration_ChequeServer, Sum(Declaration.Declaration_ChequeCount) AS SumOfDeclaration_ChequeCount, Sum(Declaration.Declaration_Card) AS SumOfDeclaration_Card, Sum(Declaration.Declaration_CardServer) AS SumOfDeclaration_CardServer, Sum(Declaration.Declaration_CardCount) AS SumOfDeclaration_CardCount, Sum(Declaration.Declaration_Payout) AS SumOfDeclaration_Payout, Sum(Declaration.Declaration_PayoutServer) AS SumOfDeclaration_PayoutServer, Sum(Declaration.Declaration_PayoutCount) AS SumOfDeclaration_PayoutCount FROM Declaration INNER JOIN POS ON Declaration.Declaration_POSID = POS.POSID Where (((Declaration.Declaration_DayEndID) = " + id + ")) ";
				sql = sql + "GROUP BY POS.POSID, POS.POS_Name;";
			} else {
				sql = "SELECT POS.POSID, POS.POS_Name, Sum(IIf(IIf(IsNull(Declaration.Declaration_CashDrop),0,Declaration.Declaration_CashDrop)=0,Declaration.Declaration_Cash,Declaration.Declaration_CashDrop)) AS SumOfDeclaration_Cash, Sum(IIf(IIf(IsNull(Declaration.Declaration_CashServerDrop),0,Declaration.Declaration_CashServerDrop)=0,Declaration.Declaration_CashServer,Declaration.Declaration_CashServerDrop)) AS SumOfDeclaration_CashServer, Sum(IIf(IIf(IsNull(Declaration.Declaration_CashCountDrop),0,Declaration.Declaration_CashCountDrop)=0,Declaration.Declaration_CashCount,Declaration.Declaration_CashCountDrop)) AS SumOfDeclaration_CashCount, ";
				sql = sql + "Sum(Declaration.Declaration_Cheque) AS SumOfDeclaration_Cheque, Sum(Declaration.Declaration_ChequeServer) AS SumOfDeclaration_ChequeServer, Sum(Declaration.Declaration_ChequeCount) AS SumOfDeclaration_ChequeCount, Sum(Declaration.Declaration_Card) AS SumOfDeclaration_Card, Sum(Declaration.Declaration_CardServer) AS SumOfDeclaration_CardServer, Sum(Declaration.Declaration_CardCount) AS SumOfDeclaration_CardCount, Sum(Declaration.Declaration_Payout) AS SumOfDeclaration_Payout, Sum(Declaration.Declaration_PayoutServer) AS SumOfDeclaration_PayoutServer, Sum(Declaration.Declaration_PayoutCount) AS SumOfDeclaration_PayoutCount FROM Declaration INNER JOIN POS ON Declaration.Declaration_POSID = POS.POSID Where (((Declaration.Declaration_DayEndID) = " + id + ")) ";
				sql = sql + "GROUP BY POS.POSID, POS.POS_Name;";
			}
			Debug.Print(sql);
			rsBanking = modRecordSet.getRS(ref sql);

			rsPayout = modRecordSet.getRS(ref "select * from Payout WHERE Payout_DayEndID = " + id);

			if (rsBanking.RecordCount == 0) {
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.ReportDefinition.Sections("Section2").SectionFormat.EnableSuppress = true;
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section3. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.ReportDefinition.Sections("Section3").SectionFormat.EnableSuppress = true;
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.ReportDefinition.Sections("Section2").SectionFormat.EnableSuppress = false;
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section3. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.ReportDefinition.Sections("Section3").SectionFormat.EnableSuppress = false;
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.OpenSubreport("Subreport1").Database.Tables(1).SetDataSource(rsBanking);
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.OpenSubreport("Subreport2").Database.Tables(1).SetDataSource(rsBanking);
			}
			if (rsPayout.RecordCount == 0) {
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section4. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.ReportDefinition.Sections("Section4").SectionFormat.EnableSuppress = true;
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section4. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.ReportDefinition.Sections("Section4").SectionFormat.EnableSuppress = false;
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport3. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.OpenSubreport("Subreport3").Database.Tables(1).SetDataSource(rsPayout);
			}

			//************************************
			//*** Sales Channels
			//************************************

			if (gParameters & gParChannel) {
				rs = modRecordSet.getRS(ref "SELECT * FROM Channel");

				while (!(rs.EOF)) {
					switch (rs.Fields("ChannelID").Value) {
						case 1:
							//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSC1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Report.SetParameterValue("txtSC1", rs.Fields("Channel_Code"));
							break;
						case 2:
							//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSC2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Report.SetParameterValue("txtSC2", rs.Fields("Channel_Code"));
							break;
						case 3:
							//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSC3. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Report.SetParameterValue("txtSC3", rs.Fields("Channel_Code"));
							break;
						case 4:
							//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSC4. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Report.SetParameterValue("txtSC4", rs.Fields("Channel_Code"));
							break;
						case 5:
							//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSC5. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Report.SetParameterValue("txtSC5", rs.Fields("Channel_Code"));
							break;
						case 6:
							//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSC6. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Report.SetParameterValue("txtSC6", rs.Fields("Channel_Code"));
							break;
						case 7:
							//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSC7. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Report.SetParameterValue("txtSC7", rs.Fields("Channel_Code"));
							break;
						case 8:
							//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSC8. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Report.SetParameterValue("txtSC8", rs.Fields("Channel_Code"));
							break;
						case 9:
							//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSC9. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Report.SetParameterValue("txtSC9", rs.Fields("Channel_Code"));
							break;
					}
					rs.moveNext();
				}
				rs.Close();

				rs = modRecordSet.getRS(ref "SELECT Sum(Sale.Sale_Discount) AS amount FROM Consignment RIGHT JOIN (Consignment AS Consignment_1 RIGHT JOIN Sale ON Consignment_1.Consignment_SaleID = Sale.SaleID) ON Consignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((Consignment.ConsignmentID) Is Null) AND ((Consignment_1.ConsignmentID) Is Null) AND ((Sale.Sale_PaymentType)<>5));");
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (Information.IsDBNull(rs.Fields("amount").Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSCmDiscount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.SetParameterValue("txtSCmDiscount", "0.00");
				} else {
					if (rs.RecordCount) {
						//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSCmDiscount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Report.SetParameterValue("txtSCmDiscount", Strings.FormatNumber(0 - rs.Fields("amount").Value, 2));
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSCmDiscount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Report.SetParameterValue("txtSCmDiscount", "0.00");
					}
				}
				rs.Close();

				rs = modRecordSet.getRS(ref "SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS SCTotal, Sale.Sale_ChannelID FROM Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = False) And ((Consignment.ConsignmentID) Is Null) And ((Consignment_1.ConsignmentID) Is Null) And ((Sale.Sale_DayEndID) = " + id + ")) GROUP BY Sale.Sale_ChannelID;");
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSCmDiscount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object lTotal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lTotal = Convert.ToDecimal(Report.ParameterFields("txtSCmDiscount").ToString);
				while (!(rs.EOF)) {
					switch (rs.Fields("Sale_ChannelID").Value) {
						case 1:
							//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSCm1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Report.SetParameterValue("txtSCm1", Strings.FormatNumber(rs.Fields("SCTotal").Value, 2));
							break;
						case 2:
							//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSCm2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Report.SetParameterValue("txtSCm2", Strings.FormatNumber(rs.Fields("SCTotal").Value, 2));
							break;
						case 3:
							//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSCm3. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Report.SetParameterValue("txtSCm3", Strings.FormatNumber(rs.Fields("SCTotal").Value, 2));
							break;
						case 4:
							//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSCm4. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Report.SetParameterValue("txtSCm4", Strings.FormatNumber(rs.Fields("SCTotal").Value, 2));
							break;
						case 5:
							//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSCm5. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Report.SetParameterValue("txtSCm5", Strings.FormatNumber(rs.Fields("SCTotal").Value, 2));
							break;
						case 6:
							//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSCm6. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Report.SetParameterValue("txtSCm6", Strings.FormatNumber(rs.Fields("SCTotal").Value, 2));
							break;
						case 7:
							//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSCm7. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Report.SetParameterValue("txtSCm7", Strings.FormatNumber(rs.Fields("SCTotal").Value, 2));
							break;
						case 8:
							//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSCm8. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Report.SetParameterValue("txtSCm8", Strings.FormatNumber(rs.Fields("SCTotal").Value, 2));
							break;
						case 9:
							//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSCm9. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Report.SetParameterValue("txtSCm9", Strings.FormatNumber(rs.Fields("SCTotal").Value, 2));
							break;
					}
					//UPGRADE_WARNING: Couldn't resolve default property of object lTotal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lTotal = lTotal + rs.Fields("SCTotal").Value;
					rs.moveNext();
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object lTotal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSCmTotal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.SetParameterValue("txtSCmTotal", Strings.FormatNumber(lTotal, 2));
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section5. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.ReportDefinition.Sections("Section5").SectionFormat.EnableSuppress = true;
			}

			if (gParameters & gParStock) {
				//*******************************************
				//***Stock Movement
				//*******************************************
				rs = modRecordSet.getRS(ref "SELECT Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost]) AS listSales, Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ActualCost]) AS actualSales, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS listShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actualShrink, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost]) AS listGRV, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ActualCost]) AS actualGRV From DayEndStockItemLnk WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)=" + id + "));");

				//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHRL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.SetParameterValue("txtSHRL", Strings.FormatNumber(rs.Fields("listShrink").Value, 2));
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHRA. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.SetParameterValue("txtSHRA", Strings.FormatNumber(rs.Fields("actualShrink").Value, 2));
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtGRVL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.SetParameterValue("txtGRVL", Strings.FormatNumber(rs.Fields("listGRV").Value, 2));

				//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtGRVA. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.SetParameterValue("txtGRVA", Strings.FormatNumber(rs.Fields("actualGRV").Value, 2));
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSaleL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.SetParameterValue("txtSaleL", Strings.FormatNumber(rs.Fields("listSales").Value, 2));
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSaleA. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.SetParameterValue("txtSaleA", Strings.FormatNumber(rs.Fields("actualSales").Value, 2));

				rs = modRecordSet.getRS(ref "SELECT Sum(([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ListCost]) AS list, Sum(([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_actualCost]) AS actual From DayEndStockItemLnk WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)=" + id + "));");
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHLclose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.SetParameterValue("txtSHLclose", Strings.FormatNumber(rs.Fields("list").Value, 2));
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHAclose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.SetParameterValue("txtSHAclose", Strings.FormatNumber(rs.Fields("actual").Value, 2));

				rs = modRecordSet.getRS(ref "SELECT Sum([DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk_ListCost]) AS list, Sum([DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk_actualCost]) AS actual From DayEndStockItemLnk WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)=" + id + "));");
				if (rs.RecordCount) {
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHLopen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.SetParameterValue("txtSHLopen", Strings.FormatNumber(rs.Fields("list").Value, 2));
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHAopen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.SetParameterValue("txtSHAopen", Strings.FormatNumber(rs.Fields("actual").Value, 2));
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHLopen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.SetParameterValue("txtSHLopen", Strings.FormatNumber(0, 2));
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHAopen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.SetParameterValue("txtSHAopen", Strings.FormatNumber(0, 2));
				}

				rs = modRecordSet.getRS(ref "SELECT Sum(([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ListCost]) AS list, Sum(([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_actualCost]) AS actual From DayEndStockItemLnk WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)=" + id - 1 + "));");
				if (rs.RecordCount) {
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHLPrevclose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.SetParameterValue("txtSHLPrevclose", Strings.FormatNumber(rs.Fields("list").Value, 2));
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHAPrevclose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.SetParameterValue("txtSHAPrevclose", Strings.FormatNumber(rs.Fields("actual").Value, 2));
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHLPrevclose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.SetParameterValue("txtSHLPrevclose", Strings.FormatNumber(0, 2));
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHAPrevclose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.SetParameterValue("txtSHAPrevclose", Strings.FormatNumber(0, 2));
				}
				if (string.IsNullOrEmpty(Report.ParameterFields("txtSHLPrevclose").ToString))
					Report.SetParameterValue("txtSHLPrevclose", Report.ParameterFields("txtSHLopen").ToString);

				if (string.IsNullOrEmpty(Report.ParameterFields("txtSHAPrevclose").ToString))
					Report.SetParameterValue("txtSHAPrevclose", Report.ParameterFields("txtSHAopen").ToString);
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHLopen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (string.IsNullOrEmpty(Report.ParameterFields("txtSHLopen").ToString)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHLPrevclose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (string.IsNullOrEmpty(Report.ParameterFields("txtSHLPrevclose").ToString)) {
						//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSVarianceL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Report.SetParameterValue("txtSVarianceL", Strings.FormatNumber(0, 2));
					} else {
						Report.SetParameterValue("txtSVarianceL", Strings.FormatNumber(0 - Convert.ToDecimal(Report.ParameterFields("txtSHLPrevclose").ToString), 2));
					}
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHLPrevclose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (string.IsNullOrEmpty(Report.ParameterFields("txtSHLPrevclose").ToString)) {
						Report.SetParameterValue("txtSVarianceL", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtSHLopen").ToString), 2));
					} else {
						Report.SetParameterValue("txtSVarianceL", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtSHLopen").ToString), 2 - Convert.ToDecimal(Report.ParameterFields("txtSHLPrevclose").ToString), 2));
					}
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHAopen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (string.IsNullOrEmpty(Report.ParameterFields("txtSHAopen").ToString)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHAPrevclose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (string.IsNullOrEmpty(Report.ParameterFields("txtSHAPrevclose").ToString)) {
						//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSVarianceL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Report.SetParameterValue("txtSVarianceL", Strings.FormatNumber(0, 2));
					} else {
						Report.SetParameterValue("txtSVarianceL", Strings.FormatNumber(0 - Convert.ToDecimal(Report.ParameterFields("txtSHAPrevclose").ToString), 2));
					}
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHAPrevclose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (string.IsNullOrEmpty(Report.ParameterFields("txtSHAPrevclose").ToString)) {
						Report.SetParameterValue("txtSVarianceL", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtSHAopen").ToString), 2));
					} else {
						Report.SetParameterValue("txtSVarianceL", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtSHAopen").ToString), 2 - Convert.ToDecimal(Report.ParameterFields("txtSHAPrevclose").ToString), 2));
					}
				}

			} else {
				Report.ReportDefinition.Sections("Section6").SectionFormat.EnableSuppress = true;
			}

			if (gParameters & gParShrink) {
				rsShrink = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS list, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actual FROM DayEndStockItemLnk INNER JOIN StockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = StockItem.StockItemID Where (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0) And ((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) = " + id + ")) GROUP BY StockItem.StockItem_Name ORDER BY StockItem.StockItem_Name;");

				if (rsShrink.RecordCount == 0) {
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section7. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.ReportDefinition.Sections("Section7").SectionFormat.EnableSuppress = true;
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section7. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.ReportDefinition.Sections("Section7").SectionFormat.EnableSuppress = false;
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport4. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.OpenSubreport("Subreport4").Database.Tables(1).SetDataSource(rsShrink);
				}
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section7. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.ReportDefinition.Sections("Section7").SectionFormat.EnableSuppress = true;
			}

			if (gParameters & gParSupplier) {
				rsSupplier = modRecordSet.getRS(ref "SELECT Supplier.Supplier_Name, SupplierTransaction.* FROM SupplierTransaction INNER JOIN Supplier ON SupplierTransaction.SupplierTransaction_SupplierID = Supplier.SupplierID Where (((SupplierTransaction.SupplierTransaction_DayEndID) = " + id + ") And ((SupplierTransaction.SupplierTransaction_TransactionTypeID) = 2 Or (SupplierTransaction.SupplierTransaction_TransactionTypeID) = 3)) ORDER BY SupplierTransaction.SupplierTransaction_DayEndID, SupplierTransaction.SupplierTransactionID;");
				if (rsSupplier.RecordCount == 0) {
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section8. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.ReportDefinition.Sections("Section8").SectionFormat.EnableSuppress = true;
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section8. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.ReportDefinition.Sections("Section8").SectionFormat.EnableSuppress = false;
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport5. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.OpenSubreport("Subreport5").Database.Tables(1).SetDataSource(rsSupplier);
				}
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section8. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.ReportDefinition.Sections("Section8").SectionFormat.EnableSuppress = true;
			}

			if (gParameters & gParCustomer) {
				rsCustomer = modRecordSet.getRS(ref "SELECT Customer.Customer_InvoiceName, TransactionType.TransactionType_Name, CustomerTransaction.CustomerTransaction_Reference, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_Description, TransactionType.TransactionTypeID FROM (CustomerTransaction INNER JOIN Customer ON CustomerTransaction.CustomerTransaction_CustomerID = Customer.CustomerID) INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID Where (((CustomerTransaction.CustomerTransaction_DayEndID) = " + id + ")) ORDER BY Customer.Customer_InvoiceName, CustomerTransaction.CustomerTransaction_Date;");
				if (rsCustomer.RecordCount == 0) {
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section9. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.ReportDefinition.Sections("Section9").SectionFormat.EnableSuppress = true;
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section9. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.ReportDefinition.Sections("Section9").SectionFormat.EnableSuppress = false;
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport6. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.OpenSubreport("Subreport6").Database.Tables(1).SetDataSource(rsCustomer);
				}
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section9. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.ReportDefinition.Sections("Section9").SectionFormat.EnableSuppress = true;
			}

			if (gParameters & gParQuote) {
				rsQuote = modRecordSet.getRS(ref "SELECT Quote.* From Quote Where (((Quote.Quote_DayEndID) = " + id + ")) ORDER BY Quote.Quote_Name;");
				if (rsQuote.RecordCount == 0) {
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section10. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.ReportDefinition.Sections("Section10").SectionFormat.EnableSuppress = true;
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section10. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.ReportDefinition.Sections("Section10").SectionFormat.EnableSuppress = false;
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport7. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.OpenSubreport("Subreport7").Database.Tables(1).SetDataSource(rsQuote);
				}
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section10. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.ReportDefinition.Sections("Section10").SectionFormat.EnableSuppress = true;
			}

			if (gParameters & gParQuote) {
				rsConsignment = modRecordSet.getRS(ref "SELECT Consignment.*, Sale.Sale_Total AS saleAmount,0 as completeAmount,0 as returnAmount FROM Consignment INNER JOIN Sale ON Consignment.Consignment_SaleID = Sale.SaleID Where (((Consignment.Consignment_DayEndID) = " + id + ")) Union SELECT Consignment.*, 0 AS saleAmount, [saleComplete]![Sale_Total] AS completeAmount, [SaleReturned]![Sale_Total]+[saleComplete]![Sale_Total] AS returnAmount FROM (Consignment INNER JOIN Sale AS SaleReturned ON Consignment.Consignment_ReversalSaleID = SaleReturned.SaleID) INNER JOIN Sale AS saleComplete ON Consignment.Consignment_CompleteSaleID = saleComplete.SaleID WHERE (((Consignment.Consignment_DayEndID)=" + id + "));");
				if (rsConsignment.RecordCount == 0) {
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section11. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.ReportDefinition.Sections("Section11").SectionFormat.EnableSuppress = true;
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section11. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.ReportDefinition.Sections("Section11").SectionFormat.EnableSuppress = false;
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport8. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.OpenSubreport("Subreport8").Database.Tables(1).SetDataSource(rsConsignment);
				}
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section11. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.ReportDefinition.Sections("Section11").SectionFormat.EnableSuppress = true;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object Report.VerifyOnEveryPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//'Report.VerifyOnEveryPrint = True
			if (Module1.bUploadReport == true) {
				Report.FileName = sPath;
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.ExportOptions. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.RPTR, sPath);
				//Report.ExportOptions.DiskFileName = sPath
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.ExportOptions. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.HTML40, sPath);
				//Report.ExportOptions.HTMLFileName = sPath
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.ExportOptions. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//Report.ExportOptions.DestinationType = CRAXDRT.CRExportDestinationType.crEDTDiskFile
				//Report.ExportOptions.DestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.ExportOptions. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//Report.ExportOptions.FormatType = CRAXDRT.CRExportFormatType.crEFTExplorer32Extend
				//Report.ExportOptions.FormatType = CrystalDecisions.Shared.ExportFormatType.HTML40
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Export. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//Report.Export(False)
				//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
				My.MyProject.Forms.frmReportShow.mReport = Report;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
			}
		}

		public static void report_PurchaseOrder(ref int id)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsItems = default(ADODB.Recordset);
			string sql = null;
			//UPGRADE_ISSUE: cryPurchaseOrder object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
			//Dim Report As New cryPurchaseOrder
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryPurchaseOrder");
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT Supplier.*, PurchaseOrder.*, PurchaseOrderStatus.PurchaseOrderStatus_Name, PurchaseOrderStatus.PurchaseOrderStatus_Complete, Company.* FROM Company, (PurchaseOrder INNER JOIN Supplier ON PurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN PurchaseOrderStatus ON PurchaseOrder.PurchaseOrder_PurchaseOrderStatusID = PurchaseOrderStatus.PurchaseOrderStatusID WHERE (((PurchaseOrder.PurchaseOrderID)=" + id + "));");
			//UPGRADE_WARNING: Couldn't resolve default property of object Report.Database. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Report.Database.Tables(1).SetDataSource(rs);
			rsItems = modRecordSet.getRS(ref "SELECT PurchaseOrderItem.*, StockItem.* FROM PurchaseOrderItem INNER JOIN StockItem ON PurchaseOrderItem.PurchaseOrderItem_StockItemID = StockItem.StockItemID WHERE (((PurchaseOrderItem.PurchaseOrderItem_PurchaseOrderID)=" + id + ") AND ((PurchaseOrderItem.PurchaseOrderItem_Quantity)<>0));");
			//UPGRADE_WARNING: Couldn't resolve default property of object Report.Database. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Report.Database.Tables(2).SetDataSource(rsItems);

			//UPGRADE_WARNING: Couldn't resolve default property of object Report.VerifyOnEveryPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//'Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = "Purchase Order";
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();

		}

		public static void report_GRV(ref int id)
		{
			string rsItem1SQL = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsPurch = default(ADODB.Recordset);
			ADODB.Recordset rsCredit = default(ADODB.Recordset);
			ADODB.Recordset rsPurchDeposit = default(ADODB.Recordset);
			ADODB.Recordset rsCreditDeposit = default(ADODB.Recordset);
			ADODB.Recordset rsItem0 = default(ADODB.Recordset);
			ADODB.Recordset rsItem1 = default(ADODB.Recordset);
			ADODB.Recordset rsDeposit0 = default(ADODB.Recordset);
			ADODB.Recordset rsDeposit1 = default(ADODB.Recordset);

			ADODB.Recordset rsData = default(ADODB.Recordset);
			string sql = null;
			//UPGRADE_ISSUE: cry object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
			//Dim Report As New cry
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryGRV");
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rsData = modRecordSet.getRS(ref "SELECT GRV.*, [GRV_ContentExclusive]*([GRV_Ullage]/100) AS Ullage, PurchaseOrder.*, Supplier.*, Company.*, GRV.GRVID, Person.Person_FirstName & ' ' & Person.Person_LastName AS Name FROM Company, (GRV INNER JOIN (PurchaseOrder INNER JOIN Supplier ON PurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) ON GRV.GRV_PurchaseOrderID = PurchaseOrder.PurchaseOrderID) INNER JOIN Person ON GRV.GRV_PersonID = Person.PersonID WHERE (((GRV.GRVID)=" + id + "));");
			if (rsData.RecordCount) {
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Database. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.Database.Tables(1).SetDataSource(rsData);
			} else {
				rsData = modRecordSet.getRS(ref "SELECT GRV.*, [GRV_ContentExclusive]*([GRV_Ullage]/100) AS Ullage, PurchaseOrder.*, Supplier.*, Company.*, GRV.GRVID, 'Logged In User' AS Name FROM Company, GRV INNER JOIN (PurchaseOrder INNER JOIN Supplier ON PurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) ON GRV.GRV_PurchaseOrderID = PurchaseOrder.PurchaseOrderID WHERE (((GRV.GRVID)=" + id + "));");
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Database. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.Database.Tables(1).SetDataSource(rsData);
			}
			rsPurch = modRecordSet.getRS(ref "SELECT Sum(((([GRVItem_PackSize]/[StockItem_Quantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])) AS exclusive, Sum(((([GRVItem_PackSize]/[StockItem_Quantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100)) AS inclusive, Sum(([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100)) AS depositIncl FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE (((GRVItem.GRVItem_Quantity)<>0) AND ((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_GRVID)=" + id + "));");
			//UPGRADE_WARNING: Couldn't resolve default property of object Report.Database. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Report.Database.Tables(2).SetDataSource(rsPurch);
			rsCredit = modRecordSet.getRS(ref "SELECT Sum(((([GRVItem_PackSize]/[StockItem_Quantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])) AS exclusiveCredit, Sum(((([GRVItem_PackSize]/[StockItem_Quantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100)) AS inclusiveCredit, Sum(([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100)) AS depositInclCredit FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE (((GRVItem.GRVItem_Quantity)<>0) AND ((GRVItem.GRVItem_Return)<>0) AND ((GRVItem.GRVItem_GRVID)=" + id + "));");
			//UPGRADE_WARNING: Couldn't resolve default property of object Report.Database. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Report.Database.Tables(3).SetDataSource(rsCredit);
			rsPurchDeposit = modRecordSet.getRS(ref "SELECT Sum((IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,[GRVDeposit_Quantity]*([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]*(1+[GRVDeposit_VatRate]/100)),0))+(IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,[GRVDeposit_quantity]*([GRVDeposit_CaseCost]*(1+[GRVDeposit_VatRate]/100)),0))) AS inclusiveDepositReturn From GRVDeposit WHERE (((GRVDeposit.GRVDeposit_GRVID)=" + id + ") AND ((GRVDeposit.GRVDeposit_Return)=0));");
			//UPGRADE_WARNING: Couldn't resolve default property of object Report.Database. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Report.Database.Tables(4).SetDataSource(rsPurchDeposit);
			rsCreditDeposit = modRecordSet.getRS(ref "SELECT Sum((IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,[GRVDeposit_Quantity]*([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]*(1+[GRVDeposit_VatRate]/100)),0))+(IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,[GRVDeposit_quantity]*([GRVDeposit_CaseCost]*(1+[GRVDeposit_VatRate]/100)),0))) AS inclusiveDepositPurch From GRVDeposit WHERE (((GRVDeposit.GRVDeposit_GRVID)=" + id + ") AND ((GRVDeposit.GRVDeposit_Return)<>0));");
			//UPGRADE_WARNING: Couldn't resolve default property of object Report.Database. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Report.Database.Tables(5).SetDataSource(rsCreditDeposit);

			//'Set rsItem0 = getRS("SELECT StockItem.StockItem_Name AS GRVItem_Name, GRVItem.GRVItem_Code, GRVItem.GRVItem_PackSize, GRVItem.GRVItem_Quantity, GRVItem.GRVItem_ContentCost, GRVItem.GRVItem_DepositCost, GRVItem.GRVItem_DiscountAmount, GRVItem.GRVItem_VatRate, ([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS depositInclusive, ((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity] AS contentExclusive, (((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS contentInclusive, (([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost]) AS contentCost FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE (((GRVItem.GRVItem_Quantity)<>0) AND ((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_GRVID)=" & id & "));")
			//Set rsItem0 = getRS("SELECT StockItem.StockItem_Name AS GRVItem_Name, GRVItem.GRVItem_Code, GRVItem.GRVItem_PackSize, GRVItem.GRVItem_Quantity, GRVItem.GRVItem_ContentCost, GRVItem.GRVItem_DepositCost, GRVItem.GRVItem_DiscountAmount, GRVItem.GRVItem_VatRate, ([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS depositInclusive, ((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity] AS contentExclusive, (((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS contentInclusive, (([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost]) AS contentCost FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE (((GRVItem.GRVItem_Quantity)<>0) AND ((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_GRVID)=" & id & "));")
			// > Set rsItem0 = getRS("SELECT StockItem.StockItem_Name AS GRVItem_Name, GRVItem.GRVItem_Code, GRVItem.GRVItem_PackSize, GRVItem.GRVItem_Quantity, GRVItem.GRVItem_ContentCost, GRVItem.GRVItem_DepositCost, GRVItem.GRVItem_DiscountAmount, GRVItem.GRVItem_VatRate, ([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS depositInclusive, ([GRVItem_ContentCost]-[GRVItem_DiscountAmount])*[GRVItem_Quantity] AS contentExclusive, (([GRVItem_ContentCost]-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS contentInclusive, GRVItem.GRVItem_Quantity, PriceChannelLnk.PriceChannelLnk_Price, GRVItem.GRVItem_Price FROM (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) LEFT JOIN PriceChannelLnk ON GRVItem.GRVItem_StockItemID = PriceChannelLnk.PriceChannelLnk_StockItemID WHERE (((GRVItem.GRVItem_Quantity)<>0) AND ((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_GRVID)=" & id & "));")

			//commented lines to put    StockItem.StockItem_SupplierCode
			//rsItem1SQL = "SELECT GRVItem.GRVItem_Name, GRVItem.GRVItem_Code, GRVItem.GRVItem_PackSize, GRVItem.GRVItem_Quantity, GRVItem.GRVItem_ContentCost, GRVItem.GRVItem_DepositCost, GRVItem.GRVItem_DiscountAmount, GRVItem.GRVItem_VatRate, ([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS depositInclusive, ((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity] AS contentExclusive, (((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS contentInclusive, (([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost]) AS contentCost, " & _
			//'"GRVItem.GRVItem_Price FROM (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) WHERE (((GRVItem.GRVItem_Quantity)<>0) AND ((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_GRVID)=" & id & "));"
			//UPGRADE_WARNING: Couldn't resolve default property of object rsItem1SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			rsItem1SQL = "SELECT GRVItem.GRVItem_Name, StockItem.StockItem_SupplierCode, GRVItem.GRVItem_PackSize, GRVItem.GRVItem_Quantity, GRVItem.GRVItem_ContentCost, GRVItem.GRVItem_DepositCost, GRVItem.GRVItem_DiscountAmount, GRVItem.GRVItem_VatRate, ([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS depositInclusive, ((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity] AS contentExclusive, (((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS contentInclusive, (([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost]) AS contentCost, " + "GRVItem.GRVItem_Price FROM (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) WHERE (((GRVItem.GRVItem_Quantity)<>0) AND ((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_GRVID)=" + id + "));";
			//commented lines to put    StockItem.StockItem_SupplierCode

			//rsItem1SQL = "SELECT GRVItem.GRVItem_Name, GRVItem.GRVItem_Code, GRVItem.GRVItem_PackSize, GRVItem.GRVItem_Quantity, GRVItem.GRVItem_ContentCost, GRVItem.GRVItem_DepositCost, GRVItem.GRVItem_DiscountAmount, GRVItem.GRVItem_VatRate, ([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS depositInclusive, ((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity] AS contentExclusive, (((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS contentInclusive, (([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost]) AS contentCost, " & _
			//' "PriceChannelLnk.PriceChannelLnk_Price, GRVItem.GRVItem_Price FROM (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) LEFT JOIN PriceChannelLnk ON (GRVItem.GRVItem_StockItemID = PriceChannelLnk.PriceChannelLnk_StockItemID) AND (GRVItem.GRVItem_StockItemQuantity = PriceChannelLnk.PriceChannelLnk_Quantity) WHERE (((GRVItem.GRVItem_Quantity)<>0) AND ((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_GRVID)=" & id & "));"
			rsItem0 = modRecordSet.getRS(ref rsItem1SQL);
			if (rsItem0.RecordCount == 0) {
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.ReportDefinition.Sections("Section2").SectionFormat.EnableSuppress = true;
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.ReportDefinition.Sections("Section2").SectionFormat.EnableSuppress = false;
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.OpenSubreport("Subreport1").Database.Tables(1).SetDataSource(rsItem0);
			}

			rsDeposit0 = modRecordSet.getRS(ref "SELECT GRVDeposit.*, IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,([GRVDeposit_CaseCost]),0)+IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]),0) AS exclusive, IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,([GRVDeposit_CaseCost]*(1+[GRVDeposit_VatRate]/100)),0)+IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]*(1+[GRVDeposit_VatRate]/100)),0) AS inclusive From GRVDeposit WHERE (((GRVDeposit.GRVDeposit_GRVID)=" + id + ") AND ((GRVDeposit.GRVDeposit_Return)<>0));");
			//
			if (rsDeposit0.RecordCount == 0) {
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section3. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.ReportDefinition.Sections("Section3").SectionFormat.EnableSuppress = true;
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section3. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.ReportDefinition.Sections("Section3").SectionFormat.EnableSuppress = false;
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.OpenSubreport("Subreport2").Database.Tables(1).SetDataSource(rsDeposit0);
			}

			//Set rsItem1 = getRS("SELECT GRVItem.GRVItem_Name, GRVItem.GRVItem_Code, GRVItem.GRVItem_PackSize, GRVItem.GRVItem_Quantity, GRVItem.GRVItem_ContentCost, GRVItem.GRVItem_DepositCost, GRVItem.GRVItem_DiscountAmount, GRVItem.GRVItem_VatRate, ([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS depositInclusive, ((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity] AS contentExclusive, (((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS contentInclusive, (([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost]) AS contentCost FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE (((GRVItem.GRVItem_Quantity)<>0) AND ((GRVItem.GRVItem_Return)<>0) AND ((GRVItem.GRVItem_GRVID)=" & id & "));")

			//commented lines to put    StockItem.StockItem_SupplierCode
			//rsItem1SQL = "SELECT GRVItem.GRVItem_Name, GRVItem.GRVItem_Code, GRVItem.GRVItem_PackSize, GRVItem.GRVItem_Quantity, GRVItem.GRVItem_ContentCost, GRVItem.GRVItem_DepositCost, GRVItem.GRVItem_DiscountAmount, GRVItem.GRVItem_VatRate, ([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS depositInclusive, ((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity] AS contentExclusive, (((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS contentInclusive, (([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost]) AS contentCost, " & _
			//'"GRVItem.GRVItem_Price FROM (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) WHERE (((GRVItem.GRVItem_Quantity)<>0) AND ((GRVItem.GRVItem_Return)<>0) AND ((GRVItem.GRVItem_GRVID)=" & id & "));"
			//UPGRADE_WARNING: Couldn't resolve default property of object rsItem1SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			rsItem1SQL = "SELECT GRVItem.GRVItem_Name, StockItem.StockItem_SupplierCode, GRVItem.GRVItem_PackSize, GRVItem.GRVItem_Quantity, GRVItem.GRVItem_ContentCost, GRVItem.GRVItem_DepositCost, GRVItem.GRVItem_DiscountAmount, GRVItem.GRVItem_VatRate, ([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS depositInclusive, ((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity] AS contentExclusive, (((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS contentInclusive, (([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost]) AS contentCost, " + "GRVItem.GRVItem_Price FROM (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) WHERE (((GRVItem.GRVItem_Quantity)<>0) AND ((GRVItem.GRVItem_Return)<>0) AND ((GRVItem.GRVItem_GRVID)=" + id + "));";
			//commented lines to put    StockItem.StockItem_SupplierCode

			//rsItem1SQL = "SELECT GRVItem.GRVItem_Name, GRVItem.GRVItem_Code, GRVItem.GRVItem_PackSize, GRVItem.GRVItem_Quantity, GRVItem.GRVItem_ContentCost, GRVItem.GRVItem_DepositCost, GRVItem.GRVItem_DiscountAmount, GRVItem.GRVItem_VatRate, ([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS depositInclusive, ((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity] AS contentExclusive, (((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS contentInclusive, (([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost]) AS contentCost, " & _
			//'"PriceChannelLnk.PriceChannelLnk_Price, GRVItem.GRVItem_Price FROM (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) LEFT JOIN PriceChannelLnk ON (GRVItem.GRVItem_StockItemID = PriceChannelLnk.PriceChannelLnk_StockItemID) AND (GRVItem.GRVItem_StockItemQuantity = PriceChannelLnk.PriceChannelLnk_Quantity) WHERE (((GRVItem.GRVItem_Quantity)<>0) AND ((GRVItem.GRVItem_Return)<>0) AND ((GRVItem.GRVItem_GRVID)=" & id & "));"
			rsItem1 = modRecordSet.getRS(ref rsItem1SQL);
			if (rsItem1.RecordCount == 0) {
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section4. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.ReportDefinition.Sections("Section4").SectionFormat.EnableSuppress = true;
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section4. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.ReportDefinition.Sections("Section4").SectionFormat.EnableSuppress = false;
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport3. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.OpenSubreport("Subreport3").Database.Tables(1).SetDataSource(rsItem1);
			}

			rsDeposit1 = modRecordSet.getRS(ref "SELECT GRVDeposit.*, IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,([GRVDeposit_CaseCost]),0)+IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]),0) AS exclusive, IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,([GRVDeposit_CaseCost]*(1+[GRVDeposit_VatRate]/100)),0)+IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]*(1+[GRVDeposit_VatRate]/100)),0) AS inclusive From GRVDeposit WHERE (((GRVDeposit.GRVDeposit_GRVID)=" + id + ") AND ((GRVDeposit.GRVDeposit_Return)=0));");
			//
			if (rsDeposit1.RecordCount == 0) {
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section5. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.ReportDefinition.Sections("Section5").SectionFormat.EnableSuppress = true;
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Section5. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.ReportDefinition.Sections("Section5").SectionFormat.EnableSuppress = false;
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport4. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.OpenSubreport("Subreport4").Database.Tables(1).SetDataSource(rsDeposit1);
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object Report.VerifyOnEveryPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//'Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = "Goods Receiving";
			//UPGRADE_WARNING: Couldn't resolve default property of object frmReportShow.CRViewer1.ReportSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object Report. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();

		}


		public static void report_CustomerStatement(ref int id)
		{
			ADODB.Recordset rsInterest = default(ADODB.Recordset);
			ADODB.Recordset rsTransaction = default(ADODB.Recordset);
			ADODB.Recordset rsCompany = default(ADODB.Recordset);
			string lNumber = null;
			string lAddress = null;
			ADODB.Recordset rs = new ADODB.Recordset();
			string sql = null;
			string Address = null;
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryCustomerStatement");
			//Dim Report As New cryCustomerStatement
			System.DateTime lDate = default(System.DateTime);

			short gMonth = 0;
			ADODB.Connection cnnDBStatement = new ADODB.Connection();
			var _with1 = cnnDBStatement;
			_with1.Provider = "MSDataShape";
			cnnDBStatement.Open("Data Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + modRecordSet.serverPath + "pricing.mdb" + ";User Id=liquid;Password=lqd;Jet OLEDB:System Database=" + modRecordSet.serverPath + "Secured.mdw");

			rs = modRecordSet.getRS(ref "SELECT Company_MonthendID FROM Company;");
			if (rs.Fields("Company_MonthendID").Value <= 1) {
				gMonth = 1;
			} else {
				gMonth = rs.Fields("Company_MonthendID").Value;
				//- 1
			}

			rs = modRecordSet.getRS(ref "SELECT MonthEnd.MonthEnd_Date From MonthEnd WHERE (((MonthEnd.MonthEndID)=" + gMonth + "));");
			//rs.Open "SELECT MonthEnd.MonthEnd_Date From MonthEnd WHERE (((MonthEnd.MonthEndID)=" & gMonth & "));", cnnDBStatement, adOpenStatic, adLockReadOnly, adCmdText
			if (Information.IsDBNull(rs.Fields("MonthEnd_Date").Value) == true | rs.RecordCount == 0) {
				gMonth = 1;
				rs = modRecordSet.getRS(ref "SELECT MonthEnd.MonthEnd_Date From MonthEnd WHERE (((MonthEnd.MonthEndID)=" + gMonth + "));");
			}

			Report.SetParameterValue("txtStatementDate", Strings.Format(DateAndTime.Today, "dd mmm yyyy"));
			if (rs.RecordCount) {
				//Report.txtStatementDate.SetText Format(rs("MonthEnd_Date"), "dd mmm yyyy")
				lDate = rs.Fields("MonthEnd_Date").Value;

			} else {
			}
			rs.Close();
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			lDate = System.Date.FromOADate(lDate.ToOADate() + 10);
			lDate = DateAndTime.DateSerial(DateAndTime.Year(lDate), DateAndTime.Month(lDate), 1);
			lDate = System.Date.FromOADate(lDate + rs.Fields("Company_PaymentDay").Value - 1);
			//Report.txtPaymentDate.SetText Format(lDate, "dd mmm yyyy")

			Address = Strings.Replace(rs.Fields("Company_PhysicalAddress").Value, Constants.vbCrLf, ", ");
			if (Strings.Right(lAddress, 2) == ", ") {
				lAddress = Strings.Left(lAddress, Strings.Len(lAddress) - 2);
			}
			Report.Database.Tables(1).SetDataSource(rs);
			Report.SetParameterValue("txtAddress", lAddress);
			lNumber = "";
			if (!string.IsNullOrEmpty(rs.Fields("Company_Telephone").Value))
				lNumber = lNumber + "Tel: " + rs.Fields("Company_Telephone").Value;
			if (!string.IsNullOrEmpty(rs.Fields("Company_Fax").Value)) {
				if (!string.IsNullOrEmpty(lNumber))
					lNumber = lNumber + " / ";
				lNumber = lNumber + "Fax: " + rs.Fields("Company_Fax").Value;
			}
			if (!string.IsNullOrEmpty(rs.Fields("Company_Email").Value)) {
				if (!string.IsNullOrEmpty(lNumber))
					lNumber = lNumber + " / ";
				lNumber = lNumber + "Email: " + rs.Fields("Company_Email").Value;
			}
			Report.SetParameterValue("txtNumbers", lNumber);

			//New banking details
			if (Information.IsDBNull(rs.Fields("Company_BankName").Value)) {
			} else {
				Report.SetParameterValue("txtBankName", rs.Fields("Company_BankName"));
			}

			if (Information.IsDBNull(rs.Fields("Company_BranchName").Value)) {
			} else {
				Report.SetParameterValue("txtBranchName", rs.Fields("Company_BranchName"));
			}

			if (Information.IsDBNull(rs.Fields("Company_BranchCode").Value)) {
			} else {
				Report.SetParameterValue("txtBranchCode", rs.Fields("Company_BranchCode"));
			}

			if (Information.IsDBNull(rs.Fields("Company_AccountNumber").Value)) {
			} else {
				Report.SetParameterValue("txtAccountNumber", rs.Fields("Company_AccountNumber"));
			}
			//...................

			rsCompany = new ADODB.Recordset();
			rsCompany.Open("SELECT * FROM Customer Where CustomerID = " + id, cnnDBStatement, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);
			Report.Database.Tables(2).SetDataSource(rsCompany);

			rsTransaction = new ADODB.Recordset();
			//changed for OPEN ITEM
			//rsTransaction.Open "SELECT CustomerTransaction.CustomerTransactionID, CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_Reference, CustomerTransaction.CustomerTransaction_PersonName," & _
			//'" TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" & id & "));", cnnDBStatement, adOpenStatic, adLockReadOnly, adCmdText
			rsTransaction.Open("SELECT CustomerTransaction.CustomerTransactionID, CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount-IIf(IsNull([CustomerTransaction.CustomerTransaction_Allocated]),0,[CustomerTransaction.CustomerTransaction_Allocated]), CustomerTransaction.CustomerTransaction_Reference & IIf([CustomerTransaction.CustomerTransaction_Allocated]<>[CustomerTransaction_Amount] AND [CustomerTransaction.CustomerTransaction_Allocated]<>0,'   (P)',Null), CustomerTransaction.CustomerTransaction_PersonName, TransactionType.TransactionType_Name," + " IIf(([CustomerTransaction_Amount]-IIf(IsNull([CustomerTransaction.CustomerTransaction_Allocated]),0,[CustomerTransaction.CustomerTransaction_Allocated]))>0,([CustomerTransaction_Amount]-IIf(IsNull([CustomerTransaction.CustomerTransaction_Allocated]),0,[CustomerTransaction.CustomerTransaction_Allocated])),Null) AS debit," + " IIf(([CustomerTransaction_Amount]-IIf(IsNull([CustomerTransaction.CustomerTransaction_Allocated]),0,[CustomerTransaction.CustomerTransaction_Allocated]))<0,([CustomerTransaction_Amount]-IIf(IsNull([CustomerTransaction.CustomerTransaction_Allocated]),0,[CustomerTransaction.CustomerTransaction_Allocated])),Null) AS credit, CustomerTransaction.CustomerTransaction_Main, CustomerTransaction.CustomerTransaction_Child, CustomerTransaction.CustomerTransaction_Allocated FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" + id + ") AND ((CustomerTransaction.CustomerTransaction_Amount-IIf(IsNull([CustomerTransaction.CustomerTransaction_Allocated]),0,[CustomerTransaction.CustomerTransaction_Allocated]))<>0)) ORDER BY CustomerTransaction.CustomerTransaction_Date;", cnnDBStatement, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);

			if (rsTransaction.BOF | rsTransaction.EOF) {
				rsTransaction = new ADODB.Recordset();
				rsTransaction.Open("SELECT 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0," + " 0, 0 AS debit, 0 AS credit;", cnnDBStatement, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);
				Report.Database.Tables(3).SetDataSource(rsTransaction);
				//Exit Sub
			} else {
				Report.Database.Tables(3).SetDataSource(rsTransaction);

			}
			//rs.Close

			rsInterest = new ADODB.Recordset();
			//UPGRADE_WARNING: Couldn't resolve default property of object rsInterest.Open. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			rsInterest.Open("SELECT * FROM Interest WHERE (((CustomerID)=" + id + ")) and (Debit>0);", cnnDBStatement, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);

			//If rsInterest.BOF Or rsInterest.EOF Then
			if (rsInterest.RecordCount > 0) {
				//Report.Field20.Top = 280
				//Report.Field21.Top = 280
				//Report.Field22.Top = 280
				//Report.Field23.Top = 280

				Report.Database.Tables(4).SetDataSource(rsInterest);

			} else {
				rsInterest = new ADODB.Recordset();
				rsInterest.Open("SELECT 0 AS CustomerID, 0 AS CDate, 0 AS Description, 0 AS Debit, 0 AS Credit, 0 AS SumIntBal ;", cnnDBStatement, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText);
				//Report.Field20.Suppress = True
				//Report.Field21.Suppress = True
				//Report.Field22.Suppress = True
				//Report.Field23.Suppress = True
				Report.Database.Tables(4).SetDataSource(rsInterest);

				//Exit Sub
				//Set rsInterest = New Recordset
				//rsInterest.Open "SELECT * FROM Interest WHERE (((CustomerID)=" & id & "));", cnnDBStatement, adOpenStatic, adLockReadOnly, adCmdText
			}
			// rsInterest.Open ("SELECT Interest.*, Interest.Description,WHERE (((Interest.CustomerID)=" & id & "));"), cnnDBStatement, adOpenStatic, adLockReadOnly, adCmdText
			//Dim rsinte As String
			// rsinte = rsInterest("Description")
			//If rsInterest.RecordCount > 0 Then
			//        Report.Database.Tables(4).SetDataSource rsInterest, 3
			//Else
			//   Set rsInterest = New Recordset
			//   rsInterest.Open "SELECT 0 AS CustomerID, 0 AS CDate, 0 AS Description, 0 AS Debit, 0 AS Credit, 0 AS SumIntBal ;", cnnDBStatement, adOpenStatic, adLockReadOnly, adCmdText
			//   Report.Database.Tables(4).SetDataSource rsInterest, 3
			//End If

			//Set rsTrans = New Recordset
			//Dim NewDateC As String
			//NewDateC = Format(Now)
			//rsTrans.Open ""
			//Report.Database.Tables(4).SetDataSource rsTrans, 3

			if (rsTransaction.BOF | rsTransaction.EOF) {
				return;
				//rsTransaction.Open "SELECT CustomerTransaction.CustomerTransactionID, CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_Reference, CustomerTransaction.CustomerTransaction_PersonName," & _
				//'" TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" & id & "));", cnnDBStatement, adOpenStatic, adLockReadOnly, adCmdText
			}

			if (rs.Fields("Company_DebtorPrintBal").Value == true) {
				CrystalDecisions.CrystalReports.Engine.TextObject textObject = Report.ReportDefinition.ReportObjects("Text5");
				textObject.Color = Color.White;
			}
			//Report.PrintOut False, 1
			//Screen.MousePointer = vbDefault

			My.MyProject.Forms.frmReportShow.Text = "Customer Statement";
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "1";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		//Public Sub report_CustomerStatement(id As Long)
		//    Dim rs As Recordset
		//    Dim rsCompany As Recordset
		//    Dim rsTransaction As Recordset
		//    Dim lAddress As String
		//    Dim lNumber As String
		//    Dim Report As New cryCustomerStatement
		//    Screen.MousePointer = vbHourglass
		//
		//    Set rs = getRS("SELECT * FROM Company")
		//
		//    If IsNull(rs("Company_PhysicalAddress")) Then
		//
		//    Else
		//        lAddress = Replace(rs("Company_PhysicalAddress"), vbCrLf, ", ")
		//        If Right(lAddress, 2) = ", " Then
		//          lAddress = Left(lAddress, Len(lAddress) - 2)
		//        End If
		//    End If
		//
		//    Report.Database.Tables(1).SetDataSource rs, 3
		//    Report.txtAddress.SetText lAddress
		//    lNumber = ""
		//    If rs("Company_Telephone") <> "" Then lNumber = lNumber & "Tel: " & rs("Company_Telephone")
		//    If rs("Company_Fax") <> "" Then
		//        If lNumber <> "" Then lNumber = lNumber & " / "
		//        lNumber = lNumber & "Fax: " & rs("Company_Fax")
		//    End If
		//    If rs("Company_Email") <> "" Then
		//        If lNumber <> "" Then lNumber = lNumber & " / "
		//        lNumber = lNumber & "Email: " & rs("Company_Email")
		//    End If
		//    Report.txtNumbers.SetText lNumber
		//
		//    'New banking details
		//      If IsNull(rs("Company_BankName")) Then Else Report.txtBankName.SetText rs("Company_BankName")
		//
		//       If IsNull(rs("Company_BranchName")) Then Else Report.txtBranchName.SetText rs("Company_BranchName")
		//
		//       If IsNull(rs("Company_BranchCode")) Then Else Report.txtBranchCode.SetText rs("Company_BranchCode")
		//
		//       If IsNull(rs("Company_AccountNumber")) Then Else Report.txtAccountNumber.SetText rs("Company_AccountNumber")
		//    '...................
		//
		//
		//    Set rsCompany = getRS("SELECT * FROM Customer Where CustomerID = " & id)
		//    Report.Database.Tables(2).SetDataSource rsCompany, 3
		//    Set rsTransaction = getRS("SELECT CustomerTransaction.*, TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" & id & "));")
		//    Report.Database.Tables(3).SetDataSource rsTransaction, 3

		//    If rsTransaction.BOF Or rsTransaction.EOF Then
		//        'ReportNone.Load("cryNoRecords.rpt")
		//        ReportNone.txtCompanyName.SetText rs("Company_Name")
		//        ReportNone.txtTitle.SetText "Statement"
		//        frmReportShow.Caption = ReportNone.txtTitle.Text
		//        frmReportShow.CRViewer1.ReportSource = ReportNone
		//        Set frmReportShow.mReport = ReportNone: frmReportShow.sMode = "0"
		//        frmReportShow.CRViewer1.ViewReport
		//        Screen.MousePointer = vbDefault
		//        frmReportShow.show 1
		//        Exit Sub
		//    End If
		//
		//    frmReportShow.Caption = "Customer Statement"
		//    frmReportShow.CRViewer1.ReportSource = Report
		//    Set frmReportShow.mReport = Report: frmReportShow.sMode = "0"
		//    frmReportShow.CRViewer1.ViewReport
		//    Screen.MousePointer = vbDefault
		//    frmReportShow.show 1
		//
		//End Sub

		public static void report_CustomerNotes(ref int id, ref object section)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsCompany = default(ADODB.Recordset);
			ADODB.Recordset rsTransaction = default(ADODB.Recordset);
			ADODB.Recordset rsInterest = default(ADODB.Recordset);
			string lAddress = null;
			string lNumber = null;
			//Dim Report As New cryCustomerStatement
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryCustomerStatement");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

			switch (section) {
				case 3:
					Report.SetParameterValue("Text1", " Debit Note ");
					break;
				case 4:
					Report.SetParameterValue("Text1", " Credit Note ");
					break;
			}

			rs = modRecordSet.getRS(ref "SELECT * FROM Company");


			if (Information.IsDBNull(rs.Fields("Company_PhysicalAddress").Value)) {
			} else {
				lAddress = Strings.Replace(rs.Fields("Company_PhysicalAddress").Value, Constants.vbCrLf, ", ");
				if (Strings.Right(lAddress, 2) == ", ") {
					lAddress = Strings.Left(lAddress, Strings.Len(lAddress) - 2);
				}
			}

			Report.Database.Tables(1).SetDataSource(rs);
			Report.SetParameterValue("txtAddress", lAddress);
			lNumber = "";
			if (!string.IsNullOrEmpty(rs.Fields("Company_Telephone").Value))
				lNumber = lNumber + "Tel: " + rs.Fields("Company_Telephone").Value;
			if (!string.IsNullOrEmpty(rs.Fields("Company_Fax").Value)) {
				if (!string.IsNullOrEmpty(lNumber))
					lNumber = lNumber + " / ";
				lNumber = lNumber + "Fax: " + rs.Fields("Company_Fax").Value;
			}
			if (!string.IsNullOrEmpty(rs.Fields("Company_Email").Value)) {
				if (!string.IsNullOrEmpty(lNumber))
					lNumber = lNumber + " / ";
				lNumber = lNumber + "Email: " + rs.Fields("Company_Email").Value;
			}
			Report.SetParameterValue("txtNumbers", lNumber);

			//New banking details
			if (Information.IsDBNull(rs.Fields("Company_BankName").Value)) {
			} else {
				Report.SetParameterValue("txtBankName", rs.Fields("Company_BankName"));
			}

			if (Information.IsDBNull(rs.Fields("Company_BranchName").Value)) {
			} else {
				Report.SetParameterValue("txtBranchName", rs.Fields("Company_BranchName"));
			}

			if (Information.IsDBNull(rs.Fields("Company_BranchCode").Value)) {
			} else {
				Report.SetParameterValue("txtBranchCode", rs.Fields("Company_BranchCode"));
			}

			if (Information.IsDBNull(rs.Fields("Company_AccountNumber").Value)) {
			} else {
				Report.SetParameterValue("txtAccountNumber", rs.Fields("Company_AccountNumber"));
			}
			//...................

			rsCompany = modRecordSet.getRS(ref "SELECT * FROM Customer Where CustomerID = " + id);
			Report.Database.Tables(2).SetDataSource(rsCompany);
			rsTransaction = modRecordSet.getRS(ref "SELECT CustomerTransaction.*, TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" + id + "));");
			Report.Database.Tables(3).SetDataSource(rsTransaction);

			rsInterest = modRecordSet.getRS(ref "SELECT * FROM Interest where CustomerID=" + id);
			Report.Database.Tables(4).SetDataSource(rsInterest);

			//'ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords");
			if (rsTransaction.BOF | rsTransaction.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
				ReportNone.SetParameterValue("txtTitle", "Statement");
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			//'Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = "Customer Statement";
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.sMode = "Cusmtomer";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		public static void report_StockItemDuplicateCodes()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryStockDuplicateCodes
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryStockDuplicateCodes");
			ReportNone.Load("cryNoRecords");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();
			rs = modRecordSet.getRS(ref "DISPLAY_StockDuplicateCodes");
			//'ReportNone.Load("cryNoRecords.rpt")
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.SetDataSource(rs);
			Report.Database.Tables(1).SetDataSource(rs);
			//'Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}
		public static void report_Deposits()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryDeposits
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryDeposits");
			ReportNone.Load("cryNoRecords");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();
			rs = modRecordSet.getRS(ref "SELECT * FROM Deposit");
			//'ReportNone.Load("cryNoRecords.rpt")
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			Report.SetDataSource(rs);
			Report.Database.Tables(1).SetDataSource(rs);
			//'Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		public static void report_Deposits_Query(ref string sQuery)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryDeposits
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryDeposits");
			ReportNone.Load("cryNoRecords");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();
			rs = modRecordSet.getRS(ref sQuery);
			//'ReportNone.Load("cryNoRecords.rpt")
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			Report.SetDataSource(rs);
			Report.Database.Tables(1).SetDataSource(rs);
			//'Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		public static void report_PrintStockSerialsRPT()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New crySerialList
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			bool showTotal = false;
			Report.Load("crySerialList");
			ReportNone.Load("cryNoRecords");
			showTotal = false;
			if (Interaction.MsgBox("Do you wish to see only totals?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) == MsgBoxResult.Yes) {
				showTotal = true;
			}
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();
			//Set rs = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_Name, SerialTracking.Serial_SerialNumber, SerialTracking.Serial_SupplierName, SerialTracking.Serial_DatePurchases, SerialTracking.Serial_Instock, SerialTracking.Serial_GRV_ID, SerialTracking.Serial_DateSold, GRV.GRV_Date, GRV.GRV_InvoiceNumber, GRV.GRV_InvoiceDate FROM (StockItem INNER JOIN SerialTracking ON StockItem.StockItemID = SerialTracking.Serial_StockItemID) INNER JOIN GRV ON SerialTracking.Serial_GRV_ID = GRV.GRVID WHERE (((SerialTracking.Serial_Instock)=False) AND ((StockItem.StockItem_SerialTracker)=True));")
			rs = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, StockItem.StockItem_Name, SerialTracking.Serial_SerialNumber, SerialTracking.Serial_SupplierName, SerialTracking.Serial_DatePurchases, SerialTracking.Serial_Instock, SerialTracking.Serial_GRV_ID, SerialTracking.Serial_DateSold, GRV.GRV_Date, GRV.GRV_InvoiceNumber, GRV.GRV_InvoiceDate FROM (StockItem INNER JOIN SerialTracking ON StockItem.StockItemID = SerialTracking.Serial_StockItemID) LEFT JOIN GRV ON SerialTracking.Serial_GRV_ID = GRV.GRVID WHERE (((SerialTracking.Serial_Instock)=False) AND ((StockItem.StockItem_SerialTracker)=True));");
			//'ReportNone.Load("cryNoRecords.rpt")
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			Report.SetDataSource(rs);
			Report.Database.Tables(1).SetDataSource(rs);
			if (showTotal == true) {
				Report.ReportDefinition.Sections("Section4").SectionFormat.EnableSuppress = true;
			}
			//'Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		public static void report_BOM(ref string lcriteria = "")
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryBOM
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryBOM");
			ReportNone.Load("cryNoRecords");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();
			sql = "SELECT report_recipe.* FROM report_recipe ";
			//    If lcriteria <> "" Then sql = sql & " WHERE " & lcriteria
			rs = modRecordSet.getRS(ref sql + lcriteria);
			//'ReportNone.Load("cryNoRecords.rpt")
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			Report.SetDataSource(rs);
			Report.Database.Tables(1).SetDataSource(rs);
			//'Report.VerifyOnEveryPrint = True
			//    With Report
			//        .ExportOptions.FormatType = crEFTExplorer32Extend
			//        .ExportOptions.DestinationType = crEDTDiskFile
			//        .ExportOptions.DiskFileName = App.Path + "\test.html"
			//        ' location & the file name
			//        .ExportOptions.HTMLFileName = App.Path + "\test.html" 'PDFExportAllPages = True
			//        .Export (False)
			//    End With
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		public static void report_StockBreak()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryStockBreak
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryStockBreak");
			ReportNone.Load("cryNoRecords");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();
			rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, StockItem_1.StockItem_Name AS StockItemChild_Name, StockBreak.* FROM (StockItem INNER JOIN StockBreak ON StockItem.StockItemID = StockBreak.StockBreak_ParentID) INNER JOIN StockItem AS StockItem_1 ON StockBreak.StockBreak_ChildID = StockItem_1.StockItemID ORDER BY StockItem.StockItem_Name;");
			//'ReportNone.Load("cryNoRecords.rpt")
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				//UPGRADE_WARNING: Couldn't resolve default property of object ReportNone.txtTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object Report.Database. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Report.Database.Tables(0).SetDataSource(rs);
			//UPGRADE_WARNING: Couldn't resolve default property of object Report.Database. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Report.Database.Tables(1).SetDataSource(rs);
			//UPGRADE_WARNING: Couldn't resolve default property of object Report.VerifyOnEveryPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//'Report.VerifyOnEveryPrint = True
			//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}
		public static void report_StockValue()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//UPGRADE_ISSUE: cryStockValue object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
			//Dim Report As New cryStockValue
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryStockValue");
			ReportNone.Load("cryNoRecords");
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtCompanyName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();

			sql = "SELECT StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID FROM (Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID GROUP BY StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, Warehouse.Warehouse_Saleable, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID ";
			sql = sql + " Having (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity)) > 0) And ((Warehouse.Warehouse_Saleable) = True) And ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) = 2)) ORDER BY StockItem.StockItem_Name;";

			rs = modRecordSet.getRS(ref sql);

			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				//UPGRADE_WARNING: Couldn't resolve default property of object ReportNone.txtTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.Database.Tables(0).SetDataSource(rs);
			//UPGRADE_WARNING: Couldn't resolve default property of object Report.VerifyOnEveryPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//'Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();

		}
		public static void report_StockValuebyGS(ref string grpID)
		{
			ADODB.Recordset rsWH = default(ADODB.Recordset);
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//UPGRADE_ISSUE: cryStockValuebyGS object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
			//Dim Report As New cryStockValuebyGS 'cryStockValue
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryStockValueByGS");
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtCompanyName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();

			int lMWNo = 0;
			lMWNo = My.MyProject.Forms.frmMWSelect.getMWNo();
			if (lMWNo > 1) {
				rsWH = modRecordSet.getRS(ref "SELECT * FROM Warehouse WHERE WarehouseID=" + lMWNo + ";");
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtWH. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.SetParameterValue("txtWH", rsWH("Warehouse_Name"));
			}

			if (!string.IsNullOrEmpty(grpID)) {
				//Multi Warehouse change
				//sql = "SELECT StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID FROM StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID GROUP BY StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, "
				//sql = sql & "WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID, Warehouse.Warehouse_Saleable HAVING (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity))>0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2) AND ((Warehouse.Warehouse_Saleable)=True)) AND (" & grpID & ") ORDER BY StockItem.StockItem_Name;"
				if (Interaction.MsgBox("Do you wish to see Retail Value instead of Cost Value?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) == MsgBoxResult.Yes) {
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.SetParameterValue("txtTitle", "Current Stock Retail Value By Group");
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.Text4. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.SetParameterValue("Text4", "Retail Value");
					//sql = "SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID FROM (StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID) INNER JOIN CatalogueChannelLnk ON (StockItem.StockItem_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) "
					//sql = sql & "GROUP BY StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID, Warehouse.Warehouse_Saleable, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID Having (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity)) > 0) And ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) =" & lMWNo & ") And ((Warehouse.Warehouse_Saleable) = True) And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1)) AND (" & grpID & ") ORDER BY StockItem.StockItem_Name;"
					//changed for Supplier QTY by markus
					sql = "SELECT StockItem.StockItem_Name, ([CatalogueChannelLnk.CatalogueChannelLnk_Price]/[StockItem.StockItem_Quantity]), Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID FROM (StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) LEFT JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID) INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID ";
					sql = sql + "GROUP BY StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID, Warehouse.Warehouse_Saleable, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID Having (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity)) > 0) And ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) = " + lMWNo + ") And ((Warehouse.Warehouse_Saleable) = True) And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1)) AND (" + grpID + ") ORDER BY StockItem.StockItem_Name;";
				} else {
					sql = "SELECT StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID FROM StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID GROUP BY StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, ";
					sql = sql + "WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID, Warehouse.Warehouse_Saleable HAVING (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity))>0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=" + lMWNo + ") AND ((Warehouse.Warehouse_Saleable)=True)) AND (" + grpID + ") ORDER BY StockItem.StockItem_Name;";
				}
				//sql = "SELECT StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID FROM StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID GROUP BY StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, "
				//sql = sql & "WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID, Warehouse.Warehouse_Saleable HAVING (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity))>0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=" & lMWNo & ") AND ((Warehouse.Warehouse_Saleable)=True)) AND (" & grpID & ") ORDER BY StockItem.StockItem_Name;"
				//Multi Warehouse change
			} else {
				//Multi Warehouse change
				//sql = "SELECT StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name FROM StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID GROUP BY StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, "
				//sql = sql & "WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, Warehouse.Warehouse_Saleable, StockGroup.StockGroup_Name HAVING (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity))>0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2) AND ((Warehouse.Warehouse_Saleable)=True)) ORDER BY StockItem.StockItem_Name;"
				if (Interaction.MsgBox("Do you wish to see Retail Value instead of Cost Value?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) == MsgBoxResult.Yes) {
					Report.SetParameterValue("txtTitle", "Current Stock Retail Value By Group");
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.Text4. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.SetParameterValue("Text4", "Retail Value");
					//sql = "SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name FROM (StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID) INNER JOIN CatalogueChannelLnk ON (StockItem.StockItem_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) "
					//sql = sql & "GROUP BY StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, Warehouse.Warehouse_Saleable, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID Having (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity)) > 0) And ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) =" & lMWNo & ") And ((Warehouse.Warehouse_Saleable) = True) And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1)) ORDER BY StockItem.StockItem_Name;"
					//changed for Supplier QTY by markus
					sql = "SELECT StockItem.StockItem_Name, ([CatalogueChannelLnk.CatalogueChannelLnk_Price]/[StockItem.StockItem_Quantity]), Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID FROM (StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) LEFT JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID) INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID ";
					sql = sql + "GROUP BY StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID, Warehouse.Warehouse_Saleable, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID Having (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity)) > 0) And ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) = " + lMWNo + ") And ((Warehouse.Warehouse_Saleable) = True) And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1)) ORDER BY StockItem.StockItem_Name;";
				} else {
					sql = "SELECT StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name FROM StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID GROUP BY StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, ";
					sql = sql + "WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, Warehouse.Warehouse_Saleable, StockGroup.StockGroup_Name HAVING (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity))>0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=" + lMWNo + ") AND ((Warehouse.Warehouse_Saleable)=True)) ORDER BY StockItem.StockItem_Name;";
				}
				//sql = "SELECT StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name FROM StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID GROUP BY StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, "
				//sql = sql & "WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, Warehouse.Warehouse_Saleable, StockGroup.StockGroup_Name HAVING (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity))>0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=" & lMWNo & ") AND ((Warehouse.Warehouse_Saleable)=True)) ORDER BY StockItem.StockItem_Name;"
				//Multi Warehouse change
			}

			rs = modRecordSet.getRS(ref sql);

			//'ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.Database.Tables(0).SetDataSource(rs);
			//'Report.VerifyOnEveryPrint = True
			//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();

		}

		public static void report_StockValuebyGX(ref string grpID)
		{
			ADODB.Recordset rsWH = default(ADODB.Recordset);
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryStockValuebyGX
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryStockValuebyGX");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();

			int lMWNo = 0;
			lMWNo = My.MyProject.Forms.frmMWSelect.getMWNo();
			if (lMWNo > 1) {
				rsWH = modRecordSet.getRS(ref "SELECT * FROM Warehouse WHERE WarehouseID=" + lMWNo + ";");
				Report.SetParameterValue("txtWH", rsWH("Warehouse_Name"));
			}

			if (!string.IsNullOrEmpty(grpID)) {
				//Multi Warehouse change
				//sql = "SELECT StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID FROM StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID GROUP BY StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, "
				//sql = sql & "WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID, Warehouse.Warehouse_Saleable HAVING (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity))>0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2) AND ((Warehouse.Warehouse_Saleable)=True)) AND (" & grpID & ") ORDER BY StockItem.StockItem_Name;"
				if (Interaction.MsgBox("Do you wish to see Retail Value instead of Cost Value?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) == MsgBoxResult.Yes) {
					Report.SetParameterValue("txtTitle", "Current Stock Retail Value By Group");
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.Text4. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.SetParameterValue("Text4", "Retail Value");
					//sql = "SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID FROM (StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID) INNER JOIN CatalogueChannelLnk ON (StockItem.StockItem_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) "
					//sql = sql & "AND (StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) GROUP BY StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID, Warehouse.Warehouse_Saleable, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID Having (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity)) > 0) And ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) =" & lMWNo & ") And ((Warehouse.Warehouse_Saleable) = True) And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1)) AND (" & grpID & ") ORDER BY StockItem.StockItem_Name;"
					//changed for Supplier QTY by markus
					sql = "SELECT StockItem.StockItem_Name, ([CatalogueChannelLnk.CatalogueChannelLnk_Price]/[StockItem.StockItem_Quantity]), Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID FROM (StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) LEFT JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID) INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID ";
					sql = sql + "GROUP BY StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID, Warehouse.Warehouse_Saleable, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity Having (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity)) > 0) And ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) = " + lMWNo + ") And ((Warehouse.Warehouse_Saleable) = True) And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = 1)) AND (" + grpID + ") ORDER BY StockItem.StockItem_Name;";
				} else {
					sql = "SELECT StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID FROM StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID GROUP BY StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, ";
					sql = sql + "WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID, Warehouse.Warehouse_Saleable HAVING (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity))>0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=" + lMWNo + ") AND ((Warehouse.Warehouse_Saleable)=True)) AND (" + grpID + ") ORDER BY StockItem.StockItem_Name;";
				}
				//Multi Warehouse change
			} else {
				//Multi Warehouse change
				//sql = "SELECT StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name FROM StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID GROUP BY StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, "
				//sql = sql & "WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, Warehouse.Warehouse_Saleable, StockGroup.StockGroup_Name HAVING (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity))>0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2) AND ((Warehouse.Warehouse_Saleable)=True)) ORDER BY StockItem.StockItem_Name;"
				if (Interaction.MsgBox("Do you wish to see Retail Value instead of Cost Value?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) == MsgBoxResult.Yes) {
					Report.SetParameterValue("txtTitle", "Current Stock Retail Value By Group");
					Report.SetParameterValue("Text4", "Retail Value");
					//sql = "SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name FROM (StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID) INNER JOIN CatalogueChannelLnk ON (StockItem.StockItem_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) "
					//sql = sql & "GROUP BY StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, Warehouse.Warehouse_Saleable, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID Having (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity)) > 0) And ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) =" & lMWNo & ") And ((Warehouse.Warehouse_Saleable) = True) And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1)) ORDER BY StockItem.StockItem_Name;"
					//changed for Supplier QTY by markus
					sql = "SELECT StockItem.StockItem_Name, ([CatalogueChannelLnk.CatalogueChannelLnk_Price]/[StockItem.StockItem_Quantity]), Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID FROM (StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) LEFT JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID) INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID ";
					sql = sql + "GROUP BY StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID, Warehouse.Warehouse_Saleable, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity Having (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity)) > 0) And ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) = " + lMWNo + ") And ((Warehouse.Warehouse_Saleable) = True) And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = 1)) ORDER BY StockItem.StockItem_Name;";
				} else {
					sql = "SELECT StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name FROM StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID GROUP BY StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, ";
					sql = sql + "WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, Warehouse.Warehouse_Saleable, StockGroup.StockGroup_Name HAVING (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity))>0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=" + lMWNo + ") AND ((Warehouse.Warehouse_Saleable)=True)) ORDER BY StockItem.StockItem_Name;";
				}
				//Multi Warehouse change
			}

			Debug.Print(sql);
			rs = modRecordSet.getRS(ref sql);
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryReportNone");
			//'ReportNone.Load("cryNoRecords.rpt")
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				//UPGRADE_WARNING: Couldn't resolve default property of object ReportNone.txtTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.Database.Tables(0).SetDataSource(rs);
			//'Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();

		}

		public static void report_StockValuebyGX_RepDB(ref string grpID)
		{
			//Public Sub report_StockValuebyGX(grpID As String)
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryStockValuebyGX_RepDB
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryStockValuebyGX_RepDB");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();

			Report.SetParameterValue("txtTitle", "Stock Content Value By Group");

			if (!string.IsNullOrEmpty(grpID)) {
				//sql = "SELECT StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID FROM StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID GROUP BY StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, "
				//sql = sql & "WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, Warehouse.Warehouse_Saleable, StockGroup.StockGroupID HAVING (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity))>0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2) AND ((Warehouse.Warehouse_Saleable)=True) AND " & GrpID & ") ORDER BY StockItem.StockItem_Name;"
				sql = "SELECT StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID FROM StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID GROUP BY StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, ";
				sql = sql + "WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID, Warehouse.Warehouse_Saleable HAVING (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity))>0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2) AND ((Warehouse.Warehouse_Saleable)=True)) AND (" + grpID + ") ORDER BY StockItem.StockItem_Name;";
			} else {
				//sql = "SELECT aStockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk1.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, aStockItem.StockItem_ListCost, aStockItem.StockItem_Quantity, aDeposit.Deposit_UnitCost, WarehouseStockItemLnk1.WarehouseStockItemLnk_WarehouseID, aStockGroup.StockGroup_Name FROM aStockGroup INNER JOIN ((Warehouse1 INNER JOIN (WarehouseStockItemLnk1 INNER JOIN aStockItem ON WarehouseStockItemLnk1.WarehouseStockItemLnk_StockItemID = aStockItem.StockItemID) ON Warehouse1.WarehouseID = WarehouseStockItemLnk1.WarehouseStockItemLnk_WarehouseID) INNER JOIN aDeposit ON aStockItem.StockItem_DepositID = aDeposit.DepositID) ON aStockGroup.StockGroupID = aStockItem.StockItem_StockGroupID GROUP BY aStockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], aStockItem.StockItem_ListCost, aStockItem.StockItem_Quantity, aDeposit.Deposit_UnitCost, "
				//sql = sql & "WarehouseStockItemLnk1.WarehouseStockItemLnk_WarehouseID, Warehouse1.Warehouse_Saleable, aStockGroup.StockGroup_Name HAVING (((Sum(WarehouseStockItemLnk1.WarehouseStockItemLnk_Quantity))>0) AND ((WarehouseStockItemLnk1.WarehouseStockItemLnk_WarehouseID)=2) AND ((Warehouse1.Warehouse_Saleable)=True)) ORDER BY aStockItem.StockItem_Name;"
				sql = "SELECT aStockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, aStockItem.StockItem_ListCost, aStockItem.StockItem_Quantity, aDeposit.Deposit_UnitCost, 2 AS WarehouseStockItemLnk_WarehouseID, aStockGroup.StockGroup_Name FROM (aStockGroup INNER JOIN (aStockItem INNER JOIN aDeposit ON aStockItem.StockItem_DepositID = aDeposit.DepositID) ON aStockGroup.StockGroupID = aStockItem.StockItem_StockGroupID) INNER JOIN DayEndStockItemLnk ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID GROUP BY aStockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], aStockItem.StockItem_ListCost, aStockItem.StockItem_Quantity, aDeposit.Deposit_UnitCost, aStockGroup.StockGroup_Name Having (((Sum(DayEndStockItemLnk.DayEndStockItemLnk_Quantity)) > 0)) ORDER BY aStockItem.StockItem_Name;";

				sql = "SELECT aStockItem.StockItem_Name, ([StockItem_ListCost]/iif([DayEndStockItemLnk.DayEndStockItemLnk_Quantity]=0,1,[DayEndStockItemLnk.DayEndStockItemLnk_Quantity])) AS ListCost, Sum(DayEndStockItemLnk.DayEndStockItemLnk_Quantity-DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales-DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink+DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV) AS SumOfWarehouseStockItemLnk_Quantity, ";
				//sql = sql & "aStockItem.StockItem_ListCost, aStockItem.StockItem_Quantity, aDeposit.Deposit_UnitCost, 2 AS WarehouseStockItemLnk_WarehouseID, aStockGroup.StockGroup_Name FROM (aStockGroup INNER JOIN (aStockItem INNER JOIN aDeposit ON aStockItem.StockItem_DepositID = aDeposit.DepositID) ON aStockGroup.StockGroupID = aStockItem.StockItem_StockGroupID) INNER JOIN DayEndStockItemLnk ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID GROUP BY aStockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], aStockItem.StockItem_ListCost, aStockItem.StockItem_Quantity, aDeposit.Deposit_UnitCost, aStockGroup.StockGroup_Name Having (((Sum(DayEndStockItemLnk.DayEndStockItemLnk_Quantity-DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales-DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink+DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV)) > 0)) ORDER BY aStockItem.StockItem_Name;"
				sql = sql + "aStockItem.StockItem_ListCost, aStockItem.StockItem_Quantity, aDeposit.Deposit_UnitCost, 2 AS WarehouseStockItemLnk_WarehouseID, aStockGroup.StockGroup_Name FROM (aStockGroup INNER JOIN (aStockItem INNER JOIN aDeposit ON aStockItem.StockItem_DepositID = aDeposit.DepositID) ON aStockGroup.StockGroupID = aStockItem.StockItem_StockGroupID) INNER JOIN DayEndStockItemLnk ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID GROUP BY aStockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], aStockItem.StockItem_ListCost, aStockItem.StockItem_Quantity, aDeposit.Deposit_UnitCost, aStockGroup.StockGroup_Name Having (((Sum(DayEndStockItemLnk.DayEndStockItemLnk_Quantity-DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales-DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink+DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV)) <> 0)) ORDER BY aStockItem.StockItem_Name;";

				sql = "SELECT aStockItem.StockItem_Name, [DayEndStockItemLnk_ListCost]/IIf([DayEndStockItemLnk_Quantity]=0,1,[DayEndStockItemLnk_Quantity]) AS ListCost, Sum(DayEndStockItemLnk.DayEndStockItemLnk_Quantity-DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales-DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink+DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV) AS SumOfWarehouseStockItemLnk_Quantity, ";
				sql = sql + "DayEndStockItemLnk.DayEndStockItemLnk_ListCost AS StockItem_ListCost, DayEndStockItemLnk.DayEndStockItemLnk_Quantity AS StockItem_Quantity, aDeposit.Deposit_UnitCost, 2 AS WarehouseStockItemLnk_WarehouseID, aStockGroup.StockGroup_Name FROM (aStockGroup INNER JOIN (aStockItem INNER JOIN aDeposit ON aStockItem.StockItem_DepositID = aDeposit.DepositID) ON aStockGroup.StockGroupID = aStockItem.StockItem_StockGroupID) INNER JOIN DayEndStockItemLnk ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID GROUP BY aStockItem.StockItem_Name, [DayEndStockItemLnk_ListCost]/IIf([DayEndStockItemLnk_Quantity]=0,1,[DayEndStockItemLnk_Quantity]), DayEndStockItemLnk.DayEndStockItemLnk_ListCost, DayEndStockItemLnk.DayEndStockItemLnk_Quantity, aDeposit.Deposit_UnitCost, aStockGroup.StockGroup_Name ";
				sql = sql + "Having (((Sum(DayEndStockItemLnk.DayEndStockItemLnk_Quantity-DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales-DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink+DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV)) <> 0)) ORDER BY aStockItem.StockItem_Name;";

				sql = "SELECT aStockItem.StockItem_Name, [DayEndStockItemLnk_ListCost]/IIf([DayEndStockItemLnk_Quantity]=0,1,[DayEndStockItemLnk_Quantity]) AS ListCost, Sum(DayEndStockItemLnk.DayEndStockItemLnk_Quantity-DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales-DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink+DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV) AS SumOfWarehouseStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_ListCost AS StockItem_ListCost, DayEndStockItemLnk.DayEndStockItemLnk_Quantity AS StockItem_Quantity, aDeposit.Deposit_UnitCost, 2 AS WarehouseStockItemLnk_WarehouseID, aStockGroup.StockGroup_Name ";
				sql = sql + "FROM ((aStockGroup INNER JOIN (aStockItem INNER JOIN aDeposit ON aStockItem.StockItem_DepositID = aDeposit.DepositID) ON aStockGroup.StockGroupID = aStockItem.StockItem_StockGroupID) INNER JOIN DayEndStockItemLnk ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) INNER JOIN Report ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Report.Report_DayEndEndID GROUP BY aStockItem.StockItem_Name, [DayEndStockItemLnk_ListCost]/IIf([DayEndStockItemLnk_Quantity]=0,1,[DayEndStockItemLnk_Quantity]), DayEndStockItemLnk.DayEndStockItemLnk_ListCost, DayEndStockItemLnk.DayEndStockItemLnk_Quantity, aDeposit.Deposit_UnitCost, aStockGroup.StockGroup_Name ";
				sql = sql + "HAVING (((Sum([DayEndStockItemLnk].[DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk].[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk].[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk].[DayEndStockItemLnk_QuantityGRV]))<>0)) ORDER BY aStockItem.StockItem_Name;";

				//query with Warehouse name for each item (changed on 08 Jan 2010)
				sql = "SELECT aStockItem.StockItem_Name, [DayEndStockItemLnk_ListCost]/IIf([DayEndStockItemLnk_Quantity]=0,1,[DayEndStockItemLnk_Quantity]) AS ListCost, Sum(DayEndStockItemLnk.DayEndStockItemLnk_Quantity-DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales-DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink+DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV+DayEndStockItemLnk.DayEndStockItemLnk_QuantityTransafer) AS SumOfWarehouseStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_ListCost AS StockItem_ListCost, DayEndStockItemLnk.DayEndStockItemLnk_Quantity AS StockItem_Quantity, aDeposit.Deposit_UnitCost, 2 AS WarehouseStockItemLnk_WarehouseID, aStockGroup.StockGroup_Name, Warehouse1.Warehouse_Name ";
				sql = sql + "FROM (((aStockGroup INNER JOIN (aStockItem INNER JOIN aDeposit ON aStockItem.StockItem_DepositID = aDeposit.DepositID) ON aStockGroup.StockGroupID = aStockItem.StockItem_StockGroupID) INNER JOIN DayEndStockItemLnk ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) INNER JOIN Report ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Report.Report_DayEndEndID) INNER JOIN Warehouse1 ON DayEndStockItemLnk.DayEndStockItemLnk_Warehouse = Warehouse1.WarehouseID GROUP BY aStockItem.StockItem_Name, [DayEndStockItemLnk_ListCost]/IIf([DayEndStockItemLnk_Quantity]=0,1,[DayEndStockItemLnk_Quantity]), DayEndStockItemLnk.DayEndStockItemLnk_ListCost, DayEndStockItemLnk.DayEndStockItemLnk_Quantity, aDeposit.Deposit_UnitCost, aStockGroup.StockGroup_Name, Warehouse1.Warehouse_Name ";
				sql = sql + "Having (((Sum([DayEndStockItemLnk].[DayEndStockItemLnk_Quantity] - [DayEndStockItemLnk].[DayEndStockItemLnk_QuantitySales] - [DayEndStockItemLnk].[DayEndStockItemLnk_QuantityShrink] + [DayEndStockItemLnk].[DayEndStockItemLnk_QuantityGRV] + [DayEndStockItemLnk].[DayEndStockItemLnk_QuantityTransafer])) <> 0)) ORDER BY aStockItem.StockItem_Name;";

				//sql = "SELECT aStockItem.StockItem_Name, [DayEndStockItemLnk_ListCost]/IIf([DayEndStockItemLnk_Quantity]=0,1,[DayEndStockItemLnk_Quantity]) AS ListCost, Sum(DayEndStockItemLnk.DayEndStockItemLnk_Quantity-DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales-DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink+DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV) AS SumOfWarehouseStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_ListCost AS StockItem_ListCost, DayEndStockItemLnk.DayEndStockItemLnk_Quantity AS StockItem_Quantity, aDeposit.Deposit_UnitCost, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse, aStockGroup.StockGroup_Name,  (SELECT Warehouse1.Warehouse_Name FROM Warehouse1 WHERE Warehouse1.WarehouseID = DayEndStockItemLnk.DayEndStockItemLnk_Warehouse) AS Expr1 "
				//sql = sql & "FROM (((Report INNER JOIN DayEndStockItemLnk ON Report.Report_DayEndEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) INNER JOIN aStockGroup ON aStockItem.StockItem_StockGroupID = aStockGroup.StockGroupID) INNER JOIN aDeposit ON aStockItem.StockItem_DepositID = aDeposit.DepositID GROUP BY aStockItem.StockItem_Name, [DayEndStockItemLnk_ListCost]/IIf([DayEndStockItemLnk_Quantity]=0,1,[DayEndStockItemLnk_Quantity]), DayEndStockItemLnk.DayEndStockItemLnk_ListCost, DayEndStockItemLnk.DayEndStockItemLnk_Quantity, aDeposit.Deposit_UnitCost, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse, aStockGroup.StockGroup_Name "
				//sql = sql & "Having (((DayEndStockItemLnk.DayEndStockItemLnk_Quantity)<>0) AND ((Sum([DayEndStockItemLnk].[DayEndStockItemLnk_Quantity] - [DayEndStockItemLnk].[DayEndStockItemLnk_QuantitySales] - [DayEndStockItemLnk].[DayEndStockItemLnk_QuantityShrink] + [DayEndStockItemLnk].[DayEndStockItemLnk_QuantityGRV])) <> 0)) ORDER BY aStockItem.StockItem_Name;"

			}

			rs = modReport.getRSreport(ref sql);

			//'ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.Database.Tables(0).SetDataSource(rs);
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();

		}


		public static void report_StockValueByDept(ref int gID)
		{
			string sql = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rj = default(ADODB.Recordset);
			//Dim Report As New cryStockValue
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryStockValue.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();

			//Old StockTake Query
			sql = "SELECT StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID FROM (Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID GROUP BY StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, Warehouse.Warehouse_Saleable, ";
			sql = sql + "StockItem.StockItem_StockGroupID Having (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity)) > 0) And ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) = 2) And ((Warehouse.Warehouse_Saleable) = True) And ((StockItem.StockItem_StockGroupID) = " + gID + ")) ORDER BY StockItem.StockItem_Name;";

			rj = modRecordSet.getRS(ref "SELECT StockGroup.StockGroup_Name From StockGroup WHERE (((StockGroup.StockGroupID)=" + gID + "));");

			if (Information.IsDBNull(rj.Fields("StockGroup_Name").Value)) {
			} else {
				Report.SetParameterValue("txtTitle", "Current Stock Content Value For " + rj.Fields("StockGroup_Name").Value);
			}

			rs = modRecordSet.getRS(ref sql);

			//'ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.SetDataSource(rs);
			//'Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		public static void report_DepositValue_FromRepDB()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryDepositValue
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryDepositValue.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();
			Report.SetParameterValue("txtTitle", "Deposit Value Report");
			//Set rs = getRS("SELECT Deposit.Deposit_Name, Deposit.Deposit_Quantity, IIf([WarehouseDepositItemLnk_DepositTypeID],'Crate','Bottle') AS depositType, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity AS quantity, IIf([WarehouseDepositItemLnk_DepositTypeID],[Deposit_CaseCost]*[WarehouseDepositItemLnk_Quantity],[Deposit_UnitCost]*[WarehouseDepositItemLnk_Quantity]) AS [value], IIf([WarehouseDepositItemLnk_DepositTypeID],[Deposit_CaseCost],[Deposit_UnitCost]) AS price FROM WarehouseDepositItemLnk INNER JOIN Deposit ON WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = Deposit.DepositID Where (((WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity) <> 0) And ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID) = 2)) ORDER BY Deposit.Deposit_Name, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID;")

			//Set rs = getRSreport("SELECT aDeposit.Deposit_Name, aDeposit.Deposit_Quantity, IIf([DayEndDeposittemLnk_DepositType],'Crate','Bottle') AS depositType, aDayEndDepositItemLnk.DayEndDepositItemLnk_Quantity AS quantity, IIf([DayEndDeposittemLnk_DepositType],[Deposit_CaseCost]*[DayEndDepositItemLnk_Quantity],[Deposit_UnitCost]*[DayEndDepositItemLnk_Quantity]) AS [value], IIf([DayEndDeposittemLnk_DepositType],[Deposit_CaseCost],[Deposit_UnitCost]) AS price FROM Report INNER JOIN (aDayEndDepositItemLnk INNER JOIN aDeposit ON aDayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = aDeposit.DepositID) ON Report.Report_DayEndStartID = aDayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID Where (((aDayEndDepositItemLnk.DayEndDepositItemLnk_Quantity) <> 0)) ORDER BY aDeposit.Deposit_Name, aDayEndDepositItemLnk.DayEndDeposittemLnk_DepositType;")

			//sql = "SELECT aDeposit.Deposit_Name, SUM(aDeposit.Deposit_Quantity), IIf([DayEndDeposittemLnk_DepositType],'Crate','Bottle') AS depositType, Sum(aDayEndDepositItemLnk.DayEndDepositItemLnk_Quantity) AS quantity, Sum(IIf([DayEndDeposittemLnk_DepositType]=0,[Deposit_UnitCost]*([DayEndDepositItemLnk_Quantity]-DayEndDepositItemLnk_QuantitySales-DayEndDepositItemLnk_QuantityShrink+DayEndDepositItemLnk_QuantityGRV),[Deposit_CaseCost]*([DayEndDepositItemLnk_Quantity]-DayEndDepositItemLnk_QuantitySales-DayEndDepositItemLnk_QuantityShrink+DayEndDepositItemLnk_QuantityGRV))) AS [value], IIf([DayEndDeposittemLnk_DepositType],[Deposit_CaseCost],[Deposit_UnitCost]) AS price FROM Report"
			//sql = sql & " INNER JOIN (aDayEndDepositItemLnk INNER JOIN aDeposit ON aDayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = aDeposit.DepositID) ON Report.Report_DayEndEndID = aDayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID Where (((aDayEndDepositItemLnk.DayEndDepositItemLnk_Quantity) <> 0)) GROUP BY Deposit_Name, DayEndDeposittemLnk_DepositType, IIf([DayEndDeposittemLnk_DepositType],'Crate','Bottle'), IIf([DayEndDeposittemLnk_DepositType],[Deposit_CaseCost],[Deposit_UnitCost]) ORDER BY aDeposit.Deposit_Name, aDayEndDepositItemLnk.DayEndDeposittemLnk_DepositType;"
			//Set rs = getRSreport(sql)
			sql = "SELECT aDeposit.Deposit_Name, aDeposit.Deposit_Quantity, IIf([DayEndDeposittemLnk_DepositType],'Crate','Bottle') AS depositType, DayEndDepositItemLnk.DayEndDepositItemLnk_Quantity AS quantity, IIf([DayEndDeposittemLnk_DepositType]=0,[DayEndDepositItemLnk_UnitCost]*([DayEndDepositItemLnk_Quantity]-DayEndDepositItemLnk_QuantitySales-DayEndDepositItemLnk_QuantityShrink+DayEndDepositItemLnk_QuantityGRV),[DayEndDepositItemLnk_CaseCost]*([DayEndDepositItemLnk_Quantity]-DayEndDepositItemLnk_QuantitySales-DayEndDepositItemLnk_QuantityShrink+DayEndDepositItemLnk_QuantityGRV)) AS [value], IIf([DayEndDeposittemLnk_DepositType],[Deposit_CaseCost],[Deposit_UnitCost]) AS price FROM Report";
			sql = sql + " INNER JOIN (DayEndDepositItemLnk INNER JOIN aDeposit ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = aDeposit.DepositID) ON Report.Report_DayEndEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID Where (((DayEndDepositItemLnk.DayEndDepositItemLnk_Quantity) <> 0)) ORDER BY aDeposit.Deposit_Name, DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType;";
			rs = modReport.getRSreport(ref sql);

			//'ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			Report.SetDataSource(rs);
			//'Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}


		public static void report_DepositValue()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryDepositValue
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryDepositValue.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();
			rs = modRecordSet.getRS(ref "SELECT Deposit.Deposit_Name, Deposit.Deposit_Quantity, IIf([WarehouseDepositItemLnk_DepositTypeID],'Crate','Bottle') AS depositType, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity AS quantity, IIf([WarehouseDepositItemLnk_DepositTypeID],[Deposit_CaseCost]*[WarehouseDepositItemLnk_Quantity],[Deposit_UnitCost]*[WarehouseDepositItemLnk_Quantity]) AS [value], IIf([WarehouseDepositItemLnk_DepositTypeID],[Deposit_CaseCost],[Deposit_UnitCost]) AS price FROM WarehouseDepositItemLnk INNER JOIN Deposit ON WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = Deposit.DepositID Where (((WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity) <> 0) And ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID) = 2)) ORDER BY Deposit.Deposit_Name, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID;");
			//'ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			Report.SetDataSource(rs);
			//'Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}
		public static void report_StockItemDisabled()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryStockItemDisabled
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryStockItemDisabled.rpt");
			ReportNone.Load("cryNoRecords.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();
			rs = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_Disabled From StockItem Where (((StockItem.StockItem_Disabled) <> 0)) ORDER BY StockItem.StockItem_Name;");
			//'ReportNone.Load("cryNoRecords.rpt")
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			Report.SetDataSource(rs);
			Report.Database.Tables(1).SetDataSource(rs);
			//'Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}
		public static void report_StockItemFixedActual()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryStockItemFixedActual
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryStockItemFixedActual.rpt");
			ReportNone.Load("cryNoRecords.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();

			rs = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_ActualCostChange From StockItem Where (((StockItem.StockItem_ActualCostChange) <> 0)) ORDER BY StockItem.StockItem_Name;");

			//'ReportNone.Load("cryNoRecords.rpt")
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.SetDataSource(rs);
			Report.Database.Tables(1).SetDataSource(rs);
			//'Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}
		public static void report_StockItemDiscontinued()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryStockItemDiscontinued
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryStockItemDiscontinued.rpt");
			ReportNone.Load("cryNoRecords.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();
			rs = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_Discontinued From StockItem Where (((StockItem.StockItem_Discontinued) <> 0)) ORDER BY StockItem.StockItem_Name;");
			//'ReportNone.Load("cryNoRecords.rpt")
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			Report.SetDataSource(rs);
			Report.Database.Tables(1).SetDataSource(rs);
			//'Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		public static void report_StockItemBrokenPack()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryStockItemBrokenPack
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryStockItemBrokenPack.rpt");
			ReportNone.Load("cryNoRecords.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();
			rs = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_OrderQuantity, StockItem.StockItem_Quantity From StockItem Where (((StockItem.StockItem_OrderQuantity) = 1) And ((StockItem.StockItem_Quantity) <> 1)) ORDER BY StockItem.StockItem_Name;");
			//'ReportNone.Load("cryNoRecords.rpt")
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			Report.SetDataSource(rs);
			Report.Database.Tables(1).SetDataSource(rs);
			//'Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		public static void report_StockItemActualCost(ref int id)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsItems = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryStockItemActualCost
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryStockItemActualCost.rpt");
			ReportNone.Load("cryNoRecords.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();
			rs = modRecordSet.getRS(ref "SELECT StockItem.*, Supplier.Supplier_Name FROM Supplier INNER JOIN StockItem ON Supplier.SupplierID = StockItem.StockItem_SupplierID WHERE (((StockItem.StockItemID)=" + id + "));");
			//'ReportNone.Load("cryNoRecords.rpt")
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			Report.Database.Tables(1).SetDataSource(rs);
			sql = "SELECT GRV.GRVID, GRV.GRV_InvoiceNumber, GRV.GRV_InvoiceDate, GRVItem.GRVItem_StockItemID, GRVItem.GRVItem_StockItemQuantity, GRVItem.GRVItem_ContentCost, GRVItem.GRVItem_DiscountAmount, [GRVItem_ContentCost]-[GRVItem_DiscountAmount]-[GRVItem_ActualCost] AS invoiceDiscount, GRVItem.GRVItem_OldActualCost AS oldPrice, GRVItem.GRVItem_WarehouseQuantity AS oldStockHolding, [GRVItem_OldActualCost]/[GRVItem_StockItemQuantity] AS oldUnitPrice, IIf([GRVItem_WarehouseQuantity]>0,[GRVItem_OldActualCost]/[GRVItem_StockItemQuantity]*[GRVItem_WarehouseQuantity],0) AS oldStockValue, GRVItem.GRVItem_ActualCost AS grvPrice, [GRVItem_PackSize]*[GRVItem_Quantity] AS grvStockHolding, [GRVItem_ActualCost]/[grvItem_StockItemQuantity] AS grvUnitPrice, ([GRVItem_PackSize]*[GRVItem_Quantity])*([GRVItem_ActualCost]/[grvItem_StockItemQuantity]) AS grvStockValue, GRVItem.GRVItem_PackSize, ([warehouseQuantity]+[grvStockHolding]) AS newStockHolding, IIf([oldStockHolding]+[grvStockHolding]=0,[grvUnitPrice], ";
			sql = sql + "([oldStockValue]+[grvStockValue])) AS newStockValue, IIf([newStockHolding]=0,[grvUnitPrice],[newStockValue]/[newStockHolding]) AS newUnitPrice, IIf([GRVItem_WarehouseQuantity]>0,[GRVItem_WarehouseQuantity],0) AS warehouseQuantity, Supplier.Supplier_Name FROM ((GRVItem INNER JOIN GRV ON GRVItem.GRVItem_GRVID = GRV.GRVID) INNER JOIN PurchaseOrder ON GRV.GRV_PurchaseOrderID = PurchaseOrder.PurchaseOrderID) INNER JOIN Supplier ON PurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID Where (((GRVItem.GRVItem_StockItemID) = " + id + ") And ((GRVItem.GRVItem_Return) = 0)) ORDER BY GRV.GRVID DESC;";
			rsItems = modRecordSet.getRS(ref sql);
			if (rsItems.BOF | rsItems.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			Report.Database.Tables(2).SetDataSource(rsItems);
			//'Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}
		public static void report_SupplierStatement(ref int id)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsCompany = default(ADODB.Recordset);
			ADODB.Recordset rsTransaction = default(ADODB.Recordset);
			string lAddress = null;
			string lNumber = null;
			//Dim Report As New crySupplierStatement
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("crySupplierStatement.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));

			if (Information.IsDBNull(rs.Fields("Company_PhysicalAddress").Value)) {
			} else {
				lAddress = Strings.Replace(rs.Fields("Company_PhysicalAddress").Value, Constants.vbCrLf, ", ");
				if (Strings.Right(lAddress, 2) == ", ") {
					lAddress = Strings.Left(lAddress, Strings.Len(lAddress) - 2);
				}
			}


			Report.Database.Tables(1).SetDataSource(rs);
			Report.SetParameterValue("txtAddress", lAddress);
			lNumber = "";
			if (!string.IsNullOrEmpty(rs.Fields("Company_Telephone").Value))
				lNumber = lNumber + "Tel: " + rs.Fields("Company_Telephone").Value;
			if (!string.IsNullOrEmpty(rs.Fields("Company_Fax").Value)) {
				if (!string.IsNullOrEmpty(lNumber))
					lNumber = lNumber + " / ";
				lNumber = lNumber + "Fax: " + rs.Fields("Company_Fax").Value;
			}
			if (!string.IsNullOrEmpty(rs.Fields("Company_Email").Value)) {
				if (!string.IsNullOrEmpty(lNumber))
					lNumber = lNumber + " / ";
				lNumber = lNumber + "Email: " + rs.Fields("Company_Email").Value;
			}
			Report.SetParameterValue("txtNumbers", lNumber);
			rsCompany = modRecordSet.getRS(ref "SELECT * FROM Supplier Where SupplierID = " + id);
			Report.Database.Tables(1).SetDataSource(rsCompany);
			rsTransaction = modRecordSet.getRS(ref "SELECT SupplierTransaction.SupplierTransaction_SupplierID, SupplierTransaction.SupplierTransaction_Date, SupplierTransaction.SupplierTransaction_Reference, TransactionType.TransactionType_Name, IIf([SupplierTransaction_Amount]<0,[SupplierTransaction_Amount],0) AS credit, IIf([SupplierTransaction_Amount]>=0,[SupplierTransaction_Amount],0) AS debit, SupplierTransaction.SupplierTransaction_Amount FROM SupplierTransaction INNER JOIN TransactionType ON SupplierTransaction.SupplierTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((SupplierTransaction.SupplierTransaction_SupplierID)=" + id + "));");
			Report.Database.Tables(2).SetDataSource(rsTransaction);

			//'ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rsTransaction.BOF | rsTransaction.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
				ReportNone.SetParameterValue("txtTitle", "Statement");
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			My.MyProject.Forms.frmReportShow.Text = "Supplier Statement";
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();

		}

		public static void report_StockTake(ref int id, ref int MWH = 0)
		{
			string sGroup = null;
			if (id) {
			} else {
				return;
			}
			if (MWH == 0)
				My.MyProject.Forms.frmStockTakeSnapshot.remoteSnapShot();
			System.Windows.Forms.Application.DoEvents();
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsWH = default(ADODB.Recordset);
			bool ltype = false;
			bool lStockQty = false;
			bool bPrintBC_QK = false;
			//Dim Report As New cryStockTake
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryStockTake.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtDate", Strings.Format(rs.Fields("Company_StockTakeDate").Value, "dd mmm, yyyy hh:mm"));
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			ltype = rs.Fields("Company_StockTakeQuantity").Value;
			lStockQty = rs.Fields("Company_StockTakeQuantityOnly").Value;
			bPrintBC_QK = rs.Fields("Company_StockTakeBC").Value;
			rs.Close();
			rs = modRecordSet.getRS(ref "SELECT StockGroup.StockGroupID, StockGroup.StockGroup_Name, Company.Company_StockTakeDate, Company.Company_StockTakeQuantity From Company, StockGroup WHERE (((StockGroup.StockGroupID)=" + id + "));");
			Report.SetParameterValue("txtTitle", "Stock Take Sheet For: " + rs.Fields("StockGroup_Name").Value);

			//Multi Warehouse change
			//If ltype Then
			//    If lStockQty Then
			//        Set rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;")
			//    Else
			//        'Set rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_Quantity) <> 0) And ((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) <> 0) And ((StockItem.StockItem_Discontinued) <> 0)) ORDER BY StockItem.StockItem_Name;")
			//        Set rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_Quantity) <> 0) And ((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;")
			//    End If
			//
			//Else
			//    If lStockQty Then
			//        Set rs = getRS("SELECT StockItem.StockItem_Name, Null AS StockTake_Quantity, StockItem.StockItem_QuickKey, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;")
			//    Else
			//        'Set rs = getRS("SELECT StockItem.StockItem_Name, Null AS StockTake_Quantity, StockItem.StockItem_QuickKey, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) <> 0) And ((StockItem.StockItem_Discontinued) <> 0) And ((StockTake.StockTake_Quantity) <> 0)) ORDER BY StockItem.StockItem_Name;")
			//        Set rs = getRS("SELECT StockItem.StockItem_Name, Null AS StockTake_Quantity, StockItem.StockItem_QuickKey, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0) And ((StockTake.StockTake_Quantity) <> 0)) ORDER BY StockItem.StockItem_Name;")
			//    End If
			//End If

			int lMWNo = 0;
			if (MWH == 0) {
				lMWNo = My.MyProject.Forms.frmMWSelect.getMWNo();
			} else {
				lMWNo = MWH;
			}
			if (lMWNo > 1) {
				rsWH = modRecordSet.getRS(ref "SELECT * FROM Warehouse WHERE WarehouseID=" + lMWNo + ";");
				Report.SetParameterValue("txtWH", rsWH.Fields("Warehouse_Name"));
			}

			if (ltype) {
				//If lMWNo = 1 Then
				//    If lStockQty Then
				//        Set rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;")
				//    Else
				//        Set rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0) And ((StockTake.StockTake_Quantity) <> 0)) ORDER BY StockItem.StockItem_Name;")
				//    End If
				//Else
				if (lStockQty) {
					if (bPrintBC_QK) {
						rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM ((StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN Catalogue ON StockTake.StockTake_StockItemID = Catalogue.Catalogue_StockItemID Where (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockGroup.StockGroupID) = " + id + ") And ((StockItem.StockItem_Disabled) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) Or (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockGroup.StockGroupID) = " + id + ") And ((StockItem.StockItem_Discontinued) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) ORDER BY StockItem.StockItem_Name;");
					} else {
						rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockGroup.StockGroupID) = " + id + ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockGroup.StockGroupID) = " + id + ") And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;");
					}

				} else {
					if (bPrintBC_QK) {
						sGroup = "SELECT StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity";
						sGroup = sGroup + " FROM ((StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN Catalogue ON StockTake.StockTake_StockItemID = Catalogue.Catalogue_StockItemID Where (((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockGroup.StockGroupID) = " + id + ") And ((StockItem.StockItem_Disabled) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) Or (((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockGroup.StockGroupID) = " + id + ") And ((StockItem.StockItem_Discontinued) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) Or (((StockTake.StockTake_Quantity) <> 0) And ((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockGroup.StockGroupID) = " + id + ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) ORDER BY StockItem.StockItem_Name;";
						rs = modRecordSet.getRS(ref sGroup);
					} else {
						rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockGroup.StockGroupID) = " + id + ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockGroup.StockGroupID) = " + id + ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_Quantity) <> 0) And ((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockGroup.StockGroupID) = " + id + ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;");
					}
				}
				//End If

			} else {
				//If lMWNo = 1 Then
				//    sGroup = "GROUP BY StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity"
				//    If lStockQty Then
				//        Set rs = getRS("SELECT StockItem.StockItem_Name, Null AS StockTake_Quantity, StockItem.StockItem_QuickKey, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Discontinued) = 0)) " & sGroup & " ORDER BY StockItem.StockItem_Name;")
				//    Else
				//        Set rs = getRS("SELECT StockItem.StockItem_Name, Null AS StockTake_Quantity, StockItem.StockItem_QuickKey, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0) And ((StockTake.StockTake_Quantity) <> 0)) " & sGroup & " ORDER BY StockItem.StockItem_Name;")
				//    End If
				//Else
				if (lStockQty) {
					if (bPrintBC_QK) {
						rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Null AS StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM ((StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN Catalogue ON StockTake.StockTake_StockItemID = Catalogue.Catalogue_StockItemID Where (((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockGroup.StockGroupID) = " + id + ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Disabled) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) Or (((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockGroup.StockGroupID) = " + id + ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Discontinued) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) ORDER BY StockItem.StockItem_Name;");
					} else {
						rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, Null AS StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockGroup.StockGroupID) = " + id + ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockGroup.StockGroupID) = " + id + ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;");
					}
				} else {
					if (bPrintBC_QK) {
						sGroup = "SELECT StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Null AS StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity";
						sGroup = sGroup + " FROM ((StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN Catalogue ON StockTake.StockTake_StockItemID = Catalogue.Catalogue_StockItemID Where (((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockGroup.StockGroupID) = " + id + ") And ((StockItem.StockItem_Disabled) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) Or (((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockGroup.StockGroupID) = " + id + ") And ((StockItem.StockItem_Discontinued) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) Or (((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockGroup.StockGroupID) = " + id + ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0) And ((StockTake.StockTake_Quantity) <> 0) And ((Catalogue.Catalogue_Quantity) = 1)) ORDER BY StockItem.StockItem_Name;";
						rs = modRecordSet.getRS(ref sGroup);
					} else {
						rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, Null AS StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockGroup.StockGroupID) = " + id + ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockGroup.StockGroupID) = " + id + ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockGroup.StockGroupID) = " + id + ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0) And ((StockTake.StockTake_Quantity) <> 0)) ORDER BY StockItem.StockItem_Name;");
					}
				}
				//End If
			}
			//Multi Warehouse change

			//'ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.Database.Tables(1).SetDataSource(rs);
			Report.SetDataSource(rs);
			//'Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();

		}

		public static void report_StockTakeDiff(ref int id, ref int MWH = 0)
		{
			string sGroup = null;
			if (id) {
			} else {
				return;
			}
			//frmStockTakeSnapshot.remoteSnapShot
			//DoEvents
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsWH = default(ADODB.Recordset);
			bool ltype = false;
			bool lStockQty = false;
			bool bPrintBC_QK = false;
			//Dim Report As New cryStockTakeDiff
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtDate", Strings.Format(rs.Fields("Company_StockTakeDate").Value, "dd mmm, yyyy hh:mm"));
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			ltype = rs.Fields("Company_StockTakeQuantity").Value;
			lStockQty = rs.Fields("Company_StockTakeQuantityOnly").Value;
			bPrintBC_QK = rs.Fields("Company_StockTakeBC").Value;
			rs.Close();
			rs = modRecordSet.getRS(ref "SELECT StockGroup.StockGroupID, StockGroup.StockGroup_Name, Company.Company_StockTakeDate, Company.Company_StockTakeQuantity From Company, StockGroup WHERE (((StockGroup.StockGroupID)=" + id + "));");
			Report.SetParameterValue("txtTitle", "Stock Take Difference Sheet For: " + rs.Fields("StockGroup_Name").Value);

			//Multi Warehouse change
			//If ltype Then
			//    If lStockQty Then
			//        Set rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;")
			//    Else
			//        'Set rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_Quantity) <> 0) And ((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) <> 0) And ((StockItem.StockItem_Discontinued) <> 0)) ORDER BY StockItem.StockItem_Name;")
			//        Set rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_Quantity) <> 0) And ((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;")
			//    End If
			//
			//Else
			//    If lStockQty Then
			//        Set rs = getRS("SELECT StockItem.StockItem_Name, Null AS StockTake_Quantity, StockItem.StockItem_QuickKey, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;")
			//    Else
			//        'Set rs = getRS("SELECT StockItem.StockItem_Name, Null AS StockTake_Quantity, StockItem.StockItem_QuickKey, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) <> 0) And ((StockItem.StockItem_Discontinued) <> 0) And ((StockTake.StockTake_Quantity) <> 0)) ORDER BY StockItem.StockItem_Name;")
			//        Set rs = getRS("SELECT StockItem.StockItem_Name, Null AS StockTake_Quantity, StockItem.StockItem_QuickKey, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0) And ((StockTake.StockTake_Quantity) <> 0)) ORDER BY StockItem.StockItem_Name;")
			//    End If
			//End If

			int lMWNo = 0;
			if (MWH == 0) {
				lMWNo = My.MyProject.Forms.frmMWSelect.getMWNo();
			} else {
				lMWNo = MWH;
			}
			if (lMWNo > 1) {
				rsWH = modRecordSet.getRS(ref "SELECT * FROM Warehouse WHERE WarehouseID=" + lMWNo + ";");
				//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtWH. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Report.SetParameterValue("txtWH", rsWH.Fields("Warehouse_Name"));
			}

			//If ltype Then
			//    'If lMWNo = 1 Then
			//    '    If lStockQty Then
			//    '        Set rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;")
			//    '    Else
			//    '        Set rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0) And ((StockTake.StockTake_Quantity) <> 0)) ORDER BY StockItem.StockItem_Name;")
			//    '    End If
			//    'Else
			//        If lStockQty Then
			//            If bPrintBC_QK Then
			//                Set rs = getRS("SELECT StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity, StockTake_QuantityOrig FROM ((StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN Catalogue ON StockTake.StockTake_StockItemID = Catalogue.Catalogue_StockItemID Where (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) Or (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) ORDER BY StockItem.StockItem_Name;")
			//            Else
			//                Set rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity, StockTake_QuantityOrig FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;")
			//            End If
			//
			//        Else

			//+ - sign change
			bool bSign = false;
			ADODB.Recordset rsSign = default(ADODB.Recordset);
			rsSign = modRecordSet.getRS(ref "SELECT Company_ShrinkSign FROM Company;");
			if (rsSign.RecordCount) {
				if (rsSign.Fields("Company_ShrinkSign").Value)
					bSign = true;
			}
			//+ - sign change
			//sql = "SELECT aStockItem.StockItem_Name, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS list, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actual, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse, CatalogueChannelLnk.CatalogueChannelLnk_Price"
			//sql = sql & " FROM (DayEndStockItemLnk LEFT JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) INNER JOIN CatalogueChannelLnk ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID Where (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0)) GROUP BY aStockItem.StockItem_Name, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price Having (((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse) = " & lMWNo & ") And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1)) ORDER BY aStockItem.StockItem_Name;"
			if (bSign) {
				if (bPrintBC_QK) {
					sGroup = "SELECT StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, (0 - StockTake.StockTake_Quantity), StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity, (0 - StockTake_QuantityOrig)";
					sGroup = sGroup + " FROM ((StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN Catalogue ON StockTake.StockTake_StockItemID = Catalogue.Catalogue_StockItemID";
					sGroup = sGroup + " Where (((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockTake.StockTake_Quantity-StockTake.StockTake_QuantityOrig) <> 0) And ((StockGroup.StockGroupID) = " + id + ") And ((StockItem.StockItem_Disabled) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) Or (((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockTake.StockTake_Quantity-StockTake.StockTake_QuantityOrig) <> 0) And ((StockGroup.StockGroupID) = " + id + ") And ((StockItem.StockItem_Discontinued) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) Or (((StockTake.StockTake_Quantity) <> 0) And ((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockTake.StockTake_Quantity-StockTake.StockTake_QuantityOrig) <> 0) And ((StockGroup.StockGroupID) = " + id + ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) ORDER BY StockItem.StockItem_Name;";
					rs = modRecordSet.getRS(ref sGroup);
				} else {
					sGroup = "SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, (0 - StockTake.StockTake_Quantity), StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity, (0 - StockTake_QuantityOrig) FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID";
					sGroup = sGroup + " Where (((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockTake.StockTake_Quantity-StockTake.StockTake_QuantityOrig) <> 0) And ((StockGroup.StockGroupID) = " + id + ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockTake.StockTake_Quantity-StockTake.StockTake_QuantityOrig) <> 0) And ((StockGroup.StockGroupID) = " + id + ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_Quantity) <> 0) And ((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockTake.StockTake_Quantity-StockTake.StockTake_QuantityOrig) <> 0) And ((StockGroup.StockGroupID) = " + id + ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;";
					rs = modRecordSet.getRS(ref sGroup);
				}
			} else {
				if (bPrintBC_QK) {
					sGroup = "SELECT StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity, StockTake_QuantityOrig";
					sGroup = sGroup + " FROM ((StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN Catalogue ON StockTake.StockTake_StockItemID = Catalogue.Catalogue_StockItemID";
					sGroup = sGroup + " Where (((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockTake.StockTake_Quantity-StockTake.StockTake_QuantityOrig) <> 0) And ((StockGroup.StockGroupID) = " + id + ") And ((StockItem.StockItem_Disabled) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) Or (((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockTake.StockTake_Quantity-StockTake.StockTake_QuantityOrig) <> 0) And ((StockGroup.StockGroupID) = " + id + ") And ((StockItem.StockItem_Discontinued) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) Or (((StockTake.StockTake_Quantity) <> 0) And ((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockTake.StockTake_Quantity-StockTake.StockTake_QuantityOrig) <> 0) And ((StockGroup.StockGroupID) = " + id + ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) ORDER BY StockItem.StockItem_Name;";
					rs = modRecordSet.getRS(ref sGroup);
				} else {
					sGroup = "SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity, StockTake_QuantityOrig FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID";
					sGroup = sGroup + " Where (((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockTake.StockTake_Quantity-StockTake.StockTake_QuantityOrig) <> 0) And ((StockGroup.StockGroupID) = " + id + ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockTake.StockTake_Quantity-StockTake.StockTake_QuantityOrig) <> 0) And ((StockGroup.StockGroupID) = " + id + ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_Quantity) <> 0) And ((StockTake.StockTake_WarehouseID) = " + lMWNo + ") And ((StockTake.StockTake_Quantity-StockTake.StockTake_QuantityOrig) <> 0) And ((StockGroup.StockGroupID) = " + id + ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;";
					rs = modRecordSet.getRS(ref sGroup);
				}
			}
			//        End If
			//    'End If
			//
			//Else
			//    'If lMWNo = 1 Then
			//    '    sGroup = "GROUP BY StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity"
			//    '    If lStockQty Then
			//    '        Set rs = getRS("SELECT StockItem.StockItem_Name, Null AS StockTake_Quantity, StockItem.StockItem_QuickKey, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Discontinued) = 0)) " & sGroup & " ORDER BY StockItem.StockItem_Name;")
			//    '    Else
			//    '        Set rs = getRS("SELECT StockItem.StockItem_Name, Null AS StockTake_Quantity, StockItem.StockItem_QuickKey, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0) And ((StockTake.StockTake_Quantity) <> 0)) " & sGroup & " ORDER BY StockItem.StockItem_Name;")
			//    '    End If
			//    'Else
			//        If lStockQty Then
			//            If bPrintBC_QK Then
			//                Set rs = getRS("SELECT StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Null AS StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity, StockTake_QuantityOrig FROM ((StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN Catalogue ON StockTake.StockTake_StockItemID = Catalogue.Catalogue_StockItemID Where (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Disabled) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) Or (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Discontinued) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) ORDER BY StockItem.StockItem_Name;")
			//            Else
			//                Set rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, Null AS StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity, StockTake_QuantityOrig FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;")
			//            End If
			//        Else
			//            If bPrintBC_QK Then
			//                sGroup = "SELECT StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Null AS StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity, StockTake_QuantityOrig"
			//                sGroup = sGroup & " FROM ((StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN Catalogue ON StockTake.StockTake_StockItemID = Catalogue.Catalogue_StockItemID Where (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) Or (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) Or (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0) And ((StockTake.StockTake_Quantity) <> 0) And ((Catalogue.Catalogue_Quantity) = 1)) ORDER BY StockItem.StockItem_Name;"
			//                Set rs = getRS(sGroup)
			//            Else
			//                Set rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, Null AS StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity, StockTake_QuantityOrig FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0) And ((StockTake.StockTake_Quantity) <> 0)) ORDER BY StockItem.StockItem_Name;")
			//            End If
			//        End If
			//    'End If
			//End If
			//Multi Warehouse change

			//'ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.Database.Tables(1).SetDataSource(rs);
			Report.SetDataSource(rs);
			//'Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();

		}

		public static void report_StockTakeNotes()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsWH = default(ADODB.Recordset);
			//Dim Report As New cryStockTakeNotes
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryStockTakeNotes.rpt");
			int lStockGroupID = 0;

			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();

			rsWH = modRecordSet.getRS(ref "SELECT * FROM Warehouse WHERE WarehouseID=2;");
			Report.SetParameterValue("txtWH", rsWH.Fields("Warehouse_Name"));
			rsWH.Close();

			//gSection = 0
			lStockGroupID = My.MyProject.Forms.frmStockGroupListNotes.getItem();
			rs = modRecordSet.getRS(ref "SELECT StockGroup.StockGroupID, StockGroup.StockGroup_Name FROM StockGroup WHERE (((StockGroup.StockGroupID)=" + lStockGroupID + "));");
			Report.SetParameterValue("txtTitle", "Stock Take Notes For : " + rs.Fields("StockGroup_Name").Value);
			rs.Close();

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT aStockTakeDetail.StockTake_StockItemID, aStockItem1.StockItem_Name, aStockTakeDetail.StockTake_WarehouseID, aStockTakeDetail.StockTake_Quantity, aStockTakeDetail.StockTake_Adjustment, aStockTakeDetail.StockTake_DayEndID, aStockTakeDetail.StockTake_Note, aStockTakeDetail.StockTake_DateTime, aDayEnd1.DayEnd_Date FROM ((aStockItem1 INNER JOIN aStockTakeDetail ON aStockItem1.StockItemID = aStockTakeDetail.StockTake_StockItemID) INNER JOIN aStockGroup1 ON aStockItem1.StockItem_StockGroupID = aStockGroup1.StockGroupID) INNER JOIN aDayEnd1 ON aStockTakeDetail.StockTake_DayEndID = aDayEnd1.DayEndID Where (((aStockGroup1.StockGroupID) = " + lStockGroupID + ")) ORDER BY aStockItem1.StockItem_Name, aDayEnd1.DayEnd_Date;");
			//'ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.Database.Tables(1).SetDataSource(rs);
			//'Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}


		public static void report_StockNegative()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			bool ltype = false;
			bool lStockQty = false;
			//Dim Report As New cryStockNegative
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryStockNegative.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtDate", Strings.Format(rs.Fields("Company_StockTakeDate").Value, "dd mmm, yyyy hh:mm"));
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();

			rs = modRecordSet.getRS(ref "SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity, StockGroup.StockGroup_Name, StockItem.StockItem_Name FROM (StockItem INNER JOIN WarehouseStockItemLnk ON StockItem.StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) = 2) And ((WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) < 0)) ORDER BY StockGroup.StockGroup_Name, StockItem.StockItem_Name;");
			//'ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.Database.Tables(1).SetDataSource(rs);
			Report.SetDataSource(rs);
			//'Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();

		}
		public static void report_StockQuantityData(ref int id)
		{
			if (id) {
			} else {
				return;
			}
			ADODB.Recordset rs = default(ADODB.Recordset);
			bool ltype = false;
			//Dim Report As New cryStockQuantity
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryStockQuantity.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();
			rs = modRecordSet.getRS(ref "SELECT StockGroup.StockGroupID, StockGroup.StockGroup_Name, Company.Company_StockTakeDate, Company.Company_StockTakeQuantity From Company, StockGroup WHERE (((StockGroup.StockGroupID)=" + id + "));");
			Report.SetParameterValue("txtTitle", "Current Stock Holding For: " + rs.Fields("StockGroup_Name").Value);

			int lMWNo = 0;
			lMWNo = My.MyProject.Forms.frmMWSelect.getMWNo();
			if (lMWNo > 1) {
				//Set rsWH = getRS("SELECT * FROM Warehouse WHERE WarehouseID=" & lMWNo & ";")
				//Report.txtWH.SetText rsWH("Warehouse_Name")
			}

			//Multi Warehouse change         Set rs = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_Quantity, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS StockTake_Quantity FROM (Warehouse INNER JOIN WarehouseStockItemLnk ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID Where (((StockItem.StockItem_StockGroupID) = " & id & ") And ((Warehouse.WarehouseID) = 2)) GROUP BY StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_Quantity, Warehouse.Warehouse_Saleable Having (((Warehouse.Warehouse_Saleable) <> 0)) ORDER BY StockItem.StockItem_Name;")
			rs = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_Quantity, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS StockTake_Quantity FROM (Warehouse INNER JOIN WarehouseStockItemLnk ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID Where (((StockItem.StockItem_StockGroupID) = " + id + ") And ((Warehouse.WarehouseID) = " + lMWNo + ")) GROUP BY StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_Quantity, Warehouse.Warehouse_Saleable Having (((Warehouse.Warehouse_Saleable) <> 0)) ORDER BY StockItem.StockItem_Name;");
			//'ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.Database.Tables(1).SetDataSource(rs);
			Report.SetDataSource(rs);
			//'Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();

		}
		public static void report_PriceSets()
		{
			//    Dim rs As Recordset
			//    Dim RSitem As Recordset
			//    Dim ltype As Boolean
			//    Dim Report As New cryPriceSets
			//    Screen.MousePointer = vbHourglass
			//    Set rs = getRS("SELECT * FROM Company")
			//    Report.txtCompanyName.SetText rs("Company_Name")
			//    rs.Close
			//    Set rs = getRS("SELECT PriceSet.*, StockItem.*, Shrink.Shrink_Name, Deposit.Deposit_Name, Vat.Vat_Amount, PricingGroup.PricingGroup_Name FROM ((((PriceSet INNER JOIN StockItem ON PriceSet.PriceSet_StockItemID = StockItem.StockItemID) INNER JOIN Shrink ON StockItem.StockItem_ShrinkID = Shrink.ShrinkID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID ORDER BY PriceSet.PriceSet_Name;")
			//    If rs.BOF Or rs.EOF Then
			//        'ReportNone.Load("cryNoRecords.rpt")
			//        ReportNone.txtCompanyName.SetText Report.txtCompanyName.Text
			//        ReportNone.txtTitle.SetText Report.txtTitle.Text
			//        frmReportShow.Caption = ReportNone.txtTitle.Text
			//        frmReportShow.CRViewer1.ReportSource = ReportNone
			//        Set frmReportShow.mReport = ReportNone: frmReportShow.sMode = "0"
			//        frmReportShow.CRViewer1.ViewReport
			//        Screen.MousePointer = vbDefault
			//        frmReportShow.show 1
			//        Exit Sub
			//    End If
			//    Set RSitem = getRS("SELECT StockItem.* From StockItem ORDER BY StockItem.StockItem_Name;")
			//    Report.Database.Tables(1).SetDataSource rs, 3
			//   Report.Database.Tables(2).SetDataSource RSitem, 3
			//   'Report.VerifyOnEveryPrint = True
			//   frmReportShow.Caption = Report.txtTitle.Text
			//    frmReportShow.CRViewer1.ReportSource = Report
			//    Set frmReportShow.mReport = Report: frmReportShow.sMode = "0"
			//    frmReportShow.CRViewer1.ViewReport
			//    Screen.MousePointer = vbDefault
			//    frmReportShow.show 1
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset RSitem = default(ADODB.Recordset);
			bool ltype = false;
			//Dim Report As New cryPriceSets
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryPriceSets.rpt");
			int gID = 0;

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();

			rs = modRecordSet.getRS(ref "SELECT PriceSet.*, StockItem.*, Shrink.Shrink_Name, Deposit.Deposit_Name, Vat.Vat_Amount, PricingGroup.PricingGroup_Name FROM ((((PriceSet INNER JOIN StockItem ON PriceSet.PriceSet_StockItemID = StockItem.StockItemID) INNER JOIN Shrink ON StockItem.StockItem_ShrinkID = Shrink.ShrinkID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID ORDER BY PriceSet.PriceSet_Name;");
			//Set rs = getRS("SELECT PriceSet.*, StockItem.*, Shrink.Shrink_Name, Deposit.Deposit_Name, Vat.Vat_Amount, PricingGroup.PricingGroup_Name, PriceSet.PriceSet_Name FROM ((((PriceSet INNER JOIN StockItem ON PriceSet.PriceSet_StockItemID = StockItem.StockItemID) INNER JOIN Shrink ON StockItem.StockItem_ShrinkID = Shrink.ShrinkID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID Where (((PriceSet.PriceSetID) = " & gID & "))ORDER BY PriceSet.PriceSet_Name, PriceSet.PriceSetID;")

			//'ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			RSitem = modRecordSet.getRS(ref "SELECT StockItem.* From StockItem ORDER BY StockItem.StockItem_Name;");
			Report.Database.Tables(1).SetDataSource(rs);
			Report.Database.Tables(2).SetDataSource(RSitem);
			//'Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
			//End If
		}

		public static void report_SelectPriceSets()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset RSitem = default(ADODB.Recordset);
			bool ltype = false;
			//Dim Report As New cryPriceSets
			int gID = 0;
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryPriceSets.rpt");
			ReportNone.Load("cryNoRecords.rpt");
			gID = holdid;
			//'ReportNone.Load("cryNoRecords.rpt")
			if (gID) {
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
				rs = modRecordSet.getRS(ref "SELECT * FROM Company");
				Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
				rs.Close();

				//Set rs = getRS("SELECT PriceSet.*, StockItem.*, Shrink.Shrink_Name, Deposit.Deposit_Name, Vat.Vat_Amount, PricingGroup.PricingGroup_Name FROM ((((PriceSet INNER JOIN StockItem ON PriceSet.PriceSet_StockItemID = StockItem.StockItemID) INNER JOIN Shrink ON StockItem.StockItem_ShrinkID = Shrink.ShrinkID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID ORDER BY PriceSet.PriceSet_Name;")
				rs = modRecordSet.getRS(ref "SELECT PriceSet.*, StockItem.*, Shrink.Shrink_Name, Deposit.Deposit_Name, Vat.Vat_Amount, PricingGroup.PricingGroup_Name, PriceSet.PriceSet_Name FROM ((((PriceSet INNER JOIN StockItem ON PriceSet.PriceSet_StockItemID = StockItem.StockItemID) INNER JOIN Shrink ON StockItem.StockItem_ShrinkID = Shrink.ShrinkID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID Where (((PriceSet.PriceSetID) = " + gID + "))ORDER BY PriceSet.PriceSet_Name, PriceSet.PriceSetID;");

				if (rs.BOF | rs.EOF) {
					ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
					ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
					My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
					My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
					My.MyProject.Forms.frmReportShow.mReport = ReportNone;
					My.MyProject.Forms.frmReportShow.sMode = "0";
					My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
					My.MyProject.Forms.frmReportShow.ShowDialog();
					return;
				}
				RSitem = modRecordSet.getRS(ref "SELECT StockItem.* From StockItem ORDER BY StockItem.StockItem_Name;");
				Report.Database.Tables(1).SetDataSource(rs);
				Report.Database.Tables(2).SetDataSource(RSitem);
				//'Report.VerifyOnEveryPrint = True
				My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
				My.MyProject.Forms.frmReportShow.mReport = Report;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
			}
		}

		public static void report_Promotion()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset RSitem = default(ADODB.Recordset);
			bool ltype = false;
			//Dim Report As New cryPromotion
			//'ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryPromotion.rpt");
			ReportNone.Load("cryNoRecords.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();
			rs = modRecordSet.getRS(ref "SELECT Promotion.* From Promotion ORDER BY Promotion.Promotion_EndDate DESC , Promotion.Promotion_Name;");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			RSitem = modRecordSet.getRS(ref "SELECT PromotionItem.*, StockItem.StockItem_Name FROM PromotionItem INNER JOIN StockItem ON PromotionItem.PromotionItem_StockItemID = StockItem.StockItemID ORDER BY StockItem.StockItem_Name, PromotionItem.PromotionItem_Quantity;");
			if (RSitem.BOF | RSitem.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			Report.Database.Tables(1).SetDataSource(rs);
			Report.Database.Tables(2).SetDataSource(RSitem);
			//'Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();

		}

		public static void report_PromotionGRV()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset RSitem = default(ADODB.Recordset);
			bool ltype = false;
			//Dim Report As New cryPromotion
			//'ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryPromotion.rpt");
			ReportNone.Load("cryNoRecords.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();
			rs = modRecordSet.getRS(ref "SELECT GRVPromotion.* From GRVPromotion ORDER BY GRVPromotion.Promotion_EndDate DESC , GRVPromotion.Promotion_Name;");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			RSitem = modRecordSet.getRS(ref "SELECT GRVPromotionItem.*, StockItem.StockItem_Name FROM GRVPromotionItem INNER JOIN StockItem ON GRVPromotionItem.PromotionItem_StockItemID = StockItem.StockItemID ORDER BY StockItem.StockItem_Name, GRVPromotionItem.PromotionItem_Quantity;");
			if (RSitem.BOF | RSitem.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			Report.Database.Tables(1).SetDataSource(rs);
			Report.Database.Tables(2).SetDataSource(RSitem);
			//'Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}


		public static void report_DepositTake()
		{
			My.MyProject.Forms.frmStockTakeSnapshot.remoteSnapShot();
			System.Windows.Forms.Application.DoEvents();

			ADODB.Recordset rs = default(ADODB.Recordset);
			bool ltype = false;
			//Dim Report As New cryDepositTake
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryDepositTake.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtDate", Strings.Format(rs.Fields("Company_StockTakeDate").Value, "dd mmm, yyyy hh:mm"));
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			ltype = rs.Fields("Company_StockTakeQuantity").Value;
			rs.Close();
			if (ltype) {
				//Set rs = getRS("SELECT Deposit.Deposit_Name, IIf([StockTakeDeposit_DepositTypeID]=0,'Bottle','Crate') AS depositType, StockTakeDeposit.StockTakeDeposit_Quantity, StockTakeDeposit.StockTakeDeposit_WarehouseID, StockTakeDeposit.StockTakeDeposit_DepositID, StockTakeDeposit.StockTakeDeposit_DepositTypeID FROM Deposit INNER JOIN StockTakeDeposit ON Deposit.DepositID = StockTakeDeposit.StockTakeDeposit_DepositID Where (((StockTakeDeposit.StockTakeDeposit_WarehouseID) = 2)) ORDER BY Deposit.Deposit_Name, StockTakeDeposit.StockTakeDeposit_DepositTypeID;")
				rs = modRecordSet.getRS(ref "SELECT Deposit.Deposit_Name, IIf([StockTakeDeposit_DepositTypeID]=0,'Bottle','Crate') AS depositType, StockTakeDeposit.StockTakeDeposit_Quantity, StockTakeDeposit.StockTakeDeposit_WarehouseID, StockTakeDeposit.StockTakeDeposit_DepositID, StockTakeDeposit.StockTakeDeposit_DepositTypeID FROM Deposit INNER JOIN StockTakeDeposit ON Deposit.DepositID = StockTakeDeposit.StockTakeDeposit_DepositID Where (((StockTakeDeposit.StockTakeDeposit_WarehouseID) = 2) AND ((Deposit.Deposit_Disabled)=False)) ORDER BY Deposit.Deposit_Name, StockTakeDeposit.StockTakeDeposit_DepositTypeID;");
			} else {
				//Set rs = getRS("SELECT Deposit.Deposit_Name, IIf([StockTakeDeposit_DepositTypeID]=0,'Bottle','Crate') AS depositType, null AS StockTakeDeposit_Quantity, StockTakeDeposit.StockTakeDeposit_WarehouseID, StockTakeDeposit.StockTakeDeposit_DepositID, StockTakeDeposit.StockTakeDeposit_DepositTypeID FROM Deposit INNER JOIN StockTakeDeposit ON Deposit.DepositID = StockTakeDeposit.StockTakeDeposit_DepositID Where (((StockTakeDeposit.StockTakeDeposit_WarehouseID) = 2)) ORDER BY Deposit.Deposit_Name, StockTakeDeposit.StockTakeDeposit_DepositTypeID;")
				rs = modRecordSet.getRS(ref "SELECT Deposit.Deposit_Name, IIf([StockTakeDeposit_DepositTypeID]=0,'Bottle','Crate') AS depositType, null AS StockTakeDeposit_Quantity, StockTakeDeposit.StockTakeDeposit_WarehouseID, StockTakeDeposit.StockTakeDeposit_DepositID, StockTakeDeposit.StockTakeDeposit_DepositTypeID FROM Deposit INNER JOIN StockTakeDeposit ON Deposit.DepositID = StockTakeDeposit.StockTakeDeposit_DepositID Where (((StockTakeDeposit.StockTakeDeposit_WarehouseID) = 2) AND ((Deposit.Deposit_Disabled)=False)) ORDER BY Deposit.Deposit_Name, StockTakeDeposit.StockTakeDeposit_DepositTypeID;");
			}
			//'ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.SetDataSource(rs);
			My.MyProject.Forms.frmReportShow.Text = "Deposit Stock Take Sheets";
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		public static void report_PricingMatrix(ref int grpID)
		{
			//Public Sub report_PricingMatrix()
			ADODB.Recordset rs = default(ADODB.Recordset);
			bool ltype = false;
			int lID = 0;
			string sql = null;
			//Dim Report As New cryPricingMatrix
			//lID = frmPricingGroupList.getItem
			lID = grpID;
			//frmPricingGroupList.getItem
			//'ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryPricingMatrix.rpt");
			ReportNone.Load("cryNoRecords.rpt");
			if (lID) {
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
				rs = modRecordSet.getRS(ref "SELECT * FROM Company");
				Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
				rs.Close();
				sql = "SELECT theJoin.*, PricingGroupChannelLnk.* FROM (SELECT DISTINCT PricingGroup.PricingGroupID, PricingGroup.PricingGroup_Name, PackSize.PackSizeID, PackSize.PackSize_Name, ShrinkItem.ShrinkItem_Quantity, Channel.ChannelID, Channel.Channel_Name, Channel.Channel_Code FROM Channel, ShrinkItem INNER JOIN ((StockItem INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN PackSize ON StockItem.StockItem_PackSizeID = PackSize.PackSizeID) ON ShrinkItem.ShrinkItem_ShrinkID = StockItem.StockItem_ShrinkID ";
				sql = sql + "Where ((Channel.ChannelID <> 9) AND (PricingGroup.PricingGroupID = " + lID + ")) ";
				sql = sql + "ORDER BY PricingGroup.PricingGroup_Name, PackSize.PackSize_Name, ShrinkItem.ShrinkItem_Quantity) AS theJoin LEFT JOIN PricingGroupChannelLnk ON (theJoin.ChannelID = PricingGroupChannelLnk.PricingGroupChannelLnk_ChannelID) AND (theJoin.ShrinkItem_Quantity = PricingGroupChannelLnk.PricingGroupChannelLnk_Quantity) AND (theJoin.PackSizeID = PricingGroupChannelLnk.PricingGroupChannelLnk_PackSizeID) AND (theJoin.PricingGroupID = PricingGroupChannelLnk.PricingGroupChannelLnk_PricingGroupID) ORDER BY theJoin.PricingGroupID, theJoin.PackSizeID, theJoin.ShrinkItem_Quantity, theJoin.ChannelID;";

				rs = modRecordSet.getRS(ref sql);
				if (rs.BOF | rs.EOF) {
					ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
					ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
					My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
					My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
					My.MyProject.Forms.frmReportShow.mReport = ReportNone;
					My.MyProject.Forms.frmReportShow.sMode = "0";
					My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
					My.MyProject.Forms.frmReportShow.ShowDialog();
					return;
				}
				Report.SetDataSource(rs);
				Report.Database.Tables(1).SetDataSource(rs);
				//'Report.VerifyOnEveryPrint = True
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
				My.MyProject.Forms.frmReportShow.mReport = Report;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
			}
		}


		public static void report_PricingMatrixNew(ref int grpID)
		{
			//Public Sub report_PricingMatrix()
			ADODB.Recordset rs = default(ADODB.Recordset);
			bool ltype = false;
			int lID = 0;
			string sql = null;
			//Dim Report As New cryPricingMatrixNew
			//lID = frmPricingGroupList.getItem
			lID = grpID;
			//frmPricingGroupList.getItem
			//'ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryPricingMatrixNew.rpt");
			ReportNone.Load("cryNoRecords.rpt");
			if (lID) {
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
				rs = modRecordSet.getRS(ref "SELECT * FROM Company");
				Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
				rs.Close();
				//sql = "SELECT theJoin.*, PricingGroupChannelLnk.* FROM (SELECT DISTINCT PricingGroup.PricingGroupID, PricingGroup.PricingGroup_Name, PackSize.PackSizeID, PackSize.PackSize_Name, ShrinkItem.ShrinkItem_Quantity, Channel.ChannelID, Channel.Channel_Name, Channel.Channel_Code FROM Channel, ShrinkItem INNER JOIN ((StockItem INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN PackSize ON StockItem.StockItem_PackSizeID = PackSize.PackSizeID) ON ShrinkItem.ShrinkItem_ShrinkID = StockItem.StockItem_ShrinkID "
				//sql = sql & "Where ((Channel.ChannelID <> 9) AND (PricingGroup.PricingGroupID = " & lID & ")) "
				//sql = sql & "ORDER BY PricingGroup.PricingGroup_Name, PackSize.PackSize_Name, ShrinkItem.ShrinkItem_Quantity) AS theJoin LEFT JOIN PricingGroupChannelLnk ON (theJoin.ChannelID = PricingGroupChannelLnk.PricingGroupChannelLnk_ChannelID) AND (theJoin.ShrinkItem_Quantity = PricingGroupChannelLnk.PricingGroupChannelLnk_Quantity) AND (theJoin.PackSizeID = PricingGroupChannelLnk.PricingGroupChannelLnk_PackSizeID) AND (theJoin.PricingGroupID = PricingGroupChannelLnk.PricingGroupChannelLnk_PricingGroupID) ORDER BY theJoin.PricingGroupID, theJoin.PackSizeID, theJoin.ShrinkItem_Quantity, theJoin.ChannelID;"
				sql = "SELECT theJoin.*, PricingGroupChannelLnk.* FROM (SELECT DISTINCT PricingGroup.PricingGroupID, PricingGroup.PricingGroup_Name, Shrink.ShrinkID, Shrink.Shrink_Name, ShrinkItem.ShrinkItem_Quantity, Channel.ChannelID, Channel.Channel_Name, Channel.Channel_Code FROM Channel, ShrinkItem INNER JOIN ((StockItem INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Shrink ON StockItem.StockItem_ShrinkID = Shrink.ShrinkID) ON ShrinkItem.ShrinkItem_ShrinkID = StockItem.StockItem_ShrinkID ";
				sql = sql + "Where ((Channel.ChannelID <> 9) AND (PricingGroup.PricingGroupID = " + lID + ")) ";
				sql = sql + "ORDER BY PricingGroup.PricingGroup_Name, Shrink.Shrink_Name, ShrinkItem.ShrinkItem_Quantity) AS theJoin LEFT JOIN PricingGroupChannelLnk ON (theJoin.ChannelID = PricingGroupChannelLnk.PricingGroupChannelLnk_ChannelID) AND (theJoin.ShrinkItem_Quantity = PricingGroupChannelLnk.PricingGroupChannelLnk_Quantity) AND (theJoin.PricingGroupID = PricingGroupChannelLnk.PricingGroupChannelLnk_PricingGroupID) ORDER BY theJoin.PricingGroupID, theJoin.ShrinkID, theJoin.ShrinkItem_Quantity, theJoin.ChannelID;";

				rs = modRecordSet.getRS(ref sql);
				if (rs.BOF | rs.EOF) {
					ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
					ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
					My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
					My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
					My.MyProject.Forms.frmReportShow.mReport = ReportNone;
					My.MyProject.Forms.frmReportShow.sMode = "0";
					My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
					My.MyProject.Forms.frmReportShow.ShowDialog();
					return;
				}
				Report.SetDataSource(rs);
				Report.Database.Tables(1).SetDataSource(rs);
				//'Report.VerifyOnEveryPrint = True
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
				My.MyProject.Forms.frmReportShow.mReport = Report;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
			}
		}

		public static void report_PricingGroup()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			bool ltype = false;
			//Dim Report As New cryPricingGroup
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryPricingGroup.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName.", rs.Fields("Company_Name"));
			rs.Close();

			rs = modRecordSet.getRS(ref "SELECT * FROM Channel WHERE ChannelID <> 9 ORDER BY ChannelID");
			while (!(rs.EOF)) {
				switch (rs.Fields("ChannelID").Value) {
					case 1:
						Report.SetParameterValue("txtChannel1", rs.Fields("Channel_Code"));
						break;
					case 2:
						Report.SetParameterValue("txtChannel2", rs.Fields("Channel_Code"));
						break;
					case 3:
						Report.SetParameterValue("txtChannel3", rs.Fields("Channel_Code"));
						break;
					case 4:
						Report.SetParameterValue("txtChannel4", rs.Fields("Channel_Code"));
						break;
					case 5:
						Report.SetParameterValue("txtChannel5", rs.Fields("Channel_Code"));
						break;
					case 6:
						Report.SetParameterValue("txtChannel6", rs.Fields("Channel_Code"));
						break;
					case 7:
						Report.SetParameterValue("txtChannel7", rs.Fields("Channel_Code"));
						break;
					case 8:
						Report.SetParameterValue("txtChannel8", rs.Fields("Channel_Code"));
						break;
				}
				rs.moveNext();
			}

			rs.Close();
			rs = modRecordSet.getRS(ref "SELECT * From PricingGroup ORDER BY PricingGroup_Name");
			//'ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.SetDataSource(rs);
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();

		}

		public static void report_Sets()
		{
			string sql = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset RSitem = default(ADODB.Recordset);
			bool ltype = false;
			//Dim Report As New crySets
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("crySets.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();

			rs = modRecordSet.getRS(ref "SELECT * FROM Channel WHERE ChannelID <> 9 ORDER BY ChannelID");
			while (!(rs.EOF)) {
				switch (rs.Fields("ChannelID").Value) {
					case 1:
						Report.SetParameterValue("txtChannel1", rs.Fields("Channel_Code"));
						break;
					case 2:
						Report.SetParameterValue("txtChannel2", rs.Fields("Channel_Code"));
						break;
					case 3:
						Report.SetParameterValue("txtChannel3", rs.Fields("Channel_Code"));
						break;
					case 4:
						Report.SetParameterValue("txtChannel4", rs.Fields("Channel_Code"));
						break;
					case 5:
						Report.SetParameterValue("txtChannel5", rs.Fields("Channel_Code"));
						break;
					case 6:
						Report.SetParameterValue("txtChannel6", rs.Fields("Channel_Code"));
						break;
					case 7:
						Report.SetParameterValue("txtChannel7", rs.Fields("Channel_Code"));
						break;
					case 8:
						Report.SetParameterValue("txtChannel8", rs.Fields("Channel_Code"));
						break;
				}
				rs.moveNext();
			}

			rs.Close();
			sql = "SELECT Set.*, Deposit.Deposit_Name FROM Deposit INNER JOIN [Set] ON Deposit.DepositID = Set.Set_DepositID;";
			rs = modRecordSet.getRS(ref sql);
			//'ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			RSitem = modRecordSet.getRS(ref "SELECT SetItem.*, StockItem.* FROM StockItem INNER JOIN SetItem ON StockItem.StockItemID = SetItem.SetItem_StockItemID;");
			Report.Database.Tables(1).SetDataSource(rs);
			Report.Database.Tables(2).SetDataSource(RSitem);
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();

		}
		public static void report_StockItemPropped()
		{
			string sql = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			bool ltype = false;
			//Dim Report As New cryPricingPropped
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryPricingPropped.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();

			rs = modRecordSet.getRS(ref "SELECT * FROM Channel WHERE ChannelID <> 9 ORDER BY ChannelID");
			while (!(rs.EOF)) {
				switch (rs.Fields("ChannelID").Value) {
					case 1:
						Report.SetParameterValue("txtChannel1", rs.Fields("Channel_Code"));
						break;
					case 2:
						Report.SetParameterValue("txtChannel2", rs.Fields("Channel_Code"));
						break;
					case 3:
						Report.SetParameterValue("txtChannel3", rs.Fields("Channel_Code"));
						break;
					case 4:
						Report.SetParameterValue("txtChannel4", rs.Fields("Channel_Code"));
						break;
					case 5:
						Report.SetParameterValue("txtChannel5", rs.Fields("Channel_Code"));
						break;
					case 6:
						Report.SetParameterValue("txtChannel6", rs.Fields("Channel_Code"));
						break;
					case 7:
						Report.SetParameterValue("txtChannel7", rs.Fields("Channel_Code"));
						break;
					case 8:
						Report.SetParameterValue("txtChannel8", rs.Fields("Channel_Code"));
						break;
				}
				rs.moveNext();
			}

			rs.Close();
			sql = "TRANSFORM Sum(DISPLAY_PricingProp.PropChannelLnk_Markup) AS SumOfPropChannelLnk_Markup SELECT DISPLAY_PricingProp.StockItem_Name, DISPLAY_PricingProp.ShrinkItem_Quantity, Sum(DISPLAY_PricingProp.PropChannelLnk_Markup) AS [Total Of PropChannelLnk_Markup] FROM (SELECT DISTINCT TOP 100 PERCENT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.ShrinkItem_Quantity, StockItem.ChannelID, PropChannelLnk.PropChannelLnk_Markup FROM ([SELECT TOP 100 PERCENT StockItem.StockItemID, StockItem.StockItem_Name, Channel.ChannelID, ShrinkItem.ShrinkItem_Quantity FROM StockItem INNER JOIN ShrinkItem ON StockItem.StockItem_ShrinkID = ShrinkItem.ShrinkItem_ShrinkID ,Channel ";
			sql = sql + " WHERE (Channel.ChannelID <> 9)]. AS StockItem LEFT JOIN PropChannelLnk ON (StockItem.ShrinkItem_Quantity = PropChannelLnk.PropChannelLnk_Quantity) AND (StockItem.ChannelID = PropChannelLnk.PropChannelLnk_ChannelID) AND (StockItem.StockItemID = PropChannelLnk.PropChannelLnk_StockItemID)) INNER JOIN PropChannelLnk AS PropChannelLnk_1 ON (PropChannelLnk_1.PropChannelLnk_Quantity = StockItem.ShrinkItem_Quantity) AND (StockItem.StockItemID = PropChannelLnk_1.PropChannelLnk_StockItemID) ORDER BY StockItem.StockItem_Name, StockItem.ShrinkItem_Quantity, StockItem.ChannelID) DISPLAY_PricingProp GROUP BY DISPLAY_PricingProp.StockItem_Name, DISPLAY_PricingProp.ShrinkItem_Quantity PIVOT DISPLAY_PricingProp.ChannelID;";

			rs = modRecordSet.getRS(ref sql);
			//'ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			Report.SetDataSource(rs);
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		public static void report_StockItemOverride()
		{
			string sql = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			bool ltype = false;
			//Dim Report As New cryPricingOverrideRpt
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryPricingOverrideRpt.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();

			rs = modRecordSet.getRS(ref "SELECT * FROM Channel WHERE ChannelID <> 9 ORDER BY ChannelID");
			while (!(rs.EOF)) {
				switch (rs.Fields("ChannelID").Value) {
					case 1:
						Report.SetParameterValue("txtChannel1", rs.Fields("Channel_Code"));
						break;
					case 2:
						Report.SetParameterValue("txtChannel2", rs.Fields("Channel_Code"));
						break;
					case 3:
						Report.SetParameterValue("txtChannel3", rs.Fields("Channel_Code"));
						break;
					case 4:
						Report.SetParameterValue("txtChannel4", rs.Fields("Channel_Code"));
						break;
					case 5:
						Report.SetParameterValue("txtChannel5", rs.Fields("Channel_Code"));
						break;
					case 6:
						Report.SetParameterValue("txtChannel6", rs.Fields("Channel_Code"));
						break;
					case 7:
						Report.SetParameterValue("txtChannel7", rs.Fields("Channel_Code"));
						break;
					case 8:
						Report.SetParameterValue("txtChannel8", rs.Fields("Channel_Code"));
						break;
				}
				rs.moveNext();
			}

			rs.Close();
			sql = "TRANSFORM Sum(DISPLAY_PricingOverride.PriceChannelLnk_Price) AS SumOfPriceChannelLnk_Price SELECT DISPLAY_PricingOverride.StockItem_Name, DISPLAY_PricingOverride.ShrinkItem_Quantity, Sum(DISPLAY_PricingOverride.PriceChannelLnk_Price) AS [Total Of PriceChannelLnk_Price] FROM (SELECT DISTINCT TOP 100 PERCENT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.ShrinkItem_Quantity, StockItem.ChannelID, PriceChannelLnk.PriceChannelLnk_Price FROM ([SELECT TOP 100 PERCENT StockItem.StockItemID, StockItem.StockItem_Name, Channel.ChannelID, ShrinkItem.ShrinkItem_Quantity FROM StockItem INNER JOIN ShrinkItem ON StockItem.StockItem_ShrinkID = ShrinkItem.ShrinkItem_ShrinkID ,Channel ";
			sql = sql + " WHERE (Channel.ChannelID <> 9)]. AS StockItem LEFT JOIN PriceChannelLnk ON (StockItem.ShrinkItem_Quantity = PriceChannelLnk.PriceChannelLnk_Quantity) AND (StockItem.ChannelID = PriceChannelLnk.PriceChannelLnk_ChannelID) AND (StockItem.StockItemID = PriceChannelLnk.PriceChannelLnk_StockItemID)) INNER JOIN PriceChannelLnk AS PriceChannelLnk_1 ON (PriceChannelLnk_1.PriceChannelLnk_Quantity = StockItem.ShrinkItem_Quantity) AND (StockItem.StockItemID = PriceChannelLnk_1.PriceChannelLnk_StockItemID) ORDER BY StockItem.StockItem_Name, StockItem.ShrinkItem_Quantity, StockItem.ChannelID) DISPLAY_PricingOverride GROUP BY DISPLAY_PricingOverride.StockItem_Name, DISPLAY_PricingOverride.ShrinkItem_Quantity PIVOT DISPLAY_PricingOverride.ChannelID;";

			rs = modRecordSet.getRS(ref sql);
			//'ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			Report.SetDataSource(rs);
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}
		public static void updatePricingBySystem()
		{
			short x = 0;
			string sql = null;

			modRecordSet.cnnDB.Execute("DELETE Catalogue.*, StockItem.StockItemID FROM StockItem RIGHT JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID WHERE (((StockItem.StockItemID) Is Null));");

			modRecordSet.cnnDB.Execute("INSERT INTO Catalogue ( Catalogue_StockItemID, Catalogue_Quantity, Catalogue_Barcode, Catalogue_Deposit, Catalogue_Content, Catalogue_Disabled ) SELECT theJoin.StockItemID, theJoin.ShrinkItem_Quantity, 'CODE' AS Expr1, 0 AS deposit, 0 AS content, 0 AS disabled FROM systemStockItemPricing INNER JOIN ([SELECT StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity FROM ShrinkItem INNER JOIN StockItem ON ShrinkItem.ShrinkItem_ShrinkID = StockItem.StockItem_ShrinkID]. AS theJoin LEFT JOIN Catalogue ON (theJoin.ShrinkItem_Quantity = Catalogue.Catalogue_Quantity) AND (theJoin.StockItemID = Catalogue.Catalogue_StockItemID)) ON systemStockItemPricing.systemStockItemPricing = theJoin.StockItemID WHERE (((Catalogue.Catalogue_StockItemID) Is Null));");
			modRecordSet.cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (StockItem INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET Catalogue.Catalogue_Content = [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ActualCost];");

			modRecordSet.cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN ((Catalogue INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET Catalogue.Catalogue_Deposit = [Catalogue_Quantity]*[Deposit_UnitCost];");
			modRecordSet.cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN ((Catalogue INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET Catalogue.Catalogue_Deposit = [Catalogue_Deposit]+[Deposit_CaseCost] WHERE (((Deposit.Deposit_CaseCost)<>0));");

			sql = "INSERT INTO CatalogueChannelLnk ( CatalogueChannelLnk_StockItemID, CatalogueChannelLnk_Quantity, CatalogueChannelLnk_ChannelID, CatalogueChannelLnk_Markup, CatalogueChannelLnk_Price, CatalogueChannelLnk_PriceOriginal, CatalogueChannelLnk_PriceSystem, CatalogueChannelLnk_Location ) ";
			sql = sql + "SELECT catalogue.Catalogue_StockItemID, catalogue.Catalogue_Quantity, catalogue.ChannelID, 0 AS markup, 0 AS price, 0 AS original, 0 AS system, 0 AS location FROM ([SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, Channel.ChannelID FROM Catalogue ,Channel]. AS catalogue LEFT JOIN CatalogueChannelLnk ON (catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (catalogue.ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)) INNER JOIN systemStockItemPricing ON catalogue.Catalogue_StockItemID = systemStockItemPricing.systemStockItemPricing WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) Is Null));";
			modRecordSet.cnnDB.Execute(sql);
			for (x = 1; x <= 8; x++) {
				modRecordSet.cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (PricingGroup INNER JOIN (StockItem INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) ON PricingGroup.PricingGroupID = StockItem.StockItem_PricingGroupID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Markup = [PricingGroup]![PricingGroup_Unit" + x + "], CatalogueChannelLnk.CatalogueChannelLnk_Location = 1 WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)=1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=" + x + "));");
				modRecordSet.cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (PricingGroup INNER JOIN (StockItem INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) ON PricingGroup.PricingGroupID = StockItem.StockItem_PricingGroupID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Markup = [PricingGroup]![PricingGroup_Case" + x + "], CatalogueChannelLnk.CatalogueChannelLnk_Location = 1 WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)<>1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=" + x + "));");
			}
			modRecordSet.cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN ((StockItem INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) INNER JOIN PricingGroupChannelLnk ON (CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = PricingGroupChannelLnk.PricingGroupChannelLnk_ChannelID) AND (StockItem.StockItem_PackSizeID = PricingGroupChannelLnk.PricingGroupChannelLnk_PackSizeID)) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Markup = [PricingGroupChannelLnk]![PricingGroupChannelLnk_Markup], CatalogueChannelLnk.CatalogueChannelLnk_Location = 2;");
			modRecordSet.cnnDB.Execute("UPDATE PropChannelLnk INNER JOIN CatalogueChannelLnk ON (PropChannelLnk.PropChannelLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (PropChannelLnk.PropChannelLnk_ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) SET CatalogueChannelLnk.CatalogueChannelLnk_Markup = [PropChannelLnk]![PropChannelLnk_Markup], CatalogueChannelLnk.CatalogueChannelLnk_Location = 3;");
			modRecordSet.cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (Catalogue INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)) ON systemStockItemPricing.systemStockItemPricing = Catalogue.Catalogue_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_PriceOriginal = [Catalogue_Content]*(1+[CatalogueChannelLnk_Markup]/100)+[Catalogue_Deposit];");
			//Add VAT
			modRecordSet.cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN ((StockItem INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_PriceOriginal = [CatalogueChannelLnk_PriceOriginal]*(1+[Vat_Amount]/100);");
			//round cents Up
			modRecordSet.cnnDB.Execute("UPDATE CatalogueChannelLnk INNER JOIN systemStockItemPricing ON CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = systemStockItemPricing.systemStockItemPricing SET CatalogueChannelLnk.CatalogueChannelLnk_Price = round([CatalogueChannelLnk_PriceOriginal]+0.0049,1);");
			//Do rouding
			modRecordSet.cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN ((StockItem INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Price = round([CatalogueChannelLnk_PriceOriginal]+0.49,0)-([PricingGroup_RemoveCents]/100) WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_Price)>[PricingGroup]![PricingGroup_RoundAfter]) AND (([CatalogueChannelLnk_PriceOriginal]*100 Mod 100)>[PricingGroup]![PricingGroup_RoundAfter]));");
			modRecordSet.cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN ((StockItem INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Price = round([CatalogueChannelLnk_PriceOriginal]-0.49,0)-([PricingGroup_RemoveCents]/100) WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_Price)>[PricingGroup]![PricingGroup_RoundAfter]) AND (([CatalogueChannelLnk_PriceOriginal]*100 Mod 100)<=[PricingGroup]![PricingGroup_RoundAfter]));");
			//update system price
			modRecordSet.cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN CatalogueChannelLnk ON systemStockItemPricing.systemStockItemPricing = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_PriceSystem = [CatalogueChannelLnk]![CatalogueChannelLnk_Price];");

			//do Price Override
			modRecordSet.cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (PriceChannelLnk INNER JOIN CatalogueChannelLnk ON (PriceChannelLnk.PriceChannelLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (PriceChannelLnk.PriceChannelLnk_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity)) ON systemStockItemPricing.systemStockItemPricing = PriceChannelLnk.PriceChannelLnk_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Price = [PriceChannelLnk]![PriceChannelLnk_Price], CatalogueChannelLnk.CatalogueChannelLnk_Location = 4;");

			//Do Channel 9 Actual Cost
			modRecordSet.cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (CatalogueChannelLnk INNER JOIN StockItem ON CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = StockItem.StockItemID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_PriceOriginal = [CatalogueChannelLnk_Quantity]/[StockItem_Quantity]*[StockItem_ActualCost] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=9));");
			modRecordSet.cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (CatalogueChannelLnk INNER JOIN Catalogue ON CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = Catalogue.Catalogue_StockItemID) ON systemStockItemPricing.systemStockItemPricing = Catalogue.Catalogue_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_PriceOriginal = [CatalogueChannelLnk]![CatalogueChannelLnk_PriceOriginal]+[Catalogue]![Catalogue_Deposit] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=9));");
			modRecordSet.cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN ((CatalogueChannelLnk INNER JOIN StockItem ON CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = StockItem.StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_PriceOriginal = [CatalogueChannelLnk_PriceOriginal]*(1+[Vat_Amount]/100) WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=9));");
			modRecordSet.cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN ((CatalogueChannelLnk INNER JOIN StockItem ON CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = StockItem.StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Price = round([CatalogueChannelLnk_PriceOriginal]+0.049,1) WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=9));");
			modRecordSet.cnnDB.Execute("UPDATE CatalogueChannelLnk INNER JOIN systemStockItemPricing ON CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = systemStockItemPricing.systemStockItemPricing SET CatalogueChannelLnk.CatalogueChannelLnk_PriceSystem = [CatalogueChannelLnk]![CatalogueChannelLnk_Price] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=9));");

			modRecordSet.cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (Channel INNER JOIN CatalogueChannelLnk ON Channel.ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) ON systemStockItemPricing.systemStockItemPricing = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Price = round([CatalogueChannelLnk_PriceOriginal]+0.049,1) WHERE (((Channel.Channel_NoPricing)<>0) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)<>9));");

			//Shrink Increment
			modRecordSet.cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (CatalogueChannelLnk AS CatalogueChannelLnk_1 INNER JOIN (Channel INNER JOIN CatalogueChannelLnk ON Channel.ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) ON (CatalogueChannelLnk_1.CatalogueChannelLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (CatalogueChannelLnk_1.CatalogueChannelLnk_ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)) ON systemStockItemPricing.systemStockItemPricing = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_PriceOriginal = [CatalogueChannelLnk_1]![CatalogueChannelLnk_Price]*[CatalogueChannelLnk]![CatalogueChannelLnk_Quantity] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)<>9) AND ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)<>1) AND ((CatalogueChannelLnk_1.CatalogueChannelLnk_Quantity)=1) AND ((Channel.Channel_ShrinkIncrement)<>0));");
			modRecordSet.cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (Channel INNER JOIN CatalogueChannelLnk ON Channel.ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) ON systemStockItemPricing.systemStockItemPricing = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Price = [CatalogueChannelLnk]![CatalogueChannelLnk_PriceOriginal], CatalogueChannelLnk.CatalogueChannelLnk_PriceSystem = [CatalogueChannelLnk]![CatalogueChannelLnk_PriceOriginal] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)<>9) AND ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)<>1) AND ((Channel.Channel_ShrinkIncrement)<>0));");
		}

		public static void buildBarcodes(ref int id = 0)
		{
			short x = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			string lCode = null;
			string lID = null;
			string lQuantity = null;
			bool changeCode = false;

			if (id == 0) {
				return;
				modRecordSet.cnnDB.Execute("UPDATE Catalogue SET Catalogue.Catalogue_Barcode = \"0\" WHERE (((IsNumeric([Catalogue_Barcode]))='0'));");

				for (x = 1; x <= 15; x++) {
					modRecordSet.cnnDB.Execute("UPDATE Catalogue SET Catalogue.Catalogue_Barcode = Mid([Catalogue_Barcode],2,999) WHERE (((Left([Catalogue_Barcode],1))=\"0\"));");
				}
				rs = modRecordSet.getRS(ref "SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, Catalogue.Catalogue_Barcode From Catalogue;");
				//        Set rs = getRS("SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, Catalogue.Catalogue_Barcode From Catalogue WHERE Catalogue.Catalogue_Barcode = '0';")
			} else {
				rs = modRecordSet.getRS(ref "SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, Catalogue.Catalogue_Barcode From Catalogue WHERE (((Catalogue.Catalogue_StockItemID)=" + id + "));");
			}
			if (rs.RecordCount) {
				rs.MoveFirst();
				while (!(rs.EOF)) {
					changeCode = true;
					lCode = rs.Fields("Catalogue_Barcode").Value;
					if (doCheckSum(ref lCode)) {
						if (Strings.Len(lCode) > 5) {
							changeCode = false;
						}
					}
					if (changeCode) {
						lID = rs.Fields("Catalogue_StockItemID").Value;
						lQuantity = rs.Fields("Catalogue_Quantity").Value;
						lCode = lID + "0" + lQuantity;
						lCode = "888" + Strings.Right(new string("0", 9) + lCode + "0", 9);
						lCode = addCheckSum(ref lCode);
						modRecordSet.cnnDB.Execute("UPDATE Catalogue SET Catalogue_Barcode = '" + Strings.Replace(lCode, "'", "''") + "' WHERE Catalogue_StockItemID = " + lID + " AND Catalogue_Quantity = " + lQuantity);
					}
					rs.moveNext();
				}
			}
		}

		public static string buildItemBarcode(ref int id, ref short quantity)
		{
			string lCode = null;
			lCode = id + "0" + quantity;
			lCode = "888" + Strings.Right(new string("0", 9) + lCode + "0", 9);
			lCode = addCheckSum(ref lCode);
			return lCode;

		}

		public static string addCheckSum(ref string Value)
		{
			string functionReturnValue = null;
			short lAmount = 0;
			string code = null;
			short i = 0;

			if (Information.IsNumeric(Value)) {
				lAmount = 0;
				for (i = 1; i <= Strings.Len(Value); i++) {
					code = Strings.Left(Value, i);
					code = Strings.Right(code, 1);
					if (i % 2) {
						lAmount = lAmount + Convert.ToInt16(code);
					} else {
						lAmount = lAmount + Convert.ToInt16(code) * 3;
					}
				}
				lAmount = 10 - (lAmount % 10);
				if (lAmount == 10)
					lAmount = 0;
				functionReturnValue = Value + lAmount;
			} else {
				functionReturnValue = Value;
			}
			return functionReturnValue;
		}

		private static string doCheckSum(ref string Value)
		{
			string functionReturnValue = null;
			short lAmount = 0;
			string code = null;
			short i = 0;

			if (Information.IsNumeric(Value)) {
				lAmount = 0;
				for (i = 1; i <= Strings.Len(Value) - 1; i++) {
					code = Strings.Left(Value, i);
					code = Strings.Right(code, 1);
					if (i % 2) {
						lAmount = lAmount + Convert.ToInt16(code);
					} else {
						lAmount = lAmount + Convert.ToInt16(code) * 3;
					}
				}
				lAmount = 10 - (lAmount % 10);
				if (lAmount == 10)
					lAmount = 0;
				functionReturnValue = lAmount == Convert.ToInt16(Strings.Right(Value, 1));
			} else {
				functionReturnValue = false;
			}
			return functionReturnValue;
		}


		private static void report_SupplierTransactions()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset RSitem = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New crySupplierTransactions
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("crySupplierTransactions.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();
			rs = modReport.getRSreport(ref "SELECT * FROM Supplier");

			RSitem = modReport.getRSreport(ref "SELECT SupplierTransaction.* From SupplierTransaction Where (((SupplierTransaction.SupplierTransaction_TransactionTypeID) = 2)) ORDER BY SupplierTransaction.SupplierTransaction_DayEndID, SupplierTransaction.SupplierTransactionID;");
			//ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (RSitem.BOF | RSitem.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			Report.Database.Tables(1).SetDataSource(rs);
			Report.Database.Tables(2).SetDataSource(RSitem);
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		private static void report_CustomerMovement()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryCustomerMovement
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryCustomer.Movement.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();
			//Set rs = getRSreport("SELECT aCustomer.Customer_InvoiceName, CustomerTransaction.CustomerTransaction_PersonName, DayEnd.DayEnd_Date, Sale.Sale_DatePOS, CustomerTransaction.CustomerTransaction_TransactionTypeID, Sale.Sale_Total, IIf([CustomerTransaction_TransactionTypeID]=2,[Sale_Total],Null) AS purchase, IIf([CustomerTransaction_TransactionTypeID]<>2,0-[Sale_Total],Null) AS payment, IIf([CustomerTransaction_TransactionTypeID]=2,[Sale_Total],0-[Sale_Total]) AS total FROM ((aCustomer INNER JOIN CustomerTransaction ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) INNER JOIN DayEnd ON CustomerTransaction.CustomerTransaction_DayEndID = DayEnd.DayEndID ORDER BY aCustomer.Customer_InvoiceName, CustomerTransaction.CustomerTransactionID;")
			//changed to aCustomer1 from aCustomer cuz it was not loading all the data of customers   Set rs = getRSreport("SELECT aCustomer.Customer_InvoiceName, CustomerTransaction.CustomerTransaction_PersonName, DayEnd.DayEnd_Date, Sale.Sale_DatePOS, CustomerTransaction.CustomerTransaction_TransactionTypeID, IIf([CustomerTransaction_TransactionTypeID]=8,[CustomerTransaction_Amount],IIf([CustomerTransaction_TransactionTypeID]<>2,0-[Sale_Total],Null)) AS payment, IIf([CustomerTransaction_TransactionTypeID]=2,[Sale_Total],Null) AS purchase, IIf([CustomerTransaction_TransactionTypeID]=2,[Sale_Total],0-[Sale_Total]) AS total FROM ((aCustomer INNER JOIN CustomerTransaction ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) INNER JOIN DayEnd ON CustomerTransaction.CustomerTransaction_DayEndID = DayEnd.DayEndID ORDER BY aCustomer.Customer_InvoiceName, CustomerTransaction.CustomerTransactionID;")
			rs = modReport.getRSreport(ref "SELECT aCustomer1.Customer_InvoiceName, CustomerTransaction.CustomerTransaction_PersonName, DayEnd.DayEnd_Date, Sale.Sale_DatePOS, CustomerTransaction.CustomerTransaction_TransactionTypeID, IIf([CustomerTransaction_TransactionTypeID]=8,[CustomerTransaction_Amount],IIf([CustomerTransaction_TransactionTypeID]<>2,0-[Sale_Total],Null)) AS payment, IIf([CustomerTransaction_TransactionTypeID]=2,[Sale_Total],Null) AS purchase, IIf([CustomerTransaction_TransactionTypeID]=2,[Sale_Total],0-[Sale_Total]) AS total FROM ((aCustomer1 INNER JOIN CustomerTransaction ON aCustomer1.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) INNER JOIN DayEnd ON CustomerTransaction.CustomerTransaction_DayEndID = DayEnd.DayEndID ORDER BY aCustomer1.Customer_InvoiceName, CustomerTransaction.CustomerTransactionID;");
			//Set rs = getRSreport("SELECT aCustomer1.Customer_InvoiceName,  aCustomerTransaction.CustomerTransaction_PersonName, DayEnd.DayEnd_Date, Sale.Sale_DatePOS, aCustomerTransaction.CustomerTransaction_TransactionTypeID, IIf([CustomerTransaction_TransactionTypeID]=8,[CustomerTransaction_Amount],IIf([CustomerTransaction_TransactionTypeID]<>2,0-[Sale_Total],Null)) AS payment, IIf([CustomerTransaction_TransactionTypeID]=2,[Sale_Total],Null) AS purchase, IIf([CustomerTransaction_TransactionTypeID]=2,[Sale_Total],0-[Sale_Total]) AS total FROM ((aCustomer1 INNER JOIN aCustomerTransaction ON aCustomer1.CustomerID = aCustomerTransaction.CustomerTransaction_CustomerID) INNER JOIN Sale ON aCustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) INNER JOIN DayEnd ON aCustomerTransaction.CustomerTransaction_DayEndID = DayEnd.DayEndID ORDER BY aCustomer1.Customer_InvoiceName, aCustomerTransaction.CustomerTransactionID;")
			//ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.Database.Tables(1).SetDataSource(rs);
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		private static void report_CustomerMovementCD()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryCustomerMovementCD
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryCustomerMovementCD.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();
			//Set rs = getRSreport("SELECT aCustomer.Customer_InvoiceName, CustomerTransaction.CustomerTransaction_PersonName, DayEnd.DayEnd_Date, Sale.Sale_DatePOS, CustomerTransaction.CustomerTransaction_TransactionTypeID, Sale.Sale_Total, IIf([CustomerTransaction_TransactionTypeID]=2,[Sale_Total],Null) AS purchase, IIf([CustomerTransaction_TransactionTypeID]<>2,0-[Sale_Total],Null) AS payment, IIf([CustomerTransaction_TransactionTypeID]=2,[Sale_Total],0-[Sale_Total]) AS total FROM ((aCustomer INNER JOIN CustomerTransaction ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) INNER JOIN DayEnd ON CustomerTransaction.CustomerTransaction_DayEndID = DayEnd.DayEndID ORDER BY aCustomer.Customer_InvoiceName, CustomerTransaction.CustomerTransactionID;")
			//changed to aCustomer1 from aCustomer cuz it was not loading all the data of customers   Set rs = getRSreport("SELECT aCustomer.Customer_InvoiceName, CustomerTransaction.CustomerTransaction_PersonName, DayEnd.DayEnd_Date, Sale.Sale_DatePOS, CustomerTransaction.CustomerTransaction_TransactionTypeID, IIf([CustomerTransaction_TransactionTypeID]=8,[CustomerTransaction_Amount],IIf([CustomerTransaction_TransactionTypeID]<>2,0-[Sale_Total],Null)) AS payment, IIf([CustomerTransaction_TransactionTypeID]=2,[Sale_Total],Null) AS purchase, IIf([CustomerTransaction_TransactionTypeID]=2,[Sale_Total],0-[Sale_Total]) AS total FROM ((aCustomer INNER JOIN CustomerTransaction ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) INNER JOIN DayEnd ON CustomerTransaction.CustomerTransaction_DayEndID = DayEnd.DayEndID ORDER BY aCustomer.Customer_InvoiceName, CustomerTransaction.CustomerTransactionID;")
			sql = "SELECT aCustomer1.Customer_InvoiceName, CustomerTransaction.CustomerTransaction_PersonName, DayEnd.DayEnd_Date, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_TransactionTypeID, IIf([CustomerTransaction_TransactionTypeID]=3,[CustomerTransaction_Amount],0) AS ePay, IIf([CustomerTransaction_TransactionTypeID]=4,[CustomerTransaction_Amount],0) AS Debit, IIf([CustomerTransaction_TransactionTypeID]=5,[CustomerTransaction_Amount],0) AS Credit, (ePay+Debit+Credit) AS total";
			sql = sql + " FROM (aCustomer1 INNER JOIN CustomerTransaction ON aCustomer1.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) INNER JOIN DayEnd ON CustomerTransaction.CustomerTransaction_DayEndID = DayEnd.DayEndID Where (((CustomerTransaction.CustomerTransaction_TransactionTypeID) = 3)) Or (((CustomerTransaction.CustomerTransaction_TransactionTypeID) = 4)) Or (((CustomerTransaction.CustomerTransaction_TransactionTypeID) = 5)) ORDER BY aCustomer1.Customer_InvoiceName, CustomerTransaction.CustomerTransactionID;";
			rs = modReport.getRSreport(ref sql);
			//ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.Database.Tables(1).SetDataSource(rs);
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}


		private static void report_StockMovementByDay()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsChange = default(ADODB.Recordset);

			string sql = null;
			//Dim Report As New cryStockMovementByDay
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryStockMovementByDay.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();
			rs = modReport.getRSreport(ref "SELECT DayEnd.DayEndID, DayEnd.DayEnd_Date, Sum([DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk_ListCost]-[DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost]-[DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]+[DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost]) AS total, Sum([DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk_ListCost]) AS opening, Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost]) AS sales, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS shrink, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost]) AS grv FROM DayEndStockItemLnk INNER JOIN DayEnd ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = DayEnd.DayEndID GROUP BY Dayend.DayEndID, DayEnd.DayEnd_Date ORDER BY DayEnd.DayEnd_Date;");
			//UPGRADE_ISSUE: cryNoRecords object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
			//ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			//    Set rsChange = getRSreport("SELECT DayEndStockItemLnk.DayEndStockItemLnk_DayEndID, Sum(([DayEndStockItemLnk]![DayEndStockItemLnk_ListCost]-[DayEndStockItemLnkfrom]![DayEndStockItemLnk_ListCost])*[DayEndStockItemLnkfrom]![DayEndStockItemLnk_Quantity]) AS totalProfit FROM [SELECT DayEndStockItemLnkFirst.* From DayEndStockItemLnkFirst Union SELECT DayEndStockItemLnk.* From DayEndStockItemLnk ]. AS dayendStockItemLnkFrom INNER JOIN DayEndStockItemLnk ON dayendStockItemLnkFrom.DayEndStockItemLnk_StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID Where (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) = [DayEndStockItemLnkfrom]![DayEndStockItemLnk_DayEndID] + 1)) GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_DayEndID;")
			// fixed err COLs IN UNION QRY DONOT MATCH  Set rsChange = getRSreport("SELECT dayendStockItemLnkFrom.DayEndStockItemLnk_DayEndID, Sum(([DayEndStockItemLnk]![DayEndStockItemLnk_ListCost]-[DayEndStockItemLnkfrom]![DayEndStockItemLnk_ListCost])*[DayEndStockItemLnk]![DayEndStockItemLnk_Quantity]) AS totalProfit FROM (SELECT * FROM DayEndStockITemLnk Union SELECT [Report_DayEndEndID]+1 AS Expr1, aStockItem.StockItemID, 0 AS opening, 0 AS sales, 0 AS shrink, 0 AS grv, 0 AS expr3, 0 AS expr2, 0 AS listCost,0 as actualCost FROM Report, aStockItem) AS dayendStockitemLnk INNER JOIN (SELECT DayEndStockItemLnkFirst.* From DayEndStockItemLnkFirst Union SELECT DayEndStockItemLnk.* From DayEndStockItemLnk ) AS dayendStockItemLnkFrom ON dayendStockitemLnk.DayEndStockItemLnk_StockItemID = dayendStockItemLnkFrom.DayEndStockItemLnk_StockItemID Where (((dayendStockitemLnk.DayEndStockItemLnk_DayEndID) = [dayendStockItemLnkFrom]![DayEndStockItemLnk_DayEndID] + 1)) GROUP BY dayendStockItemLnkFrom.DayEndStockItemLnk_DayEndID;")
			rsChange = modReport.getRSreport(ref "SELECT dayendStockItemLnkFrom.DayEndStockItemLnk_DayEndID, Sum(([DayEndStockItemLnk]![DayEndStockItemLnk_ListCost]-[DayEndStockItemLnkfrom]![DayEndStockItemLnk_ListCost])*[DayEndStockItemLnk]![DayEndStockItemLnk_Quantity]) AS totalProfit FROM (SELECT * FROM DayEndStockITemLnk Union SELECT [Report_DayEndEndID]+1 AS Expr1, aStockItem.StockItemID, 0 AS opening, 0 AS sales, 0 AS shrink, 0 AS grv, 0 AS expr3, 0 AS expr2, 0 AS listCost,0 as actualCost, 2 as Warehouse FROM Report, aStockItem) AS dayendStockitemLnk INNER JOIN (SELECT DayEndStockItemLnkFirst.* From DayEndStockItemLnkFirst Union SELECT DayEndStockItemLnk.* From DayEndStockItemLnk ) AS dayendStockItemLnkFrom ON dayendStockitemLnk.DayEndStockItemLnk_StockItemID = dayendStockItemLnkFrom.DayEndStockItemLnk_StockItemID Where (((dayendStockitemLnk.DayEndStockItemLnk_DayEndID) = [dayendStockItemLnkFrom]![DayEndStockItemLnk_DayEndID] + 1)) GROUP BY dayendStockItemLnkFrom.DayEndStockItemLnk_DayEndID;");
			Report.Database.Tables(1).SetDataSource(rs);
			Report.Database.Tables(2).SetDataSource(rsChange);
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		public static void report_POS(ref int id)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsData = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryPos
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryPos.rpt");
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			//ReportNone.Load("cryNoRecords.rpt")
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name, aPOS.POS_Name From aCompany, Report, aPOS WHERE (((aPOS.POSID)=" + id + "));");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			Report.SetParameterValue("txtTitle", "Point Of Sale Transactions for Device " + rs.Fields("POS_Name").Value);
			rs.Close();
			rs = modReport.getRSreport(ref "SELECT Sale.*, aConsignment.*, aCustomer.Customer_InvoiceName, aChannel.Channel_Name FROM aChannel INNER JOIN (aCustomer RIGHT JOIN (CustomerTransaction RIGHT JOIN (aConsignment RIGHT JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID) ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) ON aChannel.ChannelID = Sale.Sale_ChannelID WHERE (((Sale.Sale_PosID)=" + id + "));");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			sql = "SELECT SaleItem.*, IIf([SaleItem_DepositType]=1,[Deposit_Name]+'-bottle',IIf([SaleItem_DepositType]=2,[Deposit_Name]+'-Crate',[Deposit_Name]+'-Case')) AS StockItem_Name FROM SaleItem INNER JOIN aDeposit ON SaleItem.SaleItem_StockItemID = aDeposit.DepositID Where (((SaleItem.SaleItem_DepositType) <> 0)) Union ";
			sql = sql + "SELECT SaleItem.*, aStockItem.StockItem_Name FROM SaleItem INNER JOIN aStockItem ON SaleItem.SaleItem_StockItemID = aStockItem.StockItemID Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_Recipe) = 0)) Union ";
			sql = sql + "SELECT SaleItem.*, aRecipe.Recipe_Name AS StockItem_Name FROM SaleItem INNER JOIN aRecipe ON SaleItem.SaleItem_StockItemID = aRecipe.RecipeID WHERE (((SaleItem.SaleItem_DepositType)=0) AND ((SaleItem.SaleItem_Recipe)<>0));";
			rsData = modReport.getRSreport(ref sql);

			if (rsData.BOF | rsData.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.Database.Tables(1).SetDataSource(rs);
			Report.Database.Tables(2).SetDataSource(rsData);

			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}
		public static void report_StockQuantity(ref int stockID = 0)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsOpen = default(ADODB.Recordset);
			ADODB.Recordset rsWH = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryStockQuantityReport
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryStockQuantityReport.rpt");
			int lID = 0;
			if (stockID == 0) {
				lID = My.MyProject.Forms.frmStockList.getItem();
			} else {
				lID = stockID;
			}
			//Multi Warehouse change
			int lMWNo = 0;
			lMWNo = My.MyProject.Forms.frmMWSelect.getMWNo();
			if (lMWNo > 1) {
				rsWH = modRecordSet.getRS(ref "SELECT * FROM Warehouse WHERE WarehouseID=" + lMWNo + ";");
				Report.SetParameterValue("txtWH", rsWH.Fields("Warehouse_Name"));
			}
			//Multi Warehouse change
			//ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (lID) {
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
				rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
				Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
				Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
				rs.Close();
				rs = modReport.getRSreport(ref "SELECT * FROM aStockItem WHERE StockItemID=" + lID);
				Report.SetParameterValue("txtTitle", "Stock Movement for " + rs.Fields("StockItem_Name").Value);
				rs.Close();

				//sql = "SELECT DayEnd.DayEnd_Date, stockQuantity.* FROM DayEnd INNER JOIN (SELECT * FROM (SELECT Sale.Sale_DayEndID AS dayEnd, Sale.Sale_Date AS [date], 'Sale' AS type, [Sale_PosID] & '_' & [Sale_Reference] AS name, SaleItem.SaleItem_StockItemID AS stockItem, 0 AS grvQuantity, [SaleItem_ShrinkQuantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_Reversal) = 0) And ((SaleItem.SaleItem_Recipe) = 0)) Union "
				//sql = sql & "SELECT Sale.Sale_DayEndID AS dayEnd, Sale.Sale_Date AS [date], 'Sale' AS type, [Sale_PosID] & '_' & [Sale_Reference] & '*' AS name, aSaleItemReciept.SaleItemReciept_StockitemID AS stockItem, 0 AS grvQuantity, [SaleItemReciept_Quantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN aSaleItemReciept ON SaleItem.SaleItemID = aSaleItemReciept.SaleItemReciept_SaleItemID WHERE (((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)=0))) as movement Union "
				//sql = sql & "SELECT * FROM (SELECT Sale.Sale_DayEndID AS dayEnd, Sale.Sale_Date AS [date], 'Sale Return' AS type, [Sale_PosID] & '_' & [Sale_Reference] AS name, SaleItem.SaleItem_StockItemID AS stockItem, 0 AS grvQuantity, 0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_Reversal) <> 0) And ((SaleItem.SaleItem_Recipe) = 0)) Union "
				//sql = sql & "SELECT Sale.Sale_DayEndID AS dayEnd, Sale.Sale_Date AS [date], 'Sale Return' AS type, [Sale_PosID] & '_' & [Sale_Reference] & '*' AS name, aSaleItemReciept.SaleItemReciept_StockitemID AS stockItem, 0 AS grvQuantity, 0-[SaleItemReciept_Quantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN aSaleItemReciept ON SaleItem.SaleItemID = aSaleItemReciept.SaleItemReciept_SaleItemID WHERE (((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)<>0))) as movement Union "
				//sql = sql & "SELECT aGRV.GRV_DayEndID AS dayEnd, aGRV.GRV_Date AS [date], 'Purchase' AS type, Supplier.Supplier_Name AS name, aGRVItem.GRVItem_StockItemID AS stockItem, [GRVItem_PackSize]*[GRVItem_Quantity] AS grvQuantity, Null AS saleQuantity, Null AS shrinkQuantity FROM (aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID Where (((aGRVItem.GRVItem_Return) = 0) And ((aGRV.GRV_GRVStatusID) = 3)) Union "
				//sql = sql & "SELECT aGRV.GRV_DayEndID AS dayEnd, aGRV.GRV_Date AS [date], 'Purchase Return' AS type, Supplier.Supplier_Name AS name, aGRVItem.GRVItem_StockItemID AS stockItem, 0-([GRVItem_PackSize]*[GRVItem_Quantity]) AS grvQuantity, Null AS saleQuantity, Null AS shrinkQuantity FROM (aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID Where (((aGRVItem.GRVItem_Return) <> 0) And ((aGRV.GRV_GRVStatusID) = 3)) Union "
				//sql = sql & "SELECT DayEndStockItemLnk.DayEndStockItemLnk_DayEndID AS dayEnd, DayEnd.DayEnd_Date AS [date], 'Shrinkage' AS type, 'Shrinkage' AS name, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, Null AS grvQuantity, Null AS saleQuantity, DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink AS shrinkQuantity FROM DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID Where (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0)) ) AS stockQuantity ON DayEnd.DayEndID = stockQuantity.dayEnd Where (((stockQuantity.stockItem) = " & lID & ")) ORDER BY stockQuantity.date;"

				//aSaleItemReciept changed to aSaleItemReciept1
				//query was showing less/wrong info due to less rec in aSaleItemReciept
				sql = "SELECT DayEnd.DayEnd_Date, stockQuantity.* FROM DayEnd INNER JOIN (SELECT * FROM (SELECT Sale.Sale_DayEndID AS dayEnd, Sale.Sale_Date AS [date], 'Sale' AS type, [Sale_PosID] & '_' & [Sale_Reference] AS name, SaleItem.SaleItem_StockItemID AS stockItem, 0 AS grvQuantity, [SaleItem_ShrinkQuantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_Reversal) = 0) And ((SaleItem.SaleItem_Recipe) = 0)) Union ";
				sql = sql + "SELECT Sale.Sale_DayEndID AS dayEnd, Sale.Sale_Date AS [date], 'Sale' AS type, [Sale_PosID] & '_' & [Sale_Reference] & '*' AS name, aSaleItemReciept1.SaleItemReciept_StockitemID AS stockItem, 0 AS grvQuantity, [SaleItemReciept_Quantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN aSaleItemReciept1 ON SaleItem.SaleItemID = aSaleItemReciept1.SaleItemReciept_SaleItemID WHERE (((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)=0))) as movement Union ";
				sql = sql + "SELECT * FROM (SELECT Sale.Sale_DayEndID AS dayEnd, Sale.Sale_Date AS [date], 'Sale Return' AS type, [Sale_PosID] & '_' & [Sale_Reference] AS name, SaleItem.SaleItem_StockItemID AS stockItem, 0 AS grvQuantity, 0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_Reversal) <> 0) And ((SaleItem.SaleItem_Recipe) = 0)) Union ";
				sql = sql + "SELECT Sale.Sale_DayEndID AS dayEnd, Sale.Sale_Date AS [date], 'Sale Return' AS type, [Sale_PosID] & '_' & [Sale_Reference] & '*' AS name, aSaleItemReciept1.SaleItemReciept_StockitemID AS stockItem, 0 AS grvQuantity, 0-[SaleItemReciept_Quantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN aSaleItemReciept1 ON SaleItem.SaleItemID = aSaleItemReciept1.SaleItemReciept_SaleItemID WHERE (((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)<>0))) as movement Union ";
				sql = sql + "SELECT aGRV.GRV_DayEndID AS dayEnd, aGRV.GRV_Date AS [date], 'Purchase' AS type, Supplier.Supplier_Name AS name, aGRVItem.GRVItem_StockItemID AS stockItem, [GRVItem_PackSize]*[GRVItem_Quantity] AS grvQuantity, Null AS saleQuantity, Null AS shrinkQuantity FROM (aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID Where (((aGRVItem.GRVItem_Return) = 0) And ((aGRV.GRV_GRVStatusID) = 3)) Union ";
				sql = sql + "SELECT aGRV.GRV_DayEndID AS dayEnd, aGRV.GRV_Date AS [date], 'Purchase Return' AS type, Supplier.Supplier_Name AS name, aGRVItem.GRVItem_StockItemID AS stockItem, 0-([GRVItem_PackSize]*[GRVItem_Quantity]) AS grvQuantity, Null AS saleQuantity, Null AS shrinkQuantity FROM (aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID Where (((aGRVItem.GRVItem_Return) <> 0) And ((aGRV.GRV_GRVStatusID) = 3)) Union ";
				sql = sql + "SELECT DayEndStockItemLnk.DayEndStockItemLnk_DayEndID AS dayEnd, DayEnd.DayEnd_Date AS [date], 'Shrinkage' AS type, 'Shrinkage' AS name, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, Null AS grvQuantity, Null AS saleQuantity, DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink AS shrinkQuantity FROM DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID Where (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0)) ) AS stockQuantity ON DayEnd.DayEndID = stockQuantity.dayEnd Where (((stockQuantity.stockItem) = " + lID + ")) ORDER BY stockQuantity.date;";
				//adding query information in TEMP table, due to less info abt SALES QTY in RECIEPT
				sql = "";
				modReport.cnnDBreport.Execute("DELETE * FROM stockQuantityTemp;");

				//1
				sql = "SELECT DayEnd.DayEnd_Date AS dayEnddate, Sale.Sale_DayEndID AS dayEnd, Sale.Sale_Date AS [date], 'Sale' AS type, [Sale_PosID] & '_' & [Sale_Reference] AS name, SaleItem.SaleItem_StockItemID AS stockItem, 0 AS grvQuantity, [SaleItem_ShrinkQuantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity, Null AS xferQuantity ";
				sql = sql + "FROM (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN DayEnd ON Sale.Sale_DayEndID = DayEnd.DayEndID ";
				sql = sql + "WHERE (((SaleItem.SaleItem_StockItemID)=" + lID + ") AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)=0) AND ((SaleItem.SaleItem_Recipe)=0) AND ((SaleItem.SaleItem_WarehouseID)=" + lMWNo + "));";
				//Multi Warehouse change     sql = sql & "WHERE (((SaleItem.SaleItem_StockItemID)=" & lID & ") AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)=0) AND ((SaleItem.SaleItem_Recipe)=0));"
				modReport.cnnDBreport.Execute("INSERT INTO stockQuantityTemp " + sql);
				Debug.Print(sql);
				//2
				//sql = "SELECT DayEnd.DayEnd_Date AS dayEnddate, Sale.Sale_DayEndID AS dayEnd, Sale.Sale_Date AS [date], 'Sale' AS type, [Sale_PosID] & '_' & [Sale_Reference] & '*' AS name, aSaleItemReciept1.SaleItemReciept_StockitemID AS stockItem, 0 AS grvQuantity, [SaleItemReciept_Quantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity, Null AS xferQuantity "
				//changed on 11-12-2012 (if sell more then 1 it was multiplying 2 times) Hogshead
				sql = "SELECT DayEnd.DayEnd_Date AS dayEnddate, Sale.Sale_DayEndID AS dayEnd, Sale.Sale_Date AS [date], 'Sale' AS type, [Sale_PosID] & '_' & [Sale_Reference] & '*' AS name, aSaleItemReciept1.SaleItemReciept_StockitemID AS stockItem, 0 AS grvQuantity, [SaleItemReciept_Quantity] AS saleQuantity, 0 AS shrinkQuantity, Null AS xferQuantity ";
				sql = sql + "FROM ((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN aSaleItemReciept1 ON SaleItem.SaleItemID = aSaleItemReciept1.SaleItemReciept_SaleItemID) INNER JOIN DayEnd ON Sale.Sale_DayEndID = DayEnd.DayEndID ";
				sql = sql + "WHERE (((aSaleItemReciept1.SaleItemReciept_StockitemID)=" + lID + ") AND ((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)=0) AND ((SaleItem.SaleItem_WarehouseID)=" + lMWNo + "));";
				//Multi Warehouse change     sql = sql & "WHERE (((aSaleItemReciept1.SaleItemReciept_StockitemID)=" & lID & ") AND ((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)=0));"
				modReport.cnnDBreport.Execute("INSERT INTO stockQuantityTemp " + sql);
				Debug.Print(sql);
				//3
				sql = "SELECT DayEnd.DayEnd_Date AS dayEnddate, Sale.Sale_DayEndID AS dayEnd, Sale.Sale_Date AS [date], 'Sale Return' AS type, [Sale_PosID] & '_' & [Sale_Reference] AS name, SaleItem.SaleItem_StockItemID AS stockItem, 0 AS grvQuantity, 0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity, Null AS xferQuantity ";
				sql = sql + "FROM (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN DayEnd ON Sale.Sale_DayEndID = DayEnd.DayEndID ";
				sql = sql + "WHERE (((SaleItem.SaleItem_StockItemID)=" + lID + ") AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)<>0) AND ((SaleItem.SaleItem_Recipe)=0) AND ((SaleItem.SaleItem_WarehouseID)=" + lMWNo + "));";
				//Multi Warehouse change     sql = sql & "WHERE (((SaleItem.SaleItem_StockItemID)=" & lID & ") AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)<>0) AND ((SaleItem.SaleItem_Recipe)=0));"
				modReport.cnnDBreport.Execute("INSERT INTO stockQuantityTemp " + sql);
				Debug.Print(sql);
				//4
				//sql = "SELECT DayEnd.DayEnd_Date AS dayEnddate, Sale.Sale_DayEndID AS dayEnd, Sale.Sale_Date AS [date], 'Sale Return' AS type, [Sale_PosID] & '_' & [Sale_Reference] & '*' AS name, aSaleItemReciept1.SaleItemReciept_StockitemID AS stockItem, 0 AS grvQuantity, 0-[SaleItemReciept_Quantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity, Null AS xferQuantity "
				//changed on 11-12-2012 (if sell more then 1 it was multiplying 2 times) Hogshead
				sql = "SELECT DayEnd.DayEnd_Date AS dayEnddate, Sale.Sale_DayEndID AS dayEnd, Sale.Sale_Date AS [date], 'Sale Return' AS type, [Sale_PosID] & '_' & [Sale_Reference] & '*' AS name, aSaleItemReciept1.SaleItemReciept_StockitemID AS stockItem, 0 AS grvQuantity, 0-[SaleItemReciept_Quantity] AS saleQuantity, 0 AS shrinkQuantity, Null AS xferQuantity ";
				sql = sql + "FROM ((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN aSaleItemReciept1 ON SaleItem.SaleItemID = aSaleItemReciept1.SaleItemReciept_SaleItemID) INNER JOIN DayEnd ON Sale.Sale_DayEndID = DayEnd.DayEndID ";
				sql = sql + "WHERE (((aSaleItemReciept1.SaleItemReciept_StockitemID)=" + lID + ") AND ((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)<>0) AND ((SaleItem.SaleItem_WarehouseID)=" + lMWNo + "));";
				//Multi Warehouse change     sql = sql & "WHERE (((aSaleItemReciept1.SaleItemReciept_StockitemID)=" & lID & ") AND ((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)<>0));"
				modReport.cnnDBreport.Execute("INSERT INTO stockQuantityTemp " + sql);
				Debug.Print(sql);

				if (lMWNo == 2) {
					//5
					sql = "SELECT DayEnd.DayEnd_Date AS dayEnddate, aGRV.GRV_DayEndID AS dayEnd, aGRV.GRV_Date AS [date], 'Purchase' AS type, Supplier.Supplier_Name AS name, aGRVItem.GRVItem_StockItemID AS stockItem, [GRVItem_PackSize]*[GRVItem_Quantity] AS grvQuantity, Null AS saleQuantity, Null AS shrinkQuantity, Null AS xferQuantity ";
					sql = sql + "FROM (aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID ";
					sql = sql + "WHERE (((aGRVItem.GRVItem_StockItemID)=" + lID + ") AND ((aGRVItem.GRVItem_Return)=0) AND ((aGRV.GRV_GRVStatusID)=3));";
					modReport.cnnDBreport.Execute("INSERT INTO stockQuantityTemp " + sql);
					Debug.Print(sql);
					//6
					sql = "SELECT DayEnd.DayEnd_Date AS dayEnddate, aGRV.GRV_DayEndID AS dayEnd, aGRV.GRV_Date AS [date], 'Purchase Return' AS type, Supplier.Supplier_Name AS name, aGRVItem.GRVItem_StockItemID AS stockItem, 0-([GRVItem_PackSize]*[GRVItem_Quantity]) AS grvQuantity, Null AS saleQuantity, Null AS shrinkQuantity, Null AS xferQuantity ";
					sql = sql + "FROM (aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID ";
					sql = sql + "WHERE (((aGRVItem.GRVItem_StockItemID)=" + lID + ") AND ((aGRVItem.GRVItem_Return)<>0) AND ((aGRV.GRV_GRVStatusID)=3));";
					modReport.cnnDBreport.Execute("INSERT INTO stockQuantityTemp " + sql);
					Debug.Print(sql);
				}

				//7
				sql = "SELECT DayEnd.DayEnd_Date AS dayEnddate, DayEndStockItemLnk.DayEndStockItemLnk_DayEndID AS dayEnd, DayEnd.DayEnd_Date AS [date], 'Shrinkage' AS type, 'Shrinkage' AS name, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, Null AS grvQuantity, Null AS saleQuantity, DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink AS shrinkQuantity, Null AS xferQuantity ";
				sql = sql + "FROM DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID ";
				sql = sql + "WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" + lID + ") AND ((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink)<>0) AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" + lMWNo + "));";
				//Multi Warehouse change     sql = sql & "WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & lID & ") AND ((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink)<>0));"
				modReport.cnnDBreport.Execute("INSERT INTO stockQuantityTemp " + sql);
				Debug.Print(sql);

				//DayEndStockItemLnk_QuantityTransafer
				//8
				sql = "SELECT DayEnd.DayEnd_Date AS dayEnddate, DayEndStockItemLnk.DayEndStockItemLnk_DayEndID AS dayEnd, DayEnd.DayEnd_Date AS [date], 'Xfer' AS type, 'Xfer' AS name, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, Null AS grvQuantity, Null AS saleQuantity, Null AS shrinkQuantity, DayEndStockItemLnk.DayEndStockItemLnk_QuantityTransafer AS xferQuantity ";
				sql = sql + "FROM DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID ";
				sql = sql + "WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" + lID + ") AND ((DayEndStockItemLnk.DayEndStockItemLnk_QuantityTransafer)<>0) AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" + lMWNo + "));";
				modReport.cnnDBreport.Execute("INSERT INTO stockQuantityTemp " + sql);
				Debug.Print(sql);

				//adding query information in TEMP table, due to less info abt SALES QTY in RECIEPT
				sql = "SELECT * from stockQuantityTemp ORDER BY stockQuantityTemp.dayEnddate,stockQuantityTemp.date;";
				rs = modReport.getRSreport(ref sql);
				Debug.Print(sql);

				if (rs.BOF | rs.EOF) {
					//9
					sql = "SELECT DayEnd.DayEnd_Date AS dayEnddate, DayEndStockItemLnk.DayEndStockItemLnk_DayEndID AS dayEnd, DayEnd.DayEnd_Date AS [date], 'No Movement' AS type, 'No Movement' AS name, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, 0 AS grvQuantity, 0 AS saleQuantity, 0 AS shrinkQuantity, 0 AS xferQuantity ";
					sql = sql + "FROM DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID ";
					sql = sql + "WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" + lID + ") AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" + lMWNo + "));";
					modReport.cnnDBreport.Execute("INSERT INTO stockQuantityTemp " + sql);
					Debug.Print(sql);
					//adding query information in TEMP table, due to less info abt SALES QTY in RECIEPT
					sql = "SELECT * from stockQuantityTemp ORDER BY stockQuantityTemp.dayEnddate,stockQuantityTemp.date;";
					rs = modReport.getRSreport(ref sql);
					Debug.Print(sql);
				}

				if (rs.BOF | rs.EOF) {
					ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
					ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
					My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
					My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
					My.MyProject.Forms.frmReportShow.mReport = ReportNone;
					My.MyProject.Forms.frmReportShow.sMode = "0";
					My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
					My.MyProject.Forms.frmReportShow.ShowDialog();
					return;
				}
				rsOpen = modReport.getRSreport(ref "SELECT First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity From DayEndStockItemLnk GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse HAVING (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" + lID + ") AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" + lMWNo + "));");
				//Multi Warehouse change     Set rsOpen = getRSreport("SELECT First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity From DayEndStockItemLnk GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID HAVING (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & lID & "));")
				Report.Database.Tables(1).SetDataSource(rs);
				Report.Database.Tables(2).SetDataSource(rsOpen);

				//Report.VerifyOnEveryPrint = True
				My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
				My.MyProject.Forms.frmReportShow.mReport = Report;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
			}
		}


		private static void report_Deposit()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryDeposit
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryDeposit.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();
			rs = modReport.getRSreport(ref "SELECT aDeposit.Deposit_Name, aDeposit.Deposit_Quantity, Sum((IIf([SaleItem_DepositType]=3,[Deposit_Quantity],0)+IIf([SaleItem_DepositType]=1,1,0))*[SaleItem_Quantity]) AS bottle, Sum((IIf([SaleItem_DepositType]=3,1,0)+IIf([SaleItem_DepositType]=2,1,0))*[SaleItem_Quantity]) AS crate, Sum([SaleItem_Price]*[SaleItem_Quantity]) AS amount, aDeposit.Deposit_UnitCost, aDeposit.Deposit_CaseCost FROM SaleItem INNER JOIN aDeposit ON SaleItem.SaleItem_StockItemID = aDeposit.DepositID Where (((SaleItem.SaleItem_DepositType) <> 0) And ((SaleItem.SaleItem_Reversal) = False) And ((SaleItem.SaleItem_Revoke) = False)) GROUP BY aDeposit.Deposit_Name, aDeposit.Deposit_Quantity, aDeposit.Deposit_UnitCost, aDeposit.Deposit_CaseCost;");
			//ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.Database.Tables(1).SetDataSource(rs);

			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		private static void report_StockCostVariance(ref short ltype)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryStockCostVariance
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryStockCostVariance.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");

			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();
			if (ltype) {
				sql = "SELECT dayendStockItemLnkFrom.DayEndStockItemLnk_DayEndID, DayEnd.DayEnd_Date, aStockItem.StockItem_Name, dayendStockItemLnkFrom.DayEndStockItemLnk_ActualCost AS DayEndStockItemLnkFrom_ListCost, DayEndStockItemLnk.DayEndStockItemLnk_ActualCost AS DayEndStockItemLnk_ListCost, [DayEndStockItemLnk]![DayEndStockItemLnk_ActualCost]-[DayEndStockItemLnkfrom]![DayEndStockItemLnk_ActualCost] AS unitProfit, DayEndStockItemLnk.DayEndStockItemLnk_Quantity, ([DayEndStockItemLnk]![DayEndStockItemLnk_ActualCost]-[DayEndStockItemLnkfrom]![DayEndStockItemLnk_ActualCost])*[DayEndStockItemLnk]![DayEndStockItemLnk_Quantity] AS totalProfit ";
				sql = sql + "FROM ((DayEndStockItemLnk INNER JOIN [SELECT DayEndStockItemLnkFirst.* From DayEndStockItemLnkFirst Union SELECT DayEndStockItemLnk.* From DayEndStockItemLnk ]. AS dayendStockItemLnkFrom ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = dayendStockItemLnkFrom.DayEndStockItemLnk_StockItemID) INNER JOIN DayEnd ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = DayEnd.DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID Where (((DayEndStockItemLnk.DayEndStockItemLnk_ActualCost) <> [dayendStockItemLnkFrom]![DayEndStockItemLnk_ActualCost]) And ((DayEndStockItemLnk.DayEndStockItemLnk_Quantity) > 0) And ((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) = [dayendStockItemLnkFrom]![DayEndStockItemLnk_DayEndID] + 1)) ORDER BY dayendStockItemLnkFrom.DayEndStockItemLnk_DayEndID, aStockItem.StockItem_Name;";
				Report.SetParameterValue("txtTitle", "Profit or Loss due to Cost Variance - Actual");
			} else {
				sql = "SELECT dayendStockItemLnkFrom.DayEndStockItemLnk_DayEndID, DayEnd.DayEnd_Date, aStockItem.StockItem_Name, dayendStockItemLnkFrom.DayEndStockItemLnk_ListCost AS DayEndStockItemLnkFrom_ListCost, DayEndStockItemLnk.DayEndStockItemLnk_ListCost, [DayEndStockItemLnk]![DayEndStockItemLnk_ListCost]-[DayEndStockItemLnkfrom]![DayEndStockItemLnk_ListCost] AS unitProfit, DayEndStockItemLnk.DayEndStockItemLnk_Quantity, ([DayEndStockItemLnk]![DayEndStockItemLnk_ListCost]-[DayEndStockItemLnkfrom]![DayEndStockItemLnk_ListCost])*[DayEndStockItemLnk]![DayEndStockItemLnk_Quantity] AS totalProfit FROM ((DayEndStockItemLnk INNER JOIN (SELECT DayEndStockItemLnkFirst.* From DayEndStockItemLnkFirst Union SELECT DayEndStockItemLnk.* From DayEndStockItemLnk ";
				sql = sql + ") AS dayendStockItemLnkFrom ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = dayendStockItemLnkFrom.DayEndStockItemLnk_StockItemID) INNER JOIN DayEnd ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = DayEnd.DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID Where (((DayEndStockItemLnk.DayEndStockItemLnk_ListCost) <> [dayendStockItemLnkFrom]![DayEndStockItemLnk_ListCost]) And ((DayEndStockItemLnk.DayEndStockItemLnk_Quantity) > 0) And ((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) = [dayendStockItemLnkFrom]![DayEndStockItemLnk_DayEndID] + 1)) ORDER BY dayendStockItemLnkFrom.DayEndStockItemLnk_DayEndID, aStockItem.StockItem_Name;";
				Report.SetParameterValue("txtTitle", "Profit or Loss due to Cost Variance - List");
			}

			rs = modReport.getRSreport(ref sql);
			//ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.Database.Tables(1).SetDataSource(rs);

			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		private static void report_StockBreakTransaction()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryStockBreakTransaction
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryStockBreakTransaction.rpt");
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();
			rs = modReport.getRSreport(ref "SELECT DayEnd.DayEnd_Date, Format([DayEnd_Date],'dddd, dd mmm yyyy') AS theDate, DayEnd.DayEndID, aStockItem.StockItem_Name, aStockItem_1.StockItem_Name AS StockItemChild_Name, aStockBreakTransaction.* FROM ((aStockBreakTransaction INNER JOIN DayEnd ON aStockBreakTransaction.StockBreakTransaction_DayEndID = DayEnd.DayEndID) INNER JOIN aStockItem ON aStockBreakTransaction.StockBreakTransaction_ParentID = aStockItem.StockItemID) INNER JOIN aStockItem AS aStockItem_1 ON aStockBreakTransaction.StockBreakTransaction_ChildID = aStockItem_1.StockItemID ORDER BY DayEnd.DayEnd_Date, aStockItem.StockItem_Name;");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.Database.Tables(1).SetDataSource(rs);

			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		//report_SupplierBalance
		private static void report_SupplierBalance()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New crySupplierBalances 'crySupplierBalance 'IIf(Supplier.Supplier_Current, Supplier.Supplier_Current,0)
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("crySupplierBalances.rpt");
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();
			//Set rs = getRSreport("SELECT aCustomer.CustomerID, aCustomer.Customer_InvoiceName, [Customer_FirstName] & ' ' & [Customer_Surname] AS Customer_Name, aCustomer.Customer_CreditLimit, aCustomer.Customer_Current, aCustomer.Customer_30Days, aCustomer.Customer_60Days, aCustomer.Customer_90Days, aCustomer.Customer_120Days, aCustomer.Customer_150Days, [Customer_Current]+[Customer_30Days]+[Customer_60Days]+[Customer_90Days]+[Customer_120Days]+[Customer_150Days] AS outstanding From aCustomer WHERE ((([Customer_Current]+[Customer_30Days]+[Customer_60Days]+[Customer_90Days]+[Customer_120Days]+[Customer_150Days])<>0));")
			rs = modRecordSet.getRS(ref "SELECT Supplier.SupplierID, Supplier.Supplier_Name, IIf(IsNull([Supplier_Current]),0,[Supplier_Current]) AS Supplier_Currents, IIf(IsNull([Supplier_30Days]),0,[Supplier_30Days]) AS Supplier_30Dayss, IIf(IsNull([Supplier_60Days]),0,[Supplier_60Days]) AS Supplier_60Dayss, IIf(IsNull([Supplier_90Days]),0,[Supplier_90Days]) AS Supplier_90Dayss, IIf(IsNull([Supplier_120Days]),0,[Supplier_120Days]) AS Supplier_120Dayss, IIf(IsNull([Supplier_Current]),0,[Supplier_Current])+IIf(IsNull([Supplier_30Days]),0,[Supplier_30Days])+IIf(IsNull([Supplier_60Days]),0,[Supplier_60Days])+IIf(IsNull([Supplier_90Days]),0,[Supplier_90Days])+IIf(IsNull([Supplier_120Days]),0,[Supplier_120Days]) AS outstanding From Supplier WHERE (((IIf(IsNull([Supplier_Current]),0,[Supplier_Current])+IIf(IsNull([Supplier_30Days]),0,[Supplier_30Days])+IIf(IsNull([Supplier_60Days]),0,[Supplier_60Days])+IIf(IsNull([Supplier_90Days]),0,[Supplier_90Days])+IIf(IsNull([Supplier_120Days]),0,[Supplier_120Days]))<>0));");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.Database.Tables(1).SetDataSource(rs);

			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		private static void report_CustomerBalance()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryCustomerBalance
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryCustomerBalance.rpt");
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			bool showDetails = false;

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();
			//Set rs = getRSreport("SELECT aCustomer.CustomerID, aCustomer.Customer_InvoiceName, [Customer_FirstName] & ' ' & [Customer_Surname] AS Customer_Name, aCustomer.Customer_CreditLimit, aCustomer.Customer_Current, aCustomer.Customer_30Days, aCustomer.Customer_60Days, aCustomer.Customer_90Days, aCustomer.Customer_120Days, aCustomer.Customer_150Days, [Customer_Current]+[Customer_30Days]+[Customer_60Days]+[Customer_90Days]+[Customer_120Days]+[Customer_150Days] AS outstanding From aCustomer WHERE ((([Customer_Current]+[Customer_30Days]+[Customer_60Days]+[Customer_90Days]+[Customer_120Days]+[Customer_150Days])<>0));")
			if (Interaction.MsgBox("Do you wish to see Customer report only with Balances click 'Yes'?" + Constants.vbCrLf + Constants.vbCrLf + "click 'No' if you wish to see report for all Customers.", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1, "Customer Balances") == MsgBoxResult.Yes) {
				rs = modReport.getRSreport(ref "SELECT aCustomer1.CustomerID, aCustomer1.Customer_InvoiceName, [Customer_FirstName] & ' ' & [Customer_Surname] AS Customer_Name, aCustomer1.Customer_Telephone, aCustomer1.Customer_Fax, aCustomer1.Customer_CreditLimit, aCustomer1.Customer_Current, aCustomer1.Customer_30Days, aCustomer1.Customer_60Days, aCustomer1.Customer_90Days, aCustomer1.Customer_120Days, aCustomer1.Customer_150Days, [Customer_Current]+[Customer_30Days]+[Customer_60Days]+[Customer_90Days]+[Customer_120Days]+[Customer_150Days] AS outstanding From aCustomer1 WHERE ((([Customer_Current]+[Customer_30Days]+[Customer_60Days]+[Customer_90Days]+[Customer_120Days]+[Customer_150Days])<>0));");
			} else {
				rs = modReport.getRSreport(ref "SELECT aCustomer1.CustomerID, aCustomer1.Customer_InvoiceName, [Customer_FirstName] & ' ' & [Customer_Surname] AS Customer_Name, aCustomer1.Customer_Telephone, aCustomer1.Customer_Fax, aCustomer1.Customer_CreditLimit, aCustomer1.Customer_Current, aCustomer1.Customer_30Days, aCustomer1.Customer_60Days, aCustomer1.Customer_90Days, aCustomer1.Customer_120Days, aCustomer1.Customer_150Days, [Customer_Current]+[Customer_30Days]+[Customer_60Days]+[Customer_90Days]+[Customer_120Days]+[Customer_150Days] AS outstanding From aCustomer1;");
			}
			if (Interaction.MsgBox("Do you wish to see details of Customer, like Contact name, Phone and Fax numbers? click 'Yes'?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1, "Customer Balances") == MsgBoxResult.Yes) {
				CrystalDecisions.CrystalReports.Engine.TextObject textObject = Report.ReportDefinition.ReportObjects("Text1");
				textObject.Border.BackgroundColor = Color.White;
				textObject.Border.LeftLineStyle = 1;
				textObject.Border.RightLineStyle = 1;
				//Report.Text1.BackColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
				//Report.Text1.LeftLineStyle = 1
				//Report.Text1.RightLineStyle = 1
			} else {
				CrystalDecisions.CrystalReports.Engine.TextObject textObject = Report.ReportDefinition.ReportObjects("Text15");
				textObject.Top = 0;
				textObject.ObjectFormat.EnableSuppress = true;
				textObject = Report.ReportDefinition.ReportObjects("Text2");
				textObject.ObjectFormat.EnableSuppress = true;
				textObject.Top = 0;
				textObject = Report.ReportDefinition.ReportObjects("Text14");
				textObject.ObjectFormat.EnableSuppress = true;
				textObject.Top = 0;
				textObject = Report.ReportDefinition.ReportObjects("Field19");
				textObject.ObjectFormat.EnableSuppress = true;
				textObject.Top = 0;
				textObject = Report.ReportDefinition.ReportObjects("Field21");
				textObject.ObjectFormat.EnableSuppress = true;
				textObject.Top = 0;
				textObject = Report.ReportDefinition.ReportObjects("Field20");
				textObject.ObjectFormat.EnableSuppress = true;
				textObject.Top = 0;
				textObject = Report.ReportDefinition.ReportObjects("Text1");
				textObject.Top = 0;
				Report.ReportDefinition.Sections("Section3").Height = 210;
			}

			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.Database.Tables(1).SetDataSource(rs);

			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		private static void report_Gratuity()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryGratuity
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryGratuity.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();

			rs = modReport.getRSreport(ref "SELECT [Person_FirstName]+' '+[Person_LastName] AS person_Name, aPOS.POS_Name, Sale.* FROM (Sale INNER JOIN aPerson ON Sale.Sale_PersonID = aPerson.PersonID) INNER JOIN aPOS ON Sale.Sale_PosID = aPOS.POSID Where (((Sale.Sale_Gratuity) <> 0)) ORDER BY Sale.Sale_Gratuity DESC;");
			//ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.Database.Tables(1).SetDataSource(rs);
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		private static void report_Discount()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryDiscount
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryDiscount.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();
			rs = modReport.getRSreport(ref "SELECT [Person_FirstName]+' '+[Person_LastName] AS person_Name, aPOS.POS_Name, Sale.* FROM (Sale INNER JOIN aPerson ON Sale.Sale_PersonID = aPerson.PersonID) INNER JOIN aPOS ON Sale.Sale_PosID = aPOS.POSID Where (((Sale.Sale_Discount) <> 0)) ORDER BY Sale.Sale_Discount DESC;");
			//ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.Database.Tables(1).SetDataSource(rs);
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		private static void report_RevokeTransactionlist()
		{
			string sql = null;
			decimal SumSales = default(decimal);
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsData = default(ADODB.Recordset);
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");

			// to get getSQL
			bool gl = false;
			string lWhere = null;
			short x = 0;
			string lString = null;
			string getSQL = null;

			lWhere = lWhere + " AND (SaleItem_Revoke=True)";
			//If chkReversal.value Then lWhere = lWhere & " AND (SaleItem_Reversal=True)"
			//If chkFC.value Then lWhere = lWhere & " AND (Sale_PaymentType=8)"

			//lString = ""
			//For x = 0 To Me.lstChannel.ListCount - 1
			//    If Me.lstChannel.Selected(x) Then
			//        lString = lString & " OR Sale_ChannelID=" & lstChannel.ItemData(x)
			//    End If
			//Next x
			//If lString <> "" Then
			//    lString = " AND (" & Mid(lString, 4) & ")"
			//    lWhere = lWhere & lString
			//End If

			//lString = ""
			//For x = 0 To Me.lstPerson.ListCount - 1
			//    If Me.lstPerson.Selected(x) Then
			//        lString = lString & " OR Sale_PersonID=" & lstPerson.ItemData(x)
			//    End If
			//Next x
			//If lString <> "" Then
			//    lString = " AND (" & Mid(lString, 4) & ")"
			//    lWhere = lWhere & lString
			//End If

			//lString = ""
			//For x = 0 To Me.lstPOS.ListCount - 1
			//    If Me.lstPOS.Selected(x) Then
			//        lString = lString & " OR Sale_POSID=" & lstPOS.ItemData(x)
			//    End If
			//Next x
			//If lString <> "" Then
			//    lString = " AND (" & Mid(lString, 4) & ")"
			//    lWhere = lWhere & lString
			//End If

			//lString = ""
			//gl = False
			//For x = 0 To Me.lstSaleref.ListCount - 1
			//    If Me.lstSaleref.Selected(x) Then
			//        If x = 0 Then
			//          lString = lString & " Sale_CardRef <>''"
			//          gl = True
			//        ElseIf x = 1 Then
			//          If gl = True Then
			//             lString = lString & " OR Sale_OrderRef <>''"
			//          Else
			//             lString = lString & " Sale_OrderRef <>''"
			//             gl = True
			//          End If
			//        ElseIf x = 2 Then
			//           If gl = True Then
			//            lString = lString & " OR Sale_SerialRef <>''"
			//           Else
			//            lString = lString & " Sale_SerialRef <>''"
			//           End If
			//        End If
			//    End If
			//Next x
			//If lString <> "" Then
			//    lString = " AND (" & Mid(lString, 2) & ")"
			//    lWhere = lWhere & lString
			//End If

			if (!string.IsNullOrEmpty(lWhere))
				lWhere = " WHERE " + Strings.Mid(lWhere, 6);

			sql = "SELECT DISTINCT Sale.*, aConsignment.*, aCustomer.Customer_InvoiceName, aChannel.Channel_Name, aPerson.Person_FirstName & ' ' & aPerson.Person_LastName AS PersonName, aPerson.Person_Comm, aPerson1.Person_FirstName & ' ' & aPerson1.Person_LastName AS MgrName FROM (SaleItem INNER JOIN ((aChannel INNER JOIN (aCustomer RIGHT JOIN (CustomerTransaction RIGHT JOIN (aConsignment RIGHT JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID) ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) ON aChannel.ChannelID = Sale.Sale_ChannelID) INNER JOIN aPerson ON Sale.Sale_PersonID = aPerson.PersonID) ON SaleItem.SaleItem_SaleID = Sale.SaleID) LEFT JOIN aPerson1 ON Sale.Sale_ManagerID = aPerson1.PersonID ";
			sql = sql + lWhere;

			getSQL = sql;
			// to get getSQL

			//Report = New cryPOSreportRevoke
			Report.Load("cryPOSreportRevoke.rpt");

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name From aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();

			rs = modReport.getRSreport(ref getSQL);

			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			sql = "SELECT SaleItem.*, IIf([SaleItem_DepositType]=1,[Deposit_Name]+'-bottle',IIf([SaleItem_DepositType]=2,[Deposit_Name]+'-Crate',[Deposit_Name]+'-Case')) AS StockItem_Name FROM SaleItem INNER JOIN aDeposit ON SaleItem.SaleItem_StockItemID = aDeposit.DepositID Where (((SaleItem.SaleItem_DepositType) <> 0)) Union ";
			sql = sql + "SELECT SaleItem.*, aStockItem.StockItem_Name FROM SaleItem INNER JOIN aStockItem ON SaleItem.SaleItem_StockItemID = aStockItem.StockItemID Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_Recipe) = 0)) Union ";
			sql = sql + "SELECT SaleItem.*, aRecipe.Recipe_Name AS StockItem_Name FROM SaleItem INNER JOIN aRecipe ON SaleItem.SaleItem_StockItemID = aRecipe.RecipeID WHERE (((SaleItem.SaleItem_DepositType)=0) AND ((SaleItem.SaleItem_Recipe)<>0));";

			sql = "SELECT SaleItem.*, IIf([SaleItem_DepositType]=1,[Deposit_Name]+'-bottle',IIf([SaleItem_DepositType]=2,[Deposit_Name]+'-Crate',[Deposit_Name]+'-Case')) AS StockItem_Name FROM SaleItem INNER JOIN aDeposit ON SaleItem.SaleItem_StockItemID = aDeposit.DepositID Where (((SaleItem.SaleItem_DepositType) <> 0) AND ((SaleItem.SaleItem_Revoke) <> 0)) Union SELECT SaleItem.*, aStockItem.StockItem_Name FROM SaleItem INNER JOIN aStockItem ON SaleItem.SaleItem_StockItemID = aStockItem.StockItemID Where (((SaleItem.SaleItem_DepositType) = 0) AND ((SaleItem.SaleItem_Revoke) <> 0))";
			rsData = modReport.getRSreport(ref sql);

			if (rsData.BOF | rsData.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			//If emp_Clicked = True Then
			//   SumSales = 0
			//   Do While rs.EOF = False
			//      SumSales = SumSales + rs("Sale_Total")
			//      rs.moveNext
			//   Loop
			//      'Resise to excluding vat
			//      SumSales = SumSales - (SumSales * 0.14)
			//      rs.MoveFirst
			//      Report.txtComm.SetText rs("Person_Comm")
			//      Report.txtTotalCommision.SetText FormatNumber((SumSales * rs("Person_Comm")) / 100, 2)
			//End If

			Report.Database.Tables(1).SetDataSource(rs);
			Report.Database.Tables(2).SetDataSource(rsData);
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtComm").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		private static void report_ProductPerformanceGRVDeals()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			ADODB.Recordset rsData = default(ADODB.Recordset);
			//Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			string lOrder = null;
			//Dim CRXDatabaseField As CrystalDecisions.CrystalReports.Engine.DatabaseFieldDefinition
			CrystalDecisions.CrystalReports.Engine.FieldDefinition CRXDatabaseField = default(CrystalDecisions.CrystalReports.Engine.FieldDefinition);

			//    Dim lEmpID As Long
			//
			//    lEmpID = 0
			//    If MsgBox("Do you wish to see report for all Customers?", vbInformation + vbYesNo) = vbYes Then
			//    Else
			//        lEmpID = frmCustomerList.getItem(8)
			//        If lEmpID = 0 Then Exit Sub
			//    End If

			lOrder = "StockItem_Name";
			lOrder = " ORDER BY " + lOrder;

			Report = null;
			Report.Load("cryStockitemTopGroupGRVDeal");
			//Report = New cryStockitemTopGroupGRVDeal

			while (Report.DataDefinition.SortFields.Count) {
				//'Report.RecordSortFields.delete(1)
			}

			//Screen.MousePointer = vbHourglass
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();

			//    sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockListCustomer.inclusiveSum) AS inclusive, Sum(StockListCustomer.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockListCustomer.quantitySum) AS quantity, Sum(StockListCustomer.listCostSum) AS listCost, Sum(StockListCustomer.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department, StockListCustomer.CustomerTransaction_CustomerID "
			//    sql = sql & "FROM StockListCustomer INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListCustomer.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, StockListCustomer.CustomerTransaction_CustomerID HAVING (((StockListCustomer.CustomerTransaction_CustomerID)=" & lEmpID & ")) "
			//
			//    sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockListCustomerByGroup.inclusiveSum AS inclusive, StockListCustomerByGroup.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockListCustomerByGroup.quantitySum AS quantity, StockListCustomerByGroup.listCostSum AS listCost, StockListCustomerByGroup.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department, StockListCustomerByGroup.CustomerTransaction_CustomerID, StockListCustomerByGroup.Customer_InvoiceName, StockListCustomerByGroup.DayEndID, StockListCustomerByGroup.DayEnd_Date " ', StockListCustomerByGroup.CustomerTransactionID "
			//    sql = sql & "FROM StockListCustomerByGroup INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListCustomerByGroup.SaleItem_StockItemID = aStockItem1.StockItemID "
			//    sql = sql & "WHERE (((StockListCustomerByGroup.quantitySum)<>" & 0 & ")) "
			//    If lEmpID > 0 Then sql = sql & "AND (((StockListCustomerByGroup.CustomerTransaction_CustomerID)=" & lEmpID & ")) "
			//
			//    sql = Replace(sql, "StockGroup", "PricingGroup")
			//    Report.txtTitle.SetText "Product Performance - by Pricing Group"
			//    sql = sql & lOrder

			int lStkID = 0;

			lStkID = 0;
			if (Interaction.MsgBox("Do you wish to see report for all Stock Items?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) == MsgBoxResult.Yes) {
			} else {
				lStkID = My.MyProject.Forms.frmStockList.getItem();
				if (lStkID == 0)
					return;
			}

			sql = "SELECT aGRVItem.GRVItem_GRVID, aGRVItem.GRVItem_StockItemID, aGRVItem.GRVItem_Name, aGRVItem.GRVItem_QuantityOrder, aGRVItem.GRVItem_Quantity, aGRVItem.GRVItem_ContentCost, aGRV.GRV_InvoiceDate, Supplier.Supplier_Name, aGRVItem.GRVItem_ContentCost*aGRVItem.GRVItem_Quantity AS Expr1,";
			sql = sql + " (SELECT aGRVPromotionItem1.PromotionItem_Price FROM aGRVPromotion1 INNER JOIN aGRVPromotionItem1 ON aGRVPromotion1.PromotionID = aGRVPromotionItem1.PromotionItem_PromotionID WHERE (((aGRVPromotionItem1.PromotionItem_StockItemID)=aGRVItem.GRVItem_StockItemID) AND ((aGRVPromotion1.Promotion_StartDate)<=aGRV.GRV_InvoiceDate) AND ((aGRVPromotion1.Promotion_EndDate)>=aGRV.GRV_InvoiceDate))) AS DealPrice,";
			sql = sql + " (SELECT aGRVPromotion1.Promotion_Name FROM aGRVPromotion1 INNER JOIN aGRVPromotionItem1 ON aGRVPromotion1.PromotionID = aGRVPromotionItem1.PromotionItem_PromotionID WHERE (((aGRVPromotionItem1.PromotionItem_StockItemID)=aGRVItem.GRVItem_StockItemID) AND ((aGRVPromotion1.Promotion_StartDate)<=aGRV.GRV_InvoiceDate) AND ((aGRVPromotion1.Promotion_EndDate)>=aGRV.GRV_InvoiceDate))) AS DealName,";
			sql = sql + " aPurchaseOrder.PurchaseOrder_DateCreated, aGRV.GRV_Date FROM Report, (aGRVItem INNER JOIN aGRV ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN (aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) ON aGRV.GRV_PurchaseOrderID = aPurchaseOrder.PurchaseOrderID";
			//    sql = sql & " Where (((aGRVItem.GRVItem_StockItemID) = 698))"
			if (lStkID == 0) {
				sql = sql + " WHERE (((aGRV.GRV_DayEndID)>=[Report]![Report_DayEndStartID] And (aGRV.GRV_DayEndID)<=[Report]![Report_DayEndEndID]))";
			} else {
				sql = sql + " WHERE (((aGRVItem.GRVItem_StockItemID) = " + lStkID + ") AND ((aGRV.GRV_DayEndID)>=[Report]![Report_DayEndStartID] And (aGRV.GRV_DayEndID)<=[Report]![Report_DayEndEndID]))";
			}
			sql = sql + " ORDER BY aGRVItem.GRVItem_ContentCost;";

			Debug.Print(sql);
			rs = modReport.getRSreport(ref sql);
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			//Report.VerifyOnEveryPrint = True
			Report.Database.Tables(1).SetDataSource(rs);
			Report.SetDataSource(rs);
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		private static void report_ProductPerformanceCustomerByGroup()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			ADODB.Recordset rsData = default(ADODB.Recordset);
			//Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			string lOrder = null;
			CrystalDecisions.CrystalReports.Engine.FieldDefinition CRXDatabaseField = default(CrystalDecisions.CrystalReports.Engine.FieldDefinition);
			//Dim CRXDatabaseField As CrystalDecisions.CrystalReports.Engine.DatabaseFieldDefinition

			int lEmpID = 0;

			lEmpID = 0;
			if (Interaction.MsgBox("Do you wish to see report for all Customers?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) == MsgBoxResult.Yes) {
			} else {
				lEmpID = My.MyProject.Forms.frmCustomerList.getItem(ref 8);
				if (lEmpID == 0)
					return;
			}

			//Select Case Me.cmbSortField.ListIndex
			//        Case 0
			lOrder = "StockItem_Name";
			//        Case 1
			//            lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
			//        Case 2
			//            lOrder = "[exclusiveSum]-[depositSum]"
			//        Case 3
			//            lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
			//        Case 4
			//            lOrder = "IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum])"
			//        Case 5
			//            lOrder = "StockList.quantitySum"
			//End Select

			//If Me.cmbSort.ListIndex Then lOrder = lOrder & " DESC"
			lOrder = " ORDER BY " + lOrder;

			//UPGRADE_NOTE: Object Report may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			Report = null;

			//If Me.optType(0).value Then
			//    Set Report = New cryStockitemTopCustomer
			//ElseIf Me.optType(1).value Then
			//    Set Report = New cryStockitemTopByGroup
			//Else
			//Report = New cryStockitemTopGroupCustomer
			Report.Load("cryStockitemTopGroupCustomer.rpt");
			//End If
			//Do While Report.DataDefinition.SortFields.Count
			// 'Report.RecordSortFields.delete(1)
			// Loop

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();

			//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtFilter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (lEmpID == 0)
				Report.SetParameterValue("txtFilter", "All Customers");
			if (lEmpID > 0) {
				rs = modRecordSet.getRS(ref "SELECT Customer.Customer_InvoiceName AS MgrName From Customer WHERE (((Customer.CustomerID)=" + lEmpID + "));");
				Report.SetParameterValue("txtFilter", (lEmpID == 0 ? "All Customers" : rs.Fields("MgrName").Value));
			}
			//Set rs = getRSreport("SELECT * FROM Link Where LinkID=2 AND Link_SectionID=1")
			//Report.txtFilter.SetText Replace(rs("Link_Name"), "''", "'")

			//If Me.optType(0).value Then
			//    If rs("Link_SQL") <> "" Then
			//        sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
			//    Else
			//        Select Case Me.cmbSortField.ListIndex
			//            Case 0
			//sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
			sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockListCustomer.inclusiveSum) AS inclusive, Sum(StockListCustomer.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockListCustomer.quantitySum) AS quantity, Sum(StockListCustomer.listCostSum) AS listCost, Sum(StockListCustomer.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department, StockListCustomer.CustomerTransaction_CustomerID ";
			sql = sql + "FROM StockListCustomer INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListCustomer.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, StockListCustomer.CustomerTransaction_CustomerID HAVING (((StockListCustomer.CustomerTransaction_CustomerID)=" + lEmpID + ")) ";

			sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockListCustomerByGroup.inclusiveSum AS inclusive, StockListCustomerByGroup.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockListCustomerByGroup.quantitySum AS quantity, StockListCustomerByGroup.listCostSum AS listCost, StockListCustomerByGroup.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department, StockListCustomerByGroup.CustomerTransaction_CustomerID, StockListCustomerByGroup.Customer_InvoiceName, StockListCustomerByGroup.DayEndID, StockListCustomerByGroup.DayEnd_Date ";
			//, StockListCustomerByGroup.CustomerTransactionID "
			sql = sql + "FROM StockListCustomerByGroup INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListCustomerByGroup.SaleItem_StockItemID = aStockItem1.StockItemID ";
			sql = sql + "WHERE (((StockListCustomerByGroup.quantitySum)<>" + 0 + ")) ";
			//sql = sql & "GROUP BY aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockListCustomerByGroup.inclusiveSum, StockListCustomerByGroup.exclusiveSum, [exclusiveSum]-[depositSum], [exclusiveSum]-[depositSum], [exclusiveSum]-[depositSum]-[listCostSum], [exclusiveSum]-[depositSum]-[actualCostSum], StockListCustomerByGroup.quantitySum, StockListCustomerByGroup.listCostSum, StockListCustomerByGroup.actualCostSum, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0), IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0), aPricingGroup.PricingGroup_Name, StockListCustomerByGroup.CustomerTransaction_CustomerID, StockListCustomerByGroup.Customer_InvoiceName, StockListCustomerByGroup.DayEndID, StockListCustomerByGroup.DayEnd_Date, StockListCustomerByGroup.CustomerTransactionID "
			if (lEmpID > 0)
				sql = sql + "AND (((StockListCustomerByGroup.CustomerTransaction_CustomerID)=" + lEmpID + ")) ";
			//            Case 1
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) "
			//                'lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
			//            Case 2
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]) "
			//                'lOrder = "[exclusiveSum]-[depositSum]"
			//            Case 3
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) "
			//                'lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
			//            Case 4
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]) "
			//                'lOrder = "IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum])"
			//            Case 5
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, StockList.quantitySum "
			//                'lOrder = "StockList.quantitySum"
			//        End Select
			//    End If
			//
			//ElseIf Me.optType(1).value Then
			//    If rs("Link_SQL") <> "" Then
			//        sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
			//    Else
			//        Select Case Me.cmbSortField.ListIndex
			//            Case 0
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
			//            Case 1
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) "
			//                'lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
			//            Case 2
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]) "
			//                'lOrder = "[exclusiveSum]-[depositSum]"
			//            Case 3
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) "
			//                'lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
			//            Case 4
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]) "
			//                'lOrder = "IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum])"
			//            Case 5
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, StockList.quantitySum "
			//                'lOrder = "StockList.quantitySum"
			//        End Select
			//        'sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//        'sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
			//    End If
			//    Select Case Me.cmbGroup.ListIndex
			//        Case 0
			sql = Strings.Replace(sql, "StockGroup", "PricingGroup");
			Report.SetParameterValue("txtTitle", "Product Performance - by Pricing Group");
			//        Case 1
			//            Report.txtTitle.SetText "Product Performance - by Stock Group"
			//        Case 2
			//            sql = Replace(sql, "StockGroup", "Supplier")
			//            sql = Replace(sql, "aSupplier", "Supplier")
			//            Report.txtTitle.SetText "Product Performance - by Supplier"
			//        Case 3
			//            sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aReportGroup1.ReportGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aReportGroup1 ON aStockItem1.StockItem_ReportID = aReportGroup1.ReportID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
			//            Report.txtTitle.SetText "Product Performance - by Report Group"
			//    End Select
			//
			//    If Me.chkPageBreak.value Then
			//        Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = True
			//    Else
			//        Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = False
			//    End If
			//
			//Else
			//    'If rs("Link_SQL") <> "" Then
			//        sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
			//    'Else
			//    '    sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//    '    sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
			//    'End If
			//    Select Case Me.cmbGroup.ListIndex
			//        Case 0
			//            sql = Replace(sql, "StockGroup", "PricingGroup")
			//            Report.txtTitle.SetText "Product Performance - by Pricing Group"
			//        Case 1
			//            Report.txtTitle.SetText "Product Performance - by Stock Group"
			//        Case 2
			//            sql = Replace(sql, "StockGroup", "Supplier")
			//            sql = Replace(sql, "aSupplier", "Supplier")
			//            Report.txtTitle.SetText "Product Performance - by Supplier"
			//        Case 3
			//            sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aReportGroup1.ReportGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aReportGroup1 ON aStockItem1.StockItem_ReportID = aReportGroup1.ReportID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
			//            Report.txtTitle.SetText "Product Performance - by Report Group"
			//    End Select

			//    If Me.chkPageBreak.value Then
			//        Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = True
			//    Else
			//        Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = False
			//    End If
			//End If

			//for customer
			//SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aCustomer.Customer_InvoiceName AS department
			//FROM aCustomer INNER JOIN (CustomerTransaction INNER JOIN (Sale INNER JOIN (SaleItem INNER JOIN (StockList INNER JOIN aStockItem1 ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID) ON SaleItem.SaleItem_StockItemID = StockList.SaleItem_StockItemID) ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID
			//WHERE (((aCustomer.CustomerID)=2) AND ((CustomerTransaction.CustomerTransaction_TransactionTypeID)=2)) OR (((CustomerTransaction.CustomerTransaction_TransactionTypeID)=3));

			//If rs("Link_SQL") = "" Then
			//Else
			//    sql = sql & rs("Link_SQL")
			//End If

			sql = sql + lOrder;
			Debug.Print(sql);
			rs = modReport.getRSreport(ref sql);

			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			//Report.VerifyOnEveryPrint = True
			Report.Database.Tables(1).SetDataSource(rs);
			Report.SetDataSource(rs);
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		private static void report_ProductPerformanceCustomer()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			ADODB.Recordset rsData = default(ADODB.Recordset);
			//Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			string lOrder = null;
			CrystalDecisions.CrystalReports.Engine.FieldDefinition CRXDatabaseField = default(CrystalDecisions.CrystalReports.Engine.FieldDefinition);
			//Dim CRXDatabaseField As CrystalDecisions.CrystalReports.Engine.DatabaseFieldDefinition

			int lEmpID = 0;

			lEmpID = My.MyProject.Forms.frmCustomerList.getItem(ref 8);
			if (lEmpID == 0)
				return;

			//Select Case Me.cmbSortField.ListIndex
			//        Case 0
			lOrder = "StockItem_Name";
			//        Case 1
			//            lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
			//        Case 2
			//            lOrder = "[exclusiveSum]-[depositSum]"
			//        Case 3
			//            lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
			//        Case 4
			//            lOrder = "IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum])"
			//        Case 5
			//            lOrder = "StockList.quantitySum"
			//End Select

			//If Me.cmbSort.ListIndex Then lOrder = lOrder & " DESC"
			lOrder = " ORDER BY " + lOrder;

			//UPGRADE_NOTE: Object Report may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			Report = null;

			//If Me.optType(0).value Then
			Report.Load("cryStockitemTopCustomer.rpt");
			//ElseIf Me.optType(1).value Then
			//    Set Report = New cryStockitemTopByGroup
			//Else
			//    Set Report = New cryStockitemTopGroup
			//End If
			//[Do While Report.DataDefinition.SortFields.Count
			// 'Report.RecordSortFields.delete(1)
			// Loop

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();

			if (lEmpID > 0) {
				rs = modRecordSet.getRS(ref "SELECT Customer.Customer_InvoiceName AS MgrName From Customer WHERE (((Customer.CustomerID)=" + lEmpID + "));");
				Report.SetParameterValue("txtFilter", rs.Fields("MgrName"));
			}
			//Set rs = getRSreport("SELECT * FROM Link Where LinkID=2 AND Link_SectionID=1")
			//Report.txtFilter.SetText Replace(rs("Link_Name"), "''", "'")

			//If Me.optType(0).value Then
			//    If rs("Link_SQL") <> "" Then
			//        sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
			//    Else
			//        Select Case Me.cmbSortField.ListIndex
			//            Case 0
			//sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
			sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockListCustomer.inclusiveSum) AS inclusive, Sum(StockListCustomer.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockListCustomer.quantitySum) AS quantity, Sum(StockListCustomer.listCostSum) AS listCost, Sum(StockListCustomer.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department, StockListCustomer.CustomerTransaction_CustomerID ";
			sql = sql + "FROM StockListCustomer INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListCustomer.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, StockListCustomer.CustomerTransaction_CustomerID HAVING (((StockListCustomer.CustomerTransaction_CustomerID)=" + lEmpID + ")) ";

			//            Case 1
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) "
			//                'lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
			//            Case 2
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]) "
			//                'lOrder = "[exclusiveSum]-[depositSum]"
			//            Case 3
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) "
			//                'lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
			//            Case 4
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]) "
			//                'lOrder = "IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum])"
			//            Case 5
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, StockList.quantitySum "
			//                'lOrder = "StockList.quantitySum"
			//        End Select
			//    End If
			//
			//ElseIf Me.optType(1).value Then
			//    If rs("Link_SQL") <> "" Then
			//        sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
			//    Else
			//        Select Case Me.cmbSortField.ListIndex
			//            Case 0
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
			//            Case 1
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) "
			//                'lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
			//            Case 2
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]) "
			//                'lOrder = "[exclusiveSum]-[depositSum]"
			//            Case 3
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) "
			//                'lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
			//            Case 4
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]) "
			//                'lOrder = "IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum])"
			//            Case 5
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, StockList.quantitySum "
			//                'lOrder = "StockList.quantitySum"
			//        End Select
			//        'sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//        'sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
			//    End If
			//    Select Case Me.cmbGroup.ListIndex
			//        Case 0
			//            sql = Replace(sql, "StockGroup", "PricingGroup")
			//            Report.txtTitle.SetText "Product Performance - by Pricing Group"
			//        Case 1
			//            Report.txtTitle.SetText "Product Performance - by Stock Group"
			//        Case 2
			//            sql = Replace(sql, "StockGroup", "Supplier")
			//            sql = Replace(sql, "aSupplier", "Supplier")
			//            Report.txtTitle.SetText "Product Performance - by Supplier"
			//        Case 3
			//            sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aReportGroup1.ReportGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aReportGroup1 ON aStockItem1.StockItem_ReportID = aReportGroup1.ReportID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
			//            Report.txtTitle.SetText "Product Performance - by Report Group"
			//    End Select
			//
			//    If Me.chkPageBreak.value Then
			//        Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = True
			//    Else
			//        Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = False
			//    End If
			//
			//Else
			//    'If rs("Link_SQL") <> "" Then
			//        sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
			//    'Else
			//    '    sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//    '    sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
			//    'End If
			//    Select Case Me.cmbGroup.ListIndex
			//        Case 0
			//            sql = Replace(sql, "StockGroup", "PricingGroup")
			//            Report.txtTitle.SetText "Product Performance - by Pricing Group"
			//        Case 1
			//            Report.txtTitle.SetText "Product Performance - by Stock Group"
			//        Case 2
			//            sql = Replace(sql, "StockGroup", "Supplier")
			//            sql = Replace(sql, "aSupplier", "Supplier")
			//            Report.txtTitle.SetText "Product Performance - by Supplier"
			//        Case 3
			//            sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aReportGroup1.ReportGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aReportGroup1 ON aStockItem1.StockItem_ReportID = aReportGroup1.ReportID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
			//            Report.txtTitle.SetText "Product Performance - by Report Group"
			//    End Select

			//    If Me.chkPageBreak.value Then
			//        Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = True
			//    Else
			//        Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = False
			//    End If
			//End If

			//for customer
			//SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aCustomer.Customer_InvoiceName AS department
			//FROM aCustomer INNER JOIN (CustomerTransaction INNER JOIN (Sale INNER JOIN (SaleItem INNER JOIN (StockList INNER JOIN aStockItem1 ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID) ON SaleItem.SaleItem_StockItemID = StockList.SaleItem_StockItemID) ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID
			//WHERE (((aCustomer.CustomerID)=2) AND ((CustomerTransaction.CustomerTransaction_TransactionTypeID)=2)) OR (((CustomerTransaction.CustomerTransaction_TransactionTypeID)=3));

			//If rs("Link_SQL") = "" Then
			//Else
			//    sql = sql & rs("Link_SQL")
			//End If

			sql = sql + lOrder;
			Debug.Print(sql);
			rs = modReport.getRSreport(ref sql);

			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			//Report.VerifyOnEveryPrint = True
			Report.Database.Tables(1).SetDataSource(rs);
			Report.SetDataSource(rs);
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		private static void report_ProductPerformanceEmployee()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			ADODB.Recordset rsData = default(ADODB.Recordset);
			//Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			string lOrder = null;
			//Dim CRXDatabaseField As CrystalDecisions.CrystalReports.Engine.DatabaseFieldDefinition

			int lEmpID = 0;

			lEmpID = My.MyProject.Forms.frmPersonList.getItem();
			if (lEmpID == 0)
				return;

			//Select Case Me.cmbSortField.ListIndex
			//        Case 0
			lOrder = "StockItem_Name";
			//        Case 1
			//            lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
			//        Case 2
			//            lOrder = "[exclusiveSum]-[depositSum]"
			//        Case 3
			//            lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
			//        Case 4
			//            lOrder = "IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum])"
			//        Case 5
			//            lOrder = "StockList.quantitySum"
			//End Select

			//If Me.cmbSort.ListIndex Then lOrder = lOrder & " DESC"
			lOrder = " ORDER BY " + lOrder;

			//UPGRADE_NOTE: Object Report may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			Report = null;

			//If Me.optType(0).value Then
			Report.Load("cryStockitemTopEmployee.rpt");
			//ElseIf Me.optType(1).value Then
			//    Set Report = New cryStockitemTopByGroup
			//Else
			//    Set Report = New cryStockitemTopGroup
			//End If
			//Do While Report.DataDefinition.SortFields.Count
			//'Report.RecordSortFields.delete(1)
			//Loop

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();

			if (lEmpID > 0) {
				rs = modRecordSet.getRS(ref "SELECT Person.Person_FirstName & ' ' & Person.Person_LastName AS MgrName From Person WHERE (((Person.PersonID)=" + lEmpID + "));");
				Report.SetParameterValue("txtFilter", rs.Fields("MgrName"));
			}
			//Set rs = getRSreport("SELECT * FROM Link Where LinkID=2 AND Link_SectionID=1")
			//Report.txtFilter.SetText Replace(rs("Link_Name"), "''", "'")

			//If Me.optType(0).value Then
			//    If rs("Link_SQL") <> "" Then
			//        sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
			//    Else
			//        Select Case Me.cmbSortField.ListIndex
			//            Case 0
			//sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
			sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockListEmployee.inclusiveSum) AS inclusive, Sum(StockListEmployee.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockListEmployee.quantitySum) AS quantity, Sum(StockListEmployee.listCostSum) AS listCost, Sum(StockListEmployee.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department, StockListEmployee.Sale_PersonID ";
			sql = sql + "FROM StockListEmployee INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListEmployee.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, StockListEmployee.Sale_PersonID Having (((StockListEmployee.Sale_PersonID) = " + lEmpID + ")) ";

			//            Case 1
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) "
			//                'lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
			//            Case 2
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]) "
			//                'lOrder = "[exclusiveSum]-[depositSum]"
			//            Case 3
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) "
			//                'lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
			//            Case 4
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]) "
			//                'lOrder = "IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum])"
			//            Case 5
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, StockList.quantitySum "
			//                'lOrder = "StockList.quantitySum"
			//        End Select
			//    End If
			//
			//ElseIf Me.optType(1).value Then
			//    If rs("Link_SQL") <> "" Then
			//        sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
			//    Else
			//        Select Case Me.cmbSortField.ListIndex
			//            Case 0
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
			//            Case 1
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) "
			//                'lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
			//            Case 2
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]) "
			//                'lOrder = "[exclusiveSum]-[depositSum]"
			//            Case 3
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) "
			//                'lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
			//            Case 4
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]) "
			//                'lOrder = "IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum])"
			//            Case 5
			//                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, StockList.quantitySum "
			//                'lOrder = "StockList.quantitySum"
			//        End Select
			//        'sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//        'sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
			//    End If
			//    Select Case Me.cmbGroup.ListIndex
			//        Case 0
			//            sql = Replace(sql, "StockGroup", "PricingGroup")
			//            Report.txtTitle.SetText "Product Performance - by Pricing Group"
			//        Case 1
			//            Report.txtTitle.SetText "Product Performance - by Stock Group"
			//        Case 2
			//            sql = Replace(sql, "StockGroup", "Supplier")
			//            sql = Replace(sql, "aSupplier", "Supplier")
			//            Report.txtTitle.SetText "Product Performance - by Supplier"
			//        Case 3
			//            sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aReportGroup1.ReportGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aReportGroup1 ON aStockItem1.StockItem_ReportID = aReportGroup1.ReportID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
			//            Report.txtTitle.SetText "Product Performance - by Report Group"
			//    End Select
			//
			//    If Me.chkPageBreak.value Then
			//        Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = True
			//    Else
			//        Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = False
			//    End If
			//
			//Else
			//    'If rs("Link_SQL") <> "" Then
			//        sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
			//    'Else
			//    '    sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
			//    '    sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
			//    'End If
			//    Select Case Me.cmbGroup.ListIndex
			//        Case 0
			//            sql = Replace(sql, "StockGroup", "PricingGroup")
			//            Report.txtTitle.SetText "Product Performance - by Pricing Group"
			//        Case 1
			//            Report.txtTitle.SetText "Product Performance - by Stock Group"
			//        Case 2
			//            sql = Replace(sql, "StockGroup", "Supplier")
			//            sql = Replace(sql, "aSupplier", "Supplier")
			//            Report.txtTitle.SetText "Product Performance - by Supplier"
			//        Case 3
			//            sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aReportGroup1.ReportGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aReportGroup1 ON aStockItem1.StockItem_ReportID = aReportGroup1.ReportID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
			//            Report.txtTitle.SetText "Product Performance - by Report Group"
			//    End Select

			//    If Me.chkPageBreak.value Then
			//        Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = True
			//    Else
			//        Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = False
			//    End If
			//End If

			//for customer
			//SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aCustomer.Customer_InvoiceName AS department
			//FROM aCustomer INNER JOIN (CustomerTransaction INNER JOIN (Sale INNER JOIN (SaleItem INNER JOIN (StockList INNER JOIN aStockItem1 ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID) ON SaleItem.SaleItem_StockItemID = StockList.SaleItem_StockItemID) ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID
			//WHERE (((aCustomer.CustomerID)=2) AND ((CustomerTransaction.CustomerTransaction_TransactionTypeID)=2)) OR (((CustomerTransaction.CustomerTransaction_TransactionTypeID)=3));

			//If rs("Link_SQL") = "" Then
			//Else
			//    sql = sql & rs("Link_SQL")
			//End If

			sql = sql + lOrder;
			Debug.Print(sql);
			rs = modReport.getRSreport(ref sql);

			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			//Report.VerifyOnEveryPrint = True
			Report.Database.Tables(1).SetDataSource(rs);
			Report.SetDataSource(rs);
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		private static void report_WaitronTotals()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryWaitronTotals
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryWaitronTotals.rpt");
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();
			//Set rs = getRSreport("SELECT Sum(Sale.Sale_Total) AS amount, Sum(Sale.Sale_Cash) AS amountSale_Cash, Sum(Sale.Sale_Card) AS amountSale_Card, Sum(Sale.Sale_Cheque) AS amountSale_Cheque, Sum(Sale.Sale_CDebit) AS amountSale_CDebit, Count(Sale.SaleID) AS [count], Sum(Sale.Sale_Tender) AS tender, [Person_FirstName] & ' ' & [Person_LastName] AS personName, Count(Sale.Sale_TableNumber) AS tableCount, Sum(Sale.Sale_GuestCount) AS guestCount FROM (aPOS INNER JOIN Sale ON aPOS.POSID = Sale.Sale_PosID) INNER JOIN aPerson ON Sale.Sale_PersonID = aPerson.PersonID Where (((Sale.Sale_PersonID) > 0)) GROUP BY [Person_FirstName] & ' ' & [Person_LastName];")

			sql = "SELECT (Sum(Sale.Sale_Cash-iif(Sale.Sale_Cash>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0))+Sum(Sale.Sale_Card-iif(Sale.Sale_Card>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0))+Sum(Sale.Sale_Cheque-iif(Sale.Sale_Cheque>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0))+Sum(Sale.Sale_CDebit-iif(Sale.Sale_CDebit>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0))) AS amount, Sum(Sale.Sale_Cash-iif(Sale.Sale_Cash>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0)) AS amountSale_Cash, Sum(Sale.Sale_Card-iif(Sale.Sale_Card>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0)) AS amountSale_Card, ";
			sql = sql + "Sum(Sale.Sale_Cheque-iif(Sale.Sale_Cheque>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0)) AS amountSale_Cheque, Sum(Sale.Sale_CDebit-iif(Sale.Sale_CDebit>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0)) AS amountSale_CDebit, Count(Sale.SaleID) AS [count], Sum(Sale.Sale_Tender) AS tender, [Person_FirstName] & ' ' & [Person_LastName] AS personName, Count(Sale.Sale_TableNumber) AS tableCount, Sum(Sale.Sale_GuestCount) AS guestCount, Sum(Sale.Sale_Gratuity) AS amountSale_Gratuity, Sum(Sale.Sale_CDebit) AS amountTenderSale_CDebit, Sum(Sale.Sale_Total) AS amountTotal FROM (aPOS INNER JOIN Sale ON aPOS.POSID = Sale.Sale_PosID) INNER JOIN aPerson ON Sale.Sale_PersonID = aPerson.PersonID Where (((Sale.Sale_PersonID) > 0)) GROUP BY [Person_FirstName] & ' ' & [Person_LastName];";
			Debug.Print(sql);

			sql = "SELECT (Sum(Sale.Sale_Cash-IIf(Sale.Sale_Cash>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0))+Sum(Sale.Sale_Card-IIf(Sale.Sale_Card>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0))+Sum(Sale.Sale_Cheque-IIf(Sale.Sale_Cheque>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0))+Sum(Sale.Sale_CDebit-IIf(Sale.Sale_CDebit>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0))) AS amount, Sum(Sale.Sale_Cash-IIf(Sale.Sale_Cash>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0)) AS amountSale_Cash, Sum(Sale.Sale_Card-IIf(Sale.Sale_Card>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0)) AS amountSale_Card, Sum(Sale.Sale_Cheque-IIf(Sale.Sale_Cheque>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0)) AS amountSale_Cheque, Sum(Sale.Sale_CDebit-IIf(Sale.Sale_CDebit>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0)) AS amountSale_CDebit, ";
			sql = sql + "Count(Sale.SaleID) AS [count], Sum(Sale.Sale_Tender) AS tender, [Person_FirstName] & ' ' & [Person_LastName] AS personName, Count(Sale.Sale_TableNumber) AS tableCount, Sum(Sale.Sale_GuestCount) AS guestCount, Sum(Sale.Sale_Gratuity) AS amountSale_Gratuity, Sum(Sale.Sale_CDebit) AS amountTenderSale_CDebit, Sum(Sale.Sale_Total) AS amountTotal, Sum(IIf(CustomerTransaction.CustomerTransaction_Amount<0,CustomerTransaction.CustomerTransaction_Amount,0)) AS AccSale, Sum(IIf(CustomerTransaction.CustomerTransaction_Amount > 0, CustomerTransaction.CustomerTransaction_Amount, 0)) As AccAmount FROM ((aPOS INNER JOIN Sale ON aPOS.POSID = Sale.Sale_PosID) INNER JOIN aPerson ON Sale.Sale_PersonID = aPerson.PersonID) LEFT JOIN CustomerTransaction ON Sale.SaleID = CustomerTransaction.CustomerTransaction_ReferenceID Where (((Sale.Sale_PersonID) > 0)) GROUP BY [Person_FirstName] & ' ' & [Person_LastName];";

			sql = "SELECT (Sum(Sale.Sale_Cash-IIf(Sale.Sale_Cash>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0))+Sum(Sale.Sale_Card-IIf(Sale.Sale_Card>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0))+Sum(Sale.Sale_Cheque-IIf(Sale.Sale_Cheque>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0))+Sum(Sale.Sale_CDebit-IIf(Sale.Sale_CDebit>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0)))+(Sum(IIf(CustomerTransaction.CustomerTransaction_Amount<0,CustomerTransaction.CustomerTransaction_Amount,0))) AS amount, Sum(Sale.Sale_Cash-IIf(Sale.Sale_Cash>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0))+(Sum(IIf(CustomerTransaction.CustomerTransaction_Amount<0,CustomerTransaction.CustomerTransaction_Amount,0))) AS amountSale_Cash, Sum(Sale.Sale_Card-IIf(Sale.Sale_Card>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0)) AS amountSale_Card, Sum(Sale.Sale_Cheque-IIf(Sale.Sale_Cheque>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0)) AS amountSale_Cheque, Sum(Sale.Sale_CDebit-IIf(Sale.Sale_CDebit>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0)) AS amountSale_CDebit, ";
			sql = sql + "Count(Sale.SaleID) AS [count], Sum(Sale.Sale_Tender) AS tender, [Person_FirstName] & ' ' & [Person_LastName] AS personName, Count(Sale.Sale_TableNumber) AS tableCount, Sum(Sale.Sale_GuestCount) AS guestCount, Sum(Sale.Sale_Gratuity) AS amountSale_Gratuity, Sum(Sale.Sale_CDebit) AS amountTenderSale_CDebit, Sum(Sale.Sale_Total) AS amountTotal, Sum(IIf(CustomerTransaction.CustomerTransaction_Amount<0,CustomerTransaction.CustomerTransaction_Amount,0)) AS AccSale, Sum(IIf(CustomerTransaction.CustomerTransaction_Amount > 0, CustomerTransaction.CustomerTransaction_Amount, 0)) AS AccAmount FROM ((aPOS INNER JOIN Sale ON aPOS.POSID = Sale.Sale_PosID) INNER JOIN aPerson ON Sale.Sale_PersonID = aPerson.PersonID) LEFT JOIN CustomerTransaction ON Sale.SaleID = CustomerTransaction.CustomerTransaction_ReferenceID Where (((Sale.Sale_PersonID) > 0)) GROUP BY [Person_FirstName] & ' ' & [Person_LastName];";
			rs = modReport.getRSreport(ref sql);

			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.Database.Tables(1).SetDataSource(rs);
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		private static void report_ProfitByDayEnd()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryProfitByDayEnd
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryProfitByDayEnd.rpt");
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();
			sql = "SELECT DayEnd.DayEndID, DayEnd.DayEnd_Date, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ActualCost]*[SaleItem_Quantity],[SaleItem_ActualCost]*[SaleItem_Quantity])) AS actualExcl, Sum(((IIf([SaleItem_Reversal],0-[SaleItem_ActualCost]*[SaleItem_Quantity],[SaleItem_ActualCost]*[SaleItem_Quantity]))*(1+[SaleItem_Vat]/100))) AS actualIncl, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ListCost]*[SaleItem_Quantity],[SaleItem_ListCost]*[SaleItem_Quantity])) AS listExcl, Sum(((IIf([SaleItem_Reversal],0-[SaleItem_ListCost]*[SaleItem_Quantity],[SaleItem_ListCost]*[SaleItem_Quantity]))*(1+[SaleItem_Vat]/100))) AS listIncl, Sum(([SaleItem_Price]*[SaleItem_Quantity]/(1+[SaleItem_Vat]/100))) AS priceExcl, Sum(([SaleItem_Price]*[SaleItem_Quantity])) AS priceIncl, Sum(IIf([SaleItem_Reversal],0-[SaleItem_DepositCost]*[SaleItem_Quantity],[SaleItem_DepositCost]*[SaleItem_Quantity])) AS depositExcl, ";
			sql = sql + "Sum((IIf([SaleItem_Reversal],0-[SaleItem_DepositCost]*[SaleItem_Quantity],[SaleItem_DepositCost]*[SaleItem_Quantity]))*(1+[SaleItem_Vat]/100)) AS depositIncl FROM (Sale INNER JOIN (aConsignment AS aConsignment_1 RIGHT JOIN (SaleItem LEFT JOIN aConsignment ON SaleItem.SaleItem_SaleID = aConsignment.Consignment_SaleID) ON aConsignment_1.Consignment_ReversalSaleID = SaleItem.SaleItem_SaleID) ON Sale.SaleID = SaleItem.SaleItem_SaleID) INNER JOIN DayEnd ON Sale.Sale_DayEndID = DayEnd.DayEndID Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY DayEnd.DayEndID, DayEnd.DayEnd_Date ORDER BY DayEnd.DayEndID;";
			rs = modReport.getRSreport(ref sql);

			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.Database.Tables(1).SetDataSource(rs);
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}
		private static void report_Outage()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsDayEnd = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryOutage
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("crtOutage.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();

			sql = "SELECT Declaration.Declaration_DayEndID, aPOS.POSID, aPOS.POS_Name, Sum(Declaration.Declaration_Cash) AS SumOfDeclaration_Cash, Sum(Declaration.Declaration_CashServer) AS SumOfDeclaration_CashServer, Sum(Declaration.Declaration_CashCount) AS SumOfDeclaration_CashCount, Sum(Declaration.Declaration_Cheque) AS SumOfDeclaration_Cheque, Sum(Declaration.Declaration_ChequeServer) AS SumOfDeclaration_ChequeServer, Sum(Declaration.Declaration_ChequeCount) AS SumOfDeclaration_ChequeCount, Sum(Declaration.Declaration_Card) AS SumOfDeclaration_Card, Sum(Declaration.Declaration_CardServer) AS SumOfDeclaration_CardServer, Sum(Declaration.Declaration_CardCount) AS SumOfDeclaration_CardCount, Sum(Declaration.Declaration_Payout) AS SumOfDeclaration_Payout, Sum(Declaration.Declaration_PayoutServer) AS SumOfDeclaration_PayoutServer, Sum(Declaration.Declaration_PayoutCount) AS SumOfDeclaration_PayoutCount ";
			sql = sql + "FROM Declaration INNER JOIN aPOS ON Declaration.Declaration_POSID = aPOS.POSID GROUP BY Declaration.Declaration_DayEndID, aPOS.POSID, aPOS.POS_Name;";

			rs = modReport.getRSreport(ref sql);
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			rsDayEnd = modReport.getRSreport(ref "SELECT * FROM DayEnd");
			Report.Database.Tables(1).SetDataSource(rsDayEnd);

			Report.Database.Tables(2).SetDataSource(rs);

			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}
		private static void report_Payout()
		{
			ADODB.Recordset rsDayEnd = default(ADODB.Recordset);
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryPayout
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryPayout.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();
			sql = "SELECT * FROM Payout";
			rs = modReport.getRSreport(ref sql);
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			rsDayEnd = modReport.getRSreport(ref "SELECT * FROM DayEnd");
			Report.Database.Tables(1).SetDataSource(rsDayEnd);

			Report.Database.Tables(2).SetDataSource(rs);

			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		private static void report_PayoutReason()
		{
			ADODB.Recordset rsDayEnd = default(ADODB.Recordset);
			string lPGID = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryPayout
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryPayout.rpt");
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();
			if (Interaction.MsgBox("Do you wish to see All Payouts?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) == MsgBoxResult.Yes) {
				sql = "SELECT Payout.* From Payout ORDER BY Payout.PayoutID;";
			} else {
				lPGID = My.MyProject.Forms.frmPayoutGroupList.getItem();
				sql = "SELECT Payout.* From aPayoutGroup1, Payout WHERE (((aPayoutGroup1.PayoutGroup_Name)=(Left([Payout].[Payout_Narrative],Len([aPayoutGroup1].[PayoutGroup_Name])))) AND ((aPayoutGroup1.PayoutGroupID)=" + lPGID + "));";
			}
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref sql);
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			rsDayEnd = modReport.getRSreport(ref "SELECT * FROM DayEnd");
			Report.Database.Tables(1).SetDataSource(rsDayEnd);

			Report.Database.Tables(2).SetDataSource(rs);

			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		private static void report_HourlyReport()
		{
			ADODB.Recordset rsSale = default(ADODB.Recordset);
			decimal SumSales = default(decimal);
			string sql2 = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryHourlyReport
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryHourlyReport.rpt");

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();
			sql = "SELECT * FROM Sale";
			rs = modReport.getRSreport(ref sql);
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			sql2 = "SELECT SaleItem.SaleItem_StockItemID, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ActualCost]*[SaleItem_Quantity],[SaleItem_ActualCost]*[SaleItem_Quantity])) AS actualCostSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ListCost]*[SaleItem_Quantity],[SaleItem_ListCost]*[SaleItem_Quantity])) AS listCostSum, Sum(([SaleItem_Price]*[SaleItem_Quantity]/(1+[SaleItem_Vat]/100))) AS exclusiveSum, Sum(([SaleItem_Price]*[SaleItem_Quantity])) AS inclusiveSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_DepositCost]*[SaleItem_Quantity],[SaleItem_DepositCost]*[SaleItem_Quantity])) AS depositSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) AS quantitySum FROM Sale INNER JOIN (aConsignment AS aConsignment_1 RIGHT JOIN (SaleItem LEFT JOIN aConsignment ON SaleItem.SaleItem_SaleID=aConsignment.Consignment_SaleID) ON aConsignment_1.Consignment_ReversalSaleID=SaleItem.SaleItem_SaleID) ON Sale.SaleID=SaleItem.SaleItem_SaleID" + " Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null))" + " GROUP BY SaleItem.SaleItem_StockItemID;";

			rsSale = modReport.getRSreport(ref sql2);
			while (rsSale.EOF == false) {
				SumSales = SumSales + rsSale.Fields("inclusiveSum").Value;

				rsSale.moveNext();
			}

			Report.Database.Tables(1).SetDataSource(rs);

			Report.SetParameterValue("txtSum", Strings.FormatNumber(SumSales, 2));

			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}
		private static void report_SalesVat()
		{
			ADODB.Recordset rsDep = default(ADODB.Recordset);
			int txtStockDepositReturn = 0;
			int txtStockDepositSold = 0;
			string sql2 = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			decimal vInSales = default(decimal);
			decimal vExSales = default(decimal);
			decimal vTaxSales = default(decimal);
			decimal vVatSales = default(decimal);
			decimal vNonTaxSales = default(decimal);
			ADODB.Recordset rsSales = default(ADODB.Recordset);
			ADODB.Recordset rsSalesTotal = default(ADODB.Recordset);
			ADODB.Recordset rsDiscount = default(ADODB.Recordset);

			string sql = null;
			//Dim Report As New CryVreporting
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("CryVreporting.rpt");
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();

			sql2 = "SELECT SaleItem.SaleItem_StockItemID, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ActualCost]*[SaleItem_Quantity],[SaleItem_ActualCost]*[SaleItem_Quantity])) AS actualCostSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ListCost]*[SaleItem_Quantity],[SaleItem_ListCost]*[SaleItem_Quantity])) AS listCostSum, Sum(([SaleItem_Price]*[SaleItem_Quantity]/(1+[SaleItem_Vat]/100))) AS exclusiveSum, Sum(([SaleItem_Price]*[SaleItem_Quantity])) AS inclusiveSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_DepositCost]*[SaleItem_Quantity],[SaleItem_DepositCost]*[SaleItem_Quantity])) AS depositSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) AS quantitySum FROM Sale INNER JOIN (aConsignment AS aConsignment_1 RIGHT JOIN (SaleItem LEFT JOIN aConsignment ON SaleItem.SaleItem_SaleID=aConsignment.Consignment_SaleID) ON aConsignment_1.Consignment_ReversalSaleID=SaleItem.SaleItem_SaleID) ON Sale.SaleID=SaleItem.SaleItem_SaleID" + " Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null))" + " GROUP BY SaleItem.SaleItem_StockItemID;";

			rsSales = modReport.getRSreport(ref sql2);

			if (rsSales.BOF | rsSales.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			sql2 = "SELECT SaleItem.SaleItem_StockItemID, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ActualCost]*[SaleItem_Quantity],[SaleItem_ActualCost]*[SaleItem_Quantity])) AS actualCostSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ListCost]*[SaleItem_Quantity],[SaleItem_ListCost]*[SaleItem_Quantity])) AS listCostSum, Sum(([SaleItem_Price]*[SaleItem_Quantity]/(1+[SaleItem_Vat]/100))) AS exclusiveSum, Sum(([SaleItem_Price]*[SaleItem_Quantity])) AS inclusiveSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_DepositCost]*[SaleItem_Quantity],[SaleItem_DepositCost]*[SaleItem_Quantity])) AS depositSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) AS quantitySum FROM Sale INNER JOIN (aConsignment AS aConsignment_1 RIGHT JOIN (SaleItem LEFT JOIN aConsignment ON SaleItem.SaleItem_SaleID=aConsignment.Consignment_SaleID) ON aConsignment_1.Consignment_ReversalSaleID=SaleItem.SaleItem_SaleID) ON Sale.SaleID=SaleItem.SaleItem_SaleID" + " Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null))" + " GROUP BY SaleItem.SaleItem_StockItemID;";

			rsSalesTotal = modReport.getRSreport(ref sql2);

			while (rsSalesTotal.EOF == false) {
				vInSales = vInSales + rsSalesTotal.Fields("inclusiveSum").Value;

				vExSales = vExSales + rsSalesTotal.Fields("exclusiveSum").Value;

				if (rsSalesTotal.Fields("inclusiveSum").Value == rsSalesTotal.Fields("exclusiveSum").Value) {
					vNonTaxSales = vNonTaxSales + rsSalesTotal.Fields("inclusiveSum").Value;
				} else {
					vTaxSales = vTaxSales + rsSalesTotal.Fields("exclusiveSum").Value;
				}
				rsSalesTotal.moveNext();
			}

			txtStockDepositSold = 0;
			//UPGRADE_WARNING: Couldn't resolve default property of object txtStockDepositReturn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtStockDepositReturn = 0;
			rsDep = modReport.getRSreport(ref "SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS content, CBool([SaleItem_DepositType]) AS depositType, SaleItem.SaleItem_Reversal, Sum(([SaleItem_DepositCost]*[SaleItem_Quantity])*(1+[SaleItem_Vat]/100)) AS deposit FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY CBool([SaleItem_DepositType]), SaleItem.SaleItem_Reversal;");
			while (!(rsDep.EOF)) {
				if (rsDep("depositType").Value) {
					if (rsDep("SaleItem_Reversal").Value) {
						txtStockDepositSold = rsDep("content").Value;
					} else {
						txtStockDepositReturn = rsDep("content").Value;
					}
				} else {
					//            If rsDep("SaleItem_Reversal") Then
					//                Report.txtStockCreditContent.SetText FormatNumber(rsDep("content"), 2)
					//                Report.txtStockCreditDeposit.SetText FormatNumber(0 - rsDep("deposit"), 2)
					//
					//            Else
					//                Report.txtStockSoldContent.SetText FormatNumber(rsDep("content"), 2)
					//                Report.txtStockSoldDeposit.SetText FormatNumber(rsDep("deposit"), 2)
					//            End If
				}
				rsDep.moveNext();
			}
			rsDep.Close();
			vInSales = vInSales + (txtStockDepositSold + txtStockDepositReturn);
			vExSales = vExSales + (txtStockDepositSold + txtStockDepositReturn);
			vVatSales = vInSales - vExSales;

			//do invoice discount
			rsDiscount = modReport.getRSreport(ref "SELECT Sum(Sale.Sale_Discount) AS amount FROM aConsignment RIGHT JOIN (aConsignment AS aConsignment_1 RIGHT JOIN Sale ON aConsignment_1.Consignment_SaleID = Sale.SaleID) ON aConsignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null));");
			if (Information.IsDBNull(rsDiscount.Fields("amount").Value)) {
				Report.SetParameterValue("txtDiscountsGiven", "0.00");
			} else {
				if (rsDiscount.RecordCount) {
					Report.SetParameterValue("txtDiscountsGiven", Strings.FormatNumber(0 - rsDiscount.Fields("amount").Value, 2));
				} else {
					Report.SetParameterValue("txtDiscountsGiven", "0.00");
				}
			}

			Report.Database.Tables(1).SetDataSource(rsSales);
			Report.SetParameterValue("txtInSales", Strings.FormatNumber(vInSales, 2));
			Report.SetParameterValue("txtExSales", Strings.FormatNumber(vExSales, 2));
			Report.SetParameterValue("txtTaxSales", Strings.FormatNumber(vTaxSales, 2));
			Report.SetParameterValue("txtVatSales", Strings.FormatNumber(vVatSales, 2));
			Report.SetParameterValue("txtNonTaxSales", Strings.FormatNumber(vNonTaxSales, 2));

			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}
		private static void report_VATrepporting()
		{
			int rDepPurIVat = 0;
			int txtStockDepositReturn = 0;
			int txtStockDepositSold = 0;
			string sql2 = null;
			decimal vl_Charged = default(decimal);
			ADODB.Recordset rs = default(ADODB.Recordset);
			decimal vInSales = default(decimal);
			decimal vExSales = default(decimal);
			decimal vTaxSales = default(decimal);
			decimal vVatSales = default(decimal);
			decimal vNonTaxSales = default(decimal);
			ADODB.Recordset rNar = default(ADODB.Recordset);
			//Tax Narrative purpose
			ADODB.Recordset rsGRVItem = default(ADODB.Recordset);
			ADODB.Recordset rsGRVMain = default(ADODB.Recordset);
			ADODB.Recordset rsGRVDeposit = default(ADODB.Recordset);
			ADODB.Recordset rsGRVPricing = default(ADODB.Recordset);
			ADODB.Recordset rsGRVItemReturn = default(ADODB.Recordset);
			ADODB.Recordset rsGRVDepositReturn = default(ADODB.Recordset);
			ADODB.Recordset rsSalesTotal = default(ADODB.Recordset);
			ADODB.Recordset rPurchases = default(ADODB.Recordset);
			//do purchases list
			ADODB.Recordset rDayEndPur = default(ADODB.Recordset);
			//2 get the day ends
			decimal rPurEVat = default(decimal);
			decimal rPurIVat = default(decimal);
			ADODB.Recordset rsDiscount = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New Cryreporting
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("Cryreporting.rpt");
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();

			rsGRVItem = modReport.getRSreport(ref "SELECT aGRV.GRVID, Sum(IIf([GRVItem_Return],0,(((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])))) AS exclusive, Sum(IIf([GRVItem_Return],0,((((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100))))) AS inclusive, Sum(IIf([GRVItem_Return],0,[GRVItem_DepositCost]*[GRVItem_Quantity])) AS depositExcl, Sum(IIf([GRVItem_Return],0,([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100))) AS depositIncl FROM (aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) LEFT JOIN aGRVItem ON aGRV.GRVID = aGRVItem.GRVItem_GRVID Where (((aGRV.GRV_GRVStatusID) = 3) AND (GRVItem_StockItemQuantity <> 0)) GROUP BY aGRV.GRVID;");

			if (rsGRVItem.BOF | rsGRVItem.EOF) {
				report_SalesVat();
				return;
			}

			rsGRVItemReturn = modReport.getRSreport(ref "SELECT aGRV.GRVID, Sum(IIf([GRVItem_Return],(((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])),0)) AS exclusive, Sum(IIf([GRVItem_Return],((((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100))),0)) AS inclusive, Sum(IIf([GRVItem_Return],[GRVItem_DepositCost]*[GRVItem_Quantity],0)) AS depositExcl, Sum(IIf([GRVItem_Return],([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100),0)) AS depositIncl FROM (aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) LEFT JOIN aGRVItem ON aGRV.GRVID = aGRVItem.GRVItem_GRVID Where (((aGRV.GRV_GRVStatusID) = 3)) GROUP BY aGRV.GRVID;");
			rsGRVDeposit = modReport.getRSreport(ref "SELECT aGRV.GRVID, Sum(IIf([GRVDeposit_Return],0,(IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,[GRVDeposit_Quantity]*([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]*(1+[GRVDeposit_VatRate]/100)),0))+(IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,[GRVDeposit_quantity]*([GRVDeposit_CaseCost]*(1+[GRVDeposit_VatRate]/100)),0)))) AS inclusiveDepositReturn, Sum(IIf([GRVDeposit_Return],0,(IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,[GRVDeposit_Quantity]*([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]),0))+(IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,[GRVDeposit_quantity]*([GRVDeposit_CaseCost]),0)))) AS exclusiveDepositReturn FROM (aGRV LEFT JOIN aGRVDeposit ON aGRV.GRVID = aGRVDeposit.GRVDeposit_GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID Where (((aGRV.GRV_GRVStatusID) = 3)) GROUP BY aGRV.GRVID;");
			rsGRVDepositReturn = modReport.getRSreport(ref "SELECT aGRV.GRVID, Sum(IIf([GRVDeposit_Return],(IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,[GRVDeposit_Quantity]*([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]*(1+[GRVDeposit_VatRate]/100)),0))+(IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,[GRVDeposit_quantity]*([GRVDeposit_CaseCost]*(1+[GRVDeposit_VatRate]/100)),0)),0)) AS inclusiveDepositReturn, Sum(IIf([GRVDeposit_Return],(IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,[GRVDeposit_Quantity]*([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]),0))+(IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,[GRVDeposit_quantity]*([GRVDeposit_CaseCost]),0)),0)) AS exclusiveDepositReturn FROM (aGRV LEFT JOIN aGRVDeposit ON aGRV.GRVID = aGRVDeposit.GRVDeposit_GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID Where (((aGRV.GRV_GRVStatusID) = 3)) GROUP BY aGRV.GRVID;");
			//Set rsGRVMain = getRSreport("SELECT aGRV.GRVID, aGRV.GRV_InvoiceInclusive, aGRV.GRV_InvoiceVat, aGRV.GRV_InvoiceDiscount, aGRV.GRV_SundriesPlus, aGRV.GRV_SundriesMinus, aGRV.GRV_ContentExclusive, ([GRV_ContentExclusive]*(1+[GRV_Ullage]/100)-[GRV_ContentExclusive]) AS Ullage, (1+[GRV_InvoiceVat]/([GRV_InvoiceInclusive]-[GRV_InvoiceVat])) AS vat, Supplier.SupplierID, Supplier.Supplier_Name, aPurchaseOrder.PurchaseOrder_Reference, aGRV.GRV_InvoiceNumber, aGRV.GRV_InvoiceDate FROM ((aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aPurchaseOrder ON aGRV.GRV_PurchaseOrderID = aPurchaseOrder.PurchaseOrderID) INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID WHERE (((aGRV.GRV_GRVStatusID)=3) AND ((aGRV.GRV_InvoiceInclusive)<>0));")
			rsGRVMain = modReport.getRSreport(ref "SELECT aGRV.GRVID, aGRV.GRV_InvoiceInclusive, aGRV.GRV_InvoiceVat, aGRV.GRV_InvoiceDiscount, aGRV.GRV_SundriesPlus, aGRV.GRV_SundriesMinus, aGRV.GRV_ContentExclusive, ([GRV_ContentExclusive]*(1+[GRV_Ullage]/100)-[GRV_ContentExclusive]) AS Ullage, (1+[GRV_InvoiceVat]/ IIf(([GRV_InvoiceInclusive]-[GRV_InvoiceVat])=0,1,([GRV_InvoiceInclusive]-[GRV_InvoiceVat]))) AS vat, Supplier.SupplierID, Supplier.Supplier_Name, aPurchaseOrder.PurchaseOrder_Reference, aGRV.GRV_InvoiceNumber, aGRV.GRV_InvoiceDate FROM ((aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aPurchaseOrder ON aGRV.GRV_PurchaseOrderID = aPurchaseOrder.PurchaseOrderID) INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID WHERE (((aGRV.GRV_GRVStatusID)=3) AND ((aGRV.GRV_InvoiceInclusive)<>0));");

			sql = "SELECT aGRV.GRVID, Sum((([GRVItem_PackSize]/[GRVItem_StockItemQuantity])*[GRVItem_ContentCost]-[GRVItem_DiscountAmount])*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))) AS exclusive, Sum((([GRVItem_PackSize]/[GRVItem_StockItemQuantity])*[GRVItem_ContentCost]-[GRVItem_DiscountAmount])*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))*(1+[GRVItem_VatRate]/100)) AS inclusive, Sum((([GRVItem_PackSize]/[GRVItem_StockItemQuantity])*[GRVItem_ContentCost])*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))) AS PriceExcl, Sum((([GRVItem_PackSize]/[GRVItem_StockItemQuantity])*[GRVItem_ContentCost])*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))*(1+[GRVItem_VatRate]/100)) AS PriceIncl, Sum([DayEndStockItemLnk_ListCost]*[GRVItem_PackSize]*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))) AS listExcl, Sum([DayEndStockItemLnk_ListCost]*[GRVItem_PackSize]*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))*(1+[GRVItem_VatRate]/100)) AS listIncl, ";
			sql = sql + "Sum([DayEndStockItemLnk_ActualCost]*[GRVItem_PackSize]*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))*(1+[GRVItem_VatRate]/100)) AS actualIncl, Sum([DayEndStockItemLnk_ActualCost]*[GRVItem_PackSize]*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))) AS actualExcl FROM DayEndStockItemLnk INNER JOIN ((aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aGRVItem ON aGRV.GRVID = aGRVItem.GRVItem_GRVID) ON (DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aGRVItem.GRVItem_StockItemID) AND (DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aGRV.GRV_DayEndID) Where (((aGRV.GRV_GRVStatusID) = 3) AND (GRVItem_StockItemQuantity <> 0)) GROUP BY aGRV.GRVID;";

			rsGRVPricing = modReport.getRSreport(ref sql);

			if (rsGRVPricing.BOF | rsGRVPricing.EOF) {
				report_SalesVat();
				return;
			}

			sql2 = "SELECT SaleItem.SaleItem_StockItemID, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ActualCost]*[SaleItem_Quantity],[SaleItem_ActualCost]*[SaleItem_Quantity])) AS actualCostSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ListCost]*[SaleItem_Quantity],[SaleItem_ListCost]*[SaleItem_Quantity])) AS listCostSum, Sum(([SaleItem_Price]*[SaleItem_Quantity]/(1+[SaleItem_Vat]/100))) AS exclusiveSum, Sum(([SaleItem_Price]*[SaleItem_Quantity])) AS inclusiveSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_DepositCost]*[SaleItem_Quantity],[SaleItem_DepositCost]*[SaleItem_Quantity])) AS depositSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) AS quantitySum FROM Sale INNER JOIN (aConsignment AS aConsignment_1 RIGHT JOIN (SaleItem LEFT JOIN aConsignment ON SaleItem.SaleItem_SaleID=aConsignment.Consignment_SaleID) ON aConsignment_1.Consignment_ReversalSaleID=SaleItem.SaleItem_SaleID) ON Sale.SaleID=SaleItem.SaleItem_SaleID" + " Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null))" + " GROUP BY SaleItem.SaleItem_StockItemID;";

			rsSalesTotal = modReport.getRSreport(ref sql2);

			while (rsSalesTotal.EOF == false) {
				vInSales = vInSales + rsSalesTotal.Fields("inclusiveSum").Value;

				vExSales = vExSales + rsSalesTotal.Fields("exclusiveSum").Value;

				if (rsSalesTotal.Fields("inclusiveSum").Value == rsSalesTotal.Fields("exclusiveSum").Value) {
					vNonTaxSales = vNonTaxSales + rsSalesTotal.Fields("inclusiveSum").Value;
				} else {
					vTaxSales = vTaxSales + rsSalesTotal.Fields("exclusiveSum").Value;
				}


				rsSalesTotal.moveNext();
			}

			//deposit calculation
			txtStockDepositSold = 0;
			txtStockDepositReturn = 0;
			ADODB.Recordset rsDep = default(ADODB.Recordset);
			rsDep = modReport.getRSreport(ref "SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS content, CBool([SaleItem_DepositType]) AS depositType, SaleItem.SaleItem_Reversal, Sum(([SaleItem_DepositCost]*[SaleItem_Quantity])*(1+[SaleItem_Vat]/100)) AS deposit FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY CBool([SaleItem_DepositType]), SaleItem.SaleItem_Reversal;");
			if (rsDep.RecordCount) {
				while (!(rsDep.EOF)) {
					if (rsDep.Fields("depositType").Value) {
						if (rsDep.Fields("SaleItem_Reversal").Value) {
							txtStockDepositSold = rsDep.Fields("content").Value;
						} else {
							txtStockDepositReturn = rsDep.Fields("content").Value;
						}
					} else {
						//            If rsDep("SaleItem_Reversal") Then
						//                Report.txtStockCreditContent.SetText FormatNumber(rsDep("content"), 2)
						//                Report.txtStockCreditDeposit.SetText FormatNumber(0 - rsDep("deposit"), 2)
						//
						//            Else
						//                Report.txtStockSoldContent.SetText FormatNumber(rsDep("content"), 2)
						//                Report.txtStockSoldDeposit.SetText FormatNumber(rsDep("deposit"), 2)
						//            End If
					}
					rsDep.moveNext();
				}
				rsDep.Close();
			}
			vInSales = vInSales + (txtStockDepositSold + txtStockDepositReturn);
			vExSales = vExSales + (txtStockDepositSold + txtStockDepositReturn);
			vVatSales = vInSales - vExSales;

			rPurIVat = 0;
			rPurEVat = 0;

			//get ID's from DayEnd
			rDayEndPur = modReport.getRSreport(ref "SELECT aGRV.GRVID,aGRV.GRV_DayEndID, aGRV.GRV_InvoiceInclusive, aGRV.GRV_InvoiceVat, aGRV.GRV_InvoiceDiscount, aGRV.GRV_SundriesPlus, aGRV.GRV_SundriesMinus, aGRV.GRV_ContentExclusive, ([GRV_ContentExclusive]*(1+[GRV_Ullage]/100)-[GRV_ContentExclusive]) AS Ullage, (1+[GRV_InvoiceVat]/ IIf(([GRV_InvoiceInclusive]-[GRV_InvoiceVat])=0,1,([GRV_InvoiceInclusive]-[GRV_InvoiceVat]))) AS vat, Supplier.SupplierID, Supplier.Supplier_Name, aPurchaseOrder.PurchaseOrder_Reference, aGRV.GRV_InvoiceNumber, aGRV.GRV_InvoiceDate FROM ((aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aPurchaseOrder ON aGRV.GRV_PurchaseOrderID = aPurchaseOrder.PurchaseOrderID) INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID WHERE (((aGRV.GRV_GRVStatusID)=3) AND ((aGRV.GRV_InvoiceInclusive)<>0));");

			//Do While rDayEndPur.EOF = False

			while (!(rDayEndPur.EOF)) {
				rPurchases = modReport.getRSreport(ref "SELECT aStockItem.StockItem_Name AS GRVItem_Name, aGRVItem.GRVItem_Code, aGRVItem.GRVItem_PackSize, aGRVItem.GRVItem_Quantity, aGRVItem.GRVItem_ContentCost, aGRVItem.GRVItem_DepositCost, aGRVItem.GRVItem_DiscountAmount, aGRVItem.GRVItem_VatRate, ([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS depositInclusive, ((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity] AS contentExclusive, (((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS contentInclusive, (([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost]) AS contentCost FROM aGRVItem INNER JOIN aStockItem ON aGRVItem.GRVItem_StockItemID = aStockItem.StockItemID WHERE (((aGRVItem.GRVItem_Quantity)<>0) AND ((aGRVItem.GRVItem_Return)=0) AND ((aGRVItem.GRVItem_GRVID)= " + rDayEndPur.Fields("GRVID").Value + "));");

				while (rPurchases.EOF == false) {
					if (rPurchases.Fields("contentInclusive").Value == rPurchases.Fields("contentExclusive").Value) {
						rPurIVat = rPurIVat + rPurchases.Fields("contentExclusive").Value;
					} else {
						rPurEVat = rPurEVat + rPurchases.Fields("contentExclusive").Value;
					}

					rPurchases.moveNext();
				}

				rDayEndPur.moveNext();
			}

			//purchase deposit calculation
			rDepPurIVat = 0;
			ADODB.Recordset rsDepPurch = default(ADODB.Recordset);
			rsDepPurch = modReport.getRSreport(ref "SELECT Sum(IIf([DayEndDeposittemLnk_DepositType]=0,[DayEndDepositItemLnk_UnitCost],[DayEndDepositItemLnk_CaseCost])*[DayEndDepositItemLnk_QuantitySales]) AS Sales, Sum(IIf([DayEndDeposittemLnk_DepositType]=0,[DayEndDepositItemLnk_UnitCost],[DayEndDepositItemLnk_CaseCost])*[DayEndDepositItemLnk_QuantityShrink]) AS Shrink, Sum(IIf([DayEndDeposittemLnk_DepositType]=0,[DayEndDepositItemLnk_UnitCost],[DayEndDepositItemLnk_CaseCost])*[DayEndDepositItemLnk_QuantityGRV]) AS GRV From DayEndDepositItemLnk");
			if (rsDepPurch.RecordCount)
				rDepPurIVat = (Information.IsDBNull(rsDepPurch.Fields("GRV").Value) ? 0 : rsDepPurch.Fields("GRV").Value);
			rPurIVat = rPurIVat + rDepPurIVat;
			rPurEVat = rPurEVat + rDepPurIVat;

			//do invoice discount
			rsDiscount = modReport.getRSreport(ref "SELECT Sum(Sale.Sale_Discount) AS amount FROM aConsignment RIGHT JOIN (aConsignment AS aConsignment_1 RIGHT JOIN Sale ON aConsignment_1.Consignment_SaleID = Sale.SaleID) ON aConsignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null));");

			if (Information.IsDBNull(rsDiscount.Fields("amount").Value)) {
				Report.SetParameterValue("txtDiscountsGiven", "0.00");
			} else {
				if (rsDiscount.RecordCount) {
					Report.SetParameterValue("txtDiscountsGiven", Strings.FormatNumber(0 - rsDiscount.Fields("amount").Value, 2));
				} else {
					Report.SetParameterValue("txtDiscountsGiven", "0.00");
				}
			}

			Report.SetParameterValue("txtInSales", Strings.FormatNumber(vInSales, 2));
			Report.SetParameterValue("txtExSales", Strings.FormatNumber(vExSales, 2));
			Report.SetParameterValue("txtTaxSales", Strings.FormatNumber(vTaxSales, 2));
			Report.SetParameterValue("txtVatSales", Strings.FormatNumber(vVatSales, 2));
			Report.SetParameterValue("txtNonTaxSales", Strings.FormatNumber(vNonTaxSales, 2));

			//Purchases
			Report.SetParameterValue("txtNonTaxable", Strings.FormatNumber(rPurIVat, 2));
			Report.SetParameterValue("txtPurExcluding", Strings.FormatNumber(rPurEVat, 2));

			Report.Database.Tables(1).SetDataSource(rsGRVItem);
			Report.Database.Tables(2).SetDataSource(rsGRVItemReturn);
			Report.Database.Tables(3).SetDataSource(rsGRVDeposit);
			Report.Database.Tables(4).SetDataSource(rsGRVDepositReturn);
			Report.Database.Tables(5).SetDataSource(rsGRVMain);
			Report.Database.Tables(6).SetDataSource(rsGRVPricing);

			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();

		}
		public static void report_VATPASTEL()
		{
			ADODB.Recordset rsSale = default(ADODB.Recordset);
			string sql2 = null;
			short intF = 0;

			bool lMode = false;

			decimal vInSales = default(decimal);
			decimal vExSales = default(decimal);
			decimal vTaxSales = default(decimal);
			decimal vVatSales = default(decimal);
			decimal vNonTaxSales = default(decimal);
			decimal lPasteCurr = default(decimal);
			decimal vl_Charged = default(decimal);
			decimal rPurEVat = default(decimal);
			decimal rPurIVat = default(decimal);
			decimal lTotal = default(decimal);
			decimal VatEx = default(decimal);
			decimal VatEp = default(decimal);
			decimal lCash = default(decimal);
			decimal lDebit = default(decimal);
			decimal lCheque = default(decimal);
			decimal lCredit = default(decimal);

			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rNar = default(ADODB.Recordset);
			//Tax Narrative purpose
			ADODB.Recordset rsGRVItem = default(ADODB.Recordset);
			ADODB.Recordset rsGRVMain = default(ADODB.Recordset);
			ADODB.Recordset rsGRVDeposit = default(ADODB.Recordset);
			ADODB.Recordset rsGRVPricing = default(ADODB.Recordset);
			ADODB.Recordset rsGRVItemReturn = default(ADODB.Recordset);
			ADODB.Recordset rsGRVDepositReturn = default(ADODB.Recordset);
			ADODB.Recordset rsSalesTotal = default(ADODB.Recordset);
			ADODB.Recordset rPurchases = default(ADODB.Recordset);
			//do purchases list
			ADODB.Recordset rDayEndPur = default(ADODB.Recordset);
			//2 get the day ends
			ADODB.Recordset rDisplay_F = default(ADODB.Recordset);
			ADODB.Recordset rsPTotals = default(ADODB.Recordset);
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

			string sql = null;
			//Dim Report As New cryPastelAnalysisrep
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryPastenAnalysisrep.rpt");
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();

			rsGRVItem = modReport.getRSreport(ref "SELECT aGRV.GRVID, Sum(IIf([GRVItem_Return],0,(((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])))) AS exclusive, Sum(IIf([GRVItem_Return],0,((((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100))))) AS inclusive, Sum(IIf([GRVItem_Return],0,[GRVItem_DepositCost]*[GRVItem_Quantity])) AS depositExcl, Sum(IIf([GRVItem_Return],0,([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100))) AS depositIncl FROM (aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) LEFT JOIN aGRVItem ON aGRV.GRVID = aGRVItem.GRVItem_GRVID Where (((aGRV.GRV_GRVStatusID) = 3) AND (GRVItem_StockItemQuantity <> 0)) GROUP BY aGRV.GRVID;");

			if (rsGRVItem.BOF | rsGRVItem.EOF) {
				report_Salespastel();
				return;
			}

			rsGRVItemReturn = modReport.getRSreport(ref "SELECT aGRV.GRVID, Sum(IIf([GRVItem_Return],(((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])),0)) AS exclusive, Sum(IIf([GRVItem_Return],((((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100))),0)) AS inclusive, Sum(IIf([GRVItem_Return],[GRVItem_DepositCost]*[GRVItem_Quantity],0)) AS depositExcl, Sum(IIf([GRVItem_Return],([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100),0)) AS depositIncl FROM (aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) LEFT JOIN aGRVItem ON aGRV.GRVID = aGRVItem.GRVItem_GRVID Where (((aGRV.GRV_GRVStatusID) = 3)) GROUP BY aGRV.GRVID;");
			rsGRVDeposit = modReport.getRSreport(ref "SELECT aGRV.GRVID, Sum(IIf([GRVDeposit_Return],0,(IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,[GRVDeposit_Quantity]*([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]*(1+[GRVDeposit_VatRate]/100)),0))+(IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,[GRVDeposit_quantity]*([GRVDeposit_CaseCost]*(1+[GRVDeposit_VatRate]/100)),0)))) AS inclusiveDepositReturn, Sum(IIf([GRVDeposit_Return],0,(IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,[GRVDeposit_Quantity]*([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]),0))+(IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,[GRVDeposit_quantity]*([GRVDeposit_CaseCost]),0)))) AS exclusiveDepositReturn FROM (aGRV LEFT JOIN aGRVDeposit ON aGRV.GRVID = aGRVDeposit.GRVDeposit_GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID Where (((aGRV.GRV_GRVStatusID) = 3)) GROUP BY aGRV.GRVID;");
			rsGRVDepositReturn = modReport.getRSreport(ref "SELECT aGRV.GRVID, Sum(IIf([GRVDeposit_Return],(IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,[GRVDeposit_Quantity]*([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]*(1+[GRVDeposit_VatRate]/100)),0))+(IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,[GRVDeposit_quantity]*([GRVDeposit_CaseCost]*(1+[GRVDeposit_VatRate]/100)),0)),0)) AS inclusiveDepositReturn, Sum(IIf([GRVDeposit_Return],(IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,[GRVDeposit_Quantity]*([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]),0))+(IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,[GRVDeposit_quantity]*([GRVDeposit_CaseCost]),0)),0)) AS exclusiveDepositReturn FROM (aGRV LEFT JOIN aGRVDeposit ON aGRV.GRVID = aGRVDeposit.GRVDeposit_GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID Where (((aGRV.GRV_GRVStatusID) = 3)) GROUP BY aGRV.GRVID;");
			rsGRVMain = modReport.getRSreport(ref "SELECT aGRV.GRVID, aGRV.GRV_InvoiceInclusive, aGRV.GRV_InvoiceVat, aGRV.GRV_InvoiceDiscount, aGRV.GRV_SundriesPlus, aGRV.GRV_SundriesMinus, aGRV.GRV_ContentExclusive, ([GRV_ContentExclusive]*(1+[GRV_Ullage]/100)-[GRV_ContentExclusive]) AS Ullage, (1+[GRV_InvoiceVat]/([GRV_InvoiceInclusive]-[GRV_InvoiceVat])) AS vat, Supplier.SupplierID, Supplier.Supplier_Name, aPurchaseOrder.PurchaseOrder_Reference, aGRV.GRV_InvoiceNumber, aGRV.GRV_InvoiceDate FROM ((aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aPurchaseOrder ON aGRV.GRV_PurchaseOrderID = aPurchaseOrder.PurchaseOrderID) INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID WHERE (((aGRV.GRV_GRVStatusID)=3) AND ((aGRV.GRV_InvoiceInclusive)<>0));");

			sql = "SELECT aGRV.GRVID, Sum((([GRVItem_PackSize]/[GRVItem_StockItemQuantity])*[GRVItem_ContentCost]-[GRVItem_DiscountAmount])*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))) AS exclusive, Sum((([GRVItem_PackSize]/[GRVItem_StockItemQuantity])*[GRVItem_ContentCost]-[GRVItem_DiscountAmount])*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))*(1+[GRVItem_VatRate]/100)) AS inclusive, Sum((([GRVItem_PackSize]/[GRVItem_StockItemQuantity])*[GRVItem_ContentCost])*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))) AS PriceExcl, Sum((([GRVItem_PackSize]/[GRVItem_StockItemQuantity])*[GRVItem_ContentCost])*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))*(1+[GRVItem_VatRate]/100)) AS PriceIncl, Sum([DayEndStockItemLnk_ListCost]*[GRVItem_PackSize]*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))) AS listExcl, Sum([DayEndStockItemLnk_ListCost]*[GRVItem_PackSize]*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))*(1+[GRVItem_VatRate]/100)) AS listIncl, ";
			sql = sql + "Sum([DayEndStockItemLnk_ActualCost]*[GRVItem_PackSize]*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))*(1+[GRVItem_VatRate]/100)) AS actualIncl, Sum([DayEndStockItemLnk_ActualCost]*[GRVItem_PackSize]*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))) AS actualExcl FROM DayEndStockItemLnk INNER JOIN ((aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aGRVItem ON aGRV.GRVID = aGRVItem.GRVItem_GRVID) ON (DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aGRVItem.GRVItem_StockItemID) AND (DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aGRV.GRV_DayEndID) Where (((aGRV.GRV_GRVStatusID) = 3) AND (GRVItem_StockItemQuantity <> 0)) GROUP BY aGRV.GRVID;";

			rsGRVPricing = modReport.getRSreport(ref sql);

			if (rsGRVPricing.BOF | rsGRVPricing.EOF) {
				report_Salespastel();
				return;
			}

			modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount=0,HomeAmount=0,PastelDate=#" + Convert.ToDateTime(DateAndTime.Today) + "#, Reference = '4POS'");


			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			if (modReport.openConnectionReport()) {
				rs = modReport.getRSreport(ref "SELECT aCompany.Company_Name, Report.Report_Heading FROM aCompany, Report;");
				Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
				Report.SetParameterValue("txtFilter", rs.Fields("Report_Heading"));

				//get payoutTotal
				rs = modReport.getRSreport(ref "SELECT Sum(Payout.Payout_Amount) AS [amount] FROM Payout;");
				if (Information.IsDBNull(rs.Fields("amount").Value)) {
					Report.SetParameterValue("txtPayout", "0.00");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 18");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 19");

					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 18");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 19");
				} else {
					Report.SetParameterValue("txtPayout", Strings.FormatNumber(rs.Fields("amount").Value, 2));
					Report.SetParameterValue("txtPayout1", Strings.FormatNumber(rs.Fields("amount").Value, 2));
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 18");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 19");

					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 18");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 19");
				}
				rs.Close();

				//get outages.................

				rs = modReport.getRSreport(ref "SELECT Sum(([Declaration_Cash]+[Declaration_Cheque]+[Declaration_Card]-[Declaration_Payout])-([Declaration_CashServer]+[Declaration_ChequeServer]+[Declaration_CardServer]-[Declaration_PayoutServer])) AS amount FROM Declaration;");
				if (Information.IsDBNull(rs.Fields("amount").Value)) {
					Report.SetParameterValue("txtOutage", "0.00");
					Report.SetParameterValue("txtOutage1", "0.00");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 5");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 6");

					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 5");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 6");
				} else {
					if (rs.Fields("amount").Value < 0) {
						Report.SetParameterValue("txtOutage", Strings.FormatNumber(-1 * rs.Fields("amount").Value, 2));
						Report.SetParameterValue("txtOutage1", Strings.FormatNumber(-1 * rs.Fields("amount").Value, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 5");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 6");

						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 5");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 6");
					} else {
						Report.SetParameterValue("txtOutage", Strings.FormatNumber(rs.Fields("amount").Value, 2));
						Report.SetParameterValue("txtOutage1", Strings.FormatNumber(rs.Fields("amount").Value, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 5");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 6");

						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 5");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 6");
					}
				}
				rs.Close();

				//get account movement......................
				lTotal = 0;
				lCash = 0;
				lDebit = 0;
				lCheque = 0;
				lCredit = 0;

				rs = modReport.getRSreport(ref "SELECT Sum(Sale.Sale_Total) AS amount, Sale.Sale_PaymentType, Sum([Sale_Total]-[Sale_Discount]) AS Subtotal, Sum(Sale.Sale_Discount) AS discount, Sum(Sale.Sale_Cash) AS amountCash,Sum(Sale.Sale_Card) AS amountCard,Sum(Sale.Sale_CDebit) AS amountCredit,Sum(Sale.Sale_Cheque) AS amountCheque FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (CustomerTransaction INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((CustomerTransaction.CustomerTransaction_TransactionTypeID) = 2 Or (CustomerTransaction.CustomerTransaction_TransactionTypeID) = 3) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_PaymentType;");

				while (!(rs.EOF)) {
					switch (rs.Fields("Sale_PaymentType").Value) {
						case 5:
							Report.SetParameterValue("txtAccountSales", Strings.FormatNumber(rs.Fields("subtotal").Value, 2));
							Report.SetParameterValue("txtAccountSales1", Strings.FormatNumber(rs.Fields("subtotal").Value, 2));
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("subtotal").Value, 2)) + " WHERE IDDescription = 7");
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("subtotal").Value, 2)) + " WHERE IDDescription = 8");

							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("subtotal").Value, 2)) + " WHERE IDDescription = 7");
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("subtotal").Value, 2)) + " WHERE IDDescription");
							break;
						case 1:
							lCash = lCash + rs.Fields("amountCash").Value;
							lTotal = lTotal - rs.Fields("amount").Value;
							break;
						case 2:
							lTotal = lTotal - rs.Fields("amount").Value;
							lCredit = lCredit + rs.Fields("amountCredit").Value;

							break;
						case 3:
							lTotal = lTotal - rs.Fields("amount").Value;
							lDebit = lDebit + rs.Fields("amountCard").Value;
							break;
						case 4:
							lCheque = lCheque + rs.Fields("amountCheque").Value;
							lTotal = lTotal - rs.Fields("amount").Value;
							break;
						case 7:
							lTotal = lTotal - rs.Fields("amount").Value;
							lCash = lCash + rs.Fields("amountCash").Value;
							lDebit = lDebit + rs.Fields("amountCard").Value;
							lCredit = lCredit + rs.Fields("amountCredit").Value;
							lCheque = lCheque + rs.Fields("amountCheque").Value;
							break;
					}
					rs.moveNext();
				}
				rs.Close();

				//Get Output Vat.......................

				sql2 = "SELECT SaleItem.SaleItem_StockItemID, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ActualCost]*[SaleItem_Quantity],[SaleItem_ActualCost]*[SaleItem_Quantity])) AS actualCostSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ListCost]*[SaleItem_Quantity],[SaleItem_ListCost]*[SaleItem_Quantity])) AS listCostSum, Sum(([SaleItem_Price]*[SaleItem_Quantity]/(1+[SaleItem_Vat]/100))) AS exclusiveSum, Sum(([SaleItem_Price]*[SaleItem_Quantity])) AS inclusiveSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_DepositCost]*[SaleItem_Quantity],[SaleItem_DepositCost]*[SaleItem_Quantity])) AS depositSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) AS quantitySum FROM Sale INNER JOIN (aConsignment AS aConsignment_1 RIGHT JOIN (SaleItem LEFT JOIN aConsignment ON SaleItem.SaleItem_SaleID=aConsignment.Consignment_SaleID) ON aConsignment_1.Consignment_ReversalSaleID=SaleItem.SaleItem_SaleID) ON Sale.SaleID=SaleItem.SaleItem_SaleID" + " Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null))" + " GROUP BY SaleItem.SaleItem_StockItemID;";

				rsSale = modReport.getRSreport(ref sql2);

				vInSales = 0;
				if (Information.IsDBNull(rsSale("inclusiveSum"))) {
					//If rsSale.EOF Or rsSale.BOF Then
					Report.SetParameterValue("txtOutputVat", Strings.FormatNumber(vInSales, 2));
					Report.SetParameterValue("txtOutputVat1", Strings.FormatNumber(vInSales, 2));
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(vInSales, 2)) + " WHERE IDDescription = 26");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vInSales, 2)) + " WHERE IDDescription = 27");

					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(vInSales, 2)) + " WHERE IDDescription = 26");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vInSales, 2)) + " WHERE IDDescription = 27");
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object rsSale.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					while (rsSale.EOF == false) {
						vInSales = vInSales + rsSale("inclusiveSum").Value;
						vExSales = vExSales + rsSale("exclusiveSum").Value;
						rsSale.moveNext();
					}
					vVatSales = vInSales - vExSales;

					Report.SetParameterValue("txtOutputVat", Strings.FormatNumber(vVatSales, 2));
					Report.SetParameterValue("txtOutputVat1", Strings.FormatNumber(vVatSales, 2));
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(vVatSales, 2)) + " WHERE IDDescription = 26");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vVatSales, 2)) + " WHERE IDDescription = 27");

					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(vVatSales, 2)) + " WHERE IDDescription = 26");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vVatSales, 2)) + " WHERE IDDescription = 27");
				}
				rsSale.Close();

				//get Settlement movement
				vInSales = 0;
				rsSale = modReport.getRSreport(ref "SELECT Sum([CustomerTransaction_Amount]) AS SttTotal From CustomerTransaction WHERE CustomerTransaction_TransactionTypeID=8;");

				if (Information.IsDBNull(rsSale("SttTotal"))) {
					Report.SetParameterValue("txtSettlement", Strings.FormatNumber(vInSales, 2));
					Report.SetParameterValue("txtSettlement1", Strings.FormatNumber(vInSales, 2));
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(vInSales, 2)) + " WHERE IDDescription = 11");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vInSales, 2)) + " WHERE IDDescription = 12");

					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(vInSales, 2)) + " WHERE IDDescription = 11");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vInSales, 2)) + " WHERE IDDescription = 12");
				} else {
					if (rsSale("SttTotal").Value < 0) {
						Report.SetParameterValue("txtSettlement", Strings.FormatNumber(-1 * rsSale("SttTotal").Value, 0));
						Report.SetParameterValue("txtSettlement1", Strings.FormatNumber(-1 * rsSale("SttTotal").Value, 0));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale("SttTotal").Value, 0)) + " WHERE IDDescription = 11");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale("SttTotal").Value, 0)) + " WHERE IDDescription = 12");

						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale("SttTotal").Value, 0)) + " WHERE IDDescription = 11");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale("SttTotal"), 0)) + " WHERE IDDescription = 12");
					} else {
						Report.SetParameterValue("txtSettlement", Strings.FormatNumber(rsSale("SttTotal"), 0));
						Report.SetParameterValue("txtSettlement1", Strings.FormatNumber(rsSale("SttTotal"), 0));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale("SttTotal"), 0)) + " WHERE IDDescription = 11");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale("SttTotal").Value, 0)) + " WHERE IDDescription = 12");

						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale("SttTotal"), 0)) + " WHERE IDDescription = 11");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale("SttTotal").Value, 0)) + " WHERE IDDescription = 12");
					}
				}

				rsSale.Close();

				rsSale = modReport.getRSreport(ref "SELECT Sum(SupplierTransaction.SupplierTransaction_Amount) AS SttTotal FROM SupplierTransaction WHERE (((SupplierTransaction.SupplierTransaction_TransactionTypeID)=8));");
				vInSales = 0;
				if (Information.IsDBNull(rsSale("SttTotal"))) {
					//If rsSale.EOF Or rsSale.BOF Then
					Report.SetParameterValue("txtSettlementD", Strings.FormatNumber(vInSales, 2));
					Report.SetParameterValue("txtSettlementD1", Strings.FormatNumber(vInSales, 2));
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(vInSales, 2)) + " WHERE IDDescription = 24");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vInSales, 2)) + " WHERE IDDescription = 25");

					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(vInSales, 2)) + " WHERE IDDescription = 24");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vInSales, 2)) + " WHERE IDDescription = 25");
				} else {
					if (rsSale("SttTotal").Value < 0) {
						Report.SetParameterValue("txtSettlementD", Strings.FormatNumber(-1 * rsSale("SttTotal").Value, 2));
						Report.SetParameterValue("txtSettlementD1", Strings.FormatNumber(-1 * rsSale("SttTotal").Value, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale("SttTotal").Value, 2)) + " WHERE IDDescription = 24");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale("SttTotal"), 2)) + " WHERE IDDescription = 25");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale("SttTotal").Value, 2)) + " WHERE IDDescription = 24");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale("SttTotal"), 2)) + " WHERE IDDescription = 25");
					} else {
						Report.SetParameterValue("txtSettlementD", Strings.FormatNumber(rsSale("SttTotal"), 2));
						Report.SetParameterValue("txtSettlementD1", Strings.FormatNumber(rsSale("SttTotal"), 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale("SttTotal"), 2)) + " WHERE IDDescription = 24");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale("SttTotal").Value, 2)) + " WHERE IDDescription = 25");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale("SttTotal"), 2)) + " WHERE IDDescription = 24");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale("SttTotal").Value, 2)) + " WHERE IDDescription = 25");
					}
				}

				rsSale.Close();

				rsSale = modReport.getRSreport(ref "SELECT Sum(SupplierTransaction.SupplierTransaction_Amount) AS SttTotal FROM SupplierTransaction WHERE (((SupplierTransaction.SupplierTransaction_TransactionTypeID)=3));");
				vInSales = 0;
				if (Information.IsDBNull(rsSale("SttTotal"))) {
					//If rsSale.EOF Or rsSale.BOF Then
					Report.SetParameterValue("txtCreditorPay", Strings.FormatNumber(vInSales, 2));
					Report.SetParameterValue("txtCreditorPay1", Strings.FormatNumber(vInSales, 2));
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(vInSales, 2)) + " WHERE IDDescription = 22");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vInSales, 2)) + " WHERE IDDescription = 23");

					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(vInSales, 2)) + " WHERE IDDescription = 22");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vInSales, 2)) + " WHERE IDDescription = 23");
				} else {
					if (rsSale("SttTotal").Value < 0) {
						Report.SetParameterValue("txtCreditorPay", Strings.FormatNumber(-1 * rsSale("SttTotal").Value, 2));
						Report.SetParameterValue("txtCreditorPay1", Strings.FormatNumber(-1 * rsSale("SttTotal").Value, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale("SttTotal").Value, 2)) + " WHERE IDDescription = 22");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale("SttTotal"), 2)) + " WHERE IDDescription = 23");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale("SttTotal").Value, 2)) + " WHERE IDDescription = 22");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale("SttTotal"), 2)) + " WHERE IDDescription = 23");
					} else {
						Report.SetParameterValue("txtCreditorPay", Strings.FormatNumber(rsSale("SttTotal"), 2));
						Report.SetParameterValue("txtCreditorPay1", Strings.FormatNumber(rsSale("SttTotal"), 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale("SttTotal"), 2)) + " WHERE IDDescription = 22");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale("SttTotal").Value, 2)) + " WHERE IDDescription = 23");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale("SttTotal"), 2)) + " WHERE IDDescription = 22");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale("SttTotal").Value, 2)) + " WHERE IDDescription = 23");
					}
				}

				//do money movement....................
				lCash = 0;
				lDebit = 0;
				lCheque = 0;
				lCredit = 0;
				lTotal = 0;
				rs = modReport.getRSreport(ref "SELECT Sale.Sale_PaymentType,Sum(Sale.Sale_Total) as AmountTotal, Sum(Sale.Sale_Cash) AS amountCash,Sum(Sale.Sale_Card) AS amountCard,Sum(Sale.Sale_Cheque) AS amountCheque,Sum(Sale.Sale_CDebit) AS amountCredit FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_PaymentType;");

				while (!(rs.EOF)) {
					switch (rs.Fields("Sale_PaymentType").Value) {
						case 1:
							lCash = lCash + rs.Fields("amountCash").Value;
							lTotal = lTotal + rs.Fields("AmountTotal").Value;
							Report.SetParameterValue("txtMoneyCash", Strings.FormatNumber(rs("amount"), 2));
							break;
						case 2:
							lCredit = lCredit + rs.Fields("amountCredit").Value;
							lTotal = lTotal + rs.Fields("AmountTotal").Value;
							Report.SetParameterValue("txtMoneyCRcard", Strings.FormatNumber(rs("amount"), 2));
							break;
						case 3:
							lDebit = lDebit + rs.Fields("amountCard").Value;
							lTotal = lTotal + rs.Fields("AmountTotal").Value;
							Report.SetParameterValue("txtMoneyDRcard", Strings.FormatNumber(rs("amount"), 2));
							break;
						case 4:
							lTotal = lTotal + rs.Fields("AmountTotal").Value;
							lCheque = lCheque + rs.Fields("amountCheque").Value;
							Report.SetParameterValue("txtMoneyCheque", Strings.FormatNumber(rs("amount"), 2));
							break;
						case 7:
							lTotal = lTotal + rs.Fields("AmountTotal").Value;
							lCash = lCash + rs.Fields("amountCash").Value;
							lDebit = lDebit + rs.Fields("amountCard").Value;
							lCredit = lCredit + rs.Fields("amountCredit").Value;
							lCheque = lCheque + rs.Fields("amountCheque").Value;
							break;
					}
					rs.moveNext();
				}
				rs.Close();

				//1. Cash
				Report.SetParameterValue("txtMoneyCash", Strings.FormatNumber(lCash, 2));
				modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(lCash, 2)) + " WHERE IDDescription = 1");
				modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(lCash, 2)) + " WHERE IDDescription = 1");
				//2. Credit Card
				Report.SetParameterValue("txtMoneyCRcard", Strings.FormatNumber(lCredit, 2));
				modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(lCredit, 2)) + " WHERE IDDescription = 3");
				modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(lCredit, 2)) + " WHERE IDDescription = 3");
				//3. Debit Card.
				Report.SetParameterValue("txtMoneyDRcard", Strings.FormatNumber(lDebit, 2));
				modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(lDebit, 2)) + " WHERE IDDescription = 4");
				modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(lDebit, 2)) + " WHERE IDDescription = 4");
				//4. Cheque
				Report.SetParameterValue("txtMoneyCheque", Strings.FormatNumber(lCheque, 2));
				modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(lCheque, 2)) + " WHERE IDDescription = 2");
				modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(lCheque, 2)) + " WHERE IDDescription = 2");

				//Total Money movement
				Report.SetParameterValue("txtMoneyTotal", Strings.FormatNumber(lTotal, 2));
				modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * lTotal, 2)) + " WHERE IDDescription = 13");
				modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * lTotal, 2)) + " WHERE IDDescription = 13");
				lTotal = 0;

				//do invoice discount...........
				rs = modReport.getRSreport(ref "SELECT Sum(Sale.Sale_Discount) AS amount FROM aConsignment RIGHT JOIN (aConsignment AS aConsignment_1 RIGHT JOIN Sale ON aConsignment_1.Consignment_SaleID = Sale.SaleID) ON aConsignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null));");
				if (Information.IsDBNull(rs.Fields("amount").Value)) {
					Report.SetParameterValue("txtStockDiscount", "0.00");
				} else {
					if (rs.RecordCount) {
						Report.SetParameterValue("txtStockDiscount", Strings.FormatNumber(0 - rs("amount").Value, 2));
						Report.SetParameterValue("txtSCmDiscount", Strings.FormatNumber(0 - rs("amount").Value, 2));
					} else {
						Report.SetParameterValue("txtStockDiscount", "0.00");
					}
				}
				rs.Close();

				rs = modReport.getRSreport(ref "SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS content, CBool([SaleItem_DepositType]) AS depositType, SaleItem.SaleItem_Reversal, Sum(([SaleItem_DepositCost]*[SaleItem_Quantity])*(1+[SaleItem_Vat]/100)) AS deposit FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY CBool([SaleItem_DepositType]), SaleItem.SaleItem_Reversal;");
				while (!(rs.EOF)) {
					if (rs.Fields("depositType").Value) {
						if (rs.Fields("SaleItem_Reversal").Value) {
							Report.SetParameterValue("txtStockDepositSold", Strings.FormatNumber(rs("content"), 2));
						} else {
							Report.SetParameterValue("txtStockDepositReturn", Strings.FormatNumber(rs("content"), 2));
						}
					} else {
						if (rs.Fields("SaleItem_Reversal").Value) {
							Report.SetParameterValue("txtStockCreditContent", Strings.FormatNumber(rs("content"), 2));
							Report.SetParameterValue("txtStockCreditDeposit", Strings.FormatNumber(0 - rs("deposit").Value, 2));
						} else {
							Report.SetParameterValue("txtStockSoldContent", Strings.FormatNumber(rs("content"), 2));
							Report.SetParameterValue("txtStockSoldDeposit", Strings.FormatNumber(rs("deposit"), 2));
						}
					}
					rs.moveNext();
				}
				rs.Close();
				 // ERROR: Not supported in C#: OnErrorStatement

				rs = modReport.getRSreport(ref "SELECT Sum(aCustomerTransaction.CustomerTransaction_Amount) AS SumOfCustomerTransaction_Amount FROM aCustomerTransaction INNER JOIN DayEnd ON aCustomerTransaction.CustomerTransaction_DayEndID = DayEnd.DayEndID WHERE (((aCustomerTransaction.CustomerTransaction_TransactionTypeID)=3 Or (aCustomerTransaction.CustomerTransaction_TransactionTypeID)=4 Or (aCustomerTransaction.CustomerTransaction_TransactionTypeID)=5) AND ((aCustomerTransaction.CustomerTransaction_ReferenceID)=0));");
				if (rs.RecordCount) {
					if (rs.Fields("SumOfCustomerTransaction_Amount").Value < 0) {
						Report.SetParameterValue("txtAccountEFT", Strings.FormatNumber(-1 * rs.Fields("SumOfCustomerTransaction_Amount").Value, 2));
						Report.SetParameterValue("txtAccountEFT1", Strings.FormatNumber(-1 * rs.Fields("SumOfCustomerTransaction_Amount").Value, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) + " WHERE IDDescription = 9");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) + " WHERE IDDescription = 10");

						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) + " WHERE IDDescription = 9");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) + " WHERE IDDescription = 10");
					} else {
						Report.SetParameterValue("txtAccountEFT", Strings.FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2));
						Report.SetParameterValue("txtAccountEFT1", Strings.FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) + " WHERE IDDescription = 9");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) + " WHERE IDDescription = 10");

						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) + " WHERE IDDescription = 9");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) + " WHERE IDDescription = 10");
					}
				} else {
					Report.SetParameterValue("txtAccountEFT", Strings.FormatNumber(0, 2));
					Report.SetParameterValue("txtAccountEFT1", Strings.FormatNumber(0, 2));
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 9");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 10");

					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 9");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 10");
				}

				rDisplay_F = modRecordSet.getRS(ref "SELECT * FROM PastelDescription Order By IDDescription ASC");

				for (intF = 1; intF <= 29; intF++) {
					Report.SetParameterValue("txtDes1", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar1", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc1", rDisplay_F.Fields("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes2", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar2", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc2", rDisplay_F.Fields("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes3", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar3", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc3", rDisplay_F.Fields("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes4", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar4", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc4", rDisplay_F.Fields("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes5", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar5", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc5", rDisplay_F.Fields("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes6", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar6", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc6", rDisplay_F.Fields("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes7", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar7", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc7", rDisplay_F.Fields("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes8", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar8", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc8", rDisplay_F.Fields("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes9", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar9", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc9", rDisplay_F.Fields("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes10", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar10", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc10", rDisplay_F.Fields("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes11", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar11", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc11", rDisplay_F.Fields("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes12", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar12", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc12", rDisplay_F.Fields("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes13", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar13", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc13", rDisplay_F.Fields("AccountNumber"));
					rDisplay_F.moveNext();
					//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtDes14. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Report.SetParameterValue("txtDes14", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar14", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc14", rDisplay_F.Fields("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes15", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar15", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc15", rDisplay_F.Fields("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes16", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar16", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc16", rDisplay_F.Fields("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes17", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar17", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc17", rDisplay_F.Fields("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes18", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar18", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc18", rDisplay_F.Fields("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes19", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar19", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc19", rDisplay_F.Fields("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes20", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar20", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc20", rDisplay_F.Fields("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes21", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar21", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc21", rDisplay_F.Fields("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes22", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar22", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc22", rDisplay_F.Fields("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes23", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar23", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc23", rDisplay_F.Fields("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes24", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar24", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc24", rDisplay_F.Fields("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes25", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar25", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc25", rDisplay_F.Fields("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes26", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar26", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc26", rDisplay_F.Fields("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes27", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar27", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc27", rDisplay_F.Fields("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes28", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar28", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc28", rDisplay_F.Fields("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes29", rDisplay_F.Fields("Description"));
					Report.SetParameterValue("txtNar29", rDisplay_F.Fields("Decription1"));
					Report.SetParameterValue("txtAcc29", rDisplay_F.Fields("AccountNumber"));
					break; // TODO: might not be correct. Was : Exit For
				}

				if (lMode) {
				} else {
					rs = modReport.getRSreport(ref "SELECT Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost]) AS listSales, Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ActualCost]) AS actualSales, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS listShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actualShrink, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost]) AS listGRV, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ActualCost]) AS actualGRV FROM DayEndStockItemLnk;");
					if (Information.IsDBNull(rs.Fields("listShrink").Value)) {
						Report.SetParameterValue("txtSHRL", Strings.FormatNumber(0, 2));
						Report.SetParameterValue("txtSHRL1", Strings.FormatNumber(0, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 14");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 15");

						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 14");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 15");
					} else {
						if (rs.Fields("listShrink").Value < 0) {
							Report.SetParameterValue("txtSHRL", Strings.FormatNumber(-1 * rs.Fields("listShrink").Value, 2));
							Report.SetParameterValue("txtSHRL1", Strings.FormatNumber(-1 * rs.Fields("listShrink").Value, 2));
						} else {
							Report.SetParameterValue("txtSHRL", Strings.FormatNumber(rs.Fields("listShrink").Value, 2));
							Report.SetParameterValue("txtSHRL1", Strings.FormatNumber(rs.Fields("listShrink").Value, 2));
						}
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("listShrink").Value, 2)) + " WHERE IDDescription = 14");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("listShrink").Value, 2)) + " WHERE IDDescription = 15");

						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("listShrink").Value, 2)) + " WHERE IDDescription = 14");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("listShrink").Value, 2)) + " WHERE IDDescription = 15");
					}

					//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					if (Information.IsDBNull(rs.Fields("listGRV").Value)) {
						Report.SetParameterValue("txtGRVL1", Strings.FormatNumber(0, 2));
						Report.SetParameterValue("txtGRVL", Strings.FormatNumber(0, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 20");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 21");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 28");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 29");

						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 20");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 21");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 28");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 29");
					} else {
						Report.SetParameterValue("txtGRVL1", Strings.FormatNumber(rs.Fields("listGRV").Value, 2));
						Report.SetParameterValue("txtGRVL", Strings.FormatNumber(rs.Fields("listGRV").Value, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("listGRV").Value, 2)) + " WHERE IDDescription = 20");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("listGRV").Value, 2)) + " WHERE IDDescription = 21");

						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("listGRV").Value, 2)) + " WHERE IDDescription = 20");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("listGRV").Value, 2)) + " WHERE IDDescription = 21");
						VatEx = (rs.Fields("listGRV").Value * 1.14) - rs.Fields("listGRV").Value;
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(VatEx, 2)) + " WHERE IDDescription = 28");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * VatEx, 2)) + " WHERE IDDescription = 29");

						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(VatEx, 2)) + " WHERE IDDescription = 28");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * VatEx, 2)) + " WHERE IDDescription = 29");
					}

					if (Information.IsDBNull(rs.Fields("listSales").Value)) {
						Report.SetParameterValue("txtSaleL", Strings.FormatNumber(0, 2));
						Report.SetParameterValue("txtSaleL1", Strings.FormatNumber(0, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 16");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 17");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 16");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 17");
					} else {
						Report.SetParameterValue("txtSaleL", Strings.FormatNumber(rs.Fields("listSales").Value, 2));
						Report.SetParameterValue("txtSaleL1", Strings.FormatNumber(rs.Fields("listSales").Value, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("listSales").Value, 2)) + " WHERE IDDescription = 16");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("listSales").Value, 2)) + " WHERE IDDescription = 17");

						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("listSales").Value, 2)) + " WHERE IDDescription = 16");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("listSales").Value, 2)) + " WHERE IDDescription = 17");
					}
				}

				rs = modReport.getRSreport(ref "SELECT Sum([Sale]![Sale_Total]+[Sale_1]![Sale_Total]) AS priceReturn, Sale.Sale_Total FROM Sale INNER JOIN (Sale AS Sale_1 INNER JOIN aConsignment ON Sale_1.SaleID = aConsignment.Consignment_ReversalSaleID) ON Sale.SaleID = aConsignment.Consignment_CompleteSaleID GROUP BY Sale.Sale_Total;");
				if (rs.BOF | rs.EOF) {
					Report.SetParameterValue("txtConsPPurchase", Strings.FormatNumber("0", 2));
					Report.SetParameterValue("txtConsPreturn", Strings.FormatNumber("0", 2));
				} else {
					if (Information.IsDBNull(rs.Fields("Sale_Total").Value)) {
						Report.SetParameterValue("txtConsPPurchase", Strings.FormatNumber("0", 2));
						Report.SetParameterValue("txtConsPreturn", Strings.FormatNumber("0", 2));
					} else {
						Report.SetParameterValue("txtConsPPurchase", Strings.FormatNumber(rs("Sale_Total"), 2));
						Report.SetParameterValue("txtConsPreturn", Strings.FormatNumber(rs("priceReturn"), 2));
					}
				}

			}

			ADODB.Recordset rsPTotalss = default(ADODB.Recordset);

			rsPTotals = modRecordSet.getRS(ref "SELECT SUM(Amount) As totDebit FROM PastelDescription WHERE Amount > 0");
			rsPTotalss = modRecordSet.getRS(ref "SELECT SUM(Amount) as totCredit FROM PastelDescription WHERE Amount < 0");

			if (Information.IsDBNull(rsPTotals.Fields("totDebit").Value)) {
				Report.SetParameterValue("txtDebit", Strings.FormatNumber(0, 2));
			} else {
				Report.SetParameterValue("txtDebit", Strings.FormatNumber(rsPTotals.Fields("totDebit").Value));
			}
			if (Information.IsDBNull(rsPTotalss.Fields("totCredit").Value)) {
				Report.SetParameterValue("txtCredit", Strings.FormatNumber(0, 2));
			} else {
				Report.SetParameterValue("txtCredit", Strings.FormatNumber(rsPTotalss.Fields("totCredit").Value));
			}

			//Pastel export file
			if (modBResolutions.blpastel == true) {
				System.Windows.Forms.Cursor.Current = Cursors.Default;
				return;
			}

			Report.Database.Tables(1).SetDataSource(rsGRVItem);
			Report.Database.Tables(2).SetDataSource(rsGRVItemReturn);
			Report.Database.Tables(3).SetDataSource(rsGRVDeposit);
			Report.Database.Tables(4).SetDataSource(rsGRVDepositReturn);
			Report.Database.Tables(5).SetDataSource(rsGRVMain);
			Report.Database.Tables(6).SetDataSource(rsGRVPricing);

			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}
		private static void report_HourlyDayReport()
		{
			string sql2 = null;
			ADODB.Recordset rsSale = default(ADODB.Recordset);
			decimal SumSales = default(decimal);
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New crydayhourlynew
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("crydayhourlynew.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();
			sql = "SELECT * FROM Sale";
			rs = modReport.getRSreport(ref sql);
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			sql2 = "SELECT SaleItem.SaleItem_StockItemID, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ActualCost]*[SaleItem_Quantity],[SaleItem_ActualCost]*[SaleItem_Quantity])) AS actualCostSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ListCost]*[SaleItem_Quantity],[SaleItem_ListCost]*[SaleItem_Quantity])) AS listCostSum, Sum(([SaleItem_Price]*[SaleItem_Quantity]/(1+[SaleItem_Vat]/100))) AS exclusiveSum, Sum(([SaleItem_Price]*[SaleItem_Quantity])) AS inclusiveSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_DepositCost]*[SaleItem_Quantity],[SaleItem_DepositCost]*[SaleItem_Quantity])) AS depositSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) AS quantitySum FROM Sale INNER JOIN (aConsignment AS aConsignment_1 RIGHT JOIN (SaleItem LEFT JOIN aConsignment ON SaleItem.SaleItem_SaleID=aConsignment.Consignment_SaleID) ON aConsignment_1.Consignment_ReversalSaleID=SaleItem.SaleItem_SaleID) ON Sale.SaleID=SaleItem.SaleItem_SaleID" + " Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null))" + " GROUP BY SaleItem.SaleItem_StockItemID;";

			rsSale = modReport.getRSreport(ref sql2);
			while (rsSale.EOF == false) {
				SumSales = SumSales + rsSale.Fields("inclusiveSum").Value;

				rsSale.moveNext();
			}

			Report.Database.Tables(1).SetDataSource(rs);

			Report.SetParameterValue("txtSum", Strings.FormatNumber(SumSales, 2));
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}
		public static void report_HandHeldScanner()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryHandHeld
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryHandHeld.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDateH", Convert.ToDateTime(DateAndTime.Today));

			rs.Close();

			sql = "SELECT " + stTableName + ".HandHeldID,StockItem.StockItem_Name," + stTableName + ".Quantity,StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID,StockItem.StockItem_Quantity,StockTake.StockTake_WarehouseID," + stTableName + ".HandHeldID FROM " + "(StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN " + stTableName + " ON StockItem.StockItemID = " + stTableName + ".HandHeldID WHERE StockTake.StockTake_WarehouseID = 2 AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ORDER BY StockItem.StockItem_Name;";

			rs = modRecordSet.getRS(ref sql);

			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.Database.Tables(1).SetDataSource(rs);
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}


		private static void report_Shrinkage()
		{
			ADODB.Recordset rsWH = default(ADODB.Recordset);
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryShrinkage
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryShrinkage.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();

			//Multi Warehouse change
			int lMWNo = 0;
			lMWNo = My.MyProject.Forms.frmMWSelect.getMWNo();
			if (lMWNo > 1) {
				rsWH = modRecordSet.getRS(ref "SELECT * FROM Warehouse WHERE WarehouseID=" + lMWNo + ";");
				Report.SetParameterValue("txtWH", rsWH("Warehouse_Name"));
			}
			//Multi Warehouse change


			//Multi Warehouse change     Set rs = getRSreport("SELECT aStockItem.StockItem_Name, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS list, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actual FROM DayEndStockItemLnk LEFT JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID Where (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0)) GROUP BY aStockItem.StockItem_Name ORDER BY aStockItem.StockItem_Name;")
			//Set rs = getRSreport("SELECT aStockItem.StockItem_Name, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS list, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actual, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse FROM DayEndStockItemLnk LEFT JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID Where (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0)) GROUP BY aStockItem.StockItem_Name, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse Having (((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse) = " & lMWNo & ")) ORDER BY aStockItem.StockItem_Name;")

			//+ - sign change
			bool bSign = false;
			ADODB.Recordset rsSign = default(ADODB.Recordset);
			rsSign = modRecordSet.getRS(ref "SELECT Company_ShrinkSign FROM Company;");
			if (rsSign.RecordCount) {
				if (rsSign.Fields("Company_ShrinkSign").Value)
					bSign = true;
			}
			//+ - sign change
			//sql = "SELECT aStockItem.StockItem_Name, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS list, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actual, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse, CatalogueChannelLnk.CatalogueChannelLnk_Price"
			//sql = sql & " FROM (DayEndStockItemLnk LEFT JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) INNER JOIN CatalogueChannelLnk ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID Where (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0)) GROUP BY aStockItem.StockItem_Name, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price Having (((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse) = " & lMWNo & ") And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1)) ORDER BY aStockItem.StockItem_Name;"
			if (bSign) {
				sql = "SELECT aStockItem.StockItem_Name, (0 - Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink)) AS SumOfDayEndStockItemLnk_QuantityShrink, (0 - Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost])) AS list, (0 - Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost])) AS actual, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse, CatalogueChannelLnk.CatalogueChannelLnk_Price";
				sql = sql + " FROM (DayEndStockItemLnk LEFT JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) INNER JOIN CatalogueChannelLnk ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID Where (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0)) GROUP BY aStockItem.StockItem_Name, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price Having (((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse) = " + lMWNo + ") And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1)) ORDER BY aStockItem.StockItem_Name;";
			} else {
				sql = "SELECT aStockItem.StockItem_Name, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS list, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actual, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse, CatalogueChannelLnk.CatalogueChannelLnk_Price";
				sql = sql + " FROM (DayEndStockItemLnk LEFT JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) INNER JOIN CatalogueChannelLnk ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID Where (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0)) GROUP BY aStockItem.StockItem_Name, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price Having (((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse) = " + lMWNo + ") And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1)) ORDER BY aStockItem.StockItem_Name;";
			}
			rs = modReport.getRSreport(ref sql);

			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			Report.Database.Tables(1).SetDataSource(rs);

			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		private static void report_BasketValue()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsPayment = default(ADODB.Recordset);
			ADODB.Recordset rsChannel = default(ADODB.Recordset);
			string sql = null;
			// Dim Report As New cryBasketValue
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryBasketValue.rpt");

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();
			rs = modReport.getRSreport(ref "SELECT * FROM Link Where LinkID=2 AND Link_SectionID=1");
			sql = "SELECT Count(theJoin.SaleID) AS CountOfSaleItemID, Sum(theJoin.quantity) AS quantity, Sum(theJoin.price) AS price, theJoin.Sale_PaymentType FROM (SELECT Sum(IIf([SaleItem_Reversal],0-[SaleItem_Quantity],[SaleItem_Quantity])) AS quantity, Sum(([SaleItem_Price]*[SaleItem_Quantity])) AS price, Sale.Sale_PaymentType, Sale.SaleID FROM SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_DepositType) = 0)) GROUP BY Sale.Sale_PaymentType, Sale.SaleID) AS theJoin GROUP BY theJoin.Sale_PaymentType;";
			rsPayment = modReport.getRSreport(ref sql);
			sql = "SELECT Count(theJoin.SaleID) AS CountOfSaleItemID, Sum(theJoin.quantity) AS quantity, Sum(theJoin.price) AS price, aChannel.ChannelID, aChannel.Channel_Name FROM aChannel INNER JOIN (SELECT Sum(IIf([SaleItem_Reversal],0-[SaleItem_Quantity],[SaleItem_Quantity])) AS quantity, Sum(([SaleItem_Price]*[SaleItem_Quantity])) AS price, Sale.Sale_ChannelID, Sale.SaleID FROM SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_DepositType) = 0)) GROUP BY Sale.Sale_ChannelID, Sale.SaleID) AS theJoin ON aChannel.ChannelID = theJoin.Sale_ChannelID GROUP BY aChannel.ChannelID, aChannel.Channel_Name;";
			rsChannel = modReport.getRSreport(ref sql);
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rsPayment.BOF | rsPayment.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			Report.OpenSubreport("Subreport1").Database.Tables(1).SetDataSource(rsPayment);
			Report.OpenSubreport("Subreport2").Database.Tables(1).SetDataSource(rsChannel);
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}
		private static void report_Banking()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryBanking
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryBanking.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();
			rs = modReport.getRSreport(ref "SELECT aPOS.POSID, aPOS.POS_Name, Sum(Declaration.Declaration_Cash) AS SumOfDeclaration_Cash, Sum(Declaration.Declaration_CashServer) AS SumOfDeclaration_CashServer, Sum(Declaration.Declaration_CashCount) AS SumOfDeclaration_CashCount, Sum(Declaration.Declaration_Cheque) AS SumOfDeclaration_Cheque, Sum(Declaration.Declaration_ChequeServer) AS SumOfDeclaration_ChequeServer, Sum(Declaration.Declaration_ChequeCount) AS SumOfDeclaration_ChequeCount, Sum(Declaration.Declaration_Card) AS SumOfDeclaration_Card, Sum(Declaration.Declaration_CardServer) AS SumOfDeclaration_CardServer, Sum(Declaration.Declaration_CardCount) AS SumOfDeclaration_CardCount, Sum(Declaration.Declaration_Payout) AS SumOfDeclaration_Payout, Sum(Declaration.Declaration_PayoutServer) AS SumOfDeclaration_PayoutServer, Sum(Declaration.Declaration_PayoutCount) AS SumOfDeclaration_PayoutCount FROM Declaration INNER JOIN aPOS ON Declaration.Declaration_POSID = aPOS.POSID GROUP BY aPOS.POSID, aPOS.POS_Name;");
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.OpenSubreport("Subreport1").Database.Tables(1).SetDataSource(rs);
			Report.OpenSubreport("Subreport2").Database.Tables(1).SetDataSource(rs);

			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}
		private static void report_GRVDetails()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsGRVItem = default(ADODB.Recordset);
			ADODB.Recordset rsGRVItemReturn = default(ADODB.Recordset);
			ADODB.Recordset rsGRVDeposit = default(ADODB.Recordset);
			ADODB.Recordset rsGRVDepositReturn = default(ADODB.Recordset);
			ADODB.Recordset rsGRVMain = default(ADODB.Recordset);
			ADODB.Recordset rsGRVPricing = default(ADODB.Recordset);

			string sql = null;
			//Dim Report As New cryGRVDetails
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryGRVDetails.rpt");
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"));
			rs.Close();

			//New sql
			//Set rsGRVItem = getRSreport("SELECT aGRV.GRVID,Sum(IIf([GRVItem_Return],0,[GRVItem_DepositCost]*[GRVItem_Quantity])) AS depositExcl, Sum(IIf([GRVItem_Return],0,((((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100))))) AS inclusive,Sum(IIf([GRVItem_Return],0,(((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])))) AS exclusive, Sum(IIf([GRVItem_Return],0,([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100))) AS depositIncl FROM (aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aGRVItem ON aGRV.GRVID = aGRVItem.GRVItem_GRVID Where (((aGRV.GRV_GRVStatusID) = 3)) AND (GRVItem_StockItemQuantity<>0) GROUP BY aGRV.GRVID;")
			//Old

			// not showing Returned VAT   Set rsGRVItem = getRSreport("SELECT aGRV.GRVID, Sum(IIf([GRVItem_Return],0,(((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])))) AS exclusive, Sum(IIf([GRVItem_Return],0,((((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100))))) AS inclusive, Sum(IIf([GRVItem_Return],0,[GRVItem_DepositCost]*[GRVItem_Quantity])) AS depositExcl, Sum(IIf([GRVItem_Return],0,([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100))) AS depositIncl FROM (aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) LEFT JOIN aGRVItem ON aGRV.GRVID = aGRVItem.GRVItem_GRVID Where (((aGRV.GRV_GRVStatusID) = 3) AND (GRVItem_StockItemQuantity <> 0)) GROUP BY aGRV.GRVID;")
			sql = "SELECT aGRV.GRVID, Sum(IIf([GRVItem_Return],0-(((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])),(((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])))) AS exclusive, Sum(IIf([GRVItem_Return],0-((((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100))),((((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100))))) AS inclusive, Sum(IIf([GRVItem_Return],0-([GRVItem_DepositCost]*[GRVItem_Quantity]),[GRVItem_DepositCost]*[GRVItem_Quantity])) AS depositExcl, ";
			sql = sql + "Sum(IIf([GRVItem_Return],0-(([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100)),([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100))) AS depositIncl FROM (aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) ";
			sql = sql + "LEFT JOIN aGRVItem ON aGRV.GRVID = aGRVItem.GRVItem_GRVID Where (((aGRV.GRV_GRVStatusID) = 3) AND (GRVItem_StockItemQuantity <> 0)) GROUP BY aGRV.GRVID;";
			rsGRVItem = modReport.getRSreport(ref sql);
			if (rsGRVItem.BOF | rsGRVItem.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			rsGRVItemReturn = modReport.getRSreport(ref "SELECT aGRV.GRVID, Sum(IIf([GRVItem_Return],(((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])),0)) AS exclusive, Sum(IIf([GRVItem_Return],((((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100))),0)) AS inclusive, Sum(IIf([GRVItem_Return],[GRVItem_DepositCost]*[GRVItem_Quantity],0)) AS depositExcl, Sum(IIf([GRVItem_Return],([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100),0)) AS depositIncl FROM (aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) LEFT JOIN aGRVItem ON aGRV.GRVID = aGRVItem.GRVItem_GRVID Where (((aGRV.GRV_GRVStatusID) = 3)) GROUP BY aGRV.GRVID;");
			if (rsGRVItemReturn.BOF | rsGRVItemReturn.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			rsGRVDeposit = modReport.getRSreport(ref "SELECT aGRV.GRVID, Sum(IIf([GRVDeposit_Return],0,(IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,[GRVDeposit_Quantity]*([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]*(1+[GRVDeposit_VatRate]/100)),0))+(IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,[GRVDeposit_quantity]*([GRVDeposit_CaseCost]*(1+[GRVDeposit_VatRate]/100)),0)))) AS inclusiveDepositReturn, Sum(IIf([GRVDeposit_Return],0,(IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,[GRVDeposit_Quantity]*([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]),0))+(IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,[GRVDeposit_quantity]*([GRVDeposit_CaseCost]),0)))) AS exclusiveDepositReturn FROM (aGRV LEFT JOIN aGRVDeposit ON aGRV.GRVID = aGRVDeposit.GRVDeposit_GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID Where (((aGRV.GRV_GRVStatusID) = 3)) GROUP BY aGRV.GRVID;");
			if (rsGRVDeposit.BOF | rsGRVDeposit.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			rsGRVDepositReturn = modReport.getRSreport(ref "SELECT aGRV.GRVID, Sum(IIf([GRVDeposit_Return],(IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,[GRVDeposit_Quantity]*([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]*(1+[GRVDeposit_VatRate]/100)),0))+(IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,[GRVDeposit_quantity]*([GRVDeposit_CaseCost]*(1+[GRVDeposit_VatRate]/100)),0)),0)) AS inclusiveDepositReturn, Sum(IIf([GRVDeposit_Return],(IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,[GRVDeposit_Quantity]*([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]),0))+(IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,[GRVDeposit_quantity]*([GRVDeposit_CaseCost]),0)),0)) AS exclusiveDepositReturn FROM (aGRV LEFT JOIN aGRVDeposit ON aGRV.GRVID = aGRVDeposit.GRVDeposit_GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID Where (((aGRV.GRV_GRVStatusID) = 3)) GROUP BY aGRV.GRVID;");
			if (rsGRVDepositReturn.BOF | rsGRVDepositReturn.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			rsGRVMain = modReport.getRSreport(ref "SELECT aGRV.GRVID, aGRV.GRV_InvoiceInclusive, aGRV.GRV_InvoiceVat, aGRV.GRV_InvoiceDiscount, aGRV.GRV_SundriesPlus, aGRV.GRV_SundriesMinus, aGRV.GRV_ContentExclusive, ([GRV_ContentExclusive]*(1+[GRV_Ullage]/100)-[GRV_ContentExclusive]) AS Ullage, (1+[GRV_InvoiceVat]/([GRV_InvoiceInclusive]-[GRV_InvoiceVat])) AS vat, Supplier.SupplierID, Supplier.Supplier_Name, aPurchaseOrder.PurchaseOrder_Reference, aGRV.GRV_InvoiceNumber, aGRV.GRV_InvoiceDate FROM ((aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aPurchaseOrder ON aGRV.GRV_PurchaseOrderID = aPurchaseOrder.PurchaseOrderID) INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID WHERE (((aGRV.GRV_GRVStatusID)=3) AND ((aGRV.GRV_InvoiceInclusive)<>0));");
			if (rsGRVMain.BOF | rsGRVMain.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			sql = "SELECT aGRV.GRVID, Sum((([GRVItem_PackSize]/[GRVItem_StockItemQuantity])*[GRVItem_ContentCost]-[GRVItem_DiscountAmount])*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))) AS exclusive, Sum((([GRVItem_PackSize]/[GRVItem_StockItemQuantity])*[GRVItem_ContentCost]-[GRVItem_DiscountAmount])*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))*(1+[GRVItem_VatRate]/100)) AS inclusive, Sum((([GRVItem_PackSize]/[GRVItem_StockItemQuantity])*[GRVItem_ContentCost])*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))) AS PriceExcl, Sum((([GRVItem_PackSize]/[GRVItem_StockItemQuantity])*[GRVItem_ContentCost])*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))*(1+[GRVItem_VatRate]/100)) AS PriceIncl, Sum([DayEndStockItemLnk_ListCost]*[GRVItem_PackSize]*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))) AS listExcl, Sum([DayEndStockItemLnk_ListCost]*[GRVItem_PackSize]*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))*(1+[GRVItem_VatRate]/100)) AS listIncl, ";
			sql = sql + "Sum([DayEndStockItemLnk_ActualCost]*[GRVItem_PackSize]*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))*(1+[GRVItem_VatRate]/100)) AS actualIncl, Sum([DayEndStockItemLnk_ActualCost]*[GRVItem_PackSize]*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))) AS actualExcl FROM DayEndStockItemLnk INNER JOIN ((aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aGRVItem ON aGRV.GRVID = aGRVItem.GRVItem_GRVID) ON (DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aGRVItem.GRVItem_StockItemID) AND (DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aGRV.GRV_DayEndID) Where (((aGRV.GRV_GRVStatusID) = 3) AND (GRVItem_StockItemQuantity <> 0)) GROUP BY aGRV.GRVID;";
			rsGRVPricing = modReport.getRSreport(ref sql);
			if (rsGRVPricing.BOF | rsGRVPricing.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.Database.Tables(1).SetDataSource(rsGRVItem);
			Report.Database.Tables(2).SetDataSource(rsGRVItemReturn);
			Report.Database.Tables(3).SetDataSource(rsGRVDeposit);
			Report.Database.Tables(4).SetDataSource(rsGRVDepositReturn);
			Report.Database.Tables(5).SetDataSource(rsGRVMain);
			Report.Database.Tables(6).SetDataSource(rsGRVPricing);

			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		private static void report_SalesCube()
		{
			string sql = null;
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			bool lMode = false;
			ADODB.Recordset rs = default(ADODB.Recordset);
			decimal lTotal = default(decimal);
			decimal lSettDiscount = default(decimal);
			decimal OnlyAcclSettDiscount = default(decimal);

			decimal newDis = default(decimal);
			decimal oldDis = default(decimal);

			//For Split tender
			decimal lCash = default(decimal);
			decimal lDebit = default(decimal);
			decimal lCheque = default(decimal);
			decimal lCredit = default(decimal);

			if (My.MyProject.Forms.frmMenu.gSuper == true) {
				Report.Load("crySalesCubeSuper.rpt");
			} else {
				//Set Report = New crySalesCube
				Report.Load("crySalesCubeTouch.rpt");
			}

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

			if (modReport.openConnectionReport()) {
				rs = modReport.getRSreport(ref "SELECT aCompany.Company_Name, Report.Report_Heading FROM aCompany, Report;");
				Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
				Report.SetParameterValue("txtFilter", rs.Fields("Report_Heading"));

				//change translation for report
				//
				modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1974;
				if (modRecordSet.rsLang.RecordCount)
					Report.SetParameterValue("Text41", Strings.Replace(modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value, Constants.vbCrLf, " "));
				//
				modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1975;
				if (modRecordSet.rsLang.RecordCount)
					Report.SetParameterValue("Text42", Strings.Replace(modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value, Constants.vbCrLf, " "));
				//
				modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1976;
				if (modRecordSet.rsLang.RecordCount)
					Report.SetParameterValue("Text43", Strings.Replace(modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value, Constants.vbCrLf, " "));
				//
				modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1977;
				if (modRecordSet.rsLang.RecordCount)
					Report.SetParameterValue("Text44", Strings.Replace(modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value, Constants.vbCrLf, " "));

				//
				modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1974;
				if (modRecordSet.rsLang.RecordCount)
					Report.SetParameterValue("Text57", Strings.Replace(modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value, Constants.vbCrLf, " "));
				//
				modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1975;
				if (modRecordSet.rsLang.RecordCount)
					Report.SetParameterValue("Text58", Strings.Replace(modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value, Constants.vbCrLf, " "));
				//
				modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1976;
				if (modRecordSet.rsLang.RecordCount)
					Report.SetParameterValue("Text59", Strings.Replace(modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value, Constants.vbCrLf, " "));
				//
				modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1977;
				if (modRecordSet.rsLang.RecordCount)
					Report.SetParameterValue("Text60", Strings.Replace(modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value, Constants.vbCrLf, " "));
				//change translation for report

				//get payoutTotal
				rs = modReport.getRSreport(ref "SELECT Sum(Payout.Payout_Amount) AS [amount] FROM Payout;");
				if (Information.IsDBNull(rs.Fields("amount").Value)) {
					Report.SetParameterValue("txtPayout", "0.00");

				} else {
					Report.SetParameterValue("txtPayout", Strings.FormatNumber(rs.Fields("amount").Value, 2));

				}
				rs.Close();

				//get outages.............................

				rs = modReport.getRSreport(ref "SELECT Sum(([Declaration_Cash]+[Declaration_Cheque]+[Declaration_Card]-[Declaration_Payout])-([Declaration_CashServer]+[Declaration_ChequeServer]+[Declaration_CardServer]-[Declaration_PayoutServer])) AS amount FROM Declaration;");
				if (Information.IsDBNull(rs.Fields("amount").Value)) {
					Report.SetParameterValue("txtOutage", "0.00");
				} else {
					Report.SetParameterValue("txtOutage", Strings.FormatNumber(rs.Fields("amount").Value, 2));
				}
				rs.Close();

				//get account movement.....................
				lCash = 0;
				lDebit = 0;
				lCheque = 0;
				lCredit = 0;

				lTotal = 0;
				lSettDiscount = 0;
				OnlyAcclSettDiscount = 0;

				rs = modReport.getRSreport(ref "SELECT Sum(Sale.Sale_Total) AS amount, Sale.Sale_PaymentType, Sum([Sale_Total]-[Sale_Discount]) AS Subtotal, Sum(Sale.Sale_Discount) AS discount, Sum(Sale.Sale_Cash) AS amountCash,Sum(Sale.Sale_Card) AS amountCard,Sum(Sale.Sale_CDebit) AS amountCredit,Sum(Sale.Sale_Cheque) AS amountCheque FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (CustomerTransaction INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((CustomerTransaction.CustomerTransaction_TransactionTypeID) = 2 Or (CustomerTransaction.CustomerTransaction_TransactionTypeID) = 3) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null) And ((Sale.Sale_SaleChk)=False)) GROUP BY Sale.Sale_PaymentType;");
				//Set rs = getRSreport("SELECT Sum(Sale.Sale_Total) AS amount, Sale.Sale_PaymentType, Sum([Sale_Total]-[Sale_Discount]) AS Subtotal, Sum(Sale.Sale_Discount) AS discount, Sum(Sale.Sale_Cash) AS amountCash,Sum(Sale.Sale_Card) AS amountCard,Sum(Sale.Sale_CDebit) AS amountCredit,Sum(Sale.Sale_Cheque) AS amountCheque FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (CustomerTransaction INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((CustomerTransaction.CustomerTransaction_TransactionTypeID) = 2 Or (CustomerTransaction.CustomerTransaction_TransactionTypeID) = 3) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_PaymentType;")
				while (!(rs.EOF)) {
					switch (rs.Fields("Sale_PaymentType").Value) {
						case 5:
							//Revise
							Report.SetParameterValue("txtAccountSales", Strings.FormatNumber(rs.Fields("subtotal").Value, 2));
							Report.SetParameterValue("txtCubeAccountSales", Strings.FormatNumber(rs.Fields("subtotal").Value, 2));
							//05 March 2009 Fixed
							//changed above both line cuz was showing wrong figures on discounts on Universal paints
							Report.SetParameterValue("txtAccountSales", Strings.FormatNumber(rs.Fields("amount").Value, 2));
							Report.SetParameterValue("txtCubeAccountSales", Strings.FormatNumber(rs.Fields("amount").Value, 2));
							OnlyAcclSettDiscount = OnlyAcclSettDiscount + rs.Fields("discount").Value;
							break;
						case 1:
							lTotal = lTotal - rs.Fields("amount").Value;
							lCash = lCash + rs.Fields("amountCash").Value;

							break;
						case 2:
							lTotal = lTotal - rs.Fields("amount").Value;
							lCredit = lCredit + rs.Fields("amountCredit").Value;

							break;
						case 3:
							lTotal = lTotal - rs.Fields("amount").Value;
							lDebit = lDebit + rs.Fields("amountCard").Value;

							break;
						case 4:
							lTotal = lTotal - rs.Fields("amount").Value;
							lCheque = lCheque + rs.Fields("amountCheque").Value;
							break;
						case 7:
							lTotal = lTotal - rs.Fields("amount").Value;
							lCash = lCash + rs.Fields("amountCash").Value;
							lDebit = lDebit + rs.Fields("amountCard").Value;
							lCredit = lCredit + rs.Fields("amountCredit").Value;
							lCheque = lCheque + rs.Fields("amountCheque").Value;
							break;
					}

					lSettDiscount = lSettDiscount + rs.Fields("discount").Value;
					rs.moveNext();
				}

				//Assign account payment......
				Report.SetParameterValue("txtAccountCash", Strings.FormatNumber(0 - lCash, 2));
				Report.SetParameterValue("txtAccountCRcard", Strings.FormatNumber(0 - lCredit, 2));
				Report.SetParameterValue("txtAccountDRcard", Strings.FormatNumber(0 - lDebit, 2));
				Report.SetParameterValue("txtAccountCheque", Strings.FormatNumber(0 - lCheque, 2));

				Report.SetParameterValue("txtAccountPayment", Strings.FormatNumber(lTotal, 2));
				Report.SetParameterValue("txtCubeAccountPayment", Strings.FormatNumber(lTotal, 2));

				//05 March 2009 Fixed
				//changed cuz was showing wrong figures on discounts
				//lTotal = lTotal + CCur(Report.txtAccountSales.Text) '
				lTotal = lTotal + Convert.ToDecimal(Report.ParameterFields("txtCubeAccountSales").ToString);

				Report.SetParameterValue("txtCubeAccount", Strings.FormatNumber(lTotal, 2));
				Report.SetParameterValue("txtAccountTotal", Strings.FormatNumber(lTotal, 2));

				//Settlement Discount........

				rs = modReport.getRSreport(ref "SELECT Sum(CustomerTransaction_Amount) AS lSettDiscount FROM CustomerTransaction WHERE CustomerTransaction_TransactionTypeID = 8;");
				// AND CustomerTransaction_ReferenceID <> 0;")
				if (Information.IsDBNull(rs.Fields("lSettDiscount").Value)) {
					Report.SetParameterValue("txtSettlementDiscount", "0.00");
				} else {
					Report.SetParameterValue("txtSettlementDiscount", Strings.FormatNumber(rs.Fields("lSettDiscount").Value, 2));
				}
				rs.Close();

				//---------------------------
				//Do money movement...
				lCash = 0;
				lDebit = 0;
				lCheque = 0;
				lCredit = 0;

				lTotal = 0;
				//Set rs = getRSreport("SELECT Sale.Sale_PaymentType,Sum(Sale.Sale_Total) as AmountTotal, Sum(Sale.Sale_Cash) AS amountCash,Sum(Sale.Sale_Card) AS amountCard,Sum(Sale.Sale_Cheque) AS amountCheque,Sum(Sale.Sale_CDebit) AS amountCredit FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null) And ((Sale.Sale_SaleChk)=False)) GROUP BY Sale.Sale_PaymentType;")
				rs = modReport.getRSreport(ref "SELECT Sale.Sale_PaymentType,Sum(Sale.Sale_Total) as AmountTotal, Sum(Sale.Sale_Cash) AS amountCash,Sum(Sale.Sale_Card) AS amountCard,Sum(Sale.Sale_Cheque) AS amountCheque,Sum(Sale.Sale_CDebit) AS amountCredit FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_PaymentType;");
				while (!(rs.EOF)) {
					switch (rs.Fields("Sale_PaymentType").Value) {
						case 1:
							lCash = lCash + rs.Fields("amountCash").Value;
							lTotal = lTotal + rs.Fields("AmountTotal").Value;
							break;
						case 2:
							lCredit = lCredit + rs.Fields("amountCredit").Value;
							lTotal = lTotal + rs.Fields("AmountTotal").Value;
							break;
						case 3:
							lDebit = lDebit + rs.Fields("amountCard").Value;
							lTotal = lTotal + rs.Fields("AmountTotal").Value;
							break;
						case 4:
							lTotal = lTotal + rs.Fields("AmountTotal").Value;
							lCheque = lCheque + rs.Fields("amountCheque").Value;
							break;
						case 7:
							lTotal = lTotal + rs.Fields("AmountTotal").Value;
							lCash = lCash + rs.Fields("amountCash").Value;
							lDebit = lDebit + rs.Fields("amountCard").Value;
							lCredit = lCredit + rs.Fields("amountCredit").Value;
							lCheque = lCheque + rs.Fields("amountCheque").Value;
							break;
					}
					rs.moveNext();
				}

				//Assign values....
				Report.SetParameterValue("txtMoneyCash", Strings.FormatNumber(lCash, 2));
				Report.SetParameterValue("txtMoneyCRcard", Strings.FormatNumber(lCredit, 2));
				Report.SetParameterValue("txtMoneyDRcard", Strings.FormatNumber(lDebit, 2));
				Report.SetParameterValue("txtMoneyCheque", Strings.FormatNumber(lCheque, 2));
				rs.Close();
				Report.SetParameterValue("txtCubeMoney", Strings.FormatNumber(lTotal, 2));
				Report.SetParameterValue("txtMoneyTotal", Strings.FormatNumber(lTotal, 2));
				//Report.txtMoneyTotal.SetText FormatNumber(lTotal - (CCur(Report.txtStockDiscount.Text) + newDis + CCur(Abs(IIf(Report.txtStockGratuity.Text = " ", "0", Report.txtStockGratuity.Text)))), 2)
				//-------------

				//------------- Discounts
				//Set rs = getRSreport("SELECT Sum(Sale.Sale_Discount) AS amount FROM aConsignment RIGHT JOIN (aConsignment AS aConsignment_1 RIGHT JOIN Sale ON aConsignment_1.Consignment_SaleID = Sale.SaleID) ON aConsignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null) And ((Sale.Sale_SaleChk)=False));")
				rs = modReport.getRSreport(ref "SELECT Sum(Sale.Sale_Discount) AS amount FROM aConsignment RIGHT JOIN (aConsignment AS aConsignment_1 RIGHT JOIN Sale ON aConsignment_1.Consignment_SaleID = Sale.SaleID) ON aConsignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null));");
				if (Information.IsDBNull(rs.Fields("amount").Value)) {
					Report.SetParameterValue("txtStockDiscount", "0.00");
					oldDis = 0;
				} else {
					if (rs.RecordCount) {
						//Report.txtStockDiscount.SetText FormatNumber(0 - rs("amount"), 2)
						Report.SetParameterValue("txtSCmDiscount", Strings.FormatNumber(0 - rs.Fields("amount").Value, 2));
						oldDis = Convert.ToDecimal(Strings.FormatNumber(0 - rs.Fields("amount").Value, 2));
					} else {
						Report.SetParameterValue("txtStockDiscount", "0.00");
						oldDis = 0;
					}
				}
				rs.Close();

				//Set rs = getRSreport("SELECT Sum(Sale.Sale_Discount) AS amount FROM aConsignment RIGHT JOIN (aConsignment AS aConsignment_1 RIGHT JOIN Sale ON aConsignment_1.Consignment_SaleID = Sale.SaleID) ON aConsignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null) AND ((Sale.Sale_DisChk) = False) And ((Sale.Sale_SaleChk)=False));")
				rs = modReport.getRSreport(ref "SELECT Sum(Sale.Sale_Discount) AS amount FROM aConsignment RIGHT JOIN (aConsignment AS aConsignment_1 RIGHT JOIN Sale ON aConsignment_1.Consignment_SaleID = Sale.SaleID) ON aConsignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null) AND ((Sale.Sale_DisChk) = False));");
				if (Information.IsDBNull(rs.Fields("amount").Value)) {
					Report.SetParameterValue("txtStockDiscount", "0.00");
					oldDis = 0;
				} else {
					if (rs.RecordCount) {
						Report.SetParameterValue("txtStockDiscount", Strings.FormatNumber(0 - rs.Fields("amount").Value, 2));
						//Report.txtSCmDiscount.SetText FormatNumber(0 - rs("amount"), 2)
						oldDis = Convert.ToDecimal(Strings.FormatNumber(0 - rs.Fields("amount").Value, 2));
					} else {
						Report.SetParameterValue("txtStockDiscount", "0.00");
						oldDis = 0;
					}
				}
				rs.Close();
				//------------- Discounts with New Chk

				//Set rs = getRSreport("SELECT Sum(Sale.Sale_Discount) AS amount FROM aConsignment RIGHT JOIN (aConsignment AS aConsignment_1 RIGHT JOIN Sale ON aConsignment_1.Consignment_SaleID = Sale.SaleID) ON aConsignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null) AND ((Sale.Sale_DisChk) = True) And ((Sale.Sale_SaleChk)=False));")
				rs = modReport.getRSreport(ref "SELECT Sum(Sale.Sale_Discount) AS amount FROM aConsignment RIGHT JOIN (aConsignment AS aConsignment_1 RIGHT JOIN Sale ON aConsignment_1.Consignment_SaleID = Sale.SaleID) ON aConsignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null) AND ((Sale.Sale_DisChk) = True));");
				if (Information.IsDBNull(rs.Fields("amount").Value)) {
					Report.SetParameterValue("txtStockDiscount", "0.00");
				} else {
					if (rs.RecordCount) {
						Report.SetParameterValue("txtStockDiscount", Strings.FormatNumber(0 - rs("amount").Value, 2));
						newDis = Convert.ToDecimal(Strings.FormatNumber(0 - rs.Fields("amount").Value, 2));
						Report.SetParameterValue("txtSCmDiscount", Strings.FormatNumber(0 - rs("amount").Value, 2));
					} else {
						Report.SetParameterValue("txtStockDiscount", "0.00");
					}
				}
				rs.Close();


				//-------------Grutity
				//Set rs = getRSreport("SELECT Sum(Sale.Sale_Gratuity) AS amountGr FROM aConsignment RIGHT JOIN (aConsignment AS aConsignment_1 RIGHT JOIN Sale ON aConsignment_1.Consignment_SaleID = Sale.SaleID) ON aConsignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null) And ((Sale.Sale_SaleChk)=False));")
				rs = modReport.getRSreport(ref "SELECT Sum(Sale.Sale_Gratuity) AS amountGr FROM aConsignment RIGHT JOIN (aConsignment AS aConsignment_1 RIGHT JOIN Sale ON aConsignment_1.Consignment_SaleID = Sale.SaleID) ON aConsignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null));");
				if (Information.IsDBNull(rs.Fields("amountGr").Value)) {
					Report.SetParameterValue("txtStockGratuity", "0.00");
					Report.SetParameterValue("txtStockGratuity", " ");
					Report.SetParameterValue("Text94", " ");
				} else {
					if (rs.RecordCount) {
						Report.SetParameterValue("txtStockGratuity", Strings.FormatNumber(0 - rs.Fields("amountGr").Value, 2));
						//Report.txtSCmDiscount.SetText FormatNumber(0 - rs("amount"), 2)
					} else {
						Report.SetParameterValue("txtStockGratuity", "0.00");
						Report.SetParameterValue("txtStockGratuity", " ");
						Report.SetParameterValue("Text94", " ");
					}
				}
				rs.Close();
				rs = modReport.getRSreport(ref "SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS content, CBool([SaleItem_DepositType]) AS depositType, SaleItem.SaleItem_Reversal, Sum(([SaleItem_DepositCost]*[SaleItem_Quantity])*(1+[SaleItem_Vat]/100)) AS deposit FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY CBool([SaleItem_DepositType]), SaleItem.SaleItem_Reversal;");
				while (!(rs.EOF)) {
					if (rs.Fields("depositType").Value) {
						if (rs.Fields("SaleItem_Reversal").Value) {
							Report.SetParameterValue("txtStockDepositSold", Strings.FormatNumber(rs.Fields("content").Value, 2));
						} else {
							Report.SetParameterValue("txtStockDepositReturn", Strings.FormatNumber(rs.Fields("content").Value, 2));
						}
					} else {
						if (rs.Fields("SaleItem_Reversal").Value) {
							Report.SetParameterValue("txtStockCreditContent", Strings.FormatNumber(rs.Fields("content").Value, 2));
							Report.SetParameterValue("txtStockCreditDeposit", Strings.FormatNumber(0 - rs.Fields("deposit").Value, 2));
						} else {
							Report.SetParameterValue("txtStockSoldContent", Strings.FormatNumber(rs.Fields("content").Value, 2));
							Report.SetParameterValue("txtStockSoldDeposit", Strings.FormatNumber(rs.Fields("deposit").Value, 2));
						}
					}
					rs.moveNext();
				}
				rs.Close();

				Report.SetParameterValue("txtStockDepositReturn1", Report.ParameterFields("txtStockDepositReturn").ToString);
				Report.SetParameterValue("txtStockDepositSold1", Report.ParameterFields("txtStockDepositSold").ToString);
				Report.SetParameterValue("txtTotalDepositMove", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtStockDepositReturn1").ToString) + Convert.ToDecimal(Report.ParameterFields("txtStockDepositSold1").ToString), 2));

				 // ERROR: Not supported in C#: OnErrorStatement

				Report.SetParameterValue("txtStockSoldContent", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtStockSoldContent").ToString) - Convert.ToDecimal(Report.ParameterFields("txtStockSoldDeposit").ToString), 2));
				Report.SetParameterValue("txtStockCreditContent", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtStockCreditContent").ToString) - Convert.ToDecimal(Report.ParameterFields("txtStockCreditDeposit").ToString), 2));
				Report.SetParameterValue("txtStockSold", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtStockSoldContent").ToString) + Convert.ToDecimal(Report.ParameterFields("txtStockSoldDeposit").ToString), 2));
				Report.SetParameterValue("txtStockCreditTotal", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtStockCreditContent").ToString) + Convert.ToDecimal(Report.ParameterFields("txtStockCreditDeposit").ToString), 2));
				Report.SetParameterValue("txtStockSold1", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtStockSold").ToString) + (oldDis), 2));
				Report.SetParameterValue("txtStockCreditTotal1", Report.ParameterFields("txtStockCreditTotal").ToString);
				Report.SetParameterValue("txtTotalStockMove", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtStockSold1").ToString) + Convert.ToDecimal(Report.ParameterFields("txtStockCreditTotal1").ToString), 2));
				Report.SetParameterValue("txtMoneyTill", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtMoneyTotal").ToString) + Convert.ToDecimal(Report.ParameterFields("txtOutage").ToString) - Convert.ToDecimal(Report.ParameterFields("txtPayout").ToString), 2));
				Report.SetParameterValue("txtCubeDirect", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtCubeMoney").ToString) + Convert.ToDecimal(Report.ParameterFields("txtCubeAccountPayment").ToString), 2));
				Report.SetParameterValue("txtCubeStock", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtCubeDirect").ToString) + Convert.ToDecimal(Report.ParameterFields("txtCubeAccountSales").ToString), 2));
				lTotal = Convert.ToDecimal(Report.ParameterFields("txtStockCreditTotal").ToString) + Convert.ToDecimal(Report.ParameterFields("txtStockDepositReturn").ToString) + Convert.ToDecimal(Report.ParameterFields("txtStockDepositSold").ToString) + Convert.ToDecimal(Report.ParameterFields("txtStockSold").ToString) + Convert.ToDecimal(Report.ParameterFields("txtStockDiscount").ToString) + Convert.ToDecimal(System.Math.Abs((Report.ParameterFields("txtStockGratuity").ToString == " " ? "0" : Report.ParameterFields("txtStockGratuity").ToString)));
				//lTotal = CCur(Report.txtStockCreditTotal.Text) + CCur(Report.txtStockDepositReturn.Text) + CCur(Report.txtStockDepositSold.Text) + CCur(Report.txtStockSold.Text) + CCur(Report.txtStockDiscount.Text) + newDis '+ CCur(Abs(IIf(Report.txtStockGratuity.Text = " ", "0", Report.txtStockGratuity.Text)))
				Report.SetParameterValue("txtStockTotal", Strings.FormatNumber(lTotal, 2));
				//------------- Discounts with New Chk
				Report.SetParameterValue("txtStockDiscount", Strings.FormatNumber(newDis + Convert.ToDecimal(Report.ParameterFields("txtStockDiscount").ToString), 2));


				// to change StockTotal, MoneyTotal, CubeStock, CubeMoney, CubeDirect
				Report.SetParameterValue("txtStockTotal", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtStockTotal").ToString) - (Convert.ToDecimal(System.Math.Abs((Report.ParameterFields("txtStockGratuity").ToString == " " ? "0" : Report.ParameterFields("txtStockGratuity").ToString)))), 2));
				Report.SetParameterValue("txtMoneyTotal", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtMoneyTotal").ToString) - (Convert.ToDecimal(System.Math.Abs((Report.ParameterFields("txtStockGratuity").ToString == " " ? "0" : Report.ParameterFields("txtStockGratuity").ToString)))), 2));
				Report.SetParameterValue("txtCubeStock", Strings.FormatNumber((Convert.ToDecimal(Report.ParameterFields("txtCubeStock").ToString)) - (Convert.ToDecimal(System.Math.Abs((Report.ParameterFields("txtStockGratuity").ToString == " " ? "0" : Report.ParameterFields("txtStockGratuity").ToString)))), 2));
				//+ OnlyAcclSettDiscount
				Report.SetParameterValue("txtCubeMoney", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtCubeMoney").ToString) - (Convert.ToDecimal(System.Math.Abs((Report.ParameterFields("txtStockGratuity").ToString == " " ? "0" : Report.ParameterFields("txtStockGratuity").ToString)))), 2));
				Report.SetParameterValue("txtCubeDirect", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtCubeDirect").ToString) - (Convert.ToDecimal(System.Math.Abs((Report.ParameterFields("txtStockGratuity").ToString == " " ? "0" : Report.ParameterFields("txtStockGratuity").ToString)))), 2));

				//Old Account Journal Movement
				rs = modReport.getRSreport(ref "SELECT Sum(aCustomerTransaction.CustomerTransaction_Amount) AS SumOfCustomerTransaction_Amount FROM aCustomerTransaction INNER JOIN DayEnd ON aCustomerTransaction.CustomerTransaction_DayEndID = DayEnd.DayEndID WHERE (((aCustomerTransaction.CustomerTransaction_TransactionTypeID)=3 Or (aCustomerTransaction.CustomerTransaction_TransactionTypeID)=4 Or (aCustomerTransaction.CustomerTransaction_TransactionTypeID)=5) AND ((aCustomerTransaction.CustomerTransaction_ReferenceID)=0));");
				//Set rs = getRSreport("SELECT Sum(aCustomerTransaction.CustomerTransaction_Amount) AS SumOfCustomerTransaction_Amount FROM aCustomerTransaction INNER JOIN DayEnd ON aCustomerTransaction.CustomerTransaction_DayEndID = DayEnd.DayEndID WHERE (((aCustomerTransaction.CustomerTransaction_TransactionTypeID)=3 Or (aCustomerTransaction.CustomerTransaction_TransactionTypeID)=4 Or (aCustomerTransaction.CustomerTransaction_TransactionTypeID)=5 Or (aCustomerTransaction.CustomerTransaction_TransactionTypeID)=8) AND ((aCustomerTransaction.CustomerTransaction_ReferenceID)=0));")
				if (rs.RecordCount) {
					Report.SetParameterValue("txtAccountEFT", Strings.FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2));
				} else {
					Report.SetParameterValue("txtAccountEFT", Strings.FormatNumber(0, 2));
				}

				//**************************
				//*** Profit Summary ***
				//**************************
				//        Set rs = getRSreport("SELECT Sum(([SaleItem_ActualCost]*[SaleItem_Quantity])) AS actualExcl, Sum(([SaleItem_ActualCost]*[SaleItem_Quantity])*(1+[SaleItem_Vat]/100)) AS actualIncl, Sum(([SaleItem_ListCost]*[SaleItem_Quantity])) AS listExcl, Sum(([SaleItem_ListCost]*[SaleItem_Quantity])*(1+[SaleItem_Vat]/100)) AS listIncl, Sum([SaleItem_Price]*[SaleItem_Quantity]/(1+[SaleItem_Vat]/100)) AS priceExcl, Sum([SaleItem_Price]*[SaleItem_Quantity]) AS priceIncl, Sum(([SaleItem_DepositCost]*[SaleItem_Quantity])) AS depositExcl, Sum(([SaleItem_DepositCost]*[SaleItem_Quantity])*(1+[SaleItem_Vat]/100)) AS depositIncl FROM aConsignment AS aConsignment_1 RIGHT JOIN (SaleItem LEFT JOIN aConsignment ON SaleItem.SaleItem_SaleID = aConsignment.Consignment_SaleID) ON aConsignment_1.Consignment_ReversalSaleID = SaleItem.SaleItem_SaleID WHERE (((SaleItem.SaleItem_DepositType)=0) AND ((SaleItem.SaleItem_Revoke)=False) AND ((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null));")


				sql = "SELECT Sum(IIf([SaleItem_Reversal],0-[SaleItem_ActualCost]*[SaleItem_Quantity],[SaleItem_ActualCost]*[SaleItem_Quantity])) AS actualExcl, Sum(((IIf([SaleItem_Reversal],0-[SaleItem_ActualCost]*[SaleItem_Quantity],[SaleItem_ActualCost]*[SaleItem_Quantity]))*(1+[SaleItem_Vat]/100))) AS actualIncl, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ListCost]*[SaleItem_Quantity],[SaleItem_ListCost]*[SaleItem_Quantity])) AS listExcl, Sum(((IIf([SaleItem_Reversal],0-[SaleItem_ListCost]*[SaleItem_Quantity],[SaleItem_ListCost]*[SaleItem_Quantity]))*(1+[SaleItem_Vat]/100))) AS listIncl, Sum(([SaleItem_Price]*[SaleItem_Quantity]/(1+[SaleItem_Vat]/100))) AS priceExcl, Sum(([SaleItem_Price]*[SaleItem_Quantity])) AS priceIncl, Sum(IIf([SaleItem_Reversal],0-[SaleItem_DepositCost]*[SaleItem_Quantity],[SaleItem_DepositCost]*[SaleItem_Quantity])) AS depositExcl, Sum((IIf([SaleItem_Reversal],0-[SaleItem_DepositCost]*[SaleItem_Quantity],[SaleItem_DepositCost]*[SaleItem_Quantity]))*(1+[SaleItem_Vat]/100)) AS depositIncl ";
				sql = sql + "FROM aConsignment AS aConsignment_1 RIGHT JOIN (SaleItem LEFT JOIN aConsignment ON SaleItem.SaleItem_SaleID = aConsignment.Consignment_SaleID) ON aConsignment_1.Consignment_ReversalSaleID = SaleItem.SaleItem_SaleID ";
				sql = sql + "WHERE (((SaleItem.SaleItem_DepositType)=0) AND ((SaleItem.SaleItem_Revoke)=False) AND ((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null));";

				rs = modReport.getRSreport(ref sql);
				Report.SetParameterValue("txtLEcost", Strings.FormatNumber(rs.Fields("listExcl").Value, 0));
				Report.SetParameterValue("txtAEcost", Strings.FormatNumber(rs.Fields("actualExcl").Value, 0));
				Report.SetParameterValue("txtLIcost", Strings.FormatNumber(rs.Fields("listIncl").Value, 0));
				Report.SetParameterValue("txtAIcost", Strings.FormatNumber(rs.Fields("actualIncl").Value, 0));
				if (string.IsNullOrEmpty(Report.ParameterFields("txtLEcost").ToString))
					Report.SetParameterValue("txtLEcost", "0");
				if (string.IsNullOrEmpty(Report.ParameterFields("txtLIcost").ToString))
					Report.SetParameterValue("txtLIcost", "0");
				if (string.IsNullOrEmpty(Report.ParameterFields("txtAEcost").ToString))
					Report.SetParameterValue("txtAEcost", "0");
				if (string.IsNullOrEmpty(Report.ParameterFields("txtAIcost").ToString))
					Report.SetParameterValue("txtAIcost", "0");

				Report.SetParameterValue("txtLEdeposit", Strings.FormatNumber(rs.Fields("depositExcl").Value, 0));
				Report.SetParameterValue("txtLIdeposit", Strings.FormatNumber(rs.Fields("depositIncl").Value, 0));
				Report.SetParameterValue("txtAEdeposit", Strings.FormatNumber(rs.Fields("depositExcl").Value, 0));
				Report.SetParameterValue("txtAIdeposit", Strings.FormatNumber(rs.Fields("depositIncl").Value, 0));
				if (string.IsNullOrEmpty(Report.ParameterFields("txtLEdeposit").ToString))
					Report.SetParameterValue("txtLEdeposit", "0");
				if (string.IsNullOrEmpty(Report.ParameterFields("txtLIdeposit").ToString))
					Report.SetParameterValue("txtLIdeposit", "0");
				if (string.IsNullOrEmpty(Report.ParameterFields("txtAEdeposit").ToString))
					Report.SetParameterValue("txtAEdeposit", "0");
				if (string.IsNullOrEmpty(Report.ParameterFields("txtAIdeposit").ToString))
					Report.SetParameterValue("txtAIdeposit", "0");

				Report.SetParameterValue("txtLEcontent", Strings.FormatNumber(rs.Fields("priceExcl").Value - rs.Fields("depositExcl").Value + (oldDis), 0));
				Report.SetParameterValue("txtLIcontent", Strings.FormatNumber(rs.Fields("priceIncl").Value - rs.Fields("depositIncl").Value + (oldDis), 0));
				Report.SetParameterValue("txtAEcontent", Strings.FormatNumber(rs.Fields("priceExcl").Value - rs.Fields("depositExcl").Value + (oldDis), 0));
				Report.SetParameterValue("txtAIcontent", Strings.FormatNumber(rs.Fields("priceIncl").Value - rs.Fields("depositIncl").Value + (oldDis), 0));
				if (string.IsNullOrEmpty(Report.ParameterFields("txtLEcontent").ToString))
					Report.SetParameterValue("txtLEcontent", "0");
				if (string.IsNullOrEmpty(Report.ParameterFields("txtLIcontent").ToString))
					Report.SetParameterValue("txtLIcontent", "0");
				if (string.IsNullOrEmpty(Report.ParameterFields("txtAEcontent").ToString))
					Report.SetParameterValue("txtAEcontent", "0");
				if (string.IsNullOrEmpty(Report.ParameterFields("txtAIcontent").ToString))
					Report.SetParameterValue("txtAIcontent", "0");

				Report.SetParameterValue("txtLEProfit", Strings.FormatNumber((rs.Fields("priceExcl").Value - rs.Fields("depositExcl").Value) - (rs.Fields("listExcl")).Value, 0));
				Report.SetParameterValue("txtLIProfit", Strings.FormatNumber((rs.Fields("priceIncl").Value - rs.Fields("depositIncl").Value) - (rs.Fields("listIncl")).Value, 0));
				Report.SetParameterValue("txtAEProfit", Strings.FormatNumber((rs.Fields("priceExcl").Value - rs.Fields("depositExcl").Value) - (rs.Fields("actualExcl")).Value, 0));
				Report.SetParameterValue("txtAIProfit", Strings.FormatNumber((rs.Fields("priceIncl").Value - rs.Fields("depositIncl").Value) - (rs.Fields("actualIncl")).Value, 0));
				if (Convert.ToDecimal(Report.ParameterFields("txtLEcost").ToString) == 0) {
					if (string.IsNullOrEmpty(Report.ParameterFields("txtLEProfit").ToString))
						Report.SetParameterValue("txtLEProfit", "0");
					if (string.IsNullOrEmpty(Report.ParameterFields("txtLIProfit").ToString))
						Report.SetParameterValue("txtLIProfit", "0");
					if (string.IsNullOrEmpty(Report.ParameterFields("txtAEProfit").ToString))
						Report.SetParameterValue("txtAEProfit", "0");
					if (string.IsNullOrEmpty(Report.ParameterFields("txtAIProfit").ToString))
						Report.SetParameterValue("txtAIProfit", "0");
				} else {
					Report.SetParameterValue("txtLEPerc", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtLEProfit").ToString) / Convert.ToDecimal(Report.ParameterFields("txtLEcost").ToString) * 100, 2) + "%");
					Report.SetParameterValue("txtLIPerc", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtLIProfit").ToString) / Convert.ToDecimal(Report.ParameterFields("txtLIcost").ToString) * 100, 2) + "%");
					Report.SetParameterValue("txtAEPerc", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtAEProfit").ToString) / Convert.ToDecimal(Report.ParameterFields("txtAEcost").ToString) * 100, 2) + "%");
					Report.SetParameterValue("txtAIPerc", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtAIProfit").ToString) / Convert.ToDecimal(Report.ParameterFields("txtAIcost").ToString) * 100, 2) + "%");
				}
				Report.SetParameterValue("txtLEtotalProfit", Strings.FormatNumber(rs.Fields("priceExcl").Value - rs.Fields("listExcl").Value - rs.Fields("depositExcl").Value + (oldDis), 0));
				Report.SetParameterValue("txtLItotalProfit", Strings.FormatNumber(rs.Fields("priceIncl").Value - rs.Fields("listIncl").Value - rs.Fields("depositIncl").Value + (oldDis), 0));

				Report.SetParameterValue("txtAEtotalProfit", Strings.FormatNumber(rs.Fields("priceExcl").Value - rs.Fields("actualExcl").Value - rs.Fields("depositExcl").Value + (oldDis), 0));
				Report.SetParameterValue("txtAItotalProfit", Strings.FormatNumber(rs.Fields("priceIncl").Value - rs.Fields("actualIncl").Value - rs.Fields("depositIncl").Value + (oldDis), 0));
				if (string.IsNullOrEmpty(Report.ParameterFields("txtLEtotalProfit").ToString))
					Report.SetParameterValue("txtLEtotalProfit", "0");
				if (string.IsNullOrEmpty(Report.ParameterFields("txtLItotalProfit").ToString))
					Report.SetParameterValue("txtLItotalProfit", "0");
				if (string.IsNullOrEmpty(Report.ParameterFields("txtAEtotalProfit").ToString))
					Report.SetParameterValue("txtAEtotalProfit", "0");
				if (string.IsNullOrEmpty(Report.ParameterFields("txtAItotalProfit").ToString))
					Report.SetParameterValue("txtAItotalProfit", "0");

				Report.SetParameterValue("txtLEtotal", Strings.FormatNumber(rs.Fields("priceExcl").Value + (oldDis), 0));
				Report.SetParameterValue("txtLItotal", Strings.FormatNumber(rs.Fields("priceIncl").Value + (oldDis), 0));
				Report.SetParameterValue("txtAEtotal", Strings.FormatNumber(rs.Fields("priceExcl").Value + (oldDis), 0));
				Report.SetParameterValue("txtAItotal", Strings.FormatNumber(rs.Fields("priceIncl").Value + (oldDis), 0));
				if (string.IsNullOrEmpty(Report.ParameterFields("txtLEtotal").ToString))
					Report.SetParameterValue("txtLEtotal", "0");
				if (string.IsNullOrEmpty(Report.ParameterFields("txtLItotal").ToString))
					Report.SetParameterValue("txtLItotal", "0");
				if (string.IsNullOrEmpty(Report.ParameterFields("txtAEtotal").ToString))
					Report.SetParameterValue("txtAEtotal", "0");
				if (string.IsNullOrEmpty(Report.ParameterFields("txtAItotal").ToString))
					Report.SetParameterValue("txtAItotal", "0");

				if (Convert.ToDecimal(Report.ParameterFields("txtLEcost").ToString) == 0) {
				} else {
					Report.SetParameterValue("txtLEtotalPerc", Strings.FormatNumber((1 - ((rs.Fields("listExcl").Value + oldDis) + rs.Fields("depositExcl").Value) / rs.Fields("priceExcl").Value) * 100, 2) + "%");
					Report.SetParameterValue("txtLItotalPerc", Strings.FormatNumber((1 - ((rs.Fields("listIncl").Value + oldDis) + rs.Fields("depositIncl").Value) / rs.Fields("priceIncl").Value) * 100, 2) + "%");
					Report.SetParameterValue("txtAEtotalPerc", Strings.FormatNumber((1 - ((rs.Fields("actualExcl").Value + oldDis) + rs.Fields("depositExcl").Value) / rs.Fields("priceExcl").Value) * 100, 2) + "%");
					Report.SetParameterValue("txtAItotalPerc", Strings.FormatNumber((1 - ((rs.Fields("actualIncl").Value + oldDis) + rs.Fields("depositIncl").Value) / rs.Fields("priceIncl").Value) * 100, 2) + "%");
				}

				//***Stock Holding
				if (lMode) {
				} else {
					rs = modReport.getRSreport(ref "SELECT Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost]) AS listSales, Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ActualCost]) AS actualSales, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS listShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actualShrink, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost]) AS listGRV, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ActualCost]) AS actualGRV FROM DayEndStockItemLnk;");
					if (Information.IsDBNull(rs.Fields("listShrink").Value)) {
						Report.SetParameterValue("txtSHRL", Strings.FormatNumber(0, 2));
					} else {
						Report.SetParameterValue("txtSHRL", Strings.FormatNumber(rs.Fields("listShrink").Value, 2));
					}
					if (Information.IsDBNull(rs.Fields("listGRV").Value)) {
						Report.SetParameterValue("txtGRVL", Strings.FormatNumber(0, 2));
					} else {
						Report.SetParameterValue("txtGRVL", Strings.FormatNumber(rs.Fields("listGRV").Value, 2));
					}
					if (Information.IsDBNull(rs.Fields("listSales").Value)) {
						Report.SetParameterValue("txtSaleL", Strings.FormatNumber(0, 2));
					} else {
						Report.SetParameterValue("txtSaleL", Strings.FormatNumber(rs.Fields("listSales").Value, 2));
					}

					//Report.txtSHRA.SetText FormatNumber(rs("actualShrink"), 2)
					//Report.txtGRVA.SetText FormatNumber(rs("actualGRV"), 2)
					//Report.txtSaleA.SetText FormatNumber(rs("actualSales"), 2)

					rs = modReport.getRSreport(ref "SELECT Sum(([DayEndStockItemLnk]![DayEndStockItemLnk_ListCost]-[DayEndStockItemLnkfrom]![DayEndStockItemLnk_ListCost])*[DayEndStockItemLnk]![DayEndStockItemLnk_Quantity]) AS totalProfitList, Sum(([DayEndStockItemLnk]![DayEndStockItemLnk_ActualCost]-[DayEndStockItemLnkfrom]![DayEndStockItemLnk_ActualCost])*[DayEndStockItemLnk]![DayEndStockItemLnk_Quantity]) AS totalProfitActual FROM [SELECT DayEndStockItemLnkFirst.* From DayEndStockItemLnkFirst Union SELECT DayEndStockItemLnk.* From DayEndStockItemLnk ]. AS dayendStockItemLnkFrom INNER JOIN DayEndStockItemLnk ON dayendStockItemLnkFrom.DayEndStockItemLnk_StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)=[DayEndStockItemLnkfrom]![DayEndStockItemLnk_DayEndID]+1));");
					if (Information.IsDBNull(rs.Fields("totalProfitList").Value)) {
						Report.SetParameterValue("TxtSVarianceL", Strings.FormatNumber(0, 2));
					} else {
						Report.SetParameterValue("txtSVarianceL", Strings.FormatNumber(rs.Fields("totalProfitList").Value, 2));
					}
					Report.SetParameterValue("txtSVarianceA", Strings.FormatNumber(0, 2));

					rs = modReport.getRSreport(ref "SELECT Sum(([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ListCost]) AS list, Sum(([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_actualCost]) AS actual FROM Report INNER JOIN DayEndStockItemLnk ON Report.Report_DayEndEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID;");
					Report.SetParameterValue("txtSHLclose", Strings.FormatNumber(rs.Fields("list").Value, 2));
					//        Report.txtSHAclose.SetText FormatNumber(rs("actual"), 2)

					rs = modReport.getRSreport(ref "SELECT Sum(IIf([DayEndDeposittemLnk_DepositType]=0,[DayEndDepositItemLnk_UnitCost]*([DayEndDepositItemLnk_Quantity]-DayEndDepositItemLnk_QuantitySales-DayEndDepositItemLnk_QuantityShrink+DayEndDepositItemLnk_QuantityGRV),[DayEndDepositItemLnk_CaseCost]*([DayEndDepositItemLnk_Quantity]-DayEndDepositItemLnk_QuantitySales-DayEndDepositItemLnk_QuantityShrink+DayEndDepositItemLnk_QuantityGRV))) AS actual FROM Report INNER JOIN DayEndDepositItemLnk ON Report.Report_DayEndEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID;");
					Report.SetParameterValue("txtSHAclose", Strings.FormatNumber(rs.Fields("actual").Value, 2));

					rs = modReport.getRSreport(ref "SELECT Sum([DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk_ListCost]) AS list, Sum([DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk_actualCost]) AS actual FROM Report INNER JOIN DayEndStockItemLnk ON Report.Report_DayEndStartID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID;");
					if (rs.RecordCount) {
						Report.SetParameterValue("txtSHLopen", Strings.FormatNumber(rs.Fields("list").Value, 2));
						Report.SetParameterValue("txtSHAopen", Strings.FormatNumber(rs.Fields("actual").Value, 2));
					} else {
						Report.SetParameterValue("txtSHLopen", Strings.FormatNumber(0, 2));
						Report.SetParameterValue("txtSHAopen", Strings.FormatNumber(0, 2));
					}

					rs = modReport.getRSreport(ref "SELECT Sum((IIf([DayEndDeposittemLnk_DepositType]=0,[DayEndDepositItemLnk_UnitCost],[DayEndDepositItemLnk_CaseCost])*([DayEndDepositItemLnk_Quantity]))) AS Quantity FROM Report INNER JOIN DayEndDepositItemLnk ON Report.Report_DayEndStartID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID;");
					if (rs.RecordCount) {
						Report.SetParameterValue("txtSHAopen", Strings.FormatNumber(rs.Fields("quantity").Value, 2));
					} else {
						Report.SetParameterValue("txtSHAopen", Strings.FormatNumber(0, 2));
					}

					//Set rs = getRSreport("SELECT Sum(IIf([DayEndDeposittemLnk_DepositType]=0,[DayEndDepositItemLnk_UnitCost],[DayEndDepositItemLnk_CaseCost])*[DayEndDepositItemLnk_QuantitySales]) AS Sales, Sum(IIf([DayEndDeposittemLnk_DepositType]=0,[DayEndDepositItemLnk_UnitCost],[DayEndDepositItemLnk_CaseCost])*[DayEndDepositItemLnk_QuantityShrink]) AS Shrink, Sum(IIf([DayEndDeposittemLnk_DepositType]=0,[DayEndDepositItemLnk_UnitCost],[DayEndDepositItemLnk_CaseCost])*[DayEndDepositItemLnk_QuantityGRV]) AS GRV From Report, DayEndDepositItemLnk")
					rs = modReport.getRSreport(ref "SELECT Sum(IIf([DayEndDeposittemLnk_DepositType]=0,[DayEndDepositItemLnk_UnitCost],[DayEndDepositItemLnk_CaseCost])*[DayEndDepositItemLnk_QuantitySales]) AS Sales, Sum(IIf([DayEndDeposittemLnk_DepositType]=0,[DayEndDepositItemLnk_UnitCost],[DayEndDepositItemLnk_CaseCost])*[DayEndDepositItemLnk_QuantityShrink]) AS Shrink, Sum(IIf([DayEndDeposittemLnk_DepositType]=0,[DayEndDepositItemLnk_UnitCost],[DayEndDepositItemLnk_CaseCost])*[DayEndDepositItemLnk_QuantityGRV]) AS GRV From DayEndDepositItemLnk");
					Report.SetParameterValue("txtSHRA", Strings.FormatNumber(0 - rs.Fields("Shrink").Value, 2));
					Report.SetParameterValue("txtGRVA", Strings.FormatNumber(rs.Fields("GRV").Value, 2));
					Report.SetParameterValue("txtSaleA", Strings.FormatNumber(0 - rs.Fields("Sales").Value, 2));
					Report.SetParameterValue("txtSVarianceA", Strings.FormatNumber(0, 2));
					Report.SetParameterValue("txtSVarianceT", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtSVarianceA").ToString) + Convert.ToDecimal(Report.ParameterFields("txtSVarianceA").ToString), 2));
					Report.SetParameterValue("txtSaleT", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtSaleA").ToString) + Convert.ToDecimal(Report.ParameterFields("txtSaleL").ToString), 2));
					Report.SetParameterValue("txtGRVT", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtGRVA").ToString) + Convert.ToDecimal(Report.ParameterFields("txtGRVL").ToString), 2));
					Report.SetParameterValue("txtSHRT", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtSHRA").ToString) + Convert.ToDecimal(Report.ParameterFields("txtSHRL").ToString), 2));
					Report.SetParameterValue("txtSHTopen", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtSHAopen").ToString) + Convert.ToDecimal(Report.ParameterFields("txtSHLopen").ToString), 2));
					Report.SetParameterValue("txtSHTclose", Strings.FormatNumber(Convert.ToDecimal(Report.ParameterFields("txtSHAclose").ToString) + Convert.ToDecimal(Report.ParameterFields("txtSHLclose").ToString), 2));
				}
				rs = modReport.getRSreport(ref "SELECT Sum([SaleItem_ListCost]*[SaleItem_Quantity]) AS list, Sum([SaleItem_ActualCost]*[SaleItem_Quantity]) AS actual FROM aConsignment INNER JOIN SaleItem ON aConsignment.Consignment_SaleID = SaleItem.SaleItem_SaleID;");
				if (Information.IsDBNull(rs.Fields("list").Value)) {
					Report.SetParameterValue("txtConsLsales", Strings.FormatNumber("0", 2));
					Report.SetParameterValue("txtConsAsales", Strings.FormatNumber("0", 2));
				} else {
					Report.SetParameterValue("txtConsLsales", Strings.FormatNumber(rs.Fields("list").Value, 2));
					Report.SetParameterValue("txtConsAsales", Strings.FormatNumber(rs.Fields("actual").Value, 2));
				}
				rs = modReport.getRSreport(ref "SELECT Sum(Sale.Sale_Total) AS [amount] FROM aConsignment INNER JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID;");
				if (Information.IsDBNull(rs.Fields("amount").Value)) {
					Report.SetParameterValue("txtConsPsales", Strings.FormatNumber("0", 2));
				} else {
					Report.SetParameterValue("txtConsPsales", Strings.FormatNumber(rs.Fields("amount").Value, 2));
				}

				rs = modReport.getRSreport(ref "SELECT Sum([SaleItem_ListCost]*[SaleItem_Quantity]) AS list, Sum([SaleItem_ActualCost]*[SaleItem_Quantity]) AS actual FROM aConsignment INNER JOIN SaleItem ON aConsignment.Consignment_CompleteSaleID = SaleItem.SaleItem_SaleID;");
				if (Information.IsDBNull(rs.Fields("list").Value)) {
					Report.SetParameterValue("txtConsLPurchase", Strings.FormatNumber("0", 2));
					Report.SetParameterValue("txtConsAPurchase", Strings.FormatNumber("0", 2));
				} else {
					Report.SetParameterValue("txtConsLPurchase", Strings.FormatNumber(rs.Fields("list").Value, 2));
					Report.SetParameterValue("txtConsAPurchase", Strings.FormatNumber(rs.Fields("actual").Value, 2));
				}

				rs = modReport.getRSreport(ref "SELECT Sum(theJoin.list) AS list, Sum(theJoin.actual) AS actual FROM (SELECT  1 AS sale, Sum([SaleItem_Quantity]*[SaleItem_ListCost]) AS list, Sum([SaleItem_Quantity]*[SaleItem_actualCost]) AS actual FROM SaleItem INNER JOIN aConsignment ON SaleItem.SaleItem_SaleID = aConsignment.Consignment_CompleteSaleID Union SELECT 0 AS sale, Sum(0-[SaleItem_Quantity]*[SaleItem_ListCost]) AS list, Sum(0-[SaleItem_Quantity]*[SaleItem_actualCost]) AS actual FROM aConsignment INNER JOIN SaleItem ON aConsignment.Consignment_SaleID = SaleItem.SaleItem_SaleID WHERE (((aConsignment.Consignment_CompleteSaleID) Is Not Null))) AS theJoin;");
				if (Information.IsDBNull(rs.Fields("list").Value)) {
					Report.SetParameterValue("txtConsLreturn", Strings.FormatNumber("0", 2));
					Report.SetParameterValue("txtConsAreturn", Strings.FormatNumber("0", 2));
				} else {
					Report.SetParameterValue("txtConsLreturn", Strings.FormatNumber(rs.Fields("list").Value, 2));
					Report.SetParameterValue("txtConsAreturn", Strings.FormatNumber(rs.Fields("actual").Value, 2));
				}

				rs = modReport.getRSreport(ref "SELECT Sum([Sale]![Sale_Total]+[Sale_1]![Sale_Total]) AS priceReturn, Sale.Sale_Total FROM Sale INNER JOIN (Sale AS Sale_1 INNER JOIN aConsignment ON Sale_1.SaleID = aConsignment.Consignment_ReversalSaleID) ON Sale.SaleID = aConsignment.Consignment_CompleteSaleID GROUP BY Sale.Sale_Total;");
				if (rs.BOF | rs.EOF) {
					Report.SetParameterValue("txtConsPPurchase", Strings.FormatNumber("0", 2));
					Report.SetParameterValue("txtConsPreturn", Strings.FormatNumber("0", 2));
				} else {
					if (Information.IsDBNull(rs.Fields("Sale_Total").Value)) {
						Report.SetParameterValue("txtConsPPurchase", Strings.FormatNumber("0", 2));
						Report.SetParameterValue("txtConsPreturn", Strings.FormatNumber("0", 2));
					} else {
						Report.SetParameterValue("txtConsPPurchase", Strings.FormatNumber(rs.Fields("Sale_Total").Value, 2));
						Report.SetParameterValue("txtConsPreturn", Strings.FormatNumber(rs.Fields("priceReturn").Value, 2));
					}
				}
				rs = modReport.getRSreport(ref "SELECT * FROM aChannel");

				while (!(rs.EOF)) {
					switch (rs.Fields("ChannelID").Value) {
						case 1:
							Report.SetParameterValue("txtSC1", rs.Fields("Channel_Code"));
							break;
						case 2:
							Report.SetParameterValue("txtSC2", rs.Fields("Channel_Code"));
							break;
						case 3:
							Report.SetParameterValue("txtSC3", rs.Fields("Channel_Code"));
							break;
						case 4:
							Report.SetParameterValue("txtSC4", rs.Fields("Channel_Code"));
							break;
						case 5:
							Report.SetParameterValue("txtSC5", rs.Fields("Channel_Code"));
							break;
						case 6:
							Report.SetParameterValue("txtSC6", rs.Fields("Channel_Code"));
							break;
						case 7:
							Report.SetParameterValue("txtSC7", rs.Fields("Channel_Code"));
							break;
						case 8:
							Report.SetParameterValue("txtSC8", rs.Fields("Channel_Code"));
							break;
						case 9:
							Report.SetParameterValue("txtSC9", rs.Fields("Channel_Code"));
							break;
					}
					rs.moveNext();
				}

				//Set rs = getRSreport("SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS SCTotal, Sale.Sale_ChannelID FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null) And ((Sale.Sale_SaleChk)=False)) GROUP BY Sale.Sale_ChannelID;")
				rs = modReport.getRSreport(ref "SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS SCTotal, Sale.Sale_ChannelID FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_ChannelID;");
				//lTotal = CCur(Report.txtSCmDiscount.Text)
				lTotal = oldDis;
				while (!(rs.EOF)) {
					switch (rs.Fields("Sale_ChannelID").Value) {
						case 1:
							Report.SetParameterValue("txtSCm1", Strings.FormatNumber(rs.Fields("SCTotal").Value, 2));
							break;
						case 2:
							Report.SetParameterValue("txtSCm2", Strings.FormatNumber(rs.Fields("SCTotal").Value, 2));
							break;
						case 3:
							Report.SetParameterValue("txtSCm3", Strings.FormatNumber(rs.Fields("SCTotal").Value, 2));
							break;
						case 4:
							Report.SetParameterValue("txtSCm4", Strings.FormatNumber(rs.Fields("SCTotal").Value, 2));
							break;
						case 5:
							Report.SetParameterValue("txtSCm5", Strings.FormatNumber(rs.Fields("SCTotal").Value, 2));
							break;
						case 6:
							Report.SetParameterValue("txtSCm6", Strings.FormatNumber(rs.Fields("SCTotal").Value, 2));
							break;
						case 7:
							Report.SetParameterValue("txtSCm7", Strings.FormatNumber(rs.Fields("SCTotal").Value, 2));
							break;
						case 8:
							Report.SetParameterValue("txtSCm8", Strings.FormatNumber(rs.Fields("SCTotal").Value, 2));
							break;
						case 9:
							Report.SetParameterValue("txtSCm9", Strings.FormatNumber(rs.Fields("SCTotal").Value, 2));
							break;
					}
					lTotal = lTotal + rs.Fields("SCTotal").Value;
					rs.moveNext();
				}
				Report.SetParameterValue("txtSCmTotal", Strings.FormatNumber(lTotal, 2));

				rs = modReport.getRSreport(ref "SELECT Sum(aCustomer.Customer_Current) AS SumOfCustomer_Current, Sum(aCustomer.Customer_30Days) AS SumOfCustomer_30Days, Sum(aCustomer.Customer_60Days) AS SumOfCustomer_60Days, Sum(aCustomer.Customer_90Days) AS SumOfCustomer_90Days, Sum(aCustomer.Customer_120Days) AS SumOfCustomer_120Days, Sum(aCustomer.Customer_150Days) AS SumOfCustomer_150Days FROM aCustomer;");
				lTotal = 0;
				if (rs.RecordCount) {
					Report.SetParameterValue("txtCA1", Strings.FormatNumber(rs.Fields("SumOfCustomer_Current").Value, 0));
					Report.SetParameterValue("txtCA2", Strings.FormatNumber(rs.Fields("SumOfCustomer_30Days").Value, 0));
					Report.SetParameterValue("txtCA3", Strings.FormatNumber(rs.Fields("SumOfCustomer_60Days").Value, 0));
					Report.SetParameterValue("txtCA4", Strings.FormatNumber(rs.Fields("SumOfCustomer_90Days").Value, 0));
					Report.SetParameterValue("txtCA5", Strings.FormatNumber(rs.Fields("SumOfCustomer_120Days").Value, 0));
					Report.SetParameterValue("txtCA6", Strings.FormatNumber(rs.Fields("SumOfCustomer_150Days").Value, 0));
					Report.SetParameterValue("txtCAtotal", Strings.FormatNumber(rs.Fields("SumOfCustomer_Current").Value + rs.Fields("SumOfCustomer_30Days").Value + rs.Fields("SumOfCustomer_60Days").Value + rs.Fields("SumOfCustomer_90Days").Value + rs.Fields("SumOfCustomer_120Days").Value + rs.Fields("SumOfCustomer_150Days").Value, 0));
				}

				My.MyProject.Forms.frmReportShow.Text = "Sale Dashboard";
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
				My.MyProject.Forms.frmReportShow.mReport = Report;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
			}
		}

		private static void report_Salespastel()
		{
			int intF = 0;
			CrystalDecisions.CrystalReports.Engine.Groups rDisplay_F = default(CrystalDecisions.CrystalReports.Engine.Groups);
			decimal vVatSales = default(decimal);
			string sql2 = null;
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			bool lMode = false;
			decimal lPasteCurr = default(decimal);
			decimal vInSales = default(decimal);
			decimal vExSales = default(decimal);
			decimal lTotal = default(decimal);
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsSale = default(ADODB.Recordset);
			ADODB.Recordset rsPTotals = default(ADODB.Recordset);
			Report.Load("cryPastelCube.rpt");

			modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount=0,HomeAmount=0,PastelDate=#" + Convert.ToDateTime(DateAndTime.Today) + "#, Reference = '4POS'");

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			ADODB.Recordset rsPTotalss = default(ADODB.Recordset);
			if (modReport.openConnectionReport()) {
				rs = modReport.getRSreport(ref "SELECT aCompany.Company_Name, Report.Report_Heading FROM aCompany, Report;");
				Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
				Report.SetParameterValue("txtFilter", rs.Fields("Report_Heading"));

				//get payoutTotal
				rs = modReport.getRSreport(ref "SELECT Sum(Payout.Payout_Amount) AS [amount] FROM Payout;");
				if (Information.IsDBNull(rs.Fields("amount").Value)) {
					Report.SetParameterValue("txtPayout", "0.00");
					Report.SetParameterValue("txtPayout1", "0.00");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + ",HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 18");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + ",HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 19");

				} else {
					Report.SetParameterValue("txtPayout", Strings.FormatNumber(rs.Fields("amount").Value, 2));
					Report.SetParameterValue("txtPayout1", Strings.FormatNumber(rs.Fields("amount").Value, 2));
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 18");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 19");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 18");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 19");
				}
				rs.Close();
				//get outages
				rs = modReport.getRSreport(ref "SELECT Sum(([Declaration_Cash]+[Declaration_Cheque]+[Declaration_Card]-[Declaration_Payout])-([Declaration_CashServer]+[Declaration_ChequeServer]+[Declaration_CardServer]-[Declaration_PayoutServer])) AS amount FROM Declaration;");
				if (Information.IsDBNull(rs.Fields("amount").Value)) {
					Report.SetParameterValue("txtOutage", "0.00");
					Report.SetParameterValue("txtOutage1", "0.00");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 5");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 6");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 5");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 6");
				} else {
					if (rs.Fields("amount").Value < 0) {
						Report.SetParameterValue("txtOutage", Strings.FormatNumber(-1 * rs.Fields("amount").Value, 2));
						Report.SetParameterValue("txtOutage1", Strings.FormatNumber(-1 * rs.Fields("amount").Value, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 5");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 6");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 5");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 6");
					} else {
						Report.SetParameterValue("txtOutage", Strings.FormatNumber(rs.Fields("amount").Value, 2));
						Report.SetParameterValue("txtOutage1", Strings.FormatNumber(rs.Fields("amount").Value, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 5");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 6");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 5");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 6");
					}
				}
				rs.Close();
				//get account movement
				lTotal = 0;
				rs = modReport.getRSreport(ref "SELECT Sum(Sale.Sale_Total) AS amount, Sale.Sale_PaymentType, Sum([Sale_Total]-[Sale_Discount]) AS Subtotal, Sum(Sale.Sale_Discount) AS discount FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (CustomerTransaction INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((CustomerTransaction.CustomerTransaction_TransactionTypeID) = 2 Or (CustomerTransaction.CustomerTransaction_TransactionTypeID) = 3) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_PaymentType;");
				while (!(rs.EOF)) {
					switch (rs.Fields("Sale_PaymentType").Value) {
						case 5:
							//Report.txtCubeAccountSales.SetText FormatNumber(rs("subtotal"), 2)
							Report.SetParameterValue("txtAccountSales", Strings.FormatNumber(rs.Fields("subtotal").Value, 2));
							Report.SetParameterValue("txtAccountSales1", Strings.FormatNumber(rs.Fields("subtotal").Value, 2));
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("subtotal").Value, 2)) + " WHERE IDDescription = 7");
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("subtotal").Value, 2)) + " WHERE IDDescription = 8");
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("subtotal").Value, 2)) + " WHERE IDDescription = 7");
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("subtotal").Value, 2)) + " WHERE IDDescription");
							break;
						case 1:
							//Report.txtAccountCash.SetText FormatNumber(0 - rs("amount"), 2)
							lTotal = lTotal - rs.Fields("amount").Value;
							break;
						case 2:
							//Report.txtAccountCRcard.SetText FormatNumber(0 - rs("amount"), 2)
							lTotal = lTotal - rs.Fields("amount").Value;
							break;
						case 3:
							//Report.txtAccountDRcard.SetText FormatNumber(0 - rs("amount"), 2)
							lTotal = lTotal - rs.Fields("amount").Value;
							break;
						case 4:
							//Report.txtAccountCheque.SetText FormatNumber(0 - rs("amount"), 2)
							lTotal = lTotal - rs.Fields("amount").Value;
							break;
					}
					rs.moveNext();
				}

				lTotal = lTotal + Convert.ToDecimal(Report.ParameterFields("txtAccountSales").ToString);

				//Get Output Vat
				sql2 = "SELECT SaleItem.SaleItem_StockItemID, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ActualCost]*[SaleItem_Quantity],[SaleItem_ActualCost]*[SaleItem_Quantity])) AS actualCostSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ListCost]*[SaleItem_Quantity],[SaleItem_ListCost]*[SaleItem_Quantity])) AS listCostSum, Sum(([SaleItem_Price]*[SaleItem_Quantity]/(1+[SaleItem_Vat]/100))) AS exclusiveSum, Sum(([SaleItem_Price]*[SaleItem_Quantity])) AS inclusiveSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_DepositCost]*[SaleItem_Quantity],[SaleItem_DepositCost]*[SaleItem_Quantity])) AS depositSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) AS quantitySum FROM Sale INNER JOIN (aConsignment AS aConsignment_1 RIGHT JOIN (SaleItem LEFT JOIN aConsignment ON SaleItem.SaleItem_SaleID=aConsignment.Consignment_SaleID) ON aConsignment_1.Consignment_ReversalSaleID=SaleItem.SaleItem_SaleID) ON Sale.SaleID=SaleItem.SaleItem_SaleID" + " Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null))" + " GROUP BY SaleItem.SaleItem_StockItemID;";
				rsSale = modReport.getRSreport(ref sql2);
				vInSales = 0;

				if (rsSale.EOF | rsSale.BOF) {
					Report.SetParameterValue("txtOutputVat", Strings.FormatNumber(vInSales, 2));
					Report.SetParameterValue("txtOutputVat1", Strings.FormatNumber(vInSales, 2));
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(vInSales, 2)) + " WHERE IDDescription = 26");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vInSales, 2)) + " WHERE IDDescription = 27");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(vInSales, 2)) + " WHERE IDDescription = 26");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vInSales, 2)) + " WHERE IDDescription = 27");
				} else {
					while (rsSale.EOF == false) {
						vInSales = vInSales + rsSale.Fields("inclusiveSum").Value;
						vExSales = vExSales + rsSale.Fields("exclusiveSum").Value;
						rsSale.moveNext();
					}
					vVatSales = vInSales - vExSales;
					Report.SetParameterValue("txtOutputVat", Strings.FormatNumber(vVatSales, 2));
					Report.SetParameterValue("txtOutputVat1", Strings.FormatNumber(vVatSales, 2));
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(vVatSales, 2)) + " WHERE IDDescription = 26");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vVatSales, 2)) + " WHERE IDDescription = 27");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(vVatSales, 2)) + " WHERE IDDescription = 26");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vVatSales, 2)) + " WHERE IDDescription = 27");
				}
				rsSale.Close();
				//get Settlement movement
				vInSales = 0;
				rsSale = modReport.getRSreport(ref "SELECT Sum([CustomerTransaction_Amount]) AS SttTotal From CustomerTransaction WHERE CustomerTransaction_TransactionTypeID=8;");
				if (Information.IsDBNull(rsSale.Fields("SttTotal").Value)) {
					Report.SetParameterValue("txtSettlement", Strings.FormatNumber(vInSales, 0));
					Report.SetParameterValue("txtSettlement1", Strings.FormatNumber(vInSales, 0));
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(vInSales, 0)) + " WHERE IDDescription = 11");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vInSales, 0)) + " WHERE IDDescription = 12");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(vInSales, 0)) + " WHERE IDDescription = 11");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vInSales, 0)) + " WHERE IDDescription = 12");
				} else {
					if (rsSale.Fields("SttTotal").Value < 0) {
						Report.SetParameterValue("txtSettlement", Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 0));
						Report.SetParameterValue("txtSettlement1", Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 0));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 0)) + " WHERE IDDescription = 11");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 0)) + " WHERE IDDescription = 12");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 0)) + " WHERE IDDescription = 11");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 0)) + " WHERE IDDescription = 12");
					} else {
						Report.SetParameterValue("txtSettlement", Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 0));
						Report.SetParameterValue("txtSettlement1", Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 0));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 0)) + " WHERE IDDescription = 11");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 0)) + " WHERE IDDescription = 12");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 0)) + " WHERE IDDescription = 11");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 0)) + " WHERE IDDescription = 12");
					}
				}

				rsSale.Close();

				rsSale = modReport.getRSreport(ref "SELECT Sum(SupplierTransaction.SupplierTransaction_Amount) AS SttTotal FROM SupplierTransaction WHERE (((SupplierTransaction.SupplierTransaction_TransactionTypeID)=8));");
				vInSales = 0;
				if (Information.IsDBNull(rsSale.Fields("SttTotal").Value)) {
					Report.SetParameterValue("txtSettlementD", Strings.FormatNumber(vInSales, 2));
					Report.SetParameterValue("txtSettlementD1", Strings.FormatNumber(vInSales, 2));
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(vInSales, 2)) + " WHERE IDDescription = 24");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vInSales, 2)) + " WHERE IDDescription = 25");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(vInSales, 2)) + " WHERE IDDescription = 24");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vInSales, 2)) + " WHERE IDDescription = 25");
				} else {
					if (rsSale.Fields("SttTotal").Value < 0) {
						Report.SetParameterValue("txtSettlementD", Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2));
						Report.SetParameterValue("txtSettlementD1", Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 24");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 25");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 24");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 25");
					} else {
						Report.SetParameterValue("txtSettlementD", Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2));
						Report.SetParameterValue("txtSettlementD1", Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 24");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 25");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 24");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 25");
					}
				}

				rsSale.Close();
				rsSale = modReport.getRSreport(ref "SELECT Sum(SupplierTransaction.SupplierTransaction_Amount) AS SttTotal FROM SupplierTransaction WHERE (((SupplierTransaction.SupplierTransaction_TransactionTypeID)=3));");
				vInSales = 0;
				if (Information.IsDBNull(rsSale.Fields("SttTotal").Value)) {
					Report.SetParameterValue("txtCreditorPay", Strings.FormatNumber(vInSales, 2));
					Report.SetParameterValue("txtCreditorPay1", Strings.FormatNumber(vInSales, 2));
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(vInSales, 2)) + " WHERE IDDescription = 22");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vInSales, 2)) + " WHERE IDDescription = 23");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(vInSales, 2)) + " WHERE IDDescription = 22");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vInSales, 2)) + " WHERE IDDescription = 23");
				} else {
					if (rsSale.Fields("SttTotal").Value < 0) {
						Report.SetParameterValue("txtCreditorPay", Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2));
						Report.SetParameterValue("txtCreditorPay1", Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 22");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 23");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 22");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 23");
					} else {
						Report.SetParameterValue("txtCreditorPay", Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2));
						Report.SetParameterValue("txtCreditorPay1", Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 22");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 23");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 22");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 23");
					}
				}

				//do money movement
				lTotal = 0;
				rs = modReport.getRSreport(ref "SELECT Sale.Sale_PaymentType, Sum(Sale.Sale_Total) AS amount FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_PaymentType;");
				while (!(rs.EOF)) {
					switch (rs.Fields("Sale_PaymentType").Value) {
						case 1:
							Report.SetParameterValue("txtMoneyCash", Strings.FormatNumber(rs.Fields("amount").Value, 2));
							lTotal = lTotal + rs.Fields("amount").Value;
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 1");
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 1");
							break;
						case 2:
							Report.SetParameterValue("txtMoneyCRcard", Strings.FormatNumber(rs.Fields("amount").Value, 2));
							lTotal = lTotal + rs.Fields("amount").Value;
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 3");
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 3");
							break;
						case 3:
							Report.SetParameterValue("txtMoneyDRcard", Strings.FormatNumber(rs.Fields("amount").Value, 2));
							lTotal = lTotal + rs.Fields("amount").Value;
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 4");
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 4");
							break;
						case 4:
							Report.SetParameterValue("txtMoneyCheque", Strings.FormatNumber(rs.Fields("amount").Value, 2));
							lTotal = lTotal + rs.Fields("amount").Value;
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 2");
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 2");
							break;
					}
					rs.moveNext();
				}
				rs.Close();

				Report.SetParameterValue("txtMoneyTotal", Strings.FormatNumber(lTotal, 2));
				modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * lTotal, 2)) + " WHERE IDDescription = 13");
				modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * lTotal, 2)) + " WHERE IDDescription = 13");

				//do invoice discount
				rs = modReport.getRSreport(ref "SELECT Sum(Sale.Sale_Discount) AS amount FROM aConsignment RIGHT JOIN (aConsignment AS aConsignment_1 RIGHT JOIN Sale ON aConsignment_1.Consignment_SaleID = Sale.SaleID) ON aConsignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null));");
				if (Information.IsDBNull(rs.Fields("amount").Value)) {
					Report.SetParameterValue("txtStockDiscount", "0.00");
				} else {
					if (rs.RecordCount) {
						Report.SetParameterValue("txtStockDiscount", Strings.FormatNumber(0 - rs("amount").Value, 2));
						Report.SetParameterValue("txtSCmDiscount", Strings.FormatNumber(0 - rs("amount").Value, 2));
					} else {
						Report.SetParameterValue("txtStockDiscount", "0.00");
					}
				}
				rs.Close();

				rs = modReport.getRSreport(ref "SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS content, CBool([SaleItem_DepositType]) AS depositType, SaleItem.SaleItem_Reversal, Sum(([SaleItem_DepositCost]*[SaleItem_Quantity])*(1+[SaleItem_Vat]/100)) AS deposit FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY CBool([SaleItem_DepositType]), SaleItem.SaleItem_Reversal;");
				while (!(rs.EOF)) {
					if (rs.Fields("depositType").Value) {
						if (rs.Fields("SaleItem_Reversal").Value) {
							Report.SetParameterValue("txtStockDepositSold", Strings.FormatNumber(rs("content"), 2));
						} else {
							Report.SetParameterValue("txtStockDepositReturn", Strings.FormatNumber(rs("content"), 2));
						}
					} else {
						if (rs.Fields("SaleItem_Reversal").Value) {
							Report.SetParameterValue("txtStockCreditContent", Strings.FormatNumber(rs("content"), 2));
							Report.SetParameterValue("txtStockCreditDeposit", Strings.FormatNumber(0 - rs("deposit").Value, 2));
						} else {
							Report.SetParameterValue("txtStockSoldContent", Strings.FormatNumber(rs("content"), 2));
							Report.SetParameterValue("txtStockSoldDeposit", Strings.FormatNumber(rs("deposit"), 2));
						}
					}
					rs.moveNext();
				}
				rs.Close();
				 // ERROR: Not supported in C#: OnErrorStatement


				rs = modReport.getRSreport(ref "SELECT Sum(aCustomerTransaction.CustomerTransaction_Amount) AS SumOfCustomerTransaction_Amount FROM aCustomerTransaction INNER JOIN DayEnd ON aCustomerTransaction.CustomerTransaction_DayEndID = DayEnd.DayEndID WHERE (((aCustomerTransaction.CustomerTransaction_TransactionTypeID)=3 Or (aCustomerTransaction.CustomerTransaction_TransactionTypeID)=4 Or (aCustomerTransaction.CustomerTransaction_TransactionTypeID)=5) AND ((aCustomerTransaction.CustomerTransaction_ReferenceID)=0));");
				if (rs.RecordCount) {
					if (rs.Fields("SumOfCustomerTransaction_Amount").Value < 0) {
						Report.SetParameterValue("txtAccountEFT", Strings.FormatNumber(0, 2));
						Report.SetParameterValue("txtAccountEFT1", Strings.FormatNumber(0, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) + " WHERE IDDescription = 9");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) + " WHERE IDDescription = 10");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) + " WHERE IDDescription = 9");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) + " WHERE IDDescription = 10");
					} else {
						if (Information.IsDBNull(rs.Fields("SumOfCustomerTransaction_Amount").Value)) {
							Report.SetParameterValue("txtAccountEFT", "0.00");
							Report.SetParameterValue("txtAccountEFT1", "0.00");
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(0) + " WHERE IDDescription = 9");
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(0) + " WHERE IDDescription = 10");
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(0) + " WHERE IDDescription = 9");
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(0) + " WHERE IDDescription = 10");
						} else {
							Report.SetParameterValue("txtAccountEFT", Strings.FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2));
							Report.SetParameterValue("txtAccountEFT1", Strings.FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2));
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) + " WHERE IDDescription = 9");
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) + " WHERE IDDescription = 10");
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) + " WHERE IDDescription = 9");
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) + " WHERE IDDescription = 10");
						}
					}
				} else {
					Report.SetParameterValue("txtAccountEFT", Strings.FormatNumber(0, 2));
					Report.SetParameterValue("txtAccountEFT1", Strings.FormatNumber(0, 2));
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 9");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 10");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 9");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 10");
				}
				//Set rs = getRSreport(sql)
				rDisplay_F = modRecordSet.getRS(ref "SELECT * FROM PastelDescription Order By IDDescription ASC");
				for (intF = 1; intF <= 29; intF++) {
					Report.SetParameterValue("txtDes1", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar1", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc1", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes2", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar2", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc2", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes3", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar3", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc3", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes4", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar4", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc4", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes5", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar5", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc5", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes6", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar6", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc6", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes7", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar7", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc7", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes8", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar8", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc8", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes9", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar9", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc9", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes10", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar10", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc10", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes11", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar11", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc11", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes12", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar12", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc12", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes13", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar13", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc13", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes14", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar14", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc14", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes15", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar15", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc15", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes16", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar16", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc16", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes17", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar17", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc17", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes18", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar18", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc18", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes19", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar19", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc19", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes20", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar20", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc20", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes21", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar21", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc21", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes22", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar22", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc22", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes23", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar23", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc23", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes24", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar24", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc24", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes25", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar25", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc25", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes26", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar26", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc26", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes27", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar27", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc27", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes28", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar28", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc28", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes29", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar29", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc29", rDisplay_F("AccountNumber"));
					break; // TODO: might not be correct. Was : Exit For
				}

				if (lMode) {
				} else {
					rs = modReport.getRSreport(ref "SELECT Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost]) AS listSales, Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ActualCost]) AS actualSales, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS listShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actualShrink, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost]) AS listGRV, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ActualCost]) AS actualGRV FROM DayEndStockItemLnk;");

					if (Information.IsDBNull(rs.Fields("listShrink").Value)) {
						Report.SetParameterValue("txtSHRL", Strings.FormatNumber(0, 2));
						Report.SetParameterValue("txtSHRL1", Strings.FormatNumber(0, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 14");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 15");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 14");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 15");
					} else {
						if (rs.Fields("listShrink").Value < 0) {
							Report.SetParameterValue("txtSHRL", Strings.FormatNumber(-1 * rs.Fields("listShrink").Value, 2));
							Report.SetParameterValue("txtSHRL1", Strings.FormatNumber(-1 * rs.Fields("listShrink").Value, 2));
						} else {
							Report.SetParameterValue("txtSHRL", Strings.FormatNumber(rs.Fields("listShrink").Value, 2));
							Report.SetParameterValue("txtSHRL1", Strings.FormatNumber(rs.Fields("listShrink").Value, 2));
						}

						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("listShrink").Value, 2)) + " WHERE IDDescription = 14");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("listShrink").Value, 2)) + " WHERE IDDescription = 15");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("listShrink").Value, 2)) + " WHERE IDDescription = 14");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("listShrink").Value, 2)) + " WHERE IDDescription = 15");
					}

					if (Information.IsDBNull(rs.Fields("listGRV").Value)) {
						Report.SetParameterValue("txtGRVL1", Strings.FormatNumber(0, 2));
						Report.SetParameterValue("txtGRVL", Strings.FormatNumber(0, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 20");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 21");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 20");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 21");
					} else {
						Report.SetParameterValue("txtGRVL1", Strings.FormatNumber(rs.Fields("listGRV").Value, 2));
						Report.SetParameterValue("txtGRVL", Strings.FormatNumber(rs.Fields("listGRV").Value, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("listGRV").Value, 2)) + " WHERE IDDescription = 20");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("listGRV").Value, 2)) + " WHERE IDDescription = 21");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("listGRV").Value, 2)) + " WHERE IDDescription = 20");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("listGRV").Value, 2)) + " WHERE IDDescription = 21");
					}

					if (Information.IsDBNull(rs.Fields("listSales").Value)) {
						Report.SetParameterValue("txtSaleL", Strings.FormatNumber(0, 2));
						Report.SetParameterValue("txtSaleL1", Strings.FormatNumber(0, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 16");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 17");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 16");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 17");
					} else {
						Report.SetParameterValue("txtSaleL", Strings.FormatNumber(rs.Fields("listSales").Value, 2));
						Report.SetParameterValue("txtSaleL1", Strings.FormatNumber(rs.Fields("listSales").Value, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("listSales").Value, 2)) + " WHERE IDDescription = 16");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("listSales").Value, 2)) + " WHERE IDDescription = 17");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("listSales").Value, 2)) + " WHERE IDDescription = 16");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("listSales").Value, 2)) + " WHERE IDDescription = 17");
					}
				}
				rs = modReport.getRSreport(ref "SELECT Sum([SaleItem_ListCost]*[SaleItem_Quantity]) AS list, Sum([SaleItem_ActualCost]*[SaleItem_Quantity]) AS actual FROM aConsignment INNER JOIN SaleItem ON aConsignment.Consignment_SaleID = SaleItem.SaleItem_SaleID;");
				if (Information.IsDBNull(rs.Fields("list").Value)) {
					Report.SetParameterValue("txtConsLsales", Strings.FormatNumber("0", 2));
					Report.SetParameterValue("txtConsAsales", Strings.FormatNumber("0", 2));
				} else {
					Report.SetParameterValue("txtConsLsales", Strings.FormatNumber(rs("list"), 2));
					Report.SetParameterValue("txtConsAsales", Strings.FormatNumber(rs("actual"), 2));
				}
				rs = modReport.getRSreport(ref "SELECT Sum(Sale.Sale_Total) AS [amount] FROM aConsignment INNER JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID;");
				if (Information.IsDBNull(rs.Fields("amount").Value)) {
					Report.SetParameterValue("txtConsPsales", Strings.FormatNumber("0", 2));
				} else {
					Report.SetParameterValue("txtConsPsales", Strings.FormatNumber(rs("amount"), 2));
				}

				rs = modReport.getRSreport(ref "SELECT Sum([SaleItem_ListCost]*[SaleItem_Quantity]) AS list, Sum([SaleItem_ActualCost]*[SaleItem_Quantity]) AS actual FROM aConsignment INNER JOIN SaleItem ON aConsignment.Consignment_CompleteSaleID = SaleItem.SaleItem_SaleID;");
				if (Information.IsDBNull(rs.Fields("list").Value)) {
					Report.SetParameterValue("txtConsLPurchase", Strings.FormatNumber("0", 2));
					Report.SetParameterValue("txtConsAPurchase", Strings.FormatNumber("0", 2));
				} else {
					Report.SetParameterValue("txtConsLPurchase", Strings.FormatNumber(rs("list"), 2));
					Report.SetParameterValue("txtConsAPurchase", Strings.FormatNumber(rs("actual"), 2));
				}

				rs = modReport.getRSreport(ref "SELECT Sum(theJoin.list) AS list, Sum(theJoin.actual) AS actual FROM (SELECT  1 AS sale, Sum([SaleItem_Quantity]*[SaleItem_ListCost]) AS list, Sum([SaleItem_Quantity]*[SaleItem_actualCost]) AS actual FROM SaleItem INNER JOIN aConsignment ON SaleItem.SaleItem_SaleID = aConsignment.Consignment_CompleteSaleID Union SELECT 0 AS sale, Sum(0-[SaleItem_Quantity]*[SaleItem_ListCost]) AS list, Sum(0-[SaleItem_Quantity]*[SaleItem_actualCost]) AS actual FROM aConsignment INNER JOIN SaleItem ON aConsignment.Consignment_SaleID = SaleItem.SaleItem_SaleID WHERE (((aConsignment.Consignment_CompleteSaleID) Is Not Null))) AS theJoin;");
				if (Information.IsDBNull(rs.Fields("list").Value)) {
					Report.SetParameterValue("txtConsLreturn", Strings.FormatNumber("0", 2));
					Report.SetParameterValue("txtConsAreturn", Strings.FormatNumber("0", 2));
				} else {
					Report.SetParameterValue("txtConsLreturn", Strings.FormatNumber(rs("list"), 2));
					Report.SetParameterValue("txtConsAreturn", Strings.FormatNumber(rs("actual"), 2));
				}

				rs = modReport.getRSreport(ref "SELECT Sum([Sale]![Sale_Total]+[Sale_1]![Sale_Total]) AS priceReturn, Sale.Sale_Total FROM Sale INNER JOIN (Sale AS Sale_1 INNER JOIN aConsignment ON Sale_1.SaleID = aConsignment.Consignment_ReversalSaleID) ON Sale.SaleID = aConsignment.Consignment_CompleteSaleID GROUP BY Sale.Sale_Total;");
				if (rs.BOF | rs.EOF) {
					Report.SetParameterValue("txtConsPPurchase", Strings.FormatNumber("0", 2));
					Report.SetParameterValue("txtConsPreturn", Strings.FormatNumber("0", 2));
				} else {
					if (Information.IsDBNull(rs.Fields("Sale_Total").Value)) {
						Report.SetParameterValue("txtConsPPurchase", Strings.FormatNumber("0", 2));
						Report.SetParameterValue("txtConsPreturn", Strings.FormatNumber("0", 2));
					} else {
						Report.SetParameterValue("txtConsPPurchase", Strings.FormatNumber(rs("Sale_Total"), 2));
						Report.SetParameterValue("txtConsPreturn", Strings.FormatNumber(rs("priceReturn"), 2));
					}
				}

				rs = modReport.getRSreport(ref "SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS SCTotal, Sale.Sale_ChannelID FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_ChannelID;");
				//lTotal = CCur(Report.txtSCmDiscount.Text)
				while (!(rs.EOF)) {
					switch (rs.Fields("Sale_ChannelID").Value) {
					}
					lTotal = lTotal + rs.Fields("SCTotal").Value;
					rs.moveNext();
				}
				rsPTotals = modRecordSet.getRS(ref "SELECT SUM(Amount) As totDebit FROM PastelDescription WHERE Amount > 0");
				rsPTotalss = modRecordSet.getRS(ref "SELECT SUM(Amount) as totCredit FROM PastelDescription WHERE Amount < 0");

				if (Information.IsDBNull(rsPTotals.Fields("totDebit").Value)) {
					Report.SetParameterValue("txtDebit", Strings.FormatNumber(0, 2));
				} else {
					Report.SetParameterValue("txtDebit", Strings.FormatNumber(rsPTotals.Fields("totDebit").Value));
				}
				if (Information.IsDBNull(rsPTotalss.Fields("totCredit").Value)) {
					Report.SetParameterValue("txtCredit", Strings.FormatNumber(0, 2));
				} else {
					Report.SetParameterValue("txtCredit", Strings.FormatNumber(rsPTotalss.Fields("totCredit").Value));
				}


				//Pastel export file
				if (modBResolutions.blpastel == true) {
					System.Windows.Forms.Cursor.Current = Cursors.Default;
					return;
				}
				My.MyProject.Forms.frmReportShow.Text = "Pastel Report";
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
				My.MyProject.Forms.frmReportShow.mReport = Report;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();

			}

		}

		private static void report_SalespastelXX()
		{
			int intF = 0;
			CrystalDecisions.CrystalReports.Engine.Groups rDisplay_F = default(CrystalDecisions.CrystalReports.Engine.Groups);
			decimal vVatSales = default(decimal);
			string sql2 = null;
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			bool lMode = false;
			decimal lPasteCurr = default(decimal);
			decimal vInSales = default(decimal);
			decimal vExSales = default(decimal);
			decimal lTotal = default(decimal);
			decimal lCash = default(decimal);
			decimal lDebit = default(decimal);
			decimal lCheque = default(decimal);
			decimal lCredit = default(decimal);
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsSale = default(ADODB.Recordset);
			ADODB.Recordset rsPTotals = default(ADODB.Recordset);

			Report.Load("cryPastelCube.rpt");

			modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount=0,HomeAmount=0,PastelDate=#" + Convert.ToDateTime(DateAndTime.Today) + "#, Reference = '4POS'");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

			ADODB.Recordset rsPTotalss = default(ADODB.Recordset);
			if (modReport.openConnectionReport()) {
				rs = modReport.getRSreport(ref "SELECT aCompany.Company_Name, Report.Report_Heading FROM aCompany, Report;");
				Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
				Report.SetParameterValue("txtFilter", rs.Fields("Report_Heading"));

				//get payoutTotal
				rs = modReport.getRSreport(ref "SELECT Sum(Payout.Payout_Amount) AS [amount] FROM Payout;");
				if (Information.IsDBNull(rs.Fields("amount").Value)) {
					Report.SetParameterValue("txtPayout", "0.00");
					Report.SetParameterValue("txtPayout1", "0.00");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + ",HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 18");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + ",HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 19");
				} else {
					Report.SetParameterValue("txtPayout", Strings.FormatNumber(rs.Fields("amount").Value, 2));
					Report.SetParameterValue("txtPayout1", Strings.FormatNumber(rs.Fields("amount").Value, 2));
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 18");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 19");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 18");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 19");
				}
				rs.Close();

				//get outages................
				rs = modReport.getRSreport(ref "SELECT Sum(([Declaration_Cash]+[Declaration_Cheque]+[Declaration_Card]-[Declaration_Payout])-([Declaration_CashServer]+[Declaration_ChequeServer]+[Declaration_CardServer]-[Declaration_PayoutServer])) AS amount FROM Declaration;");
				if (Information.IsDBNull(rs.Fields("amount").Value)) {
					Report.SetParameterValue("txtOutage", "0.00");
					Report.SetParameterValue("txtOutage1", "0.00");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 5");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 6");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 5");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 6");
				} else {
					if (rs.Fields("amount").Value < 0) {
						Report.SetParameterValue("txtOutage", Strings.FormatNumber(-1 * rs.Fields("amount").Value, 2));
						Report.SetParameterValue("txtOutage1", Strings.FormatNumber(-1 * rs.Fields("amount").Value, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 5");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 6");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 5");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 6");
					} else {
						Report.SetParameterValue("txtOutage", Strings.FormatNumber(rs.Fields("amount").Value, 2));
						Report.SetParameterValue("txtOutage1", Strings.FormatNumber(rs.Fields("amount").Value, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 5");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 6");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 5");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("amount").Value, 2)) + " WHERE IDDescription = 6");
					}
				}
				rs.Close();

				//get account movement........................

				//lTotal = 0
				//lCash = 0
				//lDebit = 0
				//lCheque = 0
				//lCredit = 0

				//Dim sqlZ As String
				//sqlZ = "SELECT Sum(Sale.Sale_Total) AS amount, Sale.Sale_PaymentType, Sum([Sale_Total]-[Sale_Discount]) AS Subtotal, Sum(Sale.Sale_Discount) AS discount, Sum(Sale.Sale_Cash) AS amountCash, Sum(Sale.Sale_Card) AS amountCard, " & _
				//'                    "Sum(Sale.Sale_CDebit) AS amountCredit, Sum(Sale.Sale_Cheque) AS amountCheque FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (CustomerTransaction INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID " & _
				//'                    "Where (((CustomerTransaction.CustomerTransaction_TransactionTypeID) = 2 Or (CustomerTransaction.CustomerTransaction_TransactionTypeID) = 3) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_PaymentType;"
				//Debug.Print sqlZ
				//Set rs = getRSreport(sqlZ)
				//"SELECT Sum(Sale.Sale_Total) AS amount, Sale.Sale_PaymentType, Sum([Sale_Total]-[Sale_Discount]) AS Subtotal, Sum(Sale.Sale_Discount) AS discount, Sum(Sale.Sale_Cash) AS amountCash, Sum(Sale.Sale_Card) AS amountCard, Sum(Sale.Sale_CDebit) AS amountCreR"
				lTotal = 0;
				rs = modReport.getRSreport(ref "SELECT Sum(Sale.Sale_Total) AS amount, Sale.Sale_PaymentType, Sum([Sale_Total]-[Sale_Discount]) AS Subtotal, Sum(Sale.Sale_Discount) AS discount FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (CustomerTransaction INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((CustomerTransaction.CustomerTransaction_TransactionTypeID) = 2 Or (CustomerTransaction.CustomerTransaction_TransactionTypeID) = 3) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_PaymentType;");

				while (!(rs.EOF)) {
					switch (rs.Fields("Sale_PaymentType").Value) {
						case 5:
							Report.SetParameterValue("txtAccountSales", Strings.FormatNumber(rs.Fields("subtotal").Value, 2));
							Report.SetParameterValue("txtAccountSales1", Strings.FormatNumber(rs.Fields("subtotal").Value, 2));
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("subtotal").Value, 2)) + " WHERE IDDescription = 7");
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("subtotal").Value, 2)) + " WHERE IDDescription = 8");
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("subtotal").Value, 2)) + " WHERE IDDescription = 7");
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("subtotal").Value, 2)) + " WHERE IDDescription");
							break;
						case 1:
							lCash = lCash + rs.Fields("amountCash").Value;
							lTotal = lTotal - rs.Fields("amount").Value;
							break;
						case 2:
							lTotal = lTotal - rs.Fields("amount").Value;
							lCredit = lCredit + rs.Fields("amountCredit").Value;
							break;
						case 3:
							lTotal = lTotal - rs.Fields("amount").Value;
							lDebit = lDebit + rs.Fields("amountCard").Value;
							break;
						case 4:
							lCheque = lCheque + rs.Fields("amountCheque").Value;
							lTotal = lTotal - rs.Fields("amount").Value;
							break;
						case 7:
							lTotal = lTotal - rs.Fields("amount").Value;
							lCash = lCash + rs.Fields("amountCash").Value;
							lDebit = lDebit + rs.Fields("amountCard").Value;
							lCredit = lCredit + rs.Fields("amountCredit").Value;
							lCheque = lCheque + rs.Fields("amountCheque").Value;
							break;
					}
					rs.moveNext();
				}
				rs.Close();

				//Get Output Vat.......................

				sql2 = "SELECT SaleItem.SaleItem_StockItemID, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ActualCost]*[SaleItem_Quantity],[SaleItem_ActualCost]*[SaleItem_Quantity])) AS actualCostSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ListCost]*[SaleItem_Quantity],[SaleItem_ListCost]*[SaleItem_Quantity])) AS listCostSum, Sum(([SaleItem_Price]*[SaleItem_Quantity]/(1+[SaleItem_Vat]/100))) AS exclusiveSum, Sum(([SaleItem_Price]*[SaleItem_Quantity])) AS inclusiveSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_DepositCost]*[SaleItem_Quantity],[SaleItem_DepositCost]*[SaleItem_Quantity])) AS depositSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) AS quantitySum FROM Sale INNER JOIN (aConsignment AS aConsignment_1 RIGHT JOIN (SaleItem LEFT JOIN aConsignment ON SaleItem.SaleItem_SaleID=aConsignment.Consignment_SaleID) ON aConsignment_1.Consignment_ReversalSaleID=SaleItem.SaleItem_SaleID) ON Sale.SaleID=SaleItem.SaleItem_SaleID" + " Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null))" + " GROUP BY SaleItem.SaleItem_StockItemID;";
				rsSale = modReport.getRSreport(ref sql2);

				vInSales = 0;

				if (rsSale.EOF | rsSale.BOF) {
					Report.SetParameterValue("txtOutputVat", Strings.FormatNumber(vInSales, 2));
					Report.SetParameterValue("txtOutputVat1", Strings.FormatNumber(vInSales, 2));
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(vInSales, 2)) + " WHERE IDDescription = 26");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vInSales, 2)) + " WHERE IDDescription = 27");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(vInSales, 2)) + " WHERE IDDescription = 26");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vInSales, 2)) + " WHERE IDDescription = 27");
				} else {
					while (rsSale.EOF == false) {
						vInSales = vInSales + rsSale.Fields("inclusiveSum").Value;
						vExSales = vExSales + rsSale.Fields("exclusiveSum").Value;
						rsSale.moveNext();
					}
					vVatSales = vInSales - vExSales;
					Report.SetParameterValue("txtOutputVat", Strings.FormatNumber(vVatSales, 2));
					Report.SetParameterValue("txtOutputVat1", Strings.FormatNumber(vVatSales, 2));
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(vVatSales, 2)) + " WHERE IDDescription = 26");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vVatSales, 2)) + " WHERE IDDescription = 27");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(vVatSales, 2)) + " WHERE IDDescription = 26");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vVatSales, 2)) + " WHERE IDDescription = 27");
				}
				rsSale.Close();

				//get Settlement movement................

				vInSales = 0;
				rsSale = modReport.getRSreport(ref "SELECT Sum([CustomerTransaction_Amount]) AS SttTotal From CustomerTransaction WHERE CustomerTransaction_TransactionTypeID=8;");
				if (Information.IsDBNull(rsSale.Fields("SttTotal").Value)) {
					Report.SetParameterValue("txtSettlement", Strings.FormatNumber(vInSales, 0));
					Report.SetParameterValue("txtSettlement1", Strings.FormatNumber(vInSales, 0));
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(vInSales, 2)) + " WHERE IDDescription = 11");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vInSales, 2)) + " WHERE IDDescription = 12");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(vInSales, 2)) + " WHERE IDDescription = 11");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vInSales, 2)) + " WHERE IDDescription = 12");
				} else {
					if (rsSale.Fields("SttTotal").Value < 0) {
						Report.SetParameterValue("txtSettlement", Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2));
						Report.SetParameterValue("txtSettlement1", Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 11");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 12");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 11");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 12");
					} else {
						Report.SetParameterValue("txtSettlement", Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2));
						Report.SetParameterValue("txtSettlement1", Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 11");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 12");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 11");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 12");
					}
				}
				rsSale.Close();

				rsSale = modReport.getRSreport(ref "SELECT Sum(SupplierTransaction.SupplierTransaction_Amount) AS SttTotal FROM SupplierTransaction WHERE (((SupplierTransaction.SupplierTransaction_TransactionTypeID)=8));");
				vInSales = 0;
				if (Information.IsDBNull(rsSale.Fields("SttTotal").Value)) {
					Report.SetParameterValue("txtSettlementD", Strings.FormatNumber(vInSales, 2));
					Report.SetParameterValue("txtSettlementD1", Strings.FormatNumber(vInSales, 2));
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(vInSales, 2)) + " WHERE IDDescription = 24");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vInSales, 2)) + " WHERE IDDescription = 25");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(vInSales, 2)) + " WHERE IDDescription = 24");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vInSales, 2)) + " WHERE IDDescription = 25");
				} else {
					if (rsSale.Fields("SttTotal").Value < 0) {
						Report.SetParameterValue("txtSettlementD", Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2));
						Report.SetParameterValue("txtSettlementD1", Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 24");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 25");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 24");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 25");
					} else {
						Report.SetParameterValue("txtSettlementD", Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2));
						Report.SetParameterValue("txtSettlementD1", Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 24");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 25");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 24");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 25");
					}
				}

				rsSale.Close();

				rsSale = modReport.getRSreport(ref "SELECT Sum(SupplierTransaction.SupplierTransaction_Amount) AS SttTotal FROM SupplierTransaction WHERE (((SupplierTransaction.SupplierTransaction_TransactionTypeID)=3));");
				vInSales = 0;
				if (Information.IsDBNull(rsSale.Fields("SttTotal").Value)) {
					Report.SetParameterValue("txtCreditorPay", Strings.FormatNumber(vInSales, 2));
					Report.SetParameterValue("txtCreditorPay1", Strings.FormatNumber(vInSales, 2));
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(vInSales, 2)) + " WHERE IDDescription = 22");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vInSales, 2)) + " WHERE IDDescription = 23");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(vInSales, 2)) + " WHERE IDDescription = 22");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * vInSales, 2)) + " WHERE IDDescription = 23");
				} else {
					if (rsSale.Fields("SttTotal").Value < 0) {
						Report.SetParameterValue("txtCreditorPay", Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2));
						Report.SetParameterValue("txtCreditorPay1", Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 22");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 23");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 22");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 23");
					} else {
						Report.SetParameterValue("txtCreditorPay", Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2));
						Report.SetParameterValue("txtCreditorPay1", Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 22");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 23");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 22");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) + " WHERE IDDescription = 23");
					}
				}

				//do money movement....................
				lCash = 0;
				lDebit = 0;
				lCheque = 0;
				lCredit = 0;
				lTotal = 0;
				rs = modReport.getRSreport(ref "SELECT Sale.Sale_PaymentType,Sum(Sale.Sale_Total) as AmountTotal, Sum(Sale.Sale_Cash) AS amountCash,Sum(Sale.Sale_Card) AS amountCard,Sum(Sale.Sale_Cheque) AS amountCheque,Sum(Sale.Sale_CDebit) AS amountCredit FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_PaymentType;");

				while (!(rs.EOF)) {
					switch (rs.Fields("Sale_PaymentType").Value) {
						case 1:
							lCash = lCash + rs.Fields("amountCash").Value;
							lTotal = lTotal + rs.Fields("AmountTotal").Value;
							Report.SetParameterValue("txtMoneyCash", Strings.FormatNumber(rs("amount"), 2));
							break;
						case 2:
							lCredit = lCredit + rs.Fields("amountCredit").Value;
							lTotal = lTotal + rs.Fields("AmountTotal").Value;
							Report.SetParameterValue("txtMoneyCRcard", Strings.FormatNumber(rs("amount"), 2));
							break;
						case 3:
							lDebit = lDebit + rs.Fields("amountCard").Value;
							lTotal = lTotal + rs.Fields("AmountTotal").Value;
							Report.SetParameterValue("txtMoneyDRcard", Strings.FormatNumber(rs("amount"), 2));
							break;
						case 4:
							lTotal = lTotal + rs.Fields("AmountTotal").Value;
							lCheque = lCheque + rs.Fields("amountCheque").Value;
							Report.SetParameterValue("txtMoneyCheque", Strings.FormatNumber(rs("amount"), 2));
							break;
						case 7:
							lTotal = lTotal + rs.Fields("AmountTotal").Value;
							lCash = lCash + rs.Fields("amountCash").Value;
							lDebit = lDebit + rs.Fields("amountCard").Value;
							lCredit = lCredit + rs.Fields("amountCredit").Value;
							lCheque = lCheque + rs.Fields("amountCheque").Value;
							break;
					}
					rs.moveNext();
				}
				rs.Close();

				//1. Cash
				Report.SetParameterValue("txtMoneyCash", Strings.FormatNumber(lCash, 2));
				modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(lCash, 2)) + " WHERE IDDescription = 1");
				modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(lCash, 2)) + " WHERE IDDescription = 1");
				//2. Credit Card
				Report.SetParameterValue("txtMoneyCRcard", Strings.FormatNumber(lCredit, 2));
				modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(lCredit, 2)) + " WHERE IDDescription = 3");
				modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(lCredit, 2)) + " WHERE IDDescription = 3");
				//3. Debit Card.
				Report.SetParameterValue("txtMoneyDRcard", Strings.FormatNumber(lDebit, 2));
				modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(lDebit, 2)) + " WHERE IDDescription = 4");
				modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(lDebit, 2)) + " WHERE IDDescription = 4");
				//4. Cheque
				Report.SetParameterValue("txtMoneyCheque", Strings.FormatNumber(lCheque, 2));
				modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(lCheque, 2)) + " WHERE IDDescription = 2");
				modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(lCheque, 2)) + " WHERE IDDescription = 2");

				//Total Money movement
				Report.SetParameterValue("txtMoneyTotal", Strings.FormatNumber(lTotal, 2));
				modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * lTotal, 2)) + " WHERE IDDescription = 13");
				modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * lTotal, 2)) + " WHERE IDDescription = 13");
				lTotal = 0;
				//do invoice discount....................

				 // ERROR: Not supported in C#: OnErrorStatement


				rs = modReport.getRSreport(ref "SELECT Sum(aCustomerTransaction.CustomerTransaction_Amount) AS SumOfCustomerTransaction_Amount FROM aCustomerTransaction INNER JOIN DayEnd ON aCustomerTransaction.CustomerTransaction_DayEndID = DayEnd.DayEndID WHERE (((aCustomerTransaction.CustomerTransaction_TransactionTypeID)=3 Or (aCustomerTransaction.CustomerTransaction_TransactionTypeID)=4 Or (aCustomerTransaction.CustomerTransaction_TransactionTypeID)=5) AND ((aCustomerTransaction.CustomerTransaction_ReferenceID)=0));");
				if (rs.RecordCount) {
					if (rs.Fields("SumOfCustomerTransaction_Amount").Value < 0) {
						Report.SetParameterValue("txtAccountEFT", Strings.FormatNumber(0, 2));
						Report.SetParameterValue("txtAccountEFT1", Strings.FormatNumber(0, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) + " WHERE IDDescription = 9");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) + " WHERE IDDescription = 10");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) + " WHERE IDDescription = 9");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) + " WHERE IDDescription = 10");
					} else {
						if (Information.IsDBNull(rs.Fields("SumOfCustomerTransaction_Amount").Value)) {
							Report.SetParameterValue("txtAccountEFT", "0.00");
							Report.SetParameterValue("txtAccountEFT1", "0.00");
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(0) + " WHERE IDDescription = 9");
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(0) + " WHERE IDDescription = 10");
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(0) + " WHERE IDDescription = 9");
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(0) + " WHERE IDDescription = 10");
						} else {
							Report.SetParameterValue("txtAccountEFT", Strings.FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2));
							Report.SetParameterValue("txtAccountEFT1", Strings.FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2));
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) + " WHERE IDDescription = 9");
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) + " WHERE IDDescription = 10");
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) + " WHERE IDDescription = 9");
							modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) + " WHERE IDDescription = 10");
						}
					}
				} else {
					Report.SetParameterValue("txtAccountEFT", Strings.FormatNumber(0, 2));
					Report.SetParameterValue("txtAccountEFT1", Strings.FormatNumber(0, 2));
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 9");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 10");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 9");
					modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 10");
				}
				//Set rs = getRSreport(sql)
				rDisplay_F = modRecordSet.getRS(ref "SELECT * FROM PastelDescription Order By IDDescription ASC");
				for (intF = 1; intF <= 29; intF++) {
					Report.SetParameterValue("txtDes1", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar1", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc1", rDisplay_F("AccountNumber"));
					rDisplay_F.MoveNext();
					Report.SetParameterValue("txtDes2", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar2", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc2", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes3", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar3", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc3", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes4", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar4", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc4", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes5", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar5", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc5", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes6", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar6", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc6", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes7", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar7", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc7", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes8", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar8", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc8", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes9", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar9", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc9", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes10", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar10", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc10", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes11", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar11", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc11", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes12", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar12", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc12", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes13", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar13", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc13", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes14", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar14", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc14", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes15", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar15", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc15", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes16", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar16", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc16", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes17", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar17", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc17", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes18", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar18", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc18", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes19", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar19", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc19", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes20", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar20", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc20", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes21", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar21", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc21", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes22", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar22", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc22", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes23", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar23", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc23", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes24", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar24", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc24", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes25", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar25", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc25", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes26", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar26", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc26", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes27", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar27", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc27", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes28", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar28", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc28", rDisplay_F("AccountNumber"));
					rDisplay_F.moveNext();
					Report.SetParameterValue("txtDes29", rDisplay_F("Description"));
					Report.SetParameterValue("txtNar29", rDisplay_F("Decription1"));
					Report.SetParameterValue("txtAcc29", rDisplay_F("AccountNumber"));
					break; // TODO: might not be correct. Was : Exit For
				}
				if (lMode) {
				} else {
					rs = modReport.getRSreport(ref "SELECT Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost]) AS listSales, Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ActualCost]) AS actualSales, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS listShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actualShrink, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost]) AS listGRV, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ActualCost]) AS actualGRV FROM DayEndStockItemLnk;");

					if (Information.IsDBNull(rs.Fields("listShrink").Value)) {
						Report.SetParameterValue("txtSHRL", Strings.FormatNumber(0, 2));
						Report.SetParameterValue("txtSHRL1", Strings.FormatNumber(0, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 14");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 15");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 14");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 15");
					} else {
						if (rs.Fields("listShrink").Value < 0) {
							Report.SetParameterValue("txtSHRL", Strings.FormatNumber(-1 * rs.Fields("listShrink").Value, 2));
							Report.SetParameterValue("txtSHRL1", Strings.FormatNumber(-1 * rs.Fields("listShrink").Value, 2));
						} else {
							Report.SetParameterValue("txtSHRL", Strings.FormatNumber(rs.Fields("listShrink").Value, 2));
							Report.SetParameterValue("txtSHRL1", Strings.FormatNumber(rs.Fields("listShrink").Value, 2));
						}

						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("listShrink").Value, 2)) + " WHERE IDDescription = 14");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("listShrink").Value, 2)) + " WHERE IDDescription = 15");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("listShrink").Value, 2)) + " WHERE IDDescription = 14");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("listShrink").Value, 2)) + " WHERE IDDescription = 15");
					}

					if (Information.IsDBNull(rs.Fields("listGRV").Value)) {
						Report.SetParameterValue("txtGRVL1", Strings.FormatNumber(0, 2));
						Report.SetParameterValue("txtGRVL", Strings.FormatNumber(0, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 20");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 21");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 20");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 21");
					} else {
						Report.SetParameterValue("txtGRVL1", Strings.FormatNumber(rs.Fields("listGRV").Value, 2));
						Report.SetParameterValue("txtGRVL", Strings.FormatNumber(rs.Fields("listGRV").Value, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("listGRV").Value, 2)) + " WHERE IDDescription = 20");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("listGRV").Value, 2)) + " WHERE IDDescription = 21");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("listGRV").Value, 2)) + " WHERE IDDescription = 20");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("listGRV").Value, 2)) + " WHERE IDDescription = 21");
					}

					if (Information.IsDBNull(rs.Fields("listSales").Value)) {
						Report.SetParameterValue("txtSaleL", Strings.FormatNumber(0, 2));
						Report.SetParameterValue("txtSaleL1", Strings.FormatNumber(0, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 16");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 17");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 16");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(0, 2)) + " WHERE IDDescription = 17");
					} else {
						Report.SetParameterValue("txtSaleL", Strings.FormatNumber(rs.Fields("listSales").Value, 2));
						Report.SetParameterValue("txtSaleL1", Strings.FormatNumber(rs.Fields("listSales").Value, 2));
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("listSales").Value, 2)) + " WHERE IDDescription = 16");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET Amount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("listSales").Value, 2)) + " WHERE IDDescription = 17");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(rs.Fields("listSales").Value, 2)) + " WHERE IDDescription = 16");
						modRecordSet.cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " + Convert.ToDecimal(Strings.FormatNumber(-1 * rs.Fields("listSales").Value, 2)) + " WHERE IDDescription = 17");
					}
				}
				rs = modReport.getRSreport(ref "SELECT Sum([SaleItem_ListCost]*[SaleItem_Quantity]) AS list, Sum([SaleItem_ActualCost]*[SaleItem_Quantity]) AS actual FROM aConsignment INNER JOIN SaleItem ON aConsignment.Consignment_SaleID = SaleItem.SaleItem_SaleID;");
				if (Information.IsDBNull(rs.Fields("list").Value)) {
					Report.SetParameterValue("txtConsLsales", Strings.FormatNumber("0", 2));
					Report.SetParameterValue("txtConsAsales", Strings.FormatNumber("0", 2));
				} else {
					Report.SetParameterValue("txtConsLsales", Strings.FormatNumber(rs("list"), 2));
					Report.SetParameterValue("txtConsAsales", Strings.FormatNumber(rs("actual"), 2));
				}
				rs = modReport.getRSreport(ref "SELECT Sum(Sale.Sale_Total) AS [amount] FROM aConsignment INNER JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID;");
				if (Information.IsDBNull(rs.Fields("amount").Value)) {
					Report.SetParameterValue("txtConsPsales", Strings.FormatNumber("0", 2));
				} else {
					Report.SetParameterValue("txtConsPsales", Strings.FormatNumber(rs("amount"), 2));
				}

				rs = modReport.getRSreport(ref "SELECT Sum([SaleItem_ListCost]*[SaleItem_Quantity]) AS list, Sum([SaleItem_ActualCost]*[SaleItem_Quantity]) AS actual FROM aConsignment INNER JOIN SaleItem ON aConsignment.Consignment_CompleteSaleID = SaleItem.SaleItem_SaleID;");
				if (Information.IsDBNull(rs.Fields("list").Value)) {
					Report.SetParameterValue("txtConsLPurchase", Strings.FormatNumber("0", 2));
					Report.SetParameterValue("txtConsAPurchase", Strings.FormatNumber("0", 2));
				} else {
					Report.SetParameterValue("txtConsLPurchase", Strings.FormatNumber(rs("list"), 2));
					Report.SetParameterValue("txtConsAPurchase", Strings.FormatNumber(rs("actual"), 2));
				}

				rs = modReport.getRSreport(ref "SELECT Sum(theJoin.list) AS list, Sum(theJoin.actual) AS actual FROM (SELECT  1 AS sale, Sum([SaleItem_Quantity]*[SaleItem_ListCost]) AS list, Sum([SaleItem_Quantity]*[SaleItem_actualCost]) AS actual FROM SaleItem INNER JOIN aConsignment ON SaleItem.SaleItem_SaleID = aConsignment.Consignment_CompleteSaleID Union SELECT 0 AS sale, Sum(0-[SaleItem_Quantity]*[SaleItem_ListCost]) AS list, Sum(0-[SaleItem_Quantity]*[SaleItem_actualCost]) AS actual FROM aConsignment INNER JOIN SaleItem ON aConsignment.Consignment_SaleID = SaleItem.SaleItem_SaleID WHERE (((aConsignment.Consignment_CompleteSaleID) Is Not Null))) AS theJoin;");
				if (Information.IsDBNull(rs.Fields("list").Value)) {
					Report.SetParameterValue("txtConsLreturn", Strings.FormatNumber("0", 2));
					Report.SetParameterValue("txtConsAreturn", Strings.FormatNumber("0", 2));
				} else {
					Report.SetParameterValue("txtConsLreturn", Strings.FormatNumber(rs("list"), 2));
					Report.SetParameterValue("txtConsAreturn", Strings.FormatNumber(rs("actual"), 2));
				}

				rs = modReport.getRSreport(ref "SELECT Sum([Sale]![Sale_Total]+[Sale_1]![Sale_Total]) AS priceReturn, Sale.Sale_Total FROM Sale INNER JOIN (Sale AS Sale_1 INNER JOIN aConsignment ON Sale_1.SaleID = aConsignment.Consignment_ReversalSaleID) ON Sale.SaleID = aConsignment.Consignment_CompleteSaleID GROUP BY Sale.Sale_Total;");
				if (rs.BOF | rs.EOF) {
					Report.SetParameterValue("txtConsPPurchase", Strings.FormatNumber("0", 2));
					Report.SetParameterValue("txtConsPreturn", Strings.FormatNumber("0", 2));
				} else {
					if (Information.IsDBNull(rs.Fields("Sale_Total").Value)) {
						Report.SetParameterValue("txtConsPPurchase", Strings.FormatNumber("0", 2));
						Report.SetParameterValue("txtConsPreturn", Strings.FormatNumber("0", 2));
					} else {
						Report.SetParameterValue("txtConsPPurchase", Strings.FormatNumber(rs("Sale_Total"), 2));
						Report.SetParameterValue("txtConsPreturn", Strings.FormatNumber(rs("priceReturn"), 2));
					}
				}

				rs = modReport.getRSreport(ref "SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS SCTotal, Sale.Sale_ChannelID FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_ChannelID;");
				//lTotal = CCur(Report.txtSCmDiscount.Text)
				while (!(rs.EOF)) {
					switch (rs.Fields("Sale_ChannelID").Value) {
					}
					lTotal = lTotal + rs.Fields("SCTotal").Value;
					rs.MoveNext();
				}
				rsPTotals = modRecordSet.getRS(ref "SELECT SUM(Amount) As totDebit FROM PastelDescription WHERE Amount > 0");
				rsPTotalss = modRecordSet.getRS(ref "SELECT SUM(Amount) as totCredit FROM PastelDescription WHERE Amount < 0");

				if (Information.IsDBNull(rsPTotals.Fields("totDebit").Value)) {
					Report.SetParameterValue("txtDebit", Strings.FormatNumber(0, 2));
				} else {
					Report.SetParameterValue("txtDebit", Strings.FormatNumber(rsPTotals.Fields("totDebit").Value));
				}
				if (Information.IsDBNull(rsPTotalss.Fields("totCredit").Value)) {
					Report.SetParameterValue("txtCredit", Strings.FormatNumber(0, 2));
				} else {
					Report.SetParameterValue("txtCredit", Strings.FormatNumber(rsPTotalss.Fields("totCredit").Value));
				}
				//Pastel export file
				if (modBResolutions.blpastel == true) {
					System.Windows.Forms.Cursor.Current = Cursors.Default;
					return;
				}

				My.MyProject.Forms.frmReportShow.Text = "Pastel Report";
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
				My.MyProject.Forms.frmReportShow.mReport = Report;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
			}
		}
		public static void ExportToCSVFile()
		{
			string dbText = null;
			string ptbl = null;
			string lne = null;
			short n = 0;
			string StDate = null;
			string t_Day = null;
			string t_Mon = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();

			if (Strings.Len(Strings.Trim(Conversion.Str(DateAndTime.Day(DateAndTime.Today)))) == 1)
				t_Day = "0" + Strings.Trim(Convert.ToString(DateAndTime.Day(DateAndTime.Today)));
			else
				t_Day = Convert.ToString(DateAndTime.Day(DateAndTime.Today));
			if (Strings.Len(Strings.Trim(Conversion.Str(DateAndTime.Month(DateAndTime.Today)))) == 1)
				t_Mon = "0" + Strings.Trim(Convert.ToString(DateAndTime.Month(DateAndTime.Today)));
			else
				t_Mon = Conversion.Str(DateAndTime.Month(DateAndTime.Today));

			ptbl = modRecordSet.serverPath + "4POSPAS" + Strings.Trim(Convert.ToString(DateAndTime.Year(DateAndTime.Today))) + Strings.Trim(t_Mon) + Strings.Trim(t_Day);

			if (fso.FileExists(ptbl + ".csv"))
				fso.DeleteFile((ptbl + ".csv"));

			FileSystem.FileOpen(1, ptbl + ".csv", OpenMode.Output);

			rs = modRecordSet.getRS(ref "SELECT Period,PastelDate,GDC,AccountNumber,Reference,Decription1,Amount,[Tax Type],[Tax Amount],[OpenItemType],[CostCode],[ContractAccount],[Exchange Rate],[Bank ExchangeRate],[Batch ID],[Discount TaxType],[Discount Amount],[HomeAmount] FROM PastelDescription");
			if (rs.RecordCount > 0) {
				//First line as column headings
				for (n = 0; n <= rs.Fields.Count - 1; n++) {
					lne = lne + Strings.Chr(34) + rs.Fields(n).Name + Strings.Chr(34) + ",";
				}

				//Print #1, lne

				while (!rs.EOF) {
					lne = "";

					for (n = 0; n <= rs.Fields.Count - 1; n++) {
						if (n == 10) {
							if (rs.Fields(n).Value == 0)
								lne = lne + " " + ",";
						} else {
							if (rs.Fields(n).Type == dbText) {
								lne = lne + Strings.Chr(34) + rs.Fields(n).Value + Strings.Chr(34) + ",";
							} else {
								//Re-write date format...
								if (rs.Fields(n).Type == 135) {
									lne = lne + Strings.Format(rs.Fields(n).Value, "dd/mm/yyyy") + ",";
								} else {
									lne = lne + rs.Fields(n).Value + ",";
								}
							}
						}

					}

					lne = Strings.Left(lne, Strings.Len(lne) - 1);
					//get rid of last comma
					FileSystem.PrintLine(1, lne);
					rs.moveNext();
				}
				FileSystem.FileClose(1);
			}

			if (modBResolutions.blpastel == true)
				Interaction.MsgBox("Pastel CSV File, was succesfully exported to " + ptbl, MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly + MsgBoxStyle.Information, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);


		}
		public static void report_KitchenMonitor(ref System.DateTime Dt1, ref System.DateTime Dt2, ref System.DateTime Dt3, ref System.DateTime Dt4)
		{
			//Dim sql     As String
			//Dim K_path  As String
			//Dim rs      As Recordset
			//Dim Report  As New cryKitchenMonitor

			//Screen.MousePointer = vbHourglass
			//Set rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
			//Report.txtCompanyName.SetText rs("Company_Name")

			//sql = "SELECT OrderMonitor.OrderReferenceID,Sum(ItemMonitor.ItemMonitor_Quantity) AS quantitySum, OrderMonitor.OrderMonitor_TPlaced, OrderMonitor.OrderMonitor_TCompleted, DateDiff('s',[OrderMonitor_TPlaced],[OrderMonitor_TCompleted]) AS Elapsed, Sum([ItemMonitor_Quantity]*[ItemMonitor_Price]) AS rTurnOver,OrderMonitor.OrderMonitor_Date FROM OrderMonitor INNER JOIN ItemMonitor ON OrderMonitor.OrderReferenceID = ItemMonitor.ItemMonitor_OrderID  Where (((OrderMonitor.OrderMonitor_OrderStatus) = True) And ((OrderMonitor.OrderMoniotor_FPlaced) = True)) GROUP BY OrderMonitor.OrderReferenceID, OrderMonitor.OrderMonitor_TPlaced, OrderMonitor.OrderMonitor_TCompleted, OrderMonitor.OrderMonitor_Date ORDER BY Sum(ItemMonitor.ItemMonitor_Quantity);"
			//Set rs = getRS(sql)
			//rs.filter = "OrderMonitor_Date<=#" & Format(Dt1, "yyyy/MM/dd") & "# AND OrderMonitor_Date>=#" & Format(Dt2, "yyyy/MM/dd") & "#"

			//rs.filter = "OrderMonitor_TPlaced >=#" & Format(Dt3, "hh:mm:ss") & "# AND OrderMonitor_TCompleted <=#" & Format(Dt4, "hh:mm:ss") & "#"

			//If rs.BOF Or rs.EOF Then
			//        'ReportNone.Load("cryNoRecords.rpt")
			//        ReportNone.txtCompanyName.SetText Report.txtCompanyName.Text
			//        ReportNone.txtTitle.SetText Report.txtTitle.Text
			//        frmReportShow.Caption = ReportNone.txtTitle.Text
			//        frmReportShow.CRViewer1.ReportSource = ReportNone
			//        Set frmReportShow.mReport = ReportNone: frmReportShow.sMode = "0"
			//        frmReportShow.CRViewer1.ViewReport
			//        Screen.MousePointer = vbDefault
			//        frmReportShow.show 1
			//        Exit Sub
			//End If

			//Report.txtDate.SetText "This report covers order done From " & Format(Dt1, "yyyy/MM/dd") & " TO " & Format(Dt2, "yyyy/MM/dd")
			//Report.txtTime.SetText "Between " & Format(Dt3, "hh:mm:ss") & " To " & Format(Dt4, "hh:mm:ss")

			//'Report.VerifyOnEveryPrint = True
			//Report.Database.Tables(1).SetDataSource rs, 3
			//Report.Database.SetDataSource rs, 3
			//'Report.VerifyOnEveryPrint = True
			//frmReportShow.Caption = Report.txtTitle.Text
			//frmReportShow.CRViewer1.ReportSource = Report
			//Set frmReportShow.mReport = Report: frmReportShow.sMode = "0"
			//frmReportShow.CRViewer1.ViewReport
			//Screen.MousePointer = vbDefault
			//frmReportShow.show 1
		}
		public static void EmulateSnapShot()
		{
			decimal lQuantity = default(decimal);
			ADODB.Recordset adoPrimaryRS = default(ADODB.Recordset);

			//Zerorise Stock Quantity...

			System.Windows.Forms.Application.DoEvents();
			modRecordSet.cnnDB.Execute("UPDATE Company SET Company.Company_StockTakeDate = now();");
			modRecordSet.cnnDB.Execute("DELETE FROM StockTake WHERE (StockTake_WarehouseID = 2)");
			modRecordSet.cnnDB.Execute("INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment ) SELECT StockItem.StockItemID, 2 AS warehouse, 0 AS quantity, 0 AS adjustment FROM StockItem;");
			modRecordSet.cnnDB.Execute("UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));");
			modRecordSet.cnnDB.Execute("DELETE FROM StockTakeDeposit");
			modRecordSet.cnnDB.Execute("INSERT INTO StockTakeDeposit ( StockTakeDeposit_WarehouseID, StockTakeDeposit_DepositID, StockTakeDeposit_DepositTypeID, StockTakeDeposit_Quantity, StockTakeDeposit_Adjustment ) SELECT WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity FROM WarehouseDepositItemLnk INNER JOIN DISPLAY_Deposits ON (DISPLAY_Deposits.type = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = DISPLAY_Deposits.DepositID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID = DISPLAY_Deposits.WarehouseID);");
			System.Windows.Forms.Application.DoEvents();
			System.Windows.Forms.Application.DoEvents();

			adoPrimaryRS = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where  StockTake.StockTake_WarehouseID = 2  AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ORDER BY StockItem.StockItem_Name;");

			while (adoPrimaryRS.EOF == false) {
				//lQuantity = 0 - adoPrimaryRS("StockTake_Quantity")
				lQuantity = -1 * adoPrimaryRS.Fields("StockTake_Quantity").Value;
				modRecordSet.cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" + lQuantity + ") WHERE (((StockTake.StockTake_StockItemID)=" + adoPrimaryRS.Fields("StockTake_StockItemID").Value + ") AND ((StockTake.StockTake_WarehouseID)=2));");
				modRecordSet.cnnDB.Execute("UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" + lQuantity + ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" + adoPrimaryRS.Fields("StockTake_StockItemID").Value + "));");
				adoPrimaryRS.moveNext();
			}

			System.Windows.Forms.Application.DoEvents();
			modRecordSet.cnnDB.Execute("UPDATE Company SET Company.Company_StockTakeDate = now();");
			modRecordSet.cnnDB.Execute("DELETE FROM StockTake WHERE (StockTake_WarehouseID = 2)");
			modRecordSet.cnnDB.Execute("INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment ) SELECT StockItem.StockItemID, 2 AS warehouse, 0 AS quantity, 0 AS adjustment FROM StockItem;");
			modRecordSet.cnnDB.Execute("UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));");
			modRecordSet.cnnDB.Execute("DELETE FROM StockTakeDeposit");
			modRecordSet.cnnDB.Execute("INSERT INTO StockTakeDeposit ( StockTakeDeposit_WarehouseID, StockTakeDeposit_DepositID, StockTakeDeposit_DepositTypeID, StockTakeDeposit_Quantity, StockTakeDeposit_Adjustment ) SELECT WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity FROM WarehouseDepositItemLnk INNER JOIN DISPLAY_Deposits ON (DISPLAY_Deposits.type = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = DISPLAY_Deposits.DepositID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID = DISPLAY_Deposits.WarehouseID);");
			System.Windows.Forms.Application.DoEvents();
			System.Windows.Forms.Application.DoEvents();

		}

		//changes from jonas for Price change report
		public static void report_NewPriceChange()
		{
			ADODB.Recordset rs3 = default(ADODB.Recordset);

			//On Local Error Resume Next
			//Dim Report As New crypricechange
			//Dim rs As ADODB.Recordset
			//Dim rs1 As ADODB.Recordset

			//Set rs = New ADODB.Recordset
			//Set rs1 = New ADODB.Recordset

			 // ERROR: Not supported in C#: OnErrorStatement


			//Set rs = getRS("SELECT * FROM Company")
			//Report.txtCompanyName.SetText rs("Company_Name")

			//Set rsP = getRS("SELECT * FROM NewPriceChanges")
			//fsdss = rs1("OldPrice")

			//Report.Database.Tables(1).SetDataSource rsP, 3
			//Report.Database.SetDataSource rsP, 3

			//'Report.VerifyOnEveryPrint = True
			//frmReportShow.Caption = Report.txtCompanyName.Text

			//frmReportShow.CRViewer1.ReportSource = Report
			//Set frmReportShow.mReport = Report: frmReportShow.sMode = "0"
			//frmReportShow.CRViewer1.ViewReport
			//frmReportShow.show 1


			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rs1 = default(ADODB.Recordset);
			ADODB.Recordset rs2 = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New crypricechange
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("crypricechange.rpt");
			decimal HMyPrice = default(decimal);
			string MyMarkup = null;

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modReport.getRSreport(ref "SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtDayEnd", rs("Report_Heading"));
			rs.Close();

			//create table name
			Te_Names = "NewPricechanges";
			//In case the table was not dropped then drop it
			//Set rs = getRS("DROP TABLE " & Te_Names & "")
			modReport.cnnDBreport.Execute("DROP TABLE " + Te_Names + "");
			MyFTypess = "PriceChangesID_DayEndStockItemLnk Number,PriceChanges_StockItemName Text(50),OldPrice Currency,NewPrice Currency,SellingPrice Currency,Markup Number";
			modReport.cnnDBreport.Execute("CREATE TABLE " + Te_Names + " (" + MyFTypess + ")");

			rs1 = modReport.getRSreport(ref "SELECT DayEnd.DayEndID, DayEnd.DayEnd_Date, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem1.StockItem_Name, DayEndStockItemLnk.DayEndStockItemLnk_ListCost, aStockItem1.StockItemID FROM Report INNER JOIN (DayEnd INNER JOIN (DayEndStockItemLnk INNER JOIN aStockItem1 ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem1.StockItemID) ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) ON Report.Report_DayEndEndID = DayEnd.DayEndID WHERE ((StockItem_Disabled=0) AND (StockItem_Discontinued=0)) ORDER BY aStockItem1.StockItemID;");
			if (rs1.RecordCount) {
				while (!(rs1.EOF)) {
					rs2 = modReport.getRSreport(ref "SELECT DayEnd.DayEndID, DayEnd.DayEnd_Date, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem1.StockItem_Name, DayEndStockItemLnk.DayEndStockItemLnk_ListCost, aStockItem1.StockItemID FROM Report INNER JOIN (DayEnd INNER JOIN (DayEndStockItemLnk INNER JOIN aStockItem1 ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem1.StockItemID) ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) ON Report.Report_DayEndStartID = DayEnd.DayEndID WHERE (((aStockItem1.StockItemID)=" + rs1.Fields("DayEndStockItemLnk_StockItemID").Value + "));");
					if (rs2.RecordCount) {
						if (rs1.Fields("DayEndStockItemLnk_ListCost").Value != rs2.Fields("DayEndStockItemLnk_ListCost").Value) {
							rs3 = modReport.getRSreport(ref "SELECT CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID From CatalogueChannelLnk WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)=" + rs1.Fields("DayEndStockItemLnk_StockItemID").Value + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)=1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));");
							if (rs3.RecordCount) {
								HMyPrice = rs3("CatalogueChannelLnk_Price").Value;
								MyMarkup = Convert.ToString(rs1.Fields("DayEndStockItemLnk_ListCost").Value / rs3("CatalogueChannelLnk_Price").Value * 100);
								MyMarkup = Convert.ToString(100 - Convert.ToDouble(MyMarkup));
							} else {
								MyMarkup = Convert.ToString(0);
								HMyPrice = 0;
							}
							//insert into Newpricechanges
							modReport.cnnDBreport.Execute("INSERT INTO " + Te_Names + "(PriceChangesID_DayEndStockItemLnk,PriceChanges_StockItemName,OldPrice,NewPrice,SellingPrice,Markup)VALUES(" + rs1.Fields("DayEndStockItemLnk_StockItemID").Value + ",'" + rs1.Fields("StockItem_Name").Value + "', " + rs2.Fields("DayEndStockItemLnk_ListCost").Value + ", " + rs1.Fields("DayEndStockItemLnk_ListCost").Value + "," + HMyPrice + "," + MyMarkup + ")");
							//delete duplicates
							//Set rsk = getRS("DELETE * FROM " & Te_Names & " WHERE (NewPricechanges.PriceChangesID_DayEndStockItemLnk =" & rs2("DayEndStockItemLnk_StockItemID") & " and NewPricechanges.OldPrice = " & rs2("DayEndStockItemLnk_ListCost") & " and NewPricechanges.NewPrice = " & rs2("DayEndStockItemLnk_ListCost") & ")")
						}
					}
					rs1.moveNext();
				}
			} else {
				//MsgBox "There was No Price Changes of Items between " & Me.txtstartdate.Text & " And " & Me.txtenddate.Text, vbInformation, "4POS"
			}

			rs = modReport.getRSreport(ref "SELECT * FROM NewPriceChanges");
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}

			Report.Database.Tables(1).SetDataSource(rs);
			//Report.VerifyOnEveryPrint = True
			//frmReportShow.Caption = Report.ParameterFields("txtTitle").ToString
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}
	}
}
