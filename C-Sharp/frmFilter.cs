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
namespace _4PosBackOffice.NET
{
	internal partial class frmFilter : System.Windows.Forms.Form
	{
		object[] objectArray;
		public string gCriteria;
		public string gHeading;
		List<Button> cmdList = new List<Button>();
		List<GroupBox> frmList = new List<GroupBox>();
		List<GroupBox> frmString = new List<GroupBox>();
		List<Label> lblList = new List<Label>();
		List<TextBox> txtString = new List<TextBox>();

		private void loadLanguage()
		{
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2133;
			//Edit Selection Criteria|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1393;
			//Clear All|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClear.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClear.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//frmList(0) = No Code/Dynamic/NA?

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2136;
			//Build|Checked
			if (modRecordSet.rsLang.RecordCount){_cmdList_0.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_cmdList_0.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//frmString(0) = No Code/Dynamic/NA?

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmFilter.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public void buildCriteria(ref string filter_Renamed)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset RSitem = default(ADODB.Recordset);
			gHeading = "";
			gCriteria = "";
			 // ERROR: Not supported in C#: OnErrorStatement

			rs = modRecordSet.getRS(ref "SELECT ftSet.* From ftSet Where (((ftSet.ftSet_Group) = '" + Strings.Replace(filter_Renamed, "'", "''") + "')) ORDER BY ftSet.ftSet_Order;");
			if (rs.BOF | rs.EOF) {
			} else {
				while (!(rs.EOF)) {
					RSitem = modRecordSet.getRS(ref "SELECT * From ftData WHERE (((ftData.ftData_PersonID)=" + modRecordSet.gPersonID + ") AND ((ftData.ftData_FieldName)='" + Strings.Replace(rs.Fields("ftSet_Name").Value, "'", "''") + "'));");

					if (RSitem.BOF | RSitem.EOF) {
					} else {
						gHeading = gHeading + " AND " + RSitem.Fields("ftData_Heading").Value;
						gCriteria = gCriteria + " AND " + Strings.Replace(RSitem.Fields("ftData_SQL").Value, "[field]", rs.Fields("ftSet_Field").Value);
					}
					RSitem.Close();
					rs.moveNext();
				}
			}
			rs.Close();

			if (Strings.Left(gCriteria, 5) == " AND ")
				gCriteria = Strings.Mid(gCriteria, 6);
			if (!string.IsNullOrEmpty(gCriteria))
				gCriteria = " WHERE " + gCriteria;
			if (!string.IsNullOrEmpty(gHeading))
				gHeading = Strings.Mid(gHeading, 6);

			//New code

		}

		public bool loadFilter(ref string filter_Renamed)
		{
			bool functionReturnValue = false;
			object modGeneral = null;
			object lDOM = null;
			object lNode = null;
			ADODB.Recordset rs = new ADODB.Recordset();
			ADODB.Recordset RSitem = new ADODB.Recordset();
			short lCNT = 0;
			rs = modRecordSet.getRS(ref "SELECT ftSet.* From ftSet Where (((ftSet.ftSet_Group) = '" + Strings.Replace(filter_Renamed, "'", "''") + "')) ORDER BY ftSet.ftSet_Order;");

			if (rs.BOF | rs.EOF) {
				functionReturnValue = false;
			} else {
				lCNT = -1;
				objectArray = new object[rs.RecordCount];
				while (!(rs.EOF)) {
					lCNT = lCNT + 1;
					switch (rs.Fields("ftset_type").Value) {

						case 2:
							if (lCNT) {
								this.Controls.Add(_frmList_0);
								//_frmList_0.Controls.Add(lCNT)
								//_cmdList_0.Load(lCNT)
								cmdList[lCNT].Parent = frmList[lCNT];
								//lblList.Load(lCNT)
								lblList[lCNT].Parent = frmList[lCNT];
							}
							frmList[lCNT].Visible = true;
							cmdList[lCNT].Visible = true;
							lblList[lCNT].Visible = true;
							frmList[lCNT].Top = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(frmList[0].Top, false) + lCNT * sizeConvertors.pixelToTwips(frmList[0].Height, false), false);
							frmList[lCNT].Text = rs.Fields("ftset_DisplayName").Value;
							frmList[lCNT].Tag = rs.Fields("ftset_Name").Value;
							lblList[lCNT].Text = "";
							RSitem = modRecordSet.getRS(ref "SELECT ftData_Heading From ftData WHERE (ftData_PersonID = " + modRecordSet.gPersonID + ") AND (ftData_FieldName = '" + Strings.Replace(frmList[lCNT].Tag, "'", "''") + "')");
							if (RSitem.BOF | RSitem.EOF) {
							} else {
								lblList[lCNT].Text = RSitem.Fields("ftData_Heading").Value;
							}
							objectArray[lCNT] = frmList[lCNT];
							break;
						case 1:
							if (lCNT) {
								//frmString.Load(lCNT)
								//txtString.Load(lCNT)
								_txtString_0.Parent = frmString[lCNT];
							}
							_frmString_0.Visible = true;
							_txtString_0.Visible = true;
							_frmString_0.Top = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(frmList[0].Top, false) + lCNT * sizeConvertors.pixelToTwips(frmList[0].Height, false), false);
							_frmString_0.Text = lNode.selectSingleNode("@name").Text;
							_frmString_0.Tag = lNode.selectSingleNode("@id").Text;
							_txtString_0.Text = "";
							lDOM = modGeneral.lsData.sql("SELECT ftData_Data From ftData WHERE (ftData_PersonID = " + modRecordSet.gPersonID + ") AND (ftData_FieldName = '" + Strings.Replace(frmString[lCNT].Tag, "'", "''") + "')");
							if (lDOM == null) {
							} else {
								if (lDOM.documentElement.selectSingleNode("/root/ftData/@ftData_Data") == null) {
								} else {
									_txtString_0.Text = lDOM.documentElement.selectSingleNode("/root/ftData/@ftData_Data").Text;
								}
							}
							_txtString_0.Tag = _txtString_0.Text;
							objectArray[lCNT] = _frmString_0;
							break;
					}
					rs.MoveNext();
				}
				this.Height = sizeConvertors.twipsToPixels(objectArray[Information.UBound(objectArray)].Top + objectArray[Information.UBound(objectArray)].Height + 1000, false);

				loadLanguage();
				ShowDialog();
				//UPGRADE_WARNING: Couldn't resolve default property of object loadFilter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				functionReturnValue = true;
			}
			return functionReturnValue;

		}

		private void cmdClear_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modRecordSet.cnnDB.Execute("DELETE ftData.* From ftData");
			modRecordSet.cnnDB.Execute("DELETE ftDataItem.* From ftDataItem");
			this.Close();
		}

		private void cmdList_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			Button btn = new Button();
			btn = (Button)eventSender;
			int Index = GetIndex.GetIndexer(ref btn, ref cmdList);
			ADODB.Recordset rs = default(ADODB.Recordset);
			if (My.MyProject.Forms.frmFilterList.loadData(ref frmList[Index].Tag)) {
				lblList[Index].Text = "";
				rs = modRecordSet.getRS(ref "SELECT ftData_Heading From ftData WHERE (ftData_PersonID = " + modRecordSet.gPersonID + ") AND (ftData_FieldName = '" + Strings.Replace(frmList[Index].Tag, "'", "''") + "')");
				if (rs.BOF | rs.EOF) {
				} else {
					lblList[Index].Text = rs.Fields("ftData_Heading").Value;
				}
			}
		}

		private void cmdList_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			//Dim Index As Short = cmdList.GetIndex(eventSender)
			if (Shift == 4 & KeyCode == 88) {
				this.Close();
				KeyCode = 0;
			}
		}

		private void cmdList_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			//Dim Index As Short = cmdList.GetIndex(eventSender)
			if (KeyAscii == 27) {
				this.Close();
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void save()
		{
			short x = 0;
			string lText = null;
			for (x = Information.LBound(objectArray); x <= Information.UBound(objectArray); x++) {
				switch (objectArray[x].name) {
					case "frmString":
						if (txtString[x].Tag != txtString[x].Text) {
							modRecordSet.cnnDB.Execute("DELETE FROM ftData WHERE (ftData_PersonID = " + modRecordSet.gPersonID + ") AND (ftData_FieldName = '" + Strings.Replace(frmString[x].Tag, "'", "''") + "')");
							if (!string.IsNullOrEmpty(Strings.Trim(txtString[x].Text))) {
								lText = "[field] LIKE ''%25" + Strings.Replace(txtString[x].Text, " ", "%25'' AND [field] LIKE ''%25") + "%25''";
								modRecordSet.cnnDB.Execute("INSERT INTO ftData (ftData_PersonID, ftData_FieldName, ftData_SQL, ftData_Heading, ftData_Data) VALUES (" + modRecordSet.gPersonID + ", '" + Strings.Replace(frmString[x].Tag, "'", "''") + "', '(" + lText + ")', '(" + frmString[x].Text + " = " + txtString[x].Text + ")', '" + Strings.Replace(txtString[x].Text, "'", "''") + "')");
							}
						}
						break;
				}
			}
		}
		private void frmFilter_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			save();
		}

		private void txtString_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			//Dim Index As Short = txtString.GetIndex(eventSender)
			if (KeyAscii == 27) {
				this.Close();
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		private void frmFilter_Load(object sender, System.EventArgs e)
		{
			cmdList.AddRange(new Button[] { _cmdList_0 });
			frmList.AddRange(new GroupBox[] { _frmList_0 });
			frmString.AddRange(new GroupBox[] { _frmString_0 });
			lblList.AddRange(new Label[] { _lblList_0 });
			txtString.AddRange(new TextBox[] { _txtString_0 });
		}
	}
}
