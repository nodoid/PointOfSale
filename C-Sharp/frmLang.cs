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
	internal partial class frmLang : System.Windows.Forms.Form
	{
		int gParentID;
		bool grClick;
		private void loadKeys(ref short secID)
		{
			string sql = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			int x = 0;
			string kS = null;

			gridEdit.RowCount = 1;
			rs = modRecordSet.getRS(ref "SELECT LanguageLayout.LanguageLayoutID, LanguageLayout.LanguageLayout_Name From LanguageLayout WHERE (((LanguageLayout.LanguageLayoutID)=" + gParentID + "));");
			if (rs.RecordCount) {
				modRecordSet.cnnDB.Execute("INSERT INTO LanguageLayoutLnk ( LanguageLayoutLnk_LanguageID, LanguageLayoutLnk_LanguageLayoutID, LanguageLayoutLnk_Description, LanguageLayoutLnk_RightTL, LanguageLayoutLnk_Screen ) SELECT theJoin.LanguageID, theJoin.LanguageLayoutID, 'None' AS Expr1, 0 AS Expr2, 'None' AS Expr3 FROM (SELECT Language.LanguageID, LanguageLayout.LanguageLayoutID From Language, LanguageLayout WHERE (((LanguageLayout.LanguageLayoutID)=" + gParentID + "))) AS theJoin LEFT JOIN LanguageLayoutLnk ON (theJoin.LanguageID = LanguageLayoutLnk.LanguageLayoutLnk_LanguageID) AND (theJoin.LanguageLayoutID = LanguageLayoutLnk.LanguageLayoutLnk_LanguageLayoutID) WHERE (((LanguageLayoutLnk.LanguageLayoutLnk_LanguageID) Is Null));");
				sql = "UPDATE LanguageLayoutLnk AS LanguageLayoutLnk_1 INNER JOIN LanguageLayoutLnk ON LanguageLayoutLnk_1.LanguageLayoutLnk_LanguageID = LanguageLayoutLnk.LanguageLayoutLnk_LanguageID SET LanguageLayoutLnk.LanguageLayoutLnk_Description = [LanguageLayoutLnk_1]![LanguageLayoutLnk_Description], LanguageLayoutLnk.LanguageLayoutLnk_RightTL = [LanguageLayoutLnk_1]![LanguageLayoutLnk_RightTL], LanguageLayoutLnk.LanguageLayoutLnk_Section = [LanguageLayoutLnk_1]![LanguageLayoutLnk_Section], LanguageLayoutLnk.LanguageLayoutLnk_Screen = [LanguageLayoutLnk_1]![LanguageLayoutLnk_Screen] ";
				sql = sql + "WHERE (((LanguageLayoutLnk.LanguageLayoutLnk_Description)='None') AND ((LanguageLayoutLnk.LanguageLayoutLnk_Screen)='None') AND ((LanguageLayoutLnk.LanguageLayoutLnk_LanguageLayoutID)=" + gParentID + ") AND ((LanguageLayoutLnk_1.LanguageLayoutLnk_LanguageLayoutID)=1));";

				if (gParentID != 1)
					modRecordSet.cnnDB.Execute(sql);

				this.txtName.Text = rs.Fields("LanguageLayout_Name").Value;
				rs = modRecordSet.getRS(ref "SELECT Language.*, LanguageLayoutLnk.* FROM LanguageLayoutLnk INNER JOIN Language ON LanguageLayoutLnk.LanguageLayoutLnk_LanguageID = Language.LanguageID Where (((LanguageLayoutLnk.LanguageLayoutLnk_LanguageLayoutID) = " + gParentID + ") AND ((LanguageLayoutLnk.LanguageLayoutLnk_Section) = " + secID + ")) ORDER BY LanguageLayoutLnk_LanguageID;");
				gridEdit.RowCount = rs.RecordCount + 1;
				x = 0;
				while (!(rs.EOF)) {
					x = x + 1;
					gridEdit.row = x;
					gridEdit.Col = 0;
					gridEdit.Text = rs.Fields("LanguageLayoutLnk_Description").Value;
					gridEdit.CellAlignment = 1;

					gridEdit.Col = 1;
					if (rs.Fields("LanguageLayoutLnk_RightTL").Value == true) {
						kS = "Yes";
					} else {
						kS = "No";
					}
					gridEdit.Text = Strings.UCase(kS);
					//gridEdit.Text = getKeyDescription(rs("LanguageLayoutLnk_Key"), rs("LanguageLayoutLnk_Shift"))
					gridEdit.Col = 2;
					gridEdit.Text = (Information.IsDBNull(rs.Fields("LanguageLayoutLnk_Screen").Value) ? "NOT ASSIGNED" : rs.Fields("LanguageLayoutLnk_Screen").Value);
					//rs("LanguageLayoutLnk_Screen")
					//gridEdit.Col = 3
					//gridEdit.Text = rs("LanguageLayoutLnk_Key")
					gridEdit.set_RowData(ref gridEdit.row, ref rs.Fields("LanguageLayoutLnk_LanguageID").Value);
					//gridEdit.Col = 4
					//gridEdit.Text = rs("Language_Order")
					//gridEdit.RowData(gridEdit.row) = rs("LanguageLayoutLnk_LanguageID")
					//gridEdit.Col = 5
					//If rs("Language_Show") = True Then
					//   kS = "Yes"
					//Else
					//   kS = "No"
					//End If
					//gridEdit.Text = UCase(kS)
					//gridEdit.Col = 6
					//gridEdit.Text = rs("LanguageID")
					//gridEdit.RowData(gridEdit.row) = rs("LanguageLayoutLnk_LanguageID")
					rs.moveNext();
				}
			}
		}

		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modRecordSet.cnnDB.Execute("UPDATE LanguageLayout SET LanguageLayout.LanguageLayout_Name = '" + Strings.Replace(txtName.Text, "'", "''") + "' WHERE (((LanguageLayout.LanguageLayoutID)=" + gParentID + "));");
			System.Windows.Forms.Application.DoEvents();
			modRecordSet.cnnDB.Execute("UPDATE LanguageLayout SET LanguageLayout.LanguageLayout_Name = '" + Strings.Replace(txtName.Text, "'", "''") + "' WHERE (((LanguageLayout.LanguageLayoutID)=" + gParentID + "));");
			this.Close();
		}

		public void loadItem(ref short lParentID)
		{
			gParentID = lParentID;
			//loadKeys
			Option1_CheckedChanged(Option1, new System.EventArgs());
			Option1.Checked = true;
			ShowDialog();
		}

		private void frmLang_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			grClick = true;
			var _with1 = gridEdit;
			_with1.Col = 3;
			_with1.RowCount = 0;
			System.Windows.Forms.Application.DoEvents();
			_with1.RowCount = 2;
			_with1.FixedRows = 1;
			_with1.FixedCols = 0;
			_with1.row = 0;
			_with1.Col = 0;
			_with1.CellFontBold = true;
			_with1.Text = "Translation";
			_with1.set_ColWidth(0, 11200);
			_with1.CellAlignment = 3;

			_with1.Col = 1;
			_with1.CellFontBold = true;
			_with1.Text = "Right To Left";
			_with1.set_ColWidth(1, 1200);
			_with1.CellAlignment = 4;

			_with1.Col = 2;
			_with1.CellFontBold = true;
			_with1.Text = "Screen";
			_with1.set_ColWidth(2, 1500);
			_with1.CellAlignment = 1;

			//.Col = 3
			//.CellFontBold = True
			//.Text = "Keycode"
			//.ColWidth(3) = 0
			//.CellAlignment = 1

			//.Col = 4
			//.CellFontBold = True
			//.Text = "Display"
			//.ColWidth(4) = 800
			//.CellAlignment = 1

			//.Col = 5
			//.CellFontBold = True
			//.Text = "Show"
			//.ColWidth(5) = 800
			//.CellAlignment = 1

			//.Col = 6
			//.CellFontBold = True
			//.Text = "KEY"
			//.ColWidth(6) = 0
			//.CellAlignment = 1


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
			//UPGRADE_WARNING: Couldn't resolve default property of object getKeyDescription. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			return lShift + lKey;
		}

		// Handles gridEdit.ClickEvent
		private void gridEdit_ClickEvent(System.Object eventSender, System.EventArgs eventArgs)
		{
			frmLangGet frmLanguageGet = null;
			int InLanguage = 0;
			MsgBoxResult inres = default(MsgBoxResult);
			int k_ID = 0;
			string lName = null;
			string sScreen = null;
			bool bRTL = false;
			string kView = null;
			short inRe = 0;
			short lKey = 0;
			short lShift = 0;
			ADODB.Recordset rs = default(ADODB.Recordset);

			if (grClick == true) {
				grClick = false;
				return;
			}

			lName = Strings.Trim(gridEdit.get_TextMatrix(ref gridEdit.row, ref 0));
			kView = Strings.UCase(Strings.Trim(gridEdit.get_TextMatrix(ref gridEdit.row, ref 1)));
			if (kView == "YES") {
				bRTL = true;
			} else {
				bRTL = false;
			}
			sScreen = Strings.Trim(gridEdit.get_TextMatrix(ref gridEdit.row, ref 2));
			My.MyProject.Forms.frmLangGet.getLanguageValue(ref lName, ref bRTL, ref sScreen);

			if (!string.IsNullOrEmpty(lName)) {
				//Set rs = getRS("SELECT Language.* From Language WHERE (((Language.Language_Shift)=" & lShift & ") AND ((Language.Language_Key)=" & lKey & "));")
				rs = modRecordSet.getRS(ref "SELECT Language.LanguageID, Language.Language_Description, LanguageLayoutLnk.* FROM LanguageLayoutLnk INNER JOIN Language ON LanguageLayoutLnk.LanguageLayoutLnk_LanguageID = Language.LanguageID Where (((LanguageLayoutLnk.LanguageLayoutLnk_LanguageLayoutID) = " + gParentID + ") AND ((LanguageLayoutLnk.LanguageLayoutLnk_LanguageID)=" + gridEdit.get_RowData(ref gridEdit.row) + "))");

				if (rs.RecordCount) {
					//    If rs("LanguageID") = gridEdit.RowData(gridEdit.row) Then
					//    Else
					//        MsgBox "Cannot allocate this key as it is allocated to '" & rs("Language_Name") & "!", vbExclamation, "Language LAYOUT"
					//    End If
					//Else
					//    lName = getKeyDescription(lKey, lShift)
					lName = Strings.Replace(lName, ",", "-");
					lName = Strings.Replace(lName, "'", "''");
					modRecordSet.cnnDB.Execute("UPDATE LanguageLayoutLnk SET LanguageLayoutLnk.LanguageLayoutLnk_RightTL = " + bRTL + ", LanguageLayoutLnk.LanguageLayoutLnk_Description = '" + lName + "' WHERE (((LanguageLayoutLnk.LanguageLayoutLnk_LanguageLayoutID)=" + gParentID + ") AND ((LanguageLayoutLnk.LanguageLayoutLnk_LanguageID)=" + gridEdit.get_RowData(ref gridEdit.row) + "));");
					//cnnDB.Execute "UPDATE LanguageLayoutLnk SET LanguageLayoutLnk.LanguageLayoutLnk_Shift = " & lShift & ", LanguageLayoutLnk.LanguageLayoutLnk_Key = " & lKey & ", LanguageLayoutLnk.LanguageLayoutLnk_Description = '" & lName & "' WHERE (((LanguageLayoutLnk.LanguageLayoutLnk_LanguageLayoutID)=" & gParentID & ") AND ((LanguageLayoutLnk.LanguageLayoutLnk_LanguageID)=" & gridEdit.RowData(gridEdit.row) & "));"
					//    gridEdit.TextMatrix(gridEdit.row, 3) = lKey
					if (bRTL == true) {
						gridEdit.set_TextMatrix(ref gridEdit.row, ref 1, ref "YES");
					} else {
						gridEdit.set_TextMatrix(ref gridEdit.row, ref 1, ref "NO");
					}
					gridEdit.set_TextMatrix(ref gridEdit.row, ref 0, ref lName);
				}

			}

			return;
			kView = Strings.UCase(Strings.Trim(gridEdit.get_TextMatrix(ref gridEdit.row, ref gridEdit.Col)));

			if (kView == "YES" | kView == "NO") {
				k_ID = Conversion.Val(gridEdit.get_TextMatrix(ref gridEdit.row, ref gridEdit.Col + 1));
				if (kView == "YES") {
					inres = Interaction.MsgBox("Do you want to hide Key on Language", MsgBoxStyle.ApplicationModal + MsgBoxStyle.YesNo + MsgBoxStyle.Question, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					if (inres == MsgBoxResult.Yes) {
						modRecordSet.cnnDB.Execute("UPDATE Language SET Language_Show = 0 WHERE LanguageID = " + k_ID);
						gridEdit.set_TextMatrix(ref gridEdit.row, ref gridEdit.Col, ref "NO");

					}

				} else if (kView == "NO") {
					inres = Interaction.MsgBox("Do you want to show Key on Language", MsgBoxStyle.ApplicationModal + MsgBoxStyle.YesNo + MsgBoxStyle.Question, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					if (inres == MsgBoxResult.Yes) {
						modRecordSet.cnnDB.Execute("UPDATE Language SET Language_Show = 1 WHERE LanguageID = " + k_ID);
						gridEdit.set_TextMatrix(ref gridEdit.row, ref gridEdit.Col, ref "YES");
					}
				}

				return;
			}

			lName = gridEdit.get_TextMatrix(ref gridEdit.row, ref 0);
			//k_ID = Val(gridEdit.TextMatrix(gridEdit.row, 6))
			//Do Display Option.....

			if (gridEdit.Col > 0) {
				if (Conversion.Val(kView) > 0) {
					if (Conversion.Val(kView) < 100) {
						My.MyProject.Forms.frmChangeDisplay.lblName.Text = lName;
						My.MyProject.Forms.frmChangeDisplay.txtNumber.Text = Strings.Trim(kView);
						My.MyProject.Forms.frmChangeDisplay.ShowDialog();

						if (InLanguage == 200) {
						} else {
							modRecordSet.cnnDB.Execute("UPDATE Language SET Language_Order = " + InLanguage + " WHERE LanguageID = " + k_ID);
							var _with2 = gridEdit;
							_with2.Text = Conversion.Str(InLanguage);
							if (Option1.Checked)
								loadKeys(ref ref 0);
							if (Option2.Checked)
								loadKeys(ref ref 2);
							if (Option3.Checked)
								loadKeys(ref ref 1);
						}
					}
					return;
				}
			}

			lName = gridEdit.get_TextMatrix(ref gridEdit.row, ref 0);

			//lKey = gridEdit.TextMatrix(gridEdit.row, 3)
			//lShift = gridEdit.TextMatrix(gridEdit.row, 2)
			//UPGRADE_WARNING: Couldn't resolve default property of object frmLanguageGet.getLanguageValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			frmLanguageGet.getLanguageValue(ref lName, ref lKey, ref lShift);

			if (lKey != 0) {
				//Set rs = getRS("SELECT Language.* From Language WHERE (((Language.Language_Shift)=" & lShift & ") AND ((Language.Language_Key)=" & lKey & "));")
				rs = modRecordSet.getRS(ref "SELECT Language.LanguageID, Language.Language_Name, LanguageLayoutLnk.* FROM LanguageLayoutLnk INNER JOIN Language ON LanguageLayoutLnk.LanguageLayoutLnk_LanguageID = Language.LanguageID Where (((LanguageLayoutLnk.LanguageLayoutLnk_LanguageLayoutID) = " + gParentID + ") AND ((LanguageLayoutLnk.LanguageLayoutLnk_Shift)=" + lShift + ") AND ((LanguageLayoutLnk.LanguageLayoutLnk_Key)=" + lKey + "))");

				if (rs.RecordCount) {
					if (rs.Fields("LanguageID").Value == gridEdit.get_RowData(ref gridEdit.row)) {
					} else {
						Interaction.MsgBox("Cannot allocate this key as it is allocated to '" + rs.Fields("Language_Name").Value + "!", MsgBoxStyle.Exclamation, "Language LAYOUT");
					}
				} else {
					lName = getKeyDescription(ref lKey, ref lShift);
					modRecordSet.cnnDB.Execute("UPDATE LanguageLayoutLnk SET LanguageLayoutLnk.LanguageLayoutLnk_Shift = " + lShift + ", LanguageLayoutLnk.LanguageLayoutLnk_Key = " + lKey + ", LanguageLayoutLnk.LanguageLayoutLnk_Description = '" + lName + "' WHERE (((LanguageLayoutLnk.LanguageLayoutLnk_LanguageLayoutID)=" + gParentID + ") AND ((LanguageLayoutLnk.LanguageLayoutLnk_LanguageID)=" + gridEdit.get_RowData(ref gridEdit.row) + "));");
					gridEdit.set_TextMatrix(ref gridEdit.row, ref 3, ref lKey);
					gridEdit.set_TextMatrix(ref gridEdit.row, ref 2, ref lShift);
					gridEdit.set_TextMatrix(ref gridEdit.row, ref 1, ref lName);
				}

			}
		}

		private void Option1_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.Checked) {
				loadKeys(ref 0);
			}
		}

		private void Option2_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.Checked) {
				loadKeys(ref 2);
			}
		}

		private void Option3_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.Checked) {
				loadKeys(ref 1);
			}
		}

		private void Option4_Click()
		{
			int secID = 0;
			string sql = null;

			grClick = true;
			var _with3 = gridEdit;
			_with3.Col = 1;
			_with3.RowCount = 0;
			System.Windows.Forms.Application.DoEvents();
			_with3.RowCount = 2;
			_with3.FixedRows = 1;
			_with3.FixedCols = 0;
			_with3.row = 0;
			_with3.Col = 0;
			_with3.CellFontBold = true;
			_with3.Text = "Translation";
			_with3.set_ColWidth(0, 11200);
			_with3.CellAlignment = 3;

			ADODB.Recordset rs = default(ADODB.Recordset);
			int x = 0;
			string kS = null;

			gridEdit.RowCount = 1;
			rs = modRecordSet.getRS(ref "SELECT * FROM Menu;");
			if (rs.RecordCount) {
				modRecordSet.cnnDB.Execute("INSERT INTO LanguageLayoutLnk ( LanguageLayoutLnk_LanguageID, LanguageLayoutLnk_LanguageLayoutID, LanguageLayoutLnk_Description, LanguageLayoutLnk_RightTL, LanguageLayoutLnk_Screen ) SELECT theJoin.LanguageID, theJoin.LanguageLayoutID, 'None' AS Expr1, 0 AS Expr2, 'None' AS Expr3 FROM (SELECT Language.LanguageID, LanguageLayout.LanguageLayoutID From Language, LanguageLayout WHERE (((LanguageLayout.LanguageLayoutID)=" + gParentID + "))) AS theJoin LEFT JOIN LanguageLayoutLnk ON (theJoin.LanguageID = LanguageLayoutLnk.LanguageLayoutLnk_LanguageID) AND (theJoin.LanguageLayoutID = LanguageLayoutLnk.LanguageLayoutLnk_LanguageLayoutID) WHERE (((LanguageLayoutLnk.LanguageLayoutLnk_LanguageID) Is Null));");
				sql = "UPDATE LanguageLayoutLnk AS LanguageLayoutLnk_1 INNER JOIN LanguageLayoutLnk ON LanguageLayoutLnk_1.LanguageLayoutLnk_LanguageID = LanguageLayoutLnk.LanguageLayoutLnk_LanguageID SET LanguageLayoutLnk.LanguageLayoutLnk_Description = [LanguageLayoutLnk_1]![LanguageLayoutLnk_Description], LanguageLayoutLnk.LanguageLayoutLnk_RightTL = [LanguageLayoutLnk_1]![LanguageLayoutLnk_RightTL], LanguageLayoutLnk.LanguageLayoutLnk_Section = [LanguageLayoutLnk_1]![LanguageLayoutLnk_Section], LanguageLayoutLnk.LanguageLayoutLnk_Screen = [LanguageLayoutLnk_1]![LanguageLayoutLnk_Screen] ";
				sql = sql + "WHERE (((LanguageLayoutLnk.LanguageLayoutLnk_Description)='None') AND ((LanguageLayoutLnk.LanguageLayoutLnk_Screen)='None') AND ((LanguageLayoutLnk.LanguageLayoutLnk_LanguageLayoutID)=" + gParentID + ") AND ((LanguageLayoutLnk_1.LanguageLayoutLnk_LanguageLayoutID)=1));";

				if (gParentID != 1)
					modRecordSet.cnnDB.Execute(sql);

				this.txtName.Text = rs.Fields("LanguageLayout_Name").Value;
				rs = modRecordSet.getRS(ref "SELECT Language.*, LanguageLayoutLnk.* FROM LanguageLayoutLnk INNER JOIN Language ON LanguageLayoutLnk.LanguageLayoutLnk_LanguageID = Language.LanguageID Where (((LanguageLayoutLnk.LanguageLayoutLnk_LanguageLayoutID) = " + gParentID + ") AND ((LanguageLayoutLnk.LanguageLayoutLnk_Section) = " + secID + ")) ORDER BY LanguageLayoutLnk_LanguageID;");
				gridEdit.RowCount = rs.RecordCount + 1;
				x = 0;
				while (!(rs.EOF)) {
					x = x + 1;
					gridEdit.row = x;
					gridEdit.Col = 0;
					gridEdit.Text = rs.Fields("LanguageLayoutLnk_Description").Value;
					gridEdit.CellAlignment = 1;

					gridEdit.Col = 1;
					if (rs.Fields("LanguageLayoutLnk_RightTL").Value == true) {
						kS = "Yes";
					} else {
						kS = "No";
					}
					gridEdit.Text = Strings.UCase(kS);
					//gridEdit.Text = getKeyDescription(rs("LanguageLayoutLnk_Key"), rs("LanguageLayoutLnk_Shift"))
					gridEdit.Col = 2;
					gridEdit.Text = (Information.IsDBNull(rs.Fields("LanguageLayoutLnk_Screen").Value) ? "NOT ASSIGNED" : rs.Fields("LanguageLayoutLnk_Screen").Value);
					//rs("LanguageLayoutLnk_Screen")
					//gridEdit.Col = 3
					//gridEdit.Text = rs("LanguageLayoutLnk_Key")
					gridEdit.set_RowData(ref gridEdit.row, ref rs.Fields("LanguageLayoutLnk_LanguageID").Value);
					//gridEdit.Col = 4
					//gridEdit.Text = rs("Language_Order")
					//gridEdit.RowData(gridEdit.row) = rs("LanguageLayoutLnk_LanguageID")
					//gridEdit.Col = 5
					//If rs("Language_Show") = True Then
					//   kS = "Yes"
					//Else
					//   kS = "No"
					//End If
					//gridEdit.Text = UCase(kS)
					//gridEdit.Col = 6
					//gridEdit.Text = rs("LanguageID")
					//gridEdit.RowData(gridEdit.row) = rs("LanguageLayoutLnk_LanguageID")
					rs.moveNext();
				}
			}

		}
	}
}
