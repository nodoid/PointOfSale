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
	internal partial class frmBackupDatabase : System.Windows.Forms.Form
	{
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

		private ADODB.Connection cnnDBclient;
		private const short udChannel = 1;
		private const short udPerson = 2;
		private const short udPrice = 4;
		private const short udStockGroup = 8;
		private const short udSockItemSupplier = 16;
		private const short udStockItemActualCost = 32;
		private const short udSupplierStatic = 64;
		private const short udSupplierOrder = 128;
		private const short udSupplierDiscount = 256;
		private const short udPromotion = 512;
		private const short udRecipe = 1024;
		private const short udCashTransaction = 2048;
		private const short udIncrement = 4096;
		public int ExecCmd(ref string cmdline)
		{
			int ret = 0;
			PROCESS_INFORMATION proc = default(PROCESS_INFORMATION);
			STARTUPINFO start = default(STARTUPINFO);

			// Initialize the STARTUPINFO structure:
			start.cb = Strings.Len(start);

			// Start the shelled application:
			ret = CreateProcessA(Constants.vbNullString, cmdline, 0, 0, 1, NORMAL_PRIORITY_CLASS, 0, Constants.vbNullString, ref start, ref proc);

			// Wait for the shelled application to finish:
			ret = WaitForSingleObject(proc.hProcess, INFINITE);
			GetExitCodeProcess(proc.hProcess, ref ret);
			CloseHandle(proc.hThread);
			CloseHandle(proc.hProcess);
			//UPGRADE_WARNING: Couldn't resolve default property of object ExecCmd. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			return ret;
		}

		private void loadLanguage()
		{

			//NO COMPONENTS AVAILABLE FOR TRANSLATION!!!
			//Reccomend Removing text items from picture/image and adding them as
			//standalone, updatable label components.

			//No Component! [4POS Application Suite]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then COMPONENT(0).Caption = rsLang("LanguageLayoutLnk_Description"): COMPONENT(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//No Component! [Database compression and backup in progress...]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then COMPONENT(0).Caption = rsLang("LanguageLayoutLnk_Description"): COMPONENT(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmBackupDatabase.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void frmBackupDatabase_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			loadLanguage();
			tmrBackup.Enabled = true;
		}

		private void tmrBackup_Tick(System.Object eventSender, System.EventArgs eventArgs)
		{
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			string lDir = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			 // ERROR: Not supported in C#: OnErrorStatement

			lDir = FileSystem.Dir("C:\\*.tmp");
			while (!(string.IsNullOrEmpty(lDir))) {
				fso.DeleteFile("C:\\" + lDir);
				lDir = FileSystem.Dir();
			}
			lDir = FileSystem.Dir(modRecordSet.serverPath + "report*.mdb");
			while (!(string.IsNullOrEmpty(lDir))) {
				fso.DeleteFile(modRecordSet.serverPath + "" + lDir);
				lDir = FileSystem.Dir();
			}
			tmrBackup.Enabled = false;
			if (modRecordSet.openConnection()) {
				rs = modRecordSet.getRS(ref "SELECT Count(Sale.SaleID) AS CountOfSaleID FROM Sale;");
				if (rs.Fields("CountOfSaleID").Value) {
					rs.Close();
					modRecordSet.closeConnection();
					backupDatabase(ref "Pricing");
					backupDatabase(ref "Waitron");
					backupDatabase(ref "templateReport");

				}
			}
			lDir = FileSystem.Dir(modRecordSet.serverPath + "update\\*.zip");
			while (!(string.IsNullOrEmpty(lDir))) {
				switch (Strings.LCase(lDir)) {
					case "lqcontroller2.zip":
					case "template.zip":
					case "templatereport.zip":
						ExecCmd(ref "c:\\4posServer\\wzunzip.exe " + modRecordSet.serverPath + "update\\" + lDir + " " + modRecordSet.serverPath + "");
						fso.DeleteFile(modRecordSet.serverPath + "update\\" + lDir);
						break;
					case "lqpos2.zip":
					case "lqreport2.zip":
					case "lqbackoffice2.zip":
					case "lqbarcode2.zip":
					case "lqautodayend.zip":

						ExecCmd(ref "c:\\4posServer\\wzunzip.exe " + modRecordSet.serverPath + "update\\" + lDir + " c:\\4POS\\");
						fso.DeleteFile(modRecordSet.serverPath + "update\\" + lDir);
						break;
					case "data":
						break;
				}
				lDir = FileSystem.Dir();
			}
			this.Close();
			return;
			tmrBackup_Timer_Error:
			Interaction.MsgBox(Err().Description);
			this.Close();

		}

		private bool backupDatabase(ref string lDatabase)
		{
			bool functionReturnValue = false;
			JRO.JetEngine jetEngine = default(JRO.JetEngine);
			string strSourceConnect = null;
			string strDestConnect = null;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();

			fso.CopyFile(modRecordSet.serverPath + "" + lDatabase + ".mdb", modRecordSet.serverPath + "" + lDatabase + ".bk0", true);
			 // ERROR: Not supported in C#: OnErrorStatement

			if (fso.FileExists(modRecordSet.serverPath + "" + lDatabase + ".bak")) {
				fso.DeleteFile(modRecordSet.serverPath + "" + lDatabase + ".bak", true);
			}

			strSourceConnect = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + modRecordSet.serverPath + "" + lDatabase + ".mdb;User Id=liquid;Password=lqd;Jet OLEDB:System Database=" + modRecordSet.serverPath + "Secured.mdw";
			strDestConnect = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + modRecordSet.serverPath + "" + lDatabase + ".bak;User Id=liquid;Password=lqd;Jet OLEDB:System Database=" + modRecordSet.serverPath + "Secured.mdw";
			jetEngine = new JRO.JetEngine();

			// Compact and encrypt the database specified by strSourceDB
			// to the name and path specified by strDestDB.
			jetEngine.CompactDatabase(strSourceConnect, strDestConnect);
			//UPGRADE_NOTE: Object jetEngine may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			jetEngine = null;
			fso.DeleteFile(modRecordSet.serverPath + "" + lDatabase + ".mdb");
			fso.CopyFile(modRecordSet.serverPath + "" + lDatabase + ".bak", modRecordSet.serverPath + "" + lDatabase + ".mdb", true);
			modRecordSet.openConnection();
			saveDatabase(ref lDatabase);
			functionReturnValue = true;
			return functionReturnValue;
			backupDatabase_Error:

			fso.CopyFile(modRecordSet.serverPath + "" + lDatabase + ".bk0", modRecordSet.serverPath + "" + lDatabase + ".mdb", true);
			modRecordSet.openConnection();
			functionReturnValue = false;
			return functionReturnValue;
		}

		public void saveDatabase(ref string lDatabase)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			string lPath = null;
			 // ERROR: Not supported in C#: OnErrorStatement


			rs = modRecordSet.getRS(ref "SELECT Company.Company_BackupPath, Right([Company_DayEndID],1) AS file FROM Company;");
			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			if (Information.IsDBNull(rs.Fields("Company_BackupPath").Value)) {
				goto saveDatabase_Error;
			} else {
				if (string.IsNullOrEmpty(rs.Fields("Company_BackupPath").Value)) {
					lPath = _4PosBackOffice.NET.My.MyProject.Application.Info.DirectoryPath;
				} else {
					lPath = rs.Fields("Company_BackupPath").Value;
				}
				if (Strings.Right(lPath, 1) != "\\")
					lPath = lPath + "\\";
				lPath = lPath + rs.Fields("file").Value + ".bak";

				if (fso.FileExists(lPath))
					fso.DeleteFile(lPath, true);
				fso.CopyFile(modRecordSet.serverPath + "" + lDatabase + ".mdb", lPath, true);
			}

			return;
			saveDatabase_Error:
		}
	}
}
