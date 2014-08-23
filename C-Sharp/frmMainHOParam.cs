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
	internal partial class frmMainHOParam : System.Windows.Forms.Form
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
		int gID;
		int mvBookMark;
		bool mbChangedByCode;
		bool mbEditFlag;
		bool mbAddNewFlag;
		bool mbDataChanged;
		bool loading;
		bool g_Emails;


		public void loadItem()
		{
			ADODB.Recordset rj = default(ADODB.Recordset);
			System.Windows.Forms.CheckBox oCheck = null;

			adoPrimaryRS = modRecordSet.getRS(ref "SELECT Company_HOParamBit FROM Company");

			const short gReOrderLvl = 1;
			const short gEmployeePer = 2;
			const short gWaitronCount = 4;
			const short gActualCost = 8;
			const short gPromotion = 16;
			const short gRecipe = 32;

			 // ERROR: Not supported in C#: OnErrorStatement

			//Bind the check boxes to the data provider
			this._chkBit_1.CheckState = System.Math.Abs(Convert.ToInt32(Convert.ToBoolean(adoPrimaryRS.Fields("Company_HOParamBit").Value & gReOrderLvl)));
			this._chkBit_2.CheckState = System.Math.Abs(Convert.ToInt32(Convert.ToBoolean(adoPrimaryRS.Fields("Company_HOParamBit").Value & gEmployeePer)));
			this._chkBit_3.CheckState = System.Math.Abs(Convert.ToInt32(Convert.ToBoolean(adoPrimaryRS.Fields("Company_HOParamBit").Value & gWaitronCount)));
			this._chkBit_4.CheckState = System.Math.Abs(Convert.ToInt32(Convert.ToBoolean(adoPrimaryRS.Fields("Company_HOParamBit").Value & gActualCost)));
			this._chkBit_5.CheckState = System.Math.Abs(Convert.ToInt32(Convert.ToBoolean(adoPrimaryRS.Fields("Company_HOParamBit").Value & gPromotion)));
			this._chkBit_6.CheckState = System.Math.Abs(Convert.ToInt32(Convert.ToBoolean(adoPrimaryRS.Fields("Company_HOParamBit").Value & gRecipe)));

			ShowDialog();
		}

		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdClose.Focus();
			System.Windows.Forms.Application.DoEvents();

			if (update_Renamed()) {
				this.Close();
			}
		}

		private void frmMainHOParam_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case System.Windows.Forms.Keys.Escape:
					KeyAscii = 0;
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
		private void frmMainHOParam_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
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

			bool lDirty = false;
			short x = 0;
			short lBit = 0;
			const short gReOrderLvl = 1;
			const short gEmployeePer = 2;
			const short gWaitronCount = 4;
			const short gActualCost = 8;
			const short gPromotion = 16;
			const short gRecipe = 32;

			lDirty = false;
			functionReturnValue = true;

			if (this._chkBit_1.CheckState)
				lBit = lBit + gReOrderLvl;
			if (this._chkBit_2.CheckState)
				lBit = lBit + gEmployeePer;
			if (this._chkBit_3.CheckState)
				lBit = lBit + gWaitronCount;
			if (this._chkBit_4.CheckState)
				lBit = lBit + gActualCost;
			if (this._chkBit_5.CheckState)
				lBit = lBit + gPromotion;
			if (this._chkBit_6.CheckState)
				lBit = lBit + gRecipe;

			adoPrimaryRS.Fields("Company_HOParamBit").Value = lBit;

			if (mbAddNewFlag) {
				adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll);
				adoPrimaryRS.MoveLast();
				//move to the new record
			} else {
				adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll);
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
	}
}
