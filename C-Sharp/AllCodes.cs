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
	static class AllCodes
	{
//What you see on the computer screen isn't what you will get when you print,
//the computer screen doesn't have the same resolution as a printer, therefore
//lines might appear to "merge" on the screen.
//The values in varBar1 are the available text in a given Barcode language to be printed
//The values in varBar2 are the Barcode equivalent of the text in varBar1
//sBar is the accumulated Barcode equivalents of the text to be printed
//The Barcode() Function will print one character of sBar at a time in a loop
//To add more Barcode types, just continue to build functions that make the appropriate sBar String
		static string sBar;
		static int i0;

		static int i1;
		public static object Code39(ref string strCode)
		{
			string[] varBar1 = {
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
				"*"
			};
			string[] varBar2 = {
				"111221211",
				"211211112",
				"112211112",
				"212211111",
				"111221112",
				"211221111",
				"112221111",
				"111211212",
				"211211211",
				"112211211",
				"211112112",
				"112112112",
				"212112111",
				"111122112",
				"211122111",
				"112122111",
				"111112212",
				"211112211",
				"112112211",
				"111122211",
				"211111122",
				"112111122",
				"212111121",
				"111121122",
				"211121121",
				"112121121",
				"111111222",
				"211111221",
				"112111221",
				"111121221",
				"221111112",
				"122111112",
				"222111111",
				"121121112",
				"221121111",
				"122121111",
				"121111212",
				"221111211",
				"122111211",
				"121212111",
				"121211121",
				"121112121",
				"111212121",
				"121121211"
			};
			sBar = "121121211" + "1";
			for (i0 = 1; i0 <= Strings.Len(strCode); i0++) {
				for (i1 = 0; i1 <= Information.UBound(varBar1); i1++) {
					if (Strings.Mid(strCode, i0, 1) == varBar1[i1])
						sBar = sBar + varBar2[i1] + "1";
				}
			}
			sBar = sBar + "121121211";
			return sBar;
		}
		public static object Code128(ref string strCode)
		{
			string[] varBar1 = {
				" ",
				"!",
				Strings.Chr(34),
				"#",
				"$",
				"%",
				"&",
				"'",
				"(",
				")",
				"*",
				"+",
				",",
				"-",
				".",
				"/",
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
				":",
				";",
				"<",
				"=",
				">",
				"?",
				"@",
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
				"[",
				"\\",
				"]",
				"^",
				"_",
				",",
				"`",
				"a",
				"b",
				"c",
				"d",
				"e",
				"f",
				"g",
				"h",
				"i",
				"j",
				"k",
				"I",
				"m",
				"n",
				"o",
				"p",
				"q",
				"r",
				"s",
				"t",
				"u",
				"v",
				"w",
				"x",
				"y",
				"z",
				"{",
				"|",
				"}",
				"~",
				"DEL",
				"FNC 3",
				"FNC 2",
				"SHIFT",
				"CODE C",
				"FNC 4",
				"CODE A",
				"FNC 1",
				"Start A",
				"Start B",
				"Start C",
				"Stop"
			};

			string[] varBar2 = {
				"212222",
				"222122",
				"222221",
				"121223",
				"121322",
				"131222",
				"122213",
				"122312",
				"132212",
				"221213",
				"221312",
				"231212",
				"112232",
				"122132",
				"122231",
				"113222",
				"123122",
				"123221",
				"223211",
				"221132",
				"221231",
				"213212",
				"223112",
				"312131",
				"311222",
				"321122",
				"321221",
				"312212",
				"322112",
				"322211",
				"212123",
				"212321",
				"232121",
				"111323",
				"131123",
				"131321",
				"112313",
				"132113",
				"132311",
				"211313",
				"231113",
				"231311",
				"112133",
				"112331",
				"132131",
				"113123",
				"113321",
				"133121",
				"313121",
				"211331",
				"231131",
				"213113",
				"213311",
				"213131",
				"311123",
				"311321",
				"331121",
				"312113",
				"312311",
				"332111",
				"314111",
				"221411",
				"431111",
				"111224",
				"111422",
				"121124",
				"121421",
				"141122",
				"141221",
				"112214",
				"112412",
				"122114",
				"122411",
				"142112",
				"142211",
				"241211",
				"221114",
				"413111",
				"241112",
				"134111",
				"111242",
				"121142",
				"121241",
				"114212",
				"124112",
				"124211",
				"411212",
				"421112",
				"421211",
				"212141",
				"214121",
				"412121",
				"111143",
				"111341",
				"131141",
				"114113",
				"114311",
				"411113",
				"411311",
				"113141",
				"114131",
				"311141",
				"411131",
				"211412",
				"211214",
				"211232",
				"2331112"
			};
			float chksum = 104;
			sBar = "211214";
			for (i0 = 1; i0 <= Strings.Len(strCode); i0++) {
				for (i1 = 0; i1 <= Information.UBound(varBar1); i1++) {
					if (Strings.Mid(strCode, i0, 1) == varBar1[i1]) {
						sBar = sBar + varBar2[i1];
						chksum = chksum + (i1 * i0);
						break; // TODO: might not be correct. Was : Exit For
					}
				}
			}
			//sBar = varBar2(chksum - (Int(chksum / 103) * 103)) & "2331112"
			sBar = sBar + varBar2[chksum - (Conversion.Int(chksum / 103) * 103)] + "2331112";
			return sBar;
		}
		public static object Code25(ref string strCode)
		{
			string[] tmpHold = new string[21];
			string[] varBar1 = {
				"1",
				"2",
				"3",
				"4",
				"5",
				"6",
				"7",
				"8",
				"9",
				"0"
			};
			string[] varBar2 = {
				"3-1-1-1-3",
				"1-3-1-1-3",
				"3-3-1-1-1",
				"1-1-3-1-3",
				"3-1-3-1-1",
				"1-3-3-1-1",
				"1-1-1-3-3",
				"3-1-1-3-1",
				"1-3-1-3-1",
				"1-1-3-3-1"
			};
			string[] varBar3 = null;
			string[] varBar4 = null;
			sBar = "1111";
			for (i0 = 1; i0 <= Strings.Len(strCode); i0++) {
				for (i1 = 0; i1 <= Information.UBound(varBar1); i1++) {
					if (Strings.Mid(strCode, i0, 1) == varBar1[i1])
						tmpHold[i0 - 1] = varBar2[i1];
				}
			}
			i0 = 0;
			while (!(i0 == Strings.Len(strCode))) {
				varBar3 = new string[i0 + 1];
				varBar3 = Strings.Split(tmpHold[i0], "-");
				varBar4 = Strings.Split(tmpHold[i0 + 1], "-");
				for (i1 = 0; i1 <= 4; i1++) {
					sBar = sBar + varBar3[i1] + varBar4[i1];
				}
				i0 = i0 + 2;
			}
			sBar = sBar + "311";
			return sBar;
		}
		public static object Codabar(ref string strCode)
		{
			string[] varBar1 = Strings.Split("1,2,3,4,5,6,7,8,9,0,-,$,:,/,.,+,A,B,C,D", ",");
			string[] varBar2 = Strings.Split("1111221,1112112,2211111,1121121,2111121,1211112,1211211,1221111,2112111,1111122,1112211,1122111,2111212,2121112,2121211,1121212,1122121,1212112,1112122,1112221", ",");
			sBar = "1122121" + "1";
			for (i0 = 1; i0 <= Strings.Len(strCode); i0++) {
				for (i1 = 0; i1 <= Information.UBound(varBar1); i1++) {
					if (Strings.Mid(strCode, i0, 1) == varBar1[i1])
						sBar = sBar + varBar2[i1] + "1";
				}
			}
			sBar = sBar + "1122121";
			return sBar;
		}
		public static object Barcode(ref string CodeType, ref string strCode, ref object pic, ref short barscale, ref float barHeight, ref float StartX, ref float startY)
		{
			object BF = null;
			float barWidth = 0;
			float barStart = 0;
			short i0 = 0;
			switch (CodeType) {
				case "39":
					strCode = Strings.UCase(strCode);
					Code39(ref strCode);
					break;
				case "128":
					Code128(ref strCode);
					break;
				case "2/5":
					strCode = (Strings.Len(strCode) % 2 > 0 ? strCode + "0" : strCode);
					Code25(ref strCode);
					break;
				case "Codabar":
					strCode = Strings.UCase(strCode);
					Codabar(ref strCode);
					break;
			}
			barStart = StartX;
			for (i0 = 1; i0 <= Strings.Len(sBar); i0++) {
				barWidth = Convert.ToDouble(Strings.Mid(sBar, i0, 1)) * barscale;
				//UPGRADE_WARNING: Couldn't resolve default property of object pic.Line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (i0 % 2 > 0) {
					//pic.Line((barStart, startY) - Step(barWidth, barHeight), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black), BF)
				}
				barStart = barStart + (i0 % 2 > 0 ? barWidth : barWidth * 1.3);
			}
			return barStart;

			//pic.FontSize = 16: pic.CurrentX = StartX: pic.CurrentY = (startY * 1.2) + barHeight: pic.Print strCode
		}
	}
}
