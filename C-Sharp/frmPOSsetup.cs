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
	internal partial class frmPOSsetup : System.Windows.Forms.Form
	{
		private ADODB.Recordset withEventsField_adoPrimaryRS;
		public ADODB.Recordset adoPrimaryRS {
			get { return withEventsField_adoPrimaryRS; }
			set {
				if (withEventsField_adoPrimaryRS != null) {
					withEventsField_adoPrimaryRS.MoveComplete -= adoPrimaryRS_MoveComplete;
					withEventsField_adoPrimaryRS.WillChangeRecord -= adoPrimaryRS_WillChangeRecord;
				}
				withEventsField_adoPrimaryRS = value;
				if (withEventsField_adoPrimaryRS != null) {
					withEventsField_adoPrimaryRS.MoveComplete += adoPrimaryRS_MoveComplete;
					withEventsField_adoPrimaryRS.WillChangeRecord += adoPrimaryRS_WillChangeRecord;
				}
			}
		}
		bool mbChangedByCode;
		int mvBookMark;
		bool mbEditFlag;
		bool mbAddNewFlag;
		bool mbDataChanged;
		bool loading;
		int gID;

		int gLines;
		List<TextBox> txtFields = new List<TextBox>();
		List<TextBox> txtInteger = new List<TextBox>();
		List<TextBox> txtPrice = new List<TextBox>();
		List<RadioButton> optDeposits = new List<RadioButton>();

		List<RadioButton> optPrint = new List<RadioButton>();
		const short bit_deposit1 = 1;
		const short bit_deposit2 = 2;
		const short bit_Sets = 4;
		const short bit_Shrink = 8;
		const short bit_Suppress = 16;
		const short bit_Lines = 32;
		const short bit_SuppressCashup = 64;
		const short bit_BlindDeclaration = 128;
		const short bit_DeclarationQuick = 256;
		const short bit_OpenTill = 512;
		const short bit_autoSearch = 1024;
		const short bit_bypassTender = 2048;
		const short bit_bypassSecurity = 4096;
		const short bit_itemNoReceipt = 8192;
		const short bit_autoLogoff = 16384;
			//Printing exclusive A4 Invoice
		const int bit_A4Paramet = 32768;
			//Card Ref parameter
		const int bit_Cardrefere = 65536;
			//Order Ref parameter
		const int bit_OrderRefer = 131072;
			//Serial Ref parameter
		const int bit_SerialRef = 262144;
		const int bit_SerialTra = 524288;
			//To enable currecncy bit
		const int bit_IntVATPrint = 1048576;
		const int bit_LearningPOS = 2097152;
		const int bit_DisplaySell = 4194304;
		const int bit_FinalizeCash = 8388608;
		const int bit_CheckCash = 16777216;
		const int bit_ConCashUp = 33554432;
		const int bit_CustBal = 67108864;

		private void loadLanguage()
		{

			//frmPOSsetup = No Code          [Point Of Sale Parameters]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmPOSsetup.Caption = rsLang("LanguageLayoutLnk_Description"): frmPOSsetup.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lbl_5 = Receipt Details       [Receipt Details]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_5.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblLabels_0 = No Code         [First Receipt Heading Line]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblLabels_1 = No Code         [Second Receipt Heading Line]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblLabels_2 = No Code         [Third Receipt Heading Line]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblLabels_3 = No Code         [Receipt Footer]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_3.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblLabels_4 = No Code         [VAT Number]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_4.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_0 = No Code               [Transaction Prints]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Frame1 = No Code               [Print POS Transaction]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Frame1.Caption = rsLang("LanguageLayoutLnk_Description"): Frame1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2362;
			//Yes|Checked
			if (modRecordSet.rsLang.RecordCount){optPrint[1].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;optPrint[1].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2363;
			//No|Checked
			if (modRecordSet.rsLang.RecordCount){optPrint[2].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;optPrint[2].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//optPrint(0) = No Code          [Ask]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then optPrint(0).Caption = rsLang("LanguageLayoutLnk_Description"): optPrint(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblLabels_5 = No Code         [No of Account Payment Prints]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_5.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblLabels_6 = No Code         [No of Account Sale Prints]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_6.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_6.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblLabels_7 = No Code         [Cash Before Delivery Prints]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_7.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_7.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblLabels_8 = No Code         [No of Consignement Prints]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_8.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_8.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Note: _lblLabels_9.Caption has a grammar/spelling mistake!!!
			//_lblLabels_9 = No Code         [No of Payout Prints]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_9.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_9.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_1 = No Code               [Other Parameters]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1201;
			//Deposits|Checked
			if (modRecordSet.rsLang.RecordCount){frmDeposits.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;frmDeposits.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//optDeposits(0) = No Code       [Pricing Group One]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then optDeposits(0).Caption = rsLang("LanguageLayoutLnk_Description"): optDeposits(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//optDeposits(1) = No Code       [Pricing Group Two]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then optDeposits(1).Caption = rsLang("LanguageLayoutLnk_Description"): optDeposits(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//optDeposits(2) = No Code       [Automatically Determined]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then optDeposits(2).Caption = rsLang("LanguageLayoutLnk_Description"): optDeposits(2).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkPrintinvoice = No Code      [Do Not Print VAT on Invoice]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkPrintinvoice.Caption = rsLang("LanguageLayoutLnk_Description"): chkPrintinvoice.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkConCashup = No Code         [Activate Consolidate Cashup]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkConCashup.Caption = rsLang("LanguageLayoutLnk_Description"): chkConCashup.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkCustBal = No Code           [Print Customer Balances]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkCustBal.Caption = rsLang("LanguageLayoutLnk_Description"): chkCustBal.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkCardNumber = No Code        [Card Number Reference]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkCardNumber.Caption = rsLang("LanguageLayoutLnk_Description"): chkCardNumber.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkOrderNumber = No Code       [Order Number Reference]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkOrderNumber.Caption = rsLang("LanguageLayoutLnk_Description"): chkOrderNumber.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkSerialNumber = No Code      [Serial Reference Number]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkSerialNumber.Caption = rsLang("LanguageLayoutLnk_Description"): chkSerialNumber.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkSets = No Code              [Automatically Build Sets]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkSets.Caption = rsLang("LanguageLayoutLnk_Description"): chkSets.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkShrink = No Code            [Automatically Build Shrinks]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkShrink.Caption = rsLang("LanguageLayoutLnk_Description"): chkShrink.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkSuppress = No Code          [Switch on Suppress After Cashup]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkSuppress.Caption = rsLang("LanguageLayoutLnk_Description"): chkSuppress.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkBlindCashup = No Code       [Blind Cashup]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkBlindCashup.Caption = rsLang("LanguageLayoutLnk_Description"): cmdBlindCashup.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkQuickCashup = No Code       [Quick Cashup]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkQuickCashup.Caption = rsLang("LanguageLayoutLnk_Description"): chkQuickCashup.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkOpenTill = No Code          [Only Open Till for Cash Transaction]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkOpenTill.Caption = rsLang("LanguageLayoutLnk_Description"): chkOpenTill.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkDevidingLine = No Code      [Print Deviding Line on Receipt]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkPrintDividingLine.Caption = rsLang("LanguageLayoutLnk_Description"): chkPrintDividingLine.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkSearchAuto = No Code        [Automatically search for stock items]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkSearchAuto.Caption = rsLang("LanguageLayoutLnk_Description"): chkSearchAuto.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkSecurityPopup = No Code     [Bypass Security Popup]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkSecurityPopup.Caption = rsLang("LanguageLayoutLnk_Description"): chkSecurityPopup.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkBypassTender = No Code      [Bypass Cashout Tender]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkBypassTender.Caption = rsLang("LanguageLayoutLnk_Description"): chkBypassTender.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkReceiptBarcode = No Code    [Print Barcodes on Receipts]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkReceiptBarcode.Caption = rsLang("LanguageLayoutLnk_Description"): chkReceiptBarcode.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkLogoffAuto = No Code        [Automatically Logoff Cashier]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkLogoffauto.Caption = rsLang("LanguageLayoutLnk_Description"): chkLogoffAuto.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkPrintA4 = No Code           [Print A4 Invoice with Exclusive Total]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkPrintA4.Caption = rsLang("LanguageLayoutLnk_Description"): chkPrintA4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkLearningPOS = No Code       [POS Learning Mode]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkLearningPOS.Caption = rsLang("LanguageLayoutLnk_Description"): chkLearningPOS.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkDisplaySelling = No Code    [Display Selling Price]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkDisplaySelling.Caption = rsLang("LanguageLayoutLnk_Description"): chkDisplaySelling.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkFinalizeCash = No Code      [Cash sales have to be finalized (Touch)
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkFinalizeCash.Caption = rsLang("LanguageLayoutLnk_Description"): chkFinalizeCash.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")]

			//chkCheckCash = No Code         [Remove Excess Cash from Till]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkCheckCash.Caption = rsLang("LanguageLayoutLnk_Description"): chkCheckCash.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Note: Grammar for _lblLabels_10.Caption not 100%
			//_lblLabels_10 = No Code        [Cent Rounding: Default = 5 Cents, Max = 50 Cents]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_10.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_10.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmPOSsetup.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void buildDataControls()
		{
			loading = true;
			if ((adoPrimaryRS.Fields("Company_POSparameters").Value & bit_deposit1)) {
				if ((adoPrimaryRS.Fields("Company_POSparameters").Value & bit_deposit2)) {
					_optDeposits_2.Checked = true;
				} else {
					_optDeposits_0.Checked = true;
				}
			} else {
				_optDeposits_1.Checked = true;
			}

			this.chkSets.CheckState = System.Math.Abs(Convert.ToInt16(Convert.ToBoolean(adoPrimaryRS.Fields("Company_POSparameters").Value & bit_Sets)));
			this.chkShrink.CheckState = System.Math.Abs(Convert.ToInt16(Convert.ToBoolean(adoPrimaryRS.Fields("Company_POSparameters").Value & bit_Shrink)));
			this.chkSuppress.CheckState = System.Math.Abs(Convert.ToInt16(Convert.ToBoolean(adoPrimaryRS.Fields("Company_POSparameters").Value & bit_Suppress)));
			this.chkBlindCashup.CheckState = System.Math.Abs(Convert.ToInt16(Convert.ToBoolean(adoPrimaryRS.Fields("Company_POSparameters").Value & bit_BlindDeclaration)));
			this.chkDividingLine.CheckState = System.Math.Abs(Convert.ToInt16(Convert.ToBoolean(adoPrimaryRS.Fields("Company_POSparameters").Value & bit_Lines)));
			this.chkQuickCashup.CheckState = System.Math.Abs(Convert.ToInt16(Convert.ToBoolean(adoPrimaryRS.Fields("Company_POSparameters").Value & bit_DeclarationQuick)));
			this.chkOpenTill.CheckState = System.Math.Abs(Convert.ToInt16(Convert.ToBoolean(adoPrimaryRS.Fields("Company_POSparameters").Value & bit_OpenTill)));
			this.chkSearchAuto.CheckState = System.Math.Abs(Convert.ToInt16(Convert.ToBoolean(adoPrimaryRS.Fields("Company_POSparameters").Value & bit_autoSearch)));
			this.chkBypassTender.CheckState = System.Math.Abs(Convert.ToInt16(Convert.ToBoolean(adoPrimaryRS.Fields("Company_POSparameters").Value & bit_autoSearch)));
			this.chkBypassTender.CheckState = System.Math.Abs(Convert.ToInt16(Convert.ToBoolean(adoPrimaryRS.Fields("Company_POSparameters").Value & bit_bypassTender)));
			this.chkSecurityPopup.CheckState = System.Math.Abs(Convert.ToInt16(Convert.ToBoolean(adoPrimaryRS.Fields("Company_POSparameters").Value & bit_bypassSecurity)));
			this.chkReceiptBarcode.CheckState = System.Math.Abs(Convert.ToInt16(Convert.ToBoolean(adoPrimaryRS.Fields("Company_POSparameters").Value & bit_itemNoReceipt)));
			this.chkLogoffAuto.CheckState = System.Math.Abs(Convert.ToInt16(Convert.ToBoolean(adoPrimaryRS.Fields("Company_POSparameters").Value & bit_autoLogoff)));
			this.chkPrintA4.CheckState = System.Math.Abs(Convert.ToInt16(Convert.ToBoolean(adoPrimaryRS.Fields("Company_POSparameters").Value & bit_A4Paramet)));
			this.chkCardNumber.CheckState = System.Math.Abs(Convert.ToInt16(Convert.ToBoolean(adoPrimaryRS.Fields("Company_POSparameters").Value & bit_Cardrefere)));
			this.chkOrderNumber.CheckState = System.Math.Abs(Convert.ToInt16(Convert.ToBoolean(adoPrimaryRS.Fields("Company_POSparameters").Value & bit_OrderRefer)));
			this.chkSerialNumber.CheckState = System.Math.Abs(Convert.ToInt16(Convert.ToBoolean(adoPrimaryRS.Fields("Company_POSparameters").Value & bit_SerialRef)));
			this.chkSerialTracking.CheckState = System.Math.Abs(Convert.ToInt16(Convert.ToBoolean(adoPrimaryRS.Fields("Company_POSparameters").Value & bit_SerialTra)));
			this.chkLearningPOS.CheckState = System.Math.Abs(Convert.ToInt16(Convert.ToBoolean(adoPrimaryRS.Fields("Company_POSparameters").Value & bit_LearningPOS)));
			this.chkDisplaySelling.CheckState = System.Math.Abs(Convert.ToInt16(Convert.ToBoolean(adoPrimaryRS.Fields("Company_POSparameters").Value & bit_DisplaySell)));
			this.chkFinalizeCash.CheckState = System.Math.Abs(Convert.ToInt16(Convert.ToBoolean(adoPrimaryRS.Fields("Company_POSparameters").Value & bit_FinalizeCash)));
			this.chkPrintinvoice.CheckState = System.Math.Abs(Convert.ToInt16(Convert.ToBoolean(adoPrimaryRS.Fields("Company_POSparameters").Value & bit_IntVATPrint)));
			this.chkCheckCash.CheckState = System.Math.Abs(Convert.ToInt16(Convert.ToBoolean(adoPrimaryRS.Fields("Company_POSparameters").Value & bit_CheckCash)));
			this.chkConCashup.CheckState = System.Math.Abs(Convert.ToInt16(Convert.ToBoolean(adoPrimaryRS.Fields("Company_POSparameters").Value & bit_ConCashUp)));
			this.chkCustBal.CheckState = System.Math.Abs(Convert.ToInt16(Convert.ToBoolean(adoPrimaryRS.Fields("Company_POSparameters").Value & bit_CustBal)));

			loading = false;

		}
		private void updateBit()
		{
			if (loading)
				return;
			int lBit = 0;

			if (this.chkShrink.CheckState)
				lBit = lBit + bit_Shrink;
			if (this.chkSuppress.CheckState)
				lBit = lBit + bit_Suppress;
			if (this.chkSets.CheckState)
				lBit = lBit + bit_Sets;
			if (this.chkBlindCashup.CheckState)
				lBit = lBit + bit_BlindDeclaration;
			if (this.chkDividingLine.CheckState)
				lBit = lBit + bit_Lines;
			if (this.chkQuickCashup.CheckState)
				lBit = lBit + bit_DeclarationQuick;
			if (this.chkOpenTill.CheckState)
				lBit = lBit + bit_OpenTill;
			if (this.optDeposits[0].Checked)
				lBit = lBit + bit_deposit1;
			if (this.optDeposits[1].Checked)
				lBit = lBit + bit_deposit2;
			if (this.optDeposits[2].Checked)
				lBit = lBit + bit_deposit2 + bit_deposit1;
			if (chkSearchAuto.CheckState)
				lBit = lBit + bit_autoSearch;
			if (this.chkBypassTender.CheckState)
				lBit = lBit + bit_bypassTender;
			if (chkSecurityPopup.CheckState)
				lBit = lBit + bit_bypassSecurity;
			if (chkReceiptBarcode.CheckState)
				lBit = lBit + bit_itemNoReceipt;
			if (this.chkLogoffAuto.CheckState)
				lBit = lBit + bit_autoLogoff;
			if (this.chkPrintA4.CheckState)
				lBit = lBit + bit_A4Paramet;
			if (this.chkCardNumber.CheckState)
				lBit = lBit + bit_Cardrefere;
			if (this.chkOrderNumber.CheckState)
				lBit = lBit + bit_OrderRefer;
			if (this.chkSerialNumber.CheckState)
				lBit = lBit + bit_SerialRef;
			if (this.chkSerialTracking.CheckState)
				lBit = lBit + bit_SerialTra;
			if (this.chkLearningPOS.CheckState)
				lBit = lBit + bit_LearningPOS;
			if (this.chkDisplaySelling.CheckState)
				lBit = lBit + bit_DisplaySell;
			if (this.chkFinalizeCash.CheckState)
				lBit = lBit + bit_FinalizeCash;
			if (this.chkPrintinvoice.CheckState)
				lBit = lBit + bit_IntVATPrint;
			if (this.chkCheckCash.CheckState)
				lBit = lBit + bit_CheckCash;
			if (this.chkConCashup.CheckState)
				lBit = lBit + bit_ConCashUp;
			if (this.chkCustBal.CheckState)
				lBit = lBit + bit_CustBal;

			_txtFields_9.Text = Convert.ToString(lBit);


		}

		private void doDataControl(ref System.Windows.Forms.Control dataControl, ref string sql, ref string DataField, ref string boundColumn, ref string listField)
		{
			//Dim rs As ADODB.Recordset
			//rs = getRS(sql)
			//UPGRADE_WARNING: Couldn't resolve default property of object dataControl.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//dataControl.DataSource = rs
			//UPGRADE_ISSUE: Control method dataControl.DataSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			//dataControl.DataSource = adoPrimaryRS
			//UPGRADE_ISSUE: Control method dataControl.DataField was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			//dataControl.DataField = DataField
			//UPGRADE_WARNING: Couldn't resolve default property of object dataControl.boundColumn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//dataControl.boundColumn = boundColumn
			//UPGRADE_WARNING: Couldn't resolve default property of object dataControl.listField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//dataControl.listField = listField
		}

		public void loadItem()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);

			System.Windows.Forms.TextBox oText = null;
			System.Windows.Forms.CheckBox oCheck = null;
			 // ERROR: Not supported in C#: OnErrorStatement


			//Old
			//Set adoPrimaryRS = getRS("select CompanyID, Company_PosHeading1,Company_PosHeading2,Company_PosHeading3,Company_PosFooter,Company_TaxNumber,Company_PosPrintAccountPayments,Company_PosPrintAccountSales,Company_PosPrintAccountCOD,Company_PosPrintConsignment,Company_PosParameters,Company_POSRecieptPrint from Company")

			//New with text narative
			adoPrimaryRS = modRecordSet.getRS(ref "select CompanyID, Company_PosHeading1,Company_PosHeading2,Company_PosHeading3,Company_PosFooter,Company_TaxNumber,Company_PosPrintAccountPayments,Company_PosPrintAccountSales,Company_PosPrintAccountCOD,Company_PosPrintConsignment,Company_POSExcess,Company_PosParameters,Company_POSRecieptPrint,Company_PosPrintPayouts,Company_PosCentRound from Company");

			setup();
			foreach (TextBox oText_loopVariable in txtFields) {
				oText = oText_loopVariable;
				oText.DataBindings.Add(adoPrimaryRS);
				oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize;
			}
			foreach (TextBox oText_loopVariable in this.txtInteger) {
				oText = oText_loopVariable;
				oText.DataBindings.Add(adoPrimaryRS);
				oText.Leave += txtInteger_Leave;
				//txtInteger_Leave(txtInteger.Item((oText.Index)), New System.EventArgs())
			}

			foreach (TextBox oText_loopVariable in this.txtPrice) {
				oText = oText_loopVariable;
				oText.DataBindings.Add(adoPrimaryRS);
				oText.Leave += txtPrice_Leave;
				//txtPrice_Leave(txtPrice.Item((oText.Index)), New System.EventArgs())
			}

			this._txtPrice_0.Text = Strings.FormatNumber(adoPrimaryRS.Fields("Company_POSExcess").Value, 2);


			//_txtFields_9.MaxLength = 7
			_txtFields_9.MaxLength = 8;
			buildDataControls();
			mbDataChanged = false;
			//Me.optPrint(_txtFields_5).Checked = True
			if (_txtFields_5.Text == "0") {
				_optPrint_0.Checked = true;
			} else if (_txtFields_5.Text == "1") {
				_optPrint_1.Checked = true;
			} else {
				_optPrint_2.Checked = true;
			}

			loadLanguage();
			ShowDialog();
		}

		private void setup()
		{
		}
		private void Check1_Click()
		{
			updateBit();
		}

		private void chkBlindCashup_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			updateBit();
		}

		private void chkBypassTender_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			updateBit();
		}

		private void chkCardNumber_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			updateBit();
		}

		private void chkConCashup_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			updateBit();
		}

		private void chkCurrency_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			updateBit();
		}

		private void chkCustBal_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			updateBit();
		}

		private void chkDisplaySelling_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			updateBit();
		}

		private void chkDividingLine_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			updateBit();
		}

		private void chkFinalizeCash_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			updateBit();
		}

		private void chkLearningPOS_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			updateBit();
		}

		private void chkLogoffAuto_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			updateBit();
		}

		private void chkOpenTill_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			updateBit();
		}

		private void chkOrderNumber_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			updateBit();
		}

		private void chkPrintA4_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			updateBit();
		}

		private void chkPrintinvoice_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			updateBit();
		}

		private void chkCheckCash_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			updateBit();
		}

		private void chkQuickCashup_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			updateBit();
		}

		private void chkReceiptBarcode_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			updateBit();
		}

		private void chkSearchAuto_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			updateBit();
		}

		private void chkSecurityPopup_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			updateBit();
		}

		private void chkSerialNumber_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			updateBit();
		}
		private void chkSerialTracking_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			updateBit();
		}

		private void chkSets_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			updateBit();
		}

		private void chkShrink_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			updateBit();
		}

		private void chkSuppress_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			updateBit();
		}
		private void frmPOSsetup_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			modBResolutions.ResizeForm(ref this, ref sizeConvertors.pixelToTwips(this.Width, true), ref sizeConvertors.pixelToTwips(this.Height, false), ref 0);
		}

		private void frmPOSsetup_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			Button cmdLast = new Button();
			Button cmdNext = new Button();
			Label lblStatus = new Label();
			 // ERROR: Not supported in C#: OnErrorStatement

			lblStatus.Width = sizeConvertors.pixelToTwips(this.Width, true) - 1500;
			cmdNext.Left = lblStatus.Width + 700;
			cmdLast.Left = cmdNext.Left + 340;
		}
		private void frmPOSsetup_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case System.Windows.Forms.Keys.Escape:
					KeyAscii = 0;
					System.Windows.Forms.Application.DoEvents();
					adoPrimaryRS.Move(0);
					cmdClose_Click(cmdClose, new System.EventArgs());
					break;
			}

			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmPOSsetup_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
		}

		private void adoPrimaryRS_MoveComplete(ADODB.EventReasonEnum adReason, ADODB.Error pError, ref ADODB.EventStatusEnum adStatus, ADODB.Recordset pRecordset)
		{
			//This will display the current record position for this recordset
		}

		private void adoPrimaryRS_WillChangeRecord(ADODB.EventReasonEnum adReason, int cRecords, ref ADODB.EventStatusEnum adStatus, ADODB.Recordset pRecordset)
		{
			//This is where you put validation code
			//This event gets called when the following actions occur
			bool bCancel = false;
			switch (adReason) {
				case ADODB.EventReasonEnum.adRsnAddNew:
					break;
				case ADODB.EventReasonEnum.adRsnClose:
					break;
				case ADODB.EventReasonEnum.adRsnDelete:
					break;
				case ADODB.EventReasonEnum.adRsnFirstChange:
					break;
				case ADODB.EventReasonEnum.adRsnMove:
					break;
				case ADODB.EventReasonEnum.adRsnRequery:
					break;
				case ADODB.EventReasonEnum.adRsnResynch:
					break;
				case ADODB.EventReasonEnum.adRsnUndoAddNew:
					break;
				case ADODB.EventReasonEnum.adRsnUndoDelete:
					break;
				case ADODB.EventReasonEnum.adRsnUndoUpdate:
					break;
				case ADODB.EventReasonEnum.adRsnUpdate:
					break;
			}

			if (bCancel)
				adStatus = ADODB.EventStatusEnum.adStatusCancel;
		}
		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			if (mbAddNewFlag) {
				this.Close();
			} else {
				mbEditFlag = false;
				mbAddNewFlag = false;
				adoPrimaryRS.CancelUpdate();
				if (mvBookMark > 0) {
					adoPrimaryRS.Bookmark = mvBookMark;
				} else {
					adoPrimaryRS.MoveFirst();
				}
				mbDataChanged = false;
			}
		}

		private bool update_Renamed()
		{
			bool functionReturnValue = false;
			 // ERROR: Not supported in C#: OnErrorStatement

			bool lDirty = false;
			short x = 0;
			short lBit = 0;
			lDirty = false;
			functionReturnValue = true;
			if (mbAddNewFlag) {
				adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll);
				adoPrimaryRS.MoveLast();
				//move to the new record

			} else {
				adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll);
				adoPrimaryRS.MoveLast();
				//move to the new record
			}

			mbEditFlag = false;
			mbAddNewFlag = false;
			mbDataChanged = false;
			return functionReturnValue;
			UpdateErr:

			Interaction.MsgBox(Err().Description);
			functionReturnValue = false;
			return functionReturnValue;
		}

		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdClose.Focus();
			System.Windows.Forms.Application.DoEvents();

			if (update_Renamed()) {
				this.Close();
			}
		}

		//Handles optDeposits.CheckedChanged
		private void optDeposits_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.Checked) {
				RadioButton rb = new RadioButton();
				rb = (RadioButton)eventSender;
				int Index = GetIndex.GetIndexer(ref rb, ref optDeposits);
				updateBit();
			}
		}

		//Handles optPrint.CheckedChanged
		private void optPrint_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.Checked) {
				RadioButton rb = new RadioButton();
				rb = (RadioButton)eventSender;
				int Index = GetIndex.GetIndexer(ref rb, ref optPrint);
				_txtFields_5.Text = Convert.ToString(Index);
			}
		}
		// Handles txtFields.Enter
		private void txtFields_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txtbox = new TextBox();
			txtbox = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txtbox, ref txtFields);
			modUtilities.MyGotFocus(ref txtFields[Index]);
			//_txtFields_6.Text = FormatNumber(adoPrimaryRS("Company_POSExcess"), 2)
		}
		//Handles txtFields.Leave
		private void txtFields_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txtbox = new TextBox();
			txtbox = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txtbox, ref txtFields);
			modUtilities.MyGotFocus(ref txtFields[Index]);
			//_txtFields_6.Text = FormatNumber(adoPrimaryRS("Company_POSExcess"), 2)
		}

		//Handles txtInteger.Enter
		private void txtInteger_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txtbox = new TextBox();
			txtbox = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txtbox, ref txtInteger);
			modUtilities.MyGotFocusNumeric(ref txtInteger[Index]);
		}

		//Handles txtInteger.KeyPress
		private void txtInteger_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			//Dim Index As Short = txtInteger.GetIndex(eventSender)
			modUtilities.MyKeyPress(ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		//Handles txtInteger.Leave
		private void txtInteger_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txtbox = new TextBox();
			txtbox = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txtbox, ref txtInteger);
			modUtilities.MyLostFocus(ref txtInteger[Index], ref 0);
			if (Index == 0) {
				if (Convert.ToInt16(_txtInteger_0.Text) > 50) {
					Interaction.MsgBox("Maximum 50 Cents allowed!", MsgBoxStyle.Critical);
					_txtInteger_0.Text = Convert.ToString(50);
					_txtInteger_0.Focus();
				} else if (Convert.ToInt16(_txtInteger_0.Text) < 1) {
					Interaction.MsgBox("Minimum 1 Cents allowed!", MsgBoxStyle.Critical);
					_txtInteger_0.Text = Convert.ToString(1);
					_txtInteger_0.Focus();
				}
			}
		}

		private void txtFloat_MyGotFocus(ref short Index)
		{
			//    MyGotFocusNumeric txtFloat(Index)
		}

		private void txtFloat_KeyPress(ref short Index, ref short KeyAscii)
		{
			//    KeyPress KeyAscii
		}

		private void txtFloat_MyLostFocus(ref short Index)
		{
			//    LostFocus txtFloat(Index), 2
		}

		private void txtFloatNegative_MyGotFocus(ref short Index)
		{
			//    MyGotFocusNumeric txtFloatNegative(Index)
		}

		private void txtFloatNegative_KeyPress(ref short Index, ref short KeyAscii)
		{
			//    KeyPressNegative txtFloatNegative(Index), KeyAscii
		}

		private void txtFloatNegative_MyLostFocus(ref short Index)
		{
			//    LostFocus txtFloatNegative(Index), 2
		}

		//Handles txtPrice.Enter
		private void txtPrice_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txtbox = new TextBox();
			txtbox = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txtbox, ref txtPrice);
			if (!string.IsNullOrEmpty(txtPrice[Index].Text)) {
				modUtilities.MyGotFocusNumeric(ref txtPrice[Index]);
			}
		}

		//Handles txtPrice.KeyPress
		private void txtPrice_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			//Dim Index As Short = txtPrice.GetIndex(eventSender)
			modUtilities.MyKeyPress(ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		//Handles txtPrice.Leave
		private void txtPrice_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txtbox = new TextBox();
			txtbox = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txtbox, ref txtPrice);
			if (!string.IsNullOrEmpty(txtPrice[Index].Text)) {
				modUtilities.MyLostFocus(ref txtPrice[Index], ref 2);
			}
		}

		private void frmPOSsetup_Load1(object sender, System.EventArgs e)
		{
			txtFields.AddRange(new TextBox[] {
				_txtFields_0,
				_txtFields_1,
				_txtFields_2,
				_txtFields_3,
				_txtFields_4,
				_txtFields_5,
				_txtFields_9
			});
			txtPrice.AddRange(new TextBox[] { _txtPrice_0 });
			txtInteger.AddRange(new TextBox[] {
				_txtInteger_0,
				_txtInteger_5,
				_txtInteger_6,
				_txtInteger_7,
				_txtInteger_8,
				_txtInteger_9
			});
			optDeposits.AddRange(new RadioButton[] {
				_optDeposits_0,
				_optDeposits_1,
				_optDeposits_2
			});
			optPrint.AddRange(new RadioButton[] {
				_optPrint_0,
				_optPrint_1,
				_optPrint_2
			});
			TextBox tb = new TextBox();
			RadioButton rb = new RadioButton();
			foreach (TextBox tb_loopVariable in txtFields) {
				tb = tb_loopVariable;
				tb.Enter += txtFields_Enter;
				tb.Leave += txtFields_Leave;
			}
			_txtPrice_0.Enter += txtPrice_Enter;
			_txtPrice_0.KeyPress += txtPrice_KeyPress;

			foreach (RadioButton rb_loopVariable in optDeposits) {
				rb = rb_loopVariable;
				rb.Click += optDeposits_CheckedChanged;
			}

			foreach (RadioButton rb_loopVariable in optPrint) {
				rb = rb_loopVariable;
				rb.Click += optPrint_CheckedChanged;
			}
		}
	}
}
