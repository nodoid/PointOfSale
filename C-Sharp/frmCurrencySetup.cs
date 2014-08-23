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
	internal partial class frmCurrencySetup : System.Windows.Forms.Form
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
		bool blHandHeld;
		string gFilter;
		string gFilterSQL;
		int gID;

		private void loadLanguage()
		{

			//frmCurrencySetup = No Code     [Currency Setup]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmCurrency.Caption = rsLang("LanguageLayoutLnk_Description"): frmCurrency.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//Label1 = No Code               [Available Currencies]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdNew = No Code               [Add New]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdNew.Caption = rsLang("LanguageLayoutLnk_Description"): cmdNew.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdSave = No Code              [Save]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdSave.Caption = rsLang("LanguageLayoutLnk_Description"): cmdSave.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1148;
			//Delete|Checked
			if (modRecordSet.rsLang.RecordCount){cmdDelete.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdDelete.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmCurrencySetup.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public void loadItem(ref int id)
		{
			//If id Then Else Exit Sub
			gID = id;
			getNamespace();

			mbDataChanged = false;

			loadLanguage();
			ShowDialog();
		}
		private void getNamespace()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rj = default(ADODB.Recordset);

			adoPrimaryRS = modRecordSet.getRS(ref "SELECT * FROM PresetCurrency");

			//Display the list of Titles in the DataCombo
			grdDataGrid.DataSource = adoPrimaryRS;

			grdDataGrid.Columns[0].HeaderText = "ID";
			grdDataGrid.Columns[0].DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft;
			grdDataGrid.Columns[0].Width = sizeConvertors.twipsToPixels(700, true);
			grdDataGrid.Columns[0].Frozen = true;
			grdDataGrid.Columns[0].Visible = false;

			grdDataGrid.Columns[1].HeaderText = "Curreny Name";
			grdDataGrid.Columns[1].DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft;
			grdDataGrid.Columns[1].Width = sizeConvertors.twipsToPixels(1590.124, true);
			grdDataGrid.Columns[1].Frozen = true;


			grdDataGrid.Columns[2].HeaderText = "Curreny Symbol";
			grdDataGrid.Columns[2].DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft;
			grdDataGrid.Columns[2].Width = sizeConvertors.twipsToPixels(1590.124, true);
			grdDataGrid.Columns[2].DefaultCellStyle.Format = StdFormat.FormatType.fmtCustom;
			grdDataGrid.Columns[2].Frozen = false;

			grdDataGrid.Columns[3].HeaderText = "Exchange Rate";
			grdDataGrid.Columns[3].DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgRight;
			grdDataGrid.Columns[3].Width = sizeConvertors.twipsToPixels(1590.124, true);
			grdDataGrid.Columns[3].Frozen = false;


			frmCurrencySetup_Resize(this, new System.EventArgs());
			mbDataChanged = false;

		}

		private void cmdDelete_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string sqlD = null;
			//a = grdDataGrid.Col
			//a = grdDataGrid.Columns(0).Text

			if (Interaction.MsgBox("Are you sure you want to delete " + grdDataGrid.Columns[1].HeaderText + " Currency Information?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes) {
				sqlD = "Delete FROM PresetCurrency where CurrencyID = " + grdDataGrid.Columns[0].HeaderText;
				modRecordSet.cnnDB.Execute(sqlD);

				getNamespace();
				grdDataGrid.CtlRefresh();
			}
		}

		private void cmdNew_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			ADODB.Recordset rj = default(ADODB.Recordset);
			rj = modRecordSet.getRS(ref "SELECT * FROM PresetCurrency");

			if (rj.RecordCount >= 4) {
				Interaction.MsgBox(" You can only be able to Maintain 4 Currencies at a time, If you want to Add more please Delete one of the Currency you don't need at this time ");
			} else {

				grdDataGrid.Columns[1].Frozen = false;
				grdDataGrid.AllowAddNew = true;
				grdDataGrid.Focus();
				//grdDataGrid.AddNewMode
				if (rj.RecordCount <= 0) {
					//grdDataGrid.row = -1 ' rj.RecordCount + 1
				} else {
					grdDataGrid.row = rj.RecordCount + 1;
				}

				//grdDataGrid.Columns(0).Text = rj.RecordCount + 1

				cmdSave.Enabled = true;

				cmdNew.Enabled = false;
				cmdDelete.Enabled = false;
				//grdDataGrid.SelStartCol = 1
				//grdDataGrid.SelEndCol = 1
			}

		}

		private void cmdSave_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			update_Renamed();
			getNamespace();
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			grdDataGrid.CtlRefresh();

			grdDataGrid.Columns[1].Frozen = true;
			grdDataGrid.AllowAddNew = false;

			cmdSave.Enabled = false;

			cmdNew.Enabled = true;
			cmdDelete.Enabled = true;
		}

		private void frmCurrencySetup_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			//This will resize the grid when the form is resized
			System.Windows.Forms.Application.DoEvents();
			//grdDataGrid.Height = 2685
			//grdDataGrid.Columns(1).Width = grdDataGrid.Width - 5000

		}
		private void frmCurrencySetup_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void frmCurrencySetup_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;

		}

		private void adoPrimaryRS_MoveComplete(ADODB.EventReasonEnum adReason, ADODB.Error pError, ref ADODB.EventStatusEnum adStatus, ADODB.Recordset pRecordset)
		{
			//This will display the current record position for this recordset
		}

		private void adoPrimaryRS_WillChangeRecord(ADODB.EventReasonEnum adReason, int cRecords, ref ADODB.EventStatusEnum adStatus, ADODB.Recordset pRecordset)
		{
		}
		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement


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
			update_Renamed();
			this.Close();
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

		private void grdDataGrid_CellValueChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			//    If grdDataGrid.Columns(ColIndex).DataFormat.Format = "#,##0.00" Then
			//       grdDataGrid.Columns(ColIndex).DataFormat = 0
			//    End If

		}
	}
}
