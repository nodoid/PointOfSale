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
namespace _4PosBackOffice.NET
{
	static class Module1
	{
//**************************************************************************************************************************
		public static bool bActiveSession;
		public static int hOpen;
		public static int hConnection;
		public static int dwType;
		public static bool cor;
		public static clsFileIni objIniFile;
		public static object dirrecv;
		public static object password;
		public static object server;
		public static object BranchID;
		public static object BranchType;
		public static object HOfficeID;
		public static object ServerN;
		public static object username;
		public static object dirsend;
		public static object dirserv;
		public static string tipftp;
		public static object sqlUser;
		public static object sqlLinkPath;
		public static object sqlServer;
		public static object sqlPassWord;
		public static string sqlDBase;
			//Interface to be used to for connection
		public static ADODB.Connection sqlDBcn;
		public static bool bBranchChange;
		public static bool bUploadReport;
		public static string sGRVSales;

		public static string prgCol;
			#if Win16
		public static string NomeFileLog;
		[DllImport("KERNEL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
//UPGRADE_NOTE: #If #EndIf block was not upgraded because the expression Win16 did not evaluate to True or was not evaluated. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"'
		private static extern int WritePrivateProfileString(string AppName, string KeyName, string keydefault, string FileName);
		[DllImport("KERNEL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int GetPrivateProfileString(string AppName, string KeyName, string keydefault, string ReturnString, int NumBytes, string FileName);
		[DllImport("kernel32", EntryPoint = "WritePrivateProfileStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		#elif Win32 Then
		private static extern int WritePrivateProfileString(string AppName, string KeyName, string keydefault, string FileName);
		[DllImport("kernel32", EntryPoint = "GetPrivateProfileStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int GetPrivateProfileString(string AppName, string KeyName, string keydefault, string ReturnString, int NumBytes, string FileName);
		[DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		#endif
//**************************************************************************************************************************************

		public static extern int GetProcessHeap();
		[DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		public static extern int HeapAlloc(int hHeap, int dwFlags, int dwBytes);
		[DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		public static extern int HeapFree(int hHeap, int dwFlags, ref object lpMem);
		public const int HEAP_ZERO_MEMORY = 0x8;
		public const int HEAP_GENERATE_EXCEPTIONS = 0x4;
		[DllImport("kernel32", EntryPoint = "RtlMoveMemory", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		public static extern void copymemory1(ref object hpvDest, int hpvsource, int cbCopy);
		[DllImport("kernel32", EntryPoint = "RtlMoveMemory", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		public static extern void CopyMemory2(ref int hpvDest, ref object hpvsource, int cbCopy);

		public const short MAX_PATH = 260;
		public const short NO_ERROR = 0;
		public const int FILE_ATTRIBUTE_READONLY = 0x1;
		public const int FILE_ATTRIBUTE_HIDDEN = 0x2;
		public const int FILE_ATTRIBUTE_SYSTEM = 0x4;
		public const int FILE_ATTRIBUTE_DIRECTORY = 0x10;
		public const int FILE_ATTRIBUTE_ARCHIVE = 0x20;
		public const int FILE_ATTRIBUTE_NORMAL = 0x80;
		public const int FILE_ATTRIBUTE_TEMPORARY = 0x100;
		public const int FILE_ATTRIBUTE_COMPRESSED = 0x800;
		public const int FILE_ATTRIBUTE_OFFLINE = 0x1000;

		public struct FILETIME
		{
			public int dwLowDateTime;
			public int dwHighDateTime;
		}
		public struct WIN32_FIND_DATA
		{
			public int dwFileAttributes;
			public FILETIME ftCreationTime;
			public FILETIME ftLastAccessTime;
			public FILETIME ftLastWriteTime;
			public int nFileSizeHigh;
			public int nFileSizeLow;
			public int dwReserved0;
			public int dwReserved1;
			//UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
			[VBFixedString(Module1.MAX_PATH), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = Module1.MAX_PATH)]
			public char[] cFileName;
			//UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
			[VBFixedString(14), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 14)]
			public char[] cAlternate;
		}

		public const short ERROR_NO_MORE_FILES = 18;
		[DllImport("wininet.dll", EntryPoint = "InternetFindNextFileA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

//UPGRADE_WARNING: Structure WIN32_FIND_DATA may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
		public static extern int InternetFindNextFile(int hFind, ref WIN32_FIND_DATA lpvFindData);
		[DllImport("wininet.dll", EntryPoint = "FtpFindFirstFileA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

//UPGRADE_WARNING: Structure WIN32_FIND_DATA may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
		public static extern int FtpFindFirstFile(int hFtpSession, string lpszSearchFile, ref WIN32_FIND_DATA lpFindFileData, int dwFlags, int dwContent);
		[DllImport("wininet.dll", EntryPoint = "FtpGetFileA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		public static extern bool FtpGetFile(int hFtpSession, string lpszRemoteFile, string lpszNewFile, bool fFailIfExists, int dwFlagsAndAttributes, int dwFlags, int dwContext);
		[DllImport("wininet.dll", EntryPoint = "FtpPutFileA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		public static extern bool FtpPutFile(int hFtpSession, string lpszLocalFile, string lpszRemoteFile, int dwFlags, int dwContext);
		[DllImport("wininet.dll", EntryPoint = "FtpSetCurrentDirectoryA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		public static extern bool FtpSetCurrentDirectory(int hFtpSession, string lpszDirectory);
		[DllImport("wininet.dll", EntryPoint = "InternetOpenA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
// Initializes an application's use of the Win32 Internet functions
		public static extern int InternetOpen(string sAgent, int lAccessType, string sProxyName, string sProxyBypass, int lFlags);

// User agent constant.
		public const string scUserAgent = "vb wininet";

// Use registry access settings.
		public const short INTERNET_OPEN_TYPE_PRECONFIG = 0;
		public const short INTERNET_OPEN_TYPE_DIRECT = 1;
		public const short INTERNET_OPEN_TYPE_PROXY = 3;
		public const short INTERNET_INVALID_PORT_NUMBER = 0;

		public const int FTP_TRANSFER_TYPE_BINARY = 0x2;
		public const int FTP_TRANSFER_TYPE_ASCII = 0x1;
		public const int INTERNET_FLAG_PASSIVE = 0x8000000;
		[DllImport("wininet.dll", EntryPoint = "InternetConnectA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

// Opens a HTTP session for a given site.
		public static extern int InternetConnect(int hInternetSession, string sServerName, short nServerPort, string sUsername, string sPassword, int lService, int lFlags, int lContext);

		public const short ERROR_INTERNET_EXTENDED_ERROR = 12003;
		[DllImport("wininet.dll", EntryPoint = "InternetGetLastResponseInfoA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		public static extern bool InternetGetLastResponseInfo(ref int lpdwError, string lpszBuffer, ref int lpdwBufferLength);

// Number of the TCP/IP port on the server to connect to.
		public const short INTERNET_DEFAULT_FTP_PORT = 21;
		public const short INTERNET_DEFAULT_GOPHER_PORT = 70;
		public const short INTERNET_DEFAULT_HTTP_PORT = 80;
		public const short INTERNET_DEFAULT_HTTPS_PORT = 443;
		public const short INTERNET_DEFAULT_SOCKS_PORT = 1080;

		public const short INTERNET_OPTION_CONNECT_TIMEOUT = 2;
		public const short INTERNET_OPTION_RECEIVE_TIMEOUT = 6;
		public const short INTERNET_OPTION_SEND_TIMEOUT = 5;

		public const short INTERNET_OPTION_USERNAME = 28;
		public const short INTERNET_OPTION_PASSWORD = 29;
		public const short INTERNET_OPTION_PROXY_USERNAME = 43;
		public const short INTERNET_OPTION_PROXY_PASSWORD = 44;

// Type of service to access.
		public const short INTERNET_SERVICE_FTP = 1;
		public const short INTERNET_SERVICE_GOPHER = 2;
		public const short INTERNET_SERVICE_HTTP = 3;
		[DllImport("wininet.dll", EntryPoint = "HttpOpenRequestA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

// Opens an HTTP request handle.
		public static extern int HttpOpenRequest(int hHttpSession, string sVerb, string sObjectName, string sVersion, string sReferer, int something, int lFlags, int lContext);

// Brings the data across the wire even if it locally cached.
		public const int INTERNET_FLAG_RELOAD = 0x80000000;
		public const int INTERNET_FLAG_KEEP_CONNECTION = 0x400000;
		public const int INTERNET_FLAG_MULTIPART = 0x200000;

		public const int GENERIC_READ = 0x80000000;
		public const int GENERIC_WRITE = 0x40000000;
		[DllImport("wininet.dll", EntryPoint = "HttpSendRequestA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

// Sends the specified request to the HTTP server.
		public static extern short HttpSendRequest(int hHttpRequest, string sHeaders, int lHeadersLength, string sOptional, int lOptionalLength);
		[DllImport("wininet.dll", EntryPoint = "HttpQueryInfoA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]


// Queries for information about an HTTP request.
		public static extern short HttpQueryInfo(int hHttpRequest, int lInfoLevel, ref object sBuffer, ref int lBufferLength, ref int lIndex);

// The possible values for the lInfoLevel parameter include:
		public const short HTTP_QUERY_CONTENT_TYPE = 1;
		public const short HTTP_QUERY_CONTENT_LENGTH = 5;
		public const short HTTP_QUERY_EXPIRES = 10;
		public const short HTTP_QUERY_LAST_MODIFIED = 11;
		public const short HTTP_QUERY_PRAGMA = 17;
		public const short HTTP_QUERY_VERSION = 18;
		public const short HTTP_QUERY_STATUS_CODE = 19;
		public const short HTTP_QUERY_STATUS_TEXT = 20;
		public const short HTTP_QUERY_RAW_HEADERS = 21;
		public const short HTTP_QUERY_RAW_HEADERS_CRLF = 22;
		public const short HTTP_QUERY_FORWARDED = 30;
		public const short HTTP_QUERY_SERVER = 37;
		public const short HTTP_QUERY_USER_AGENT = 39;
		public const short HTTP_QUERY_SET_COOKIE = 43;
		public const short HTTP_QUERY_REQUEST_METHOD = 45;
		public const short HTTP_STATUS_DENIED = 401;
		public const short HTTP_STATUS_PROXY_AUTH_REQ = 407;

// Add this flag to the about flags to get request header.
		public const int HTTP_QUERY_FLAG_REQUEST_HEADERS = 0x80000000;
		public const int HTTP_QUERY_FLAG_NUMBER = 0x20000000;
		[DllImport("wininet.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
// Reads data from a handle opened by the HttpOpenRequest function.
		public static extern short InternetReadFile(int hFile, string sBuffer, int lNumBytesToRead, ref int lNumberOfBytesRead);
		[DllImport("wininet.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		public static extern short InternetWriteFile(int hFile, string sBuffer, int lNumberOfBytesToRead, ref int lNumberOfBytesRead);
		[DllImport("wininet.dll", EntryPoint = "FtpOpenFileA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		public static extern int FtpOpenFile(int hFtpSession, string sFileName, int lAccess, int lFlags, int lContext);
		[DllImport("wininet.dll", EntryPoint = "FtpDeleteFileA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		public static extern bool FtpDeleteFile(int hFtpSession, string lpszFileName);
		[DllImport("wininet.dll", EntryPoint = "InternetSetOptionA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		public static extern short InternetSetOption(int hInternet, int lOption, ref object sBuffer, int lBufferLength);
		[DllImport("wininet.dll", EntryPoint = "InternetSetOptionA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		public static extern short InternetSetOptionStr(int hInternet, int lOption, string sBuffer, int lBufferLength);
		[DllImport("wininet.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

// Closes a single Internet handle or a subtree of Internet handles.
		public static extern short InternetCloseHandle(int hInet);
		[DllImport("wininet.dll", EntryPoint = "InternetQueryOptionA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

// Queries an Internet option on the specified handle
		public static extern short InternetQueryOption(int hInternet, int lOption, ref object sBuffer, ref int lBufferLength);

// Returns the version number of Wininet.dll.
		public const short INTERNET_OPTION_VERSION = 40;

// Contains the version number of the DLL that contains the Windows Internet
// functions (Wininet.dll). This structure is used when passing the
// INTERNET_OPTION_VERSION flag to the InternetQueryOption function.
		public struct tWinInetDLLVersion
		{
			public int lMajorVersion;
			public int lMinorVersion;
		}
		[DllImport("wininet.dll", EntryPoint = "HttpAddRequestHeadersA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

// Adds one or more HTTP request headers to the HTTP request handle.
		public static extern short HttpAddRequestHeaders(int hHttpRequest, string sHeaders, int lHeadersLength, int lModifiers);

// Flags to modify the semantics of this function. Can be a combination of these values:

// Adds the header only if it does not already exist; otherwise, an error is returned.
		public const int HTTP_ADDREQ_FLAG_ADD_IF_NEW = 0x10000000;

// Adds the header if it does not exist. Used with REPLACE.
		public const int HTTP_ADDREQ_FLAG_ADD = 0x20000000;

// Replaces or removes a header. If the header value is empty and the header is found,
// it is removed. If not empty, the header value is replaced
		public const int HTTP_ADDREQ_FLAG_REPLACE = 0x80000000;
		[DllImport("user32", EntryPoint = "FindWindowA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

//FOR PASSWORD INPUTPUTBOX
		private static extern int FindWindow(string lpClassName, string lpWindowName);
		[DllImport("user32", EntryPoint = "FindWindowExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		private static extern int FindWindowEx(int hWnd1, int hWnd2, string lpsz1, string lpsz2);
		[DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		public static extern int SetTimer(int hwnd, int nIDEvent, int uElapse, int lpTimerFunc);
		[DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		private static extern int KillTimer(int hwnd, int nIDEvent);
		[DllImport("user32", EntryPoint = "SendMessageA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		private static extern int SendMessage(int hwnd, int wMsg, int wParam, ref object lParam);

		const int EM_SETPASSWORDCHAR = 0xcc;
		public const int NV_INPUTBOX = 0x5000;

//FOR PASSWORD INPUTPUTBOX
		public static void TimerProc(int hwnd, int uMsg, int idEvent, int dwTime)
		{

			int EditHwnd = 0;
			// CHANGE APP.TITLE TO YOUR INPUT BOX TITLE.
			EditHwnd = FindWindowEx(FindWindow("#32770", _4PosBackOffice.NET.My.MyProject.Application.Info.Title), 0, "Edit", "");

			SendMessage(EditHwnd, EM_SETPASSWORDCHAR, Strings.Asc("*"), ref 0);
			KillTimer(hwnd, idEvent);
		}

		public static void CaricaDati()
		{

			objIniFile = new clsFileIni();
			objIniFile.FileINI = _4PosBackOffice.NET.My.MyProject.Application.Info.DirectoryPath + "\\" + "4POSHQ.INI";
			objIniFile.section = "Configuration Info";
			objIniFile.Key = "";
			//"FTPSERVER"
			objIniFile.ReadFromINI();
			//UPGRADE_WARNING: Couldn't resolve default property of object ServerN. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ServerN = "http://www.4pos.co.za/testHQ/4posheadoffice.pos";
			//server = objIniFile.Description
			objIniFile.Key = "BranchType";
			objIniFile.ReadFromINI();
			//UPGRADE_WARNING: Couldn't resolve default property of object BranchType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			BranchType = objIniFile.Description;
			//username = objIniFile.Description
			objIniFile.Key = "BranchID";
			objIniFile.ReadFromINI();
			//password = objIniFile.Description
			//UPGRADE_WARNING: Couldn't resolve default property of object BranchID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			BranchID = objIniFile.Description;
			objIniFile.Key = "DIRSEND";
			objIniFile.ReadFromINI();
			//UPGRADE_WARNING: Couldn't resolve default property of object dirsend. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dirsend = objIniFile.Description;
			objIniFile.Key = "DIRRECV";
			objIniFile.ReadFromINI();
			//UPGRADE_WARNING: Couldn't resolve default property of object dirrecv. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dirrecv = objIniFile.Description;
			objIniFile.Key = "DIRSERV";
			objIniFile.ReadFromINI();
			//UPGRADE_WARNING: Couldn't resolve default property of object dirserv. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dirserv = objIniFile.Description;
			objIniFile.Key = Convert.ToString(1);
			//"TIPFTP"
			objIniFile.ReadFromINI();
			tipftp = Convert.ToString(1);
			//objIniFile.Description
			//UPGRADE_NOTE: Object objIniFile may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			objIniFile = null;

		}

//UPGRADE_NOTE: Main was upgraded to Main_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private static void Main_Renamed()
		{

			//Set variables
			bActiveSession = false;
			hOpen = 0;
			hConnection = 0;
			dwType = FTP_TRANSFER_TYPE_BINARY;
			prgCol = "4POS-HQ_";
			NomeFileLog = prgCol + Convert.ToString(Strings.Format(DateAndTime.Now, "ddmmyyyy")) + Convert.ToString(Strings.Format(DateAndTime.Now, "hhmm")) + ".log";

			CaricaDati();
			//read the file
			//frmMainHO.Text1.Text = ""
			//frmMainHO.Label1(1).Caption = ""
			//UPGRADE_ISSUE: Load statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"'
			//Load(frmMainHO)
			//PreparaForm
			//frmFTP.Show vbModal
			My.MyProject.Forms.frmMainHO.ShowDialog();
			//vbModal

		}
		public static void PreparaForm(ref string Caso = "")
		{

			if (bActiveSession == true) {
				if (string.IsNullOrEmpty(Strings.Trim(Caso))) {
					My.MyProject.Forms.frmMainHO._cmdPulsante_0.Enabled = false;
					My.MyProject.Forms.frmMainHO._cmdPulsante_1.Enabled = true;
					My.MyProject.Forms.frmMainHO._cmdPulsante_2.Enabled = false;
					My.MyProject.Forms.frmMainHO._cmdPulsante_3.Enabled = false;
					My.MyProject.Forms.frmMainHO._cmdPulsante_4.Enabled = false;
					My.MyProject.Forms.frmMainHO._cmdPulsante_6.Enabled = true;
					My.MyProject.Forms.frmMainHO._cmdPulsante_7.Enabled = true;
				} else {
					if (Caso == "UpLoad") {
						My.MyProject.Forms.frmMainHO._cmdPulsante_1.Enabled = false;
						My.MyProject.Forms.frmMainHO._cmdPulsante_7.Enabled = false;
					}
					if (Caso == "UpLoadFine") {
						My.MyProject.Forms.frmMainHO._cmdPulsante_1.Enabled = true;
						My.MyProject.Forms.frmMainHO._cmdPulsante_7.Enabled = true;
					}
					if (Caso == "DownLoad") {
						My.MyProject.Forms.frmMainHO._cmdPulsante_1.Enabled = false;
						My.MyProject.Forms.frmMainHO._cmdPulsante_6.Enabled = false;
					}
					if (Caso == "DownLoadFine") {
						My.MyProject.Forms.frmMainHO._cmdPulsante_1.Enabled = true;
						My.MyProject.Forms.frmMainHO._cmdPulsante_6.Enabled = true;
					}

				}
			} else if (bActiveSession == false) {
				My.MyProject.Forms.frmMainHO._cmdPulsante_0.Enabled = true;
				My.MyProject.Forms.frmMainHO._cmdPulsante_1.Enabled = false;
				My.MyProject.Forms.frmMainHO._cmdPulsante_2.Enabled = true;
				My.MyProject.Forms.frmMainHO._cmdPulsante_3.Enabled = true;
				My.MyProject.Forms.frmMainHO._cmdPulsante_4.Enabled = true;
				My.MyProject.Forms.frmMainHO._cmdPulsante_6.Enabled = false;
				My.MyProject.Forms.frmMainHO._cmdPulsante_7.Enabled = false;
			}

		}
	}
}
