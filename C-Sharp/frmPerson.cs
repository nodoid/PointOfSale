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
	internal partial class frmPerson : System.Windows.Forms.Form
	{
		int gID;
		short InOper;
		short perIden;
		int mvBookMark;
		bool inController;
		bool blCChanged;
		bool mbEditFlag;
		bool mbAddNewFlag;
		bool mbDataChanged;
		bool mbChangedByCode;
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
		List<TextBox> txtFields;

		List<CheckBox> chkFields;
		private void loadLanguage()
		{

			//frmPerson = No Code        [Edit Employee Details]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmPerson.Caption = rsLang("LanguageLayoutLnk_Description"): frmPerson.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//cmdBOsecurity = No Code    [Back Office Permissions]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdBOsecurity.Caption = rsLang("LanguageLayoutLnk_Description"): cmdBOsecurity.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdPOSsecurity = No Code   [Point Of Sale Security]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdPOSsecurity.Caption = rsLang("LanguageLayoutLnk_Description"): cmdPOSsecurity.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdFPR = No Code           [Finger Print Registration]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdFPR.Caption = rsLang("LanguageLayoutLnk_Description"): cmdFPR.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1010;
			//General|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_5.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_5.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lblLabels_2 = No Code     [First Name]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1287;
			//Surname|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_4.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_4.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lblLabels_7 = No Code     [Cell]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_7.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_7.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblLabels_5 = No Code     [Position]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_5.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblLabels_13 = No Code    [ID Number]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_13.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_13.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1288;
			//Telephone|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_8.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_8.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lbl_0 = No Code           [Security]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//frmSecurity(0) = No Code   [Back Office Logon]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmSecurity(0).Caption = rsLang("LanguageLayoutLnk_Description"): frmSecurity(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblLabels_10 = No Code    [User ID]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_10.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_10.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2490;
			//Password|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_11.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_11.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//Frame1 = No Code           [Commission %]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Frame1.Caption = rsLang("LanguageLayoutLnk_Description"): Frame1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//frmSecurity(1) = No Code   [Point Of Sale Logon]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmSecurity(1).Caption = rsLang("LanguageLayoutLnk_Description"): frmSecurity(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblLabels_12 = No Code    [Access Scan ID]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_12.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_12.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label1 = No Code           [This is a barcode used.......]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2136;
			//Build|
			if (modRecordSet.rsLang.RecordCount){cmdBuild.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdBuild.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lblLabels_0 = No Code     [Default Till/Drawer]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkController = No Code    [Permit this person to terminate controller]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkController.Caption = rsLang("LanguageLayoutLnk_Description"): chkController.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_chkFields_2 = No Code     [Disable this person from using the application suite]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _chkFields_2.Caption = rsLang("LanguageLayoutLnk_Description"): _chkFields_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmPerson.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void buildDataControls()
		{

		}

		private void doDataControl(ref myDataGridView dataControl, ref string sql, ref string DataField, ref string boundColumn, ref string listField)
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
			ADODB.Recordset rsP = default(ADODB.Recordset);
			System.Windows.Forms.TextBox oText = null;
			System.Windows.Forms.CheckBox oCheck = null;
			 // ERROR: Not supported in C#: OnErrorStatement


			InOper = id;
			inController = false;



			if (id) {
				adoPrimaryRS = modRecordSet.getRS(ref "select PersonID,Person_Title,Person_FirstName,Person_LastName,Person_Position,Person_Cell,Person_Telephone,Person_UserID,Person_Password,Person_QuickAccess,Person_IDNo,Person_Disabled,Person_Drawer from Person WHERE PersonID = " + id);
				rsP = modRecordSet.getRS(ref "SELECT * FROM Person WHERE PersonID = " + id);
				txtComm.Text = Strings.FormatNumber(rsP.Fields("Person_Comm").Value, 2);
				//for duplication access id
				_txtFields_12.Text = rsP.Fields("Person_QuickAccess").Value;

				rsP = modRecordSet.getRS(ref "SELECT Controller_Permission FROM ControllerPermission WHERE Controller_PersonID = " + id);
				if (rsP.RecordCount == 0) {
					inController = true;
					modRecordSet.cnnDB.Execute("INSERT INTO ControllerPermission (Controller_PersonID,Controller_Permission) VALUES (" + id + ",0)");
					this.chkController.CheckState = System.Windows.Forms.CheckState.Unchecked;
					this.chkController.Tag = 0;
				} else {
					if (rsP.Fields("Controller_Permission").Value == true) {
						this.chkController.CheckState = System.Windows.Forms.CheckState.Checked;
						this.chkController.Tag = 1;
					} else {
						this.chkController.CheckState = System.Windows.Forms.CheckState.Unchecked;
						this.chkController.Tag = 0;
					}
				}
				_lbl_1.Text = "Employee No. " + id;
			} else {
				adoPrimaryRS = modRecordSet.getRS(ref "select * from Person");
				adoPrimaryRS.AddNew();
				this.Text = this.Text + " [New record]";
				mbAddNewFlag = true;
				_lbl_1.Text = "Employee No. " + " [New record]";
			}

			setup();

			foreach (TextBox oText_loopVariable in this.txtFields) {
				oText = oText_loopVariable;
				oText.DataBindings.Add(adoPrimaryRS);
				oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize;
			}

			perIden = id;

			 // ERROR: Not supported in C#: OnErrorStatement

			if (id) {
				cmbDraw.SelectedIndex = adoPrimaryRS.Fields("Person_Drawer").Value;
			} else {
				cmbDraw.SelectedIndex = 0;
			}

			foreach (CheckBox oCheck_loopVariable in this.chkFields) {
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
		}
		private void cmdBOsecurity_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (update_Renamed())
				My.MyProject.Forms.frmBOSecurity.loadItem(ref adoPrimaryRS.Fields("PersonID").Value);
		}

		private void cmdBuild_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string tt = null;
			string lCode = null;
			lCode = Strings.Right("888888888888" + Strings.Replace(Convert.ToString(Convert.ToDecimal(DateAndTime.Now.ToOADate())), ".", ""), 12);
			tt = modApplication.addCheckSum(ref lCode);
			_txtFields_12.Text = tt;
		}

		private void cmdFPR_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement


			//SDK Selection
			ADODB.Recordset rsSDK = default(ADODB.Recordset);
			rsSDK = modRecordSet.getRS(ref "SELECT Company_FingerSDK FROM Company");
			if (rsSDK.RecordCount) {
				if ((Information.IsDBNull(rsSDK.Fields("Company_FingerSDK").Value) ? 0 : rsSDK.Fields("Company_FingerSDK").Value) == 0) {
					if (update_Renamed())
						My.MyProject.Forms.frmPersonFPReg.loadItem(ref adoPrimaryRS.Fields("PersonID").Value);
				} else {
					if (update_Renamed())
						My.MyProject.Forms.frmPersonFPRegOT.loadItem(ref adoPrimaryRS.Fields("PersonID").Value);
					My.MyProject.Forms.frmPersonFPVerifyOT.loadItem(ref (adoPrimaryRS.Fields("PersonID").Value));
				}
			} else {
				if (update_Renamed())
					My.MyProject.Forms.frmPersonFPReg.loadItem(ref adoPrimaryRS.Fields("PersonID").Value);
			}
			//SDK Selection

			return;
			FPA_Error:
			if (Err().Number == 429) {
				Interaction.MsgBox("Driver/Device missing for Finger Print Reader", MsgBoxStyle.Critical);
			} else {
				Interaction.MsgBox(Err().Number + " " + Err().Description, MsgBoxStyle.Critical);
				 // ERROR: Not supported in C#: ResumeStatement

			}
		}

		private void cmdPOSsecurity_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (update_Renamed())
				My.MyProject.Forms.frmPOSSecurity.loadItem(ref adoPrimaryRS.Fields("PersonID").Value);
		}

		private void frmPerson_Load(object sender, System.EventArgs e)
		{
			txtFields.AddRange(new TextBox[] {
				_txtFields_1,
				_txtFields_2,
				_txtFields_4,
				_txtFields_5,
				_txtFields_7,
				_txtFields_8,
				_txtFields_10,
				_txtFields_11,
				_txtFields_12,
				_txtFields_13
			});
			chkFields.AddRange(new CheckBox[] { _chkFields_2 });
			TextBox tb = new TextBox();
			foreach (TextBox tb_loopVariable in txtFields) {
				tb = tb_loopVariable;
				tb.Enter += txtFields_Enter;
			}

		}

//UPGRADE_WARNING: Event frmPerson.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void frmPerson_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			Button cmdLast = new Button();
			Button cmdNext = new Button();
			Label lblStatus = new Label();
			 // ERROR: Not supported in C#: OnErrorStatement

			lblStatus.Width = sizeConvertors.pixelToTwips(this.Width, true) - 1500;
			cmdNext.Left = lblStatus.Width + 700;
			cmdLast.Left = cmdNext.Left + 340;
		}

		private void frmPerson_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void frmPerson_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
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
				//UPGRADE_WARNING: Couldn't resolve default property of object mvBookMark. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (mvBookMark > 0) {
					//UPGRADE_WARNING: Couldn't resolve default property of object mvBookMark. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
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
			ADODB.Recordset rs = default(ADODB.Recordset);
			string rsValue = null;


			if (InOper != 0) {
				//for old employee
				if (inController == true) {
					modRecordSet.cnnDB.Execute("UPDATE Person SET Person_Comm = " + Conversion.Val(rsValue) + " WHERE PersonID = " + perIden);
					modRecordSet.cnnDB.Execute("UPDATE ControllerPermission SET Controller_Permission = " + Conversion.Val(Convert.ToString(this.chkController.CheckState)) + " WHERE Controller_PersonID = " + perIden);
				} else {

					modRecordSet.cnnDB.Execute("UPDATE Person SET Person_Comm = " + Conversion.Val(txtComm.Text) + " WHERE PersonID = " + perIden);
					if (this.chkController.CheckState != Convert.ToDouble(this.chkController.Tag)) {
						modRecordSet.cnnDB.Execute("UPDATE ControllerPermission SET Controller_Permission = " + Conversion.Val(Convert.ToString(this.chkController.CheckState)) + " WHERE Controller_PersonID = " + perIden);
					}
				}

				modRecordSet.cnnDB.Execute("UPDATE Person SET Person_Drawer = " + cmbDraw.SelectedIndex + " WHERE PersonID = " + perIden);

				//for duplication access id
				rs = modRecordSet.getRS(ref "Select * FROM Person WHERE Person_QuickAccess = '" + Strings.Trim(_txtFields_12.Text) + "' AND PersonID <> " + perIden + ";");
				if (rs.RecordCount > 0) {
					Interaction.MsgBox("Access Scan ID already being used, Please choose another!!", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					_txtFields_12.Focus();
					return;
				}
				modRecordSet.cnnDB.Execute("UPDATE Person SET Person_QuickAccess = '" + _txtFields_12.Text + "' WHERE PersonID = " + perIden);

			} else {

				//New employee being added
				rsValue = txtComm.Text;
				//if new add validation
				rs = modRecordSet.getRS(ref "Select * FROM Person WHERE Person_QuickAccess = '" + Strings.Trim(_txtFields_12.Text) + "'");
				if (rs.RecordCount > 0) {
					Interaction.MsgBox("Access Scan ID already being used, Please choose another!!", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					_txtFields_12.Focus();
					return;
				}
				//exit sub
			}

			cmdClose.Focus();
			System.Windows.Forms.Application.DoEvents();
			if (update_Renamed()) {

				if (InOper == 0) {
					rs = modRecordSet.getRS(ref "SELECT MAX(PersonID) FROM Person");

					//if new add access code
					modRecordSet.cnnDB.Execute("UPDATE Person SET Person_QuickAccess = '" + _txtFields_12.Text + "' WHERE PersonID = " + rs.Fields(0).Value);

					modRecordSet.cnnDB.Execute("UPDATE Person SET Person_Comm = " + Conversion.Val(rsValue) + " WHERE PersonID = " + rs.Fields(0).Value);
					modRecordSet.cnnDB.Execute("INSERT INTO ControllerPermission (Controller_PersonID,Controller_Permission) VALUES (" + rs.Fields(0).Value + "," + this.chkController.CheckState + ")");

					modRecordSet.cnnDB.Execute("UPDATE Person SET Person_Drawer = " + cmbDraw.SelectedIndex + " WHERE PersonID = " + rs.Fields(0).Value);
				}
				this.Close();
			}


		}

		private void txtComm_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyGotFocusNumeric(ref txtComm.Text());
		}

		private void txtComm_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			modUtilities.MyKeyPress(ref KeyAscii);

			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
		private void txtComm_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			modUtilities.MyLostFocus(ref txtComm, ref 2);
		}

		//
		private void txtFields_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txt = new TextBox();
			txt = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txt, ref txtFields);
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
			//    LostFocus txtFloat(Index), 2
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
