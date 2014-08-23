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
	static class modTemporary
	{
		private const short vbDot = 46;
		private const short MAX_PATH = 260;
		private const short INVALID_HANDLE_VALUE = -1;
		private const string vbBackslash = "\\";
//Private Const ALL_FILES = "*.*"
		private const string ALL_FILES = "*.tmp";

		private struct FILETIME
		{
			public int dwLowDateTime;
			public int dwHighDateTime;
		}

		private struct WIN32_FIND_DATA
		{
			public int dwFileAttributes;
			public FILETIME ftCreationTime;
			public FILETIME ftLastAccessTime;
			public FILETIME ftLastWriteTime;
			public int nFileSizeHigh;
			public int nFileSizeLow;
			public int dwReserved0;
			public int dwReserved1;
			//UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
			[VBFixedString(modTemporary.MAX_PATH), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = modTemporary.MAX_PATH)]
			public char[] cFileName;
			//UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
			[VBFixedString(14), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 14)]
			public char[] cAlternate;
		}

		private struct FILE_PARAMS
		{
			public bool bRecurse;
			public int nCount;
			public int nSearched;
			public string sFileNameExt;
			public string sFileRoot;
		}
		[DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		private static extern int FindClose(int hFindFile);
		[DllImport("kernel32", EntryPoint = "FindFirstFileA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

//UPGRADE_WARNING: Structure WIN32_FIND_DATA may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
		private static extern int FindFirstFile(string lpFileName, ref WIN32_FIND_DATA lpFindFileData);
		[DllImport("kernel32", EntryPoint = "FindNextFileA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

//UPGRADE_WARNING: Structure WIN32_FIND_DATA may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
		private static extern int FindNextFile(int hFindFile, ref WIN32_FIND_DATA lpFindFileData);
		[DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		private static extern int GetTickCount();
		[DllImport("kernel32", EntryPoint = "lstrlenW", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		private static extern int lstrlen(int lpString);
		[DllImport("shlwapi", EntryPoint = "PathMatchSpecW", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		private static extern int PathMatchSpec(int pszFileParam, int pszSpec);

			//holds search parameters
		private static FILE_PARAMS fp;

		private const int LVM_FIRST = 0x1000;
		[DllImport("kernel32", EntryPoint = "DeleteFileA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		private static extern int DeleteFile(string lpFileName);

		static bool CancelSearch;
		private static bool MatchSpec(ref string sFile, ref string sSpec)
		{
			//UPGRADE_ISSUE: VarPtr.VarPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
			return PathMatchSpec(VarPtr.VarPtr(sFile), VarPtr.VarPtr(sSpec));

		}
		private static string TrimNull(ref string startstr)
		{
			//UPGRADE_ISSUE: VarPtr.VarPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
			return Strings.Left(startstr, lstrlen(VarPtr.VarPtr(startstr)));
		}
		private static string QualifyPath(ref string sPath)
		{
			string functionReturnValue = null;
			if (Strings.Right(sPath, 1) != vbBackslash)
				functionReturnValue = sPath + vbBackslash;
			else
				functionReturnValue = sPath;
			return functionReturnValue;
		}

		private static void SearchForFiles(ref string sRoot)
		{
			Scripting.FileSystemObject oFileSys = new Scripting.FileSystemObject();
			Scripting.TextStream oFile = default(Scripting.TextStream);
			WIN32_FIND_DATA WFD = default(WIN32_FIND_DATA);
			int hFile = 0;

			 // ERROR: Not supported in C#: OnErrorStatement


			hFile = FindFirstFile(sRoot + ALL_FILES, ref WFD);

			if (hFile != INVALID_HANDLE_VALUE) {
				FileSystem.FileOpen(1, "C:\\WriTMP.txt", OpenMode.Output);
				do {
					if (CancelSearch == true)
						return;
					if (MatchSpec(ref WFD.cFileName, ref fp.sFileNameExt)) {
						FileSystem.PrintLine(1, sRoot + TrimNull(ref WFD.cFileName));
					}
					//If MatchSpec

				} while (FindNextFile(hFile, ref WFD));

			}
			//If hFile

			FindClose(hFile);
			FileSystem.FileClose(1);

			oFile = oFileSys.OpenTextFile("C:\\WriTMP.txt", Scripting.IOMode.ForReading, false, Scripting.Tristate.TristateUseDefault);

			int FileNum = 0;
			while (!oFile.AtEndOfLine) {
				if (DeleteFile(oFile.ReadLine) == 0) {
					FileNum = FreeFile();
					FileSystem.FileOpen(FileNum, _4PosBackOffice.NET.My.MyProject.Application.Info.DirectoryPath + "\\log.txt", OpenMode.Binary, OpenAccess.Write);
					//UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
					FileSystem.FilePut(FileNum, oFile.ReadLine + Constants.vbCrLf);
					FileSystem.FileClose(FileNum);
				}
			}

		}

		public static void DeleteTempFiles()
		{

			var _with1 = fp;
			_with1.sFileRoot = QualifyPath(ref ref "C:\\");
			//start path
			_with1.sFileNameExt = "*.tmp;";
			_with1.bRecurse = true;
			//True = recursive search
			_with1.nCount = 0;
			//results
			_with1.nSearched = 0;
			//results

			SearchForFiles(ref fp.sFileRoot);

		}
	}
}
