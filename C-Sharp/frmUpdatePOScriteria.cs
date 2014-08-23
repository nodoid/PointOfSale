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
	internal partial class frmUpdatePOScriteria : System.Windows.Forms.Form
	{
		const short gUpdateWarnin = 512;
		int gParameters;
		ADODB.Recordset rsBitter;
		string gFilter;
		ADODB.Recordset gRS;
		string gFilterSQL;
		short gSection;
		int gID;
		public List<GroupBox> frmType = new List<GroupBox>();
		List<Button> cmdType = new List<Button>();
		string sLocalQuery;

		private void loadLanguage()
		{

			//frmUpdatePOScriteria = No Code [Selection Criteria for Point Of Sale Update]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmUpdatePOScriteria.Caption = rsLang("LanguageLayoutLnk_Description"): frmUpdatePOScriteria.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label2 = No Code               [You may set the Point Of.......]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label2.Caption = rsLang("LanguageLayoutLnk_Description"): Label2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//frmType(0) = No Code           [Option One (Update POS Changes)]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmType(0).Caption = rsLang("LanguageLayoutLnk_Description"): frmType(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1(0) = No Code            [As you make changes to your.......]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(0).Caption = rsLang("LanguageLayoutLnk_Description"): COMPONENT(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_Label3_0 = No Code            [Click on the "View Update Changes >>" button to continue.]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _Label3_0.Caption = rsLang("LanguageLayoutLnk_Description"): _Label3_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdBuildChanges = No Code      [View and Update Changes >>]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdBuildChanges.Caption = rsLang("LanguageLayoutLnk_Description"): cmdBuildChanges.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//frmType(1) = No Code           [Update POS by a filter]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmType(1).Caption = rsLang("LanguageLayoutLnk_Description"): frmType(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblHeading = No Code           [Using the "Stock Item Selector"...]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblHeading.Caption = rsLang("LanguageLayoutLnk_Description"): lblHeading.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1006;
			//Filter|Checked
			if (modRecordSet.rsLang.RecordCount){cmdNamespace.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdNamespace.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//cmdBuildFilter = No Code       [View and Update Changes >>]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdBuildFilter.Caption = rsLang("LanguageLayoutLnk_Description"): cmdBuildFilter.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//frmType(2) = No Code           [Option Three (Check Data Integrity)]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmType(2).Caption = rsLang("LanguageLayoutLnk_Description"): frmType(2).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1(1) = No Code            [This option will check all your data.......]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1(1).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_Label3_1 = No Code            [Click on the "View and Update Changes >>" button to continue.]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _Label3_1.Caption = rsLang("LanguageLayoutLnk_Description"): _Label3_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdBuildAll = No Code          [View and Update Changes >>]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdBuildAll.Caption = rsLang("LanguageLayoutLnk_Description"): CmdBuildAll.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdType(0) = No Code           [Changes Only]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdType(0).Caption = rsLang("LanguageLayoutLnk_Description"): cmdType(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdType(1) = No Code           [Update by Filter]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdType(1).Caption = rsLang("LanguageLayoutLnk_Description"): cmdType(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdType(2) = No Code           [Update All]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdType(2).Caption = rsLang("LanguageLayoutLnk_Description"): cmdType(2).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmUpdatePOScriteria.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

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
			doSearch();
		}

		private void cmdBuildAll_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			System.Windows.Forms.Application.DoEvents();
			modRecordSet.cnnDB.Execute("DELETE FROM systemStockItemPricing;");
			modRecordSet.cnnDB.Execute("INSERT INTO systemStockItemPricing ( systemStockItemPricing ) SELECT StockItem.StockItemID FROM StockItem;");
			modRecordSet.cnnDB.Execute("UPDATE POSCatalogueChannelLnk INNER JOIN CatalogueChannelLnk ON (POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) SET CatalogueChannelLnk.CatalogueChannelLnk_Price = [POSCatalogueChannelLnk]![POSCatalogueChannelLnk_Price] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_Price)<>[POSCatalogueChannelLnk]![POSCatalogueChannelLnk_Price]));");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			frmUpdateCatalogue formUpdate = null;
			formUpdate.Show();
			frmUpdatePOS formUpdatePOS = null;
			if (gParameters & gUpdateWarnin == 512) {
				formUpdatePOS.Show();
			} else {
				if (My.MyProject.Forms.frmUpdateWarning.loadItem()) {
					formUpdatePOS.Show();
				}
			}
			this.Close();
			//If frmUpdateWarning.loadItem() Then frmUpdatePOS.show 1, Me
		}

		private void cmdBuildChanges_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			System.Windows.Forms.Application.DoEvents();
			modRecordSet.cnnDB.Execute("DELETE FROM systemStockItemPricing;");
			modRecordSet.cnnDB.Execute("INSERT INTO systemStockItemPricing ( systemStockItemPricing ) SELECT tempStockItem.tempStockItemID FROM tempStockItem;");
			modRecordSet.cnnDB.Execute("UPDATE POSCatalogueChannelLnk INNER JOIN CatalogueChannelLnk ON (POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) SET CatalogueChannelLnk.CatalogueChannelLnk_Price = [POSCatalogueChannelLnk]![POSCatalogueChannelLnk_Price] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_Price)<>[POSCatalogueChannelLnk]![POSCatalogueChannelLnk_Price]));");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			frmUpdateCatalogue frmUpdate = null;
			frmUpdatePOS frmPOS = null;
			frmUpdate.Show();

			if (gParameters & gUpdateWarnin == 512) {
				frmPOS.Show();
			} else {
				if (My.MyProject.Forms.frmUpdateWarning.loadItem())
					frmPOS.Show();
			}
			this.Close();
			//If frmUpdateWarning.loadItem() Then frmUpdatePOS.show 1, Me
		}

		private void cmdBuildFilter_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			System.Windows.Forms.Application.DoEvents();
			modRecordSet.cnnDB.Execute("DELETE FROM systemStockItemPricing;");
			modRecordSet.cnnDB.Execute("INSERT INTO systemStockItemPricing ( systemStockItemPricing ) SELECT StockItem.StockItemID From StockItem " + gFilterSQL);
			modRecordSet.cnnDB.Execute("UPDATE POSCatalogueChannelLnk INNER JOIN CatalogueChannelLnk ON (POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) SET CatalogueChannelLnk.CatalogueChannelLnk_Price = [POSCatalogueChannelLnk]![POSCatalogueChannelLnk_Price] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_Price)<>[POSCatalogueChannelLnk]![POSCatalogueChannelLnk_Price]));");
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			//frmUpdateCatalogue.show 1, Me
			frmUpdatePOS frmPOS = null;
			if (gParameters & gUpdateWarnin == 512) {
				frmPOS.Show();
			} else {
				if (My.MyProject.Forms.frmUpdateWarning.loadItem())
					frmPOS.Show();
			}
			this.Close();
			//If frmUpdateWarning.loadItem() Then frmUpdatePOS.show 1, Me
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


		private void cmdType_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			Button btn = new Button();
			btn = (Button)eventSender;
			int Index = GetIndex.GetIndexer(ref btn, ref cmdType);
			int x = 0;
			for (x = 0; x <= frmType.Count; x++) {
				frmType[x].Visible = false;
			}
			frmType[Index].Visible = true;

			if (Index == 2) {
				cmdBuildAll_Click(cmdBuildAll, new System.EventArgs());
				My.MyProject.Forms.frmUpdatePOS.AutomaticPOSUpdate();
			}

		}
		private void frmUpdatePOScriteria_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		public void frmUpdatePOScriteria_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			short x = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			frmType.AddRange(new GroupBox[] {
				_frmType_0,
				_frmType_1,
				_frmType_2
			});
			cmdType.AddRange(new Button[] {
				_cmdType_0,
				_cmdType_1,
				_cmdType_2
			});
			Button bt = new Button();
			foreach (Button bt_loopVariable in cmdType) {
				bt = bt_loopVariable;
				bt.Click += cmdType_Click;
			}
			sLocalQuery = "";
			rsBitter = modRecordSet.getRS(ref "SELECT * FROM Company");
			gParameters = Convert.ToInt32(0 + rsBitter.Fields("Company_DayEndBit").Value);

			loadLanguage();

			for (x = 0; x <= frmType.Count; x++) {
				frmType[x].Top = frmType[0].Top;
				frmType[x].Left = frmType[0].Left;
				frmType[x].Visible = false;
			}
			rs = modRecordSet.getRS(ref "DISPLAY_StockDuplicateCodes");

			if (rs.BOF | rs.EOF) {
				gFilter = "stockitem";
				getNamespace();
			} else {
				rs.Close();
				cmdBarcodes_Click();
				rs = modRecordSet.getRS(ref "DISPLAY_StockDuplicateCodes");
				if (rs.BOF | rs.EOF) {
					cmdBarcodes_Click();

					gFilter = "stockitem";
					getNamespace();
				} else {
					tmrDuplicate.Enabled = true;
				}
			}

			//deposit query changed by markus for 'The Liq Company' problem - 20 June 2012
			//    If rs.State Then rs.Close
			//    'Set rs = getRS("SELECT Deposit.DepositID, Deposit.Deposit_Name, Deposit.Deposit_ReceiptName, Deposit.Deposit_Key, Deposit.Deposit_Quantity, Deposit.Deposit_UnitPrice1, Deposit.Deposit_CasePrice1, Deposit.Deposit_UnitPrice2, Deposit.Deposit_CasePrice2, Vat.Vat_Amount, Deposit.Deposit_Key FROM Deposit INNER JOIN Vat ON Deposit.Deposit_VatID = Vat.VatID WHERE (((Deposit.Deposit_UnitPrice1)=0) AND ((Deposit.Deposit_Key)='') AND ((Deposit.Deposit_Disabled)<>True)) OR (((Deposit.Deposit_CasePrice1)=0) AND ((Deposit.Deposit_Key)='') AND ((Deposit.Deposit_Disabled)<>True)) OR (((Deposit.Deposit_UnitPrice1)=0) AND ((Deposit.Deposit_Key)Is Null) AND ((Deposit.Deposit_Disabled)<>True)) OR (((Deposit.Deposit_CasePrice1)=0) AND ((Deposit.Deposit_Key)Is Null) AND ((Deposit.Deposit_Disabled)<>True)) ORDER BY Deposit.Deposit_Key;")
			//    Set rs = getRS("SELECT Deposit.DepositID, Deposit.Deposit_Name, Deposit.Deposit_ReceiptName, Deposit.Deposit_Key, Deposit.Deposit_Quantity, Deposit.Deposit_UnitPrice1, Deposit.Deposit_CasePrice1, Deposit.Deposit_UnitPrice2, Deposit.Deposit_CasePrice2, Vat.Vat_Amount, Deposit.Deposit_Key FROM Deposit INNER JOIN Vat ON Deposit.Deposit_VatID = Vat.VatID WHERE ((LEFT((Deposit.Deposit_Name),3)<>'Non') AND ((Deposit.Deposit_Key)='') AND ((Deposit.Deposit_UnitPrice1)=0) AND ((Deposit.Deposit_Disabled)<>True)) OR ((LEFT((Deposit.Deposit_Name),3)<>'Non') AND ((Deposit.Deposit_Key)='') AND ((Deposit.Deposit_CasePrice1)=0) AND ((Deposit.Deposit_Disabled)<>True)) OR ((LEFT((Deposit.Deposit_Name),3)<>'Non') AND ((Deposit.Deposit_Key) Is Null) AND ((Deposit.Deposit_UnitPrice1)=0) AND ((Deposit.Deposit_Disabled)<>True)) OR ((LEFT((Deposit.Deposit_Name),3)<>'Non') AND ((Deposit.Deposit_Key) Is Null) AND ((Deposit.Deposit_CasePrice1)=0) AND ((Deposit.Deposit_Disabled)<>True)) ORDER BY Deposit.Deposit_Key;")
			//    If rs.RecordCount Then
			//        MsgBox "The following Deposit(s) cannot have '0.00' Inclusive Price OR does not have valid 'POS Quick Key'. Please assign a value to the deposit before an update will be allowed."
			//        sLocalQuery = "SELECT * FROM Deposit WHERE (((Deposit.Deposit_UnitPrice1)=0) AND ((Deposit.Deposit_Key)='') AND ((Deposit.Deposit_Disabled)<>True)) OR (((Deposit.Deposit_CasePrice1)=0) AND ((Deposit.Deposit_Key)='') AND ((Deposit.Deposit_Disabled)<>True)) OR (((Deposit.Deposit_UnitPrice1)=0) AND ((Deposit.Deposit_Key)Is Null) AND ((Deposit.Deposit_Disabled)<>True)) OR (((Deposit.Deposit_CasePrice1)=0) AND ((Deposit.Deposit_Key)Is Null) AND ((Deposit.Deposit_Disabled)<>True)) ORDER BY Deposit.Deposit_Key;"
			//        tmrDeposit.Enabled = True
			//        Exit Sub
			//    End If
			if (rs.State)
				rs.Close();
			rs = modRecordSet.getRS(ref "SELECT Deposit.DepositID, Deposit.Deposit_Name, Deposit.Deposit_ReceiptName, Deposit.Deposit_Key, Deposit.Deposit_Quantity, Deposit.Deposit_UnitPrice1, Deposit.Deposit_CasePrice1, Deposit.Deposit_UnitPrice2, Deposit.Deposit_CasePrice2, Vat.Vat_Amount, Deposit.Deposit_Key FROM Deposit INNER JOIN Vat ON Deposit.Deposit_VatID = Vat.VatID WHERE (((Deposit.Deposit_Key)='') AND ((Deposit.Deposit_Disabled)<>True)) OR (((Deposit.Deposit_Key)Is Null) AND ((Deposit.Deposit_Disabled)<>True)) ORDER BY Deposit.Deposit_Key;");
			if (rs.RecordCount) {
				Interaction.MsgBox("The following Deposit(s) does not have valid 'POS Quick Key'. Please assign a value to the deposit before an update will be allowed.");
				sLocalQuery = "SELECT * FROM Deposit WHERE (((Deposit.Deposit_Key)='') AND ((Deposit.Deposit_Disabled)<>True)) OR (((Deposit.Deposit_Key)Is Null) AND ((Deposit.Deposit_Disabled)<>True)) ORDER BY Deposit.Deposit_Key;";
				tmrDeposit.Enabled = true;
				return;
			}

			if (rs.State)
				rs.Close();
			rs = modRecordSet.getRS(ref "SELECT Deposit.* FROM Deposit INNER JOIN [Set] ON Deposit.DepositID = Set.Set_DepositID WHERE (((Deposit.Deposit_Disabled)=True) AND ((Set.Set_Disabled)=False));");
			if (rs.RecordCount) {
				Interaction.MsgBox("The following Deposit(s) are disabled but currently in use in a Stock Set(s). Please remove the deposit from the Stock Set(s) before an update will be allowed.");
				sLocalQuery = "SELECT Deposit.* FROM Deposit INNER JOIN [Set] ON Deposit.DepositID = Set.Set_DepositID WHERE (((Deposit.Deposit_Disabled)=True) AND ((Set.Set_Disabled)=False));";
				tmrDeposit.Enabled = true;
				return;
			}


			if (modApplication.blMEndUpdatePOS == true) {
				tmrMEndUpdatePOS.Enabled = true;
				//cmdType_Click (2)
			}

		}

		private void tmrDeposit_Tick(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (string.IsNullOrEmpty(sLocalQuery)) {
				tmrDeposit.Enabled = false;
			} else {
				tmrDeposit.Enabled = false;
				modApplication.report_Deposits_Query(ref sLocalQuery);
				this.Close();
			}
		}


		private void frmUpdatePOScriteria_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			//    gRS.Close
		}


		private void doSearch()
		{
			ListControl DataList1 = null;
			TextBox txtSearch = new TextBox();
			return;
			string sql = null;
			string lString = null;
			lString = Strings.Trim(txtSearch.Text);
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");


			//UPGRADE_WARNING: Couldn't resolve default property of object txtSearch.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(Strings.Trim(txtSearch.Text))) {
				lString = gFilterSQL;
			} else {
				lString = "(StockItem_Name LIKE '%" + Strings.Replace(lString, " ", "%' AND StockItem_Name LIKE '%") + "%')";
				if (string.IsNullOrEmpty(gFilterSQL)) {
					lString = " WHERE " + lString;
				} else {
					lString = gFilterSQL + " AND " + lString;
				}
			}
			gRS = modRecordSet.getRS(ref "SELECT DISTINCT StockItemID, StockItem_Name FROM StockItem " + lString + " ORDER BY StockItem_Name");
			//Display the list of Titles in the DataCombo
			DataList1.DataBindings.Add(gRS);
			//DataList1.listField = "StockItem_Name"

			//Bind the DataCombo to the ADO Recordset
			DataList1.DataSource = gRS;
			//DataList1.boundColumn = "StockItemID"

		}

		private void tmrDuplicate_Tick(System.Object eventSender, System.EventArgs eventArgs)
		{
			modApplication.report_StockItemDuplicateCodes();
			this.Close();
		}

		private short doCheckSum(ref string Value)
		{
			short functionReturnValue = 0;
			short lAmount = 0;
			string code = null;
			short i = 0;
			Value = Strings.Replace(Value, " ", "");
			Value = Strings.Replace(Value, " ", "");
			Value = Strings.Replace(Value, " ", "");
			Value = Strings.Replace(Value, " ", "");
			Value = Strings.Replace(Value, " ", "");
			Value = Strings.Replace(Value, " ", "");
			Value = Strings.Replace(Value, " ", "");
			if (Information.IsNumeric(Value)) {
				lAmount = 0;
				for (i = 0; i <= Strings.Len(Value) - 1; i++) {
					code = Strings.Left(Value, i);
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
				functionReturnValue = lAmount == Convert.ToInt16(Strings.Right(Value, 1));
			} else {
				functionReturnValue = false;
			}
			return functionReturnValue;
		}


		private void cmdBarcodes_Click()
		{
			int x = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			string lCode = null;
			string lID = null;
			string lQuantity = null;
			bool changeCode = false;
			return;
			//    If id = 0 Then
			//        cnnDB.Execute "UPDATE Catalogue SET Catalogue.Catalogue_Barcode = ""0"" WHERE (((IsNumeric([Catalogue_Barcode]))<>0));"
			modRecordSet.cnnDB.Execute("UPDATE Catalogue INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID SET Catalogue.Catalogue_Barcode = '0' WHERE (((Left([Catalogue_Barcode],3))='888') AND ((StockItem.StockItem_BrandItemID)>0));");

			for (x = 1; x <= 15; x++) {
				modRecordSet.cnnDB.Execute("UPDATE Catalogue SET Catalogue.Catalogue_Barcode = Mid([Catalogue_Barcode],2,999) WHERE (((Left([Catalogue_Barcode],1))=\"0\"));");
			}
			rs = modRecordSet.getRS(ref "SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, Catalogue.Catalogue_Barcode From Catalogue;");
			//        Set rs = getRS("SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, Catalogue.Catalogue_Barcode From Catalogue WHERE Catalogue.Catalogue_Barcode = '0';")
			//    Else
			//        Set rs = getRS("SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, Catalogue.Catalogue_Barcode From Catalogue WHERE (((Catalogue.Catalogue_StockItemID)=" & id & "));")
			//    End If
			if (rs.RecordCount) {
				rs.MoveFirst();
				while (!(rs.EOF)) {
					changeCode = true;
					lCode = rs.Fields("Catalogue_Barcode").Value;
					if (doCheckSum(ref lCode)) {
						if (Strings.Len(lCode) > 5) {
							changeCode = false;
						}
					}
					if (changeCode) {
						lID = rs.Fields("Catalogue_StockItemID").Value;
						lQuantity = rs.Fields("Catalogue_Quantity").Value;
						lCode = lID + "0" + lQuantity;
						lCode = "888" + Strings.Right(new string("0", 9) + lCode + "0", 9);
						lCode = modApplication.addCheckSum(ref lCode);
						modRecordSet.cnnDB.Execute("UPDATE Catalogue SET Catalogue_Barcode = '" + Strings.Replace(lCode, "'", "''") + "' WHERE Catalogue_StockItemID = " + lID + " AND Catalogue_Quantity = " + lQuantity);
					}
					rs.moveNext();
				}
			}
		}

		private void tmrMEndUpdatePOS_Tick(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (modApplication.blMEndUpdatePOS == true) {
				tmrMEndUpdatePOS.Enabled = false;
				if (modApplication.blChangeOnlyUpdatePOS == true) {
					cmdBuildChanges_Click(cmdBuildChanges, new System.EventArgs());
				} else {
					cmdType_Click(cmdType[2], new System.EventArgs());
				}
			}
		}
	}
}
