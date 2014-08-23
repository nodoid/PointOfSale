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
	internal partial class frmPOS : System.Windows.Forms.Form
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
		List<TextBox> txtFloat = new List<TextBox>();
		List<TextBox> txtInteger = new List<TextBox>();
		List<CheckBox> chkFields = new List<CheckBox>();
		List<Label> lblLic = new List<Label>();
		private void loadLanguage()
		{

			//frmPOS = No Code               [Edit Point Of Sales]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmPOS.Caption = rsLang("LanguageLayoutLnk_Description"): frmPOS.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1074;
			//Undo|Checked
			if (modRecordSet.rsLang.RecordCount){cmdCancel.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdCancel.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lblLic(1) = No Code    -->BLANK!!!
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblLic(1).Caption = rsLang("LanguageLayoutLnk_Description"): lblLic(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblLic(0) = No Code            [Not Licenced]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblLic(0).Caption = rsLang("LanguageLayoutLnk_Description"): lblLic(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1010;
			//General|Checked
			if (modRecordSet.rsLang.RecordCount){_lbl_5.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lbl_5.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lblLabels_1 = No Code         [POS Name]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblLabels_3 = No Code         [POS IP Address]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_3.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1195;
			//Disable|Checked
			if (modRecordSet.rsLang.RecordCount){_chkFields_2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_chkFields_2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lblLabels_5 = No code         [Float]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_5.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2115;
			//Warehouse|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_6.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_6.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lblLabels_2 = No Code         [POS Number]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblLabels_4 = No Code         [Last Decleration]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_4.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lblLabels_0 = No Code         [Default Keyboard]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lblLabels_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Labels1 = No Code              [Kitchen Monitors]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkKitchenMonitors = No Code   [Setup this Terminal as a Kitchen Monitor (For Drive thru only)]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkKitchenMonitors.Caption = rsLang("LanguageLayoutLnk_Description"): chkKitchenMonitors.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmPOS.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void buildDataControls()
		{
			doDataControl(ref (this.cmbKeyboard), ref "SELECT KeyboardLayout.KeyboardLayoutID, KeyboardLayout.KeyboardLayout_Name FROM KeyboardLayout ORDER BY KeyboardLayout_Name", ref "POS_Keyboard", ref "KeyboardLayoutID", ref "KeyboardLayout_Name");
			doDataControl(ref (this.cmbWH), ref "SELECT Warehouse.WarehouseID, Warehouse.Warehouse_Name FROM Warehouse ORDER BY WarehouseID", ref "POS_Warehouse", ref "WarehouseID", ref "Warehouse_Name");
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
			int x = 0;
			string lCode = null;
			string leCode = null;
			string lPassword = null;

			System.Windows.Forms.TextBox oText = null;
			System.Windows.Forms.CheckBox oCheck = null;
			 // ERROR: Not supported in C#: OnErrorStatement


			if (id) {
				k_posNew = false;
				k_posID = id;
				//Get POS ID...
				adoPrimaryRS = modRecordSet.getRS(ref "select * from POS WHERE POSID = " + id);

				//new serialization check
				lPassword = Strings.LTrim(Strings.Replace(My.MyProject.Forms.frmMenu.lblCompany.Text, "'", ""));
				lPassword = Strings.RTrim(Strings.Replace(lPassword, " ", ""));
				lPassword = Strings.Trim(Strings.Replace(lPassword, ".", ""));
				lPassword = Strings.LCase(lPassword);
				leCode = "";
				lCode = "";
				for (x = 0; x <= Strings.Len(lPassword); x++) {
					lCode = Strings.Mid(lPassword, x, 1);
					lCode = Convert.ToString(Strings.Asc(lCode));
					if (Convert.ToDouble(lCode) > 96 & Convert.ToDouble(lCode) < 123) {
						leCode = leCode + Strings.Mid(lPassword, x, 1);
					}
				}
				lPassword = leCode;
				lCode = Convert.ToString(adoPrimaryRS.Fields("POS_CID").Value * 135792468);
				leCode = Encrypt(lCode, lPassword);
				for (x = 1; x <= Strings.Len(leCode); x++) {
					if (Strings.Asc(Strings.Mid(leCode, x, 1)) < 33) {
						leCode = Strings.Left(leCode, x - 1) + Strings.Chr(33) + Strings.Mid(leCode, x + 1);
					}
				}
				if (Strings.Split(adoPrimaryRS.Fields("POS_Code").Value, Strings.Chr(255))[0] != leCode) {
					lblLic[1].Visible = true;
					lblLic[0].Visible = true;
				}
				//new serialization check
			} else {
				k_posNew = true;
				adoPrimaryRS = modRecordSet.getRS(ref "select * from POS");
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
			if (k_posNew == true)
				_txtFields_10.Text = basCryptoProcs.strCDKey;
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

			bolLoad = true;
			if (id) {
				if (adoPrimaryRS.Fields("POS_KitchenMonitor").Value == true) {
					this.chkKitchenMonitors.CheckState = System.Windows.Forms.CheckState.Checked;
					this.chkKitchenMonitors.Tag = 1;
				} else {
					this.chkKitchenMonitors.CheckState = System.Windows.Forms.CheckState.Unchecked;
					this.chkKitchenMonitors.Tag = 0;
				}
			}
			bolLoad = false;

			//Bind the check boxes to the data provider
			foreach (CheckBox oCheck_loopVariable in chkFields) {
				oCheck = oCheck_loopVariable;
				oCheck.DataBindings.Add(adoPrimaryRS);
			}
			buildDataControls();

			 // ERROR: Not supported in C#: OnErrorStatement

			if (id) {
			} else {
				cmbKeyboard.BoundText = Convert.ToString(2);
				cmbWH.BoundText = Convert.ToString(2);
			}
			mbDataChanged = false;

			loadLanguage();
			ShowDialog();
		}

		private void setup()
		{
		}

//UPGRADE_WARNING: Event chkKitchenMonitors.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void chkKitchenMonitors_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (bolLoad == true) {
			} else {
				if (chkKitchenMonitors.CheckState == 1) {

					if (Interaction.MsgBox("Are you sure, you want to use this Terminal for Drive Thru OR as a Kitchen Monitor only?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes) {
					} else {
						chkKitchenMonitors.CheckState = System.Windows.Forms.CheckState.Unchecked;
					}
				}
			}
		}

		private void cmdLocate_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			CommonDialog1Open.FileName = "";
			CommonDialog1Open.ShowDialog();
			if (!string.IsNullOrEmpty(CommonDialog1Open.FileName)) {
				//If AddDSN("4POS", "4POS data", CommonDialog1.FileName, True) Then
				if (modRecordSet.openSComp(ref CommonDialog1Open.FileName) == null) {
					Interaction.MsgBox("Waitron Database is not valid, Chooose correct database.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				} else {
					_txtInteger_1.Text = Strings.Split(Strings.LCase(CommonDialog1Open.FileName), "waitron.mdb")[0];
				}
				//End If
			}
		}

//UPGRADE_WARNING: Event frmPOS.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void frmPOS_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			Button cmdLast = new Button();
			Button cmdnext = new Button();
			Label lblStatus = new Label();
			 // ERROR: Not supported in C#: OnErrorStatement

			lblStatus.Width = sizeConvertors.pixelToTwips(this.Width, true) - 1500;
			cmdnext.Left = lblStatus.Width + 700;
			cmdLast.Left = cmdnext.Left + 340;
		}
		private void frmPOS_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
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

		private void frmPOS_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
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
				foreach (TextBox oText_loopVariable in this.txtFloat) {
					oText = oText_loopVariable;
					if (string.IsNullOrEmpty(oText.Text))
						oText.Text = "0";
					oText.Text = oText.Text * 100;
					//txtFloat_Leave(txtFloat.Item(oText.SelectedIndex), New System.EventArgs())
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
				Interaction.MsgBox("POS Number [ " + Conversion.Val(_txtInteger_0.Text) + " ] exist already, Chooose another number", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
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
			int x = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rj = default(ADODB.Recordset);
			string lCode = null;
			string leCode = null;
			string lPassword = null;

			if (modApplication.nwPOS == true) {
				rs = modRecordSet.getRS(ref "Select * FROM POS WHERE POS_Name = '" + Strings.Trim(_txtFields_1.Text) + "'");
				if (rs.RecordCount > 0) {
					Interaction.MsgBox("POS Name [ " + _txtFields_1.Text + " ] exist already, Chooose another name", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					return;
				}
				//-------------------------
				rs = modRecordSet.getRS(ref "Select * FROM POS WHERE POSID = " + Conversion.Val(_txtInteger_0.Text));
				if (rs.RecordCount > 0) {
					Interaction.MsgBox("POS Number [ " + Conversion.Val(_txtInteger_0.Text) + " ] exist already, Chooose another number", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					return;
				}

				rs = modRecordSet.getRS(ref "Select * FROM POS WHERE POS_IPAddress = '" + Strings.Trim(_txtFields_3.Text) + "'");
				if (rs.RecordCount > 0) {
					Interaction.MsgBox("POS IP Address [ " + Strings.Trim(_txtFields_3.Text) + " ] exist already, Chooose another IP Address", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					return;
				}
				//-------------------------
			}

			if (string.IsNullOrEmpty(_txtFields_1.Text)) {
				Interaction.MsgBox("POS Name cannot be blank, enter Point Of Sale name", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				return;
			}
			if (Conversion.Val(_txtInteger_0.Text) == 0) {
				Interaction.MsgBox("Please enter another POS Number other than 0", MsgBoxStyle.Information + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				return;
			}

			if (string.IsNullOrEmpty(_txtFields_3.Text)) {
				Interaction.MsgBox("POS IP Address cannot be blank, enter POS IP Address", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				return;
			}


			cmdClose.Focus();
			System.Windows.Forms.Application.DoEvents();

			if (update_Renamed()) {
				if (k_posNew == false) {
					modRecordSet.cnnDB.Execute("UPDATE POS SET POS_KitchenMonitor = " + Conversion.Val(Convert.ToString(this.chkKitchenMonitors.CheckState)) + " WHERE POSID = " + k_posID);
				} else {
					modRecordSet.cnnDB.Execute("UPDATE POS SET POS_KitchenMonitor = " + Conversion.Val(Convert.ToString(this.chkKitchenMonitors.CheckState)) + " WHERE POSID = " + Conversion.Val(_txtInteger_0.Text));

					rj = modRecordSet.getRS(ref "Select Company_Name FROM Company;");
					if (rj.RecordCount > 0) {
						lPassword = Strings.LTrim(Strings.Replace(rj.Fields("Company_Name").Value, "'", ""));
						lPassword = Strings.RTrim(Strings.Replace(lPassword, " ", ""));
						lPassword = Strings.Trim(Strings.Replace(lPassword, ".", ""));
						lPassword = Strings.LCase(lPassword);
						leCode = "";
						lCode = "";
						for (x = 1; x <= Strings.Len(lPassword); x++) {
							lCode = Strings.Mid(lPassword, x, 1);
							lCode = Convert.ToString(Strings.Asc(lCode));
							if (Convert.ToDouble(lCode) > 96 & Convert.ToDouble(lCode) < 123) {
								leCode = leCode + Strings.Mid(lPassword, x, 1);
							}
						}
						lPassword = leCode;
						rs = modRecordSet.getRS(ref "SELECT * FROM POS WHERE POSID = " + Conversion.Val(_txtInteger_0.Text) + ";");
						if (rs.RecordCount) {
							lCode = Convert.ToString(rs.Fields("POS_CID").Value * 135792468);
							leCode = Encrypt(lCode, lPassword);
							leCode = leCode + Strings.Chr(255) + _txtFields_10.Text;
							modRecordSet.cnnDB.Execute("UPDATE POS SET POS.POS_Code = '" + Strings.Replace(leCode, "'", "''") + "' WHERE POS.POS_CID=" + rs.Fields("POS_CID").Value + ";");
							//cnnDB.Execute "UPDATE POS SET POS.POS_Code = '" & Replace(leCode, "'", "''") & "' WHERE POSID = " & Val(_txtInteger_0.Text) & ";"
						}
					}
				}
				modApplication.nwPOS = false;
				this.Close();
			}
		}

		private string getSerialNumber()
		{
			string functionReturnValue = null;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			Scripting.Folder fsoFolder = default(Scripting.Folder);
			Scripting.Drive fsoDrive = default(Scripting.Drive);
			functionReturnValue = "";
			if (fso.FolderExists(modRecordSet.serverPath)) {
				fsoFolder = fso.GetFolder(modRecordSet.serverPath);
				functionReturnValue = Convert.ToString(fsoFolder.Drive.SerialNumber);
			}
			return functionReturnValue;
		}

		private string Encrypt(string secret, string PassWord)
		{
			int l = 0;
			short x = 0;
			string Char_Renamed = null;
			l = Strings.Len(PassWord);
			for (x = 1; x <= Strings.Len(secret); x++) {
				Char_Renamed = Convert.ToString(Strings.Asc(Strings.Mid(PassWord, (x % l) - l * Convert.ToInt16((x % l) == 0), 1)));
				Strings.Mid(secret, x, 1) = Strings.Chr(Strings.Asc(Strings.Mid(secret, x, 1)) ^ Char_Renamed);
			}
			return secret;
		}

		private bool checkSecurity()
		{
			bool functionReturnValue = false;
			string lCode = null;
			string leCode = null;
			string lPassword = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			short x = 0;
			functionReturnValue = false;
			if (modRecordSet.openConnection()) {
				rs = modRecordSet.getRS(ref "SELECT * From Company");
				if (rs.RecordCount) {
					if (Information.IsNumeric(rs.Fields("Company_Code").Value)) {
						modApplication.gSecKey = rs.Fields("Company_Code").Value;
						if (Strings.Len(rs.Fields("Company_Code").Value) == 13) {

							functionReturnValue = true;
							return functionReturnValue;
						}
					}
					lPassword = "pospospospos";
					lCode = getSerialNumber();
					if (lCode == "0" & Strings.LCase(Strings.Left(modRecordSet.serverPath, 3)) != "c:\\" & !string.IsNullOrEmpty(rs.Fields("Company_Code").Value)) {
						functionReturnValue = true;
					} else {
						leCode = Encrypt(lCode, lPassword);
						for (x = 1; x <= Strings.Len(leCode); x++) {
							if (Strings.Asc(Strings.Mid(leCode, x, 1)) < 33) {
								leCode = Strings.Left(leCode, x - 1) + Strings.Chr(33) + Strings.Mid(leCode, x + 1);
							}
						}

						if (rs.Fields("Company_Code").Value == leCode) {
							//If IsNull(rs("Company_TerminateDate")) Then
							functionReturnValue = true;
							return functionReturnValue;
							//Else
							//    If Date > rs("Company_TerminateDate") Then
							//        cnnDB.Execute "UPDATE Company SET Company.Company_Code = '';"
							//        checkSecurity = False
							//   End If
							//End If
						} else {
							//txtCompany.Text = rs("Company_Name")
							//txtCompany.SelStart = 0
							//txtCompany.SelLength = 999
							//show 1
						}

					}
				} else {
					Interaction.MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS");
					System.Environment.Exit(0);
				}
			} else {
				Interaction.MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS");
				System.Environment.Exit(0);
			}
			return functionReturnValue;
		}

		//Handles lblLic.Click
		private void lblLic_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			Label lbl = new Label();
			lbl = (Label)eventSender;
			int Index = GetIndex.GetIndexer(ref lbl, ref lblLic);
			ADODB.Recordset rs = default(ADODB.Recordset);
			int x = 0;
			ADODB.Recordset rj = default(ADODB.Recordset);
			string lCode = null;
			string leCode = null;
			string lPassword = null;

			if (checkSecurity() == true) {
				basCryptoProcs.strCDKey = "";
				if (My.MyProject.Forms.frmPOSCode.setupCode() == true) {
					//_txtFields_10.Text = strCDKey
					rj = modRecordSet.getRS(ref "Select Company_Name FROM Company;");
					if (rj.RecordCount > 0) {
						lPassword = Strings.LTrim(Strings.Replace(rj.Fields("Company_Name").Value, "'", ""));
						lPassword = Strings.RTrim(Strings.Replace(lPassword, " ", ""));
						lPassword = Strings.Trim(Strings.Replace(lPassword, ".", ""));
						lPassword = Strings.LCase(lPassword);
						leCode = "";
						lCode = "";
						for (x = 0; x <= Strings.Len(lPassword); x++) {
							lCode = Strings.Mid(lPassword, x, 1);
							lCode = Convert.ToString(Strings.Asc(lCode));
							if (Convert.ToDouble(lCode) > 96 & Convert.ToDouble(lCode) < 123) {
								leCode = leCode + Strings.Mid(lPassword, x, 1);
							}
						}
						lPassword = leCode;
						rs = modRecordSet.getRS(ref "SELECT * FROM POS WHERE POSID = " + Conversion.Val(_txtInteger_0.Text) + ";");
						if (rs.RecordCount) {
							lCode = Convert.ToString(rs("POS_CID").Value * 135792468);
							leCode = Encrypt(lCode, lPassword);
							leCode = leCode + Strings.Chr(255) + basCryptoProcs.strCDKey;
							//_txtFields_10.Text
							modRecordSet.cnnDB.Execute("UPDATE POS SET POS.POS_Code = '" + Strings.Replace(leCode, "'", "''") + "' WHERE POS.POS_CID=" + rs("POS_CID").Value + ";");

							basCryptoProcs.strCDKey = "";
							//cmdClose.SetFocus
							//cmdClose_Click
							lblLic[0].Visible = false;
							lblLic[1].Visible = false;
						}
					}
				}
				basCryptoProcs.strCDKey = "";
			} else {
				Interaction.MsgBox("POS units may only be licensed with registered versions of your 4POS system." + Constants.vbCrLf + "Please contact your 4POS representative or www.4pos.co.za.", MsgBoxStyle.Critical, "Software is not Registered");
			}


		}

		// Handles txtFields.Enter
		private void txtFields_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txtbox = new TextBox();
			txtbox = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txtbox, ref txtFields);
			modUtilities.MyGotFocus(ref txtFields[Index]);
		}
		// Handles txtInteger.Enter
		private void txtInteger_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txtbox = new TextBox();
			txtbox = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txtbox, ref txtInteger);
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
		//Handles txtInteger.Leave
		private void txtInteger_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txtbox = new TextBox();
			txtbox = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txtbox, ref txtInteger);
			modUtilities.MyLostFocus(ref txtInteger[Index], ref 0);
		}
		//Handles txtFloat.Enter
		private void txtFloat_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txtbox = new TextBox();
			txtbox = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txtbox, ref txtFloat);
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
			TextBox txtbox = new TextBox();
			txtbox = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txtbox, ref txtFloat);
			modUtilities.MyLostFocus(ref txtFloat[Index], ref 2);
		}
		private void txtFloatNegative_MyGotFocus(ref short Index)
		{
			//MyGotFocusNumeric txtFloatNegative(Index)
		}
		private void txtFloatNegative_KeyPress(ref short Index, ref short KeyAscii)
		{
			//KeyPressNegative txtFloatNegative(Index), KeyAscii
		}
		private void txtFloatNegative_MyLostFocus(ref short Index)
		{
			//LostFocus txtFloatNegative(Index), 2
		}

		private void frmPOS_Load(object sender, System.EventArgs e)
		{
			txtFloat.AddRange(new TextBox[] { _txtFloat_5 });
			_txtFloat_5.Enter += txtFloat_Enter;
			_txtFloat_5.KeyPress += txtFloat_KeyPress;
			txtInteger.AddRange(new TextBox[] {
				_txtInteger_0,
				_txtInteger_1,
				_txtInteger_4
			});
			txtFields.AddRange(new TextBox[] {
				_txtFields_1,
				_txtFields_3,
				_txtFields_10
			});
			chkFields.AddRange(new CheckBox[] { _chkFields_2 });
			lblLic.AddRange(new Label[] {
				_lblLic_0,
				_lblLic_1
			});
			TextBox tb = new TextBox();
			Label lb = new Label();
			foreach (TextBox tb_loopVariable in txtInteger) {
				tb = tb_loopVariable;
				tb.Enter += txtInteger_Enter;
				tb.KeyPress += txtInteger_KeyPress;
			}
			foreach (TextBox tb_loopVariable in txtFields) {
				tb = tb_loopVariable;
				tb.Enter += txtFields_Enter;
			}
			foreach (Label lb_loopVariable in lblLic) {
				lb = lb_loopVariable;
				lb.Click += lblLic_Click;
			}
		}
	}
}
