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
using VB = Microsoft.VisualBasic;
namespace _4PosBackOffice.NET
{
	internal partial class frmBarcodeLoad : System.Windows.Forms.Form
	{
		public int gLBLleft;
		public int gLBLwidth;
		public int gLBLheight;
		public int LabelDisp;
		public int glBTop;
		public int twipsToMM;
		public string gPrinterLabel;
		public int gOffsetLabel;
		public int gPersonID;
		string strname;
		Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
		Label inrec;
		int strwidht;
		int strheight;
		string strpath;
		string pPath;
		bool cCompany;
		bool cCompTelephone;
		bool cStockItem;
		bool cBarcode;
		bool cGroup;
		bool cPrice;
		List<RadioButton> Option1 = new List<RadioButton>();
		List<RadioButton> Option2 = new List<RadioButton>();
		private void loadLanguage()
		{

			//frmBarcodeLoad = No Code       [Barcode Designing]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmBarcodeLoad.Caption = rsLang("LanguageLayoutLnk_Description"): frmBarcodeLoad.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1927;
			//Design Name|Checked
			if (modRecordSet.rsLang.RecordCount){Label1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lblDesign = No Code/Dynamic/NA?

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1928;
			//Label Width|
			if (modRecordSet.rsLang.RecordCount){_lbl_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lblWidth = No Code/Dynamic/NA?

			//_lbl_0 = No Code               [mm]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1929;
			//Label Height|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lblHeigh = No Code/Dynamic/NA?

			//_lbl_3 = No Code               [mm]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_3.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1930;
			//Top Margin|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_4.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_4.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lblTop = No Code/Dynamic/NA?

			//_lbl_5 = No Code               [mm]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_5.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1931;
			//Left Margin|
			if (modRecordSet.rsLang.RecordCount){_lbl_6.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_6.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lblLeft = No Code/Dynamic/NA?

			//_lbl_7 = No Code               [mm]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_7.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_7.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblLineNO = Not Applicable

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1579;
			//Back|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//Frame1 = No Code               [Select Field to Format]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0
			//If rsLang.RecordCount Then Frame1.Caption = rsLang("LanguageLayoutLnk_Description"): Frame1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1934;
			//Company Name|Checked
			if (modRecordSet.rsLang.RecordCount){Option1[0].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Option1[0].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1935;
			//Stock Item Name|Checked
			if (modRecordSet.rsLang.RecordCount){Option1[1].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Option1[1].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1936;
			//Barcode No|Checked
			if (modRecordSet.rsLang.RecordCount){Option1[2].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Option1[2].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1288;
			//Telephone|Checked
			if (modRecordSet.rsLang.RecordCount){Option1[3].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Option1[3].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1938;
			//Group|Checked
			if (modRecordSet.rsLang.RecordCount){Option1[5].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Option1[5].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1939;
			//Line|Checked
			if (modRecordSet.rsLang.RecordCount){Option1[6].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Option1[6].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1838;
			//Barcode|Checked
			if (modRecordSet.rsLang.RecordCount){Option1[7].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Option1[7].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1941;
			//Blank|
			if (modRecordSet.rsLang.RecordCount){Option1[8].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Option1[8].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//Option1(4) = No Code           [Price for 1]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Option1(4).Caption = rsLang("LanguageLayoutLnk_Description"): Option1(4).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Option1(9) = No Code           [Price for  6]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Option1(9).Caption = rsLang("LanguageLayoutLnk_Description"): Option1(9).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Option1(10) = No Code          [Price for 12]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Option1(10).Caption = rsLang("LanguageLayoutLnk_Description"): Option1(10).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Option1(11) = No Code          [Price for 24]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Option1(11).Caption = rsLang("LanguageLayoutLnk_Description"): Option1(11).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1946;
			//Font|Checked
			if (modRecordSet.rsLang.RecordCount){frmDeposits.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;frmDeposits.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1947;
			//Font Size|Checked
			if (modRecordSet.rsLang.RecordCount){Label5.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label5.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1948;
			//Row Position|Checked
			if (modRecordSet.rsLang.RecordCount){Label6.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label6.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1949;
			//Bold|Checked
			if (modRecordSet.rsLang.RecordCount){_chkFields_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_chkFields_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1950;
			//Align Left|Checked
			if (modRecordSet.rsLang.RecordCount){Option2[0].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Option2[0].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1951;
			//Align Centre|Checked
			if (modRecordSet.rsLang.RecordCount){Option2[1].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Option2[1].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1952;
			//Align Right|Checked
			if (modRecordSet.rsLang.RecordCount){Option2[2].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Option2[2].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_chkFields_4 = No Code         [Add/Remove]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _chkFields_4.Caption = rsLang("LanguageLayoutLnk_Description"): _chkFields_4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1579;
			//Back|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdundo.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdundo.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1956;
			//Save Design|Checked
			if (modRecordSet.rsLang.RecordCount){cmdadd.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdadd.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1957;
			//Apply Changes|Checked
			if (modRecordSet.rsLang.RecordCount){cmdSave.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdSave.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmBarcodeLoad.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public bool loadBarcodePrinter()
		{
			bool functionReturnValue = false;
			System.Drawing.Printing.PrintDocument Printer = new System.Drawing.Printing.PrintDocument();
			Label lblPrinter = null;

			System.Drawing.Printing.PrintDocument lPrinter = new System.Drawing.Printing.PrintDocument();
			ADODB.Recordset rs = default(ADODB.Recordset);
			functionReturnValue = true;
			gPrinterLabel = modApplication.MyNewPrLabel;
			//Jonas
			lblPrinter.Text = modApplication.MyNewPrLabel;
			if (Printer.PrinterSettings.InstalledPrinters.Count == 0) {
				functionReturnValue = false;
			} else {
				// gPrinterLabel = frmPrinter.selectPrinter()
				if (string.IsNullOrEmpty(gPrinterLabel)) {
					functionReturnValue = false;
				} else {

					foreach (System.Drawing.Printing.PrintDocument lPrinter_loopVariable in Printer.PrinterSettings.InstalledPrinters) {
						lPrinter = lPrinter_loopVariable;
						if (Strings.InStr(Strings.LCase(lPrinter.ToString()), Strings.LCase(gPrinterLabel))) {
							Printer = lPrinter;
							break; // TODO: might not be correct. Was : Exit For
						}
					}
					//Printer.PrinterSettings.DefaultPageSettings. = ScaleModeConstants.vbTwips 'twips
					//twipsToMM = Printer.ScaleWidth
					//Printer.ScaleMode = ScaleModeConstants.vbMillimeters 'mm
					//twipsToMM = twipsToMM / Printer.ScaleWidth
					//Printer.ScaleMode = ScaleModeConstants.vbTwips 'twips
					rs = modRecordSet.getRS(ref "SELECT Printer.* From Printer WHERE (((Printer.PrinterID)='" + Strings.Replace(gPrinterLabel, "'", "''") + "'));");
					//If rs.RecordCount Then
					//gOffsetLabel = rs("Printer_Offset")
					//gLBLheight = (rs("Printer_BCheight")) * twipsToMM
					//gLBLwidth = (rs("Printer_BCwidth")) * twipsToMM
					//Else
					gLBLheight = (30 - 2) * twipsToMM;
					gLBLwidth = (40 - 2) * twipsToMM;

					//End If

				}
			}
			return functionReturnValue;

		}

//UPGRADE_NOTE: size was upgraded to size_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		public string doImage(ref string code, ref bool size_Renamed)
		{
			string lXML = null;
			string lCode = null;
			short i = 0;
			for (i = 1; i <= Strings.Len(code); i++) {
				lCode = Strings.Left(code, i);
				lCode = Strings.Right(lCode, 1);
				if (lCode == "0") {
					lXML = lXML + System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White) + "~";
				} else {
					lXML = lXML + System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black) + "~";
				}
				if ((size_Renamed)) {
					lXML = lXML + 30 + "|";
				} else {
					lXML = lXML + 25 + "|";
				}
			}
			return lXML;
		}

		private bool doCheckSum(ref string lString)
		{
			bool functionReturnValue = false;
			short lAmount = 0;
			string code = null;
			short i = 0;
			string value = null;
			value = lString;
			//UPGRADE_WARNING: Couldn't resolve default property of object doCheckSum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			functionReturnValue = false;
			if (Strings.InStr(value, "0")) {
				while (!(Convert.ToDouble(Strings.Left(value, 1)) != 0)) {
					value = Strings.Mid(value, 2);
				}
			}
			if (Strings.Len(value) < 12)
				return functionReturnValue;
			if (string.IsNullOrEmpty(value))
				return functionReturnValue;
			if (Strings.InStr(value, ".")) {
				//UPGRADE_WARNING: Couldn't resolve default property of object doCheckSum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				functionReturnValue = false;
			} else {
				if (Information.IsNumeric(value)) {
					lAmount = 0;
					for (i = 1; i <= Strings.Len(value) - 1; i++) {
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
					//UPGRADE_WARNING: Couldn't resolve default property of object doCheckSum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					functionReturnValue = lAmount == Convert.ToInt16(Strings.Right(value, 1));
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object doCheckSum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					functionReturnValue = false;
				}
			}
			return functionReturnValue;
		}



		public void printBarcode(ref object barcodePicture, ref string lValue, ref int lLeft, ref int lTop, ref int lWidth = 0)
		{
			//Dim BF As Object
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
			int i = 0;
			int j = 0;
			short cnt = 0;
			string[] barArray = null;
			lXML = "";
			if (doCheckSum(ref lValue)) {
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
				code = Strings.Left(lValue, 1);
				code = Strings.Right(code, 1);
				codeType = parityArray[Convert.ToInt16(code)];

				lXML = lXML + doImage(ref "101", ref 1);
				for (i = 2; i <= 7; i++) {
					code = Strings.Left(lValue, i);
					code = Strings.Right(code, 1);
					lCode = Strings.Left(codeType, i - 1);
					lCode = Strings.Right(lCode, 1);
					if (lCode == "0") {
						lXML = lXML + doImage(ref evenArray[code], ref 0);
					} else {
						lXML = lXML + doImage(ref oddArray[code], ref 0);
					}
				}
				lXML = lXML + doImage(ref "01010", ref 1);
				for (i = 8; i <= 13; i++) {
					code = Strings.Left(lValue, i);
					code = Strings.Right(code, 1);
					lXML = lXML + doImage(ref lastArray[code], ref 0);
				}
				lXML = lXML + doImage(ref "101", ref 1);
			} else {
				lString = lValue;
				for (i = 1; i <= Strings.Len(lString); i++) {
					if (Convert.ToDouble(Strings.Left(lString, 1)) == 0) {
						lString = Strings.Right(lString, Strings.Len(lString) - 1);
					} else {
						break; // TODO: might not be correct. Was : Exit For
					}
				}
				lValue = lString;

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

				lString = "131131311";
				lString = lString + "1";
				for (i = 1; i <= Strings.Len(lValue); i++) {
					code = Strings.Left(lValue, i);
					code = Strings.Right(code, 1);
					code = Strings.UCase(code);
					for (j = 0; j <= Information.UBound(oddArray); j++) {
						if (code == oddArray[j]) {
							lString = lString + evenArray[j];
							lString = lString + "1";
							j = 9999;
						}
					}
				}
				lString = lString + "131131311";

				for (i = 1; i <= Strings.Len(lString); i++) {
					code = Strings.Left(lString, i);
					code = Strings.Right(code, 1);
					for (j = 1; j <= Convert.ToInt16(code); j++) {
						lCode = Strings.Left(code, i);
						lCode = Strings.Right(lCode, 1);
						if (i % 2) {
							lXML = lXML + System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black) + "~";
						} else {
							lXML = lXML + System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White) + "~";
						}
						lXML = lXML + "20|";
					}
				}
			}

			barArray = Strings.Split(lXML, "|");
			y = lTop;
			if (lWidth == 0) {
				x = lLeft;
			} else {
				x = Convert.ToInt16(lLeft + (lWidth - Information.UBound(barArray) * sizeConvertors.twipsPerPixel(true) / 2));
			}
			for (cnt = Information.LBound(barArray); cnt <= Information.UBound(barArray); cnt++) {
				if (!string.IsNullOrEmpty(barArray[cnt])) {
					if (Convert.ToInt32(Strings.Split(barArray[cnt], "~")[0]) == System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)) {

						//barcodePicture.Line((x + cnt * twipsPerPixel(True), y) - (x + (cnt + 1) * twipsPerPixel(true), y + CInt(Split(barArray(cnt), "~")(1)) * twipsPerPixel(true)), CInt(Split(barArray(cnt), "~")(0)), BF)

					}
				}

			}
		}

		private void Command1_Click()
		{
			short NewLargeChange = 0;
			int lline = 0;
			PictureBox lObject = null;
			int y = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsData = default(ADODB.Recordset);
			lObject = _picSelect_0;
			int currentPic = 0;
			short RecSelNew = 0;
			string lString1 = null;
			string lString2 = null;
			//For currentPic = 0 To 1
			//_picSelect_0.Unload(currentPic)
			//Next
			//currentPic = 0
			_picSelect_0.Width = sizeConvertors.twipsToPixels(gLBLwidth, true);
			gLBLleft = (lObject.Width - (gLBLwidth)) / 2 + (gOffsetLabel * twipsToMM);
			gLBLleft = 0;
			//picSelect(0).Cls

			rs = modRecordSet.getRS(ref "SELECT * FROM BClabel WHERE BClabel_Disabled = false and BClabel_LabelID=" + modApplication.LaIDHold + " ORDER BY BClabelID");
			//currentPic = 0
			while (!(rs.EOF)) {
				if (currentPic) {
					 // ERROR: Not supported in C#: OnErrorStatement

					_picSelect_0.Load(currentPic);
				}
				_picSelect_0.Left = sizeConvertors.twipsToPixels((sizeConvertors.pixelToTwips(_picSelect_0.Width, true) + 90) * currentPic, true);
				_picSelect_0.Visible = true;
				//UPGRADE_ISSUE: PictureBox property picSelect.AutoRedraw was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				//_picSelect_0.AutoRedraw = True
				lObject = _picSelect_0;
				_picSelect_0.Tag = rs.Fields("BClabelID").Value;

				y = Convert.ToInt16((gLBLheight - rs.Fields("BClabel_Height").Value * twipsToMM) / 2);
				if (y < 0)
					y = 0;
				//lObject.FontName = "Tahoma"

				rsData = modRecordSet.getRS(ref "SELECT * FROM BClabelItem INNER JOIN BClabel ON BClabelItem.BClabelItem_BCLabelID = BClabel.BClabelID Where (((BClabel.BClabelID) = " + rs.Fields("BClabelID").Value + ")) ORDER BY BClabel.BClabelID, BClabelItem.BClabelItem_Line;");
				if (rsData.RecordCount) {
					lline = rsData.Fields("BClabelItem_Line").Value;
					while (!(rsData.EOF)) {
						if (lline != rsData.Fields("BClabelItem_Line").Value) {
							y = lObject.Location.Y + 10;
							lline = rsData.Fields("BClabelItem_Line").Value;
						}

						switch (Strings.LCase(rsData.Fields("BClabelItem_Field").Value)) {
							case "line":
								break;
							//lObject.Line((15 + gLBLleft, y) - (gLBLleft + gLBLwidth, y), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black))
							case "code":
								switch (rsData.Fields("BClabelItem_Align").Value) {
									case 1:
										printBarcode(lObject, "6001060071416", gLBLleft, y);
										break;
									//lObject.FontBold = rsData.Fields("BClabelItem_Bold").Value
									//lObject.FontSize = rsData.Fields("BClabelItem_Size").Value
									case 2:
										//lObject.FontBold = rsData.Fields("BClabelItem_Bold").Value
										//lObject.FontSize = rsData.Fields("BClabelItem_Size").Value
										printBarcode(lObject, "6001060071416", gLBLleft + 1000, y);
										break;
									default:
										//lObject.FontBold = rsData.Fields("BClabelItem_Bold").Value
										//lObject.FontSize = rsData.Fields("BClabelItem_Size").Value
										printBarcode(ref lObject, ref "6001060071416", ref gLBLleft, ref y, ref gLBLwidth);

										break;
								}

								break;
							default:
								 // ERROR: Not supported in C#: OnErrorStatement

								//lObject.FontSize = rsData.Fields("BClabelItem_Size").Value
								//lObject.FontBold = rsData.Fields("BClabelItem_Bold").Value
								//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
								lString1 = rsData.Fields("BClabelItem_Sample").Value;
								switch (rsData.Fields("BClabelItem_Align").Value) {
									case 1:
										break;
									//lObject.PSet(New Point[](gLBLleft, y))
									//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
									//lObject.Print(lString1)

									case 2:
										break;
									//lObject.PSet(New Point[](gLBLleft + gLBLwidth - lObject.TextWidth(lString1), y))
									//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
									//lObject.Print(lString1)

									case 3:
										//splitString(lObject, lString1, lString2)
										if (!string.IsNullOrEmpty(lString1)) {
											//lObject.PSet(New Point[](CShort(gLBLleft + (gLBLwidth - lObject.TextWidth(lString1)) / 2), y))
											//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
											//lObject.Print(lString1)
											y = lObject.Location.Y + 10;
											//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
										}
										lString1 = lString2;
										if (!string.IsNullOrEmpty(lString1)) {
											//.lObject.PSet(New Point[](CShort(gLBLleft + (gLBLwidth - lObject.TextWidth(lString1)) / 2), y))
											//.lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
											//.lObject.Print(lString1)
										}
										break;
									default:
										break;
									//lObject.PSet(New Point[](CShort(gLBLleft + (gLBLwidth - lObject.TextWidth(lString1)) / 2), y))
									//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
									//lObject.Print(lString1)
								}
								break;
						}
						rsData.MoveNext();
					}
				}
				rs.MoveNext();
			}
			// picSelect(0).FontItalic = True
			picInner.Width = sizeConvertors.twipsToPixels(lObject.Left + lObject.Width, true);
			picInner.SetBounds(0, 0, sizeConvertors.twipsToPixels(lObject.Left + lObject.Width, true), sizeConvertors.twipsToPixels(lObject.Top + lObject.Height, false));
			if (sizeConvertors.pixelToTwips(picInner.Width, true) > sizeConvertors.pixelToTwips(picOuter.Width, true)) {
				HSselect.Enabled = true;
				HSselect.Value = 0;
				HSselect.Maximum = (sizeConvertors.pixelToTwips(picInner.Width, true) - sizeConvertors.pixelToTwips(picOuter.Width, true) + 100 + HSselect.LargeChange - 1);
				NewLargeChange = lObject.Width + 100;
				HSselect.Maximum = HSselect.Maximum + NewLargeChange - HSselect.LargeChange;
				HSselect.LargeChange = NewLargeChange;
				HSselect.SmallChange = Convert.ToInt16((lObject.Width + 100) / 2);

			} else {
				HSselect.Enabled = false;
			}


		}

		private int TextWidth(PictureBox obj, string text)
		{
			Size width = TextRenderer.MeasureText(text, obj.DefaultFont);
			return width.Width;
		}

		private void splitString(ref PictureBox lObject, ref string HeadingString1, ref string HeadingString2)
		{
			System.Drawing.Printing.PrintDocument Printer = new System.Drawing.Printing.PrintDocument();
			short y = 0;
			short x = 0;
			string lHeading = null;
			Size width = TextRenderer.MeasureText(lHeading, lObject.DefaultFont);

			lHeading = HeadingString1;
			HeadingString1 = lHeading + " ";
			HeadingString2 = "";
			if ((gLBLwidth - TextWidth(lObject, lHeading)) < 0) {
				for (x = Strings.Len(lHeading) + 1; x >= 1; x += -1) {
					HeadingString1 = Strings.Left(lHeading, x);
					if ((gLBLwidth - TextWidth(lObject, HeadingString1) + 50) > 0) {
						for (y = Strings.Len(HeadingString1) + 1; y >= 1; y += -1) {

							if (Strings.Right(Strings.Left(HeadingString1, y), 1) == " ") {
								HeadingString1 = Strings.Left(HeadingString1, y - 1);
								if ((lHeading != HeadingString1)) {
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
				HeadingString2 = HeadingString1;
				HeadingString1 = "";
			} else {
				while (!(Printer.DefaultPageSettings.Bounds.Width <= gLBLwidth)) {
					//Do Until Printer.TextWidth(HeadingString2) <= gLBLwidth
					HeadingString2 = Strings.Mid(HeadingString2, 1, Strings.Len(HeadingString2) - 1);
				}
			}
			HeadingString1 = Strings.Trim(HeadingString1);
			HeadingString2 = Strings.Trim(HeadingString2);
		}


		private void Align_Click(ref short Index)
		{
		}

		private void chkfield_Click(ref short Index)
		{
			string TheNamesCod = null;
			string TheNamesLi = null;
			string TheNamesGro = null;
			string TheNamesPr = null;
			string TheNamesTel = null;
			string TheNamesBarc = null;
			string TheNamesSt = null;
			string TheNamesC = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = new ADODB.Recordset();

			if (Index == 0) {
				TheNamesC = "Company_Name";
				modApplication.TheNames = "Company_Name";
				rs = modRecordSet.getRS(ref "SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + TheNamesC + "'");
			} else if (Index == 1) {
				TheNamesSt = "StockItem_Name";
				modApplication.TheNames = "StockItem_Name";
				rs = modRecordSet.getRS(ref "SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + TheNamesSt + "'");
			} else if (Index == 4) {
				TheNamesBarc = "Catalogue_Barcode";
				modApplication.TheNames = "Catalogue_Barcode";
				rs = modRecordSet.getRS(ref "SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + TheNamesBarc + "'");
			} else if (Index == 2) {
				TheNamesTel = "Company_Telephone";
				modApplication.TheNames = "Company_Telephone";
				rs = modRecordSet.getRS(ref "SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + TheNamesTel + "'");
			} else if (Index == 3) {
				TheNamesPr = "Price";
				modApplication.TheNames = "Price";
				rs = modRecordSet.getRS(ref "SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + TheNamesPr + "'");
			} else if (Index == 5) {
				TheNamesGro = "PricingGroupID";
				modApplication.TheNames = "PricingGroupID";
				rs = modRecordSet.getRS(ref "SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + TheNamesGro + "'");
			} else if (Index == 7) {
				TheNamesLi = "line";
				modApplication.TheNames = "line";
				rs = modRecordSet.getRS(ref "SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + TheNamesLi + "'");
			} else if (Index == 6) {
				TheNamesCod = "code";
				modApplication.TheNames = "code";
				rs = modRecordSet.getRS(ref "SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + TheNamesCod + "'");
			}

		}

		//Private Sub chkFields_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkFields.CheckStateChanged
		//	Dim Index As Short = chkFields.GetIndex(eventSender)

		//If _chkFields_0.value Then cCompany = True Else cCompany = False
		//updattecomp
		//If _chkFields_1.value Then cCompTelephone = True Else cCompTelephone = False
		//updattetel
		//If _chkFields_2.value Then cStockItem = True Else cStockItem = False
		//updattestck
		//If _chkFields_3.value Then cBarcode = True Else cBarcode = False
		//updattebar
		//If _chkFields_4.value Then cGroup = True Else cGroup = False
		//updattegr
		//If _chkFields_5.value Then cPrice = True Else cPrice = False
		//updattepr

		//If _chkFields_1.value And _chkFields_2.value = 0 Then

		//   If _chkFields_2.value Then
		//       _chkFields_1.value = 0
		//   ElseIf _chkFields_1.value Then
		//       _chkFields_1.value = 1
		//  End If
		//ElseIf _chkFields_2.value = 1 And _chkFields_1.value = 1 Then
		//    If _chkFields_2.value Then
		//        _chkFields_1.value = 0
		//    Else
		//        _chkFields_1.value = 1
		//    End If

		//End If

		//Public MyFBold As String
		//Public MyFAlign As String

		//If _chkFields_1.value Then
		//    MyFAlign = 1
		//ElseIf _chkFields_2.value Then
		//    MyFAlign = 0
		//ElseIf _chkFields_3.value Then
		//    MyFAlign = 2
		//End If

		//End Sub
		private void updattepr()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "SELECT BClabelItem.* from BClabelItem");
			while (!(rs.EOF)) {
				if (cPrice == true) {
					modRecordSet.cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = True WHERE (((BClabelItem.BClabelItem_Field)='Price'));");
				} else {
					modRecordSet.cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = False WHERE (((BClabelItem.BClabelItem_Field)='Price'));");
				}
				rs.MoveNext();
			}
		}

		private void updattegr()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "SELECT BClabelItem.* from BClabelItem");
			while (!(rs.EOF)) {
				if (cGroup == true) {
					modRecordSet.cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = True WHERE (((BClabelItem.BClabelItem_Field)='PricingGroupID'));");
				} else {
					modRecordSet.cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = False WHERE (((BClabelItem.BClabelItem_Field)='PricingGroupID'));");
				}

				rs.MoveNext();
			}
		}
		private void updattebar()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "SELECT BClabelItem.* from BClabelItem");
			while (!(rs.EOF)) {
				if (cBarcode == true) {
					modRecordSet.cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = True WHERE (((BClabelItem.BClabelItem_Field)='Catalogue_Barcode'));");
				} else {
					modRecordSet.cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = False WHERE (((BClabelItem.BClabelItem_Field)='Catalogue_Barcode'));");
				}
				rs.MoveNext();
			}
		}
		private void updattestck()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "SELECT BClabelItem.* from BClabelItem");
			while (!(rs.EOF)) {
				if (cStockItem == true) {
					modRecordSet.cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = True WHERE (((BClabelItem.BClabelItem_Field)='StockItem_Name'));");
				} else {
					modRecordSet.cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = False WHERE (((BClabelItem.BClabelItem_Field)='StockItem_Name'));");
				}
				rs.MoveNext();
			}
		}
		private void updattecomp()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);

			rs = modRecordSet.getRS(ref "SELECT BClabelItem.* from BClabelItem");
			while (!(rs.EOF)) {
				if (cCompany == true) {
					modRecordSet.cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = True WHERE (((BClabelItem.BClabelItem_Field)='Company_Name'));");
				} else {
					modRecordSet.cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = False WHERE (((BClabelItem.BClabelItem_Field)='Company_Name'));");
				}
				rs.MoveNext();
			}

		}

		private void updattetel()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);

			rs = modRecordSet.getRS(ref "SELECT BClabelItem.* from BClabelItem");
			while (!(rs.EOF)) {
				if (cCompTelephone == true) {
					modRecordSet.cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = True WHERE (((BClabelItem.BClabelItem_Field)='Company_Telephone'));");
				} else {
					modRecordSet.cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = False WHERE (((BClabelItem.BClabelItem_Field)='Company_Telephone'));");
				}
				rs.MoveNext();
			}
		}

		private void updatte()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);

			rs = modRecordSet.getRS(ref "SELECT BClabelItem.* from BClabelItem");
			while (!(rs.EOF)) {
				if (cCompany == true) {
					modRecordSet.cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = True WHERE (((BClabelItem.BClabelItem_Field)='Company_Name'));");
				} else {
					modRecordSet.cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = False WHERE (((BClabelItem.BClabelItem_Field)='Company_Name'));");
				}

				if (cCompTelephone == true) {
					modRecordSet.cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = True WHERE (((BClabelItem.BClabelItem_Field)='Company_Telephone'));");
				} else {
					modRecordSet.cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = False WHERE (((BClabelItem.BClabelItem_Field)='Company_Telephone'));");
				}

				if (cStockItem == true) {
					modRecordSet.cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = True WHERE (((BClabelItem.BClabelItem_Field)='StockItem_Name'));");
				} else {
					modRecordSet.cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = False WHERE (((BClabelItem.BClabelItem_Field)='StockItem_Name'));");
				}

				if (cBarcode == true) {
					modRecordSet.cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = True WHERE (((BClabelItem.BClabelItem_Field)='Catalogue_Barcode'));");
				} else {
					modRecordSet.cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = False WHERE (((BClabelItem.BClabelItem_Field)='Catalogue_Barcode'));");
				}

				if (cGroup == true) {
					modRecordSet.cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = True WHERE (((BClabelItem.BClabelItem_Field)='PricingGroupID'));");
				} else {
					modRecordSet.cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = False WHERE (((BClabelItem.BClabelItem_Field)='PricingGroupID'));");
				}
				if (cPrice == true) {
					modRecordSet.cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = True WHERE (((BClabelItem.BClabelItem_Field)='Price'));");
				} else {
					modRecordSet.cnnDB.Execute("UPDATE BClabelItem SET BClabelItem.BClabelItem_Disabled = False WHERE (((BClabelItem.BClabelItem_Field)='Price'));");
				}
				rs.MoveNext();
			}
		}


		private void cmbfont_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (!Information.IsNumeric(this.cmbfont.Text)) {
				Interaction.MsgBox("Font size must be a Number.", MsgBoxStyle.Information, "4Pos Back Office");
				this.cmbfont.Text = "8";
				this.cmbfont.Focus();
				return;
			} else {
			}

		}

		private void cmdAdd_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//On Error Resume Next
			string MyInputStr = null;
			ADODB.Recordset rst = default(ADODB.Recordset);
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsNoRec = default(ADODB.Recordset);
			ADODB.Recordset rsBDItem = default(ADODB.Recordset);
			ADODB.Recordset rsBCL = default(ADODB.Recordset);
			string TheNames1 = null;
			short RecSel1 = 0;
			ADODB.Recordset rsLabel = default(ADODB.Recordset);
			ADODB.Recordset rsCName = default(ADODB.Recordset);
			string MySamp = null;
			short TheLaID = 0;
			short TheMSgValu = 0;

			rs = new ADODB.Recordset();
			rst = new ADODB.Recordset();
			rsNoRec = new ADODB.Recordset();
			rsBDItem = new ADODB.Recordset();
			rsBCL = new ADODB.Recordset();
			rsLabel = new ADODB.Recordset();
			rsCName = new ADODB.Recordset();


			//calling the input box
			MyInputStr = Interaction.InputBox("Please enter Label Name");

			string apostrophe = null;
			string TheUpOne = null;

			apostrophe = "'";
			short pos = 0;
			string DouQuotes = null;
			short start = 0;
			string MNewVerror = null;
			start = 1;
			DouQuotes = "''";

			MNewVerror = MyInputStr;
			pos = Strings.InStr(start, MNewVerror, apostrophe);


			if (pos > 0) {
				TheUpOne = Strings.Replace(MNewVerror, apostrophe, DouQuotes, 1, pos, CompareMethod.Text);
				MyInputStr = TheUpOne;
			} else {
				TheUpOne = MNewVerror;
				MyInputStr = TheUpOne;
			}


			//selecting the last labelID so we can increment it by one
			rs = modRecordSet.getRS(ref "SELECT Max(Label.LabelID) AS TheLastLabel FROM Label");
			TheLaID = rs.Fields("TheLastLabel").Value;
			TheLaID = TheLaID + 1;
			//checking if the name already exist
			rsCName = modRecordSet.getRS(ref "SELECT Label.*, LabelItem.* FROM Label INNER JOIN LabelItem ON Label.LabelID = LabelItem.labelItem_LabelID WHERE Label.Label_Name='" + MyInputStr + "' and Label.Label_Type=" + modApplication.TheType + "");

			int LeftVa = 0;
			ADODB.Recordset rsFound = default(ADODB.Recordset);
			short HoldMyLaID = 0;
			if (!string.IsNullOrEmpty(Strings.Trim(MyInputStr))) {
				rs = modRecordSet.getRS(ref "SELECT * FROM BClabelItem WHERE BClabelItem_LabelID=" + modApplication.MyLIDWHole + "");

				if (rs.RecordCount == 1) {
					Interaction.MsgBox("Saving an empty design is not allowed.Please add some fields.", MsgBoxStyle.Information, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					return;

				} else {
				}

				//If HSLeft.value = 0 Then
				//    LeftVa = 0
				//Else
				//    LeftVa = LeftVa + 400
				//End If


				if (rsCName.RecordCount < 1) {
					rsLabel = modRecordSet.getRS(ref "INSERT INTO Label(LabelID,Label_Type,Label_Name,Label_Height,Label_Width,Label_Top,Label_Rotate,Label_Disabled,Label_Left)VALUES(" + TheLaID + "," + modApplication.TheType + ",'" + MyInputStr + "'," + this.HSHeight.Value + "," + this.HSWidth.Value + "," + HSTop.Value + ",'" + 0 + "','" + 0 + "'," + HSLeft.Value + ")");

				} else if (rsCName.RecordCount > 0 & modApplication.NewLabelName == MyInputStr) {
					rsLabel = modRecordSet.getRS(ref "UPDATE Label SET Label_Height=" + this.HSHeight.Value + ",Label_Width=" + this.HSWidth.Value + ",Label_Top=" + HSTop.Value + ",Label_Rotate='" + 0 + "',Label_Disabled='" + 0 + "',Label_Name='" + MyInputStr + "',Label_Left=" + HSLeft.Value + " WHERE Label.Label_Name='" + MyInputStr + "'");
				} else if (rsCName.RecordCount > 0 & modApplication.NewLabelName != MyInputStr) {
					TheMSgValu = Interaction.MsgBox("There is a Design with the same name.Clicking Yes will override the existing design.Are you sure you wish to override the design?", MsgBoxStyle.YesNo, "4POS Back Office");
					if (TheMSgValu == MsgBoxResult.Yes) {
						rsLabel = modRecordSet.getRS(ref "UPDATE Label SET Label_Height=" + this.HSHeight.Value + ",Label_Width=" + this.HSWidth.Value + ",Label_Top=" + HSTop.Value + ",Label_Rotate='" + 0 + "',Label_Disabled='" + 0 + "',Label_Name='" + MyInputStr + "',Label_Left=" + HSLeft.Value + " WHERE Label.Label_Name='" + MyInputStr + "'");
					} else if (TheMSgValu == MsgBoxResult.No) {
						return;
					}

				}

				rst = modRecordSet.getRS(ref "SELECT Max(BClabelItem.BClabelItem_BCLabelID) as TheLastItemID FROM BClabelItem");

				//selecting from the selected design to modify it and added it as a new design
				rsNoRec = modRecordSet.getRS(ref "SELECT * FROM BClabelItem WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + "");

				RecSel1 = rst.Fields("TheLastItemID").Value + 1;
				//adding 1 to insert a new record later

				//Set rsBCL = getRS("SELECT * FROM BClabel WHERE BClabelID=" & RecSel & "")

				if (rsCName.RecordCount < 1) {
					//TheNames = TheNames

					while (!(rsNoRec.EOF)) {
						//for hold the sample to insert
						if (rsNoRec.Fields("BClabelItem_Field").Value == "Company_Name" & string.IsNullOrEmpty(Strings.Trim(rsNoRec.Fields("BClabelItem_Sample").Value))) {
							MySamp = " ";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "Company_Name") {
							MySamp = "4POS Demo";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "Company_Telephone" & string.IsNullOrEmpty(Strings.Trim(rsNoRec.Fields("BClabelItem_Sample").Value))) {
							MySamp = " ";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "Company_Telephone") {
							MySamp = "082 448 3987";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "line") {
							MySamp = " ";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "StockItem_Name" & string.IsNullOrEmpty(Strings.Trim(rsNoRec.Fields("BClabelItem_Sample").Value))) {
							MySamp = " ";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "StockItem_Name") {
							MySamp = "Default Stock Item Name";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "code") {
							MySamp = " ";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "Catalogue_Barcode" & string.IsNullOrEmpty(Strings.Trim(rsNoRec.Fields("BClabelItem_Sample").Value))) {
							MySamp = " ";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "Catalogue_Barcode") {
							MySamp = "6001060071416";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "PricingGroup_Name" & string.IsNullOrEmpty(Strings.Trim(rsNoRec.Fields("BClabelItem_Sample").Value))) {
							MySamp = " ";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "PricingGroup_Name") {
							MySamp = "Beer Local";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "Price" & string.IsNullOrEmpty(Strings.Trim(rsNoRec.Fields("BClabelItem_Sample").Value))) {
							MySamp = " ";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "Price") {
							MySamp = "R 21.99";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "Price6") {
							MySamp = "R 21.99 for   6";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "Price12") {
							MySamp = "R 21.99 for  12";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "Price24") {
							MySamp = "R 21.99 for  24";

						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "blank") {
							MySamp = " ";
						}

						//if field is equal to code the sample is space
						if (rsNoRec.Fields("BClabelItem_Field").Value == "code") {
							TheNames1 = " ";
						//if the field is equal to line the sample is space
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "line") {
							TheNames1 = " ";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "blank") {
							TheNames1 = " ";
						} else {
							if (modApplication.TheNames == "line") {
								TheNames1 = " ";
							} else {
								TheNames1 = rsNoRec.Fields("BClabelItem_Sample").Value;
							}

						}
						//if field is equal to code
						if (rsNoRec.Fields("BClabelItem_Field").Value == "code") {
							rs = modRecordSet.getRS(ref "INSERT INTO LabelItem(labelItem_LabelID,labelItem_Line,labelItem_Field,labelItem_Align,labelItem_Size,labelItem_Bold,labelItem_Sample) VALUES (" + TheLaID + "," + rsNoRec.Fields("BClabelItem_Line").Value + ",'code'," + rsNoRec.Fields("BClabelItem_Align").Value + "," + rsNoRec.Fields("BClabelItem_Size").Value + "," + rsNoRec.Fields("BClabelItem_Bold").Value + ",'" + TheNames1 + "')");
						//if field is equal to line
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "line") {
							rs = modRecordSet.getRS(ref "INSERT INTO LabelItem(labelItem_LabelID,labelItem_Line,labelItem_Field,labelItem_Align,labelItem_Size,labelItem_Bold,labelItem_Sample) VALUES (" + TheLaID + "," + rsNoRec.Fields("BClabelItem_Line").Value + ",'line'," + rsNoRec.Fields("BClabelItem_Align").Value + "," + rsNoRec.Fields("BClabelItem_Size").Value + "," + rsNoRec.Fields("BClabelItem_Bold").Value + ",'" + TheNames1 + "')");
							//****
							//New code for Blank
						//if field is equal to line
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "blank") {
							rs = modRecordSet.getRS(ref "INSERT INTO LabelItem(labelItem_LabelID,labelItem_Line,labelItem_Field,labelItem_Align,labelItem_Size,labelItem_Bold,labelItem_Sample) VALUES (" + TheLaID + "," + rsNoRec.Fields("BClabelItem_Line").Value + ",'blank'," + rsNoRec.Fields("BClabelItem_Align").Value + "," + rsNoRec.Fields("BClabelItem_Size").Value + "," + rsNoRec.Fields("BClabelItem_Bold").Value + ",'" + TheNames1 + "')");
							//****
						} else {
							rs = modRecordSet.getRS(ref "INSERT INTO LabelItem(labelItem_LabelID,labelItem_Line,labelItem_Field,labelItem_Align,labelItem_Size,labelItem_Bold,labelItem_Sample) VALUES (" + TheLaID + "," + rsNoRec.Fields("BClabelItem_Line").Value + ",'" + rsNoRec.Fields("BClabelItem_Field").Value + "'," + rsNoRec.Fields("BClabelItem_Align").Value + "," + rsNoRec.Fields("BClabelItem_Size").Value + "," + rsNoRec.Fields("BClabelItem_Bold").Value + ",'" + MySamp + "')");
						}
						rsNoRec.MoveNext();

					}

					rs = modRecordSet.getRS(ref "SELECT * FROM BClabel WHERE BClabelID=" + modApplication.RecSel + "");

					//For Inserting New Record into BClabel
					rsCName = modRecordSet.getRS(ref "INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES(" + RecSel1 + ",'" + rs.Fields("BClabel_Name").Value + "','" + rs.Fields("BClabel_Type").Value + "'," + rs.Fields("BClabel_Disabled").Value + "," + rs.Fields("BClabel_Height").Value + "," + TheLaID + ")");

					rs = modRecordSet.getRS(ref "SELECT * FROM LabelItem WHERE labelItem_LabelID=" + TheLaID + "");

					//For Inserting New record into BCLabelItem
					//If rs.RecordCount > 0 Then
					//End If
					while (!(rs.EOF)) {
						rsCName = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + RecSel1 + "," + rs.Fields("labelItem_Line").Value + ",'" + rs.Fields("labelItem_Field").Value + "'," + rs.Fields("labelItem_Align").Value + "," + rs.Fields("labelItem_Size").Value + "," + rs.Fields("labelItem_Bold").Value + ",'" + rs.Fields("labelItem_Sample").Value + "','" + 0 + "'," + TheLaID + ")");
						rs.MoveNext();
					}
					//000
					rsCName = modRecordSet.getRS(ref "SELECT * FROM BClabelItemUndo");

					if (rsCName.RecordCount > 0) {
						rs = modRecordSet.getRS(ref "SELECT * FROM BClabelItemUndo");
					} else {
						modApplication.TheSelectedPrinterNew = 2;
						modApplication.MyLIDWHole = TheLaID;
						labelsfile();
						return;
					}
					//rs.MoveLast

					while (!(rs.EOF)) {
						rsNoRec = modRecordSet.getRS(ref "SELECT * FROM BClabelItem WHERE BClabelItemID =" + rs.Fields("BClabelItemID").Value + " AND BClabelItem_Field='" + rs.Fields("BClabelItem_Field").Value + "'");

						if (rsNoRec.RecordCount > 0) {
							rst = modRecordSet.getRS(ref "DELETE * FROM BClabelItem WHERE BClabelItemID=" + rs.Fields("BClabelItemID").Value + "");

							//Set rst = getRS("DELETE * FROM BClabelItemUndo WHERE BClabelItemID=" & rs("BClabelItemID") & "")
						} else if (rsNoRec.RecordCount < 1) {
							rst = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rs.Fields("BClabelItem_BCLabelID").Value + "," + rs.Fields("BClabelItem_Line").Value + ",'" + rs.Fields("BClabelItem_Field").Value + "'," + rs.Fields("BClabelItem_Align").Value + "," + rs.Fields("BClabelItem_Size").Value + "," + rs.Fields("BClabelItem_Bold").Value + ",'" + rs.Fields("BClabelItem_Sample").Value + "'," + rs.Fields("BClabelItem_Disabled").Value + "," + rs.Fields("BClabelItem_LabelID").Value + ")");
							//Set rst = getRS("DELETE * FROM BClabelItemUndo WHERE BClabelItemID=" & rs("BClabelItemID") & " and BClabelItem_Field='" & rs("BClabelItem_Field") & "'")
						}

						rs.MoveNext();
					}
					rst = modRecordSet.getRS(ref "DELETE * FROM BClabelItemUndo");
					// WHERE BClabelItemID=" & rs("BClabelItemID") & " and BClabelItem_Field='" & rs("BClabelItem_Field") & "'")
					modApplication.MyLIDWHole = TheLaID;
					modApplication.RecSel = RecSel1;
					//000
				} else {
					//updating
					rsFound = new ADODB.Recordset();

					HoldMyLaID = rsCName.Fields("labelItem_LabelID").Value;

					rsFound = modRecordSet.getRS(ref "DELETE * FROM LabelItem WHERE labelItem_LabelID=" + HoldMyLaID + "");


					while (!(rsNoRec.EOF)) {
						//for hold the sample to insert
						if (rsNoRec.Fields("BClabelItem_Field").Value == "Company_Name" & string.IsNullOrEmpty(Strings.Trim(rsNoRec.Fields("BClabelItem_Sample").Value))) {
							MySamp = " ";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "Company_Name") {
							MySamp = "4POS Demo";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "Company_Telephone" & string.IsNullOrEmpty(Strings.Trim(rsNoRec.Fields("BClabelItem_Sample").Value))) {
							MySamp = " ";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "Company_Telephone") {
							MySamp = "082 448 3987";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "line") {
							MySamp = " ";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "StockItem_Name" & string.IsNullOrEmpty(Strings.Trim(rsNoRec.Fields("BClabelItem_Sample").Value))) {
							MySamp = " ";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "StockItem_Name") {
							MySamp = "Default Stock Item Name";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "code") {
							MySamp = " ";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "Catalogue_Barcode" & string.IsNullOrEmpty(Strings.Trim(rsNoRec.Fields("BClabelItem_Sample").Value))) {
							MySamp = " ";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "Catalogue_Barcode") {
							MySamp = "6001060071416";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "PricingGroup_Name" & string.IsNullOrEmpty(Strings.Trim(rsNoRec.Fields("BClabelItem_Sample").Value))) {
							MySamp = " ";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "PricingGroup_Name") {
							MySamp = "Beer Local";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "Price" & string.IsNullOrEmpty(Strings.Trim(rsNoRec.Fields("BClabelItem_Sample").Value))) {
							MySamp = " ";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "Price") {
							MySamp = "R 21.99";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "Price6") {
							MySamp = "R 21.99 for   6";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "Price12") {
							MySamp = "R 21.99 for  12";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "Price24") {
							MySamp = "R 21.99 for  24";

						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "blank") {
							MySamp = " ";
						}

						//if field is equal to code the sample is space
						if (rsNoRec.Fields("BClabelItem_Field").Value == "code") {
							TheNames1 = " ";
						//if the field is equal to line the sample is space
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "line") {
							TheNames1 = " ";
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "blank") {
							TheNames1 = " ";
						} else {
							if (modApplication.TheNames == "line") {
								TheNames1 = " ";
							} else {
								TheNames1 = rsNoRec.Fields("BClabelItem_Sample").Value;
							}
						}
						//if field is equal to code
						if (rsNoRec.Fields("BClabelItem_Field").Value == "code") {
							rs = modRecordSet.getRS(ref "INSERT INTO LabelItem(labelItem_LabelID,labelItem_Line,labelItem_Field,labelItem_Align,labelItem_Size,labelItem_Bold,labelItem_Sample) VALUES (" + HoldMyLaID + "," + rsNoRec.Fields("BClabelItem_Line").Value + ",'code'," + rsNoRec.Fields("BClabelItem_Align").Value + "," + rsNoRec.Fields("BClabelItem_Size").Value + "," + rsNoRec.Fields("BClabelItem_Bold").Value + ",'" + TheNames1 + "')");
						//if field is equal to line
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "line") {
							rs = modRecordSet.getRS(ref "INSERT INTO LabelItem(labelItem_LabelID,labelItem_Line,labelItem_Field,labelItem_Align,labelItem_Size,labelItem_Bold,labelItem_Sample) VALUES (" + HoldMyLaID + "," + rsNoRec.Fields("BClabelItem_Line").Value + ",'line'," + rsNoRec.Fields("BClabelItem_Align").Value + "," + rsNoRec.Fields("BClabelItem_Size").Value + "," + rsNoRec.Fields("BClabelItem_Bold").Value + ",'" + TheNames1 + "')");
							//****
							//New code for Blank
						//if field is equal to line
						} else if (rsNoRec.Fields("BClabelItem_Field").Value == "blank") {
							rs = modRecordSet.getRS(ref "INSERT INTO LabelItem(labelItem_LabelID,labelItem_Line,labelItem_Field,labelItem_Align,labelItem_Size,labelItem_Bold,labelItem_Sample) VALUES (" + HoldMyLaID + "," + rsNoRec.Fields("BClabelItem_Line").Value + ",'blank'," + rsNoRec.Fields("BClabelItem_Align").Value + "," + rsNoRec.Fields("BClabelItem_Size").Value + "," + rsNoRec.Fields("BClabelItem_Bold").Value + ",'" + TheNames1 + "')");
							//****
						} else {
							rs = modRecordSet.getRS(ref "INSERT INTO LabelItem(labelItem_LabelID,labelItem_Line,labelItem_Field,labelItem_Align,labelItem_Size,labelItem_Bold,labelItem_Sample) VALUES (" + HoldMyLaID + "," + rsNoRec.Fields("BClabelItem_Line").Value + ",'" + rsNoRec.Fields("BClabelItem_Field").Value + "'," + rsNoRec.Fields("BClabelItem_Align").Value + "," + rsNoRec.Fields("BClabelItem_Size").Value + "," + rsNoRec.Fields("BClabelItem_Bold").Value + ",'" + MySamp + "')");
						}
						rsNoRec.MoveNext();
					}

					//updating
				}

			} else if (string.IsNullOrEmpty(Strings.Trim(MyInputStr))) {
				return;
			}
			//refreshes

			modApplication.TheSelectedPrinterNew = 2;
			modApplication.NewLabelName = "";
			labelsfile();
			//RecSel1 = 3
			//Unload frmPrinter
			//frmPrinter.selectPrinter
			//frmBarcodedesign.TheLoading
			//TheSelectedPrinterNew = 0

		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//On Error GoTo ErrH
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rst = default(ADODB.Recordset);
			ADODB.Recordset rsHave = default(ADODB.Recordset);
			ADODB.Recordset rsMaxID = default(ADODB.Recordset);
			short HoldBClabelItem_BCLabelID = 0;
			string TheSample = null;
			ADODB.Recordset rsInner = default(ADODB.Recordset);
			short HoldLaIDVaBack = 0;
			short TMaxID = 0;

			rs = new ADODB.Recordset();
			rst = new ADODB.Recordset();
			rsHave = new ADODB.Recordset();
			rsInner = new ADODB.Recordset();
			rsMaxID = new ADODB.Recordset();

			modApplication.IntDesign = 0;
			//New code

			rs = modRecordSet.getRS(ref "DELETE * FROM BClabelItemUndo");

			strheight = 0;
			strwidht = 0;

			rs = modRecordSet.getRS(ref "SELECT * FROM LabelItem WHERE labelItem_LabelID=" + modApplication.MyLIDWHole + "");


			if (rs.RecordCount == 1) {
				rs = modRecordSet.getRS(ref "DELETE * FROM LabelItem WHERE labelItem_LabelID=" + modApplication.MyLIDWHole + "");
				rs = modRecordSet.getRS(ref "DELETE * FROM Label WHERE LabelID=" + modApplication.MyLIDWHole + "");
				rs = modRecordSet.getRS(ref "DELETE * FROM BClabel WHERE BClabel_LabelID=" + modApplication.MyLIDWHole + "");
				rs = modRecordSet.getRS(ref "DELETE * FROM BClabelItem WHERE BClabelItem_LabelID=" + modApplication.MyLIDWHole + "");
				this.Close();
				My.MyProject.Forms.frmDesign.RefreshLoad(ref modApplication.TheType);
				return;


			} else {
			}

			rs = modRecordSet.getRS(ref "SELECT Max(LabelItem.labelItem_LabelID) as TheMaxID FROM LabelItem");
			TMaxID = rs.Fields("TheMaxID").Value;

			rs = modRecordSet.getRS(ref "SELECT * FROM LabelItem ORDER BY labelItem_LabelID");

			rs.MoveFirst();
			//Loading BClabelItem with Infor from LabelItem
			while (!(rs.EOF)) {
				 // ERROR: Not supported in C#: OnErrorStatement

				rsHave = modRecordSet.getRS(ref "SELECT * FROM BClabelItem WHERE BClabelItem_LabelID=" + rs.Fields("labelItem_LabelID").Value + "");
				HoldBClabelItem_BCLabelID = rsHave.Fields("BClabelItem_BCLabelID").Value;

				rst = modRecordSet.getRS(ref "DELETE * FROM BClabelItem WHERE BClabelItem_LabelID =" + rs.Fields("labelItem_LabelID").Value + "");

				rsInner = modRecordSet.getRS(ref "SELECT * FROM LabelItem WHERE labelItem_LabelID=" + rs.Fields("labelItem_LabelID").Value + "");
				while (!(rsInner.EOF)) {
					if (Information.IsDBNull(rsInner.Fields("labelItem_Sample").Value)) {
						TheSample = " ";
					} else {
						TheSample = rsInner.Fields("labelItem_Sample").Value;
					}
					rst = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + HoldBClabelItem_BCLabelID + "," + rsInner.Fields("labelItem_Line").Value + ",'" + rsInner.Fields("labelItem_Field").Value + "'," + rsInner.Fields("labelItem_Align").Value + "," + rsInner.Fields("labelItem_Size").Value + "," + rsInner.Fields("labelItem_Bold").Value + ",'" + TheSample + "','" + 0 + "'," + rsInner.Fields("labelItem_LabelID").Value + ")");
					rsInner.MoveNext();
				}

				HoldLaIDVaBack = rs.Fields("labelItem_LabelID").Value;
				rs.MoveNext();


				while (!(rs.Fields("labelItem_LabelID").Value != HoldLaIDVaBack)) {
					if (rs.Fields("labelItem_LabelID").Value == TMaxID) {
						rs.MoveLast();
						rs.MoveNext();
						break; // TODO: might not be correct. Was : Exit Do
					}

					rs.MoveNext();
				}

			}

			this.Close();
			My.MyProject.Forms.frmDesign.RefreshLoad(ref modApplication.TheType);
			//ErrH:    frmDesign.RefreshLoad TheType

			//frmdesign.RefreshLoad TheType
		}

		private void cmdLoad_Click()
		{
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			string strname = null;

			this.ShowDialog();

		}

		private void cmdnormal_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim rs As ADODB.Recordset
			//Dim rst As ADODB.Recordset
			//Dim TheSam As String
			//Set rs = New ADODB.Recordset
			//Set rst = New ADODB.Recordset

			//Set rs = getRS("DELETE * FROM BClabel")
			//Set rs = getRS("DELETE * FROM BClabelItem")

			//Set rst = getRS("SELECT * FROM BClabelNormal")

			//Do Until rst.EOF
			//Set rs = getRS("INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height)VALUES(" & rst("BClabelID") & ",'" & rst("BClabel_Name") & "','" & rst("BClabel_Type") & "'," & rst("BClabel_Disabled") & "," & rst("BClabel_Height") & ")")

			//rst.MoveNext
			//Loop

			//Set rst = getRS("SELECT * FROM BClabelItemNormal")'

			//Do Until rst.EOF
			//    If IsNull(rst("BClabelItem_Sample")) Then
			//    TheSam = " "
			//    Else
			//    TheSam = rst("BClabelItem_Sample")
			//    End If
			//Set rs = getRS("INSERT INTO BClabelItem(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & rst("BClabelItemID") & "," & rst("BClabelItem_BCLabelID") & "," & rst("BClabelItem_Line") & ",'" & rst("BClabelItem_Field") & "'," & rst("BClabelItem_Align") & "," & rst("BClabelItem_Size") & "," & rst("BClabelItem_Bold") & ",'" & TheSam & " '," & rst("BClabelItem_Disabled") & "," & MyLIDWHole & ")")

			//rst.MoveNext
			//Loop

			//TheSelectedPrinterNew = 2

			//labelsfile
		}

		private void cmdOffset_Click()
		{
			//Dim frm As New frmBarcodeOffset
			//frm.Show(1)
		}

		private void cmdSave_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rst = default(ADODB.Recordset);
			short RecSel1 = 0;
			string TheSpacess = null;
			string MyLines = null;
			rs = new ADODB.Recordset();
			rst = new ADODB.Recordset();
			ADODB.Recordset rsMax = default(ADODB.Recordset);
			short ThePosition = 0;
			short TheCode = 0;
			ADODB.Recordset rsDet = default(ADODB.Recordset);
			rsMax = new ADODB.Recordset();
			rsDet = new ADODB.Recordset();


			//If Not IsNumeric(Me.txtpos.Text) Then
			//    MsgBox "Row Position Must be a Number.", vbInformation, "4Pos Back Office"
			//Exit Sub
			//Else
			//End If


			//for a sample of the selected field
			//Designing barcodes
			if (modApplication.TheNames == "Price") {
				TheSpacess = "R 21.99";
				//And rsT.RecordCount < 1 Then
				if (_chkFields_4.CheckState == 1) {

					if (this._chkFields_0.CheckState == 1) {
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 1 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + " )");
						rsDet = modRecordSet.getRS(ref "SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem");
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("TheLastDe").Value + "," + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 1 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
					} else {
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 0 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + " )");
						rsDet = modRecordSet.getRS(ref "SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem");
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("TheLastDe").Value + "," + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 0 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
					}

					//ElseIf _chkFields_4.value = 1 And rsT.RecordCount > 0 Then
					//Set rs = getRS("UPDATE BClabelItem SET BClabelItem_Line=" & ThePosition & ",BClabelItem_Field='" & TheNames & "',BClabelItem_Align=" & MyFAlign & ",BClabelItem_Size=" & Me.cmbfont.Text & ",BClabelItem_Sample='" & TheSpacess & "',BClabelItem_Disabled='" & 0 & "' WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
				} else if (_chkFields_4.CheckState == 0) {
					//Set rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
					rsDet = modRecordSet.getRS(ref "SELECT * FROM BClabelItem WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "'");
					rsDet.MoveFirst();
					rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("BClabelItemID").Value + "," + modApplication.RecSel + "," + rsDet.Fields("BClabelItem_Line").Value + ",'" + modApplication.TheNames + "'," + rsDet.Fields("BClabelItem_Align").Value + "," + rsDet.Fields("BClabelItem_Size").Value + "," + rsDet.Fields("BClabelItem_Bold").Value + ",'" + TheSpacess + "'," + rsDet.Fields("BClabelItem_Disabled").Value + "," + modApplication.MyLIDWHole + ")");
					rs = modRecordSet.getRS(ref "DELETE * FROM BClabelItem WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "' and BClabelItemID=" + rsDet.Fields("BClabelItemID").Value + "");
				}

			//Designing barcodes
			} else if (modApplication.TheNames == "Price6") {
				TheSpacess = "R 21.99 for   6";
				//And rsT.RecordCount < 1 Then
				if (_chkFields_4.CheckState == 1) {

					if (this._chkFields_0.CheckState == 1) {
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 1 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + " )");
						rsDet = modRecordSet.getRS(ref "SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem");
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("TheLastDe").Value + "," + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 1 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
					} else {
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 0 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + " )");
						rsDet = modRecordSet.getRS(ref "SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem");
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("TheLastDe").Value + "," + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 0 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
					}

					//ElseIf _chkFields_4.value = 1 And rsT.RecordCount > 0 Then
					//Set rs = getRS("UPDATE BClabelItem SET BClabelItem_Line=" & ThePosition & ",BClabelItem_Field='" & TheNames & "',BClabelItem_Align=" & MyFAlign & ",BClabelItem_Size=" & Me.cmbfont.Text & ",BClabelItem_Sample='" & TheSpacess & "',BClabelItem_Disabled='" & 0 & "' WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
				} else if (_chkFields_4.CheckState == 0) {
					//Set rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
					rsDet = modRecordSet.getRS(ref "SELECT * FROM BClabelItem WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "'");
					rsDet.MoveFirst();
					rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("BClabelItemID").Value + "," + modApplication.RecSel + "," + rsDet.Fields("BClabelItem_Line").Value + ",'" + modApplication.TheNames + "'," + rsDet.Fields("BClabelItem_Align").Value + "," + rsDet.Fields("BClabelItem_Size").Value + "," + rsDet.Fields("BClabelItem_Bold").Value + ",'" + TheSpacess + "'," + rsDet.Fields("BClabelItem_Disabled").Value + "," + modApplication.MyLIDWHole + ")");
					rs = modRecordSet.getRS(ref "DELETE * FROM BClabelItem WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "' and BClabelItemID=" + rsDet.Fields("BClabelItemID").Value + "");
				}

			//Designing barcodes
			} else if (modApplication.TheNames == "Price12") {
				TheSpacess = "R 21.99 for  12";
				//And rsT.RecordCount < 1 Then
				if (_chkFields_4.CheckState == 1) {

					if (this._chkFields_0.CheckState == 1) {
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 1 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + " )");
						rsDet = modRecordSet.getRS(ref "SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem");
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("TheLastDe").Value + "," + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 1 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
					} else {
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 0 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + " )");
						rsDet = modRecordSet.getRS(ref "SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem");
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("TheLastDe").Value + "," + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 0 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
					}

					//ElseIf _chkFields_4.value = 1 And rsT.RecordCount > 0 Then
					//Set rs = getRS("UPDATE BClabelItem SET BClabelItem_Line=" & ThePosition & ",BClabelItem_Field='" & TheNames & "',BClabelItem_Align=" & MyFAlign & ",BClabelItem_Size=" & Me.cmbfont.Text & ",BClabelItem_Sample='" & TheSpacess & "',BClabelItem_Disabled='" & 0 & "' WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
				} else if (_chkFields_4.CheckState == 0) {
					//Set rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
					rsDet = modRecordSet.getRS(ref "SELECT * FROM BClabelItem WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "'");
					rsDet.MoveFirst();
					rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("BClabelItemID").Value + "," + modApplication.RecSel + "," + rsDet.Fields("BClabelItem_Line").Value + ",'" + modApplication.TheNames + "'," + rsDet.Fields("BClabelItem_Align").Value + "," + rsDet.Fields("BClabelItem_Size").Value + "," + rsDet.Fields("BClabelItem_Bold").Value + ",'" + TheSpacess + "'," + rsDet.Fields("BClabelItem_Disabled").Value + "," + modApplication.MyLIDWHole + ")");
					rs = modRecordSet.getRS(ref "DELETE * FROM BClabelItem WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "' and BClabelItemID=" + rsDet.Fields("BClabelItemID").Value + "");
				}

			//Designing barcodes
			} else if (modApplication.TheNames == "Price24") {
				TheSpacess = "R 21.99 for  24";
				//And rsT.RecordCount < 1 Then
				if (_chkFields_4.CheckState == 1) {

					if (this._chkFields_0.CheckState == 1) {
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 1 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + " )");
						rsDet = modRecordSet.getRS(ref "SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem");
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("TheLastDe").Value + "," + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 1 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
					} else {
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 0 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + " )");
						rsDet = modRecordSet.getRS(ref "SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem");
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("TheLastDe").Value + "," + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 0 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
					}

					//ElseIf _chkFields_4.value = 1 And rsT.RecordCount > 0 Then
					//Set rs = getRS("UPDATE BClabelItem SET BClabelItem_Line=" & ThePosition & ",BClabelItem_Field='" & TheNames & "',BClabelItem_Align=" & MyFAlign & ",BClabelItem_Size=" & Me.cmbfont.Text & ",BClabelItem_Sample='" & TheSpacess & "',BClabelItem_Disabled='" & 0 & "' WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
				} else if (_chkFields_4.CheckState == 0) {
					//Set rsDet = getRS("SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem")
					rsDet = modRecordSet.getRS(ref "SELECT * FROM BClabelItem WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "'");
					rsDet.MoveFirst();
					rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("BClabelItemID").Value + "," + modApplication.RecSel + "," + rsDet.Fields("BClabelItem_Line").Value + ",'" + modApplication.TheNames + "'," + rsDet.Fields("BClabelItem_Align").Value + "," + rsDet.Fields("BClabelItem_Size").Value + "," + rsDet.Fields("BClabelItem_Bold").Value + ",'" + TheSpacess + "'," + rsDet.Fields("BClabelItem_Disabled").Value + "," + modApplication.MyLIDWHole + ")");
					rs = modRecordSet.getRS(ref "DELETE * FROM BClabelItem WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "' and BClabelItemID=" + rsDet.Fields("BClabelItemID").Value + "");
				}

			} else if (modApplication.TheNames == "Company_Name") {
				TheSpacess = "4POS Demo";
				//And rsT.RecordCount < 1 Then
				if (_chkFields_4.CheckState == 1) {
					if (this._chkFields_0.CheckState == 1) {
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 1 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
						rsDet = modRecordSet.getRS(ref "SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem");
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("TheLastDe").Value + "," + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 1 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
					} else {
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 0 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
						rsDet = modRecordSet.getRS(ref "SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem");
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("TheLastDe").Value + "," + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 0 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
					}

					//ElseIf _chkFields_4.value = 1 And rsT.RecordCount > 0 Then
					//Set rs = getRS("UPDATE BClabelItem SET BClabelItem_Line=" & ThePosition & ",BClabelItem_Field='" & TheNames & "',BClabelItem_Align=" & MyFAlign & ",BClabelItem_Size=" & Me.cmbfont.Text & ",BClabelItem_Sample='" & TheSpacess & "',BClabelItem_Disabled='" & 0 & "' WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
				} else if (_chkFields_4.CheckState == 0) {
					rsDet = modRecordSet.getRS(ref "SELECT * FROM BClabelItem WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "'");
					rsDet.MoveFirst();
					rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("BClabelItemID").Value + "," + modApplication.RecSel + "," + rsDet.Fields("BClabelItem_Line").Value + ",'" + modApplication.TheNames + "'," + rsDet.Fields("BClabelItem_Align").Value + "," + rsDet.Fields("BClabelItem_Size").Value + "," + rsDet.Fields("BClabelItem_Bold").Value + ",'" + TheSpacess + "'," + rsDet.Fields("BClabelItem_Disabled").Value + "," + modApplication.MyLIDWHole + ")");
					rs = modRecordSet.getRS(ref "DELETE * FROM BClabelItem WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "' and BClabelItemID=" + rsDet.Fields("BClabelItemID").Value + "");
				}

			} else if (modApplication.TheNames == "StockItem_Name") {
				TheSpacess = "Default Stock Item Name";
				//And rsT.RecordCount < 1 Then
				if (_chkFields_4.CheckState == 1) {

					if (this._chkFields_0.CheckState == 1) {
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 1 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
						rsDet = modRecordSet.getRS(ref "SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem");
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("TheLastDe").Value + "," + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 1 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
					} else {
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 0 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
						rsDet = modRecordSet.getRS(ref "SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem");
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("TheLastDe").Value + "," + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 0 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
					}

					//ElseIf _chkFields_4.value = 1 And rsT.RecordCount > 0 Then
					//Set rs = getRS("UPDATE BClabelItem SET BClabelItem_Line=" & ThePosition & ",BClabelItem_Field='" & TheNames & "',BClabelItem_Align=" & MyFAlign & ",BClabelItem_Size=" & Me.cmbfont.Text & ",BClabelItem_Sample='" & TheSpacess & "',BClabelItem_Disabled='" & 0 & "' WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
				} else if (_chkFields_4.CheckState == 0) {
					rsDet = modRecordSet.getRS(ref "SELECT * FROM BClabelItem WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "'");
					rsDet.MoveFirst();

					rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("BClabelItemID").Value + "," + modApplication.RecSel + "," + rsDet.Fields("BClabelItem_Line").Value + ",'" + modApplication.TheNames + "'," + rsDet.Fields("BClabelItem_Align").Value + "," + rsDet.Fields("BClabelItem_Size").Value + "," + rsDet.Fields("BClabelItem_Bold").Value + ",'" + TheSpacess + "'," + rsDet.Fields("BClabelItem_Disabled").Value + "," + modApplication.MyLIDWHole + ")");
					rs = modRecordSet.getRS(ref "DELETE * FROM BClabelItem WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "' and BClabelItemID=" + rsDet.Fields("BClabelItemID").Value + "");
				}

			} else if (modApplication.TheNames == "Catalogue_Barcode") {
				TheSpacess = "6001060071416";
				//And rsT.RecordCount < 1 Then
				if (_chkFields_4.CheckState == 1) {
					if (this._chkFields_0.CheckState == 1) {
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 1 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
						rsDet = modRecordSet.getRS(ref "SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem");
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("TheLastDe").Value + "," + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 1 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
					} else {
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 0 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
						rsDet = modRecordSet.getRS(ref "SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem");
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("TheLastDe").Value + "," + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 0 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
					}

					//ElseIf _chkFields_4.value = 1 And rsT.RecordCount > 0 Then
					//Set rs = getRS("UPDATE BClabelItem SET BClabelItem_Line=" & ThePosition & ",BClabelItem_Field='" & TheNames & "',BClabelItem_Align=" & MyFAlign & ",BClabelItem_Size=" & Me.cmbfont.Text & ",BClabelItem_Sample='" & TheSpacess & "',BClabelItem_Disabled='" & 0 & "' WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
				} else if (_chkFields_4.CheckState == 0) {
					rsDet = modRecordSet.getRS(ref "SELECT * FROM BClabelItem WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "'");
					rsDet.MoveFirst();
					rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("BClabelItemID").Value + "," + modApplication.RecSel + "," + rsDet.Fields("BClabelItem_Line").Value + ",'" + modApplication.TheNames + "'," + rsDet.Fields("BClabelItem_Align").Value + "," + rsDet.Fields("BClabelItem_Size").Value + "," + rsDet.Fields("BClabelItem_Bold").Value + ",'" + TheSpacess + "'," + rsDet.Fields("BClabelItem_Disabled").Value + "," + modApplication.MyLIDWHole + ")");
					rs = modRecordSet.getRS(ref "DELETE * FROM BClabelItem WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "' and BClabelItemID=" + rsDet.Fields("BClabelItemID").Value + "");
				}

			} else if (modApplication.TheNames == "Company_Telephone") {
				TheSpacess = "082 448 3987";
				//And rsT.RecordCount < 1 Then
				if (_chkFields_4.CheckState == 1) {
					if (this._chkFields_0.CheckState == 1) {
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 1 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
						rsDet = modRecordSet.getRS(ref "SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem");
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("TheLastDe").Value + "," + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 1 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
					} else {
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 0 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
						rsDet = modRecordSet.getRS(ref "SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem");
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("TheLastDe").Value + "," + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 0 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
					}

					//ElseIf _chkFields_4.value = 1 And rsT.RecordCount > 0 Then
					//    Set rs = getRS("UPDATE BClabelItem SET BClabelItem_Line=" & ThePosition & ",BClabelItem_Field='" & TheNames & "',BClabelItem_Align=" & MyFAlign & ",BClabelItem_Size=" & Me.cmbfont.Text & ",BClabelItem_Sample='" & TheSpacess & "',BClabelItem_Disabled='" & 0 & "' WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
				} else if (_chkFields_4.CheckState == 0) {
					rsDet = modRecordSet.getRS(ref "SELECT * FROM BClabelItem WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "'");
					rsDet.MoveFirst();
					rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("BClabelItemID").Value + "," + modApplication.RecSel + "," + rsDet.Fields("BClabelItem_Line").Value + ",'" + modApplication.TheNames + "'," + rsDet.Fields("BClabelItem_Align").Value + "," + rsDet.Fields("BClabelItem_Size").Value + "," + rsDet.Fields("BClabelItem_Bold").Value + ",'" + TheSpacess + "'," + rsDet.Fields("BClabelItem_Disabled").Value + "," + modApplication.MyLIDWHole + ")");
					rs = modRecordSet.getRS(ref "DELETE * FROM BClabelItem WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "' and BClabelItemID=" + rsDet.Fields("BClabelItemID").Value + "");
				}

			} else if (modApplication.TheNames == "PricingGroup_Name") {
				TheSpacess = "Beer Local";
				//And rsT.RecordCount < 1 Then
				if (_chkFields_4.CheckState == 1) {
					if (this._chkFields_0.CheckState == 1) {
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 1 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
						rsDet = modRecordSet.getRS(ref "SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem");
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("TheLastDe").Value + "," + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 1 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
					} else {
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 0 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
						rsDet = modRecordSet.getRS(ref "SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem");
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("TheLastDe").Value + "," + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 0 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
					}

					//ElseIf _chkFields_4.value = 1 And rsT.RecordCount > 0 Then
					//Set rs = getRS("UPDATE BClabelItem SET BClabelItem_Line=" & ThePosition & ",BClabelItem_Field='" & TheNames & "',BClabelItem_Align=" & MyFAlign & ",BClabelItem_Size=" & Me.cmbfont.Text & ",BClabelItem_Sample='" & TheSpacess & "',BClabelItem_Disabled='" & 0 & "' WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
				} else if (_chkFields_4.CheckState == 0) {
					rsDet = modRecordSet.getRS(ref "SELECT * FROM BClabelItem WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "'");
					rsDet.MoveFirst();
					rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("BClabelItemID").Value + "," + modApplication.RecSel + "," + rsDet.Fields("BClabelItem_Line").Value + ",'" + modApplication.TheNames + "'," + rsDet.Fields("BClabelItem_Align").Value + "," + rsDet.Fields("BClabelItem_Size").Value + "," + rsDet.Fields("BClabelItem_Bold").Value + ",'" + TheSpacess + "'," + rsDet.Fields("BClabelItem_Disabled").Value + "," + modApplication.MyLIDWHole + ")");
					rs = modRecordSet.getRS(ref "DELETE * FROM BClabelItem WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "' and BClabelItemID=" + rsDet.Fields("BClabelItemID").Value + "");
				}

			} else if (modApplication.TheNames == "line") {
				TheSpacess = " ";
				//And rsT.RecordCount < 1 Then
				if (_chkFields_4.CheckState == 1) {
					if (this._chkFields_0.CheckState == 1) {
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 1 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
						rsDet = modRecordSet.getRS(ref "SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem");
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("TheLastDe").Value + "," + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 1 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
					} else {
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 0 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
						rsDet = modRecordSet.getRS(ref "SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem");
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("TheLastDe").Value + "," + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 0 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
					}

					//ElseIf _chkFields_4.value = 1 And rsT.RecordCount > 0 Then
					//Set rs = getRS("UPDATE BClabelItem SET BClabelItem_Line=" & ThePosition & ",BClabelItem_Field='" & TheNames & "',BClabelItem_Align=" & MyFAlign & ",BClabelItem_Size=" & Me.cmbfont.Text & ",BClabelItem_Sample='" & TheSpacess & "',BClabelItem_Disabled='" & 0 & "' WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
				} else if (_chkFields_4.CheckState == 0) {
					rsDet = modRecordSet.getRS(ref "SELECT * FROM BClabelItem WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "'");
					rsDet.MoveFirst();
					rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("BClabelItemID").Value + "," + modApplication.RecSel + "," + rsDet.Fields("BClabelItem_Line").Value + ",'" + modApplication.TheNames + "'," + rsDet.Fields("BClabelItem_Align").Value + "," + rsDet.Fields("BClabelItem_Size").Value + "," + rsDet.Fields("BClabelItem_Bold").Value + ",'" + TheSpacess + "'," + rsDet.Fields("BClabelItem_Disabled").Value + "," + modApplication.MyLIDWHole + ")");
					rs = modRecordSet.getRS(ref "DELETE * FROM BClabelItem WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "' and BClabelItemID=" + rsDet.Fields("BClabelItemID").Value + "");
				}

				//*****
				//Blank
			} else if (modApplication.TheNames == "blank") {
				TheSpacess = " ";
				//And rsT.RecordCount < 1 Then
				if (_chkFields_4.CheckState == 1) {
					if (this._chkFields_0.CheckState == 1) {
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 1 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
						rsDet = modRecordSet.getRS(ref "SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem");
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("TheLastDe").Value + "," + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 1 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
					} else {
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 0 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
						rsDet = modRecordSet.getRS(ref "SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem");
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("TheLastDe").Value + "," + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 0 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
					}

					//ElseIf _chkFields_4.value = 1 And rsT.RecordCount > 0 Then
					//Set rs = getRS("UPDATE BClabelItem SET BClabelItem_Line=" & ThePosition & ",BClabelItem_Field='" & TheNames & "',BClabelItem_Align=" & MyFAlign & ",BClabelItem_Size=" & Me.cmbfont.Text & ",BClabelItem_Sample='" & TheSpacess & "',BClabelItem_Disabled='" & 0 & "' WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
				} else if (_chkFields_4.CheckState == 0) {
					rsDet = modRecordSet.getRS(ref "SELECT * FROM BClabelItem WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "'");
					rsDet.MoveFirst();
					rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("BClabelItemID").Value + "," + modApplication.RecSel + "," + rsDet.Fields("BClabelItem_Line").Value + ",'" + modApplication.TheNames + "'," + rsDet.Fields("BClabelItem_Align").Value + "," + rsDet.Fields("BClabelItem_Size").Value + "," + rsDet.Fields("BClabelItem_Bold").Value + ",'" + TheSpacess + "'," + rsDet.Fields("BClabelItem_Disabled").Value + "," + modApplication.MyLIDWHole + ")");
					rs = modRecordSet.getRS(ref "DELETE * FROM BClabelItem WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "' and BClabelItemID=" + rsDet.Fields("BClabelItemID").Value + "");
				}
				//****


			} else if (modApplication.TheNames == "code") {
				if (Convert.ToDouble(this.txtpos.Text) == -2) {
					TheCode = 50;
				} else if (Convert.ToDouble(this.txtpos.Text) == 0) {
					TheCode = 50;
				} else if (Convert.ToDouble(this.txtpos.Text) == 1) {
					TheCode = 45;
				} else if (Convert.ToDouble(this.txtpos.Text) == 2) {
					TheCode = 40;
				} else if (Convert.ToDouble(this.txtpos.Text) == 3) {
					TheCode = 35;
				} else if (Convert.ToDouble(this.txtpos.Text) == 4) {
					TheCode = 30;
				} else if (Convert.ToDouble(this.txtpos.Text) == 5) {
					TheCode = 25;
				} else if (Convert.ToDouble(this.txtpos.Text) == 6) {
					TheCode = 20;
				} else if (Convert.ToDouble(this.txtpos.Text) == 7) {
					TheCode = 15;
				} else if (Convert.ToDouble(this.txtpos.Text) == 8) {
					TheCode = 10;
				} else if (Convert.ToDouble(this.txtpos.Text) == 7) {
					TheCode = 5;
				} else if (Convert.ToDouble(this.txtpos.Text) == 8) {
					TheCode = 0;
				}

				//Set rs = getRS("UPDATE BClabel SET BClabel_Height=" & TheCode & " WHERE BClabelID=" & RecSel & "")

				TheSpacess = " ";
				//And rsT.RecordCount < 1 Then
				if (_chkFields_4.CheckState == 1) {
					if (this._chkFields_0.CheckState == 1) {
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 1 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
						rsDet = modRecordSet.getRS(ref "SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem");
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("TheLastDe").Value + "," + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 1 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
					} else {
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 0 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
						rsDet = modRecordSet.getRS(ref "SELECT Max(BClabelItem.BClabelItemID) as TheLastDe FROM BClabelItem");
						rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("TheLastDe").Value + "," + modApplication.RecSel + "," + this.txtpos.Text + ",'" + modApplication.TheNames + "'," + modApplication.MyFAlign + "," + this.cmbfont.Text + ",'" + 0 + "','" + TheSpacess + "','" + 0 + "'," + modApplication.MyLIDWHole + ")");
					}

					if (Convert.ToDouble(this.txtpos.Text) == -2) {
						rs = modRecordSet.getRS(ref "UPDATE BClabel SET BClabel_Height=" + 50 + " WHERE BClabelID=" + modApplication.RecSel + "");
					} else if (Convert.ToDouble(this.txtpos.Text) == 0) {
						rs = modRecordSet.getRS(ref "UPDATE BClabel SET BClabel_Height=" + 40 + " WHERE BClabelID=" + modApplication.RecSel + "");
					} else if (Convert.ToDouble(this.txtpos.Text) == 2) {
						rs = modRecordSet.getRS(ref "UPDATE BClabel SET BClabel_Height=" + 40 + " WHERE BClabelID=" + modApplication.RecSel + "");
					} else if (Convert.ToDouble(this.txtpos.Text) == 3) {
						rs = modRecordSet.getRS(ref "UPDATE BClabel SET BClabel_Height=" + 35 + " WHERE BClabelID=" + modApplication.RecSel + "");
					} else if (Convert.ToDouble(this.txtpos.Text) == 4) {
						rs = modRecordSet.getRS(ref "UPDATE BClabel SET BClabel_Height=" + 30 + " WHERE BClabelID=" + modApplication.RecSel + "");
					} else if (Convert.ToDouble(this.txtpos.Text) == 5) {
						rs = modRecordSet.getRS(ref "UPDATE BClabel SET BClabel_Height=" + 20 + " WHERE BClabelID=" + modApplication.RecSel + "");
					} else if (Convert.ToDouble(this.txtpos.Text) == 6) {
						rs = modRecordSet.getRS(ref "UPDATE BClabel SET BClabel_Height=" + 10 + " WHERE BClabelID=" + modApplication.RecSel + "");
					} else if (Convert.ToDouble(this.txtpos.Text) == 7) {
						rs = modRecordSet.getRS(ref "UPDATE BClabel SET BClabel_Height=" + 0 + " WHERE BClabelID=" + modApplication.RecSel + "");
					}
					//ElseIf _chkFields_4.value = 1 And rsT.RecordCount > 0 Then
					//Set rs = getRS("UPDATE BClabelItem SET BClabelItem_Line=" & ThePosition & ",BClabelItem_Field='" & TheNames & "',BClabelItem_Align=" & MyFAlign & ",BClabelItem_Size=" & Me.cmbfont.Text & ",BClabelItem_Sample='" & TheSpacess & "',BClabelItem_Disabled='" & 0 & "' WHERE BClabelItem_BCLabelID=" & RecSel & " AND BClabelItem_Field='" & TheNames & "'")
				} else if (_chkFields_4.CheckState == 0) {
					//Set rs = getRS("INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" & RecSel & "," & Me.txtpos.Text & ",'" & TheNames & "'," & MyFAlign & "," & Me.cmbfont.Text & ",'" & 1 & "','" & TheSpacess & "','" & 0 & "'," & MyLIDWHole & ")")

					rsDet = modRecordSet.getRS(ref "SELECT * FROM BClabelItem WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "'");

					rsDet.MoveFirst();
					rs = modRecordSet.getRS(ref "INSERT INTO BClabelItemUndo(BClabelItemID,BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rsDet.Fields("BClabelItemID").Value + "," + modApplication.RecSel + "," + rsDet.Fields("BClabelItem_Line").Value + ",'" + modApplication.TheNames + "'," + rsDet.Fields("BClabelItem_Align").Value + "," + rsDet.Fields("BClabelItem_Size").Value + "," + rsDet.Fields("BClabelItem_Bold").Value + ",'" + TheSpacess + "'," + rsDet.Fields("BClabelItem_Disabled").Value + "," + modApplication.MyLIDWHole + ")");
					rs = modRecordSet.getRS(ref "DELETE * FROM BClabelItem WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "' and BClabelItemID=" + rsDet.Fields("BClabelItemID").Value + "");
				}

			}

			modApplication.TheSelectedPrinterNew = 2;

			labelsfile();

			modApplication.TheSelectedPrinterNew = 0;
		}

		private void cmdUndo_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rst = default(ADODB.Recordset);
			ADODB.Recordset RsCh = default(ADODB.Recordset);
			ADODB.Recordset rsIn = default(ADODB.Recordset);
			rs = new ADODB.Recordset();
			rst = new ADODB.Recordset();
			rsIn = new ADODB.Recordset();

			RsCh = modRecordSet.getRS(ref "SELECT * FROM BClabelItemUndo");

			if (RsCh.RecordCount > 0) {
				rs = modRecordSet.getRS(ref "SELECT * FROM BClabelItemUndo");
				rs.MoveLast();
				rsIn = modRecordSet.getRS(ref "SELECT * FROM BClabelItem WHERE BClabelItemID =" + rs.Fields("BClabelItemID").Value + " AND BClabelItem_Field='" + rs.Fields("BClabelItem_Field").Value + "'");

				if (rsIn.RecordCount > 0) {
					rst = modRecordSet.getRS(ref "DELETE * FROM BClabelItem WHERE BClabelItemID=" + rs.Fields("BClabelItemID").Value + "");

					rst = modRecordSet.getRS(ref "DELETE * FROM BClabelItemUndo WHERE BClabelItemID=" + rs.Fields("BClabelItemID").Value + "");
				} else if (rsIn.RecordCount < 1) {
					rst = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + rs.Fields("BClabelItem_BCLabelID").Value + "," + rs.Fields("BClabelItem_Line").Value + ",'" + rs.Fields("BClabelItem_Field").Value + "'," + rs.Fields("BClabelItem_Align").Value + "," + rs.Fields("BClabelItem_Size").Value + "," + rs.Fields("BClabelItem_Bold").Value + ",'" + rs.Fields("BClabelItem_Sample").Value + "'," + rs.Fields("BClabelItem_Disabled").Value + "," + rs.Fields("BClabelItem_LabelID").Value + ")");
					rst = modRecordSet.getRS(ref "DELETE * FROM BClabelItemUndo WHERE BClabelItemID=" + rs.Fields("BClabelItemID").Value + " and BClabelItem_Field='" + rs.Fields("BClabelItem_Field").Value + "'");
				}

				modApplication.TheSelectedPrinterNew = 2;
				labelsfile();
				//Unload frmPrinter
				//frmPrinter.selectPrinter
				//frmBarcodedesign.TheLoading
				//TheSelectedPrinterNew = 0

				//cmdExit_Click

			} else {
			}

		}

		private void frmBarcodeLoad_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);

			if (KeyAscii == 27) {
				cmdExit_Click(cmdExit, new System.EventArgs());
			} else if (KeyAscii == 13) {
				cmdSave_Click(cmdSave, new System.EventArgs());
			}

			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmBarcodeLoad_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			Option1.AddRange(new RadioButton[] {
				_Option1_0,
				_Option1_1,
				_Option1_2,
				_Option1_3,
				_Option1_4,
				_Option1_5,
				_Option1_6,
				_Option1_7,
				_Option1_8,
				_Option1_9,
				_Option1_10,
				_Option1_11
			});
			Option2.AddRange(new RadioButton[] {
				_Option2_0,
				_Option2_1,
				_Option2_2
			});
			RadioButton rb = new RadioButton();
			foreach (RadioButton rb_loopVariable in Option1) {
				rb = rb_loopVariable;
				rb.CheckedChanged += Option1_CheckedChanged;
			}
			foreach (RadioButton rb_loopVariable in Option2) {
				rb = rb_loopVariable;
				rb.CheckedChanged += Option2_CheckedChanged;
			}
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			//openConnection
			loadLanguage();

			strheight = 0;
			strwidht = 0;

			this.lbldesign.Text = modApplication.SelectLabelName;
			if (modApplication.TheType == 2) {
				this.Text = "Barcode Design";
			} else if (modApplication.TheType == 1) {
				this.Text = "Shelf Talker Design";
			}
			labelsfile();
			strheight = 0;
			strwidht = 0;

			Option1[0].Checked = true;

		}
		private void labelsfile()
		{
			System.Windows.Forms.CheckBox chk6 = new System.Windows.Forms.CheckBox();
			System.Windows.Forms.CheckBox chk5 = new System.Windows.Forms.CheckBox();
			System.Windows.Forms.CheckBox chk4 = new System.Windows.Forms.CheckBox();
			System.Windows.Forms.CheckBox chk3 = new System.Windows.Forms.CheckBox();
			System.Windows.Forms.CheckBox chk2 = new System.Windows.Forms.CheckBox();
			System.Windows.Forms.CheckBox chk1 = new System.Windows.Forms.CheckBox();
			int lValue = 0;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			string strname = null;
			ADODB.Recordset rsNew = default(ADODB.Recordset);

			rsNew = new ADODB.Recordset();

			 // ERROR: Not supported in C#: OnErrorStatement

			//openConnection
			gPersonID = 1;

			//If loadBarcodePrinter() Then
			Debug.Print(gLBLwidth);
			lValue = gLBLwidth;


			rsNew = modRecordSet.getRS(ref "SELECT * FROM Label WHERE LabelID=" + modApplication.MyLIDWHole + " ORDER BY Label_Type,LabelID");
			modApplication.SelectLabelName = rsNew.Fields("Label_Name").Value;
			this.lbldesign.Text = modApplication.SelectLabelName;

			twipsToMM = 57;
			int StHi = 0;
			int StWi = 0;


			while (!(rsNew.EOF)) {
				if (modApplication.TheSelectedPrinterNew != 2) {
					strwidht = rsNew.Fields("Label_Width").Value;
					strheight = rsNew.Fields("Label_Height").Value;
				} else {
					strwidht = this.HSWidth.Value;
					strheight = this.HSHeight.Value;
				}

				_chkFields_0.CheckState = chk1.Checked;
				_chkFields_1.CheckState = chk2.Checked;
				_chkFields_2.CheckState = chk3.Checked;
				_chkFields_3.CheckState = chk4.Checked;
				_chkFields_4.CheckState = chk5.Checked;
				_chkFields_5.CheckState = chk6.Checked;

				modApplication.LaIDHold = rsNew.Fields("LabelID").Value;

				HSHeight.Value = strheight;
				if (modApplication.TheSelectedPrinterNew == 2) {
					HSHeight_Change(0);
				}
				HSWidth.Value = strwidht;
				if (modApplication.TheSelectedPrinterNew == 2) {
					HSHeight_Change(0);
				}
				rsNew.MoveNext();

			}

			modApplication.TheSelectedPrinterNew = 0;
			modApplication.IntDesign = 0;
			Debug.Print(gLBLwidth);

			return;
			errLoad:
			 // ERROR: Not supported in C#: ResumeStatement

			updatte();
		}
		private void updatee()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);

			rs = modRecordSet.getRS(ref "Select BClabelItem.* from BClabelItem");




		}


		private void frmBarcodeLoad_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			//Dim rs As Recordset
			//If gPrinterLabel <> "" Then
			//Set rs = getRS("SELECT Printer.PrinterID From Printer WHERE (((Printer.PrinterID)='" & gPrinterLabel & "'));")
			//If rs.RecordCount Then
			// cnnDB.Execute "UPDATE Printer SET Printer_Offset = " & gOffsetLabel & ", Printer.Printer_BCwidth = " & HSWidth.value & ", Printer.Printer_BCheight = " & HSHeight.value & " WHERE (((Printer.PrinterID)='" & Replace(gPrinterLabel, "'", "''") & "'));"
			//Else
			//cnnDB.Execute "INSERT INTO Printer ( Printer_Offset, Printer_BCwidth, Printer_BCheight, PrinterID ) SELECT " & gOffsetLabel & ", " & HSWidth.value & ", " & HSHeight.value & ", '" & Replace(gPrinterLabel, "'", "''") & "';"
			//End If
			//End If
		}

		private void HSHeight_Change(int newScrollValue)
		{
			HSWidth_Change(0);
		}

		private void HSLeft_Change(int newScrollValue)
		{
			HSWidth_Change(0);
		}

		private void HSselect_Change(int newScrollValue)
		{
			picInner.Left = sizeConvertors.twipsToPixels(0 - newScrollValue, true);
		}

		private void HSTop_Change(int newScrollValue)
		{
			HSWidth_Change(0);
		}

		private void HSWidth_Change(int newScrollValue)
		{
			System.Windows.Forms.PictureBox currentPic = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = new ADODB.Recordset();
			 // ERROR: Not supported in C#: OnErrorStatement

			int Topval = 0;
			lblWidth.Text = Convert.ToString(newScrollValue);
			gLBLwidth = newScrollValue * twipsToMM;
			_picSelect_0.Width = sizeConvertors.twipsToPixels(gLBLwidth, true);
			lblHeight.Text = Convert.ToString(HSHeight.Value);
			gLBLheight = HSHeight.Value * twipsToMM;
			_picSelect_0.Height = sizeConvertors.twipsToPixels(gLBLheight, false);

			//New code
			rs = modRecordSet.getRS(ref "SELECT BClabel.*, Label.* FROM Label INNER JOIN BClabel ON Label.LabelID = BClabel.BClabel_LabelID WHERE BClabelID=" + modApplication.RecSel + "");
			if (modApplication.IntDesign == 1) {
				HSTop.Value = rs.Fields("Label_Top").Value;
				HSLeft.Value = rs.Fields("Label_Left").Value;

			} else {
			}
			//New code end here

			if (HSTop.Value == 0) {
				_picSelect_0.Top = 0;
				lblTop.Text = Convert.ToString(HSTop.Value);
				lblLineNo.Top = sizeConvertors.twipsToPixels(1320, false);
			} else {
				_picSelect_0.Top = sizeConvertors.twipsToPixels(HSTop.Value * twipsToMM, false);
				lblTop.Text = Convert.ToString(HSTop.Value);
				lblLineNo.Top = sizeConvertors.twipsToPixels(1320 + sizeConvertors.pixelToTwips(_picSelect_0.Top, false), false);
			}


			if (HSLeft.Value == 0) {
				_picSelect_0.Left = 0;
				lblLeft.Text = Convert.ToString(HSLeft.Value);
			} else {
				_picSelect_0.Left = sizeConvertors.twipsToPixels(HSLeft.Value * twipsToMM, true);
				lblLeft.Text = Convert.ToString(HSLeft.Value);
			}


			if (modApplication.TheSelectedPrinterNew == 2) {
				CommandNew();
			} else {
				CommandNew();
			}

		}

		private void Option1_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.Checked) {
				int Index = 0;
				RadioButton radio = new RadioButton();
				radio = (RadioButton)eventSender;
				Index = GetIndex.GetIndexer(ref radio, ref Option1);
				ADODB.Recordset rs = default(ADODB.Recordset);
				rs = new ADODB.Recordset();

				if (Option1[1].Checked) {
					modApplication.TheNames = "StockItem_Name";
					rs = modRecordSet.getRS(ref "SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "'");
				} else if (Option1[2].Checked) {
					modApplication.TheNames = "Catalogue_Barcode";
					rs = modRecordSet.getRS(ref "SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "'");
				} else if (Option1[3].Checked) {
					modApplication.TheNames = "Company_Telephone";
					rs = modRecordSet.getRS(ref "SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "'");
				} else if (Option1[4].Checked) {
					modApplication.TheNames = "Price";
					rs = modRecordSet.getRS(ref "SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "'");
				} else if (Option1[0].Checked) {
					modApplication.TheNames = "Company_Name";
					rs = modRecordSet.getRS(ref "SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "'");
				} else if (Option1[5].Checked) {
					modApplication.TheNames = "PricingGroup_Name";
					rs = modRecordSet.getRS(ref "SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "'");
				} else if (Option1[6].Checked) {
					modApplication.TheNames = "line";
					rs = modRecordSet.getRS(ref "SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "'");
				} else if (Option1[7].Checked) {
					modApplication.TheNames = "code";
					rs = modRecordSet.getRS(ref "SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "'");
				} else if (Option1[8].Checked) {
					modApplication.TheNames = "blank";
					rs = modRecordSet.getRS(ref "SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "'");

				} else if (Option1[9].Checked) {
					modApplication.TheNames = "Price6";
					rs = modRecordSet.getRS(ref "SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "'");
				} else if (Option1[10].Checked) {
					modApplication.TheNames = "Price12";
					rs = modRecordSet.getRS(ref "SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "'");
				} else if (Option1[11].Checked) {
					modApplication.TheNames = "Price24";
					rs = modRecordSet.getRS(ref "SELECT * FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID WHERE BClabelItem_BCLabelID=" + modApplication.RecSel + " AND BClabelItem_Field='" + modApplication.TheNames + "'");
				}

				Label7.Text = "Formatting " + modApplication.TheNames;

			}
		}

		private void Option2_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.Checked) {
				//Dim Index As Short = Option2.GetIndex(eventSender)

				if (this.Option2[0].Checked) {
					modApplication.MyFAlign = 1;
				} else if (this.Option2[1].Checked) {
					modApplication.MyFAlign = 0;
				} else if (this.Option2[2].Checked) {
					modApplication.MyFAlign = 2;
				}

			}
		}

		private void printStock(ref int labelID)
		{
			int mm = 0;
			int lline = 0;
			object frmBarcodedesign = null;
			string sql = null;
			System.Drawing.Printing.PrintDocument Printer = new System.Drawing.Printing.PrintDocument();
			System.Drawing.Printing.PrintDocument lObject = new System.Drawing.Printing.PrintDocument();
			int y = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsData = default(ADODB.Recordset);
			lObject = Printer;
			int currentPic = 0;

			string lString1 = null;
			string lString2 = null;

			//Set rsData = getRS("SELECT * FROM BClabelItem INNER JOIN BClabel ON BClabelItem.BClabelItem_BCLabelID = BClabel.BClabelID Where (((BClabel.BClabelID) = " & labelID & ")) ORDER BY BClabel.BClabelID, BClabelItem.BClabelItem_Line;")
			rsData = modRecordSet.getRS(ref "SELECT * FROM BClabelItem INNER JOIN BClabel ON BClabelItem.BClabelItem_BCLabelID = BClabel.BClabelID Where (((BClabel.BClabelID) = " + labelID + "))  And ((BClabelItem.BClabelItem_Disabled) <> True) ORDER BY BClabel.BClabelID, BClabelItem.BClabelItem_Line;");

			sql = "SELECT StockItem.StockItemID, Catalogue.Catalogue_Quantity, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Supplier.SupplierID, Supplier.Supplier_Name, PricingGroup.PricingGroupID, PricingGroup.PricingGroup_Name, Format([CatalogueChannelLnk_Price],'Currency') AS Price, barcodePersonLnk.barcodePersonLnk_PersonID, barcodePersonLnk.barcodePersonLnk_PrintQTY, Company.*";
			sql = sql + "FROM Company, barcodePersonLnk INNER JOIN ((((StockItem INNER JOIN Supplier ON StockItem.StockItem_SupplierID = Supplier.SupplierID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)) ON (barcodePersonLnk.barcodePersonLnk_StockItemID = Catalogue.Catalogue_StockItemID) AND (barcodePersonLnk.barcodePersonLnk_Shrink = Catalogue.Catalogue_Quantity)";
			sql = sql + "WHERE (((barcodePersonLnk.barcodePersonLnk_PersonID)=1) AND ((barcodePersonLnk.barcodePersonLnk_PrintQTY)<>0) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));";

			sql = "SELECT StockItem.StockItemID, Catalogue.Catalogue_Quantity, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Supplier.SupplierID, Supplier.Supplier_Name, PricingGroup.PricingGroupID, PricingGroup.PricingGroup_Name, Format([CatalogueChannelLnk_Price],'Currency') AS Price, barcodePersonLnk.barcodePersonLnk_PersonID, barcodePersonLnk.barcodePersonLnk_PrintQTY, Company.*, barcodePersonLnk.barcodePersonLnk_PrintQTY ";
			sql = sql + "FROM Company, barcodePersonLnk INNER JOIN ((((StockItem INNER JOIN Supplier ON StockItem.StockItem_SupplierID = Supplier.SupplierID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity)) ON (barcodePersonLnk.barcodePersonLnk_Shrink = Catalogue.Catalogue_Quantity) AND (barcodePersonLnk.barcodePersonLnk_StockItemID = Catalogue.Catalogue_StockItemID) ";
			sql = sql + "WHERE (((barcodePersonLnk.barcodePersonLnk_PersonID)=1) AND ((barcodePersonLnk.barcodePersonLnk_PrintQTY)<>0) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));";

			gLBLleft = (lObject.PrinterSettings.DefaultPageSettings.PaperSize.Width - (gLBLwidth)) / 2 + (gOffsetLabel * twipsToMM);
			//    lObject.Cls
			//gLBLleft = (Printer.Width - gLBLwidth) + ((gOffsetLabel) * frmBarcodedesign.twipsToMM)
			rs = modRecordSet.getRS(ref sql);
			while (!(rs.EOF)) {
				rsData.MoveFirst();
				y = Convert.ToInt16((gLBLheight - rsData.Fields("BClabel_Height").Value * twipsToMM) / 2);
				Printer.PrinterSettings.Copies = rs.Fields("barcodePersonLnk_PrintQTY").Value;

				if (y < 0)
					y = 0;
				//lObject.FontName = "Tahoma"
				rsData.MoveFirst();
				if (rsData.RecordCount) {
					lline = rsData.Fields("BClabelItem_Line").Value;
					while (!(rsData.EOF)) {
						if (lline != rsData.Fields("BClabelItem_Line").Value) {
							//y = lObject.Location.Y + 10
							lline = rsData.Fields("BClabelItem_Line").Value;
						}

						switch (Strings.LCase(rsData.Fields("BClabelItem_Field").Value)) {
							case "line":
								break;
							//lObject.Line((15 + gLBLleft, y) - (gLBLleft + gLBLwidth, y), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black))
							case "code":
								switch (rsData.Fields("BClabelItem_Align").Value) {
									case 1:
										printBarcode(lObject, rs.Fields("Catalogue_Barcode").Value, gLBLleft + 90, y);
										break;
									case 2:
										printBarcode(lObject, rs.Fields("Catalogue_Barcode").Value, gLBLleft + 90, y);
										break;
									default:
										printBarcode(ref lObject, ref rs.Fields("Catalogue_Barcode").Value, ref gLBLleft, ref y, ref gLBLwidth);
										break;
								}
								break;
							default:
								//lObject.FontSize = rsData.Fields("BClabelItem_Size").Value
								//lObject.FontBold = rsData.Fields("BClabelItem_Bold").Value
								//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
								mm = rsData.Fields("BClabelItem_Field").Value;
								lString1 = rs.Fields(mm).Value;
								switch (rsData.Fields("BClabelItem_Align").Value) {
									case 1:
										break;
									//lObject.PSet(New Point[](gLBLleft + 90, y))
									//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
									//lObject.Print(lString1)

									case 2:
										break;
									//lObject.PSet(New Point[](gLBLleft + gLBLwidth - lObject.TextWidth(lString1) - 90, y))
									//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
									//lObject.Print(lString1)

									case 3:
										//splitString(lObject, lString1, lString2)
										if (!string.IsNullOrEmpty(lString1)) {
											//lObject.PSet(New Point[](CShort(gLBLleft + (gLBLwidth - lObject.TextWidth(lString1)) / 2), y))
											//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
											//lObject.Print(lString1)
											//y = lObject.Location.Y + 10
											//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
										}
										lString1 = lString2;
										if (!string.IsNullOrEmpty(lString1)) {
											//lObject.PSet(New Point[](CShort(gLBLleft + (gLBLwidth - lObject.TextWidth(lString1)) / 2), y))
											//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
											//lObject.Print(lString1)
										}
										break;
									default:
										break;
									//lObject.PSet(New Point[](CShort(gLBLleft + (gLBLwidth - lObject.TextWidth(lString1)) / 2), y))
									//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
									//lObject.Print(lString1)
								}
								break;
						}
						rsData.MoveNext();
					}
				}
				Printer.Print();
				rs.MoveNext();
			}
		}

		public object PrintBcodes()
		{
			System.Windows.Forms.PictureBox barcodePicture = null;
			string lValue = null;
			int lTop = 0;
			int lLeft = 0;
			int lWidth = 0;
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
			int i = 0;
			int j = 0;
			short cnt = 0;
			string[] barArray = null;
			lXML = "";
			if (doCheckSum(ref lValue)) {
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
				code = Strings.Left(lValue, 1);
				code = Strings.Right(code, 1);
				codeType = parityArray[Convert.ToInt16(code)];

				lXML = lXML + doImage(ref "101", ref 1);
				for (i = 2; i <= 7; i++) {
					code = Strings.Left(lValue, i);
					code = Strings.Right(code, 1);
					lCode = Strings.Left(codeType, i - 1);
					lCode = Strings.Right(lCode, 1);
					if (lCode == "0") {
						lXML = lXML + doImage(ref evenArray[code], ref 0);
					} else {
						lXML = lXML + doImage(ref oddArray[code], ref 0);
					}
				}
				lXML = lXML + doImage(ref "01010", ref 1);
				for (i = 8; i <= 13; i++) {
					code = Strings.Left(lValue, i);
					code = Strings.Right(code, 1);
					lXML = lXML + doImage(ref lastArray[code], ref 0);
				}
				lXML = lXML + doImage(ref "101", ref 1);
			} else {
				lString = lValue;
				for (i = 1; i <= Strings.Len(lString); i++) {
					if (Convert.ToDouble(Strings.Left(lString, 1)) == 0) {
						lString = Strings.Right(lString, Strings.Len(lString) - 1);
					} else {
						break; // TODO: might not be correct. Was : Exit For
					}
				}
				lValue = lString;

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

				lString = "131131311";
				lString = lString + "1";
				for (i = 1; i <= Strings.Len(lValue); i++) {
					code = Strings.Left(lValue, i);
					code = Strings.Right(code, 1);
					code = Strings.UCase(code);
					for (j = 0; j <= Information.UBound(oddArray); j++) {
						if (code == oddArray[j]) {
							lString = lString + evenArray[j];
							lString = lString + "1";
							j = 9999;
						}
					}
				}
				lString = lString + "131131311";

				for (i = 1; i <= Strings.Len(lString); i++) {
					code = Strings.Left(lString, i);
					code = Strings.Right(code, 1);
					for (j = 1; j <= Convert.ToInt16(code); j++) {
						lCode = Strings.Left(code, i);
						lCode = Strings.Right(lCode, 1);
						if (i % 2) {
							lXML = lXML + System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black) + "~";
						} else {
							lXML = lXML + System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White) + "~";
						}
						lXML = lXML + "20|";
					}
				}
			}

			barArray = Strings.Split(lXML, "|");
			y = lTop;
			if (lWidth == 0) {
				x = lLeft;
			} else {
				x = Convert.ToInt16(lLeft + (lWidth - Information.UBound(barArray) * sizeConvertors.twipsPerPixel(true) / 2));
			}
			for (cnt = Information.LBound(barArray); cnt <= Information.UBound(barArray); cnt++) {
				if (!string.IsNullOrEmpty(barArray[cnt])) {
					if (Convert.ToInt32(Strings.Split(barArray[cnt], "~")[0]) == System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)) {
						 // ERROR: Not supported in C#: OnErrorStatement

						//barcodePicture.Line((x + cnt * twipsPerPixel(True), y) - _
						//    (x + (cnt + 1) * twipsPerPixel(true), _
						//        y + CInt(Split(barArray(cnt), "~")(1)) * _
						//        twipsPerPixel(true)), CInt(Split(barArray(cnt), "~")(0)), BF)
					}
				}

			}
		}

		public object MyFormLoads()
		{
			object functionReturnValue = null;
			System.Windows.Forms.Label lblPrinter = new System.Windows.Forms.Label();
			int lValue = 0;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			//openConnection

			// strheight = 0
			// strwidht = 0
			//ppp
			if (fso.FileExists("C:\\lblPath\\path.dat")) {
				loadBarcodePrinter();
				// strwidht = 0
				// strheight = 0
				labelsfile();
				//picSelect(1).ForeColor = vbGreen
				strwidht = 0;
				strheight = 0;
				PrintBcodes();
				return functionReturnValue;

			} else {
				gPersonID = 1;
				if (loadBarcodePrinter()) {
					Debug.Print(gLBLwidth);
					lValue = gLBLwidth;
					lblPrinter.Text = gPrinterLabel;
					HSHeight.Value = gLBLheight / twipsToMM;
					HSWidth.Value = lValue / twipsToMM;
					Debug.Print(gLBLwidth);
				} else {
					return functionReturnValue;
					//Unload Me
				}


			}
			updatte();
			return functionReturnValue;
		}

		public object CommandNew()
		{
			short NewLargeChange = 0;
			object lline = null;
			System.Windows.Forms.PictureBox lObject = null;
			int y = 0;
			int x = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsData = default(ADODB.Recordset);
			lObject = _picSelect_0;
			int currentPic = 0;
			short RecSelNew = 0;
			string lString1 = null;
			string lString2 = null;
			ADODB.Recordset rsTop = default(ADODB.Recordset);

			_picSelect_0.Width = sizeConvertors.twipsToPixels(gLBLwidth, true);

			gLBLleft = (lObject.Width - (gLBLwidth)) / 2 + (twipsToMM);
			gLBLleft = 0;
			//UPGRADE_ISSUE: PictureBox method picSelect.Cls was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			//picSelect(0).Cls()
			rs = modRecordSet.getRS(ref "SELECT * FROM BClabel WHERE BClabel_Disabled = false and BClabelID=" + modApplication.RecSel + " ORDER BY BClabelID");

			while (!(rs.EOF)) {
				if (currentPic) {
					 // ERROR: Not supported in C#: OnErrorStatement

					_picSelect_0.Load(currentPic);
				}
				//picSelect(currentPic).Left = (picSelect(currentPic).Width + 90) * currentPic
				_picSelect_0.Visible = true;
				//UPGRADE_ISSUE: PictureBox property picSelect.AutoRedraw was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				//picSelect(currentPic).AutoRedraw = True
				lObject = _picSelect_0;
				_picSelect_0.Tag = rs.Fields("BClabelID").Value;
				currentPic = currentPic + 1;

				y = Convert.ToInt16((gLBLheight - rs.Fields("BClabel_Height").Value * twipsToMM) / 2);
				if (y < 0)
					y = 0;
				//lObject.FontName = "Tahoma"
				x = y;
				rsData = modRecordSet.getRS(ref "SELECT * FROM BClabelItem INNER JOIN BClabel ON BClabelItem.BClabelItem_BCLabelID = BClabel.BClabelID Where (((BClabel.BClabelID) = " + rs.Fields("BClabelID").Value + ")) ORDER BY BClabel.BClabelID, BClabelItem.BClabelItem_Line;");
				if (rsData.RecordCount) {
					lline = rsData.Fields("BClabelItem_Line").Value;
					while (!(rsData.EOF)) {
						if (lline != rsData.Fields("BClabelItem_Line").Value) {
							y = lObject.Location.Y + 10;
							x = y;
							lline = rsData.Fields("BClabelItem_Line").Value;
						}
						//lline = rsData("BClabelItem_Line")
						switch (Strings.LCase(rsData.Fields("BClabelItem_Field").Value)) {

							case "line":

								if (rsData.Fields("BClabelItem_Line").Value == 1) {
									y = 150;
								} else if (rsData.Fields("BClabelItem_Line").Value == 2) {
									y = 350;
								} else if (rsData.Fields("BClabelItem_Line").Value == 3) {
									y = 600;
								} else if (rsData.Fields("BClabelItem_Line").Value == 4) {
									y = 750;
								} else if (rsData.Fields("BClabelItem_Line").Value == 5) {
									y = 950;
								} else if (rsData.Fields("BClabelItem_Line").Value == 6) {
									y = 1150;
								} else if (rsData.Fields("BClabelItem_Line").Value == 7) {
									y = 1350;
								} else if (rsData.Fields("BClabelItem_Line").Value == 8) {
									y = 1550;
								} else if (rsData.Fields("BClabelItem_Line").Value == 9) {
									y = 1700;
								} else if (rsData.Fields("BClabelItem_Line").Value == 10) {
									y = 1850;
								} else if (rsData.Fields("BClabelItem_Line").Value == 11) {
									y = 2100;
								} else if (rsData.Fields("BClabelItem_Line").Value == 12) {
									y = 2300;
								} else if (rsData.Fields("BClabelItem_Line").Value == 13) {
									y = 2500;
								} else if (rsData.Fields("BClabelItem_Line").Value == 14) {
									y = 2700;
								} else if (rsData.Fields("BClabelItem_Line").Value == 15) {
									y = 2900;
								} else if (rsData.Fields("BClabelItem_Line").Value == 16) {
									y = 3100;
								} else if (rsData.Fields("BClabelItem_Line").Value == 17) {
									y = 3300;
								} else if (rsData.Fields("BClabelItem_Line").Value == 18) {
									y = 3500;
								} else if (rsData.Fields("BClabelItem_Line").Value == 19) {
									y = 3700;
								} else if (rsData.Fields("BClabelItem_Line").Value == 20) {
									y = 3900;
								} else if (rsData.Fields("BClabelItem_Line").Value == 21) {
									y = 4100;
								} else if (rsData.Fields("BClabelItem_Line").Value == 22) {
									y = 4200;
								} else if (rsData.Fields("BClabelItem_Line").Value == 23) {
									y = 4350;
								}


								//lObject.Line((15 + gLBLleft, y) - (gLBLleft + gLBLwidth, y), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black))
								y = x;
								break;
							case "code":
								if (rsData.Fields("BClabelItem_Line").Value == 1) {
									y = 0;
								} else if (rsData.Fields("BClabelItem_Line").Value == 2) {
									y = 150;
								} else if (rsData.Fields("BClabelItem_Line").Value == 3) {
									y = 350;
								} else if (rsData.Fields("BClabelItem_Line").Value == 4) {
									y = 600;
								} else if (rsData.Fields("BClabelItem_Line").Value == 5) {
									y = 750;
								} else if (rsData.Fields("BClabelItem_Line").Value == 6) {
									y = 950;
								} else if (rsData.Fields("BClabelItem_Line").Value == 7) {
									y = 1150;
								} else if (rsData.Fields("BClabelItem_Line").Value == 8) {
									y = 1350;
								} else if (rsData.Fields("BClabelItem_Line").Value == 9) {
									y = 1550;
								} else if (rsData.Fields("BClabelItem_Line").Value == 10) {
									y = 1700;
								} else if (rsData.Fields("BClabelItem_Line").Value == 11) {
									y = 1850;
								} else if (rsData.Fields("BClabelItem_Line").Value == 12) {
									y = 2100;
								} else if (rsData.Fields("BClabelItem_Line").Value == 13) {
									y = 2300;
								} else if (rsData.Fields("BClabelItem_Line").Value == 14) {
									y = 2500;
								} else if (rsData.Fields("BClabelItem_Line").Value == 15) {
									y = 2700;
								} else if (rsData.Fields("BClabelItem_Line").Value == 16) {
									y = 2900;
								} else if (rsData.Fields("BClabelItem_Line").Value == 17) {
									y = 3100;
								} else if (rsData.Fields("BClabelItem_Line").Value == 18) {
									y = 3300;
								} else if (rsData.Fields("BClabelItem_Line").Value == 19) {
									y = 3500;
								} else if (rsData.Fields("BClabelItem_Line").Value == 20) {
									y = 3700;
								} else if (rsData.Fields("BClabelItem_Line").Value == 21) {
									y = 3900;
								} else if (rsData.Fields("BClabelItem_Line").Value == 22) {
									y = 4100;
								} else if (rsData.Fields("BClabelItem_Line").Value == 23) {
									y = 4200;
								}
								switch (rsData.Fields("BClabelItem_Align").Value) {

									case 1:
										//Jonas added
										//lObject.FontSize = rsData.Fields("BClabelItem_Size").Value
										//lObject.FontBold = rsData.Fields("BClabelItem_Bold").Value
										//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
										//Jonas
										printBarcode(lObject, "6001060071416", gLBLleft, y);
										break;
									case 2:
										//Jonas added
										//lObject.FontSize = rsData.Fields("BClabelItem_Size").Value
										//lObject.FontBold = rsData.Fields("BClabelItem_Bold").Value
										//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
										//Jonas

										printBarcode(ref lObject, ref "6001060071416", ref gLBLleft, ref y, ref gLBLwidth + gLBLwidth - 1440);
										break;
									//lObject.PSet (gLBLleft, y)
									default:
										//Jonas added
										//lObject.FontSize = rsData.Fields("BClabelItem_Size").Value
										//lObject.FontBold = rsData.Fields("BClabelItem_Bold").Value
										//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
										//Jonas
										printBarcode(ref lObject, ref "6001060071416", ref gLBLleft, ref y, ref gLBLwidth);
										break;
								}
								y = x;
								break;
							default:

								 // ERROR: Not supported in C#: OnErrorStatement


								//lObject.FontSize = rsData.Fields("BClabelItem_Size").Value
								//lObject.FontBold = rsData.Fields("BClabelItem_Bold").Value
								//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
								y = lObject.Location.Y + 10;
								x = y;
								lline = rsData.Fields("BClabelItem_Line").Value;
								if (Information.IsDBNull(rsData.Fields("BClabelItem_Sample").Value)) {
									lString1 = "";
								} else {
									lString1 = rsData.Fields("BClabelItem_Sample").Value;
								}
								switch (rsData.Fields("BClabelItem_Align").Value) {
									case 1:

										if (rsData.Fields("BClabelItem_Line").Value == 1) {
											y = 0;
										} else if (rsData.Fields("BClabelItem_Line").Value == 2) {
											y = 150;
										} else if (rsData.Fields("BClabelItem_Line").Value == 3) {
											y = 350;
										} else if (rsData.Fields("BClabelItem_Line").Value == 4) {
											y = 600;
										} else if (rsData.Fields("BClabelItem_Line").Value == 5) {
											y = 750;
										} else if (rsData.Fields("BClabelItem_Line").Value == 6) {
											y = 950;
										} else if (rsData.Fields("BClabelItem_Line").Value == 7) {
											y = 1150;
										} else if (rsData.Fields("BClabelItem_Line").Value == 8) {
											y = 1350;
										} else if (rsData.Fields("BClabelItem_Line").Value == 9) {
											y = 1550;
										} else if (rsData.Fields("BClabelItem_Line").Value == 10) {
											y = 1700;
										} else if (rsData.Fields("BClabelItem_Line").Value == 11) {
											y = 1850;
										} else if (rsData.Fields("BClabelItem_Line").Value == 12) {
											y = 2100;
										} else if (rsData.Fields("BClabelItem_Line").Value == 13) {
											y = 2300;
										} else if (rsData.Fields("BClabelItem_Line").Value == 14) {
											y = 2500;
										} else if (rsData.Fields("BClabelItem_Line").Value == 15) {
											y = 2700;
										} else if (rsData.Fields("BClabelItem_Line").Value == 16) {
											y = 2900;
										} else if (rsData.Fields("BClabelItem_Line").Value == 17) {
											y = 3100;
										} else if (rsData.Fields("BClabelItem_Line").Value == 18) {
											y = 3300;
										} else if (rsData.Fields("BClabelItem_Line").Value == 19) {
											y = 3500;
										} else if (rsData.Fields("BClabelItem_Line").Value == 20) {
											y = 3700;
										} else if (rsData.Fields("BClabelItem_Line").Value == 21) {
											y = 3900;
										} else if (rsData.Fields("BClabelItem_Line").Value == 22) {
											y = 4100;
										} else if (rsData.Fields("BClabelItem_Line").Value == 23) {
											y = 4200;
										}

										//y = 1112
										//dfd = rsData("BClabelItem_Field")
										//lObject.PSet(New Point[](gLBLleft, y))

										//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
										//lObject.Print(lString1)
										y = x;
										break;
									case 2:
										//Row No
										if (rsData.Fields("BClabelItem_Line").Value == 1) {
											y = 0;
										} else if (rsData.Fields("BClabelItem_Line").Value == 2) {
											y = 150;
										} else if (rsData.Fields("BClabelItem_Line").Value == 3) {
											y = 350;
										} else if (rsData.Fields("BClabelItem_Line").Value == 4) {
											y = 600;
										} else if (rsData.Fields("BClabelItem_Line").Value == 5) {
											y = 750;
										} else if (rsData.Fields("BClabelItem_Line").Value == 6) {
											y = 950;
										} else if (rsData.Fields("BClabelItem_Line").Value == 7) {
											y = 1150;
										} else if (rsData.Fields("BClabelItem_Line").Value == 8) {
											y = 1350;
										} else if (rsData.Fields("BClabelItem_Line").Value == 9) {
											y = 1550;
										} else if (rsData.Fields("BClabelItem_Line").Value == 10) {
											y = 1700;
										} else if (rsData.Fields("BClabelItem_Line").Value == 11) {
											y = 1850;
										} else if (rsData.Fields("BClabelItem_Line").Value == 12) {
											y = 2100;
										} else if (rsData.Fields("BClabelItem_Line").Value == 13) {
											y = 2300;
										} else if (rsData.Fields("BClabelItem_Line").Value == 14) {
											y = 2500;
										} else if (rsData.Fields("BClabelItem_Line").Value == 15) {
											y = 2700;
										} else if (rsData.Fields("BClabelItem_Line").Value == 16) {
											y = 2900;
										} else if (rsData.Fields("BClabelItem_Line").Value == 17) {
											y = 3100;
										} else if (rsData.Fields("BClabelItem_Line").Value == 18) {
											y = 3300;
										} else if (rsData.Fields("BClabelItem_Line").Value == 19) {
											y = 3500;
										} else if (rsData.Fields("BClabelItem_Line").Value == 20) {
											y = 3700;
										} else if (rsData.Fields("BClabelItem_Line").Value == 21) {
											y = 3900;
										} else if (rsData.Fields("BClabelItem_Line").Value == 22) {
											y = 4100;
										} else if (rsData.Fields("BClabelItem_Line").Value == 23) {
											y = 4200;
										}

										//Row No
										//lObject.PSet(New Point[](gLBLleft + gLBLwidth - lObject.TextWidth(lString1), y))
										//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
										//lObject.Print(lString1)
										y = x;
										break;
									case 3:
										//Row No
										if (rsData.Fields("BClabelItem_Line").Value == 1) {
											y = 0;
										} else if (rsData.Fields("BClabelItem_Line").Value == 2) {
											y = 150;
										} else if (rsData.Fields("BClabelItem_Line").Value == 3) {
											y = 350;
										} else if (rsData.Fields("BClabelItem_Line").Value == 4) {
											y = 600;
										} else if (rsData.Fields("BClabelItem_Line").Value == 5) {
											y = 750;
										} else if (rsData.Fields("BClabelItem_Line").Value == 6) {
											y = 950;
										} else if (rsData.Fields("BClabelItem_Line").Value == 7) {
											y = 1150;
										} else if (rsData.Fields("BClabelItem_Line").Value == 8) {
											y = 1350;
										} else if (rsData.Fields("BClabelItem_Line").Value == 9) {
											y = 1550;
										} else if (rsData.Fields("BClabelItem_Line").Value == 10) {
											y = 1700;
										} else if (rsData.Fields("BClabelItem_Line").Value == 11) {
											y = 1850;
										} else if (rsData.Fields("BClabelItem_Line").Value == 12) {
											y = 2100;
										} else if (rsData.Fields("BClabelItem_Line").Value == 13) {
											y = 2300;
										} else if (rsData.Fields("BClabelItem_Line").Value == 14) {
											y = 2500;
										} else if (rsData.Fields("BClabelItem_Line").Value == 15) {
											y = 2700;
										} else if (rsData.Fields("BClabelItem_Line").Value == 16) {
											y = 2900;
										} else if (rsData.Fields("BClabelItem_Line").Value == 17) {
											y = 3100;
										} else if (rsData.Fields("BClabelItem_Line").Value == 18) {
											y = 3300;
										} else if (rsData.Fields("BClabelItem_Line").Value == 19) {
											y = 3500;
										} else if (rsData.Fields("BClabelItem_Line").Value == 20) {
											y = 3700;
										} else if (rsData.Fields("BClabelItem_Line").Value == 21) {
											y = 3900;
										} else if (rsData.Fields("BClabelItem_Line").Value == 22) {
											y = 4100;
										} else if (rsData.Fields("BClabelItem_Line").Value == 23) {
											y = 4200;
										}

										//Row No
										//splitString(lObject, lString1, lString2)
										if (!string.IsNullOrEmpty(lString1)) {
											//lObject.PSet(New Point[](CShort(gLBLleft + (gLBLwidth - lObject.TextWidth(lString1)) / 2), y))
											y = x;
											//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
											//lObject.Print(lString1)
											y = lObject.Location.Y + 10;
											x = y;
											//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
										}
										lString1 = lString2;
										if (!string.IsNullOrEmpty(lString1)) {
											//lObject.PSet(New Point[](CShort(gLBLleft + (gLBLwidth - lObject.TextWidth(lString1)) / 2), y))
											//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
											//lObject.Print(lString1)
										}
										break;
									default:
										//Row No
										if (rsData.Fields("BClabelItem_Line").Value == 1) {
											y = 0;
										} else if (rsData.Fields("BClabelItem_Line").Value == 2) {
											y = 150;
										} else if (rsData.Fields("BClabelItem_Line").Value == 3) {
											y = 350;
										} else if (rsData.Fields("BClabelItem_Line").Value == 4) {
											y = 600;
										} else if (rsData.Fields("BClabelItem_Line").Value == 5) {
											y = 750;
										} else if (rsData.Fields("BClabelItem_Line").Value == 6) {
											y = 950;
										} else if (rsData.Fields("BClabelItem_Line").Value == 7) {
											y = 1150;
										} else if (rsData.Fields("BClabelItem_Line").Value == 8) {
											y = 1350;
										} else if (rsData.Fields("BClabelItem_Line").Value == 9) {
											y = 1550;
										} else if (rsData.Fields("BClabelItem_Line").Value == 10) {
											y = 1700;
										} else if (rsData.Fields("BClabelItem_Line").Value == 11) {
											y = 1850;
										} else if (rsData.Fields("BClabelItem_Line").Value == 12) {
											y = 2100;
										} else if (rsData.Fields("BClabelItem_Line").Value == 13) {
											y = 2300;
										} else if (rsData.Fields("BClabelItem_Line").Value == 14) {
											y = 2500;
										} else if (rsData.Fields("BClabelItem_Line").Value == 15) {
											y = 2700;
										} else if (rsData.Fields("BClabelItem_Line").Value == 16) {
											y = 2900;
										} else if (rsData.Fields("BClabelItem_Line").Value == 17) {
											y = 3100;
										} else if (rsData.Fields("BClabelItem_Line").Value == 18) {
											y = 3300;
										} else if (rsData.Fields("BClabelItem_Line").Value == 19) {
											y = 3500;
										} else if (rsData.Fields("BClabelItem_Line").Value == 20) {
											y = 3700;
										} else if (rsData.Fields("BClabelItem_Line").Value == 21) {
											y = 3900;
										} else if (rsData.Fields("BClabelItem_Line").Value == 22) {
											y = 4100;
										} else if (rsData.Fields("BClabelItem_Line").Value == 23) {
											y = 4200;
										}

										//Row No
										//lObject.PSet(New Point[](CShort(gLBLleft + (gLBLwidth - lObject.TextWidth(lString1)) / 2), y))
										y = x;
										break;
									//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
									//lObject.Print(lString1)
								}
								break;
						}
						rsData.MoveNext();
					}
				}
				rs.MoveNext();
			}

			//End If
			picInner.Width = sizeConvertors.twipsToPixels(lObject.Left + lObject.Width, true);
			picInner.SetBounds(0, 0, sizeConvertors.twipsToPixels(lObject.Left + lObject.Width, true), sizeConvertors.twipsToPixels(lObject.Top + lObject.Height, false));
			if (sizeConvertors.pixelToTwips(picInner.Width, true) > sizeConvertors.pixelToTwips(picOuter.Width, true)) {
				HSselect.Enabled = true;
				HSselect.Value = 0;
				HSselect.Maximum = (sizeConvertors.pixelToTwips(picInner.Width, true) - sizeConvertors.pixelToTwips(picOuter.Width, true) + 100 + HSselect.LargeChange - 1);
				NewLargeChange = lObject.Width + 100;
				HSselect.Maximum = HSselect.Maximum + NewLargeChange - HSselect.LargeChange;
				HSselect.LargeChange = NewLargeChange;
				HSselect.SmallChange = Convert.ToInt16((lObject.Width + 100) / 2);

			} else {
				HSselect.Enabled = false;
			}


		}


		private void txtpos_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (!Information.IsNumeric(this.txtpos.Text)) {
				Interaction.MsgBox("Please enter a Valid Number for Row Position.", MsgBoxStyle.Information, "4POS");
				this.txtpos.Text = "1";
				this.txtpos.Focus();
				return;
			} else {
			}

			if (Convert.ToDouble(this.txtpos.Text) < 1 | Convert.ToDouble(this.txtpos.Text) > 23) {
				Interaction.MsgBox("Please enter a Number from 1 to 23 for 'Row Position' as indicated on the left hand side of you designing page.", MsgBoxStyle.Information, "4Pos Back Office");
				this.txtpos.Focus();
				this.txtpos.Text = "1";
				return;
			} else {
			}

		}

		public object FunUnl()
		{
			object functionReturnValue = null;
			this.Close();
			return functionReturnValue;
			return functionReturnValue;
		}


		private void VScroll1_Change()
		{
		}
		private void HSHeight_Scroll(System.Object eventSender, System.Windows.Forms.ScrollEventArgs eventArgs)
		{
			switch (eventArgs.Type) {
				case System.Windows.Forms.ScrollEventType.EndScroll:
					HSHeight_Change(eventArgs.NewValue);
					break;
			}
		}
		private void HSLeft_Scroll(System.Object eventSender, System.Windows.Forms.ScrollEventArgs eventArgs)
		{
			switch (eventArgs.Type) {
				case System.Windows.Forms.ScrollEventType.EndScroll:
					HSLeft_Change(eventArgs.NewValue);
					break;
			}
		}
		private void HSselect_Scroll(System.Object eventSender, System.Windows.Forms.ScrollEventArgs eventArgs)
		{
			switch (eventArgs.Type) {
				case System.Windows.Forms.ScrollEventType.EndScroll:
					HSselect_Change(eventArgs.NewValue);
					break;
			}
		}
		private void HSTop_Scroll(System.Object eventSender, System.Windows.Forms.ScrollEventArgs eventArgs)
		{
			switch (eventArgs.Type) {
				case System.Windows.Forms.ScrollEventType.EndScroll:
					HSTop_Change(eventArgs.NewValue);
					break;
			}
		}
		private void HSWidth_Scroll(System.Object eventSender, System.Windows.Forms.ScrollEventArgs eventArgs)
		{
			switch (eventArgs.Type) {
				case System.Windows.Forms.ScrollEventType.EndScroll:
					HSWidth_Change(eventArgs.NewValue);
					break;
			}
		}
	}
}
