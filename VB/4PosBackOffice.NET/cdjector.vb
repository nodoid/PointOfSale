Option Strict Off
Option Explicit On
Module CDjector
	Private Declare Function mciSendString Lib "winmm.dll"  Alias "mciSendStringA"(ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Integer, ByVal hwndCallback As Integer) As Integer
	Public Function openCD(ByVal dRv As String) As Integer
		'UPGRADE_NOTE: Alias was upgraded to Alias_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim Alias_Renamed As String
		Dim retval As Integer
		Alias_Renamed = "Drive" & dRv
		retval = -1 'we need to set retval to anything other then 0
		retval = mciSendString("open " & dRv & ": type cdaudio alias " & Alias_Renamed & " wait", vbNullString, 0, 0)
		retval = mciSendString("set " & Alias_Renamed & " door open", vbNullString, 0, 0)
		openCD = retval
	End Function
	Public Function closeCD(ByVal dRv As String) As Integer
		'UPGRADE_NOTE: Alias was upgraded to Alias_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim Alias_Renamed As String
		Dim retval As Integer
		Alias_Renamed = "Drive" & dRv
		retval = -1 'we need to set retval to anything other then 0
		retval = mciSendString("set " & Alias_Renamed & " door closed", vbNullString, 0, 0)
		retval = mciSendString("close " & Alias_Renamed, vbNullString, 0, 0)
		closeCD = retval
	End Function
End Module