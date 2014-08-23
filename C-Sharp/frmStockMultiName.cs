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
using StdFormat;
namespace _4PosBackOffice.NET
{
	internal partial class frmStockMultiName : System.Windows.Forms.Form
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

		string gFilter;
		string gFilterSQL;

		private void loadLanguage()
		{

			//frmStockMultiName = No Code    [Edit Stock Item Names]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmStockMultiName.Caption = rsLang("LanguageLayoutLnk_Description"): frmStockMultiName.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblHeading = No Code           [Using the "Stock Item Selector"...]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblHeading.Caption = rsLang("LanguageLayoutLnk_Description"): lblHeading.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1006;
			//Filter|Checked
			if (modRecordSet.rsLang.RecordCount){cmdFilter.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdFilter.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1085;
			//Print|Checked
			if (modRecordSet.rsLang.RecordCount){cmdPrint.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPrint.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmStockMultiName.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdFilter_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmFilter.loadFilter(ref gFilter);
			getNamespace();
		}

		private void getNamespace()
		{
			object lString = null;
			if (string.IsNullOrEmpty(gFilter)) {
				this.lblHeading.Text = "";
			} else {
				My.MyProject.Forms.frmFilter.buildCriteria(ref gFilter);
				this.lblHeading.Text = My.MyProject.Forms.frmFilter.gHeading;
			}
			gFilterSQL = My.MyProject.Forms.frmFilter.gCriteria;
			if (string.IsNullOrEmpty(gFilterSQL)) {
				//UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lString = " WHERE StockItem.StockItem_Disabled=0 AND StockItem.StockItem_Discontinued=0 ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lString = gFilterSQL + " AND StockItem.StockItem_Disabled=0 AND StockItem.StockItem_Discontinued=0 ";
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object lString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			adoPrimaryRS = modRecordSet.getRS(ref "SELECT StockItem_Name,StockItem_ReceiptName FROM StockItem " + lString + " ORDER BY StockItem_Name");
			//Display the list of Titles in the DataCombo

			grdDataGrid.DataSource = adoPrimaryRS;
			grdDataGrid.Columns[0].HeaderText = "Stock Name";
			grdDataGrid.Columns[0].DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft;

			grdDataGrid.Columns[1].HeaderText = "Receipt Name";
			grdDataGrid.Columns[1].DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft;
			grdDataGrid.Columns[1].Width = sizeConvertors.twipsToPixels(2000, true);
			frmStockMultiName_Resize(this, new System.EventArgs());
			mbDataChanged = false;

		}

		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			bool ltype = false;
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = default(CrystalDecisions.CrystalReports.Engine.ReportDocument);
			Report.Load("cryStockItemName.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			Report.SetParameterValue("txtTilte", this.Text);
			Report.SetParameterValue("txtFilter", this.lblHeading.Text);
			rs.Close();
			//Report.Database.SetDataSource(adoPrimaryRS, 3)
			Report.Database.Tables(1).SetDataSource(adoPrimaryRS);
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTilte").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();

		}

		private void frmStockMultiName_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void frmStockMultiName_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			var myfmt = new StdDataFormat();
			myfmt.Type = FormatType.fmtCustom;
			gFilter = "stockitem";
			getNamespace();
			mbDataChanged = false;

			loadLanguage();
		}

		private void frmStockMultiName_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			//This will resize the grid when the form is resized
			System.Windows.Forms.Application.DoEvents();
			grdDataGrid.Height = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(this.ClientRectangle.Height, false) - 30 - sizeConvertors.pixelToTwips(picButtons.Height, false), false);
			grdDataGrid.Columns[0].Width = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(grdDataGrid.Width, true) - 2000 - 580, true);

		}

		private void frmStockMultiName_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
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

		private void cmdCancel_Click()
		{
			 // ERROR: Not supported in C#: OnErrorStatement


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
			mbDataChanged = false;

		}

//UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private void update_Renamed()
		{
			 // ERROR: Not supported in C#: OnErrorStatement


			adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll);

			if (mbAddNewFlag) {
				adoPrimaryRS.MoveLast();
				//move to the new record
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

		//Private Sub grdDataGrid_CellValueChanged(ByVal eventSender As System.Object, ByVal eventArgs As DataColumnChangeEventArgs) Handles grdDataGrid.ColumnDisplayIndexChanged
		//    If grdDataGrid.Columns(ColIndex).DataFormat.Format = "#,##0.00" Then
		//       grdDataGrid.Columns(ColIndex).DataFormat = 0
		//    End If

		//End Sub
	}
}
