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
	internal partial class frmBarcodeStockitem : System.Windows.Forms.Form
	{
		ADODB.Recordset gRS;
		bool gCancel;
		string gOrder;
		List<TextBox> txtSearch = new List<TextBox>();
		bool loadCSV;

		private void loadLanguage()
		{
			//frmBarcodeStockItem = No Code  [Select Products for Barcode Printing]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmBarcodeStockItem.Caption = rsLang("LanguageLayoutLnk_Description"): frmBarcodeStockItem.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdLoad = No Code              [Load Qty from CSV file]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdLoad.Caption = rsLang("LanguageLayoutLnk_Description"): cmdLoad.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdShow = No Code              [Show Changed Price Items Or Selected Products]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdshow.Caption = rsLang("LanguageLayoutLnk_Description"): cmdshow.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdClear = No Code             [Clear All Selected Products]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdClear.Caption = rsLang("LanguageLayoutLnk_Description"): cmdClear.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Command1 = No Code             [Show Only with Single Qty]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Command1.Caption = rsLang("LanguageLayoutLnk_Description"): Command1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1085;
			//Print|Checked
			if (modRecordSet.rsLang.RecordCount){cmdPrint.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdPrint.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.Filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.Filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmBarcodeStockitem.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		public bool loadStock()
		{
			bool functionReturnValue = false;
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			if (modApplication.grvPrin) {
				if (fso.FileExists(modRecordSet.serverPath + "Shelfbarcode.dat")) {
				} else {
					Interaction.MsgBox("File " + modRecordSet.serverPath + "Shelfbarcode.dat not found", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly + MsgBoxStyle.Information, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
					this.Close();
					return functionReturnValue;
				}
				//show 1
				//loadStock = gCancel
			}

			loadLanguage();
			ShowDialog();
			functionReturnValue = gCancel;
			return functionReturnValue;

		}
		private void cmdClear_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modRecordSet.cnnDB.Execute("DELETE barcodePersonLnk.* From barcodePersonLnk WHERE (((barcodePersonLnk.barcodePersonLnk_PersonID)=" + modRecordSet.gPersonID + "));");
			modRecordSet.cnnDB.Execute("INSERT INTO barcodePersonLnk ( barcodePersonLnk_PersonID, barcodePersonLnk_StockItemID, barcodePersonLnk_Shrink, barcodePersonLnk_PrintQTY ) SELECT " + modRecordSet.gPersonID + ", Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, 0 FROM Catalogue;");
			doRS();
		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			gridEdit_LeaveCell(gridEdit, new System.EventArgs());
			gCancel = false;
			this.Close();
		}

		public string[] ImportCSVinArray(ref string sFileName, ref string sDelimiter = ",")
		{
			string[] functionReturnValue = null;

			string[,] MyArray = null;
			string[] sSplit = null;
			string sLine = null;
			int lRows = 0;
			int lColumns = 0;
			int lCounter = 0;
			string[,] Empty = new string[ + 1,  + 1] { {
				"",
				""
			} };

			 // ERROR: Not supported in C#: OnErrorStatement


			if (!string.IsNullOrEmpty(FileSystem.Dir(sFileName))) {
				//determine number of rows and columns needed
				lRows = 0;
				lColumns = 0;
				FileSystem.FileOpen(7, sFileName, OpenMode.Input);
				while (!(FileSystem.EOF(7))) {
					sLine = FileSystem.LineInput(7);
					if (Strings.Len(sLine) > 0) {
						sSplit = Strings.Split(sLine, sDelimiter);
						if (Information.UBound(sSplit) > lColumns)
							lColumns = Information.UBound(sSplit);
						lRows = lRows + 1;
					}
				}
				FileSystem.FileClose(7);


				//fill array
				//If lColumns = 1 Then 'no csv file!
				//  ReDim MyArray(lRows - 1)
				//  Open sFileName For Input As #7
				//  lRows = 0
				//  While Not (EOF(7))
				//    Line Input #7, sLine
				//    If Len(sLine) > 0 Then
				//      MyArray(lRows) = Val(sLine)
				//      lRows = lRows + 1
				//    End If
				//  Wend
				//  Close #7

				//ElseIf lColumns > 1 Then 'multidimensional csv file
				MyArray = new string[lRows, lColumns + 1];

				FileSystem.FileOpen(7, sFileName, OpenMode.Input);
				lRows = 0;
				while (!(FileSystem.EOF(7))) {
					sLine = FileSystem.LineInput(7);
					if (Strings.Len(sLine) > 0) {
						sSplit = Strings.Split(sLine, sDelimiter);
						for (lCounter = 0; lCounter <= Information.UBound(sSplit); lCounter++) {
							MyArray[lRows, lCounter] = Convert.ToString(Conversion.Val(sSplit[lCounter]));
						}
						lRows = lRows + 1;
					}
				}
				FileSystem.FileClose(7);

				//End If

				//return function
				functionReturnValue = MyArray.Clone();
			}
			return functionReturnValue;
			ErrHandler_ImportCSVinArray:
			return functionReturnValue;
			//ImportCSVinArray(, ) = Empty
		}

		private void cmdLoad_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string sql = null;
			ADODB.Recordset rs = default(ADODB.Recordset);
			string[] arrloadCSV = null;
			string strname = null;

			 // ERROR: Not supported in C#: OnErrorStatement


			var _with1 = cmdDlgOpen;
			_with1.Filter = "Data File (*.csv)|*.csv";
			_with1.Title = "Open a file...";
			_with1.ShowDialog();
			strname = cmdDlgOpen.FileName;
			if (string.IsNullOrEmpty(strname))
				return;

			arrloadCSV = ImportCSVinArray(strname);
			//loadCSV = True
			//asdf = arrloadCSV(0, 1)
			int x = 0;
			int y = 0;
			//On Local Error Resume Next
			x = 1;
			var _with2 = gridEdit;
			_with2.Visible = false;
			_with2.RowCount = gRS.RecordCount + 1;
			gCancel = false;
			gRS.MoveFirst();
			while (!(gRS.EOF)) {
				gridEdit.set_TextMatrix(ref ref x, ref ref 0, ref ref gRS.Fields("Catalogue_Barcode").Value);
				gridEdit.set_TextMatrix(ref ref x, ref ref 1, ref ref gRS.Fields("StockItemID").Value);
				gridEdit.set_TextMatrix(ref ref x, ref ref 2, ref ref " " + gRS.Fields("Catalogue_Quantity").Value + "x" + gRS.Fields("StockItem_Name").Value);
				gridEdit.set_TextMatrix(ref ref x, ref ref 3, ref ref " " + gRS.Fields("Supplier_Name").Value);
				gridEdit.set_TextMatrix(ref ref x, ref ref 4, ref ref " " + gRS.Fields("PricingGroup_Name").Value);

				int lRows = 0;
				int lColumns = 0;
				for (lRows = 0; lRows <= Information.UBound(arrloadCSV); lRows++) {
					if (arrloadCSV[lRows] == gRS.Fields("Catalogue_Barcode").Value)
						lColumns = arrloadCSV[lRows];
				}

				if (lColumns == 0) {
					gridEdit.set_TextMatrix(ref ref x, ref ref 5, ref ref gRS.Fields("barcodePersonLnk_PrintQTY").Value);
				} else {
					gridEdit.set_TextMatrix(ref ref x, ref ref 5, ref ref lColumns);

					if (rs.State)
						rs.Close();
					sql = "SELECT Catalogue_Quantity FROM Catalogue WHERE Catalogue_StockItemID = " + gRS.Fields("StockItemID").Value + " AND Catalogue_Barcode = '" + Strings.Trim(gRS.Fields("Catalogue_Barcode").Value) + "'";
					rs = modRecordSet.getRS(ref ref sql);
					sql = "UPDATE barcodePersonLnk SET barcodePersonLnk.barcodePersonLnk_PrintQTY = " + lColumns + " WHERE (((barcodePersonLnk.barcodePersonLnk_PersonID)=" + modRecordSet.gPersonID + ") AND ((barcodePersonLnk.barcodePersonLnk_StockItemID)=" + gRS.Fields("StockItemID").Value + ") AND ((barcodePersonLnk.barcodePersonLnk_Shrink)= " + rs("Catalogue_Quantity").Value + "));";
					modRecordSet.cnnDB.Execute(sql);
				}

				x = x + 1;
				if (x % 10) {
				} else {
					System.Windows.Forms.Application.DoEvents();
					if (gCancel)
						break; // TODO: might not be correct. Was : Exit Do
				}
				gRS.moveNext();
			}
			_with2.RowCount = x;
			_with2.Visible = true;

			//loadCSV = False

			return;
			errL:
			 // ERROR: Not supported in C#: ResumeStatement

		}

		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			gridEdit_LeaveCell(gridEdit, new System.EventArgs());
			gCancel = true;
			this.Close();
		}
		private void cmdShow_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			doRS(ref true);
		}

		private void Command1_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modRecordSet.cnnDB.Execute("UPDATE barcodePersonLnk SET barcodePersonLnk.barcodePersonLnk_PrintQTY = 0 WHERE ((barcodePersonLnk.barcodePersonLnk_PersonID)=" + modRecordSet.gPersonID + ") AND ((barcodePersonLnk.barcodePersonLnk_Shrink) > 1);");
			//doRS
			doRSSingle(ref true);

		}

		private void frmBarcodeStockitem_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			short KeyAscii = Strings.Asc(eventArgs.KeyCode);

			if (KeyAscii == 27 & Shift == 2)
				gCancel = true;

		}
		private void frmBarcodeStockitem_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			int x = 0;
			string lOrder = null;
			string sql = null;
			string stSring = null;
			ADODB.Recordset rsPrinter_B = new ADODB.Recordset();
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			TextBox tb = new TextBox();
			txtSearch.AddRange(new TextBox[] {
				_txtSearch_0,
				_txtSearch_1,
				_txtSearch_2,
				_txtSearch_3,
				_txtSearch_4
			});
			foreach (TextBox tb_loopVariable in txtSearch) {
				tb = tb_loopVariable;
				tb.TextChanged += txtSearch_TextChanged;
				tb.Enter += txtSearch_Enter;
				tb.KeyDown += txtSearch_KeyDown;
				tb.KeyPress += txtSearch_KeyPress;
				tb.Leave += txtSearch_Leave;
			}
			modBResolutions.ResizeForm(ref this, ref sizeConvertors.pixelToTwips(this.Width, true), ref sizeConvertors.pixelToTwips(this.Height, false), ref 0);

			 // ERROR: Not supported in C#: OnErrorStatement

			//Doing shelf from file
			if (modApplication.grvPrin) {
				//rsPrinter_B.Close
				rsPrinter_B.Open(modRecordSet.serverPath + "ShelfBarcode.dat");
				//rsPrinter_B.filter = ""
				//If frmBarcode._optBarcode_2.value = True Then rsPrinter_B.filter = "StockItem_SBarcode ='barcode'"
				//If frmBarcode._optBarcode_1.value = True Then rsPrinter_B.filter = "StockItem_SBarcode ='shelf'"

				if (My.MyProject.Forms.frmBarcode._optBarcode_2.Checked == true)
					rsPrinter_B.filter = "StockItem_SBarcode = true";
				if (My.MyProject.Forms.frmBarcode._optBarcode_1.Checked == true)
					rsPrinter_B.filter = "StockItem_SShelf =true";

				//If grvPrinType = 1 Then rsPrinter_B.filter = "StockItem_SBarcode ='shelf'"

				modRecordSet.cnnDB.Execute("DELETE * FROM barcodePersonLnk");

				while (!(rsPrinter_B.EOF)) {
					//If its a shelf talker.....
					if (My.MyProject.Forms.frmBarcode._optBarcode_1.Checked == true) {
						sql = "INSERT INTO barcodePersonLnk ( barcodePersonLnk_PersonID, barcodePersonLnk_StockItemID, barcodePersonLnk_Shrink,barcodePersonLnk_PrintQTY ) ";
						sql = sql + "SELECT theJoin.Person, theJoin.Catalogue_StockItemID, theJoin.Catalogue_Quantity , theJoin.PrinQTY FROM (SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, " + modRecordSet.gPersonID + " AS Person, 1 AS PrinQTY FROM Catalogue WHERE Catalogue.Catalogue_Quantity = 1 AND Catalogue_StockItemID = " + rsPrinter_B.Fields("GRVItem_StockItemID").Value + ") AS theJoin";

					} else {
						sql = "INSERT INTO barcodePersonLnk ( barcodePersonLnk_PersonID, barcodePersonLnk_StockItemID, barcodePersonLnk_Shrink,barcodePersonLnk_PrintQTY ) ";
						sql = sql + "SELECT theJoin.Person, theJoin.Catalogue_StockItemID, theJoin.Catalogue_Quantity , theJoin.PrinQTY FROM (SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, " + modRecordSet.gPersonID + " AS Person, " + rsPrinter_B.Fields("GRVItem_Quantity").Value + " AS PrinQTY FROM Catalogue WHERE Catalogue.Catalogue_Quantity = 1 AND Catalogue_StockItemID = " + rsPrinter_B.Fields("GRVItem_StockItemID").Value + ") AS theJoin";

					}
					#if DEBUG
					Debug.Print(sql);
					#endif

					modRecordSet.cnnDB.Execute(sql);
					rsPrinter_B.moveNext();
				}
			} else {
				modRecordSet.cnnDB.Execute("DELETE * FROM barcodePersonLnk");
				sql = "INSERT INTO barcodePersonLnk ( barcodePersonLnk_PersonID, barcodePersonLnk_StockItemID, barcodePersonLnk_Shrink ) ";
				sql = sql + "SELECT theJoin.Person, theJoin.Catalogue_StockItemID, theJoin.Catalogue_Quantity ";
				sql = sql + "FROM (SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, " + modRecordSet.gPersonID + " AS Person FROM Catalogue) AS theJoin LEFT JOIN barcodePersonLnk ON (theJoin.Person = barcodePersonLnk.barcodePersonLnk_PersonID) AND (theJoin.Catalogue_Quantity = barcodePersonLnk.barcodePersonLnk_Shrink) AND (theJoin.Catalogue_StockItemID = barcodePersonLnk.barcodePersonLnk_StockItemID) WHERE (((barcodePersonLnk.barcodePersonLnk_PersonID) Is Null));";
				modRecordSet.cnnDB.Execute(sql);
			}


			int lLeft = 0;
			var _with3 = gridEdit;
			_with3.Col = 7;
			_with3.RowCount = 0;
			System.Windows.Forms.Application.DoEvents();
			_with3.RowCount = 2;
			_with3.FixedRows = 1;
			_with3.FixedCols = 0;
			_with3.row = 0;
			_with3.Col = 0;
			_with3.CellFontBold = true;
			_with3.Text = "Barcode";
			_with3.set_ColWidth(0, 1400);
			_with3.CellAlignment = 7;
			_with3.Col = 1;
			_with3.CellFontBold = true;
			_with3.Text = "ID";
			_with3.set_ColWidth(1, 800);
			_with3.CellAlignment = 4;
			_with3.Col = 2;
			_with3.CellFontBold = true;
			_with3.Text = "Stock Name";
			_with3.set_ColWidth(2, 2000);
			_with3.CellAlignment = 1;
			_with3.Col = 3;
			_with3.CellFontBold = true;
			_with3.Text = "Supplier";
			_with3.set_ColWidth(3, 2000);
			_with3.CellAlignment = 1;
			_with3.Col = 4;
			_with3.CellFontBold = true;
			_with3.Text = "Department";
			_with3.set_ColWidth(4, 2000);
			_with3.CellAlignment = 1;
			_with3.Col = 5;
			_with3.CellFontBold = true;
			_with3.Text = "QTY";
			_with3.set_ColWidth(5, 800);
			_with3.CellAlignment = 1;
			_with3.Col = 6;
			_with3.CellFontBold = true;
			_with3.Text = "Price Status";
			_with3.set_ColWidth(6, 1300);
			_with3.CellAlignment = 2;
			lOrder = " ORDER BY StockItem.StockItem_Name";
			lLeft = sizeConvertors.pixelToTwips(_with3.Left, true);

			for (x = 0; x <= txtSearch.Count; x++) {
				txtSearch[x].Left = sizeConvertors.twipsToPixels(lLeft, true);
				txtSearch[x].Width = sizeConvertors.twipsToPixels(_with3.get_ColWidth(x), true);
				lLeft = lLeft + sizeConvertors.pixelToTwips(txtSearch[x].Width, true);
			}
			_with3.Col = 0;
			doRS(ref ref true);
			//doRS True
			doRS();

			return;
			ErrLoadForm:
			if (Err().Number == 0) {
				 // ERROR: Not supported in C#: ResumeStatement

			#if DEBUG
			} else {
				Debug.Print(Err().Number);
				#endif

				Interaction.MsgBox(Err().Number + Err().Description);
				 // ERROR: Not supported in C#: ResumeStatement

			}
		}

		private void doRS(ref bool show_Renamed = false)
		{
			string sql = null;
			string lString = null;
			string lFilter = null;
			System.Windows.Forms.TextBox oText = null;
			lFilter = "";
			gridEdit_LeaveCell(gridEdit, new System.EventArgs());
			if (show_Renamed) {
				if (modApplication.grvPrin) {
					lFilter = " Where Catalogue.Catalogue_Quantity = 1 AND CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = 1 AND barcodePersonLnk.barcodePersonLnk_PersonID=" + modRecordSet.gPersonID + " AND barcodePersonLnk.barcodePersonLnk_PrintQTY <> 0  AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ";
				} else {
					lFilter = " Where CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = 1 AND barcodePersonLnk.barcodePersonLnk_PersonID=" + modRecordSet.gPersonID + " AND barcodePersonLnk.barcodePersonLnk_PrintQTY <> 0  AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ";
				}
			} else {
				foreach (TextBox oText_loopVariable in txtSearch) {
					oText = oText_loopVariable;
					lString = doSearch(ref (oText.Tag), ref (oText.Text));
					if (!string.IsNullOrEmpty(lString))
						lFilter = lFilter + " AND " + lString + "";
				}

				if (modApplication.grvPrin) {
					lFilter = " Where Catalogue.Catalogue_Quantity = 1 AND CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = 1 AND barcodePersonLnk.barcodePersonLnk_PersonID=" + modRecordSet.gPersonID + " AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False" + lFilter;
				} else {
					lFilter = " Where CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = 1 AND barcodePersonLnk.barcodePersonLnk_PersonID=" + modRecordSet.gPersonID + " AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False" + lFilter;
				}
			}
			//sql = "SELECT StockItem.StockItemID, Catalogue.Catalogue_Quantity, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Supplier.SupplierID, Supplier.Supplier_Name, PricingGroup.PricingGroupID, PricingGroup.PricingGroup_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (((StockItem INNER JOIN Supplier ON StockItem.StockItem_SupplierID = Supplier.SupplierID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)"
			sql = "SELECT StockItem.StockItemID, Catalogue.Catalogue_Quantity, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Supplier.SupplierID, Supplier.Supplier_Name, PricingGroup.PricingGroupID, PricingGroup.PricingGroup_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, barcodePersonLnk.barcodePersonLnk_PersonID, barcodePersonLnk.barcodePersonLnk_PrintQTY ";
			sql = sql + " FROM barcodePersonLnk INNER JOIN ((((StockItem INNER JOIN Supplier ON StockItem.StockItem_SupplierID = Supplier.SupplierID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity)) ON (barcodePersonLnk.barcodePersonLnk_Shrink = Catalogue.Catalogue_Quantity) AND (barcodePersonLnk.barcodePersonLnk_StockItemID = Catalogue.Catalogue_StockItemID) ";
			gRS = modRecordSet.getRS(ref sql + lFilter + gOrder);
			txtEdit.Visible = false;
			loadData();
		}

		private void doRSSingle(ref bool show_Renamed = false)
		{
			string sql = null;
			string lString = null;
			string lFilter = null;
			System.Windows.Forms.TextBox oText = null;
			lFilter = "";
			gridEdit_LeaveCell(gridEdit, new System.EventArgs());
			if (show_Renamed) {
				lFilter = " Where CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = 1 AND barcodePersonLnk.barcodePersonLnk_PersonID=" + modRecordSet.gPersonID + " AND barcodePersonLnk.barcodePersonLnk_PrintQTY <> 0 AND barcodePersonLnk.barcodePersonLnk_Shrink = 1 AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ";
			} else {
				foreach (TextBox oText_loopVariable in txtSearch) {
					oText = oText_loopVariable;
					lString = doSearch(ref (oText.Tag), ref (oText.Text));
					if (!string.IsNullOrEmpty(lString))
						lFilter = lFilter + " AND " + lString + "";
				}


				lFilter = " Where CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = 1 AND barcodePersonLnk.barcodePersonLnk_PersonID=" + modRecordSet.gPersonID + " AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False" + lFilter;
			}
			//sql = "SELECT StockItem.StockItemID, Catalogue.Catalogue_Quantity, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Supplier.SupplierID, Supplier.Supplier_Name, PricingGroup.PricingGroupID, PricingGroup.PricingGroup_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (((StockItem INNER JOIN Supplier ON StockItem.StockItem_SupplierID = Supplier.SupplierID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)"
			sql = "SELECT StockItem.StockItemID, Catalogue.Catalogue_Quantity, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Supplier.SupplierID, Supplier.Supplier_Name, PricingGroup.PricingGroupID, PricingGroup.PricingGroup_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, barcodePersonLnk.barcodePersonLnk_PersonID, barcodePersonLnk.barcodePersonLnk_PrintQTY ";
			sql = sql + " FROM barcodePersonLnk INNER JOIN ((((StockItem INNER JOIN Supplier ON StockItem.StockItem_SupplierID = Supplier.SupplierID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity)) ON (barcodePersonLnk.barcodePersonLnk_Shrink = Catalogue.Catalogue_Quantity) AND (barcodePersonLnk.barcodePersonLnk_StockItemID = Catalogue.Catalogue_StockItemID) ";
			gRS = modRecordSet.getRS(ref sql + lFilter + gOrder);
			txtEdit.Visible = false;
			loadData();
		}


		private void changePrice()
		{
			int lColumns = 0;
			int lRows = 0;
			string sql = null;
			//Dim arrloadCSV() As String
			string strname = null;
			ADODB.Recordset gRSPrice = default(ADODB.Recordset);
			ADODB.Recordset rs = default(ADODB.Recordset);

			 // ERROR: Not supported in C#: OnErrorStatement


			sql = "TRANSFORM Sum(Query2.POSCatalogueChannelLnk_Price) AS SumOfPOSCatalogueChannelLnk_Price SELECT Query2.StockItemID, Query2.StockItem_Name, Query2.CatalogueChannelLnk_Quantity FROM (SELECT StockItem.StockItemID, StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price, POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price ";
			sql = sql + "FROM ((POSUpdate_PriceChangeSummary INNER JOIN StockItem ON POSUpdate_PriceChangeSummary.CatalogueChannelLnk_StockItemID = StockItem.StockItemID) INNER JOIN CatalogueChannelLnk ON (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = POSUpdate_PriceChangeSummary.CatalogueChannelLnk_Quantity) AND (POSUpdate_PriceChangeSummary.CatalogueChannelLnk_ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) AND (StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)) INNER JOIN POSCatalogueChannelLnk ON (CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID) ORDER BY StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) ";
			sql = sql + "Query2 GROUP BY Query2.StockItemID, Query2.StockItem_Name, Query2.CatalogueChannelLnk_Quantity PIVOT Query2.CatalogueChannelLnk_ChannelID;";
			//Set gRSPrice = getRS("SELECT StockItem.StockItemID, systemStockItemPricing.systemStockItemPricing FROM StockItem INNER JOIN systemStockItemPricing ON StockItem.StockItemID = systemStockItemPricing.systemStockItemPricing;")
			gRSPrice = modRecordSet.getRS(ref sql);

			int x = 0;
			int y = 0;
			//On Local Error Resume Next

			if (gRSPrice.RecordCount > 0) {
			} else {
				return;
			}
			x = 1;
			var _with4 = gridEdit;
			_with4.Visible = false;
			_with4.RowCount = gRS.RecordCount + 1;
			gCancel = false;
			gRS.MoveFirst();
			while (!(gRS.EOF)) {
				gridEdit.set_TextMatrix(ref ref x, ref ref 0, ref ref gRS.Fields("Catalogue_Barcode").Value);
				gridEdit.set_TextMatrix(ref ref x, ref ref 1, ref ref gRS.Fields("StockItemID").Value);
				gridEdit.set_TextMatrix(ref ref x, ref ref 2, ref ref " " + gRS.Fields("Catalogue_Quantity").Value + "x" + gRS.Fields("StockItem_Name").Value);
				gridEdit.set_TextMatrix(ref ref x, ref ref 3, ref ref " " + gRS.Fields("Supplier_Name").Value);
				gridEdit.set_TextMatrix(ref ref x, ref ref 4, ref ref " " + gRS.Fields("PricingGroup_Name").Value);

				lRows = 0;
				lColumns = 0;
				//For lRows = 0 To UBound(arrloadCSV)
				//    If arrloadCSV(lRows, 0) = gRS("Catalogue_Barcode") Then lColumns = arrloadCSV(lRows, 1)
				//Next
				gRSPrice.MoveFirst();
				while (!(gRSPrice.EOF)) {
					if (gRSPrice.Fields("StockItemID").Value == gRS.Fields("StockItemID").Value)
						lColumns = 1;
					gRSPrice.moveNext();
				}

				if (lColumns == 0) {
					gridEdit.set_TextMatrix(ref ref x, ref ref 5, ref ref gRS.Fields("barcodePersonLnk_PrintQTY").Value);
				} else {
					gridEdit.set_TextMatrix(ref ref x, ref ref 5, ref ref lColumns);
					gridEdit.set_TextMatrix(ref ref x, ref ref 6, ref ref "Changed");

					//If rs.State Then rs.Close
					//sql = "SELECT Catalogue_Quantity FROM Catalogue WHERE Catalogue_StockItemID = " & Val(gridEdit.TextMatrix(gridEdit.row, 1)) & " AND Catalogue_Barcode = '" & Trim(gridEdit.TextMatrix(gridEdit.row, 0)) & "'"
					sql = "SELECT Catalogue_Quantity FROM Catalogue WHERE Catalogue_StockItemID = " + gRS.Fields("StockItemID").Value + " AND Catalogue_Barcode = '" + Strings.Trim(gRS.Fields("Catalogue_Barcode").Value) + "'";
					rs = modRecordSet.getRS(ref ref sql);
					modRecordSet.cnnDB.Execute("UPDATE barcodePersonLnk SET barcodePersonLnk.barcodePersonLnk_PrintQTY = " + lColumns + " WHERE (((barcodePersonLnk.barcodePersonLnk_PersonID)=" + modRecordSet.gPersonID + ") AND ((barcodePersonLnk.barcodePersonLnk_StockItemID)=" + gRS.Fields("StockItemID").Value + ") AND ((barcodePersonLnk.barcodePersonLnk_Shrink)= " + rs.Fields("Catalogue_Quantity").Value + "));");
					rs.Close();
				}


				x = x + 1;
				if (x % 10) {
				} else {
					System.Windows.Forms.Application.DoEvents();
					if (gCancel)
						break; // TODO: might not be correct. Was : Exit Do
				}
				gRS.moveNext();
			}
			_with4.RowCount = x;
			_with4.Visible = true;

			return;
			errL:
			 // ERROR: Not supported in C#: ResumeStatement

		}

		private void newPrice()
		{
			int lColumns = 0;
			int lRows = 0;
			string sql = null;
			//Dim arrloadCSV() As String
			string strname = null;
			ADODB.Recordset gRSPrice = default(ADODB.Recordset);
			ADODB.Recordset rs = default(ADODB.Recordset);

			 // ERROR: Not supported in C#: OnErrorStatement


			sql = "TRANSFORM Sum(newItems.CatalogueChannelLnk_Price) AS SumOfCatalogueChannelLnk_Price SELECT newItems.StockItemID, newItems.StockItem_Name, newItems.CatalogueChannelLnk_Quantity FROM [SELECT StockItem.StockItemID, StockItem.StockItem_Name, POSUpdate_PriceNewSummary.CatalogueChannelLnk_ChannelID, POSUpdate_PriceNewSummary.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM CatalogueChannelLnk INNER JOIN (POSUpdate_PriceNewSummary INNER JOIN StockItem ON POSUpdate_PriceNewSummary.CatalogueChannelLnk_StockItemID = StockItem.StockItemID) ON (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = POSUpdate_PriceNewSummary.CatalogueChannelLnk_Quantity) AND (CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = POSUpdate_PriceNewSummary.CatalogueChannelLnk_ChannelID) AND (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = POSUpdate_PriceNewSummary.CatalogueChannelLnk_StockItemID) ";
			sql = sql + "ORDER BY StockItem.StockItem_Name, POSUpdate_PriceNewSummary.CatalogueChannelLnk_ChannelID, POSUpdate_PriceNewSummary.CatalogueChannelLnk_Quantity]. AS newItems GROUP BY newItems.StockItemID, newItems.StockItem_Name, newItems.CatalogueChannelLnk_Quantity PIVOT newItems.CatalogueChannelLnk_ChannelID;";
			//Set gRSPrice = getRS("SELECT StockItem.StockItemID, systemStockItemPricing.systemStockItemPricing FROM StockItem INNER JOIN systemStockItemPricing ON StockItem.StockItemID = systemStockItemPricing.systemStockItemPricing;")
			gRSPrice = modRecordSet.getRS(ref sql);

			int x = 0;
			int y = 0;
			//On Local Error Resume Next

			if (gRSPrice.RecordCount > 0) {
			} else {
				return;
			}
			x = 1;
			var _with5 = gridEdit;
			_with5.Visible = false;
			_with5.RowCount = gRS.RecordCount + 1;
			gCancel = false;
			gRS.MoveFirst();
			while (!(gRS.EOF)) {
				gridEdit.set_TextMatrix(ref ref x, ref ref 0, ref ref gRS.Fields("Catalogue_Barcode").Value);
				gridEdit.set_TextMatrix(ref ref x, ref ref 1, ref ref gRS.Fields("StockItemID").Value);
				gridEdit.set_TextMatrix(ref ref x, ref ref 2, ref ref " " + gRS.Fields("Catalogue_Quantity").Value + "x" + gRS.Fields("StockItem_Name").Value);
				gridEdit.set_TextMatrix(ref ref x, ref ref 3, ref ref " " + gRS.Fields("Supplier_Name").Value);
				gridEdit.set_TextMatrix(ref ref x, ref ref 4, ref ref " " + gRS.Fields("PricingGroup_Name").Value);

				lRows = 0;
				lColumns = 0;
				//For lRows = 0 To UBound(arrloadCSV)
				//    If arrloadCSV(lRows, 0) = gRS("Catalogue_Barcode") Then lColumns = arrloadCSV(lRows, 1)
				//Next
				gRSPrice.MoveFirst();
				while (!(gRSPrice.EOF)) {
					if (gRSPrice.Fields("StockItemID").Value == gRS.Fields("StockItemID").Value)
						lColumns = 1;
					gRSPrice.moveNext();
				}

				if (lColumns == 0) {
					gridEdit.set_TextMatrix(ref ref x, ref ref 5, ref ref gRS.Fields("barcodePersonLnk_PrintQTY").Value);
				} else {
					gridEdit.set_TextMatrix(ref ref x, ref ref 5, ref ref lColumns);
					gridEdit.set_TextMatrix(ref ref x, ref ref 6, ref ref "New");

					sql = "SELECT Catalogue_Quantity FROM Catalogue WHERE Catalogue_StockItemID = " + gRS.Fields("StockItemID").Value + " AND Catalogue_Barcode = '" + Strings.Trim(gRS.Fields("Catalogue_Barcode").Value) + "'";
					rs = modRecordSet.getRS(ref ref sql);
					modRecordSet.cnnDB.Execute("UPDATE barcodePersonLnk SET barcodePersonLnk.barcodePersonLnk_PrintQTY = " + lColumns + " WHERE (((barcodePersonLnk.barcodePersonLnk_PersonID)=" + modRecordSet.gPersonID + ") AND ((barcodePersonLnk.barcodePersonLnk_StockItemID)=" + gRS.Fields("StockItemID").Value + ") AND ((barcodePersonLnk.barcodePersonLnk_Shrink)= " + rs.Fields("Catalogue_Quantity").Value + "));");
					rs.Close();
				}
				//sql = "SELECT Catalogue_Quantity FROM Catalogue WHERE Catalogue_StockItemID = " & gRS("StockItemID") & " AND Catalogue_Barcode = '" & Trim(gRS("Catalogue_Barcode")) & "'"
				//Set rs = getRS(sql)
				//cnnDB.Execute "UPDATE barcodePersonLnk SET barcodePersonLnk.barcodePersonLnk_PrintQTY = " & lColumns & " WHERE (((barcodePersonLnk.barcodePersonLnk_PersonID)=" & gPersonID & ") AND ((barcodePersonLnk.barcodePersonLnk_StockItemID)=" & gRS("StockItemID") & ") AND ((barcodePersonLnk.barcodePersonLnk_Shrink)= " & rs("Catalogue_Quantity") & "));"
				//rs.Close

				x = x + 1;
				if (x % 10) {
				} else {
					System.Windows.Forms.Application.DoEvents();
					if (gCancel)
						break; // TODO: might not be correct. Was : Exit Do
				}
				gRS.moveNext();
			}
			_with5.RowCount = x;
			_with5.Visible = true;

			return;
			errL:
			 // ERROR: Not supported in C#: ResumeStatement

		}

		private void loadData()
		{
			int x = 0;
			int y = 0;
			 // ERROR: Not supported in C#: OnErrorStatement

			x = 1;
			var _with6 = gridEdit;
			_with6.Visible = false;
			_with6.RowCount = gRS.RecordCount + 1;
			gCancel = false;
			while (!(gRS.EOF)) {
				gridEdit.set_TextMatrix(ref ref x, ref ref 0, ref ref gRS.Fields("Catalogue_Barcode").Value);
				gridEdit.set_TextMatrix(ref ref x, ref ref 1, ref ref gRS.Fields("StockItemID").Value);
				gridEdit.set_TextMatrix(ref ref x, ref ref 2, ref ref " " + gRS.Fields("Catalogue_Quantity").Value + "x" + gRS.Fields("StockItem_Name").Value);
				gridEdit.set_TextMatrix(ref ref x, ref ref 3, ref ref " " + gRS.Fields("Supplier_Name").Value);
				gridEdit.set_TextMatrix(ref ref x, ref ref 4, ref ref " " + gRS.Fields("PricingGroup_Name").Value);
				gridEdit.set_TextMatrix(ref ref x, ref ref 5, ref ref gRS.Fields("barcodePersonLnk_PrintQTY").Value);
				gridEdit.set_TextMatrix(ref ref x, ref ref 6, ref ref "NO");
				x = x + 1;
				if (x % 10) {
				} else {
					System.Windows.Forms.Application.DoEvents();
					if (gCancel)
						break; // TODO: might not be correct. Was : Exit Do
				}
				gRS.moveNext();
			}
			_with6.RowCount = x;
			_with6.Visible = true;

			changePrice();
			newPrice();
		}

		private string doSearch(ref string lField, ref string lText)
		{
			string lString = null;
			lString = Strings.Trim(lText);
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");
			lString = Strings.Replace(lString, "  ", " ");

			if (string.IsNullOrEmpty(Strings.Trim(lText))) {
				lString = "";
			} else {
				lString = "(" + lField + " LIKE '%" + Strings.Replace(lString, " ", "%' AND " + lField + " LIKE '%") + "%')";
				//lString = "(" & lField & " LIKE '%" & Replace(lString, " ", "%' AND StockItem_Name LIKE '%") & "%')"
			}
			return lString;
		}

		private void gridEdit_DblClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			var _with7 = gridEdit;
			if (_with7.Col != 5) {
				txtSearch[_with7.Col].Text = Strings.Trim(_with7.Text);
				doRS();
				txtSearch[_with7.Col].Focus();
			}

		}

		//Handles gridEdit.EnterCell
		private void gridEdit_EnterCell(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			if (this.Visible) {
				var _with8 = gridEdit;
				if (_with8.Col == 5) {
					txtEdit.SetBounds(sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with8.Left, true) + _with8.CellLeft, true), sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(_with8.Top, false) + _with8.CellTop, false), sizeConvertors.twipsToPixels(_with8.CellWidth, true), sizeConvertors.twipsToPixels(_with8.CellHeight, false));
					txtEdit.Text = _with8.Text;
					txtEdit.Tag = txtEdit.Text;
					txtEdit.Visible = true;
					txtEdit.Focus();
				} else {
					txtSearch[_with8.Col].Focus();
					txtEdit.Visible = false;
				}
			}
		}
		//Handles gridEdit.LeaveCell
		private void gridEdit_LeaveCell(System.Object eventSender, System.EventArgs eventArgs)
		{
			string sql = null;
			ADODB.Recordset rs = default(ADODB.Recordset);

			if (txtEdit.Visible) {
				txtEdit.Visible = false;

				sql = "SELECT Catalogue_Quantity FROM Catalogue WHERE Catalogue_StockItemID = " + Conversion.Val(gridEdit.get_TextMatrix(ref gridEdit.row, ref 1)) + " AND Catalogue_Barcode = '" + Strings.Trim(gridEdit.get_TextMatrix(ref gridEdit.row, ref 0)) + "'";
				rs = modRecordSet.getRS(ref sql);
				modRecordSet.cnnDB.Execute("UPDATE barcodePersonLnk SET barcodePersonLnk.barcodePersonLnk_PrintQTY = " + txtEdit.Text + " WHERE (((barcodePersonLnk.barcodePersonLnk_PersonID)=" + modRecordSet.gPersonID + ") AND ((barcodePersonLnk.barcodePersonLnk_StockItemID)=" + gridEdit.get_TextMatrix(ref gridEdit.row, ref 1) + ") AND ((barcodePersonLnk.barcodePersonLnk_Shrink)= " + rs.Fields("Catalogue_Quantity").Value + "));");
			}
		}

		private void txtEdit_TextChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			gridEdit.set_TextMatrix(ref gridEdit.row, ref 5, ref txtEdit.Text);
		}

		private void txtEdit_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtEdit.SelectionStart = 0;
			txtEdit.SelectionLength = 999;

		}

		private void txtEdit_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			switch (KeyCode) {
				case 40:
					if (gridEdit.row <= gridEdit.RowCount - 2) {
						gridEdit.row = gridEdit.row + 1;
					}
					break;
				case 38:
					if (gridEdit.row > 1) {
						gridEdit.row = gridEdit.row - 1;
					}
					break;
				case 27:
					break;
			}
		}

		private void txtEdit_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (Strings.Chr(KeyAscii)) {
				case Convert.ToString(0):
				case Convert.ToString(1):
				case Convert.ToString(2):
				case Convert.ToString(3):
				case Convert.ToString(4):
				case Convert.ToString(5):
				case Convert.ToString(6):
				case Convert.ToString(7):
				case Convert.ToString(8):
				case Convert.ToString(9):
				case Convert.ToString(0):
					break;
				default:
					KeyAscii = 0;
					break;
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		//Handles txtSearch.TextChanged
		private void txtSearch_TextChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			//Dim Index As Short = txtSearch.GetIndex(eventSender)
			//doRS
		}

		//Handles txtSearch.Enter
		private void txtSearch_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txt = new TextBox();
			txt = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txt, ref txtSearch);
			txtSearch[Index].BackColor = System.Drawing.Color.White;

		}

		//Handles txtSearch.KeyDown
		private void txtSearch_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short KeyCode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;
			TextBox txt = new TextBox();
			txt = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txt, ref txtSearch);
			switch (KeyCode) {
				case 38:
					gOrder = " ORDER BY " + txtSearch[Index].Tag + " DESC";
					KeyCode = 0;
					doRS();
					break;
				case 40:
					gOrder = " ORDER BY " + txtSearch[Index].Tag;
					KeyCode = 0;
					doRS();
					break;
				case 27:
					if (!string.IsNullOrEmpty(txtSearch[Index].Text)) {
						txtSearch[Index].Text = "";
						KeyCode = 0;
						doRS();
					}
					break;
			}
		}

		//Handles txtSearch.KeyPress
		private void txtSearch_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			//Dim Index As Short = txtSearch.GetIndex(eventSender)
			if (KeyAscii == 27) {
				KeyAscii = 0;
			} else if (KeyAscii == 13) {
				doRS();
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}

		//Handles txtSearch.Leave
		private void txtSearch_Leave(System.Object eventSender, System.EventArgs eventArgs)
		{
			TextBox txt = new TextBox();
			txt = (TextBox)eventSender;
			int Index = GetIndex.GetIndexer(ref txt, ref txtSearch);
			txtSearch[Index].BackColor = this.BackColor;
		}
	}
}
