Option Strict Off
Option Explicit On
Option Compare Text
Imports VB = Microsoft.VisualBasic
Friend Class frmVegTest
	Inherits System.Windows.Forms.Form
	
	'serialization
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim mbChangedByCode As Boolean
	Dim mvBookMark As Integer
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
	Dim gID As Integer
	Dim k_posID As Integer
	Dim k_posNew As Boolean
    Dim txtEdit As New List(Of TextBox)
	
	Dim flag As Boolean
	Dim y As Single
	Dim c As Short
	Dim YY As Short
	Dim x As Short
	Private Declare Function BitBlt Lib "gdi32" (ByVal hDestDC As Integer, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hSrcDC As Integer, ByVal xSrc As Integer, ByVal ySrc As Integer, ByVal dwRop As Integer) As Integer
	
	Dim obj As System.Drawing.Image = New System.Drawing.Bitmap(1, 1)
	Private Declare Function GetDriveType Lib "kernel32"  Alias "GetDriveTypeA"(ByVal nDrive As String) As Integer
	
	Dim fox(8) As Object
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
	Dim bFinish As Boolean
	Dim cPackVol As Decimal
	
	Dim testName As String
	Dim testType As String
	Dim testID As Integer
	Dim StockItemLineID() As Integer
	
	Public Sub Reset_frmEncStrings()
		Dim strMsg As String
		
		Erase arData
		Erase arPWord
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
		Dim rsLoad As ADODB.Recordset
		Dim lGRVID As Integer
		
		frmVegTestSelect.loadTest(testType, testID)
		cPackVol = 0
		
reType: 
		If testType = "exit" Then
			Me.Close()
			Exit Sub
			
		ElseIf testType = "new" Then 
			testName = InputBox("Please enter short Name/Title for Veg Production Test.", "Please enter short Name/Title for Veg Production Test.")
			If testName = "" Then GoTo reType
			
			lID = frmStockList.getItem
			'lGRVID = frmVegTestGRV.getGRVID
			
			If lID <> 0 Then
				'On Local Error Resume Next
				rs = getRS("SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity From WarehouseStockItemLnk WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID)=" & lID & ") AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));")
				If rs.RecordCount Then
					If rs.Fields("WarehouseStockItemLnk_Quantity").Value > 0 Then
						AvailGRV.Text = FormatNumber(rs.Fields("WarehouseStockItemLnk_Quantity").Value, 2)
						'txtZ.Text = FormatNumber(rs("GRVItem_QuantityTotalKG"), 2)
						'lblA = FormatNumber(rs("GRVItem_QuantityUsedKG"), 2)
						lblB.Text = AvailGRV.Text
					Else
						MsgBox("Insufficient Qty in Main Stock Item!")
						Me.Close()
						Exit Sub
					End If
				Else
					MsgBox("Main Stock Item doest not have Qty to be used!")
					Me.Close()
					Exit Sub
				End If
				
				'txtR.Text = FormatNumber(rs("GRVItem_ActualCost") / rs("GRVItem_PackSizeVol"), 4)
				'cPackVol = rs("GRVItem_PackSizeVol")
				sql = "INSERT INTO VegTest ( VegTest_DayEndID, VegTest_VegTestStatusID, VegTest_Date, VegTest_MainItemID, VegTest_PersonID, VegTest_Desc, VegTest_PricePerKg, VegTest_WeightCarcass, VegTest_RequiredGP, VegTest_VAT, VegTest_Notes, VegTest_GRVID, VegTest_PackSize ) "
				sql = sql & "SELECT Company.Company_DayEndID, 1 AS status, Now(), " & lID & ", " & frmMenu.lblUser.Tag & ", '" & VB.Left(Replace(testName, "'", "''"), 49) & "', " & 0 & ", 0, 0, 0, '', " & 0 & ", " & 0 & " FROM Company;"
				cnnDB.Execute(sql)
				rs = getRS("SELECT Max(VegTestID) AS id FROM VegTest;")
				testID = rs.Fields("id").Value
				
				loadItem(lID)
			End If
			
		ElseIf testType = "load" Then 
			rs = getRS("SELECT * FROM VegTest WHERE VegTestID = " & testID & ";")
			If rs.RecordCount Then
				
				rsLoad = getRS("SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity From WarehouseStockItemLnk WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID)=" & rs.Fields("VegTest_MainItemID").Value & ") AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));")
				If rsLoad.RecordCount Then
					If rsLoad.Fields("WarehouseStockItemLnk_Quantity").Value > 0 Then
						AvailGRV.Text = FormatNumber(rsLoad.Fields("WarehouseStockItemLnk_Quantity").Value, 2)
						lblB.Text = AvailGRV.Text
					Else
						MsgBox("Insufficient Qty in Main Stock Item!")
						Me.Close()
						Exit Sub
					End If
				Else
					MsgBox("Main Stock Item is not part of Selected Market/GRV!")
					Me.Close()
					Exit Sub
				End If
				
				'txtR.Text = FormatNumber(rsLoad("GRVItem_ActualCost") / rs("VegTest_PackSize"), 2)
				'cPackVol = rs("VegTest_PackSize")
				loadItemSAVE(rs.Fields("VegTest_MainItemID").Value) 'lID
				
			Else
				MsgBox("Problem while loading Test")
			End If
		End If
		
	End Sub
	
	Private Sub loadData()
		Dim rs As ADODB.Recordset
		Dim rj As ADODB.Recordset
		
		'Set rs = getRS("SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & gStockItemID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
		rs = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_Name, RecipeStockitemLnk.RecipeStockitemLnk_Quantity, [StockItem_ListCost]/[StockItem_Quantity] AS cost, PriceChannelLnk.PriceChannelLnk_Price FROM (RecipeStockitemLnk INNER JOIN StockItem ON RecipeStockitemLnk.RecipeStockitemLnk_StockitemID = StockItem.StockItemID) INNER JOIN PriceChannelLnk ON StockItem.StockItemID = PriceChannelLnk.PriceChannelLnk_StockItemID Where (((RecipeStockitemLnk.RecipeStockitemLnk_RecipeID) = " & gStockItemID & ") And ((StockItem.StockItem_Discontinued) = False) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = 1) And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1)) ORDER BY StockItem.StockItem_Name;")
		If rs.RecordCount Then
			'lblStockItem.Caption = rs("StockItem_Name")
			'lblPromotion.Caption = rs("Promotion_Name")
			'txtPrice.Text = rs("CatalogueChannelLnk_Price") * 100
			'txtPrice_LostFocus
			'cmbQuantity.Tag = rs("CatalogueChannelLnk_Quantity")
			lblContentExclusive.Text = frmMenu.lblUser.Text
			getRecItems()
			ShowDialog()
		Else
			Me.Close()
			Exit Sub
		End If
		
	End Sub
	
	Public Sub loadItem(ByRef stockitemID As Integer, Optional ByRef quantity As Integer = 0)
        Dim colQuantity As Integer
        Dim oText As New TextBox
		
        ResizeForm(Me, pixelToTwips(Me.Width, True), pixelToTwips(Me.Height, False), 2)
		
		setup()
		frmVegTest_Resize(Me, New System.EventArgs())
		
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

    'Private Sub CreateVegItems(csvBarcode As String, csvPRG As String, csvDESC As String, csvSell As Currency, csvCost As Currency, csvSTG_RPG As String, csvVAT As String)
    Private Sub CreateVegItems(ByRef sID As Integer, ByRef sSellPrice As Decimal, ByRef sPackVol As Decimal, ByRef lgetNewID As Integer)
        Dim newATItem As Boolean
        Dim sql As String
        Dim gBrandItem As Integer
        Dim gStockItem As Integer

        System.Windows.Forms.Application.DoEvents()
        gStockItem = 0
       gBrandItem = 0
        On Error GoTo cErrorHndlr
        'Dim rsSupp          As Recordset
        'Dim rsDep          As Recordset
        'Dim rsPriceG          As Recordset
        'Dim rsStockG          As Recordset
        'Dim rsReportG          As Recordset
        Dim rs As ADODB.Recordset
        Dim rsCostPrice As ADODB.Recordset
        Dim aCost As Decimal
        Dim sPrice As Decimal

        sql = "SELECT StockItem.StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_ListCost, StockItem.StockItem_ActualCost, Catalogue.Catalogue_Barcode "
        sql = sql & "FROM (StockItem INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID "
        sql = sql & "WHERE (((StockItem.StockItemID)=" & sID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)=1) AND ((Catalogue.Catalogue_Quantity)=1));"
        rsCostPrice = getRS(sql)

        sql = "INSERT INTO StockItem ( StockItem_BrandItemID, StockItem_SupplierID, StockItem_ShrinkID, StockItem_PackSizeID, StockItem_PricingGroupID, StockItem_StockGroupID, StockItem_VatID, StockItem_DepositID, StockItem_Name, StockItem_ReceiptName, StockItem_Quantity, StockItem_ListCost, StockItem_ActualCost, StockItem_MinimumStock, StockItem_MaximumStock, StockItem_OrderQuantity, StockItem_OrderRounding, StockItem_OrderDynamic, StockItem_Disabled, StockItem_Discontinued, StockItem_SupplierCode, StockItem_ActualCostChange, StockItem_PriceSetID, StockItem_LastCost, StockItem_Parameters, StockItem_Fractions, StockItem_NegSale, StockItem_VariablePrice, StockItem_NonWeighted, StockItem_PrintLocationID, StockItem_RecipeType, StockItem_PrintGroupID, StockItem_SerialTracker, StockItem_SBarcode, StockItem_SShelf, StockItem_ReportID, StockItemOrderType, StockItem_ATItem, StockItem_ATStockTypeID, StockItem_ExpiryDays ) "
        sql = sql & "SELECT StockItem.StockItem_BrandItemID, StockItem.StockItem_SupplierID, StockItem.StockItem_ShrinkID, StockItem.StockItem_PackSizeID, StockItem.StockItem_PricingGroupID, StockItem.StockItem_StockGroupID, StockItem.StockItem_VatID, StockItem.StockItem_DepositID, [StockItem].[StockItem_Name] & ' # " & Format(Today, "dd/mm") & "' AS StockItemName, [StockItem].[StockItem_ReceiptName] & ' # " & Format(Today, "dd/mm") & "' AS StockItemReceiptName, StockItem.StockItem_Quantity, " & (CDec(IIf(sPackVol = 0, 1, sPackVol) * CDec(txtR.Text))) & " AS StockItemListCost, " & (CDec(IIf(sPackVol = 0, 1, sPackVol) * CDec(txtR.Text))) & " AS StockItemActualCost, StockItem.StockItem_MinimumStock, StockItem.StockItem_MaximumStock, StockItem.StockItem_OrderQuantity, StockItem.StockItem_OrderRounding, StockItem.StockItem_OrderDynamic, StockItem.StockItem_Disabled, StockItem.StockItem_Discontinued, "
        'sql = sql & "SELECT StockItem.StockItem_BrandItemID, StockItem.StockItem_SupplierID, StockItem.StockItem_ShrinkID, StockItem.StockItem_PackSizeID, StockItem.StockItem_PricingGroupID, StockItem.StockItem_StockGroupID, StockItem.StockItem_VatID, StockItem.StockItem_DepositID, [StockItem].[StockItem_Name] & ' # " & Format(Date, "dd/mm") & "' AS StockItemName, [StockItem].[StockItem_ReceiptName] & ' # " & Format(Date, "dd/mm") & "' AS StockItemReceiptName, StockItem.StockItem_Quantity, " & CCur(txtR.Text) & " AS StockItemListCost, " & CCur(txtR.Text) & " AS StockItemActualCost, StockItem.StockItem_MinimumStock, StockItem.StockItem_MaximumStock, StockItem.StockItem_OrderQuantity, StockItem.StockItem_OrderRounding, StockItem.StockItem_OrderDynamic, StockItem.StockItem_Disabled, StockItem.StockItem_Discontinued, StockItem.StockItem_SupplierCode, StockItem.StockItem_ActualCostChange, StockItem.StockItem_PriceSetID, "
        sql = sql & "StockItem.StockItem_SupplierCode, StockItem.StockItem_ActualCostChange, StockItem.StockItem_PriceSetID, StockItem.StockItem_LastCost, StockItem.StockItem_Parameters, StockItem.StockItem_Fractions, StockItem.StockItem_NegSale, StockItem.StockItem_VariablePrice, StockItem.StockItem_NonWeighted, StockItem.StockItem_PrintLocationID, StockItem.StockItem_RecipeType, StockItem.StockItem_PrintGroupID, StockItem.StockItem_SerialTracker, StockItem.StockItem_SBarcode, StockItem.StockItem_SShelf, StockItem.StockItem_ReportID, StockItem.StockItemOrderType, StockItem.StockItem_ATItem, StockItem.StockItem_ATStockTypeID, StockItem.StockItem_ExpiryDays "
        sql = sql & "From StockItem WHERE (((StockItem.StockItemID)=" & sID & "));"
        'sql = "INSERT INTO StockItem (StockItem_BrandItemID, StockItem_SupplierID, StockItem_ShrinkID, StockItem_PackSizeID, StockItem_PricingGroupID, StockItem_StockGroupID, StockItem_VatID, StockItem_DepositID, StockItem_Name, StockItem_ReceiptName, StockItem_Quantity, StockItem_ListCost, StockItem_ActualCost, StockItem_MinimumStock, StockItem_MaximumStock, StockItem_OrderQuantity, StockItem_OrderRounding, StockItem_OrderDynamic, StockItem_Disabled, StockItem_Discontinued, StockItem_QuickKey, StockItem_NegSale, StockItem_PrintLocationID, StockItem_SerialTracker, StockItem_ReportID, StockItem_ATItem, StockItem_ATStockTypeID) VALUES ("
        'sql = sql & gBrandItem & ", " & 2 & ", " & 1 & ", " & 1 & ", " & rsPriceG(0) & ", " & rsStockG(0) & ", 2, " & rsDep(0) & ", '" & csvDESC & "', '" & csvDESC & "', " & Replace(1, ",", "") & ", " & Replace(aCost, ",", "") & ", " & Replace(aCost, ",", "") & ", 0, 0, " & CCur(1) & ", 1, 0, 0, 0, '" & csvBarcode & "', True, 1, True, " & rsReportG(0) & ", True, 0)"
        Debug.Print(sql)
        cnnDB.Execute(sql)

        sql = "SELECT Max(StockItem.StockItemID) AS id FROM StockItem;"
        rs = getRS(sql)
        gStockItem = rs.Fields("id").Value
        lgetNewID = gStockItem
        cnnDB.Execute("UPDATE StockItem, Company SET StockItem.StockItem_LastCost = [Company_DayEndID] WHERE (((StockItem.StockItemID)=" & gStockItem & "));")
        cnnDB.Execute("UPDATE StockItem INNER JOIN BrandItemSupplier ON (StockItem.StockItem_SupplierID = BrandItemSupplier.BrandItemSupplier_SupplierID) AND (StockItem.StockItem_BrandItemID = BrandItemSupplier.BrandItemSupplier_BrandItemID) SET StockItem.StockItem_SupplierCode = [BrandItemSupplier]![BrandItemSupplier_Code] WHERE (((StockItem.StockItemID)=" & gStockItem & "));")
        'Multi Warehouse change
        'cnnDB.Execute "INSERT INTO DayEndStockItemLnk ( DayEndStockItemLnk_DayEndID, DayEndStockItemLnk_StockItemID, DayEndStockItemLnk_Quantity, DayEndStockItemLnk_QuantitySales, DayEndStockItemLnk_QuantityShrink, DayEndStockItemLnk_QuantityGRV, DayEndStockItemLnk_ListCost, DayEndStockItemLnk_ActualCost, DayEndStockItemLnk_Warehouse ) SELECT Company.Company_DayEndID, " & gStockItem & " AS stock, 0, 0, 0, 0, " & rsCostPrice("StockItem_ListCost") & ", " & rsCostPrice("StockItem_ListCost") & ", Warehouse.WarehouseID FROM Company, Warehouse;"
        cnnDB.Execute("INSERT INTO DayEndStockItemLnk ( DayEndStockItemLnk_DayEndID, DayEndStockItemLnk_StockItemID, DayEndStockItemLnk_Quantity, DayEndStockItemLnk_QuantitySales, DayEndStockItemLnk_QuantityShrink, DayEndStockItemLnk_QuantityGRV, DayEndStockItemLnk_ListCost, DayEndStockItemLnk_ActualCost, DayEndStockItemLnk_Warehouse ) SELECT Company.Company_DayEndID, " & gStockItem & " AS stock, 0, 0, 0, 0, " & (CDec(IIf(sPackVol = 0, 1, sPackVol) * CDec(txtR.Text))) & ", " & (CDec(IIf(sPackVol = 0, 1, sPackVol) * CDec(txtR.Text))) & ", Warehouse.WarehouseID FROM Company, Warehouse;")
        cnnDB.Execute("INSERT INTO WarehouseStockItemLnk ( WarehouseStockItemLnk_WarehouseID, WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk_Quantity ) SELECT Warehouse.WarehouseID, " & gStockItem & ", 0 FROM Warehouse;")
        cnnDB.Execute("INSERT INTO tempStockItem ( tempStockItemID ) SELECT StockItem.StockItemID FROM tempStockItem RIGHT JOIN StockItem ON tempStockItem.tempStockItemID = StockItem.StockItemID WHERE (((tempStockItem.tempStockItemID) Is Null) AND ((StockItem.StockItemID)=" & gStockItem & "));")
        cnnDB.Execute("DELETE FROM systemStockItemPricing;")
        cnnDB.Execute("INSERT INTO systemStockItemPricing ( systemStockItemPricing ) VALUES (" & gStockItem & ")")

        'cnnDB.Execute "INSERT INTO Catalogue (Catalogue_StockItemID,Catalogue_Quantity,Catalogue_Barcode) VALUES (" & gStockItem & ",1,'" & buildItemBarcode(gStockItem, 1) & "')"
        'UPGRADE_WARNING: Couldn't resolve default property of object gStockItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        cnnDB.Execute("INSERT INTO Catalogue (Catalogue_StockItemID,Catalogue_Quantity,Catalogue_Barcode) VALUES (" & gStockItem & ",1,'" & rsCostPrice.Fields("Catalogue_Barcode").Value & Format(Today, "ddmmyy") & "')")

        'Override
        cnnDB.Execute("INSERT INTO PriceChannelLnk ( PriceChannelLnk_StockItemID, PriceChannelLnk_Quantity, PriceChannelLnk_ChannelID, PriceChannelLnk_Price ) VALUES (" & gStockItem & "," & 1 & ",1," & sSellPrice & ")")
        cnnDB.Execute("UPDATE PriceChannelLnk SET PriceChannelLnk_Price=" & sSellPrice & " WHERE PriceChannelLnk_StockItemID = " & gStockItem & ";")
        newATItem = True
        Dim catalog As New frmUpdateCatalogue
        catalog.Show()

        Exit Sub
cErrorHndlr:
        MsgBox(Err.Description)
        Resume Next

    End Sub

    Private Sub cmdProc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdProc.Click
        Dim QtyD_P_GRV As Integer
        Dim QtyD_P As Integer
        Dim x As Short
        'If txtR.Text = "" Then txtR.Text = 0
        'If CCur(txtR.Text) > 0 Then
        'Else
        '    MsgBox "Please enter the Price Per Kg."
        '    txtR.SetFocus
        '    Exit Sub
        'End If

        loading = True
        bFinish = True
        On Error Resume Next
        'If gridItem.Col = 1 Then
        '    rowNo = gridItem.row
        QtyD_P = 0
        QtyD_P_GRV = 0
        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 3
                QtyD_P = QtyD_P + CDec(.Text)
            Next
        End With
        TotalQTY.Text = FormatNumber(QtyD_P, 2)
        'TotalQTY = FormatNumber(QtyD_P_GRV, 4)
        'If TotalQTY > AvailGRV Then
        '    MsgBox "Insufficient Qty in Main Stock Item! Please correct your last entered QTY."
        'End If
        'gridItem.row = rowNo
        'End If

        loading = False

        If TotalQTY.Text = "" Then TotalQTY.Text = CStr(0)
        If CDec(TotalQTY.Text) > 0 Then
        Else
            MsgBox("Please enter the QTY you wish to make.")
            bFinish = False
            Exit Sub
        End If

        If lblB.Text = "" Then lblB.Text = CStr(0)
        'txtZ.Text = AvailGRV
        If CDec(TotalQTY.Text) > CDec(lblB.Text) Then
            MsgBox("Total QTY after production is more then Available Market/GRV QTY. Call Your Supervisor for Override?", MsgBoxStyle.Question + MsgBoxStyle.ApplicationModal + MsgBoxStyle.DefaultButton1, My.Application.Info.Title)
            If frmOverride.sOverride(0) Then
                'update the GRV processer person id
                'cnnDB.Execute "UPDATE GRV SET GRV.GRV_OverridePersonID = " & lMgrID & " WHERE (((GRV.GRVID)=" & frmGRV.adoPrimaryRS("GRVID") & "));"
            Else
                MsgBox("You do not have Supervisor rights. Call Your Supervisor for Override?", MsgBoxStyle.Question + MsgBoxStyle.ApplicationModal + MsgBoxStyle.DefaultButton1, My.Application.Info.Title)
                bFinish = False
                Exit Sub
            End If
            'Exit Sub
        End If

        'Serial chk
        If checkSecurity = True Then
            cmdTotal_Click(cmdTotal, New System.EventArgs())
            If updateProc Then Me.Close()
        Else
            If timeOver Then
                MsgBox("Your 4VEG Production Software has expired." & vbCrLf & "Please contact your 4POS representative or www.4pos.co.za.", MsgBoxStyle.Critical, "4VEG Production is not Registered")
                bFinish = False
                Exit Sub
            Else
                cmdTotal_Click(cmdTotal, New System.EventArgs())
                If updateProc Then Me.Close()
            End If
        End If

        bFinish = False

    End Sub

    Private Function updateProc() As Boolean
        Dim strFldName As String
        On Error GoTo UpdateErr

        Dim rs As ADODB.Recordset
        Dim rj As ADODB.Recordset
        Dim RSadoPrimary As ADODB.Recordset
        Dim rsBarcode As ADODB.Recordset
        Dim FSO As New Scripting.FileSystemObject
        Dim sql As String
        Dim lQuantity As Decimal
        Dim getNewID As Integer

        'If checkSecurity = True Then
        '    'for Security Code
        '    If bolSecurityCode = True Then
        '        'loadCustom
        'Set rs = getRS("SELECT * from VegTestItem Where VegTestItem_VegTestID = " & testID & ";")
        rs = getRS("SELECT VegTestItem.*, StockItem.StockItemID, StockItem.StockItem_SBarcode FROM VegTestItem INNER JOIN StockItem ON VegTestItem.VegTestItem_StockItemID = StockItem.StockItemID WHERE (((VegTestItem.VegTestItem_VegTestID)=" & testID & "));")
        If rs.RecordCount > 0 Then
            'UPGRADE_WARNING: Couldn't resolve default property of object strFldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            strFldName = "HandHeldID Number,Handheld_Barcode Text(50), Quantity Currency"
           cnnDB.Execute("CREATE TABLE " & "HandheldVegTest" & " (" & strFldName & ")")
            System.Windows.Forms.Application.DoEvents()
            sql = "INSERT INTO HandheldVegTest (HandHeldID,Handheld_Barcode,Quantity) VALUES (" & gStockItemID & ", 0, " & (0 - (CDec(TotalQTY.Text))) & ")"
            cnnDB.Execute(sql)
            System.Windows.Forms.Application.DoEvents()
            Do While rs.EOF = False
                If rs.Fields("VegTestItem_PerWeightYield").Value > 0 Then
                    getNewID = 0
                    If rs.Fields("StockItem_SBarcode").Value = True Then
                        getNewID = rs.Fields("VegTestItem_StockItemID").Value
                        'create new
                        'CreateVegItems rs("VegTestItem_StockItemID"), rs("VegTestItem_ActualSellPriceIncl"), rs("VegTestItem_PackSize"), getNewID   ' csvSplit(0), csvSplit(1), csvSplit(2), CCur(csvSplit(3)), CCur(csvSplit(4)), csvSplit(6), csvSplit(7)
                    Else
                        getNewID = rs.Fields("VegTestItem_StockItemID").Value
                    End If
                    'Stock Adjustment
                    sql = "INSERT INTO HandheldVegTest (HandHeldID,Handheld_Barcode,Quantity) VALUES (" & getNewID & ", 0, " & (rs.Fields("VegTestItem_PerWeightYield")).Value & ")"
                    cnnDB.Execute(sql)
                End If
                rs.moveNext()
            Loop
        Else
            MsgBox("This Product does not have any Recipe.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
            Exit Function
        End If
        '    Else
        '        MsgBox "New Stock Items cannot be added due to Security Restrictions." & vbCrLf & "Please contact your 4POS representative or www.4pos.co.za.", vbCritical, "4POS Expired"
        '        Exit Function
        '    End If
        '    'for Security Code
        'Else
        '    Set rs = getRS("SELECT * From Company")
        '    If rs.RecordCount Then
        '        If IsNull(rs("Company_TerminateDate")) Then
        '            cnnDB.Execute "UPDATE Company SET Company_TerminateDate = #" & Date & "#;"
        '            Set rs = getRS("SELECT * From Company")
        '        End If
        '        If Date >= CDate(rs("Company_TerminateDate") + 15) Then
        '            MsgBox "New Stock Items may only be added with registered versions of your 4POS system." & vbCrLf & "Please contact your 4POS representative or www.4pos.co.za.", vbCritical, "4POS Expired"
        '            Exit Function
        '        Else
        '            'loadCustom
        '            Set rs = getRS("SELECT * from VegTestItem Where VegTestItem_VegTestID = " & testID & ";")
        '            If rs.RecordCount > 0 Then
        '                    strFldName = "HandHeldID Number,Handheld_Barcode Text(50), Quantity Currency"
        '                    cnnDB.Execute "CREATE TABLE " & "HandheldVegTest" & " (" & strFldName & ")"
        '                    DoEvents
        '                    sql = "INSERT INTO HandheldVegTest (HandHeldID,Handheld_Barcode,Quantity) VALUES (" & gStockItemID & ", 0, " & (0 - (CCur(TotalQTY.Text) / cPackVol)) & ")"
        '                    cnnDB.Execute sql
        '                    DoEvents
        '                    Do While rs.EOF = False
        '                        If rs("VegTestItem_CutWeight") > 0 Then
        '                            getNewID = 0
        '                            'create new
        '                            CreateVegItems rs("VegTestItem_StockItemID"), rs("VegTestItem_ActualSellPriceIncl"), rs("VegTestItem_PackSize"), getNewID  ' csvSplit(0), csvSplit(1), csvSplit(2), CCur(csvSplit(3)), CCur(csvSplit(4)), csvSplit(6), csvSplit(7)
        '                            'Stock Adjustment
        '                            sql = "INSERT INTO HandheldVegTest (HandHeldID,Handheld_Barcode,Quantity) VALUES (" & getNewID & ", 0, " & (rs("VegTestItem_CutWeight")) & ")"
        '                            cnnDB.Execute sql
        '                        End If
        '                        rs.moveNext
        '                    Loop
        '            Else
        '                MsgBox "This Product does not have any Recipe.", vbApplicationModal + vbInformation + vbOKOnly, App.title
        '                Exit Function
        '            End If
        '        End If
        '    End If
        'End If
        'MsgBox "Items activated"

        '---------------------------------------------
        cnnDB.Execute("INSERT INTO StockGroup (StockGroup_Name) VALUES ('HandheldVegTest')")
        stTableName = "HandheldVegTest"
        rj = getRS("SELECT StockGroup.StockGroupID, StockGroup.StockGroup_Name From StockGroup WHERE StockGroup.StockGroup_Name = 'HandheldVegTest';")
        gID = rj.Fields("StockGroupID").Value

        'snap shot
        cnnDB.Execute("UPDATE Company SET Company.Company_StockTakeDate = now();")
        'Multi Warehouse change
        cnnDB.Execute("DELETE FROM StockTake WHERE (StockTake_WarehouseID > 0)")
        cnnDB.Execute("INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment ) SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, 0 AS quantity, 0 AS adjustment FROM WarehouseStockItemLnk;")
        cnnDB.Execute("UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)>0));")
        'Multi Warehouse change
        ' cnnDB.Execute "UPDATE StockTake SET StockTake.StockTake_Adjustment = [StockTake]![StockTake_Quantity];"
        cnnDB.Execute("DELETE FROM StockTakeDeposit")
        cnnDB.Execute("INSERT INTO StockTakeDeposit ( StockTakeDeposit_WarehouseID, StockTakeDeposit_DepositID, StockTakeDeposit_DepositTypeID, StockTakeDeposit_Quantity, StockTakeDeposit_Adjustment ) SELECT WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity FROM WarehouseDepositItemLnk INNER JOIN DISPLAY_Deposits ON (DISPLAY_Deposits.type = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = DISPLAY_Deposits.DepositID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID = DISPLAY_Deposits.WarehouseID);")
        'snap shot

        RSadoPrimary = getRS("SELECT StockItem.StockItem_Name, " & stTableName & ".Quantity, StockItem.StockItem_Quantity," & stTableName & ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" & stTableName & " INNER JOIN StockItem ON " & stTableName & ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " & gID & ") And ((Warehouse.WarehouseID) = 2)) ORDER BY StockItem.StockItem_Name")
        If RSadoPrimary.RecordCount > 0 Then
            Do While RSadoPrimary.EOF = False
                lQuantity = RSadoPrimary.Fields("Quantity").Value
                'lQuantity = RSadoPrimary("Quantity") - RSadoPrimary("StockTake_Quantity").OriginalValue
                cnnDB.Execute("UPDATE StockTake SET StockTake.StockTake_Quantity = " & lQuantity & " WHERE (((StockTake.StockTake_StockItemID)=" & RSadoPrimary.Fields("StockTake_StockItemID").Value & ") AND ((StockTake.StockTake_WarehouseID)=2));")
                cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & RSadoPrimary.Fields("StockTake_StockItemID").Value & ") AND ((StockTake.StockTake_WarehouseID)=2));")
                'cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = 0 WHERE (((StockTake.StockTake_StockItemID)=" & RSadoPrimary("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
                cnnDB.Execute("UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" & lQuantity & ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & RSadoPrimary.Fields("StockTake_StockItemID").Value & "));")
                RSadoPrimary.moveNext()
            Loop
        End If

        'Update POS
        'Set rsPri = getRS("SELECT GRVItem.GRVItem_StockItemID, (GRVItem.GRVItem_Quantity*GRVItem_PackSize) AS GRVItem_Quantity, StockItem.StockItem_SBarcode,StockItem.StockItem_SShelf FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE GRVItem_GRVID = " & Val(frmGRV.adoPrimaryRS("GRVID")) & " AND (StockItem_SBarcode = True Or StockItem_SShelf = True)")
        'Set rsBarcode = getRS("SELECT HandheldVegTest.HandHeldID AS GRVItem_StockItemID, HandheldVegTest.Quantity AS GRVItem_Quantity, StockItem.StockItem_SBarcode, StockItem.StockItem_SShelf FROM HandheldVegTest INNER JOIN StockItem ON HandheldVegTest.HandHeldID = StockItem.StockItemID WHERE (((HandheldVegTest.Quantity)>0));")
        rsBarcode = getRS("SELECT HandheldVegTest.HandHeldID AS GRVItem_StockItemID, HandheldVegTest.Quantity AS GRVItem_Quantity, StockItem.StockItem_SBarcode, StockItem.StockItem_SShelf FROM HandheldVegTest INNER JOIN StockItem ON HandheldVegTest.HandHeldID = StockItem.StockItemID WHERE (((HandheldVegTest.Quantity)>0) AND ((StockItem.StockItem_SBarcode)=True)) OR (((StockItem.StockItem_SShelf)=True));")
        'Write file
        If rsBarcode.RecordCount Then
            If FSO.FileExists(serverPath & "ShelfBarcode.dat") Then FSO.DeleteFile(serverPath & "ShelfBarcode.dat", True)
            rsBarcode.save(serverPath & "ShelfBarcode.dat", ADODB.PersistFormatEnum.adPersistADTG)
            grvPrin = True
            'If MsgBox("Do you want to do Shelf/Barcode Printing on flagged StockItems?", vbQuestion + vbYesNo + vbApplicationModal + vbDefaultButton1, App.title) = vbYes Then

            blMEndUpdatePOS = True
            blChangeOnlyUpdatePOS = True
            frmUpdatePOScriteria.ShowDialog()
            blChangeOnlyUpdatePOS = False
            blMEndUpdatePOS = False

            frmBarcode.ShowDialog()
        End If

        cnnDB.Execute("DROP TABLE HandheldVegTest")
        cnnDB.Execute("DELETE * FROM StockGroup WHERE StockGroup_Name ='HandheldVegTest'")
        cnnDB.Execute("UPDATE VegTest SET VegTest_VegTestStatusID = 3 WHERE (VegTestID = " & testID & ")")
        'cnnDB.Execute "UPDATE VegTest INNER JOIN GRVItem ON (VegTest.VegTest_GRVID = GRVItem.GRVItem_GRVID) AND (VegTest.VegTest_MainItemID = GRVItem.GRVItem_StockItemID) SET GRVItem.GRVItem_QuantityUsedKG = " & CCur(TotalQTY.Text) & " WHERE (((VegTest.VegTestID)=" & testID & "));"

        MsgBox("Veg Production Test process has been completed.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
        updateProc = True

        Exit Function
UpdateErr:
        MsgBox(Err.Description)
        updateProc = True
    End Function

    Private Function getSerialNumber() As String
        Dim FSO As New Scripting.FileSystemObject
        Dim fsoFolder As Scripting.Folder
        Dim fsoDrive As Scripting.Drive
        getSerialNumber = ""
        If FSO.FolderExists(serverPath) Then
            fsoFolder = FSO.GetFolder(serverPath)
            getSerialNumber = CStr(fsoFolder.Drive.SerialNumber)
        End If
    End Function

    Private Function Encrypt(ByVal secret As String, ByVal password As String) As String
        Dim l As Integer
        Dim x As Short
        Dim Char_Renamed As String
        l = Len(password)
        For x = 1 To Len(secret)
            Char_Renamed = CStr(Asc(Mid(password, (x Mod l) - l * CShort((x Mod l) = 0), 1)))
            Mid(secret, x, 1) = Chr(Asc(Mid(secret, x, 1)) Xor Char_Renamed)
        Next
        Encrypt = secret
    End Function

    Private Function bolSecurityCode() As Boolean
        Dim lCode As String
        Dim leCode As String
        Dim lPassword As String
        Dim rs As ADODB.Recordset
        Dim x As Short

        Dim intDate As Short
        Dim intYear As Short
        Dim intMonth As Short

        Dim stPass As String
        Dim givPass As String

        On Error GoTo Hell_Error

        bolSecurityCode = False
        If openConnection() Then
            rs = getRS("SELECT * From Company")
            If rs.RecordCount Then
                If IsNumeric(rs.Fields("Company_PosString").Value) Then
                    gSecKey = rs.Fields("Company_PosString").Value
                    If Len(rs.Fields("Company_PosString").Value) = 13 Then
                        bolSecurityCode = True
                        Exit Function
                    End If
                End If

                'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                If IsDbNull(rs.Fields("Company_PosString").Value) Or rs.Fields("Company_PosString").Value = "0" Then
                    bolSecurityCode = True
                    Exit Function
                End If

                If IsNumeric(rs.Fields("Company_PosString").Value) Then
                    intYear = CShort(VB.Left(rs.Fields("Company_PosString").Value, 2))
                    intMonth = CShort(Mid(rs.Fields("Company_PosString").Value, 3, 2))
                    intDate = CShort(Mid(rs.Fields("Company_PosString").Value, 5, 2))

                    If (intDate / 2) = System.Math.Round(intDate / 2) Then
                        intDate = intDate / 2
                    Else
                        Exit Function
                    End If


                    If (intMonth / 2) = System.Math.Round(intMonth / 2) Then
                        intMonth = intMonth / 2
                    Else
                        Exit Function
                    End If


                    If (intYear / 2) = System.Math.Round(intYear / 2) Then
                        intYear = intYear / 2
                    Else
                        Exit Function
                    End If

                    stPass = "20"
                    If Len(CStr(intYear)) = 1 Then stPass = stPass & "0" & intYear & "/" Else stPass = stPass & intYear & "/"
                    If Len(CStr(intMonth)) = 1 Then stPass = stPass & "0" & intMonth & "/" Else stPass = stPass & intMonth & "/"
                    If Len(CStr(intDate)) = 1 Then stPass = stPass & "0" & intDate Else stPass = stPass & intDate

                    If IsDate(stPass) Then
                        If CDate(stPass) >= Today Then
                            bolSecurityCode = True
                            Exit Function
                        End If
                    End If

                    'If Left(rs("Company_PosString"), 2) >= Year(Date) And Mid(rs("Company_PosString"), 3, 2) >= Month(Date) And Mid(rs("Company_PosString"), 5) >= Day(Date) Then
                    '    bolSecurityCode = True
                    '    Exit Function
                    'Else
                    '    Exit Function
                    'End If

                Else
                    Exit Function
                End If

            End If
        Else
            MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS")
            End
        End If

        Exit Function
Hell_Error:
        MsgBox(Err.Number & " - " & Err.Description, MsgBoxStyle.Exclamation)
        Exit Function
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
        Dim strTmp As Object
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

                If IsDbNull(rs.Fields("Company_ResMS").Value) Then checkSecurity = False : Exit Function


                cCrypto = New clsCryptoAPI 'clsCryptoAPI
                System.Windows.Forms.Application.DoEvents()
                'strTmp = cCrypto.ConvertStringFromHex(Left(rs("Company_ResMS"), 6))
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
                If cCrypto.Decrypt(2, 1) Then
                    System.Windows.Forms.Application.DoEvents()
                    arData = cCrypto.OutputData.Clone()
                    strSerial = cCrypto.ByteArrayToString(arData)
                End If

                If VB.Left(strSerial, 3) = "veg" Then

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
                            If CDate(stPass) >= (System.Date.FromOADate(Today.ToOADate - 31)) Then
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
        Dim lCode As String
        Dim leCode As String
        Dim lPassword As String
        Dim rs As ADODB.Recordset
        Dim x As Short
        timeOver = False
        'If openConnection() Then
        rs = getRS("SELECT * From Company")
        If rs.RecordCount Then

            'if old database don't chk secuirty
            If rs.Fields.Count <= 55 Then timeOver = False : Exit Function

            If rs.Fields("Company_ResMN").Value < 5 Then
                If rs.Fields("Company_ResMN").Value = 2 Then MsgBox("You have 1 more Calculations to run before the demo software expires." & vbCrLf & "Please contact your 4POS representative or www.4pos.co.za.", MsgBoxStyle.Critical, "4VEG Production is not Registered")
                cnnDB.Execute("UPDATE Company SET Company_ResMN = Company_ResMN+1;")
                timeOver = False
            ElseIf rs.Fields("Company_ResMN").Value >= 5 Then
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

    Private Function checkSecurityPOS() As Boolean
        Dim lCode As String
        Dim leCode As String
        Dim lPassword As String
        Dim rs As ADODB.Recordset
        Dim x As Short
        checkSecurityPOS = False
        If openConnection() Then
            rs = getRS("SELECT * From Company")
            If rs.RecordCount Then
                If IsNumeric(rs.Fields("Company_Code").Value) Then
                    gSecKey = rs.Fields("Company_Code").Value
                    If Len(rs.Fields("Company_Code").Value) = 13 Then

                        checkSecurityPOS = True
                        Exit Function
                    End If
                End If
                lPassword = "pospospospos"
                lCode = getSerialNumber
                If lCode = "0" And LCase(VB.Left(serverPath, 3)) <> "c:\" And rs.Fields("Company_Code").Value <> "" Then
                    checkSecurityPOS = True
                Else
                    leCode = Encrypt(lCode, lPassword)
                    For x = 1 To Len(leCode)
                        If Asc(Mid(leCode, x, 1)) < 33 Then
                            leCode = VB.Left(leCode, x - 1) & Chr(33) & Mid(leCode, x + 1)
                        End If
                    Next x

                    If rs.Fields("Company_Code").Value = leCode Then
                        'If IsNull(rs("Company_TerminateDate")) Then
                        checkSecurityPOS = True
                        'Else
                        '    If Date > rs("Company_TerminateDate") Then
                        '        cnnDB.Execute "UPDATE Company SET Company.Company_Code = '';"
                        '        checkSecurityPOS = False
                        Exit Function
                        '   End If
                        'End If
                    Else
                        'txtCompany.Text = rs("Company_Name")
                        'txtCompany.SelStart = 0
                        'txtCompany.SelLength = 999
                        'show 1
                    End If

                End If
            Else
                MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS")
                End
            End If
        Else
            MsgBox("Unable to locate the '4POS Application Suite' database.", MsgBoxStyle.Critical, "4POS")
            End
        End If
    End Function


    Private Function updateProc_OLD() As Boolean
        Dim strFldName As String
        On Error GoTo UpdateErr

        Dim rs As ADODB.Recordset
        Dim rj As ADODB.Recordset
        Dim RSadoPrimary As ADODB.Recordset
        Dim sql As String
        Dim lQuantity As Decimal

        rs = getRS("SELECT * from VegTestItem Where VegTestItem_VegTestID = " & testID & ";")
        If rs.RecordCount > 0 Then

            strFldName = "HandHeldID Number,Handheld_Barcode Text(50), Quantity Currency"
            cnnDB.Execute("CREATE TABLE " & "HandheldVegTest" & " (" & strFldName & ")")
            System.Windows.Forms.Application.DoEvents()
            sql = "INSERT INTO HandheldVegTest (HandHeldID,Handheld_Barcode,Quantity) VALUES (" & gStockItemID & ", 0, " & (0 - CDec(txtZ.Text)) & ")"
            cnnDB.Execute(sql)
            System.Windows.Forms.Application.DoEvents()

            Do While rs.EOF = False
                sql = "INSERT INTO HandheldVegTest (HandHeldID,Handheld_Barcode,Quantity) VALUES (" & rs.Fields("VegTestItem_StockItemID").Value & ", 0, " & (rs.Fields("VegTestItem_CutWeight")).Value & ")"
                cnnDB.Execute(sql)
                rs.moveNext()
            Loop

        Else
            MsgBox("This Product does not have any Recipe.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
            Exit Function
        End If
        cnnDB.Execute("INSERT INTO StockGroup (StockGroup_Name) VALUES ('HandheldVegTest')")
        stTableName = "HandheldVegTest"
        rj = getRS("SELECT StockGroup.StockGroupID, StockGroup.StockGroup_Name From StockGroup WHERE StockGroup.StockGroup_Name = 'HandheldVegTest';")
        gID = rj.Fields("StockGroupID").Value

        'snap shot
        cnnDB.Execute("UPDATE Company SET Company.Company_StockTakeDate = now();")
        cnnDB.Execute("DELETE FROM StockTake WHERE (StockTake_WarehouseID = 2)")
        cnnDB.Execute("INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment ) SELECT StockItem.StockItemID, 2 AS warehouse, 0 AS quantity, 0 AS adjustment FROM StockItem;")
        cnnDB.Execute("UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));")
        cnnDB.Execute("DELETE FROM StockTakeDeposit")
        cnnDB.Execute("INSERT INTO StockTakeDeposit ( StockTakeDeposit_WarehouseID, StockTakeDeposit_DepositID, StockTakeDeposit_DepositTypeID, StockTakeDeposit_Quantity, StockTakeDeposit_Adjustment ) SELECT WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity FROM WarehouseDepositItemLnk INNER JOIN DISPLAY_Deposits ON (DISPLAY_Deposits.type = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = DISPLAY_Deposits.DepositID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID = DISPLAY_Deposits.WarehouseID);")
        'snap shot

        'Set RSadoPrimary = getRS("SELECT StockItem.StockItem_Name, " & stTableName & ".Quantity, StockItem.StockItem_Quantity," & stTableName & ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" & stTableName & " INNER JOIN StockItem ON " & stTableName & ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " & gID & ") And ((Warehouse.WarehouseID) = 2) And ((StockItem.StockItem_Disabled) = False) And ((StockItem.StockItem_Discontinued) = False)) ORDER BY StockItem.StockItem_Name")
        RSadoPrimary = getRS("SELECT StockItem.StockItem_Name, " & stTableName & ".Quantity, StockItem.StockItem_Quantity," & stTableName & ".HandHeldID, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID FROM ((" & stTableName & " INNER JOIN StockItem ON " & stTableName & ".HandHeldID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN (StockTake INNER JOIN Warehouse ON StockTake.StockTake_WarehouseID = Warehouse.WarehouseID) ON StockItem.StockItemID = StockTake.StockTake_StockItemID Where (((StockGroup.StockGroupID) < " & gID & ") And ((Warehouse.WarehouseID) = 2)) ORDER BY StockItem.StockItem_Name")
        If RSadoPrimary.RecordCount > 0 Then
            Do While RSadoPrimary.EOF = False
                lQuantity = RSadoPrimary.Fields("Quantity").Value
                'lQuantity = RSadoPrimary("Quantity") - RSadoPrimary("StockTake_Quantity").OriginalValue
                cnnDB.Execute("UPDATE StockTake SET StockTake.StockTake_Quantity = " & lQuantity & " WHERE (((StockTake.StockTake_StockItemID)=" & RSadoPrimary.Fields("StockTake_StockItemID").Value & ") AND ((StockTake.StockTake_WarehouseID)=2));")
                cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & RSadoPrimary.Fields("StockTake_StockItemID").Value & ") AND ((StockTake.StockTake_WarehouseID)=2));")
                'cnnDB.Execute "UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = 0 WHERE (((StockTake.StockTake_StockItemID)=" & RSadoPrimary("StockTake_StockItemID") & ") AND ((StockTake.StockTake_WarehouseID)=2));"
                cnnDB.Execute("UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" & lQuantity & ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & RSadoPrimary.Fields("StockTake_StockItemID").Value & "));")
                RSadoPrimary.moveNext()
            Loop
        End If

        cnnDB.Execute("DROP TABLE HandheldVegTest")
        cnnDB.Execute("DELETE * FROM StockGroup WHERE StockGroup_Name ='HandheldVegTest'")

        cnnDB.Execute("UPDATE VegTest SET VegTest_VegTestStatusID = 3 WHERE (VegTestID = " & testID & ")")
        MsgBox("Veg Production Test process has been completed.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)

        updateProc_OLD = True

        Exit Function
UpdateErr:
        MsgBox(Err.Description)
        updateProc_OLD = True
    End Function

    Private Sub updatePrice()
        cnnDB.Execute("UPDATE VegTestItem INNER JOIN CatalogueChannelLnk ON VegTestItem.VegTestItem_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Price = VegTestItem.VegTestItem_MRelatedSellPrice WHERE (((VegTestItem.VegTestItem_VegTestID)=" & testID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=2));")
        cnnDB.Execute("UPDATE VegTestItem INNER JOIN CatalogueChannelLnk ON VegTestItem.VegTestItem_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Price = VegTestItem.VegTestItem_ActualSellPriceIncl WHERE (((VegTestItem.VegTestItem_VegTestID)=" & testID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
    End Sub

    Private Sub cmdReg_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdReg.Click
        If frmVegTestCode.setupCode = True Then

            Me.Text = VB.Left(Me.Text, Len(Me.Text) - Len(" - Trial"))
            cmdReg.Visible = False
        End If
    End Sub

    Private Sub cmdTotal_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdTotal.Click
        Dim QtyD_P As Decimal
        On Error Resume Next
        loading = True
        bFinish = True
        'Serial chk
        'If checkSecurity = True Then
        'Else
        '    If timeOver Then
        '        MsgBox "Your 4VEG Production Software has expired." & vbCrLf & "Please contact your 4POS representative or www.4pos.co.za.", vbCritical, "4VEG Production is not Registered"
        '        Exit Sub
        '    End If
        'End If

        cmdTotal.Enabled = False
        'update VegTest master
        cnnDB.Execute("UPDATE VegTest SET VegTest_PricePerKg = " & FormatNumber(CDec(txtR.Text), 4) & ", VegTest_WeightCarcass = " & FormatNumber(CDec(txtZ.Text), 4) & ", VegTest_RequiredGP = " & FormatNumber(CDec(txtReqGP.Text), 2) & ", VegTest_VAT = " & FormatNumber(CDec(txtVAT.Text), 4) & " WHERE (VegTestID = " & testID & ")")

        'lblA.Caption = FormatNumber(CCur(txtR.Text) * CCur(txtZ.Text), 4)

        'lblGP_Y.Caption = FormatNumber(CCur(1 - (CCur(txtReqGP.Text / 100))), 4)


        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 2
                cnnDB.Execute("UPDATE VegTestItem SET VegTestItem_PerWeightYield = " & FormatNumber(CDec(.Text), 2) & " WHERE ((VegTestItem_VegTestID = " & testID & ") AND (VegTestItem_StockItemID = " & .get_RowData(x) & ") AND (VegTestItem_Line = " & x & "));")
            Next
        End With

        QtyD_P = 0
        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 3
                QtyD_P = QtyD_P + CDbl(FormatNumber(CDec(.Text), 2))
                cnnDB.Execute("UPDATE VegTestItem SET VegTestItem_MRSellingratio = " & FormatNumber(CDec(.Text), 2) & " WHERE ((VegTestItem_VegTestID = " & testID & ") AND (VegTestItem_StockItemID = " & .get_RowData(x) & ") AND (VegTestItem_Line = " & x & "));")
            Next
        End With
        TotalQTY.Text = FormatNumber(QtyD_P, 2)

        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 1
                'QtyD_P = QtyD_P + CCur(.Text)   ' .TextMatrix(.row, 1) = FormatNumber(CCur(_txtEdit_1.Text) / 100, 4)
                cnnDB.Execute("UPDATE VegTestItem SET VegTestItem_CutWeight = " & FormatNumber(CDec(.Text), 4) & " WHERE ((VegTestItem_VegTestID = " & testID & ") AND (VegTestItem_StockItemID = " & .get_RowData(x) & ") AND (VegTestItem_Line = " & x & "));")
            Next
        End With
        'lblP.Caption = FormatNumber(QtyD_P, 4)


        'lblB.Caption = FormatNumber(CCur(txtZ.Text) - CCur(lblP.Caption), 4)


        'lblC.Caption = FormatNumber(CCur(lblA.Caption) / CCur(lblP.Caption), 4)


        'lblB_Z.Caption = FormatNumber(CCur(lblB.Caption) / CCur(txtZ.Text), 4)


        'lblX.Caption = FormatNumber(CCur((CCur(txtVAT.Text / 100) + 1)), 4)


        'With gridItem
        '    For x = 1 To (.RowCount - 1)
        '        .row = x
        '        .Col = 1
        '        .TextMatrix(.row, 3) = FormatNumber((CCur(.Text) / CCur(txtZ.Text)) * 100, 4)
        '        '.Col = 3
        '        'QtyD_P = QtyD_P + CCur(.Text)
        '    Next
        'End With
        'QtyD_P = 0
        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 4
                'QtyD_P = QtyD_P + CCur(.Text)
                'cnnDB.Execute "UPDATE VegTestItem SET VegTestItem_PerWeightYield = " & FormatNumber(CCur(.Text), 4) & " WHERE ((VegTestItem_VegTestID = " & testID & ") AND (VegTestItem_StockItemID = " & .RowData(x) & ") AND (VegTestItem_Line = " & x & "));"
                cnnDB.Execute("UPDATE VegTestItem SET VegTestItem_ActualSellPriceIncl = " & FormatNumber(CDec(.Text), 2) & " WHERE ((VegTestItem_VegTestID = " & testID & ") AND (VegTestItem_StockItemID = " & .get_RowData(x) & ") AND (VegTestItem_Line = " & x & "));")
            Next
        End With
        'lblTotalF.Caption = FormatNumber(QtyD_P, 4)
        'total req

        QtyD_P = 0
        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 5
                'QtyD_P = QtyD_P + CCur(.Text)
                QtyD_P = QtyD_P + CDbl(FormatNumber(CDec(.Text), 2))
                'cnnDB.Execute "UPDATE VegTestItem SET VegTestItem_MRelatedTO = " & FormatNumber(CCur(.Text), 4) & " WHERE ((VegTestItem_VegTestID = " & testID & ") AND (VegTestItem_StockItemID = " & .RowData(x) & ") AND (VegTestItem_Line = " & x & "));"
                cnnDB.Execute("UPDATE VegTestItem SET VegTestItem_TOActualSellExcl = " & FormatNumber(CDec(.Text), 2) & " WHERE ((VegTestItem_VegTestID = " & testID & ") AND (VegTestItem_StockItemID = " & .get_RowData(x) & ") AND (VegTestItem_Line = " & x & "));")
            Next
        End With
        txtReqGP.Text = FormatNumber(QtyD_P, 2)
        'total req


        Dim S_A_Q As Decimal
        'S_A_Q = FormatNumber(CCur(lblA.Caption) / CCur(lblTotalQ.Caption), 4)


        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 6
                '.TextMatrix(.row, 4) = FormatNumber((CCur(.Text) / CCur(lblC.Caption)) * CCur(lblGP_Y.Caption), 4)
                '.TextMatrix(.row, 4) = FormatNumber((CCur(.Text) / CCur(lblC.Caption)) * CCur(S_A_Q), 4)
                cnnDB.Execute("UPDATE VegTestItem SET VegTestItem_MRelatedSellPrice = " & FormatNumber(CDec(.Text), 2) & " WHERE ((VegTestItem_VegTestID = " & testID & ") AND (VegTestItem_StockItemID = " & .get_RowData(x) & ") AND (VegTestItem_Line = " & x & "));")
            Next
        End With
        QtyD_P = 0
        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 7
                QtyD_P = QtyD_P + CDbl(FormatNumber(CDec(.Text), 2))
                'cnnDB.Execute "UPDATE VegTestItem SET VegTestItem_MRSellingratio = " & FormatNumber(CCur(.Text), 4) & " WHERE ((VegTestItem_VegTestID = " & testID & ") AND (VegTestItem_StockItemID = " & .RowData(x) & ") AND (VegTestItem_Line = " & x & "));"
                cnnDB.Execute("UPDATE VegTestItem SET VegTestItem_TOSuggSellPriceExcl = " & FormatNumber(CDec(.Text), 2) & " WHERE ((VegTestItem_VegTestID = " & testID & ") AND (VegTestItem_StockItemID = " & .get_RowData(x) & ") AND (VegTestItem_Line = " & x & "));")
            Next
        End With
        lblGP_Y.Text = FormatNumber(QtyD_P, 2)
        'total req


        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 8
                '.TextMatrix(.row, 7) = FormatNumber(CCur(lblC.Caption) * CCur(.Text), 4)
                'cnnDB.Execute "UPDATE VegTestItem SET VegTestItem_PrimalCostkgExclVAT = " & FormatNumber(CCur(lblC.Caption) * CCur(.Text), 4) & " WHERE ((VegTestItem_VegTestID = " & testID & ") AND (VegTestItem_StockItemID = " & .RowData(x) & ") AND (VegTestItem_Line = " & x & "));"
                cnnDB.Execute("UPDATE VegTestItem SET VegTestItem_SuggSellPriceIncl = " & FormatNumber(CDec(.Text), 2) & " WHERE ((VegTestItem_VegTestID = " & testID & ") AND (VegTestItem_StockItemID = " & .get_RowData(x) & ") AND (VegTestItem_Line = " & x & "));")
            Next
        End With

        If CDec(txtReqGP.Text) > 0 And CDec(lblGP_Y.Text) > 0 Then
            lblB_Z.Text = CStr(100 - ((CDec(txtReqGP.Text) / CDec(lblGP_Y.Text)) * 100))
        End If

        cmdTotal.Enabled = True
        'temporary
        loading = False
        bFinish = False

    End Sub

    Private Sub frmVegTest_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtEdit.AddRange(New TextBox() {_txtEdit_0, _txtEdit_1, _txtEdit_2})
    End Sub



    'UPGRADE_WARNING: Event frmVegTest.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub frmVegTest_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
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
        If TotalQTY.Visible Then
            TotalQTY.Top = twipsToPixels(lTop, False)
            _lblTotal_5.Top = twipsToPixels(lTop, False)
            lTop = lTop + pixelToTwips(TotalQTY.Height, False) + 30
        End If

        frmTotals.Height = twipsToPixels(lTop + 100, False)

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

        gridItem.Height = twipsToPixels(pixelToTwips(ClientRectangle.Height, False) - _
            pixelToTwips(gridItem.Top, False) - pixelToTwips(frmTotals.Height, False), False)
        'gridItem.Height = picForm.ScaleHeight - gridItem.Top - frmTotals.Height
        gridItem.Width = frmTotals.Width ' ScaleWidth - gridItem.Left
        'gridItem.Width = picForm.ScaleWidth - gridItem.Left

        lWidth = pixelToTwips(gridItem.Width, True) - 450
        For x = 0 To gridItem.Col - 1
            lWidth = lWidth - gridItem.get_ColWidth(x)
        Next
        lWidth = lWidth + gridItem.get_ColWidth(0)
        If lWidth > 200 Then
            gridItem.set_ColWidth(0, 6000) 'lWidth
        Else
            gridItem.set_ColWidth(0, 6000)
        End If
        'gridItem_EnterCell
        If gridItem.RowCount > 1 Then
            gridItem.Height = twipsToPixels((gridItem.RowCount * gridItem.get_RowHeight(1)) + (gridItem.get_RowHeight(0) - 100), False) ' ScaleHeight - gridItem.Top - frmTotals.Height
        End If
        gridItem.Top = twipsToPixels(pixelToTwips(gridItem.Top, False) + 20, False)
        picTotal.Top = twipsToPixels(pixelToTwips(gridItem.Top, False) + _
                                    pixelToTwips(gridItem.Height, False), False) '+ 20
        picTotal.Left = gridItem.Left
    End Sub

    Private Sub setup()
        loading = True
        '    Dim lDOM As DOMDocument
        '    Dim lNode As IXMLDOMNode
        '    Dim lNodeList As IXMLDOMNodeList
        'lblSupplier.Caption = frmGRV.adoPrimaryRS("Supplier_Name") & "(" & frmGRV.adoPrimaryRS("PurchaseOrder_Reference") & ")"
        'lblReturns.Visible = orderType

        With gridItem
            gridItem.RowCount = 1
            gridItem.row = 0

            gridItem.Col = 9

            gridItem.set_RowHeight(0, 650) '430
            gridItem.Col = 1 'colTotalExclusive
            'gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, 1, "New QTY") '"Cut Weight"
            gridItem.set_ColAlignment(1, 7)
            gridItem.set_ColWidth(1, 1000)

            gridItem.Col = 2 'colTotalInclusive
            'gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, 2, "Qty Packed")
            gridItem.set_ColAlignment(2, 7)
            gridItem.set_ColWidth(2, 1000)

            gridItem.Col = 3 'colExclusive
            'gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, 3, "Bags Used")
            gridItem.set_ColAlignment(3, 7)
            gridItem.set_ColWidth(3, 1000)

            gridItem.Col = 4 'colInclusive
            'gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, 4, "COST")
            gridItem.set_ColAlignment(4, 7)
            gridItem.set_ColWidth(4, 1000)


            gridItem.Col = 5 'colVAT
            'gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, 5, "Total Cost")
            gridItem.set_ColAlignment(5, 7)
            gridItem.set_ColWidth(5, 1000)

            gridItem.Col = 6 'colCode
            'gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, 6, "SELLING")
            gridItem.set_ColAlignment(6, 7)
            gridItem.set_ColWidth(6, 1000)

            gridItem.Col = 7 'colName
            'gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, 7, "Total Selling")
            gridItem.set_ColAlignment(7, 7)
            gridItem.set_ColWidth(7, 1000)

            gridItem.Col = 8 'colBrokenPack
            'gridItem.CellFontBold = True
            gridItem.set_TextMatrix(0, 8, "GP%")
            gridItem.set_ColAlignment(8, 7)
            gridItem.set_ColWidth(8, 1000)


        End With
        loading = False
    End Sub

    Private Sub getRecItems(Optional ByRef retInfo As Boolean = False)
        Dim colQuantity As Integer
        Dim colPosPrice As Decimal
        Dim colChannelPrice As Decimal
        Dim colName As String
        Dim colTotalInclusive As Decimal
        Dim colTotalExclusive As Decimal
        Dim colInclusive As Decimal
        Dim colExclusive As Decimal
        Dim colOnOrder As Integer
        Dim colDiscountPercentage As Decimal
        Dim colDiscountLine As Integer
        Dim colDiscount As Integer
        Dim colContentTotalInclusive As Decimal
        Dim colContentTotalExclusive As Decimal
        Dim colDepositTotalInclusive As Decimal
        Dim colDepositTotalExclusive As Decimal
        Dim colDepositInclusive As Decimal
        Dim colDepositExclusive As Decimal
        Dim colContentInclusive As Decimal
        Dim colContentExclusive As Decimal
        Dim colPackSize As Integer
        Dim colFractions As Decimal
        Dim sql As String
        Dim gGRVFieldOrder As String
        Dim gFieldOrder As Integer
        Dim rs As ADODB.Recordset
        Dim rs1 As ADODB.Recordset
        Dim CurTot As Decimal
        Dim oText As New System.Windows.Forms.TextBox
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
        Dim lDeposit As Decimal

        If retInfo = True Then
            rs = getRS("SELECT VegTestItem.VegTestItem_StockItemID AS StockItemID, VegTestItem.VegTestItem_Name AS StockItem_Name, VegTestItem.* From VegTestItem Where (((VegTestItem.VegTestItem_VegTestID) = " & testID & ")) ORDER BY VegTestItem.VegTestItem_Line;")
        Else
            sql = "SELECT StockItem.StockItemID, StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk_1.CatalogueChannelLnk_Price AS POSCatalogueChannelLnk_Price, CatalogueChannelLnk_1.CatalogueChannelLnk_ChannelID, PackSize.PackSize_Volume, * "
            'changes for CHANNEL 6 price        sql = sql & "FROM (((StockItem INNER JOIN RecipeStockitemLnk ON StockItem.StockItemID = RecipeStockitemLnk.RecipeStockitemLnk_StockitemID) INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) INNER JOIN CatalogueChannelLnk AS CatalogueChannelLnk_1 ON StockItem.StockItemID = CatalogueChannelLnk_1.CatalogueChannelLnk_StockItemID) INNER JOIN PackSize ON StockItem.StockItem_PackSizeID = PackSize.PackSizeID WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=2) AND ((CatalogueChannelLnk_1.CatalogueChannelLnk_ChannelID)=1) AND ((RecipeStockitemLnk.RecipeStockitemLnk_RecipeID)=" & gStockItemID & ") AND ((StockItem.StockItem_Disabled)=0) AND ((StockItem.StockItem_Discontinued)=0));"
            sql = sql & "FROM (((StockItem INNER JOIN RecipeStockitemLnk ON StockItem.StockItemID = RecipeStockitemLnk.RecipeStockitemLnk_StockitemID) INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) INNER JOIN CatalogueChannelLnk AS CatalogueChannelLnk_1 ON StockItem.StockItemID = CatalogueChannelLnk_1.CatalogueChannelLnk_StockItemID) INNER JOIN PackSize ON StockItem.StockItem_PackSizeID = PackSize.PackSizeID WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=2) AND ((CatalogueChannelLnk_1.CatalogueChannelLnk_ChannelID)=6) AND ((RecipeStockitemLnk.RecipeStockitemLnk_RecipeID)=" & gStockItemID & ") AND ((StockItem.StockItem_Disabled)=0) AND ((StockItem.StockItem_Discontinued)=0));"
            'Set rs = getRS(sql)
            rs = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_Name, RecipeStockitemLnk.RecipeStockitemLnk_Quantity, [StockItem_ListCost]/[StockItem_Quantity] AS cost, PriceChannelLnk.PriceChannelLnk_Price FROM (RecipeStockitemLnk INNER JOIN StockItem ON RecipeStockitemLnk.RecipeStockitemLnk_StockitemID = StockItem.StockItemID) INNER JOIN PriceChannelLnk ON StockItem.StockItemID = PriceChannelLnk.PriceChannelLnk_StockItemID Where (((RecipeStockitemLnk.RecipeStockitemLnk_RecipeID) = " & gStockItemID & ") And ((StockItem.StockItem_Discontinued) = False) And ((PriceChannelLnk.PriceChannelLnk_Quantity) = 1) And ((PriceChannelLnk.PriceChannelLnk_ChannelID) = 1)) ORDER BY StockItem.StockItem_Name;")
            'Set rs = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk_1.CatalogueChannelLnk_Price AS POSCatalogueChannelLnk_Price, CatalogueChannelLnk_1.CatalogueChannelLnk_ChannelID, * FROM ((StockItem INNER JOIN RecipeStockitemLnk ON StockItem.StockItemID = RecipeStockitemLnk.RecipeStockitemLnk_StockitemID) INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) INNER JOIN CatalogueChannelLnk AS CatalogueChannelLnk_1 ON StockItem.StockItemID = CatalogueChannelLnk_1.CatalogueChannelLnk_StockItemID WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=2) AND ((CatalogueChannelLnk_1.CatalogueChannelLnk_ChannelID)=1) AND ((RecipeStockitemLnk.RecipeStockitemLnk_RecipeID)=" & gStockItemID & ") AND ((StockItem.StockItem_Disabled)=0) AND ((StockItem.StockItem_Discontinued)=0));")
        End If

        If rs.RecordCount > 0 Then
        Else
            MsgBox("This Product does not have any Recipe.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
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
                    sql = "INSERT INTO VegTestItem ( VegTestItem_VegTestID, VegTestItem_StockItemID, VegTestItem_Name, VegTestItem_CutWeight, VegTestItem_MRelatedSellPrice, VegTestItem_ActualSellPriceIncl, VegTestItem_Line ) "
                    sql = sql & "SELECT " & testID & ", " & rs.Fields("StockItemID").Value & ", '" & Replace(rs.Fields("StockItem_Name").Value, "'", "''") & "', " & rs.Fields("RecipeStockitemLnk_Quantity").Value & ", " & CDec(rs.Fields("PriceChannelLnk_Price").Value) & ", " & CDec(rs.Fields("cost").Value) & ", " & x & " FROM Company;"
                    Debug.Print(sql)
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

                    .set_TextMatrix(x, 1, FormatNumber(rs.Fields("VegTestItem_CutWeight").Value, 4))
                    .set_TextMatrix(x, 2, rs.Fields("VegTestItem_PerWeightYield").Value)
                    .set_TextMatrix(x, 3, FormatNumber(rs.Fields("VegTestItem_MRSellingratio").Value, 2))

                    .set_TextMatrix(x, 4, FormatNumber(rs.Fields("VegTestItem_ActualSellPriceIncl").Value, 2))
                    .set_TextMatrix(x, 5, FormatNumber(rs.Fields("VegTestItem_TOActualSellExcl").Value, 2))

                    .set_TextMatrix(x, 6, FormatNumber(rs.Fields("VegTestItem_MRelatedSellPrice").Value, 2))
                    .set_TextMatrix(x, 7, FormatNumber(rs.Fields("VegTestItem_TOSuggSellPriceExcl").Value, 2))
                    .set_TextMatrix(x, 8, FormatNumber(rs.Fields("VegTestItem_SuggSellPriceIncl").Value, 2))

                Else
                    .set_TextMatrix(x, colName, rs.Fields("StockItem_Name").Value)
                    .set_TextMatrix(x, 1, FormatNumber(rs.Fields("RecipeStockitemLnk_Quantity").Value, 4))
                    .set_TextMatrix(x, 2, "0")
                    .set_TextMatrix(x, 3, "0.00")
                    .set_TextMatrix(x, 4, FormatNumber(rs.Fields("cost").Value, 2))
                    .set_TextMatrix(x, 5, "0.00")
                    .set_TextMatrix(x, 6, FormatNumber(rs.Fields("PriceChannelLnk_Price").Value, 2))
                    .set_TextMatrix(x, 7, "0.00")
                    .set_TextMatrix(x, 8, "0.00")
                End If

                displayLine(x)
                rs.moveNext()
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
        Dim lDiscount As Decimal
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

    Private Sub gridItem_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles gridItem.KeyPress
        Select Case eventArgs.KeyChar
            Case Chr(40)
                eventArgs.KeyChar = Chr(0)
        End Select

    End Sub

    Private Sub gridItem_EnterCell(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles gridItem.Enter
        On Error GoTo gridItem_Err
        If loading Then Exit Sub
        loading = True
        With gridItem
            If .row Then
                If .Col = 2 Or .Col = 3 Then 'colContentExclusive Then
                    _txtEdit_1.SetBounds(twipsToPixels(pixelToTwips(.Left, True) + .CellLeft, True), _
                                         twipsToPixels(pixelToTwips(.Top, False) + .CellTop, False), _
                                         twipsToPixels(.CellWidth, True), twipsToPixels(.CellHeight, False))
                    _txtEdit_1.Text = .Text
                    _txtEdit_1.Tag = _txtEdit_1.Text
                    _txtEdit_1.Visible = True
                    _txtEdit_1.Text = Replace(_txtEdit_1.Text, ",", "")
                    _txtEdit_1.Text = Replace(_txtEdit_1.Text, ".", "")
                    _txtEdit_1.SelectionStart = 0
                    _txtEdit_1.SelectionLength = 9999
                    If Me.Visible Then _txtEdit_1.Focus()
                    'ElseIf .Col = 2 Or .Col = 17 Then
                    '    _txtEdit_1.Move .Left + .CellLeft, .Top + .CellTop, .CellWidth, .CellHeight
                    '    _txtEdit_1.Text = .Text
                    '    _txtEdit_1.Tag = _txtEdit_1.Text
                    '    _txtEdit_1.Visible = True
                    '    _txtEdit_1.Text = Replace(_txtEdit_1.Text, ",", "")
                    '    _txtEdit_1.Text = Replace(_txtEdit_1.Text, ".", "")
                    '    _txtEdit_1.SelStart = 0
                    '    _txtEdit_1.SelLength = 9999
                    '    If Me.Visible Then _txtEdit_1.SetFocus
                    'ElseIf .Col = 15 Then
                    '    _txtEdit_1.Move .Left + .CellLeft, .Top + .CellTop, .CellWidth, .CellHeight
                    '    _txtEdit_1.Text = .Text
                    '    _txtEdit_1.Tag = _txtEdit_1.Text
                    '    _txtEdit_1.Visible = True
                    '    _txtEdit_1.Text = Replace(_txtEdit_1.Text, ",", "")
                    '    _txtEdit_1.Text = Replace(_txtEdit_1.Text, ".", "")
                    '    _txtEdit_1.SelStart = 0
                    '    _txtEdit_1.SelLength = 9999
                    '    If Me.Visible Then _txtEdit_1.SetFocus
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

    Private Sub gridItem_LeaveCell(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles gridItem.Leave
        If loading Then Exit Sub
        If bFinish Then Exit Sub
        If cmdTotal.Enabled = False Then Exit Sub
        'MsgBox gridItem.row & "  " & gridItem.Col
        On Error Resume Next

        If gridItem.Col = 2 Then
            gridItem.set_TextMatrix(gridItem.row, 3, FormatNumber(CDec(gridItem.Text) * CDec(gridItem.get_TextMatrix(gridItem.row, 1)), 2))
            gridItem.set_TextMatrix(gridItem.row, 5, FormatNumber(CDec(gridItem.Text) * CDec(gridItem.get_TextMatrix(gridItem.row, 4)), 2))
            gridItem.set_TextMatrix(gridItem.row, 7, FormatNumber(CDec(gridItem.Text) * CDec(gridItem.get_TextMatrix(gridItem.row, 6)), 2))
            If CDec(gridItem.get_TextMatrix(gridItem.row, 5)) > 0 And CDec(gridItem.get_TextMatrix(gridItem.row, 7)) > 0 Then
                gridItem.set_TextMatrix(gridItem.row, 8, FormatNumber(100 - ((CDec(gridItem.get_TextMatrix(gridItem.row, 5)) / CDec(gridItem.get_TextMatrix(gridItem.row, 7)) * 100)), 2))
            End If
        ElseIf gridItem.Col = 15 Then

        End If

    End Sub

    'UPGRADE_WARNING: Event txtEdit.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub txtEdit_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'Dim Index As Short = txtEdit.GetIndex(eventSender)
        Dim colPrice As Decimal
        Dim colFractions As Decimal
        Dim colQuantity As Integer
        If loading Then Exit Sub
        Dim lString As String
        Dim lValue As Integer
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

        With gridItem
            lString = txtEdit(Index).Text
            If lString = "." Then lString = "0."
            If .row Then
                If lString = "" Then lString = "0"
                'If CCur(lString) = 0 Then lString = ""
                If IsNumeric(lString) Then
                    Select Case Index
                        Case 0
                            If CBool(.get_TextMatrix(.row, colFractions)) Then
                                .set_TextMatrix(.row, colQuantity, FormatNumber(lString, 4))
                            Else
                                .set_TextMatrix(.row, colQuantity, FormatNumber(lString, 0))
                            End If
                        Case 1
                            If .Col = 2 Then
                                '.TextMatrix(.row, 1) = FormatNumber(CCur(lString) / 100, 2)
                                .set_TextMatrix(.row, 2, CDec(lString))
                            ElseIf .Col = 3 Then
                                .set_TextMatrix(.row, 3, FormatNumber(CDec(lString) / 100, 2))
                                'ElseIf .Col = 17 Then
                                '    .TextMatrix(.row, 17) = FormatNumber(CCur(lString) / 100, 2)
                                'ElseIf .Col = 15 Then
                                '    .TextMatrix(.row, 15) = FormatNumber(CCur(lString) / 100, 2)
                            End If
                        Case 2
                            'UPGRADE_WARNING: Couldn't resolve default property of object colPrice. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            .set_TextMatrix(.row, colPrice, FormatNumber(CDec(lString) / 100, 2))
                    End Select
                End If
                'displayLine .row
            End If
        End With
        'doTotals
    End Sub

    Private Sub txtEdit_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'Dim Index As Short = txtEdit.GetIndex(eventSender)
        MyGotFocusNumeric(_txtEdit_1)
    End Sub

    Private Sub txtEdit_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'Dim Index As Short = txtEdit.GetIndex(eventSender)
        Select Case KeyAscii
            Case Asc(vbCr)
                gridItem.Focus()
                _txtEdit_1.Visible = False
                'update
                KeyAscii = 0
            Case 8
            Case 48 To 57
            Case Else
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtEdit_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'Dim Index As Short = txtEdit.GetIndex(eventSender)
        'update
        calcP()
    End Sub

    Private Sub txtEdit_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs)
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        'Dim Index As Short = txtEdit.GetIndex(eventSender)
        If KeyCode = 40 Then
            'update
            loading = True
            calcP()
            loading = True
            moveNext(1, 1)
            loading = False
        ElseIf KeyCode = 38 Then
            'update
            loading = True
            calcP()
            loading = True
            moveNext(1, -1)
            loading = False
        End If


    End Sub

    Private Function moveNext(ByRef Index As Integer, ByRef direction As Short) As Boolean
        Dim a As String
        Dim x As Short
        Dim y As Short
        On Error Resume Next

        x = gridItem.row + direction
        If x >= gridItem.RowCount Or x < gridItem.FixedRows Then
        Else
            gridItem.row = x
        End If

        With gridItem
            If .row Then
                If .Col = 2 Then 'colContentExclusive Then
                    _txtEdit_1.SetBounds(twipsToPixels(pixelToTwips(.Left, True) + .CellLeft, True), _
                                         twipsToPixels(pixelToTwips(.Top, False) + .CellTop, False), _
                                         twipsToPixels(.CellWidth, True), _
                                         twipsToPixels(.CellHeight, False))
                    a = CDec(.Text)
                    'If Me.Visible Then _txtEdit_1.SetFocus
                    loading = True
                    _txtEdit_1.Text = a
                    '_txtEdit_1.Tag = _txtEdit_1.Text
                    _txtEdit_1.Visible = True
                    '_txtEdit_1.Text = Replace(_txtEdit_1.Text, ",", "")
                    '_txtEdit_1.Text = Replace(_txtEdit_1.Text, ".", "")
                    '_txtEdit_1.SelStart = 0
                    '_txtEdit_1.SelLength = 9999
                    loading = False
                ElseIf .Col = 3 Then
                    _txtEdit_1.SetBounds(twipsToPixels(pixelToTwips(.Left, True) + .CellLeft, True), _
                                         twipsToPixels(pixelToTwips(.Top, False) + .CellTop, False), _
                                         twipsToPixels(.CellWidth, True), _
                                         twipsToPixels(.CellHeight, False))
                    a = CDec(.Text)
                    'If Me.Visible Then _txtEdit_1.SetFocus
                    loading = True
                    'UPGRADE_WARNING: Couldn't resolve default property of object a. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    _txtEdit_1.Text = a
                    _txtEdit_1.Visible = True
                    loading = False
                    'ElseIf .Col = 15 Then
                    '    _txtEdit_1.Move .Left + .CellLeft, .Top + .CellTop, .CellWidth, .CellHeight
                    '    a = CCur(.Text)
                    '    'If Me.Visible Then _txtEdit_1.SetFocus
                    '    loading = True
                    '    _txtEdit_1.Text = a
                    '    _txtEdit_1.Visible = True
                    '    loading = False
                    'ElseIf .Col = 2 Then
                    '    _txtEdit_1.Move .Left + .CellLeft, .Top + .CellTop, .CellWidth, .CellHeight
                    '    If CCur(.Text) = 0 Then _txtEdit_1.Text = "" Else _txtEdit_1.Text = CCur(.Text) '* 100
                    'ElseIf .Col = 11 Then
                    '    _txtEdit_1.Move .Left + .CellLeft, .Top + .CellTop, .CellWidth, .CellHeight
                    '    If CCur(.Text) = 0 Then _txtEdit_1.Text = "" Else _txtEdit_1.Text = CCur(.Text) '* 100
                Else
                    _txtEdit_1.Visible = False
                End If
            End If
        End With
        'txtEdit(Index).SelStart = 0
        'txtEdit(Index).SelLength = 999
        cmdPrint.Focus()
        If txtEdit(Index).Visible Then txtEdit(Index).Focus()
        moveNext = True
    End Function

    Private Sub calcP()
        Dim QtyD_P As Decimal
        Dim QtyD_P_GRV As Decimal
        Dim rowNo As Integer
        loading = True
        On Error Resume Next
        If gridItem.Col = 2 Then
            rowNo = gridItem.row
            QtyD_P = 0
            QtyD_P_GRV = 0
            With gridItem
                For x = 1 To (.RowCount - 1)
                    .row = x
                    .Col = 2
                    QtyD_P = QtyD_P + CDec(.Text)
                    If gridItem.row = rowNo Then
                        gridItem.set_TextMatrix(gridItem.row, 3, FormatNumber(CDec(gridItem.get_TextMatrix(gridItem.row, 2)) * CDec(gridItem.get_TextMatrix(gridItem.row, 1)), 2))
                        gridItem.set_TextMatrix(gridItem.row, 5, FormatNumber(CDec(gridItem.get_TextMatrix(gridItem.row, 2)) * CDec(gridItem.get_TextMatrix(gridItem.row, 4)), 2))
                        gridItem.set_TextMatrix(gridItem.row, 7, FormatNumber(CDec(gridItem.get_TextMatrix(gridItem.row, 2)) * CDec(gridItem.get_TextMatrix(gridItem.row, 6)), 2))
                        If CDec(gridItem.get_TextMatrix(gridItem.row, 5)) > 0 And CDec(gridItem.get_TextMatrix(gridItem.row, 7)) > 0 Then
                            gridItem.set_TextMatrix(gridItem.row, 8, FormatNumber(100 - ((CDec(gridItem.get_TextMatrix(gridItem.row, 5)) / CDec(gridItem.get_TextMatrix(gridItem.row, 7)) * 100)), 2))
                        End If
                        'gridItem.TextMatrix(gridItem.row, 14) = FormatNumber((CCur(.Text) * CCur(gridItem.TextMatrix(gridItem.row, 13))), 2)
                        'gridItem.TextMatrix(gridItem.row, 15) = FormatNumber((CCur(.Text) * CCur(gridItem.TextMatrix(gridItem.row, 13))), 2)
                    End If
                    QtyD_P_GRV = QtyD_P_GRV + CDbl(gridItem.get_TextMatrix(gridItem.row, 3)) '(CCur(.Text) * CCur(gridItem.TextMatrix(gridItem.row, 13)))

                Next
            End With
            'lblP.Caption = FormatNumber(QtyD_P, 4)
            TotalQTY.Text = FormatNumber(QtyD_P_GRV, 4)
            'If TotalQTY > AvailGRV Then
            '    MsgBox "Insufficient Qty in Main Stock Item! Please correct your last entered QTY."
            'End If
            gridItem.row = rowNo
        ElseIf gridItem.Col = 3 Then
            rowNo = gridItem.row
            'QtyD_P = 0
            QtyD_P_GRV = 0
            With gridItem
                For x = 1 To (.RowCount - 1)
                    .row = x
                    .Col = 3
                    'QtyD_P = QtyD_P + CCur(.Text)
                    'gridItem.TextMatrix(gridItem.row, 14) = FormatNumber((CCur(.Text) * CCur(gridItem.TextMatrix(gridItem.row, 13))), 2)
                    'gridItem.TextMatrix(gridItem.row, 15) = FormatNumber((CCur(.Text) * CCur(gridItem.TextMatrix(gridItem.row, 13))), 2)
                    QtyD_P_GRV = QtyD_P_GRV + CDec(.Text)

                Next
            End With
            'lblP.Caption = FormatNumber(QtyD_P, 4)
            TotalQTY.Text = FormatNumber(QtyD_P_GRV, 4)
            'If TotalQTY > AvailGRV Then
            '    MsgBox "Insufficient Qty in Main Stock Item! Please correct your last entered QTY."
            'End If
            gridItem.row = rowNo
        End If
        loading = False
    End Sub
    'UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
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
                gridItem.set_TextMatrix(gridItem.row, 1, CDec(_txtEdit_1.Text))
            Case 2
                gridItem.set_TextMatrix(gridItem.row, 2, FormatNumber(_txtEdit_1.Text, 2))
            Case 17 '11
                gridItem.set_TextMatrix(gridItem.row, 17, FormatNumber(_txtEdit_1.Text, 2))
        End Select
        'End If
    End Sub



    Private Sub txtR_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtR.Enter
        'MyGotFocusNumericMEAT txtR
        MyGotFocusNumeric(txtR)
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
        MyLostFocus(txtR, 2)
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
        Dim oText As New TextBox

        ResizeForm(Me, pixelToTwips(Me.Width, True), pixelToTwips(Me.Height, False), 2)

        setup()
        frmVegTest_Resize(Me, New System.EventArgs())

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
        loadDataSAVE()
    End Sub

    Private Sub loadDataSAVE()
        Dim rs As ADODB.Recordset
        Dim rj As ADODB.Recordset

        'Set rs = getRS("SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM (Catalogue INNER JOIN StockItem ON (StockItem.StockItem_Quantity = Catalogue.Catalogue_Quantity) AND (Catalogue.Catalogue_StockItemID = StockItem.StockItemID)) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) WHERE (((StockItem.StockItemID)=" & gStockItemID & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
        rs = getRS("SELECT VegTest.*, StockItem.StockItem_Name, Person.Person_FirstName, Person.Person_LastName FROM (VegTest INNER JOIN StockItem ON VegTest.VegTest_MainItemID = StockItem.StockItemID) INNER JOIN Person ON VegTest.VegTest_PersonID = Person.PersonID WHERE (((VegTest.VegTestID)=" & testID & "));")

        If rs.RecordCount Then
            lblContentExclusive.Text = rs.Fields("Person_FirstName").Value & " " & rs.Fields("Person_LastName").Value
            txtR.Text = FormatNumber(rs.Fields("VegTest_PricePerKg").Value, 4)
            txtZ.Text = FormatNumber(rs.Fields("VegTest_WeightCarcass").Value, 4)
            txtReqGP.Text = FormatNumber(rs.Fields("VegTest_RequiredGP").Value, 4)
            txtVAT.Text = FormatNumber(rs.Fields("VegTest_VAT").Value, 4)
            getRecItems(True)
            cmdTotal_ClickSAVE()
            If rs.Fields("VegTest_VegTestStatusID").Value = 3 Then
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
        bFinish = True
        loading = True

        QtyD_P = 0
        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 3
                QtyD_P = QtyD_P + CDbl(FormatNumber(CDec(.Text), 2))
                'cnnDB.Execute "UPDATE VegTestItem SET VegTestItem_MRSellingratio = " & FormatNumber(CCur(.Text), 2) & " WHERE ((VegTestItem_VegTestID = " & testID & ") AND (VegTestItem_StockItemID = " & .RowData(x) & ") AND (VegTestItem_Line = " & x & "));"
            Next
        End With
        TotalQTY.Text = FormatNumber(QtyD_P, 2)

        QtyD_P = 0
        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 5
                'QtyD_P = QtyD_P + CCur(.Text)
                QtyD_P = QtyD_P + CDbl(FormatNumber(CDec(.Text), 2))
                'cnnDB.Execute "UPDATE VegTestItem SET VegTestItem_MRelatedTO = " & FormatNumber(CCur(.Text), 4) & " WHERE ((VegTestItem_VegTestID = " & testID & ") AND (VegTestItem_StockItemID = " & .RowData(x) & ") AND (VegTestItem_Line = " & x & "));"
                'cnnDB.Execute "UPDATE VegTestItem SET VegTestItem_TOActualSellExcl = " & FormatNumber(CCur(.Text), 2) & " WHERE ((VegTestItem_VegTestID = " & testID & ") AND (VegTestItem_StockItemID = " & .RowData(x) & ") AND (VegTestItem_Line = " & x & "));"
            Next
        End With
        txtReqGP.Text = FormatNumber(QtyD_P, 2)

        QtyD_P = 0
        With gridItem
            For x = 1 To (.RowCount - 1)
                .row = x
                .Col = 7
                QtyD_P = QtyD_P + CDbl(FormatNumber(CDec(.Text), 2))
                'cnnDB.Execute "UPDATE VegTestItem SET VegTestItem_MRSellingratio = " & FormatNumber(CCur(.Text), 4) & " WHERE ((VegTestItem_VegTestID = " & testID & ") AND (VegTestItem_StockItemID = " & .RowData(x) & ") AND (VegTestItem_Line = " & x & "));"
                'cnnDB.Execute "UPDATE VegTestItem SET VegTestItem_TOSuggSellPriceExcl = " & FormatNumber(CCur(.Text), 2) & " WHERE ((VegTestItem_VegTestID = " & testID & ") AND (VegTestItem_StockItemID = " & .RowData(x) & ") AND (VegTestItem_Line = " & x & "));"
            Next
        End With
        lblGP_Y.Text = FormatNumber(QtyD_P, 2)

        If CDec(txtReqGP.Text) > 0 And CDec(lblGP_Y.Text) > 0 Then
            lblB_Z.Text = CStr(100 - ((CDec(txtReqGP.Text) / CDec(lblGP_Y.Text)) * 100))
        End If


        'total req
        loading = False
        bFinish = False
    End Sub
End Class