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
	internal partial class frmDepositTake : System.Windows.Forms.Form
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
		private StdFormat.StdDataFormat fmtBooleanData;

		private void loadLanguage()
		{

			//frmDepositTake = No Code   [Deposit Stock Take Adjustments]
			//'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmDepositTake.Caption = rsLang("LanguageLayoutLnk_Description"): frmDepositTake.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblHeading = No Code       [Deposit Stock Take List]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblHeading.Caption = rsLang("LanguageLayoutLnk_Description"): lblHeading.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1085;
			//Print|Checked
			if (modRecordSet.rsLang.RecordCount){cmdPrint.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPrint.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmDepositTake.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public void loadItem()
		{
			My.MyProject.Forms.frmStockTakeSnapshot.remoteSnapShot();
			System.Windows.Forms.Application.DoEvents();

			getNamespace();
			mbDataChanged = false;

			loadLanguage();
			ShowDialog();
		}


		private void cmdFilter_Click()
		{
			My.MyProject.Forms.frmFilter.loadFilter(ref gFilter);
			getNamespace();
		}

		private void getNamespace()
		{

			adoPrimaryRS = modRecordSet.getRS(ref "SELECT Deposit.Deposit_Name, StockTakeDeposit_DepositTypeID, StockTakeDeposit.StockTakeDeposit_Quantity, StockTakeDeposit_DepositTypeID, StockTakeDeposit.StockTakeDeposit_WarehouseID, StockTakeDeposit.StockTakeDeposit_DepositID FROM Deposit INNER JOIN StockTakeDeposit ON Deposit.DepositID = StockTakeDeposit.StockTakeDeposit_DepositID Where (((StockTakeDeposit.StockTakeDeposit_WarehouseID) = 2)) ORDER BY Deposit.Deposit_Name, StockTakeDeposit.StockTakeDeposit_DepositTypeID;");

			//Display the list of Titles in the DataCombo
			grdDataGrid.DataSource = adoPrimaryRS;
			grdDataGrid.Columns[0].HeaderText = "Stock Name";
			grdDataGrid.Columns[0].DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft;
			grdDataGrid.Columns[0].Frozen = true;

			grdDataGrid.Columns[1].HeaderText = "Type";
			grdDataGrid.Columns[1].Frozen = true;
			grdDataGrid.Columns[1].Width = sizeConvertors.twipsToPixels(900, true);
			grdDataGrid.Columns[1].DefaultCellStyle.Format = fmtBooleanData;


			grdDataGrid.Columns[2].HeaderText = "Quantity";
			grdDataGrid.Columns[2].DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgRight;
			grdDataGrid.Columns[2].Width = sizeConvertors.twipsToPixels(900, true);
			//UPGRADE_WARNING: Couldn't resolve default property of object grdDataGrid.Columns().DataFormat.Type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//grdDataGrid.Columns(2).DefaultCellStyle.FormatProvid = 1
			grdDataGrid.Columns[2].DefaultCellStyle.Format = "#,##0";
			grdDataGrid.Columns[2].Frozen = false;

			grdDataGrid.Columns[5].Visible = false;
			grdDataGrid.Columns[3].Visible = false;
			grdDataGrid.Columns[4].Visible = false;

			frmDepositTake_Resize(this, new System.EventArgs());
			mbDataChanged = false;

		}



		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modApplication.report_DepositTake();
		}

		private void frmDepositTake_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			fmtBooleanData = new StdFormat.StdDataFormat();
			fmtBooleanData.Type = StdFormat.FormatType.fmtBoolean;
			fmtBooleanData.TrueValue = "Crate";
			fmtBooleanData.FalseValue = "Bottle";
			fmtBooleanData.NullValue = "";

		}
		private void frmDepositTake_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

//UPGRADE_WARNING: Event frmDepositTake.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void frmDepositTake_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			//This will resize the grid when the form is resized
			System.Windows.Forms.Application.DoEvents();
			grdDataGrid.Height = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(this.ClientRectangle.Height, false) - 30 - sizeConvertors.pixelToTwips(picButtons.Height, false), false);
			grdDataGrid.Columns[0].Width = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(grdDataGrid.Width, true) - 1800 - 580, true);

		}

		private void frmDepositTake_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
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
			if (adoPrimaryRS.Fields("StockTakeDeposit_Quantity").OriginalValue != adoPrimaryRS.Fields("StockTakeDeposit_Quantity").Value) {
				lQuantity = Convert.ToInt32(adoPrimaryRS.Fields("StockTakeDeposit_Quantity").Value) - Convert.ToInt32(adoPrimaryRS.Fields("StockTakeDeposit_Quantity").OriginalValue);
				modRecordSet.cnnDB.Execute("UPDATE WarehouseDepositItemLnk SET WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity = [WarehouseDepositItemLnk]![WarehouseDepositItemLnk_Quantity]+(" + lQuantity + ") WHERE (((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID)=" + adoPrimaryRS.Fields("StockTakeDeposit_WarehouseID").Value + ") AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID)=" + adoPrimaryRS.Fields("StockTakeDeposit_DepositID").Value + ") AND ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID)=" + adoPrimaryRS.Fields(1).Value + "));");

				modRecordSet.cnnDB.Execute("UPDATE Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityShrink = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityShrink]+" + lQuantity + " WHERE (((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID)=" + adoPrimaryRS.Fields("StockTakeDeposit_DepositID").Value + ") AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=" + adoPrimaryRS.Fields(1).Value + "));");

				doDiskFlush();

			}
		}
		private void doDiskFlush()
		{
			return;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			int hkey = 0;
			int lRetVal = 0;
			string vValue = null;
			string lPath = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			int lID = 0;
			int lCompanyID = 0;
			string lString = null;
			string lKey = null;
			short lDepositType = 0;
			lID = adoPrimaryRS.Fields("StockTakeDeposit_DepositID").Value;
			lDepositType = adoPrimaryRS.Fields(1).Value;
			lRetVal = modUtilities.RegOpenKeyEx(modUtilities.HKEY_LOCAL_MACHINE, "Software\\4POS", 0, modUtilities.KEY_QUERY_VALUE, ref hkey);
			lRetVal = modUtilities.QueryValueEx(hkey, "master", ref vValue);
			modUtilities.RegCloseKey(hkey);
			if (string.IsNullOrEmpty(vValue)) {
				return;
			} else {
				lPath = vValue;
			}
			rs = modRecordSet.getRS(ref "SELECT Company.CompanyID, DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID, DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID, DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityShrink, DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType FROM Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID WHERE (((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID)=" + lID + ") AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=" + lDepositType + "));");

			//If rs.RecordCount Then
			//Key = rs("CompanyID") & "_" & rs("DayEndDeposittemLnk_DepositID") & "_" & rs("DayEndDepositItemLnk_DayEndID") & "_" & CInt(lDepositType + 1)
			//lCompanyID = rs("CompanyID")
			//If fso.FileExists(lPath & lCompanyID & "\" & Key & ".stk") Then fso.DeleteFile lPath & lCompanyID & "\" & Key & ".stk"
			//If rs("DayEndDepositItemLnk_QuantityShrink") Then
			//Set lTextstream = fso.OpenTextFile(lPath & lCompanyID & "\" & Key & ".stk", ForWriting, True)
			//lTextstream.Write rs("DayEndDepositItemLnk_QuantityShrink")
			//lTextstream.Close
			//End If
			//End If

		}
		private void cmdCancel_Click()
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

		//Private Sub grdDataGrid_CellValueChanged(ByVal eventSender As System.Object, ByVal eventArgs As AxMSDataGridLib.DDataGridEvents_CellValueChangedEvent) Handles grdDataGrid.CellValueChanged
		//    If grdDataGrid.Columns(ColIndex).DataFormat.Format = "#,##0.00" Then
		//       grdDataGrid.Columns(ColIndex).DataFormat = 0
		//    End If

		//End Sub
	}
}
