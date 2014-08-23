Option Strict Off
Option Explicit On
Friend Class CGZipFiles
	'
	'
	' Chris Eastwood July 1999 - adapted from code at the
	' InfoZip homepage.
	'
	Public Enum ZTranslate
		CRLFtoLF = 1
		LFtoCRLF = 2
	End Enum
	'
	' Collection of Files to Zip
	'
	Private mCollection As Collection
	'
	' Recurse Folders ?
	'
	Private miRecurseFolders As Short
	'
	' Zip File Name
	'
	Private msZipFileName As String
	'
	' Encryption ?
	'
	Private miEncrypt As Short
	'
	' System Files
	'
	Private miSystem As Short
	'
	' Root Directory
	'
	Private msRootDirectory As String
	'
	' Verbose Zip
	'
	Private miVerbose As Short
	'
	' Quiet Zip
	'
	Private miQuiet As Short
	'
	' Translate CRLF / LF Chars
	'
	Private miTranslateCRLF As ZTranslate
	'
	' Updating Existing Zip ?
	'
	Private miUpdateZip As Short
	
	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Initialize_Renamed()
		'
		' Initialise the collection
		'
		mCollection = New Collection
		'
		' We have to add in a dummy file into the collection because
		' the Zip routines fall over otherwise.
		'
		' I think this is a bug, but it's not documented anywhere
		' on the InfoZip website.
		'
		' The Zip process *always* fails on the first file,
		' regardless of whether it's a valid file or not!
		'
		mCollection.Add("querty", "querty")
		miEncrypt = 0
		miSystem = 0
		msRootDirectory = "\"
		miQuiet = 0
		miUpdateZip = 0
		
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	
	'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Terminate_Renamed()
		'
		' Terminate the collection
		'
		'UPGRADE_NOTE: Object mCollection may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mCollection = Nothing
	End Sub
	Protected Overrides Sub Finalize()
		Class_Terminate_Renamed()
		MyBase.Finalize()
	End Sub
	
	
	Public Property RecurseFolders() As Boolean
		Get
			RecurseFolders = miRecurseFolders = 1
		End Get
		Set(ByVal Value As Boolean)
			miRecurseFolders = IIf(Value, 1, 0)
		End Set
	End Property
	
	
	Public Property ZipFileName() As String
		Get
			ZipFileName = msZipFileName
		End Get
		Set(ByVal Value As String)
			msZipFileName = Value '& vbNullChar
		End Set
	End Property
	
	
	Public Property Encrypted() As Boolean
		Get
			Encrypted = miEncrypt = 1
		End Get
		Set(ByVal Value As Boolean)
			miEncrypt = IIf(Value, 1, 0)
		End Set
	End Property
	
	
	Public Property IncludeSystemFiles() As Boolean
		Get
			IncludeSystemFiles = miSystem = 1
		End Get
		Set(ByVal Value As Boolean)
			miSystem = IIf(Value, 1, 0)
		End Set
	End Property
	
	Public ReadOnly Property ZipFileCount() As Integer
		Get
			If mCollection Is Nothing Then
				ZipFileCount = 0
			Else
				ZipFileCount = mCollection.Count() - 1
			End If
		End Get
	End Property
	
	
	
	Public Property RootDirectory() As String
		Get
			RootDirectory = msRootDirectory
		End Get
		Set(ByVal Value As String)
			msRootDirectory = Value ' & vbNullChar
		End Set
	End Property
	
	
	Public Property UpdatingZip() As Boolean
		Get
			UpdatingZip = miUpdateZip = 1
		End Get
		Set(ByVal Value As Boolean)
			miUpdateZip = IIf(Value, 1, 0)
		End Set
	End Property
	
	Public Function AddFile(ByVal sFileName As String) As Object
		Dim lCount As Integer
		Dim sFile As String
		
		On Error Resume Next
		
		'UPGRADE_WARNING: Couldn't resolve default property of object mCollection.Item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		sFile = mCollection.Item(sFileName)
		
		If Len(sFile) = 0 Then
			Err.Clear()
			On Error GoTo 0
			mCollection.Add(sFileName, sFileName)
		Else
			On Error GoTo 0
			Err.Raise(vbObjectError + 2001, "CGZip::AddFile", "File is already in Zip List")
		End If
		
	End Function
	
	Public Function RemoveFile(ByVal sFileName As String) As Object
		Dim lCount As Integer
		Dim sFile As String
		
		On Error Resume Next
		
		'UPGRADE_WARNING: Couldn't resolve default property of object mCollection.Item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		sFile = mCollection.Item(sFileName)
		
		If Len(sFile) = 0 Then
			Err.Raise(vbObjectError + 2002, "CGZip::RemoveFile", "File is not in Zip List")
		Else
			mCollection.Remove(sFileName)
		End If
		
	End Function
	
	Public Function MakeZipFile() As Integer
		'UPGRADE_WARNING: Arrays in structure zFileArray may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim zFileArray As ZIPnames
		Dim sFileName As Object
		Dim lFileCount As Integer
		Dim iIgnorePath As Short
		Dim iRecurse As Short
		
		On Error GoTo vbErrorHandler
		
		
		
		lFileCount = 0
		
		For	Each sFileName In mCollection
			'UPGRADE_WARNING: Couldn't resolve default property of object sFileName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			zFileArray.s(lFileCount) = sFileName
			lFileCount = lFileCount + 1
		Next sFileName
		
		
		MakeZipFile = VBZip(CShort(lFileCount), msZipFileName, zFileArray, iIgnorePath, miRecurseFolders, miUpdateZip, 0, msRootDirectory)
		
		
		Exit Function
		
vbErrorHandler: 
		MakeZipFile = -99
		Err.Raise(Err.Number, "CGZipFiles::MakeZipFile", Err.Description)
		
	End Function
	
	Public Function GetLastMessage() As String
		GetLastMessage = msOutput
	End Function
End Class