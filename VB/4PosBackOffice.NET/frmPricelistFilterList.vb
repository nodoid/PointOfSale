Option Strict Off
Option Explicit On
Friend Class frmPricelistFilterList
	Inherits System.Windows.Forms.Form
	Dim gFilter As String
	Dim gRS As ADODB.Recordset
	Dim gFilterSQL As String
	Dim gID As Integer
	Dim gSection As Short
	
	Private Sub loadLanguage()
		
		'frmPricelistFilterList = No Code   [Select a Price List Group]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmPricelistFilterList.Caption = rsLang("LanguageLayoutLnk_Description"): frmPricelistFilterList.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1080 'Search|Checked
		If rsLang.RecordCount Then lbl.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lbl.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1065 'New|Checked
		If rsLang.RecordCount Then cmdNew.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdNew.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmPricelistFilterList.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Function getItem() As Integer
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
	
	Private Sub cmdNew_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNew.Click
		frmPricelistFilter.loadItem(0)
		doSearch()
	End Sub
	
	Private Sub DataList1_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DataList1.DoubleClick
		
		If cmdNew.Visible Then
			If DataList1.BoundText <> "" Then
				frmPricelistFilter.loadItem(CInt(DataList1.BoundText))
			End If
			doSearch()
		Else
			If DataList1.BoundText = "" Then
				gID = 0
			Else
				gID = CInt(DataList1.BoundText)
			End If
			Select Case gSection
				Case 0
					Me.Close()
				Case 1
					report_StockTake(CInt(DataList1.BoundText))
				Case 2
					frmStockTake.loadItem(CInt(DataList1.BoundText))
				Case 3
					report_StockQuantityData(CInt(DataList1.BoundText))
			End Select
		End If
	End Sub
	
    Private Sub DataList1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles DataList1.KeyPress
        Select Case eventArgs.KeyChar
            Case ChrW(13)
                DataList1_DblClick(DataList1, New System.EventArgs())
                eventArgs.KeyChar = ChrW(0)
            Case ChrW(27)
                Me.Close()
                eventArgs.KeyChar = ChrW(0)
        End Select

    End Sub
	Private Sub frmPricelistFilterList_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
		gSection = section
		If gSection Then cmdNew.Visible = False
		doSearch()
		
		loadLanguage()
		Me.ShowDialog()
	End Sub
	
	Private Sub frmPricelistFilterList_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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
		If lString = "" Then
		Else
			lString = "WHERE (Pricelist_Name LIKE '%" & Replace(lString, " ", "%' AND Pricelist_Name LIKE '%") & "%')"
		End If
		gRS = getRS("SELECT DISTINCT PricelistID, Pricelist_Name FROM PricelistFilter " & lString & " ORDER BY Pricelist_Name")
		'Display the list of Titles in the DataCombo
		DataList1.DataSource = gRS
		DataList1.listField = "Pricelist_Name"
		
		
		'Bind the DataCombo to the ADO Recordset
		'UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
		DataList1.DataSource = gRS
		DataList1.boundColumn = "PricelistID"
		
	End Sub
End Class