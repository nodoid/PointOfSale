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
	internal partial class frmExportUt : System.Windows.Forms.Form
	{
		private DatabaseExport withEventsField_ex;
		private DatabaseExport ex {
			get { return withEventsField_ex; }
			set {
				if (withEventsField_ex != null) {
					withEventsField_ex.ExportStarted -= ex_ExportStarted;
					withEventsField_ex.ExportComplete -= ex_ExportComplete;
				}
				withEventsField_ex = value;
				if (withEventsField_ex != null) {
					withEventsField_ex.ExportStarted += ex_ExportStarted;
					withEventsField_ex.ExportComplete += ex_ExportComplete;
				}
			}
		}

		private void loadLanguage()
		{

			//NOTE: Form Caption has a spelling Mistake!
			//frmExportUt = No Code      [Export Utilities]
			//rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
			//If rsLang.RecordCount Then frmExportUt.Caption = rsLang("LanguageLayoutLnk_Description"): frmExportUt.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 1004;
			//Exit|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExit.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExit.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2424;
			//File Path|Checked
			if (modRecordSet.rsLang.RecordCount){Label1.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;Label1.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			//NOTE: DB Entry 2483 missing "!"
			modRecordSet.rsLang.filter = "LanguageLayoutLnk_LanguageID=" + 2483;
			//Export Now|Checked
			if (modRecordSet.rsLang.RecordCount){cmdExportNow.Text = modRecordSet.rsLang.Fields("LanguageLayoutLnk_Description").Value;cmdExportNow.RightToLeft = modRecordSet.rsLang.Fields("LanguageLayoutLnk_RightTL").Value;}

			modRecordSet.rsHelp.filter = "Help_Section=0 AND Help_Form='" + this.Name + "'";
			//UPGRADE_ISSUE: Form property frmExportUt.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			if (modRecordSet.rsHelp.RecordCount)
				this.ToolTip1 = modRecordSet.rsHelp.Fields("Help_ContextID").Value;

		}

		private void cmdBrowse_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string strSelect = null;

			ex = new DatabaseExport();

			strSelect = "CSV";

			switch (strSelect) {

				case "CSV":

					if (ex.ShowSave(cmdlgSave, DatabaseExport.DatabaseExportEnum.CSV)) {
						Text1.Text = ex.FilePath;
					}
					break;
			}

		}
		private bool isClean()
		{
			bool functionReturnValue = false;

			if (string.IsNullOrEmpty(Text1.Text)) {
				Interaction.MsgBox("Please enter file name and the destination!" + Constants.vbCrLf + "FOR CSV", MsgBoxStyle.Exclamation, "Exporter Utitities");
				functionReturnValue = true;
			} else {
				functionReturnValue = false;
			}
			return functionReturnValue;

		}

		private void cmdExit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}
		private void cmdExportNow_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
			//Set ex = New DatabaseExport

			if (string.IsNullOrEmpty(Text1.Text)) {
				Interaction.MsgBox("Please Enter file destination", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, _4PosBackOffice.NET.My.MyProject.Application.Info.Title);
				return;
			} else {
				if (fso.FileExists(Text1.Text) == true) {
					if (Interaction.MsgBox("File Exists, Do you wan to overwrite it?", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Question + MsgBoxStyle.YesNo, _4PosBackOffice.NET.My.MyProject.Application.Info.Title) == MsgBoxResult.Yes) {
						ex.FilePath = Text1.Text;
						if (isClean() == false)
							ex.ExportToCSV();
					} else {
						return;
					}
					this.Close();
				} else {
					if (isClean() == false)
						ex.ExportToCSV();
					this.Close();
				}
			}

		}
		private void ex_ExportStarted(DatabaseExport.DatabaseExportEnum ExportingFormat)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			Debug.Print((ExportingFormat == DatabaseExport.DatabaseExportEnum.CSV ? "CSV" : (ExportingFormat == DatabaseExport.DatabaseExportEnum.HTML ? "HTML" : "Excel")));
		}
		private void ex_ExportComplete(bool Success, DatabaseExport.DatabaseExportEnum ExportingFormat)
		{
			if (Success == true) {
				Interaction.MsgBox("Export Completed!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information + MsgBoxStyle.ApplicationModal, "Export Utilies");

			} else {
				Interaction.MsgBox("Export Completed!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information + MsgBoxStyle.ApplicationModal, "Export Utilies");
			}
			this.Close();
		}

//Sub loaditem()

//ex.ExportToCSV

//End Sub
		private void frmExportUt_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			loadLanguage();
		}
	}
}
