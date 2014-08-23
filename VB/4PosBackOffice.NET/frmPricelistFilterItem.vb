Option Strict Off
Option Explicit On
Friend Class frmPricelistFilterItem
	Inherits System.Windows.Forms.Form
    Dim gID As Integer
    Dim cmdClick As New List(Of Button)
    Dim dataArray(,) As Integer
	
	Private Sub loadLanguage()
		
		'frmPricelistFilterItem = No Code [Allocate Stock Items to Pricelist]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmPricelistFilterItem.Caption = rsLang("LanguageLayoutLnk_Description"): frmPricelistFilterItem.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblHeading = No Code/Dynamic!
		
		'TOOLBAR CODE NOT DONE!!!
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1080 'Search|Checked
		If rsLang.RecordCount Then _lbl_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmPricelistFilterItem.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
    Private Sub cmdClick_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'Dim Index As Short = cmdClick.GetIndex(eventSender)
        Dim Index As Integer
        Dim n As New Button
        n = DirectCast(eventSender, Button)
        Index = GetIndexer(n, cmdClick)
        tbStockItem_ButtonClick(Me.tbStockItem.Items.Item(Index), New System.EventArgs())
        lstStockItem.Focus()
    End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	
	Public Sub loadItem(ByRef id As Integer)
        Dim x As Short
		Dim rs As ADODB.Recordset
		gID = id
		rs = getRS("SELECT Pricelist_Name FROM PricelistFilter WHERE PricelistID = " & gID)
		If rs.BOF Or rs.EOF Then
		Else
			lblHeading.Text = rs.Fields("Pricelist_Name").Value
			rs = getRS("SELECT TOP 100 PERCENT StockItem.StockItemID, StockItem.StockItem_Name FROM StockItem ORDER BY StockItem_Name;")
            ReDim dataArray(rs.RecordCount, 2)
			x = -1
			Do Until rs.EOF
				x = x + 1
				dataArray(x, 0) = rs.Fields("StockItemID").Value
				'UPGRADE_WARNING: Couldn't resolve default property of object x. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object dataArray(x, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				dataArray(x, 1) = rs.Fields("StockItem_Name").Value
				dataArray(x, 2) = False
				rs.moveNext()
			Loop 
			
			
			rs = getRS("SELECT PricelistFilterStockItemLnk.PricelistStockItemLnk_StockItemID From PricelistFilterStockItemLnk WHERE (((PricelistFilterStockItemLnk.PricelistStockItemLnk_PricelistID)=" & gID & "));")
			Do Until rs.EOF
				For x = LBound(dataArray) To UBound(dataArray)
					If dataArray(x, 0) = rs.Fields("PricelistStockItemLnk_StockItemID").Value Then
						dataArray(x, 2) = True
					End If
				Next x
				rs.moveNext()
			Loop 
			
			doLoad()
			
			loadLanguage()
			ShowDialog()
		End If
	End Sub
	
	Private Sub doLoad()
        Dim x As Short
        Dim loading As Boolean
        Dim tmpString As String
		loading = True
		lstStockItem.Visible = False
        Me.lstStockItem.Items.Clear()
        Dim m As Integer
		Select Case Me.tbStockItem.Tag
			Case CStr(1)
				For x = 0 To UBound(dataArray) - 1
					If dataArray(x, 2) Then
                        If InStr(UCase(dataArray(x, 1)), UCase(Me.txtSearch.Text)) Then
                            tmpString = dataArray(x, 1) & " " & x.ToString
                            m = lstStockItem.Items.Add(tmpString)
                            lstStockItem.SetItemChecked(m, dataArray(x, 2))
                        End If
					End If
				Next 
				
			Case CStr(2)
				For x = 0 To UBound(dataArray) - 1
					If dataArray(x, 2) Then
					Else
						If InStr(UCase(dataArray(x, 1)), UCase(Me.txtSearch.Text)) Then
                            tmpString = dataArray(x, 1) & " " & x.ToString
                            m = lstStockItem.Items.Add(tmpString)
                            lstStockItem.SetItemChecked(m, dataArray(x, 2))
						End If
					End If
				Next 
			Case Else
				For x = 0 To UBound(dataArray) - 1
					If InStr(UCase(dataArray(x, 1)), UCase(Me.txtSearch.Text)) Then
                        tmpString = dataArray(x, 1) & " " & x.ToString
                        m = lstStockItem.Items.Add(tmpString)
                        lstStockItem.SetItemChecked(m, dataArray(x, 2))
					End If
				Next 
		End Select
		If lstStockItem.SelectedIndex Then lstStockItem.SelectedIndex = 0
		lstStockItem.Visible = True
		loading = False
		
	End Sub
	
	Private Sub frmPricelistFilterItem_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub lstStockItem_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstStockItem.SelectedIndexChanged
        Dim loading As Boolean
		Dim sql As String
		If loading Then Exit Sub
		Dim x As Short
        x = CLng(lstStockItem.SelectedIndex)
		If lstStockItem.SelectedIndex <> -1 Then
			dataArray(x, 2) = CShort(lstStockItem.GetItemChecked(lstStockItem.SelectedIndex))
			sql = "DELETE PricelistFilterStockItemLnk.* From PricelistFilterStockItemLnk WHERE (((PricelistFilterStockItemLnk.PricelistStockitemLnk_PricelistID)=" & gID & ") AND ((PricelistFilterStockItemLnk.PricelistStockitemLnk_StockitemID)=" & dataArray(x, 0) & "));"
			
			cnnDB.Execute(sql)
			
			If dataArray(x, 2) Then
				sql = "INSERT INTO PricelistFilterStockItemLnk ( PricelistStockitemLnk_PricelistID, PricelistStockitemLnk_StockitemID ) SELECT " & gID & " AS pricelist, " & dataArray(x, 0) & " AS stock;"
				
				cnnDB.Execute(sql)
			End If
		End If
	End Sub
	
	Private Sub tbStockItem_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _tbStockItem_Button1.Click, _tbStockItem_Button2.Click, _tbStockItem_Button3.Click
        Dim Button As System.Windows.Forms.ToolStrip = CType(eventSender, System.Windows.Forms.ToolStrip)
		Dim x As Short
        For x = 0 To tbStockItem.Items.Count
            CType(tbStockItem.Items.Item(x), ToolStripButton).Checked = False
        Next
        tbStockItem.Tag = Button.Items.IndexOf(Button.Tag) - 1
		'    buildDepartment
        'Button.Checked = True
		doLoad()
	End Sub
	
	Private Sub txtSearch_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KeyCode = 40 Then
			Me.lstStockItem.Focus()
			KeyCode = 0
		End If
	End Sub
	
	Private Sub txtSearch_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case KeyAscii
			Case 13
				doLoad()
				KeyAscii = 0
		End Select
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub

    Private Sub frmPricelistFilterItem_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        cmdClick.AddRange(New Button() {_cmdClick_1, _cmdClick_2, _cmdClick_3})
        Dim bt As New Button
        For Each bt In cmdClick
            AddHandler bt.Click, AddressOf cmdClick_Click
        Next
    End Sub
End Class