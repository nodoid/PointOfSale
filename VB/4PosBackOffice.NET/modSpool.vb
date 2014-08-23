Option Strict Off
Option Explicit On
Module modSpool
	
	'
	' Win32 API Calls
	'
	Private Declare Function GetProfileString Lib "kernel32" Alias "GetProfileStringA" (ByVal lpAppName As String, ByVal lpKeyName As Object, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer) As Integer
	Private Declare Function OpenPrinter Lib "winspool.drv" Alias "OpenPrinterA" (ByVal pPrinterName As String, ByRef phPrn As Integer, ByRef pDefault As Object) As Integer
	'UPGRADE_WARNING: Structure DOC_INFO_1 may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function StartDocPrinter Lib "winspool.drv"  Alias "StartDocPrinterA"(ByVal hPrn As Integer, ByVal Level As Integer, ByRef pDocInfo As DOC_INFO_1) As Integer
	Private Declare Function StartPagePrinter Lib "winspool.drv" (ByVal hPrn As Integer) As Integer
	Private Declare Function WritePrinter Lib "winspool.drv" (ByVal hPrn As Integer, ByRef pBuf As Object, ByVal cdBuf As Integer, ByRef pcWritten As Integer) As Integer
	Private Declare Function EndPagePrinter Lib "winspool.drv" (ByVal hPrn As Integer) As Integer
	Private Declare Function EndDocPrinter Lib "winspool.drv" (ByVal hPrn As Integer) As Integer
	Private Declare Function ClosePrinter Lib "winspool.drv" (ByVal hPrn As Integer) As Integer
	'
	' Structure required by StartDocPrinter
	'
	Private Structure DOC_INFO_1
		Dim pDocName As String
		Dim pOutputFile As String
		Dim pDatatype As String
	End Structure
	
	Public Sub SpoolFile(ByRef sFile As String, ByRef PrnName As String, Optional ByRef AppName As String = "")
		Dim hPrn As Integer
		Dim Buffer() As Byte
		Dim hFile As Short
		Dim Written As Integer
		Dim di As DOC_INFO_1
		Dim i As Integer
		Const BufSize As Integer = &H4000
		AppName = "4POS Barcode"
		'
		' Extract filename from passed spec, and build job name.
		' Fill remainder of DOC_INFO_1 structure.
		'
		If InStr(sFile, "\") Then
			For i = Len(sFile) To 1 Step -1
				If Mid(sFile, i, 1) = "\" Then Exit For
				di.pDocName = Mid(sFile, i, 1) & di.pDocName
			Next i
		Else
			di.pDocName = sFile
		End If
		If Len(AppName) Then
			di.pDocName = AppName
		End If
		di.pOutputFile = vbNullString
		di.pDatatype = "RAW"
		'
		' Open printer for output to obtain handle.
		' Set it up to begin recieving raw data.
		'
		Call OpenPrinter(PrnName, hPrn, 0)
		Call StartDocPrinter(hPrn, 1, di)
		Call StartPagePrinter(hPrn)
		'
		' Open file and pump it to the printer.
		'
		hFile = FreeFile
		FileOpen(hFile, sFile, OpenMode.Binary, OpenAccess.Read)
		'
		' Read in 16K buffers and spool.
		'
		'UPGRADE_WARNING: Lower bound of array Buffer was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		ReDim Buffer(BufSize)
		For i = 1 To LOF(hFile) \ BufSize
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(hFile, Buffer)
			Call WritePrinter(hPrn, Buffer(1), BufSize, Written)
		Next i
		'
		' Get last chunk of file if it doesn't
		' fit evenly into a 16K buffer.
		'
		If LOF(hFile) Mod BufSize Then
			'UPGRADE_WARNING: Lower bound of array Buffer was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
			ReDim Buffer((LOF(hFile) Mod BufSize))
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(hFile, Buffer)
			Call WritePrinter(hPrn, Buffer(1), UBound(Buffer), Written)
		End If
		FileClose(hFile)
		'
		' Shut down spooling process.
		'
		Call EndPagePrinter(hPrn)
		Call EndDocPrinter(hPrn)
		Call ClosePrinter(hPrn)
	End Sub
End Module