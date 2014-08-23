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
	internal partial class frmDayEnd : System.Windows.Forms.Form
	{
		private const short MAX_PATH = 260;
		[DllImport("kernel32", EntryPoint = "GetWindowsDirectoryA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int GetWindowsDirectory(string lpBuffer, int nSize);
		[DllImport("kernel32", EntryPoint = "GetSystemDirectoryA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int GetSystemDirectory(string lpBuffer, int nSize);

		private struct PROCESS_INFORMATION
		{
			public int hProcess;
			public int hThread;
			public int dwProcessID;
			public int dwThreadID;
		}

		const short mdPricingGroup = 0;
		const short mdDepartment = 1;
		const short mdPackSize = 2;

		short gMode;
		short lCNT;

		const short mdPOS = 0;
		const short mdTransactions = 1;
		const short mdConfirm = 2;
		const short mdComplete = 3;
		const short mdSecurity = 4;
		List<GroupBox> frmMode = new List<GroupBox>();
		bool bolAutoDE_Error;

		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1261;
			//Day End Run|
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//Label3 = No Code           [Please Wait, Stock Update Progress...]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label3.Caption = rsLang("LanguageLayoutLnk_Description"): Label3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdBack.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdBack.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//NOTE: DB Entry 1005 doesn't have ">>" chars
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1005;
			//Next|Checked
			if (modRecordSet.rsLang.RecordCount){cmdNext.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdNext.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//frmMode(4) = No Code       [Demo Version Notification]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmMode(4).Caption = rsLang("LanguageLayoutLnk_Description"): frmMode(4).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblText = No Code          [The 4POS Application........]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblText.Caption = rsLang("LanguageLayoutLnk_Description"): lblText.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblDemo = No Code
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then COMPONENT(0).Caption = rsLang("LanguageLayoutLnk_Description"): COMPONENT(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//frmMode(0) = No Code       [No Cashup Declarations]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmMode(0).Caption = rsLang("LanguageLayoutLnk_Description"): frmMode(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1(0) = No Code         [The Following Point of Sales devices have not been declared]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label(0).Caption = rsLang("LanguageLayoutLnk_Description"): Label(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1(3) = No Code         [All active]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label(3).Caption = rsLang("LanguageLayoutLnk_Description"): Label(3).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//frmMode(2) = No Code       [Confirm Day End Run]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmMode(2).Caption = rsLang("LanguageLayoutLnk_Description"): frmMode(2).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1(1) = No Code        [Use the date selector to select the correct date for your day end.]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(1).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1(2) = No Code        [As part of the "Day End" run, the integrity of your database will be checked and a backup made.]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(2).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(2).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label2 = No Code           [Please ensure that there are no other users using the system before pressing the "Next" button!]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label2.Caption = rsLang("LanguageLayoutLnk_Description"): Label2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//frmMode(1) = No Code       [No POS Transactions]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmMode(1).Caption = rsLang("LanguageLayoutLnk_Description"): frmMode(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1(5) = No Code        [There have been no Point of Sale transaction since the last Day end procedure was run]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(5).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(5).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1(4) = No Code        [There is no need to run your Day end Procedure.]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(4).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(4).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//frmMode(3) = No Code       [Day End Run Complete]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmMode(3).Caption = rsLang("LanguageLayoutLnk_Description"): frmMode(3).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmDayEnd.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void doMode(ref short mode)
		{
			string strFldName = null;
			string st1 = null;
			 // ERROR: Not supported in C#: OnErrorStatement


			int gParameters = 0;
			bool bHOAutoUpload = false;

			ADODB.Recordset rsBit = default(ADODB.Recordset);
			ADODB.Recordset rs = default(ADODB.Recordset);
			gMode = mode;

			int x = 0;
			int gMonth = 0;
			int dayStart = 0;
			int dayEnd = 0;
			string sql = null;

			string errDesc = null;

			const short gParPastelReport = 128;
			//Pastel CSV's
			const short gCopySalesToHQ = 1024;
			//Sales to HQ
			const short gZeroStock_DayEnd = 4096;


			for (x = 0; x <= frmMode.Count - 1; x++) {
				frmMode[x].Visible = false;
			}

			frmMode[gMode].Left = frmMode[0].Left;
			frmMode[gMode].Top = frmMode[0].Top;
			frmMode[gMode].Visible = true;

			errDesc = "Starting Point";

			ADODB.Connection cn = new ADODB.Connection();
			bool bDCChk = false;
			ADODB.Recordset rsDCChk = default(ADODB.Recordset);
			ADODB.Recordset rsRep = default(ADODB.Recordset);
			ADODB.Recordset rsHO = default(ADODB.Recordset);
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			Scripting.TextStream lTextstream = default(Scripting.TextStream);
			string lString = null;
			//Dim Report As New cryOpenTable
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryOpenTable");
			switch (gMode) {
				case mdPOS:
					errDesc = "mdPOS Point";

					//Check for open table...
					cn = modRecordSet.openConnectionInstance(ref "waitron.mdb");
					if (cn == null) {
						Interaction.MsgBox("The Day End cannot be successfully executed as the Waitron Database is unable to connect to the 4POS BackOffice server." + Constants.vbCrLf + "Please ensure that the database is at correct location." + Constants.vbCrLf + Constants.vbCrLf + "If this error persists please contact the '4POS' representative.", MsgBoxStyle.Critical, "Server Off-line");
						return;
					}

					//Clear WaitronTable
					cn.Execute("DELETE * FROM WaitronTable;");

					//Dry Cleaning Customer Check
					bDCChk = false;
					rsDCChk = modRecordSet.getRS(ref "SELECT * FROM Company;");
					if (rsDCChk.RecordCount) {
						if (rsDCChk.Fields.Count >= 60) {
							if (rsDCChk.Fields("Company_DCCustomer").Value) {
								bDCChk = true;
							}
						}
					}
					//Dry Cleaning Customer Check

					rs = modRecordSet.getRSwaitron(ref "SELECT * FROM OpenTable", ref cn);
					if (rs.RecordCount > 0 & bDCChk == false) {
						st1 = "You cannot do Day End now, because there are still some Open Table" + Constants.vbCrLf + Constants.vbCrLf;
						// on this machine
						st1 = st1 + "Make sure all Waitron's had cashout to all their table(s)" + Constants.vbCrLf + Constants.vbCrLf;
						st1 = st1 + "Click OK to see table(s) list";
						Interaction.MsgBox(st1, MsgBoxStyle.Exclamation, "Day End Warning");

						//Dim sql As String

						System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
						rsRep = modRecordSet.getRS(ref "SELECT * FROM Company");
						//Report.txtCompanyName.SetText rsRep("Company_Name")
						rsRep.Close();

						sql = "SELECT OpenTable.OpenTable_TableID, OpenTable.OpenTable_WaitronID, OpenTable.OpenTable_Text, OpenTable.OpenTable_Date, OpenTable.OpenTable_GuestCount, TableTranactionItem.TableTranactionItem_lineNo, TableTranactionItem.TableTranactionItem_name, TableTranactionItem.TableTranactionItem_quantity, TableTranactionItem.TableTranactionItem_price, Person.Person_FirstName, Person.Person_LastName ";
						sql = sql + "FROM (OpenTable OpenTable INNER JOIN Person Person ON OpenTable.OpenTable_WaitronID = Person.PersonID) INNER JOIN TableTranactionItem TableTranactionItem ON OpenTable.OpenTable_TableID = TableTranactionItem.TableTranactionItem_TableID ORDER BY OpenTable.OpenTable_TableID ASC;";

						rsRep = modRecordSet.getRSwaitron(ref sql, ref cn);

						//If rs.BOF Or rs.EOF Then
						//    ReportNone.Load("cryNoRecords.rpt")
						//    ReportNone.txtCompanyName.SetText Report.txtCompanyName.Text
						//    ReportNone.txtTitle.SetText Report.txtTitle.Text
						//    frmReportShow.caption = ReportNone.txtTitle.Text
						//    frmReportShow.CRViewer1.ReportSource = ReportNone
						//    Set frmReportShow.mReport = ReportNone: frmReportShow.sMode = "0"
						//    frmReportShow.CRViewer1.ViewReport
						//    Screen.MousePointer = vbDefault
						//    frmReportShow.Show 1
						//    Exit Sub
						//End If

						Report.Database.Tables(0).SetDataSource(rsRep);
						//UPGRADE_WARNING: Couldn't resolve default property of object Report.VerifyOnEveryPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//Report.VerifyOnEveryPrint = True
						//frmReportShow.caption = Report.txtTitle.Text
						My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
						My.MyProject.Forms.frmReportShow.mReport = Report;
						My.MyProject.Forms.frmReportShow.sMode = "0";
						My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
						System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
						My.MyProject.Forms.frmReportShow.ShowDialog();

						System.Windows.Forms.Application.DoEvents();

						this.cmdNext.Enabled = false;
						frmMode[0].Visible = false;
						return;

					} else {
						//if there is no record
						if (bDCChk == false) {
							//delete OpenTable
							cn.Execute("DELETE * FROM OpenTable;");
							cn.Execute("DROP TABLE OpenTable;");
							//create OpenTable
							strFldName = "OpenTable_WaitronID Number NOT NULL, ";
							strFldName = strFldName + "OpenTable_TableID Number NOT NULL, ";
							strFldName = strFldName + "OpenTable_Text Text(50), ";
							strFldName = strFldName + "OpenTable_X Number, ";
							strFldName = strFldName + "OpenTable_Y Number, ";
							strFldName = strFldName + "OpenTable_Date DateTime, ";
							strFldName = strFldName + "OpenTable_Complete YesNo, ";
							strFldName = strFldName + "OpenTable_GuestCount Number, ";
							strFldName = strFldName + "OpenTable_Delivery YesNo, ";
							strFldName = strFldName + "OpenTable_TelNumber Text(50), ";
							strFldName = strFldName + "OpenTable_ID AUTOINCREMENT, ";
							strFldName = strFldName + "OpenTable_Discount Currency, ";
							strFldName = strFldName + "OpenTable_DiscountReason Text(50), ";
							strFldName = strFldName + "OpenTable_VoidReason Text(50), ";
							strFldName = strFldName + "OpenTable_FLTableID Number, ";
							strFldName = strFldName + "OpenTable_Printed YesNo";
							Debug.Print(strFldName);
							cn.Execute("CREATE TABLE OpenTable (" + strFldName + ")");
							System.Windows.Forms.Application.DoEvents();
						}
					}
					//Check for open table...

					rs = modRecordSet.getRS(ref "SELECT DISTINCT TOP 100 PERCENT POS.POSID, POS.POS_Name FROM POS INNER JOIN Sale ON POS.POSID = Sale.Sale_PosID AND POS.POS_DeclarationID = Sale.Sale_DeclarationID Where (POS.POS_Disabled = 0) ORDER BY POS.POS_Name");
					this.lstPOS.Items.Clear();
					while (!(rs.EOF)) {
						lstPOS.Items.Add(new LBI(rs.Fields("POS_Name").Value, rs.Fields("POSID").Value));
						rs.MoveNext();
					}
					if (lstPOS.Items.Count) {
						lstPOS.SelectedIndex = -1;
						lstPOS.Visible = true;
						this.cmdNext.Enabled = false;
					} else {
						doMode(ref mdTransactions);
					}

					break;
				case mdTransactions:
					errDesc = "mdTransactions Point";
					rs = modRecordSet.getRS(ref "SELECT Count(Sale.SaleID) AS CountOfSaleID FROM Sale INNER JOIN Company ON Sale.Sale_DayEndID = Company.Company_DayEndID;");
					if (rs.BOF | rs.EOF) {
						this.cmdNext.Enabled = false;
					} else {
						if (rs.Fields(0).Value == 0) {
							this.cmdNext.Enabled = false;
						} else {
							doMode(ref mdConfirm);
						}
					}

					break;
				case mdConfirm:
					calDayEnd.SetDate(DateAndTime.Now);
					if (DateAndTime.Hour(DateAndTime.TimeOfDay) < 12) {
						calDayEnd.SetDate(System.DateTime.FromOADate(DateAndTime.Today.ToOADate() - 1));
					}

					if (modApplication.bolAutoDE == true) {
						if (bolAutoDE_Error == false) {
							doMode(ref mdComplete);
						} else {
							this.cmdNext.Enabled = true;
						}
					} else {
						this.cmdNext.Enabled = true;
					}
					break;
				case mdComplete:
					errDesc = "mdComplete Point";
					rsBit = modRecordSet.getRS(ref "SELECT * FROM Company");
					gParameters = Convert.ToInt32(0 + rsBit.Fields("Company_DayEndBit").Value);

					bHOAutoUpload = (Information.IsDBNull(rsBit.Fields("Company_HOLink").Value) ? false : rsBit.Fields("Company_HOLink").Value);

					if (modApplication.bolAutoDE == true) {
					} else {
						if (gParameters & gParPastelReport) {
							My.MyProject.Forms.frmMenu.Automaticload();
							modBResolutions.blpastel = true;
							modApplication.report_VATPASTEL();
							modApplication.ExportToCSVFile();
						}
					}

					rs = modRecordSet.getRS(ref "SELECT DayEnd_Date FROM DayEnd ORDER BY DayEnd_Date DESC;");
					if (rs.RecordCount > 1) {
						rs.MoveNext();
						if (DateAndTime.DateSerial(DateAndTime.Year(calDayEnd.SelectionStart), DateAndTime.Month(calDayEnd.SelectionStart), DateAndTime.Day(calDayEnd.SelectionStart)) <= rs.Fields(0).Value) {
							Interaction.MsgBox("You may not do a day end run for a previous day!" + Constants.vbCrLf + Constants.vbCrLf + "The last day end run was on the " + Strings.Format(rs.Fields(0).Value, "ddd, dd-mmm-yyyy") + "!", MsgBoxStyle.Exclamation, "DAYEND RUN");
							bolAutoDE_Error = true;
							doMode(ref mdConfirm);
							return;
						}
					}

					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					modApplication.modUpdate = 1;

					modApplication.updateStockMovement();

					errDesc = "After updateStockMovement Point";

					//Multi Warehouse change     cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN (Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2) AND (([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]+[DayEndStockItemLnk_QuantityShrink]-[DayEndStockItemLnk_QuantityGRV])<>[WarehouseStockItemLnk_Quantity]));"
					//Tranfer change             cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN (Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AND WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID = DayEndStockItemLnk.DayEndStockItemLnk_Warehouse SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2) AND (([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]+[DayEndStockItemLnk_QuantityShrink]-[DayEndStockItemLnk_QuantityGRV])<>[WarehouseStockItemLnk_Quantity]));"
					modRecordSet.cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN (Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AND WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID = DayEndStockItemLnk.DayEndStockItemLnk_Warehouse SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV]+[DayEndStockItemLnk_QuantityTransafer] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2) AND (([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]+[DayEndStockItemLnk_QuantityShrink]-[DayEndStockItemLnk_QuantityGRV]-[DayEndStockItemLnk_QuantityTransafer])<>[WarehouseStockItemLnk_Quantity]));");

					sql = "INSERT INTO StockitemHistory ( StockitemHistory_StockItemID, StockitemHistory_Value, StockitemHistory_Day1, StockitemHistory_Day2, StockitemHistory_Day3, StockitemHistory_Day4, StockitemHistory_Day5, StockitemHistory_Day6, StockitemHistory_Day7, StockitemHistory_Day8, StockitemHistory_Day9, StockitemHistory_Day10, StockitemHistory_Day11, StockitemHistory_Day12, StockitemHistory_Week1, StockitemHistory_Week2, StockitemHistory_Week3, StockitemHistory_Week4, StockitemHistory_Week5, StockitemHistory_Week6, StockitemHistory_Week7, StockitemHistory_Week8, StockitemHistory_Week9, StockitemHistory_Week11, StockitemHistory_Month1, StockitemHistory_Month2, StockitemHistory_Month3, StockitemHistory_Month4, StockitemHistory_Month5, StockitemHistory_Month6, StockitemHistory_Month7, StockitemHistory_Month8, StockitemHistory_Month9, StockitemHistory_Month10, StockitemHistory_Month11, StockitemHistory_Month12 ) ";
					sql = sql + "SELECT StockItem.StockItemID, 0 AS Expr2, 0 AS Expr3, 0 AS Expr4, 0 AS Expr5, 0 AS Expr6, 0 AS Expr7, 0 AS Expr8, 0 AS Expr9, 0 AS Expr10, 0 AS Expr11, 0 AS Expr12, 0 AS Expr13, 0 AS Expr14, 0 AS Expr15, 0 AS Expr16, 0 AS Expr17, 0 AS Expr18, 0 AS Expr19, 0 AS Expr20, 0 AS Expr21, 0 AS Expr22, 0 AS Expr23, 0 AS Expr24, 0 AS Expr25, 0 AS Expr26, 0 AS Expr27, 0 AS Expr28, 0 AS Expr29, 0 AS Expr30, 0 AS Expr31, 0 AS Expr32, 0 AS Expr33, 0 AS Expr34, 0 AS Expr35, 0 AS Expr1 FROM StockItem LEFT JOIN StockitemHistory ON StockItem.StockItemID = StockitemHistory.StockitemHistory_StockItemID WHERE (((StockitemHistory.StockitemHistory_StockItemID) Is Null));";
					modRecordSet.cnnDB.Execute(sql);

					//add temporary table for StockitemHistory
					ChkStockitemHistoryTable();
					System.Windows.Forms.Application.DoEvents();
					sql = "INSERT INTO StockitemHistory777 ( StockItemID, QuantitySales ) ";
					sql = sql + "SELECT DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales) AS Exp1 FROM Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID;";
					modRecordSet.cnnDB.Execute(sql);
					//add temporary table for StockitemHistory
					System.DateTime dated = default(System.DateTime);
					dated = calDayEnd.SelectionRange.Start;
					//cnnDB.Execute "UPDATE Company INNER JOIN (StockitemHistory INNER JOIN DayEndStockItemLnk ON StockitemHistory.StockitemHistory_StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID SET StockitemHistory.StockitemHistory_Day1 = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantitySales];"
					modRecordSet.cnnDB.Execute("UPDATE StockitemHistory INNER JOIN StockitemHistory777 ON StockitemHistory.StockitemHistory_StockItemID = StockitemHistory777.StockItemID SET StockitemHistory.StockitemHistory_Day1 = [StockitemHistory777]![QuantitySales];");
					//cnnDB.Execute "UPDATE Company INNER JOIN (StockitemHistory INNER JOIN DayEndStockItemLnk ON StockitemHistory.StockitemHistory_StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID SET StockitemHistory.StockitemHistory_Week1 = [StockitemHistory]![StockitemHistory_Week1]+[DayEndStockItemLnk]![DayEndStockItemLnk_QuantitySales];"
					modRecordSet.cnnDB.Execute("UPDATE StockitemHistory INNER JOIN StockitemHistory777 ON StockitemHistory.StockitemHistory_StockItemID = StockitemHistory777.StockItemID SET StockitemHistory.StockitemHistory_Week1 = [StockitemHistory]![StockitemHistory_Week1]+[StockitemHistory777]![QuantitySales];");
					//cnnDB.Execute "UPDATE Company INNER JOIN (StockitemHistory INNER JOIN DayEndStockItemLnk ON StockitemHistory.StockitemHistory_StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID SET StockitemHistory.StockitemHistory_Month1 = [StockitemHistory]![StockitemHistory_Month1]+[DayEndStockItemLnk]![DayEndStockItemLnk_QuantitySales];"
					modRecordSet.cnnDB.Execute("UPDATE StockitemHistory INNER JOIN StockitemHistory777 ON StockitemHistory.StockitemHistory_StockItemID = StockitemHistory777.StockItemID SET StockitemHistory.StockitemHistory_Month1 = [StockitemHistory]![StockitemHistory_Month1]+[StockitemHistory777]![QuantitySales];");
					sql = "UPDATE StockitemHistory SET StockitemHistory.StockitemHistory_Day12 = [StockitemHistory]![StockitemHistory_Day11], StockitemHistory.StockitemHistory_Day11 = [StockitemHistory]![StockitemHistory_Day10], StockitemHistory.StockitemHistory_Day10 = [StockitemHistory]![StockitemHistory_Day9], StockitemHistory.StockitemHistory_Day9 = [StockitemHistory]![StockitemHistory_Day8], StockitemHistory.StockitemHistory_Day8 = [StockitemHistory]![StockitemHistory_Day7], StockitemHistory.StockitemHistory_Day7 = [StockitemHistory]![StockitemHistory_Day6], StockitemHistory.StockitemHistory_Day6 = [StockitemHistory]![StockitemHistory_Day5], StockitemHistory.StockitemHistory_Day5 = [StockitemHistory]![StockitemHistory_Day4], ";
					sql = sql + "StockitemHistory.StockitemHistory_Day4 = [StockitemHistory]![StockitemHistory_Day3], StockitemHistory.StockitemHistory_Day3 = [StockitemHistory]![StockitemHistory_Day2], StockitemHistory.StockitemHistory_Day2 = [StockitemHistory]![StockitemHistory_Day1], StockitemHistory.StockitemHistory_Day1 = 0;";
					modRecordSet.cnnDB.Execute(sql);

					modRecordSet.cnnDB.Execute("UPDATE (Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN StockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = StockItem.StockItemID SET DayEndStockItemLnk.DayEndStockItemLnk_ListCost = [StockItem]![StockItem_ListCost]/[StockItem]![StockItem_Quantity], DayEndStockItemLnk.DayEndStockItemLnk_ActualCost = [StockItem]![StockItem_ActualCost]/[StockItem]![StockItem_Quantity];");
					modRecordSet.cnnDB.Execute("INSERT INTO DayEnd ( DayEndID, DayEnd_MonthEndID, DayEnd_Date ) SELECT Company.Company_DayEndID, Company.Company_MonthEndID, #" + dated.Month + "# FROM Company LEFT JOIN DayEnd ON Company.Company_DayEndID = DayEnd.DayEndID WHERE (((DayEnd.DayEndID) Is Null));");
					modRecordSet.cnnDB.Execute("UPDATE Company INNER JOIN DayEnd ON Company.Company_DayEndID = DayEnd.DayEndID SET DayEnd.DayEnd_MonthEndID = [Company]![Company_MonthEndID], DayEnd.DayEnd_Date = #" + dated.Day + "#;");
					modRecordSet.cnnDB.Execute("UPDATE Company SET Company.Company_DayEndID = [Company]![Company_DayEndID]+1;");
					if (Strings.LCase(Strings.Format(this.calDayEnd.SelectionRange.Start.Day + 1, "ddd")) == "sun") {
						//If LCase(Format(System.DateTime.FromOADate(dated.ToOADate + 1)), "ddd", 1, FirstWeekOfYear.FirstFullWeek) = "sun" Then
						modRecordSet.cnnDB.Execute("INSERT INTO DayEnd ( DayEndID, DayEnd_MonthEndID, DayEnd_Date ) SELECT Company.Company_DayEndID, Company.Company_MonthEndID, #" + System.DateTime.FromOADate(dated.ToOADate() + 1) + "# FROM Company LEFT JOIN DayEnd ON Company.Company_DayEndID = DayEnd.DayEndID WHERE (((DayEnd.DayEndID) Is Null));");
						sql = "UPDATE StockitemHistory SET StockitemHistory.StockitemHistory_Week12 = [StockitemHistory]![StockitemHistory_Week11], StockitemHistory.StockitemHistory_Week11 = [StockitemHistory]![StockitemHistory_Week10], StockitemHistory.StockitemHistory_Week10 = [StockitemHistory]![StockitemHistory_Week9], StockitemHistory.StockitemHistory_Week9 = [StockitemHistory]![StockitemHistory_Week8], StockitemHistory.StockitemHistory_Week8 = [StockitemHistory]![StockitemHistory_Week7], StockitemHistory.StockitemHistory_Week7 = [StockitemHistory]![StockitemHistory_Week6], StockitemHistory.StockitemHistory_Week6 = [StockitemHistory]![StockitemHistory_Week5], StockitemHistory.StockitemHistory_Week5 = [StockitemHistory]![StockitemHistory_Week4], ";
						sql = sql + "StockitemHistory.StockitemHistory_Week4 = [StockitemHistory]![StockitemHistory_Week3], StockitemHistory.StockitemHistory_Week3 = [StockitemHistory]![StockitemHistory_Week2], StockitemHistory.StockitemHistory_Week2 = [StockitemHistory]![StockitemHistory_Week1], StockitemHistory.StockitemHistory_Week1 = 0;";
						modRecordSet.cnnDB.Execute(sql);
					} else {
						modRecordSet.cnnDB.Execute("INSERT INTO DayEnd ( DayEndID, DayEnd_MonthEndID, DayEnd_Date ) SELECT Company.Company_DayEndID, Company.Company_MonthEndID, #" + System.DateTime.FromOADate(dated.ToOADate() + 1) + "# FROM Company LEFT JOIN DayEnd ON Company.Company_DayEndID = DayEnd.DayEndID WHERE (((DayEnd.DayEndID) Is Null));");
					}
					//delete from dayendstocklink AND dayend depositlink   for that dayend
					rs = modRecordSet.getRS(ref "SELECT Company_DayEndID FROM Company;");
					if (rs.RecordCount > 1) {
						modRecordSet.cnnDB.Execute("DELETE * FROM DayEndStockItemLnk WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)=" + rs.Fields("Company_DayEndID").Value + "));");
						modRecordSet.cnnDB.Execute("DELETE * FROM DayEndDepositItemLnk WHERE (((DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID)=" + rs.Fields("Company_DayEndID").Value + "));");
					}


					//On Local Error Resume Next
					//Multi Warehouse change    cnnDB.Execute "INSERT INTO DayEndStockItemLnk ( DayEndStockItemLnk_DayEndID, DayEndStockItemLnk_StockItemID, DayEndStockItemLnk_Quantity, DayEndStockItemLnk_QuantitySales, DayEndStockItemLnk_QuantityShrink, DayEndStockItemLnk_QuantityGRV, DayEndStockItemLnk_ListCost, DayEndStockItemLnk_ActualCost ) SELECT Company.Company_DayEndID, StockItem.StockItemID, 0 AS Expr1, 0 AS Expr2, 0 AS Expr3, 0 AS Expr4, [StockItem]![StockItem_ListCost]/[StockItem]![StockItem_Quantity], [StockItem]![StockItem_ActualCost]/[StockItem]![StockItem_Quantity] FROM Company, StockItem;"
					modRecordSet.cnnDB.Execute("INSERT INTO DayEndStockItemLnk ( DayEndStockItemLnk_DayEndID, DayEndStockItemLnk_StockItemID, DayEndStockItemLnk_Quantity, DayEndStockItemLnk_QuantitySales, DayEndStockItemLnk_QuantityShrink, DayEndStockItemLnk_QuantityGRV, DayEndStockItemLnk_ListCost, DayEndStockItemLnk_ActualCost, DayEndStockItemLnk_Warehouse ) SELECT Company.Company_DayEndID, StockItem.StockItemID, 0 AS Expr1, 0 AS Expr2, 0 AS Expr3, 0 AS Expr4, [StockItem]![StockItem_ListCost]/[StockItem]![StockItem_Quantity], [StockItem]![StockItem_ActualCost]/[StockItem]![StockItem_Quantity], Warehouse.WarehouseID FROM Company, StockItem, Warehouse;");
					//On Local Error GoTo 0
					//Multi Warehouse change     cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN (DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID) ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID SET DayEndStockItemLnk.DayEndStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=1 Or (WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));"
					modRecordSet.cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN (DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID) ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AND WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID = DayEndStockItemLnk.DayEndStockItemLnk_Warehouse SET DayEndStockItemLnk.DayEndStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=1 Or (WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));");
					sql = "INSERT INTO DayEndDepositItemLnk ( DayEndDepositItemLnk_DayEndID, DayEndDeposittemLnk_DepositID, DayEndDeposittemLnk_DepositType, DayEndDepositItemLnk_Quantity, DayEndDepositItemLnk_QuantitySales, DayEndDepositItemLnk_QuantityShrink, DayEndDepositItemLnk_QuantityGRV, DayEndDepositItemLnk_UnitCost, DayEndDepositItemLnk_CaseCost, DayEndDepositItemLnk_CaseQuantity ) SELECT DISPLAY_DepositDayEnd.Company_DayEndID, DISPLAY_DepositDayEnd.DepositID, DISPLAY_DepositDayEnd.type, 0, 0, 0, 0, Deposit.Deposit_UnitCost, Deposit.Deposit_CaseCost, Deposit.Deposit_Quantity FROM DayEndDepositItemLnk RIGHT JOIN (Deposit INNER JOIN DISPLAY_DepositDayEnd ON Deposit.DepositID = DISPLAY_DepositDayEnd.DepositID) ON (DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType = DISPLAY_DepositDayEnd.type) AND (DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = DISPLAY_DepositDayEnd.DepositID) AND (DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID = DISPLAY_DepositDayEnd.Company_DayEndID) ";
					sql = sql + "WHERE (((DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) Is Null));";
					modRecordSet.cnnDB.Execute(sql);

					errDesc = "Middle Point";

					rs = modRecordSet.getRS(ref "SELECT [Company_DayEndID]-1 AS theDayend FROM Company;");
					rs = modRecordSet.getRS(ref "SELECT Min(DayEnd.DayEndID) AS minDay, Max(DayEnd_1.DayEndID) AS MaxDay FROM (Company INNER JOIN DayEnd AS DayEnd_1 ON Company.Company_MonthEndID = DayEnd_1.DayEnd_MonthEndID) INNER JOIN DayEnd ON Company.Company_MonthEndID = DayEnd.DayEnd_MonthEndID;");
					dayStart = rs.Fields("minDay").Value;
					dayEnd = rs.Fields("MaxDay").Value;
					rs.Close();

					modRecordSet.cnnDB.Execute("UPDATE DayEndStockItemLnk SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV = 0;");
					modRecordSet.cnnDB.Execute("UPDATE (DayEndStockItemLnk INNER JOIN GRVItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = GRVItem.GRVItem_StockItemID) INNER JOIN GRV ON (DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = GRV.GRV_DayEndID) AND (GRVItem.GRVItem_GRVID = GRV.GRVID) SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV = [DayEndStockItemLnk_QuantityGRV]+IIf([GRVItem]![GRVItem_Return],0-[GRVItem_PackSize]*[GRVItem_Quantity],[GRVItem_PackSize]*[GRVItem_Quantity]) WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=2) AND ((GRV.GRV_GRVStatusID)=3));");

					for (x = dayStart; x <= dayEnd; x++) {
						//Multi Warehouse change     cnnDB.Execute "UPDATE DayEndStockItemLnk AS dayEndToday INNER JOIN DayEndStockItemLnk AS Tomarrow ON dayEndToday.DayEndStockItemLnk_StockItemID = Tomarrow.DayEndStockItemLnk_StockItemID SET Tomarrow.DayEndStockItemLnk_Quantity = [dayEndToday]![DayEndStockItemLnk_Quantity]-[dayEndToday]![DayEndStockItemLnk_QuantitySales]-[dayEndToday]![DayEndStockItemLnk_QuantityShrink]+[dayEndToday]![DayEndStockItemLnk_QuantityGRV] WHERE (((dayEndToday.DayEndStockItemLnk_DayEndID)=" & x & ") AND ((Tomarrow.DayEndStockItemLnk_DayEndID)=[dayendtoday]![DayEndStockItemLnk_DayEndID]+1));"
						//Tranfer change             cnnDB.Execute "UPDATE DayEndStockItemLnk AS dayEndToday INNER JOIN DayEndStockItemLnk AS Tomarrow ON dayEndToday.DayEndStockItemLnk_StockItemID = Tomarrow.DayEndStockItemLnk_StockItemID AND dayEndToday.DayEndStockItemLnk_Warehouse = Tomarrow.DayEndStockItemLnk_Warehouse SET Tomarrow.DayEndStockItemLnk_Quantity = [dayEndToday]![DayEndStockItemLnk_Quantity]-[dayEndToday]![DayEndStockItemLnk_QuantitySales]-[dayEndToday]![DayEndStockItemLnk_QuantityShrink]+[dayEndToday]![DayEndStockItemLnk_QuantityGRV] WHERE (((dayEndToday.DayEndStockItemLnk_DayEndID)=" & x & ") AND ((Tomarrow.DayEndStockItemLnk_DayEndID)=[dayendtoday]![DayEndStockItemLnk_DayEndID]+1));"
						modRecordSet.cnnDB.Execute("UPDATE DayEndStockItemLnk AS dayEndToday INNER JOIN DayEndStockItemLnk AS Tomarrow ON dayEndToday.DayEndStockItemLnk_StockItemID = Tomarrow.DayEndStockItemLnk_StockItemID AND dayEndToday.DayEndStockItemLnk_Warehouse = Tomarrow.DayEndStockItemLnk_Warehouse SET Tomarrow.DayEndStockItemLnk_Quantity = [dayEndToday]![DayEndStockItemLnk_Quantity]-[dayEndToday]![DayEndStockItemLnk_QuantitySales]-[dayEndToday]![DayEndStockItemLnk_QuantityShrink]+[dayEndToday]![DayEndStockItemLnk_QuantityGRV]+[dayEndToday]![DayEndStockItemLnk_QuantityTransafer] WHERE (((dayEndToday.DayEndStockItemLnk_DayEndID)=" + x + ") AND ((Tomarrow.DayEndStockItemLnk_DayEndID)=[dayendtoday]![DayEndStockItemLnk_DayEndID]+1));");
					}


					//Multi Warehouse change     cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN (Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2) AND (([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]+[DayEndStockItemLnk_QuantityShrink]-[DayEndStockItemLnk_QuantityGRV])<>[WarehouseStockItemLnk_Quantity]));"
					//Tranfer change             cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN (Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AND WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID = DayEndStockItemLnk.DayEndStockItemLnk_Warehouse SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2) AND (([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]+[DayEndStockItemLnk_QuantityShrink]-[DayEndStockItemLnk_QuantityGRV])<>[WarehouseStockItemLnk_Quantity]));"
					modRecordSet.cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN (Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AND WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID = DayEndStockItemLnk.DayEndStockItemLnk_Warehouse SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV]+[DayEndStockItemLnk_QuantityTransafer] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)>1) AND (([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]+[DayEndStockItemLnk_QuantityShrink]-[DayEndStockItemLnk_QuantityGRV]-[DayEndStockItemLnk_QuantityTransafer])<>[WarehouseStockItemLnk_Quantity]));");
					modRecordSet.cnnDB.Execute("UPDATE (DayEndDepositItemLnk AS DayEndDepositItemLnk_1 INNER JOIN Company ON DayEndDepositItemLnk_1.DayEndDepositItemLnk_DayEndID = Company.Company_DayEndID) INNER JOIN DayEndDepositItemLnk ON (DayEndDepositItemLnk_1.DayEndDeposittemLnk_DepositID = DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID) AND (DayEndDepositItemLnk_1.DayEndDeposittemLnk_DepositType = DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType) SET DayEndDepositItemLnk_1.DayEndDepositItemLnk_Quantity = [DayEndDepositItemLnk!DayEndDepositItemLnk_Quantity]+[DayEndDepositItemLnk!DayEndDepositItemLnk_QuantityShrink]-[DayEndDepositItemLnk!DayEndDepositItemLnk_QuantitySales]+[DayEndDepositItemLnk!DayEndDepositItemLnk_QuantityGRV] WHERE (((DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID)=[Company_DayEndID]-1));");

					//clear Make finish check for sale qty
					modRecordSet.cnnDB.Execute("UPDATE StockItem SET StockItem.StockItem_MakeFinishItem = 0 WHERE StockItemID > 0;");

					if (modApplication.bolAutoDE == true) {
					} else {
						modApplication.loadDayEndReport(dayEnd - 1);
					}
					this.cmdNext.Visible = false;
					System.Windows.Forms.Application.DoEvents();

					//blMontheEnd = False
					errDesc = "End Point";
					//On Local Error Resume Next  'Prevent crushes for month End
					if (gParameters & gCopySalesToHQ) {
						//Do Collect Sales....
						modEmails.CollectSalesHQ();

					} else {
						//autoupload report
						//get HO info
						rsHO = modRecordSet.getRS(ref "Select Comp_ID FROM CompanyEmails;");
						if (rsHO.RecordCount > 0) {
							//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
							if (Information.IsDBNull(rsHO.Fields("Comp_ID").Value)) {
							} else {
								if (rsHO.Fields("Comp_ID").Value == 0) {
									if (bHOAutoUpload) {
										cmdHO_Click();
									}
								}
							}
						}
					}

					System.Windows.Forms.Application.DoEvents();
					cmdPrintSlip_Click();
					System.Windows.Forms.Application.DoEvents();

					if (gParameters & gZeroStock_DayEnd) {
						System.Windows.Forms.Application.DoEvents();
						Label3.Text = "Please Wait, Reseting Stock to Zero...";
						Label3.Visible = true;
						modApplication.EmulateSnapShot();
						System.Windows.Forms.Application.DoEvents();
						System.Windows.Forms.Application.DoEvents();
						Label3.Text = "Reseting Stock Complete...";
					}

					this.Cursor = System.Windows.Forms.Cursors.Default;
					if (DateAndTime.Day(System.DateTime.FromOADate(calDayEnd.SelectionStart.ToOADate() + 1)) == 1) {
						switch (Interaction.MsgBox("This is the last day of the month!" + Constants.vbCrLf + Constants.vbCrLf + "Do you want to do the Month End Now?", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, "Month End Run")) {
							case MsgBoxResult.Yes:
								//blMontheEnd = True
								My.MyProject.Forms.frmMonthEnd.ShowDialog();
								break;
						}
					}

					if (modApplication.bolAutoDE == true) {
						lString = modRecordSet.serverPath + "data\\4POSInterface\\4POSAUTODEDONE.txt";
						if (fso.FileExists(lString))
							fso.DeleteFile(lString, true);
						lTextstream = fso.OpenTextFile(lString, Scripting.IOMode.ForWriting, true);
						lTextstream.Write("DONE");
						lTextstream.Close();
						System.Environment.Exit(0);
						//Unload Me
					}
					break;
			}

			return;
			ErrHandlerr:
			Interaction.MsgBox("Error while DayEnd on " + errDesc + " : " + Err().Number + " : " + Err().Description + " : " + Err().Source);
			 // ERROR: Not supported in C#: ResumeStatement

		}

		private void cmdHO_Click()
		{
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();

			//Set variables
			Module1.bActiveSession = false;
			Module1.hOpen = 0;
			Module1.hConnection = 0;
			Module1.dwType = Module1.FTP_TRANSFER_TYPE_BINARY;
			Module1.prgCol = "4POS-HQ_";
			Module1.NomeFileLog = Module1.prgCol + Convert.ToString(Strings.Format(DateAndTime.Now, "ddmmyyyy")) + Convert.ToString(Strings.Format(DateAndTime.Now, "hhmm")) + ".log";

			//Check for Zipit file
			if (!string.IsNullOrEmpty(GetSystemPath())) {
				if (fso.FileExists(GetSystemPath() + "\\zipit.dll")) {
				} else {
					Interaction.MsgBox("Install headoffice first.");
					return;
				}
			}

			if (Strings.LCase(Strings.Left(modRecordSet.serverPath, 3)) != "c:\\") {
				Interaction.MsgBox("4POS HeadOffice Sync Engine must be run on the server", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine");
				return;
			}
			string ServerN = null;
			string sqlLinkPath = null;
			ServerN = "http://www.4pos.co.za/4HeadOffice/4posheadoffice.pos";
			sqlLinkPath = "http://www.4pos.co.za/4HeadOffice/4posheadoffice.dsl";
			Module1.tipftp = Convert.ToString(1);

			//get HO info
			int BranchType = 0;
			int branchID = 0;
			string HOfficeID = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "Select Comp_ID, Comp_Email1, Comp_Email2 FROM CompanyEmails;");
			if (rs.RecordCount > 0) {
				if (Information.IsDBNull(rs.Fields("Comp_ID").Value)){Interaction.MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine");return;
}
				BranchType = rs.Fields("Comp_ID").Value;
				if (BranchType == 1)
					return;
				//check if it is Headoffice
				if (Information.IsDBNull(rs.Fields("Comp_Email1").Value)){Interaction.MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine");return;
}
				if (Information.IsNumeric(rs.Fields("Comp_Email1").Value)) {
				} else {
					Interaction.MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine");
					return;
				}
				if (Convert.ToInt16(rs.Fields("Comp_Email1").Value) > 0) {
				} else {
					Interaction.MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine");
					return;
				}
				HOfficeID = rs.Fields("Comp_Email1").Value;
				if (Information.IsDBNull(rs.Fields("Comp_Email2").Value)){Interaction.MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine");return;
}
				if (Information.IsNumeric(rs.Fields("Comp_Email2").Value)) {
				} else {
					Interaction.MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine");
					return;
				}
				if (Convert.ToInt16(rs.Fields("Comp_Email2").Value) > 0) {
				} else {
					Interaction.MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine");
					return;
				}
				branchID = rs.Fields("Comp_Email2").Value;
			} else {
				Interaction.MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine");
				return;
			}

			//CaricaDati  'read the file
			//frmMainHO.Text1.Text = ""
			//frmMainHO.Label1(1).Caption = ""
			//UPGRADE_ISSUE: Load statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"'
			//Load(frmMainHO)
			//PreparaForm
			//frmFTP.Show vbModal
			My.MyProject.Forms.frmMainHO.tmrAutoDE.Enabled = true;
			My.MyProject.Forms.frmMainHO.ShowDialog();
			//vbModal
		}

		public string GetSystemPath()
		{
			string functionReturnValue = null;
			string strFolder = null;
			int lngResult = 0;
			strFolder = new string(Strings.Chr(0), MAX_PATH);
			lngResult = GetSystemDirectory(strFolder, MAX_PATH);
			if (lngResult != 0) {
				functionReturnValue = Strings.Left(strFolder, Strings.InStr(strFolder, Strings.Chr(0)) - 1);
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object GetSystemPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				functionReturnValue = "";
			}
			return functionReturnValue;
		}

		private string GetWinPath()
		{
			string functionReturnValue = null;
			string strFolder = null;
			int lngResult = 0;
			strFolder = new string(Strings.Chr(0), MAX_PATH);
			lngResult = GetWindowsDirectory(strFolder, MAX_PATH);
			if (lngResult != 0) {
				functionReturnValue = Strings.Left(strFolder, Strings.InStr(strFolder, Strings.Chr(0)) - 1);
			} else {
				functionReturnValue = "";
			}
			return functionReturnValue;
		}

		private string getRegKey(ref object lKey)
		{
			int hkey = 0;
			int lRetVal = 0;
			string vValue = null;
			lRetVal = modUtilities.RegOpenKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\4POS\\pos", 0, modUtilities.KEY_QUERY_VALUE, ref hkey);
			lRetVal = modUtilities.QueryValueEx(hkey, lKey, ref vValue);

			modUtilities.RegCloseKey(hkey);
			return vValue;
		}

		private void cmdPrintSlip_Click()
		{
			//Dim Object_Renamed As Object
			short rightX = 0;
			string lString = null;
			short y = 0;
			int lRetVal = 0;
			int hkey = 0;
			int vValue = 0;
			System.Drawing.Printing.PrintDocument Printer = new System.Drawing.Printing.PrintDocument();
			int gFontSize = 0;
			int gValue = 0;
			string gFontName = null;
			ADODB.Recordset rsPrinter = default(ADODB.Recordset);
			ADODB.Recordset rs = default(ADODB.Recordset);
			string TheBarcodePrName = null;
			string lPrinter = null;
			System.Drawing.Printing.PrintDocument lPrn = new System.Drawing.Printing.PrintDocument();
			System.Drawing.Printing.PrintDocument lPrnType = new System.Drawing.Printing.PrintDocument();
			object gObject = null;
			//On Local Error Resume Next
			const short characters = 32;
			int gWidth = 0;
			int gLeft = 0;
			int gRight = 0;

			rs = modRecordSet.getRS(ref "SELECT Company_PrintDayEndSlip from Company;");
			if (rs.RecordCount) {
				if (rs.Fields("Company_PrintDayEndSlip").Value) {

				} else {
					return;
				}
			} else {
				return;
			}

			 // ERROR: Not supported in C#: OnErrorStatement

			gFontName = getRegKey(ref "printerPOSfontName");
			if (string.IsNullOrEmpty(gFontName))
				gFontName = "Courier";
			gValue = getRegKey(ref "printerPOSfontSize");
			if (string.IsNullOrEmpty(gValue)) {
				gFontSize = 10;
			} else {
				gFontSize = Convert.ToInt16(gValue);
			}

			gValue = getRegKey(ref "printerPOSleft");
			 // ERROR: Not supported in C#: OnErrorStatement

			//UPGRADE_WARNING: Couldn't resolve default property of object gValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(gValue)) {
				gLeft = 0;
			} else {
				gLeft = Convert.ToInt32(gValue) * sizeConvertors.twipsPerPixel(true);
			}
			gValue = getRegKey(ref "printerPOSright");
			if (string.IsNullOrEmpty(gValue)) {
				gRight = 0;
			} else {
				gRight = Convert.ToInt32(gValue) * sizeConvertors.twipsPerPixel(true);
			}

			vValue = "";
			lRetVal = modUtilities.RegOpenKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\4POS\\pos", 0, modUtilities.KEY_QUERY_VALUE, ref hkey);
			lRetVal = modUtilities.QueryValueEx(hkey, "printerPOS", ref vValue);
			modUtilities.RegCloseKey(hkey);
			if (string.IsNullOrEmpty(vValue))
				vValue = "0";

			if (vValue != "0") {
				if (vValue == "[Not Installed]") {
					return;
				}

				foreach (System.Drawing.Printing.PrintDocument lPrn_loopVariable in System.Drawing.Printing.PrinterSettings.InstalledPrinters) {
					lPrn = lPrn_loopVariable;
					//If rsPrinter("PrinterName") = (lPrn.DeviceName) Then
					if (Strings.LCase(lPrn.PrinterSettings.PrinterName) == Strings.LCase(vValue)) {
						Printer = lPrn;
						lPrinter = vValue;
						break; // TODO: might not be correct. Was : Exit For
					}
				}

				gWidth = Printer.PrinterSettings.DefaultPageSettings.PrintableArea.Width;
				if (gWidth == 2724) {
				} else {
					gWidth = 3600;
				}

				gObject = Printer;

				 // ERROR: Not supported in C#: OnErrorStatement

				gObject.FontBold = true;
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.CurrentY. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.TextWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.PSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//gObject.PSet(New Point[](((gWidth - gRight) - gObject.TextWidth(" ")) / 2, gObject.CurrentY))
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.Print(" ");

				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.CurrentY. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.TextWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.PSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//gObject.PSet(New Point[](((gWidth - gRight) - gObject.TextWidth(frmMenu.lblCompany.Text)) / 2, gObject.CurrentY))
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.Print(My.MyProject.Forms.frmMenu.lblCompany.Text);

				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.Print(" ");

				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.CurrentY. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.TextWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.PSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//gObject.PSet(New Point[](((gWidth - gRight) - gObject.TextWidth("Day End Completed")) / 2, gObject.CurrentY))
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.Print("Day End Completed");
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.Print(" ");

				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.FontUnderline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.FontUnderline = true;
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.CurrentY. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object y. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				y = gObject.CurrentY;
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.FontBold. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.FontBold = true;
				//UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lString = "Manager" + " :";
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.Print(lString);
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.FontBold. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.FontBold = false;
				//UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lString = My.MyProject.Forms.frmMenu.lblUser.Text;
				//gObject.PSet (1800, y)
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.PSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//gObject.PSet(New Point[](IIf(gWidth = 2724, 1050, 1800), y)) '1350
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.Print(lString);

				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.FontUnderline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.FontUnderline = true;
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.CurrentY. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object y. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				y = gObject.CurrentY;
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.FontBold. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.FontBold = true;
				//UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lString = "Date" + " :";
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.Print(lString);
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.FontBold. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.FontBold = false;
				//UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lString = Strings.Format(DateAndTime.Now, "ddd dd mm,yyyy hh:nn");
				//gObject.PSet (1800, y)
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.PSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//gObject.PSet(New Point[](IIf(gWidth = 2724, 1050, 1800), y)) '1350
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.Print(lString);

				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.FontUnderline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.FontUnderline = false;

				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.CurrentY. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object rightX. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.Line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//gObject.Line((0, gObject.CurrentY) - ((gObject.Width - gRight) - rightX, gObject.CurrentY + 1))
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.CurrentY. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.PSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//gObject.PSet(New Point[](0, gObject.CurrentY + 30))
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);

				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.Print(" ");
				//UPGRADE_WARNING: Couldn't resolve default property of object Object.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//Object_Renamed.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)

				//For x = 1 To 6
				//    gObject.Print " "
				//Next x
				//UPGRADE_WARNING: Couldn't resolve default property of object gObject.EndDoc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gObject.EndDoc();

			}
		}

		private void ChkStockitemHistoryTable()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string strFldName = null;
			ChkTransTable:


			 // ERROR: Not supported in C#: OnErrorStatement

			rs = modRecordSet.getRS(ref "SELECT * FROM StockitemHistory777;");
			if (rs.RecordCount) {
				modRecordSet.cnnDB.Execute("DELETE FROM StockitemHistory777");
			}

			return;
			Err_ChkTransTable:
			if (Err().Number == -2147217865 & Err().Description == "[Microsoft][ODBC Microsoft Access Driver] The Microsoft Jet database engine cannot find the input table or query 'StockitemHistory777'.  Make sure it exists and that its name is spelled correctly.") {
				strFldName = "StockItemID Number, QuantitySales Currency";
				modRecordSet.cnnDB.Execute("CREATE TABLE " + "StockitemHistory777" + " (" + strFldName + ")");
				System.Windows.Forms.Application.DoEvents();
				rs = modRecordSet.getRS(ref "SELECT * FROM StockitemHistory777;");
				if (rs.RecordCount) {
					modRecordSet.cnnDB.Execute("DELETE FROM StockitemHistory777");
				}

				goto ChkTransTable;
			}

		}

		private void cmdBack_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (gMode == mdComplete) {
			}
			this.Close();
		}

		private void cmdNext_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			switch (gMode) {
				case mdSecurity:
					doMode(ref mdPOS);
					break;
				case mdPOS:
					doMode(ref mdConfirm);
					break;
				case mdConfirm:
					doMode(ref mdComplete);
					break;
			}
		}

		private void frmDayEnd_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			Width = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(this.frmMode[0].Left, true) + sizeConvertors.pixelToTwips(frmMode[0].Width, true) + 250, true);
			Height = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(this.cmdBack.Top, false) + sizeConvertors.pixelToTwips(cmdBack.Height, false) + 250 + 240, false);
			frmMode.AddRange(new GroupBox[] {
				_frmMode_0,
				_frmMode_1,
				_frmMode_2,
				_frmMode_3,
				_frmMode_4
			});
			GroupBox gb = new GroupBox();
			foreach (GroupBox gb_loopVariable in frmMode) {
				gb = gb_loopVariable;
				gb.KeyPress += frmDayEnd_KeyPress;
			}
			bolAutoDE_Error = false;
			loadLanguage();
			if (checkSecurity()) {
			}
		}
		private void frmDayEnd_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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
		private string getSerialNumber()
		{
			string functionReturnValue = null;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			Scripting.Folder fsoFolder = default(Scripting.Folder);
			Scripting.Drive fsoDrive = default(Scripting.Drive);
			functionReturnValue = "";
			if (fso.FolderExists(modRecordSet.serverPath)) {
				fsoFolder = fso.GetFolder(modRecordSet.serverPath);
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
			string lCode = null;
			string leCode = null;
			string lPassword = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			short x = 0;
			functionReturnValue = false;
			lPassword = "pospospospos";
			//only for 4AIR
			if (Strings.LCase(Strings.Left(modRecordSet.serverPath, 3)) == "d:\\" & Strings.LCase(My.MyProject.Forms.frmMenu.lblCompany.Text) == "4air") {
				//only for 4AIR
				functionReturnValue = true;
				doMode(ref mdPOS);
				return functionReturnValue;
			} else if (Strings.LCase(Strings.Left(modRecordSet.serverPath, 3)) != "c:\\") {
				lblDemo.Text = "";
				frmMode[4].Text = "";
				lblText.Text = "Due to security implications the Day End run may only be run from the Main 4POS Server.";

				lblDemo.ForeColor = System.Drawing.Color.Red;
				this.cmdNext.Enabled = false;
				doMode(ref mdSecurity);
				return functionReturnValue;
			}
			lCode = getSerialNumber();
			leCode = Encrypt(lCode, lPassword);
			for (x = 1; x <= Strings.Len(leCode); x++) {
				if (Strings.Asc(Strings.Mid(leCode, x, 1)) < 33) {
					leCode = Strings.Left(leCode, x - 1) + Strings.Chr(33) + Strings.Mid(leCode, x + 1);
				}
			}

			rs = modRecordSet.getRS(ref "SELECT * From Company WHERE Company_Code = '" + Strings.Replace(leCode, "'", "''") + "';");
			if (rs.RecordCount) {
				functionReturnValue = true;

				//for Security Code
				if (bolSecurityCode() == true) {
					doMode(ref mdPOS);
				} else {
					lblDemo.Text = "You cannot do more Day Ends due to Security Restrictions. Please Contact 4POS!";
					lblDemo.ForeColor = System.Drawing.Color.Red;
					this.cmdNext.Enabled = false;
				}
				//for Security Code
			} else {
				rs = modRecordSet.getRS(ref "SELECT * From Company;");

				if (Information.IsNumeric(rs.Fields("Company_Code").Value) & Strings.Len(rs.Fields("Company_Code").Value) == 13) {
					functionReturnValue = true;

					//for Security Code
					if (bolSecurityCode() == true) {
						doMode(ref mdPOS);
					} else {
						lblDemo.Text = "You cannot do more Day Ends due to Security Restrictions. Please Contact 4POS!";
						lblDemo.ForeColor = System.Drawing.Color.Red;
						this.cmdNext.Enabled = false;
					}
					//for Security Code
				} else {
					rs = modRecordSet.getRS(ref "SELECT Max(DayEnd.DayEndID) AS maxID FROM DayEnd;");
					doMode(ref mdSecurity);

					if (rs.BOF | rs.EOF) {
						x = 9;
					} else {
						x = 10 - rs.Fields("maxID").Value;
					}

					if (x < 0) {
						lblDemo.Text = "Your Software has expired. Please Contact 4POS to register!";
						lblDemo.ForeColor = System.Drawing.Color.Red;
						this.cmdNext.Enabled = false;
					} else {
						lblDemo.Text = "After this Day End run you will have " + x + " more Day End runs before the demo software expires.";
						this.cmdNext.Enabled = true;
					}
				}
			}
			return functionReturnValue;

		}

		private void frmDayEnd_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			Scripting.TextStream lTextstream = default(Scripting.TextStream);
			string lString = null;
			if (modApplication.bolAutoDE == true) {
				lString = modRecordSet.serverPath + "data\\4POSInterface\\4POSAUTODE.txt";
				if (fso.FileExists(lString))
					fso.DeleteFile(lString, true);
				lString = modRecordSet.serverPath + "data\\4POSInterface\\4POSAUTODEDONE.txt";
				if (fso.FileExists(lString))
					fso.DeleteFile(lString, true);
				lTextstream = fso.OpenTextFile(lString, Scripting.IOMode.ForWriting, true);
				lTextstream.Write("DONE");
				lTextstream.Close();
				System.Environment.Exit(0);
				//Unload Me
			}
		}
	}
}
