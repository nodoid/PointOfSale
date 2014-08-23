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
using VB = Microsoft.VisualBasic;
namespace _4PosBackOffice.NET
{
	//Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
	internal partial class frmBarcode : System.Windows.Forms.Form
	{
		int gType;
		[DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int GetTickCount();
		List<RadioButton> optBarcode = new List<RadioButton>();

		private void loadLanguage()
		{
			Button cmdExit = null;

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1817;
			//Barcode Printing|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1818;
			//Printer|Checked
			if (modRecordSet.rsLang.RecordCount){_Label2_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_Label2_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lblPrinter = No Code/Dynamic/NA?

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1819;
			//Printer Type|Checked
			if (modRecordSet.rsLang.RecordCount){_Label2_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_Label2_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lblPrinterType = No Code/Dynamic/NA?

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1820;
			//Select the barcode printing type you require|Checked
			if (modRecordSet.rsLang.RecordCount){Label1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1821;
			//Stock Barcode|Checked
			if (modRecordSet.rsLang.RecordCount){_optBarcode_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_optBarcode_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1830;
			//Shelf Taker|Checked
			if (modRecordSet.rsLang.RecordCount){_optBarcode_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_optBarcode_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount) {
				cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;
				cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;
			}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1005;
			//Next|Checked
			if (modRecordSet.rsLang.RecordCount){cmdnext.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdnext.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.Filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void showLabels()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			System.Windows.Forms.ListViewItem lvItem = null;
			rs = modRecordSet.getRS(ref "SELECT Label.* From Label WHERE (((Label.Label_Type)=" + gType + ")) ORDER BY LabelID;");
			this.lstBarcode.Items.Clear();
			int m = 0;
			while (!(rs.EOF)) {
				m = this.lstBarcode.Items.Add(rs.Fields("Label_Name").Value + " (" + "W" + rs.Fields("Label_Width").Value + "mm X H" + rs.Fields("Label_Height").Value + "mm)");
				lstBarcode.Items.Add(new SetItemData(m, rs.Fields("labelID").Value));

				rs.MoveNext();
			}

			rs = modRecordSet.getRS(ref "SELECT * FROM PrinterOftenUsed");
			 // ERROR: Not supported in C#: OnErrorStatement

			if (modApplication.TheErr != -2147217865) {
				if (gType == 2) {
					lstBarcode.SelectedIndex = rs.Fields("LabelIndex").Value;
				} else if (gType == 1) {
					lstBarcode.SelectedIndex = rs.Fields("ShelfIndex").Value;
				}
			}
		}

		private void printStock()
		{
			string sql = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			sql = "SELECT StockItem.StockItemID, Catalogue.Catalogue_Quantity, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Supplier.SupplierID, Supplier.Supplier_Name, PricingGroup.PricingGroupID, PricingGroup.PricingGroup_Name, Format([CatalogueChannelLnk_Price],'Currency') AS Price, barcodePersonLnk.barcodePersonLnk_PersonID, barcodePersonLnk.barcodePersonLnk_PrintQTY, Company.*, barcodePersonLnk.barcodePersonLnk_PrintQTY, Label.LabelID, Label.Label_TextStream, 'SELL BY ' & Format(NOW+[StockItem].[StockItem_ExpiryDays], 'dd/mm/yy') AS StockItem_ExpiryDays ";
			sql = sql + "FROM Company, Label, barcodePersonLnk INNER JOIN ((((StockItem INNER JOIN Supplier ON StockItem.StockItem_SupplierID = Supplier.SupplierID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)) ON (barcodePersonLnk.barcodePersonLnk_StockItemID = Catalogue.Catalogue_StockItemID) AND (barcodePersonLnk.barcodePersonLnk_Shrink = Catalogue.Catalogue_Quantity) ";
			sql = sql + "WHERE (((barcodePersonLnk.barcodePersonLnk_PersonID)=" + modRecordSet.gPersonID + ") AND ((barcodePersonLnk.barcodePersonLnk_PrintQTY)<>0) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((Label.LabelID)=" + Convert.ToInt32(lstBarcode.SelectedIndex) + ")); ";
			rs = modRecordSet.getRS(ref sql);

			if (rs.RecordCount) {
				//Checks if the barcode/Shelf Talker button is clicked and displays the correct button.
				if (_optBarcode_2.Checked == true) {
					if (Interaction.MsgBox("You have selected " + rs.RecordCount + " products to print." + Constants.vbCrLf + Constants.vbCrLf + "Are you sure you wish to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "PRINT BARCODES") == MsgBoxResult.Yes) {
						if (Convert.ToDouble(lblPrinterType.Tag) == 1) {
							printStockBarcode(ref rs);

						} else if (Convert.ToDouble(lblPrinterType.Tag) == 2) {
							printStockA4(ref rs);

						} else if (Convert.ToDouble(lblPrinterType.Tag) == 3) {
							PrintBarcodeDatamax(ref rs);
						}
					}
				} else if (_optBarcode_1.Checked == true) {
					if (Interaction.MsgBox("You have selected " + rs.RecordCount + " products to print." + Constants.vbCrLf + Constants.vbCrLf + "Are you sure you wish to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "PRINT SHELF TALKER") == MsgBoxResult.Yes) {
						if (Convert.ToDouble(lblPrinterType.Tag) == 1) {
							printStockBarcode(ref rs);
						} else if (Convert.ToDouble(lblPrinterType.Tag) == 2) {
							//If InStr(LCase(lblPrinter), "label") Then
							printStockA4(ref rs);
							//Else
							//    printStockA4_OLD rs
							//End If
						} else if (Convert.ToDouble(lblPrinterType.Tag) == 3) {
							PrintBarcodeDatamax(ref rs);
						}
					}

				}
			}
		}

		private void printStockBarcode(ref ADODB.Recordset rs)
		{
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			Scripting.TextStream lStream = default(Scripting.TextStream);
			string lString = null;
			string[] lArray = null;
			string lText = null;
			short x = 0;
			while (!(rs.EOF)) {
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

				rs.MoveNext();
			}
		}

		private string doString(ref string lString, ref ADODB.Recordset rs)
		{
			string functionReturnValue = null;
			short x = 0;
			string lString1 = null;
			string lString2 = null;
			string lText = null;
			ADODB.Recordset rsP = default(ADODB.Recordset);
			ADODB.Recordset rsShrink = default(ADODB.Recordset);

			if (Strings.Len(lString) > 15) {
				lText = Strings.Mid(lString, 16);
				if (Strings.InStr(lText, "COMPANY NAME CENTER")) {
					functionReturnValue = Strings.Left(lString, 15) + doCenter(ref lText, ref rs.Fields("Company_Name").Value);
					return functionReturnValue;
				}
				if (Strings.InStr(lText, "COMPANY NAME LEFT")) {
					functionReturnValue = Strings.Left(lString, 15) + Strings.Left(rs.Fields("Company_Name").Value, Strings.Len(lText));
					return functionReturnValue;
				}
				if (Strings.InStr(lText, "COMPANY NAME RIGHT")) {
					functionReturnValue = Strings.Left(lString, 15) + Strings.Right(new string(" ", Strings.Len(lText)) + rs.Fields("Company_Name").Value, Strings.Len(lText));
					return functionReturnValue;
				}
				if (Strings.InStr(lText, "TELEPHONE CENTER")) {
					functionReturnValue = Strings.Left(lString, 15) + doCenter(ref lText, ref rs.Fields("Company_Telephone").Value);
					return functionReturnValue;
				}
				if (Strings.InStr(lText, "TELEPHONE LEFT")) {
					functionReturnValue = Strings.Left(lString, 15) + Strings.Left(rs.Fields("Company_Telephone").Value, Strings.Len(lText));
					return functionReturnValue;
				}
				if (Strings.InStr(lText, "TELEPHONE RIGHT")) {
					functionReturnValue = Strings.Left(lString, 15) + Strings.Right(new string(" ", Strings.Len(lText)) + rs.Fields("Company_Telephone").Value, Strings.Len(lText));
					return functionReturnValue;
				}
				if (Strings.InStr(lText, "PRICEXXXXX")) {
					functionReturnValue = Strings.Left(lString, 15) + Strings.Replace(lText, lText, Strings.Right(new string(" ", Strings.Len(lText)) + rs.Fields("Price").Value, Strings.Len(lText)));
					return functionReturnValue;
				}
				if (Strings.InStr(lText, "PRICEX")) {
					functionReturnValue = Strings.Left(lString, 15) + Strings.Replace(lText, lText, Strings.Right(new string(" ", Strings.Len(lText)) + Strings.Split(rs.Fields("Price").Value + ".00", ".")[0], Strings.Len(lText)));
					return functionReturnValue;
				}


				if (Strings.InStr(lText, "PRIC4XXXXX")) {
					functionReturnValue = Strings.Left(lString, 15) + Strings.Replace(lText, lText, Strings.Right(new string(" ", Strings.Len(lText)) + rs.Fields("Price").Value, Strings.Len(lText)));
					return functionReturnValue;
				}
				if (Strings.InStr(lText, "PRIC1XXXXX")) {
					rsShrink = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, StockItem.StockItem_ShrinkID, Shrink.ShrinkID, ShrinkItem.ShrinkItem_ShrinkID, ShrinkItem.ShrinkItem_Quantity FROM (Shrink INNER JOIN StockItem ON Shrink.ShrinkID = StockItem.StockItem_ShrinkID) INNER JOIN ShrinkItem ON Shrink.ShrinkID = ShrinkItem.ShrinkItem_ShrinkID Where (((StockItem.stockitemID) = " + rs.Fields("StockItemID").Value + ")) ORDER BY StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity;");
					x = 0;
					if (rsShrink.RecordCount > 0) {

						while (!(rsShrink.EOF)) {
							if (rsShrink.Fields("ShrinkItem_Quantity").Value > 1) {
								if (x == 0) {
									rsP = modRecordSet.getRS(ref "SELECT TOP 1 PriceChannelLnk.PriceChannelLnk_StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk Where (((PriceChannelLnk.PriceChannelLnk_StockItemID) = " + rsShrink.Fields("StockItemID").Value + ") And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = " + rsShrink.Fields("ShrinkItem_Quantity").Value + ")) ORDER BY PriceChannelLnk.PriceChannelLnk_Quantity DESC;");
									if (rsP.RecordCount > 0) {
										functionReturnValue = Strings.Left(lString, 15) + Strings.Replace(lText, lText, Strings.Right(new string(" ", Strings.Len(lText)) + Strings.FormatNumber(rsP.Fields("PriceChannelLnk_Price").Value, 2) + " FOR  ", Strings.Len(lText)));
									} else {
										rsP = modRecordSet.getRS(ref "SELECT TOP 1 CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk Where (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) = " + rsShrink.Fields("StockItemID").Value + ") And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = " + rsShrink.Fields("ShrinkItem_Quantity").Value + ")) ORDER BY CatalogueChannelLnk.CatalogueChannelLnk_Quantity DESC;");
										if (rsP.RecordCount > 0) {
											functionReturnValue = Strings.Left(lString, 15) + Strings.Replace(lText, lText, Strings.Right(new string(" ", Strings.Len(lText)) + Strings.FormatNumber(rsP.Fields("CatalogueChannelLnk_Price").Value, 2) + " FOR  ", Strings.Len(lText)));
										} else {
											//doString = Left(lString, 15) & Replace(lText, lText, Right(String(Len(lText), " ") & Split(rs("Price") & ".00", ".")(0), Len(lText)))
										}
									}
									x = x + 1;

								} else if (x == 1) {
									x = x + 1;

								} else if (x == 2) {
									x = x + 1;
								}

							}

							rsShrink.MoveNext();
						}
					}
					return functionReturnValue;

				}
				if (Strings.InStr(lText, "PRIC2XXXXX")) {
					rsShrink = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, StockItem.StockItem_ShrinkID, Shrink.ShrinkID, ShrinkItem.ShrinkItem_ShrinkID, ShrinkItem.ShrinkItem_Quantity FROM (Shrink INNER JOIN StockItem ON Shrink.ShrinkID = StockItem.StockItem_ShrinkID) INNER JOIN ShrinkItem ON Shrink.ShrinkID = ShrinkItem.ShrinkItem_ShrinkID Where (((StockItem.stockitemID) = " + rs.Fields("StockItemID").Value + ")) ORDER BY StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity;");
					x = 0;
					if (rsShrink.RecordCount > 0) {

						while (!(rsShrink.EOF)) {
							if (rsShrink.Fields("ShrinkItem_Quantity").Value > 1) {

								if (x == 0) {
									x = x + 1;
								} else if (x == 1) {
									rsP = modRecordSet.getRS(ref "SELECT TOP 1 PriceChannelLnk.PriceChannelLnk_StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk Where (((PriceChannelLnk.PriceChannelLnk_StockItemID) = " + rsShrink.Fields("StockItemID").Value + ") And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = " + rsShrink.Fields("ShrinkItem_Quantity").Value + ")) ORDER BY PriceChannelLnk.PriceChannelLnk_Quantity DESC;");
									if (rsP.RecordCount > 0) {
										functionReturnValue = Strings.Left(lString, 15) + Strings.Replace(lText, lText, Strings.Right(new string(" ", Strings.Len(lText)) + Strings.FormatNumber(rsP.Fields("PriceChannelLnk_Price").Value, 2) + " FOR  ", Strings.Len(lText)));
									} else {
										rsP = modRecordSet.getRS(ref "SELECT TOP 1 CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk Where (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) = " + rsShrink.Fields("StockItemID").Value + ") And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = " + rsShrink.Fields("ShrinkItem_Quantity").Value + ")) ORDER BY CatalogueChannelLnk.CatalogueChannelLnk_Quantity DESC;");
										if (rsP.RecordCount > 0) {
											functionReturnValue = Strings.Left(lString, 15) + Strings.Replace(lText, lText, Strings.Right(new string(" ", Strings.Len(lText)) + Strings.FormatNumber(rsP.Fields("CatalogueChannelLnk_Price").Value, 2) + " FOR  ", Strings.Len(lText)));
										} else {
											//doString = Left(lString, 15) & Replace(lText, lText, Right(String(Len(lText), " ") & Split(rs("Price") & ".00", ".")(0), Len(lText)))
										}
									}
									x = x + 1;

								} else if (x == 2) {
									x = x + 1;
								}

							}

							rsShrink.MoveNext();
						}
					}
					return functionReturnValue;
				}
				if (Strings.InStr(lText, "PRIC3XXXXX")) {
					rsShrink = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, StockItem.StockItem_ShrinkID, Shrink.ShrinkID, ShrinkItem.ShrinkItem_ShrinkID, ShrinkItem.ShrinkItem_Quantity FROM (Shrink INNER JOIN StockItem ON Shrink.ShrinkID = StockItem.StockItem_ShrinkID) INNER JOIN ShrinkItem ON Shrink.ShrinkID = ShrinkItem.ShrinkItem_ShrinkID Where (((StockItem.stockitemID) = " + rs.Fields("StockItemID").Value + ")) ORDER BY StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity;");
					x = 0;
					if (rsShrink.RecordCount > 0) {

						while (!(rsShrink.EOF)) {
							if (rsShrink.Fields("ShrinkItem_Quantity").Value > 1) {

								if (x == 0) {
									x = x + 1;

								} else if (x == 1) {
									x = x + 1;
								} else if (x == 2) {
									rsP = modRecordSet.getRS(ref "SELECT TOP 1 PriceChannelLnk.PriceChannelLnk_StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk Where (((PriceChannelLnk.PriceChannelLnk_StockItemID) = " + rsShrink.Fields("StockItemID").Value + ") And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = " + rsShrink.Fields("ShrinkItem_Quantity").Value + ")) ORDER BY PriceChannelLnk.PriceChannelLnk_Quantity DESC;");
									if (rsP.RecordCount > 0) {
										functionReturnValue = Strings.Left(lString, 15) + Strings.Replace(lText, lText, Strings.Right(new string(" ", Strings.Len(lText)) + Strings.FormatNumber(rsP.Fields("PriceChannelLnk_Price").Value, 2) + " FOR  ", Strings.Len(lText)));
									} else {
										rsP = modRecordSet.getRS(ref "SELECT TOP 1 CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk Where (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) = " + rsShrink.Fields("StockItemID").Value + ") And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = " + rsShrink.Fields("ShrinkItem_Quantity").Value + ")) ORDER BY CatalogueChannelLnk.CatalogueChannelLnk_Quantity DESC;");
										if (rsP.RecordCount > 0) {
											functionReturnValue = Strings.Left(lString, 15) + Strings.Replace(lText, lText, Strings.Right(new string(" ", Strings.Len(lText)) + Strings.FormatNumber(rsP.Fields("CatalogueChannelLnk_Price").Value, 2) + " FOR  ", Strings.Len(lText)));
										} else {
											//doString = Left(lString, 15) & Replace(lText, lText, Right(String(Len(lText), " ") & Split(rs("Price") & ".00", ".")(0), Len(lText)))
										}
									}
									x = x + 1;
								}

							}

							rsShrink.MoveNext();
						}
					}
					return functionReturnValue;
				}

				if (lText == "S1") {
					rsShrink = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, StockItem.StockItem_ShrinkID, Shrink.ShrinkID, ShrinkItem.ShrinkItem_ShrinkID, ShrinkItem.ShrinkItem_Quantity FROM (Shrink INNER JOIN StockItem ON Shrink.ShrinkID = StockItem.StockItem_ShrinkID) INNER JOIN ShrinkItem ON Shrink.ShrinkID = ShrinkItem.ShrinkItem_ShrinkID Where (((StockItem.stockitemID) = " + rs.Fields("StockItemID").Value + ")) ORDER BY StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity;");
					x = 0;
					if (rsShrink.RecordCount > 0) {

						while (!(rsShrink.EOF)) {
							if (rsShrink.Fields("ShrinkItem_Quantity").Value > 1) {
								if (x == 0) {
									rsP = modRecordSet.getRS(ref "SELECT TOP 1 PriceChannelLnk.PriceChannelLnk_StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk Where (((PriceChannelLnk.PriceChannelLnk_StockItemID) = " + rsShrink.Fields("StockItemID").Value + ") And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = " + rsShrink.Fields("ShrinkItem_Quantity").Value + ")) ORDER BY PriceChannelLnk.PriceChannelLnk_Quantity DESC;");
									if (rsP.RecordCount > 0) {
										functionReturnValue = Strings.Left(lString, 15) + Strings.Right(new string(" ", Strings.Len(lText)) + rsP.Fields("PriceChannelLnk_Quantity").Value, Strings.Len(lText));
									} else {
										rsP = modRecordSet.getRS(ref "SELECT TOP 1 CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk Where (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) = " + rsShrink.Fields("StockItemID").Value + ") And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = " + rsShrink.Fields("ShrinkItem_Quantity").Value + ")) ORDER BY CatalogueChannelLnk.CatalogueChannelLnk_Quantity DESC;");
										if (rsP.RecordCount > 0) {
											functionReturnValue = Strings.Left(lString, 15) + Strings.Right(new string(" ", Strings.Len(lText)) + rsP.Fields("CatalogueChannelLnk_Quantity").Value, Strings.Len(lText));

										} else {
										}
									}
									x = x + 1;

								} else if (x == 1) {
									x = x + 1;

								} else if (x == 2) {
									x = x + 1;
								}

							}

							rsShrink.MoveNext();
						}
					}
					return functionReturnValue;

				}
				if (lText == "S2") {
					rsShrink = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, StockItem.StockItem_ShrinkID, Shrink.ShrinkID, ShrinkItem.ShrinkItem_ShrinkID, ShrinkItem.ShrinkItem_Quantity FROM (Shrink INNER JOIN StockItem ON Shrink.ShrinkID = StockItem.StockItem_ShrinkID) INNER JOIN ShrinkItem ON Shrink.ShrinkID = ShrinkItem.ShrinkItem_ShrinkID Where (((StockItem.stockitemID) = " + rs.Fields("StockItemID").Value + ")) ORDER BY StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity;");
					x = 0;
					if (rsShrink.RecordCount > 0) {

						while (!(rsShrink.EOF)) {
							if (rsShrink.Fields("ShrinkItem_Quantity").Value > 1) {

								if (x == 0) {
									x = x + 1;
								} else if (x == 1) {
									rsP = modRecordSet.getRS(ref "SELECT TOP 1 PriceChannelLnk.PriceChannelLnk_StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk Where (((PriceChannelLnk.PriceChannelLnk_StockItemID) = " + rsShrink.Fields("StockItemID").Value + ") And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = " + rsShrink.Fields("ShrinkItem_Quantity").Value + ")) ORDER BY PriceChannelLnk.PriceChannelLnk_Quantity DESC;");
									if (rsP.RecordCount > 0) {
										functionReturnValue = Strings.Left(lString, 15) + Strings.Right(new string(" ", Strings.Len(lText)) + rsP.Fields("PriceChannelLnk_Quantity").Value, Strings.Len(lText));
									} else {
										rsP = modRecordSet.getRS(ref "SELECT TOP 1 CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk Where (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) = " + rsShrink.Fields("StockItemID").Value + ") And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = " + rsShrink.Fields("ShrinkItem_Quantity").Value + ")) ORDER BY CatalogueChannelLnk.CatalogueChannelLnk_Quantity DESC;");
										if (rsP.RecordCount > 0) {
											functionReturnValue = Strings.Left(lString, 15) + Strings.Right(new string(" ", Strings.Len(lText)) + rsP.Fields("CatalogueChannelLnk_Quantity").Value, Strings.Len(lText));

										} else {
										}
									}
									x = x + 1;

								} else if (x == 2) {
									x = x + 1;
								}

							}

							rsShrink.MoveNext();
						}
					}
					return functionReturnValue;
				}
				if (lText == "S3") {
					rsShrink = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, StockItem.StockItem_ShrinkID, Shrink.ShrinkID, ShrinkItem.ShrinkItem_ShrinkID, ShrinkItem.ShrinkItem_Quantity FROM (Shrink INNER JOIN StockItem ON Shrink.ShrinkID = StockItem.StockItem_ShrinkID) INNER JOIN ShrinkItem ON Shrink.ShrinkID = ShrinkItem.ShrinkItem_ShrinkID Where (((StockItem.stockitemID) = " + rs.Fields("StockItemID").Value + ")) ORDER BY StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity;");
					x = 0;
					if (rsShrink.RecordCount > 0) {

						while (!(rsShrink.EOF)) {
							if (rsShrink.Fields("ShrinkItem_Quantity").Value > 1) {

								if (x == 0) {
									x = x + 1;

								} else if (x == 1) {
									x = x + 1;
								} else if (x == 2) {
									rsP = modRecordSet.getRS(ref "SELECT TOP 1 PriceChannelLnk.PriceChannelLnk_StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk Where (((PriceChannelLnk.PriceChannelLnk_StockItemID) = " + rsShrink.Fields("StockItemID").Value + ") And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = " + rsShrink.Fields("ShrinkItem_Quantity").Value + ")) ORDER BY PriceChannelLnk.PriceChannelLnk_Quantity DESC;");
									if (rsP.RecordCount > 0) {
										functionReturnValue = Strings.Left(lString, 15) + Strings.Right(new string(" ", Strings.Len(lText)) + rsP.Fields("PriceChannelLnk_Quantity").Value, Strings.Len(lText));
									} else {
										rsP = modRecordSet.getRS(ref "SELECT TOP 1 CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk Where (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) = " + rsShrink.Fields("StockItemID").Value + ") And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = " + rsShrink.Fields("ShrinkItem_Quantity").Value + ")) ORDER BY CatalogueChannelLnk.CatalogueChannelLnk_Quantity DESC;");
										if (rsP.RecordCount > 0) {
											functionReturnValue = Strings.Left(lString, 15) + Strings.Right(new string(" ", Strings.Len(lText)) + rsP.Fields("CatalogueChannelLnk_Quantity").Value, Strings.Len(lText));

										} else {
										}
									}
									x = x + 1;
								}

							}

							rsShrink.MoveNext();
						}
					}
					return functionReturnValue;
				}

				if (lText == "(P1 ea)") {
					rsShrink = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, StockItem.StockItem_ShrinkID, Shrink.ShrinkID, ShrinkItem.ShrinkItem_ShrinkID, ShrinkItem.ShrinkItem_Quantity FROM (Shrink INNER JOIN StockItem ON Shrink.ShrinkID = StockItem.StockItem_ShrinkID) INNER JOIN ShrinkItem ON Shrink.ShrinkID = ShrinkItem.ShrinkItem_ShrinkID Where (((StockItem.stockitemID) = " + rs.Fields("StockItemID").Value + ")) ORDER BY StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity;");
					x = 0;
					if (rsShrink.RecordCount > 0) {

						while (!(rsShrink.EOF)) {
							if (rsShrink.Fields("ShrinkItem_Quantity").Value > 1) {
								if (x == 0) {
									rsP = modRecordSet.getRS(ref "SELECT TOP 1 PriceChannelLnk.PriceChannelLnk_StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk Where (((PriceChannelLnk.PriceChannelLnk_StockItemID) = " + rsShrink.Fields("StockItemID").Value + ") And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = " + rsShrink.Fields("ShrinkItem_Quantity").Value + ")) ORDER BY PriceChannelLnk.PriceChannelLnk_Quantity DESC;");
									if (rsP.RecordCount > 0) {
										functionReturnValue = Strings.Left(lString, 15) + Strings.Left("(" + Strings.FormatNumber((rsP.Fields("PriceChannelLnk_Price").Value ? rsP.Fields("PriceChannelLnk_Price").Value : 1) / (rsP.Fields("PriceChannelLnk_Quantity").Value ? rsP.Fields("PriceChannelLnk_Quantity").Value : 1), 2) + " ea)", Strings.Len(" (" + Strings.FormatNumber((rsP.Fields("PriceChannelLnk_Price").Value ? rsP.Fields("PriceChannelLnk_Price").Value : 1) / (rsP.Fields("PriceChannelLnk_Quantity").Value ? rsP.Fields("PriceChannelLnk_Quantity").Value : 1), 2) + " ea)"));
									} else {
										rsP = modRecordSet.getRS(ref "SELECT TOP 1 CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk Where (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) = " + rsShrink.Fields("StockItemID").Value + ") And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = " + rsShrink.Fields("ShrinkItem_Quantity").Value + ")) ORDER BY CatalogueChannelLnk.CatalogueChannelLnk_Quantity DESC;");
										if (rsP.RecordCount > 0) {
											functionReturnValue = Strings.Left(lString, 15) + Strings.Left("(" + Strings.FormatNumber((rsP.Fields("CatalogueChannelLnk_Price").Value ? rsP.Fields("CatalogueChannelLnk_Price").Value : 1) / (rsP.Fields("CatalogueChannelLnk_Quantity").Value ? rsP.Fields("CatalogueChannelLnk_Quantity").Value : 1), 2) + " ea)", Strings.Len(" (" + Strings.FormatNumber((rsP.Fields("CatalogueChannelLnk_Price").Value ? rsP.Fields("CatalogueChannelLnk_Price").Value : 1) / (rsP.Fields("CatalogueChannelLnk_Quantity").Value ? rsP.Fields("CatalogueChannelLnk_Quantity").Value : 1), 2) + " ea)"));

										} else {
										}
									}
									x = x + 1;

								} else if (x == 1) {
									x = x + 1;

								} else if (x == 2) {
									x = x + 1;
								}

							}

							rsShrink.MoveNext();
						}
					}
					return functionReturnValue;

				}
				if (lText == "(P2 ea)") {
					rsShrink = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, StockItem.StockItem_ShrinkID, Shrink.ShrinkID, ShrinkItem.ShrinkItem_ShrinkID, ShrinkItem.ShrinkItem_Quantity FROM (Shrink INNER JOIN StockItem ON Shrink.ShrinkID = StockItem.StockItem_ShrinkID) INNER JOIN ShrinkItem ON Shrink.ShrinkID = ShrinkItem.ShrinkItem_ShrinkID Where (((StockItem.stockitemID) = " + rs.Fields("StockItemID").Value + ")) ORDER BY StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity;");
					x = 0;
					if (rsShrink.RecordCount > 0) {

						while (!(rsShrink.EOF)) {
							if (rsShrink.Fields("ShrinkItem_Quantity").Value > 1) {

								if (x == 0) {
									x = x + 1;
								} else if (x == 1) {
									rsP = modRecordSet.getRS(ref "SELECT TOP 1 PriceChannelLnk.PriceChannelLnk_StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk Where (((PriceChannelLnk.PriceChannelLnk_StockItemID) = " + rsShrink.Fields("StockItemID").Value + ") And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = " + rsShrink.Fields("ShrinkItem_Quantity").Value + ")) ORDER BY PriceChannelLnk.PriceChannelLnk_Quantity DESC;");
									if (rsP.RecordCount > 0) {
										functionReturnValue = Strings.Left(lString, 15) + Strings.Left("(" + Strings.FormatNumber((rsP.Fields("PriceChannelLnk_Price").Value ? rsP.Fields("PriceChannelLnk_Price").Value : 1) / (rsP.Fields("PriceChannelLnk_Quantity").Value ? rsP.Fields("PriceChannelLnk_Quantity").Value : 1), 2) + " ea)", Strings.Len(" (" + Strings.FormatNumber((rsP.Fields("PriceChannelLnk_Price").Value ? rsP.Fields("PriceChannelLnk_Price").Value : 1) / (rsP.Fields("PriceChannelLnk_Quantity").Value ? rsP.Fields("PriceChannelLnk_Quantity").Value : 1), 2) + " ea)"));
									} else {
										rsP = modRecordSet.getRS(ref "SELECT TOP 1 CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk Where (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) = " + rsShrink.Fields("StockItemID").Value + ") And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = " + rsShrink.Fields("ShrinkItem_Quantity").Value + ")) ORDER BY CatalogueChannelLnk.CatalogueChannelLnk_Quantity DESC;");
										if (rsP.RecordCount > 0) {
											functionReturnValue = Strings.Left(lString, 15) + Strings.Left("(" + Strings.FormatNumber((rsP.Fields("CatalogueChannelLnk_Price").Value ? rsP.Fields("CatalogueChannelLnk_Price").Value : 1) / (rsP.Fields("CatalogueChannelLnk_Quantity").Value ? rsP.Fields("CatalogueChannelLnk_Quantity").Value : 1), 2) + " ea)", Strings.Len(" (" + Strings.FormatNumber((rsP.Fields("CatalogueChannelLnk_Price").Value ? rsP.Fields("CatalogueChannelLnk_Price").Value : 1) / (rsP.Fields("CatalogueChannelLnk_Quantity").Value ? rsP.Fields("CatalogueChannelLnk_Quantity").Value : 1), 2) + " ea)"));

										} else {
										}
									}
									x = x + 1;

								} else if (x == 2) {
									x = x + 1;
								}

							}

							rsShrink.MoveNext();
						}
					}
					return functionReturnValue;
				}
				if (lText == "(P3 ea)") {
					rsShrink = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, StockItem.StockItem_ShrinkID, Shrink.ShrinkID, ShrinkItem.ShrinkItem_ShrinkID, ShrinkItem.ShrinkItem_Quantity FROM (Shrink INNER JOIN StockItem ON Shrink.ShrinkID = StockItem.StockItem_ShrinkID) INNER JOIN ShrinkItem ON Shrink.ShrinkID = ShrinkItem.ShrinkItem_ShrinkID Where (((StockItem.stockitemID) = " + rs.Fields("StockItemID").Value + ")) ORDER BY StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity;");
					x = 0;
					if (rsShrink.RecordCount > 0) {

						while (!(rsShrink.EOF)) {
							if (rsShrink.Fields("ShrinkItem_Quantity").Value > 1) {

								if (x == 0) {
									x = x + 1;

								} else if (x == 1) {
									x = x + 1;
								} else if (x == 2) {
									rsP = modRecordSet.getRS(ref "SELECT TOP 1 PriceChannelLnk.PriceChannelLnk_StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk Where (((PriceChannelLnk.PriceChannelLnk_StockItemID) = " + rsShrink.Fields("StockItemID").Value + ") And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = " + rsShrink.Fields("ShrinkItem_Quantity").Value + ")) ORDER BY PriceChannelLnk.PriceChannelLnk_Quantity DESC;");
									if (rsP.RecordCount > 0) {
										functionReturnValue = Strings.Left(lString, 15) + Strings.Left("(" + Strings.FormatNumber((rsP.Fields("PriceChannelLnk_Price").Value ? rsP.Fields("PriceChannelLnk_Price").Value : 1) / (rsP.Fields("PriceChannelLnk_Quantity").Value ? rsP.Fields("PriceChannelLnk_Quantity").Value : 1), 2) + " ea)", Strings.Len(" (" + Strings.FormatNumber((rsP.Fields("PriceChannelLnk_Price").Value ? rsP.Fields("PriceChannelLnk_Price").Value : 1) / (rsP.Fields("PriceChannelLnk_Quantity").Value ? rsP.Fields("PriceChannelLnk_Quantity").Value : 1), 2) + " ea)"));
									} else {
										rsP = modRecordSet.getRS(ref "SELECT TOP 1 CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk Where (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) = " + rsShrink.Fields("StockItemID").Value + ") And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = " + rsShrink.Fields("ShrinkItem_Quantity").Value + ")) ORDER BY CatalogueChannelLnk.CatalogueChannelLnk_Quantity DESC;");
										if (rsP.RecordCount > 0) {
											functionReturnValue = Strings.Left(lString, 15) + Strings.Left("(" + Strings.FormatNumber((rsP.Fields("CatalogueChannelLnk_Price").Value ? rsP.Fields("CatalogueChannelLnk_Price").Value : 1) / (rsP.Fields("CatalogueChannelLnk_Quantity").Value ? rsP.Fields("CatalogueChannelLnk_Quantity").Value : 1), 2) + " ea)", Strings.Len(" (" + Strings.FormatNumber((rsP.Fields("CatalogueChannelLnk_Price").Value ? rsP.Fields("CatalogueChannelLnk_Price").Value : 1) / (rsP.Fields("CatalogueChannelLnk_Quantity").Value ? rsP.Fields("CatalogueChannelLnk_Quantity").Value : 1), 2) + " ea)"));

										} else {
										}
									}
									x = x + 1;
								}

							}

							rsShrink.MoveNext();
						}
					}
					return functionReturnValue;
				}


				if (lText == "(P1 EA)") {
					rsShrink = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, StockItem.StockItem_ShrinkID, Shrink.ShrinkID, ShrinkItem.ShrinkItem_ShrinkID, ShrinkItem.ShrinkItem_Quantity FROM (Shrink INNER JOIN StockItem ON Shrink.ShrinkID = StockItem.StockItem_ShrinkID) INNER JOIN ShrinkItem ON Shrink.ShrinkID = ShrinkItem.ShrinkItem_ShrinkID Where (((StockItem.stockitemID) = " + rs.Fields("StockItemID").Value + ")) ORDER BY StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity;");
					x = 0;
					if (rsShrink.RecordCount > 0) {

						while (!(rsShrink.EOF)) {
							if (rsShrink.Fields("ShrinkItem_Quantity").Value > 1) {
								if (x == 0) {
									rsP = modRecordSet.getRS(ref "SELECT TOP 1 PriceChannelLnk.PriceChannelLnk_StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk Where (((PriceChannelLnk.PriceChannelLnk_StockItemID) = " + rsShrink.Fields("StockItemID").Value + ") And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = " + rsShrink.Fields("ShrinkItem_Quantity").Value + ")) ORDER BY PriceChannelLnk.PriceChannelLnk_Quantity DESC;");
									if (rsP.RecordCount > 0) {
										functionReturnValue = Strings.Left(lString, 15) + Strings.Left("(" + Strings.FormatNumber((rsP.Fields("PriceChannelLnk_Price").Value ? rsP.Fields("PriceChannelLnk_Price").Value : 1) / (rsP.Fields("PriceChannelLnk_Quantity").Value ? rsP.Fields("PriceChannelLnk_Quantity").Value : 1), 2) + " ea)", Strings.Len(" (" + Strings.FormatNumber((rsP.Fields("PriceChannelLnk_Price").Value ? rsP.Fields("PriceChannelLnk_Price").Value : 1) / (rsP.Fields("PriceChannelLnk_Quantity").Value ? rsP.Fields("PriceChannelLnk_Quantity").Value : 1), 2) + " EA)"));
									} else {
										rsP = modRecordSet.getRS(ref "SELECT TOP 1 CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk Where (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) = " + rsShrink.Fields("StockItemID").Value + ") And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = " + rsShrink.Fields("ShrinkItem_Quantity").Value + ")) ORDER BY CatalogueChannelLnk.CatalogueChannelLnk_Quantity DESC;");
										if (rsP.RecordCount > 0) {
											functionReturnValue = Strings.Left(lString, 15) + Strings.Left("(" + Strings.FormatNumber((rsP.Fields("CatalogueChannelLnk_Price").Value ? rsP.Fields("CatalogueChannelLnk_Price").Value : 1) / (rsP.Fields("CatalogueChannelLnk_Quantity").Value ? rsP.Fields("CatalogueChannelLnk_Quantity").Value : 1), 2) + " ea)", Strings.Len(" (" + Strings.FormatNumber((rsP.Fields("CatalogueChannelLnk_Price").Value ? rsP.Fields("CatalogueChannelLnk_Price").Value : 1) / (rsP.Fields("CatalogueChannelLnk_Quantity").Value ? rsP.Fields("CatalogueChannelLnk_Quantity").Value : 1), 2) + " EA)"));

										} else {
										}
									}
									x = x + 1;

								} else if (x == 1) {
									x = x + 1;

								} else if (x == 2) {
									x = x + 1;
								}

							}

							rsShrink.MoveNext();
						}
					}
					return functionReturnValue;

				}
				if (lText == "(P2 EA)") {
					rsShrink = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, StockItem.StockItem_ShrinkID, Shrink.ShrinkID, ShrinkItem.ShrinkItem_ShrinkID, ShrinkItem.ShrinkItem_Quantity FROM (Shrink INNER JOIN StockItem ON Shrink.ShrinkID = StockItem.StockItem_ShrinkID) INNER JOIN ShrinkItem ON Shrink.ShrinkID = ShrinkItem.ShrinkItem_ShrinkID Where (((StockItem.stockitemID) = " + rs.Fields("StockItemID").Value + ")) ORDER BY StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity;");
					x = 0;
					if (rsShrink.RecordCount > 0) {

						while (!(rsShrink.EOF)) {
							if (rsShrink.Fields("ShrinkItem_Quantity").Value > 1) {

								if (x == 0) {
									x = x + 1;
								} else if (x == 1) {
									rsP = modRecordSet.getRS(ref "SELECT TOP 1 PriceChannelLnk.PriceChannelLnk_StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk Where (((PriceChannelLnk.PriceChannelLnk_StockItemID) = " + rsShrink.Fields("StockItemID").Value + ") And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = " + rsShrink.Fields("ShrinkItem_Quantity").Value + ")) ORDER BY PriceChannelLnk.PriceChannelLnk_Quantity DESC;");
									if (rsP.RecordCount > 0) {
										functionReturnValue = Strings.Left(lString, 15) + Strings.Left("(" + Strings.FormatNumber((rsP.Fields("PriceChannelLnk_Price").Value ? rsP.Fields("PriceChannelLnk_Price").Value : 1) / (rsP.Fields("PriceChannelLnk_Quantity").Value ? rsP.Fields("PriceChannelLnk_Quantity").Value : 1), 2) + " ea)", Strings.Len(" (" + Strings.FormatNumber((rsP.Fields("PriceChannelLnk_Price").Value ? rsP.Fields("PriceChannelLnk_Price").Value : 1) / (rsP.Fields("PriceChannelLnk_Quantity").Value ? rsP.Fields("PriceChannelLnk_Quantity").Value : 1), 2) + " EA)"));
									} else {
										rsP = modRecordSet.getRS(ref "SELECT TOP 1 CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk Where (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) = " + rsShrink.Fields("StockItemID").Value + ") And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = " + rsShrink.Fields("ShrinkItem_Quantity").Value + ")) ORDER BY CatalogueChannelLnk.CatalogueChannelLnk_Quantity DESC;");
										if (rsP.RecordCount > 0) {
											functionReturnValue = Strings.Left(lString, 15) + Strings.Left("(" + Strings.FormatNumber((rsP.Fields("CatalogueChannelLnk_Price").Value ? rsP.Fields("CatalogueChannelLnk_Price").Value : 1) / (rsP.Fields("CatalogueChannelLnk_Quantity").Value ? rsP.Fields("CatalogueChannelLnk_Quantity").Value : 1), 2) + " ea)", Strings.Len(" (" + Strings.FormatNumber((rsP.Fields("CatalogueChannelLnk_Price").Value ? rsP.Fields("CatalogueChannelLnk_Price").Value : 1) / (rsP.Fields("CatalogueChannelLnk_Quantity").Value ? rsP.Fields("CatalogueChannelLnk_Quantity").Value : 1), 2) + " EA)"));

										} else {
										}
									}
									x = x + 1;

								} else if (x == 2) {
									x = x + 1;
								}

							}

							rsShrink.MoveNext();
						}
					}
					return functionReturnValue;
				}
				if (lText == "(P3 EA)") {
					rsShrink = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, StockItem.StockItem_ShrinkID, Shrink.ShrinkID, ShrinkItem.ShrinkItem_ShrinkID, ShrinkItem.ShrinkItem_Quantity FROM (Shrink INNER JOIN StockItem ON Shrink.ShrinkID = StockItem.StockItem_ShrinkID) INNER JOIN ShrinkItem ON Shrink.ShrinkID = ShrinkItem.ShrinkItem_ShrinkID Where (((StockItem.stockitemID) = " + rs.Fields("StockItemID").Value + ")) ORDER BY StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity;");
					x = 0;
					if (rsShrink.RecordCount > 0) {

						while (!(rsShrink.EOF)) {
							if (rsShrink.Fields("ShrinkItem_Quantity").Value > 1) {

								if (x == 0) {
									x = x + 1;

								} else if (x == 1) {
									x = x + 1;
								} else if (x == 2) {
									rsP = modRecordSet.getRS(ref "SELECT TOP 1 PriceChannelLnk.PriceChannelLnk_StockItemID, PriceChannelLnk.PriceChannelLnk_Quantity, PriceChannelLnk.PriceChannelLnk_ChannelID, PriceChannelLnk.PriceChannelLnk_Price From PriceChannelLnk Where (((PriceChannelLnk.PriceChannelLnk_StockItemID) = " + rsShrink.Fields("StockItemID").Value + ") And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = " + rsShrink.Fields("ShrinkItem_Quantity").Value + ")) ORDER BY PriceChannelLnk.PriceChannelLnk_Quantity DESC;");
									if (rsP.RecordCount > 0) {
										functionReturnValue = Strings.Left(lString, 15) + Strings.Left("(" + Strings.FormatNumber((rsP.Fields("PriceChannelLnk_Price").Value ? rsP.Fields("PriceChannelLnk_Price").Value : 1) / (rsP.Fields("PriceChannelLnk_Quantity").Value ? rsP.Fields("PriceChannelLnk_Quantity").Value : 1), 2) + " ea)", Strings.Len(" (" + Strings.FormatNumber((rsP.Fields("PriceChannelLnk_Price").Value ? rsP.Fields("PriceChannelLnk_Price").Value : 1) / (rsP.Fields("PriceChannelLnk_Quantity").Value ? rsP.Fields("PriceChannelLnk_Quantity").Value : 1), 2) + " EA)"));
									} else {
										rsP = modRecordSet.getRS(ref "SELECT TOP 1 CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price From CatalogueChannelLnk Where (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) = " + rsShrink.Fields("StockItemID").Value + ") And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = " + rsShrink.Fields("ShrinkItem_Quantity").Value + ")) ORDER BY CatalogueChannelLnk.CatalogueChannelLnk_Quantity DESC;");
										if (rsP.RecordCount > 0) {
											functionReturnValue = Strings.Left(lString, 15) + Strings.Left("(" + Strings.FormatNumber((rsP.Fields("CatalogueChannelLnk_Price").Value ? rsP.Fields("CatalogueChannelLnk_Price").Value : 1) / (rsP.Fields("CatalogueChannelLnk_Quantity").Value ? rsP.Fields("CatalogueChannelLnk_Quantity").Value : 1), 2) + " ea)", Strings.Len(" (" + Strings.FormatNumber((rsP.Fields("CatalogueChannelLnk_Price").Value ? rsP.Fields("CatalogueChannelLnk_Price").Value : 1) / (rsP.Fields("CatalogueChannelLnk_Quantity").Value ? rsP.Fields("CatalogueChannelLnk_Quantity").Value : 1), 2) + " EA)"));

										} else {
										}
									}
									x = x + 1;
								}

							}

							rsShrink.MoveNext();
						}
					}
					return functionReturnValue;
				}

				if (lText == "CCCC MM") {
					//doString = Left(lString, 15) & Replace(lText, lText, Left(String(Len(lText), " ") & Year(Now) & " " & Month(Now), Len(lText)))
					functionReturnValue = Strings.Left(lString, 15) + Strings.Left(DateAndTime.Year(DateAndTime.Now) + " " + DateAndTime.Month(DateAndTime.Now), Strings.Len(lText));
					return functionReturnValue;
				}

				//If InStr(lText, "XX") Then
				if (lText == "XX") {
					functionReturnValue = Strings.Left(lString, 15) + Strings.Replace(lText, lText, Strings.Right(new string(" ", Strings.Len(lText)) + Strings.Split(rs.Fields("Price").Value, ".")[1], Strings.Len(lText)));
					return functionReturnValue;
				}
				if (Strings.InStr(lText, "DEPARTMENT CENTER")) {
					functionReturnValue = Strings.Left(lString, 15) + doCenter(ref lText, ref rs.Fields("PricingGroup_Name").Value);
					return functionReturnValue;
				}
				if (Strings.InStr(lText, "DEPARTMENT LEFT")) {
					functionReturnValue = Strings.Left(lString, 15) + Strings.Left(rs.Fields("PricingGroup_Name").Value, Strings.Len(lText));
					return functionReturnValue;
				}
				if (Strings.InStr(lText, "DEPARTMENT RIGHT")) {
					functionReturnValue = Strings.Left(lString, 15) + Strings.Right(new string(" ", Strings.Len(lText)) + rs.Fields("PricingGroup_Name").Value, Strings.Len(lText));
					return functionReturnValue;
				}
				if (Strings.InStr(lText, "BARREAD CENTER")) {
					functionReturnValue = Strings.Left(lString, 15) + doCenter(ref lText, ref rs.Fields("Catalogue_Barcode").Value);
					return functionReturnValue;
				}
				if (Strings.InStr(lText, "BARREAD LEFT")) {
					functionReturnValue = Strings.Left(lString, 15) + Strings.Left(rs.Fields("Catalogue_Barcode").Value, Strings.Len(lText));
					return functionReturnValue;
				}
				if (Strings.InStr(lText, "BARREAD RIGHT")) {
					functionReturnValue = Strings.Left(lString, 15) + Strings.Right(new string(" ", Strings.Len(lText)) + rs.Fields("Catalogue_Barcode").Value, Strings.Len(lText));
					return functionReturnValue;
				}

				if (Strings.InStr(lText, "BARCODEXXXXXX")) {
					functionReturnValue = Strings.Left(lString, 15) + Strings.Right(new string(" ", Strings.Len(lText)) + rs.Fields("Catalogue_Barcode").Value, Strings.Len(lText));
					return functionReturnValue;
				}

				if (Strings.InStr(lText, "NAME 1 CENTER")) {
					lString1 = rs.Fields("Stockitem_Name").Value;
					if (rs.Fields("Catalogue_Quantity").Value != 1)
						lString1 = rs.Fields("Catalogue_Quantity").Value + "X" + lString1;
					splitString(ref Strings.Len(lText), ref lString1, ref lString2);
					functionReturnValue = Strings.Left(lString, 15) + doCenter(ref lText, ref lString1);
					return functionReturnValue;
				}
				if (Strings.InStr(lText, "NAME 1 LEFT")) {
					lString1 = rs.Fields("Stockitem_Name").Value;
					if (rs.Fields("Catalogue_Quantity").Value != 1)
						lString1 = rs.Fields("Catalogue_Quantity").Value + "X" + lString1;
					splitString(ref Strings.Len(lText), ref lString1, ref lString2);
					functionReturnValue = Strings.Left(lString, 15) + Strings.Left(lString1, Strings.Len(lText));
					return functionReturnValue;
				}
				if (Strings.InStr(lText, "NAME 1 RIGHT")) {
					lString1 = rs.Fields("Stockitem_Name").Value;
					if (rs.Fields("Catalogue_Quantity").Value != 1)
						lString1 = rs.Fields("Catalogue_Quantity").Value + "X" + lString1;
					splitString(ref Strings.Len(lText), ref lString1, ref lString2);
					functionReturnValue = Strings.Left(lString, 15) + Strings.Right(new string(" ", Strings.Len(lText)) + lString1, Strings.Len(lText));
					return functionReturnValue;
				}

				if (Strings.InStr(lText, "NAME 2 CENTER")) {
					lString1 = rs.Fields("Stockitem_Name").Value;
					if (rs.Fields("Catalogue_Quantity").Value != 1)
						lString1 = rs.Fields("Catalogue_Quantity").Value + "X" + lString1;
					splitString(ref Strings.Len(lText), ref lString1, ref lString2);
					functionReturnValue = Strings.Left(lString, 15) + doCenter(ref lText, ref lString2);
					return functionReturnValue;
				}
				if (Strings.InStr(lText, "NAME 2 LEFT")) {
					lString1 = rs.Fields("Stockitem_Name").Value;
					if (rs.Fields("Catalogue_Quantity").Value != 1)
						lString1 = rs.Fields("Catalogue_Quantity").Value + "X" + lString1;
					splitString(ref Strings.Len(lText), ref lString1, ref lString2);
					functionReturnValue = Strings.Left(lString, 15) + Strings.Left(lString2, Strings.Len(lText));
					return functionReturnValue;
				}
				if (Strings.InStr(lText, "NAME 2 RIGHT")) {
					lString1 = rs.Fields("Stockitem_Name").Value;
					if (rs.Fields("Catalogue_Quantity").Value != 1)
						lString1 = rs.Fields("Catalogue_Quantity").Value + "X" + lString1;
					splitString(ref Strings.Len(lText), ref lString1, ref lString2);
					functionReturnValue = Strings.Left(lString, 15) + Strings.Right(new string(" ", Strings.Len(lText)) + lString2, Strings.Len(lText));
					return functionReturnValue;
				}
				if (Strings.InStr(lText, "DATE")) {
					lString1 = Strings.Format(DateAndTime.Now, "yymm");
					functionReturnValue = Strings.Left(lString, 15) + Strings.Format(DateAndTime.Now, "yymm");
					return functionReturnValue;
				}

				//Expiry Date
				if (Strings.InStr(lText, "SELL BY")) {
					//lString1 = Format((Now() + rs("StockItem_ExpiryDays")), "dd/mm/yy")
					//doString = Left(lString, 15) & Format((Now() + rs("StockItem_ExpiryDays")), "dd/mm/yy")
					lString1 = rs.Fields("StockItem_ExpiryDays").Value;
					functionReturnValue = Strings.Left(lString, 15) + rs.Fields("StockItem_ExpiryDays").Value;
					return functionReturnValue;
				}

				if (lText == "BARCODE") {
					//If InStr(lText, "BARCODE") Then
					if (doCheckSum(ref rs.Fields("Catalogue_Barcode").Value)) {
					} else {
						functionReturnValue = Strings.Left(lString, 15) + rs.Fields("Catalogue_Barcode").Value;
					}
					return functionReturnValue;
				}
				if (Strings.InStr(lText, "600106007141")) {
					if (doCheckSum(ref rs.Fields("Catalogue_Barcode").Value)) {
						functionReturnValue = Strings.Left(lString, 15) + Strings.Left(rs.Fields("Catalogue_Barcode").Value + "0000", 13);
					}
					return functionReturnValue;
				}
				functionReturnValue = lString;
			} else {
				if (lString == "Q0001") {
					functionReturnValue = Strings.Replace(lString, "Q0001", "Q" + Strings.Right("0000" + rs.Fields("barcodePersonLnk_PrintQTY").Value, 4));
				} else {
					functionReturnValue = lString;
				}
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
			if (Strings.Len(value) > 9)
				value = Strings.Left(value + "00000", 13);
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
			string newstring = null;
			if (Strings.Len(origText) > Strings.Len(newstring)) {
				if (Convert.ToInt16((Strings.Len(origText) - Strings.Len(newText)) / 2) >= 0) {
					functionReturnValue = new string(" ", Convert.ToInt16((Strings.Len(origText) - Strings.Len(newText)) / 2)) + newText;
				} else {
					functionReturnValue = Strings.Left(newText, Strings.Len(origText));
				}
			} else {
				functionReturnValue = Strings.Left(newText, Strings.Len(origText));
			}
			return functionReturnValue;

		}

		private void splitStringA4(ref Label lObject, ref int lWidth, ref string HeadingString1, ref string HeadingString2)
		{
			System.Drawing.Printing.PrintDocument Printer = new System.Drawing.Printing.PrintDocument();
			short y = 0;
			short x = 0;
			string lHeading = null;
			lHeading = HeadingString1;
			HeadingString1 = lHeading + " ";
			HeadingString2 = "";
			if ((lWidth - lObject.Width) < 0) {
				for (x = Strings.Len(lHeading) + 1; x >= 1; x += -1) {
					HeadingString1 = Strings.Left(lHeading, x);
					if ((lWidth - lObject.Width + 50) > 0) {
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
				while (!(Printer.DefaultPageSettings.Bounds.Width <= lWidth)) {
					//Do Until Printer.PrinterSettings.TextWidth(HeadingString2) <= lWidth
					HeadingString2 = Strings.Mid(HeadingString2, 1, Strings.Len(HeadingString2) - 1);
				}
			}
			HeadingString1 = Strings.Trim(HeadingString1);
			HeadingString2 = Strings.Trim(HeadingString2);
		}

		private void cmdNext_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			lstBarcode_DoubleClick(lstBarcode, new System.EventArgs());
		}

		private void cndExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}
		private void frmBarcode_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			optBarcode.AddRange(new RadioButton[] {
				_optBarcode_1,
				_optBarcode_2
			});
			RadioButton rb = new RadioButton();
			foreach (RadioButton rb_loopVariable in optBarcode) {
				rb = rb_loopVariable;
				rb.CheckedChanged += optBarcode_CheckedChanged;
			}
			System.Drawing.Printing.PrintDocument Printer = new System.Drawing.Printing.PrintDocument();
			ADODB.Recordset rs = default(ADODB.Recordset);
			 // ERROR: Not supported in C#: OnErrorStatement


			string TheBarcodePrName = null;
			string lPrinter = null;

			lPrinter = My.MyProject.Forms.frmPrinter.selectPrinter();

			loadLanguage();

			if (string.IsNullOrEmpty(lPrinter)) {
				this.Close();
				return;

			} else {
				rs = modRecordSet.getRS(ref "SELECT * FROM PrinterOftenUsed");
				if (rs.RecordCount) {
					lblPrinter.Text = lPrinter;
					if (rs("PrinterType").Value == 2) {
						lblPrinterType.Tag = 1;
						lblPrinterType.Text = "Argox Barcode Printer";
					// Printer.Width <= 9000 Then  'TheBarcodePrName = "Datamax Allegro" Then 'if Printer.Width <= 9000 then or if Name= DatamaxNew code for Datamax Allegro still busy
					} else if (rs("PrinterType").Value == 3) {
						lblPrinterType.Tag = 3;
						lblPrinterType.Text = "Other Printer";
					} else if (rs("PrinterType").Value == 1) {
						lblPrinterType.Tag = 2;
						lblPrinterType.Text = "A4 Printer";
					}
				} else {
					lblPrinter.Text = lPrinter;
					if (Strings.InStr(Strings.LCase(Printer.PrinterSettings.PrinterName), "label")) {
						lblPrinterType.Tag = 1;
						lblPrinterType.Text = "Argox Barcode Printer";
					//TheBarcodePrName = "Datamax Allegro" Then 'if Printer.Width <= 9000 then or if Name= DatamaxNew code for Datamax Allegro still busy
					} else if (Printer.PrinterSettings.DefaultPageSettings.PaperSize.Width <= 9000) {
						//a = Printer.Height
						lblPrinterType.Tag = 3;
						lblPrinterType.Text = "Other Barcode Printer";
					} else {
						lblPrinterType.Tag = 2;
						lblPrinterType.Text = "A4 Printer";
					}
				}
				gType = 2;
				showLabels();
			}

			//Set rs = getRS("SELECT * FROM PrinterOftenUsed")
			if (modApplication.TheErr != -2147217865) {
				if (gType == 2) {
					//stBarcode.SelectedIndex = rs("LabelIndex")
				} else if (gType == 1) {
					lstBarcode.SelectedIndex = rs("ShelfIndex").Value;
				}
			}
		}

		private void lstBarcode_DoubleClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = new ADODB.Recordset();
			int lID = 0;
			string sBCode = null;
			decimal cQTY = default(decimal);

			rs = modRecordSet.getRS(ref "SELECT * FROM PrinterOftenUsed");

			if (rs.RecordCount > 0) {
				if (gType == 2) {
					rs = modRecordSet.getRS(ref "UPDATE PrinterOftenUsed SET PrinterIndex=" + rs("PrinterIndex").Value.ToString + " ,LabelIndex = " + lstBarcode.SelectedIndex.ToString() + " WHERE PrinterIndex=" + rs("PrinterIndex").Value.ToString + "");
				} else if (gType == 1) {
					rs = modRecordSet.getRS(ref "UPDATE PrinterOftenUsed SET PrinterIndex=" + rs("PrinterIndex").Value.ToString + " ,ShelfIndex=" + lstBarcode.SelectedIndex.ToString() + " WHERE PrinterIndex=" + rs("PrinterIndex").Value.ToString + "");
				}
			} else {
			}

			if (lstBarcode.SelectedIndex != -1) {
				switch (gType) {
					case 1:
					case 2:

						if (modApplication.scaleBCPrint == true) {
							lID = My.MyProject.Forms.frmStockList.getItem();
							if (lID != 0) {
								 // ERROR: Not supported in C#: OnErrorStatement

								if (My.MyProject.Forms.frmBarcodeScaleItem.loadItem(ref lID, ref cQTY, ref sBCode)) {
									printStockScale(ref cQTY, ref sBCode);
									//scaleBCPrint = False
								}
							}
						} else {
							//old way
							if (My.MyProject.Forms.frmBarcodeStockitem.loadStock()) {
								printStock();
							}
						}
						break;
					default:
						break;
				}
			}
		}

		private void printStockScale(ref decimal cQuantity = 0, ref string sBCode = "")
		{
			string sql = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			short x = 0;
			short C = 0;
			short D = 0;
			short CD = 0;
			string strCD = null;
			x = 0;
			C = 0;
			D = 0;
			CD = 0;
			strCD = "";

			string wCodemvarCodeID = null;
			string wCodemvarLenPrice = null;
			string code = null;
			string chkInput = null;

			chkInput = Convert.ToString(1);
			wCodemvarCodeID = Strings.Right("0000" + sBCode, 4);
			wCodemvarLenPrice = Strings.FormatCurrency(cQuantity, 2);
			wCodemvarLenPrice = Strings.Replace(wCodemvarLenPrice, "R", "");
			wCodemvarLenPrice = Strings.Replace(wCodemvarLenPrice, ",", "");
			wCodemvarLenPrice = Strings.Replace(wCodemvarLenPrice, ".", "");
			wCodemvarLenPrice = Strings.Replace(wCodemvarLenPrice, " ", "");
			wCodemvarLenPrice = Strings.Right("00000" + wCodemvarLenPrice, 5);
			chkInput = Convert.ToString(Rnd2(ref 1, ref 9));
			chkInput = Strings.Left(chkInput, 1);
			code = "20" + wCodemvarCodeID + chkInput + wCodemvarLenPrice + "0";
			//New CheckSum code
			// & format = 4 + 5 (4 digit for item & 5 digit for price)
			//If Val(wCodemvarCodeID) = 4 And Val(wCodemvarLenPrice) = 5 Then
			for (x = 1; x <= 6; x++) {
				C = C + Conversion.Val(Strings.Mid(code, x * 2, 1));
			}
			C = C * 3;

			for (x = 1; x <= 6; x++) {
				D = D + Conversion.Val(Strings.Mid(code, (x * 2) - 1, 1));
			}
			CD = C + D;

			strCD = Conversion.Str(CD);
			//CD = 10 - (Val(Right(CD, 1)))
			CD = 10 - (Conversion.Val(Strings.Right(Convert.ToString(CD), 1)));
			if (CD == 10)
				CD = 0;

			code = Strings.Left(code, 12) + CD;
			//End If
			//New CheckSum code

			//sql = "SELECT StockItem.StockItemID, Catalogue.Catalogue_Quantity, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Supplier.SupplierID, Supplier.Supplier_Name, PricingGroup.PricingGroupID, PricingGroup.PricingGroup_Name, Format([CatalogueChannelLnk_Price],'Currency') AS Price, barcodePersonLnk.barcodePersonLnk_PersonID, barcodePersonLnk.barcodePersonLnk_PrintQTY, Company.*, barcodePersonLnk.barcodePersonLnk_PrintQTY, Label.LabelID, Label.Label_TextStream, 'SELL BY ' & Format(NOW+[StockItem].[StockItem_ExpiryDays], 'dd/mm/yy') AS StockItem_ExpiryDays "
			sql = "SELECT StockItem.StockItemID, Catalogue.Catalogue_Quantity, StockItem.StockItem_Name, " + code + " AS Catalogue_Barcode, Supplier.SupplierID, Supplier.Supplier_Name, PricingGroup.PricingGroupID, PricingGroup.PricingGroup_Name, '" + Strings.FormatCurrency(cQuantity, 2) + "' AS Price, barcodePersonLnk.barcodePersonLnk_PersonID, barcodePersonLnk.barcodePersonLnk_PrintQTY, Company.*, barcodePersonLnk.barcodePersonLnk_PrintQTY, Label.LabelID, Label.Label_TextStream, 'SELL BY ' & Format(NOW+[StockItem].[StockItem_ExpiryDays], 'dd/mm/yy') AS StockItem_ExpiryDays ";
			sql = sql + "FROM Company, Label, barcodePersonLnk INNER JOIN ((((StockItem INNER JOIN Supplier ON StockItem.StockItem_SupplierID = Supplier.SupplierID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)) ON (barcodePersonLnk.barcodePersonLnk_StockItemID = Catalogue.Catalogue_StockItemID) AND (barcodePersonLnk.barcodePersonLnk_Shrink = Catalogue.Catalogue_Quantity) ";
			sql = sql + "WHERE (((barcodePersonLnk.barcodePersonLnk_PersonID)=" + modRecordSet.gPersonID + ") AND ((barcodePersonLnk.barcodePersonLnk_PrintQTY)<>0) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((Label.LabelID)=" + Convert.ToInt32(lstBarcode.SelectedIndex) + ")); ";
			rs = modRecordSet.getRS(ref sql);

			if (rs.RecordCount) {
				//Checks if the barcode/Shelf Talker button is clicked and displays the correct button.
				if (_optBarcode_2.Checked == true) {
					if (Interaction.MsgBox("You have selected " + rs.RecordCount + " products to print." + Constants.vbCrLf + Constants.vbCrLf + "Are you sure you wish to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "PRINT BARCODES") == MsgBoxResult.Yes) {
						if (Convert.ToDouble(lblPrinterType.Tag) == 1) {
							printStockBarcode(ref rs);

						} else if (Convert.ToDouble(lblPrinterType.Tag) == 2) {
							printStockA4(ref rs);

						} else if (Convert.ToDouble(lblPrinterType.Tag) == 3) {
							PrintBarcodeDatamax(ref rs);
						}
					}
				} else if (_optBarcode_1.Checked == true) {
					if (Interaction.MsgBox("You have selected " + rs.RecordCount + " products to print." + Constants.vbCrLf + Constants.vbCrLf + "Are you sure you wish to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "PRINT SHELF TALKER") == MsgBoxResult.Yes) {
						if (Convert.ToDouble(lblPrinterType.Tag) == 1) {
							printStockBarcode(ref rs);
						} else if (Convert.ToDouble(lblPrinterType.Tag) == 2) {
							//If InStr(LCase(lblPrinter), "label") Then
							printStockA4(ref rs);
							//Else
							//    printStockA4_OLD rs
							//End If
						} else if (Convert.ToDouble(lblPrinterType.Tag) == 3) {
							PrintBarcodeDatamax(ref rs);
						}
					}

				}
			}
		}

		private float Rnd2(ref float sngLow, ref float sngHigh)
		{
			VBMath.Randomize((GetTickCount() + DateAndTime.Now.ToOADate()));
			// Reseed with system time (2 ways)
			return (VBMath.Rnd() * (sngHigh - sngLow)) + sngLow;
		}

		private void optBarcode_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.Checked) {
				int Index = 0;
				RadioButton radBtn = new RadioButton();
				radBtn = (RadioButton)eventSender;
				Index = GetIndex.GetIndexer(ref radBtn, ref optBarcode);
				string stSring = null;
				ADODB.Recordset rsPrinter_B = new ADODB.Recordset();
				Scripting.FileSystemObject fso = new Scripting.FileSystemObject();

				//Doing shelf from file
				if (modApplication.grvPrin) {
					if (fso.FileExists(modRecordSet.serverPath + "ShelfBarcode.dat")) {
						rsPrinter_B.Open(modRecordSet.serverPath + "ShelfBarcode.dat");
						//If Index = 2 Then rsPrinter_B.filter = "StockItem_SBarcode ='barcode'"
						//If Index = 1 Then rsPrinter_B.filter = "StockItem_SBarcode ='shelf'"

						if (Index == 2)
							rsPrinter_B.Filter = "StockItem_SBarcode =true";
						if (Index == 1)
							rsPrinter_B.Filter = "StockItem_SShelf =true";
						if (rsPrinter_B.RecordCount > 0) {
							//grvPrinType = Index
						} else {
							if (Index == 2)
								stSring = "Barcode Labels";
							if (Index == 1)
								stSring = "Shelf Talkers";
							Interaction.MsgBox("There are no StockItem(s) to print " + stSring + " from!.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly + MsgBoxStyle.Information, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
							this.Close();
						}
					} else {
						Interaction.MsgBox("File " + modRecordSet.serverPath + "ShelfBarcode.dat not found.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
						this.Close();
					}
				}
				gType = Index;
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
		private void printStockA4(ref ADODB.Recordset rs)
		{
			decimal mm = default(decimal);
			int i = 0;
			int lline = 0;
			string bGroup = null;
			string sGroup = null;
			int lTop = 0;
			int lHeight = 0;
			int gOffsetLabel = 0;
			int dasd = 0;
			System.Drawing.Printing.PrintDocument Printer = new System.Drawing.Printing.PrintDocument();
			System.Drawing.Printing.PrintDocument lObject = new System.Drawing.Printing.PrintDocument();
			int y = 0;
			int x = 0;
			ADODB.Recordset rsData = default(ADODB.Recordset);
			int currentPic = 0;
			int twipsToMM = 0;
			int lLeft = 0;
			int lWidth = 0;
			short lCol = 0;
			short lCols = 0;
			short lRows = 0;
			short lrow = 0;
			 // ERROR: Not supported in C#: OnErrorStatement

			dasd = Printer.PrinterSettings.DefaultPageSettings.PaperSize.Width;
			//Printer.PrinterSettings.DefaultPageSettings.ScaleMode = ScaleModeConstants.vbTwips 'twips
			//twipsToMM = Printer.ScaleWidth
			//Printer.ScaleMode = ScaleModeConstants.vbMillimeters 'mm
			//twipsToMM = twipsToMM / Printer.ScaleWidth
			//Printer.ScaleMode = ScaleModeConstants.vbTwips 'twips
			lObject = Printer;

			string lString1 = null;
			string lString2 = null;

			rsData = modRecordSet.getRS(ref "SELECT * FROM labelItem INNER JOIN label ON labelItem.labelItem_LabelID = label.labelID Where (((label.labelID) = " + rs.Fields("LabelID").Value + ")) ORDER BY label.labelID, labelItem.labelItem_Line;");

			lLeft = (lObject.PrinterSettings.DefaultPageSettings.PaperSize.Width - (lWidth)) / 2 + (gOffsetLabel * twipsToMM);
			lLeft = 0;
			if (rsData.Fields("Label_Rotate").Value) {
				lWidth = rsData.Fields("label_Height").Value * twipsToMM;
				lHeight = rsData.Fields("label_Width").Value * twipsToMM;
			} else {
				lWidth = rsData.Fields("label_width").Value * twipsToMM;
				lHeight = rsData.Fields("label_Height").Value * twipsToMM;
			}
			lTop = rsData.Fields("label_Top").Value * twipsToMM;
			lCols = Convert.ToDecimal(Printer.PrinterSettings.DefaultPageSettings.PaperSize.Width / (lWidth + 60)) - 0.49999;
			lRows = Convert.ToDecimal(Printer.PrinterSettings.DefaultPageSettings.PaperSize.Height / (lHeight + 60)) - 0.49999;

			sGroup = "1";
			if (Strings.InStr(Strings.LCase(rsData.Fields("Label_Name").Value), "nursery")) {
				bGroup = "Yes";
			} else {
				bGroup = "No";
				printStockA4(ref rs);
				return;
			}

			while (!(rs.EOF)) {
				rsData.MoveFirst();
				y = 0;

				if (y < 0)
					y = 0;
				//lObject.FontName = "Tahoma"
				rsData.MoveFirst();
				if (rsData.RecordCount) {
					lline = rsData.Fields("labelItem_Line").Value;
					for (i = 1; i <= rs.Fields("barcodePersonLnk_PrintQTY").Value; i++) {
						lLeft = (Information.IsDBNull(rsData.Fields("Label_Left").Value) ? 0 : rsData.Fields("Label_Left").Value) * twipsToMM;
						//lLeft = 1200 'lCol * (lWidth + 60)

						//lObject.CurrentY = lrow * (lHeight + 60)
						rsData.MoveFirst();
						//y = lObject.CurrentY
						//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(Me.BackColor)
						 // ERROR: Not supported in C#: OnErrorStatement

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
								//y = lObject.CurrentY + 10
								lline = rsData.Fields("labelItem_Line").Value;
							}

							switch (Strings.LCase(Strings.Trim(rsData.Fields("labelItem_Field").Value))) {
								case "blank":
									break;
								//lObject.FontSize = rsData.Fields("labelItem_Size").Value
								//lObject.FontBold = rsData.Fields("labelItem_Bold").Value
								//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
								//lObject.Print(" ")
								case "line":
									break;
								//lObject.Line((15 + lLeft, y) - (lLeft + lWidth, y), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black))
								case "code":
									switch (rsData.Fields("labelItem_Align").Value) {
										case 1:
											if (bGroup == "Yes") {
												//Barcode CodeType, txtData, Printer, 15, 700, 3000, 250
												//Barcode "128", rs("Catalogue_Barcode"), lObject, 15, 700, lLeft + 90, Y
												AllCodes.Barcode(ref "128", ref rs.Fields("Catalogue_Barcode").Value, ref lObject, ref 24, ref 500, ref 2400, ref Convert.ToSingle(y));
											} else {
												//printBarcode(lObject, rs.Fields("Catalogue_Barcode").Value, lLeft + 90, y)
											}
											break;
										case 2:
											if (bGroup == "Yes") {
												AllCodes.Barcode(ref "128", ref rs.Fields("Catalogue_Barcode").Value, ref lObject, ref 24, ref 500, ref 2400, ref Convert.ToSingle(y));
											} else {
												//old line before jonas   printBarcode lObject, rs("Catalogue_Barcode"), lLeft + 90, y
												//printBarcode(lObject, rs.Fields("Catalogue_Barcode").Value, lLeft + 90, y, lWidth + lWidth - 1440)
											}
											break;
										default:
											if (bGroup == "Yes") {
												//Barcode "128", rs("Catalogue_Barcode"), lObject, 15, 700, lLeft + 90, Y
												AllCodes.Barcode(ref "128", ref rs.Fields("Catalogue_Barcode").Value, ref lObject, ref 24, ref 500, ref 2400, ref Convert.ToSingle(y));
												//3600
												//Barcode "128", "tZst1234", lObject, 24, 700, 2500, 130
											} else {
												//printBarcode(lObject, rs.Fields("Catalogue_Barcode").Value, lLeft, y, lWidth)
											}
											break;
									}
									break;
								default:
									//lObject.FontSize = rsData.Fields("labelItem_Size").Value
									//lObject.FontBold = rsData.Fields("labelItem_Bold").Value
									//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
									mm = rsData.Fields("labelItem_Field").Value;
									//code for printing shrinks

									//code for printing shrinks
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
											//splitStringA4(lObject, lWidth, lString1, lString2)
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

							if (bGroup == "Yes") {
								//sGroup = "1"

								//And rs("barcodePersonLnk_PrintQTY") = 1 Then
								if (sGroup != rsData.Fields("labelItem_Sample").Value) {
									if (rs.Fields("barcodePersonLnk_PrintQTY").Value == 1) {
										rs.moveNext();
									} else if (rs.Fields("barcodePersonLnk_PrintQTY").Value >= 1) {
										if (i == rs.Fields("barcodePersonLnk_PrintQTY").Value & sGroup == "4") {
											sGroup = "1";
											break; // TODO: might not be correct. Was : Exit Do
										} else if (i == rs.Fields("barcodePersonLnk_PrintQTY").Value) {
											rs.moveNext();
											i = 0;
										}
										i = i + 1;
									}
									sGroup = rsData.Fields("labelItem_Sample").Value;
								}

								//i = i + 1
								//If i >= rs("barcodePersonLnk_PrintQTY") Then
								//    sGroup = rsData("labelItem_Sample")
								//    'rs.moveNext
								//   Exit Do
								//End If
								if (rs.EOF)
									break; // TODO: might not be correct. Was : Exit Do
							}
							rsData.moveNext();
						}
						lCol = lCol + 1;
						if (lCol >= lCols) {
							lCol = 0;
							lrow = lrow + 1;
							//If (lrow + 1) * lHeight > lObject.Height Then
							// Printer.NewPage()
							// If bGroup = "Yes" Then
							// lrow = 0 '-1
							//Else
							//   lrow = -1
							// End If
							//End If
						}
						if (sGroup == "4")
							sGroup = "1";
					}
				}
				if (bGroup == "Yes") {
					if (rs.EOF)
						break; // TODO: might not be correct. Was : Exit Do
					if (sGroup == "4")
						sGroup = "1";
				}
				rs.moveNext();
			}
			//Printer.EndDoc()

			return;
			Err_printStockA4:
			//MsgBox Err.Description
			 // ERROR: Not supported in C#: ResumeStatement

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
				x = Convert.ToInt16(lLeft + (lWidth - Information.UBound(barArray) * sizeConvertors.twipsPerPixel(true) / 2));
			}
			for (cnt = Information.LBound(barArray); cnt <= Information.UBound(barArray); cnt++) {
				if (!string.IsNullOrEmpty(barArray[cnt])) {

					if (Convert.ToInt32(Strings.Split(barArray[cnt], "~")[0]) == System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)) {
						//barcodePicture.Line((x + cnt * twipsPerPixel(true), y) - (_
						//        x + (cnt + 1) * twipsPerPixel(true), _
						//        y + CInt(Split(barArray(cnt), "~")(1)) _
						//        * twipsPerPixel(True)), CInt(Split(barArray(cnt), "~")(0)), BF)
					}
				}

			}
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

		public bool PrintBarcodeDatamax(ref ADODB.Recordset rs)
		{
			string sql = null;
			string mm = null;
			int i = 0;
			int lline = 0;
			int lTop = 0;
			int lHeight = 0;
			System.Drawing.Printing.PrintDocument Printer = new System.Drawing.Printing.PrintDocument();
			System.Drawing.Printing.PrintDocument lObject = new System.Drawing.Printing.PrintDocument();
			int y = 0;
			int x = 0;
			ADODB.Recordset rsData = default(ADODB.Recordset);
			int currentPic = 0;
			int twipsToMM = 0;
			int lLeft = 0;
			int lWidth = 0;
			short lCol = 0;
			short lCols = 0;
			short lRows = 0;
			short lrow = 0;

			ADODB.Recordset rsPrice = default(ADODB.Recordset);

			//Printer.ScaleMode = ScaleModeConstants.vbTwips 'twips
			//twipsToMM = Printer.ScaleWidth
			//Printer.ScaleMode = ScaleModeConstants.vbMillimeters 'mm
			//twipsToMM = twipsToMM / Printer.ScaleWidth
			//Printer.ScaleMode = ScaleModeConstants.vbTwips 'twips
			lObject = Printer;

			string lString1 = null;
			string lString2 = null;
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

			while (!(rs.EOF)) {
				rsData.MoveFirst();
				y = 0;

				//If y < 0 Then y = 0
				//lObject.FontName = "Tahoma"
				rsData.MoveFirst();
				if (rsData.RecordCount) {
					lline = rsData.Fields("labelItem_Line").Value;

					for (i = 1; i <= rs.Fields("barcodePersonLnk_PrintQTY").Value; i++) {
						lLeft = (Information.IsDBNull(rsData.Fields("Label_Left").Value) ? 0 : rsData.Fields("Label_Left").Value) * twipsToMM;
						//lObject.CurrentY = lrow * (lHeight + 60)
						rsData.MoveFirst();
						//y = lObject.CurrentY
						//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(Me.BackColor)
						 // ERROR: Not supported in C#: OnErrorStatement

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
								//y = lObject.CurrentY + 10

								lline = rsData.Fields("labelItem_Line").Value;
							}

							switch (Strings.LCase(Strings.Trim(rsData.Fields("labelItem_Field").Value))) {
								case "blank":
									break;
								//lObject.FontSize = rsData.Fields("labelItem_Size").Value
								//lObject.FontBold = rsData.Fields("labelItem_Bold").Value
								//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
								//lObject.Print(" ")
								case "line":
									break;
								//lObject.Line((15 + lLeft, y) - (lLeft + lWidth, y), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black))

								case "code":
									switch (rsData.Fields("labelItem_Align").Value) {
										case 1:
											break;
										//printBarcode(lObject, rs.Fields("Catalogue_Barcode").Value, lLeft + 90, y)
										case 2:
											break;
										//printBarcode(lObject, rs.Fields("Catalogue_Barcode").Value, lLeft + 90, y, lWidth + lWidth - 1440)
										default:
											break;
										//printBarcode(lObject, rs.Fields("Catalogue_Barcode").Value, lLeft, y, lWidth)
									}

									break;
								default:
									//lObject.FontSize = rsData.Fields("labelItem_Size").Value
									//lObject.FontBold = rsData.Fields("labelItem_Bold").Value
									//lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
									mm = rsData.Fields("labelItem_Field").Value;
									//code for printing shrinks
									if (mm == "Price6") {
										sql = "SELECT StockItem.StockItemID, Format([CatalogueChannelLnk_Price],'Currency') AS Price ";
										sql = sql + "FROM (StockItem INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID ";
										sql = sql + "WHERE (((StockItem.StockItemID)=" + rs.Fields("StockItemID").Value + ") AND ((Catalogue.Catalogue_Quantity)=6) AND ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)=6) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));";
										rsPrice = modRecordSet.getRS(ref sql);
										if (rsPrice.RecordCount) {
											lString1 = rsPrice.Fields("Price").Value + " FOR   6";
										} else {
											lString1 = " ";
										}

									} else if (mm == "Price12") {
										sql = "SELECT StockItem.StockItemID, Format([CatalogueChannelLnk_Price],'Currency') AS Price ";
										sql = sql + "FROM (StockItem INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID ";
										sql = sql + "WHERE (((StockItem.StockItemID)=" + rs.Fields("StockItemID").Value + ") AND ((Catalogue.Catalogue_Quantity)=12) AND ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)=12) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));";
										rsPrice = modRecordSet.getRS(ref sql);
										if (rsPrice.RecordCount) {
											lString1 = rsPrice.Fields("Price").Value + " FOR  12";
										} else {
											lString1 = " ";
										}

									} else if (mm == "Price24") {
										sql = "SELECT StockItem.StockItemID, Format([CatalogueChannelLnk_Price],'Currency') AS Price ";
										sql = sql + "FROM (StockItem INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID ";
										sql = sql + "WHERE (((StockItem.StockItemID)=" + rs.Fields("StockItemID").Value + ") AND ((Catalogue.Catalogue_Quantity)=24) AND ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)=24) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));";
										rsPrice = modRecordSet.getRS(ref sql);
										if (rsPrice.RecordCount) {
											lString1 = rsPrice.Fields("Price").Value + " FOR  24";
										} else {
											lString1 = " ";
										}
									} else {
										lString1 = rs.Fields(mm).Value;
									}
									//code for printing shrinks

									//lString1 = rs(mm)
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
											//splitStringA4(lObject, lWidth, lString1, lString2)
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

										// lObject.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
										// lObject.Print(lString1)
									}
									break;
							}
							rsData.MoveNext();
						}

						//New code for tesing barcode printing

						//Printer.NewPage()

					}
				}
				rs.MoveNext();
			}
			//Printer.EndDoc()
		}
	}
}
