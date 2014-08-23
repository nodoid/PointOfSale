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
	internal partial class frmGRVselect : System.Windows.Forms.Form
	{
		short gMode;
		ADODB.Recordset rs;
		string HoldGrvID;
		string HoldGrvNo;

		int gBrandItem;
		int gStockItem;

		bool newATItem;
		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1621;
			//Select GRV Type|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1622;
			//Imported GRV Data|Checked
			if (modRecordSet.rsLang.RecordCount){_Frame1_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_Frame1_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1080;
			//Search|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1624;
			//Delete GRV|Checked
			if (modRecordSet.rsLang.RecordCount){Frame2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Frame2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1630;
			//Load Selecter GRV|Checked
			if (modRecordSet.rsLang.RecordCount){cmdEdit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdEdit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1631;
			//Create a New GRV|Checked
			if (modRecordSet.rsLang.RecordCount){cmdNew.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdNew.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1632;
			//Import a GRV|Checked
			if (modRecordSet.rsLang.RecordCount){cmdImport.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdImport.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//cmdAirTime = No Code   [Air Time GRV]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdAirTime.Caption = rsLang("LanguageLayoutLnk_Description"): cmdAirTime.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1634;
			//Import GRV Field.......|
			if (modRecordSet.rsLang.RecordCount){Label1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//Frame2 = No Code       [Importing Airtime File]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Frame2.Caption = rsLang("LanguageLayoutLnk_Description"): Frame2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmGRVselect.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public void loadItem()
		{
			doSearch();

			loadLanguage();
			ShowDialog();
		}
		private void loadGRV()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			System.Windows.Forms.ListViewItem listItem = null;
			lvImport.Items.Clear();
			rs = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, GRVimport.GRVimport_Key, GRVimport.GRVimport_Barcode, StockItem.StockItem_Name, Catalogue.Catalogue_Quantity, GRVimport.GRVimport_Quantity, GRVimport.GRVimport_Cost, GRVimport.GRVimport_Price FROM (GRVimport INNER JOIN Catalogue ON GRVimport.GRVimport_Barcode = Catalogue.Catalogue_Barcode) INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID;");
			while (!(rs.EOF)) {
				listItem = this.lvImport.Items.Add("k" + rs.Fields("stockitemID").Value, rs.Fields("GRVimport_Barcode").Value, "");
				if (listItem.SubItems.Count > 1) {
					listItem.SubItems[1].Text = rs.Fields("StockItem_Name").Value;
				} else {
					listItem.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("StockItem_Name").Value));
				}
				if (listItem.SubItems.Count > 2) {
					listItem.SubItems[2].Text = rs.Fields("Catalogue_Quantity").Value;
				} else {
					listItem.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("Catalogue_Quantity").Value));
				}
				if (listItem.SubItems.Count > 3) {
					listItem.SubItems[3].Text = rs.Fields("GRVimport_Quantity").Value;
				} else {
					listItem.SubItems.Insert(3, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("GRVimport_Quantity").Value));
				}
				if (listItem.SubItems.Count > 4) {
					listItem.SubItems[4].Text = Strings.FormatNumber(rs.Fields("GRVimport_Cost").Value, 2);
				} else {
					listItem.SubItems.Insert(4, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("GRVimport_Cost").Value, 2)));
				}
				if (listItem.SubItems.Count > 5) {
					listItem.SubItems[5].Text = Strings.FormatNumber(rs.Fields("GRVimport_Price").Value, 2);
				} else {
					listItem.SubItems.Insert(5, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("GRVimport_Price").Value, 2)));
				}
				if (listItem.SubItems.Count > 6) {
					listItem.SubItems[6].Text = rs.Fields("GRVimport_Key").Value;
				} else {
					listItem.SubItems.Insert(6, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("GRVimport_Key").Value));
				}
				rs.MoveNext();
			}
		}

		private string getSerialNumber()
		{
			string functionReturnValue = null;
			Scripting.FileSystemObject FSO = new Scripting.FileSystemObject();
			Scripting.Folder fsoFolder = default(Scripting.Folder);
			Scripting.Drive fsoDrive = default(Scripting.Drive);
			functionReturnValue = "";
			if (FSO.FolderExists(modRecordSet.serverPath)) {
				fsoFolder = FSO.GetFolder(modRecordSet.serverPath);
				functionReturnValue = Convert.ToString(fsoFolder.Drive.SerialNumber);
			}
			return functionReturnValue;
		}

		private string Encrypt(string secret, string password)
		{
			int l = 0;
			short x = 0;
			string Char_Renamed = null;
			l = Strings.Len(password);
			for (x = 1; x <= Strings.Len(secret); x++) {
				Char_Renamed = Convert.ToString(Strings.Asc(Strings.Mid(password, (x % l) - l * Convert.ToInt16((x % l) == 0), 1)));
				Strings.Mid(secret, x, 1) = Strings.Chr(Strings.Asc(Strings.Mid(secret, x, 1)) ^ Char_Renamed);
			}
			return secret;
		}

		private bool bolSecurityCode()
		{
			bool functionReturnValue = false;
			string lCode = null;
			string leCode = null;
			string lPassword = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			short x = 0;

			short intDate = 0;
			short intYear = 0;
			short intMonth = 0;

			string stPass = null;
			string givPass = null;

			 // ERROR: Not supported in C#: OnErrorStatement


			functionReturnValue = false;
			if (modRecordSet.openConnection()) {
				rs = modRecordSet.getRS(ref "SELECT * From Company");
				if (rs.RecordCount) {
					if (Information.IsNumeric(rs.Fields("Company_PosString").Value)) {
						modApplication.gSecKey = rs.Fields("Company_PosString").Value;
						if (Strings.Len(rs.Fields("Company_PosString").Value) == 13) {
							functionReturnValue = true;
							return functionReturnValue;
						}
					}

					if (Information.IsDBNull(rs.Fields("Company_PosString").Value) | rs.Fields("Company_PosString").Value == "0") {
						functionReturnValue = true;
						return functionReturnValue;
					}

					if (Information.IsNumeric(rs.Fields("Company_PosString").Value)) {
						intYear = Convert.ToInt16(Strings.Left(rs.Fields("Company_PosString").Value, 2));
						intMonth = Convert.ToInt16(Strings.Mid(rs.Fields("Company_PosString").Value, 3, 2));
						intDate = Convert.ToInt16(Strings.Mid(rs.Fields("Company_PosString").Value, 5, 2));

						if ((intDate / 2) == System.Math.Round(intDate / 2)) {
							intDate = intDate / 2;
						} else {
							return functionReturnValue;
						}


						if ((intMonth / 2) == System.Math.Round(intMonth / 2)) {
							intMonth = intMonth / 2;
						} else {
							return functionReturnValue;
						}


						if ((intYear / 2) == System.Math.Round(intYear / 2)) {
							intYear = intYear / 2;
						} else {
							return functionReturnValue;
						}

						stPass = "20";
						if (Strings.Len(Convert.ToString(intYear)) == 1)
							stPass = stPass + "0" + intYear + "/";
						else
							stPass = stPass + intYear + "/";
						if (Strings.Len(Convert.ToString(intMonth)) == 1)
							stPass = stPass + "0" + intMonth + "/";
						else
							stPass = stPass + intMonth + "/";
						if (Strings.Len(Convert.ToString(intDate)) == 1)
							stPass = stPass + "0" + intDate;
						else
							stPass = stPass + intDate;

						if (Information.IsDate(stPass)) {
							if (Convert.ToDateTime(stPass) >= DateAndTime.Today) {
								functionReturnValue = true;
								return functionReturnValue;
							}
						}

						//If Left(rs("Company_PosString"), 2) >= Year(Date) And Mid(rs("Company_PosString"), 3, 2) >= Month(Date) And Mid(rs("Company_PosString"), 5) >= Day(Date) Then
						//    bolSecurityCode = True
						//    Exit Function
						//Else
						//    Exit Function
						//End If

					} else {
						return functionReturnValue;
					}

				}
			} else {
				Interaction.MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS");
				System.Environment.Exit(0);
			}
			return functionReturnValue;
			Hell_Error:

			Interaction.MsgBox(Err().Number + " - " + Err().Description, MsgBoxStyle.Exclamation);
			return functionReturnValue;
			return functionReturnValue;
		}

		private bool checkSecurity()
		{
			bool functionReturnValue = false;
			string lCode = null;
			string leCode = null;
			string lPassword = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			short x = 0;
			functionReturnValue = false;
			if (modRecordSet.openConnection()) {
				rs = modRecordSet.getRS(ref "SELECT * From Company");
				if (rs.RecordCount) {
					if (Information.IsNumeric(rs.Fields("Company_Code").Value)) {
						modApplication.gSecKey = rs.Fields("Company_Code").Value;
						if (Strings.Len(rs.Fields("Company_Code").Value) == 13) {

							functionReturnValue = true;
							return functionReturnValue;
						}
					}
					lPassword = "pospospospos";
					lCode = getSerialNumber();
					if (lCode == "0" & Strings.LCase(Strings.Left(modRecordSet.serverPath, 3)) != "c:\\" & !string.IsNullOrEmpty(rs.Fields("Company_Code").Value)) {
						functionReturnValue = true;
					} else {
						leCode = Encrypt(lCode, lPassword);
						for (x = 1; x <= Strings.Len(leCode); x++) {
							if (Strings.Asc(Strings.Mid(leCode, x, 1)) < 33) {
								leCode = Strings.Left(leCode, x - 1) + Strings.Chr(33) + Strings.Mid(leCode, x + 1);
							}
						}

						if (rs.Fields("Company_Code").Value == leCode) {
							//If IsNull(rs("Company_TerminateDate")) Then
							functionReturnValue = true;
							return functionReturnValue;
							//Else
							//    If Date > rs("Company_TerminateDate") Then
							//        cnnDB.Execute "UPDATE Company SET Company.Company_Code = '';"
							//        checkSecurity = False
							//   End If
							//End If
						} else {
							//txtCompany.Text = rs("Company_Name")
							//txtCompany.SelStart = 0
							//txtCompany.SelLength = 999
							//show 1
						}

					}
				} else {
					Interaction.MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS");
					System.Environment.Exit(0);
				}
			} else {
				Interaction.MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS");
				System.Environment.Exit(0);
			}
			return functionReturnValue;
		}

		private void loadAirtimeCSV(ref string csvBarcode, ref string csvPRG, ref string csvDESC, ref decimal csvSell, ref decimal csvCost, ref string csvSTG_RPG, ref string csvVAT)
		{
			string sql = null;


			System.Windows.Forms.Application.DoEvents();
			gStockItem = 0;
			gBrandItem = 0;

			ADODB.Recordset rsSupp = default(ADODB.Recordset);
			ADODB.Recordset rsDep = default(ADODB.Recordset);
			ADODB.Recordset rsPriceG = default(ADODB.Recordset);
			ADODB.Recordset rsStockG = default(ADODB.Recordset);
			ADODB.Recordset rsReportG = default(ADODB.Recordset);
			ADODB.Recordset rs = default(ADODB.Recordset);
			decimal aCost = default(decimal);

			//Set rs = getRS("SELECT StockItemID FROM StockItem WHERE StockItem_Name = '" & Replace(ManuName(ManufactureId) & " - " & Description, "'", "''") & "'")
			//If rs.RecordCount > 0 Then
			//Else
			rsDep = modRecordSet.getRS(ref "SELECT DepositID AS DepositIDs FROM Deposit WHERE Deposit_Name = 'Non' OR Deposit_Name = 'No Deposit' OR Deposit_Name = 'NON'");
			if (rsDep.RecordCount > 0) {
			} else {
				//rsDep.Close
				//Set rsDep = Nothing
				rsDep = modRecordSet.getRS(ref "SELECT MIN(DepositID) AS DepositIDs  FROM Deposit;");
				if (rsDep.RecordCount > 0) {

				}
				//MsgBox "Setup Deposit with 'Non' Title"
				//Exit Sub
				//cnnDB.Execute "INSERT INTO PricingGroup ( PricingGroup_Name, PricingGroup_Code, PricingGroup_RemoveCents, PricingGroup_RoundAfter, PricingGroup_RoundDown, PricingGroup_Unit1, PricingGroup_Case1, PricingGroup_Unit2, PricingGroup_Case2, PricingGroup_Unit3, PricingGroup_Case3, PricingGroup_Unit4, PricingGroup_Case4, PricingGroup_Unit5, PricingGroup_Case5, PricingGroup_Unit6, PricingGroup_Case6, PricingGroup_Unit7, PricingGroup_Case7, PricingGroup_Unit8, PricingGroup_Case8 ) VALUES ('AirTime_CES', '0', 1, 39, 19.99, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20)"
				//Set rsDep = getRS("SELECT MAX(DepositID) FROM Deposit")
			}

			rsPriceG = modRecordSet.getRS(ref "SELECT PricingGroupID FROM PricingGroup WHERE PricingGroup_Name = '" + csvPRG + "'");
			if (rsPriceG.RecordCount > 0) {
			} else {
				rsPriceG.Close();
				rsPriceG = null;

				modRecordSet.cnnDB.Execute("INSERT INTO PricingGroup ( PricingGroup_Name, PricingGroup_Code, PricingGroup_RemoveCents, PricingGroup_RoundAfter, PricingGroup_RoundDown, PricingGroup_Unit1, PricingGroup_Case1, PricingGroup_Unit2, PricingGroup_Case2, PricingGroup_Unit3, PricingGroup_Case3, PricingGroup_Unit4, PricingGroup_Case4, PricingGroup_Unit5, PricingGroup_Case5, PricingGroup_Unit6, PricingGroup_Case6, PricingGroup_Unit7, PricingGroup_Case7, PricingGroup_Unit8, PricingGroup_Case8 ) VALUES ('" + csvPRG + "', '0', 1, 39, 19.99, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20)");
				rsPriceG = modRecordSet.getRS(ref "SELECT MAX(PricingGroupID) FROM PricingGroup");
			}

			rsStockG = modRecordSet.getRS(ref "SELECT StockGroupID FROM StockGroup WHERE StockGroup_Name = '" + csvSTG_RPG + "'");
			if (rsStockG.RecordCount > 0) {
			} else {
				rsStockG.Close();
				rsStockG = null;

				modRecordSet.cnnDB.Execute("INSERT INTO StockGroup ( StockGroup_Name, StockGroup_Disabled ) VALUES ('" + csvSTG_RPG + "',0)");
				rsStockG = modRecordSet.getRS(ref "SELECT MAX(StockGroupID) FROM StockGroup");
			}

			rsReportG = modRecordSet.getRS(ref "SELECT ReportID FROM ReportGroup WHERE ReportGroup_Name = '" + csvSTG_RPG + "'");
			if (rsReportG.RecordCount > 0) {
			} else {
				rsReportG.Close();
				rsReportG = null;

				modRecordSet.cnnDB.Execute("INSERT INTO ReportGroup ( ReportGroup_Name ) VALUES ('" + csvSTG_RPG + "')");
				rsReportG = modRecordSet.getRS(ref "SELECT MAX(ReportID) FROM ReportGroup");
			}

			//aCost = (RetailPrice / 1.04)
			//aCost = (aCost / 1.14)
			aCost = csvCost;
			sql = "INSERT INTO StockItem (StockItem_BrandItemID, StockItem_SupplierID, StockItem_ShrinkID, StockItem_PackSizeID, StockItem_PricingGroupID, StockItem_StockGroupID, StockItem_VatID, StockItem_DepositID, StockItem_Name, StockItem_ReceiptName, StockItem_Quantity, StockItem_ListCost, StockItem_ActualCost, StockItem_MinimumStock, StockItem_MaximumStock, StockItem_OrderQuantity, StockItem_OrderRounding, StockItem_OrderDynamic, StockItem_Disabled, StockItem_Discontinued, StockItem_QuickKey, StockItem_NegSale, StockItem_PrintLocationID, StockItem_SerialTracker, StockItem_ReportID, StockItem_ATItem, StockItem_ATStockTypeID) VALUES (";
			sql = sql + gBrandItem + ", " + 2 + ", " + 1 + ", " + 1 + ", " + rsPriceG.Fields(0).Value + ", " + rsStockG.Fields(0).Value + ", 2, " + rsDep.Fields(0).Value + ", '" + csvDESC + "', '" + csvDESC + "', " + Strings.Replace(Convert.ToString(1), ",", "") + ", " + Strings.Replace(Convert.ToString(aCost), ",", "") + ", " + Strings.Replace(Convert.ToString(aCost), ",", "") + ", 0, 0, " + Convert.ToDecimal(1) + ", 1, 0, 0, 0, '" + csvBarcode + "', True, 1, True, " + rsReportG.Fields(0).Value + ", True, 0)";
			Debug.Print(sql);
			modRecordSet.cnnDB.Execute(sql);

			sql = "SELECT Max(StockItem.StockItemID) AS id FROM StockItem;";
			rs = modRecordSet.getRS(ref sql);
			gStockItem = rs.Fields("id").Value;
			modRecordSet.cnnDB.Execute("UPDATE StockItem, Company SET StockItem.StockItem_LastCost = [Company_DayEndID] WHERE (((StockItem.StockItemID)=" + gStockItem + "));");

			modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN BrandItemSupplier ON (StockItem.StockItem_SupplierID = BrandItemSupplier.BrandItemSupplier_SupplierID) AND (StockItem.StockItem_BrandItemID = BrandItemSupplier.BrandItemSupplier_BrandItemID) SET StockItem.StockItem_SupplierCode = [BrandItemSupplier]![BrandItemSupplier_Code] WHERE (((StockItem.StockItemID)=" + gStockItem + "));");

			//Multi Warehouse change     cnnDB.Execute "INSERT INTO DayEndStockItemLnk ( DayEndStockItemLnk_DayEndID, DayEndStockItemLnk_StockItemID, DayEndStockItemLnk_Quantity, DayEndStockItemLnk_QuantitySales, DayEndStockItemLnk_QuantityShrink, DayEndStockItemLnk_QuantityGRV, DayEndStockItemLnk_ListCost, DayEndStockItemLnk_ActualCost ) SELECT Company.Company_DayEndID, " & gStockItem & " AS stock, 0, 0, 0, 0, " & CCur(txtCost.Text) / CCur(txtQuantity.Text) & ", " & CCur(txtCost.Text) / CCur(txtQuantity.Text) & " FROM Company;"
			modRecordSet.cnnDB.Execute("INSERT INTO DayEndStockItemLnk ( DayEndStockItemLnk_DayEndID, DayEndStockItemLnk_StockItemID, DayEndStockItemLnk_Quantity, DayEndStockItemLnk_QuantitySales, DayEndStockItemLnk_QuantityShrink, DayEndStockItemLnk_QuantityGRV, DayEndStockItemLnk_ListCost, DayEndStockItemLnk_ActualCost, DayEndStockItemLnk_Warehouse ) SELECT Company.Company_DayEndID, " + gStockItem + " AS stock, 0, 0, 0, 0, " + csvCost + ", " + csvCost + ", Warehouse.WarehouseID FROM Company, Warehouse;");
			modRecordSet.cnnDB.Execute("INSERT INTO WarehouseStockItemLnk ( WarehouseStockItemLnk_WarehouseID, WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk_Quantity ) SELECT Warehouse.WarehouseID, " + gStockItem + ", 0 FROM Warehouse;");

			modRecordSet.cnnDB.Execute("INSERT INTO tempStockItem ( tempStockItemID ) SELECT StockItem.StockItemID FROM tempStockItem RIGHT JOIN StockItem ON tempStockItem.tempStockItemID = StockItem.StockItemID WHERE (((tempStockItem.tempStockItemID) Is Null) AND ((StockItem.StockItemID)=" + gStockItem + "));");

			modRecordSet.cnnDB.Execute("DELETE FROM systemStockItemPricing;");
			modRecordSet.cnnDB.Execute("INSERT INTO systemStockItemPricing ( systemStockItemPricing ) VALUES (" + gStockItem + ")");

			modRecordSet.cnnDB.Execute("INSERT INTO Catalogue (Catalogue_StockItemID,Catalogue_Quantity,Catalogue_Barcode) VALUES (" + gStockItem + ",1,'" + modApplication.buildItemBarcode(ref gStockItem, ref 1) + "')");

			//buildBarcodes gStockItem
			//If gBrandItem Then
			//   cnnDB.Execute "UPDATE (StockItem INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN BrandItemQuantity ON (BrandItemQuantity.BrandItemQuantity_Quantity = Catalogue.Catalogue_Quantity) AND (StockItem.StockItem_BrandItemID = BrandItemQuantity.BrandItemQuantity_BrandItemID) SET Catalogue.Catalogue_Barcode = [BrandItemQuantity]![BrandItemQuantity_Barcode] WHERE (((StockItem.StockItemID)=" & gStockItem & "));"
			//End If

			//cnnDB.Execute "UPDATE Catalogue Set Catalogue_Barcode = '" & sBarCode & "' WHERE Catalogue_Quantity = " & 1 & " AND Catalogue_StockItemID =" & rs.Fields(0) & ";"
			//Set rt = getRS("SELECT * FROM PriceChannelLnk WHERE PriceChannelLnk_StockItemID = " & rs.Fields(0) & " AND PriceChannelLnk_Quantity = " & 1 & ";")
			//If rt.RecordCount Then
			//Else
			modRecordSet.cnnDB.Execute("INSERT INTO PriceChannelLnk ( PriceChannelLnk_StockItemID, PriceChannelLnk_Quantity, PriceChannelLnk_ChannelID, PriceChannelLnk_Price ) VALUES (" + gStockItem + "," + 1 + ",1," + csvSell + ")");
			modRecordSet.cnnDB.Execute("UPDATE PriceChannelLnk SET PriceChannelLnk_Price=" + csvSell + " WHERE PriceChannelLnk_StockItemID = " + gStockItem + ";");
			//End If
			newATItem = true;
			//gStockItem = 0
			//gBrandItem = 0
			//loadProducts
			//End If
			frmUpdateCatalogue form = null;
			form.Show();
		}

		private void CreateAirtimeBC(ref string csvATFile)
		{
			string strSvrName = null;
			ADODB.Recordset ATrs = new ADODB.Recordset();
			string[] csvSplit = null;
			string csvLine = null;
			int csvRows = 0;
			ADODB.Recordset rsCat = default(ADODB.Recordset);

			string vValue = null;
			int hkey = 0;
			int lRetVal = 0;
			if (checkSecurity() == true) {
				//for Security Code
				if (bolSecurityCode() == true) {
					//loadCustom
					FileSystem.FileOpen(8, csvATFile, OpenMode.Input);
					csvRows = 0;
					while (!(FileSystem.EOF(8))) {
						csvLine = FileSystem.LineInput(8);
						if (Strings.Len(csvLine) > 0) {
							if (Strings.Left(csvLine, 3) == "PLU") {
							} else {
								csvSplit = Strings.Split(csvLine, ",");
								rsCat = modRecordSet.getRS(ref "Select * from Catalogue where Catalogue_Barcode = '" + Strings.Left(csvSplit[0], 5) + "'");
								if (rsCat.RecordCount == 0) {
									//FROM QUICK KEY
									rsCat = modRecordSet.getRS(ref "SELECT StockItem.StockItemID From StockItem WHERE ((StockItem.StockItem_QuickKey)='" + Strings.Left(csvSplit[0], 5) + "');");
									if (rsCat.RecordCount == 0) {
										loadAirtimeCSV(ref csvSplit[0], ref csvSplit[1], ref csvSplit[2], ref Convert.ToDecimal(csvSplit[3]), ref Convert.ToDecimal(csvSplit[4]), ref csvSplit[6], ref csvSplit[7]);
										if (gStockItem != 0) {
											modRecordSet.cnnDB.Execute("UPDATE PriceChannelLnk SET PriceChannelLnk_Price=" + Convert.ToDecimal(csvSplit[3]) + " WHERE PriceChannelLnk_StockItemID = " + gStockItem + ";");
											//MsgBox gStockItem & " " & CCur(csvSplit(3))
										}
									}
								}
							}
						}
						csvRows = csvRows + 1;
					}
					FileSystem.FileClose(8);

				} else {
					Interaction.MsgBox("New Stock Items cannot be added due to Security Restrictions." + Constants.vbCrLf + "Please contact your 4POS representative or www.4pos.co.za.", MsgBoxStyle.Critical, "4POS Expired");
					return;
				}
				//for Security Code
			} else {
				rs = modRecordSet.getRS(ref "SELECT * From Company");
				if (rs.RecordCount) {
					//check advance date expiry system
					 // ERROR: Not supported in C#: OnErrorStatement

					vValue = "";
					lRetVal = modUtilities.RegOpenKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\Microsoft\\Windows\\CurrentVersion\\ShellDls", 0, modUtilities.KEY_QUERY_VALUE, ref hkey);
					lRetVal = modUtilities.QueryValueEx(hkey, "ShellClass", ref vValue);
					modUtilities.RegCloseKey(hkey);
					if (string.IsNullOrEmpty(vValue)) {
						vValue = "0";
					} else {
						if (vValue != "0")
							vValue = Convert.ToString(Convert.ToDateTime("&H" + vValue));
					}

					//If IsNull(rs("Company_TerminateDate")) Then
					//    cnnDB.Execute "UPDATE Company SET Company_TerminateDate = #" & Date & "#;"
					//    Set rs = getRS("SELECT * From Company")
					//End If
					if (Information.IsDBNull(rs.Fields("Company_TerminateDate").Value) & vValue == "0") {
						modRecordSet.cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" + DateAndTime.Today + "#;");
						lRetVal = modUtilities.RegCreateKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\Microsoft\\Windows\\CurrentVersion\\ShellDls\\MSOCache", 0, "soap", 0, modUtilities.KEY_ALL_ACCESS, 0, ref hkey, ref 0);
						lRetVal = modUtilities.RegOpenKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\Microsoft\\Windows\\CurrentVersion\\ShellDls", 0, modUtilities.KEY_ALL_ACCESS, ref hkey);
						modUtilities.SetValueEx(hkey, ref "ShellClass", ref modUtilities.REG_SZ, ref Conversion.Hex(DateAndTime.Today.ToOADate()));
						modUtilities.RegCloseKey(hkey);
						rs = modRecordSet.getRS(ref "SELECT * From Company");
					} else {
						if (Information.IsDBNull(rs.Fields("Company_TerminateDate").Value) & vValue != "0") {
							//db date tempered
							if (posDemo() == true) {
								modRecordSet.cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" + DateAndTime.Today + "#;");
								lRetVal = modUtilities.RegCreateKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\Microsoft\\Windows\\CurrentVersion\\ShellDls\\MSOCache", 0, "soap", 0, modUtilities.KEY_ALL_ACCESS, 0, ref hkey, ref 0);
								lRetVal = modUtilities.RegOpenKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\Microsoft\\Windows\\CurrentVersion\\ShellDls", 0, modUtilities.KEY_ALL_ACCESS, ref hkey);
								modUtilities.SetValueEx(hkey, ref "ShellClass", ref modUtilities.REG_SZ, ref Conversion.Hex(DateAndTime.Today.ToOADate()));
								modUtilities.RegCloseKey(hkey);
							} else {
								modRecordSet.cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" + (System.Date.FromOADate(DateAndTime.Today.ToOADate() - 20)) + "#;");
								Interaction.MsgBox("Invalid License found." + Constants.vbCrLf + "application will now exit", MsgBoxStyle.Critical, "Run Time Error");
								System.Environment.Exit(0);
							}
						}

						if (Information.IsDBNull(rs.Fields("Company_TerminateDate").Value)) {
						} else {
							if (rs.Fields("Company_TerminateDate").Value > DateAndTime.Today) {
								//db date tempered
								modRecordSet.cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" + (System.Date.FromOADate(DateAndTime.Today.ToOADate() - 20)) + "#;");
								Interaction.MsgBox("Invalid License found." + Constants.vbCrLf + "application will now exit", MsgBoxStyle.Critical, "Run Time Error");
								System.Environment.Exit(0);
							}
						}

						//If (Date + 2) > rs("Company_TerminateDate") Then
						//    cnnDB.Execute "UPDATE Company SET Company.Company_Code = '';"
						//    checkSecurity = False
						//   Exit Function
						//End If
					}

					if (DateAndTime.Today >= Convert.ToDateTime(rs.Fields("Company_TerminateDate").Value + 30)) {
						Interaction.MsgBox("New Stock Items may only be added with registered versions of your 4POS system." + Constants.vbCrLf + "Please contact your 4POS representative or www.4pos.co.za.", MsgBoxStyle.Critical, "4POS Expired");
						return;
					} else {
						//loadCustom
						FileSystem.FileOpen(8, csvATFile, OpenMode.Input);
						csvRows = 0;
						while (!(FileSystem.EOF(8))) {
							csvLine = FileSystem.LineInput(8);
							if (Strings.Len(csvLine) > 0) {
								if (Strings.Left(csvLine, 3) == "PLU") {
								} else {
									csvSplit = Strings.Split(csvLine, ",");
									rsCat = modRecordSet.getRS(ref "Select * from Catalogue where Catalogue_Barcode = '" + Strings.Left(csvSplit[0], 5) + "'");
									if (rsCat.RecordCount == 0) {
										//FROM QUICK KEY
										rsCat = modRecordSet.getRS(ref "SELECT StockItem.StockItemID From StockItem WHERE ((StockItem.StockItem_QuickKey)='" + Strings.Left(csvSplit[0], 5) + "');");
										if (rsCat.RecordCount == 0) {
											loadAirtimeCSV(ref csvSplit[0], ref csvSplit[1], ref csvSplit[2], ref Convert.ToDecimal(csvSplit[3]), ref Convert.ToDecimal(csvSplit[4]), ref csvSplit[6], ref csvSplit[7]);
											if (gStockItem != 0) {
												modRecordSet.cnnDB.Execute("UPDATE PriceChannelLnk SET PriceChannelLnk_Price=" + Convert.ToDecimal(csvSplit[3]) + " WHERE PriceChannelLnk_StockItemID = " + gStockItem + ";");
												//MsgBox gStockItem & " " & CCur(csvSplit(3))
											}
										}
									}
								}
							}
							csvRows = csvRows + 1;
						}
						FileSystem.FileClose(8);
					}
					//End If
				}
			}
			//frmUpdateCatalogue.show 1, Me
			Interaction.MsgBox("All Airtime Items activated/updated. Now system will do GRV.");
		}

		private void cmdAirTime_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string sql = null;
			string strIn = null;
			string Pin = null;
			string Serial = null;
			string lString = null;
			string[] lData = null;
			string[] lFields = null;
			Scripting.FileSystemObject FSO = new Scripting.FileSystemObject();
			Scripting.TextStream lTextstream = default(Scripting.TextStream);
			int x = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset RSitem = default(ADODB.Recordset);
			ADODB.Recordset rsCat = default(ADODB.Recordset);
			//Dim lListitem As listItem
			 // ERROR: Not supported in C#: OnErrorStatement


			string[] sSplit = null;
			string sLine = null;
			int lRows = 0;
			int lRowsIN = 0;
			int iPOId = 0;
			int iSuppId = 0;
			ADODB.Recordset rsID = default(ADODB.Recordset);
			ADODB.Recordset rsChk = default(ADODB.Recordset);
			string errPosition = null;

			CDOpen.ShowDialog();
			lString = CDOpen.FileName;
			//lvImport.ListItems.Clear
			if (string.IsNullOrEmpty(lString)) {
				//Unload Me
				return;
			} else {
				modRecordSet.cnnDB.Execute("DELETE * from StockTransferGRV;");
				if (FSO.FileExists(lString)) {

					Frame2.Visible = true;
					cmdAirTime.Enabled = false;

					//Validating serials file
					FileSystem.FileOpen(7, lString, OpenMode.Input);
					lRows = 0;
					lRowsIN = 0;
					while (!(FileSystem.EOF(7))) {
						sLine = FileSystem.LineInput(7);
						if (Strings.Len(sLine) > 0) {
							if (Strings.Left(sLine, 2) == "D|") {

								sSplit = Strings.Split(sLine, "|");
								RSitem = modRecordSet.getRS(ref "Select * from Serialtracking where serial_serialnumber = '" + sSplit[7] + "'");
								if (RSitem.RecordCount) {
									//a = 1
									Debug.Print(Serial);
									Debug.Print(Pin);
								} else {
									validateAgain:
									rsCat = modRecordSet.getRS(ref "Select * from Catalogue where Catalogue_Barcode = '" + Strings.Left(sSplit[1], 5) + "'");
									if (rsCat.RecordCount == 0) {
										//MsgBox "Barcode not found for '" & Left(sSplit(1), 5) & "'"
										//FROM QUICK KEY
										rsCat = modRecordSet.getRS(ref "SELECT StockItem.StockItemID From StockItem WHERE ((StockItem.StockItem_QuickKey)='" + Strings.Left(sSplit[1], 5) + "');");
										//SELECT StockItem.StockItemID From StockItem WHERE (((StockItem.StockItem_QuickKey)="C0005"));
										if (rsCat.RecordCount == 0) {
											Interaction.MsgBox("Barcode or Quick key not found for '" + Strings.Left(sSplit[1], 5) + "'. Process will now Create/Update airtime item(s).");
											//Fire external utility
											if (FSO.FileExists("c:\\4POSServer\\4AIRItems.csv")) {
												newATItem = false;
												CreateAirtimeBC(ref "c:\\4POSServer\\4AIRItems.csv");
												if (newATItem == true) {
													goto validateAgain;
												} else {
													Interaction.MsgBox("Could not Create Airtime item. Process will stop now. Please make sure you have latest Airtime CSV file in place.");
													return;
												}
											} else {
												Interaction.MsgBox("Could not find file '" + modRecordSet.serverPath + "4AIRItems.csv'. Process will stop now. Please make sure you have latest Airtime CSV file in place.");
												return;
											}
										} else {
											//cnnDB.Execute "INSERT INTO Serialtracking(Serial_Stockitemid,serial_serialnumber,serial_suppliername,serial_datepurchases,Serial_Status,Serial_PIN,Serial_Expires) Values('" & rsCat("StockItemID") & "','" & sSplit(7) & "','4AIR',#" & Format(Now, "yyyy/mm/dd") & "#,'GRV_START','" & sSplit(8) & "','" & sSplit(5) & "')"
											//Set rs = getRS("SELECT * FROM StockTransferGRV WHERE StockTransfer_StockItemID = " & rsCat("StockItemID") & ";")
											//If rs.RecordCount > 0 Then
											//    strIn = "UPDATE StockTransferGRV SET StockTransfer_Quantity = " & rs("StockTransfer_Quantity") + 1 & " WHERE StockTransfer_StockItemID = " & rsCat("StockItemID") & ";"
											//Else
											//    strIn = "INSERT INTO StockTransferGRV (StockTransfer_StockItemID,StockTransfer_Quantity,StockTransfer_Price,StockTransfer_Pack) VALUES " & _
											//'            "(" & rsCat("StockItemID") & ", 1, 1, 1)"
											//End If
											//DoEvents
											//cnnDB.Execute strIn
											//Debug.Print strIn
											//DoEvents
											//lRows = lRows + 1
										}
									} else {

										//FROM BARCODE
										//cnnDB.Execute "INSERT INTO Serialtracking(Serial_Stockitemid,serial_serialnumber,serial_suppliername,serial_datepurchases,Serial_Status,Serial_PIN,Serial_Expires) Values('" & rsCat("catalogue_StockItemID") & "','" & sSplit(7) & "','4AIR',#" & Format(Now, "yyyy/mm/dd") & "#,'GRV_START','" & sSplit(8) & "','" & sSplit(5) & "')"
										//Set rs = getRS("SELECT * FROM StockTransferGRV WHERE StockTransfer_StockItemID = " & rsCat("catalogue_StockItemID") & ";")
										//If rs.RecordCount > 0 Then
										//    strIn = "UPDATE StockTransferGRV SET StockTransfer_Quantity = " & rs("StockTransfer_Quantity") + 1 & " WHERE StockTransfer_StockItemID = " & rsCat("catalogue_StockItemID") & ";"
										//Else
										//    strIn = "INSERT INTO StockTransferGRV (StockTransfer_StockItemID,StockTransfer_Quantity,StockTransfer_Price,StockTransfer_Pack) VALUES " & _
										//'            "(" & rsCat("catalogue_StockItemID") & ", 1, 1, 1)"
										//End If
										//DoEvents
										//cnnDB.Execute strIn
										//Debug.Print strIn
										//DoEvents
										//lRows = lRows + 1
									}
								}
								lRowsIN = lRowsIN + 1;
							}
						}
					}
					FileSystem.FileClose(7);


					prgBar.Maximum = lRowsIN;
					prgBar.Value = 0;

					//Importing serials file
					FileSystem.FileOpen(7, lString, OpenMode.Input);
					lRows = 0;
					lRowsIN = 0;
					while (!(FileSystem.EOF(7))) {
						sLine = FileSystem.LineInput(7);
						if (Strings.Len(sLine) > 0) {
							if (Strings.Left(sLine, 2) == "D|") {

								if (prgBar.Value == prgBar.Maximum) {
									System.Windows.Forms.Application.DoEvents();
									prgBar.Value = 0;
								} else {
									prgBar.Value = prgBar.Value + 1;
									System.Windows.Forms.Application.DoEvents();
								}

								sSplit = Strings.Split(sLine, "|");
								RSitem = modRecordSet.getRS(ref "Select * from Serialtracking where serial_serialnumber = '" + sSplit[7] + "'");
								if (RSitem.RecordCount) {
									//a = 1
									Debug.Print(sSplit[7]);
									Debug.Print(sSplit[8]);
								} else {
									rsCat = modRecordSet.getRS(ref "Select * from Catalogue where Catalogue_Barcode = '" + Strings.Left(sSplit[1], 5) + "'");
									if (rsCat.RecordCount == 0) {
										//MsgBox "Barcode not found for '" & Left(sSplit(1), 5) & "'"
										//FROM QUICK KEY
										rsCat = modRecordSet.getRS(ref "SELECT StockItem.StockItemID From StockItem WHERE ((StockItem.StockItem_QuickKey)='" + Strings.Left(sSplit[1], 5) + "');");
										//SELECT StockItem.StockItemID From StockItem WHERE (((StockItem.StockItem_QuickKey)="C0005"));
										if (rsCat.RecordCount == 0) {
											Interaction.MsgBox("Barcode or Quick key not found for '" + Strings.Left(sSplit[1], 5) + "'");
										} else {

											modRecordSet.cnnDB.Execute("UPDATE StockItem SET StockItem.StockItem_NegSale=True, StockItem.StockItem_SerialTracker=True, StockItem.StockItem_ATItem=True WHERE (((StockItem.StockItemID)=" + rsCat.Fields("StockItemID").Value + "));");
											modRecordSet.cnnDB.Execute("INSERT INTO Serialtracking(Serial_Stockitemid,serial_serialnumber,serial_suppliername,serial_datepurchases,Serial_Status,Serial_PIN,Serial_Expires) Values('" + rsCat.Fields("StockItemID").Value + "','" + sSplit[7] + "','4AIR',#" + Strings.Format(DateAndTime.Now, "yyyy/mm/dd") + "#,'GRV_START','" + sSplit[8] + "','" + sSplit[5] + "')");
											if (string.IsNullOrEmpty(sSplit[2])) {
												sSplit[2] = Convert.ToString(1);
											} else {
												sSplit[2] = Convert.ToString(Convert.ToDouble(sSplit[2]) / 1.14);
											}
											rs = modRecordSet.getRS(ref "SELECT * FROM StockTransferGRV WHERE StockTransfer_StockItemID = " + rsCat.Fields("StockItemID").Value + ";");
											if (rs.RecordCount > 0) {
												strIn = "UPDATE StockTransferGRV SET StockTransfer_Quantity = " + rs.Fields("StockTransfer_Quantity").Value + 1 + " WHERE StockTransfer_StockItemID = " + rsCat.Fields("StockItemID").Value + ";";
											} else {
												strIn = "INSERT INTO StockTransferGRV (StockTransfer_StockItemID,StockTransfer_Quantity,StockTransfer_Price,StockTransfer_Pack) VALUES " + "(" + rsCat.Fields("StockItemID").Value + ", 1, " + (string.IsNullOrEmpty(sSplit[2]) ? 1 : sSplit[2]) + ", 1)";
												// "(" & rsCat("StockItemID") & ", 1, 1, 1)"
											}
											System.Windows.Forms.Application.DoEvents();
											modRecordSet.cnnDB.Execute(strIn);
											Debug.Print(strIn);
											System.Windows.Forms.Application.DoEvents();
											lRows = lRows + 1;
										}
									} else {

										//FROM BARCODE
										modRecordSet.cnnDB.Execute("UPDATE StockItem SET StockItem.StockItem_NegSale=True, StockItem.StockItem_SerialTracker=True, StockItem.StockItem_ATItem=True WHERE (((StockItem.StockItemID)=" + rsCat.Fields("catalogue_StockItemID").Value + "));");
										modRecordSet.cnnDB.Execute("INSERT INTO Serialtracking(Serial_Stockitemid,serial_serialnumber,serial_suppliername,serial_datepurchases,Serial_Status,Serial_PIN,Serial_Expires) Values('" + rsCat.Fields("catalogue_StockItemID").Value + "','" + sSplit[7] + "','4AIR',#" + Strings.Format(DateAndTime.Now, "yyyy/mm/dd") + "#,'GRV_START','" + sSplit[8] + "','" + sSplit[5] + "')");
										if (string.IsNullOrEmpty(sSplit[2])) {
											sSplit[2] = Convert.ToString(1);
										} else {
											sSplit[2] = Convert.ToString(Convert.ToDouble(sSplit[2]) / 1.14);
										}
										rs = modRecordSet.getRS(ref "SELECT * FROM StockTransferGRV WHERE StockTransfer_StockItemID = " + rsCat.Fields("catalogue_StockItemID").Value + ";");
										if (rs.RecordCount > 0) {
											strIn = "UPDATE StockTransferGRV SET StockTransfer_Quantity = " + rs.Fields("StockTransfer_Quantity").Value + 1 + " WHERE StockTransfer_StockItemID = " + rsCat.Fields("catalogue_StockItemID").Value + ";";
										} else {
											strIn = "INSERT INTO StockTransferGRV (StockTransfer_StockItemID,StockTransfer_Quantity,StockTransfer_Price,StockTransfer_Pack) VALUES " + "(" + rsCat.Fields("catalogue_StockItemID").Value + ", 1, " + (string.IsNullOrEmpty(sSplit[2]) ? 1 : sSplit[2]) + ", 1)";
											//"(" & rsCat("catalogue_StockItemID") & ", 1, 1, 1)"
										}
										System.Windows.Forms.Application.DoEvents();
										modRecordSet.cnnDB.Execute(strIn);
										Debug.Print(strIn);
										System.Windows.Forms.Application.DoEvents();
										lRows = lRows + 1;
									}
								}
								lRowsIN = lRowsIN + 1;
							}
						}
					}
					FileSystem.FileClose(7);

					errPosition = "Start";
					//Create GRV
					rs = modRecordSet.getRS(ref "SELECT * FROM StockTransferGRV;");
					if (rs.RecordCount > 0) {
						if (lRowsIN != lRows) {
							Interaction.MsgBox("Total serials imported " + lRows + " out of " + lRowsIN + " in file");
						}

						iSuppId = 2;
						rsID = modRecordSet.getRS(ref "SELECT SupplierID FROM Supplier WHERE Supplier_Name = '4AIR';");
						if (rsID.RecordCount) {
							iSuppId = rsID.Fields("SupplierID").Value;
						}

						sql = "INSERT INTO PurchaseOrder ( PurchaseOrder_SupplierID, PurchaseOrder_DayEndID, PurchaseOrder_PersonID, PurchaseOrder_DateCreated, PurchaseOrder_PurchaseOrderStatusID, PurchaseOrder_Reference, PurchaseOrder_AttentionLine ) ";
						sql = sql + "SELECT " + iSuppId + ", Company.Company_DayEndID, " + My.MyProject.Forms.frmMenu.lblUser.Tag + ", Now(), 1, '" + Strings.Format(DateAndTime.Now, "yyyy mmm dd") + " (Blind)', '' FROM Company;";
						modRecordSet.cnnDB.Execute(sql, , ADODB.ExecuteOptionEnum.adExecuteNoRecords);

						errPosition = "2";
						rsID = modRecordSet.getRS(ref "SELECT Max(PurchaseOrder.PurchaseOrderID) AS id FROM PurchaseOrder;");
						iPOId = rsID.Fields("id").Value;
						sql = "INSERT INTO GRV ( GRV_PurchaseOrderID, GRV_DayEndID, GRV_GRVStatusID, GRV_Date, GRV_InvoiceDate, GRV_InvoiceNumber, GRV_InvoiceInclusive, GRV_InvoiceVat, GRV_InvoiceDiscount, GRV_Ullage, GRV_SundriesPlus, GRV_SundriesMinus, GRV_Terms ) SELECT " + rsID.Fields("id").Value + ", Company.Company_DayEndID, 1 AS status, Now(), Now(), '', 0, 0, 0, 0, 0, 0, 1 FROM Company;";
						modRecordSet.cnnDB.Execute(sql, , ADODB.ExecuteOptionEnum.adExecuteNoRecords);
						if (rsID.State)
							rsID.Close();
						rsID = modRecordSet.getRS(ref "SELECT Max(GRV.GRVID) AS id FROM GRV;");

						x = 1;
						rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, StockTransferGRV.* FROM StockTransferGRV INNER JOIN StockItem ON StockTransferGRV.StockTransfer_StockItemID = StockItem.StockItemID ORDER BY StockItem.StockItem_Name, StockTransferGRV.StockTransfer_Quantity;");
						while (!(rs.EOF)) {
							errPosition = "3";
							rsChk = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + rs.Fields("StockTransfer_StockItemID").Value + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));");
							if (rsChk.RecordCount) {

								errPosition = "4";
								//sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID("id") & " AS grvid, StockItem.StockItemID, 1 AS return, StockItem.StockItem_Name, '' AS code, 1, 1, " & rs("StockTransfer_Quantity") & " AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
								//sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID("id") & " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, StockItem.StockItem_Quantity, 1, " & rs("StockTransfer_Quantity") & " AS quantity,     StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
								sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " + x + ", " + rsID.Fields("id").Value + " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, StockItem.StockItem_Quantity, 1, " + rs.Fields("StockTransfer_Quantity").Value + " AS quantity, " + rs.Fields("StockTransfer_Price").Value + ", 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))";
								sql = sql + " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + rs.Fields("StockTransfer_StockItemID").Value + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));";
								Debug.Print(sql);
								modRecordSet.cnnDB.Execute(sql);
							} else {

								errPosition = "5";
								if (rs.Fields("StockTransfer_Pack").Value == 1) {
									sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " + x + ", " + rsID.Fields("id").Value + " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, 1, 1, " + rs.Fields("StockTransfer_Quantity").Value + " AS quantity, " + rs.Fields("StockTransfer_Price").Value + ", 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))";
									sql = sql + " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + rs.Fields("StockTransfer_StockItemID").Value + ") AND ((Catalogue.Catalogue_Quantity)=1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));";
								} else {
									sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " + x + ", " + rsID.Fields("id").Value + " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, 1, 1, " + rs.Fields("StockTransfer_Quantity").Value + " AS quantity, " + rs.Fields("StockTransfer_Price").Value + ", 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))";
									sql = sql + " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + rs.Fields("StockTransfer_StockItemID").Value + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));";
								}
								Debug.Print(sql);
								modRecordSet.cnnDB.Execute(sql);
							}

							sql = "UPDATE (StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID SET GRVItem.GRVItem_VatRate = [Vat_Amount] WHERE (((GRVItem.GRVItem_GRVID)=" + rsID.Fields("id").Value + ") AND ((GRVItem.GRVItem_StockItemID)=" + rs.Fields("StockTransfer_StockItemID").Value + "));";
							modRecordSet.cnnDB.Execute(sql);

							x = x + 1;
							rs.moveNext();
						}

						doSearch();

						Frame2.Visible = false;

						modApplication.bolAirTimeGRV = true;
						modApplication.strAirTimeFile = lString;
						My.MyProject.Forms.frmGRV.Create(iPOId);
						this.Close();
					} else {
						Interaction.MsgBox("No Airtime serials have been imported, please verify that the file wasn't imported already!");
					}
				}
			}
			return;

			cmdAirTime.Enabled = true;
			loadGRV_Error:
			Interaction.MsgBox(Err().Description);
			//Unload Me
			 // ERROR: Not supported in C#: ResumeStatement

		}

		private void cmdDelete_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			MsgBoxResult grvdelete = default(MsgBoxResult);
			//*
			 // ERROR: Not supported in C#: OnErrorStatement

			string sqlstr = null;
			string sql = null;
			string sqlpur = null;


			//* Delete the selected GRV.

			sqlstr = "DELETE * FROM GRV WHERE GRV.GRVID =" + HoldGrvID;
			sql = "DELETE * FROM GRVItem WHERE GRVItem_GRVID =" + HoldGrvID;
			sqlpur = "DELETE * FROM PurchaseOrder WHERE PurchaseOrderID =" + HoldGrvID;


			grvdelete = Interaction.MsgBox("Are you sure you wish to delete the selected GRV", MsgBoxStyle.YesNoCancel);
			if (grvdelete == MsgBoxResult.Yes) {
				modRecordSet.cnnDB.Execute(sql);
				modRecordSet.cnnDB.Execute(sqlstr);
				modRecordSet.cnnDB.Execute(sqlpur);

				//MsgBox ("GRV Deleted")
				cmdExit_Click(cmdExit, new System.EventArgs());
				doSearch();
				lvImport.Refresh();
				//frmGRVselect.Refresh
				HoldGrvID = "";

				loadLanguage();
				ShowDialog();

			} else if (grvdelete == MsgBoxResult.No) {
			} else if (grvdelete == MsgBoxResult.Cancel) {
			}

			//*
		}

		private void cmdEdit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (this.lvImport.FocusedItem == null) {
			} else {
				My.MyProject.Forms.frmGRV.Create(Convert.ToInt32(Strings.Mid(this.lvImport.FocusedItem.Name, 2)));
				this.Close();
			}
		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdImport_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
			 // ERROR: Not supported in C#: OnErrorStatement

			My.MyProject.Forms.frmGRVimport.ShowDialog();
		}

		private void cmdNew_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
			My.MyProject.Forms.frmGRVblind.ShowDialog();
		}

		private void doSearch()
		{
			string sql = null;
			string lString = null;
			System.Windows.Forms.ListViewItem listItem = null;
			lString = Strings.Trim(txtSearch.Text);
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			if (string.IsNullOrEmpty(lString)) {
			} else {
				lString = " AND (Supplier_Name LIKE '%" + Strings.Replace(lString, " ", "%' AND Supplier_Name LIKE '%") + "%')";
			}

			//    Set grs = getRS("SELECT PurchaseOrder.PurchaseOrderID, [Supplier_Name] & '(' & [PurchaseOrder_Reference] & ')' AS name FROM (PurchaseOrder INNER JOIN Supplier ON PurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN PurchaseOrderStatus ON PurchaseOrder.PurchaseOrder_PurchaseOrderStatusID = PurchaseOrderStatus.PurchaseOrderStatusID Where PurchaseOrderStatus.PurchaseOrderStatus_Complete = 0  AND Supplier_Disabled = 0 " & lstring & " ORDER BY Supplier.Supplier_Name;")
			rs = modRecordSet.getRS(ref "SELECT PurchaseOrder.PurchaseOrderID, Supplier.Supplier_Name, PurchaseOrder.PurchaseOrder_DateCreated, PurchaseOrder.PurchaseOrder_Reference, GRV.GRV_InvoiceNumber, GRV.GRV_InvoiceInclusive FROM ((PurchaseOrder INNER JOIN Supplier ON PurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN PurchaseOrderStatus ON PurchaseOrder.PurchaseOrder_PurchaseOrderStatusID = PurchaseOrderStatus.PurchaseOrderStatusID) LEFT JOIN GRV ON PurchaseOrder.PurchaseOrderID = GRV.GRV_PurchaseOrderID Where PurchaseOrderStatus.PurchaseOrderStatus_Complete = 0 And Supplier.Supplier_Disabled = 0 " + lString + " ORDER BY Supplier.Supplier_Name;");
			 // ERROR: Not supported in C#: OnErrorStatement

			lvImport.Items.Clear();
			while (!(rs.EOF)) {
				listItem = this.lvImport.Items.Add("k" + rs.Fields("PurchaseOrderID").Value, rs.Fields("Supplier_Name").Value, "");
				cmddelete.Enabled = true;
				if (listItem.SubItems.Count > 1) {
					listItem.SubItems[1].Text = Strings.Format(rs.Fields("PurchaseOrder_DateCreated").Value, "yyyy mmm dd");
				} else {
					listItem.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.Format(rs.Fields("PurchaseOrder_DateCreated").Value, "yyyy mmm dd")));
				}
				if (listItem.SubItems.Count > 2) {
					listItem.SubItems[2].Text = rs.Fields("PurchaseOrder_Reference").Value;
				} else {
					listItem.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("PurchaseOrder_Reference").Value));
				}
				if (Information.IsDBNull(rs.Fields("GRV_InvoiceInclusive").Value)) {
				} else {
					if (listItem.SubItems.Count > 3) {
						listItem.SubItems[3].Text = rs.Fields("GRV_InvoiceNumber").Value;
					} else {
						listItem.SubItems.Insert(3, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("GRV_InvoiceNumber").Value));
					}
					if (listItem.SubItems.Count > 4) {
						listItem.SubItems[4].Text = Strings.FormatNumber(rs.Fields("GRV_InvoiceInclusive").Value, 2);
					} else {
						listItem.SubItems.Insert(4, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("GRV_InvoiceInclusive").Value, 2)));
					}
				}
				rs.moveNext();
			}


		}


		private void cmdNewFnV_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modApplication.bolFNVegGRV = true;
			this.Close();
			My.MyProject.Forms.frmGRVblind.ShowDialog();
		}

		private void cmdVoucher_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string sql = null;
			string strIn = null;
			string Pin = null;
			string Serial = null;
			string lString = null;
			string[] lData = null;
			string[] lFields = null;
			Scripting.FileSystemObject FSO = new Scripting.FileSystemObject();
			Scripting.TextStream lTextstream = default(Scripting.TextStream);
			int x = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset RSitem = default(ADODB.Recordset);
			ADODB.Recordset rsCat = default(ADODB.Recordset);
			//Dim lListitem As listItem
			 // ERROR: Not supported in C#: OnErrorStatement


			string[] sSplit = null;
			string sLine = null;
			int lRows = 0;
			int lRowsIN = 0;
			int iPOId = 0;
			int iSuppId = 0;
			ADODB.Recordset rsID = default(ADODB.Recordset);
			ADODB.Recordset rsChk = default(ADODB.Recordset);
			string errPosition = null;

			CDOpen.ShowDialog();
			lString = CDOpen.FileName;
			//lvImport.ListItems.Clear
			if (string.IsNullOrEmpty(lString)) {
				//Unload Me
				return;
			} else {
				modRecordSet.cnnDB.Execute("DELETE * from StockTransferGRV;");
				if (FSO.FileExists(lString)) {

					Frame2.Visible = true;
					cmdAirTime.Enabled = false;

					//Validating serials file
					FileSystem.FileOpen(7, lString, OpenMode.Input);
					lRows = 0;
					lRowsIN = 0;
					while (!(FileSystem.EOF(7))) {
						sLine = FileSystem.LineInput(7);
						if (Strings.Len(sLine) > 0) {
							if (Strings.Left(sLine, 2) == "D|") {

								sSplit = Strings.Split(sLine, "|");
								RSitem = modRecordSet.getRS(ref "Select * from Serialtracking where serial_serialnumber = '" + sSplit[7] + "'");
								if (RSitem.RecordCount) {
									//a = 1
									Debug.Print(Serial);
									Debug.Print(Pin);
								} else {
									validateAgain:
									rsCat = modRecordSet.getRS(ref "Select * from Catalogue where Catalogue_Barcode = '" + Strings.Left(sSplit[1], 5) + "'");
									if (rsCat.RecordCount == 0) {
										//MsgBox "Barcode not found for '" & Left(sSplit(1), 5) & "'"
										//FROM QUICK KEY
										rsCat = modRecordSet.getRS(ref "SELECT StockItem.StockItemID From StockItem WHERE ((StockItem.StockItem_QuickKey)='" + Strings.Left(sSplit[1], 5) + "');");
										//SELECT StockItem.StockItemID From StockItem WHERE (((StockItem.StockItem_QuickKey)="C0005"));
										if (rsCat.RecordCount == 0) {
											Interaction.MsgBox("Barcode or Quick key not found for '" + Strings.Left(sSplit[1], 5) + "'. Process will stop now. Please Configure 4POS Voucher item correctly.");
											//Fire external utility
											//If fso.FileExists("c:\4POSServer\4AIRItems.csv") Then
											//    newATItem = False
											//    CreateAirtimeBC "c:\4POSServer\4AIRItems.csv"
											//    If newATItem = True Then
											//        GoTo validateAgain
											//    Else
											//        MsgBox "Could not Create Airtime item. Process will stop now. Please make sure you have latest Airtime CSV file in place."
											//        Exit Sub
											//    End If
											//Else
											//    MsgBox "Could not find file '" & serverPath & "4AIRItems.csv'. Process will stop now. Please make sure you have latest Airtime CSV file in place."
											return;
											//End If
										} else {
											//cnnDB.Execute "INSERT INTO Serialtracking(Serial_Stockitemid,serial_serialnumber,serial_suppliername,serial_datepurchases,Serial_Status,Serial_PIN,Serial_Expires) Values('" & rsCat("StockItemID") & "','" & sSplit(7) & "','4AIR',#" & Format(Now, "yyyy/mm/dd") & "#,'GRV_START','" & sSplit(8) & "','" & sSplit(5) & "')"
											//Set rs = getRS("SELECT * FROM StockTransferGRV WHERE StockTransfer_StockItemID = " & rsCat("StockItemID") & ";")
											//If rs.RecordCount > 0 Then
											//    strIn = "UPDATE StockTransferGRV SET StockTransfer_Quantity = " & rs("StockTransfer_Quantity") + 1 & " WHERE StockTransfer_StockItemID = " & rsCat("StockItemID") & ";"
											//Else
											//    strIn = "INSERT INTO StockTransferGRV (StockTransfer_StockItemID,StockTransfer_Quantity,StockTransfer_Price,StockTransfer_Pack) VALUES " & _
											//'            "(" & rsCat("StockItemID") & ", 1, 1, 1)"
											//End If
											//DoEvents
											//cnnDB.Execute strIn
											//Debug.Print strIn
											//DoEvents
											//lRows = lRows + 1
										}
									} else {

										//FROM BARCODE
										//cnnDB.Execute "INSERT INTO Serialtracking(Serial_Stockitemid,serial_serialnumber,serial_suppliername,serial_datepurchases,Serial_Status,Serial_PIN,Serial_Expires) Values('" & rsCat("catalogue_StockItemID") & "','" & sSplit(7) & "','4AIR',#" & Format(Now, "yyyy/mm/dd") & "#,'GRV_START','" & sSplit(8) & "','" & sSplit(5) & "')"
										//Set rs = getRS("SELECT * FROM StockTransferGRV WHERE StockTransfer_StockItemID = " & rsCat("catalogue_StockItemID") & ";")
										//If rs.RecordCount > 0 Then
										//    strIn = "UPDATE StockTransferGRV SET StockTransfer_Quantity = " & rs("StockTransfer_Quantity") + 1 & " WHERE StockTransfer_StockItemID = " & rsCat("catalogue_StockItemID") & ";"
										//Else
										//    strIn = "INSERT INTO StockTransferGRV (StockTransfer_StockItemID,StockTransfer_Quantity,StockTransfer_Price,StockTransfer_Pack) VALUES " & _
										//'            "(" & rsCat("catalogue_StockItemID") & ", 1, 1, 1)"
										//End If
										//DoEvents
										//cnnDB.Execute strIn
										//Debug.Print strIn
										//DoEvents
										//lRows = lRows + 1
									}
								}
								lRowsIN = lRowsIN + 1;
							}
						}
					}
					FileSystem.FileClose(7);


					prgBar.Maximum = lRowsIN;
					prgBar.Value = 0;

					//Importing serials file
					FileSystem.FileOpen(7, lString, OpenMode.Input);
					lRows = 0;
					lRowsIN = 0;
					while (!(FileSystem.EOF(7))) {
						sLine = FileSystem.LineInput(7);
						if (Strings.Len(sLine) > 0) {
							if (Strings.Left(sLine, 2) == "D|") {

								if (prgBar.Value == prgBar.Maximum) {
									System.Windows.Forms.Application.DoEvents();
									prgBar.Value = 0;
								} else {
									prgBar.Value = prgBar.Value + 1;
									System.Windows.Forms.Application.DoEvents();
								}

								sSplit = Strings.Split(sLine, "|");
								RSitem = modRecordSet.getRS(ref "Select * from Serialtracking where serial_serialnumber = '" + sSplit[7] + "'");
								if (RSitem.RecordCount) {
									//a = 1
									Debug.Print(sSplit[7]);
									Debug.Print(sSplit[8]);
								} else {
									rsCat = modRecordSet.getRS(ref "Select * from Catalogue where Catalogue_Barcode = '" + Strings.Left(sSplit[1], 5) + "'");
									if (rsCat.RecordCount == 0) {
										//MsgBox "Barcode not found for '" & Left(sSplit(1), 5) & "'"
										//FROM QUICK KEY
										rsCat = modRecordSet.getRS(ref "SELECT StockItem.StockItemID From StockItem WHERE ((StockItem.StockItem_QuickKey)='" + Strings.Left(sSplit[1], 5) + "');");
										//SELECT StockItem.StockItemID From StockItem WHERE (((StockItem.StockItem_QuickKey)="C0005"));
										if (rsCat.RecordCount == 0) {
											Interaction.MsgBox("Barcode or Quick key not found for '" + Strings.Left(sSplit[1], 5) + "'");
										} else {

											modRecordSet.cnnDB.Execute("UPDATE StockItem SET StockItem.StockItem_NegSale=True, StockItem.StockItem_SerialTracker=True, StockItem.StockItem_ATItem=True WHERE (((StockItem.StockItemID)=" + rsCat.Fields("StockItemID").Value + "));");
											modRecordSet.cnnDB.Execute("INSERT INTO Serialtracking(Serial_Stockitemid,serial_serialnumber,serial_suppliername,serial_datepurchases,Serial_Status,Serial_PIN,Serial_Expires) Values('" + rsCat.Fields("StockItemID").Value + "','" + sSplit[7] + "','4AIR',#" + Strings.Format(DateAndTime.Now, "yyyy/mm/dd") + "#,'GRV_START','" + sSplit[8] + "','" + sSplit[5] + "')");
											if (string.IsNullOrEmpty(sSplit[2])) {
												sSplit[2] = Convert.ToString(1);
											} else {
												sSplit[2] = Convert.ToString(Convert.ToDouble(sSplit[2]) / 1.14);
											}
											rs = modRecordSet.getRS(ref "SELECT * FROM StockTransferGRV WHERE StockTransfer_StockItemID = " + rsCat.Fields("StockItemID").Value + ";");
											if (rs.RecordCount > 0) {
												strIn = "UPDATE StockTransferGRV SET StockTransfer_Quantity = " + rs.Fields("StockTransfer_Quantity").Value + 1 + " WHERE StockTransfer_StockItemID = " + rsCat.Fields("StockItemID").Value + ";";
											} else {
												strIn = "INSERT INTO StockTransferGRV (StockTransfer_StockItemID,StockTransfer_Quantity,StockTransfer_Price,StockTransfer_Pack) VALUES " + "(" + rsCat.Fields("StockItemID").Value + ", 1, " + (string.IsNullOrEmpty(sSplit[2]) ? 1 : sSplit[2]) + ", 1)";
												// "(" & rsCat("StockItemID") & ", 1, 1, 1)"
											}
											System.Windows.Forms.Application.DoEvents();
											modRecordSet.cnnDB.Execute(strIn);
											Debug.Print(strIn);
											System.Windows.Forms.Application.DoEvents();
											lRows = lRows + 1;
										}
									} else {

										//FROM BARCODE
										modRecordSet.cnnDB.Execute("UPDATE StockItem SET StockItem.StockItem_NegSale=True, StockItem.StockItem_SerialTracker=True, StockItem.StockItem_ATItem=True WHERE (((StockItem.StockItemID)=" + rsCat.Fields("catalogue_StockItemID").Value + "));");
										modRecordSet.cnnDB.Execute("INSERT INTO Serialtracking(Serial_Stockitemid,serial_serialnumber,serial_suppliername,serial_datepurchases,Serial_Status,Serial_PIN,Serial_Expires) Values('" + rsCat.Fields("catalogue_StockItemID").Value + "','" + sSplit[7] + "','4AIR',#" + Strings.Format(DateAndTime.Now, "yyyy/mm/dd") + "#,'GRV_START','" + sSplit[8] + "','" + sSplit[5] + "')");
										if (string.IsNullOrEmpty(sSplit[2])) {
											sSplit[2] = Convert.ToString(1);
										} else {
											sSplit[2] = Convert.ToString(Convert.ToDouble(sSplit[2]) / 1.14);
										}
										rs = modRecordSet.getRS(ref "SELECT * FROM StockTransferGRV WHERE StockTransfer_StockItemID = " + rsCat.Fields("catalogue_StockItemID").Value + ";");
										if (rs.RecordCount > 0) {
											strIn = "UPDATE StockTransferGRV SET StockTransfer_Quantity = " + rs.Fields("StockTransfer_Quantity").Value + 1 + " WHERE StockTransfer_StockItemID = " + rsCat.Fields("catalogue_StockItemID").Value + ";";
										} else {
											strIn = "INSERT INTO StockTransferGRV (StockTransfer_StockItemID,StockTransfer_Quantity,StockTransfer_Price,StockTransfer_Pack) VALUES " + "(" + rsCat.Fields("catalogue_StockItemID").Value + ", 1, " + (string.IsNullOrEmpty(sSplit[2]) ? 1 : sSplit[2]) + ", 1)";
											//"(" & rsCat("catalogue_StockItemID") & ", 1, 1, 1)"
										}
										System.Windows.Forms.Application.DoEvents();
										modRecordSet.cnnDB.Execute(strIn);
										Debug.Print(strIn);
										System.Windows.Forms.Application.DoEvents();
										lRows = lRows + 1;
									}
								}
								lRowsIN = lRowsIN + 1;
							}
						}
					}
					FileSystem.FileClose(7);

					errPosition = "Start";
					//Create GRV
					rs = modRecordSet.getRS(ref "SELECT * FROM StockTransferGRV;");
					if (rs.RecordCount > 0) {
						if (lRowsIN != lRows) {
							Interaction.MsgBox("Total serials imported " + lRows + " out of " + lRowsIN + " in file");
						}

						iSuppId = 2;
						rsID = modRecordSet.getRS(ref "SELECT SupplierID FROM Supplier WHERE Supplier_Name = '4POS SOFTWARE';");
						if (rsID.RecordCount) {
							iSuppId = rsID.Fields("SupplierID").Value;
						}

						sql = "INSERT INTO PurchaseOrder ( PurchaseOrder_SupplierID, PurchaseOrder_DayEndID, PurchaseOrder_PersonID, PurchaseOrder_DateCreated, PurchaseOrder_PurchaseOrderStatusID, PurchaseOrder_Reference, PurchaseOrder_AttentionLine ) ";
						sql = sql + "SELECT " + iSuppId + ", Company.Company_DayEndID, " + My.MyProject.Forms.frmMenu.lblUser.Tag + ", Now(), 1, '" + Strings.Format(DateAndTime.Now, "yyyy mmm dd") + " (Blind)', '' FROM Company;";
						modRecordSet.cnnDB.Execute(sql, , ADODB.ExecuteOptionEnum.adExecuteNoRecords);

						errPosition = "2";
						rsID = modRecordSet.getRS(ref "SELECT Max(PurchaseOrder.PurchaseOrderID) AS id FROM PurchaseOrder;");
						iPOId = rsID.Fields("id").Value;
						sql = "INSERT INTO GRV ( GRV_PurchaseOrderID, GRV_DayEndID, GRV_GRVStatusID, GRV_Date, GRV_InvoiceDate, GRV_InvoiceNumber, GRV_InvoiceInclusive, GRV_InvoiceVat, GRV_InvoiceDiscount, GRV_Ullage, GRV_SundriesPlus, GRV_SundriesMinus, GRV_Terms ) SELECT " + rsID.Fields("id").Value + ", Company.Company_DayEndID, 1 AS status, Now(), Now(), '', 0, 0, 0, 0, 0, 0, 1 FROM Company;";
						modRecordSet.cnnDB.Execute(sql, , ADODB.ExecuteOptionEnum.adExecuteNoRecords);
						if (rsID.State)
							rsID.Close();
						rsID = modRecordSet.getRS(ref "SELECT Max(GRV.GRVID) AS id FROM GRV;");

						x = 1;
						rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, StockTransferGRV.* FROM StockTransferGRV INNER JOIN StockItem ON StockTransferGRV.StockTransfer_StockItemID = StockItem.StockItemID ORDER BY StockItem.StockItem_Name, StockTransferGRV.StockTransfer_Quantity;");
						while (!(rs.EOF)) {
							errPosition = "3";
							rsChk = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + rs.Fields("StockTransfer_StockItemID").Value + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));");
							if (rsChk.RecordCount) {

								errPosition = "4";
								//sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID("id") & " AS grvid, StockItem.StockItemID, 1 AS return, StockItem.StockItem_Name, '' AS code, 1, 1, " & rs("StockTransfer_Quantity") & " AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
								//sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " & x & ", " & rsID("id") & " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, StockItem.StockItem_Quantity, 1, " & rs("StockTransfer_Quantity") & " AS quantity,     StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))"
								sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " + x + ", " + rsID.Fields("id").Value + " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, StockItem.StockItem_Quantity, 1, " + rs.Fields("StockTransfer_Quantity").Value + " AS quantity, " + rs.Fields("StockTransfer_Price").Value + ", 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))";
								sql = sql + " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + rs.Fields("StockTransfer_StockItemID").Value + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));";
								Debug.Print(sql);
								modRecordSet.cnnDB.Execute(sql);
							} else {

								errPosition = "5";
								if (rs.Fields("StockTransfer_Pack").Value == 1) {
									sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " + x + ", " + rsID.Fields("id").Value + " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, 1, 1, " + rs.Fields("StockTransfer_Quantity").Value + " AS quantity, " + rs.Fields("StockTransfer_Price").Value + ", 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))";
									sql = sql + " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + rs.Fields("StockTransfer_StockItemID").Value + ") AND ((Catalogue.Catalogue_Quantity)=1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));";
								} else {
									sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " + x + ", " + rsID.Fields("id").Value + " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, 1, 1, " + rs.Fields("StockTransfer_Quantity").Value + " AS quantity, " + rs.Fields("StockTransfer_Price").Value + ", 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))";
									sql = sql + " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + rs.Fields("StockTransfer_StockItemID").Value + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));";
								}
								Debug.Print(sql);
								modRecordSet.cnnDB.Execute(sql);
							}

							sql = "UPDATE (StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID SET GRVItem.GRVItem_VatRate = [Vat_Amount] WHERE (((GRVItem.GRVItem_GRVID)=" + rsID.Fields("id").Value + ") AND ((GRVItem.GRVItem_StockItemID)=" + rs.Fields("StockTransfer_StockItemID").Value + "));";
							modRecordSet.cnnDB.Execute(sql);

							x = x + 1;
							rs.moveNext();
						}

						doSearch();

						Frame2.Visible = false;

						modApplication.bolAirTimeGRV = true;
						modApplication.strAirTimeFile = lString;
						My.MyProject.Forms.frmGRV.Create(ref iPOId, ref , ref true);
						this.Close();
					} else {
						Interaction.MsgBox("No Vouchers have been imported, please verify that the file wasn't imported already!");
					}
				}
			}
			return;

			cmdAirTime.Enabled = true;
			loadGRV_Error:
			Interaction.MsgBox(Err().Description);
			//Unload Me
			 // ERROR: Not supported in C#: ResumeStatement

		}

		private void frmGRVselect_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmddelete.Enabled = false;
			modApplication.bolAirTimeGRV = false;
			modApplication.strAirTimeFile = "";

			//4POS Voucher
			ADODB.Recordset rsVoucher = default(ADODB.Recordset);
			rsVoucher = modRecordSet.getRS(ref "SELECT Company_Name FROM Company");
			if (rsVoucher.RecordCount) {
				if (Strings.LCase(rsVoucher.Fields("Company_Name").Value) == "compupos") {
					cmdVoucher.Visible = true;
				}
			}
			//4POS Voucher
		}

		private void frmGRVselect_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			modApplication.bolAirTimeGRV = false;
			modApplication.strAirTimeFile = "";
		}

		private void lvImport_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//*Get the following fields
			 // ERROR: Not supported in C#: OnErrorStatement

			rs = modRecordSet.getRS(ref "SELECT GRV.GRVID,GRV.GRV_InvoiceNumber, GRV.GRV_InvoiceInclusive,GRVItem.GRVItem_GRVID FROM ((GRV INNER JOIN GRVItem ON GRV.GRVID=GRVItem.GRVItem_GRVID))");

			//*Get the GRVID of the select GRV,Remove letter K from It and hold it.
			HoldGrvID = Strings.Split(lvImport.FocusedItem.Name, "_")[0];
			HoldGrvID = Strings.Mid(HoldGrvID, 2);

			//Set rs = getRS("SELECT GRV_InvoiceNumber FROM GRV WHERE GRVID=" & HoldGrvID)
			//HoldGrvNo = rs("GRV_InvoiceNumber")

			//HoldName = lvImport.SelectedItem
		}

		private void lvImport_DoubleClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdEdit_Click(cmdEdit, new System.EventArgs());
		}

		private void lvImport_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			//* Cater for the delete button to delete a GRV in the listbox
			if (KeyCode == 46)
				cmdDelete_Click(cmddelete, new System.EventArgs());
		}

		private void lvImport_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 13)
				cmdEdit_Click(cmdEdit, new System.EventArgs());
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtSearch_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtSearch.SelectionStart = 0;
			txtSearch.SelectionLength = 999;
		}

		private void txtSearch_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case 13:
					doSearch();
					KeyAscii = 0;
					break;
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
	}
}
