Option Strict Off
Option Explicit On
Imports System.Text.UnicodeEncoding
Friend Class CSocketMaster

    '********************************************************************************
    '
    'Name.......... CSocketMaster
    'File.......... CSocketMaster.cls
    'Version....... 1.1
    'Dependencies.. Requires modSocketMaster.bas code module
    'Description... Winsock api implementation class
    'Author........ Emiliano Scavuzzo <anshoku@yahoo.com>
    'Date.......... February, 22nd 2004

    'Copyright (c) 2004 by Emiliano Scavuzzo
    'Rosario, Argentina
    '
    'Based on CSocket by Oleg Gdalevich
    'Subclassing based on WinSubHook2 by Paul Caton <Paul_Caton@hotmail.com>
    '
    '********************************************************************************


    '==============================================================================
    'API FUNCTIONS
    '==============================================================================

    Private Declare Function api_socket Lib "ws2_32.dll" Alias "socket" (ByVal af As Integer, ByVal s_type As Integer, ByVal Protocol As Integer) As Integer
    Private Declare Function api_GlobalLock Lib "kernel32" Alias "GlobalLock" (ByVal hMem As Integer) As Integer
    Private Declare Function api_GlobalUnlock Lib "kernel32" Alias "GlobalUnlock" (ByVal hMem As Integer) As Integer
    Private Declare Function api_htons Lib "ws2_32.dll" Alias "htons" (ByVal hostshort As Short) As Short
    Private Declare Function api_ntohs Lib "ws2_32.dll" Alias "ntohs" (ByVal netshort As Short) As Short
    'UPGRADE_WARNING: Structure sockaddr_in may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Private Declare Function api_connect Lib "ws2_32.dll" Alias "connect" (ByVal s As Integer, ByRef name As sockaddr_in, ByVal namelen As Integer) As Integer
    Private Declare Function api_gethostname Lib "ws2_32.dll" Alias "gethostname" (ByVal host_name As String, ByVal namelen As Integer) As Integer
    Private Declare Function api_gethostbyname Lib "ws2_32.dll" Alias "gethostbyname" (ByVal host_name As String) As Integer
    'UPGRADE_WARNING: Structure sockaddr_in may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Private Declare Function api_bind Lib "ws2_32.dll" Alias "bind" (ByVal s As Integer, ByRef name As sockaddr_in, ByRef namelen As Integer) As Integer
    'UPGRADE_WARNING: Structure sockaddr_in may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Private Declare Function api_getsockname Lib "ws2_32.dll" Alias "getsockname" (ByVal s As Integer, ByRef name As sockaddr_in, ByRef namelen As Integer) As Integer
    'UPGRADE_WARNING: Structure sockaddr_in may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Private Declare Function api_getpeername Lib "ws2_32.dll" Alias "getpeername" (ByVal s As Integer, ByRef name As sockaddr_in, ByRef namelen As Integer) As Integer
    Private Declare Function api_inet_addr Lib "ws2_32.dll" Alias "inet_addr" (ByVal cp As String) As Integer
    Private Declare Function api_send Lib "ws2_32.dll" Alias "send" (ByVal s As Integer, ByRef buf As Object, ByVal buflen As Integer, ByVal flags As Integer) As Integer
    'UPGRADE_WARNING: Structure sockaddr_in may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Private Declare Function api_sendto Lib "ws2_32.dll" Alias "sendto" (ByVal s As Integer, ByRef buf As Object, ByVal buflen As Integer, ByVal flags As Integer, ByRef toaddr As sockaddr_in, ByVal tolen As Integer) As Integer
    Private Declare Function api_getsockopt Lib "ws2_32.dll" Alias "getsockopt" (ByVal s As Integer, ByVal level As Integer, ByVal optname As Integer, ByRef optval As Object, ByRef optlen As Integer) As Integer
    Private Declare Function api_setsockopt Lib "ws2_32.dll" Alias "setsockopt" (ByVal s As Integer, ByVal level As Integer, ByVal optname As Integer, ByRef optval As Object, ByVal optlen As Integer) As Integer
    Private Declare Function api_recv Lib "ws2_32.dll" Alias "recv" (ByVal s As Integer, ByRef buf As Object, ByVal buflen As Integer, ByVal flags As Integer) As Integer
    'UPGRADE_WARNING: Structure sockaddr_in may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Private Declare Function api_recvfrom Lib "ws2_32.dll" Alias "recvfrom" (ByVal s As Integer, ByRef buf As Object, ByVal buflen As Integer, ByVal flags As Integer, ByRef from As sockaddr_in, ByRef fromlen As Integer) As Integer
    Private Declare Function api_WSACancelAsyncRequest Lib "ws2_32.dll" Alias "WSACancelAsyncRequest" (ByVal hAsyncTaskHandle As Integer) As Integer
    Private Declare Function api_listen Lib "ws2_32.dll" Alias "listen" (ByVal s As Integer, ByVal backlog As Integer) As Integer
    'UPGRADE_WARNING: Structure sockaddr_in may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Private Declare Function api_accept Lib "ws2_32.dll" Alias "accept" (ByVal s As Integer, ByRef addr As sockaddr_in, ByRef addrlen As Integer) As Integer
    Private Declare Function api_inet_ntoa Lib "ws2_32.dll" Alias "inet_ntoa" (ByVal inn As Integer) As Integer
    Private Declare Function api_gethostbyaddr Lib "ws2_32.dll" Alias "gethostbyaddr" (ByRef addr As Integer, ByVal addr_len As Integer, ByVal addr_type As Integer) As Integer
    Private Declare Function api_ioctlsocket Lib "ws2_32.dll" Alias "ioctlsocket" (ByVal s As Integer, ByVal cmd As Integer, ByRef argp As Integer) As Integer
    Private Declare Function api_closesocket Lib "ws2_32.dll" Alias "closesocket" (ByVal s As Integer) As Integer

    '==============================================================================
    'CONSTANTS
    '==============================================================================
    Public Enum SockState
        sckClosed = 0
        sckOpen
        sckListening
        sckConnectionPending
        sckResolvingHost
        sckHostResolved
        sckConnecting
        sckConnected
        sckClosing
        sckError
    End Enum

    Public Enum DestResolucion 'asynchronic host resolution destination
        destConnect = 0
        'destSendUDP = 1
    End Enum

    Private Const SOMAXCONN As Integer = 5

    Public Enum ProtocolConstants
        sckTCPProtocol = 0
        sckUDPProtocol = 1
    End Enum

    Private Const MSG_PEEK As Integer = &H2

    '==============================================================================
    'EVENTS
    '==============================================================================

    Public Event CloseSck()
    Public Event Connect()
    Public Event ConnectionRequest(ByVal requestID As Integer)
    Public Event DataArrival(ByVal bytesTotal As Integer)
    Public Event Error_Renamed(ByVal Number As Short, ByRef Description As String, ByVal sCode As Integer, ByVal Source As String, ByVal HelpFile As String, ByVal HelpContext As Integer, ByRef CancelDisplay As Boolean)
    Public Event SendComplete()
    Public Event SendProgress(ByVal bytesSent As Integer, ByVal bytesRemaining As Integer)

    '==============================================================================
    'MEMBER VARIABLES
    '==============================================================================
    Private m_lngSocketHandle As Integer 'socket handle
    Private m_enmState As SockState 'socket state
    Private m_strTag As String 'tag
    Private m_strRemoteHost As String 'remote host
    Private m_lngRemotePort As Integer 'remote port
    Private m_strRemoteHostIP As String 'remote host ip
    Private m_lngLocalPort As Integer 'local port
    Private m_lngLocalPortBind As Integer 'temporary local port
    Private m_strLocalIP As String 'local IP
    Private m_enmProtocol As ProtocolConstants 'protocol used (TCP / UDP)

    Private m_lngMemoryPointer As Integer 'memory pointer used as buffer when resolving host
    Private m_lngMemoryHandle As Integer 'buffer memory handle

    Private m_lngSendBufferLen As Integer 'winsock buffer size for sends
    Private m_lngRecvBufferLen As Integer 'winsock buffer size for receives

    Private m_strSendBuffer As String 'local incoming buffer
    Private m_strRecvBuffer As String 'local outgoing buffer

    Private m_blnAcceptClass As Boolean 'if True then this is a Accept socket class
    Private m_colWaitingResolutions As Collection 'hosts waiting to be resolved by the system

    '  ****  WARNING WARNING WARNING WARNING ******
    'This sub MUST be the first on the class. DO NOT attempt
    'to change it's location or the code will CRASH.
    'This sub receives system messages from our WndProc.
    Public Sub WndProc(ByVal hwnd As Integer, ByVal uMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
        Select Case uMsg

            Case RESOLVE_MESSAGE

                PostResolution(wParam, HiWord(lParam))

            Case SOCKET_MESSAGE

                PostSocket(LoWord(lParam), HiWord(lParam))

        End Select
    End Sub

    Private Sub Class_Initialize_Renamed()
        'socket's handle default value
        m_lngSocketHandle = INVALID_SOCKET

        'initiate resolution collection
        m_colWaitingResolutions = New Collection

        'initiate processes and winsock service
        modSocketMaster.InitiateProcesses()
    End Sub
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub

    Private Sub Class_Terminate_Renamed()
        'clean hostname resolution system
        CleanResolutionSystem()

        'destroy socket if it exists
        If Not m_blnAcceptClass Then DestroySocket()

        'clean processes and finish winsock service
        modSocketMaster.FinalizeProcesses()

        'clean resolution collection
        'UPGRADE_NOTE: Object m_colWaitingResolutions may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        m_colWaitingResolutions = Nothing
    End Sub
    Protected Overrides Sub Finalize()
        Class_Terminate_Renamed()
        MyBase.Finalize()
    End Sub

    '==============================================================================
    'PROPERTIES
    '==============================================================================


    Public Property RemotePort() As Integer
        Get
            RemotePort = m_lngRemotePort
        End Get
        Set(ByVal Value As Integer)
            If m_enmProtocol = ProtocolConstants.sckTCPProtocol And m_enmState <> SockState.sckClosed Then
                Err.Raise(sckInvalidOp, "CSocketMaster.RemotePort", "Invalid operation at current state")
            End If

            If Value < 0 Or Value > 65535 Then
                Err.Raise(sckInvalidArg, "CSocketMaster.RemotePort", "The argument passed to a function was not in the correct format or in the specified range.")
            Else
                m_lngRemotePort = Value
            End If
        End Set
    End Property


    Public Property RemoteHost() As String
        Get
            RemoteHost = m_strRemoteHost
        End Get
        Set(ByVal Value As String)
            If m_enmProtocol = ProtocolConstants.sckTCPProtocol And m_enmState <> SockState.sckClosed Then
                Err.Raise(sckInvalidOp, "CSocketMaster.RemoteHost", "Invalid operation at current state")
            End If

            m_strRemoteHost = Value
        End Set
    End Property

    Public ReadOnly Property RemoteHostIP() As String
        Get
            RemoteHostIP = m_strRemoteHostIP
        End Get
    End Property


    Public Property LocalPort() As Integer
        Get
            If m_lngLocalPortBind = 0 Then
                LocalPort = m_lngLocalPort
            Else
                LocalPort = m_lngLocalPortBind
            End If
        End Get
        Set(ByVal Value As Integer)
            If m_enmState <> SockState.sckClosed Then
                Err.Raise(sckInvalidOp, "CSocketMaster.LocalPort", "Invalid operation at current state")
            End If
            If Value < 0 Or Value > 65535 Then
                Err.Raise(sckInvalidArg, "CSocketMaster.LocalPort", "The argument passed to a function was not in the correct format or in the specified range.")
            Else
                m_lngLocalPort = Value
            End If
        End Set
    End Property

    Public ReadOnly Property State() As SockState
        Get
            State = m_enmState
        End Get
    End Property

    Public ReadOnly Property LocalHostName() As String
        Get
            LocalHostName = GetLocalHostName()
        End Get
    End Property

    Public ReadOnly Property LocalIP() As String
        Get
            If m_enmState = SockState.sckOpen Or m_enmState = SockState.sckListening Then
                LocalIP = m_strLocalIP
            Else
                LocalIP = GetLocalIP()
            End If
        End Get
    End Property

    Public ReadOnly Property BytesReceived() As Integer
        Get
            If m_enmProtocol = ProtocolConstants.sckTCPProtocol Then
                BytesReceived = Len(m_strRecvBuffer)
            Else
                BytesReceived = GetBufferLenUDP()
            End If
        End Get
    End Property

    Public ReadOnly Property SocketHandle() As Integer
        Get
            SocketHandle = m_lngSocketHandle
        End Get
    End Property


    Public Property Tag() As String
        Get
            Tag = m_strTag
        End Get
        Set(ByVal Value As String)
            m_strTag = Value
        End Set
    End Property


    Public Property Protocol() As ProtocolConstants
        Get
            Protocol = m_enmProtocol
        End Get
        Set(ByVal Value As ProtocolConstants)
            If m_enmState <> SockState.sckClosed Then
                Err.Raise(sckInvalidOp, "CSocketMaster.Protocol", "Invalid operation at current state")
            Else
                m_enmProtocol = Value
            End If
        End Set
    End Property

    'Destroys the socket if it exists and unregisters it
    'from control list.
    Private Sub DestroySocket()
        Dim lngResult As Integer
        Dim lngErrorCode As Integer
        If Not m_lngSocketHandle = INVALID_SOCKET Then


            lngResult = api_closesocket(m_lngSocketHandle)

            If lngResult = SOCKET_ERROR Then

                m_enmState = SockState.sckError : Debug.Print("STATE: sckError")
                lngErrorCode = Err.LastDllError
                Err.Raise(lngErrorCode, "CSocketMaster.DestroySocket", GetErrorDescription(lngErrorCode))

            Else

                Debug.Print("OK Destroyed socket " & m_lngSocketHandle)
                modSocketMaster.UnregisterSocket(m_lngSocketHandle)
                m_lngSocketHandle = INVALID_SOCKET

            End If

        End If
    End Sub

    Public Sub CloseSck_Renamed()
        If m_lngSocketHandle = INVALID_SOCKET Then Exit Sub

        m_enmState = SockState.sckClosing : Debug.Print("STATE: sckClosing")
        CleanResolutionSystem()
        DestroySocket()

        m_lngLocalPortBind = 0
        m_strRemoteHostIP = ""
        m_strRecvBuffer = ""
        m_strSendBuffer = ""
        m_lngSendBufferLen = 0
        m_lngRecvBufferLen = 0

        m_enmState = SockState.sckClosed : Debug.Print("STATE: sckClosed")

    End Sub

    'Tries to create a socket if there isn't one yet and registers
    'it to the control list.
    'Returns TRUE if it has success
    Private Function SocketExists() As Boolean
        SocketExists = True
        Dim lngResult As Integer
        Dim lngErrorCode As Integer

        'check if there is a socket already
        Dim blnCancelDisplay As Boolean
        If m_lngSocketHandle = INVALID_SOCKET Then

            'decide what kind of socket we are creating, TCP or UDP
            If m_enmProtocol = ProtocolConstants.sckTCPProtocol Then
                lngResult = api_socket(AF_INET, SOCK_STREAM, IPPROTO_TCP)
            Else
                lngResult = api_socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP)
            End If

            If lngResult = INVALID_SOCKET Then

                m_enmState = SockState.sckError : Debug.Print("STATE: sckError")
                Debug.Print("ERROR trying to create socket")
                SocketExists = False
                lngErrorCode = Err.LastDllError
                blnCancelDisplay = True
                RaiseEvent Error_Renamed(lngErrorCode, GetErrorDescription(lngErrorCode), 0, "CSocketMaster.SocketExists", "", 0, blnCancelDisplay)
                If blnCancelDisplay = False Then MsgBox(GetErrorDescription(lngErrorCode), MsgBoxStyle.OkOnly, "CSocketMaster.SocketExists")
            Else

                Debug.Print("OK Created socket: " & lngResult)
                m_lngSocketHandle = lngResult
                'set and get some socket options
                ProcessOptions()
                SocketExists = modSocketMaster.RegisterSocket(m_lngSocketHandle, VarPtr.VarPtr(Me), True)

            End If
        End If
    End Function

    'Tries to connect to RemoteHost if it was passed, or uses
    'm_strRemoteHost instead. If it is a hostname tries to
    'resolve it first.
    Public Sub Connect_Renamed(Optional ByRef RemoteHost As String = Nothing, Optional ByRef RemotePort As Integer = Nothing)
        If m_enmState <> SockState.sckClosed Then
            Err.Raise(sckInvalidOp, "CSocketMaster.Connect", "Invalid operation at current state")
        End If

        If Not IsNothing(RemoteHost) Then
            m_strRemoteHost = CStr(RemoteHost)
        End If

        'for some reason we get a GPF if we try to
        'resolve a null string, so we replace it with
        'an empty string
        If m_strRemoteHost = vbNullString Then
            m_strRemoteHost = ""
        End If

        'check if RemotePort is a number between 1 and 65535
        If Not IsNothing(RemotePort) Then
            If IsNumeric(RemotePort) Then
                If CInt(RemotePort) > 65535 Or CInt(RemotePort) < 1 Then
                    Err.Raise(sckInvalidArg, "CSocketMaster.Connect", "The argument passed to a function was not in the correct format or in the specified range.")
                Else
                    m_lngRemotePort = CInt(RemotePort)
                End If
            Else
                Err.Raise(sckUnsupported, "CSocketMaster.Connect", "Unsupported variant type.")
            End If
        End If

        'create a socket if there isn't one yet
        If Not SocketExists() Then Exit Sub

        'If we are using UDP we just bind the socket and exit
        'silently. Remember UDP is a connectionless protocol.
        If m_enmProtocol = ProtocolConstants.sckUDPProtocol Then
            If BindInternal() Then
                m_enmState = SockState.sckOpen : Debug.Print("STATE: sckOpen")
            End If
            Exit Sub
        End If

        'try to get a 32 bits long that is used to identify a host
        Dim lngAddress As Integer
        lngAddress = ResolveIfHostname(m_strRemoteHost, DestResolucion.destConnect)

        'We've got two options here:
        '1) m_strRemoteHost was an IP, so a resolution wasn't
        '   necessary, and now lngAddress is a 32 bits long and
        '   we proceed to connect.
        '2) m_strRemoteHost was a hostname, so a resolution was
        '   necessary and it's taking place right now. We leave
        '   silently.

        If lngAddress <> VariantType.Null Then
            ConnectToIP(lngAddress, 0)
        End If

    End Sub

    'When the system resolves a hostname in asynchronous way we
    'call this function to decide what to do with the result.
    Private Sub PostResolution(ByVal lngAsynHandle As Integer, ByVal lngErrorCode As Integer)
        If m_enmState <> SockState.sckResolvingHost Then Exit Sub

        Dim enmDestination As DestResolucion

        'find out what the resolution destination was
        'UPGRADE_WARNING: Couldn't resolve default property of object m_colWaitingResolutions.Item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        enmDestination = m_colWaitingResolutions.Item("R" & lngAsynHandle)
        'erase that record from the collection since we won't need it any longer
        m_colWaitingResolutions.Remove("R" & lngAsynHandle)

        Dim udtHostent As HOSTENT
        Dim lngPtrToIP As Integer
        Dim lngRemoteHostAddress As Integer
        Dim Count As Short
        Dim strIpAddress As String
        'UPGRADE_WARNING: Lower bound of array arrIpAddress was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
        Dim arrIpAddress(4) As Byte
        If lngErrorCode = 0 Then 'if there weren't errors trying to resolve the hostname

            m_enmState = SockState.sckHostResolved : Debug.Print("STATE: sckHostResolved")


            'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object udtHostent. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            api_CopyMemory(udtHostent, m_lngMemoryPointer, LenB(udtHostent))
            api_CopyMemory(lngPtrToIP, udtHostent.hAddrList, 4)
            api_CopyMemory(arrIpAddress(1), lngPtrToIP, 4)
            api_CopyMemory(lngRemoteHostAddress, lngPtrToIP, 4)

            'free memmory, won't need it any longer
            FreeMemory()

            'We turn the 32 bits long into a readable string.
            'Note: we don't need this string. I put this here just
            'in case you need it.
            For Count = 1 To 4
                strIpAddress = strIpAddress & arrIpAddress(Count) & "."
            Next

            strIpAddress = Left(strIpAddress, Len(strIpAddress) - 1)

            'Decide what to do with the result according to the destination
            Select Case enmDestination

                Case DestResolucion.destConnect
                    ConnectToIP(lngRemoteHostAddress, 0)

            End Select

        Else 'there were errors trying to resolve the hostname

            'free buffer memory
            FreeMemory()

            Select Case enmDestination

                Case DestResolucion.destConnect
                    ConnectToIP(VariantType.Null, lngErrorCode)

            End Select

        End If
    End Sub

    'This procedure is called by the WindowProc callback function
    'from the modSocketMaster module. The lngEventID argument is an
    'ID of the network event occurred for the socket. The lngErrorCode
    'argument contains an error code only if an error was occurred
    'during an asynchronous execution.
    Private Sub PostSocket(ByVal lngEventID As Integer, ByVal lngErrorCode As Integer)

        'handle any possible error
        Dim blnCancelDisplay As Boolean
        If lngErrorCode <> 0 Then
            m_enmState = SockState.sckError : Debug.Print("STATE: sckError")
            blnCancelDisplay = True
            RaiseEvent Error_Renamed(lngErrorCode, GetErrorDescription(lngErrorCode), 0, "CSocketMaster.PostSocket", "", 0, blnCancelDisplay)
            If blnCancelDisplay = False Then MsgBox(GetErrorDescription(lngErrorCode), MsgBoxStyle.OkOnly, "CSocketMaster.PostSocket")
            Exit Sub
        End If

        'UPGRADE_WARNING: Arrays in structure udtSockAddr may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        Dim udtSockAddr As sockaddr_in
        Dim lngResult As Integer
        Dim lngBytesReceived As Integer

        Dim lngTempRP As Integer
        Dim strTempRHIP As String
        Dim strTempRH As String
        Select Case lngEventID

            '======================================================================

            Case FD_CONNECT

                'Arrival of this message means that the connection initiated by the call
                'of the connect Winsock API function was successfully established.

                Debug.Print("FD_CONNECT " & m_lngSocketHandle)

                If m_enmState <> SockState.sckConnecting Then
                    Debug.Print("WARNING: Omitting FD_CONNECT")
                    Exit Sub
                End If

                'Get the connection local end-point parameters
                'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
                lngResult = api_getpeername(m_lngSocketHandle, udtSockAddr, LenB(udtSockAddr))

                If lngResult = 0 Then
                    m_lngRemotePort = modSocketMaster.IntegerToUnsigned(api_ntohs(udtSockAddr.sin_port))
                    m_strRemoteHostIP = StringFromPointer(api_inet_ntoa(udtSockAddr.sin_addr))
                End If

                m_enmState = SockState.sckConnected : Debug.Print("STATE: sckConnected")
                RaiseEvent Connect()

                '======================================================================

            Case FD_WRITE

                'This message means that the socket in a write-able
                'state, that is, buffer for outgoing data of the transport
                'service is empty and ready to receive data to send through
                'the network.

                Debug.Print("FD_WRITE " & m_lngSocketHandle)

                If m_enmState <> SockState.sckConnected Then
                    Debug.Print("WARNING: Omitting FD_WRITE")
                    Exit Sub
                End If

                If Len(m_strSendBuffer) > 0 Then
                    SendBufferedData()
                End If

                '======================================================================

            Case FD_READ

                'Some data has arrived for this socket.

                Debug.Print("FD_READ " & m_lngSocketHandle)

                If m_enmProtocol = ProtocolConstants.sckTCPProtocol Then

                    If m_enmState <> SockState.sckConnected Then
                        Debug.Print("WARNING: Omitting FD_READ")
                        Exit Sub
                    End If

                    'Call the RecvDataToBuffer function that move arrived data
                    'from the Winsock buffer to the local one and returns number
                    'of bytes received.

                    lngBytesReceived = RecvDataToBuffer()

                    If lngBytesReceived > 0 Then
                        RaiseEvent DataArrival(Len(m_strRecvBuffer))
                    End If

                Else 'UDP protocol

                    If m_enmState <> SockState.sckOpen Then
                        Debug.Print("WARNING: Omitting FD_READ")
                        Exit Sub
                    End If

                    'If we use UDP we don't remove data from winsock buffer.
                    'We just let the user know the amount received so
                    'he/she can decide what to do.

                    lngBytesReceived = GetBufferLenUDP()

                    If lngBytesReceived > 0 Then
                        RaiseEvent DataArrival(lngBytesReceived)
                    End If


                    'Now the buffer is emptied no matter what the user
                    'dicided to do with the received data
                    EmptyBuffer()
                End If


                '======================================================================

            Case FD_ACCEPT

                'When the socket is in a listening state, arrival of this message
                'means that a connection request was received. Call the accept
                'Winsock API function in oreder to create a new socket for the
                'requested connection.

                Debug.Print("FD_ACCEPT " & m_lngSocketHandle)
                If m_enmState <> SockState.sckListening Then
                    Debug.Print("WARNING: Omitting FD_ACCEPT")
                    Exit Sub
                End If

                'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
                lngResult = api_accept(m_lngSocketHandle, udtSockAddr, LenB(udtSockAddr))

                If lngResult = INVALID_SOCKET Then
                    lngErrorCode = Err.LastDllError
                    Err.Raise(lngErrorCode, "CSocketMaster.PostSocket", GetErrorDescription(lngErrorCode))
                Else
                    'We assign a temporal instance of CSocketMaster to
                    'handle this new socket until user accepts (or not)
                    'the new connection
                    modSocketMaster.RegisterAccept(lngResult)

                    'We change remote info before firing ConnectionRequest
                    'event so the user can see which host is trying to
                    'connect.

                    lngTempRP = m_lngRemotePort
                    strTempRHIP = m_strRemoteHostIP
                    strTempRH = m_strRemoteHost

                    GetRemoteInfo(lngResult, m_lngRemotePort, m_strRemoteHostIP, m_strRemoteHost)

                    Debug.Print("OK Accepted socket: " & lngResult)
                    RaiseEvent ConnectionRequest(lngResult)

                    'we return original info
                    If m_enmState = SockState.sckListening Then
                        m_lngRemotePort = lngTempRP
                        m_strRemoteHostIP = strTempRHIP
                        m_strRemoteHost = strTempRH
                    End If

                    'This is very important. If the connection wasn't accepted
                    'we must close the socket.
                    If IsAcceptRegistered(lngResult) Then
                        api_closesocket(lngResult)
                        modSocketMaster.UnregisterSocket(lngResult)
                        modSocketMaster.UnregisterAccept(lngResult)
                        Debug.Print("OK Closed accepted socket: " & lngResult)
                    End If
                End If

                '======================================================================

            Case FD_CLOSE

                'This message means that the remote host is closing the conection

                Debug.Print("FD_CLOSE " & m_lngSocketHandle)

                If m_enmState <> SockState.sckConnected Then
                    Debug.Print("WARNING: Omitting FD_CLOSE")
                    Exit Sub
                End If

                m_enmState = SockState.sckClosing : Debug.Print("STATE: sckClosing")
                RaiseEvent CloseSck()

        End Select
    End Sub

    'Connect to a given 32 bits long ip
    Private Sub ConnectToIP(ByVal lngRemoteHostAddress As Integer, ByVal lngErrorCode As Integer)

        Dim blnCancelDisplay As Boolean

        'Check and handle errors
        If lngErrorCode <> 0 Then
            m_enmState = SockState.sckError : Debug.Print("STATE: sckError")
            blnCancelDisplay = True
            RaiseEvent Error_Renamed(lngErrorCode, GetErrorDescription(lngErrorCode), 0, "CSocketMaster.ConnectToIP", "", 0, blnCancelDisplay)
            If blnCancelDisplay = False Then MsgBox(GetErrorDescription(lngErrorCode), MsgBoxStyle.OkOnly, "CSocketMaster.ConnectToIP")
            Exit Sub
        End If

        'Here we bind the socket
        If Not BindInternal() Then Exit Sub

        Debug.Print("OK Connecting to: " & m_strRemoteHost & " " & m_strRemoteHostIP)
        m_enmState = SockState.sckConnecting : Debug.Print("STATE: sckConnecting")

        'UPGRADE_WARNING: Arrays in structure udtSockAddr may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        Dim udtSockAddr As sockaddr_in
        Dim lngResult As Integer

        'Build the sockaddr_in structure to pass it to the connect
        'Winsock API function as an address of the remote host.
        With udtSockAddr
            .sin_addr = lngRemoteHostAddress
            .sin_family = AF_INET
            .sin_port = api_htons(modSocketMaster.UnsignedToInteger(m_lngRemotePort))
        End With

        'Call the connect Winsock API function in order to establish connection.
        'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
        lngResult = api_connect(m_lngSocketHandle, udtSockAddr, LenB(udtSockAddr))

        'Check and handle errors
        If lngResult = SOCKET_ERROR Then
            lngErrorCode = Err.LastDllError
            If lngErrorCode <> WSAEWOULDBLOCK Then
                If lngErrorCode = WSAEADDRNOTAVAIL Then
                    Err.Raise(WSAEADDRNOTAVAIL, "CSocketMaster.ConnectToIP", GetErrorDescription(WSAEADDRNOTAVAIL))
                Else
                    m_enmState = SockState.sckError : Debug.Print("STATE: sckError")
                    blnCancelDisplay = True
                    RaiseEvent Error_Renamed(lngErrorCode, GetErrorDescription(lngErrorCode), 0, "CSocketMaster.ConnectToIP", "", 0, blnCancelDisplay)
                    If blnCancelDisplay = False Then MsgBox(GetErrorDescription(lngErrorCode), MsgBoxStyle.OkOnly, "CSocketMaster.ConnectToIP")
                End If
            End If
        End If

    End Sub

    Public Sub Bind(Optional ByRef LocalPort As Integer = Nothing, Optional ByRef LocalIP As String = Nothing)
        If m_enmState <> SockState.sckClosed Then
            Err.Raise(sckInvalidOp, "CSocketMaster.Bind", "Invalid operation at current state")
        End If

        If BindInternal(LocalPort, LocalIP) Then
            m_enmState = SockState.sckOpen : Debug.Print("STATE: sckOpen")
        End If
    End Sub

    'This function binds a socket to a local port and IP.
    'Retunrs TRUE if it has success.
    Private Function BindInternal(Optional ByVal varLocalPort As Integer = Nothing, Optional ByVal varLocalIP As String = Nothing) As Boolean
        If m_enmState = SockState.sckOpen Then
            BindInternal = True
            Exit Function
        End If

        Dim lngLocalPortInternal As Integer
        Dim strLocalHostInternal As String
        Dim strIP As String
        Dim lngAddressInternal As Integer
        Dim lngResult As Integer
        Dim lngErrorCode As Integer

        BindInternal = False

        'Check if varLocalPort is a number between 0 and 65535
        If Not IsNothing(varLocalPort) Then

            If IsNumeric(varLocalPort) Then
                If varLocalPort < 0 Or varLocalPort > 65535 Then
                    BindInternal = False
                    Err.Raise(sckInvalidArg, "CSocketMaster.BindInternal", "The argument passed to a function was not in the correct format or in the specified range.")
                Else
                    lngLocalPortInternal = CInt(varLocalPort)
                End If
            Else
                BindInternal = False
                Err.Raise(sckUnsupported, "CSocketMaster.BindInternal", "Unsupported variant type.")
            End If

        Else

            lngLocalPortInternal = m_lngLocalPort

        End If

        If Not IsNothing(varLocalIP) Then
            If varLocalIP <> vbNullString Then
                strLocalHostInternal = CStr(varLocalIP)
            Else
                strLocalHostInternal = GetLocalIP()
            End If
        Else
            strLocalHostInternal = GetLocalIP()
        End If

        'get a 32 bits long IP
        lngAddressInternal = ResolveIfHostnameSync(strLocalHostInternal, strIP, lngResult)

        If lngResult <> 0 Then
            Err.Raise(sckInvalidArg, "CSocketMaster.BindInternal", "Invalid argument")
        End If

        'create a socket if there isn't one yet
        If Not SocketExists() Then Exit Function

        'UPGRADE_WARNING: Arrays in structure udtSockAddr may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        Dim udtSockAddr As sockaddr_in

        With udtSockAddr
            .sin_addr = lngAddressInternal
            .sin_family = AF_INET
            .sin_port = api_htons(modSocketMaster.UnsignedToInteger(lngLocalPortInternal))
        End With

        'bind the socket
        lngResult = api_bind(m_lngSocketHandle, udtSockAddr, LenB(udtSockAddr))

        If lngResult = SOCKET_ERROR Then

            lngErrorCode = Err.LastDllError
            Err.Raise(lngErrorCode, "CSocketMaster.BindInternal", GetErrorDescription(lngErrorCode))

        Else

            m_strLocalIP = strIP

            If lngLocalPortInternal <> 0 Then

                Debug.Print("OK Bind HOST: " & strLocalHostInternal & " PORT: " & lngLocalPortInternal)
                m_lngLocalPort = lngLocalPortInternal

            Else
                lngResult = GetLocalPort(m_lngSocketHandle)

                If lngResult = SOCKET_ERROR Then
                    lngErrorCode = Err.LastDllError
                    Err.Raise(lngErrorCode, "CSocketMaster.BindInternal", GetErrorDescription(lngErrorCode))
                Else
                    Debug.Print("OK Bind HOST: " & strLocalHostInternal & " PORT: " & lngResult)
                    m_lngLocalPortBind = lngResult
                End If

            End If

            BindInternal = True
        End If
    End Function

    'Allocate some memory for HOSTEN structure and returns
    'a pointer to this buffer if no error occurs.
    'Returns 0 if it fails.
    Private Function AllocateMemory() As Integer
        m_lngMemoryHandle = api_GlobalAlloc(GMEM_FIXED, MAXGETHOSTSTRUCT)

        If m_lngMemoryHandle <> 0 Then
            m_lngMemoryPointer = api_GlobalLock(m_lngMemoryHandle)

            If m_lngMemoryPointer <> 0 Then
                api_GlobalUnlock(m_lngMemoryHandle)
                AllocateMemory = m_lngMemoryPointer
            Else
                api_GlobalFree(m_lngMemoryHandle)
                AllocateMemory = m_lngMemoryPointer '0
            End If

        Else
            AllocateMemory = m_lngMemoryHandle '0
        End If
    End Function

    'Free memory allocated by AllocateMemory
    Private Sub FreeMemory()
        If m_lngMemoryHandle <> 0 Then
            m_lngMemoryHandle = 0
            m_lngMemoryPointer = 0
            api_GlobalFree(m_lngMemoryHandle)
        End If
    End Sub

    Private Function GetLocalHostName() As String
        Dim strHostNameBuf As String
        Dim lngResult As Integer

        lngResult = api_gethostname(strHostNameBuf, LOCAL_HOST_BUFF)

        Dim lngErrorCode As Integer
        If lngResult = SOCKET_ERROR Then
            GetLocalHostName = vbNullString
            lngErrorCode = Err.LastDllError
            Err.Raise(lngErrorCode, "CSocketMaster.GetLocalHostName", GetErrorDescription(lngErrorCode))
        Else
            GetLocalHostName = Left(strHostNameBuf, InStr(1, strHostNameBuf, Chr(0)) - 1)
        End If
    End Function

    Private Function GetLocalIP() As String
        Dim lngResult As Integer
        Dim lngPtrToIP As Integer
        Dim strLocalHost As String
        Dim arrIpAddress(4) As Byte
        Dim Count As Short
        Dim udtHostent As HOSTENT
        Dim strIpAddress As String

        strLocalHost = GetLocalHostName()

        lngResult = api_gethostbyname(strLocalHost)

        Dim lngErrorCode As Integer
        If lngResult = 0 Then
            GetLocalIP = vbNullString
            lngErrorCode = Err.LastDllError
            Err.Raise(lngErrorCode, "CSocketMaster.GetLocalIP", GetErrorDescription(lngErrorCode))
        Else
            api_CopyMemory(udtHostent, lngResult, LenB(udtHostent))
            api_CopyMemory(lngPtrToIP, udtHostent.hAddrList, 4)
            api_CopyMemory(arrIpAddress(1), lngPtrToIP, 4)

            For Count = 1 To 4
                strIpAddress = strIpAddress & arrIpAddress(Count) & "."
            Next

            strIpAddress = Left(strIpAddress, Len(strIpAddress) - 1)
            GetLocalIP = strIpAddress
        End If
    End Function

    'If Host is an IP doesn't resolve anything and returns a
    'a 32 bits long IP.
    'If Host isn't an IP then returns vbNull, tries to resolve it
    'in asynchronous way and acts according to enmDestination.
    Private Function ResolveIfHostname(ByVal Host As String, ByVal enmDestination As DestResolucion) As Integer
        Dim lngAddress As Integer
        lngAddress = api_inet_addr(Host)

        Dim lngAsynHandle As Integer
        Dim lngErrorCode As Integer
        Dim blnCancelDisplay As Boolean
        If lngAddress = INADDR_NONE Then 'if Host isn't an IP

            ResolveIfHostname = VariantType.Null
            m_enmState = SockState.sckResolvingHost : Debug.Print("STATE: sckResolvingHost")

            If AllocateMemory() Then

                'UPGRADE_ISSUE: ObjPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
                lngAsynHandle = modSocketMaster.ResolveHost(Host, m_lngMemoryPointer, VarPtr.VarPtr(Me))

                If lngAsynHandle = 0 Then
                    FreeMemory()
                    m_enmState = SockState.sckError : Debug.Print("STATE: sckError")
                    lngErrorCode = Err.LastDllError
                    blnCancelDisplay = True
                    RaiseEvent Error_Renamed(lngErrorCode, GetErrorDescription(lngErrorCode), 0, "CSocketMaster.ResolveIfHostname", "", 0, blnCancelDisplay)
                    If blnCancelDisplay = False Then MsgBox(GetErrorDescription(lngErrorCode), MsgBoxStyle.OkOnly, "CSocketMaster.ResolveIfHostname")
                Else
                    m_colWaitingResolutions.Add(enmDestination, "R" & lngAsynHandle)
                    Debug.Print("Resolving host " & Host & " with handle " & lngAsynHandle)
                End If

            Else

                m_enmState = SockState.sckError : Debug.Print("STATE: sckError")
                Debug.Print("Error trying to allocate memory")
                Err.Raise(sckOutOfMemory, "CSocketMaster.ResolveIfHostname", "Out of memory")

            End If

        Else 'if Host is an IP doen't need to resolve anything
            ResolveIfHostname = lngAddress
        End If
    End Function

    'Resolves a hots (if necessary) in synchronous way
    'If succeeds returns a 32 bits long IP,
    'strHostIP = readable IP string and lngErrorCode = 0
    'If fails returns vbNull,
    'strHostIP = vbNullString and lngErrorCode <> 0
    Private Function ResolveIfHostnameSync(ByVal Host As String, ByRef strHostIP As String, ByRef lngErrorCode As Integer) As Integer
        Dim lngPtrToHOSTENT As Integer
        Dim udtHostent As HOSTENT
        Dim lngAddress As Integer
        Dim lngPtrToIP As Integer
        Dim arrIpAddress(4) As Byte
        Dim Count As Short

        If Host = vbNullString Then
            strHostIP = vbNullString
            lngErrorCode = WSAEAFNOSUPPORT
            ResolveIfHostnameSync = VariantType.Null
            Exit Function
        End If

        lngAddress = api_inet_addr(Host)

        If lngAddress = INADDR_NONE Then 'if Host isn't an IP

            lngPtrToHOSTENT = api_gethostbyname(Host)

            If lngPtrToHOSTENT = 0 Then
                lngErrorCode = Err.LastDllError
                strHostIP = vbNullString
                ResolveIfHostnameSync = VariantType.Null
            Else
                api_CopyMemory(udtHostent, lngPtrToHOSTENT, LenB(udtHostent))
                api_CopyMemory(lngPtrToIP, udtHostent.hAddrList, 4)
                api_CopyMemory(arrIpAddress(1), lngPtrToIP, 4)
                api_CopyMemory(lngAddress, lngPtrToIP, 4)

                For Count = 1 To 4
                    strHostIP = strHostIP & arrIpAddress(Count) & "."
                Next

                strHostIP = Left(strHostIP, Len(strHostIP) - 1)

                lngErrorCode = 0
                ResolveIfHostnameSync = lngAddress
            End If

        Else 'if Host is an IP doen't need to resolve anything

            lngErrorCode = 0
            strHostIP = Host
            ResolveIfHostnameSync = lngAddress

        End If
    End Function

    'Returns local port from a connected or bound socket.
    'Returns SOCKET_ERROR if fails.
    Private Function GetLocalPort(ByVal lngSocket As Integer) As Integer
        Dim udtSockAddr As sockaddr_in
        Dim lngResult As Integer

        lngResult = api_getsockname(lngSocket, udtSockAddr, LenB(udtSockAddr))

        If lngResult = SOCKET_ERROR Then
            GetLocalPort = SOCKET_ERROR
        Else
            GetLocalPort = modSocketMaster.IntegerToUnsigned(api_ntohs(udtSockAddr.sin_port))
        End If
    End Function

    Public Sub SendData(ByRef data As Object)

        Dim arrData() As Byte 'We store the data here before send it

        If m_enmProtocol = ProtocolConstants.sckTCPProtocol Then
            If m_enmState <> SockState.sckConnected Then
                Err.Raise(sckBadState, "CSocketMaster.SendData", "Wrong protocol or connection state for the requested transaction or request")
                Exit Sub
            End If
        Else 'If we use UDP we create a socket if there isn't one yet
            If Not SocketExists() Then Exit Sub
            If Not BindInternal() Then Exit Sub
            m_enmState = SockState.sckOpen : Debug.Print("STATE: sckOpen")
        End If

        'We need to convert data variant into a byte array
        Dim strdata As String
        Dim strArray As String
        Dim blnData As Boolean
        Dim bytData As Byte
        Dim curData As Decimal
        Dim datData As Date
        Dim dblData As Double
        Dim intData As Short
        Dim lngData As Integer
        Dim sngData As Single
        Select Case VarType(data)
            Case VariantType.String
                strdata = CStr(data)
                If Len(strdata) = 0 Then Exit Sub
                ReDim arrData(Len(strdata) - 1)
                arrData = System.Text.UnicodeEncoding.Unicode.GetBytes(strdata)
            Case VariantType.Array + VariantType.Byte
                strArray = Unicode.GetString(data)
                If Len(strArray) = 0 Then Exit Sub
                arrData = Unicode.GetBytes(strArray)
            Case VariantType.Boolean
                blnData = CBool(data)
                ReDim arrData(LenB(blnData) - 1)
                api_CopyMemory(arrData(0), blnData, LenB(blnData))
            Case VariantType.Byte
                bytData = CByte(data)
                ReDim arrData(LenB(bytData) - 1)
                api_CopyMemory(arrData(0), bytData, LenB(bytData))
            Case VariantType.Decimal
                curData = CDec(data)
                ReDim arrData(LenB(curData) - 1)
                api_CopyMemory(arrData(0), curData, LenB(curData))
            Case VariantType.Date
                datData = CDate(data)
                ReDim arrData(LenB(datData) - 1)
                api_CopyMemory(arrData(0), datData, LenB(datData))
            Case VariantType.Double
                dblData = CDbl(data)
                ReDim arrData(LenB(dblData) - 1)
                api_CopyMemory(arrData(0), dblData, LenB(dblData))
            Case VariantType.Short
                intData = CShort(data)
                ReDim arrData(LenB(intData) - 1)
                api_CopyMemory(arrData(0), intData, LenB(intData))
            Case VariantType.Integer
                lngData = CInt(data)
                ReDim arrData(LenB(lngData) - 1)
                api_CopyMemory(arrData(0), lngData, LenB(lngData))
            Case VariantType.Single
                sngData = CSng(data)
                ReDim arrData(LenB(sngData) - 1)
                api_CopyMemory(arrData(0), sngData, LenB(sngData))
            Case Else
                Err.Raise(sckUnsupported, "CSocketMaster.SendData", "Unsupported variant type.")
        End Select

        'if there's already something in the buffer that means we are
        'already sending data, so we put the new data in the buffer
        'and exit silently
        If Len(m_strSendBuffer) > 0 Then
            m_strSendBuffer = m_strSendBuffer & Unicode.GetString(arrData)

            Exit Sub
        Else
            m_strSendBuffer = m_strSendBuffer & Unicode.GetString(arrData)
        End If

        'send the data
        SendBufferedData()

    End Sub

    'Check which protocol we are using to decide which
    'function should handle the data sending.
    Private Sub SendBufferedData()
        If m_enmProtocol = ProtocolConstants.sckTCPProtocol Then
            SendBufferedDataTCP()
        Else
            SendBufferedDataUDP()
        End If
    End Sub

    'Send buffered data if we are using UDP protocol.
    Private Sub SendBufferedDataUDP()
        Dim lngAddress As Integer
        Dim udtSockAddr As sockaddr_in
        Dim arrData() As Byte
        Dim lngBufferLength As Integer
        Dim lngResult As Integer
        Dim lngErrorCode As Integer

        Dim strTemp As String
        lngAddress = ResolveIfHostnameSync(m_strRemoteHost, strTemp, lngErrorCode)

        If lngErrorCode <> 0 Then
            m_strSendBuffer = ""

            If lngErrorCode = WSAEAFNOSUPPORT Then
                Err.Raise(lngErrorCode, "CSocketMaster.SendBufferedDataUDP", GetErrorDescription(lngErrorCode))
            Else
                Err.Raise(sckInvalidArg, "CSocketMaster.SendBufferedDataUDP", "Invalid argument")
            End If
        End If

        With udtSockAddr
            .sin_addr = lngAddress
            .sin_family = AF_INET
            .sin_port = api_htons(modSocketMaster.UnsignedToInteger(m_lngRemotePort))
        End With

        lngBufferLength = Len(m_strSendBuffer)

        arrData = System.Text.UnicodeEncoding.Unicode.GetBytes(m_strSendBuffer)

        m_strSendBuffer = ""

        lngResult = api_sendto(m_lngSocketHandle, arrData(0), lngBufferLength, 0, udtSockAddr, LenB(udtSockAddr))

        Dim blnCancelDisplay As Boolean
        If lngResult = SOCKET_ERROR Then
            lngErrorCode = Err.LastDllError
            m_enmState = SockState.sckError : Debug.Print("STATE: sckError")
            blnCancelDisplay = True
            RaiseEvent Error_Renamed(lngErrorCode, GetErrorDescription(lngErrorCode), 0, "CSocketMaster.SendBufferedDataUDP", "", 0, blnCancelDisplay)
            If blnCancelDisplay = False Then MsgBox(GetErrorDescription(lngErrorCode), MsgBoxStyle.OkOnly, "CSocketMaster.SendBufferedDataUDP")
        End If

    End Sub

    'Send buffered data if we are using TCP protocol.
    Private Sub SendBufferedDataTCP()

        Dim arrData() As Byte
        Dim lngBufferLength As Integer
        Dim lngResult As Integer
        Dim lngTotalSent As Integer

        Dim lngErrorCode As Integer
        Dim blnCancelDisplay As Boolean
        Dim lngTemp As Integer
        Do Until lngResult = SOCKET_ERROR Or Len(m_strSendBuffer) = 0

            lngBufferLength = Len(m_strSendBuffer)

            If lngBufferLength > m_lngSendBufferLen Then
                lngBufferLength = m_lngSendBufferLen
                arrData = Unicode.GetBytes(Left(m_strSendBuffer, m_lngSendBufferLen))
            Else
                arrData = Unicode.GetBytes(m_strSendBuffer)
            End If

            lngResult = api_send(m_lngSocketHandle, arrData(0), lngBufferLength, 0)

            If lngResult = SOCKET_ERROR Then
                lngErrorCode = Err.LastDllError

                If lngErrorCode = WSAEWOULDBLOCK Then
                    Debug.Print("WARNING: Send buffer full, waiting...")
                    If lngTotalSent > 0 Then RaiseEvent SendProgress(lngTotalSent, Len(m_strSendBuffer))
                Else
                    m_enmState = SockState.sckError : Debug.Print("STATE: sckError")
                    blnCancelDisplay = True
                    RaiseEvent Error_Renamed(lngErrorCode, GetErrorDescription(lngErrorCode), 0, "CSocketMaster.SendBufferedData", "", 0, blnCancelDisplay)
                    If blnCancelDisplay = False Then MsgBox(GetErrorDescription(lngErrorCode), MsgBoxStyle.OkOnly, "CSocketMaster.SendBufferedData")
                End If

            Else
                Debug.Print("OK Bytes sent: " & lngResult)
                lngTotalSent = lngTotalSent + lngResult
                If Len(m_strSendBuffer) > lngResult Then
                    m_strSendBuffer = Mid(m_strSendBuffer, lngResult + 1)
                Else
                    Debug.Print("OK Finished SENDING")
                    m_strSendBuffer = ""
                    lngTemp = lngTotalSent
                    lngTotalSent = 0
                    RaiseEvent SendProgress(lngTemp, 0)
                    RaiseEvent SendComplete()
                End If
            End If

        Loop

    End Sub

    'This function retrieves data from the Winsock buffer
    'into the class local buffer. The function returns number
    'of bytes retrieved (received).
    Private Function RecvDataToBuffer() As Integer
        Dim arrBuffer() As Byte
        Dim lngBytesReceived As Integer
        Dim strBuffTemporal As String

        ReDim arrBuffer(m_lngRecvBufferLen - 1)

        lngBytesReceived = api_recv(m_lngSocketHandle, arrBuffer(0), m_lngRecvBufferLen, 0)

        Dim lngErrorCode As Integer
        If lngBytesReceived = SOCKET_ERROR Then

            m_enmState = SockState.sckError : Debug.Print("STATE: sckError")
            lngErrorCode = Err.LastDllError
            Err.Raise(lngErrorCode, "CSocketMaster.RecvDataToBuffer", GetErrorDescription(lngErrorCode))

        ElseIf lngBytesReceived > 0 Then

            strBuffTemporal = Unicode.GetString(arrBuffer)
            m_strRecvBuffer = m_strRecvBuffer & Left(strBuffTemporal, lngBytesReceived)
            RecvDataToBuffer = lngBytesReceived

        End If

    End Function

    'Retrieves some socket options.
    'If it is an UDP socket also sets SO_BROADCAST option.
    Private Sub ProcessOptions()
        Dim lngResult As Integer
        Dim lngBuffer As Integer
        Dim lngErrorCode As Integer

        If m_enmProtocol = ProtocolConstants.sckTCPProtocol Then
            lngResult = api_getsockopt(m_lngSocketHandle, SOL_SOCKET, SO_RCVBUF, lngBuffer, LenB(lngBuffer))

            If lngResult = SOCKET_ERROR Then
                lngErrorCode = Err.LastDllError
                Err.Raise(lngErrorCode, "CSocketMaster.ProcessOptions", GetErrorDescription(lngErrorCode))
            Else
                m_lngRecvBufferLen = lngBuffer
            End If

            lngResult = api_getsockopt(m_lngSocketHandle, SOL_SOCKET, SO_SNDBUF, lngBuffer, LenB(lngBuffer))

            If lngResult = SOCKET_ERROR Then
                lngErrorCode = Err.LastDllError
                Err.Raise(lngErrorCode, "CSocketMaster.ProcessOptions", GetErrorDescription(lngErrorCode))
            Else
                m_lngSendBufferLen = lngBuffer
            End If

        Else
            lngBuffer = 1
            lngResult = api_setsockopt(m_lngSocketHandle, SOL_SOCKET, SO_BROADCAST, lngBuffer, LenB(lngBuffer))

            lngResult = api_getsockopt(m_lngSocketHandle, SOL_SOCKET, SO_MAX_MSG_SIZE, lngBuffer, LenB(lngBuffer))

            If lngResult = SOCKET_ERROR Then
                lngErrorCode = Err.LastDllError
                Err.Raise(lngErrorCode, "CSocketMaster.ProcessOptions", GetErrorDescription(lngErrorCode))
            Else
                m_lngRecvBufferLen = lngBuffer
                m_lngSendBufferLen = lngBuffer
            End If
        End If


        Debug.Print("Winsock buffer size for sends: " & m_lngRecvBufferLen)
        Debug.Print("Winsock buffer size for receives: " & m_lngSendBufferLen)
    End Sub

    Public Sub GetData(ByRef data As String, Optional ByRef varType_Renamed As Object = Nothing, Optional ByRef maxLen As Integer = Nothing)

        If m_enmProtocol = ProtocolConstants.sckTCPProtocol Then
            If m_enmState <> SockState.sckConnected And Not m_blnAcceptClass Then
                Err.Raise(sckBadState, "CSocketMaster.GetData", "Wrong protocol or connection state for the requested transaction or request")
                Exit Sub
            End If
        Else
            If m_enmState <> SockState.sckOpen Then
                Err.Raise(sckBadState, "CSocketMaster.GetData", "Wrong protocol or connection state for the requested transaction or request")
                Exit Sub
            End If
            If GetBufferLenUDP() = 0 Then Exit Sub
        End If

        If Not IsNothing(maxLen) Then
            If IsNumeric(maxLen) Then
                If CInt(maxLen) < 0 Then
                    Err.Raise(sckInvalidArg, "CSocketMaster.GetData", "The argument passed to a function was not in the correct format or in the specified range.")
                End If
            Else
                If m_enmProtocol = ProtocolConstants.sckTCPProtocol Then
                    maxLen = Len(m_strRecvBuffer)
                Else
                    maxLen = GetBufferLenUDP()
                End If
            End If
        End If

        Dim lngBytesRecibidos As Integer

        lngBytesRecibidos = RecvData(data, False, varType_Renamed, maxLen)
        Debug.Print("OK Bytes obtained from buffer: " & lngBytesRecibidos)

    End Sub

    Public Sub PeekData(ByRef data As String, Optional ByRef varType_Renamed As Object = Nothing, Optional ByRef maxLen As Integer = Nothing)

        If m_enmProtocol = ProtocolConstants.sckTCPProtocol Then
            If m_enmState <> SockState.sckConnected Then
                Err.Raise(sckBadState, "CSocketMaster.PeekData", "Wrong protocol or connection state for the requested transaction or request")
                Exit Sub
            End If
        Else
            If m_enmState <> SockState.sckOpen Then
                Err.Raise(sckBadState, "CSocketMaster.PeekData", "Wrong protocol or connection state for the requested transaction or request")
                Exit Sub
            End If
            If GetBufferLenUDP() = 0 Then Exit Sub
        End If

        If Not IsNothing(maxLen) Then
            If IsNumeric(maxLen) Then
                If CInt(maxLen) < 0 Then
                    Err.Raise(sckInvalidArg, "CSocketMaster.PeekData", "The argument passed to a function was not in the correct format or in the specified range.")
                End If
            Else
                If m_enmProtocol = ProtocolConstants.sckTCPProtocol Then
                    maxLen = Len(m_strRecvBuffer)
                Else
                    maxLen = GetBufferLenUDP()
                End If
            End If
        End If

        Dim lngBytesRecibidos As Integer

        lngBytesRecibidos = RecvData(data, True, varType_Renamed, maxLen)
        Debug.Print("OK Bytes obtained from buffer: " & lngBytesRecibidos)
    End Sub


    'This function is to retrieve data from the buffer. If we are using TCP
    'then the data is retrieved from a local buffer (m_strRecvBuffer). If we
    'are using UDP the data is retrieved from winsock buffer.
    'It can be called by two public methods of the class - GetData and PeekData.
    'Behavior of the function is defined by the blnPeek argument. If a value of
    'that argument is TRUE, the function returns number of bytes in the
    'buffer, and copy data from that buffer into the data argument.
    'If a value of the blnPeek is FALSE, then this function returns number of
    'bytes received, and move data from the buffer into the data
    'argument. MOVE means that data will be removed from the buffer.
    Private Function RecvData(ByRef data As String, ByVal blnPeek As Boolean, Optional ByRef varClass As Object = Nothing, Optional ByRef maxLen As Integer = Nothing) As Integer

        Dim blnMaxLenMiss As Boolean
        Dim blnClassMiss As Boolean
        Dim strRecvData As String
        Dim lngBufferLen As Integer
        Dim arrBuffer() As Byte
        Dim lngErrorCode As Integer

        If m_enmProtocol = ProtocolConstants.sckTCPProtocol Then
            lngBufferLen = Len(m_strRecvBuffer)
        Else
            lngBufferLen = GetBufferLenUDP()
        End If

        blnMaxLenMiss = IsNothing(maxLen)
        blnClassMiss = IsNothing(varClass)

        'Select type of data
        If VarType(data) = VariantType.Empty Then
            If blnClassMiss Then varClass = VariantType.Array + VariantType.Byte
        Else
            varClass = VarType(data)
        End If

        'As stated on Winsock control documentation if the
        'data type passed is string or byte array type then
        'we must take into account maxLen argument.
        'If it is another type maxLen is ignored.
        If varClass = VariantType.String Or varClass = VariantType.Array + VariantType.Byte Then

            If blnMaxLenMiss Then 'if maxLen argument is missing

                If lngBufferLen = 0 Then

                    RecvData = 0

                    arrBuffer = Unicode.GetBytes("")
                    'UPGRADE_WARNING: Couldn't resolve default property of object data. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    data = arrBuffer.Clone

                    Exit Function

                Else

                    RecvData = lngBufferLen
                    arrBuffer = BuildArray(lngBufferLen, blnPeek, lngErrorCode)

                End If

            Else 'if maxLen argument is not missing

                If maxLen = 0 Or lngBufferLen = 0 Then

                    RecvData = 0

                    arrBuffer = Unicode.GetBytes("")
                    'UPGRADE_WARNING: Couldn't resolve default property of object data. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    data = arrBuffer.Clone

                    If m_enmProtocol = ProtocolConstants.sckUDPProtocol Then
                        EmptyBuffer()
                        Err.Raise(WSAEMSGSIZE, "CSocketMaster.RecvData", GetErrorDescription(WSAEMSGSIZE))
                    End If

                    Exit Function

                ElseIf maxLen > lngBufferLen Then

                    RecvData = lngBufferLen
                    arrBuffer = BuildArray(lngBufferLen, blnPeek, lngErrorCode)

                Else

                    RecvData = CInt(maxLen)
                    arrBuffer = BuildArray(CInt(maxLen), blnPeek, lngErrorCode)

                End If

            End If

        End If

        Dim strdata As String
        Dim blnData As Boolean
        Dim bytData As Byte
        Dim curData As Decimal
        Dim datData As Date
        Dim dblData As Double
        Dim intData As Short
        Dim lngData As Integer
        Dim sngData As Single
        Select Case varClass

            Case VariantType.String
                strdata = Unicode.GetString(arrBuffer)
                data = strdata
            Case VariantType.Array + VariantType.Byte
                data = arrBuffer.Clone()
            Case VariantType.Boolean
                If LenB(blnData) > lngBufferLen Then Exit Function
                arrBuffer = BuildArray(LenB(blnData), blnPeek, lngErrorCode)
                RecvData = LenB(blnData)
                api_CopyMemory(blnData, arrBuffer(0), LenB(blnData))
                data = blnData
            Case VariantType.Byte
                If LenB(bytData) > lngBufferLen Then Exit Function
                arrBuffer = BuildArray(LenB(bytData), blnPeek, lngErrorCode)
                RecvData = LenB(bytData)
                api_CopyMemory(bytData, arrBuffer(0), LenB(bytData))
                data = bytData
            Case VariantType.Decimal
                If LenB(curData) > lngBufferLen Then Exit Function
                arrBuffer = BuildArray(LenB(curData), blnPeek, lngErrorCode)
                RecvData = LenB(curData)
                api_CopyMemory(curData, arrBuffer(0), LenB(curData))
                data = curData
            Case VariantType.Date
                If LenB(datData) > lngBufferLen Then Exit Function
                arrBuffer = BuildArray(LenB(datData), blnPeek, lngErrorCode)
                RecvData = LenB(datData)
                api_CopyMemory(datData, arrBuffer(0), LenB(datData))
                data = datData
            Case VariantType.Double
                If LenB(dblData) > lngBufferLen Then Exit Function
                arrBuffer = BuildArray(LenB(dblData), blnPeek, lngErrorCode)
                RecvData = LenB(dblData)
                api_CopyMemory(dblData, arrBuffer(0), LenB(dblData))
                data = dblData
            Case VariantType.Short
                If LenB(intData) > lngBufferLen Then Exit Function
                arrBuffer = BuildArray(LenB(intData), blnPeek, lngErrorCode)
                RecvData = LenB(intData)
                api_CopyMemory(intData, arrBuffer(0), LenB(intData))
                data = intData
            Case VariantType.Integer
                If LenB(lngData) > lngBufferLen Then Exit Function
                arrBuffer = BuildArray(LenB(lngData), blnPeek, lngErrorCode)
                RecvData = LenB(lngData)
                api_CopyMemory(lngData, arrBuffer(0), LenB(lngData))
                data = lngData
            Case VariantType.Single
                If LenB(sngData) > lngBufferLen Then Exit Function
                arrBuffer = BuildArray(LenB(sngData), blnPeek, lngErrorCode)
                RecvData = LenB(sngData)
                api_CopyMemory(sngData, arrBuffer(0), LenB(sngData))
                data = sngData
            Case Else
                Err.Raise(sckUnsupported, "CSocketMaster.RecvData", "Unsupported variant type.")

        End Select

        'if BuildArray returns an error is handled here
        If lngErrorCode <> 0 Then
            Err.Raise(lngErrorCode, "CSocketMaster.RecvData", GetErrorDescription(lngErrorCode))
        End If

    End Function

    'Returns a byte array of Size bytes filled with incoming buffer data.
    Private Function BuildArray(ByVal Size As Integer, ByVal blnPeek As Boolean, ByRef lngErrorCode As Integer) As Byte()
        Dim strdata As String

        Dim arrBuffer() As Byte
        Dim lngResult As Integer
        Dim lngFlags As Integer
        Dim udtSockAddr As sockaddr_in
        If m_enmProtocol = ProtocolConstants.sckTCPProtocol Then

            strdata = Left(m_strRecvBuffer, CInt(Size))
            BuildArray = Unicode.GetBytes(strdata)

            If Not blnPeek Then
                m_strRecvBuffer = Mid(m_strRecvBuffer, Size + 1)
            End If

        Else 'UDP protocol

            If blnPeek Then lngFlags = MSG_PEEK

            ReDim arrBuffer(Size - 1)

            lngResult = api_recvfrom(m_lngSocketHandle, arrBuffer(0), Size, lngFlags, udtSockAddr, LenB(udtSockAddr))

            If lngResult = SOCKET_ERROR Then
                lngErrorCode = Err.LastDllError
            End If

            BuildArray = arrBuffer.Clone()
            GetRemoteInfoFromSI(udtSockAddr, m_lngRemotePort, m_strRemoteHostIP, m_strRemoteHost)

        End If
    End Function

    'Clean resolution system that is in charge of
    'asynchronous hostname resolutions.
    Private Sub CleanResolutionSystem()
        Dim varAsynHandle As Integer

        'cancel async resolutions if they're still running
        For Each varAsynHandle In m_colWaitingResolutions
            api_WSACancelAsyncRequest(varAsynHandle)
            modSocketMaster.UnregisterResolution(varAsynHandle)
        Next varAsynHandle

        'free memory buffer where resolution results are stored
        FreeMemory()
    End Sub

    Public Sub Listen()
        If m_enmState <> SockState.sckClosed And m_enmState <> SockState.sckOpen Then
            Err.Raise(sckInvalidOp, "CSocketMaster.Listen", "Invalid operation at current state")
        End If

        If Not SocketExists() Then Exit Sub
        If Not BindInternal() Then Exit Sub

        Dim lngResult As Integer

        lngResult = api_listen(m_lngSocketHandle, SOMAXCONN)

        Dim lngErrorCode As Integer
        If lngResult = SOCKET_ERROR Then
            lngErrorCode = Err.LastDllError
            Err.Raise(lngErrorCode, "CSocketMaster.Listen", GetErrorDescription(lngErrorCode))
        Else
            m_enmState = SockState.sckListening : Debug.Print("STATE: sckListening")
        End If

    End Sub

    Public Sub Accept(ByRef requestID As Integer)
        If m_enmState <> SockState.sckClosed Then
            Err.Raise(sckInvalidOp, "CSocketMaster.Accept", "Invalid operation at current state")
        End If

        Dim lngResult As Integer
        Dim udtSockAddr As sockaddr_in
        Dim lngErrorCode As Integer

        m_lngSocketHandle = requestID
        m_enmProtocol = ProtocolConstants.sckTCPProtocol
        ProcessOptions()

        If Not modSocketMaster.IsAcceptRegistered(requestID) Then
            If IsSocketRegistered(requestID) Then
                Err.Raise(sckBadState, "CSocketMaster.Accept", "Wrong protocol or connection state for the requested transaction or request")
            Else
                m_blnAcceptClass = True
                m_enmState = SockState.sckConnected : Debug.Print("STATE: sckConnected")
                'UPGRADE_ISSUE: ObjPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
                modSocketMaster.RegisterSocket(m_lngSocketHandle, VarPtr.VarPtr(Me), False)
                Exit Sub
            End If
        End If

        Dim clsSocket As CSocketMaster
        clsSocket = GetAcceptClass(requestID)
        modSocketMaster.UnregisterAccept(requestID)

        lngResult = api_getsockname(m_lngSocketHandle, udtSockAddr, LenB(udtSockAddr))

        If lngResult = SOCKET_ERROR Then

            lngErrorCode = Err.LastDllError
            Err.Raise(lngErrorCode, "CSocketMaster.Accept", GetErrorDescription(lngErrorCode))

        Else

            m_lngLocalPortBind = IntegerToUnsigned(api_ntohs(udtSockAddr.sin_port))
            m_strLocalIP = StringFromPointer(api_inet_ntoa(udtSockAddr.sin_addr))

        End If

        GetRemoteInfo(m_lngSocketHandle, m_lngRemotePort, m_strRemoteHostIP, m_strRemoteHost)
        m_enmState = SockState.sckConnected : Debug.Print("STATE: sckConnected")

        If clsSocket.BytesReceived > 0 Then
            clsSocket.GetData(m_strRecvBuffer)
        End If

        'UPGRADE_ISSUE: ObjPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
        modSocketMaster.Subclass_ChangeOwner(requestID, VarPtr.VarPtr(Me))

        If Len(m_strRecvBuffer) > 0 Then RaiseEvent DataArrival(Len(m_strRecvBuffer))

        If clsSocket.State = SockState.sckClosing Then
            m_enmState = SockState.sckClosing : Debug.Print("STATE: sckClosing")
            RaiseEvent CloseSck()
        End If

        clsSocket = Nothing
    End Sub

    'Retrieves remote info from a connected socket.
    'If succeeds returns TRUE and loads the arguments.
    'If fails returns FALSE and arguments are not loaded.
    Private Function GetRemoteInfo(ByVal lngSocket As Integer, ByRef lngRemotePort As Integer, ByRef strRemoteHostIP As String, ByRef strRemoteHost As String) As Boolean
        GetRemoteInfo = False
        Dim lngResult As Integer
        Dim udtSockAddr As sockaddr_in

        'lngResult = api_getpeername(lngSocket, udtSockAddr, LenB(udtSockAddr))

        If lngResult = 0 Then
            GetRemoteInfo = True
            GetRemoteInfoFromSI(udtSockAddr, lngRemotePort, strRemoteHostIP, strRemoteHost)
        Else
            lngRemotePort = 0
            strRemoteHostIP = ""
            strRemoteHost = ""
        End If
    End Function

    'Gets remote info from a sockaddr_in structure.
    Private Sub GetRemoteInfoFromSI(ByRef udtSockAddr As sockaddr_in, ByRef lngRemotePort As Integer, ByRef strRemoteHostIP As String, ByRef strRemoteHost As String)

        'Dim lngResult As Long
        'Dim udtHostent As HOSTENT

        lngRemotePort = IntegerToUnsigned(api_ntohs(udtSockAddr.sin_port))
        strRemoteHostIP = StringFromPointer(api_inet_ntoa(udtSockAddr.sin_addr))
        'lngResult = api_gethostbyaddr(udtSockAddr.sin_addr, 4&, AF_INET)

        'If lngResult <> 0 Then
        '    api_CopyMemory udtHostent, ByVal lngResult, LenB(udtHostent)
        '    strRemoteHost = StringFromPointer(udtHostent.hName)
        'Else
        m_strRemoteHost = ""
        'End If

    End Sub

    'Returns winsock incoming buffer length from an UDP socket.
    Private Function GetBufferLenUDP() As Integer
        Dim lngResult As Integer
        Dim lngBuffer As Integer
        lngResult = api_ioctlsocket(m_lngSocketHandle, FIONREAD, lngBuffer)

        If lngResult = SOCKET_ERROR Then
            GetBufferLenUDP = 0
        Else
            GetBufferLenUDP = lngBuffer
        End If
    End Function

    'Empty winsock incoming buffer from an UDP socket.
    Private Sub EmptyBuffer()
        Dim B As Byte
        api_recv(m_lngSocketHandle, B, Len(B), 0)
    End Sub
End Class