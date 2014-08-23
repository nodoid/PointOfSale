Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Module modBarcode
	Public twipsToMM As Integer
	Public gLabelName As String
	Public gLabelColumns As Integer
	Public gLabelLeft As Integer
	Public gLabelHeight As Integer
	Public gLabelWidth As Integer
	Function doImage(ByRef code As Object, ByRef size As Object) As String
		Dim lXML As String
		Dim lCode As String
		Dim i As Short
		For i = 1 To Len(code)
			'UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lCode = Left(code, i)
			lCode = Right(lCode, 1)
			If lCode = "0" Then
				lXML = lXML & System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White) & "~"
			Else
				lXML = lXML & System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black) & "~"
			End If
			If (size) Then
				lXML = lXML & 30 & "|"
			Else
				lXML = lXML & 25 & "|"
			End If
		Next 
		doImage = lXML
	End Function
	
	Private Function doCheckSum(ByRef value As Object) As Object
		Dim lAmount As Short
		Dim code As String
		Dim i As Short
		'UPGRADE_WARNING: Couldn't resolve default property of object value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If InStr(value, ".") Then
			'UPGRADE_WARNING: Couldn't resolve default property of object doCheckSum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			doCheckSum = False
		Else
			If IsNumeric(value) Then
				lAmount = 0
				For i = 1 To Len(value) - 1
					'UPGRADE_WARNING: Couldn't resolve default property of object value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					code = Left(value, i)
					code = Right(code, 1)
					If i Mod 2 Then
						lAmount = lAmount + CShort(code)
					Else
						lAmount = lAmount + CShort(code) * 3
					End If
				Next 
				lAmount = 10 - (lAmount Mod 10)
				If lAmount = 10 Then lAmount = 0
				'UPGRADE_WARNING: Couldn't resolve default property of object value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object doCheckSum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				doCheckSum = lAmount = CShort(Right(value, 1))
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object doCheckSum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				doCheckSum = False
			End If
		End If
	End Function
	
	
	
	Public Sub printBarcode(ByRef barcodePicture As Object, ByRef lHeading As Object, ByRef lValue As Object, ByRef lFooter As Object, ByRef lLeft As Integer, ByRef lTop As Integer, ByRef lWidth As Integer, Optional ByRef noCode As Boolean = False, Optional ByRef headingMain1 As String = "", Optional ByRef headingMain2 As String = "")
        Dim BF As String
		Dim Printer As New Printer
        Dim x As Short
		Dim y As Short
		Dim lXML As String
        Dim lastArray, oddArray, evenArray, parityArray As String()
        Dim lString, codeType, code, lCode, HeadingString1 As String
		Dim HeadingString2 As String
        Dim i, j As Short
		Dim cnt As Short
        Dim barArray As String()
		lXML = ""
		'UPGRADE_WARNING: Couldn't resolve default property of object doCheckSum(lValue). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If doCheckSum(lValue) Then
			'UPGRADE_WARNING: Array has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			'UPGRADE_WARNING: Couldn't resolve default property of object oddArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            oddArray = New String() {"0001101", "0011001", "0010011", "0111101", "0100011", "0110001", "0101111", "0111011", "0110111", "0001011"}
			'UPGRADE_WARNING: Array has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			'UPGRADE_WARNING: Couldn't resolve default property of object evenArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            evenArray = New String() {"0100111", "0110011", "0011011", "0100001", "0011101", "0111001", "0000101", "0010001", "0001001", "0010111"}
			'UPGRADE_WARNING: Array has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			'UPGRADE_WARNING: Couldn't resolve default property of object lastArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            lastArray = New String() {"1110010", "1100110", "1101100", "1000010", "1011100", "1001110", "1010000", "1000100", "1001000", "1110100"}
			'UPGRADE_WARNING: Array has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			'UPGRADE_WARNING: Couldn't resolve default property of object parityArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            parityArray = New String() {"111111", "110100", "110010", "110001", "101100", "100110", "100011", "101010", "101001", "100101"}
			'UPGRADE_WARNING: Couldn't resolve default property of object lValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			code = Left(lValue, 1)
			'UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			code = Right(code, 1)
			'UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object parityArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object codeType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			codeType = parityArray(CShort(code))
			
			lXML = lXML & doImage("101", 1)
			For i = 2 To 7
				'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object lValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				code = Left(lValue, i)
				'UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				code = Right(code, 1)
				'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object codeType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object lCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lCode = Left(codeType, i - 1)
				'UPGRADE_WARNING: Couldn't resolve default property of object lCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lCode = Right(lCode, 1)
				'UPGRADE_WARNING: Couldn't resolve default property of object lCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If lCode = "0" Then
					lXML = lXML & doImage(evenArray(code), 0)
				Else
					lXML = lXML & doImage(oddArray(code), 0)
				End If
			Next 
			lXML = lXML & doImage("01010", 1)
			For i = 8 To 13
				'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object lValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				code = Left(lValue, i)
				'UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				code = Right(code, 1)
				lXML = lXML & doImage(lastArray(code), 0)
			Next 
			lXML = lXML & doImage("101", 1)
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object lValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lString = lValue
			For i = 1 To Len(lString)
				'UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If CDbl(Left(lString, 1)) = 0 Then
					'UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lString = Right(lString, Len(lString) - 1)
				Else
					Exit For
				End If
			Next 
			'UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object lValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lValue = lString
			
			'UPGRADE_WARNING: Array has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			'UPGRADE_WARNING: Couldn't resolve default property of object oddArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            oddArray = New String() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "-", ".", " ", "$", "/", "+", "%", "~", ","}
			'UPGRADE_WARNING: Array has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			'UPGRADE_WARNING: Couldn't resolve default property of object evenArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            evenArray = New String() {"111331311", "311311113", "113311113", "313311111", "111331113", "311331111", "113331111", "111311313", "311311311", "113311311", "311113113", "113113113", "313113111", "111133113", "311133111", "113133111", "111113313", "311113311", "113113311", "111133311", "311111133", "113111133", "313111131", "111131133", "311131131", "113131131", "111111333", "311111331", "113111331", "111131331", "331111113", "133111113", "333111111", "131131113", "331131111", "133131111", "131111313", "331111311", "133111311", "131131311", "131313111", "131311131", "131113131", "111313131", "1311313111131131311"}
			
			'UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lString = "131131311"
			'UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lString = lString + "1"
			For i = 1 To Len(lValue)
				'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object lValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				code = Left(lValue, i)
				'UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				code = Right(code, 1)
				'UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				code = UCase(code)
				For j = 0 To UBound(oddArray)
					'UPGRADE_WARNING: Couldn't resolve default property of object oddArray(j). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If code = oddArray(j) Then
						'UPGRADE_WARNING: Couldn't resolve default property of object evenArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						'UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						lString = lString + evenArray(j)
						'UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						lString = lString + "1"
						'UPGRADE_WARNING: Couldn't resolve default property of object j. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						j = 9999
					End If
				Next 
			Next 
			'UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lString = lString + "131131311"
			
			For i = 1 To Len(lString)
				'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				code = Left(lString, i)
				'UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				code = Right(code, 1)
				'UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				For j = 1 To CShort(code)
					'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object lCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lCode = Left(code, i)
					'UPGRADE_WARNING: Couldn't resolve default property of object lCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lCode = Right(lCode, 1)
					'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Mod has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
					If i Mod 2 Then
						lXML = lXML & System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black) & "~"
					Else
						lXML = lXML & System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White) & "~"
					End If
					lXML = lXML & "20|"
				Next 
			Next 
		End If
		
		'UPGRADE_WARNING: Couldn't resolve default property of object lHeading. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		lString = lHeading
		'UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		x = 0
		y = 0
		'UPGRADE_WARNING: Couldn't resolve default property of object lHeading. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object HeadingString1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		HeadingString1 = lHeading & " "
		HeadingString2 = ""
		'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.TextWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If (lWidth - barcodePicture.TextWidth(lHeading)) < 0 Then
			For x = Len(lHeading) + 1 To 1 Step -1
				'UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object lHeading. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object HeadingString1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				HeadingString1 = Left(lHeading, x)
				'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.TextWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If (lWidth - barcodePicture.TextWidth(HeadingString1) + 50) > 0 Then
					For y = Len(HeadingString1) + 1 To 1 Step -1
						'UPGRADE_WARNING: Couldn't resolve default property of object HeadingString1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If Right(Left(HeadingString1, y), 1) = " " Then
							
							'UPGRADE_WARNING: Couldn't resolve default property of object HeadingString1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							HeadingString1 = Left(HeadingString1, y - 1)
							'UPGRADE_WARNING: Couldn't resolve default property of object HeadingString1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: Couldn't resolve default property of object lHeading. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							If (lHeading <> HeadingString1) Then
								'UPGRADE_WARNING: Couldn't resolve default property of object lHeading. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								HeadingString2 = Right(lHeading, Len(lHeading) - Len(HeadingString1))
							End If
							Exit For
						End If
					Next y
					Exit For
				End If
			Next 
		End If
		If HeadingString2 = "" Then
			'UPGRADE_WARNING: Couldn't resolve default property of object HeadingString1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			HeadingString2 = HeadingString1
			'UPGRADE_WARNING: Couldn't resolve default property of object HeadingString1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			HeadingString1 = ""
		Else
			Do Until Printer.TextWidth(HeadingString2) <= lWidth
				HeadingString2 = Mid(HeadingString2, 1, Len(HeadingString2) - 1)
			Loop 
		End If
		
		System.Windows.Forms.Application.DoEvents()
		System.Windows.Forms.Application.DoEvents()
		y = lTop + 30
		If headingMain1 <> "" Then
			'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.FontName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			barcodePicture.FontName = "Tahoma"
			'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.FontSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			barcodePicture.FontSize = 8
			'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.FontBold. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			barcodePicture.FontBold = True
			'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			barcodePicture.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
			'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.TextWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.PSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'barcodePicture.PSet(New Point[](CShort(lLeft + (lWidth - barcodePicture.TextWidth(headingMain1)) / 2), y))
			'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			barcodePicture.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
			'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			barcodePicture.Print(headingMain1)
			'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.CurrentY. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			y = barcodePicture.CurrentY
		End If
		If headingMain2 <> "" Then
			'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.FontName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			barcodePicture.FontName = "Tahoma"
			'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.FontSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			barcodePicture.FontSize = 8
			'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.FontBold. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			barcodePicture.FontBold = True
			'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			barcodePicture.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
			'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.TextWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.PSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'barcodePicture.PSet(New Point[](CShort(lLeft + (lWidth - barcodePicture.TextWidth(headingMain2)) / 2), y))
			'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			barcodePicture.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
			'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			barcodePicture.Print(headingMain2)
			'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.CurrentY. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			y = barcodePicture.CurrentY + 30
		End If
		'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.FontName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		barcodePicture.FontName = "Tahoma"
		'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.FontSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		barcodePicture.FontSize = 8
		'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.FontBold. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		barcodePicture.FontBold = True
		'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		barcodePicture.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
		'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.TextWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.PSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'barcodePicture.PSet(New Point[](CShort(lLeft + (lWidth - barcodePicture.TextWidth(HeadingString1)) / 2), y))
		'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		barcodePicture.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
		'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		barcodePicture.Print(HeadingString1)
		'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		barcodePicture.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
		'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.CurrentY. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		y = barcodePicture.CurrentY
		'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.TextWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.PSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'barcodePicture.PSet(New Point[](CShort(lLeft + (lWidth - barcodePicture.TextWidth(HeadingString2)) / 2), y))
		'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		barcodePicture.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
		'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		barcodePicture.Print(HeadingString2)
		
		'UPGRADE_WARNING: Couldn't resolve default property of object barArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		barArray = Split(lXML, "|")
		'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.CurrentY. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		y = barcodePicture.CurrentY
		'UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        x = CShort(lLeft + (lWidth - UBound(barArray) * twipsPerPixel(True)) / 2)
		For cnt = LBound(barArray) To UBound(barArray)
			'UPGRADE_WARNING: Couldn't resolve default property of object barArray(cnt). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If barArray(cnt) <> "" Then
				'UPGRADE_WARNING: Couldn't resolve default property of object barArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If CInt(Split(barArray(cnt), "~")(0)) = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black) Then
					'UPGRADE_WARNING: Couldn't resolve default property of object barArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.Line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'barcodePicture.Line((x + cnt * twipsPerPixel(true), y) - (x + (cnt + 1) * twipsPerPixel(true), y + CInt(Split(barArray(cnt), "~")(1)) * twipsPerPixel(true)), CInt(Split(barArray(cnt), "~")(0)), BF)
				End If
			End If
			
		Next 
		'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.CurrentX. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		x = barcodePicture.CurrentX
		'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.CurrentY. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		y = barcodePicture.CurrentY
		If noCode Then
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object lValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lString = lValue
			'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			barcodePicture.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
			'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.TextWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.PSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'barcodePicture.PSet(New Point[](CShort(lLeft + (lWidth - barcodePicture.TextWidth(lString)) / 2), y))
			'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			barcodePicture.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
			'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			barcodePicture.Print(lString)
			'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.CurrentX. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			x = barcodePicture.CurrentX
			'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.CurrentY. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			y = barcodePicture.CurrentY
		End If
		'UPGRADE_WARNING: Couldn't resolve default property of object lFooter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		lString = lFooter
		'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		barcodePicture.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
		'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.TextWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.PSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'barcodePicture.PSet(New Point[](CShort(lLeft + (lWidth - barcodePicture.TextWidth(lString)) / 2), y))
		'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		barcodePicture.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
		'UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		barcodePicture.Print(lString)
	End Sub
	
	
	Public Function isBarcodePrinter() As Boolean
		Dim Printer As New Printer
		isBarcodePrinter = CBool(InStr(LCase(Printer.DeviceName), "label"))
	End Function
	
	
	
	Public Sub setLabelDefaults()
		Dim rs As ADODB.Recordset
		'    If isBarcodePrinter = "1" Then
		'        Set rs = getRS("SELECT TOP 1 Label.* From Label Where (((Label.Label_Type) <> 0)) ORDER BY Label.Label_Name;")
		'    Else
		'        Set rs = getRS("SELECT TOP 1 Label.* From Label Where (((Label.Label_Type) = 0)) ORDER BY Label.Label_Name;")
		'    End If
		'    gLabelName = rs("Label_Name")
		'    gLabelColumns = rs("Label_Columns")
		'    gLabelLeft = rs("Label_Left")
		'    gLabelHeight = rs("Label_Height")
		'    gLabelWidth = rs("Label_Width")
		
	End Sub
End Module