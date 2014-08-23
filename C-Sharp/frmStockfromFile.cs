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
	internal partial class frmStockfromFile : System.Windows.Forms.Form
	{
		string stBarcode;
		short slProd;
		int gBrandItem;
		int gStockItem;
		const short mdProducts = 0;
		const short mdDetails = 1;
		const short mdBarcodes = 3;
		const short mdCustomDetails = 2;
		const short mdFinish = 4;
		short gSystem;
		short gMode;

		private void loadLanguage()
		{

			//frmStockfromFile = No Code     [Adding Stock Items]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmStockfromFile.Caption = rsLang("LanguageLayoutLnk_Description"): frmStockfromFile.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdBack.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdBack.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//cmdNext = No Code              [Do Update]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdNext.Caption = rsLang("LanguageLayoutLnk_Description"): cmdNext.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1 = No Code               [File Name]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmStockfromFile.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void doMode(ref short mode)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsC = default(ADODB.Recordset);
			gMode = mode;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			string lStringRecord = null;
			int x = 0;

			//stBarcode = ""
			//If txtFile.Text = "" Then
			//    MsgBox "Please Upload the file to load data from", vbApplicationModal + vbInformation + vbOKOnly, App.title
			//   Exit Sub
			//Else
			System.Windows.Forms.Application.DoEvents();

			//    Set TS = FSO.OpenTextFile(CommonDialog1.FileName)
			//    If TS Is Nothing Then
			//       Else
			//           If TS.AtEndOfStream Then
			//                MsgBox CommonDialog1.FileName & " is an Empty file!", vbExclamation, "FILE ERROR"
			//                Exit Sub
			//           Else
			//             X = 0
			//               Do Until TS.AtEndOfStream
			//
			//
			//
			//                  lStringRecord = TS.ReadLine
			//
			//                  k = Len(lStringRecord) - Len(Right(lStringRecord, Len(lStringRecord) - InStr(lStringRecord, ",")))


			//                  lStringRecord = Mid$(lStringRecord, 1, k - 1)

			rs = modRecordSet.getRS(ref "SELECT TOP 100 PERCENT BrandItem.BrandItemID, BrandItem.BrandItem_Name FROM BrandItem LEFT OUTER JOIN StockItem ON BrandItem.BrandItemID = StockItem.StockItem_BrandItemID WHERE (StockItem.StockItemID IS NULL) ORDER BY BrandItem.BrandItem_Name");



			//Set rsC = getRS("SELECT * FROM Catalogue WHERE Catalogue_Barcode ='" & lStringRecord & "'")


			while (rs.EOF == false) {
				//If rs.RecordCount > 0 Then

				//Else
				//Set rs = getRS("SELECT * FROM BrandItem,BrandItemQuantity WHERE BrandItem.BrandItemID = BrandItemQuantity.BrandItemQuantity_BrandItemID AND BrandItemQuantity_Barcode = '" & lStringRecord & "'")
				rsC = modRecordSet.getRS(ref "SELECT * FROM BrandItem,BrandItemQuantity WHERE BrandItem.BrandItemID = BrandItemQuantity.BrandItemQuantity_BrandItemID AND BrandItemQuantity_BrandItemID = " + rs.Fields("BrandItemID").Value + "");

				if (rsC.RecordCount) {
					x = x + 1;
					gBrandItem = rsC.Fields("BrandItemID").Value;
					txtName.Text = rsC.Fields("BrandItem_Name").Value;
					txtReceipt.Text = rsC.Fields("BrandItem_ReceiptName").Value;
					createProduct();
				} else {
					x = x + 1;
					stBarcode = lStringRecord;
					txtName.Text = "[New Product]";
					txtReceipt.Text = "[New Product]";
					createProduct();

				}

				//End If

				rs.MoveNext();
			}

			//      End If
			//    End If
			//   Label2.Caption = "Number Of Record Added :" & Str(X)
			//End If

		}
		private void cboBarcode_Click()
		{
			_frmMode_1.Enabled = true;

		}

		private void cmbDeposit_KeyDown(System.Object eventSender, KeyEventArgs eventArgs)
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
				//eventArgs.KeyChar = ChrW(0)
				cmdBack_Click(cmdBack, new System.EventArgs());
			}
		}

		private void cmbStockGroup_KeyDown(System.Object eventSender, KeyEventArgs eventArgs)
		{
			if (eventArgs.KeyCode == 27) {
				//eventArgs.KeyChar = ChrW(0)
				cmdBack_Click(cmdBack, new System.EventArgs());
			}
		}

		private void cmbSupplier_KeyDown(System.Object eventSender, KeyEventArgs eventArgs)
		{
			if (eventArgs.KeyCode == 27) {
				//eventArgs.KeyChar = ChrW(0)
				cmdBack_Click(cmdBack, new System.EventArgs());
			}

		}
		private void cmdBack_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdCustom_Click()
		{
			loadCustom();
		}
		private void cmdNext_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			doMode(ref mdProducts);
			System.Windows.Forms.Application.DoEvents();
			cmdNext.Focus();
			System.Windows.Forms.Application.DoEvents();

		}
		private void createProduct()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			if (string.IsNullOrEmpty(txtName.Text)) {
				Interaction.MsgBox("Product Name is a required field", MsgBoxStyle.Exclamation, this.Text);
				txtName.Focus();
				return;
			}
			if (string.IsNullOrEmpty(txtReceipt.Text)) {
				Interaction.MsgBox("Receipt Name is a required field", MsgBoxStyle.Exclamation, this.Text);
				txtReceipt.Focus();
				return;
			}

			txtQuantity.Text = "1";

			txtCost.Text = "1";

			if (string.IsNullOrEmpty(cmbSupplier.BoundText) | string.IsNullOrEmpty(cmbShrink.BoundText) | string.IsNullOrEmpty(cmbPricingGroup.BoundText) | string.IsNullOrEmpty(cmbStockGroup.BoundText) | string.IsNullOrEmpty(cmbDeposit.BoundText)) {
				Interaction.MsgBox("Please enter all the required information", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				return;
			}

			sql = "INSERT INTO StockItem (StockItem_BrandItemID, StockItem_SupplierID, StockItem_ShrinkID, StockItem_PricingGroupID, StockItem_StockGroupID, StockItem_VatID, StockItem_DepositID, StockItem_Name, StockItem_ReceiptName, StockItem_Quantity, StockItem_ListCost, StockItem_ActualCost, StockItem_MinimumStock, StockItem_MaximumStock, StockItem_OrderQuantity, StockItem_OrderRounding, StockItem_OrderDynamic, StockItem_Disabled, StockItem_Discontinued, StockItem_QuickKey) VALUES (";
			sql = sql + gBrandItem + ", " + cmbSupplier.BoundText + ", " + cmbShrink.BoundText + ", " + cmbPricingGroup.BoundText + ", " + cmbStockGroup.BoundText + ", 2, " + cmbDeposit.BoundText + ", '" + Strings.Replace(txtName.Text, "'", "''") + "', '" + Strings.Replace(txtReceipt.Text, "'", "''") + "', " + Strings.Replace(txtQuantity.Text, ",", "") + ", " + Strings.Replace(txtCost.Text, ",", "") + ", " + Strings.Replace(txtCost.Text, ",", "") + ", 0, 0, " + txtQuantity.Text + ", 1, 0, 0, 0, '')";

			modRecordSet.cnnDB.Execute(sql);

			sql = "SELECT Max(StockItem.StockItemID) AS id FROM StockItem;";
			rs = modRecordSet.getRS(ref sql);
			gStockItem = rs.Fields("id").Value;
			modRecordSet.cnnDB.Execute("UPDATE StockItem, Company SET StockItem.StockItem_LastCost = [Company_DayEndID] WHERE (((StockItem.StockItemID)=" + gStockItem + "));");

			modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN BrandItemSupplier ON (StockItem.StockItem_SupplierID = BrandItemSupplier.BrandItemSupplier_SupplierID) AND (StockItem.StockItem_BrandItemID = BrandItemSupplier.BrandItemSupplier_BrandItemID) SET StockItem.StockItem_SupplierCode = [BrandItemSupplier]![BrandItemSupplier_Code] WHERE (((StockItem.StockItemID)=" + gStockItem + "));");

			modRecordSet.cnnDB.Execute("INSERT INTO DayEndStockItemLnk ( DayEndStockItemLnk_DayEndID, DayEndStockItemLnk_StockItemID, DayEndStockItemLnk_Quantity, DayEndStockItemLnk_QuantitySales, DayEndStockItemLnk_QuantityShrink, DayEndStockItemLnk_QuantityGRV, DayEndStockItemLnk_ListCost, DayEndStockItemLnk_ActualCost ) SELECT Company.Company_DayEndID, " + gStockItem + " AS stock, 0, 0, 0, 0, " + Convert.ToDecimal(txtCost.Text) / Convert.ToDecimal(txtQuantity.Text) + ", " + Convert.ToDecimal(txtCost.Text) / Convert.ToDecimal(txtQuantity.Text) + " FROM Company;");
			modRecordSet.cnnDB.Execute("INSERT INTO WarehouseStockItemLnk ( WarehouseStockItemLnk_WarehouseID, WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk_Quantity ) SELECT Warehouse.WarehouseID, " + gStockItem + ", 0 FROM Warehouse;");

			modRecordSet.cnnDB.Execute("INSERT INTO tempStockItem ( tempStockItemID ) SELECT StockItem.StockItemID FROM tempStockItem RIGHT JOIN StockItem ON tempStockItem.tempStockItemID = StockItem.StockItemID WHERE (((tempStockItem.tempStockItemID) Is Null) AND ((StockItem.StockItemID)=" + gStockItem + "));");

			modRecordSet.cnnDB.Execute("DELETE FROM systemStockItemPricing;");
			modRecordSet.cnnDB.Execute("INSERT INTO systemStockItemPricing ( systemStockItemPricing ) VALUES (" + gStockItem + ")");
			frmUpdateCatalogue update = new frmUpdateCatalogue();
			update.Show();

			modApplication.buildBarcodes(ref gStockItem);

			if (gBrandItem) {
				modRecordSet.cnnDB.Execute("UPDATE (StockItem INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN BrandItemQuantity ON (BrandItemQuantity.BrandItemQuantity_Quantity = Catalogue.Catalogue_Quantity) AND (StockItem.StockItem_BrandItemID = BrandItemQuantity.BrandItemQuantity_BrandItemID) SET Catalogue.Catalogue_Barcode = [BrandItemQuantity]![BrandItemQuantity_Barcode] WHERE (((StockItem.StockItemID)=" + gStockItem + "));");
			} else {
				modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN Catalogue ON StockItem.StockItemID=Catalogue.Catalogue_StockItemID SET Catalogue.Catalogue_Barcode = '" + stBarcode + "' WHERE (((StockItem.StockItemID)=" + gStockItem + "));");

			}

			gStockItem = 0;
			gBrandItem = 0;

		}
		private void frmStockfromFile_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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
		private void frmStockfromFile_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			object gStockItemID = null;
			object gBrandItemID = null;
			//UPGRADE_WARNING: Couldn't resolve default property of object gBrandItemID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			gBrandItemID = 0;
			//UPGRADE_WARNING: Couldn't resolve default property of object gStockItemID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			gStockItemID = 0;

			loadLanguage();
			buildDataControls();
			loadCustom();
			System.Windows.Forms.Application.DoEvents();
			//Me.CommonDialog1.FileName = ""
			//Me.CommonDialog1.ShowOpen

			//txtFile.Text = CommonDialog1.FileName


		}

		private void loadCustom()
		{
			object gStockItemID = null;
			object gBrandItemID = null;
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
				cmbPricingGroup.BoundText = Convert.ToString(163);

			} else {
				cmbShrink.BoundText = Convert.ToString(12);
				cmbSupplier.BoundText = Convert.ToString(4);
				cmbDeposit.BoundText = Convert.ToString(0);
				cmbStockGroup.BoundText = Convert.ToString(1);
				cmbPricingGroup.BoundText = Convert.ToString(1);
			}


		}
		private void buildDataControls()
		{
			doDataControl(ref (this.cmbShrink), ref "SELECT ShrinkID, Shrink_Name FROM Shrink ORDER BY Shrink_Name", ref "StockItem_ShrinkID", ref "ShrinkID", ref "Shrink_Name");
			doDataControl(ref (this.cmbPricingGroup), ref "SELECT PricingGroupID, PricingGroup_Name FROM PricingGroup ORDER BY PricingGroup_Name", ref "StockItem_PricingGroupID", ref "PricingGroupID", ref "PricingGroup_Name");
			doDataControl(ref (this.cmbSupplier), ref "SELECT SupplierID, Supplier_Name FROM Supplier WHERE Supplier_Disabled=False ORDER BY Supplier_Name", ref "StockItem_SupplierID", ref "SupplierID", ref "Supplier_Name");
			doDataControl(ref (this.cmbDeposit), ref "SELECT DepositID, Deposit_Name FROM Deposit WHERE Deposit_Disabled=False ORDER BY Deposit_Name", ref "StockItem_DepositID", ref "DepositID", ref "Deposit_Name");
			doDataControl(ref (this.cmbStockGroup), ref "SELECT StockGroupID, StockGroup_Name FROM StockGroup WHERE StockGroup_Disabled=False ORDER BY StockGroup_Name", ref "StockItem_StockGroupID", ref "StockGroupID", ref "StockGroup_Name");
		}

		private void doDataControl(ref myDataGridView dataControl, ref string sql, ref string DataField, ref string boundColumn, ref string listField)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref sql);
			//UPGRADE_WARNING: Couldn't resolve default property of object dataControl.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dataControl.DataSource = rs;
			//UPGRADE_WARNING: Couldn't resolve default property of object dataControl.boundColumn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dataControl.boundColumn = boundColumn;
			//UPGRADE_WARNING: Couldn't resolve default property of object dataControl.listField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dataControl.listField = listField;
		}

		private void txtName_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocus(ref txtName);
		}

		private void txtName_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (string.IsNullOrEmpty(txtReceipt.Text)) {
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
	}
}
