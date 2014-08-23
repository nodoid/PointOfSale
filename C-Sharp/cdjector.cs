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
	static class CDjector
	{
		[DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);
		public static int openCD(string dRv)
		{
			//UPGRADE_NOTE: Alias was upgraded to Alias_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			string Alias_Renamed = null;
			int retval = 0;
			Alias_Renamed = "Drive" + dRv;
			retval = -1;
			//we need to set retval to anything other then 0
			retval = mciSendString("open " + dRv + ": type cdaudio alias " + Alias_Renamed + " wait", Constants.vbNullString, 0, 0);
			retval = mciSendString("set " + Alias_Renamed + " door open", Constants.vbNullString, 0, 0);
			return retval;
		}
		public static int closeCD(string dRv)
		{
			//UPGRADE_NOTE: Alias was upgraded to Alias_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			string Alias_Renamed = null;
			int retval = 0;
			Alias_Renamed = "Drive" + dRv;
			retval = -1;
			//we need to set retval to anything other then 0
			retval = mciSendString("set " + Alias_Renamed + " door closed", Constants.vbNullString, 0, 0);
			retval = mciSendString("close " + Alias_Renamed, Constants.vbNullString, 0, 0);
			return retval;
		}
	}
}
