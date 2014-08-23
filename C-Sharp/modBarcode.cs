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
using Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6;
namespace _4PosBackOffice.NET
{
	static class modBarcode
	{
		public static int twipsToMM;
		public static string gLabelName;
		public static int gLabelColumns;
		public static int gLabelLeft;
		public static int gLabelHeight;
		public static int gLabelWidth;
		public static string doImage(ref object code, ref object size)
		{
			string lXML = null;
			string lCode = null;
			short i = 0;
			for (i = 1; i <= Strings.Len(code); i++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lCode = Strings.Left(code, i);
				lCode = Strings.Right(lCode, 1);
				if (lCode == "0") {
					lXML = lXML + System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White) + "~";
				} else {
					lXML = lXML + System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black) + "~";
				}
				if ((size)) {
					lXML = lXML + 30 + "|";
				} else {
					lXML = lXML + 25 + "|";
				}
			}
			return lXML;
		}

		private static object doCheckSum(ref object value)
		{
			object functionReturnValue = null;
			short lAmount = 0;
			string code = null;
			short i = 0;
			//UPGRADE_WARNING: Couldn't resolve default property of object value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (Strings.InStr(value, ".")) {
				//UPGRADE_WARNING: Couldn't resolve default property of object doCheckSum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				functionReturnValue = false;
			} else {
				if (Information.IsNumeric(value)) {
					lAmount = 0;
					for (i = 1; i <= Strings.Len(value) - 1; i++) {
						//UPGRADE_WARNING: Couldn't resolve default property of object value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						code = Strings.Left(value, i);
						code = Strings.Right(code, 1);
						if (i % 2) {
							lAmount = lAmount + Convert.ToInt16(code);
						} else {
							lAmount = lAmount + Convert.ToInt16(code) * 3;
						}
					}
					lAmount = 10 - (lAmount % 10);
					if (lAmount == 10)
						lAmount = 0;
					//UPGRADE_WARNING: Couldn't resolve default property of object value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object doCheckSum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					functionReturnValue = lAmount == Convert.ToInt16(Strings.Right(value, 1));
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object doCheckSum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					functionReturnValue = false;
				}
			}
			return functionReturnValue;
		}



		public static void printBarcode(ref object barcodePicture, ref object lHeading, ref object lValue, ref object lFooter, ref int lLeft, ref int lTop, ref int lWidth, ref bool noCode = false, ref string headingMain1 = "", ref string headingMain2 = "")
		{
			string BF = null;
			Printer Printer = new Printer();
			short x = 0;
			short y = 0;
			string lXML = null;
			string lastArray = null;
			string oddArray = null;
			string evenArray = null;
			string[] parityArray = null;
			string lString = null;
			string codeType = null;
			string code = null;
			string lCode = null;
			string HeadingString1 = null;
			string HeadingString2 = null;
			short i = 0;
			short j = 0;
			short cnt = 0;
			string[] barArray = null;
			lXML = "";
			//UPGRADE_WARNING: Couldn't resolve default property of object doCheckSum(lValue). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (doCheckSum(ref lValue)) {
				//UPGRADE_WARNING: Array has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				//UPGRADE_WARNING: Couldn't resolve default property of object oddArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				oddArray = new string[] {
					"0001101",
					"0011001",
					"0010011",
					"0111101",
					"0100011",
					"0110001",
					"0101111",
					"0111011",
					"0110111",
					"0001011"
				};
				//UPGRADE_WARNING: Array has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				//UPGRADE_WARNING: Couldn't resolve default property of object evenArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				evenArray = new string[] {
					"0100111",
					"0110011",
					"0011011",
					"0100001",
					"0011101",
					"0111001",
					"0000101",
					"0010001",
					"0001001",
					"0010111"
				};
				//UPGRADE_WARNING: Array has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				//UPGRADE_WARNING: Couldn't resolve default property of object lastArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lastArray = new string[] {
					"1110010",
					"1100110",
					"1101100",
					"1000010",
					"1011100",
					"1001110",
					"1010000",
					"1000100",
					"1001000",
					"1110100"
				};
				//UPGRADE_WARNING: Array has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				//UPGRADE_WARNING: Couldn't resolve default property of object parityArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				parityArray = new string[] {
					"111111",
					"110100",
					"110010",
					"110001",
					"101100",
					"100110",
					"100011",
					"101010",
					"101001",
					"100101"
				};
				//UPGRADE_WARNING: Couldn't resolve default property of object lValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				code = Strings.Left(lValue, 1);
				//UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				code = Strings.Right(code, 1);
				//UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object parityArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object codeType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				codeType = parityArray[Convert.ToInt16(code)];

				lXML = lXML + doImage(ref "101", ref 1);
				for (i = 2; i <= 7; i++) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object lValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					code = Strings.Left(lValue, i);
					//UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					code = Strings.Right(code, 1);
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object codeType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object lCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lCode = Strings.Left(codeType, i - 1);
					//UPGRADE_WARNING: Couldn't resolve default property of object lCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lCode = Strings.Right(lCode, 1);
					//UPGRADE_WARNING: Couldn't resolve default property of object lCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (lCode == "0") {
						lXML = lXML + doImage(ref evenArray[code], ref 0);
					} else {
						lXML = lXML + doImage(ref oddArray[code], ref 0);
					}
				}
				lXML = lXML + doImage(ref "01010", ref 1);
				for (i = 8; i <= 13; i++) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object lValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					code = Strings.Left(lValue, i);
					//UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					code = Strings.Right(code, 1);
					lXML = lXML + doImage(ref lastArray[code], ref 0);
				}
				lXML = lXML + doImage(ref "101", ref 1);
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object lValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lString = lValue;
				for (i = 1; i <= Strings.Len(lString); i++) {
					//UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Convert.ToDouble(Strings.Left(lString, 1)) == 0) {
						//UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						lString = Strings.Right(lString, Strings.Len(lString) - 1);
					} else {
						break; // TODO: might not be correct. Was : Exit For
					}
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object lValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lValue = lString;

				//UPGRADE_WARNING: Array has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				//UPGRADE_WARNING: Couldn't resolve default property of object oddArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				oddArray = new string[] {
					"0",
					"1",
					"2",
					"3",
					"4",
					"5",
					"6",
					"7",
					"8",
					"9",
					"A",
					"B",
					"C",
					"D",
					"E",
					"F",
					"G",
					"H",
					"I",
					"J",
					"K",
					"L",
					"M",
					"N",
					"O",
					"P",
					"Q",
					"R",
					"S",
					"T",
					"U",
					"V",
					"W",
					"X",
					"Y",
					"Z",
					"-",
					".",
					" ",
					"$",
					"/",
					"+",
					"%",
					"~",
					","
				};
				//UPGRADE_WARNING: Array has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				//UPGRADE_WARNING: Couldn't resolve default property of object evenArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				evenArray = new string[] {
					"111331311",
					"311311113",
					"113311113",
					"313311111",
					"111331113",
					"311331111",
					"113331111",
					"111311313",
					"311311311",
					"113311311",
					"311113113",
					"113113113",
					"313113111",
					"111133113",
					"311133111",
					"113133111",
					"111113313",
					"311113311",
					"113113311",
					"111133311",
					"311111133",
					"113111133",
					"313111131",
					"111131133",
					"311131131",
					"113131131",
					"111111333",
					"311111331",
					"113111331",
					"111131331",
					"331111113",
					"133111113",
					"333111111",
					"131131113",
					"331131111",
					"133131111",
					"131111313",
					"331111311",
					"133111311",
					"131131311",
					"131313111",
					"131311131",
					"131113131",
					"111313131",
					"1311313111131131311"
				};

				//UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lString = "131131311";
				//UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lString = lString + "1";
				for (i = 1; i <= Strings.Len(lValue); i++) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object lValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					code = Strings.Left(lValue, i);
					//UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					code = Strings.Right(code, 1);
					//UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					code = Strings.UCase(code);
					for (j = 0; j <= Information.UBound(oddArray); j++) {
						//UPGRADE_WARNING: Couldn't resolve default property of object oddArray(j). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (code == oddArray[j]) {
							//UPGRADE_WARNING: Couldn't resolve default property of object evenArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lString = lString + evenArray[j];
							//UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lString = lString + "1";
							//UPGRADE_WARNING: Couldn't resolve default property of object j. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							j = 9999;
						}
					}
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lString = lString + "131131311";

				for (i = 1; i <= Strings.Len(lString); i++) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					code = Strings.Left(lString, i);
					//UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					code = Strings.Right(code, 1);
					//UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					for (j = 1; j <= Convert.ToInt16(code); j++) {
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object lCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						lCode = Strings.Left(code, i);
						//UPGRADE_WARNING: Couldn't resolve default property of object lCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						lCode = Strings.Right(lCode, 1);
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Mod has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
						if (i % 2) {
							lXML = lXML + System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black) + "~";
						} else {
							lXML = lXML + System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White) + "~";
						}
						lXML = lXML + "20|";
					}
				}
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object lHeading. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lString = lHeading;
			//UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			x = 0;
			y = 0;
			//UPGRADE_WARNING: Couldn't resolve default property of object lHeading. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object HeadingString1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			HeadingString1 = lHeading + " ";
			HeadingString2 = "";
			//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.TextWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if ((lWidth - barcodePicture.TextWidth(lHeading)) < 0) {
				for (x = Strings.Len(lHeading) + 1; x >= 1; x += -1) {
					//UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object lHeading. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object HeadingString1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					HeadingString1 = Strings.Left(lHeading, x);
					//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.TextWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if ((lWidth - barcodePicture.TextWidth(HeadingString1) + 50) > 0) {
						for (y = Strings.Len(HeadingString1) + 1; y >= 1; y += -1) {
							//UPGRADE_WARNING: Couldn't resolve default property of object HeadingString1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							if (Strings.Right(Strings.Left(HeadingString1, y), 1) == " ") {

								//UPGRADE_WARNING: Couldn't resolve default property of object HeadingString1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								HeadingString1 = Strings.Left(HeadingString1, y - 1);
								//UPGRADE_WARNING: Couldn't resolve default property of object HeadingString1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								//UPGRADE_WARNING: Couldn't resolve default property of object lHeading. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								if ((lHeading != HeadingString1)) {
									//UPGRADE_WARNING: Couldn't resolve default property of object lHeading. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
									HeadingString2 = Strings.Right(lHeading, Strings.Len(lHeading) - Strings.Len(HeadingString1));
								}
								break; // TODO: might not be correct. Was : Exit For
							}
						}
						break; // TODO: might not be correct. Was : Exit For
					}
				}
			}
			if (string.IsNullOrEmpty(HeadingString2)) {
				//UPGRADE_WARNING: Couldn't resolve default property of object HeadingString1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				HeadingString2 = HeadingString1;
				//UPGRADE_WARNING: Couldn't resolve default property of object HeadingString1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				HeadingString1 = "";
			} else {
				while (!(Printer.TextWidth(HeadingString2) <= lWidth)) {
					HeadingString2 = Strings.Mid(HeadingString2, 1, Strings.Len(HeadingString2) - 1);
				}
			}

			System.Windows.Forms.Application.DoEvents();
			System.Windows.Forms.Application.DoEvents();
			y = lTop + 30;
			if (!string.IsNullOrEmpty(headingMain1)) {
				//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.FontName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				barcodePicture.FontName = "Tahoma";
				//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.FontSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				barcodePicture.FontSize = 8;
				//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.FontBold. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				barcodePicture.FontBold = true;
				//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				barcodePicture.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
				//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.TextWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.PSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//barcodePicture.PSet(New Point[](CShort(lLeft + (lWidth - barcodePicture.TextWidth(headingMain1)) / 2), y))
				//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				barcodePicture.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
				//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				barcodePicture.Print(headingMain1);
				//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.CurrentY. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				y = barcodePicture.CurrentY;
			}
			if (!string.IsNullOrEmpty(headingMain2)) {
				//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.FontName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				barcodePicture.FontName = "Tahoma";
				//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.FontSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				barcodePicture.FontSize = 8;
				//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.FontBold. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				barcodePicture.FontBold = true;
				//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				barcodePicture.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
				//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.TextWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.PSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//barcodePicture.PSet(New Point[](CShort(lLeft + (lWidth - barcodePicture.TextWidth(headingMain2)) / 2), y))
				//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				barcodePicture.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
				//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				barcodePicture.Print(headingMain2);
				//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.CurrentY. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				y = barcodePicture.CurrentY + 30;
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.FontName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			barcodePicture.FontName = "Tahoma";
			//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.FontSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			barcodePicture.FontSize = 8;
			//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.FontBold. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			barcodePicture.FontBold = true;
			//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			barcodePicture.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
			//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.TextWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.PSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//barcodePicture.PSet(New Point[](CShort(lLeft + (lWidth - barcodePicture.TextWidth(HeadingString1)) / 2), y))
			//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			barcodePicture.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
			//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			barcodePicture.Print(HeadingString1);
			//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			barcodePicture.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
			//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.CurrentY. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			y = barcodePicture.CurrentY;
			//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.TextWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.PSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//barcodePicture.PSet(New Point[](CShort(lLeft + (lWidth - barcodePicture.TextWidth(HeadingString2)) / 2), y))
			//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			barcodePicture.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
			//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			barcodePicture.Print(HeadingString2);

			//UPGRADE_WARNING: Couldn't resolve default property of object barArray. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			barArray = Strings.Split(lXML, "|");
			//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.CurrentY. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			y = barcodePicture.CurrentY;
			//UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			x = Convert.ToInt16(lLeft + (lWidth - Information.UBound(barArray) * sizeConvertors.twipsPerPixel(true)) / 2);
			for (cnt = Information.LBound(barArray); cnt <= Information.UBound(barArray); cnt++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object barArray(cnt). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (!string.IsNullOrEmpty(barArray[cnt])) {
					//UPGRADE_WARNING: Couldn't resolve default property of object barArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Convert.ToInt32(Strings.Split(barArray[cnt], "~")[0]) == System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)) {
						//UPGRADE_WARNING: Couldn't resolve default property of object barArray(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.Line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//barcodePicture.Line((x + cnt * twipsPerPixel(true), y) - (x + (cnt + 1) * twipsPerPixel(true), y + CInt(Split(barArray(cnt), "~")(1)) * twipsPerPixel(true)), CInt(Split(barArray(cnt), "~")(0)), BF)
					}
				}

			}
			//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.CurrentX. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			x = barcodePicture.CurrentX;
			//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.CurrentY. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			y = barcodePicture.CurrentY;
			if (noCode) {
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object lValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lString = lValue;
				//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				barcodePicture.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
				//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.TextWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.PSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//barcodePicture.PSet(New Point[](CShort(lLeft + (lWidth - barcodePicture.TextWidth(lString)) / 2), y))
				//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				barcodePicture.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
				//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				barcodePicture.Print(lString);
				//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.CurrentX. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				x = barcodePicture.CurrentX;
				//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.CurrentY. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				y = barcodePicture.CurrentY;
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object lFooter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lString = lFooter;
			//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			barcodePicture.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
			//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.TextWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.PSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//barcodePicture.PSet(New Point[](CShort(lLeft + (lWidth - barcodePicture.TextWidth(lString)) / 2), y))
			//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.ForeColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			barcodePicture.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
			//UPGRADE_WARNING: Couldn't resolve default property of object barcodePicture.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			barcodePicture.Print(lString);
		}


		public static bool isBarcodePrinter()
		{
			Printer Printer = new Printer();
			return Convert.ToBoolean(Strings.InStr(Strings.LCase(Printer.DeviceName), "label"));
		}



		public static void setLabelDefaults()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			//    If isBarcodePrinter = "1" Then
			//        Set rs = getRS("SELECT TOP 1 Label.* From Label Where (((Label.Label_Type) <> 0)) ORDER BY Label.Label_Name;")
			//    Else
			//        Set rs = getRS("SELECT TOP 1 Label.* From Label Where (((Label.Label_Type) = 0)) ORDER BY Label.Label_Name;")
			//    End If
			//    gLabelName = rs("Label_Name")
			//    gLabelColumns = rs("Label_Columns")
			//    gLabelLeft = rs("Label_Left")
			//    gLabelHeight = rs("Label_Height")
			//    gLabelWidth = rs("Label_Width")

		}
	}
}
