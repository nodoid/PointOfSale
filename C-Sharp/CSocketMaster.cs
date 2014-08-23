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
using System.Text.UnicodeEncoding;
namespace _4PosBackOffice.NET
{
	internal class CSocketMaster
	{
		[DllImport("ws2_32.dll", EntryPoint = "socket", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		//********************************************************************************
		//
		//Name.......... CSocketMaster
		//File.......... CSocketMaster.cls
		//Version....... 1.1
		//Dependencies.. Requires modSocketMaster.bas code module
		//Description... Winsock api implementation class
		//Author........ Emiliano Scavuzzo <anshoku@yahoo.com>
		//Date.......... February, 22nd 2004

		//Copyright (c) 2004 by Emiliano Scavuzzo
		//Rosario, Argentina
		//
		//Based on CSocket by Oleg Gdalevich
		//Subclassing based on WinSubHook2 by Paul Caton <Paul_Caton@hotmail.com>
		//
		//********************************************************************************


		//==============================================================================
		//API FUNCTIONS
		//==============================================================================

		private static extern int api_socket(int af, int s_type, int Protocol);
		[DllImport("kernel32", EntryPoint = "GlobalLock", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int api_GlobalLock(int hMem);
		[DllImport("kernel32", EntryPoint = "GlobalUnlock", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int api_GlobalUnlock(int hMem);
		[DllImport("ws2_32.dll", EntryPoint = "htons", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern short api_htons(short hostshort);
		[DllImport("ws2_32.dll", EntryPoint = "ntohs", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern short api_ntohs(short netshort);
		[DllImport("ws2_32.dll", EntryPoint = "connect", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//UPGRADE_WARNING: Structure sockaddr_in may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
		private static extern int api_connect(int s, ref sockaddr_in name, int namelen);
		[DllImport("ws2_32.dll", EntryPoint = "gethostname", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int api_gethostname(string host_name, int namelen);
		[DllImport("ws2_32.dll", EntryPoint = "gethostbyname", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int api_gethostbyname(string host_name);
		[DllImport("ws2_32.dll", EntryPoint = "bind", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//UPGRADE_WARNING: Structure sockaddr_in may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
		private static extern int api_bind(int s, ref sockaddr_in name, ref int namelen);
		[DllImport("ws2_32.dll", EntryPoint = "getsockname", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//UPGRADE_WARNING: Structure sockaddr_in may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
		private static extern int api_getsockname(int s, ref sockaddr_in name, ref int namelen);
		[DllImport("ws2_32.dll", EntryPoint = "getpeername", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//UPGRADE_WARNING: Structure sockaddr_in may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
		private static extern int api_getpeername(int s, ref sockaddr_in name, ref int namelen);
		[DllImport("ws2_32.dll", EntryPoint = "inet_addr", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int api_inet_addr(string cp);
		[DllImport("ws2_32.dll", EntryPoint = "send", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int api_send(int s, ref object buf, int buflen, int flags);
		[DllImport("ws2_32.dll", EntryPoint = "sendto", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//UPGRADE_WARNING: Structure sockaddr_in may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
		private static extern int api_sendto(int s, ref object buf, int buflen, int flags, ref sockaddr_in toaddr, int tolen);
		[DllImport("ws2_32.dll", EntryPoint = "getsockopt", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int api_getsockopt(int s, int level, int optname, ref object optval, ref int optlen);
		[DllImport("ws2_32.dll", EntryPoint = "setsockopt", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int api_setsockopt(int s, int level, int optname, ref object optval, int optlen);
		[DllImport("ws2_32.dll", EntryPoint = "recv", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int api_recv(int s, ref object buf, int buflen, int flags);
		[DllImport("ws2_32.dll", EntryPoint = "recvfrom", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//UPGRADE_WARNING: Structure sockaddr_in may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
		private static extern int api_recvfrom(int s, ref object buf, int buflen, int flags, ref sockaddr_in @from, ref int fromlen);
		[DllImport("ws2_32.dll", EntryPoint = "WSACancelAsyncRequest", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int api_WSACancelAsyncRequest(int hAsyncTaskHandle);
		[DllImport("ws2_32.dll", EntryPoint = "listen", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int api_listen(int s, int backlog);
		[DllImport("ws2_32.dll", EntryPoint = "accept", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//UPGRADE_WARNING: Structure sockaddr_in may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
		private static extern int api_accept(int s, ref sockaddr_in addr, ref int addrlen);
		[DllImport("ws2_32.dll", EntryPoint = "inet_ntoa", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int api_inet_ntoa(int inn);
		[DllImport("ws2_32.dll", EntryPoint = "gethostbyaddr", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int api_gethostbyaddr(ref int addr, int addr_len, int addr_type);
		[DllImport("ws2_32.dll", EntryPoint = "ioctlsocket", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int api_ioctlsocket(int s, int cmd, ref int argp);
		[DllImport("ws2_32.dll", EntryPoint = "closesocket", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int api_closesocket(int s);

		//==============================================================================
		//CONSTANTS
		//==============================================================================
		public enum SockState
		{
			sckClosed = 0,
			sckOpen,
			sckListening,
			sckConnectionPending,
			sckResolvingHost,
			sckHostResolved,
			sckConnecting,
			sckConnected,
			sckClosing,
			sckError
		}

		public enum DestResolucion
		{
			//asynchronic host resolution destination
			destConnect = 0
			//destSendUDP = 1
		}


		private const int SOMAXCONN = 5;
		public enum ProtocolConstants
		{
			sckTCPProtocol = 0,
			sckUDPProtocol = 1
		}


		private const int MSG_PEEK = 0x2;
		//==============================================================================
		//EVENTS
		//==============================================================================

		public event CloseSckEventHandler CloseSck;
		public delegate void CloseSckEventHandler();
		public event ConnectEventHandler Connect;
		public delegate void ConnectEventHandler();
		public event ConnectionRequestEventHandler ConnectionRequest;
		public delegate void ConnectionRequestEventHandler(int requestID);
		public event DataArrivalEventHandler DataArrival;
		public delegate void DataArrivalEventHandler(int bytesTotal);
		public event Error_RenamedEventHandler Error_Renamed;
		public delegate void Error_RenamedEventHandler(short Number, ref string Description, int sCode, string Source, string HelpFile, int HelpContext, ref bool CancelDisplay);
		public event SendCompleteEventHandler SendComplete;
		public delegate void SendCompleteEventHandler();
		public event SendProgressEventHandler SendProgress;
		public delegate void SendProgressEventHandler(int bytesSent, int bytesRemaining);

		//==============================================================================
		//MEMBER VARIABLES
		//==============================================================================
			//socket handle
		private int m_lngSocketHandle;
			//socket state
		private SockState m_enmState;
			//tag
		private string m_strTag;
			//remote host
		private string m_strRemoteHost;
			//remote port
		private int m_lngRemotePort;
			//remote host ip
		private string m_strRemoteHostIP;
			//local port
		private int m_lngLocalPort;
			//temporary local port
		private int m_lngLocalPortBind;
			//local IP
		private string m_strLocalIP;
			//protocol used (TCP / UDP)
		private ProtocolConstants m_enmProtocol;

			//memory pointer used as buffer when resolving host
		private int m_lngMemoryPointer;
			//buffer memory handle
		private int m_lngMemoryHandle;

			//winsock buffer size for sends
		private int m_lngSendBufferLen;
			//winsock buffer size for receives
		private int m_lngRecvBufferLen;

			//local incoming buffer
		private string m_strSendBuffer;
			//local outgoing buffer
		private string m_strRecvBuffer;

			//if True then this is a Accept socket class
		private bool m_blnAcceptClass;
			//hosts waiting to be resolved by the system
		private Collection m_colWaitingResolutions;

		//  ****  WARNING WARNING WARNING WARNING ******
		//This sub MUST be the first on the class. DO NOT attempt
		//to change it's location or the code will CRASH.
		//This sub receives system messages from our WndProc.
		public void WndProc(int hwnd, int uMsg, int wParam, int lParam)
		{
			switch (uMsg) {

				case modSocketMaster.RESOLVE_MESSAGE:

					PostResolution(wParam, modSocketMaster.HiWord(ref lParam));

					break;
				case modSocketMaster.SOCKET_MESSAGE:

					PostSocket(modSocketMaster.LoWord(ref lParam), modSocketMaster.HiWord(ref lParam));

					break;
			}
		}

		private void Class_Initialize_Renamed()
		{
			//socket's handle default value
			m_lngSocketHandle = modSocketMaster.INVALID_SOCKET;

			//initiate resolution collection
			m_colWaitingResolutions = new Collection();

			//initiate processes and winsock service
			modSocketMaster.InitiateProcesses();
		}
		public CSocketMaster() : base()
		{
			Class_Initialize_Renamed();
		}

		private void Class_Terminate_Renamed()
		{
			//clean hostname resolution system
			CleanResolutionSystem();

			//destroy socket if it exists
			if (!m_blnAcceptClass)
				DestroySocket();

			//clean processes and finish winsock service
			modSocketMaster.FinalizeProcesses();

			//clean resolution collection
			//UPGRADE_NOTE: Object m_colWaitingResolutions may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			m_colWaitingResolutions = null;
		}
		protected override void Finalize()
		{
			Class_Terminate_Renamed();
			base.Finalize();
		}

		//==============================================================================
		//PROPERTIES
		//==============================================================================


		public int RemotePort {
			get { return m_lngRemotePort; }
			set {
				if (m_enmProtocol == ProtocolConstants.sckTCPProtocol & m_enmState != SockState.sckClosed) {
					Err().Raise(modSocketMaster.sckInvalidOp, "CSocketMaster.RemotePort", "Invalid operation at current state");
				}

				if (value < 0 | value > 65535) {
					Err().Raise(modSocketMaster.sckInvalidArg, "CSocketMaster.RemotePort", "The argument passed to a function was not in the correct format or in the specified range.");
				} else {
					m_lngRemotePort = value;
				}
			}
		}


		public string RemoteHost {
			get { return m_strRemoteHost; }
			set {
				if (m_enmProtocol == ProtocolConstants.sckTCPProtocol & m_enmState != SockState.sckClosed) {
					Err().Raise(modSocketMaster.sckInvalidOp, "CSocketMaster.RemoteHost", "Invalid operation at current state");
				}

				m_strRemoteHost = value;
			}
		}

		public string RemoteHostIP {
			get { return m_strRemoteHostIP; }
		}


		public int LocalPort {
			get {
				int functionReturnValue = 0;
				if (m_lngLocalPortBind == 0) {
					functionReturnValue = m_lngLocalPort;
				} else {
					functionReturnValue = m_lngLocalPortBind;
				}
				return functionReturnValue;
			}
			set {
				if (m_enmState != SockState.sckClosed) {
					Err().Raise(modSocketMaster.sckInvalidOp, "CSocketMaster.LocalPort", "Invalid operation at current state");
				}
				if (value < 0 | value > 65535) {
					Err().Raise(modSocketMaster.sckInvalidArg, "CSocketMaster.LocalPort", "The argument passed to a function was not in the correct format or in the specified range.");
				} else {
					m_lngLocalPort = value;
				}
			}
		}

		public SockState State {
			get { return m_enmState; }
		}

		public string LocalHostName {
			get { return GetLocalHostName(); }
		}

		public string LocalIP {
			get {
				string functionReturnValue = null;
				if (m_enmState == SockState.sckOpen | m_enmState == SockState.sckListening) {
					functionReturnValue = m_strLocalIP;
				} else {
					functionReturnValue = GetLocalIP();
				}
				return functionReturnValue;
			}
		}

		public int BytesReceived {
			get {
				int functionReturnValue = 0;
				if (m_enmProtocol == ProtocolConstants.sckTCPProtocol) {
					functionReturnValue = Strings.Len(m_strRecvBuffer);
				} else {
					functionReturnValue = GetBufferLenUDP();
				}
				return functionReturnValue;
			}
		}

		public int SocketHandle {
			get { return m_lngSocketHandle; }
		}


		public string Tag {
			get { return m_strTag; }
			set { m_strTag = value; }
		}


		public ProtocolConstants Protocol {
			get { return m_enmProtocol; }
			set {
				if (m_enmState != SockState.sckClosed) {
					Err().Raise(modSocketMaster.sckInvalidOp, "CSocketMaster.Protocol", "Invalid operation at current state");
				} else {
					m_enmProtocol = value;
				}
			}
		}

		//Destroys the socket if it exists and unregisters it
		//from control list.
		private void DestroySocket()
		{
			int lngResult = 0;
			int lngErrorCode = 0;

			if (!(m_lngSocketHandle == modSocketMaster.INVALID_SOCKET)) {

				lngResult = api_closesocket(m_lngSocketHandle);


				if (lngResult == modSocketMaster.SOCKET_ERROR) {
					m_enmState = SockState.sckError;
					Debug.Print("STATE: sckError");
					lngErrorCode = Err().LastDllError;
					Err().Raise(lngErrorCode, "CSocketMaster.DestroySocket", modSocketMaster.GetErrorDescription(lngErrorCode));


				} else {
					Debug.Print("OK Destroyed socket " + m_lngSocketHandle);
					modSocketMaster.UnregisterSocket(m_lngSocketHandle);
					m_lngSocketHandle = modSocketMaster.INVALID_SOCKET;

				}

			}
		}

		public void CloseSck_Renamed()
		{
			if (m_lngSocketHandle == modSocketMaster.INVALID_SOCKET)
				return;

			m_enmState = SockState.sckClosing;
			Debug.Print("STATE: sckClosing");
			CleanResolutionSystem();
			DestroySocket();

			m_lngLocalPortBind = 0;
			m_strRemoteHostIP = "";
			m_strRecvBuffer = "";
			m_strSendBuffer = "";
			m_lngSendBufferLen = 0;
			m_lngRecvBufferLen = 0;

			m_enmState = SockState.sckClosed;
			Debug.Print("STATE: sckClosed");

		}

		//Tries to create a socket if there isn't one yet and registers
		//it to the control list.
		//Returns TRUE if it has success
		private bool SocketExists()
		{
			bool functionReturnValue = false;
			functionReturnValue = true;
			int lngResult = 0;
			int lngErrorCode = 0;

			//check if there is a socket already
			bool blnCancelDisplay = false;

			if (m_lngSocketHandle == modSocketMaster.INVALID_SOCKET) {
				//decide what kind of socket we are creating, TCP or UDP
				if (m_enmProtocol == ProtocolConstants.sckTCPProtocol) {
					lngResult = api_socket(modSocketMaster.AF_INET, modSocketMaster.SOCK_STREAM, modSocketMaster.IPPROTO_TCP);
				} else {
					lngResult = api_socket(modSocketMaster.AF_INET, modSocketMaster.SOCK_DGRAM, modSocketMaster.IPPROTO_UDP);
				}


				if (lngResult == modSocketMaster.INVALID_SOCKET) {
					m_enmState = SockState.sckError;
					Debug.Print("STATE: sckError");
					Debug.Print("ERROR trying to create socket");
					functionReturnValue = false;
					lngErrorCode = Err().LastDllError;
					blnCancelDisplay = true;
					if (Error_Renamed != null) {
						Error_Renamed(lngErrorCode, modSocketMaster.GetErrorDescription(lngErrorCode), 0, "CSocketMaster.SocketExists", "", 0, blnCancelDisplay);
					}
					if (blnCancelDisplay == false)
						Interaction.MsgBox(modSocketMaster.GetErrorDescription(lngErrorCode), MsgBoxStyle.OkOnly, "CSocketMaster.SocketExists");

				} else {
					Debug.Print("OK Created socket: " + lngResult);
					m_lngSocketHandle = lngResult;
					//set and get some socket options
					ProcessOptions();
					functionReturnValue = modSocketMaster.RegisterSocket(m_lngSocketHandle, VarPtr.VarPtr(this), true);

				}
			}
			return functionReturnValue;
		}

		//Tries to connect to RemoteHost if it was passed, or uses
		//m_strRemoteHost instead. If it is a hostname tries to
		//resolve it first.
		public void Connect_Renamed(ref string RemoteHost = null, ref int RemotePort = null)
		{
			if (m_enmState != SockState.sckClosed) {
				Err().Raise(modSocketMaster.sckInvalidOp, "CSocketMaster.Connect", "Invalid operation at current state");
			}

			if ((RemoteHost != null)) {
				m_strRemoteHost = Convert.ToString(RemoteHost);
			}

			//for some reason we get a GPF if we try to
			//resolve a null string, so we replace it with
			//an empty string
			if (m_strRemoteHost == Constants.vbNullString) {
				m_strRemoteHost = "";
			}

			//check if RemotePort is a number between 1 and 65535
			if ((RemotePort != null)) {
				if (Information.IsNumeric(RemotePort)) {
					if (Convert.ToInt32(RemotePort) > 65535 | Convert.ToInt32(RemotePort) < 1) {
						Err().Raise(modSocketMaster.sckInvalidArg, "CSocketMaster.Connect", "The argument passed to a function was not in the correct format or in the specified range.");
					} else {
						m_lngRemotePort = Convert.ToInt32(RemotePort);
					}
				} else {
					Err().Raise(modSocketMaster.sckUnsupported, "CSocketMaster.Connect", "Unsupported variant type.");
				}
			}

			//create a socket if there isn't one yet
			if (!SocketExists())
				return;

			//If we are using UDP we just bind the socket and exit
			//silently. Remember UDP is a connectionless protocol.
			if (m_enmProtocol == ProtocolConstants.sckUDPProtocol) {
				if (BindInternal()) {
					m_enmState = SockState.sckOpen;
					Debug.Print("STATE: sckOpen");
				}
				return;
			}

			//try to get a 32 bits long that is used to identify a host
			int lngAddress = 0;
			lngAddress = ResolveIfHostname(m_strRemoteHost, DestResolucion.destConnect);

			//We've got two options here:
			//1) m_strRemoteHost was an IP, so a resolution wasn't
			//   necessary, and now lngAddress is a 32 bits long and
			//   we proceed to connect.
			//2) m_strRemoteHost was a hostname, so a resolution was
			//   necessary and it's taking place right now. We leave
			//   silently.

			if (lngAddress != VariantType.Null) {
				ConnectToIP(lngAddress, 0);
			}

		}

		//When the system resolves a hostname in asynchronous way we
		//call this function to decide what to do with the result.
		private void PostResolution(int lngAsynHandle, int lngErrorCode)
		{
			if (m_enmState != SockState.sckResolvingHost)
				return;

			DestResolucion enmDestination = default(DestResolucion);

			//find out what the resolution destination was
			//UPGRADE_WARNING: Couldn't resolve default property of object m_colWaitingResolutions.Item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			enmDestination = m_colWaitingResolutions["R" + lngAsynHandle];
			//erase that record from the collection since we won't need it any longer
			m_colWaitingResolutions.Remove("R" + lngAsynHandle);

			HOSTENT udtHostent = default(HOSTENT);
			int lngPtrToIP = 0;
			int lngRemoteHostAddress = 0;
			short Count = 0;
			string strIpAddress = null;
			//UPGRADE_WARNING: Lower bound of array arrIpAddress was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
			byte[] arrIpAddress = new byte[5];
			//if there weren't errors trying to resolve the hostname
			if (lngErrorCode == 0) {

				m_enmState = SockState.sckHostResolved;
				Debug.Print("STATE: sckHostResolved");


				//UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object udtHostent. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modSocketMaster.api_CopyMemory(ref udtHostent, ref m_lngMemoryPointer, modLenB.LenB(udtHostent));
				modSocketMaster.api_CopyMemory(ref lngPtrToIP, ref udtHostent.hAddrList, 4);
				modSocketMaster.api_CopyMemory(ref arrIpAddress[1], ref lngPtrToIP, 4);
				modSocketMaster.api_CopyMemory(ref lngRemoteHostAddress, ref lngPtrToIP, 4);

				//free memmory, won't need it any longer
				FreeMemory();

				//We turn the 32 bits long into a readable string.
				//Note: we don't need this string. I put this here just
				//in case you need it.
				for (Count = 1; Count <= 4; Count++) {
					strIpAddress = strIpAddress + arrIpAddress[Count] + ".";
				}

				strIpAddress = Strings.Left(strIpAddress, Strings.Len(strIpAddress) - 1);

				//Decide what to do with the result according to the destination
				switch (enmDestination) {

					case DestResolucion.destConnect:
						ConnectToIP(lngRemoteHostAddress, 0);

						break;
				}

			//there were errors trying to resolve the hostname
			} else {

				//free buffer memory
				FreeMemory();

				switch (enmDestination) {

					case DestResolucion.destConnect:
						ConnectToIP(VariantType.Null, lngErrorCode);

						break;
				}

			}
		}

		//This procedure is called by the WindowProc callback function
		//from the modSocketMaster module. The lngEventID argument is an
		//ID of the network event occurred for the socket. The lngErrorCode
		//argument contains an error code only if an error was occurred
		//during an asynchronous execution.

		private void PostSocket(int lngEventID, int lngErrorCode)
		{
			//handle any possible error
			bool blnCancelDisplay = false;
			if (lngErrorCode != 0) {
				m_enmState = SockState.sckError;
				Debug.Print("STATE: sckError");
				blnCancelDisplay = true;
				if (Error_Renamed != null) {
					Error_Renamed(lngErrorCode, modSocketMaster.GetErrorDescription(lngErrorCode), 0, "CSocketMaster.PostSocket", "", 0, blnCancelDisplay);
				}
				if (blnCancelDisplay == false)
					Interaction.MsgBox(modSocketMaster.GetErrorDescription(lngErrorCode), MsgBoxStyle.OkOnly, "CSocketMaster.PostSocket");
				return;
			}

			//UPGRADE_WARNING: Arrays in structure udtSockAddr may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
			sockaddr_in udtSockAddr = default(sockaddr_in);
			int lngResult = 0;
			int lngBytesReceived = 0;

			int lngTempRP = 0;
			string strTempRHIP = null;
			string strTempRH = null;
			switch (lngEventID) {

				//======================================================================

				case modSocketMaster.FD_CONNECT:

					//Arrival of this message means that the connection initiated by the call
					//of the connect Winsock API function was successfully established.

					Debug.Print("FD_CONNECT " + m_lngSocketHandle);

					if (m_enmState != SockState.sckConnecting) {
						Debug.Print("WARNING: Omitting FD_CONNECT");
						return;
					}

					//Get the connection local end-point parameters
					//UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
					lngResult = api_getpeername(m_lngSocketHandle, ref udtSockAddr, ref modLenB.LenB(udtSockAddr));

					if (lngResult == 0) {
						m_lngRemotePort = modSocketMaster.IntegerToUnsigned(ref api_ntohs(udtSockAddr.sin_port));
						m_strRemoteHostIP = modSocketMaster.StringFromPointer(api_inet_ntoa(udtSockAddr.sin_addr));
					}

					m_enmState = SockState.sckConnected;
					Debug.Print("STATE: sckConnected");
					if (Connect != null) {
						Connect();
					}


					break;
				//======================================================================

				case modSocketMaster.FD_WRITE:

					//This message means that the socket in a write-able
					//state, that is, buffer for outgoing data of the transport
					//service is empty and ready to receive data to send through
					//the network.

					Debug.Print("FD_WRITE " + m_lngSocketHandle);

					if (m_enmState != SockState.sckConnected) {
						Debug.Print("WARNING: Omitting FD_WRITE");
						return;
					}

					if (Strings.Len(m_strSendBuffer) > 0) {
						SendBufferedData();
					}

					break;
				//======================================================================

				case modSocketMaster.FD_READ:

					//Some data has arrived for this socket.

					Debug.Print("FD_READ " + m_lngSocketHandle);


					if (m_enmProtocol == ProtocolConstants.sckTCPProtocol) {
						if (m_enmState != SockState.sckConnected) {
							Debug.Print("WARNING: Omitting FD_READ");
							return;
						}

						//Call the RecvDataToBuffer function that move arrived data
						//from the Winsock buffer to the local one and returns number
						//of bytes received.

						lngBytesReceived = RecvDataToBuffer();

						if (lngBytesReceived > 0) {
							if (DataArrival != null) {
								DataArrival(Strings.Len(m_strRecvBuffer));
							}
						}

					//UDP protocol
					} else {

						if (m_enmState != SockState.sckOpen) {
							Debug.Print("WARNING: Omitting FD_READ");
							return;
						}

						//If we use UDP we don't remove data from winsock buffer.
						//We just let the user know the amount received so
						//he/she can decide what to do.

						lngBytesReceived = GetBufferLenUDP();

						if (lngBytesReceived > 0) {
							if (DataArrival != null) {
								DataArrival(lngBytesReceived);
							}
						}


						//Now the buffer is emptied no matter what the user
						//dicided to do with the received data
						EmptyBuffer();
					}

					break;

				//======================================================================

				case modSocketMaster.FD_ACCEPT:

					//When the socket is in a listening state, arrival of this message
					//means that a connection request was received. Call the accept
					//Winsock API function in oreder to create a new socket for the
					//requested connection.

					Debug.Print("FD_ACCEPT " + m_lngSocketHandle);
					if (m_enmState != SockState.sckListening) {
						Debug.Print("WARNING: Omitting FD_ACCEPT");
						return;
					}

					//UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
					lngResult = api_accept(m_lngSocketHandle, ref udtSockAddr, ref modLenB.LenB(udtSockAddr));

					if (lngResult == modSocketMaster.INVALID_SOCKET) {
						lngErrorCode = Err().LastDllError;
						Err().Raise(lngErrorCode, "CSocketMaster.PostSocket", modSocketMaster.GetErrorDescription(lngErrorCode));
					} else {
						//We assign a temporal instance of CSocketMaster to
						//handle this new socket until user accepts (or not)
						//the new connection
						modSocketMaster.RegisterAccept(lngResult);

						//We change remote info before firing ConnectionRequest
						//event so the user can see which host is trying to
						//connect.

						lngTempRP = m_lngRemotePort;
						strTempRHIP = m_strRemoteHostIP;
						strTempRH = m_strRemoteHost;

						GetRemoteInfo(lngResult, ref m_lngRemotePort, ref m_strRemoteHostIP, ref m_strRemoteHost);

						Debug.Print("OK Accepted socket: " + lngResult);
						if (ConnectionRequest != null) {
							ConnectionRequest(lngResult);
						}

						//we return original info
						if (m_enmState == SockState.sckListening) {
							m_lngRemotePort = lngTempRP;
							m_strRemoteHostIP = strTempRHIP;
							m_strRemoteHost = strTempRH;
						}

						//This is very important. If the connection wasn't accepted
						//we must close the socket.
						if (modSocketMaster.IsAcceptRegistered(lngResult)) {
							api_closesocket(lngResult);
							modSocketMaster.UnregisterSocket(lngResult);
							modSocketMaster.UnregisterAccept(lngResult);
							Debug.Print("OK Closed accepted socket: " + lngResult);
						}
					}

					break;
				//======================================================================

				case modSocketMaster.FD_CLOSE:

					//This message means that the remote host is closing the conection

					Debug.Print("FD_CLOSE " + m_lngSocketHandle);

					if (m_enmState != SockState.sckConnected) {
						Debug.Print("WARNING: Omitting FD_CLOSE");
						return;
					}

					m_enmState = SockState.sckClosing;
					Debug.Print("STATE: sckClosing");
					if (CloseSck != null) {
						CloseSck();
					}


					break;
			}
		}

		//Connect to a given 32 bits long ip

		private void ConnectToIP(int lngRemoteHostAddress, int lngErrorCode)
		{
			bool blnCancelDisplay = false;

			//Check and handle errors
			if (lngErrorCode != 0) {
				m_enmState = SockState.sckError;
				Debug.Print("STATE: sckError");
				blnCancelDisplay = true;
				if (Error_Renamed != null) {
					Error_Renamed(lngErrorCode, modSocketMaster.GetErrorDescription(lngErrorCode), 0, "CSocketMaster.ConnectToIP", "", 0, blnCancelDisplay);
				}
				if (blnCancelDisplay == false)
					Interaction.MsgBox(modSocketMaster.GetErrorDescription(lngErrorCode), MsgBoxStyle.OkOnly, "CSocketMaster.ConnectToIP");
				return;
			}

			//Here we bind the socket
			if (!BindInternal())
				return;

			Debug.Print("OK Connecting to: " + m_strRemoteHost + " " + m_strRemoteHostIP);
			m_enmState = SockState.sckConnecting;
			Debug.Print("STATE: sckConnecting");

			//UPGRADE_WARNING: Arrays in structure udtSockAddr may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
			sockaddr_in udtSockAddr = default(sockaddr_in);
			int lngResult = 0;

			//Build the sockaddr_in structure to pass it to the connect
			//Winsock API function as an address of the remote host.
			var _with1 = udtSockAddr;
			_with1.sin_addr = lngRemoteHostAddress;
			_with1.sin_family = modSocketMaster.AF_INET;
			_with1.sin_port = api_htons(modSocketMaster.UnsignedToInteger(ref ref m_lngRemotePort));

			//Call the connect Winsock API function in order to establish connection.
			//UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
			lngResult = api_connect(m_lngSocketHandle, ref udtSockAddr, modLenB.LenB(udtSockAddr));

			//Check and handle errors
			if (lngResult == modSocketMaster.SOCKET_ERROR) {
				lngErrorCode = Err().LastDllError;
				if (lngErrorCode != modSocketMaster.WSAEWOULDBLOCK) {
					if (lngErrorCode == modSocketMaster.WSAEADDRNOTAVAIL) {
						Err().Raise(modSocketMaster.WSAEADDRNOTAVAIL, "CSocketMaster.ConnectToIP", modSocketMaster.GetErrorDescription(modSocketMaster.WSAEADDRNOTAVAIL));
					} else {
						m_enmState = SockState.sckError;
						Debug.Print("STATE: sckError");
						blnCancelDisplay = true;
						if (Error_Renamed != null) {
							Error_Renamed(lngErrorCode, modSocketMaster.GetErrorDescription(lngErrorCode), 0, "CSocketMaster.ConnectToIP", "", 0, blnCancelDisplay);
						}
						if (blnCancelDisplay == false)
							Interaction.MsgBox(modSocketMaster.GetErrorDescription(lngErrorCode), MsgBoxStyle.OkOnly, "CSocketMaster.ConnectToIP");
					}
				}
			}

		}

		public void Bind(ref int LocalPort = null, ref string LocalIP = null)
		{
			if (m_enmState != SockState.sckClosed) {
				Err().Raise(modSocketMaster.sckInvalidOp, "CSocketMaster.Bind", "Invalid operation at current state");
			}

			if (BindInternal(LocalPort, LocalIP)) {
				m_enmState = SockState.sckOpen;
				Debug.Print("STATE: sckOpen");
			}
		}

		//This function binds a socket to a local port and IP.
		//Retunrs TRUE if it has success.
		private bool BindInternal(int varLocalPort = null, string varLocalIP = null)
		{
			bool functionReturnValue = false;
			if (m_enmState == SockState.sckOpen) {
				functionReturnValue = true;
				return functionReturnValue;
			}

			int lngLocalPortInternal = 0;
			string strLocalHostInternal = null;
			string strIP = null;
			int lngAddressInternal = 0;
			int lngResult = 0;
			int lngErrorCode = 0;

			functionReturnValue = false;

			//Check if varLocalPort is a number between 0 and 65535

			if ((varLocalPort != null)) {
				if (Information.IsNumeric(varLocalPort)) {
					if (varLocalPort < 0 | varLocalPort > 65535) {
						functionReturnValue = false;
						Err().Raise(modSocketMaster.sckInvalidArg, "CSocketMaster.BindInternal", "The argument passed to a function was not in the correct format or in the specified range.");
					} else {
						lngLocalPortInternal = Convert.ToInt32(varLocalPort);
					}
				} else {
					functionReturnValue = false;
					Err().Raise(modSocketMaster.sckUnsupported, "CSocketMaster.BindInternal", "Unsupported variant type.");
				}


			} else {
				lngLocalPortInternal = m_lngLocalPort;

			}

			if ((varLocalIP != null)) {
				if (varLocalIP != Constants.vbNullString) {
					strLocalHostInternal = Convert.ToString(varLocalIP);
				} else {
					strLocalHostInternal = GetLocalIP();
				}
			} else {
				strLocalHostInternal = GetLocalIP();
			}

			//get a 32 bits long IP
			lngAddressInternal = ResolveIfHostnameSync(strLocalHostInternal, ref strIP, ref lngResult);

			if (lngResult != 0) {
				Err().Raise(modSocketMaster.sckInvalidArg, "CSocketMaster.BindInternal", "Invalid argument");
			}

			//create a socket if there isn't one yet
			if (!SocketExists())
				return functionReturnValue;

			//UPGRADE_WARNING: Arrays in structure udtSockAddr may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
			sockaddr_in udtSockAddr = default(sockaddr_in);

			var _with2 = udtSockAddr;
			_with2.sin_addr = lngAddressInternal;
			_with2.sin_family = modSocketMaster.AF_INET;
			_with2.sin_port = api_htons(modSocketMaster.UnsignedToInteger(ref ref lngLocalPortInternal));

			//bind the socket
			lngResult = api_bind(m_lngSocketHandle, ref udtSockAddr, ref modLenB.LenB(udtSockAddr));


			if (lngResult == modSocketMaster.SOCKET_ERROR) {
				lngErrorCode = Err().LastDllError;
				Err().Raise(lngErrorCode, "CSocketMaster.BindInternal", modSocketMaster.GetErrorDescription(lngErrorCode));


			} else {
				m_strLocalIP = strIP;


				if (lngLocalPortInternal != 0) {
					Debug.Print("OK Bind HOST: " + strLocalHostInternal + " PORT: " + lngLocalPortInternal);
					m_lngLocalPort = lngLocalPortInternal;

				} else {
					lngResult = GetLocalPort(m_lngSocketHandle);

					if (lngResult == modSocketMaster.SOCKET_ERROR) {
						lngErrorCode = Err().LastDllError;
						Err().Raise(lngErrorCode, "CSocketMaster.BindInternal", modSocketMaster.GetErrorDescription(lngErrorCode));
					} else {
						Debug.Print("OK Bind HOST: " + strLocalHostInternal + " PORT: " + lngResult);
						m_lngLocalPortBind = lngResult;
					}

				}

				functionReturnValue = true;
			}
			return functionReturnValue;
		}

		//Allocate some memory for HOSTEN structure and returns
		//a pointer to this buffer if no error occurs.
		//Returns 0 if it fails.
		private int AllocateMemory()
		{
			int functionReturnValue = 0;
			m_lngMemoryHandle = modSocketMaster.api_GlobalAlloc(modSocketMaster.GMEM_FIXED, modSocketMaster.MAXGETHOSTSTRUCT);

			if (m_lngMemoryHandle != 0) {
				m_lngMemoryPointer = api_GlobalLock(m_lngMemoryHandle);

				if (m_lngMemoryPointer != 0) {
					api_GlobalUnlock(m_lngMemoryHandle);
					functionReturnValue = m_lngMemoryPointer;
				} else {
					modSocketMaster.api_GlobalFree(m_lngMemoryHandle);
					functionReturnValue = m_lngMemoryPointer;
					//0
				}

			} else {
				functionReturnValue = m_lngMemoryHandle;
				//0
			}
			return functionReturnValue;
		}

		//Free memory allocated by AllocateMemory
		private void FreeMemory()
		{
			if (m_lngMemoryHandle != 0) {
				m_lngMemoryHandle = 0;
				m_lngMemoryPointer = 0;
				modSocketMaster.api_GlobalFree(m_lngMemoryHandle);
			}
		}

		private string GetLocalHostName()
		{
			string functionReturnValue = null;
			string strHostNameBuf = null;
			int lngResult = 0;

			lngResult = api_gethostname(strHostNameBuf, modSocketMaster.LOCAL_HOST_BUFF);

			int lngErrorCode = 0;
			if (lngResult == modSocketMaster.SOCKET_ERROR) {
				functionReturnValue = Constants.vbNullString;
				lngErrorCode = Err().LastDllError;
				Err().Raise(lngErrorCode, "CSocketMaster.GetLocalHostName", modSocketMaster.GetErrorDescription(lngErrorCode));
			} else {
				functionReturnValue = Strings.Left(strHostNameBuf, Strings.InStr(1, strHostNameBuf, Strings.Chr(0)) - 1);
			}
			return functionReturnValue;
		}

		private string GetLocalIP()
		{
			string functionReturnValue = null;
			int lngResult = 0;
			int lngPtrToIP = 0;
			string strLocalHost = null;
			byte[] arrIpAddress = new byte[5];
			short Count = 0;
			HOSTENT udtHostent = default(HOSTENT);
			string strIpAddress = null;

			strLocalHost = GetLocalHostName();

			lngResult = api_gethostbyname(strLocalHost);

			int lngErrorCode = 0;
			if (lngResult == 0) {
				functionReturnValue = Constants.vbNullString;
				lngErrorCode = Err().LastDllError;
				Err().Raise(lngErrorCode, "CSocketMaster.GetLocalIP", modSocketMaster.GetErrorDescription(lngErrorCode));
			} else {
				modSocketMaster.api_CopyMemory(ref udtHostent, ref lngResult, modLenB.LenB(udtHostent));
				modSocketMaster.api_CopyMemory(ref lngPtrToIP, ref udtHostent.hAddrList, 4);
				modSocketMaster.api_CopyMemory(ref arrIpAddress[1], ref lngPtrToIP, 4);

				for (Count = 1; Count <= 4; Count++) {
					strIpAddress = strIpAddress + arrIpAddress[Count] + ".";
				}

				strIpAddress = Strings.Left(strIpAddress, Strings.Len(strIpAddress) - 1);
				functionReturnValue = strIpAddress;
			}
			return functionReturnValue;
		}

		//If Host is an IP doesn't resolve anything and returns a
		//a 32 bits long IP.
		//If Host isn't an IP then returns vbNull, tries to resolve it
		//in asynchronous way and acts according to enmDestination.
		private int ResolveIfHostname(string Host, DestResolucion enmDestination)
		{
			int functionReturnValue = 0;
			int lngAddress = 0;
			lngAddress = api_inet_addr(Host);

			int lngAsynHandle = 0;
			int lngErrorCode = 0;
			bool blnCancelDisplay = false;
			//if Host isn't an IP
			if (lngAddress == modSocketMaster.INADDR_NONE) {

				functionReturnValue = VariantType.Null;
				m_enmState = SockState.sckResolvingHost;
				Debug.Print("STATE: sckResolvingHost");


				if (AllocateMemory()) {
					//UPGRADE_ISSUE: ObjPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
					lngAsynHandle = modSocketMaster.ResolveHost(Host, m_lngMemoryPointer, VarPtr.VarPtr(this));

					if (lngAsynHandle == 0) {
						FreeMemory();
						m_enmState = SockState.sckError;
						Debug.Print("STATE: sckError");
						lngErrorCode = Err().LastDllError;
						blnCancelDisplay = true;
						if (Error_Renamed != null) {
							Error_Renamed(lngErrorCode, modSocketMaster.GetErrorDescription(lngErrorCode), 0, "CSocketMaster.ResolveIfHostname", "", 0, blnCancelDisplay);
						}
						if (blnCancelDisplay == false)
							Interaction.MsgBox(modSocketMaster.GetErrorDescription(lngErrorCode), MsgBoxStyle.OkOnly, "CSocketMaster.ResolveIfHostname");
					} else {
						m_colWaitingResolutions.Add(enmDestination, "R" + lngAsynHandle);
						Debug.Print("Resolving host " + Host + " with handle " + lngAsynHandle);
					}


				} else {
					m_enmState = SockState.sckError;
					Debug.Print("STATE: sckError");
					Debug.Print("Error trying to allocate memory");
					Err().Raise(modSocketMaster.sckOutOfMemory, "CSocketMaster.ResolveIfHostname", "Out of memory");

				}

			//if Host is an IP doen't need to resolve anything
			} else {
				functionReturnValue = lngAddress;
			}
			return functionReturnValue;
		}

		//Resolves a hots (if necessary) in synchronous way
		//If succeeds returns a 32 bits long IP,
		//strHostIP = readable IP string and lngErrorCode = 0
		//If fails returns vbNull,
		//strHostIP = vbNullString and lngErrorCode <> 0
		private int ResolveIfHostnameSync(string Host, ref string strHostIP, ref int lngErrorCode)
		{
			int functionReturnValue = 0;
			int lngPtrToHOSTENT = 0;
			HOSTENT udtHostent = default(HOSTENT);
			int lngAddress = 0;
			int lngPtrToIP = 0;
			byte[] arrIpAddress = new byte[5];
			short Count = 0;

			if (Host == Constants.vbNullString) {
				strHostIP = Constants.vbNullString;
				lngErrorCode = modSocketMaster.WSAEAFNOSUPPORT;
				functionReturnValue = VariantType.Null;
				return functionReturnValue;
			}

			lngAddress = api_inet_addr(Host);

			//if Host isn't an IP
			if (lngAddress == modSocketMaster.INADDR_NONE) {

				lngPtrToHOSTENT = api_gethostbyname(Host);

				if (lngPtrToHOSTENT == 0) {
					lngErrorCode = Err().LastDllError;
					strHostIP = Constants.vbNullString;
					functionReturnValue = VariantType.Null;
				} else {
					modSocketMaster.api_CopyMemory(ref udtHostent, ref lngPtrToHOSTENT, modLenB.LenB(udtHostent));
					modSocketMaster.api_CopyMemory(ref lngPtrToIP, ref udtHostent.hAddrList, 4);
					modSocketMaster.api_CopyMemory(ref arrIpAddress[1], ref lngPtrToIP, 4);
					modSocketMaster.api_CopyMemory(ref lngAddress, ref lngPtrToIP, 4);

					for (Count = 1; Count <= 4; Count++) {
						strHostIP = strHostIP + arrIpAddress[Count] + ".";
					}

					strHostIP = Strings.Left(strHostIP, Strings.Len(strHostIP) - 1);

					lngErrorCode = 0;
					functionReturnValue = lngAddress;
				}

			//if Host is an IP doen't need to resolve anything
			} else {

				lngErrorCode = 0;
				strHostIP = Host;
				functionReturnValue = lngAddress;

			}
			return functionReturnValue;
		}

		//Returns local port from a connected or bound socket.
		//Returns SOCKET_ERROR if fails.
		private int GetLocalPort(int lngSocket)
		{
			int functionReturnValue = 0;
			sockaddr_in udtSockAddr = default(sockaddr_in);
			int lngResult = 0;

			lngResult = api_getsockname(lngSocket, ref udtSockAddr, ref modLenB.LenB(udtSockAddr));

			if (lngResult == modSocketMaster.SOCKET_ERROR) {
				functionReturnValue = modSocketMaster.SOCKET_ERROR;
			} else {
				functionReturnValue = modSocketMaster.IntegerToUnsigned(ref api_ntohs(udtSockAddr.sin_port));
			}
			return functionReturnValue;
		}


		public void SendData(ref object data)
		{
			byte[] arrData = null;
			//We store the data here before send it

			if (m_enmProtocol == ProtocolConstants.sckTCPProtocol) {
				if (m_enmState != SockState.sckConnected) {
					Err().Raise(modSocketMaster.sckBadState, "CSocketMaster.SendData", "Wrong protocol or connection state for the requested transaction or request");
					return;
				}
			//If we use UDP we create a socket if there isn't one yet
			} else {
				if (!SocketExists())
					return;
				if (!BindInternal())
					return;
				m_enmState = SockState.sckOpen;
				Debug.Print("STATE: sckOpen");
			}

			//We need to convert data variant into a byte array
			string strdata = null;
			string strArray = null;
			bool blnData = false;
			byte bytData = 0;
			decimal curData = default(decimal);
			System.DateTime datData = default(System.DateTime);
			double dblData = 0;
			short intData = 0;
			int lngData = 0;
			float sngData = 0;
			switch (Information.VarType(data)) {
				case VariantType.String:
					strdata = Convert.ToString(data);
					if (Strings.Len(strdata) == 0)
						return;

					arrData = new byte[Strings.Len(strdata)];
					arrData = System.Text.UnicodeEncoding.Unicode.GetBytes(strdata);
					break;
				case VariantType.Array + VariantType.Byte:
					strArray = System.Text.Encoding.Unicode.GetString(data);
					if (Strings.Len(strArray) == 0)
						return;

					arrData = System.Text.Encoding.Unicode.GetBytes(strArray);
					break;
				case VariantType.Boolean:
					blnData = Convert.ToBoolean(data);
					arrData = new byte[modLenB.LenB(blnData)];
					modSocketMaster.api_CopyMemory(ref arrData[0], ref blnData, modLenB.LenB(blnData));
					break;
				case VariantType.Byte:
					bytData = Convert.ToByte(data);
					arrData = new byte[modLenB.LenB(bytData)];
					modSocketMaster.api_CopyMemory(ref arrData[0], ref bytData, modLenB.LenB(bytData));
					break;
				case VariantType.Decimal:
					curData = Convert.ToDecimal(data);
					arrData = new byte[modLenB.LenB(curData)];
					modSocketMaster.api_CopyMemory(ref arrData[0], ref curData, modLenB.LenB(curData));
					break;
				case VariantType.Date:
					datData = Convert.ToDateTime(data);
					arrData = new byte[modLenB.LenB(datData)];
					modSocketMaster.api_CopyMemory(ref arrData[0], ref datData, modLenB.LenB(datData));
					break;
				case VariantType.Double:
					dblData = Convert.ToDouble(data);
					arrData = new byte[modLenB.LenB(dblData)];
					modSocketMaster.api_CopyMemory(ref arrData[0], ref dblData, modLenB.LenB(dblData));
					break;
				case VariantType.Short:
					intData = Convert.ToInt16(data);
					arrData = new byte[modLenB.LenB(intData)];
					modSocketMaster.api_CopyMemory(ref arrData[0], ref intData, modLenB.LenB(intData));
					break;
				case VariantType.Integer:
					lngData = Convert.ToInt32(data);
					arrData = new byte[modLenB.LenB(lngData)];
					modSocketMaster.api_CopyMemory(ref arrData[0], ref lngData, modLenB.LenB(lngData));
					break;
				case VariantType.Single:
					sngData = Convert.ToSingle(data);
					arrData = new byte[modLenB.LenB(sngData)];
					modSocketMaster.api_CopyMemory(ref arrData[0], ref sngData, modLenB.LenB(sngData));
					break;
				default:
					Err().Raise(modSocketMaster.sckUnsupported, "CSocketMaster.SendData", "Unsupported variant type.");
					break;
			}

			//if there's already something in the buffer that means we are
			//already sending data, so we put the new data in the buffer
			//and exit silently
			if (Strings.Len(m_strSendBuffer) > 0) {
				m_strSendBuffer = m_strSendBuffer + System.Text.Encoding.Unicode.GetString(arrData);

				return;
			} else {
				m_strSendBuffer = m_strSendBuffer + System.Text.Encoding.Unicode.GetString(arrData);
			}

			//send the data
			SendBufferedData();

		}

		//Check which protocol we are using to decide which
		//function should handle the data sending.
		private void SendBufferedData()
		{
			if (m_enmProtocol == ProtocolConstants.sckTCPProtocol) {
				SendBufferedDataTCP();
			} else {
				SendBufferedDataUDP();
			}
		}

		//Send buffered data if we are using UDP protocol.
		private void SendBufferedDataUDP()
		{
			int lngAddress = 0;
			sockaddr_in udtSockAddr = default(sockaddr_in);
			byte[] arrData = null;
			int lngBufferLength = 0;
			int lngResult = 0;
			int lngErrorCode = 0;

			string strTemp = null;
			lngAddress = ResolveIfHostnameSync(m_strRemoteHost, ref strTemp, ref lngErrorCode);

			if (lngErrorCode != 0) {
				m_strSendBuffer = "";

				if (lngErrorCode == modSocketMaster.WSAEAFNOSUPPORT) {
					Err().Raise(lngErrorCode, "CSocketMaster.SendBufferedDataUDP", modSocketMaster.GetErrorDescription(lngErrorCode));
				} else {
					Err().Raise(modSocketMaster.sckInvalidArg, "CSocketMaster.SendBufferedDataUDP", "Invalid argument");
				}
			}

			var _with3 = udtSockAddr;
			_with3.sin_addr = lngAddress;
			_with3.sin_family = modSocketMaster.AF_INET;
			_with3.sin_port = api_htons(modSocketMaster.UnsignedToInteger(ref ref m_lngRemotePort));

			lngBufferLength = Strings.Len(m_strSendBuffer);

			arrData = System.Text.UnicodeEncoding.Unicode.GetBytes(m_strSendBuffer);

			m_strSendBuffer = "";

			lngResult = api_sendto(m_lngSocketHandle, ref arrData[0], lngBufferLength, 0, ref udtSockAddr, modLenB.LenB(udtSockAddr));

			bool blnCancelDisplay = false;
			if (lngResult == modSocketMaster.SOCKET_ERROR) {
				lngErrorCode = Err().LastDllError;
				m_enmState = SockState.sckError;
				Debug.Print("STATE: sckError");
				blnCancelDisplay = true;
				if (Error_Renamed != null) {
					Error_Renamed(lngErrorCode, modSocketMaster.GetErrorDescription(lngErrorCode), 0, "CSocketMaster.SendBufferedDataUDP", "", 0, blnCancelDisplay);
				}
				if (blnCancelDisplay == false)
					Interaction.MsgBox(modSocketMaster.GetErrorDescription(lngErrorCode), MsgBoxStyle.OkOnly, "CSocketMaster.SendBufferedDataUDP");
			}

		}

		//Send buffered data if we are using TCP protocol.

		private void SendBufferedDataTCP()
		{
			byte[] arrData = null;
			int lngBufferLength = 0;
			int lngResult = 0;
			int lngTotalSent = 0;

			int lngErrorCode = 0;
			bool blnCancelDisplay = false;
			int lngTemp = 0;

			while (!(lngResult == modSocketMaster.SOCKET_ERROR | Strings.Len(m_strSendBuffer) == 0)) {
				lngBufferLength = Strings.Len(m_strSendBuffer);

				if (lngBufferLength > m_lngSendBufferLen) {
					lngBufferLength = m_lngSendBufferLen;
					arrData = System.Text.Encoding.Unicode.GetBytes(Strings.Left(m_strSendBuffer, m_lngSendBufferLen));
				} else {
					arrData = System.Text.Encoding.Unicode.GetBytes(m_strSendBuffer);
				}

				lngResult = api_send(m_lngSocketHandle, ref arrData[0], lngBufferLength, 0);

				if (lngResult == modSocketMaster.SOCKET_ERROR) {
					lngErrorCode = Err().LastDllError;

					if (lngErrorCode == modSocketMaster.WSAEWOULDBLOCK) {
						Debug.Print("WARNING: Send buffer full, waiting...");
						if (lngTotalSent > 0)
							if (SendProgress != null) {
								SendProgress(lngTotalSent, Strings.Len(m_strSendBuffer));
							}
					} else {
						m_enmState = SockState.sckError;
						Debug.Print("STATE: sckError");
						blnCancelDisplay = true;
						if (Error_Renamed != null) {
							Error_Renamed(lngErrorCode, modSocketMaster.GetErrorDescription(lngErrorCode), 0, "CSocketMaster.SendBufferedData", "", 0, blnCancelDisplay);
						}
						if (blnCancelDisplay == false)
							Interaction.MsgBox(modSocketMaster.GetErrorDescription(lngErrorCode), MsgBoxStyle.OkOnly, "CSocketMaster.SendBufferedData");
					}

				} else {
					Debug.Print("OK Bytes sent: " + lngResult);
					lngTotalSent = lngTotalSent + lngResult;
					if (Strings.Len(m_strSendBuffer) > lngResult) {
						m_strSendBuffer = Strings.Mid(m_strSendBuffer, lngResult + 1);
					} else {
						Debug.Print("OK Finished SENDING");
						m_strSendBuffer = "";
						lngTemp = lngTotalSent;
						lngTotalSent = 0;
						if (SendProgress != null) {
							SendProgress(lngTemp, 0);
						}
						if (SendComplete != null) {
							SendComplete();
						}
					}
				}

			}

		}

		//This function retrieves data from the Winsock buffer
		//into the class local buffer. The function returns number
		//of bytes retrieved (received).
		private int RecvDataToBuffer()
		{
			int functionReturnValue = 0;
			byte[] arrBuffer = null;
			int lngBytesReceived = 0;
			string strBuffTemporal = null;

			arrBuffer = new byte[m_lngRecvBufferLen];

			lngBytesReceived = api_recv(m_lngSocketHandle, ref arrBuffer[0], m_lngRecvBufferLen, 0);

			int lngErrorCode = 0;

			if (lngBytesReceived == modSocketMaster.SOCKET_ERROR) {
				m_enmState = SockState.sckError;
				Debug.Print("STATE: sckError");
				lngErrorCode = Err().LastDllError;
				Err().Raise(lngErrorCode, "CSocketMaster.RecvDataToBuffer", modSocketMaster.GetErrorDescription(lngErrorCode));


			} else if (lngBytesReceived > 0) {
				strBuffTemporal = System.Text.Encoding.Unicode.GetString(arrBuffer);
				m_strRecvBuffer = m_strRecvBuffer + Strings.Left(strBuffTemporal, lngBytesReceived);
				functionReturnValue = lngBytesReceived;

			}
			return functionReturnValue;

		}

		//Retrieves some socket options.
		//If it is an UDP socket also sets SO_BROADCAST option.
		private void ProcessOptions()
		{
			int lngResult = 0;
			int lngBuffer = 0;
			int lngErrorCode = 0;

			if (m_enmProtocol == ProtocolConstants.sckTCPProtocol) {
				lngResult = api_getsockopt(m_lngSocketHandle, modSocketMaster.SOL_SOCKET, modSocketMaster.SO_RCVBUF, ref lngBuffer, ref modLenB.LenB(lngBuffer));

				if (lngResult == modSocketMaster.SOCKET_ERROR) {
					lngErrorCode = Err().LastDllError;
					Err().Raise(lngErrorCode, "CSocketMaster.ProcessOptions", modSocketMaster.GetErrorDescription(lngErrorCode));
				} else {
					m_lngRecvBufferLen = lngBuffer;
				}

				lngResult = api_getsockopt(m_lngSocketHandle, modSocketMaster.SOL_SOCKET, modSocketMaster.SO_SNDBUF, ref lngBuffer, ref modLenB.LenB(lngBuffer));

				if (lngResult == modSocketMaster.SOCKET_ERROR) {
					lngErrorCode = Err().LastDllError;
					Err().Raise(lngErrorCode, "CSocketMaster.ProcessOptions", modSocketMaster.GetErrorDescription(lngErrorCode));
				} else {
					m_lngSendBufferLen = lngBuffer;
				}

			} else {
				lngBuffer = 1;
				lngResult = api_setsockopt(m_lngSocketHandle, modSocketMaster.SOL_SOCKET, modSocketMaster.SO_BROADCAST, ref lngBuffer, modLenB.LenB(lngBuffer));

				lngResult = api_getsockopt(m_lngSocketHandle, modSocketMaster.SOL_SOCKET, modSocketMaster.SO_MAX_MSG_SIZE, ref lngBuffer, ref modLenB.LenB(lngBuffer));

				if (lngResult == modSocketMaster.SOCKET_ERROR) {
					lngErrorCode = Err().LastDllError;
					Err().Raise(lngErrorCode, "CSocketMaster.ProcessOptions", modSocketMaster.GetErrorDescription(lngErrorCode));
				} else {
					m_lngRecvBufferLen = lngBuffer;
					m_lngSendBufferLen = lngBuffer;
				}
			}


			Debug.Print("Winsock buffer size for sends: " + m_lngRecvBufferLen);
			Debug.Print("Winsock buffer size for receives: " + m_lngSendBufferLen);
		}


		public void GetData(ref string data, ref object varType_Renamed = null, ref int maxLen = null)
		{
			if (m_enmProtocol == ProtocolConstants.sckTCPProtocol) {
				if (m_enmState != SockState.sckConnected & !m_blnAcceptClass) {
					Err().Raise(modSocketMaster.sckBadState, "CSocketMaster.GetData", "Wrong protocol or connection state for the requested transaction or request");
					return;
				}
			} else {
				if (m_enmState != SockState.sckOpen) {
					Err().Raise(modSocketMaster.sckBadState, "CSocketMaster.GetData", "Wrong protocol or connection state for the requested transaction or request");
					return;
				}
				if (GetBufferLenUDP() == 0)
					return;
			}

			if ((maxLen != null)) {
				if (Information.IsNumeric(maxLen)) {
					if (Convert.ToInt32(maxLen) < 0) {
						Err().Raise(modSocketMaster.sckInvalidArg, "CSocketMaster.GetData", "The argument passed to a function was not in the correct format or in the specified range.");
					}
				} else {
					if (m_enmProtocol == ProtocolConstants.sckTCPProtocol) {
						maxLen = Strings.Len(m_strRecvBuffer);
					} else {
						maxLen = GetBufferLenUDP();
					}
				}
			}

			int lngBytesRecibidos = 0;

			lngBytesRecibidos = RecvData(ref data, false, ref varType_Renamed, ref maxLen);
			Debug.Print("OK Bytes obtained from buffer: " + lngBytesRecibidos);

		}


		public void PeekData(ref string data, ref object varType_Renamed = null, ref int maxLen = null)
		{
			if (m_enmProtocol == ProtocolConstants.sckTCPProtocol) {
				if (m_enmState != SockState.sckConnected) {
					Err().Raise(modSocketMaster.sckBadState, "CSocketMaster.PeekData", "Wrong protocol or connection state for the requested transaction or request");
					return;
				}
			} else {
				if (m_enmState != SockState.sckOpen) {
					Err().Raise(modSocketMaster.sckBadState, "CSocketMaster.PeekData", "Wrong protocol or connection state for the requested transaction or request");
					return;
				}
				if (GetBufferLenUDP() == 0)
					return;
			}

			if ((maxLen != null)) {
				if (Information.IsNumeric(maxLen)) {
					if (Convert.ToInt32(maxLen) < 0) {
						Err().Raise(modSocketMaster.sckInvalidArg, "CSocketMaster.PeekData", "The argument passed to a function was not in the correct format or in the specified range.");
					}
				} else {
					if (m_enmProtocol == ProtocolConstants.sckTCPProtocol) {
						maxLen = Strings.Len(m_strRecvBuffer);
					} else {
						maxLen = GetBufferLenUDP();
					}
				}
			}

			int lngBytesRecibidos = 0;

			lngBytesRecibidos = RecvData(ref data, true, ref varType_Renamed, ref maxLen);
			Debug.Print("OK Bytes obtained from buffer: " + lngBytesRecibidos);
		}


		//This function is to retrieve data from the buffer. If we are using TCP
		//then the data is retrieved from a local buffer (m_strRecvBuffer). If we
		//are using UDP the data is retrieved from winsock buffer.
		//It can be called by two public methods of the class - GetData and PeekData.
		//Behavior of the function is defined by the blnPeek argument. If a value of
		//that argument is TRUE, the function returns number of bytes in the
		//buffer, and copy data from that buffer into the data argument.
		//If a value of the blnPeek is FALSE, then this function returns number of
		//bytes received, and move data from the buffer into the data
		//argument. MOVE means that data will be removed from the buffer.
		private int RecvData(ref string data, bool blnPeek, ref object varClass = null, ref int maxLen = null)
		{
			int functionReturnValue = 0;

			bool blnMaxLenMiss = false;
			bool blnClassMiss = false;
			string strRecvData = null;
			int lngBufferLen = 0;
			byte[] arrBuffer = null;
			int lngErrorCode = 0;

			if (m_enmProtocol == ProtocolConstants.sckTCPProtocol) {
				lngBufferLen = Strings.Len(m_strRecvBuffer);
			} else {
				lngBufferLen = GetBufferLenUDP();
			}

			blnMaxLenMiss = (maxLen == null);
			blnClassMiss = (varClass == null);

			//Select type of data
			if (Information.VarType(data) == VariantType.Empty) {
				if (blnClassMiss)
					varClass = VariantType.Array + VariantType.Byte;
			} else {
				varClass = Information.VarType(data);
			}

			//As stated on Winsock control documentation if the
			//data type passed is string or byte array type then
			//we must take into account maxLen argument.
			//If it is another type maxLen is ignored.

			if (varClass == VariantType.String | varClass == VariantType.Array + VariantType.Byte) {
				//if maxLen argument is missing
				if (blnMaxLenMiss) {


					if (lngBufferLen == 0) {
						functionReturnValue = 0;

						arrBuffer = System.Text.Encoding.Unicode.GetBytes("");
						//UPGRADE_WARNING: Couldn't resolve default property of object data. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						data = arrBuffer.Clone();
						return functionReturnValue;



					} else {
						functionReturnValue = lngBufferLen;
						arrBuffer = BuildArray(lngBufferLen, blnPeek, ref lngErrorCode);

					}

				//if maxLen argument is not missing
				} else {


					if (maxLen == 0 | lngBufferLen == 0) {
						functionReturnValue = 0;

						arrBuffer = System.Text.Encoding.Unicode.GetBytes("");
						//UPGRADE_WARNING: Couldn't resolve default property of object data. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						data = arrBuffer.Clone();

						if (m_enmProtocol == ProtocolConstants.sckUDPProtocol) {
							EmptyBuffer();
							Err().Raise(modSocketMaster.WSAEMSGSIZE, "CSocketMaster.RecvData", modSocketMaster.GetErrorDescription(modSocketMaster.WSAEMSGSIZE));
						}
						return functionReturnValue;



					} else if (maxLen > lngBufferLen) {
						functionReturnValue = lngBufferLen;
						arrBuffer = BuildArray(lngBufferLen, blnPeek, ref lngErrorCode);


					} else {
						functionReturnValue = Convert.ToInt32(maxLen);
						arrBuffer = BuildArray(Convert.ToInt32(maxLen), blnPeek, ref lngErrorCode);

					}

				}

			}

			string strdata = null;
			bool blnData = false;
			byte bytData = 0;
			decimal curData = default(decimal);
			System.DateTime datData = default(System.DateTime);
			double dblData = 0;
			short intData = 0;
			int lngData = 0;
			float sngData = 0;
			switch (varClass) {

				case VariantType.String:
					strdata = System.Text.Encoding.Unicode.GetString(arrBuffer);
					data = strdata;
					break;
				case VariantType.Array + VariantType.Byte:
					data = arrBuffer.Clone();
					break;
				case VariantType.Boolean:
					if (modLenB.LenB(blnData) > lngBufferLen)
						return functionReturnValue;
					arrBuffer = BuildArray(modLenB.LenB(blnData), blnPeek, ref lngErrorCode);
					functionReturnValue = modLenB.LenB(blnData);
					modSocketMaster.api_CopyMemory(ref blnData, ref arrBuffer[0], modLenB.LenB(blnData));
					data = blnData;
					break;
				case VariantType.Byte:
					if (modLenB.LenB(bytData) > lngBufferLen)
						return functionReturnValue;
					arrBuffer = BuildArray(modLenB.LenB(bytData), blnPeek, ref lngErrorCode);
					functionReturnValue = modLenB.LenB(bytData);
					modSocketMaster.api_CopyMemory(ref bytData, ref arrBuffer[0], modLenB.LenB(bytData));
					data = bytData;
					break;
				case VariantType.Decimal:
					if (modLenB.LenB(curData) > lngBufferLen)
						return functionReturnValue;
					arrBuffer = BuildArray(modLenB.LenB(curData), blnPeek, ref lngErrorCode);
					functionReturnValue = modLenB.LenB(curData);
					modSocketMaster.api_CopyMemory(ref curData, ref arrBuffer[0], modLenB.LenB(curData));
					data = curData;
					break;
				case VariantType.Date:
					if (modLenB.LenB(datData) > lngBufferLen)
						return functionReturnValue;
					arrBuffer = BuildArray(modLenB.LenB(datData), blnPeek, ref lngErrorCode);
					functionReturnValue = modLenB.LenB(datData);
					modSocketMaster.api_CopyMemory(ref datData, ref arrBuffer[0], modLenB.LenB(datData));
					data = datData;
					break;
				case VariantType.Double:
					if (modLenB.LenB(dblData) > lngBufferLen)
						return functionReturnValue;
					arrBuffer = BuildArray(modLenB.LenB(dblData), blnPeek, ref lngErrorCode);
					functionReturnValue = modLenB.LenB(dblData);
					modSocketMaster.api_CopyMemory(ref dblData, ref arrBuffer[0], modLenB.LenB(dblData));
					data = dblData;
					break;
				case VariantType.Short:
					if (modLenB.LenB(intData) > lngBufferLen)
						return functionReturnValue;
					arrBuffer = BuildArray(modLenB.LenB(intData), blnPeek, ref lngErrorCode);
					functionReturnValue = modLenB.LenB(intData);
					modSocketMaster.api_CopyMemory(ref intData, ref arrBuffer[0], modLenB.LenB(intData));
					data = intData;
					break;
				case VariantType.Integer:
					if (modLenB.LenB(lngData) > lngBufferLen)
						return functionReturnValue;
					arrBuffer = BuildArray(modLenB.LenB(lngData), blnPeek, ref lngErrorCode);
					functionReturnValue = modLenB.LenB(lngData);
					modSocketMaster.api_CopyMemory(ref lngData, ref arrBuffer[0], modLenB.LenB(lngData));
					data = lngData;
					break;
				case VariantType.Single:
					if (modLenB.LenB(sngData) > lngBufferLen)
						return functionReturnValue;
					arrBuffer = BuildArray(modLenB.LenB(sngData), blnPeek, ref lngErrorCode);
					functionReturnValue = modLenB.LenB(sngData);
					modSocketMaster.api_CopyMemory(ref sngData, ref arrBuffer[0], modLenB.LenB(sngData));
					data = sngData;
					break;
				default:
					Err().Raise(modSocketMaster.sckUnsupported, "CSocketMaster.RecvData", "Unsupported variant type.");

					break;
			}

			//if BuildArray returns an error is handled here
			if (lngErrorCode != 0) {
				Err().Raise(lngErrorCode, "CSocketMaster.RecvData", modSocketMaster.GetErrorDescription(lngErrorCode));
			}
			return functionReturnValue;

		}

		//Returns a byte array of Size bytes filled with incoming buffer data.
		private byte[] BuildArray(int Size, bool blnPeek, ref int lngErrorCode)
		{
			byte[] functionReturnValue = null;
			string strdata = null;

			byte[] arrBuffer = null;
			int lngResult = 0;
			int lngFlags = 0;
			sockaddr_in udtSockAddr = default(sockaddr_in);

			if (m_enmProtocol == ProtocolConstants.sckTCPProtocol) {
				strdata = Strings.Left(m_strRecvBuffer, Convert.ToInt32(Size));
				functionReturnValue = System.Text.Encoding.Unicode.GetBytes(strdata);

				if (!blnPeek) {
					m_strRecvBuffer = Strings.Mid(m_strRecvBuffer, Size + 1);
				}

			//UDP protocol
			} else {

				if (blnPeek)
					lngFlags = MSG_PEEK;

				arrBuffer = new byte[Size];

				lngResult = api_recvfrom(m_lngSocketHandle, ref arrBuffer[0], Size, lngFlags, ref udtSockAddr, ref modLenB.LenB(udtSockAddr));

				if (lngResult == modSocketMaster.SOCKET_ERROR) {
					lngErrorCode = Err().LastDllError;
				}

				functionReturnValue = arrBuffer.Clone();
				GetRemoteInfoFromSI(ref udtSockAddr, ref m_lngRemotePort, ref m_strRemoteHostIP, ref m_strRemoteHost);

			}
			return functionReturnValue;
		}

		//Clean resolution system that is in charge of
		//asynchronous hostname resolutions.
		private void CleanResolutionSystem()
		{
			int varAsynHandle = 0;

			//cancel async resolutions if they're still running
			foreach (int varAsynHandle_loopVariable in m_colWaitingResolutions) {
				varAsynHandle = varAsynHandle_loopVariable;
				api_WSACancelAsyncRequest(varAsynHandle);
				modSocketMaster.UnregisterResolution(varAsynHandle);
			}

			//free memory buffer where resolution results are stored
			FreeMemory();
		}

		public void Listen()
		{
			if (m_enmState != SockState.sckClosed & m_enmState != SockState.sckOpen) {
				Err().Raise(modSocketMaster.sckInvalidOp, "CSocketMaster.Listen", "Invalid operation at current state");
			}

			if (!SocketExists())
				return;
			if (!BindInternal())
				return;

			int lngResult = 0;

			lngResult = api_listen(m_lngSocketHandle, SOMAXCONN);

			int lngErrorCode = 0;
			if (lngResult == modSocketMaster.SOCKET_ERROR) {
				lngErrorCode = Err().LastDllError;
				Err().Raise(lngErrorCode, "CSocketMaster.Listen", modSocketMaster.GetErrorDescription(lngErrorCode));
			} else {
				m_enmState = SockState.sckListening;
				Debug.Print("STATE: sckListening");
			}

		}

		public void Accept(ref int requestID)
		{
			if (m_enmState != SockState.sckClosed) {
				Err().Raise(modSocketMaster.sckInvalidOp, "CSocketMaster.Accept", "Invalid operation at current state");
			}

			int lngResult = 0;
			sockaddr_in udtSockAddr = default(sockaddr_in);
			int lngErrorCode = 0;

			m_lngSocketHandle = requestID;
			m_enmProtocol = ProtocolConstants.sckTCPProtocol;
			ProcessOptions();

			if (!modSocketMaster.IsAcceptRegistered(requestID)) {
				if (modSocketMaster.IsSocketRegistered(requestID)) {
					Err().Raise(modSocketMaster.sckBadState, "CSocketMaster.Accept", "Wrong protocol or connection state for the requested transaction or request");
				} else {
					m_blnAcceptClass = true;
					m_enmState = SockState.sckConnected;
					Debug.Print("STATE: sckConnected");
					//UPGRADE_ISSUE: ObjPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
					modSocketMaster.RegisterSocket(m_lngSocketHandle, VarPtr.VarPtr(this), false);
					return;
				}
			}

			CSocketMaster clsSocket = null;
			clsSocket = modSocketMaster.GetAcceptClass(requestID);
			modSocketMaster.UnregisterAccept(requestID);

			lngResult = api_getsockname(m_lngSocketHandle, ref udtSockAddr, ref modLenB.LenB(udtSockAddr));


			if (lngResult == modSocketMaster.SOCKET_ERROR) {
				lngErrorCode = Err().LastDllError;
				Err().Raise(lngErrorCode, "CSocketMaster.Accept", modSocketMaster.GetErrorDescription(lngErrorCode));


			} else {
				m_lngLocalPortBind = modSocketMaster.IntegerToUnsigned(ref api_ntohs(udtSockAddr.sin_port));
				m_strLocalIP = modSocketMaster.StringFromPointer(api_inet_ntoa(udtSockAddr.sin_addr));

			}

			GetRemoteInfo(m_lngSocketHandle, ref m_lngRemotePort, ref m_strRemoteHostIP, ref m_strRemoteHost);
			m_enmState = SockState.sckConnected;
			Debug.Print("STATE: sckConnected");

			if (clsSocket.BytesReceived > 0) {
				clsSocket.GetData(m_strRecvBuffer);
			}

			//UPGRADE_ISSUE: ObjPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
			modSocketMaster.Subclass_ChangeOwner(requestID, VarPtr.VarPtr(this));

			if (Strings.Len(m_strRecvBuffer) > 0)
				if (DataArrival != null) {
					DataArrival(Strings.Len(m_strRecvBuffer));
				}

			if (clsSocket.State == SockState.sckClosing) {
				m_enmState = SockState.sckClosing;
				Debug.Print("STATE: sckClosing");
				if (CloseSck != null) {
					CloseSck();
				}
			}

			clsSocket = null;
		}

		//Retrieves remote info from a connected socket.
		//If succeeds returns TRUE and loads the arguments.
		//If fails returns FALSE and arguments are not loaded.
		private bool GetRemoteInfo(int lngSocket, ref int lngRemotePort, ref string strRemoteHostIP, ref string strRemoteHost)
		{
			bool functionReturnValue = false;
			functionReturnValue = false;
			int lngResult = 0;
			sockaddr_in udtSockAddr = default(sockaddr_in);

			//lngResult = api_getpeername(lngSocket, udtSockAddr, LenB(udtSockAddr))

			if (lngResult == 0) {
				functionReturnValue = true;
				GetRemoteInfoFromSI(ref udtSockAddr, ref lngRemotePort, ref strRemoteHostIP, ref strRemoteHost);
			} else {
				lngRemotePort = 0;
				strRemoteHostIP = "";
				strRemoteHost = "";
			}
			return functionReturnValue;
		}

		//Gets remote info from a sockaddr_in structure.

		private void GetRemoteInfoFromSI(ref sockaddr_in udtSockAddr, ref int lngRemotePort, ref string strRemoteHostIP, ref string strRemoteHost)
		{
			//Dim lngResult As Long
			//Dim udtHostent As HOSTENT

			lngRemotePort = modSocketMaster.IntegerToUnsigned(ref api_ntohs(udtSockAddr.sin_port));
			strRemoteHostIP = modSocketMaster.StringFromPointer(api_inet_ntoa(udtSockAddr.sin_addr));
			//lngResult = api_gethostbyaddr(udtSockAddr.sin_addr, 4&, AF_INET)

			//If lngResult <> 0 Then
			//    api_CopyMemory udtHostent, ByVal lngResult, LenB(udtHostent)
			//    strRemoteHost = StringFromPointer(udtHostent.hName)
			//Else
			m_strRemoteHost = "";
			//End If

		}

		//Returns winsock incoming buffer length from an UDP socket.
		private int GetBufferLenUDP()
		{
			int functionReturnValue = 0;
			int lngResult = 0;
			int lngBuffer = 0;
			lngResult = api_ioctlsocket(m_lngSocketHandle, modSocketMaster.FIONREAD, ref lngBuffer);

			if (lngResult == modSocketMaster.SOCKET_ERROR) {
				functionReturnValue = 0;
			} else {
				functionReturnValue = lngBuffer;
			}
			return functionReturnValue;
		}

		//Empty winsock incoming buffer from an UDP socket.
		private void EmptyBuffer()
		{
			byte B = 0;
			api_recv(m_lngSocketHandle, ref B, Strings.Len(B), 0);
		}
	}
}
