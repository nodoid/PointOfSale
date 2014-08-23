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
	static class CodeModule
	{

//-- C Style argv
		public struct UNZIPnames
		{
			[VBFixedArray(99)]
			public string[] uzFiles;

			//UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
			public void Initialize()
			{
				uzFiles = new string[100];
			}
		}

//-- Callback Large "String"
		public struct UNZIPCBChar
		{
			[VBFixedArray(32800)]
			public byte[] ch;

			//UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
			public void Initialize()
			{
				ch = new byte[32801];
			}
		}

//-- Callback Small "String"
		public struct UNZIPCBCh
		{
			[VBFixedArray(256)]
			public byte[] ch;

			//UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
			public void Initialize()
			{
				ch = new byte[257];
			}
		}

//-- UNZIP32.DLL DCL Structure
		public struct DCLIST
		{
				// 1 = Extract Only Newer, Else 0
			public int ExtractOnlyNewer;
				// 1 = Convert Space To Underscore, Else 0
			public int SpaceToUnderScore;
				// 1 = Prompt To Overwrite Required, Else 0
			public int PromptToOverwrite;
				// 2 = No Messages, 1 = Less, 0 = All
			public int fQuiet;
				// 1 = Write To Stdout, Else 0
			public int ncflag;
				// 1 = Test Zip File, Else 0
			public int ntflag;
				// 0 = Extract, 1 = List Zip Contents
			public int nvflag;
				// 1 = Extract Only Newer, Else 0
			public int nUflag;
				// 1 = Display Zip File Comment, Else 0
			public int nzflag;
				// 1 = Honor Directories, Else 0
			public int ndflag;
				// 1 = Overwrite Files, Else 0
			public int noflag;
				// 1 = Convert CR To CRLF, Else 0
			public int naflag;
				// 1 = Zip Info Verbose, Else 0
			public int nZIflag;
				// 1 = Case Insensitivity, 0 = Case Sensitivity
			public int C_flag;
				// 1 = ACL, 2 = Privileges
			public int fPrivilege;
				// The Zip Filename To Extract Files
			public string Zip;
				// The Extraction Directory, NULL If Extracting To Current Dir
			public string ExtractDir;
		}

//-- UNZIP32.DLL Userfunctions Structure
		public struct USERFUNCTION
		{
				// Pointer To Apps Print Function
			public int UZDLLPrnt;
				// Pointer To Apps Sound Function
			public int UZDLLSND;
				// Pointer To Apps Replace Function
			public int UZDLLREPLACE;
				// Pointer To Apps Password Function
			public int UZDLLPASSWORD;
				// Pointer To Apps Message Function
			public int UZDLLMESSAGE;
				// Pointer To Apps Service Function (Not Coded!)
			public int UZDLLSERVICE;
				// Total Size Of Zip Archive
			public int TotalSizeComp;
				// Total Size Of All Files In Archive
			public int TotalSize;
				// Compression Factor
			public int CompFactor;
				// Total Number Of All Files In The Archive
			public int NumMembers;
				// Flag If Archive Has A Comment!
			public short cchComment;
		}

//-- UNZIP32.DLL Version Structure
		public struct UZPVER
		{
				// Length Of The Structure Being Passed
			public int structlen;
				// Bit 0: is_beta  bit 1: uses_zlib
			public int flag;
			//UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
			[VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 10)]
				// e.g., "g BETA" or ""
			public char[] beta;
			//UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
			//UPGRADE_NOTE: date was upgraded to date_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			[VBFixedString(20), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 20)]
				// e.g., "4 Sep 95" (beta) or "4 September 1995"
			public char[] date_Renamed;
			//UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
			[VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 10)]
				// e.g., "1.0.5" or NULL
			public char[] zlib;
			[VBFixedArray(4)]
				// Version Type Unzip
			public byte[] Unzip;
			[VBFixedArray(4)]
				// Version Type Zip Info
			public byte[] zipinfo;
				// Version Type OS2 DLL
			public int os2dll;
			[VBFixedArray(4)]
				// Version Type Windows DLL
			public byte[] windll;

			//UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
			public void Initialize()
			{
				//UPGRADE_WARNING: Lower bound of array Unzip was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
				Unzip = new byte[5];
				//UPGRADE_WARNING: Lower bound of array zipinfo was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
				zipinfo = new byte[5];
				//UPGRADE_WARNING: Lower bound of array windll was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
				windll = new byte[5];
			}
		}
		[DllImport("unzip32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

//-- This Assumes UNZIP32.DLL Is In Your \Windows\System Directory!
//UPGRADE_WARNING: Structure USERFUNCTION may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
//UPGRADE_WARNING: Structure DCLIST may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
//UPGRADE_WARNING: Structure UNZIPnames may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
//UPGRADE_WARNING: Structure UNZIPnames may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
		private static extern int Wiz_SingleEntryUnzip(int ifnc, ref UNZIPnames ifnv, int xfnc, ref UNZIPnames xfnv, ref DCLIST dcll, ref USERFUNCTION Userf);
		[DllImport("unzip32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

//UPGRADE_WARNING: Structure UZPVER may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
		private static extern void UzpVersion2(ref UZPVER uzpv);

//argv
		public struct ZIPnames
		{
			[VBFixedArray(99)]
			public string[] s;

			//UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
			public void Initialize()
			{
				s = new string[100];
			}
		}

//ZPOPT is used to set options in the zip32.dll
		private struct ZPOPT
		{
			public int fSuffix;
			public int fEncrypt;
			public int fSystem;
			public int fVolume;
			public int fExtra;
			public int fNoDirEntries;
			public int fExcludeDate;
			public int fIncludeDate;
			public int fVerbose;
			public int fQuiet;
			public int fCRLF_LF;
			public int fLF_CRLF;
			public int fJunkDir;
			public int fRecurse;
			public int fGrow;
			public int fForce;
			public int fMove;
			public int fDeleteEntries;
			public int fUpdate;
			public int fFreshen;
			public int fJunkSFX;
			public int fLatestTime;
			public int fComment;
			public int fOffsets;
			public int fPrivilege;
			public int fEncryption;
			public int fRepair;
			public byte flevel;
			//UPGRADE_NOTE: date was upgraded to date_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
				// 8 bytes long
			public string date_Renamed;
				// up to 256 bytes long
			public string szRootDir;
		}

		private struct ZIPUSERFUNCTIONS
		{
			public int DLLPrnt;
			public int DLLPASSWORD;
			public int DLLCOMMENT;
			public int DLLSERVICE;
		}

//Structure ZCL - not used by VB
//Private Type ZCL
//    argc As Long            'number of files
//    filename As String      'Name of the Zip file
//    fileArray As ZIPnames   'The array of filenames
//End Type

// Call back "string" (sic)
		public struct CBChar
		{
			[VBFixedArray(4096)]

			public byte[] ch;
			//UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
			public void Initialize()
			{
				ch = new byte[4097];
			}
		}
		[DllImport("zip32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

//Local declares

// Dim MYZCL As ZCL


//This assumes zip32.dll is in your \windows\system directory!
//UPGRADE_WARNING: Structure ZIPUSERFUNCTIONS may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
		private static extern int ZpInit(ref ZIPUSERFUNCTIONS Zipfun);
		[DllImport("zip32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		// Set Zip Callbacks

//UPGRADE_WARNING: Structure ZPOPT may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
		private static extern int ZpSetOptions(ref ZPOPT Opts);
		[DllImport("zip32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		// Set Zip options

		private static extern ZPOPT ZpGetOptions();
		[DllImport("zip32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		// used to check encryption flag only

//UPGRADE_WARNING: Structure ZIPnames may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
		private static extern int ZpArchive(int argc, string funame, ref ZIPnames argv);
		[DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		// Real zipping action
		private static extern void Sleep(int dwMilliseconds);

		private static short uZipNumber;
		private static string uZipMessage;
		private static string uZipInfo;
		private static short uVBSkip;
		public static string msOutput;


// Puts a function pointer in a structure
		public static int FnPtr(int lp)
		{
			return lp;
		}

// Callback for zip32.dll
		public static int DLLPrnt(ref CBChar fname, int x)
		{
			string s0 = null;
			int xx = 0;
			string sVbZipInf = null;

			// always put this in callback routines!
			 // ERROR: Not supported in C#: OnErrorStatement

			s0 = "";
			for (xx = 0; xx <= x; xx++) {
				if (fname.ch[xx] == 0)
					xx = 99999;
				else
					s0 = s0 + Strings.Chr(fname.ch[xx]);
			}

			Debug.Print(sVbZipInf + s0);
			msOutput = msOutput + s0;

			sVbZipInf = "";

			System.Windows.Forms.Application.DoEvents();
			return 0;

		}

// Callback for Zip32.dll ?
		public static short DllServ(ref CBChar fname, int x)
		{

			string s0 = null;
			int xx = 0;

			 // ERROR: Not supported in C#: OnErrorStatement


			s0 = "";

			for (xx = 0; xx <= x - 1; xx++) {
				if (fname.ch[xx] == 0)
					break; // TODO: might not be correct. Was : Exit For
				s0 = s0 + Strings.Chr(fname.ch[xx]);
			}

			return 0;
		}

// Callback for zip32.dll
		public static short DllPass(ref byte s1, ref int x, ref byte s2, ref byte s3)
		{

			// always put this in callback routines!
			 // ERROR: Not supported in C#: OnErrorStatement

			// not supported - always return 1
			return 1;
		}

// Callback for zip32.dll
		public static CBChar DllComm(ref CBChar s1)
		{

			// always put this in callback routines!
			 // ERROR: Not supported in C#: OnErrorStatement

			// not supported always return \0
			s1.ch[0] = Convert.ToByte(Constants.vbNullString);
			//UPGRADE_WARNING: Couldn't resolve default property of object DllComm. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			return s1;
		}

		//Main Subroutine
		public static int VBZip(ref short argc, ref string zipname, ref ZIPnames mynames, ref short junk, ref short recurse, ref short updat, ref short freshen, ref string basename, ref short Encrypt = 0, ref short IncludeSystem = 0,
		ref short IgnoreDirectoryEntries = 0, ref short Verbose = 0, ref short Quiet = 0, ref short CRLFtoLF = 0, ref short LFtoCRLF = 0, ref short Grow = 0, ref short Force = 0, ref short iMove = 0, ref short DeleteEntries = 0)
		{

			int hmem = 0;
			short xx = 0;
			int retcode = 0;
			ZIPUSERFUNCTIONS MYUSER = default(ZIPUSERFUNCTIONS);
			ZPOPT MYOPT = default(ZPOPT);

			 // ERROR: Not supported in C#: OnErrorStatement

			// nothing will go wrong :-)

			msOutput = "";

			// Set address of callback functions
			//UPGRADE_WARNING: Add a delegate for AddressOf DLLPrnt Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"'
			//MYUSER.DLLPrnt = FnPtr(AddressOf DLLPrnt)
			//UPGRADE_WARNING: Add a delegate for AddressOf DllPass Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"'
			//MYUSER.DLLPASSWORD = FnPtr(AddressOf DllPass)
			//UPGRADE_WARNING: Add a delegate for AddressOf DllComm Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"'
			//MYUSER.DLLCOMMENT = FnPtr(AddressOf DllComm)
			MYUSER.DLLSERVICE = 0;
			// not coded yet :-)
			//    retcode = ZpInit(MYUSER)

			// Set zip options
			MYOPT.fSuffix = 0;
			// include suffixes (not yet implemented)
			MYOPT.fEncrypt = Encrypt;
			// 1 if encryption wanted
			MYOPT.fSystem = IncludeSystem;
			// 1 to include system/hidden files
			MYOPT.fVolume = 0;
			// 1 if storing volume label
			MYOPT.fExtra = 0;
			// 1 if including extra attributes
			MYOPT.fNoDirEntries = IgnoreDirectoryEntries;
			// 1 if ignoring directory entries
			MYOPT.fExcludeDate = 0;
			// 1 if excluding files earlier than a specified date
			MYOPT.fIncludeDate = 0;
			// 1 if including files earlier than a specified date
			MYOPT.fVerbose = Verbose;
			// 1 if full messages wanted
			MYOPT.fQuiet = Quiet;
			// 1 if minimum messages wanted
			MYOPT.fCRLF_LF = CRLFtoLF;
			// 1 if translate CR/LF to LF
			MYOPT.fLF_CRLF = LFtoCRLF;
			// 1 if translate LF to CR/LF
			MYOPT.fJunkDir = junk;
			// 1 if junking directory names
			MYOPT.fRecurse = recurse;
			// 1 if recursing into subdirectories
			MYOPT.fGrow = Grow;
			// 1 if allow appending to zip file
			MYOPT.fForce = Force;
			// 1 if making entries using DOS names
			MYOPT.fMove = iMove;
			// 1 if deleting files added or updated
			MYOPT.fDeleteEntries = DeleteEntries;
			// 1 if files passed have to be deleted
			MYOPT.fUpdate = updat;
			// 1 if updating zip file--overwrite only if newer
			MYOPT.fFreshen = freshen;
			// 1 if freshening zip file--overwrite only
			MYOPT.fJunkSFX = 0;
			// 1 if junking sfx prefix
			MYOPT.fLatestTime = 0;
			// 1 if setting zip file time to time of latest file in archive
			MYOPT.fComment = 0;
			// 1 if putting comment in zip file
			MYOPT.fOffsets = 0;
			// 1 if updating archive offsets for sfx Files
			MYOPT.fPrivilege = 0;
			// 1 if not saving privelages
			MYOPT.fEncryption = 0;
			//Read only property!
			MYOPT.fRepair = 0;
			// 1=> fix archive, 2=> try harder to fix
			MYOPT.flevel = 0;
			// compression level - should be 0!!!
			MYOPT.date_Renamed = Constants.vbNullString;
			// "12/31/79"? US Date?
			MYOPT.szRootDir = Strings.UCase(basename);

			retcode = ZpInit(ref MYUSER);
			// Set options
			retcode = ZpSetOptions(ref MYOPT);

			// ZCL not needed in VB
			// MYZCL.argc = 2
			// MYZCL.filename = "c:\wiz\new.zip"
			// MYZCL.fileArray = MYNAMES

			// Go for it!

			retcode = ZpArchive(argc, zipname, ref mynames);

			return retcode;
		}



		//-- Callback For UNZIP32.DLL - Receive Message Function
		public static void UZReceiveDLLMessage(int ucsize, int csiz, short cfactor, short mo, short dy, short yr, short hh, short mm, byte c, ref UNZIPCBCh fname,

		ref UNZIPCBCh meth, int crc, byte fCrypt)
		{
			string s0 = null;
			int xx = 0;
			string strout = null;

			//-- Always Put This In Callback Routines!
			 // ERROR: Not supported in C#: OnErrorStatement


			//------------------------------------------------
			//-- This Is Where The Received Messages Are
			//-- Printed Out And Displayed.
			//-- You Can Modify Below!
			//------------------------------------------------

			strout = Strings.Space(80);

			//-- For Zip Message Printing
			if (uZipNumber == 0) {
				Strings.Mid(strout, 1, 50) = "Filename:";
				Strings.Mid(strout, 53, 4) = "Size";
				Strings.Mid(strout, 62, 4) = "Date";
				Strings.Mid(strout, 71, 4) = "Time";
				uZipMessage = strout + Constants.vbNewLine;
				strout = Strings.Space(80);
			}

			s0 = "";

			//-- Do Not Change This For Next!!!
			for (xx = 0; xx <= 255; xx++) {
				if (fname.ch[xx] == 0)
					break; // TODO: might not be correct. Was : Exit For
				s0 = s0 + Strings.Chr(fname.ch[xx]);
			}

			//-- Assign Zip Information For Printing
			Strings.Mid(strout, 1, 50) = Strings.Mid(s0, 1, 50);
			Strings.Mid(strout, 51, 7) = Strings.Right("        " + Conversion.Str(ucsize), 7);
			Strings.Mid(strout, 60, 3) = Strings.Right("0" + Strings.Trim(Conversion.Str(mo)), 2) + "/";
			Strings.Mid(strout, 63, 3) = Strings.Right("0" + Strings.Trim(Conversion.Str(dy)), 2) + "/";
			Strings.Mid(strout, 66, 2) = Strings.Right("0" + Strings.Trim(Conversion.Str(yr)), 2);
			Strings.Mid(strout, 70, 3) = Strings.Right(Conversion.Str(hh), 2) + ":";
			Strings.Mid(strout, 73, 2) = Strings.Right("0" + Strings.Trim(Conversion.Str(mm)), 2);

			// Mid(strout, 75, 2) = Right(" " & Str(cfactor), 2)
			// Mid(strout, 78, 8) = Right("        " & Str(csiz), 8)
			// s0 = ""
			// For xx = 0 To 255
			//     If meth.ch(xx) = 0 Then exit for
			//     s0 = s0 & Chr(meth.ch(xx))
			// Next xx

			//-- Do Not Modify Below!!!
			uZipMessage = uZipMessage + strout + Constants.vbNewLine;
			uZipNumber = uZipNumber + 1;

		}

		//-- Callback For UNZIP32.DLL - Print Message Function
		public static int UZDLLPrnt(ref UNZIPCBChar fname, int x)
		{

			string s0 = null;
			int xx = 0;

			//-- Always Put This In Callback Routines!
			 // ERROR: Not supported in C#: OnErrorStatement


			s0 = "";

			//-- Gets The UNZIP32.DLL Message For Displaying.
			for (xx = 0; xx <= x - 1; xx++) {
				if (fname.ch[xx] == 0)
					break; // TODO: might not be correct. Was : Exit For
				s0 = s0 + Strings.Chr(fname.ch[xx]);
			}

			//-- Assign Zip Information
			if (Strings.Mid(s0, 1, 1) == Constants.vbLf)
				s0 = Constants.vbNewLine;
			// Damn UNIX :-)
			uZipInfo = uZipInfo + s0;

			msOutput = uZipInfo;

			return 0;

		}

		//-- Callback For UNZIP32.DLL - DLL Service Function
		public static int UZDLLServ(ref UNZIPCBChar mname, int x)
		{

			string s0 = null;
			int xx = 0;

			//-- Always Put This In Callback Routines!
			 // ERROR: Not supported in C#: OnErrorStatement


			s0 = "";
			//-- Get Zip32.DLL Message For processing
			for (xx = 0; xx <= x - 1; xx++) {
				if (mname.ch[xx] == 0)
					break; // TODO: might not be correct. Was : Exit For
				s0 = s0 + Strings.Chr(mname.ch[xx]);
			}
			// At this point, s0 contains the message passed from the DLL
			// It is up to the developer to code something useful here :)
			return 0;
			// Setting this to 1 will abort the zip!

		}

		//-- Callback For UNZIP32.DLL - Password Function
		public static short UZDLLPass(ref UNZIPCBCh p, int n, ref UNZIPCBCh m, ref UNZIPCBCh Name)
		{
			short functionReturnValue = 0;

			string prompt = null;
			short xx = 0;
			string szpassword = null;

			//-- Always Put This In Callback Routines!
			 // ERROR: Not supported in C#: OnErrorStatement


			functionReturnValue = 1;

			if (uVBSkip == 1)
				return functionReturnValue;

			//-- Get The Zip File Password
			szpassword = Interaction.InputBox("Please Enter The Password!");

			//-- No Password So Exit The Function
			if (string.IsNullOrEmpty(szpassword)) {
				uVBSkip = 1;
				return functionReturnValue;
			}

			//-- Zip File Password So Process It
			for (xx = 0; xx <= 255; xx++) {
				if (m.ch[xx] == 0) {
					break; // TODO: might not be correct. Was : Exit For
				} else {
					prompt = prompt + Strings.Chr(m.ch[xx]);
				}
			}

			for (xx = 0; xx <= n - 1; xx++) {
				p.ch[xx] = 0;
			}

			for (xx = 0; xx <= Strings.Len(szpassword) - 1; xx++) {
				p.ch[xx] = Strings.Asc(Strings.Mid(szpassword, xx + 1, 1));
			}

			p.ch[xx] = Convert.ToByte(Strings.AscW(0));
			// Put Null Terminator For C

			functionReturnValue = 0;
			return functionReturnValue;

		}

		//-- Callback For UNZIP32.DLL - Report Function To Overwrite Files.
		//-- This Function Will Display A MsgBox Asking The User
		//-- If They Would Like To Overwrite The Files.
		public static int UZDLLRep(ref UNZIPCBChar fname)
		{
			int functionReturnValue = 0;

			string s0 = null;
			int xx = 0;

			//-- Always Put This In Callback Routines!
			 // ERROR: Not supported in C#: OnErrorStatement


			functionReturnValue = 100;
			// 100 = Do Not Overwrite - Keep Asking User
			s0 = "";

			for (xx = 0; xx <= 255; xx++) {
				if (fname.ch[xx] == 0)
					xx = 99999;
				else
					s0 = s0 + Strings.Chr(fname.ch[xx]);
			}

			//-- This Is The MsgBox Code
			xx = Interaction.MsgBox("Overwrite " + s0 + "?", Convert.ToDouble(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNoCancel), "VBUnZip32 - File Already Exists!");

			if (xx == MsgBoxResult.No)
				return functionReturnValue;

			if (xx == MsgBoxResult.Cancel) {
				functionReturnValue = 104;
				return functionReturnValue;
				// 104 = Overwrite None
			}

			functionReturnValue = 102;
			return functionReturnValue;
			// 102 = Overwrite 103 = Overwrite All

		}

		//-- ASCIIZ To String Function
		public static string szTrim(ref string szString)
		{
			string functionReturnValue = null;

			short pos = 0;
			short ln = 0;

			pos = Strings.InStr(szString, Strings.Chr(0));
			ln = Strings.Len(szString);

			switch (pos) {
				case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
1:
					functionReturnValue = Strings.Trim(Strings.Left(szString, pos - 1));
					break;
				case 1:
					functionReturnValue = "";
					break;
				default:
					functionReturnValue = Strings.Trim(szString);
					break;
			}
			return functionReturnValue;

		}


		public static int VBUnzip(ref object sZipFileName, ref string sUnzipDirectory, ref short iExtractNewer, ref short iSpaceUnderScore, ref short iPromptOverwrite, ref short iQuiet, ref short iWriteStdOut, ref short iTestZip, ref short iExtractList, ref short iExtractOnlyNewer,
		ref short iDisplayComment, ref short iHonorDirectories, ref short iOverwriteFiles, ref short iConvertCR_CRLF, ref short iVerbose, ref short iCaseSensitivty, ref short iPrivilege)
		{
			int functionReturnValue = 0;


			 // ERROR: Not supported in C#: OnErrorStatement



			int lRet = 0;

			DCLIST UZDCL = default(DCLIST);
			USERFUNCTION UZUSER = default(USERFUNCTION);
			//UPGRADE_WARNING: Arrays in structure UZVER may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
			UZPVER UZVER = default(UZPVER);
			//UPGRADE_WARNING: Arrays in structure uExcludeNames may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
			UNZIPnames uExcludeNames = default(UNZIPnames);
			//UPGRADE_WARNING: Arrays in structure uZipNames may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
			UNZIPnames uZipNames = default(UNZIPnames);

			msOutput = "";

			uExcludeNames.uzFiles[0] = Constants.vbNullString;
			uZipNames.uzFiles[0] = Constants.vbNullString;

			uZipNumber = 0;
			uZipMessage = Constants.vbNullString;
			uZipInfo = Constants.vbNullString;
			uVBSkip = 0;

			var _with1 = UZDCL;
			_with1.ExtractOnlyNewer = iExtractOnlyNewer;
			_with1.SpaceToUnderScore = iSpaceUnderScore;
			_with1.PromptToOverwrite = iPromptOverwrite;
			_with1.fQuiet = iQuiet;
			_with1.ncflag = iWriteStdOut;
			_with1.ntflag = iTestZip;
			_with1.nvflag = iExtractList;
			_with1.nUflag = iExtractNewer;
			_with1.nzflag = iDisplayComment;
			_with1.ndflag = iHonorDirectories;
			_with1.noflag = iOverwriteFiles;
			_with1.naflag = iConvertCR_CRLF;
			_with1.nZIflag = iVerbose;
			_with1.C_flag = iCaseSensitivty;
			_with1.fPrivilege = iPrivilege;
			//UPGRADE_WARNING: Couldn't resolve default property of object sZipFileName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			_with1.Zip = sZipFileName;
			_with1.ExtractDir = sUnzipDirectory;

			var _with2 = UZUSER;
			//UPGRADE_WARNING: Add a delegate for AddressOf UZDLLPrnt Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"'
			//.UZDLLPrnt = FnPtr(AddressOf UZDLLPrnt)
			_with2.UZDLLSND = 0;
			//UPGRADE_WARNING: Add a delegate for AddressOf UZDLLRep Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"'
			//.UZDLLREPLACE = FnPtr(AddressOf UZDLLRep)
			//UPGRADE_WARNING: Add a delegate for AddressOf UZDLLPass Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"'
			//.UZDLLPASSWORD = FnPtr(AddressOf UZDLLPass)
			//UPGRADE_WARNING: Add a delegate for AddressOf UZReceiveDLLMessage Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"'
			//.UZDLLMESSAGE = FnPtr(AddressOf UZReceiveDLLMessage)
			//UPGRADE_WARNING: Add a delegate for AddressOf UZDLLServ Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"'
			//.UZDLLSERVICE = FnPtr(AddressOf UZDLLServ)

			var _with3 = UZVER;
			_with3.structlen = Strings.Len(UZVER);
			_with3.beta = Strings.Space(9) + Constants.vbNullChar;
			_with3.date_Renamed = Strings.Space(19) + Constants.vbNullChar;
			_with3.zlib = Strings.Space(9) + Constants.vbNullChar;

			UzpVersion2(ref UZVER);

			lRet = Wiz_SingleEntryUnzip(0, ref uZipNames, 0, ref uExcludeNames, ref UZDCL, ref UZUSER);
			functionReturnValue = lRet;
			return functionReturnValue;
			vbErrorHandler:



			Err().Raise(Err().Number, "CodeModule::VBUnzip", Err().Description);
			return functionReturnValue;

		}
	}
}
