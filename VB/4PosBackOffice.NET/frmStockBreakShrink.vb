Option Strict Off
Option Explicit On
Friend Class frmStockBreakShrink
	Inherits System.Windows.Forms.Form
	Dim gFilter As String
	Dim gRS As ADODB.Recordset
	Dim gFilterSQL As String
	Dim gID As Integer
	Dim gSection As Short
	
	Private Sub loadLanguage()
		
		'frmStockBreakShrink = No Code  [Break a Stock Item]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmStockBreakShrink.Caption = rsLang("LanguageLayoutLnk_Description"): frmStockBreakShrink.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1080 'Search|Checked
		If rsLang.RecordCount Then _lbl_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lbl_1 = No Code               [Quantity to move]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdMove = No Code              [Move]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdMove.Caption = rsLang("LanguageLayoutLnk_Description"): cmdMove.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmStockBreakShrink.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Function getItem() As Integer
        Dim cmdNew As New Button
		cmdNew.Visible = False
		
		loadLanguage()
		Me.ShowDialog()
		getItem = gID
		
	End Function
	
	Private Sub getNamespace()
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	
	Private Sub cmdNamespace_Click()
		frmFilter.loadFilter(gFilter)
		getNamespace()
	End Sub
	
	
	Private Sub DataList1_DblClick()
		Dim cmdNew As Object
		Dim DataList1 As Object
		
		'UPGRADE_WARNING: Couldn't resolve default property of object cmdNew.Visible. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If cmdNew.Visible Then
			'UPGRADE_WARNING: Couldn't resolve default property of object DataList1.BoundText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If DataList1.BoundText <> "" Then
				'UPGRADE_WARNING: Couldn't resolve default property of object DataList1.BoundText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				frmStockGroup.loadItem(DataList1.BoundText)
			End If
			doSearch()
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object DataList1.BoundText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If DataList1.BoundText = "" Then
				gID = 0
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object DataList1.BoundText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gID = DataList1.BoundText
			End If
			Select Case gSection
				Case 0
					Me.Close()
				Case 1
					'UPGRADE_WARNING: Couldn't resolve default property of object DataList1.BoundText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					report_StockTake(DataList1.BoundText)
				Case 2
					'UPGRADE_WARNING: Couldn't resolve default property of object DataList1.BoundText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					frmStockTake.loadItem(DataList1.BoundText)
				Case 3
					'UPGRADE_WARNING: Couldn't resolve default property of object DataList1.BoundText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					report_StockQuantityData(DataList1.BoundText)
			End Select
		End If
	End Sub
	
	Private Sub DataList1_KeyPress(ByRef KeyAscii As Short)
		Select Case KeyAscii
			Case 13
				DataList1_DblClick()
				KeyAscii = 0
			Case 27
				Me.Close()
				KeyAscii = 0
		End Select
		
	End Sub
	
	Private Sub cmdMove_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMove.Click
		Dim lParent, lChild As Integer
		lParent = CInt(Split(lblData.Tag, "_")(0))
		lChild = CInt(Split(lblData.Tag, "_")(1))
		Dim lQty As Short
		lQty = CShort(Me.txtQuantity.Text)
		If lQty Then
			If MsgBox("Are you sure to want to commit this conversion?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, "COMMIT CONVERSION") = MsgBoxResult.Yes Then
				cnnDB.Execute("UPDATE WarehouseStockItemLnk SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]-" & lQty & " WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID)=" & lParent & "));")
				cnnDB.Execute("UPDATE Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-" & lQty & " WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & lParent & "));")
				
				'UPGRADE_WARNING: Lower bound of collection Me.lvStock.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				lQty = lQty * CDbl(Me.lvStock.FocusedItem.SubItems(4).Text)
				
				cnnDB.Execute("UPDATE WarehouseStockItemLnk SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+" & lQty & " WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID)=" & lChild & "));")
				cnnDB.Execute("UPDATE Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]+" & lQty & " WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & lChild & "));")
				
				cnnDB.Execute("UPDATE StockItem INNER JOIN (StockBreak INNER JOIN StockItem AS StockItem_1 ON StockBreak.StockBreak_ChildID = StockItem_1.StockItemID) ON StockItem.StockItemID = StockBreak.StockBreak_ParentID SET StockItem_1.StockItem_ActualCost = [StockItem!StockItem_ActualCost]/CLng([StockItem!StockItem_Quantity])/CLng([StockBreak!StockBreak_Quantity]), StockItem_1.StockItem_ListCost = [StockItem!StockItem_ListCost]/CLng([StockItem!StockItem_Quantity])/CLng([StockBreak!StockBreak_Quantity]) WHERE (((StockItem.StockItemID)=" & lParent & ") AND ((StockItem_1.StockItemID)=" & lChild & "));")
				
				cnnDB.Execute("INSERT INTO StockBreakTransaction ( StockBreakTransaction_ParentID, StockBreakTransaction_ChildID, StockBreakTransaction_DayEndID, StockBreakTransaction_Quantity, StockBreakTransaction_MoveQuantity ) SELECT StockBreak.StockBreak_ParentID, StockBreak.StockBreak_ChildID, Company.Company_DayEndID, StockBreak.StockBreak_Quantity, " & CShort(Me.txtQuantity.Text) & " AS moveQty From Company, StockBreak WHERE (((StockBreak.StockBreak_ParentID)=" & lParent & ") AND ((StockBreak.StockBreak_ChildID)=" & lChild & "));")
				
				
				doSearch()
			End If
		Else
			MsgBox("Stock Item Move Quantity is ZERO!", MsgBoxStyle.Exclamation, "STOCK ITEM CONVERSION")
			Me.txtQuantity.Focus()
		End If
		
	End Sub
	
	Private Sub frmStockBreakShrink_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.Escape
				KeyAscii = 0
				cmdExit_Click(cmdExit, New System.EventArgs())
		End Select
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Public Sub loadItem(ByRef section As Short)
		Dim cmdNew As Object
		gSection = section
		'UPGRADE_WARNING: Couldn't resolve default property of object cmdNew.Visible. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If gSection Then cmdNew.Visible = False
		doSearch()
		
		loadLanguage()
		Me.ShowDialog()
	End Sub
	
	Private Sub frmStockBreakShrink_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        lvStock.Columns.Add("", "From Stock Item", CInt(twipsToPixels(3800, True)))
        lvStock.Columns.Add("QTY", CInt(twipsToPixels(800, True)), System.Windows.Forms.HorizontalAlignment.Right)
        lvStock.Columns.Add("", "To Stock Item", CInt(twipsToPixels(3750, True)))
        lvStock.Columns.Add("QTY", CInt(twipsToPixels(800, True)), System.Windows.Forms.HorizontalAlignment.Right)
        lvStock.Columns.Add("Move", CInt(twipsToPixels(600, True)), System.Windows.Forms.HorizontalAlignment.Right)
	End Sub
	
	Private Sub frmStockBreakShrink_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		gRS.Close()
	End Sub
	
	Private Sub lvStock_ItemClick(ByVal Item As System.Windows.Forms.ListViewItem)
		Me.lblData.Text = "Remove one unit of '" & lvStock.FocusedItem.Text & "' and create " & lvStock.FocusedItem.SubItems(4).Text & " units of '" & lvStock.FocusedItem.SubItems(2).Text & "'."
		Me.lblData.Tag = lvStock.FocusedItem.Name
	End Sub
	
	Private Sub lvStock_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles lvStock.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Then
			Me.txtQuantity.Focus()
			KeyAscii = 0
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtQuantity_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQuantity.Enter
        MyGotFocusNumeric(txtQuantity)
	End Sub
	
	Private Sub txtQuantity_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtQuantity.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Then
			Me.cmdMove.Focus()
			KeyAscii = 0
		Else
            MyKeyPress(KeyAscii)
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtQuantity_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQuantity.Leave
        MyLostFocus(txtQuantity, 0)
	End Sub
	
	Private Sub txtSearch_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSearch.Enter
		txtSearch.SelectionStart = 0
		txtSearch.SelectionLength = 999
	End Sub
	
	Private Sub txtSearch_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Select Case KeyCode
			Case 40
				Me.lvStock.Focus()
		End Select
	End Sub
	
	Private Sub txtSearch_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case KeyAscii
			Case 13
				doSearch()
				KeyAscii = 0
		End Select
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub doSearch()
		Dim sql As String
		Dim lString As String
		Dim listItem As System.Windows.Forms.ListViewItem
		lString = Trim(txtSearch.Text)
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		If lString = "" Then
		Else
			lString = " AND (StockItem.StockItem_Name LIKE '%" & Replace(lString, " ", "%' AND StockItem.StockItem_Name LIKE '%") & "%')"
		End If
		lString = " WHERE StockBreak.StockBreak_Disabled=0 AND WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID=2 AND WarehouseStockItemLnk_1.WarehouseStockItemLnk_WarehouseID=2 " & lString
		gRS = getRS("SELECT StockBreak.StockBreak_Quantity, StockBreak.StockBreak_ParentID, StockItem.StockItem_Name, WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity, StockBreak.StockBreak_ChildID, StockItemChild.StockItem_Name AS StockItemChild_Name, WarehouseStockItemLnk_1.WarehouseStockItemLnk_Quantity AS WarehouseStockItemLnkChild_Quantity FROM WarehouseStockItemLnk AS WarehouseStockItemLnk_1 INNER JOIN (WarehouseStockItemLnk INNER JOIN ((StockBreak INNER JOIN StockItem ON StockBreak.StockBreak_ParentID = StockItem.StockItemID) INNER JOIN StockItem AS StockItemChild ON StockBreak.StockBreak_ChildID = StockItemChild.StockItemID) ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON WarehouseStockItemLnk_1.WarehouseStockItemLnk_StockItemID = StockItemChild.StockItemID " & lString & " ORDER BY StockItem.StockItem_Name")
		lvStock.Items.Clear()
		Do Until gRS.EOF
			listItem = lvStock.Items.Add(gRS.Fields("StockBreak_ParentID").Value & "_" & gRS.Fields("StockBreak_ChildID").Value, gRS.Fields("StockItem_Name").Value, "")
			If listItem.SubItems.Count > 0 Then
                listItem.SubItems(0).Text = gRS.Fields("WarehouseStockItemLnk_Quantity").Value
            Else
                listItem.SubItems.Insert(0, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, gRS.Fields("WarehouseStockItemLnk_Quantity").Value))
            End If
			If listItem.SubItems.Count > 1 Then
                listItem.SubItems(1).Text = gRS.Fields("StockItemChild_Name").Value
            Else
                listItem.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, gRS.Fields("StockItemChild_Name").Value))
            End If
			If listItem.SubItems.Count > 2 Then
                listItem.SubItems(2).Text = gRS.Fields("WarehouseStockItemLnkChild_Quantity").Value
            Else
                listItem.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, gRS.Fields("WarehouseStockItemLnkChild_Quantity").Value))
            End If
			If listItem.SubItems.Count > 3 Then
                listItem.SubItems(3).Text = gRS.Fields("StockBreak_Quantity").Value
            Else
                listItem.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, gRS.Fields("StockBreak_Quantity").Value))
            End If
			
			gRS.moveNext()
		Loop 
		If lvStock.FocusedItem Is Nothing Then
			Me.lblData.Text = ""
			picMove.Visible = False
		Else
			'UPGRADE_ISSUE: MSComctlLib.ListView event lvStock.ItemClick was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
			lvStock_ItemClick(lvStock.FocusedItem)
			picMove.Visible = True
		End If
	End Sub
End Class