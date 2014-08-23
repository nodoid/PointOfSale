Option Strict Off
Option Explicit On
Friend Class frmStockList2
	Inherits System.Windows.Forms.Form
	Dim gFilter As String
	Dim gRS As ADODB.Recordset
	Dim gFilterSQL As String
	Dim gSection As Short
	Dim gID As Integer
	Dim gAll As Boolean
	
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2113 'Select a Stock Item|Checked
		If rsLang.RecordCount Then frmStockList.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : frmStockList.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1080 'Search|Checked
		If rsLang.RecordCount Then lbl.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1006 'Filter|Checked
		If rsLang.RecordCount Then cmdNamespace.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdNamespace.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lblHeading = No Code   [Using the "Stock Item Selector"...]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblHeading.Caption = rsLang("LanguageLayoutLnk_Description"): lblHeading.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmStockList2.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub getNamespace()
		If gFilter = "" Then
			Me.lblHeading.Text = ""
		Else
			frmFilter.buildCriteria(gFilter)
			Me.lblHeading.Text = frmFilter.gHeading
		End If
		gFilterSQL = frmFilter.gCriteria
		doSearch()
	End Sub
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	
	Private Sub cmdNamespace_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNamespace.Click
		frmFilter.loadFilter(gFilter)
		getNamespace()
	End Sub
	
    Private Sub DataList1_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles DataList1.DoubleClick
        On Error Resume Next
        If DataList1.BoundText = "" Then Exit Sub
        Dim lID As Integer
        lID = CInt(DataList1.BoundText)
        Select Case gSection
            Case -1
                gID = CInt(DataList1.BoundText)
                Me.Close()
            Case 0
                frmStockItem.loadItem(CInt(DataList1.BoundText))
                Dim formItem As frmStockItem
                formItem.Show()
            Case 1
                frmStockPricing.loadItem(CInt(DataList1.BoundText))
                Dim formPrice As frmStockPricing
                formPrice.Show()
            Case 2
                report_StockQuantity(CInt(DataList1.BoundText))
        End Select
        gRS.Requery()
        'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        DataList1.CtlRefresh()
    End Sub
	
    Private Sub DataList1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles DataList1.KeyPress
        Select Case eventArgs.KeyChar
            Case ChrW(13)
                DataList1_DblClick(DataList1, New System.EventArgs())
                eventArgs.KeyChar = ChrW(0)
        End Select
    End Sub
	
	Public Function getItem() As Integer
		editItem(-1)
		
		loadLanguage()
		ShowDialog()
		getItem = gID
	End Function
	Public Sub editItem(ByRef lSection As Short)
		gSection = lSection
		gFilter = "StockItem"
		getNamespace()
	End Sub
	
	
	Private Sub frmStockList2_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KeyCode = 36 Then
			gAll = Not gAll
			doSearch()
			KeyCode = False
		End If
	End Sub
	
	Private Sub frmStockList2_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.Escape
				Me.Close()
				KeyAscii = 0
		End Select
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub frmStockList2_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		On Error Resume Next
		gRS.Close()
		
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
				Me.DataList1.Focus()
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
		lString = Trim(txtSearch.Text)
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		
		If Trim(txtSearch.Text) = "" Then
			lString = gFilterSQL
		Else
			lString = "(StockItem_Name LIKE '%" & Replace(lString, " ", "%' AND StockItem_Name LIKE '%") & "%')"
			If gFilterSQL = "" Then
				lString = " WHERE " & lString
			Else
				lString = gFilterSQL & " AND " & lString
			End If
		End If
		If gAll Then
		Else
			If lString = "" Then
				lString = " WHERE StockItem.StockItem_Disabled = 0 Or StockItem.StockItem_Discontinued = 0 "
			Else
				lString = lString & " AND (StockItem.StockItem_Disabled = 0 Or StockItem.StockItem_Discontinued = 0) "
			End If
		End If
		gRS = getRS("SELECT DISTINCT StockItemID, StockItem_Name FROM StockItem " & lString & " ORDER BY StockItem_Name")
		If gRS.RecordCount Then
		Else
			If Trim(txtSearch.Text) = "" Then
			Else
				If IsNumeric(txtSearch.Text) Then
					lString = Trim(txtSearch.Text)
					lString = Replace(lString, "  ", " ")
					lString = Replace(lString, "  ", " ")
					lString = Replace(lString, "  ", " ")
					lString = Replace(lString, "  ", " ")
					lString = Replace(lString, "  ", " ")
					lString = Replace(lString, "  ", " ")
					lString = "WHERE (Catalogue_Barcode LIKE '%" & Replace(lString, " ", "%' AND StockItem_Name LIKE '%") & "%')"
					If gAll Then
					Else
						lString = lString & " AND StockItem.StockItem_Disabled = 0 And StockItem.StockItem_Discontinued = 0 "
					End If
					
					gRS = getRS("SELECT DISTINCT StockItem.StockItemID, StockItem.StockItem_Name FROM Catalogue INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID " & lString & " ORDER BY StockItem.StockItem_Name;")
				End If
			End If
		End If
		'Display the list of Titles in the DataCombo
        DataList1.DataSource = gRS
		DataList1.listField = "StockItem_Name"
		
		
		'Bind the DataCombo to the ADO Recordset
		'UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
		DataList1.DataSource = gRS
		DataList1.boundColumn = "StockItemID"
		
	End Sub
End Class