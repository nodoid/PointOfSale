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
	internal partial class frmCompanyEmails : System.Windows.Forms.Form
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

		const short bit_deposit1 = 1;
		const short bit_deposit2 = 2;
		const short bit_Sets = 4;
		const short bit_Shrink = 8;

		const short bit_Suppress = 16;

		List<TextBox> txtFields = new List<TextBox>();
		private void loadLanguage()
		{

			//frmCompanyEmails = No Code [Edit Store Emails]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmCompanyEmails.Caption = rsLang("LanguageLayoutLnk_Description"): frmCompanyEmails.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//Label6 = No Code           [Email For Remote Office]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label6.Caption = rsLang("LanguageLayoutLnk_Description"): Label6.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1 = No Code           [Email No 1]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label2 = No Code           [Email No 2]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label2.Caption = rsLang("LanguageLayoutLnk_Description"): Label2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label3 = No Code           [Email No 3]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label3.Caption = rsLang("LanguageLayoutLnk_Description"): Label3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label4 = No Code           [Email No 4]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label4.Caption = rsLang("LanguageLayoutLnk_Description"): Label4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label5 = No Code           [Email No 5]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label5.Caption = rsLang("LanguageLayoutLnk_Description"): Label5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label7 = No Code           [Email No 6]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label7.Caption = rsLang("LanguageLayoutLnk_Description"): Label7.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label8 = No Code           [Email No 7]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label8.Caption = rsLang("LanguageLayoutLnk_Description"): Label8.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label9 = No Code           [Company Number]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label9.Caption = rsLang("LanguageLayoutLnk_Description"): Label9.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label10 = No Code          [Company Number]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label10.Caption = rsLang("LanguageLayoutLnk_Description"): Label10.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmCompanyEmails.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void updateBit()
		{
		}
		private void buildDataControls()
		{
		}
		private void doDataControl(ref myDataGridView dataControl, ref string sql, ref string DataField, ref string boundColumn, ref string listField)
		{
			//Dim rs As ADODB.Recordset
			//rs = getRS(sql)
			//UPGRADE_WARNING: Couldn't resolve default property of object dataControl.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//dataControl.DataBindings.Add(rs)
			//UPGRADE_ISSUE: Control method dataControl.DataSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			//dataControl.DataSource = adoPrimaryRS
			//UPGRADE_ISSUE: Control method dataControl.DataField was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			//dataControl.DataField = DataField
			//UPGRADE_WARNING: Couldn't resolve default property of object dataControl.boundColumn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//dataControl.boundColumn = boundColumn
			//UPGRADE_WARNING: Couldn't resolve default property of object dataControl.listField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//dataControl.listField = listField
		}
		public void loadItem(ref bool bHOLink = false)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			System.Windows.Forms.TextBox oText = null;
			System.Windows.Forms.CheckBox oCheck = null;

			//Working 4 Now...
			//Check Data
			CheckEmailsData();

			adoPrimaryRS = modRecordSet.getRS(ref "SELECT * FROM CompanyEmails");

			setup();
			 // ERROR: Not supported in C#: OnErrorStatement

			foreach (TextBox oText_loopVariable in this.txtFields) {
				oText = oText_loopVariable;
				oText.DataBindings.Add(adoPrimaryRS);
				oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize;
			}
			buildDataControls();
			mbDataChanged = false;

			loadLanguage();

			if (bHOLink == true) {
				this.Text = "Edit Head Office link";
				Label6.Text = "1. Head Office link locations";

				Label1.Text = "H/Office No.:";
				Label2.Text = "Branch No.:";
				Label3.Text = "-";
				//"Down Link 2:"
				Label4.Text = "-";
				//"Down Link 3:"
				Label5.Text = "-";
				//"Down Link 4:"
				Label7.Text = "-";
				//"Down Link 5:"
				Label8.Text = "-";
				//"Down Link 6:"

				Label9.Text = "2. Headoffice/Branch";
				Label10.Text = "Headoffice = 1    /    Branch = 0";
			}
			ShowDialog();
		}
		public void CheckEmailsData()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);

			rs = modRecordSet.getRS(ref "Select * From CompanyEmails");
			if (rs.RecordCount == 0) {
				modRecordSet.cnnDB.Execute("INSERT INTO CompanyEmails (Comp_ID) VALUES (1)");
			}
		}
		private void setup()
		{

		}
		private void frmCompanyEmails_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void frmCompanyEmails_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
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
			lDirty = false;
			functionReturnValue = true;

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
			if (update_Renamed()) {
				this.Close();
			}
		}
		private void txtFields_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			int Index = 0;
			TextBox txtBox = new TextBox();
			txtBox = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref txtBox, ref txtFields);
			if (Index == 7)
				modUtilities.MyGotFocusNumeric(ref txtFields[Index]);
		}
		private void txtFields_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			int Index = 0;
			TextBox txtBox = new TextBox();
			txtBox = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref txtBox, ref txtFields);
			if (Index == 7)
				modUtilities.MyKeyPress(ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
		private void txtFields_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			int Index = 0;
			TextBox txtBox = new TextBox();
			txtBox = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref txtBox, ref txtFields);
			if (Index == 7)
				modUtilities.MyLostFocus(ref txtFields[Index], ref 0);
		}

		private void frmCompanyEmails_Load(object sender, System.EventArgs e)
		{
			txtFields.AddRange(new TextBox[] {
				_txtFields_0,
				_txtFields_1,
				_txtFields_2,
				_txtFields_3,
				_txtFields_4,
				_txtFields_5,
				_txtFields_6,
				_txtFields_7
			});
			TextBox tb = new TextBox();
			foreach (TextBox tb_loopVariable in txtFields) {
				tb = tb_loopVariable;
				tb.Enter += txtFields_Enter;
				tb.KeyPress += txtFields_KeyPress;
				tb.Leave += txtFields_Leave;
			}

		}
	}
}
