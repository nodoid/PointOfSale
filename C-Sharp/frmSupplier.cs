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
	internal partial class frmSupplier : System.Windows.Forms.Form
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
		List<TextBox> txtFloat = new List<TextBox>();
		List<TextBox> txtFields = new List<TextBox>();
		List<TextBox> txtFloatNegative = new List<TextBox>();

		List<CheckBox> chkFields = new List<CheckBox>();
		int gID;

		private void loadLanguage()
		{

			//NOTE: DB Entry 1437 contains invalid text!!!
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1437;
			//Edit Supplier Details|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1282;
			//Statement|Checked
			if (modRecordSet.rsLang.RecordCount){cmdStatement.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdStatement.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1010;
			//General|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1442;
			//Supplier Name|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1288;
			//Telephone|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_8.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_8.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1289;
			//Fax|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_9.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_9.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1291;
			//Physical Address|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_6.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_6.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1292;
			//Postal Address|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_7.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_7.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1447;
			//Disable this Supplier|Checked
			if (modRecordSet.rsLang.RecordCount){_chkFields_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_chkFields_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1448;
			//Aging|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1295;
			//Current|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_13.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_13.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1297;
			//60 Days|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_15.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_15.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1299;
			//120 Days|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_17.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_17.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1296;
			//30 Days|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_14.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_14.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1298;
			//90 Days|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_16.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_16.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1454;
			//Ordering Details|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1455;
			//Representative Name|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_38.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_38.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1456;
			//Reperesentative Number|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_37.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_37.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1457;
			//Account number|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_36.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_36.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1458;
			//Default Order Attention Line Text|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_35.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_35.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1459;
			//GRV Template|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_4.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_4.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1460;
			//Payment Terms|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1461;
			//Ullage Discount|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_33.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_33.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1462;
			//C.O.D|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_32.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_32.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1296;
			//30 Days|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_30.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_30.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1298;
			//90 Days|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_28.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_28.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1468;
			//Smart Card|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_26.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_26.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lblLabels(31) = No Code    [15 Days]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblLabels(31).Caption = rsLang("LanguageLayoutLnk_Description"): lblLabels(31).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1297;
			//60 Days|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_29.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_29.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1299;
			//120 Days|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_27.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_27.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmSupplier.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void buildDataControls()
		{
			//    doDataControl Me.cmbChannel, "SELECT ChannelID, Channel_Name FROM Channel ORDER BY ChannelID", "Customer_ChannelID", "ChannelID", "Channel_Name"
			doDataControl(ref (this.cmbTemplate), ref "SELECT GRVTemplateID, GRVTemplate_Name FROM GRVTemplate ORDER BY GRVTemplate_Name", ref "Supplier_GRVtype", ref "GRVTemplate_Name", ref "GRVTemplate_Name");
			//doDataControl Me.cmbKeyboard, "SELECT KeyboardLayout.KeyboardLayoutID, KeyboardLayout.KeyboardLayout_Name FROM KeyboardLayout ORDER BY KeyboardLayout_Name", "POS_Keyboard", "KeyboardLayoutID", "KeyboardLayout_Name"
		}

		private void doDataControl(ref myDataGridView dataControl, ref string sql, ref string DataField, ref string boundColumn, ref string listField)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref sql);
			dataControl.DataSource = rs;
			dataControl.DataSource = adoPrimaryRS;
			dataControl.DataField = DataField;
			dataControl.boundColumn = boundColumn;
			dataControl.listField = listField;
		}

		public void loadItem(ref int id)
		{
			System.Windows.Forms.TextBox oText = null;
			System.Windows.Forms.CheckBox oCheck = null;
			 // ERROR: Not supported in C#: OnErrorStatement


			gID = id;

			bool cBitA = false;
			bool cBitF = false;
			if (id) {
				adoPrimaryRS = modRecordSet.getRS(ref "select * from Supplier WHERE SupplierID = " + id);

				if (32 & My.MyProject.Forms.frmMenu.gBit)
					cBitA = true;
				if (64 & My.MyProject.Forms.frmMenu.gBit)
					cBitF = true;
				if (cBitA == true & cBitF == true) {
					_txtFloat_13.Enabled = true;
					_txtFloat_14.Enabled = true;
					_txtFloat_15.Enabled = true;
					_txtFloat_16.Enabled = true;
					_txtFloat_17.Enabled = true;
				}

			} else {
				adoPrimaryRS = modRecordSet.getRS(ref "select * from Supplier");
				adoPrimaryRS.AddNew();
				this.Text = this.Text + " [New record]";
				mbAddNewFlag = true;
			}
			//    If adoPrimaryRS.BOF Or adoPrimaryRS.EOF Then
			//    Else
			 // ERROR: Not supported in C#: OnErrorStatement

			foreach (TextBox oText_loopVariable in txtFields) {
				oText = oText_loopVariable;
				oText.DataBindings.Add(adoPrimaryRS);
				oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize;
			}
			//        For Each oText In Me.txtInteger
			//            Set oText.DataBindings.Add(adoPrimaryRS)
			//            txtInteger_LostFocus oText.Index
			//        Next
			foreach (TextBox oText_loopVariable in txtFloat) {
				oText = oText_loopVariable;
				oText.DataBindings.Add(adoPrimaryRS);
				if (string.IsNullOrEmpty(oText.Text))
					oText.Text = "0";
				oText.Text = Convert.ToString(Convert.ToDouble(oText.Text) * 100);
				oText.Leave += txtFloat_Leave;
			}
			foreach (TextBox oText_loopVariable in txtFloatNegative) {
				oText = oText_loopVariable;
				oText.DataBindings.Add(adoPrimaryRS);
				if (string.IsNullOrEmpty(oText.Text))
					oText.Text = "0";
				oText.Text = Convert.ToString(Convert.ToDouble(oText.Text) * 100);
				oText.Leave += txtFloatNegative_Leave;
			}
			//Bind the check boxes to the data provider
			foreach (CheckBox oCheck_loopVariable in this.chkFields) {
				oCheck = oCheck_loopVariable;
				oCheck.DataBindings.Add(adoPrimaryRS);
			}
			buildDataControls();
			mbDataChanged = false;

			loadLanguage();
			ShowDialog();
			//    End If
		}

		private void cmdStatement_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (mbAddNewFlag) {
				Interaction.MsgBox("There is no statement for a new supplier.", MsgBoxStyle.Exclamation, "New Supplier");
			} else {
				modApplication.report_SupplierStatement(ref adoPrimaryRS.Fields("SupplierID").Value);
			}
		}

		private void frmSupplier_Load(object sender, System.EventArgs e)
		{
			txtFloat.AddRange(new TextBox[] {
				_txtFloat_13,
				_txtFloat_14,
				_txtFloat_15,
				_txtFloat_16,
				_txtFloat_17
			});
			txtFields.AddRange(new TextBox[] {
				_txtFields_1,
				_txtFields_2,
				_txtFields_6,
				_txtFields_7,
				_txtFields_8,
				_txtFields_9,
				_txtFields_26,
				_txtFields_27,
				_txtFields_28
			});
			txtFloatNegative.AddRange(new TextBox[] {
				_txtFloatNegative_11,
				_txtFloatNegative_12,
				_txtFloatNegative_13,
				_txtFloatNegative_14,
				_txtFloatNegative_15,
				_txtFloatNegative_16,
				_txtFloatNegative_17,
				_txtFloatNegative_18
			});
			chkFields.AddRange(new CheckBox[] { _chkFields_1 });
			TextBox tb = new TextBox();
			foreach (TextBox tb_loopVariable in txtFields) {
				tb = tb_loopVariable;
				tb.Enter += txtFields_Enter;
			}
			foreach (TextBox tb_loopVariable in txtFloat) {
				tb = tb_loopVariable;
				tb.Enter += txtFloat_Enter;
				tb.KeyPress += txtFloat_KeyPress;
			}
			foreach (TextBox tb_loopVariable in txtFloatNegative) {
				tb = tb_loopVariable;
				tb.Enter += txtFloatNegative_Enter;
				tb.KeyPress += txtFloatNegative_KeyPress;
			}
		}

//UPGRADE_WARNING: Event frmSupplier.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void frmSupplier_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			Button cmdLast = new Button();
			Button cmdNext = new Button();
			Label lblStatus = new Label();
			 // ERROR: Not supported in C#: OnErrorStatement

			lblStatus.Width = sizeConvertors.pixelToTwips(this.Width, true) - 1500;
			cmdNext.Left = lblStatus.Width + 700;
			cmdLast.Left = cmdNext.Left + 340;
		}

		private void frmSupplier_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			if (mbEditFlag | mbAddNewFlag)
				return;

			switch (KeyCode) {
				case System.Windows.Forms.Keys.Escape:
					KeyCode = 0;
					System.Windows.Forms.Application.DoEvents();
					adoPrimaryRS.Move(0);
					cmdClose_Click(cmdClose, new System.EventArgs());
					break;
			}
		}

		private void frmSupplier_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
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
			TextBox oText = new TextBox();
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
				foreach (TextBox oText_loopVariable in txtFloat) {
					oText = oText_loopVariable;
					if (string.IsNullOrEmpty(oText.Text))
						oText.Text = "0";
					oText.Text = oText.Text * 100;
					//txtFloat_Leave(txtFloat.Item(oText.Index), New System.EventArgs())
				}
				foreach (TextBox oText_loopVariable in this.txtFloatNegative) {
					oText = oText_loopVariable;
					if (string.IsNullOrEmpty(oText.Text))
						oText.Text = "0";
					oText.Text = oText.Text * 100;
					//txtFloatNegative_Leave(txtFloatNegative.Item(oText.Index), New System.EventArgs())
				}
				mbDataChanged = false;

				this.Close();
			}
		}
		private bool update_Renamed()
		{
			bool functionReturnValue = false;
			 // ERROR: Not supported in C#: OnErrorStatement

			functionReturnValue = true;
			if (string.IsNullOrEmpty(_txtFields_2.Text)) {
				Interaction.MsgBox("A Supplier's Name is required.", MsgBoxStyle.Information, "Suppler's Details");
				_txtFields_2.Focus();
				functionReturnValue = false;
				return functionReturnValue;
			}

			functionReturnValue = true;
			//adoPrimaryRS.UpdateBatch adAffectAll
			//If mbAddNewFlag Then
			//    adoPrimaryRS.MoveLast              'move to the new record
			//End If

			//mbEditFlag = False
			//mbAddNewFlag = False
			//mbDataChanged = False


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
			ADODB.Recordset rs = default(ADODB.Recordset);

			if (gID & txtFloat[13].Enabled == true) {
				rs = modRecordSet.getRS(ref "SELECT SUM(SupplierTransaction.SupplierTransaction_Amount) As sumTran From SupplierTransaction WHERE (((SupplierTransaction.SupplierTransaction_SupplierID)=" + gID + "));");
				if (rs.RecordCount > 0) {
					if (System.Math.Round((Information.IsDBNull(rs.Fields("sumTran").Value) ? 0 : rs.Fields("sumTran").Value), 2) != System.Math.Round(Convert.ToDecimal(txtFloat[13].Text) + Convert.ToDecimal(txtFloat[14].Text) + Convert.ToDecimal(txtFloat[15].Text) + Convert.ToDecimal(txtFloat[16].Text) + Convert.ToDecimal(txtFloat[17].Text), 2)) {
						Interaction.MsgBox("Aging does not match with total Balance!", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
						modUtilities.MyGotFocusNumeric(ref _txtFloat_13);
						_txtFloat_13.Focus();
						return;
					}
				}
			}

			cmdClose.Focus();
			System.Windows.Forms.Application.DoEvents();
			if (update_Renamed()) {
				this.Close();
			}
		}

		private void txtFields_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txtbox = new TextBox();
			txtbox = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txtbox, ref txtFields);
			modUtilities.MyGotFocus(ref txtFields[Index]);
		}

		private void txtFloat_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txtbox = new TextBox();
			txtbox = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txtbox, ref txtFloat);
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
			TextBox txtbox = new TextBox();
			txtbox = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txtbox, ref txtFloat);
			modUtilities.MyLostFocus(ref txtFloat[Index], ref 2);
		}

		private void txtFloatNegative_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txtbox = new TextBox();
			txtbox = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txtbox, ref txtFloatNegative);
			modUtilities.MyGotFocusNumeric(ref txtFloatNegative[Index]);
		}

		private void txtFloatNegative_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			TextBox txtbox = new TextBox();
			txtbox = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txtbox, ref txtFloatNegative);
			modUtilities.MyKeyPressNegative(ref txtFloatNegative[Index], ref KeyAscii);
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtFloatNegative_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txtbox = new TextBox();
			txtbox = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txtbox, ref txtFloatNegative);
			modUtilities.MyLostFocus(ref txtFloatNegative[Index], ref 2);
		}
	}
}
