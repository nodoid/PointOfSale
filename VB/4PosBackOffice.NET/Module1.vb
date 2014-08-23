Option Strict Off
Option Explicit On
Module Module1
	'**************************************************************************************************************************
	Public bActiveSession As Boolean
	Public hOpen, hConnection As Integer
	Public dwType As Integer
	Public cor As Boolean
	Public objIniFile As clsFileIni
	Public dirrecv, password, server, BranchID, BranchType, HOfficeID, ServerN, username, dirsend, dirserv As Object
	Public tipftp As String
	Public sqlUser, sqlLinkPath, sqlServer, sqlPassWord As Object
	Public sqlDBase As String
	Public sqlDBcn As ADODB.Connection 'Interface to be used to for connection
	Public bBranchChange As Boolean
	Public bUploadReport As Boolean
	Public sGRVSales As String
	
	Public prgCol As String
	Public NomeFileLog As String
#If Win16 Then
	'UPGRADE_NOTE: #If #EndIf block was not upgraded because the expression Win16 did not evaluate to True or was not evaluated. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"'
	Private Declare Function WritePrivateProfileString Lib "KERNEL" (ByVal AppName As String, ByVal KeyName As String, ByVal keydefault As String, ByVal FileName As String) As Integer
	Private Declare Function GetPrivateProfileString Lib "KERNEL" (ByVal AppName As String, ByVal KeyName As String, ByVal keydefault As String, ByVal ReturnString As String, ByVal NumBytes As Integer, ByVal FileName As String) As Integer
#ElseIf Win32 Then
	Private Declare Function WritePrivateProfileString Lib "kernel32"  Alias "WritePrivateProfileStringA"(ByVal AppName As String, ByVal KeyName As String, ByVal keydefault As String, ByVal FileName As String) As Integer
	Private Declare Function GetPrivateProfileString Lib "kernel32"  Alias "GetPrivateProfileStringA"(ByVal AppName As String, ByVal KeyName As String, ByVal keydefault As String, ByVal ReturnString As String, ByVal NumBytes As Integer, ByVal FileName As String) As Integer
#End If
	'**************************************************************************************************************************************
	
	Declare Function GetProcessHeap Lib "kernel32" () As Integer
	Declare Function HeapAlloc Lib "kernel32" (ByVal hHeap As Integer, ByVal dwFlags As Integer, ByVal dwBytes As Integer) As Integer
	Declare Function HeapFree Lib "kernel32" (ByVal hHeap As Integer, ByVal dwFlags As Integer, ByRef lpMem As Object) As Integer
	Public Const HEAP_ZERO_MEMORY As Integer = &H8
	Public Const HEAP_GENERATE_EXCEPTIONS As Integer = &H4
	
	Declare Sub copymemory1 Lib "kernel32" Alias "RtlMoveMemory" (ByRef hpvDest As Object, ByVal hpvsource As Integer, ByVal cbCopy As Integer)
	Declare Sub CopyMemory2 Lib "kernel32" Alias "RtlMoveMemory" (ByRef hpvDest As Integer, ByRef hpvsource As Object, ByVal cbCopy As Integer)
	
	Public Const MAX_PATH As Short = 260
	Public Const NO_ERROR As Short = 0
	Public Const FILE_ATTRIBUTE_READONLY As Integer = &H1
	Public Const FILE_ATTRIBUTE_HIDDEN As Integer = &H2
	Public Const FILE_ATTRIBUTE_SYSTEM As Integer = &H4
	Public Const FILE_ATTRIBUTE_DIRECTORY As Integer = &H10
	Public Const FILE_ATTRIBUTE_ARCHIVE As Integer = &H20
	Public Const FILE_ATTRIBUTE_NORMAL As Integer = &H80
	Public Const FILE_ATTRIBUTE_TEMPORARY As Integer = &H100
	Public Const FILE_ATTRIBUTE_COMPRESSED As Integer = &H800
	Public Const FILE_ATTRIBUTE_OFFLINE As Integer = &H1000
	
	Structure FILETIME
		Dim dwLowDateTime As Integer
		Dim dwHighDateTime As Integer
	End Structure
	Structure WIN32_FIND_DATA
		Dim dwFileAttributes As Integer
		Dim ftCreationTime As FILETIME
		Dim ftLastAccessTime As FILETIME
		Dim ftLastWriteTime As FILETIME
		Dim nFileSizeHigh As Integer
		Dim nFileSizeLow As Integer
		Dim dwReserved0 As Integer
		Dim dwReserved1 As Integer
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(MAX_PATH),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=MAX_PATH)> Public cFileName() As Char
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(14),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=14)> Public cAlternate() As Char
	End Structure
	
	Public Const ERROR_NO_MORE_FILES As Short = 18
	
	'UPGRADE_WARNING: Structure WIN32_FIND_DATA may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Public Declare Function InternetFindNextFile Lib "wininet.dll"  Alias "InternetFindNextFileA"(ByVal hFind As Integer, ByRef lpvFindData As WIN32_FIND_DATA) As Integer
	
	'UPGRADE_WARNING: Structure WIN32_FIND_DATA may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Public Declare Function FtpFindFirstFile Lib "wininet.dll"  Alias "FtpFindFirstFileA"(ByVal hFtpSession As Integer, ByVal lpszSearchFile As String, ByRef lpFindFileData As WIN32_FIND_DATA, ByVal dwFlags As Integer, ByVal dwContent As Integer) As Integer
	
	Public Declare Function FtpGetFile Lib "wininet.dll"  Alias "FtpGetFileA"(ByVal hFtpSession As Integer, ByVal lpszRemoteFile As String, ByVal lpszNewFile As String, ByVal fFailIfExists As Boolean, ByVal dwFlagsAndAttributes As Integer, ByVal dwFlags As Integer, ByVal dwContext As Integer) As Boolean
	
	Public Declare Function FtpPutFile Lib "wininet.dll"  Alias "FtpPutFileA"(ByVal hFtpSession As Integer, ByVal lpszLocalFile As String, ByVal lpszRemoteFile As String, ByVal dwFlags As Integer, ByVal dwContext As Integer) As Boolean
	
	Public Declare Function FtpSetCurrentDirectory Lib "wininet.dll"  Alias "FtpSetCurrentDirectoryA"(ByVal hFtpSession As Integer, ByVal lpszDirectory As String) As Boolean
	' Initializes an application's use of the Win32 Internet functions
	Public Declare Function InternetOpen Lib "wininet.dll"  Alias "InternetOpenA"(ByVal sAgent As String, ByVal lAccessType As Integer, ByVal sProxyName As String, ByVal sProxyBypass As String, ByVal lFlags As Integer) As Integer
	
	' User agent constant.
	Public Const scUserAgent As String = "vb wininet"
	
	' Use registry access settings.
	Public Const INTERNET_OPEN_TYPE_PRECONFIG As Short = 0
	Public Const INTERNET_OPEN_TYPE_DIRECT As Short = 1
	Public Const INTERNET_OPEN_TYPE_PROXY As Short = 3
	Public Const INTERNET_INVALID_PORT_NUMBER As Short = 0
	
	Public Const FTP_TRANSFER_TYPE_BINARY As Integer = &H2
	Public Const FTP_TRANSFER_TYPE_ASCII As Integer = &H1
	Public Const INTERNET_FLAG_PASSIVE As Integer = &H8000000
	
	' Opens a HTTP session for a given site.
	Public Declare Function InternetConnect Lib "wininet.dll"  Alias "InternetConnectA"(ByVal hInternetSession As Integer, ByVal sServerName As String, ByVal nServerPort As Short, ByVal sUsername As String, ByVal sPassword As String, ByVal lService As Integer, ByVal lFlags As Integer, ByVal lContext As Integer) As Integer
	
	Public Const ERROR_INTERNET_EXTENDED_ERROR As Short = 12003
	Public Declare Function InternetGetLastResponseInfo Lib "wininet.dll"  Alias "InternetGetLastResponseInfoA"(ByRef lpdwError As Integer, ByVal lpszBuffer As String, ByRef lpdwBufferLength As Integer) As Boolean
	
	' Number of the TCP/IP port on the server to connect to.
	Public Const INTERNET_DEFAULT_FTP_PORT As Short = 21
	Public Const INTERNET_DEFAULT_GOPHER_PORT As Short = 70
	Public Const INTERNET_DEFAULT_HTTP_PORT As Short = 80
	Public Const INTERNET_DEFAULT_HTTPS_PORT As Short = 443
	Public Const INTERNET_DEFAULT_SOCKS_PORT As Short = 1080
	
	Public Const INTERNET_OPTION_CONNECT_TIMEOUT As Short = 2
	Public Const INTERNET_OPTION_RECEIVE_TIMEOUT As Short = 6
	Public Const INTERNET_OPTION_SEND_TIMEOUT As Short = 5
	
	Public Const INTERNET_OPTION_USERNAME As Short = 28
	Public Const INTERNET_OPTION_PASSWORD As Short = 29
	Public Const INTERNET_OPTION_PROXY_USERNAME As Short = 43
	Public Const INTERNET_OPTION_PROXY_PASSWORD As Short = 44
	
	' Type of service to access.
	Public Const INTERNET_SERVICE_FTP As Short = 1
	Public Const INTERNET_SERVICE_GOPHER As Short = 2
	Public Const INTERNET_SERVICE_HTTP As Short = 3
	
	' Opens an HTTP request handle.
	Public Declare Function HttpOpenRequest Lib "wininet.dll"  Alias "HttpOpenRequestA"(ByVal hHttpSession As Integer, ByVal sVerb As String, ByVal sObjectName As String, ByVal sVersion As String, ByVal sReferer As String, ByVal something As Integer, ByVal lFlags As Integer, ByVal lContext As Integer) As Integer
	
	' Brings the data across the wire even if it locally cached.
	Public Const INTERNET_FLAG_RELOAD As Integer = &H80000000
	Public Const INTERNET_FLAG_KEEP_CONNECTION As Integer = &H400000
	Public Const INTERNET_FLAG_MULTIPART As Integer = &H200000
	
	Public Const GENERIC_READ As Integer = &H80000000
	Public Const GENERIC_WRITE As Integer = &H40000000
	
	' Sends the specified request to the HTTP server.
	Public Declare Function HttpSendRequest Lib "wininet.dll"  Alias "HttpSendRequestA"(ByVal hHttpRequest As Integer, ByVal sHeaders As String, ByVal lHeadersLength As Integer, ByVal sOptional As String, ByVal lOptionalLength As Integer) As Short
	
	
	' Queries for information about an HTTP request.
	Public Declare Function HttpQueryInfo Lib "wininet.dll" Alias "HttpQueryInfoA" (ByVal hHttpRequest As Integer, ByVal lInfoLevel As Integer, ByRef sBuffer As Object, ByRef lBufferLength As Integer, ByRef lIndex As Integer) As Short
	
	' The possible values for the lInfoLevel parameter include:
	Public Const HTTP_QUERY_CONTENT_TYPE As Short = 1
	Public Const HTTP_QUERY_CONTENT_LENGTH As Short = 5
	Public Const HTTP_QUERY_EXPIRES As Short = 10
	Public Const HTTP_QUERY_LAST_MODIFIED As Short = 11
	Public Const HTTP_QUERY_PRAGMA As Short = 17
	Public Const HTTP_QUERY_VERSION As Short = 18
	Public Const HTTP_QUERY_STATUS_CODE As Short = 19
	Public Const HTTP_QUERY_STATUS_TEXT As Short = 20
	Public Const HTTP_QUERY_RAW_HEADERS As Short = 21
	Public Const HTTP_QUERY_RAW_HEADERS_CRLF As Short = 22
	Public Const HTTP_QUERY_FORWARDED As Short = 30
	Public Const HTTP_QUERY_SERVER As Short = 37
	Public Const HTTP_QUERY_USER_AGENT As Short = 39
	Public Const HTTP_QUERY_SET_COOKIE As Short = 43
	Public Const HTTP_QUERY_REQUEST_METHOD As Short = 45
	Public Const HTTP_STATUS_DENIED As Short = 401
	Public Const HTTP_STATUS_PROXY_AUTH_REQ As Short = 407
	
	' Add this flag to the about flags to get request header.
	Public Const HTTP_QUERY_FLAG_REQUEST_HEADERS As Integer = &H80000000
	Public Const HTTP_QUERY_FLAG_NUMBER As Integer = &H20000000
	' Reads data from a handle opened by the HttpOpenRequest function.
	Public Declare Function InternetReadFile Lib "wininet.dll" (ByVal hFile As Integer, ByVal sBuffer As String, ByVal lNumBytesToRead As Integer, ByRef lNumberOfBytesRead As Integer) As Short
	
	Public Declare Function InternetWriteFile Lib "wininet.dll" (ByVal hFile As Integer, ByVal sBuffer As String, ByVal lNumberOfBytesToRead As Integer, ByRef lNumberOfBytesRead As Integer) As Short
	
	Public Declare Function FtpOpenFile Lib "wininet.dll"  Alias "FtpOpenFileA"(ByVal hFtpSession As Integer, ByVal sFileName As String, ByVal lAccess As Integer, ByVal lFlags As Integer, ByVal lContext As Integer) As Integer
	Public Declare Function FtpDeleteFile Lib "wininet.dll"  Alias "FtpDeleteFileA"(ByVal hFtpSession As Integer, ByVal lpszFileName As String) As Boolean
	Public Declare Function InternetSetOption Lib "wininet.dll" Alias "InternetSetOptionA" (ByVal hInternet As Integer, ByVal lOption As Integer, ByRef sBuffer As Object, ByVal lBufferLength As Integer) As Short
	Public Declare Function InternetSetOptionStr Lib "wininet.dll"  Alias "InternetSetOptionA"(ByVal hInternet As Integer, ByVal lOption As Integer, ByVal sBuffer As String, ByVal lBufferLength As Integer) As Short
	
	' Closes a single Internet handle or a subtree of Internet handles.
	Public Declare Function InternetCloseHandle Lib "wininet.dll" (ByVal hInet As Integer) As Short
	
	' Queries an Internet option on the specified handle
	Public Declare Function InternetQueryOption Lib "wininet.dll" Alias "InternetQueryOptionA" (ByVal hInternet As Integer, ByVal lOption As Integer, ByRef sBuffer As Object, ByRef lBufferLength As Integer) As Short
	
	' Returns the version number of Wininet.dll.
	Public Const INTERNET_OPTION_VERSION As Short = 40
	
	' Contains the version number of the DLL that contains the Windows Internet
	' functions (Wininet.dll). This structure is used when passing the
	' INTERNET_OPTION_VERSION flag to the InternetQueryOption function.
	Public Structure tWinInetDLLVersion
		Dim lMajorVersion As Integer
		Dim lMinorVersion As Integer
	End Structure
	
	' Adds one or more HTTP request headers to the HTTP request handle.
	Public Declare Function HttpAddRequestHeaders Lib "wininet.dll"  Alias "HttpAddRequestHeadersA"(ByVal hHttpRequest As Integer, ByVal sHeaders As String, ByVal lHeadersLength As Integer, ByVal lModifiers As Integer) As Short
	
	' Flags to modify the semantics of this function. Can be a combination of these values:
	
	' Adds the header only if it does not already exist; otherwise, an error is returned.
	Public Const HTTP_ADDREQ_FLAG_ADD_IF_NEW As Integer = &H10000000
	
	' Adds the header if it does not exist. Used with REPLACE.
	Public Const HTTP_ADDREQ_FLAG_ADD As Integer = &H20000000
	
	' Replaces or removes a header. If the header value is empty and the header is found,
	' it is removed. If not empty, the header value is replaced
	Public Const HTTP_ADDREQ_FLAG_REPLACE As Integer = &H80000000
	
	'FOR PASSWORD INPUTPUTBOX
	Private Declare Function FindWindow Lib "user32"  Alias "FindWindowA"(ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
	
	Private Declare Function FindWindowEx Lib "user32"  Alias "FindWindowExA"(ByVal hWnd1 As Integer, ByVal hWnd2 As Integer, ByVal lpsz1 As String, ByVal lpsz2 As String) As Integer
	
	Public Declare Function SetTimer Lib "user32" (ByVal hwnd As Integer, ByVal nIDEvent As Integer, ByVal uElapse As Integer, ByVal lpTimerFunc As Integer) As Integer
	
	Private Declare Function KillTimer Lib "user32" (ByVal hwnd As Integer, ByVal nIDEvent As Integer) As Integer
	
	Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByRef lParam As Object) As Integer
	
	Const EM_SETPASSWORDCHAR As Integer = &HCC
	Public Const NV_INPUTBOX As Integer = &H5000
	
	'FOR PASSWORD INPUTPUTBOX
	Public Sub TimerProc(ByVal hwnd As Integer, ByVal uMsg As Integer, ByVal idEvent As Integer, ByVal dwTime As Integer)
		
		Dim EditHwnd As Integer
		' CHANGE APP.TITLE TO YOUR INPUT BOX TITLE.
		EditHwnd = FindWindowEx(FindWindow("#32770", My.Application.Info.Title), 0, "Edit", "")
		
		Call SendMessage(EditHwnd, EM_SETPASSWORDCHAR, Asc("*"), 0)
		KillTimer(hwnd, idEvent)
	End Sub
	
	Public Sub CaricaDati()
		
		objIniFile = New clsFileIni
		objIniFile.FileINI = My.Application.Info.DirectoryPath & "\" & "4POSHQ.INI"
		objIniFile.section = "Configuration Info"
		objIniFile.Key = "" '"FTPSERVER"
		Call objIniFile.ReadFromINI()
		'UPGRADE_WARNING: Couldn't resolve default property of object ServerN. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ServerN = "http://www.4pos.co.za/testHQ/4posheadoffice.pos"
		'server = objIniFile.Description
		objIniFile.Key = "BranchType"
		Call objIniFile.ReadFromINI()
		'UPGRADE_WARNING: Couldn't resolve default property of object BranchType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		BranchType = objIniFile.Description
		'username = objIniFile.Description
		objIniFile.Key = "BranchID"
		Call objIniFile.ReadFromINI()
		'password = objIniFile.Description
		'UPGRADE_WARNING: Couldn't resolve default property of object BranchID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		BranchID = objIniFile.Description
		objIniFile.Key = "DIRSEND"
		Call objIniFile.ReadFromINI()
		'UPGRADE_WARNING: Couldn't resolve default property of object dirsend. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		dirsend = objIniFile.Description
		objIniFile.Key = "DIRRECV"
		Call objIniFile.ReadFromINI()
		'UPGRADE_WARNING: Couldn't resolve default property of object dirrecv. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		dirrecv = objIniFile.Description
		objIniFile.Key = "DIRSERV"
		Call objIniFile.ReadFromINI()
		'UPGRADE_WARNING: Couldn't resolve default property of object dirserv. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		dirserv = objIniFile.Description
		objIniFile.Key = CStr(1) '"TIPFTP"
		Call objIniFile.ReadFromINI()
		tipftp = CStr(1) 'objIniFile.Description
		'UPGRADE_NOTE: Object objIniFile may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		objIniFile = Nothing
		
	End Sub
	
	'UPGRADE_NOTE: Main was upgraded to Main_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Main_Renamed()
		
		'Set variables
		bActiveSession = False
		hOpen = 0
		hConnection = 0
		dwType = FTP_TRANSFER_TYPE_BINARY
		prgCol = "4POS-HQ_"
		NomeFileLog = prgCol & CStr(Format(Now, "ddmmyyyy")) & CStr(Format(Now, "hhmm")) & ".log"
		
		CaricaDati() 'read the file
		'frmMainHO.Text1.Text = ""
		'frmMainHO.Label1(1).Caption = ""
		'UPGRADE_ISSUE: Load statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"'
        'Load(frmMainHO)
		'PreparaForm
		'frmFTP.Show vbModal
		frmMainHO.ShowDialog() 'vbModal
		
	End Sub
	Public Sub PreparaForm(Optional ByRef Caso As String = "")
		
		If bActiveSession = True Then
			If Trim(Caso) = "" Then
                frmMainHO._cmdPulsante_0.Enabled = False
                frmMainHO._cmdPulsante_1.Enabled = True
                frmMainHO._cmdPulsante_2.Enabled = False
                frmMainHO._cmdPulsante_3.Enabled = False
                frmMainHO._cmdPulsante_4.Enabled = False
                frmMainHO._cmdPulsante_6.Enabled = True
                frmMainHO._cmdPulsante_7.Enabled = True
			Else
				If Caso = "UpLoad" Then
                    frmMainHO._cmdPulsante_1.Enabled = False
                    frmMainHO._cmdPulsante_7.Enabled = False
				End If
				If Caso = "UpLoadFine" Then
                    frmMainHO._cmdPulsante_1.Enabled = True
                    frmMainHO._cmdPulsante_7.Enabled = True
				End If
				If Caso = "DownLoad" Then
                    frmMainHO._cmdPulsante_1.Enabled = False
                    frmMainHO._cmdPulsante_6.Enabled = False
				End If
				If Caso = "DownLoadFine" Then
                    frmMainHO._cmdPulsante_1.Enabled = True
                    frmMainHO._cmdPulsante_6.Enabled = True
				End If
				
			End If
		ElseIf bActiveSession = False Then 
            frmMainHO._cmdPulsante_0.Enabled = True
            frmMainHO._cmdPulsante_1.Enabled = False
            frmMainHO._cmdPulsante_2.Enabled = True
            frmMainHO._cmdPulsante_3.Enabled = True
            frmMainHO._cmdPulsante_4.Enabled = True
            frmMainHO._cmdPulsante_6.Enabled = False
            frmMainHO._cmdPulsante_7.Enabled = False
		End If
		
	End Sub
End Module