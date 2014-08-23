Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmOrderWizard
	Inherits System.Windows.Forms.Form
	Private Sub loadLanguage()
		
		'frmOrderWizard = No Code   [Stock Re-Order Wizard]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmOrderWizard.Caption = rsLang("LanguageLayoutLnk_Description"): frmOrderWizard.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_0 = No Code           [Day End Selection Criteria]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lbl_1 = No Code           [Applied Filter]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1 = No Code           [Affected Stock Items]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2138 'Build|Checked
		If rsLang.RecordCount Then cmdBuild.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdBuild.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1006 'Filter|Checked
		If rsLang.RecordCount Then cmdFilter.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdFilter.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2464 'Update|Checked
		If rsLang.RecordCount Then cmdUpdate.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdUpdate.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmOrderWizard.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub buildMinMax()
        Dim db As String
		
		Dim sql As String
		Dim rs As ADODB.Recordset
		Dim lConn As ADODB.Connection
		Dim rsData As ADODB.Recordset
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		cnnDB.Execute("DELETE MinMaxStockItemLnk.* FROM MinMaxStockItemLnk;")
		'    sql = "INSERT INTO MinMaxStockItemLnk (MinMaxStockItemLnk_MinMaxID, MinMaxStockItemLnk_StockItemID, MinMaxStockItemLnk_Minimum, MinMaxStockItemLnk_Maximum, MinMaxStockItemLnk_Disabled, MinMaxStockItemLnk_Average) SELECT TOP 100 PERCENT 1, StockItem.StockItemID, 0, 0, 0, 0 FROM MinMaxStockItemLnk RIGHT OUTER JOIN StockItem ON MinMaxStockItemLnk.MinMaxStockItemLnk_StockItemID = StockItem.StockItemID Where (MinMaxStockItemLnk.MinMaxStockItemLnk_StockItemID Is Null)"
		cnnDB.Execute("INSERT INTO MinMaxStockItemLnk ( MinMaxStockItemLnk_MinMaxID, MinMaxStockItemLnk_StockItemID, MinMaxStockItemLnk_Minimum, MinMaxStockItemLnk_Maximum, MinMaxStockItemLnk_Disabled, MinMaxStockItemLnk_Average ) SELECT 1, StockItem.StockItemID, 0, 0, 0, 0 FROM StockItem;")
		
		
		'    cnnDB.Execute "UPDATE MinMaxStockItemLnk SET MinMaxStockItemLnk.MinMaxStockItemLnk_Minimum = 0, MinMaxStockItemLnk.MinMaxStockItemLnk_Average = 0 WHERE (((MinMaxStockItemLnk.MinMaxStockItemLnk_MinMaxID)=1));"
		rs = getRS("SELECT DISTINCT Company.Company_MonthEndID, DayEnd.DayEnd_MonthEndID From dayEnd, Company WHERE (((DayEnd.DayEndID)>=" & frmOrderWizardFilter.gDayEndStart & " And (DayEnd.DayEndID)<=" & frmOrderWizardFilter.gDayEndEnd & "));")
		Do Until rs.EOF
			If rs.Fields("Company_MonthEndID").Value = rs.Fields("DayEnd_MonthEndID").Value Then
				db = "pricing.mdb"
			Else
				db = "month" & rs.Fields("DayEnd_MonthEndID").Value & ".mdb"
			End If
			lConn = openConnectionInstance(CStr(db))
			If lConn Is Nothing Then
			Else
				lConn.Execute("UPDATE DayEndStockItemLnk INNER JOIN MinMaxStockItemLnk ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = MinMaxStockItemLnk.MinMaxStockItemLnk_StockItemID SET MinMaxStockItemLnk.MinMaxStockItemLnk_Average = [MinMaxStockItemLnk_Average]+[DayEndStockItemLnk_QuantitySales] WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)>=" & frmOrderWizardFilter.gDayEndStart & " And (DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)<=" & frmOrderWizardFilter.gDayEndEnd & "));")
				lConn.Execute("UPDATE StockBreakTransaction INNER JOIN MinMaxStockItemLnk ON StockBreakTransaction.StockBreakTransaction_ParentID = MinMaxStockItemLnk.MinMaxStockItemLnk_StockItemID SET MinMaxStockItemLnk.MinMaxStockItemLnk_Average = [MinMaxStockItemLnk_Average]+[StockBreakTransaction_MoveQuantity] WHERE (((StockBreakTransaction.StockBreakTransaction_DayEndID)>=" & frmOrderWizardFilter.gDayEndStart & " And (StockBreakTransaction.StockBreakTransaction_DayEndID)<=" & frmOrderWizardFilter.gDayEndEnd & "));")
				lConn.Execute("UPDATE StockBreakTransaction INNER JOIN MinMaxStockItemLnk ON StockBreakTransaction.StockBreakTransaction_ChildID = MinMaxStockItemLnk.MinMaxStockItemLnk_StockItemID SET MinMaxStockItemLnk.MinMaxStockItemLnk_Average = [MinMaxStockItemLnk_Average]-([StockBreakTransaction_MoveQuantity]*[StockBreakTransaction_Quantity]) WHERE (((StockBreakTransaction.StockBreakTransaction_DayEndID)>=" & frmOrderWizardFilter.gDayEndStart & " And (StockBreakTransaction.StockBreakTransaction_DayEndID)<=" & frmOrderWizardFilter.gDayEndEnd & "));")
				
			End If
			rs.moveNext()
		Loop 
		cnnDB.Execute("UPDATE MinMaxStockItemLnk SET MinMaxStockItemLnk.MinMaxStockItemLnk_Average = [MinMaxStockItemLnk_Average]/" & CDbl(frmOrderWizardFilter.gDayEndEnd) - frmOrderWizardFilter.gDayEndStart + 1 & ";")
		cnnDB.Execute("UPDATE MinMaxStockItemLnk SET MinMaxStockItemLnk.MinMaxStockItemLnk_Minimum = [MinMaxStockItemLnk_Average]*" & frmOrderWizardFilter.txtDays.Text & ";")
		
		
		cnnDB.Execute("UPDATE MinMaxStockItemLnk INNER JOIN MinMax ON MinMaxStockItemLnk.MinMaxStockItemLnk_MinMaxID = MinMax.MinMaxID SET MinMaxStockItemLnk.MinMaxStockItemLnk_Minimum = [MinMax]![MinMax_Minimum] WHERE (((MinMaxStockItemLnk.MinMaxStockItemLnk_Minimum)<[MinMax]![MinMax_Minimum]));")
		cnnDB.Execute("DELETE StockItem.StockItem_Disabled, MinMaxStockItemLnk.* FROM MinMaxStockItemLnk INNER JOIN StockItem ON MinMaxStockItemLnk.MinMaxStockItemLnk_StockItemID = StockItem.StockItemID WHERE (((StockItem.StockItem_Disabled)<>0));")
		cnnDB.Execute("DELETE StockItem.StockItem_Disabled, MinMaxStockItemLnk.* FROM MinMaxStockItemLnk INNER JOIN StockItem ON MinMaxStockItemLnk.MinMaxStockItemLnk_StockItemID = StockItem.StockItemID WHERE (((StockItem.StockItem_Discontinued)<>0));")
		cnnDB.Execute("UPDATE MinMaxStockItemLnk INNER JOIN StockItem ON MinMaxStockItemLnk.MinMaxStockItemLnk_StockItemID = StockItem.StockItemID SET MinMaxStockItemLnk.MinMaxStockItemLnk_Disabled = 1 WHERE (((StockItem.StockItem_OrderDynamic)<>0));")
		cnnDB.Execute("UPDATE MinMaxStockItemLnk INNER JOIN StockItem ON MinMaxStockItemLnk.MinMaxStockItemLnk_StockItemID = StockItem.StockItemID SET MinMaxStockItemLnk.MinMaxStockItemLnk_Minimum = [StockItem]![StockItem_MinimumStock] WHERE (((MinMaxStockItemLnk.MinMaxStockItemLnk_Disabled)<>0));")
		
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
	End Sub
	
	Private Sub cmdBuild_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBuild.Click
		Dim sql As String
		sql = "DELETE FROM MinMaxStockItemLnk WHERE MinMaxStockItemLnk_MinMaxID = 1"
		cnnDB.Execute(sql)
		buildMinMax()
		sql = "UPDATE MinMaxStockItemLnk INNER JOIN StockItem ON MinMaxStockItemLnk.MinMaxStockItemLnk_StockItemID = StockItem.StockItemID SET MinMaxStockItemLnk.MinMaxStockItemLnk_Disabled = True WHERE (((MinMaxStockItemLnk.MinMaxStockItemLnk_MinMaxID)=1) AND ((StockItem.StockItem_OrderDynamic)=True));"
		cnnDB.Execute(sql)
		sql = "UPDATE MinMaxStockItemLnk INNER JOIN StockItem ON MinMaxStockItemLnk.MinMaxStockItemLnk_StockItemID = StockItem.StockItemID SET MinMaxStockItemLnk.MinMaxStockItemLnk_Disabled = True WHERE (((MinMaxStockItemLnk.MinMaxStockItemLnk_MinMaxID)=1) AND ((StockItem.StockItem_Disabled)=True));"
		cnnDB.Execute(sql)
		sql = "UPDATE MinMaxStockItemLnk INNER JOIN StockItem ON MinMaxStockItemLnk.MinMaxStockItemLnk_StockItemID = StockItem.StockItemID SET MinMaxStockItemLnk.MinMaxStockItemLnk_Disabled = True WHERE (((MinMaxStockItemLnk.MinMaxStockItemLnk_MinMaxID)=1) AND ((StockItem.StockItem_Discontinued)=True));"
		cnnDB.Execute(sql)
		GetData()
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	
	Private Sub cmdFilter_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFilter.Click
        Dim form As frmOrderWizardFilter
        form.Show()
		lblDayEnd.Text = frmOrderWizardFilter.lblDayEnd.Text
		lblFilter.Text = frmOrderWizardFilter.lblFilter.Text
		buildMinMax()
		GetData()
	End Sub
	
	Private Sub GetData()
		Dim sql As String
		Dim lFilter As String
		Dim rs As ADODB.Recordset
		Dim lvItem As System.Windows.Forms.ListViewItem
		sql = "SELECT TOP 100 PERCENT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_MinimumStock, StockItem.StockItem_OrderQuantity, StockItem.StockItem_OrderRounding, StockItem.StockItem_Quantity, StockItem.StockItem_ListCost, MinMaxStockItemLnk.MinMaxStockItemLnk_Minimum, MinMaxStockItemLnk.MinMaxStockItemLnk_Disabled, MinMaxStockItemLnk.MinMaxStockItemLnk_Average FROM MinMaxStockItemLnk INNER JOIN StockItem ON MinMaxStockItemLnk.MinMaxStockItemLnk_StockItemID = StockItem.StockItemID  "
		lFilter = frmOrderWizardFilter.gFilterSQL
		If lFilter = "" Then
			lFilter = " WHERE "
		Else
			lFilter = lFilter & " AND "
		End If
		lFilter = lFilter & "(MinMaxStockItemLnk.MinMaxStockItemLnk_MinMaxID = 1) AND (StockItem_Discontinued = 0) AND MinMaxStockItemLnk.MinMaxStockItemLnk_Disabled=0 "
		sql = sql & lFilter
		sql = sql & " ORDER BY StockItem.StockItem_Name"
		
		rs = getRS(sql)
		lvData.Items.Clear()
		Do Until rs.EOF
			lvItem = lvData.Items.Add("K" & rs.Fields("StockItemID").Value, rs.Fields("StockItem_Name").Value, "")
			lvItem.Checked = rs.Fields("MinMaxStockItemLnk_Disabled").Value
			If lvItem.SubItems.Count > 1 Then
				lvItem.SubItems(1).Text = FormatNumber(rs.Fields("StockItem_ListCost").Value, 2)
			Else
				lvItem.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("StockItem_ListCost").Value, 2)))
			End If
			If lvItem.SubItems.Count > 2 Then
				lvItem.SubItems(2).Text = rs.Fields("StockItem_Quantity").Value
			Else
				lvItem.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("StockItem_Quantity").Value))
			End If
			If lvItem.SubItems.Count > 3 Then
				lvItem.SubItems(3).Text = rs.Fields("StockItem_OrderRounding").Value & "x" & rs.Fields("StockItem_OrderQuantity").Value
			Else
				lvItem.SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("StockItem_OrderRounding").Value & "x" & rs.Fields("StockItem_OrderQuantity").Value))
			End If
			If lvItem.SubItems.Count > 4 Then
				lvItem.SubItems(4).Text = rs.Fields("StockItem_MinimumStock").Value
			Else
				lvItem.SubItems.Insert(4, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("StockItem_MinimumStock").Value))
			End If
			If lvItem.SubItems.Count > 5 Then
				lvItem.SubItems(5).Text = rs.Fields("MinMaxStockItemLnk_Minimum").Value
			Else
				lvItem.SubItems.Insert(5, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, rs.Fields("MinMaxStockItemLnk_Minimum").Value))
			End If
			If lvItem.SubItems.Count > 6 Then
				lvItem.SubItems(6).Text = FormatNumber(rs.Fields("MinMaxStockItemLnk_Average").Value, 4)
			Else
				lvItem.SubItems.Insert(6, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("MinMaxStockItemLnk_Average").Value, 4)))
			End If
			rs.moveNext()
		Loop 
	End Sub
	
	
	Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
		Dim sql As String
		Dim lKey As Integer
		Dim x As Integer
		Dim lFilter As String
		
		lFilter = frmOrderWizardFilter.gFilterSQL
		If lFilter = "" Then
			lFilter = " WHERE "
		Else
			lFilter = lFilter & " AND "
		End If
		lFilter = lFilter & "(MinMaxStockItemLnk.MinMaxStockItemLnk_MinMaxID = 1)"
		cnnDB.Execute("UPDATE StockItem INNER JOIN MinMaxStockItemLnk ON StockItem.StockItemID = MinMaxStockItemLnk.MinMaxStockItemLnk_StockItemID SET StockItem.StockItem_MinimumStock = [MinMaxStockItemLnk]![MinMaxStockItemLnk_Minimum] " & lFilter & ";")
		Me.Close()
	End Sub
	
	Private Sub frmOrderWizard_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub frmOrderWizard_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim lvHeader As System.Windows.Forms.ColumnHeader
        'Load(frmOrderWizardFilter)
		lblDayEnd.Text = frmOrderWizardFilter.lblDayEnd.Text
		lblFilter.Text = frmOrderWizardFilter.lblFilter.Text
        lvData.Columns.Add("Name", CInt(twipsToPixels(2000, True)), System.Windows.Forms.HorizontalAlignment.Left)
        lvData.Columns.Add("Cost", CInt(twipsToPixels(900, True)), System.Windows.Forms.HorizontalAlignment.Right)
        lvData.Columns.Add("X", CInt(twipsToPixels(500, True)), System.Windows.Forms.HorizontalAlignment.Right)
        lvData.Columns.Add("Order", CInt(twipsToPixels(900, True)), System.Windows.Forms.HorizontalAlignment.Right)
        lvData.Columns.Add("Orginal", CInt(twipsToPixels(900, True)), System.Windows.Forms.HorizontalAlignment.Right)
        lvData.Columns.Add("New", CInt(twipsToPixels(900, True)), System.Windows.Forms.HorizontalAlignment.Right)
        lvData.Columns.Add("Average", CInt(twipsToPixels(1000, True)), System.Windows.Forms.HorizontalAlignment.Right)
		
		loadLanguage()
		
		GetData()
	End Sub
	
	Private Sub frmOrderWizard_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		Dim x As Short
		Dim lWidth As Integer
		For x = 2 To lvData.Columns.Count
			lWidth = lWidth + pixelToTwips(lvData.Columns.Item(x).Width, True)
		Next 
		lvData.Columns.Item(1).Width = twipsToPixels(pixelToTwips(lvData.Width, True) - lWidth - 320, True)
	End Sub
	
	Private Sub frmOrderWizard_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		frmOrderWizardFilter.Close()
	End Sub
	
	Private Sub lvData_ItemCheck(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ItemCheckEventArgs) Handles lvData.ItemCheck
		Dim Item As System.Windows.Forms.ListViewItem = lvData.Items(eventArgs.Index)
		Dim sql As String
		Dim lKey As Integer
		lKey = CInt(Mid(Item.Name, 2))
		
		sql = "UPDATE MinMaxStockItemLnk SET MinMaxStockItemLnk_Disabled = " & CShort(Item.Checked) & " Where (MinMaxStockItemLnk_MinMaxID = 1) And (MinMaxStockItemLnk_StockItemID = " & lKey & ")"
		cnnDB.Execute(sql)
	End Sub
	
	Private Sub lvData_ItemClick(ByVal Item As System.Windows.Forms.ListViewItem)
		Dim sql As String
		Dim lKey As Integer
		lKey = CInt(Mid(Item.Name, 2))
		
		'UPGRADE_WARNING: Lower bound of collection Item has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		Me.Tag = lKey & "|" & Item.Text & "|" & Item.SubItems(1).Text & "|" & Split(Item.SubItems(3).Text, "x")(0) & "|" & Item.SubItems(4).Text
		If lKey > 0 Then 
		Else 
			Exit Sub
		End If
		frmOrderItemQuick.ShowDialog()
		
		GetData()
	End Sub
End Class