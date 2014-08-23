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
	internal partial class frmPricelistFilter : System.Windows.Forms.Form
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
		bool mvBookMark;
		bool mbEditFlag;
		bool mbAddNewFlag;

		bool mbDataChanged;
		List<TextBox> txtFields = new List<TextBox>();

		List<CheckBox> chkFields = new List<CheckBox>();
		int gID;

		private void loadLanguage()
		{

			//frmPricelistFilter = No code   [Edit Price List Group]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmPricelistFilter.Caption = rsLang("LanguageLayoutLnk_Description"): frmPricelistFilter.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1101;
			//Allocate Stock Items|Checked
			if (modRecordSet.rsLang.RecordCount){cmdAllocate.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdAllocate.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1010;
			//General|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_5.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_5.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lblLabels(38) = No Code        [Price List Group Name]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblLabels(38).Caption = rsLang("LanguageLayoutLnk_Description"): lblLabels(38).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2463;
			//Disabled|Checked
			if (modRecordSet.rsLang.RecordCount){_chkFields_12.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_chkFields_12.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmPricelistFilter.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void buildDataControls()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "SELECT * FROM Channel ORDER BY ChannelID");
			cmbCOD.Items.Clear();
			cmbDelivery.Items.Clear();
			string tmpString = null;
			int m = 0;
			while (!(rs.EOF)) {
				tmpString = rs.Fields("Channel_Name").Value + " " + rs.Fields("ChannelID").Value;
				m = cmbCOD.Items.Add(tmpString);
				if (adoPrimaryRS.Fields("Pricelist_CODChannelID").Value == rs.Fields("ChannelID").Value) {
					cmbCOD.SelectedIndex = m;
				}
				tmpString = rs.Fields("Channel_Name").Value + " " + rs.Fields("ChannelID").Value;
				m = cmbDelivery.Items.Add(tmpString);
				if (adoPrimaryRS.Fields("Pricelist_DeliveryChannelID").Value == rs.Fields("ChannelID").Value) {
					cmbDelivery.SelectedIndex = m;
				}
				rs.MoveNext();

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
			//dataControl.DataBindings.Add(adoPrimaryRS)
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
				adoPrimaryRS = modRecordSet.getRS(ref "select * from PricelistFilter WHERE PricelistID = " + id);
			} else {
				adoPrimaryRS = modRecordSet.getRS(ref "select * from PricelistFilter");
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
			foreach (CheckBox oCheck_loopVariable in this.chkFields) {
				oCheck = oCheck_loopVariable;
				oCheck.DataBindings.Add(adoPrimaryRS);
			}
			//buildDataControls
			mbDataChanged = false;
			//If Me.cmbDelivery.ListIndex = -1 Then
			//    chkChannel.value = 0
			//    cmbDelivery.Enabled = False
			//Else
			//    chkChannel.value = 1
			//    cmbDelivery.Enabled = True
			//End If

			loadLanguage();
			ShowDialog();
		}

		private void setup()
		{
		}

		private void chkChannel_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmbDelivery.Enabled = (chkChannel.CheckState);

		}

		private void cmdAllocate_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (update_Renamed()) {
				My.MyProject.Forms.frmPricelistFilterItem.loadItem(ref adoPrimaryRS.Fields("PricelistID").Value);
			}
		}

		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsCompany = default(ADODB.Recordset);
			string sql = null;
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = default(CrystalDecisions.CrystalReports.Engine.ReportDocument);
			update_Renamed();
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
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
			Report.Database.Tables(1).SetDataSource(rs);
			Report.Database.Tables(2).SetDataSource(rsCompany);
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = "Price List";
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();

		}

		private void frmPricelistFilter_Load(object sender, System.EventArgs e)
		{
			txtFields.AddRange(new TextBox[] { _txtFields_0 });
			chkFields.AddRange(new CheckBox[] { _chkFields_12 });
		}

//UPGRADE_WARNING: Event frmPricelistFilter.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void frmPricelistFilter_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			Button cmdLast = new Button();
			Button cmdNext = new Button();
			Label lblStatus = new Label();
			 // ERROR: Not supported in C#: OnErrorStatement

			lblStatus.Width = sizeConvertors.pixelToTwips(this.Width, true) - 1500;
			cmdNext.Left = lblStatus.Width + 700;
			cmdLast.Left = cmdNext.Left + 340;
		}

		private void frmPricelistFilter_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void frmPricelistFilter_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
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

		private bool update_Renamed()
		{
			bool functionReturnValue = false;
			 // ERROR: Not supported in C#: OnErrorStatement

			functionReturnValue = true;
			//adoPrimaryRS("Pricelist_CODChannelID") = cmbCOD.ItemData(cmbCOD.ListIndex)
			//If chkChannel.value Then
			//    adoPrimaryRS("Pricelist_DeliveryChannelID") = cmbDelivery.ItemData(cmbDelivery.ListIndex)
			//Else
			//    adoPrimaryRS("Pricelist_DeliveryChannelID") = 0
			//End If
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

		private void txtFields_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			int Index = 0;
			TextBox n = new TextBox();
			n = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref n, ref txtFields);
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
	}
}
