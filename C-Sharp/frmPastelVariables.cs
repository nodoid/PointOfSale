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
namespace _4PosBackOffice.NET
{
	internal partial class frmPastelVariables : System.Windows.Forms.Form
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

			//frmPastelVariables = No Code   [Edit Export Variable]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmPastelVariable.Caption = rsLang("LanguageLayoutLnk_Description"): frmPastelVariables.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//Label1 = No Code               [Note: Account Number.......]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmPastelVariables.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public void loadItem(ref int id)
		{

			ADODB.Recordset rs = default(ADODB.Recordset);
			gID = id;
			getNamespace();

			mbDataChanged = false;

			loadLanguage();
			ShowDialog();
		}
		private void getNamespace()
		{
			System.Windows.Forms.TextBox oText = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rj = default(ADODB.Recordset);

			adoPrimaryRS = modRecordSet.getRS(ref "SELECT IDDescription,GDC,Decription1,AccountNumber,Reference,Period FROM PastelDescription");

			//Display the list of Titles in the DataCombo
			grdDataGrid.DataSource = adoPrimaryRS;

			grdDataGrid.Columns[0].HeaderText = "ID No";
			grdDataGrid.Columns[0].DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft;
			grdDataGrid.Columns[0].Width = sizeConvertors.twipsToPixels(800, true);
			grdDataGrid.Columns[0].Frozen = true;

			grdDataGrid.Columns[1].HeaderText = "GDC";
			grdDataGrid.Columns[1].DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft;
			grdDataGrid.Columns[1].Width = sizeConvertors.twipsToPixels(800, true);
			grdDataGrid.Columns[1].Frozen = true;

			grdDataGrid.Columns[2].HeaderText = "Decription";
			grdDataGrid.Columns[2].DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft;
			grdDataGrid.Columns[2].Width = sizeConvertors.twipsToPixels(3890.124, true);
			grdDataGrid.Columns[2].Frozen = false;

			grdDataGrid.Columns[3].HeaderText = "Account Number";
			grdDataGrid.Columns[3].DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft;
			grdDataGrid.Columns[3].Width = sizeConvertors.twipsToPixels(1890.124, true);
			grdDataGrid.Columns[3].DefaultCellStyle.Format = 1;
			grdDataGrid.Columns[3].Frozen = false;

			grdDataGrid.Columns[4].HeaderText = "Reference";
			grdDataGrid.Columns[4].DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgRight;
			grdDataGrid.Columns[4].Width = sizeConvertors.twipsToPixels(1000, true);
			grdDataGrid.Columns[4].DefaultCellStyle.Format = 1;
			grdDataGrid.Columns[4].Frozen = false;

			frmPastelVariables_Resize(this, new System.EventArgs());
			mbDataChanged = false;

		}
		private void frmPastelVariables_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			modBResolutions.ResizeForm(ref this, ref sizeConvertors.pixelToTwips(this.Width, true), ref sizeConvertors.pixelToTwips(this.Height, false), ref 2);

		}

//UPGRADE_WARNING: Event frmPastelVariables.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void frmPastelVariables_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			//This will resize the grid when the form is resized
			System.Windows.Forms.Application.DoEvents();
			grdDataGrid.Height = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(this.ClientRectangle.Height, false) - 30 - sizeConvertors.pixelToTwips(picButtons.Height, false), false);
			//grdDataGrid.Columns(1).Width = grdDataGrid.Width
			//grdDataGrid.Columns(1).Width = grdDataGrid.Width - 5000

		}
		private void frmPastelVariables_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void frmPastelVariables_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
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

			if (adoPrimaryRS.Fields("Reference").OriginalValue != adoPrimaryRS.Fields("Reference").Value) {

				//cnndb.Execute "Update PastelDescription Set Narrative ='
			}

			if (adoPrimaryRS.Fields("AccountNumber").OriginalValue != adoPrimaryRS.Fields("AccountNumber").Value) {
				//cnnDB.Execute "Update PastelDescription Set AccountNumber =' "

			}


		}
//UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
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

			//On Error Resume Next
			//If Val(txtPeriod(0).Text) >= 1 And Val(txtPeriod(0).Text) <= 12 Then
			//   cnnDB.Execute "UPDATE PastelDescription Set Period = " & Val(txtPeriod(0).Text)
			update_Renamed();
			this.Close();
			//Else
			//   MsgBox "Period Value must be in range of 1 - 12", vbApplicationModal + vbInformation + vbOKOnly, "Pastel Variables"
			//End If
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

		//Private Sub grdDataGrid_CellValueChanged(ByVal eventSender As System.Object, ByVal eventArgs As AxMSDataGridLib.DDataGridEvents_CellValueChangedEvent) Handles grdDataGrid.CellValueChanged
		//    If grdDataGrid.Columns(ColIndex).DataFormat.Format = "#,##0.00" Then
		//       grdDataGrid.Columns(ColIndex).DataFormat = 0
		//    End If

		//End Sub
	}
}
