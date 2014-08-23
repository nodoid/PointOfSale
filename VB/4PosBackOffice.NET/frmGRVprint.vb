Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmGRVprint
	Inherits System.Windows.Forms.Form
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1781 'Invoice Print|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1433 'Select a Supplier|Checked
		If rsLang.RecordCount Then _lbl_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1783 'Select an Invoice|Checked
		If rsLang.RecordCount Then _lbl_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmGRVprint.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
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
	
	Private Sub frmGRVprint_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub frmGRVprint_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim loading As Boolean
		loading = True
		Dim rs As ADODB.Recordset
		Dim ltype As String
        Dim tmpString As String
		loadLanguage()
		setHeading()
		rs = getRS("SELECT TOP 100 PERCENT Supplier.* FROM Supplier WHERE Supplier_Disabled = 0 ORDER BY Supplier.Supplier_Name")
		Me.lstSupplier.Items.Clear()
		Do Until rs.EOF
			If IsDbNull(rs.Fields("Supplier_GRVtype").Value) Then
				ltype = "normal"
			Else
				ltype = rs.Fields("Supplier_GRVtype").Value
				If ltype = "" Then ltype = "normal"
            End If
            tmpString = rs.Fields("Supplier_Name").Value & " " & rs.Fields("SupplierID").Value
            lstSupplier.Items.Add(tmpString)
			rs.moveNext()
		Loop 
		lstSupplier.SelectedIndex = 0
		loading = False
	End Sub
	
	Private Sub lstSupplier_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstSupplier.SelectedIndexChanged
        Dim ltype As String
		Dim rs As ADODB.Recordset
		Dim lvItem As System.Windows.Forms.ListViewItem
		If lstSupplier.SelectedIndex = -1 Then Exit Sub
        rs = getRS("SELECT TOP 100 GRV.GRVID, Supplier.SupplierID, Supplier.Supplier_Name, GRV.GRV_GRVStatusID, GRV.GRV_InvoiceNumber, GRV.GRV_InvoiceDate, GRV.GRV_InvoiceInclusive, Supplier.Supplier_GRVtype FROM (PurchaseOrder INNER JOIN GRV ON PurchaseOrder.PurchaseOrderID = GRV.GRV_PurchaseOrderID) INNER JOIN Supplier ON PurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID Where (((Supplier.SupplierID) = " & CLng(lstSupplier.SelectedIndex) & ")) ORDER BY GRV.GRV_InvoiceDate DESC;")
		
		
		Me.lvItems.Items.Clear()
		Do Until rs.EOF
			If IsDbNull(rs.Fields("Supplier_GRVtype").Value) Then
				ltype = "normal"
			Else
				ltype = rs.Fields("Supplier_GRVtype").Value
				If ltype = "" Then ltype = "normal"
			End If
			lvItem = lvItems.Items.Add("K" & rs.Fields("GRVID").Value, rs.Fields("Supplier_Name").Value, "")
			
            lvItem.Font = New Font(lvItem.Font, rs.Fields("GRV_GRVStatusID").Value <> 1)
			
            If lvItem.SubItems.Count > 0 Then
                lvItem.SubItems(0).Text = rs.Fields("GRV_InvoiceNumber").Value
            Else
                lvItem.SubItems.Insert(0, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("GRV_InvoiceNumber").Value))
            End If
			If lvItem.SubItems.Count > 0 Then
                lvItem.SubItems(0).Text = Format(rs.Fields("GRV_InvoiceDate").Value, "dd,mmm yyyy")
            Else
                lvItem.SubItems.Insert(0, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Format(rs.Fields("GRV_InvoiceDate").Value, "dd,mmm yyyy")))
            End If
			If lvItem.SubItems.Count > 1 Then
                lvItem.SubItems(1).Text = FormatNumber(rs.Fields("GRV_InvoiceInclusive").Value, 1)
            Else
                lvItem.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("GRV_InvoiceInclusive").Value, 2)))
            End If
			rs.moveNext()
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
			report_GRV(CInt(Mid(lvItems.FocusedItem.Name, 2)))
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