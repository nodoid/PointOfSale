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
	static class modEmails
	{
		[DllImport("ODBCCP32.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
// Registry API functions
		private static extern int SQLConfigDataSource(int hwndParent, int fRequest, string lpszDriver, string lpszAttributes);

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


		public static object ExecCmd(ref string cmdline)
		{
			int ret = 0;
			PROCESS_INFORMATION proc = default(PROCESS_INFORMATION);
			STARTUPINFO start = default(STARTUPINFO);

			//Initialize the STARTUPINFO structure:
			start.cb = Strings.Len(start);

			//Start the shelled application:
			ret = CreateProcessA(Constants.vbNullString, cmdline, 0, 0, 1, NORMAL_PRIORITY_CLASS, 0, Constants.vbNullString, ref start, ref proc);

			//Wait for the shelled application to finish:
			ret = WaitForSingleObject(proc.hProcess, INFINITE);
			GetExitCodeProcess(proc.hProcess, ref ret);
			CloseHandle(proc.hThread);
			CloseHandle(proc.hProcess);
			//UPGRADE_WARNING: Couldn't resolve default property of object ExecCmd. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			return ret;
		}
		public static void SendSaleMail(ref string stEmail_d, ref string stAttchFile, ref string compID)
		{
			short id = 0;
			string stFileName = null;
			stFileName = modRecordSet.serverPath + "HQSales\\HQSales" + id + ".zip";

			stFileName = "HQSales" + compID + ".zip";

			// MSAPISession calls now need to be using System.Net.Mail

			//frmDayEnd.MAPISession1.SignOn()
			//frmDayEnd.MAPIMessages1.SessionID = frmDayEnd.MAPISession1.SessionID
			//frmDayEnd.MAPIMessages1.Compose()
			//frmDayEnd.MAPIMessages1.RecipIndex = 0
			//frmDayEnd.MAPIMessages1.RecipDisplayName = stEmail_d
			//frmDayEnd.MAPIMessages1.ResolveName()
			//frmDayEnd.MAPIMessages1.AddressResolveUI = True
			//frmDayEnd.MAPIMessages1.ResolveName()
			//frmDayEnd.MAPIMessages1.RecipAddress = "smtp:" & Trim(stEmail_d)
			//frmDayEnd.MAPIMessages1.MsgSubject = "4POS Sales"
			//frmDayEnd.MAPIMessages1.MsgNoteText = "Store Sales as at " & Format(Now, "ddd, dd-mmm-yyyy hh:nn")
			//frmDayEnd.MAPIMessages1.AttachmentType = MSMAPI.AttachTypeConstants.mapData
			//frmDayEnd.MAPIMessages1.AttachmentName = stFileName '"HQSales.zip"
			//'frmDayEnd.MAPIMessages1.AttachmentPathName = serverPath & "HQSales\HQSales.zip"
			//frmDayEnd.MAPIMessages1.AttachmentPathName = stAttchFile 'Identifying company ID
			//frmDayEnd.MAPIMessages1.Send(False)
			//frmDayEnd.MAPISession1.SignOff()

		}

		public static void CollectSalesHQ()
		{
			string dateSeril = null;
			string ldir1 = null;
			string f_File = null;
			bool sFiles = false;
			string strFile = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			Scripting.FileSystemObject FSO = new Scripting.FileSystemObject();

			 // ERROR: Not supported in C#: OnErrorStatement


			rs = modRecordSet.getRS(ref "SELECT * FROM CompanyEmails");
			if (rs.RecordCount)
				strFile = modRecordSet.serverPath + "HQSales\\HQSales" + rs.Fields("Comp_ID").Value + ".zip ";

			string stEmail = null;
			short k = 0;
			bool v_Email = false;
			if (copyFilesFromPoints() == true) {
				//ExecCmd  serverPath & "wzzip.exe " & serverPath & "HQSales\HQSales.zip " & serverPath & "HQSales\*.*"

				//now it will look  "c:\4POSServer\"  ExecCmd serverPath & "wzzip.exe " & strFile & serverPath & "HQSales\*.*"
				ExecCmd(ref "c:\\4POSServer\\" + "wzzip.exe " + strFile + modRecordSet.serverPath + "HQSales\\*.*");
				//On Local Error Resume Next


				//UPGRADE_WARNING: Couldn't resolve default property of object dateSeril. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				dateSeril = Strings.Trim(Strings.Replace(Convert.ToString(DateAndTime.Now), ":", ""));
				//UPGRADE_WARNING: Couldn't resolve default property of object dateSeril. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				dateSeril = Strings.Trim(Strings.Replace(dateSeril, "/", ""));
				//UPGRADE_WARNING: Couldn't resolve default property of object dateSeril. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				dateSeril = Strings.Trim(Strings.Replace(dateSeril, " ", ""));

				rs = modRecordSet.getRS(ref "SELECT * FROM CompanyEmails");
				if (rs.RecordCount) {
					for (k = 1; k <= 7; k++) {
						stEmail = rs.Fields("Comp_Email" + k).Value;
						if (Strings.InStr(stEmail, "@") > 0)
							v_Email = true;
						if (Strings.InStr(stEmail, ":\\") > 0)
							v_Email = true;
						if (Strings.InStr(stEmail, "\\\\") > 0)
							v_Email = true;
					}
					if (v_Email == false)
						return;
					//No valid email
					for (k = 1; k <= 7; k++) {
						stEmail = rs.Fields("Comp_Email" + k).Value;
						//Validate email string...
						if (Strings.InStr(stEmail, "@") > 0) {
							//SendSaleMail stEmail, rs("Comp_ID")
							SendSaleMail(ref stEmail, ref modRecordSet.serverPath + "HQSales\\HQSales" + rs.Fields("Comp_ID").Value + ".zip", ref rs.Fields("Comp_ID").Value);

						//Validate Netword Path string...
						} else if (Strings.InStr(stEmail, "\\\\") > 0) {
							System.Windows.Forms.Application.DoEvents();
							if (Strings.Right(stEmail, 1) == "\\") {
							} else {
								stEmail = stEmail + "\\";
							}
							if (FSO.FolderExists(stEmail)) {
								System.Windows.Forms.Application.DoEvents();
								if (FSO.FileExists(stEmail + "HQSales" + rs.Fields("Comp_ID").Value + ".zip")) {
									//UPGRADE_WARNING: Couldn't resolve default property of object dateSeril. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
									FSO.CopyFile(modRecordSet.serverPath + "HQSales\\HQSales" + rs.Fields("Comp_ID").Value + ".zip", stEmail + "HQSales" + rs.Fields("Comp_ID").Value + "_" + dateSeril + ".zip", true);
								} else {
									FSO.CopyFile(modRecordSet.serverPath + "HQSales\\HQSales" + rs.Fields("Comp_ID").Value + ".zip", stEmail + "HQSales" + rs.Fields("Comp_ID").Value + ".zip", true);
								}
							} else {
							}

						//Validate Local Path string...
						} else if (Strings.InStr(stEmail, ":\\") > 0) {

							if (Strings.Right(stEmail, 1) == "\\") {
							} else {
								stEmail = stEmail + "\\";
							}
							if (FSO.FolderExists(stEmail)) {
							} else {
								FSO.CreateFolder(stEmail);
							}
							System.Windows.Forms.Application.DoEvents();
							if (FSO.FileExists(stEmail + "HQSales" + rs.Fields("Comp_ID").Value + ".zip")) {
								//UPGRADE_WARNING: Couldn't resolve default property of object dateSeril. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								FSO.CopyFile(modRecordSet.serverPath + "HQSales\\HQSales" + rs.Fields("Comp_ID").Value + ".zip", stEmail + "HQSales" + rs.Fields("Comp_ID").Value + "_" + dateSeril + ".zip", true);
							} else {
								FSO.CopyFile(modRecordSet.serverPath + "HQSales\\HQSales" + rs.Fields("Comp_ID").Value + ".zip", stEmail + "HQSales" + rs.Fields("Comp_ID").Value + ".zip", true);
							}

						}
					}
				}
			}

			return;
			ErrHQ:
			Interaction.MsgBox(Err().Number + " : " + Err().Description + " : Path = " + stEmail);
			 // ERROR: Not supported in C#: ResumeStatement

		}
		private static bool copyFilesFromPoints()
		{
			bool functionReturnValue = false;
			bool sFiles = false;
			string f_File = null;
			string ldir1 = null;
			ADODB.Recordset rj = default(ADODB.Recordset);
			Scripting.FileSystemObject FSO = new Scripting.FileSystemObject();


			sFiles = false;

			f_File = Strings.Trim(Conversion.Str(DateAndTime.Year(DateAndTime.Today))) + "\\" + Strings.Trim(Conversion.Str(DateAndTime.Month(DateAndTime.Today))) + "\\" + Strings.Trim(Conversion.Str(DateAndTime.Day(DateAndTime.Today)));

			rj = modRecordSet.getRS(ref "SELECT POS_Name FROM POS WHERE POS_Disabled = False AND POS_KitchenMonitor = False;");

			if (rj.RecordCount) {
				if (FSO.FolderExists(modRecordSet.serverPath + "HQSales")) {
				} else {
					FSO.CreateFolder(modRecordSet.serverPath + "HQSales");
				}

				//Make sure the HQSales file is empty...
				//UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				ldir1 = FileSystem.Dir(modRecordSet.serverPath + "HQSales\\*.*");
				while (!(string.IsNullOrEmpty(ldir1))) {
					FSO.DeleteFile(modRecordSet.serverPath + "HQSales\\" + ldir1, true);
					//UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
					ldir1 = FileSystem.Dir();
				}

				while (rj.EOF == false) {
					if (Strings.LCase(rj.Fields("POS_Name").Value) == "localhost") {
						if (FSO.FolderExists(modRecordSet.serverPath + "data\\Server\\" + f_File)) {
							//UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
							ldir1 = FileSystem.Dir(modRecordSet.serverPath + "data\\Server\\" + f_File + "\\*.*");
							while (!(string.IsNullOrEmpty(ldir1))) {
								FSO.CopyFile(modRecordSet.serverPath + "data\\Server\\" + f_File + "\\" + ldir1, modRecordSet.serverPath + "HQSales\\" + ldir1, true);
								//UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
								ldir1 = FileSystem.Dir();
								sFiles = true;
							}
						}
					} else {
						if (FSO.FolderExists(modRecordSet.serverPath + "data\\" + rj.Fields("POS_Name").Value + "\\" + f_File)) {
							//UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
							ldir1 = FileSystem.Dir(modRecordSet.serverPath + "data\\" + rj.Fields("POS_Name").Value + "\\" + f_File + "\\*.*");
							while (!(string.IsNullOrEmpty(ldir1))) {
								FSO.CopyFile(modRecordSet.serverPath + "data\\" + rj.Fields("POS_Name").Value + "\\" + f_File + "\\" + ldir1, modRecordSet.serverPath + "HQSales\\" + ldir1, true);
								//UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
								ldir1 = FileSystem.Dir();
								sFiles = true;
							}

						}
					}
					rj.moveNext();
				}
			}

			if (sFiles == true) {
				functionReturnValue = true;
			} else {
				functionReturnValue = false;
			}
			return functionReturnValue;

		}
	}
}
