Option Strict Off
Option Explicit On
Friend Class frmBlockTestSelect
	Inherits System.Windows.Forms.Form
	Dim testType As String
	Dim testID As Integer
	
	Private Sub loadLanguage()
		
		'frmBlockTestSelect = No code   [Block Test]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmBlockTestSelect.Caption = rsLang("LanguageLayoutLnk_Description"): frmBlockTestSelect.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1080 'Search|Checked
		If rsLang.RecordCount Then _lbl_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'cmdEdit = No Code              [Load Selected Test]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdEdit.Caption = rsLang("LanguageLayoutLnk_Description"): cmdEdit.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdNew = No Code               [Create a N&ew Test]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdNew.Caption = rsLang("LanguageLayoutLnk_Description"): cmdNew.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmBlockTestSelect.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Sub loadTest(ByRef tType As String, ByRef tID As Integer)
		doSearch()
		
		loadLanguage()
		ShowDialog()
		
		tType = testType
		tID = testID
	End Sub
	
	Private Sub cmdEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEdit.Click
		If Me.lvImport.FocusedItem Is Nothing Then
		Else
			testType = "load"
			testID = CInt(Mid(Me.lvImport.FocusedItem.Name, 2))
			Me.Close()
		End If
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		testType = "exit"
		testID = 0
		Me.Close()
	End Sub
	
	Private Sub cmdNew_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNew.Click
		testType = "new"
		testID = 0
		Me.Close()
	End Sub
	
	Private Sub cmdNewExist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNewExist.Click
		testType = "select"
		testID = 0
		Me.Close()
	End Sub
	
	Private Sub doSearch()
        Dim rs As ADODB.Recordset
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
			lString = " AND (BlockTest.BlockTest_Desc LIKE '%" & Replace(lString, " ", "%' AND BlockTest.BlockTest_Desc LIKE '%") & "%')"
		End If
		
		rs = getRS("SELECT BlockTest.BlockTestID, BlockTest.BlockTest_Date, BlockTest.BlockTest_MainItemID, BlockTest.BlockTest_PersonID, BlockTest.BlockTest_Desc, Person.Person_FirstName, Person.Person_LastName, StockItem.StockItem_Name, BlockTest.BlockTest_BlockTestStatusID FROM (BlockTest INNER JOIN Person ON BlockTest.BlockTest_PersonID = Person.PersonID) INNER JOIN StockItem ON BlockTest.BlockTest_MainItemID = StockItem.StockItemID WHERE ((BlockTest.BlockTest_BlockTestStatusID)>0) " & lString & " ORDER BY BlockTest.BlockTest_Desc;")
		'Set rs = getRS("SELECT PurchaseOrder.PurchaseOrderID, Supplier.Supplier_Name, PurchaseOrder.PurchaseOrder_DateCreated, PurchaseOrder.PurchaseOrder_Reference, GRV.GRV_InvoiceNumber, GRV.GRV_InvoiceInclusive FROM ((PurchaseOrder INNER JOIN Supplier ON PurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN PurchaseOrderStatus ON PurchaseOrder.PurchaseOrder_PurchaseOrderStatusID = PurchaseOrderStatus.PurchaseOrderStatusID) LEFT JOIN GRV ON PurchaseOrder.PurchaseOrderID = GRV.GRV_PurchaseOrderID Where PurchaseOrderStatus.PurchaseOrderStatus_Complete = 0 And Supplier.Supplier_Disabled = 0 " & lString & " ORDER BY Supplier.Supplier_Name;")
		On Error Resume Next
		lvImport.Items.Clear()
		'UPGRADE_WARNING: Couldn't resolve default property of object rs.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Do Until rs.EOF
			'UPGRADE_WARNING: Couldn't resolve default property of object rs(BlockTest_Desc). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            listItem = Me.lvImport.Items.Add("k" & rs("BlockTestID").Value, rs("BlockTest_Desc").Value, "")
			cmddelete.Enabled = True
			'UPGRADE_WARNING: Lower bound of collection listItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If listItem.SubItems.Count > 1 Then
                listItem.SubItems(1).Text = Format(rs("BlockTest_Date"), "yyyy mmm dd")
			Else
                listItem.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Format(rs("BlockTest_Date"), "yyyy mmm dd")))
			End If
			'UPGRADE_WARNING: Lower bound of collection listItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Couldn't resolve default property of object rs(Person_LastName). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If listItem.SubItems.Count > 2 Then
                listItem.SubItems(2).Text = rs("Person_FirstName").Value & " " & rs("Person_LastName").Value
			Else
                listItem.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs("Person_FirstName").Value & " " & rs("Person_LastName").Value))
			End If
			'If IsNull(rs("GRV_InvoiceInclusive")) Then
			'Else
			'UPGRADE_WARNING: Lower bound of collection listItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_WARNING: Couldn't resolve default property of object rs(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If listItem.SubItems.Count > 3 Then
				listItem.SubItems(3).Text = rs("StockItem_Name")
			Else
				listItem.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs("StockItem_Name")))
			End If
			'    listItem.SubItems(4) = FormatNumber(rs("GRV_InvoiceInclusive"), 2)
			'End If
			'UPGRADE_WARNING: Couldn't resolve default property of object rs.moveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			rs.moveNext()
		Loop 
		
	End Sub
	
	Private Sub txtSearch_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSearch.Enter
		txtSearch.SelectionStart = 0
		txtSearch.SelectionLength = 999
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
	
	Private Sub lvImport_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvImport.DoubleClick
		cmdEdit_Click(cmdEdit, New System.EventArgs())
	End Sub
	
	Private Sub lvImport_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles lvImport.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Then cmdEdit_Click(cmdEdit, New System.EventArgs())
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	
	Private Sub loadBT()
		Dim rs As ADODB.Recordset
		Dim listItem As System.Windows.Forms.ListViewItem
		lvImport.Items.Clear()
		rs = getRS("SELECT StockItem.StockItemID, GRVimport.GRVimport_Key, GRVimport.GRVimport_Barcode, StockItem.StockItem_Name, Catalogue.Catalogue_Quantity, GRVimport.GRVimport_Quantity, GRVimport.GRVimport_Cost, GRVimport.GRVimport_Price FROM (GRVimport INNER JOIN Catalogue ON GRVimport.GRVimport_Barcode = Catalogue.Catalogue_Barcode) INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID;")
		Do Until rs.EOF
			listItem = Me.lvImport.Items.Add("k" & rs.Fields("stockitemID").Value, rs.Fields("GRVimport_Barcode").Value, "")
			'UPGRADE_WARNING: Lower bound of collection listItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If listItem.SubItems.Count > 1 Then
				listItem.SubItems(1).Text = rs.Fields("StockItem_Name").Value
			Else
				listItem.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("StockItem_Name").Value))
			End If
			'UPGRADE_WARNING: Lower bound of collection listItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If listItem.SubItems.Count > 2 Then
				listItem.SubItems(2).Text = rs.Fields("Catalogue_Quantity").Value
			Else
				listItem.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("Catalogue_Quantity").Value))
			End If
			'UPGRADE_WARNING: Lower bound of collection listItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If listItem.SubItems.Count > 3 Then
				listItem.SubItems(3).Text = rs.Fields("GRVimport_Quantity").Value
			Else
				listItem.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("GRVimport_Quantity").Value))
			End If
			'UPGRADE_WARNING: Lower bound of collection listItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If listItem.SubItems.Count > 4 Then
				listItem.SubItems(4).Text = FormatNumber(rs.Fields("GRVimport_Cost").Value, 2)
			Else
				listItem.SubItems.Insert(4, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("GRVimport_Cost").Value, 2)))
			End If
			'UPGRADE_WARNING: Lower bound of collection listItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If listItem.SubItems.Count > 5 Then
				listItem.SubItems(5).Text = FormatNumber(rs.Fields("GRVimport_Price").Value, 2)
			Else
				listItem.SubItems.Insert(5, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("GRVimport_Price").Value, 2)))
			End If
			'UPGRADE_WARNING: Lower bound of collection listItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If listItem.SubItems.Count > 6 Then
				listItem.SubItems(6).Text = rs.Fields("GRVimport_Key").Value
			Else
				listItem.SubItems.Insert(6, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("GRVimport_Key").Value))
			End If
			rs.moveNext()
		Loop 
	End Sub
End Class