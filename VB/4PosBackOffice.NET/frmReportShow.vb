Option Strict Off
Option Explicit On
Friend Class frmReportShow
	Inherits System.Windows.Forms.Form
    Public mReport As CrystalDecisions.CrystalReports.Engine.ReportDocument
	Public sMode As String
	
    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Me.Close()
    End Sub
	
    Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        On Error GoTo printError

        'If sMode = "1" Then
        '    'old code to print report
        '    CRViewer1.PrintReport
        '    DoEvents
        '    cmdPrint.SetFocus
        '    Exit Sub
        '    'old code to print report
        'Else
        System.Windows.Forms.Application.DoEvents()
        'Dim cOrientation As CRAXDRT.CRPaperOrientation
        'Dim cOriendation As CrystalDecisions.CrystalReports.Engine.PrintOptions
        'Dim cSize As CRAXDRT.CRPaperSize
        'cOrientation = mReport.PaperOrientation
        'cSize = mReport.PaperSize
        'Printer.DeviceName
        'UPGRADE_WARNING: CommonDialog variable was not upgraded Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="671167DC-EA81-475D-B690-7A40C7BF4A23"'
        With cdbPrinterPrint
            'CancelError = True 'Abort print when user clicks on cancels
            '.PrinterDefault = True 'Use user selection to change printer default.
            .PrinterSettings.MinimumPage = 1 ' Guess!
            CRViewer1.ShowLastPage()
            System.Windows.Forms.Application.DoEvents()
            .PrinterSettings.MaximumPage = CRViewer1.GetCurrentPageNumber '1
            System.Windows.Forms.Application.DoEvents()
            .PrinterSettings.ToPage = CRViewer1.GetCurrentPageNumber '1
            CRViewer1.ShowFirstPage()
            .PrinterSettings.FromPage = CRViewer1.GetCurrentPageNumber '1
            System.Windows.Forms.Application.DoEvents()
            .ShowDialog()
        End With

        System.Windows.Forms.Application.DoEvents()
        'Report.VerifyOnEveryPrint = True
        'mReport.selectPrinter Printer.DriverName, Printer.DeviceName, Printer.Port
        mReport.PrintToPrinter(False, False, cdbPrinterPrint.PrinterSettings.FromPage, cdbPrinterPrint.PrinterSettings.ToPage)
        'mReport.PrintOut(False, cdbPrinterPrint.PrinterSettings.Copies, , cdbPrinterPrint.PrinterSettings.FromPage, cdbPrinterPrint.PrinterSettings.ToPage)

        'With mReport
        '    .selectPrinter Printer.DriverName, Printer.DeviceName, Printer.Port
        '    '.PaperOrientation = cOrientation
        '    '.PaperSize = cSize
        '        'If cdbPrinter.Flags = cdlPDAllPages Then
        '        '    .PrintOut False, cdbPrinter.Copies ', False, cdbPrinter.FromPage
        '        'ElseIf cdbPrinter.Flags = cdlPDPageNums Then
        '        '    .PrintOut False, cdbPrinter.Copies, False, cdbPrinter.FromPage, cdbPrinter.ToPage
        '        'Else
        '            .PrintOut False, cdbPrinter.Copies, , cdbPrinter.FromPage, cdbPrinter.ToPage
        '        'End If
        'End With
        System.Windows.Forms.Application.DoEvents()
        cmdPrint.Focus()
        'End If


        Exit Sub
printError:
        If Err.Number = MsgBoxResult.Cancel Then
            Exit Sub
        ElseIf Err.Number = 32755 Then
            Exit Sub
        ElseIf InStr(1, Err.Description, "Cancel") Then
            Exit Sub
        Else
            'MsgBox Err.Number & Err.Description
            Resume Next
        End If
        'If cdbPrinter.CancelError Then Exit Sub
    End Sub
	
    Private Sub CRViewer1_DownloadFinished(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles CRViewer1.DownloadFinished
        tmrZoom.Enabled = True
    End Sub
	
	
	Private Sub frmReportShow_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 27 Then
			KeyAscii = 0
			Me.Close()
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	
	Private Sub frmReportShow_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		CRViewer1.Top = picButtons.Height
		CRViewer1.Left = 0
        CRViewer1.Height = twipsToPixels(pixelToTwips(ClientRectangle.Height, False) - _
                                        pixelToTwips(CRViewer1.Top, False), False)
		CRViewer1.Width = ClientRectangle.Width
		
	End Sub
	
	Private Sub picButtons_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles picButtons.Resize
        cmdClose.Left = twipsToPixels(pixelToTwips(picButtons.Width, True) - _
                                     pixelToTwips(cmdClose.Width, True) - 90, True)
	End Sub
	
	Private Sub tmrZoom_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrZoom.Tick
		On Error Resume Next
		tmrZoom.Enabled = False
		CRViewer1.Zoom(120)
	End Sub
End Class