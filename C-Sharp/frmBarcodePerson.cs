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
	internal partial class frmBarcodePerson : System.Windows.Forms.Form
	{
		ADODB.Recordset rs;

		private void loadLanguage()
		{

			//frmBarcodePerson = No Code     [Security Barcode Printing]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmBarcodePerson.Caption = rsLang("LanguageLayoutLnk_Description"): frmBarcodePerson.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1818;
			//Printer|Checked
			if (modRecordSet.rsLang.RecordCount){_Label2_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_Label2_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lblPrinter = No Code/Dynamic/NA?

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1819;
			//Printer Type|Checked
			if (modRecordSet.rsLang.RecordCount){_Label2_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_Label2_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lblPrinterType = No Code/Dynamic/NA?

			//Label1 = No Code               [Tick the check boxes for the Persons you require access barcodes for from the list below.]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1085;
			//Print|Checked
			if (modRecordSet.rsLang.RecordCount){cmdPrint.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPrint.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cndExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cndExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmBarcodePerson.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void showLabels()
		{
			rs = modRecordSet.getRS(ref "SELECT Person.PersonID, [Person_FirstName] & ' ' & [Person_LastName] AS PersonName, Person.Person_QuickAccess, Label.* From Person, Label Where Person.Person_Disabled = False And Label.Label_Type = 3 ANd PersonID <> 1 ORDER BY [Person_FirstName] & ' ' & [Person_LastName];");
			this.lstPerson.Items.Clear();
			string tmpString = null;
			while (!(rs.EOF)) {
				tmpString = rs.Fields("PersonName").Value + " " + rs.Fields("PersonID").Value;
				lstPerson.Items.Add(tmpString);
				tmpString = "";
				rs.MoveNext();
			}
		}
		private void printPerson()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			if (Convert.ToDouble(lblPrinterType.Tag) == 1) {
				printBarcodePerson();
			} else if (Convert.ToDouble(lblPrinterType.Tag) == 2) {
				printA4Person();
			}
		}

		private void printBarcodePerson()
		{
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			Scripting.TextStream lStream = default(Scripting.TextStream);
			string lString = null;
			string[] lArray = null;
			string lText = null;
			short x = 0;
			short y = 0;
			for (y = 0; y <= lstPerson.Items.Count - 1; y++) {
				if (lstPerson.GetItemChecked(y)) {
					rs.Filter = "PersonID = " + GID.GetItemData(ref lstPerson, ref y);
					//rs.Filter = "PersonID = " & CLng(lstPerson(y))
					lString = rs.Fields("label_textstream").Value;
					lArray = Strings.Split(lString, Constants.vbCrLf);
					lString = "";

					for (x = 0; x <= Information.UBound(lArray); x++) {
						lText = lArray[x];
						lString = lString + Constants.vbCrLf + doString(ref lText, ref rs);
					}
					lStream = fso.OpenTextFile("c:\\aa.txt", Scripting.IOMode.ForWriting, true);
					lStream.Write(lString);
					lStream.Close();
					lString = "C:\\AA.TXT";
					modSpool.SpoolFile(lString, (lblPrinter.Text));
				}
			}
		}

		private string doString(ref string lString, ref ADODB.Recordset rs)
		{
			string functionReturnValue = null;
			string lString1 = null;
			string lString2 = null;
			string lText = null;
			if (Strings.Len(lString) > 15) {
				lText = Strings.Mid(lString, 16);
				if (Strings.InStr(lText, "NAME 1 CENTER")) {
					lString1 = rs.Fields("PersonName").Value;
					splitString(ref Strings.Len(lText), ref lString1, ref lString2);
					functionReturnValue = Strings.Left(lString, 15) + doCenter(ref lText, ref lString1);
					return functionReturnValue;
				}
				if (Strings.InStr(lText, "DATE")) {
					lString1 = Strings.Format(DateAndTime.Now, "yymm");
					functionReturnValue = Strings.Left(lString, 15) + Strings.Format(DateAndTime.Now, "yymm");
					return functionReturnValue;
				}

				if (Strings.InStr(lText, "BARCODE")) {
					if (doCheckSum(ref rs.Fields("Person_QuickAccess").Value)) {
					} else {
						functionReturnValue = Strings.Left(lString, 15) + rs.Fields("Person_QuickAccess").Value;
					}
					return functionReturnValue;
				}
				if (Strings.InStr(lText, "600106007141")) {
					if (doCheckSum(ref rs.Fields("Person_QuickAccess").Value))
						functionReturnValue = Strings.Left(lString, 15) + rs.Fields("Person_QuickAccess").Value;
					return functionReturnValue;
				}
				functionReturnValue = lString;
			} else {
				functionReturnValue = lString;
			}
			return functionReturnValue;
		}

		private bool doCheckSum(ref string lString)
		{
			bool functionReturnValue = false;
			short lAmount = 0;
			string code = null;
			short i = 0;
			string value = null;
			value = lString;
			functionReturnValue = false;
			if (Strings.InStr(value, "0")) {
				while (!(Convert.ToDouble(Strings.Left(value, 1)) != 0)) {
					value = Strings.Mid(value, 2);
				}
			}
			if (Strings.Len(value) != 13)
				return functionReturnValue;
			if (string.IsNullOrEmpty(value))
				return functionReturnValue;
			if (Strings.InStr(value, ".")) {
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
					functionReturnValue = lAmount == Convert.ToInt16(Strings.Right(value, 1));
				} else {
					functionReturnValue = false;
				}
			}
			return functionReturnValue;
		}

		public string doCenter(ref string origText, ref string newText)
		{
			string functionReturnValue = null;
			object newstring = null;
			if (Strings.Len(origText) > Strings.Len(newstring)) {
				functionReturnValue = new string(" ", Convert.ToInt16((Strings.Len(origText) - Strings.Len(newText)) / 2)) + newText;
			} else {
				functionReturnValue = Strings.Left(newText, Strings.Len(origText));
			}
			return functionReturnValue;

		}

		private void splitStringA4(ref object lObject, ref int lWidth, ref string HeadingString1, ref string HeadingString2)
		{
			System.Drawing.Printing.PrintDocument Printer = new System.Drawing.Printing.PrintDocument();
			short y = 0;
			short x = 0;
			string lHeading = null;
			lHeading = HeadingString1;
			HeadingString1 = lHeading + " ";
			HeadingString2 = "";
			if ((lWidth - lObject.TextWidth(lHeading)) < 0) {
				for (x = Strings.Len(lHeading) + 1; x >= 1; x += -1) {
					HeadingString1 = Strings.Left(lHeading, x);
					if ((lWidth - lObject.TextWidth(HeadingString1) + 50) > 0) {
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
				//
				//Else
				//Do Until Printer.TextWidth(HeadingString2) <= lWidth
				// HeadingString2 = Mid(HeadingString2, 1, Len(HeadingString2) - 1)
				//Loop 
			}
			HeadingString1 = Strings.Trim(HeadingString1);
			HeadingString2 = Strings.Trim(HeadingString2);
		}

		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			printPerson();
		}

		private void cndExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void frmBarcodePerson_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			System.Drawing.Printing.PrintDocument Printer = new System.Drawing.Printing.PrintDocument();
			string lPrinter = null;
			//UPGRADE_WARNING: Couldn't resolve default property of object frmPrinter.selectPrinter(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lPrinter = My.MyProject.Forms.frmPrinter.selectPrinter();
			loadLanguage();
			if (string.IsNullOrEmpty(lPrinter)) {
				this.Close();
				return;
			} else {
				lblPrinter.Text = lPrinter;
				if (Strings.InStr(Strings.LCase(Printer.PrinterSettings.PrinterName), "label")) {
					lblPrinterType.Tag = 1;
					lblPrinterType.Text = "Barcode Printer";
				} else {
					lblPrinterType.Tag = 2;
					lblPrinterType.Text = "A4 Printer";
				}
				showLabels();
			}
		}

		private void splitString(ref short Max, ref string HeadingString1, ref string HeadingString2)
		{
			string lHeading = null;
			lHeading = Strings.UCase(HeadingString1);
			lHeading = Strings.Replace(lHeading, "&", "AND");
			lHeading = Strings.Replace(lHeading, "'", "");
			HeadingString1 = lHeading + " ";
			HeadingString2 = "";

			if (Strings.Len(lHeading) > Max) {
				HeadingString1 = Strings.Left(lHeading, Max + 1);
				while (!(Strings.Right(HeadingString1, 1) == " " | Strings.Len(HeadingString1) == 1)) {
					HeadingString1 = Strings.Left(HeadingString1, Strings.Len(HeadingString1) - 1);

				}
				if (Strings.Len(HeadingString1) == 1) {
					HeadingString1 = Strings.Left(lHeading, 25);
					HeadingString2 = Strings.Mid(lHeading, 25, 25);

				} else {
					HeadingString2 = Strings.Left(Strings.Trim(Strings.Mid(lHeading, Strings.Len(HeadingString1))), Max);
				}
			}

		}

		private void printA4Person()
		{
			decimal mm = default(decimal);
			int lline = 0;
			int i = 0;
			int lTop = 0;
			int lHeight = 0;
			int gOffsetLabel = 0;
			System.Drawing.Printing.PrintDocument Printer = new System.Drawing.Printing.PrintDocument();
			System.Drawing.Printing.PrintDocument lObject = new System.Drawing.Printing.PrintDocument();
			int y = 0;
			ADODB.Recordset rsData = default(ADODB.Recordset);
			int currentPic = 0;
			int twipsToMM = 0;
			int lLeft = 0;
			int lWidth = 0;
			short lCol = 0;
			short lCols = 0;
			short lRows = 0;
			short lrow = 0;

			//Printer.ScaleMode = ScaleModeConstants.vbTwips 'twips
			//twipsToMM = Printer.ScaleWidth
			//Printer.ScaleMode = ScaleModeConstants.vbMillimeters 'mm
			//twipsToMM = twipsToMM / Printer.ScaleWidth
			//Printer.ScaleMode = ScaleModeConstants.vbTwips 'twips
			lObject = Printer;


			string lString1 = null;
			string lString2 = null;
			rs.MoveFirst();

			rsData = modRecordSet.getRS(ref "SELECT * FROM labelItem INNER JOIN label ON labelItem.labelItem_LabelID = label.labelID Where (((label.labelID) = " + rs.Fields("LabelID").Value + ")) ORDER BY label.labelID, labelItem.labelItem_Line;");

			//lLeft = (lObject.Width - (lWidth)) / 2 + (gOffsetLabel * twipsToMM)
			lLeft = 0;
			if (rsData.Fields("Label_Rotate").Value) {
				lWidth = rsData.Fields("label_Height").Value * twipsToMM;
				lHeight = rsData.Fields("label_Width").Value * twipsToMM;
			} else {
				lWidth = rsData.Fields("label_width").Value * twipsToMM;
				lHeight = rsData.Fields("label_Height").Value * twipsToMM;
			}
			lTop = rsData.Fields("label_Top").Value * twipsToMM;
			//lCols = CDec(Printer.Width / (lWidth + 60)) - 0.49999
			//lRows = CDec(Printer.Height / (lHeight + 60)) - 0.49999
			for (i = 0; i <= lstPerson.Items.Count - 1; i++) {
				if (lstPerson.GetItemChecked(i)) {
					rs.Filter = "PersonID=" + GID.GetItemData(ref lstPerson, ref i);
					rsData.MoveFirst();
					y = 0;

					if (y < 0)
						y = 0;
					//lObject.FontName = "Tahoma"
					rsData.MoveFirst();
					if (rsData.RecordCount) {
						lline = rsData.Fields("labelItem_Line").Value;

						lLeft = lCol * (lWidth + 60);
						//lObject.CurrentY = lrow * (lHeight + 60)
						rsData.MoveFirst();
						//y = lObject.CurrentY
						//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(Me.BackColor)
						//lObject.Line((lLeft, y) - (lLeft, y + 100))
						//lObject.Line((lLeft, y) - (lLeft + 100, y))
						//lObject.Line((lLeft + lWidth, y) - (lLeft + lWidth - 100, y))
						//lObject.Line((lLeft + lWidth, y) - (lLeft + lWidth, y + 100))
						//lObject.Line((lLeft + lWidth, lHeight + y) - (lLeft + lWidth, lHeight + y - 100))
						//lObject.Line((lLeft + lWidth, lHeight + y) - (lLeft + lWidth - 100, lHeight + y))
						//lObject.Line((lLeft, lHeight + y) - (lLeft, lHeight + y - 100))
						//lObject.Line((lLeft, lHeight + y) - (lLeft + 100, lHeight + y))
						//lObject.CurrentY = lrow * (lHeight + 60) + lTop
						//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
						//y = lObject.CurrentY + 10
						while (!(rsData.EOF)) {
							if (lline != rsData.Fields("labelItem_Line").Value) {
								//		y = lObject.CurrentY + 10
								lline = rsData.Fields("labelItem_Line").Value;
							}

							switch (Strings.LCase(Strings.Trim(rsData.Fields("labelItem_Field").Value))) {
								case "blank":
									break;
								//			lObject.FontSize = rsData.Fields("labelItem_Size").Value
								//				lObject.FontBold = rsData.Fields("labelItem_Bold").Value
								//'					lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
								//					lObject.Print(" ")
								case "line":
									break;
								//					lObject.Line((15 + lLeft, y) - (lLeft + lWidth, y), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black))
								case "code":
									switch (rsData.Fields("labelItem_Align").Value) {
										case 1:
											break;
										//printBarcode(lObject, rs.Fields("Person_QuickAccess").Value, lLeft + 90, y)
										case 2:
											break;
										//printBarcode(lObject, rs.Fields("Person_QuickAccess").Value, lLeft + 90, y)
										default:
											break;
										//printBarcode(lObject, rs.Fields("Person_QuickAccess").Value, lLeft, y, lWidth)
									}
									break;
								default:
									//lObject.FontSize = rsData.Fields("labelItem_Size").Value
									//lObject.FontBold = rsData.Fields("labelItem_Bold").Value
									//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
									mm = rsData.Fields("labelItem_Field").Value;
									lString1 = rs.Fields(mm).Value;
									switch (rsData.Fields("labelItem_Align").Value) {
										case 1:
											break;
										//lObject.PSet(New Point[](lLeft + 90, y))
										//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
										//lObject.Print(lString1)

										case 2:
											break;
										//lObject.PSet(New Point[](lLeft + lWidth - lObject.TextWidth(lString1) - 90, y))
										//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
										//lObject.Print(lString1)

										case 3:
											splitStringA4(ref lObject, ref lWidth, ref lString1, ref lString2);
											//lObject.PSet(New Point[](CShort(lLeft + (lWidth - lObject.TextWidth(lString1)) / 2), y))
											//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
											//lObject.Print(lString1)
											//y = lObject.CurrentY + 10
											//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
											lString1 = lString2;
											break;
										//lObject.PSet(New Point[](CShort(lLeft + (lWidth - lObject.TextWidth(lString1)) / 2), y))
										//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
										//lObject.Print(lString1)
										default:
											break;
										//lObject.PSet(New Point[](CShort(lLeft + (lWidth - lObject.TextWidth(lString1)) / 2), y))
										//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
										//lObject.Print(lString1)
									}
									break;
							}
							rsData.moveNext();
						}
						lCol = lCol + 1;
						if (lCol >= lCols) {
							lCol = 0;
							lrow = lrow + 1;
							//If (lrow + 1) * lHeight > lObject.Height Then
							//Printer.NewPage()
							//lrow = -1
							//End If
						}
					}
				}
			}
			//Printer.EndDoc()
		}

		public void printBarcode(ref PictureBox barcodePicture, ref string lValue, ref int lLeft, ref int lTop, ref int lWidth = 0)
		{
			int BF = 0;
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
				x = Convert.ToInt16(lLeft + (lWidth - Information.UBound(barArray) * sizeConvertors.twipsPerPixel(true)) / 2);
			}
			//For cnt = LBound(barArray) To UBound(barArray)
			// If barArray(cnt) <> "" Then
			// If CInt(Split(barArray(cnt), "~")(0)) = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black) Then
			//             barcodePicture.Line((x + cnt * twipsPerPixel(True), y) - (x + (cnt + 1) * _
			//                     twipsPerPixel(true), y + CInt(Split(barArray(cnt), "~")(1)) * _
			//                     twipsPerPixel(true)), CInt(Split(barArray(cnt), "~")(0)), BF)
			// End If
			//End If

			//Next
		}

		public string doImage(ref string code, ref int size_Renamed)
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
	}
}
