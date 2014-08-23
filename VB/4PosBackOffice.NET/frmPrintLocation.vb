Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Friend Class frmPrintLocation
	Inherits System.Windows.Forms.Form
	Dim gID As Integer
	
	Private Sub loadLanguage()
		
		'Note: Form Caption has a spelling mistake!
		'frmPrintLocation = No Code     [Select a Printer for the Print Location]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmPrintLocation.Caption = rsLang("LanguageLayoutLnk_Description"): frmPrintLocation.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1 = No Code               [Print Location Name]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'cmdNext = No Code              [Save]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdNext.Caption = rsLang("LanguageLayoutLnk_Description"): cmdNext.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmPrintLocation.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Sub loadItem(ByRef lID As Integer)
		Dim rs As ADODB.Recordset
		Dim lPrn As Printer
		gID = lID
		If gID Then
			rs = getRS("SELECT * FROM PrintLocation WHERE PrintLocationID=" & lID)
			Me.txtName.Text = rs.Fields("PrintLocation_Name").Value
		End If
		rs = getRS("SELECT PrintLocationPrinterLnk.* From PrintLocationPrinterLnk WHERE (((PrintLocationPrinterLnk.PrintLocationPrinterLnk_PrintLocationID)=" & gID & "));")
        lstPrinter.Items.Clear()
        Dim m As Integer
		For	Each lPrn In Printers
			If InStr(1, lPrn.DeviceName, " ") Then
			Else
				rs.filter = "PrintLocationPrinterLnk_PrinterName = '" & lPrn.DeviceName & "'"
                m = lstPrinter.Items.Add((lPrn.DeviceName))
				If rs.RecordCount Then 
					'UPGRADE_ISSUE: ListBox property lstPrinter.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
                    lstPrinter.SetItemChecked(m, True)
				End If
			End If
		Next lPrn
		
		loadLanguage()
		ShowDialog()
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	
	Private Sub cmdNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNext.Click
		Dim lPrinter As Printer
		Dim lPrinterName As Boolean
		Dim rs As ADODB.Recordset
		Dim x As Short
		'    On Local Error Resume Next
		If gID Then
			cnnDB.Execute("UPDATE PrintLocation SET PrintLocation.PrintLocation_Name = '" & Replace(txtName.Text, "'", "''") & "' WHERE (((PrintLocation.PrintLocationID)=" & gID & "));")
		Else
			cnnDB.Execute("INSERT INTO PrintLocation ( PrintLocation_Name, PrintLocation_Disabled ) SELECT '" & Replace(txtName.Text, "'", "''") & "', False")
			rs = getRS("SELECT Max(PrintLocation.PrintLocationID) AS MaxOfPrintLocationID FROM PrintLocation;")
			gID = rs.Fields(0).Value
		End If
		cnnDB.Execute("DELETE PrintLocationPrinterLnk.* From PrintLocationPrinterLnk WHERE (((PrintLocationPrinterLnk.PrintLocationPrinterLnk_PrintLocationID)=" & gID & "));")
		For x = 0 To Me.lstPrinter.Items.Count - 1
			If lstPrinter.GetItemChecked(x) Then
                cnnDB.Execute("INSERT INTO PrintLocationPrinterLnk ( PrintLocationPrinterLnk_PrintLocationID, PrintLocationPrinterLnk_PrinterName ) SELECT " & gID & ", '" & Replace(GetItemString(lstPrinter, x), "'", "''") & "';")
			End If
		Next 
		
		
		
		
		Me.Close()
	End Sub
	
	Private Sub frmPrintLocation_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub txtName_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtName.Enter
        MyGotFocus(txtName)
	End Sub
End Class