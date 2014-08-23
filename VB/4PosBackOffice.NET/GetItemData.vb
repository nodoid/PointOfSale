Module GID

    Public Function GetItemDataString(ByRef listObj As Object, ByRef posn As Integer) As String
        Return listObj(posn).ToString
    End Function

    Public Function GetItemData(ByRef listObj As Object, ByRef posn As Integer) As Integer
        Return listObj(posn)
    End Function

    Public Function GetItemString(ByRef listObj As Object, ByRef posn As Integer) As String
        Return listObj(posn).ToString
    End Function

End Module
