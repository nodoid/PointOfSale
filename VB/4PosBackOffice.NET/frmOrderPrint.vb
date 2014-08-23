Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmOrderPrint
	Inherits System.Windows.Forms.Form
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1613 'Purchase Order Print|Checked
		If rsLang.RecordCount Then lblPath.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lblPath.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1433 'Select a Supplier|Checked
		If rsLang.RecordCount Then _lbl_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1615 'Select a Purchase Order|Checked
		If rsLang.RecordCount Then _lbl_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmOrderPrint.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub setHeading()
		Dim lvHeading As System.Windows.Forms.ColumnHeader
		lvItems.Columns.Clear()
		lvHeading = lvItems.Columns.Add("Supplier")
        lvHeading.Width = twipsToPixels(2100, True)
		lvHeading = lvItems.Columns.Add("Invoice Number")
        lvHeading.Width = twipsToPixels(1500, True)
		lvHeading = lvItems.Columns.Add("Date")
        lvHeading.Width = twipsToPixels(1100, True)
		lvHeading = lvItems.Columns.Add("Amount")
        lvHeading.Width = twipsToPixels(1300, True)
		lvHeading.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
	End Sub
	
	Private Sub cmdBack_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBack.Click
		Me.Close()
	End Sub
	
	Private Sub frmOrderPrint_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub frmOrderPrint_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim loading As Boolean
		loading = True
		Dim rs As ADODB.Recordset
		'    Dim lNode As IXMLDOMNode
		'    Dim lNodeList As IXMLDOMNodeList
        Dim x, lQuantity As Integer
		Dim lDepositQuantity As Short
        Dim lCost As Decimal
		Dim lActualCost As Decimal
        Dim lDepositUnit As Decimal
		Dim lDepositPack As Decimal
		Dim ltype As String
		setHeading()
		
		loadLanguage()
		
		rs = getRS("SELECT TOP 100 PERCENT Supplier.* FROM Supplier WHERE Supplier_Disabled = 0 ORDER BY Supplier.Supplier_Name")
		Me.lstSupplier.Items.Clear()
		Do Until rs.EOF
            If IsDBNull(rs.Fields("Supplier_GRVtype").Value) Then
                ltype = "normal"
            Else
                ltype = rs.Fields("Supplier_GRVtype").Value
                If ltype = "" Then ltype = "normal"
            End If
            lstSupplier.Items.Add(New LBI(rs.Fields("Supplier_Name").Value & "", rs.Fields("SupplierID").Value))
            rs.MoveNext()
        Loop
		lstSupplier.SelectedIndex = 0
		loading = False
	End Sub
	
	Private Sub lstSupplier_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstSupplier.SelectedIndexChanged
		Dim rs As ADODB.Recordset
		Dim lvItem As System.Windows.Forms.ListViewItem
		If lstSupplier.SelectedIndex = -1 Then Exit Sub
		rs = getRS("SELECT TOP 100 PurchaseOrder.PurchaseOrderID, PurchaseOrder.PurchaseOrder_Reference, PurchaseOrder.PurchaseOrder_DateCreated, PurchaseOrder.PurchaseOrder_PurchaseOrderStatusID, Supplier.Supplier_Name FROM PurchaseOrderItem INNER JOIN (PurchaseOrder INNER JOIN Supplier ON PurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) ON PurchaseOrderItem.PurchaseOrderItem_PurchaseOrderID = PurchaseOrder.PurchaseOrderID GROUP BY PurchaseOrder.PurchaseOrderID, PurchaseOrder.PurchaseOrder_Reference, PurchaseOrder.PurchaseOrder_DateCreated, PurchaseOrder.PurchaseOrder_PurchaseOrderStatusID, Supplier.Supplier_Name, PurchaseOrder.PurchaseOrder_SupplierID Having (((PurchaseOrder.PurchaseOrder_SupplierID) = " & CInt(lstSupplier.SelectedIndex) & ")) ORDER BY PurchaseOrder.PurchaseOrderID DESC;")
		
		Me.lvItems.Items.Clear()
		Do Until rs.EOF
			
			lvItem = lvItems.Items.Add("K" & rs.Fields("PurchaseOrderID").Value, rs.Fields("Supplier_Name").Value, "")

            If rs.Fields("PurchaseOrder_PurchaseOrderStatusID").Value <> 1 Then
                'lvItem.Font = lvItem.Font.
            End If

            'UPGRADE_WARNING: Lower bound of collection lvItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
            If lvItem.SubItems.Count > 0 Then
                lvItem.SubItems(0).Text = rs.Fields("PurchaseOrder_Reference").Value
            Else
                lvItem.SubItems.Insert(0, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("PurchaseOrder_Reference").Value))
            End If
            'UPGRADE_WARNING: Lower bound of collection lvItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
            If lvItem.SubItems.Count > 1 Then
                lvItem.SubItems(1).Text = Format(rs.Fields("PurchaseOrder_DateCreated").Value, "dd,mmm yyyy")
            Else
                lvItem.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Format(rs.Fields("PurchaseOrder_DateCreated").Value, "dd,mmm yyyy")))
            End If
            rs.MoveNext()
        Loop
		
	End Sub
	
	Private Sub lstSupplier_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles lstSupplier.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 27 Then
			Me.Close()
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub lvItems_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvItems.DoubleClick
		If lvItems.FocusedItem Is Nothing Then
		Else
			report_PurchaseOrder(CInt(Mid(lvItems.FocusedItem.Name, 2)))
		End If
	End Sub
	
	Private Sub lvItems_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles lvItems.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 27 Then
			Me.Close()
		ElseIf KeyAscii = 13 Then 
			lvItems_DoubleClick(lvItems, New System.EventArgs())
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class