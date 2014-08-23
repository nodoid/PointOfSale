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
	internal partial class frmMaster : System.Windows.Forms.Form
	{
		[DllImport("ODBCCP32.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
// Registry API functions
		private static extern int SQLConfigDataSource(int hWndParent, int fRequest, string lpszDriver, string lpszAttributes);

			// Add data source
		const short ODBC_ADD_DSN = 1;
			// Delete data source
		const short ODBC_REMOVE_DSN = 3;

		private struct STARTUPINFO
		{
			public int cb;
			public string lpReserved;
			public string lpDesktop;
			public string lpTitle;
			public int dwX;
			public int dwY;
			public int dwXSize;
			public int dwYSize;
			public int dwXCountChars;
			public int dwYCountChars;
			public int dwFillAttribute;
			public int dwFlags;
			public short wShowWindow;
			public short cbReserved2;
			public int lpReserved2;
			public int hStdInput;
			public int hStdOutput;
			public int hStdError;
		}

		private struct PROCESS_INFORMATION
		{
			public int hProcess;
			public int hThread;
			public int dwProcessID;
			public int dwThreadID;
		}
		[DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		private static extern int WaitForSingleObject(int hHandle, int dwMilliseconds);
		[DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

//UPGRADE_WARNING: Structure PROCESS_INFORMATION may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
//UPGRADE_WARNING: Structure STARTUPINFO may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
		private static extern int CreateProcessA(string lpApplicationName, string lpCommandLine, int lpProcessAttributes, int lpThreadAttributes, int bInheritHandles, int dwCreationFlags, int lpEnvironment, string lpCurrentDirectory, ref STARTUPINFO lpStartupInfo, ref PROCESS_INFORMATION lpProcessInformation);
		[DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		private static extern int CloseHandle(int hObject);
		[DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		private static extern int GetExitCodeProcess(int hProcess, ref int lpExitCode);

		private const int NORMAL_PRIORITY_CLASS = 0x20;
		private const short INFINITE = -1;

		ADODB.Connection cnnDBmaster;
		ADODB.Connection cnnDBWaitron;
		string gMasterPath;

		string gSecurityCode;

		string gSecKey;

		List<Label> Label1 = new List<Label>();
		private void loadLanguage()
		{

			//frmMaster = No Code        [4POS Company Loader...]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmMaster.Caption = rsLang("LanguageLayoutLnk_Description"): frmMaster.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1(2) = No Code        [Company]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(2).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(2).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblCompany = No Code/Dynamic/NA?

			//Label1(3) = No Code        [Database]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(3).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(3).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblPath = No Code/Dynamic/NA?

			//Label1(4) = No Code        [Directory]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(4).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(4).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblDir = No Code/Dynamic/NA?

			//Label1(0) = No Code        [User ID]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(0).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2490;
			//Password|Checked
			if (modRecordSet.rsLang.RecordCount){_Label1_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_Label1_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1389;
			//OK|Checked
			if (modRecordSet.rsLang.RecordCount){cmdOK.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdOK.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//cmdBuild = No Code         [Synchronize Via Email]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdBuild.Caption = rsLang("LanguageLayoutLnk_Description"): cmdBuild.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//NOTE: Caption has a spelling mistake!!!
			//frmRegister = No Code      [Unregistered Version]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmRegister.Caption = rsLang("LanguageLayoutLnk_Description"): frmRegister.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_0 = No Code           [Store Name]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdRegistration = No Code  [Registration]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdRegistration.Caption = rsLang("LanguageLayoutLnk_Description"): cmdRegistration.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmMaster.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private int ExecCmd(ref string cmdline)
		{
			int ret = 0;
			PROCESS_INFORMATION proc = default(PROCESS_INFORMATION);
			STARTUPINFO start = default(STARTUPINFO);

			// Initialize the STARTUPINFO structure:
			start.cb = Strings.Len(start);

			// Start the shelled application:
			ret = CreateProcessA(Constants.vbNullString, cmdline, 0, 0, 1, NORMAL_PRIORITY_CLASS, 0, Constants.vbNullString, ref start, ref proc);

			// Wait for the shelled application to finish:
			ret = WaitForSingleObject(proc.hProcess, 1);
			// INFINITE)
			GetExitCodeProcess(proc.hProcess, ref ret);
			CloseHandle(proc.hThread);
			CloseHandle(proc.hProcess);
			return ret;
		}
		private bool AddDSN(string strDSN, string strDescription, ref string strDB, ref bool delete = false)
		{
			bool functionReturnValue = false;

			//------------------------------------
			//Usage:
			// AddDSN "MyDSN", "This is a test", "C:\test\myDB.mdb"
			//------------------------------------

			 // ERROR: Not supported in C#: OnErrorStatement


			//win 7
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			Scripting.TextStream textstream = default(Scripting.TextStream);
			string lString = null;
			if (Win7Ver() == true) {
				if (fso.FileExists("C:\\4POS\\4POSWinPath.txt"))
					fso.DeleteFile("C:\\4POS\\4POSWinPath.txt", true);

				lString = Strings.Replace(strDB, "\\pricing.mdb", "\\");
				textstream = fso.OpenTextFile("C:\\4POS\\4POSWinPath.txt", Scripting.IOMode.ForWriting, true);
				textstream.Write(lString);
				textstream.Close();

			}
			//win 7


			//Set the Driver Name
			string strDriver = null;
			string strFolder = null;
			strFolder = strDB;
			while (!(Strings.Right(strFolder, 1) == "\\")) {
				strFolder = Strings.Left(strFolder, Strings.Len(strFolder) - 1);
			}
			strDriver = "Microsoft Access Driver (*.mdb)";

			//Build the attributes - Attributes must be Null separated
			string strAttributes = "";
			strAttributes = strAttributes + "DESCRIPTION=" + strDescription + Strings.Chr(0);
			strAttributes = strAttributes + "DSN=" + strDSN + Strings.Chr(0);
			//strAttributes = strAttributes & "DATABASE=" & strDB & Chr(0)
			strAttributes = strAttributes + "DBQ=" + strDB + Strings.Chr(0);
			strAttributes = strAttributes + "systemDB=" + strFolder + "Secured.mdw" + Strings.Chr(0);
			strAttributes = strAttributes + "UID=liquid" + Strings.Chr(0);
			strAttributes = strAttributes + "PWD=lqd" + Strings.Chr(0);

			//Create DSN
			functionReturnValue = SQLConfigDataSource(0, ODBC_REMOVE_DSN, strDriver, strAttributes);
			if (delete) {
			} else {
				functionReturnValue = SQLConfigDataSource(0, ODBC_ADD_DSN, strDriver, strAttributes);
			}
			functionReturnValue = true;
			return functionReturnValue;
			Hell:

			functionReturnValue = false;
			Interaction.MsgBox(Err().Description);
			return functionReturnValue;
		}

		public ADODB.Recordset getRSMaster(ref string sql)
		{
			ADODB.Recordset functionReturnValue = default(ADODB.Recordset);
			functionReturnValue = new ADODB.Recordset();
			functionReturnValue.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
			functionReturnValue.Open(sql, cnnDBmaster, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
			return functionReturnValue;
		}

		private bool getMasterDB()
		{
			bool functionReturnValue = false;
			 // ERROR: Not supported in C#: OnErrorStatement

			//getMasterDB = True
			cnnDBmaster = new ADODB.Connection();
			string filename = null;
			if (modWinVer.Win7Ver() == true) {
				filename = "c:\\4posmaster\\4posmaster.mdb";
			} else {
				filename = "4posmaster.mdb";
			}
			if (System.IO.File.Exists(filename) == true) {
				var _with1 = cnnDBmaster;
				//.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0"
				_with1.Provider = "Microsoft.ACE.OLEDB.12.0";
				_with1.Open(filename);
				//.Open()
				functionReturnValue = true;
			} else {
				functionReturnValue = false;
			}

			//cnnDBmaster.Open("4posMaster")
			//gMasterPath = Split(Split(cnnDBmaster.ConnectionString, ";DBQ=")(1), ";")(0)
			//gMasterPath = Split(LCase(gMasterPath), "4posmaster.mdb")(0) '

			//win 7
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			Scripting.TextStream textstream = default(Scripting.TextStream);
			string lString = null;
			if (modWinVer.Win7Ver() == true) {
				//If fso.FileExists("C:\4POS\4POSWinPath.txt") Then
				//    Set textstream = fso.OpenTextFile("C:\4POS\4POSWinPath.txt", ForReading, True)
				//    lString = textstream.ReadAll
				//    serverPath = lString '& "pricing.mdb"
				//Else
				//    serverPath = "C:\4POSServer\" '"pricing.mdb"
				//End If
				gMasterPath = "c:\\4posmaster\\";
				return functionReturnValue;
				//getMasterDB = True
			}
			//win 7

			gMasterPath = Strings.Split(Strings.Split(cnnDBmaster.ConnectionString, ";DBQ=")[1], ";")[0];
			gMasterPath = Strings.Split(Strings.LCase(gMasterPath), "4posmaster.mdb")[0];
			return functionReturnValue;
			openConnection_Error:
			//

			functionReturnValue = false;
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
		private void cmdBuild_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int x = 0;
			string TMPgMasterPath = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			string lDir = null;
			 // ERROR: Not supported in C#: OnErrorStatement

			if (Interaction.MsgBox("A data instruction will prepare a download for each store of the latest stock and pricing data." + Constants.vbCrLf + Constants.vbCrLf + "Are you sure you wish to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Prepare Download") == MsgBoxResult.Yes) {

				TMPgMasterPath = gMasterPath;
				gMasterPath = "c:\\4POSServer\\";

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
				rs = getRSMaster(ref "SELECT 1 as MasterID, #" + DateAndTime.Today + "# as Master_DateReplica");
				rs.save(gMasterPath + "Data\\Master.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM Catalogue");
				rs.save(gMasterPath + "Data\\catalogue.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM PriceSet");
				rs.save(gMasterPath + "Data\\PriceSet.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM Channel ORDER BY ChannelID");
				rs.save(gMasterPath + "Data\\channel.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM Deposit ORDER BY DepositID");
				rs.save(gMasterPath + "Data\\Deposit.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM PackSize ORDER BY PackSizeID");
				rs.save(gMasterPath + "Data\\PackSize.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM Person ORDER BY PersonID");
				rs.save(gMasterPath + "Data\\Person.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM PersonChannelLnk");
				rs.save(gMasterPath + "Data\\PersonChannelLnk.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM PriceChannelLnk");
				rs.save(gMasterPath + "Data\\PriceChannelLnk.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM PricingGroup ORDER BY PricingGroupID");
				rs.save(gMasterPath + "Data\\PricingGroup.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM PricingGroupChannelLnk");
				rs.save(gMasterPath + "Data\\PricingGroupChannelLnk.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM PropChannelLnk");
				rs.save(gMasterPath + "Data\\PropChannelLnk.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM [Set] ORDER BY SetID");
				rs.save(gMasterPath + "Data\\Set.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM SetItem");
				rs.save(gMasterPath + "Data\\SetItem.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM Shrink ORDER BY ShrinkID");
				rs.save(gMasterPath + "Data\\Shrink.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM ShrinkItem");
				rs.save(gMasterPath + "Data\\ShrinkItem.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM StockGroup ORDER BY StockGroupID");
				rs.save(gMasterPath + "Data\\StockGroup.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM StockItem ORDER BY StockItemID");
				rs.save(gMasterPath + "Data\\stockitem.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM Supplier ORDER BY SupplierID");
				rs.save(gMasterPath + "Data\\Supplier.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM SupplierDepositLnk");
				rs.save(gMasterPath + "Data\\SupplierDepositLnk.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM Promotion");
				rs.save(gMasterPath + "Data\\Promotion.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM PromotionItem");
				rs.save(gMasterPath + "Data\\PromotionItem.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM StockBreak");
				rs.save(gMasterPath + "Data\\StockBreak.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM RecipeStockItemLnk");
				rs.save(gMasterPath + "Data\\RecipeStockItemLnk.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM CashTransaction");
				rs.save(gMasterPath + "Data\\CashTransaction.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM Increment");
				rs.save(gMasterPath + "Data\\Increment.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM IncrementStockItemLnk");
				rs.save(gMasterPath + "Data\\IncrementStockItemLnk.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM IncrementQuantity");
				rs.save(gMasterPath + "Data\\IncrementQuantity.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM Message");
				rs.save(gMasterPath + "Data\\Message.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM MessageItem");
				rs.save(gMasterPath + "Data\\MessageItem.rs", ADODB.PersistFormatEnum.adPersistADTG);
				rs = modRecordSet.getRS(ref "SELECT * FROM StockItemMessageLnk");
				rs.save(gMasterPath + "Data\\StockItemMessageLnk.rs", ADODB.PersistFormatEnum.adPersistADTG);
				openConnectionWaitron();
				rs = getRSwaitron(ref "SELECT * FROM POSMenu");
				rs.save(gMasterPath + "Data\\POSMenu.rs", ADODB.PersistFormatEnum.adPersistADTG);

				ExecCmd(ref gMasterPath + "wzzip.exe " + gMasterPath + "Data\\data.zip " + gMasterPath + "Data\\*.*");

				if (fso.FileExists(gMasterPath + "Data.zip"))
					fso.DeleteFile(gMasterPath + "Data.zip", true);

				fso.CopyFile(gMasterPath + "Data\\data.zip", gMasterPath + "Data.zip", true);

				rs = getRSMaster(ref "SELECT locationCompany_1.locationCompanyID, locationCompany.locationCompany_Email FROM locationCompany INNER JOIN (locationCompany AS locationCompany_1 INNER JOIN location ON locationCompany_1.locationCompany_LocationID = location.locationID) ON locationCompany.locationCompany_LocationID = location.locationID WHERE (((locationCompany_1.locationCompanyID)=" + lblCompany.Tag + "));");

				 // ERROR: Not supported in C#: OnErrorStatement

				//MAPISession1.SignOn()
				//MAPIMessages1.SessionID = MAPISession1.SessionID
				//MAPIMessages1.Compose()
				x = -1;
				 // ERROR: Not supported in C#: OnErrorStatement

				while (!(rs.EOF)) {

					if (!string.IsNullOrEmpty(rs.Fields("locationCompany_Email").Value)) {
						x = x + 1;
						//MAPIMessages1.RecipIndex = x
						//MAPIMessages1.RecipDisplayName = rs.Fields("locationCompany_Email").Value
						//MAPIMessages1.ResolveName()
					}

					rs.moveNext();
				}
				rs = getRSMaster(ref "SELECT locationAudit.locationAuditID, locationAudit.locationAudit_Email FROM locationCompany INNER JOIN locationAudit ON locationCompany.locationCompany_LocationID = locationAudit.locationAudit_LocationID WHERE (((locationCompany.locationCompanyID)=" + lblCompany.Tag + "));");
				while (!(rs.EOF)) {
					x = x + 1;
					//MAPIMessages1.RecipIndex = x
					//MAPIMessages1.RecipDisplayName = rs.Fields("locationAudit_Email").Value
					//MAPIMessages1.ResolveName()
					rs.moveNext();
				}
				//MAPIMessages1.MsgSubject = "4POS Data"
				//MAPIMessages1.MsgNoteText = "4POS Pricing update as at " & Format(Now, "ddd, dd-mmm-yyyy hh:nn")
				//MAPIMessages1.AttachmentType = MSMAPI.AttachTypeConstants.mapData
				//MAPIMessages1.AttachmentName = "data.zip"
				//MAPIMessages1.AttachmentPathName = gMasterPath & "data.zip"
				//MAPIMessages1.Send()
				//MAPISession1.SignOff()

				gMasterPath = TMPgMasterPath;
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;

			return;
			buildError:
			if (Err().Number == 53) {
				Interaction.MsgBox("Please ensure if you have 'WinZip Command Line Support Add-On' installed on your system.");
			} else {
				Interaction.MsgBox(Err().Number + " " + Err().Description);
			}
		}
		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdCompany_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			cnnDBmaster.Execute("UPDATE locationCompany SET locationCompany.locationCompany_Name = '" + Strings.Replace(txtCompany.Text, "'", "''") + "' WHERE (((locationCompany.locationCompanyID)=" + lblCompany.Tag + "));");
			loadCompanies();
			lvLocation.FocusedItem = lvLocation.Items["k" + lblCompany.Tag];
			lblCompany.Text = lvLocation.FocusedItem.Text + " - " + lvLocation.FocusedItem.SubItems[0].Text;

		}

		private void cmdDatabase_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.CDmasterOpen.Title = "Select the path to " + lvLocation.FocusedItem.SubItems[0].Text + " application database ...";
			CDmasterOpen.Filter = "Application Data Base|pricing.mdb";
			CDmasterOpen.FileName = "";
			this.CDmasterOpen.ShowDialog();
			if (string.IsNullOrEmpty(CDmasterOpen.FileName)) {
			} else {
				lblCompany.Tag = Strings.Mid(lvLocation.FocusedItem.Name, 2);
				cnnDBmaster.Execute("UPDATE locationCompany SET locationCompany.locationCompany_Path = '" + Strings.Replace(CDmasterOpen.FileName, "'", "''") + "' WHERE (((locationCompany.locationCompanyID)=" + Strings.Mid(lvLocation.FocusedItem.Name, 2) + "));");
				loadCompanies();
				lvLocation.FocusedItem = lvLocation.Items["k" + lblCompany.Tag];
				lvLocation_DoubleClick(lvLocation, new System.EventArgs());
				cmdCompany_Click(cmdCompany, new System.EventArgs());
			}

		}

		private void cmdOK_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			bool createDayend = false;
			decimal x = default(decimal);
			string revName = "";
			//loading languages files
			//Dim rs As Recordset
			short tempLID = 0;
			tempLID = 1;
			rs = modRecordSet.getRS(ref "SELECT Company_LanguageID, Company_RightTL From Company");
			if (rs.RecordCount) {
				if (Information.IsDBNull(rs.Fields("Company_LanguageID").Value))
					tempLID = 1;
				if (rs.Fields("Company_LanguageID").Value == 0) {
					tempLID = 1;
				} else {
					tempLID = rs.Fields("Company_LanguageID").Value;
				}

				if (Information.IsDBNull(rs.Fields("Company_RightTL").Value))
					modRecordSet.iLangRTL = 0;
				if (rs.Fields("Company_RightTL").Value == 0) {
					modRecordSet.iLangRTL = 0;
				} else {
					modRecordSet.iLangRTL = rs.Fields("Company_RightTL").Value;
				}
			} else {
				tempLID = 1;
				modRecordSet.iLangRTL = 0;
			}

			modRecordSet.rsLang = modRecordSet.getRS(ref "SELECT * From LanguageLayoutLnk Where LanguageLayoutLnk_LanguageLayoutID = " + tempLID + ";");
			//loading languages files

			//loading help file
			string helpPath = null;
			//helpPath = App.Path & "\4POS4Dummies.chm"
			//If Command = "1" Then helpPath = "C:\4POS\4POS4Dummies.chm"
			helpPath = "C:\\4POS\\4POS4Dummies.chm";
			if (fso.FileExists(helpPath)) {
				modRecordSet.rsHelp = modRecordSet.getRS(ref "SELECT * From Help;");
			} else {
				modRecordSet.rsHelp = modRecordSet.getRS(ref "SELECT 0 AS Help_Section, 'A' AS Help_Form From Help;");
			}
			//loading help file

			 // ERROR: Not supported in C#: OnErrorStatement

			rs = modRecordSet.getRS(ref "SELECT * FROM Person WHERE (Person_UserID = '" + Strings.Replace(this.txtUserName.Text, "'", "''") + "') AND (Person_Password = '" + Strings.Replace(this.txtPassword.Text, "'", "''") + "')");
			ADODB.Recordset rsRpt = default(ADODB.Recordset);
			if (rs.BOF | rs.EOF) {
				Interaction.MsgBox("Invalid User Name or Password, try again!", MsgBoxStyle.Exclamation, "Login");
				txtPassword.Focus();
			} else {
				if (Convert.ToInt32(rs.Fields("Person_SecurityBit").Value + "0")) {
					this.Close();
					My.MyProject.Forms.frmMenu.lblUser.Text = rs.Fields("Person_FirstName").Value + " " + rs.Fields("Person_LastName").Value;
					My.MyProject.Forms.frmMenu.lblUser.Tag = rs.Fields("PersonID").Value;
					My.MyProject.Forms.frmMenu.gBit = rs.Fields("Person_SecurityBit").Value;

					if (Strings.Len(rs.Fields("Person_QuickAccess").Value) > 0) {
						for (x = Strings.Len(rs.Fields("Person_QuickAccess").Value); x >= 1; x += -1) {
							revName = revName + Strings.Mid(rs.Fields("Person_QuickAccess").Value, x, 1);
						}
						if (Strings.LCase(Strings.Left(rs.Fields("Person_Position").Value, 8)) == "4posboss" & Strings.LCase(Strings.Right(rs.Fields("Person_Position").Value, Strings.Len(rs.Fields("Person_QuickAccess").Value))) == revName) {
							My.MyProject.Forms.frmMenu.lblUser.ForeColor = System.Drawing.Color.Yellow;
							My.MyProject.Forms.frmMenu.gSuper = true;
						}
					}

					rsRpt = modRecordSet.getRS(ref "SELECT Company_LoadTRpt From Company");
					if (Information.IsDBNull(rsRpt.Fields("Company_LoadTRpt").Value)) {
					} else if (rsRpt.Fields("Company_LoadTRpt").Value == 0) {
					} else {
						if (fso.FileExists(modRecordSet.serverPath + "templateReport1.mdb")) {
							if (fso.FileExists(modRecordSet.serverPath + "report" + My.MyProject.Forms.frmMenu.lblUser.Tag + ".mdb"))
								fso.DeleteFile(modRecordSet.serverPath + "report" + My.MyProject.Forms.frmMenu.lblUser.Tag + ".mdb", true);
							if (fso.FileExists(modRecordSet.serverPath + "templateReport.mdb"))
								fso.DeleteFile(modRecordSet.serverPath + "templateReport.mdb", true);

							fso.CopyFile(modRecordSet.serverPath + "templateReport1.mdb", modRecordSet.serverPath + "templateReport.mdb", true);
						}
					}

					My.MyProject.Forms.frmMenu.loadMenu("stock");
					if (fso.FileExists(modRecordSet.serverPath + "report" + My.MyProject.Forms.frmMenu.lblUser.Tag + ".mdb")) {
					} else {
						fso.CopyFile(modRecordSet.serverPath + "templateReport.mdb", modRecordSet.serverPath + "report" + My.MyProject.Forms.frmMenu.lblUser.Tag + ".mdb");
						createDayend = true;
					}
					if (modReport.openConnectionReport()) {
					} else {
						Interaction.MsgBox("Unable to locate the Report Database!" + Constants.vbCrLf + Constants.vbCrLf + "The Update Controller wil terminate.", MsgBoxStyle.Critical, "SERVER ERROR");
						System.Environment.Exit(0);
					}
					if (createDayend) {
						//                cnnDBreport.Execute "DELETE * FROM Report"
						//                cnnDBreport.Execute "INSERT INTO Report ( ReportID, Report_DayEndStartID, Report_DayEndEndID, Report_Heading ) SELECT 1 AS reportKey, Max(aDayEnd.DayEndID) AS MaxOfDayEndID, Max(aDayEnd.DayEndID) AS MaxOfDayEndID1, 'From ' & Format(Max([aDayEnd].[DayEnd_Date]),'ddd dd mmm yyyy') & ' to ' & Format(Max([aDayEnd].[DayEnd_Date]),'ddd dd mmm yyyy') & ' covering a dayend range of 1 days' AS theHeading FROM aDayEnd;"
						//                frmUpdateDayEnd.show 1
						My.MyProject.Forms.frmMenu.cmdToday_Click(null, new System.EventArgs());
						My.MyProject.Forms.frmMenu.cmdLoad_Click(null, new System.EventArgs());
					}

					rs = modReport.getRSreport(ref "SELECT DayEnd.DayEnd_Date AS fromDate, DayEnd_1.DayEnd_Date AS toDate FROM (Report INNER JOIN DayEnd ON Report.Report_DayEndStartID = DayEnd.DayEndID) INNER JOIN DayEnd AS DayEnd_1 ON Report.Report_DayEndEndID = DayEnd_1.DayEndID;");
					if (rs.RecordCount) {
						My.MyProject.Forms.frmMenu._DTPicker1_0.Value = Strings.Format(rs.Fields("fromDate").Value, "yyyy");
						My.MyProject.Forms.frmMenu._DTPicker1_0.Value = Strings.Format(rs.Fields("fromDate").Value, "mm");
						My.MyProject.Forms.frmMenu._DTPicker1_0.Value = Strings.Format(rs.Fields("fromDate").Value, "dd");
						My.MyProject.Forms.frmMenu._DTPicker1_1.Value = Strings.Format(rs.Fields("toDate").Value, "yyyy");
						My.MyProject.Forms.frmMenu._DTPicker1_1.Value = Strings.Format(rs.Fields("toDate").Value, "mm");
						My.MyProject.Forms.frmMenu._DTPicker1_1.Value = Strings.Format(rs.Fields("toDate").Value, "dd");
					}
					My.MyProject.Forms.frmMenu.setDayEndRange();
					My.MyProject.Forms.frmMenu.lblDayEndCurrent.Text = My.MyProject.Forms.frmMenu.lblDayEnd.Text;
				} else {
					Interaction.MsgBox("You do not have the correct permissions to access the 4POS Office Application, try again!", MsgBoxStyle.Exclamation, "Login");
					this.txtUserName.Focus();
					System.Windows.Forms.SendKeys.Send("{Home}+{End}");
				}
			}



		}

		private void BuildRegistrationKey()
		{
			short x = 0;
			string lCode = null;
			string leCode = null;
			gSecurityCode = Strings.UCase(txtCompany.Text) + "XDFHWPGMIJ";
			gSecurityCode = Strings.Replace(gSecurityCode, " ", "");
			gSecurityCode = Strings.Replace(gSecurityCode, "'", "");
			gSecurityCode = Strings.Replace(gSecurityCode, "\"", "");
			gSecurityCode = Strings.Replace(gSecurityCode, ",", "");
			for (x = 1; x <= 10; x++) {
				gSecurityCode = Strings.Left(gSecurityCode, x) + Strings.Replace(Strings.Mid(gSecurityCode, x + 1), Strings.Mid(gSecurityCode, x, 1), "");
			}
			gSecurityCode = Strings.Left(gSecurityCode, 10);
			lCode = getSerialNumber();
			leCode = "";
			 // ERROR: Not supported in C#: OnErrorStatement

			for (x = 1; x <= Strings.Len(lCode); x++) {
				leCode = leCode + Strings.Mid(gSecurityCode, Convert.ToDouble(Strings.Mid(lCode, x, 1)) + 1, 1);
			}
			 // ERROR: Not supported in C#: OnErrorStatement

			lblCode.Text = leCode;

		}

		private void Command1_Click()
		{
			if (checkSecurity()) {
				this.frmRegister.Visible = false;
			} else {
				this.frmRegister.Visible = true;
				BuildRegistrationKey();
			}
		}

		private void cmdRegistration_Click_OLD()
		{
			string lCode = null;
			string lPassword = null;
			int x = 0;
			string lNewString = null;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			const string securtyStringReply = "9487203516";

			//Exit Sub

			if (Interaction.MsgBox("By Clicking 'Yes' you confirm that your company name is correct and you understand the licensing agreement." + Constants.vbCrLf + Constants.vbCrLf + "Do you wish to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "REGISTRATION") == MsgBoxResult.Yes) {

				if (Strings.Len(gSecKey) == 12) {
					lNewString = "";
					for (x = 1; x <= Strings.Len(txtKey.Text); x++) {
						if (Information.IsNumeric(Strings.Mid(txtKey.Text, x, 1))) {
							lNewString = lNewString + Strings.InStr(securtyStringReply, Strings.Mid(txtKey.Text, x, 1)) - 1;
						}
					}
					cmdCompany_Click(cmdCompany, new System.EventArgs());
					return;
				} else {
					lNewString = "";
					for (x = 1; x <= Strings.Len(txtKey.Text); x++) {
						if (Information.IsNumeric(Strings.Mid(txtKey.Text, x, 1))) {
							lNewString = lNewString + Strings.InStr(securtyStringReply, Strings.Mid(txtKey.Text, x, 1)) - 1;
						}
					}
					if (!string.IsNullOrEmpty(lNewString)) {
						if (System.Math.Abs(Convert.ToDouble(lNewString)) == System.Math.Abs(Convert.ToDouble(getSerialNumber()))) {
							lPassword = "pospospospos";
							lCode = getSerialNumber();
							if (!string.IsNullOrEmpty(lCode)) {
								lCode = Encrypt(lCode, lPassword);
								cmdCompany_Click(cmdCompany, new System.EventArgs());
								modRecordSet.cnnDB.Execute("UPDATE Company SET Company.Company_Code = '" + Strings.Replace(lCode, "'", "''") + "';");
								frmRegister.Visible = false;
							}

							return;
						}
					}
				}
			}
			Interaction.MsgBox("The 'Activation key' is invalid!", MsgBoxStyle.Exclamation, "4POS REGISTRATION");
		}

		private void cmdBegin_Click_OLD()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			if (!string.IsNullOrEmpty(Strings.Trim(txtCompany.Text))) {
				//cnnDB.Execute "UPDATE Company SET Company_Name = '" & Replace(txtCompany.Text, "'", "''") & "'"
				rs = modRecordSet.getRS(ref "SELECT * From Company");
				if (rs.RecordCount) {
					if (Information.IsDBNull(rs("Company_TerminateDate"))) {
						modRecordSet.cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" + DateAndTime.Today + "#;");
					} else {
						//If (Date + 2) > rs("Company_TerminateDate") Then
						//    cnnDB.Execute "UPDATE Company SET Company.Company_Code = '';"
						//    checkSecurity = False
						//   Exit Function
						//End If
					}
				}
			}
		}

		private void cmdBegin_Click()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string vValue = null;
			string hkey = null;
			int lRetVal = 0;
			if (!string.IsNullOrEmpty(Strings.Trim(txtCompany.Text))) {
				modRecordSet.cnnDB.Execute("UPDATE Company SET Company_Name = '" + Strings.Replace(txtCompany.Text, "'", "''") + "'");
				rs = modRecordSet.getRS(ref "SELECT * From Company");

				if (rs.RecordCount) {
					//check advance date expiry system
					 // ERROR: Not supported in C#: OnErrorStatement

					vValue = "";
					lRetVal = modUtilities.RegOpenKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\Microsoft\\Windows\\CurrentVersion\\ShellDls", 0, modUtilities.KEY_QUERY_VALUE, ref hkey);
					lRetVal = modUtilities.QueryValueEx(hkey, "ShellClass", ref vValue);
					modUtilities.RegCloseKey(hkey);
					if (string.IsNullOrEmpty(vValue)) {
						vValue = "0";
					} else {
						if (vValue != "0")
							vValue = Convert.ToString(Convert.ToDateTime("&H" + vValue));
					}

					if (Information.IsDBNull(rs("Company_TerminateDate")) & vValue == "0") {
						modRecordSet.cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" + DateAndTime.Today + "#;");
						lRetVal = modUtilities.RegCreateKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\Microsoft\\Windows\\CurrentVersion\\ShellDls\\MSOCache", 0, "soap", 0, modUtilities.KEY_ALL_ACCESS, 0, ref hkey, ref 0);
						lRetVal = modUtilities.RegOpenKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\Microsoft\\Windows\\CurrentVersion\\ShellDls", 0, modUtilities.KEY_ALL_ACCESS, ref hkey);
						modUtilities.SetValueEx(hkey, ref "ShellClass", ref modUtilities.REG_SZ, ref Conversion.Hex(DateAndTime.Today.ToOADate()));
						modUtilities.RegCloseKey(hkey);
					} else {
						if (Information.IsDBNull(rs("Company_TerminateDate")) & vValue != "0") {
							//db date tempered
							if (modApplication.posDemo() == true) {
								modRecordSet.cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" + DateAndTime.Today + "#;");
								lRetVal = modUtilities.RegCreateKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\Microsoft\\Windows\\CurrentVersion\\ShellDls\\MSOCache", 0, "soap", 0, modUtilities.KEY_ALL_ACCESS, 0, ref hkey, ref 0);
								lRetVal = modUtilities.RegOpenKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\Microsoft\\Windows\\CurrentVersion\\ShellDls", 0, modUtilities.KEY_ALL_ACCESS, ref hkey);
								modUtilities.SetValueEx(hkey, ref "ShellClass", ref modUtilities.REG_SZ, ref Conversion.Hex(DateAndTime.Today.ToOADate()));
								modUtilities.RegCloseKey(hkey);
							} else {
								modRecordSet.cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" + (System.DateTime.FromOADate(DateAndTime.Today.ToOADate() - 20)) + "#;");
								Interaction.MsgBox("Invalid License found." + Constants.vbCrLf + "application will now exit", MsgBoxStyle.Critical, "Run Time Error");
								System.Environment.Exit(0);
							}
						}

						if (Information.IsDBNull(rs("Company_TerminateDate"))) {
						} else {
							if (rs("Company_TerminateDate").Value > DateAndTime.Today) {
								//db date tempered
								modRecordSet.cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" + (System.DateTime.FromOADate(DateAndTime.Today.ToOADate() - 20)) + "#;");
								Interaction.MsgBox("Invalid License found." + Constants.vbCrLf + "application will now exit", MsgBoxStyle.Critical, "Run Time Error");
								System.Environment.Exit(0);
							}
						}

						//If (Date + 2) > rs("Company_TerminateDate") Then
						//    cnnDB.Execute "UPDATE Company SET Company.Company_Code = '';"
						//    checkSecurity = False
						//   Exit Function
						//End If
					}
				}
			}
		}

		private void cmdRegistration_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short x = 0;
			string lCode = null;
			string leCode = null;
			string lPassword = null;
			ADODB.Recordset rs = default(ADODB.Recordset);

			if (!string.IsNullOrEmpty(Strings.Trim(txtCompany.Text))) {
				//new serialization check
				//If Len(gSecKey) = 12 Then
				//is he really using Original CD to register
				if (My.MyProject.Forms.frmPOSCode.setupCode() == true) {
					if (Interaction.MsgBox("By Clicking 'Yes' you confirm that your company name is correct and you understand the licensing agreement." + Constants.vbCrLf + Constants.vbCrLf + "Do you wish to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "REGISTRATION") == MsgBoxResult.Yes) {
						modRecordSet.cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" + DateAndTime.Today + "#;");
						cmdBegin_Click();
						//new serialization check    cnnDB.Execute "UPDATE Company SET Company.Company_Code = [Company_Code] & '0';"
						//new serialization check    cnnDB.Execute "UPDATE POS SET POS.POS_Code = '" & strCDKey & "';"
						lPassword = "pospospospos";
						lCode = getSerialNumber();
						lCode = Encrypt(lCode, lPassword);
						modRecordSet.cnnDB.Execute("UPDATE Company SET Company.Company_Code = '" + Strings.Replace(lCode, "'", "''") + "';");

						lPassword = Strings.LTrim(Strings.Replace(txtCompany.Text, "'", ""));
						lPassword = Strings.RTrim(Strings.Replace(lPassword, " ", ""));
						lPassword = Strings.Trim(Strings.Replace(lPassword, ".", ""));
						lPassword = Strings.LCase(lPassword);
						leCode = "";
						lCode = "";
						for (x = 1; x <= Strings.Len(lPassword); x++) {
							lCode = Strings.Mid(lPassword, x, 1);
							lCode = Convert.ToString(Strings.Asc(lCode));
							if (Convert.ToDouble(lCode) > 96 & Convert.ToDouble(lCode) < 123) {
								leCode = leCode + Strings.Mid(lPassword, x, 1);
							}
						}
						lPassword = leCode;
						rs = modRecordSet.getRS(ref "SELECT * FROM POS;");
						//WHERE POS_IPAddress = 'localhost';")
						if (rs.RecordCount) {
							while (rs.EOF == false) {
								if (rs.Fields("POS_IPAddress").Value == "localhost" & rs.Fields("POS_Name").Value == "Server") {
									lCode = Convert.ToString(rs.Fields("POS_CID").Value * 135792468);
									leCode = Encrypt(lCode, lPassword);
									leCode = leCode + Strings.Chr(255) + basCryptoProcs.strCDKey;
									modRecordSet.cnnDB.Execute("UPDATE POS SET POS.POS_Code = '" + Strings.Replace(leCode, "'", "''") + "' WHERE POS.POS_CID=" + rs.Fields("POS_CID").Value + ";");
									modRecordSet.cnnDB.Execute("UPDATE POS SET POS.POS_Code = '0' WHERE POS.POS_CID<>" + rs.Fields("POS_CID").Value + ";");
									break; // TODO: might not be correct. Was : Exit Do
								} else if (rs.Fields("POS_IPAddress").Value == "localhost") {
									lCode = Convert.ToString(rs.Fields("POS_CID").Value * 135792468);
									leCode = Encrypt(lCode, lPassword);
									leCode = leCode + Strings.Chr(255) + basCryptoProcs.strCDKey;
									modRecordSet.cnnDB.Execute("UPDATE POS SET POS.POS_Code = '" + Strings.Replace(leCode, "'", "''") + "' WHERE POS.POS_CID=" + rs.Fields("POS_CID").Value + ";");
									modRecordSet.cnnDB.Execute("UPDATE POS SET POS.POS_Code = '0' WHERE POS.POS_CID<>" + rs.Fields("POS_CID").Value + ";");
									break; // TODO: might not be correct. Was : Exit Do
									//Else
									//    cnnDB.Execute "UPDATE POS SET POS.POS_Code = '0' WHERE POS.POS_CID=" & rs("POS_CID") & ";"
								}
								rs.moveNext();
							}
						}
						//new serialization check
						frmRegister.Visible = false;
					}

				}

			} else {
				Interaction.MsgBox("A Company name is required." + Constants.vbCrLf + Constants.vbCrLf + "If you do not want to register now, Press then 'Exit Button'.", MsgBoxStyle.Exclamation, "4POS REGISTRATION");
				txtCompany.Focus();
			}
		}

		private void frmMaster_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			string lFile = null;
			Label1.AddRange(new Label[] {
				_Label1_0,
				_Label1_1,
				_Label1_2,
				_Label1_3,
				_Label1_4
			});
			//ResizeForm(Me, pixelToTwips(Me.Width, True), pixelToTwips(Me.Height, False), 0)

			ExecCmd(ref "cmd /C DEL c:\\*.tmp");

			if (fso.FileExists("C:\\4POS\\pos\\data.ug")) {
				if (fso.FileExists("C:\\4POS\\pos\\4POSupgrade.exe")) {
					Interaction.Shell("C:\\4POS\\pos\\4POSupgrade.exe", AppWinStyle.NormalFocus);
				} else {
					Interaction.MsgBox("An upgrade is required, but the upgrade unility can not be located!" + Constants.vbCrLf + Constants.vbCrLf + "Please contact a 4POS representative to assist you in resolving this problem.", MsgBoxStyle.Critical, "UPGRADE");
				}
				System.Environment.Exit(0);
			}

			modUtilities.setShortDateFormat();

			short tempLID = 0;
			string helpPath = null;
			Scripting.TextStream DayEndtextstream = default(Scripting.TextStream);
			string lString = null;
			if (getMasterDB()) {
				//loadLanguage
				loadCompanies();
			} else {
				if (modRecordSet.openConnection()) {
				} else {
					if (fso.FileExists("c:\\4posServer\\pricing.mdb")) {
						lFile = "c:\\4posServer\\pricing.mdb";
					} else {
						this.CDmasterOpen.Title = "Select the path to the application database ...";
						//UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
						CDmasterOpen.Filter = "Application Data Base|pricing.mdb";
						CDmasterOpen.FileName = "";
						this.CDmasterOpen.ShowDialog();
						lFile = CDmasterOpen.FileName;
					}
					if (string.IsNullOrEmpty(lFile)) {
						System.Environment.Exit(0);
					} else {
						if (AddDSN("4POS", "4POS Pricing File", lFile)) {
							this.Close();
							Interaction.MsgBox("The new data source has just been configured into the application suite." + Constants.vbCrLf + Constants.vbCrLf + "Please restart this application", MsgBoxStyle.Information, "DATA SOURCE");
							System.Environment.Exit(0);
						} else {
							System.Environment.Exit(0);
						}
					}
				}
				//loading languages files
				//Dim rs As Recordset
				tempLID = 1;
				rs = modRecordSet.getRS(ref "SELECT Company_LanguageID, Company_RightTL From Company");
				if (rs.RecordCount) {
					if (Information.IsDBNull(rs.Fields("Company_LanguageID").Value))
						tempLID = 1;
					if (rs.Fields("Company_LanguageID").Value == 0) {
						tempLID = 1;
					} else {
						tempLID = rs.Fields("Company_LanguageID").Value;
					}

					if (Information.IsDBNull(rs.Fields("Company_RightTL").Value))
						modRecordSet.iLangRTL = 0;
					if (rs.Fields("Company_RightTL").Value == 0) {
						modRecordSet.iLangRTL = 0;
					} else {
						modRecordSet.iLangRTL = rs.Fields("Company_RightTL").Value;
					}
				} else {
					tempLID = 1;
					modRecordSet.iLangRTL = 0;
				}

				modRecordSet.rsLang = modRecordSet.getRS(ref "SELECT * From LanguageLayoutLnk Where LanguageLayoutLnk_LanguageLayoutID = " + tempLID + ";");
				//loading languages files

				//loading help file
				//helpPath = App.Path & "\4POS4Dummies.chm"
				//If Command = "1" Then helpPath = "C:\4POS\4POS4Dummies.chm"
				helpPath = "C:\\4POS\\4POS4Dummies.chm";
				if (fso.FileExists(helpPath)) {
					modRecordSet.rsHelp = modRecordSet.getRS(ref "SELECT * From Help;");
				} else {
					modRecordSet.rsHelp = modRecordSet.getRS(ref "SELECT 0 AS Help_Section, 'A' AS Help_Form From Help;");
				}
				//loading help file

				//Dim lTextstream As textstream
				lString = modRecordSet.serverPath + "data\\4POSInterface\\4POSAUTODE.txt";
				if (fso.FileExists(lString)) {
					DayEndtextstream = fso.OpenTextFile(lString, Scripting.IOMode.ForReading, true);
					lString = DayEndtextstream.ReadAll;
					DayEndtextstream.Close();
					DayEndtextstream = null;

					if (Information.IsDate(lString)) {
						modApplication.bolAutoDE = true;
						modApplication.dateDayEnd = Convert.ToDateTime(lString);
						modApplication.doMenuForms(ref "frmdayend");
						System.Windows.Forms.Application.DoEvents();
					} else {
						Interaction.MsgBox("Auto DayEnd file was detected but file is invalid.");
						System.Environment.Exit(0);
					}
				} else {
					loadLanguage();
					frmLogin f = new frmLogin();
					f.Show();
					//frmLogin.Show()
				}

				//Me.Close()
				this.Hide();
			}


		}

//Private Sub Label3_Click()
//    Dim rs As Recordset
//        Set rs = getRS("SELECT * FROM aTransactionItem")
//        If rs.RecordCount = 0 Then
//        rs.save gMasterPath & "Data\aTransactionItem.rs", adPersistADTG
//        End If
//End Sub

		private void lvLocation_DoubleClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			string[] lArray = null;
			short x = 0;

			if (AddDSN("4POS", "4POS Pricing Data", this.lvLocation.FocusedItem.SubItems[1].Text)) {
				System.Windows.Forms.Application.DoEvents();
				if (modRecordSet.openConnection()) {
					lblCompany.Text = lvLocation.FocusedItem.Text + " - " + lvLocation.FocusedItem.SubItems[0].Text;
					lblCompany.Tag = Strings.Mid(lvLocation.FocusedItem.Name, 2);
					lblPath.Text = lvLocation.FocusedItem.SubItems[1].Text;
					lArray = Strings.Split(lblPath.Text, "\\");
					//lblDir.Text = lArray(0) & "\"
					for (x = 1; x <= Information.UBound(lArray) - 1; x++) {
						lblDir.Text = lblDir.Text + lArray[x] + "\\";
					}
					for (x = 0; x <= Label1.Count; x++) {
						Label1[x].Enabled = true;
					}
					cmdCompany.Enabled = true;
					cmdBuild.Enabled = true;
					cmdDatabase.Enabled = true;
					this.txtUserName.Enabled = true;
					txtPassword.Enabled = true;
					this.cmdOK.Enabled = true;
					if (checkSecurity()) {
						this.frmRegister.Visible = false;
					} else {
						this.frmRegister.Visible = true;
						BuildRegistrationKey();
					}
					if (txtUserName.Visible)
						txtUserName.Focus();

					return;
				}
			}
			lblCompany.Text = "...";
			lblCompany.Tag = "";
			lblPath.Text = "...";
			lblDir.Text = "...";
			for (x = 0; x <= Label1.Count; x++) {
				Label1[x].Enabled = false;
			}
			this.txtUserName.Enabled = false;
			txtPassword.Enabled = false;
			this.cmdOK.Enabled = false;
			cmdCompany.Enabled = false;
			cmdBuild.Enabled = false;
			cmdDatabase.Enabled = false;

			this.CDmasterOpen.Title = "Select the path to " + lvLocation.FocusedItem.SubItems[0].Text + " application database ...";
			CDmasterOpen.Filter = "Application Data Base|pricing.mdb";
			CDmasterOpen.FileName = "";
			this.CDmasterOpen.ShowDialog();
			if (string.IsNullOrEmpty(CDmasterOpen.FileName)) {
			} else {
				lblCompany.Tag = Strings.Mid(lvLocation.FocusedItem.Name, 2);
				cnnDBmaster.Execute("UPDATE locationCompany SET locationCompany.locationCompany_Path = '" + Strings.Replace(CDmasterOpen.FileName, "'", "''") + "' WHERE (((locationCompany.locationCompanyID)=" + Strings.Mid(lvLocation.FocusedItem.Name, 2) + "));");
				loadCompanies();
				lvLocation.FocusedItem = lvLocation.Items["k" + lblCompany.Tag];
				lvLocation_DoubleClick(lvLocation, new System.EventArgs());
			}
		}

		private void loadCompanies()
		{
			ADODB.Recordset rs = new ADODB.Recordset();
			System.Windows.Forms.ListViewItem lListitem = null;
			rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
			//If openConnection Then
			//End If
			rs.Open("SELECT locationCompany.locationCompanyID, location.location_Name, locationCompany.locationCompany_Name, locationCompany.locationCompany_Path FROM location INNER JOIN locationCompany ON location.locationID = locationCompany.locationCompany_LocationID ORDER BY location.location_Name, locationCompany.locationCompany_Name;", cnnDBmaster, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
			//If lvLocation.Items.Count <> 0 Then
			//Me.lvLocation.Items.Clear()
			//End If
			if (rs.RecordCount) {
				while (!(rs.EOF)) {
					lListitem = lvLocation.Items.Add("k" + rs.Fields("locationCompanyID").Value, rs.Fields("locationCompany_Name").Value, 2);
					if (lListitem.SubItems.Count > 0) {
						lListitem.SubItems[0].Text = rs.Fields("location_Name").Value + "";
					} else {
						lListitem.SubItems.Insert(0, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("location_Name").Value + ""));
					}
					if (lListitem.SubItems.Count > 1) {
						lListitem.SubItems[1].Text = rs.Fields("locationCompany_Path").Value + "";
					} else {
						lListitem.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("locationCompany_Path").Value + ""));
					}
					if (Strings.LCase(rs.Fields("locationCompany_Path").Value + "") == Strings.LCase(modRecordSet.serverPath + "pricing.mdb")) {
						lListitem.Selected = true;
						lvLocation_DoubleClick(lvLocation, new System.EventArgs());
					}
					rs.MoveNext();
				}
			}
		}

		private void txtCompany_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtCompany.SelectionStart = 0;
			txtCompany.SelectionLength = 9999;
		}

		private void txtCompany_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (!string.IsNullOrEmpty(Strings.Trim(txtCompany.Text))) {
				modRecordSet.cnnDB.Execute("UPDATE Company SET Company_Name = '" + Strings.Replace(txtCompany.Text, "'", "''") + "'");
			}
			BuildRegistrationKey();
		}

		private void txtKey_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtKey.SelectionStart = 0;
			txtKey.SelectionLength = 9999;
		}
		private void txtPassword_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtPassword.SelectionStart = 0;
			txtPassword.SelectionLength = 9999;
		}
		private void txtPassword_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 13) {
				KeyAscii = 0;
				cmdOK_Click(cmdOK, new System.EventArgs());
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
		private void txtUserName_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtUserName.SelectionStart = 0;
			txtUserName.SelectionLength = 9999;
		}
		private void txtUserName_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 13) {
				KeyAscii = 0;
				txtPassword.Focus();
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
		public bool checkSecurity()
		{
			bool functionReturnValue = false;
			string lCode = null;
			string leCode = null;
			string lPassword = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			short x = 0;

			modApplication.getLoginDate();
			//Piracy check

			functionReturnValue = false;
			rs = modRecordSet.getRS(ref "SELECT * From Company");
			if (rs.RecordCount) {
				gSecKey = rs.Fields("Company_Code").Value + "";
				if (Information.IsNumeric(rs.Fields("Company_Code").Value)) {
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
						//        checkSecurity = False
						//   End If
						//End If
					} else {
						txtCompany.Text = rs.Fields("Company_Name").Value;
						txtCompany.SelectionStart = 0;
						txtCompany.SelectionLength = 999;
					}

				}
			} else {
				Interaction.MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS");
				System.Environment.Exit(0);
			}
			return functionReturnValue;
		}
	}
}
