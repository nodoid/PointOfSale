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
	static class modSocketMaster
	{
		[DllImport("kernel32", EntryPoint = "RtlMoveMemory", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
//**************************************************************************************
//
//modSocketMaster module 1.1
//Copyright (c) 2004 by Emiliano Scavuzzo <anshoku@yahoo.com>
//
//Rosario, Argentina
//
//**************************************************************************************
//This module contains API declarations and helper functions for the CSocketMaster class
//**************************************************************************************


//==============================================================================
//API FUNCTIONS
//==============================================================================

		public static extern void api_CopyMemory(ref object Destination, ref object Source, int Length);
		[DllImport("ws2_32.dll", EntryPoint = "WSAGetLastError", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		public static extern int api_WSAGetLastError();
		[DllImport("kernel32", EntryPoint = "GlobalAlloc", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		public static extern int api_GlobalAlloc(int wFlags, int dwBytes);
		[DllImport("kernel32", EntryPoint = "GlobalFree", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		public static extern int api_GlobalFree(int hMem);
		[DllImport("ws2_32.dll", EntryPoint = "WSAStartup", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
//UPGRADE_WARNING: Structure WSAData may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
		private static extern int api_WSAStartup(int wVersionRequired, ref WSAData lpWSADATA);
		[DllImport("ws2_32.dll", EntryPoint = "WSACleanup", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int api_WSACleanup();
		[DllImport("ws2_32.dll", EntryPoint = "WSAAsyncGetHostByName", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int api_WSAAsyncGetHostByName(int hwnd, int wMsg, string strHostName, ref object buf, int buflen);
		[DllImport("wsock32.dll", EntryPoint = "WSAAsyncSelect", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int api_WSAAsyncSelect(int s, int hwnd, int wMsg, int lEvent);
		[DllImport("user32", EntryPoint = "CreateWindowExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int api_CreateWindowEx(int dwExStyle, string lpClassName, string lpWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, int hWndParent, int hMenu,
		int hInstance, ref object lpParam);
		[DllImport("user32", EntryPoint = "DestroyWindow", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int api_DestroyWindow(int hwnd);
		[DllImport("kernel32", EntryPoint = "lstrlenA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int api_lstrlen(object lpString);
		[DllImport("kernel32", EntryPoint = "lstrcpyA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int api_lstrcpy(string lpString1, int lpString2);


//==============================================================================
//CONSTANTS
//==============================================================================

		public const short SOCKET_ERROR = -1;
		public const short INVALID_SOCKET = -1;
		public const int INADDR_NONE = 0xffff;

		private const short WSADESCRIPTION_LEN = 257;
		private const short WSASYS_STATUS_LEN = 129;

		private enum WinsockVersion
		{
			SOCKET_VERSION_11 = 0x101,
			SOCKET_VERSION_22 = 0x202
		}

		public const short MAXGETHOSTSTRUCT = 1024;

		public const int AF_INET = 2;
		public const int SOCK_STREAM = 1;
		public const int SOCK_DGRAM = 2;
		public const int IPPROTO_TCP = 6;
		public const int IPPROTO_UDP = 17;

		public const int FD_READ = 0x1;
		public const int FD_WRITE = 0x2;
		public const int FD_ACCEPT = 0x8;
		public const int FD_CONNECT = 0x10;
		public const int FD_CLOSE = 0x20;

		private const int OFFSET_2 = 65536;
		private const short MAXINT_2 = 32767;

		public const int GMEM_FIXED = 0x0;
		public const short LOCAL_HOST_BUFF = 256;

		public const int SOL_SOCKET = 65535;
		public const int SO_SNDBUF = 0x1001;
		public const int SO_RCVBUF = 0x1002;
		public const int SO_MAX_MSG_SIZE = 0x2003;
		public const int SO_BROADCAST = 0x20;
		public const int FIONREAD = 0x4004667f;

//==============================================================================
//ERROR CODES
//==============================================================================

		public const int WSABASEERR = 10000;
		public const int WSAEINTR = (WSABASEERR + 4);
		public const int WSAEACCES = (WSABASEERR + 13);
		public const int WSAEFAULT = (WSABASEERR + 14);
		public const int WSAEINVAL = (WSABASEERR + 22);
		public const int WSAEMFILE = (WSABASEERR + 24);
		public const int WSAEWOULDBLOCK = (WSABASEERR + 35);
		public const int WSAEINPROGRESS = (WSABASEERR + 36);
		public const int WSAEALREADY = (WSABASEERR + 37);
		public const int WSAENOTSOCK = (WSABASEERR + 38);
		public const int WSAEDESTADDRREQ = (WSABASEERR + 39);
		public const int WSAEMSGSIZE = (WSABASEERR + 40);
		public const int WSAEPROTOTYPE = (WSABASEERR + 41);
		public const int WSAENOPROTOOPT = (WSABASEERR + 42);
		public const int WSAEPROTONOSUPPORT = (WSABASEERR + 43);
		public const int WSAESOCKTNOSUPPORT = (WSABASEERR + 44);
		public const int WSAEOPNOTSUPP = (WSABASEERR + 45);
		public const int WSAEPFNOSUPPORT = (WSABASEERR + 46);
		public const int WSAEAFNOSUPPORT = (WSABASEERR + 47);
		public const int WSAEADDRINUSE = (WSABASEERR + 48);
		public const int WSAEADDRNOTAVAIL = (WSABASEERR + 49);
		public const int WSAENETDOWN = (WSABASEERR + 50);
		public const int WSAENETUNREACH = (WSABASEERR + 51);
		public const int WSAENETRESET = (WSABASEERR + 52);
		public const int WSAECONNABORTED = (WSABASEERR + 53);
		public const int WSAECONNRESET = (WSABASEERR + 54);
		public const int WSAENOBUFS = (WSABASEERR + 55);
		public const int WSAEISCONN = (WSABASEERR + 56);
		public const int WSAENOTCONN = (WSABASEERR + 57);
		public const int WSAESHUTDOWN = (WSABASEERR + 58);
		public const int WSAETIMEDOUT = (WSABASEERR + 60);
		public const int WSAEHOSTUNREACH = (WSABASEERR + 65);
		public const int WSAECONNREFUSED = (WSABASEERR + 61);
		public const int WSAEPROCLIM = (WSABASEERR + 67);
		public const int WSASYSNOTREADY = (WSABASEERR + 91);
		public const int WSAVERNOTSUPPORTED = (WSABASEERR + 92);
		public const int WSANOTINITIALISED = (WSABASEERR + 93);
		public const int WSAHOST_NOT_FOUND = (WSABASEERR + 1001);
		public const int WSATRY_AGAIN = (WSABASEERR + 1002);
		public const int WSANO_RECOVERY = (WSABASEERR + 1003);
		public const int WSANO_DATA = (WSABASEERR + 1004);

//==============================================================================
//WINSOCK CONTROL ERROR CODES
//==============================================================================

		public const short sckOutOfMemory = 7;
		public const int sckBadState = 40006;
		public const int sckInvalidArg = 40014;
		public const int sckUnsupported = 40018;
		public const int sckInvalidOp = 40020;

//==============================================================================
//STRUCTURES
//==============================================================================

		private struct WSAData
		{
			public short wVersion;
			public short wHighVersion;
			//UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
			[VBFixedString(modSocketMaster.WSADESCRIPTION_LEN), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = modSocketMaster.WSADESCRIPTION_LEN)]
			public char[] szDescription;
			//UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
			[VBFixedString(modSocketMaster.WSASYS_STATUS_LEN), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = modSocketMaster.WSASYS_STATUS_LEN)]
			public char[] szSystemStatus;
			public short iMaxSockets;
			public short iMaxUdpDg;
			public int lpVendorInfo;
		}

		public struct HOSTENT
		{
			public int hName;
			public int hAliases;
			public short hAddrType;
			public short hLength;
			public int hAddrList;
		}

		public struct sockaddr_in
		{
			public short sin_family;
			public short sin_port;
			public int sin_addr;
			[VBFixedArray(8)]
			public byte[] sin_zero;

			//UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
			public void Initialize()
			{
				//UPGRADE_WARNING: Lower bound of array sin_zero was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
				sin_zero = new byte[9];
			}
		}

//==============================================================================
//MEMBER VARIABLES
//==============================================================================

			//specify if winsock service was initiated
		private static bool m_blnInitiated;
			//number of instances created
		private static int m_lngSocksQuantity;
			//sockets list and instance owner
		private static Collection m_colSocketsInst;
			//sockets in queue that need to be accepted
		private static Collection m_colAcceptList;
			//message window handle
		private static int m_lngWindowHandle;
		[DllImport("user32", EntryPoint = "IsWindow", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

//==============================================================================
//SUBCLASSING DECLARATIONS
//by Paul Caton
//==============================================================================
		private static extern int api_IsWindow(int hwnd);
		[DllImport("user32", EntryPoint = "GetWindowLongA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int api_GetWindowLong(int hwnd, int nIndex);
		[DllImport("user32", EntryPoint = "SetWindowLongA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int api_SetWindowLong(int hwnd, int nIndex, int dwNewLong);
		[DllImport("kernel32", EntryPoint = "GetModuleHandleA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int api_GetModuleHandle(string lpModuleName);
		[DllImport("kernel32", EntryPoint = "GetProcAddress", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int api_GetProcAddress(int hModule, string lpProcName);

		private const int PATCH_06 = 106;
		private const int PATCH_09 = 137;

		private const short GWL_WNDPROC = (-4);

		private const int WM_USER = 0x400;

		public const int RESOLVE_MESSAGE = WM_USER + 0x400;
		public const int SOCKET_MESSAGE = WM_USER + 0x401;

			//TableA entry count
		private static int lngMsgCntA;
			//TableB entry count
		private static int lngMsgCntB;
			//TableA1: list of async handles
		private static int[] lngTableA1;
			//TableA2: list of async handles owners
		private static int[] lngTableA2;
			//TableB1: list of sockets
		private static int[] lngTableB1;
			//TableB2: list of sockets owners
		private static int[] lngTableB2;
			//window handle subclassed
		private static int hWndSub;
			//address of our WndProc
		private static int nAddrSubclass;
			//address of original WndProc
		private static int nAddrOriginal;


//This function initiates the processes needed to keep
//control of sockets. Returns 0 if it has success.
		public static int InitiateProcesses()
		{
			int functionReturnValue = 0;

			functionReturnValue = 0;
			m_lngSocksQuantity = m_lngSocksQuantity + 1;

			//if the service wasn't initiated yet we do it now
			int lngResult = 0;
			if (!m_blnInitiated) {

				Subclass_Initialize();

				m_blnInitiated = true;

				lngResult = InitiateService();

				if (lngResult == 0) {
					Debug.Print("OK Winsock service initiated");
				} else {
					Debug.Print("ERROR trying to initiate winsock service");
					Err().Raise(lngResult, "modSocketMaster.InitiateProcesses", GetErrorDescription(lngResult));
					functionReturnValue = lngResult;
				}

			}
			return functionReturnValue;
		}

//This function initiate the winsock service calling
//the api_WSAStartup funtion and returns resulting value.
		private static int InitiateService()
		{
			WSAData udtWSAData = default(WSAData);
			int lngResult = 0;

			lngResult = api_WSAStartup(WinsockVersion.SOCKET_VERSION_11, ref udtWSAData);
			return lngResult;
		}

//Once we are done with the class instance we call this
//function to discount it and finish winsock service if
//it was the last one.
//Returns 0 if it has success.
		public static int FinalizeProcesses()
		{
			int functionReturnValue = 0;
			functionReturnValue = 0;
			m_lngSocksQuantity = m_lngSocksQuantity - 1;

			//if the service was initiated and there's no more instances
			//of the class then we finish the service
			int lngErrorCode = 0;
			if (m_blnInitiated & m_lngSocksQuantity == 0) {
				if (FinalizeService() == SOCKET_ERROR) {
					lngErrorCode = Err().LastDllError;
					functionReturnValue = lngErrorCode;
					Err().Raise(lngErrorCode, "modSocketMaster.FinalizeProcesses", GetErrorDescription(lngErrorCode));
				} else {
					Debug.Print("OK Winsock service finalized");
				}

				Subclass_Terminate();
				m_blnInitiated = false;
			}
			return functionReturnValue;

		}

//Finish winsock service calling the function
//api_WSACleanup and returns the result.
		private static int FinalizeService()
		{
			int lngResultado = 0;
			lngResultado = api_WSACleanup();
			return lngResultado;
		}

//This function receives a number that represents an error
//and returns the corresponding description string.
		public static string GetErrorDescription(int lngErrorCode)
		{
			string functionReturnValue = null;
			switch (lngErrorCode) {
				case WSAEACCES:
					functionReturnValue = "Permission denied.";
					break;
				case WSAEADDRINUSE:
					functionReturnValue = "Address already in use.";
					break;
				case WSAEADDRNOTAVAIL:
					functionReturnValue = "Cannot assign requested address.";
					break;
				case WSAEAFNOSUPPORT:
					functionReturnValue = "Address family not supported by protocol family.";
					break;
				case WSAEALREADY:
					functionReturnValue = "Operation already in progress.";
					break;
				case WSAECONNABORTED:
					functionReturnValue = "Software caused connection abort.";
					break;
				case WSAECONNREFUSED:
					functionReturnValue = "Connection refused.";
					break;
				case WSAECONNRESET:
					functionReturnValue = "Connection reset by peer.";
					break;
				case WSAEDESTADDRREQ:
					functionReturnValue = "Destination address required.";
					break;
				case WSAEFAULT:
					functionReturnValue = "Bad address.";
					break;
				case WSAEHOSTUNREACH:
					functionReturnValue = "No route to host.";
					break;
				case WSAEINPROGRESS:
					functionReturnValue = "Operation now in progress.";
					break;
				case WSAEINTR:
					functionReturnValue = "Interrupted function call.";
					break;
				case WSAEINVAL:
					functionReturnValue = "Invalid argument.";
					break;
				case WSAEISCONN:
					functionReturnValue = "Socket is already connected.";
					break;
				case WSAEMFILE:
					functionReturnValue = "Too many open files.";
					break;
				case WSAEMSGSIZE:
					functionReturnValue = "Message too long.";
					break;
				case WSAENETDOWN:
					functionReturnValue = "Network is down.";
					break;
				case WSAENETRESET:
					functionReturnValue = "Network dropped connection on reset.";
					break;
				case WSAENETUNREACH:
					functionReturnValue = "Network is unreachable.";
					break;
				case WSAENOBUFS:
					functionReturnValue = "No buffer space available.";
					break;
				case WSAENOPROTOOPT:
					functionReturnValue = "Bad protocol option.";
					break;
				case WSAENOTCONN:
					functionReturnValue = "Socket is not connected.";
					break;
				case WSAENOTSOCK:
					functionReturnValue = "Socket operation on nonsocket.";
					break;
				case WSAEOPNOTSUPP:
					functionReturnValue = "Operation not supported.";
					break;
				case WSAEPFNOSUPPORT:
					functionReturnValue = "Protocol family not supported.";
					break;
				case WSAEPROCLIM:
					functionReturnValue = "Too many processes.";
					break;
				case WSAEPROTONOSUPPORT:
					functionReturnValue = "Protocol not supported.";
					break;
				case WSAEPROTOTYPE:
					functionReturnValue = "Protocol wrong type for socket.";
					break;
				case WSAESHUTDOWN:
					functionReturnValue = "Cannot send after socket shutdown.";
					break;
				case WSAESOCKTNOSUPPORT:
					functionReturnValue = "Socket type not supported.";
					break;
				case WSAETIMEDOUT:
					functionReturnValue = "Connection timed out.";
					break;
				case WSAEWOULDBLOCK:
					functionReturnValue = "Resource temporarily unavailable.";
					break;
				case WSAHOST_NOT_FOUND:
					functionReturnValue = "Host not found.";
					break;
				case WSANOTINITIALISED:
					functionReturnValue = "Successful WSAStartup not yet performed.";
					break;
				case WSANO_DATA:
					functionReturnValue = "Valid name, no data record of requested type.";
					break;
				case WSANO_RECOVERY:
					functionReturnValue = "This is a nonrecoverable error.";
					break;
				case WSASYSNOTREADY:
					functionReturnValue = "Network subsystem is unavailable.";
					break;
				case WSATRY_AGAIN:
					functionReturnValue = "Nonauthoritative host not found.";
					break;
				case WSAVERNOTSUPPORTED:
					functionReturnValue = "Winsock.dll version out of range.";
					break;
				default:
					functionReturnValue = "Unknown error.";
					break;
			}
			return functionReturnValue;

		}

//Create a window that is used to capture sockets messages.
//Returns 0 if it has success.
		private static int CreateWinsockMessageWindow()
		{
			int functionReturnValue = 0;
			m_lngWindowHandle = api_CreateWindowEx(0, "STATIC", "SOCKET_WINDOW", 0, 0, 0, 0, 0, 0, 0,
			Process.GetCurrentProcess().Handle.ToInt32(), ref 0);

			if (m_lngWindowHandle == 0) {
				functionReturnValue = sckOutOfMemory;
				return functionReturnValue;
			} else {
				functionReturnValue = 0;
				Debug.Print("OK Created winsock message window " + m_lngWindowHandle);
			}
			return functionReturnValue;
		}

//Destroy the window that is used to capture sockets messages.
//Returns 0 if it has success.
		private static int DestroyWinsockMessageWindow()
		{
			int functionReturnValue = 0;
			functionReturnValue = 0;

			if (m_lngWindowHandle == 0) {
				Debug.Print("WARNING lngWindowHandle is ZERO");
				return functionReturnValue;
			}

			int lngResult = 0;

			lngResult = api_DestroyWindow(m_lngWindowHandle);

			if (lngResult == 0) {
				functionReturnValue = sckOutOfMemory;
				Err().Raise(sckOutOfMemory, "modSocketMaster.DestroyWinsockMessageWindow", "Out of memory");
			} else {
				Debug.Print("OK Destroyed winsock message window " + m_lngWindowHandle);
				m_lngWindowHandle = 0;
			}
			return functionReturnValue;

		}

//When a socket needs to resolve a hostname in asynchronous way
//it calls this function. If it has success it returns a nonzero
//number that represents the async task handle and register this
//number in the TableA list.
//Returns 0 if it fails.
		public static int ResolveHost(string strHost, int lngHOSTENBuf, int lngObjectPointer)
		{
			int lngAsynHandle = 0;
			lngAsynHandle = api_WSAAsyncGetHostByName(m_lngWindowHandle, RESOLVE_MESSAGE, strHost, ref lngHOSTENBuf, MAXGETHOSTSTRUCT);
			if (lngAsynHandle != 0)
				Subclass_AddResolveMessage(lngAsynHandle, lngObjectPointer);
			return lngAsynHandle;
		}

//Returns the hi word from a double word.
		public static int HiWord(ref int lngValue)
		{
			int functionReturnValue = 0;
			if ((lngValue & 0x80000000) == 0x80000000) {
				functionReturnValue = ((lngValue & 0x7fff0000) / 0x10000) | 0x8000;
			} else {
				functionReturnValue = (lngValue & 0xffff0000) / 0x10000;
			}
			return functionReturnValue;
		}

//Returns the low word from a double word.
		public static int LoWord(ref int lngValue)
		{
			return (lngValue & 0xffff);
		}

//Receives a string pointer and it turns it into a regular string.
		public static string StringFromPointer(int lPointer)
		{
			string functionReturnValue = null;
			string strTemp = null;
			int lRetVal = 0;

			strTemp = new string(Strings.Chr(0), api_lstrlen(lPointer));
			lRetVal = api_lstrcpy(strTemp, lPointer);
			if (lRetVal)
				functionReturnValue = strTemp;
			return functionReturnValue;
		}

//The function takes an unsigned Integer from and API and 
//converts it to a Long for display or arithmetic purposes
		public static short UnsignedToInteger(ref int Value)
		{
			short functionReturnValue = 0;
			if (Value < 0 | Value >= OFFSET_2)
				 // ERROR: Not supported in C#: ErrorStatement

			// Overflow
			if (Value <= MAXINT_2) {
				functionReturnValue = Value;
			} else {
				functionReturnValue = Value - OFFSET_2;
			}
			return functionReturnValue;
		}

//The function takes a Long containing a value in the range 
//of an unsigned Integer and returns an Integer that you 
//can pass to an API that requires an unsigned Integer
		public static int IntegerToUnsigned(ref short Value)
		{
			int functionReturnValue = 0;
			if (Value < 0) {
				functionReturnValue = Value + OFFSET_2;
			} else {
				functionReturnValue = Value;
			}
			return functionReturnValue;
		}

//Adds the socket to the m_colSocketsInst collection, and
//registers that socket with WSAAsyncSelect Winsock API
//function to receive network events for the socket.
//If this socket is the first one to be registered, the
//window and collection will be created in this function as well.
		public static bool RegisterSocket(int lngSocket, int lngObjectPointer, bool blnEvents)
		{

			if (m_colSocketsInst == null) {
				m_colSocketsInst = new Collection();
				Debug.Print("OK Created socket collection");

				if (CreateWinsockMessageWindow() != 0) {
					Err().Raise(sckOutOfMemory, "modSocketMaster.RegisterSocket", "Out of memory");
				}

				Subclass_Subclass(m_lngWindowHandle);

			}

			Subclass_AddSocketMessage(lngSocket, lngObjectPointer);

			//Do we need to register socket events?
			int lngEvents = 0;
			int lngResult = 0;
			int lngErrorCode = 0;
			if (blnEvents) {

				lngEvents = FD_READ | FD_WRITE | FD_ACCEPT | FD_CONNECT | FD_CLOSE;
				lngResult = api_WSAAsyncSelect(lngSocket, m_lngWindowHandle, SOCKET_MESSAGE, lngEvents);

				if (lngResult == SOCKET_ERROR) {
					Debug.Print("ERROR trying to register events from socket " + lngSocket);
					lngErrorCode = Err().LastDllError;
					Err().Raise(lngErrorCode, "modSocketMaster.RegisterSocket", GetErrorDescription(lngErrorCode));
				} else {
					Debug.Print("OK Registered events from socket " + lngSocket);
				}
			}

			m_colSocketsInst.Add(lngObjectPointer, "S" + lngSocket);
			return true;
		}

//Removes the socket from the m_colSocketsInst collection
//If it is the last socket in that collection, the window
//and colection will be destroyed as well.
		public static void UnregisterSocket(int lngSocket)
		{
			Subclass_DelSocketMessage(lngSocket);
			 // ERROR: Not supported in C#: OnErrorStatement

			m_colSocketsInst.Remove("S" + lngSocket);

			if (m_colSocketsInst.Count() == 0) {
				//UPGRADE_NOTE: Object m_colSocketsInst may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				m_colSocketsInst = null;
				Subclass_UnSubclass();
				DestroyWinsockMessageWindow();
				Debug.Print("OK Destroyed socket collection");
			}
		}

//Returns TRUE si the socket that is passed is registered
//in the colSocketsInst collection.
		public static bool IsSocketRegistered(int lngSocket)
		{
			bool functionReturnValue = false;
			 // ERROR: Not supported in C#: OnErrorStatement


			m_colSocketsInst.Add("S" + lngSocket);
			functionReturnValue = true;
			return functionReturnValue;
			Error_Handler:


			functionReturnValue = false;
			return functionReturnValue;
		}

//When ResolveHost is called an async task handle is added
//to TableA list. Use this function to remove that record.
		public static void UnregisterResolution(int lngAsynHandle)
		{
			Subclass_DelResolveMessage(lngAsynHandle);
		}

//It turns a CSocketMaster instance pointer into an actual instance.
		private static CSocketMaster SocketObjectFromPointer(int lngPointer)
		{
			CSocketMaster functionReturnValue = null;

			CSocketMaster objSocket = null;

			//UPGRADE_WARNING: Couldn't resolve default property of object objSocket. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			api_CopyMemory(ref objSocket, ref lngPointer, 4);
			functionReturnValue = objSocket;
			//UPGRADE_WARNING: Couldn't resolve default property of object objSocket. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			api_CopyMemory(ref objSocket, ref 0, 4);
			return functionReturnValue;

		}

//Assing a temporal instance of CSocketMaster to a
//socket and register this socket to the accept list.
		public static void RegisterAccept(int lngSocket)
		{
			if (m_colAcceptList == null) {
				m_colAcceptList = new Collection();
				Debug.Print("OK Created accept collection");
			}
			CSocketMaster Socket = null;
			Socket = new CSocketMaster();
			Socket.Accept(ref lngSocket);
			m_colAcceptList.Add(Socket, "S" + lngSocket);
		}

//Returns True is lngSocket is registered on the
//accept list.
		public static bool IsAcceptRegistered(int lngSocket)
		{
			bool functionReturnValue = false;
			 // ERROR: Not supported in C#: OnErrorStatement


			m_colAcceptList.Add("S" + lngSocket);
			functionReturnValue = true;
			return functionReturnValue;
			Error_Handler:


			functionReturnValue = false;
			return functionReturnValue;
		}

//Unregister lngSocket from the accept list.
		public static void UnregisterAccept(int lngSocket)
		{
			m_colAcceptList.Remove("S" + lngSocket);

			if (m_colAcceptList.Count() == 0) {
				//UPGRADE_NOTE: Object m_colAcceptList may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				m_colAcceptList = null;
				Debug.Print("OK Destroyed accept collection");
			}
		}

//Return the accept instance class from a socket.
		public static CSocketMaster GetAcceptClass(int lngSocket)
		{
			return m_colAcceptList["S" + lngSocket];
		}


//==============================================================================
//SUBCLASSING CODE
//based on code by Paul Caton
//==============================================================================

		private static void Subclass_Initialize()
		{
			const int PATCH_01 = 15;
			//Code buffer offset to the location of the relative address to EbMode
			const int PATCH_03 = 76;
			//Relative address of SetWindowsLong
			const int PATCH_05 = 100;
			//Relative address of CallWindowProc
			const string FUNC_EBM = "EbMode";
			//VBA's EbMode function allows the machine code thunk to know if the IDE has stopped or is on a breakpoint
			const string FUNC_SWL = "SetWindowLongA";
			//SetWindowLong allows the cSubclasser machine code thunk to unsubclass the subclasser itself if it detects via the EbMode function that the IDE has stopped
			const string FUNC_CWP = "CallWindowProcA";
			//We use CallWindowProc to call the original WndProc
			const string MOD_VBA5 = "vba5";
			//Location of the EbMode function if running VB5
			const string MOD_VBA6 = "vba6";
			//Location of the EbMode function if running VB6
			const string MOD_USER = "user32";
			//Location of the SetWindowLong & CallWindowProc functions
			int i = 0;
			//Loop index
			int nLen = 0;
			//String lengths
			string sHex = null;
			//Hex code string
			string sCode = null;
			//Binary code string

			//Store the hex pair machine code representation in sHex
			sHex = "5850505589E55753515231C0EB0EE8xxxxx01x83F802742285C074258B45103D0008000074433D01080000745BE8200000005A595B5FC9C21400E813000000EBF168xxxxx02x6AFCFF750CE8xxxxx03xEBE0FF7518FF7514FF7510FF750C68xxxxx04xE8xxxxx05xC3BBxxxxx06x8B4514BFxxxxx07x89D9F2AF75B629CB4B8B1C9Dxxxxx08xEB1DBBxxxxx09x8B4514BFxxxxx0Ax89D9F2AF759729CB4B8B1C9Dxxxxx0Bx895D088B1B8B5B1C89D85A595B5FC9FFE0";
			nLen = Strings.Len(sHex);
			//Length of hex pair string

			//Convert the string from hex pairs to bytes and store in the ASCII string opcode buffer
			//For each pair of hex characters
			for (i = 1; i <= nLen; i += 2) {
				//UPGRADE_ISSUE: ChrB$ function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
				sCode = sCode + Convert.ToChar(Conversion.Val("&H" + Strings.Mid(sHex, i, 2)));
				//Convert a pair of hex characters to a byte and append to the ASCII string
			}
			//Next pair

			//UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
			nLen = modLenB.LenB(sCode);
			//Get the machine code length
			nAddrSubclass = api_GlobalAlloc(0, nLen);
			//Allocate fixed memory for machine code buffer
			Debug.Print("OK Subclass memory allocated at: " + nAddrSubclass);

			//Copy the code to allocated memory
			//UPGRADE_ISSUE: StrPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
			api_CopyMemory(ref nAddrSubclass, ref sCode, nLen);

			if (Subclass_InIDE()) {
				//Patch the jmp (EB0E) with two nop's (90) enabling the IDE breakpoint/stop checking code
				api_CopyMemory(ref nAddrSubclass + 12, ref 0x9090, 2);

				i = Subclass_AddrFunc(MOD_VBA6, FUNC_EBM);
				//Get the address of EbMode in vba6.dll
				//Found?
				if (i == 0) {
					i = Subclass_AddrFunc(MOD_VBA5, FUNC_EBM);
					//VB5 perhaps, try vba5.dll
				}

				System.Diagnostics.Debug.Assert(i, "");
				//Ensure the EbMode function was found
				Subclass_PatchRel(PATCH_01, i);
				//Patch the relative address to the EbMode api function
			}

			Subclass_PatchRel(PATCH_03, Subclass_AddrFunc(MOD_USER, FUNC_SWL));
			//Address of the SetWindowLong api function
			Subclass_PatchRel(PATCH_05, Subclass_AddrFunc(MOD_USER, FUNC_CWP));
			//Address of the CallWindowProc api function
		}

//UnSubclass and release the allocated memory
		private static void Subclass_Terminate()
		{
			Subclass_UnSubclass();
			//UnSubclass if the Subclass thunk is active
			api_GlobalFree(nAddrSubclass);
			//Release the allocated memory
			Debug.Print("OK Freed subclass memory at: " + nAddrSubclass);
			nAddrSubclass = 0;
			//UPGRADE_WARNING: Lower bound of array lngTableA1 was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
			lngTableA1 = new int[2];
			//UPGRADE_WARNING: Lower bound of array lngTableA2 was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
			lngTableA2 = new int[2];
			//UPGRADE_WARNING: Lower bound of array lngTableB1 was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
			lngTableB1 = new int[2];
			//UPGRADE_WARNING: Lower bound of array lngTableB2 was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
			lngTableB2 = new int[2];
		}

//Return whether we're running in the IDE. Public for general utility purposes
		private static bool Subclass_InIDE()
		{
			System.Diagnostics.Debug.Assert(Subclass_SetTrue(ref Subclass_InIDE()), "");
		}

//Set the window subclass
		private static bool Subclass_Subclass(int hwnd)
		{
			bool functionReturnValue = false;
			const int PATCH_02 = 66;
			//Address of the previous WndProc
			const int PATCH_04 = 95;
			//Address of the previous WndProc

			if (hWndSub == 0) {
				System.Diagnostics.Debug.Assert(api_IsWindow(hwnd), "");
				//Invalid window handle
				hWndSub = hwnd;
				//Store the window handle

				//Get the original window proc
				nAddrOriginal = api_GetWindowLong(hwnd, GWL_WNDPROC);
				Subclass_PatchVal(PATCH_02, nAddrOriginal);
				//Original WndProc address for CallWindowProc, call the original WndProc
				Subclass_PatchVal(PATCH_04, nAddrOriginal);
				//Original WndProc address for SetWindowLong, unsubclass on IDE stop

				//Set our WndProc in place of the original
				nAddrOriginal = api_SetWindowLong(hwnd, GWL_WNDPROC, nAddrSubclass);
				if (nAddrOriginal != 0) {
					nAddrOriginal = 0;
					functionReturnValue = true;
					//Success
				}
			}

			System.Diagnostics.Debug.Assert(Subclass_Subclass(), "");
			return functionReturnValue;
		}

//Stop subclassing the window
		private static bool Subclass_UnSubclass()
		{
			bool functionReturnValue = false;
			if (hWndSub != 0) {
				lngMsgCntA = 0;
				lngMsgCntB = 0;
				Subclass_PatchVal(PATCH_06, lngMsgCntA);
				//Patch the TableA entry count to ensure no further Proc callbacks
				Subclass_PatchVal(PATCH_09, lngMsgCntB);
				//Patch the TableB entry count to ensure no further Proc callbacks

				//Restore the original WndProc
				api_SetWindowLong(hWndSub, GWL_WNDPROC, nAddrOriginal);

				hWndSub = 0;
				//Indicate the subclasser is inactive

				functionReturnValue = true;
				//Success
			}
			return functionReturnValue;

		}

//Return the address of the passed function in the passed dll
		private static int Subclass_AddrFunc(string sDLL, string sProc)
		{
			return api_GetProcAddress(api_GetModuleHandle(sDLL), sProc);

		}

//Return the address of the low bound of the passed table array
		private static int Subclass_AddrMsgTbl(ref int[] aMsgTbl)
		{
			int functionReturnValue = 0;
			 // ERROR: Not supported in C#: OnErrorStatement

			//The table may not be dimensioned yet so we need protection
			//UPGRADE_ISSUE: VarPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
			functionReturnValue = VarPtr.VarPtr(aMsgTbl[1]);
			//Get the address of the first element of the passed message table
			 // ERROR: Not supported in C#: OnErrorStatement

			return functionReturnValue;
			//Switch off error protection
		}

//Patch the machine code buffer offset with the relative address to the target address
		private static void Subclass_PatchRel(int nOffset, int nTargetAddr)
		{
			api_CopyMemory(ref nAddrSubclass + nOffset, ref nTargetAddr - nAddrSubclass - nOffset - 4, 4);
		}

//Patch the machine code buffer offset with the passed value
		private static void Subclass_PatchVal(int nOffset, int nValue)
		{
			api_CopyMemory(ref nAddrSubclass + nOffset, ref nValue, 4);
		}

//Worker function for InIDE - will only be called whilst running in the IDE
		private static bool Subclass_SetTrue(ref bool bValue)
		{
			bool functionReturnValue = false;
			functionReturnValue = true;
			bValue = true;
			return functionReturnValue;
		}

		private static void Subclass_AddResolveMessage(int lngAsync, int lngObjectPointer)
		{
			int Count = 0;
			for (Count = 1; Count <= lngMsgCntA; Count++) {
				switch (lngTableA1[Count]) {

					case -1:
						lngTableA1[Count] = lngAsync;
						lngTableA2[Count] = lngObjectPointer;
						return;

						break;
					case lngAsync:
						Debug.Print("WARNING: Async already registered!");
						return;

						break;
				}
			}

			lngMsgCntA = lngMsgCntA + 1;
			//UPGRADE_WARNING: Lower bound of array lngTableA1 was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
			Array.Resize(ref lngTableA1, lngMsgCntA + 1);
			//UPGRADE_WARNING: Lower bound of array lngTableA2 was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
			Array.Resize(ref lngTableA2, lngMsgCntA + 1);

			lngTableA1[lngMsgCntA] = lngAsync;
			lngTableA2[lngMsgCntA] = lngObjectPointer;
			Subclass_PatchTableA();

		}

		private static void Subclass_AddSocketMessage(int lngSocket, int lngObjectPointer)
		{
			int Count = 0;
			for (Count = 1; Count <= lngMsgCntB; Count++) {
				switch (lngTableB1[Count]) {

					case -1:
						lngTableB1[Count] = lngSocket;
						lngTableB2[Count] = lngObjectPointer;
						return;

						break;
					case lngSocket:
						Debug.Print("WARNING: Socket already registered!");
						return;

						break;
				}
			}

			lngMsgCntB = lngMsgCntB + 1;
			//UPGRADE_WARNING: Lower bound of array lngTableB1 was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
			Array.Resize(ref lngTableB1, lngMsgCntB + 1);
			//UPGRADE_WARNING: Lower bound of array lngTableB2 was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
			Array.Resize(ref lngTableB2, lngMsgCntB + 1);

			lngTableB1[lngMsgCntB] = lngSocket;
			lngTableB2[lngMsgCntB] = lngObjectPointer;
			Subclass_PatchTableB();

		}

		private static void Subclass_DelResolveMessage(int lngAsync)
		{
			int Count = 0;
			for (Count = 1; Count <= lngMsgCntA; Count++) {
				if (lngTableA1[Count] == lngAsync) {
					lngTableA1[Count] = -1;
					lngTableA2[Count] = -1;
					return;
				}
			}
		}

		private static void Subclass_DelSocketMessage(int lngSocket)
		{
			int Count = 0;
			for (Count = 1; Count <= lngMsgCntB; Count++) {
				if (lngTableB1[Count] == lngSocket) {
					lngTableB1[Count] = -1;
					lngTableB2[Count] = -1;
					return;
				}
			}
		}

		private static void Subclass_PatchTableA()
		{
			const int PATCH_07 = 114;
			const int PATCH_08 = 130;

			Subclass_PatchVal(PATCH_06, lngMsgCntA);
			Subclass_PatchVal(PATCH_07, Subclass_AddrMsgTbl(ref lngTableA1));
			Subclass_PatchVal(PATCH_08, Subclass_AddrMsgTbl(ref lngTableA2));
		}

		private static void Subclass_PatchTableB()
		{
			const int PATCH_0A = 145;
			const int PATCH_0B = 161;

			Subclass_PatchVal(PATCH_09, lngMsgCntB);
			Subclass_PatchVal(PATCH_0A, Subclass_AddrMsgTbl(ref lngTableB1));
			Subclass_PatchVal(PATCH_0B, Subclass_AddrMsgTbl(ref lngTableB2));
		}

		public static void Subclass_ChangeOwner(int lngSocket, int lngObjectPointer)
		{
			int Count = 0;
			for (Count = 1; Count <= lngMsgCntB; Count++) {
				if (lngTableB1[Count] == lngSocket) {
					lngTableB2[Count] = lngObjectPointer;
					return;
				}
			}
		}
	}
}
