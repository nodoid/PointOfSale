Public Class SetItemData
    Private iPosition As Integer
    Private oValue As Object

    Public Sub New(position As Integer, value As Object)
        iPosition = position
        oValue = value
    End Sub

    Public Overrides Function ToString() As String
        Return iPosition & ", " & oValue
    End Function
End Class
