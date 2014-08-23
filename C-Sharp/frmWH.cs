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
	internal partial class frmWH : System.Windows.Forms.Form
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
		int k_posID;
		bool k_posNew;
		bool bolLoad;
		List<TextBox> txtFields = new List<TextBox>();

		List<TextBox> txtInteger = new List<TextBox>();
		private void loadLanguage()
		{

			//frmWH = No Code            [Edit Warehouse Details]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmWH.Caption = rsLang("LanguageLayoutLnk_Description"): frmWH.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1010;
			//General|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_5.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_5.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lblLabels_1 = No Code     [Warehouse Name]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblLabels_2 = No Code     [Warehouse Number]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmWH.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public void loadItem(ref int id)
		{
			System.Windows.Forms.TextBox oText = null;
			System.Windows.Forms.CheckBox oCheck = null;
			 // ERROR: Not supported in C#: OnErrorStatement


			if (id) {
				k_posNew = false;
				k_posID = id;
				//Get Warehouse ID...
				adoPrimaryRS = modRecordSet.getRS(ref "select * from Warehouse WHERE WarehouseID = " + id);
			} else {
				k_posNew = true;
				adoPrimaryRS = modRecordSet.getRS(ref "select * from Warehouse");
				adoPrimaryRS.AddNew();
				this.Text = this.Text + " [New record]";
				_txtInteger_0.Enabled = true;
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
				//txtInteger_Leave(txtInteger.Item((oText.Index)), New System.EventArgs())
			}

			bolLoad = true;
			if (id) {

			}
			bolLoad = false;

			mbDataChanged = false;

			loadLanguage();
			ShowDialog();
		}

		private void setup()
		{
		}

		private void frmWH_Load(object sender, System.EventArgs e)
		{
			txtFields.AddRange(new TextBox[] {
				_txtFields_1,
				_txtFields_10
			});
			txtInteger.AddRange(new TextBox[] { _txtInteger_0 });
			_txtFields_1.Enter += txtFields_Enter;
			_txtFields_10.Enter += txtFields_Enter;
		}


//UPGRADE_WARNING: Event frmWH.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void frmWH_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			//lblStatus.Width = Me.Width - 1500
			//cmdnext.Left = lblStatus.Width + 700
			//cmdLast.Left = cmdnext.Left + 340
		}
		private void frmWH_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case System.Windows.Forms.Keys.Escape:
					KeyAscii = 0;
					System.Windows.Forms.Application.DoEvents();
					//            adoPrimaryRS.Move 0
					cmdClose_Click(cmdClose, new System.EventArgs());
					break;
			}

			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmWH_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
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

			bool lDirty = false;
			short x = 0;
			lDirty = false;
			functionReturnValue = true;

			if (mbAddNewFlag) {
				adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll);
				adoPrimaryRS.MoveLast();
				//move to the new record
			} else {
				adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll);
				adoPrimaryRS.MoveLast();
				//move to the new record
			}

			mbEditFlag = false;
			mbAddNewFlag = false;
			mbDataChanged = false;
			return functionReturnValue;
			UpdateErr:

			if (Err().Number == Convert.ToDouble("-2147217900")) {
				Interaction.MsgBox("Warehouse Number [ " + Conversion.Val(_txtInteger_0.Text) + " ] exist already, Chooose another number", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				functionReturnValue = false;
				_txtInteger_0.Focus();
			} else {
				Interaction.MsgBox(Err().Number + Err().Description);
				functionReturnValue = false;
			}
			return functionReturnValue;
		}

		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rj = default(ADODB.Recordset);

			if (k_posNew == true) {
				//-------------------------
				rs = modRecordSet.getRS(ref "Select * FROM Warehouse WHERE Warehouse_Name = '" + Strings.Trim(_txtFields_1.Text) + "'");
				if (rs.RecordCount > 0) {
					Interaction.MsgBox("Warehouse Name [ " + _txtFields_1.Text + " ] exist already, Chooose another name", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					return;
				}

				rs = modRecordSet.getRS(ref "Select * FROM Warehouse WHERE WarehouseID = " + Conversion.Val(_txtInteger_0.Text));
				if (rs.RecordCount > 0) {
					Interaction.MsgBox("Warehouse Number [ " + Conversion.Val(_txtInteger_0.Text) + " ] exist already, Chooose another number", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					return;
				}
				//-------------------------
			} else {
				rs = modRecordSet.getRS(ref "Select * FROM Warehouse WHERE WarehouseID <> " + k_posID + " AND Warehouse_Name = '" + Strings.Trim(_txtFields_1.Text) + "'");
				if (rs.RecordCount > 0) {
					Interaction.MsgBox("Warehouse Name [ " + _txtFields_1.Text + " ] exist already, Chooose another name", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					return;
				}
			}

			if (string.IsNullOrEmpty(_txtFields_1.Text)) {
				Interaction.MsgBox("Warehouse Name cannot be blank, enter Warehouse name", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				return;
			}
			if (Conversion.Val(_txtInteger_0.Text) < 2) {
				Interaction.MsgBox("Please enter another Warehouse Number other than 0 or 1", MsgBoxStyle.Information + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				return;
			}


			cmdClose.Focus();
			System.Windows.Forms.Application.DoEvents();

			if (update_Renamed()) {
				if (k_posNew == true) {
					rs = modRecordSet.getRS(ref "SELECT Max(Warehouse.WarehouseID) AS id FROM Warehouse;");
					if (rs.RecordCount > 0) {
						//a = rs("id")
						modRecordSet.cnnDB.Execute("INSERT INTO WarehouseStockItemLnk ( WarehouseStockItemLnk_WarehouseID, WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk_Quantity ) SELECT Warehouse.WarehouseID, StockItem.StockItemID, 0 FROM Warehouse, StockItem WHERE (((Warehouse.WarehouseID)=" + rs.Fields("id").Value + "));");
						modRecordSet.cnnDB.Execute("INSERT INTO DayEndStockItemLnk ( DayEndStockItemLnk_DayEndID, DayEndStockItemLnk_StockItemID, DayEndStockItemLnk_Quantity, DayEndStockItemLnk_QuantitySales, DayEndStockItemLnk_QuantityShrink, DayEndStockItemLnk_QuantityGRV, DayEndStockItemLnk_ListCost, DayEndStockItemLnk_ActualCost, DayEndStockItemLnk_Warehouse ) SELECT Company.Company_DayEndID, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, 0 AS Expr1, 0 AS Expr2, 0 AS Expr3, 0 AS Expr4, DayEndStockItemLnk.DayEndStockItemLnk_ListCost, DayEndStockItemLnk.DayEndStockItemLnk_ActualCost, Warehouse.WarehouseID FROM Warehouse, Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID GROUP BY Company.Company_DayEndID, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, DayEndStockItemLnk.DayEndStockItemLnk_ListCost, DayEndStockItemLnk.DayEndStockItemLnk_ActualCost, Warehouse.WarehouseID HAVING (((Warehouse.WarehouseID)=" + rs.Fields("id").Value + "));");
					}
				}
				k_posNew = false;
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
	}
}
