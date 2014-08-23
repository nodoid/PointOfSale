Option Explicit On
Imports System.Text
Imports System.IO
Public Class clsRC4
    Private Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" (Destination As Long, Source As Long, ByVal Length As Long)

    Private m_Key As String
    Private m_sBox(0 To 255) As Integer
    Private m_bytIndex(0 To 63) As Byte
    Private m_bytReverseIndex(0 To 255) As Byte
    Private Const k_bytEqualSign As Byte = 61
    Private Const k_bytMask1 As Byte = 3
    Private Const k_bytMask2 As Byte = 15
    Private Const k_bytMask3 As Byte = 63
    Private Const k_bytMask4 As Byte = 192
    Private Const k_bytMask5 As Byte = 240
    Private Const k_bytMask6 As Byte = 252
    Private Const k_bytShift2 As Byte = 4
    Private Const k_bytShift4 As Byte = 16
    Private Const k_bytShift6 As Byte = 64
    Private Const k_lMaxBytesPerLine As Long = 152

    Private Sub Initialize64()
        Dim x As Integer
        Dim y As Integer
        For x = 0 To 51
            m_bytIndex(x) = x + 65
        Next
        For x = 52 To 61
            m_bytIndex(x) = x - 4
            m_bytReverseIndex(x - 4) = x
        Next
        m_bytIndex(62) = 43 'Asc("+")
        m_bytIndex(63) = 47 'Asc("/")
        y = 0
        For x = 65 To 122
            m_bytReverseIndex(x) = y
            y = y + 1
        Next
        m_bytReverseIndex(43) = 62 'Asc("+")
        m_bytReverseIndex(47) = 63 'Asc("/")
    End Sub

    Public Function Decode64(sInput As String) As String
        If sInput = "" Then Exit Function
        Decode64 = Encoding.ASCII.GetString(DecodeArray64(sInput))
    End Function

    Public Function DecodeArray64(sInput As String) As Byte()
        If m_bytReverseIndex(47) <> 63 Then Initialize64()
        Dim bytInput() As Byte
        Dim bytWorkspace() As Byte
        Dim bytResult() As Byte
        Dim lInputCounter As Long
        Dim lWorkspaceCounter As Long

        Dim innerString As String = Replace(sInput, vbCrLf, "")
        Dim outerString As String = Replace(innerString, "=", "")
        bytInput = UTF8Encoding.UTF8.GetBytes(outerString)
        ReDim bytWorkspace(0 To (UBound(bytInput) * 2))
        lWorkspaceCounter = LBound(bytWorkspace)
        For lInputCounter = LBound(bytInput) To UBound(bytInput)
            bytInput(lInputCounter) = m_bytReverseIndex(bytInput(lInputCounter))
        Next lInputCounter

        For lInputCounter = LBound(bytInput) To (UBound(bytInput) - ((UBound(bytInput) Mod 8) + 8)) Step 8
            bytWorkspace(lWorkspaceCounter) = (bytInput(lInputCounter) * k_bytShift2) + (bytInput(lInputCounter + 2) \ k_bytShift4)
            bytWorkspace(lWorkspaceCounter + 1) = ((bytInput(lInputCounter + 2) And k_bytMask2) * k_bytShift4) + (bytInput(lInputCounter + 4) \ k_bytShift2)
            bytWorkspace(lWorkspaceCounter + 2) = ((bytInput(lInputCounter + 4) And k_bytMask1) * k_bytShift6) + bytInput(lInputCounter + 6)
            lWorkspaceCounter = lWorkspaceCounter + 3
        Next lInputCounter

        Select Case (UBound(bytInput) Mod 8)
            Case 3
                bytWorkspace(lWorkspaceCounter) = (bytInput(lInputCounter) * k_bytShift2) + (bytInput(lInputCounter + 2) \ k_bytShift4)
            Case 5
                bytWorkspace(lWorkspaceCounter) = (bytInput(lInputCounter) * k_bytShift2) + (bytInput(lInputCounter + 2) \ k_bytShift4)
                bytWorkspace(lWorkspaceCounter + 1) = ((bytInput(lInputCounter + 2) And k_bytMask2) * k_bytShift4) + (bytInput(lInputCounter + 4) \ k_bytShift2)
                lWorkspaceCounter = lWorkspaceCounter + 1
            Case 7
                bytWorkspace(lWorkspaceCounter) = (bytInput(lInputCounter) * k_bytShift2) + (bytInput(lInputCounter + 2) \ k_bytShift4)
                bytWorkspace(lWorkspaceCounter + 1) = ((bytInput(lInputCounter + 2) And k_bytMask2) * k_bytShift4) + (bytInput(lInputCounter + 4) \ k_bytShift2)
                bytWorkspace(lWorkspaceCounter + 2) = ((bytInput(lInputCounter + 4) And k_bytMask1) * k_bytShift6) + bytInput(lInputCounter + 6)
                lWorkspaceCounter = lWorkspaceCounter + 2
        End Select

        ReDim bytResult(0 To lWorkspaceCounter)
        If LBound(bytWorkspace) = 0 Then lWorkspaceCounter = lWorkspaceCounter + 1
        CopyMemory(VarPtr.VarPtr(bytResult(LBound(bytResult))), VarPtr.VarPtr(bytWorkspace(LBound(bytWorkspace))), lWorkspaceCounter)
        DecodeArray64 = bytResult
    End Function

    Public Function Encode64(ByRef sInput As String) As String
        If sInput = "" Then Exit Function
        Dim bytTemp() As Byte
        bytTemp = Encoding.ASCII.GetBytes(sInput)
        Encode64 = EncodeArray64(bytTemp)
    End Function

    Public Function EncodeArray64(ByRef bytInput() As Byte) As String
        On Error GoTo ErrorHandler

        If m_bytReverseIndex(47) <> 63 Then Initialize64()
        Dim bytWorkspace() As Byte, bytResult() As Byte
        Dim bytCrLf(0 To 3) As Byte, lCounter As Long
        Dim lWorkspaceCounter As Long, lLineCounter As Long
        Dim lCompleteLines As Long, lBytesRemaining As Long
        Dim lpWorkSpace As Long, lpResult As Long
        Dim lpCrLf As Long

        If UBound(bytInput) < 1024 Then
            ReDim bytWorkspace(0 To (LBound(bytInput) + 4096))
        Else
            ReDim bytWorkspace(0 To (UBound(bytInput) * 4))
        End If

        lWorkspaceCounter = LBound(bytWorkspace)

        For lCounter = LBound(bytInput) To (UBound(bytInput) - ((UBound(bytInput) Mod 3) + 3)) Step 3
            bytWorkspace(lWorkspaceCounter) = m_bytIndex((bytInput(lCounter) \ k_bytShift2))
            bytWorkspace(lWorkspaceCounter + 2) = m_bytIndex(((bytInput(lCounter) And k_bytMask1) * k_bytShift4) + ((bytInput(lCounter + 1)) \ k_bytShift4))
            bytWorkspace(lWorkspaceCounter + 4) = m_bytIndex(((bytInput(lCounter + 1) And k_bytMask2) * k_bytShift2) + (bytInput(lCounter + 2) \ k_bytShift6))
            bytWorkspace(lWorkspaceCounter + 6) = m_bytIndex(bytInput(lCounter + 2) And k_bytMask3)
            lWorkspaceCounter = lWorkspaceCounter + 8
        Next lCounter

        Select Case (UBound(bytInput) Mod 3)
            Case 0
                bytWorkspace(lWorkspaceCounter) = m_bytIndex((bytInput(lCounter) \ k_bytShift2))
                bytWorkspace(lWorkspaceCounter + 2) = m_bytIndex((bytInput(lCounter) And k_bytMask1) * k_bytShift4)
                bytWorkspace(lWorkspaceCounter + 4) = k_bytEqualSign
                bytWorkspace(lWorkspaceCounter + 6) = k_bytEqualSign
            Case 1
                bytWorkspace(lWorkspaceCounter) = m_bytIndex((bytInput(lCounter) \ k_bytShift2))
                bytWorkspace(lWorkspaceCounter + 2) = m_bytIndex(((bytInput(lCounter) And k_bytMask1) * k_bytShift4) + ((bytInput(lCounter + 1)) \ k_bytShift4))
                bytWorkspace(lWorkspaceCounter + 4) = m_bytIndex((bytInput(lCounter + 1) And k_bytMask2) * k_bytShift2)
                bytWorkspace(lWorkspaceCounter + 6) = k_bytEqualSign
            Case 2
                bytWorkspace(lWorkspaceCounter) = m_bytIndex((bytInput(lCounter) \ k_bytShift2))
                bytWorkspace(lWorkspaceCounter + 2) = m_bytIndex(((bytInput(lCounter) And k_bytMask1) * k_bytShift4) + ((bytInput(lCounter + 1)) \ k_bytShift4))
                bytWorkspace(lWorkspaceCounter + 4) = m_bytIndex(((bytInput(lCounter + 1) And k_bytMask2) * k_bytShift2) + ((bytInput(lCounter + 2)) \ k_bytShift6))
                bytWorkspace(lWorkspaceCounter + 6) = m_bytIndex(bytInput(lCounter + 2) And k_bytMask3)
        End Select

        lWorkspaceCounter = lWorkspaceCounter + 8

        If lWorkspaceCounter <= k_lMaxBytesPerLine Then
            EncodeArray64 = Left(bytWorkspace.ToString, InStr(1, bytWorkspace.ToString, "") - 1)
        Else
            bytCrLf(0) = 13
            bytCrLf(1) = 0
            bytCrLf(2) = 10
            bytCrLf(3) = 0
            ReDim bytResult(0 To UBound(bytWorkspace))
            lpWorkSpace = VarPtr.VarPtr(bytWorkspace(LBound(bytWorkspace)))
            lpResult = VarPtr.VarPtr(bytResult(LBound(bytResult)))
            lpCrLf = VarPtr.VarPtr(bytCrLf(LBound(bytCrLf)))
            lCompleteLines = Fix(lWorkspaceCounter / k_lMaxBytesPerLine)

            For lLineCounter = 0 To lCompleteLines
                CopyMemory(lpResult, lpWorkSpace, k_lMaxBytesPerLine)
                lpWorkSpace = lpWorkSpace + k_lMaxBytesPerLine
                lpResult = lpResult + k_lMaxBytesPerLine
                CopyMemory(lpResult, lpCrLf, 4&)
                lpResult = lpResult + 4&
            Next lLineCounter

            lBytesRemaining = lWorkspaceCounter - (lCompleteLines * k_lMaxBytesPerLine)
            If lBytesRemaining > 0 Then CopyMemory(lpResult, lpWorkSpace, lBytesRemaining)
            EncodeArray64 = Left(bytResult.ToString, InStr(1, bytResult.ToString, "") - 1)
        End If
        Exit Function

ErrorHandler:
        Erase bytResult
        EncodeArray64 = bytResult.ToString
    End Function

    Public Function EncryptFile(InFile As String, OutFile As String, Overwrite As Boolean, Optional Key As String = "", Optional OutputIn64 As Boolean = False) As Boolean
        On Error GoTo ErrorHandler
        If FileExist(InFile) = False Then
            EncryptFile = False
            Exit Function
        End If
        If FileExist(OutFile) = True And Overwrite = False Then
            EncryptFile = False
            Exit Function
        End If
        Dim FileO As Integer, Buffer() As Byte
        FileO = FreeFile()
        Dim inStream As New FileStream(FileO.ToString, FileMode.Open)
        Dim binRead As BinaryReader = New BinaryReader(inStream)

        ReDim Buffer(0 To FileLen(FileO.ToString - 1))
        Buffer = binRead.ReadBytes(FileLen(FileO.ToString - 1))
        binRead.Close()
        inStream.Close()
        Call EncryptByte(Buffer, Key)
        If FileExist(OutFile) = True Then Kill(OutFile)
        FileO = FreeFile()

        Dim outStream As New FileStream(FileO.ToString, FileMode.Create)
        Dim binWrite As BinaryWriter = New BinaryWriter(outStream)
        If OutputIn64 = True Then
            binWrite.Write(EncodeArray64(Buffer))
        Else
            binWrite.Write(Buffer)
        End If
        binWrite.Close()
        outStream.Close()
        EncryptFile = True
        Exit Function

ErrorHandler:
        EncryptFile = False
    End Function
    Public Function DecryptFile(InFile As String, OutFile As String, Overwrite As Boolean, Optional Key As String = "", Optional IsFileIn64 As Boolean = False) As Boolean
        On Error GoTo ErrorHandler
        If FileExist(InFile) = False Then
            DecryptFile = False
            Exit Function
        End If
        If FileExist(OutFile) = True And Overwrite = False Then
            DecryptFile = False
            Exit Function
        End If
        Dim FileO As Integer, Buffer() As Byte
        FileO = FreeFile()
        Dim inStream As New FileStream(FileO.ToString, FileMode.Open)
        Dim binRead As BinaryReader = New BinaryReader(inStream)

        ReDim Buffer(0 To FileLen(FileO.ToString) - 1)
        Buffer = binRead.ReadBytes(FileLen(FileO.ToString) - 1)
        binRead.Close()
        inStream.Close()

        If IsFileIn64 = True Then Buffer = DecodeArray64(Encoding.ASCII.GetString(Buffer))
        Call DecryptByte(Buffer, Key)
        If FileExist(OutFile) = True Then Kill(OutFile)
        FileO = FreeFile()
        Dim outStream As New FileStream(FileO.ToString, FileMode.Create)
        Dim binWrite As BinaryWriter = New BinaryWriter(outStream)
        binWrite.Write(Buffer)
        binWrite.Close()
        outStream.Close()

        DecryptFile = True
        Exit Function

ErrorHandler:
        DecryptFile = False
    End Function

    Public Sub DecryptByte(byteArray() As Byte, Optional Key As String = "")
        Call EncryptByte(byteArray, Key)
    End Sub
    Public Function EncryptString(Text As String, Optional Key As String = "", Optional OutputIn64 As Boolean = False) As String
        Dim byteArray() As Byte
        byteArray = Encoding.ASCII.GetBytes(Text)
        Call EncryptByte(byteArray, Key)
        EncryptString = Encoding.ASCII.GetString(byteArray)
        If OutputIn64 = True Then EncryptString = Encode64(EncryptString)
    End Function
    Public Function DecryptString(Text As String, Optional Key As String = "", Optional IsTextIn64 As Boolean = False) As String
        Dim byteArray() As Byte
        If IsTextIn64 = True Then Text = Decode64(Text)
        byteArray = Encoding.ASCII.GetBytes(Text)
        Call DecryptByte(byteArray, Key)
        DecryptString = Encoding.ASCII.GetString(byteArray)
    End Function

    Public Sub EncryptByte(byteArray() As Byte, Optional Key As String = "")
        Dim i As Long, j As Long, Temp As Byte, Offset As Long, OrigLen As Long, CipherLen As Long, CurrPercent As Long, NextPercent As Long, sBox(0 To 255) As Integer

        If (Len(Key) > 0) Then Me.Key = Key
        Call CopyMemory(sBox(0), m_sBox(0), 512)
        OrigLen = UBound(byteArray) + 1
        CipherLen = OrigLen

        For Offset = 0 To (OrigLen - 1)
            i = (i + 1) Mod 256
            j = (j + sBox(i)) Mod 256
            Temp = sBox(i)
            sBox(i) = sBox(j)
            sBox(j) = Temp
            byteArray(Offset) = byteArray(Offset) Xor (sBox((sBox(i) + sBox(j)) Mod 256))
            If (Offset >= NextPercent) Then
                CurrPercent = Int((Offset / CipherLen) * 100)
                NextPercent = (CipherLen * ((CurrPercent + 1) / 100)) + 1
                'RaiseEvent Progress(CurrPercent)
            End If
        Next
        'If (CurrPercent <> 100) Then RaiseEvent Progress(100)
    End Sub
    Private Function FileExist(Filename As String) As Boolean
        On Error GoTo ErrorHandler
        Call FileLen(Filename)
        FileExist = True
        Exit Function

ErrorHandler:
        FileExist = False
    End Function


    Public WriteOnly Property Key() As String
        Set(value As String)
            Dim a As Long, b As Long, Temp As Byte, myKey() As Byte, KeyLen As Long
            If (m_Key = value) Then Exit Property
            m_Key = value
            'myKey = StrConv(m_Key, vbFromUnicode)
            myKey = Encoding.ASCII.GetBytes(m_Key)
            KeyLen = Len(m_Key)
            For a = 0 To 255
                m_sBox(a) = a
            Next a
            For a = 0 To 255
                b = (b + m_sBox(a) + myKey(a Mod KeyLen)) Mod 256
                Temp = m_sBox(a)
                m_sBox(a) = m_sBox(b)
                m_sBox(b) = Temp
            Next
        End Set
    End Property
End Class
