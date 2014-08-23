Option Strict Off
Option Explicit On
Friend Class frmSupplierDeposits
	Inherits System.Windows.Forms.Form
	Dim loading As Boolean
	Dim gID As Integer
	
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1469 'Supplier Deposits|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lblSupplier = No Code/Dynamic!
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmSupplierDeposits.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub cmdExit_Click()
		Me.Close()
	End Sub
	
	Public Sub loadItem(ByRef id As Integer)
		Dim rs As ADODB.Recordset
		Dim lvList As System.Windows.Forms.ListViewItem
        Dim x, lQuantity As Integer
		Dim lDepositQuantity As Short
        Dim lCost As Decimal
		Dim lActualCost As Decimal
        Dim lDepositUnit As Decimal
		Dim lDepositPack As Decimal
		Dim lvItem As System.Windows.Forms.ListViewItem
		loading = True
		gID = id
		rs = getRS("SELECT * FROM Supplier WHERE SupplierID = " & gID)
		lblSupplier.Text = "Deposits for '" & rs.Fields("Supplier_Name").Value & "'"
		rs.Close()
		lvDeposit.Items.Clear()
		rs = getRS("SELECT * FROM Deposit WHERE (Deposit_Quantity <> 0) and Deposit_Disabled = 0 ORDER BY Deposit_Name")
		Do Until rs.EOF
			If rs.Fields("Deposit_Quantity").Value = "1" Then
				lvList = lvDeposit.Items.Add("k1" & rs.Fields("DepositID").Value, rs.Fields("Deposit_Name").Value, "")
				'UPGRADE_WARNING: Lower bound of collection lvList has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lvList.SubItems.Count > 1 Then
					lvList.SubItems(1).Text = "Unit"
				Else
					lvList.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Unit"))
				End If
			Else
				lvList = lvDeposit.Items.Add("k2" & rs.Fields("DepositID").Value, rs.Fields("Deposit_Name").Value, "")
				'UPGRADE_WARNING: Lower bound of collection lvList has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lvList.SubItems.Count > 1 Then
					lvList.SubItems(1).Text = "Crate"
				Else
					lvList.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Crate"))
				End If
				lvList = lvDeposit.Items.Add("k3" & rs.Fields("DepositID").Value, rs.Fields("Deposit_Name").Value, "")
				'UPGRADE_WARNING: Lower bound of collection lvList has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lvList.SubItems.Count > 1 Then
					lvList.SubItems(1).Text = "Case"
				Else
					lvList.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Case"))
				End If
			End If
			rs.moveNext()
		Loop 
		rs.Close()
		rs = getRS("SELECT SupplierDepositLnk_Type, SupplierDepositLnk_Name, SupplierDepositLnk_DepositID FROM SupplierDepositLnk WHERE (SupplierDepositLnk_SupplierID = " & gID & ")")
		On Error Resume Next
		
		Do Until rs.EOF
			lvItem = lvDeposit.Items.Item("k" & rs.Fields("SupplierDepositLnk_Type").Value & rs.Fields("SupplierDepositLnk_DepositID").Value)
			If lvItem Is Nothing Then
			Else
				lvItem.Checked = True
				'UPGRADE_WARNING: Lower bound of collection lvItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				If lvItem.SubItems.Count > 2 Then
					lvItem.SubItems(2).Text = rs.Fields("SupplierDepositLnk_Name").Value
				Else
					lvItem.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("SupplierDepositLnk_Name").Value))
				End If
			End If
			
			rs.moveNext()
		Loop 
		rs.Close()
		
		loading = False
		
		loadLanguage()
		Me.ShowDialog()
		
	End Sub
	
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	
	Private Sub frmSupplierDeposits_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Select Case KeyCode
			Case System.Windows.Forms.Keys.Escape
				KeyCode = 0
				System.Windows.Forms.Application.DoEvents()
				cmdClose_Click(cmdClose, New System.EventArgs())
		End Select
	End Sub
	
	Private Sub lvDeposit_ItemCheck(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ItemCheckEventArgs) Handles lvDeposit.ItemCheck
		Dim Item As System.Windows.Forms.ListViewItem = lvDeposit.Items(eventArgs.Index)
		Dim lString As String
		If Item.Checked Then
			'UPGRADE_WARNING: Lower bound of collection Item has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If Item.SubItems.Count > 2 Then
				Item.SubItems(2).Text = Item.Text
			Else
				Item.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Item.Text))
			End If
			cnnDB.Execute("INSERT INTO SupplierDepositLnk (SupplierDepositLnk_SupplierID, SupplierDepositLnk_DepositID, SupplierDepositLnk_Type, SupplierDepositLnk_Name) VALUES (" & gID & ", " & Mid(Item.Name, 3) & ", " & Mid(Item.Name, 2, 1) & ", '" & Replace(Item.Text, "'", "''") & "')")
		Else
			cnnDB.Execute("DELETE FROM SupplierDepositLnk WHERE SupplierDepositLnk_SupplierID = " & gID & " AND SupplierDepositLnk_DepositID = " & Mid(lvDeposit.FocusedItem.Name, 3) & " AND SupplierDepositLnk_Type = " & Mid(lvDeposit.FocusedItem.Name, 2, 1))
			'UPGRADE_WARNING: Lower bound of collection Item has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If Item.SubItems.Count > 2 Then
				Item.SubItems(2).Text = ""
			Else
				Item.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, ""))
			End If
		End If
	End Sub
	
	Private Sub lvDeposit_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles lvDeposit.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		Dim lString As String
		Dim lvItem As System.Windows.Forms.ListViewItem
		If lvDeposit.FocusedItem Is Nothing Then
		Else
			If KeyAscii = 13 Then
				'UPGRADE_WARNING: Lower bound of collection lvDeposit.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				lString = InputBox("Enter The Suppliers Name!", "DEPOSIT", lvDeposit.FocusedItem.SubItems(2).Text)
				If lString <> "" Then
					'UPGRADE_WARNING: Lower bound of collection lvDeposit.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
					If lString <> lvDeposit.FocusedItem.SubItems(2).Text Then
						cnnDB.Execute("UPDATE SupplierDepositLnk SET SupplierDepositLnk_Name = '" & Replace(lString, "'", "''") & "' WHERE SupplierDepositLnk_SupplierID = " & gID & " AND SupplierDepositLnk_DepositID = " & Mid(lvDeposit.FocusedItem.Name, 3) & " AND SupplierDepositLnk_Type = " & Mid(lvDeposit.FocusedItem.Name, 2, 1))
						'UPGRADE_WARNING: Lower bound of collection lvDeposit.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
						If lvDeposit.FocusedItem.SubItems.Count > 2 Then
							lvDeposit.FocusedItem.SubItems(2).Text = lString
						Else
							lvDeposit.FocusedItem.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, lString))
						End If
					End If
				End If
			End If
			
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class