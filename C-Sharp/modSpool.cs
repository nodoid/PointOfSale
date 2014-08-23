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
	static class modSpool
	{
		[DllImport("kernel32", EntryPoint = "GetProfileStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

//
// Win32 API Calls
//
		private static extern int GetProfileString(string lpAppName, object lpKeyName, string lpDefault, string lpReturnedString, int nSize);
		[DllImport("winspool.drv", EntryPoint = "OpenPrinterA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int OpenPrinter(string pPrinterName, ref int phPrn, ref object pDefault);
		[DllImport("winspool.drv", EntryPoint = "StartDocPrinterA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
//UPGRADE_WARNING: Structure DOC_INFO_1 may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
		private static extern int StartDocPrinter(int hPrn, int Level, ref DOC_INFO_1 pDocInfo);
		[DllImport("winspool.drv", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int StartPagePrinter(int hPrn);
		[DllImport("winspool.drv", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int WritePrinter(int hPrn, ref object pBuf, int cdBuf, ref int pcWritten);
		[DllImport("winspool.drv", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int EndPagePrinter(int hPrn);
		[DllImport("winspool.drv", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int EndDocPrinter(int hPrn);
		[DllImport("winspool.drv", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int ClosePrinter(int hPrn);
//
// Structure required by StartDocPrinter
//
		private struct DOC_INFO_1
		{
			public string pDocName;
			public string pOutputFile;
			public string pDatatype;
		}

		public static void SpoolFile(ref string sFile, ref string PrnName, ref string AppName = "")
		{
			int hPrn = 0;
			byte[] Buffer = null;
			short hFile = 0;
			int Written = 0;
			DOC_INFO_1 di = default(DOC_INFO_1);
			int i = 0;
			const int BufSize = 0x4000;
			AppName = "4POS Barcode";
			//
			// Extract filename from passed spec, and build job name.
			// Fill remainder of DOC_INFO_1 structure.
			//
			if (Strings.InStr(sFile, "\\")) {
				for (i = Strings.Len(sFile); i >= 1; i += -1) {
					if (Strings.Mid(sFile, i, 1) == "\\")
						break; // TODO: might not be correct. Was : Exit For
					di.pDocName = Strings.Mid(sFile, i, 1) + di.pDocName;
				}
			} else {
				di.pDocName = sFile;
			}
			if (Strings.Len(AppName)) {
				di.pDocName = AppName;
			}
			di.pOutputFile = Constants.vbNullString;
			di.pDatatype = "RAW";
			//
			// Open printer for output to obtain handle.
			// Set it up to begin recieving raw data.
			//
			OpenPrinter(PrnName, ref hPrn, ref 0);
			StartDocPrinter(hPrn, 1, ref di);
			StartPagePrinter(hPrn);
			//
			// Open file and pump it to the printer.
			//
			hFile = FreeFile();
			FileSystem.FileOpen(hFile, sFile, OpenMode.Binary, OpenAccess.Read);
			//
			// Read in 16K buffers and spool.
			//
			//UPGRADE_WARNING: Lower bound of array Buffer was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
			Buffer = new byte[BufSize + 1];
			for (i = 1; i <= FileSystem.LOF(hFile) / BufSize; i++) {
				//UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileSystem.FileGet(hFile, Buffer);
				WritePrinter(hPrn, ref Buffer[1], BufSize, ref Written);
			}
			//
			// Get last chunk of file if it doesn't
			// fit evenly into a 16K buffer.
			//
			if (FileSystem.LOF(hFile) % BufSize) {
				//UPGRADE_WARNING: Lower bound of array Buffer was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
				Buffer = new byte[(FileSystem.LOF(hFile) % BufSize) + 1];
				//UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				FileSystem.FileGet(hFile, Buffer);
				WritePrinter(hPrn, ref Buffer[1], Information.UBound(Buffer), ref Written);
			}
			FileSystem.FileClose(hFile);
			//
			// Shut down spooling process.
			//
			EndPagePrinter(hPrn);
			EndDocPrinter(hPrn);
			ClosePrinter(hPrn);
		}
	}
}
