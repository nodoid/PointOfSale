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
	internal partial class frmFloatRepre : System.Windows.Forms.Form
	{
			//Save Default ....
		int g_Default;
		int g_Defailt2;
		int grsKey_ID;
		int g_FloatU;
		bool g_Enough;
		bool g_NewKy;
		bool g_FloatU_1;
		bool g_floatSet;

		bool grsKeyboard;

		List<TextBox> txtFloat = new List<TextBox>();

		private void loadLanguage()
		{
			//frmFloatRepre = No Code    [Denomination Details]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmFloatRepre.Caption = rsLang("LanguageLayoutLnk_Description"): frmFloatRepre.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){Command1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Command1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//Label1 = No Code           [Float Details]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label3 = No Code           [Float Name]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label3.Caption = rsLang("LanguageLayoutLnk_Description"): Label3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label5 = No Code           [Float Type]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label5.Caption = rsLang("LanguageLayoutLnk_Description"): COMPONENT(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label9 = No Code           [Float Value]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label9.Caption = rsLang("LanguageLayoutLnk_Description"): Label9.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label4 = No Code           [Float Pack]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label4.Caption = rsLang("LanguageLayoutLnk_Description"): Label4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label8 = No Code           [Change Float Type]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label8.Caption = rsLang("LanguageLayoutLnk_Description"): Label8.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkDisable = No Code       [Float Disabled]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkDisable.Caption = rsLang("LanguageLayoutLnk_Description"): chkDisable.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label2 = No Code           [Preset Details]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label2.Caption = rsLang("LanguageLayoutLnk_Description"): Label2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//chkKey = No Code           [Float set as a Fast Preset Tender on POS]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then chkKey.Caption = rsLang("LanguageLayoutLnk_Description"): chkKey.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label6 = No Code           [Keyboard Name]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label6.Caption = rsLang("LanguageLayoutLnk_Description"): Label6.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Label7 = No Code           [Keyboard Key(s)]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label7.Caption = rsLang("LanguageLayoutLnk_Description"): Label7.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmFloatRepre.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public void loadItem(ref int id)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rt = default(ADODB.Recordset);
			ADODB.Recordset rk = default(ADODB.Recordset);

			g_floatSet = false;

			rs = modRecordSet.getRS(ref "SELECT * FROM [Float] WHERE Float.Float_Unit = " + Convert.ToInt32(id) + ";");
			if (rs.RecordCount) {

				g_FloatU = Convert.ToInt32(id);
				_txtFloat_0.Text = rs.Fields("Float_Name").Value;
				//_txtFloat_1.Text = rs("Float_Pack")
				_txtFloat_1.Text = Strings.FormatNumber(rs.Fields("Float_Pack").Value);
				g_Defailt2 = Convert.ToDouble(Strings.FormatNumber(rs.Fields("Float_Pack").Value)) * 100;

				//If rs("Float_Type") = True Then
				//   _txtFloat_2.Text = "Note"
				if (rs.Fields("Float_Type").Value == true) {
					_txtFloat_2.Text = "Note";
					this.cbmChangeType.SelectedIndex = 1;
				} else {
					_txtFloat_2.Text = "Coin";
					this.cbmChangeType.SelectedIndex = 0;
				}
				//Do presets....
				rt = modRecordSet.getRS(ref "SELECT Float.*, tblPresetTender.* FROM tblPresetTender INNER JOIN [Float] ON tblPresetTender.tblValue = Float.Float_Unit WHERE Float.Float_Unit = " + Convert.ToInt32(id) + ";");
				if (rt.RecordCount) {
					rk = modRecordSet.getRS(ref "SELECT keyboard.keyboard_Name,keyboard.keyboard_Description, keyboard.keyboard_Show,keyboard.keyboardID FROM tblPresetTender INNER JOIN keyboard ON tblPresetTender.tblKey = keyboard.KeyboardID WHERE tblPresetTender.tblValue = " + Convert.ToInt32(id) + ";");
					if (rk.RecordCount) {
						g_Enough = false;
						_txtKey_0.Text = rk.Fields("keyboard_Name").Value;
						grsKey_ID = rk.Fields("keyboardID").Value;

						rk = modRecordSet.getRS(ref "SELECT KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_Description FROM KeyboardKeyboardLayoutLnk WHERE KeyboardKeyboardLayoutLnk_KeyboardID = " + rk.Fields("keyboardID").Value + ";");
						//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						if (Information.IsDBNull(rk.Fields("KeyboardKeyboardLayoutLnk_Description").Value)) {
						} else {
							_txtKey_1.Text = rk.Fields("KeyboardKeyboardLayoutLnk_Description").Value;
						}

						if (rt.Fields("tblActivated").Value == true) {
							g_FloatU_1 = true;
							chkKey.CheckState = System.Windows.Forms.CheckState.Checked;
							chkKey.Tag = 1;
						} else {
							g_FloatU_1 = false;
							chkKey.CheckState = System.Windows.Forms.CheckState.Unchecked;
							chkKey.Tag = 0;
						}
					} else {
						g_Enough = true;
					}
				} else {
					//Check if there is option for new Preset....
					rt = modRecordSet.getRS(ref "SELECT * FROM tblPresetTender WHERE tblKey >= 5000 AND tblActivated = False");

					if (rt.RecordCount) {
						g_Enough = true;
						g_FloatU_1 = false;
						chkKey.CheckState = System.Windows.Forms.CheckState.Unchecked;
						chkKey.Tag = 0;
						_txtKey_0.Enabled = false;
						_txtKey_1.Enabled = false;
					} else {
						g_Enough = true;
						g_FloatU_1 = false;
						chkKey.CheckState = System.Windows.Forms.CheckState.Unchecked;
						chkKey.Tag = 0;
						chkKey.Enabled = false;
						_txtKey_0.Enabled = false;
						_txtKey_1.Enabled = false;
					}

				}


				g_Default = rs.Fields("Float_unit").Value;
				_txtFloat_3.Text = Strings.FormatNumber(rs.Fields("Float_unit").Value / 100);

				if (rs.Fields("Float_Disabled").Value == true) {
					chkDisable.CheckState = System.Windows.Forms.CheckState.Checked;
					chkDisable.Tag = 1;
				} else {
					chkDisable.CheckState = System.Windows.Forms.CheckState.Unchecked;
					chkDisable.Tag = 0;
				}

			}
			g_floatSet = true;

			loadLanguage();
			ShowDialog();
		}
		private void chkKey_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			string st1 = null;
			string grsKeyID = null;
			ADODB.Recordset rs = default(ADODB.Recordset);

			 // ERROR: Not supported in C#: OnErrorStatement


			if (g_floatSet == true) {
				if (g_Enough == false) {
					return;
				}

				if (g_Enough == true) {
					rs = modRecordSet.getRS(ref "SELECT * FROM tblPresetTender WHERE tblKey >= 5000 AND tblActivated = False");
					if (rs.RecordCount) {
						grsKeyID = rs.Fields("tblkey").Value;
						_txtKey_0.Text = this._txtFloat_0.Text;
						grsKey_ID = rs.Fields("tblKey").Value;
						g_NewKy = true;
					} else {
						st1 = "You've already allocated enough presets on your POS.";
						st1 = st1 + "To allocate a new one please disable anyone.";
						Interaction.MsgBox(st1, MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "New Preset");
						return;
					}
				}
			}
		}
		private void Command1_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int dValue_1 = 0;
			short stType = 0;
			ADODB.Recordset rj = default(ADODB.Recordset);
			 // ERROR: Not supported in C#: OnErrorStatement


			if (!string.IsNullOrEmpty(_txtKey_1.Text)) {
				if (string.IsNullOrEmpty(_txtKey_0.Text)) {
					Interaction.MsgBox("Keyboard Name is a required filed", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Preset Tender");
					return;
				} else {
					if (g_Enough == true) {
					} else {
						modRecordSet.cnnDB.Execute("UPDATE Keyboard Set keyboard_Name = '" + Strings.Replace(_txtKey_0.Text, "'", "''") + "', keyboard_Description = '" + Strings.Replace(_txtKey_0.Text, "'", "''") + "' WHERE keyboardID = " + grsKey_ID + ";");
						modRecordSet.cnnDB.Execute("UPDATE tblPresetTender SET tblDescription ='" + Strings.Replace(_txtKey_0.Text, "'", "''") + "',tblActivated = " + Conversion.Val(Convert.ToString(this.chkKey.CheckState)) + " WHERE tblKey = " + grsKey_ID + ";");
					}
				}
			}

			if (!string.IsNullOrEmpty(_txtFloat_0.Text)) {
				dValue_1 = Convert.ToInt32(Convert.ToDouble(Strings.FormatNumber(_txtFloat_3.Text)) * 100);
				if (!string.IsNullOrEmpty(this.cbmChangeType.Text)) {
					if (this.cbmChangeType.Text == "Coin")
						stType = 0;
					else
						stType = 1;
					modRecordSet.cnnDB.Execute("UPDATE [Float] Set Float.Float_Type = " + stType + ", Float.Float_Name = '" + Strings.Replace(this._txtFloat_0.Text, "'", "''") + "', Float.Float_Disabled = " + Conversion.Val(Convert.ToString(this.chkDisable.CheckState)) + ", Float.Float_Pack = " + Convert.ToInt32(_txtFloat_1.Text) + " WHERE Float.Float_Unit = " + g_FloatU + ";");
				} else {
					modRecordSet.cnnDB.Execute("UPDATE [Float] Set Float.Float_Name = '" + Strings.Replace(this._txtFloat_0.Text, "'", "''") + "', Float.Float_Disabled = " + Conversion.Val(Convert.ToString(this.chkDisable.CheckState)) + ", Float.Float_Pack = " + Convert.ToInt32(_txtFloat_1.Text) + " WHERE Float.Float_Unit = " + g_FloatU + ";");
				}

				if (g_Default == dValue_1) {

				} else if (dValue_1 == 0) {
				} else {
					rj = modRecordSet.getRS(ref "SELECT * FROM [Float] WHERE Float.Float_Unit = " + dValue_1 + ";");
					if (rj.RecordCount) {
						Interaction.MsgBox("Denomination with this Float Unit/Amount exist already, New Amount would not be updated", MsgBoxStyle.Information + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "New Denomination");
					} else {
						modRecordSet.cnnDB.Execute("UPDATE [Float] Set Float.Float_Unit = " + dValue_1 + " WHERE Float.Float_Unit = " + g_FloatU + ";");
					}
				}

			}

			if (g_FloatU_1 == true) {

				if (g_Enough == true) {
				} else {

					modRecordSet.cnnDB.Execute("UPDATE tblPresetTender SET tblActivated = " + Conversion.Val(Convert.ToString(this.chkKey.CheckState)) + " WHERE tblKey = " + grsKey_ID + ";");
				}

			}

			if (g_NewKy == true) {
				modRecordSet.cnnDB.Execute("UPDATE Keyboard Set keyboard_Name = '" + Strings.Replace(_txtKey_0.Text, "'", "''") + "', keyboard_Description = '" + Strings.Replace(_txtKey_0.Text, "'", "''") + "', keyboard_Show = 1 WHERE keyboardID = " + grsKey_ID + ";");
				modRecordSet.cnnDB.Execute("UPDATE tblPresetTender SET tblDescription ='" + Strings.Replace(_txtKey_0.Text, "'", "''") + "',tblValue =" + g_FloatU + ", tblActivated = 1 WHERE tblKey = " + grsKey_ID + ";");
				g_NewKy = false;
			}

			this.Close();
		}
		public void LostFocus1(ref Control lControl, ref int lDecimal)
		{
			if (string.IsNullOrEmpty(lControl.Text))
				return;
			if (lDecimal) {
				lControl.Text = lControl.Text / 100;
			}
			//lControl.Text = FormatNumber(lControl.Text, lDecimal)
			lControl.Text = Strings.FormatNumber(lControl.Text);
		}


		private void txtFloat_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			int index = 0;
			TextBox n = null;
			n = (TextBox)eventSender;
			index = GetIndex.GetIndexer(ref n, ref txtFloat);
			if (index == 1 | index == 3) {
				modUtilities.MyGotFocusNumeric(ref txtFloat[index]);
			}
		}
		private void txtFloat_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			int index = 0;
			TextBox n = null;
			n = (TextBox)eventSender;
			index = GetIndex.GetIndexer(ref n, ref txtFloat);
			if (index == 1 | index == 3) {
				modUtilities.MyKeyPress(ref KeyAscii);
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
		private void txtFloat_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			int index = 0;
			TextBox n = null;
			n = (TextBox)eventSender;
			index = GetIndex.GetIndexer(ref n, ref txtFloat);
			string g_Defailt = null;
			if (index == 1) {
				if (string.IsNullOrEmpty(_txtFloat_1.Text)) {
					_txtFloat_1.Text = Convert.ToString(g_Defailt2);
				}

				if (!string.IsNullOrEmpty(_txtFloat_1.Text)) {
					if (Convert.ToDouble(Strings.FormatNumber(_txtFloat_1.Text)) == 0) {
						_txtFloat_1.Text = Convert.ToString(g_Defailt2);
					} else if (Convert.ToInt32(Convert.ToDouble(Strings.FormatNumber(_txtFloat_1.Text)) / 100) == 0) {
						_txtFloat_1.Text = Convert.ToString(g_Defailt2);
					}
				}
				LostFocus1(ref _txtFloat_1, ref 2);
			}

			if (index == 3) {
				if (string.IsNullOrEmpty(txtFloat[3].Text)) {
					txtFloat[3].Text = Convert.ToString(g_Default);
				}

				if (!string.IsNullOrEmpty(txtFloat[3].Text)) {
					if (Convert.ToDouble(Strings.FormatNumber(txtFloat[3].Text)) == 0) {
						txtFloat[3].Text = Convert.ToString(g_Default);
					} else if (Convert.ToInt32(Convert.ToDouble(Strings.FormatNumber(txtFloat[3].Text)) / 100) == 0) {
						//UPGRADE_WARNING: Couldn't resolve default property of object g_Defailt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						txtFloat[3].Text = g_Defailt;
					}

				}
				LostFocus1(ref txtFloat[3], ref 2);
			}


		}

		private void frmFloatRepre_Load(object sender, System.EventArgs e)
		{
			txtFloat.AddRange(new TextBox[] {
				_txtFloat_0,
				_txtFloat_1,
				_txtFloat_2,
				_txtFloat_3
			});
			TextBox tb = new TextBox();
			foreach (TextBox tb_loopVariable in txtFloat) {
				tb = tb_loopVariable;
				tb.Enter += txtFloat_Enter;
				tb.KeyPress += txtFloat_KeyPress;
				tb.Leave += txtFloat_Leave;
			}
		}
	}
}
