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
	internal partial class frmFilterOrder : System.Windows.Forms.Form
	{
		object[] objectArray;
		public string gCriteria;
		public string gHeading;
		List<Button> cmdList = new List<Button>();

		private void loadLanguage()
		{
			//frmFilterOrder = No Code   [Broken Pack Exclusion List Criteria]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmFilterOrder.Caption = rsLang("LanguageLayoutLnk_Description"): frmFilterOrder.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//frmList(0) = No Code/Dynamic/NA?
			//lblList(0) = No Code/Dynamic/NA?

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2136;
			//Build |Checked
			if (modRecordSet.rsLang.RecordCount){cmdList[0].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdList[0].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmFilterOrder.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public void buildCriteria(ref string filter_Renamed)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset RSitem = default(ADODB.Recordset);
			gHeading = "";
			gCriteria = "";
			rs = modRecordSet.getRS(ref "SELECT * From ftOrderSet Where (((ftSet_Group) = 'order')) ORDER BY ftSet_Order;");
			if (rs.BOF | rs.EOF) {
			} else {
				while (!(rs.EOF)) {
					RSitem = modRecordSet.getRS(ref "SELECT * From ftOrder WHERE (((ftData_PersonID)=" + modRecordSet.gPersonID + ") AND ((ftData_FieldName)='" + Strings.Replace(rs.Fields("ftSet_Name").Value, "'", "''") + "'));");
					if (RSitem.BOF | RSitem.EOF) {
					} else {
						gHeading = gHeading + " AND " + RSitem.Fields("ftData_Heading").Value;
						gCriteria = gCriteria + " AND " + Strings.Replace(RSitem.Fields("ftData_SQL").Value, "[field]", rs.Fields("ftSet_Field").Value);
					}
					RSitem.Close();
					rs.moveNext();
				}
				gCriteria = Strings.Replace(gCriteria, "=", "<>");
				gCriteria = Strings.Replace(gCriteria, " OR ", " AND ");
			}
			rs.Close();
			if (!string.IsNullOrEmpty(gHeading))
				gHeading = Strings.Mid(gHeading, 6);

		}
		public bool loadFilter(ref string filter_Renamed)
		{
			bool functionReturnValue = false;
			ADODB.Recordset rs = new ADODB.Recordset();
			ADODB.Recordset RSitem = new ADODB.Recordset();
			short lCNT = 0;
			rs = modRecordSet.getRS(ref "SELECT * From ftOrderSet Where (((ftSet_Group) = 'order')) ORDER BY ftSet_Order;");
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
								//_frmList_0.
								//frmList.Load(lCNT)
								//cmdList.Load(lCNT)
								cmdList[lCNT].Parent = _frmList_0;
								//lblList.Load(lCNT)
								_lblList_0.Parent = _frmList_0;
							}

							_frmList_0.Visible = true;
							_cmdList_0.Visible = true;
							_lblList_0.Visible = true;
							if (lCNT)
								_frmList_0.Top = sizeConvertors.twipsToPixels(lCNT * sizeConvertors.pixelToTwips(_frmList_0.Height, false) + sizeConvertors.pixelToTwips(_frmList_0.Top, false), false);
							_frmList_0.Text = rs.Fields("ftset_DisplayName").Value;
							_frmList_0.Tag = rs.Fields("ftset_Name").Value;
							_lblList_0.Text = "";
							RSitem = modRecordSet.getRS(ref "SELECT ftData_Heading From ftOrder WHERE (ftData_PersonID = " + modRecordSet.gPersonID + ") AND (ftData_FieldName = '" + Strings.Replace(_frmList_0.Tag, "'", "''") + "')");
							if (RSitem.BOF | RSitem.EOF) {
							} else {
								_lblList_0.Text = RSitem.Fields("ftData_Heading").Value;
							}

							objectArray[lCNT] = _frmList_0;

							break;
					}
					rs.MoveNext();
				}
				this.Height = sizeConvertors.twipsToPixels(objectArray[Information.UBound(objectArray)].Top + objectArray[Information.UBound(objectArray)].Height + 1000, false);

				loadLanguage();
				ShowDialog();
				functionReturnValue = true;
			}
			return functionReturnValue;
		}
		private void cmdList_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			Button btn = new Button();
			btn = (Button)eventSender;
			int Index = GetIndex.GetIndexer(ref btn, ref cmdList);
			ADODB.Recordset rs = default(ADODB.Recordset);
			if (My.MyProject.Forms.frmFilterOrderList.loadData(ref _frmList_0.Tag)) {
				_lblList_0.Text = "";
				rs = modRecordSet.getRS(ref "SELECT ftData_Heading From ftOrder WHERE (ftData_PersonID = " + modRecordSet.gPersonID + ") AND (ftData_FieldName = '" + Strings.Replace(_frmList_0.Tag, "'", "''") + "')");
				if (rs.BOF | rs.EOF) {
				} else {
					_lblList_0.Text = rs.Fields("ftData_Heading").Value;
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
						break;
				}
			}
		}
		private void frmFilterOrder_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			save();
		}
		private void txtString_KeyPress(ref short Index, ref short KeyAscii)
		{
			if (KeyAscii == 27) {
				this.Close();
			}
		}

		private void frmFilterOrder_Load(object sender, System.EventArgs e)
		{
			cmdList.AddRange(new Button[] { _cmdList_0 });
		}
	}
}
