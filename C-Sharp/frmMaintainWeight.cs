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
	internal partial class frmMaintainWeight : System.Windows.Forms.Form
	{
		short bEditFlag;
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
		bool blHandHeld;
		string gFilter;
		string gFilterSQL;
		int gID;

		private void loadLanguage()
		{

			//frmMaintainWeight = No Code    [Maintain Scale Weight Codes]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmMaintainWeight.Caption = rsLang("LanguageLayoutLnk_Description"): frmMaintainWeight.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1065;
			//New|Checked
			if (modRecordSet.rsLang.RecordCount){cmdNew.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdNew.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//cmdCancel = No Code            [Cancel]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdCancel.Caption = rsLang("LanguageLayoutLnk_Description"): cmdCancel.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmMaintainWeight.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public void loadItem(ref int id)
		{
			System.Windows.Forms.TextBox oText = null;
			ADODB.Recordset rs = default(ADODB.Recordset);

			gID = id;
			if (id) {
				//Set adoPrimaryRS = getRS("SELECT * FROM WeightCodes")
				//adoPrimaryRS.AddNew
				this.Text = this.Text + " [New record]";
				//mbAddNewFlag = True
				Frame1.Visible = false;
				return;

			} else {
				getNamespace();
				mbDataChanged = false;
			}

			loadLanguage();
			ShowDialog();

		}
		private void getNamespace()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rj = default(ADODB.Recordset);

			adoPrimaryRS = modRecordSet.getRS(ref "SELECT * FROM WeightCodes");
			//Display the list of Titles in the DataCombo
			grdDataGrid.DataSource = adoPrimaryRS;

			grdDataGrid.Columns[0].HeaderText = "ScalePrefix";
			grdDataGrid.Columns[0].DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft;
			grdDataGrid.Columns[0].Width = sizeConvertors.twipsToPixels(1000, true);
			grdDataGrid.Columns[0].Frozen = false;

			grdDataGrid.Columns[1].HeaderText = "Barcode";
			grdDataGrid.Columns[1].DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft;
			grdDataGrid.Columns[1].Width = sizeConvertors.twipsToPixels(1000, true);
			grdDataGrid.Columns[1].Frozen = false;

			grdDataGrid.Columns[2].HeaderText = "Check Digit";
			grdDataGrid.Columns[2].DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft;
			grdDataGrid.Columns[2].Width = sizeConvertors.twipsToPixels(1000, true);
			grdDataGrid.Columns[2].DefaultCellStyle.Format = 1;
			grdDataGrid.Columns[2].Frozen = false;

			grdDataGrid.Columns[3].HeaderText = "Price";
			grdDataGrid.Columns[3].DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgRight;
			grdDataGrid.Columns[3].Width = sizeConvertors.twipsToPixels(1000, true);
			grdDataGrid.Columns[3].Frozen = false;

			grdDataGrid.Columns[4].HeaderText = "Decimals";
			grdDataGrid.Columns[4].DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgRight;
			grdDataGrid.Columns[4].Width = sizeConvertors.twipsToPixels(1000, true);
			grdDataGrid.Columns[4].Frozen = false;

			frmMaintainWeight_Resize(this, new System.EventArgs());
			mbDataChanged = false;

		}
		private void cmdNew_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			Frame1.Visible = false;
			cmdNew.Enabled = false;
			loadItem(ref 1);

		}
		private void frmMaintainWeight_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			//This will resize the grid when the form is resized
			System.Windows.Forms.Application.DoEvents();
			grdDataGrid.Height = sizeConvertors.twipsToPixels(2685, false);
			//grdDataGrid.Columns(1).Width = grdDataGrid.Width - 5000

		}
		private void frmMaintainWeight_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 27) {
				KeyAscii = 0;
				cmdClose_Click(cmdClose, new System.EventArgs());
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmMaintainWeight_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;

		}
		private void adoPrimaryRS_MoveComplete(ADODB.EventReasonEnum adReason, ADODB.Error pError, ref ADODB.EventStatusEnum adStatus, ADODB.Recordset pRecordset)
		{
			//This will display the current record position for this recordset
		}
		private void adoPrimaryRS_WillChangeRecord(ADODB.EventReasonEnum adReason, int cRecords, ref ADODB.EventStatusEnum adStatus, ADODB.Recordset pRecordset)
		{
			int lQuantity = 0;
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

			cmdNew.Enabled = true;

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
		private void update_Renamed()
		{
			 // ERROR: Not supported in C#: OnErrorStatement


			adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll);
			if (mbAddNewFlag) {
				adoPrimaryRS.MoveLast();
				//Move to the new record
			}
			mbEditFlag = false;
			mbAddNewFlag = false;
			mbDataChanged = false;

			return;
			UpdateErr:
			Interaction.MsgBox(Err().Description);
		}
		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string sql = null;

			//Add new Record
			if (gID == 1) {
				//Verify....
				if (Conversion.Val(this._txtFields_4.Text) > 1) {
					Interaction.MsgBox("Check digit can only be 0 or 1", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly + MsgBoxStyle.Information, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);

					return;
				}
				sql = "INSERT INTO WeightCodes (ScalePrefix,barCode,CheckDigit,PriceLength,NrDecimals) VALUES ( '" + this._txtFields_0.Text + "'," + Conversion.Val(this._txtFields_1.Text) + "," + Conversion.Val(this._txtFields_4.Text) + "," + Conversion.Val(this._txtFields_2.Text) + "," + Conversion.Val(this._txtFields_3.Text) + ")";
				modRecordSet.cnnDB.Execute(sql);
				this.Close();
			} else {
				update_Renamed();
				this.Close();
			}

		}
		private void goFirst()
		{
			 // ERROR: Not supported in C#: OnErrorStatement


			adoPrimaryRS.MoveFirst();
			mbDataChanged = false;
			return;
			GoFirstError:

			Interaction.MsgBox(Err().Description);
		}
		private void goLast()
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			adoPrimaryRS.MoveLast();
			mbDataChanged = false;
			return;
			GoLastError:

			Interaction.MsgBox(Err().Description);
		}
		//Handles txtFields.KeyPress
		private void txtFields_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			//Dim Index As Short = txtFields.GetIndex(eventSender)


			if (Information.IsNumeric(Strings.Chr(KeyAscii))) {
			} else {
				if (KeyAscii == 49 | KeyAscii == 13 | KeyAscii == 8) {
				} else {
					KeyAscii = 0;
				}
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
	}
}
