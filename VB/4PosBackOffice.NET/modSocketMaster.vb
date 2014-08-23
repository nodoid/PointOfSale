Option Strict Off
Option Explicit On
Module modSocketMaster
	'**************************************************************************************
	'
	'modSocketMaster module 1.1
	'Copyright (c) 2004 by Emiliano Scavuzzo <anshoku@yahoo.com>
	'
	'Rosario, Argentina
	'
	'**************************************************************************************
	'This module contains API declarations and helper functions for the CSocketMaster class
	'**************************************************************************************
	
	
	'==============================================================================
	'API FUNCTIONS
	'==============================================================================
	
	Public Declare Sub api_CopyMemory Lib "kernel32" Alias "RtlMoveMemory" (ByRef Destination As Object, ByRef Source As Object, ByVal Length As Integer)
	Public Declare Function api_WSAGetLastError Lib "ws2_32.dll"  Alias "WSAGetLastError"() As Integer
	Public Declare Function api_GlobalAlloc Lib "kernel32"  Alias "GlobalAlloc"(ByVal wFlags As Integer, ByVal dwBytes As Integer) As Integer
	Public Declare Function api_GlobalFree Lib "kernel32"  Alias "GlobalFree"(ByVal hMem As Integer) As Integer
	'UPGRADE_WARNING: Structure WSAData may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function api_WSAStartup Lib "ws2_32.dll"  Alias "WSAStartup"(ByVal wVersionRequired As Integer, ByRef lpWSADATA As WSAData) As Integer
	Private Declare Function api_WSACleanup Lib "ws2_32.dll"  Alias "WSACleanup"() As Integer
	Private Declare Function api_WSAAsyncGetHostByName Lib "ws2_32.dll" Alias "WSAAsyncGetHostByName" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal strHostName As String, ByRef buf As Object, ByVal buflen As Integer) As Integer
	Private Declare Function api_WSAAsyncSelect Lib "wsock32.dll"  Alias "WSAAsyncSelect"(ByVal s As Integer, ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal lEvent As Integer) As Integer
	Private Declare Function api_CreateWindowEx Lib "user32" Alias "CreateWindowExA" (ByVal dwExStyle As Integer, ByVal lpClassName As String, ByVal lpWindowName As String, ByVal dwStyle As Integer, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hWndParent As Integer, ByVal hMenu As Integer, ByVal hInstance As Integer, ByRef lpParam As Object) As Integer
	Private Declare Function api_DestroyWindow Lib "user32"  Alias "DestroyWindow"(ByVal hwnd As Integer) As Integer
	Private Declare Function api_lstrlen Lib "kernel32" Alias "lstrlenA" (ByVal lpString As Object) As Integer
	Private Declare Function api_lstrcpy Lib "kernel32"  Alias "lstrcpyA"(ByVal lpString1 As String, ByVal lpString2 As Integer) As Integer
	
	
	'==============================================================================
	'CONSTANTS
	'==============================================================================
	
	Public Const SOCKET_ERROR As Short = -1
	Public Const INVALID_SOCKET As Short = -1
	Public Const INADDR_NONE As Integer = &HFFFF
	
	Private Const WSADESCRIPTION_LEN As Short = 257
	Private Const WSASYS_STATUS_LEN As Short = 129
	
	Private Enum WinsockVersion
		SOCKET_VERSION_11 = &H101
		SOCKET_VERSION_22 = &H202
	End Enum
	
	Public Const MAXGETHOSTSTRUCT As Short = 1024
	
	Public Const AF_INET As Integer = 2
	Public Const SOCK_STREAM As Integer = 1
	Public Const SOCK_DGRAM As Integer = 2
	Public Const IPPROTO_TCP As Integer = 6
	Public Const IPPROTO_UDP As Integer = 17
	
	Public Const FD_READ As Integer = &H1
	Public Const FD_WRITE As Integer = &H2
	Public Const FD_ACCEPT As Integer = &H8
	Public Const FD_CONNECT As Integer = &H10
	Public Const FD_CLOSE As Integer = &H20
	
	Private Const OFFSET_2 As Integer = 65536
	Private Const MAXINT_2 As Short = 32767
	
	Public Const GMEM_FIXED As Integer = &H0
	Public Const LOCAL_HOST_BUFF As Short = 256
	
	Public Const SOL_SOCKET As Integer = 65535
	Public Const SO_SNDBUF As Integer = &H1001
	Public Const SO_RCVBUF As Integer = &H1002
	Public Const SO_MAX_MSG_SIZE As Integer = &H2003
	Public Const SO_BROADCAST As Integer = &H20
	Public Const FIONREAD As Integer = &H4004667F
	
	'==============================================================================
	'ERROR CODES
	'==============================================================================
	
	Public Const WSABASEERR As Integer = 10000
	Public Const WSAEINTR As Integer = (WSABASEERR + 4)
	Public Const WSAEACCES As Integer = (WSABASEERR + 13)
	Public Const WSAEFAULT As Integer = (WSABASEERR + 14)
	Public Const WSAEINVAL As Integer = (WSABASEERR + 22)
	Public Const WSAEMFILE As Integer = (WSABASEERR + 24)
	Public Const WSAEWOULDBLOCK As Integer = (WSABASEERR + 35)
	Public Const WSAEINPROGRESS As Integer = (WSABASEERR + 36)
	Public Const WSAEALREADY As Integer = (WSABASEERR + 37)
	Public Const WSAENOTSOCK As Integer = (WSABASEERR + 38)
	Public Const WSAEDESTADDRREQ As Integer = (WSABASEERR + 39)
	Public Const WSAEMSGSIZE As Integer = (WSABASEERR + 40)
	Public Const WSAEPROTOTYPE As Integer = (WSABASEERR + 41)
	Public Const WSAENOPROTOOPT As Integer = (WSABASEERR + 42)
	Public Const WSAEPROTONOSUPPORT As Integer = (WSABASEERR + 43)
	Public Const WSAESOCKTNOSUPPORT As Integer = (WSABASEERR + 44)
	Public Const WSAEOPNOTSUPP As Integer = (WSABASEERR + 45)
	Public Const WSAEPFNOSUPPORT As Integer = (WSABASEERR + 46)
	Public Const WSAEAFNOSUPPORT As Integer = (WSABASEERR + 47)
	Public Const WSAEADDRINUSE As Integer = (WSABASEERR + 48)
	Public Const WSAEADDRNOTAVAIL As Integer = (WSABASEERR + 49)
	Public Const WSAENETDOWN As Integer = (WSABASEERR + 50)
	Public Const WSAENETUNREACH As Integer = (WSABASEERR + 51)
	Public Const WSAENETRESET As Integer = (WSABASEERR + 52)
	Public Const WSAECONNABORTED As Integer = (WSABASEERR + 53)
	Public Const WSAECONNRESET As Integer = (WSABASEERR + 54)
	Public Const WSAENOBUFS As Integer = (WSABASEERR + 55)
	Public Const WSAEISCONN As Integer = (WSABASEERR + 56)
	Public Const WSAENOTCONN As Integer = (WSABASEERR + 57)
	Public Const WSAESHUTDOWN As Integer = (WSABASEERR + 58)
	Public Const WSAETIMEDOUT As Integer = (WSABASEERR + 60)
	Public Const WSAEHOSTUNREACH As Integer = (WSABASEERR + 65)
	Public Const WSAECONNREFUSED As Integer = (WSABASEERR + 61)
	Public Const WSAEPROCLIM As Integer = (WSABASEERR + 67)
	Public Const WSASYSNOTREADY As Integer = (WSABASEERR + 91)
	Public Const WSAVERNOTSUPPORTED As Integer = (WSABASEERR + 92)
	Public Const WSANOTINITIALISED As Integer = (WSABASEERR + 93)
	Public Const WSAHOST_NOT_FOUND As Integer = (WSABASEERR + 1001)
	Public Const WSATRY_AGAIN As Integer = (WSABASEERR + 1002)
	Public Const WSANO_RECOVERY As Integer = (WSABASEERR + 1003)
	Public Const WSANO_DATA As Integer = (WSABASEERR + 1004)
	
	'==============================================================================
	'WINSOCK CONTROL ERROR CODES
	'==============================================================================
	
	Public Const sckOutOfMemory As Short = 7
	Public Const sckBadState As Integer = 40006
	Public Const sckInvalidArg As Integer = 40014
	Public Const sckUnsupported As Integer = 40018
	Public Const sckInvalidOp As Integer = 40020
	
	'==============================================================================
	'STRUCTURES
	'==============================================================================
	
	Private Structure WSAData
		Dim wVersion As Short
		Dim wHighVersion As Short
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(WSADESCRIPTION_LEN),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=WSADESCRIPTION_LEN)> Public szDescription() As Char
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(WSASYS_STATUS_LEN),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=WSASYS_STATUS_LEN)> Public szSystemStatus() As Char
		Dim iMaxSockets As Short
		Dim iMaxUdpDg As Short
		Dim lpVendorInfo As Integer
	End Structure
	
	Public Structure HOSTENT
		Dim hName As Integer
		Dim hAliases As Integer
		Dim hAddrType As Short
		Dim hLength As Short
		Dim hAddrList As Integer
	End Structure
	
	Public Structure sockaddr_in
		Dim sin_family As Short
		Dim sin_port As Short
		Dim sin_addr As Integer
		<VBFixedArray(8)> Dim sin_zero() As Byte
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			'UPGRADE_WARNING: Lower bound of array sin_zero was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
			ReDim sin_zero(8)
		End Sub
	End Structure
	
	'==============================================================================
	'MEMBER VARIABLES
	'==============================================================================
	
	Private m_blnInitiated As Boolean 'specify if winsock service was initiated
	Private m_lngSocksQuantity As Integer 'number of instances created
	Private m_colSocketsInst As Collection 'sockets list and instance owner
	Private m_colAcceptList As Collection 'sockets in queue that need to be accepted
	Private m_lngWindowHandle As Integer 'message window handle
	
	'==============================================================================
	'SUBCLASSING DECLARATIONS
	'by Paul Caton
	'==============================================================================
	Private Declare Function api_IsWindow Lib "user32"  Alias "IsWindow"(ByVal hwnd As Integer) As Integer
	Private Declare Function api_GetWindowLong Lib "user32"  Alias "GetWindowLongA"(ByVal hwnd As Integer, ByVal nIndex As Integer) As Integer
	Private Declare Function api_SetWindowLong Lib "user32"  Alias "SetWindowLongA"(ByVal hwnd As Integer, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
	Private Declare Function api_GetModuleHandle Lib "kernel32"  Alias "GetModuleHandleA"(ByVal lpModuleName As String) As Integer
	Private Declare Function api_GetProcAddress Lib "kernel32"  Alias "GetProcAddress"(ByVal hModule As Integer, ByVal lpProcName As String) As Integer
	
	Private Const PATCH_06 As Integer = 106
	Private Const PATCH_09 As Integer = 137
	
	Private Const GWL_WNDPROC As Short = (-4)
	
	Private Const WM_USER As Integer = &H400
	
	Public Const RESOLVE_MESSAGE As Integer = WM_USER + &H400
	Public Const SOCKET_MESSAGE As Integer = WM_USER + &H401
	
	Private lngMsgCntA As Integer 'TableA entry count
	Private lngMsgCntB As Integer 'TableB entry count
	Private lngTableA1() As Integer 'TableA1: list of async handles
	Private lngTableA2() As Integer 'TableA2: list of async handles owners
	Private lngTableB1() As Integer 'TableB1: list of sockets
	Private lngTableB2() As Integer 'TableB2: list of sockets owners
	Private hWndSub As Integer 'window handle subclassed
	Private nAddrSubclass As Integer 'address of our WndProc
	Private nAddrOriginal As Integer 'address of original WndProc
	
	
	'This function initiates the processes needed to keep
	'control of sockets. Returns 0 if it has success.
	Public Function InitiateProcesses() As Integer
		
		InitiateProcesses = 0
		m_lngSocksQuantity = m_lngSocksQuantity + 1
		
		'if the service wasn't initiated yet we do it now
		Dim lngResult As Integer
		If Not m_blnInitiated Then
			
			Subclass_Initialize()
			
			m_blnInitiated = True
			
			lngResult = InitiateService
			
			If lngResult = 0 Then
				Debug.Print("OK Winsock service initiated")
			Else
				Debug.Print("ERROR trying to initiate winsock service")
				Err.Raise(lngResult, "modSocketMaster.InitiateProcesses", GetErrorDescription(lngResult))
				InitiateProcesses = lngResult
			End If
			
		End If
	End Function
	
	'This function initiate the winsock service calling
	'the api_WSAStartup funtion and returns resulting value.
	Private Function InitiateService() As Integer
		Dim udtWSAData As WSAData
		Dim lngResult As Integer
		
		lngResult = api_WSAStartup(WinsockVersion.SOCKET_VERSION_11, udtWSAData)
		InitiateService = lngResult
	End Function
	
	'Once we are done with the class instance we call this
	'function to discount it and finish winsock service if
	'it was the last one.
	'Returns 0 if it has success.
	Public Function FinalizeProcesses() As Integer
		FinalizeProcesses = 0
		m_lngSocksQuantity = m_lngSocksQuantity - 1
		
		'if the service was initiated and there's no more instances
		'of the class then we finish the service
		Dim lngErrorCode As Integer
		If m_blnInitiated And m_lngSocksQuantity = 0 Then
			If FinalizeService = SOCKET_ERROR Then
				lngErrorCode = Err.LastDllError
				FinalizeProcesses = lngErrorCode
				Err.Raise(lngErrorCode, "modSocketMaster.FinalizeProcesses", GetErrorDescription(lngErrorCode))
			Else
				Debug.Print("OK Winsock service finalized")
			End If
			
			Subclass_Terminate()
			m_blnInitiated = False
		End If
		
	End Function
	
	'Finish winsock service calling the function
	'api_WSACleanup and returns the result.
	Private Function FinalizeService() As Integer
		Dim lngResultado As Integer
		lngResultado = api_WSACleanup
		FinalizeService = lngResultado
	End Function
	
	'This function receives a number that represents an error
	'and returns the corresponding description string.
	Public Function GetErrorDescription(ByVal lngErrorCode As Integer) As String
		Select Case lngErrorCode
			Case WSAEACCES
				GetErrorDescription = "Permission denied."
			Case WSAEADDRINUSE
				GetErrorDescription = "Address already in use."
			Case WSAEADDRNOTAVAIL
				GetErrorDescription = "Cannot assign requested address."
			Case WSAEAFNOSUPPORT
				GetErrorDescription = "Address family not supported by protocol family."
			Case WSAEALREADY
				GetErrorDescription = "Operation already in progress."
			Case WSAECONNABORTED
				GetErrorDescription = "Software caused connection abort."
			Case WSAECONNREFUSED
				GetErrorDescription = "Connection refused."
			Case WSAECONNRESET
				GetErrorDescription = "Connection reset by peer."
			Case WSAEDESTADDRREQ
				GetErrorDescription = "Destination address required."
			Case WSAEFAULT
				GetErrorDescription = "Bad address."
			Case WSAEHOSTUNREACH
				GetErrorDescription = "No route to host."
			Case WSAEINPROGRESS
				GetErrorDescription = "Operation now in progress."
			Case WSAEINTR
				GetErrorDescription = "Interrupted function call."
			Case WSAEINVAL
				GetErrorDescription = "Invalid argument."
			Case WSAEISCONN
				GetErrorDescription = "Socket is already connected."
			Case WSAEMFILE
				GetErrorDescription = "Too many open files."
			Case WSAEMSGSIZE
				GetErrorDescription = "Message too long."
			Case WSAENETDOWN
				GetErrorDescription = "Network is down."
			Case WSAENETRESET
				GetErrorDescription = "Network dropped connection on reset."
			Case WSAENETUNREACH
				GetErrorDescription = "Network is unreachable."
			Case WSAENOBUFS
				GetErrorDescription = "No buffer space available."
			Case WSAENOPROTOOPT
				GetErrorDescription = "Bad protocol option."
			Case WSAENOTCONN
				GetErrorDescription = "Socket is not connected."
			Case WSAENOTSOCK
				GetErrorDescription = "Socket operation on nonsocket."
			Case WSAEOPNOTSUPP
				GetErrorDescription = "Operation not supported."
			Case WSAEPFNOSUPPORT
				GetErrorDescription = "Protocol family not supported."
			Case WSAEPROCLIM
				GetErrorDescription = "Too many processes."
			Case WSAEPROTONOSUPPORT
				GetErrorDescription = "Protocol not supported."
			Case WSAEPROTOTYPE
				GetErrorDescription = "Protocol wrong type for socket."
			Case WSAESHUTDOWN
				GetErrorDescription = "Cannot send after socket shutdown."
			Case WSAESOCKTNOSUPPORT
				GetErrorDescription = "Socket type not supported."
			Case WSAETIMEDOUT
				GetErrorDescription = "Connection timed out."
			Case WSAEWOULDBLOCK
				GetErrorDescription = "Resource temporarily unavailable."
			Case WSAHOST_NOT_FOUND
				GetErrorDescription = "Host not found."
			Case WSANOTINITIALISED
				GetErrorDescription = "Successful WSAStartup not yet performed."
			Case WSANO_DATA
				GetErrorDescription = "Valid name, no data record of requested type."
			Case WSANO_RECOVERY
				GetErrorDescription = "This is a nonrecoverable error."
			Case WSASYSNOTREADY
				GetErrorDescription = "Network subsystem is unavailable."
			Case WSATRY_AGAIN
				GetErrorDescription = "Nonauthoritative host not found."
			Case WSAVERNOTSUPPORTED
				GetErrorDescription = "Winsock.dll version out of range."
			Case Else
				GetErrorDescription = "Unknown error."
		End Select
		
	End Function
	
	'Create a window that is used to capture sockets messages.
	'Returns 0 if it has success.
	Private Function CreateWinsockMessageWindow() As Integer
        m_lngWindowHandle = api_CreateWindowEx(0, "STATIC", "SOCKET_WINDOW", 0, 0, 0, 0, 0, 0, 0, Process.GetCurrentProcess.Handle.ToInt32, 0)
		
		If m_lngWindowHandle = 0 Then
			CreateWinsockMessageWindow = sckOutOfMemory
			Exit Function
		Else
			CreateWinsockMessageWindow = 0
			Debug.Print("OK Created winsock message window " & m_lngWindowHandle)
		End If
	End Function
	
	'Destroy the window that is used to capture sockets messages.
	'Returns 0 if it has success.
	Private Function DestroyWinsockMessageWindow() As Integer
		DestroyWinsockMessageWindow = 0
		
		If m_lngWindowHandle = 0 Then
			Debug.Print("WARNING lngWindowHandle is ZERO")
			Exit Function
		End If
		
		Dim lngResult As Integer
		
		lngResult = api_DestroyWindow(m_lngWindowHandle)
		
		If lngResult = 0 Then
			DestroyWinsockMessageWindow = sckOutOfMemory
			Err.Raise(sckOutOfMemory, "modSocketMaster.DestroyWinsockMessageWindow", "Out of memory")
		Else
			Debug.Print("OK Destroyed winsock message window " & m_lngWindowHandle)
			m_lngWindowHandle = 0
		End If
		
	End Function
	
	'When a socket needs to resolve a hostname in asynchronous way
	'it calls this function. If it has success it returns a nonzero
	'number that represents the async task handle and register this
	'number in the TableA list.
	'Returns 0 if it fails.
	Public Function ResolveHost(ByVal strHost As String, ByVal lngHOSTENBuf As Integer, ByVal lngObjectPointer As Integer) As Integer
		Dim lngAsynHandle As Integer
		lngAsynHandle = api_WSAAsyncGetHostByName(m_lngWindowHandle, RESOLVE_MESSAGE, strHost, lngHOSTENBuf, MAXGETHOSTSTRUCT)
		If lngAsynHandle <> 0 Then Subclass_AddResolveMessage(lngAsynHandle, lngObjectPointer)
		ResolveHost = lngAsynHandle
	End Function
	
	'Returns the hi word from a double word.
	Public Function HiWord(ByRef lngValue As Integer) As Integer
		If (lngValue And &H80000000) = &H80000000 Then
			HiWord = ((lngValue And &H7FFF0000) \ &H10000) Or &H8000
		Else
			HiWord = (lngValue And &HFFFF0000) \ &H10000
		End If
	End Function
	
	'Returns the low word from a double word.
	Public Function LoWord(ByRef lngValue As Integer) As Integer
		LoWord = (lngValue And &HFFFF)
	End Function
	
	'Receives a string pointer and it turns it into a regular string.
	Public Function StringFromPointer(ByVal lPointer As Integer) As String
		Dim strTemp As String
		Dim lRetVal As Integer
		
		strTemp = New String(Chr(0), api_lstrlen(lPointer))
		lRetVal = api_lstrcpy(strTemp, lPointer)
		If lRetVal Then StringFromPointer = strTemp
	End Function
	
	'The function takes an unsigned Integer from and API and 
	'converts it to a Long for display or arithmetic purposes
	Public Function UnsignedToInteger(ByRef Value As Integer) As Short
		If Value < 0 Or Value >= OFFSET_2 Then Error(6) ' Overflow
		If Value <= MAXINT_2 Then
			UnsignedToInteger = Value
		Else
			UnsignedToInteger = Value - OFFSET_2
		End If
	End Function
	
	'The function takes a Long containing a value in the range 
	'of an unsigned Integer and returns an Integer that you 
	'can pass to an API that requires an unsigned Integer
	Public Function IntegerToUnsigned(ByRef Value As Short) As Integer
		If Value < 0 Then
			IntegerToUnsigned = Value + OFFSET_2
		Else
			IntegerToUnsigned = Value
		End If
	End Function
	
	'Adds the socket to the m_colSocketsInst collection, and
	'registers that socket with WSAAsyncSelect Winsock API
	'function to receive network events for the socket.
	'If this socket is the first one to be registered, the
	'window and collection will be created in this function as well.
	Public Function RegisterSocket(ByVal lngSocket As Integer, ByVal lngObjectPointer As Integer, ByVal blnEvents As Boolean) As Boolean
		
		If m_colSocketsInst Is Nothing Then
			m_colSocketsInst = New Collection
			Debug.Print("OK Created socket collection")
			
			If CreateWinsockMessageWindow <> 0 Then
				Err.Raise(sckOutOfMemory, "modSocketMaster.RegisterSocket", "Out of memory")
			End If
			
			Subclass_Subclass(m_lngWindowHandle)
			
		End If
		
		Subclass_AddSocketMessage(lngSocket, lngObjectPointer)
		
		'Do we need to register socket events?
		Dim lngEvents As Integer
		Dim lngResult As Integer
		Dim lngErrorCode As Integer
		If blnEvents Then
			
			lngEvents = FD_READ Or FD_WRITE Or FD_ACCEPT Or FD_CONNECT Or FD_CLOSE
			lngResult = api_WSAAsyncSelect(lngSocket, m_lngWindowHandle, SOCKET_MESSAGE, lngEvents)
			
			If lngResult = SOCKET_ERROR Then
				Debug.Print("ERROR trying to register events from socket " & lngSocket)
				lngErrorCode = Err.LastDllError
				Err.Raise(lngErrorCode, "modSocketMaster.RegisterSocket", GetErrorDescription(lngErrorCode))
			Else
				Debug.Print("OK Registered events from socket " & lngSocket)
			End If
		End If
		
		m_colSocketsInst.Add(lngObjectPointer, "S" & lngSocket)
		RegisterSocket = True
	End Function
	
	'Removes the socket from the m_colSocketsInst collection
	'If it is the last socket in that collection, the window
	'and colection will be destroyed as well.
	Public Sub UnregisterSocket(ByVal lngSocket As Integer)
		Subclass_DelSocketMessage(lngSocket)
		On Error Resume Next
		m_colSocketsInst.Remove("S" & lngSocket)
		
		If m_colSocketsInst.Count() = 0 Then
			'UPGRADE_NOTE: Object m_colSocketsInst may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			m_colSocketsInst = Nothing
			Subclass_UnSubclass()
			DestroyWinsockMessageWindow()
			Debug.Print("OK Destroyed socket collection")
		End If
	End Sub
	
	'Returns TRUE si the socket that is passed is registered
	'in the colSocketsInst collection.
	Public Function IsSocketRegistered(ByVal lngSocket As Integer) As Boolean
		On Error GoTo Error_Handler
		
        m_colSocketsInst.Add("S" & lngSocket)
		IsSocketRegistered = True
		
		Exit Function
		
Error_Handler: 
		IsSocketRegistered = False
	End Function
	
	'When ResolveHost is called an async task handle is added
	'to TableA list. Use this function to remove that record.
	Public Sub UnregisterResolution(ByVal lngAsynHandle As Integer)
		Subclass_DelResolveMessage(lngAsynHandle)
	End Sub
	
	'It turns a CSocketMaster instance pointer into an actual instance.
	Private Function SocketObjectFromPointer(ByVal lngPointer As Integer) As CSocketMaster
		
		Dim objSocket As CSocketMaster
		
		'UPGRADE_WARNING: Couldn't resolve default property of object objSocket. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		api_CopyMemory(objSocket, lngPointer, 4)
		SocketObjectFromPointer = objSocket
		'UPGRADE_WARNING: Couldn't resolve default property of object objSocket. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		api_CopyMemory(objSocket, 0, 4)
		
	End Function
	
	'Assing a temporal instance of CSocketMaster to a
	'socket and register this socket to the accept list.
	Public Sub RegisterAccept(ByVal lngSocket As Integer)
		If m_colAcceptList Is Nothing Then
			m_colAcceptList = New Collection
			Debug.Print("OK Created accept collection")
		End If
		Dim Socket As CSocketMaster
		Socket = New CSocketMaster
		Socket.Accept(lngSocket)
		m_colAcceptList.Add(Socket, "S" & lngSocket)
	End Sub
	
	'Returns True is lngSocket is registered on the
	'accept list.
	Public Function IsAcceptRegistered(ByVal lngSocket As Integer) As Boolean
		On Error GoTo Error_Handler
		
        m_colAcceptList.Add("S" & lngSocket)
		IsAcceptRegistered = True
		
		Exit Function
		
Error_Handler: 
		IsAcceptRegistered = False
	End Function
	
	'Unregister lngSocket from the accept list.
	Public Sub UnregisterAccept(ByVal lngSocket As Integer)
		m_colAcceptList.Remove("S" & lngSocket)
		
		If m_colAcceptList.Count() = 0 Then
			'UPGRADE_NOTE: Object m_colAcceptList may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			m_colAcceptList = Nothing
			Debug.Print("OK Destroyed accept collection")
		End If
	End Sub
	
	'Return the accept instance class from a socket.
	Public Function GetAcceptClass(ByVal lngSocket As Integer) As CSocketMaster
		GetAcceptClass = m_colAcceptList.Item("S" & lngSocket)
	End Function
	
	
	'==============================================================================
	'SUBCLASSING CODE
	'based on code by Paul Caton
	'==============================================================================
	
	Private Sub Subclass_Initialize()
		Const PATCH_01 As Integer = 15 'Code buffer offset to the location of the relative address to EbMode
		Const PATCH_03 As Integer = 76 'Relative address of SetWindowsLong
		Const PATCH_05 As Integer = 100 'Relative address of CallWindowProc
		Const FUNC_EBM As String = "EbMode" 'VBA's EbMode function allows the machine code thunk to know if the IDE has stopped or is on a breakpoint
		Const FUNC_SWL As String = "SetWindowLongA" 'SetWindowLong allows the cSubclasser machine code thunk to unsubclass the subclasser itself if it detects via the EbMode function that the IDE has stopped
		Const FUNC_CWP As String = "CallWindowProcA" 'We use CallWindowProc to call the original WndProc
		Const MOD_VBA5 As String = "vba5" 'Location of the EbMode function if running VB5
		Const MOD_VBA6 As String = "vba6" 'Location of the EbMode function if running VB6
		Const MOD_USER As String = "user32" 'Location of the SetWindowLong & CallWindowProc functions
		Dim i As Integer 'Loop index
		Dim nLen As Integer 'String lengths
		Dim sHex As String 'Hex code string
		Dim sCode As String 'Binary code string
		
		'Store the hex pair machine code representation in sHex
		sHex = "5850505589E55753515231C0EB0EE8xxxxx01x83F802742285C074258B45103D0008000074433D01080000745BE8200000005A595B5FC9C21400E813000000EBF168xxxxx02x6AFCFF750CE8xxxxx03xEBE0FF7518FF7514FF7510FF750C68xxxxx04xE8xxxxx05xC3BBxxxxx06x8B4514BFxxxxx07x89D9F2AF75B629CB4B8B1C9Dxxxxx08xEB1DBBxxxxx09x8B4514BFxxxxx0Ax89D9F2AF759729CB4B8B1C9Dxxxxx0Bx895D088B1B8B5B1C89D85A595B5FC9FFE0"
		nLen = Len(sHex) 'Length of hex pair string
		
		'Convert the string from hex pairs to bytes and store in the ASCII string opcode buffer
		For i = 1 To nLen Step 2 'For each pair of hex characters
			'UPGRADE_ISSUE: ChrB$ function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
            sCode = sCode & Convert.ToChar(Val("&H" & Mid(sHex, i, 2))) 'Convert a pair of hex characters to a byte and append to the ASCII string
		Next i 'Next pair
		
		'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
		nLen = LenB(sCode) 'Get the machine code length
		nAddrSubclass = api_GlobalAlloc(0, nLen) 'Allocate fixed memory for machine code buffer
		Debug.Print("OK Subclass memory allocated at: " & nAddrSubclass)
		
		'Copy the code to allocated memory
		'UPGRADE_ISSUE: StrPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
        Call api_CopyMemory(nAddrSubclass, sCode, nLen)
		
		If Subclass_InIDE Then
			'Patch the jmp (EB0E) with two nop's (90) enabling the IDE breakpoint/stop checking code
			Call api_CopyMemory(nAddrSubclass + 12, &H9090, 2)
			
			i = Subclass_AddrFunc(MOD_VBA6, FUNC_EBM) 'Get the address of EbMode in vba6.dll
			If i = 0 Then 'Found?
				i = Subclass_AddrFunc(MOD_VBA5, FUNC_EBM) 'VB5 perhaps, try vba5.dll
			End If
			
			System.Diagnostics.Debug.Assert(i, "") 'Ensure the EbMode function was found
			Call Subclass_PatchRel(PATCH_01, i) 'Patch the relative address to the EbMode api function
		End If
		
		Call Subclass_PatchRel(PATCH_03, Subclass_AddrFunc(MOD_USER, FUNC_SWL)) 'Address of the SetWindowLong api function
		Call Subclass_PatchRel(PATCH_05, Subclass_AddrFunc(MOD_USER, FUNC_CWP)) 'Address of the CallWindowProc api function
	End Sub
	
	'UnSubclass and release the allocated memory
	Private Sub Subclass_Terminate()
		Call Subclass_UnSubclass() 'UnSubclass if the Subclass thunk is active
		Call api_GlobalFree(nAddrSubclass) 'Release the allocated memory
		Debug.Print("OK Freed subclass memory at: " & nAddrSubclass)
		nAddrSubclass = 0
		'UPGRADE_WARNING: Lower bound of array lngTableA1 was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		ReDim lngTableA1(1)
		'UPGRADE_WARNING: Lower bound of array lngTableA2 was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		ReDim lngTableA2(1)
		'UPGRADE_WARNING: Lower bound of array lngTableB1 was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		ReDim lngTableB1(1)
		'UPGRADE_WARNING: Lower bound of array lngTableB2 was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		ReDim lngTableB2(1)
	End Sub
	
	'Return whether we're running in the IDE. Public for general utility purposes
	Private Function Subclass_InIDE() As Boolean
		System.Diagnostics.Debug.Assert(Subclass_SetTrue(Subclass_InIDE), "")
	End Function
	
	'Set the window subclass
	Private Function Subclass_Subclass(ByVal hwnd As Integer) As Boolean
		Const PATCH_02 As Integer = 66 'Address of the previous WndProc
		Const PATCH_04 As Integer = 95 'Address of the previous WndProc
		
		If hWndSub = 0 Then
			System.Diagnostics.Debug.Assert(api_IsWindow(hwnd), "") 'Invalid window handle
			hWndSub = hwnd 'Store the window handle
			
			'Get the original window proc
			nAddrOriginal = api_GetWindowLong(hwnd, GWL_WNDPROC)
			Call Subclass_PatchVal(PATCH_02, nAddrOriginal) 'Original WndProc address for CallWindowProc, call the original WndProc
			Call Subclass_PatchVal(PATCH_04, nAddrOriginal) 'Original WndProc address for SetWindowLong, unsubclass on IDE stop
			
			'Set our WndProc in place of the original
			nAddrOriginal = api_SetWindowLong(hwnd, GWL_WNDPROC, nAddrSubclass)
			If nAddrOriginal <> 0 Then
				nAddrOriginal = 0
				Subclass_Subclass = True 'Success
			End If
		End If
		
		System.Diagnostics.Debug.Assert(Subclass_Subclass, "")
	End Function
	
	'Stop subclassing the window
	Private Function Subclass_UnSubclass() As Boolean
		If hWndSub <> 0 Then
			lngMsgCntA = 0
			lngMsgCntB = 0
			Call Subclass_PatchVal(PATCH_06, lngMsgCntA) 'Patch the TableA entry count to ensure no further Proc callbacks
			Call Subclass_PatchVal(PATCH_09, lngMsgCntB) 'Patch the TableB entry count to ensure no further Proc callbacks
			
			'Restore the original WndProc
			Call api_SetWindowLong(hWndSub, GWL_WNDPROC, nAddrOriginal)
			
			hWndSub = 0 'Indicate the subclasser is inactive
			
			Subclass_UnSubclass = True 'Success
		End If
		
	End Function
	
	'Return the address of the passed function in the passed dll
	Private Function Subclass_AddrFunc(ByVal sDLL As String, ByVal sProc As String) As Integer
		Subclass_AddrFunc = api_GetProcAddress(api_GetModuleHandle(sDLL), sProc)
		
	End Function
	
	'Return the address of the low bound of the passed table array
	Private Function Subclass_AddrMsgTbl(ByRef aMsgTbl() As Integer) As Integer
		On Error Resume Next 'The table may not be dimensioned yet so we need protection
		'UPGRADE_ISSUE: VarPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
        Subclass_AddrMsgTbl = VarPtr.VarPtr(aMsgTbl(1)) 'Get the address of the first element of the passed message table
		On Error GoTo 0 'Switch off error protection
	End Function
	
	'Patch the machine code buffer offset with the relative address to the target address
	Private Sub Subclass_PatchRel(ByVal nOffset As Integer, ByVal nTargetAddr As Integer)
		Call api_CopyMemory(nAddrSubclass + nOffset, nTargetAddr - nAddrSubclass - nOffset - 4, 4)
	End Sub
	
	'Patch the machine code buffer offset with the passed value
	Private Sub Subclass_PatchVal(ByVal nOffset As Integer, ByVal nValue As Integer)
		Call api_CopyMemory(nAddrSubclass + nOffset, nValue, 4)
	End Sub
	
	'Worker function for InIDE - will only be called whilst running in the IDE
	Private Function Subclass_SetTrue(ByRef bValue As Boolean) As Boolean
		Subclass_SetTrue = True
		bValue = True
	End Function
	
	Private Sub Subclass_AddResolveMessage(ByVal lngAsync As Integer, ByVal lngObjectPointer As Integer)
		Dim Count As Integer
		For Count = 1 To lngMsgCntA
			Select Case lngTableA1(Count)
				
				Case -1
					lngTableA1(Count) = lngAsync
					lngTableA2(Count) = lngObjectPointer
					Exit Sub
				Case lngAsync
					Debug.Print("WARNING: Async already registered!")
					Exit Sub
			End Select
		Next Count
		
		lngMsgCntA = lngMsgCntA + 1
		'UPGRADE_WARNING: Lower bound of array lngTableA1 was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		ReDim Preserve lngTableA1(lngMsgCntA)
		'UPGRADE_WARNING: Lower bound of array lngTableA2 was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		ReDim Preserve lngTableA2(lngMsgCntA)
		
		lngTableA1(lngMsgCntA) = lngAsync
		lngTableA2(lngMsgCntA) = lngObjectPointer
		Subclass_PatchTableA()
		
	End Sub
	
	Private Sub Subclass_AddSocketMessage(ByVal lngSocket As Integer, ByVal lngObjectPointer As Integer)
		Dim Count As Integer
		For Count = 1 To lngMsgCntB
			Select Case lngTableB1(Count)
				
				Case -1
					lngTableB1(Count) = lngSocket
					lngTableB2(Count) = lngObjectPointer
					Exit Sub
				Case lngSocket
					Debug.Print("WARNING: Socket already registered!")
					Exit Sub
			End Select
		Next Count
		
		lngMsgCntB = lngMsgCntB + 1
		'UPGRADE_WARNING: Lower bound of array lngTableB1 was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		ReDim Preserve lngTableB1(lngMsgCntB)
		'UPGRADE_WARNING: Lower bound of array lngTableB2 was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		ReDim Preserve lngTableB2(lngMsgCntB)
		
		lngTableB1(lngMsgCntB) = lngSocket
		lngTableB2(lngMsgCntB) = lngObjectPointer
		Subclass_PatchTableB()
		
	End Sub
	
	Private Sub Subclass_DelResolveMessage(ByVal lngAsync As Integer)
		Dim Count As Integer
		For Count = 1 To lngMsgCntA
			If lngTableA1(Count) = lngAsync Then
				lngTableA1(Count) = -1
				lngTableA2(Count) = -1
				Exit Sub
			End If
		Next Count
	End Sub
	
	Private Sub Subclass_DelSocketMessage(ByVal lngSocket As Integer)
		Dim Count As Integer
		For Count = 1 To lngMsgCntB
			If lngTableB1(Count) = lngSocket Then
				lngTableB1(Count) = -1
				lngTableB2(Count) = -1
				Exit Sub
			End If
		Next Count
	End Sub
	
	Private Sub Subclass_PatchTableA()
		Const PATCH_07 As Integer = 114
		Const PATCH_08 As Integer = 130
		
		Call Subclass_PatchVal(PATCH_06, lngMsgCntA)
		Call Subclass_PatchVal(PATCH_07, Subclass_AddrMsgTbl(lngTableA1))
		Call Subclass_PatchVal(PATCH_08, Subclass_AddrMsgTbl(lngTableA2))
	End Sub
	
	Private Sub Subclass_PatchTableB()
		Const PATCH_0A As Integer = 145
		Const PATCH_0B As Integer = 161
		
		Call Subclass_PatchVal(PATCH_09, lngMsgCntB)
		Call Subclass_PatchVal(PATCH_0A, Subclass_AddrMsgTbl(lngTableB1))
		Call Subclass_PatchVal(PATCH_0B, Subclass_AddrMsgTbl(lngTableB2))
	End Sub
	
	Public Sub Subclass_ChangeOwner(ByVal lngSocket As Integer, ByVal lngObjectPointer As Integer)
		Dim Count As Integer
		For Count = 1 To lngMsgCntB
			If lngTableB1(Count) = lngSocket Then
				lngTableB2(Count) = lngObjectPointer
				Exit Sub
			End If
		Next Count
	End Sub
End Module