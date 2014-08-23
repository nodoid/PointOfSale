Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmBarcodePerson
	Inherits System.Windows.Forms.Form
	Dim rs As ADODB.Recordset
	
	Private Sub loadLanguage()
		
		'frmBarcodePerson = No Code     [Security Barcode Printing]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmBarcodePerson.Caption = rsLang("LanguageLayoutLnk_Description"): frmBarcodePerson.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1818 'Printer|Checked
		If rsLang.RecordCount Then _Label2_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _Label2_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lblPrinter = No Code/Dynamic/NA?
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1819 'Printer Type|Checked
		If rsLang.RecordCount Then _Label2_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _Label2_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lblPrinterType = No Code/Dynamic/NA?
		
		'Label1 = No Code               [Tick the check boxes for the Persons you require access barcodes for from the list below.]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1085 'Print|Checked
		If rsLang.RecordCount Then cmdPrint.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrint.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cndExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cndExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmBarcodePerson.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub showLabels()
		rs = getRS("SELECT Person.PersonID, [Person_FirstName] & ' ' & [Person_LastName] AS PersonName, Person.Person_QuickAccess, Label.* From Person, Label Where Person.Person_Disabled = False And Label.Label_Type = 3 ANd PersonID <> 1 ORDER BY [Person_FirstName] & ' ' & [Person_LastName];")
        Me.lstPerson.Items.Clear()
        Dim tmpString As String
        Do Until rs.EOF
            tmpString = rs.Fields("PersonName").Value & " " & rs.Fields("PersonID").Value
            lstPerson.Items.Add(tmpString)
            tmpString = ""
            rs.MoveNext()
        Loop
	End Sub
	Private Sub printPerson()
		Dim rs As ADODB.Recordset
		If CDbl(lblPrinterType.Tag) = 1 Then
			printBarcodePerson()
		ElseIf CDbl(lblPrinterType.Tag) = 2 Then 
			printA4Person()
		End If
	End Sub
	
	Private Sub printBarcodePerson()
		Dim fso As New Scripting.FileSystemObject
		Dim lStream As Scripting.TextStream
		Dim lString As String
        Dim lArray As String()
		Dim lText As String
		Dim x, y As Short
		For y = 0 To lstPerson.Items.Count - 1
			If lstPerson.GetItemChecked(y) Then
                rs.Filter = "PersonID = " & GetItemData(lstPerson, y)
                'rs.Filter = "PersonID = " & CLng(lstPerson(y))
				lString = rs.Fields("label_textstream").Value
				lArray = Split(lString, vbCrLf)
				lString = ""
				
				For x = 0 To UBound(lArray)
					lText = lArray(x)
					lString = lString & vbCrLf & doString(lText, rs)
				Next x
				lStream = fso.OpenTextFile("c:\aa.txt", Scripting.IOMode.ForWriting, True)
				lStream.Write(lString)
				lStream.Close()
				lString = "C:\AA.TXT"
				Call SpoolFile(lString, (lblPrinter.Text))
			End If
		Next 
	End Sub
	
	Private Function doString(ByRef lString As String, ByRef rs As ADODB.Recordset) As String
		Dim lString1 As String
		Dim lString2 As String
		Dim lText As String
		If Len(lString) > 15 Then
			lText = Mid(lString, 16)
			If InStr(lText, "NAME 1 CENTER") Then
				lString1 = rs.Fields("PersonName").Value
				splitString(Len(lText), lString1, lString2)
				doString = VB.Left(lString, 15) & doCenter(lText, lString1)
				Exit Function
			End If
			If InStr(lText, "DATE") Then
                lString1 = Format(Now, "yymm")
                doString = VB.Left(lString, 15) & Format(Now, "yymm")
				Exit Function
			End If
			
			If InStr(lText, "BARCODE") Then
				If doCheckSum(rs.Fields("Person_QuickAccess").Value) Then 
				Else 
					doString = VB.Left(lString, 15) & rs.Fields("Person_QuickAccess").Value
				End If
				Exit Function
			End If
			If InStr(lText, "600106007141") Then
				If doCheckSum(rs.Fields("Person_QuickAccess").Value) Then doString = VB.Left(lString, 15) & rs.Fields("Person_QuickAccess").Value
				Exit Function
			End If
			doString = lString
		Else
			doString = lString
		End If
	End Function
	
    Private Function doCheckSum(ByRef lString As String) As Boolean
        Dim lAmount As Short
        Dim code As String
        Dim i As Short
        Dim value As String
        value = lString
        doCheckSum = False
        If InStr(value, "0") Then
            Do Until CDbl(VB.Left(value, 1)) <> 0
                value = Mid(value, 2)
            Loop
        End If
        If Len(value) <> 13 Then Exit Function
        If value = "" Then Exit Function
        If InStr(value, ".") Then
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
                doCheckSum = lAmount = CShort(VB.Right(value, 1))
            Else
                doCheckSum = False
            End If
        End If
    End Function
	
    Public Function doCenter(ByRef origText As String, ByRef newText As String) As String
        Dim newstring As Object
        If Len(origText) > Len(newstring) Then
            doCenter = New String(" ", CShort((Len(origText) - Len(newText)) / 2)) & newText
        Else
            doCenter = VB.Left(newText, Len(origText))
        End If

    End Function
	
	Private Sub splitStringA4(ByRef lObject As Object, ByRef lWidth As Integer, ByRef HeadingString1 As String, ByRef HeadingString2 As String)
        Dim Printer As New Printing.PrintDocument
        Dim y As Short
        Dim x As Short
        Dim lHeading As String
		lHeading = HeadingString1
		HeadingString1 = lHeading & " "
		HeadingString2 = ""
		If (lWidth - lObject.TextWidth(lHeading)) < 0 Then
			For x = Len(lHeading) + 1 To 1 Step -1
				HeadingString1 = VB.Left(lHeading, x)
				If (lWidth - lObject.TextWidth(HeadingString1) + 50) > 0 Then
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
            HeadingString1 = "" '
            'Else
            'Do Until Printer.TextWidth(HeadingString2) <= lWidth
            ' HeadingString2 = Mid(HeadingString2, 1, Len(HeadingString2) - 1)
            'Loop 
		End If
		HeadingString1 = Trim(HeadingString1)
		HeadingString2 = Trim(HeadingString2)
	End Sub
	
	Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
		printPerson()
	End Sub
	
	Private Sub cndExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cndExit.Click
		Me.Close()
	End Sub
	
	Private Sub frmBarcodePerson_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim Printer As New Printing.PrintDocument
		Dim lPrinter As String
		'UPGRADE_WARNING: Couldn't resolve default property of object frmPrinter.selectPrinter(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		lPrinter = frmPrinter.selectPrinter()
		loadLanguage()
		If lPrinter = "" Then
			Me.Close()
			Exit Sub
		Else
			lblPrinter.Text = lPrinter
            If InStr(LCase(Printer.PrinterSettings.PrinterName), "label") Then
                lblPrinterType.Tag = 1
                lblPrinterType.Text = "Barcode Printer"
            Else
                lblPrinterType.Tag = 2
                lblPrinterType.Text = "A4 Printer"
            End If
			showLabels()
		End If
	End Sub
	
	Private Sub splitString(ByRef Max As Short, ByRef HeadingString1 As String, ByRef HeadingString2 As String)
        Dim lHeading As String
		lHeading = UCase(HeadingString1)
		lHeading = Replace(lHeading, "&", "AND")
		lHeading = Replace(lHeading, "'", "")
		HeadingString1 = lHeading & " "
		HeadingString2 = ""
		
		If Len(lHeading) > Max Then
			HeadingString1 = VB.Left(lHeading, Max + 1)
			Do Until VB.Right(HeadingString1, 1) = " " Or Len(HeadingString1) = 1
				HeadingString1 = VB.Left(HeadingString1, Len(HeadingString1) - 1)
				
			Loop 
			If Len(HeadingString1) = 1 Then
				HeadingString1 = VB.Left(lHeading, 25)
				HeadingString2 = Mid(lHeading, 25, 25)
				
			Else
				HeadingString2 = VB.Left(Trim(Mid(lHeading, Len(HeadingString1))), Max)
			End If
		End If
		
	End Sub
	
	Private Sub printA4Person()
        Dim mm As Decimal
        Dim lline As Integer
        Dim i As Integer
        Dim lTop As Integer
        Dim lHeight As Integer
        Dim gOffsetLabel As Integer
        Dim Printer As New Printing.PrintDocument
        Dim lObject As New Printing.PrintDocument
		Dim y As Integer
		Dim rsData As ADODB.Recordset
		Dim currentPic As Integer
		Dim twipsToMM As Integer
		Dim lLeft As Integer
		Dim lWidth As Integer
		Dim lCol, lCols, lRows, lrow As Short
		
        'Printer.ScaleMode = ScaleModeConstants.vbTwips 'twips
        'twipsToMM = Printer.ScaleWidth
        'Printer.ScaleMode = ScaleModeConstants.vbMillimeters 'mm
        'twipsToMM = twipsToMM / Printer.ScaleWidth
        'Printer.ScaleMode = ScaleModeConstants.vbTwips 'twips
		lObject = Printer
		
		
		Dim lString1, lString2 As String
		rs.MoveFirst()
		
		rsData = getRS("SELECT * FROM labelItem INNER JOIN label ON labelItem.labelItem_LabelID = label.labelID Where (((label.labelID) = " & rs.Fields("LabelID").Value & ")) ORDER BY label.labelID, labelItem.labelItem_Line;")
		
        'lLeft = (lObject.Width - (lWidth)) / 2 + (gOffsetLabel * twipsToMM)
		lLeft = 0
		If rsData.Fields("Label_Rotate").Value Then
			lWidth = rsData.Fields("label_Height").Value * twipsToMM
			lHeight = rsData.Fields("label_Width").Value * twipsToMM
		Else
			lWidth = rsData.Fields("label_width").Value * twipsToMM
			lHeight = rsData.Fields("label_Height").Value * twipsToMM
		End If
		lTop = rsData.Fields("label_Top").Value * twipsToMM
        'lCols = CDec(Printer.Width / (lWidth + 60)) - 0.49999
        'lRows = CDec(Printer.Height / (lHeight + 60)) - 0.49999
		For i = 0 To lstPerson.Items.Count - 1
			If lstPerson.GetItemChecked(i) Then
                rs.Filter = "PersonID=" & GetItemData(lstPerson, i)
				rsData.MoveFirst()
				y = 0
				
				If y < 0 Then y = 0
                'lObject.FontName = "Tahoma"
				rsData.MoveFirst()
				If rsData.RecordCount Then
					lline = rsData.Fields("labelItem_Line").Value
					
					lLeft = lCol * (lWidth + 60)
                    'lObject.CurrentY = lrow * (lHeight + 60)
					rsData.MoveFirst()
                    'y = lObject.CurrentY
                    'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(Me.BackColor)
                    'lObject.Line((lLeft, y) - (lLeft, y + 100))
                    'lObject.Line((lLeft, y) - (lLeft + 100, y))
                    'lObject.Line((lLeft + lWidth, y) - (lLeft + lWidth - 100, y))
                    'lObject.Line((lLeft + lWidth, y) - (lLeft + lWidth, y + 100))
                    'lObject.Line((lLeft + lWidth, lHeight + y) - (lLeft + lWidth, lHeight + y - 100))
                    'lObject.Line((lLeft + lWidth, lHeight + y) - (lLeft + lWidth - 100, lHeight + y))
                    'lObject.Line((lLeft, lHeight + y) - (lLeft, lHeight + y - 100))
                    'lObject.Line((lLeft, lHeight + y) - (lLeft + 100, lHeight + y))
                    'lObject.CurrentY = lrow * (lHeight + 60) + lTop
                    'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                    'y = lObject.CurrentY + 10
					Do Until rsData.EOF
						If lline <> rsData.Fields("labelItem_Line").Value Then
                            '		y = lObject.CurrentY + 10
							lline = rsData.Fields("labelItem_Line").Value
						End If
						
						Select Case LCase(Trim(rsData.Fields("labelItem_Field").Value))
							Case "blank"
                                '			lObject.FontSize = rsData.Fields("labelItem_Size").Value
                                '				lObject.FontBold = rsData.Fields("labelItem_Bold").Value
                                ''					lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                                '					lObject.Print(" ")
							Case "line"
                                '					lObject.Line((15 + lLeft, y) - (lLeft + lWidth, y), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black))
							Case "code"
								Select Case rsData.Fields("labelItem_Align").Value
									Case 1
                                        'printBarcode(lObject, rs.Fields("Person_QuickAccess").Value, lLeft + 90, y)
									Case 2
                                        'printBarcode(lObject, rs.Fields("Person_QuickAccess").Value, lLeft + 90, y)
									Case Else
                                        'printBarcode(lObject, rs.Fields("Person_QuickAccess").Value, lLeft, y, lWidth)
								End Select
							Case Else
                                'lObject.FontSize = rsData.Fields("labelItem_Size").Value
                                'lObject.FontBold = rsData.Fields("labelItem_Bold").Value
                                'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
								mm = rsData.Fields("labelItem_Field").Value
								lString1 = rs.Fields(mm).Value
								Select Case rsData.Fields("labelItem_Align").Value
									Case 1
                                        'lObject.PSet(New Point[](lLeft + 90, y))
                                        'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                        'lObject.Print(lString1)
										
									Case 2
                                        'lObject.PSet(New Point[](lLeft + lWidth - lObject.TextWidth(lString1) - 90, y))
                                        'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                        'lObject.Print(lString1)
										
									Case 3
										splitStringA4(lObject, lWidth, lString1, lString2)
                                        'lObject.PSet(New Point[](CShort(lLeft + (lWidth - lObject.TextWidth(lString1)) / 2), y))
                                        'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                        'lObject.Print(lString1)
                                        'y = lObject.CurrentY + 10
                                        'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
										lString1 = lString2
                                        'lObject.PSet(New Point[](CShort(lLeft + (lWidth - lObject.TextWidth(lString1)) / 2), y))
                                        'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                        'lObject.Print(lString1)
									Case Else
                                        'lObject.PSet(New Point[](CShort(lLeft + (lWidth - lObject.TextWidth(lString1)) / 2), y))
                                        'lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                        'lObject.Print(lString1)
								End Select
						End Select
						rsData.moveNext()
					Loop 
					lCol = lCol + 1
					If lCol >= lCols Then
						lCol = 0
						lrow = lrow + 1
                        'If (lrow + 1) * lHeight > lObject.Height Then
                        'Printer.NewPage()
                        'lrow = -1
                        'End If
                    End If
                End If
            End If
        Next
        'Printer.EndDoc()
	End Sub
	
    Public Sub printBarcode(ByRef barcodePicture As PictureBox, ByRef lValue As String, ByRef lLeft As Integer, ByRef lTop As Integer, Optional ByRef lWidth As Integer = 0)
        Dim BF As Integer
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
            x = CShort(lLeft + (lWidth - UBound(barArray) * twipsPerPixel(True)) / 2)
        End If
        'For cnt = LBound(barArray) To UBound(barArray)
        ' If barArray(cnt) <> "" Then
        ' If CInt(Split(barArray(cnt), "~")(0)) = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black) Then
        '             barcodePicture.Line((x + cnt * twipsPerPixel(True), y) - (x + (cnt + 1) * _
        '                     twipsPerPixel(true), y + CInt(Split(barArray(cnt), "~")(1)) * _
        '                     twipsPerPixel(true)), CInt(Split(barArray(cnt), "~")(0)), BF)
        ' End If
        'End If

        'Next
    End Sub
	
    Function doImage(ByRef code As String, ByRef size_Renamed As Integer) As String
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
End Class