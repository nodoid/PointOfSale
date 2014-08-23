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
	internal partial class frmStockMultiPrice : System.Windows.Forms.Form
	{
		private ADODB.Recordset withEventsField_adoPrimaryRS;
		public ADODB.Recordset adoPrimaryRS {
			get { return withEventsField_adoPrimaryRS; }
			set {
				if (withEventsField_adoPrimaryRS != null) {
					withEventsField_adoPrimaryRS.FieldChangeComplete -= adoPrimaryRS_FieldChangeComplete;
					withEventsField_adoPrimaryRS.MoveComplete -= adoPrimaryRS_MoveComplete;
					withEventsField_adoPrimaryRS.WillChangeRecord -= adoPrimaryRS_WillChangeRecord;
				}
				withEventsField_adoPrimaryRS = value;
				if (withEventsField_adoPrimaryRS != null) {
					withEventsField_adoPrimaryRS.FieldChangeComplete += adoPrimaryRS_FieldChangeComplete;
					withEventsField_adoPrimaryRS.MoveComplete += adoPrimaryRS_MoveComplete;
					withEventsField_adoPrimaryRS.WillChangeRecord += adoPrimaryRS_WillChangeRecord;
				}
			}
		}
		bool mbChangedByCode;
		bool mvBookMark;
		bool mbEditFlag;
		bool mbAddNewFlag;
		bool mbDataChanged;

		string gFilter;
		string gFilterSQL;
		private StdFormat.StdDataFormat withEventsField_myfmt;
		public StdFormat.StdDataFormat myfmt {
			get { return withEventsField_myfmt; }
			set {
				if (withEventsField_myfmt != null) {
					withEventsField_myfmt.UnFormat -= myfmt_UnFormat;
				}
				withEventsField_myfmt = value;
				if (withEventsField_myfmt != null) {
					withEventsField_myfmt.UnFormat += myfmt_UnFormat;
				}
			}
		}

		private void loadLanguage()
		{

			//frmStockMultiPrice = No Code   [Edit Stock Item Micro Pricing]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmStockMultiPrice.Caption = rsLang("LanguageLayoutLnk_Description"): frmStockMultiPrice.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblHeading = No Code           [Using the "Stock Item Selector"...]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblHeading.Caption = rsLang("LanguageLayoutLnk_Description"): lblHeading.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_0 = No Label              [For which Sale Channel]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_1 = No Label              [And for what Quantity]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

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
			//UPGRADE_ISSUE: Form property frmStockMultiPrice.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void myfmt_UnFormat(StdFormat.StdDataValue DataValue)
		{
			var _with1 = DataValue;
			if (Information.IsNumeric(_with1.value)) {
				if (Strings.InStr(_with1.value, ".")) {
					_with1.value = Strings.FormatNumber(_with1.value, 2);
				} else {
					_with1.value = Strings.FormatNumber(_with1.value / 100, 2);
				}
			}
		}

		private void adoPrimaryRS_FieldChangeComplete(int cFields, object Fields, ADODB.Error pError, ref ADODB.EventStatusEnum adStatus, ADODB.Recordset pRecordset)
		{
			string sql = null;
			sql = "DELETE From PriceChannelLnk WHERE (((PriceChannelLnk.PriceChannelLnk_StockItemID)=" + adoPrimaryRS.Fields("CatalogueChannelLnk_StockItemID").Value + ") AND ((PriceChannelLnk.PriceChannelLnk_Quantity)=" + adoPrimaryRS.Fields("CatalogueChannelLnk_Quantity").Value + ") AND ((PriceChannelLnk.PriceChannelLnk_ChannelID)=" + adoPrimaryRS.Fields("CatalogueChannelLnk_ChannelID").Value + "));";
			modRecordSet.cnnDB.Execute(sql);


			sql = "INSERT INTO PriceChannelLnk ( PriceChannelLnk_StockItemID, PriceChannelLnk_Quantity, PriceChannelLnk_ChannelID, PriceChannelLnk_Price ) SELECT CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, " + pRecordset.Fields("CatalogueChannelLnk_Price").Value + " AS Price From CatalogueChannelLnk WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)=" + pRecordset.Fields("CatalogueChannelLnk_StockItemID").Value + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)=" + pRecordset.Fields("CatalogueChannelLnk_Quantity").Value + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=" + pRecordset.Fields("CatalogueChannelLnk_ChannelID").Value + ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_PriceSystem)<>" + pRecordset.Fields("CatalogueChannelLnk_Price").Value + "));";

			modRecordSet.cnnDB.Execute(sql);
		}

		//Handles cmbChannel.Change
		private void cmbChannel_Change(System.Object eventSender, System.EventArgs eventArgs)
		{
			getNamespace();
		}

		private void cmbShrink_ClickEvent(System.Object eventSender, ColumnClickEventArgs eventArgs)
		{
			getNamespace();
		}

		private void cmdFilter_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmFilter.loadFilter(ref gFilter);
			getNamespace();
		}

		private void getNamespace()
		{
			if (string.IsNullOrEmpty(cmbShrink.BoundText) | string.IsNullOrEmpty(cmbChannel.BoundText))
				return;
			string lString = null;
			lString = " CatalogueChannelLnk.CatalogueChannelLnk_Quantity=" + this.cmbShrink.BoundText + " AND CatalogueChannelLnk.CatalogueChannelLnk_ChannelID=" + this.cmbChannel.BoundText + " AND StockItem.StockItem_Disabled=0 AND StockItem.StockItem_Discontinued=0 ";
			if (string.IsNullOrEmpty(gFilter)) {
				this.lblHeading.Text = "";
			} else {
				My.MyProject.Forms.frmFilter.buildCriteria(ref gFilter);
				this.lblHeading.Text = My.MyProject.Forms.frmFilter.gHeading;
			}
			gFilterSQL = My.MyProject.Forms.frmFilter.gCriteria;
			if (string.IsNullOrEmpty(gFilterSQL)) {
				lString = " WHERE " + lString;
			} else {
				lString = gFilterSQL + " AND " + lString;
			}
			//    If gFilterSQL = "" Then
			//        lString = " WHERE StockItem.StockItem_Disabled=0 AND StockItem.StockItem_Discontinued=0 "
			//    Else
			//        lString = gFilterSQL & " AND StockItem.StockItem_Disabled=0 AND StockItem.StockItem_Discontinued=0 "
			//    End If

			adoPrimaryRS = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID FROM (Catalogue INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID) INNER JOIN CatalogueChannelLnk ON (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) " + lString + " ORDER BY StockItem.StockItem_Name;");

			//Display the list of Titles in the DataCombo
			grdDataGrid.DataSource = adoPrimaryRS;
			grdDataGrid.Columns[0].HeaderText = "Stock Name";
			grdDataGrid.Columns[0].DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft;
			grdDataGrid.Columns[0].Frozen = true;

			grdDataGrid.Columns[1].HeaderText = "Price";
			grdDataGrid.Columns[1].DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgRight;
			grdDataGrid.Columns[1].Width = sizeConvertors.twipsToPixels(900, true);
			grdDataGrid.Columns[1].DefaultCellStyle.Format = (StdFormat.StdDataFormat)myfmt;
			//grdDataGrid.Columns(1).NumberFormat = "#,##0.00"

			grdDataGrid.Columns[2].Visible = false;
			grdDataGrid.Columns[3].Visible = false;
			grdDataGrid.Columns[4].Visible = false;

			frmStockMultiPrice_Resize(this, new System.EventArgs());
			mbDataChanged = false;

		}



		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = default(CrystalDecisions.CrystalReports.Engine.ReportDocument);
			Report.Load("cryStockItemPrice.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();
			Report.SetParameterValue("txtFilter", lblHeading.Text);
			Report.SetParameterValue("txtTitle1", "Where Sales Channel = " + cmbChannel.CtlText);

			//Report.Database.SetDataSource(adoPrimaryRS, 3)
			Report.Database.Tables(1).SetDataSource(adoPrimaryRS);
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		private void buildDataControls()
		{
			doDataControl(ref (this.cmbChannel), ref "SELECT ChannelID, Channel_Name FROM Channel WHERE ChannelID <> 9 ORDER BY ChannelID", ref "ChannelID", ref "Channel_Name");
			doDataControl(ref (this.cmbShrink), ref "SELECT DISTINCT ShrinkItem.ShrinkItem_Quantity From ShrinkItem ORDER BY ShrinkItem.ShrinkItem_Quantity;", ref "ShrinkItem_Quantity", ref "ShrinkItem_Quantity");
			cmbChannel.BoundText = Convert.ToString(1);
			cmbShrink.BoundText = Convert.ToString(1);
		}

		private void doDataControl(ref myDataGridView dataControl, ref string sql, ref string boundColumn, ref string listField)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref sql);
			//UPGRADE_WARNING: Couldn't resolve default property of object dataControl.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dataControl.DataSource = rs;
			//UPGRADE_WARNING: Couldn't resolve default property of object dataControl.boundColumn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dataControl.boundColumn = boundColumn;
			//UPGRADE_WARNING: Couldn't resolve default property of object dataControl.listField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dataControl.listField = listField;
		}

		private void frmStockMultiPrice_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			myfmt = new StdFormat.StdDataFormat();
			myfmt.Type = StdFormat.FormatType.fmtCustom;
			buildDataControls();
			gFilter = "stockitem";
			getNamespace();
			mbDataChanged = false;

			loadLanguage();
		}

		public void changePrice(ref int mainID)
		{
			myfmt = new StdFormat.StdDataFormat();
			myfmt.Type = StdFormat.FormatType.fmtCustom;
			buildDataControls();
			gFilter = "stockitem";

			mbDataChanged = false;

			cmbChannel.BoundText = Convert.ToString(6);
			cmbChannel.Enabled = false;
			cmdFilter.Enabled = false;
			cmbShrink.Enabled = false;

			getNamespaceCP(ref mainID);

			loadLanguage();
			ShowDialog();
		}

//UPGRADE_NOTE: mID was upgraded to mID_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private void getNamespaceCP(ref int mID_Renamed)
		{
			object sql = null;
			if (string.IsNullOrEmpty(cmbShrink.BoundText) | string.IsNullOrEmpty(cmbChannel.BoundText))
				return;
			string lString = null;
			lString = " CatalogueChannelLnk.CatalogueChannelLnk_Quantity=" + this.cmbShrink.BoundText + " AND CatalogueChannelLnk.CatalogueChannelLnk_ChannelID=" + this.cmbChannel.BoundText + " AND StockItem.StockItem_Disabled=0 AND StockItem.StockItem_Discontinued=0 ";
			if (string.IsNullOrEmpty(gFilter)) {
				this.lblHeading.Text = "";
			} else {
				My.MyProject.Forms.frmFilter.buildCriteria(ref gFilter);
				this.lblHeading.Text = My.MyProject.Forms.frmFilter.gHeading;
			}
			gFilterSQL = My.MyProject.Forms.frmFilter.gCriteria;
			if (string.IsNullOrEmpty(gFilterSQL)) {
				lString = " WHERE " + lString;
			} else {
				lString = gFilterSQL + " AND " + lString;
			}
			//    If gFilterSQL = "" Then
			//        lString = " WHERE StockItem.StockItem_Disabled=0 AND StockItem.StockItem_Discontinued=0 "
			//    Else
			//        lString = gFilterSQL & " AND StockItem.StockItem_Disabled=0 AND StockItem.StockItem_Discontinued=0 "
			//    End If
			//UPGRADE_WARNING: Couldn't resolve default property of object sql. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			sql = "SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID FROM (Catalogue INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID) INNER JOIN CatalogueChannelLnk ON (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) " + lString + " ORDER BY StockItem.StockItem_Name;";
			Debug.Print(sql);
			//UPGRADE_WARNING: Couldn't resolve default property of object sql. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			sql = "SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID FROM RecipeStockitemLnk INNER JOIN ((Catalogue INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID) INNER JOIN CatalogueChannelLnk ON Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) ON RecipeStockitemLnk.RecipeStockitemLnk_StockitemID = StockItem.StockItemID Where (((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 6) And ((RecipeStockitemLnk.RecipeStockitemLnk_RecipeID) = " + mID_Renamed + ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;";
			adoPrimaryRS = modRecordSet.getRS(ref sql);

			//Display the list of Titles in the DataCombo
			grdDataGrid.DataSource = adoPrimaryRS;
			grdDataGrid.Columns[0].HeaderText = "Stock Name";
			grdDataGrid.Columns[0].DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft;
			grdDataGrid.Columns[0].Frozen = true;

			grdDataGrid.Columns[1].HeaderText = "Price";
			grdDataGrid.Columns[1].DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgRight;
			grdDataGrid.Columns[1].Width = sizeConvertors.twipsToPixels(900, true);
			grdDataGrid.Columns[1].DefaultCellStyle.Format = myfmt;
			//grdDataGrid.Columns(1).NumberFormat = "#,##0.00"

			grdDataGrid.Columns[2].Visible = false;
			grdDataGrid.Columns[3].Visible = false;
			grdDataGrid.Columns[4].Visible = false;

			frmStockMultiPrice_Resize(this, new System.EventArgs());
			mbDataChanged = false;

		}

		private void frmStockMultiPrice_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

//UPGRADE_WARNING: Event frmStockMultiPrice.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void frmStockMultiPrice_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			//This will resize the grid when the form is resized
			System.Windows.Forms.Application.DoEvents();
			grdDataGrid.Height = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(this.ClientRectangle.Height, false) - 30 - sizeConvertors.pixelToTwips(picButtons.Height, false), false);
			grdDataGrid.Columns[0].Width = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(grdDataGrid.Width, true) - 900 - 580, true);

		}

		private void frmStockMultiPrice_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
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

			//bCancel = True
			//  adStatus = adStatusCantDeny
		}

		private void cmdCancel_Click()
		{
			 // ERROR: Not supported in C#: OnErrorStatement


			mbEditFlag = false;
			mbAddNewFlag = false;
			adoPrimaryRS.CancelUpdate();
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


		private void grdDataGrid_CellValueChanged(System.Object eventSender, DataGridViewCellEventArgs eventArgs)
		{
			//    If grdDataGrid.Columns(ColIndex).DataFormat.Format = "#,##0.00" Then
			//       grdDataGrid.Columns(ColIndex).DataFormat = 0
			//    End If

		}
	}
}
