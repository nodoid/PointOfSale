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
	internal class CGZipFiles
	{
//
//
// Chris Eastwood July 1999 - adapted from code at the
// InfoZip homepage.
//
		public enum ZTranslate
		{
			CRLFtoLF = 1,
			LFtoCRLF = 2
		}
//
// Collection of Files to Zip
//
		private Collection mCollection;
//
// Recurse Folders ?
//
		private short miRecurseFolders;
//
// Zip File Name
//
		private string msZipFileName;
//
// Encryption ?
//
		private short miEncrypt;
//
// System Files
//
		private short miSystem;
//
// Root Directory
//
		private string msRootDirectory;
//
// Verbose Zip
//
		private short miVerbose;
//
// Quiet Zip
//
		private short miQuiet;
//
// Translate CRLF / LF Chars
//
		private ZTranslate miTranslateCRLF;
//
// Updating Existing Zip ?
//
		private short miUpdateZip;

//UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private void Class_Initialize_Renamed()
		{
			//
			// Initialise the collection
			//
			mCollection = new Collection();
			//
			// We have to add in a dummy file into the collection because
			// the Zip routines fall over otherwise.
			//
			// I think this is a bug, but it's not documented anywhere
			// on the InfoZip website.
			//
			// The Zip process *always* fails on the first file,
			// regardless of whether it's a valid file or not!
			//
			mCollection.Add("querty", "querty");
			miEncrypt = 0;
			miSystem = 0;
			msRootDirectory = "\\";
			miQuiet = 0;
			miUpdateZip = 0;

		}
		public CGZipFiles() : base()
		{
			Class_Initialize_Renamed();
		}

//UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private void Class_Terminate_Renamed()
		{
			//
			// Terminate the collection
			//
			//UPGRADE_NOTE: Object mCollection may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			mCollection = null;
		}
		protected override void Finalize()
		{
			Class_Terminate_Renamed();
			base.Finalize();
		}


		public bool RecurseFolders {
			get { return miRecurseFolders == 1; }
			set { miRecurseFolders = (value ? 1 : 0); }
		}


		public string ZipFileName {
			get { return msZipFileName; }
				//& vbNullChar
			set { msZipFileName = value; }
		}


		public bool Encrypted {
			get { return miEncrypt == 1; }
			set { miEncrypt = (value ? 1 : 0); }
		}


		public bool IncludeSystemFiles {
			get { return miSystem == 1; }
			set { miSystem = (value ? 1 : 0); }
		}

		public int ZipFileCount {
			get {
				int functionReturnValue = 0;
				if (mCollection == null) {
					functionReturnValue = 0;
				} else {
					functionReturnValue = mCollection.Count() - 1;
				}
				return functionReturnValue;
			}
		}



		public string RootDirectory {
			get { return msRootDirectory; }
				// & vbNullChar
			set { msRootDirectory = value; }
		}


		public bool UpdatingZip {
			get { return miUpdateZip == 1; }
			set { miUpdateZip = (value ? 1 : 0); }
		}

		public object AddFile(string sFileName)
		{
			int lCount = 0;
			string sFile = null;

			 // ERROR: Not supported in C#: OnErrorStatement


			//UPGRADE_WARNING: Couldn't resolve default property of object mCollection.Item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			sFile = mCollection[sFileName];

			if (Strings.Len(sFile) == 0) {
				Err().Clear();
				 // ERROR: Not supported in C#: OnErrorStatement

				mCollection.Add(sFileName, sFileName);
			} else {
				 // ERROR: Not supported in C#: OnErrorStatement

				Err().Raise(Constants.vbObjectError + 2001, "CGZip::AddFile", "File is already in Zip List");
			}

		}

		public object RemoveFile(string sFileName)
		{
			int lCount = 0;
			string sFile = null;

			 // ERROR: Not supported in C#: OnErrorStatement


			//UPGRADE_WARNING: Couldn't resolve default property of object mCollection.Item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			sFile = mCollection[sFileName];

			if (Strings.Len(sFile) == 0) {
				Err().Raise(Constants.vbObjectError + 2002, "CGZip::RemoveFile", "File is not in Zip List");
			} else {
				mCollection.Remove(sFileName);
			}

		}

		public int MakeZipFile()
		{
			int functionReturnValue = 0;
			//UPGRADE_WARNING: Arrays in structure zFileArray may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
			ZIPnames zFileArray = default(ZIPnames);
			object sFileName = null;
			int lFileCount = 0;
			short iIgnorePath = 0;
			short iRecurse = 0;

			 // ERROR: Not supported in C#: OnErrorStatement




			lFileCount = 0;

			foreach (object sFileName_loopVariable in mCollection) {
				sFileName = sFileName_loopVariable;
				//UPGRADE_WARNING: Couldn't resolve default property of object sFileName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				zFileArray.s(lFileCount) = sFileName;
				lFileCount = lFileCount + 1;
			}


			functionReturnValue = CodeModule.VBZip(Convert.ToInt16(lFileCount), msZipFileName, zFileArray, iIgnorePath, miRecurseFolders, miUpdateZip, 0, msRootDirectory);
			return functionReturnValue;
			vbErrorHandler:



			functionReturnValue = -99;
			Err().Raise(Err().Number, "CGZipFiles::MakeZipFile", Err().Description);
			return functionReturnValue;

		}

		public string GetLastMessage()
		{
			return CodeModule.msOutput;
		}
	}
}
