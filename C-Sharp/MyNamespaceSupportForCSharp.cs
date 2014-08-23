using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Devices;

// This file was created by the VB to C# converter (SharpDevelop 4.4.0.9722).
// It contains classes for supporting the VB "My" namespace in C#.
// If the VB application does not use the "My" namespace, or if you removed the usage
// after the conversion to C#, you can delete this file.

namespace _4PosBackOffice.NET.My
{
	sealed partial class MyProject
	{
		[ThreadStatic] static MyApplication application;
		
		public static MyApplication Application {
			[DebuggerStepThrough]
			get {
				if (application == null)
					application = new MyApplication();
				return application;
			}
		}
		
		[ThreadStatic] static MyComputer computer;
		
		public static MyComputer Computer {
			[DebuggerStepThrough]
			get {
				if (computer == null)
					computer = new MyComputer();
				return computer;
			}
		}
		
		[ThreadStatic] static User user;
		
		public static User User {
			[DebuggerStepThrough]
			get {
				if (user == null)
					user = new User();
				return user;
			}
		}
		
		[ThreadStatic] static MyForms forms;
		
		public static MyForms Forms {
			[DebuggerStepThrough]
			get {
				if (forms == null)
					forms = new MyForms();
				return forms;
			}
		}
		
		internal sealed class MyForms
		{
			global::_4PosBackOffice.NET.frmVNC frmVNC_instance;
			bool frmVNC_isCreating;
			public global::_4PosBackOffice.NET.frmVNC frmVNC {
				[DebuggerStepThrough] get { return GetForm(ref frmVNC_instance, ref frmVNC_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmVNC_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmWH frmWH_instance;
			bool frmWH_isCreating;
			public global::_4PosBackOffice.NET.frmWH frmWH {
				[DebuggerStepThrough] get { return GetForm(ref frmWH_instance, ref frmWH_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmWH_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmWHlist frmWHlist_instance;
			bool frmWHlist_isCreating;
			public global::_4PosBackOffice.NET.frmWHlist frmWHlist {
				[DebuggerStepThrough] get { return GetForm(ref frmWHlist_instance, ref frmWHlist_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmWHlist_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmZeroise frmZeroise_instance;
			bool frmZeroise_isCreating;
			public global::_4PosBackOffice.NET.frmZeroise frmZeroise {
				[DebuggerStepThrough] get { return GetForm(ref frmZeroise_instance, ref frmZeroise_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmZeroise_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmZeroiseCD frmZeroiseCD_instance;
			bool frmZeroiseCD_isCreating;
			public global::_4PosBackOffice.NET.frmZeroiseCD frmZeroiseCD {
				[DebuggerStepThrough] get { return GetForm(ref frmZeroiseCD_instance, ref frmZeroiseCD_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmZeroiseCD_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmBackupDatabase frmBackupDatabase_instance;
			bool frmBackupDatabase_isCreating;
			public global::_4PosBackOffice.NET.frmBackupDatabase frmBackupDatabase {
				[DebuggerStepThrough] get { return GetForm(ref frmBackupDatabase_instance, ref frmBackupDatabase_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmBackupDatabase_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmBarcode frmBarcode_instance;
			bool frmBarcode_isCreating;
			public global::_4PosBackOffice.NET.frmBarcode frmBarcode {
				[DebuggerStepThrough] get { return GetForm(ref frmBarcode_instance, ref frmBarcode_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmBarcode_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmBarcodeLoad frmBarcodeLoad_instance;
			bool frmBarcodeLoad_isCreating;
			public global::_4PosBackOffice.NET.frmBarcodeLoad frmBarcodeLoad {
				[DebuggerStepThrough] get { return GetForm(ref frmBarcodeLoad_instance, ref frmBarcodeLoad_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmBarcodeLoad_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmZeroiseED frmZeroiseED_instance;
			bool frmZeroiseED_isCreating;
			public global::_4PosBackOffice.NET.frmZeroiseED frmZeroiseED {
				[DebuggerStepThrough] get { return GetForm(ref frmZeroiseED_instance, ref frmZeroiseED_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmZeroiseED_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmBarcodePerson frmBarcodePerson_instance;
			bool frmBarcodePerson_isCreating;
			public global::_4PosBackOffice.NET.frmBarcodePerson frmBarcodePerson {
				[DebuggerStepThrough] get { return GetForm(ref frmBarcodePerson_instance, ref frmBarcodePerson_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmBarcodePerson_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmBarcodeScaleItem frmBarcodeScaleItem_instance;
			bool frmBarcodeScaleItem_isCreating;
			public global::_4PosBackOffice.NET.frmBarcodeScaleItem frmBarcodeScaleItem {
				[DebuggerStepThrough] get { return GetForm(ref frmBarcodeScaleItem_instance, ref frmBarcodeScaleItem_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmBarcodeScaleItem_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmBarcodeStockitem frmBarcodeStockitem_instance;
			bool frmBarcodeStockitem_isCreating;
			public global::_4PosBackOffice.NET.frmBarcodeStockitem frmBarcodeStockitem {
				[DebuggerStepThrough] get { return GetForm(ref frmBarcodeStockitem_instance, ref frmBarcodeStockitem_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmBarcodeStockitem_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmBlockTest frmBlockTest_instance;
			bool frmBlockTest_isCreating;
			public global::_4PosBackOffice.NET.frmBlockTest frmBlockTest {
				[DebuggerStepThrough] get { return GetForm(ref frmBlockTest_instance, ref frmBlockTest_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmBlockTest_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmBlockTestCode frmBlockTestCode_instance;
			bool frmBlockTestCode_isCreating;
			public global::_4PosBackOffice.NET.frmBlockTestCode frmBlockTestCode {
				[DebuggerStepThrough] get { return GetForm(ref frmBlockTestCode_instance, ref frmBlockTestCode_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmBlockTestCode_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmBlockTestFilterSelect frmBlockTestFilterSelect_instance;
			bool frmBlockTestFilterSelect_isCreating;
			public global::_4PosBackOffice.NET.frmBlockTestFilterSelect frmBlockTestFilterSelect {
				[DebuggerStepThrough] get { return GetForm(ref frmBlockTestFilterSelect_instance, ref frmBlockTestFilterSelect_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmBlockTestFilterSelect_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmBlockTestSelect frmBlockTestSelect_instance;
			bool frmBlockTestSelect_isCreating;
			public global::_4PosBackOffice.NET.frmBlockTestSelect frmBlockTestSelect {
				[DebuggerStepThrough] get { return GetForm(ref frmBlockTestSelect_instance, ref frmBlockTestSelect_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmBlockTestSelect_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmBOSecurity frmBOSecurity_instance;
			bool frmBOSecurity_isCreating;
			public global::_4PosBackOffice.NET.frmBOSecurity frmBOSecurity {
				[DebuggerStepThrough] get { return GetForm(ref frmBOSecurity_instance, ref frmBOSecurity_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmBOSecurity_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmBrokenPack frmBrokenPack_instance;
			bool frmBrokenPack_isCreating;
			public global::_4PosBackOffice.NET.frmBrokenPack frmBrokenPack {
				[DebuggerStepThrough] get { return GetForm(ref frmBrokenPack_instance, ref frmBrokenPack_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmBrokenPack_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmcalendar frmcalendar_instance;
			bool frmcalendar_isCreating;
			public global::_4PosBackOffice.NET.frmcalendar frmcalendar {
				[DebuggerStepThrough] get { return GetForm(ref frmcalendar_instance, ref frmcalendar_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmcalendar_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmCashTransactionItem frmCashTransactionItem_instance;
			bool frmCashTransactionItem_isCreating;
			public global::_4PosBackOffice.NET.frmCashTransactionItem frmCashTransactionItem {
				[DebuggerStepThrough] get { return GetForm(ref frmCashTransactionItem_instance, ref frmCashTransactionItem_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmCashTransactionItem_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmCashTransaction frmCashTransaction_instance;
			bool frmCashTransaction_isCreating;
			public global::_4PosBackOffice.NET.frmCashTransaction frmCashTransaction {
				[DebuggerStepThrough] get { return GetForm(ref frmCashTransaction_instance, ref frmCashTransaction_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmCashTransaction_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmChangeDisplay frmChangeDisplay_instance;
			bool frmChangeDisplay_isCreating;
			public global::_4PosBackOffice.NET.frmChangeDisplay frmChangeDisplay {
				[DebuggerStepThrough] get { return GetForm(ref frmChangeDisplay_instance, ref frmChangeDisplay_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmChangeDisplay_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmChannel frmChannel_instance;
			bool frmChannel_isCreating;
			public global::_4PosBackOffice.NET.frmChannel frmChannel {
				[DebuggerStepThrough] get { return GetForm(ref frmChannel_instance, ref frmChannel_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmChannel_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmChannelList frmChannelList_instance;
			bool frmChannelList_isCreating;
			public global::_4PosBackOffice.NET.frmChannelList frmChannelList {
				[DebuggerStepThrough] get { return GetForm(ref frmChannelList_instance, ref frmChannelList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmChannelList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmCompanyEmails frmCompanyEmails_instance;
			bool frmCompanyEmails_isCreating;
			public global::_4PosBackOffice.NET.frmCompanyEmails frmCompanyEmails {
				[DebuggerStepThrough] get { return GetForm(ref frmCompanyEmails_instance, ref frmCompanyEmails_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmCompanyEmails_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmCompanySetup frmCompanySetup_instance;
			bool frmCompanySetup_isCreating;
			public global::_4PosBackOffice.NET.frmCompanySetup frmCompanySetup {
				[DebuggerStepThrough] get { return GetForm(ref frmCompanySetup_instance, ref frmCompanySetup_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmCompanySetup_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmCurrencySetup frmCurrencySetup_instance;
			bool frmCurrencySetup_isCreating;
			public global::_4PosBackOffice.NET.frmCurrencySetup frmCurrencySetup {
				[DebuggerStepThrough] get { return GetForm(ref frmCurrencySetup_instance, ref frmCurrencySetup_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmCurrencySetup_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmCustomer frmCustomer_instance;
			bool frmCustomer_isCreating;
			public global::_4PosBackOffice.NET.frmCustomer frmCustomer {
				[DebuggerStepThrough] get { return GetForm(ref frmCustomer_instance, ref frmCustomer_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmCustomer_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmCustomerAllocPayment frmCustomerAllocPayment_instance;
			bool frmCustomerAllocPayment_isCreating;
			public global::_4PosBackOffice.NET.frmCustomerAllocPayment frmCustomerAllocPayment {
				[DebuggerStepThrough] get { return GetForm(ref frmCustomerAllocPayment_instance, ref frmCustomerAllocPayment_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmCustomerAllocPayment_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmCustomerAllocPaymentAmount frmCustomerAllocPaymentAmount_instance;
			bool frmCustomerAllocPaymentAmount_isCreating;
			public global::_4PosBackOffice.NET.frmCustomerAllocPaymentAmount frmCustomerAllocPaymentAmount {
				[DebuggerStepThrough] get { return GetForm(ref frmCustomerAllocPaymentAmount_instance, ref frmCustomerAllocPaymentAmount_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmCustomerAllocPaymentAmount_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmCustomerHistory frmCustomerHistory_instance;
			bool frmCustomerHistory_isCreating;
			public global::_4PosBackOffice.NET.frmCustomerHistory frmCustomerHistory {
				[DebuggerStepThrough] get { return GetForm(ref frmCustomerHistory_instance, ref frmCustomerHistory_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmCustomerHistory_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmCustomerList frmCustomerList_instance;
			bool frmCustomerList_isCreating;
			public global::_4PosBackOffice.NET.frmCustomerList frmCustomerList {
				[DebuggerStepThrough] get { return GetForm(ref frmCustomerList_instance, ref frmCustomerList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmCustomerList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmCustomerStatement frmCustomerStatement_instance;
			bool frmCustomerStatement_isCreating;
			public global::_4PosBackOffice.NET.frmCustomerStatement frmCustomerStatement {
				[DebuggerStepThrough] get { return GetForm(ref frmCustomerStatement_instance, ref frmCustomerStatement_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmCustomerStatement_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmCustomerStatementRun frmCustomerStatementRun_instance;
			bool frmCustomerStatementRun_isCreating;
			public global::_4PosBackOffice.NET.frmCustomerStatementRun frmCustomerStatementRun {
				[DebuggerStepThrough] get { return GetForm(ref frmCustomerStatementRun_instance, ref frmCustomerStatementRun_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmCustomerStatementRun_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmCustomerTransaction frmCustomerTransaction_instance;
			bool frmCustomerTransaction_isCreating;
			public global::_4PosBackOffice.NET.frmCustomerTransaction frmCustomerTransaction {
				[DebuggerStepThrough] get { return GetForm(ref frmCustomerTransaction_instance, ref frmCustomerTransaction_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmCustomerTransaction_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmCustomerTransactionNotes frmCustomerTransactionNotes_instance;
			bool frmCustomerTransactionNotes_isCreating;
			public global::_4PosBackOffice.NET.frmCustomerTransactionNotes frmCustomerTransactionNotes {
				[DebuggerStepThrough] get { return GetForm(ref frmCustomerTransactionNotes_instance, ref frmCustomerTransactionNotes_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmCustomerTransactionNotes_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmDayEnd frmDayEnd_instance;
			bool frmDayEnd_isCreating;
			public global::_4PosBackOffice.NET.frmDayEnd frmDayEnd {
				[DebuggerStepThrough] get { return GetForm(ref frmDayEnd_instance, ref frmDayEnd_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmDayEnd_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmDayEndList frmDayEndList_instance;
			bool frmDayEndList_isCreating;
			public global::_4PosBackOffice.NET.frmDayEndList frmDayEndList {
				[DebuggerStepThrough] get { return GetForm(ref frmDayEndList_instance, ref frmDayEndList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmDayEndList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmDeposit frmDeposit_instance;
			bool frmDeposit_isCreating;
			public global::_4PosBackOffice.NET.frmDeposit frmDeposit {
				[DebuggerStepThrough] get { return GetForm(ref frmDeposit_instance, ref frmDeposit_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmDeposit_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmDepositList frmDepositList_instance;
			bool frmDepositList_isCreating;
			public global::_4PosBackOffice.NET.frmDepositList frmDepositList {
				[DebuggerStepThrough] get { return GetForm(ref frmDepositList_instance, ref frmDepositList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmDepositList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmDepositTake frmDepositTake_instance;
			bool frmDepositTake_isCreating;
			public global::_4PosBackOffice.NET.frmDepositTake frmDepositTake {
				[DebuggerStepThrough] get { return GetForm(ref frmDepositTake_instance, ref frmDepositTake_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmDepositTake_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmDesign frmDesign_instance;
			bool frmDesign_isCreating;
			public global::_4PosBackOffice.NET.frmDesign frmDesign {
				[DebuggerStepThrough] get { return GetForm(ref frmDesign_instance, ref frmDesign_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmDesign_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmExport frmExport_instance;
			bool frmExport_isCreating;
			public global::_4PosBackOffice.NET.frmExport frmExport {
				[DebuggerStepThrough] get { return GetForm(ref frmExport_instance, ref frmExport_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmExport_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmExportProductPerfomace frmExportProductPerfomace_instance;
			bool frmExportProductPerfomace_isCreating;
			public global::_4PosBackOffice.NET.frmExportProductPerfomace frmExportProductPerfomace {
				[DebuggerStepThrough] get { return GetForm(ref frmExportProductPerfomace_instance, ref frmExportProductPerfomace_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmExportProductPerfomace_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmExportUt frmExportUt_instance;
			bool frmExportUt_isCreating;
			public global::_4PosBackOffice.NET.frmExportUt frmExportUt {
				[DebuggerStepThrough] get { return GetForm(ref frmExportUt_instance, ref frmExportUt_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmExportUt_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmFilter frmFilter_instance;
			bool frmFilter_isCreating;
			public global::_4PosBackOffice.NET.frmFilter frmFilter {
				[DebuggerStepThrough] get { return GetForm(ref frmFilter_instance, ref frmFilter_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmFilter_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmFilterList frmFilterList_instance;
			bool frmFilterList_isCreating;
			public global::_4PosBackOffice.NET.frmFilterList frmFilterList {
				[DebuggerStepThrough] get { return GetForm(ref frmFilterList_instance, ref frmFilterList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmFilterList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmFilterOrder frmFilterOrder_instance;
			bool frmFilterOrder_isCreating;
			public global::_4PosBackOffice.NET.frmFilterOrder frmFilterOrder {
				[DebuggerStepThrough] get { return GetForm(ref frmFilterOrder_instance, ref frmFilterOrder_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmFilterOrder_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmFilterOrderList frmFilterOrderList_instance;
			bool frmFilterOrderList_isCreating;
			public global::_4PosBackOffice.NET.frmFilterOrderList frmFilterOrderList {
				[DebuggerStepThrough] get { return GetForm(ref frmFilterOrderList_instance, ref frmFilterOrderList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmFilterOrderList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmFloatLister frmFloatLister_instance;
			bool frmFloatLister_isCreating;
			public global::_4PosBackOffice.NET.frmFloatLister frmFloatLister {
				[DebuggerStepThrough] get { return GetForm(ref frmFloatLister_instance, ref frmFloatLister_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmFloatLister_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmFloatRepre frmFloatRepre_instance;
			bool frmFloatRepre_isCreating;
			public global::_4PosBackOffice.NET.frmFloatRepre frmFloatRepre {
				[DebuggerStepThrough] get { return GetForm(ref frmFloatRepre_instance, ref frmFloatRepre_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmFloatRepre_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmGlobalCost frmGlobalCost_instance;
			bool frmGlobalCost_isCreating;
			public global::_4PosBackOffice.NET.frmGlobalCost frmGlobalCost {
				[DebuggerStepThrough] get { return GetForm(ref frmGlobalCost_instance, ref frmGlobalCost_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmGlobalCost_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmGlobalFilter frmGlobalFilter_instance;
			bool frmGlobalFilter_isCreating;
			public global::_4PosBackOffice.NET.frmGlobalFilter frmGlobalFilter {
				[DebuggerStepThrough] get { return GetForm(ref frmGlobalFilter_instance, ref frmGlobalFilter_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmGlobalFilter_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmGroupSales frmGroupSales_instance;
			bool frmGroupSales_isCreating;
			public global::_4PosBackOffice.NET.frmGroupSales frmGroupSales {
				[DebuggerStepThrough] get { return GetForm(ref frmGroupSales_instance, ref frmGroupSales_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmGroupSales_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmGRV frmGRV_instance;
			bool frmGRV_isCreating;
			public global::_4PosBackOffice.NET.frmGRV frmGRV {
				[DebuggerStepThrough] get { return GetForm(ref frmGRV_instance, ref frmGRV_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmGRV_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmGRVblind frmGRVblind_instance;
			bool frmGRVblind_isCreating;
			public global::_4PosBackOffice.NET.frmGRVblind frmGRVblind {
				[DebuggerStepThrough] get { return GetForm(ref frmGRVblind_instance, ref frmGRVblind_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmGRVblind_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmGRVDeposit frmGRVDeposit_instance;
			bool frmGRVDeposit_isCreating;
			public global::_4PosBackOffice.NET.frmGRVDeposit frmGRVDeposit {
				[DebuggerStepThrough] get { return GetForm(ref frmGRVDeposit_instance, ref frmGRVDeposit_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmGRVDeposit_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmGRVimport frmGRVimport_instance;
			bool frmGRVimport_isCreating;
			public global::_4PosBackOffice.NET.frmGRVimport frmGRVimport {
				[DebuggerStepThrough] get { return GetForm(ref frmGRVimport_instance, ref frmGRVimport_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmGRVimport_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmGRVitem frmGRVitem_instance;
			bool frmGRVitem_isCreating;
			public global::_4PosBackOffice.NET.frmGRVitem frmGRVitem {
				[DebuggerStepThrough] get { return GetForm(ref frmGRVitem_instance, ref frmGRVitem_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmGRVitem_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmGRVitemFnV frmGRVitemFnV_instance;
			bool frmGRVitemFnV_isCreating;
			public global::_4PosBackOffice.NET.frmGRVitemFnV frmGRVitemFnV {
				[DebuggerStepThrough] get { return GetForm(ref frmGRVitemFnV_instance, ref frmGRVitemFnV_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmGRVitemFnV_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmGRVItemQuick frmGRVItemQuick_instance;
			bool frmGRVItemQuick_isCreating;
			public global::_4PosBackOffice.NET.frmGRVItemQuick frmGRVItemQuick {
				[DebuggerStepThrough] get { return GetForm(ref frmGRVItemQuick_instance, ref frmGRVItemQuick_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmGRVItemQuick_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmGRVprint frmGRVprint_instance;
			bool frmGRVprint_isCreating;
			public global::_4PosBackOffice.NET.frmGRVprint frmGRVprint {
				[DebuggerStepThrough] get { return GetForm(ref frmGRVprint_instance, ref frmGRVprint_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmGRVprint_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmGRVPromotionItem frmGRVPromotionItem_instance;
			bool frmGRVPromotionItem_isCreating;
			public global::_4PosBackOffice.NET.frmGRVPromotionItem frmGRVPromotionItem {
				[DebuggerStepThrough] get { return GetForm(ref frmGRVPromotionItem_instance, ref frmGRVPromotionItem_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmGRVPromotionItem_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmGRVPromotionList frmGRVPromotionList_instance;
			bool frmGRVPromotionList_isCreating;
			public global::_4PosBackOffice.NET.frmGRVPromotionList frmGRVPromotionList {
				[DebuggerStepThrough] get { return GetForm(ref frmGRVPromotionList_instance, ref frmGRVPromotionList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmGRVPromotionList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmGRVPromotion frmGRVPromotion_instance;
			bool frmGRVPromotion_isCreating;
			public global::_4PosBackOffice.NET.frmGRVPromotion frmGRVPromotion {
				[DebuggerStepThrough] get { return GetForm(ref frmGRVPromotion_instance, ref frmGRVPromotion_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmGRVPromotion_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmGRVselect frmGRVselect_instance;
			bool frmGRVselect_isCreating;
			public global::_4PosBackOffice.NET.frmGRVselect frmGRVselect {
				[DebuggerStepThrough] get { return GetForm(ref frmGRVselect_instance, ref frmGRVselect_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmGRVselect_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmGRVSummary frmGRVSummary_instance;
			bool frmGRVSummary_isCreating;
			public global::_4PosBackOffice.NET.frmGRVSummary frmGRVSummary {
				[DebuggerStepThrough] get { return GetForm(ref frmGRVSummary_instance, ref frmGRVSummary_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmGRVSummary_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmGRVSummaryFnV frmGRVSummaryFnV_instance;
			bool frmGRVSummaryFnV_isCreating;
			public global::_4PosBackOffice.NET.frmGRVSummaryFnV frmGRVSummaryFnV {
				[DebuggerStepThrough] get { return GetForm(ref frmGRVSummaryFnV_instance, ref frmGRVSummaryFnV_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmGRVSummaryFnV_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmGRVTemplate frmGRVTemplate_instance;
			bool frmGRVTemplate_isCreating;
			public global::_4PosBackOffice.NET.frmGRVTemplate frmGRVTemplate {
				[DebuggerStepThrough] get { return GetForm(ref frmGRVTemplate_instance, ref frmGRVTemplate_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmGRVTemplate_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmItemItem frmItemItem_instance;
			bool frmItemItem_isCreating;
			public global::_4PosBackOffice.NET.frmItemItem frmItemItem {
				[DebuggerStepThrough] get { return GetForm(ref frmItemItem_instance, ref frmItemItem_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmItemItem_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmImportStock frmImportStock_instance;
			bool frmImportStock_isCreating;
			public global::_4PosBackOffice.NET.frmImportStock frmImportStock {
				[DebuggerStepThrough] get { return GetForm(ref frmImportStock_instance, ref frmImportStock_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmImportStock_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmIncomeExpense frmIncomeExpense_instance;
			bool frmIncomeExpense_isCreating;
			public global::_4PosBackOffice.NET.frmIncomeExpense frmIncomeExpense {
				[DebuggerStepThrough] get { return GetForm(ref frmIncomeExpense_instance, ref frmIncomeExpense_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmIncomeExpense_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmIncrement frmIncrement_instance;
			bool frmIncrement_isCreating;
			public global::_4PosBackOffice.NET.frmIncrement frmIncrement {
				[DebuggerStepThrough] get { return GetForm(ref frmIncrement_instance, ref frmIncrement_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmIncrement_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmIncrementList frmIncrementList_instance;
			bool frmIncrementList_isCreating;
			public global::_4PosBackOffice.NET.frmIncrementList frmIncrementList {
				[DebuggerStepThrough] get { return GetForm(ref frmIncrementList_instance, ref frmIncrementList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmIncrementList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmKeyboard frmKeyboard_instance;
			bool frmKeyboard_isCreating;
			public global::_4PosBackOffice.NET.frmKeyboard frmKeyboard {
				[DebuggerStepThrough] get { return GetForm(ref frmKeyboard_instance, ref frmKeyboard_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmKeyboard_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmIncrementQuantity frmIncrementQuantity_instance;
			bool frmIncrementQuantity_isCreating;
			public global::_4PosBackOffice.NET.frmIncrementQuantity frmIncrementQuantity {
				[DebuggerStepThrough] get { return GetForm(ref frmIncrementQuantity_instance, ref frmIncrementQuantity_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmIncrementQuantity_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmItem frmItem_instance;
			bool frmItem_isCreating;
			public global::_4PosBackOffice.NET.frmItem frmItem {
				[DebuggerStepThrough] get { return GetForm(ref frmItem_instance, ref frmItem_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmItem_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmItemGroup frmItemGroup_instance;
			bool frmItemGroup_isCreating;
			public global::_4PosBackOffice.NET.frmItemGroup frmItemGroup {
				[DebuggerStepThrough] get { return GetForm(ref frmItemGroup_instance, ref frmItemGroup_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmItemGroup_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmKeyboardGet frmKeyboardGet_instance;
			bool frmKeyboardGet_isCreating;
			public global::_4PosBackOffice.NET.frmKeyboardGet frmKeyboardGet {
				[DebuggerStepThrough] get { return GetForm(ref frmKeyboardGet_instance, ref frmKeyboardGet_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmKeyboardGet_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmKeyboardList frmKeyboardList_instance;
			bool frmKeyboardList_isCreating;
			public global::_4PosBackOffice.NET.frmKeyboardList frmKeyboardList {
				[DebuggerStepThrough] get { return GetForm(ref frmKeyboardList_instance, ref frmKeyboardList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmKeyboardList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmLangList frmLangList_instance;
			bool frmLangList_isCreating;
			public global::_4PosBackOffice.NET.frmLangList frmLangList {
				[DebuggerStepThrough] get { return GetForm(ref frmLangList_instance, ref frmLangList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmLangList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmLangMenu frmLangMenu_instance;
			bool frmLangMenu_isCreating;
			public global::_4PosBackOffice.NET.frmLangMenu frmLangMenu {
				[DebuggerStepThrough] get { return GetForm(ref frmLangMenu_instance, ref frmLangMenu_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmLangMenu_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmLoading frmLoading_instance;
			bool frmLoading_isCreating;
			public global::_4PosBackOffice.NET.frmLoading frmLoading {
				[DebuggerStepThrough] get { return GetForm(ref frmLoading_instance, ref frmLoading_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmLoading_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmLogin frmLogin_instance;
			bool frmLogin_isCreating;
			public global::_4PosBackOffice.NET.frmLogin frmLogin {
				[DebuggerStepThrough] get { return GetForm(ref frmLogin_instance, ref frmLogin_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmLogin_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmMainHO frmMainHO_instance;
			bool frmMainHO_isCreating;
			public global::_4PosBackOffice.NET.frmMainHO frmMainHO {
				[DebuggerStepThrough] get { return GetForm(ref frmMainHO_instance, ref frmMainHO_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmMainHO_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmMainHOParam frmMainHOParam_instance;
			bool frmMainHOParam_isCreating;
			public global::_4PosBackOffice.NET.frmMainHOParam frmMainHOParam {
				[DebuggerStepThrough] get { return GetForm(ref frmMainHOParam_instance, ref frmMainHOParam_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmMainHOParam_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmMaintainWeight frmMaintainWeight_instance;
			bool frmMaintainWeight_isCreating;
			public global::_4PosBackOffice.NET.frmMaintainWeight frmMaintainWeight {
				[DebuggerStepThrough] get { return GetForm(ref frmMaintainWeight_instance, ref frmMaintainWeight_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmMaintainWeight_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmMakeFinishItem frmMakeFinishItem_instance;
			bool frmMakeFinishItem_isCreating;
			public global::_4PosBackOffice.NET.frmMakeFinishItem frmMakeFinishItem {
				[DebuggerStepThrough] get { return GetForm(ref frmMakeFinishItem_instance, ref frmMakeFinishItem_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmMakeFinishItem_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmMakeRepairItem frmMakeRepairItem_instance;
			bool frmMakeRepairItem_isCreating;
			public global::_4PosBackOffice.NET.frmMakeRepairItem frmMakeRepairItem {
				[DebuggerStepThrough] get { return GetForm(ref frmMakeRepairItem_instance, ref frmMakeRepairItem_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmMakeRepairItem_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmMaster frmMaster_instance;
			bool frmMaster_isCreating;
			public global::_4PosBackOffice.NET.frmMaster frmMaster {
				[DebuggerStepThrough] get { return GetForm(ref frmMaster_instance, ref frmMaster_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmMaster_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmMenu frmMenu_instance;
			bool frmMenu_isCreating;
			public global::_4PosBackOffice.NET.frmMenu frmMenu {
				[DebuggerStepThrough] get { return GetForm(ref frmMenu_instance, ref frmMenu_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmMenu_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmLabel frmLabel_instance;
			bool frmLabel_isCreating;
			public global::_4PosBackOffice.NET.frmLabel frmLabel {
				[DebuggerStepThrough] get { return GetForm(ref frmLabel_instance, ref frmLabel_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmLabel_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmLang frmLang_instance;
			bool frmLang_isCreating;
			public global::_4PosBackOffice.NET.frmLang frmLang {
				[DebuggerStepThrough] get { return GetForm(ref frmLang_instance, ref frmLang_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmLang_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmMonthEnd frmMonthEnd_instance;
			bool frmMonthEnd_isCreating;
			public global::_4PosBackOffice.NET.frmMonthEnd frmMonthEnd {
				[DebuggerStepThrough] get { return GetForm(ref frmMonthEnd_instance, ref frmMonthEnd_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmMonthEnd_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmMonthendBudget frmMonthendBudget_instance;
			bool frmMonthendBudget_isCreating;
			public global::_4PosBackOffice.NET.frmMonthendBudget frmMonthendBudget {
				[DebuggerStepThrough] get { return GetForm(ref frmMonthendBudget_instance, ref frmMonthendBudget_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmMonthendBudget_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmMonthendList frmMonthendList_instance;
			bool frmMonthendList_isCreating;
			public global::_4PosBackOffice.NET.frmMonthendList frmMonthendList {
				[DebuggerStepThrough] get { return GetForm(ref frmMonthendList_instance, ref frmMonthendList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmMonthendList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmMTWebReg frmMTWebReg_instance;
			bool frmMTWebReg_isCreating;
			public global::_4PosBackOffice.NET.frmMTWebReg frmMTWebReg {
				[DebuggerStepThrough] get { return GetForm(ref frmMTWebReg_instance, ref frmMTWebReg_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmMTWebReg_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmMWSelect frmMWSelect_instance;
			bool frmMWSelect_isCreating;
			public global::_4PosBackOffice.NET.frmMWSelect frmMWSelect {
				[DebuggerStepThrough] get { return GetForm(ref frmMWSelect_instance, ref frmMWSelect_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmMWSelect_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmLangGet frmLangGet_instance;
			bool frmLangGet_isCreating;
			public global::_4PosBackOffice.NET.frmLangGet frmLangGet {
				[DebuggerStepThrough] get { return GetForm(ref frmLangGet_instance, ref frmLangGet_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmLangGet_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmNewDenomination frmNewDenomination_instance;
			bool frmNewDenomination_isCreating;
			public global::_4PosBackOffice.NET.frmNewDenomination frmNewDenomination {
				[DebuggerStepThrough] get { return GetForm(ref frmNewDenomination_instance, ref frmNewDenomination_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmNewDenomination_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmNewReportGroup frmNewReportGroup_instance;
			bool frmNewReportGroup_isCreating;
			public global::_4PosBackOffice.NET.frmNewReportGroup frmNewReportGroup {
				[DebuggerStepThrough] get { return GetForm(ref frmNewReportGroup_instance, ref frmNewReportGroup_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmNewReportGroup_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmOrder frmOrder_instance;
			bool frmOrder_isCreating;
			public global::_4PosBackOffice.NET.frmOrder frmOrder {
				[DebuggerStepThrough] get { return GetForm(ref frmOrder_instance, ref frmOrder_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmOrder_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmOrderItem frmOrderItem_instance;
			bool frmOrderItem_isCreating;
			public global::_4PosBackOffice.NET.frmOrderItem frmOrderItem {
				[DebuggerStepThrough] get { return GetForm(ref frmOrderItem_instance, ref frmOrderItem_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmOrderItem_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmOrderItemQuick frmOrderItemQuick_instance;
			bool frmOrderItemQuick_isCreating;
			public global::_4PosBackOffice.NET.frmOrderItemQuick frmOrderItemQuick {
				[DebuggerStepThrough] get { return GetForm(ref frmOrderItemQuick_instance, ref frmOrderItemQuick_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmOrderItemQuick_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmOrderPrint frmOrderPrint_instance;
			bool frmOrderPrint_isCreating;
			public global::_4PosBackOffice.NET.frmOrderPrint frmOrderPrint {
				[DebuggerStepThrough] get { return GetForm(ref frmOrderPrint_instance, ref frmOrderPrint_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmOrderPrint_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmOrderSummary frmOrderSummary_instance;
			bool frmOrderSummary_isCreating;
			public global::_4PosBackOffice.NET.frmOrderSummary frmOrderSummary {
				[DebuggerStepThrough] get { return GetForm(ref frmOrderSummary_instance, ref frmOrderSummary_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmOrderSummary_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmOrderWizard frmOrderWizard_instance;
			bool frmOrderWizard_isCreating;
			public global::_4PosBackOffice.NET.frmOrderWizard frmOrderWizard {
				[DebuggerStepThrough] get { return GetForm(ref frmOrderWizard_instance, ref frmOrderWizard_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmOrderWizard_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmOrderWizardFilter frmOrderWizardFilter_instance;
			bool frmOrderWizardFilter_isCreating;
			public global::_4PosBackOffice.NET.frmOrderWizardFilter frmOrderWizardFilter {
				[DebuggerStepThrough] get { return GetForm(ref frmOrderWizardFilter_instance, ref frmOrderWizardFilter_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmOrderWizardFilter_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmOverride frmOverride_instance;
			bool frmOverride_isCreating;
			public global::_4PosBackOffice.NET.frmOverride frmOverride {
				[DebuggerStepThrough] get { return GetForm(ref frmOverride_instance, ref frmOverride_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmOverride_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPackSize frmPackSize_instance;
			bool frmPackSize_isCreating;
			public global::_4PosBackOffice.NET.frmPackSize frmPackSize {
				[DebuggerStepThrough] get { return GetForm(ref frmPackSize_instance, ref frmPackSize_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPackSize_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPackSizeList frmPackSizeList_instance;
			bool frmPackSizeList_isCreating;
			public global::_4PosBackOffice.NET.frmPackSizeList frmPackSizeList {
				[DebuggerStepThrough] get { return GetForm(ref frmPackSizeList_instance, ref frmPackSizeList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPackSizeList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPastelVariables frmPastelVariables_instance;
			bool frmPastelVariables_isCreating;
			public global::_4PosBackOffice.NET.frmPastelVariables frmPastelVariables {
				[DebuggerStepThrough] get { return GetForm(ref frmPastelVariables_instance, ref frmPastelVariables_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPastelVariables_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPayoutGroup frmPayoutGroup_instance;
			bool frmPayoutGroup_isCreating;
			public global::_4PosBackOffice.NET.frmPayoutGroup frmPayoutGroup {
				[DebuggerStepThrough] get { return GetForm(ref frmPayoutGroup_instance, ref frmPayoutGroup_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPayoutGroup_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPayoutGroupList frmPayoutGroupList_instance;
			bool frmPayoutGroupList_isCreating;
			public global::_4PosBackOffice.NET.frmPayoutGroupList frmPayoutGroupList {
				[DebuggerStepThrough] get { return GetForm(ref frmPayoutGroupList_instance, ref frmPayoutGroupList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPayoutGroupList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPerson frmPerson_instance;
			bool frmPerson_isCreating;
			public global::_4PosBackOffice.NET.frmPerson frmPerson {
				[DebuggerStepThrough] get { return GetForm(ref frmPerson_instance, ref frmPerson_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPerson_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPersonFPReg frmPersonFPReg_instance;
			bool frmPersonFPReg_isCreating;
			public global::_4PosBackOffice.NET.frmPersonFPReg frmPersonFPReg {
				[DebuggerStepThrough] get { return GetForm(ref frmPersonFPReg_instance, ref frmPersonFPReg_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPersonFPReg_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPersonFPRegOT frmPersonFPRegOT_instance;
			bool frmPersonFPRegOT_isCreating;
			public global::_4PosBackOffice.NET.frmPersonFPRegOT frmPersonFPRegOT {
				[DebuggerStepThrough] get { return GetForm(ref frmPersonFPRegOT_instance, ref frmPersonFPRegOT_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPersonFPRegOT_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmLangImport frmLangImport_instance;
			bool frmLangImport_isCreating;
			public global::_4PosBackOffice.NET.frmLangImport frmLangImport {
				[DebuggerStepThrough] get { return GetForm(ref frmLangImport_instance, ref frmLangImport_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmLangImport_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPOSreport frmPOSreport_instance;
			bool frmPOSreport_isCreating;
			public global::_4PosBackOffice.NET.frmPOSreport frmPOSreport {
				[DebuggerStepThrough] get { return GetForm(ref frmPOSreport_instance, ref frmPOSreport_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPOSreport_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPersonFPVerify frmPersonFPVerify_instance;
			bool frmPersonFPVerify_isCreating;
			public global::_4PosBackOffice.NET.frmPersonFPVerify frmPersonFPVerify {
				[DebuggerStepThrough] get { return GetForm(ref frmPersonFPVerify_instance, ref frmPersonFPVerify_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPersonFPVerify_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPOSSecurity frmPOSSecurity_instance;
			bool frmPOSSecurity_isCreating;
			public global::_4PosBackOffice.NET.frmPOSSecurity frmPOSSecurity {
				[DebuggerStepThrough] get { return GetForm(ref frmPOSSecurity_instance, ref frmPOSSecurity_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPOSSecurity_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPOSsetup frmPOSsetup_instance;
			bool frmPOSsetup_isCreating;
			public global::_4PosBackOffice.NET.frmPOSsetup frmPOSsetup {
				[DebuggerStepThrough] get { return GetForm(ref frmPOSsetup_instance, ref frmPOSsetup_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPOSsetup_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPersonFPVerifyOT frmPersonFPVerifyOT_instance;
			bool frmPersonFPVerifyOT_isCreating;
			public global::_4PosBackOffice.NET.frmPersonFPVerifyOT frmPersonFPVerifyOT {
				[DebuggerStepThrough] get { return GetForm(ref frmPersonFPVerifyOT_instance, ref frmPersonFPVerifyOT_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPersonFPVerifyOT_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPersonList frmPersonList_instance;
			bool frmPersonList_isCreating;
			public global::_4PosBackOffice.NET.frmPersonList frmPersonList {
				[DebuggerStepThrough] get { return GetForm(ref frmPersonList_instance, ref frmPersonList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPersonList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPOS frmPOS_instance;
			bool frmPOS_isCreating;
			public global::_4PosBackOffice.NET.frmPOS frmPOS {
				[DebuggerStepThrough] get { return GetForm(ref frmPOS_instance, ref frmPOS_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPOS_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPresetList frmPresetList_instance;
			bool frmPresetList_isCreating;
			public global::_4PosBackOffice.NET.frmPresetList frmPresetList {
				[DebuggerStepThrough] get { return GetForm(ref frmPresetList_instance, ref frmPresetList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPresetList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPOSCode frmPOSCode_instance;
			bool frmPOSCode_isCreating;
			public global::_4PosBackOffice.NET.frmPOSCode frmPOSCode {
				[DebuggerStepThrough] get { return GetForm(ref frmPOSCode_instance, ref frmPOSCode_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPOSCode_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmpricechange frmpricechange_instance;
			bool frmpricechange_isCreating;
			public global::_4PosBackOffice.NET.frmpricechange frmpricechange {
				[DebuggerStepThrough] get { return GetForm(ref frmpricechange_instance, ref frmpricechange_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmpricechange_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPriceList frmPriceList_instance;
			bool frmPriceList_isCreating;
			public global::_4PosBackOffice.NET.frmPriceList frmPriceList {
				[DebuggerStepThrough] get { return GetForm(ref frmPriceList_instance, ref frmPriceList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPriceList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPricelistFilter frmPricelistFilter_instance;
			bool frmPricelistFilter_isCreating;
			public global::_4PosBackOffice.NET.frmPricelistFilter frmPricelistFilter {
				[DebuggerStepThrough] get { return GetForm(ref frmPricelistFilter_instance, ref frmPricelistFilter_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPricelistFilter_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPOSlist frmPOSlist_instance;
			bool frmPOSlist_isCreating;
			public global::_4PosBackOffice.NET.frmPOSlist frmPOSlist {
				[DebuggerStepThrough] get { return GetForm(ref frmPOSlist_instance, ref frmPOSlist_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPOSlist_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPricelistFilterList frmPricelistFilterList_instance;
			bool frmPricelistFilterList_isCreating;
			public global::_4PosBackOffice.NET.frmPricelistFilterList frmPricelistFilterList {
				[DebuggerStepThrough] get { return GetForm(ref frmPricelistFilterList_instance, ref frmPricelistFilterList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPricelistFilterList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPricelistItem frmPricelistItem_instance;
			bool frmPricelistItem_isCreating;
			public global::_4PosBackOffice.NET.frmPricelistItem frmPricelistItem {
				[DebuggerStepThrough] get { return GetForm(ref frmPricelistItem_instance, ref frmPricelistItem_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPricelistItem_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPricelistList frmPricelistList_instance;
			bool frmPricelistList_isCreating;
			public global::_4PosBackOffice.NET.frmPricelistList frmPricelistList {
				[DebuggerStepThrough] get { return GetForm(ref frmPricelistList_instance, ref frmPricelistList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPricelistList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPriceSet frmPriceSet_instance;
			bool frmPriceSet_isCreating;
			public global::_4PosBackOffice.NET.frmPriceSet frmPriceSet {
				[DebuggerStepThrough] get { return GetForm(ref frmPriceSet_instance, ref frmPriceSet_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPriceSet_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPriceSetList frmPriceSetList_instance;
			bool frmPriceSetList_isCreating;
			public global::_4PosBackOffice.NET.frmPriceSetList frmPriceSetList {
				[DebuggerStepThrough] get { return GetForm(ref frmPriceSetList_instance, ref frmPriceSetList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPriceSetList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPricingGroup frmPricingGroup_instance;
			bool frmPricingGroup_isCreating;
			public global::_4PosBackOffice.NET.frmPricingGroup frmPricingGroup {
				[DebuggerStepThrough] get { return GetForm(ref frmPricingGroup_instance, ref frmPricingGroup_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPricingGroup_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPricingGroupList frmPricingGroupList_instance;
			bool frmPricingGroupList_isCreating;
			public global::_4PosBackOffice.NET.frmPricingGroupList frmPricingGroupList {
				[DebuggerStepThrough] get { return GetForm(ref frmPricingGroupList_instance, ref frmPricingGroupList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPricingGroupList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPricingMatrix frmPricingMatrix_instance;
			bool frmPricingMatrix_isCreating;
			public global::_4PosBackOffice.NET.frmPricingMatrix frmPricingMatrix {
				[DebuggerStepThrough] get { return GetForm(ref frmPricingMatrix_instance, ref frmPricingMatrix_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPricingMatrix_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPrinter frmPrinter_instance;
			bool frmPrinter_isCreating;
			public global::_4PosBackOffice.NET.frmPrinter frmPrinter {
				[DebuggerStepThrough] get { return GetForm(ref frmPrinter_instance, ref frmPrinter_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPrinter_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPrintLocationList frmPrintLocationList_instance;
			bool frmPrintLocationList_isCreating;
			public global::_4PosBackOffice.NET.frmPrintLocationList frmPrintLocationList {
				[DebuggerStepThrough] get { return GetForm(ref frmPrintLocationList_instance, ref frmPrintLocationList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPrintLocationList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPrintGroup frmPrintGroup_instance;
			bool frmPrintGroup_isCreating;
			public global::_4PosBackOffice.NET.frmPrintGroup frmPrintGroup {
				[DebuggerStepThrough] get { return GetForm(ref frmPrintGroup_instance, ref frmPrintGroup_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPrintGroup_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPricelistFilterItem frmPricelistFilterItem_instance;
			bool frmPricelistFilterItem_isCreating;
			public global::_4PosBackOffice.NET.frmPricelistFilterItem frmPricelistFilterItem {
				[DebuggerStepThrough] get { return GetForm(ref frmPricelistFilterItem_instance, ref frmPricelistFilterItem_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPricelistFilterItem_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmQuoteDelete frmQuoteDelete_instance;
			bool frmQuoteDelete_isCreating;
			public global::_4PosBackOffice.NET.frmQuoteDelete frmQuoteDelete {
				[DebuggerStepThrough] get { return GetForm(ref frmQuoteDelete_instance, ref frmQuoteDelete_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmQuoteDelete_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPrintGroupList frmPrintGroupList_instance;
			bool frmPrintGroupList_isCreating;
			public global::_4PosBackOffice.NET.frmPrintGroupList frmPrintGroupList {
				[DebuggerStepThrough] get { return GetForm(ref frmPrintGroupList_instance, ref frmPrintGroupList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPrintGroupList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPrintLocation frmPrintLocation_instance;
			bool frmPrintLocation_isCreating;
			public global::_4PosBackOffice.NET.frmPrintLocation frmPrintLocation {
				[DebuggerStepThrough] get { return GetForm(ref frmPrintLocation_instance, ref frmPrintLocation_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPrintLocation_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPromotionItem frmPromotionItem_instance;
			bool frmPromotionItem_isCreating;
			public global::_4PosBackOffice.NET.frmPromotionItem frmPromotionItem {
				[DebuggerStepThrough] get { return GetForm(ref frmPromotionItem_instance, ref frmPromotionItem_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPromotionItem_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPromotionList frmPromotionList_instance;
			bool frmPromotionList_isCreating;
			public global::_4PosBackOffice.NET.frmPromotionList frmPromotionList {
				[DebuggerStepThrough] get { return GetForm(ref frmPromotionList_instance, ref frmPromotionList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPromotionList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmPromotion frmPromotion_instance;
			bool frmPromotion_isCreating;
			public global::_4PosBackOffice.NET.frmPromotion frmPromotion {
				[DebuggerStepThrough] get { return GetForm(ref frmPromotion_instance, ref frmPromotion_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmPromotion_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmSelComp frmSelComp_instance;
			bool frmSelComp_isCreating;
			public global::_4PosBackOffice.NET.frmSelComp frmSelComp {
				[DebuggerStepThrough] get { return GetForm(ref frmSelComp_instance, ref frmSelComp_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmSelComp_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmSelCompChk frmSelCompChk_instance;
			bool frmSelCompChk_isCreating;
			public global::_4PosBackOffice.NET.frmSelCompChk frmSelCompChk {
				[DebuggerStepThrough] get { return GetForm(ref frmSelCompChk_instance, ref frmSelCompChk_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmSelCompChk_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmSerialNumber frmSerialNumber_instance;
			bool frmSerialNumber_isCreating;
			public global::_4PosBackOffice.NET.frmSerialNumber frmSerialNumber {
				[DebuggerStepThrough] get { return GetForm(ref frmSerialNumber_instance, ref frmSerialNumber_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmSerialNumber_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmSet frmSet_instance;
			bool frmSet_isCreating;
			public global::_4PosBackOffice.NET.frmSet frmSet {
				[DebuggerStepThrough] get { return GetForm(ref frmSet_instance, ref frmSet_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmSet_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmSetItem frmSetItem_instance;
			bool frmSetItem_isCreating;
			public global::_4PosBackOffice.NET.frmSetItem frmSetItem {
				[DebuggerStepThrough] get { return GetForm(ref frmSetItem_instance, ref frmSetItem_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmSetItem_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmSetList frmSetList_instance;
			bool frmSetList_isCreating;
			public global::_4PosBackOffice.NET.frmSetList frmSetList {
				[DebuggerStepThrough] get { return GetForm(ref frmSetList_instance, ref frmSetList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmSetList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmShrink frmShrink_instance;
			bool frmShrink_isCreating;
			public global::_4PosBackOffice.NET.frmShrink frmShrink {
				[DebuggerStepThrough] get { return GetForm(ref frmShrink_instance, ref frmShrink_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmShrink_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStock frmStock_instance;
			bool frmStock_isCreating;
			public global::_4PosBackOffice.NET.frmStock frmStock {
				[DebuggerStepThrough] get { return GetForm(ref frmStock_instance, ref frmStock_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStock_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmRegister frmRegister_instance;
			bool frmRegister_isCreating;
			public global::_4PosBackOffice.NET.frmRegister frmRegister {
				[DebuggerStepThrough] get { return GetForm(ref frmRegister_instance, ref frmRegister_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmRegister_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockBarcode frmStockBarcode_instance;
			bool frmStockBarcode_isCreating;
			public global::_4PosBackOffice.NET.frmStockBarcode frmStockBarcode {
				[DebuggerStepThrough] get { return GetForm(ref frmStockBarcode_instance, ref frmStockBarcode_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockBarcode_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockBreak frmStockBreak_instance;
			bool frmStockBreak_isCreating;
			public global::_4PosBackOffice.NET.frmStockBreak frmStockBreak {
				[DebuggerStepThrough] get { return GetForm(ref frmStockBreak_instance, ref frmStockBreak_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockBreak_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmRegisterAgree frmRegisterAgree_instance;
			bool frmRegisterAgree_isCreating;
			public global::_4PosBackOffice.NET.frmRegisterAgree frmRegisterAgree {
				[DebuggerStepThrough] get { return GetForm(ref frmRegisterAgree_instance, ref frmRegisterAgree_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmRegisterAgree_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockBreakList frmStockBreakList_instance;
			bool frmStockBreakList_isCreating;
			public global::_4PosBackOffice.NET.frmStockBreakList frmStockBreakList {
				[DebuggerStepThrough] get { return GetForm(ref frmStockBreakList_instance, ref frmStockBreakList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockBreakList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmReportGroupList frmReportGroupList_instance;
			bool frmReportGroupList_isCreating;
			public global::_4PosBackOffice.NET.frmReportGroupList frmReportGroupList {
				[DebuggerStepThrough] get { return GetForm(ref frmReportGroupList_instance, ref frmReportGroupList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmReportGroupList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockBreakShrink frmStockBreakShrink_instance;
			bool frmStockBreakShrink_isCreating;
			public global::_4PosBackOffice.NET.frmStockBreakShrink frmStockBreakShrink {
				[DebuggerStepThrough] get { return GetForm(ref frmStockBreakShrink_instance, ref frmStockBreakShrink_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockBreakShrink_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockChildMessage frmStockChildMessage_instance;
			bool frmStockChildMessage_isCreating;
			public global::_4PosBackOffice.NET.frmStockChildMessage frmStockChildMessage {
				[DebuggerStepThrough] get { return GetForm(ref frmStockChildMessage_instance, ref frmStockChildMessage_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockChildMessage_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockfromFile frmStockfromFile_instance;
			bool frmStockfromFile_isCreating;
			public global::_4PosBackOffice.NET.frmStockfromFile frmStockfromFile {
				[DebuggerStepThrough] get { return GetForm(ref frmStockfromFile_instance, ref frmStockfromFile_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockfromFile_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmReportPriceList frmReportPriceList_instance;
			bool frmReportPriceList_isCreating;
			public global::_4PosBackOffice.NET.frmReportPriceList frmReportPriceList {
				[DebuggerStepThrough] get { return GetForm(ref frmReportPriceList_instance, ref frmReportPriceList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmReportPriceList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockGroup frmStockGroup_instance;
			bool frmStockGroup_isCreating;
			public global::_4PosBackOffice.NET.frmStockGroup frmStockGroup {
				[DebuggerStepThrough] get { return GetForm(ref frmStockGroup_instance, ref frmStockGroup_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockGroup_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockGroupList frmStockGroupList_instance;
			bool frmStockGroupList_isCreating;
			public global::_4PosBackOffice.NET.frmStockGroupList frmStockGroupList {
				[DebuggerStepThrough] get { return GetForm(ref frmStockGroupList_instance, ref frmStockGroupList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockGroupList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockGroupListNotes frmStockGroupListNotes_instance;
			bool frmStockGroupListNotes_isCreating;
			public global::_4PosBackOffice.NET.frmStockGroupListNotes frmStockGroupListNotes {
				[DebuggerStepThrough] get { return GetForm(ref frmStockGroupListNotes_instance, ref frmStockGroupListNotes_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockGroupListNotes_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockItem frmStockItem_instance;
			bool frmStockItem_isCreating;
			public global::_4PosBackOffice.NET.frmStockItem frmStockItem {
				[DebuggerStepThrough] get { return GetForm(ref frmStockItem_instance, ref frmStockItem_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockItem_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockItemByGroup frmStockItemByGroup_instance;
			bool frmStockItemByGroup_isCreating;
			public global::_4PosBackOffice.NET.frmStockItemByGroup frmStockItemByGroup {
				[DebuggerStepThrough] get { return GetForm(ref frmStockItemByGroup_instance, ref frmStockItemByGroup_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockItemByGroup_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockItemHistory frmStockItemHistory_instance;
			bool frmStockItemHistory_isCreating;
			public global::_4PosBackOffice.NET.frmStockItemHistory frmStockItemHistory {
				[DebuggerStepThrough] get { return GetForm(ref frmStockItemHistory_instance, ref frmStockItemHistory_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockItemHistory_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockItemNew frmStockItemNew_instance;
			bool frmStockItemNew_isCreating;
			public global::_4PosBackOffice.NET.frmStockItemNew frmStockItemNew {
				[DebuggerStepThrough] get { return GetForm(ref frmStockItemNew_instance, ref frmStockItemNew_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockItemNew_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockList frmStockList_instance;
			bool frmStockList_isCreating;
			public global::_4PosBackOffice.NET.frmStockList frmStockList {
				[DebuggerStepThrough] get { return GetForm(ref frmStockList_instance, ref frmStockList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockList2 frmStockList2_instance;
			bool frmStockList2_isCreating;
			public global::_4PosBackOffice.NET.frmStockList2 frmStockList2 {
				[DebuggerStepThrough] get { return GetForm(ref frmStockList2_instance, ref frmStockList2_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockList2_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockMultiBarcode frmStockMultiBarcode_instance;
			bool frmStockMultiBarcode_isCreating;
			public global::_4PosBackOffice.NET.frmStockMultiBarcode frmStockMultiBarcode {
				[DebuggerStepThrough] get { return GetForm(ref frmStockMultiBarcode_instance, ref frmStockMultiBarcode_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockMultiBarcode_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockMultiCost frmStockMultiCost_instance;
			bool frmStockMultiCost_isCreating;
			public global::_4PosBackOffice.NET.frmStockMultiCost frmStockMultiCost {
				[DebuggerStepThrough] get { return GetForm(ref frmStockMultiCost_instance, ref frmStockMultiCost_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockMultiCost_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockMultiName frmStockMultiName_instance;
			bool frmStockMultiName_isCreating;
			public global::_4PosBackOffice.NET.frmStockMultiName frmStockMultiName {
				[DebuggerStepThrough] get { return GetForm(ref frmStockMultiName_instance, ref frmStockMultiName_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockMultiName_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockMultiPrice frmStockMultiPrice_instance;
			bool frmStockMultiPrice_isCreating;
			public global::_4PosBackOffice.NET.frmStockMultiPrice frmStockMultiPrice {
				[DebuggerStepThrough] get { return GetForm(ref frmStockMultiPrice_instance, ref frmStockMultiPrice_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockMultiPrice_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockPricing frmStockPricing_instance;
			bool frmStockPricing_isCreating;
			public global::_4PosBackOffice.NET.frmStockPricing frmStockPricing {
				[DebuggerStepThrough] get { return GetForm(ref frmStockPricing_instance, ref frmStockPricing_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockPricing_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockSales frmStockSales_instance;
			bool frmStockSales_isCreating;
			public global::_4PosBackOffice.NET.frmStockSales frmStockSales {
				[DebuggerStepThrough] get { return GetForm(ref frmStockSales_instance, ref frmStockSales_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockSales_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockSalesShrink frmStockSalesShrink_instance;
			bool frmStockSalesShrink_isCreating;
			public global::_4PosBackOffice.NET.frmStockSalesShrink frmStockSalesShrink {
				[DebuggerStepThrough] get { return GetForm(ref frmStockSalesShrink_instance, ref frmStockSalesShrink_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockSalesShrink_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockTake frmStockTake_instance;
			bool frmStockTake_isCreating;
			public global::_4PosBackOffice.NET.frmStockTake frmStockTake {
				[DebuggerStepThrough] get { return GetForm(ref frmStockTake_instance, ref frmStockTake_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockTake_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmReportShow frmReportShow_instance;
			bool frmReportShow_isCreating;
			public global::_4PosBackOffice.NET.frmReportShow frmReportShow {
				[DebuggerStepThrough] get { return GetForm(ref frmReportShow_instance, ref frmReportShow_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmReportShow_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockTakeAdd frmStockTakeAdd_instance;
			bool frmStockTakeAdd_isCreating;
			public global::_4PosBackOffice.NET.frmStockTakeAdd frmStockTakeAdd {
				[DebuggerStepThrough] get { return GetForm(ref frmStockTakeAdd_instance, ref frmStockTakeAdd_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockTakeAdd_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmRPfilter frmRPfilter_instance;
			bool frmRPfilter_isCreating;
			public global::_4PosBackOffice.NET.frmRPfilter frmRPfilter {
				[DebuggerStepThrough] get { return GetForm(ref frmRPfilter_instance, ref frmRPfilter_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmRPfilter_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockTakeCSV frmStockTakeCSV_instance;
			bool frmStockTakeCSV_isCreating;
			public global::_4PosBackOffice.NET.frmStockTakeCSV frmStockTakeCSV {
				[DebuggerStepThrough] get { return GetForm(ref frmStockTakeCSV_instance, ref frmStockTakeCSV_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockTakeCSV_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockTakeLIQ frmStockTakeLIQ_instance;
			bool frmStockTakeLIQ_isCreating;
			public global::_4PosBackOffice.NET.frmStockTakeLIQ frmStockTakeLIQ {
				[DebuggerStepThrough] get { return GetForm(ref frmStockTakeLIQ_instance, ref frmStockTakeLIQ_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockTakeLIQ_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmRPpriceCompare frmRPpriceCompare_instance;
			bool frmRPpriceCompare_isCreating;
			public global::_4PosBackOffice.NET.frmRPpriceCompare frmRPpriceCompare {
				[DebuggerStepThrough] get { return GetForm(ref frmRPpriceCompare_instance, ref frmRPpriceCompare_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmRPpriceCompare_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockTakeLIQCode frmStockTakeLIQCode_instance;
			bool frmStockTakeLIQCode_isCreating;
			public global::_4PosBackOffice.NET.frmStockTakeLIQCode frmStockTakeLIQCode {
				[DebuggerStepThrough] get { return GetForm(ref frmStockTakeLIQCode_instance, ref frmStockTakeLIQCode_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockTakeLIQCode_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockTakeSnapshot frmStockTakeSnapshot_instance;
			bool frmStockTakeSnapshot_isCreating;
			public global::_4PosBackOffice.NET.frmStockTakeSnapshot frmStockTakeSnapshot {
				[DebuggerStepThrough] get { return GetForm(ref frmStockTakeSnapshot_instance, ref frmStockTakeSnapshot_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockTakeSnapshot_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockTransfer frmStockTransfer_instance;
			bool frmStockTransfer_isCreating;
			public global::_4PosBackOffice.NET.frmStockTransfer frmStockTransfer {
				[DebuggerStepThrough] get { return GetForm(ref frmStockTransfer_instance, ref frmStockTransfer_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockTransfer_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockValSelect frmStockValSelect_instance;
			bool frmStockValSelect_isCreating;
			public global::_4PosBackOffice.NET.frmStockValSelect frmStockValSelect {
				[DebuggerStepThrough] get { return GetForm(ref frmStockValSelect_instance, ref frmStockValSelect_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockValSelect_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmSupplier frmSupplier_instance;
			bool frmSupplier_isCreating;
			public global::_4PosBackOffice.NET.frmSupplier frmSupplier {
				[DebuggerStepThrough] get { return GetForm(ref frmSupplier_instance, ref frmSupplier_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmSupplier_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockTransferItem frmStockTransferItem_instance;
			bool frmStockTransferItem_isCreating;
			public global::_4PosBackOffice.NET.frmStockTransferItem frmStockTransferItem {
				[DebuggerStepThrough] get { return GetForm(ref frmStockTransferItem_instance, ref frmStockTransferItem_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockTransferItem_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockTransferItemWH frmStockTransferItemWH_instance;
			bool frmStockTransferItemWH_isCreating;
			public global::_4PosBackOffice.NET.frmStockTransferItemWH frmStockTransferItemWH {
				[DebuggerStepThrough] get { return GetForm(ref frmStockTransferItemWH_instance, ref frmStockTransferItemWH_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockTransferItemWH_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmStockTransferWH frmStockTransferWH_instance;
			bool frmStockTransferWH_isCreating;
			public global::_4PosBackOffice.NET.frmStockTransferWH frmStockTransferWH {
				[DebuggerStepThrough] get { return GetForm(ref frmStockTransferWH_instance, ref frmStockTransferWH_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmStockTransferWH_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmSupplierDeposits frmSupplierDeposits_instance;
			bool frmSupplierDeposits_isCreating;
			public global::_4PosBackOffice.NET.frmSupplierDeposits frmSupplierDeposits {
				[DebuggerStepThrough] get { return GetForm(ref frmSupplierDeposits_instance, ref frmSupplierDeposits_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmSupplierDeposits_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmTopSelectGRV frmTopSelectGRV_instance;
			bool frmTopSelectGRV_isCreating;
			public global::_4PosBackOffice.NET.frmTopSelectGRV frmTopSelectGRV {
				[DebuggerStepThrough] get { return GetForm(ref frmTopSelectGRV_instance, ref frmTopSelectGRV_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmTopSelectGRV_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmTopSelectNon frmTopSelectNon_instance;
			bool frmTopSelectNon_isCreating;
			public global::_4PosBackOffice.NET.frmTopSelectNon frmTopSelectNon {
				[DebuggerStepThrough] get { return GetForm(ref frmTopSelectNon_instance, ref frmTopSelectNon_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmTopSelectNon_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmUpdateCatalogue frmUpdateCatalogue_instance;
			bool frmUpdateCatalogue_isCreating;
			public global::_4PosBackOffice.NET.frmUpdateCatalogue frmUpdateCatalogue {
				[DebuggerStepThrough] get { return GetForm(ref frmUpdateCatalogue_instance, ref frmUpdateCatalogue_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmUpdateCatalogue_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmUpdateDayEnd frmUpdateDayEnd_instance;
			bool frmUpdateDayEnd_isCreating;
			public global::_4PosBackOffice.NET.frmUpdateDayEnd frmUpdateDayEnd {
				[DebuggerStepThrough] get { return GetForm(ref frmUpdateDayEnd_instance, ref frmUpdateDayEnd_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmUpdateDayEnd_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmUpdatePOS frmUpdatePOS_instance;
			bool frmUpdatePOS_isCreating;
			public global::_4PosBackOffice.NET.frmUpdatePOS frmUpdatePOS {
				[DebuggerStepThrough] get { return GetForm(ref frmUpdatePOS_instance, ref frmUpdatePOS_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmUpdatePOS_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmUpdatePOScriteria frmUpdatePOScriteria_instance;
			bool frmUpdatePOScriteria_isCreating;
			public global::_4PosBackOffice.NET.frmUpdatePOScriteria frmUpdatePOScriteria {
				[DebuggerStepThrough] get { return GetForm(ref frmUpdatePOScriteria_instance, ref frmUpdatePOScriteria_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmUpdatePOScriteria_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmUpdateReportData frmUpdateReportData_instance;
			bool frmUpdateReportData_isCreating;
			public global::_4PosBackOffice.NET.frmUpdateReportData frmUpdateReportData {
				[DebuggerStepThrough] get { return GetForm(ref frmUpdateReportData_instance, ref frmUpdateReportData_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmUpdateReportData_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmUpdateWarning frmUpdateWarning_instance;
			bool frmUpdateWarning_isCreating;
			public global::_4PosBackOffice.NET.frmUpdateWarning frmUpdateWarning {
				[DebuggerStepThrough] get { return GetForm(ref frmUpdateWarning_instance, ref frmUpdateWarning_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmUpdateWarning_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmVAT frmVAT_instance;
			bool frmVAT_isCreating;
			public global::_4PosBackOffice.NET.frmVAT frmVAT {
				[DebuggerStepThrough] get { return GetForm(ref frmVAT_instance, ref frmVAT_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmVAT_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmVATList frmVATList_instance;
			bool frmVATList_isCreating;
			public global::_4PosBackOffice.NET.frmVATList frmVATList {
				[DebuggerStepThrough] get { return GetForm(ref frmVATList_instance, ref frmVATList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmVATList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmVegTest frmVegTest_instance;
			bool frmVegTest_isCreating;
			public global::_4PosBackOffice.NET.frmVegTest frmVegTest {
				[DebuggerStepThrough] get { return GetForm(ref frmVegTest_instance, ref frmVegTest_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmVegTest_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmVegTestCode frmVegTestCode_instance;
			bool frmVegTestCode_isCreating;
			public global::_4PosBackOffice.NET.frmVegTestCode frmVegTestCode {
				[DebuggerStepThrough] get { return GetForm(ref frmVegTestCode_instance, ref frmVegTestCode_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmVegTestCode_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmSupplierList frmSupplierList_instance;
			bool frmSupplierList_isCreating;
			public global::_4PosBackOffice.NET.frmSupplierList frmSupplierList {
				[DebuggerStepThrough] get { return GetForm(ref frmSupplierList_instance, ref frmSupplierList_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmSupplierList_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmVegTestGRV frmVegTestGRV_instance;
			bool frmVegTestGRV_isCreating;
			public global::_4PosBackOffice.NET.frmVegTestGRV frmVegTestGRV {
				[DebuggerStepThrough] get { return GetForm(ref frmVegTestGRV_instance, ref frmVegTestGRV_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmVegTestGRV_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmVegTestSelect frmVegTestSelect_instance;
			bool frmVegTestSelect_isCreating;
			public global::_4PosBackOffice.NET.frmVegTestSelect frmVegTestSelect {
				[DebuggerStepThrough] get { return GetForm(ref frmVegTestSelect_instance, ref frmVegTestSelect_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmVegTestSelect_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmVegTestStockBack frmVegTestStockBack_instance;
			bool frmVegTestStockBack_isCreating;
			public global::_4PosBackOffice.NET.frmVegTestStockBack frmVegTestStockBack {
				[DebuggerStepThrough] get { return GetForm(ref frmVegTestStockBack_instance, ref frmVegTestStockBack_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmVegTestStockBack_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmSupplierStatement frmSupplierStatement_instance;
			bool frmSupplierStatement_isCreating;
			public global::_4PosBackOffice.NET.frmSupplierStatement frmSupplierStatement {
				[DebuggerStepThrough] get { return GetForm(ref frmSupplierStatement_instance, ref frmSupplierStatement_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmSupplierStatement_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmSupplierTransaction frmSupplierTransaction_instance;
			bool frmSupplierTransaction_isCreating;
			public global::_4PosBackOffice.NET.frmSupplierTransaction frmSupplierTransaction {
				[DebuggerStepThrough] get { return GetForm(ref frmSupplierTransaction_instance, ref frmSupplierTransaction_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmSupplierTransaction_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmTopSelect frmTopSelect_instance;
			bool frmTopSelect_isCreating;
			public global::_4PosBackOffice.NET.frmTopSelect frmTopSelect {
				[DebuggerStepThrough] get { return GetForm(ref frmTopSelect_instance, ref frmTopSelect_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmTopSelect_instance, value); }
			}
			
			global::_4PosBackOffice.NET.frmTopSelectCustomer frmTopSelectCustomer_instance;
			bool frmTopSelectCustomer_isCreating;
			public global::_4PosBackOffice.NET.frmTopSelectCustomer frmTopSelectCustomer {
				[DebuggerStepThrough] get { return GetForm(ref frmTopSelectCustomer_instance, ref frmTopSelectCustomer_isCreating); }
				[DebuggerStepThrough] set { SetForm(ref frmTopSelectCustomer_instance, value); }
			}
			
			[DebuggerStepThrough]
			static T GetForm<T>(ref T instance, ref bool isCreating) where T : Form, new()
			{
				if (instance == null || instance.IsDisposed) {
					if (isCreating) {
						throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate", new string[0]));
					}
					isCreating = true;
					try {
						instance = new T();
					} catch (System.Reflection.TargetInvocationException ex) {
						throw new InvalidOperationException(Utils.GetResourceString("WinForms_SeeInnerException", new string[] { ex.InnerException.Message }), ex.InnerException);
					} finally {
						isCreating = false;
					}
				}
				return instance;
			}
			
			[DebuggerStepThrough]
			static void SetForm<T>(ref T instance, T value) where T : Form
			{
				if (instance != value) {
					if (value == null) {
						instance.Dispose();
						instance = null;
					} else {
						throw new ArgumentException("Property can only be set to null");
					}
				}
			}
		}
	}
	
	partial class MyApplication : WindowsFormsApplicationBase
	{
		[STAThread]
		public static void Main(string[] args)
		{
			Application.SetCompatibleTextRenderingDefault(UseCompatibleTextRendering);
			MyProject.Application.Run(args);
		}
	}
	
	partial class MyComputer : Computer
	{
	}
}
