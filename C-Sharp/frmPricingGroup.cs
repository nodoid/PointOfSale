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
	internal partial class frmPricingGroup : System.Windows.Forms.Form
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
		short pRid;
		int gID;
		//Dim WithEvents lblLabels As New List(Of Label)
		List<TextBox> txtFields = new List<TextBox>();
		List<TextBox> txtFloat = new List<TextBox>();
		List<TextBox> txtInteger = new List<TextBox>();
		List<TextBox> txtFloatNegative = new List<TextBox>();

		List<Label> lblCG = new List<Label>();
		private void loadLanguage()
		{

			//frmPricingGroup = No Code  [Edit Pricing Group Details]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmPricingGroup.Caption = rsLang("LanguageLayoutLnk_Description"): frmPricingGroup.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//cmdMatrix = No Code        [Pricing Matrix]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdMatrix.Caption = rsLang("LanguageLayoutLnk_Description"): cmdMatrix.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//DB Entry needs "&" for accelerator key
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1085;
			//Print|Checked
			if (modRecordSet.rsLang.RecordCount){cmdPrint.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPrint.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1010;
			//General|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_5.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_5.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1066;
			//Pricing Group Name|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_38.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_38.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1067;
			//Pricing Rules|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lbl(10) = No Code          [When a Stock Item value is over]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lbl(10).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(10).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lbl(18) = No Code          [round all amounts below]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lbl(18).Caption = rsLang("LanguageLayoutLnk_Description"): lbl(18).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//========================================================================================
			//NOTE: For multi-currency support the word "RAND" must be removed from the labels below!!
			//Recommend generating the sentence from two DB entries, and use a fixed variable to
			//stores the currency of choice inserted in the middle before applying it to the component.
			//
			//   E.g.    firstPart       = rsLang.filter = & 1234;
			//           lastPart        = rsLang.Filter = & 1235;
			//           _lbl_3.Caption  = firstPart + ' ' + currency + ' ' + lastPart;
			//========================================================================================

			//_lbl_3 = No Code           [cents to the lower <Rand> value]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_3.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_2 = No Code           [value, then remove]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//NOTE: Same problem as _lbl_3 applies here!!!
			//_lbl_4 = No Code           [cents from the rounded stock item <Rand> value]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_4.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1068;
			//Default Pricing Markup Percentage|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lblLabels(34) = No Code (Closest match 2105, but grammar wrong for use)
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblLabels(34).Caption = rsLang("LanguageLayoutLnk_Description"): lblLabels(34).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblLabels(33) = No Code    [Case/Carton]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblLabels(33).Caption = rsLang("LanguageLayoutLnk_Description"): lblLabels(33).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblCG(0) = Dynamic
			//lblCG(1) = Dynamic
			//lblCG(2) = Dynamic
			//lblCG(3) = Dynamic
			//lblCG(4) = Dynamic
			//lblCG(5) = Dynamic
			//lblCG(6) = Dynamic
			//lblCG(7) = Dynamic

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1069;
			//Disabled Pricing Group|Checked
			if (modRecordSet.rsLang.RecordCount){Label1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1070;
			//Disable this Pricing Group|Checked
			if (modRecordSet.rsLang.RecordCount){chkPricing.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;chkPricing.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmPricingGroup.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void buildDataControls()
		{
			//    doDataControl Me.cmbChannel, "SELECT ChannelID, Channel_Name FROM Channel ORDER BY ChannelID", "Customer_ChannelID", "ChannelID", "Channel_Name"
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

		public void loadItem(ref int id)
		{
			System.Windows.Forms.TextBox oText = null;
			System.Windows.Forms.CheckBox oCheck = null;
			 // ERROR: Not supported in C#: OnErrorStatement

			if (id) {
				pRid = id;
				adoPrimaryRS = modRecordSet.getRS(ref "select PricingGroupID,PricingGroup_Name,PricingGroup_RemoveCents,PricingGroup_RoundAfter,PricingGroup_RoundDown,PricingGroup_Unit1,PricingGroup_Case1,PricingGroup_Unit2,PricingGroup_Case2,PricingGroup_Unit3,PricingGroup_Case3,PricingGroup_Unit4,PricingGroup_Case4,PricingGroup_Unit5,PricingGroup_Case5,PricingGroup_Unit6,PricingGroup_Case6,PricingGroup_Unit7,PricingGroup_Case7,PricingGroup_Unit8,PricingGroup_Case8,PricingGroup_Disabled from PricingGroup WHERE PricingGroupID = " + id);
			} else {
				adoPrimaryRS = modRecordSet.getRS(ref "select * from PricingGroup");
				adoPrimaryRS.AddNew();
				this.Text = this.Text + " [New record]";
				mbAddNewFlag = true;
			}
			setup();
			foreach (TextBox oText_loopVariable in this.txtFields) {
				oText = oText_loopVariable;
				oText.DataBindings.Add(adoPrimaryRS);
				oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize;
			}
			foreach (TextBox oText_loopVariable in this.txtInteger) {
				oText = oText_loopVariable;
				oText.DataBindings.Add(adoPrimaryRS);
				oText.Leave += txtInteger_Leave;
			}
			foreach (TextBox oText_loopVariable in this.txtFloat) {
				oText = oText_loopVariable;
				oText.DataBindings.Add(adoPrimaryRS);
				if (string.IsNullOrEmpty(oText.Text))
					oText.Text = "0";
				oText.Text = Convert.ToString(Convert.ToDouble(oText.Text) * 100);
				oText.Leave += txtFloat_Leave;
			}
			foreach (TextBox oText_loopVariable in this.txtFloatNegative) {
				oText = oText_loopVariable;
				oText.DataBindings.Add(adoPrimaryRS);
				if (string.IsNullOrEmpty(oText.Text))
					oText.Text = "0";
				oText.Text = Convert.ToString(Convert.ToDouble(oText.Text) * 100);
				oText.Leave += txtFloatNegative_Leave;
			}

			if (Convert.ToInt16(adoPrimaryRS.Fields("PricingGroup_Disabled").Value)) {
				this.chkPricing.CheckState = System.Windows.Forms.CheckState.Checked;
				this.chkPricing.Tag = 1;
			} else {
				this.chkPricing.Tag = 0;
			}

			buildDataControls();
			mbDataChanged = false;

			loadLanguage();
			ShowDialog();
		}

		private void setup()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			short x = 0;
			rs = modRecordSet.getRS(ref "SELECT Channel_Code FROM Channel ORDER BY ChannelID");
			rs.MoveFirst();
			for (x = 0; x <= 7; x++) {
				this.lblCG[x].Text = rs.Fields("Channel_Code").Value;
				rs.moveNext();
			}
		}

		private void Command1_Click()
		{

		}

		private void cmdMatrix_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdMatrix.Focus();
			System.Windows.Forms.Application.DoEvents();
			update_Renamed();
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			My.MyProject.Forms.frmPricingMatrix.loadMatrix(ref adoPrimaryRS.Fields("PricingGroupID").Value);
			Cursor = System.Windows.Forms.Cursors.Default;
			frmPricingMatrix form = null;
			form.Show();
		}

		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modApplication.report_PricingGroup();
		}

		private void frmPricingGroup_Load(object sender, System.EventArgs e)
		{
			txtFields.AddRange(new TextBox[] { _txtFields_28 });
			txtFloat.AddRange(new TextBox[] { _txtFloat_1 });
			txtInteger.AddRange(new TextBox[] {
				_txtInteger_0,
				_txtInteger_2
			});
			txtFloatNegative.AddRange(new TextBox[] {
				_txtFloatNegative_0,
				_txtFloatNegative_1,
				_txtFloatNegative_2,
				_txtFloatNegative_3,
				_txtFloatNegative_4,
				_txtFloatNegative_5,
				_txtFloatNegative_6,
				_txtFloatNegative_7,
				_txtFloatNegative_8,
				_txtFloatNegative_9,
				_txtFloatNegative_10,
				_txtFloatNegative_11,
				_txtFloatNegative_12,
				_txtFloatNegative_13,
				_txtFloatNegative_14,
				_txtFloatNegative_15
			});
			lblCG.AddRange(new Label[] {
				_lblCG_0,
				_lblCG_1,
				_lblCG_2,
				_lblCG_3,
				_lblCG_4,
				_lblCG_5,
				_lblCG_6,
				_lblCG_7
			});
			_txtFields_28.Enter += txtFields_Enter;
			_txtFloat_1.Enter += txtFloat_Enter;
			_txtFloat_1.KeyPress += txtFloat_KeyPress;

			TextBox tb = new TextBox();
			foreach (TextBox tb_loopVariable in txtInteger) {
				tb = tb_loopVariable;
				tb.Enter += txtInteger_Enter;
				tb.KeyPress += txtInteger_KeyPress;
			}
			foreach (TextBox tb_loopVariable in txtFloatNegative) {
				tb = tb_loopVariable;
				tb.Enter += txtFloatNegative_Enter;
				tb.KeyPress += txtFloatNegative_KeyPress;
			}

		}


//UPGRADE_WARNING: Event frmPricingGroup.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void frmPricingGroup_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			Button cmdLast = null;
			Button cmdnext = null;
			Label lblStatus = null;
			 // ERROR: Not supported in C#: OnErrorStatement

			//UPGRADE_WARNING: Couldn't resolve default property of object lblStatus.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lblStatus.Width = sizeConvertors.pixelToTwips(this.Width, true) - 1500;
			//UPGRADE_WARNING: Couldn't resolve default property of object cmdnext.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object lblStatus.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			cmdnext.Left = lblStatus.Width + 700;
			//UPGRADE_WARNING: Couldn't resolve default property of object cmdLast.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object cmdnext.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			cmdLast.Left = cmdnext.Left + 340;
		}
		private void frmPricingGroup_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case System.Windows.Forms.Keys.Escape:
					KeyAscii = 0;
					cmdClose.Focus();
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

		private void frmPricingGroup_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
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
			TextBox oText = new TextBox();
			 // ERROR: Not supported in C#: OnErrorStatement

			if (mbAddNewFlag) {
				this.Close();
			} else {
				mbEditFlag = false;
				mbAddNewFlag = false;
				adoPrimaryRS.CancelUpdate();
				//UPGRADE_WARNING: Couldn't resolve default property of object mvBookMark. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (mvBookMark > 0) {
					//UPGRADE_WARNING: Couldn't resolve default property of object mvBookMark. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					adoPrimaryRS.Bookmark = mvBookMark;

				} else {
					adoPrimaryRS.MoveFirst();
				}
				foreach (TextBox oText_loopVariable in this.txtInteger) {
					oText = oText_loopVariable;
					//UPGRADE_WARNING: Couldn't resolve default property of object oText.Index. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//txtInteger_Leave(txtInteger.Item(oText.Index), New System.EventArgs())
				}
				foreach (TextBox oText_loopVariable in this.txtFloat) {
					oText = oText_loopVariable;
					//UPGRADE_WARNING: Couldn't resolve default property of object oText.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (string.IsNullOrEmpty(oText.Text))
						oText.Text = "0";
					//UPGRADE_WARNING: Couldn't resolve default property of object oText.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					oText.Text = oText.Text * 100;
					//UPGRADE_WARNING: Couldn't resolve default property of object oText.Index. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//txtFloat_Leave(txtFloat.Item(oText.Index), New System.EventArgs())
				}
				foreach (TextBox oText_loopVariable in this.txtFloatNegative) {
					oText = oText_loopVariable;
					//UPGRADE_WARNING: Couldn't resolve default property of object oText.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (string.IsNullOrEmpty(oText.Text))
						oText.Text = "0";
					//UPGRADE_WARNING: Couldn't resolve default property of object oText.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					oText.Text = oText.Text * 100;
					//UPGRADE_WARNING: Couldn't resolve default property of object oText.Index. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//txtFloatNegative_Leave(txtFloatNegative.Item(oText.Index), New System.EventArgs())
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
			lDirty = false;
			functionReturnValue = true;
			if (mbAddNewFlag) {
				adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll);
				adoPrimaryRS.MoveLast();
				//move to the new record
			} else {
				for (x = 1; x <= 8; x++) {
					if (adoPrimaryRS.Fields("PricingGroup_Unit" + x).Value != adoPrimaryRS.Fields("PricingGroup_Unit" + x).OriginalValue)
						lDirty = true;
					if (adoPrimaryRS.Fields("PricingGroup_Case" + x).Value != adoPrimaryRS.Fields("PricingGroup_Case" + x).OriginalValue)
						lDirty = true;
				}
				if (adoPrimaryRS.Fields("PricingGroup_RemoveCents").Value != adoPrimaryRS.Fields("PricingGroup_RemoveCents").OriginalValue)
					lDirty = true;
				if (adoPrimaryRS.Fields("PricingGroup_RoundAfter").Value != adoPrimaryRS.Fields("PricingGroup_RoundAfter").OriginalValue)
					lDirty = true;
				if (adoPrimaryRS.Fields("PricingGroup_RoundDown").Value != adoPrimaryRS.Fields("PricingGroup_RoundDown").OriginalValue)
					lDirty = true;
				if (lDirty) {
					modRecordSet.cnnDB.Execute("INSERT INTO tempStockItem ( tempStockItemID ) SELECT StockItem.StockItemID FROM StockItem LEFT JOIN tempStockItem ON StockItem.StockItemID = tempStockItem.tempStockItemID WHERE (((StockItem.StockItem_PricingGroupID)=" + adoPrimaryRS.Fields("PricingGroupID").Value + ") AND ((tempStockItem.tempStockItemID) Is Null));");
				}
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

			if (Convert.ToDouble(this.chkPricing.Tag) != this.chkPricing.CheckState) {
				modRecordSet.cnnDB.Execute("UPDATE PricingGroup SET PricingGroup_Disabled = " + Conversion.Val(Convert.ToString(this.chkPricing.CheckState)) + " WHERE PricingGroupID = " + pRid);
			}
			if (update_Renamed()) {
				this.Close();
			}
		}

		private void txtFields_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			int Index = 0;
			TextBox txBox = new TextBox();
			txBox = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref txBox, ref txtFields);
			modUtilities.MyGotFocus(ref txtFields[Index]);
		}

		private void txtInteger_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			int Index = 0;
			TextBox txtBox = new TextBox();
			txtBox = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref txtBox, ref txtInteger);
			modUtilities.MyGotFocusNumeric(ref txtInteger[Index]);
		}

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

		private void txtInteger_Leave(System.Object eventSender, EventArgs eventArgs)
		{
			int Index = 0;
			TextBox txtBox = new TextBox();
			txtBox = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref txtBox, ref txtInteger);
			modUtilities.MyLostFocus(ref txtInteger[Index], ref 0);
		}

		private void txtFloat_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			int Index = 0;
			TextBox textBox = new TextBox();
			textBox = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref textBox, ref txtFloat);
			modUtilities.MyGotFocusNumeric(ref txtFloat[Index]);
		}

		private void txtFloat_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			//Dim Index As Short = txtFloat.GetIndex(eventSender)
			modUtilities.MyKeyPress(ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtFloat_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			int Index = 0;
			TextBox txtBox = new TextBox();
			txtBox = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref txtBox, ref txtFloat);
			modUtilities.MyLostFocus(ref txtFloat[Index], ref 2);
		}

		private void txtFloatNegative_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			int Index = 0;
			TextBox txtBox = new TextBox();
			txtBox = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref txtBox, ref txtFloatNegative);
			modUtilities.MyGotFocusNumeric(ref txtFloatNegative[Index]);
		}

		private void txtFloatNegative_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			int Index = 0;
			TextBox txtBox = new TextBox();
			txtBox = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref txtBox, ref txtFloatNegative);
			modUtilities.MyKeyPressNegative(ref txtFloatNegative[Index], ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtFloatNegative_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			int Index = 0;
			TextBox txtBox = new TextBox();
			txtBox = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref txtBox, ref txtFloatNegative);
			modUtilities.MyLostFocus(ref txtFloatNegative[Index], ref 2);
		}
	}
}
