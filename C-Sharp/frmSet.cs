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
	internal partial class frmSet : System.Windows.Forms.Form
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

		int gID;

		int isNewRec;
		List<TextBox> txtFields = new List<TextBox>();
		List<TextBox> txtFloat = new List<TextBox>();
		List<TextBox> txtInteger = new List<TextBox>();
		List<CheckBox> chkFields = new List<CheckBox>();
		List<Label> lblCG = new List<Label>();

		private void loadLanguage()
		{

			//frmSet = No Code   [Edit Stock Set Details]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmSet.Caption = rsLang("LanguageLayoutLnk_Description"): frmSet.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1100;
			//Emulate Pricing|Checked
			if (modRecordSet.rsLang.RecordCount){cmdEmulate.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdEmulate.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1101;
			//Allocate Stock Items|Checked
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

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1105;
			//Set Name|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1013;
			//Deposit|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_11.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_11.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1107;
			//Number of Units in the Set|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1108;
			//Disable this Set|Checked
			if (modRecordSet.rsLang.RecordCount){_chkFields_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_chkFields_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1109;
			//Pricing Per Sale Channel|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1110;
			//This Stock Set is locked to the following Stock Item|Checked
			if (modRecordSet.rsLang.RecordCount){chkStockItem.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;chkStockItem.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lblStockitem = No Code/Dynamic!
			//lblCG(0) = Dynamic
			//lblCG(1) = Dynamic
			//lblCG(2) = Dynamic
			//lblCG(3) = Dynamic
			//lblCG(4) = Dynamic
			//lblCG(5) = Dynamic
			//lblCG(6) = Dynamic
			//lblCG(7) = Dynamic
			//lblCG(8) = Dynamic

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmSet.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void buildDataControls()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			//doDataControl Me.cmbDeposit, "SELECT DepositID, Deposit_Name FROM Deposit WHERE ((LEFT((Deposit.Deposit_Name),3)<>'Non')) ORDER BY Deposit_Name", "Set_DepositID", "DepositID", "Deposit_Name"
			doDataControl(ref (this.cmbDeposit), ref "SELECT DepositID, Deposit_Name FROM Deposit WHERE ((Deposit.Deposit_Disabled) <> True) ORDER BY Deposit_Name", ref "Set_DepositID", ref "DepositID", ref "Deposit_Name");
			if (adoPrimaryRS.Fields("Set_StockitemID").Value > 0) {
				chkStockItem.Tag = adoPrimaryRS.Fields("Set_StockitemID").Value;
				chkStockItem.CheckState = System.Windows.Forms.CheckState.Checked;
				chkStockItem.Tag = "";
				//        Set rs = getRS("SELECT * FROM StockItem WHERE StockItemID=" & adoPrimaryRS("Set_StockitemID"))
				//        If rs.RecordCount Then
				//            lblStockItem.Caption = rs("StockItem_Name")
				//        End If

			}
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
			TextBox oText = new TextBox();
			CheckBox oCheck = new CheckBox();
			 // ERROR: Not supported in C#: OnErrorStatement


			isNewRec = id;
			if (id) {
				adoPrimaryRS = modRecordSet.getRS(ref "select * from [Set] WHERE SetID = " + id);
			} else {
				adoPrimaryRS = modRecordSet.getRS(ref "select * from [Set]");
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
			foreach (TextBox oText_loopVariable in txtInteger) {
				oText = oText_loopVariable;
				oText.DataBindings.Add(adoPrimaryRS);
				oText.Leave += txtInteger_Leave;
			}
			foreach (TextBox oText_loopVariable in txtFloat) {
				oText = oText_loopVariable;
				oText.DataBindings.Add(adoPrimaryRS);
				if (string.IsNullOrEmpty(oText.Text))
					oText.Text = "0";
				oText.Text = Convert.ToString(Convert.ToDouble(oText.Text) * 100);
				oText.Leave += txtFloat_Leave;
			}
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
			buildDataControls();
			mbDataChanged = false;
			setup();

			loadLanguage();
			ShowDialog();
		}

		private void setup()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			short x = 0;
			rs = modRecordSet.getRS(ref "SELECT Channel_Code FROM Channel ORDER BY ChannelID");
			rs.MoveFirst();
			for (x = 0; x <= 7; x++) {
				this.lblCG[x].Text = rs.Fields("Channel_Code").Value + ":";
				rs.moveNext();
			}

		}

		private void chkStockItem_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			int lID = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			if (chkStockItem.CheckState) {
				for (lID = 0; lID <= 7; lID++) {
					this.txtFloat[lID].Enabled = false;
					this.txtFloat[lID].Text = "0.00";
				}
				if (!string.IsNullOrEmpty(chkStockItem.Tag)) {
					lID = Convert.ToInt32(chkStockItem.Tag);
				} else {
					lID = My.MyProject.Forms.frmStockList.getItem();
				}
				if (lID == 0) {
					chkStockItem.CheckState = System.Windows.Forms.CheckState.Unchecked;
				} else {
					this._txtFields_1.Text = Convert.ToString(lID);
					rs = modRecordSet.getRS(ref "SELECT * FROM StockItem WHERE StockItemID=" + lID);
					if (rs.RecordCount) {
						lblStockitem.Text = rs.Fields("StockItem_Name").Value;
						rs.Close();
						rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_DepositID, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM CatalogueChannelLnk INNER JOIN StockItem ON CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = StockItem.StockItemID WHERE (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = " + lID + ") AND (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = " + this._txtInteger_0.Text + ") AND CatalogueChannelLnk.CatalogueChannelLnk_ChannelID <> 9");
						while (!(rs.EOF)) {
							txtFloat[rs.Fields("CatalogueChannelLnk_ChannelID").Value - 1].Text = Convert.ToString(rs.Fields("CatalogueChannelLnk_Price").Value * 100);
							txtFloat_Leave(txtFloat[rs.Fields("CatalogueChannelLnk_ChannelID").Value - 1], new System.EventArgs());
							rs.moveNext();
						}
					}

				}

			} else {
				this._txtFields_1.Text = Convert.ToString(0);
				lblStockitem.Text = "[No Stock Item ...]";
				this._txtFloat_0.Enabled = true;
				this._txtFloat_1.Enabled = true;
				this._txtFloat_2.Enabled = true;
				this.txtFloat[3].Enabled = true;
				this.txtFloat[4].Enabled = true;
				this.txtFloat[5].Enabled = true;
				this.txtFloat[6].Enabled = true;
				this.txtFloat[7].Enabled = true;
			}
		}

		private void cmbDeposit_KeyDown(System.Object eventSender, KeyEventArgs eventArgs)
		{
			if (mbEditFlag | mbAddNewFlag)
				return;
			if (eventArgs.KeyCode == 27) {
				//eventArgs.KeyChar = ChrW(0)
				adoPrimaryRS.Move(0);
				cmdClose_Click(cmdClose, new System.EventArgs());
			}

		}

		private void cmdAllocate_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (Information.IsDBNull(adoPrimaryRS.Fields("SetID").Value)) {
				if (update_Renamed()) {
				} else {
					return;
				}
			}

			My.MyProject.Forms.frmSetItem.loadItem(ref adoPrimaryRS.Fields("SetID").Value);
		}

		private void cmdEmulate_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int lID = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			if (_txtInteger_0.Text == "0") {
				Interaction.MsgBox("Insert the Set quantity first", MsgBoxStyle.Exclamation, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				_txtInteger_0.Focus();
				return;
			}

			lID = My.MyProject.Forms.frmStockList.getItem();
			if (lID != 0) {
				rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_DepositID, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM CatalogueChannelLnk INNER JOIN StockItem ON CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = StockItem.StockItemID WHERE (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = " + lID + ") AND (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = " + this._txtInteger_0.Text + ") AND CatalogueChannelLnk.CatalogueChannelLnk_ChannelID <> 9");
				if (rs.BOF | rs.EOF) {
					Interaction.MsgBox("Set quantity no found!", MsgBoxStyle.Exclamation, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				} else {
					while (!(rs.EOF)) {
						txtFloat[rs.Fields("CatalogueChannelLnk_ChannelID").Value - 1].Text = Convert.ToString(rs.Fields("CatalogueChannelLnk_Price").Value * 100);
						txtFloat_Leave(txtFloat[rs.Fields("CatalogueChannelLnk_ChannelID").Value - 1], new System.EventArgs());

						rs.moveNext();
					}
				}

			}

		}


		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modApplication.report_Sets();
		}

		private void frmSet_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
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

		private void frmSet_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			Button cmdLast = new Button();
			Button cmdNext = new Button();
			Label lblStatus = new Label();
			 // ERROR: Not supported in C#: OnErrorStatement

			lblStatus.Width = sizeConvertors.pixelToTwips(this.Width, true) - 1500;
			cmdNext.Left = lblStatus.Width + 700;
			cmdLast.Left = cmdNext.Left + 340;
		}



		private void frmSet_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
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

				foreach (TextBox oText_loopVariable in this.txtInteger) {
					oText = oText_loopVariable;
					oText.Leave += txtInteger_Leave;
				}
				foreach (TextBox oText_loopVariable in this.txtFloat) {
					oText = oText_loopVariable;
					if (string.IsNullOrEmpty(oText.Text))
						oText.Text = "0";
					oText.Text = oText.Text * 100;
					oText.Leave += txtFloat_Leave;
				}
				mbDataChanged = false;
			}
		}

		private bool update_Renamed()
		{
			bool functionReturnValue = false;
			 // ERROR: Not supported in C#: OnErrorStatement

			functionReturnValue = true;
			adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll);
			//    adoPrimaryRS.save
			if (mbAddNewFlag) {
				adoPrimaryRS.MoveLast();
				//move to the new record
			} else {
				adoPrimaryRS.Move(0);
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
			cmdClose.Focus();
			System.Windows.Forms.Application.DoEvents();

			if (string.IsNullOrEmpty(cmbDeposit.BoundText)) {
				Interaction.MsgBox("Please choose deposit!!", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				cmbDeposit.Focus();
				return;
			}

			if (isNewRec) {
				rs = modRecordSet.getRS(ref "Select * FROM [Set] WHERE Set_DepositID = " + cmbDeposit.BoundText + " AND SetID <> " + isNewRec + ";");
				if (rs.RecordCount > 0) {
					Interaction.MsgBox("Deposit already being used, Please choose different deposit!!", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					cmbDeposit.Focus();
					return;
				}
			} else {
				//New set being added
				//if new add validation
				rs = modRecordSet.getRS(ref "Select * FROM [Set] WHERE Set_DepositID = " + cmbDeposit.BoundText + ";");
				if (rs.RecordCount > 0) {
					Interaction.MsgBox("Deposit already being used, Please choose different deposit!!", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					cmbDeposit.Focus();
					return;
				}
				//exit sub
			}

			if (update_Renamed()) {
				this.Close();
			}
		}

		//Handles txtFields.Enter
		private void txtFields_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txt = new TextBox();
			txt = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txt, ref txtFields);
			modUtilities.MyGotFocus(ref txtFields[Index]);
		}

		private void txtInteger_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txt = new TextBox();
			txt = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txt, ref txtInteger);
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
			TextBox txt = new TextBox();
			txt = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txt, ref txtInteger);
			modUtilities.MyLostFocus(ref txtInteger[Index], ref 0);
		}

		//Handles txtFloat.Enter
		private void txtFloat_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txt = new TextBox();
			txt = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txt, ref txtFloat);
			modUtilities.MyGotFocusNumeric(ref txtFloat[Index]);
		}

		//Handles txtFloat.KeyPress
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

		//Handles txtFloat.Leave
		private void txtFloat_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txt = new TextBox();
			txt = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txt, ref txtFloat);
			modUtilities.MyLostFocus(ref txtFloat[Index], ref 2);
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

		private void frmSet_Load(object sender, System.EventArgs e)
		{
			chkFields.AddRange(new CheckBox[] { _chkFields_2 });
			txtFields.AddRange(new TextBox[] {
				_txtFields_0,
				_txtFields_1
			});
			txtFloat.AddRange(new TextBox[] {
				_txtFloat_0,
				_txtFloat_1,
				_txtFloat_2,
				_txtFloat_3,
				_txtFloat_4,
				_txtFloat_5,
				_txtFloat_6,
				_txtFloat_7
			});
			lblCG.AddRange(new Label[] {
				_lblCG_0,
				_lblCG_1,
				_lblCG_2,
				_lblCG_3,
				_lblCG_4,
				_lblCG_5,
				_lblCG_6,
				_lblCG_7
			});
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
		}
	}
}
