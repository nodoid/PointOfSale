Option Strict Off
Option Explicit On
Friend Class frmGRVimport
	Inherits System.Windows.Forms.Form
	Dim gMode As Short
	
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1632 'Import a GRV|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1622 'Imported GRV Data|Checked
        If rsLang.RecordCount Then _Frame1_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _Frame1_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1005 'Next|Checked
		If rsLang.RecordCount Then cmdNext.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdNext.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmGRVimport.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub loadGRV()
		Dim lString As String
        Dim lData As String()
        Dim lFields As String()
		Dim fso As New Scripting.FileSystemObject
		Dim lTextstream As Scripting.TextStream
		Dim x As Integer
		Dim rs As ADODB.Recordset
		Dim lListitem As System.Windows.Forms.ListViewItem
		On Error GoTo loadGRV_Error
		If sGRVSales = "" Then
			CDOpen.ShowDialog()
			lString = CDOpen.FileName
		Else
			lString = sGRVSales
		End If
		
		lvImport.Items.Clear()
		If lString = "" Then
			Me.Close()
		Else
			cnnDB.Execute("DELETE * FROM GRVimport")
			If fso.FileExists(lString) Then
				lTextstream = fso.OpenTextFile(lString)
				lData = Split(lTextstream.ReadAll, vbCrLf)
				
				For x = LBound(lData) To UBound(lData)
					lFields = Split(lData(x), ",")
					If UBound(lFields) = 4 Then
						rs = getRS("SELECT * FROM GRVimport")
						rs.AddNew()
						'barcode,qut,cost,sell
						'code,desc,qty,cost,sell
						rs.Fields(0).Value = x + 1
						rs.Fields(1).Value = lFields(0)
						If lFields(1) = "" Then
							rs.Fields(2).Value = "0"
						Else
							rs.Fields(2).Value = lFields(1)
						End If
						If lFields(3) = "" Then
							rs.Fields(3).Value = 0
						Else
							rs.Fields(3).Value = lFields(3)
						End If
						If lFields(4) = "" Then
							rs.Fields(4).Value = 0
						Else
							rs.Fields(4).Value = lFields(4)
						End If
						rs.update()
					ElseIf UBound(lFields) = 1 Then 
						rs = getRS("SELECT * FROM GRVimport")
						rs.AddNew()
						'code,qty   ,desc,cost,sell
						rs.Fields(0).Value = x + 1
						rs.Fields(1).Value = lFields(0)
						If lFields(1) = "" Then
							rs.Fields(2).Value = "0"
						Else
							rs.Fields(2).Value = lFields(1)
						End If
						rs.Fields(3).Value = 0
						rs.Fields(4).Value = 0
						rs.update()
					End If
				Next 
			End If
			lvImport.Items.Clear()
			cnnDB.Execute("UPDATE CatalogueChannelLnk INNER JOIN (Catalogue INNER JOIN GRVimport ON Catalogue.Catalogue_Barcode = GRVimport.GRVimport_Barcode) ON (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = Catalogue.Catalogue_StockItemID) SET GRVimport.GRVimport_Price = [CatalogueChannelLnk_Price] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((GRVimport.GRVimport_Price)=0));")
			cnnDB.Execute("UPDATE (Catalogue INNER JOIN GRVimport ON Catalogue.Catalogue_Barcode = GRVimport.GRVimport_Barcode) INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID SET GRVimport.GRVimport_Cost = [StockItem_ActualCost] WHERE (((GRVimport.GRVimport_Cost)=0) AND ((Catalogue.Catalogue_Quantity)=1));")
			
			rs = getRS("SELECT StockItem.StockItemID, GRVimport.GRVimport_Key, GRVimport.GRVimport_Barcode, StockItem.StockItem_Name, Catalogue.Catalogue_Quantity, GRVimport.GRVimport_Quantity, GRVimport.GRVimport_Cost, GRVimport.GRVimport_Price FROM (GRVimport INNER JOIN Catalogue ON GRVimport.GRVimport_Barcode = Catalogue.Catalogue_Barcode) INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID WHERE (((StockItem.StockItem_Disabled)=0) AND ((StockItem.StockItem_Discontinued)=0));")
			Do Until rs.EOF
				lListitem = lvImport.Items.Add("x" & rs.Fields("GRVimport_Key").Value, rs.Fields("GRVimport_Barcode").Value & "", "")
				If lListitem.SubItems.Count > 1 Then
					lListitem.SubItems(1).Text = rs.Fields("StockItem_Name").Value
				Else
					lListitem.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("StockItem_Name").Value))
				End If
				If lListitem.SubItems.Count > 2 Then
					lListitem.SubItems(2).Text = rs.Fields("Catalogue_Quantity").Value
				Else
					lListitem.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("Catalogue_Quantity").Value))
				End If
				If lListitem.SubItems.Count > 3 Then
					lListitem.SubItems(3).Text = rs.Fields("GRVimport_Quantity").Value
				Else
					lListitem.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("GRVimport_Quantity").Value))
				End If
				If lListitem.SubItems.Count > 4 Then
					lListitem.SubItems(4).Text = FormatNumber(rs.Fields("GRVimport_Cost").Value, 2)
				Else
					lListitem.SubItems.Insert(4, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("GRVimport_Cost").Value, 2)))
				End If
				If lListitem.SubItems.Count > 5 Then
					lListitem.SubItems(5).Text = FormatNumber(rs.Fields("GRVimport_Price").Value, 2)
				Else
					lListitem.SubItems.Insert(5, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("GRVimport_Price").Value, 2)))
				End If
				If lListitem.SubItems.Count > 6 Then
					lListitem.SubItems(6).Text = rs.Fields("GRVimport_Key").Value
				Else
					lListitem.SubItems.Insert(6, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("GRVimport_Key").Value))
				End If
				rs.moveNext()
			Loop 
		End If
		
		If sGRVSales <> "" Then
			tmrAutoGRV.Enabled = True
		End If
		
		Exit Sub
loadGRV_Error: 
		MsgBox(Err.Description)
		'Resume Next
		Me.Close()
	End Sub
	
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	
	Private Sub cmdNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNext.Click
		Dim sql As String
		Dim rs As ADODB.Recordset
        If _Frame1_0.Visible Then
            _Frame1_1.Visible = True
            _Frame1_0.Visible = False
        Else

            If DataList1.BoundText <> "" Then
                sql = "INSERT INTO PurchaseOrder ( PurchaseOrder_SupplierID, PurchaseOrder_DayEndID, PurchaseOrder_PersonID, PurchaseOrder_DateCreated, PurchaseOrder_PurchaseOrderStatusID, PurchaseOrder_Reference, PurchaseOrder_AttentionLine ) "
                sql = sql & "SELECT " & DataList1.BoundText & ", Company.Company_DayEndID, " & gPersonID & ", Now(), 1, '" & Format(Now, "yyyy mmm dd") & " (Import)', '' FROM Company;"
                cnnDB.Execute(sql, , ADODB.ExecuteOptionEnum.adExecuteNoRecords)
                rs = getRS("SELECT Max(PurchaseOrder.PurchaseOrderID) AS id FROM PurchaseOrder;")

                Me.Close()
                frmGRV.Create(rs.Fields("id").Value, True)
            End If
        End If
	End Sub
	
	Private Sub DataList1_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DataList1.DoubleClick
		cmdNext_Click(cmdNext, New System.EventArgs())
	End Sub
	
	Private Sub DataList1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles DataList1.KeyPress
        Dim KeyCode As Integer
        If eventArgs.KeyChar = ChrW(13) Then
            cmdNext_Click(cmdNext, New System.EventArgs())
            KeyCode = 0
        End If
	End Sub
	
	Private Sub frmGRVimport_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim rs As ADODB.Recordset
		rs = getRS("SELECT DISTINCT SupplierID, Supplier_Name FROM Supplier ORDER BY Supplier_Name")
		'Display the list of Titles in the DataCombo
		DataList1.DataSource = rs
		DataList1.listField = "Supplier_Name"
		
		
		'Bind the DataCombo to the ADO Recordset
		'UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
		DataList1.DataSource = rs
		DataList1.boundColumn = "SupplierID"
		
		loadLanguage()
		loadGRV()
	End Sub
	
	Private Sub tmrAutoGRV_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrAutoGRV.Tick
        Dim sql As String
        Dim suppID As Integer
		tmrAutoGRV.Enabled = False
		
		Dim rs As ADODB.Recordset
		
		suppID = 2
		rs = getRS("SELECT DISTINCT SupplierID, Supplier_Name FROM Supplier WHERE Supplier_ShippingCode = '" & HOfficeID & "'")
		If rs.RecordCount Then suppID = rs.Fields("SupplierID").Value
		sql = "INSERT INTO PurchaseOrder ( PurchaseOrder_SupplierID, PurchaseOrder_DayEndID, PurchaseOrder_PersonID, PurchaseOrder_DateCreated, PurchaseOrder_PurchaseOrderStatusID, PurchaseOrder_Reference, PurchaseOrder_AttentionLine ) "
		sql = sql & "SELECT " & suppID & ", Company.Company_DayEndID, " & gPersonID & ", Now(), 1, '" & Format(Now, "yyyy mmm dd") & " (Import)', '' FROM Company;"
		cnnDB.Execute(sql,  , ADODB.ExecuteOptionEnum.adExecuteNoRecords)
		rs = getRS("SELECT Max(PurchaseOrder.PurchaseOrderID) AS id FROM PurchaseOrder;")
		
		Me.Close()
		frmGRV.Create(rs.Fields("id").Value, True)
	End Sub
End Class