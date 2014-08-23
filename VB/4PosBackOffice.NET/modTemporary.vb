Option Strict Off
Option Explicit On
Module modTemporary
	Private Const vbDot As Short = 46
	Private Const MAX_PATH As Short = 260
	Private Const INVALID_HANDLE_VALUE As Short = -1
	Private Const vbBackslash As String = "\"
	'Private Const ALL_FILES = "*.*"
	Private Const ALL_FILES As String = "*.tmp"
	
	Private Structure FILETIME
		Dim dwLowDateTime As Integer
		Dim dwHighDateTime As Integer
	End Structure
	
	Private Structure WIN32_FIND_DATA
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
	
	Private Structure FILE_PARAMS
		Dim bRecurse As Boolean
		Dim nCount As Integer
		Dim nSearched As Integer
		Dim sFileNameExt As String
		Dim sFileRoot As String
	End Structure
	
	Private Declare Function FindClose Lib "kernel32" (ByVal hFindFile As Integer) As Integer
	
	'UPGRADE_WARNING: Structure WIN32_FIND_DATA may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function FindFirstFile Lib "kernel32"  Alias "FindFirstFileA"(ByVal lpFileName As String, ByRef lpFindFileData As WIN32_FIND_DATA) As Integer
	
	'UPGRADE_WARNING: Structure WIN32_FIND_DATA may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function FindNextFile Lib "kernel32"  Alias "FindNextFileA"(ByVal hFindFile As Integer, ByRef lpFindFileData As WIN32_FIND_DATA) As Integer
	
	Private Declare Function GetTickCount Lib "kernel32" () As Integer
	
	Private Declare Function lstrlen Lib "kernel32"  Alias "lstrlenW"(ByVal lpString As Integer) As Integer
	
	Private Declare Function PathMatchSpec Lib "shlwapi"  Alias "PathMatchSpecW"(ByVal pszFileParam As Integer, ByVal pszSpec As Integer) As Integer
	
	Private fp As FILE_PARAMS 'holds search parameters
	
	Private Const LVM_FIRST As Integer = &H1000
	
	Private Declare Function DeleteFile Lib "kernel32"  Alias "DeleteFileA"(ByVal lpFileName As String) As Integer
	
	Dim CancelSearch As Boolean
	Private Function MatchSpec(ByRef sFile As String, ByRef sSpec As String) As Boolean
        'UPGRADE_ISSUE: VarPtr.VarPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
        MatchSpec = PathMatchSpec(VarPtr.VarPtr(sFile), VarPtr.VarPtr(sSpec))

    End Function
    Private Function TrimNull(ByRef startstr As String) As String
        'UPGRADE_ISSUE: VarPtr.VarPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
        TrimNull = Left(startstr, lstrlen(VarPtr.VarPtr(startstr)))
    End Function
	Private Function QualifyPath(ByRef sPath As String) As String
		If Right(sPath, 1) <> vbBackslash Then QualifyPath = sPath & vbBackslash Else QualifyPath = sPath
	End Function
	
	Private Sub SearchForFiles(ByRef sRoot As String)
		Dim oFileSys As New Scripting.FileSystemObject
		Dim oFile As Scripting.TextStream
		Dim WFD As WIN32_FIND_DATA
		Dim hFile As Integer
		
		On Error Resume Next
		
		hFile = FindFirstFile(sRoot & ALL_FILES, WFD)
		
		If hFile <> INVALID_HANDLE_VALUE Then
			FileOpen(1, "C:\WriTMP.txt", OpenMode.Output)
			Do 
				If CancelSearch = True Then Exit Sub
				If MatchSpec(WFD.cFileName, fp.sFileNameExt) Then
					PrintLine(1, sRoot & TrimNull(WFD.cFileName))
				End If 'If MatchSpec
				
			Loop While FindNextFile(hFile, WFD)
			
		End If 'If hFile
		
		Call FindClose(hFile)
		FileClose(1)
		
		oFile = oFileSys.OpenTextFile("C:\WriTMP.txt", Scripting.IOMode.ForReading, False, Scripting.Tristate.TristateUseDefault)
		
		Dim FileNum As Integer
		While Not oFile.AtEndOfLine
			If DeleteFile(oFile.ReadLine) = 0 Then
				FileNum = FreeFile
				FileOpen(FileNum, My.Application.Info.DirectoryPath & "\log.txt", OpenMode.Binary, OpenAccess.Write)
				'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FilePut(FileNum, oFile.ReadLine & vbCrLf)
				FileClose(FileNum)
			End If
		End While
		
	End Sub
	
	Public Sub DeleteTempFiles()
		
		With fp
			.sFileRoot = QualifyPath("C:\") 'start path
			.sFileNameExt = "*.tmp;"
			.bRecurse = True 'True = recursive search
			.nCount = 0 'results
			.nSearched = 0 'results
		End With
		
		Call SearchForFiles(fp.sFileRoot)
		
	End Sub
End Module