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
	internal partial class frmExportProductPerfomace : System.Windows.Forms.Form
	{

		List<RadioButton> optType = new List<RadioButton>();
		private void loadLanguage()
		{

			//NOTE: Caption has a spelling mistake!!!
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2469;
			//Export Product Performance
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2471;
			//Export Options|Checked
			if (modRecordSet.rsLang.RecordCount){_Frame1_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_Frame1_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2152;
			//Normal Item Listing|Checked
			if (modRecordSet.rsLang.RecordCount){_optType_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_optType_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2153;
			//Items Per Group|Checked
			if (modRecordSet.rsLang.RecordCount){_optType_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_optType_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2154;
			//Group Totals|Checked
			if (modRecordSet.rsLang.RecordCount){_optType_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_optType_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1173;
			//Group On|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2477;
			//Export Sort Options|Checked
			if (modRecordSet.rsLang.RecordCount){_Frame1_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_Frame1_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2158;
			//Sort Field|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2159;
			//Sort Order|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2480;
			//Export Filter|Checked
			if (modRecordSet.rsLang.RecordCount){_Frame1_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_Frame1_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1006;
			//Filter|Checked
			if (modRecordSet.rsLang.RecordCount){cmdGroup.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdGroup.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2483;
			//Export Now|Checked
			if (modRecordSet.rsLang.RecordCount){cmdLoad.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdLoad.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmExportProductPerfomace.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}
		private void cmdGroup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			int lID = 0;
			modReport.cnnDBreport.Execute("DELETE aftDataItem.* From aftDataItem WHERE (((aftDataItem.ftDataItem_PersonID)=" + modRecordSet.gPersonID + "));");

			modReport.cnnDBreport.Execute("DELETE aftData.* From aftData WHERE (((aftData.ftData_PersonID)=" + modRecordSet.gPersonID + "));");
			modReport.cnnDBreport.Execute("INSERT INTO aftData ( ftData_PersonID, ftData_FieldName, ftData_SQL, ftData_Heading ) SELECT LinkData.LinkData_PersonID, LinkData.LinkData_FieldName, LinkData.LinkData_SQL, LinkData.LinkData_Heading From LinkData WHERE (((LinkData.LinkData_LinkID)=2) AND ((LinkData.LinkData_SectionID)=1) AND ((LinkData.LinkData_PersonID)=" + modRecordSet.gPersonID + "));");
			modReport.cnnDBreport.Execute("INSERT INTO aftDataItem ( ftDataItem_PersonID, ftDataItem_FieldName, ftDataItem_ID ) SELECT LinkDataItem.LinkDataItem_PersonID, LinkDataItem.LinkDataItem_FieldName, LinkDataItem.LinkDataItem_ID From LinkDataItem WHERE (((LinkDataItem.LinkDataItem_LinkID)=2) AND ((LinkDataItem.LinkDataItem_SectionID)=1) AND ((LinkDataItem.LinkDataItem_PersonID)=" + modRecordSet.gPersonID + "));");
			My.MyProject.Forms.frmFilter.Close();
			My.MyProject.Forms.frmFilter.buildCriteria(ref "Sale");
			My.MyProject.Forms.frmFilter.loadFilter(ref "Sale");
			My.MyProject.Forms.frmFilter.buildCriteria(ref "Sale");

			modReport.cnnDBreport.Execute("UPDATE Link SET Link.Link_Name = '" + Strings.Replace(My.MyProject.Forms.frmFilter.gHeading, "'", "''") + "', Link.Link_SQL = '" + Strings.Replace(My.MyProject.Forms.frmFilter.gCriteria, "'", "''") + "' WHERE (((Link.LinkID)=2) AND ((Link.Link_SectionID)=1) AND ((Link.Link_PersonID)=" + modRecordSet.gPersonID + "));");
			modReport.cnnDBreport.Execute("DELETE LinkDataItem.* From LinkDataItem WHERE (((LinkDataItem.LinkDataItem_LinkID)=2) AND ((LinkDataItem.LinkDataItem_SectionID)=1) AND ((LinkDataItem.LinkDataItem_PersonID)=" + modRecordSet.gPersonID + "));");
			modReport.cnnDBreport.Execute("DELETE LinkData.* From LinkData WHERE (((LinkData.LinkData_LinkID)=2) AND ((LinkData.LinkData_SectionID)=1) AND ((LinkData.LinkData_PersonID)=" + modRecordSet.gPersonID + "));");
			modReport.cnnDBreport.Execute("INSERT INTO LinkData ( LinkData_LinkID, LinkData_SectionID, LinkData_PersonID, LinkData_FieldName, LinkData_SQL, LinkData_Heading ) SELECT 2, 1, aftData.ftData_PersonID, aftData.ftData_FieldName, aftData.ftData_SQL, aftData.ftData_Heading From aftData WHERE (((aftData.ftData_PersonID)=" + modRecordSet.gPersonID + "));");
			modReport.cnnDBreport.Execute("INSERT INTO LinkDataItem ( LinkDataItem_LinkID, LinkDataItem_SectionID, LinkDataItem_PersonID, LinkDataItem_FieldName, LinkDataItem_ID ) SELECT 2, 1, aftDataItem.ftDataItem_PersonID, aftDataItem.ftDataItem_FieldName, aftDataItem.ftDataItem_ID From aftDataItem WHERE (((aftDataItem.ftDataItem_PersonID)=" + modRecordSet.gPersonID + "));");
			lblGroup.Text = My.MyProject.Forms.frmFilter.gHeading;
		}
		private void setup()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modReport.getRSreport(ref "SELECT Link.Link_PersonID From Link WHERE (((Link.Link_PersonID)=" + modRecordSet.gPersonID + "));");
			if (rs.BOF | rs.EOF) {
				modReport.cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 1, 1, " + modRecordSet.gPersonID + ", '', '';");
				modReport.cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 2, 1, " + modRecordSet.gPersonID + ", '', '';");
				modReport.cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 1, 2, " + modRecordSet.gPersonID + ", '', '';");
				modReport.cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 2, 2, " + modRecordSet.gPersonID + ", '', '';");
				modReport.cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 1, 3, " + modRecordSet.gPersonID + ", '', '';");
				modReport.cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 2, 3, " + modRecordSet.gPersonID + ", '', '';");
				modReport.cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 3, 3, " + modRecordSet.gPersonID + ", '', '';");
				modReport.cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 4, 3, " + modRecordSet.gPersonID + ", '', '';");
				modReport.cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 5, 3, " + modRecordSet.gPersonID + ", '', '';");
				modReport.cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 6, 3, " + modRecordSet.gPersonID + ", '', '';");
				modReport.cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 7, 3, " + modRecordSet.gPersonID + ", '', '';");
				modReport.cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 8, 3, " + modRecordSet.gPersonID + ", '', '';");
				modReport.cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 9, 3, " + modRecordSet.gPersonID + ", '', '';");
				modReport.cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 10, 3, " + modRecordSet.gPersonID + ", '', '';");
			}

			rs = modReport.getRSreport(ref "SELECT Link.Link_Name From Link WHERE (((Link.LinkID)=2) AND ((Link.Link_SectionID)=1) AND ((Link.Link_PersonID)=" + modRecordSet.gPersonID + "));");
			lblGroup.Text = rs.Fields("Link_Name").Value;
		}
		private void cmdLoad_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string dbText = null;
			string sql = null;
			string stFileName = null;
			string lOrder = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsData = default(ADODB.Recordset);


			//Exporting file...
			string lne = null;
			short n = 0;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();

			switch (this.cmbSortField.SelectedIndex) {
				case 0:
					lOrder = "StockItem_Name";
					break;
				case 1:
					lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]";
					break;
				case 2:
					lOrder = "[exclusiveSum]-[depositSum]";
					break;
				case 3:
					lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]";
					break;
				case 4:
					lOrder = "IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum])";
					break;
				case 5:
					lOrder = "StockList.quantitySum";
					break;

			}

			if (this.cmbSort.SelectedIndex)
				lOrder = lOrder + " DESC";
			lOrder = " ORDER BY " + lOrder;

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

			rs = modReport.getRSreport(ref "SELECT * FROM Link Where LinkID=2 AND Link_SectionID=1");

			if (_optType_0.Checked) {
				sql = "SELECT aStockItem.StockItemID, aStockItem.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem INNER JOIN aStockGroup ON aStockItem.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem.StockItemID ";
			} else {
				sql = "SELECT aStockItem.StockItemID, aStockItem.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem INNER JOIN aStockGroup ON aStockItem.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem.StockItemID ";
				switch (this.cmbGroup.SelectedIndex) {
					case 0:
						sql = Strings.Replace(sql, "StockGroup", "PricingGroup");
						break;
					//Report.txtTitle.SetText "Product Performance - by Pricing Group"
					case 1:
						break;
					//Report.txtTitle.SetText "Product Performance - by Stock Group"
					case 2:
						sql = Strings.Replace(sql, "StockGroup", "Supplier");
						sql = Strings.Replace(sql, "aSupplier", "Supplier");
						break;
					//Report.txtTitle.SetText "Product Performance - by Supplier"
				}
			}

			if (string.IsNullOrEmpty(rs.Fields("Link_SQL").Value)) {
			} else {
				sql = sql + rs.Fields("Link_SQL").Value;
			}

			sql = sql + lOrder;

			string ptbl = null;
			string t_day = null;
			string t_Mon = null;

			if (Strings.Len(Strings.Trim(Conversion.Str(DateAndTime.Day(DateAndTime.Today)))) == 1)
				t_day = "0" + Strings.Trim(Convert.ToString(DateAndTime.Day(DateAndTime.Today)));
			else
				t_day = Convert.ToString(DateAndTime.Day(DateAndTime.Today));
			if (Strings.Len(Strings.Trim(Conversion.Str(DateAndTime.Month(DateAndTime.Today)))) == 1)
				t_Mon = "0" + Strings.Trim(Convert.ToString(DateAndTime.Month(DateAndTime.Today)));
			else
				t_Mon = Conversion.Str(DateAndTime.Month(DateAndTime.Today));

			ptbl = modRecordSet.serverPath + "4POSProd" + Strings.Trim(Convert.ToString(DateAndTime.Year(DateAndTime.Today))) + Strings.Trim(t_Mon) + Strings.Trim(t_day);

			if (fso.FileExists(ptbl + ".csv"))
				fso.DeleteFile((ptbl + ".csv"));

			FileSystem.FileOpen(1, ptbl + ".csv", OpenMode.Output);
			//Open serverPath & "ProductPerformace.csv" For Output As #1

			rs = modReport.getRSreport(ref sql);
			//Write Out CSV
			if (rs.BOF | rs.EOF) {
				Interaction.MsgBox("There are no recods to export, Try Changing Day End date range", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Export Product Performance");
				System.Windows.Forms.Cursor.Current = Cursors.Default;
				return;
			} else {
				//First line as column headings
				for (n = 0; n <= rs.Fields.Count - 1; n++) {
					lne = lne + Strings.Chr(34) + rs.Fields(n).Name + Strings.Chr(34) + ",";
				}

				FileSystem.PrintLine(1, lne);

				while (!rs.EOF) {
					lne = "";
					for (n = 0; n <= rs.Fields.Count - 1; n++) {

						if (rs.Fields(n).Type == dbText) {
							lne = lne + Strings.Chr(34) + rs.Fields(n).Value + Strings.Chr(34) + ",";
						} else {
							lne = lne + rs.Fields(n).Value + ",";
						}
					}
					lne = Strings.Left(lne, Strings.Len(lne) - 1);
					//get rid of last comma
					FileSystem.PrintLine(1, lne);
					rs.moveNext();
				}

				FileSystem.FileClose(1);
				Interaction.MsgBox("Product performance CSV File, was successfully exported to : " + ptbl + ".csv");
			}
			System.Windows.Forms.Cursor.Current = Cursors.Default;


		}
		private void frmExportProductPerfomace_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 27) {
				KeyAscii = 0;
				this.Close();
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
		private void frmExportProductPerfomace_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			optType.AddRange(new RadioButton[] {
				_optType_0,
				_optType_1,
				_optType_2
			});
			loadLanguage();
			setup();
			this.cmbGroup.SelectedIndex = 0;
			this.cmbSort.SelectedIndex = 0;
			this.cmbSortField.SelectedIndex = 0;
		}

		//Handles optType.CheckedChanged
		private void optType_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.Checked) {
				RadioButton opt = new RadioButton();
				opt = (RadioButton)eventSender;
				int Index = GetIndex.GetIndexer(ref opt, ref optType);
				if (Index) {
					cmbGroup.Enabled = true;
				} else {
					cmbGroup.Enabled = false;
				}
				this.chkPageBreak.Enabled = (Index == 1);
			}
		}
	}
}
