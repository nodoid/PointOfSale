Option Strict Off
Option Explicit On
Option Compare Text
Imports VB = Microsoft.VisualBasic
Friend Class frmBlockTest
	Inherits System.Windows.Forms.Form
	
	'serialization
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim mbChangedByCode As Boolean
    Dim mvBookMark As Boolean
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
	Dim gID As Integer
	Dim k_posID As Integer
	Dim k_posNew As Boolean
	Dim flag As Boolean
	Dim y As Single
	Dim c As Short
	Dim YY As Short
	Dim x As Short
	Private Declare Function BitBlt Lib "gdi32" (ByVal hDestDC As Integer, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hSrcDC As Integer, ByVal xSrc As Integer, ByVal ySrc As Integer, ByVal dwRop As Integer) As Integer
	
	Dim obj As System.Drawing.Image = New System.Drawing.Bitmap(1, 1)
	Private Declare Function GetDriveType Lib "kernel32"  Alias "GetDriveTypeA"(ByVal nDrive As String) As Integer
	
    Dim fox() As Integer
	Dim usb_drv As String
	Dim yourdrive As String
	Dim CDKey As Boolean
	'Option Explicit
	
	Private arData() As Byte
	Private arPWord() As Byte
	Private m_intCipher As Short
	'serialization
	
	Dim gStockItemID As Integer
	Dim gPromotionID As Integer
	Dim gQuantity As Integer
	Dim loading As Boolean
	
	Dim testName As String
	Dim testType As String
	Dim testID As Integer
	Dim StockItemLineID() As Integer
    Dim selectTest(,) As Integer

    Dim txtEdit As New List(Of TextBox)
	
	Private Sub loadLanguage()
		
		'frmBlockTest = No Code         [4MEAT Block Tester]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmBlockTest.Caption = rsLang("LanguageLayoutLnk_Description"): frmBlockTest.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1085 'Print|Checked
		If rsLang.RecordCount Then cmdPrint.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrint.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1332 'Process|Checked
		If rsLang.RecordCount Then cmdProc.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdProc.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'cmdReg = No Code               [Register 4MEAT]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0
		'If rsLang.RecordCount Then cmdReg.Caption = rsLang("LanguageLayoutLnk_Description"): cmdReg.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'NOTE: frmTotals has a spelling mistake in the caption!!!
		'frmTotals = No Code            [General Information]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmTotals.Caption = rsLang("LanguageLayoutLnk_Description"): frmTotals.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblTotal_0 = No Code          [Person Cutting]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0
		'If rsLang.RecordCount Then _lblTotal_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblTotal_1 = No Code          [Price Per Kg]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblTotal_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblTotal_2 = No Code          [Weight of Carcass]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblTotal_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblTotal_3 = No code          [Cost of Carcass]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblTotal_3.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'NOTE: Label Caption needs "&&"
		'_lblTotal_4 = No Code          [Weight Loss && Cutting Loss]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblTotal_4.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblTotal_5 = No Code          [Effective Price per Kg after loss]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblTotal_5.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblTotal_10 = No Code         [Required GP]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblTotal_10.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_10.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblTotal_9 = No Code          [1 - GP%]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblTotal_9.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_9.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblTotal_8 = No Code          [B/Z]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblTotal_8.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_8.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblTotal_7 = No Code          [VAT]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblTotal_7.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_7.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblTotal_6 = No Code          [X - VAT + 1]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblTotal_6.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_6.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdTotal = No Code             [Calculate]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdTotal.Caption = rsLang("LanguageLayoutLnk_Description"): cmdTotal.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblTotal_11 = No Code         [Weight after Cutting && W.Loss - P]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblTotal_11.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_11.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblTotal_12 = No Code         [F]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblTotal_12.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_12.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblTotal_14 = No Code         [G]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblTotal_14.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_14.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblTotal_15 = No Code         [H]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblTotal_15.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_15.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblTotal_13 = No Code         [Q]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblTotal_13.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_13.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblLabel(16) = No Code         [L]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblTotal_16.Caption = rsLang("LanguageLayoutLnk_Description"): _lblTotal_16.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmBlockTest.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmBlockTest.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Sub Reset_frmEncStrings()
        Erase arData
        Erase arPWord
    End Sub
	
	Private Sub cmdLoadNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLoadNext.Click
		Dim selectTestWeight As Decimal
		Dim rsTest As ADODB.Recordset
        Dim x As Integer
        Dim y As Integer
		On Error Resume Next
		
		For x = 0 To UBound(selectTest)
			If selectTest(x, 2) = -1 Then
				selectTestWeight = selectTestWeight + CDec(selectTest(x, 3))
				
				rsTest = getRS("SELECT BlockTestItem.BlockTestItem_StockItemID AS StockItemID, BlockTestItem.BlockTestItem_CutWeight From BlockTestItem Where (((BlockTestItem.BlockTestItem_BlockTestID) = " & selectTest(x, 0) & ")) ORDER BY BlockTestItem.BlockTestItem_Line;")
				If rsTest.RecordCount Then
					Do Until rsTest.EOF
						With gridItem
                            For y = 1 To (.RowCount - 1)
                                .row = y
                                If .get_RowData(y) = rsTest.Fields("StockItemID").Value Then
                                    .set_TextMatrix(.row, 1, .get_TextMatrix(.row, 1) + rsTest.Fields("BlockTestItem_CutWeight").Value)
                                    Exit For
                                End If
                            Next
						End With
						rsTest.moveNext()
					Loop 
				End If
			End If
		Next 
		
		On Error Resume Next
		With gridItem
            For y = 1 To (.RowCount - 1)
                .row = y
                'If .RowData(y) = rsTest("StockItemID") Then
                .set_TextMatrix(.row, 1, FormatNumber((CDbl(.get_TextMatrix(.row, 1)) / selectTestWeight) * CDec(txtZ.Text), 3))
                '    Exit For
                'End If
            Next
		End With
		
		cmdTotal.Visible = True
		gridItem.Visible = True
		picTotal.Visible = True
		cmdLoadNext.Visible = False
		
	End Sub
	
	'UPGRADE_NOTE: Form_Initialize was upgraded to Form_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Form_Initialize_Renamed()
		'ChDrive App.Path
		'ChDir App.Path
		Initial_settings()
		Reset_frmEncStrings()
	End Sub
	
	
	Public Sub makeItem()
        Dim sql As String
		Dim lID As Integer
		Dim rs As ADODB.Recordset
		
		frmBlockTestSelect.loadTest(testType, testID)
		
reType: 
		If testType = "exit" Then
			Me.Close()
			Exit Sub
			
		ElseIf testType = "select" Then 
			testName = InputBox("Please enter short Name/Title for Block Test.", "Please enter short Name/Title for Block Test.")
			If testName = "" Then GoTo reType
			
			lID = frmStockList.getItem
			If lID <> 0 Then
				'On Local Error Resume Next
				sql = "INSERT INTO BlockTest ( BlockTest_DayEndID, BlockTest_BlockTestStatusID, BlockTest_Date, BlockTest_MainItemID, BlockTest_PersonID, BlockTest_Desc, BlockTest_PricePerKg, BlockTest_WeightCarcass, BlockTest_RequiredGP, BlockTest_VAT, BlockTest_Notes ) "
				sql = sql & "SELECT Company.Company_DayEndID, 1 AS status, Now(), " & lID & ", " & frmMenu.lblUser.Tag & ", '" & VB.Left(Replace(testName, "'", "''"), 49) & "', 0, 0, 0, 0, '' FROM Company;"
				cnnDB.Execute(sql)
				rs = getRS("SELECT Max(BlockTestID) AS id FROM BlockTest;")
				testID = rs.Fields("id").Value
				
                frmBlockTestFilterSelect.loadItem(lID, selectTest(testType, testID), testID)
				
				loadItem(lID)
			End If
			
		ElseIf testType = "new" Then 
			testName = InputBox("Please enter short Name/Title for Block Test.", "Please enter short Name/Title for Block Test.")
			If testName = "" Then GoTo reType
			
			lID = frmStockList.getItem
			If lID <> 0 Then
				'On Local Error Resume Next
				sql = "INSERT INTO BlockTest ( BlockTest_DayEndID, BlockTest_BlockTestStatusID, BlockTest_Date, BlockTest_MainItemID, BlockTest_PersonID, BlockTest_Desc, BlockTest_PricePerKg, BlockTest_WeightCarcass, BlockTest_RequiredGP, BlockTest_VAT, BlockTest_Notes ) "
				sql = sql & "SELECT Company.Company_DayEndID, 1 AS status, Now(), " & lID & ", " & frmMenu.lblUser.Tag & ", '" & VB.Left(Replace(testName, "'", "''"), 49) & "', 0, 0, 0, 0, '' FROM Company;"
				cnnDB.Execute(sql)
				rs = getRS("SELECT Max(BlockTestID) AS id FROM BlockTest;")
				testID = rs.Fields("id").Value
				
				loadItem(lID)
			End If
			
		ElseIf testType = "load" Then 
			rs = getRS("SELECT * FROM BlockTest WHERE BlockTestID = " & testID & ";")
			If rs.RecordCount Then
				loadItemSAVE(rs.Fields("BlockTest_MainItemID").Value) 'lID
				
			Else
				MsgBox("Problem while loading Test")
			End If
		End If
		
	End Sub
	
	Private Sub loadData()
		Dim rs As ADODB.Recordset
		Dim rj As ADODB.Recordset
		
		On Error Resume Next
		
		rs = getRS("SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & gStockItemID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
		If rs.RecordCount Then
			'lblStockItem.Caption = rs("StockItem_Name")
			'lblPromotion.Caption = rs("Promotion_Name")
			'txtPrice.Text = rs("CatalogueChannelLnk_Price") * 100
			'txtPrice_LostFocus
			'cmbQuantity.Tag = rs("CatalogueChannelLnk_Quantity")
			lblContentExclusive.Text = frmMenu.lblUser.Text
			getRecItems()
			
			loadLanguage()
			
			If testType = "select" Then
				cmdTotal.Visible = False
				gridItem.Visible = False
				picTotal.Visible = False
				cmdLoadNext.Visible = True
			End If
			
			ShowDialog()
		Else
			Me.Close()
			Exit Sub
		End If
		
	End Sub
	
	Public Sub loadItem(ByRef stockitemID As Integer, Optional ByRef quantity As Integer = 0)
        Dim colQuantity As Integer
        Dim oText As System.Windows.Forms.TextBox
		
        ResizeForm(Me, pixelToTwips(Me.Width, True), pixelToTwips(Me.Height, False), 2)
		
		setup()
		frmBlockTest_Resize(Me, New System.EventArgs())
		
		'Serial chk
		If checkSecurity = True Then
		Else
			Me.Text = Me.Text & " - Trial"
			cmdReg.Visible = True
		End If
		
        If gridItem.RowCount Then
            loading = True
            gridItem.Col = 0
            gridItem.row = 0
            loading = False
            For Each oText In txtEdit
                oText.Visible = False
            Next oText
            If gridItem.RowCount > 1 Then
                gridItem.Col = colQuantity
                gridItem.row = 1
                _txtEdit_0.Visible = True
            Else
            End If
        End If
        loading = False

        gStockItemID = stockitemID
        gQuantity = quantity

        Dim rsVat As ADODB.Recordset
        rsVat = getRS("SELECT Vat.Vat_Amount FROM StockItem INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID WHERE (((StockItem.StockItemID)=" & gStockItemID & "));")
        If rsVat.RecordCount Then txtVAT.Text = FormatNumber(rsVat.Fields("Vat_Amount").Value, 4)

        loadData()

    End Sub

    Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
        'Printer.Orientation = Or_Landscape
        'Printer.PaintPicture picForm.Picture, 0, 0 ',  x, y
        'gObject.PaintPicture Picture1.Picture, ((gWidth - x) / 2), 0, x, y
        Picture2.Visible = False
        cmdTotal.Visible = False
        Me.PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.CompatibleModeClientAreaOnly)

        Picture2.Visible = True
        cmdTotal.Visible = True
    End Sub

    Private Sub cmdProc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdProc.Click
        If updateProc Then Me.Close()
    End Sub

    Private Function updateProc() As Boolean
        Dim strFldName As String
        On Error GoTo UpdateErr

        Dim rs As ADODB.Recordset
        Dim rj As ADODB.Recordset
        Dim adoPrimaryRS As ADODB.Recordset
        Dim sql As String
        Dim lQuantity As Decimal

        rs = getRS("SELECT * from BlockTestItem Where BlockTestItem_BlockTestID = " & testID & ";")
        If rs.RecordCount > 0 Then

            strFldName = "HandHeldID Number,Handheld_Barcode Text(50), Quantity Currency"
            cnnDB.Execute("CREATE TABLE " & "HandheldBlockTest" & " (" & strFldName & ")")
            System.Windows.Forms.Application.DoEvents()
            sql = "INSERT INTO HandheldBlockTest (HandHeldID,Handheld_Barcode,Quantity) VALUES (" & gStockItemID & ", 0, " & (0 - CDec(txtZ.Text)) & ")"
            cnnDB.Execute(sql)
            System.Windows.Forms.Application.DoEvents()

            Do While rs.EOF = False
                sql = "INSERT INTO HandheldBlockTest (HandHeldID,Handheld_Barcode,Quantity) VALUES (" & rs.Fields("BlockTestItem_StockItemID").Value & ", 0, " & (rs.Fields("BlockTestItem_CutWeight")).Value & ")"
                cnnDB.Execute(sql)
                rs.moveNext()
            Loop

        Else
            MsgBox("This Product does not have any Recipe.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
            updateProc = False
            Exit Function
        End If
        cnnDB.Execute("INSERT INTO StockGroup (StockGroup_Name) VALUES ('HandheldBlockTest')")
        stTableName = "HandheldBlockTest"
        rj = getRS("SELECT StockGroup.StockGroupID, StockGroup.StockGroup_Name From StockGroup WHERE StockGroup.StockGroup_Name = 'HandheldBlockTest';")
        gID = rj.Fields("StockGroupID").Value

        'snap shot
        cnnDB.Execute("UPDATE Company SET Company.Company_StockTakeDate = now();")
        cnnDB.Execute("DELETE FROM StockTake WHERE (StockTake_WarehouseID = 2)")
        cnnDB.Execute("INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment ) SELECT StockItem.StockItemID, 2 AS warehouse, 0 AS quantity, 0 AS adjustment FROM StockItem;")
        cnnDB.Execute("UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));")
        cnnDB.Execute("DELETE FROM StockTakeDeposit")
        cnnDB.Execute("INSERT INTO StockTakeDeposit ( StockTakeDeposit_WarehouseID, StockTakeDeposit_DepositID, StockTakeDeposit_DepositTypeID, StockTakeDeposit_Quantity, StockTakeDeposit_Adjustment ) SELECT WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity FROM WarehouseDepositItemLnk INNER JOIN DISPLAY_Deposits ON (DISPLAY_Deposits.type = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = DISPLAY_Deposits.DepositID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID = DISPLAY_Deposits.WarehouseID);")
        'snap shot

        'Set adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, " & stTableName & ".Quantity, StockItem.StockItem_Quantity," & stTableName & ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" & stTableName & " INNER JOIN StockItem ON " & stTableName & ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " & gID & ") And ((Warehouse.WarehouseID) = 2) And ((StockItem.StockItem_Disabled) = False) And ((StockItem.StockItem_Discontinued) = False)) ORDER BY StockItem.StockItem_Name")
        adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, " & stTableName & ".Quantity, StockItem.StockItem_Quantity," & stTableName & ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" & stTableName & " INNER JOIN StockItem ON " & stTableName & ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " & gID & ") And ((Warehouse.WarehouseID) = 2)) ORDER BY StockItem.StockItem_Name")
        If adoPrimaryRS.RecordCount > 0 Then
            Do While adoPrimaryRS.EOF = False
                lQuantity = adoPrimaryRS.Fields("Quantity").Value
                'lQuantity = adoPrimaryRS("Quantity") - adoPrimaryRS("StockTake_Quantity").OriginalValue
                cnnDB.Execute("UPDATE StockTake SET StockTake.StockTake_Quantity = " & lQuantity & " WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS.Fields("StockTake_StockItemID").Value & ") AND ((StockTake.StockTake_WarehouseID)=2));")
                cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS.Fields("StockTake_StockItemID").Value & ") AND ((StockTake.StockTake_WarehouseID)=2));")
                'cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = 0 WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
                cnnDB.Execute("UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" & lQuantity & ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & adoPrimaryRS.Fields("StockTake_StockItemID").Value & "));")
                adoPrimaryRS.moveNext()
            Loop
        End If

        cnnDB.Execute("DROP TABLE HandheldBlockTest")
        cnnDB.Execute("DELETE * FROM StockGroup WHERE StockGroup_Name ='HandheldBlockTest'")

        cnnDB.Execute("UPDATE BlockTest SET BlockTest_BlockTestStatusID = 3 WHERE (BlockTestID = " & testID & ")")
        MsgBox("Block Test process has been completed.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)

        updateProc = True

        Exit Function
UpdateErr:
        MsgBox(Err.Description)
        updateProc = True
    End Function

    Private Sub updatePrice()
        cnnDB.Execute("UPDATE BlockTestItem INNER JOIN CatalogueChannelLnk ON BlockTestItem.BlockTestItem_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Price = BlockTestItem.BlockTestItem_MRelatedSellPrice WHERE (((BlockTestItem.BlockTestItem_BlockTestID)=" & testID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=2));")
        cnnDB.Execute("UPDATE BlockTestItem INNER JOIN CatalogueChannelLnk ON BlockTestItem.BlockTestItem_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Price = BlockTestItem.BlockTestItem_ActualSellPriceIncl WHERE (((BlockTestItem.BlockTestItem_BlockTestID)=" & testID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
    End Sub

    Private Sub cmdReg_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdReg.Click
        If frmBlockTestCode.setupCode = True Then

            Me.Text = VB.Left(Me.Text, Len(Me.Text) - Len(" - Trial"))
            cmdReg.Visible = False
        End If
    End Sub

    Private Sub cmdTotal_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdTotal.Click
        Dim QtyD_P As Decimal
        Dim x As Integer
        On Error Resume Next

        'Serial chk
        If checkSecurity = True Then

        Else
            If timeOver Then
                MsgBox("Your 4MEAT Software has expired." & vbCrLf & "Please contact your 4POS representative or www.4pos.co.za.", MsgBoxStyle.Critical, "4MEAT is not Registered")
                Exit Sub
            End If
        End If

        cmdTotal.Enabled = False
        'update BlockTest master
        cnnDB.Execute("UPDATE BlockTest SET BlockTest_PricePerKg = " & FormatNumber(CDec(txtR.Text), 4) & ", BlockTest_WeightCarcass = " & FormatNumber(CDec(txtZ.Text), 4) & ", BlockTest_RequiredGP = " & FormatNumber(CDec(txtReqGP.Text), 2) & ", BlockTest_VAT = " & FormatNumber(CDec(txtVAT.Text), 4) & " WHERE (BlockTestID = " & testID & ")")


        lblA.Text = FormatNumber(CDec(txtR.Text) * CDec(txtZ.Text), 4)


        lblGP_Y.Text = FormatNumber(CDec(1 - (CDec(CDbl(txtReqGP.Text) / 100))), 4)

        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 2
                cnnDB.Execute("UPDATE BlockTestItem SET BlockTestItem_MRelatedSellPrice = " & FormatNumber(CDec(.Text), 2) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .get_RowData(x) & ") AND (BlockTestItem_Line = " & x & "));")
            Next
        End With

        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 11
                cnnDB.Execute("UPDATE BlockTestItem SET BlockTestItem_ActualSellPriceIncl = " & FormatNumber(CDec(.Text), 2) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .get_RowData(x) & ") AND (BlockTestItem_Line = " & x & "));")
            Next
        End With

        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 1
                QtyD_P = QtyD_P + CDec(.Text) '.TextMatrix(.row, 1) = FormatNumber(CCur(_txtEdit_1.Text) / 100, 4)
                cnnDB.Execute("UPDATE BlockTestItem SET BlockTestItem_CutWeight = " & FormatNumber(CDec(.Text), 3) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .get_RowData(x) & ") AND (BlockTestItem_Line = " & x & "));")
            Next
        End With
        lblP.Text = FormatNumber(QtyD_P, 4)


        lblB.Text = FormatNumber(CDec(txtZ.Text) - CDec(lblP.Text), 4)


        lblC.Text = FormatNumber(CDec(lblA.Text) / CDec(lblP.Text), 4)


        lblB_Z.Text = FormatNumber(CDec(lblB.Text) / CDec(txtZ.Text), 4)


        lblX.Text = FormatNumber(CDec(CDec(CDbl(txtVAT.Text) / 100) + 1), 4)


        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 1
                .set_TextMatrix(.row, 3, FormatNumber((CDec(.Text) / CDec(txtZ.Text)) * 100, 4))
                '.Col = 3
                'QtyD_P = QtyD_P + CCur(.Text)
            Next
        End With
        QtyD_P = 0
        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 3
                QtyD_P = QtyD_P + CDec(.Text)
                'cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_PerWeightYield = " & FormatNumber(CCur(.Text), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
                cnnDB.Execute("UPDATE BlockTestItem SET BlockTestItem_PerWeightYield = " & CDec(.Text) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .get_RowData(x) & ") AND (BlockTestItem_Line = " & x & "));")
            Next
        End With
        lblTotalF.Text = FormatNumber(QtyD_P, 4)
        'total req


        Dim D_E As Decimal
        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 1
                D_E = CDec(.Text)
                .Col = 2
                D_E = D_E * CDec(.Text)
                .set_TextMatrix(.row, 6, FormatNumber(D_E, 4))
            Next
        End With
        QtyD_P = 0
        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 6
                QtyD_P = QtyD_P + CDec(.Text)
                'QtyD_P = FormatNumber(CCur(.Text), 4)
                'cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_MRelatedTO = " & FormatNumber(CCur(.Text), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
                cnnDB.Execute("UPDATE BlockTestItem SET BlockTestItem_MRelatedTO = " & CDec(.Text) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .get_RowData(x) & ") AND (BlockTestItem_Line = " & x & "));")
            Next
        End With
        lblTotalQ.Text = FormatNumber(QtyD_P, 4)
        'total req


        Dim S_A_Q As Decimal
        S_A_Q = CDec(FormatNumber(CDec(lblA.Text) / CDec(lblTotalQ.Text), 4))


        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 2
                '.TextMatrix(.row, 4) = FormatNumber((CCur(.Text) / CCur(lblC.Caption)) * CCur(lblGP_Y.Caption), 4)
                .set_TextMatrix(.row, 4, FormatNumber((CDec(.Text) / CDec(lblC.Text)) * CDec(S_A_Q), 4))
            Next
        End With
        QtyD_P = 0
        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 4
                QtyD_P = QtyD_P + CDec(.Text)
                'cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_MRSellingratio = " & FormatNumber(CCur(.Text), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
                cnnDB.Execute("UPDATE BlockTestItem SET BlockTestItem_MRSellingratio = " & CDec(.Text) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .get_RowData(x) & ") AND (BlockTestItem_Line = " & x & "));")
            Next
        End With
        lblTotalG.Text = FormatNumber(QtyD_P, 4)
        'total req


        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 4
                .set_TextMatrix(.row, 7, FormatNumber(CDec(lblC.Text) * CDec(.Text), 4))
                'cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_PrimalCostkgExclVAT = " & FormatNumber(CCur(lblC.Caption) * CCur(.Text), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
                cnnDB.Execute("UPDATE BlockTestItem SET BlockTestItem_PrimalCostkgExclVAT = " & (CDec(lblC.Text) * CDec(.Text)) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .get_RowData(x) & ") AND (BlockTestItem_Line = " & x & "));")
            Next
        End With


        Dim J_D As Decimal
        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 7
                J_D = CDec(.Text)
                .Col = 1
                J_D = J_D * CDec(.Text)
                .set_TextMatrix(.row, 5, FormatNumber(J_D, 4))
            Next
        End With
        QtyD_P = 0
        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 5
                QtyD_P = QtyD_P + CDec(.Text)
                'cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_CostkgTO = " & FormatNumber(CCur(.Text), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
                cnnDB.Execute("UPDATE BlockTestItem SET BlockTestItem_CostkgTO = " & CDec(.Text) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .get_RowData(x) & ") AND (BlockTestItem_Line = " & x & "));")
            Next
        End With
        lblTotalH.Text = FormatNumber(QtyD_P, 4)
        'total req


        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 7
                .set_TextMatrix(.row, 8, FormatNumber(CDec(.Text) / CDec(lblGP_Y.Text), 4))
                'cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_SuggSellPriceExcl = " & FormatNumber(CCur(.Text) / CCur(lblGP_Y.Caption), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
                cnnDB.Execute("UPDATE BlockTestItem SET BlockTestItem_SuggSellPriceExcl = " & (CDec(.Text) / CDec(lblGP_Y.Text)) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .get_RowData(x) & ") AND (BlockTestItem_Line = " & x & "));")
            Next
        End With


        Dim K_D As Decimal
        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 8
                K_D = CDec(.Text)
                .Col = 1
                K_D = K_D * CDec(.Text)
                .set_TextMatrix(.row, 9, FormatNumber(K_D, 4))
            Next
        End With
        QtyD_P = 0
        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 9
                QtyD_P = QtyD_P + CDec(.Text)
                'cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_TOSuggSellPriceExcl = " & FormatNumber(CCur(.Text), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
                cnnDB.Execute("UPDATE BlockTestItem SET BlockTestItem_TOSuggSellPriceExcl = " & CDec(.Text) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .get_RowData(x) & ") AND (BlockTestItem_Line = " & x & "));")
            Next
        End With
        lblTotalL.Text = FormatNumber(QtyD_P, 4)
        lblTotalLP.Text = FormatNumber(((CDec(lblTotalH.Text) - QtyD_P) / QtyD_P) * 100, 4)
        If CDec(lblTotalLP.Text) < 0 Then lblTotalLP.Text = CStr(0 - CDec(lblTotalLP.Text))
        'total req


        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 8
                .set_TextMatrix(.row, 10, FormatNumber(CDec(.Text) * CDec(lblX.Text), 4))
                'cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_SuggSellPriceIncl = " & FormatNumber(CCur(.Text) * CCur(lblX.Caption), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
                cnnDB.Execute("UPDATE BlockTestItem SET BlockTestItem_SuggSellPriceIncl = " & (CDec(.Text) * CDec(lblX.Text)) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .get_RowData(x) & ") AND (BlockTestItem_Line = " & x & "));")
            Next
        End With


        Dim N_X_D As Decimal
        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 11
                N_X_D = (CDec(.Text) / CDec(lblX.Text))
                .Col = 1
                N_X_D = N_X_D * CDec(.Text)
                .set_TextMatrix(.row, 12, FormatNumber(N_X_D, 4))
            Next
        End With
        QtyD_P = 0
        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 12
                QtyD_P = QtyD_P + CDec(.Text)
                'cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_TOActualSellExcl = " & FormatNumber(CCur(.Text), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
                cnnDB.Execute("UPDATE BlockTestItem SET BlockTestItem_TOActualSellExcl = " & CDec(.Text) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .get_RowData(x) & ") AND (BlockTestItem_Line = " & x & "));")
            Next
        End With
        lblTotalO.Text = FormatNumber(QtyD_P, 4)
        lblTotalOP.Text = FormatNumber(((CDec(lblTotalH.Text) - QtyD_P) / QtyD_P) * 100, 4)
        If CDec(lblTotalOP.Text) < 0 Then lblTotalOP.Text = CStr(0 - CDec(lblTotalOP.Text))
        'total req

        cmdTotal.Enabled = True
        'temporary


    End Sub

    Private Sub frmBlockTest_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If mbEditFlag Or mbAddNewFlag Then GoTo EventExitSub

        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Escape
                KeyAscii = 0
                cmdExit.Focus()
                System.Windows.Forms.Application.DoEvents()
                cmdExit_Click(cmdExit, New System.EventArgs())
        End Select
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub frmBlockTest_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtEdit.AddRange(New TextBox() {_txtEdit_0, _txtEdit_1, _txtEdit_2})
        Dim te As New TextBox
        For Each te In txtEdit
            AddHandler te.TextChanged, AddressOf txtEdit_TextChanged
            AddHandler te.Enter, AddressOf txtEdit_Enter
            AddHandler te.KeyDown, AddressOf txtEdit_KeyDown
            AddHandler te.KeyPress, AddressOf txtEdit_KeyPress
            AddHandler te.Leave, AddressOf txtEdit_Leave
        Next
    End Sub

    Private Sub frmBlockTest_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        Dim x As Short
        Dim lWidth As Short
        Dim lTop As Integer
        lTop = 420
        If lblContentExclusive.Visible Then
            lblContentExclusive.Top = twipsToPixels(lTop, False)
            _lblTotal_0.Top = twipsToPixels(lTop, False)
            lTop = lTop + pixelToTwips(lblContentExclusive.Height, False) + 30
        End If
        If txtR.Visible Then
            txtR.Top = twipsToPixels(lTop, False)
            _lblTotal_1.Top = twipsToPixels(lTop, False)
            lTop = lTop + pixelToTwips(txtR.Height, False) + 30
        End If
        If txtZ.Visible Then
            txtZ.Top = twipsToPixels(lTop, False)
            _lblTotal_2.Top = twipsToPixels(lTop, False)
            lTop = lTop + pixelToTwips(txtZ.Height, False) + 30
        End If
        If lblA.Visible Then
            lblA.Top = twipsToPixels(lTop, False)
            _lblTotal_3.Top = twipsToPixels(lTop, False)
            lTop = lTop + pixelToTwips(lblA.Height, False) + 30
        End If
        If lblB.Visible Then
            lblB.Top = twipsToPixels(lTop, False)
            _lblTotal_4.Top = twipsToPixels(lTop, False)
            lTop = lTop + pixelToTwips(lblB.Height, False) + 30
        End If
        If lblC.Visible Then
            lblC.Top = twipsToPixels(lTop, False)
            _lblTotal_5.Top = twipsToPixels(lTop, False)
            lTop = lTop + pixelToTwips(lblC.Height, False) + 30
        End If
        frmTotals.Height = twipsToPixels(lTop + 30, False)

        'frmTotals.Top = ScaleHeight - frmTotals.Height
        'frmTotals.Left = ScaleWidth - frmTotals.Width
        'lblReturns.Top = frmTotals.Top + (frmTotals.Height - lblReturns.Height) / 2
        'lblReturns.Left = frmTotals.Left - lblReturns.Width - 100
        'lblReturns.Visible = orderType
        'lstWorkspace.Height = ScaleHeight - lstWorkspace.Top

        'picForm.Top = 800
        'picForm.Left = 40
        'picForm.Height = ScaleHeight - picForm.Top '- frmTotals.Height
        'picForm.Width = ScaleWidth - picForm.Left

        'gridItem.Height = ScaleHeight - gridItem.Top - frmTotals.Height
        'gridItem.Height = picForm.ScaleHeight - gridItem.Top - frmTotals.Height
        gridItem.Width = twipsToPixels(pixelToTwips(ClientRectangle.Width, True) - pixelToTwips(gridItem.Left, True), True)
        'gridItem.Width = picForm.ScaleWidth - gridItem.Left

        lWidth = pixelToTwips(gridItem.Width, True) - 450
        For x = 0 To gridItem.Col - 1
            lWidth = lWidth - gridItem.get_ColWidth(x)
        Next
        lWidth = lWidth + gridItem.get_ColWidth(0)
        If lWidth > 200 Then
            gridItem.set_ColWidth(0, lWidth)
        Else
            gridItem.set_ColWidth(0, 2000)
        End If
        'gridItem_EnterCell
        If gridItem.RowCount > 1 Then
            'gridItem.Height = (gridItem.RowCount * gridItem.RowHeight(1)) + (gridItem.RowHeight(0) - 100)   ' ScaleHeight - gridItem.Top - frmTotals.Height
        End If
        gridItem.Top = twipsToPixels(pixelToTwips(gridItem.Top, False) + 20, False)
        picTotal.Top = twipsToPixels((pixelToTwips(ClientRectangle.Height, False) - _
                                           pixelToTwips(picTotal.Height, False)) - 100, False) 'gridItem.Top + gridItem.Height  '+ 20
        gridItem.Height = twipsToPixels((pixelToTwips(picTotal.Top, False) - 60) - _
                                         pixelToTwips(gridItem.Top, False), False) '(gridItem.Top - frmTotals.Height)
        picTotal.Left = gridItem.Left
    End Sub

    Private Sub setup()
        Dim colFractions As Integer
        Dim colDepositTotalInclusive As Integer
        Dim colDepositTotalExclusive As Integer
        Dim colDepositInclusive As Integer
        Dim colDepositExclusive As Integer
        Dim colContentTotalInclusive As Integer
        Dim colContentTotalExclusive As Integer
        Dim colContentInclusive As Integer
        Dim colPrice As Integer
        Dim colContentExclusive As Integer
        Dim colPackSize As Integer
        Dim colQuantity As Integer
        loading = True
        '    Dim lDOM As DOMDocument
        '    Dim lNode As IXMLDOMNode
        '    Dim lNodeList As IXMLDOMNodeList
        'lblSupplier.Caption = frmGRV.adoPrimaryRS("Supplier_Name") & "(" & frmGRV.adoPrimaryRS("PurchaseOrder_Reference") & ")"
        'lblReturns.Visible = orderType

        With gridItem
            gridItem.RowCount = 1
            gridItem.row = 0

            gridItem.Col = 13

            gridItem.set_RowHeight(0, 650) '430
            gridItem.Col = 1 'colTotalExclusive
            'gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, 1, "Cut Weight")
            gridItem.set_ColAlignment(1, 7)
            gridItem.set_ColWidth(1, 1000)

            gridItem.Col = 2 'colTotalInclusive
            'gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, 2, "M Related Selling Prices")
            gridItem.set_ColAlignment(2, 7)
            gridItem.set_ColWidth(2, 1000)

            gridItem.Col = 3 'colExclusive
            'gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, 3, "% of Weight (Yield)")
            gridItem.set_ColAlignment(3, 7)
            gridItem.set_ColWidth(3, 1000)

            gridItem.Col = 4 'colInclusive
            'gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, 4, "MR Selling ratio to R/kg")
            gridItem.set_ColAlignment(4, 7)
            gridItem.set_ColWidth(4, 1000)


            gridItem.Col = 5 'colVAT
            'gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, 5, "Cost x kg TO")
            gridItem.set_ColAlignment(5, 7)
            gridItem.set_ColWidth(5, 1000)

            gridItem.Col = 6 'colCode
            'gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, 6, "M Related TO")
            gridItem.set_ColAlignment(6, 7)
            gridItem.set_ColWidth(6, 1000)

            gridItem.Col = 7 'colName
            'gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, 7, "Primal Cost /kg Excl VAT")
            gridItem.set_ColAlignment(7, 7)
            gridItem.set_ColWidth(7, 1000)

            gridItem.Col = 8 'colBrokenPack
            'gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, 8, "Suggested Selling Prices Excl VAT")
            gridItem.set_ColAlignment(8, 7)
            gridItem.set_ColWidth(8, 1000)

            gridItem.Col = 9 'colDiscount
            'gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, 9, "TO Suggested Selling Prices Excl VAT")
            gridItem.set_ColAlignment(9, 7)
            gridItem.set_ColWidth(9, 1000)

            gridItem.Col = 10 'colDiscountLine
            'gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, 10, "Suggested Selling Prices Incl VAT")
            gridItem.set_ColAlignment(10, 7)
            gridItem.set_ColWidth(10, 1000)

            gridItem.Col = 11 'colDiscountPercentage
            'gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, 11, "Actual Selling Prices Incl VAT")
            gridItem.set_ColAlignment(11, 7)
            gridItem.set_ColWidth(11, 1000)

            gridItem.Col = 12 'colOnOrder
            'gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, 12, "TO at Actual Selling Excl VAT")
            gridItem.set_ColAlignment(12, 7)
            gridItem.set_ColWidth(12, 1000)

            gridItem.Col = colQuantity
            gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, colQuantity, "QTY")
            gridItem.set_ColAlignment(colQuantity, 7)
            gridItem.set_ColWidth(colQuantity, 1000)

            gridItem.Col = colPackSize
            gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, colPackSize, "P")
            gridItem.set_ColAlignment(colPackSize, 7)
            gridItem.set_ColWidth(colPackSize, 300)

            gridItem.Col = colContentExclusive
            gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, colContentExclusive, "Content Excl")
            gridItem.set_ColAlignment(colContentExclusive, 7)
            gridItem.set_ColWidth(colContentExclusive, 900)

            gridItem.Col = colPrice
            gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, colPrice, "Selling")
            gridItem.set_ColAlignment(colPrice, 7)
            gridItem.set_ColWidth(colPrice, 900)

            gridItem.Col = colContentInclusive
            gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, colContentInclusive, "Content Incl")
            gridItem.set_ColAlignment(colContentInclusive, 7)
            gridItem.set_ColWidth(colContentInclusive, 900)

            gridItem.Col = colContentTotalExclusive
            gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, colContentTotalExclusive, "Total Con Excl")
            gridItem.set_ColAlignment(colContentTotalExclusive, 7)
            gridItem.set_ColWidth(colContentTotalExclusive, 900)

            gridItem.Col = colContentTotalInclusive
            gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, colContentTotalInclusive, "Total Con Incl")
            gridItem.set_ColAlignment(colContentTotalInclusive, 7)
            gridItem.set_ColWidth(colContentTotalInclusive, 900)

            gridItem.Col = colDepositExclusive
            gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, colDepositExclusive, "Deposit Excl")
            gridItem.set_ColAlignment(colDepositExclusive, 7)
            gridItem.set_ColWidth(colDepositExclusive, 900)

            gridItem.Col = colDepositInclusive
            gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, colDepositInclusive, "Deposit Incl")
            gridItem.set_ColAlignment(colDepositInclusive, 7)
            gridItem.set_ColWidth(colDepositInclusive, 900)

            gridItem.Col = colDepositTotalExclusive
            gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, colDepositTotalExclusive, "Total Dep Excl")
            gridItem.set_ColAlignment(colDepositTotalExclusive, 7)
            gridItem.set_ColWidth(colDepositTotalExclusive, 900)

            gridItem.Col = colDepositTotalInclusive
            gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, colDepositTotalInclusive, "Total Dep Incl")
            gridItem.set_ColAlignment(colDepositTotalInclusive, 7)
            gridItem.set_ColWidth(colDepositTotalInclusive, 900)

            gridItem.Col = colFractions
            gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, colFractions, "")
            gridItem.set_ColAlignment(colFractions, 7)
            gridItem.set_ColWidth(colFractions, 1)

        End With
        loading = False
    End Sub

    Private Sub getRecItems(Optional ByRef retInfo As Boolean = False)
        Dim colQuantity As Integer
        Dim colPosPrice As Integer
        Dim colChannelPrice As Integer
        Dim colName As Integer
        Dim colTotalInclusive As Integer
        Dim colTotalExclusive As Integer
        Dim colInclusive As Integer
        Dim colExclusive As Integer
        Dim colOnOrder As Integer
        Dim colDiscountPercentage As Integer
        Dim colDiscountLine As Integer
        Dim colDiscount As Integer
        Dim colContentTotalInclusive As Integer
        Dim colContentTotalExclusive As Integer
        Dim colDepositTotalInclusive As Integer
        Dim colDepositTotalExclusive As Integer
        Dim colDepositInclusive As Integer
        Dim colDepositExclusive As Integer
        Dim colContentInclusive As Integer
        Dim colContentExclusive As Integer
        Dim colPackSize As Integer
        Dim colFractions As Integer
        Dim sql As String
        Dim gGRVFieldOrder As String = ""
        Dim gFieldOrder As String = ""
        Dim rs As ADODB.Recordset
        Dim oText As System.Windows.Forms.TextBox
        For Each oText In txtEdit
            oText.Visible = False
        Next oText
        '    Dim lNode As IXMLDOMNode
        '    Dim lNodeList As IXMLDOMNodeList
        Dim lCode As String
        If gGRVFieldOrder = "" Then
            lCode = gFieldOrder
        Else
            lCode = gGRVFieldOrder
        End If
        Dim x As Short

        If retInfo = True Then
            rs = getRS("SELECT BlockTestItem.BlockTestItem_StockItemID AS StockItemID, BlockTestItem.BlockTestItem_Name AS StockItem_Name, BlockTestItem.BlockTestItem_MRelatedSellPrice AS CatalogueChannelLnk_Price, BlockTestItem.BlockTestItem_ActualSellPriceIncl AS POSCatalogueChannelLnk_Price, BlockTestItem.BlockTestItem_CutWeight, BlockTestItem.BlockTestItem_PerWeightYield, BlockTestItem.BlockTestItem_MRSellingratio, BlockTestItem.BlockTestItem_CostkgTO, BlockTestItem.BlockTestItem_MRelatedTO, BlockTestItem.BlockTestItem_PrimalCostkgExclVAT, BlockTestItem.BlockTestItem_SuggSellPriceExcl, BlockTestItem.BlockTestItem_TOSuggSellPriceExcl, BlockTestItem.BlockTestItem_SuggSellPriceIncl, BlockTestItem.BlockTestItem_TOActualSellExcl From BlockTestItem Where (((BlockTestItem.BlockTestItem_BlockTestID) = " & testID & ")) ORDER BY BlockTestItem.BlockTestItem_Line;")
        Else
            'Set rs = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price, POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price, POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID, * FROM ((StockItem INNER JOIN RecipeStockitemLnk ON StockItem.StockItemID = RecipeStockitemLnk.RecipeStockitemLnk_StockitemID) INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) INNER JOIN POSCatalogueChannelLnk ON StockItem.StockItemID = POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID WHERE (((RecipeStockitemLnk.RecipeStockitemLnk_RecipeID)=" & gStockItemID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=2) AND ((POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID)=1) AND ((StockItem.StockItem_Disabled)=0) AND ((StockItem.StockItem_Discontinued)=0));")
            rs = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk_1.CatalogueChannelLnk_Price AS POSCatalogueChannelLnk_Price, CatalogueChannelLnk_1.CatalogueChannelLnk_ChannelID, * FROM ((StockItem INNER JOIN RecipeStockitemLnk ON StockItem.StockItemID = RecipeStockitemLnk.RecipeStockitemLnk_StockitemID) INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) INNER JOIN CatalogueChannelLnk AS CatalogueChannelLnk_1 ON StockItem.StockItemID = CatalogueChannelLnk_1.CatalogueChannelLnk_StockItemID WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=2) AND ((CatalogueChannelLnk_1.CatalogueChannelLnk_ChannelID)=1) AND ((RecipeStockitemLnk.RecipeStockitemLnk_RecipeID)=" & gStockItemID & ") AND ((StockItem.StockItem_Disabled)=0) AND ((StockItem.StockItem_Discontinued)=0));")
        End If


        If rs.RecordCount > 0 Then
        Else
            MsgBox("This Product does not have any Recipe.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, My.Application.Info.Title)
            Exit Sub
        End If

        loading = True
        With gridItem
            .Visible = False
            '            xsl:Sort select="" data-type="text" order="asending"
            .RowCount = rs.RecordCount + 1
            'ReDim StockItemLineID(Rows)
            x = 0
            Do Until rs.EOF
                x = x + 1
                .row = x
                .set_RowData(x, rs.Fields("StockItemID").Value)
                'StockItemLineID(x) = rs("StockItemID")

                If retInfo = True Then

                Else
                    sql = "INSERT INTO BlockTestItem ( BlockTestItem_BlockTestID, BlockTestItem_StockItemID, BlockTestItem_Name, BlockTestItem_MRelatedSellPrice, BlockTestItem_ActualSellPriceIncl, BlockTestItem_Line ) "
                    sql = sql & "SELECT " & testID & ", " & rs.Fields("StockItemID").Value & ", '" & Replace(rs.Fields("StockItem_Name").Value, "'", "''") & "', " & FormatNumber(rs.Fields("CatalogueChannelLnk_Price").Value, 2) & ", " & FormatNumber(rs.Fields("POSCatalogueChannelLnk_Price").Value, 2) & ", " & x & " FROM Company;"
                    cnnDB.Execute(sql)
                End If

                .Col = colFractions
                .set_TextMatrix(x, colFractions, 0) 'rs("StockItem_Fractions")

                .Col = colPackSize
                gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(222, 222, 222))
                .Col = colContentExclusive
                gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(222, 222, 222))
                .Col = colContentInclusive
                gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(212, 212, 212))

                .Col = colDepositExclusive
                gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(222, 222, 222))
                .Col = colDepositInclusive
                gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(212, 212, 212))

                .Col = colDepositTotalExclusive
                gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(220, 220, 255))
                .Col = colDepositTotalInclusive
                gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(200, 200, 255))

                .Col = colContentTotalExclusive
                gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(220, 220, 255))
                .Col = colContentTotalInclusive
                gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(200, 200, 255))

                .Col = colDiscount
                gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(222, 222, 200))
                .Col = colDiscountLine
                gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(222, 222, 200))
                .Col = colDiscountPercentage
                gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(222, 222, 200))
                .Col = colOnOrder
                gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(222, 222, 222))

                .Col = colExclusive
                gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(220, 255, 220))
                .Col = colInclusive
                gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(200, 255, 200))

                .Col = colTotalExclusive
                gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(220, 255, 220))
                .Col = colTotalInclusive
                gridItem.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(200, 255, 200))

                colName = 0
                colChannelPrice = 2
                colPosPrice = 11

                'If gStockItemID Then
                '    .TextMatrix(x, colName) = rs("StockItem_Name")
                '    .TextMatrix(x, 1) = "0.00"
                '    .TextMatrix(x, colChannelPrice) = FormatNumber(rs("CatalogueChannelLnk_Price"), 2)
                '    .TextMatrix(x, colPosPrice) = FormatNumber(rs("POSCatalogueChannelLnk_Price"), 2)
                'Else
                '    If IsNull(rs(gFieldDisplay)) Then
                '        .TextMatrix(x, colName) = rs("StockItem_Name")
                '    Else
                '        .TextMatrix(x, colName) = rs("StockItem_Name")
                '      ' .TextMatrix(x, colName) = rs(gFieldDisplay)
                '    End If
                'End If

                If retInfo = True Then
                    .set_TextMatrix(x, colName, rs.Fields("StockItem_Name").Value)
                    .set_TextMatrix(x, colChannelPrice, FormatNumber(rs.Fields("CatalogueChannelLnk_Price").Value, 2))
                    .set_TextMatrix(x, colPosPrice, FormatNumber(rs.Fields("POSCatalogueChannelLnk_Price").Value, 2))
                    .set_TextMatrix(x, 1, FormatNumber(rs.Fields("BlockTestItem_CutWeight").Value, 3))
                    .set_TextMatrix(x, 3, FormatNumber(rs.Fields("BlockTestItem_PerWeightYield").Value, 4))
                    .set_TextMatrix(x, 4, FormatNumber(rs.Fields("BlockTestItem_MRSellingratio").Value, 4))
                    .set_TextMatrix(x, 5, FormatNumber(rs.Fields("BlockTestItem_CostkgTO").Value, 4))
                    .set_TextMatrix(x, 6, FormatNumber(rs.Fields("BlockTestItem_MRelatedTO").Value, 4))
                    .set_TextMatrix(x, 7, FormatNumber(rs.Fields("BlockTestItem_PrimalCostkgExclVAT").Value, 4))
                    .set_TextMatrix(x, 8, FormatNumber(rs.Fields("BlockTestItem_SuggSellPriceExcl").Value, 4))
                    .set_TextMatrix(x, 9, FormatNumber(rs.Fields("BlockTestItem_TOSuggSellPriceExcl").Value, 4))
                    .set_TextMatrix(x, 10, FormatNumber(rs.Fields("BlockTestItem_SuggSellPriceIncl").Value, 4))
                    .set_TextMatrix(x, 12, FormatNumber(rs.Fields("BlockTestItem_TOActualSellExcl").Value, 4))
                Else
                    .set_TextMatrix(x, colName, rs.Fields("StockItem_Name").Value)
                    .set_TextMatrix(x, 1, "0.00")
                    .set_TextMatrix(x, colChannelPrice, FormatNumber(rs.Fields("CatalogueChannelLnk_Price").Value, 2))
                    .set_TextMatrix(x, colPosPrice, FormatNumber(rs.Fields("POSCatalogueChannelLnk_Price").Value, 2))
                End If

                displayLine(x)
                rs.MoveNext()
            Loop
            .Col = colQuantity
            .Visible = True
        End With
        loading = False
        'doTotals

        picTotal.Top = twipsToPixels(pixelToTwips(gridItem.Top, False) + _
                                    pixelToTwips(gridItem.Height, False) + 20, False)
    End Sub

    Private Sub displayLine(ByRef row As Object)
        'Dim lDiscount As Decimal
        ' With gridItem
        'lDiscount = .TextMatrix(row, colDiscount)
        'If activePrice = 1 Or activePrice = 3 Then
        '    lDiscount = lDiscount / (1 + .TextMatrix(row, colVAT) / 100)
        'End If
        '.TextMatrix(row, colDepositTotalExclusive) = FormatNumber(.TextMatrix(row, colDepositExclusive) * .TextMatrix(row, colQuantity), 2)
        '.TextMatrix(row, colContentTotalExclusive) = FormatNumber((.TextMatrix(row, colContentExclusive) - lDiscount) * .TextMatrix(row, colQuantity), 2)

        '.TextMatrix(row, colTotalExclusive) = FormatNumber(CCur(.TextMatrix(row, colContentTotalExclusive)) + CCur(.TextMatrix(row, colDepositTotalExclusive)), 2)
        '.TextMatrix(row, colExclusive) = FormatNumber(CCur(.TextMatrix(row, colContentExclusive)) + CCur(.TextMatrix(row, colDepositExclusive)), 2)

        '.TextMatrix(row, colContentInclusive) = FormatNumber(CCur(.TextMatrix(row, colContentExclusive)) + CCur(.TextMatrix(row, colContentExclusive)) * CCur(.TextMatrix(row, colVAT)) / 100, 2)
        '.TextMatrix(row, colDepositInclusive) = FormatNumber(CCur(.TextMatrix(row, colDepositExclusive)) + CCur(.TextMatrix(row, colDepositExclusive)) * CCur(.TextMatrix(row, colVAT)) / 100, 2)
        '.TextMatrix(row, colContentTotalInclusive) = FormatNumber(CCur(.TextMatrix(row, colContentTotalExclusive)) + CCur(.TextMatrix(row, colContentTotalExclusive)) * CCur(.TextMatrix(row, colVAT)) / 100, 2)
        '.TextMatrix(row, colDepositTotalInclusive) = FormatNumber(CCur(.TextMatrix(row, colDepositTotalExclusive)) + CCur(.TextMatrix(row, colDepositTotalExclusive)) * CCur(.TextMatrix(row, colVAT)) / 100, 2)

        '.TextMatrix(row, colTotalInclusive) = FormatNumber(CCur(.TextMatrix(row, colTotalExclusive)) + CCur(.TextMatrix(row, colTotalExclusive)) * CCur(.TextMatrix(row, colVAT)) / 100, 2)

        '.TextMatrix(row, colInclusive) = FormatNumber(CCur(.TextMatrix(row, colExclusive)) + CCur(.TextMatrix(row, colExclusive)) * CCur(.TextMatrix(row, colVAT)) / 100, 2)
        'If CCur(gridItem.TextMatrix(gridItem.row, colContentExclusive)) = 0 Then
        '    gridItem.TextMatrix(gridItem.row, colDiscountPercentage) = 0
        'Else
        '    gridItem.TextMatrix(gridItem.row, colDiscountPercentage) = FormatNumber(CCur(.TextMatrix(row, colDiscount)) / CCur(gridItem.TextMatrix(gridItem.row, colContentExclusive)) * 100, 2)
        'End If
        'gridItem.TextMatrix(gridItem.row, colDiscountLine) = FormatNumber(CCur(.TextMatrix(row, colDiscount)) * gridItem.TextMatrix(gridItem.row, colQuantity), 2)

        'End With

    End Sub

    Private Sub gridItem_EnterCell(ByVal eventSender As System.Object, ByVal eventArgs As EventArgs) Handles gridItem.Enter
        On Error GoTo gridItem_Err
        If loading Then Exit Sub
        loading = True
        With gridItem
            If .row Then
                If .Col = 1 Then 'colContentExclusive Then
                    _txtEdit_1.SetBounds(twipsToPixels(pixelToTwips(.Left, True) + .CellLeft, True), _
                                         twipsToPixels(pixelToTwips(.Top, False) + .CellTop, False), _
                                         twipsToPixels(.CellWidth, True), _
                                         twipsToPixels(.CellHeight, False))
                    _txtEdit_1.Text = .Text
                    _txtEdit_1.Tag = _txtEdit_1.Text
                    _txtEdit_1.Visible = True
                    _txtEdit_1.SelectionStart = 0
                    _txtEdit_1.SelectionLength = 9999
                    If Me.Visible Then _txtEdit_1.Focus()
                ElseIf .Col = 2 Or .Col = 11 Then
                    _txtEdit_1.SetBounds(twipsToPixels(pixelToTwips(.Left, True) + .CellLeft, True), _
                                         twipsToPixels(pixelToTwips(.Top, False) + .CellTop, False), _
                                         twipsToPixels(.CellWidth, True), twipsToPixels(.CellHeight, False))
                    _txtEdit_1.Text = .Text
                    _txtEdit_1.Tag = _txtEdit_1.Text
                    _txtEdit_1.Visible = True
                    _txtEdit_1.SelectionStart = 0
                    _txtEdit_1.SelectionLength = 9999
                    If Me.Visible Then _txtEdit_1.Focus()
                Else
                    _txtEdit_1.Visible = False
                End If
            End If
        End With
        loading = False

        Exit Sub
gridItem_Err:
        Resume Next
    End Sub
    Private Sub gridItem_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles gridItem.Enter
        '    txtEdit_GotFocus
    End Sub

    Private Sub gridItem_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles gridItem.KeyPress
        Select Case eventArgs.KeyChar
            Case Chr(40)
                eventArgs.KeyChar = Chr(0)
        End Select

    End Sub

    Private Sub gridItem_LeaveCell(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles gridItem.Leave
        'update
    End Sub

    Private Function moveNext(ByRef Index As Integer, ByRef direction As Integer) As Boolean
        Dim x As Integer
        Dim y As Integer
        On Error Resume Next

        x = gridItem.Row + direction
        If x >= gridItem.RowCount Or x < gridItem.FixedRows Then
        Else
            gridItem.Row = x
        End If

        With gridItem
            If .Row Then
                If .Col = 1 Then 'colContentExclusive Then
                    _txtEdit_1.SetBounds(twipsToPixels(pixelToTwips(.Left, True) + .CellLeft, True), _
                                         twipsToPixels(pixelToTwips(.Top, False) + .CellTop, False), _
                                         twipsToPixels(.CellWidth, True), _
                                         twipsToPixels(.CellHeight, False))
                    '_txtEdit_1.Text = CCur(.Text) * 100
                    If CDec(.Text) = 0 Then _txtEdit_1.Text = "" Else _txtEdit_1.Text = CStr(CDec(.Text)) '* 100
                    '_txtEdit_1.Tag = _txtEdit_1.Text
                    '_txtEdit_1.Visible = True
                    '_txtEdit_1.SelStart = 0
                    '_txtEdit_1.SelLength = 9999
                    'If Me.Visible Then _txtEdit_1.SetFocus
                ElseIf .Col = 2 Then
                    _txtEdit_1.SetBounds(twipsToPixels(pixelToTwips(.Left, True) + .CellLeft, True), _
                                         twipsToPixels(pixelToTwips(.Top, False) + .CellTop, False), _
                                         twipsToPixels(.CellWidth, True), _
                                         twipsToPixels(.CellHeight, False))
                    If CDec(.Text) = 0 Then _txtEdit_1.Text = "" Else _txtEdit_1.Text = CStr(CDec(.Text)) '* 100
                ElseIf .Col = 11 Then
                    _txtEdit_1.SetBounds(twipsToPixels(pixelToTwips(.Left, True) + .CellLeft, True), _
                                         twipsToPixels(pixelToTwips(.Top, False) + .CellTop, False), _
                                         twipsToPixels(.CellWidth, True), _
                                         twipsToPixels(.CellHeight, False))
                    If CDec(.Text) = 0 Then _txtEdit_1.Text = "" Else _txtEdit_1.Text = CStr(CDec(.Text)) '* 100
                Else
                    _txtEdit_1.Visible = False
                End If
            End If
        End With
        'txtEdit(Index).SelectionStart = 0
        'txtEdit(Index).SelectionLength = 999
        'If txtEdit(Index).Visible Then txtEdit(Index).Focus()

        moveNext = True
    End Function

    Private Sub txtEdit_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs)
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        'Dim Index As Short = txtEdit.GetIndex(eventSender)

        Dim Index As Integer
        Dim m As New TextBox
        Dim n As New TextBox
        n = DirectCast(eventSender, TextBox)
        Index = 0
        For Each m In txtEdit
            If m.Name <> n.Name Then
                Index = Index + 1
            End If
        Next

        If KeyCode = 40 Then
            loading = True
            calcP()
            moveNext(1, 1)
            loading = False
            'txtEdit(Index).SelStart = 0
            'txtEdit(Index).SelLength = 999
        ElseIf KeyCode = 38 Then
            loading = True
            calcP()
            moveNext(1, -1)
            loading = False
            'txtEdit(Index).SelStart = 0
            'txtEdit(Index).SelLength = 999
        End If

    End Sub

    Private Sub txtEdit_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'Dim Index As Short = txtEdit.GetIndex(eventSender)
        Dim Index As Integer
        Dim m As New TextBox
        Dim n As New TextBox
        n = DirectCast(eventSender, TextBox)
        Index = GetIndexer(n, txtEdit)

        ' Delete carriage returns to get rid of beep
        ' and only allow numbers.
        Select Case KeyAscii
            Case Asc(vbCr)
                gridItem.Focus()
                update_Renamed()
                KeyAscii = 0
            Case 8
            Case 48 To 57
            Case Else
                'If Index = 0 Then
                '    If CBool(gridItem.TextMatrix(gridItem.row, colFractions)) Then
                '    Else
                '        KeyAscii = 0
                '        Exit Sub
                '    End If
                'End If



        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtEdit_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'Dim Index As Short = txtEdit.GetIndex(eventSender)
        Dim Index As Integer
        Dim m As New TextBox
        Dim n As New TextBox
        n = DirectCast(eventSender, TextBox)
        Index = GetIndexer(n, txtEdit)
        Dim colPrice As Integer
        Dim colFractions As Integer
        Dim colQuantity As Integer
        If loading Then Exit Sub
        Dim lString As String
        With gridItem
            lString = txtEdit(Index).Text
            If lString = "." Then lString = "0."
            If .Row Then
                If lString = "" Then lString = "0"
                If CDec(lString) = 0 Then lString = ""
                If IsNumeric(lString) Then
                    Select Case Index
                        Case 0
                            If CBool(.get_TextMatrix(.Row, colFractions)) Then
                                .set_TextMatrix(.Row, colQuantity, FormatNumber(lString, 4))
                            Else
                                .set_TextMatrix(.Row, colQuantity, FormatNumber(lString, 0))
                            End If
                        Case 1
                            If .Col = 1 Then
                                .set_TextMatrix(.Row, 1, FormatNumber(lString, 3))
                            ElseIf .Col = 2 Then
                                .set_TextMatrix(.Row, 2, FormatNumber(lString, 2))
                            ElseIf .Col = 11 Then
                                .set_TextMatrix(.Row, 11, FormatNumber(lString, 2))
                            End If
                        Case 2
                            .set_TextMatrix(.Row, colPrice, FormatNumber(CDec(lString) / 100, 2))
                    End Select
                End If
                'displayLine .row
            End If
        End With
        'doTotals
    End Sub

    Private Sub txtEdit_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'Dim Index As Short = txtEdit.GetIndex(eventSender)
        update_Renamed()
        calcP()
    End Sub

    Private Sub calcP()
        Dim QtyD_P As Decimal
        Dim rowNo As Integer
        Dim x As Short
        loading = True
        On Error Resume Next
        If gridItem.Col = 1 Then
            rowNo = gridItem.row
            QtyD_P = 0
            With gridItem
                For x = 1 To (.RowCount - 1)
                    .row = x
                    .Col = 1
                    QtyD_P = QtyD_P + CDec(.Text)
                Next
            End With
            lblP.Text = FormatNumber(QtyD_P, 4)
            gridItem.row = rowNo
        End If
        loading = False
    End Sub
    Private Sub update_Renamed()
        If loading Then Exit Sub
        '    Dim lNode As IXMLDOMNode
        'Dim x As Integer
        'Dim sql As String
        Dim QtyD_P As Decimal
        On Error Resume Next

        Dim oText As System.Windows.Forms.TextBox
        Dim lUpdate As Boolean
        For Each oText In txtEdit
            If oText.Text = "" Then oText.Text = "0"
            If oText.Text <> oText.Tag Then
                lUpdate = True
            End If
        Next oText
        'If lUpdate Then
        Select Case gridItem.Col
            Case 1 'colContentExclusive
                'gridItem.TextMatrix(gridItem.row, 1) = FormatNumber(CCur(_txtEdit_1.Text) / 100, 2)
                gridItem.set_TextMatrix(gridItem.row, 1, FormatNumber(_txtEdit_1.Text, 3))
                '_txtEdit_1.Tag = _txtEdit_1.Text
            Case 2
                gridItem.set_TextMatrix(gridItem.row, 2, FormatNumber(_txtEdit_1.Text, 2))
            Case 11
                gridItem.set_TextMatrix(gridItem.row, 11, FormatNumber(_txtEdit_1.Text, 2))
        End Select
        'End If
    End Sub

    Private Sub txtEdit_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'Dim Index As Short = txtEdit.GetIndex(eventSender)
        'txtEdit(Index).SelStart = 0
        'txtEdit(Index).SelLength = 999
        On Error Resume Next
        With gridItem
            If .Row Then
                If .Col = 1 Then 'colContentExclusive Then
                    _txtEdit_1.SetBounds(twipsToPixels(pixelToTwips(.Left, True) + .CellLeft, True), _
                                         twipsToPixels(pixelToTwips(.Top, False) + .CellTop, False), _
                                         twipsToPixels(.CellWidth, True), _
                                         twipsToPixels(.CellHeight, False))
                    '_txtEdit_1.Text = CCur(.Text) * 100
                    If CDec(.Text) = 0 Then _txtEdit_1.Text = "" Else _txtEdit_1.Text = CStr(CDec(.Text)) '* 100
                    '_txtEdit_1.Tag = _txtEdit_1.Text
                    '_txtEdit_1.Visible = True
                    '_txtEdit_1.SelStart = 0
                    '_txtEdit_1.SelLength = 9999
                    'If Me.Visible Then _txtEdit_1.SetFocus
                ElseIf .Col = 2 Then
                    _txtEdit_1.SetBounds(twipsToPixels(pixelToTwips(.Left, True) + .CellLeft, True), _
                                         twipsToPixels(pixelToTwips(.Top, False) + .CellTop, False), _
                                         twipsToPixels(.CellWidth, True), _
                                         twipsToPixels(.CellHeight, False))
                    If CDec(.Text) = 0 Then _txtEdit_1.Text = "" Else _txtEdit_1.Text = CStr(CDec(.Text)) '* 100
                ElseIf .Col = 11 Then
                    _txtEdit_1.SetBounds(twipsToPixels(pixelToTwips(.Left, True) + .CellLeft, True), _
                                         twipsToPixels(pixelToTwips(.Top, False) + .CellTop, False), _
                                         twipsToPixels(.CellWidth, True), _
                                         twipsToPixels(.CellHeight, False))
                    If CDec(.Text) = 0 Then _txtEdit_1.Text = "" Else _txtEdit_1.Text = CStr(CDec(.Text)) '* 100
                Else
                    _txtEdit_1.Visible = False
                End If
            End If
        End With
        'txtEdit(Index).SelStart = 0
        'txtEdit(Index).SelLength = 999
    End Sub

    Private Sub txtR_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtR.Enter
        MyGotFocusNumericMEAT(txtR)
    End Sub

    Private Sub txtR_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtR.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'If KeyAscii = 27 Then
        '    'Unload Me
        'Else
        '    KeyPress KeyAscii
        'End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtR_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtR.Leave
        'LostFocus txtR, 2
    End Sub

    Private Sub txtReqGP_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtReqGP.Enter
        MyGotFocusNumericMEAT(txtReqGP)
    End Sub

    Private Sub txtVAT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtVAT.Enter
        MyGotFocusNumericMEAT(txtVAT)
    End Sub

    Private Sub txtZ_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtZ.Enter
        MyGotFocusNumericMEAT(txtZ)
    End Sub

    Private Sub txtZ_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtZ.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'If KeyAscii = 27 Then
        '    'Unload Me
        'Else
        '    KeyPress KeyAscii
        'End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtZ_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtZ.Leave
        'LostFocus txtZ, 2
    End Sub

    Public Sub loadItemSAVE(ByRef stockitemID As Integer, Optional ByRef quantity As Integer = 0)
        Dim colQuantity As Integer
        Dim oText As System.Windows.Forms.TextBox

        ResizeForm(Me, pixelToTwips(Me.Width, True), pixelToTwips(Me.Height, False), 2)

        setup()
        frmBlockTest_Resize(Me, New System.EventArgs())

        'Serial chk
        If checkSecurity() = True Then
        Else
            Me.Text = Me.Text & " - Trial"
            cmdReg.Visible = True
        End If

        If gridItem.RowCount Then
            loading = True
            gridItem.Col = 0
            gridItem.Row = 0
            loading = False
            For Each oText In txtEdit
                oText.Visible = False
            Next oText
            If gridItem.RowCount > 1 Then
                gridItem.Col = colQuantity
                gridItem.Row = 1
                _txtEdit_0.Visible = True
            Else
            End If
        End If
        loading = False

        gStockItemID = stockitemID
        gQuantity = quantity
        loadDataSAVE()
    End Sub

    Private Sub loadDataSAVE()
        Dim rs As ADODB.Recordset

        'Set rs = getRS("SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & gStockItemID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
        rs = getRS("SELECT BlockTest.*, StockItem.StockItem_Name, Person.Person_FirstName, Person.Person_LastName FROM (BlockTest INNER JOIN StockItem ON BlockTest.BlockTest_MainItemID = StockItem.StockItemID) INNER JOIN Person ON BlockTest.BlockTest_PersonID = Person.PersonID WHERE (((BlockTest.BlockTestID)=" & testID & "));")

        If rs.RecordCount Then
            lblContentExclusive.Text = rs.Fields("Person_FirstName").Value & " " & rs.Fields("Person_LastName").Value
            txtR.Text = FormatNumber(rs.Fields("BlockTest_PricePerKg").Value, 4)
            txtZ.Text = FormatNumber(rs.Fields("BlockTest_WeightCarcass").Value, 4)
            txtReqGP.Text = FormatNumber(rs.Fields("BlockTest_RequiredGP").Value, 4)
            txtVAT.Text = FormatNumber(rs.Fields("BlockTest_VAT").Value, 4)
            getRecItems(True)
            cmdTotal_ClickSAVE()
            If rs.Fields("BlockTest_BlockTestStatusID").Value = 3 Then
                txtR.ReadOnly = True
                txtZ.ReadOnly = True
                txtReqGP.ReadOnly = True
                txtVAT.ReadOnly = True

                gridItem.Enabled = False
                cmdProc.Enabled = False
                cmdTotal.Enabled = False
            End If
            ShowDialog()
        Else
            Me.Close()
            Exit Sub
        End If
    End Sub


    Private Sub cmdTotal_ClickSAVE()
        Dim QtyD_P As Decimal
        On Error Resume Next

        lblA.Text = FormatNumber(CDec(txtR.Text) * CDec(txtZ.Text), 4)


        lblGP_Y.Text = FormatNumber(CDec(1 - (CDec(CDbl(txtReqGP.Text) / 100))), 4)


        With gridItem
            For x = 1 To (.RowCount - 1)
                .Row = x
                .Col = 1
                QtyD_P = QtyD_P + CDec(.Text) ' .TextMatrix(.row, 1) = FormatNumber(CCur(_txtEdit_1.Text) / 100, 4)
                'cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_CutWeight = " & FormatNumber(CCur(.Text), 3) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
            Next
        End With
        lblP.Text = FormatNumber(QtyD_P, 4)


        lblB.Text = FormatNumber(CDec(txtZ.Text) - CDec(lblP.Text), 4)


        lblC.Text = FormatNumber(CDec(lblA.Text) / CDec(lblP.Text), 4)


        lblB_Z.Text = FormatNumber(CDec(lblB.Text) / CDec(txtZ.Text), 4)


        lblX.Text = FormatNumber(CDec(CDec(CDbl(txtVAT.Text) / 100) + 1), 4)


        'With gridItem
        '    For x = 1 To (.RowCount - 1)
        '        .row = x
        '        .Col = 1
        '        .TextMatrix(.row, 3) = FormatNumber((CCur(.Text) / CCur(txtZ.Text)) * 100, 4)
        '        '.Col = 3
        '        'QtyD_P = QtyD_P + CCur(.Text)
        '    Next
        'End With
        QtyD_P = 0
        With gridItem
            For x = 1 To (.RowCount - 1)
                .Row = x
                .Col = 3
                QtyD_P = QtyD_P + CDec(.Text)
                '        cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_PerWeightYield = " & FormatNumber(CCur(.Text), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
            Next
        End With
        lblTotalF.Text = FormatNumber(QtyD_P, 4)
        'total req


        'Dim D_E As Currency
        'With gridItem
        '    For x = 1 To (.RowCount - 1)
        '        .row = x
        '        .Col = 1
        '        D_E = CCur(.Text)
        '        .Col = 2
        '        D_E = D_E * CCur(.Text)
        '        .TextMatrix(.row, 6) = FormatNumber(D_E, 4)
        '    Next
        'End With
        QtyD_P = 0
        With gridItem
            For x = 1 To (.RowCount - 1)
                .Row = x
                .Col = 6
                QtyD_P = QtyD_P + CDec(.Text)
                '        cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_MRelatedTO = " & FormatNumber(CCur(.Text), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
            Next
        End With
        lblTotalQ.Text = FormatNumber(QtyD_P, 4)
        'total req


        Dim S_A_Q As Decimal
        S_A_Q = CDec(FormatNumber(CDec(lblA.Text) / CDec(lblTotalQ.Text), 4))
        '
        'With gridItem
        '    For x = 1 To (.RowCount - 1)
        '        .row = x
        '        .Col = 2
        '        '.TextMatrix(.row, 4) = FormatNumber((CCur(.Text) / CCur(lblC.Caption)) * CCur(lblGP_Y.Caption), 4)
        '        .TextMatrix(.row, 4) = FormatNumber((CCur(.Text) / CCur(lblC.Caption)) * CCur(S_A_Q), 4)
        '    Next
        'End With
        QtyD_P = 0
        With gridItem
            For x = 1 To (.RowCount - 1)
                .Row = x
                .Col = 4
                QtyD_P = QtyD_P + CDec(.Text)
                '        cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_MRSellingratio = " & FormatNumber(CCur(.Text), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
            Next
        End With
        lblTotalG.Text = FormatNumber(QtyD_P, 4)
        'total req


        'With gridItem
        '    For x = 1 To (.RowCount - 1)
        '        .row = x
        '        .Col = 4
        '        .TextMatrix(.row, 7) = FormatNumber(CCur(lblC.Caption) * CCur(.Text), 4)
        '        cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_PrimalCostkgExclVAT = " & FormatNumber(CCur(lblC.Caption) * CCur(.Text), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
        '    Next
        'End With


        'Dim J_D As Currency
        'With gridItem
        '    For x = 1 To (.RowCount - 1)
        '        .row = x
        '        .Col = 7
        '        J_D = CCur(.Text)
        '        .Col = 1
        '        J_D = J_D * CCur(.Text)
        '        .TextMatrix(.row, 5) = FormatNumber(J_D, 4)
        '    Next
        'End With
        QtyD_P = 0
        With gridItem
            For x = 1 To (.RowCount - 1)
                .Row = x
                .Col = 5
                QtyD_P = QtyD_P + CDec(.Text)
                '        cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_CostkgTO = " & FormatNumber(CCur(.Text), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
            Next
        End With
        lblTotalH.Text = FormatNumber(QtyD_P, 4)
        'total req


        'With gridItem
        '    For x = 1 To (.RowCount - 1)
        '        .row = x
        '        .Col = 7
        '        .TextMatrix(.row, 8) = FormatNumber(CCur(.Text) / CCur(lblGP_Y.Caption), 4)
        '        cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_SuggSellPriceExcl = " & FormatNumber(CCur(.Text) / CCur(lblGP_Y.Caption), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
        '    Next
        'End With


        'Dim K_D As Currency
        'With gridItem
        '    For x = 1 To (.RowCount - 1)
        '        .row = x
        '        .Col = 8
        '        K_D = CCur(.Text)
        '        .Col = 1
        '        K_D = K_D * CCur(.Text)
        '        .TextMatrix(.row, 9) = FormatNumber(K_D, 4)
        '    Next
        'End With
        QtyD_P = 0
        With gridItem
            For x = 1 To (.RowCount - 1)
                .Row = x
                .Col = 9
                QtyD_P = QtyD_P + CDec(.Text)
                '        cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_TOSuggSellPriceExcl = " & FormatNumber(CCur(.Text), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
            Next
        End With
        lblTotalL.Text = FormatNumber(QtyD_P, 4)
        'total req


        'With gridItem
        '    For x = 1 To (.RowCount - 1)
        '        .row = x
        '        .Col = 8
        '        .TextMatrix(.row, 10) = FormatNumber(CCur(.Text) * CCur(lblX.Caption), 4)
        '        cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_SuggSellPriceIncl = " & FormatNumber(CCur(.Text) * CCur(lblX.Caption), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
        '    Next
        'End With


        'Dim N_X_D As Currency
        'With gridItem
        '    For x = 1 To (.RowCount - 1)
        '        .row = x
        '        .Col = 11
        '        N_X_D = (CCur(.Text) / CCur(lblX.Caption))
        '        .Col = 1
        '        N_X_D = N_X_D * CCur(.Text)
        '        .TextMatrix(.row, 12) = FormatNumber(N_X_D, 4)
        '    Next
        'End With
        QtyD_P = 0
        With gridItem
            For x = 1 To (.RowCount - 1)
                .Row = x
                .Col = 12
                QtyD_P = QtyD_P + CDec(.Text)
                '        cnnDB.Execute "UPDATE BlockTestItem SET BlockTestItem_TOActualSellExcl = " & FormatNumber(CCur(.Text), 4) & " WHERE ((BlockTestItem_BlockTestID = " & testID & ") AND (BlockTestItem_StockItemID = " & .RowData(x) & ") AND (BlockTestItem_Line = " & x & "));"
            Next
        End With
        _lblTotal_0.Text = FormatNumber(QtyD_P, 4)
        'total req

    End Sub

    Private Function getSerialNumber() As String
        Dim fso As New Scripting.FileSystemObject
        Dim fsoFolder As Scripting.Folder
        getSerialNumber = ""
        If fso.FolderExists(serverPath) Then
            fsoFolder = fso.GetFolder(serverPath)
            getSerialNumber = CStr(fsoFolder.Drive.SerialNumber)
        End If
    End Function

    Private Function Encrypt(ByVal secret As String, ByVal PassWord As String) As String
        Dim l As Integer
        Dim x As Short
        Dim Char_Renamed As String
        l = Len(PassWord)
        For x = 1 To Len(secret)
            Char_Renamed = CStr(Asc(Mid(PassWord, (x Mod l) - l * CShort((x Mod l) = 0), 1)))
            Mid(secret, x, 1) = Chr(Asc(Mid(secret, x, 1)) Xor Char_Renamed)
        Next
        Encrypt = secret
    End Function

    Private Function checkSecurity() As Boolean
        Dim intMonth As Integer
        Dim intYear As Integer
        Dim lCode As String
        Dim leCode As String
        Dim lPassword As String
        Dim rs As ADODB.Recordset
        Dim x As Short
        checkSecurity = False
        Dim strSerial As String
        Dim strTmp As String
        Dim intDate As Short
        Dim dtDate As String
        Dim dtMonth As String
        Dim dtYear As String
        Dim stPass As String ' clsCryptoAPI
        Dim cCrypto As clsCryptoAPI
        If openConnection() Then
            rs = getRS("SELECT * From Company")
            If rs.RecordCount Then

                'if old database don't chk secuirty
                If rs.Fields.Count <= 55 Then checkSecurity = True : Exit Function

                If IsDBNull(rs.Fields("Company_ResMS").Value) Then checkSecurity = False : Exit Function


                cCrypto = New clsCryptoAPI 'clsCryptoAPI
                System.Windows.Forms.Application.DoEvents()
                strTmp = cCrypto.ConvertStringFromHex(VB.Left(rs.Fields("Company_ResMS").Value, Len(rs.Fields("Company_ResMS").Value) - 5))
                System.Windows.Forms.Application.DoEvents()
               arData = cCrypto.StringToByteArray(strTmp)
                System.Windows.Forms.Application.DoEvents()
                arPWord = cCrypto.StringToByteArray(Val(VB.Right(rs.Fields("Company_ResMS").Value, 5)))
                System.Windows.Forms.Application.DoEvents()
                cCrypto.PassWord = arPWord
                System.Windows.Forms.Application.DoEvents()
                cCrypto.InputData = System.Text.UnicodeEncoding.Unicode.GetString(arData)
                System.Windows.Forms.Application.DoEvents()

                ' Decrypt the data input from the encrypted text box
                'If cCrypto.Decrypt(g_intHashType, m_intCipher) Then
                'UPGRADE_WARNING: Couldn't resolve default property of object cCrypto.Decrypt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If cCrypto.Decrypt(2, 1) Then
                    System.Windows.Forms.Application.DoEvents()
                    'UPGRADE_WARNING: Couldn't resolve default property of object cCrypto.OutputData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    arData = cCrypto.OutputData.Clone()
                    'UPGRADE_WARNING: Couldn't resolve default property of object cCrypto.ByteArrayToString. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    strSerial = cCrypto.ByteArrayToString(arData)
                End If

                If VB.Left(strSerial, 3) = "met" Then

                    'Create date password
                    If IsNumeric(Mid(strSerial, 4, Len(strSerial))) Then

                        checkSecurity = True
                        GoTo jumpOut

                        strSerial = Mid(strSerial, 4, Len(strSerial))
                        intYear = Mid(strSerial, 5, 2)
                        intMonth = Mid(strSerial, 3, 2)
                        intDate = CShort(VB.Left(strSerial, 2))

                        If (intDate / 2) = System.Math.Round(intDate / 2) Then
                            intDate = intDate / 2
                        Else
                            GoTo jumpOut
                        End If

                        If (intMonth / 3) = System.Math.Round(intMonth / 3) Then
                            intMonth = intMonth / 3
                        Else
                            GoTo jumpOut
                        End If

                        If (intYear / 4) = System.Math.Round(intYear / 4) Then
                            intYear = intYear / 4
                        Else
                            GoTo jumpOut
                        End If

                        stPass = "20"
                        If Len(CStr(intYear)) = 1 Then
                            stPass = stPass & "0" & intYear & "/"
                        Else
                            stPass = stPass & intYear & "/"
                        End If
                        If Len(CStr(intMonth)) = 1 Then
                            stPass = stPass & "0" & intMonth & "/"
                        Else
                            stPass = stPass & intMonth & "/"
                        End If
                        If Len(CStr(intDate)) = 1 Then stPass = stPass & "0" & intDate Else stPass = stPass & intDate

                        If IsDate(stPass) Then
                            If CDate(stPass) >= (System.DateTime.FromOADate(Today.ToOADate - 31)) Then
                                checkSecurity = True
                            End If
                        End If

                    Else
                        'MsgBox "Not a Valid 4MEAT Key!", vbCritical
                    End If
                Else
                    'MsgBox "Not a Valid 4MEAT Key!", vbCritical
                End If
jumpOut:
                'UPGRADE_NOTE: Object cCrypto may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                cCrypto = Nothing ' Free the Crypto class from memory
                strTmp = New String(Chr(0), 250) ' overwrite data in temp variable
                Exit Function

            Else
                MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS")
                'End
            End If
        Else
            MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS")
            'End
        End If
    End Function

    Private Function timeOver() As Boolean
        Dim rs As ADODB.Recordset

        timeOver = False
        'If openConnection() Then
        rs = getRS("SELECT * From Company")
        If rs.RecordCount Then

            'if old database don't chk secuirty
            If rs.Fields.Count <= 55 Then timeOver = False : Exit Function

            If rs.Fields("Company_ResMN").Value < 20 Then
                If rs.Fields("Company_ResMN").Value = 11 Then MsgBox("You have 7 more Calculations to run before the demo software expires." & vbCrLf & "Please contact your 4POS representative or www.4pos.co.za.", MsgBoxStyle.Critical, "4MEAT is not Registered")
                cnnDB.Execute("UPDATE Company SET Company_ResMN = Company_ResMN+1;")
                timeOver = False
            ElseIf rs.Fields("Company_ResMN").Value >= 20 Then
                timeOver = True
            End If
            Exit Function

        Else
            MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS")
            'End
        End If
        'Else
        '    MsgBox "Unable to locate the '4POS Application Suite' database.", vbCritical, "4POS"
        '    End
        'End If
    End Function
End Class