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
	internal partial class frmReportShow : System.Windows.Forms.Form
	{
		public CrystalDecisions.CrystalReports.Engine.ReportDocument mReport;
		public string sMode;

		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement


			//If sMode = "1" Then
			//    'old code to print report
			//    CRViewer1.PrintReport
			//    DoEvents
			//    cmdPrint.SetFocus
			//    Exit Sub
			//    'old code to print report
			//Else
			System.Windows.Forms.Application.DoEvents();
			//Dim cOrientation As CRAXDRT.CRPaperOrientation
			//Dim cOriendation As CrystalDecisions.CrystalReports.Engine.PrintOptions
			//Dim cSize As CRAXDRT.CRPaperSize
			//cOrientation = mReport.PaperOrientation
			//cSize = mReport.PaperSize
			//Printer.DeviceName
			//UPGRADE_WARNING: CommonDialog variable was not upgraded Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="671167DC-EA81-475D-B690-7A40C7BF4A23"'
			var _with1 = cdbPrinterPrint;
			//CancelError = True 'Abort print when user clicks on cancels
			//.PrinterDefault = True 'Use user selection to change printer default.
			_with1.PrinterSettings.MinimumPage = 1;
			// Guess!
			CRViewer1.ShowLastPage();
			System.Windows.Forms.Application.DoEvents();
			_with1.PrinterSettings.MaximumPage = CRViewer1.GetCurrentPageNumber;
			//1
			System.Windows.Forms.Application.DoEvents();
			_with1.PrinterSettings.ToPage = CRViewer1.GetCurrentPageNumber;
			//1
			CRViewer1.ShowFirstPage();
			_with1.PrinterSettings.FromPage = CRViewer1.GetCurrentPageNumber;
			//1
			System.Windows.Forms.Application.DoEvents();
			_with1.ShowDialog();

			System.Windows.Forms.Application.DoEvents();
			//Report.VerifyOnEveryPrint = True
			//mReport.selectPrinter Printer.DriverName, Printer.DeviceName, Printer.Port
			mReport.PrintToPrinter(false, false, cdbPrinterPrint.PrinterSettings.FromPage, cdbPrinterPrint.PrinterSettings.ToPage);
			//mReport.PrintOut(False, cdbPrinterPrint.PrinterSettings.Copies, , cdbPrinterPrint.PrinterSettings.FromPage, cdbPrinterPrint.PrinterSettings.ToPage)

			//With mReport
			//    .selectPrinter Printer.DriverName, Printer.DeviceName, Printer.Port
			//    '.PaperOrientation = cOrientation
			//    '.PaperSize = cSize
			//        'If cdbPrinter.Flags = cdlPDAllPages Then
			//        '    .PrintOut False, cdbPrinter.Copies ', False, cdbPrinter.FromPage
			//        'ElseIf cdbPrinter.Flags = cdlPDPageNums Then
			//        '    .PrintOut False, cdbPrinter.Copies, False, cdbPrinter.FromPage, cdbPrinter.ToPage
			//        'Else
			//            .PrintOut False, cdbPrinter.Copies, , cdbPrinter.FromPage, cdbPrinter.ToPage
			//        'End If
			//End With
			System.Windows.Forms.Application.DoEvents();
			cmdPrint.Focus();
			//End If


			return;
			printError:
			if (Err().Number == MsgBoxResult.Cancel) {
				return;
			} else if (Err().Number == 32755) {
				return;
			} else if (Strings.InStr(1, Err().Description, "Cancel")) {
				return;
			} else {
				//MsgBox Err.Number & Err.Description
				 // ERROR: Not supported in C#: ResumeStatement

			}
			//If cdbPrinter.CancelError Then Exit Sub
		}

		//Handles CRViewer1.DownloadFinished
		private void CRViewer1_DownloadFinished(System.Object eventSender, System.EventArgs eventArgs)
		{
			tmrZoom.Enabled = true;
		}


		private void frmReportShow_KeyPress(System.Object eventSender, System.Windows.Forms.KeyPressEventArgs eventArgs)
		{
			short KeyAscii = Strings.Asc(eventArgs.KeyChar);
			if (KeyAscii == 27) {
				KeyAscii = 0;
				this.Close();
			}
			eventArgs.KeyChar = Strings.Chr(KeyAscii);
			if (KeyAscii == 0) {
				eventArgs.Handled = true;
			}
		}


		private void frmReportShow_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			CRViewer1.Top = picButtons.Height;
			CRViewer1.Left = 0;
			CRViewer1.Height = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(ClientRectangle.Height, false) - sizeConvertors.pixelToTwips(CRViewer1.Top, false), false);
			CRViewer1.Width = ClientRectangle.Width;

		}

		private void picButtons_Resize(System.Object eventSender, System.EventArgs eventArgs)
		{
			cmdClose.Left = sizeConvertors.twipsToPixels(sizeConvertors.pixelToTwips(picButtons.Width, true) - sizeConvertors.pixelToTwips(cmdClose.Width, true) - 90, true);
		}

		private void tmrZoom_Tick(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement

			tmrZoom.Enabled = false;
			CRViewer1.Zoom(120);
		}
	}
}
