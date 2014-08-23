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
using System.Data.OleDb;
namespace _4PosBackOffice.NET
{
	internal partial class frmMonthEnd : System.Windows.Forms.Form
	{
		[DllImport("kernel32", EntryPoint = "GetComputerNameA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int GetComputerName(string lpBuffer, ref int nSize);

		const short mdPricingGroup = 0;
		const short mdDepartment = 1;
		const short mdPackSize = 2;

		short gMode;

		short lCNT;

		List<GroupBox> frmMode = new List<GroupBox>();
		const short mdDayEnd = 0;
		const short mdTransactions = 1;
		const short mdConfirm = 2;
		const short mdComplete = 3;

		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1274;
			//Month End Run|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//frmMode(0) = No Code    [Outstanding Day End Run!]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmMode(0).Caption = rsLang("LanguageLayoutLnk_Description"): frmMode(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1(5) = No Code    [There is an outstanding day end run.]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(5).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(5).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1(4) = No Code    [Please complete the Day End before proceeding with your Month End]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(4).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(4).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdBack.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdBack.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1005;
			//Next|
			if (modRecordSet.rsLang.RecordCount){cmdNext.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdNext.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//frmMode(1) = No Code   [Outstanding Day End Run]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmMode(1).Caption = rsLang("LanguageLayoutLnk_Description"): frmMode(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1(7) = No Code    [There have been no Point......]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(7).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(7).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Note: Grammar wrong in label caption!
			//Label1(6) = No Code    [There is no need to do your Month End Run.]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(6).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(6).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//frmMode(2) = No Code   [Confirm Month End Run]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmMode(3).Caption = rsLang("LanguageLayoutLnk_Description"): frmMode(3).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1(1) = No Code    [Are you sure you wish to run.......]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(1).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1(2) = No Code    [By pressing 'Next' you will commit the Month End Run.]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(1).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//frmMode(3) = No Code   [Month End Run Complete]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmMode(3).Caption = rsLang("LanguageLayoutLnk_Description"): frmMode(3).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmMonthEnd.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void doMode(ref short mode)
		{
			//    Dim lNodeList As IXMLDOMNodeList
			gMode = mode;
			//    Dim lNode As IXMLDOMNode
			ADODB.Recordset rs = default(ADODB.Recordset);
			short x = 0;

			for (x = 0; x <= frmMode.Count - 1; x++) {
				frmMode[x].Visible = false;
			}

			frmMode[gMode].Left = frmMode[0].Left;
			frmMode[gMode].Top = frmMode[0].Top;
			frmMode[gMode].Visible = true;

			ADODB.Recordset rsME = default(ADODB.Recordset);
			Scripting.TextStream textstreamME = default(Scripting.TextStream);
			Scripting.FileSystemObject fsoME = new Scripting.FileSystemObject();
			switch (gMode) {
				case mdDayEnd:
					rs = modRecordSet.getRS(ref "SELECT id FROM (SELECT COUNT(*) AS id FROM company INNER JOIN Sale ON Company.Company_DayEndID = Sale.Sale_DayEndID) transactions");

					if (rs.Fields("id").Value) {
					} else {
						doMode(ref mdTransactions);
						return;
					}
					this.cmdNext.Enabled = false;

					break;
				case mdTransactions:
					rs = modRecordSet.getRS(ref "SELECT Count(Sale.SaleID) AS id FROM Company INNER JOIN ((Sale INNER JOIN DayEnd ON Sale.Sale_DayEndID = DayEnd.DayEndID) INNER JOIN MonthEnd ON DayEnd.DayEnd_MonthEndID = MonthEnd.MonthEndID) ON Company.Company_MonthEndID = MonthEnd.MonthEndID;");

					if (rs.Fields("id").Value) {
						doMode(ref mdConfirm);
						return;
					}

					//If blMontheEnd = True Then
					//   str1 = "Month End Run failed to run, please try again!!!" & vbCrLf & "If the same problem persist, Consult 4POS for assistance"
					//   MsgBox str1, vbApplicationModal + vbInformation + vbOKOnly, "Month End"
					//End If

					this.cmdNext.Enabled = false;

					break;
				case mdConfirm:
					break;
				case mdComplete:
					//Set lDOM = modGeneral.lsData.SQL("p4_monthEnd")
					//modSecurity.checkSecurity

					//do backup
					rsME = modRecordSet.getRS(ref "select Company_BackupPath from Company");
					if (rsME.RecordCount) {
						if (!string.IsNullOrEmpty(rsME.Fields("Company_BackupPath").Value)) {
							if (fsoME.FileExists("C:\\4POSBackup.txt"))
								fsoME.DeleteFile("C:\\4POSBackup.txt", true);

							textstreamME = fsoME.OpenTextFile("C:\\4POSBackup.txt", Scripting.IOMode.ForWriting, true);
							textstreamME.Write(rsME.Fields("Company_BackupPath").Value);
							textstreamME.Close();

							Interaction.Shell("c:\\4pos\\4posbackup.exe", AppWinStyle.NormalFocus);
							System.Windows.Forms.Application.DoEvents();
						}
					}
					//do backup

					this.cmdNext.Visible = false;
					System.Windows.Forms.Application.DoEvents();
					doMonthEnd();
					break;
			}
		}

		private void BuildAll()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			int x = 0;
			System.Windows.Forms.Application.DoEvents();
			//cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN (Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID SET DayEndStockItemLnk.DayEndStockItemLnk_Quantity = [DayEndStockItemLnk_QuantitySales]+[WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)>1));"
			rs = modRecordSet.getRS(ref "Select * from Company");
			for (x = rs.Fields("Company_DayEndID").Value; x >= 0; x += -1) {
				modRecordSet.cnnDB.Execute("UPDATE DayEndStockItemLnk AS DayEndStockItemLnk_1 INNER JOIN DayEndStockItemLnk ON DayEndStockItemLnk_1.DayEndStockItemLnk_StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID SET DayEndStockItemLnk.DayEndStockItemLnk_Quantity = DayEndStockItemLnk_1!DayEndStockItemLnk_Quantity+[DayEndStockItemLnk]![DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk]![DayEndStockItemLnk_QuantityGRV]+[DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink] WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)=[DayEndStockItemLnk_1]![DayEndStockItemLnk_DayEndID]-1) AND ((DayEndStockItemLnk_1.DayEndStockItemLnk_DayEndID)=" + x + "));");
			}
		}
		private void doMonthEnd()
		{
			string sql = null;
			string lPath = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			ADODB.Connection dbcnnMonth = default(ADODB.Connection);

			//fix Server Path in Month End DBs
			string databaseName = null;

			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			System.Windows.Forms.Application.DoEvents();
			//BuildAll

			rs = modRecordSet.getRS(ref "SELECT Company_MonthEndID, Company_OpenDebtor From Company");
			lPath = modRecordSet.serverPath + "month" + rs.Fields("Company_MonthEndID").Value + ".mdb";

			//fix Server Path in Month End DBs
			databaseName = "month" + rs.Fields("Company_MonthEndID").Value + ".mdb";

			sql = "UPDATE Company Set Company.Company_MonthEndID = Company.Company_MonthEndID + 1;";
			modRecordSet.cnnDB.Execute(sql);
			sql = "INSERT INTO MonthEnd ( MonthEndID, MonthEnd_Date, MonthEnd_Days, MonthEnd_BudgetSales, MonthEnd_BudgetPurchases ) SELECT Company.Company_MonthEndID, Now(), 20, 100000, 100000 FROM Company;";
			modRecordSet.cnnDB.Execute(sql);

			modRecordSet.cnnDB.Execute("UPDATE Company INNER JOIN DayEnd ON Company.Company_DayEndID = DayEnd.DayEndID SET DayEnd.DayEnd_MonthEndID = [Company]![Company_MonthEndID];");

			fso.CopyFile(modRecordSet.serverPath + "template.mdb", lPath, true);

			dbcnnMonth = new ADODB.Connection();

			var _with1 = dbcnnMonth;
			_with1.Provider = "Microsoft.ACE.OLEDB.12.0";
			_with1.Properties("Jet OLEDB:System Database").Value = "" + modRecordSet.serverPath + "Secured.mdw";
			_with1.Open(lPath, "liquid", "lqd");

			sql = "UPDATE StockitemHistory SET StockitemHistory.StockitemHistory_Month12 = [StockitemHistory]![StockitemHistory_Month11], StockitemHistory.StockitemHistory_Month11 = [StockitemHistory]![StockitemHistory_Month10], StockitemHistory.StockitemHistory_Month10 = [StockitemHistory]![StockitemHistory_Month9], StockitemHistory.StockitemHistory_Month9 = [StockitemHistory]![StockitemHistory_Month8], StockitemHistory.StockitemHistory_Month8 = [StockitemHistory]![StockitemHistory_Month7], StockitemHistory.StockitemHistory_Month7 = [StockitemHistory]![StockitemHistory_Month6], StockitemHistory.StockitemHistory_Month6 = [StockitemHistory]![StockitemHistory_Month5], StockitemHistory.StockitemHistory_Month5 = [StockitemHistory]![StockitemHistory_Month4], ";
			sql = sql + "StockitemHistory.StockitemHistory_Month4 = [StockitemHistory]![StockitemHistory_Month3], StockitemHistory.StockitemHistory_Month3 = [StockitemHistory]![StockitemHistory_Month2], StockitemHistory.StockitemHistory_Month2 = [StockitemHistory]![StockitemHistory_Month1], StockitemHistory.StockitemHistory_Month1 = 0;";
			modRecordSet.cnnDB.Execute(sql);

			sql = "INSERT INTO Customer ( CustomerID, Customer_ChannelID, Customer_InvoiceName, Customer_DepartmentName, Customer_FirstName, Customer_Surname, Customer_PhysicalAddress, Customer_PostalAddress, Customer_Telephone, Customer_Fax, Customer_Email, Customer_Disabled, Customer_Terms, Customer_CreditLimit, Customer_Current, Customer_30Days, Customer_60Days, Customer_90Days, Customer_120Days, Customer_150Days, Customer_PrintStatement,Customer_VATNumber ) ";
			sql = sql + "SELECT M_Customer.CustomerID, M_Customer.Customer_ChannelID, M_Customer.Customer_InvoiceName, M_Customer.Customer_DepartmentName, M_Customer.Customer_FirstName, M_Customer.Customer_Surname, M_Customer.Customer_PhysicalAddress, M_Customer.Customer_PostalAddress, M_Customer.Customer_Telephone, M_Customer.Customer_Fax, M_Customer.Customer_Email, M_Customer.Customer_Disabled, M_Customer.Customer_Terms, M_Customer.Customer_CreditLimit, M_Customer.Customer_Current, M_Customer.Customer_30Days, M_Customer.Customer_60Days, M_Customer.Customer_90Days, M_Customer.Customer_120Days, M_Customer.Customer_150Days, M_Customer.Customer_PrintStatement, M_Customer.Customer_VATNumber FROM M_Customer;";
			dbcnnMonth.Execute(sql);

			sql = "INSERT INTO CustomerTransaction ( CustomerTransactionID, CustomerTransaction_CustomerID, CustomerTransaction_TransactionTypeID, CustomerTransaction_DayEndID, CustomerTransaction_MonthEndID, CustomerTransaction_ReferenceID, CustomerTransaction_Date, CustomerTransaction_Description, CustomerTransaction_Amount, CustomerTransaction_Reference, CustomerTransaction_PersonName, CustomerTransaction_Done, CustomerTransaction_Main, CustomerTransaction_Child, CustomerTransaction_Allocated ) ";
			sql = sql + "SELECT M_CustomerTransaction.CustomerTransactionID, M_CustomerTransaction.CustomerTransaction_CustomerID, M_CustomerTransaction.CustomerTransaction_TransactionTypeID, M_CustomerTransaction.CustomerTransaction_DayEndID, M_CustomerTransaction.CustomerTransaction_MonthEndID, M_CustomerTransaction.CustomerTransaction_ReferenceID, M_CustomerTransaction.CustomerTransaction_Date, M_CustomerTransaction.CustomerTransaction_Description, M_CustomerTransaction.CustomerTransaction_Amount, M_CustomerTransaction.CustomerTransaction_Reference, M_CustomerTransaction.CustomerTransaction_PersonName, M_CustomerTransaction.CustomerTransaction_Done, M_CustomerTransaction.CustomerTransaction_Main, M_CustomerTransaction.CustomerTransaction_Child, M_CustomerTransaction.CustomerTransaction_Allocated FROM M_CustomerTransaction;";
			dbcnnMonth.Execute(sql);

			sql = "INSERT INTO CustomerTransactionAlloc ( CustomerTransactionAllocID, CustomerTransactionAlloc_CustomerID, CustomerTransactionAlloc_MainID, CustomerTransactionAlloc_ChildID, CustomerTransactionAlloc_Date, CustomerTransactionAlloc_Description, CustomerTransactionAlloc_Amount, CustomerTransactionAlloc_Reference, CustomerTransactionAlloc_PersonName ) ";
			sql = sql + "SELECT M_CustomerTransactionAlloc.CustomerTransactionAllocID, M_CustomerTransactionAlloc.CustomerTransactionAlloc_CustomerID, M_CustomerTransactionAlloc.CustomerTransactionAlloc_MainID, M_CustomerTransactionAlloc.CustomerTransactionAlloc_ChildID, M_CustomerTransactionAlloc.CustomerTransactionAlloc_Date, M_CustomerTransactionAlloc.CustomerTransactionAlloc_Description, M_CustomerTransactionAlloc.CustomerTransactionAlloc_Amount, M_CustomerTransactionAlloc.CustomerTransactionAlloc_Reference, M_CustomerTransactionAlloc.CustomerTransactionAlloc_PersonName FROM M_CustomerTransactionAlloc;";
			dbcnnMonth.Execute(sql);

			if (rs.Fields("Company_OpenDebtor").Value == true) {
				//sql = "DELETE M_CustomerTransaction.* FROM M_CustomerTransaction WHERE (((M_CustomerTransaction.CustomerTransaction_Allocated)=[M_CustomerTransaction].[CustomerTransaction_Amount]) AND ((M_CustomerTransaction.CustomerTransaction_Allocated)<>0));"
				//dbcnnMonth.Execute sql
				sql = "DELETE M_CustomerTransaction.* FROM M_CustomerTransaction;";
				dbcnnMonth.Execute(sql);

				//version 1 problem
				//sql = "INSERT INTO M_CustomerTransaction ( CustomerTransaction_CustomerID, CustomerTransaction_TransactionTypeID, CustomerTransaction_DayEndID, CustomerTransaction_MonthEndID, CustomerTransaction_ReferenceID, CustomerTransaction_Date, CustomerTransaction_Description, CustomerTransaction_Amount, CustomerTransaction_Reference, CustomerTransaction_PersonName, CustomerTransaction_Done, CustomerTransaction_Main, CustomerTransaction_Child, CustomerTransaction_Allocated ) "
				//sql = sql & "SELECT CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, (CustomerTransaction.CustomerTransaction_Amount-CustomerTransaction.CustomerTransaction_Allocated) AS SumOfCustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_Reference & ' B/F' AS ref, CustomerTransaction.CustomerTransaction_PersonName, CustomerTransaction.CustomerTransaction_Done, CustomerTransaction.CustomerTransaction_Main, CustomerTransaction.CustomerTransaction_Child, CustomerTransaction.CustomerTransaction_Allocated "
				//sql = sql & "From CustomerTransaction WHERE (((CustomerTransaction.CustomerTransaction_Allocated)<>[CustomerTransaction].[CustomerTransaction_Amount])) AND (((CustomerTransaction.CustomerTransaction_Allocated)<>0));"
				//dbcnnMonth.Execute sql

				//version 2
				//sql = "INSERT INTO M_CustomerTransaction ( CustomerTransaction_CustomerID, CustomerTransaction_TransactionTypeID, CustomerTransaction_DayEndID, CustomerTransaction_MonthEndID, CustomerTransaction_ReferenceID, CustomerTransaction_Date, CustomerTransaction_Description, CustomerTransaction_Amount, CustomerTransaction_Reference, CustomerTransaction_PersonName, CustomerTransaction_Done ) "
				//sql = sql & "SELECT CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, M_Company.Company_DayEndID, M_Company.Company_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, (CustomerTransaction.CustomerTransaction_Amount-CustomerTransaction.CustomerTransaction_Allocated) AS SumOfCustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_Reference & '" & " *" & "' AS ref, CustomerTransaction.CustomerTransaction_PersonName, CustomerTransaction.CustomerTransaction_Done "
				//sql = sql & "FROM CustomerTransaction, M_Company WHERE (((CustomerTransaction.CustomerTransaction_Allocated)<>[CustomerTransaction].[CustomerTransaction_Amount])) ORDER BY CustomerTransaction.CustomerTransactionID;"
				//dbcnnMonth.Execute sql

				//version 3
				sql = "INSERT INTO M_CustomerTransaction ( CustomerTransaction_CustomerID, CustomerTransaction_TransactionTypeID, CustomerTransaction_DayEndID, CustomerTransaction_MonthEndID, CustomerTransaction_ReferenceID, CustomerTransaction_Date, CustomerTransaction_Description, CustomerTransaction_Amount, CustomerTransaction_Reference, CustomerTransaction_PersonName, CustomerTransaction_Done ) ";
				sql = sql + "SELECT CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, (CustomerTransaction.CustomerTransaction_Amount-CustomerTransaction.CustomerTransaction_Allocated) AS SumOfCustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_Reference & '" + " *" + "' AS ref, CustomerTransaction.CustomerTransaction_PersonName, CustomerTransaction.CustomerTransaction_Done ";
				sql = sql + "FROM CustomerTransaction WHERE (((CustomerTransaction.CustomerTransaction_Allocated)<>[CustomerTransaction].[CustomerTransaction_Amount])) ORDER BY CustomerTransaction.CustomerTransactionID;";
				dbcnnMonth.Execute(sql);

			} else {
				//DO THE OLD WAY
				sql = "DELETE M_CustomerTransaction.* FROM M_CustomerTransaction;";
				dbcnnMonth.Execute(sql);

				sql = "INSERT INTO M_CustomerTransaction ( CustomerTransaction_CustomerID, CustomerTransaction_TransactionTypeID, CustomerTransaction_DayEndID, CustomerTransaction_MonthEndID, CustomerTransaction_ReferenceID, CustomerTransaction_Date, CustomerTransaction_Description, CustomerTransaction_Amount, CustomerTransaction_Reference, CustomerTransaction_PersonName ) SELECT CustomerTransaction.CustomerTransaction_CustomerID, 7 AS transType, M_Company.Company_DayEndID, M_Company.Company_MonthEndID, 0 AS reference, Now() AS [date], '' AS [desc], Sum(CustomerTransaction.CustomerTransaction_Amount) AS SumOfCustomerTransaction_Amount, 'Month End' AS ref, 'System' AS person From CustomerTransaction, M_Company GROUP BY CustomerTransaction.CustomerTransaction_CustomerID, M_Company.Company_DayEndID, M_Company.Company_MonthEndID;";
				dbcnnMonth.Execute(sql);
			}

			sql = "UPDATE M_Customer SET M_Customer.Customer_150Days = [M_Customer]![Customer_150Days]+[M_Customer]![Customer_120Days], M_Customer.Customer_120Days = [M_Customer]![Customer_90Days], M_Customer.Customer_90Days = [M_Customer]![Customer_60Days], M_Customer.Customer_60Days = [M_Customer]![Customer_30Days], M_Customer.Customer_30Days = [M_Customer]![Customer_Current], M_Customer.Customer_Current = 0;";
			dbcnnMonth.Execute(sql);

			//Debtor Age shifting if Credit
			dbcnnMonth.Execute("UPDATE M_Customer SET M_Customer.Customer_120Days = iif(([M_Customer]![Customer_150Days]<0),([M_Customer]![Customer_120Days]+[M_Customer]![Customer_150Days]),[M_Customer]![Customer_120Days]);");
			dbcnnMonth.Execute("UPDATE M_Customer SET M_Customer.Customer_150Days = iif(([M_Customer]![Customer_150Days]<0),0,[M_Customer]![Customer_150Days]);");

			dbcnnMonth.Execute("UPDATE M_Customer SET M_Customer.Customer_90Days = iif(([M_Customer]![Customer_120Days]<0),([M_Customer]![Customer_90Days]+[M_Customer]![Customer_120Days]),[M_Customer]![Customer_90Days]);");
			dbcnnMonth.Execute("UPDATE M_Customer SET M_Customer.Customer_120Days = iif(([M_Customer]![Customer_120Days]<0),0,[M_Customer]![Customer_120Days]);");

			dbcnnMonth.Execute("UPDATE M_Customer SET M_Customer.Customer_60Days = iif(([M_Customer]![Customer_90Days]<0),([M_Customer]![Customer_60Days]+[M_Customer]![Customer_90Days]),[M_Customer]![Customer_60Days]);");
			dbcnnMonth.Execute("UPDATE M_Customer SET M_Customer.Customer_90Days = iif(([M_Customer]![Customer_90Days]<0),0,[M_Customer]![Customer_90Days]);");

			dbcnnMonth.Execute("UPDATE M_Customer SET M_Customer.Customer_30Days = iif(([M_Customer]![Customer_60Days]<0),([M_Customer]![Customer_30Days]+[M_Customer]![Customer_60Days]),[M_Customer]![Customer_30Days]);");
			dbcnnMonth.Execute("UPDATE M_Customer SET M_Customer.Customer_60Days = iif(([M_Customer]![Customer_60Days]<0),0,[M_Customer]![Customer_60Days]);");

			dbcnnMonth.Execute("UPDATE M_Customer SET M_Customer.Customer_Current = iif(([M_Customer]![Customer_30Days]<0),([M_Customer]![Customer_Current]+[M_Customer]![Customer_30Days]),[M_Customer]![Customer_Current]);");
			dbcnnMonth.Execute("UPDATE M_Customer SET M_Customer.Customer_30Days = iif(([M_Customer]![Customer_30Days]<0),0,[M_Customer]![Customer_30Days]);");
			//Debtor Age shifting if Credit

			//Tranfer change             sql = "INSERT INTO DayEndStockItemLnk ( DayEndStockItemLnk_DayEndID, DayEndStockItemLnk_StockItemID, DayEndStockItemLnk_Quantity, DayEndStockItemLnk_QuantitySales, DayEndStockItemLnk_QuantityShrink, DayEndStockItemLnk_QuantityGRV, DayEndStockItemLnk_ListCost, DayEndStockItemLnk_ActualCost, DayEndStockItemLnk_Warehouse ) SELECT M_DayEndStockItemLnk.DayEndStockItemLnk_DayEndID, M_DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, M_DayEndStockItemLnk.DayEndStockItemLnk_Quantity, M_DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales, M_DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink, M_DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV, M_DayEndStockItemLnk.DayEndStockItemLnk_ListCost, M_DayEndStockItemLnk.DayEndStockItemLnk_ActualCost, M_DayEndStockItemLnk.DayEndStockItemLnk_Warehouse From M_DayEndStockItemLnk, M_Company WHERE (((M_DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)<>[M_Company]![Company_DayEndID]));"
			sql = "INSERT INTO DayEndStockItemLnk ( DayEndStockItemLnk_DayEndID, DayEndStockItemLnk_StockItemID, DayEndStockItemLnk_Quantity, DayEndStockItemLnk_QuantitySales, DayEndStockItemLnk_QuantityShrink, DayEndStockItemLnk_QuantityGRV, DayEndStockItemLnk_QuantityTransafer, DayEndStockItemLnk_ListCost, DayEndStockItemLnk_ActualCost, DayEndStockItemLnk_Warehouse ) SELECT M_DayEndStockItemLnk.DayEndStockItemLnk_DayEndID, M_DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, M_DayEndStockItemLnk.DayEndStockItemLnk_Quantity, M_DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales, M_DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink, M_DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV, M_DayEndStockItemLnk.DayEndStockItemLnk_QuantityTransafer, M_DayEndStockItemLnk.DayEndStockItemLnk_ListCost, M_DayEndStockItemLnk.DayEndStockItemLnk_ActualCost, M_DayEndStockItemLnk.DayEndStockItemLnk_Warehouse ";
			sql = sql + "From M_DayEndStockItemLnk, M_Company WHERE (((M_DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)<>[M_Company]![Company_DayEndID]));";
			dbcnnMonth.Execute(sql);

			sql = "DELETE M_DayEndStockItemLnk.* From M_DayEndStockItemLnk, M_Company WHERE (((M_DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)<>[M_Company]![Company_DayEndID]));";
			dbcnnMonth.Execute(sql);

			//Tranfer change
			sql = "INSERT INTO StockTransferWH ( StockTransferWH_Date, StockTransferWH_DayEndID, StockTransferWH_PersonID, StockTransferWH_WHFrom, StockTransferWH_WHTo, StockTransferWH_StockItemID, StockTransferWH_Qty ) SELECT M_StockTransferWH.StockTransferWH_Date, M_StockTransferWH.StockTransferWH_DayEndID, M_StockTransferWH.StockTransferWH_PersonID, M_StockTransferWH.StockTransferWH_WHFrom, M_StockTransferWH.StockTransferWH_WHTo, M_StockTransferWH.StockTransferWH_StockItemID, M_StockTransferWH.StockTransferWH_Qty ";
			sql = sql + "From M_StockTransferWH, M_Company WHERE (((M_StockTransferWH.StockTransferWH_DayEndID)<>[M_Company]![Company_DayEndID]));";
			dbcnnMonth.Execute(sql);

			sql = "DELETE M_StockTransferWH.* From M_StockTransferWH, M_Company WHERE (((M_StockTransferWH.StockTransferWH_DayEndID)<>[M_Company]![Company_DayEndID]));";
			dbcnnMonth.Execute(sql);
			//Tranfer change

			sql = "INSERT INTO Declaration ( DeclarationID, Declaration_POSID, Declaration_DayEndID, Declaration_Date, Declaration_Cash, Declaration_CashServer, Declaration_CashCount, Declaration_Cheque, Declaration_ChequeServer, Declaration_ChequeCount, Declaration_Card, Declaration_CardServer, Declaration_CardCount, Declaration_Payout, Declaration_PayoutServer, Declaration_PayoutCount, Declaration_Total, Declaration_TotalServer, Declaration_TotalCount ) ";
			sql = sql + "SELECT M_Declaration.DeclarationID, M_Declaration.Declaration_POSID, M_Declaration.Declaration_DayEndID, M_Declaration.Declaration_Date, M_Declaration.Declaration_Cash, M_Declaration.Declaration_CashServer, M_Declaration.Declaration_CashCount, M_Declaration.Declaration_Cheque, M_Declaration.Declaration_ChequeServer, M_Declaration.Declaration_ChequeCount, M_Declaration.Declaration_Card, M_Declaration.Declaration_CardServer, M_Declaration.Declaration_CardCount, M_Declaration.Declaration_Payout, M_Declaration.Declaration_PayoutServer, M_Declaration.Declaration_PayoutCount, M_Declaration.Declaration_Total, M_Declaration.Declaration_TotalServer, M_Declaration.Declaration_TotalCount FROM M_Declaration;";
			dbcnnMonth.Execute(sql);

			sql = "DELETE M_Declaration.* FROM M_Declaration;";
			dbcnnMonth.Execute(sql);

			sql = "INSERT INTO Sale ( SaleID, Sale_PosID, Sale_DeclarationID, Sale_ChannelID, Sale_PersonID, Sale_ManagerID, Sale_DayEndID, Sale_Date, Sale_DatePOS, Sale_SubTotal, Sale_Discount, Sale_Total, Sale_Tender, Sale_Slip, Sale_PaymentType, Sale_Reference,Sale_CardRef,Sale_OrderRef,Sale_SerialRef,Sale_Cash,Sale_Card,Sale_Cheque,Sale_CDebit,Sale_PersonShiftID,Sale_TableNumber,Sale_GuestCount,Sale_SlipCount,Sale_Gratuity,Sale_DisChk,Sale_SaleChk ) ";
			sql = sql + "SELECT M_Sale.SaleID, M_Sale.Sale_PosID, M_Sale.Sale_DeclarationID, M_Sale.Sale_ChannelID, M_Sale.Sale_PersonID, M_Sale.Sale_ManagerID, M_Sale.Sale_DayEndID, M_Sale.Sale_Date, M_Sale.Sale_DatePOS, M_Sale.Sale_SubTotal, M_Sale.Sale_Discount, M_Sale.Sale_Total, M_Sale.Sale_Tender, M_Sale.Sale_Slip, M_Sale.Sale_PaymentType, Sale_Reference,M_Sale.Sale_CardRef,M_Sale.Sale_OrderRef,M_Sale.Sale_SerialRef, M_Sale.Sale_Cash,M_Sale.Sale_Card,M_Sale.Sale_Cheque,M_Sale.Sale_CDebit,M_Sale.Sale_PersonShiftID,M_Sale.Sale_TableNumber,M_Sale.Sale_GuestCount,M_Sale.Sale_SlipCount,M_Sale.Sale_Gratuity,M_Sale.Sale_DisChk,M_Sale.Sale_SaleChk FROM M_Sale;";
			dbcnnMonth.Execute(sql);

			sql = "INSERT INTO SaleItem ( SaleItemID, SaleItem_SaleID, SaleItem_StockItemID, SaleItem_ShrinkQuantity, SaleItem_Quantity, SaleItem_LineNo, SaleItem_Vat, SaleItem_PriceOriginal, SaleItem_Price, SaleItem_Revoke, SaleItem_Reversal, SaleItem_DepositType, SaleItem_DepositCost, SaleItem_ActualCost, SaleItem_ListCost, SaleItem_SetID, SaleItem_WarehouseID ) SELECT M_SaleItem.SaleItemID, M_SaleItem.SaleItem_SaleID, M_SaleItem.SaleItem_StockItemID, M_SaleItem.SaleItem_ShrinkQuantity, M_SaleItem.SaleItem_Quantity, M_SaleItem.SaleItem_LineNo, M_SaleItem.SaleItem_Vat, M_SaleItem.SaleItem_PriceOriginal, M_SaleItem.SaleItem_Price, M_SaleItem.SaleItem_Revoke, M_SaleItem.SaleItem_Reversal, M_SaleItem.SaleItem_DepositType, M_SaleItem.SaleItem_DepositCost, M_SaleItem.SaleItem_ActualCost, M_SaleItem.SaleItem_ListCost, M_SaleItem.SaleItem_SetID, M_SaleItem.SaleItem_WarehouseID FROM M_SaleItem;";
			dbcnnMonth.Execute(sql);

			sql = "INSERT INTO SaleItemReciept ( SaleItemReciept_SaleItemID, SaleItemReciept_StockitemID, SaleItemReciept_Quantity, SaleItemReciept_DepositCost, SaleItemReciept_ListCost, SaleItemReciept_ActualCost, SaleItemReciept_Price ) SELECT M_SaleItemReciept.SaleItemReciept_SaleItemID, M_SaleItemReciept.SaleItemReciept_StockitemID, M_SaleItemReciept.SaleItemReciept_Quantity, M_SaleItemReciept.SaleItemReciept_DepositCost, M_SaleItemReciept.SaleItemReciept_ListCost, M_SaleItemReciept.SaleItemReciept_ActualCost, M_SaleItemReciept.SaleItemReciept_Price FROM M_SaleItemReciept;";
			dbcnnMonth.Execute(sql);

			sql = "DELETE M_SaleItemReciept.* FROM M_SaleItemReciept;";
			dbcnnMonth.Execute(sql);


			sql = "DELETE M_SaleItem.* FROM M_SaleItem;";
			dbcnnMonth.Execute(sql);

			sql = "DELETE M_Sale.* FROM M_Sale;";
			dbcnnMonth.Execute(sql);

			sql = "INSERT INTO Supplier ( SupplierID, Supplier_SystemID, Supplier_Name, Supplier_PostalAddress, Supplier_PhysicalAddress, Supplier_Telephone, Supplier_Facimile, Supplier_RepresentativeName, Supplier_RepresentativeNumber, Supplier_ShippingCode, Supplier_OrderAttentionLine, Supplier_Terms, Supplier_Ullage, Supplier_discountCOD, Supplier_discount15days, Supplier_discount30days, Supplier_discount60days, Supplier_discount90days, Supplier_discount120days, Supplier_discountSmartCard, Supplier_discountDefault, Supplier_Current, Supplier_30Days, Supplier_60Days, Supplier_90Days, Supplier_120Days, Supplier_GRVtype ) ";
			sql = sql + "SELECT M_Supplier.SupplierID, M_Supplier.Supplier_SystemID, M_Supplier.Supplier_Name, M_Supplier.Supplier_PostalAddress, M_Supplier.Supplier_PhysicalAddress, M_Supplier.Supplier_Telephone, M_Supplier.Supplier_Facimile, M_Supplier.Supplier_RepresentativeName, M_Supplier.Supplier_RepresentativeNumber, M_Supplier.Supplier_ShippingCode, M_Supplier.Supplier_OrderAttentionLine, M_Supplier.Supplier_Terms, M_Supplier.Supplier_Ullage, M_Supplier.Supplier_discountCOD, M_Supplier.Supplier_discount15days, M_Supplier.Supplier_discount30days, M_Supplier.Supplier_discount60days, M_Supplier.Supplier_discount90days, M_Supplier.Supplier_discount120days, M_Supplier.Supplier_discountSmartCard, M_Supplier.Supplier_discountDefault, M_Supplier.Supplier_Current, M_Supplier.Supplier_30Days, M_Supplier.Supplier_60Days, M_Supplier.Supplier_90Days, M_Supplier.Supplier_120Days, M_Supplier.Supplier_GRVtype FROM M_Supplier;";
			dbcnnMonth.Execute(sql);

			sql = "INSERT INTO SupplierTransaction ( SupplierTransactionID, SupplierTransaction_SupplierID, SupplierTransaction_PersonID, SupplierTransaction_TransactionTypeID, SupplierTransaction_MonthEndID, SupplierTransaction_MonthEndIDFor, SupplierTransaction_DayEndID, SupplierTransaction_ReferenceID, SupplierTransaction_Date, SupplierTransaction_Description, SupplierTransaction_Amount, SupplierTransaction_Reference ) ";
			sql = sql + "SELECT M_SupplierTransaction.SupplierTransactionID, M_SupplierTransaction.SupplierTransaction_SupplierID, M_SupplierTransaction.SupplierTransaction_PersonID, M_SupplierTransaction.SupplierTransaction_TransactionTypeID, M_SupplierTransaction.SupplierTransaction_MonthEndID, M_SupplierTransaction.SupplierTransaction_MonthEndIDFor, M_SupplierTransaction.SupplierTransaction_DayEndID, M_SupplierTransaction.SupplierTransaction_ReferenceID, M_SupplierTransaction.SupplierTransaction_Date, M_SupplierTransaction.SupplierTransaction_Description, M_SupplierTransaction.SupplierTransaction_Amount, M_SupplierTransaction.SupplierTransaction_Reference FROM M_SupplierTransaction;";
			dbcnnMonth.Execute(sql);

			sql = "DELETE M_SupplierTransaction.* FROM M_SupplierTransaction;";
			dbcnnMonth.Execute(sql);

			//*********************
			sql = "INSERT INTO M_SupplierTransaction ( SupplierTransaction_SupplierID, SupplierTransaction_PersonID, SupplierTransaction_TransactionTypeID, SupplierTransaction_MonthEndID, SupplierTransaction_MonthEndIDFor, SupplierTransaction_DayEndID, SupplierTransaction_ReferenceID, SupplierTransaction_Date, SupplierTransaction_Description, SupplierTransaction_Amount, SupplierTransaction_Reference ) SELECT SupplierTransaction.SupplierTransaction_SupplierID, 1 AS person, 7 AS tranType, M_Company.Company_MonthEndID, M_Company.Company_MonthEndID, M_Company.Company_DayEndID, 0 AS refID, Now() AS [date], '' AS [desc], Sum(SupplierTransaction.SupplierTransaction_Amount) AS SumOfSupplierTransaction_Amount, 'Month End' AS ref From SupplierTransaction, M_Company GROUP BY SupplierTransaction.SupplierTransaction_SupplierID, M_Company.Company_MonthEndID, M_Company.Company_MonthEndID, M_Company.Company_DayEndID;";
			dbcnnMonth.Execute(sql);

			sql = "UPDATE M_Supplier SET M_Supplier.Supplier_120Days = [M_Supplier]![Supplier_120Days]+[M_Supplier]![Supplier_90Days], M_Supplier.Supplier_90Days = [M_Supplier]![Supplier_60Days], M_Supplier.Supplier_60Days = [M_Supplier]![Supplier_30Days], M_Supplier.Supplier_30Days = [M_Supplier]![Supplier_Current], M_Supplier.Supplier_Current = 0;";
			dbcnnMonth.Execute(sql);

			//Debtor Age shifting if Credit
			//dbcnnMonth.Execute "UPDATE M_Supplier SET M_Supplier.Supplier_120Days = iif(([M_Supplier]![Supplier_150Days]<0),([M_Supplier]![Supplier_120Days]+[M_Supplier]![Supplier_150Days]),[M_Supplier]![Supplier_120Days]);"
			//dbcnnMonth.Execute "UPDATE M_Supplier SET M_Supplier.Supplier_150Days = iif(([M_Supplier]![Supplier_150Days]<0),0,[M_Supplier]![Supplier_150Days]);"

			dbcnnMonth.Execute("UPDATE M_Supplier SET M_Supplier.Supplier_90Days = iif(([M_Supplier]![Supplier_120Days]<0),([M_Supplier]![Supplier_90Days]+[M_Supplier]![Supplier_120Days]),[M_Supplier]![Supplier_90Days]);");
			dbcnnMonth.Execute("UPDATE M_Supplier SET M_Supplier.Supplier_120Days = iif(([M_Supplier]![Supplier_120Days]<0),0,[M_Supplier]![Supplier_120Days]);");

			dbcnnMonth.Execute("UPDATE M_Supplier SET M_Supplier.Supplier_60Days = iif(([M_Supplier]![Supplier_90Days]<0),([M_Supplier]![Supplier_60Days]+[M_Supplier]![Supplier_90Days]),[M_Supplier]![Supplier_60Days]);");
			dbcnnMonth.Execute("UPDATE M_Supplier SET M_Supplier.Supplier_90Days = iif(([M_Supplier]![Supplier_90Days]<0),0,[M_Supplier]![Supplier_90Days]);");

			dbcnnMonth.Execute("UPDATE M_Supplier SET M_Supplier.Supplier_30Days = iif(([M_Supplier]![Supplier_60Days]<0),([M_Supplier]![Supplier_30Days]+[M_Supplier]![Supplier_60Days]),[M_Supplier]![Supplier_30Days]);");
			dbcnnMonth.Execute("UPDATE M_Supplier SET M_Supplier.Supplier_60Days = iif(([M_Supplier]![Supplier_60Days]<0),0,[M_Supplier]![Supplier_60Days]);");

			dbcnnMonth.Execute("UPDATE M_Supplier SET M_Supplier.Supplier_Current = iif(([M_Supplier]![Supplier_30Days]<0),([M_Supplier]![Supplier_Current]+[M_Supplier]![Supplier_30Days]),[M_Supplier]![Supplier_Current]);");
			dbcnnMonth.Execute("UPDATE M_Supplier SET M_Supplier.Supplier_30Days = iif(([M_Supplier]![Supplier_30Days]<0),0,[M_Supplier]![Supplier_30Days]);");
			//Debtor Age shifting if Credit


			this.Cursor = System.Windows.Forms.Cursors.Default;

			//fix Server Path in Month End DBs
			ADODB.Recordset rsPOSList = default(ADODB.Recordset);
			string strSvrName = null;

			//Create a buffer
			strSvrName = new string(Strings.Chr(0), 255);
			//Get the computer name
			GetComputerName(strSvrName, ref 255);
			//remove the unnecessary chr$(0)'s
			strSvrName = Strings.Left(strSvrName, Strings.InStr(1, strSvrName, Strings.Chr(0)));
			strSvrName = Strings.Left(strSvrName, Strings.Len(strSvrName) - 1);
			//MsgBox strSvrName
			rsPOSList = modRecordSet.getRS(ref "SELECT * FROM POS;");
			if (rsPOSList.RecordCount > 1) {
				//if more then 1 POS
				//Set rsMonthList = getRS("SELECT MonthEndID FROM MonthEnd;")
				//If rsMonthList.RecordCount Then
				//    Do While rsMonthList.EOF = False
				//        databaseName = "Month" & rsMonthList("MonthEndID") & ".mdb"
				if (fso.FileExists(modRecordSet.serverPath + databaseName)) {
					buildPath1_Month(ref databaseName, ref strSvrName);
					System.Windows.Forms.Application.DoEvents();
					buildPath1_Month(ref databaseName, ref strSvrName);
				}

				//        rsMonthList.moveNext
				//    Loop
				//End If
			}
			//fix Server Path in Month End DBs

			//If rs("Company_OpenDebtor") = True Then
			//Else
			//    If MsgBox("Would you like to Enable 'OPEN DEBTOR' option from starting month?" & vbCrLf & vbCrLf & "NOTE: It is recommended to turn this option now if you wish to use." & vbCrLf & vbCrLf & "You can enable it later from 'Store Setup and Security -> General Parameters'.", vbYesNo) = vbYes Then
			//        sql = "UPDATE Company Set Company.Company_OpenDebtor = True;"
			//        cnnDB.Execute sql
			//    End If
			//End If

			//For Auto UpdatePOS on MonthEnd
			if (Interaction.MsgBox("You are requested to do UpdatePOS at this stage, to run some Reports." + Constants.vbCrLf + Constants.vbCrLf + "NOTE: If you have changed Prices for some items, UpdatePOS will update Terminals." + Constants.vbCrLf + Constants.vbCrLf + "If you want to Run UpdatePOS now select 'YES' or click 'NO' If you don't want to change the prices on terminals.", MsgBoxStyle.YesNo) == MsgBoxResult.Yes) {
				modApplication.blMEndUpdatePOS = true;
				My.MyProject.Forms.frmUpdatePOScriteria.ShowDialog();
			} else {
				modApplication.blMEndUpdatePOS = false;
			}
			modApplication.blMEndUpdatePOS = false;
		}

		private bool buildPath1_Month(ref string lPath, ref string lServerPath)
		{
			bool functionReturnValue = false;
			ADOX.Catalog cat = new ADOX.Catalog();
			ADOX.Table tbl = new ADOX.Table();
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Connection cn = default(ADODB.Connection);
			string lFile = null;
			string holdfile = null;
			short x = 0;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			string lDir = null;
			 // ERROR: Not supported in C#: OnErrorStatement

			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			//lPath = upgradePath
			System.Windows.Forms.Application.DoEvents();

			lDir = Strings.LCase("\\\\" + lServerPath + "\\C\\4posServer\\");

			cn = modRecordSet.openConnectionInstance(ref lPath);
			if (cn == null) {
			} else {
				cat.let_ActiveConnection(cn);
				foreach ( tbl in cat.Tables) {
					if (tbl.Type == "LINK") {
						System.Windows.Forms.Application.DoEvents();
						//lFile = tbl.Name
						if (tbl.Properties("Jet OLEDB:Link Datasource").Value != lDir + "pricing.mdb") {
							tbl.Properties("Jet OLEDB:Link Datasource").Value = Strings.Replace(Strings.LCase(tbl.Properties("Jet OLEDB:Link Datasource").Value), Strings.LCase("C:\\4posServer\\"), lDir);
						}
						//DoEvents
						//If tbl.Properties("Jet OLEDB:Link Datasource") <> lDIR & "pricing.mdb" Then
						//    tbl.Properties("Jet OLEDB:Link Datasource") = Replace(LCase(tbl.Properties("Jet OLEDB:Link Datasource")), LCase("C:\4posServer\"), lDIR)
						//End If
					}
				}
				//UPGRADE_NOTE: Object cat may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				cat = null;
				cn.Close();
				//UPGRADE_NOTE: Object cn may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
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

		private void cmdBack_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}
		private void cmdNext_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			switch (gMode) {
				case mdDayEnd:
					doMode(ref mdConfirm);
					break;
				case mdConfirm:
					doMode(ref mdComplete);
					break;
			}
		}
		private void frmMonthEnd_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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
		private void frmMonthEnd_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			Width = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(this.frmMode[0].Left, true) + sizeConvertors.pixelToTwips(frmMode[0].Width, true) + 250, true);
			Height = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(this.cmdBack.Top, false) + sizeConvertors.pixelToTwips(cmdBack.Height, false) + 250 + 240, false);
			frmMode.AddRange(new GroupBox[] {
				_frmMode_0,
				_frmMode_1,
				_frmMode_2,
				_frmMode_3
			});
			loadLanguage();
			doMode(ref mdDayEnd);
		}
	}
}
