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
namespace _4PosBackOffice.NET
{
	internal partial class frmKeyboard : System.Windows.Forms.Form
	{
		int gParentID;
		bool grClick;

		private void loadLanguage()
		{

			//frmKeyboard = No Code  [Keyboard Layout Editor]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmKeyboard(0).Caption = rsLang("LanguageLayoutLnk_Description"): frmKeyboard.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1085;
			//Print|Checked
			if (modRecordSet.rsLang.RecordCount){cmdPrint.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPrint.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//Label1 = No Code       [Keyboard Name]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmKeyboard.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void loadKeys()
		{
			string sql = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			int x = 0;
			string kS = null;

			gridEdit.RowCount = 1;
			rs = modRecordSet.getRS(ref "SELECT KeyboardLayout.KeyboardLayoutID, KeyboardLayout.KeyboardLayout_Name From KeyboardLayout WHERE (((KeyboardLayout.KeyboardLayoutID)=" + gParentID + "));");
			if (rs.RecordCount) {
				modRecordSet.cnnDB.Execute("INSERT INTO KeyboardKeyboardLayoutLnk ( KeyboardKeyboardLayoutLnk_KeyboardID, KeyboardKeyboardLayoutLnk_KeyboardLayoutID, KeyboardKeyboardLayoutLnk_Shift, KeyboardKeyboardLayoutLnk_Key, KeyboardKeyboardLayoutLnk_Description ) SELECT theJoin.KeyboardID, theJoin.KeyboardLayoutID, 0 AS Expr1, 0 AS Expr2, 'None' AS Expr3 FROM (SELECT keyboard.KeyboardID, KeyboardLayout.KeyboardLayoutID From keyboard, KeyboardLayout WHERE (((KeyboardLayout.KeyboardLayoutID)=" + gParentID + "))) AS theJoin LEFT JOIN KeyboardKeyboardLayoutLnk ON (theJoin.KeyboardID = KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_KeyboardID) AND (theJoin.KeyboardLayoutID = KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_KeyboardLayoutID) WHERE (((KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_KeyboardID) Is Null));");
				sql = "UPDATE KeyboardKeyboardLayoutLnk AS KeyboardKeyboardLayoutLnk_1 INNER JOIN KeyboardKeyboardLayoutLnk ON KeyboardKeyboardLayoutLnk_1.KeyboardKeyboardLayoutLnk_KeyboardID = KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_KeyboardID SET KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_Shift = [KeyboardKeyboardLayoutLnk_1]![KeyboardKeyboardLayoutLnk_Shift], KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_Key = [KeyboardKeyboardLayoutLnk_1]![KeyboardKeyboardLayoutLnk_Key], KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_Description = [KeyboardKeyboardLayoutLnk_1]![KeyboardKeyboardLayoutLnk_Description] ";
				sql = sql + "WHERE (((KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_Shift)=0) AND ((KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_Key)=0) AND ((KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_KeyboardLayoutID)=" + gParentID + ") AND ((KeyboardKeyboardLayoutLnk_1.KeyboardKeyboardLayoutLnk_KeyboardLayoutID)=1));";

				if (gParentID != 1)
					modRecordSet.cnnDB.Execute(sql);

				this.txtName.Text = rs.Fields("KeyboardLayout_Name").Value;
				rs = modRecordSet.getRS(ref "SELECT keyboard.*, KeyboardKeyboardLayoutLnk.* FROM KeyboardKeyboardLayoutLnk INNER JOIN keyboard ON KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_KeyboardID = keyboard.KeyboardID Where (((KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_KeyboardLayoutID) = " + gParentID + ")) ORDER BY keyboard.keyboard_Order, keyboard.keyboard_Name;");
				gridEdit.RowCount = rs.RecordCount + 1;
				x = 0;
				while (!(rs.EOF)) {
					x = x + 1;
					gridEdit.row = x;
					gridEdit.Col = 0;
					gridEdit.Text = rs.Fields("keyboard_Name").Value;
					gridEdit.CellAlignment = 1;

					gridEdit.Col = 1;
					gridEdit.Text = getKeyDescription(ref rs.Fields("KeyboardKeyboardLayoutLnk_Key").Value, ref rs.Fields("KeyboardKeyboardLayoutLnk_Shift").Value);
					gridEdit.Col = 2;
					gridEdit.Text = rs.Fields("KeyboardKeyboardLayoutLnk_Shift").Value;
					gridEdit.Col = 3;
					gridEdit.Text = rs.Fields("KeyboardKeyboardLayoutLnk_Key").Value;
					gridEdit.set_RowData(ref gridEdit.row, ref rs.Fields("KeyboardKeyboardLayoutLnk_KeyboardID").Value);
					gridEdit.Col = 4;
					gridEdit.Text = rs.Fields("Keyboard_Order").Value;
					gridEdit.set_RowData(ref gridEdit.row, ref rs.Fields("KeyboardKeyboardLayoutLnk_KeyboardID").Value);
					gridEdit.Col = 5;
					if (rs.Fields("keyboard_Show").Value == true) {
						kS = "Yes";
					} else {
						kS = "No";
					}
					gridEdit.Text = Strings.UCase(kS);
					gridEdit.Col = 6;
					gridEdit.Text = rs.Fields("KeyboardID").Value;
					gridEdit.set_RowData(ref gridEdit.row, ref rs.Fields("KeyboardKeyboardLayoutLnk_KeyboardID").Value);
					rs.moveNext();
				}
			}
		}

		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modRecordSet.cnnDB.Execute("UPDATE KeyboardLayout SET KeyboardLayout.KeyboardLayout_Name = '" + Strings.Replace(txtName.Text, "'", "''") + "' WHERE (((KeyboardLayout.KeyboardLayoutID)=" + gParentID + "));");
			this.Close();
		}

		public void loadItem(ref int lParentID)
		{
			gParentID = lParentID;
			loadKeys();

			loadLanguage();
			ShowDialog();
		}

		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			//Dim Report As New cryKeyboardName
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			Report.Load("cryKeyboardName.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();

			rs = modRecordSet.getRS(ref "SELECT KeyboardLayout.KeyboardLayout_Name, keyboard.keyboard_Name, KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_Description, keyboard.keyboard_Order, keyboard.keyboard_Show FROM (KeyboardKeyboardLayoutLnk INNER JOIN keyboard ON KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_KeyboardID = keyboard.KeyboardID) INNER JOIN KeyboardLayout ON KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_KeyboardLayoutID = KeyboardLayout.KeyboardLayoutID Where (((KeyboardLayout.KeyboardLayoutID) = " + gParentID + ")) ORDER BY keyboard.keyboard_Order, keyboard.keyboard_Name;");

			//ReportNone.Load("cryNoRecords.rpt")
			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			ReportNone.Load("cryNoRecords.rpt");
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
			Report.Database.Tables(0).SetDataSource(rs);
			Report.Database.Tables(1).SetDataSource(rs);
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();
		}

		private void frmKeyboard_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			grClick = true;
			var _with1 = gridEdit;
			_with1.Col = 7;
			_with1.RowCount = 0;
			System.Windows.Forms.Application.DoEvents();
			_with1.RowCount = 2;
			_with1.FixedRows = 1;
			_with1.FixedCols = 0;
			_with1.row = 0;
			_with1.Col = 0;
			_with1.CellFontBold = true;
			_with1.Text = "Action";
			_with1.set_ColWidth(0, 3000);
			_with1.CellAlignment = 3;

			_with1.Col = 1;
			_with1.CellFontBold = true;
			_with1.Text = "Key";
			_with1.set_ColWidth(1, 800);
			_with1.CellAlignment = 4;

			_with1.Col = 2;
			_with1.CellFontBold = true;
			_with1.Text = "Special";
			_with1.set_ColWidth(2, 0);
			_with1.CellAlignment = 1;

			_with1.Col = 3;
			_with1.CellFontBold = true;
			_with1.Text = "Keycode";
			_with1.set_ColWidth(3, 0);
			_with1.CellAlignment = 1;

			_with1.Col = 4;
			_with1.CellFontBold = true;
			_with1.Text = "Display";
			_with1.set_ColWidth(4, 800);
			_with1.CellAlignment = 1;

			_with1.Col = 5;
			_with1.CellFontBold = true;
			_with1.Text = "Show";
			_with1.set_ColWidth(5, 800);
			_with1.CellAlignment = 1;

			_with1.Col = 6;
			_with1.CellFontBold = true;
			_with1.Text = "KEY";
			_with1.set_ColWidth(6, 0);
			_with1.CellAlignment = 1;


		}

		public object getKeyDescription(ref short KeyCode, ref short Shift)
		{
			string lShift = null;
			string lKey = null;
			switch (KeyCode) {
				case 16:
				case 17:
				case 18:
					break;
				case 112:
				case 113:
				case 114:
				case 115:
				case 116:
				case 117:
				case 118:
				case 119:
				case 120:
				case 121:
				case 122:
				case 123:
					lKey = "F" + KeyCode - 111;
					break;
				case 37:
					lKey = "Left";
					break;
				case 38:
					lKey = "Up";
					break;
				case 39:
					lKey = "Right";
					break;
				case 40:
					lKey = "Down";
					break;
				case 27:
					lKey = "Esc";
					break;
				case 13:
					lKey = "Enter";
					break;
				case 35:
					lKey = "End";
					break;
				case 34:
					lKey = "PgDn";
					break;
				case 33:
					lKey = "PgUp";
					break;
				case 36:
					lKey = "Home";
					break;
				case 46:
					lKey = "Del";
					break;
				case 45:
					lKey = "Ins";
					break;
				case 19:
					lKey = "Pause";
					break;
				case 9:
					lKey = "Tab";
					break;
				case 8:
					lKey = "Back Space";
					break;
				default:
					lKey = Strings.Chr(KeyCode);
					break;
			}
			switch (Shift) {
				case 1:
					lShift = "Shift+";
					break;
				case 2:
					lShift = "Ctrl+";
					break;
				case 4:
					lShift = "Alt+";
					break;
				default:
					lShift = "";
					break;
			}
			return lShift + lKey;
		}

		private void gridEdit_ClickEvent(System.Object eventSender, KeyEventArgs eventArgs)
		{
			MsgBoxResult inres = default(MsgBoxResult);
			int k_ID = 0;
			string lName = null;
			string kView = null;
			short inRe = 0;
			short lKey = 0;
			short lShift = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);

			if (grClick == true) {
				grClick = false;
				return;
			}

			kView = Strings.UCase(Strings.Trim(gridEdit.get_TextMatrix(ref gridEdit.row, ref gridEdit.Col)));

			if (kView == "YES" | kView == "NO") {
				k_ID = Conversion.Val(gridEdit.get_TextMatrix(ref gridEdit.row, ref gridEdit.Col + 1));
				if (kView == "YES") {
					inres = Interaction.MsgBox("Do you want to hide Key on Keyboard", MsgBoxStyle.ApplicationModal + MsgBoxStyle.YesNo + MsgBoxStyle.Question, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					if (inres == MsgBoxResult.Yes) {
						modRecordSet.cnnDB.Execute("UPDATE Keyboard SET Keyboard_Show = 0 WHERE KeyboardID = " + k_ID);
						gridEdit.set_TextMatrix(ref gridEdit.row, ref gridEdit.Col, ref "NO");

					}

				} else if (kView == "NO") {
					inres = Interaction.MsgBox("Do you want to show Key on Keyboard", MsgBoxStyle.ApplicationModal + MsgBoxStyle.YesNo + MsgBoxStyle.Question, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					if (inres == MsgBoxResult.Yes) {
						modRecordSet.cnnDB.Execute("UPDATE Keyboard SET Keyboard_Show = 1 WHERE KeyboardID = " + k_ID);
						gridEdit.set_TextMatrix(ref gridEdit.row, ref gridEdit.Col, ref "YES");
					}
				}

				return;
			}

			lName = gridEdit.get_TextMatrix(ref gridEdit.row, ref 0);
			k_ID = Conversion.Val(gridEdit.get_TextMatrix(ref gridEdit.row, ref 6));
			//Do Display Option.....

			if (gridEdit.Col > 0) {
				if (Conversion.Val(kView) > 0) {
					if (Conversion.Val(kView) < 100) {
						My.MyProject.Forms.frmChangeDisplay.lblName.Text = lName;
						My.MyProject.Forms.frmChangeDisplay.txtNumber.Text = Strings.Trim(kView);
						My.MyProject.Forms.frmChangeDisplay.ShowDialog();

						if (modApplication.InKeyboard == 200) {
						} else {
							modRecordSet.cnnDB.Execute("UPDATE Keyboard SET keyboard_Order = " + modApplication.InKeyboard + " WHERE KeyboardID = " + k_ID);
							var _with2 = gridEdit;
							_with2.Text = Conversion.Str(modApplication.InKeyboard);
							loadKeys();
						}
					}
					return;
				}
			}

			lName = gridEdit.get_TextMatrix(ref gridEdit.row, ref 0);

			lKey = Convert.ToInt16(gridEdit.get_TextMatrix(ref gridEdit.row, ref 3));
			lShift = Convert.ToInt16(gridEdit.get_TextMatrix(ref gridEdit.row, ref 2));
			My.MyProject.Forms.frmKeyboardGet.getKeyboardValue(ref lName, ref lKey, ref lShift);

			if (lKey != 0) {
				//Set rs = getRS("SELECT keyboard.* From keyboard WHERE (((keyboard.keyboard_Shift)=" & lShift & ") AND ((keyboard.keyboard_Key)=" & lKey & "));")
				rs = modRecordSet.getRS(ref "SELECT keyboard.keyboardID, keyboard.keyboard_Name, KeyboardKeyboardLayoutLnk.* FROM KeyboardKeyboardLayoutLnk INNER JOIN keyboard ON KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_KeyboardID = keyboard.KeyboardID Where (((KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_KeyboardLayoutID) = " + gParentID + ") AND ((KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_Shift)=" + lShift + ") AND ((KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_Key)=" + lKey + "))");

				if (rs.RecordCount) {
					if (rs.Fields("KeyboardID").Value == gridEdit.get_RowData(ref gridEdit.row)) {
					} else {
						Interaction.MsgBox("Cannot allocate this key as it is allocated to '" + rs.Fields("keyboard_Name").Value + "!", MsgBoxStyle.Exclamation, "KEYBOARD LAYOUT");
					}
				} else {
					lName = getKeyDescription(ref lKey, ref lShift);
					modRecordSet.cnnDB.Execute("UPDATE KeyboardKeyboardLayoutLnk SET KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_Shift = " + lShift + ", KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_Key = " + lKey + ", KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_Description = '" + lName + "' WHERE (((KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_KeyboardLayoutID)=" + gParentID + ") AND ((KeyboardKeyboardLayoutLnk.KeyboardKeyboardLayoutLnk_KeyboardID)=" + gridEdit.get_RowData(ref gridEdit.row) + "));");
					gridEdit.set_TextMatrix(ref gridEdit.row, ref 3, ref lKey);
					gridEdit.set_TextMatrix(ref gridEdit.row, ref 2, ref lShift);
					gridEdit.set_TextMatrix(ref gridEdit.row, ref 1, ref lName);
				}

			}
		}
	}
}
