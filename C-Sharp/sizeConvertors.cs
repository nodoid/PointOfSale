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
namespace _4PosBackOffice.NET
{
	static class sizeConvertors
	{
		[DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		public static extern long GetDC(long hwnd);
		[DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		public static extern long ReleaseDC(long hwnd, long hdc);
		[DllImport("gdi32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		public static extern long GetDeviceCaps(long hdc, long nIndex);

		const  WU_LOGPIXELSX = 88;

		const  WU_LOGPIXELSY = 90;
		public static long twipsPerPixel(bool lngDirection)
		{
			//Dim lngDC As Long
			//Dim lngPPI As Long
			//Const nTwipsPerInch = 1440
			//lngDC = GetDC(0)
			//If (lngDirection) Then
			// lngPPI = GetDeviceCaps(lngDC, WU_LOGPIXELSX)
			// Else
			// lngPPI = GetDeviceCaps(lngDC, WU_LOGPIXELSY)
			// End If
			// lngDC = ReleaseDC(0, lngDC)
			// twipsPerPixel = (1 / nTwipsPerInch) * lngPPI
		}

		public static long twipsToPixels(long lngTwips, bool lngDirection)
		{
			//Dim lngDC As Long
			//Dim lngPixelsPerInch As Long
			//Const nTwipsPerInch = 1440
			//lngDC = GetDC(0)

			//If (lngDirection) Then       'Horizontal
			// lngPixelsPerInch = GetDeviceCaps(lngDC, WU_LOGPIXELSX)
			// Else                            'Vertical
			// lngPixelsPerInch = GetDeviceCaps(lngDC, WU_LOGPIXELSY)
			// End If
			// lngDC = ReleaseDC(0, lngDC)
			// twipsToPixels = (lngTwips / nTwipsPerInch) * lngPixelsPerInch
		}

		public static long pixelToTwips(long lngPixels, bool lngDirection)
		{
			//Dim lngDC As Long
			//Dim lngPPI As Long
			//Const TPI = 1440
			//lngDC = GetDC(0)
			//If (lngDirection) Then
			//lngPPI = GetDeviceCaps(lngDC, WU_LOGPIXELSX)
			//Else
			//lngPPI = GetDeviceCaps(lngDC, WU_LOGPIXELSY)
			//End If
			//lngDC = ReleaseDC(0, lngDC)
			//pixelToTwips = (lngPixels * TPI) / lngPPI
		}
	}
}
