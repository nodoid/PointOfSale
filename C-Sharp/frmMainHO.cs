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
	internal partial class frmMainHO : System.Windows.Forms.Form
	{
//Option Explicit

		private const short STRING_SIZE = 128;
		private const short INTERNET_OPEN_TYPE_DIRECT = 1;
		private const int INTERNET_FLAG_NO_CACHE_WRITE = 0x4000000;
		[DllImport("wininet", EntryPoint = "InternetOpenA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
//
		private static extern int InternetOpen(string sAgent, int lAccessType, string sProxyName, string sProxyBypass, int lFlags);
		[DllImport("wininet", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
//
		private static extern int InternetCloseHandle(ref int hInet);
		[DllImport("wininet", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
//
		private static extern short InternetReadFile(int hFile, string sBuffer, int lNumBytesToRead, ref int lNumberOfBytesRead);
		[DllImport("wininet", EntryPoint = "InternetOpenUrlA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
//
		private static extern int InternetOpenUrl(int hInternetSession, string lpszUrl, string lpszHeaders, int dwHeadersLength, int dwFlags, int dwContext);
//
//
//
		Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
		Scripting.TextStream ErrTextstream;
		string tempStatus;
		[DllImport("wininet", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		private static extern int InternetAttemptConnect(int dwReserved);
		CSocketMaster myWinSock;
			// clsBlowfish
		clsRC4 a = new clsRC4();

		string gMasterPath;
		ADODB.Connection cnnDBWaitron;
		private const string gPathHO = "C:\\4POS\\headoffice\\";
		ADODB.Recordset rsWebDB;

		int gDayEndStart;
		int gDayEndEnd;

		short gCNT;
		public List<Button> cmdPulsante = new List<Button>();
		List<DateTimePicker> DTPicker1 = new List<DateTimePicker>();
		private string SendAPIRequest(string strUrl)
		{
			string functionReturnValue = null;
			int hOpen = 0;
			int hFile = 0;
			int ret = 0;
			string sBuffer = null;
			short iResult = 0;
			string sData = null;

			 // ERROR: Not supported in C#: OnErrorStatement


			hOpen = InternetOpen("VB Program", 1, Constants.vbNullString, Constants.vbNullString, 0);
			if (hOpen == 0) {
				Interaction.MsgBox("Error opening Internet connection");
				return functionReturnValue;
			}

			hFile = InternetOpenUrl(hOpen, strUrl, Constants.vbNullString, 0, INTERNET_FLAG_NO_CACHE_WRITE, 0);
			if (hFile == 0) {
				//MsgBox "Error opening Web page"
				lbl11.Text = "Error opening Web page";
				//lstStatus.AddItem lbl11
				//lstStatus.ListIndex = lstStatus.ListCount - 1
				//lstStatus.ListIndex = -1
			} else {
				InternetReadFile(hFile, sBuffer, STRING_SIZE, ref ret);
				sData = sBuffer;
				while (ret != 0) {
					InternetReadFile(hFile, sBuffer, STRING_SIZE, ref ret);
					sData = sData + Strings.Mid(sBuffer, 1, ret);
				}
			}

			InternetCloseHandle(ref hFile);
			InternetCloseHandle(ref hOpen);
			functionReturnValue = sData;
			sData = "";
			return functionReturnValue;
			AutoErrorHndlr:

			//TEST PURPOSE
			tempStatus = "SendAPIRequest" + " - " + Err().Number + " - " + Err().Description + Constants.vbCrLf;
			if (fso.FileExists(gPathHO + "\\4HOfficeStatusErrLog.log")) {
				ErrTextstream = fso.OpenTextFile(gPathHO + "\\4HOfficeStatusErrLog.log", Scripting.IOMode.ForAppending, true);
			} else {
				ErrTextstream = fso.OpenTextFile(gPathHO + "\\4HOfficeStatusErrLog.log", Scripting.IOMode.ForWriting, true);
			}
			ErrTextstream.Write(tempStatus);
			ErrTextstream.Close();
			//TEST PURPOSE
			 // ERROR: Not supported in C#: ResumeStatement

			return functionReturnValue;
		}

		private void updateStatus(ref string sStatus)
		{
			Text1.Text = Text1.Text + sStatus + Constants.vbCrLf;
			Text1.Refresh();
			Text1.SelectionStart = Strings.Len(Text1.Text);
		}

//Private Sub updateLOG(Log_BranchID As Long, Log_HeadOfficeID As Long, Log_User As String, Log_Action As String, Log_Remarks As String)
		private void updateLOG(ref string Log_Action, ref string Log_Remarks)
		{
			string sql = null;
			if (Module1.sqlDBcn == null) {
			} else {
				sql = "INSERT INTO Log (Log_BranchID, Log_HeadOfficeID, Log_Date, Log_User, Log_Action, Log_Remarks) " + "VALUES     (" + (Module1.BranchType == "0" ? Convert.ToInt32(Module1.BranchID) : 0) + ", " + (Module1.BranchType == "1" ? Convert.ToInt32(Module1.HOfficeID) : 0) + ", '" + DateAndTime.Now + "', '" + My.MyProject.Forms.frmMenu.lblUser.Text + "', '" + Log_Action + "', '" + Log_Remarks + " ')";
				Module1.sqlDBcn.Execute(sql);
			}
		}

		private void cmdClear_Click()
		{
			lbl11.Text = "-/-";
			lbl22.Text = "-/-";
			lbl33.Text = "-/-";
			lbl44.Text = "-/-";
			lbl55.Text = "-/-";
			lbl66.Text = "-/-";
			//lbl77 = "-/-"
			//lbl88 = "-/-"

			//lstStatus.Clear
			Text1.Text = "";
			_Label1_1.Text = "-/-";
			//txtCustOrder.Text = ""
			//txtBalStatus.Text = ""
			//txtBalRes.Text = ""
			//txtWSDLOrder.Text = ""
			//txtWSDLOrder_Log.Text = ""
			//txtWSDLPOFile.Text = ""
			//txtGRVFile.Text = ""
			//txtCartID.Text = ""
			//txtRespnse.Text = ""
			//txtCredit.Text = ""
			//txtCellNo.Text = ""
			//Text1Copy.Text = ""
			//txtCustOrderCopy.Text = ""
			//txtPrevOrder = ""

			//tmr1ChkNewOrder.Enabled = False
			//tmr2FoundDL.Enabled = False
			//tmr3ChkStkLvl.Enabled = False
			//tmr4POfileWSDL.Enabled = False
			//tmr5GRV.Enabled = False
			//tmr6ScanOrder.Enabled = False
			//tmr7Controller.Enabled = False
		}

		private void cmdBookIN_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			Module1.bBranchChange = false;

			cmdClear_Click();
			cmdPulsante_Click(cmdPulsante[0], new System.EventArgs());
			cmdPulsante_Click(cmdPulsante[9], new System.EventArgs());
			cmdPulsante_Click(cmdPulsante[1], new System.EventArgs());

			Interaction.MsgBox("Process Finished.");
		}

		private void cmdBookOut_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			Module1.bBranchChange = false;

			cmdClear_Click();
			cmdPulsante_Click(cmdPulsante[0], new System.EventArgs());
			cmdPulsante_Click(cmdPulsante[8], new System.EventArgs());
			cmdPulsante_Click(cmdPulsante[1], new System.EventArgs());

			Interaction.MsgBox("Process Finished.");
		}

		private void cmdCheckWOrder_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			Module1.bBranchChange = false;

			if (Module1.BranchType == "0") {
				Interaction.MsgBox("Option not allowed.");
				return;
			}

			cmdClear_Click();
			cmdPulsante_Click(cmdPulsante[0], new System.EventArgs());
			cmdPulsante_Click(cmdPulsante[6], new System.EventArgs());
			cmdPulsante_Click(cmdPulsante[1], new System.EventArgs());

			Interaction.MsgBox("Process Finished.");
		}

		private void cmdClearLock_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (Interaction.MsgBox("Are you sure you wish to clear the lock file? It may create problem if other branch/headoffice is busy at the moment.", MsgBoxStyle.YesNo) == MsgBoxResult.Yes) {
				cmdClear_Click();
				cmdPulsante_Click(cmdPulsante[0], new System.EventArgs());
				DownLoadFile_DownTxt(true);
				System.Windows.Forms.Application.DoEvents();
				DownLoadFile_DownTxt(true);
				cmdPulsante_Click(cmdPulsante[1], new System.EventArgs());

				System.Windows.Forms.Application.DoEvents();
				cmdPulsante_Click(cmdPulsante[0], new System.EventArgs());
				DownLoadFile_DownTxt(ref true, ref true);
				System.Windows.Forms.Application.DoEvents();
				DownLoadFile_DownTxt(ref true, ref true);
				cmdPulsante_Click(cmdPulsante[1], new System.EventArgs());

				Interaction.MsgBox("Process Finished.");
			}
		}

		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdToday_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "SELECT DayEnd.DayEndID, DayEnd.DayEnd_Date From DayEnd, Company WHERE (((DayEnd.DayEndID)=[Company]![Company_DayEndID]-1));");
			if (rs.RecordCount) {
				_DTPicker1_0.Value = rs.Fields("DayEnd_Date").Value;
				_DTPicker1_1.Value = rs.Fields("DayEnd_Date").Value;
				setDayEndRangeHO();
			} else {
				//cmdToday_Click
			}
			//_DTPicker1_1.SetFocus
		}

		private void Command3_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			Module1.bBranchChange = false;

			if (Module1.BranchType == "1") {
				Interaction.MsgBox("Option not allowed.");
				return;
			}

			cmdClear_Click();
			Text1.Text = Text1.Text + "Uploading Product Performance reports" + Constants.vbCrLf;
			Text1.Refresh();
			Text1.SelectionStart = Strings.Len(Text1.Text);
			cmdPulsante_Click(cmdPulsante[0], new System.EventArgs());

			picInner.Width = 0;
			gCNT = 0;
			System.Windows.Forms.Application.DoEvents();
			picOuter.Visible = true;
			uploadProductPerformance();
			picOuter.Visible = false;

			cmdPulsante_Click(cmdPulsante[1], new System.EventArgs());

			Interaction.MsgBox("Process Finished.");
		}

		private void DTPicker1_Change(System.Object eventSender, System.EventArgs eventArgs)
		{
			DateTimePicker dtp = new DateTimePicker();
			dtp = (DateTimePicker)eventSender;
			int Index = GetIndex.GetIndexer(ref dtp, ref DTPicker1);
			setDayEndRangeHO();
			//MsgBox gDayEndStart
		}

		private void setDayEndRangeHO()
		{
			System.DateTime lDate = default(System.DateTime);
			string lDateString = null;
			string[] lDateArray = null;
			System.DateTime lDateStart = default(System.DateTime);
			System.DateTime lDateEnd = default(System.DateTime);
			ADODB.Recordset rs = default(ADODB.Recordset);
			 // ERROR: Not supported in C#: OnErrorStatement


			_DTPicker1_0.Value = _DTPicker1_1.Value;
			lDateStart = _DTPicker1_0.Value;
			lDateEnd = _DTPicker1_1.Value;
			lDateStart = Convert.ToDateTime(Strings.Left(Convert.ToString(lDateStart), 10));
			lDateEnd = Convert.ToDateTime(Strings.Left(Convert.ToString(lDateEnd), 10));

			if (lDateStart >= lDateEnd) {
				lDateStart = _DTPicker1_1.Value;
				lDateEnd = _DTPicker1_0.Value;
			}
			lDateStart = Convert.ToDateTime(Strings.Left(Convert.ToString(lDateStart), 10));
			lDateEnd = Convert.ToDateTime(Strings.Left(Convert.ToString(lDateEnd), 10));

			rs = modRecordSet.getRS(ref "SELECT DayEnd.DayEndID From DayEnd Where (((DayEnd.DayEnd_Date) >= #" + lDateStart + " 00:00:00#)) ORDER BY DayEnd.DayEnd_Date;");
			if (rs.BOF | rs.EOF) {
				rs.Close();
				rs = modRecordSet.getRS(ref "SELECT Max(DayEnd.DayEndID) AS DayEndID FROM DayEnd;");

			}
			gDayEndStart = rs.Fields("DayEndID").Value;
			rs.Close();

			rs = modRecordSet.getRS(ref "SELECT DayEnd.DayEndID From DayEnd Where (((DayEnd.DayEnd_Date) <= #" + lDateEnd + " 23:59:59#)) ORDER BY DayEnd.DayEnd_Date DESC;");
			if (rs.BOF | rs.EOF) {
				rs.Close();
				rs = modRecordSet.getRS(ref "SELECT Min(DayEnd.DayEndID) AS DayEndID FROM DayEnd;");

			}
			gDayEndEnd = rs.Fields("DayEndID").Value;
			rs.Close();

			rs = modRecordSet.getRS(ref "SELECT Count(DayEnd.DayEndID) AS [count], Min(DayEnd.DayEnd_Date) AS fromDate, Max(DayEnd.DayEnd_Date) AS toDate From DayEnd WHERE (((DayEnd.DayEndID)>= " + gDayEndStart + ") AND ((DayEnd.DayEndID) <= " + gDayEndEnd + "));");
			//
			//    lblDayEnd.Caption = "From " & Format(rs("fromDate"), "ddd dd mmm yyyy")
			//    lblDayEnd.Caption = lblDayEnd.Caption & " to "
			//    lblDayEnd.Caption = lblDayEnd.Caption & Format(rs("toDate"), "ddd dd mmm yyyy")
			//    lblDayEnd.Caption = lblDayEnd.Caption & " covering " & rs("count") & " day-end/s."
			//_DTPicker1_0. = Format(rs.Fields("fromDate").Value, "yyyy")
			//_DTPicker1_0.Month = Format(rs.Fields("fromDate").Value, "m")
			//_DTPicker1_0.Day = Format(rs.Fields("fromDate").Value, "d")
			//_DTPicker1_1.Year = Format(rs.Fields("toDate").Value, "yyyy")
			//_DTPicker1_1.Month = Format(rs.Fields("toDate").Value, "m")
			//_DTPicker1_1.Day = Format(rs.Fields("toDate").Value, "d")
		}


		private void cmdUpReport_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			Module1.bBranchChange = false;

			if (Module1.BranchType == "1") {
				Interaction.MsgBox("Option not allowed.");
				return;
			}

			cmdClear_Click();
			Text1.Text = Text1.Text + "Uploading Day End reports" + Constants.vbCrLf;
			Text1.Refresh();
			Text1.SelectionStart = Strings.Len(Text1.Text);
			cmdPulsante_Click(cmdPulsante[0], new System.EventArgs());
			cmdPulsante_Click(cmdPulsante[10], new System.EventArgs());
			cmdPulsante_Click(cmdPulsante[1], new System.EventArgs());


			cmdClear_Click();
			Text1.Text = Text1.Text + "Uploading Product Performance reports" + Constants.vbCrLf;
			Text1.Refresh();
			Text1.SelectionStart = Strings.Len(Text1.Text);
			cmdPulsante_Click(cmdPulsante[0], new System.EventArgs());

			picInner.Width = 0;
			gCNT = 0;
			System.Windows.Forms.Application.DoEvents();
			picOuter.Visible = true;
			uploadProductPerformance();
			picOuter.Visible = false;

			cmdPulsante_Click(cmdPulsante[1], new System.EventArgs());

			Interaction.MsgBox("Process Finished.");
		}

		private void uploadProductPerformance()
		{
			string sql = null;
			My.MyProject.Forms.frmMenu._DTPicker1_0.Value = _DTPicker1_1.Value;
			My.MyProject.Forms.frmMenu.setDayEndRange();
			My.MyProject.Forms.frmMenu._DTPicker1_1.Value = _DTPicker1_1.Value;
			My.MyProject.Forms.frmMenu.setDayEndRange();
			My.MyProject.Forms.frmMenu.cmdLoad_Click(null, new System.EventArgs());

			ADODB.Recordset rs = default(ADODB.Recordset);
			//sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity,"
			//sql = sql & "Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name  ORDER BY StockItem_Name;"
			sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.actualCostSum, StockList.listCostSum, StockList.exclusiveSum, StockList.inclusiveSum, StockList.depositSum, StockList.quantitySum, StockList.Sale_ChannelID, aStockGroup.StockGroup_Name, aPricingGroup.PricingGroup_Name ";
			sql = sql + "FROM (StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID) INNER JOIN aPricingGroup ON aStockItem1.StockItem_PricingGroupID = aPricingGroup.PricingGroupID;";
			rs = modReport.getRSreport(ref sql);
			if (rs.BOF | rs.EOF) {
				//MsgBox "No data found for Product Performance reports."
				Text1.Text = Text1.Text + "No data found for Product Performance reports." + Constants.vbCrLf;
				Text1.Refresh();
				Text1.SelectionStart = Strings.Len(Text1.Text);

			} else {
				Module1.sqlDBcn.Execute("DELETE FROM ProductPerform Where (BranchID = " + Convert.ToInt32(Module1.BranchID) + ") And (HeadOfficeID = " + Convert.ToInt32(Module1.HOfficeID) + ") And (DayEndDate = '" + Strings.Format(_DTPicker1_1.Value, "short date") + "')");


				while (!(rs.EOF)) {
					sql = "INSERT INTO ProductPerform (BranchID, HeadOfficeID, DayEndDate, StockItemID, StockItemName, actualCostSum, listCostSum, exclusiveSum, inclusiveSum, depositSum, quantitySum, ChannelID, StockGroupName, PricingGroupName) " + "VALUES     (" + Convert.ToInt32(Module1.BranchID) + ", " + Convert.ToInt32(Module1.HOfficeID) + ", '" + Strings.Format(_DTPicker1_1.Value, "short date") + "', " + rs.Fields("StockItemID").Value + ", '" + rs.Fields("StockItem_Name").Value + "', " + rs.Fields("actualCostSum").Value + ", " + rs.Fields("listCostSum").Value + ", " + rs.Fields("exclusiveSum").Value + ", " + rs.Fields("inclusiveSum").Value + ", " + rs.Fields("depositSum").Value + ", " + rs.Fields("quantitySum").Value + ", " + rs.Fields("Sale_ChannelID").Value + ", '" + rs.Fields("StockGroup_Name").Value + "', '" + rs.Fields("PricingGroup_Name").Value + " ')";
					Debug.Print(sql);
					Module1.sqlDBcn.Execute(sql);

					moveItem();

					rs.MoveNext();
				}
			}
		}

		private void moveItem()
		{
			if (sizeConvertors.pixelToTwips(picInner.Width, true) > sizeConvertors.pixelToTwips(picOuter.Width, true)){picInner.Width = 0;gCNT = 0;}

			gCNT = gCNT + 1;
			picInner.Width = sizeConvertors.twipsToPixels(Convert.ToInt16(sizeConvertors.pixelToTwips(picOuter.Width, true) / 31 * gCNT) + 100, true);
			System.Windows.Forms.Application.DoEvents();
		}

		private void Command2_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string lString = null;
			string sql = null;
			ADODB.Recordset rsWebDBs = default(ADODB.Recordset);
			Module1.bBranchChange = false;

			string ret = null;
			string dtDate = null;
			string dtMonth = null;
			string stPass = null;
			if (Module1.BranchType == "1") {
				//UPGRADE_WARNING: Add a delegate for AddressOf TimerProc Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"'
				//SetTimer(Handle.ToInt32, NV_INPUTBOX, 10, TimerProc)
				ret = Interaction.InputBox("Enter Password");
				//Construct password...........
				if (Strings.Len(DateAndTime.Day(DateAndTime.Today)) == 1)
					dtDate = "0" + Conversion.Str(DateAndTime.Day(DateAndTime.Today));
				else
					dtDate = Strings.Trim(Conversion.Str(DateAndTime.Day(DateAndTime.Today)));
				dtDate = Strings.Replace(dtDate, " ", "");
				if (Strings.Len(DateAndTime.Month(DateAndTime.Today)) == 1)
					dtMonth = "0" + Conversion.Str(DateAndTime.Month(DateAndTime.Today));
				else
					dtMonth = Strings.Trim(Conversion.Str(DateAndTime.Month(DateAndTime.Today)));
				dtMonth = Strings.Replace(dtMonth, " ", "");

				//Create password
				stPass = dtDate + "##" + dtMonth;
				stPass = Strings.Replace(stPass, " ", "");

				if (Strings.Trim(ret) == stPass) {
					Module1.bBranchChange = true;
				} else {
					Interaction.MsgBox("Incorrect password was entered!!!", MsgBoxStyle.Exclamation, "Incorrect Passwords");
					return;
				}
			}

			cmdClear_Click();
			cmdPulsante_Click(cmdPulsante[0], new System.EventArgs());
			cmdPulsante_Click(cmdPulsante[7], new System.EventArgs());
			cmdPulsante_Click(cmdPulsante[1], new System.EventArgs());

			if (Module1.BranchType == "0") {
				cmdPulsante_Click(cmdPulsante[0], new System.EventArgs());

				rsWebDBs = new ADODB.Recordset();
				sql = "SELECT * FROM GRVSale WHERE (GRVSale_HeadOfficeID = " + Convert.ToInt16(Module1.HOfficeID) + ") AND (GRVSale_BranchID = " + Convert.ToInt16(Module1.BranchID) + ") AND (GRVSale_Done = 'False');";
				var _with1 = rsWebDBs;
				_with1.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
				_with1.CursorType = ADODB.CursorTypeEnum.adOpenForwardOnly;
				_with1.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic;
				_with1.Source = sql;
				_with1.ActiveConnection = Module1.sqlDBcn;
				_with1.Open();
				_with1.ActiveConnection = null;
				if (rsWebDBs.RecordCount) {
					tryCheckZip:
					if (fso.FileExists(modRecordSet.serverPath + "data.zip")) {
						Interaction.MsgBox("There are 'Sale to GRV' outstanding to be processed. Please click 'OK' once 4POS Domain Controller finished with Pricing update.");
						goto tryCheckZip;
					}

					lString = Strings.Replace(Convert.ToString(DateAndTime.Now), " ", "_");
					lString = Strings.Replace(lString, "/", "-");
					lString = Strings.Replace(lString, ":", "");
					if (fso.FolderExists(gPathHO + "download\\" + lString)) {
					} else {
						fso.CreateFolder(gPathHO + "download\\" + lString);
					}


					while (!(rsWebDBs.EOF)) {
						cmdPulsante_Click(cmdPulsante[1], new System.EventArgs());
						cmdPulsante_Click(cmdPulsante[0], new System.EventArgs());
						DownLoadFile_GRV(ref false, ref Convert.ToString(Strings.Split(rsWebDBs("GRVSale_Path"), "/grv/")[1]), ref gPathHO + "download\\" + lString, ref true);
						Module1.sGRVSales = gPathHO + "download\\" + lString + "\\" + Convert.ToString(Strings.Split(rsWebDBs("GRVSale_Path"), "/grv/")[1]);
						//frmGRVimport.Tag = lString
						My.MyProject.Forms.frmGRVimport.ShowDialog();

						if (Module1.sGRVSales == "DONE") {
							sql = "UPDATE GRVSale SET GRVSale_Done = 'True' WHERE (GRVSaleID = " + rsWebDBs("GRVSaleID").Value + ");";
							Module1.sqlDBcn.Execute(sql);
						}

						Module1.sGRVSales = "";
						rsWebDBs.MoveNext();
					}

				}
				cmdPulsante_Click(cmdPulsante[1], new System.EventArgs());
			}

			Module1.sGRVSales = "";
			Interaction.MsgBox("Process Finished.");
		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement


			modRecordSet.closeConnection();
			System.Environment.Exit(0);
			this.Close();

			return;
			AutoErrorHndlr:
			//TEST PURPOSE
			tempStatus = "cmdExit_Click" + " - " + Err().Number + " - " + Err().Description + Constants.vbCrLf;
			if (fso.FileExists("d:\\4AIR\\4AIRStatusErrLog.log")) {
				ErrTextstream = fso.OpenTextFile("d:\\4AIR\\4AIRStatusErrLog.log", Scripting.IOMode.ForAppending, true);
			} else {
				ErrTextstream = fso.OpenTextFile("d:\\4AIR\\4AIRStatusErrLog.log", Scripting.IOMode.ForWriting, true);
			}
			ErrTextstream.Write(tempStatus);
			ErrTextstream.Close();
			//TEST PURPOSE
			//a = SendAPIRequest("http://www.bulksmsportal.co.za/httppost4.aspx?type=singlesms&username=" & "compupos" & "&password=" & "compupos" & "&Number=" & "0726633429" & "&Message=" & tempStatus & "&CustomerID=123")
			 // ERROR: Not supported in C#: ResumeStatement

		}

		private void Command1_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
		}

		private void frmMainHO_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdPulsante.AddRange(new Button[] {
				_cmdPulsante_0,
				_cmdPulsante_1,
				_cmdPulsante_2,
				_cmdPulsante_3,
				_cmdPulsante_4,
				_cmdPulsante_5,
				_cmdPulsante_6,
				_cmdPulsante_7
			});
			DTPicker1.AddRange(new DateTimePicker[] {
				_DTPicker1_0,
				_DTPicker1_1
			});
			Button bt = new Button();
			DateTimePicker dt = new DateTimePicker();
			foreach (Button bt_loopVariable in cmdPulsante) {
				bt = bt_loopVariable;
				bt.Click += cmdPulsante_Click;
			}
			foreach (DateTimePicker dt_loopVariable in DTPicker1) {
				dt = dt_loopVariable;
				dt.ValueChanged += DTPicker1_Change;
			}
			//If App.PrevInstance = True Then End

			string lString = null;
			 // ERROR: Not supported in C#: OnErrorStatement

			Module1.bUploadReport = false;

			if (fso.FolderExists(gPathHO)) {
			} else {
				fso.CreateFolder(gPathHO);
			}

			if (fso.FolderExists(gPathHO + "upload")) {
			} else {
				fso.CreateFolder(gPathHO + "upload");
			}

			if (fso.FolderExists(gPathHO + "download")) {
			} else {
				fso.CreateFolder(gPathHO + "download");
			}

			if (Module1.BranchType == "0") {
				this.Text = this.Text + " - BRANCH";
			} else {
				this.Text = this.Text + " - HEAD OFFICE";
			}

			//If openConnection Then
			lbl8.Text = modRecordSet.serverPath;
			//Else
			//    MsgBox "Couldn't find Pricing database.", vbExclamation
			//    End
			//End If

			cmdClear_Click();
			cmdToday_Click(cmdToday, new System.EventArgs());

			return;

			return;
			AutoErrorHndlr:
			//TEST PURPOSE
			tempStatus = "Form_Load" + " - " + Err().Number + " - " + Err().Description + Constants.vbCrLf;
			if (fso.FileExists(_4PosBackOffice.NET.My.MyProject.Application.Info.DirectoryPath + "\\4POSHOStatusErrLog.log")) {
				ErrTextstream = fso.OpenTextFile(_4PosBackOffice.NET.My.MyProject.Application.Info.DirectoryPath + "\\4POSHOStatusErrLog.log", Scripting.IOMode.ForAppending, true);
			} else {
				ErrTextstream = fso.OpenTextFile(_4PosBackOffice.NET.My.MyProject.Application.Info.DirectoryPath + "\\4POSHOStatusErrLog.log", Scripting.IOMode.ForWriting, true);
			}
			ErrTextstream.Write(tempStatus);
			ErrTextstream.Close();
			//TEST PURPOSE
			 // ERROR: Not supported in C#: ResumeStatement

		}

		public void SleepFor(double Seconds)
		{
			// "Sleep" for the specified number of seconds.
			System.DateTime EndTime = default(System.DateTime);
			EndTime = DateAndTime.DateAdd(Microsoft.VisualBasic.DateInterval.Second, Seconds, DateAndTime.Now);
			do {
				System.Windows.Forms.Application.DoEvents();
			} while (!(DateAndTime.Now >= EndTime));
		}


		private void Automatico()
		{
			cmdPulsante_Click(cmdPulsante[0], new System.EventArgs());
			cmdPulsante_Click(cmdPulsante[6], new System.EventArgs());
			cmdPulsante_Click(cmdPulsante[7], new System.EventArgs());
			cmdPulsante_Click(cmdPulsante[1], new System.EventArgs());
		}

		public void DownLoadFile_GRV(ref bool delRemote = false, ref string fname = "", ref string fpath = "", ref bool dirUD = false)
		{
			//Declare Variables
			bool bRet = false;
			bool bret1 = false;
			bool bret2 = false;
			string szDirRemote = null;
			string szFileRemote = null;
			string szFileLocal = null;
			string szTempString = null;
			int nPos = 0;
			int nTemp = 0;
			int hFind = 0;
			WIN32_FIND_DATA findfile = default(WIN32_FIND_DATA);
			short errore = 0;
			short Count = 0;
			//Total Files Wrong
			errore = 0;
			//Total Files
			Count = 0;
			//Checking the Connection
			Module1.dirrecv = Module1.dirsend + "/grv";
			if (Module1.bActiveSession) {
				//Set the current directory
				if (dirUD) {
					Module1.FtpSetCurrentDirectory(Module1.hConnection, Module1.dirrecv);
				} else {
					Module1.FtpSetCurrentDirectory(Module1.hConnection, Module1.dirsend);
				}
				//Beginning to Look for files
				System.Windows.Forms.Application.DoEvents();
				hFind = Module1.FtpFindFirstFile(Module1.hConnection, fname, ref findfile, 0, 0);
				if (hFind == 0) {
					Text1.Text = Text1.Text + "No file found ..." + Constants.vbCrLf;
					return;
				}
				Count = 1;
				szFileRemote = fname;
				//Trim(Mid(findfile.cFileName, 1, InStr(1, findfile.cFileName, Chr(0), vbTextCompare) - 1))
				_Label1_1.Text = szFileRemote;
				_Label1_1.Refresh();
				bRet = Module1.FtpGetFile(Module1.hConnection, szFileRemote, fpath + "/" + szFileRemote, false, Module1.INTERNET_FLAG_RELOAD, Module1.dwType, 0);
				if (bRet == false) {
					//File Log'
					Text1.Text = Text1.Text + "Error while Downloading File " + szFileRemote + " : " + Convert.ToString(Err().LastDllError) + Constants.vbCrLf;
					Text1.Refresh();
					Text1.SelectionStart = Strings.Len(Text1.Text);
					errore = errore + 1;
					updateLOG(ref "DOWNLOAD_ERROR_POINT_1", ref Convert.ToString(Err().LastDllError));
				} else {
					if (delRemote == true) {
						bret2 = Module1.FtpDeleteFile(Module1.hConnection, szFileRemote);
					}
				}
				//If bRet = False Then ErrorOut cstr(Err.LastDllError), "FtpGetFile"
				//bret1 = InternetFindNextFile(hFind, findfile)
				//While bret1 <> False
				//    szFileRemote = Trim(Mid(findfile.cFileName, 1, InStr(1, findfile.cFileName, Chr(0), vbTextCompare) - 1))
				//    Count = Count + 1
				//    _Label1_1.Caption = szFileRemote
				//    _Label1_1.Refresh
				//    bRet = FtpGetFile(hConnection, szFileRemote, dirrecv & "/" & szFileRemote, False, _
				//'    INTERNET_FLAG_RELOAD, dwType, 0)
				//    If bRet = False Then
				//        'File Log'
				//        Text1.Text = Text1.Text + "Error DownLoad File " + szFileRemote + " : " + CStr(Err.LastDllError) + vbCrLf
				//        Text1.Refresh
				//        Text1.SelStart = Len(Text1.Text)
				//        errore = errore + 1
				//    Else
				//        bret2 = FtpDeleteFile(hConnection, szFileRemote)
				//    End If
				//    bret1 = InternetFindNextFile(hFind, findfile)
				//Wend
				//_Label1_1.Caption = ""
				//File Log'
				if (errore == 0) {
					Text1.Text = Text1.Text + "Downloading completed successfully ..." + Constants.vbCrLf;
					Text1.Refresh();
					Text1.SelectionStart = Strings.Len(Text1.Text);
					lbl44.Text = "DONE";
					updateLOG(ref "DOWNLOAD_COMPLETED_1", ref "NILL");
				} else {
					Text1.Text = Text1.Text + "Download didn't Complete ..." + Constants.vbCrLf;
					Text1.Refresh();
					Text1.SelectionStart = Strings.Len(Text1.Text);
					updateLOG(ref "DOWNLOAD_NOT_COMPLETED_1", ref "NILL");
				}
				Text1.Text = Text1.Text + "Total file(s) : " + Convert.ToString(Count) + Constants.vbCrLf;
				Text1.Refresh();
				Text1.SelectionStart = Strings.Len(Text1.Text);
				Text1.Text = Text1.Text + "Error in file(s) : " + Convert.ToString(errore) + Constants.vbCrLf;
				Text1.Refresh();
				Text1.SelectionStart = Strings.Len(Text1.Text);
			}
		}

		public void DownLoadFile_DownFile(ref bool delRemote = false, ref string fname = "", ref bool dirUD = false)
		{
			//Declare Variables
			bool bRet = false;
			bool bret1 = false;
			bool bret2 = false;
			string szDirRemote = null;
			string szFileRemote = null;
			string szFileLocal = null;
			string szTempString = null;
			int nPos = 0;
			int nTemp = 0;
			int hFind = 0;
			WIN32_FIND_DATA findfile = default(WIN32_FIND_DATA);
			short errore = 0;
			short Count = 0;
			//Total Files Wrong
			errore = 0;
			//Total Files
			Count = 0;
			//Checking the Connection
			if (Module1.bActiveSession) {
				//Set the current directory
				if (dirUD) {
					Module1.FtpSetCurrentDirectory(Module1.hConnection, Module1.dirrecv);
				} else {
					Module1.FtpSetCurrentDirectory(Module1.hConnection, Module1.dirsend);
				}
				//Beginning to Look for files
				System.Windows.Forms.Application.DoEvents();
				hFind = Module1.FtpFindFirstFile(Module1.hConnection, fname, ref findfile, 0, 0);
				if (hFind == 0) {
					Text1.Text = Text1.Text + "No file found ..." + Constants.vbCrLf;
					return;
				}
				Count = 1;
				szFileRemote = fname;
				//Trim(Mid(findfile.cFileName, 1, InStr(1, findfile.cFileName, Chr(0), vbTextCompare) - 1))
				_Label1_1.Text = szFileRemote;
				_Label1_1.Refresh();
				bRet = Module1.FtpGetFile(Module1.hConnection, szFileRemote, gPathHO + "/" + szFileRemote, false, Module1.INTERNET_FLAG_RELOAD, Module1.dwType, 0);
				if (bRet == false) {
					//File Log'
					Text1.Text = Text1.Text + "Error while Downloading File " + szFileRemote + " : " + Convert.ToString(Err().LastDllError) + Constants.vbCrLf;
					Text1.Refresh();
					Text1.SelectionStart = Strings.Len(Text1.Text);
					errore = errore + 1;
					updateLOG(ref "DOWNLOAD_ERROR_POINT_1", ref Convert.ToString(Err().LastDllError));
				} else {
					if (delRemote == true) {
						bret2 = Module1.FtpDeleteFile(Module1.hConnection, szFileRemote);
					}
				}
				//If bRet = False Then ErrorOut cstr(Err.LastDllError), "FtpGetFile"
				//bret1 = InternetFindNextFile(hFind, findfile)
				//While bret1 <> False
				//    szFileRemote = Trim(Mid(findfile.cFileName, 1, InStr(1, findfile.cFileName, Chr(0), vbTextCompare) - 1))
				//    Count = Count + 1
				//    _Label1_1.Caption = szFileRemote
				//    _Label1_1.Refresh
				//    bRet = FtpGetFile(hConnection, szFileRemote, dirrecv & "/" & szFileRemote, False, _
				//'    INTERNET_FLAG_RELOAD, dwType, 0)
				//    If bRet = False Then
				//        'File Log'
				//        Text1.Text = Text1.Text + "Error DownLoad File " + szFileRemote + " : " + CStr(Err.LastDllError) + vbCrLf
				//        Text1.Refresh
				//        Text1.SelStart = Len(Text1.Text)
				//        errore = errore + 1
				//    Else
				//        bret2 = FtpDeleteFile(hConnection, szFileRemote)
				//    End If
				//    bret1 = InternetFindNextFile(hFind, findfile)
				//Wend
				//_Label1_1.Caption = ""
				//File Log'
				if (errore == 0) {
					Text1.Text = Text1.Text + "Downloading completed successfully ..." + Constants.vbCrLf;
					Text1.Refresh();
					Text1.SelectionStart = Strings.Len(Text1.Text);
					lbl44.Text = "DONE";
					updateLOG(ref "DOWNLOAD_COMPLETED_1", ref "NILL");
				} else {
					Text1.Text = Text1.Text + "Download didn't Complete ..." + Constants.vbCrLf;
					Text1.Refresh();
					Text1.SelectionStart = Strings.Len(Text1.Text);
					updateLOG(ref "DOWNLOAD_NOT_COMPLETED_1", ref "NILL");
				}
				Text1.Text = Text1.Text + "Total file(s) : " + Convert.ToString(Count) + Constants.vbCrLf;
				Text1.Refresh();
				Text1.SelectionStart = Strings.Len(Text1.Text);
				Text1.Text = Text1.Text + "Error in file(s) : " + Convert.ToString(errore) + Constants.vbCrLf;
				Text1.Refresh();
				Text1.SelectionStart = Strings.Len(Text1.Text);
			}
		}

		public void DownLoadFile_DownTxt(ref bool delRemote = false, ref bool dirUD = false)
		{
			//Declare Variables
			bool bRet = false;
			bool bret1 = false;
			bool bret2 = false;
			string szDirRemote = null;
			string szFileRemote = null;
			string szFileLocal = null;
			string szTempString = null;
			int nPos = 0;
			int nTemp = 0;
			int hFind = 0;
			WIN32_FIND_DATA findfile = default(WIN32_FIND_DATA);
			short errore = 0;
			short Count = 0;
			//Total Files Wrong
			errore = 0;
			//Total Files
			Count = 0;
			//Checking the Connection
			if (Module1.bActiveSession) {
				//Set the current directory
				if (dirUD) {
					Module1.FtpSetCurrentDirectory(Module1.hConnection, Module1.dirrecv);
				} else {
					Module1.FtpSetCurrentDirectory(Module1.hConnection, Module1.dirsend);
				}
				//Beginning to Look for files
				hFind = Module1.FtpFindFirstFile(Module1.hConnection, "4pos_download.txt", ref findfile, 0, 0);
				if (hFind == 0) {
					Text1.Text = Text1.Text + "No one else is busy Downloading/Uploading ..." + Constants.vbCrLf;
					return;
				}
				Count = 1;
				szFileRemote = "4pos_download.txt";
				//Trim(Mid(findfile.cFileName, 1, InStr(1, findfile.cFileName, Chr(0), vbTextCompare) - 1))
				_Label1_1.Text = szFileRemote;
				_Label1_1.Refresh();
				bRet = Module1.FtpGetFile(Module1.hConnection, szFileRemote, gPathHO + "/" + szFileRemote, false, Module1.INTERNET_FLAG_RELOAD, Module1.dwType, 0);
				if (bRet == false) {
					//File Log'
					Text1.Text = Text1.Text + "Error while Downloading File " + szFileRemote + " : " + Convert.ToString(Err().LastDllError) + Constants.vbCrLf;
					Text1.Refresh();
					Text1.SelectionStart = Strings.Len(Text1.Text);
					errore = errore + 1;
				} else {
					if (delRemote == true) {
						bret2 = Module1.FtpDeleteFile(Module1.hConnection, szFileRemote);
					}
				}
				//If bRet = False Then ErrorOut cstr(Err.LastDllError), "FtpGetFile"
				//bret1 = InternetFindNextFile(hFind, findfile)
				//While bret1 <> False
				//    szFileRemote = Trim(Mid(findfile.cFileName, 1, InStr(1, findfile.cFileName, Chr(0), vbTextCompare) - 1))
				//    Count = Count + 1
				//    _Label1_1.Caption = szFileRemote
				//    _Label1_1.Refresh
				//    bRet = FtpGetFile(hConnection, szFileRemote, dirrecv & "/" & szFileRemote, False, _
				//'    INTERNET_FLAG_RELOAD, dwType, 0)
				//    If bRet = False Then
				//        'File Log'
				//        Text1.Text = Text1.Text + "Error DownLoad File " + szFileRemote + " : " + CStr(Err.LastDllError) + vbCrLf
				//        Text1.Refresh
				//        Text1.SelStart = Len(Text1.Text)
				//        errore = errore + 1
				//    Else
				//        bret2 = FtpDeleteFile(hConnection, szFileRemote)
				//    End If
				//    bret1 = InternetFindNextFile(hFind, findfile)
				//Wend
				//_Label1_1.Caption = ""
				//File Log'
				if (errore == 0) {
					Text1.Text = Text1.Text + "Downloading completed successfully ..." + Constants.vbCrLf;
					Text1.Refresh();
					Text1.SelectionStart = Strings.Len(Text1.Text);
					lbl44.Text = "DONE";
				} else {
					Text1.Text = Text1.Text + "Download didn't Complete ..." + Constants.vbCrLf;
					Text1.Refresh();
					Text1.SelectionStart = Strings.Len(Text1.Text);
				}
				Text1.Text = Text1.Text + "Total file(s) : " + Convert.ToString(Count) + Constants.vbCrLf;
				Text1.Refresh();
				Text1.SelectionStart = Strings.Len(Text1.Text);
				Text1.Text = Text1.Text + "Error in File(s) : " + Convert.ToString(errore) + Constants.vbCrLf;
				Text1.Refresh();
				Text1.SelectionStart = Strings.Len(Text1.Text);
			}
		}

		public void DownLoadFile_UpTxt(ref bool delRemote = false, ref bool dirUD = false)
		{
			//Declare Variables
			bool bRet = false;
			bool bret1 = false;
			bool bret2 = false;
			string szDirRemote = null;
			string szFileRemote = null;
			string szFileLocal = null;
			string szTempString = null;
			int nPos = 0;
			int nTemp = 0;
			int hFind = 0;
			WIN32_FIND_DATA findfile = default(WIN32_FIND_DATA);
			short errore = 0;
			short Count = 0;
			//Total Files Wrong
			errore = 0;
			//Total Files
			Count = 0;
			//Checking the Connection
			if (Module1.bActiveSession) {
				//Set the current directory
				if (dirUD) {
					Module1.FtpSetCurrentDirectory(Module1.hConnection, Module1.dirrecv);
				} else {
					Module1.FtpSetCurrentDirectory(Module1.hConnection, Module1.dirsend);
				}
				//Beginning to Look for files
				hFind = Module1.FtpFindFirstFile(Module1.hConnection, "4pos_upload.txt", ref findfile, 0, 0);
				if (hFind == 0) {
					Text1.Text = Text1.Text + "No one else is busy Downloading/Uploading ..." + Constants.vbCrLf;
					return;
				}
				Count = 1;
				szFileRemote = "4pos_upload.txt";
				//Trim(Mid(findfile.cFileName, 1, InStr(1, findfile.cFileName, Chr(0), vbTextCompare) - 1))
				_Label1_1.Text = szFileRemote;
				_Label1_1.Refresh();
				bRet = Module1.FtpGetFile(Module1.hConnection, szFileRemote, gPathHO + "download\\" + "/" + szFileRemote, false, Module1.INTERNET_FLAG_RELOAD, Module1.dwType, 0);
				if (bRet == false) {
					//File Log'
					Text1.Text = Text1.Text + "Error while Downloading File " + szFileRemote + " : " + Convert.ToString(Err().LastDllError) + Constants.vbCrLf;
					Text1.Refresh();
					Text1.SelectionStart = Strings.Len(Text1.Text);
					errore = errore + 1;
				} else {
					if (delRemote == true) {
						bret2 = Module1.FtpDeleteFile(Module1.hConnection, szFileRemote);
					}
				}
				//If bRet = False Then ErrorOut cstr(Err.LastDllError), "FtpGetFile"
				//bret1 = InternetFindNextFile(hFind, findfile)
				//While bret1 <> False
				//    szFileRemote = Trim(Mid(findfile.cFileName, 1, InStr(1, findfile.cFileName, Chr(0), vbTextCompare) - 1))
				//    Count = Count + 1
				//    _Label1_1.Caption = szFileRemote
				//    _Label1_1.Refresh
				//    bRet = FtpGetFile(hConnection, szFileRemote, dirrecv & "/" & szFileRemote, False, _
				//'    INTERNET_FLAG_RELOAD, dwType, 0)
				//    If bRet = False Then
				//        'File Log'
				//        Text1.Text = Text1.Text + "Error DownLoad File " + szFileRemote + " : " + CStr(Err.LastDllError) + vbCrLf
				//        Text1.Refresh
				//        Text1.SelStart = Len(Text1.Text)
				//        errore = errore + 1
				//    Else
				//        bret2 = FtpDeleteFile(hConnection, szFileRemote)
				//    End If
				//    bret1 = InternetFindNextFile(hFind, findfile)
				//Wend
				//_Label1_1.Caption = ""
				//File Log'
				if (errore == 0) {
					Text1.Text = Text1.Text + "Downloading completed successfully ..." + Constants.vbCrLf;
					Text1.Refresh();
					Text1.SelectionStart = Strings.Len(Text1.Text);
					lbl44.Text = "DONE";
				} else {
					Text1.Text = Text1.Text + "Download didn't Complete ..." + Constants.vbCrLf;
					Text1.Refresh();
					Text1.SelectionStart = Strings.Len(Text1.Text);
				}
				Text1.Text = Text1.Text + "Total file(s) : " + Convert.ToString(Count) + Constants.vbCrLf;
				Text1.Refresh();
				Text1.SelectionStart = Strings.Len(Text1.Text);
				Text1.Text = Text1.Text + "Error in File(s) : " + Convert.ToString(errore) + Constants.vbCrLf;
				Text1.Refresh();
				Text1.SelectionStart = Strings.Len(Text1.Text);
			}
		}

		public void DownLoadFile()
		{
			string lDir = null;
			string szFileConPath = null;
			string dirsendLocal = null;
			//Declare Variables
			bool bRet = false;
			bool bret1 = false;
			bool bret2 = false;
			string szDirRemote = null;
			string szFileRemote = null;
			string szFileLocal = null;
			string szTempString = null;
			int nPos = 0;
			int nTemp = 0;
			int hFind = 0;
			WIN32_FIND_DATA findfile = default(WIN32_FIND_DATA);
			short errore = 0;
			short Count = 0;
			string lString = null;
			string lStringToday = null;
			//Total Files Wrong
			errore = 0;
			//Total Files
			Count = 0;

			updateStatus(ref "Starting Download");
			updateLOG(ref "DOWNLOAD_START_POINT", ref "NILL");

			//Checking the Connection
			CGUnzipFiles zLimsU = new CGUnzipFiles();
			if (Module1.bActiveSession) {
				//Set the current directory
				Module1.FtpSetCurrentDirectory(Module1.hConnection, Module1.dirrecv);

				if (fso.FileExists(gPathHO + "4pos_download.txt"))
					fso.DeleteFile(gPathHO + "4pos_download.txt", true);
				Module1.dwType = Module1.FTP_TRANSFER_TYPE_ASCII;
				//DownLoadFile
				DownLoadFile_DownTxt(ref false, ref true);
				if (fso.FileExists(gPathHO + "4pos_download.txt")) {
					//MsgBox "One of branch/headoffice still busy."
					//Exit Sub
				}

				tempStatus = Module1.BranchID + "|" + DateAndTime.Now;
				ErrTextstream = fso.OpenTextFile(gPathHO + "4pos_download.txt", Scripting.IOMode.ForWriting, true);
				ErrTextstream.Write(tempStatus);
				ErrTextstream.Close();

				dirsendLocal = gPathHO;
				szFileLocal = "4pos_download.txt";
				_Label1_1.Text = szFileLocal;
				_Label1_1.Refresh();
				System.Windows.Forms.Application.DoEvents();
				szFileConPath = dirsendLocal + szFileLocal;
				szFileRemote = szFileLocal;
				if ((string.IsNullOrEmpty(szDirRemote)))
					szDirRemote = "\\";
				rcd(ref szDirRemote);

				bRet = Module1.FtpPutFile(Module1.hConnection, szFileConPath, szFileRemote, Module1.dwType, 0);
				if (bRet == false) {
					//File Log'
					//            Text1.Text = Text1.Text + "Error while Uploading File : " + CStr(Err.LastDllError) + vbCrLf
					//            Text1.Refresh
					//            DoEvents
					//            Text1.SelStart = Len(Text1.Text)
					//            errore = errore + 1
				}

				lStringToday = Strings.Replace(Convert.ToString(DateAndTime.Now), " ", "_");
				lStringToday = Strings.Replace(lStringToday, "/", "-");
				lStringToday = Strings.Replace(lStringToday, ":", "");
				if (fso.FolderExists(gPathHO + "download\\" + lStringToday)) {
				} else {
					fso.CreateFolder(gPathHO + "download\\" + lStringToday);
				}

				fso.CopyFile(modRecordSet.serverPath + "pricing.mdb", gPathHO + "download\\" + lStringToday + "\\pricing.mdb", true);
				fso.CopyFile(modRecordSet.serverPath + "waitron.mdb", gPathHO + "download\\" + lStringToday + "\\waitron.mdb", true);

				if (fso.FileExists(gPathHO + "download\\" + "4pos_upload.txt"))
					fso.DeleteFile(gPathHO + "download\\" + "4pos_upload.txt", true);
				Module1.dwType = Module1.FTP_TRANSFER_TYPE_ASCII;
				DownLoadFile_UpTxt(ref false, ref true);
				if (fso.FileExists(gPathHO + "download\\" + "4pos_upload.txt")) {
					fso.MoveFile(gPathHO + "download\\" + "4pos_upload.txt", gPathHO + "download\\" + lStringToday + "\\4pos_upload.txt");
					ErrTextstream = fso.OpenTextFile(gPathHO + "download\\" + lStringToday + "\\4pos_upload.txt", Scripting.IOMode.ForReading, true);
					lString = ErrTextstream.ReadAll;
					ErrTextstream.Close();
				} else {
					Interaction.MsgBox("Upload information file not found on server. Please upload from HO again.");
					return;
				}

				//Beginning to Look for files
				System.Windows.Forms.Application.DoEvents();
				cmdPulsante_Click(cmdPulsante[1], new System.EventArgs());
				cmdPulsante_Click(cmdPulsante[0], new System.EventArgs());
				System.Windows.Forms.Application.DoEvents();
				Module1.FtpSetCurrentDirectory(Module1.hConnection, Module1.dirrecv);
				System.Windows.Forms.Application.DoEvents();
				Module1.dwType = Module1.FTP_TRANSFER_TYPE_BINARY;

				//        If BranchType = "1" Then
				//            DownLoadFile_DownFile False, lString, True ' & "_hqsales*.zip"
				//
				//                Count = 1
				//                If fso.FileExists(gPathHO & lString) Then fso.MoveFile gPathHO & lString, gPathHO & "download\" & lStringToday & "\" & lString
				//                If fso.FolderExists(serverPath & "SalesTransaction") Then
				//                Else
				//                    fso.CreateFolder serverPath & "SalesTransaction"
				//                End If
				//                lDir = Dir(serverPath & "SalesTransaction\*.*")
				//                Do Until lDir = ""
				//                    fso.DeleteFile serverPath & "SalesTransaction\" & lDir, True
				//                    lDir = Dir()
				//                Loop
				//                If fso.FileExists(gPathHO & "download\" & lStringToday & "\" & lString) Then fso.CopyFile gPathHO & "download\" & lStringToday & "\" & lString, serverPath & ("hqsales" & Split(lString, "hqsales")(1)), True
				//
				//                Dim zLims As New ZipIt.CGUnzipFiles
				//                zLims.HonorDirectories = False
				//                zLims.Unzip serverPath & ("hqsales" & Split(lString, "hqsales")(1)), serverPath & "SalesTransaction"
				//
				//        Else
				//hFind = FtpFindFirstFile(hConnection, lString & "_data.zip", findfile, 0, 0)
				DownLoadFile_DownFile(ref false, ref lString + "_data.zip", ref true);

				Count = 1;
				if (fso.FileExists(gPathHO + lString + "_data.zip"))
					fso.MoveFile(gPathHO + lString + "_data.zip", gPathHO + "download\\" + lStringToday + "\\" + lString + "_data.zip");
				if (fso.FolderExists(modRecordSet.serverPath + "update")) {
				} else {
					fso.CreateFolder(modRecordSet.serverPath + "update");
				}
				lDir = FileSystem.Dir(modRecordSet.serverPath + "update\\*.*");
				while (!(string.IsNullOrEmpty(lDir))) {
					fso.DeleteFile(modRecordSet.serverPath + "update\\" + lDir, true);
					lDir = FileSystem.Dir();
				}
				if (fso.FileExists(gPathHO + "download\\" + lStringToday + "\\" + lString + "_data.zip"))
					fso.CopyFile(gPathHO + "download\\" + lStringToday + "\\" + lString + "_data.zip", modRecordSet.serverPath + "data.zip", true);

				zLimsU.HonorDirectories = false;
				zLimsU.Unzip(ref modRecordSet.serverPath + "data.zip", ref modRecordSet.serverPath + "update");
				//        End If

				System.Windows.Forms.Application.DoEvents();
				cmdPulsante_Click(cmdPulsante[1], new System.EventArgs());
				cmdPulsante_Click(cmdPulsante[0], new System.EventArgs());
				System.Windows.Forms.Application.DoEvents();
				Module1.FtpSetCurrentDirectory(Module1.hConnection, Module1.dirrecv);
				System.Windows.Forms.Application.DoEvents();
				Module1.dwType = Module1.FTP_TRANSFER_TYPE_ASCII;
				DownLoadFile_DownTxt(ref true, ref true);
				System.Windows.Forms.Application.DoEvents();
				DownLoadFile_DownTxt(ref true, ref true);

				_Label1_1.Text = "";
				//File Log'
				if (errore == 0) {
					Text1.Text = Text1.Text + "Downloading completed successfully ..." + Constants.vbCrLf;
					Text1.Refresh();
					Text1.SelectionStart = Strings.Len(Text1.Text);
					lbl44.Text = "DONE";

					updateLOG(ref "DOWNLOAD_COMPLETED", ref "NILL");
				} else {
					Text1.Text = Text1.Text + "Download didn't Complete ..." + Constants.vbCrLf;
					Text1.Refresh();
					Text1.SelectionStart = Strings.Len(Text1.Text);
					updateLOG(ref "DOWNLOAD_NOT_COMPLETED", ref "NILL");
				}
				Text1.Text = Text1.Text + "Total file(s) : " + Convert.ToString(Count) + Constants.vbCrLf;
				Text1.Refresh();
				Text1.SelectionStart = Strings.Len(Text1.Text);
				Text1.Text = Text1.Text + "Error in File(s) : " + Convert.ToString(errore) + Constants.vbCrLf;
				Text1.Refresh();
				Text1.SelectionStart = Strings.Len(Text1.Text);
			}
		}


		private void DisconnettiServer()
		{
			//Connect to Server Closed
			if (Module1.hConnection != 0)
				InternetCloseHandle(ref Module1.hConnection);
			Module1.hConnection = 0;

			if (Module1.sqlDBcn == null) {
			} else {
				if (Module1.sqlDBcn.State) {
					updateLOG(ref "DISCONNECTED", ref "NILL");
					Module1.sqlDBcn.Close();
				}
			}
		}


		private void DisconnettiInternet()
		{
			//Closing Internet
			if (Module1.hOpen != 0)
				InternetCloseHandle(ref Module1.hOpen);
			lbl66.Text = "DONE";
			Module1.hOpen = 0;
		}

		private void rcd(ref string pszDir)
		{
			string sPathFromRoot = null;
			bool bRet = false;
			if (!string.IsNullOrEmpty(pszDir)) {
				if (Strings.InStr(1, pszDir, Module1.server)) {
					sPathFromRoot = Strings.Mid(pszDir, Strings.Len(Module1.server) + 1, Strings.Len(pszDir) - Strings.Len(Module1.server));
				} else {
					sPathFromRoot = pszDir;
				}
				if (string.IsNullOrEmpty(sPathFromRoot))
					sPathFromRoot = "/";
				bRet = Module1.FtpSetCurrentDirectory(Module1.hConnection, sPathFromRoot);
			}
		}

		private void ScriviFileLog()
		{
			short iFile = 0;
			iFile = FileSystem.FreeFile();
			FileSystem.FileOpen(iFile, Module1.NomeFileLog, OpenMode.Append);
			FileSystem.PrintLine(iFile, Text1.Text);
			FileSystem.FileClose(iFile);

		}

		public ADODB.Recordset getRSMaster(ref object sql)
		{
			ADODB.Recordset functionReturnValue = default(ADODB.Recordset);
			object cnnDBmaster = null;
			functionReturnValue = new ADODB.Recordset();
			functionReturnValue.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
			functionReturnValue.Open(sql, cnnDBmaster, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
			return functionReturnValue;
		}

		public bool openConnectionWaitron()
		{
			bool functionReturnValue = false;
			 // ERROR: Not supported in C#: OnErrorStatement

			bool createDayend = false;
			string strDBPath = null;
			createDayend = false;
			functionReturnValue = true;
			cnnDBWaitron = new ADODB.Connection();
			strDBPath = modRecordSet.serverPath + "Waitron.mdb";
			var _with2 = cnnDBWaitron;
			_with2.Provider = "Microsoft.ACE.OLEDB.12.0";
			_with2.Properties("Jet OLEDB:System Database").Value = modRecordSet.serverPath + "Secured.mdw";
			_with2.Open(strDBPath, "liquid", "lqd");
			return functionReturnValue;
			openConnection_Error:

			functionReturnValue = false;
			return functionReturnValue;

		}
		public void closeConnectionWaitron()
		{
			cnnDBWaitron.Close();
			cnnDBWaitron = null;
		}
		public ADODB.Recordset getRSwaitron(ref object sql)
		{
			ADODB.Recordset functionReturnValue = default(ADODB.Recordset);
			functionReturnValue = new ADODB.Recordset();
			functionReturnValue.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
			functionReturnValue.Open(sql, cnnDBWaitron, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
			return functionReturnValue;
		}

		private void cmdBuild_Click(ref string zipPath = "")
		{
			string szFileLocal = null;
			string TMPgMasterPath = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			//Dim fso As New FileSystemObject
			string lDir = null;
			 // ERROR: Not supported in C#: OnErrorStatement

			//If MsgBox("A data instruction will prepare a download for each store of the latest stock and pricing data." & vbCrLf & vbCrLf & "Are you sure you wish to continue?", vbQuestion + vbYesNo + vbDefaultButton2, "Prepare Download") = vbYes Then

			TMPgMasterPath = gMasterPath;
			gMasterPath = gPathHO + "upload\\" + zipPath + "\\";
			//serverPath '"c:\4POSServer\"

			if (fso.FolderExists(gMasterPath + "Data\\")) {
			} else {
				fso.CreateFolder(gMasterPath + "Data\\");
			}
			lDir = FileSystem.Dir(gMasterPath + "data\\*.*");
			while (!(string.IsNullOrEmpty(lDir))) {
				fso.DeleteFile(gMasterPath + "data\\" + lDir, true);
				lDir = FileSystem.Dir();
			}
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			System.Windows.Forms.Application.DoEvents();
			rs = modRecordSet.getRS(ref "SELECT 1 as MasterID, #" + DateAndTime.Today + "# as Master_DateReplica");
			rs.Save(gMasterPath + "Data\\Master.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM Catalogue");
			rs.Save(gMasterPath + "Data\\catalogue.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM PriceSet");
			rs.Save(gMasterPath + "Data\\PriceSet.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM Channel ORDER BY ChannelID");
			rs.Save(gMasterPath + "Data\\channel.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM Deposit ORDER BY DepositID");
			rs.Save(gMasterPath + "Data\\Deposit.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM PackSize ORDER BY PackSizeID");
			rs.Save(gMasterPath + "Data\\PackSize.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM Person ORDER BY PersonID");
			rs.Save(gMasterPath + "Data\\Person.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM PersonChannelLnk");
			rs.Save(gMasterPath + "Data\\PersonChannelLnk.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM PriceChannelLnk");
			rs.Save(gMasterPath + "Data\\PriceChannelLnk.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM PricingGroup ORDER BY PricingGroupID");
			rs.Save(gMasterPath + "Data\\PricingGroup.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM PricingGroupChannelLnk");
			rs.Save(gMasterPath + "Data\\PricingGroupChannelLnk.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM PropChannelLnk");
			rs.Save(gMasterPath + "Data\\PropChannelLnk.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM [Set] ORDER BY SetID");
			rs.Save(gMasterPath + "Data\\Set.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM SetItem");
			rs.Save(gMasterPath + "Data\\SetItem.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM Shrink ORDER BY ShrinkID");
			rs.Save(gMasterPath + "Data\\Shrink.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM ShrinkItem");
			rs.Save(gMasterPath + "Data\\ShrinkItem.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM StockGroup ORDER BY StockGroupID");
			rs.Save(gMasterPath + "Data\\StockGroup.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM StockItem ORDER BY StockItemID");
			rs.Save(gMasterPath + "Data\\stockitem.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM Supplier ORDER BY SupplierID");
			rs.Save(gMasterPath + "Data\\Supplier.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM SupplierDepositLnk");
			rs.Save(gMasterPath + "Data\\SupplierDepositLnk.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM Promotion");
			rs.Save(gMasterPath + "Data\\Promotion.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM PromotionItem");
			rs.Save(gMasterPath + "Data\\PromotionItem.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM StockBreak");
			rs.Save(gMasterPath + "Data\\StockBreak.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM RecipeStockItemLnk");
			rs.Save(gMasterPath + "Data\\RecipeStockItemLnk.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM CashTransaction");
			rs.Save(gMasterPath + "Data\\CashTransaction.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM Increment");
			rs.Save(gMasterPath + "Data\\Increment.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM IncrementStockItemLnk");
			rs.Save(gMasterPath + "Data\\IncrementStockItemLnk.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM IncrementQuantity");
			rs.Save(gMasterPath + "Data\\IncrementQuantity.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM Message");
			rs.Save(gMasterPath + "Data\\Message.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM MessageItem");
			rs.Save(gMasterPath + "Data\\MessageItem.rs", ADODB.PersistFormatEnum.adPersistADTG);
			rs = modRecordSet.getRS(ref "SELECT * FROM StockItemMessageLnk");
			rs.Save(gMasterPath + "Data\\StockItemMessageLnk.rs", ADODB.PersistFormatEnum.adPersistADTG);
			openConnectionWaitron();
			rs = getRSwaitron(ref "SELECT * FROM POSMenu");
			rs.Save(gMasterPath + "Data\\POSMenu.rs", ADODB.PersistFormatEnum.adPersistADTG);

			//ExecCmd gMasterPath & "wzzip.exe " & gMasterPath & "Data\data.zip " & gMasterPath & "Data\*.*"
			if (fso.FileExists(gMasterPath + zipPath + "_data.zip"))
				fso.DeleteFile(gMasterPath + zipPath + "_data.zip", true);

			CGZipFiles zLims = new CGZipFiles();
			zLims.ZipFileName = gMasterPath + zipPath + "_data.zip";
			//zLims.RecurseFolders = False
			szFileLocal = FileSystem.Dir(gMasterPath + "Data\\*.*");
			while (!string.IsNullOrEmpty(szFileLocal)) {
				zLims.AddFile(gMasterPath + "Data\\" + szFileLocal);
				szFileLocal = FileSystem.Dir();
			}
			zLims.MakeZipFile();

			//fso.CopyFile gMasterPath & "Data\data.zip", gMasterPath & "Data.zip", True

			//        Set rs = getRSMaster("SELECT locationCompany_1.locationCompanyID, locationCompany.locationCompany_Email FROM locationCompany INNER JOIN (locationCompany AS locationCompany_1 INNER JOIN location ON locationCompany_1.locationCompany_LocationID = location.locationID) ON locationCompany.locationCompany_LocationID = location.locationID WHERE (((locationCompany_1.locationCompanyID)=" & lblCompany.Tag & "));")
			//
			//        On Local Error Resume Next
			//        MAPISession1.SignOn
			//        MAPIMessages1.SessionID = MAPISession1.SessionID
			//        MAPIMessages1.Compose
			//        x = -1
			//        On Local Error Resume Next
			//        Do Until rs.EOF
			//
			//            If rs("locationCompany_Email") <> "" Then
			//                x = x + 1
			//                MAPIMessages1.RecipIndex = x
			//                MAPIMessages1.RecipDisplayName = rs("locationCompany_Email")
			//                MAPIMessages1.ResolveName
			//            End If
			//
			//            rs.MoveNext
			//        Loop
			//        Set rs = getRSMaster("SELECT locationAudit.locationAuditID, locationAudit.locationAudit_Email FROM locationCompany INNER JOIN locationAudit ON locationCompany.locationCompany_LocationID = locationAudit.locationAudit_LocationID WHERE (((locationCompany.locationCompanyID)=" & lblCompany.Tag & "));")
			//        Do Until rs.EOF
			//            x = x + 1
			//            MAPIMessages1.RecipIndex = x
			//            MAPIMessages1.RecipDisplayName = rs("locationAudit_Email")
			//            MAPIMessages1.ResolveName
			//            rs.MoveNext
			//        Loop
			//        MAPIMessages1.MsgSubject = "4POS Data"
			//        MAPIMessages1.MsgNoteText = "4POS Pricing update as at " & Format(Now(), "ddd, dd-mmm-yyyy hh:nn")
			//        MAPIMessages1.AttachmentType = mapData
			//        MAPIMessages1.AttachmentName = "data.zip"
			//        MAPIMessages1.AttachmentPathName = gMasterPath & "data.zip"
			//        MAPIMessages1.Send
			//        MAPISession1.SignOff

			gMasterPath = TMPgMasterPath;
			//End If
			this.Cursor = System.Windows.Forms.Cursors.Default;

			return;
			buildError:
			if (Err().Number == 53) {
				Interaction.MsgBox("Please ensure if you have 'WinZip Command Line Support Add-On' installed on your system.");
			} else {
				Interaction.MsgBox(Err().Number + " " + Err().Description);
			}
			 // ERROR: Not supported in C#: ResumeStatement

		}

		private void UpLoad()
		{
			string sql = null;
			bool bRet = false;
			string szDirRemote = null;
			string szFileRemote = null;
			string szFileLocal = null;
			string szTempString = null;
			string szFileConPath = null;
			short errore = 0;
			short Count = 0;
			string dirsendLocal = null;
			string lString = null;
			string zipname = null;

			Count = 0;
			errore = 0;

			updateStatus(ref "Starting Upload");
			updateLOG(ref "UPLOAD_START_POINT", ref "NILL");

			if (Module1.bActiveSession) {
				szTempString = Module1.server + Module1.dirsend;
				//'dirserv
				szDirRemote = Strings.Right(szTempString, Strings.Len(szTempString) - Strings.Len(Module1.server));

				//If BranchType = "1" Then

				if (fso.FileExists(gPathHO + "4pos_download.txt"))
					fso.DeleteFile(gPathHO + "4pos_download.txt", true);
				Module1.dwType = Module1.FTP_TRANSFER_TYPE_ASCII;
				//DownLoadFile
				DownLoadFile_DownTxt();
				if (fso.FileExists(gPathHO + "4pos_download.txt")) {
					//MsgBox "One of branch/headoffice still busy."
					//Exit Sub
				}

				tempStatus = Module1.BranchID + "|" + DateAndTime.Now;
				ErrTextstream = fso.OpenTextFile(gPathHO + "4pos_download.txt", Scripting.IOMode.ForWriting, true);
				ErrTextstream.Write(tempStatus);
				ErrTextstream.Close();

				dirsendLocal = gPathHO;
				szFileLocal = "4pos_download.txt";
				_Label1_1.Text = szFileLocal;
				_Label1_1.Refresh();
				System.Windows.Forms.Application.DoEvents();
				szFileConPath = dirsendLocal + szFileLocal;
				szFileRemote = szFileLocal;
				if ((string.IsNullOrEmpty(szDirRemote)))
					szDirRemote = "\\";
				rcd(ref szDirRemote);

				bRet = Module1.FtpPutFile(Module1.hConnection, szFileConPath, szFileRemote, Module1.dwType, 0);
				if (bRet == false) {
					//File Log'
					Text1.Text = Text1.Text + "Error while Uploading File : " + Convert.ToString(Err().LastDllError) + Constants.vbCrLf;
					Text1.Refresh();
					System.Windows.Forms.Application.DoEvents();
					Text1.SelectionStart = Strings.Len(Text1.Text);
					errore = errore + 1;
				}

				zipname = "";

				if (Module1.BranchType == "1") {
					lString = Strings.Replace(Convert.ToString(DateAndTime.Now), " ", "_");
					lString = Strings.Replace(lString, "/", "-");
					lString = Strings.Replace(lString, ":", "");

					if (fso.FolderExists(gPathHO + "upload\\" + lString)) {
					} else {
						fso.CreateFolder(gPathHO + "upload\\" + lString);
					}

					Module1.dwType = Module1.FTP_TRANSFER_TYPE_BINARY;
					cmdBuild_Click(ref lString);

					dirsendLocal = gPathHO + "upload\\" + lString + "\\";
					//serverPath
					szFileLocal = lString + "_data.zip";

					Count = Count + 1;
					_Label1_1.Text = szFileLocal;
					_Label1_1.Refresh();
					System.Windows.Forms.Application.DoEvents();
					szFileConPath = dirsendLocal + szFileLocal;
					szFileRemote = szFileLocal;
					if ((string.IsNullOrEmpty(szDirRemote)))
						szDirRemote = "\\";
					rcd(ref szDirRemote);
					bRet = Module1.FtpPutFile(Module1.hConnection, szFileConPath, szFileRemote, Module1.dwType, 0);
					if (bRet == false) {
						//File Log'
						Text1.Text = Text1.Text + "Error while Uploading File : " + Convert.ToString(Err().LastDllError) + Constants.vbCrLf;
						Text1.Refresh();
						System.Windows.Forms.Application.DoEvents();
						Text1.SelectionStart = Strings.Len(Text1.Text);
						errore = errore + 1;

						updateLOG(ref "UPLOAD_ERROR_POINT_1", ref Convert.ToString(Err().LastDllError));
					}

					//File Log'
					if (errore == 0) {
						Text1.Text = Text1.Text + "Uploading completed successfully ..." + Constants.vbCrLf;
						Text1.Refresh();
						Text1.SelectionStart = Strings.Len(Text1.Text);
						lbl33.Text = "DONE";

						updateLOG(ref "UPLOAD_COMPLETED", ref "NILL");
						sql = "UPDATE HeadOffice SET HeadOffice_LastLoginUser='" + My.MyProject.Forms.frmMenu.lblUser.Text + "', HeadOffice_LastLoginBranch=(SELECT Branch_Name FROM Branch WHERE BranchID=" + Convert.ToInt32(Module1.BranchID) + "), HeadOffice_LastUpdate='" + DateAndTime.Now + "' WHERE HeadOfficeID=" + Convert.ToInt32(Module1.HOfficeID) + ";";
						Module1.sqlDBcn.Execute(sql);
					} else {
						Text1.Text = Text1.Text + "Upload didn't Complete ..." + Constants.vbCrLf;
						Text1.Refresh();

						updateLOG(ref "UPLOAD_NOT_COMPLETED", ref "NILL");
					}
					Text1.Text = Text1.Text + "Total file(s) : " + Convert.ToString(Count) + Constants.vbCrLf;
					Text1.Refresh();
					Text1.SelectionStart = Strings.Len(Text1.Text);
					Text1.Text = Text1.Text + "Error in File(s) : " + Convert.ToString(errore) + Constants.vbCrLf;
					Text1.Refresh();
					Text1.SelectionStart = Strings.Len(Text1.Text);
					_Label1_1.Text = "";


				} else {
					//                    lString = Replace(Now, " ", "_")
					//                    lString = Replace(lString, "/", "-")
					//                    lString = Replace(lString, ":", "")
					//
					//                    If fso.FolderExists(gPathHO & "upload\" & lString) Then Else fso.CreateFolder gPathHO & "upload\" & lString
					//
					//                    dwType = FTP_TRANSFER_TYPE_BINARY
					//                    If copyFilesFromPoints(lString) Then Else Exit Sub
					//
					//                    Dim rj        As Recordset
					//                    'Dim zipName   As String
					//                    Set rj = getRS("SELECT * FROM CompanyEmails")
					//                    If rj.RecordCount Then
					//                         zipname = lString & "_hqsales" & rj("Comp_ID") & ".zip"
					//                    Else
					//                         zipname = lString & "_hqsales.zip"
					//                    End If
					//
					//                     If fso.FileExists(gPathHO & "upload\" & lString & "\" & zipname) Then fso.DeleteFile gPathHO & "upload\" & lString & "\" & zipname, True
					//
					//                     Dim zLims As New ZipIt.CGZipFiles
					//                     zLims.ZipFileName = gPathHO & "upload\" & lString & "\" & zipname
					//                     zLims.RecurseFolders = False
					//
					//                    szFileLocal = Dir(gPathHO & "upload\" & lString & "\" & "HQSales\*.*")
					//                    While szFileLocal <> ""
					//                        zLims.AddFile gPathHO & "upload\" & lString & "\" & "HQSales\" & szFileLocal
					//                        szFileLocal = Dir
					//                    Wend
					//                    zLims.MakeZipFile
					//
					//                    dirsendLocal = gPathHO & "upload\" & lString & "\"
					//                    szFileLocal = zipname
					//
					//                    Count = Count + 1
					//                    _Label1_1.Caption = szFileLocal
					//                    _Label1_1.Refresh
					//                    DoEvents
					//                    szFileConPath = dirsendLocal + szFileLocal
					//                    szFileRemote = szFileLocal
					//                    If (szDirRemote = "") Then szDirRemote = "\"
					//                    rcd szDirRemote
					//                    bRet = FtpPutFile(hConnection, szFileConPath, szFileRemote, _
					//'                     dwType, 0)
					//                    If bRet = False Then
					//                        'File Log'
					//                        Text1.Text = Text1.Text + "Error while Uploading File : " + CStr(Err.LastDllError) + vbCrLf
					//                        Text1.Refresh
					//                        DoEvents
					//                        Text1.SelStart = Len(Text1.Text)
					//                        errore = errore + 1
					//                    End If
					//
					//                    'File Log'
					//                    If errore = 0 Then
					//                        Text1.Text = Text1.Text + "Uploading completed successfully ..." + vbCrLf
					//                        Text1.Refresh
					//                        Text1.SelStart = Len(Text1.Text)
					//                        lbl33 = "DONE"
					//                    Else
					//                        Text1.Text = Text1.Text + "Upload didn't Complete ..." + vbCrLf
					//                        Text1.Refresh
					//
					//                    End If
					//                    Text1.Text = Text1.Text + "Total file(s) : " + CStr(Count) + vbCrLf
					//                    Text1.Refresh
					//                    Text1.SelStart = Len(Text1.Text)
					//                    Text1.Text = Text1.Text + "Error in File(s) : " + CStr(errore) + vbCrLf
					//                    Text1.Refresh
					//                    Text1.SelStart = Len(Text1.Text)
					//                    _Label1_1.Caption = ""


				}

				if (fso.FileExists(gPathHO + "upload\\" + "4pos_upload.txt"))
					fso.DeleteFile(gPathHO + "upload\\" + "4pos_upload.txt", true);
				Module1.dwType = Module1.FTP_TRANSFER_TYPE_ASCII;

				tempStatus = (string.IsNullOrEmpty(zipname) ? lString : zipname);
				//Now()
				ErrTextstream = fso.OpenTextFile(gPathHO + "upload\\" + "4pos_upload.txt", Scripting.IOMode.ForWriting, true);
				ErrTextstream.Write(tempStatus);
				ErrTextstream.Close();

				dirsendLocal = gPathHO + "upload\\";
				szFileLocal = "4pos_upload.txt";
				_Label1_1.Text = szFileLocal;
				_Label1_1.Refresh();
				System.Windows.Forms.Application.DoEvents();
				szFileConPath = dirsendLocal + szFileLocal;
				szFileRemote = szFileLocal;
				if ((string.IsNullOrEmpty(szDirRemote)))
					szDirRemote = "\\";
				rcd(ref szDirRemote);

				bRet = Module1.FtpPutFile(Module1.hConnection, szFileConPath, szFileRemote, Module1.dwType, 0);
				if (bRet == false) {
					//File Log'
					Text1.Text = Text1.Text + "Error while Uploading File : " + Convert.ToString(Err().LastDllError) + Constants.vbCrLf;
					Text1.Refresh();
					System.Windows.Forms.Application.DoEvents();
					Text1.SelectionStart = Strings.Len(Text1.Text);
					errore = errore + 1;
					updateLOG(ref "UPLOAD_ERROR_POINT_2", ref Convert.ToString(Err().LastDllError));
				}

				DownLoadFile_DownTxt(true);
				System.Windows.Forms.Application.DoEvents();
				DownLoadFile_DownTxt(true);
				//-------------------------------------------------------------------
				//Else
				//End If




			}

			updateStatus(ref "Finishing Upload");
			updateLOG(ref "UPLOAD_END_POINT", ref "NILL");
		}


		private bool copyFilesFromPoints(ref string zipPath = "")
		{
			bool functionReturnValue = false;
			bool sFiles = false;
			string f_File = null;
			string ldir1 = null;
			string strFile = null;
			ADODB.Recordset rj = default(ADODB.Recordset);
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			System.DateTime DTPDate = default(System.DateTime);

			sFiles = false;
			//UPGRADE_WARNING: Couldn't resolve default property of object DTPicker1().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DTPDate = _DTPicker1_0.Value;
			gMasterPath = gPathHO + "upload\\" + zipPath + "\\";

			f_File = Strings.Trim(Conversion.Str(DateAndTime.Year(DTPDate))) + "\\" + Strings.Trim(Conversion.Str(DateAndTime.Month(DTPDate))) + "\\" + Strings.Trim(Conversion.Str(DateAndTime.Day(DTPDate)));

			rj = modRecordSet.getRS(ref "SELECT POS_Name FROM POS WHERE POS_Disabled = False AND POS_KitchenMonitor = False;");

			if (rj.RecordCount) {
				//If FSO.FolderExists(serverPath & "HQSales") Then Else FSO.CreateFolder serverPath & "HQSales"
				if (fso.FolderExists(gMasterPath + "HQSales")) {
				} else {
					fso.CreateFolder(gMasterPath + "HQSales");
				}

				//Make sure the HQSales file is empty...
				ldir1 = FileSystem.Dir(gMasterPath + "HQSales\\*.*");
				while (!(string.IsNullOrEmpty(ldir1))) {
					fso.DeleteFile(gMasterPath + "HQSales\\" + ldir1, true);
					ldir1 = FileSystem.Dir();
				}

				while (rj.EOF == false) {
					if (Strings.LCase(rj.Fields("POS_Name").Value) == "localhost") {
						if (fso.FolderExists(modRecordSet.serverPath + "data\\Server\\" + f_File)) {
							ldir1 = FileSystem.Dir(modRecordSet.serverPath + "data\\Server\\" + f_File + "\\*.*");
							while (!(string.IsNullOrEmpty(ldir1))) {
								fso.CopyFile(modRecordSet.serverPath + "data\\Server\\" + f_File + "\\" + ldir1, gMasterPath + "HQSales\\" + ldir1, true);
								ldir1 = FileSystem.Dir();
								sFiles = true;
							}
						}
					} else {
						if (fso.FolderExists(modRecordSet.serverPath + "data\\" + rj.Fields("POS_Name").Value + "\\" + f_File)) {
							ldir1 = FileSystem.Dir(modRecordSet.serverPath + "data\\" + rj.Fields("POS_Name").Value + "\\" + f_File + "\\*.*");
							while (!(string.IsNullOrEmpty(ldir1))) {
								fso.CopyFile(modRecordSet.serverPath + "data\\" + rj.Fields("POS_Name").Value + "\\" + f_File + "\\" + ldir1, gMasterPath + "HQSales\\" + ldir1, true);
								ldir1 = FileSystem.Dir();
								sFiles = true;
							}

						}
					}
					rj.MoveNext();
				}
			}

			if (sFiles == true) {
				functionReturnValue = true;
			} else {
				functionReturnValue = false;
			}
			return functionReturnValue;

		}

		private bool ConnessioneInternet()
		{
			bool functionReturnValue = false;
			//***********************
			//Internet connection
			//***********************
			Module1.hOpen = InternetOpen(Module1.scUserAgent, INTERNET_OPEN_TYPE_DIRECT, Constants.vbNullString, Constants.vbNullString, 0);
			if (Module1.hOpen == 0) {
				//File Log'
				functionReturnValue = false;
				return functionReturnValue;
			} else {
				//File Log'
				lbl11.Text = "DONE";
				functionReturnValue = true;
				return functionReturnValue;
			}
			return functionReturnValue;
		}

		private bool ConnessioneServer()
		{
			bool functionReturnValue = false;
			string sql = null;
			string j = null;
			string s = null;
			int x = 0;
			int y = 0;

			int nflag = 0;
			if (Convert.ToDouble(Module1.tipftp) == 1) {
				nflag = Module1.INTERNET_FLAG_PASSIVE;
			} else {
				nflag = 0;
			}

			string getServer = null;
			string ServerU = null;
			string ServerP = null;

			getServer = SendAPIRequest(Module1.ServerN);
			Debug.Print(getServer);
			if (string.IsNullOrEmpty(Strings.Trim(getServer))) {
				lbl11.Text = "No server Found!";
				Module1.bActiveSession = false;
				functionReturnValue = false;
				return functionReturnValue;
			} else {
				y = 0;
				for (x = 1; x <= Strings.Len(getServer); x++) {
					if (y == 2) {
						s = s + " " + Strings.Mid(getServer, x, 1);
						y = 0;
					} else {
						s = s + Strings.Mid(getServer, x, 1);
					}
					y = y + 1;
				}
				Text2.Text = s;
				Text3.Text = modHEX.HexToStr(Text2.Text);
				for (x = 1; x <= Strings.Len(Text3.Text); x++) {
					if (x == 3) {
						//s = s & "1" & Mid(Text1, x, 1)
					} else if (x == 8) {
						//s = s & "1" & Mid(Text1, x, 1)
					} else {
						j = j + Strings.Mid(Text3.Text, x, 1);
					}
				}
				Text4.Text = j;
				Text4.Text = a.DecryptString(Text4.Text, "786YaAllah0zoi", true);

				if (Strings.InStr(1, Strings.Trim(Text4.Text), "|")) {
					if (Information.UBound(Strings.Split(Text4.Text, "|")) == 2) {
						Module1.server = Strings.Split(Text4.Text, "|")[0];
						ServerU = Strings.Split(Text4.Text, "|")[1];
						ServerP = Strings.Split(Text4.Text, "|")[2];
					} else {
						Module1.bActiveSession = false;
						functionReturnValue = false;
						return functionReturnValue;
					}
				} else {
					Module1.bActiveSession = false;
					functionReturnValue = false;
					return functionReturnValue;
				}
			}


			getServer = SendAPIRequest(Module1.sqlLinkPath);
			Debug.Print(getServer);
			if (string.IsNullOrEmpty(Strings.Trim(getServer))) {
				lbl11.Text = "No server Found!";
				Module1.bActiveSession = false;
				functionReturnValue = false;
				return functionReturnValue;
			} else {
				y = 0;
				s = "";
				j = "";
				for (x = 1; x <= Strings.Len(getServer); x++) {
					if (y == 2) {
						s = s + " " + Strings.Mid(getServer, x, 1);
						y = 0;
					} else {
						s = s + Strings.Mid(getServer, x, 1);
					}
					y = y + 1;
				}
				Text2.Text = s;
				Text3.Text = modHEX.HexToStr(Text2.Text);
				for (x = 1; x <= Strings.Len(Text3.Text); x++) {
					if (x == 3) {
						//s = s & "1" & Mid(Text1, x, 1)
					} else if (x == 8) {
						//s = s & "1" & Mid(Text1, x, 1)
					} else {
						j = j + Strings.Mid(Text3.Text, x, 1);
					}
				}
				Text4.Text = j;
				Text4.Text = a.DecryptString(Text4.Text, "786YaAllah0zoi", true);

				if (Strings.InStr(1, Strings.Trim(Text4.Text), "|")) {
					if (Information.UBound(Strings.Split(Text4.Text, "|")) == 3) {
						Module1.sqlServer = Strings.Split(Text4.Text, "|")[0];
						Module1.sqlDBase = Strings.Split(Text4.Text, "|")[1];
						Module1.sqlUser = Strings.Split(Text4.Text, "|")[2];
						Module1.sqlPassWord = Strings.Split(Text4.Text, "|")[3];
					} else {
						Module1.bActiveSession = false;
						functionReturnValue = false;
						return functionReturnValue;
					}
				} else {
					Module1.bActiveSession = false;
					functionReturnValue = false;
					return functionReturnValue;
				}
			}

			Module1.hConnection = Module1.InternetConnect(Module1.hOpen, Module1.server, Module1.INTERNET_INVALID_PORT_NUMBER, ServerU, ServerP, Module1.INTERNET_SERVICE_FTP, nflag, 0);
			if (Module1.hConnection == 0) {
				Module1.bActiveSession = false;
				functionReturnValue = false;
				return functionReturnValue;

			} else {
				//sql
				Module1.sqlDBcn = new ADODB.Connection();
				Module1.sqlDBcn.ConnectionString = "PROVIDER=MSDASQL;driver={SQL Server};server=" + Module1.sqlServer + ";uid=" + Module1.sqlUser + ";pwd=" + Module1.sqlPassWord + ";database=" + Module1.sqlDBase + ";";
				Module1.sqlDBcn.Open();
				if (Module1.sqlDBcn == null) {
					Text1.Text = Text1.Text + "Error in Data Server Connection : " + Convert.ToString(Convert.ToString(Err().LastDllError)) + Constants.vbCrLf;
					Text1.Refresh();
					Text1.SelectionStart = Strings.Len(Text1.Text);
					Module1.bActiveSession = false;
					functionReturnValue = false;
					return functionReturnValue;
				} else {
					if (Module1.sqlDBcn.State) {
						//cnWebSql.Close
					} else {
						Text1.Text = Text1.Text + "Error in Data Server Connection : " + Convert.ToString(Convert.ToString(Err().LastDllError)) + Constants.vbCrLf;
						Text1.Refresh();
						Text1.SelectionStart = Strings.Len(Text1.Text);
						Module1.bActiveSession = false;
						functionReturnValue = false;
						return functionReturnValue;
					}
				}

				//HEADOFFICE ------------------------
				rsWebDB = new ADODB.Recordset();
				sql = "SELECT HeadOffice_Path FROM HeadOffice WHERE (HeadOffice.HeadOfficeID = " + Convert.ToInt16(Module1.HOfficeID) + ");";
				var _with3 = rsWebDB;
				_with3.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
				_with3.CursorType = ADODB.CursorTypeEnum.adOpenForwardOnly;
				_with3.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic;
				_with3.let_Source(sql);
				_with3.ActiveConnection = Module1.sqlDBcn;
				_with3.Open();
				_with3.let_ActiveConnection(null);
				if (rsWebDB.RecordCount) {
					if (Information.IsDBNull(rsWebDB.Fields("HeadOffice_Path").Value)) {
						updateStatus(ref "Web path not found for Headoffice # " + Module1.HOfficeID);
						Module1.bActiveSession = false;
						functionReturnValue = false;
						return functionReturnValue;
					} else {
						if (Module1.BranchType == "1") {
							Module1.dirsend = rsWebDB.Fields("HeadOffice_Path").Value;
							Module1.dirrecv = rsWebDB.Fields("HeadOffice_Path").Value;
						} else {
							Module1.dirrecv = rsWebDB.Fields("HeadOffice_Path").Value;
						}
						Module1.dirserv = "/httpsdocs/HeadOffice";
					}
				} else {
					updateStatus(ref "No information found for Headoffice # " + Module1.HOfficeID);
					Module1.bActiveSession = false;
					functionReturnValue = false;
					return functionReturnValue;
				}

				//BRANCH ------------------------
				rsWebDB = new ADODB.Recordset();
				sql = "SELECT Branch_Path FROM Branch WHERE (Branch.BranchID = " + Convert.ToInt16(Module1.BranchID) + ");";
				var _with4 = rsWebDB;
				_with4.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
				_with4.CursorType = ADODB.CursorTypeEnum.adOpenForwardOnly;
				_with4.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic;
				_with4.let_Source(sql);
				_with4.ActiveConnection = Module1.sqlDBcn;
				_with4.Open();
				_with4.let_ActiveConnection(null);
				if (rsWebDB.RecordCount) {
					if (Information.IsDBNull(rsWebDB.Fields("Branch_Path").Value)) {
						updateStatus(ref "Web path not found for Branch # " + Module1.HOfficeID);
						Module1.bActiveSession = false;
						functionReturnValue = false;
						return functionReturnValue;
					} else {
						if (Module1.BranchType == "0") {
							Module1.dirsend = rsWebDB.Fields("Branch_Path").Value;
						} else {
							//dirrecv = rsWebDB("Branch_Path")
						}
						Module1.dirserv = "/httpdocs/HeadOffice";
					}
				} else {
					updateStatus(ref "No information found for Branch # " + Module1.HOfficeID);
					Module1.bActiveSession = false;
					functionReturnValue = false;
					return functionReturnValue;
				}

				updateLOG(ref "CONNECTED", ref "NILL");

				//ftp
				Module1.bActiveSession = true;
				functionReturnValue = true;
				lbl22.Text = "DONE";
				return functionReturnValue;
			}
			return functionReturnValue;

		}

		private void cmdPulsante_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int Index = 0;
			TextBox txtBox = new TextBox();
			txtBox = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref txtBox, ref cmdPulsante);
			string sql = null;
			object frmSetup = null;

			string lString = null;
			bool bGetFail = false;
			string lDir = null;
			switch (Index) {

				case 0:
					//***********************
					//Connet
					//***********************
					Text1.Text = Text1.Text + "***************************************************************" + Constants.vbCrLf;
					Text1.Text = Text1.Text + "Date           : " + Strings.Format(DateAndTime.Now, "dd/mm/yyyy") + Constants.vbCrLf;
					Text1.Text = Text1.Text + "Time           : " + Strings.Format(DateAndTime.Now, "hh:mm:ss") + Constants.vbCrLf;
					//Text1.Text = Text1.Text + "User           : " + prgCol + vbCrLf
					Text1.Text = Text1.Text + "***************************************************************" + Constants.vbCrLf;
					Text1.Text = Text1.Text + "Starting Internet Connection ..." + Constants.vbCrLf;
					Text1.Refresh();
					Text1.SelectionStart = Strings.Len(Text1.Text);
					if (!ConnessioneInternet()) {
						Text1.Text = Text1.Text + "Error with Internet Connection : " + Convert.ToString(Err().LastDllError) + Constants.vbCrLf;
						Text1.Refresh();
						Text1.SelectionStart = Strings.Len(Text1.Text);
						return;
					} else {
						Text1.Text = Text1.Text + "Internet Connection Complete ..." + Constants.vbCrLf;
						Text1.Refresh();
						Text1.SelectionStart = Strings.Len(Text1.Text);
						//File Log'
						Text1.Text = Text1.Text + "Starting Server Connection ..." + Constants.vbCrLf;
						Text1.Refresh();
						Text1.SelectionStart = Strings.Len(Text1.Text);
						if (!ConnessioneServer()) {
							//File Log'
							Text1.Text = Text1.Text + "Error with Server Connection : " + Convert.ToString(Convert.ToString(Err().LastDllError)) + Constants.vbCrLf;
							Text1.Refresh();
							Text1.SelectionStart = Strings.Len(Text1.Text);
							return;
						} else {
							//File Log'
							Text1.Text = Text1.Text + "Server Connection Complete ..." + Constants.vbCrLf;
							Text1.Refresh();
							Text1.SelectionStart = Strings.Len(Text1.Text);
						}
						Module1.PreparaForm();
					}
					break;
				case 1:
					//***********************
					//Disconnet
					//***********************
					DisconnettiServer();
					DisconnettiInternet();
					Text1.Text = Text1.Text + "Server Disconnection Complete ..." + Constants.vbCrLf;
					Text1.Text = Text1.Text + "*************************Fine*******************************" + Constants.vbCrLf;
					Text1.Refresh();
					Text1.SelectionStart = Strings.Len(Text1.Text);
					ScriviFileLog();
					Module1.bActiveSession = false;
					Module1.PreparaForm();
					break;
				case 2:
					//***********************
					//Setup INI
					//***********************
					frmSet frm = new frmSet();
					frmSetup.Show();
					break;
				case 3:
					//*******************************************
					//For automatic loading and saving
					//*******************************************
					Automatico();
					System.Environment.Exit(0);
					break;
				case 4:
					//***********************
					//exit
					//***********************
					System.Environment.Exit(0);
					break;
				case 5:
					//***********************
					//Opening Log Files
					//***********************
					Interaction.Shell("notepad.exe " + Module1.NomeFileLog, AppWinStyle.NormalFocus);
					break;
				case 6:
					//***********************
					//UpLoad
					//***********************
					Module1.PreparaForm(ref "UpLoad");

					updateLOG(ref "UPLOAD_LOGGED_IN", ref "NILL");
					//check
					updateStatus(ref "Checking for database booking...");

					rsWebDB = new ADODB.Recordset();
					sql = "SELECT HeadOffice.*, (SELECT Branch_Name FROM Branch WHERE BranchID=" + Convert.ToInt32(Module1.BranchID) + ") AS sBranch FROM HeadOffice WHERE (HeadOffice.HeadOfficeID = " + Convert.ToInt16(Module1.HOfficeID) + ");";
					var _with5 = rsWebDB;
					_with5.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
					_with5.CursorType = ADODB.CursorTypeEnum.adOpenForwardOnly;
					_with5.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic;
					_with5.let_Source(sql);
					_with5.ActiveConnection = Module1.sqlDBcn;
					_with5.Open();
					//UPGRADE_NOTE: Object rsWebDB.ActiveConnection may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					_with5.let_ActiveConnection(null);
					if (rsWebDB.RecordCount) {
						if (rsWebDB.Fields("HeadOffice_BookedOut").Value) {
							if (Strings.UCase(rsWebDB.Fields("HeadOffice_BookedOutUser").Value) != Strings.UCase(My.MyProject.Forms.frmMenu.lblUser.Text)) {
								updateStatus(ref "The database has been booked out by " + Strings.UCase(rsWebDB.Fields("HeadOffice_BookedOutUser").Value));
								updateStatus(ref " at " + Strings.UCase(rsWebDB.Fields("HeadOffice_BookedOutBranch").Value) + " on " + rsWebDB.Fields("HeadOffice_BookedOutDate").Value);
								updateStatus(ref "Please ask relevant person to Book it in. If this is you then click Book In.");
								return;
							} else {
								if (Module1.BranchType == "1") {
									if (Strings.UCase(rsWebDB.Fields("HeadOffice_BookedOutBranch").Value) == Strings.UCase(Strings.UCase(rsWebDB.Fields("HeadOffice_Name").Value))) {
									} else {
										updateStatus(ref "The database has been booked out by " + Strings.UCase(rsWebDB.Fields("HeadOffice_BookedOutUser").Value));
										updateStatus(ref " at " + Strings.UCase(rsWebDB.Fields("HeadOffice_BookedOutBranch").Value) + " on " + rsWebDB.Fields("HeadOffice_BookedOutDate").Value);
										updateStatus(ref "Please ask relevant person to Book it in. If this is you then click Book In.");
										return;
									}
								} else {
									if (Strings.UCase(rsWebDB.Fields("HeadOffice_BookedOutBranch").Value) == Strings.UCase(Strings.UCase(rsWebDB.Fields("sBranch").Value))) {
									} else {
										updateStatus(ref "The database has been booked out by " + Strings.UCase(rsWebDB.Fields("HeadOffice_BookedOutUser").Value));
										updateStatus(ref " at " + Strings.UCase(rsWebDB.Fields("HeadOffice_BookedOutBranch").Value) + " on " + rsWebDB.Fields("HeadOffice_BookedOutDate").Value);
										updateStatus(ref "Please ask relevant person to Book it in. If this is you then click Book In.");
										return;
									}
								}
							}
						} else {
							if (Module1.BranchType == "1") {
								sql = "UPDATE HeadOffice SET HeadOffice_BookedOut=1, HeadOffice_BookedOutUser='" + My.MyProject.Forms.frmMenu.lblUser.Text + "', HeadOffice_BookedOutBranch=HeadOffice_Name, HeadOffice_BookedOutDate='" + DateAndTime.Now + "' WHERE HeadOfficeID=" + Convert.ToInt32(Module1.HOfficeID) + ";";
							} else {
								sql = "UPDATE HeadOffice SET HeadOffice_BookedOut=1, HeadOffice_BookedOutUser='" + My.MyProject.Forms.frmMenu.lblUser.Text + "', HeadOffice_BookedOutBranch=(SELECT Branch_Name FROM Branch WHERE BranchID=" + Convert.ToInt32(Module1.BranchID) + "), HeadOffice_BookedOutDate='" + DateAndTime.Now + "' WHERE HeadOfficeID=" + Convert.ToInt32(Module1.HOfficeID) + ";";
							}
							Module1.sqlDBcn.Execute(sql);
							updateLOG(ref "BOOKED_OUT", ref "NILL");
							updateStatus(ref "Database booked out to you...");
						}
					} else {
						updateStatus(ref "No information found for Headoffice.");
						return;
					}

					UpLoad();
					sql = "UPDATE HeadOffice SET HeadOffice_BookedOut=0 WHERE HeadOfficeID=" + Convert.ToInt32(Module1.HOfficeID) + ";";
					Module1.sqlDBcn.Execute(sql);
					updateLOG(ref "BOOKED_IN", ref "NILL");
					updateStatus(ref "Database booked in...");

					updateLOG(ref "UPLOAD_LOGGED_OUT", ref "NILL");
					Module1.PreparaForm(ref "UpLoadFine");
					break;
				case 7:
					//***********************
					//DownLoad
					//***********************
					Module1.PreparaForm(ref "DownLoad");

					updateLOG(ref "DOWNLOAD_LOGGED_IN", ref "NILL");
					//check
					updateStatus(ref "Checking for database booking...");

					rsWebDB = new ADODB.Recordset();
					sql = "SELECT HeadOffice.*, (SELECT Branch_Name FROM Branch WHERE BranchID=" + Convert.ToInt32(Module1.BranchID) + ") AS sBranch FROM HeadOffice WHERE (HeadOffice.HeadOfficeID = " + Convert.ToInt16(Module1.HOfficeID) + ");";
					var _with6 = rsWebDB;
					_with6.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
					_with6.CursorType = ADODB.CursorTypeEnum.adOpenForwardOnly;
					_with6.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic;
					_with6.let_Source(sql);
					_with6.ActiveConnection = Module1.sqlDBcn;
					_with6.Open();
					_with6.let_ActiveConnection(null);
					if (rsWebDB.RecordCount) {
						if (rsWebDB.Fields("HeadOffice_BookedOut").Value) {
							updateStatus(ref "The database has been booked out by " + Strings.UCase(rsWebDB.Fields("HeadOffice_BookedOutUser").Value));
							updateStatus(ref " at " + Strings.UCase(rsWebDB.Fields("HeadOffice_BookedOutBranch").Value) + " on " + rsWebDB.Fields("HeadOffice_BookedOutDate").Value);
							updateStatus(ref "Please ask relevant person to Book it in. If this is you then click Book In.");
							return;
						} else {
							if (Module1.BranchType == "1") {
								sql = "UPDATE HeadOffice SET HeadOffice_BookedOut=1, HeadOffice_BookedOutUser='" + My.MyProject.Forms.frmMenu.lblUser.Text + "', HeadOffice_BookedOutBranch=HeadOffice_Name, HeadOffice_BookedOutDate='" + DateAndTime.Now + "' WHERE HeadOfficeID=" + Convert.ToInt32(Module1.HOfficeID) + ";";
							} else {
								sql = "UPDATE HeadOffice SET HeadOffice_BookedOut=1, HeadOffice_BookedOutUser='" + My.MyProject.Forms.frmMenu.lblUser.Text + "', HeadOffice_BookedOutBranch=(SELECT Branch_Name FROM Branch WHERE BranchID=" + Convert.ToInt32(Module1.BranchID) + "), HeadOffice_BookedOutDate='" + DateAndTime.Now + "' WHERE HeadOfficeID=" + Convert.ToInt32(Module1.HOfficeID) + ";";
							}
							Module1.sqlDBcn.Execute(sql);
							updateLOG(ref "BOOKED_OUT", ref "NILL");
							updateStatus(ref "Database booked out to you...");
						}
					} else {
						updateStatus(ref "No information found for Headoffice.");
						return;
					}

					DownLoadFile();

					if (Module1.BranchType == "0") {
						sql = "UPDATE HeadOffice SET HeadOffice_BookedOut=0 WHERE HeadOfficeID=" + Convert.ToInt32(Module1.HOfficeID) + ";";
						Module1.sqlDBcn.Execute(sql);
						updateLOG(ref "BOOKED_IN", ref "NILL");
						updateStatus(ref "Database booked in...");

						sql = "UPDATE Branch SET Branch_LastDLoadUser='" + My.MyProject.Forms.frmMenu.lblUser.Text + "', Branch_LastDLoad='" + DateAndTime.Now + "' WHERE BranchID=" + Convert.ToInt32(Module1.BranchID) + ";";
						Module1.sqlDBcn.Execute(sql);
					} else {
					}
					//            If MsgBox("Do you want to book-out this database to you?", vbYesNo) = vbNo Then
					//                sql = "UPDATE HeadOffice SET HeadOffice_BookedOut=0;"
					//                sqlDBcn.Execute sql
					//                updateLOG "BOOKED_IN", "NILL"
					//                updateStatus "Database booked in..."
					//            End If

					updateLOG(ref "DOWNLOAD_LOGGED_OUT", ref "NILL");

					DisconnettiServer();
					if (ConnessioneServer()) {
					}
					Module1.PreparaForm(ref "DownLoadFine");

					break;
				//book out
				case 8:

					updateLOG(ref "BOOKOUT_LOGGED_IN", ref "NILL");
					//check
					updateStatus(ref "Checking for database booking...");

					rsWebDB = new ADODB.Recordset();
					sql = "SELECT HeadOffice.*, (SELECT Branch_Name FROM Branch WHERE BranchID=" + Convert.ToInt32(Module1.BranchID) + ") AS sBranch FROM HeadOffice WHERE (HeadOffice.HeadOfficeID = " + Convert.ToInt16(Module1.HOfficeID) + ");";
					var _with7 = rsWebDB;
					_with7.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
					_with7.CursorType = ADODB.CursorTypeEnum.adOpenForwardOnly;
					_with7.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic;
					_with7.let_Source(sql);
					_with7.ActiveConnection = Module1.sqlDBcn;
					_with7.Open();
					_with7.let_ActiveConnection(null);
					if (rsWebDB.RecordCount) {
						if (rsWebDB.Fields("HeadOffice_BookedOut").Value) {
							updateStatus(ref "The database has been booked out by " + Strings.UCase(rsWebDB.Fields("HeadOffice_BookedOutUser").Value));
							updateStatus(ref " at " + Strings.UCase(rsWebDB.Fields("HeadOffice_BookedOutBranch").Value) + " on " + rsWebDB.Fields("HeadOffice_BookedOutDate").Value);
							updateStatus(ref "Please ask relevant person to Book it in. If this is you then click Book In.");
							return;
						} else {
							if (Module1.BranchType == "1") {
								sql = "UPDATE HeadOffice SET HeadOffice_BookedOut=1, HeadOffice_BookedOutUser='" + My.MyProject.Forms.frmMenu.lblUser.Text + "', HeadOffice_BookedOutBranch=HeadOffice_Name, HeadOffice_BookedOutDate='" + DateAndTime.Now + "' WHERE HeadOfficeID=" + Convert.ToInt32(Module1.HOfficeID) + ";";
							} else {
								sql = "UPDATE HeadOffice SET HeadOffice_BookedOut=1, HeadOffice_BookedOutUser='" + My.MyProject.Forms.frmMenu.lblUser.Text + "', HeadOffice_BookedOutBranch=(SELECT Branch_Name FROM Branch WHERE BranchID=" + Convert.ToInt32(Module1.BranchID) + "), HeadOffice_BookedOutDate='" + DateAndTime.Now + "' WHERE HeadOfficeID=" + Convert.ToInt32(Module1.HOfficeID) + ";";
							}
							Module1.sqlDBcn.Execute(sql);
							updateLOG(ref "BOOKED_OUT", ref "NILL");
							updateStatus(ref "Database booked out to you...");
						}
					} else {
						updateStatus(ref "No information found for Headoffice.");
						return;
					}

					updateLOG(ref "BOOKOUT_LOGGED_OUT", ref "NILL");

					break;
				//book In
				case 9:

					updateLOG(ref "BOOKIN_LOGGED_IN", ref "NILL");
					//check
					updateStatus(ref "Checking for database booking...");

					rsWebDB = new ADODB.Recordset();
					sql = "SELECT HeadOffice.*, (SELECT Branch_Name FROM Branch WHERE BranchID=" + Convert.ToInt32(Module1.BranchID) + ") AS sBranch FROM HeadOffice WHERE (HeadOffice.HeadOfficeID = " + Convert.ToInt16(Module1.HOfficeID) + ");";
					var _with8 = rsWebDB;
					_with8.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
					_with8.CursorType = ADODB.CursorTypeEnum.adOpenForwardOnly;
					_with8.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic;
					_with8.let_Source(sql);
					_with8.ActiveConnection = Module1.sqlDBcn;
					_with8.Open();
					_with8.let_ActiveConnection(null);
					if (rsWebDB.RecordCount) {
						if (rsWebDB.Fields("HeadOffice_BookedOut").Value) {
							if (Strings.UCase(rsWebDB.Fields("HeadOffice_BookedOutUser").Value) != Strings.UCase(My.MyProject.Forms.frmMenu.lblUser.Text)) {
								updateStatus(ref "The database has been booked out by " + Strings.UCase(rsWebDB.Fields("HeadOffice_BookedOutUser").Value));
								updateStatus(ref " at " + Strings.UCase(rsWebDB.Fields("HeadOffice_BookedOutBranch").Value) + " on " + rsWebDB.Fields("HeadOffice_BookedOutDate").Value);
								updateStatus(ref "Please ask relevant person to Book it in. If this is you then click Book In.");
							} else {
								if (Module1.BranchType == "1") {
									if (Strings.UCase(rsWebDB.Fields("HeadOffice_BookedOutBranch").Value) == Strings.UCase(Strings.UCase(rsWebDB.Fields("HeadOffice_Name").Value))) {
										sql = "UPDATE HeadOffice SET HeadOffice_BookedOut=0 WHERE HeadOfficeID=" + Convert.ToInt32(Module1.HOfficeID) + ";";
										Module1.sqlDBcn.Execute(sql);
										updateLOG(ref "BOOKED_IN", ref "NILL");
										updateStatus(ref "Database booked in.");
									} else {
										updateStatus(ref "The database has been booked out by " + Strings.UCase(rsWebDB.Fields("HeadOffice_BookedOutUser").Value));
										updateStatus(ref " at " + Strings.UCase(rsWebDB.Fields("HeadOffice_BookedOutBranch").Value) + " on " + rsWebDB.Fields("HeadOffice_BookedOutDate").Value);
										updateStatus(ref "Please ask relevant person to Book it in. If this is you then click Book In.");
									}
								} else {
									if (Strings.UCase(rsWebDB.Fields("HeadOffice_BookedOutBranch").Value) == Strings.UCase(Strings.UCase(rsWebDB.Fields("sBranch").Value))) {
										sql = "UPDATE HeadOffice SET HeadOffice_BookedOut=0 WHERE HeadOfficeID=" + Convert.ToInt32(Module1.HOfficeID) + ";";
										Module1.sqlDBcn.Execute(sql);
										updateLOG(ref "BOOKED_IN", ref "NILL");
										updateStatus(ref "Database booked in.");
									} else {
										updateStatus(ref "The database has been booked out by " + Strings.UCase(rsWebDB.Fields("HeadOffice_BookedOutUser").Value));
										updateStatus(ref " at " + Strings.UCase(rsWebDB.Fields("HeadOffice_BookedOutBranch").Value) + " on " + rsWebDB.Fields("HeadOffice_BookedOutDate").Value);
										updateStatus(ref "Please ask relevant person to Book it in. If this is you then click Book In.");
									}
								}
							}
						} else {
							updateLOG(ref "BOOKED_IN_ALREADY", ref "NILL");
							updateStatus(ref "Database already booked in.");
						}
					} else {
						updateStatus(ref "No information found for Headoffice.");
						return;
					}

					updateLOG(ref "BOOKIN_LOGGED_OUT", ref "NILL");

					break;

				//reports
				case 10:
					updateLOG(ref "REPORTS_LOGGED_IN", ref "NILL");
					//check
					updateStatus(ref "Checking reports data for selected day end...");

					Module1.bUploadReport = true;



					lString = Strings.Replace(Convert.ToString(Convert.ToDateTime(_DTPicker1_1.Value)), " ", "_");
					lString = Strings.Replace(lString, "/", "-");
					lString = Strings.Replace(lString, ":", "");

					lString = DateAndTime.Year(Convert.ToDateTime(_DTPicker1_1.Value)) + "-";
					lString = lString + (Strings.Len(DateAndTime.Month(Convert.ToDateTime(_DTPicker1_1.Value))) == 1 ? "0" + DateAndTime.Month(Convert.ToDateTime(_DTPicker1_1.Value)) : DateAndTime.Month(Convert.ToDateTime(_DTPicker1_1.Value))) + "-";
					lString = lString + (Strings.Len(DateAndTime.Day(Convert.ToDateTime(_DTPicker1_1.Value))) == 1 ? "0" + DateAndTime.Day(Convert.ToDateTime(_DTPicker1_1.Value)) : DateAndTime.Day(Convert.ToDateTime(_DTPicker1_1.Value)));

					bGetFail = false;
					if (fso.FolderExists(gPathHO + "upload\\" + lString)) {
					} else {
						fso.CreateFolder(gPathHO + "upload\\" + lString);
					}
					lDir = FileSystem.Dir(gPathHO + "upload\\" + lString + "\\*.*");
					while (!(string.IsNullOrEmpty(lDir))) {
						fso.DeleteFile(gPathHO + "upload\\" + lString + "\\" + lDir, true);
						lDir = FileSystem.Dir();
						System.Windows.Forms.Application.DoEvents();
					}

					if (fso.FolderExists(gPathHO + "upload\\" + lString + "\\done")) {
					} else {
						fso.CreateFolder(gPathHO + "upload\\" + lString + "\\done");
					}
					lDir = FileSystem.Dir(gPathHO + "upload\\" + lString + "\\done\\*.*");
					while (!(string.IsNullOrEmpty(lDir))) {
						fso.DeleteFile(gPathHO + "upload\\" + lString + "\\done\\" + lDir, true);
						lDir = FileSystem.Dir();
						System.Windows.Forms.Application.DoEvents();
					}

					modApplication.loadDayEndReport(ref gDayEndEnd, ref gPathHO + "upload\\" + lString + "\\" + lString + ".html", ref bGetFail);

					Module1.bUploadReport = false;
					if (bGetFail) {
						updateStatus(ref "Reports data for selected day end not found...");
						updateLOG(ref "REPORTS_DATA_FAIL", ref "NILL");
					} else {
						updateStatus(ref "Reports data found for selected day end...");
						updateLOG(ref "REPORTS_DATA_DONE", ref "NILL");

						updateStatus(ref "Starting Report Upload");
						updateLOG(ref "UPLOAD_RPT_START_POINT", ref "NILL");


						lDir = FileSystem.Dir(gPathHO + "upload\\" + lString + "\\*.*");
						while (!(string.IsNullOrEmpty(lDir))) {
							UpLoad_Report(ref gPathHO + "upload\\" + lString + "\\", ref lDir, ref (Strings.Right(lDir, 3) == "tml" ? false : true));
							fso.MoveFile(gPathHO + "upload\\" + lString + "\\" + lDir, gPathHO + "upload\\" + lString + "\\done\\" + lDir);
							lDir = FileSystem.Dir();
							System.Windows.Forms.Application.DoEvents();
						}

						updateStatus(ref "Finishing RPT Upload");
						updateLOG(ref "UPLOAD_END_POINT", ref "NILL");
					}

					updateLOG(ref "REPORTS_LOGGED_OUT", ref "NILL");
					break;
			}
		}

		private void UpLoad_Report(ref string sPath, ref string sFName, ref bool bType)
		{
			string sql = null;
			bool bRet = false;
			string szDirRemote = null;
			string szFileRemote = null;
			string szFileLocal = null;
			string szTempString = null;
			string szFileConPath = null;
			short errore = 0;
			short Count = 0;
			string dirsendLocal = null;
			string lString = null;
			string zipname = null;

			Count = 0;
			errore = 0;

			if (Module1.bActiveSession) {
				szTempString = Module1.server + Module1.dirsend;
				//'dirserv
				szDirRemote = Strings.Right(szTempString, Strings.Len(szTempString) - Strings.Len(Module1.server));

				//        lString = Replace(Now, " ", "_")
				//        lString = Replace(lString, "/", "-")
				//        lString = Replace(lString, ":", "")
				//        If fso.FolderExists(gPathHO & "upload\" & lString) Then Else fso.CreateFolder gPathHO & "upload\" & lString

				if (bType) {
					Module1.dwType = Module1.FTP_TRANSFER_TYPE_BINARY;
				} else {
					Module1.dwType = Module1.FTP_TRANSFER_TYPE_ASCII;
				}
				//cmdBuild_Click lString

				dirsendLocal = sPath;
				//gPathHO & "upload\" & lString & "\" 'serverPath
				szFileLocal = sFName;
				//lString & "_data.zip"

				Count = Count + 1;
				_Label1_1.Text = szFileLocal;
				_Label1_1.Refresh();
				System.Windows.Forms.Application.DoEvents();
				szFileConPath = dirsendLocal + szFileLocal;
				szFileRemote = szFileLocal;
				if ((string.IsNullOrEmpty(szDirRemote)))
					szDirRemote = "\\";
				rcd(ref szDirRemote);
				bRet = Module1.FtpPutFile(Module1.hConnection, szFileConPath, szFileRemote, Module1.dwType, 0);
				if (bRet == false) {
					//File Log'
					Text1.Text = Text1.Text + "Error while Uploading File : " + sFName + " " + Convert.ToString(Err().LastDllError) + Constants.vbCrLf;
					Text1.Refresh();
					System.Windows.Forms.Application.DoEvents();
					Text1.SelectionStart = Strings.Len(Text1.Text);
					errore = errore + 1;

					updateLOG(ref "UPLOAD_RPT_ERROR_POINT_1 " + sFName, ref Convert.ToString(Err().LastDllError));
				}

				//File Log'
				if (errore == 0) {
					Text1.Text = Text1.Text + "Uploading completed successfully ..." + Constants.vbCrLf;
					Text1.Refresh();
					Text1.SelectionStart = Strings.Len(Text1.Text);
					lbl33.Text = "DONE";

					updateLOG(ref "UPLOAD_RPT_COMPLETED", ref "NILL");
					sql = "UPDATE Branch SET Branch_LastLoginUser='" + My.MyProject.Forms.frmMenu.lblUser.Text + "', Branch_LastUpdate='" + DateAndTime.Now + "' WHERE BranchID=" + Convert.ToInt32(Module1.BranchID) + ";";
					Module1.sqlDBcn.Execute(sql);
				} else {
					Text1.Text = Text1.Text + "Upload didn't Complete ..." + Constants.vbCrLf;
					Text1.Refresh();

					updateLOG(ref "UPLOAD_RPT_NOT_COMPLETED", ref "NILL");
				}
				Text1.Text = Text1.Text + "Total file(s) : " + Convert.ToString(Count) + Constants.vbCrLf;
				Text1.Refresh();
				Text1.SelectionStart = Strings.Len(Text1.Text);
				Text1.Text = Text1.Text + "Error in File(s) : " + Convert.ToString(errore) + Constants.vbCrLf;
				Text1.Refresh();
				Text1.SelectionStart = Strings.Len(Text1.Text);
				_Label1_1.Text = "";
			}

		}

		private void tmrAutoDE_Tick(System.Object eventSender, System.EventArgs eventArgs)
		{
			tmrAutoDE.Enabled = false;
			cmdCheckWOrder.Enabled = false;
			Command2.Enabled = false;
			cmdClose.Enabled = false;
			cmdToday.Enabled = false;
			cmdUpReport.Enabled = false;
			cmdBookOut.Enabled = false;
			cmdBookIN.Enabled = false;

			Module1.bBranchChange = false;

			if (Module1.BranchType == "1") {
				Interaction.MsgBox("Option not allowed.");
				this.Close();
			}

			cmdClear_Click();
			cmdPulsante_Click(cmdPulsante[0], new System.EventArgs());
			cmdPulsante_Click(cmdPulsante[10], new System.EventArgs());
			cmdPulsante_Click(cmdPulsante[1], new System.EventArgs());

			System.Windows.Forms.Application.DoEvents();
			this.Close();
		}
	}
}
