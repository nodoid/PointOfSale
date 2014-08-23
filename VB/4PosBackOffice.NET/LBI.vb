Public Class LBI
    Private mString As String
    Private mT As Object

    Public Sub New(inString As String, inT As Object)
        mString = inString
        mT = inT
    End Sub

    Public Overrides Function ToString() As String
        Return mString & ", " & mT
    End Function

End Class
