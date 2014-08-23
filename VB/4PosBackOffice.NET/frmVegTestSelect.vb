Option Strict Off
Option Explicit On
Friend Class frmVegTestSelect
	Inherits System.Windows.Forms.Form
	Dim testType As String
	Dim testID As Integer
	Dim gAll As Boolean
	
	Public Sub loadTest(ByRef tType As String, ByRef tID As Integer)
		doSearch()
		ShowDialog()
		
		tType = testType
		tID = testID
	End Sub
	
	Private Sub cmdDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDelete.Click
		On Error Resume Next
		Dim rs As ADODB.Recordset
		
		If Me.lvImport.FocusedItem Is Nothing Then
		Else
			If MsgBox("Are you sure you wish to delete the selected Production Test", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
				
				rs = getRS("SELECT * FROM VegTest WHERE VegTest.VegTestID =" & Mid(Me.lvImport.FocusedItem.Name, 2) & ";")
				If rs.Fields("VegTest_VegTestStatusID").Value = 3 Then
					MsgBox("You may not delete Processed Production Test!")
				Else
					cnnDB.Execute("DELETE * FROM VegTest WHERE VegTest.VegTestID =" & Mid(Me.lvImport.FocusedItem.Name, 2))
					cnnDB.Execute("DELETE * FROM VegTestItem WHERE VegTestItem_VegTestID =" & Mid(Me.lvImport.FocusedItem.Name, 2))
				End If
				doSearch()
			End If
		End If
		
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
			lString = " AND (VegTest.VegTest_Desc LIKE '%" & Replace(lString, " ", "%' AND VegTest.VegTest_Desc LIKE '%") & "%')"
		End If
		
		If gAll Then
			rs = getRS("SELECT VegTest.VegTestID, VegTest.VegTest_Date, VegTest.VegTest_MainItemID, VegTest.VegTest_PersonID, VegTest.VegTest_Desc, Person.Person_FirstName, Person.Person_LastName, StockItem.StockItem_Name, VegTest.VegTest_VegTestStatusID FROM (VegTest INNER JOIN Person ON VegTest.VegTest_PersonID = Person.PersonID) INNER JOIN StockItem ON VegTest.VegTest_MainItemID = StockItem.StockItemID WHERE ((VegTest.VegTest_VegTestStatusID)>0) " & lString & " ORDER BY VegTest.VegTestID DESC;")
		Else
			rs = getRS("SELECT VegTest.VegTestID, VegTest.VegTest_Date, VegTest.VegTest_MainItemID, VegTest.VegTest_PersonID, VegTest.VegTest_Desc, Person.Person_FirstName, Person.Person_LastName, StockItem.StockItem_Name, VegTest.VegTest_VegTestStatusID FROM (VegTest INNER JOIN Person ON VegTest.VegTest_PersonID = Person.PersonID) INNER JOIN StockItem ON VegTest.VegTest_MainItemID = StockItem.StockItemID WHERE ((VegTest.VegTest_VegTestStatusID)<>3) " & lString & " ORDER BY VegTest.VegTestID DESC;")
		End If
		'Set rs = getRS("SELECT PurchaseOrder.PurchaseOrderID, Supplier.Supplier_Name, PurchaseOrder.PurchaseOrder_DateCreated, PurchaseOrder.PurchaseOrder_Reference, GRV.GRV_InvoiceNumber, GRV.GRV_InvoiceInclusive FROM ((PurchaseOrder INNER JOIN Supplier ON PurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN PurchaseOrderStatus ON PurchaseOrder.PurchaseOrder_PurchaseOrderStatusID = PurchaseOrderStatus.PurchaseOrderStatusID) LEFT JOIN GRV ON PurchaseOrder.PurchaseOrderID = GRV.GRV_PurchaseOrderID Where PurchaseOrderStatus.PurchaseOrderStatus_Complete = 0 And Supplier.Supplier_Disabled = 0 " & lString & " ORDER BY Supplier.Supplier_Name;")
		On Error Resume Next
		lvImport.Items.Clear()
		Do Until rs.EOF
            listItem = Me.lvImport.Items.Add("k" & rs("VegTestID").Value, rs("VegTest_Desc").Value, "")
			cmddelete.Enabled = True
			If listItem.SubItems.Count > 1 Then
				listItem.SubItems(1).Text = Format(rs("VegTest_Date"), "yyyy mmm dd")
			Else
				listItem.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Format(rs("VegTest_Date"), "yyyy mmm dd")))
			End If
			If listItem.SubItems.Count > 2 Then
                listItem.SubItems(2).Text = rs("Person_FirstName").Value & " " & rs("Person_LastName").Value
			Else
                listItem.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs("Person_FirstName").Value & " " & rs("Person_LastName").Value))
			End If
			'If IsNull(rs("GRV_InvoiceInclusive")) Then
			'Else
			If listItem.SubItems.Count > 3 Then
				listItem.SubItems(3).Text = rs("StockItem_Name")
			Else
				listItem.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs("StockItem_Name")))
			End If
			'    listItem.SubItems(4) = FormatNumber(rs("GRV_InvoiceInclusive"), 2)
			'End If
			rs.moveNext()
		Loop 
		
	End Sub
	
	Private Sub cmdRepair_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRepair.Click
		frmMakeRepairItem.makeItem()
	End Sub
	
	Private Sub cmdRevST_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRevST.Click
		Dim lID As Integer
		Dim rs As ADODB.Recordset
		
		lID = frmStockList.getItem
		If lID <> 0 Then
			rs = getRS("SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS Warehouse_StockItemQuantity From WarehouseStockItemLnk Where (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) = 1 Or (WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) = 2)) GROUP BY WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID HAVING (((WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID)=" & lID & "));")
			If rs.RecordCount Then
				If rs.Fields("Warehouse_StockItemQuantity").Value > 0 Then
					frmVegTestStockBack.loadItem(lID, rs.Fields("Warehouse_StockItemQuantity").Value)
				Else
					MsgBox("Insufficient Qty!")
					Exit Sub
				End If
			Else
				MsgBox("Insufficient Qty!")
				Exit Sub
			End If
			'
		End If
	End Sub
	
	Private Sub frmVegTestSelect_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KeyCode = 36 Then
			gAll = Not gAll
			doSearch()
			KeyCode = False
		End If
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
	
	Private Sub lvImport_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvImport.Click
        Dim HoldGrvID As String
        Dim rs As ADODB.Recordset
		'*Get the following fields
		On Error Resume Next
		rs = getRS("SELECT GRV.GRVID,GRV.GRV_InvoiceNumber, GRV.GRV_InvoiceInclusive,GRVItem.GRVItem_GRVID FROM ((GRV INNER JOIN GRVItem ON GRV.GRVID=GRVItem.GRVItem_GRVID))")
		
		'*Get the GRVID of the select GRV,Remove letter K from It and hold it.
		HoldGrvID = Split(lvImport.FocusedItem.Name, "_")(0)
		HoldGrvID = Mid(HoldGrvID, 2)
		
		'Set rs = getRS("SELECT GRV_InvoiceNumber FROM GRV WHERE GRVID=" & HoldGrvID)
		'HoldGrvNo = rs("GRV_InvoiceNumber")
		
		'HoldName = lvImport.SelectedItem
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