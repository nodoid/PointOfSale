Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmMWSelect
	Inherits System.Windows.Forms.Form
	Dim lMWNo As Integer
	Dim rsMWare As ADODB.Recordset
	
	Private Sub loadLanguage()
		
		'frmMWSelect = No Code  [Warehouse Selection]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmMWSelect.Caption = rsLang("LanguageLayoutLnk_Description"): frmMWSelect.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1005 'Next|
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmMWSelect.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Function getMWNo() As Integer
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		rsMWare = getRS("SELECT WarehouseID, Warehouse_Name From Warehouse WHERE (WarehouseID > 1) ORDER BY WarehouseID")
		If rsMWare.RecordCount = 1 Then
			getMWNo = rsMWare.Fields("WarehouseID").Value
			GoTo jumpOut
		End If
		
		cmbMWNo.Items.Clear()
		Do Until rsMWare.EOF
            cmbMWNo.Items.Add(New LBI(rsMWare.Fields("Warehouse_Name").Value, rsMWare.Fields("WarehouseID").Value))
			rsMWare.moveNext()
		Loop 
		cmbMWNo.SelectedIndex = 0
        txtWNO.Text = CStr(cmbMWNo.SelectedIndex)
		
		loadLanguage()
		Me.ShowDialog()
		getMWNo = lMWNo
		
jumpOut: 
		
	End Function
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		lMWNo = CInt(txtWNO.Text)
        lMWNo = CInt(cmbMWNo.SelectedIndex)
		Me.Close()
	End Sub
End Class