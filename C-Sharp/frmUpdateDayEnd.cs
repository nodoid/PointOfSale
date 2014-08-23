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
	internal partial class frmUpdateDayEnd : System.Windows.Forms.Form
	{
		short gCNT;
		short gTotal;

		private void loadLanguage()
		{

			//Label1 = No Code   [Updating Report Data...]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmUpdateDayEnd.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private bool buildPath1(ref string lPath)
		{
			bool functionReturnValue = false;
			ADOX.Catalog cat = default(ADOX.Catalog);
			ADOX.Table tbl = default(ADOX.Table);
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Connection cn = new ADODB.Connection();
			string lFile = null;
			string holdfile = null;
			string[] lArray = null;
			short x = 0;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			string lDir = null;
			cat = new ADOX.Catalog();
			tbl = new ADOX.Table();
			 // ERROR: Not supported in C#: OnErrorStatement

			Cursor = System.Windows.Forms.Cursors.WaitCursor;

			if (modReport.cnnDBreport == null) {
			} else {
				cat.let_ActiveConnection(modReport.cnnDBreport);
				foreach ( tbl in cat.Tables) {
					if (tbl.Type == "LINK") {
						System.Windows.Forms.Application.DoEvents();
						tbl.Properties("Jet OLEDB:Link Datasource").Value = modRecordSet.serverPath + "pricing.mdb";
						//Replace(LCase(tbl.Properties("Jet OLEDB:Link Datasource")), LCase("C:\4posServer\"), serverPath)
					}
				}
				cat = null;
				cn.Close();
				cn = null;
				cat = new ADOX.Catalog();
			}

			System.Windows.Forms.Application.DoEvents();
			Cursor = System.Windows.Forms.Cursors.Default;
			functionReturnValue = true;
			return functionReturnValue;
			buildPath_Error:
			Cursor = System.Windows.Forms.Cursors.Default;
			Interaction.MsgBox(Err().Description);
			functionReturnValue = false;
			return functionReturnValue;
		}

		private void linkTables(ref string source)
		{

			ADOX.Catalog cat = default(ADOX.Catalog);
			ADOX.Table tbl = default(ADOX.Table);
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			if (fso.FileExists(modRecordSet.serverPath + source + ".mdb")) {
			} else {
				return;
			}

			cat = new ADOX.Catalog();
			short x = 0;
			// Open the catalog.
			cat.let_ActiveConnection(modReport.cnnDBreport);

			for (x = cat.Tables.Count - 1; x >= 0; x += -1) {
				switch (Strings.LCase(cat.Tables(x).name)) {
					case "acustomertransaction":
					case "adayendstockitemlnk":
					case "adeclaration":
					case "asale":
					case "asaleitem":
					case "asuppliertransaction":
						cat.Tables.delete(cat.Tables(x).name);
						break;
				}
			}
			tbl = new ADOX.Table();
			tbl.name = "aCustomerTransaction";
			tbl.ParentCatalog = cat;
			tbl.Properties("Jet OLEDB:Link Datasource").Value = modRecordSet.serverPath + source + ".mdb";
			tbl.Properties("Jet OLEDB:Remote Table Name").Value = "CustomerTransaction";
			tbl.Properties("Jet OLEDB:Create Link").Value = true;
			cat.Tables.Append(tbl);

			tbl = new ADOX.Table();
			tbl.name = "aDayEndStockItemLnk";
			tbl.ParentCatalog = cat;
			tbl.Properties("Jet OLEDB:Link Datasource").Value = modRecordSet.serverPath + source + ".mdb";
			tbl.Properties("Jet OLEDB:Remote Table Name").Value = "DayEndStockItemLnk";
			tbl.Properties("Jet OLEDB:Create Link").Value = true;
			cat.Tables.Append(tbl);

			tbl = new ADOX.Table();
			tbl.name = "aDeclaration";
			tbl.ParentCatalog = cat;
			tbl.Properties("Jet OLEDB:Link Datasource").Value = modRecordSet.serverPath + source + ".mdb";
			tbl.Properties("Jet OLEDB:Remote Table Name").Value = "Declaration";
			tbl.Properties("Jet OLEDB:Create Link").Value = true;
			cat.Tables.Append(tbl);


			tbl = new ADOX.Table();
			tbl.name = "aSale";
			tbl.ParentCatalog = cat;
			tbl.Properties("Jet OLEDB:Link Datasource").Value = modRecordSet.serverPath + source + ".mdb";
			tbl.Properties("Jet OLEDB:Remote Table Name").Value = "Sale";
			tbl.Properties("Jet OLEDB:Create Link").Value = true;
			cat.Tables.Append(tbl);

			tbl = new ADOX.Table();
			tbl.name = "aSaleItem";
			tbl.ParentCatalog = cat;
			tbl.Properties("Jet OLEDB:Link Datasource").Value = modRecordSet.serverPath + source + ".mdb";
			tbl.Properties("Jet OLEDB:Remote Table Name").Value = "SaleItem";
			tbl.Properties("Jet OLEDB:Create Link").Value = true;
			cat.Tables.Append(tbl);

			tbl = new ADOX.Table();
			tbl.name = "aSupplierTransaction";
			tbl.ParentCatalog = cat;
			tbl.Properties("Jet OLEDB:Link Datasource").Value = modRecordSet.serverPath + source + ".mdb";
			tbl.Properties("Jet OLEDB:Remote Table Name").Value = "SupplierTransaction";
			tbl.Properties("Jet OLEDB:Create Link").Value = true;
			cat.Tables.Append(tbl);

			cat.Tables.Refresh();

			cat = null;


		}

		private void linkFirstTable(ref string source)
		{
			ADOX.Catalog cat = default(ADOX.Catalog);
			ADOX.Table tbl = default(ADOX.Table);
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();

			 // ERROR: Not supported in C#: OnErrorStatement


			if (fso.FileExists(modRecordSet.serverPath + source + ".mdb")) {
			} else {
				return;
			}

			cat = new ADOX.Catalog();
			short x = 0;
			// Open the catalog.
			cat.let_ActiveConnection(modReport.cnnDBreport);

			for (x = cat.Tables.Count - 1; x >= 0; x += -1) {
				switch (Strings.LCase(cat.Tables(x).name)) {
					case "adayendstockitemlnk":
						cat.Tables.delete(cat.Tables(x).name);
						break;
				}
			}
			tbl = new ADOX.Table();
			tbl.name = "aDayEndStockItemLnk";
			tbl.ParentCatalog = cat;
			tbl.Properties("Jet OLEDB:Link Datasource").Value = modRecordSet.serverPath + source + ".mdb";
			tbl.Properties("Jet OLEDB:Remote Table Name").Value = "DayEndStockItemLnk";
			tbl.Properties("Jet OLEDB:Create Link").Value = true;
			cat.Tables.Append(tbl);
			cat.Tables.Refresh();
			cat = null;
			return;
			withPass:
			openConnection_linkFirstTable:

			//cat.ActiveConnection("Jet OLEDB:Database Password") = "lqd"
			//Resume Next
			//Exit Sub

			//If Err.Description = "[Microsoft][ODBC Microsoft Access Driver] Not a valid password." Then
			//    GoTo withPass
			//ElseIf Err.Description = "Not a valid password." Then
			//    GoTo withPass
			//Else
			Interaction.MsgBox(Err().Number + " - " + Err().Description);
			//End If
		}

		private void moveItem()
		{
			gCNT = gCNT + 1;
			picInner.Width = sizeConvertors.twipsToPixels(Convert.ToInt16(sizeConvertors.pixelToTwips(picOuter.Width, true) / gTotal * gCNT) + 100, true);
			System.Windows.Forms.Application.DoEvents();
		}

		private void beginUpdate()
		{
			bool gModeReport = false;

			 // ERROR: Not supported in C#: OnErrorStatement


			picInner.Width = 0;
			gCNT = 0;
			System.Windows.Forms.Application.DoEvents();
			short x = 0;
			string sql = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsChk = default(ADODB.Recordset);
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			bool lMode = false;
			gModeReport = false;

			if (Strings.Left(modRecordSet.serverPath, 3) == "c:\\") {
			} else {
				buildPath1(ref modRecordSet.serverPath);
			}

			Label1.Text = "Loading Report ...";
			//Dim ccndbReport As Connection
			string[] lTable = null;
			short y = 0;
			lTable = Strings.Split("aChannel,aCompany,aConsignment,aCustomer,aDayEnd,aDayEndDepositItemLnk,aDeposit,aftConstruct,aftData,aftDataItem,aftSet,aGRV,aGRVDeposit,aGRVitem,aPackSize,aPayout,aPerson,aPOS,aPricingGroup,aPurchaseOrder,aRecipe,aRecipeStockitemLnk,aSaleItemReciept,aShrink,aStockBreakTransaction,aStockGroup,aStockItem,aStockTakeDetail,Supplier,Vat", ",");
			System.Windows.Forms.Application.DoEvents();
			gTotal = 9 + 1 * 9;
			//ccndbReport.Close
			//Set ccndbReport = openConnectionInstance("templatereport.mdb")
			for (y = 0; y <= Information.UBound(lTable); y++) {
				moveItem();
				System.Windows.Forms.Application.DoEvents();
				modReport.cnnDBreport.Execute("DELETE * FROM " + lTable[y] + ";");
				modReport.cnnDBreport.Execute("INSERT INTO " + lTable[y] + " SELECT * FROM " + lTable[y] + "1;");
			}

			Label1.Text = "Updating Report Data ...";
			picInner.Width = 0;
			gCNT = 0;
			System.Windows.Forms.Application.DoEvents();

			modReport.cnnDBreport.Execute("DELETE * FROM DayEnd");
			modReport.cnnDBreport.Execute("INSERT INTO dayend ( DayEndID, DayEnd_MonthEndID, DayEnd_Date ) SELECT aDayEnd.DayEndID, aDayEnd.DayEnd_MonthEndID, aDayEnd.DayEnd_Date From aDayEnd, Report WHERE (((aDayEnd.DayEndID)>=[Report]![Report_DayEndStartID] And (aDayEnd.DayEndID)<=[Report]![Report_DayEndEndID]));");
			modReport.cnnDBreport.Execute("DELETE DayEndStockItemLnkFirst.* FROM DayEndStockItemLnkFirst;");
			//Error in aCompany showing old wrong data if month end is done
			//Set rs = getRSreport("SELECT aDayEnd.*, aCompany.Company_DayEndID, aCompany.Company_MonthEndID From aDayEnd, Report, aCompany WHERE (((aDayEnd.DayEndID)=[Report]![Report_DayEndStartID]-1));")
			rs = modReport.getRSreport(ref "SELECT aDayEnd.*, aCompany1.Company_DayEndID, aCompany1.Company_MonthEndID From aDayEnd, Report, aCompany1 WHERE (((aDayEnd.DayEndID)=[Report]![Report_DayEndStartID]-1));");
			if (rs.RecordCount) {
				if (rs.Fields("DayEnd_MonthEndID").Value == rs.Fields("Company_MonthEndID").Value) {
					linkFirstTable(ref "pricing");
				} else {
					linkFirstTable(ref "month" + rs.Fields("DayEnd_MonthEndID").Value);
				}
				modReport.cnnDBreport.Execute("INSERT INTO DayEndStockItemLnkFirst SELECT aDayEndStockItemLnk.* FROM Report, aDayEndStockItemLnk INNER JOIN aDayEnd ON aDayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aDayEnd.DayEndID WHERE (((aDayEnd.DayEndID)=[Report]![Report_DayEndStartID]-1));");
			}
			rs.Close();

			//Error in aCompany showing old wrong data if month end is done
			//Set rs = getRSreport("SELECT DISTINCT DayEnd.DayEnd_MonthEndID, aCompany.Company_MonthEndID FROM DayEnd, aCompany;")
			rs = modReport.getRSreport(ref "SELECT DISTINCT DayEnd.DayEnd_MonthEndID, aCompany1.Company_MonthEndID FROM DayEnd, aCompany1;");
			gTotal = 9 + rs.RecordCount * 9;
			moveItem();
			modReport.cnnDBreport.Execute("DELETE Payout.* FROM Payout;");
			modReport.cnnDBreport.Execute("INSERT INTO Payout SELECT aPayout.* From Report, aPayout WHERE (((aPayout.Payout_DayEndID)>=[Report]![Report_DayEndStartID] And (aPayout.Payout_DayEndID)<=[Report]![Report_DayEndEndID]));");
			moveItem();
			modReport.cnnDBreport.Execute("DELETE aStockTakeDetail.* FROM aStockTakeDetail;");
			modReport.cnnDBreport.Execute("INSERT INTO aStockTakeDetail SELECT aStockTakeDetail1.* From Report, aStockTakeDetail1 WHERE (((aStockTakeDetail1.StockTake_DayEndID)>=[Report]![Report_DayEndStartID] And (aStockTakeDetail1.StockTake_DayEndID)<=[Report]![Report_DayEndEndID]));");
			moveItem();
			modReport.cnnDBreport.Execute("DELETE * FROM DayEndStockItemLnk");
			moveItem();
			modReport.cnnDBreport.Execute("DELETE * FROM DayEndDepositItemLnk");
			moveItem();
			modReport.cnnDBreport.Execute("DELETE SaleItem.* FROM SaleItem;");
			moveItem();

			//consignment setting in report
			modReport.cnnDBreport.Execute("DELETE aConsignment.* FROM aConsignment;");
			moveItem();

			modReport.cnnDBreport.Execute("DELETE Sale.* FROM Sale;");
			moveItem();
			modReport.cnnDBreport.Execute("DELETE CustomerTransaction.* FROM CustomerTransaction;");
			moveItem();
			modReport.cnnDBreport.Execute("DELETE Declaration.* FROM Declaration;");
			moveItem();
			modReport.cnnDBreport.Execute("DELETE SupplierTransaction.* FROM SupplierTransaction;");
			moveItem();

			while (!(rs.EOF)) {
				if (rs.Fields("DayEnd_MonthEndID").Value == rs.Fields("Company_MonthEndID").Value) {
					linkTables(ref "pricing");
				} else {
					linkTables(ref "month" + rs.Fields("DayEnd_MonthEndID").Value);
				}
				moveItem();
				modReport.cnnDBreport.Execute("INSERT INTO DayEndStockItemLnk SELECT aDayEndStockItemLnk.* FROM aDayEndStockItemLnk INNER JOIN DayEnd ON aDayEndStockItemLnk.DayEndStockItemLnk_DayEndID = DayEnd.DayEndID;");
				moveItem();
				 // ERROR: Not supported in C#: OnErrorStatement

				modReport.cnnDBreport.Execute("INSERT INTO DayEndDepositItemLnk SELECT aDayEndDepositItemLnk.* FROM aDayEndDepositItemLnk INNER JOIN DayEnd ON aDayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID = DayEnd.DayEndID;");
				moveItem();
				if (My.MyProject.Forms.frmMenu.gSuper == true) {
					modReport.cnnDBreport.Execute("INSERT INTO sale SELECT aSale.* FROM [SELECT aSale.* FROM aSale LEFT JOIN Sale ON aSale.SaleID = Sale.SaleID WHERE (((Sale.SaleID) Is Null))]. AS aSale, Report WHERE (((aSale.Sale_DayEndID)>=[Report]![Report_DayEndStartID] And (aSale.Sale_DayEndID)<=[Report]![Report_DayEndEndID]));");
				} else {
					if (rsChk.State)
						rsChk.Close();
					rsChk = modReport.getRSreport(ref "SELECT TOP 1 * FROM aSale;");
					if (rsChk.Fields.Count < 30) {
						modReport.cnnDBreport.Execute("INSERT INTO sale SELECT aSale.* FROM [SELECT aSale.* FROM aSale LEFT JOIN Sale ON aSale.SaleID = Sale.SaleID WHERE (((Sale.SaleID) Is Null))]. AS aSale, Report WHERE (((aSale.Sale_DayEndID)>=[Report]![Report_DayEndStartID] And (aSale.Sale_DayEndID)<=[Report]![Report_DayEndEndID]));");
					} else {
						modReport.cnnDBreport.Execute("INSERT INTO sale SELECT aSale.* FROM [SELECT aSale.* FROM aSale LEFT JOIN Sale ON aSale.SaleID = Sale.SaleID WHERE (((Sale.SaleID) Is Null))]. AS aSale, Report WHERE ((((aSale.Sale_SaleChk)=False) And (aSale.Sale_DayEndID)>=[Report]![Report_DayEndStartID] And (aSale.Sale_DayEndID)<=[Report]![Report_DayEndEndID]));");
					}
					rsChk.Close();
				}
				moveItem();
				modReport.cnnDBreport.Execute("INSERT INTO SaleItem SELECT aSaleItem.* FROM (aSaleItem INNER JOIN Sale ON aSaleItem.SaleItem_SaleID = Sale.SaleID) LEFT JOIN SaleItem ON aSaleItem.SaleItemID = SaleItem.SaleItemID WHERE (((SaleItem.SaleItemID) Is Null));");
				moveItem();

				//consignment setting in report
				modReport.cnnDBreport.Execute("INSERT INTO aConsignment SELECT aConsignment1.* FROM aConsignment1;");
				moveItem();

				if (rs.Fields("DayEnd_MonthEndID").Value == rs.Fields("Company_MonthEndID").Value) {
					modReport.cnnDBreport.Execute("INSERT INTO CustomerTransaction SELECT aCustomerTransaction.* From Report, aCustomerTransaction WHERE (((aCustomerTransaction.CustomerTransaction_MonthEndID)=" + rs.Fields("DayEnd_MonthEndID").Value + ") AND ((aCustomerTransaction.CustomerTransaction_DayEndID)>=[Report]![Report_DayEndStartID] And (aCustomerTransaction.CustomerTransaction_DayEndID)<=[Report]![Report_DayEndEndID]));");
				} else {
					modReport.cnnDBreport.Execute("INSERT INTO CustomerTransaction SELECT aCustomerTransaction.* From Report, aCustomerTransaction WHERE (((aCustomerTransaction.CustomerTransaction_MonthEndID)=" + rs.Fields("DayEnd_MonthEndID").Value + ") AND ((aCustomerTransaction.CustomerTransaction_DayEndID)>=[Report]![Report_DayEndStartID] And (aCustomerTransaction.CustomerTransaction_DayEndID)<=[Report]![Report_DayEndEndID]));");
				}
				moveItem();
				sql = "INSERT INTO SupplierTransaction ( SupplierTransactionID, SupplierTransaction_SupplierID, SupplierTransaction_PersonID, SupplierTransaction_TransactionTypeID, SupplierTransaction_MonthEndID, SupplierTransaction_MonthEndIDFor, SupplierTransaction_DayEndID, SupplierTransaction_ReferenceID, SupplierTransaction_Date, SupplierTransaction_Description, SupplierTransaction_Amount, SupplierTransaction_Reference )";
				sql = sql + "SELECT aSupplierTransaction.SupplierTransactionID, aSupplierTransaction.SupplierTransaction_SupplierID, aSupplierTransaction.SupplierTransaction_PersonID, aSupplierTransaction.SupplierTransaction_TransactionTypeID, aSupplierTransaction.SupplierTransaction_MonthEndID, aSupplierTransaction.SupplierTransaction_MonthEndIDFor, aSupplierTransaction.SupplierTransaction_DayEndID, aSupplierTransaction.SupplierTransaction_ReferenceID, aSupplierTransaction.SupplierTransaction_Date, aSupplierTransaction.SupplierTransaction_Description, aSupplierTransaction.SupplierTransaction_Amount, aSupplierTransaction.SupplierTransaction_Reference FROM aSupplierTransaction INNER JOIN DayEnd ON aSupplierTransaction.SupplierTransaction_DayEndID = DayEnd.DayEndID;";

				sql = "INSERT INTO SupplierTransaction ( SupplierTransactionID, SupplierTransaction_SupplierID, SupplierTransaction_PersonID, SupplierTransaction_TransactionTypeID, SupplierTransaction_MonthEndID, SupplierTransaction_MonthEndIDFor, SupplierTransaction_DayEndID, SupplierTransaction_ReferenceID, SupplierTransaction_Date, SupplierTransaction_Description, SupplierTransaction_Amount, SupplierTransaction_Reference ) ";
				sql = sql + "SELECT [SupplierTransaction_MonthEndID] & [SupplierTransactionID] AS Expr1, aSupplierTransaction.SupplierTransaction_SupplierID, aSupplierTransaction.SupplierTransaction_PersonID, aSupplierTransaction.SupplierTransaction_TransactionTypeID, aSupplierTransaction.SupplierTransaction_MonthEndID, aSupplierTransaction.SupplierTransaction_MonthEndIDFor, aSupplierTransaction.SupplierTransaction_DayEndID, aSupplierTransaction.SupplierTransaction_ReferenceID, aSupplierTransaction.SupplierTransaction_Date, aSupplierTransaction.SupplierTransaction_Description, aSupplierTransaction.SupplierTransaction_Amount, aSupplierTransaction.SupplierTransaction_Reference FROM aSupplierTransaction INNER JOIN DayEnd ON aSupplierTransaction.SupplierTransaction_DayEndID = DayEnd.DayEndID;";

				modReport.cnnDBreport.Execute(sql);
				moveItem();
				modReport.cnnDBreport.Execute("INSERT INTO Declaration SELECT aDeclaration.* From Report, aDeclaration WHERE (((aDeclaration.Declaration_DayEndID)>=[Report]![Report_DayEndStartID] And (aDeclaration.Declaration_DayEndID)<=[Report]![Report_DayEndEndID]));");
				moveItem();
				modReport.cnnDBreport.Execute("UPDATE aCompany INNER JOIN (DayEndStockItemLnk INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) ON aCompany.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_ListCost = [aStockItem]![StockItem_ListCost]/[aStockItem]![StockItem_Quantity], DayEndStockItemLnk.DayEndStockItemLnk_ActualCost = [aStockItem]![StockItem_ActualCost]/[aStockItem]![StockItem_Quantity];");
				moveItem();
				rs.moveNext();
			}

			moveItem();
			modReport.cnnDBreport.Execute("UPDATE Report SET Report.Report_Type = " + lMode + ";");
			rs = modReport.getRSreport(ref "SELECT DayEnd.DayEndID FROM aCompany INNER JOIN DayEnd ON aCompany.Company_DayEndID = DayEnd.DayEndID;");
			if (rs.RecordCount) {
				modReport.cnnDBreport.Execute("UPDATE Report SET Report.Report_Heading = [Report_Heading] & '(*)';");

				modReport.cnnDBreport.Execute("UPDATE aCompany INNER JOIN DayEndStockItemLnk ON aCompany.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales = 0, DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV = 0;");
				//Multi Warehouse change
				//cnnDBreport.Execute "UPDATE aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN ((DayEndStockItemLnk INNER JOIN (Sale INNER JOIN aCompany ON Sale.Sale_DayEndID = aCompany.Company_DayEndID) ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aCompany.Company_DayEndID) INNER JOIN SaleItem ON (DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = SaleItem.SaleItem_StockItemID) AND (Sale.SaleID = SaleItem.SaleItem_SaleID)) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantitySales]+(IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) WHERE (((SaleItem.SaleItem_Recipe)=0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_DepositType)=0) AND ((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null));"
				sql = "UPDATE aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN ((DayEndStockItemLnk INNER JOIN (Sale INNER JOIN aCompany ON Sale.Sale_DayEndID = aCompany.Company_DayEndID) ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aCompany.Company_DayEndID) INNER JOIN SaleItem ON (DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = SaleItem.SaleItem_StockItemID) AND (DayEndStockItemLnk.DayEndStockItemLnk_Warehouse = SaleItem.SaleItem_WarehouseID) AND (Sale.SaleID = SaleItem.SaleItem_SaleID)) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantitySales]+(IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) ";
				sql = sql + "WHERE (((SaleItem.SaleItem_Recipe)=0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_DepositType)=0) AND ((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null));";
				modReport.cnnDBreport.Execute(sql);

				//sql = "UPDATE aSaleItemReciept INNER JOIN (aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN ((DayEndStockItemLnk INNER JOIN (Sale INNER JOIN aCompany ON Sale.Sale_DayEndID = aCompany.Company_DayEndID) ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aCompany.Company_DayEndID) INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID) ON (aSaleItemReciept.SaleItemReciept_StockitemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) AND (aSaleItemReciept.SaleItemReciept_SaleItemID = SaleItem.SaleItemID) SET DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantitySales]+(IIf([SaleItem_Reversal],0-[SaleItemReciept_Quantity]*[SaleItem_Quantity],[SaleItemReciept_Quantity]*[SaleItem_Quantity])) "
				//sql = sql & "WHERE (((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_DepositType)=0) AND ((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null));"
				sql = "UPDATE aSaleItemReciept INNER JOIN (aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN ((DayEndStockItemLnk INNER JOIN (Sale INNER JOIN aCompany ON Sale.Sale_DayEndID = aCompany.Company_DayEndID) ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aCompany.Company_DayEndID) INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID AND DayEndStockItemLnk.DayEndStockItemLnk_Warehouse = SaleItem.SaleItem_WarehouseID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID) ON (aSaleItemReciept.SaleItemReciept_StockitemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) AND (aSaleItemReciept.SaleItemReciept_SaleItemID = SaleItem.SaleItemID) SET DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantitySales]+(IIf([SaleItem_Reversal],0-[SaleItemReciept_Quantity]*[SaleItem_Quantity],[SaleItemReciept_Quantity]*[SaleItem_Quantity])) ";
				sql = sql + "WHERE (((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_DepositType)=0) AND ((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null));";
				modReport.cnnDBreport.Execute(sql);
				//Multi Warehouse change
				modReport.cnnDBreport.Execute("UPDATE aGRV INNER JOIN ((aCompany INNER JOIN DayEndStockItemLnk ON aCompany.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aGRVItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aGRVItem.GRVItem_StockItemID) ON (DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aGRV.GRV_DayEndID) AND (aGRV.GRVID = aGRVItem.GRVItem_GRVID) SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV = [DayEndStockItemLnk_QuantityGRV]+IIf([aGRVItem]![GRVItem_Return],0-[GRVItem_PackSize]*[GRVItem_Quantity],[GRVItem_PackSize]*[GRVItem_Quantity]) WHERE (((aGRV.GRV_GRVStatusID)=3));");

			}

			System.Windows.Forms.Application.DoEvents();
			this.Close();

			return;
			Err_beginUpdate:

			Interaction.MsgBox("Error while Loading Report and Error is :" + Err().Number + " " + Err().Description + " " + Err().Source);
			System.Windows.Forms.Application.DoEvents();
			this.Close();
		}

		private void frmUpdateDayEnd_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			picInner.Width = 0;
		}

		private void tmrStart_Tick(System.Object eventSender, System.EventArgs eventArgs)
		{
			tmrStart.Enabled = false;
			beginUpdate();
		}
	}
}
