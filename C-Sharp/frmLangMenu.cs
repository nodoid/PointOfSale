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
	internal partial class frmLangMenu : System.Windows.Forms.Form
	{
		int gParentID;
		bool grClick;
		private void loadKeys(ref short secID)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			int x = 0;
			string kS = null;

			gridEdit.RowCount = 1;
			rs = modRecordSet.getRS(ref "SELECT * FROM Menu WHERE (((Menu.Menu_ParentID)>0)) ORDER BY Menu.Menu_ParentID, Menu.Menu_Order;");
			if (rs.RecordCount) {
				gridEdit.RowCount = rs.RecordCount + 1;
				x = 0;
				while (!(rs.EOF)) {
					x = x + 1;
					gridEdit.RowCount = x;
					gridEdit.ColumnCount = 0;
					gridEdit.Text = rs.Fields("Menu_Name").Value;
					//gridEdit.CellAlignment = 1

					gridEdit.set_RowData(ref gridEdit.RowCount, ref rs.Fields("MenuID").Value);

					rs.moveNext();
				}
			}
		}

		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		public void loadItem(ref int lParentID)
		{
			gParentID = lParentID;
			loadKeys(ref 4);
			ShowDialog();
		}

		private void frmLangMenu_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			grClick = true;
			var _with1 = gridEdit;
			_with1.ColumnCount = 1;
			_with1.RowCount = 0;
			System.Windows.Forms.Application.DoEvents();
			_with1.RowCount = 2;
			//.FixedRows = 1
			//.FixedCols = 0
			_with1.RowCount = 0;
			_with1.ColumnCount = 0;
			//.CellFontBold = True
			_with1.Text = "Translation";
			//.set_ColWidth(0, 6225)
			//.CellAlignment = 3
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

		private void gridEdit_ClickEvent(System.Object eventSender, System.EventArgs eventArgs)
		{
			frmLangGet frmLanguageGet = null;
			RadioButton Option3 = new RadioButton();
			RadioButton Option2 = new RadioButton();
			RadioButton Option1 = new RadioButton();
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

			lName = Strings.Trim(gridEdit.get_TextMatrix(ref gridEdit.RowCount, ref 0));
			//If kView = "YES" Then
			bRTL = true;
			//Else
			//    bRTL = False
			//End If
			sScreen = "";
			//Trim(gridEdit.TextMatrix(gridEdit.row, 2))
			My.MyProject.Forms.frmLangGet.getLanguageValue(ref lName, ref bRTL, ref sScreen);

			if (!string.IsNullOrEmpty(lName)) {
				rs = modRecordSet.getRS(ref "SELECT * FROM Menu WHERE ((MenuID)=" + gridEdit.get_RowData(ref gridEdit.RowCount) + ");");

				if (rs.RecordCount) {
					lName = Strings.Replace(lName, ",", "-");
					lName = Strings.Replace(lName, "'", "''");

					modRecordSet.cnnDB.Execute("UPDATE Menu SET Menu_Update=True, Menu_Name = '" + lName + "' WHERE ((MenuID)=" + gridEdit.get_RowData(ref gridEdit.RowCount) + ");");
					gridEdit.set_TextMatrix(ref gridEdit.RowCount, ref 0, ref lName);
				}

			}

			return;
			kView = Strings.UCase(Strings.Trim(gridEdit.get_TextMatrix(ref gridEdit.RowCount, ref gridEdit.ColumnCount)));

			if (kView == "YES" | kView == "NO") {
				k_ID = Conversion.Val(gridEdit.get_TextMatrix(ref gridEdit.RowCount, ref gridEdit.ColumnCount + 1));
				if (kView == "YES") {
					inres = Interaction.MsgBox("Do you want to hide Key on Language", MsgBoxStyle.ApplicationModal + MsgBoxStyle.YesNo + MsgBoxStyle.Question, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					if (inres == MsgBoxResult.Yes) {
						modRecordSet.cnnDB.Execute("UPDATE Language SET Language_Show = 0 WHERE LanguageID = " + k_ID);
						gridEdit.set_TextMatrix(ref gridEdit.RowCount, ref gridEdit.ColumnCount, ref "NO");

					}

				} else if (kView == "NO") {
					inres = Interaction.MsgBox("Do you want to show Key on Language", MsgBoxStyle.ApplicationModal + MsgBoxStyle.YesNo + MsgBoxStyle.Question, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					if (inres == MsgBoxResult.Yes) {
						modRecordSet.cnnDB.Execute("UPDATE Language SET Language_Show = 1 WHERE LanguageID = " + k_ID);
						gridEdit.set_TextMatrix(ref gridEdit.RowCount, ref gridEdit.ColumnCount, ref "YES");
					}
				}

				return;
			}

			lName = gridEdit.get_TextMatrix(ref gridEdit.RowCount, ref 0);
			//k_ID = Val(gridEdit.TextMatrix(gridEdit.row, 6))
			//Do Display Option.....

			if (gridEdit.ColumnCount > 0) {
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

			lName = gridEdit.get_TextMatrix(ref gridEdit.RowCount, ref 0);

			//lKey = gridEdit.TextMatrix(gridEdit.row, 3)
			//lShift = gridEdit.TextMatrix(gridEdit.row, 2)
			frmLanguageGet.getLanguageValue(ref lName, ref lKey, ref lShift);

			if (lKey != 0) {
				//Set rs = getRS("SELECT Language.* From Language WHERE (((Language.Language_Shift)=" & lShift & ") AND ((Language.Language_Key)=" & lKey & "));")
				rs = modRecordSet.getRS(ref "SELECT Language.LanguageID, Language.Language_Name, LanguageLayoutLnk.* FROM LanguageLayoutLnk INNER JOIN Language ON LanguageLayoutLnk.LanguageLayoutLnk_LanguageID = Language.LanguageID Where (((LanguageLayoutLnk.LanguageLayoutLnk_LanguageLayoutID) = " + gParentID + ") AND ((LanguageLayoutLnk.LanguageLayoutLnk_Shift)=" + lShift + ") AND ((LanguageLayoutLnk.LanguageLayoutLnk_Key)=" + lKey + "))");

				if (rs.RecordCount) {
					if (rs.Fields("LanguageID").Value == gridEdit.get_RowData(ref gridEdit.RowCount)) {
					} else {
						Interaction.MsgBox("Cannot allocate this key as it is allocated to '" + rs.Fields("Language_Name").Value + "!", MsgBoxStyle.Exclamation, "Language LAYOUT");
					}
				} else {
					lName = getKeyDescription(ref lKey, ref lShift);
					modRecordSet.cnnDB.Execute("UPDATE LanguageLayoutLnk SET LanguageLayoutLnk.LanguageLayoutLnk_Shift = " + lShift + ", LanguageLayoutLnk.LanguageLayoutLnk_Key = " + lKey + ", LanguageLayoutLnk.LanguageLayoutLnk_Description = '" + lName + "' WHERE (((LanguageLayoutLnk.LanguageLayoutLnk_LanguageLayoutID)=" + gParentID + ") AND ((LanguageLayoutLnk.LanguageLayoutLnk_LanguageID)=" + gridEdit.get_RowData(ref gridEdit.RowCount) + "));");
					gridEdit.set_TextMatrix(ref gridEdit.RowCount, ref 3, ref lKey);
					gridEdit.set_TextMatrix(ref gridEdit.RowCount, ref 2, ref lShift);
					gridEdit.set_TextMatrix(ref gridEdit.RowCount, ref 1, ref lName);
				}

			}
		}
	}
}
