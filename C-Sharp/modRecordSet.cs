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
namespace _4PosBackOffice.NET
{
	static class modRecordSet
	{
		public static ADODB.Connection cnnDB;
		public static ADODB.Connection cnnDB1;
			//2 Open Instances......
		public static ADODB.Connection cnnIns;
		public static bool gDisp;
		public static bool picP;
		public static bool gDisplay;
		public static short gDQuote;
		public static short gMain;
		public static short gInt;
		public static string StrLocRep;
		public static string RptHead;
		public static short gPersonID;
		public static string serverPath;
		public static short dltDayEndID;
		public static short intCur;
		public static string[] intArrayProd = new string[101];
		public static short[] intArrayCode = new short[101];
		public static short[] intArrayQty = new short[101];
//loading languages files
		public static ADODB.Recordset rsLang;
		public static short iLangRTL;
//loading help file
		public static ADODB.Recordset rsHelp;

		public static void setServerPath()
		{
			return;
			Scripting.FileSystemObject FSO = new Scripting.FileSystemObject();
			int hkey = 0;
			int lRetVal = 0;
			string vValue = null;
			string lPath = null;
			lRetVal = modUtilities.RegOpenKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\4POS", 0, modUtilities.KEY_QUERY_VALUE, ref hkey);
			lRetVal = modUtilities.QueryValueEx(hkey, "server", ref vValue);
			modUtilities.RegCloseKey(hkey);
			if (string.IsNullOrEmpty(vValue)) {
				lPath = serverPath + "";
			} else {
				lPath = vValue;
			}

			if (Strings.Right(lPath, 1) != "\\")
				lPath = lPath + "\\";
			if (FSO.FolderExists(lPath)) {
				serverPath = lPath;
			} else {
				serverPath = "";
			}
		}

		public static void setNewServerPath()
		{
			Scripting.FileSystemObject FSO = new Scripting.FileSystemObject();
			int hkey = 0;
			int lRetVal = 0;
			string vValue = null;
			string lPath = null;
			lRetVal = modUtilities.RegOpenKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\4POS", 0, modUtilities.KEY_QUERY_VALUE, ref hkey);
			lRetVal = modUtilities.QueryValueEx(hkey, "server", ref vValue);
			modUtilities.RegCloseKey(hkey);
			if (string.IsNullOrEmpty(vValue)) {
				lPath = serverPath + "";
			} else {
				lPath = vValue;
			}

			if (Strings.Right(lPath, 1) != "\\")
				lPath = lPath + "\\";
			if (FSO.FolderExists(lPath)) {
				serverPath = lPath;
			} else {
				serverPath = "";
			}
		}

		public static ADODB.Recordset getRS(ref string sql)
		{
			ADODB.Recordset functionReturnValue = default(ADODB.Recordset);
			functionReturnValue = new ADODB.Recordset();
			functionReturnValue.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
			functionReturnValue.Open(sql, cnnDB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic, -1);
			return functionReturnValue;
			//Debug.Print(sql)
		}
		public static bool openConnection()
		{
			bool functionReturnValue = false;
			string Path = null;
			string cnnDBname = null;
			//this
			 // ERROR: Not supported in C#: OnErrorStatement

			//If Win7Ver() = True Then
			//Path = "c:\4posserver\"
			//Else
			//Path = String.Empty
			//End If
			cnnDBname = "4pos";
			cnnDB = new ADODB.Connection();
			//cnnDB.Provider = "Microsoft.ACE.OLEDB.12.0"
			cnnDB.Open(cnnDBname);

			//win 7
			Scripting.FileSystemObject FSO = new Scripting.FileSystemObject();
			Scripting.TextStream textstream = default(Scripting.TextStream);
			string lString = null;
			if (modWinVer.Win7Ver() == true) {
				if (FSO.FileExists("C:\\4POS\\4POSWinPath.txt")) {
					textstream = FSO.OpenTextFile("C:\\4POS\\4POSWinPath.txt", Scripting.IOMode.ForReading, true);
					lString = textstream.ReadAll;
					serverPath = lString;
					//& "pricing.mdb"
				} else {
					serverPath = "C:\\4POSServer\\";
					//"pricing.mdb"
				}
				functionReturnValue = true;
				return functionReturnValue;
			}
			//win 7

			serverPath = Strings.Split(Strings.Split(cnnDB.ConnectionString, ";DBQ=")[1], ";")[0];
			serverPath = Strings.Split(Strings.LCase(serverPath), "pricing.mdb")[0];
			//
			functionReturnValue = true;
			return functionReturnValue;
			if (string.IsNullOrEmpty(serverPath))
				setServerPath();
			string strDBPath = null;
			if (string.IsNullOrEmpty(serverPath)) {
				functionReturnValue = false;
			} else {
				functionReturnValue = true;
				cnnDB = new ADODB.Connection();
				strDBPath = serverPath + "Pricing.mdb";
				var _with1 = cnnDB;
				_with1.Provider = "Microsoft.ACE.OLEDB.12.0";
				_with1.Properties("Jet OLEDB:System Database").Value = serverPath + "secured.mdw";
				_with1.Open(strDBPath, "liquid", "lqd");
			}
			return functionReturnValue;
			withPass:

			if (string.IsNullOrEmpty(serverPath))
				setNewServerPath();
			if (!string.IsNullOrEmpty(serverPath)) {
				cnnDB = new ADODB.Connection();
				strDBPath = serverPath + "pricing.mdb";
				Path = strDBPath + ";Jet " + "OLEDB:Database Password=lqd";
				cnnDB.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
				cnnDB.Open("Provider=Microsoft.ACE.OLEDB.12.0;Persist Security Info=False;Data Source= " + Path);
				functionReturnValue = true;
			}
			return functionReturnValue;
			openConnection_Error:

			if (Err().Description == "[Microsoft][ODBC Microsoft Access Driver] Not a valid password.") {
				goto withPass;
			} else if (Err().Description == "Not a valid password.") {
				goto withPass;
			}

			functionReturnValue = false;
			return functionReturnValue;

		}
		public static ADODB.Connection openConnectionInstance(ref string lDatabase = "")
		{
			ADODB.Connection functionReturnValue = default(ADODB.Connection);
			string Path = null;
			Scripting.FileSystemObject FSO = new Scripting.FileSystemObject();

			if (string.IsNullOrEmpty(lDatabase))
				lDatabase = "Pricing.mdb";
			if (string.IsNullOrEmpty(serverPath))
				setServerPath();
			 // ERROR: Not supported in C#: OnErrorStatement

			ADODB.Connection cn = new ADODB.Connection();
			//UPGRADE_NOTE: Object openConnectionInstance may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			functionReturnValue = null;
			string strDBPath = null;
			if (string.IsNullOrEmpty(serverPath)) {
			} else {
				strDBPath = serverPath + lDatabase;
				var _with2 = cn;
				_with2.Provider = "Microsoft.ACE.OLEDB.12.0";
				_with2.Properties("Jet OLEDB:System Database").Value = serverPath + "Secured.mdw";
				_with2.Open(strDBPath, "liquid", "lqd");
				functionReturnValue = cn;
			}
			return functionReturnValue;
			withPass:

			if (string.IsNullOrEmpty(serverPath))
				setNewServerPath();
			if (!string.IsNullOrEmpty(serverPath)) {
				functionReturnValue = null;
				strDBPath = serverPath + lDatabase;
				Path = strDBPath + ";Jet " + "OLEDB:Database Password=lqd";
				cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
				cn.Open("Provider=Microsoft.ACE.OLEDB.12.0;Persist Security Info=False;Data Source= " + Path);
				functionReturnValue = cn;
			}
			return functionReturnValue;
			openConnection_Error:

			if (Err().Description == "[Microsoft][ODBC Microsoft Access Driver] Not a valid password.") {
				goto withPass;
			} else if (Err().Description == "Not a valid password.") {
				goto withPass;
			} else {
				Interaction.MsgBox(Err().Number + " - " + Err().Description);
			}
			return functionReturnValue;

		}
		public static ADODB.Connection openConnectionShapeInstance()
		{
			ADODB.Connection functionReturnValue = default(ADODB.Connection);
			string Path = null;
			string lDatabase = null;
			 // ERROR: Not supported in C#: OnErrorStatement

			ADODB.Connection cn = new ADODB.Connection();
			functionReturnValue = null;
			if (string.IsNullOrEmpty(serverPath))
				setServerPath();
			string strDBPath = null;
			if (string.IsNullOrEmpty(serverPath)) {
			} else {
				strDBPath = serverPath + "Pricing.mdb";
				var _with3 = cn;
				_with3.Provider = "MSDataShape";
				cn.Open("Data Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strDBPath + ";User Id=liquid;Password=lqd;Jet OLEDB:System Database=" + serverPath + "Secured.mdw");
				functionReturnValue = cn;
			}
			return functionReturnValue;
			withPass:

			if (string.IsNullOrEmpty(serverPath))
				setNewServerPath();
			if (!string.IsNullOrEmpty(serverPath)) {
				functionReturnValue = null;
				strDBPath = serverPath + lDatabase;
				Path = strDBPath + ";Jet " + "OLEDB:Database Password=lqd";
				cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
				cn.Open("Provider=Microsoft.ACE.OLEDB.12.0;Persist Security Info=False;Data Source= " + Path);
				functionReturnValue = cn;
			}
			return functionReturnValue;
			openConnectionShape_Error:

			if (Err().Description == "[Microsoft][ODBC Microsoft Access Driver] Not a valid password.") {
				goto withPass;
			} else if (Err().Description == "Not a valid password.") {
				goto withPass;
			} else {
				Interaction.MsgBox(Err().Number + " - " + Err().Description);
			}
			return functionReturnValue;
		}
		public static void closeConnection()
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			cnnDB.Close();
			cnnDB = null;
		}


		public static ADODB.Recordset getRSwaitron(ref object sql, ref ADODB.Connection cn)
		{
			ADODB.Recordset functionReturnValue = default(ADODB.Recordset);
			functionReturnValue = new ADODB.Recordset();
			functionReturnValue.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
			functionReturnValue.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
			return functionReturnValue;

		}


		public static ADODB.Connection openSComp(ref string lDatabase = "")
		{
			ADODB.Connection functionReturnValue = default(ADODB.Connection);
			Scripting.FileSystemObject FSO = new Scripting.FileSystemObject();

			//If lDatabase = "" Then lDatabase = "Pricing.mdb"
			//If serverPath = "" Then setServerPath
			if (string.IsNullOrEmpty(lDatabase))
				lDatabase = serverPath + "Pricing.mdb";
			 // ERROR: Not supported in C#: OnErrorStatement

			ADODB.Connection cn = new ADODB.Connection();
			functionReturnValue = null;
			string strDBPath = null;
			if (string.IsNullOrEmpty(lDatabase)) {
			} else {
				strDBPath = lDatabase;
				var _with4 = cn;
				_with4.Provider = "Microsoft.ACE.OLEDB.12.0";
				_with4.Properties("Jet OLEDB:System Database").Value = serverPath + "Secured.mdw";
				_with4.Open(strDBPath, "liquid", "lqd");
				functionReturnValue = cn;
			}
			return functionReturnValue;
			openConnection_Error:
			return functionReturnValue;


		}
	}
}
