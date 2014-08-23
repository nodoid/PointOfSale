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
	internal partial class frmUpdatePOS : System.Windows.Forms.Form
	{
		private void loadLanguage()
		{

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1169;
			//Update Point Of Sale|Checked
			if (modRecordSet.rsLang.RecordCount){this.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;this.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//cmdPrintNew = No Code      [Print &New]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdPrintNew.Caption = rsLang("LanguageLayoutLnk_Description"): cmdPrintNew.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdPrintAmend = No Code    [Print &Amend]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdPrintAmend.Caption = rsLang("LanguageLayoutLnk_Description"): cmdPrintAmend.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//Command1 = No Code         [Print &Barcodes]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then Command1.Caption = rsLang("LanguageLayoutLnk_Description"): Command1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdUpdate = No Code        [&Update POS]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdUpdate.Caption = rsLang("LanguageLayoutLnk_Description"): cmdUpdate.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdClose.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdClose.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//_lbl_1 = No Code           [Number of Stock Items that will be effected by the Update]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//lblLabels(34) = No Code    [Amend]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then lblLabels(34).Caption = rsLang("LanguageLayoutLnk_Description"): lblLabels(34).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1065;
			//New|Checked
			if (modRecordSet.rsLang.RecordCount){_lblLabels_33.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;_lblLabels_33.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//lblCG(0) = No Code/Dynamic/NA?
			//lblCG(1) = No code/Dynamic/NA?
			//lblCG(2) = No Code/Dynamic/NA?
			//lblCG(3) = No Code/Dynamic/NA?
			//lblCG(4) = No Code/Dynamic/NA?
			//lblCG(5) = No Code/Dynamic/NA?
			//lblCG(6) = No Code/Dynamic/NA?
			//lblCG(7) = No Code/Dynamic/NA?

			//_lbl_0 = No Code           [The current POS update the new POS instruction number will be]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//_lbl_2 = No Code           [After this update the number will be]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			//cmdScale = No Code         [Force &Scale Update]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then cmdScale.Caption = rsLang("LanguageLayoutLnk_Description"): cmdScale.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmUpdatePOS.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void setup()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "SELECT Channel_Code FROM Channel ORDER BY ChannelID");
			rs.MoveFirst();
			_lblCG_0.Text = _lblCG_1.Text == _lblCG_2.Text == _lblCG_3.Text == _lblCG_4.Text == _lblCG_5.Text == _lblCG_6.Text == _lblCG_7.Text == rs.Fields("Channel_Code").Value;

			rs = modRecordSet.getRS(ref "SELECT Company.Company_PosInstruction FROM Company;");
			lblInstruction.Text = rs.Fields("Company_PosInstruction").Value;
			lblInstructionNew.Text = Convert.ToString(Convert.ToDouble(lblInstruction.Text) + 1);

		}

		private void loadSummary()
		{
			ADODB.Recordset rs = default(ADODB.Recordset);
			string sql = null;
			sql = "SELECT theJoin.CatalogueChannelLnk_ChannelID, Count(theJoin.CatalogueChannelLnk_StockItemID) AS noUnits FROM [SELECT POSUpdate_PriceChangeSummary.CatalogueChannelLnk_ChannelID, POSUpdate_PriceChangeSummary.CatalogueChannelLnk_StockItemID From POSUpdate_PriceChangeSummary GROUP BY POSUpdate_PriceChangeSummary.CatalogueChannelLnk_ChannelID, POSUpdate_PriceChangeSummary.CatalogueChannelLnk_StockItemID]. AS theJoin GROUP BY theJoin.CatalogueChannelLnk_ChannelID;";
			rs = modRecordSet.getRS(ref sql);
			while (!(rs.EOF)) {
				_txtAmend_1.Text = rs.Fields("noUnits").Value;
				rs.moveNext();
			}

			sql = "SELECT theJoin.CatalogueChannelLnk_ChannelID, Count(theJoin.CatalogueChannelLnk_StockItemID) AS noUnits FROM [SELECT POSUpdate_PriceNewSummary.CatalogueChannelLnk_ChannelID, POSUpdate_PriceNewSummary.CatalogueChannelLnk_StockItemID From POSUpdate_PriceNewSummary GROUP BY POSUpdate_PriceNewSummary.CatalogueChannelLnk_ChannelID, POSUpdate_PriceNewSummary.CatalogueChannelLnk_StockItemID]. AS theJoin GROUP BY theJoin.CatalogueChannelLnk_ChannelID;";
			rs = modRecordSet.getRS(ref sql);
			while (!(rs.EOF)) {
				_txtNew_1.Text = rs.Fields("noUnits").Value;
				rs.moveNext();
			}
		}

		private void txtFloatNegative_Change(ref short Index)
		{

		}

		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//For Auto UpdatePOS on MonthEnd
			if (modApplication.blMEndUpdatePOS == true) {
				modApplication.blMEndUpdatePOS = false;
			}

			this.Close();
		}

		private void cmdPrintAmend_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string sql = null;

			ADODB.Recordset rs = default(ADODB.Recordset);
			bool ltype = false;
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = default(CrystalDecisions.CrystalReports.Engine.ReportDocument);
			Report.Load("cryPOSupdate.rpt");
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();

			Report.SetParameterValue("txtTitle", "Amended Catalogue Updates");
			Report.SetParameterValue("txtTitle1", _lbl_0.Text + " " + this.lblInstruction.Text + ". the new POS update Instruction will be " + this.lblInstructionNew.Text + ".");
			rs = modRecordSet.getRS(ref "SELECT * FROM Channel WHERE ChannelID <> 9 ORDER BY ChannelID");
			while (!(rs.EOF)) {
				switch (rs.Fields("ChannelID").Value) {
					case 1:
						Report.SetParameterValue("txtChannel1", rs.Fields("Channel_Code"));
						break;
					case 2:
						Report.SetParameterValue("txtChannel2", rs.Fields("Channel_Code"));
						break;
					case 3:
						Report.SetParameterValue("txtChannel3", rs.Fields("Channel_Code"));
						break;
					case 4:
						Report.SetParameterValue("txtChannel4", rs.Fields("Channel_Code"));
						break;
					case 5:
						Report.SetParameterValue("txtChannel5", rs.Fields("Channel_Code"));
						break;
					case 6:
						Report.SetParameterValue("txtChannel6", rs.Fields("Channel_Code"));
						break;
					case 7:
						Report.SetParameterValue("txtChannel7", rs.Fields("Channel_Code"));
						break;
					case 8:
						Report.SetParameterValue("txtChannel8", rs.Fields("Channel_Code"));
						break;
				}
				rs.moveNext();
			}

			rs.Close();
			sql = "TRANSFORM Sum(Query2.POSCatalogueChannelLnk_Price) AS SumOfPOSCatalogueChannelLnk_Price SELECT Query2.StockItemID, Query2.StockItem_Name, Query2.CatalogueChannelLnk_Quantity FROM (SELECT StockItem.StockItemID, StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price, POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price ";
			sql = sql + "FROM ((POSUpdate_PriceChangeSummary INNER JOIN StockItem ON POSUpdate_PriceChangeSummary.CatalogueChannelLnk_StockItemID = StockItem.StockItemID) INNER JOIN CatalogueChannelLnk ON (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = POSUpdate_PriceChangeSummary.CatalogueChannelLnk_Quantity) AND (POSUpdate_PriceChangeSummary.CatalogueChannelLnk_ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) AND (StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)) INNER JOIN POSCatalogueChannelLnk ON (CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID) ORDER BY StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) ";
			sql = sql + "Query2 GROUP BY Query2.StockItemID, Query2.StockItem_Name, Query2.CatalogueChannelLnk_Quantity PIVOT Query2.CatalogueChannelLnk_ChannelID;";

			rs = modRecordSet.getRS(ref sql);
			if (rs.BOF | rs.EOF) {
				//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				Interaction.MsgBox("No items in report", MsgBoxStyle.Exclamation, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				return;
			}
			//Report.Database.SetDataSource(rs, 3)
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();


		}

		private void cmdPrintNew_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string sql = null;
			CrystalDecisions.CrystalReports.Engine.ReportDocument Report = default(CrystalDecisions.CrystalReports.Engine.ReportDocument);
			ADODB.Recordset rs = default(ADODB.Recordset);
			bool ltype = false;
			Report.Load("cryPOSupdate.rpt");
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			rs = modRecordSet.getRS(ref "SELECT * FROM Company");
			//UPGRADE_WARNING: Couldn't resolve default property of object Report.txtCompanyName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"));
			rs.Close();

			Report.SetParameterValue("txtTitle", "New Catalogue Updates");
			Report.SetParameterValue("txtTitle1", _lbl_0.Text + " " + this.lblInstruction.Text + ". the new POS update Instruction will be " + this.lblInstructionNew.Text + ".");
			rs = modRecordSet.getRS(ref "SELECT * FROM Channel WHERE ChannelID <> 9 ORDER BY ChannelID");
			while (!(rs.EOF)) {
				switch (rs.Fields("ChannelID").Value) {
					case 1:
						Report.SetParameterValue("txtChannel1", rs.Fields("Channel_Code"));
						break;
					case 2:
						Report.SetParameterValue("txtChannel2", rs.Fields("Channel_Code"));
						break;
					case 3:
						Report.SetParameterValue("txtChannel3", rs.Fields("Channel_Code"));
						break;
					case 4:
						Report.SetParameterValue("txtChannel4", rs.Fields("Channel_Code"));
						break;
					case 5:
						Report.SetParameterValue("txtChannel5", rs.Fields("Channel_Code"));
						break;
					case 6:
						Report.SetParameterValue("txtChannel6", rs.Fields("Channel_Code"));
						break;
					case 7:
						Report.SetParameterValue("txtChannel7", rs.Fields("Channel_Code"));
						break;
					case 8:
						Report.SetParameterValue("txtChannel8", rs.Fields("Channel_Code"));
						break;
				}
				rs.moveNext();
			}

			rs.Close();
			sql = "TRANSFORM Sum(newItems.CatalogueChannelLnk_Price) AS SumOfCatalogueChannelLnk_Price SELECT newItems.StockItemID, newItems.StockItem_Name, newItems.CatalogueChannelLnk_Quantity FROM [SELECT StockItem.StockItemID, StockItem.StockItem_Name, POSUpdate_PriceNewSummary.CatalogueChannelLnk_ChannelID, POSUpdate_PriceNewSummary.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM CatalogueChannelLnk INNER JOIN (POSUpdate_PriceNewSummary INNER JOIN StockItem ON POSUpdate_PriceNewSummary.CatalogueChannelLnk_StockItemID = StockItem.StockItemID) ON (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = POSUpdate_PriceNewSummary.CatalogueChannelLnk_Quantity) AND (CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = POSUpdate_PriceNewSummary.CatalogueChannelLnk_ChannelID) AND (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = POSUpdate_PriceNewSummary.CatalogueChannelLnk_StockItemID) ";
			sql = sql + "ORDER BY StockItem.StockItem_Name, POSUpdate_PriceNewSummary.CatalogueChannelLnk_ChannelID, POSUpdate_PriceNewSummary.CatalogueChannelLnk_Quantity]. AS newItems GROUP BY newItems.StockItemID, newItems.StockItem_Name, newItems.CatalogueChannelLnk_Quantity PIVOT newItems.CatalogueChannelLnk_ChannelID;";

			rs = modRecordSet.getRS(ref sql);
			if (rs.BOF | rs.EOF) {
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				Interaction.MsgBox("No items in report", MsgBoxStyle.Exclamation, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				return;
			}
			//Report.Database.SetDataSource(rs, 3)
			//Report.VerifyOnEveryPrint = True
			My.MyProject.Forms.frmReportShow.Text = Report.ParameterFields("txtTitle").ToString;
			My.MyProject.Forms.frmReportShow.CRViewer1.ReportSource = Report;
			My.MyProject.Forms.frmReportShow.mReport = Report;
			My.MyProject.Forms.frmReportShow.sMode = "0";
			My.MyProject.Forms.frmReportShow.CRViewer1.Refresh();
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			My.MyProject.Forms.frmReportShow.ShowDialog();




		}

		private void cmdScale_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string mySQL = null;
			ADODB.Recordset rsScale = default(ADODB.Recordset);
			ADODB.Recordset rsData = default(ADODB.Recordset);
			string lString = "";
			string lFormat = null;
			string HeadingString1 = null;
			string HeadingString2 = null;
			string lWeighted = null;
			Scripting.FileSystemObject FSO = new Scripting.FileSystemObject();
			Scripting.TextStream lTextstreamC = default(Scripting.TextStream);
			 // ERROR: Not supported in C#: OnErrorStatement

			rsScale = modRecordSet.getRS(ref "SELECT Scale.* FROM Scale;");
			while (!(rsScale.EOF)) {
				if (My.MyProject.Forms.frmUpdatePOScriteria.frmType[0].Visible == true) {
					mySQL = "SELECT Right('0000'+[Catalogue_Barcode],4) AS code, Format([CatalogueChannelLnk_Price],'Fixed') AS price, StockItem.StockItem_Name, StockGroup.StockGroup_Name, StockItem.StockItem_NonWeighted FROM POSUpdate_PriceChangeSummary INNER JOIN ((StockItem INNER JOIN (CatalogueChannelLnk INNER JOIN Catalogue ON (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = Catalogue.Catalogue_StockItemID) AND (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = Catalogue.Catalogue_Quantity)) ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) ON POSUpdate_PriceChangeSummary.CatalogueChannelLnk_StockItemID = StockItem.StockItemID WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((Catalogue.Catalogue_Quantity)=1) AND ((StockItem.StockItem_Disabled)=False) AND ((StockItem.StockItem_VariablePrice)=True));";
				} else {
					mySQL = "SELECT Right('0000'+[Catalogue_Barcode],4) AS code, Format([CatalogueChannelLnk_Price],'Fixed') AS price, StockItem.StockItem_Name, StockGroup.StockGroup_Name, StockItem.StockItem_NonWeighted FROM (StockItem INNER JOIN (CatalogueChannelLnk INNER JOIN Catalogue ON (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = Catalogue.Catalogue_Quantity) AND (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = Catalogue.Catalogue_StockItemID)) ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((Catalogue.Catalogue_Quantity)=1) AND ((StockItem.StockItem_Disabled)=False) AND ((StockItem.StockItem_VariablePrice)=True));";
				}
				rsData = modRecordSet.getRS(ref mySQL);

				//        Select Case rsScale("Scale_format")
				//            Case 0
				//                rsData.MoveFirst
				//                Do Until rsData.EOF

				//                    HeadingString1 = Left(rsData("Stockitem_Name"), 16)
				//                    HeadingString2 = ""
				//                    If Len(rsData("Stockitem_Name")) > 16 Then
				//                        Do Until Right(HeadingString1, 1) = " "
				//                            HeadingString1 = Left(HeadingString1, Len(HeadingString1) - 1)
				//                        Loop
				//                        HeadingString2 = Mid(rsData("Stockitem_Name"), Len(HeadingString1) + 1)
				//                    End If
				//                    HeadingString1 = Left(HeadingString1 & String(16, " "), 16)
				//                    HeadingString2 = Left(HeadingString2 & String(16, " "), 16)
				//                    If rsData("StockItem_NonWeighted") Then lWeighted = "01" Else lWeighted = "00"
				//                    lstring = lstring & vbCrLf & "#" & rsData("code") & "$" & rsData("price") & "%#000%$" & lWeighted & "%(A" & HeadingString1 & "%)A" & HeadingString2 & "%[" & Left(rsData("StockGroup_Name") & String(15, " "), 15)
				//                    rsData.moveNext
				//                Loop
				//            Case 1

				rsData.MoveFirst();
				while (!(rsData.EOF)) {

					HeadingString1 = Strings.Left(rsData.Fields("Stockitem_Name").Value, 16);
					//16 was 22
					HeadingString2 = "";
					//16 was 22
					if (Strings.Len(rsData.Fields("Stockitem_Name").Value) > 16) {
						while (!(Strings.Right(HeadingString1, 1) == " " | string.IsNullOrEmpty(HeadingString1))) {
							HeadingString1 = Strings.Left(HeadingString1, Strings.Len(HeadingString1) - 1);
						}
						HeadingString2 = Strings.Mid(rsData.Fields("Stockitem_Name").Value, Strings.Len(HeadingString1) + 1);
					}
					HeadingString1 = Strings.Left(HeadingString1 + new string(" ", 16), 16);
					//16 was 22
					HeadingString2 = Strings.Left(HeadingString2 + new string(" ", 22), 22);
					//16 was 22
					if (rsData.Fields("StockItem_NonWeighted").Value)
						lWeighted = "01";
					else
						lWeighted = "00";
					//                    lstring = lstring & vbCrLf & "%*0 #" & rsData("code") & " $" & Right("00000" & Replace(rsData("price"), ".", ""), 5) & " %#000 %$" & lWeighted & "%&" & rsScale("ScaleID") & rsData("code") & " %(A" & HeadingString1 & " %)A" & HeadingString2 & " %[" & Left(rsData("StockGroup_Name") & String(15, " "), 15) & " %]" & String(15, " ") & " %~"
					//If lString = "" Then
					//    lString = "%*0 #" & rsData("code") & " $" & Right("00000" & FormatNumber(rsData("price"), 2), 6) & " %#000 %&       %(A" & HeadingString1 & " %)A" & HeadingString2 & " %$" & lWeighted
					//Else
					lString = lString + Constants.vbCrLf + "%*0 #" + rsData.Fields("code").Value + " $" + Strings.Right("00000" + Strings.FormatNumber(rsData.Fields("price").Value, 2), 6) + " %#000 %&       %(A" + HeadingString1 + " %)A" + HeadingString2 + " %$" + lWeighted;
					//End If
					rsData.moveNext();
				}
				//        End Select
				//FOR NEW SCALE ITEMS
				if (My.MyProject.Forms.frmUpdatePOScriteria.frmType[0].Visible == true) {
					//UPGRADE_WARNING: Couldn't resolve default property of object mySQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					mySQL = "SELECT Right('0000'+[Catalogue_Barcode],4) AS code, Format([CatalogueChannelLnk_Price],'Fixed') AS price, StockItem.StockItem_Name, StockGroup.StockGroup_Name, StockItem.StockItem_NonWeighted FROM POSUpdate_PriceNewSummary INNER JOIN ((StockItem INNER JOIN (CatalogueChannelLnk INNER JOIN Catalogue ON (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = Catalogue.Catalogue_StockItemID) AND (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = Catalogue.Catalogue_Quantity)) ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) ON POSUpdate_PriceNewSummary.CatalogueChannelLnk_StockItemID = StockItem.StockItemID WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((Catalogue.Catalogue_Quantity)=1) AND ((StockItem.StockItem_Disabled)=False) AND ((StockItem.StockItem_VariablePrice)=True));";
					rsData = modRecordSet.getRS(ref mySQL);
					rsData.MoveFirst();
					while (!(rsData.EOF)) {

						HeadingString1 = Strings.Left(rsData.Fields("Stockitem_Name").Value, 16);
						//16 was 22
						HeadingString2 = "";
						//16 was 22
						if (Strings.Len(rsData.Fields("Stockitem_Name").Value) > 16) {
							while (!(Strings.Right(HeadingString1, 1) == " " | string.IsNullOrEmpty(HeadingString1))) {
								HeadingString1 = Strings.Left(HeadingString1, Strings.Len(HeadingString1) - 1);
							}
							HeadingString2 = Strings.Mid(rsData.Fields("Stockitem_Name").Value, Strings.Len(HeadingString1) + 1);
						}
						HeadingString1 = Strings.Left(HeadingString1 + new string(" ", 16), 16);
						//16 was 22
						HeadingString2 = Strings.Left(HeadingString2 + new string(" ", 22), 22);
						//16 was 22
						if (rsData.Fields("StockItem_NonWeighted").Value)
							lWeighted = "01";
						else
							lWeighted = "00";
						lString = lString + Constants.vbCrLf + "%*0 #" + rsData.Fields("code").Value + " $" + Strings.Right("00000" + Strings.FormatNumber(rsData.Fields("price").Value, 2), 6) + " %#000 %&       %(A" + HeadingString1 + " %)A" + HeadingString2 + " %$" + lWeighted;
						rsData.moveNext();
					}
				}

				if (FSO.FileExists(rsScale.Fields("Scale_Path").Value))
					FSO.DeleteFile(rsScale.Fields("Scale_Path").Value);
				if (Strings.Len(lString)) {


					lTextstreamC = FSO.CreateTextFile(rsScale.Fields("Scale_Path").Value, true);
					Debug.Print(Strings.Trim(Strings.Left(lString, Strings.Len(lString) - 1)));
					lTextstreamC.Write(Strings.Mid(lString, 3));
					lTextstreamC.Close();

					//Open rsScale("Scale_Path") For Output As #7
					//Print #7, mID(lString, 3, Len(lString) - 5)
					//Close #7

					if (FSO.FileExists(modRecordSet.serverPath + "teraoka.bat"))
						Interaction.Shell(modRecordSet.serverPath + "teraoka.bat", AppWinStyle.MinimizedNoFocus);
				}
				rsScale.moveNext();
			}
			modRecordSet.cnnDB.Execute("UPDATE Scale SET Scale.Scale_Update = False;");

		}

		private void cmdUpdate_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "SELECT * FROM Scale");
			if (rs.RecordCount) {
				if (rs.Fields("Scale_Update").Value) {
					cmdScale_Click(cmdScale, new System.EventArgs());
				}
			}

			modRecordSet.cnnDB.Execute("INSERT INTO StockItemTalker ( StockItemID ) SELECT DISTINCT POSUpdate_PriceChangeSummary.CatalogueChannelLnk_StockItemID FROM StockItemTalker RIGHT JOIN POSUpdate_PriceChangeSummary ON StockItemTalker.StockItemID = POSUpdate_PriceChangeSummary.CatalogueChannelLnk_StockItemID WHERE (((StockItemTalker.StockItemID) Is Null) AND ((POSUpdate_PriceChangeSummary.CatalogueChannelLnk_ChannelID)=1));");
			modRecordSet.cnnDB.Execute("INSERT INTO POSCatalogue ( POSCatalogue_StockItemID, POSCatalogue_Quantity, POSCatalogue_Barcode, POSCatalogue_Deposit, POSCatalogue_Content ) SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, Catalogue.Catalogue_Barcode, Catalogue.Catalogue_Deposit, Catalogue.Catalogue_Content FROM Catalogue LEFT JOIN POSCatalogue ON (Catalogue.Catalogue_StockItemID = POSCatalogue.POSCatalogue_StockItemID) AND (Catalogue.Catalogue_Quantity = POSCatalogue.POSCatalogue_Quantity) WHERE (((POSCatalogue.POSCatalogue_StockItemID) Is Null) AND ((Catalogue.Catalogue_Disabled)=0));");
			modRecordSet.cnnDB.Execute("INSERT INTO POSCatalogueChannelLnk ( POSCatalogueChannelLnk_StockItemID, POSCatalogueChannelLnk_ChannelID, POSCatalogueChannelLnk_Quantity, POSCatalogueChannelLnk_Price ) SELECT CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price FROM CatalogueChannelLnk LEFT JOIN POSCatalogueChannelLnk ON (CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID) AND (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity) AND (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID) WHERE (((POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID) Is Null));");
			modRecordSet.cnnDB.Execute("UPDATE POSCatalogueChannelLnk INNER JOIN (CatalogueChannelLnk INNER JOIN systemStockItemPricing ON CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = systemStockItemPricing.systemStockItemPricing) ON (POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) AND (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) SET POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price = [CatalogueChannelLnk]![CatalogueChannelLnk_Price];");
			modRecordSet.cnnDB.Execute("DELETE tempStockItem.* FROM systemStockItemPricing INNER JOIN tempStockItem ON systemStockItemPricing.systemStockItemPricing = tempStockItem.tempStockItemID;");
			modRecordSet.cnnDB.Execute("UPDATE Company SET Company.Company_PosUpdate = 1;");


			//For Auto UpdatePOS on MonthEnd
			if (modApplication.blMEndUpdatePOS == true) {
				modApplication.blMEndUpdatePOS = false;
			}

			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Close();
		}

		private void Command1_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			//*Removes the error "Object was unloaded" on Security Access Barcoodes Submenu
			modApplication.grvPrin = false;
			My.MyProject.Forms.frmBarcode.ShowDialog();
		}

		private void frmUpdatePOS_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			loadLanguage();

			setup();
			loadSummary();

			if (modApplication.blMEndUpdatePOS == true) {
				tmrMEndUpdatePOS.Enabled = true;
			}
		}

		private void frmUpdatePOS_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			switch (KeyAscii) {
				case System.Windows.Forms.Keys.Escape:
					this.Close();
					KeyAscii = 0;
					break;
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}
		public void AutomaticPOSUpdate()
		{
			setup();
			loadSummary();

			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ADODB.Recordset rs = default(ADODB.Recordset);
			rs = modRecordSet.getRS(ref "SELECT * FROM Scale");
			if (rs.RecordCount) {
				if (rs.Fields("Scale_Update").Value) {
					cmdScale_Click(cmdScale, new System.EventArgs());
				}
			}
			modRecordSet.cnnDB.Execute("INSERT INTO StockItemTalker ( StockItemID ) SELECT DISTINCT POSUpdate_PriceChangeSummary.CatalogueChannelLnk_StockItemID FROM StockItemTalker RIGHT JOIN POSUpdate_PriceChangeSummary ON StockItemTalker.StockItemID = POSUpdate_PriceChangeSummary.CatalogueChannelLnk_StockItemID WHERE (((StockItemTalker.StockItemID) Is Null) AND ((POSUpdate_PriceChangeSummary.CatalogueChannelLnk_ChannelID)=1));");
			modRecordSet.cnnDB.Execute("INSERT INTO POSCatalogue ( POSCatalogue_StockItemID, POSCatalogue_Quantity, POSCatalogue_Barcode, POSCatalogue_Deposit, POSCatalogue_Content ) SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, Catalogue.Catalogue_Barcode, Catalogue.Catalogue_Deposit, Catalogue.Catalogue_Content FROM Catalogue LEFT JOIN POSCatalogue ON (Catalogue.Catalogue_StockItemID = POSCatalogue.POSCatalogue_StockItemID) AND (Catalogue.Catalogue_Quantity = POSCatalogue.POSCatalogue_Quantity) WHERE (((POSCatalogue.POSCatalogue_StockItemID) Is Null) AND ((Catalogue.Catalogue_Disabled)=0));");
			modRecordSet.cnnDB.Execute("INSERT INTO POSCatalogueChannelLnk ( POSCatalogueChannelLnk_StockItemID, POSCatalogueChannelLnk_ChannelID, POSCatalogueChannelLnk_Quantity, POSCatalogueChannelLnk_Price ) SELECT CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price FROM CatalogueChannelLnk LEFT JOIN POSCatalogueChannelLnk ON (CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID) AND (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity) AND (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID) WHERE (((POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID) Is Null));");
			modRecordSet.cnnDB.Execute("UPDATE POSCatalogueChannelLnk INNER JOIN (CatalogueChannelLnk INNER JOIN systemStockItemPricing ON CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = systemStockItemPricing.systemStockItemPricing) ON (POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) AND (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) SET POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price = [CatalogueChannelLnk]![CatalogueChannelLnk_Price];");
			modRecordSet.cnnDB.Execute("DELETE tempStockItem.* FROM systemStockItemPricing INNER JOIN tempStockItem ON systemStockItemPricing.systemStockItemPricing = tempStockItem.tempStockItemID;");
			modRecordSet.cnnDB.Execute("UPDATE Company SET Company.Company_PosUpdate = 1;");

			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Close();

		}

		private void tmrMEndUpdatePOS_Tick(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (modApplication.blMEndUpdatePOS == true) {
				tmrMEndUpdatePOS.Enabled = false;
				cmdUpdate_Click(cmdUpdate, new System.EventArgs());
			}
		}
	}
}
