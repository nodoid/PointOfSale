Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmExportProductPerfomace
    Inherits System.Windows.Forms.Form

    Dim WithEvents optType As New List(Of RadioButton)
	Private Sub loadLanguage()
		
		'NOTE: Caption has a spelling mistake!!!
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2469 'Export Product Performance
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2471 'Export Options|Checked
        If rsLang.RecordCount Then _Frame1_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _Frame1_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2152 'Normal Item Listing|Checked
        If rsLang.RecordCount Then _optType_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _optType_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2153 'Items Per Group|Checked
        If rsLang.RecordCount Then _optType_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _optType_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2154 'Group Totals|Checked
        If rsLang.RecordCount Then _optType_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _optType_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1173 'Group On|Checked
		If rsLang.RecordCount Then _lbl_3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2477 'Export Sort Options|Checked
        If rsLang.RecordCount Then _Frame1_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _Frame1_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2158 'Sort Field|Checked
		If rsLang.RecordCount Then _lbl_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2159 'Sort Order|Checked
		If rsLang.RecordCount Then _lbl_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2480 'Export Filter|Checked
        If rsLang.RecordCount Then _Frame1_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _Frame1_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1006 'Filter|Checked
		If rsLang.RecordCount Then cmdGroup.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdGroup.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2483 'Export Now|Checked
		If rsLang.RecordCount Then cmdLoad.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdLoad.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmExportProductPerfomace.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	Private Sub cmdGroup_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGroup.Click
		Dim rs As ADODB.Recordset
		Dim lID As Integer
		cnnDBreport.Execute("DELETE aftDataItem.* From aftDataItem WHERE (((aftDataItem.ftDataItem_PersonID)=" & gPersonID & "));")
		
		cnnDBreport.Execute("DELETE aftData.* From aftData WHERE (((aftData.ftData_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("INSERT INTO aftData ( ftData_PersonID, ftData_FieldName, ftData_SQL, ftData_Heading ) SELECT LinkData.LinkData_PersonID, LinkData.LinkData_FieldName, LinkData.LinkData_SQL, LinkData.LinkData_Heading From LinkData WHERE (((LinkData.LinkData_LinkID)=2) AND ((LinkData.LinkData_SectionID)=1) AND ((LinkData.LinkData_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("INSERT INTO aftDataItem ( ftDataItem_PersonID, ftDataItem_FieldName, ftDataItem_ID ) SELECT LinkDataItem.LinkDataItem_PersonID, LinkDataItem.LinkDataItem_FieldName, LinkDataItem.LinkDataItem_ID From LinkDataItem WHERE (((LinkDataItem.LinkDataItem_LinkID)=2) AND ((LinkDataItem.LinkDataItem_SectionID)=1) AND ((LinkDataItem.LinkDataItem_PersonID)=" & gPersonID & "));")
		frmFilter.Close()
		frmFilter.buildCriteria("Sale")
		frmFilter.loadFilter("Sale")
		frmFilter.buildCriteria("Sale")
		
		cnnDBreport.Execute("UPDATE Link SET Link.Link_Name = '" & Replace(frmFilter.gHeading, "'", "''") & "', Link.Link_SQL = '" & Replace(frmFilter.gCriteria, "'", "''") & "' WHERE (((Link.LinkID)=2) AND ((Link.Link_SectionID)=1) AND ((Link.Link_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("DELETE LinkDataItem.* From LinkDataItem WHERE (((LinkDataItem.LinkDataItem_LinkID)=2) AND ((LinkDataItem.LinkDataItem_SectionID)=1) AND ((LinkDataItem.LinkDataItem_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("DELETE LinkData.* From LinkData WHERE (((LinkData.LinkData_LinkID)=2) AND ((LinkData.LinkData_SectionID)=1) AND ((LinkData.LinkData_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("INSERT INTO LinkData ( LinkData_LinkID, LinkData_SectionID, LinkData_PersonID, LinkData_FieldName, LinkData_SQL, LinkData_Heading ) SELECT 2, 1, aftData.ftData_PersonID, aftData.ftData_FieldName, aftData.ftData_SQL, aftData.ftData_Heading From aftData WHERE (((aftData.ftData_PersonID)=" & gPersonID & "));")
		cnnDBreport.Execute("INSERT INTO LinkDataItem ( LinkDataItem_LinkID, LinkDataItem_SectionID, LinkDataItem_PersonID, LinkDataItem_FieldName, LinkDataItem_ID ) SELECT 2, 1, aftDataItem.ftDataItem_PersonID, aftDataItem.ftDataItem_FieldName, aftDataItem.ftDataItem_ID From aftDataItem WHERE (((aftDataItem.ftDataItem_PersonID)=" & gPersonID & "));")
		lblGroup.Text = frmFilter.gHeading
	End Sub
	Private Sub setup()
		Dim rs As ADODB.Recordset
		rs = getRSreport("SELECT Link.Link_PersonID From Link WHERE (((Link.Link_PersonID)=" & gPersonID & "));")
		If rs.BOF Or rs.EOF Then
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 1, 1, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 2, 1, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 1, 2, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 2, 2, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 1, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 2, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 3, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 4, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 5, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 6, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 7, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 8, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 9, 3, " & gPersonID & ", '', '';")
			cnnDBreport.Execute("INSERT INTO link ( LinkID, Link_SectionID, Link_PersonID, Link_Name, Link_SQL ) SELECT 10, 3, " & gPersonID & ", '', '';")
		End If
		
		rs = getRSreport("SELECT Link.Link_Name From Link WHERE (((Link.LinkID)=2) AND ((Link.Link_SectionID)=1) AND ((Link.Link_PersonID)=" & gPersonID & "));")
		lblGroup.Text = rs.Fields("Link_Name").Value
	End Sub
	Private Sub cmdLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLoad.Click
        Dim dbText As String
		Dim sql As String
		Dim stFileName As String
		Dim lOrder As String
		Dim rs As ADODB.Recordset
		Dim rsData As ADODB.Recordset
		
		
		'Exporting file...
		Dim lne As String
		Dim n As Short
		Dim fso As New Scripting.FileSystemObject
		
		Select Case Me.cmbSortField.SelectedIndex
			Case 0
				lOrder = "StockItem_Name"
			Case 1
				lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
			Case 2
				lOrder = "[exclusiveSum]-[depositSum]"
			Case 3
				lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
			Case 4
				lOrder = "IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum])"
			Case 5
				lOrder = "StockList.quantitySum"
				
		End Select
		
		If Me.cmbSort.SelectedIndex Then lOrder = lOrder & " DESC"
		lOrder = " ORDER BY " & lOrder
		
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		rs = getRSreport("SELECT * FROM Link Where LinkID=2 AND Link_SectionID=1")
		
        If _optType_0.Checked Then
            sql = "SELECT aStockItem.StockItemID, aStockItem.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem INNER JOIN aStockGroup ON aStockItem.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem.StockItemID "
        Else
            sql = "SELECT aStockItem.StockItemID, aStockItem.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem INNER JOIN aStockGroup ON aStockItem.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem.StockItemID "
            Select Case Me.cmbGroup.SelectedIndex
                Case 0
                    sql = Replace(sql, "StockGroup", "PricingGroup")
                    'Report.txtTitle.SetText "Product Performance - by Pricing Group"
                Case 1
                    'Report.txtTitle.SetText "Product Performance - by Stock Group"
                Case 2
                    sql = Replace(sql, "StockGroup", "Supplier")
                    sql = Replace(sql, "aSupplier", "Supplier")
                    'Report.txtTitle.SetText "Product Performance - by Supplier"
            End Select
        End If
		
		If rs.Fields("Link_SQL").Value = "" Then
		Else
			sql = sql & rs.Fields("Link_SQL").Value
		End If
		
		sql = sql & lOrder
		
		Dim ptbl As String
		Dim t_day As String
		Dim t_Mon As String
		
		If Len(Trim(Str(VB.Day(Today)))) = 1 Then t_day = "0" & Trim(CStr(VB.Day(Today))) Else t_day = CStr(VB.Day(Today))
		If Len(Trim(Str(Month(Today)))) = 1 Then t_Mon = "0" & Trim(CStr(Month(Today))) Else t_Mon = Str(Month(Today))
		
		ptbl = serverPath & "4POSProd" & Trim(CStr(Year(Today))) & Trim(t_Mon) & Trim(t_day)
		
		If fso.FileExists(ptbl & ".csv") Then fso.DeleteFile((ptbl & ".csv"))
		
		FileOpen(1, ptbl & ".csv", OpenMode.Output)
		'Open serverPath & "ProductPerformace.csv" For Output As #1
		
		rs = getRSreport(sql)
		'Write Out CSV
		If rs.BOF Or rs.EOF Then
			MsgBox("There are no recods to export, Try Changing Day End date range", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "Export Product Performance")
            System.Windows.Forms.Cursor.Current = Cursors.Default
			Exit Sub
		Else
			For n = 0 To rs.Fields.Count - 1 'First line as column headings
				lne = lne & Chr(34) & rs.Fields(n).Name & Chr(34) & ","
			Next n
			
			PrintLine(1, lne)
			
			Do While Not rs.EOF
				lne = ""
				For n = 0 To rs.Fields.Count - 1
					
					If rs.Fields(n).Type = dbText Then
						lne = lne & Chr(34) & rs.Fields(n).Value & Chr(34) & ","
					Else
						lne = lne & rs.Fields(n).Value & ","
					End If
				Next n
				lne = VB.Left(lne, Len(lne) - 1) 'get rid of last comma
				PrintLine(1, lne)
				rs.moveNext()
			Loop 
			
			FileClose(1)
			MsgBox("Product performance CSV File, was successfully exported to : " & ptbl & ".csv")
		End If
        System.Windows.Forms.Cursor.Current = Cursors.Default
		
		
	End Sub
    Private Sub frmExportProductPerfomace_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	Private Sub frmExportProductPerfomace_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        optType.AddRange(New RadioButton() {_optType_0, _optType_1, _optType_2})
        loadLanguage()
		setup()
		Me.cmbGroup.SelectedIndex = 0
		Me.cmbSort.SelectedIndex = 0
		Me.cmbSortField.SelectedIndex = 0
	End Sub
	
    Private Sub optType_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles optType.CheckedChanged
        If eventSender.Checked Then
            Dim opt As New RadioButton
            opt = DirectCast(eventSender, RadioButton)
            Dim Index As Integer = GetIndexer(opt, optType)
            If Index Then
                cmbGroup.Enabled = True
            Else
                cmbGroup.Enabled = False
            End If
            Me.chkPageBreak.Enabled = (Index = 1)
        End If
    End Sub
End Class