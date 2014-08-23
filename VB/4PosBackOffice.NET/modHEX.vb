Option Strict Off
Option Explicit On
Module modHEX
	
	Private m_InitHex As Boolean
	Private m_ByteToHex(255, 1) As Byte
	'UPGRADE_WARNING: Lower bound of array m_HexToByte was changed from 48,48 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Private m_HexToByte(70, 70) As Byte
	
    Private Declare Sub FillMemory Lib "kernel32.dll" Alias "RtlFillMemory" (ByRef Destination As Object, ByVal Length As Integer, ByVal Fill As Byte)
	
	Public Function HexToStr(ByRef HexText As String, Optional ByVal Separators As Integer = 1) As String
		
		Dim a As Integer
		Dim Pos As Integer
		Dim PosAdd As Integer
		Dim ByteSize As Integer
		Dim HexByte() As Byte
		Dim byteArray() As Byte
		
		'Initialize the hex routine
		If (Not m_InitHex) Then Call InitHex()
		
		'The destination string is half
		'the size of the source string
		'when the separators are removed
		If (Len(HexText) = 2) Then
			ByteSize = 1
		Else
			ByteSize = ((Len(HexText) + 1) \ (2 + Separators))
		End If
		ReDim byteArray(ByteSize - 1)
		
		'Convert every HEX code to the
		'equivalent ASCII character
		PosAdd = 2 + Separators
        HexByte = System.Text.UnicodeEncoding.Unicode.GetBytes(StrConv(HexText, vbUnicode(HexText)))
		For a = 0 To (ByteSize - 1)
			byteArray(a) = m_HexToByte(HexByte(Pos), HexByte(Pos + 1))
			Pos = Pos + PosAdd
		Next 
		
		'Now finally convert the byte
        'array to the return string
        HexToStr = System.Text.Encoding.UTF8.GetString(byteArray)
		
	End Function
	Private Sub InitHex()
		Dim a As Integer
		Dim HexBytes() As Byte
		Dim HexString As String
		
		'The routine is initialized
		m_InitHex = True
		
		'Create a string with all hex values
		HexString = New String("0", 512)
		For a = 1 To 255
			Mid(HexString, 1 + a * 2 - CShort(a < 16)) = Hex(a)
		Next 
        HexBytes = System.Text.UnicodeEncoding.Unicode.GetBytes(StrConv(HexString, vbUnicode(HexString)))
		
		'Create the Str->Hex array
		For a = 0 To 255
			m_ByteToHex(a, 0) = HexBytes(a * 2)
			m_ByteToHex(a, 1) = HexBytes(a * 2 + 1)
		Next 
		
		'Create the Str->Hex array
		For a = 0 To 255
			m_HexToByte(m_ByteToHex(a, 0), m_ByteToHex(a, 1)) = a
		Next 
	End Sub
	Public Function StrToHex(ByRef Text As String, Optional ByRef Separator As String = " ") As String
		
		Dim a As Integer
		Dim Pos As Integer
		Dim PosAdd As Integer
		Dim ByteSize As Integer
		Dim byteArray() As Byte
		Dim ByteReturn() As Byte
		Dim SeparatorLen As Integer
		
		'Initialize the hex routine
		If (Not m_InitHex) Then Call InitHex()
		
		'Initialize variables
		SeparatorLen = Len(Separator)
		
		'Create the destination bytearray, this
		'will be converted to a string later
		ByteSize = (Len(Text) * 2 + (Len(Text) - 1) * SeparatorLen)
		ReDim ByteReturn(ByteSize - 1)
		Call FillMemory(ByteReturn(0), ByteSize, AscW(Separator))
		
		'We convert the source string into a
		'byte array to speed this up a tad
		'UPGRADE_ISSUE: Constant vbFromUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		'UPGRADE_TODO: Code was upgraded to use System.Text.UnicodeEncoding.Unicode.GetBytes() which may not have the same behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"'
        byteArray = System.Text.UnicodeEncoding.Unicode.GetBytes(StrConv(Text, vbUnicode(Text)))
		
		'Now convert every character to
		'it's equivalent HEX code
		PosAdd = 2 + SeparatorLen
		For a = 0 To (Len(Text) - 1)
			ByteReturn(Pos) = m_ByteToHex(byteArray(a), 0)
			ByteReturn(Pos + 1) = m_ByteToHex(byteArray(a), 1)
			Pos = Pos + PosAdd
		Next 
		
		'Convert the bytearray to a string
		StrToHex = System.Text.Encoding.UTF8.GetString(ByteReturn)
	End Function
End Module