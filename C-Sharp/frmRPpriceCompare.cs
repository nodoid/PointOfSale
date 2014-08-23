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
	internal partial class frmRPpriceCompare : System.Windows.Forms.Form
	{
		string gFilter;
		ADODB.Recordset gRS;
		string gFilterSQL;

		private void loadLanguage()
		{

			//frmRPpriceCompare = No Code    [Setup Price Comparison Report]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmRPpriceCompare.Caption = rsLang("LanguageLayoutLnk_Description"): frmRPpriceCompare.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblHeading = No Code           [Using the "Stock Item Selector"...]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblHeading.Caption = rsLang("LanguageLayoutLnk_Description"): lblHeading.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1006;
			//Filter|Checked
			if (modRecordSet.rsLang.RecordCount){cmdNamespace.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdNamespace.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lbl_0 = No Code               [For which Sale Channel]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0
			//If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkDifferent = No Code         [Only show stock item where prices are different]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkDifferent.Caption = rsLang("LanguageLayoutLnk_Description"): chkDifferent.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkQuantity = No Code          [Show stock Items where quantity is exactly]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkQuantity.Caption = rsLang("LanguageLayoutLnk_Description"): chkQuantity.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkAbove = No Code             [Show stock Items where exit price is above]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkAbove.Caption = rsLang("LanguageLayoutLnk_Description"): chkAbove.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkBelow = No Code             [Show stock Items where exit price below]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkBelow.Caption = rsLang("LanguageLayoutLnk_Description"): chkBelow.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1085;
			//Print|Checked
			if (modRecordSet.rsLang.RecordCount){cmdPrint.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPrint.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmRPpriceCompare.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}


		private void buildDataControls()
		{
			doDataControl(ref (this.cmbChannel), ref "SELECT ChannelID, Channel_Name FROM Channel ORDER BY ChannelID", ref "ChannelID", ref "Channel_Name");
			doDataControl(ref (this.cmbShrink), ref "SELECT DISTINCT ShrinkItem.ShrinkItem_Quantity From ShrinkItem ORDER BY ShrinkItem.ShrinkItem_Quantity;", ref "ShrinkItem_Quantity", ref "ShrinkItem_Quantity");
			cmbChannel.BoundText = Convert.ToString(1);
			cmbShrink.BoundText = Convert.ToString(1);
		}

		private void doDataControl(ref myDataGridView dataControl, ref string sql, ref string boundColumn, ref string listField)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref sql);
			dataControl.DataSource = rs;
			dataControl.boundColumn = boundColumn;
			dataControl.listField = listField;
		}

//UPGRADE_WARNING: Event chkQuantity.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void chkQuantity_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmbShrink.Enabled = chkQuantity.CheckState;
		}

		private void cmbChannel_KeyPress(System.Object eventSender, KeyPressEventArgs eventArgs)
		{
			frmRPpriceCompare_KeyPress(this, new System.Windows.Forms.KeyPressEventArgs(eventArgs.KeyChar));
		}

		private void cmbShrink_KeyPress(System.Object eventSender, KeyPressEventArgs eventArgs)
		{
			frmRPpriceCompare_KeyPress(this, new System.Windows.Forms.KeyPressEventArgs(eventArgs.KeyChar));
		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdNamespace_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmFilter.loadFilter(ref gFilter);
			getNamespace();
		}

		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			doSearch();
		}

		private void frmRPpriceCompare_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			gFilter = "stockitem";
			buildDataControls();

			loadLanguage();
			getNamespace();
		}

		private void frmRPpriceCompare_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case System.Windows.Forms.Keys.Escape:
					this.Close();
					KeyAscii = 0;
					break;
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void getNamespace()
		{
			if (string.IsNullOrEmpty(gFilter)) {
				this.lblHeading.Text = "";
			} else {
				My.MyProject.Forms.frmFilter.buildCriteria(ref gFilter);
				this.lblHeading.Text = My.MyProject.Forms.frmFilter.gHeading;
			}
			gFilterSQL = My.MyProject.Forms.frmFilter.gCriteria;
		}


		private void doSearch()
		{
			string lString = null;
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = default(CrystalDecisions.CrystalReports.Engine.ReportDocument);
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			Report.Load("cryPriceComparison.rpt");
			string lHeading = null;
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtTitle", this.Text);
			Report.SetParameterValue("txtFilter", this.lblHeading.Text);
			rs.Close();
			lString = "((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = " + this.cmbChannel.BoundText + ") And (Catalogue.Catalogue_Disabled <> -1) AND ([Catalogue_Content]<>0)";
			if (string.IsNullOrEmpty(gFilterSQL)) {
				lString = " WHERE " + lString;
			} else {
				lString = gFilterSQL + " AND " + lString;
			}
			if (cmbShrink.Enabled) {
				lString = lString + " AND (Catalogue.Catalogue_Quantity = " + this.cmbShrink.BoundText + ") ";
				lHeading = " and Quantity = " + this.cmbShrink.BoundText;
			}
			if (chkDifferent.CheckState) {
				lString = lString + " AND (([CatalogueChannelLnk_PriceSystem]-[CatalogueChannelLnk_Price])<>0) ";
			}
			if (chkAbove.CheckState) {
				lString = lString + " AND (((1 - (([Catalogue_Content]) * (1 + [vat_amount] / 100)) / [CatalogueChannelLnk_Price]) * 100) > " + this.txtAbove.Text + ") ";
				lHeading = " and Markup > " + this.txtAbove.Text;
			}
			if (chkBelow.CheckState) {
				lString = lString + " AND (((1 - (([Catalogue_Content]) * (1 + [vat_amount] / 100)) / [CatalogueChannelLnk_Price]) * 100) < " + this.txtAbove.Text + ") ";
				lHeading = " and Markup < " + this.txtAbove.Text;
			}

			sql = "SELECT StockItem.StockItem_Name, Catalogue.*, ([Catalogue_Content]+[Catalogue_Deposit])*(1+[vat_amount]/100) AS cost, CatalogueChannelLnk.CatalogueChannelLnk_Location, CatalogueChannelLnk.CatalogueChannelLnk_Markup, CatalogueChannelLnk.CatalogueChannelLnk_PriceOriginal, CatalogueChannelLnk.CatalogueChannelLnk_PriceSystem, CatalogueChannelLnk.CatalogueChannelLnk_Price, [CatalogueChannelLnk_Price]-[CatalogueChannelLnk_PriceSystem] AS difference, 100*(([CatalogueChannelLnk_Price]/(1+([Vat_Amount]/100))-[Catalogue_Deposit])/[Catalogue_Content]-1) AS MarkupPrice, 100*(([CatalogueChannelLnk_PriceSystem]/(1+([Vat_Amount]/100))-[Catalogue_Deposit])/[Catalogue_Content]-1) AS MarkupSystem, (1-(([Catalogue_Content])*(1+[vat_amount]/100))/[CatalogueChannelLnk_Price])*100 AS grossPercentage, ([CatalogueChannelLnk_Price]/([Catalogue_Content]*(1+[vat_amount]/100))-1)*100 AS markupPercentage ";
			sql = sql + "FROM ((StockItem INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity)) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID ";
			sql = sql + lString;
			sql = sql + "ORDER BY StockItem.StockItem_Name, Catalogue.Catalogue_Quantity;";

			Report.SetParameterValue("txtTitle", "Where Sales Channel = " + cmbChannel.CtlText + lHeading);

			rs = modRecordSet.getRS(ref sql);
			//Report.Database.SetDataSource(rs, 3)
			Report.Database.Tables(1).SetDataSource(rs);
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();

		}


		private void txtAbove_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtAbove.Text());
		}

		private void txtAbove_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			modUtilities.MyKeyPressNegative(ref txtAbove, ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtAbove_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtAbove, ref 0);
		}
	}
}
