Option Strict Off
Option Explicit On
Friend Class frmBarcodeStockitem
	Inherits System.Windows.Forms.Form
	Dim gRS As ADODB.Recordset
	Dim gCancel As Boolean
	Dim gOrder As String
    Dim txtSearch As New List(Of TextBox)
	Dim loadCSV As Boolean
	
	Private Sub loadLanguage()
        'frmBarcodeStockItem = No Code  [Select Products for Barcode Printing]
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then frmBarcodeStockItem.Caption = rsLang("LanguageLayoutLnk_Description"): frmBarcodeStockItem.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

        'cmdLoad = No Code              [Load Qty from CSV file]
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then cmdLoad.Caption = rsLang("LanguageLayoutLnk_Description"): cmdLoad.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

        'cmdShow = No Code              [Show Changed Price Items Or Selected Products]
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then cmdshow.Caption = rsLang("LanguageLayoutLnk_Description"): cmdshow.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

        'cmdClear = No Code             [Clear All Selected Products]
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then cmdClear.Caption = rsLang("LanguageLayoutLnk_Description"): cmdClear.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

        'Command1 = No Code             [Show Only with Single Qty]
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then Command1.Caption = rsLang("LanguageLayoutLnk_Description"): Command1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1085 'Print|Checked
        If rsLang.RecordCount Then cmdPrint.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrint.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsLang.Filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
        If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value

        rsHelp.Filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
        'UPGRADE_ISSUE: Form property frmBarcodeStockitem.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value

    End Sub
	
	Public Function loadStock() As Boolean
		Dim fso As New Scripting.FileSystemObject
		If grvPrin Then
			If fso.FileExists(serverPath & "Shelfbarcode.dat") Then
			Else
				MsgBox("File " & serverPath & "Shelfbarcode.dat not found", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OKOnly + MsgBoxStyle.Information, My.Application.Info.Title)
				Me.Close()
				Exit Function
			End If
			'show 1
			'loadStock = gCancel
		End If
		
		loadLanguage()
		ShowDialog()
		loadStock = gCancel
		
	End Function
	Private Sub cmdClear_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClear.Click
		cnnDB.Execute("DELETE barcodePersonLnk.* From barcodePersonLnk WHERE (((barcodePersonLnk.barcodePersonLnk_PersonID)=" & gPersonID & "));")
		cnnDB.Execute("INSERT INTO barcodePersonLnk ( barcodePersonLnk_PersonID, barcodePersonLnk_StockItemID, barcodePersonLnk_Shrink, barcodePersonLnk_PrintQTY ) SELECT " & gPersonID & ", Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, 0 FROM Catalogue;")
		doRS()
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		gridEdit_LeaveCell(gridEdit, New System.EventArgs())
		gCancel = False
		Me.Close()
	End Sub
	
	Public Function ImportCSVinArray(ByRef sFileName As String, Optional ByRef sDelimiter As String = ",") As String()
		
        Dim MyArray(,) As String
		Dim sSplit() As String
		Dim sLine As String
		Dim lRows As Integer
		Dim lColumns As Integer
        Dim lCounter As Integer
        Dim Empty(,) As String = New String(,) {{"", ""}}
		
		On Error GoTo ErrHandler_ImportCSVinArray
		
		If Dir(sFileName) <> "" Then
            'determine number of rows and columns needed
            lRows = 0
            lColumns = 0
            FileOpen(7, sFileName, OpenMode.Input)
            While Not (EOF(7))
                sLine = LineInput(7)
                If Len(sLine) > 0 Then
                    sSplit = Split(sLine, sDelimiter)
                    If UBound(sSplit) > lColumns Then lColumns = UBound(sSplit)
                    lRows = lRows + 1
                End If
            End While
            FileClose(7)


            'fill array
            'If lColumns = 1 Then 'no csv file!
            '  ReDim MyArray(lRows - 1)
            '  Open sFileName For Input As #7
            '  lRows = 0
            '  While Not (EOF(7))
            '    Line Input #7, sLine
            '    If Len(sLine) > 0 Then
            '      MyArray(lRows) = Val(sLine)
            '      lRows = lRows + 1
            '    End If
            '  Wend
            '  Close #7

            'ElseIf lColumns > 1 Then 'multidimensional csv file
            ReDim MyArray(lRows - 1, lColumns)

            FileOpen(7, sFileName, OpenMode.Input)
            lRows = 0
            While Not (EOF(7))
                sLine = LineInput(7)
                If Len(sLine) > 0 Then
                    sSplit = Split(sLine, sDelimiter)
                    For lCounter = 0 To UBound(sSplit)
                        MyArray(lRows, lCounter) = CStr(Val(sSplit(lCounter)))
                    Next lCounter
                    lRows = lRows + 1
                End If
            End While
            FileClose(7)

            'End If

            'return function
            ImportCSVinArray = MyArray.Clone()
        End If
		Exit Function
ErrHandler_ImportCSVinArray:
        'ImportCSVinArray(, ) = Empty
	End Function
	
	Private Sub cmdLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLoad.Click
        Dim sql As String
        Dim rs As ADODB.Recordset
        Dim arrloadCSV() As String
		Dim strname As String
		
		On Error GoTo errL
		
		With cmdDlgOpen
            .Filter = "Data File (*.csv)|*.csv"
            .Title = "Open a file..."
            .ShowDialog()
        End With
		strname = cmdDlgOpen.FileName
		If strname = "" Then Exit Sub
		
		arrloadCSV = ImportCSVinArray(strname)
		'loadCSV = True
		'asdf = arrloadCSV(0, 1)
		Dim x, y As Integer
		'On Local Error Resume Next
		x = 1
		With gridEdit
			.Visible = False
			.RowCount = gRS.RecordCount + 1
			gCancel = False
			gRS.MoveFirst()
			Do Until gRS.EOF
				gridEdit.set_TextMatrix(x, 0, gRS.Fields("Catalogue_Barcode").Value)
				gridEdit.set_TextMatrix(x, 1, gRS.Fields("StockItemID").Value)
				gridEdit.set_TextMatrix(x, 2, " " & gRS.Fields("Catalogue_Quantity").Value & "x" & gRS.Fields("StockItem_Name").Value)
				gridEdit.set_TextMatrix(x, 3, " " & gRS.Fields("Supplier_Name").Value)
				gridEdit.set_TextMatrix(x, 4, " " & gRS.Fields("PricingGroup_Name").Value)
				
				Dim lRows As Integer = 0
				Dim lColumns As Integer = 0
                For lRows = 0 To UBound(arrloadCSV)
                    If arrloadCSV(lRows) = gRS.Fields("Catalogue_Barcode").Value Then lColumns = arrloadCSV(lRows)
                Next
				
				If lColumns = 0 Then
                    gridEdit.set_TextMatrix(x, 5, gRS.Fields("barcodePersonLnk_PrintQTY").Value)
                Else
                    gridEdit.set_TextMatrix(x, 5, lColumns)

                    If rs.State Then rs.Close()
                    sql = "SELECT Catalogue_Quantity FROM Catalogue WHERE Catalogue_StockItemID = " & gRS.Fields("StockItemID").Value & " AND Catalogue_Barcode = '" & Trim(gRS.Fields("Catalogue_Barcode").Value) & "'"
                    rs = getRS(sql)
                    sql = "UPDATE barcodePersonLnk SET barcodePersonLnk.barcodePersonLnk_PrintQTY = " _
                    & lColumns & " WHERE (((barcodePersonLnk.barcodePersonLnk_PersonID)=" & gPersonID _
                    & ") AND ((barcodePersonLnk.barcodePersonLnk_StockItemID)=" _
                    & gRS.Fields("StockItemID").Value & ") AND ((barcodePersonLnk.barcodePersonLnk_Shrink)= " _
                    & rs("Catalogue_Quantity").Value & "));"
                    cnnDB.Execute(sql)
                End If
				
				x = x + 1
				If x Mod 10 Then
				Else
					System.Windows.Forms.Application.DoEvents()
					If gCancel Then Exit Do
				End If
				gRS.moveNext()
			Loop 
			.RowCount = x
			.Visible = True
		End With
		
		'loadCSV = False
		
		Exit Sub
errL: 
		Resume Next
	End Sub
	
	Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
		gridEdit_LeaveCell(gridEdit, New System.EventArgs())
		gCancel = True
		Me.Close()
	End Sub
	Private Sub cmdShow_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdShow.Click
		doRS(True)
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		cnnDB.Execute("UPDATE barcodePersonLnk SET barcodePersonLnk.barcodePersonLnk_PrintQTY = 0 WHERE ((barcodePersonLnk.barcodePersonLnk_PersonID)=" & gPersonID & ") AND ((barcodePersonLnk.barcodePersonLnk_Shrink) > 1);")
		'doRS
		doRSSingle(True)
		
	End Sub
	
	Private Sub frmBarcodeStockitem_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim KeyAscii As Short = Asc(eventArgs.KeyCode)

		If KeyAscii = 27 And Shift = 2 Then gCancel = True
		
	End Sub
	Private Sub frmBarcodeStockitem_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim x As Integer
        Dim lOrder As String
        Dim sql As String
		Dim stSring As String
		Dim rsPrinter_B As New ADODB.Recordset
		Dim fso As New Scripting.FileSystemObject
        Dim tb As New TextBox
        txtSearch.AddRange(New TextBox() {_txtSearch_0, _txtSearch_1, _txtSearch_2, _txtSearch_3, _
                                         _txtSearch_4})
        For Each tb In txtSearch
            AddHandler tb.TextChanged, AddressOf txtSearch_TextChanged
            AddHandler tb.Enter, AddressOf txtSearch_Enter
            AddHandler tb.KeyDown, AddressOf txtSearch_KeyDown
            AddHandler tb.KeyPress, AddressOf txtSearch_KeyPress
            AddHandler tb.Leave, AddressOf txtSearch_Leave
        Next
        ResizeForm(Me, pixelToTwips(Me.Width, True), pixelToTwips(Me.Height, False), 0)
		
		On Error GoTo ErrLoadForm
		'Doing shelf from file
		If grvPrin Then
			'rsPrinter_B.Close
			rsPrinter_B.Open(serverPath & "ShelfBarcode.dat")
			'rsPrinter_B.filter = ""
			'If frmBarcode._optBarcode_2.value = True Then rsPrinter_B.filter = "StockItem_SBarcode ='barcode'"
			'If frmBarcode._optBarcode_1.value = True Then rsPrinter_B.filter = "StockItem_SBarcode ='shelf'"
			
			If frmBarcode._optBarcode_2.Checked = True Then rsPrinter_B.filter = "StockItem_SBarcode = true"
			If frmBarcode._optBarcode_1.Checked = True Then rsPrinter_B.filter = "StockItem_SShelf =true"
			
			'If grvPrinType = 1 Then rsPrinter_B.filter = "StockItem_SBarcode ='shelf'"
			
			cnnDB.Execute("DELETE * FROM barcodePersonLnk")
			
			Do Until rsPrinter_B.EOF
				If frmBarcode._optBarcode_1.Checked = True Then 'If its a shelf talker.....
					sql = "INSERT INTO barcodePersonLnk ( barcodePersonLnk_PersonID, barcodePersonLnk_StockItemID, barcodePersonLnk_Shrink,barcodePersonLnk_PrintQTY ) "
                    sql = sql & "SELECT theJoin.Person, theJoin.Catalogue_StockItemID, theJoin.Catalogue_Quantity , theJoin.PrinQTY FROM (SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, " & gPersonID & " AS Person, 1 AS PrinQTY FROM Catalogue WHERE Catalogue.Catalogue_Quantity = 1 AND Catalogue_StockItemID = " & rsPrinter_B.Fields("GRVItem_StockItemID").Value & ") AS theJoin"
					
				Else
					sql = "INSERT INTO barcodePersonLnk ( barcodePersonLnk_PersonID, barcodePersonLnk_StockItemID, barcodePersonLnk_Shrink,barcodePersonLnk_PrintQTY ) "
                    sql = sql & "SELECT theJoin.Person, theJoin.Catalogue_StockItemID, theJoin.Catalogue_Quantity , theJoin.PrinQTY FROM (SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, " & gPersonID & " AS Person, " & rsPrinter_B.Fields("GRVItem_Quantity").Value & " AS PrinQTY FROM Catalogue WHERE Catalogue.Catalogue_Quantity = 1 AND Catalogue_StockItemID = " & rsPrinter_B.Fields("GRVItem_StockItemID").Value & ") AS theJoin"
					
                End If
#If DEBUG Then
                Debug.Print(sql)
#End If

				cnnDB.Execute(sql)
				rsPrinter_B.moveNext()
			Loop 
		Else
			cnnDB.Execute("DELETE * FROM barcodePersonLnk")
			sql = "INSERT INTO barcodePersonLnk ( barcodePersonLnk_PersonID, barcodePersonLnk_StockItemID, barcodePersonLnk_Shrink ) "
			sql = sql & "SELECT theJoin.Person, theJoin.Catalogue_StockItemID, theJoin.Catalogue_Quantity "
			sql = sql & "FROM (SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, " & gPersonID & " AS Person FROM Catalogue) AS theJoin LEFT JOIN barcodePersonLnk ON (theJoin.Person = barcodePersonLnk.barcodePersonLnk_PersonID) AND (theJoin.Catalogue_Quantity = barcodePersonLnk.barcodePersonLnk_Shrink) AND (theJoin.Catalogue_StockItemID = barcodePersonLnk.barcodePersonLnk_StockItemID) WHERE (((barcodePersonLnk.barcodePersonLnk_PersonID) Is Null));"
			cnnDB.Execute(sql)
		End If
		
		
		Dim lLeft As Integer
		With gridEdit
            .Col = 7
			.RowCount = 0
			System.Windows.Forms.Application.DoEvents()
			.RowCount = 2
			.FixedRows = 1
			.FixedCols = 0
			.row = 0
			.Col = 0
			.CellFontBold = True
			.Text = "Barcode"
			.set_ColWidth(0, 1400)
			.CellAlignment = 7
			.Col = 1
			.CellFontBold = True
			.Text = "ID"
			.set_ColWidth(1, 800)
			.CellAlignment = 4
			.Col = 2
			.CellFontBold = True
			.Text = "Stock Name"
			.set_ColWidth(2, 2000)
			.CellAlignment = 1
			.Col = 3
			.CellFontBold = True
			.Text = "Supplier"
			.set_ColWidth(3, 2000)
			.CellAlignment = 1
			.Col = 4
			.CellFontBold = True
			.Text = "Department"
			.set_ColWidth(4, 2000)
			.CellAlignment = 1
			.Col = 5
			.CellFontBold = True
			.Text = "QTY"
			.set_ColWidth(5, 800)
			.CellAlignment = 1
			.Col = 6
			.CellFontBold = True
			.Text = "Price Status"
			.set_ColWidth(6, 1300)
			.CellAlignment = 2
			lOrder = " ORDER BY StockItem.StockItem_Name"
            lLeft = pixelToTwips(.Left, True)

            For x = 0 To txtSearch.Count
                txtSearch(x).Left = twipsToPixels(lLeft, True)
                txtSearch(x).Width = twipsToPixels(.get_ColWidth(x), True)
                lLeft = lLeft + pixelToTwips(txtSearch(x).Width, True)
            Next
			.Col = 0
			doRS(True)
		End With
		'doRS True
		doRS()
		
		Exit Sub
ErrLoadForm: 
		If Err.Number = 0 Then
			Resume Next
        Else
#If DEBUG Then
            Debug.Print(Err.Number)
#End If

            MsgBox(Err.Number & Err.Description)
            Resume Next
		End If
	End Sub
	
	Private Sub doRS(Optional ByRef show_Renamed As Boolean = False)
        Dim sql As String
        Dim lString As String
        Dim lFilter As String
        Dim oText As System.Windows.Forms.TextBox
        lFilter = ""
        gridEdit_LeaveCell(gridEdit, New System.EventArgs())
        If show_Renamed Then
            If grvPrin Then
                lFilter = " Where Catalogue.Catalogue_Quantity = 1 AND CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = 1 AND barcodePersonLnk.barcodePersonLnk_PersonID=" & gPersonID & " AND barcodePersonLnk.barcodePersonLnk_PrintQTY <> 0  AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False "
            Else
                lFilter = " Where CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = 1 AND barcodePersonLnk.barcodePersonLnk_PersonID=" & gPersonID & " AND barcodePersonLnk.barcodePersonLnk_PrintQTY <> 0  AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False "
            End If
        Else
            For Each oText In txtSearch
                lString = doSearch((oText.Tag), (oText.Text))
                If lString <> "" Then lFilter = lFilter & " AND " & lString & ""
            Next oText

            If grvPrin Then
                lFilter = " Where Catalogue.Catalogue_Quantity = 1 AND CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = 1 AND barcodePersonLnk.barcodePersonLnk_PersonID=" & gPersonID & " AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False" & lFilter
            Else
                lFilter = " Where CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = 1 AND barcodePersonLnk.barcodePersonLnk_PersonID=" & gPersonID & " AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False" & lFilter
            End If
        End If
        'sql = "SELECT StockItem.StockItemID, Catalogue.Catalogue_Quantity, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Supplier.SupplierID, Supplier.Supplier_Name, PricingGroup.PricingGroupID, PricingGroup.PricingGroup_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (((StockItem INNER JOIN Supplier ON StockItem.StockItem_SupplierID = Supplier.SupplierID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)"
        sql = "SELECT StockItem.StockItemID, Catalogue.Catalogue_Quantity, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Supplier.SupplierID, Supplier.Supplier_Name, PricingGroup.PricingGroupID, PricingGroup.PricingGroup_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, barcodePersonLnk.barcodePersonLnk_PersonID, barcodePersonLnk.barcodePersonLnk_PrintQTY "
        sql = sql & " FROM barcodePersonLnk INNER JOIN ((((StockItem INNER JOIN Supplier ON StockItem.StockItem_SupplierID = Supplier.SupplierID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity)) ON (barcodePersonLnk.barcodePersonLnk_Shrink = Catalogue.Catalogue_Quantity) AND (barcodePersonLnk.barcodePersonLnk_StockItemID = Catalogue.Catalogue_StockItemID) "
        gRS = getRS(sql & lFilter & gOrder)
        txtEdit.Visible = False
        loadData()
    End Sub
	
	Private Sub doRSSingle(Optional ByRef show_Renamed As Boolean = False)
        Dim sql As String
        Dim lString As String
        Dim lFilter As String
        Dim oText As System.Windows.Forms.TextBox
        lFilter = ""
        gridEdit_LeaveCell(gridEdit, New System.EventArgs())
        If show_Renamed Then
            lFilter = " Where CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = 1 AND barcodePersonLnk.barcodePersonLnk_PersonID=" & gPersonID & " AND barcodePersonLnk.barcodePersonLnk_PrintQTY <> 0 AND barcodePersonLnk.barcodePersonLnk_Shrink = 1 AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False "
        Else
            For Each oText In txtSearch
                lString = doSearch((oText.Tag), (oText.Text))
                If lString <> "" Then lFilter = lFilter & " AND " & lString & ""
            Next oText


            lFilter = " Where CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = 1 AND barcodePersonLnk.barcodePersonLnk_PersonID=" & gPersonID & " AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False" & lFilter
        End If
        'sql = "SELECT StockItem.StockItemID, Catalogue.Catalogue_Quantity, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Supplier.SupplierID, Supplier.Supplier_Name, PricingGroup.PricingGroupID, PricingGroup.PricingGroup_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (((StockItem INNER JOIN Supplier ON StockItem.StockItem_SupplierID = Supplier.SupplierID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)"
        sql = "SELECT StockItem.StockItemID, Catalogue.Catalogue_Quantity, StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Supplier.SupplierID, Supplier.Supplier_Name, PricingGroup.PricingGroupID, PricingGroup.PricingGroup_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, barcodePersonLnk.barcodePersonLnk_PersonID, barcodePersonLnk.barcodePersonLnk_PrintQTY "
        sql = sql & " FROM barcodePersonLnk INNER JOIN ((((StockItem INNER JOIN Supplier ON StockItem.StockItem_SupplierID = Supplier.SupplierID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity)) ON (barcodePersonLnk.barcodePersonLnk_Shrink = Catalogue.Catalogue_Quantity) AND (barcodePersonLnk.barcodePersonLnk_StockItemID = Catalogue.Catalogue_StockItemID) "
        gRS = getRS(sql & lFilter & gOrder)
        txtEdit.Visible = False
        loadData()
    End Sub
	
	
	Private Sub changePrice()
        Dim lColumns As Integer
        Dim lRows As Integer
        Dim sql As String
		'Dim arrloadCSV() As String
		Dim strname As String
		Dim gRSPrice As ADODB.Recordset
		Dim rs As ADODB.Recordset
		
		On Error GoTo errL
		
		sql = "TRANSFORM Sum(Query2.POSCatalogueChannelLnk_Price) AS SumOfPOSCatalogueChannelLnk_Price SELECT Query2.StockItemID, Query2.StockItem_Name, Query2.CatalogueChannelLnk_Quantity FROM (SELECT StockItem.StockItemID, StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price, POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price "
		sql = sql & "FROM ((POSUpdate_PriceChangeSummary INNER JOIN StockItem ON POSUpdate_PriceChangeSummary.CatalogueChannelLnk_StockItemID = StockItem.StockItemID) INNER JOIN CatalogueChannelLnk ON (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = POSUpdate_PriceChangeSummary.CatalogueChannelLnk_Quantity) AND (POSUpdate_PriceChangeSummary.CatalogueChannelLnk_ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) AND (StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)) INNER JOIN POSCatalogueChannelLnk ON (CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID) ORDER BY StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) "
		sql = sql & "Query2 GROUP BY Query2.StockItemID, Query2.StockItem_Name, Query2.CatalogueChannelLnk_Quantity PIVOT Query2.CatalogueChannelLnk_ChannelID;"
		'Set gRSPrice = getRS("SELECT StockItem.StockItemID, systemStockItemPricing.systemStockItemPricing FROM StockItem INNER JOIN systemStockItemPricing ON StockItem.StockItemID = systemStockItemPricing.systemStockItemPricing;")
		gRSPrice = getRS(sql)
		
		Dim x, y As Integer
		'On Local Error Resume Next
		
		If gRSPrice.RecordCount > 0 Then 
		Else 
			Exit Sub
		End If
		x = 1
		With gridEdit
			.Visible = False
			.RowCount = gRS.RecordCount + 1
			gCancel = False
			gRS.MoveFirst()
			Do Until gRS.EOF
				gridEdit.set_TextMatrix(x, 0, gRS.Fields("Catalogue_Barcode").Value)
				gridEdit.set_TextMatrix(x, 1, gRS.Fields("StockItemID").Value)
				gridEdit.set_TextMatrix(x, 2, " " & gRS.Fields("Catalogue_Quantity").Value & "x" & gRS.Fields("StockItem_Name").Value)
				gridEdit.set_TextMatrix(x, 3, " " & gRS.Fields("Supplier_Name").Value)
				gridEdit.set_TextMatrix(x, 4, " " & gRS.Fields("PricingGroup_Name").Value)
				
				lRows = 0
				lColumns = 0
				'For lRows = 0 To UBound(arrloadCSV)
				'    If arrloadCSV(lRows, 0) = gRS("Catalogue_Barcode") Then lColumns = arrloadCSV(lRows, 1)
				'Next
				gRSPrice.MoveFirst()
				Do Until gRSPrice.EOF
					If gRSPrice.Fields("StockItemID").Value = gRS.Fields("StockItemID").Value Then lColumns = 1
					gRSPrice.moveNext()
				Loop 
				
				If lColumns = 0 Then
                    gridEdit.set_TextMatrix(x, 5, gRS.Fields("barcodePersonLnk_PrintQTY").Value)
                Else
                    gridEdit.set_TextMatrix(x, 5, lColumns)
                    gridEdit.set_TextMatrix(x, 6, "Changed")

                    'If rs.State Then rs.Close
                    'sql = "SELECT Catalogue_Quantity FROM Catalogue WHERE Catalogue_StockItemID = " & Val(gridEdit.TextMatrix(gridEdit.row, 1)) & " AND Catalogue_Barcode = '" & Trim(gridEdit.TextMatrix(gridEdit.row, 0)) & "'"
                    sql = "SELECT Catalogue_Quantity FROM Catalogue WHERE Catalogue_StockItemID = " & gRS.Fields("StockItemID").Value & " AND Catalogue_Barcode = '" & Trim(gRS.Fields("Catalogue_Barcode").Value) & "'"
                    rs = getRS(sql)
                    cnnDB.Execute("UPDATE barcodePersonLnk SET barcodePersonLnk.barcodePersonLnk_PrintQTY = " & lColumns & " WHERE (((barcodePersonLnk.barcodePersonLnk_PersonID)=" & gPersonID & ") AND ((barcodePersonLnk.barcodePersonLnk_StockItemID)=" & gRS.Fields("StockItemID").Value & ") AND ((barcodePersonLnk.barcodePersonLnk_Shrink)= " & rs.Fields("Catalogue_Quantity").Value & "));")
                    rs.Close()
                End If
				
				
				x = x + 1
				If x Mod 10 Then
				Else
					System.Windows.Forms.Application.DoEvents()
					If gCancel Then Exit Do
				End If
				gRS.moveNext()
			Loop 
			.RowCount = x
			.Visible = True
		End With
		
		Exit Sub
errL: 
		Resume Next
	End Sub
	
	Private Sub newPrice()
        Dim lColumns As Integer
        Dim lRows As Integer
        Dim sql As String
		'Dim arrloadCSV() As String
		Dim strname As String
		Dim gRSPrice As ADODB.Recordset
		Dim rs As ADODB.Recordset
		
		On Error GoTo errL
		
		sql = "TRANSFORM Sum(newItems.CatalogueChannelLnk_Price) AS SumOfCatalogueChannelLnk_Price SELECT newItems.StockItemID, newItems.StockItem_Name, newItems.CatalogueChannelLnk_Quantity FROM [SELECT StockItem.StockItemID, StockItem.StockItem_Name, POSUpdate_PriceNewSummary.CatalogueChannelLnk_ChannelID, POSUpdate_PriceNewSummary.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM CatalogueChannelLnk INNER JOIN (POSUpdate_PriceNewSummary INNER JOIN StockItem ON POSUpdate_PriceNewSummary.CatalogueChannelLnk_StockItemID = StockItem.StockItemID) ON (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = POSUpdate_PriceNewSummary.CatalogueChannelLnk_Quantity) AND (CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = POSUpdate_PriceNewSummary.CatalogueChannelLnk_ChannelID) AND (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = POSUpdate_PriceNewSummary.CatalogueChannelLnk_StockItemID) "
		sql = sql & "ORDER BY StockItem.StockItem_Name, POSUpdate_PriceNewSummary.CatalogueChannelLnk_ChannelID, POSUpdate_PriceNewSummary.CatalogueChannelLnk_Quantity]. AS newItems GROUP BY newItems.StockItemID, newItems.StockItem_Name, newItems.CatalogueChannelLnk_Quantity PIVOT newItems.CatalogueChannelLnk_ChannelID;"
		'Set gRSPrice = getRS("SELECT StockItem.StockItemID, systemStockItemPricing.systemStockItemPricing FROM StockItem INNER JOIN systemStockItemPricing ON StockItem.StockItemID = systemStockItemPricing.systemStockItemPricing;")
		gRSPrice = getRS(sql)
		
		Dim x, y As Integer
		'On Local Error Resume Next
		
		If gRSPrice.RecordCount > 0 Then 
		Else 
			Exit Sub
		End If
		x = 1
		With gridEdit
			.Visible = False
			.RowCount = gRS.RecordCount + 1
			gCancel = False
			gRS.MoveFirst()
			Do Until gRS.EOF
				gridEdit.set_TextMatrix(x, 0, gRS.Fields("Catalogue_Barcode").Value)
				gridEdit.set_TextMatrix(x, 1, gRS.Fields("StockItemID").Value)
				gridEdit.set_TextMatrix(x, 2, " " & gRS.Fields("Catalogue_Quantity").Value & "x" & gRS.Fields("StockItem_Name").Value)
				gridEdit.set_TextMatrix(x, 3, " " & gRS.Fields("Supplier_Name").Value)
				gridEdit.set_TextMatrix(x, 4, " " & gRS.Fields("PricingGroup_Name").Value)
				
				lRows = 0
				lColumns = 0
				'For lRows = 0 To UBound(arrloadCSV)
				'    If arrloadCSV(lRows, 0) = gRS("Catalogue_Barcode") Then lColumns = arrloadCSV(lRows, 1)
				'Next
				gRSPrice.MoveFirst()
				Do Until gRSPrice.EOF
					If gRSPrice.Fields("StockItemID").Value = gRS.Fields("StockItemID").Value Then lColumns = 1
					gRSPrice.moveNext()
				Loop 
				
				If lColumns = 0 Then
                    gridEdit.set_TextMatrix(x, 5, gRS.Fields("barcodePersonLnk_PrintQTY").Value)
                Else
                    gridEdit.set_TextMatrix(x, 5, lColumns)
                    gridEdit.set_TextMatrix(x, 6, "New")

                    sql = "SELECT Catalogue_Quantity FROM Catalogue WHERE Catalogue_StockItemID = " & gRS.Fields("StockItemID").Value & " AND Catalogue_Barcode = '" & Trim(gRS.Fields("Catalogue_Barcode").Value) & "'"
                    rs = getRS(sql)
                    cnnDB.Execute("UPDATE barcodePersonLnk SET barcodePersonLnk.barcodePersonLnk_PrintQTY = " & lColumns & " WHERE (((barcodePersonLnk.barcodePersonLnk_PersonID)=" & gPersonID & ") AND ((barcodePersonLnk.barcodePersonLnk_StockItemID)=" & gRS.Fields("StockItemID").Value & ") AND ((barcodePersonLnk.barcodePersonLnk_Shrink)= " & rs.Fields("Catalogue_Quantity").Value & "));")
                    rs.Close()
                End If
				'sql = "SELECT Catalogue_Quantity FROM Catalogue WHERE Catalogue_StockItemID = " & gRS("StockItemID") & " AND Catalogue_Barcode = '" & Trim(gRS("Catalogue_Barcode")) & "'"
				'Set rs = getRS(sql)
				'cnnDB.Execute "UPDATE barcodePersonLnk SET barcodePersonLnk.barcodePersonLnk_PrintQTY = " & lColumns & " WHERE (((barcodePersonLnk.barcodePersonLnk_PersonID)=" & gPersonID & ") AND ((barcodePersonLnk.barcodePersonLnk_StockItemID)=" & gRS("StockItemID") & ") AND ((barcodePersonLnk.barcodePersonLnk_Shrink)= " & rs("Catalogue_Quantity") & "));"
				'rs.Close
				
				x = x + 1
				If x Mod 10 Then
				Else
					System.Windows.Forms.Application.DoEvents()
					If gCancel Then Exit Do
				End If
				gRS.moveNext()
			Loop 
			.RowCount = x
			.Visible = True
		End With
		
		Exit Sub
errL: 
		Resume Next
	End Sub
	
	Private Sub loadData()
		Dim x, y As Integer
		On Error Resume Next
		x = 1
		With gridEdit
			.Visible = False
			.RowCount = gRS.RecordCount + 1
			gCancel = False
			Do Until gRS.EOF
				gridEdit.set_TextMatrix(x, 0, gRS.Fields("Catalogue_Barcode").Value)
				gridEdit.set_TextMatrix(x, 1, gRS.Fields("StockItemID").Value)
				gridEdit.set_TextMatrix(x, 2, " " & gRS.Fields("Catalogue_Quantity").Value & "x" & gRS.Fields("StockItem_Name").Value)
				gridEdit.set_TextMatrix(x, 3, " " & gRS.Fields("Supplier_Name").Value)
				gridEdit.set_TextMatrix(x, 4, " " & gRS.Fields("PricingGroup_Name").Value)
				gridEdit.set_TextMatrix(x, 5, gRS.Fields("barcodePersonLnk_PrintQTY").Value)
				gridEdit.set_TextMatrix(x, 6, "NO")
				x = x + 1
				If x Mod 10 Then
				Else
					System.Windows.Forms.Application.DoEvents()
					If gCancel Then Exit Do
				End If
				gRS.moveNext()
			Loop 
			.RowCount = x
			.Visible = True
		End With
		
		changePrice()
		newPrice()
	End Sub
	
	Private Function doSearch(ByRef lField As String, ByRef lText As String) As String
		Dim lString As String
		lString = Trim(lText)
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		
		If Trim(lText) = "" Then
			lString = ""
		Else
			lString = "(" & lField & " LIKE '%" & Replace(lString, " ", "%' AND " & lField & " LIKE '%") & "%')"
			'lString = "(" & lField & " LIKE '%" & Replace(lString, " ", "%' AND StockItem_Name LIKE '%") & "%')"
		End If
		doSearch = lString
	End Function
	
    Private Sub gridEdit_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles gridEdit.DoubleClick
        On Error Resume Next
        With gridEdit
            If .Col <> 5 Then
                txtSearch(.Col).Text = Trim(.Text)
                doRS()
                txtSearch(.Col).Focus()
            End If
        End With

    End Sub
	
    Private Sub gridEdit_EnterCell(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles gridEdit.EnterCell
        On Error Resume Next
        If Me.Visible Then
            With gridEdit
                If .Col = 5 Then
                    txtEdit.SetBounds(twipsToPixels(pixelToTwips(.Left, True) + .CellLeft, True), _
                                      twipsToPixels(pixelToTwips(.Top, False) + .CellTop, False), _
                                      twipsToPixels(.CellWidth, True), _
                                      twipsToPixels(.CellHeight, False))
                    txtEdit.Text = .Text
                    txtEdit.Tag = txtEdit.Text
                    txtEdit.Visible = True
                    txtEdit.Focus()
                Else
                    txtSearch(.Col).Focus()
                    txtEdit.Visible = False
                End If
            End With
        End If
    End Sub
    Private Sub gridEdit_LeaveCell(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles gridEdit.LeaveCell
        Dim sql As String
        Dim rs As ADODB.Recordset

        If txtEdit.Visible Then
            txtEdit.Visible = False

            sql = "SELECT Catalogue_Quantity FROM Catalogue WHERE Catalogue_StockItemID = " & Val(gridEdit.get_TextMatrix(gridEdit.row, 1)) & " AND Catalogue_Barcode = '" & Trim(gridEdit.get_TextMatrix(gridEdit.row, 0)) & "'"
            rs = getRS(sql)
            cnnDB.Execute("UPDATE barcodePersonLnk SET barcodePersonLnk.barcodePersonLnk_PrintQTY = " & txtEdit.Text & " WHERE (((barcodePersonLnk.barcodePersonLnk_PersonID)=" & gPersonID & ") AND ((barcodePersonLnk.barcodePersonLnk_StockItemID)=" & gridEdit.get_TextMatrix(gridEdit.row, 1) & ") AND ((barcodePersonLnk.barcodePersonLnk_Shrink)= " & rs.Fields("Catalogue_Quantity").Value & "));")
        End If
    End Sub
	
	Private Sub txtEdit_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtEdit.TextChanged
        gridEdit.set_TextMatrix(gridEdit.Row, 5, txtEdit.Text)
    End Sub
	
	Private Sub txtEdit_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtEdit.Enter
		txtEdit.SelectionStart = 0
		txtEdit.SelectionLength = 999
		
	End Sub
	
	Private Sub txtEdit_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtEdit.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Select Case KeyCode
			Case 40
				If gridEdit.row <= gridEdit.RowCount - 2 Then
					gridEdit.row = gridEdit.row + 1
				End If
			Case 38
				If gridEdit.row > 1 Then
					gridEdit.row = gridEdit.row - 1
				End If
			Case 27
		End Select
	End Sub
	
	Private Sub txtEdit_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtEdit.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case Chr(KeyAscii)
			Case CStr(0), CStr(1), CStr(2), CStr(3), CStr(4), CStr(5), CStr(6), CStr(7), CStr(8), CStr(9), CStr(0)
			Case Else
				KeyAscii = 0
		End Select
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
    Private Sub txtSearch_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtSearch.TextChanged
        'Dim Index As Short = txtSearch.GetIndex(eventSender)
        'doRS
    End Sub
	
    Private Sub txtSearch_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtSearch.Enter
        Dim txt As New TextBox
        txt = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txt, txtSearch)
        txtSearch(Index).BackColor = System.Drawing.Color.White

    End Sub
	
    Private Sub txtSearch_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) 'Handles txtSearch.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim txt As New TextBox
        txt = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txt, txtSearch)
        Select Case KeyCode
            Case 38
                gOrder = " ORDER BY " & txtSearch(Index).Tag & " DESC"
                KeyCode = 0
                doRS()
            Case 40
                gOrder = " ORDER BY " & txtSearch(Index).Tag
                KeyCode = 0
                doRS()
            Case 27
                If txtSearch(Index).Text <> "" Then
                    txtSearch(Index).Text = ""
                    KeyCode = 0
                    doRS()
                End If
        End Select
    End Sub
	
    Private Sub txtSearch_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) 'Handles txtSearch.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'Dim Index As Short = txtSearch.GetIndex(eventSender)
        If KeyAscii = 27 Then
            KeyAscii = 0
        ElseIf KeyAscii = 13 Then
            doRS()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub txtSearch_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtSearch.Leave
        Dim txt As New TextBox
        txt = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txt, txtSearch)
        txtSearch(Index).BackColor = Me.BackColor
    End Sub
End Class