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
	static class SaveArrayAsCSVFile
	{

			//Double
		public static string[,] dChrom;


// SaveAsCSV saves an array as csv file. Choosing a delimiter different as a comma, is optional.
//
// Syntax:
// SaveAsCSV dMyArray, sMyFileName, [sMyDelimiter]
//
// Examples:
// SaveAsCSV dChrom, app.path & "\Demo.csv"       --> comma as delimiter
// SaveAsCSV dChrom, app.path & "\Demo.csv", ";"  --> semicolon as delimiter
//
// written by Baber Abbass
// baber_abbass@hotmail.com



		public static void SaveAsCSV(ref string[,] MyArray, ref string sFileName, ref string sDelimiter = ",")
		{
			int n = 0;
			//counter
			int M = 0;
			//counter
			string sCSV = null;
			//csv string to print

			 // ERROR: Not supported in C#: OnErrorStatement



			//check extension and correct if needed
			if (Strings.InStr(sFileName, ".csv") == 0) {
				sFileName = sFileName + ".csv";
			} else {
				while ((Strings.Len(sFileName) - Strings.InStr(sFileName, ".csv")) > 3) {
					sFileName = Strings.Left(sFileName, Strings.Len(sFileName) - 1);
				}
			}

			//If MultiDimensional(MyArray) = False Then '1 dimension

			//save the file
			//        FileOpen(7, sFileName, OpenMode.Output)
			//        For n = 0 To UBound(MyArray, 1)
			//PrintLine(7, MyArray(n, 0)) 'Format( MyArray(n, 0), "0.000000E+00")
			//Next n
			//FileClose(7)

			//        Else 'more dimensional

			//save the file
			FileSystem.FileOpen(7, sFileName, OpenMode.Output);
			for (n = 0; n <= Information.UBound(MyArray, 1); n++) {
				sCSV = "";
				for (M = 0; M <= Information.UBound(MyArray, 2); M++) {
					sCSV = sCSV + MyArray[n, M] + sDelimiter;
					//Format(MyArray(n, M), "0.000000E+00") & sDelimiter
				}
				sCSV = Strings.Left(sCSV, Strings.Len(sCSV) - 1);
				//remove last Delimiter
				FileSystem.PrintLine(7, sCSV);
			}
			FileSystem.FileClose(7);

			//End If

			return;
			ErrHandler_SaveAsCSV:


			FileSystem.FileClose(7);
		}

// Function ImportCSVinArray imports a csv file into an array. Choosing a delimiter different as a comma, is optional.
//
// Syntax:
// dMyArray() = ImportCSVinArray (sMyFileName, [sMyDelimiter])
//
// Examples:
// dChrom() = ImportCSVinArray("c:\temp\demo.csv")       --> comma as delimiter
// dChrom() = ImportCSVinArray("c:\temp\demo.csv",";")   --> semicolon as delimiter
//
//
// written by Baber Abbass
// baber_abbass@hotmail.com

		public static double[] ImportCSVinArray(ref string sFileName, ref string sDelimiter = ",")
		{
			double[] functionReturnValue = null;

			double[] MyArray = null;
			double[,] MyOArray = null;
			string[] sSplit = null;
			string sLine = null;
			int lRows = 0;
			int lColumns = 0;
			int lCounter = 0;

			 // ERROR: Not supported in C#: OnErrorStatement


			//UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			if (!string.IsNullOrEmpty(FileSystem.Dir(sFileName))) {
				//determine number of rows and columns needed
				lRows = 0;
				lColumns = 0;
				FileSystem.FileOpen(7, sFileName, OpenMode.Input);
				while (!(FileSystem.EOF(7))) {
					sLine = FileSystem.LineInput(7);
					if (Strings.Len(sLine) > 0) {
						sSplit = Strings.Split(sLine, sDelimiter);
						if (Information.UBound(sSplit) > lColumns)
							lColumns = Information.UBound(sSplit);
						lRows = lRows + 1;
					}
				}
				FileSystem.FileClose(7);


				//fill array
				//no csv file!
				if (lColumns == 1) {

					MyArray = new double[lRows];

					FileSystem.FileOpen(7, sFileName, OpenMode.Input);
					lRows = 0;
					while (!(FileSystem.EOF(7))) {
						sLine = FileSystem.LineInput(7);
						if (Strings.Len(sLine) > 0) {
							MyArray[lRows] = Conversion.Val(sLine);
							lRows = lRows + 1;
						}
					}
					FileSystem.FileClose(7);


				//multidimensional csv file
				} else if (lColumns > 1) {

					MyOArray = new double[lRows, lColumns + 1];

					FileSystem.FileOpen(7, sFileName, OpenMode.Input);
					lRows = 0;
					while (!(FileSystem.EOF(7))) {
						sLine = FileSystem.LineInput(7);
						if (Strings.Len(sLine) > 0) {
							sSplit = Strings.Split(sLine, sDelimiter);
							for (lCounter = 0; lCounter <= Information.UBound(sSplit); lCounter++) {
								MyOArray[lRows, lCounter] = Conversion.Val(sSplit[lCounter]);
							}
							lRows = lRows + 1;
						}
					}
					FileSystem.FileClose(7);

				}

				//return function
				functionReturnValue = MyArray.Clone();
			}
			return functionReturnValue;
			ErrHandler_ImportCSVinArray:
			return functionReturnValue;



		}

		private static bool MultiDimensional(ref string[] CheckArray)
		{
			bool functionReturnValue = false;

			 // ERROR: Not supported in C#: OnErrorStatement


			if (Information.UBound(CheckArray, 2) > 0) {
				functionReturnValue = true;
				//more than 1 dimension
			}
			return functionReturnValue;
			ErrHandler_MultiDimensional:

			functionReturnValue = false;
			return functionReturnValue;
			//1 dimension
		}
	}
}
