Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Friend Class frmPrinter
	Inherits System.Windows.Forms.Form
	Dim gSelect As Boolean
    Dim optType As New List(Of RadioButton)
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1810 'Select a Printer|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1811 'NOTE: Please select your printer type before clicking "next"|Checked
		If rsLang.RecordCount Then Frame1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Frame1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1812 'A4 Printer|Checked
        If rsLang.RecordCount Then _optType_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _optType_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1813 'Argox Printer|Checked
        If rsLang.RecordCount Then _optType_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _optType_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1814 'Other barcode printer|
        If rsLang.RecordCount Then _optType_3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _optType_3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1005 'Next|Checked
		If rsLang.RecordCount Then cmdnext.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdnext.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmPrinter.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
    Public Function selectPrinter() As String
        Dim TheSelectedPrinterStr As String
        Dim Printer As New Printer
        Dim lPrn As Printer
        Dim rs As ADODB.Recordset
        Dim lPrnType As Printer

        On Error GoTo selectPrinterErr
        rs = getRS("SELECT * FROM PrinterOftenUsed")

        lstPrinter.Items.Clear()
        For Each lPrn In Printers
            lstPrinter.Items.Add((lPrn.DeviceName))
        Next lPrn

        If lstPrinter.Items.Count Then
            If rs.RecordCount > 0 Then
                lstPrinter.SelectedIndex = rs.Fields("PrinterIndex").Value

                If rs.Fields("PrinterType").Value = 0 Then
                    lPrnType = Printers(lstPrinter.SelectedIndex)
                    If InStr(LCase(lPrnType.DeviceName), "label") Then
                        optType(2).Checked = True
                    ElseIf Printer.Width <= 9000 Then
                        optType(3).Checked = True
                    Else
                        optType(1).Checked = True
                    End If
                ElseIf rs.Fields("PrinterType").Value > 0 Then
                    optType(rs.Fields("PrinterType").Value).Checked = True
                End If
            Else
                optType(1).Checked = True
            End If

            loadLanguage()
            ShowDialog()
        Else
            selectPrinter = ""
            optType(1).Checked = True
        End If

        If gSelect Then
           selectPrinter = Printer.DeviceName
            TheSelectedPrinterStr = Printer.DeviceName
            MyNewPrLabel = selectPrinter
        Else
           selectPrinter = ""
        End If

selectPrinterErr:
        Resume Next
    End Function
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	Private Sub cmdNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNext.Click
		Dim Printer As New Printer
		Dim lPrinter As Printer
		Dim lPrinterName As Boolean
		'added by jonas
		Dim rs As ADODB.Recordset
		Dim rst As ADODB.Recordset
		Dim prnType As Short
		
		prnType = 0
		If optType(1).Checked = True Then prnType = 1
		If optType(2).Checked = True Then prnType = 2
		If optType(3).Checked = True Then prnType = 3
		
		rs = New ADODB.Recordset
		rst = getRS("SELECT * FROM PrinterOftenUsed")
		If rst.RecordCount < 1 Then
			rs = getRS("INSERT INTO PrinterOftenUsed(PrinterIndex,LabelIndex,ShelfIndex,PrinterType)VALUES(" & lstPrinter.SelectedIndex & "," & -1 & "," & -1 & "," & prnType & ")")
		Else
			rs = getRS("SELECT * FROM PrinterOftenUsed")
			rs = getRS("UPDATE PrinterOftenUsed SET PrinterIndex=" & lstPrinter.SelectedIndex & ", PrinterType=" & prnType & " WHERE PrinterIndex=" & rs.Fields("PrinterIndex").Value & "")
		End If
		'added by jonas
		If lstPrinter.SelectedIndex <> -1 Then
			If optType(1).Checked = False And optType(2).Checked = False And optType(3).Checked = False Then
				MsgBox("You are required to select Printer Type in order to proceed next. [A4 will be used as default].", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information, "Printing")
				Exit Sub
			Else
				Printer = Printers(lstPrinter.SelectedIndex)
				gSelect = True
			End If
			
		Else
			MsgBox("You are required to select Printer in order to proceed NEXT. Or No printer installed.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information, "Printing")
			Exit Sub
		End If
		Me.Close()
	End Sub
	Private Sub frmPrinter_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 27 Then
			KeyAscii = 0
			cmdExit_Click(cmdExit, New System.EventArgs())
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	Private Sub lstPrinter_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstPrinter.DoubleClick
		cmdNext_Click(cmdNext, New System.EventArgs())
	End Sub
	
	Private Sub lstPrinter_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles lstPrinter.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Then
			cmdNext_Click(cmdNext, New System.EventArgs())
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub

    Private Sub frmPrinter_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        optType.AddRange(New RadioButton() {_optType_0, _optType_1, _optType_2, _optType_3})
    End Sub
End Class