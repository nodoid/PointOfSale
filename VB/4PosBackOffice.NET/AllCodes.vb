Option Strict Off
Option Explicit On
Module AllCodes
	'What you see on the computer screen isn't what you will get when you print,
	'the computer screen doesn't have the same resolution as a printer, therefore
	'lines might appear to "merge" on the screen.
	'The values in varBar1 are the available text in a given Barcode language to be printed
	'The values in varBar2 are the Barcode equivalent of the text in varBar1
	'sBar is the accumulated Barcode equivalents of the text to be printed
	'The Barcode() Function will print one character of sBar at a time in a loop
	'To add more Barcode types, just continue to build functions that make the appropriate sBar String
	Dim sBar As String
    Dim i0, i1 As Integer

    Public Function Code39(ByRef strCode As String) As Object
        Dim varBar1 As String() = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", _
                                   "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", _
                                   "S", "T", "U", "V", "W", "X", "Y", "Z", "-", ".", " ", "$", "/", "+", _
                                   "%", "*"}
        Dim varBar2 As String() = {"111221211", "211211112", "112211112", "212211111", "111221112", "211221111", _
                                   "112221111", "111211212", "211211211", "112211211", "211112112", "112112112", _
                                   "212112111", "111122112", "211122111", "112122111", "111112212", "211112211", _
                                   "112112211", "111122211", "211111122", "112111122", "212111121", "111121122", _
                                   "211121121", "112121121", "111111222", "211111221", "112111221", "111121221", _
                                   "221111112", "122111112", "222111111", "121121112", "221121111", "122121111", _
                                   "121111212", "221111211", "122111211", "121212111", "121211121", "121112121", _
                                   "111212121", "121121211"}
        sBar = "121121211" & "1"
        For i0 = 1 To Len(strCode)
            For i1 = 0 To UBound(varBar1)
                If Mid(strCode, i0, 1) = varBar1(i1) Then sBar = sBar & varBar2(i1) & "1"
            Next
        Next
        sBar = sBar & "121121211"
        Return sBar
    End Function
    Public Function Code128(ByRef strCode As String) As Object
        Dim varBar1 As String() = {" ", "!", Chr(34), "#", "$", "%", "&", "'", "(", ")", "*", "+", ",", "-", ".", _
        "/", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", ":", ";", "<", "=", ">", "?", "@", "A", "B", _
        "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", _
        "W", "X", "Y", "Z", "[", "\", "]", "^", "_", ",", "`", "a", "b", "c", "d", "e", "f", "g", "h", "i", _
        "j", "k", "I", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "{", "|", "}", _
        "~", "DEL", "FNC 3", "FNC 2", "SHIFT", "CODE C", "FNC 4", "CODE A", "FNC 1", "Start A", _
        "Start B", "Start C", "Stop"}

        Dim varBar2 As String() = {"212222", "222122", "222221", "121223", "121322", "131222", "122213", "122312", _
                                   "132212", "221213", "221312", "231212", "112232", "122132", "122231", "113222", _
                                   "123122", "123221", "223211", "221132", "221231", "213212", "223112", "312131", _
                                   "311222", "321122", "321221", "312212", "322112", "322211", "212123", "212321", _
                                   "232121", "111323", "131123", "131321", "112313", "132113", "132311", "211313", _
                                   "231113", "231311", "112133", "112331", "132131", "113123", "113321", "133121", _
                                   "313121", "211331", "231131", "213113", "213311", "213131", "311123", "311321", _
                                   "331121", "312113", "312311", "332111", "314111", "221411", "431111", "111224", _
                                   "111422", "121124", "121421", "141122", "141221", "112214", "112412", "122114", _
                                   "122411", "142112", "142211", "241211", "221114", "413111", "241112", "134111", _
                                   "111242", "121142", "121241", "114212", "124112", "124211", "411212", "421112", _
                                   "421211", "212141", "214121", "412121", "111143", "111341", "131141", "114113", _
                                   "114311", "411113", "411311", "113141", "114131", "311141", "411131", "211412", _
                                   "211214", "211232", "2331112"}
        Dim chksum As Single = 104
        sBar = "211214"
        For i0 = 1 To Len(strCode)
            For i1 = 0 To UBound(varBar1)
                If Mid(strCode, i0, 1) = varBar1(i1) Then
                    sBar = sBar & varBar2(i1)
                    chksum = chksum + (i1 * i0)
                    Exit For
                End If
            Next
        Next
        'sBar = varBar2(chksum - (Int(chksum / 103) * 103)) & "2331112"
        sBar = sBar & varBar2(chksum - (Int(chksum / 103) * 103)) & "2331112"
        Return sBar
    End Function
    Public Function Code25(ByRef strCode As String) As Object
        Dim tmpHold(20) As String
        Dim varBar1 As String() = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0"}
        Dim varBar2 As String() = {"3-1-1-1-3", "1-3-1-1-3", "3-3-1-1-1", "1-1-3-1-3", "3-1-3-1-1", "1-3-3-1-1", _
                                   "1-1-1-3-3", "3-1-1-3-1", "1-3-1-3-1", "1-1-3-3-1"}
        Dim varBar3 As String()
        Dim varBar4 As String()
        sBar = "1111"
        For i0 = 1 To Len(strCode)
            For i1 = 0 To UBound(varBar1)
                If Mid(strCode, i0, 1) = varBar1(i1) Then tmpHold(i0 - 1) = varBar2(i1)
            Next
        Next
        i0 = 0
        Do Until i0 = Len(strCode)
            ReDim varBar3(i0)
            varBar3 = Split(tmpHold(i0), "-")
            varBar4 = Split(tmpHold(i0 + 1), "-")
            For i1 = 0 To 4
                sBar = sBar & varBar3(i1) & varBar4(i1)
            Next
            i0 = i0 + 2
        Loop
        sBar = sBar & "311"
        Return sBar
    End Function
    Public Function Codabar(ByRef strCode As String) As Object
        Dim varBar1 As String() = Split("1,2,3,4,5,6,7,8,9,0,-,$,:,/,.,+,A,B,C,D", ",")
        Dim varBar2 As String() = Split("1111221,1112112,2211111,1121121,2111121,1211112,1211211,1221111,2112111,1111122,1112211,1122111,2111212,2121112,2121211,1121212,1122121,1212112,1112122,1112221", ",")
        sBar = "1122121" & "1"
        For i0 = 1 To Len(strCode)
            For i1 = 0 To UBound(varBar1)
                If Mid(strCode, i0, 1) = varBar1(i1) Then sBar = sBar & varBar2(i1) & "1"
            Next
        Next
        sBar = sBar & "1122121"
        Return sBar
    End Function
    Public Function Barcode(ByRef CodeType As String, ByRef strCode As String, ByRef pic As Object, _
                            ByRef barscale As Short, ByRef barHeight As Single, ByRef StartX As Single, _
                            ByRef startY As Single) As Object
        Dim BF As Object
        Dim barWidth, barStart As Single
        Dim i0 As Short
        Select Case CodeType
            Case "39" : strCode = UCase(strCode) : Code39(strCode)
            Case "128" : Code128(strCode)
            Case "2/5" : strCode = IIf(Len(strCode) Mod 2 > 0, strCode & "0", strCode) : Code25(strCode)
            Case "Codabar" : strCode = UCase(strCode) : Codabar(strCode)
        End Select
        barStart = StartX
        For i0 = 1 To Len(sBar)
            barWidth = CDbl(Mid(sBar, i0, 1)) * barscale
            'UPGRADE_WARNING: Couldn't resolve default property of object pic.Line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If i0 Mod 2 > 0 Then
                'pic.Line((barStart, startY) - Step(barWidth, barHeight), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black), BF)
            End If
            barStart = barStart + IIf(i0 Mod 2 > 0, barWidth, barWidth * 1.3)
        Next
        Return barStart

        'pic.FontSize = 16: pic.CurrentX = StartX: pic.CurrentY = (startY * 1.2) + barHeight: pic.Print strCode
    End Function
End Module