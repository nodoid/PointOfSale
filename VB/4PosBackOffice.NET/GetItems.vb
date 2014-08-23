Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Module GetIndex
    Public Function GetIndexer(ByRef text1 As Object, ByRef text2 As IEnumerable(Of Control))
        Dim index As Integer
        Dim m As New Control
        index = 0
        For Each m In text2
            If m.Name <> text1.Name Then
                index = index + 1
            Else
                Exit For
            End If
        Next
        Return index
    End Function
End Module
