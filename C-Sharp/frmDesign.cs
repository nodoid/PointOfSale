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
	internal partial class frmDesign : System.Windows.Forms.Form
	{
		List<RadioButton> option1;
		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1906;
			//Barcode Design|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1907;
			//Please Select the Stock Barcode to Modify|Checked
			if (modRecordSet.rsLang.RecordCount){Label1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1821;
			//Stock Barcode|Checked
			if (modRecordSet.rsLang.RecordCount){option1[2].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;option1[2].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1830;
			//Shelf Taker|Checked
			if (modRecordSet.rsLang.RecordCount){option1[1].Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;option1[1].RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdexit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdexit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1065;
			//New|Checked
			if (modRecordSet.rsLang.RecordCount){cmdnew.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdnew.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1005;
			//Next|Checked
			if (modRecordSet.rsLang.RecordCount){cmdnext.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdnext.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmDesign.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdNew_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rsBClabel = default(ADODB.Recordset);
			ADODB.Recordset rst = default(ADODB.Recordset);
			short TheLastIDIncr = 0;
			short BCLabelIDIncr = 0;
			ADODB.Recordset rsNewName = default(ADODB.Recordset);
			ADODB.Recordset rsForName = default(ADODB.Recordset);
			string InpType = null;
			short x = 0;
			rs = new ADODB.Recordset();
			rsBClabel = new ADODB.Recordset();
			rst = new ADODB.Recordset();
			rsNewName = new ADODB.Recordset();
			rsForName = new ADODB.Recordset();

			//Set rs = getRS("SELECT Max(BClabel_LabelID) as TheMaxLabelID FROM BClabel")
			//***** If BClabel and BClabelItem tables are empty then insert all data from LabelItem
			//If IsNull(rs("TheMaxLabelID")) Then
			//   IntDesign1 = 2
			//   DataList1_DblClick
			//  Exit Sub
			//End If

			rs = modRecordSet.getRS(ref "SELECT Max(LabelID) as TheMaxLabelID FROM Label;");
			if (Information.IsDBNull(rs.Fields("TheMaxLabelID").Value)) {
				modApplication.IntDesign1 = 2;
				DataList1_DblClick(DataList1, new System.EventArgs());
				return;
			}
			TheLastIDIncr = rs.Fields("TheMaxLabelID").Value + 1;
			//LabelID

			rst = modRecordSet.getRS(ref "SELECT Max(BClabelID) as TheMaxBClabelID FROM BClabel");
			if (Information.IsDBNull(rst.Fields("TheMaxBClabelID").Value)) {
				BCLabelIDIncr = 1;
			} else {
				BCLabelIDIncr = rst.Fields("TheMaxBClabelID").Value + 1;
				//BCLabelID
			}

			if (option1[1].Checked == true) {
				InpType = Convert.ToString(1);
			} else if (option1[2].Checked == true) {
				InpType = Convert.ToString(2);
			} else {
				InpType = Interaction.InputBox("Please enter 1 for New Shelf Talker Design OR 2 for New Barcode Design.");
				if (!Information.IsNumeric(InpType)) {
					//MsgBox "Please enter 1 for New Shelf Talker Design OR 2 for New Barcode Design.", vbInformation, App.title
					return;
				} else if (Convert.ToDouble(InpType) == 1) {
					modApplication.TheType = 1;
				} else if (Convert.ToDouble(InpType) == 2) {
					modApplication.TheType = 2;
				} else {
					Interaction.MsgBox("Please enter 1 for New Shelf Talker Design OR 2 for New Barcode Design.", MsgBoxStyle.Information, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					return;
				}
			}

			//****
			//New Label Name
			//****
			x = x + 1;
			modApplication.NewLabelName = "New Label" + x;

			rsNewName = modRecordSet.getRS(ref "SELECT * FROM Label WHERE Label_Name='" + modApplication.NewLabelName + "'");
			rsForName = modRecordSet.getRS(ref "SELECT * FROM Label");

			if (rsNewName.RecordCount > 0) {
				//*******
				//Do until New Name not found
				//*******
				while (!(rsForName.EOF)) {
					//****
					//If New Label Name not found then add 1 to last Label No
					//****
					if (rsNewName.RecordCount > 0) {
						x = x + 1;
						modApplication.NewLabelName = "New Label" + x;
						rsNewName = modRecordSet.getRS(ref "SELECT * FROM Label WHERE Label_Name='" + modApplication.NewLabelName + "'");

					} else if (rsNewName.RecordCount < 1) {
						modApplication.NewLabelName = modApplication.NewLabelName;
						break; // TODO: might not be correct. Was : Exit Do
					}

					rsForName.moveNext();
				}

			} else {

			}
			x = 0;

			//*****
			//Inserting New Label
			//*****
			rsBClabel = modRecordSet.getRS(ref "INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES(" + BCLabelIDIncr + " ,'Stock','Stock','" + 0 + "',15," + TheLastIDIncr + ")");

			rsBClabel = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + BCLabelIDIncr + "," + 22 + ",'blank'," + 1 + "," + 0 + ",'" + 0 + "',' ','" + 0 + "'," + TheLastIDIncr + ")");

			rs = modRecordSet.getRS(ref "SELECT BClabel.*, BClabelItem.* FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabel_LabelID = BClabelItem.BClabelItem_LabelID WHERE BClabelItem.BClabelItem_LabelID=" + TheLastIDIncr + "");

			rsBClabel = modRecordSet.getRS(ref "INSERT INTO Label(LabelID,Label_Type,Label_Name,Label_Height,Label_Width,Label_Top,Label_Rotate,Label_Disabled,Label_Left)VALUES(" + TheLastIDIncr + "," + modApplication.TheType + ",'" + modApplication.NewLabelName + "'," + 30 + "," + 40 + "," + 0 + ",'" + 0 + "','" + 0 + "'," + 0 + ")");

			rsBClabel = modRecordSet.getRS(ref "INSERT INTO LabelItem(labelItem_LabelID,labelItem_Line,labelItem_Field,labelItem_Align,labelItem_Size,labelItem_Bold,labelItem_Sample) VALUES (" + TheLastIDIncr + "," + 22 + ",'blank'," + 1 + "," + 0 + ",'" + 0 + "',' ')");

			modApplication.RecSel = rs.Fields("BClabelID").Value;
			//SelectLabelName = NewLabelName

			modApplication.MyLIDWHole = TheLastIDIncr;

			My.MyProject.Forms.frmBarcodeLoad.ShowDialog();

		}

		private void cmdNext_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			DataList1_DblClick(DataList1, new System.EventArgs());
		}

		private void DataList1_DblClick(System.Object eventSender, KeyPressEventArgs eventArgs)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rst = default(ADODB.Recordset);
			ADODB.Recordset rsInner = default(ADODB.Recordset);
			ADODB.Recordset rsShelf = default(ADODB.Recordset);
			ADODB.Recordset rsBClabel = default(ADODB.Recordset);
			short HoldBClabelItem_BCLabelID = 0;
			string TheSample = null;
			short IntLabelID = 0;
			short IncrBClabelID = 0;

			rs = new ADODB.Recordset();
			rst = new ADODB.Recordset();
			rsInner = new ADODB.Recordset();
			rsShelf = new ADODB.Recordset();
			rsBClabel = new ADODB.Recordset();
			short TheeMaxID = 0;

			modRecordSet.cnnDB.Execute("DELETE * FROM BClabel;");
			modRecordSet.cnnDB.Execute("DELETE * FROM BClabelItem;");

			modApplication.IntDesign = 1;
			//New code
			HoldBClabelItem_BCLabelID = 1;
			rs = modRecordSet.getRS(ref "SELECT BClabel.*, BClabelItem.* FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabelID = BClabelItem.BClabelItem_BCLabelID");


			if (rs.RecordCount > 0) {
				if (string.IsNullOrEmpty(Strings.Trim(DataList1.CurrentCell.Value.ToString()))) {
					if (modApplication.TheType == 2) {
						Interaction.MsgBox("Please select Stock Barcode Design and click Next", MsgBoxStyle.Information, "4Pos Back Office");
						return;
					} else {
						Interaction.MsgBox("Please select Shelf Talker Design and click Next", MsgBoxStyle.Information, "4Pos Back Office");
						return;
					}
				} else {
				}

				modApplication.MyLIDWHole = Convert.ToInt16(DataList1.CurrentCell.Value);

				rs = modRecordSet.getRS(ref "SELECT BClabel.*, BClabelItem.* FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabel_LabelID = BClabelItem.BClabelItem_LabelID WHERE BClabelItem.BClabelItem_LabelID=" + modApplication.MyLIDWHole + "");

				if (rs.RecordCount == 0) {
					IncrBClabelID = 1;
					rsInner = modRecordSet.getRS(ref "SELECT Label.*, LabelItem.* FROM Label INNER JOIN LabelItem ON Label.LabelID = LabelItem.labelItem_LabelID WHERE Label.Label_Type=2;");

					rsBClabel = modRecordSet.getRS(ref "INSERT INTO BClabel(BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES('Stock','Stock','" + 0 + "',15," + rsInner.Fields("LabelID").Value + ")");
					//Set rsBClabel = getRS("INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES(1,'Stock','Stock','" & 0 & "',15," & rsInner("LabelID") & ")")

					while (!(rsInner.EOF)) {
						//****
						//Inserting information into BCLabel
						//***

						if (string.IsNullOrEmpty(Strings.Trim(rsInner.Fields("labelItem_Sample").Value))) {
							TheSample = " ";
							//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						} else if (Information.IsDBNull(rsInner.Fields("labelItem_Sample").Value)) {
							TheSample = " ";
						} else {
							TheSample = rsInner.Fields("labelItem_Sample").Value;
						}

						rst = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + HoldBClabelItem_BCLabelID + "," + rsInner.Fields("labelItem_Line").Value + ",'" + rsInner.Fields("labelItem_Field").Value + "'," + rsInner.Fields("labelItem_Align").Value + "," + rsInner.Fields("labelItem_Size").Value + "," + rsInner.Fields("labelItem_Bold").Value + ",'" + TheSample + "','" + 0 + "'," + rsInner.Fields("labelItem_LabelID").Value + ")");
						IntLabelID = rsInner.Fields("labelItem_LabelID").Value;
						rsInner.MoveNext();
						//****
						//If the ID is still for the same design then dont increment HoldBClabelItem_BCLabelID
						//****
						 // ERROR: Not supported in C#: OnErrorStatement

						if (IntLabelID != rsInner.Fields("labelItem_LabelID").Value) {
							HoldBClabelItem_BCLabelID = HoldBClabelItem_BCLabelID + 1;

							IncrBClabelID = IncrBClabelID + 1;

							if (rsInner.Fields("Label_Top").Value == 3) {
								rsBClabel = modRecordSet.getRS(ref "INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES(" + IncrBClabelID + ",'Stock','Stock','" + 0 + "',15," + rsInner.Fields("LabelID").Value + ")");
							} else {
								rsBClabel = modRecordSet.getRS(ref "INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES(" + IncrBClabelID + ",'Stock','Stock','" + 0 + "',30," + rsInner.Fields("LabelID").Value + ")");
							}


						} else {
						}
					}
					rst = modRecordSet.getRS(ref "SELECT Max(BClabelID) As MaxLaID FROM BClabel");
					//Dim TheeMaxID As Integer

					TheeMaxID = rst.Fields("MaxLaID").Value;

					rsInner = modRecordSet.getRS(ref "SELECT Label.*, LabelItem.* FROM Label INNER JOIN LabelItem ON Label.LabelID = LabelItem.labelItem_LabelID WHERE Label.Label_Type=1;");

					//****
					//Inserting For shelf talker
					//****
					TheeMaxID = TheeMaxID + 1;
					rsBClabel = modRecordSet.getRS(ref "INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES(" + IncrBClabelID + ",'Stock','Stock','" + 0 + "',15," + rsInner.Fields("LabelID").Value + ")");

					while (!(rsInner.EOF)) {
						//****
						//Inserting information into BCLabel
						//***

						if (string.IsNullOrEmpty(Strings.Trim(rsInner.Fields("labelItem_Sample").Value))) {
							TheSample = " ";
							//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						} else if (Information.IsDBNull(rsInner.Fields("labelItem_Sample").Value)) {
							TheSample = " ";
						} else {
							TheSample = rsInner.Fields("labelItem_Sample").Value;
						}

						rst = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + TheeMaxID + "," + rsInner.Fields("labelItem_Line").Value + ",'" + rsInner.Fields("labelItem_Field").Value + "'," + rsInner.Fields("labelItem_Align").Value + "," + rsInner.Fields("labelItem_Size").Value + "," + rsInner.Fields("labelItem_Bold").Value + ",'" + TheSample + "','" + 0 + "'," + rsInner.Fields("labelItem_LabelID").Value + ")");
						IntLabelID = rsInner.Fields("labelItem_LabelID").Value;
						rsInner.MoveNext();
						//****
						//If the ID is still for the same design then dont increment HoldBClabelItem_BCLabelID
						//****

						if (IntLabelID != rsInner.Fields("labelItem_LabelID").Value) {
							TheeMaxID = TheeMaxID + 1;

							//IncrBClabelID = IncrBClabelID + 1

							if (rsInner.Fields("Label_Top").Value == 3) {
								rsBClabel = modRecordSet.getRS(ref "INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES(" + TheeMaxID + ",'Stock','Stock','" + 0 + "',15," + rsInner.Fields("LabelID").Value + ")");
							} else {
								rsBClabel = modRecordSet.getRS(ref "INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES(" + TheeMaxID + ",'Stock','Stock','" + 0 + "',30," + rsInner.Fields("LabelID").Value + ")");
							}


						} else {
						}
					}

					//***
					//For new database
					//***
					if (modApplication.IntDesign1 != 2) {
						if (string.IsNullOrEmpty(Strings.Trim(DataList1.CurrentCell.Value.ToString()))) {
							if (modApplication.TheType == 2) {
								Interaction.MsgBox("Please select Stock Barcode Design and click Next", MsgBoxStyle.Information, "4Pos Back Office");
								return;
							} else {
								Interaction.MsgBox("Please select Shelf Talker Design and click Next", MsgBoxStyle.Information, "4Pos Back Office");
								return;
							}
						} else {
						}
					} else {
						modApplication.IntDesign = 0;
					}

					if (modApplication.IntDesign1 == 2) {
						modApplication.IntDesign1 = 0;
						cmdNew_Click(cmdnew, new System.EventArgs());
						return;

					}

					modApplication.MyLIDWHole = Convert.ToInt16(DataList1.CurrentCell.Value);

					rs = modRecordSet.getRS(ref "SELECT BClabel.*, BClabelItem.* FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabel_LabelID = BClabelItem.BClabelItem_LabelID WHERE BClabelItem.BClabelItem_LabelID=" + modApplication.MyLIDWHole + "");
					modApplication.RecSel = rs.Fields("BClabelID").Value;
					//UPGRADE_NOTE: Text was upgraded to CtlText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
					modApplication.SelectLabelName = DataList1.CurrentCell.Value.ToString();
					My.MyProject.Forms.frmBarcodeLoad.ShowDialog();

				} else {
					modApplication.RecSel = rs.Fields("BClabelID").Value;
					//UPGRADE_NOTE: Text was upgraded to CtlText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
					modApplication.SelectLabelName = DataList1.CurrentCell.Value.ToString();
					My.MyProject.Forms.frmBarcodeLoad.ShowDialog();
				}
			} else if (rs.RecordCount < 1) {
				//Set rsInner = getRS("SELECT Label.*, LabelItem.* FROM Label INNER JOIN LabelItem ON Label.LabelID = LabelItem.labelItem_LabelID WHERE Label.Label_Type=2;")
				IncrBClabelID = 1;
				rsInner = modRecordSet.getRS(ref "SELECT Label.*, LabelItem.* FROM Label INNER JOIN LabelItem ON Label.LabelID = LabelItem.labelItem_LabelID WHERE Label.Label_Type=2;");

				rsBClabel = modRecordSet.getRS(ref "INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES(1,'Stock','Stock','" + 0 + "',15," + rsInner.Fields("LabelID").Value + ")");

				while (!(rsInner.EOF)) {
					//****
					//Inserting information into BCLabel
					//***

					if (string.IsNullOrEmpty(Strings.Trim(rsInner.Fields("labelItem_Sample").Value))) {
						TheSample = " ";
						//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					} else if (Information.IsDBNull(rsInner.Fields("labelItem_Sample").Value)) {
						TheSample = " ";
					} else {
						TheSample = rsInner.Fields("labelItem_Sample").Value;
					}

					rst = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + HoldBClabelItem_BCLabelID + "," + rsInner.Fields("labelItem_Line").Value + ",'" + rsInner.Fields("labelItem_Field").Value + "'," + rsInner.Fields("labelItem_Align").Value + "," + rsInner.Fields("labelItem_Size").Value + "," + rsInner.Fields("labelItem_Bold").Value + ",'" + TheSample + "','" + 0 + "'," + rsInner.Fields("labelItem_LabelID").Value + ")");
					IntLabelID = rsInner.Fields("labelItem_LabelID").Value;
					rsInner.MoveNext();
					//****
					//If the ID is still for the same design then dont increment HoldBClabelItem_BCLabelID
					//****
					 // ERROR: Not supported in C#: OnErrorStatement

					if (IntLabelID != rsInner.Fields("labelItem_LabelID").Value) {
						HoldBClabelItem_BCLabelID = HoldBClabelItem_BCLabelID + 1;

						IncrBClabelID = IncrBClabelID + 1;

						if (rsInner.Fields("Label_Top").Value == 3) {
							rsBClabel = modRecordSet.getRS(ref "INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES(" + IncrBClabelID + ",'Stock','Stock','" + 0 + "',15," + rsInner.Fields("LabelID").Value + ")");
						} else {
							rsBClabel = modRecordSet.getRS(ref "INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES(" + IncrBClabelID + ",'Stock','Stock','" + 0 + "',30," + rsInner.Fields("LabelID").Value + ")");
						}


					} else {
					}
				}
				rst = modRecordSet.getRS(ref "SELECT Max(BClabelID) As MaxLaID FROM BClabel");
				//Dim TheeMaxID As Integer

				TheeMaxID = rst.Fields("MaxLaID").Value;

				rsInner = modRecordSet.getRS(ref "SELECT Label.*, LabelItem.* FROM Label INNER JOIN LabelItem ON Label.LabelID = LabelItem.labelItem_LabelID WHERE Label.Label_Type=1;");

				//****
				//Inserting For shelf talker
				//****
				TheeMaxID = TheeMaxID + 1;
				rsBClabel = modRecordSet.getRS(ref "INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES(" + IncrBClabelID + ",'Stock','Stock','" + 0 + "',15," + rsInner.Fields("LabelID").Value + ")");

				while (!(rsInner.EOF)) {
					//****
					//Inserting information into BCLabel
					//***

					if (string.IsNullOrEmpty(Strings.Trim(rsInner.Fields("labelItem_Sample").Value))) {
						TheSample = " ";
						//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					} else if (Information.IsDBNull(rsInner.Fields("labelItem_Sample").Value)) {
						TheSample = " ";
					} else {
						TheSample = rsInner.Fields("labelItem_Sample").Value;
					}

					rst = modRecordSet.getRS(ref "INSERT INTO BClabelItem(BClabelItem_BCLabelID,BClabelItem_Line,BClabelItem_Field,BClabelItem_Align,BClabelItem_Size,BClabelItem_Bold,BClabelItem_Sample,BClabelItem_Disabled,BClabelItem_LabelID)VALUES(" + TheeMaxID + "," + rsInner.Fields("labelItem_Line").Value + ",'" + rsInner.Fields("labelItem_Field").Value + "'," + rsInner.Fields("labelItem_Align").Value + "," + rsInner.Fields("labelItem_Size").Value + "," + rsInner.Fields("labelItem_Bold").Value + ",'" + TheSample + "','" + 0 + "'," + rsInner.Fields("labelItem_LabelID").Value + ")");
					IntLabelID = rsInner.Fields("labelItem_LabelID").Value;
					rsInner.MoveNext();
					//****
					//If the ID is still for the same design then dont increment HoldBClabelItem_BCLabelID
					//****

					if (IntLabelID != rsInner.Fields("labelItem_LabelID").Value) {
						TheeMaxID = TheeMaxID + 1;

						//IncrBClabelID = IncrBClabelID + 1

						if (rsInner.Fields("Label_Top").Value == 3) {
							rsBClabel = modRecordSet.getRS(ref "INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES(" + TheeMaxID + ",'Stock','Stock','" + 0 + "',15," + rsInner.Fields("LabelID").Value + ")");
						} else {
							rsBClabel = modRecordSet.getRS(ref "INSERT INTO BClabel(BClabelID,BClabel_Name,BClabel_Type,BClabel_Disabled,BClabel_Height,BClabel_LabelID)VALUES(" + TheeMaxID + ",'Stock','Stock','" + 0 + "',30," + rsInner.Fields("LabelID").Value + ")");
						}


					} else {
					}
				}

				//***
				//For new database
				//***
				if (modApplication.IntDesign1 != 2) {
					if (string.IsNullOrEmpty(Strings.Trim(DataList1.CurrentCell.Value.ToString()))) {
						if (modApplication.TheType == 2) {
							Interaction.MsgBox("Please select Stock Barcode Design and click Next", MsgBoxStyle.Information, "4Pos Back Office");
							return;
						} else {
							Interaction.MsgBox("Please select Shelf Talker Design and click Next", MsgBoxStyle.Information, "4Pos Back Office");
							return;
						}
					} else {
					}
				} else {
					modApplication.IntDesign = 0;
				}

				if (modApplication.IntDesign1 == 2) {
					modApplication.IntDesign1 = 0;
					cmdNew_Click(cmdnew, new System.EventArgs());
					return;

				}

				modApplication.MyLIDWHole = Convert.ToInt16(DataList1.CurrentCell.Value);

				rs = modRecordSet.getRS(ref "SELECT BClabel.*, BClabelItem.* FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabel_LabelID = BClabelItem.BClabelItem_LabelID WHERE BClabelItem.BClabelItem_LabelID=" + modApplication.MyLIDWHole + "");
				modApplication.RecSel = rs.Fields("BClabelID").Value;
				//UPGRADE_NOTE: Text was upgraded to CtlText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
				modApplication.SelectLabelName = DataList1.CurrentCell.Value.ToString();
				My.MyProject.Forms.frmBarcodeLoad.ShowDialog();



			}
			//*** if statement for checking BClabel and BClabelItem =0 end here

		}

		private void frmDesign_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);

			if (KeyAscii == 27) {
				cmdExit_Click(cmdexit, new System.EventArgs());
			} else if (KeyAscii == 13) {
				cmdNext_Click(cmdnext, new System.EventArgs());
			}

			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
		private void frmDesign_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			option1.AddRange(new RadioButton[] {
				_Option1_1,
				_Option1_2
			});
			 // ERROR: Not supported in C#: OnErrorStatement

			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rst = default(ADODB.Recordset);

			rs = new ADODB.Recordset();

			rst = new ADODB.Recordset();

			rs = modRecordSet.getRS(ref "SELECT * FROM Label WHERE Label.Label_Type=" + 2 + " ORDER BY LabelID");
			DataList1.DataBindings.Add(rs);
			DataList1.DataSource = rs;
			DataList1.listField = "Label_Name";

			//UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
			DataList1.DataSource = rs;
			DataList1.boundColumn = "LabelID";
			modApplication.TheType = 2;

			loadLanguage();
			this.ShowDialog();

		}
		public object MyLoad()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rst = new ADODB.Recordset();

			rs = modRecordSet.getRS(ref "SELECT * FROM Label WHERE Label.Label_Type=" + 2 + "");

			DataList1.DataSource = rs;
			DataList1.listField = "Label_Name";

			//Bind the DataCombo to the ADO Recordset
			//UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
			DataList1.DataSource = rs;
			DataList1.boundColumn = "LabelID";

			loadLanguage();
			this.ShowDialog();
		}
		public object TheSelect()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rst = default(ADODB.Recordset);

			rs = new ADODB.Recordset();
			rst = new ADODB.Recordset();

			modApplication.MyLIDWHole = Convert.ToInt16(DataList1.CurrentCell.Value);

			rs = modRecordSet.getRS(ref "SELECT BClabel.*, BClabelItem.* FROM BClabel INNER JOIN BClabelItem ON BClabel.BClabel_LabelID = BClabelItem.BClabelItem_LabelID WHERE BClabelItem.BClabelItem_LabelID=" + modApplication.MyLIDWHole + "");
			modApplication.RecSel = rs.Fields("BClabelID").Value;

			modApplication.TheSelectedPrinterNew = 2;
			My.MyProject.Forms.frmBarcodeLoad.ShowDialog();

		}
		public object RefreshLoad(ref short Index)
		{

			 // ERROR: Not supported in C#: OnErrorStatement

			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rst = default(ADODB.Recordset);

			rs = new ADODB.Recordset();

			rst = new ADODB.Recordset();
			//TheSelectedPrinterNew = 0
			rs = modRecordSet.getRS(ref "SELECT * FROM Label WHERE Label.Label_Type=" + Index + " ORDER BY LabelID");

			DataList1.DataSource = rs;
			DataList1.listField = "Label_Name";

			//Bind the DataCombo to the ADO Recordset

			//UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
			DataList1.DataSource = rs;
			DataList1.boundColumn = "LabelID";
			//if the Type was Shelf Talker set option button to true else set Barcode option button to true
			if (modApplication.TheType == 1) {
				this.option1[1].Checked = true;
			} else if (modApplication.TheType == 2) {
				this.option1[2].Checked = true;
			}

			loadLanguage();
			this.ShowDialog();

		}

		private void Option1_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.Checked) {
				int Index = 0;
				RadioButton rb = new RadioButton();
				rb = (RadioButton)eventSender;
				Index = GetIndex.GetIndexer(ref rb, ref option1);

				 // ERROR: Not supported in C#: OnErrorStatement

				ADODB.Recordset rs = default(ADODB.Recordset);
				ADODB.Recordset rst = default(ADODB.Recordset);

				rs = new ADODB.Recordset();

				rst = new ADODB.Recordset();

				rs = modRecordSet.getRS(ref "SELECT * FROM Label WHERE Label.Label_Type=" + Index + " ORDER BY LabelID");

				DataList1.DataSource = rs;
				DataList1.listField = "Label_Name";

				//UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
				DataList1.DataSource = rs;
				DataList1.boundColumn = "LabelID";
				modApplication.TheType = Index;

				if (modApplication.TheType == 1) {
					this.Label1.Text = "Please select the Shelf Talker you wish to modify";
					this.Text = "Shelf Talker Design";
				} else {
					this.Label1.Text = "Please select the Stock Barcode you wish to modify";
					this.Text = "Barcode Design";
				}

			}
		}
	}
}
