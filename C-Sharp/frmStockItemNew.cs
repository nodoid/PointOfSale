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
	internal partial class frmStockItemNew : System.Windows.Forms.Form
	{
		int gBrandItem;
		int gStockItem;
		const short mdProducts = 0;
		const short mdDetails = 1;
		const short mdBarcodes = 3;
		const short mdCustomDetails = 2;
		const short mdFinish = 4;
		short gSystem;
		short gMode;
		List<GroupBox> frmMode = new List<GroupBox>();
		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1668;
			//New Stock Item|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//NOTE: DB Entry 1001 needs Double Quotations
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1001;
			//Select the product for the new stock item|Checked
			if (modRecordSet.rsLang.RecordCount){_frmMode_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_frmMode_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1080;
			//Search|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_35.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_35.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//NOTE: Full label not matching DB entry 1002 as it requires a count(er) attached to it!
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1002;
			if (modRecordSet.rsLang.RecordCount){lblRecords.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lblRecords.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1003;
			//The product I want is not in the list.|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCustom.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCustom.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdBack.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdBack.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//missing ">>" and "&" characters
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1005;
			//Next|Checked
			if (modRecordSet.rsLang.RecordCount){cmdNext.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdNext.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//frmMode(1) = No Code

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1009;
			//Display Name|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_7.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_7.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//txtName = No Code/NA?

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1011;
			//Receipt Name|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_8.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_8.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//txtReceipt = No Code/NA?

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1776;
			//Supplier|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1013;
			//Deposit|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_6.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_6.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1021;
			//Pricing Group|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1022;
			//Stock Group|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_4.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_4.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1019;
			//Pack Size|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_5.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_5.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lblLabels_2 = No code     [There Are]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblLabels_10 = No Code    [Units in a Case/Carton, which costs]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_10.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_10.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblLabels_1 = No Code     [And you sell in shrinks of]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmStockItemNew.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void loadProducts()
		{
			string lString = null;
			short x = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			gMode = 0;



			for (x = 0; x <= frmMode.Count - 1; x++) {
				frmMode[x].Visible = false;
			}

			frmMode[0].Left = frmMode[0].Left;
			frmMode[0].Top = frmMode[0].Top;
			frmMode[0].Visible = true;
			frmMode[0].Refresh();

			lString = Strings.Trim(txtSearch.Text);
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");

			if (string.IsNullOrEmpty(Strings.Trim(txtSearch.Text))) {
				lString = "Where (StockItem.StockItemID Is Null)";
			} else {
				lString = "(BrandItem_Name LIKE '%" + Strings.Replace(lString, " ", "%' AND BrandItem_Name LIKE '%") + "%')";
				lString = "Where (StockItem.StockItemID Is Null) AND " + lString;
			}

			rs = modRecordSet.getRS(ref "SELECT TOP 100 PERCENT BrandItem.BrandItemID, BrandItem.BrandItem_Name FROM BrandItem LEFT OUTER JOIN StockItem ON BrandItem.BrandItemID = StockItem.StockItem_BrandItemID " + lString + " ORDER BY BrandItem.BrandItem_Name");
			if (rs.RecordCount) {
				lblRecords.Text = "Displayed Records : " + rs.RecordCount;
			} else {
				if (!string.IsNullOrEmpty(Strings.Trim(txtSearch.Text)))
					rs = modRecordSet.getRS(ref "SELECT TOP 100 PERCENT BrandItem.BrandItemID, BrandItem.BrandItem_Name FROM BrandItemQuantity INNER JOIN (BrandItem LEFT JOIN StockItem ON BrandItem.BrandItemID = StockItem.StockItem_BrandItemID) ON BrandItemQuantity.BrandItemQuantity_BrandItemID = BrandItem.BrandItemID WHERE (((BrandItemQuantity.BrandItemQuantity_Barcode)='" + Strings.Trim(txtSearch.Text) + "') AND ((StockItem.StockItemID) Is Null)) ORDER BY BrandItem.BrandItem_Name;");
			}

			BindingSource bind = new BindingSource();
			bind.DataSource = rs;
			DataList1.DataSource = rs;
			DataList1.listField = "BrandItem_Name";
			DataList1.DataBindings.Add(bind.DataSource);
			DataList1.boundColumn = "BrandItemID";
			this.cmdBack.Text = "E&xit";
			this.cmdNext.Text = "&Next";
			this.cmdNext.Enabled = true;
			if (txtSearch.Visible)
				this.txtSearch.Focus();

		}
		private void doMode(ref short mode)
		{
			short mdSystemDetails = 0;
			gMode = mode;
			short x = 0;
			for (x = 0; x <= frmMode.Count - 1; x++) {
				frmMode[x].Visible = false;
			}
			frmMode[gMode].Left = frmMode[0].Left;
			frmMode[gMode].Top = frmMode[0].Top;
			frmMode[gMode].Visible = true;
			frmMode[gMode].Refresh();
			switch (gMode) {
				case mdProducts:
					loadProducts();
					break;
				case mdSystemDetails:
					break;
				case mdCustomDetails:
					loadCustom();

					break;
			}
		}

		private void cmbDeposit_KeyDown(System.Object eventSender, KeyEventArgs eventArgs)
		{
			if (eventArgs.KeyCode == 27) {
				//eventArgs.KeyCode = 0
				cmdBack_Click(cmdBack, new System.EventArgs());
			}
		}

		private void cmbPackSize_KeyDown(System.Object eventSender, KeyEventArgs eventArgs)
		{
			if (eventArgs.KeyCode == 27) {
				//eventArgs.KeyCode = 0
				cmdBack_Click(cmdBack, new System.EventArgs());
			}
		}

		private void cmbPricingGroup_KeyDown(System.Object eventSender, KeyEventArgs eventArgs)
		{
			if (eventArgs.KeyCode == 27) {
				//eventArgs.KeyCode = 0
				cmdBack_Click(cmdBack, new System.EventArgs());
			}
		}

		private void cmbShrink_KeyDown(System.Object eventSender, KeyEventArgs eventArgs)
		{
			if (eventArgs.KeyCode == 27) {
				//eventArgs.KeyCode = 0
				cmdBack_Click(cmdBack, new System.EventArgs());
			}
		}

		private void cmbStockGroup_KeyDown(System.Object eventSender, KeyEventArgs eventArgs)
		{
			if (eventArgs.KeyCode == 27) {
				//eventArgs.KeyCode = 0
				cmdBack_Click(cmdBack, new System.EventArgs());
			}
		}

		private void cmbSupplier_KeyDown(System.Object eventSender, KeyEventArgs eventArgs)
		{
			if (eventArgs.KeyCode == 27) {
				//eventArgs.KeyCode = 0
				cmdBack_Click(cmdBack, new System.EventArgs());
			}

		}
		private void cmdBack_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short x = 0;
			switch (gMode) {
				case 0:
					this.Close();
					break;
				case 1:
					gMode = 0;
					for (x = 0; x <= frmMode.Count - 1; x++) {
						frmMode[x].Visible = false;
					}

					frmMode[0].Left = frmMode[0].Left;
					frmMode[0].Top = frmMode[0].Top;
					frmMode[0].Visible = true;
					frmMode[0].Refresh();
					txtSearch.Focus();
					cmdBack.Text = "E&xit";
					break;
			}
		}




		private void cmdCustom_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string vValue = null;
			string hkey = null;
			int lRetVal = 0;
			if (checkSecurity() == true) {

				//for Security Code
				if (bolSecurityCode() == true) {
					loadCustom();
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

					if (Information.IsDBNull(rs("Company_TerminateDate")) & vValue == "0") {
						modRecordSet.cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" + DateAndTime.Today + "#;");
						lRetVal = modUtilities.RegCreateKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\Microsoft\\Windows\\CurrentVersion\\ShellDls\\MSOCache", 0, "soap", 0, modUtilities.KEY_ALL_ACCESS, 0, ref hkey, ref 0);
						lRetVal = modUtilities.RegOpenKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\Microsoft\\Windows\\CurrentVersion\\ShellDls", 0, modUtilities.KEY_ALL_ACCESS, ref hkey);
						modUtilities.SetValueEx(hkey, ref "ShellClass", ref modUtilities.REG_SZ, ref Conversion.Hex(DateAndTime.Today.ToOADate()));
						modUtilities.RegCloseKey(hkey);
					} else {
						if (Information.IsDBNull(rs("Company_TerminateDate")) & vValue != "0") {
							//db date tempered
							if (modApplication.posDemo() == true) {
								modRecordSet.cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" + DateAndTime.Today + "#;");
								lRetVal = modUtilities.RegCreateKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\Microsoft\\Windows\\CurrentVersion\\ShellDls\\MSOCache", 0, "soap", 0, modUtilities.KEY_ALL_ACCESS, 0, ref hkey, ref 0);
								lRetVal = modUtilities.RegOpenKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\Microsoft\\Windows\\CurrentVersion\\ShellDls", 0, modUtilities.KEY_ALL_ACCESS, ref hkey);
								modUtilities.SetValueEx(hkey, ref "ShellClass", ref modUtilities.REG_SZ, ref Conversion.Hex(DateAndTime.Today.ToOADate()));
								modUtilities.RegCloseKey(hkey);
							} else {
								modRecordSet.cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" + (System.DateTime.FromOADate(DateAndTime.Today.ToOADate() - 20)) + "#;");
								Interaction.MsgBox("Invalid License found." + Constants.vbCrLf + "application will now exit", MsgBoxStyle.Critical, "Run Time Error");
								System.Environment.Exit(0);
							}
						}

						if (Information.IsDBNull(rs("Company_TerminateDate"))) {
						} else {
							//UPGRADE_WARNING: Couldn't resolve default property of object rs(Company_TerminateDate). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							if (rs("Company_TerminateDate").Value > DateAndTime.Today) {
								//db date tempered
								modRecordSet.cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" + (System.DateTime.FromOADate(DateAndTime.Today.ToOADate() - 20)) + "#;");
								Interaction.MsgBox("Invalid License found." + Constants.vbCrLf + "application will now exit", MsgBoxStyle.Critical, "Run Time Error");
								System.Environment.Exit(0);
							}
						}

						if (DateAndTime.Today >= Convert.ToDateTime(rs("Company_TerminateDate").Value + 30)) {
							//    cnnDB.Execute "UPDATE Company SET Company.Company_Code = '';"
							//    checkSecurity = False
							Interaction.MsgBox("New Stock Items may only be added with registered versions of your 4POS system." + Constants.vbCrLf + "Please contact your 4POS representative or www.4pos.co.za.", MsgBoxStyle.Critical, "4POS Expired");
							return;
						} else {
							loadCustom();
						}
					}
				}
			}
		}

		private void cmdDeposit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmDepositList.loadItem(ref 0);
			doDataControl(ref (this.cmbDeposit), ref "SELECT DepositID, Deposit_Name FROM Deposit WHERE Deposit_Disabled=False ORDER BY Deposit_Name", ref "StockItem_DepositID", ref "DepositID", ref "Deposit_Name");
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "SELECT * FROM [Default]");
			if (rs.RecordCount) {
				cmbDeposit.BoundText = rs.Fields("Default_DepositID").Value;
			} else {
				cmbDeposit.BoundText = Convert.ToString(0);
			}
		}

		private void cmdNext_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdNext.Focus();
			System.Windows.Forms.Application.DoEvents();
			switch (gMode) {
				case 0:
					DataList1_DblClick(DataList1, new System.EventArgs());
					break;
				case 1:
					createProduct();
					break;
			}
		}
		private void createProduct()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;

			if (string.IsNullOrEmpty(txtName.Text)) {
				Interaction.MsgBox("Product Name is a required field!", MsgBoxStyle.Exclamation, this.Text);
				txtName.Focus();
				return;
			}
			if (string.IsNullOrEmpty(txtReceipt.Text)) {
				Interaction.MsgBox("Receipt Name is a required field!", MsgBoxStyle.Exclamation, this.Text);
				txtReceipt.Focus();
				return;
			}
			if (string.IsNullOrEmpty(cmbSupplier.CtlText)) {
				Interaction.MsgBox("The Supplier field Must Not be empty!", MsgBoxStyle.Exclamation, this.Text);
				cmbSupplier.Focus();
				return;
			}
			if (string.IsNullOrEmpty(cmbDeposit.CtlText)) {
				Interaction.MsgBox("The Deposit field Must Not be empty!", MsgBoxStyle.Exclamation, this.Text);
				cmbDeposit.Focus();
				return;
			}
			if (string.IsNullOrEmpty(cmbPricingGroup.CtlText)) {
				Interaction.MsgBox("The Pricing Group field Must Not be empty!", MsgBoxStyle.Exclamation, this.Text);
				cmbPricingGroup.Focus();
				return;
			}
			if (string.IsNullOrEmpty(cmbStockGroup.CtlText)) {
				Interaction.MsgBox("The Stock Group field Must Not be empty!", MsgBoxStyle.Exclamation, this.Text);
				cmbStockGroup.Focus();
				return;
			}
			if (string.IsNullOrEmpty(cmbPackSize.CtlText)) {
				Interaction.MsgBox("The Pack Size field Must Not be empty!", MsgBoxStyle.Exclamation, this.Text);
				cmbPackSize.Focus();
				return;
			}
			if (Convert.ToInt32(txtQuantity.Text) == Convert.ToDouble("0")) {
				txtQuantity.Text = "1";
			}
			if (Convert.ToInt32(txtCost.Text) == Convert.ToDouble("0")) {
				txtCost.Text = "1";
			}

			sql = "INSERT INTO StockItem (StockItem_BrandItemID, StockItem_SupplierID, StockItem_ShrinkID, StockItem_PackSizeID, StockItem_PricingGroupID, StockItem_StockGroupID, StockItem_VatID, StockItem_DepositID, StockItem_Name, StockItem_ReceiptName, StockItem_Quantity, StockItem_ListCost, StockItem_ActualCost, StockItem_MinimumStock, StockItem_MaximumStock, StockItem_OrderQuantity, StockItem_OrderRounding, StockItem_OrderDynamic, StockItem_Disabled, StockItem_Discontinued, StockItem_QuickKey) VALUES (";
			sql = sql + gBrandItem + ", " + cmbSupplier.BoundText + ", " + cmbShrink.BoundText + ", " + cmbPackSize.BoundText + ", " + cmbPricingGroup.BoundText + ", " + cmbStockGroup.BoundText + ", 2, " + cmbDeposit.BoundText + ", '" + Strings.Replace(txtName.Text, "'", "''") + "', '" + Strings.Replace(txtReceipt.Text, "'", "''") + "', " + Strings.Replace(Convert.ToString(Convert.ToDecimal(txtQuantity.Text)), ",", "") + ", " + Strings.Replace(txtCost.Text, ",", "") + ", " + Strings.Replace(txtCost.Text, ",", "") + ", 0, 0, " + Convert.ToDecimal(txtQuantity.Text) + ", 1, 0, 0, 0, '')";
			modRecordSet.cnnDB.Execute(sql);

			sql = "SELECT Max(StockItem.StockItemID) AS id FROM StockItem;";
			rs = modRecordSet.getRS(ref sql);
			gStockItem = rs.Fields("id").Value;
			modRecordSet.cnnDB.Execute("UPDATE StockItem, Company SET StockItem.StockItem_LastCost = [Company_DayEndID] WHERE (((StockItem.StockItemID)=" + gStockItem + "));");

			modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN BrandItemSupplier ON (StockItem.StockItem_SupplierID = BrandItemSupplier.BrandItemSupplier_SupplierID) AND (StockItem.StockItem_BrandItemID = BrandItemSupplier.BrandItemSupplier_BrandItemID) SET StockItem.StockItem_SupplierCode = [BrandItemSupplier]![BrandItemSupplier_Code] WHERE (((StockItem.StockItemID)=" + gStockItem + "));");

			//Multi Warehouse change     cnnDB.Execute "INSERT INTO DayEndStockItemLnk ( DayEndStockItemLnk_DayEndID, DayEndStockItemLnk_StockItemID, DayEndStockItemLnk_Quantity, DayEndStockItemLnk_QuantitySales, DayEndStockItemLnk_QuantityShrink, DayEndStockItemLnk_QuantityGRV, DayEndStockItemLnk_ListCost, DayEndStockItemLnk_ActualCost ) SELECT Company.Company_DayEndID, " & gStockItem & " AS stock, 0, 0, 0, 0, " & CCur(txtCost.Text) / CCur(txtQuantity.Text) & ", " & CCur(txtCost.Text) / CCur(txtQuantity.Text) & " FROM Company;"
			modRecordSet.cnnDB.Execute("INSERT INTO DayEndStockItemLnk ( DayEndStockItemLnk_DayEndID, DayEndStockItemLnk_StockItemID, DayEndStockItemLnk_Quantity, DayEndStockItemLnk_QuantitySales, DayEndStockItemLnk_QuantityShrink, DayEndStockItemLnk_QuantityGRV, DayEndStockItemLnk_ListCost, DayEndStockItemLnk_ActualCost, DayEndStockItemLnk_Warehouse ) SELECT Company.Company_DayEndID, " + gStockItem + " AS stock, 0, 0, 0, 0, " + Convert.ToDecimal(txtCost.Text) / Convert.ToDecimal(txtQuantity.Text) + ", " + Convert.ToDecimal(txtCost.Text) / Convert.ToDecimal(txtQuantity.Text) + ", Warehouse.WarehouseID FROM Company, Warehouse;");
			modRecordSet.cnnDB.Execute("INSERT INTO WarehouseStockItemLnk ( WarehouseStockItemLnk_WarehouseID, WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk_Quantity ) SELECT Warehouse.WarehouseID, " + gStockItem + ", 0 FROM Warehouse;");

			modRecordSet.cnnDB.Execute("INSERT INTO tempStockItem ( tempStockItemID ) SELECT StockItem.StockItemID FROM tempStockItem RIGHT JOIN StockItem ON tempStockItem.tempStockItemID = StockItem.StockItemID WHERE (((tempStockItem.tempStockItemID) Is Null) AND ((StockItem.StockItemID)=" + gStockItem + "));");

			modRecordSet.cnnDB.Execute("DELETE FROM systemStockItemPricing;");
			modRecordSet.cnnDB.Execute("INSERT INTO systemStockItemPricing ( systemStockItemPricing ) VALUES (" + gStockItem + ")");
			frmUpdateCatalogue formUpdate = null;
			formUpdate.Show();

			modApplication.buildBarcodes(ref gStockItem);
			if (gBrandItem) {
				modRecordSet.cnnDB.Execute("UPDATE (StockItem INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN BrandItemQuantity ON (BrandItemQuantity.BrandItemQuantity_Quantity = Catalogue.Catalogue_Quantity) AND (StockItem.StockItem_BrandItemID = BrandItemQuantity.BrandItemQuantity_BrandItemID) SET Catalogue.Catalogue_Barcode = [BrandItemQuantity]![BrandItemQuantity_Barcode] WHERE (((StockItem.StockItemID)=" + gStockItem + "));");
			}
			My.MyProject.Forms.frmStockBarcode.loadItem(ref gStockItem);
			frmStockBarcode formBar = null;
			formBar.Show();
			My.MyProject.Forms.frmStockPricing.loadItem(ref gStockItem);
			frmStockPricing formPrice = null;
			formPrice.Show();
			gStockItem = 0;
			gBrandItem = 0;
			loadProducts();


		}

		private void cmdPackSize_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmPackSizeList.loadItem();
			doDataControl(ref (this.cmbPackSize), ref "SELECT PackSizeID, PackSize_Name FROM PackSize ORDER BY PackSize_Name", ref "StockItem_PackSizeID", ref "PackSizeID", ref "PackSize_Name");
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "SELECT * FROM [Default]");
			if (rs.RecordCount) {
				cmbPackSize.BoundText = rs.Fields("Default_PricingGroupID").Value;
			} else {
				cmbPackSize.BoundText = Convert.ToString(1);
			}
		}

		private void cmdPricingGroup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmPricingGroupList.getItem();
			doDataControl(ref (this.cmbPricingGroup), ref "SELECT PricingGroupID, PricingGroup_Name FROM PricingGroup WHERE PricingGroup_Disabled = 0 ORDER BY PricingGroup_Name", ref "StockItem_PricingGroupID", ref "PricingGroupID", ref "PricingGroup_Name");
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "SELECT * FROM [Default]");
			if (rs.RecordCount) {
				cmbPricingGroup.BoundText = rs.Fields("Default_PricingGroupID").Value;
			} else {
				cmbPricingGroup.BoundText = Convert.ToString(1);
			}
		}

		private void cmdShrink_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmShrink.ShowDialog();
			doDataControl(ref (this.cmbShrink), ref "SELECT ShrinkID, Shrink_Name FROM Shrink ORDER BY Shrink_Name", ref "StockItem_ShrinkID", ref "ShrinkID", ref "Shrink_Name");
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "SELECT * FROM [Default]");
			if (rs.RecordCount) {
				cmbShrink.BoundText = rs.Fields("Default_ShrinkID").Value;
			} else {
				cmbShrink.BoundText = Convert.ToString(12);
			}
		}
		private void cmdStockGroup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmStockGroupList.loadItem(ref 0);
			doDataControl(ref (this.cmbStockGroup), ref "SELECT StockGroupID, StockGroup_Name FROM StockGroup WHERE StockGroup_Disabled=False ORDER BY StockGroup_Name", ref "StockItem_StockGroupID", ref "StockGroupID", ref "StockGroup_Name");
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "SELECT * FROM [Default]");
			if (rs.RecordCount) {
				cmbStockGroup.BoundText = rs.Fields("Default_StockGroupID").Value;
			} else {
				cmbStockGroup.BoundText = Convert.ToString(1);
			}
		}
		private void cmdSupplier_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmSupplierList.loadItem(ref 0);
			doDataControl(ref (this.cmbSupplier), ref "SELECT SupplierID, Supplier_Name FROM Supplier WHERE Supplier_Disabled=False ORDER BY Supplier_Name", ref "StockItem_SupplierID", ref "SupplierID", ref "Supplier_Name");
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "SELECT * FROM [Default]");
			if (rs.RecordCount) {
				cmbSupplier.BoundText = rs.Fields("Default_SupplierID").Value;
			} else {
				cmbSupplier.BoundText = Convert.ToString(4);
			}
		}
		private string getSerialNumber()
		{
			string functionReturnValue = null;
			Scripting.FileSystemObject FSO = new Scripting.FileSystemObject();
			Scripting.Folder fsoFolder = default(Scripting.Folder);
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

		private void DataList1_DblClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			int gStockItemID = 0;
			int gBrandItemID = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			short x = 0;

			string vValue = null;
			string hkey = "";
			int lRetVal = 0;
			if (checkSecurity() == true) {

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

					if (Information.IsDBNull(rs.Fields("Company_TerminateDate").Value) & vValue == "0") {
						modRecordSet.cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" + DateAndTime.Today + "#;");
						lRetVal = modUtilities.RegCreateKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\Microsoft\\Windows\\CurrentVersion\\ShellDls\\MSOCache", 0, "soap", 0, modUtilities.KEY_ALL_ACCESS, 0, ref hkey, ref 0);
						lRetVal = modUtilities.RegOpenKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\Microsoft\\Windows\\CurrentVersion\\ShellDls", 0, modUtilities.KEY_ALL_ACCESS, ref hkey);
						modUtilities.SetValueEx(hkey, ref "ShellClass", ref modUtilities.REG_SZ, ref Conversion.Hex(DateAndTime.Today.ToOADate()));
						modUtilities.RegCloseKey(hkey);
					} else {
						if (Information.IsDBNull(rs.Fields("Company_TerminateDate").Value) & vValue != "0") {
							//db date tempered
							if (modApplication.posDemo() == true) {
								modRecordSet.cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" + DateAndTime.Today + "#;");
								lRetVal = modUtilities.RegCreateKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\Microsoft\\Windows\\CurrentVersion\\ShellDls\\MSOCache", 0, "soap", 0, modUtilities.KEY_ALL_ACCESS, 0, ref hkey, ref 0);
								lRetVal = modUtilities.RegOpenKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\Microsoft\\Windows\\CurrentVersion\\ShellDls", 0, modUtilities.KEY_ALL_ACCESS, ref hkey);
								modUtilities.SetValueEx(hkey, ref "ShellClass", ref modUtilities.REG_SZ, ref Conversion.Hex(DateAndTime.Today.ToOADate()));
								modUtilities.RegCloseKey(hkey);
							} else {
								modRecordSet.cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" + (System.DateTime.FromOADate(DateAndTime.Today.ToOADate() - 20)) + "#;");
								Interaction.MsgBox("Invalid License found." + Constants.vbCrLf + "application will now exit", MsgBoxStyle.Critical, "Run Time Error");
								System.Environment.Exit(0);
							}
						}

						if (Information.IsDBNull(rs.Fields("Company_TerminateDate").Value)) {
						} else {
							if (rs.Fields("Company_TerminateDate").Value > DateAndTime.Today) {
								//db date tempered
								modRecordSet.cnnDB.Execute("UPDATE Company SET Company_TerminateDate = #" + (System.DateTime.FromOADate(DateAndTime.Today.ToOADate() - 20)) + "#;");
								Interaction.MsgBox("Invalid License found." + Constants.vbCrLf + "application will now exit", MsgBoxStyle.Critical, "Run Time Error");
								System.Environment.Exit(0);
							}
						}

						if (DateAndTime.Today >= Convert.ToDateTime(rs.Fields("Company_TerminateDate").Value + 30)) {
							//    cnnDB.Execute "UPDATE Company SET Company.Company_Code = '';"
							//   checkSecurity = False
							Interaction.MsgBox("New Stock Items may only be added with registered versions of your 4POS system." + Constants.vbCrLf + "Please contact your 4POS representative or www.4pos.co.za.", MsgBoxStyle.Critical, "4POS Expired");
							return;

						} else {
						}
					}
				}
			}

			if (!string.IsNullOrEmpty(DataList1.BoundText)) {
				gMode = 1;
				gBrandItemID = 0;
				gStockItemID = 0;
				txtName.Enabled = false;
				txtReceipt.Enabled = false;
				cmbStockGroup.BoundText = Convert.ToString(35);

				rs = modRecordSet.getRS(ref "SELECT * FROM BrandItem WHERE BrandItemID = " + DataList1.BoundText);

				gBrandItem = rs.Fields("BrandItemID").Value;
				txtName.Text = rs.Fields("BrandItem_Name").Value;
				txtReceipt.Text = rs.Fields("BrandItem_ReceiptName").Value;
				cmbShrink.BoundText = rs.Fields("BrandItem_ShrinkID").Value;
				cmbDeposit.BoundText = rs.Fields("BrandItem_DepositID").Value;

				cmbPricingGroup.BoundText = (Information.IsDBNull(rs.Fields("BrandItem_PricingGroupID").Value) ? 1 : rs.Fields("BrandItem_PricingGroupID").Value);
				//rs("BrandItem_PricingGroupID")
				cmbStockGroup.BoundText = (Information.IsDBNull(rs.Fields("BrandItem_StockGroupID").Value) ? 1 : rs.Fields("BrandItem_StockGroupID").Value);
				//rs("BrandItem_StockGroupID")
				cmbPackSize.BoundText = (Information.IsDBNull(rs.Fields("BrandItem_PackSizeID").Value) ? 1 : rs.Fields("BrandItem_PackSizeID").Value);
				//rs("BrandItem_PackSizeID")

				rs = modRecordSet.getRS(ref "SELECT TOP 1 BrandItemSupplier.BrandItemSupplier_SupplierID, BrandItemSupplier.BrandItemSupplier_Quantity, BrandItemSupplier.BrandItemSupplier_PackCost From BrandItemSupplier Where (((BrandItemSupplier.BrandItemSupplier_BrandItemID) = " + gBrandItem + ")) ORDER BY BrandItemSupplier.BrandItemSupplier_SupplierID;");
				if (rs.BOF | rs.EOF) {
				} else {
					cmbSupplier.BoundText = rs.Fields("BrandItemSupplier_SupplierID").Value;
					txtQuantity.Text = Strings.FormatNumber(rs.Fields("BrandItemSupplier_Quantity").Value, 0);
					txtCost.Text = Strings.FormatNumber(rs.Fields("BrandItemSupplier_PackCost").Value, 2);
				}

				for (x = 0; x <= frmMode.Count - 1; x++) {
					frmMode[x].Visible = false;
				}

				frmMode[1].Left = frmMode[0].Left;
				frmMode[1].Top = frmMode[0].Top;
				frmMode[1].Visible = true;
				frmMode[1].Refresh();
				cmbSupplier.Focus();
				cmdBack.Text = "&Back";

			}
		}
		private void DataList1_KeyPress(System.Object eventSender, KeyPressEventArgs eventArgs)
		{
			if (eventArgs.KeyChar == Strings.ChrW(13)) {
				eventArgs.KeyChar = Strings.ChrW(0);
				DataList1_DblClick(DataList1, new System.EventArgs());
			}
		}
		private void frmStockItemNew_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 27) {
				KeyAscii = 0;
				cmdBack_Click(cmdBack, new System.EventArgs());
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
		private void frmStockItemNew_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			frmMode.AddRange(new GroupBox[] {
				_frmMode_0,
				_frmMode_1
			});
			int gStockItemID = 0;
			int gBrandItemID = 0;
			gBrandItemID = 0;
			gStockItemID = 0;
			buildDataControls();
			doMode(ref mdProducts);

			loadLanguage();
		}

		private void loadCustom()
		{
			int gStockItemID = 0;
			int gBrandItemID = 0;
			short x = 0;
			gMode = 1;
			gBrandItemID = 0;
			gStockItemID = 0;
			txtName.Enabled = true;
			txtReceipt.Enabled = true;
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "SELECT * FROM [Default]");
			if (rs.RecordCount) {
				cmbShrink.BoundText = rs.Fields("Default_ShrinkID").Value;
				cmbSupplier.BoundText = rs.Fields("Default_SupplierID").Value;
				cmbDeposit.BoundText = rs.Fields("Default_DepositID").Value;
				cmbStockGroup.BoundText = rs.Fields("Default_StockGroupID").Value;
				cmbPricingGroup.BoundText = rs.Fields("Default_PricingGroupID").Value;
				cmbPackSize.BoundText = rs.Fields("Default_PricingGroupID").Value;
			} else {
				cmbShrink.BoundText = Convert.ToString(12);
				cmbSupplier.BoundText = Convert.ToString(4);
				cmbDeposit.BoundText = Convert.ToString(0);
				cmbStockGroup.BoundText = Convert.ToString(1);
				cmbPricingGroup.BoundText = Convert.ToString(1);
				cmbPackSize.BoundText = Convert.ToString(1);
			}
			for (x = 0; x <= frmMode.Count - 1; x++) {
				frmMode[x].Visible = false;
			}
			frmMode[1].Left = frmMode[0].Left;
			frmMode[1].Top = frmMode[0].Top;
			frmMode[1].Visible = true;
			frmMode[1].Refresh();
			cmdBack.Text = "&Back";
			txtName.Focus();
		}
		private void buildDataControls()
		{
			doDataControl(ref (this.cmbShrink), ref "SELECT ShrinkID, Shrink_Name FROM Shrink ORDER BY Shrink_Name", ref "StockItem_ShrinkID", ref "ShrinkID", ref "Shrink_Name");
			doDataControl(ref (this.cmbPricingGroup), ref "SELECT PricingGroupID, PricingGroup_Name FROM PricingGroup WHERE PricingGroup_Disabled = 0 ORDER BY PricingGroup_Name", ref "StockItem_PricingGroupID", ref "PricingGroupID", ref "PricingGroup_Name");
			doDataControl(ref (this.cmbSupplier), ref "SELECT SupplierID, Supplier_Name FROM Supplier WHERE Supplier_Disabled=False ORDER BY Supplier_Name", ref "StockItem_SupplierID", ref "SupplierID", ref "Supplier_Name");
			doDataControl(ref (this.cmbDeposit), ref "SELECT DepositID, Deposit_Name FROM Deposit WHERE Deposit_Disabled=False ORDER BY Deposit_Name", ref "StockItem_DepositID", ref "DepositID", ref "Deposit_Name");
			doDataControl(ref (this.cmbStockGroup), ref "SELECT StockGroupID, StockGroup_Name FROM StockGroup WHERE StockGroup_Disabled=False ORDER BY StockGroup_Name", ref "StockItem_StockGroupID", ref "StockGroupID", ref "StockGroup_Name");
			doDataControl(ref (this.cmbPackSize), ref "SELECT PackSizeID, PackSize_Name FROM PackSize ORDER BY PackSize_Name", ref "StockItem_PackSizeID", ref "PackSizeID", ref "PackSize_Name");
		}

		private void doDataControl(ref myDataGridView dataControl, ref string sql, ref string DataField, ref string boundColumn, ref string listField)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref sql);
			dataControl.DataSource = rs;
			dataControl.boundColumn = boundColumn;
			dataControl.listField = listField;
		}
		private void txtName_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocus(ref txtName);
		}

		private void txtName_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (string.IsNullOrEmpty(txtReceipt.Text) | txtReceipt.Text == "[New Product]") {
				txtReceipt.Text = txtName.Text;
			}
		}

		private void txtReceipt_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocus(ref txtReceipt);
		}

		private void txtQuantity_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtQuantity);
		}

		private void txtQuantity_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			modUtilities.MyKeyPress(ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtQuantity_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtQuantity, ref 0);
		}

		private void txtCost_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtCost);
		}

		private void txtCost_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			modUtilities.MyKeyPress(ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtCost_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtCost, ref 2);
		}

		private void txtSearch_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtSearch.SelectionStart = 0;
			txtSearch.SelectionLength = 999;
		}

		private void txtSearch_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			if (KeyCode == 40) {
				this.DataList1.Focus();
			}
		}
		private void txtSearch_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 13) {
				loadProducts();
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
	}
}
