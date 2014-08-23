Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmVegTestGRV
	Inherits System.Windows.Forms.Form
	Dim localGRVID As Integer
	
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
	
	Private Sub frmVegTestGRV_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Public Function getGRVID() As Integer
		localGRVID = 0
		ShowDialog()
		getGRVID = localGRVID
	End Function
	
	Private Sub frmVegTestGRV_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim loading As Boolean
		'loading = True
		Dim rs As ADODB.Recordset
        Dim X, lQuantity As Short
		Dim lDepositQuantity As Short
        Dim lCost As Decimal
		Dim lActualCost As Decimal
        Dim lDepositUnit As Decimal
		Dim lDepositPack As Decimal
        Dim ltype As String
        Dim tmp As String
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
            tmp = rs.Fields("Supplier_Name").Value & "" & rs.Fields("SupplierID").Value
            lstSupplier.Items.Add(tmp)
			rs.moveNext()
		Loop 
		lstSupplier.SelectedIndex = 0
		loading = False
	End Sub
	
	'UPGRADE_WARNING: Event lstSupplier.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub lstSupplier_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstSupplier.SelectedIndexChanged
        Dim ltype As String
		Dim rs As ADODB.Recordset
		Dim lvItem As System.Windows.Forms.ListViewItem
		If lstSupplier.SelectedIndex = -1 Then Exit Sub
        rs = getRS("SELECT TOP 100 GRV.GRVID, Supplier.SupplierID, Supplier.Supplier_Name, GRV.GRV_GRVStatusID, GRV.GRV_InvoiceNumber, GRV.GRV_InvoiceDate, GRV.GRV_InvoiceInclusive, Supplier.Supplier_GRVtype FROM (PurchaseOrder INNER JOIN GRV ON PurchaseOrder.PurchaseOrderID = GRV.GRV_PurchaseOrderID) INNER JOIN Supplier ON PurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID Where (((GRV.GRV_GRVStatusID)=3) AND ((Supplier.SupplierID) = " & CInt(lstSupplier.SelectedIndex) & ")) ORDER BY GRV.GRV_InvoiceDate DESC;")
	
		Me.lvItems.Items.Clear()
		Do Until rs.EOF
			If IsDbNull(rs.Fields("Supplier_GRVtype").Value) Then
				ltype = "normal"
			Else
				ltype = rs.Fields("Supplier_GRVtype").Value
				If ltype = "" Then ltype = "normal"
			End If
			lvItem = lvItems.Items.Add("K" & rs.Fields("GRVID").Value, rs.Fields("Supplier_Name").Value, "")

            If rs.Fields("GRV_GRVStatusID").Value <> 1 Then
                lvItem.Font = New Font(lvItem.Font, FontStyle.Bold)
            End If

            If lvItem.SubItems.Count > 0 Then
                lvItem.SubItems(0).Text = rs.Fields("GRV_InvoiceNumber").Value
            Else
                lvItem.SubItems.Insert(0, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("GRV_InvoiceNumber").Value))
            End If
            If lvItem.SubItems.Count > 1 Then
                lvItem.SubItems(1).Text = Format(rs.Fields("GRV_InvoiceDate").Value, "dd,mmm yyyy")
            Else
                lvItem.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Format(rs.Fields("GRV_InvoiceDate").Value, "dd,mmm yyyy")))
            End If
            If lvItem.SubItems.Count > 2 Then
                lvItem.SubItems(2).Text = FormatNumber(rs.Fields("GRV_InvoiceInclusive").Value, 2)
            Else
                lvItem.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("GRV_InvoiceInclusive").Value, 2)))
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
			'report_GRV  Mid(lvItems.SelectedItem.Key, 2)
			localGRVID = CInt(Mid(lvItems.FocusedItem.Name, 2))
			Me.Close()
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