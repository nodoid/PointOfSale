Option Strict Off
Option Explicit On
Module modWinVer
	'UPGRADE_WARNING: Structure OSVERSIONINFO may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Public Declare Function GetVersionEx Lib "kernel32"  Alias "GetVersionExA"(ByRef lpVersionInformation As OSVERSIONINFO) As Integer
	
    Public Structure OSVERSIONINFO
        Dim dwOSVersionInfoSize As Integer
        Dim dwMajorVersion As Integer
        Dim dwMinorVersion As Integer
        Dim dwBuildNumber As Integer
        Dim dwPlatformId As Integer
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(128), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=128)> Public szCSDVersion() As Char
    End Structure

    Public Function Win7Ver() As Boolean
        Dim osVer As System.OperatingSystem = System.Environment.OSVersion
        Dim PId As String
        If osVer.Version.Major = 6 AndAlso osVer.Version.Minor = 1 Then
            Win7Ver = True
        Else
            Win7Ver = False
        End If
    End Function

    'Public Function Win7Ver() As Boolean
    ' Dim Ret As Integer
    ' Dim OSInfo As OSVERSIONINFO
    ' Dim PId As String
    ' 'Set the graphical mode to persistent
    '' '    Me.AutoRedraw = True
    ''Set the structure size
    '		OSInfo.dwOSVersionInfoSize = Len(OSInfo)
    '    'Get the Windows version'
    '	Ret = GetVersionEx(OSInfo)
    'Chack for error's
    '    If ret& = 0 Then MsgBox "Error Getting Version Information": Exit Sub
    '	If Ret = 0 Then Win7Ver = False : Exit Function
    'Print the information to the form
    '	Select Case OSInfo.dwPlatformId
    '			Case 0'
    '		PId = "Windows 32s "
    '	Case '1
    '		PId = "Windows 95/98"
    '	Case 2
    '		PId = "Windows NT "
    'End Select
    '    Print "OS: " + PId
    '    Print "Win version:" + Str$(OSInfo.dwMajorVersion) + "." + LTrim(Str(OSInfo.dwMinorVersion))
    '    Print "Build: " + Str(OSInfo.dwBuildNumber)
    '	If OSInfo.dwMajorVersion >= 6 Then Win7Ver = True
    'End Function

    Public Function getWinVer() As String
        Dim Ret As Integer
        Dim OSInfo As OSVERSIONINFO
        Dim PId As String
        'Set the graphical mode to persistent
        '    Me.AutoRedraw = True
        'Set the structure size
        OSInfo.dwOSVersionInfoSize = Len(OSInfo)
        'Get the Windows version
        Ret = GetVersionEx(OSInfo)
        'Chack for errors
        '    If ret& = 0 Then MsgBox "Error Getting Version Information": Exit Sub
        'If Ret& = 0 Then Win7Ver = False: Exit Function
        'Print the information to the form
        Select Case OSInfo.dwPlatformId
            Case 0
                PId = "Windows 32s "
            Case 1
                PId = "Windows 95/98"
            Case 2
                PId = "Windows NT "
        End Select
        '    Print "OS: " + PId
        '    Print "Win version:" + Str$(OSInfo.dwMajorVersion) + "." + LTrim(Str(OSInfo.dwMinorVersion))
        '    Print "Build: " + Str(OSInfo.dwBuildNumber)
        getWinVer = PId
    End Function

    'Private Sub Form_Load()
    '    Dim OSInfo As OSVERSIONINFO, PId As String
    '    'Set the graphical mode to persistent
    '    Me.AutoRedraw = True
    '    'Set the structure size
    '    OSInfo.dwOSVersionInfoSize = Len(OSInfo)
    '    'Get the Windows version
    '    ret& = GetVersionEx(OSInfo)
    '    'Chack for errors
    '    If ret& = 0 Then MsgBox "Error Getting Version Information": Exit Sub
    '    'Print the information to the form
    '    Select Case OSInfo.dwPlatformId
    '        Case 0
    '            PId = "Windows 32s "
    '        Case 1
    '            PId = "Windows 95/98"
    '        Case 2
    '            PId = "Windows NT "
    '    End Select
    '    Print "OS: " + PId
    '    Print "Win version:" + Str$(OSInfo.dwMajorVersion) + "." + LTrim(Str(OSInfo.dwMinorVersion))
    '    Print "Build: " + Str(OSInfo.dwBuildNumber)
    'End Sub
End Module