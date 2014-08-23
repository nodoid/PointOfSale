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
	static class modHEX
	{

		private static bool m_InitHex;
		private static byte[,] m_ByteToHex = new byte[256, 2];
//UPGRADE_WARNING: Lower bound of array m_HexToByte was changed from 48,48 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		private static byte[,] m_HexToByte = new byte[71, 71];
		[DllImport("kernel32.dll", EntryPoint = "RtlFillMemory", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		private static extern void FillMemory(ref object Destination, int Length, byte Fill);

		public static string HexToStr(ref string HexText, int Separators = 1)
		{

			int a = 0;
			int Pos = 0;
			int PosAdd = 0;
			int ByteSize = 0;
			byte[] HexByte = null;
			byte[] byteArray = null;

			//Initialize the hex routine
			if ((!m_InitHex))
				InitHex();

			//The destination string is half
			//the size of the source string
			//when the separators are removed
			if ((Strings.Len(HexText) == 2)) {
				ByteSize = 1;
			} else {
				ByteSize = ((Strings.Len(HexText) + 1) / (2 + Separators));
			}
			byteArray = new byte[ByteSize];

			//Convert every HEX code to the
			//equivalent ASCII character
			PosAdd = 2 + Separators;
			HexByte = System.Text.UnicodeEncoding.Unicode.GetBytes(Strings.StrConv(HexText, modVBFromUnicode.vbUnicode(HexText)));
			for (a = 0; a <= (ByteSize - 1); a++) {
				byteArray[a] = m_HexToByte[HexByte[Pos], HexByte[Pos + 1]];
				Pos = Pos + PosAdd;
			}

			//Now finally convert the byte
			//array to the return string
			return System.Text.Encoding.UTF8.GetString(byteArray);

		}
		private static void InitHex()
		{
			int a = 0;
			byte[] HexBytes = null;
			string HexString = null;

			//The routine is initialized
			m_InitHex = true;

			//Create a string with all hex values
			HexString = new string("0", 512);
			for (a = 1; a <= 255; a++) {
				Strings.Mid(HexString, 1 + a * 2 - Convert.ToInt16(a < 16)) = Conversion.Hex(a);
			}
			HexBytes = System.Text.UnicodeEncoding.Unicode.GetBytes(Strings.StrConv(HexString, modVBFromUnicode.vbUnicode(HexString)));

			//Create the Str->Hex array
			for (a = 0; a <= 255; a++) {
				m_ByteToHex[a, 0] = HexBytes[a * 2];
				m_ByteToHex[a, 1] = HexBytes[a * 2 + 1];
			}

			//Create the Str->Hex array
			for (a = 0; a <= 255; a++) {
				m_HexToByte[m_ByteToHex[a, 0], m_ByteToHex[a, 1]] = a;
			}
		}
		public static string StrToHex(ref string Text, ref string Separator = " ")
		{

			int a = 0;
			int Pos = 0;
			int PosAdd = 0;
			int ByteSize = 0;
			byte[] byteArray = null;
			byte[] ByteReturn = null;
			int SeparatorLen = 0;

			//Initialize the hex routine
			if ((!m_InitHex))
				InitHex();

			//Initialize variables
			SeparatorLen = Strings.Len(Separator);

			//Create the destination bytearray, this
			//will be converted to a string later
			ByteSize = (Strings.Len(Text) * 2 + (Strings.Len(Text) - 1) * SeparatorLen);
			ByteReturn = new byte[ByteSize];
			FillMemory(ref ByteReturn[0], ByteSize, Strings.AscW(Separator));

			//We convert the source string into a
			//byte array to speed this up a tad
			//UPGRADE_ISSUE: Constant vbFromUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
			//UPGRADE_TODO: Code was upgraded to use System.Text.UnicodeEncoding.Unicode.GetBytes() which may not have the same behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"'
			byteArray = System.Text.UnicodeEncoding.Unicode.GetBytes(Strings.StrConv(Text, modVBFromUnicode.vbUnicode(Text)));

			//Now convert every character to
			//it's equivalent HEX code
			PosAdd = 2 + SeparatorLen;
			for (a = 0; a <= (Strings.Len(Text) - 1); a++) {
				ByteReturn[Pos] = m_ByteToHex[byteArray[a], 0];
				ByteReturn[Pos + 1] = m_ByteToHex[byteArray[a], 1];
				Pos = Pos + PosAdd;
			}

			//Convert the bytearray to a string
			return System.Text.Encoding.UTF8.GetString(ByteReturn);
		}
	}
}
