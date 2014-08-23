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
using VB = Microsoft.VisualBasic;
using Microsoft.VisualBasic.PowerPacks;
namespace _4PosBackOffice.NET
{
	internal partial class frmDeposit : System.Windows.Forms.Form
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


		decimal gVAT;
		List<TextBox> txtFields = new List<TextBox>();
		List<TextBox> txtFloat = new List<TextBox>();
		List<TextBox> txtHide = new List<TextBox>();
		List<TextBox> txtInteger = new List<TextBox>();
		List<CheckBox> chkFields = new List<CheckBox>();
		private void loadLanguage()
		{

			//NOTE: DB Entry 1083 has invalid text
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1083;
			//Edit Deposit Details
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

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

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1009;
			//Display Name|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_38.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_38.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1011;
			//Receipt Name|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1012;
			//POS Quick Key|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_4.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_4.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lblLabels_2 = No Code     [VAT]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1091;
			//Number of Bottles in a Case|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_5.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_5.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1092;
			//Disable this Deposit|Checked
			if (modRecordSet.rsLang.RecordCount){_chkFields_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_chkFields_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1093;
			//Pricing|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lblLabels_8 = No Code     [Bottles]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_8.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_8.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblLabels_9 = No Code     [Case]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_9.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_9.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//NOTE: DB Entry 1094 contains invalid text
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1094;
			//Inclusive Price|Check
			if (modRecordSet.rsLang.RecordCount){_lblLabels_6.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_6.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1095;
			//Special Price|Check
			if (modRecordSet.rsLang.RecordCount){_lblLabels_7.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_7.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmDeposit.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void buildDataControls()
		{
			doDataControl(ref (this.cmbVat), ref "SELECT VatID, Vat_Name FROM Vat ORDER BY Vat_Name", ref "Deposit_VatID", ref "VatID", ref "Vat_Name");
		}

		private void doDataControl(ref myDataGridView dataControl, ref string sql, ref string DataField, ref string boundColumn, ref string listField)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref sql);
			//dataControl.DataSource = rs
			dataControl.DataSource = adoPrimaryRS;
			dataControl.DataField = DataField;
			dataControl.boundColumn = boundColumn;
			dataControl.listField = listField;
		}

		public void loadItem(ref int id)
		{
			System.Windows.Forms.TextBox oText = null;
			System.Windows.Forms.CheckBox oCheck = null;
			 // ERROR: Not supported in C#: OnErrorStatement

			if (id) {
				gID = id;
				adoPrimaryRS = modRecordSet.getRS(ref "select * from Deposit WHERE DepositID = " + id);
			} else {
				gID = 0;
				adoPrimaryRS = modRecordSet.getRS(ref "select * from Deposit");
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
			foreach (TextBox oText_loopVariable in txtHide) {
				oText = oText_loopVariable;
				oText.DataBindings.Add(adoPrimaryRS);
			}
			foreach (TextBox oText_loopVariable in txtInteger) {
				oText = oText_loopVariable;
				oText.DataBindings.Add(adoPrimaryRS);
				oText.Leave += txtInteger_Leave;
				//txtInteger_Leave(txtInteger.Item((oText.Index)), New System.EventArgs())
			}
			foreach (TextBox oText_loopVariable in txtFloat) {
				oText = oText_loopVariable;
				oText.DataBindings.Add(adoPrimaryRS);

				if (string.IsNullOrEmpty(oText.Text))
					oText.Text = "0";
				oText.Text = Convert.ToString(Convert.ToDouble(oText.Text) * 100);
				oText.Leave += txtFloat_Leave;
				//txtFloat_Leave(txtFloat.Item((oText.Index)), New System.EventArgs())
			}
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

			loadLanguage();
			ShowDialog();
		}

		private void setup()
		{
			//    Dim rs As Recordset
			//    Dim X As Integer
			//    Set rs = getRS("SELECT Channel_Code FROM Channel ORDER BY ChannelID")
			//    rs.MoveFirst
			//    For X = 0 To 7
			//        Me.lblCG(X).Caption = rs("Channel_Code")
			//        rs.moveNext
			//    Next
		}

		private void Command1_Click()
		{

		}

		private void cmbVat_KeyDown(System.Object eventSender, KeyEventArgs eventArgs)
		{
			if (mbEditFlag | mbAddNewFlag)
				return;
			if (eventArgs.KeyCode == 27) {
				//eventArgs.KeyCode = 0
				adoPrimaryRS.Move(0);
				cmdClose_Click(cmdClose, new System.EventArgs());
			}
		}

		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modApplication.report_Deposits();
		}

		private void frmDeposit_Load(object sender, System.EventArgs e)
		{
			txtFields.AddRange(new TextBox[] {
				_txtFields_3,
				_txtFields_4,
				_txtFields_28
			});
			txtFloat.AddRange(new TextBox[] {
				_txtFloat_0,
				_txtFloat_1,
				_txtFloat_2,
				_txtFloat_3
			});
			txtHide.AddRange(new TextBox[] {
				_txtHide_0,
				_txtHide_1
			});
			txtInteger.AddRange(new TextBox[] { _txtInteger_5 });
			chkFields.AddRange(new CheckBox[] { _chkFields_1 });
			TextBox tb = new TextBox();
			CheckBox cb = new CheckBox();
			foreach (TextBox tb_loopVariable in txtFields) {
				tb = tb_loopVariable;
				tb.Enter += txtFields_Enter;
				tb.Leave += txtFields_Leave;
			}
			foreach (TextBox tb_loopVariable in txtFloat) {
				tb = tb_loopVariable;
				tb.Enter += txtFloat_Enter;
				tb.KeyPress += txtFloat_KeyPress;
			}
			foreach (TextBox tb_loopVariable in txtInteger) {
				tb = tb_loopVariable;
				tb.Enter += txtInteger_Enter;
				tb.KeyPress += txtInteger_KeyPress;
			}
		}

		private void frmDeposit_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			Button cmdLast = new Button();
			Button cmdNext = new Button();
			Label lblStatus = new Label();
			 // ERROR: Not supported in C#: OnErrorStatement

			lblStatus.Width = sizeConvertors.pixelToTwips(this.Width, true) - 1500;
			cmdNext.Left = lblStatus.Width + 700;
			cmdLast.Left = cmdNext.Left + 340;
		}

		private void frmDeposit_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case System.Windows.Forms.Keys.Escape:
					KeyAscii = 0;
					cmdClose.Focus();
					System.Windows.Forms.Application.DoEvents();
					adoPrimaryRS.Move(0);
					cmdClose_Click(cmdClose, new System.EventArgs());
					break;
			}

			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmDeposit_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
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
				foreach (TextBox oText_loopVariable in txtInteger) {
					oText = oText_loopVariable;
					oText.Leave += txtInteger_Leave;
					//txtInteger_Leave(txtInteger.Item(oText.Index), New System.EventArgs())
				}
				foreach (TextBox oText_loopVariable in txtFloat) {
					oText = oText_loopVariable;
					if (string.IsNullOrEmpty(oText.Text))
						oText.Text = "0";
					oText.Text = oText.Text * 100;
					oText.Leave += txtFloat_Leave;
					//txtFloat_Leave(txtFloat.Item(oText.Index), New System.EventArgs())
				}
				mbDataChanged = false;
			}
		}

		private bool update_Renamed()
		{
			bool functionReturnValue = false;
			 // ERROR: Not supported in C#: OnErrorStatement

			functionReturnValue = true;
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			rs = modRecordSet.getRS(ref "SELECT * FROM Vat WHERE VatID = " + cmbVat.BoundText);
			if (rs.BOF | rs.EOF) {
				gVAT = 0;
			} else {
				gVAT = rs.Fields("Vat_Amount").Value;
			}
			txtHide[0].Text = Convert.ToString(Convert.ToDouble(_txtFloat_0.Text) / (1 + gVAT / 100));
			txtHide[1].Text = Convert.ToString(Convert.ToDouble(_txtFloat_1.Text) / (1 + gVAT / 100));
			System.Windows.Forms.Application.DoEvents();
			if (mbAddNewFlag) {
				adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll);
				adoPrimaryRS.MoveLast();
				//move to the new record
			} else {
				if (adoPrimaryRS.Fields("Deposit_UnitPrice1").Value != adoPrimaryRS.Fields("Deposit_UnitPrice1").OriginalValue | adoPrimaryRS.Fields("Deposit_CasePrice1").Value != adoPrimaryRS.Fields("Deposit_CasePrice1").OriginalValue) {
					modRecordSet.cnnDB.Execute("INSERT INTO tempStockItem ( tempStockItemID ) SELECT StockItem.StockItemID FROM StockItem LEFT JOIN tempStockItem ON StockItem.StockItemID = tempStockItem.tempStockItemID WHERE (((tempStockItem.tempStockItemID) Is Null) AND ((StockItem.StockItem_DepositID)=" + adoPrimaryRS.Fields("DepositID").Value + "));");
				}
				adoPrimaryRS.Move(0);
				adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll);

			}
			modRecordSet.cnnDB.Execute("INSERT INTO WarehouseDepositItemLnk ( WarehouseDepositItemLnk_WarehouseID, WarehouseDepositItemLnk_DepositID, WarehouseDepositItemLnk_DepositTypeID, WarehouseDepositItemLnk_Quantity ) SELECT DISPLAY_Deposits.WarehouseID, DISPLAY_Deposits.DepositID, DISPLAY_Deposits.type, 0 AS quantity FROM WarehouseDepositItemLnk RIGHT JOIN DISPLAY_Deposits ON (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID = DISPLAY_Deposits.type) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID = DISPLAY_Deposits.WarehouseID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = DISPLAY_Deposits.DepositID) WHERE (((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID) Is Null));");
			sql = "INSERT INTO DayEndDepositItemLnk ( DayEndDepositItemLnk_DayEndID, DayEndDeposittemLnk_DepositID, DayEndDeposittemLnk_DepositType, DayEndDepositItemLnk_Quantity, DayEndDepositItemLnk_QuantitySales, DayEndDepositItemLnk_QuantityShrink, DayEndDepositItemLnk_UnitCost, DayEndDepositItemLnk_CaseCost, DayEndDepositItemLnk_CaseQuantity ) SELECT DISPLAY_DepositDayEnd.Company_DayEndID, DISPLAY_DepositDayEnd.DepositID, DISPLAY_DepositDayEnd.type, 0 AS Expr1, 0 AS Expr2, 0 AS Expr3, Deposit.Deposit_UnitCost, Deposit.Deposit_CaseCost, Deposit.Deposit_Quantity FROM DayEndDepositItemLnk RIGHT JOIN (Deposit INNER JOIN DISPLAY_DepositDayEnd ON Deposit.DepositID = DISPLAY_DepositDayEnd.DepositID) ON (DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType = DISPLAY_DepositDayEnd.type) AND (DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = DISPLAY_DepositDayEnd.DepositID) AND (DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID = DISPLAY_DepositDayEnd.Company_DayEndID) ";
			sql = sql + "WHERE (((DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) Is Null));";
			modRecordSet.cnnDB.Execute(sql);


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

			if (string.IsNullOrEmpty(txtFields[28].Text) | string.IsNullOrEmpty(_txtFields_3.Text)) {
				Interaction.MsgBox("Deposit display name/receipt name cannot be empty", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Deposits");
				return;
			}

			if (Conversion.Val(txtInteger[5].Text) == 0) {
				Interaction.MsgBox("Number of Bottles In a case cannot be zero", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Deposits");
				return;
			}

			if (Strings.Left(Strings.LCase(txtFields[28].Text), 3) != "non") {
				if (string.IsNullOrEmpty(_txtFields_4.Text)) {
					Interaction.MsgBox("Deposit 'POS Quick Key' cannot be empty", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Deposits");
					return;
				}

				//        If _txtFloat_0.Text = 0 Then
				//           MsgBox "Bottle 'Inclusive Price' cannot be empty", vbApplicationModal + vbInformation + vbOKOnly, "Deposits"
				//           Exit Sub
				//        End If
				//
				//        If _txtFloat_1.Text = 0 Then
				//           MsgBox "Bottle 'Inclusive Price' cannot be empty", vbApplicationModal + vbInformation + vbOKOnly, "Deposits"
				//           Exit Sub
				//        End If
			}

			if (gID == 0) {
				rs = modRecordSet.getRS(ref "Select * FROM Deposit WHERE Deposit_Name = '" + Strings.Trim(txtFields[28].Text) + "'");
				if (rs.RecordCount > 0) {
					Interaction.MsgBox("Deposit Name [ " + Strings.Trim(txtFields[28].Text) + " ] exist already, Chooose another Deposit Name", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					return;
				}

				rs = modRecordSet.getRS(ref "Select * FROM Deposit WHERE ((Deposit.Deposit_Disabled) <> True) AND Deposit_Key = '" + Strings.Trim(_txtFields_4.Text) + "'");
				if (rs.RecordCount > 0) {
					Interaction.MsgBox("POS Quick Key [ " + Strings.Trim(_txtFields_4.Text) + " ] exist already, Chooose another POS Quick Key", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					return;
				}

			} else {
				rs = modRecordSet.getRS(ref "Select * FROM Deposit WHERE ((Deposit.Deposit_Disabled) <> True) AND DepositID <> " + gID + " AND Deposit_Name = '" + Strings.Trim(txtFields[28].Text) + "'");
				if (rs.RecordCount > 0) {
					Interaction.MsgBox("Deposit Name [ " + Strings.Trim(txtFields[28].Text) + " ] exist already, Chooose another Deposit Name", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					return;
				}

				rs = modRecordSet.getRS(ref "Select * FROM Deposit WHERE ((Deposit.Deposit_Disabled) <> True) AND DepositID <> " + gID + " AND Deposit_Key = '" + Strings.Trim(_txtFields_4.Text) + "'");
				if (rs.RecordCount > 0) {
					Interaction.MsgBox("POS Quick Key [ " + Strings.Trim(_txtFields_4.Text) + " ] exist already, Chooose another POS Quick Key", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					return;
				}

				if (_chkFields_1.CheckState) {
					rs = modRecordSet.getRS(ref "Select * FROM [Set] WHERE Set_DepositID = " + gID + " AND Set_Disabled=False");
					if (rs.RecordCount > 0) {
						Interaction.MsgBox("This Deposit is being used in Stock Set(s). Please 'Disable' this Stock Set(s) first in order to disable the Deposit.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
						return;
					}

					rs = modRecordSet.getRS(ref "Select * FROM StockItem WHERE StockItem_DepositID = " + gID + " AND StockItem_Disabled=False;");
					if (rs.RecordCount > 0) {
						Interaction.MsgBox("This Deposit is being used in Stock Item(s). Please 'Disable' those Stock Item(s) first in order to disable this Deposit.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
						return;
					}
				}

			}

			if (update_Renamed()) {
				this.Close();
			}

		}

		//Handles txtFields.Enter
		private void txtFields_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			int Index = 0;
			TextBox txtBox = new TextBox();
			txtBox = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref txtBox, ref txtFields);
			modUtilities.MyGotFocus(ref txtFields[Index]);
		}

		// Handles txtFields.Leave
		private void txtFields_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txt = null;
			txt = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txt, ref txtFields);
			//*Code that put the Display Name text in the Receipt Name Textbox when Display Name Loses Focus
			if (string.IsNullOrEmpty(_txtFields_3.Text)) {
				_txtFields_3.Text = _txtFields_28.Text;
			}
		}

		//Handles txtInteger.Enter
		private void txtInteger_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			int Index = 0;
			TextBox txtBox = new TextBox();
			txtBox = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref txtBox, ref txtInteger);
			modUtilities.MyGotFocusNumeric(ref txtInteger[Index]);
		}

		//Handles txtInteger.KeyPress
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

		// Handles txtInteger.Leave
		private void txtInteger_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			int Index = 0;
			TextBox txtBox = new TextBox();
			txtBox = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref txtBox, ref txtInteger);
			modUtilities.MyLostFocus(ref txtInteger[Index], ref 0);
		}

		//Handles txtFloat.Enter
		private void txtFloat_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			int Index = 0;
			TextBox txtBox = new TextBox();
			txtBox = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref txtBox, ref txtFloat);
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
			int Index = 0;
			TextBox txtBox = new TextBox();
			txtBox = (TextBox)eventSender;
			Index = GetIndex.GetIndexer(ref txtBox, ref txtFloat);
			modUtilities.MyLostFocus(ref txtFloat[Index], ref 2);
		}
	}
}
