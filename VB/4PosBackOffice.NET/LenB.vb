Module modLenB
    Public Function LenB(ByVal ObjStr As String) As Integer
        If Len(ObjStr) = 0 Then Return 0
        Return System.Text.Encoding.Unicode.GetByteCount(ObjStr)
    End Function

    Public Function LenB(ByVal Obj As Object) As Integer
        If Obj Is Nothing Then Return 0
        Try
            Return Len(Obj)
        Catch
            Try
                Return System.Runtime.InteropServices.Marshal.SizeOf(Obj)
            Catch
                Return -1
            End Try
        End Try
    End Function
End Module
