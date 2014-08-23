Imports System.Runtime.InteropServices

Module VarPtr

    Public Function VarPtr(ByVal e As Object) As Integer
        Dim GC As GCHandle = GCHandle.Alloc(e, GCHandleType.Pinned)
        Dim GC2 As Integer = GC.AddrOfPinnedObject.ToInt32
        GC.Free()
        Return GC2
    End Function
End Module

Module ObjPtr
    Public Function ObjPtr(ByVal e As Object) As Integer
        Dim GC As GCHandle = GCHandle.Alloc(e, GCHandleType.Normal)
        Dim GC2 As Integer = GC.AddrOfPinnedObject.ToInt32
    End Function
End Module
