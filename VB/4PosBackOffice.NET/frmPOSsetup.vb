Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmPOSsetup
	Inherits System.Windows.Forms.Form
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim mbChangedByCode As Boolean
    Dim mvBookMark As Integer
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
	Dim loading As Boolean
	Dim gID As Integer
	Dim gLines As Integer

    Dim txtFields As New List(Of TextBox)
    Dim txtInteger As New List(Of TextBox)
    Dim txtPrice As New List(Of TextBox)
    Dim optDeposits As New List(Of RadioButton)
    Dim optPrint As New List(Of RadioButton)

	Const bit_deposit1 As Short = 1
	Const bit_deposit2 As Short = 2
	Const bit_Sets As Short = 4
	Const bit_Shrink As Short = 8
	Const bit_Suppress As Short = 16
	Const bit_Lines As Short = 32
	Const bit_SuppressCashup As Short = 64
	Const bit_BlindDeclaration As Short = 128
	Const bit_DeclarationQuick As Short = 256
	Const bit_OpenTill As Short = 512
	Const bit_autoSearch As Short = 1024
	Const bit_bypassTender As Short = 2048
	Const bit_bypassSecurity As Short = 4096
	Const bit_itemNoReceipt As Short = 8192
	Const bit_autoLogoff As Short = 16384
	Const bit_A4Paramet As Integer = 32768 'Printing exclusive A4 Invoice
	Const bit_Cardrefere As Integer = 65536 'Card Ref parameter
	Const bit_OrderRefer As Integer = 131072 'Order Ref parameter
	Const bit_SerialRef As Integer = 262144 'Serial Ref parameter
	Const bit_SerialTra As Integer = 524288
	Const bit_IntVATPrint As Integer = 1048576 'To enable currecncy bit
	Const bit_LearningPOS As Integer = 2097152
	Const bit_DisplaySell As Integer = 4194304
	Const bit_FinalizeCash As Integer = 8388608
	Const bit_CheckCash As Integer = 16777216
	Const bit_ConCashUp As Integer = 33554432
	Const bit_CustBal As Integer = 67108864
	
	Private Sub loadLanguage()
		
		'frmPOSsetup = No Code          [Point Of Sale Parameters]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmPOSsetup.Caption = rsLang("LanguageLayoutLnk_Description"): frmPOSsetup.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lbl_5 = Receipt Details       [Receipt Details]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_5.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblLabels_0 = No Code         [First Receipt Heading Line]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblLabels_1 = No Code         [Second Receipt Heading Line]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblLabels_2 = No Code         [Third Receipt Heading Line]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblLabels_3 = No Code         [Receipt Footer]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_3.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblLabels_4 = No Code         [VAT Number]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_4.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_0 = No Code               [Transaction Prints]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Frame1 = No Code               [Print POS Transaction]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Frame1.Caption = rsLang("LanguageLayoutLnk_Description"): Frame1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2362 'Yes|Checked
		If rsLang.RecordCount Then optPrint(1).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : optPrint(1).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2363 'No|Checked
		If rsLang.RecordCount Then optPrint(2).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : optPrint(2).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'optPrint(0) = No Code          [Ask]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then optPrint(0).Caption = rsLang("LanguageLayoutLnk_Description"): optPrint(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblLabels_5 = No Code         [No of Account Payment Prints]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_5.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblLabels_6 = No Code         [No of Account Sale Prints]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_6.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_6.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblLabels_7 = No Code         [Cash Before Delivery Prints]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_7.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_7.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblLabels_8 = No Code         [No of Consignement Prints]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_8.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_8.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Note: _lblLabels_9.Caption has a grammar/spelling mistake!!!
		'_lblLabels_9 = No Code         [No of Payout Prints]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_9.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_9.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_1 = No Code               [Other Parameters]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1201 'Deposits|Checked
		If rsLang.RecordCount Then frmDeposits.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : frmDeposits.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'optDeposits(0) = No Code       [Pricing Group One]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then optDeposits(0).Caption = rsLang("LanguageLayoutLnk_Description"): optDeposits(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'optDeposits(1) = No Code       [Pricing Group Two]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then optDeposits(1).Caption = rsLang("LanguageLayoutLnk_Description"): optDeposits(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'optDeposits(2) = No Code       [Automatically Determined]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then optDeposits(2).Caption = rsLang("LanguageLayoutLnk_Description"): optDeposits(2).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkPrintinvoice = No Code      [Do Not Print VAT on Invoice]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkPrintinvoice.Caption = rsLang("LanguageLayoutLnk_Description"): chkPrintinvoice.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkConCashup = No Code         [Activate Consolidate Cashup]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkConCashup.Caption = rsLang("LanguageLayoutLnk_Description"): chkConCashup.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkCustBal = No Code           [Print Customer Balances]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkCustBal.Caption = rsLang("LanguageLayoutLnk_Description"): chkCustBal.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkCardNumber = No Code        [Card Number Reference]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkCardNumber.Caption = rsLang("LanguageLayoutLnk_Description"): chkCardNumber.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkOrderNumber = No Code       [Order Number Reference]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkOrderNumber.Caption = rsLang("LanguageLayoutLnk_Description"): chkOrderNumber.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkSerialNumber = No Code      [Serial Reference Number]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkSerialNumber.Caption = rsLang("LanguageLayoutLnk_Description"): chkSerialNumber.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkSets = No Code              [Automatically Build Sets]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkSets.Caption = rsLang("LanguageLayoutLnk_Description"): chkSets.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkShrink = No Code            [Automatically Build Shrinks]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkShrink.Caption = rsLang("LanguageLayoutLnk_Description"): chkShrink.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkSuppress = No Code          [Switch on Suppress After Cashup]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkSuppress.Caption = rsLang("LanguageLayoutLnk_Description"): chkSuppress.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkBlindCashup = No Code       [Blind Cashup]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkBlindCashup.Caption = rsLang("LanguageLayoutLnk_Description"): cmdBlindCashup.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkQuickCashup = No Code       [Quick Cashup]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkQuickCashup.Caption = rsLang("LanguageLayoutLnk_Description"): chkQuickCashup.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkOpenTill = No Code          [Only Open Till for Cash Transaction]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkOpenTill.Caption = rsLang("LanguageLayoutLnk_Description"): chkOpenTill.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkDevidingLine = No Code      [Print Deviding Line on Receipt]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkPrintDividingLine.Caption = rsLang("LanguageLayoutLnk_Description"): chkPrintDividingLine.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkSearchAuto = No Code        [Automatically search for stock items]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkSearchAuto.Caption = rsLang("LanguageLayoutLnk_Description"): chkSearchAuto.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkSecurityPopup = No Code     [Bypass Security Popup]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkSecurityPopup.Caption = rsLang("LanguageLayoutLnk_Description"): chkSecurityPopup.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkBypassTender = No Code      [Bypass Cashout Tender]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkBypassTender.Caption = rsLang("LanguageLayoutLnk_Description"): chkBypassTender.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkReceiptBarcode = No Code    [Print Barcodes on Receipts]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkReceiptBarcode.Caption = rsLang("LanguageLayoutLnk_Description"): chkReceiptBarcode.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkLogoffAuto = No Code        [Automatically Logoff Cashier]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkLogoffauto.Caption = rsLang("LanguageLayoutLnk_Description"): chkLogoffAuto.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkPrintA4 = No Code           [Print A4 Invoice with Exclusive Total]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkPrintA4.Caption = rsLang("LanguageLayoutLnk_Description"): chkPrintA4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkLearningPOS = No Code       [POS Learning Mode]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkLearningPOS.Caption = rsLang("LanguageLayoutLnk_Description"): chkLearningPOS.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkDisplaySelling = No Code    [Display Selling Price]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkDisplaySelling.Caption = rsLang("LanguageLayoutLnk_Description"): chkDisplaySelling.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkFinalizeCash = No Code      [Cash sales have to be finalized (Touch)
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkFinalizeCash.Caption = rsLang("LanguageLayoutLnk_Description"): chkFinalizeCash.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")]
		
		'chkCheckCash = No Code         [Remove Excess Cash from Till]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkCheckCash.Caption = rsLang("LanguageLayoutLnk_Description"): chkCheckCash.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Note: Grammar for _lblLabels_10.Caption not 100%
		'_lblLabels_10 = No Code        [Cent Rounding: Default = 5 Cents, Max = 50 Cents]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_10.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_10.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmPOSsetup.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub buildDataControls()
		loading = True
		If (adoPrimaryRS.Fields("Company_POSparameters").Value And bit_deposit1) Then
			If (adoPrimaryRS.Fields("Company_POSparameters").Value And bit_deposit2) Then
                _optDeposits_2.Checked = True
			Else
                _optDeposits_0.Checked = True
			End If
		Else
            _optDeposits_1.Checked = True
		End If
		
		Me.chkSets.CheckState = System.Math.Abs(CShort(CBool(adoPrimaryRS.Fields("Company_POSparameters").Value And bit_Sets)))
		Me.chkShrink.CheckState = System.Math.Abs(CShort(CBool(adoPrimaryRS.Fields("Company_POSparameters").Value And bit_Shrink)))
		Me.chkSuppress.CheckState = System.Math.Abs(CShort(CBool(adoPrimaryRS.Fields("Company_POSparameters").Value And bit_Suppress)))
		Me.chkBlindCashup.CheckState = System.Math.Abs(CShort(CBool(adoPrimaryRS.Fields("Company_POSparameters").Value And bit_BlindDeclaration)))
		Me.chkDividingLine.CheckState = System.Math.Abs(CShort(CBool(adoPrimaryRS.Fields("Company_POSparameters").Value And bit_Lines)))
		Me.chkQuickCashup.CheckState = System.Math.Abs(CShort(CBool(adoPrimaryRS.Fields("Company_POSparameters").Value And bit_DeclarationQuick)))
		Me.chkOpenTill.CheckState = System.Math.Abs(CShort(CBool(adoPrimaryRS.Fields("Company_POSparameters").Value And bit_OpenTill)))
		Me.chkSearchAuto.CheckState = System.Math.Abs(CShort(CBool(adoPrimaryRS.Fields("Company_POSparameters").Value And bit_autoSearch)))
		Me.chkBypassTender.CheckState = System.Math.Abs(CShort(CBool(adoPrimaryRS.Fields("Company_POSparameters").Value And bit_autoSearch)))
		Me.chkBypassTender.CheckState = System.Math.Abs(CShort(CBool(adoPrimaryRS.Fields("Company_POSparameters").Value And bit_bypassTender)))
		Me.chkSecurityPopup.CheckState = System.Math.Abs(CShort(CBool(adoPrimaryRS.Fields("Company_POSparameters").Value And bit_bypassSecurity)))
		Me.chkReceiptBarcode.CheckState = System.Math.Abs(CShort(CBool(adoPrimaryRS.Fields("Company_POSparameters").Value And bit_itemNoReceipt)))
		Me.chkLogoffAuto.CheckState = System.Math.Abs(CShort(CBool(adoPrimaryRS.Fields("Company_POSparameters").Value And bit_autoLogoff)))
		Me.chkPrintA4.CheckState = System.Math.Abs(CShort(CBool(adoPrimaryRS.Fields("Company_POSparameters").Value And bit_A4Paramet)))
		Me.chkCardNumber.CheckState = System.Math.Abs(CShort(CBool(adoPrimaryRS.Fields("Company_POSparameters").Value And bit_Cardrefere)))
		Me.chkOrderNumber.CheckState = System.Math.Abs(CShort(CBool(adoPrimaryRS.Fields("Company_POSparameters").Value And bit_OrderRefer)))
		Me.chkSerialNumber.CheckState = System.Math.Abs(CShort(CBool(adoPrimaryRS.Fields("Company_POSparameters").Value And bit_SerialRef)))
		Me.chkSerialTracking.CheckState = System.Math.Abs(CShort(CBool(adoPrimaryRS.Fields("Company_POSparameters").Value And bit_SerialTra)))
		Me.chkLearningPOS.CheckState = System.Math.Abs(CShort(CBool(adoPrimaryRS.Fields("Company_POSparameters").Value And bit_LearningPOS)))
		Me.chkDisplaySelling.CheckState = System.Math.Abs(CShort(CBool(adoPrimaryRS.Fields("Company_POSparameters").Value And bit_DisplaySell)))
		Me.chkFinalizeCash.CheckState = System.Math.Abs(CShort(CBool(adoPrimaryRS.Fields("Company_POSparameters").Value And bit_FinalizeCash)))
		Me.chkPrintinvoice.CheckState = System.Math.Abs(CShort(CBool(adoPrimaryRS.Fields("Company_POSparameters").Value And bit_IntVATPrint)))
		Me.chkCheckCash.CheckState = System.Math.Abs(CShort(CBool(adoPrimaryRS.Fields("Company_POSparameters").Value And bit_CheckCash)))
		Me.chkConCashup.CheckState = System.Math.Abs(CShort(CBool(adoPrimaryRS.Fields("Company_POSparameters").Value And bit_ConCashUp)))
		Me.chkCustBal.CheckState = System.Math.Abs(CShort(CBool(adoPrimaryRS.Fields("Company_POSparameters").Value And bit_CustBal)))
		
		loading = False
		
	End Sub
	Private Sub updateBit()
		If loading Then Exit Sub
		Dim lBit As Integer
		
		If Me.chkShrink.CheckState Then lBit = lBit + bit_Shrink
		If Me.chkSuppress.CheckState Then lBit = lBit + bit_Suppress
		If Me.chkSets.CheckState Then lBit = lBit + bit_Sets
		If Me.chkBlindCashup.CheckState Then lBit = lBit + bit_BlindDeclaration
		If Me.chkDividingLine.CheckState Then lBit = lBit + bit_Lines
		If Me.chkQuickCashup.CheckState Then lBit = lBit + bit_DeclarationQuick
		If Me.chkOpenTill.CheckState Then lBit = lBit + bit_OpenTill
		If Me.optDeposits(0).Checked Then lBit = lBit + bit_deposit1
		If Me.optDeposits(1).Checked Then lBit = lBit + bit_deposit2
		If Me.optDeposits(2).Checked Then lBit = lBit + bit_deposit2 + bit_deposit1
		If chkSearchAuto.CheckState Then lBit = lBit + bit_autoSearch
		If Me.chkBypassTender.CheckState Then lBit = lBit + bit_bypassTender
		If chkSecurityPopup.CheckState Then lBit = lBit + bit_bypassSecurity
		If chkReceiptBarcode.CheckState Then lBit = lBit + bit_itemNoReceipt
		If Me.chkLogoffAuto.CheckState Then lBit = lBit + bit_autoLogoff
		If Me.chkPrintA4.CheckState Then lBit = lBit + bit_A4Paramet
		If Me.chkCardNumber.CheckState Then lBit = lBit + bit_Cardrefere
		If Me.chkOrderNumber.CheckState Then lBit = lBit + bit_OrderRefer
		If Me.chkSerialNumber.CheckState Then lBit = lBit + bit_SerialRef
		If Me.chkSerialTracking.CheckState Then lBit = lBit + bit_SerialTra
		If Me.chkLearningPOS.CheckState Then lBit = lBit + bit_LearningPOS
		If Me.chkDisplaySelling.CheckState Then lBit = lBit + bit_DisplaySell
		If Me.chkFinalizeCash.CheckState Then lBit = lBit + bit_FinalizeCash
		If Me.chkPrintinvoice.CheckState Then lBit = lBit + bit_IntVATPrint
		If Me.chkCheckCash.CheckState Then lBit = lBit + bit_CheckCash
		If Me.chkConCashup.CheckState Then lBit = lBit + bit_ConCashUp
		If Me.chkCustBal.CheckState Then lBit = lBit + bit_CustBal
		
		_txtFields_9.Text = CStr(lBit)
		
		
	End Sub
	
	Private Sub doDataControl(ByRef dataControl As System.Windows.Forms.Control, ByRef sql As String, ByRef DataField As String, ByRef boundColumn As String, ByRef listField As String)
        'Dim rs As ADODB.Recordset
        'rs = getRS(sql)
		'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'dataControl.DataSource = rs
		'UPGRADE_ISSUE: Control method dataControl.DataSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        'dataControl.DataSource = adoPrimaryRS
		'UPGRADE_ISSUE: Control method dataControl.DataField was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        'dataControl.DataField = DataField
		'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.boundColumn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'dataControl.boundColumn = boundColumn
		'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.listField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'dataControl.listField = listField
	End Sub
	
	Public Sub loadItem()
		Dim rs As ADODB.Recordset
		
		Dim oText As System.Windows.Forms.TextBox
		Dim oCheck As System.Windows.Forms.CheckBox
		On Error Resume Next
		
		'Old
		'Set adoPrimaryRS = getRS("select CompanyID, Company_PosHeading1,Company_PosHeading2,Company_PosHeading3,Company_PosFooter,Company_TaxNumber,Company_PosPrintAccountPayments,Company_PosPrintAccountSales,Company_PosPrintAccountCOD,Company_PosPrintConsignment,Company_PosParameters,Company_POSRecieptPrint from Company")
		
		'New with text narative
		adoPrimaryRS = getRS("select CompanyID, Company_PosHeading1,Company_PosHeading2,Company_PosHeading3,Company_PosFooter,Company_TaxNumber,Company_PosPrintAccountPayments,Company_PosPrintAccountSales,Company_PosPrintAccountCOD,Company_PosPrintConsignment,Company_POSExcess,Company_PosParameters,Company_POSRecieptPrint,Company_PosPrintPayouts,Company_PosCentRound from Company")
		
		setup()
        For Each oText In txtFields
            oText.DataBindings.Add(adoPrimaryRS)
            oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize
        Next oText
		For	Each oText In Me.txtInteger
            oText.DataBindings.Add(adoPrimaryRS)
            AddHandler oText.Leave, AddressOf txtInteger_Leave
			'txtInteger_Leave(txtInteger.Item((oText.Index)), New System.EventArgs())
		Next oText
		
		For	Each oText In Me.txtPrice
            oText.DataBindings.Add(adoPrimaryRS)
            AddHandler oText.Leave, AddressOf txtPrice_Leave
			'txtPrice_Leave(txtPrice.Item((oText.Index)), New System.EventArgs())
		Next oText
		
		Me._txtPrice_0.Text = FormatNumber(adoPrimaryRS.Fields("Company_POSExcess").Value, 2)
		
		
		'_txtFields_9.MaxLength = 7
		_txtFields_9.Maxlength = 8
		buildDataControls()
		mbDataChanged = False
        'Me.optPrint(_txtFields_5).Checked = True
        If _txtFields_5.Text = "0" Then
            _optPrint_0.Checked = True
        ElseIf _txtFields_5.Text = "1" Then
            _optPrint_1.Checked = True
        Else
            _optPrint_2.Checked = True
        End If

        loadLanguage()
        ShowDialog()
	End Sub
	
	Private Sub setup()
	End Sub
	Private Sub Check1_Click()
		updateBit()
	End Sub
	
	Private Sub chkBlindCashup_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        updateBit()
    End Sub
	
	Private Sub chkBypassTender_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        updateBit()
    End Sub
	
	Private Sub chkCardNumber_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        updateBit()
    End Sub
	
	Private Sub chkConCashup_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        updateBit()
    End Sub
	
	Private Sub chkCurrency_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        updateBit()
    End Sub
	
	Private Sub chkCustBal_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        updateBit()
    End Sub
	
	Private Sub chkDisplaySelling_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        updateBit()
    End Sub
	
	Private Sub chkDividingLine_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        updateBit()
    End Sub
	
	Private Sub chkFinalizeCash_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        updateBit()
    End Sub
	
	Private Sub chkLearningPOS_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        updateBit()
    End Sub
	
	Private Sub chkLogoffAuto_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        updateBit()
    End Sub
	
	Private Sub chkOpenTill_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        updateBit()
    End Sub
	
	Private Sub chkOrderNumber_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        updateBit()
    End Sub
	
	Private Sub chkPrintA4_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        updateBit()
    End Sub
	
	Private Sub chkPrintinvoice_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        updateBit()
    End Sub
	
	Private Sub chkCheckCash_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        updateBit()
    End Sub
	
    Private Sub chkQuickCashup_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        updateBit()
    End Sub

   Private Sub chkReceiptBarcode_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        updateBit()
    End Sub

    Private Sub chkSearchAuto_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        updateBit()
    End Sub

    Private Sub chkSecurityPopup_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        updateBit()
    End Sub

   Private Sub chkSerialNumber_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        updateBit()
    End Sub
    Private Sub chkSerialTracking_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        updateBit()
    End Sub

    Private Sub chkSets_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        updateBit()
    End Sub

    Private Sub chkShrink_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        updateBit()
    End Sub

    Private Sub chkSuppress_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        updateBit()
    End Sub
    Private Sub frmPOSsetup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        ResizeForm(Me, pixelToTwips(Me.Width, True), pixelToTwips(Me.Height, False), 0)
    End Sub

    Private Sub frmPOSsetup_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim cmdLast As New Button
        Dim cmdNext As New Button
        Dim lblStatus As New Label
        On Error Resume Next
        lblStatus.Width = pixelToTwips(Me.Width, True) - 1500
        cmdNext.Left = lblStatus.Width + 700
        cmdLast.Left = cmdNext.Left + 340
    End Sub
    Private Sub frmPOSsetup_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Escape
                KeyAscii = 0
                System.Windows.Forms.Application.DoEvents()
                adoPrimaryRS.Move(0)
                cmdClose_Click(cmdClose, New System.EventArgs())
        End Select

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub frmPOSsetup_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub adoPrimaryRS_MoveComplete(ByVal adReason As ADODB.EventReasonEnum, ByVal pError As ADODB.Error, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.MoveComplete
        'This will display the current record position for this recordset
    End Sub

    Private Sub adoPrimaryRS_WillChangeRecord(ByVal adReason As ADODB.EventReasonEnum, ByVal cRecords As Integer, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.WillChangeRecord
        'This is where you put validation code
        'This event gets called when the following actions occur
        Dim bCancel As Boolean
        Select Case adReason
            Case ADODB.EventReasonEnum.adRsnAddNew
            Case ADODB.EventReasonEnum.adRsnClose
            Case ADODB.EventReasonEnum.adRsnDelete
            Case ADODB.EventReasonEnum.adRsnFirstChange
            Case ADODB.EventReasonEnum.adRsnMove
            Case ADODB.EventReasonEnum.adRsnRequery
            Case ADODB.EventReasonEnum.adRsnResynch
            Case ADODB.EventReasonEnum.adRsnUndoAddNew
            Case ADODB.EventReasonEnum.adRsnUndoDelete
            Case ADODB.EventReasonEnum.adRsnUndoUpdate
            Case ADODB.EventReasonEnum.adRsnUpdate
        End Select

        If bCancel Then adStatus = ADODB.EventStatusEnum.adStatusCancel
    End Sub
    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        On Error Resume Next
        If mbAddNewFlag Then
            Me.Close()
        Else
            mbEditFlag = False
            mbAddNewFlag = False
            adoPrimaryRS.CancelUpdate()
            If mvBookMark > 0 Then
                adoPrimaryRS.Bookmark = mvBookMark
            Else
                adoPrimaryRS.MoveFirst()
            End If
            mbDataChanged = False
        End If
    End Sub

    Private Function update_Renamed() As Boolean
        On Error GoTo UpdateErr
        Dim lDirty As Boolean
        Dim x As Short
        Dim lBit As Short
        lDirty = False
        update_Renamed = True
        If mbAddNewFlag Then
            adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll)
            adoPrimaryRS.MoveLast() 'move to the new record
        Else

            adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll)
            adoPrimaryRS.MoveLast() 'move to the new record
        End If

        mbEditFlag = False
        mbAddNewFlag = False
        mbDataChanged = False

        Exit Function
UpdateErr:
        MsgBox(Err.Description)
        update_Renamed = False
    End Function

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        cmdClose.Focus()
        System.Windows.Forms.Application.DoEvents()

        If update_Renamed() Then
            Me.Close()
        End If
    End Sub

    Private Sub optDeposits_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles optDeposits.CheckedChanged
        If eventSender.Checked Then
            Dim rb As New RadioButton
            rb = DirectCast(eventSender, RadioButton)
            Dim Index As Integer = GetIndexer(rb, optDeposits)
            updateBit()
        End If
    End Sub

    Private Sub optPrint_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles optPrint.CheckedChanged
        If eventSender.Checked Then
            Dim rb As New RadioButton
            rb = DirectCast(eventSender, RadioButton)
            Dim Index As Integer = GetIndexer(rb, optPrint)
            _txtFields_5.Text = CStr(Index)
        End If
    End Sub
    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) ' Handles txtFields.Enter
        Dim txtbox As New TextBox
        txtbox = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txtbox, txtFields)
        MyGotFocus(txtFields(Index))
        '_txtFields_6.Text = FormatNumber(adoPrimaryRS("Company_POSExcess"), 2)
    End Sub
    Private Sub txtFields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtFields.Leave
        Dim txtbox As New TextBox
        txtbox = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txtbox, txtFields)
        MyGotFocus(txtFields(Index))
        '_txtFields_6.Text = FormatNumber(adoPrimaryRS("Company_POSExcess"), 2)
    End Sub

    Private Sub txtInteger_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtInteger.Enter
        Dim txtbox As New TextBox
        txtbox = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txtbox, txtInteger)
        MyGotFocusNumeric(txtInteger(Index))
    End Sub

    Private Sub txtInteger_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) 'Handles txtInteger.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'Dim Index As Short = txtInteger.GetIndex(eventSender)
        MyKeyPress(KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtInteger_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtInteger.Leave
        Dim txtbox As New TextBox
        txtbox = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txtbox, txtInteger)
        MyLostFocus(txtInteger(Index), 0)
        If Index = 0 Then
            If CShort(_txtInteger_0.Text) > 50 Then
                MsgBox("Maximum 50 Cents allowed!", MsgBoxStyle.Critical)
                _txtInteger_0.Text = CStr(50)
                _txtInteger_0.Focus()
            ElseIf CShort(_txtInteger_0.Text) < 1 Then
                MsgBox("Minimum 1 Cents allowed!", MsgBoxStyle.Critical)
                _txtInteger_0.Text = CStr(1)
                _txtInteger_0.Focus()
            End If
        End If
    End Sub

    Private Sub txtFloat_MyGotFocus(ByRef Index As Short)
        '    MyGotFocusNumeric txtFloat(Index)
    End Sub

    Private Sub txtFloat_KeyPress(ByRef Index As Short, ByRef KeyAscii As Short)
        '    KeyPress KeyAscii
    End Sub

    Private Sub txtFloat_MyLostFocus(ByRef Index As Short)
        '    LostFocus txtFloat(Index), 2
    End Sub

    Private Sub txtFloatNegative_MyGotFocus(ByRef Index As Short)
        '    MyGotFocusNumeric txtFloatNegative(Index)
    End Sub

    Private Sub txtFloatNegative_KeyPress(ByRef Index As Short, ByRef KeyAscii As Short)
        '    KeyPressNegative txtFloatNegative(Index), KeyAscii
    End Sub

    Private Sub txtFloatNegative_MyLostFocus(ByRef Index As Short)
        '    LostFocus txtFloatNegative(Index), 2
    End Sub

    Private Sub txtPrice_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtPrice.Enter
        Dim txtbox As New TextBox
        txtbox = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txtbox, txtPrice)
        If txtPrice(Index).Text <> "" Then
            MyGotFocusNumeric(txtPrice(Index))
        End If
    End Sub

    Private Sub txtPrice_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) 'Handles txtPrice.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'Dim Index As Short = txtPrice.GetIndex(eventSender)
        MyKeyPress(KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtPrice_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtPrice.Leave
        Dim txtbox As New TextBox
        txtbox = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txtbox, txtPrice)
        If txtPrice(Index).Text <> "" Then
            MyLostFocus(txtPrice(Index), 2)
        End If
    End Sub

    Private Sub frmPOSsetup_Load1(sender As Object, e As System.EventArgs) Handles Me.Load
        txtFields.AddRange(New TextBox() {_txtFields_0, _txtFields_1, _txtFields_2, _txtFields_3, _
                                          _txtFields_4, _txtFields_5, _txtFields_9})
        txtPrice.AddRange(New TextBox() {_txtPrice_0})
        txtInteger.AddRange(New TextBox() {_txtInteger_0, _txtInteger_5, _txtInteger_6, _txtInteger_7, _
                                           _txtInteger_8, _txtInteger_9})
        optDeposits.AddRange(New RadioButton() {_optDeposits_0, _optDeposits_1, _optDeposits_2})
        optPrint.AddRange(New RadioButton() {_optPrint_0, _optPrint_1, _optPrint_2})
        Dim tb As New TextBox
        Dim rb As New RadioButton
        For Each tb In txtFields
            AddHandler tb.Enter, AddressOf txtFields_Enter
            AddHandler tb.Leave, AddressOf txtFields_Leave
        Next
        AddHandler _txtPrice_0.Enter, AddressOf txtPrice_Enter
        AddHandler _txtPrice_0.KeyPress, AddressOf txtPrice_KeyPress

        For Each rb In optDeposits
            AddHandler rb.Click, AddressOf optDeposits_CheckedChanged
        Next

        For Each rb In optPrint
            AddHandler rb.Click, AddressOf optPrint_CheckedChanged
        Next
    End Sub
End Class