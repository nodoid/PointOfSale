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
using Microsoft.VisualBasic.PowerPacks;
namespace _4PosBackOffice.NET
{
	internal partial class frmOrderWizard : System.Windows.Forms.Form
	{
		private void loadLanguage()
		{

			//frmOrderWizard = No Code   [Stock Re-Order Wizard]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmOrderWizard.Caption = rsLang("LanguageLayoutLnk_Description"): frmOrderWizard.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_0 = No Code           [Day End Selection Criteria]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_1 = No Code           [Applied Filter]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1 = No Code           [Affected Stock Items]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2138;
			//Build|Checked
			if (modRecordSet.rsLang.RecordCount){cmdBuild.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdBuild.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1006;
			//Filter|Checked
			if (modRecordSet.rsLang.RecordCount){cmdFilter.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdFilter.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2464;
			//Update|Checked
			if (modRecordSet.rsLang.RecordCount){cmdUpdate.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdUpdate.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmOrderWizard.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void buildMinMax()
		{
			string db = null;

			string sql = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Connection lConn = default(ADODB.Connection);
			ADODB.Recordset rsData = default(ADODB.Recordset);
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			modRecordSet.cnnDB.Execute("DELETE MinMaxStockItemLnk.* FROM MinMaxStockItemLnk;");
			//    sql = "INSERT INTO MinMaxStockItemLnk (MinMaxStockItemLnk_MinMaxID, MinMaxStockItemLnk_StockItemID, MinMaxStockItemLnk_Minimum, MinMaxStockItemLnk_Maximum, MinMaxStockItemLnk_Disabled, MinMaxStockItemLnk_Average) SELECT TOP 100 PERCENT 1, StockItem.StockItemID, 0, 0, 0, 0 FROM MinMaxStockItemLnk RIGHT OUTER JOIN StockItem ON MinMaxStockItemLnk.MinMaxStockItemLnk_StockItemID = StockItem.StockItemID Where (MinMaxStockItemLnk.MinMaxStockItemLnk_StockItemID Is Null)"
			modRecordSet.cnnDB.Execute("INSERT INTO MinMaxStockItemLnk ( MinMaxStockItemLnk_MinMaxID, MinMaxStockItemLnk_StockItemID, MinMaxStockItemLnk_Minimum, MinMaxStockItemLnk_Maximum, MinMaxStockItemLnk_Disabled, MinMaxStockItemLnk_Average ) SELECT 1, StockItem.StockItemID, 0, 0, 0, 0 FROM StockItem;");


			//    cnnDB.Execute "UPDATE MinMaxStockItemLnk SET MinMaxStockItemLnk.MinMaxStockItemLnk_Minimum = 0, MinMaxStockItemLnk.MinMaxStockItemLnk_Average = 0 WHERE (((MinMaxStockItemLnk.MinMaxStockItemLnk_MinMaxID)=1));"
			rs = modRecordSet.getRS(ref "SELECT DISTINCT Company.Company_MonthEndID, DayEnd.DayEnd_MonthEndID From dayEnd, Company WHERE (((DayEnd.DayEndID)>=" + My.MyProject.Forms.frmOrderWizardFilter.gDayEndStart + " And (DayEnd.DayEndID)<=" + My.MyProject.Forms.frmOrderWizardFilter.gDayEndEnd + "));");
			while (!(rs.EOF)) {
				if (rs.Fields("Company_MonthEndID").Value == rs.Fields("DayEnd_MonthEndID").Value) {
					db = "pricing.mdb";
				} else {
					db = "month" + rs.Fields("DayEnd_MonthEndID").Value + ".mdb";
				}
				lConn = modRecordSet.openConnectionInstance(ref Convert.ToString(db));
				if (lConn == null) {
				} else {
					lConn.Execute("UPDATE DayEndStockItemLnk INNER JOIN MinMaxStockItemLnk ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = MinMaxStockItemLnk.MinMaxStockItemLnk_StockItemID SET MinMaxStockItemLnk.MinMaxStockItemLnk_Average = [MinMaxStockItemLnk_Average]+[DayEndStockItemLnk_QuantitySales] WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)>=" + My.MyProject.Forms.frmOrderWizardFilter.gDayEndStart + " And (DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)<=" + My.MyProject.Forms.frmOrderWizardFilter.gDayEndEnd + "));");
					lConn.Execute("UPDATE StockBreakTransaction INNER JOIN MinMaxStockItemLnk ON StockBreakTransaction.StockBreakTransaction_ParentID = MinMaxStockItemLnk.MinMaxStockItemLnk_StockItemID SET MinMaxStockItemLnk.MinMaxStockItemLnk_Average = [MinMaxStockItemLnk_Average]+[StockBreakTransaction_MoveQuantity] WHERE (((StockBreakTransaction.StockBreakTransaction_DayEndID)>=" + My.MyProject.Forms.frmOrderWizardFilter.gDayEndStart + " And (StockBreakTransaction.StockBreakTransaction_DayEndID)<=" + My.MyProject.Forms.frmOrderWizardFilter.gDayEndEnd + "));");
					lConn.Execute("UPDATE StockBreakTransaction INNER JOIN MinMaxStockItemLnk ON StockBreakTransaction.StockBreakTransaction_ChildID = MinMaxStockItemLnk.MinMaxStockItemLnk_StockItemID SET MinMaxStockItemLnk.MinMaxStockItemLnk_Average = [MinMaxStockItemLnk_Average]-([StockBreakTransaction_MoveQuantity]*[StockBreakTransaction_Quantity]) WHERE (((StockBreakTransaction.StockBreakTransaction_DayEndID)>=" + My.MyProject.Forms.frmOrderWizardFilter.gDayEndStart + " And (StockBreakTransaction.StockBreakTransaction_DayEndID)<=" + My.MyProject.Forms.frmOrderWizardFilter.gDayEndEnd + "));");

				}
				rs.moveNext();
			}
			modRecordSet.cnnDB.Execute("UPDATE MinMaxStockItemLnk SET MinMaxStockItemLnk.MinMaxStockItemLnk_Average = [MinMaxStockItemLnk_Average]/" + Convert.ToDouble(My.MyProject.Forms.frmOrderWizardFilter.gDayEndEnd) - My.MyProject.Forms.frmOrderWizardFilter.gDayEndStart + 1 + ";");
			modRecordSet.cnnDB.Execute("UPDATE MinMaxStockItemLnk SET MinMaxStockItemLnk.MinMaxStockItemLnk_Minimum = [MinMaxStockItemLnk_Average]*" + My.MyProject.Forms.frmOrderWizardFilter.txtDays.Text + ";");


			modRecordSet.cnnDB.Execute("UPDATE MinMaxStockItemLnk INNER JOIN MinMax ON MinMaxStockItemLnk.MinMaxStockItemLnk_MinMaxID = MinMax.MinMaxID SET MinMaxStockItemLnk.MinMaxStockItemLnk_Minimum = [MinMax]![MinMax_Minimum] WHERE (((MinMaxStockItemLnk.MinMaxStockItemLnk_Minimum)<[MinMax]![MinMax_Minimum]));");
			modRecordSet.cnnDB.Execute("DELETE StockItem.StockItem_Disabled, MinMaxStockItemLnk.* FROM MinMaxStockItemLnk INNER JOIN StockItem ON MinMaxStockItemLnk.MinMaxStockItemLnk_StockItemID = StockItem.StockItemID WHERE (((StockItem.StockItem_Disabled)<>0));");
			modRecordSet.cnnDB.Execute("DELETE StockItem.StockItem_Disabled, MinMaxStockItemLnk.* FROM MinMaxStockItemLnk INNER JOIN StockItem ON MinMaxStockItemLnk.MinMaxStockItemLnk_StockItemID = StockItem.StockItemID WHERE (((StockItem.StockItem_Discontinued)<>0));");
			modRecordSet.cnnDB.Execute("UPDATE MinMaxStockItemLnk INNER JOIN StockItem ON MinMaxStockItemLnk.MinMaxStockItemLnk_StockItemID = StockItem.StockItemID SET MinMaxStockItemLnk.MinMaxStockItemLnk_Disabled = 1 WHERE (((StockItem.StockItem_OrderDynamic)<>0));");
			modRecordSet.cnnDB.Execute("UPDATE MinMaxStockItemLnk INNER JOIN StockItem ON MinMaxStockItemLnk.MinMaxStockItemLnk_StockItemID = StockItem.StockItemID SET MinMaxStockItemLnk.MinMaxStockItemLnk_Minimum = [StockItem]![StockItem_MinimumStock] WHERE (((MinMaxStockItemLnk.MinMaxStockItemLnk_Disabled)<>0));");

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
		}

		private void cmdBuild_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string sql = null;
			sql = "DELETE FROM MinMaxStockItemLnk WHERE MinMaxStockItemLnk_MinMaxID = 1";
			modRecordSet.cnnDB.Execute(sql);
			buildMinMax();
			sql = "UPDATE MinMaxStockItemLnk INNER JOIN StockItem ON MinMaxStockItemLnk.MinMaxStockItemLnk_StockItemID = StockItem.StockItemID SET MinMaxStockItemLnk.MinMaxStockItemLnk_Disabled = True WHERE (((MinMaxStockItemLnk.MinMaxStockItemLnk_MinMaxID)=1) AND ((StockItem.StockItem_OrderDynamic)=True));";
			modRecordSet.cnnDB.Execute(sql);
			sql = "UPDATE MinMaxStockItemLnk INNER JOIN StockItem ON MinMaxStockItemLnk.MinMaxStockItemLnk_StockItemID = StockItem.StockItemID SET MinMaxStockItemLnk.MinMaxStockItemLnk_Disabled = True WHERE (((MinMaxStockItemLnk.MinMaxStockItemLnk_MinMaxID)=1) AND ((StockItem.StockItem_Disabled)=True));";
			modRecordSet.cnnDB.Execute(sql);
			sql = "UPDATE MinMaxStockItemLnk INNER JOIN StockItem ON MinMaxStockItemLnk.MinMaxStockItemLnk_StockItemID = StockItem.StockItemID SET MinMaxStockItemLnk.MinMaxStockItemLnk_Disabled = True WHERE (((MinMaxStockItemLnk.MinMaxStockItemLnk_MinMaxID)=1) AND ((StockItem.StockItem_Discontinued)=True));";
			modRecordSet.cnnDB.Execute(sql);
			GetData();
		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdFilter_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			frmOrderWizardFilter form = null;
			form.Show();
			lblDayEnd.Text = My.MyProject.Forms.frmOrderWizardFilter.lblDayEnd.Text;
			lblFilter.Text = My.MyProject.Forms.frmOrderWizardFilter.lblFilter.Text;
			buildMinMax();
			GetData();
		}

		private void GetData()
		{
			string sql = null;
			string lFilter = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			System.Windows.Forms.ListViewItem lvItem = null;
			sql = "SELECT TOP 100 PERCENT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_MinimumStock, StockItem.StockItem_OrderQuantity, StockItem.StockItem_OrderRounding, StockItem.StockItem_Quantity, StockItem.StockItem_ListCost, MinMaxStockItemLnk.MinMaxStockItemLnk_Minimum, MinMaxStockItemLnk.MinMaxStockItemLnk_Disabled, MinMaxStockItemLnk.MinMaxStockItemLnk_Average FROM MinMaxStockItemLnk INNER JOIN StockItem ON MinMaxStockItemLnk.MinMaxStockItemLnk_StockItemID = StockItem.StockItemID  ";
			lFilter = My.MyProject.Forms.frmOrderWizardFilter.gFilterSQL;
			if (string.IsNullOrEmpty(lFilter)) {
				lFilter = " WHERE ";
			} else {
				lFilter = lFilter + " AND ";
			}
			lFilter = lFilter + "(MinMaxStockItemLnk.MinMaxStockItemLnk_MinMaxID = 1) AND (StockItem_Discontinued = 0) AND MinMaxStockItemLnk.MinMaxStockItemLnk_Disabled=0 ";
			sql = sql + lFilter;
			sql = sql + " ORDER BY StockItem.StockItem_Name";

			rs = modRecordSet.getRS(ref sql);
			lvData.Items.Clear();
			while (!(rs.EOF)) {
				lvItem = lvData.Items.Add("K" + rs.Fields("StockItemID").Value, rs.Fields("StockItem_Name").Value, "");
				lvItem.Checked = rs.Fields("MinMaxStockItemLnk_Disabled").Value;
				if (lvItem.SubItems.Count > 1) {
					lvItem.SubItems[1].Text = Strings.FormatNumber(rs.Fields("StockItem_ListCost").Value, 2);
				} else {
					lvItem.SubItems.Insert(1, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("StockItem_ListCost").Value, 2)));
				}
				if (lvItem.SubItems.Count > 2) {
					lvItem.SubItems[2].Text = rs.Fields("StockItem_Quantity").Value;
				} else {
					lvItem.SubItems.Insert(2, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("StockItem_Quantity").Value));
				}
				if (lvItem.SubItems.Count > 3) {
					lvItem.SubItems[3].Text = rs.Fields("StockItem_OrderRounding").Value + "x" + rs.Fields("StockItem_OrderQuantity").Value;
				} else {
					lvItem.SubItems.Insert(3, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("StockItem_OrderRounding").Value + "x" + rs.Fields("StockItem_OrderQuantity").Value));
				}
				if (lvItem.SubItems.Count > 4) {
					lvItem.SubItems[4].Text = rs.Fields("StockItem_MinimumStock").Value;
				} else {
					lvItem.SubItems.Insert(4, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("StockItem_MinimumStock").Value));
				}
				if (lvItem.SubItems.Count > 5) {
					lvItem.SubItems[5].Text = rs.Fields("MinMaxStockItemLnk_Minimum").Value;
				} else {
					lvItem.SubItems.Insert(5, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, rs.Fields("MinMaxStockItemLnk_Minimum").Value));
				}
				if (lvItem.SubItems.Count > 6) {
					lvItem.SubItems[6].Text = Strings.FormatNumber(rs.Fields("MinMaxStockItemLnk_Average").Value, 4);
				} else {
					lvItem.SubItems.Insert(6, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("MinMaxStockItemLnk_Average").Value, 4)));
				}
				rs.moveNext();
			}
		}


		private void cmdUpdate_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string sql = null;
			int lKey = 0;
			int x = 0;
			string lFilter = null;

			lFilter = My.MyProject.Forms.frmOrderWizardFilter.gFilterSQL;
			if (string.IsNullOrEmpty(lFilter)) {
				lFilter = " WHERE ";
			} else {
				lFilter = lFilter + " AND ";
			}
			lFilter = lFilter + "(MinMaxStockItemLnk.MinMaxStockItemLnk_MinMaxID = 1)";
			modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN MinMaxStockItemLnk ON StockItem.StockItemID = MinMaxStockItemLnk.MinMaxStockItemLnk_StockItemID SET StockItem.StockItem_MinimumStock = [MinMaxStockItemLnk]![MinMaxStockItemLnk_Minimum] " + lFilter + ";");
			this.Close();
		}

		private void frmOrderWizard_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void frmOrderWizard_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			System.Windows.Forms.ColumnHeader lvHeader = null;
			//Load(frmOrderWizardFilter)
			lblDayEnd.Text = My.MyProject.Forms.frmOrderWizardFilter.lblDayEnd.Text;
			lblFilter.Text = My.MyProject.Forms.frmOrderWizardFilter.lblFilter.Text;
			lvData.Columns.Add("Name", Convert.ToInt32(sizeConvertors.twipsToPixels(2000, true)), System.Windows.Forms.HorizontalAlignment.Left);
			lvData.Columns.Add("Cost", Convert.ToInt32(sizeConvertors.twipsToPixels(900, true)), System.Windows.Forms.HorizontalAlignment.Right);
			lvData.Columns.Add("X", Convert.ToInt32(sizeConvertors.twipsToPixels(500, true)), System.Windows.Forms.HorizontalAlignment.Right);
			lvData.Columns.Add("Order", Convert.ToInt32(sizeConvertors.twipsToPixels(900, true)), System.Windows.Forms.HorizontalAlignment.Right);
			lvData.Columns.Add("Orginal", Convert.ToInt32(sizeConvertors.twipsToPixels(900, true)), System.Windows.Forms.HorizontalAlignment.Right);
			lvData.Columns.Add("New", Convert.ToInt32(sizeConvertors.twipsToPixels(900, true)), System.Windows.Forms.HorizontalAlignment.Right);
			lvData.Columns.Add("Average", Convert.ToInt32(sizeConvertors.twipsToPixels(1000, true)), System.Windows.Forms.HorizontalAlignment.Right);

			loadLanguage();

			GetData();
		}

		private void frmOrderWizard_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			short x = 0;
			int lWidth = 0;
			for (x = 2; x <= lvData.Columns.Count; x++) {
				lWidth = lWidth + sizeConvertors.pixelToTwips(lvData.Columns[x].Width, true);
			}
			lvData.Columns[1].Width = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(lvData.Width, true) - lWidth - 320, true);
		}

		private void frmOrderWizard_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			My.MyProject.Forms.frmOrderWizardFilter.Close();
		}

		private void lvData_ItemCheck(System.Object eventSender, System.Windows.Forms.ItemCheckEventArgs eventArgs)
		{
			System.Windows.Forms.ListViewItem Item = lvData.Items[eventArgs.Index];
			string sql = null;
			int lKey = 0;
			lKey = Convert.ToInt32(Strings.Mid(Item.Name, 2));

			sql = "UPDATE MinMaxStockItemLnk SET MinMaxStockItemLnk_Disabled = " + Convert.ToInt16(Item.Checked) + " Where (MinMaxStockItemLnk_MinMaxID = 1) And (MinMaxStockItemLnk_StockItemID = " + lKey + ")";
			modRecordSet.cnnDB.Execute(sql);
		}

		private void lvData_ItemClick(System.Windows.Forms.ListViewItem Item)
		{
			string sql = null;
			int lKey = 0;
			lKey = Convert.ToInt32(Strings.Mid(Item.Name, 2));

			//UPGRADE_WARNING: Lower bound of collection Item has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			this.Tag = lKey + "|" + Item.Text + "|" + Item.SubItems[1].Text + "|" + Strings.Split(Item.SubItems[3].Text, "x")[0] + "|" + Item.SubItems[4].Text;
			if (lKey > 0) {
			} else {
				return;
			}
			My.MyProject.Forms.frmOrderItemQuick.ShowDialog();

			GetData();
		}
	}
}
