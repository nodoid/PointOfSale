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
	internal partial class frmPriceList : System.Windows.Forms.Form
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
		List<TextBox> txtFields = new List<TextBox>();
		List<CheckBox> chkFields = new List<CheckBox>();
		int gID;

		private void loadLanguage()
		{

			//frmPriceList = No Code     [Edit Price List]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmPriceList.Caption = rsLang("LanguageLayoutLnk_Description"): frmPriceList.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1188;
			//Allocate|Checked
			if (modRecordSet.rsLang.RecordCount){cmdAllocate.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdAllocate.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1085;
			//Print|Checked
			if (modRecordSet.rsLang.RecordCount){cmdPrint.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPrint.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1010;
			//General|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_5.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_5.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1192;
			//Price List Name|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_38.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_38.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1193;
			//COD Channel Name|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1194;
			//Delivery Channel Name|Checked
			if (modRecordSet.rsLang.RecordCount){chkChannel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;chkChannel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2463;
			//Disabled|Checked
			if (modRecordSet.rsLang.RecordCount){_chkFields_12.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_chkFields_12.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmPriceList.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void buildDataControls()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "SELECT * FROM Channel ORDER BY ChannelID");
			cmbCOD.Items.Clear();
			cmbDelivery.Items.Clear();
			int x = 0;
			while (!(rs.EOF)) {
				x = cmbCOD.Items.Add(new LBI(rs.Fields("Channel_Name").Value, rs.Fields("ChannelID").Value));
				if (adoPrimaryRS.Fields("Pricelist_CODChannelID").Value == rs.Fields("ChannelID").Value) {
					cmbCOD.SelectedIndex = x;
				}
				cmbDelivery.Items.Add(new LBI(rs.Fields("Channel_Name").Value, rs.Fields("ChannelID").Value));
				if (adoPrimaryRS.Fields("Pricelist_DeliveryChannelID").Value == rs.Fields("ChannelID").Value) {
					cmbDelivery.SelectedIndex = x;
				}
				rs.moveNext();

			}


			//    doDataControl Me.cmbChannel, "SELECT ChannelID, Channel_Name FROM Channel ORDER BY ChannelID", "Customer_ChannelID", "ChannelID", "Channel_Name"
		}

		private void doDataControl(ref System.Windows.Forms.Control dataControl, ref string sql, ref string DataField, ref string boundColumn, ref string listField)
		{
			//Dim rs As ADODB.Recordset
			//rs = getRS(sql)
			//UPGRADE_WARNING: Couldn't resolve default property of object dataControl.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//dataControl.DataSource = rs
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
				adoPrimaryRS = modRecordSet.getRS(ref "select * from Pricelist WHERE PricelistID = " + id);
			} else {
				adoPrimaryRS = modRecordSet.getRS(ref "select * from Pricelist");
				adoPrimaryRS.AddNew();
				this.Text = this.Text + " [New record]";
				mbAddNewFlag = true;
			}
			setup();
			foreach (TextBox oText_loopVariable in txtFields) {
				oText = oText_loopVariable;
				oText.DataBindings.Add(adoPrimaryRS);
				oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize;
			}
			//    For Each oText In Me.txtInteger
			//        Set oText.DataBindings.Add(adoPrimaryRS)
			//        txtInteger_LostFocus oText.Index
			//    Next
			//    For Each oText In Me.txtFloat
			//        Set oText.DataBindings.Add(adoPrimaryRS)
			//        If oText.Text = "" Then oText.Text = "0"
			//        oText.Text = oText.Text * 100
			//        txtFloat_LostFocus oText.Index
			//    Next
			//    For Each oText In Me.txtFloatNegative
			//        Set oText.DataBindings.Add(adoPrimaryRS)
			//        If oText.Text = "" Then oText.Text = "0"
			//        oText.Text = oText.Text * 100
			//        txtFloatNegative_LostFocus oText.Index
			//    Next
			//Bind the check boxes to the data provider
			foreach (CheckBox oCheck_loopVariable in chkFields) {
				oCheck = oCheck_loopVariable;
				oCheck.DataBindings.Add(adoPrimaryRS);
			}
			buildDataControls();
			mbDataChanged = false;
			if (this.cmbDelivery.SelectedIndex == -1) {
				chkChannel.CheckState = System.Windows.Forms.CheckState.Unchecked;
				cmbDelivery.Enabled = false;
			} else {
				chkChannel.CheckState = System.Windows.Forms.CheckState.Checked;
				cmbDelivery.Enabled = true;
			}

			loadLanguage();
			ShowDialog();
		}

		private void setup()
		{
		}

//UPGRADE_WARNING: Event chkChannel.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void chkChannel_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmbDelivery.Enabled = (chkChannel.CheckState);

		}

		private void cmdAllocate_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (update_Renamed()) {
				My.MyProject.Forms.frmPricelistItem.loadItem(ref adoPrimaryRS.Fields("PricelistID").Value);
			}
		}

		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsCompany = default(ADODB.Recordset);
			string sql = null;
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = default(CrystalDecisions.CrystalReports.Engine.ReportDocument);
			update_Renamed();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rsCompany = modRecordSet.getRS(ref "SELECT * FROM Company");
			if (this.chkChannel.CheckState) {
				Report.Load("cryPriceList.rpt");

				sql = "SELECT Pricelist.Pricelist_Name, StockItem.StockItem_Name, Max(codCase.CatalogueChannelLnk_Price) AS codCase, Max(codCase.CatalogueChannelLnk_Quantity) AS codQuantity, codSingle.CatalogueChannelLnk_Price AS codSingle, Max(deliveryCase.CatalogueChannelLnk_Quantity) AS delQuantity, Max(deliveryCase.CatalogueChannelLnk_Price) AS delCase, deliverySingle.CatalogueChannelLnk_Price AS delSingle";
				sql = sql + " FROM ShrinkItem INNER JOIN";
				sql = sql + " (CatalogueChannelLnk AS deliverySingle INNER JOIN (CatalogueChannelLnk AS deliveryCase INNER JOIN ((CatalogueChannelLnk AS codCase INNER JOIN (StockItem INNER JOIN (PricelistStockItemLnk INNER JOIN Pricelist ON PricelistStockItemLnk.PricelistStockitemLnk_PricelistID = Pricelist.PricelistID) ON StockItem.StockItemID = PricelistStockItemLnk.PricelistStockitemLnk_StockitemID) ON (codCase.CatalogueChannelLnk_ChannelID = Pricelist.Pricelist_CODChannelID) AND (codCase.CatalogueChannelLnk_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk AS codSingle ON (StockItem.StockItemID = codSingle.CatalogueChannelLnk_StockItemID) AND (Pricelist.Pricelist_CODChannelID = codSingle.CatalogueChannelLnk_ChannelID)) ON (deliveryCase.CatalogueChannelLnk_StockItemID = StockItem.StockItemID) AND (deliveryCase.CatalogueChannelLnk_ChannelID = Pricelist.Pricelist_DeliveryChannelID)) ON (deliverySingle.CatalogueChannelLnk_ChannelID = Pricelist.Pricelist_DeliveryChannelID)";
				sql = sql + " AND (deliverySingle.CatalogueChannelLnk_StockItemID = StockItem.StockItemID)) ON (ShrinkItem.ShrinkItem_Quantity = codCase.CatalogueChannelLnk_Quantity) AND (ShrinkItem.ShrinkItem_Quantity = deliveryCase.CatalogueChannelLnk_Quantity) AND (ShrinkItem.ShrinkItem_ShrinkID = StockItem.StockItem_ShrinkID)";
				sql = sql + " Where (((codSingle.CatalogueChannelLnk_Quantity) = 1) And ((Pricelist.Pricelist_Disabled) = 0) And ((deliverySingle.CatalogueChannelLnk_Quantity) = 1))";
				sql = sql + " GROUP BY Pricelist.Pricelist_Name, StockItem.StockItem_Name, codSingle.CatalogueChannelLnk_Price, deliverySingle.CatalogueChannelLnk_Price";
				sql = sql + " ORDER BY Pricelist.Pricelist_Name, StockItem.StockItem_Name;";
			} else {
				Report.Load("cryPriceListSingle.rpt");
				sql = "SELECT Pricelist.Pricelist_Name, StockItem.StockItem_Name, Max(codCase.CatalogueChannelLnk_Price) AS codCase, Max(codCase.CatalogueChannelLnk_Quantity) AS codQuantity, codSingle.CatalogueChannelLnk_Price AS codSingle, StockItem.StockItemID ";
				sql = sql + "FROM ((CatalogueChannelLnk AS codCase INNER JOIN (StockItem INNER JOIN (PricelistStockItemLnk INNER JOIN Pricelist ON PricelistStockItemLnk.PricelistStockitemLnk_PricelistID = Pricelist.PricelistID) ON StockItem.StockItemID = PricelistStockItemLnk.PricelistStockitemLnk_StockitemID) ON (codCase.CatalogueChannelLnk_StockItemID = StockItem.StockItemID) AND (codCase.CatalogueChannelLnk_ChannelID = Pricelist.Pricelist_CODChannelID)) INNER JOIN CatalogueChannelLnk AS codSingle ON (Pricelist.Pricelist_CODChannelID = codSingle.CatalogueChannelLnk_ChannelID) AND (StockItem.StockItemID = codSingle.CatalogueChannelLnk_StockItemID)) INNER JOIN ShrinkItem ON (ShrinkItem.ShrinkItem_Quantity = codCase.CatalogueChannelLnk_Quantity) AND (StockItem.StockItem_ShrinkID = ShrinkItem.ShrinkItem_ShrinkID) ";
				sql = sql + "Where (((codSingle.CatalogueChannelLnk_Quantity) = 1) And ((Pricelist.Pricelist_Disabled) = 0)) GROUP BY Pricelist.Pricelist_Name, StockItem.StockItem_Name, codSingle.CatalogueChannelLnk_Price, StockItem.StockItemID ORDER BY Pricelist.Pricelist_Name, StockItem.StockItem_Name;";
			}


			rs = modRecordSet.getRS(ref sql);
			if (rs.BOF | rs.EOF) {
				Interaction.MsgBox("No Price allocated!", MsgBoxStyle.Exclamation, "PRICE LIST");
				return;
			}

			if (this.chkChannel.CheckState) {
				Report.SetParameterValue("Text3", cmbCOD.Text);
				Report.SetParameterValue("Text4", cmbDelivery.Text);
			} else {
				Report.SetParameterValue("Text3", cmbCOD.Text);
			}

			Report.Database.Tables(1).SetDataSource(rs);
			Report.Database.Tables(2).SetDataSource(rsCompany);
			Report.SetParameterValue("txtCompanyName", rsCompany.Fields("Company_Name"));
			My.MyProject.Forms.frmReportShow.Text = "Price List";
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();

		}

//UPGRADE_WARNING: Event frmPriceList.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void frmPriceList_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			Button cmdLast = new Button();
			Button cmdNext = new Button();
			Label lblStatus = new Label();
			 // ERROR: Not supported in C#: OnErrorStatement

			lblStatus.Width = sizeConvertors.pixelToTwips(this.Width, true) - 1500;
			cmdNext.Left = lblStatus.Width + 700;
			cmdLast.Left = cmdNext.Left + 340;
		}

		private void frmPriceList_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (mbEditFlag | mbAddNewFlag)
				goto EventExitSub;

			switch (KeyAscii) {
				case System.Windows.Forms.Keys.Escape:
					KeyAscii = 0;
					adoPrimaryRS.Move(0);

					cmdClose.Focus();
					System.Windows.Forms.Application.DoEvents();
					cmdClose_Click(cmdClose, new System.EventArgs());
					break;
			}
			EventExitSub:
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmPriceList_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
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

			functionReturnValue = true;
			adoPrimaryRS.Fields("Pricelist_CODChannelID").Value = Convert.ToInt32(cmbCOD.SelectedIndex);
			if (chkChannel.CheckState) {
				adoPrimaryRS.Fields("Pricelist_DeliveryChannelID").Value = Convert.ToInt32(cmbDelivery.SelectedIndex);
			} else {
				adoPrimaryRS.Fields("Pricelist_DeliveryChannelID").Value = 0;
			}
			adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll);
			if (mbAddNewFlag) {
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
			cmdClose.Focus();
			System.Windows.Forms.Application.DoEvents();
			if (update_Renamed()) {
				this.Close();
			}
		}

		//Handles txtFields.Enter
		private void txtFields_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txtBox = new TextBox();
			txtBox = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txtBox, ref txtFields);
			modUtilities.MyGotFocus(ref txtFields[Index]);
		}

		private void txtInteger_MyGotFocus(ref short Index)
		{
			//    MyGotFocusNumeric txtInteger(Index)
		}

		private void txtInteger_KeyPress(ref short Index, ref short KeyAscii)
		{
			//    KeyPress KeyAscii
		}

		private void txtInteger_MyLostFocus(ref short Index)
		{
			//    LostFocus txtInteger(Index), 0
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
			//    MyGotFocusNumeric txtFloat(Index), 2
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

		private void frmPriceList_Load(object sender, System.EventArgs e)
		{
			txtFields.AddRange(new TextBox[] { _txtFields_0 });
			_txtFields_0.Enter += txtFields_Enter;
			chkFields.AddRange(new CheckBox[] { _chkFields_12 });
		}
	}
}
