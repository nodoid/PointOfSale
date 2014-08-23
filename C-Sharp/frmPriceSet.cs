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
	internal partial class frmPriceSet : System.Windows.Forms.Form
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
		List<TextBox> txtFields = new List<TextBox>();
		List<CheckBox> chkFields = new List<CheckBox>();
		private void loadLanguage()
		{

			//DB Line Entry Faulty!!! Contains wrong/invalid words!!!
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1124;
			//Edit Pricing Set Details|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1126;
			//Print all|Checked
			if (modRecordSet.rsLang.RecordCount){cmdPrintAll.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPrintAll.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1085;
			//Print|Checked
			if (modRecordSet.rsLang.RecordCount){cmdPrint.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPrint.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1010;
			//General|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_5.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_5.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1130;
			//Price Set Name|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1108;
			//Disable this Set|Checked
			if (modRecordSet.rsLang.RecordCount){_chkFields_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_chkFields_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1131;
			//Primary Stock Item|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lblStockItem = No Code/Dynamic!

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1704;
			//Edit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdEdit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdEdit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmPriceSet.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void buildDataControls()
		{
			//doDataControl Me.cmbDeposit, "SELECT DepositID, Deposit_Name FROM Deposit ORDER BY Deposit_Name", "Set_DepositID", "DepositID", "Deposit_Name"
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
			ADODB.Recordset rs = default(ADODB.Recordset);
			int lID = 0;
			System.Windows.Forms.TextBox oText = null;
			System.Windows.Forms.CheckBox oCheck = null;
			 // ERROR: Not supported in C#: OnErrorStatement

			if (id) {
				adoPrimaryRS = modRecordSet.getRS(ref "SELECT PriceSet.PriceSetID, PriceSet.PriceSet_Name, PriceSet.PriceSet_StockItemID, PriceSet.PriceSet_Disabled From PriceSet WHERE (((PriceSet.PriceSetID)=" + id + "));");
			} else {
				adoPrimaryRS = modRecordSet.getRS(ref "select * from [PriceSet]");
				adoPrimaryRS.AddNew();
				this.Text = this.Text + "[New Record]";
				mbAddNewFlag = true;
			}
			setup();

			foreach (TextBox oText_loopVariable in txtFields) {
				oText = oText_loopVariable;
				oText.DataBindings.Add(adoPrimaryRS);
				oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize;
			}

			//Bind the check boxes to the data provider
			foreach (CheckBox oCheck_loopVariable in chkFields) {
				oCheck = oCheck_loopVariable;
				lID = adoPrimaryRS.Fields("PriceSet_StockItemID").Value;
				if (lID != 0) {
					rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name FROM StockItem WHERE (StockItemID = " + lID + ")");
					if (rs.BOF | rs.EOF) {
						this.lblStockItem.Text = "No Stock Item Selected ...";
						this.lblStockItem.Tag = 0;
					} else {
						this.lblStockItem.Text = rs("StockItem_Name");
						this.lblStockItem.Tag = lID;
					}

				}
				oCheck.DataBindings.Add(adoPrimaryRS);
			}
			if (_chkFields_0.CheckState == 2)
				_chkFields_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			buildDataControls();
			mbDataChanged = false;
			setup();

			loadLanguage();
			ShowDialog();
		}

		private void setup()
		{
		}

		private void cmbDeposit_KeyDown(ref short KeyCode, ref short Shift)
		{
			if (mbEditFlag | mbAddNewFlag)
				return;
			if (KeyCode == 27) {
				KeyCode = 0;
				adoPrimaryRS.Move(0);
				cmdClose_Click(cmdClose, new System.EventArgs());
			}

		}
		private void cmdEdit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//* Disable the Pricing Set button when frmpricesetlist is open
			My.MyProject.Forms.frmStockItem.cmdpriceselist.Enabled = false;

			//*Code that refuses you access to frmstockitem before you add the new primary stockitem
			if (string.IsNullOrEmpty(this.lblStockItem.Tag)) {
				Interaction.MsgBox("Please Select the Primary Stock Item", MsgBoxStyle.Information);
				return;
			}
			//*
			if (Convert.ToBoolean(this.lblStockItem.Tag)) {
				My.MyProject.Forms.frmStockItem.loadItem(ref Convert.ToInt32(this.lblStockItem.Tag));
				frmStockItem form = null;
				form.Show();

			}

		}

		private void cmdEmulate_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int lID = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);

			//lID = frmStockList.getItem
			lID = My.MyProject.Forms.frmStockList2.getItem();
			if (lID != 0) {
				rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Name FROM StockItem WHERE (StockItemID = " + lID + ")");
				if (rs.BOF | rs.EOF) {
					Interaction.MsgBox("Stock Item Not Found!", MsgBoxStyle.Exclamation, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				} else {
					this.lblStockItem.Text = rs.Fields("StockItem_Name").Value;
					this.lblStockItem.Tag = lID;
				}

			}

		}

		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdPrint.Focus();

			System.Windows.Forms.Application.DoEvents();
			update_Renamed();
			modApplication.report_SelectPriceSets();
		}

		private void cmdPrintAll_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdPrintAll.Focus();
			System.Windows.Forms.Application.DoEvents();
			update_Renamed();
			modApplication.report_PriceSets();
		}

		private void frmPriceSet_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
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

		private void frmPriceSet_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			Button cmdLast = new Button();
			Button cmdnext = new Button();
			Label lblStatus = null;
			 // ERROR: Not supported in C#: OnErrorStatement

			lblStatus.Width = sizeConvertors.pixelToTwips(this.Width, true) - 1500;
			cmdnext.Left = lblStatus.Width + 700;
			cmdLast.Left = cmdnext.Left + 340;
		}
		private void frmPriceSet_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			txtholdvalue.Text = _txtFields_0.Text;
			modApplication.Holdvalue = txtholdvalue.Text;

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
			adoPrimaryRS.Fields("PriceSet_StockItemID").Value = this.lblStockItem.Tag;
			adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll);
			//   adoPrimaryRS.save
			if (mbAddNewFlag) {
				adoPrimaryRS.MoveLast();
				//move to the new record
			} else {
				adoPrimaryRS.Move(0);
			}
			if (Information.IsDBNull(adoPrimaryRS.Fields("PriceSet_StockItemID").Value)) {
			} else {
				modRecordSet.cnnDB.Execute("UPDATE StockItem SET StockItem.StockItem_PriceSetID = " + adoPrimaryRS.Fields("PriceSetID").Value + " WHERE (((StockItem.StockItemID)=" + adoPrimaryRS.Fields("PriceSet_StockItemID").Value + "));");
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

		public void CheckFields()
		{
			//*Disable the emulate and edit buttons when Price Set Name = Nothing
			//frmPriceSet._txtFields_0.Text = Hcheck
			if (string.IsNullOrEmpty(Strings.Trim(this._txtFields_0.Text))) {
				this.cmdEmulate.Enabled = false;
				this.cmdEdit.Enabled = false;
			} else if (!string.IsNullOrEmpty(Strings.Trim(this._txtFields_0.Text))) {
				this.cmdEmulate.Enabled = true;
				this.cmdEdit.Enabled = true;
			}
			//*
		}

//UPGRADE_WARNING: Event txtFields.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void txtFields_TextChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txtBox = new TextBox();
			txtBox = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txtBox, ref txtFields);
			CheckFields();
		}

		private void txtFields_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txtBox = new TextBox();
			txtBox = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txtBox, ref txtFields);
			modUtilities.MyGotFocus(ref txtFields[Index]);
			CheckFields();
		}

		private void frmPriceSet_Load(object sender, System.EventArgs e)
		{
			txtFields.AddRange(new TextBox[] { _txtFields_0 });
			chkFields.AddRange(new CheckBox[] { _chkFields_0 });
		}
	}
}
