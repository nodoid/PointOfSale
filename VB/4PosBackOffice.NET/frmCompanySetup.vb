Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmCompanySetup
	Inherits System.Windows.Forms.Form
	Private Structure BrowseInfo
		Dim hWndOwner As Integer
		Dim pIDLRoot As Integer
		Dim pszDisplayName As Integer
		Dim lpszTitle As Integer
		Dim ulFlags As Integer
		Dim lpfnCallback As Integer
		Dim lParam As Integer
		Dim iImage As Integer
	End Structure
	Const BIF_RETURNONLYFSDIRS As Short = 1
	'Const MAX_PATH = 260
	Private Declare Sub CoTaskMemFree Lib "ole32.dll" (ByVal hmem As Integer)
	Private Declare Function lstrcat Lib "kernel32"  Alias "lstrcatA"(ByVal lpString1 As String, ByVal lpString2 As String) As Integer
	'UPGRADE_WARNING: Structure BrowseInfo may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function SHBrowseForFolder Lib "shell32" (ByRef lpbi As BrowseInfo) As Integer
	Private Declare Function SHGetPathFromIDList Lib "shell32" (ByVal pidList As Integer, ByVal lpBuffer As String) As Integer
	
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim gID As Integer
    Dim mvBookMark As Integer
	Dim mbChangedByCode As Boolean
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
	Dim loading As Boolean
	Dim g_Emails As Boolean
	
	Const bit_deposit1 As Short = 1
	Const bit_deposit2 As Short = 2
	Const bit_Sets As Short = 4
	Const bit_Shrink As Short = 8
	Const bit_Suppress As Short = 16
	
	Private Const MAX_PATH As Short = 260
	Private Declare Function GetWindowsDirectory Lib "kernel32"  Alias "GetWindowsDirectoryA"(ByVal lpBuffer As String, ByVal nSize As Integer) As Integer
	Private Declare Function GetSystemDirectory Lib "kernel32"  Alias "GetSystemDirectoryA"(ByVal lpBuffer As String, ByVal nSize As Integer) As Integer

    Dim chkBit As New List(Of CheckBox)
    Dim chkFields As New List(Of CheckBox)
    Dim txtFields As New List(Of TextBox)
    Dim cboIntPer As New List(Of ComboBox)

	Dim fso As New Scripting.FileSystemObject
	
	Private Sub loadLanguage()

		'frmCompanySetup = No Code  [Edit Store Details]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmCompanySetup.Caption = rsLang("LanguageLayoutLnk_Description"): frmCompanySetup.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'Command1 = No Code         [Edit Emails]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Command1.Caption = rsLang("LanguageLayoutLnk_Description"): Command1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1010 'General|Checked
		If rsLang.RecordCount Then _lbl_5.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_5.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1934 'Company Name
		If rsLang.RecordCount Then _lblLabels_5.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_5.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lblLabels_0 = No Code     [To change your store name, please contact 4POS Support]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1291 'Physical Address|Checked
		If rsLang.RecordCount Then _lblLabels_6.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_6.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1292 'Postal Address|Checked
		If rsLang.RecordCount Then _lblLabels_7.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_7.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1288 'Telephone|Checked
		If rsLang.RecordCount Then _lblLabels_8.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_8.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1289 'Fax|Checked
		If rsLang.RecordCount Then _lblLabels_9.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_9.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1290 'Email|Checked
		If rsLang.RecordCount Then _lblLabels_10.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_10.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lbl_0 = No Code           [&2. Current Period Numbers]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0
		'If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label6 = No Code           [Pastel period]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label6.Caption = rsLang("LanguageLayoutLnk_Description"): Label6.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblLabels_13 = No Code    [Current Day End Number:]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_13.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_13.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblLabels_14 = No Code    [Current Month End Number]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_14.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_14.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_1 = No Code           [&3. Stock Take Parameters]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_chkFields_4 = No Code     [When print stock take sheets, show Barcode and not Quick Key]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkFields_4.Caption = rsLang("LanguageLayoutLnk_Description"): _chkFields_4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_chkFields_12 = No Code    [When print stock take sheets, show stock value]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkFields_12.Caption = rsLang("LanguageLayoutLnk_Description"): _chkFields_12.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_chkFields_0 = No Code     [When print stock take sheets, dont print zero stock]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkFields_0.Caption = rsLang("LanguageLayoutLnk_Description"): _chkFields_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_chkFields_2 = No Code     [On processing GRV, update GRV Cost to Actual Cost(Default is List Cost)]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkFields_2.Caption = rsLang("LanguageLayoutLnk_Description"): _chkFields_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label8 = No Code           [-------------------------------------------  OR  -------------------------------------------]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label8.Caption = rsLang("LanguageLayoutLnk_Description"): Label8.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_chkBit_11 = No Code       [On processing GRV, update GRV cost to LIST cost && calculate Weighted Avg cost to Actual Cost]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkBit_11.Caption = rsLang("LanguageLayoutLnk_Description"): _chkBit_11.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label9 = No Code           [-------------------------------------------  OR  -------------------------------------------]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label9.Caption = rsLang("LanguageLayoutLnk_Description"): Label9.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_chkBit_13 = No Code       [On processing GRV, Do not update GRV cost to LIST cost && calculate Weighted Avg cost to Actual Cost]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkBit_13.Caption = rsLang("LanguageLayoutLnk_Description"): _chkBit_13.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label10 = No Code          [&4. Language settings]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label10.Caption = rsLang("LanguageLayoutLnk_Description"): Label10.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblLabels_1 = No Code     [Default Language]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_chkFields_6 = No Code     [Right to Left]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkFields_6.Caption = rsLang("LanguageLayoutLnk_Description"): _chkFields_6.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_2 = No Code           [Day End Report Print Parameters]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_chkBit_1 = No Code        [Sale Channel Activities]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkBit_1.Caption = rsLang("LanguageLayoutLnk_Description"): _chkBit_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1961 'Stock Movement Summary|Checked
		If rsLang.RecordCount Then _chkBit_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _chkBit_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_chkBit_3 = No Code        [Print Shrinkage Details]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkBit_3.Caption = rsLang("LanguageLayoutLnk_Description"): _chkBit_3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_chkBit_4 = No Code        [Print Supplier Movement Summary]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkBit_4.Caption = rsLang("LanguageLayoutLnk_Description"): _chkBit_4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_chkBit_5 = No Code        [Print Customer Movement Details]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkBit_5.Caption = rsLang("LanguageLayoutLnk_Description"): _chkBit_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_chkBit_6 = No Code        [Print Quotes]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkBit_6.Caption = rsLang("LanguageLayoutLnk_Description"): _chkBit_6.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_chkBit_7 = No code        [Consignment Summary]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkBit_7.Caption = rsLang("LanguageLayoutLnk_Description"): _chkBit_7.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_chkBit_0 = No Code        [Automatic Pastel Report]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkBit_0.Caption = rsLang("LanguageLayoutLnk_Description"): _chkBit_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_chkBit_10 = No Code       [Automatic Email to Remote Office]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkBit_10.Caption = rsLang("LanguageLayoutLnk_Description"): _chkBit_10.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_3 = No Code           [Other]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_3.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_chkBit_8 = No Code        [4POS Interface Handling]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkBit_8.Caption = rsLang("LanguageLayoutLnk_Description"): _chkBit_8.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_chkFields_1 = No Code     [Allow Day End run to be performed from the 4POS Domain Controller]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkFields_1.Caption = rsLang("LanguageLayoutLnk_Description"): _chkFields_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_chkBit_9 = No Code        [Do Not View Update Warning on update POS]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkBit_9.Caption = rsLang("LanguageLayoutLnk_Description"): _chkBit_9.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_chkBit_12 = No Code       [Automatic Zero Stock At Day End]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkBit_12.Caption = rsLang("LanguageLayoutLnk_Description"): _chkBit_12.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_chkFields_5 = No Code     [Dry Cleaning Customer]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkFields_5.Caption = rsLang("LanguageLayoutLnk_Description"): _chkFields_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label5 = No Code           [Banking Details]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label5.Caption = rsLang("LanguageLayoutLnk_Description"): Label5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1 = No Code           [Bank Name]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label2 = No Code           [Branch Name]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label2.Caption = rsLang("LanguageLayoutLnk_Description"): Label2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label3 = No Code           [Branch Code]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label3.Caption = rsLang("LanguageLayoutLnk_Description"): Label3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1457 'Account Number|Checked
		If rsLang.RecordCount Then Label4.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label4.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'Label7 = No Code           [&8. Interest Percentages]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label7.Caption = rsLang("LanguageLayoutLnk_Description"): Label7.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblinterestper = No Code   [Interest Percentage per Year]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblinterestper.Caption = rsLang("LanguageLayoutLnk_Description"): lblinterestper.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblintrfromper = No Code   [Interest From Period]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblintrfromper.Caption = rsLang("LanguageLayoutLnk_Description"): lblintrfromper.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label11 = No Code          [Open Item Debtors]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label11.Caption = rsLang("LanguageLayoutLnk_Description"): Label11.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_chkFields_7 = No Code     [Use Open Item Debtors for payment allocation]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkFields_7.Caption = rsLang("LanguageLayoutLnk_Description"): _chkFields_7.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_chkFields_8 = No Code     [Do not print 'Balance Due Now' on statements]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _chkFields_8.Caption = rsLang("LanguageLayoutLnk_Description"): _chkFields_8.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmCompanySetup.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	
	Private Sub updateBit()
	End Sub
	
	Private Sub buildDataControls()
		doDataControl((Me.cmbLanguage), "SELECT LanguageLayout.LanguageLayoutID, LanguageLayout.LanguageLayout_Name FROM LanguageLayout ORDER BY LanguageLayout_Name", "Company_LanguageID", "LanguageLayoutID", "LanguageLayout_Name")
	End Sub
    Private Sub doDataControl(ByRef dataControl As myDataGridView, ByRef sql As String, ByRef DataField As String, ByRef boundColumn As String, ByRef listField As String)
        Dim rs As ADODB.Recordset
        rs = getRS(sql)
        'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        dataControl.DataSource = rs
        'UPGRADE_ISSUE: Control method dataControl.DataSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        dataControl.DataSource = adoPrimaryRS
        'UPGRADE_ISSUE: Control method dataControl.DataField was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        dataControl.DataField = DataField
        'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.boundColumn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        dataControl.boundColumn = boundColumn
        'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.listField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        dataControl.listField = listField
    End Sub
	Public Sub loadItem()
		Dim rj As ADODB.Recordset
		Dim oText As System.Windows.Forms.TextBox
		Dim oCheck As System.Windows.Forms.CheckBox
		Dim oComb As System.Windows.Forms.ComboBox
		
		g_Emails = False
		'Working 4 Now...
		adoPrimaryRS = getRS("SELECT Company_Name,Company_PhysicalAddress,Company_PostalAddress,Company_Telephone,Company_Fax,Company_Email,Company_LicenseNumber,Company_TaxNumber,Company_DayEndID,Company_MonthEndID,Company_MonthEndDay,Company_PaymentDay,Company_StockTakeQuantity,Company_StockTakeQuantityOnly,CompanyID, Company_DayEndBit,Company_AutoDayEnd,Company_BankName,Company_BranchCode,Company_BranchName,Company_AccountNumber,Company_IntPercent,Company_IntPeriod,Company_GRVCost,Company_StockTakeBC,Company_DCCustomer,Company_OpenDebtor,Company_LanguageID,Company_RightTL,Company_DebtorPrintBal,Company_FNVegShowVol,Company_CashLess,Company_POPrintBC,Company_ShrinkSign,Company_PrintDayEndSlip,Company_FingerSDK,Company_HOLink,Company_BackupPath,Company_SortOrderItems,Company_MakeFinishSaleChk,Company_LoadTRpt,Company_SecurityPerm FROM Company")
		'Set adoPrimaryRS = getRS("SELECT Company_Name,Company_PhysicalAddress,Company_PostalAddress,Company_Telephone,Company_Fax,Company_Email,Company_LicenseNumber,Company_TaxNumber,Company_DayEndID,Company_MonthEndID,Company_MonthEndDay,Company_PaymentDay,Company_StockTakeQuantity,Company_StockTakeQuantityOnly,CompanyID, Company_DayEndBit,Company_AutoDayEnd,Company_BankName,Company_BranchCode,Company_BranchName,Company_AccountNumber,Company_IntPercent,Company_IntPeriod,Company_GRVCost,Company_MenuUpdate FROM Company")
		
		setup()
		Const gParChannel As Short = 1
		Const gParStock As Short = 2
		Const gParShrink As Short = 4
		Const gParSupplier As Short = 8
		Const gParCustomer As Short = 16
		Const gParQuote As Short = 32
		Const gParConsignment As Short = 64
		Const gParPastelReport As Short = 128 'Pastel Variable
		Const gParPastelPOS As Short = 256 'Pastel Variable
		Const gUpdateWarnin As Short = 512
		Const gCopySalesToHQ As Short = 1024
		Const gActualAndList_U As Short = 2048
		Const gZeroStock_DayEnd As Short = 4096
		Const gLeaveListAct_U As Short = 8192
		
		On Error Resume Next
        For Each oText In txtFields
            oText.DataBindings.Add(adoPrimaryRS)
            oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize
        Next oText
		
		'Bind the check boxes to the data provider
        For Each oCheck In chkFields
            oCheck.DataBindings.Add(adoPrimaryRS)
        Next oCheck
		
		'Bind the combo boxes to the data provider
        For Each oComb In cboIntPer
            oComb.DataSource = adoPrimaryRS
        Next oComb
		
		cboSDK.SelectedIndex = IIf(IsDbNull(adoPrimaryRS.Fields("Company_FingerSDK").Value), 0, adoPrimaryRS.Fields("Company_FingerSDK").Value)
		cboSDK.DataSource = adoPrimaryRS
		
		Me._chkBit_0.CheckState = System.Math.Abs(CInt(CBool(adoPrimaryRS.Fields("Company_DayEndBit").Value And gParPastelReport)))
		Me._chkBit_1.CheckState = System.Math.Abs(CInt(CBool(adoPrimaryRS.Fields("Company_DayEndBit").Value And gParChannel)))
		Me._chkBit_2.CheckState = System.Math.Abs(CInt(CBool(adoPrimaryRS.Fields("Company_DayEndBit").Value And gParStock)))
		Me._chkBit_3.CheckState = System.Math.Abs(CInt(CBool(adoPrimaryRS.Fields("Company_DayEndBit").Value And gParShrink)))
		Me._chkBit_4.CheckState = System.Math.Abs(CInt(CBool(adoPrimaryRS.Fields("Company_DayEndBit").Value And gParSupplier)))
		Me._chkBit_5.CheckState = System.Math.Abs(CInt(CBool(adoPrimaryRS.Fields("Company_DayEndBit").Value And gParCustomer)))
		Me._chkBit_6.CheckState = System.Math.Abs(CInt(CBool(adoPrimaryRS.Fields("Company_DayEndBit").Value And gParQuote)))
		Me._chkBit_7.CheckState = System.Math.Abs(CInt(CBool(adoPrimaryRS.Fields("Company_DayEndBit").Value And gParConsignment)))
		Me._chkBit_8.CheckState = System.Math.Abs(CInt(CBool(adoPrimaryRS.Fields("Company_DayEndBit").Value And gParPastelPOS)))
		Me._chkBit_9.CheckState = System.Math.Abs(CInt(CBool(adoPrimaryRS.Fields("Company_DayEndBit").Value And gUpdateWarnin)))
		Me._chkBit_10.CheckState = System.Math.Abs(CInt(CBool(adoPrimaryRS.Fields("Company_DayEndBit").Value And gCopySalesToHQ)))
		Me._chkBit_11.CheckState = System.Math.Abs(CInt(CBool(adoPrimaryRS.Fields("Company_DayEndBit").Value And gActualAndList_U)))
		Me._chkBit_12.CheckState = System.Math.Abs(CInt(CBool(adoPrimaryRS.Fields("Company_DayEndBit").Value And gZeroStock_DayEnd)))
		Me._chkBit_13.CheckState = System.Math.Abs(CInt(CBool(adoPrimaryRS.Fields("Company_DayEndBit").Value And gLeaveListAct_U)))
		
		'Do pastel variable
		rj = getRS("SELECT Period FROM PastelDescription")
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(rj.Fields("Period").Value) Then
			txtPeriod.Text = CStr(1)
		Else
			txtPeriod.Text = rj.Fields("Period").Value
		End If
		
		buildDataControls()
		mbDataChanged = False
		g_Emails = True
		
		loadLanguage()
		ShowDialog()
	End Sub
	Private Sub setup()
	End Sub
	
	Private Sub chkSets_Click()
		updateBit()
	End Sub
	
	Private Sub chkShrink_Click()
		updateBit()
	End Sub
	
	Private Sub chkSuppress_Click()
		updateBit()
	End Sub
	
	'UPGRADE_WARNING: Event chkBit.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub chkBit_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Integer
        Dim chkBox As New CheckBox
        chkBox = DirectCast(eventSender, CheckBox)
        Index = GetIndexer(chkBox, chkBit)
        If g_Emails <> False Then
            If Index = 10 Then
                If chkBit(Index).CheckState = 1 Then
                    chkFields(15).CheckState = System.Windows.Forms.CheckState.Unchecked
                    If MsgBox("Do you also want to add/edit new Store Emails", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.ApplicationModal, "Store E-mails") = MsgBoxResult.Yes Then
                        frmCompanyEmails.loadItem()
                    End If
                End If
            End If
        End If

        If Index = 11 Then
            If chkBit(Index).CheckState = 1 Then
                _chkFields_2.CheckState = System.Windows.Forms.CheckState.Unchecked
                _chkBit_13.CheckState = System.Windows.Forms.CheckState.Unchecked
            ElseIf chkBit(Index).CheckState = 0 Then
                If _chkFields_2.CheckState = 0 And _chkBit_13.CheckState = 0 Then
                    chkBit(Index).CheckState = System.Windows.Forms.CheckState.Checked
                End If
            End If
        ElseIf Index = 13 Then
            If chkBit(Index).CheckState = 1 Then
                _chkFields_2.CheckState = System.Windows.Forms.CheckState.Unchecked
                _chkBit_11.CheckState = System.Windows.Forms.CheckState.Unchecked
            ElseIf chkBit(Index).CheckState = 0 Then
                If _chkFields_2.CheckState = 0 And _chkBit_11.CheckState = 0 Then
                    chkBit(Index).CheckState = System.Windows.Forms.CheckState.Checked
                End If
            End If
        ElseIf Index = 10 Then
            If chkBit(Index).CheckState = 1 Then
                chkFields(15).CheckState = System.Windows.Forms.CheckState.Unchecked
            End If
        End If
    End Sub
	
	'UPGRADE_WARNING: Event chkFields.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub chkFields_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Integer
        Dim chkBox As New CheckBox
        chkBox = DirectCast(eventSender, CheckBox)
        Index = GetIndexer(chkBox, chkFields)
        If Index = 2 Then
            If chkFields(Index).CheckState = 1 Then
                _chkBit_11.CheckState = System.Windows.Forms.CheckState.Unchecked
                _chkBit_13.CheckState = System.Windows.Forms.CheckState.Unchecked
            ElseIf chkFields(Index).CheckState = 0 Then
                If _chkBit_11.CheckState = 0 And _chkBit_13.CheckState = 0 Then
                    _chkFields_2.CheckState = System.Windows.Forms.CheckState.Checked
                End If
            End If
        End If
        If Index = 15 Then
            If chkFields(Index).CheckState = 1 Then
                _chkBit_10.CheckState = System.Windows.Forms.CheckState.Unchecked
                If g_Emails <> False Then
                    If MsgBox("Do you also want to add/edit Head Offline Link", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.ApplicationModal, "Head Offline Link") = MsgBoxResult.Yes Then
                        frmCompanyEmails.loadItem(True)
                    End If
                End If
            End If
        End If

    End Sub
	
    Private Sub chkFields_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim x As Single = pixelToTwips(eventArgs.X, True)
        Dim y As Single = pixelToTwips(eventArgs.Y, False)
        Dim Index As Integer
        Dim chkBox As New CheckBox
        chkBox = DirectCast(eventSender, CheckBox)
        Index = GetIndexer(chkBox, chkFields)
        Dim rs As ADODB.Recordset
        If g_Emails = True Then
            If Index = 7 Then
                'Set rs = getRS("SELECT Sum(CustomerTransaction.CustomerTransaction_Amount) AS sumTran From CustomerTransaction WHERE (((CustomerTransaction.CustomerTransaction_TransactionTypeID)<>7));")
                rs = getRS("SELECT * From Sale;")
                If rs.RecordCount > 0 Then
                    'If IIf(IsNull(rs("sumTran")), 0, rs("sumTran")) <> 0 Then
                    MsgBox("'Open Item Debtors' option may only be changed right after you do Month End!", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, My.Application.Info.Title)
                    Exit Sub
                    'End If
                End If
            End If
        End If
    End Sub
	
	Private Sub cmdHO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdHO.Click
		'Set variables
		bActiveSession = False
		hOpen = 0
		hConnection = 0
		dwType = FTP_TRANSFER_TYPE_BINARY
		prgCol = "4POS-HQ_"
        NomeFileLog = prgCol & CStr(Format(Now, "ddmmyyyy")) & CStr(Format(Now, "hhmm")) & ".log"
		
		'Check for Zipit file
		If GetSystemPath <> "" Then
			If fso.FileExists(GetSystemPath & "\zipit.dll") Then 
			Else 
				MsgBox("Install headoffice first.") : Exit Sub
			End If
		End If
		
		If LCase(VB.Left(serverPath, 3)) <> "c:\" Then
			MsgBox("4POS HeadOffice Sync Engine must be run on the server", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine")
			Exit Sub
		End If
		
		ServerN = "http://www.4pos.co.za/4HeadOffice/4posheadoffice.pos"
		sqlLinkPath = "http://www.4pos.co.za/4HeadOffice/4posheadoffice.dsl"
		tipftp = CStr(1)
		
		'get HO info
		Dim rs As ADODB.Recordset
		rs = getRS("Select Comp_ID, Comp_Email1, Comp_Email2 FROM CompanyEmails;")
		If rs.RecordCount > 0 Then
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rs.Fields("Comp_ID").Value) Then MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine") : Exit Sub
			'UPGRADE_WARNING: Couldn't resolve default property of object BranchType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			BranchType = rs.Fields("Comp_ID").Value
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rs.Fields("Comp_Email1").Value) Then MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine") : Exit Sub
			If IsNumeric(rs.Fields("Comp_Email1").Value) Then 
			Else 
				MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine") : Exit Sub
			End If
			If CShort(rs.Fields("Comp_Email1").Value) > 0 Then 
			Else 
				MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine") : Exit Sub
			End If
			'UPGRADE_WARNING: Couldn't resolve default property of object HOfficeID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			HOfficeID = rs.Fields("Comp_Email1").Value
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(rs.Fields("Comp_Email2").Value) Then MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine") : Exit Sub
			If IsNumeric(rs.Fields("Comp_Email2").Value) Then 
			Else 
				MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine") : Exit Sub
			End If
			If CShort(rs.Fields("Comp_Email2").Value) > 0 Then 
			Else 
				MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine") : Exit Sub
			End If
			'UPGRADE_WARNING: Couldn't resolve default property of object BranchID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			BranchID = rs.Fields("Comp_Email2").Value
		Else
			MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine")
			Exit Sub
		End If
		
		'CaricaDati  'read the file
		'frmMainHO.Text1.Text = ""
		'frmMainHO.Label1(1).Caption = ""
		'UPGRADE_ISSUE: Load statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"'
        Dim frm As frmMainHO
        frm.Show()
		'PreparaForm
		'frmFTP.Show vbModal
		'frmMainHO.tmrAutoDE.Enabled = True
		frmMainHO.ShowDialog() 'vbModal
	End Sub
	
	Public Function GetSystemPath() As Object
		Dim strFolder As String
		Dim lngResult As Integer
		strFolder = New String(Chr(0), MAX_PATH)
		lngResult = GetSystemDirectory(strFolder, MAX_PATH)
		If lngResult <> 0 Then
			GetSystemPath = VB.Left(strFolder, InStr(strFolder, Chr(0)) - 1)
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object GetSystemPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			GetSystemPath = ""
		End If
	End Function
	
	Private Function GetWinPath() As Object
		Dim strFolder As String
		Dim lngResult As Integer
		strFolder = New String(Chr(0), MAX_PATH)
		lngResult = GetWindowsDirectory(strFolder, MAX_PATH)
		If lngResult <> 0 Then
			GetWinPath = VB.Left(strFolder, InStr(strFolder, Chr(0)) - 1)
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object GetWinPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			GetWinPath = ""
		End If
	End Function
	
	Private Sub cmdLocate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLocate.Click
		Dim iNull As Short
		Dim lpIDList, lresult As Integer
		Dim sPath As String
		Dim udtBI As BrowseInfo
		
		With udtBI
			'Set the owner window
			.hWndOwner = Me.Handle.ToInt32
			'lstrcat appends the two strings and returns the memory address
			.lpszTitle = lstrcat("C:\", "")
			'Return only if the user selected a directory
			.ulFlags = BIF_RETURNONLYFSDIRS
		End With
		
		'Show the 'Browse for folder' dialog
		lpIDList = SHBrowseForFolder(udtBI)
		If lpIDList Then
			sPath = New String(Chr(0), MAX_PATH)
			'Get the path from the IDList
			SHGetPathFromIDList(lpIDList, sPath)
			'free the block of memory
			CoTaskMemFree(lpIDList)
			iNull = InStr(sPath, vbNullChar)
			If iNull Then
				sPath = VB.Left(sPath, iNull - 1)
			End If
		End If
		
		'MsgBox sPath
		If sPath <> "" Then
			_txtFields_11.Text = sPath
		End If
	End Sub
	
	Private Sub cmdSyncParam_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSyncParam.Click
		frmMainHOParam.loadItem()
	End Sub
	
	'Private Sub cmbintperiod_MyLostFocus()
	'IntPeriod = Me.cmbintperiod.Text
	'End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		If Me._chkBit_10.CheckState = 1 Then
			frmCompanyEmails.loadItem()
		End If
		If chkFields(15).CheckState = 1 Then
			frmCompanyEmails.loadItem(True)
		End If
	End Sub
	
	
	Private Sub frmCompanySetup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        chkBit.AddRange(New CheckBox() {_chkBit_0, _chkBit_1, _chkBit_2, _chkBit_3, _chkBit_4, _
                                         _chkBit_5, _chkBit_6, _chkBit_7, _chkBit_8, _chkBit_9, _
                                         _chkBit_10, _chkBit_11, _chkBit_12, _chkBit_13})
        chkFields.AddRange(New CheckBox() {_chkFields_0, _chkFields_1, _chkFields_2, _chkFields_3, _
                                           _chkFields_4, _chkFields_5, _chkFields_6, _chkFields_7, _
                                           _chkFields_8, _chkFields_9, _chkFields_10, _chkFields_11, _
                                           _chkFields_12, _chkFields_13, _chkFields_14, _chkFields_15, _
                                           _chkFields_16, _chkFields_17, _chkFields_18, _chkFields_19})
        txtFields.AddRange(New TextBox() {_txtFields_0, _txtFields_1, _txtFields_2, _txtFields_3, _
                                          _txtFields_4, _txtFields_5, _txtFields_6, _txtFields_7, _
                                          _txtFields_8, _txtFields_9, _txtFields_10, _txtFields_11, _
                                          _txtFields_13, _txtFields_14})
        cboIntPer.AddRange(New ComboBox() {_cboIntPer_0})
        Dim cb As New CheckBox
        Dim tb As New TextBox
        For Each cb In chkBit
            AddHandler cb.CheckStateChanged, AddressOf chkBit_CheckStateChanged
        Next
        For Each cb In chkFields
            AddHandler cb.CheckStateChanged, AddressOf chkFields_CheckStateChanged
            AddHandler cb.MouseDown, AddressOf chkFields_MouseDown
        Next
        For Each tb In txtFields
            AddHandler tb.Enter, AddressOf txtFields_Enter
            AddHandler tb.Leave, AddressOf txtFields_Leave
        Next
		If Intpercen > 0 Then
			'Me.txtintper.Text = Intpercen & ".00"
			
		End If
		
		If IntPeriod <> "" Then
			
			'Me.cmbintperiod.Text = IntPeriod
			
		End If
		
	End Sub
	
	'UPGRADE_WARNING: Event frmCompanySetup.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmCompanySetup_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        Dim cmdLast As New Button
        Dim cmdNext As New Button
        Dim lblStatus As New Label
		On Error Resume Next
		lblStatus.Width = pixelToTwips(Me.Width, True) - 1500
		cmdNext.Left = lblStatus.Width + 700
		cmdLast.Left = cmdNext.Left + 340
	End Sub
	Private Sub frmCompanySetup_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	Private Sub frmCompanySetup_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
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
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
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
	'UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Function update_Renamed() As Boolean
		On Error GoTo UpdateErr
		Dim lDirty As Boolean
		Dim x As Short
		Dim lBit As Short
		Const gParChannel As Short = 1
		Const gParStock As Short = 2
		Const gParShrink As Short = 4
		Const gParSupplier As Short = 8
		Const gParCustomer As Short = 16
		Const gParQuote As Short = 32
		Const gParConsignment As Short = 64
		Const gParPastelReport As Short = 128
		Const gParPastelPOS As Short = 256
		Const gUpdateWarnin As Short = 512
		Const gCopySalesToHQ As Short = 1024
		Const gActualAndList_U As Short = 2048
		Const gZeroStock_DayEnd As Short = 4096
		Const gLeaveListAct_U As Short = 8192
		
		lDirty = False
		update_Renamed = True
		
		If Me._chkBit_1.CheckState Then lBit = lBit + gParChannel
		If Me._chkBit_2.CheckState Then lBit = lBit + gParStock
		If Me._chkBit_3.CheckState Then lBit = lBit + gParShrink
		If Me._chkBit_4.CheckState Then lBit = lBit + gParSupplier
		If Me._chkBit_5.CheckState Then lBit = lBit + gParCustomer
		If Me._chkBit_6.CheckState Then lBit = lBit + gParQuote
		If Me._chkBit_7.CheckState Then lBit = lBit + gParConsignment
		'Pastel logo
		If Me._chkBit_0.CheckState Then lBit = lBit + gParPastelReport
		If Me._chkBit_8.CheckState Then lBit = lBit + gParPastelPOS
		If Me._chkBit_9.CheckState Then lBit = lBit + gUpdateWarnin
		If Me._chkBit_10.CheckState Then lBit = lBit + gCopySalesToHQ
		'Grv's Actual & List Update...
		If Me._chkBit_11.CheckState Then lBit = lBit + gActualAndList_U
		If Me._chkBit_12.CheckState Then lBit = lBit + gZeroStock_DayEnd
		If Me._chkBit_13.CheckState Then lBit = lBit + gLeaveListAct_U
		
        adoPrimaryRS.Fields("Company_FingerSDK").Value = CInt(cboSDK.SelectedIndex)
		
		adoPrimaryRS.Fields("Company_DayEndBit").Value = lBit
		If mbAddNewFlag Then
			adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll)
			adoPrimaryRS.MoveLast() 'move to the new record
		Else
			adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll)
		End If
		
		
		mbEditFlag = False
		mbAddNewFlag = False
		mbDataChanged = False
		
		Exit Function
UpdateErr: 
		MsgBox(Err.Description)
		update_Renamed = False
	End Function
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		cmdClose.Focus()
		System.Windows.Forms.Application.DoEvents()
		
		If Val(txtPeriod.Text) >= 1 And Val(txtPeriod.Text) <= 12 Then
			cnnDB.Execute("UPDATE PastelDescription Set Period = " & Val(txtPeriod.Text))
		Else
			MsgBox("Period Value must be in range of 1 - 12", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Pastel Variables")
			Exit Sub
		End If
		
		'assign Interest percenetage and interest from period to variables
		'IntPeriod = Me.cmbintperiod.Text
		'Intpercen = Me.txtintper.Text
		
		If update_Renamed() Then
			Me.Close()
		End If
	End Sub
	
	Private Sub optDeposits_Click(ByRef Index As Short)
		updateBit()
	End Sub
	
    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Integer
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Index = GetIndexer(txtBox, txtFields)
        MyGotFocus(txtFields(Index))
        If Index = 4 Then
            MyGotFocusNumeric(txtFields(Index))
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
	
    Private Sub txtFields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Integer
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Index = GetIndexer(txtBox, txtFields)
        If Index = 4 Then
            MyLostFocus(_txtFields_4, 2)
            'If _txtFields_4.Text = "" Then _txtFields_4.Text = 0
            'If _txtFields_4.Text < 0 Then
            If CDbl(_txtFields_4.Text) > 100 Then
                MsgBox("Interest Percentage cannot Exceed 100%", MsgBoxStyle.Information, "4Pos Interest Calculation")
                _txtFields_4.Focus()
            End If
        End If
    End Sub
	
	Private Sub txtintper_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtintper.Leave
		On Error Resume Next
        MyLostFocus(txtintper, 2)
		'Dim CheckNo As Double
		'CheckNo = (Len(txtintper))
		'Interest must be less or equal to 100
		
		'If IsNumeric(txtintper.Text) Then
		'MsgBox "Interest Percentage must not contain Alphabets", vbInformation, "4Pos Interest Calculation"
		'Me.txtintper.Text = "0.00"
		'Me.txtintper.SetFocus
		'End If
		
		If CDbl(txtintper.Text) > 100 Then
			MsgBox("Interest Percentage cannot Exceed 100%", MsgBoxStyle.Information, "4Pos Interest Calculation")
			Me.txtintper.Text = "0.00"
			Me.txtintper.Focus()
			
			
			'Me.txtintper.se
		Else
		End If
		
	End Sub
	
	Private Sub txtPeriod_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPeriod.Enter
        MyGotFocusNumeric(txtPeriod)
	End Sub
	Private Sub txtPeriod_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtPeriod.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        MyKeyPress(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	Private Sub txtPeriod_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPeriod.Leave
        MyLostFocus(txtPeriod, 0)
	End Sub
	
	Private Sub cmdProcess_Click(ByRef cID As Object, ByRef cSum As Object)
        Dim amount As Decimal
        Dim txtAmountText As Integer
        Dim txtNarrativeText As String
        Dim txtNotesText As String
        Dim rsCus As ADODB.Recordset
        Dim cSQL As String
		Dim sql As String
		Dim sql1 As String
		Dim rs As ADODB.Recordset
		Dim id As String
		Dim days120, days60, current, lAmount, days30, days90, days150 As Decimal
		System.Windows.Forms.Application.DoEvents()
		'If txtNarrative.Text = "" Then
		'    MsgBox "Narrative is a mandarory field", vbExclamation, Me.Caption
		'    txtNarrative.SetFocus
		'    Exit Sub
		'End If
		'If CCur(txtAmount.Text) = 0 Then
		'   MsgBox "Amount is a mandarory field", vbExclamation, Me.Caption
		'   txtAmount.SetFocus
		'   Exit Sub
		'End If
		
		
		cSQL = "SELECT CustomerTransaction.*, TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit"
		cSQL = cSQL & " FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID"
		cSQL = cSQL & " WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" & cID & "))"
		cSQL = cSQL & " ORDER BY CustomerTransaction.CustomerTransaction_Date DESC;"
		rsCus = getRS(cSQL)
		
		If rsCus.RecordCount < 1 Then Exit Sub
		
		'If CCur(rsCus("CustomerTransaction_Amount")) < 0 Then  'rsCus("credit") <> ""
		'    gSection = 1
		'    txtNotesText = "Zeroise Debitors Accounts"
		'    txtNarrativeText = "Zeroise Debitors Accounts"
		'    txtAmountText = (rsCus("CustomerTransaction_Amount") / -1)
		'End If
		
		'If CCur(rsCus("CustomerTransaction_Amount")) > 0 Then 'rsCus("debit") <> ""
		'gSection = 2
		txtNotesText = "Interest"
		txtNarrativeText = "Interest"
		txtAmountText = System.Math.Round(cSum, 2) '+ (rsCus("CustomerTransaction_Amount"))
		
		'End If
		
		
		sql = "INSERT INTO CustomerTransaction ( CustomerTransaction_CustomerID, CustomerTransaction_TransactionTypeID, CustomerTransaction_DayEndID, CustomerTransaction_MonthEndID, CustomerTransaction_ReferenceID, CustomerTransaction_Date, CustomerTransaction_Description, CustomerTransaction_Amount, CustomerTransaction_Reference, CustomerTransaction_PersonName )"
		'Select Case gSection
		'    Case sec_Payment
		'        sql = sql & "SELECT " & cID & " AS Customer, 3 AS [type], Company.Company_DayEndID, Company.Company_MonthEndID, 0 AS referenceID, Now() AS [Date], '" & Replace(txtNotesText, "'", "''") & "' AS description, " & CCur(0 - CCur(txtAmountText)) & " AS amount, '" & Replace(txtNarrativeText, "'", "''") & "' AS reference, 'System' AS person FROM Company;"
		'    Case sec_Debit
		sql = sql & "SELECT " & cID & " AS Customer, 9 AS [type], Company.Company_DayEndID, Company.Company_MonthEndID, 0 AS referenceID, Now() AS [Date], '" & Replace(txtNotesText, "'", "''") & "' AS description, " & CDec(txtAmountText) & " AS amount, '" & Replace(txtNarrativeText, "'", "''") & "' AS reference, 'System' AS person FROM Company;"
		'    Case sec_Credit
		'        sql = sql & "SELECT " & cID & " AS Customer, 5 AS [type], Company.Company_DayEndID, Company.Company_MonthEndID, 0 AS referenceID, Now() AS [Date], '" & Replace(txtNotesText, "'", "''") & "' AS description, " & CCur(0 - CCur(txtAmountText)) & " AS amount, '" & Replace(txtNarrativeText, "'", "''") & "' AS reference, 'System' AS person FROM Company;"
		'End Select
		
		cnnDB.Execute(sql)
		
		rs = getRS("SELECT MAX(CustomerTransactionID) AS id From CustomerTransaction")
		If rs.BOF Or rs.EOF Then
		Else
			id = rs.Fields("id").Value
			cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_Current = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_Current) Is Null));")
			cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_30Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_30Days) Is Null));")
			cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_60Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_60Days) Is Null));")
			cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_90Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_90Days) Is Null));")
			cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_120Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_120Days) Is Null));")
			cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_150Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" & id & ") AND ((Customer.Customer_150Days) Is Null));")
			
			rs = getRS("SELECT CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_Amount, Customer.Customer_Current, Customer.Customer_30Days, Customer.Customer_60Days, Customer.Customer_90Days, Customer.Customer_120Days, Customer.Customer_150Days FROM Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID Where (((CustomerTransaction.CustomerTransactionID) = " & id & "));")
			
			amount = rs.Fields("CustomerTransaction_Amount").Value
			current = rs.Fields("Customer_Current").Value
			days30 = rs.Fields("Customer_30Days").Value
			days60 = rs.Fields("Customer_60Days").Value
			days90 = rs.Fields("Customer_90Days").Value
			days120 = rs.Fields("Customer_120Days").Value
			days150 = rs.Fields("Customer_150Days").Value
			If amount < 0 Then
				days150 = days150 + amount
				If (days150 < 0) Then
                    amount = days150
					days150 = 0
				Else
					amount = 0
				End If
				days120 = days120 + amount
				If (days120 < 0) Then
					amount = days120
					days120 = 0
				Else
					amount = 0
				End If
				days90 = days90 + amount
				If (days90 < 0) Then
					amount = days90
					days90 = 0
				Else
					amount = 0
				End If
				days60 = days60 + amount
				If (days60 < 0) Then
                    amount = days60
					days60 = 0
				Else
					amount = 0
				End If
				days30 = days30 + amount
				If (days30 < 0) Then
					amount = days30
					days30 = 0
				Else
					amount = 0
				End If
			End If
			current = current + amount
			cnnDB.Execute("UPDATE Customer SET Customer.Customer_Current = " & current & ", Customer.Customer_30Days = " & days30 & ", Customer.Customer_60Days = " & days60 & ", Customer.Customer_90Days = " & days90 & ", Customer.Customer_120Days = " & days120 & ", Customer.Customer_150Days = 0" & days150 & " WHERE (((Customer.CustomerID)=" & rs.Fields("CustomerTransaction_CustomerID").Value & "));")
			'cnnDB.Execute "UPDATE Customer SET Customer.Customer_Current = " & 0 & ", Customer.Customer_30Days = " & 0 & ", Customer.Customer_60Days = " & 0 & ", Customer.Customer_90Days = " & 0 & ", Customer.Customer_120Days = " & 0 & ", Customer.Customer_150Days = " & 0 & " WHERE (((Customer.CustomerID)=" & rs("CustomerTransaction_CustomerID") & "));"
		End If
		
	End Sub
	
	Public Function CalcIntPeriod() As Object
		On Error Resume Next
		
		Dim IntFromPeriod As Double
		Dim HoldTheSum As Double
		Dim TSum As String
		Dim CDateN As String
		Dim HoldVer As String
		Dim CmsBOx As String
		Dim rs As ADODB.Recordset
		
		rs = getRS("select * from Company")
		IntPeriod = rs.Fields("Company_IntPeriod").Value
		Intpercen = rs.Fields("Company_IntPercent").Value
		
		If IntPeriod <> "" And Intpercen <> 0 Then
			
			If MsgBox("This will calculate interest Percentage of " & "'" & Intpercen & "%' " & " from " & "'" & IntPeriod & "'" & " on your Overdue accounts are you sure you want to continue", MsgBoxStyle.YesNo, "4Pos Interest Calculation") = MsgBoxResult.Yes Then
				
				
				'If vbYes Then
				
                CDateN = Format(Today)
				
				adoPrimaryRS = getRS("select * from Customer")
				
				If IntPeriod = "Current" Then
					adoPrimaryRS.MoveFirst()
					Do Until adoPrimaryRS.EOF
						HoldTheSum = (adoPrimaryRS.Fields("Customer_Current").Value + adoPrimaryRS.Fields("Customer_30Days").Value + adoPrimaryRS.Fields("Customer_60Days").Value + adoPrimaryRS.Fields("Customer_90Days").Value + adoPrimaryRS.Fields("Customer_120Days").Value + adoPrimaryRS.Fields("Customer_150Days").Value)
						If HoldTheSum > 0 Then
							
							'Calculate interest
							IntFromPeriod = (HoldTheSum * Intpercen / 100) / 12
							
							TSum = CStr(IntFromPeriod + HoldTheSum)
							'cnnDB.Execute "INSERT INTO Interest (CustomerID,Perc,Period,CDate,Description,Debit,Credit,SumIntBal)VALUES ('" & adoPrimaryRS("CustomerID") & "','" & Intpercen & "%" & "','" & IntPeriod & "','" & CDateN & "',' Interest ','" & IntFromPeriod & "','" & 0 & " ','" & TSum & "')"
							
							System.Windows.Forms.Application.DoEvents()
							cmdProcess_Click(adoPrimaryRS.Fields("CustomerID"), IntFromPeriod)
							System.Windows.Forms.Application.DoEvents()
							
						End If
						
						adoPrimaryRS.moveNext()
					Loop 
					
				ElseIf IntPeriod = "30 Days" Then 
					
					adoPrimaryRS.MoveFirst()
					Do Until adoPrimaryRS.EOF
						
						HoldTheSum = adoPrimaryRS.Fields("Customer_30Days").Value + adoPrimaryRS.Fields("Customer_60Days").Value + adoPrimaryRS.Fields("Customer_90Days").Value + adoPrimaryRS.Fields("Customer_120Days").Value + adoPrimaryRS.Fields("Customer_150Days").Value
						If HoldTheSum > 0 Then
							'Calculate interest
							IntFromPeriod = (HoldTheSum * Intpercen / 100) / 12
							
							
							TSum = CStr(IntFromPeriod + HoldTheSum)
							'cnnDB.Execute "INSERT INTO Interest (CustomerID,Perc,Period,CDate,Description,Debit,Credit,SumIntBal)VALUES ('" & adoPrimaryRS("CustomerID") & "','" & Intpercen & "%" & "','" & IntPeriod & "','" & CDateN & "',' Interest ','" & IntFromPeriod & "','" & 0 & " ','" & TSum & "')"
							
							System.Windows.Forms.Application.DoEvents()
							cmdProcess_Click(adoPrimaryRS.Fields("CustomerID"), IntFromPeriod)
							System.Windows.Forms.Application.DoEvents()
							
						End If
						adoPrimaryRS.moveNext()
					Loop 
					
				ElseIf IntPeriod = "60 Days" Then 
					
					adoPrimaryRS.MoveFirst()
					Do Until adoPrimaryRS.EOF
						
						HoldTheSum = adoPrimaryRS.Fields("Customer_60Days").Value + adoPrimaryRS.Fields("Customer_90Days").Value + adoPrimaryRS.Fields("Customer_120Days").Value + adoPrimaryRS.Fields("Customer_150Days").Value
						If HoldTheSum > 0 Then
							'Calculate interest
							IntFromPeriod = (HoldTheSum * Intpercen / 100) / 12
							
							TSum = CStr(IntFromPeriod + HoldTheSum)
							'cnnDB.Execute "INSERT INTO Interest (CustomerID,Perc,Period,CDate,Description,Debit,Credit,SumIntBal)VALUES ('" & adoPrimaryRS("CustomerID") & "','" & Intpercen & "%" & "','" & IntPeriod & "','" & CDateN & "',' Interest ','" & IntFromPeriod & "','" & 0 & " ','" & TSum & "')"
							
							System.Windows.Forms.Application.DoEvents()
							cmdProcess_Click(adoPrimaryRS.Fields("CustomerID"), IntFromPeriod)
							System.Windows.Forms.Application.DoEvents()
							
						End If
						adoPrimaryRS.moveNext()
					Loop 
					
				ElseIf IntPeriod = "90 Days" Then 
					
					adoPrimaryRS.MoveFirst()
					Do Until adoPrimaryRS.EOF
						HoldTheSum = adoPrimaryRS.Fields("Customer_90Days").Value + adoPrimaryRS.Fields("Customer_120Days").Value + adoPrimaryRS.Fields("Customer_150Days").Value
						If HoldTheSum > 0 Then
							'Calculate interest
							IntFromPeriod = (HoldTheSum * Intpercen / 100) / 12
							
							TSum = CStr(IntFromPeriod + HoldTheSum)
							'cnnDB.Execute "INSERT INTO Interest (CustomerID,Perc,Period,CDate,Description,Debit,Credit,SumIntBal)VALUES ('" & adoPrimaryRS("CustomerID") & "','" & Intpercen & "%" & "','" & IntPeriod & "','" & CDateN & "',' Interest ','" & IntFromPeriod & "','" & 0 & " ','" & TSum & "')"
							
							System.Windows.Forms.Application.DoEvents()
							cmdProcess_Click(adoPrimaryRS.Fields("CustomerID"), IntFromPeriod)
							System.Windows.Forms.Application.DoEvents()
							
						End If
						adoPrimaryRS.moveNext()
					Loop 
					
				ElseIf IntPeriod = "120 Days" Then 
					
					adoPrimaryRS.MoveFirst()
					Do Until adoPrimaryRS.EOF
						HoldTheSum = adoPrimaryRS.Fields("Customer_120Days").Value + adoPrimaryRS.Fields("Customer_150Days").Value
						If HoldTheSum > 0 Then
							'Calculate interest
							IntFromPeriod = (HoldTheSum * Intpercen / 100) / 12
							
							TSum = CStr(IntFromPeriod + HoldTheSum)
							'cnnDB.Execute "INSERT INTO Interest (CustomerID,Perc,Period,CDate,Description,Debit,Credit,SumIntBal)VALUES ('" & adoPrimaryRS("CustomerID") & "','" & Intpercen & "%" & "','" & IntPeriod & "','" & CDateN & "',' Interest ','" & IntFromPeriod & "','" & 0 & " ','" & TSum & "')"
							
							System.Windows.Forms.Application.DoEvents()
							cmdProcess_Click(adoPrimaryRS.Fields("CustomerID"), IntFromPeriod)
							System.Windows.Forms.Application.DoEvents()
							
						End If
						adoPrimaryRS.moveNext()
					Loop 
					
				ElseIf IntPeriod = "150 Days" Then 
					
					adoPrimaryRS.MoveFirst()
					Do Until adoPrimaryRS.EOF
						
						HoldTheSum = adoPrimaryRS.Fields("Customer_150Days").Value
						If HoldTheSum > 0 Then
							'Calculate interest
							IntFromPeriod = (HoldTheSum * Intpercen / 100) / 12
							
							TSum = CStr(IntFromPeriod + HoldTheSum)
							'cnnDB.Execute "INSERT INTO Interest (CustomerID,Perc,Period,CDate,Description,Debit,Credit,SumIntBal)VALUES ('" & adoPrimaryRS("CustomerID") & "','" & Intpercen & "%" & "','" & IntPeriod & "','" & CDateN & "',' Interest ','" & IntFromPeriod & "','" & 0 & " ','" & TSum & "')"
							
							System.Windows.Forms.Application.DoEvents()
							cmdProcess_Click(adoPrimaryRS.Fields("CustomerID"), IntFromPeriod)
							System.Windows.Forms.Application.DoEvents()
							
						End If
						adoPrimaryRS.moveNext()
					Loop 
					
				End If
				
			ElseIf MsgBoxResult.No Then 
				
			End If
			
		ElseIf IntPeriod = "" And Intpercen = 0 Then 
			MsgBox("You must enter Percentage and Period in Store Setup and Security", MsgBoxStyle.Information, "4Pos Interest Calculation")
		ElseIf IntPeriod = "" And Intpercen <> 0 Then 
			MsgBox("You must enter Period in Store Setup and Security", MsgBoxStyle.Information, "4Pos Interest Calculation")
		ElseIf IntPeriod <> "" And Intpercen = 0 Then 
			MsgBox("You must enter Percentage in Store Setup and Security", MsgBoxStyle.Information, "4Pos Interest Calculation")
		End If
		
	End Function
End Class