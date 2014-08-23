Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmBarcodeLoad
	Inherits System.Windows.Forms.Form
	Public gLBLleft As Integer
	Public gLBLwidth As Integer
	Public gLBLheight As Integer
	Public LabelDisp As Integer
	Public glBTop As Integer
	Public twipsToMM As Integer
	Public gPrinterLabel As String
	Public gOffsetLabel As Integer
	Public gPersonID As Integer
	Dim strname As String
	Dim fso As New Scripting.FileSystemObject
    Dim inrec As Label
	Dim strwidht As Integer
	Dim strheight As Integer
	Dim strpath As String
	Dim pPath As String
	Dim cCompany As Boolean
	Dim cCompTelephone As Boolean
	Dim cStockItem As Boolean
	Dim cBarcode As Boolean
	Dim cGroup As Boolean
	Dim cPrice As Boolean
    Dim Option1 As New List(Of RadioButton)
    Dim Option2 As New List(Of RadioButton)
	Private Sub loadLanguage()
		
		'frmBarcodeLoad = No Code       [Barcode Designing]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmBarcodeLoad.Caption = rsLang("LanguageLayoutLnk_Description"): frmBarcodeLoad.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1927 'Design Name|Checked
		If rsLang.RecordCount Then Label1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lblDesign = No Code/Dynamic/NA?
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1928 'Label Width|
		If rsLang.RecordCount Then _lbl_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lblWidth = No Code/Dynamic/NA?
		
		'_lbl_0 = No Code               [mm]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1929 'Label Height|Checked
		If rsLang.RecordCount Then _lbl_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lblHeigh = No Code/Dynamic/NA?
		
		'_lbl_3 = No Code               [mm]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_3.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1930 'Top Margin|Checked
		If rsLang.RecordCount Then _lbl_4.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_4.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lblTop = No Code/Dynamic/NA?
		
		'_lbl_5 = No Code               [mm]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_5.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1931 'Left Margin|
		If rsLang.RecordCount Then _lbl_6.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_6.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lblLeft = No Code/Dynamic/NA?
		
		'_lbl_7 = No Code               [mm]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_7.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_7.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblLineNO = Not Applicable
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1579 'Back|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'Frame1 = No Code               [Select Field to Format]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0
		'If rsLang.RecordCount Then Frame1.Caption = rsLang("LanguageLayoutLnk_Description"): Frame1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1934 'Company Name|Checked
		If rsLang.RecordCount Then Option1(0).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Option1(0).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1935 'Stock Item Name|Checked
		If rsLang.RecordCount Then Option1(1).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Option1(1).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1936 'Barcode No|Checked
		If rsLang.RecordCount Then Option1(2).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Option1(2).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1288 'Telephone|Checked
		If rsLang.RecordCount Then Option1(3).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Option1(3).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1938 'Group|Checked
		If rsLang.RecordCount Then Option1(5).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Option1(5).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1939 'Line|Checked
		If rsLang.RecordCount Then Option1(6).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Option1(6).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1838 'Barcode|Checked
		If rsLang.RecordCount Then Option1(7).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Option1(7).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1941 'Blank|
		If rsLang.RecordCount Then Option1(8).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Option1(8).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'Option1(4) = No Code           [Price for 1]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Option1(4).Caption = rsLang("LanguageLayoutLnk_Description"): Option1(4).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Option1(9) = No Code           [Price for  6]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Option1(9).Caption = rsLang("LanguageLayoutLnk_Description"): Option1(9).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Option1(10) = No Code          [Price for 12]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Option1(10).Caption = rsLang("LanguageLayoutLnk_Description"): Option1(10).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Option1(11) = No Code          [Price for 24]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Option1(11).Caption = rsLang("LanguageLayoutLnk_Description"): Option1(11).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1946 'Font|Checked
		If rsLang.RecordCount Then frmDeposits.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : frmDeposits.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1947 'Font Size|Checked
		If rsLang.RecordCount Then Label5.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label5.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1948 'Row Position|Checked
		If rsLang.RecordCount Then Label6.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label6.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1949 'Bold|Checked
		If rsLang.RecordCount Then _chkFields_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _chkFields_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1950 'Align Left|Checked
		If rsLang.RecordCount Then Option2(0).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Option2(0).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1951 'Align Centre|Checked
		If rsLang.RecordCount Then Option2(1).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Option2(1).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1952 'Align Right|Checked
		If rsLang.RecordCount Then Option2(2).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Option2(2).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_chkFields_4 = No Code         [Add/Remove]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkFields_4.Caption = rsLang("LanguageLayoutLnk_Description"): _chkFields_4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1579 'Back|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdundo.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdundo.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1956 'Save Design|Checked
		If rsLang.RecordCount Then cmdadd.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdadd.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1957 'Apply Changes|Checked
		If rsLang.RecordCount Then cmdSave.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdSave.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmBarcodeLoad.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Function loadBarcodePrinter() As Boolean
        Dim Printer As New Printing.PrintDocument
        Dim lblPrinter As Label
		
        Dim lPrinter As New Printing.PrintDocument
		Dim rs As ADODB.Recordset
		loadBarcodePrinter = True
		gPrinterLabel = MyNewPrLabel 'Jonas
		lblPrinter.Text = MyNewPrLabel
        If Printer.PrinterSettings.InstalledPrinters.Count = 0 Then
            loadBarcodePrinter = False
        Else
            ' gPrinterLabel = frmPrinter.selectPrinter()
            If gPrinterLabel = "" Then
                loadBarcodePrinter = False
            Else
                For Each lPrinter In Printer.PrinterSettings.InstalledPrinters

                    If InStr(LCase(lPrinter.ToString), LCase(gPrinterLabel)) Then
                        Printer = lPrinter
                        Exit For
                    End If
                Next lPrinter
                'Printer.PrinterSettings.DefaultPageSettings. = ScaleModeConstants.vbTwips 'twips
                'twipsToMM = Printer.ScaleWidth
                'Printer.ScaleMode = ScaleModeConstants.vbMillimeters 'mm
                'twipsToMM = twipsToMM / Printer.ScaleWidth
                'Printer.ScaleMode = ScaleModeConstants.vbTwips 'twips
                rs = getRS("SELECT Printer.* From Printer WHERE (((Printer.PrinterID)='" & Replace(gPrinterLabel, "'", "''") & "'));")
                'If rs.RecordCount Then
                'gOffsetLabel = rs("Printer_Offset")
                'gLBLheight = (rs("Printer_BCheight")) * twipsToMM
                'gLBLwidth = (rs("Printer_BCwidth")) * twipsToMM
                'Else
                gLBLheight = (30 - 2) * twipsToMM
                gLBLwidth = (40 - 2) * twipsToMM

                'End If

            End If
        End If
		
	End Function
	
	'UPGRADE_NOTE: size was upgraded to size_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Function doImage(ByRef code As String, ByRef size_Renamed As Boolean) As String
        Dim lXML As String
        Dim lCode As String
        Dim i As Short
        For i = 1 To Len(code)
            lCode = VB.Left(code, i)
            lCode = VB.Right(lCode, 1)
            If lCode = "0" Then
                lXML = lXML & System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White) & "~"
            Else
                lXML = lXML & System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black) & "~"
            End If
            If (size_Renamed) Then
                lXML = lXML & 30 & "|"
            Else
                lXML = lXML & 25 & "|"
            End If
        Next
        doImage = lXML
    End Function
	
    Private Function doCheckSum(ByRef lString As String) As Boolean
        Dim lAmount As Short
        Dim code As String
        Dim i As Short
        Dim value As String
        value = lString
        'UPGRADE_WARNING: Couldn't resolve default property of object doCheckSum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        doCheckSum = False
        If InStr(value, "0") Then
            Do Until CDbl(VB.Left(value, 1)) <> 0
                value = Mid(value, 2)
            Loop
        End If
        If Len(value) < 12 Then Exit Function
        If value = "" Then Exit Function
        If InStr(value, ".") Then
            'UPGRADE_WARNING: Couldn't resolve default property of object doCheckSum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            doCheckSum = False
        Else
            If IsNumeric(value) Then
                lAmount = 0
                For i = 1 To Len(value) - 1
                    code = VB.Left(value, i)
                    code = VB.Right(code, 1)
                    If i Mod 2 Then
                        lAmount = lAmount + CShort(code)
                    Else
                        lAmount = lAmount + CShort(code) * 3
                    End If
                Next
                lAmount = 10 - (lAmount Mod 10)
                If lAmount = 10 Then lAmount = 0
                'UPGRADE_WARNING: Couldn't resolve default property of object doCheckSum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                doCheckSum = lAmount = CShort(VB.Right(value, 1))
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object doCheckSum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                doCheckSum = False
            End If
        End If
    End Function
	
	
	
	Public Sub printBarcode(ByRef barcodePicture As Object, ByRef lValue As String, ByRef lLeft As Integer, ByRef lTop As Integer, Optional ByRef lWidth As Integer = 0)
        'Dim BF As Object
        Dim x As Short
		Dim y As Short
		Dim lXML As String
        Dim lastArray, oddArray, evenArray, parityArray As String()
        Dim lString, codeType, code, lCode, HeadingString1 As String
		Dim HeadingString2 As String
        Dim i, j As Integer
		Dim cnt As Short
        Dim barArray As String()
		lXML = ""
		If doCheckSum(lValue) Then
			oddArray = New String() {"0001101", "0011001", "0010011", "0111101", "0100011", "0110001", "0101111", "0111011", "0110111", "0001011"}
            evenArray = New String() {"0100111", "0110011", "0011011", "0100001", "0011101", "0111001", "0000101", "0010001", "0001001", "0010111"}
            lastArray = New String() {"1110010", "1100110", "1101100", "1000010", "1011100", "1001110", "1010000", "1000100", "1001000", "1110100"}
            parityArray = New String() {"111111", "110100", "110010", "110001", "101100", "100110", "100011", "101010", "101001", "100101"}
			code = VB.Left(lValue, 1)
			code = VB.Right(code, 1)
			codeType = parityArray(CShort(code))
			
			lXML = lXML & doImage("101", 1)
            For i = 2 To 7
                code = VB.Left(lValue, i)
                code = VB.Right(code, 1)
                lCode = VB.Left(codeType, i - 1)
                lCode = VB.Right(lCode, 1)
                If lCode = "0" Then
                    lXML = lXML & doImage(evenArray(code), 0)
                Else
                    lXML = lXML & doImage(oddArray(code), 0)
                End If
            Next
			lXML = lXML & doImage("01010", 1)
            For i = 8 To 13
                code = VB.Left(lValue, i)
                code = VB.Right(code, 1)
                lXML = lXML & doImage(lastArray(code), 0)
            Next
			lXML = lXML & doImage("101", 1)
		Else
			lString = lValue
			For i = 1 To Len(lString)
				If CDbl(VB.Left(lString, 1)) = 0 Then
					lString = VB.Right(lString, Len(lString) - 1)
				Else
					Exit For
				End If
			Next 
			lValue = lString
			
			oddArray = New String() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "-", ".", " ", "$", "/", "+", "%", "~", ","}
			evenArray = New String() {"111331311", "311311113", "113311113", "313311111", "111331113", "311331111", "113331111", "111311313", "311311311", "113311311", "311113113", "113113113", "313113111", "111133113", "311133111", "113133111", "111113313", "311113311", "113113311", "111133311", "311111133", "113111133", "313111131", "111131133", "311131131", "113131131", "111111333", "311111331", "113111331", "111131331", "331111113", "133111113", "333111111", "131131113", "331131111", "133131111", "131111313", "331111311", "133111311", "131131311", "131313111", "131311131", "131113131", "111313131", "1311313111131131311"}
			
			lString = "131131311"
			lString = lString + "1"
			For i = 1 To Len(lValue)
				code = VB.Left(lValue, i)
				code = VB.Right(code, 1)
				code = UCase(code)
				For j = 0 To UBound(oddArray)
					If code = oddArray(j) Then
						lString = lString + evenArray(j)
						lString = lString + "1"
						j = 9999
					End If
				Next 
			Next 
			lString = lString + "131131311"
			
			For i = 1 To Len(lString)
				code = VB.Left(lString, i)
				code = VB.Right(code, 1)
				For j = 1 To CShort(code)
					lCode = VB.Left(code, i)
					lCode = VB.Right(lCode, 1)
					If i Mod 2 Then
						lXML = lXML & System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black) & "~"
					Else
						lXML = lXML & System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White) & "~"
					End If
					lXML = lXML & "20|"
				Next 
			Next 
		End If
		
		barArray = Split(lXML, "|")
		y = lTop
		If lWidth = 0 Then
			x = lLeft
		Else
            x = CShort(lLeft + (lWidth - UBound(barArray) * twipsPerPixel(True) / 2))
		End If
		For cnt = LBound(barArray) To UBound(barArray)
			If barArray(cnt) <> "" Then
				If CInt(Split(barArray(cnt), "~")(0)) = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black) Then
					
                    'barcodePicture.Line((x + cnt * twipsPerPixel(True), y) - (x + (cnt + 1) * twipsPerPixel(true), y + CInt(Split(barArray(cnt), "~")(1)) * twipsPerPixel(true)), CInt(Split(barArray(cnt), "~")(0)), BF)
					
				End If
			End If
			
		Next 
	End Sub
	
	Private Sub Command1_Click()
		Dim NewLargeChange As Short
        Dim lline As Integer
        Dim lObject As PictureBox
		Dim y As Integer
		Dim rs As ADODB.Recordset
		Dim rsData As ADODB.Recordset
        lObject = _picSelect_0
		Dim currentPic As Integer
		Dim RecSelNew As Short
		Dim lString1, lString2 As String
        'For currentPic = 0 To 1
        '_picSelect_0.Unload(currentPic)
        'Next
        'currentPic = 0
        _picSelect_0.Width = twipsToPixels(gLBLwidth, True)
        gLBLleft = (lObject.Width - (gLBLwidth)) / 2 + (gOffsetLabel * twipsToMM)
        gLBLleft = 0
        'picSelect(0).Cls

        rs = getRS("SELECT * FROM BClabel WHERE BClabel_Disabled = false and BClabel_LabelID=" & LaIDHold & " ORDER BY BClabelID")
        'currentPic = 0
        Do Until rs.EOF
            If currentPic Then
                On Error Resume Next
                _picSelect_0.Load(currentPic)
            End If
            _picSelect_0.Left = twipsToPixels((pixelToTwips(_picSelect_0.Width, True) + 90) _
                * currentPic, True)
            _picSelect_0.Visible = True
            'UPGRADE_ISSUE: PictureBox property picSelect.AutoRedraw was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
            '_picSelect_0.AutoRedraw = True
            lObject = _picSelect_0
            _picSelect_0.Tag = rs.Fields("BClabelID").Value

            y = CShort((gLBLheight - rs.Fields("BClabel_Height").Value * twipsToMM) / 2)
            If y < 0 Then y = 0
            'lObject.FontName = "Tahoma"

            rsData = getRS("SELECT * FROM BClabelItem INNER JOIN BClabel ON BClabelItem.BClabelItem_BCLabelID = BClabel.BClabelID Where (((BClabel.BClabelID) = " & rs.Fields("BClabelID").Value & ")) ORDER BY BClabel.BClabelID, BClabelItem.BClabelItem_Line;")
            If rsData.RecordCount Then
                lline = rsData.Fields("BClabelItem_Line").Value
                Do Until rsData.EOF
                    If lline <> rsData.Fields("BClabelItem_Line").Value Then
                        y = lObject.Location.Y + 10
                        lline = rsData.Fields("BClabelItem_Line").Value
                    End If

                    Select Case LCase(rsData.Fields("BClabelItem_Field").Value)
                        Case "line"
                            'lObject.Line((15 + gLBLleft, y) - (gLBLleft + gLBLwidth, y), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black))
                        Case "code"
                            Select Case rsData.Fields("BClabelItem_Align").Value
                                Case 1
                                    printBarcode(lObject, "6001060071416", gLBLleft, y)
                                    'lObject.FontBold = rsData.Fields("BClabelItem_Bold").Value
                                    'lObject.FontSize = rsData.Fields("BClabelItem_Size").Value
                                Case 2
                                    'lObject.FontBold = rsData.Fields("BClabelItem_Bold").Value
                                    'lObject.FontSize = rsData.Fields("BClabelItem_Size").Value
                                    printBarcode(lObject, "6001060071416", gLBLleft + 1000, y)
                                Case Else
                                    'lObject.FontBold = rsData.Fields("BClabelItem_Bold").Value
                                    'lObject.FontSize = rsData.Fields("BClabelItem_Size").Value
                                    printBarcode(lObject, "6001060071416", gLBLleft, y, gLBLwidth)

                            End Select

                        Case Else
                            On Error Resume Next
                            'lObject.FontSize = rsData.Fields("BClabelItem_Size").Value
                            'lObject.FontBold = rsData.Fields("BClabelItem_Bold").Value
                            'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                            lString1 = rsData.Fields("BClabelItem_Sample").Value
                            Select Case rsData.Fields("BClabelItem_Align").Value
                                Case 1
                                    'lObject.PSet(New Point[](gLBLleft, y))
                                    'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                    'lObject.Print(lString1)

                                Case 2
                                    'lObject.PSet(New Point[](gLBLleft + gLBLwidth - lObject.TextWidth(lString1), y))
                                    'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                    'lObject.Print(lString1)

                                Case 3
                                    'splitString(lObject, lString1, lString2)
                                    If lString1 <> "" Then
                                        'lObject.PSet(New Point[](CShort(gLBLleft + (gLBLwidth - lObject.TextWidth(lString1)) / 2), y))
                                        'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                        'lObject.Print(lString1)
                                        y = lObject.Location.Y + 10
                                        'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                                    End If
                                    lString1 = lString2
                                    If lString1 <> "" Then
                                        '.lObject.PSet(New Point[](CShort(gLBLleft + (gLBLwidth - lObject.TextWidth(lString1)) / 2), y))
                                        '.lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                        '.lObject.Print(lString1)
                                    End If
                                Case Else
                                    'lObject.PSet(New Point[](CShort(gLBLleft + (gLBLwidth - lObject.TextWidth(lString1)) / 2), y))
                                    'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                    'lObject.Print(lString1)
                            End Select
                    End Select
                    rsData.MoveNext()
                Loop
            End If
            rs.MoveNext()
        Loop
        ' picSelect(0).FontItalic = True
        picInner.Width = twipsToPixels(lObject.Left + lObject.Width, True)
        picInner.SetBounds(0, 0, twipsToPixels(lObject.Left + lObject.Width, True), twipsToPixels(lObject.Top + lObject.Height, False))
        If pixelToTwips(picInner.Width, True) > pixelToTwips(picOuter.Width, True) Then
            HSselect.Enabled = True
            HSselect.Value = 0
            HSselect.Maximum = (pixelToTwips(picInner.Width, True) - pixelToTwips(picOuter.Width, True) + 100 + HSselect.LargeChange - 1)
            NewLargeChange = lObject.Width + 100
            HSselect.Maximum = HSselect.Maximum + NewLargeChange - HSselect.LargeChange
            HSselect.LargeChange = NewLargeChange
            HSselect.SmallChange = CShort((lObject.Width + 100) / 2)

        Else
            HSselect.Enabled = False
        End If


    End Sub

    Private Function TextWidth(ByVal obj As PictureBox, ByVal text As String) As Integer
        Dim width As Size = TextRenderer.MeasureText(text, obj.DefaultFont)
        TextWidth = width.Width
    End Function

    Private Sub splitString(ByRef lObject As PictureBox, ByRef HeadingString1 As String, ByRef HeadingString2 As String)
        Dim Printer As New Printing.PrintDocument
        Dim y As Short
        Dim x As Short
        Dim lHeading As String
        Dim width As Size = TextRenderer.MeasureText(lHeading, lObject.DefaultFont)

        lHeading = HeadingString1
        HeadingString1 = lHeading & " "
        HeadingString2 = ""
        If (gLBLwidth - TextWidth(lObject, lHeading)) < 0 Then
            For x = Len(lHeading) + 1 To 1 Step -1
                HeadingString1 = VB.Left(lHeading, x)
                If (gLBLwidth - TextWidth(lObject, HeadingString1) + 50) > 0 Then
                    For y = Len(HeadingString1) + 1 To 1 Step -1
                        If VB.Right(VB.Left(HeadingString1, y), 1) = " " Then

                            HeadingString1 = VB.Left(HeadingString1, y - 1)
                            If (lHeading <> HeadingString1) Then
                                HeadingString2 = VB.Right(lHeading, Len(lHeading) - Len(HeadingString1))
                            End If
                            Exit For
                        End If
                    Next y
                    Exit For
                End If
            Next
        End If
        If HeadingString2 = "" Then
            HeadingString2 = HeadingString1
            HeadingString1 = ""
        Else
            Do Until Printer.DefaultPageSettings.Bounds.Width <= gLBLwidth
                'Do Until Printer.TextWidth(HeadingString2) <= gLBLwidth
                HeadingString2 = Mid(HeadingString2, 1, Len(HeadingString2) - 1)
            Loop
        End If
        HeadingString1 = Trim(HeadingString1)
        HeadingString2 = Trim(HeadingString2)
    End Sub

    Private Sub Align_Click(ByRef Index As Short)

    End Sub

    Private Sub chkfield_Click(ByRef Index As Short)
        Dim TheNamesCod As String
        Dim TheNamesLi As String
        Dim TheNamesGro As String
        Dim TheNamesPr As String
        Dim TheNamesTel As String
        Dim TheNamesBarc As String
        Dim TheNamesSt As String
        Dim TheNamesC As String
        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset

        If Index = 0 Then
            TheNamesC = "Company_Name"
            TheNames = "Company_Name"
            rs = getRS("SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNamesC & "'")
        ElseIf Index = 1 Then
            TheNamesSt = "StockItem_Name"
            TheNames = "StockItem_Name"
            rs = getRS("SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNamesSt & "'")
        ElseIf Index = 4 Then
            TheNamesBarc = "Catalogue_Barcode"
            TheNames = "Catalogue_Barcode"
            rs = getRS("SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNamesBarc & "'")
        ElseIf Index = 2 Then
            TheNamesTel = "Company_Telephone"
            TheNames = "Company_Telephone"
            rs = getRS("SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNamesTel & "'")
        ElseIf Index = 3 Then
            TheNamesPr = "Price"
            TheNames = "Price"
            rs = getRS("SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNamesPr & "'")
        ElseIf Index = 5 Then
            TheNamesGro = "PricingGroupID"
            TheNames = "PricingGroupID"
            rs = getRS("SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNamesGro & "'")
        ElseIf Index = 7 Then
            TheNamesLi = "line"
            TheNames = "line"
            rs = getRS("SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNamesLi & "'")
        ElseIf Index = 6 Then
            TheNamesCod = "code"
            TheNames = "code"
            rs = getRS("SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNamesCod & "'")
        End If

    End Sub

    'Private Sub chkFields_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkFields.CheckStateChanged
    '	Dim Index As Short = chkFields.GetIndex(eventSender)

    'If _chkFields_0.value Then cCompany = True Else cCompany = False
    'updattecomp
    'If _chkFields_1.value Then cCompTelephone = True Else cCompTelephone = False
    'updattetel
    'If _chkFields_2.value Then cStockItem = True Else cStockItem = False
    'updattestck
    'If _chkFields_3.value Then cBarcode = True Else cBarcode = False
    'updattebar
    'If _chkFields_4.value Then cGroup = True Else cGroup = False
    'updattegr
    'If _chkFields_5.value Then cPrice = True Else cPrice = False
    'updattepr

    'If _chkFields_1.value And _chkFields_2.value = 0 Then

    '   If _chkFields_2.value Then
    '       _chkFields_1.value = 0
    '   ElseIf _chkFields_1.value Then
    '       _chkFields_1.value = 1
    '  End If
    'ElseIf _chkFields_2.value = 1 And _chkFields_1.value = 1 Then
    '    If _chkFields_2.value Then
    '        _chkFields_1.value = 0
    '    Else
    '        _chkFields_1.value = 1
    '    End If

    'End If

    'Public MyFBold As String
    'Public MyFAlign As String

    'If _chkFields_1.value Then
    '    MyFAlign = 1
    'ElseIf _chkFields_2.value Then
    '    MyFAlign = 0
    'ElseIf _chkFields_3.value Then
    '    MyFAlign = 2
    'End If

    'End Sub
    Private Sub updattepr()
        Dim rs As ADODB.Recordset
        rs = getRS("SELECT BClabelItem.* from BClabelItem")
        Do Until rs.EOF
            If cPrice = True Then
                cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = True WHERE (((BClabelItem.BClabelItem_Field)='Price'));")
            Else
                cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = False WHERE (((BClabelItem.BClabelItem_Field)='Price'));")
            End If
            rs.MoveNext()
        Loop
    End Sub

    Private Sub updattegr()
        Dim rs As ADODB.Recordset
        rs = getRS("SELECT BClabelItem.* from BClabelItem")
        Do Until rs.EOF
            If cGroup = True Then
                cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = True WHERE (((BClabelItem.BClabelItem_Field)='PricingGroupID'));")
            Else
                cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = False WHERE (((BClabelItem.BClabelItem_Field)='PricingGroupID'));")
            End If

            rs.MoveNext()
        Loop
    End Sub
    Private Sub updattebar()
        Dim rs As ADODB.Recordset
        rs = getRS("SELECT BClabelItem.* from BClabelItem")
        Do Until rs.EOF
            If cBarcode = True Then
                cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = True WHERE (((BClabelItem.BClabelItem_Field)='Catalogue_Barcode'));")
            Else
                cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = False WHERE (((BClabelItem.BClabelItem_Field)='Catalogue_Barcode'));")
            End If
            rs.MoveNext()
        Loop
    End Sub
    Private Sub updattestck()
        Dim rs As ADODB.Recordset
        rs = getRS("SELECT BClabelItem.* from BClabelItem")
        Do Until rs.EOF
            If cStockItem = True Then
                cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = True WHERE (((BClabelItem.BClabelItem_Field)='StockItem_Name'));")
            Else
                cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = False WHERE (((BClabelItem.BClabelItem_Field)='StockItem_Name'));")
            End If
            rs.MoveNext()
        Loop
    End Sub
    Private Sub updattecomp()
        Dim rs As ADODB.Recordset

        rs = getRS("SELECT BClabelItem.* from BClabelItem")
        Do Until rs.EOF
            If cCompany = True Then
                cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = True WHERE (((BClabelItem.BClabelItem_Field)='Company_Name'));")
            Else
                cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = False WHERE (((BClabelItem.BClabelItem_Field)='Company_Name'));")
            End If
            rs.MoveNext()
        Loop

    End Sub

    Private Sub updattetel()
        Dim rs As ADODB.Recordset

        rs = getRS("SELECT BClabelItem.* from BClabelItem")
        Do Until rs.EOF
            If cCompTelephone = True Then
                cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = True WHERE (((BClabelItem.BClabelItem_Field)='Company_Telephone'));")
            Else
                cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = False WHERE (((BClabelItem.BClabelItem_Field)='Company_Telephone'));")
            End If
            rs.MoveNext()
        Loop
    End Sub

    Private Sub updatte()
        Dim rs As ADODB.Recordset

        rs = getRS("SELECT BClabelItem.* from BClabelItem")
        Do Until rs.EOF
            If cCompany = True Then
                cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = True WHERE (((BClabelItem.BClabelItem_Field)='Company_Name'));")
            Else
                cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = False WHERE (((BClabelItem.BClabelItem_Field)='Company_Name'));")
            End If

            If cCompTelephone = True Then
                cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = True WHERE (((BClabelItem.BClabelItem_Field)='Company_Telephone'));")
            Else
                cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = False WHERE (((BClabelItem.BClabelItem_Field)='Company_Telephone'));")
            End If

            If cStockItem = True Then
                cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = True WHERE (((BClabelItem.BClabelItem_Field)='StockItem_Name'));")
            Else
                cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = False WHERE (((BClabelItem.BClabelItem_Field)='StockItem_Name'));")
            End If

            If cBarcode = True Then
                cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = True WHERE (((BClabelItem.BClabelItem_Field)='Catalogue_Barcode'));")
            Else
                cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = False WHERE (((BClabelItem.BClabelItem_Field)='Catalogue_Barcode'));")
            End If

            If cGroup = True Then
                cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = True WHERE (((BClabelItem.BClabelItem_Field)='PricingGroupID'));")
            Else
                cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = False WHERE (((BClabelItem.BClabelItem_Field)='PricingGroupID'));")
            End If
            If cPrice = True Then
                cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = True WHERE (((BClabelItem.BClabelItem_Field)='Price'));")
            Else
                cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = False WHERE (((BClabelItem.BClabelItem_Field)='Price'));")
            End If
            rs.MoveNext()
        Loop
    End Sub

    Private Sub cmbfont_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbfont.Leave

        If Not IsNumeric(Me.cmbfont.Text) Then
            MsgBox("Font size must be a Number.", MsgBoxStyle.Information, "4Pos Back Office")
            Me.cmbfont.Text = "8"
            Me.cmbfont.Focus()
            Exit Sub
        Else
        End If

    End Sub

    Private Sub cmdAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdadd.Click
        'On Error Resume Next
        Dim MyInputStr As String
        Dim rst As ADODB.Recordset
        Dim rs As ADODB.Recordset
        Dim rsNoRec As ADODB.Recordset
        Dim rsBDItem As ADODB.Recordset
        Dim rsBCL As ADODB.Recordset
        Dim TheNames1 As String
        Dim RecSel1 As Short
        Dim rsLabel As ADODB.Recordset
        Dim rsCName As ADODB.Recordset
        Dim MySamp As String
        Dim TheLaID As Short
        Dim TheMSgValu As Short

        rs = New ADODB.Recordset
        rst = New ADODB.Recordset
        rsNoRec = New ADODB.Recordset
        rsBDItem = New ADODB.Recordset
        rsBCL = New ADODB.Recordset
        rsLabel = New ADODB.Recordset
        rsCName = New ADODB.Recordset


        'calling the input box
        MyInputStr = InputBox("Please enter Label Name")

        Dim apostrophe As String
        Dim TheUpOne As String

        apostrophe = "'"
        Dim pos As Short
        Dim DouQuotes As String
        Dim start As Short
        Dim MNewVerror As String
        start = 1
        DouQuotes = "''"

        MNewVerror = MyInputStr
        pos = InStr(start, MNewVerror, apostrophe)

        If pos > 0 Then

            TheUpOne = Replace(MNewVerror, apostrophe, DouQuotes, 1, pos, CompareMethod.Text)
            MyInputStr = TheUpOne
        Else
            TheUpOne = MNewVerror
            MyInputStr = TheUpOne
        End If


        'selecting the last labelID so we can increment it by one
        rs = getRS("SELECT Max(Label.LabelID) AS TheLastLabel FROM Label")
        TheLaID = rs.Fields("TheLastLabel").Value
        TheLaID = TheLaID + 1
        'checking if the name already exist
        rsCName = getRS("SELECT Label.*, LabelItem.* FROM Label INNER JOIN LabelItem ON Label.LabelID = LabelItem.labelItem_LabelID WHERE Label.Label_Name='" & MyInputStr & "' and Label.Label_Type=" & TheType & "")

        Dim LeftVa As Integer
        Dim rsFound As ADODB.Recordset
        Dim HoldMyLaID As Short
        If Trim(MyInputStr) <> "" Then
            rs = getRS("SELECT * FROM BClabelItem WHERE BClabelItem_LabelID=" & MyLIDWHole & "")

            If rs.RecordCount = 1 Then
                MsgBox("Saving an empty design is not allowed.Please add some fields.", MsgBoxStyle.Information, My.Application.Info.Title)
                Exit Sub
            Else

            End If

            'If HSLeft.value = 0 Then
            '    LeftVa = 0
            'Else
            '    LeftVa = LeftVa + 400
            'End If

            If rsCName.RecordCount < 1 Then

                rsLabel = getRS("INSERT INTO Label(LabelID,Label_Type,Label_Name,Label_Height,Label_Width,Label_Top,Label_Rotate,Label_Disabled,Label_Left)VALUES(" & TheLaID & "," & TheType & ",'" & MyInputStr & "'," & Me.HSHeight.Value & "," & Me.HSWidth.Value & "," & HSTop.Value & ",'" & 0 & "','" & 0 & "'," & HSLeft.Value & ")")

            ElseIf rsCName.RecordCount > 0 And NewLabelName = MyInputStr Then
                rsLabel = getRS("UPDATE Label SET Label_Height=" & Me.HSHeight.Value & ",Label_Width=" & Me.HSWidth.Value & ",Label_Top=" & HSTop.Value & ",Label_Rotate='" & 0 & "',Label_Disabled='" & 0 & "',Label_Name='" & MyInputStr & "',Label_Left=" & HSLeft.Value & " WHERE Label.Label_Name='" & MyInputStr & "'")
            ElseIf rsCName.RecordCount > 0 And NewLabelName <> MyInputStr Then
                TheMSgValu = MsgBox("There is a Design with the same name.Clicking Yes will override the existing design.Are you sure you wish to override the design?", MsgBoxStyle.YesNo, "4POS Back Office")
                If TheMSgValu = MsgBoxResult.Yes Then
                    rsLabel = getRS("UPDATE Label SET Label_Height=" & Me.HSHeight.Value & ",Label_Width=" & Me.HSWidth.Value & ",Label_Top=" & HSTop.Value & ",Label_Rotate='" & 0 & "',Label_Disabled='" & 0 & "',Label_Name='" & MyInputStr & "',Label_Left=" & HSLeft.Value & " WHERE Label.Label_Name='" & MyInputStr & "'")
                ElseIf TheMSgValu = MsgBoxResult.No Then
                    Exit Sub
                End If

            End If

            rst = getRS("SELECT Max(BClabelItem.BClabelItem_BCLabelID) as TheLastItemID FROM BClabelItem")

            'selecting from the selected design to modify it and added it as a new design
            rsNoRec = getRS("SELECT * FROM BClabelItem WHERE BClabelItem_BCLabelID=" & RecSel & "")

            RecSel1 = rst.Fields("TheLastItemID").Value + 1 'adding 1 to insert a new record later

            'Set rsBCL = getRS("SELECT * FROM BClabel WHERE BClabelID=" & RecSel & "")

            If rsCName.RecordCount < 1 Then
                'TheNames = TheNames
                Do Until rsNoRec.EOF

                    'for hold the sample to insert
                    If rsNoRec.Fields("BClabelItem_Field").Value = "Company_Name" And Trim(rsNoRec.Fields("BClabelItem_Sample").Value) = "" Then
                        MySamp = " "
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "Company_Name" Then
                        MySamp = "4POS Demo"
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "Company_Telephone" And Trim(rsNoRec.Fields("BClabelItem_Sample").Value) = "" Then
                        MySamp = " "
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "Company_Telephone" Then
                        MySamp = "082 448 3987"
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "line" Then
                        MySamp = " "
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "StockItem_Name" And Trim(rsNoRec.Fields("BClabelItem_Sample").Value) = "" Then
                        MySamp = " "
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "StockItem_Name" Then
                        MySamp = "Default Stock Item Name"
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "code" Then
                        MySamp = " "
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "Catalogue_Barcode" And Trim(rsNoRec.Fields("BClabelItem_Sample").Value) = "" Then
                        MySamp = " "
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "Catalogue_Barcode" Then
                        MySamp = "6001060071416"
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "PricingGroup_Name" And Trim(rsNoRec.Fields("BClabelItem_Sample").Value) = "" Then
                        MySamp = " "
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "PricingGroup_Name" Then
                        MySamp = "Beer Local"
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "Price" And Trim(rsNoRec.Fields("BClabelItem_Sample").Value) = "" Then
                        MySamp = " "
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "Price" Then
                        MySamp = "R 21.99"
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "Price6" Then
                        MySamp = "R 21.99 for   6"
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "Price12" Then
                        MySamp = "R 21.99 for  12"
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "Price24" Then
                        MySamp = "R 21.99 for  24"

                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "blank" Then
                        MySamp = " "
                    End If

                    'if field is equal to code the sample is space
                    If rsNoRec.Fields("BClabelItem_Field").Value = "code" Then
                        TheNames1 = " "
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "line" Then  'if the field is equal to line the sample is space
                        TheNames1 = " "
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "blank" Then
                        TheNames1 = " "
                    Else
                        If TheNames = "line" Then
                            TheNames1 = " "
                        Else
                            TheNames1 = rsNoRec.Fields("BClabelItem_Sample").Value
                        End If

                    End If
                    'if field is equal to code
                    If rsNoRec.Fields("BClabelItem_Field").Value = "code" Then
                        rs = getRS("INSERT INTO LabelItem(labelItem_LabelID,labelItem_Line,labelItem_Field,labelItem_Align,labelItem_Size,labelItem_Bold,labelItem_Sample) VALUES (" & TheLaID & "," & rsNoRec.Fields("BClabelItem_Line").Value & ",'code'," & rsNoRec.Fields("BClabelItem_Align").Value & "," & rsNoRec.Fields("BClabelItem_Size").Value & "," & rsNoRec.Fields("BClabelItem_Bold").Value & ",'" & TheNames1 & "')")
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "line" Then  'if field is equal to line
                        rs = getRS("INSERT INTO LabelItem(labelItem_LabelID,labelItem_Line,labelItem_Field,labelItem_Align,labelItem_Size,labelItem_Bold,labelItem_Sample) VALUES (" & TheLaID & "," & rsNoRec.Fields("BClabelItem_Line").Value & ",'line'," & rsNoRec.Fields("BClabelItem_Align").Value & "," & rsNoRec.Fields("BClabelItem_Size").Value & "," & rsNoRec.Fields("BClabelItem_Bold").Value & ",'" & TheNames1 & "')")
                        '****
                        'New code for Blank
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "blank" Then  'if field is equal to line
                        rs = getRS("INSERT INTO LabelItem(labelItem_LabelID,labelItem_Line,labelItem_Field,labelItem_Align,labelItem_Size,labelItem_Bold,labelItem_Sample) VALUES (" & TheLaID & "," & rsNoRec.Fields("BClabelItem_Line").Value & ",'blank'," & rsNoRec.Fields("BClabelItem_Align").Value & "," & rsNoRec.Fields("BClabelItem_Size").Value & "," & rsNoRec.Fields("BClabelItem_Bold").Value & ",'" & TheNames1 & "')")
                        '****
                    Else
                        rs = getRS("INSERT INTO LabelItem(labelItem_LabelID,labelItem_Line,labelItem_Field,labelItem_Align,labelItem_Size,labelItem_Bold,labelItem_Sample) VALUES (" & TheLaID & "," & rsNoRec.Fields("BClabelItem_Line").Value & ",'" & rsNoRec.Fields("BClabelItem_Field").Value & "'," & rsNoRec.Fields("BClabelItem_Align").Value & "," & rsNoRec.Fields("BClabelItem_Size").Value & "," & rsNoRec.Fields("BClabelItem_Bold").Value & ",'" & MySamp & "')")
                    End If
                    rsNoRec.MoveNext()

                Loop

                rs = getRS("SELECT * FROM BClabel WHERE BClabelID=" & RecSel & "")

                'For Inserting New Record into BClabel
                rsCName = getRS("INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES(" & RecSel1 & ",'" & rs.Fields("BClabel_Name").Value & "','" & rs.Fields("BClabel_Type").Value & "'," & rs.Fields("BClabel_Disabled").Value & "," & rs.Fields("BClabel_Height").Value & "," & TheLaID & ")")

                rs = getRS("SELECT * FROM LabelItem WHERE labelItem_LabelID=" & TheLaID & "")

                'For Inserting New record into BCLabelItem
                'If rs.RecordCount > 0 Then
                'End If
                Do Until rs.EOF
                    rsCName = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & RecSel1 & "," & rs.Fields("labelItem_Line").Value & ",'" & rs.Fields("labelItem_Field").Value & "'," & rs.Fields("labelItem_Align").Value & "," & rs.Fields("labelItem_Size").Value & "," & rs.Fields("labelItem_Bold").Value & ",'" & rs.Fields("labelItem_Sample").Value & "','" & 0 & "'," & TheLaID & ")")
                    rs.MoveNext()
                Loop
                '000
                rsCName = getRS("SELECT * FROM BClabelItemUndo")

                If rsCName.RecordCount > 0 Then
                    rs = getRS("SELECT * FROM BClabelItemUndo")
                Else
                    TheSelectedPrinterNew = 2
                    MyLIDWHole = TheLaID
                    labelsfile()
                    Exit Sub
                End If
                'rs.MoveLast

                Do Until rs.EOF
                    rsNoRec = getRS("SELECT * FROM BClabelItem WHERE BClabelItemID =" & rs.Fields("BClabelItemID").Value & " AND BClabelItem_Field='" & rs.Fields("BClabelItem_Field").Value & "'")

                    If rsNoRec.RecordCount > 0 Then
                        rst = getRS("DELETE * FROM BClabelItem WHERE BClabelItemID=" & rs.Fields("BClabelItemID").Value & "")

                        'Set rst = getRS("DELETE * FROM BClabelItemUndo WHERE BClabelItemID=" & rs("BClabelItemID") & "")
                    ElseIf rsNoRec.RecordCount < 1 Then
                        rst = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rs.Fields("BClabelItem_BCLabelID").Value & "," & rs.Fields("BClabelItem_Line").Value & ",'" & rs.Fields("BClabelItem_Field").Value & "'," & rs.Fields("BClabelItem_Align").Value & "," & rs.Fields("BClabelItem_Size").Value & "," & rs.Fields("BClabelItem_Bold").Value & ",'" & rs.Fields("BClabelItem_Sample").Value & "'," & rs.Fields("BClabelItem_Disabled").Value & "," & rs.Fields("BClabelItem_LabelID").Value & ")")
                        'Set rst = getRS("DELETE * FROM BClabelItemUndo WHERE BClabelItemID=" & rs("BClabelItemID") & " and BClabelItem_Field='" & rs("BClabelItem_Field") & "'")
                    End If

                    rs.MoveNext()
                Loop
                rst = getRS("DELETE * FROM BClabelItemUndo") ' WHERE BClabelItemID=" & rs("BClabelItemID") & " and BClabelItem_Field='" & rs("BClabelItem_Field") & "'")
                MyLIDWHole = TheLaID
                RecSel = RecSel1
                '000
            Else
                'updating
                rsFound = New ADODB.Recordset

                HoldMyLaID = rsCName.Fields("labelItem_LabelID").Value

                rsFound = getRS("DELETE * FROM LabelItem WHERE labelItem_LabelID=" & HoldMyLaID & "")

                Do Until rsNoRec.EOF

                    'for hold the sample to insert
                    If rsNoRec.Fields("BClabelItem_Field").Value = "Company_Name" And Trim(rsNoRec.Fields("BClabelItem_Sample").Value) = "" Then
                        MySamp = " "
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "Company_Name" Then
                        MySamp = "4POS Demo"
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "Company_Telephone" And Trim(rsNoRec.Fields("BClabelItem_Sample").Value) = "" Then
                        MySamp = " "
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "Company_Telephone" Then
                        MySamp = "082 448 3987"
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "line" Then
                        MySamp = " "
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "StockItem_Name" And Trim(rsNoRec.Fields("BClabelItem_Sample").Value) = "" Then
                        MySamp = " "
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "StockItem_Name" Then
                        MySamp = "Default Stock Item Name"
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "code" Then
                        MySamp = " "
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "Catalogue_Barcode" And Trim(rsNoRec.Fields("BClabelItem_Sample").Value) = "" Then
                        MySamp = " "
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "Catalogue_Barcode" Then
                        MySamp = "6001060071416"
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "PricingGroup_Name" And Trim(rsNoRec.Fields("BClabelItem_Sample").Value) = "" Then
                        MySamp = " "
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "PricingGroup_Name" Then
                        MySamp = "Beer Local"
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "Price" And Trim(rsNoRec.Fields("BClabelItem_Sample").Value) = "" Then
                        MySamp = " "
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "Price" Then
                        MySamp = "R 21.99"
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "Price6" Then
                        MySamp = "R 21.99 for   6"
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "Price12" Then
                        MySamp = "R 21.99 for  12"
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "Price24" Then
                        MySamp = "R 21.99 for  24"

                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "blank" Then
                        MySamp = " "
                    End If

                    'if field is equal to code the sample is space
                    If rsNoRec.Fields("BClabelItem_Field").Value = "code" Then
                        TheNames1 = " "
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "line" Then  'if the field is equal to line the sample is space
                        TheNames1 = " "
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "blank" Then
                        TheNames1 = " "
                    Else
                        If TheNames = "line" Then
                            TheNames1 = " "
                        Else
                            TheNames1 = rsNoRec.Fields("BClabelItem_Sample").Value
                        End If
                    End If
                    'if field is equal to code
                    If rsNoRec.Fields("BClabelItem_Field").Value = "code" Then
                        rs = getRS("INSERT INTO LabelItem(labelItem_LabelID,labelItem_Line,labelItem_Field,labelItem_Align,labelItem_Size,labelItem_Bold,labelItem_Sample) VALUES (" & HoldMyLaID & "," & rsNoRec.Fields("BClabelItem_Line").Value & ",'code'," & rsNoRec.Fields("BClabelItem_Align").Value & "," & rsNoRec.Fields("BClabelItem_Size").Value & "," & rsNoRec.Fields("BClabelItem_Bold").Value & ",'" & TheNames1 & "')")
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "line" Then  'if field is equal to line
                        rs = getRS("INSERT INTO LabelItem(labelItem_LabelID,labelItem_Line,labelItem_Field,labelItem_Align,labelItem_Size,labelItem_Bold,labelItem_Sample) VALUES (" & HoldMyLaID & "," & rsNoRec.Fields("BClabelItem_Line").Value & ",'line'," & rsNoRec.Fields("BClabelItem_Align").Value & "," & rsNoRec.Fields("BClabelItem_Size").Value & "," & rsNoRec.Fields("BClabelItem_Bold").Value & ",'" & TheNames1 & "')")
                        '****
                        'New code for Blank
                    ElseIf rsNoRec.Fields("BClabelItem_Field").Value = "blank" Then  'if field is equal to line
                        rs = getRS("INSERT INTO LabelItem(labelItem_LabelID,labelItem_Line,labelItem_Field,labelItem_Align,labelItem_Size,labelItem_Bold,labelItem_Sample) VALUES (" & HoldMyLaID & "," & rsNoRec.Fields("BClabelItem_Line").Value & ",'blank'," & rsNoRec.Fields("BClabelItem_Align").Value & "," & rsNoRec.Fields("BClabelItem_Size").Value & "," & rsNoRec.Fields("BClabelItem_Bold").Value & ",'" & TheNames1 & "')")
                        '****
                    Else
                        rs = getRS("INSERT INTO LabelItem(labelItem_LabelID,labelItem_Line,labelItem_Field,labelItem_Align,labelItem_Size,labelItem_Bold,labelItem_Sample) VALUES (" & HoldMyLaID & "," & rsNoRec.Fields("BClabelItem_Line").Value & ",'" & rsNoRec.Fields("BClabelItem_Field").Value & "'," & rsNoRec.Fields("BClabelItem_Align").Value & "," & rsNoRec.Fields("BClabelItem_Size").Value & "," & rsNoRec.Fields("BClabelItem_Bold").Value & ",'" & MySamp & "')")
                    End If
                    rsNoRec.MoveNext()
                Loop

                'updating
            End If

        ElseIf Trim(MyInputStr) = "" Then
            Exit Sub
        End If
        'refreshes

        TheSelectedPrinterNew = 2
        NewLabelName = ""
        labelsfile()
        'RecSel1 = 3
        'Unload frmPrinter
        'frmPrinter.selectPrinter
        'frmBarcodedesign.TheLoading
        'TheSelectedPrinterNew = 0

    End Sub

    Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
        'On Error GoTo ErrH
        Dim rs As ADODB.Recordset
        Dim rst As ADODB.Recordset
        Dim rsHave As ADODB.Recordset
        Dim rsMaxID As ADODB.Recordset
        Dim HoldBClabelItem_BCLabelID As Short
        Dim TheSample As String
        Dim rsInner As ADODB.Recordset
        Dim HoldLaIDVaBack As Short
        Dim TMaxID As Short

        rs = New ADODB.Recordset
        rst = New ADODB.Recordset
        rsHave = New ADODB.Recordset
        rsInner = New ADODB.Recordset
        rsMaxID = New ADODB.Recordset

        IntDesign = 0 'New code

        rs = getRS("DELETE * FROM BClabelItemUndo")

        strheight = 0
        strwidht = 0

        rs = getRS("SELECT * FROM LabelItem WHERE labelItem_LabelID=" & MyLIDWHole & "")

        If rs.RecordCount = 1 Then

            rs = getRS("DELETE * FROM LabelItem WHERE labelItem_LabelID=" & MyLIDWHole & "")
            rs = getRS("DELETE * FROM Label WHERE LabelID=" & MyLIDWHole & "")
            rs = getRS("DELETE * FROM BClabel WHERE BClabel_LabelID=" & MyLIDWHole & "")
            rs = getRS("DELETE * FROM BClabelItem WHERE BClabelItem_LabelID=" & MyLIDWHole & "")
            Me.Close()
            frmDesign.RefreshLoad(TheType)
            Exit Sub

        Else

        End If

        rs = getRS("SELECT Max(LabelItem.labelItem_LabelID) as TheMaxID FROM LabelItem")
        TMaxID = rs.Fields("TheMaxID").Value

        rs = getRS("SELECT * FROM LabelItem ORDER BY labelItem_LabelID")

        rs.MoveFirst()
        'Loading BClabelItem with Infor from LabelItem
        Do Until rs.EOF
            On Error Resume Next
            rsHave = getRS("SELECT * FROM BClabelItem WHERE BClabelItem_LabelID=" & rs.Fields("labelItem_LabelID").Value & "")
            HoldBClabelItem_BCLabelID = rsHave.Fields("BClabelItem_BCLabelID").Value

            rst = getRS("DELETE * FROM BClabelItem WHERE BClabelItem_LabelID =" & rs.Fields("labelItem_LabelID").Value & "")

            rsInner = getRS("SELECT * FROM LabelItem WHERE labelItem_LabelID=" & rs.Fields("labelItem_LabelID").Value & "")
            Do Until rsInner.EOF
                If IsDBNull(rsInner.Fields("labelItem_Sample").Value) Then
                    TheSample = " "
                Else
                    TheSample = rsInner.Fields("labelItem_Sample").Value
                End If
                rst = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & HoldBClabelItem_BCLabelID & "," & rsInner.Fields("labelItem_Line").Value & ",'" & rsInner.Fields("labelItem_Field").Value & "'," & rsInner.Fields("labelItem_Align").Value & "," & rsInner.Fields("labelItem_Size").Value & "," & rsInner.Fields("labelItem_Bold").Value & ",'" & TheSample & "','" & 0 & "'," & rsInner.Fields("labelItem_LabelID").Value & ")")
                rsInner.MoveNext()
            Loop

            HoldLaIDVaBack = rs.Fields("labelItem_LabelID").Value
            rs.MoveNext()

            Do Until rs.Fields("labelItem_LabelID").Value <> HoldLaIDVaBack

                If rs.Fields("labelItem_LabelID").Value = TMaxID Then
                    rs.MoveLast()
                    rs.MoveNext()
                    Exit Do
                End If

                rs.MoveNext()
            Loop

        Loop

        Me.Close()
        frmDesign.RefreshLoad(TheType)
        'ErrH:    frmDesign.RefreshLoad TheType

        'frmdesign.RefreshLoad TheType
    End Sub

    Private Sub cmdLoad_Click()
        Dim fso As New Scripting.FileSystemObject
        Dim strname As String

        Me.ShowDialog()

    End Sub

    Private Sub cmdnormal_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdnormal.Click
        'Dim rs As ADODB.Recordset
        'Dim rst As ADODB.Recordset
        'Dim TheSam As String
        'Set rs = New ADODB.Recordset
        'Set rst = New ADODB.Recordset

        'Set rs = getRS("DELETE * FROM BClabel")
        'Set rs = getRS("DELETE * FROM BClabelItem")

        'Set rst = getRS("SELECT * FROM BClabelNormal")

        'Do Until rst.EOF
        'Set rs = getRS("INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height)VALUES(" & rst("BClabelID") & ",'" & rst("BClabel_Name") & "','" & rst("BClabel_Type") & "'," & rst("BClabel_Disabled") & "," & rst("BClabel_Height") & ")")

        'rst.MoveNext
        'Loop

        'Set rst = getRS("SELECT * FROM BClabelItemNormal")'

        'Do Until rst.EOF
        '    If IsNull(rst("BClabelItem_Sample")) Then
        '    TheSam = " "
        '    Else
        '    TheSam = rst("BClabelItem_Sample")
        '    End If
        'Set rs = getRS("INSERT INTO BClabelItem(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rst("BClabelItemID") & "," & rst("BClabelItem_BCLabelID") & "," & rst("BClabelItem_Line") & ",'" & rst("BClabelItem_Field") & "'," & rst("BClabelItem_Align") & "," & rst("BClabelItem_Size") & "," & rst("BClabelItem_Bold") & ",'" & TheSam & " '," & rst("BClabelItem_Disabled") & "," & MyLIDWHole & ")")

        'rst.MoveNext
        'Loop

        'TheSelectedPrinterNew = 2

        'labelsfile
    End Sub

    Private Sub cmdOffset_Click()
        'Dim frm As New frmBarcodeOffset
        'frm.Show(1)
    End Sub

    Private Sub cmdSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSave.Click
        On Error Resume Next
        Dim rs As ADODB.Recordset
        Dim rst As ADODB.Recordset
        Dim RecSel1 As Short
        Dim TheSpacess As String
        Dim MyLines As String
        rs = New ADODB.Recordset
        rst = New ADODB.Recordset
        Dim rsMax As ADODB.Recordset
        Dim ThePosition As Short
        Dim TheCode As Short
        Dim rsDet As ADODB.Recordset
        rsMax = New ADODB.Recordset
        rsDet = New ADODB.Recordset


        'If Not IsNumeric(Me.txtpos.Text) Then
        '    MsgBox "Row Position Must be a Number.", vbInformation, "4Pos Back Office"
        'Exit Sub
        'Else
        'End If


        'for a sample of the selected field
        If TheNames = "Price" Then 'Designing barcodes
            TheSpacess = "R 21.99"
            If _chkFields_4.CheckState = 1 Then 'And rsT.RecordCount < 1 Then

                If Me._chkFields_0.CheckState = 1 Then
                    rs = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 1 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & " )")
                    rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
                    rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("TheLastDe").Value & "," & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 1 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                Else
                    rs = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 0 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & " )")
                    rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
                    rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("TheLastDe").Value & "," & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 0 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                End If

                'ElseIf _chkFields_4.value = 1 And rsT.RecordCount > 0 Then
                'Set rs = getRS("UPDATE BClabelItem SET BClabelItem_Line=" & ThePosition & ",BClabelItem_Field='" & TheNames & "',BClabelItem_Align=" & MyFAlign & ",BClabelItem_Size=" & Me.cmbfont.Text & ",BClabelItem_Sample='" & TheSpacess & "',BClabelItem_Disabled='" & 0 & "' WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
            ElseIf _chkFields_4.CheckState = 0 Then
                'Set rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
                rsDet = getRS("SELECT * FROM BClabelItem WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
                rsDet.MoveFirst()
                rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("BClabelItemID").Value & "," & RecSel & "," & rsDet.Fields("BClabelItem_Line").Value & ",'" & TheNames & "'," & rsDet.Fields("BClabelItem_Align").Value & "," & rsDet.Fields("BClabelItem_Size").Value & "," & rsDet.Fields("BClabelItem_Bold").Value & ",'" & TheSpacess & "'," & rsDet.Fields("BClabelItem_Disabled").Value & "," & MyLIDWHole & ")")
                rs = getRS("DELETE * FROM BClabelItem WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "' and BClabelItemID=" & rsDet.Fields("BClabelItemID").Value & "")
            End If

        ElseIf TheNames = "Price6" Then  'Designing barcodes
            TheSpacess = "R 21.99 for   6"
            If _chkFields_4.CheckState = 1 Then 'And rsT.RecordCount < 1 Then

                If Me._chkFields_0.CheckState = 1 Then
                    rs = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 1 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & " )")
                    rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
                    rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("TheLastDe").Value & "," & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 1 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                Else
                    rs = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 0 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & " )")
                    rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
                    rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("TheLastDe").Value & "," & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 0 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                End If

                'ElseIf _chkFields_4.value = 1 And rsT.RecordCount > 0 Then
                'Set rs = getRS("UPDATE BClabelItem SET BClabelItem_Line=" & ThePosition & ",BClabelItem_Field='" & TheNames & "',BClabelItem_Align=" & MyFAlign & ",BClabelItem_Size=" & Me.cmbfont.Text & ",BClabelItem_Sample='" & TheSpacess & "',BClabelItem_Disabled='" & 0 & "' WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
            ElseIf _chkFields_4.CheckState = 0 Then
                'Set rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
                rsDet = getRS("SELECT * FROM BClabelItem WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
                rsDet.MoveFirst()
                rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("BClabelItemID").Value & "," & RecSel & "," & rsDet.Fields("BClabelItem_Line").Value & ",'" & TheNames & "'," & rsDet.Fields("BClabelItem_Align").Value & "," & rsDet.Fields("BClabelItem_Size").Value & "," & rsDet.Fields("BClabelItem_Bold").Value & ",'" & TheSpacess & "'," & rsDet.Fields("BClabelItem_Disabled").Value & "," & MyLIDWHole & ")")
                rs = getRS("DELETE * FROM BClabelItem WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "' and BClabelItemID=" & rsDet.Fields("BClabelItemID").Value & "")
            End If

        ElseIf TheNames = "Price12" Then  'Designing barcodes
            TheSpacess = "R 21.99 for  12"
            If _chkFields_4.CheckState = 1 Then 'And rsT.RecordCount < 1 Then

                If Me._chkFields_0.CheckState = 1 Then
                    rs = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 1 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & " )")
                    rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
                    rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("TheLastDe").Value & "," & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 1 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                Else
                    rs = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 0 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & " )")
                    rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
                    rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("TheLastDe").Value & "," & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 0 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                End If

                'ElseIf _chkFields_4.value = 1 And rsT.RecordCount > 0 Then
                'Set rs = getRS("UPDATE BClabelItem SET BClabelItem_Line=" & ThePosition & ",BClabelItem_Field='" & TheNames & "',BClabelItem_Align=" & MyFAlign & ",BClabelItem_Size=" & Me.cmbfont.Text & ",BClabelItem_Sample='" & TheSpacess & "',BClabelItem_Disabled='" & 0 & "' WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
            ElseIf _chkFields_4.CheckState = 0 Then
                'Set rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
                rsDet = getRS("SELECT * FROM BClabelItem WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
                rsDet.MoveFirst()
                rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("BClabelItemID").Value & "," & RecSel & "," & rsDet.Fields("BClabelItem_Line").Value & ",'" & TheNames & "'," & rsDet.Fields("BClabelItem_Align").Value & "," & rsDet.Fields("BClabelItem_Size").Value & "," & rsDet.Fields("BClabelItem_Bold").Value & ",'" & TheSpacess & "'," & rsDet.Fields("BClabelItem_Disabled").Value & "," & MyLIDWHole & ")")
                rs = getRS("DELETE * FROM BClabelItem WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "' and BClabelItemID=" & rsDet.Fields("BClabelItemID").Value & "")
            End If

        ElseIf TheNames = "Price24" Then  'Designing barcodes
            TheSpacess = "R 21.99 for  24"
            If _chkFields_4.CheckState = 1 Then 'And rsT.RecordCount < 1 Then

                If Me._chkFields_0.CheckState = 1 Then
                    rs = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 1 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & " )")
                    rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
                    rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("TheLastDe").Value & "," & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 1 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                Else
                    rs = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 0 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & " )")
                    rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
                    rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("TheLastDe").Value & "," & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 0 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                End If

                'ElseIf _chkFields_4.value = 1 And rsT.RecordCount > 0 Then
                'Set rs = getRS("UPDATE BClabelItem SET BClabelItem_Line=" & ThePosition & ",BClabelItem_Field='" & TheNames & "',BClabelItem_Align=" & MyFAlign & ",BClabelItem_Size=" & Me.cmbfont.Text & ",BClabelItem_Sample='" & TheSpacess & "',BClabelItem_Disabled='" & 0 & "' WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
            ElseIf _chkFields_4.CheckState = 0 Then
                'Set rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
                rsDet = getRS("SELECT * FROM BClabelItem WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
                rsDet.MoveFirst()
                rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("BClabelItemID").Value & "," & RecSel & "," & rsDet.Fields("BClabelItem_Line").Value & ",'" & TheNames & "'," & rsDet.Fields("BClabelItem_Align").Value & "," & rsDet.Fields("BClabelItem_Size").Value & "," & rsDet.Fields("BClabelItem_Bold").Value & ",'" & TheSpacess & "'," & rsDet.Fields("BClabelItem_Disabled").Value & "," & MyLIDWHole & ")")
                rs = getRS("DELETE * FROM BClabelItem WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "' and BClabelItemID=" & rsDet.Fields("BClabelItemID").Value & "")
            End If

        ElseIf TheNames = "Company_Name" Then
            TheSpacess = "4POS Demo"
            If _chkFields_4.CheckState = 1 Then 'And rsT.RecordCount < 1 Then
                If Me._chkFields_0.CheckState = 1 Then
                    rs = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 1 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                    rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
                    rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("TheLastDe").Value & "," & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 1 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                Else
                    rs = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 0 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                    rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
                    rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("TheLastDe").Value & "," & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 0 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                End If

                'ElseIf _chkFields_4.value = 1 And rsT.RecordCount > 0 Then
                'Set rs = getRS("UPDATE BClabelItem SET BClabelItem_Line=" & ThePosition & ",BClabelItem_Field='" & TheNames & "',BClabelItem_Align=" & MyFAlign & ",BClabelItem_Size=" & Me.cmbfont.Text & ",BClabelItem_Sample='" & TheSpacess & "',BClabelItem_Disabled='" & 0 & "' WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
            ElseIf _chkFields_4.CheckState = 0 Then
                rsDet = getRS("SELECT * FROM BClabelItem WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
                rsDet.MoveFirst()
                rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("BClabelItemID").Value & "," & RecSel & "," & rsDet.Fields("BClabelItem_Line").Value & ",'" & TheNames & "'," & rsDet.Fields("BClabelItem_Align").Value & "," & rsDet.Fields("BClabelItem_Size").Value & "," & rsDet.Fields("BClabelItem_Bold").Value & ",'" & TheSpacess & "'," & rsDet.Fields("BClabelItem_Disabled").Value & "," & MyLIDWHole & ")")
                rs = getRS("DELETE * FROM BClabelItem WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "' and BClabelItemID=" & rsDet.Fields("BClabelItemID").Value & "")
            End If

        ElseIf TheNames = "StockItem_Name" Then
            TheSpacess = "Default Stock Item Name"
            If _chkFields_4.CheckState = 1 Then 'And rsT.RecordCount < 1 Then
                If Me._chkFields_0.CheckState = 1 Then

                    rs = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 1 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                    rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
                    rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("TheLastDe").Value & "," & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 1 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                Else
                    rs = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 0 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                    rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
                    rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("TheLastDe").Value & "," & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 0 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                End If

                'ElseIf _chkFields_4.value = 1 And rsT.RecordCount > 0 Then
                'Set rs = getRS("UPDATE BClabelItem SET BClabelItem_Line=" & ThePosition & ",BClabelItem_Field='" & TheNames & "',BClabelItem_Align=" & MyFAlign & ",BClabelItem_Size=" & Me.cmbfont.Text & ",BClabelItem_Sample='" & TheSpacess & "',BClabelItem_Disabled='" & 0 & "' WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
            ElseIf _chkFields_4.CheckState = 0 Then
                rsDet = getRS("SELECT * FROM BClabelItem WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
                rsDet.MoveFirst()

                rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("BClabelItemID").Value & "," & RecSel & "," & rsDet.Fields("BClabelItem_Line").Value & ",'" & TheNames & "'," & rsDet.Fields("BClabelItem_Align").Value & "," & rsDet.Fields("BClabelItem_Size").Value & "," & rsDet.Fields("BClabelItem_Bold").Value & ",'" & TheSpacess & "'," & rsDet.Fields("BClabelItem_Disabled").Value & "," & MyLIDWHole & ")")
                rs = getRS("DELETE * FROM BClabelItem WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "' and BClabelItemID=" & rsDet.Fields("BClabelItemID").Value & "")
            End If

        ElseIf TheNames = "Catalogue_Barcode" Then
            TheSpacess = "6001060071416"
            If _chkFields_4.CheckState = 1 Then 'And rsT.RecordCount < 1 Then
                If Me._chkFields_0.CheckState = 1 Then
                    rs = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 1 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                    rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
                    rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("TheLastDe").Value & "," & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 1 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                Else
                    rs = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 0 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                    rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
                    rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("TheLastDe").Value & "," & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 0 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                End If

                'ElseIf _chkFields_4.value = 1 And rsT.RecordCount > 0 Then
                'Set rs = getRS("UPDATE BClabelItem SET BClabelItem_Line=" & ThePosition & ",BClabelItem_Field='" & TheNames & "',BClabelItem_Align=" & MyFAlign & ",BClabelItem_Size=" & Me.cmbfont.Text & ",BClabelItem_Sample='" & TheSpacess & "',BClabelItem_Disabled='" & 0 & "' WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
            ElseIf _chkFields_4.CheckState = 0 Then
                rsDet = getRS("SELECT * FROM BClabelItem WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
                rsDet.MoveFirst()
                rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("BClabelItemID").Value & "," & RecSel & "," & rsDet.Fields("BClabelItem_Line").Value & ",'" & TheNames & "'," & rsDet.Fields("BClabelItem_Align").Value & "," & rsDet.Fields("BClabelItem_Size").Value & "," & rsDet.Fields("BClabelItem_Bold").Value & ",'" & TheSpacess & "'," & rsDet.Fields("BClabelItem_Disabled").Value & "," & MyLIDWHole & ")")
                rs = getRS("DELETE * FROM BClabelItem WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "' and BClabelItemID=" & rsDet.Fields("BClabelItemID").Value & "")
            End If

        ElseIf TheNames = "Company_Telephone" Then
            TheSpacess = "082 448 3987"
            If _chkFields_4.CheckState = 1 Then 'And rsT.RecordCount < 1 Then
                If Me._chkFields_0.CheckState = 1 Then
                    rs = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 1 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                    rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
                    rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("TheLastDe").Value & "," & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 1 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                Else
                    rs = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 0 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                    rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
                    rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("TheLastDe").Value & "," & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 0 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                End If

                'ElseIf _chkFields_4.value = 1 And rsT.RecordCount > 0 Then
                '    Set rs = getRS("UPDATE BClabelItem SET BClabelItem_Line=" & ThePosition & ",BClabelItem_Field='" & TheNames & "',BClabelItem_Align=" & MyFAlign & ",BClabelItem_Size=" & Me.cmbfont.Text & ",BClabelItem_Sample='" & TheSpacess & "',BClabelItem_Disabled='" & 0 & "' WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
            ElseIf _chkFields_4.CheckState = 0 Then
                rsDet = getRS("SELECT * FROM BClabelItem WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
                rsDet.MoveFirst()
                rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("BClabelItemID").Value & "," & RecSel & "," & rsDet.Fields("BClabelItem_Line").Value & ",'" & TheNames & "'," & rsDet.Fields("BClabelItem_Align").Value & "," & rsDet.Fields("BClabelItem_Size").Value & "," & rsDet.Fields("BClabelItem_Bold").Value & ",'" & TheSpacess & "'," & rsDet.Fields("BClabelItem_Disabled").Value & "," & MyLIDWHole & ")")
                rs = getRS("DELETE * FROM BClabelItem WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "' and BClabelItemID=" & rsDet.Fields("BClabelItemID").Value & "")
            End If

        ElseIf TheNames = "PricingGroup_Name" Then
            TheSpacess = "Beer Local"
            If _chkFields_4.CheckState = 1 Then 'And rsT.RecordCount < 1 Then
                If Me._chkFields_0.CheckState = 1 Then
                    rs = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 1 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                    rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
                    rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("TheLastDe").Value & "," & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 1 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                Else
                    rs = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 0 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                    rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
                    rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("TheLastDe").Value & "," & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 0 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                End If

                'ElseIf _chkFields_4.value = 1 And rsT.RecordCount > 0 Then
                'Set rs = getRS("UPDATE BClabelItem SET BClabelItem_Line=" & ThePosition & ",BClabelItem_Field='" & TheNames & "',BClabelItem_Align=" & MyFAlign & ",BClabelItem_Size=" & Me.cmbfont.Text & ",BClabelItem_Sample='" & TheSpacess & "',BClabelItem_Disabled='" & 0 & "' WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
            ElseIf _chkFields_4.CheckState = 0 Then
                rsDet = getRS("SELECT * FROM BClabelItem WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
                rsDet.MoveFirst()
                rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("BClabelItemID").Value & "," & RecSel & "," & rsDet.Fields("BClabelItem_Line").Value & ",'" & TheNames & "'," & rsDet.Fields("BClabelItem_Align").Value & "," & rsDet.Fields("BClabelItem_Size").Value & "," & rsDet.Fields("BClabelItem_Bold").Value & ",'" & TheSpacess & "'," & rsDet.Fields("BClabelItem_Disabled").Value & "," & MyLIDWHole & ")")
                rs = getRS("DELETE * FROM BClabelItem WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "' and BClabelItemID=" & rsDet.Fields("BClabelItemID").Value & "")
            End If

        ElseIf TheNames = "line" Then
            TheSpacess = " "
            If _chkFields_4.CheckState = 1 Then 'And rsT.RecordCount < 1 Then
                If Me._chkFields_0.CheckState = 1 Then
                    rs = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 1 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                    rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
                    rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("TheLastDe").Value & "," & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 1 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                Else
                    rs = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 0 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                    rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
                    rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("TheLastDe").Value & "," & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 0 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                End If

                'ElseIf _chkFields_4.value = 1 And rsT.RecordCount > 0 Then
                'Set rs = getRS("UPDATE BClabelItem SET BClabelItem_Line=" & ThePosition & ",BClabelItem_Field='" & TheNames & "',BClabelItem_Align=" & MyFAlign & ",BClabelItem_Size=" & Me.cmbfont.Text & ",BClabelItem_Sample='" & TheSpacess & "',BClabelItem_Disabled='" & 0 & "' WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
            ElseIf _chkFields_4.CheckState = 0 Then
                rsDet = getRS("SELECT * FROM BClabelItem WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
                rsDet.MoveFirst()
                rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("BClabelItemID").Value & "," & RecSel & "," & rsDet.Fields("BClabelItem_Line").Value & ",'" & TheNames & "'," & rsDet.Fields("BClabelItem_Align").Value & "," & rsDet.Fields("BClabelItem_Size").Value & "," & rsDet.Fields("BClabelItem_Bold").Value & ",'" & TheSpacess & "'," & rsDet.Fields("BClabelItem_Disabled").Value & "," & MyLIDWHole & ")")
                rs = getRS("DELETE * FROM BClabelItem WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "' and BClabelItemID=" & rsDet.Fields("BClabelItemID").Value & "")
            End If

            '*****
            'Blank
        ElseIf TheNames = "blank" Then
            TheSpacess = " "
            If _chkFields_4.CheckState = 1 Then 'And rsT.RecordCount < 1 Then
                If Me._chkFields_0.CheckState = 1 Then
                    rs = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 1 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                    rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
                    rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("TheLastDe").Value & "," & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 1 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                Else
                    rs = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 0 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                    rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
                    rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("TheLastDe").Value & "," & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 0 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                End If

                'ElseIf _chkFields_4.value = 1 And rsT.RecordCount > 0 Then
                'Set rs = getRS("UPDATE BClabelItem SET BClabelItem_Line=" & ThePosition & ",BClabelItem_Field='" & TheNames & "',BClabelItem_Align=" & MyFAlign & ",BClabelItem_Size=" & Me.cmbfont.Text & ",BClabelItem_Sample='" & TheSpacess & "',BClabelItem_Disabled='" & 0 & "' WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
            ElseIf _chkFields_4.CheckState = 0 Then
                rsDet = getRS("SELECT * FROM BClabelItem WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
                rsDet.MoveFirst()
                rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("BClabelItemID").Value & "," & RecSel & "," & rsDet.Fields("BClabelItem_Line").Value & ",'" & TheNames & "'," & rsDet.Fields("BClabelItem_Align").Value & "," & rsDet.Fields("BClabelItem_Size").Value & "," & rsDet.Fields("BClabelItem_Bold").Value & ",'" & TheSpacess & "'," & rsDet.Fields("BClabelItem_Disabled").Value & "," & MyLIDWHole & ")")
                rs = getRS("DELETE * FROM BClabelItem WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "' and BClabelItemID=" & rsDet.Fields("BClabelItemID").Value & "")
            End If
            '****

        ElseIf TheNames = "code" Then

            If CDbl(Me.txtpos.Text) = -2 Then
                TheCode = 50
            ElseIf CDbl(Me.txtpos.Text) = 0 Then
                TheCode = 50
            ElseIf CDbl(Me.txtpos.Text) = 1 Then
                TheCode = 45
            ElseIf CDbl(Me.txtpos.Text) = 2 Then
                TheCode = 40
            ElseIf CDbl(Me.txtpos.Text) = 3 Then
                TheCode = 35
            ElseIf CDbl(Me.txtpos.Text) = 4 Then
                TheCode = 30
            ElseIf CDbl(Me.txtpos.Text) = 5 Then
                TheCode = 25
            ElseIf CDbl(Me.txtpos.Text) = 6 Then
                TheCode = 20
            ElseIf CDbl(Me.txtpos.Text) = 7 Then
                TheCode = 15
            ElseIf CDbl(Me.txtpos.Text) = 8 Then
                TheCode = 10
            ElseIf CDbl(Me.txtpos.Text) = 7 Then
                TheCode = 5
            ElseIf CDbl(Me.txtpos.Text) = 8 Then
                TheCode = 0
            End If

            'Set rs = getRS("UPDATE BClabel SET BClabel_Height=" & TheCode & " WHERE BClabelID=" & RecSel & "")

            TheSpacess = " "
            If _chkFields_4.CheckState = 1 Then 'And rsT.RecordCount < 1 Then
                If Me._chkFields_0.CheckState = 1 Then
                    rs = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 1 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                    rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
                    rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("TheLastDe").Value & "," & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 1 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                Else
                    rs = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 0 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                    rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
                    rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("TheLastDe").Value & "," & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 0 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")
                End If

                If CDbl(Me.txtpos.Text) = -2 Then
                    rs = getRS("UPDATE BClabel SET BClabel_Height=" & 50 & " WHERE BClabelID=" & RecSel & "")
                ElseIf CDbl(Me.txtpos.Text) = 0 Then
                    rs = getRS("UPDATE BClabel SET BClabel_Height=" & 40 & " WHERE BClabelID=" & RecSel & "")
                ElseIf CDbl(Me.txtpos.Text) = 2 Then
                    rs = getRS("UPDATE BClabel SET BClabel_Height=" & 40 & " WHERE BClabelID=" & RecSel & "")
                ElseIf CDbl(Me.txtpos.Text) = 3 Then
                    rs = getRS("UPDATE BClabel SET BClabel_Height=" & 35 & " WHERE BClabelID=" & RecSel & "")
                ElseIf CDbl(Me.txtpos.Text) = 4 Then
                    rs = getRS("UPDATE BClabel SET BClabel_Height=" & 30 & " WHERE BClabelID=" & RecSel & "")
                ElseIf CDbl(Me.txtpos.Text) = 5 Then
                    rs = getRS("UPDATE BClabel SET BClabel_Height=" & 20 & " WHERE BClabelID=" & RecSel & "")
                ElseIf CDbl(Me.txtpos.Text) = 6 Then
                    rs = getRS("UPDATE BClabel SET BClabel_Height=" & 10 & " WHERE BClabelID=" & RecSel & "")
                ElseIf CDbl(Me.txtpos.Text) = 7 Then
                    rs = getRS("UPDATE BClabel SET BClabel_Height=" & 0 & " WHERE BClabelID=" & RecSel & "")
                End If
                'ElseIf _chkFields_4.value = 1 And rsT.RecordCount > 0 Then
                'Set rs = getRS("UPDATE BClabelItem SET BClabelItem_Line=" & ThePosition & ",BClabelItem_Field='" & TheNames & "',BClabelItem_Align=" & MyFAlign & ",BClabelItem_Size=" & Me.cmbfont.Text & ",BClabelItem_Sample='" & TheSpacess & "',BClabelItem_Disabled='" & 0 & "' WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
            ElseIf _chkFields_4.CheckState = 0 Then
                'Set rs = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 1 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")

                rsDet = getRS("SELECT * FROM BClabelItem WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")

                rsDet.MoveFirst()
                rs = getRS("INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rsDet.Fields("BClabelItemID").Value & "," & RecSel & "," & rsDet.Fields("BClabelItem_Line").Value & ",'" & TheNames & "'," & rsDet.Fields("BClabelItem_Align").Value & "," & rsDet.Fields("BClabelItem_Size").Value & "," & rsDet.Fields("BClabelItem_Bold").Value & ",'" & TheSpacess & "'," & rsDet.Fields("BClabelItem_Disabled").Value & "," & MyLIDWHole & ")")
                rs = getRS("DELETE * FROM BClabelItem WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "' and BClabelItemID=" & rsDet.Fields("BClabelItemID").Value & "")
            End If

        End If

        TheSelectedPrinterNew = 2

        labelsfile()

        TheSelectedPrinterNew = 0
    End Sub

    Private Sub cmdUndo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdundo.Click
        On Error Resume Next
        Dim rs As ADODB.Recordset
        Dim rst As ADODB.Recordset
        Dim RsCh As ADODB.Recordset
        Dim rsIn As ADODB.Recordset
        rs = New ADODB.Recordset
        rst = New ADODB.Recordset
        rsIn = New ADODB.Recordset

        RsCh = getRS("SELECT * FROM BClabelItemUndo")

        If RsCh.RecordCount > 0 Then
            rs = getRS("SELECT * FROM BClabelItemUndo")
            rs.MoveLast()
            rsIn = getRS("SELECT * FROM BClabelItem WHERE BClabelItemID =" & rs.Fields("BClabelItemID").Value & " AND BClabelItem_Field='" & rs.Fields("BClabelItem_Field").Value & "'")

            If rsIn.RecordCount > 0 Then
                rst = getRS("DELETE * FROM BClabelItem WHERE BClabelItemID=" & rs.Fields("BClabelItemID").Value & "")

                rst = getRS("DELETE * FROM BClabelItemUndo WHERE BClabelItemID=" & rs.Fields("BClabelItemID").Value & "")
            ElseIf rsIn.RecordCount < 1 Then
                rst = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rs.Fields("BClabelItem_BCLabelID").Value & "," & rs.Fields("BClabelItem_Line").Value & ",'" & rs.Fields("BClabelItem_Field").Value & "'," & rs.Fields("BClabelItem_Align").Value & "," & rs.Fields("BClabelItem_Size").Value & "," & rs.Fields("BClabelItem_Bold").Value & ",'" & rs.Fields("BClabelItem_Sample").Value & "'," & rs.Fields("BClabelItem_Disabled").Value & "," & rs.Fields("BClabelItem_LabelID").Value & ")")
                rst = getRS("DELETE * FROM BClabelItemUndo WHERE BClabelItemID=" & rs.Fields("BClabelItemID").Value & " and BClabelItem_Field='" & rs.Fields("BClabelItem_Field").Value & "'")
            End If

            TheSelectedPrinterNew = 2
            labelsfile()
            'Unload frmPrinter
            'frmPrinter.selectPrinter
            'frmBarcodedesign.TheLoading
            'TheSelectedPrinterNew = 0

            'cmdExit_Click
        Else

        End If

    End Sub

    Private Sub frmBarcodeLoad_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

        If KeyAscii = 27 Then
            cmdExit_Click(cmdExit, New System.EventArgs())
        ElseIf KeyAscii = 13 Then
            cmdSave_Click(cmdSave, New System.EventArgs())
        End If

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub frmBarcodeLoad_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Option1.AddRange(New RadioButton() {_Option1_0, _Option1_1, _Option1_2, _Option1_3, _
                                           _Option1_4, _Option1_5, _Option1_6, _Option1_7, _
                                           _Option1_8, _Option1_9, _Option1_10, _Option1_11})
        Option2.AddRange(New RadioButton() {_Option2_0, _Option2_1, _Option2_2})
        Dim rb As New RadioButton
        For Each rb In Option1
            AddHandler rb.CheckedChanged, AddressOf Option1_CheckedChanged
        Next
        For Each rb In Option2
            AddHandler rb.CheckedChanged, AddressOf Option2_CheckedChanged
        Next
        Dim fso As New Scripting.FileSystemObject
        'openConnection
        loadLanguage()

        strheight = 0
        strwidht = 0

        Me.lbldesign.Text = SelectLabelName
        If TheType = 2 Then
            Me.Text = "Barcode Design"
        ElseIf TheType = 1 Then
            Me.Text = "Shelf Talker Design"
        End If
        Call labelsfile()
        strheight = 0
        strwidht = 0

        Option1(0).Checked = True

    End Sub
    Private Sub labelsfile()
        Dim chk6 As New System.Windows.Forms.CheckBox
        Dim chk5 As New System.Windows.Forms.CheckBox
        Dim chk4 As New System.Windows.Forms.CheckBox
        Dim chk3 As New System.Windows.Forms.CheckBox
        Dim chk2 As New System.Windows.Forms.CheckBox
        Dim chk1 As New System.Windows.Forms.CheckBox
        Dim lValue As Integer
        Dim fso As New Scripting.FileSystemObject
        Dim strname As String
        Dim rsNew As ADODB.Recordset

        rsNew = New ADODB.Recordset

        On Error GoTo errLoad
        'openConnection
        gPersonID = 1

        'If loadBarcodePrinter() Then
        Debug.Print(gLBLwidth)
        lValue = gLBLwidth


        rsNew = getRS("SELECT * FROM Label WHERE LabelID=" & MyLIDWHole & " ORDER BY Label_Type,LabelID")
        SelectLabelName = rsNew.Fields("Label_Name").Value
        Me.lbldesign.Text = SelectLabelName

        twipsToMM = 57
        Dim StHi As Integer
        Dim StWi As Integer

        Do Until rsNew.EOF

            If TheSelectedPrinterNew <> 2 Then
                strwidht = rsNew.Fields("Label_Width").Value
                strheight = rsNew.Fields("Label_Height").Value
            Else
                strwidht = Me.HSWidth.Value
                strheight = Me.HSHeight.Value
            End If

            _chkFields_0.CheckState = chk1.Checked
            _chkFields_1.CheckState = chk2.Checked
            _chkFields_2.CheckState = chk3.Checked
            _chkFields_3.CheckState = chk4.Checked
            _chkFields_4.CheckState = chk5.Checked
            _chkFields_5.CheckState = chk6.Checked

            LaIDHold = rsNew.Fields("LabelID").Value

            HSHeight.Value = strheight
            If TheSelectedPrinterNew = 2 Then
                HSHeight_Change(0)
            End If
            HSWidth.Value = strwidht
            If TheSelectedPrinterNew = 2 Then
                HSHeight_Change(0)
            End If
            rsNew.MoveNext()

        Loop

        TheSelectedPrinterNew = 0
        IntDesign = 0
        Debug.Print(gLBLwidth)

        Exit Sub
errLoad:
        Resume Next
        updatte()
    End Sub
    Private Sub updatee()
        Dim rs As ADODB.Recordset

        rs = getRS("Select BClabelItem.* from BClabelItem")




    End Sub


    Private Sub frmBarcodeLoad_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Dim rs As Recordset
        'If gPrinterLabel <> "" Then
        'Set rs = getRS("SELECT Printer.PrinterID From Printer WHERE (((Printer.PrinterID)='" & gPrinterLabel & "'));")
        'If rs.RecordCount Then
        ' cnnDB.Execute "UPDATE Printer SET Printer_Offset = " & gOffsetLabel & ", Printer.Printer_BCwidth = " & HSWidth.value & ", Printer.Printer_BCheight = " & HSHeight.value & " WHERE (((Printer.PrinterID)='" & Replace(gPrinterLabel, "'", "''") & "'));"
        'Else
        'cnnDB.Execute "INSERT INTO Printer ( Printer_Offset, Printer_BCwidth, Printer_BCheight, PrinterID ) SELECT " & gOffsetLabel & ", " & HSWidth.value & ", " & HSHeight.value & ", '" & Replace(gPrinterLabel, "'", "''") & "';"
        'End If
        'End If
    End Sub

    Private Sub HSHeight_Change(ByVal newScrollValue As Integer)
        HSWidth_Change(0)
    End Sub

    Private Sub HSLeft_Change(ByVal newScrollValue As Integer)
        HSWidth_Change(0)
    End Sub

    Private Sub HSselect_Change(ByVal newScrollValue As Integer)
        picInner.Left = twipsToPixels(0 - newScrollValue, True)
    End Sub

    Private Sub HSTop_Change(ByVal newScrollValue As Integer)
        HSWidth_Change(0)
    End Sub

    Private Sub HSWidth_Change(ByVal newScrollValue As Integer)
        Dim currentPic As System.Windows.Forms.PictureBox
        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset
        On Error Resume Next
        Dim Topval As Integer
        lblWidth.Text = CStr(newScrollValue)
        gLBLwidth = newScrollValue * twipsToMM
        _picSelect_0.Width = twipsToPixels(gLBLwidth, True)
        lblHeight.Text = CStr(HSHeight.Value)
        gLBLheight = HSHeight.Value * twipsToMM
        _picSelect_0.Height = twipsToPixels(gLBLheight, False)

        'New code
        rs = getRS("SELECT BClabel.*, Label.* FROM Label INNER JOIN BClabel ON Label.LabelID = BClabel.BClabel_LabelID WHERE BClabelID=" & RecSel & "")
        If IntDesign = 1 Then
            HSTop.Value = rs.Fields("Label_Top").Value
            HSLeft.Value = rs.Fields("Label_Left").Value

        Else
        End If 'New code end here

        If HSTop.Value = 0 Then
            _picSelect_0.Top = 0
            lblTop.Text = CStr(HSTop.Value)
            lblLineNo.Top = twipsToPixels(1320, False)
        Else
            _picSelect_0.Top = twipsToPixels(HSTop.Value * twipsToMM, False)
            lblTop.Text = CStr(HSTop.Value)
            lblLineNo.Top = twipsToPixels(1320 + pixelToTwips(_picSelect_0.Top, False), False)
        End If


        If HSLeft.Value = 0 Then
            _picSelect_0.Left = 0
            lblLeft.Text = CStr(HSLeft.Value)
        Else
            _picSelect_0.Left = twipsToPixels(HSLeft.Value * twipsToMM, True)
            lblLeft.Text = CStr(HSLeft.Value)
        End If


        If TheSelectedPrinterNew = 2 Then
            CommandNew()
        Else
            CommandNew()
        End If

    End Sub

    Private Sub Option1_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If eventSender.Checked Then
            Dim Index As Integer
            Dim radio As New RadioButton
            radio = DirectCast(eventSender, RadioButton)
            Index = GetIndexer(radio, Option1)
            Dim rs As ADODB.Recordset
            rs = New ADODB.Recordset

            If Option1(1).Checked Then
                TheNames = "StockItem_Name"
                rs = getRS("SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
            ElseIf Option1(2).Checked Then
                TheNames = "Catalogue_Barcode"
                rs = getRS("SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
            ElseIf Option1(3).Checked Then
                TheNames = "Company_Telephone"
                rs = getRS("SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
            ElseIf Option1(4).Checked Then
                TheNames = "Price"
                rs = getRS("SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
            ElseIf Option1(0).Checked Then
                TheNames = "Company_Name"
                rs = getRS("SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
            ElseIf Option1(5).Checked Then
                TheNames = "PricingGroup_Name"
                rs = getRS("SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
            ElseIf Option1(6).Checked Then
                TheNames = "line"
                rs = getRS("SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
            ElseIf Option1(7).Checked Then
                TheNames = "code"
                rs = getRS("SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
            ElseIf Option1(8).Checked Then
                TheNames = "blank"
                rs = getRS("SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")

            ElseIf Option1(9).Checked Then
                TheNames = "Price6"
                rs = getRS("SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
            ElseIf Option1(10).Checked Then
                TheNames = "Price12"
                rs = getRS("SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
            ElseIf Option1(11).Checked Then
                TheNames = "Price24"
                rs = getRS("SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
            End If

            Label7.Text = "Formatting " & TheNames

        End If
    End Sub

    Private Sub Option2_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If eventSender.Checked Then
            'Dim Index As Short = Option2.GetIndex(eventSender)

            If Me.Option2(0).Checked Then
                MyFAlign = 1
            ElseIf Me.Option2(1).Checked Then
                MyFAlign = 0
            ElseIf Me.Option2(2).Checked Then
                MyFAlign = 2
            End If

        End If
    End Sub

    Private Sub printStock(ByRef labelID As Integer)
        Dim mm As Integer
        Dim lline As Integer
        Dim frmBarcodedesign As Object
        Dim sql As String
        Dim Printer As New Printing.PrintDocument
        Dim lObject As New Printing.PrintDocument
        Dim y As Integer
        Dim rs As ADODB.Recordset
        Dim rsData As ADODB.Recordset
        lObject = Printer
        Dim currentPic As Integer

        Dim lString1, lString2 As String

        'Set rsData = getRS("SELECT * FROM BClabelItem INNER JOIN BClabel ON BClabelItem.BClabelItem_BCLabelID = BClabel.BClabelID Where (((BClabel.BClabelID) = " & labelID & ")) ORDER BY BClabel.BClabelID, BClabelItem.BClabelItem_Line;")
        rsData = getRS("SELECT * FROM BClabelItem INNER JOIN BClabel ON BClabelItem.BClabelItem_BCLabelID = BClabel.BClabelID Where (((BClabel.BClabelID) = " & labelID & "))  And ((BClabelItem.BClabelItem_Disabled) <> True) ORDER BY BClabel.BClabelID, BClabelItem.BClabelItem_Line;")

        sql = "SELECT StockItem.StockItemID, Catalogue.Catalogue_Quantity, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Supplier.SupplierID, Supplier.Supplier_Name, PricingGroup.PricingGroupID, PricingGroup.PricingGroup_Name, Format([CatalogueChannelLnk_Price],'Currency') AS Price, barcodePersonLnk.barcodePersonLnk_PersonID, barcodePersonLnk.barcodePersonLnk_PrintQTY, Company.*"
        sql = sql & "FROM Company, barcodePersonLnk INNER JOIN ((((StockItem INNER JOIN Supplier ON StockItem.StockItem_SupplierID = Supplier.SupplierID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)) ON (barcodePersonLnk.barcodePersonLnk_StockItemID = Catalogue.Catalogue_StockItemID) AND (barcodePersonLnk.barcodePersonLnk_Shrink = Catalogue.Catalogue_Quantity)"
        sql = sql & "WHERE (((barcodePersonLnk.barcodePersonLnk_PersonID)=1) AND ((barcodePersonLnk.barcodePersonLnk_PrintQTY)<>0) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));"

        sql = "SELECT StockItem.StockItemID, Catalogue.Catalogue_Quantity, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Supplier.SupplierID, Supplier.Supplier_Name, PricingGroup.PricingGroupID, PricingGroup.PricingGroup_Name, Format([CatalogueChannelLnk_Price],'Currency') AS Price, barcodePersonLnk.barcodePersonLnk_PersonID, barcodePersonLnk.barcodePersonLnk_PrintQTY, Company.*, barcodePersonLnk.barcodePersonLnk_PrintQTY "
        sql = sql & "FROM Company, barcodePersonLnk INNER JOIN ((((StockItem INNER JOIN Supplier ON StockItem.StockItem_SupplierID = Supplier.SupplierID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity)) ON (barcodePersonLnk.barcodePersonLnk_Shrink = Catalogue.Catalogue_Quantity) AND (barcodePersonLnk.barcodePersonLnk_StockItemID = Catalogue.Catalogue_StockItemID) "
        sql = sql & "WHERE (((barcodePersonLnk.barcodePersonLnk_PersonID)=1) AND ((barcodePersonLnk.barcodePersonLnk_PrintQTY)<>0) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));"

        gLBLleft = (lObject.PrinterSettings.DefaultPageSettings.PaperSize.Width - (gLBLwidth)) / 2 + (gOffsetLabel * twipsToMM)
        '    lObject.Cls
        'gLBLleft = (Printer.Width - gLBLwidth) + ((gOffsetLabel) * frmBarcodedesign.twipsToMM)
        rs = getRS(sql)
        Do Until rs.EOF
            rsData.MoveFirst()
            y = CShort((gLBLheight - rsData.Fields("BClabel_Height").Value * twipsToMM) / 2)
            Printer.PrinterSettings.Copies = rs.Fields("barcodePersonLnk_PrintQTY").Value

            If y < 0 Then y = 0
            'lObject.FontName = "Tahoma"
            rsData.MoveFirst()
            If rsData.RecordCount Then
                lline = rsData.Fields("BClabelItem_Line").Value
                Do Until rsData.EOF
                    If lline <> rsData.Fields("BClabelItem_Line").Value Then
                        'y = lObject.Location.Y + 10
                        lline = rsData.Fields("BClabelItem_Line").Value
                    End If

                    Select Case LCase(rsData.Fields("BClabelItem_Field").Value)
                        Case "line"
                            'lObject.Line((15 + gLBLleft, y) - (gLBLleft + gLBLwidth, y), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black))
                        Case "code"
                            Select Case rsData.Fields("BClabelItem_Align").Value
                                Case 1
                                    printBarcode(lObject, rs.Fields("Catalogue_Barcode").Value, gLBLleft + 90, y)
                                Case 2
                                    printBarcode(lObject, rs.Fields("Catalogue_Barcode").Value, gLBLleft + 90, y)
                                Case Else
                                    printBarcode(lObject, rs.Fields("Catalogue_Barcode").Value, gLBLleft, y, gLBLwidth)
                            End Select
                        Case Else
                            'lObject.FontSize = rsData.Fields("BClabelItem_Size").Value
                            'lObject.FontBold = rsData.Fields("BClabelItem_Bold").Value
                            'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                            mm = rsData.Fields("BClabelItem_Field").Value
                            lString1 = rs.Fields(mm).Value
                            Select Case rsData.Fields("BClabelItem_Align").Value
                                Case 1
                                    'lObject.PSet(New Point[](gLBLleft + 90, y))
                                    'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                    'lObject.Print(lString1)

                                Case 2
                                    'lObject.PSet(New Point[](gLBLleft + gLBLwidth - lObject.TextWidth(lString1) - 90, y))
                                    'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                    'lObject.Print(lString1)

                                Case 3
                                    'splitString(lObject, lString1, lString2)
                                    If lString1 <> "" Then
                                        'lObject.PSet(New Point[](CShort(gLBLleft + (gLBLwidth - lObject.TextWidth(lString1)) / 2), y))
                                        'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                        'lObject.Print(lString1)
                                        'y = lObject.Location.Y + 10
                                        'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                                    End If
                                    lString1 = lString2
                                    If lString1 <> "" Then
                                        'lObject.PSet(New Point[](CShort(gLBLleft + (gLBLwidth - lObject.TextWidth(lString1)) / 2), y))
                                        'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                        'lObject.Print(lString1)
                                    End If
                                Case Else
                                    'lObject.PSet(New Point[](CShort(gLBLleft + (gLBLwidth - lObject.TextWidth(lString1)) / 2), y))
                                    'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                    'lObject.Print(lString1)
                            End Select
                    End Select
                    rsData.MoveNext()
                Loop
            End If
            Printer.Print()
            rs.MoveNext()
        Loop
    End Sub

    Public Function PrintBcodes() As Object
        Dim barcodePicture As System.Windows.Forms.PictureBox
        Dim lValue As String
        Dim lTop, lLeft, lWidth As Integer
        Dim x As Short
        Dim y As Short
        Dim lXML As String
        Dim lastArray, oddArray, evenArray, parityArray As String()
        Dim lString, codeType, code, lCode, HeadingString1 As String
        Dim HeadingString2 As String
        Dim i, j As Integer
        Dim cnt As Short
        Dim barArray As String()
        lXML = ""
        If doCheckSum(lValue) Then
            oddArray = New String() {"0001101", "0011001", "0010011", "0111101", "0100011", "0110001", "0101111", "0111011", "0110111", "0001011"}
            evenArray = New String() {"0100111", "0110011", "0011011", "0100001", "0011101", "0111001", "0000101", "0010001", "0001001", "0010111"}
            lastArray = New String() {"1110010", "1100110", "1101100", "1000010", "1011100", "1001110", "1010000", "1000100", "1001000", "1110100"}
            parityArray = New String() {"111111", "110100", "110010", "110001", "101100", "100110", "100011", "101010", "101001", "100101"}
            code = VB.Left(lValue, 1)
            code = VB.Right(code, 1)
            codeType = parityArray(CShort(code))

            lXML = lXML & doImage("101", 1)
            For i = 2 To 7
                code = VB.Left(lValue, i)
                code = VB.Right(code, 1)
                lCode = VB.Left(codeType, i - 1)
                lCode = VB.Right(lCode, 1)
                If lCode = "0" Then
                    lXML = lXML & doImage(evenArray(code), 0)
                Else
                    lXML = lXML & doImage(oddArray(code), 0)
                End If
            Next
            lXML = lXML & doImage("01010", 1)
            For i = 8 To 13
                code = VB.Left(lValue, i)
                code = VB.Right(code, 1)
                lXML = lXML & doImage(lastArray(code), 0)
            Next
            lXML = lXML & doImage("101", 1)
        Else
            lString = lValue
            For i = 1 To Len(lString)
                If CDbl(VB.Left(lString, 1)) = 0 Then
                    lString = VB.Right(lString, Len(lString) - 1)
                Else
                    Exit For
                End If
            Next
            lValue = lString

            oddArray = New String() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "-", ".", " ", "$", "/", "+", "%", "~", ","}
            evenArray = New String() {"111331311", "311311113", "113311113", "313311111", "111331113", "311331111", "113331111", "111311313", "311311311", "113311311", "311113113", "113113113", "313113111", "111133113", "311133111", "113133111", "111113313", "311113311", "113113311", "111133311", "311111133", "113111133", "313111131", "111131133", "311131131", "113131131", "111111333", "311111331", "113111331", "111131331", "331111113", "133111113", "333111111", "131131113", "331131111", "133131111", "131111313", "331111311", "133111311", "131131311", "131313111", "131311131", "131113131", "111313131", "1311313111131131311"}

            lString = "131131311"
            lString = lString + "1"
            For i = 1 To Len(lValue)
                code = VB.Left(lValue, i)
                code = VB.Right(code, 1)
                code = UCase(code)
                For j = 0 To UBound(oddArray)
                    If code = oddArray(j) Then
                        lString = lString + evenArray(j)
                        lString = lString + "1"
                        j = 9999
                    End If
                Next
            Next
            lString = lString + "131131311"

            For i = 1 To Len(lString)
                code = VB.Left(lString, i)
                code = VB.Right(code, 1)
                For j = 1 To CShort(code)
                    lCode = VB.Left(code, i)
                    lCode = VB.Right(lCode, 1)
                    If i Mod 2 Then
                        lXML = lXML & System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black) & "~"
                    Else
                        lXML = lXML & System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White) & "~"
                    End If
                    lXML = lXML & "20|"
                Next
            Next
        End If

        barArray = Split(lXML, "|")
        y = lTop
        If lWidth = 0 Then
            x = lLeft
        Else
            x = CShort(lLeft + (lWidth - UBound(barArray) * twipsPerPixel(True) / 2))
        End If
        For cnt = LBound(barArray) To UBound(barArray)
            If barArray(cnt) <> "" Then
                If CInt(Split(barArray(cnt), "~")(0)) = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black) Then
                    On Error Resume Next
                    'barcodePicture.Line((x + cnt * twipsPerPixel(True), y) - _
                    '    (x + (cnt + 1) * twipsPerPixel(true), _
                    '        y + CInt(Split(barArray(cnt), "~")(1)) * _
                    '        twipsPerPixel(true)), CInt(Split(barArray(cnt), "~")(0)), BF)
                End If
            End If

        Next
    End Function

    Public Function MyFormLoads() As Object
        Dim lblPrinter As New System.Windows.Forms.Label
        Dim lValue As Integer
        Dim fso As New Scripting.FileSystemObject
        'openConnection

        ' strheight = 0
        ' strwidht = 0
        'ppp
        If fso.FileExists("C:\lblPath\path.dat") Then
            loadBarcodePrinter()
            ' strwidht = 0
            ' strheight = 0
            Call labelsfile()
            'picSelect(1).ForeColor = vbGreen
            strwidht = 0
            strheight = 0
            Call PrintBcodes()

            Exit Function
        Else
            gPersonID = 1
            If loadBarcodePrinter() Then
                Debug.Print(gLBLwidth)
                lValue = gLBLwidth
                lblPrinter.Text = gPrinterLabel
                HSHeight.Value = gLBLheight / twipsToMM
                HSWidth.Value = lValue / twipsToMM
                Debug.Print(gLBLwidth)
            Else
                'Unload Me
                Exit Function
            End If


        End If
        updatte()
    End Function

    Public Function CommandNew() As Object
        Dim NewLargeChange As Short
        Dim lline As Object
        Dim lObject As System.Windows.Forms.PictureBox
        Dim y As Integer
        Dim x As Integer
        Dim rs As ADODB.Recordset
        Dim rsData As ADODB.Recordset
        lObject = _picSelect_0
        Dim currentPic As Integer
        Dim RecSelNew As Short
        Dim lString1, lString2 As String
        Dim rsTop As ADODB.Recordset

        _picSelect_0.Width = twipsToPixels(gLBLwidth, True)

        gLBLleft = (lObject.Width - (gLBLwidth)) / 2 + (twipsToMM)
        gLBLleft = 0
        'UPGRADE_ISSUE: PictureBox method picSelect.Cls was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        'picSelect(0).Cls()
        rs = getRS("SELECT * FROM BClabel WHERE BClabel_Disabled = false and BClabelID=" & RecSel & " ORDER BY BClabelID")

        Do Until rs.EOF
            If currentPic Then
                On Error Resume Next
                _picSelect_0.Load(currentPic)
            End If
            'picSelect(currentPic).Left = (picSelect(currentPic).Width + 90) * currentPic
            _picSelect_0.Visible = True
            'UPGRADE_ISSUE: PictureBox property picSelect.AutoRedraw was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
            'picSelect(currentPic).AutoRedraw = True
            lObject = _picSelect_0
            _picSelect_0.Tag = rs.Fields("BClabelID").Value
            currentPic = currentPic + 1

            y = CShort((gLBLheight - rs.Fields("BClabel_Height").Value * twipsToMM) / 2)
            If y < 0 Then y = 0
            'lObject.FontName = "Tahoma"
            x = y
            rsData = getRS("SELECT * FROM BClabelItem INNER JOIN BClabel ON BClabelItem.BClabelItem_BCLabelID = BClabel.BClabelID Where (((BClabel.BClabelID) = " & rs.Fields("BClabelID").Value & ")) ORDER BY BClabel.BClabelID, BClabelItem.BClabelItem_Line;")
            If rsData.RecordCount Then
                lline = rsData.Fields("BClabelItem_Line").Value
                Do Until rsData.EOF
                    If lline <> rsData.Fields("BClabelItem_Line").Value Then
                        y = lObject.Location.Y + 10
                        x = y
                        lline = rsData.Fields("BClabelItem_Line").Value
                    End If
                    'lline = rsData("BClabelItem_Line")
                    Select Case LCase(rsData.Fields("BClabelItem_Field").Value)

                        Case "line"

                            If rsData.Fields("BClabelItem_Line").Value = 1 Then
                                y = 150
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 2 Then
                                y = 350
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 3 Then
                                y = 600
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 4 Then
                                y = 750
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 5 Then
                                y = 950
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 6 Then
                                y = 1150
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 7 Then
                                y = 1350
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 8 Then
                                y = 1550
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 9 Then
                                y = 1700
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 10 Then
                                y = 1850
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 11 Then
                                y = 2100
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 12 Then
                                y = 2300
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 13 Then
                                y = 2500
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 14 Then
                                y = 2700
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 15 Then
                                y = 2900
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 16 Then
                                y = 3100
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 17 Then
                                y = 3300
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 18 Then
                                y = 3500
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 19 Then
                                y = 3700
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 20 Then
                                y = 3900
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 21 Then
                                y = 4100
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 22 Then
                                y = 4200
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 23 Then
                                y = 4350
                            End If


                            'lObject.Line((15 + gLBLleft, y) - (gLBLleft + gLBLwidth, y), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black))
                            y = x
                        Case "code"
                            If rsData.Fields("BClabelItem_Line").Value = 1 Then
                                y = 0
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 2 Then
                                y = 150
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 3 Then
                                y = 350
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 4 Then
                                y = 600
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 5 Then
                                y = 750
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 6 Then
                                y = 950
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 7 Then
                                y = 1150
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 8 Then
                                y = 1350
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 9 Then
                                y = 1550
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 10 Then
                                y = 1700
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 11 Then
                                y = 1850
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 12 Then
                                y = 2100
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 13 Then
                                y = 2300
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 14 Then
                                y = 2500
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 15 Then
                                y = 2700
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 16 Then
                                y = 2900
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 17 Then
                                y = 3100
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 18 Then
                                y = 3300
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 19 Then
                                y = 3500
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 20 Then
                                y = 3700
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 21 Then
                                y = 3900
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 22 Then
                                y = 4100
                            ElseIf rsData.Fields("BClabelItem_Line").Value = 23 Then
                                y = 4200
                            End If
                            Select Case rsData.Fields("BClabelItem_Align").Value

                                Case 1
                                    'Jonas added
                                    'lObject.FontSize = rsData.Fields("BClabelItem_Size").Value
                                    'lObject.FontBold = rsData.Fields("BClabelItem_Bold").Value
                                    'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                                    'Jonas
                                    printBarcode(lObject, "6001060071416", gLBLleft, y)
                                Case 2
                                    'Jonas added
                                    'lObject.FontSize = rsData.Fields("BClabelItem_Size").Value
                                    'lObject.FontBold = rsData.Fields("BClabelItem_Bold").Value
                                    'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                                    'Jonas

                                    printBarcode(lObject, "6001060071416", gLBLleft, y, gLBLwidth + gLBLwidth - 1440)
                                    'lObject.PSet (gLBLleft, y)
                                Case Else
                                    'Jonas added
                                    'lObject.FontSize = rsData.Fields("BClabelItem_Size").Value
                                    'lObject.FontBold = rsData.Fields("BClabelItem_Bold").Value
                                    'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                                    'Jonas
                                    printBarcode(lObject, "6001060071416", gLBLleft, y, gLBLwidth)
                            End Select
                            y = x
                        Case Else

                            On Error Resume Next

                            'lObject.FontSize = rsData.Fields("BClabelItem_Size").Value
                            'lObject.FontBold = rsData.Fields("BClabelItem_Bold").Value
                            'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                            y = lObject.Location.Y + 10
                            x = y
                            lline = rsData.Fields("BClabelItem_Line").Value
                            If IsDBNull(rsData.Fields("BClabelItem_Sample").Value) Then
                                lString1 = ""
                            Else
                                lString1 = rsData.Fields("BClabelItem_Sample").Value
                            End If
                            Select Case rsData.Fields("BClabelItem_Align").Value
                                Case 1

                                    If rsData.Fields("BClabelItem_Line").Value = 1 Then
                                        y = 0
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 2 Then
                                        y = 150
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 3 Then
                                        y = 350
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 4 Then
                                        y = 600
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 5 Then
                                        y = 750
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 6 Then
                                        y = 950
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 7 Then
                                        y = 1150
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 8 Then
                                        y = 1350
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 9 Then
                                        y = 1550
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 10 Then
                                        y = 1700
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 11 Then
                                        y = 1850
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 12 Then
                                        y = 2100
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 13 Then
                                        y = 2300
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 14 Then
                                        y = 2500
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 15 Then
                                        y = 2700
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 16 Then
                                        y = 2900
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 17 Then
                                        y = 3100
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 18 Then
                                        y = 3300
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 19 Then
                                        y = 3500
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 20 Then
                                        y = 3700
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 21 Then
                                        y = 3900
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 22 Then
                                        y = 4100
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 23 Then
                                        y = 4200
                                    End If

                                    'y = 1112
                                    'dfd = rsData("BClabelItem_Field")
                                    'lObject.PSet(New Point[](gLBLleft, y))

                                    'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                    'lObject.Print(lString1)
                                    y = x
                                Case 2
                                    'Row No
                                    If rsData.Fields("BClabelItem_Line").Value = 1 Then
                                        y = 0
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 2 Then
                                        y = 150
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 3 Then
                                        y = 350
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 4 Then
                                        y = 600
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 5 Then
                                        y = 750
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 6 Then
                                        y = 950
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 7 Then
                                        y = 1150
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 8 Then
                                        y = 1350
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 9 Then
                                        y = 1550
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 10 Then
                                        y = 1700
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 11 Then
                                        y = 1850
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 12 Then
                                        y = 2100
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 13 Then
                                        y = 2300
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 14 Then
                                        y = 2500
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 15 Then
                                        y = 2700
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 16 Then
                                        y = 2900
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 17 Then
                                        y = 3100
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 18 Then
                                        y = 3300
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 19 Then
                                        y = 3500
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 20 Then
                                        y = 3700
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 21 Then
                                        y = 3900
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 22 Then
                                        y = 4100
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 23 Then
                                        y = 4200
                                    End If

                                    'Row No
                                    'lObject.PSet(New Point[](gLBLleft + gLBLwidth - lObject.TextWidth(lString1), y))
                                    'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                    'lObject.Print(lString1)
                                    y = x
                                Case 3
                                    'Row No
                                    If rsData.Fields("BClabelItem_Line").Value = 1 Then
                                        y = 0
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 2 Then
                                        y = 150
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 3 Then
                                        y = 350
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 4 Then
                                        y = 600
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 5 Then
                                        y = 750
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 6 Then
                                        y = 950
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 7 Then
                                        y = 1150
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 8 Then
                                        y = 1350
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 9 Then
                                        y = 1550
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 10 Then
                                        y = 1700
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 11 Then
                                        y = 1850
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 12 Then
                                        y = 2100
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 13 Then
                                        y = 2300
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 14 Then
                                        y = 2500
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 15 Then
                                        y = 2700
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 16 Then
                                        y = 2900
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 17 Then
                                        y = 3100
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 18 Then
                                        y = 3300
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 19 Then
                                        y = 3500
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 20 Then
                                        y = 3700
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 21 Then
                                        y = 3900
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 22 Then
                                        y = 4100
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 23 Then
                                        y = 4200
                                    End If

                                    'Row No
                                    'splitString(lObject, lString1, lString2)
                                    If lString1 <> "" Then
                                        'lObject.PSet(New Point[](CShort(gLBLleft + (gLBLwidth - lObject.TextWidth(lString1)) / 2), y))
                                        y = x
                                        'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                        'lObject.Print(lString1)
                                        y = lObject.Location.Y + 10
                                        x = y
                                        'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                                    End If
                                    lString1 = lString2
                                    If lString1 <> "" Then
                                        'lObject.PSet(New Point[](CShort(gLBLleft + (gLBLwidth - lObject.TextWidth(lString1)) / 2), y))
                                        'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                        'lObject.Print(lString1)
                                    End If
                                Case Else
                                    'Row No
                                    If rsData.Fields("BClabelItem_Line").Value = 1 Then
                                        y = 0
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 2 Then
                                        y = 150
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 3 Then
                                        y = 350
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 4 Then
                                        y = 600
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 5 Then
                                        y = 750
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 6 Then
                                        y = 950
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 7 Then
                                        y = 1150
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 8 Then
                                        y = 1350
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 9 Then
                                        y = 1550
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 10 Then
                                        y = 1700
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 11 Then
                                        y = 1850
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 12 Then
                                        y = 2100
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 13 Then
                                        y = 2300
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 14 Then
                                        y = 2500
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 15 Then
                                        y = 2700
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 16 Then
                                        y = 2900
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 17 Then
                                        y = 3100
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 18 Then
                                        y = 3300
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 19 Then
                                        y = 3500
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 20 Then
                                        y = 3700
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 21 Then
                                        y = 3900
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 22 Then
                                        y = 4100
                                    ElseIf rsData.Fields("BClabelItem_Line").Value = 23 Then
                                        y = 4200
                                    End If

                                    'Row No
                                    'lObject.PSet(New Point[](CShort(gLBLleft + (gLBLwidth - lObject.TextWidth(lString1)) / 2), y))
                                    y = x
                                    'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                    'lObject.Print(lString1)
                            End Select
                    End Select
                    rsData.MoveNext()
                Loop
            End If
            rs.MoveNext()
        Loop

        'End If
        picInner.Width = twipsToPixels(lObject.Left + lObject.Width, True)
        picInner.SetBounds(0, 0, twipsToPixels(lObject.Left + lObject.Width, True), _
                           twipsToPixels(lObject.Top + lObject.Height, False))
        If pixelToTwips(picInner.Width, True) > pixelToTwips(picOuter.Width, True) Then
            HSselect.Enabled = True
            HSselect.Value = 0
            HSselect.Maximum = (pixelToTwips(picInner.Width, True) - _
                                pixelToTwips(picOuter.Width, True) + 100 + _
                                HSselect.LargeChange - 1)
            NewLargeChange = lObject.Width + 100
            HSselect.Maximum = HSselect.Maximum + NewLargeChange - HSselect.LargeChange
            HSselect.LargeChange = NewLargeChange
            HSselect.SmallChange = CShort((lObject.Width + 100) / 2)

        Else
            HSselect.Enabled = False
        End If


    End Function

    Private Sub txtpos_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtpos.Leave

        If Not IsNumeric(Me.txtpos.Text) Then
            MsgBox("Please enter a Valid Number for Row Position.", MsgBoxStyle.Information, "4POS")
            Me.txtpos.Text = "1"
            Me.txtpos.Focus()
            Exit Sub
        Else
        End If

        If CDbl(Me.txtpos.Text) < 1 Or CDbl(Me.txtpos.Text) > 23 Then
            MsgBox("Please enter a Number from 1 to 23 for 'Row Position' as indicated on the left hand side of you designing page.", MsgBoxStyle.Information, "4Pos Back Office")
            Me.txtpos.Focus()
            Me.txtpos.Text = "1"
            Exit Sub
        Else
        End If

    End Sub

    Public Function FunUnl() As Object
        Me.Close()
        Exit Function
    End Function

    Private Sub VScroll1_Change()

    End Sub
    Private Sub HSHeight_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles HSHeight.Scroll
        Select Case eventArgs.Type
            Case System.Windows.Forms.ScrollEventType.EndScroll
                HSHeight_Change(eventArgs.NewValue)
        End Select
    End Sub
    Private Sub HSLeft_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles HSLeft.Scroll
        Select Case eventArgs.Type
            Case System.Windows.Forms.ScrollEventType.EndScroll
                HSLeft_Change(eventArgs.NewValue)
        End Select
    End Sub
    Private Sub HSselect_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles HSselect.Scroll
        Select Case eventArgs.Type
            Case System.Windows.Forms.ScrollEventType.EndScroll
                HSselect_Change(eventArgs.NewValue)
        End Select
    End Sub
    Private Sub HSTop_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles HSTop.Scroll
        Select Case eventArgs.Type
            Case System.Windows.Forms.ScrollEventType.EndScroll
                HSTop_Change(eventArgs.NewValue)
        End Select
    End Sub
    Private Sub HSWidth_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles HSWidth.Scroll
        Select Case eventArgs.Type
            Case System.Windows.Forms.ScrollEventType.EndScroll
                HSWidth_Change(eventArgs.NewValue)
        End Select
    End Sub
End Class