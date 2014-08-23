using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using DpSdkEngLib;
using DPSDKOPSLib;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using System.Runtime.InteropServices;
 // ERROR: Not supported in C#: OptionDeclaration
namespace _4PosBackOffice.NET
{
	static class modWinVer
	{
		[DllImport("kernel32", EntryPoint = "GetVersionExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
//UPGRADE_WARNING: Structure OSVERSIONINFO may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
		public static extern int GetVersionEx(ref OSVERSIONINFO lpVersionInformation);

		public struct OSVERSIONINFO
		{
			public int dwOSVersionInfoSize;
			public int dwMajorVersion;
			public int dwMinorVersion;
			public int dwBuildNumber;
			public int dwPlatformId;
			//UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
			[VBFixedString(128), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 128)]
			public char[] szCSDVersion;
		}

		public static bool Win7Ver()
		{
			bool functionReturnValue = false;
			System.OperatingSystem osVer = System.Environment.OSVersion;
			string PId = null;
			if (osVer.Version.Major == 6 && osVer.Version.Minor == 1) {
				functionReturnValue = true;
			} else {
				functionReturnValue = false;
			}
			return functionReturnValue;
		}

		//Public Function Win7Ver() As Boolean
		// Dim Ret As Integer
		// Dim OSInfo As OSVERSIONINFO
		// Dim PId As String
		// 'Set the graphical mode to persistent
		//' '    Me.AutoRedraw = True
		//'Set the structure size
		//		OSInfo.dwOSVersionInfoSize = Len(OSInfo)
		//    'Get the Windows version'
		//	Ret = GetVersionEx(OSInfo)
		//Chack for error's
		//    If ret& = 0 Then MsgBox "Error Getting Version Information": Exit Sub
		//	If Ret = 0 Then Win7Ver = False : Exit Function
		//Print the information to the form
		//	Select Case OSInfo.dwPlatformId
		//			Case 0'
		//		PId = "Windows 32s "
		//	Case '1
		//		PId = "Windows 95/98"
		//	Case 2
		//		PId = "Windows NT "
		//End Select
		//    Print "OS: " + PId
		//    Print "Win version:" + Str$(OSInfo.dwMajorVersion) + "." + LTrim(Str(OSInfo.dwMinorVersion))
		//    Print "Build: " + Str(OSInfo.dwBuildNumber)
		//	If OSInfo.dwMajorVersion >= 6 Then Win7Ver = True
		//End Function

		public static string getWinVer()
		{
			int Ret = 0;
			OSVERSIONINFO OSInfo = default(OSVERSIONINFO);
			string PId = null;
			//Set the graphical mode to persistent
			//    Me.AutoRedraw = True
			//Set the structure size
			OSInfo.dwOSVersionInfoSize = Strings.Len(OSInfo);
			//Get the Windows version
			Ret = GetVersionEx(ref OSInfo);
			//Chack for errors
			//    If ret& = 0 Then MsgBox "Error Getting Version Information": Exit Sub
			//If Ret& = 0 Then Win7Ver = False: Exit Function
			//Print the information to the form
			switch (OSInfo.dwPlatformId) {
				case 0:
					PId = "Windows 32s ";
					break;
				case 1:
					PId = "Windows 95/98";
					break;
				case 2:
					PId = "Windows NT ";
					break;
			}
			//    Print "OS: " + PId
			//    Print "Win version:" + Str$(OSInfo.dwMajorVersion) + "." + LTrim(Str(OSInfo.dwMinorVersion))
			//    Print "Build: " + Str(OSInfo.dwBuildNumber)
			return PId;
		}

		//Private Sub Form_Load()
		//    Dim OSInfo As OSVERSIONINFO, PId As String
		//    'Set the graphical mode to persistent
		//    Me.AutoRedraw = True
		//    'Set the structure size
		//    OSInfo.dwOSVersionInfoSize = Len(OSInfo)
		//    'Get the Windows version
		//    ret& = GetVersionEx(OSInfo)
		//    'Chack for errors
		//    If ret& = 0 Then MsgBox "Error Getting Version Information": Exit Sub
		//    'Print the information to the form
		//    Select Case OSInfo.dwPlatformId
		//        Case 0
		//            PId = "Windows 32s "
		//        Case 1
		//            PId = "Windows 95/98"
		//        Case 2
		//            PId = "Windows NT "
		//    End Select
		//    Print "OS: " + PId
		//    Print "Win version:" + Str$(OSInfo.dwMajorVersion) + "." + LTrim(Str(OSInfo.dwMinorVersion))
		//    Print "Build: " + Str(OSInfo.dwBuildNumber)
		//End Sub
	}
}
