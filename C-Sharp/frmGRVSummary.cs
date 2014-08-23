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
using Microsoft.VisualBasic.PowerPacks;
namespace _4PosBackOffice.NET
{

	internal partial class frmGRVSummary : System.Windows.Forms.Form
	{
//Option Explicit
		short intComp;
		List<GroupBox> Frame1 = new List<GroupBox>();
		List<Label> lbl = new List<Label>();
		List<RadioButton> optClose = new List<RadioButton>();
		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1720;
			//GRV Summary and Process|
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1579;
			//Back|Checked
			if (modRecordSet.rsLang.RecordCount){cmdBack.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdBack.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//Picture1 = No Code/Dynamic/NA?

			//frmMain = No Code
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmMain.Caption = rsLang("LanguageLayoutLnk_Description"): frmMain.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1722;
			//Purchased Content / Liquid|Checked
			if (modRecordSet.rsLang.RecordCount){Frame1[0].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Frame1[0].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lbl(32) = No code      [No of Lines]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lbl(32).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(32).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lbl(20) = No Code      [Contents Value]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lbl(20).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(20).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1725;
			//Line Item Discount|Checked
			if (modRecordSet.rsLang.RecordCount){lbl[21].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl[21].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}


			//NOTE: DB Entry 1726 Contains 2x different Entries!!!!
			//----> Second entry clashes with DB Entry 1460!


			//First entry of 1726 is fit for use, but disabled to verify if fixed
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1726 'Content Sub Total|
			//If rsLang.RecordCount Then lbl(31).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(31).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1460;
			//Payment Terms|Checked
			if (modRecordSet.rsLang.RecordCount){lbl[19].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl[19].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1727;
			//Account Discount|Checked
			if (modRecordSet.rsLang.RecordCount){lblDiscountName.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lblDiscountName.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1728;
			//Ullage @|Checked
			if (modRecordSet.rsLang.RecordCount){Label2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1729;
			//Sundry Plusses|Checked
			if (modRecordSet.rsLang.RecordCount){lbl[10].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl[10].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1731;
			//Sundry Minuses|Checked
			if (modRecordSet.rsLang.RecordCount){lbl[11].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl[11].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1751;
			//Exclusive|Checked
			if (modRecordSet.rsLang.RecordCount){lbl[22].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl[22].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lbl(29) = No Code      [VAT]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lbl(29).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(29).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1753;
			//Inclusive|Checked
			if (modRecordSet.rsLang.RecordCount){lbl[30].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl[30].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1735;
			//Deposits with Purchases|
			if (modRecordSet.rsLang.RecordCount){Frame1[1].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Frame1[1].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1736;
			//Deposit Value|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lbl(13) = No Code      [VAT]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lbl(13).Caption = rsLang("LanguageLayoutLnk_Description"): lb(13).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1753;
			//Inclusive|Checked
			if (modRecordSet.rsLang.RecordCount){lbl[14].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl[14].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//Frame1(5) = No Code    [Purchased Deposits]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Frame1(5).Caption = rsLang("LanguageLayoutLnk_Description"): Frame1(5).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1736;
			//Deposit Value|Checked
			if (modRecordSet.rsLang.RecordCount){lbl[35].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl[35].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lbl(34) = No Code      [VAT]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lbl(34).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(34).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")


			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1753;
			//Inclusive|Checked
			if (modRecordSet.rsLang.RecordCount){lbl[33].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl[33].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1742;
			//Out Bound VAT|Checked
			if (modRecordSet.rsLang.RecordCount){lbl[8].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl[8].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1743;
			//Purchases Inclusive|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_6.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_6.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1744;
			//Desired Invoice Value|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1746;
			//Difference|Checked
			if (modRecordSet.rsLang.RecordCount){lbl[18].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl[18].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1747;
			//Credited Content / Liquid|Checked
			if (modRecordSet.rsLang.RecordCount){Frame1[3].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Frame1[3].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lbl(37) = No Code      [No Of Lines]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then COMPONENT(0).Caption = rsLang("LanguageLayoutLnk_Description"): COMPONENT(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_1 = No Code       [Contents Value]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1725;
			//Line Item Discount|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1751;
			//Exclusive\Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_4.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_4.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lbl_5 = No Code       [VAT]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_5.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1753;
			//Inclusive|Checked
			if (modRecordSet.rsLang.RecordCount){lbl[12].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl[12].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1754;
			//Deposits with Credits|Checked
			if (modRecordSet.rsLang.RecordCount){Frame1[4].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Frame1[4].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1758;
			//Credits VAT|Checked
			if (modRecordSet.rsLang.RecordCount){lbl[26].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl[26].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1759;
			//Credits Inclusive|Checked
			if (modRecordSet.rsLang.RecordCount){lbl[25].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl[25].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1760;
			//Returned Deposits|Checked
			if (modRecordSet.rsLang.RecordCount){Frame1[2].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Frame1[2].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1736;
			//Deposit Value|Checked
			if (modRecordSet.rsLang.RecordCount){lbl[17].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl[17].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lbl(16) = No Code      [VAT]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lbl(16).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(16).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1753;
			//Inclusive|Checked
			if (modRecordSet.rsLang.RecordCount){lbl[15].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl[15].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1764;
			//In Bound VAT|Checked
			if (modRecordSet.rsLang.RecordCount){lbl[28].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl[28].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1765;
			//Credit Inclusive|Checked
			if (modRecordSet.rsLang.RecordCount){lbl[27].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;lbl[27].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1766;
			//Nett Invoice Value|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_7.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_7.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//frmProcess = No Code   [Process this 'Goods Receiving Voucher']
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmProcess.Caption = rsLang("LanguageLayoutLnk_Description"): frmProcess.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1768;
			//This Purchase Order has been delivered in full|Checked
			if (modRecordSet.rsLang.RecordCount){optClose[0].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;optClose[0].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1328;
			//Notes|Checked
			if (modRecordSet.rsLang.RecordCount){Label3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1332;
			//Process|Checked
			if (modRecordSet.rsLang.RecordCount){cmdNext.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdNext.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmGRVSummary.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public void doTotals()
		{
			this.lblDiscount.Text = Strings.FormatNumber(0 - Convert.ToDecimal(lblContentExclusiveIn.Text) * Convert.ToDecimal(txtDiscount.Text) / 100, 2);
			lblUllage.Text = Strings.FormatNumber(0 - Convert.ToDecimal(lblContentExclusiveIn.Text) * Convert.ToDouble(this.txtUllage.Text) / 100, 2);
			lblExclusiveIn.Text = Strings.FormatNumber(Convert.ToDecimal(lblContentExclusiveIn.Text) + Convert.ToDecimal(this.lblDiscount.Text) + Convert.ToDecimal(lblUllage.Text) + Convert.ToDecimal(txtPlus.Text) - Convert.ToDecimal(txtMinus.Text), 2);
			lblVATin.Text = Strings.FormatNumber(Convert.ToDecimal(lblExclusiveIn.Text) * Convert.ToDecimal(lblVatRateIn.Text) / 100, 2);
			lblInclusiveIn.Text = Strings.FormatNumber(Convert.ToDecimal(lblExclusiveIn.Text) + Convert.ToDecimal(lblVATin.Text), 2);
			this.lblOutBoundVat.Text = Strings.FormatNumber(Convert.ToDecimal(lblVATin.Text) + Convert.ToDecimal(lblDepositVatIn.Text) + Convert.ToDecimal(lblDepositReturnVatIn.Text), 2);
			this.lblOutBound.Text = Strings.FormatNumber(Convert.ToDecimal(lblInclusiveIn.Text) + Convert.ToDecimal(lblDepositInclusiveIn.Text) + Convert.ToDecimal(lblDepositReturnInclusiveIn.Text), 2);

			lblDifference.Text = Strings.FormatNumber(Convert.ToDecimal(lblOutBound.Text) - Convert.ToDecimal(lblTotalOriginal.Text), 2);
			this.lblTotal.Text = Strings.FormatNumber(Convert.ToDecimal(lblOutBound.Text) - Convert.ToDecimal(lblInBound.Text), 2);
		}
		private void cmbPayment_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			string lString = null;
			if (cmbPayment.SelectedIndex != -1) {
				switch (Convert.ToInt32(cmbPayment.SelectedIndex)) {
					//Select Case cmbPayment.GetItemData()
					case 0:
						lString = "Supplier_discountCOD";
						break;
					case 1:
						lString = "Supplier_discount15days";
						break;
					case 2:
						lString = "Supplier_discount30days";
						break;
					case 3:
						lString = "Supplier_discount60days";
						break;
					case 4:
						lString = "Supplier_discount90days";
						break;
					case 5:
						lString = "Supplier_discount120days";
						break;
					case 6:
						lString = "Supplier_discountSmartCard";
						break;
				}
				if (Information.IsDBNull(My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields(lString).Value)) {
					this.txtDiscount.Text = Strings.FormatNumber("0", 2);
				} else {
					this.txtDiscount.Text = Strings.FormatNumber(My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields(lString).Value * 100, 2);
				}
			} else {
				this.txtDiscount.Text = Strings.FormatNumber("0", 2);
			}
			txtDiscount_Leave(txtDiscount, new System.EventArgs());
		}
		private void cmdBack_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			saveDetails();
			this.Close();
		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
			My.MyProject.Forms.frmGRVDeposit.Close();
			My.MyProject.Forms.frmGRVitem.Close();
			My.MyProject.Forms.frmGRV.Close();
		}

		private void cmdNext_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int GRVInvoiceNumber = 0;
			int PurchaseOrderSupplierID = 0;
			int xx = 0;
			string sql = null;
			bool iSer = false;
			ADODB.Recordset rsC = default(ADODB.Recordset);
			ADODB.Recordset rsPri = default(ADODB.Recordset);
			ADODB.Recordset rBit = default(ADODB.Recordset);
			int gParameter = 0;
			const short gActualAndList_U = 2048;
			const short gLeaveListAct_U = 8192;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();


			rBit = modRecordSet.getRS(ref "SELECT Company_DayEndBit FROM Company");
			gParameter = Convert.ToInt32(0 + rBit.Fields("Company_DayEndBit").Value);

			modApplication.grvPrin = false;
			bool QtyChkOver = false;
			ADODB.Recordset rsQtyOver = default(ADODB.Recordset);
			int lMgrID = 0;
			ADODB.Recordset rsPur = default(ADODB.Recordset);
			ADODB.Recordset rsQty = default(ADODB.Recordset);
			decimal cQty = default(decimal);
			bool QtyChk = false;
			ADODB.Recordset rsID = default(ADODB.Recordset);
			ADODB.Recordset rsSTransGRV = default(ADODB.Recordset);
			short x = 0;
			ADODB.Recordset rsChk = default(ADODB.Recordset);
			if (Interaction.MsgBox("You are about to commit this 'Goods Receiving Voucher' into Stock." + Constants.vbCrLf + "Are you sure you wish to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Commit GRV") == MsgBoxResult.Yes) {
				iSer = false;
				modApplication.intCurr = 0;

				//update TotalQtyKG
				//cnnDB.Execute "UPDATE (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN PackSize ON StockItem.StockItem_PackSizeID = PackSize.PackSizeID SET GRVItem_QuantityTotalKG = PackSize_Volume*GRVItem_Quantity, GRVItem_QuantityUsedKG=0, GRVItem_PackSizeVol=PackSize.PackSize_Volume WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & "));"
				modRecordSet.cnnDB.Execute("UPDATE (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN PackSize ON StockItem.StockItem_PackSizeID = PackSize.PackSizeID SET GRVItem_QuantityTotalKG = IIf(GRVItem_PackSizeVol=0,PackSize.PackSize_Volume,GRVItem_PackSizeVol)*GRVItem_Quantity, GRVItem_QuantityUsedKG=0, GRVItem_PackSizeVol=IIf(GRVItem_PackSizeVol=0,PackSize.PackSize_Volume,GRVItem_PackSizeVol) WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + "));");

				//update the GRV processer person id
				modRecordSet.cnnDB.Execute("UPDATE GRV SET GRV.GRV_PersonID = " + My.MyProject.Forms.frmMenu.lblUser.Tag + " WHERE (((GRV.GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + "));");

				//Check for person security to not show Order QTY

				lMgrID = 0;
				if (8192 & My.MyProject.Forms.frmMenu.gBit) {
				} else {
					QtyChkOver = false;
					rsQtyOver = modRecordSet.getRS(ref "SELECT GRVItem.GRVItem_StockItemID, GRVItem_QuantityOrder, GRVItem.GRVItem_Quantity FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE GRVItem_GRVID = " + Conversion.Val(My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value) + ";");
					while (!(rsQtyOver.EOF)) {
						if (rsQtyOver.Fields("GRVItem_Quantity").Value > 0) {
							if (rsQtyOver.Fields("GRVItem_Quantity").Value != rsQtyOver.Fields("GRVItem_QuantityOrder").Value) {
								QtyChkOver = true;
							}
						}
						rsQtyOver.moveNext();
					}
					if (QtyChkOver) {
						Interaction.MsgBox("GRV Qty for some items is not same as Actual Ordered Qty. Call Your Supervisor for Override?", MsgBoxStyle.Question + MsgBoxStyle.ApplicationModal + MsgBoxStyle.DefaultButton1, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
						if (My.MyProject.Forms.frmOverride.sOverride(ref lMgrID)) {
							//update the GRV processer person id
							modRecordSet.cnnDB.Execute("UPDATE GRV SET GRV.GRV_OverridePersonID = " + lMgrID + " WHERE (((GRV.GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + "));");
						} else {
							return;
						}

					}
				}
				//Check for person security to not show Order QTY

				//Do you want.......
				modApplication.Gr_ID = Conversion.Val(My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value);
				modApplication.Gr_ID = My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value;
				sql = "SELECT * FROM GRVItem WHERE GRVItem_Return = 0 AND GRVItem_GRVID = " + Conversion.Val(My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value);

				for (xx = 0; xx <= 100; xx++) {
					modApplication.tempStockItem[xx] = "";
					modApplication.intArrayName[xx] = "";
					modApplication.intArraySCode[xx] = 0;
				}

				//New sql
				sql = "SELECT StockItem.StockItem_SerialTracker, GRVItem.* FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE (((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_GRVID)= " + Conversion.Val(My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value) + "));";
				modApplication.rs_St = modRecordSet.getRS(ref sql);
				modApplication.rs_St.filter = "StockItem_SerialTracker = 1";
				if (modApplication.rs_St.RecordCount) {
					iSer = true;
				}
				if (iSer == true) {
					modApplication.Grv_Unload = false;
					My.MyProject.Forms.frmSerialNumber.ShowDialog();
				}

				if (modApplication.Grv_Unload == true) {
					saveDetails();
					this.Close();
				} else {


					saveDetails();
					modRecordSet.cnnDB.BeginTrans();

					SaveIntoTable();
					//Save serial number's into tables


					modRecordSet.cnnDB.Execute("UPDATE GRV, Company SET GRV.GRV_ContentExclusive = " + Convert.ToDecimal(lblContentExclusiveIn.Text) + ", GRV.GRV_DayEndID = [Company]![Company_DayEndID], GRV.GRV_GRVStatusID = 3, GRV.GRV_Date = Now(), GRV.GRV_InvoiceInclusive = " + Convert.ToDecimal(this.lblTotal.Text) + ", GRV_InvoiceVat = " + Convert.ToDecimal(Convert.ToDecimal(this.lblOutBoundVat.Text) - Convert.ToDecimal(this.lblInBoundVat.Text)) + ", GRV.GRV_InvoiceDiscount = " + Convert.ToDecimal(this.lblDiscount.Text) + ", GRV.GRV_Ullage = " + Convert.ToDecimal(this.txtUllage.Text) + ", GRV.GRV_SundriesPlus = " + Convert.ToDecimal(this.txtPlus.Text) + ", GRV.GRV_SundriesMinus = " + Convert.ToDecimal(0 - Convert.ToDecimal(this.txtMinus.Text)) + ", GRV.GRV_Terms = " + Convert.ToInt32(cmbPayment.SelectedIndex) + " WHERE (((GRV.GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + "));");
					modRecordSet.cnnDB.Execute("UPDATE Warehouse INNER JOIN (GRVItem INNER JOIN WarehouseStockItemLnk ON GRVItem.GRVItem_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID SET GRVItem.GRVItem_WarehouseQuantity = [GRVItem]![GRVItem_WarehouseQuantity]+[WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((Warehouse.Warehouse_Saleable)<>0));");
					modRecordSet.cnnDB.Execute("UPDATE (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID SET GRVItem.GRVItem_DepositCost = [Deposit_UnitCost]*[GRVItem_PackSize] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + "));");
					modRecordSet.cnnDB.Execute("UPDATE (GRVItem INNER JOIN StockItem ON (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize) AND (GRVItem.GRVItem_StockItemID = StockItem.StockItemID)) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID SET GRVItem.GRVItem_DepositCost = [GRVItem_DepositCost]+[Deposit_CaseCost] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + "));");
					//cnnDB.Execute "UPDATE Vat INNER JOIN (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) ON Vat.VatID = StockItem.StockItem_VatID SET GRVItem.GRVItem_VatRate = [Vat]![Vat_Amount] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & "));"
					modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET GRVItem.GRVItem_OldActualCost = [StockItem]![StockItem_ActualCost], GRVItem.GRVItem_StockItemQuantity = [StockItem]![StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + "));");

					//Do Actual Cost
					modRecordSet.cnnDB.Execute("UPDATE GRVItem SET GRVItem.GRVItem_ActualCost = [GRVItem_ContentCost]-[GRVItem_DiscountAmount] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + "));");
					modRecordSet.cnnDB.Execute("UPDATE GRV INNER JOIN GRVItem ON GRV.GRVID = GRVItem.GRVItem_GRVID SET GRVItem.GRVItem_ActualCost = ([GRVItem_ActualCost]+([GRVItem_ActualCost]*(([GRV_InvoiceDiscount]+[GRV_Ullage]+[GRV_SundriesPlus]+[GRV_SundriesMinus])/([GRV_ContentExclusive]+0.0001)))) WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=0));");

					//sql = "INSERT INTO PriceChannelLnk (PriceChannelLnk_StockItemID, PriceChannelLnk_Quantity, PriceChannelLnk_ChannelID, PriceChannelLnk_Price) VALUES (" & gStockItemID & ", " & frmItem(x).Tag & ", " & gChannelID & ", " & Replace(txtPrice(x).Text, ",", "") & ")"
					//cnnDB.Execute "UPDATE PriceChannelLnk INNER JOIN GRVItem ON (PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID) AND (GRVItem.GRVItem_StockItemQuantity = PriceChannelLnk.PriceChannelLnk_Quantity) SET PriceChannelLnk.PriceChannelLnk_Price = ([GRVItem_Price]) WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0));"
					//cnnDB.Execute "UPDATE PriceChannelLnk INNER JOIN GRVItem ON ((PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID) AND (PriceChannelLnk.PriceChannelLnk_Quantity=1) AND (PriceChannelLnk.PriceChannelLnk_ChannelID=1)) SET PriceChannelLnk.PriceChannelLnk_Price = ([GRVItem_Price]) WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0));"
					modRecordSet.cnnDB.Execute("UPDATE PriceChannelLnk INNER JOIN GRVItem ON ((PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID)) SET PriceChannelLnk.PriceChannelLnk_Price = ([GRVItem_Price]) WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=0) AND ((PriceChannelLnk.PriceChannelLnk_Quantity)=1)  AND ((PriceChannelLnk.PriceChannelLnk_ChannelID)=1));");

					//to check for Actual cost
					rsC = modRecordSet.getRS(ref "SELECT Company_GRVCost FROM Company;");
					if (rsC.Fields("Company_GRVCost").Value == true) {


						//If gParameter And gActualAndList_U = 2048 Then
						//    'Actual Update...
						//    cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = (((([StockItem_ActualCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
						//    cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
						//
						//    'cnnDB.Execute "UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_ContentCost = (GRVItem.GRVItem_ContentCost * StockItem.StockItem_Quantity) Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS("GRVID") & ") And (GRVItem_Return=0)"
						//    'cnnDB.Execute "UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_ContentCost = (GRVItem.GRVItem_ContentCost * GRVItem.GRVItem_Quantity) Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS("GRVID") & ") And (GRVItem_Return=0)"
						//    'List Update...
						//    cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ListCost = (((([StockItem_ListCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
						//    cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ListCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
						//
						// commented due to changes option
						//Else
						//
						//    cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = (((([StockItem_ActualCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
						//    cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
						//End If
						//cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = (((([StockItem_ActualCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
						//cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));"

						//to check for Actual cost >>> cnnDB.Execute "UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_WarehouseQuantity)<=0) AND ((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((StockItem.StockItem_ActualCostChange)<>True));"

					} else {


						//If gParameter And gActualAndList_U = 2048 Then
						if (System.Math.Abs(Convert.ToInt32(Convert.ToBoolean(rBit.Fields("Company_DayEndBit").Value & gActualAndList_U)))) {
							//Actual Update...
							modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = (((([StockItem_ActualCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));");
							modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));");

							//cnnDB.Execute "UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_ContentCost = (GRVItem.GRVItem_ContentCost * StockItem.StockItem_Quantity) Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS("GRVID") & ") And (GRVItem_Return=0)"
							//cnnDB.Execute "UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_ContentCost = (GRVItem.GRVItem_ContentCost * GRVItem.GRVItem_Quantity) Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS("GRVID") & ") And (GRVItem_Return=0)"
							//List Update...
							modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ListCost = (((([StockItem_ListCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));");
							modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ListCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));");

						} else {
							//commened for wronge calculation and changed to LIST COST in below line cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = (((([StockItem_ActualCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
							modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = (((([StockItem_ActualCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));");
							modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));");
						}
						//cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = (((([StockItem_ActualCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
						//cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));"

						//commenting due to Wronge formula of sundries
						modRecordSet.cnnDB.Execute("UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_WarehouseQuantity)<=0) AND ((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((StockItem.StockItem_ActualCostChange)<>True));");


					}
					//end of to check for Actual cost

					//Warehouse StockItem
					modRecordSet.cnnDB.Execute("UPDATE GRVItem INNER JOIN WarehouseStockItemLnk ON GRVItem.GRVItem_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk_Quantity]+[GRVItem_PackSize]*[GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));");
					modRecordSet.cnnDB.Execute("UPDATE GRVItem INNER JOIN WarehouseStockItemLnk ON GRVItem.GRVItem_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk_Quantity]-[GRVItem_PackSize]*[GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=1) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));");

					modRecordSet.cnnDB.Execute("UPDATE PurchaseOrderItem INNER JOIN (GRV INNER JOIN GRVItem ON GRV.GRVID = GRVItem.GRVItem_GRVID) ON (PurchaseOrderItem.PurchaseOrderItem_StockItemID = GRVItem.GRVItem_StockItemID) AND (PurchaseOrderItem.PurchaseOrderItem_PurchaseOrderID = GRV.GRV_PurchaseOrderID) SET PurchaseOrderItem.PurchaseOrderItem_QuantityDelivered = [GRVItem_Quantity]*[GRVItem_PackSize]+[PurchaseOrderItem_QuantityDelivered] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=0));");

					//cnnDB.Execute "UPDATE (Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN GRVItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = GRVItem.GRVItem_StockItemID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV = [DayEndStockItemLnk_QuantityGRV]+[GRVItem_PackSize]*[GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0));"
					//cnnDB.Execute "UPDATE (Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN GRVItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = GRVItem.GRVItem_StockItemID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV = [DayEndStockItemLnk_QuantityGRV]-[GRVItem_PackSize]*[GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=1));"

					//Stock item Deposits
					modRecordSet.cnnDB.Execute("UPDATE ((Deposit INNER JOIN WarehouseDepositItemLnk ON Deposit.DepositID = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID) INNER JOIN StockItem ON Deposit.DepositID = StockItem.StockItem_DepositID) INNER JOIN GRVItem ON (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize) AND (StockItem.StockItemID = GRVItem.GRVItem_StockItemID) SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_Quantity]+[GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=0) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=1) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2));");
					modRecordSet.cnnDB.Execute("UPDATE ((Deposit INNER JOIN WarehouseDepositItemLnk ON Deposit.DepositID = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID) INNER JOIN StockItem ON Deposit.DepositID = StockItem.StockItem_DepositID) INNER JOIN GRVItem ON (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize) AND (StockItem.StockItemID = GRVItem.GRVItem_StockItemID) SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_Quantity]-[GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=1) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=1) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2));");

					//cnnDB.Execute "UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN ((Deposit INNER JOIN StockItem ON Deposit.DepositID = StockItem.StockItem_DepositID) INNER JOIN GRVItem ON (StockItem.StockItemID = GRVItem.GRVItem_StockItemID) AND (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize)) ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = Deposit.DepositID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]+[GRVItem]![GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=1));"
					//cnnDB.Execute "UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN ((Deposit INNER JOIN StockItem ON Deposit.DepositID = StockItem.StockItem_DepositID) INNER JOIN GRVItem ON (StockItem.StockItemID = GRVItem.GRVItem_StockItemID) AND (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize)) ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = Deposit.DepositID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]-[GRVItem]![GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)<>0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=1));"

					//deposits
					modRecordSet.cnnDB.Execute("UPDATE Vat INNER JOIN (SupplierDepositLnk INNER JOIN ((PurchaseOrder INNER JOIN GRV ON PurchaseOrder.PurchaseOrderID = GRV.GRV_PurchaseOrderID) INNER JOIN (Deposit INNER JOIN GRVDeposit ON Deposit.DepositID = GRVDeposit.GRVDeposit_DepositID) ON GRV.GRVID = GRVDeposit.GRVDeposit_GRVID) ON (SupplierDepositLnk.SupplierDepositLnk_Type = GRVDeposit.GRVDeposit_Type) AND (SupplierDepositLnk.SupplierDepositLnk_DepositID = Deposit.DepositID) AND (SupplierDepositLnk.SupplierDepositLnk_SupplierID = PurchaseOrder.PurchaseOrder_SupplierID)) ON Vat.VatID = Deposit.Deposit_VatID SET GRVDeposit.GRVDeposit_Name = [SupplierDepositLnk]![SupplierDepositLnk_Name], GRVDeposit.GRVDeposit_UnitCost = [Deposit]![Deposit_UnitCost], GRVDeposit.GRVDeposit_CaseCost = [Deposit]![Deposit_CaseCost], GRVDeposit.GRVDeposit_CaseQuantity = [Deposit]![Deposit_Quantity], GRVDeposit.GRVDeposit_VatRate = [Vat]![Vat_Amount] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + "));");

					//units
					modRecordSet.cnnDB.Execute("UPDATE WarehouseDepositItemLnk INNER JOIN GRVDeposit ON WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_Quantity]-[GRVDeposit_Quantity]*[GRVDeposit_CaseQuantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=0) AND ((GRVDeposit.GRVDeposit_Type)=1 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=0));");
					modRecordSet.cnnDB.Execute("UPDATE WarehouseDepositItemLnk INNER JOIN GRVDeposit ON WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_Quantity]+[GRVDeposit_Quantity]*[GRVDeposit_CaseQuantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=0) AND ((GRVDeposit.GRVDeposit_Type)=1 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=1));");

					//cnnDB.Execute "UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN GRVDeposit ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]-[GRVDeposit_Quantity]*[GRVDeposit_CaseQuantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVDeposit.GRVDeposit_Type)=1 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=0));"
					//cnnDB.Execute "UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN GRVDeposit ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]+[GRVDeposit_Quantity]*[GRVDeposit_CaseQuantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVDeposit.GRVDeposit_Type)=1 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)<>0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=0));"

					//cnnDB.Execute "UPDATE WarehouseDepositItemLnk INNER JOIN GRVDeposit ON WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_DepositTypeID]-[GRVDeposit_Quantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=1) AND ((GRVDeposit.GRVDeposit_Type)=2 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=0));"
					//cnnDB.Execute "UPDATE WarehouseDepositItemLnk INNER JOIN GRVDeposit ON WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_DepositTypeID]+[GRVDeposit_Quantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=1) AND ((GRVDeposit.GRVDeposit_Type)=2 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=1));"
					//FIXED: was not updating Case QTY correct
					modRecordSet.cnnDB.Execute("UPDATE WarehouseDepositItemLnk INNER JOIN GRVDeposit ON WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_Quantity]-[GRVDeposit_Quantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=1) AND ((GRVDeposit.GRVDeposit_Type)=2 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=0));");
					modRecordSet.cnnDB.Execute("UPDATE WarehouseDepositItemLnk INNER JOIN GRVDeposit ON WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_Quantity]+[GRVDeposit_Quantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=1) AND ((GRVDeposit.GRVDeposit_Type)=2 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=1));");

					//cnnDB.Execute "UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN GRVDeposit ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]-[GRVDeposit_Quantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVDeposit.GRVDeposit_Type)=2 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=1));"
					//cnnDB.Execute "UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN GRVDeposit ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]+[GRVDeposit_Quantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVDeposit.GRVDeposit_Type)=2 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)<>0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=1));"


					if (this.optClose[0].Checked) {
						modRecordSet.cnnDB.Execute("UPDATE GRV INNER JOIN PurchaseOrder ON GRV.GRV_PurchaseOrderID = PurchaseOrder.PurchaseOrderID SET PurchaseOrder.PurchaseOrder_PurchaseOrderStatusID = 3 WHERE (((GRV.GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + "));");
					}
					modRecordSet.cnnDB.Execute("INSERT INTO SupplierTransaction ( SupplierTransaction_SupplierID, SupplierTransaction_TransactionTypeID, SupplierTransaction_MonthEndID, SupplierTransaction_MonthEndIDFor, SupplierTransaction_DayEndID, SupplierTransaction_ReferenceID, SupplierTransaction_Date, SupplierTransaction_Description, SupplierTransaction_Amount, SupplierTransaction_Reference ) SELECT PurchaseOrder.PurchaseOrder_SupplierID, 2 AS transType, DayEnd.DayEnd_MonthEndID, DayEnd.DayEnd_MonthEndID, GRV.GRV_DayEndID, GRV.GRVID, GRV.GRV_InvoiceDate, '' AS [Desc], GRV.GRV_InvoiceInclusive, GRV.GRV_InvoiceNumber FROM DayEnd INNER JOIN (PurchaseOrder INNER JOIN GRV ON PurchaseOrder.PurchaseOrderID = GRV.GRV_PurchaseOrderID) ON DayEnd.DayEndID = GRV.GRV_DayEndID Where (((GRV.GRVID) = " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + "));");
					modRecordSet.cnnDB.Execute("UPDATE GRV INNER JOIN (Supplier INNER JOIN PurchaseOrder ON Supplier.SupplierID = PurchaseOrder.PurchaseOrder_SupplierID) ON GRV.GRV_PurchaseOrderID = PurchaseOrder.PurchaseOrderID SET Supplier.Supplier_Current = [Supplier]![Supplier_Current]+[GRV]![GRV_InvoiceInclusive] WHERE (((GRV.GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + "));");

					//to check for Actual cost
					rsC = modRecordSet.getRS(ref "SELECT Company_GRVCost FROM Company;");
					if (rsC.Fields("Company_GRVCost").Value == true) {
						modRecordSet.cnnDB.Execute("UPDATE Company, GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET StockItem.StockItem_LastCost = [Company_DayEndID], StockItem.StockItem_ActualCost = [GRVItem_ContentCost] WHERE (((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_ContentCost)<>[StockItem_ListCost]) AND ((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + "));");
					} else {
						//If gParameter And gLeaveListAct_U = 8192 Then
						if (System.Math.Abs(Convert.ToInt32(Convert.ToBoolean(rBit.Fields("Company_DayEndBit").Value & gLeaveListAct_U)))) {
						} else {
							modRecordSet.cnnDB.Execute("UPDATE Company, GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET StockItem.StockItem_LastCost = [Company_DayEndID], StockItem.StockItem_ListCost = [GRVItem_ContentCost] WHERE (((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_ContentCost)<>[StockItem_ListCost]) AND ((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + "));");
						}
					}

					modRecordSet.cnnDB.Execute("INSERT INTO systemStockItemPricing ( systemStockItemPricing ) SELECT PriceChannelLnk.PriceChannelLnk_StockItemID FROM systemStockItemPricing RIGHT JOIN (PriceChannelLnk INNER JOIN GRVItem ON (PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID) AND (PriceChannelLnk.PriceChannelLnk_Quantity = GRVItem.GRVItem_PackSize)) ON systemStockItemPricing.systemStockItemPricing = PriceChannelLnk.PriceChannelLnk_StockItemID WHERE (((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((PriceChannelLnk.PriceChannelLnk_ChannelID)=1) AND ((systemStockItemPricing.systemStockItemPricing) Is Null) AND ((PriceChannelLnk.PriceChannelLnk_Price)<>[GRVItem_Price]));");
					//cnnDB.Execute "UPDATE PriceChannelLnk INNER JOIN GRVItem ON (PriceChannelLnk.PriceChannelLnk_Quantity = GRVItem.GRVItem_PackSize) AND (PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID) SET PriceChannelLnk.PriceChannelLnk_Price = [GRVItem_Price] WHERE (((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((PriceChannelLnk.PriceChannelLnk_ChannelID)=1) AND ((PriceChannelLnk.PriceChannelLnk_Price)<>[GRVItem_Price]));"

					FlushMemoryArrays();
					//Reset arrays
					modApplication.intCurr = 0;


					modRecordSet.cnnDB.CommitTrans();

					doDiskFlush();

					modApplication.report_GRV(ref My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value);

					//check for Order QTY

					modRecordSet.cnnDB.Execute("DELETE * from StockTransferGRV;");
					QtyChk = false;
					rsQty = modRecordSet.getRS(ref "SELECT GRVItem.GRVItem_StockItemID, GRVItem_QuantityOrder, GRVItem.GRVItem_Quantity FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE GRVItem_GRVID = " + Conversion.Val(My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value) + ";");
					while (!(rsQty.EOF)) {
						if (rsQty.Fields("GRVItem_Quantity").Value > 0) {
							if (rsQty.Fields("GRVItem_Quantity").Value < rsQty.Fields("GRVItem_QuantityOrder").Value) {
								cQty = rsQty.Fields("GRVItem_QuantityOrder").Value - rsQty.Fields("GRVItem_Quantity").Value;
								modRecordSet.cnnDB.Execute("INSERT INTO StockTransferGRV ( StockTransfer_StockItemID, StockTransfer_Quantity, StockTransfer_Price ) SELECT " + rsQty.Fields("GRVItem_StockItemID").Value + ", " + cQty + ", " + 0);
								QtyChk = true;
							}
						}
						rsQty.moveNext();
					}

					if (QtyChk == true) {

						PurchaseOrderSupplierID = 2;
						GRVInvoiceNumber = "BackOrder";
						rsPur = modRecordSet.getRS(ref "SELECT PurchaseOrder.PurchaseOrder_SupplierID, GRV.GRV_InvoiceNumber, GRV.GRVID FROM PurchaseOrder INNER JOIN GRV ON PurchaseOrder.PurchaseOrderID = GRV.GRV_PurchaseOrderID WHERE (((GRV.GRVID)=" + Conversion.Val(My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value) + "));");
						if (rsPur.RecordCount) {
							PurchaseOrderSupplierID = rsPur.Fields("PurchaseOrder_SupplierID").Value;
							GRVInvoiceNumber = rsPur.Fields("GRV_InvoiceNumber").Value;
						}

						if (Interaction.MsgBox("GRV Qty for some items is less then Actual Ordered Qty. Do you want to log an Order for balance Qty?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.ApplicationModal + MsgBoxStyle.DefaultButton1, _4PosBackOffice.NET.My.MyProject.Application.Info.Title) == MsgBoxResult.Yes) {
							sql = "INSERT INTO PurchaseOrder ( PurchaseOrder_SupplierID, PurchaseOrder_DayEndID, PurchaseOrder_PersonID, PurchaseOrder_DateCreated, PurchaseOrder_PurchaseOrderStatusID, PurchaseOrder_Reference, PurchaseOrder_AttentionLine ) ";
							sql = sql + "SELECT " + PurchaseOrderSupplierID + ", Company.Company_DayEndID, " + modRecordSet.gPersonID + ", Now(), 1, '" + Strings.Format(DateAndTime.Now, "yyyy mmm dd") + " (Balance Order)', '' FROM Company;";
							modRecordSet.cnnDB.Execute(sql, , ADODB.ExecuteOptionEnum.adExecuteNoRecords);

							rsID = modRecordSet.getRS(ref "SELECT Max(PurchaseOrder.PurchaseOrderID) AS id FROM PurchaseOrder;");
							sql = "INSERT INTO GRV ( GRV_PurchaseOrderID, GRV_DayEndID, GRV_GRVStatusID, GRV_Date, GRV_InvoiceDate, GRV_InvoiceNumber, GRV_InvoiceInclusive, GRV_InvoiceVat, GRV_InvoiceDiscount, GRV_Ullage, GRV_SundriesPlus, GRV_SundriesMinus, GRV_Terms ) SELECT " + rsID.Fields("id").Value + ", Company.Company_DayEndID, 1 AS status, Now(), Now(), '" + (GRVInvoiceNumber + "_" + rsID.Fields("id").Value) + "', 0, 0, 0, 0, 0, 0, 1 FROM Company;";
							modRecordSet.cnnDB.Execute(sql, , ADODB.ExecuteOptionEnum.adExecuteNoRecords);
							if (rsID.State)
								rsID.Close();
							rsID = modRecordSet.getRS(ref "SELECT Max(GRV.GRVID) AS id FROM GRV;");

							x = 1;
							//Set rsSTransGRV = getRS("SELECT StockItem.StockItem_Name, StockTransferGRV.* FROM StockTransferGRV INNER JOIN StockItem ON StockTransferGRV.StockTransfer_StockItemID = StockItem.StockItemID ORDER BY StockItem.StockItem_Name, StockTransferGRV.StockTransfer_Quantity;")
							rsSTransGRV = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, StockTransferGRV.*, GRVItem.GRVItem_PackSize FROM (StockTransferGRV INNER JOIN StockItem ON StockTransferGRV.StockTransfer_StockItemID = StockItem.StockItemID) INNER JOIN GRVItem ON StockTransferGRV.StockTransfer_StockItemID = GRVItem.GRVItem_StockItemID Where (((GRVItem.GRVItem_GRVID) = " + Conversion.Val(My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value) + ")) ORDER BY StockItem.StockItem_Name, StockTransferGRV.StockTransfer_Quantity;");
							while (!(rsSTransGRV.EOF)) {

								rsChk = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + rsSTransGRV.Fields("StockTransfer_StockItemID").Value + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));");
								if (rsChk.RecordCount) {
									sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " + x + ", " + rsID.Fields("id").Value + " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, " + rsSTransGRV.Fields("GRVItem_PackSize").Value + " AS PackSize, " + rsSTransGRV.Fields("StockTransfer_Quantity").Value + " AS QuantityOrder, " + rsSTransGRV.Fields("StockTransfer_Quantity").Value + " AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))";
									sql = sql + " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + rsSTransGRV.Fields("StockTransfer_StockItemID").Value + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));";
									modRecordSet.cnnDB.Execute(sql);
								} else {
									sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " + x + ", " + rsID.Fields("id").Value + " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, " + rsSTransGRV.Fields("GRVItem_PackSize").Value + " AS PackSize, " + rsSTransGRV.Fields("StockTransfer_Quantity").Value + " AS QuantityOrder, " + rsSTransGRV.Fields("StockTransfer_Quantity").Value + " AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))";
									sql = sql + " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + rsSTransGRV.Fields("StockTransfer_StockItemID").Value + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));";
									modRecordSet.cnnDB.Execute(sql);
								}

								x = x + 1;
								rsSTransGRV.moveNext();
							}
						}
					}

					//run time error removal of type mismatch
					//Set rsPri = getRS("SELECT GRVItem.GRVItem_StockItemID, GRVItem.GRVItem_Quantity, StockItem.StockItem_SBarcode FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE GRVItem_GRVID = " & Val(frmGRV.adoPrimaryRS("GRVID")) & " AND (StockItem_SBarcode = 'shelf' Or StockItem_SBarcode = 'barcode')")
					//Set rsPri = getRS("SELECT GRVItem.GRVItem_StockItemID, GRVItem.GRVItem_Quantity, StockItem.StockItem_SBarcode FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE GRVItem_GRVID = " & Val(frmGRV.adoPrimaryRS("GRVID")) & " AND (StockItem_SBarcode = True Or StockItem_SShelf = True)")
					rsPri = modRecordSet.getRS(ref "SELECT GRVItem.GRVItem_StockItemID, (GRVItem.GRVItem_Quantity*GRVItem_PackSize) AS GRVItem_Quantity, StockItem.StockItem_SBarcode,StockItem.StockItem_SShelf FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE GRVItem_GRVID = " + Conversion.Val(My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value) + " AND (StockItem_SBarcode = True Or StockItem_SShelf = True)");
					//Write file
					if (rsPri.RecordCount) {
						if (fso.FileExists(modRecordSet.serverPath + "ShelfBarcode.dat"))
							fso.DeleteFile(modRecordSet.serverPath + "ShelfBarcode.dat", true);
						rsPri.save(modRecordSet.serverPath + "ShelfBarcode.dat", ADODB.PersistFormatEnum.adPersistADTG);
						modApplication.grvPrin = true;
						if (Interaction.MsgBox("Do you want to do Shelf/Barcode Printing on flagged StockItems?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.ApplicationModal + MsgBoxStyle.DefaultButton1, _4PosBackOffice.NET.My.MyProject.Application.Info.Title) == MsgBoxResult.Yes) {

							//For Auto UpdatePOS on MonthEnd
							//If MsgBox("You are requested to do UpdatePOS at this stage, to run some Reports." & vbCrLf & vbCrLf & "NOTE: If you have changed Prices for some items, UpdatePOS will update Terminals." & vbCrLf & vbCrLf & "If you want to Run UpdatePOS now select 'YES' or click 'NO' If you don't want to change the prices on terminals.", vbYesNo) = vbYes Then
							modApplication.blMEndUpdatePOS = true;
							My.MyProject.Forms.frmUpdatePOScriteria.ShowDialog();
							//Else
							//    blMEndUpdatePOS = False
							//End If
							modApplication.blMEndUpdatePOS = false;

							My.MyProject.Forms.frmBarcode.ShowDialog();
						}
					}
					cmdExit_Click(cmdExit, new System.EventArgs());
				}
			}
		}

		private void cmdNext_Click_Auto()
		{
			int GRVInvoiceNumber = 0;
			int PurchaseOrderSupplierID = 0;
			string sql = null;
			bool iSer = false;
			ADODB.Recordset rsC = default(ADODB.Recordset);
			ADODB.Recordset rsPri = default(ADODB.Recordset);
			ADODB.Recordset rBit = default(ADODB.Recordset);
			int gParameter = 0;
			const short gActualAndList_U = 2048;
			const short gLeaveListAct_U = 8192;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();


			rBit = modRecordSet.getRS(ref "SELECT Company_DayEndBit FROM Company");
			gParameter = Convert.ToInt32(0 + rBit.Fields("Company_DayEndBit").Value);

			modApplication.grvPrin = false;
			//If MsgBox("You are about to commit this 'Goods Receiving Voucher' into Stock." & vbCrLf & "Are you sure you wish to continue?", vbQuestion + vbYesNo + vbDefaultButton2, "Commit GRV") = vbYes Then
			iSer = false;
			modApplication.intCurr = 0;

			//Do you want.......
			modApplication.Gr_ID = Conversion.Val(My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value);
			modApplication.Gr_ID = My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value;
			sql = "SELECT * FROM GRVItem WHERE GRVItem_Return = 0 AND GRVItem_GRVID = " + Conversion.Val(My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value);

			//New sql
			sql = "SELECT StockItem.StockItem_SerialTracker, GRVItem.* FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE (((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_GRVID)= " + Conversion.Val(My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value) + "));";
			modApplication.rs_St = modRecordSet.getRS(ref sql);
			modApplication.rs_St.filter = "StockItem_SerialTracker = 1";
			//      If rs_St.RecordCount Then
			//         iSer = True
			//      End If
			//      If iSer = True Then
			modApplication.Grv_Unload = false;
			//         frmSerialNumber.show 1
			//      End If
			modRecordSet.cnnDB.Execute("UPDATE SerialTracking SET Serial_GRV_ID = " + modApplication.Gr_ID + ", Serial_Status = 'Received' WHERE Serial_Status = 'GRV_START';");
			ADODB.Recordset rsPur = default(ADODB.Recordset);
			ADODB.Recordset rsQty = default(ADODB.Recordset);
			decimal cQty = default(decimal);
			bool QtyChk = false;
			ADODB.Recordset rsID = default(ADODB.Recordset);
			ADODB.Recordset rsSTransGRV = default(ADODB.Recordset);
			short x = 0;
			ADODB.Recordset rsChk = default(ADODB.Recordset);
			if (modApplication.Grv_Unload == true) {
				saveDetails();
				this.Close();
			} else {


				saveDetails();
				modRecordSet.cnnDB.BeginTrans();

				SaveIntoTable();
				//Save serial number's into tables


				modRecordSet.cnnDB.Execute("UPDATE GRV, Company SET GRV.GRV_ContentExclusive = " + Convert.ToDecimal(lblContentExclusiveIn.Text) + ", GRV.GRV_DayEndID = [Company]![Company_DayEndID], GRV.GRV_GRVStatusID = 3, GRV.GRV_Date = Now(), GRV.GRV_InvoiceInclusive = " + Convert.ToDecimal(this.lblTotal.Text) + ", GRV_InvoiceVat = " + Convert.ToDecimal(Convert.ToDecimal(this.lblOutBoundVat.Text) - Convert.ToDecimal(this.lblInBoundVat.Text)) + ", GRV.GRV_InvoiceDiscount = " + Convert.ToDecimal(this.lblDiscount.Text) + ", GRV.GRV_Ullage = " + Convert.ToDecimal(this.txtUllage.Text) + ", GRV.GRV_SundriesPlus = " + Convert.ToDecimal(this.txtPlus.Text) + ", GRV.GRV_SundriesMinus = " + Convert.ToDecimal(0 - Convert.ToDecimal(this.txtMinus.Text)) + ", GRV.GRV_Terms = " + Convert.ToInt32(cmbPayment.SelectedIndex) + " WHERE (((GRV.GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + "));");
				modRecordSet.cnnDB.Execute("UPDATE Warehouse INNER JOIN (GRVItem INNER JOIN WarehouseStockItemLnk ON GRVItem.GRVItem_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID SET GRVItem.GRVItem_WarehouseQuantity = [GRVItem]![GRVItem_WarehouseQuantity]+[WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((Warehouse.Warehouse_Saleable)<>0));");
				modRecordSet.cnnDB.Execute("UPDATE (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID SET GRVItem.GRVItem_DepositCost = [Deposit_UnitCost]*[GRVItem_PackSize] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + "));");
				modRecordSet.cnnDB.Execute("UPDATE (GRVItem INNER JOIN StockItem ON (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize) AND (GRVItem.GRVItem_StockItemID = StockItem.StockItemID)) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID SET GRVItem.GRVItem_DepositCost = [GRVItem_DepositCost]+[Deposit_CaseCost] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + "));");
				//cnnDB.Execute "UPDATE Vat INNER JOIN (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) ON Vat.VatID = StockItem.StockItem_VatID SET GRVItem.GRVItem_VatRate = [Vat]![Vat_Amount] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & "));"
				modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET GRVItem.GRVItem_OldActualCost = [StockItem]![StockItem_ActualCost], GRVItem.GRVItem_StockItemQuantity = [StockItem]![StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + "));");

				//Do Actual Cost
				modRecordSet.cnnDB.Execute("UPDATE GRVItem SET GRVItem.GRVItem_ActualCost = [GRVItem_ContentCost]-[GRVItem_DiscountAmount] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + "));");
				modRecordSet.cnnDB.Execute("UPDATE GRV INNER JOIN GRVItem ON GRV.GRVID = GRVItem.GRVItem_GRVID SET GRVItem.GRVItem_ActualCost = ([GRVItem_ActualCost]+([GRVItem_ActualCost]*(([GRV_InvoiceDiscount]+[GRV_Ullage]+[GRV_SundriesPlus]+[GRV_SundriesMinus])/([GRV_ContentExclusive]+0.0001)))) WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=0));");

				//sql = "INSERT INTO PriceChannelLnk (PriceChannelLnk_StockItemID, PriceChannelLnk_Quantity, PriceChannelLnk_ChannelID, PriceChannelLnk_Price) VALUES (" & gStockItemID & ", " & frmItem(x).Tag & ", " & gChannelID & ", " & Replace(txtPrice(x).Text, ",", "") & ")"
				//cnnDB.Execute "UPDATE PriceChannelLnk INNER JOIN GRVItem ON (PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID) AND (GRVItem.GRVItem_StockItemQuantity = PriceChannelLnk.PriceChannelLnk_Quantity) SET PriceChannelLnk.PriceChannelLnk_Price = ([GRVItem_Price]) WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0));"
				//cnnDB.Execute "UPDATE PriceChannelLnk INNER JOIN GRVItem ON ((PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID) AND (PriceChannelLnk.PriceChannelLnk_Quantity=1) AND (PriceChannelLnk.PriceChannelLnk_ChannelID=1)) SET PriceChannelLnk.PriceChannelLnk_Price = ([GRVItem_Price]) WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0));"
				modRecordSet.cnnDB.Execute("UPDATE PriceChannelLnk INNER JOIN GRVItem ON ((PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID)) SET PriceChannelLnk.PriceChannelLnk_Price = ([GRVItem_Price]) WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=0) AND ((PriceChannelLnk.PriceChannelLnk_Quantity)=1)  AND ((PriceChannelLnk.PriceChannelLnk_ChannelID)=1));");

				//to check for Actual cost
				rsC = modRecordSet.getRS(ref "SELECT Company_GRVCost FROM Company;");
				if (rsC.Fields("Company_GRVCost").Value == true) {


					//If gParameter And gActualAndList_U = 2048 Then
					//    'Actual Update...
					//    cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = (((([StockItem_ActualCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
					//    cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
					//
					//    'cnnDB.Execute "UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_ContentCost = (GRVItem.GRVItem_ContentCost * StockItem.StockItem_Quantity) Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS("GRVID") & ") And (GRVItem_Return=0)"
					//    'cnnDB.Execute "UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_ContentCost = (GRVItem.GRVItem_ContentCost * GRVItem.GRVItem_Quantity) Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS("GRVID") & ") And (GRVItem_Return=0)"
					//    'List Update...
					//    cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ListCost = (((([StockItem_ListCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
					//    cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ListCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
					//
					// commented due to changes option
					//Else
					//
					//    cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = (((([StockItem_ActualCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
					//    cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
					//End If
					//cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = (((([StockItem_ActualCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
					//cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));"

					//to check for Actual cost >>> cnnDB.Execute "UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_WarehouseQuantity)<=0) AND ((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((StockItem.StockItem_ActualCostChange)<>True));"

				} else {


					//If gParameter And gActualAndList_U = 2048 Then
					if (System.Math.Abs(Convert.ToInt32(Convert.ToBoolean(rBit.Fields("Company_DayEndBit").Value & gActualAndList_U)))) {
						//Actual Update...
						modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = (((([StockItem_ActualCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));");
						modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));");

						//cnnDB.Execute "UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_ContentCost = (GRVItem.GRVItem_ContentCost * StockItem.StockItem_Quantity) Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS("GRVID") & ") And (GRVItem_Return=0)"
						//cnnDB.Execute "UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET GRVItem.GRVItem_ContentCost = (GRVItem.GRVItem_ContentCost * GRVItem.GRVItem_Quantity) Where (GRVItem_GRVID = " & frmGRV.adoPrimaryRS("GRVID") & ") And (GRVItem_Return=0)"
						//List Update...
						modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ListCost = (((([StockItem_ListCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));");
						modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ListCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));");

					} else {
						//commened for wronge calculation and changed to LIST COST in below line cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = (((([StockItem_ActualCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
						modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = (((([StockItem_ActualCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));");
						modRecordSet.cnnDB.Execute("UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));");
					}
					//cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = (((([StockItem_ActualCost]/[StockItem_Quantity])*[GRVItem_WarehouseQuantity]))+(([GRVItem_actualcost]/[StockItem_Quantity])*[GRVItem_PackSize]*[GRVItem_Quantity]))/([GRVItem_Quantity]*[GRVItem_PackSize]+[GRVItem_WarehouseQuantity])*[StockItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND (([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity])<>0) AND ((StockItem.StockItem_ActualCostChange)<>True));"
					//cnnDB.Execute "UPDATE StockItem INNER JOIN GRVItem ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND ([GRVItem_PackSize]*[GRVItem_Quantity]+[GRVItem_WarehouseQuantity]=0) AND ((StockItem.StockItem_ActualCostChange)<>True));"

					//commenting due to Wronge formula of sundries
					modRecordSet.cnnDB.Execute("UPDATE GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET StockItem.StockItem_ActualCost = [GRVItem]![GRVItem_ActualCost] WHERE (((GRVItem.GRVItem_WarehouseQuantity)<=0) AND ((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((StockItem.StockItem_ActualCostChange)<>True));");


				}
				//end of to check for Actual cost

				//Warehouse StockItem
				modRecordSet.cnnDB.Execute("UPDATE GRVItem INNER JOIN WarehouseStockItemLnk ON GRVItem.GRVItem_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk_Quantity]+[GRVItem_PackSize]*[GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));");
				modRecordSet.cnnDB.Execute("UPDATE GRVItem INNER JOIN WarehouseStockItemLnk ON GRVItem.GRVItem_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk_Quantity]-[GRVItem_PackSize]*[GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=1) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));");

				modRecordSet.cnnDB.Execute("UPDATE PurchaseOrderItem INNER JOIN (GRV INNER JOIN GRVItem ON GRV.GRVID = GRVItem.GRVItem_GRVID) ON (PurchaseOrderItem.PurchaseOrderItem_StockItemID = GRVItem.GRVItem_StockItemID) AND (PurchaseOrderItem.PurchaseOrderItem_PurchaseOrderID = GRV.GRV_PurchaseOrderID) SET PurchaseOrderItem.PurchaseOrderItem_QuantityDelivered = [GRVItem_Quantity]*[GRVItem_PackSize]+[PurchaseOrderItem_QuantityDelivered] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=0));");

				//cnnDB.Execute "UPDATE (Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN GRVItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = GRVItem.GRVItem_StockItemID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV = [DayEndStockItemLnk_QuantityGRV]+[GRVItem_PackSize]*[GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0));"
				//cnnDB.Execute "UPDATE (Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN GRVItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = GRVItem.GRVItem_StockItemID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV = [DayEndStockItemLnk_QuantityGRV]-[GRVItem_PackSize]*[GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=1));"

				//Stock item Deposits
				modRecordSet.cnnDB.Execute("UPDATE ((Deposit INNER JOIN WarehouseDepositItemLnk ON Deposit.DepositID = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID) INNER JOIN StockItem ON Deposit.DepositID = StockItem.StockItem_DepositID) INNER JOIN GRVItem ON (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize) AND (StockItem.StockItemID = GRVItem.GRVItem_StockItemID) SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_Quantity]+[GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=0) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=1) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2));");
				modRecordSet.cnnDB.Execute("UPDATE ((Deposit INNER JOIN WarehouseDepositItemLnk ON Deposit.DepositID = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID) INNER JOIN StockItem ON Deposit.DepositID = StockItem.StockItem_DepositID) INNER JOIN GRVItem ON (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize) AND (StockItem.StockItemID = GRVItem.GRVItem_StockItemID) SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_Quantity]-[GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVItem.GRVItem_Return)=1) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=1) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2));");

				//cnnDB.Execute "UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN ((Deposit INNER JOIN StockItem ON Deposit.DepositID = StockItem.StockItem_DepositID) INNER JOIN GRVItem ON (StockItem.StockItemID = GRVItem.GRVItem_StockItemID) AND (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize)) ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = Deposit.DepositID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]+[GRVItem]![GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=1));"
				//cnnDB.Execute "UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN ((Deposit INNER JOIN StockItem ON Deposit.DepositID = StockItem.StockItem_DepositID) INNER JOIN GRVItem ON (StockItem.StockItemID = GRVItem.GRVItem_StockItemID) AND (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize)) ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = Deposit.DepositID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]-[GRVItem]![GRVItem_Quantity] WHERE (((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVItem.GRVItem_Return)<>0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=1));"

				//deposits
				modRecordSet.cnnDB.Execute("UPDATE Vat INNER JOIN (SupplierDepositLnk INNER JOIN ((PurchaseOrder INNER JOIN GRV ON PurchaseOrder.PurchaseOrderID = GRV.GRV_PurchaseOrderID) INNER JOIN (Deposit INNER JOIN GRVDeposit ON Deposit.DepositID = GRVDeposit.GRVDeposit_DepositID) ON GRV.GRVID = GRVDeposit.GRVDeposit_GRVID) ON (SupplierDepositLnk.SupplierDepositLnk_Type = GRVDeposit.GRVDeposit_Type) AND (SupplierDepositLnk.SupplierDepositLnk_DepositID = Deposit.DepositID) AND (SupplierDepositLnk.SupplierDepositLnk_SupplierID = PurchaseOrder.PurchaseOrder_SupplierID)) ON Vat.VatID = Deposit.Deposit_VatID SET GRVDeposit.GRVDeposit_Name = [SupplierDepositLnk]![SupplierDepositLnk_Name], GRVDeposit.GRVDeposit_UnitCost = [Deposit]![Deposit_UnitCost], GRVDeposit.GRVDeposit_CaseCost = [Deposit]![Deposit_CaseCost], GRVDeposit.GRVDeposit_CaseQuantity = [Deposit]![Deposit_Quantity], GRVDeposit.GRVDeposit_VatRate = [Vat]![Vat_Amount] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + "));");

				//units
				modRecordSet.cnnDB.Execute("UPDATE WarehouseDepositItemLnk INNER JOIN GRVDeposit ON WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_Quantity]-[GRVDeposit_Quantity]*[GRVDeposit_CaseQuantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=0) AND ((GRVDeposit.GRVDeposit_Type)=1 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=0));");
				modRecordSet.cnnDB.Execute("UPDATE WarehouseDepositItemLnk INNER JOIN GRVDeposit ON WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_Quantity]+[GRVDeposit_Quantity]*[GRVDeposit_CaseQuantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=0) AND ((GRVDeposit.GRVDeposit_Type)=1 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=1));");

				//cnnDB.Execute "UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN GRVDeposit ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]-[GRVDeposit_Quantity]*[GRVDeposit_CaseQuantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVDeposit.GRVDeposit_Type)=1 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=0));"
				//cnnDB.Execute "UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN GRVDeposit ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]+[GRVDeposit_Quantity]*[GRVDeposit_CaseQuantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVDeposit.GRVDeposit_Type)=1 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)<>0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=0));"

				//cnnDB.Execute "UPDATE WarehouseDepositItemLnk INNER JOIN GRVDeposit ON WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_DepositTypeID]-[GRVDeposit_Quantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=1) AND ((GRVDeposit.GRVDeposit_Type)=2 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=0));"
				//cnnDB.Execute "UPDATE WarehouseDepositItemLnk INNER JOIN GRVDeposit ON WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_DepositTypeID]+[GRVDeposit_Quantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=1) AND ((GRVDeposit.GRVDeposit_Type)=2 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=1));"
				//FIXED: was not updating Case QTY correct
				modRecordSet.cnnDB.Execute("UPDATE WarehouseDepositItemLnk INNER JOIN GRVDeposit ON WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_Quantity]-[GRVDeposit_Quantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=1) AND ((GRVDeposit.GRVDeposit_Type)=2 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=0));");
				modRecordSet.cnnDB.Execute("UPDATE WarehouseDepositItemLnk INNER JOIN GRVDeposit ON WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk_Quantity]+[GRVDeposit_Quantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=2) AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=1) AND ((GRVDeposit.GRVDeposit_Type)=2 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=1));");

				//cnnDB.Execute "UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN GRVDeposit ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]-[GRVDeposit_Quantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVDeposit.GRVDeposit_Type)=2 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=1));"
				//cnnDB.Execute "UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN GRVDeposit ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]+[GRVDeposit_Quantity] WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((GRVDeposit.GRVDeposit_Type)=2 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((GRVDeposit.GRVDeposit_Return)<>0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=1));"


				if (this.optClose[0].Checked) {
					modRecordSet.cnnDB.Execute("UPDATE GRV INNER JOIN PurchaseOrder ON GRV.GRV_PurchaseOrderID = PurchaseOrder.PurchaseOrderID SET PurchaseOrder.PurchaseOrder_PurchaseOrderStatusID = 3 WHERE (((GRV.GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + "));");
				}
				modRecordSet.cnnDB.Execute("INSERT INTO SupplierTransaction ( SupplierTransaction_SupplierID, SupplierTransaction_TransactionTypeID, SupplierTransaction_MonthEndID, SupplierTransaction_MonthEndIDFor, SupplierTransaction_DayEndID, SupplierTransaction_ReferenceID, SupplierTransaction_Date, SupplierTransaction_Description, SupplierTransaction_Amount, SupplierTransaction_Reference ) SELECT PurchaseOrder.PurchaseOrder_SupplierID, 2 AS transType, DayEnd.DayEnd_MonthEndID, DayEnd.DayEnd_MonthEndID, GRV.GRV_DayEndID, GRV.GRVID, GRV.GRV_InvoiceDate, '' AS [Desc], GRV.GRV_InvoiceInclusive, GRV.GRV_InvoiceNumber FROM DayEnd INNER JOIN (PurchaseOrder INNER JOIN GRV ON PurchaseOrder.PurchaseOrderID = GRV.GRV_PurchaseOrderID) ON DayEnd.DayEndID = GRV.GRV_DayEndID Where (((GRV.GRVID) = " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + "));");
				modRecordSet.cnnDB.Execute("UPDATE GRV INNER JOIN (Supplier INNER JOIN PurchaseOrder ON Supplier.SupplierID = PurchaseOrder.PurchaseOrder_SupplierID) ON GRV.GRV_PurchaseOrderID = PurchaseOrder.PurchaseOrderID SET Supplier.Supplier_Current = [Supplier]![Supplier_Current]+[GRV]![GRV_InvoiceInclusive] WHERE (((GRV.GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + "));");

				//to check for Actual cost
				rsC = modRecordSet.getRS(ref "SELECT Company_GRVCost FROM Company;");
				if (rsC.Fields("Company_GRVCost").Value == true) {
					modRecordSet.cnnDB.Execute("UPDATE Company, GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET StockItem.StockItem_LastCost = [Company_DayEndID], StockItem.StockItem_ActualCost = [GRVItem_ContentCost] WHERE (((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_ContentCost)<>[StockItem_ListCost]) AND ((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + "));");
				} else {
					//If gParameter And gLeaveListAct_U = 8192 Then
					if (System.Math.Abs(Convert.ToInt32(Convert.ToBoolean(rBit.Fields("Company_DayEndBit").Value & gLeaveListAct_U)))) {
					} else {
						modRecordSet.cnnDB.Execute("UPDATE Company, GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID SET StockItem.StockItem_LastCost = [Company_DayEndID], StockItem.StockItem_ListCost = [GRVItem_ContentCost] WHERE (((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_ContentCost)<>[StockItem_ListCost]) AND ((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + "));");
					}
				}

				modRecordSet.cnnDB.Execute("INSERT INTO systemStockItemPricing ( systemStockItemPricing ) SELECT PriceChannelLnk.PriceChannelLnk_StockItemID FROM systemStockItemPricing RIGHT JOIN (PriceChannelLnk INNER JOIN GRVItem ON (PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID) AND (PriceChannelLnk.PriceChannelLnk_Quantity = GRVItem.GRVItem_PackSize)) ON systemStockItemPricing.systemStockItemPricing = PriceChannelLnk.PriceChannelLnk_StockItemID WHERE (((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((PriceChannelLnk.PriceChannelLnk_ChannelID)=1) AND ((systemStockItemPricing.systemStockItemPricing) Is Null) AND ((PriceChannelLnk.PriceChannelLnk_Price)<>[GRVItem_Price]));");
				//cnnDB.Execute "UPDATE PriceChannelLnk INNER JOIN GRVItem ON (PriceChannelLnk.PriceChannelLnk_Quantity = GRVItem.GRVItem_PackSize) AND (PriceChannelLnk.PriceChannelLnk_StockItemID = GRVItem.GRVItem_StockItemID) SET PriceChannelLnk.PriceChannelLnk_Price = [GRVItem_Price] WHERE (((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & ") AND ((PriceChannelLnk.PriceChannelLnk_ChannelID)=1) AND ((PriceChannelLnk.PriceChannelLnk_Price)<>[GRVItem_Price]));"

				FlushMemoryArrays();
				//Reset arrays
				modApplication.intCurr = 0;


				modRecordSet.cnnDB.CommitTrans();

				doDiskFlush();

				modApplication.report_GRV(ref My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value);

				//check for Order QTY

				modRecordSet.cnnDB.Execute("DELETE * from StockTransferGRV;");
				QtyChk = false;
				rsQty = modRecordSet.getRS(ref "SELECT GRVItem.GRVItem_StockItemID, GRVItem_QuantityOrder, GRVItem.GRVItem_Quantity FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE GRVItem_GRVID = " + Conversion.Val(My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value) + ";");
				while (!(rsQty.EOF)) {
					if (rsQty.Fields("GRVItem_Quantity").Value > 0) {
						if (rsQty.Fields("GRVItem_Quantity").Value < rsQty.Fields("GRVItem_QuantityOrder").Value) {
							cQty = rsQty.Fields("GRVItem_QuantityOrder").Value - rsQty.Fields("GRVItem_Quantity").Value;
							modRecordSet.cnnDB.Execute("INSERT INTO StockTransferGRV ( StockTransfer_StockItemID, StockTransfer_Quantity, StockTransfer_Price ) SELECT " + rsQty.Fields("GRVItem_StockItemID").Value + ", " + cQty + ", " + 0);
							QtyChk = true;
						}
					}
					rsQty.moveNext();
				}

				if (QtyChk == true) {

					PurchaseOrderSupplierID = 2;
					GRVInvoiceNumber = "BackOrder";
					rsPur = modRecordSet.getRS(ref "SELECT PurchaseOrder.PurchaseOrder_SupplierID, GRV.GRV_InvoiceNumber, GRV.GRVID FROM PurchaseOrder INNER JOIN GRV ON PurchaseOrder.PurchaseOrderID = GRV.GRV_PurchaseOrderID WHERE (((GRV.GRVID)=" + Conversion.Val(My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value) + "));");
					if (rsPur.RecordCount) {
						PurchaseOrderSupplierID = rsPur.Fields("PurchaseOrder_SupplierID").Value;
						GRVInvoiceNumber = rsPur.Fields("GRV_InvoiceNumber").Value;
					}

					if (Interaction.MsgBox("GRV Qty for some items is less then Actual Ordered Qty. Do you want to log an Order for balance Qty?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.ApplicationModal + MsgBoxStyle.DefaultButton1, _4PosBackOffice.NET.My.MyProject.Application.Info.Title) == MsgBoxResult.Yes) {
						sql = "INSERT INTO PurchaseOrder ( PurchaseOrder_SupplierID, PurchaseOrder_DayEndID, PurchaseOrder_PersonID, PurchaseOrder_DateCreated, PurchaseOrder_PurchaseOrderStatusID, PurchaseOrder_Reference, PurchaseOrder_AttentionLine ) ";
						sql = sql + "SELECT " + PurchaseOrderSupplierID + ", Company.Company_DayEndID, " + modRecordSet.gPersonID + ", Now(), 1, '" + Strings.Format(DateAndTime.Now, "yyyy mmm dd") + " (Balance Order)', '' FROM Company;";
						modRecordSet.cnnDB.Execute(sql, , ADODB.ExecuteOptionEnum.adExecuteNoRecords);

						rsID = modRecordSet.getRS(ref "SELECT Max(PurchaseOrder.PurchaseOrderID) AS id FROM PurchaseOrder;");
						sql = "INSERT INTO GRV ( GRV_PurchaseOrderID, GRV_DayEndID, GRV_GRVStatusID, GRV_Date, GRV_InvoiceDate, GRV_InvoiceNumber, GRV_InvoiceInclusive, GRV_InvoiceVat, GRV_InvoiceDiscount, GRV_Ullage, GRV_SundriesPlus, GRV_SundriesMinus, GRV_Terms ) SELECT " + rsID.Fields("id").Value + ", Company.Company_DayEndID, 1 AS status, Now(), Now(), '" + (GRVInvoiceNumber + "_" + rsID.Fields("id").Value) + "', 0, 0, 0, 0, 0, 0, 1 FROM Company;";
						modRecordSet.cnnDB.Execute(sql, , ADODB.ExecuteOptionEnum.adExecuteNoRecords);
						if (rsID.State)
							rsID.Close();
						rsID = modRecordSet.getRS(ref "SELECT Max(GRV.GRVID) AS id FROM GRV;");

						x = 1;
						//Set rsSTransGRV = getRS("SELECT StockItem.StockItem_Name, StockTransferGRV.* FROM StockTransferGRV INNER JOIN StockItem ON StockTransferGRV.StockTransfer_StockItemID = StockItem.StockItemID ORDER BY StockItem.StockItem_Name, StockTransferGRV.StockTransfer_Quantity;")
						rsSTransGRV = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, StockTransferGRV.*, GRVItem.GRVItem_PackSize FROM (StockTransferGRV INNER JOIN StockItem ON StockTransferGRV.StockTransfer_StockItemID = StockItem.StockItemID) INNER JOIN GRVItem ON StockTransferGRV.StockTransfer_StockItemID = GRVItem.GRVItem_StockItemID Where (((GRVItem.GRVItem_GRVID) = " + Conversion.Val(My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value) + ")) ORDER BY StockItem.StockItem_Name, StockTransferGRV.StockTransfer_Quantity;");
						while (!(rsSTransGRV.EOF)) {

							rsChk = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + rsSTransGRV.Fields("StockTransfer_StockItemID").Value + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));");
							if (rsChk.RecordCount) {
								sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " + x + ", " + rsID.Fields("id").Value + " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, " + rsSTransGRV.Fields("GRVItem_PackSize").Value + " AS PackSize, " + rsSTransGRV.Fields("StockTransfer_Quantity").Value + " AS QuantityOrder, " + rsSTransGRV.Fields("StockTransfer_Quantity").Value + " AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))";
								sql = sql + " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + rsSTransGRV.Fields("StockTransfer_StockItemID").Value + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));";
								modRecordSet.cnnDB.Execute(sql);
							} else {
								sql = "INSERT INTO GRVItem ( GRVItem_Line, GRVItem_GRVID, GRVItem_StockItemID, GRVItem_Return, GRVItem_Name, GRVItem_Code, GRVItem_PackSize, GRVItem_QuantityOrder, GRVItem_Quantity, GRVItem_ContentCost, GRVItem_DiscountAmount, GRVItem_WarehouseQuantity, GRVItem_ActualCost, GRVItem_Date, GRVItem_VatRate, GRVItem_Price ) SELECT " + x + ", " + rsID.Fields("id").Value + " AS grvid, StockItem.StockItemID, 0 AS return, StockItem.StockItem_Name, '' AS code, " + rsSTransGRV.Fields("GRVItem_PackSize").Value + " AS PackSize, " + rsSTransGRV.Fields("StockTransfer_Quantity").Value + " AS QuantityOrder, " + rsSTransGRV.Fields("StockTransfer_Quantity").Value + " AS quantity, StockItem.StockItem_ListCost, 0 AS discount, 0 AS whQuantity, 0 AS actualCost, Now() AS [date], 0 AS vatRate, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (Catalogue.Catalogue_StockItemID = StockItem.StockItemID))";
								sql = sql + " INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" + rsSTransGRV.Fields("StockTransfer_StockItemID").Value + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));";
								modRecordSet.cnnDB.Execute(sql);
							}

							x = x + 1;
							rsSTransGRV.moveNext();
						}
					}
				}

				//run time error removal of type mismatch
				//Set rsPri = getRS("SELECT GRVItem.GRVItem_StockItemID, GRVItem.GRVItem_Quantity, StockItem.StockItem_SBarcode FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE GRVItem_GRVID = " & Val(frmGRV.adoPrimaryRS("GRVID")) & " AND (StockItem_SBarcode = 'shelf' Or StockItem_SBarcode = 'barcode')")
				//Set rsPri = getRS("SELECT GRVItem.GRVItem_StockItemID, GRVItem.GRVItem_Quantity, StockItem.StockItem_SBarcode FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE GRVItem_GRVID = " & Val(frmGRV.adoPrimaryRS("GRVID")) & " AND (StockItem_SBarcode = True Or StockItem_SShelf = True)")
				rsPri = modRecordSet.getRS(ref "SELECT GRVItem.GRVItem_StockItemID, (GRVItem.GRVItem_Quantity*GRVItem_PackSize) AS GRVItem_Quantity, StockItem.StockItem_SBarcode,StockItem.StockItem_SShelf FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE GRVItem_GRVID = " + Conversion.Val(My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value) + " AND (StockItem_SBarcode = True Or StockItem_SShelf = True)");
				//Write file
				if (rsPri.RecordCount) {
					if (fso.FileExists(modRecordSet.serverPath + "ShelfBarcode.dat"))
						fso.DeleteFile(modRecordSet.serverPath + "ShelfBarcode.dat", true);
					rsPri.save(modRecordSet.serverPath + "ShelfBarcode.dat", ADODB.PersistFormatEnum.adPersistADTG);
					modApplication.grvPrin = true;
					if (Interaction.MsgBox("Do you want to do Shelf/Barcode Printing on flagged StockItems?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.ApplicationModal + MsgBoxStyle.DefaultButton1, _4PosBackOffice.NET.My.MyProject.Application.Info.Title) == MsgBoxResult.Yes) {

						//For Auto UpdatePOS on MonthEnd
						//If MsgBox("You are requested to do UpdatePOS at this stage, to run some Reports." & vbCrLf & vbCrLf & "NOTE: If you have changed Prices for some items, UpdatePOS will update Terminals." & vbCrLf & vbCrLf & "If you want to Run UpdatePOS now select 'YES' or click 'NO' If you don't want to change the prices on terminals.", vbYesNo) = vbYes Then
						modApplication.blMEndUpdatePOS = true;
						My.MyProject.Forms.frmUpdatePOScriteria.ShowDialog();
						//Else
						//    blMEndUpdatePOS = False
						//End If
						modApplication.blMEndUpdatePOS = false;

						My.MyProject.Forms.frmBarcode.ShowDialog();
					}
				}
				cmdExit_Click(cmdExit, new System.EventArgs());
			}
			//End If
		}

		private void doDiskFlush()
		{
			Scripting.TextStream lTextstream = default(Scripting.TextStream);
			string Key = null;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			int hkey = 0;
			int lRetVal = 0;
			int vValue = 0;
			string lPath = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			int GRVID = 0;
			int lCompanyID = 0;
			string lString = null;
			int lCNT = 0;

			GRVID = My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value;
			lRetVal = modUtilities.RegOpenKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\4POS", 0, modUtilities.KEY_QUERY_VALUE, ref hkey);
			lRetVal = modUtilities.QueryValueEx(hkey, "master", ref vValue);
			modUtilities.RegCloseKey(hkey);


			if (string.IsNullOrEmpty(vValue)) {
				return;
			} else {
				lPath = vValue;
			}

			rs = modRecordSet.getRS(ref "SELECT 'grv' AS type, Company.CompanyID, PurchaseOrder.PurchaseOrder_SupplierID, GRV.GRVID, GRV.GRV_DayEndID, GRV.GRV_GRVStatusID, GRV.GRV_Date, GRV.GRV_InvoiceNumber, GRV.GRV_InvoiceDate, GRV.GRV_InvoiceInclusive, GRV.GRV_InvoiceVat, GRV.GRV_InvoiceDiscount, GRV.GRV_Ullage, GRV.GRV_SundriesPlus, GRV.GRV_SundriesMinus, GRV.GRV_ContentExclusive, GRV.GRV_Terms, GRV.GRV_Notes FROM Company, GRV INNER JOIN PurchaseOrder ON GRV.GRV_PurchaseOrderID = PurchaseOrder.PurchaseOrderID WHERE (((GRV.GRVID)=" + GRVID + ") AND ((GRV.GRV_GRVStatusID)=3));");
			if (rs.RecordCount) {
				Key = rs.Fields("CompanyID").Value + "_" + rs.Fields("PurchaseOrder_SupplierID").Value + "_";
				lCompanyID = rs.Fields("CompanyID").Value;
				lString = getDelimeter(ref rs);
				rs = modRecordSet.getRS(ref "SELECT 'item' AS type, GRVItem.* From GRVItem WHERE (((GRVItem.GRVItem_GRVID)=" + GRVID + "));");
				if (rs.RecordCount)
					lString = lString + Strings.Chr(255) + getDelimeter(ref rs);

				rs = modRecordSet.getRS(ref "SELECT 'deposit' AS type, GRVDeposit.* From GRVDeposit WHERE (((GRVDeposit.GRVDeposit_GRVID)=" + GRVID + "));");
				if (rs.RecordCount)
					lString = lString + Strings.Chr(255) + getDelimeter(ref rs);
				lCNT = 1;
				while (fso.FileExists(modRecordSet.serverPath + Key + lCNT + ".grv")) {
					lCNT = lCNT + 1;
				}

				lTextstream = fso.OpenTextFile(modRecordSet.serverPath + Key + lCNT + ".grv", Scripting.IOMode.ForWriting, true);
				lTextstream.Write(lString);
				lTextstream.Close();
			}
		}

		private string getDelimeter(ref ADODB.Recordset rs)
		{
			string functionReturnValue = null;
			string lString1 = null;
			string lString2 = null;
			ADODB.Field lField = default(ADODB.Field);
			lString1 = "";
			while (!(rs.EOF)) {
				lString2 = "";
				foreach ( lField in rs.Fields) {
					if (Information.IsDBNull(lField.Value)) {
						lString2 = lString2 + Strings.Chr(254) + Strings.Chr(253);
					} else {
						switch (lField.Type) {
							case 7:
								lString2 = lString2 + Strings.Chr(254) + Strings.Format(lField.Value, "yyyy/MM/dd");
								break;
							case 202:
								lString2 = lString2 + Strings.Chr(254) + lField.Value;
								break;
							default:
								lString2 = lString2 + Strings.Chr(254) + lField.Value;
								break;
						}
					}
				}
				lString1 = lString1 + Strings.Chr(255) + Strings.Mid(lString2, 2);
				rs.moveNext();
			}
			if (string.IsNullOrEmpty(lString1)) {
				functionReturnValue = "";
			} else {
				functionReturnValue = Strings.Mid(lString1, 2);
			}
			return functionReturnValue;
		}

		private void saveDetails()
		{
			string sql = null;
			if (this.Visible) {
				this.cmdNext.Focus();
				System.Windows.Forms.Application.DoEvents();
				sql = "UPDATE GRV SET GRV_SundriesPlus = " + Convert.ToDecimal(this.txtPlus.Text) + ", GRV_SundriesMinus = " + Convert.ToDecimal(this.txtMinus.Text) + ", GRV_Notes = '" + Strings.Replace(txtNotes.Text, "'", "''") + "' Where (GRVID = " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ")";
				modRecordSet.cnnDB.Execute(sql);

			}
		}
		public void FlushMemoryArrays()
		{
			short p = 0;

			for (p = 0; p <= 100; p++) {
				modApplication.intArrayName[p] = "";
				modApplication.intArraySCode[p] = 0;
				modApplication.tempStockItem[p] = "";
			}
		}

		private void setTotals()
		{
			string sql = null;
			decimal lExclusive = default(decimal);
			decimal lVat = default(decimal);
			ADODB.Recordset rs = default(ADODB.Recordset);

			lblLinesIn.Text = Convert.ToString(0);
			lblVatRateIn.Text = "0.00";
			lblDiscountLineIn.Text = "0.00";
			lblLinesOut.Text = Convert.ToString(0);
			lblVatRateOut.Text = "0.00";
			lblDiscountLineOut.Text = "0.00";
			lblInclusiveOut.Text = "0.00";
			//    Set rs = getRS("SELECT Sum([GRVItem_PackSize]/[StockItem_Quantity]*[GRVItem_ContentCost]*[GRVItem_Quantity]-[GRVItem_DiscountAmount]*[GRVItem_Quantity]) AS exclusive, Sum([GRVItem_DiscountAmount]*[GRVItem_Quantity]) AS discount, Sum(([GRVItem_PackSize]/[StockItem_Quantity]*[GRVItem_ContentCost]*[GRVItem_Quantity]-[GRVItem_DiscountAmount]*[GRVItem_Quantity])*([Vat_Amount]/100)) AS vat, GRVItem.GRVItem_Return, Count(GRVItem.GRVItem_GRVID) AS itemCount FROM (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID Where (((GRVItem.GRVItem_GRVID) = " & frmGRV.adoPrimaryRS("GRVID") & ")) GROUP BY GRVItem.GRVItem_Return HAVING (((GRVItem.GRVItem_Return)=0));")
			rs = modRecordSet.getRS(ref "SELECT Sum([GRVItem_PackSize]/[StockItem_Quantity]*[GRVItem_ContentCost]*[GRVItem_Quantity]-[GRVItem_DiscountAmount]*[GRVItem_Quantity]) AS exclusive, Sum([GRVItem_DiscountAmount]*[GRVItem_Quantity]) AS discount, Sum(([GRVItem_PackSize]/[StockItem_Quantity]*[GRVItem_ContentCost]*[GRVItem_Quantity]-[GRVItem_DiscountAmount]*[GRVItem_Quantity])*([GRVItem_VatRate]/100)) AS vat, GRVItem.GRVItem_Return, Count(GRVItem.GRVItem_GRVID) AS itemCount FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID Where (((GRVItem.GRVItem_GRVID) = " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ")) GROUP BY GRVItem.GRVItem_Return HAVING (((GRVItem.GRVItem_Return)=0));");
			if (rs.BOF | rs.EOF) {
			} else {
				lVat = (Information.IsDBNull(rs.Fields("vat").Value) ? 0 : rs.Fields("vat").Value);
				lblLinesIn.Text = rs.Fields("itemCount").Value;
				lExclusive = (Information.IsDBNull(rs.Fields("exclusive").Value) ? 0 : rs.Fields("exclusive").Value);
				if (lExclusive) {
					lblVatRateIn.Text = Strings.FormatNumber(lVat / lExclusive * 100, 2);
				} else {
					lblVatRateIn.Text = Strings.FormatNumber(0, 2);
				}

				lblContentExclusiveIn.Text = Strings.FormatNumber(lExclusive, 2);
				this.lblDiscountLineIn.Text = Strings.FormatNumber(rs.Fields("discount").Value, 2);
				this.lblContentIn.Text = Strings.FormatNumber(Convert.ToDecimal(lblContentExclusiveIn.Text) + Convert.ToDecimal(lblDiscountLineIn.Text), 2);
			}
			//    Set rs = getRS("SELECT Sum([GRVItem_PackSize]/[StockItem_Quantity]*[GRVItem_ContentCost]*[GRVItem_Quantity]-[GRVItem_DiscountAmount]*[GRVItem_Quantity]) AS exclusive, Sum([GRVItem_DiscountAmount]*[GRVItem_Quantity]) AS discount, Sum(([GRVItem_PackSize]/[StockItem_Quantity]*[GRVItem_ContentCost]*[GRVItem_Quantity]-[GRVItem_DiscountAmount]*[GRVItem_Quantity])*([Vat_Amount]/100)) AS vat, GRVItem.GRVItem_Return, Count(GRVItem.GRVItem_GRVID) AS itemCount FROM (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID Where (((GRVItem.GRVItem_GRVID) = " & frmGRV.adoPrimaryRS("GRVID") & ")) GROUP BY GRVItem.GRVItem_Return HAVING (((GRVItem.GRVItem_Return)=1));")
			rs = modRecordSet.getRS(ref "SELECT Sum([GRVItem_PackSize]/[StockItem_Quantity]*[GRVItem_ContentCost]*[GRVItem_Quantity]-[GRVItem_DiscountAmount]*[GRVItem_Quantity]) AS exclusive, Sum([GRVItem_DiscountAmount]*[GRVItem_Quantity]) AS discount, Sum(([GRVItem_PackSize]/[StockItem_Quantity]*[GRVItem_ContentCost]*[GRVItem_Quantity]-[GRVItem_DiscountAmount]*[GRVItem_Quantity])*([GRVItem_VatRate]/100)) AS vat, GRVItem.GRVItem_Return, Count(GRVItem.GRVItem_GRVID) AS itemCount FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID Where (((GRVItem.GRVItem_GRVID) = " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ")) GROUP BY GRVItem.GRVItem_Return HAVING (((GRVItem.GRVItem_Return)=1));");
			if (rs.BOF | rs.EOF) {
			} else {
				lVat = rs.Fields("vat").Value;
				lblLinesIn.Text = rs.Fields("itemCount").Value;
				lExclusive = rs.Fields("exclusive").Value;
				if (lExclusive) {
					lblVatRateOut.Text = Strings.FormatNumber(lVat / lExclusive * 100, 2);
				} else {
					lblVatRateOut.Text = Strings.FormatNumber(0, 2);
				}
				lblExclusiveOut.Text = Strings.FormatNumber(lExclusive, 2);
				lblDiscountLineOut.Text = Strings.FormatNumber(rs.Fields("discount").Value, 2);
				lblContentOut.Text = Strings.FormatNumber(Convert.ToDecimal(lblExclusiveOut.Text) + Convert.ToDecimal(lblDiscountLineOut.Text), 2);
				lblVATout.Text = Strings.FormatNumber(Convert.ToDecimal(lblExclusiveOut.Text) * Convert.ToDecimal(lblVatRateOut.Text) / 100, 2);
				lblInclusiveOut.Text = Strings.FormatNumber(Convert.ToDecimal(lblExclusiveOut.Text) + Convert.ToDecimal(lblVATout.Text), 2);

			}
			this.lblDepositIn.Text = "0.00";
			this.lblDepositVatIn.Text = "0.00";
			this.lblDepositVatRateIn.Text = "0.00";
			this.lblDepositInclusiveIn.Text = "0.00";
			this.lblDepositOut.Text = "0.00";
			this.lblDepositVatOut.Text = "0.00";
			this.lblDepositVatRateOut.Text = "0.00";
			this.lblDepositInclusiveOut.Text = "0.00";

			sql = "SELECT GRVItem.GRVItem_Return, Sum(((Abs([StockItem_Quantity]=[GRVItem_PackSize])*[Deposit_CaseCost])+([Deposit_UnitCost]*[GRVItem_PackSize]))*[GRVItem_Quantity]) AS exclusive, Sum((((Abs([StockItem_Quantity]=[GRVItem_PackSize])*[Deposit_CaseCost])+([Deposit_UnitCost]*[GRVItem_PackSize]))*[GRVItem_Quantity])*([Vat_Amount]/100)) AS vat, Avg(Vat.Vat_Amount) AS AvgOfVat_Amount, Count(GRVItem.GRVItem_GRVID) AS CountOfGRVItem_GRVID FROM ((GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID Where (((Deposit.Deposit_UnitCost) <> 0) And ((GRVItem.GRVItem_GRVID) = " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ")) Or (((Deposit.Deposit_CaseCost) <> 0) And ((GRVItem.GRVItem_GRVID) = " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ")) GROUP BY GRVItem.GRVItem_Return HAVING (GRVItem.GRVItem_Return=0);";

			rs = modRecordSet.getRS(ref sql);

			if (rs.BOF | rs.EOF) {
			} else {
				lVat = rs.Fields("vat").Value;
				lExclusive = rs.Fields("exclusive").Value;
				if (lExclusive) {
					lblDepositVatRateIn.Text = Strings.FormatNumber(lVat / lExclusive * 100, 2);
				} else {
					lblDepositVatRateIn.Text = Strings.FormatNumber(0, 2);
				}
				lblDepositIn.Text = Strings.FormatNumber(lExclusive, 2);
				lblDepositVatIn.Text = Strings.FormatNumber(lVat, 2);
				lblDepositInclusiveIn.Text = Strings.FormatNumber(lExclusive + lVat, 2);
			}

			sql = "SELECT GRVItem.GRVItem_Return, Sum(((Abs([StockItem_Quantity]=[GRVItem_PackSize])*[Deposit_CaseCost])+([Deposit_UnitCost]*[GRVItem_PackSize]))*[GRVItem_Quantity]) AS exclusive, Sum((((Abs([StockItem_Quantity]=[GRVItem_PackSize])*[Deposit_CaseCost])+([Deposit_UnitCost]*[GRVItem_PackSize]))*[GRVItem_Quantity])*([Vat_Amount]/100)) AS vat, Avg(Vat.Vat_Amount) AS AvgOfVat_Amount, Count(GRVItem.GRVItem_GRVID) AS CountOfGRVItem_GRVID FROM ((GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID Where (((Deposit.Deposit_UnitCost) <> 0) And ((GRVItem.GRVItem_GRVID) = " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ")) Or (((Deposit.Deposit_CaseCost) <> 0) And ((GRVItem.GRVItem_GRVID) = " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ")) GROUP BY GRVItem.GRVItem_Return HAVING (GRVItem.GRVItem_Return=1);";
			rs = modRecordSet.getRS(ref sql);

			if (rs.BOF | rs.EOF) {
			} else {
				lVat = rs.Fields("vat").Value;
				lExclusive = rs.Fields("exclusive").Value;
				if (lExclusive == 0) {
					lblDepositVatRateOut.Text = Strings.FormatNumber(0, 2);
				} else {
					lblDepositVatRateOut.Text = Strings.FormatNumber(lVat / lExclusive * 100, 2);
				}
				lblDepositOut.Text = Strings.FormatNumber(lExclusive, 2);
				lblDepositVatOut.Text = Strings.FormatNumber(lVat, 2);
				lblDepositInclusiveOut.Text = Strings.FormatNumber(lExclusive + lVat, 2);
			}
			this.lblDepositReturnOut.Text = "0.00";
			this.lblDepositReturnVatOut.Text = "0.00";
			this.lblDepositReturnVatRateOut.Text = "0.00";
			this.lblDepositReturnInclusiveOut.Text = "0.00";

			sql = "SELECT Sum((IIf([GRVDeposit_Type]=1,[Deposit_UnitCost],0)+IIf([GRVDeposit_Type]=2,[Deposit_CaseCost],0)+IIf([GRVDeposit_Type]=3,[Deposit_UnitCost]*[Deposit_Quantity]+[Deposit_CaseCost],0))*[GRVDeposit_Quantity]) AS exclusive, Sum((IIf([GRVDeposit_Type]=1,[Deposit_UnitCost],0)+IIf([GRVDeposit_Type]=2,[Deposit_CaseCost],0)+IIf([GRVDeposit_Type]=3,[Deposit_UnitCost]*[Deposit_Quantity]+[Deposit_CaseCost],0))*[GRVDeposit_Quantity]*[Vat_Amount]/100) AS vat, Count(GRVDeposit.GRVDeposit_GRVID) AS itemCount FROM (Deposit INNER JOIN GRVDeposit ON Deposit.DepositID = GRVDeposit.GRVDeposit_DepositID) INNER JOIN Vat ON Deposit.Deposit_VatID = Vat.VatID WHERE (((GRVDeposit.GRVDeposit_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVDeposit.GRVDeposit_Return)=0));";
			rs = modRecordSet.getRS(ref sql);
			if (rs.BOF | rs.EOF) {
			} else {
				if (Information.IsDBNull(rs.Fields("vat").Value)) {
					lVat = 0;
					lExclusive = 0;
					lblDepositReturnVatRateOut.Text = Strings.FormatNumber(0, 2);
				} else {
					lVat = rs.Fields("vat").Value;
					lExclusive = rs.Fields("exclusive").Value;
					if (lExclusive == 0) {
						lblDepositReturnVatRateOut.Text = Strings.FormatNumber(0, 2);
					} else {
						lblDepositReturnVatRateOut.Text = Strings.FormatNumber(lVat / lExclusive * 100, 2);
					}
				}
				lblDepositReturnOut.Text = Strings.FormatNumber(lExclusive, 2);
				lblDepositReturnVatOut.Text = Strings.FormatNumber(lVat, 2);
				lblDepositReturnInclusiveOut.Text = Strings.FormatNumber(lExclusive + lVat, 2);
			}

			sql = "SELECT Sum((IIf([GRVDeposit_Type]=1,[Deposit_UnitCost],0)+IIf([GRVDeposit_Type]=2,[Deposit_CaseCost],0)+IIf([GRVDeposit_Type]=3,[Deposit_UnitCost]*[Deposit_Quantity]+[Deposit_CaseCost],0))*[GRVDeposit_Quantity]) AS exclusive, Sum((IIf([GRVDeposit_Type]=1,[Deposit_UnitCost],0)+IIf([GRVDeposit_Type]=2,[Deposit_CaseCost],0)+IIf([GRVDeposit_Type]=3,[Deposit_UnitCost]*[Deposit_Quantity]+[Deposit_CaseCost],0))*[GRVDeposit_Quantity]*[Vat_Amount]/100) AS vat, Count(GRVDeposit.GRVDeposit_GRVID) AS itemCount FROM (Deposit INNER JOIN GRVDeposit ON Deposit.DepositID = GRVDeposit.GRVDeposit_DepositID) INNER JOIN Vat ON Deposit.Deposit_VatID = Vat.VatID WHERE (((GRVDeposit.GRVDeposit_GRVID)=" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ") AND ((GRVDeposit.GRVDeposit_Return)=1));";
			rs = modRecordSet.getRS(ref sql);
			if (rs.BOF | rs.EOF) {
			} else {
				if (Information.IsDBNull(rs.Fields("vat").Value)) {
					lVat = 0;
					lExclusive = 0;
					lblDepositReturnVatRateIn.Text = Strings.FormatNumber(0, 2);
				} else {
					lVat = rs.Fields("vat").Value;
					lExclusive = rs.Fields("exclusive").Value;
					if (lExclusive == 0) {
						lblDepositReturnVatRateIn.Text = Strings.FormatNumber(0, 2);
					} else {
						lblDepositReturnVatRateIn.Text = Strings.FormatNumber(lVat / lExclusive * 100, 2);
					}
				}
				lblDepositReturnIn.Text = Strings.FormatNumber(lExclusive, 2);
				lblDepositReturnVatIn.Text = Strings.FormatNumber(lVat, 2);
				lblDepositReturnInclusiveIn.Text = Strings.FormatNumber(lExclusive + lVat, 2);
			}
			this.lblCredit.Text = Strings.FormatNumber(Convert.ToDecimal(lblInclusiveOut.Text) + Convert.ToDecimal(lblDepositInclusiveOut.Text), 2);
			this.lblCreditVat.Text = Strings.FormatNumber(Convert.ToDecimal(this.lblVATout.Text) + Convert.ToDecimal(lblDepositVatOut.Text), 2);
			this.lblInBoundVat.Text = Strings.FormatNumber(Convert.ToDecimal(this.lblCreditVat.Text) + Convert.ToDecimal(lblDepositReturnVatOut.Text), 2);
			this.lblInBound.Text = Strings.FormatNumber(Convert.ToDecimal(this.lblCredit.Text) + Convert.ToDecimal(lblDepositReturnInclusiveOut.Text), 2);

		}


		public void loadSummary()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);

			modBResolutions.ResizeForm(ref this, ref sizeConvertors.pixelToTwips(this.Width, true), ref sizeConvertors.pixelToTwips(this.Height, false), ref 2);


			rs = modRecordSet.getRS(ref "SELECT * FROM GRV WHERE GRVID = " + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value);
			setTotals();

			this.lblSupplier.Text = My.MyProject.Forms.frmGRVitem.lblSupplier.Text;

			this.frmMain.Text = "Summary for Invoice # '" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRV_InvoiceNumber").Value + "'";
			if (Information.IsDBNull(My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("Supplier_Ullage").Value)) {
				this.txtUllage.Text = Strings.FormatNumber("0", 2);
			} else {
				this.txtUllage.Text = Strings.FormatNumber(My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("Supplier_Ullage").Value, 2);
			}
			this.txtDiscount.Text = Strings.FormatNumber("0", 2);
			this.txtMinus.Text = Strings.FormatNumber(rs.Fields("GRV_SundriesMinus").Value, 2);
			this.txtPlus.Text = Strings.FormatNumber(rs.Fields("GRV_SundriesPlus").Value, 2);
			lblTotalOriginal.Text = Strings.FormatNumber(rs.Fields("GRV_InvoiceInclusive").Value, 2);
			if (Information.IsDBNull(rs.Fields("GRV_Notes").Value)) {
				txtNotes.Text = "";
			} else {
				this.txtNotes.Text = rs.Fields("GRV_Notes").Value;
			}
			this.cmbPayment.SelectedIndex = 0;
			cmbPayment_SelectedIndexChanged(cmbPayment, new System.EventArgs());
			doTotals();
			if (modApplication.bolAirTimeGRV == true) {
				tmrAutoGRV.Enabled = true;
			}

			loadLanguage();
			ShowDialog();
		}
		public void SaveIntoTable()
		{
			string sql = null;
			//Save all details into serial tables
			ADODB.Recordset rs = default(ADODB.Recordset);
			short intK = 0;
			short intP = 0;
			short Grv_qty = 0;
			short Grv_Track = 0;
			short UpLoop = 0;
			string SItem = null;

			Grv_qty = 0;
			Grv_Track = 0;

			for (intK = 0; intK <= modApplication.intCurr - 1; intK++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object sql. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sql = "SELECT * FROM GRVItem WHERE GRVItem_StockItemID = " + modApplication.intArraySCode[intK] + " AND GRVItem_Return = 0 AND GRVItem_GRVID = " + modApplication.Gr_ID;
				rs = modRecordSet.getRS(ref sql);

				Grv_qty = (rs.Fields("GRVItem_Quantity").Value - 1);
				UpLoop = Grv_Track + Grv_qty;
				if (rs.RecordCount == 1) {
					for (intP = Grv_Track; intP <= UpLoop; intP++) {
						if (Strings.Mid(Strings.Trim(modApplication.tempStockItem[intP]), 1, 2) == "RT") {
							//Returned
							SItem = Strings.Trim(Strings.Right(Strings.Trim(modApplication.tempStockItem[intP]), Strings.Len(Strings.Trim(modApplication.tempStockItem[intP])) - 2));
							sql = "INSERT INTO SerialTracking (Serial_StockItemID,Serial_SerialNumber,Serial_SupplierName,Serial_DatePurchases,Serial_Status,Serial_GRV_ID) " + "VALUES (" + Conversion.Val(Convert.ToString(modApplication.intArraySCode[intK])) + ",'" + SItem + "','" + Strings.Split(lblSupplier.Text, "(")[0] + "',#" + Convert.ToDateTime(DateAndTime.Today) + "#,'Returned'" + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ")";

						} else {
							//Received
							SItem = Strings.Trim(Strings.Right(Strings.Trim(modApplication.tempStockItem[intP]), Strings.Len(Strings.Trim(modApplication.tempStockItem[intP])) - 2));
							sql = "INSERT INTO SerialTracking (Serial_StockItemID,Serial_SerialNumber,Serial_SupplierName,Serial_DatePurchases,Serial_Status,Serial_GRV_ID) " + "VALUES (" + Conversion.Val(Convert.ToString(modApplication.intArraySCode[intK])) + ",'" + SItem + "','" + Strings.Split(lblSupplier.Text, "(")[0] + "',#" + Convert.ToDateTime(DateAndTime.Today) + "#,'Received'," + My.MyProject.Forms.frmGRV.adoPrimaryRS.Fields("GRVID").Value + ")";
						}

						//UPGRADE_WARNING: Couldn't resolve default property of object sql. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modRecordSet.cnnDB.Execute(sql);

					}

					Grv_Track = intP;
					//Grv_qty + 1
				}


			}

		}



		private void frmGRVSummary_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			saveDetails();
		}


		private void Picture2_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdExit.Left = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(Picture2.ClientRectangle.Width, true) - sizeConvertors.pixelToTwips(cmdExit.Width, true) - 30, true);
			cmdBack.Left = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(cmdExit.Left, true) - sizeConvertors.pixelToTwips(cmdBack.Width, true) - sizeConvertors.pixelToTwips(cmdBack.Width, true) - 150 - 45, true);

		}

		private void tmrAutoGRV_Tick(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (modApplication.bolAirTimeGRV == true) {
				tmrAutoGRV.Enabled = false;
				cmdNext.Focus();
				cmdNext_Click_Auto();
			}
		}

		private void txtDiscount_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtDiscount);
		}

		private void txtDiscount_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			modUtilities.MyKeyPress(ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtDiscount_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtDiscount, ref 2);
			doTotals();
		}

		private void txtMinus_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtMinus);
		}

		private void txtMinus_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			modUtilities.MyKeyPress(ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtMinus_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtMinus, ref 2);
			doTotals();
		}


		private void txtPlus_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtPlus);
		}

		private void txtPlus_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			modUtilities.MyKeyPress(ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtPlus_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtPlus, ref 2);
			doTotals();
		}


		private void txtUllage_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtUllage);
		}

		private void txtUllage_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			modUtilities.MyKeyPress(ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtUllage_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtUllage, ref 2);
			doTotals();
		}

		private void frmGRVSummary_Load(object sender, System.EventArgs e)
		{
			lbl.AddRange(new Label[] {
				_lbl_0,
				_lbl_1,
				_lbl_2,
				_lbl_3,
				_lbl_4,
				_lbl_5,
				_lbl_6,
				_lbl_7,
				_lbl_8,
				_lbl_9,
				_lbl_10,
				_lbl_11,
				_lbl_12,
				_lbl_13,
				_lbl_14,
				_lbl_15,
				_lbl_16,
				_lbl_17,
				_lbl_18,
				_lbl_19,
				_lbl_20,
				_lbl_21,
				_lbl_22,
				_lbl_23,
				_lbl_24,
				_lbl_25,
				_lbl_26,
				_lbl_27,
				_lbl_28,
				_lbl_29,
				_lbl_30,
				_lbl_31,
				_lbl_32,
				_lbl_33,
				_lbl_34,
				_lbl_35,
				_lbl_37
			});
			optClose.AddRange(new RadioButton[] { _optClose_0 });
			Frame1.AddRange(new GroupBox[] {
				_Frame1_0,
				_Frame1_1,
				_Frame1_2,
				_Frame1_3,
				_Frame1_4,
				_Frame1_5
			});
		}
	}
}
