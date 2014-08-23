Option Strict Off
Option Explicit On
Module SaveArrayAsCSVFile
	
    Public dChrom(,) As String 'Double
	
	
	' SaveAsCSV saves an array as csv file. Choosing a delimiter different as a comma, is optional.
	'
	' Syntax:
	' SaveAsCSV dMyArray, sMyFileName, [sMyDelimiter]
	'
	' Examples:
	' SaveAsCSV dChrom, app.path & "\Demo.csv"       --> comma as delimiter
	' SaveAsCSV dChrom, app.path & "\Demo.csv", ";"  --> semicolon as delimiter
	'
	' written by Baber Abbass
	' baber_abbass@hotmail.com
	
	
    Public Sub SaveAsCSV(ByRef MyArray(,) As String, ByRef sFileName As String, Optional ByRef sDelimiter As String = ",")

        Dim n As Integer 'counter
        Dim M As Integer 'counter
        Dim sCSV As String 'csv string to print

        On Error GoTo ErrHandler_SaveAsCSV


        'check extension and correct if needed
        If InStr(sFileName, ".csv") = 0 Then
            sFileName = sFileName & ".csv"
        Else
            While (Len(sFileName) - InStr(sFileName, ".csv")) > 3
                sFileName = Left(sFileName, Len(sFileName) - 1)
            End While
        End If

        'If MultiDimensional(MyArray) = False Then '1 dimension

        'save the file
        '        FileOpen(7, sFileName, OpenMode.Output)
        '        For n = 0 To UBound(MyArray, 1)
        'PrintLine(7, MyArray(n, 0)) 'Format( MyArray(n, 0), "0.000000E+00")
        'Next n
        'FileClose(7)

        '        Else 'more dimensional

        'save the file
        FileOpen(7, sFileName, OpenMode.Output)
        For n = 0 To UBound(MyArray, 1)
            sCSV = ""
            For M = 0 To UBound(MyArray, 2)
                sCSV = sCSV & MyArray(n, M) & sDelimiter 'Format(MyArray(n, M), "0.000000E+00") & sDelimiter
            Next M
            sCSV = Left(sCSV, Len(sCSV) - 1) 'remove last Delimiter
            PrintLine(7, sCSV)
        Next n
        FileClose(7)

        'End If

        Exit Sub


ErrHandler_SaveAsCSV:
        FileClose(7)
    End Sub
	
	' Function ImportCSVinArray imports a csv file into an array. Choosing a delimiter different as a comma, is optional.
	'
	' Syntax:
	' dMyArray() = ImportCSVinArray (sMyFileName, [sMyDelimiter])
	'
	' Examples:
	' dChrom() = ImportCSVinArray("c:\temp\demo.csv")       --> comma as delimiter
	' dChrom() = ImportCSVinArray("c:\temp\demo.csv",";")   --> semicolon as delimiter
	'
	'
	' written by Baber Abbass
	' baber_abbass@hotmail.com
	
	Public Function ImportCSVinArray(ByRef sFileName As String, Optional ByRef sDelimiter As String = ",") As Double()
		
        Dim MyArray() As Double
        Dim MyOArray(,) As Double
		Dim sSplit() As String
		Dim sLine As String
		Dim lRows As Integer
		Dim lColumns As Integer
		Dim lCounter As Integer
		
		On Error GoTo ErrHandler_ImportCSVinArray
		
		'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		If Dir(sFileName) <> "" Then
			'determine number of rows and columns needed
			lRows = 0
			lColumns = 0
			FileOpen(7, sFileName, OpenMode.Input)
			While Not (EOF(7))
				sLine = LineInput(7)
				If Len(sLine) > 0 Then
					sSplit = Split(sLine, sDelimiter)
					If UBound(sSplit) > lColumns Then lColumns = UBound(sSplit)
					lRows = lRows + 1
				End If
			End While
			FileClose(7)
			
			
			'fill array
			If lColumns = 1 Then 'no csv file!
				
				ReDim MyArray(lRows - 1)
				
				FileOpen(7, sFileName, OpenMode.Input)
				lRows = 0
				While Not (EOF(7))
					sLine = LineInput(7)
					If Len(sLine) > 0 Then
						MyArray(lRows) = Val(sLine)
						lRows = lRows + 1
					End If
				End While
				FileClose(7)
				
				
			ElseIf lColumns > 1 Then  'multidimensional csv file
				
                ReDim MyOArray(lRows - 1, lColumns)
				
				FileOpen(7, sFileName, OpenMode.Input)
				lRows = 0
				While Not (EOF(7))
					sLine = LineInput(7)
					If Len(sLine) > 0 Then
						sSplit = Split(sLine, sDelimiter)
						For lCounter = 0 To UBound(sSplit)
                            MyOArray(lRows, lCounter) = Val(sSplit(lCounter))
						Next lCounter
						lRows = lRows + 1
					End If
				End While
				FileClose(7)
				
			End If
			
			'return function
            ImportCSVinArray = MyArray.Clone()
		End If
		
		
		Exit Function
		
ErrHandler_ImportCSVinArray: 
	End Function
	
	Private Function MultiDimensional(ByRef CheckArray() As String) As Boolean
		
		On Error GoTo ErrHandler_MultiDimensional
		
		If UBound(CheckArray, 2) > 0 Then
			MultiDimensional = True 'more than 1 dimension
		End If
		
		Exit Function
ErrHandler_MultiDimensional: 
		MultiDimensional = False '1 dimension
	End Function
End Module