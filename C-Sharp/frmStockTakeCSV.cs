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
	internal partial class frmStockTakeCSV : System.Windows.Forms.Form
	{
		ADODB.Recordset rs;
		string Te_Name;
		string MyFTypes;
		string sql1;

			// picture loading
		Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			// to select W/H for stock take
		int lMWNo;

		private void loadLanguage()
		{

			//NOTE: Caption has a spelling mistake, DB Entry 1213 is correct!
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1213;
			//Stock Take
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2506;
			//Show Differendce|Checked
			if (modRecordSet.rsLang.RecordCount){cmdDiff.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdDiff.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//NOTE: DB Entry 2507 requires "&" for accelerator key
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2507;
			//Save and Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1838;
			//Barcode|Checked
			if (modRecordSet.rsLang.RecordCount){Label1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1674;
			//Description|Checked
			if (modRecordSet.rsLang.RecordCount){Label2.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label2.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1676;
			//Qty|Checked
			if (modRecordSet.rsLang.RecordCount){Label3.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label3.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1080;
			//Search|Checked
			if (modRecordSet.rsLang.RecordCount){cmdsearch.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdsearch.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2512;
			//Show Pictures|Checked
			if (modRecordSet.rsLang.RecordCount){chkPic.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;chkPic.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmStockTakeCSV.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

//UPGRADE_WARNING: Event chkPic.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void chkPic_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (chkPic.CheckState) {
				this.Width = sizeConvertors.twipsToPixels(12675, true);
				picBC.Visible = true;
				imgBC.Visible = true;
				this.Left = sizeConvertors.twipsToPixels(400, true);
			} else {
				this.Width = sizeConvertors.twipsToPixels(8640, true);
				picBC.Visible = false;
				imgBC.Visible = false;
			}
		}

		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int MStockNew = 0;
			 // ERROR: Not supported in C#: OnErrorStatement

			ADODB.Recordset rsB = default(ADODB.Recordset);
			ADODB.Recordset rsk = default(ADODB.Recordset);

			rsB = new ADODB.Recordset();
			rsk = new ADODB.Recordset();

			rsk = modRecordSet.getRS(ref "SELECT * FROM " + Te_Name + "");

			if (rsk.RecordCount > 0) {
				//UPGRADE_WARNING: Couldn't resolve default property of object MStockNew. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MStockNew = 2;
				rsB = modRecordSet.getRS(ref "INSERT INTO StockGroup(StockGroup_Name,StockGroup_Disabled)VALUES('" + Te_Name + "',0)");
				UpdateCatalogID(ref (Te_Name));
			}
			MyErH:
			this.Close();

		}

		private void report_WHTransfer(ref string tblName)
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = default(CrystalDecisions.CrystalReports.Engine.ReportDocument);
			Report.Load("cryWHRecVerify.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT Company.Company_Name FROM Company;");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();

			sql = "SELECT Handheld777_0.HandHeldID, StockItem.StockItem_Name, Handheld777_0.Quantity";
			sql = sql + " FROM Handheld777_0 INNER JOIN StockItem ON Handheld777_0.HandHeldID = StockItem.StockItemID;";
			rs = modRecordSet.getRS(ref sql);

			CrystalDecisions.CrystalReports.Engine.ReportDocument ReportNone = default(CrystalDecisions.CrystalReports.Engine.ReportDocument);
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

		private void cmdDiff_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string strIn = null;
			string strFldName = null;
			//Te_Name
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rj = default(ADODB.Recordset);

			 // ERROR: Not supported in C#: OnErrorStatement

			//Set rs = getRS("SELECT * FROM Te_Name")

			modRecordSet.cnnDB.Execute("DELETE * FROM Handheld777_0;");
			modRecordSet.cnnDB.Execute("DROP TABLE Handheld777_0;");
			strFldName = "HandHeldID Number,Handheld_Barcode Text(50), Quantity Currency";
			modRecordSet.cnnDB.Execute("CREATE TABLE " + "Handheld777_0" + " (" + strFldName + ")");
			System.Windows.Forms.Application.DoEvents();

			rj = modRecordSet.getRS(ref "SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity From WarehouseStockItemLnk WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=" + lMWNo + ") AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity)>0))");
			while (rj.EOF == false) {

				rs = modRecordSet.getRS(ref "SELECT * FROM " + Te_Name + " WHERE HandHeldID=" + rj.Fields("WarehouseStockItemLnk_StockItemID").Value + ";");
				if (rs.RecordCount > 0) {
				} else {
					strIn = "INSERT INTO Handheld777_0 (HandHeldID,Handheld_Barcode,Quantity) VALUES (" + rj.Fields("WarehouseStockItemLnk_StockItemID").Value + ", '" + rj.Fields("WarehouseStockItemLnk_Quantity").Value + "', " + rj.Fields("WarehouseStockItemLnk_Quantity").Value + ")";
					modRecordSet.cnnDB.Execute(strIn);
				}

				rj.moveNext();
			}

			report_WHTransfer(ref "Handheld777_0");

			modRecordSet.cnnDB.Execute("DELETE * FROM Handheld777_0;");
			modRecordSet.cnnDB.Execute("DROP TABLE Handheld777_0;");
			return;
			diff_Error:
			Interaction.MsgBox(Err().Number + " " + Err().Description);
		}

		private void cmdsearch_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string eroor = null;
			 // ERROR: Not supported in C#: OnErrorStatement

			//openConnection
			ADODB.Recordset rsP = default(ADODB.Recordset);
			ADODB.Recordset rsk = default(ADODB.Recordset);
			ADODB.Recordset rsTest = default(ADODB.Recordset);
			ADODB.Recordset rsNew = default(ADODB.Recordset);

			rs = new ADODB.Recordset();
			rsP = new ADODB.Recordset();
			rsk = new ADODB.Recordset();
			rsk = new ADODB.Recordset();
			rsTest = new ADODB.Recordset();
			rsNew = new ADODB.Recordset();
			if (string.IsNullOrEmpty(this.txtcode.Text))
				return;
			//If Me.txtCode.Text <> "" Then
			//creating table name
			//Te_Name = "HandHeld" & Trim(Year(Date)) & Trim(Month(Date)) & Trim(Day(Date)) & Trim(Hour(Now)) & Trim(Minute(Now)) & Trim(Second(Now)) & "_" & frmMenu.lblUser.Tag
			rsTest = modRecordSet.getRS(ref "SELECT Barcodes,Description,Quantity FROM " + Te_Name + "");

			//If rsTest.RecordCount And MStockNew = 0 Then
			rs = modRecordSet.getRS(ref "SELECT * FROM Catalogue WHERE Catalogue_Barcode='" + this.txtcode.Text + "'");

			//check if the barcode exists
			if (rs.RecordCount > 0) {
				rsP = modRecordSet.getRS(ref "SELECT StockItem_Name FROM StockItem WHERE StockItemID=" + rs.Fields("Catalogue_StockItemID").Value + "");
				this.txtdesc.Text = rsP.Fields("StockItem_Name").Value;
				this.txtqty.Focus();

				//show pic
				if (this.cmdsearch.Text != "&Add") {
					if (chkPic.CheckState & picBC.Visible == true) {
						if (fso.FileExists(modRecordSet.serverPath + "\\images\\" + this.txtcode.Text + ".jpg")) {
							picBC.Image = System.Drawing.Image.FromFile(modRecordSet.serverPath + "\\images\\" + this.txtcode.Text + ".jpg");
							imgBC.Image = picBC.Image;
						} else {
							Interaction.MsgBox("No picture found for " + this.txtcode.Text);
						}
					}
				}
				//show pic

				this.cmdsearch.Text = "&Add";
				//if the barcode does not exist display a message
			} else if (rs.RecordCount < 1) {
				Interaction.MsgBox("The Item does not exist,Please add it in Stock Create/Edit, New Stock Item", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, "4POS");
				this.txtcode.Text = "";
				this.txtcode.Focus();
				return;
			}

			//Checking if the barcode was found and if the quantity textbox has a value
			double NewQty = 0;
			if (this.cmdsearch.Text == "&Add" & !string.IsNullOrEmpty(this.txtqty.Text)) {
				//creating fields with their data types
				MyFTypes = "HandHeldID Number,Barcodes Text(50),Description Text(50),Quantity Currency";

				rsk = modRecordSet.getRS(ref "SELECT * FROM " + Te_Name + "");
				//if the table has not been created yet create it
				switch (eroor) {
					case  // ERROR: Case labels with binary operators are unsupported : LessThan
0:
						 // ERROR: Not supported in C#: ErrorStatement

						break;
					case 1:
						goto erh;
						break;
				}
				erh:

				modRecordSet.cnnDB.Execute("CREATE TABLE " + Te_Name + " (" + MyFTypes + ")");

				//selecting from the new table created
				rsNew = modRecordSet.getRS(ref "SELECT * FROM " + Te_Name + " WHERE Barcodes='" + this.txtcode.Text + "'");
				//if the item is already in the newly created table then add the previous quantity to the new one then update it
				if (rsNew.RecordCount > 0) {

					NewQty = Convert.ToDouble(this.txtqty.Text);

					NewQty = NewQty + rsNew.Fields("Quantity").Value;
					//update the quantity
					rsk = modRecordSet.getRS(ref "UPDATE " + Te_Name + " SET Quantity=" + NewQty + " WHERE Barcodes='" + this.txtcode.Text + "'");
				} else if (rsNew.RecordCount < 1) {
					//inserting into the newly created table
					rsk = modRecordSet.getRS(ref "INSERT INTO " + Te_Name + "(HandHeldID,Barcodes,Description,Quantity)VALUES(" + rs.Fields("Catalogue_StockItemID").Value + ",'" + this.txtcode.Text + "','" + this.txtdesc.Text + "'," + this.txtqty.Text + " )");
				}

				//selecting from the newly created table
				rsk = modRecordSet.getRS(ref "SELECT Barcodes,Description,Quantity FROM " + Te_Name + "");
				//filling the datagrid with the record consisting of barcode,description,quantity if the barcode exist
				this.DataGrid1.DataSource = rsk;
				this.txtcode.Text = "";
				this.txtdesc.Text = "";
				this.txtqty.Text = "";
				this.cmdsearch.Text = "&Search";
				this.txtcode.Focus();

			}
			//ElseIf rsTest.RecordCount > 0 And MStockNew = 2 Then
			//MsgBox "A Table with the Same Name Already Exist", vbApplicationModal + vbOKOnly, "4POS"
			//Me.txtCode.Text = ""
			//Me.cmdClose.SetFocus
			//End If
		}

		private void frmStockTakeCSV_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);

			if (KeyAscii == 13 & this.cmdsearch.Text == "&Search" & !string.IsNullOrEmpty(this.txtcode.Text)) {
				cmdsearch_Click(cmdsearch, new System.EventArgs());
			} else if (KeyAscii == 13 & this.cmdsearch.Text == "&Add" & !string.IsNullOrEmpty(this.txtdesc.Text)) {
				cmdsearch_Click(cmdsearch, new System.EventArgs());
			} else if (KeyAscii == 27) {
				cmdClose_Click(cmdClose, new System.EventArgs());
			}

			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		public void UpdateCatalogID(ref string st_Name)
		{
			string strFldName = null;
			string strIn = null;
			ADODB.Recordset rj = default(ADODB.Recordset);
			ADODB.Recordset rs = default(ADODB.Recordset);
			ADODB.Recordset rID = default(ADODB.Recordset);

			//Set rID = getRS("SELECT * FROM " & st_Name)
			//Do While rID.EOF = False
			//        If prgUpdate.value = prgUpdate.Max Then
			//           prgUpdate.value = 0
			//        Else
			//           prgUpdate.value = prgUpdate.value + 1
			//        End If
			//    'rID("Handheld_Barcode") = 0
			//        rID("HandHeldID") = 0
			//        rID.update '"HandHeldID", 0
			// rID.moveNext
			//Loop

			strIn = "UPDATE " + st_Name + " SET HandHeldID = 0 WHERE Quantity > 0;";
			modRecordSet.cnnDB.Execute(strIn);

			rj = modRecordSet.getRS(ref "SELECT * FROM " + st_Name);
			while (rj.EOF == false) {
				//If prgUpdate.value = prgUpdate.Max Then
				//   prgUpdate.value = 0
				//Else
				//   prgUpdate.value = prgUpdate.value + 1
				//End If

				//Set rs = getRS("SELECT * FROM Catalogue WHERE Catalogue_Barcode = '" & rj("Handheld_Barcode") & "'")
				rs = modRecordSet.getRS(ref "SELECT StockItem.StockItem_Disabled, StockItem.StockItem_Discontinued, * FROM Catalogue INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID WHERE (((Catalogue.Catalogue_Barcode)='" + rj.Fields("Barcodes").Value + "') AND ((StockItem.StockItem_Disabled)=False) AND ((StockItem.StockItem_Discontinued)=False));");
				if (rs.RecordCount > 0)
					modRecordSet.cnnDB.Execute("UPDATE " + st_Name + " SET HandHeldID = " + rs.Fields("Catalogue_StockItemID").Value + ", Quantity = " + (rj.Fields("Quantity").Value * rs.Fields("Catalogue_Quantity").Value) + " WHERE Barcodes = '" + rj.Fields("Barcodes").Value + "'");

				rj.moveNext();
			}

			//chkDuplicate:
			strFldName = "HandHeldID Number,Barcodes Text(50),Description Text(50),Quantity Currency";
			modRecordSet.cnnDB.Execute("CREATE TABLE " + "Handheld777" + " (" + strFldName + ")");
			System.Windows.Forms.Application.DoEvents();

			rj = modRecordSet.getRS(ref "SELECT * FROM " + st_Name);
			while (rj.EOF == false) {

				rs = modRecordSet.getRS(ref "SELECT * FROM Handheld777 WHERE HandHeldID=" + rj.Fields("HandHeldID").Value + ";");
				if (rs.RecordCount > 0) {
					strIn = "UPDATE Handheld777 SET Quantity = " + (rs.Fields("Quantity").Value + rj.Fields("Quantity").Value) + " WHERE HandHeldID=" + rj.Fields("HandHeldID").Value + ";";
				} else {
					strIn = "INSERT INTO Handheld777 (HandHeldID,Barcodes,Quantity) VALUES (" + rj.Fields("HandHeldID").Value + ", '" + rj.Fields("Barcodes").Value + "', " + rj.Fields("Quantity").Value + ")";
				}
				modRecordSet.cnnDB.Execute(strIn);

				rj.moveNext();
			}

			modRecordSet.cnnDB.Execute("DELETE * FROM " + st_Name + ";");
			//strIn = "SELECT Handheld777.* INTO " & st_Name & " FROM Handheld777" '& ResolveTable(cmbTables.Text)
			modRecordSet.cnnDB.Execute("INSERT INTO " + st_Name + " SELECT * FROM Handheld777;");
			modRecordSet.cnnDB.Execute("DROP TABLE Handheld777;");
			//chkDuplicate:

			//DeleteBlankID
			//MsgBox "File was extracted and exported succesfully", vbApplicationModal + vbInformation + vbOKOnly, App.title
			//prgUpdate.value = 300

		}

		private void frmStockTakeCSV_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			if (modRecordSet.cnnDB == null) {
				if (openConnection() == true) {

				}
			}
			//creating table name
			Te_Name = "HandHeld" + Strings.Trim(Convert.ToString(DateAndTime.Year(DateAndTime.Today))) + Strings.Trim(Convert.ToString(DateAndTime.Month(DateAndTime.Today))) + Strings.Trim(Convert.ToString(DateAndTime.Day(DateAndTime.Today))) + Strings.Trim(Convert.ToString(DateAndTime.Hour(DateAndTime.Now))) + Strings.Trim(Convert.ToString(DateAndTime.Minute(DateAndTime.Now))) + Strings.Trim(Convert.ToString(DateAndTime.Second(DateAndTime.Now))) + "_" + My.MyProject.Forms.frmMenu.lblUser.Tag;

			loadLanguage();

			lMWNo = My.MyProject.Forms.frmMWSelect.getMWNo();
			if (lMWNo > 1) {
				//Set rsWH = getRS("SELECT * FROM Warehouse WHERE WarehouseID=" & lMWNo & ";")
				//Report.txtWH.SetText rsWH("Warehouse_Name")
			}
		}
	}
}
