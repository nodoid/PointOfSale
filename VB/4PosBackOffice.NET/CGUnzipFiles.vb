Option Strict Off
Option Explicit On
Friend Class CGUnzipFiles
	'
	' UnZip Class
	'
	' Chris Eastwood July 1999
	'
	Public Enum ZMessageLevel
		All = 0
		Less = 1
		NoMessages = 2
	End Enum
	Public Enum ZExtractType
		Extract = 0
		ListContents = 1
	End Enum
	Public Enum ZPrivilege
		Ignore = 0
		ACL = 1
		Privileges = 2
	End Enum
	
	Private miExtractNewer As Short ' 1 = Extract Only Newer, Else 0
	Private miSpaceUnderScore As Short ' 1 = Convert Space To Underscore, Else 0
	Private miPromptOverwrite As Short ' 1 = Prompt To Overwrite Required, Else 0
	Private miQuiet As ZMessageLevel ' 2 = No Messages, 1 = Less, 0 = All
	Private miWriteStdOut As Short ' 1 = Write To Stdout, Else 0
	Private miTestZip As Short ' 1 = Test Zip File, Else 0
	Private miExtractList As ZExtractType ' 0 = Extract, 1 = List Contents
	Private miExtractOnlyNewer As Short ' 1 = Extract Only Newer, Else 0
	Private miDisplayComment As Short ' 1 = Display Zip File Comment, Else 0
	Private miHonorDirectories As Short ' 1 = Honor Directories, Else 0
	Private miOverWriteFiles As Short ' 1 = Overwrite Files, Else 0
	Private miConvertCR_CRLF As Short ' 1 = Convert CR To CRLF, Else 0
	Private miVerbose As Short ' 1 = Zip Info Verbose
	Private miCaseSensitivity As Short ' 1 = Case Insensitivity, 0 = Case Sensitivity
	Private miPrivilege As ZPrivilege ' 1 = ACL, 2 = Privileges, Else 0
	Private msZipFileName As String ' The Zip File Name
	Private msExtractDir As String ' Extraction Directory, Null If Current Directory
	
	
	Public Property ExtractNewer() As Boolean
		Get
			ExtractNewer = miExtractNewer = 1
		End Get
		Set(ByVal Value As Boolean)
			miExtractNewer = IIf(Value, 1, 0)
		End Set
	End Property
	
	
	Public Property SpaceToUnderScore() As Boolean
		Get
			SpaceToUnderScore = miSpaceUnderScore = 1
		End Get
		Set(ByVal Value As Boolean)
			miSpaceUnderScore = IIf(Value, 1, 0)
		End Set
	End Property
	
	
	Public Property PromptOverwrite() As Boolean
		Get
			PromptOverwrite = miPromptOverwrite = 1
		End Get
		Set(ByVal Value As Boolean)
			miPromptOverwrite = IIf(Value, 1, 0)
		End Set
	End Property
	
	
	Public Property MessageLevel() As ZMessageLevel
		Get
			MessageLevel = miQuiet
		End Get
		Set(ByVal Value As ZMessageLevel)
			miQuiet = Value
		End Set
	End Property
	
	
	Public Property WriteToStdOut() As Boolean
		Get
			WriteToStdOut = miWriteStdOut = 1
		End Get
		Set(ByVal Value As Boolean)
			miWriteStdOut = IIf(Value, 1, 0)
		End Set
	End Property
	
	
	Public Property TestZip() As Boolean
		Get
			TestZip = miTestZip = 1
		End Get
		Set(ByVal Value As Boolean)
			miTestZip = IIf(Value, 1, 0)
		End Set
	End Property
	
	
	Public Property ExtractList() As ZExtractType
		Get
			ExtractList = miExtractList
		End Get
		Set(ByVal Value As ZExtractType)
			miExtractList = Value
		End Set
	End Property
	
	
	Public Property ExtractOnlyNewer() As Boolean
		Get
			ExtractOnlyNewer = miExtractOnlyNewer = 1
		End Get
		Set(ByVal Value As Boolean)
			miExtractOnlyNewer = IIf(Value, 1, 0)
		End Set
	End Property
	
	
	Public Property DisplayComment() As Boolean
		Get
			DisplayComment = miDisplayComment = 1
		End Get
		Set(ByVal Value As Boolean)
			miDisplayComment = IIf(Value, 1, 0)
		End Set
	End Property
	
	
	Public Property HonorDirectories() As Boolean
		Get
			HonorDirectories = miHonorDirectories = 1
		End Get
		Set(ByVal Value As Boolean)
			miHonorDirectories = IIf(Value, 1, 0)
		End Set
	End Property
	
	
	Public Property OverWriteFiles() As Boolean
		Get
			OverWriteFiles = miOverWriteFiles = 1
		End Get
		Set(ByVal Value As Boolean)
			miOverWriteFiles = IIf(Value, 1, 0)
		End Set
	End Property
	
	
	Public Property ConvertCRtoCRLF() As Boolean
		Get
			ConvertCRtoCRLF = miConvertCR_CRLF = 1
		End Get
		Set(ByVal Value As Boolean)
			miConvertCR_CRLF = IIf(Value, 1, 0)
		End Set
	End Property
	
	
	Public Property Verbose() As Boolean
		Get
			Verbose = miVerbose = 1
		End Get
		Set(ByVal Value As Boolean)
			miVerbose = IIf(Value, 1, 0)
		End Set
	End Property
	
	
	Public Property CaseSensitive() As Boolean
		Get
			CaseSensitive = miCaseSensitivity = 1
		End Get
		Set(ByVal Value As Boolean)
			miCaseSensitivity = IIf(Value, 1, 0)
		End Set
	End Property
	
	
	Public Property Privilege() As ZPrivilege
		Get
			Privilege = miPrivilege
		End Get
		Set(ByVal Value As ZPrivilege)
			miPrivilege = Value
		End Set
	End Property
	
	
	Public Property ZipFileName() As String
		Get
			ZipFileName = msZipFileName
		End Get
		Set(ByVal Value As String)
			msZipFileName = Value
		End Set
	End Property
	
	
	Public Property ExtractDir() As String
		Get
			ExtractDir = msExtractDir
		End Get
		Set(ByVal Value As String)
			msExtractDir = Value
		End Set
	End Property
	
	Public Function Unzip(Optional ByRef sZipFileName As String = "", Optional ByRef sExtractDir As String = "") As Integer
		
		On Error GoTo vbErrorHandler
		
		Dim lRet As Integer
		
		If Len(sZipFileName) > 0 Then
			msZipFileName = sZipFileName
		End If
		
		If Len(sExtractDir) > 0 Then
			msExtractDir = sExtractDir
		End If
		
		
		lRet = VBUnzip(msZipFileName, msExtractDir, miExtractNewer, miSpaceUnderScore, miPromptOverwrite, CShort(miQuiet), miWriteStdOut, miTestZip, CShort(miExtractList), miExtractOnlyNewer, miDisplayComment, miHonorDirectories, miOverWriteFiles, miConvertCR_CRLF, miVerbose, miCaseSensitivity, CShort(miPrivilege))
		
		Unzip = lRet
		
		Exit Function
		
vbErrorHandler: 
		Err.Raise(Err.Number, "CGUnZipFiles::Unzip", Err.Description)
		
	End Function
	
	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Initialize_Renamed()
		miExtractNewer = 0
		miSpaceUnderScore = 0
		miPromptOverwrite = 0
		miQuiet = ZMessageLevel.NoMessages
		miWriteStdOut = 0
		miTestZip = 0
		miExtractList = ZExtractType.Extract
		miExtractOnlyNewer = 0
		miDisplayComment = 0
		miHonorDirectories = 1
		miOverWriteFiles = 1
		miConvertCR_CRLF = 0
		miVerbose = 0
		miCaseSensitivity = 1
		miPrivilege = ZPrivilege.Ignore
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	
	Public Function GetLastMessage() As String
		GetLastMessage = msOutput
	End Function
End Class