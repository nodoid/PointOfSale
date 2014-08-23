Option Strict Off
Option Explicit On
Friend Class clsFileIni
	
#If Win16 Then
	'UPGRADE_NOTE: #If #EndIf block was not upgraded because the expression Win16 did not evaluate to True or was not evaluated. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"'
	Private Declare Function WritePrivateProfileString Lib "KERNEL" (ByVal AppName As String, ByVal KeyName As String, ByVal keydefault As String, ByVal FileName As String) As Integer
	Private Declare Function GetPrivateProfileString Lib "KERNEL" (ByVal AppName As String, ByVal KeyName As String, ByVal keydefault As String, ByVal ReturnString As String, ByVal NumBytes As Integer, ByVal FileName As String) As Integer
#Else
	Private Declare Function WritePrivateProfileString Lib "kernel32"  Alias "WritePrivateProfileStringA"(ByVal AppName As String, ByVal KeyName As String, ByVal keydefault As String, ByVal FileName As String) As Integer
	Private Declare Function GetPrivateProfileString Lib "kernel32"  Alias "GetPrivateProfileStringA"(ByVal AppName As String, ByVal KeyName As String, ByVal keydefault As String, ByVal ReturnString As String, ByVal NumBytes As Integer, ByVal FileName As String) As Integer
#End If
	
	Private m_strFileINI As String
	Private m_strSection As String
	Private m_strKey As String
	Private m_strDescription As String
	
	'Costant
	Private Const BufSize As Short = 255
	
	
	
	Public Property FileINI() As String
		Get
			
			FileINI = m_strFileINI
			
		End Get
		Set(ByVal Value As String)
			
			m_strFileINI = Value
			
		End Set
	End Property
	
	Public Property section() As String
		Get
			
			section = m_strSection
			
		End Get
		Set(ByVal Value As String)
			
			m_strSection = Value
			
		End Set
	End Property
	
	
	Public Property Key() As String
		Get
			
			Key = m_strKey
			
		End Get
		Set(ByVal Value As String)
			
			m_strKey = Value
			
		End Set
	End Property
	
	
	Public Property Description() As String
		Get
			
			Description = m_strDescription
			
		End Get
		Set(ByVal Value As String)
			
			m_strDescription = Value
			
		End Set
	End Property
	
	
	Public Sub AddToINI()
		Dim rc As Integer
		
		rc = WritePrivateProfileString(m_strSection, m_strKey, m_strDescription, m_strFileINI)
		
	End Sub
	
	Public Function ReadFromINI() As String
		Dim rc As Integer
		Dim RetStr As String
		
		RetStr = Space(BufSize)
		rc = GetPrivateProfileString(m_strSection, m_strKey, "Not Found", RetStr, BufSize, m_strFileINI)
		
		RetStr = Left(RetStr, rc)
		If RetStr = "Not Found" Then
			m_strDescription = "Not Found"
		Else
			m_strDescription = RetStr
		End If
		
		ReadFromINI = m_strDescription
	End Function
End Class