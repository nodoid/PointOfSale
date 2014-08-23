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
	internal partial class frmGRVimport : System.Windows.Forms.Form
	{
		short gMode;

		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1632;
			//Import a GRV|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1622;
			//Imported GRV Data|Checked
			if (modRecordSet.rsLang.RecordCount){_Frame1_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_Frame1_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1005;
			//Next|Checked
			if (modRecordSet.rsLang.RecordCount){cmdNext.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdNext.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmGRVimport.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void loadGRV()
		{
			string lString = null;
			string[] lData = null;
			string[] lFields = null;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			Scripting.TextStream lTextstream = default(Scripting.TextStream);
			int x = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			System.Windows.Forms.ListViewItem lListitem = null;
			 // ERROR: Not supported in C#: OnErrorStatement

			if (string.IsNullOrEmpty(Module1.sGRVSales)) {
				CDOpen.ShowDialog();
				lString = CDOpen.FileName;
			} else {
				lString = Module1.sGRVSales;
			}

			lvImport.Items.Clear();
			if (string.IsNullOrEmpty(lString)) {
				this.Close();
			} else {
				modRecordSet.cnnDB.Execute("DELETE * FROM GRVimport");
				if (fso.FileExists(lString)) {
					lTextstream = fso.OpenTextFile(lString);
					lData = Strings.Split(lTextstream.ReadAll, Constants.vbCrLf);

					for (x = Information.LBound(lData); x <= Information.UBound(lData); x++) {
						lFields = Strings.Split(lData[x], ",");
						if (Information.UBound(lFields) == 4) {
							rs = modRecordSet.getRS(ref "SELECT * FROM GRVimport");
							rs.AddNew();
							//barcode,qut,cost,sell
							//code,desc,qty,cost,sell
							rs.Fields(0).Value = x + 1;
							rs.Fields(1).Value = lFields[0];
							if (string.IsNullOrEmpty(lFields[1])) {
								rs.Fields(2).Value = "0";
							} else {
								rs.Fields(2).Value = lFields[1];
							}
							if (string.IsNullOrEmpty(lFields[3])) {
								rs.Fields(3).Value = 0;
							} else {
								rs.Fields(3).Value = lFields[3];
							}
							if (string.IsNullOrEmpty(lFields[4])) {
								rs.Fields(4).Value = 0;
							} else {
								rs.Fields(4).Value = lFields[4];
							}
							rs.update();
						} else if (Information.UBound(lFields) == 1) {
							rs = modRecordSet.getRS(ref "SELECT * FROM GRVimport");
							rs.AddNew();
							//code,qty   ,desc,cost,sell
							rs.Fields(0).Value = x + 1;
							rs.Fields(1).Value = lFields[0];
							if (string.IsNullOrEmpty(lFields[1])) {
								rs.Fields(2).Value = "0";
							} else {
								rs.Fields(2).Value = lFields[1];
							}
							rs.Fields(3).Value = 0;
							rs.Fields(4).Value = 0;
							rs.update();
						}
					}
				}
				lvImport.Items.Clear();
				modRecordSet.cnnDB.Execute("UPDATE CatalogueChannelLnk INNER JOIN (Catalogue INNER JOIN GRVimport ON Catalogue.Catalogue_Barcode = GRVimport.GRVimport_Barcode) ON (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = Catalogue.Catalogue_StockItemID) SET GRVimport.GRVimport_Price = [CatalogueChannelLnk_Price] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((GRVimport.GRVimport_Price)=0));");
				modRecordSet.cnnDB.Execute("UPDATE (Catalogue INNER JOIN GRVimport ON Catalogue.Catalogue_Barcode = GRVimport.GRVimport_Barcode) INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID SET GRVimport.GRVimport_Cost = [StockItem_ActualCost] WHERE (((GRVimport.GRVimport_Cost)=0) AND ((Catalogue.Catalogue_Quantity)=1));");

				rs = modRecordSet.getRS(ref "SELECT StockItem.StockItemID, GRVimport.GRVimport_Key, GRVimport.GRVimport_Barcode, StockItem.StockItem_Name, Catalogue.Catalogue_Quantity, GRVimport.GRVimport_Quantity, GRVimport.GRVimport_Cost, GRVimport.GRVimport_Price FROM (GRVimport INNER JOIN Catalogue ON GRVimport.GRVimport_Barcode = Catalogue.Catalogue_Barcode) INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID WHERE (((StockItem.StockItem_Disabled)=0) AND ((StockItem.StockItem_Discontinued)=0));");
				while (!(rs.EOF)) {
					lListitem = lvImport.Items.Add("x" + rs.Fields("GRVimport_Key").Value, rs.Fields("GRVimport_Barcode").Value + "", "");
					if (lListitem.SubItems.Count > 1) {
						lListitem.SubItems[1].Text = rs.Fields("StockItem_Name").Value;
					} else {
						lListitem.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("StockItem_Name").Value));
					}
					if (lListitem.SubItems.Count > 2) {
						lListitem.SubItems[2].Text = rs.Fields("Catalogue_Quantity").Value;
					} else {
						lListitem.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("Catalogue_Quantity").Value));
					}
					if (lListitem.SubItems.Count > 3) {
						lListitem.SubItems[3].Text = rs.Fields("GRVimport_Quantity").Value;
					} else {
						lListitem.SubItems.Insert(3, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("GRVimport_Quantity").Value));
					}
					if (lListitem.SubItems.Count > 4) {
						lListitem.SubItems[4].Text = Strings.FormatNumber(rs.Fields("GRVimport_Cost").Value, 2);
					} else {
						lListitem.SubItems.Insert(4, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("GRVimport_Cost").Value, 2)));
					}
					if (lListitem.SubItems.Count > 5) {
						lListitem.SubItems[5].Text = Strings.FormatNumber(rs.Fields("GRVimport_Price").Value, 2);
					} else {
						lListitem.SubItems.Insert(5, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("GRVimport_Price").Value, 2)));
					}
					if (lListitem.SubItems.Count > 6) {
						lListitem.SubItems[6].Text = rs.Fields("GRVimport_Key").Value;
					} else {
						lListitem.SubItems.Insert(6, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("GRVimport_Key").Value));
					}
					rs.moveNext();
				}
			}

			if (!string.IsNullOrEmpty(Module1.sGRVSales)) {
				tmrAutoGRV.Enabled = true;
			}

			return;
			loadGRV_Error:
			Interaction.MsgBox(Err().Description);
			//Resume Next
			this.Close();
		}


		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdNext_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string sql = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			if (_Frame1_0.Visible) {
				_Frame1_1.Visible = true;
				_Frame1_0.Visible = false;

			} else {
				if (!string.IsNullOrEmpty(DataList1.BoundText)) {
					sql = "INSERT INTO PurchaseOrder ( PurchaseOrder_SupplierID, PurchaseOrder_DayEndID, PurchaseOrder_PersonID, PurchaseOrder_DateCreated, PurchaseOrder_PurchaseOrderStatusID, PurchaseOrder_Reference, PurchaseOrder_AttentionLine ) ";
					sql = sql + "SELECT " + DataList1.BoundText + ", Company.Company_DayEndID, " + modRecordSet.gPersonID + ", Now(), 1, '" + Strings.Format(DateAndTime.Now, "yyyy mmm dd") + " (Import)', '' FROM Company;";
					modRecordSet.cnnDB.Execute(sql, , ADODB.ExecuteOptionEnum.adExecuteNoRecords);
					rs = modRecordSet.getRS(ref "SELECT Max(PurchaseOrder.PurchaseOrderID) AS id FROM PurchaseOrder;");

					this.Close();
					My.MyProject.Forms.frmGRV.Create(rs.Fields("id").Value, true);
				}
			}
		}

		private void DataList1_DblClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdNext_Click(cmdNext, new System.EventArgs());
		}

		private void DataList1_KeyPress(System.Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyCode = 0;
			if (eventArgs.KeyChar == Strings.ChrW(13)) {
				cmdNext_Click(cmdNext, new System.EventArgs());
				KeyCode = 0;
			}
		}

		private void frmGRVimport_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "SELECT DISTINCT SupplierID, Supplier_Name FROM Supplier ORDER BY Supplier_Name");
			//Display the list of Titles in the DataCombo
			DataList1.DataSource = rs;
			DataList1.listField = "Supplier_Name";


			//Bind the DataCombo to the ADO Recordset
			//UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
			DataList1.DataSource = rs;
			DataList1.boundColumn = "SupplierID";

			loadLanguage();
			loadGRV();
		}

		private void tmrAutoGRV_Tick(System.Object eventSender, System.EventArgs eventArgs)
		{
			string sql = null;
			int suppID = 0;
			tmrAutoGRV.Enabled = false;

			ADODB.Recordset rs = default(ADODB.Recordset);

			suppID = 2;
			rs = modRecordSet.getRS(ref "SELECT DISTINCT SupplierID, Supplier_Name FROM Supplier WHERE Supplier_ShippingCode = '" + Module1.HOfficeID + "'");
			if (rs.RecordCount)
				suppID = rs.Fields("SupplierID").Value;
			sql = "INSERT INTO PurchaseOrder ( PurchaseOrder_SupplierID, PurchaseOrder_DayEndID, PurchaseOrder_PersonID, PurchaseOrder_DateCreated, PurchaseOrder_PurchaseOrderStatusID, PurchaseOrder_Reference, PurchaseOrder_AttentionLine ) ";
			sql = sql + "SELECT " + suppID + ", Company.Company_DayEndID, " + modRecordSet.gPersonID + ", Now(), 1, '" + Strings.Format(DateAndTime.Now, "yyyy mmm dd") + " (Import)', '' FROM Company;";
			modRecordSet.cnnDB.Execute(sql, , ADODB.ExecuteOptionEnum.adExecuteNoRecords);
			rs = modRecordSet.getRS(ref "SELECT Max(PurchaseOrder.PurchaseOrderID) AS id FROM PurchaseOrder;");

			this.Close();
			My.MyProject.Forms.frmGRV.Create(rs.Fields("id").Value, true);
		}
	}
}
