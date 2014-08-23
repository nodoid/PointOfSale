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
 // ERROR: Not supported in C#: OptionDeclaration
namespace _4PosBackOffice.NET
{
	internal class CGUnzipFiles
	{
//
// UnZip Class
//
// Chris Eastwood July 1999
//
		public enum ZMessageLevel
		{
			All = 0,
			Less = 1,
			NoMessages = 2
		}
		public enum ZExtractType
		{
			Extract = 0,
			ListContents = 1
		}
		public enum ZPrivilege
		{
			Ignore = 0,
			ACL = 1,
			Privileges = 2
		}

			// 1 = Extract Only Newer, Else 0
		private short miExtractNewer;
			// 1 = Convert Space To Underscore, Else 0
		private short miSpaceUnderScore;
			// 1 = Prompt To Overwrite Required, Else 0
		private short miPromptOverwrite;
			// 2 = No Messages, 1 = Less, 0 = All
		private ZMessageLevel miQuiet;
			// 1 = Write To Stdout, Else 0
		private short miWriteStdOut;
			// 1 = Test Zip File, Else 0
		private short miTestZip;
			// 0 = Extract, 1 = List Contents
		private ZExtractType miExtractList;
			// 1 = Extract Only Newer, Else 0
		private short miExtractOnlyNewer;
			// 1 = Display Zip File Comment, Else 0
		private short miDisplayComment;
			// 1 = Honor Directories, Else 0
		private short miHonorDirectories;
			// 1 = Overwrite Files, Else 0
		private short miOverWriteFiles;
			// 1 = Convert CR To CRLF, Else 0
		private short miConvertCR_CRLF;
			// 1 = Zip Info Verbose
		private short miVerbose;
			// 1 = Case Insensitivity, 0 = Case Sensitivity
		private short miCaseSensitivity;
			// 1 = ACL, 2 = Privileges, Else 0
		private ZPrivilege miPrivilege;
			// The Zip File Name
		private string msZipFileName;
			// Extraction Directory, Null If Current Directory
		private string msExtractDir;


		public bool ExtractNewer {
			get { return miExtractNewer == 1; }
			set { miExtractNewer = (value ? 1 : 0); }
		}


		public bool SpaceToUnderScore {
			get { return miSpaceUnderScore == 1; }
			set { miSpaceUnderScore = (value ? 1 : 0); }
		}


		public bool PromptOverwrite {
			get { return miPromptOverwrite == 1; }
			set { miPromptOverwrite = (value ? 1 : 0); }
		}


		public ZMessageLevel MessageLevel {
			get { return miQuiet; }
			set { miQuiet = value; }
		}


		public bool WriteToStdOut {
			get { return miWriteStdOut == 1; }
			set { miWriteStdOut = (value ? 1 : 0); }
		}


		public bool TestZip {
			get { return miTestZip == 1; }
			set { miTestZip = (value ? 1 : 0); }
		}


		public ZExtractType ExtractList {
			get { return miExtractList; }
			set { miExtractList = value; }
		}


		public bool ExtractOnlyNewer {
			get { return miExtractOnlyNewer == 1; }
			set { miExtractOnlyNewer = (value ? 1 : 0); }
		}


		public bool DisplayComment {
			get { return miDisplayComment == 1; }
			set { miDisplayComment = (value ? 1 : 0); }
		}


		public bool HonorDirectories {
			get { return miHonorDirectories == 1; }
			set { miHonorDirectories = (value ? 1 : 0); }
		}


		public bool OverWriteFiles {
			get { return miOverWriteFiles == 1; }
			set { miOverWriteFiles = (value ? 1 : 0); }
		}


		public bool ConvertCRtoCRLF {
			get { return miConvertCR_CRLF == 1; }
			set { miConvertCR_CRLF = (value ? 1 : 0); }
		}


		public bool Verbose {
			get { return miVerbose == 1; }
			set { miVerbose = (value ? 1 : 0); }
		}


		public bool CaseSensitive {
			get { return miCaseSensitivity == 1; }
			set { miCaseSensitivity = (value ? 1 : 0); }
		}


		public ZPrivilege Privilege {
			get { return miPrivilege; }
			set { miPrivilege = value; }
		}


		public string ZipFileName {
			get { return msZipFileName; }
			set { msZipFileName = value; }
		}


		public string ExtractDir {
			get { return msExtractDir; }
			set { msExtractDir = value; }
		}

		public int Unzip(ref string sZipFileName = "", ref string sExtractDir = "")
		{
			int functionReturnValue = 0;

			 // ERROR: Not supported in C#: OnErrorStatement


			int lRet = 0;

			if (Strings.Len(sZipFileName) > 0) {
				msZipFileName = sZipFileName;
			}

			if (Strings.Len(sExtractDir) > 0) {
				msExtractDir = sExtractDir;
			}


			lRet = CodeModule.VBUnzip(ref msZipFileName, ref msExtractDir, ref miExtractNewer, ref miSpaceUnderScore, ref miPromptOverwrite, ref Convert.ToInt16(miQuiet), ref miWriteStdOut, ref miTestZip, ref Convert.ToInt16(miExtractList), ref miExtractOnlyNewer,
			ref miDisplayComment, ref miHonorDirectories, ref miOverWriteFiles, ref miConvertCR_CRLF, ref miVerbose, ref miCaseSensitivity, ref Convert.ToInt16(miPrivilege));

			functionReturnValue = lRet;
			return functionReturnValue;
			vbErrorHandler:


			Err().Raise(Err().Number, "CGUnZipFiles::Unzip", Err().Description);
			return functionReturnValue;

		}

//UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private void Class_Initialize_Renamed()
		{
			miExtractNewer = 0;
			miSpaceUnderScore = 0;
			miPromptOverwrite = 0;
			miQuiet = ZMessageLevel.NoMessages;
			miWriteStdOut = 0;
			miTestZip = 0;
			miExtractList = ZExtractType.Extract;
			miExtractOnlyNewer = 0;
			miDisplayComment = 0;
			miHonorDirectories = 1;
			miOverWriteFiles = 1;
			miConvertCR_CRLF = 0;
			miVerbose = 0;
			miCaseSensitivity = 1;
			miPrivilege = ZPrivilege.Ignore;
		}
		public CGUnzipFiles() : base()
		{
			Class_Initialize_Renamed();
		}

		public string GetLastMessage()
		{
			return CodeModule.msOutput;
		}
	}
}
