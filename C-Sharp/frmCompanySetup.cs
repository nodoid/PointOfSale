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
using System.Runtime.InteropServices;
 // ERROR: Not supported in C#: OptionDeclaration
using VB = Microsoft.VisualBasic;
using Microsoft.VisualBasic.PowerPacks;
namespace _4PosBackOffice.NET
{
	internal partial class frmCompanySetup : System.Windows.Forms.Form
	{
		private struct BrowseInfo
		{
			public int hWndOwner;
			public int pIDLRoot;
			public int pszDisplayName;
			public int lpszTitle;
			public int ulFlags;
			public int lpfnCallback;
			public int lParam;
			public int iImage;
		}
		const short BIF_RETURNONLYFSDIRS = 1;
		[DllImport("ole32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
//Const MAX_PATH = 260
		private static extern void CoTaskMemFree(int hmem);
		[DllImport("kernel32", EntryPoint = "lstrcatA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int lstrcat(string lpString1, string lpString2);
		[DllImport("shell32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
//UPGRADE_WARNING: Structure BrowseInfo may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
		private static extern int SHBrowseForFolder(ref BrowseInfo lpbi);
		[DllImport("shell32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int SHGetPathFromIDList(int pidList, string lpBuffer);

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
		int gID;
		int mvBookMark;
		bool mbChangedByCode;
		bool mbEditFlag;
		bool mbAddNewFlag;
		bool mbDataChanged;
		bool loading;
		bool g_Emails;

		const short bit_deposit1 = 1;
		const short bit_deposit2 = 2;
		const short bit_Sets = 4;
		const short bit_Shrink = 8;
		const short bit_Suppress = 16;

		private const short MAX_PATH = 260;
		[DllImport("kernel32", EntryPoint = "GetWindowsDirectoryA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int GetWindowsDirectory(string lpBuffer, int nSize);
		[DllImport("kernel32", EntryPoint = "GetSystemDirectoryA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int GetSystemDirectory(string lpBuffer, int nSize);

		List<CheckBox> chkBit = new List<CheckBox>();
		List<CheckBox> chkFields = new List<CheckBox>();
		List<TextBox> txtFields = new List<TextBox>();

		List<ComboBox> cboIntPer = new List<ComboBox>();
		Scripting.FileSystemObject fso = new Scripting.FileSystemObject();


		private void loadLanguage()
		{
			//frmCompanySetup = No Code  [Edit Store Details]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmCompanySetup.Caption = rsLang("LanguageLayoutLnk_Description"): frmCompanySetup.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//Command1 = No Code         [Edit Emails]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Command1.Caption = rsLang("LanguageLayoutLnk_Description"): Command1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1010;
			//General|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_5.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_5.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1934;
			//Company Name
			if (modRecordSet.rsLang.RecordCount){_lblLabels_5.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_5.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lblLabels_0 = No Code     [To change your store name, please contact 4POS Support]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1291;
			//Physical Address|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_6.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_6.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1292;
			//Postal Address|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_7.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_7.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1288;
			//Telephone|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_8.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_8.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1289;
			//Fax|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_9.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_9.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1290;
			//Email|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_10.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_10.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lbl_0 = No Code           [&2. Current Period Numbers]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0
			//If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label6 = No Code           [Pastel period]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label6.Caption = rsLang("LanguageLayoutLnk_Description"): Label6.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblLabels_13 = No Code    [Current Day End Number:]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_13.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_13.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblLabels_14 = No Code    [Current Month End Number]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_14.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_14.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_1 = No Code           [&3. Stock Take Parameters]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_chkFields_4 = No Code     [When print stock take sheets, show Barcode and not Quick Key]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _chkFields_4.Caption = rsLang("LanguageLayoutLnk_Description"): _chkFields_4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_chkFields_12 = No Code    [When print stock take sheets, show stock value]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _chkFields_12.Caption = rsLang("LanguageLayoutLnk_Description"): _chkFields_12.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_chkFields_0 = No Code     [When print stock take sheets, dont print zero stock]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _chkFields_0.Caption = rsLang("LanguageLayoutLnk_Description"): _chkFields_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_chkFields_2 = No Code     [On processing GRV, update GRV Cost to Actual Cost(Default is List Cost)]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _chkFields_2.Caption = rsLang("LanguageLayoutLnk_Description"): _chkFields_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label8 = No Code           [-------------------------------------------  OR  -------------------------------------------]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label8.Caption = rsLang("LanguageLayoutLnk_Description"): Label8.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_chkBit_11 = No Code       [On processing GRV, update GRV cost to LIST cost && calculate Weighted Avg cost to Actual Cost]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _chkBit_11.Caption = rsLang("LanguageLayoutLnk_Description"): _chkBit_11.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label9 = No Code           [-------------------------------------------  OR  -------------------------------------------]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label9.Caption = rsLang("LanguageLayoutLnk_Description"): Label9.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_chkBit_13 = No Code       [On processing GRV, Do not update GRV cost to LIST cost && calculate Weighted Avg cost to Actual Cost]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _chkBit_13.Caption = rsLang("LanguageLayoutLnk_Description"): _chkBit_13.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label10 = No Code          [&4. Language settings]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label10.Caption = rsLang("LanguageLayoutLnk_Description"): Label10.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblLabels_1 = No Code     [Default Language]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_chkFields_6 = No Code     [Right to Left]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _chkFields_6.Caption = rsLang("LanguageLayoutLnk_Description"): _chkFields_6.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_2 = No Code           [Day End Report Print Parameters]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_chkBit_1 = No Code        [Sale Channel Activities]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _chkBit_1.Caption = rsLang("LanguageLayoutLnk_Description"): _chkBit_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1961;
			//Stock Movement Summary|Checked
			if (modRecordSet.rsLang.RecordCount){_chkBit_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_chkBit_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_chkBit_3 = No Code        [Print Shrinkage Details]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _chkBit_3.Caption = rsLang("LanguageLayoutLnk_Description"): _chkBit_3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_chkBit_4 = No Code        [Print Supplier Movement Summary]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _chkBit_4.Caption = rsLang("LanguageLayoutLnk_Description"): _chkBit_4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_chkBit_5 = No Code        [Print Customer Movement Details]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _chkBit_5.Caption = rsLang("LanguageLayoutLnk_Description"): _chkBit_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_chkBit_6 = No Code        [Print Quotes]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _chkBit_6.Caption = rsLang("LanguageLayoutLnk_Description"): _chkBit_6.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_chkBit_7 = No code        [Consignment Summary]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _chkBit_7.Caption = rsLang("LanguageLayoutLnk_Description"): _chkBit_7.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_chkBit_0 = No Code        [Automatic Pastel Report]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _chkBit_0.Caption = rsLang("LanguageLayoutLnk_Description"): _chkBit_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_chkBit_10 = No Code       [Automatic Email to Remote Office]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _chkBit_10.Caption = rsLang("LanguageLayoutLnk_Description"): _chkBit_10.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_3 = No Code           [Other]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_3.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_chkBit_8 = No Code        [4POS Interface Handling]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _chkBit_8.Caption = rsLang("LanguageLayoutLnk_Description"): _chkBit_8.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_chkFields_1 = No Code     [Allow Day End run to be performed from the 4POS Domain Controller]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _chkFields_1.Caption = rsLang("LanguageLayoutLnk_Description"): _chkFields_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_chkBit_9 = No Code        [Do Not View Update Warning on update POS]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _chkBit_9.Caption = rsLang("LanguageLayoutLnk_Description"): _chkBit_9.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_chkBit_12 = No Code       [Automatic Zero Stock At Day End]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _chkBit_12.Caption = rsLang("LanguageLayoutLnk_Description"): _chkBit_12.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_chkFields_5 = No Code     [Dry Cleaning Customer]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _chkFields_5.Caption = rsLang("LanguageLayoutLnk_Description"): _chkFields_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label5 = No Code           [Banking Details]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label5.Caption = rsLang("LanguageLayoutLnk_Description"): Label5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1 = No Code           [Bank Name]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label2 = No Code           [Branch Name]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label2.Caption = rsLang("LanguageLayoutLnk_Description"): Label2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label3 = No Code           [Branch Code]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label3.Caption = rsLang("LanguageLayoutLnk_Description"): Label3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1457;
			//Account Number|Checked
			if (modRecordSet.rsLang.RecordCount){Label4.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label4.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//Label7 = No Code           [&8. Interest Percentages]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label7.Caption = rsLang("LanguageLayoutLnk_Description"): Label7.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblinterestper = No Code   [Interest Percentage per Year]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblinterestper.Caption = rsLang("LanguageLayoutLnk_Description"): lblinterestper.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblintrfromper = No Code   [Interest From Period]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblintrfromper.Caption = rsLang("LanguageLayoutLnk_Description"): lblintrfromper.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label11 = No Code          [Open Item Debtors]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label11.Caption = rsLang("LanguageLayoutLnk_Description"): Label11.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_chkFields_7 = No Code     [Use Open Item Debtors for payment allocation]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _chkFields_7.Caption = rsLang("LanguageLayoutLnk_Description"): _chkFields_7.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_chkFields_8 = No Code     [Do not print 'Balance Due Now' on statements]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _chkFields_8.Caption = rsLang("LanguageLayoutLnk_Description"): _chkFields_8.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmCompanySetup.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}


		private void updateBit()
		{
		}

		private void buildDataControls()
		{
			doDataControl(ref (this.cmbLanguage), ref "SELECT LanguageLayout.LanguageLayoutID, LanguageLayout.LanguageLayout_Name FROM LanguageLayout ORDER BY LanguageLayout_Name", ref "Company_LanguageID", ref "LanguageLayoutID", ref "LanguageLayout_Name");
		}
		private void doDataControl(ref myDataGridView dataControl, ref string sql, ref string DataField, ref string boundColumn, ref string listField)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref sql);
			//UPGRADE_WARNING: Couldn't resolve default property of object dataControl.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dataControl.DataSource = rs;
			//UPGRADE_ISSUE: Control method dataControl.DataSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			dataControl.DataSource = adoPrimaryRS;
			//UPGRADE_ISSUE: Control method dataControl.DataField was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			dataControl.DataField = DataField;
			//UPGRADE_WARNING: Couldn't resolve default property of object dataControl.boundColumn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dataControl.boundColumn = boundColumn;
			//UPGRADE_WARNING: Couldn't resolve default property of object dataControl.listField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dataControl.listField = listField;
		}
		public void loadItem()
		{
			ADODB.Recordset rj = default(ADODB.Recordset);
			System.Windows.Forms.TextBox oText = null;
			System.Windows.Forms.CheckBox oCheck = null;
			System.Windows.Forms.ComboBox oComb = null;

			g_Emails = false;
			//Working 4 Now...
			adoPrimaryRS = modRecordSet.getRS(ref "SELECT Company_Name,Company_PhysicalAddress,Company_PostalAddress,Company_Telephone,Company_Fax,Company_Email,Company_LicenseNumber,Company_TaxNumber,Company_DayEndID,Company_MonthEndID,Company_MonthEndDay,Company_PaymentDay,Company_StockTakeQuantity,Company_StockTakeQuantityOnly,CompanyID, Company_DayEndBit,Company_AutoDayEnd,Company_BankName,Company_BranchCode,Company_BranchName,Company_AccountNumber,Company_IntPercent,Company_IntPeriod,Company_GRVCost,Company_StockTakeBC,Company_DCCustomer,Company_OpenDebtor,Company_LanguageID,Company_RightTL,Company_DebtorPrintBal,Company_FNVegShowVol,Company_CashLess,Company_POPrintBC,Company_ShrinkSign,Company_PrintDayEndSlip,Company_FingerSDK,Company_HOLink,Company_BackupPath,Company_SortOrderItems,Company_MakeFinishSaleChk,Company_LoadTRpt,Company_SecurityPerm FROM Company");
			//Set adoPrimaryRS = getRS("SELECT Company_Name,Company_PhysicalAddress,Company_PostalAddress,Company_Telephone,Company_Fax,Company_Email,Company_LicenseNumber,Company_TaxNumber,Company_DayEndID,Company_MonthEndID,Company_MonthEndDay,Company_PaymentDay,Company_StockTakeQuantity,Company_StockTakeQuantityOnly,CompanyID, Company_DayEndBit,Company_AutoDayEnd,Company_BankName,Company_BranchCode,Company_BranchName,Company_AccountNumber,Company_IntPercent,Company_IntPeriod,Company_GRVCost,Company_MenuUpdate FROM Company")

			setup();
			const short gParChannel = 1;
			const short gParStock = 2;
			const short gParShrink = 4;
			const short gParSupplier = 8;
			const short gParCustomer = 16;
			const short gParQuote = 32;
			const short gParConsignment = 64;
			const short gParPastelReport = 128;
			//Pastel Variable
			const short gParPastelPOS = 256;
			//Pastel Variable
			const short gUpdateWarnin = 512;
			const short gCopySalesToHQ = 1024;
			const short gActualAndList_U = 2048;
			const short gZeroStock_DayEnd = 4096;
			const short gLeaveListAct_U = 8192;

			 // ERROR: Not supported in C#: OnErrorStatement

			foreach (TextBox oText_loopVariable in txtFields) {
				oText = oText_loopVariable;
				oText.DataBindings.Add(adoPrimaryRS);
				oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize;
			}

			//Bind the check boxes to the data provider
			foreach (CheckBox oCheck_loopVariable in chkFields) {
				oCheck = oCheck_loopVariable;
				oCheck.DataBindings.Add(adoPrimaryRS);
			}

			//Bind the combo boxes to the data provider
			foreach (ComboBox oComb_loopVariable in cboIntPer) {
				oComb = oComb_loopVariable;
				oComb.DataSource = adoPrimaryRS;
			}

			cboSDK.SelectedIndex = (Information.IsDBNull(adoPrimaryRS.Fields("Company_FingerSDK").Value) ? 0 : adoPrimaryRS.Fields("Company_FingerSDK").Value);
			cboSDK.DataSource = adoPrimaryRS;

			this._chkBit_0.CheckState = System.Math.Abs(Convert.ToInt32(Convert.ToBoolean(adoPrimaryRS.Fields("Company_DayEndBit").Value & gParPastelReport)));
			this._chkBit_1.CheckState = System.Math.Abs(Convert.ToInt32(Convert.ToBoolean(adoPrimaryRS.Fields("Company_DayEndBit").Value & gParChannel)));
			this._chkBit_2.CheckState = System.Math.Abs(Convert.ToInt32(Convert.ToBoolean(adoPrimaryRS.Fields("Company_DayEndBit").Value & gParStock)));
			this._chkBit_3.CheckState = System.Math.Abs(Convert.ToInt32(Convert.ToBoolean(adoPrimaryRS.Fields("Company_DayEndBit").Value & gParShrink)));
			this._chkBit_4.CheckState = System.Math.Abs(Convert.ToInt32(Convert.ToBoolean(adoPrimaryRS.Fields("Company_DayEndBit").Value & gParSupplier)));
			this._chkBit_5.CheckState = System.Math.Abs(Convert.ToInt32(Convert.ToBoolean(adoPrimaryRS.Fields("Company_DayEndBit").Value & gParCustomer)));
			this._chkBit_6.CheckState = System.Math.Abs(Convert.ToInt32(Convert.ToBoolean(adoPrimaryRS.Fields("Company_DayEndBit").Value & gParQuote)));
			this._chkBit_7.CheckState = System.Math.Abs(Convert.ToInt32(Convert.ToBoolean(adoPrimaryRS.Fields("Company_DayEndBit").Value & gParConsignment)));
			this._chkBit_8.CheckState = System.Math.Abs(Convert.ToInt32(Convert.ToBoolean(adoPrimaryRS.Fields("Company_DayEndBit").Value & gParPastelPOS)));
			this._chkBit_9.CheckState = System.Math.Abs(Convert.ToInt32(Convert.ToBoolean(adoPrimaryRS.Fields("Company_DayEndBit").Value & gUpdateWarnin)));
			this._chkBit_10.CheckState = System.Math.Abs(Convert.ToInt32(Convert.ToBoolean(adoPrimaryRS.Fields("Company_DayEndBit").Value & gCopySalesToHQ)));
			this._chkBit_11.CheckState = System.Math.Abs(Convert.ToInt32(Convert.ToBoolean(adoPrimaryRS.Fields("Company_DayEndBit").Value & gActualAndList_U)));
			this._chkBit_12.CheckState = System.Math.Abs(Convert.ToInt32(Convert.ToBoolean(adoPrimaryRS.Fields("Company_DayEndBit").Value & gZeroStock_DayEnd)));
			this._chkBit_13.CheckState = System.Math.Abs(Convert.ToInt32(Convert.ToBoolean(adoPrimaryRS.Fields("Company_DayEndBit").Value & gLeaveListAct_U)));

			//Do pastel variable
			rj = modRecordSet.getRS(ref "SELECT Period FROM PastelDescription");

			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			if (Information.IsDBNull(rj.Fields("Period").Value)) {
				txtPeriod.Text = Convert.ToString(1);
			} else {
				txtPeriod.Text = rj.Fields("Period").Value;
			}

			buildDataControls();
			mbDataChanged = false;
			g_Emails = true;

			loadLanguage();
			ShowDialog();
		}
		private void setup()
		{
		}

		private void chkSets_Click()
		{
			updateBit();
		}

		private void chkShrink_Click()
		{
			updateBit();
		}

		private void chkSuppress_Click()
		{
			updateBit();
		}

//UPGRADE_WARNING: Event chkBit.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void chkBit_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			int Index = 0;
			CheckBox chkBox = new CheckBox();
			chkBox = (CheckBox)eventSender;
			Index = GetIndex.GetIndexer(ref chkBox, ref chkBit);
			if (g_Emails != false) {
				if (Index == 10) {
					if (chkBit[Index].CheckState == 1) {
						chkFields[15].CheckState = System.Windows.Forms.CheckState.Unchecked;
						if (Interaction.MsgBox("Do you also want to add/edit new Store Emails", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.ApplicationModal, "Store E-mails") == MsgBoxResult.Yes) {
							My.MyProject.Forms.frmCompanyEmails.loadItem();
						}
					}
				}
			}

			if (Index == 11) {
				if (chkBit[Index].CheckState == 1) {
					_chkFields_2.CheckState = System.Windows.Forms.CheckState.Unchecked;
					_chkBit_13.CheckState = System.Windows.Forms.CheckState.Unchecked;
				} else if (chkBit[Index].CheckState == 0) {
					if (_chkFields_2.CheckState == 0 & _chkBit_13.CheckState == 0) {
						chkBit[Index].CheckState = System.Windows.Forms.CheckState.Checked;
					}
				}
			} else if (Index == 13) {
				if (chkBit[Index].CheckState == 1) {
					_chkFields_2.CheckState = System.Windows.Forms.CheckState.Unchecked;
					_chkBit_11.CheckState = System.Windows.Forms.CheckState.Unchecked;
				} else if (chkBit[Index].CheckState == 0) {
					if (_chkFields_2.CheckState == 0 & _chkBit_11.CheckState == 0) {
						chkBit[Index].CheckState = System.Windows.Forms.CheckState.Checked;
					}
				}
			} else if (Index == 10) {
				if (chkBit[Index].CheckState == 1) {
					chkFields[15].CheckState = System.Windows.Forms.CheckState.Unchecked;
				}
			}
		}

//UPGRADE_WARNING: Event chkFields.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void chkFields_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			int Index = 0;
			CheckBox chkBox = new CheckBox();
			chkBox = (CheckBox)eventSender;
			Index = GetIndex.GetIndexer(ref chkBox, ref chkFields);
			if (Index == 2) {
				if (chkFields[Index].CheckState == 1) {
					_chkBit_11.CheckState = System.Windows.Forms.CheckState.Unchecked;
					_chkBit_13.CheckState = System.Windows.Forms.CheckState.Unchecked;
				} else if (chkFields[Index].CheckState == 0) {
					if (_chkBit_11.CheckState == 0 & _chkBit_13.CheckState == 0) {
						_chkFields_2.CheckState = System.Windows.Forms.CheckState.Checked;
					}
				}
			}
			if (Index == 15) {
				if (chkFields[Index].CheckState == 1) {
					_chkBit_10.CheckState = System.Windows.Forms.CheckState.Unchecked;
					if (g_Emails != false) {
						if (Interaction.MsgBox("Do you also want to add/edit Head Offline Link", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.ApplicationModal, "Head Offline Link") == MsgBoxResult.Yes) {
							My.MyProject.Forms.frmCompanyEmails.loadItem(ref true);
						}
					}
				}
			}

		}

		private void chkFields_MouseDown(System.Object eventSender, System.Windows.Forms.MouseEventArgs eventArgs)
		{
			short Button = eventArgs.Button / 0x100000;
			short Shift = System.Windows.Forms.Control.ModifierKeys / 0x10000;
			float x = sizeConvertors.pixelToTwips(eventArgs.X, true);
			float y = sizeConvertors.pixelToTwips(eventArgs.Y, false);
			int Index = 0;
			CheckBox chkBox = new CheckBox();
			chkBox = (CheckBox)eventSender;
			Index = GetIndex.GetIndexer(ref chkBox, ref chkFields);
			ADODB.Recordset rs = default(ADODB.Recordset);
			if (g_Emails == true) {
				if (Index == 7) {
					//Set rs = getRS("SELECT Sum(CustomerTransaction.CustomerTransaction_Amount) AS sumTran From CustomerTransaction WHERE (((CustomerTransaction.CustomerTransaction_TransactionTypeID)<>7));")
					rs = modRecordSet.getRS(ref "SELECT * From Sale;");
					if (rs.RecordCount > 0) {
						//If IIf(IsNull(rs("sumTran")), 0, rs("sumTran")) <> 0 Then
						Interaction.MsgBox("'Open Item Debtors' option may only be changed right after you do Month End!", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
						return;
						//End If
					}
				}
			}
		}

		private void cmdHO_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Set variables
			Module1.bActiveSession = false;
			Module1.hOpen = 0;
			Module1.hConnection = 0;
			Module1.dwType = Module1.FTP_TRANSFER_TYPE_BINARY;
			Module1.prgCol = "4POS-HQ_";
			Module1.NomeFileLog = Module1.prgCol + Convert.ToString(Strings.Format(DateAndTime.Now, "ddmmyyyy")) + Convert.ToString(Strings.Format(DateAndTime.Now, "hhmm")) + ".log";

			//Check for Zipit file
			if (!string.IsNullOrEmpty(GetSystemPath())) {
				if (fso.FileExists(GetSystemPath() + "\\zipit.dll")) {
				} else {
					Interaction.MsgBox("Install headoffice first.");
					return;
				}
			}

			if (Strings.LCase(Strings.Left(modRecordSet.serverPath, 3)) != "c:\\") {
				Interaction.MsgBox("4POS HeadOffice Sync Engine must be run on the server", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine");
				return;
			}

			Module1.ServerN = "http://www.4pos.co.za/4HeadOffice/4posheadoffice.pos";
			Module1.sqlLinkPath = "http://www.4pos.co.za/4HeadOffice/4posheadoffice.dsl";
			Module1.tipftp = Convert.ToString(1);

			//get HO info
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "Select Comp_ID, Comp_Email1, Comp_Email2 FROM CompanyEmails;");
			if (rs.RecordCount > 0) {
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (Information.IsDBNull(rs.Fields("Comp_ID").Value)){Interaction.MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine");return;
}
				//UPGRADE_WARNING: Couldn't resolve default property of object BranchType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Module1.BranchType = rs.Fields("Comp_ID").Value;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (Information.IsDBNull(rs.Fields("Comp_Email1").Value)){Interaction.MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine");return;
}
				if (Information.IsNumeric(rs.Fields("Comp_Email1").Value)) {
				} else {
					Interaction.MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine");
					return;
				}
				if (Convert.ToInt16(rs.Fields("Comp_Email1").Value) > 0) {
				} else {
					Interaction.MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine");
					return;
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object HOfficeID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Module1.HOfficeID = rs.Fields("Comp_Email1").Value;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (Information.IsDBNull(rs.Fields("Comp_Email2").Value)){Interaction.MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine");return;
}
				if (Information.IsNumeric(rs.Fields("Comp_Email2").Value)) {
				} else {
					Interaction.MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine");
					return;
				}
				if (Convert.ToInt16(rs.Fields("Comp_Email2").Value) > 0) {
				} else {
					Interaction.MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine");
					return;
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object BranchID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Module1.BranchID = rs.Fields("Comp_Email2").Value;
			} else {
				Interaction.MsgBox("4POS HeadOffice parameters are not configured.", MsgBoxStyle.Exclamation, "4POS HeadOffice Sync Engine");
				return;
			}

			//CaricaDati  'read the file
			//frmMainHO.Text1.Text = ""
			//frmMainHO.Label1(1).Caption = ""
			//UPGRADE_ISSUE: Load statement is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"'
			frmMainHO frm = null;
			frm.Show();
			//PreparaForm
			//frmFTP.Show vbModal
			//frmMainHO.tmrAutoDE.Enabled = True
			My.MyProject.Forms.frmMainHO.ShowDialog();
			//vbModal
		}

		public object GetSystemPath()
		{
			object functionReturnValue = null;
			string strFolder = null;
			int lngResult = 0;
			strFolder = new string(Strings.Chr(0), MAX_PATH);
			lngResult = GetSystemDirectory(strFolder, MAX_PATH);
			if (lngResult != 0) {
				functionReturnValue = Strings.Left(strFolder, Strings.InStr(strFolder, Strings.Chr(0)) - 1);
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object GetSystemPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				functionReturnValue = "";
			}
			return functionReturnValue;
		}

		private object GetWinPath()
		{
			object functionReturnValue = null;
			string strFolder = null;
			int lngResult = 0;
			strFolder = new string(Strings.Chr(0), MAX_PATH);
			lngResult = GetWindowsDirectory(strFolder, MAX_PATH);
			if (lngResult != 0) {
				functionReturnValue = Strings.Left(strFolder, Strings.InStr(strFolder, Strings.Chr(0)) - 1);
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object GetWinPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				functionReturnValue = "";
			}
			return functionReturnValue;
		}

		private void cmdLocate_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short iNull = 0;
			int lpIDList = 0;
			int lresult = 0;
			string sPath = null;
			BrowseInfo udtBI = default(BrowseInfo);

			var _with1 = udtBI;
			//Set the owner window
			_with1.hWndOwner = this.Handle.ToInt32();
			//lstrcat appends the two strings and returns the memory address
			_with1.lpszTitle = lstrcat("C:\\", "");
			//Return only if the user selected a directory
			_with1.ulFlags = BIF_RETURNONLYFSDIRS;

			//Show the 'Browse for folder' dialog
			lpIDList = SHBrowseForFolder(ref udtBI);
			if (lpIDList) {
				sPath = new string(Strings.Chr(0), MAX_PATH);
				//Get the path from the IDList
				SHGetPathFromIDList(lpIDList, sPath);
				//free the block of memory
				CoTaskMemFree(lpIDList);
				iNull = Strings.InStr(sPath, Constants.vbNullChar);
				if (iNull) {
					sPath = Strings.Left(sPath, iNull - 1);
				}
			}

			//MsgBox sPath
			if (!string.IsNullOrEmpty(sPath)) {
				_txtFields_11.Text = sPath;
			}
		}

		private void cmdSyncParam_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmMainHOParam.loadItem();
		}

//Private Sub cmbintperiod_MyLostFocus()
//IntPeriod = Me.cmbintperiod.Text
//End Sub

		private void Command1_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (this._chkBit_10.CheckState == 1) {
				My.MyProject.Forms.frmCompanyEmails.loadItem();
			}
			if (chkFields[15].CheckState == 1) {
				My.MyProject.Forms.frmCompanyEmails.loadItem(ref true);
			}
		}


		private void frmCompanySetup_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			chkBit.AddRange(new CheckBox[] {
				_chkBit_0,
				_chkBit_1,
				_chkBit_2,
				_chkBit_3,
				_chkBit_4,
				_chkBit_5,
				_chkBit_6,
				_chkBit_7,
				_chkBit_8,
				_chkBit_9,
				_chkBit_10,
				_chkBit_11,
				_chkBit_12,
				_chkBit_13
			});
			chkFields.AddRange(new CheckBox[] {
				_chkFields_0,
				_chkFields_1,
				_chkFields_2,
				_chkFields_3,
				_chkFields_4,
				_chkFields_5,
				_chkFields_6,
				_chkFields_7,
				_chkFields_8,
				_chkFields_9,
				_chkFields_10,
				_chkFields_11,
				_chkFields_12,
				_chkFields_13,
				_chkFields_14,
				_chkFields_15,
				_chkFields_16,
				_chkFields_17,
				_chkFields_18,
				_chkFields_19
			});
			txtFields.AddRange(new TextBox[] {
				_txtFields_0,
				_txtFields_1,
				_txtFields_2,
				_txtFields_3,
				_txtFields_4,
				_txtFields_5,
				_txtFields_6,
				_txtFields_7,
				_txtFields_8,
				_txtFields_9,
				_txtFields_10,
				_txtFields_11,
				_txtFields_13,
				_txtFields_14
			});
			cboIntPer.AddRange(new ComboBox[] { _cboIntPer_0 });
			CheckBox cb = new CheckBox();
			TextBox tb = new TextBox();
			foreach (CheckBox cb_loopVariable in chkBit) {
				cb = cb_loopVariable;
				cb.CheckStateChanged += chkBit_CheckStateChanged;
			}
			foreach (CheckBox cb_loopVariable in chkFields) {
				cb = cb_loopVariable;
				cb.CheckStateChanged += chkFields_CheckStateChanged;
				cb.MouseDown += chkFields_MouseDown;
			}
			foreach (TextBox tb_loopVariable in txtFields) {
				tb = tb_loopVariable;
				tb.Enter += txtFields_Enter;
				tb.Leave += txtFields_Leave;
			}
			if (modApplication.Intpercen > 0) {
				//Me.txtintper.Text = Intpercen & ".00"

			}

			if (!string.IsNullOrEmpty(modApplication.IntPeriod)) {

				//Me.cmbintperiod.Text = IntPeriod

			}

		}

//UPGRADE_WARNING: Event frmCompanySetup.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void frmCompanySetup_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			Button cmdLast = new Button();
			Button cmdNext = new Button();
			Label lblStatus = new Label();
			 // ERROR: Not supported in C#: OnErrorStatement

			lblStatus.Width = sizeConvertors.pixelToTwips(this.Width, true) - 1500;
			cmdNext.Left = lblStatus.Width + 700;
			cmdLast.Left = cmdNext.Left + 340;
		}
		private void frmCompanySetup_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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
		private void frmCompanySetup_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
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
//UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private bool update_Renamed()
		{
			bool functionReturnValue = false;
			 // ERROR: Not supported in C#: OnErrorStatement

			bool lDirty = false;
			short x = 0;
			short lBit = 0;
			const short gParChannel = 1;
			const short gParStock = 2;
			const short gParShrink = 4;
			const short gParSupplier = 8;
			const short gParCustomer = 16;
			const short gParQuote = 32;
			const short gParConsignment = 64;
			const short gParPastelReport = 128;
			const short gParPastelPOS = 256;
			const short gUpdateWarnin = 512;
			const short gCopySalesToHQ = 1024;
			const short gActualAndList_U = 2048;
			const short gZeroStock_DayEnd = 4096;
			const short gLeaveListAct_U = 8192;

			lDirty = false;
			functionReturnValue = true;

			if (this._chkBit_1.CheckState)
				lBit = lBit + gParChannel;
			if (this._chkBit_2.CheckState)
				lBit = lBit + gParStock;
			if (this._chkBit_3.CheckState)
				lBit = lBit + gParShrink;
			if (this._chkBit_4.CheckState)
				lBit = lBit + gParSupplier;
			if (this._chkBit_5.CheckState)
				lBit = lBit + gParCustomer;
			if (this._chkBit_6.CheckState)
				lBit = lBit + gParQuote;
			if (this._chkBit_7.CheckState)
				lBit = lBit + gParConsignment;
			//Pastel logo
			if (this._chkBit_0.CheckState)
				lBit = lBit + gParPastelReport;
			if (this._chkBit_8.CheckState)
				lBit = lBit + gParPastelPOS;
			if (this._chkBit_9.CheckState)
				lBit = lBit + gUpdateWarnin;
			if (this._chkBit_10.CheckState)
				lBit = lBit + gCopySalesToHQ;
			//Grv's Actual & List Update...
			if (this._chkBit_11.CheckState)
				lBit = lBit + gActualAndList_U;
			if (this._chkBit_12.CheckState)
				lBit = lBit + gZeroStock_DayEnd;
			if (this._chkBit_13.CheckState)
				lBit = lBit + gLeaveListAct_U;

			adoPrimaryRS.Fields("Company_FingerSDK").Value = Convert.ToInt32(cboSDK.SelectedIndex);

			adoPrimaryRS.Fields("Company_DayEndBit").Value = lBit;
			if (mbAddNewFlag) {
				adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll);
				adoPrimaryRS.MoveLast();
				//move to the new record
			} else {
				adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll);
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

			if (Conversion.Val(txtPeriod.Text) >= 1 & Conversion.Val(txtPeriod.Text) <= 12) {
				modRecordSet.cnnDB.Execute("UPDATE PastelDescription Set Period = " + Conversion.Val(txtPeriod.Text));
			} else {
				Interaction.MsgBox("Period Value must be in range of 1 - 12", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Pastel Variables");
				return;
			}

			//assign Interest percenetage and interest from period to variables
			//IntPeriod = Me.cmbintperiod.Text
			//Intpercen = Me.txtintper.Text

			if (update_Renamed()) {
				this.Close();
			}
		}

		private void optDeposits_Click(ref short Index)
		{
			updateBit();
		}

		private void txtFields_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			int Index = 0;
			TextBox txtBox = new TextBox();
			txtBox = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref txtBox, ref txtFields);
			modUtilities.MyGotFocus(ref txtFields[Index]);
			if (Index == 4) {
				modUtilities.MyGotFocusNumeric(ref txtFields[Index]);
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

		private void txtFields_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			int Index = 0;
			TextBox txtBox = new TextBox();
			txtBox = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref txtBox, ref txtFields);
			if (Index == 4) {
				modUtilities.MyLostFocus(ref _txtFields_4, ref 2);
				//If _txtFields_4.Text = "" Then _txtFields_4.Text = 0
				//If _txtFields_4.Text < 0 Then
				if (Convert.ToDouble(_txtFields_4.Text) > 100) {
					Interaction.MsgBox("Interest Percentage cannot Exceed 100%", MsgBoxStyle.Information, "4Pos Interest Calculation");
					_txtFields_4.Focus();
				}
			}
		}

		private void txtintper_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			modUtilities.MyLostFocus(ref txtintper, ref 2);
			//Dim CheckNo As Double
			//CheckNo = (Len(txtintper))
			//Interest must be less or equal to 100

			//If IsNumeric(txtintper.Text) Then
			//MsgBox "Interest Percentage must not contain Alphabets", vbInformation, "4Pos Interest Calculation"
			//Me.txtintper.Text = "0.00"
			//Me.txtintper.SetFocus
			//End If

			if (Convert.ToDouble(txtintper.Text) > 100) {
				Interaction.MsgBox("Interest Percentage cannot Exceed 100%", MsgBoxStyle.Information, "4Pos Interest Calculation");
				this.txtintper.Text = "0.00";
				this.txtintper.Focus();


				//Me.txtintper.se
			} else {
			}

		}

		private void txtPeriod_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtPeriod);
		}
		private void txtPeriod_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			modUtilities.MyKeyPress(ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
		private void txtPeriod_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtPeriod, ref 0);
		}

		private void cmdProcess_Click(ref object cID, ref object cSum)
		{
			decimal amount = default(decimal);
			int txtAmountText = 0;
			string txtNarrativeText = null;
			string txtNotesText = null;
			ADODB.Recordset rsCus = default(ADODB.Recordset);
			string cSQL = null;
			string sql = null;
			string sql1 = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			string id = null;
			decimal days120 = default(decimal);
			decimal days60 = default(decimal);
			decimal current = default(decimal);
			decimal lAmount = default(decimal);
			decimal days30 = default(decimal);
			decimal days90 = default(decimal);
			decimal days150 = default(decimal);
			System.Windows.Forms.Application.DoEvents();
			//If txtNarrative.Text = "" Then
			//    MsgBox "Narrative is a mandarory field", vbExclamation, Me.Caption
			//    txtNarrative.SetFocus
			//    Exit Sub
			//End If
			//If CCur(txtAmount.Text) = 0 Then
			//   MsgBox "Amount is a mandarory field", vbExclamation, Me.Caption
			//   txtAmount.SetFocus
			//   Exit Sub
			//End If


			cSQL = "SELECT CustomerTransaction.*, TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit";
			cSQL = cSQL + " FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID";
			cSQL = cSQL + " WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" + cID + "))";
			cSQL = cSQL + " ORDER BY CustomerTransaction.CustomerTransaction_Date DESC;";
			rsCus = modRecordSet.getRS(ref cSQL);

			if (rsCus.RecordCount < 1)
				return;

			//If CCur(rsCus("CustomerTransaction_Amount")) < 0 Then  'rsCus("credit") <> ""
			//    gSection = 1
			//    txtNotesText = "Zeroise Debitors Accounts"
			//    txtNarrativeText = "Zeroise Debitors Accounts"
			//    txtAmountText = (rsCus("CustomerTransaction_Amount") / -1)
			//End If

			//If CCur(rsCus("CustomerTransaction_Amount")) > 0 Then 'rsCus("debit") <> ""
			//gSection = 2
			txtNotesText = "Interest";
			txtNarrativeText = "Interest";
			txtAmountText = System.Math.Round(cSum, 2);
			//+ (rsCus("CustomerTransaction_Amount"))

			//End If


			sql = "INSERT INTO CustomerTransaction ( CustomerTransaction_CustomerID, CustomerTransaction_TransactionTypeID, CustomerTransaction_DayEndID, CustomerTransaction_MonthEndID, CustomerTransaction_ReferenceID, CustomerTransaction_Date, CustomerTransaction_Description, CustomerTransaction_Amount, CustomerTransaction_Reference, CustomerTransaction_PersonName )";
			//Select Case gSection
			//    Case sec_Payment
			//        sql = sql & "SELECT " & cID & " AS Customer, 3 AS [type], Company.Company_DayEndID, Company.Company_MonthEndID, 0 AS referenceID, Now() AS [Date], '" & Replace(txtNotesText, "'", "''") & "' AS description, " & CCur(0 - CCur(txtAmountText)) & " AS amount, '" & Replace(txtNarrativeText, "'", "''") & "' AS reference, 'System' AS person FROM Company;"
			//    Case sec_Debit
			sql = sql + "SELECT " + cID + " AS Customer, 9 AS [type], Company.Company_DayEndID, Company.Company_MonthEndID, 0 AS referenceID, Now() AS [Date], '" + Strings.Replace(txtNotesText, "'", "''") + "' AS description, " + Convert.ToDecimal(txtAmountText) + " AS amount, '" + Strings.Replace(txtNarrativeText, "'", "''") + "' AS reference, 'System' AS person FROM Company;";
			//    Case sec_Credit
			//        sql = sql & "SELECT " & cID & " AS Customer, 5 AS [type], Company.Company_DayEndID, Company.Company_MonthEndID, 0 AS referenceID, Now() AS [Date], '" & Replace(txtNotesText, "'", "''") & "' AS description, " & CCur(0 - CCur(txtAmountText)) & " AS amount, '" & Replace(txtNarrativeText, "'", "''") & "' AS reference, 'System' AS person FROM Company;"
			//End Select

			modRecordSet.cnnDB.Execute(sql);

			rs = modRecordSet.getRS(ref "SELECT MAX(CustomerTransactionID) AS id From CustomerTransaction");
			if (rs.BOF | rs.EOF) {
			} else {
				id = rs.Fields("id").Value;
				modRecordSet.cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_Current = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" + id + ") AND ((Customer.Customer_Current) Is Null));");
				modRecordSet.cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_30Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" + id + ") AND ((Customer.Customer_30Days) Is Null));");
				modRecordSet.cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_60Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" + id + ") AND ((Customer.Customer_60Days) Is Null));");
				modRecordSet.cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_90Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" + id + ") AND ((Customer.Customer_90Days) Is Null));");
				modRecordSet.cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_120Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" + id + ") AND ((Customer.Customer_120Days) Is Null));");
				modRecordSet.cnnDB.Execute("UPDATE Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID SET Customer.Customer_150Days = 0 WHERE (((CustomerTransaction.CustomerTransactionID)=" + id + ") AND ((Customer.Customer_150Days) Is Null));");

				rs = modRecordSet.getRS(ref "SELECT CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_Amount, Customer.Customer_Current, Customer.Customer_30Days, Customer.Customer_60Days, Customer.Customer_90Days, Customer.Customer_120Days, Customer.Customer_150Days FROM Customer INNER JOIN CustomerTransaction ON Customer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID Where (((CustomerTransaction.CustomerTransactionID) = " + id + "));");

				amount = rs.Fields("CustomerTransaction_Amount").Value;
				current = rs.Fields("Customer_Current").Value;
				days30 = rs.Fields("Customer_30Days").Value;
				days60 = rs.Fields("Customer_60Days").Value;
				days90 = rs.Fields("Customer_90Days").Value;
				days120 = rs.Fields("Customer_120Days").Value;
				days150 = rs.Fields("Customer_150Days").Value;
				if (amount < 0) {
					days150 = days150 + amount;
					if ((days150 < 0)) {
						amount = days150;
						days150 = 0;
					} else {
						amount = 0;
					}
					days120 = days120 + amount;
					if ((days120 < 0)) {
						amount = days120;
						days120 = 0;
					} else {
						amount = 0;
					}
					days90 = days90 + amount;
					if ((days90 < 0)) {
						amount = days90;
						days90 = 0;
					} else {
						amount = 0;
					}
					days60 = days60 + amount;
					if ((days60 < 0)) {
						amount = days60;
						days60 = 0;
					} else {
						amount = 0;
					}
					days30 = days30 + amount;
					if ((days30 < 0)) {
						amount = days30;
						days30 = 0;
					} else {
						amount = 0;
					}
				}
				current = current + amount;
				modRecordSet.cnnDB.Execute("UPDATE Customer SET Customer.Customer_Current = " + current + ", Customer.Customer_30Days = " + days30 + ", Customer.Customer_60Days = " + days60 + ", Customer.Customer_90Days = " + days90 + ", Customer.Customer_120Days = " + days120 + ", Customer.Customer_150Days = 0" + days150 + " WHERE (((Customer.CustomerID)=" + rs.Fields("CustomerTransaction_CustomerID").Value + "));");
				//cnnDB.Execute "UPDATE Customer SET Customer.Customer_Current = " & 0 & ", Customer.Customer_30Days = " & 0 & ", Customer.Customer_60Days = " & 0 & ", Customer.Customer_90Days = " & 0 & ", Customer.Customer_120Days = " & 0 & ", Customer.Customer_150Days = " & 0 & " WHERE (((Customer.CustomerID)=" & rs("CustomerTransaction_CustomerID") & "));"
			}

		}

		public object CalcIntPeriod()
		{
			 // ERROR: Not supported in C#: OnErrorStatement


			double IntFromPeriod = 0;
			double HoldTheSum = 0;
			string TSum = null;
			string CDateN = null;
			string HoldVer = null;
			string CmsBOx = null;
			ADODB.Recordset rs = default(ADODB.Recordset);

			rs = modRecordSet.getRS(ref "select * from Company");
			modApplication.IntPeriod = rs.Fields("Company_IntPeriod").Value;
			modApplication.Intpercen = rs.Fields("Company_IntPercent").Value;

			if (!string.IsNullOrEmpty(modApplication.IntPeriod) & modApplication.Intpercen != 0) {

				if (Interaction.MsgBox("This will calculate interest Percentage of " + "'" + modApplication.Intpercen + "%' " + " from " + "'" + modApplication.IntPeriod + "'" + " on your Overdue accounts are you sure you want to continue", MsgBoxStyle.YesNo, "4Pos Interest Calculation") == MsgBoxResult.Yes) {


					//If vbYes Then

					CDateN = Strings.Format(DateAndTime.Today);

					adoPrimaryRS = modRecordSet.getRS(ref "select * from Customer");

					if (modApplication.IntPeriod == "Current") {
						adoPrimaryRS.MoveFirst();
						while (!(adoPrimaryRS.EOF)) {
							HoldTheSum = (adoPrimaryRS.Fields("Customer_Current").Value + adoPrimaryRS.Fields("Customer_30Days").Value + adoPrimaryRS.Fields("Customer_60Days").Value + adoPrimaryRS.Fields("Customer_90Days").Value + adoPrimaryRS.Fields("Customer_120Days").Value + adoPrimaryRS.Fields("Customer_150Days").Value);
							if (HoldTheSum > 0) {

								//Calculate interest
								IntFromPeriod = (HoldTheSum * modApplication.Intpercen / 100) / 12;

								TSum = Convert.ToString(IntFromPeriod + HoldTheSum);
								//cnnDB.Execute "INSERT INTO Interest (CustomerID,Perc,Period,CDate,Description,Debit,Credit,SumIntBal)VALUES ('" & adoPrimaryRS("CustomerID") & "','" & Intpercen & "%" & "','" & IntPeriod & "','" & CDateN & "',' Interest ','" & IntFromPeriod & "','" & 0 & " ','" & TSum & "')"

								System.Windows.Forms.Application.DoEvents();
								cmdProcess_Click(ref adoPrimaryRS.Fields("CustomerID"), ref IntFromPeriod);
								System.Windows.Forms.Application.DoEvents();

							}

							adoPrimaryRS.moveNext();
						}

					} else if (modApplication.IntPeriod == "30 Days") {

						adoPrimaryRS.MoveFirst();
						while (!(adoPrimaryRS.EOF)) {

							HoldTheSum = adoPrimaryRS.Fields("Customer_30Days").Value + adoPrimaryRS.Fields("Customer_60Days").Value + adoPrimaryRS.Fields("Customer_90Days").Value + adoPrimaryRS.Fields("Customer_120Days").Value + adoPrimaryRS.Fields("Customer_150Days").Value;
							if (HoldTheSum > 0) {
								//Calculate interest
								IntFromPeriod = (HoldTheSum * modApplication.Intpercen / 100) / 12;


								TSum = Convert.ToString(IntFromPeriod + HoldTheSum);
								//cnnDB.Execute "INSERT INTO Interest (CustomerID,Perc,Period,CDate,Description,Debit,Credit,SumIntBal)VALUES ('" & adoPrimaryRS("CustomerID") & "','" & Intpercen & "%" & "','" & IntPeriod & "','" & CDateN & "',' Interest ','" & IntFromPeriod & "','" & 0 & " ','" & TSum & "')"

								System.Windows.Forms.Application.DoEvents();
								cmdProcess_Click(ref adoPrimaryRS.Fields("CustomerID"), ref IntFromPeriod);
								System.Windows.Forms.Application.DoEvents();

							}
							adoPrimaryRS.moveNext();
						}

					} else if (modApplication.IntPeriod == "60 Days") {

						adoPrimaryRS.MoveFirst();
						while (!(adoPrimaryRS.EOF)) {

							HoldTheSum = adoPrimaryRS.Fields("Customer_60Days").Value + adoPrimaryRS.Fields("Customer_90Days").Value + adoPrimaryRS.Fields("Customer_120Days").Value + adoPrimaryRS.Fields("Customer_150Days").Value;
							if (HoldTheSum > 0) {
								//Calculate interest
								IntFromPeriod = (HoldTheSum * modApplication.Intpercen / 100) / 12;

								TSum = Convert.ToString(IntFromPeriod + HoldTheSum);
								//cnnDB.Execute "INSERT INTO Interest (CustomerID,Perc,Period,CDate,Description,Debit,Credit,SumIntBal)VALUES ('" & adoPrimaryRS("CustomerID") & "','" & Intpercen & "%" & "','" & IntPeriod & "','" & CDateN & "',' Interest ','" & IntFromPeriod & "','" & 0 & " ','" & TSum & "')"

								System.Windows.Forms.Application.DoEvents();
								cmdProcess_Click(ref adoPrimaryRS.Fields("CustomerID"), ref IntFromPeriod);
								System.Windows.Forms.Application.DoEvents();

							}
							adoPrimaryRS.moveNext();
						}

					} else if (modApplication.IntPeriod == "90 Days") {

						adoPrimaryRS.MoveFirst();
						while (!(adoPrimaryRS.EOF)) {
							HoldTheSum = adoPrimaryRS.Fields("Customer_90Days").Value + adoPrimaryRS.Fields("Customer_120Days").Value + adoPrimaryRS.Fields("Customer_150Days").Value;
							if (HoldTheSum > 0) {
								//Calculate interest
								IntFromPeriod = (HoldTheSum * modApplication.Intpercen / 100) / 12;

								TSum = Convert.ToString(IntFromPeriod + HoldTheSum);
								//cnnDB.Execute "INSERT INTO Interest (CustomerID,Perc,Period,CDate,Description,Debit,Credit,SumIntBal)VALUES ('" & adoPrimaryRS("CustomerID") & "','" & Intpercen & "%" & "','" & IntPeriod & "','" & CDateN & "',' Interest ','" & IntFromPeriod & "','" & 0 & " ','" & TSum & "')"

								System.Windows.Forms.Application.DoEvents();
								cmdProcess_Click(ref adoPrimaryRS.Fields("CustomerID"), ref IntFromPeriod);
								System.Windows.Forms.Application.DoEvents();

							}
							adoPrimaryRS.moveNext();
						}

					} else if (modApplication.IntPeriod == "120 Days") {

						adoPrimaryRS.MoveFirst();
						while (!(adoPrimaryRS.EOF)) {
							HoldTheSum = adoPrimaryRS.Fields("Customer_120Days").Value + adoPrimaryRS.Fields("Customer_150Days").Value;
							if (HoldTheSum > 0) {
								//Calculate interest
								IntFromPeriod = (HoldTheSum * modApplication.Intpercen / 100) / 12;

								TSum = Convert.ToString(IntFromPeriod + HoldTheSum);
								//cnnDB.Execute "INSERT INTO Interest (CustomerID,Perc,Period,CDate,Description,Debit,Credit,SumIntBal)VALUES ('" & adoPrimaryRS("CustomerID") & "','" & Intpercen & "%" & "','" & IntPeriod & "','" & CDateN & "',' Interest ','" & IntFromPeriod & "','" & 0 & " ','" & TSum & "')"

								System.Windows.Forms.Application.DoEvents();
								cmdProcess_Click(ref adoPrimaryRS.Fields("CustomerID"), ref IntFromPeriod);
								System.Windows.Forms.Application.DoEvents();

							}
							adoPrimaryRS.moveNext();
						}

					} else if (modApplication.IntPeriod == "150 Days") {

						adoPrimaryRS.MoveFirst();
						while (!(adoPrimaryRS.EOF)) {

							HoldTheSum = adoPrimaryRS.Fields("Customer_150Days").Value;
							if (HoldTheSum > 0) {
								//Calculate interest
								IntFromPeriod = (HoldTheSum * modApplication.Intpercen / 100) / 12;

								TSum = Convert.ToString(IntFromPeriod + HoldTheSum);
								//cnnDB.Execute "INSERT INTO Interest (CustomerID,Perc,Period,CDate,Description,Debit,Credit,SumIntBal)VALUES ('" & adoPrimaryRS("CustomerID") & "','" & Intpercen & "%" & "','" & IntPeriod & "','" & CDateN & "',' Interest ','" & IntFromPeriod & "','" & 0 & " ','" & TSum & "')"

								System.Windows.Forms.Application.DoEvents();
								cmdProcess_Click(ref adoPrimaryRS.Fields("CustomerID"), ref IntFromPeriod);
								System.Windows.Forms.Application.DoEvents();

							}
							adoPrimaryRS.moveNext();
						}

					}

				} else if (MsgBoxResult.No) {

				}

			} else if (string.IsNullOrEmpty(modApplication.IntPeriod) & modApplication.Intpercen == 0) {
				Interaction.MsgBox("You must enter Percentage and Period in Store Setup and Security", MsgBoxStyle.Information, "4Pos Interest Calculation");
			} else if (string.IsNullOrEmpty(modApplication.IntPeriod) & modApplication.Intpercen != 0) {
				Interaction.MsgBox("You must enter Period in Store Setup and Security", MsgBoxStyle.Information, "4Pos Interest Calculation");
			} else if (!string.IsNullOrEmpty(modApplication.IntPeriod) & modApplication.Intpercen == 0) {
				Interaction.MsgBox("You must enter Percentage in Store Setup and Security", MsgBoxStyle.Information, "4Pos Interest Calculation");
			}

		}
	}
}
