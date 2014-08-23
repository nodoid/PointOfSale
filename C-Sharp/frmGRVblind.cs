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
	internal partial class frmGRVblind : System.Windows.Forms.Form
	{

		short gMode;
		const short mdProcess = 1;
		const short mdSupplier = 0;
		const short mdInstruction = 2;
		bool loading;

		public int gSupplierID;
		public int gPurchaseOrderID;
		public bool gSupplierSystem;
		public short gTransactionType;
		List<GroupBox> frmMode = new List<GroupBox>();

		private void loadLanguage()
		{
			//frmGRVblind = NO CAPTION!

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1636;
			//This utility will create a blank.......|Checked
			if (modRecordSet.rsLang.RecordCount){Label1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1432;
			//Supplier Details|Checked
			if (modRecordSet.rsLang.RecordCount){frmMode[1].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;frmMode[1].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1442;
			//Supplier Name|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1573;
			//Representative Name|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1641;
			//Create New Purchase Order|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_4.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_4.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lblData = No Code      [By Clicking the "Create Purchase Order" button.......]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblData.Caption = rsLang("LanguageLayoutLnk_Description"): lblData.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdProceed = No Code   [Create Purchase Order]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdProceed.Caption = rsLang("LanguageLayoutLnk_Description"): cmdProceed.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2459;
			//New Supplier|Checked
			if (modRecordSet.rsLang.RecordCount){cmdBack.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdBack.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//Note: DB Entry 1005 does not contain ">>" chars
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1005;
			//Next|Checked
			if (modRecordSet.rsLang.RecordCount){cmdNext.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdNext.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmGRVblind.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void doMode(ref short mode)
		{
			gMode = mode;
			short x = 0;
			for (x = 0; x <= frmMode.Count - 1; x++) {
				frmMode[x].Visible = false;
			}
			frmMode[gMode].Left = frmMode[0].Left;
			frmMode[gMode].Top = frmMode[0].Top;
			frmMode[gMode].Visible = true;
			System.Windows.Forms.Application.DoEvents();

			switch (gMode) {
				case mdProcess:
					this.cmdProceed.Focus();
					cmdBack.Text = "&Back";
					cmdNext.Text = "E&xit";
					break;
				case mdSupplier:
					if (this.Visible)
						lstSupplier.Focus();
					cmdBack.Text = "E&xit";
					cmdNext.Text = "&Next";
					break;
				case mdInstruction:
					Interaction.MsgBox("");

					break;
			}
		}

		public void exitOrder()
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			modApplication.bolFNVegGRV = false;
			this.Close();
		}


		private void cmdBack_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			switch (gMode) {
				case mdSupplier:
					exitOrder();
					break;
				case mdProcess:
					doMode(ref mdSupplier);
					break;
				case mdInstruction:
					doMode(ref mdProcess);
					break;
			}

		}



		private void cmdNext_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//    On Local Error Resume Next
			string sql = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			switch (gMode) {
				case mdSupplier:
					rs = modRecordSet.getRS(ref "SELECT * FROM Supplier WHERE SupplierID = " + GID.GetItemData(ref lstSupplier, ref lstSupplier.SelectedIndex));
					lblName.Text = "";
					lblRepName.Text = "";
					lblRepNumber.Text = "";

					gSupplierID = rs.Fields("SupplierID").Value;
					lblName.Text = rs.Fields("Supplier_Name").Value;
					lblRepName.Text = rs.Fields("Supplier_RepresentativeName").Value + "";
					lblRepNumber.Text = rs.Fields("Supplier_RepresentativeNumber").Value + "";

					doMode(ref mdProcess);
					break;
				case mdProcess:

					exitOrder();
					break;

			}
		}

		private void cmdProceed_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string sql = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			if (lstSupplier.SelectedIndex != -1) {
				sql = "INSERT INTO PurchaseOrder ( PurchaseOrder_SupplierID, PurchaseOrder_DayEndID, PurchaseOrder_PersonID, PurchaseOrder_DateCreated, PurchaseOrder_PurchaseOrderStatusID, PurchaseOrder_Reference, PurchaseOrder_AttentionLine ) ";
				sql = sql + "SELECT " + GID.GetItemData(ref this.lstSupplier, ref lstSupplier.SelectedIndex) + ", Company.Company_DayEndID, " + modRecordSet.gPersonID + ", Now(), 1, '" + Strings.Format(DateAndTime.Now, "yyyy mmm dd") + " (Blind)', '' FROM Company;";
				modRecordSet.cnnDB.Execute(sql, , ADODB.ExecuteOptionEnum.adExecuteNoRecords);
				rs = modRecordSet.getRS(ref "SELECT Max(PurchaseOrder.PurchaseOrderID) AS id FROM PurchaseOrder;");
				this.Close();
				My.MyProject.Forms.frmGRV.Create(rs.Fields("id").Value);
			}
		}

		private void frmGRVblind_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void frmGRVblind_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			loading = true;
			frmMode.AddRange(new GroupBox[] {
				_frmMode_0,
				_frmMode_1
			});

			ADODB.Recordset rs = default(ADODB.Recordset);
			short x = 0;
			short lQuantity = 0;
			short lDepositQuantity = 0;
			decimal lCost = default(decimal);
			decimal lActualCost = default(decimal);
			decimal lDepositUnit = default(decimal);
			decimal lDepositPack = default(decimal);
			rs = modRecordSet.getRS(ref "SELECT * FROM Supplier WHERE Supplier_Disabled = 0 ORDER BY Supplier.Supplier_Name");
			this.lstSupplier.Items.Clear();
			while (!(rs.EOF)) {
				lstSupplier.Items.Add(new LBI(rs.Fields("Supplier_Name").Value + "", rs.Fields("SupplierID").Value));
				rs.MoveNext();
			}
			lstSupplier.SelectedIndex = 0;

			loadLanguage();
			loading = false;

			doMode(ref mdSupplier);
		}


		private void lstSupplier_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (lstSupplier.SelectedIndex != -1)
				cmdNext.Enabled = true;
		}

		private void lstSupplier_DoubleClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdNext_Click(cmdNext, new System.EventArgs());

		}

		private void lstSupplier_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 13) {
				cmdNext_Click(cmdNext, new System.EventArgs());
			}
			if (KeyAscii == 27) {
				cmdBack_Click(cmdBack, new System.EventArgs());
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
	}
}
