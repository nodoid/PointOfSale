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
using CrystalDecisions;
namespace _4PosBackOffice.NET
{
	internal partial class frmIncrement : System.Windows.Forms.Form
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
		List<CheckBox> chkFields = new List<CheckBox>();
		List<TextBox> txtFields = new List<TextBox>();

		List<TextBox> txtInteger = new List<TextBox>();
		int gID;

		private void loadLanguage()
		{

			//frmIncrement = No Code     [Edit Increment Details]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmIncrement.Caption = rsLang("LanguageLayoutLnk_Description"): frmIncrement.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1085;
			//Print|Checked
			if (modRecordSet.rsLang.RecordCount){cmdPrint.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPrint.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1010;
			//General|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_5.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_5.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lblLabels(38) = No Code    [Increment Name]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblLabels(38).Caption = rsLang("LanguageLayoutLnk_Description"): lblLabels(38).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2145;
			//Shrink Size|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_9.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_9.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2463;
			//Disabled|Checked
			if (modRecordSet.rsLang.RecordCount){_chkFields_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_chkFields_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lbl_2 = No Code
			//NOTE: Caption Grammar incorrect!
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_chkFields_1 = No Code/Dynamic!
			//_chkFields_2 = No Code/Dynamic!
			//_chkFields_3 = No Code/Dynamic!
			//_chkFields_4 = No Code/Dynamic!
			//_chkFields_5 = No Code/Dynamic!
			//_chkFields_6 = No Code/Dynamic!
			//_chkFields_7 = No Code/Dynamic!
			//_chkFields_8 = No Code/Dynamic!
			//_chkFields_9 = No Code/Dynamic!

			//_lbl_0 = No Code           [Quantities and Price]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1147;
			//Add|Checked
			if (modRecordSet.rsLang.RecordCount){cmdAdd.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdAdd.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1148;
			//Delete|Checked
			if (modRecordSet.rsLang.RecordCount){cmdDelete.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdDelete.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lbl_1 = No Code           [Stock Items]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1147;
			//Add|Checked
			if (modRecordSet.rsLang.RecordCount){cmdAddStock.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdAddStock.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1148;
			//Delete|Checked
			if (modRecordSet.rsLang.RecordCount){cmdDelStock.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdDelStock.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
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
			//dataControl.DataSource = rs
			//dataControl.DataSource = adoPrimaryRS
			//dataControl.DataField = DataField
			//dataControl.boundColumn = boundColumn
			//dataControl.listField = listField
		}

		public void loadItem(ref int id)
		{
			System.Windows.Forms.TextBox oText = null;
			DateTimePicker oDate = new DateTimePicker();
			System.Windows.Forms.CheckBox oCheck = null;
			 // ERROR: Not supported in C#: OnErrorStatement


			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "SELECT * FROM Channel");
			while (!(rs.EOF)) {
				chkFields[rs.Fields("ChannelID").Value].Text = rs.Fields("ChannelID").Value + ". " + rs.Fields("Channel_Code").Value;
				rs.moveNext();
			}
			rs.Close();


			if (id) {
				adoPrimaryRS = modRecordSet.getRS(ref "select Increment.* from Increment WHERE IncrementID = " + id);
			} else {
				adoPrimaryRS = modRecordSet.getRS(ref "select * from Increment");
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
				//txtInteger_Leave(txtInteger.Item((oText.TabIndex)), New System.EventArgs())
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
			gID = id;
			if (gID) {
				loadItems();
			}

			loadLanguage();
			ShowDialog();
		}

		private void setup()
		{
		}

		private void cmdAdd_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			update_Renamed();
			My.MyProject.Forms.frmIncrementQuantity.loadItem(ref adoPrimaryRS.Fields("IncrementID").Value, ref 0);
			loadItems();
		}

		private void cmdAddStock_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int lID = 0;

			lID = My.MyProject.Forms.frmStockList.getItem();
			if (lID != 0) {
				modRecordSet.cnnDB.Execute("DELETE IncrementStockItemLnk.* From IncrementStockItemLnk WHERE (((IncrementStockItemLnk.IncrementStockItemLnk_IncrementID)=" + adoPrimaryRS.Fields("IncrementID").Value + ") AND ((IncrementStockItemLnk.IncrementStockItemLnk_StockItemID)=" + lID + "));");
				modRecordSet.cnnDB.Execute("INSERT INTO IncrementStockItemLnk ( IncrementStockItemLnk_IncrementID, IncrementStockItemLnk_StockItemID ) SELECT " + adoPrimaryRS.Fields("IncrementID").Value + ", " + lID + ";");
				loadItems();
			}

		}

		private void cmdDelete_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string lQty = null;
			int lID = 0;
			if (lvItem.FocusedItem == null) {
			} else {
				if (Interaction.MsgBox("Are you sure you wish to remove the " + lvItem.FocusedItem.Text + " quantity from this Increment?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "DELETE") == MsgBoxResult.Yes) {
					lID = Convert.ToInt32(Strings.Split(lvItem.FocusedItem.Name, "_")[0]);
					lQty = Strings.Split(lvItem.FocusedItem.Name, "_")[1];
					modRecordSet.cnnDB.Execute("DELETE IncrementQuantity.* From IncrementQuantity WHERE (((IncrementQuantity.IncrementQuantity_IncrementID)=" + lID + ") AND ((IncrementQuantity.IncrementQuantity_Quantity)=" + lQty + "));");
					loadItems();
				}
			}

		}

		private void cmdDelStock_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int lQty = 0;
			int lstock = 0;
			int lID = 0;
			if (lvItem.FocusedItem == null) {
			} else {
				if (Interaction.MsgBox("Are you sure you wish to remove '" + lvItem.FocusedItem.Text + "' from this Increment?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "DELETE") == MsgBoxResult.Yes) {
					lID = Convert.ToInt32(Strings.Split(lvItem.FocusedItem.Name, "_")[0]);
					lstock = Strings.Split(lvItem.FocusedItem.Name, "_")[1];
					modRecordSet.cnnDB.Execute("DELETE IncrementStockItemLnk.* From IncrementStockItemLnk WHERE (((IncrementStockItemLnk.IncrementStockItemLnk_IncrementID)=" + lID + ") AND ((IncrementStockItemLnk.IncrementStockItemLnk_StockItemID)=" + lstock + "));");

					modRecordSet.cnnDB.Execute("DELETE IncrementQuantity.* From IncrementQuantity WHERE (((IncrementQuantity.IncrementQuantity_IncrementID)=" + lID + ") AND ((IncrementQuantity.IncrementQuantity_Quantity)=" + lQty + "));");
					loadItems();
				}
			}

		}

		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			update_Renamed();
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsQty = default(ADODB.Recordset);
			ADODB.Recordset RSitem = default(ADODB.Recordset);
			bool ltype = false;
			//Dim Report As New cryIncrement
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryIncrement.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();

			rs = modRecordSet.getRS(ref "SELECT * FROM Channel ORDER BY ChannelID");
			while (!(rs.EOF)) {
				switch (rs.Fields("ChannelID").Value) {
					case 1:
						Report.SetParameterValue("txtCS1", rs.Fields("Channel_Code"));
						break;
					case 2:
						Report.SetParameterValue("txtCS2", rs.Fields("Channel_Code"));
						break;
					case 3:
						Report.SetParameterValue("txtCS3", rs.Fields("Channel_Code"));
						break;
					case 4:
						Report.SetParameterValue("txtCS4", rs.Fields("Channel_Code"));
						break;
					case 5:
						Report.SetParameterValue("txtCS5", rs.Fields("Channel_Code"));
						break;
					case 6:
						Report.SetParameterValue("txtCS6", rs.Fields("Channel_Code"));
						break;
					case 7:
						Report.SetParameterValue("txtCS7", rs.Fields("Channel_Code"));
						break;
					case 8:
						Report.SetParameterValue("txtCS8", rs.Fields("Channel_Code"));
						break;
				}
				rs.moveNext();
			}

			rs.Close();
			rs = modRecordSet.getRS(ref "SELECT Increment.* FROM Increment;");
			//ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryNoRecords.rpt");
			if (rs.BOF | rs.EOF) {
				ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString);
				ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString);
				My.MyProject.Forms.frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString;
				My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = ReportNone;
				My.MyProject.Forms.frmReportShow.mReport = ReportNone;
				My.MyProject.Forms.frmReportShow.sMode = "0";
				My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				My.MyProject.Forms.frmReportShow.ShowDialog();
				return;
			}
			rsQty = modRecordSet.getRS(ref "SELECT IncrementQuantity.* From IncrementQuantity ORDER BY IncrementQuantity.IncrementQuantity_Quantity;");
			RSitem = modRecordSet.getRS(ref "SELECT IncrementStockItemLnk.IncrementStockItemLnk_IncrementID, StockItem.StockItem_Name FROM IncrementStockItemLnk INNER JOIN StockItem ON IncrementStockItemLnk.IncrementStockItemLnk_StockItemID = StockItem.StockItemID ORDER BY StockItem.StockItem_Name;");

			Report.Database.Tables(1).SetDataSource(rs);
			Report.Database.Tables(2).SetDataSource(rsQty);
			Report.Database.Tables(3).SetDataSource(RSitem);
			//UPGRADE_WARNING: Couldn't resolve default property of object Report.VerifyOnEveryPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();

		}

		private void frmIncrement_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtFields.AddRange(new TextBox[] { _txtFields_0 });
			txtInteger.AddRange(new TextBox[] { _txtInteger_0 });
			chkFields.AddRange(new CheckBox[] {
				_chkFields_0,
				_chkFields_1,
				_chkFields_2,
				_chkFields_3,
				_chkFields_4,
				_chkFields_5,
				_chkFields_6,
				_chkFields_7,
				_chkFields_8,
				_chkFields_9
			});
			TextBox tb = new TextBox();
			CheckBox cb = new CheckBox();
			foreach (TextBox tb_loopVariable in txtFields) {
				tb = tb_loopVariable;
				tb.Enter += txtFields_Enter;
			}
			foreach (TextBox tb_loopVariable in txtInteger) {
				tb = tb_loopVariable;
				tb.Enter += txtInteger_Enter;
				tb.KeyPress += txtInteger_KeyPress;
				tb.Leave += txtInteger_Leave;
			}
			lvItem.Columns.Clear();
			lvItem.Columns.Add("", "QTY", Convert.ToInt32(sizeConvertors.twipsToPixels(750, true)));
			lvItem.Columns.Add("Price", Convert.ToInt32(sizeConvertors.twipsToPixels(1240, true)), System.Windows.Forms.HorizontalAlignment.Right);

			lvStockItem.Columns.Clear();
			lvStockItem.Columns.Add("", "Stock Item", Convert.ToInt32(sizeConvertors.twipsToPixels(2900, true)));
		}

		private void loadItems()
		{
			System.Windows.Forms.ListViewItem listItem = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			lvItem.Items.Clear();
			rs = modRecordSet.getRS(ref "SELECT IncrementQuantity.IncrementQuantity_IncrementID, IncrementQuantity.IncrementQuantity_Quantity, IncrementQuantity.IncrementQuantity_Price From IncrementQuantity Where (((IncrementQuantity.IncrementQuantity_IncrementID) = " + adoPrimaryRS.Fields("IncrementID").Value + ")) ORDER BY IncrementQuantity.IncrementQuantity_Quantity;");
			while (!(rs.EOF)) {
				listItem = lvItem.Items.Add(rs.Fields("IncrementQuantity_IncrementID").Value + "_" + rs.Fields("IncrementQuantity_Quantity").Value, rs.Fields("IncrementQuantity_Quantity").Value, "");
				if (listItem.SubItems.Count > 0) {
					listItem.SubItems[0].Text = Strings.FormatNumber(rs.Fields("IncrementQuantity_Price").Value, 1);
				} else {
					listItem.SubItems.Insert(0, new System.Windows.Forms.ListViewItem.ListViewSubItem(null, Strings.FormatNumber(rs.Fields("IncrementQuantity_Price").Value, 1)));
				}

				rs.moveNext();
			}

			lvStockItem.Items.Clear();
			rs = modRecordSet.getRS(ref "SELECT IncrementStockItemLnk.IncrementStockItemLnk_IncrementID, IncrementStockItemLnk.IncrementStockItemLnk_StockItemID, StockItem.StockItem_Name FROM IncrementStockItemLnk INNER JOIN StockItem ON IncrementStockItemLnk.IncrementStockItemLnk_StockItemID = StockItem.StockItemID Where (((IncrementStockItemLnk.IncrementStockItemLnk_IncrementID) = " + adoPrimaryRS.Fields("IncrementID").Value + ")) ORDER BY StockItem.StockItem_Name;");
			while (!(rs.EOF)) {
				listItem = lvStockItem.Items.Add(rs.Fields("IncrementStockItemLnk_IncrementID").Value + "_" + rs.Fields("IncrementStockItemLnk_StockItemID").Value, rs.Fields("StockItem_Name").Value, "");
				rs.moveNext();
			}

		}

		private void frmIncrement_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			System.Windows.Forms.Button cmdLast = new System.Windows.Forms.Button();
			System.Windows.Forms.Button cmdNext = new System.Windows.Forms.Button();
			System.Windows.Forms.Label lblStatus = new System.Windows.Forms.Label();
			 // ERROR: Not supported in C#: OnErrorStatement

			lblStatus.Width = sizeConvertors.pixelToTwips(this.Width, true) - 1500;
			cmdNext.Left = lblStatus.Width + 700;
			cmdLast.Left = cmdNext.Left + 340;
		}

		private void frmIncrement_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void frmIncrement_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
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
			if (mbAddNewFlag) {
				if (string.IsNullOrEmpty(this._txtFields_0.Text)) {
					functionReturnValue = true;
					return functionReturnValue;
				}
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

		private void lvItem_DoubleClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			int lID = 0;
			short lQty = 0;
			if (lvItem.FocusedItem == null) {
			} else {
				lID = Convert.ToInt32(Strings.Split(lvItem.FocusedItem.Name, "_")[0]);
				lQty = Convert.ToInt16(Strings.Split(lvItem.FocusedItem.Name, "_")[1]);

				My.MyProject.Forms.frmIncrementQuantity.loadItem(ref lID, ref Convert.ToInt16(lQty));
				loadItems();
			}
		}

		private void lvItem_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 13) {
				lvItem_DoubleClick(lvItem, new System.EventArgs());
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void txtFields_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim Index As Short = txtFields.GetIndex(eventSender)
			int Index = 0;
			TextBox m = new TextBox();
			TextBox n = new TextBox();
			n = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref n, ref txtFields);
			modUtilities.MyGotFocus(ref txtFields[Index]);
		}

		private void txtInteger_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim Index As Short = txtInteger.GetIndex(eventSender)
			int Index = 0;
			TextBox m = new TextBox();
			TextBox n = new TextBox();
			n = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref n, ref txtInteger);
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

		private void txtInteger_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim Index As Short = txtInteger.GetIndex(eventSender)
			int Index = 0;
			TextBox m = new TextBox();
			TextBox n = new TextBox();
			n = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref n, ref txtInteger);
			modUtilities.MyLostFocus(ref txtInteger[Index], ref 0);
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
