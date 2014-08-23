Option Strict Off
Option Explicit On
Module CodeModule
	
	'-- C Style argv
	Public Structure UNZIPnames
		<VBFixedArray(99)> Dim uzFiles() As String
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			ReDim uzFiles(99)
		End Sub
	End Structure
	
	'-- Callback Large "String"
	Public Structure UNZIPCBChar
		<VBFixedArray(32800)> Dim ch() As Byte
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			ReDim ch(32800)
		End Sub
	End Structure
	
	'-- Callback Small "String"
	Public Structure UNZIPCBCh
		<VBFixedArray(256)> Dim ch() As Byte
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			ReDim ch(256)
		End Sub
	End Structure
	
	'-- UNZIP32.DLL DCL Structure
	Public Structure DCLIST
		Dim ExtractOnlyNewer As Integer ' 1 = Extract Only Newer, Else 0
		Dim SpaceToUnderScore As Integer ' 1 = Convert Space To Underscore, Else 0
		Dim PromptToOverwrite As Integer ' 1 = Prompt To Overwrite Required, Else 0
		Dim fQuiet As Integer ' 2 = No Messages, 1 = Less, 0 = All
		Dim ncflag As Integer ' 1 = Write To Stdout, Else 0
		Dim ntflag As Integer ' 1 = Test Zip File, Else 0
		Dim nvflag As Integer ' 0 = Extract, 1 = List Zip Contents
		Dim nUflag As Integer ' 1 = Extract Only Newer, Else 0
		Dim nzflag As Integer ' 1 = Display Zip File Comment, Else 0
		Dim ndflag As Integer ' 1 = Honor Directories, Else 0
		Dim noflag As Integer ' 1 = Overwrite Files, Else 0
		Dim naflag As Integer ' 1 = Convert CR To CRLF, Else 0
		Dim nZIflag As Integer ' 1 = Zip Info Verbose, Else 0
		Dim C_flag As Integer ' 1 = Case Insensitivity, 0 = Case Sensitivity
		Dim fPrivilege As Integer ' 1 = ACL, 2 = Privileges
		Dim Zip As String ' The Zip Filename To Extract Files
		Dim ExtractDir As String ' The Extraction Directory, NULL If Extracting To Current Dir
	End Structure
	
	'-- UNZIP32.DLL Userfunctions Structure
	Public Structure USERFUNCTION
		Dim UZDLLPrnt As Integer ' Pointer To Apps Print Function
		Dim UZDLLSND As Integer ' Pointer To Apps Sound Function
		Dim UZDLLREPLACE As Integer ' Pointer To Apps Replace Function
		Dim UZDLLPASSWORD As Integer ' Pointer To Apps Password Function
		Dim UZDLLMESSAGE As Integer ' Pointer To Apps Message Function
		Dim UZDLLSERVICE As Integer ' Pointer To Apps Service Function (Not Coded!)
		Dim TotalSizeComp As Integer ' Total Size Of Zip Archive
		Dim TotalSize As Integer ' Total Size Of All Files In Archive
		Dim CompFactor As Integer ' Compression Factor
		Dim NumMembers As Integer ' Total Number Of All Files In The Archive
		Dim cchComment As Short ' Flag If Archive Has A Comment!
	End Structure
	
	'-- UNZIP32.DLL Version Structure
	Public Structure UZPVER
		Dim structlen As Integer ' Length Of The Structure Being Passed
		Dim flag As Integer ' Bit 0: is_beta  bit 1: uses_zlib
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public beta() As Char ' e.g., "g BETA" or ""
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		'UPGRADE_NOTE: date was upgraded to date_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		<VBFixedString(20),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=20)> Public date_Renamed() As Char ' e.g., "4 Sep 95" (beta) or "4 September 1995"
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public zlib() As Char ' e.g., "1.0.5" or NULL
		<VBFixedArray(4)> Dim Unzip() As Byte ' Version Type Unzip
		<VBFixedArray(4)> Dim zipinfo() As Byte ' Version Type Zip Info
		Dim os2dll As Integer ' Version Type OS2 DLL
		<VBFixedArray(4)> Dim windll() As Byte ' Version Type Windows DLL
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			'UPGRADE_WARNING: Lower bound of array Unzip was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
			ReDim Unzip(4)
			'UPGRADE_WARNING: Lower bound of array zipinfo was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
			ReDim zipinfo(4)
			'UPGRADE_WARNING: Lower bound of array windll was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
			ReDim windll(4)
		End Sub
	End Structure
	
	'-- This Assumes UNZIP32.DLL Is In Your \Windows\System Directory!
	'UPGRADE_WARNING: Structure USERFUNCTION may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	'UPGRADE_WARNING: Structure DCLIST may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	'UPGRADE_WARNING: Structure UNZIPnames may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	'UPGRADE_WARNING: Structure UNZIPnames may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function Wiz_SingleEntryUnzip Lib "unzip32.dll" (ByVal ifnc As Integer, ByRef ifnv As UNZIPnames, ByVal xfnc As Integer, ByRef xfnv As UNZIPnames, ByRef dcll As DCLIST, ByRef Userf As USERFUNCTION) As Integer
	
	'UPGRADE_WARNING: Structure UZPVER may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Sub UzpVersion2 Lib "unzip32.dll" (ByRef uzpv As UZPVER)
	
	'argv
	Public Structure ZIPnames
		<VBFixedArray(99)> Dim s() As String
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			ReDim s(99)
		End Sub
	End Structure
	
	'ZPOPT is used to set options in the zip32.dll
	Private Structure ZPOPT
		Dim fSuffix As Integer
		Dim fEncrypt As Integer
		Dim fSystem As Integer
		Dim fVolume As Integer
		Dim fExtra As Integer
		Dim fNoDirEntries As Integer
		Dim fExcludeDate As Integer
		Dim fIncludeDate As Integer
		Dim fVerbose As Integer
		Dim fQuiet As Integer
		Dim fCRLF_LF As Integer
		Dim fLF_CRLF As Integer
		Dim fJunkDir As Integer
		Dim fRecurse As Integer
		Dim fGrow As Integer
		Dim fForce As Integer
		Dim fMove As Integer
		Dim fDeleteEntries As Integer
		Dim fUpdate As Integer
		Dim fFreshen As Integer
		Dim fJunkSFX As Integer
		Dim fLatestTime As Integer
		Dim fComment As Integer
		Dim fOffsets As Integer
		Dim fPrivilege As Integer
		Dim fEncryption As Integer
		Dim fRepair As Integer
		Dim flevel As Byte
		'UPGRADE_NOTE: date was upgraded to date_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim date_Renamed As String ' 8 bytes long
		Dim szRootDir As String ' up to 256 bytes long
	End Structure
	
	Private Structure ZIPUSERFUNCTIONS
		Dim DLLPrnt As Integer
		Dim DLLPASSWORD As Integer
		Dim DLLCOMMENT As Integer
		Dim DLLSERVICE As Integer
	End Structure
	
	'Structure ZCL - not used by VB
	'Private Type ZCL
	'    argc As Long            'number of files
	'    filename As String      'Name of the Zip file
	'    fileArray As ZIPnames   'The array of filenames
	'End Type
	
	' Call back "string" (sic)
    Public Structure CBChar
        <VBFixedArray(4096)> Dim ch() As Byte

        'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
        Public Sub Initialize()
            ReDim ch(4096)
        End Sub
    End Structure
	
	'Local declares
	
	' Dim MYZCL As ZCL
	
	
	'This assumes zip32.dll is in your \windows\system directory!
	'UPGRADE_WARNING: Structure ZIPUSERFUNCTIONS may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function ZpInit Lib "zip32.dll" (ByRef Zipfun As ZIPUSERFUNCTIONS) As Integer ' Set Zip Callbacks
	
	'UPGRADE_WARNING: Structure ZPOPT may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function ZpSetOptions Lib "zip32.dll" (ByRef Opts As ZPOPT) As Integer ' Set Zip options
	
	Private Declare Function ZpGetOptions Lib "zip32.dll" () As ZPOPT ' used to check encryption flag only
	
	'UPGRADE_WARNING: Structure ZIPnames may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function ZpArchive Lib "zip32.dll" (ByVal argc As Integer, ByVal funame As String, ByRef argv As ZIPnames) As Integer ' Real zipping action
	Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)
	
	Private uZipNumber As Short
	Private uZipMessage As String
	Private uZipInfo As String
	Private uVBSkip As Short
	Public msOutput As String
	
	
	' Puts a function pointer in a structure
	Function FnPtr(ByVal lp As Integer) As Integer
		FnPtr = lp
	End Function
	
	' Callback for zip32.dll
	Function DLLPrnt(ByRef fname As CBChar, ByVal x As Integer) As Integer
		Dim s0 As String
		Dim xx As Integer
		Dim sVbZipInf As String
		
		' always put this in callback routines!
		On Error Resume Next
		s0 = ""
		For xx = 0 To x
			If fname.ch(xx) = 0 Then xx = 99999 Else s0 = s0 & Chr(fname.ch(xx))
		Next xx
		
		Debug.Print(sVbZipInf & s0)
		msOutput = msOutput & s0
		
		sVbZipInf = ""
		
		System.Windows.Forms.Application.DoEvents()
		DLLPrnt = 0
		
	End Function
	
	' Callback for Zip32.dll ?
    Function DllServ(ByRef fname As CBChar, ByVal x As Integer) As Short

        Dim s0 As String
        Dim xx As Integer

        On Error Resume Next

        s0 = ""

        For xx = 0 To x - 1
            If fname.ch(xx) = 0 Then Exit For
            s0 = s0 & Chr(fname.ch(xx))
        Next

        DllServ = 0
    End Function
	
	' Callback for zip32.dll
    Function DllPass(ByRef s1 As Byte, ByRef x As Integer, ByRef s2 As Byte, ByRef s3 As Byte) As Short

        ' always put this in callback routines!
        On Error Resume Next
        ' not supported - always return 1
        DllPass = 1
    End Function
	
	' Callback for zip32.dll
    Function DllComm(ByRef s1 As CBChar) As CBChar

        ' always put this in callback routines!
        On Error Resume Next
        ' not supported always return \0
        s1.ch(0) = CByte(vbNullString)
        'UPGRADE_WARNING: Couldn't resolve default property of object DllComm. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        DllComm = s1
    End Function

    'Main Subroutine
    Public Function VBZip(ByRef argc As Short, ByRef zipname As String, ByRef mynames As ZIPnames, ByRef junk As Short, ByRef recurse As Short, ByRef updat As Short, ByRef freshen As Short, ByRef basename As String, Optional ByRef Encrypt As Short = 0, Optional ByRef IncludeSystem As Short = 0, Optional ByRef IgnoreDirectoryEntries As Short = 0, Optional ByRef Verbose As Short = 0, Optional ByRef Quiet As Short = 0, Optional ByRef CRLFtoLF As Short = 0, Optional ByRef LFtoCRLF As Short = 0, Optional ByRef Grow As Short = 0, Optional ByRef Force As Short = 0, Optional ByRef iMove As Short = 0, Optional ByRef DeleteEntries As Short = 0) As Integer

        Dim hmem As Integer
        Dim xx As Short
        Dim retcode As Integer
        Dim MYUSER As ZIPUSERFUNCTIONS
        Dim MYOPT As ZPOPT

        On Error Resume Next ' nothing will go wrong :-)

        msOutput = ""

        ' Set address of callback functions
        'UPGRADE_WARNING: Add a delegate for AddressOf DLLPrnt Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"'
        'MYUSER.DLLPrnt = FnPtr(AddressOf DLLPrnt)
        'UPGRADE_WARNING: Add a delegate for AddressOf DllPass Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"'
        'MYUSER.DLLPASSWORD = FnPtr(AddressOf DllPass)
        'UPGRADE_WARNING: Add a delegate for AddressOf DllComm Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"'
        'MYUSER.DLLCOMMENT = FnPtr(AddressOf DllComm)
        MYUSER.DLLSERVICE = 0 ' not coded yet :-)
        '    retcode = ZpInit(MYUSER)

        ' Set zip options
        MYOPT.fSuffix = 0 ' include suffixes (not yet implemented)
        MYOPT.fEncrypt = Encrypt ' 1 if encryption wanted
        MYOPT.fSystem = IncludeSystem ' 1 to include system/hidden files
        MYOPT.fVolume = 0 ' 1 if storing volume label
        MYOPT.fExtra = 0 ' 1 if including extra attributes
        MYOPT.fNoDirEntries = IgnoreDirectoryEntries ' 1 if ignoring directory entries
        MYOPT.fExcludeDate = 0 ' 1 if excluding files earlier than a specified date
        MYOPT.fIncludeDate = 0 ' 1 if including files earlier than a specified date
        MYOPT.fVerbose = Verbose ' 1 if full messages wanted
        MYOPT.fQuiet = Quiet ' 1 if minimum messages wanted
        MYOPT.fCRLF_LF = CRLFtoLF ' 1 if translate CR/LF to LF
        MYOPT.fLF_CRLF = LFtoCRLF ' 1 if translate LF to CR/LF
        MYOPT.fJunkDir = junk ' 1 if junking directory names
        MYOPT.fRecurse = recurse ' 1 if recursing into subdirectories
        MYOPT.fGrow = Grow ' 1 if allow appending to zip file
        MYOPT.fForce = Force ' 1 if making entries using DOS names
        MYOPT.fMove = iMove ' 1 if deleting files added or updated
        MYOPT.fDeleteEntries = DeleteEntries ' 1 if files passed have to be deleted
        MYOPT.fUpdate = updat ' 1 if updating zip file--overwrite only if newer
        MYOPT.fFreshen = freshen ' 1 if freshening zip file--overwrite only
        MYOPT.fJunkSFX = 0 ' 1 if junking sfx prefix
        MYOPT.fLatestTime = 0 ' 1 if setting zip file time to time of latest file in archive
        MYOPT.fComment = 0 ' 1 if putting comment in zip file
        MYOPT.fOffsets = 0 ' 1 if updating archive offsets for sfx Files
        MYOPT.fPrivilege = 0 ' 1 if not saving privelages
        MYOPT.fEncryption = 0 'Read only property!
        MYOPT.fRepair = 0 ' 1=> fix archive, 2=> try harder to fix
        MYOPT.flevel = 0 ' compression level - should be 0!!!
        MYOPT.date_Renamed = vbNullString ' "12/31/79"? US Date?
        MYOPT.szRootDir = UCase(basename)

        retcode = ZpInit(MYUSER)
        ' Set options
        retcode = ZpSetOptions(MYOPT)

        ' ZCL not needed in VB
        ' MYZCL.argc = 2
        ' MYZCL.filename = "c:\wiz\new.zip"
        ' MYZCL.fileArray = MYNAMES

        ' Go for it!

        retcode = ZpArchive(argc, zipname, mynames)

        VBZip = retcode
    End Function



    '-- Callback For UNZIP32.DLL - Receive Message Function
    Public Sub UZReceiveDLLMessage(ByVal ucsize As Integer, ByVal csiz As Integer, ByVal cfactor As Short, ByVal mo As Short, ByVal dy As Short, ByVal yr As Short, ByVal hh As Short, ByVal mm As Short, ByVal c As Byte, ByRef fname As UNZIPCBCh, ByRef meth As UNZIPCBCh, ByVal crc As Integer, ByVal fCrypt As Byte)

        Dim s0 As String
        Dim xx As Integer
        Dim strout As String

        '-- Always Put This In Callback Routines!
        On Error Resume Next

        '------------------------------------------------
        '-- This Is Where The Received Messages Are
        '-- Printed Out And Displayed.
        '-- You Can Modify Below!
        '------------------------------------------------

        strout = Space(80)

        '-- For Zip Message Printing
        If uZipNumber = 0 Then
            Mid(strout, 1, 50) = "Filename:"
            Mid(strout, 53, 4) = "Size"
            Mid(strout, 62, 4) = "Date"
            Mid(strout, 71, 4) = "Time"
            uZipMessage = strout & vbNewLine
            strout = Space(80)
        End If

        s0 = ""

        '-- Do Not Change This For Next!!!
        For xx = 0 To 255
            If fname.ch(xx) = 0 Then Exit For
            s0 = s0 & Chr(fname.ch(xx))
        Next

        '-- Assign Zip Information For Printing
        Mid(strout, 1, 50) = Mid(s0, 1, 50)
        Mid(strout, 51, 7) = Right("        " & Str(ucsize), 7)
        Mid(strout, 60, 3) = Right("0" & Trim(Str(mo)), 2) & "/"
        Mid(strout, 63, 3) = Right("0" & Trim(Str(dy)), 2) & "/"
        Mid(strout, 66, 2) = Right("0" & Trim(Str(yr)), 2)
        Mid(strout, 70, 3) = Right(Str(hh), 2) & ":"
        Mid(strout, 73, 2) = Right("0" & Trim(Str(mm)), 2)

        ' Mid(strout, 75, 2) = Right(" " & Str(cfactor), 2)
        ' Mid(strout, 78, 8) = Right("        " & Str(csiz), 8)
        ' s0 = ""
        ' For xx = 0 To 255
        '     If meth.ch(xx) = 0 Then exit for
        '     s0 = s0 & Chr(meth.ch(xx))
        ' Next xx

        '-- Do Not Modify Below!!!
        uZipMessage = uZipMessage & strout & vbNewLine
        uZipNumber = uZipNumber + 1

    End Sub

    '-- Callback For UNZIP32.DLL - Print Message Function
    Public Function UZDLLPrnt(ByRef fname As UNZIPCBChar, ByVal x As Integer) As Integer

        Dim s0 As String
        Dim xx As Integer

        '-- Always Put This In Callback Routines!
        On Error Resume Next

        s0 = ""

        '-- Gets The UNZIP32.DLL Message For Displaying.
        For xx = 0 To x - 1
            If fname.ch(xx) = 0 Then Exit For
            s0 = s0 & Chr(fname.ch(xx))
        Next

        '-- Assign Zip Information
        If Mid(s0, 1, 1) = vbLf Then s0 = vbNewLine ' Damn UNIX :-)
        uZipInfo = uZipInfo & s0

        msOutput = uZipInfo

        UZDLLPrnt = 0

    End Function

    '-- Callback For UNZIP32.DLL - DLL Service Function
    Public Function UZDLLServ(ByRef mname As UNZIPCBChar, ByVal x As Integer) As Integer

        Dim s0 As String
        Dim xx As Integer

        '-- Always Put This In Callback Routines!
        On Error Resume Next

        s0 = ""
        '-- Get Zip32.DLL Message For processing
        For xx = 0 To x - 1
            If mname.ch(xx) = 0 Then Exit For
            s0 = s0 & Chr(mname.ch(xx))
        Next
        ' At this point, s0 contains the message passed from the DLL
        ' It is up to the developer to code something useful here :)
        UZDLLServ = 0 ' Setting this to 1 will abort the zip!

    End Function

    '-- Callback For UNZIP32.DLL - Password Function
    Public Function UZDLLPass(ByRef p As UNZIPCBCh, ByVal n As Integer, ByRef m As UNZIPCBCh, ByRef Name As UNZIPCBCh) As Short

        Dim prompt As String
        Dim xx As Short
        Dim szpassword As String

        '-- Always Put This In Callback Routines!
        On Error Resume Next

        UZDLLPass = 1

        If uVBSkip = 1 Then Exit Function

        '-- Get The Zip File Password
        szpassword = InputBox("Please Enter The Password!")

        '-- No Password So Exit The Function
        If szpassword = "" Then
            uVBSkip = 1
            Exit Function
        End If

        '-- Zip File Password So Process It
        For xx = 0 To 255
            If m.ch(xx) = 0 Then
                Exit For
            Else
                prompt = prompt & Chr(m.ch(xx))
            End If
        Next

        For xx = 0 To n - 1
            p.ch(xx) = 0
        Next

        For xx = 0 To Len(szpassword) - 1
            p.ch(xx) = Asc(Mid(szpassword, xx + 1, 1))
        Next

        p.ch(xx) = CByte(AscW(0)) ' Put Null Terminator For C

        UZDLLPass = 0

    End Function

    '-- Callback For UNZIP32.DLL - Report Function To Overwrite Files.
    '-- This Function Will Display A MsgBox Asking The User
    '-- If They Would Like To Overwrite The Files.
    Public Function UZDLLRep(ByRef fname As UNZIPCBChar) As Integer

        Dim s0 As String
        Dim xx As Integer

        '-- Always Put This In Callback Routines!
        On Error Resume Next

        UZDLLRep = 100 ' 100 = Do Not Overwrite - Keep Asking User
        s0 = ""

        For xx = 0 To 255
            If fname.ch(xx) = 0 Then xx = 99999 Else s0 = s0 & Chr(fname.ch(xx))
        Next

        '-- This Is The MsgBox Code
        xx = MsgBox("Overwrite " & s0 & "?", CDbl(MsgBoxStyle.Exclamation & MsgBoxStyle.YesNoCancel), "VBUnZip32 - File Already Exists!")

        If xx = MsgBoxResult.No Then Exit Function

        If xx = MsgBoxResult.Cancel Then
            UZDLLRep = 104 ' 104 = Overwrite None
            Exit Function
        End If

        UZDLLRep = 102 ' 102 = Overwrite 103 = Overwrite All

    End Function

    '-- ASCIIZ To String Function
    Public Function szTrim(ByRef szString As String) As String

        Dim pos As Short
        Dim ln As Short

        pos = InStr(szString, Chr(0))
        ln = Len(szString)

        Select Case pos
            Case Is > 1
                szTrim = Trim(Left(szString, pos - 1))
            Case 1
                szTrim = ""
            Case Else
                szTrim = Trim(szString)
        End Select

    End Function


    Public Function VBUnzip(ByRef sZipFileName As Object, ByRef sUnzipDirectory As String, ByRef iExtractNewer As Short, ByRef iSpaceUnderScore As Short, ByRef iPromptOverwrite As Short, ByRef iQuiet As Short, ByRef iWriteStdOut As Short, ByRef iTestZip As Short, ByRef iExtractList As Short, ByRef iExtractOnlyNewer As Short, ByRef iDisplayComment As Short, ByRef iHonorDirectories As Short, ByRef iOverwriteFiles As Short, ByRef iConvertCR_CRLF As Short, ByRef iVerbose As Short, ByRef iCaseSensitivty As Short, ByRef iPrivilege As Short) As Integer


        On Error GoTo vbErrorHandler


        Dim lRet As Integer

        Dim UZDCL As DCLIST
        Dim UZUSER As USERFUNCTION
        'UPGRADE_WARNING: Arrays in structure UZVER may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        Dim UZVER As UZPVER
        'UPGRADE_WARNING: Arrays in structure uExcludeNames may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        Dim uExcludeNames As UNZIPnames
        'UPGRADE_WARNING: Arrays in structure uZipNames may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        Dim uZipNames As UNZIPnames

        msOutput = ""

        uExcludeNames.uzFiles(0) = vbNullString
        uZipNames.uzFiles(0) = vbNullString

        uZipNumber = 0
        uZipMessage = vbNullString
        uZipInfo = vbNullString
        uVBSkip = 0

        With UZDCL
            .ExtractOnlyNewer = iExtractOnlyNewer
            .SpaceToUnderScore = iSpaceUnderScore
            .PromptToOverwrite = iPromptOverwrite
            .fQuiet = iQuiet
            .ncflag = iWriteStdOut
            .ntflag = iTestZip
            .nvflag = iExtractList
            .nUflag = iExtractNewer
            .nzflag = iDisplayComment
            .ndflag = iHonorDirectories
            .noflag = iOverwriteFiles
            .naflag = iConvertCR_CRLF
            .nZIflag = iVerbose
            .C_flag = iCaseSensitivty
            .fPrivilege = iPrivilege
            'UPGRADE_WARNING: Couldn't resolve default property of object sZipFileName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .Zip = sZipFileName
            .ExtractDir = sUnzipDirectory
        End With

        With UZUSER
            'UPGRADE_WARNING: Add a delegate for AddressOf UZDLLPrnt Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"'
            '.UZDLLPrnt = FnPtr(AddressOf UZDLLPrnt)
            .UZDLLSND = 0
            'UPGRADE_WARNING: Add a delegate for AddressOf UZDLLRep Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"'
            '.UZDLLREPLACE = FnPtr(AddressOf UZDLLRep)
            'UPGRADE_WARNING: Add a delegate for AddressOf UZDLLPass Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"'
            '.UZDLLPASSWORD = FnPtr(AddressOf UZDLLPass)
            'UPGRADE_WARNING: Add a delegate for AddressOf UZReceiveDLLMessage Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"'
            '.UZDLLMESSAGE = FnPtr(AddressOf UZReceiveDLLMessage)
            'UPGRADE_WARNING: Add a delegate for AddressOf UZDLLServ Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"'
            '.UZDLLSERVICE = FnPtr(AddressOf UZDLLServ)
        End With

        With UZVER
            .structlen = Len(UZVER)
            .beta = Space(9) & vbNullChar
            .date_Renamed = Space(19) & vbNullChar
            .zlib = Space(9) & vbNullChar
        End With

        UzpVersion2(UZVER)

        lRet = Wiz_SingleEntryUnzip(0, uZipNames, 0, uExcludeNames, UZDCL, UZUSER)
        VBUnzip = lRet


        Exit Function

vbErrorHandler:
        Err.Raise(Err.Number, "CodeModule::VBUnzip", Err.Description)

    End Function
End Module