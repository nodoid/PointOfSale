Option Strict Off
Option Explicit On

Imports VB = Microsoft.VisualBasic
Module modApplication
	Public Declare Sub ExitProcess Lib "kernel32" (ByVal uExitCode As Integer)
	'changes from jonas for Price change report
	Public Te_Names As String
	Public MyFTypess As String
	Public ForNewPChange As Short
	Public HCalDate As String
	Public HForPriceC As Short
	
	'for label printing
	Public TheType As Short
	Public TheSelectedPrinterNew As Short
	Public TheErr As Integer
	Public TheNames As String
	Public MyFAlign As Short
	Public RecSel As Short
	Structure Labelss
		Dim widthh As Integer
		Dim heightt As Integer
	End Structure
	Public IntDesign As Short
	Public IntDesign1 As Short
	Public NewLabelName As String
	Public SelectLabelName As String
	Public LaIDHold As Short
	Public MyLIDWHole As Short
	Public MyNewPrLabel As String
	'changes from jonas for Price change report
	
	'To keep track of month end routine
	Public holdid As Integer
	Public Intpercen As Double
	Public IntPeriod As String
	Public checkcustid As String
	Public holddel As Integer
	Public Holdquantity As Integer
	Public Holdvalue As String
	Public HoldP As String
	Public Hold_text As String
	Public modUpdate As Integer
	Public gSecKey As String
	Public tempStockItem(100) As String
	Public stTableName As String
	Public intArrayName(100) As String
	Public strLocation As String
	Public intQTY As Short
	Public rInt As Short
	Public InKeyboard As Short
	Public Gr_ID As Short
	Public intArraySCode(100) As Short
	Public intCurr As Short
	Public exUt_variable As Short
	Public grvPrinType As Short
	Public Grv_Unload As Boolean
	Public nwPOS As Boolean
	Public inTableCrea As Boolean
	Public grvPrin As Boolean
	Public scaleBCPrint As Boolean 'to print scale barcode
	'Public blMontheEnd        As Boolean
	
	Public blMEndUpdatePOS As Boolean 'For Auto UpdatePOS on MonthEnd
	Public blChangeOnlyUpdatePOS As Boolean 'For Auto UpdatePOS on MonthEnd
	Public blNextItem As Boolean
	Public rs_St As ADODB.Recordset
	Public blChkSecu As Boolean 'security check
	
	'stock holding report from multiple companies
	Public arrCompChk() As String
	Public bolCompChk As Boolean
	
	Public bGRVNewItemBarcode As Boolean 'to check for duplicate barcode when create new item from GRV
	
	'Air Time Auto GRV
	Public bolAirTimeGRV As Boolean
	Public strAirTimeFile As String
	
	'Fruit and Veg GRV
	Public bolFNVegGRV As Boolean
	
	'Auto DayEnd from Controller
	Public bolAutoDE As Boolean
	Public dateDayEnd As Date
	
	'Piracy check
	Public loginDate As Date
	Public instalDate As Date
	'Piracy check
	
	Public Function posDemo() As Boolean
		Dim bPosDemo As Boolean
		Dim rs As ADODB.Recordset
		
		On Error GoTo skipEnd
		
		bPosDemo = False
		rs = getRS("SELECT Company.Company_Name FROM Company;")
		If rs.RecordCount Then
			If IsDbNull(rs.Fields("Company_Name").Value) Then
				bPosDemo = True
				GoTo skipEnd
			ElseIf Left(UCase(rs.Fields("Company_Name").Value), 4) = "4POS" Then 
				bPosDemo = True
				GoTo skipEnd
			End If
		End If
		
		bPosDemo = False
		rs = getRS("SELECT Count([SaleID]) AS cSaleID FROM Sale;")
		If rs.Fields("cSaleID").Value > 1 Then
		Else
			rs = getRS("SELECT Count([DayEndID]) AS cDayEnd FROM DayEnd;")
			If rs.Fields("cDayEnd").Value > 1 Then
			Else
				bPosDemo = True
				GoTo skipEnd
			End If
		End If
		
skipEnd: 
		posDemo = bPosDemo
	End Function
	
	Public Sub getLoginDate()
		Dim fso As New Scripting.FileSystemObject
		
		'Piracy check
		loginDate = Today
		Dim fsoFolder As Scripting.Folder
		If fso.FolderExists(serverPath) Then
			fsoFolder = fso.GetFolder(serverPath)
			'getSerialNumber = fsoFolder.Drive.SerialNumber
			instalDate = fsoFolder.DateCreated
		End If
	End Sub
	
	Public Function getBanList(ByRef compName As String) As Boolean
        Dim x As Short
		Dim sBanList() As String 'new ban check
		Dim bFound As Boolean
		
		bFound = False
		ReDim sBanList(43)
		sBanList(0) = "Hey day chicken_REMOVED" 'removed 10-Nov-2011  "Hey day chicken"
		sBanList(1) = "Heyday Chicken_REMOVED" 'removed 10-Nov-2011  "Heyday Chicken"
		sBanList(2) = "Hay Day Chicken_REMOVED" 'removed 10-Nov-2011  "Hay Day Chicken"
		sBanList(3) = "Hayday Chicken_REMOVED" 'removed 10-Nov-2011  "Hayday Chicken"
		sBanList(4) = "Bloemhof Drankwinkel"
		'list of 04-oct
		sBanList(5) = "FOOD & GOODS SUPERMARKET"
		sBanList(6) = "FOOD AND GOODS SUPERMARKET"
		sBanList(7) = "LOBAY SUPERMARKET"
		sBanList(8) = "MABENA'S SUPERMARKET"
		sBanList(9) = "MABENA SUPERMARKET"
		sBanList(10) = "PHILLY'S PUB"
		sBanList(11) = "PHILLY PUB"
		sBanList(12) = "COLTRANE'S TUCK SHOP"
		sBanList(13) = "COLTRANE TUCK SHOP"
		sBanList(14) = "OUDSTAD BUTCHERY"
		sBanList(15) = "PEACE SUPERSAVE(FORMERLY FOOD BAZAAR)"
		sBanList(16) = "PEACE SUPERSAVE"
		sBanList(17) = "AMBRO'S EATING HOUSE"
		sBanList(18) = "AMBRO EATING HOUSE"
		sBanList(19) = "IKA SUPERMARKET"
		sBanList(20) = "MOONEYES TUCKSHOP"
		sBanList(21) = "SELLO'S EATING HOUSE"
		sBanList(22) = "SELLO EATING HOUSE"
		sBanList(23) = "SELLO'S TUCKSHOP"
		sBanList(24) = "SELLO TUCKSHOP"
		sBanList(25) = "SOMETHING TASTY TUCKSHOP"
		sBanList(26) = "SIPHO'S BOTTLE STORE"
		sBanList(27) = "SIPHOS BOTTLE STORE"
		sBanList(28) = "BRO-DANS TUCKSHOP"
		sBanList(29) = "BRO DANS TUCKSHOP"
		sBanList(30) = "LAKE'S TUCKSHOP"
		sBanList(31) = "LAKE TUCKSHOP"
		sBanList(32) = "MONAKAMOTA SHOP"
		sBanList(33) = "THREEDOOR TAVERN"
		sBanList(34) = "JAKKALS SUPERMARKET"
		sBanList(35) = "LIFESTYLE PUB"
		sBanList(36) = "MATSHENGELANE GARAGE SHOP"
		sBanList(37) = "MOLEBOGENG SUPERMARKET"
		sBanList(38) = "BRO PHILLS BAR"
		sBanList(39) = "ALPHA TUCKSHOP"
		sBanList(40) = "GREEN LINE"
		sBanList(41) = "GREEN_LINE"
		sBanList(42) = "DIE STOEP"
		sBanList(43) = "DIE_STOEP"
		
		For x = 0 To UBound(sBanList)
			If LCase(compName) = LCase(sBanList(x)) Then bFound = True
			If InStr(LCase(compName), LCase(sBanList(x))) Then bFound = True
		Next 
		
		getBanList = bFound
		
	End Function
	
	Public Function getBanCDKey() As Boolean
        Dim x As Short
		Dim sBanList() As String 'new ban check
		Dim bFound As Boolean
		Dim rs As ADODB.Recordset
		
		bFound = False
		ReDim sBanList(1)
		sBanList(0) = "372B97AFDEE79CCE5E00842"
		sBanList(1) = "372B97AFDEE79CCE5E00842"
        rs = getRS("Select * FROM POS;")
        If rs.ToString <> "" Then
            For x = 0 To UBound(sBanList)

                Do While rs.EOF = False

                    If InStr(1, rs.Fields("POS_Code").Value.ToString, Chr(255)) Then
                        If LCase(Split(rs.Fields("POS_Code").Value, Chr(255))(1)) = LCase(sBanList(x)) Then
                            getBanCDKey = True
                            Exit Function
                        End If
                    End If
                    rs.MoveNext()
                Loop

            Next
        End If
        getBanCDKey = bFound

	End Function
	
	Public Sub RecipeCost()
		Dim x As Short
		Dim rs As ADODB.Recordset
		For x = 1 To 3
			rs = getRS("SELECT RecipeStockitemLnk.RecipeStockitemLnk_RecipeID, Sum([RecipeStockitemLnk_Quantity]/[Stockitem].[StockItem_Quantity]*[StockItem]![StockItem_ListCost]) AS cost FROM StockItem AS StockItem_1 INNER JOIN (RecipeStockitemLnk INNER JOIN StockItem ON RecipeStockitemLnk.RecipeStockitemLnk_StockitemID = StockItem.StockItemID) ON StockItem_1.StockItemID = RecipeStockitemLnk.RecipeStockitemLnk_RecipeID Where (((StockItem_1.StockItem_RecipeType) = 2)) GROUP BY RecipeStockitemLnk.RecipeStockitemLnk_RecipeID;")
			'Bill of material looping delay...
			Do Until rs.EOF
				cnnDB.Execute("UPDATE StockItem SET StockItem.StockItem_ListCost = " & rs.Fields("cost").Value & " WHERE (((StockItem.StockItemID)=" & rs.Fields("RecipeStockitemLnk_RecipeID").Value & "));")
				rs.moveNext()
			Loop 
		Next 
	End Sub
	Private Sub Mains()
		Dim iret As Integer
		Dim lHandle As Integer
		Dim rs As ADODB.Recordset
		Dim fso As New Scripting.FileSystemObject

        If fso.FileExists("C:\4POS\pos\data.ug") Then
            If fso.FileExists("C:\4POS\pos\4POSupgrade.exe") Then
                Shell("C:\4POS\pos\4POSupgrade.exe", AppWinStyle.NormalFocus)
            Else
                MsgBox("An upgrade is required, but the upgrade unility can not be located!" & vbCrLf & vbCrLf & "Please contact a 4POS representative to assist you in resolving this problem.", MsgBoxStyle.Critical, "UPGRADE")
            End If
            End
        End If

        setShortDateFormat()
        On Error Resume Next
        If VB.Command() = "" Then
            frmLogin.Show()
        Else
            frmMaster.Show()
        End If
	End Sub
	Public Sub updateStockMovement()
        Dim Path As String
        Dim strDBPath As String
		Dim lDayend As Integer
		Dim sql As String
		Dim cn As ADODB.Connection
		Dim rs As ADODB.Recordset
		On Error GoTo ErrHandlerr
		Dim errDesc As String
		
		System.Windows.Forms.Application.DoEvents()
		If modUpdate = 1 Then
			frmDayEnd.Label3.Text = "Please Wait, Stock Update progress..."
			frmDayEnd.Label3.Visible = True
		End If
		System.Windows.Forms.Application.DoEvents()
		System.Windows.Forms.Application.DoEvents()
		
		errDesc = "Starting Point"
		
		cnnDB.Execute("UPDATE Company INNER JOIN DayEndStockItemLnk ON Company.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales = 0, DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV = 0;")
		cnnDB.Execute("UPDATE DayEndDepositItemLnk INNER JOIN Company ON DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID = Company.Company_DayEndID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantitySales = 0, DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = 0;")
		'Multi Warehouse change
		'cnnDB.Execute "UPDATE Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN ((DayEndStockItemLnk INNER JOIN (Sale INNER JOIN company ON Sale.Sale_DayEndID = company.Company_DayEndID) ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = company.Company_DayEndID) INNER JOIN SaleItem ON (DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = SaleItem.SaleItem_StockItemID) AND (Sale.SaleID = SaleItem.SaleItem_SaleID)) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantitySales]+(IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) WHERE (((SaleItem.SaleItem_Recipe)=0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_DepositType)=0) AND ((Consignment.ConsignmentID) Is Null) AND ((Consignment_1.ConsignmentID) Is Null));"
		sql = "UPDATE Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN ((DayEndStockItemLnk INNER JOIN (Sale INNER JOIN company ON Sale.Sale_DayEndID = company.Company_DayEndID) ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = company.Company_DayEndID) INNER JOIN SaleItem ON (DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = SaleItem.SaleItem_StockItemID) AND (DayEndStockItemLnk.DayEndStockItemLnk_Warehouse = SaleItem.SaleItem_WarehouseID) AND (Sale.SaleID = SaleItem.SaleItem_SaleID)) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantitySales]+(IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) "
		sql = sql & "WHERE (((SaleItem.SaleItem_Recipe)=0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_DepositType)=0) AND ((Consignment.ConsignmentID) Is Null) AND ((Consignment_1.ConsignmentID) Is Null));"
		cnnDB.Execute(sql)
		
		'sql = "UPDATE SaleItemReciept INNER JOIN (Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN ((DayEndStockItemLnk INNER JOIN (Sale INNER JOIN company ON Sale.Sale_DayEndID = company.Company_DayEndID) ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = company.Company_DayEndID) INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID) ON (SaleItemReciept.SaleItemReciept_StockitemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) AND (SaleItemReciept.SaleItemReciept_SaleItemID = SaleItem.SaleItemID) SET DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantitySales]+(IIf([SaleItem_Reversal],0-[SaleItemReciept_Quantity]*[SaleItem_Quantity],[SaleItemReciept_Quantity]*[SaleItem_Quantity])) "
		sql = "UPDATE SaleItemReciept INNER JOIN (Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN ((DayEndStockItemLnk INNER JOIN (Sale INNER JOIN company ON Sale.Sale_DayEndID = company.Company_DayEndID) ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = company.Company_DayEndID) INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID AND DayEndStockItemLnk.DayEndStockItemLnk_Warehouse = SaleItem.SaleItem_WarehouseID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID) ON (SaleItemReciept.SaleItemReciept_StockitemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) AND (SaleItemReciept.SaleItemReciept_SaleItemID = SaleItem.SaleItemID) SET DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantitySales]+(IIf([SaleItem_Reversal],0-[SaleItemReciept_Quantity]*[SaleItem_Quantity],[SaleItemReciept_Quantity]*[SaleItem_Quantity])) "
		sql = sql & "WHERE (((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_DepositType)=0) AND ((Consignment.ConsignmentID) Is Null) AND ((Consignment_1.ConsignmentID) Is Null));"
		cnnDB.Execute(sql)
		'Multi Warehouse change
		
		'Multi Warehouse change     cnnDB.Execute "UPDATE ((StockItem INNER JOIN (DayEndStockItemLnk INNER JOIN GRVItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = GRVItem.GRVItem_StockItemID) ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID) INNER JOIN GRV ON (GRVItem.GRVItem_GRVID = GRV.GRVID) AND (DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = GRV.GRV_DayEndID)) INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV = [DayEndStockItemLnk_QuantityGRV]+IIf([GRVItem]![GRVItem_Return],0-[GRVItem_PackSize]*[GRVItem_Quantity],[GRVItem_PackSize]*[GRVItem_Quantity]) WHERE (((GRV.GRV_GRVStatusID)=3));"
		cnnDB.Execute("UPDATE ((StockItem INNER JOIN (DayEndStockItemLnk INNER JOIN GRVItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = GRVItem.GRVItem_StockItemID) ON StockItem.StockItemID = GRVItem.GRVItem_StockItemID) INNER JOIN GRV ON (GRVItem.GRVItem_GRVID = GRV.GRVID) AND (DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = GRV.GRV_DayEndID)) INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV = [DayEndStockItemLnk_QuantityGRV]+IIf([GRVItem]![GRVItem_Return],0-[GRVItem_PackSize]*[GRVItem_Quantity],[GRVItem_PackSize]*[GRVItem_Quantity]) WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=2) AND ((GRV.GRV_GRVStatusID)=3));")
		cnnDB.Execute("UPDATE GRV INNER JOIN ((Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN ((Deposit INNER JOIN StockItem ON Deposit.DepositID = StockItem.StockItem_DepositID) INNER JOIN GRVItem ON (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize) AND (StockItem.StockItemID = GRVItem.GRVItem_StockItemID)) ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = Deposit.DepositID) ON (GRV.GRVID = GRVItem.GRVItem_GRVID) AND (GRV.GRV_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]+(IIf([GRVItem]![GRVItem_Return],0-[GRVItem]![GRVItem_Quantity],[GRVItem]![GRVItem_Quantity])) WHERE (((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=1) AND ((GRV.GRV_GRVStatusID)=3));")
		cnnDB.Execute("UPDATE GRV INNER JOIN ((Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN ((Deposit INNER JOIN StockItem ON Deposit.DepositID = StockItem.StockItem_DepositID) INNER JOIN GRVItem ON (StockItem.StockItemID = GRVItem.GRVItem_StockItemID) AND (StockItem.StockItem_Quantity = GRVItem.GRVItem_PackSize)) ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = Deposit.DepositID) ON (GRV.GRV_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) AND (GRV.GRVID = GRVItem.GRVItem_GRVID) SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]+(IIf([GRVItem]![GRVItem_Return],0-[GRVItem]![GRVItem_Quantity],[GRVItem]![GRVItem_Quantity]))*[Deposit_Quantity] WHERE (((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=0) AND ((GRV.GRV_GRVStatusID)=3));")
		
		cnnDB.Execute("UPDATE GRV INNER JOIN ((Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN GRVDeposit ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID) ON (GRV.GRVID = GRVDeposit.GRVDeposit_GRVID) AND (GRV.GRV_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]-IIf([GRVDeposit]![GRVDeposit_Return],0-[GRVDeposit_Quantity]*[GRVDeposit_CaseQuantity],[GRVDeposit_Quantity]*[GRVDeposit_CaseQuantity]) WHERE (((GRVDeposit.GRVDeposit_Type)=1 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=0) AND ((GRV.GRV_GRVStatusID)=3));")
		cnnDB.Execute("UPDATE ((Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN GRVDeposit ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = GRVDeposit.GRVDeposit_DepositID) INNER JOIN GRV ON (GRV.GRV_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) AND (GRVDeposit.GRVDeposit_GRVID = GRV.GRVID) SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantityGRV = [DayEndDepositItemLnk]![DayEndDepositItemLnk_QuantityGRV]-IIf([GRVDeposit_Return],0-[GRVDeposit_Quantity],[GRVDeposit_Quantity]) WHERE (((GRVDeposit.GRVDeposit_Type)=2 Or (GRVDeposit.GRVDeposit_Type)=3) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=1) AND ((GRV.GRV_GRVStatusID)=3));")
		
		cnnDB.Execute("UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) ON (SaleItem.SaleItem_StockItemID = DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID) AND (Company.Company_DayEndID = Sale.Sale_DayEndID) SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantitySales = [DayEndDepositItemLnk_QuantitySales]-[SaleItem_Quantity] WHERE (((SaleItem.SaleItem_DepositType)=1) AND ((SaleItem.SaleItem_Revoke)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=0) AND ((SaleItem.SaleItem_Reversal)<>0));")
		cnnDB.Execute("UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) ON (SaleItem.SaleItem_StockItemID = DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID) AND (Company.Company_DayEndID = Sale.Sale_DayEndID) SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantitySales = [DayEndDepositItemLnk_QuantitySales]+[SaleItem_Quantity] WHERE (((SaleItem.SaleItem_DepositType)=1) AND ((SaleItem.SaleItem_Revoke)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=0) AND ((SaleItem.SaleItem_Reversal)=0));")
		
		cnnDB.Execute("UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) ON (SaleItem.SaleItem_StockItemID = DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID) AND (Company.Company_DayEndID = Sale.Sale_DayEndID) SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantitySales = [DayEndDepositItemLnk_QuantitySales]-[SaleItem_Quantity] WHERE (((SaleItem.SaleItem_DepositType)=2 Or (SaleItem.SaleItem_DepositType)=3) AND ((SaleItem.SaleItem_Revoke)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=1) AND ((SaleItem.SaleItem_Reversal)<>0));")
		cnnDB.Execute("UPDATE (Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) ON (SaleItem.SaleItem_StockItemID = DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID) AND (Company.Company_DayEndID = Sale.Sale_DayEndID) SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantitySales = [DayEndDepositItemLnk_QuantitySales]+[SaleItem_Quantity] WHERE (((SaleItem.SaleItem_DepositType)=2 Or (SaleItem.SaleItem_DepositType)=3) AND ((SaleItem.SaleItem_Revoke)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=1) AND ((SaleItem.SaleItem_Reversal)=0));")
		
		errDesc = "Middle Point"
		
		cnnDB.Execute("UPDATE Deposit INNER JOIN ((Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) ON (SaleItem.SaleItem_StockItemID = DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID) AND (Company.Company_DayEndID = Sale.Sale_DayEndID)) ON Deposit.DepositID = DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantitySales = [DayEndDepositItemLnk_QuantitySales]-([SaleItem_Quantity]*[Deposit_Quantity]) WHERE (((SaleItem.SaleItem_DepositType)=3) AND ((SaleItem.SaleItem_Revoke)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=0) AND ((SaleItem.SaleItem_Reversal)<>0));")
		cnnDB.Execute("UPDATE Deposit INNER JOIN ((Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) ON (SaleItem.SaleItem_StockItemID = DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID) AND (Company.Company_DayEndID = Sale.Sale_DayEndID)) ON Deposit.DepositID = DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantitySales = [DayEndDepositItemLnk_QuantitySales]+([SaleItem_Quantity]*[Deposit_Quantity]) WHERE (((SaleItem.SaleItem_DepositType)=3) AND ((SaleItem.SaleItem_Revoke)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=0) AND ((SaleItem.SaleItem_Reversal)=0));")
		
		cnnDB.Execute("UPDATE StockItem INNER JOIN (Deposit INNER JOIN ((Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) ON Company.Company_DayEndID = Sale.Sale_DayEndID) ON Deposit.DepositID = DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID) ON (SaleItem.SaleItem_StockItemID = StockItem.StockItemID) AND (StockItem.StockItem_DepositID = Deposit.DepositID) SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantitySales = [DayEndDepositItemLnk_QuantitySales]-([SaleItem_Quantity]*CInt([SaleItem_ShrinkQuantity]/[Deposit_Quantity]+0.04999)) WHERE (((SaleItem.SaleItem_DepositType)=0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=1) AND ((SaleItem.SaleItem_Reversal)=0));")
		cnnDB.Execute("UPDATE StockItem INNER JOIN (Deposit INNER JOIN ((Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) ON Company.Company_DayEndID = Sale.Sale_DayEndID) ON Deposit.DepositID = DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID) ON (SaleItem.SaleItem_StockItemID = StockItem.StockItemID) AND (StockItem.StockItem_DepositID = Deposit.DepositID) SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantitySales = [DayEndDepositItemLnk_QuantitySales]+([SaleItem_Quantity]*CInt([SaleItem_ShrinkQuantity]/[Deposit_Quantity]+0.04999)) WHERE (((SaleItem.SaleItem_DepositType)=0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=1) AND ((SaleItem.SaleItem_Reversal)<>0));")
		
		cnnDB.Execute("UPDATE StockItem INNER JOIN (Deposit INNER JOIN ((Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) ON Company.Company_DayEndID = Sale.Sale_DayEndID) ON Deposit.DepositID = DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID) ON (SaleItem.SaleItem_StockItemID = StockItem.StockItemID) AND (StockItem.StockItem_DepositID = Deposit.DepositID) SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantitySales = [DayEndDepositItemLnk_QuantitySales]-([SaleItem_Quantity]*[SaleItem_ShrinkQuantity]) WHERE (((SaleItem.SaleItem_DepositType)=0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=0) AND ((SaleItem.SaleItem_Reversal)=0));")
		cnnDB.Execute("UPDATE StockItem INNER JOIN (Deposit INNER JOIN ((Company INNER JOIN DayEndDepositItemLnk ON Company.Company_DayEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID) INNER JOIN (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) ON Company.Company_DayEndID = Sale.Sale_DayEndID) ON Deposit.DepositID = DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID) ON (SaleItem.SaleItem_StockItemID = StockItem.StockItemID) AND (StockItem.StockItem_DepositID = Deposit.DepositID) SET DayEndDepositItemLnk.DayEndDepositItemLnk_QuantitySales = [DayEndDepositItemLnk_QuantitySales]+([SaleItem_Quantity]*[SaleItem_ShrinkQuantity]) WHERE (((SaleItem.SaleItem_DepositType)=0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType)=0) AND ((SaleItem.SaleItem_Reversal)<>0));")
		
		If modUpdate = 1 Then
			frmDayEnd.Label3.Visible = False
		End If
		
		
		If Left(serverPath, 3) = "c:\" Then
			rs = getRS("SELECT Company.Company_DayEndID FROM Company;")
			lDayend = rs.Fields(0).Value
			dltDayEndID = lDayend
			cn = openConnectionInstance("templatereport.mdb")
			If cn Is Nothing Then
			Else
				
tryAgainPassword: 
				errDesc = "TemplateReport Point"
				cn.Execute("DELETE aDayEnd.* From aDayEnd WHERE (((aDayEnd.DayEndID)=" & lDayend & "));")
				cn.Execute("DELETE aDayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID From aDayEndDepositItemLnk WHERE (((aDayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID)=" & lDayend & "));")
				sql = "INSERT INTO aDayEndDepositItemLnk ( DayEndDepositItemLnk_DayEndID, DayEndDeposittemLnk_DepositID, DayEndDeposittemLnk_DepositType, DayEndDepositItemLnk_Quantity, DayEndDepositItemLnk_QuantitySales, DayEndDepositItemLnk_QuantityShrink, DayEndDepositItemLnk_QuantityGRV, DayEndDepositItemLnk_QuantityRecipe, DayEndDepositItemLnk_QuantityTransfer, DayEndDepositItemLnk_UnitCost, DayEndDepositItemLnk_CaseCost, DayEndDepositItemLnk_CaseQuantity ) "
				sql = sql & "SELECT aDayEndDepositItemLnk1.DayEndDepositItemLnk_DayEndID, aDayEndDepositItemLnk1.DayEndDeposittemLnk_DepositID, aDayEndDepositItemLnk1.DayEndDeposittemLnk_DepositType, aDayEndDepositItemLnk1.DayEndDepositItemLnk_Quantity, aDayEndDepositItemLnk1.DayEndDepositItemLnk_QuantitySales, aDayEndDepositItemLnk1.DayEndDepositItemLnk_QuantityShrink, aDayEndDepositItemLnk1.DayEndDepositItemLnk_QuantityGRV, aDayEndDepositItemLnk1.DayEndDepositItemLnk_QuantityRecipe, aDayEndDepositItemLnk1.DayEndDepositItemLnk_QuantityTransfer, aDayEndDepositItemLnk1.DayEndDepositItemLnk_UnitCost, aDayEndDepositItemLnk1.DayEndDepositItemLnk_CaseCost, aDayEndDepositItemLnk1.DayEndDepositItemLnk_CaseQuantity From aDayEndDepositItemLnk1 WHERE (((aDayEndDepositItemLnk1.DayEndDepositItemLnk_DayEndID)=" & lDayend & "));"
				cn.Execute(sql)
				
				cn.Execute("DELETE aGRVDeposit.* FROM aGRVDeposit INNER JOIN aGRV ON aGRVDeposit.GRVDeposit_GRVID = aGRV.GRVID WHERE (((aGRV.GRV_DayEndID)=" & lDayend & "));")
				cn.Execute("DELETE aGRVitem.* FROM aGRVitem INNER JOIN aGRV ON aGRVitem.GRVItem_GRVID = aGRV.GRVID WHERE (((aGRV.GRV_DayEndID)=" & lDayend & "));")
				cn.Execute("DELETE aGRV.* From aGRV WHERE (((aGRV.GRV_DayEndID)=" & lDayend & "));")
				cn.Execute("DELETE aPurchaseOrder.* From aPurchaseOrder WHERE (((aPurchaseOrder.PurchaseOrder_DayEndID)=" & lDayend & "));")
				
				cn.Execute("INSERT INTO aDayEnd SELECT aDayEnd1.* From aDayEnd1 WHERE (((aDayEnd1.DayEndID)=" & lDayend & "));")
				
				cn.Execute("INSERT INTO aPurchaseOrder SELECT aPurchaseOrder1.* From aPurchaseOrder1 WHERE (((aPurchaseOrder1.PurchaseOrder_DayEndID)=" & lDayend & "));")
				cn.Execute("INSERT INTO agrv SELECT aGRV1.* From aGRV1 WHERE (((aGRV1.GRV_DayEndID)=" & lDayend & "));")
				cn.Execute("INSERT INTO aGRVItem SELECT aGRVItem1.* FROM aGRVItem1 INNER JOIN aGRV1 ON aGRVItem1.GRVItem_GRVID = aGRV1.GRVID WHERE (((aGRV1.GRV_DayEndID)=" & lDayend & "));")
				cn.Execute("INSERT INTO aGRVDeposit SELECT aGRVDeposit1.* FROM aGRVDeposit1 INNER JOIN aGRV1 ON aGRVDeposit1.GRVDeposit_GRVID = aGRV1.GRVID WHERE (((aGRV1.GRV_DayEndID)=" & lDayend & "));")
				
			End If
		End If
		
		Exit Sub
ErrHandlerr: 
		If Err.Description = "Not a valid password." Then
			
			cnnDB.Close()
			cnnDB = Nothing
			cnnDB = New ADODB.Connection
			strDBPath = serverPath & "pricing.mdb"
			Path = strDBPath & ";Jet " & "OLEDB:Database Password=lqd"
			'cnnDB.CursorLocation = adUseClient
			cnnDB.Open("Provider=Microsoft.ACE.OLEDB.12.0;Mode=Share Deny Read|Share Deny Write;Persist Security Info=False;Data Source= " & Path)
			cnnDB.Execute("ALTER DATABASE PASSWORD Null " & " " & "lqd")
			cnnDB.Close()
			cnnDB = Nothing
			openConnection()
			
			GoTo tryAgainPassword
			'Resume Next
		Else
			MsgBox("Error while UpdateStockMovement on " & errDesc & " : " & Err.Number & " : " & Err.Description & " : " & Err.Source)
			Resume Next
		End If
	End Sub
	Private Sub linkTables()
		Dim cat As ADOX.Catalog
		Dim tbl As ADOX.Table
		Dim fso As New Scripting.FileSystemObject
		
		If fso.FileExists(strLocation) Then
		Else
			Exit Sub
		End If
		
		cat = New ADOX.Catalog
		Dim x As Short
		' Open the catalog.
		cat.let_ActiveConnection(cnnDBConsReport)
		
		For x = cat.Tables.Count - 1 To 0 Step -1
			Select Case LCase(cat.Tables(x).Name)
				Case "acustomertransaction", "adayendstockitemlnk", "adeclaration", "asale", "asaleitem", "asuppliertransaction"
					cat.Tables.delete(cat.Tables(x).Name)
			End Select
		Next 
		tbl = New ADOX.Table
		tbl.Name = "aCustomerTransaction"
		tbl.ParentCatalog = cat
		tbl.Properties("Jet OLEDB:Link Datasource").Value = strLocation
		tbl.Properties("Jet OLEDB:Remote Table Name").Value = "CustomerTransaction"
		tbl.Properties("Jet OLEDB:Create Link").Value = True
		cat.Tables.Append(tbl)
		
		tbl = New ADOX.Table
		tbl.Name = "aDayEndStockItemLnk"
		tbl.ParentCatalog = cat
		tbl.Properties("Jet OLEDB:Link Datasource").Value = strLocation
		tbl.Properties("Jet OLEDB:Remote Table Name").Value = "DayEndStockItemLnk"
		tbl.Properties("Jet OLEDB:Create Link").Value = True
		cat.Tables.Append(tbl)
		
		tbl = New ADOX.Table
		tbl.Name = "aDeclaration"
		tbl.ParentCatalog = cat
		tbl.Properties("Jet OLEDB:Link Datasource").Value = strLocation
		tbl.Properties("Jet OLEDB:Remote Table Name").Value = "Declaration"
		tbl.Properties("Jet OLEDB:Create Link").Value = True
		cat.Tables.Append(tbl)
		
		
		tbl = New ADOX.Table
		tbl.Name = "aSale"
		tbl.ParentCatalog = cat
		tbl.Properties("Jet OLEDB:Link Datasource").Value = strLocation
		tbl.Properties("Jet OLEDB:Remote Table Name").Value = "Sale"
		tbl.Properties("Jet OLEDB:Create Link").Value = True
		cat.Tables.Append(tbl)
		
		tbl = New ADOX.Table
		tbl.Name = "aSaleItem"
		tbl.ParentCatalog = cat
		tbl.Properties("Jet OLEDB:Link Datasource").Value = strLocation
		tbl.Properties("Jet OLEDB:Remote Table Name").Value = "SaleItem"
		tbl.Properties("Jet OLEDB:Create Link").Value = True
		cat.Tables.Append(tbl)
		'
		tbl = New ADOX.Table
		tbl.Name = "aSupplierTransaction"
		tbl.ParentCatalog = cat
		tbl.Properties("Jet OLEDB:Link Datasource").Value = strLocation
		tbl.Properties("Jet OLEDB:Remote Table Name").Value = "SupplierTransaction"
		tbl.Properties("Jet OLEDB:Create Link").Value = True
		cat.Tables.Append(tbl)
		
		cat.Tables.Refresh()
		
		cat = Nothing
		
	End Sub
	
	Private Sub linkFirstTable(ByRef Source As String)
		Dim cat As ADOX.Catalog
		Dim tbl As ADOX.Table
		Dim fso As New Scripting.FileSystemObject
		If fso.FileExists(strLocation) Then
		Else
			Exit Sub
		End If
		
		cat = New ADOX.Catalog
		Dim x As Short
		'Open the catalog.
		
		'MsgBox StrLocRep
		
		cat.let_ActiveConnection(cnnDBConsReport)
		
		For x = cat.Tables.Count - 1 To 0 Step -1
			Select Case LCase(cat.Tables(x).Name)
				Case "adayendstockitemlnk"
					cat.Tables.delete(cat.Tables(x).Name)
			End Select
		Next 
		
		tbl = New ADOX.Table
		
		tbl.Name = "aDayEndStockItemLnk"
		tbl.ParentCatalog = cat
		tbl.Properties("Jet OLEDB:Link Datasource").Value = strLocation
		tbl.Properties("Jet OLEDB:Remote Table Name").Value = "DayEndStockItemLnk"
		tbl.Properties("Jet OLEDB:Create Link").Value = True
		cat.Tables.Append(tbl)
		cat.Tables.Refresh()
		
		cat = Nothing
		
	End Sub
	Private Sub beginConsUpdate()
        Dim gTotal As Integer
        Dim gModeReport As Boolean
        Dim gCNT As Integer
		'picInner.Width = 0
		gCNT = 0
		System.Windows.Forms.Application.DoEvents()
		Dim x As Short
		Dim sql As String
		Dim rs As ADODB.Recordset
		Dim fso As New Scripting.FileSystemObject
		Dim lMode As Boolean
		
		gModeReport = False
		
		cnnDBConsReport.Execute("DELETE * FROM DayEnd")
		cnnDBConsReport.Execute("INSERT INTO dayend ( DayEndID, DayEnd_MonthEndID, DayEnd_Date ) SELECT aDayEnd.DayEndID, aDayEnd.DayEnd_MonthEndID, aDayEnd.DayEnd_Date From aDayEnd, Report WHERE (((aDayEnd.DayEndID)>=[Report]![Report_DayEndStartID] And (aDayEnd.DayEndID)<=[Report]![Report_DayEndEndID]));")
		
		cnnDBConsReport.Execute("DELETE DayEndStockItemLnkFirst.* FROM DayEndStockItemLnkFirst;")
		
		rs = getRSreport1("SELECT aDayEnd.*, aCompany.Company_DayEndID, aCompany.Company_MonthEndID From aDayEnd, Report, aCompany WHERE (((aDayEnd.DayEndID)=[Report]![Report_DayEndStartID]-1));")
		
		If rs.RecordCount Then
			If rs.Fields("DayEnd_MonthEndID").Value = rs.Fields("Company_MonthEndID").Value Then
				'linkFirstTable "pricing"
			Else
				'linkFirstTable "month" & rs("DayEnd_MonthEndID")
			End If
			
			cnnDBConsReport.Execute("DELETE * FROM DayEndStockItemLnkFirst")
			cnnDBConsReport.Execute("INSERT INTO DayEndStockItemLnkFirst SELECT aDayEndStockItemLnk.* FROM Report, aDayEndStockItemLnk INNER JOIN aDayEnd ON aDayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aDayEnd.DayEndID WHERE (((aDayEnd.DayEndID)=[Report]![Report_DayEndStartID]-1));")
			
		End If
		
		rs.Close()
		
		rs = getRSreport1("SELECT DISTINCT DayEnd.DayEnd_MonthEndID, aCompany.Company_MonthEndID FROM DayEnd, aCompany;")
		
		gTotal = 9 + rs.RecordCount * 9
		
		cnnDBConsReport.Execute("DELETE Payout.* FROM Payout;")
		cnnDBConsReport.Execute("INSERT INTO Payout SELECT aPayout.* From Report, aPayout WHERE (((aPayout.Payout_DayEndID)>=[Report]![Report_DayEndStartID] And (aPayout.Payout_DayEndID)<=[Report]![Report_DayEndEndID]));")
		
		
		cnnDBConsReport.Execute("DELETE * FROM DayEndStockItemLnk")
		
		cnnDBConsReport.Execute("DELETE * FROM DayEndDepositItemLnk")
		
		cnnDBConsReport.Execute("DELETE SaleItem.* FROM SaleItem;")
		
		
		cnnDBConsReport.Execute("DELETE Sale.* FROM Sale;")
		
		cnnDBConsReport.Execute("DELETE CustomerTransaction.* FROM CustomerTransaction;")
		
		cnnDBConsReport.Execute("DELETE Declaration.* FROM Declaration;")
		
		cnnDBConsReport.Execute("DELETE SupplierTransaction.* FROM SupplierTransaction;")
		
		cnnDBConsReport.Execute("INSERT INTO DayEndStockItemLnk SELECT aDayEndStockItemLnk.* FROM aDayEndStockItemLnk INNER JOIN DayEnd ON aDayEndStockItemLnk.DayEndStockItemLnk_DayEndID = DayEnd.DayEndID;")
		
		On Error Resume Next
		cnnDBConsReport.Execute("INSERT INTO DayEndDepositItemLnk SELECT aDayEndDepositItemLnk.* FROM aDayEndDepositItemLnk INNER JOIN DayEnd ON aDayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID = DayEnd.DayEndID;")
		
		cnnDBConsReport.Execute("INSERT INTO sale SELECT aSale.* FROM [SELECT aSale.* FROM aSale LEFT JOIN Sale ON aSale.SaleID = Sale.SaleID WHERE (((Sale.SaleID) Is Null))]. AS aSale, Report WHERE (((aSale.Sale_DayEndID)>=[Report]![Report_DayEndStartID] And (aSale.Sale_DayEndID)<=[Report]![Report_DayEndEndID]));")
		
		cnnDBConsReport.Execute("INSERT INTO SaleItem SELECT aSaleItem.* FROM (aSaleItem INNER JOIN Sale ON aSaleItem.SaleItem_SaleID = Sale.SaleID) LEFT JOIN SaleItem ON aSaleItem.SaleItemID = SaleItem.SaleItemID WHERE (((SaleItem.SaleItemID) Is Null));")
		
		cnnDBConsReport.Execute("INSERT INTO CustomerTransaction SELECT aCustomerTransaction.* From Report, aCustomerTransaction WHERE (((aCustomerTransaction.CustomerTransaction_DayEndID)>=[Report]![Report_DayEndStartID] And (aCustomerTransaction.CustomerTransaction_DayEndID)<=[Report]![Report_DayEndEndID]));")
		
		
		sql = "INSERT INTO SupplierTransaction ( SupplierTransactionID, SupplierTransaction_SupplierID, SupplierTransaction_PersonID, SupplierTransaction_TransactionTypeID, SupplierTransaction_MonthEndID, SupplierTransaction_MonthEndIDFor, SupplierTransaction_DayEndID, SupplierTransaction_ReferenceID, SupplierTransaction_Date, SupplierTransaction_Description, SupplierTransaction_Amount, SupplierTransaction_Reference )"
		sql = sql & "SELECT aSupplierTransaction.SupplierTransactionID, aSupplierTransaction.SupplierTransaction_SupplierID, aSupplierTransaction.SupplierTransaction_PersonID, aSupplierTransaction.SupplierTransaction_TransactionTypeID, aSupplierTransaction.SupplierTransaction_MonthEndID, aSupplierTransaction.SupplierTransaction_MonthEndIDFor, aSupplierTransaction.SupplierTransaction_DayEndID, aSupplierTransaction.SupplierTransaction_ReferenceID, aSupplierTransaction.SupplierTransaction_Date, aSupplierTransaction.SupplierTransaction_Description, aSupplierTransaction.SupplierTransaction_Amount, aSupplierTransaction.SupplierTransaction_Reference FROM aSupplierTransaction INNER JOIN DayEnd ON aSupplierTransaction.SupplierTransaction_DayEndID = DayEnd.DayEndID;"
		
		sql = "INSERT INTO SupplierTransaction ( SupplierTransactionID, SupplierTransaction_SupplierID, SupplierTransaction_PersonID, SupplierTransaction_TransactionTypeID, SupplierTransaction_MonthEndID, SupplierTransaction_MonthEndIDFor, SupplierTransaction_DayEndID, SupplierTransaction_ReferenceID, SupplierTransaction_Date, SupplierTransaction_Description, SupplierTransaction_Amount, SupplierTransaction_Reference ) "
		sql = sql & "SELECT [SupplierTransaction_MonthEndID] & [SupplierTransactionID] AS Expr1, aSupplierTransaction.SupplierTransaction_SupplierID, aSupplierTransaction.SupplierTransaction_PersonID, aSupplierTransaction.SupplierTransaction_TransactionTypeID, aSupplierTransaction.SupplierTransaction_MonthEndID, aSupplierTransaction.SupplierTransaction_MonthEndIDFor, aSupplierTransaction.SupplierTransaction_DayEndID, aSupplierTransaction.SupplierTransaction_ReferenceID, aSupplierTransaction.SupplierTransaction_Date, aSupplierTransaction.SupplierTransaction_Description, aSupplierTransaction.SupplierTransaction_Amount, aSupplierTransaction.SupplierTransaction_Reference FROM aSupplierTransaction INNER JOIN DayEnd ON aSupplierTransaction.SupplierTransaction_DayEndID = DayEnd.DayEndID;"
		
		cnnDBConsReport.Execute(sql)
		
		cnnDBConsReport.Execute("INSERT INTO Declaration SELECT aDeclaration.* From Report, aDeclaration WHERE (((aDeclaration.Declaration_DayEndID)>=[Report]![Report_DayEndStartID] And (aDeclaration.Declaration_DayEndID)<=[Report]![Report_DayEndEndID]));")
		
		cnnDBConsReport.Execute("UPDATE aCompany INNER JOIN (DayEndStockItemLnk INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) ON aCompany.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_ListCost = [aStockItem]![StockItem_ListCost]/[aStockItem]![StockItem_Quantity], DayEndStockItemLnk.DayEndStockItemLnk_ActualCost = [aStockItem]![StockItem_ActualCost]/[aStockItem]![StockItem_Quantity];")
		
		cnnDBConsReport.Execute("UPDATE Report SET Report.Report_Type = " & lMode & ";")
		
		rs = getRSreport1("SELECT DayEnd.DayEndID FROM aCompany INNER JOIN DayEnd ON aCompany.Company_DayEndID = DayEnd.DayEndID;")
		
		If rs.RecordCount Then
			cnnDBConsReport.Execute("UPDATE Report SET Report.Report_Heading = [Report_Heading] & '(*)';")
			
			cnnDBConsReport.Execute("UPDATE aCompany INNER JOIN DayEndStockItemLnk ON aCompany.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales = 0, DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV = 0;")
			cnnDBConsReport.Execute("UPDATE aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN ((DayEndStockItemLnk INNER JOIN (Sale INNER JOIN aCompany ON Sale.Sale_DayEndID = aCompany.Company_DayEndID) ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aCompany.Company_DayEndID) INNER JOIN SaleItem ON (DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = SaleItem.SaleItem_StockItemID) AND (Sale.SaleID = SaleItem.SaleItem_SaleID)) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantitySales]+(IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) WHERE (((SaleItem.SaleItem_Recipe)=0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_DepositType)=0) AND ((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null));")
			
			sql = "UPDATE aSaleItemReciept INNER JOIN (aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN ((DayEndStockItemLnk INNER JOIN (Sale INNER JOIN aCompany ON Sale.Sale_DayEndID = aCompany.Company_DayEndID) ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aCompany.Company_DayEndID) INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID) ON (aSaleItemReciept.SaleItemReciept_StockitemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) AND (aSaleItemReciept.SaleItemReciept_SaleItemID = SaleItem.SaleItemID) SET DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantitySales]+(IIf([SaleItem_Reversal],0-[SaleItemReciept_Quantity]*[SaleItem_Quantity],[SaleItemReciept_Quantity]*[SaleItem_Quantity])) "
			sql = sql & "WHERE (((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_DepositType)=0) AND ((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null));"
			
			cnnDBConsReport.Execute(sql)
			
			cnnDBConsReport.Execute("UPDATE aGRV INNER JOIN ((aCompany INNER JOIN DayEndStockItemLnk ON aCompany.Company_DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aGRVItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aGRVItem.GRVItem_StockItemID) ON (DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aGRV.GRV_DayEndID) AND (aGRV.GRVID = aGRVItem.GRVItem_GRVID) SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV = [DayEndStockItemLnk_QuantityGRV]+IIf([aGRVItem]![GRVItem_Return],0-[GRVItem_PackSize]*[GRVItem_Quantity],[GRVItem_PackSize]*[GRVItem_Quantity]) WHERE (((aGRV.GRV_GRVStatusID)=3));")
		End If
		
	End Sub
	
	Public Sub ExportStockOrlando()
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
		
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		'
		'    frmStockTakeSnapshot.remoteSnapShot
		'    DoEvents
		
		Dim lMWNo As Integer
		lMWNo = 0
		If MsgBox("Do you wish to export consolidated quantities for all warehouses?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
			sql = "SELECT Catalogue.Catalogue_Barcode AS BAR_CODE, StockItem.StockItem_Name AS PRODUCT_DESCRIPTION, StockItem.StockItem_ActualCost AS COST, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS STOCK, StockGroup.StockGroup_Name AS DEPT FROM WarehouseStockItemLnk INNER JOIN ((StockItem INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID GROUP BY Catalogue.Catalogue_Barcode, StockItem.StockItem_Name, StockItem.StockItem_ActualCost, StockGroup.StockGroup_Name, Catalogue.Catalogue_Quantity, StockItem.StockItem_Disabled, StockItem.StockItem_Discontinued HAVING (((Catalogue.Catalogue_Barcode)<>'') AND ((Catalogue.Catalogue_Quantity)=1) AND ((StockItem.StockItem_Disabled)=False) AND ((StockItem.StockItem_Discontinued)=False));"
		Else
			lMWNo = frmMWSelect.getMWNo
			If lMWNo <> 0 Then
				sql = "SELECT Catalogue.Catalogue_Barcode AS BAR_CODE, StockItem.StockItem_Name AS PRODUCT_DESCRIPTION, StockItem.StockItem_ActualCost AS COST, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS STOCK, StockGroup.StockGroup_Name AS DEPT FROM WarehouseStockItemLnk INNER JOIN ((StockItem INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID "
				sql = sql & "GROUP BY Catalogue.Catalogue_Barcode, StockItem.StockItem_Name, StockItem.StockItem_ActualCost, StockGroup.StockGroup_Name, Catalogue.Catalogue_Quantity, StockItem.StockItem_Disabled, StockItem.StockItem_Discontinued, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID HAVING (((Catalogue.Catalogue_Barcode)<>'') AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=" & lMWNo & ") AND ((Catalogue.Catalogue_Quantity)=1) AND ((StockItem.StockItem_Disabled)=False) AND ((StockItem.StockItem_Discontinued)=False));"
			Else
				Exit Sub
			End If
		End If
		
		Dim ptbl As String
		Dim t_Day As String
		Dim t_Mon As String
		
		If Len(Trim(Str(VB.Day(Today)))) = 1 Then t_Day = "0" & Trim(CStr(VB.Day(Today))) Else t_Day = CStr(VB.Day(Today))
		If Len(Trim(Str(Month(Today)))) = 1 Then t_Mon = "0" & Trim(CStr(Month(Today))) Else t_Mon = Str(Month(Today))
		
		ptbl = serverPath & "4POSStockExp" & Trim(CStr(Year(Today))) & Trim(t_Mon) & Trim(t_Day)
		
		If fso.FileExists(ptbl & ".csv") Then fso.DeleteFile((ptbl & ".csv"))
		
		FileOpen(1, ptbl & ".csv", OpenMode.Output)
		'Open serverPath & "ProductPerformace.csv" For Output As #1
		
		rs = getRS(sql)
		'Write Out CSV
		If rs.BOF Or rs.EOF Then
			MsgBox("There are no recods to export.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "Export Stock")
            System.Windows.Forms.Cursor.Current = Cursors.Default
			Exit Sub
		Else
			For n = 0 To rs.Fields.Count - 1 'First line as column headings
				lne = lne & Chr(34) & rs.Fields(n).Name & Chr(34) & ","
			Next n
			lne = lne & Chr(34) & "NEW_STOCK" & Chr(34)
			
			'Print #1, lne
			
			Do While Not rs.EOF
				lne = ""
				For n = 0 To rs.Fields.Count - 1
					
					If rs.Fields(n).Type = dbText Then
						lne = lne & Chr(34) & rs.Fields(n).Value & Chr(34) & ","
					Else
						'If n = 0 Then
						'  lne = lne & "'" & rs(n) & "'" & ","
						'Else
						lne = lne & rs.Fields(n).Value & ","
						'End If
					End If
				Next n
				lne = Left(lne, Len(lne) - 1) 'get rid of last comma
				lne = lne & ",0"
				PrintLine(1, lne)
				rs.moveNext()
			Loop 
			
			FileClose(1)
			MsgBox("Stock CSV File was successfully exported to : " & ptbl & ".csv")
		End If
        System.Windows.Forms.Cursor.Current = Cursors.Default
	End Sub
	
	'Public Sub ImportStockOrlando()
	'
	'
	'    frmStockTakeAdd.loadItem gID
	'
	'    Set rs = getRS("SELECT StockGroup_Name FROM StockGroup WHERE StockGroupID =" & Val(DataList1.BoundText))
	'    If UCase(mID$(rs("StockGroup_Name"), 1, 8)) = "HANDHELD" Then
	'        grpDelete = Trim(rs("StockGroup_Name"))
	'
	'        cnnDB.Execute "DROP TABLE " & grpDelete
	'        cnnDB.Execute "DELETE * FROM StockGroup WHERE StockGroup_Name ='" & grpDelete & "'"
	'        loadItem1 2
	'    End If
	'End Sub
	
	
	Public Sub doMenuForms(ByRef lName As String)
		Dim frmBuildWizard As Object
		Dim frmRecipeList As Object
		Dim frmBackOfficeSetup As Object
		Dim frmProductPerfomance As Object
		Dim rs As ADODB.Recordset
		
		Debug.Print(lName)
		
		Dim rsWH As ADODB.Recordset
		Select Case LCase(lName)
			Case "frmexportstockorlando"
				ExportStockOrlando()
			Case "frmimportstockorlando"
				exUt_variable = 1
				frmImportStock.loadItems(1)
			Case "frmmaintainfloatcents"
				frmFloatLister.ShowDialog()
			Case "frmexportproductperf"
				frmExportProductPerfomace.ShowDialog()
			Case "frmglobalupdates"
				frmGlobalFilter.editItem(0)
			Case "frmmaintainscaleweights"
				frmMaintainWeight.loadItem(0)
			Case "frmstockitembarcodesfile"
				On Error Resume Next
				grvPrin = True
				frmBarcode.ShowDialog()
			Case "frmmaintaincurreny"
				frmCurrencySetup.loadItem(0)
			Case "frmmaintainpastelprinting"
				frmPastelVariables.loadItem(0)
			Case "frmhandheldutilities"
				exUt_variable = 1
				frmExport.loadItems(1)
			Case "frmstocktakecsv" 'Jonas
				frmStockTakeCSV.ShowDialog()
			Case "frmstocktakeliq"
				frmStockTakeLIQ.ShowDialog()
			Case "frmzeroise"
				'exUt_variable = 1
				frmZeroise.ShowDialog()
			Case "frmpastelexportfile"
				blpastel = True
				report_VATPASTEL()
				ExportToCSVFile()
			Case "frmpastelaccounting"
				blpastel = False
				report_VATPASTEL()
			Case "frmcreatebarcodes"
				'Jonas Wrote Barcode design
				On Error Resume Next
				frmDesign.ShowDialog()
			Case "frmpricechangerep"
				'Jonas wrote rep for Price change
				'frmpricechange.show 1
				report_NewPriceChange()
			Case "frmrecipeutilities"
				exUt_variable = 2
				frmExport.loadItems(2)
			Case "frmconsolidatedperformance"
				frmProductPerfomance.show(1)
			Case "frmvatreporting"
				report_VATrepporting()
			Case "frmdayhourlyreport"
				report_HourlyDayReport()
			Case "frmhourlyreport"
				report_HourlyReport()
			Case "report_bom"
				frmRPfilter.loadItem("recipe")
			Case "frmprintlocation"
				frmPrintLocationList.ShowDialog()
			Case "report_pricelistreal"
				frmReportPriceList.ShowDialog()
			Case "report_printstockserials"
				report_PrintStockSerialsRPT()
			Case "dobackofficemode"
				If UCase(InputBox("Input Access Code", "Access Code", "")) = "4POSADMIN" Then
					frmBackOfficeSetup.show(1)
				End If
			Case "report_dayend"
				frmDayEndList.loadItem(0)
			Case "frmcashtransaction"
				frmCashTransaction.loadItem()
			Case "frmincrement"
				frmIncrementList.loadItem()
			Case "frmpacksize"
				frmPackSizeList.loadItem()
			Case "frmrecipe"
				frmRecipeList.show(1)
			Case "frmmonthendlist"
				frmMonthendList.loadItem(0)
			Case "frmpricelist"
				frmPricelistList.loadItem(0)
			Case "frmpricelistfilter"
				frmPricelistFilterList.loadItem(0)
			Case "frmincomeexpense"
				frmIncomeExpense.ShowDialog()
			Case "frmstockbreak"
				frmStockBreakList.loadItem(0)
			Case "frmstockbreakshrink"
				frmStockBreakShrink.loadItem(0)
			Case "frmvnc"
				frmVNC.ShowDialog()
			Case "frmpromotion"
				frmPromotionList.loadItem(0)
			Case "frmgrvpromotion"
				frmGRVPromotionList.loadItem(0)
			Case "frmpriceset"
				frmPriceSetList.ShowDialog()
			Case "report_stockvalue"
				'report_StockValue
				'report_StockValuebyG
				'report_StockValueByDept (35)
				frmStockValSelect.ShowDialog()
			Case "report_stockvaluebydept" '4 Now pricing group
				frmStockGroupList.loadItem(4)
			Case "report_depositvalue"
				report_DepositValue()
			Case "frmdepositvalrepdb"
				report_DepositValue_FromRepDB()
			Case "report_stocknegative"
				report_StockNegative()
			Case "report_stockitemfixedactual"
				report_StockItemFixedActual()
			Case "report_stockitembrokenpack"
				report_StockItemBrokenPack()
			Case "report_stockitemdisabled"
				report_StockItemDisabled()
			Case "report_stockitemdiscontinued"
				report_StockItemDiscontinued()
			Case "frmquotedelete"
				frmQuoteDelete.ShowDialog()
			Case "frmsupplierstatement"
				frmSupplierStatement.ShowDialog()
			Case "frmcustomerstatement"
				frmCustomerStatement.ShowDialog()
			Case "report_pricinggroup"
				report_PricingGroup()
			Case "report_pricingmatrix"
				'report_PricingMatrix
			Case "report_deposits"
				report_Deposits()
			Case "report_sets"
				report_Sets()
			Case "frmdayend"
				frmDayEnd.ShowDialog()
			Case "frmmonthend"
				frmMonthEnd.ShowDialog()
			Case "frmcalculateinterest"
				frmCompanySetup.CalcIntPeriod()
			Case "frmcustomerstatementrun"
				frmCustomerStatementRun.loadItem()
			Case "frmstocktakesnapshot"
				frmStockTakeSnapshot.ShowDialog()
			Case "frmstocktakeprint"
				frmStockGroupList.loadItem(1)
			Case "frmkeyboard"
				frmKeyboardList.loadItem(0)
			Case "frmlanguage"
				frmLangList.loadItem(0)
			Case "frmstockprint"
				'bolCompChk = frmSelCompChk.loadDB(arrCompChk())
				frmStockGroupList.loadItem(3)
			Case "frmstocktakeedit"
				frmStockGroupList.loadItem(2)
			Case "frmstocktakeedits"
				frmStockGroupList.loadItem(5)
			Case "frmpossetup"
				frmPOSsetup.loadItem()
			Case "frmcompanysetup"
				frmCompanySetup.loadItem()
			Case "frmbuildbarcodes"
				buildBarcodes()
				MsgBox("Done", MsgBoxStyle.Information, "Build All Barcodes")
			Case "frmrpstockitemoverride"
				report_StockItemOverride()
			Case "frmupdateposcriteria"
				frmUpdatePOScriteria.ShowDialog()
			Case "frmrpstockitempropped"
				report_StockItemPropped()
			Case "frmrpstockduplicatecodes"
				report_StockItemDuplicateCodes()
			Case "frmrpfilter stockitemgrouping"
				frmRPfilter.loadItem("stockitemGrouping")
			Case "frmrpfilter stockitemorderlevels"
				frmRPfilter.loadItem("stockitemOrderLevels")
			Case "frmrppricecompare"
				frmRPpriceCompare.ShowDialog()
			Case "frmstockmulticost"
				frmStockMultiCost.ShowDialog()
			Case "frmstockmultiprice"
				frmStockMultiPrice.ShowDialog()
			Case "frmstockmultibarcode"
				frmStockMultiBarcode.ShowDialog()
			Case "frmstockmultiname"
				frmStockMultiName.ShowDialog()
			Case "frmstockitemnew"
				frmStockItemNew.ShowDialog()
			Case "frmstockitem"
				frmStockList.editItem(0)
				frmStockList.ShowDialog()
			Case "frmperson"
				frmPersonList.ShowDialog()
			Case "frmstockprice"
				frmStockList.editItem(1)
				frmStockList.ShowDialog()
			Case "frmmakefinishitem"
				frmMakeFinishItem.makeItem()
			Case "frmblocktest"
				frmBlockTest.makeItem()
			Case "frmvegproduction"
				frmVegTest.makeItem()
			Case "frmcustomer"
				frmCustomerList.loadItem(0)
			Case "frmcustomerhistory"
				frmCustomerList.loadItem(6)
			Case "frmallocatepayment"
				rs = getRS("SELECT Company_OpenDebtor From Company;")
				If rs.RecordCount Then
					If rs.Fields("Company_OpenDebtor").Value = True Then
						frmCustomerList.loadItem(7)
					Else
						MsgBox("In order to use this option you need to Select 'OPEN ITEM DEBTOR' option under 'Store Setup and Security' -> 'General Parameters'")
					End If
				Else
					MsgBox("Please download the latest 4POS upgrades!")
				End If
				
			Case "frmcustomerpayment"
				frmCustomerList.loadItem(1)
			Case "frmcustomerdebit"
				frmCustomerList.loadItem(2)
			Case "frmcustomercredit"
				frmCustomerList.loadItem(3)
			Case "frmcustomerdebitnote"
				frmCustomerList.loadItem(4)
			Case "frmcustomercreditnote"
				frmCustomerList.loadItem(5)
				
			Case "frmzeroisecd"
				frmZeroiseCD.ShowDialog()
			Case "frmzeroiseed"
				frmZeroiseED.ShowDialog()
				
			Case "frmsupplier"
				frmSupplierList.loadItem(0)
			Case "frmsupplierpayment"
				frmSupplierList.loadItem(1)
			Case "frmsupplierdebit"
				frmSupplierList.loadItem(2)
			Case "frmsuppliercredit"
				frmSupplierList.loadItem(3)
			Case "frmsupplierdeposit"
				frmSupplierList.loadItem(4)
			Case "frmchannel"
				frmChannelList.ShowDialog()
			Case "frmpos"
				frmPOSlist.ShowDialog()
			Case "frmwh"
				frmWHlist.ShowDialog()
			Case "frmpayoutreason"
				frmPayoutGroupList.loadItem(0)
			Case "frmpricinggroup"
				frmPricingGroupList.ShowDialog()
			Case "frmstockgroup"
				frmStockGroupList.loadItem(0)
			Case "frmdeposit"
				frmDepositList.ShowDialog()
			Case "frmdeposittakeprint"
				report_DepositTake()
			Case "frmdeposittakeedit"
				frmDepositTake.loadItem()
			Case "frmpricingmatrix"
				frmPricingMatrix.ShowDialog()
			Case "frmset"
				frmSetList.ShowDialog()
			Case "frmreportgroups"
				frmReportGroupList.ShowDialog()
			Case "frmstocktransfer"
				frmStockTransfer.ShowDialog()
			Case "frmstocktransfermw"
				'Multi Warehouse change     frmStockTransfer.show 1
				frmStockTransferWH.ShowDialog()
			Case "frmorder"
				frmOrder.ShowDialog()
			Case "frmorderprint"
				frmOrderPrint.ShowDialog()
			Case "frmgrv"
				frmGRVselect.loadItem()
			Case "frmgrvprint"
				frmGRVprint.ShowDialog()
			Case "frmorderwizard"
				frmOrderWizard.ShowDialog()
			Case "frmgrvblind"
				frmGRVblind.ShowDialog()
			Case "frmstockitembarcodes"
				On Error Resume Next '*Removes the error "Object was unloaded" on Security Access Barcoodes Submenu
				grvPrin = False
				frmBarcode.ShowDialog()
			Case "frmstockitembarcodesscale"
				On Error Resume Next '*Removes the error "Object was unloaded" on Security Access Barcoodes Submenu
				grvPrin = False
				scaleBCPrint = True
				frmBarcode.ShowDialog()
				scaleBCPrint = False
			Case "frmpersonbarcodes"
				On Error Resume Next
				frmBarcodePerson.ShowDialog()
			Case "report_stocksalesshrink"
				frmStockSalesShrink.ShowDialog()
			Case "report_stockitemsales"
				rsWH = getRS("SELECT COUNT(WarehouseID) AS COUNTWarehouseID FROM Warehouse;")
				If rsWH.RecordCount Then
					If IsDbNull(rsWH.Fields("COUNTWarehouseID").Value) Then
					Else
						If rsWH.Fields("COUNTWarehouseID").Value > 1 Then
							MsgBox("This report cannot work with multiple Warehouses.")
							Exit Sub
						End If
					End If
				End If
				
				frmStockSales.reportType = 0
				frmStockSales.Text = "Stock Item Sales Listing Order"
				frmStockSales.ShowDialog()
			Case "report_stocksalescompare"
				frmStockSales.reportType = 1
				frmStockSales.Text = "Stock Item Sales Comparision Listing Order"
				frmStockSales.ShowDialog()
			Case "frmbasketvalue"
				report_BasketValue()
			Case "report_grvdetails"
				report_GRVDetails()
			Case "report_profitbydayend"
				report_ProfitByDayEnd()
			Case "report_stocktakenote"
				report_StockTakeNotes()
			Case "frmstockvalrepdb"
				report_StockValuebyGX_RepDB("")
			Case "report_stockmovementbyday"
				report_StockMovementByDay()
			Case "report_stockquantity"
				'report_StockQuantity
				frmStockList2.editItem(2)
				frmStockList2.ShowDialog()
			Case "report_stockquantityall" ' bongie made report
				frmStock.ShowDialog()
			Case "report_stockcostvariance"
				report_StockCostVariance(0)
			Case "report_stockcostvarianceactual"
				report_StockCostVariance(1)
			Case "frmgroupsales"
				frmGroupSales.ShowDialog()
			Case "doreportmode"
				'            doReportMode
			Case "frmbuildwizard"
				frmBuildWizard.show(1)
			Case "frmpostransactionlist"
				frmPOSreport.ShowDialog()
			Case "frmrevoketransactionlist"
				report_RevokeTransactionlist()
			Case "frmproductperformanceemployee"
				report_ProductPerformanceEmployee()
			Case "frmproductperformancecustomer"
				report_ProductPerformanceCustomerByGroup()
			Case "frmdealcomparison"
				report_ProductPerformanceGRVDeals()
			Case "frmwaitrontotals"
				report_WaitronTotals()
			Case "report_suppliertransactions"
				report_SupplierTransactions()
			Case "frmtopselect"
				frmTopSelect.ShowDialog()
				'frmTopSelectCustomer.show 1
			Case "frmtopselectnon"
				frmTopSelectNon.ShowDialog()
			Case "frmtopselectgrv"
				frmTopSelectGRV.ShowDialog()
			Case "frmitemitem"
				frmItemItem.ShowDialog()
			Case "frmitem"
				frmItem.ShowDialog()
			Case "report_stockbreaktransaction"
				report_StockBreakTransaction()
			Case "report_salescube"
				report_SalesCube()
			Case "report_banking"
				report_Banking()
			Case "report_shrinkage"
				report_Shrinkage()
			Case "report_payout"
				report_Payout()
			Case "report_payoutreason"
				report_PayoutReason()
			Case "report_outage"
				report_Outage()
			Case "report_discount"
				report_Discount()
				'report_Gratuity
			Case "report_gratuity"
				report_Gratuity()
			Case "report_deposit"
				report_Deposit()
			Case "report_customermovement"
				report_CustomerMovement()
			Case "report_customermovementcd"
				report_CustomerMovementCD()
			Case "frmitemgroup"
				frmItemGroup.ShowDialog()
			Case "report_customerbalance"
				report_CustomerBalance()
			Case "report_supplierbalance"
				report_SupplierBalance()
			Case "report_pos1"
				report_POS(1)
			Case "report_pos2"
				report_POS(2)
			Case "report_pos3"
				report_POS(3)
			Case "report_pos4"
				report_POS(4)
			Case "report_pos5"
				report_POS(5)
			Case "report_pos6"
				report_POS(6)
			Case "report_pos7"
				report_POS(7)
			Case "report_pos8"
				report_POS(8)
			Case "report_pos9"
				report_POS(9)
			Case "report_pos10"
				report_POS(10)
			Case "report_pos11"
				report_POS(11)
			Case "report_pos12"
				report_POS(12)
			Case "buildscalefile"
				buildScaleFile()
				
		End Select
		
	End Sub
	
	
	Private Sub buildScaleFile()
		Dim rsScale As ADODB.Recordset
		Dim rsData As ADODB.Recordset
		Dim lString As String
		Dim lFormat As String
		Dim HeadingString1, HeadingString2 As String
		Dim lWeighted As String
		Dim fso As New Scripting.FileSystemObject
		Dim lTextstream As Scripting.TextStream
		On Error Resume Next
		rsScale = getRS("SELECT Scale.* FROM Scale;")
		Do Until rsScale.EOF
			rsData = getRS("SELECT Right('0000'+[Catalogue_Barcode],4) AS code, Format([CatalogueChannelLnk_Price],'Fixed') AS price, StockItem.StockItem_Name, StockGroup.StockGroup_Name, StockItem.StockItem_NonWeighted FROM (StockItem INNER JOIN (CatalogueChannelLnk INNER JOIN Catalogue ON (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = Catalogue.Catalogue_Quantity) AND (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = Catalogue.Catalogue_StockItemID)) ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((Catalogue.Catalogue_Quantity)=1) AND ((StockItem.StockItem_Disabled)=False) AND ((StockItem.StockItem_VariablePrice)=True));")
			Select Case rsScale.Fields("Scale_format").Value
				Case 0
					rsData.MoveFirst()
					Do Until rsData.EOF
						
						HeadingString1 = Left(rsData.Fields("Stockitem_Name").Value, 16)
						HeadingString2 = ""
						If Len(rsData.Fields("Stockitem_Name").Value) > 16 Then
							Do Until Right(HeadingString1, 1) = " "
								HeadingString1 = Left(HeadingString1, Len(HeadingString1) - 1)
							Loop 
							HeadingString2 = Mid(rsData.Fields("Stockitem_Name").Value, Len(HeadingString1) + 1)
						End If
						HeadingString1 = Left(HeadingString1 & New String(" ", 16), 16)
						HeadingString2 = Left(HeadingString2 & New String(" ", 16), 16)
						If rsData.Fields("StockItem_NonWeighted").Value Then lWeighted = "01" Else lWeighted = "00"
						lString = lString & vbCrLf & "#" & rsData.Fields("code").Value & "$" & rsData.Fields("price").Value & "%#000%$" & lWeighted & "%(A" & HeadingString1 & "%)A" & HeadingString2 & "%[" & Left(rsData.Fields("StockGroup_Name").Value & New String(" ", 15), 15)
						rsData.moveNext()
					Loop 
				Case 1
					rsData.MoveFirst()
					Do Until rsData.EOF
						
						HeadingString1 = Left(rsData.Fields("Stockitem_Name").Value, 22)
						HeadingString2 = ""
						If Len(rsData.Fields("Stockitem_Name").Value) > 22 Then
							Do Until Right(HeadingString1, 1) = " " Or HeadingString1 = ""
								HeadingString1 = Left(HeadingString1, Len(HeadingString1) - 1)
							Loop 
							HeadingString2 = Mid(rsData.Fields("Stockitem_Name").Value, Len(HeadingString1) + 1)
						End If
						HeadingString1 = Left(HeadingString1 & New String(" ", 22), 22)
						HeadingString2 = Left(HeadingString2 & New String(" ", 21), 21)
						If rsData.Fields("StockItem_NonWeighted").Value Then lWeighted = "01" Else lWeighted = "00"
						lString = lString & vbCrLf & " %*0 #" & rsData.Fields("code").Value & " $" & Right("00000" & Replace(rsData.Fields("price").Value, ".", ""), 5) & " %#000 %$" & lWeighted & "%&" & rsScale.Fields("ScaleID").Value & rsData.Fields("code").Value & " %(A" & HeadingString1 & " %)A" & HeadingString2 & " %[" & Left(rsData.Fields("StockGroup_Name").Value & New String(" ", 15), 15) & " %]" & New String(" ", 15) & " %~"
						rsData.moveNext()
					Loop 
			End Select
			If fso.FileExists(rsScale.Fields("Scale_Path").Value) Then fso.DeleteFile(rsScale.Fields("Scale_Path").Value)
			If Len(lString) Then
				lTextstream = fso.CreateTextFile(rsScale.Fields("Scale_Path").Value, True)
				lTextstream.Write(Mid(lString, 3))
				lTextstream.Close()
			End If
			rsScale.moveNext()
		Loop 
	End Sub
	
	Public Sub loadDayEndReportPrev(ByRef id As Integer, ByRef monthId As Integer)
        Dim lTotal As Integer
		Dim rs As ADODB.Recordset
		Dim rsBanking As ADODB.Recordset
		Dim rsPayout As ADODB.Recordset
		Dim rsSupplier As ADODB.Recordset
		Dim rsShrink As ADODB.Recordset
		Dim rsCustomer As ADODB.Recordset
		Dim rsQuote As ADODB.Recordset
		Dim rsConsignment As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryDayEndForm
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryDayEndForm.rpt")
		Dim gParameters As Integer
		Const gParChannel As Short = 1
		Const gParStock As Short = 2
		Const gParShrink As Short = 4
		Const gParSupplier As Short = 8
		Const gParCustomer As Short = 16
		Const gParQuote As Short = 32
		Const gParConsignment As Short = 64
		Const gParPastelReport As Short = 128 'Pastel Variable
		
		Dim cn As ADODB.Connection
		Dim x As Short
		Dim databaseName As String
		
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        gParameters = CInt(0 & rs.Fields("Company_DayEndBit").Value)
        rs.Close()

        rs = getRS("SELECT * FROM DayEnd WHERE DayEndID = " & id)
        'ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If
        Report.Database.Tables(1).SetDataSource(rs)
        databaseName = "month" & monthId & ".mdb"
        cn = openConnectionInstance(CStr(databaseName))
        If cn Is Nothing Then
            Exit Sub
        End If

        If frmMenu.gSuper = True Then
            sql = "SELECT POS.POSID, POS.POS_Name, Sum(Declaration.Declaration_Cash) AS SumOfDeclaration_Cash, Sum(Declaration.Declaration_CashServer) AS SumOfDeclaration_CashServer, Sum(Declaration.Declaration_CashCount) AS SumOfDeclaration_CashCount, Sum(Declaration.Declaration_Cheque) AS SumOfDeclaration_Cheque, Sum(Declaration.Declaration_ChequeServer) AS SumOfDeclaration_ChequeServer, Sum(Declaration.Declaration_ChequeCount) AS SumOfDeclaration_ChequeCount, Sum(Declaration.Declaration_Card) AS SumOfDeclaration_Card, Sum(Declaration.Declaration_CardServer) AS SumOfDeclaration_CardServer, Sum(Declaration.Declaration_CardCount) AS SumOfDeclaration_CardCount, Sum(Declaration.Declaration_Payout) AS SumOfDeclaration_Payout, Sum(Declaration.Declaration_PayoutServer) AS SumOfDeclaration_PayoutServer, Sum(Declaration.Declaration_PayoutCount) AS SumOfDeclaration_PayoutCount FROM Declaration INNER JOIN POS ON Declaration.Declaration_POSID = POS.POSID Where (((Declaration.Declaration_DayEndID) = " & id & ")) "
            sql = sql & "GROUP BY POS.POSID, POS.POS_Name;"
        Else
            sql = "SELECT POS.POSID, POS.POS_Name, Sum(IIf(IIf(IsNull(Declaration.Declaration_CashDrop),0,Declaration.Declaration_CashDrop)=0,Declaration.Declaration_Cash,Declaration.Declaration_CashDrop)) AS SumOfDeclaration_Cash, Sum(IIf(IIf(IsNull(Declaration.Declaration_CashServerDrop),0,Declaration.Declaration_CashServerDrop)=0,Declaration.Declaration_CashServer,Declaration.Declaration_CashServerDrop)) AS SumOfDeclaration_CashServer, Sum(IIf(IIf(IsNull(Declaration.Declaration_CashCountDrop),0,Declaration.Declaration_CashCountDrop)=0,Declaration.Declaration_CashCount,Declaration.Declaration_CashCountDrop)) AS SumOfDeclaration_CashCount, "
            sql = sql & "Sum(Declaration.Declaration_Cheque) AS SumOfDeclaration_Cheque, Sum(Declaration.Declaration_ChequeServer) AS SumOfDeclaration_ChequeServer, Sum(Declaration.Declaration_ChequeCount) AS SumOfDeclaration_ChequeCount, Sum(Declaration.Declaration_Card) AS SumOfDeclaration_Card, Sum(Declaration.Declaration_CardServer) AS SumOfDeclaration_CardServer, Sum(Declaration.Declaration_CardCount) AS SumOfDeclaration_CardCount, Sum(Declaration.Declaration_Payout) AS SumOfDeclaration_Payout, Sum(Declaration.Declaration_PayoutServer) AS SumOfDeclaration_PayoutServer, Sum(Declaration.Declaration_PayoutCount) AS SumOfDeclaration_PayoutCount FROM Declaration INNER JOIN POS ON Declaration.Declaration_POSID = POS.POSID Where (((Declaration.Declaration_DayEndID) = " & id & ")) "
            sql = sql & "GROUP BY POS.POSID, POS.POS_Name;"
        End If
        Debug.Print(sql)
        'Set rsBanking = getRS(sql)
        rsBanking = New ADODB.Recordset
        rsBanking.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)

        'Set rsPayout = getRS("select * from Payout WHERE Payout_DayEndID = " & id)
        rsPayout = New ADODB.Recordset
        sql = "select * from M_Payout WHERE Payout_DayEndID = " & id
        rsPayout.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)

        If rsBanking.RecordCount = 0 Then
            Report.ReportDefinition.Sections("Section2").SectionFormat.EnableSuppress = True
            Report.ReportDefinition.Sections("Section3").SectionFormat.EnableSuppress = True
        Else
            Report.ReportDefinition.Sections("Section2").SectionFormat.EnableSuppress = False
            Report.ReportDefinition.Sections("Section3").SectionFormat.EnableSuppress = False
            Report.OpenSubreport("Subreport1").Database.Tables(1).SetDataSource(rsBanking)
            Report.OpenSubreport("Subreport2").Database.Tables(1).SetDataSource(rsBanking)
        End If
        If rsPayout.RecordCount = 0 Then
            Report.ReportDefinition.Sections("Section4").SectionFormat.EnableSuppress = True
        Else
            Report.ReportDefinition.Sections("Section4").SectionFormat.EnableSuppress = False
            Report.OpenSubreport("Subreport4").Database.Tables(1).SetDataSource(rsPayout)
        End If

        '************************************
        '*** Sales Channels
        '************************************
        If gParameters And gParChannel Then

            rs = getRS("SELECT * FROM Channel")

            Do Until rs.EOF
                Select Case rs.Fields("ChannelID").Value
                    Case 1
                        Report.SetParameterValue("txtSC1", rs.Fields("Channel_Code"))
                    Case 2
                        Report.SetParameterValue("txtSC2", rs.Fields("Channel_Code"))
                    Case 3
                        Report.SetParameterValue("txtSC3", rs.Fields("Channel_Code"))
                    Case 4
                        Report.SetParameterValue("txtSC4", rs.Fields("Channel_Code"))
                    Case 5
                        Report.SetParameterValue("txtSC5", rs.Fields("Channel_Code"))
                    Case 6
                        Report.SetParameterValue("txtSC6", rs.Fields("Channel_Code"))
                    Case 7
                        Report.SetParameterValue("txtSC7", rs.Fields("Channel_Code"))
                    Case 8
                        Report.SetParameterValue("txtSC8", rs.Fields("Channel_Code"))
                    Case 9
                        Report.SetParameterValue("txtSC9", rs.Fields("Channel_Code"))
                End Select
                rs.moveNext()
            Loop
            rs.Close()

            'Set rs = getRS("SELECT Sum(Sale.Sale_Discount) AS amount FROM Consignment RIGHT JOIN (Consignment AS Consignment_1 RIGHT JOIN Sale ON Consignment_1.Consignment_SaleID = Sale.SaleID) ON Consignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((Consignment.ConsignmentID) Is Null) AND ((Consignment_1.ConsignmentID) Is Null) AND ((Sale.Sale_PaymentType)<>5));")
            'Set rs = New Recordset
            If rs.State Then rs.Close()
            sql = "SELECT Sum(Sale.Sale_Discount) AS amount FROM Consignment RIGHT JOIN (Consignment AS Consignment_1 RIGHT JOIN Sale ON Consignment_1.Consignment_SaleID = Sale.SaleID) ON Consignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((Consignment.ConsignmentID) Is Null) AND ((Consignment_1.ConsignmentID) Is Null) AND ((Sale.Sale_PaymentType)<>5));"
            rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
            If IsDBNull(rs.Fields("amount").Value) Then
                Report.SetParameterValue("txtSCmDiscount", "0.00")
            Else
                If rs.RecordCount Then
                    Report.SetParameterValue("txtSCmDiscount", FormatNumber(0 - rs.Fields("amount").Value, 2))
                Else
                    Report.SetParameterValue("txtSCmDiscount", "0.00")
                End If
            End If
            rs.Close()

            'Set rs = getRS("SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS SCTotal, Sale.Sale_ChannelID FROM Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = False) And ((Consignment.ConsignmentID) Is Null) And ((Consignment_1.ConsignmentID) Is Null) And ((Sale.Sale_DayEndID) = " & id & ")) GROUP BY Sale.Sale_ChannelID;")
            'Set rs = New Recordset
            If rs.State Then rs.Close()
            sql = "SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS SCTotal, Sale.Sale_ChannelID FROM Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = False) And ((Consignment.ConsignmentID) Is Null) And ((Consignment_1.ConsignmentID) Is Null) And ((Sale.Sale_DayEndID) = " & id & ")) GROUP BY Sale.Sale_ChannelID;"
            rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
            lTotal = CDec(Report.ParameterFields("txtSCmDiscount").ToString)
            Do Until rs.EOF
                Select Case rs.Fields("Sale_ChannelID").Value
                    Case 1
                        Report.SetParameterValue("txtSCm1", FormatNumber(rs.Fields("SCTotal").Value, 2))
                    Case 2
                        Report.SetParameterValue("txtSCm2", FormatNumber(rs.Fields("SCTotal").Value, 2))
                    Case 3
                        Report.SetParameterValue("txtSCm3", FormatNumber(rs.Fields("SCTotal").Value, 2))
                    Case 4
                        Report.SetParameterValue("txtSCm4", FormatNumber(rs.Fields("SCTotal").Value, 2))
                    Case 5
                        Report.SetParameterValue("txtSCm5", FormatNumber(rs.Fields("SCTotal").Value, 2))
                    Case 6
                        Report.SetParameterValue("txtSCm6", FormatNumber(rs.Fields("SCTotal").Value, 2))
                    Case 7
                        Report.SetParameterValue("txtSCm7", FormatNumber(rs.Fields("SCTotal").Value, 2))
                    Case 8
                        Report.SetParameterValue("txtSCm8", FormatNumber(rs.Fields("SCTotal").Value, 2))
                    Case 9
                        Report.SetParameterValue("txtSCm9", FormatNumber(rs.Fields("SCTotal").Value, 2))
                End Select
                lTotal = lTotal + rs.Fields("SCTotal").Value
                rs.moveNext()
            Loop
            Report.SetParameterValue("txtSCmTotal", FormatNumber(lTotal, 2))
        Else
            Report.ReportDefinition.Sections("Section5").SectionFormat.EnableSuppress = True
        End If

        If gParameters And gParStock Then
            '*******************************************
            '***Stock Movement
            '*******************************************
            'Set rs = getRS("SELECT Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost]) AS listSales, Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ActualCost]) AS actualSales, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS listShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actualShrink, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost]) AS listGRV, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ActualCost]) AS actualGRV From DayEndStockItemLnk WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)=" & id & "));")
            If rs.State Then rs.Close()
            sql = "SELECT Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost]) AS listSales, Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ActualCost]) AS actualSales, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS listShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actualShrink, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost]) AS listGRV, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ActualCost]) AS actualGRV From DayEndStockItemLnk WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)=" & id & "));"
            rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
            If rs.RecordCount Then
                Report.SetParameterValue("txtSHRL", FormatNumber(rs.Fields("listShrink").Value, 2))
                Report.SetParameterValue("txtSHRA", FormatNumber(rs.Fields("actualShrink").Value, 2))
                Report.SetParameterValue("txtGRVL", FormatNumber(rs.Fields("listGRV").Value, 2))

                Report.SetParameterValue("txtGRVA", FormatNumber(rs.Fields("actualGRV").Value, 2))
                Report.SetParameterValue("txtSaleL", FormatNumber(rs.Fields("listSales").Value, 2))
                Report.SetParameterValue("txtSaleA", FormatNumber(rs.Fields("actualSales").Value, 2))
            End If

            'Set rs = getRS("SELECT Sum(([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ListCost]) AS list, Sum(([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_actualCost]) AS actual From DayEndStockItemLnk WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)=" & id & "));")
            If rs.State Then rs.Close()
            sql = "SELECT Sum(([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ListCost]) AS list, Sum(([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_actualCost]) AS actual From DayEndStockItemLnk WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)=" & id & "));"
            rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)

            If rs.RecordCount Then
                Report.SetParameterValue("txtSHLclose", FormatNumber(rs.Fields("list").Value, 2))
                Report.SetParameterValue("txtSHAclose", FormatNumber(rs.Fields("actual").Value, 2))
            End If

            rs = getRSwaitron("SELECT Sum([DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk_ListCost]) AS list, Sum([DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk_actualCost]) AS actual From DayEndStockItemLnk WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)=" & id & "));", cn)
            If rs.RecordCount Then
                Report.SetParameterValue("txtSHLopen", FormatNumber(rs.Fields("list").Value, 2))
                Report.SetParameterValue("txtSHAopen", FormatNumber(rs.Fields("actual").Value, 2))
            Else
                Report.SetParameterValue("txtSHLopen", FormatNumber(0, 2))
                Report.SetParameterValue("txtSHAopen", FormatNumber(0, 2))
            End If

            rs = getRSwaitron("SELECT Sum(([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ListCost]) AS list, Sum(([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_actualCost]) AS actual From DayEndStockItemLnk WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)=" & id - 1 & "));", cn)
            If rs.RecordCount Then
                Report.SetParameterValue("txtSHLPrevclose", FormatNumber(rs.Fields("list").Value, 2))
                Report.SetParameterValue("txtSHAPrevclose", FormatNumber(rs.Fields("actual").Value, 2))
            Else
                Report.SetParameterValue("txtSHLPrevclose", FormatNumber(0, 2))
                Report.SetParameterValue("txtSHAPrevclose", FormatNumber(0, 2))
            End If
            If Report.ParameterFields("txtSHLPrevclose").ToString = "" Then Report.SetParameterValue("txtSHLPrevclose", Report.ParameterFields("txtSHLopen").ToString)
            If Report.ParameterFields("txtSHAPrevclose").ToString = "" Then Report.SetParameterValue("txtSHAPrevclose", Report.ParameterFields("txtSHAopen").ToString)
            If Report.ParameterFields("txtSHLopen").ToString = "" Then
                If Report.ParameterFields("txtSHLPrevclose").ToString = "" Then
                    Report.SetParameterValue("txtSVarianceL", FormatNumber(0, 2))
                Else
                    Report.SetParameterValue("txtSVarianceL", FormatNumber(0 - CDec(Report.ParameterFields("txtSHLPrevclose").ToString), 2))
                End If
            Else
                If Report.ParameterFields("txtSHLPrevclose").ToString = "" Then
                    Report.SetParameterValue("txtSVarianceL", FormatNumber(CDec(Report.ParameterFields("txtSHLopen").ToString), 2))
                Else
                    Report.SetParameterValue("txtSVarianceL", FormatNumber(CDec(Report.ParameterFields("txtSHLopen").ToString) - CDec(Report.ParameterFields("txtSHLPrevclose").ToString), 2))
                End If
            End If

            If Report.ParameterFields("txtSHAopen").ToString = "" Then
                If Report.ParameterFields("txtSHAPrevclose").ToString = "" Then
                    Report.SetParameterValue("txtSVarianceL", FormatNumber(0, 2))
                Else
                    Report.SetParameterValue("txtSVarianceL", FormatNumber(0 - CDec(Report.ParameterFields("txtSHAPrevclose").ToString), 2))
                End If
            Else
                If Report.ParameterFields("txtSHAPrevclose").ToString = "" Then
                    Report.SetParameterValue("txtSVarianceL", FormatNumber(CDec(Report.ParameterFields("txtSHAopen").ToString), 2))
                Else
                    Report.SetParameterValue("txtSVarianceL", FormatNumber(CDec(Report.ParameterFields("txtSHAopen").ToString) - CDec(Report.ParameterFields("txtSHAPrevclose").ToString), 2))
                End If
            End If

        Else
            Report.ReportDefinition.Sections("Section6").SectionFormat.EnableSuppress = True
        End If

        If gParameters And gParShrink Then
            rsShrink = getRSwaitron("SELECT StockItem.StockItem_Name, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS list, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actual FROM DayEndStockItemLnk INNER JOIN StockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = StockItem.StockItemID Where (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0) And ((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) = " & id & ")) GROUP BY StockItem.StockItem_Name ORDER BY StockItem.StockItem_Name;", cn)

            If rsShrink.RecordCount = 0 Then
                Report.ReportDefinition.Sections("Section7").SectionFormat.EnableSuppress = True
            Else
                Report.ReportDefinition.Sections("Section7").SectionFormat.EnableSuppress = False
                Report.OpenSubreport("Subreport4").Database.Tables(1).SetDataSource(rsShrink)
            End If
        Else
            Report.ReportDefinition.Sections("Section7").SectionFormat.EnableSuppress = True
        End If

        If gParameters And gParSupplier Then
            rsSupplier = getRSwaitron("SELECT Supplier.Supplier_Name, SupplierTransaction.* FROM SupplierTransaction INNER JOIN Supplier ON SupplierTransaction.SupplierTransaction_SupplierID = Supplier.SupplierID Where (((SupplierTransaction.SupplierTransaction_DayEndID) = " & id & ") And ((SupplierTransaction.SupplierTransaction_TransactionTypeID) = 2 Or (SupplierTransaction.SupplierTransaction_TransactionTypeID) = 3)) ORDER BY SupplierTransaction.SupplierTransaction_DayEndID, SupplierTransaction.SupplierTransactionID;", cn)
            If rsSupplier.RecordCount = 0 Then
                Report.ReportDefinition.Sections("Section8").SectionFormat.EnableSuppress = True
            Else
                Report.ReportDefinition.Sections("Section8").SectionFormat.EnableSuppress = False
                Report.OpenSubreport("Subreport5").Database.Tables(1).SetDataSource(rsSupplier)
            End If
        Else
            Report.ReportDefinition.Sections("Section8").SectionFormat.EnableSuppress = True
        End If

        If gParameters And gParCustomer Then
            rsCustomer = getRSwaitron("SELECT Customer.Customer_InvoiceName, TransactionType.TransactionType_Name, CustomerTransaction.CustomerTransaction_Reference, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_Description, TransactionType.TransactionTypeID FROM (CustomerTransaction INNER JOIN Customer ON CustomerTransaction.CustomerTransaction_CustomerID = Customer.CustomerID) INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID Where (((CustomerTransaction.CustomerTransaction_DayEndID) = " & id & ")) ORDER BY Customer.Customer_InvoiceName, CustomerTransaction.CustomerTransaction_Date;", cn)
            If rsCustomer.RecordCount = 0 Then
                Report.ReportDefinition.Sections("Section9").SectionFormat.EnableSuppress = True
            Else
                Report.ReportDefinition.Sections("Section9").SectionFormat.EnableSuppress = False
                Report.OpenSubreport("Subreport6").Database.Tables(1).SetDataSource(rsCustomer)
            End If
        Else
            Report.ReportDefinition.Sections("Section9").SectionFormat.EnableSuppress = True
        End If

        '    If gParameters And gParQuote Then
        '        Set rsQuote = getRS("SELECT Quote.* From Quote Where (((Quote.Quote_DayEndID) = " & id & ")) ORDER BY Quote.Quote_Name;")
        '        If rsQuote.RecordCount = 0 Then
        '            Report.Section10.Suppress = True
        '        Else
        '            Report.Section10.Suppress = False
        '            Report.Subreport7.OpenSubreport.Database.Tables(1).SetDataSource rsQuote, 3
        '        End If
        '    Else
        'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section10. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Report.ReportDefinition.Sections("Section10").SectionFormat.EnableSuppress = True
        '    End If

        If gParameters And gParQuote Then
            rsConsignment = getRSwaitron("SELECT Consignment.*, Sale.Sale_Total AS saleAmount,0 as completeAmount,0 as returnAmount FROM Consignment INNER JOIN Sale ON Consignment.Consignment_SaleID = Sale.SaleID Where (((Consignment.Consignment_DayEndID) = " & id & ")) Union SELECT Consignment.*, 0 AS saleAmount, [saleComplete]![Sale_Total] AS completeAmount, [SaleReturned]![Sale_Total]+[saleComplete]![Sale_Total] AS returnAmount FROM (Consignment INNER JOIN Sale AS SaleReturned ON Consignment.Consignment_ReversalSaleID = SaleReturned.SaleID) INNER JOIN Sale AS saleComplete ON Consignment.Consignment_CompleteSaleID = saleComplete.SaleID WHERE (((Consignment.Consignment_DayEndID)=" & id & "));", cn)
            If rsConsignment.RecordCount = 0 Then
                Report.ReportDefinition.Sections("Section11").SectionFormat.EnableSuppress = True
            Else
                Report.ReportDefinition.Sections("Section11").SectionFormat.EnableSuppress = False
                Report.OpenSubreport("Subreport8").Database.Tables(1).SetDataSource(rsConsignment)
            End If
        Else
            Report.ReportDefinition.Sections("Section11").SectionFormat.EnableSuppress = True
        End If

        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
       System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()

    End Sub

    Public Sub loadDayEndReport(ByRef id As Integer, Optional ByRef sPath As String = "", Optional ByRef bFAIL As Boolean = False)
        Dim lTotal As Integer
        Dim rs As ADODB.Recordset
        Dim rsBanking As ADODB.Recordset
        Dim rsPayout As ADODB.Recordset
        Dim rsSupplier As ADODB.Recordset
        Dim rsShrink As ADODB.Recordset
        Dim rsCustomer As ADODB.Recordset
        Dim rsQuote As ADODB.Recordset
        Dim rsConsignment As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryDayEnd
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim gParameters As Integer
        Const gParChannel As Short = 1
        Const gParStock As Short = 2
        Const gParShrink As Short = 4
        Const gParSupplier As Short = 8
        Const gParCustomer As Short = 16
        Const gParQuote As Short = 32
        Const gParConsignment As Short = 64
        Const gParPastelReport As Short = 128 'Pastel Variable

        Report.Load("cryDatEnd")
        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtCompanyName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        gParameters = CInt(0 & rs.Fields("Company_DayEndBit").Value)
        rs.Close()

        'change translation for report
        '
        rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1974
        'UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport1_Text9. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If rsLang.RecordCount Then Report.SetParameterValue("Subreport1_Text9", Replace(rsLang.Fields("LanguageLayoutLnk_Description").Value, vbCrLf, " "))
        '
        rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1975
        'UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport1_Text8. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If rsLang.RecordCount Then Report.SetParameterValue("Subreport1_Text8", Replace(rsLang.Fields("LanguageLayoutLnk_Description").Value, vbCrLf, " "))
        '
        rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1974
        'UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport2_Text4. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If rsLang.RecordCount Then Report.SetParameterValue("Subreport2_Text4", Replace(rsLang.Fields("LanguageLayoutLnk_Description").Value, vbCrLf, " "))
        '
        rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1975
        'UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport2_Text3. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If rsLang.RecordCount Then Report.SetParameterValue("Subreport2_Text3", Replace(rsLang.Fields("LanguageLayoutLnk_Description").Value, vbCrLf, " "))
        '
        'change translation for report

        rs = getRS("SELECT * FROM DayEnd WHERE DayEndID = " & id)
        'UPGRADE_ISSUE: cryNoRecords object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords")
        ''ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            If bUploadReport = True Then
                bFAIL = True
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtCompanyName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object ReportNone.txtCompanyName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName"))
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object ReportNone.txtTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle"))
                'UPGRADE_WARNING: Couldn't resolve default property of object ReportNone.txtTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
                'UPGRADE_WARNING: Couldn't resolve default property of object frmReportShow.CRViewer1.ReportSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object ReportNone. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                frmReportShow.CRViewer1.ReportSource = ReportNone
                frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
                frmReportShow.CRViewer1.Refresh()
                'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                frmReportShow.ShowDialog()
            End If
            Exit Sub
        End If
        'UPGRADE_WARNING: Couldn't resolve default property of object Report.Database. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'

        Report.Database.Tables(1).SetDataSource(rs)
        If frmMenu.gSuper = True Then
            sql = "SELECT POS.POSID, POS.POS_Name, Sum(Declaration.Declaration_Cash) AS SumOfDeclaration_Cash, Sum(Declaration.Declaration_CashServer) AS SumOfDeclaration_CashServer, Sum(Declaration.Declaration_CashCount) AS SumOfDeclaration_CashCount, Sum(Declaration.Declaration_Cheque) AS SumOfDeclaration_Cheque, Sum(Declaration.Declaration_ChequeServer) AS SumOfDeclaration_ChequeServer, Sum(Declaration.Declaration_ChequeCount) AS SumOfDeclaration_ChequeCount, Sum(Declaration.Declaration_Card) AS SumOfDeclaration_Card, Sum(Declaration.Declaration_CardServer) AS SumOfDeclaration_CardServer, Sum(Declaration.Declaration_CardCount) AS SumOfDeclaration_CardCount, Sum(Declaration.Declaration_Payout) AS SumOfDeclaration_Payout, Sum(Declaration.Declaration_PayoutServer) AS SumOfDeclaration_PayoutServer, Sum(Declaration.Declaration_PayoutCount) AS SumOfDeclaration_PayoutCount FROM Declaration INNER JOIN POS ON Declaration.Declaration_POSID = POS.POSID Where (((Declaration.Declaration_DayEndID) = " & id & ")) "
            sql = sql & "GROUP BY POS.POSID, POS.POS_Name;"
        Else
            sql = "SELECT POS.POSID, POS.POS_Name, Sum(IIf(IIf(IsNull(Declaration.Declaration_CashDrop),0,Declaration.Declaration_CashDrop)=0,Declaration.Declaration_Cash,Declaration.Declaration_CashDrop)) AS SumOfDeclaration_Cash, Sum(IIf(IIf(IsNull(Declaration.Declaration_CashServerDrop),0,Declaration.Declaration_CashServerDrop)=0,Declaration.Declaration_CashServer,Declaration.Declaration_CashServerDrop)) AS SumOfDeclaration_CashServer, Sum(IIf(IIf(IsNull(Declaration.Declaration_CashCountDrop),0,Declaration.Declaration_CashCountDrop)=0,Declaration.Declaration_CashCount,Declaration.Declaration_CashCountDrop)) AS SumOfDeclaration_CashCount, "
            sql = sql & "Sum(Declaration.Declaration_Cheque) AS SumOfDeclaration_Cheque, Sum(Declaration.Declaration_ChequeServer) AS SumOfDeclaration_ChequeServer, Sum(Declaration.Declaration_ChequeCount) AS SumOfDeclaration_ChequeCount, Sum(Declaration.Declaration_Card) AS SumOfDeclaration_Card, Sum(Declaration.Declaration_CardServer) AS SumOfDeclaration_CardServer, Sum(Declaration.Declaration_CardCount) AS SumOfDeclaration_CardCount, Sum(Declaration.Declaration_Payout) AS SumOfDeclaration_Payout, Sum(Declaration.Declaration_PayoutServer) AS SumOfDeclaration_PayoutServer, Sum(Declaration.Declaration_PayoutCount) AS SumOfDeclaration_PayoutCount FROM Declaration INNER JOIN POS ON Declaration.Declaration_POSID = POS.POSID Where (((Declaration.Declaration_DayEndID) = " & id & ")) "
            sql = sql & "GROUP BY POS.POSID, POS.POS_Name;"
        End If
        Debug.Print(sql)
        rsBanking = getRS(sql)

        rsPayout = getRS("select * from Payout WHERE Payout_DayEndID = " & id)

        If rsBanking.RecordCount = 0 Then
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.ReportDefinition.Sections("Section2").SectionFormat.EnableSuppress = True
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section3. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.ReportDefinition.Sections("Section3").SectionFormat.EnableSuppress = True
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.ReportDefinition.Sections("Section2").SectionFormat.EnableSuppress = False
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section3. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.ReportDefinition.Sections("Section3").SectionFormat.EnableSuppress = False
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.OpenSubreport("Subreport1").Database.Tables(1).SetDataSource(rsBanking)
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.OpenSubreport("Subreport2").Database.Tables(1).SetDataSource(rsBanking)
        End If
        If rsPayout.RecordCount = 0 Then
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section4. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.ReportDefinition.Sections("Section4").SectionFormat.EnableSuppress = True
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section4. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.ReportDefinition.Sections("Section4").SectionFormat.EnableSuppress = False
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport3. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.OpenSubreport("Subreport3").Database.Tables(1).SetDataSource(rsPayout)
        End If

        '************************************
        '*** Sales Channels
        '************************************
        If gParameters And gParChannel Then

            rs = getRS("SELECT * FROM Channel")
            Do Until rs.EOF

                Select Case rs.Fields("ChannelID").Value
                    Case 1
                        'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSC1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Report.SetParameterValue("txtSC1", rs.Fields("Channel_Code"))
                    Case 2
                        'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSC2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Report.SetParameterValue("txtSC2", rs.Fields("Channel_Code"))
                    Case 3
                        'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSC3. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Report.SetParameterValue("txtSC3", rs.Fields("Channel_Code"))
                    Case 4
                        'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSC4. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Report.SetParameterValue("txtSC4", rs.Fields("Channel_Code"))
                    Case 5
                        'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSC5. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Report.SetParameterValue("txtSC5", rs.Fields("Channel_Code"))
                    Case 6
                        'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSC6. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Report.SetParameterValue("txtSC6", rs.Fields("Channel_Code"))
                    Case 7
                        'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSC7. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Report.SetParameterValue("txtSC7", rs.Fields("Channel_Code"))
                    Case 8
                        'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSC8. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Report.SetParameterValue("txtSC8", rs.Fields("Channel_Code"))
                    Case 9
                        'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSC9. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Report.SetParameterValue("txtSC9", rs.Fields("Channel_Code"))
                End Select
                rs.moveNext()
            Loop
            rs.Close()

            rs = getRS("SELECT Sum(Sale.Sale_Discount) AS amount FROM Consignment RIGHT JOIN (Consignment AS Consignment_1 RIGHT JOIN Sale ON Consignment_1.Consignment_SaleID = Sale.SaleID) ON Consignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((Consignment.ConsignmentID) Is Null) AND ((Consignment_1.ConsignmentID) Is Null) AND ((Sale.Sale_PaymentType)<>5));")
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDbNull(rs.Fields("amount").Value) Then
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSCmDiscount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.SetParameterValue("txtSCmDiscount", "0.00")
            Else
                If rs.RecordCount Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSCmDiscount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Report.SetParameterValue("txtSCmDiscount", FormatNumber(0 - rs.Fields("amount").Value, 2))
                Else
                    'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSCmDiscount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Report.SetParameterValue("txtSCmDiscount", "0.00")
                End If
            End If
            rs.Close()

            rs = getRS("SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS SCTotal, Sale.Sale_ChannelID FROM Consignment AS Consignment_1 RIGHT JOIN (Consignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON Consignment.Consignment_SaleID = Sale.SaleID) ON Consignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = False) And ((Consignment.ConsignmentID) Is Null) And ((Consignment_1.ConsignmentID) Is Null) And ((Sale.Sale_DayEndID) = " & id & ")) GROUP BY Sale.Sale_ChannelID;")
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSCmDiscount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object lTotal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            lTotal = CDec(Report.ParameterFields("txtSCmDiscount").ToString)
            Do Until rs.EOF
                Select Case rs.Fields("Sale_ChannelID").Value
                    Case 1
                        'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSCm1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Report.SetParameterValue("txtSCm1", FormatNumber(rs.Fields("SCTotal").Value, 2))
                    Case 2
                        'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSCm2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Report.SetParameterValue("txtSCm2", FormatNumber(rs.Fields("SCTotal").Value, 2))
                    Case 3
                        'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSCm3. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Report.SetParameterValue("txtSCm3", FormatNumber(rs.Fields("SCTotal").Value, 2))
                    Case 4
                        'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSCm4. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Report.SetParameterValue("txtSCm4", FormatNumber(rs.Fields("SCTotal").Value, 2))
                    Case 5
                        'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSCm5. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Report.SetParameterValue("txtSCm5", FormatNumber(rs.Fields("SCTotal").Value, 2))
                    Case 6
                        'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSCm6. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Report.SetParameterValue("txtSCm6", FormatNumber(rs.Fields("SCTotal").Value, 2))
                    Case 7
                        'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSCm7. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Report.SetParameterValue("txtSCm7", FormatNumber(rs.Fields("SCTotal").Value, 2))
                    Case 8
                        'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSCm8. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Report.SetParameterValue("txtSCm8", FormatNumber(rs.Fields("SCTotal").Value, 2))
                    Case 9
                        'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSCm9. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Report.SetParameterValue("txtSCm9", FormatNumber(rs.Fields("SCTotal").Value, 2))
                End Select
                'UPGRADE_WARNING: Couldn't resolve default property of object lTotal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                lTotal = lTotal + rs.Fields("SCTotal").Value
                rs.moveNext()
            Loop
            'UPGRADE_WARNING: Couldn't resolve default property of object lTotal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSCmTotal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.SetParameterValue("txtSCmTotal", FormatNumber(lTotal, 2))
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section5. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.ReportDefinition.Sections("Section5").SectionFormat.EnableSuppress = True
        End If

        If gParameters And gParStock Then
            '*******************************************
            '***Stock Movement
            '*******************************************
            rs = getRS("SELECT Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost]) AS listSales, Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ActualCost]) AS actualSales, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS listShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actualShrink, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost]) AS listGRV, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ActualCost]) AS actualGRV From DayEndStockItemLnk WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)=" & id & "));")

            'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHRL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.SetParameterValue("txtSHRL", FormatNumber(rs.Fields("listShrink").Value, 2))
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHRA. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.SetParameterValue("txtSHRA", FormatNumber(rs.Fields("actualShrink").Value, 2))
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtGRVL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.SetParameterValue("txtGRVL", FormatNumber(rs.Fields("listGRV").Value, 2))

            'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtGRVA. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.SetParameterValue("txtGRVA", FormatNumber(rs.Fields("actualGRV").Value, 2))
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSaleL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.SetParameterValue("txtSaleL", FormatNumber(rs.Fields("listSales").Value, 2))
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSaleA. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.SetParameterValue("txtSaleA", FormatNumber(rs.Fields("actualSales").Value, 2))

            rs = getRS("SELECT Sum(([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ListCost]) AS list, Sum(([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_actualCost]) AS actual From DayEndStockItemLnk WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)=" & id & "));")
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHLclose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.SetParameterValue("txtSHLclose", FormatNumber(rs.Fields("list").Value, 2))
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHAclose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.SetParameterValue("txtSHAclose", FormatNumber(rs.Fields("actual").Value, 2))

            rs = getRS("SELECT Sum([DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk_ListCost]) AS list, Sum([DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk_actualCost]) AS actual From DayEndStockItemLnk WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)=" & id & "));")
            If rs.RecordCount Then
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHLopen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.SetParameterValue("txtSHLopen", FormatNumber(rs.Fields("list").Value, 2))
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHAopen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.SetParameterValue("txtSHAopen", FormatNumber(rs.Fields("actual").Value, 2))
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHLopen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.SetParameterValue("txtSHLopen", FormatNumber(0, 2))
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHAopen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.SetParameterValue("txtSHAopen", FormatNumber(0, 2))
            End If

            rs = getRS("SELECT Sum(([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ListCost]) AS list, Sum(([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_actualCost]) AS actual From DayEndStockItemLnk WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)=" & id - 1 & "));")
            If rs.RecordCount Then
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHLPrevclose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.SetParameterValue("txtSHLPrevclose", FormatNumber(rs.Fields("list").Value, 2))
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHAPrevclose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.SetParameterValue("txtSHAPrevclose", FormatNumber(rs.Fields("actual").Value, 2))
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHLPrevclose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.SetParameterValue("txtSHLPrevclose", FormatNumber(0, 2))
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHAPrevclose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.SetParameterValue("txtSHAPrevclose", FormatNumber(0, 2))
            End If
            If Report.ParameterFields("txtSHLPrevclose").ToString = "" Then Report.SetParameterValue("txtSHLPrevclose", Report.ParameterFields("txtSHLopen").ToString)

            If Report.ParameterFields("txtSHAPrevclose").ToString = "" Then Report.SetParameterValue("txtSHAPrevclose", Report.ParameterFields("txtSHAopen").ToString)
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHLopen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If Report.ParameterFields("txtSHLopen").ToString = "" Then
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHLPrevclose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If Report.ParameterFields("txtSHLPrevclose").ToString = "" Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSVarianceL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Report.SetParameterValue("txtSVarianceL", FormatNumber(0, 2))
                Else
                    Report.SetParameterValue("txtSVarianceL", FormatNumber(0 - CDec(Report.ParameterFields("txtSHLPrevclose").ToString), 2))
                End If
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHLPrevclose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If Report.ParameterFields("txtSHLPrevclose").ToString = "" Then
                    Report.SetParameterValue("txtSVarianceL", FormatNumber(CDec(Report.ParameterFields("txtSHLopen").ToString), 2))
                Else
                    Report.SetParameterValue("txtSVarianceL", FormatNumber(CDec(Report.ParameterFields("txtSHLopen").ToString), 2 - CDec(Report.ParameterFields("txtSHLPrevclose").ToString), 2))
                End If
            End If

            'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHAopen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If Report.ParameterFields("txtSHAopen").ToString = "" Then
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHAPrevclose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If Report.ParameterFields("txtSHAPrevclose").ToString = "" Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSVarianceL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Report.SetParameterValue("txtSVarianceL", FormatNumber(0, 2))
                Else
                    Report.SetParameterValue("txtSVarianceL", FormatNumber(0 - CDec(Report.ParameterFields("txtSHAPrevclose").ToString), 2))
                End If
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtSHAPrevclose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If Report.ParameterFields("txtSHAPrevclose").ToString = "" Then
                    Report.SetParameterValue("txtSVarianceL", FormatNumber(CDec(Report.ParameterFields("txtSHAopen").ToString), 2))
                Else
                    Report.SetParameterValue("txtSVarianceL", FormatNumber(CDec(Report.ParameterFields("txtSHAopen").ToString), 2 - CDec(Report.ParameterFields("txtSHAPrevclose").ToString), 2))
                End If
            End If

        Else
            Report.ReportDefinition.Sections("Section6").SectionFormat.EnableSuppress = True
        End If

        If gParameters And gParShrink Then
            rsShrink = getRS("SELECT StockItem.StockItem_Name, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS list, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actual FROM DayEndStockItemLnk INNER JOIN StockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = StockItem.StockItemID Where (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0) And ((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) = " & id & ")) GROUP BY StockItem.StockItem_Name ORDER BY StockItem.StockItem_Name;")

            If rsShrink.RecordCount = 0 Then
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section7. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.ReportDefinition.Sections("Section7").SectionFormat.EnableSuppress = True
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section7. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.ReportDefinition.Sections("Section7").SectionFormat.EnableSuppress = False
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport4. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.OpenSubreport("Subreport4").Database.Tables(1).SetDataSource(rsShrink)
            End If
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section7. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.ReportDefinition.Sections("Section7").SectionFormat.EnableSuppress = True
        End If

        If gParameters And gParSupplier Then
            rsSupplier = getRS("SELECT Supplier.Supplier_Name, SupplierTransaction.* FROM SupplierTransaction INNER JOIN Supplier ON SupplierTransaction.SupplierTransaction_SupplierID = Supplier.SupplierID Where (((SupplierTransaction.SupplierTransaction_DayEndID) = " & id & ") And ((SupplierTransaction.SupplierTransaction_TransactionTypeID) = 2 Or (SupplierTransaction.SupplierTransaction_TransactionTypeID) = 3)) ORDER BY SupplierTransaction.SupplierTransaction_DayEndID, SupplierTransaction.SupplierTransactionID;")
            If rsSupplier.RecordCount = 0 Then
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section8. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.ReportDefinition.Sections("Section8").SectionFormat.EnableSuppress = True
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section8. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.ReportDefinition.Sections("Section8").SectionFormat.EnableSuppress = False
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport5. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.OpenSubreport("Subreport5").Database.Tables(1).SetDataSource(rsSupplier)
            End If
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section8. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.ReportDefinition.Sections("Section8").SectionFormat.EnableSuppress = True
        End If

        If gParameters And gParCustomer Then
            rsCustomer = getRS("SELECT Customer.Customer_InvoiceName, TransactionType.TransactionType_Name, CustomerTransaction.CustomerTransaction_Reference, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_Description, TransactionType.TransactionTypeID FROM (CustomerTransaction INNER JOIN Customer ON CustomerTransaction.CustomerTransaction_CustomerID = Customer.CustomerID) INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID Where (((CustomerTransaction.CustomerTransaction_DayEndID) = " & id & ")) ORDER BY Customer.Customer_InvoiceName, CustomerTransaction.CustomerTransaction_Date;")
            If rsCustomer.RecordCount = 0 Then
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section9. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.ReportDefinition.Sections("Section9").SectionFormat.EnableSuppress = True
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section9. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.ReportDefinition.Sections("Section9").SectionFormat.EnableSuppress = False
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport6. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.OpenSubreport("Subreport6").Database.Tables(1).SetDataSource(rsCustomer)
            End If
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section9. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.ReportDefinition.Sections("Section9").SectionFormat.EnableSuppress = True
        End If

        If gParameters And gParQuote Then
            rsQuote = getRS("SELECT Quote.* From Quote Where (((Quote.Quote_DayEndID) = " & id & ")) ORDER BY Quote.Quote_Name;")
            If rsQuote.RecordCount = 0 Then
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section10. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.ReportDefinition.Sections("Section10").SectionFormat.EnableSuppress = True
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section10. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.ReportDefinition.Sections("Section10").SectionFormat.EnableSuppress = False
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport7. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.OpenSubreport("Subreport7").Database.Tables(1).SetDataSource(rsQuote)
            End If
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section10. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.ReportDefinition.Sections("Section10").SectionFormat.EnableSuppress = True
        End If

        If gParameters And gParQuote Then
            rsConsignment = getRS("SELECT Consignment.*, Sale.Sale_Total AS saleAmount,0 as completeAmount,0 as returnAmount FROM Consignment INNER JOIN Sale ON Consignment.Consignment_SaleID = Sale.SaleID Where (((Consignment.Consignment_DayEndID) = " & id & ")) Union SELECT Consignment.*, 0 AS saleAmount, [saleComplete]![Sale_Total] AS completeAmount, [SaleReturned]![Sale_Total]+[saleComplete]![Sale_Total] AS returnAmount FROM (Consignment INNER JOIN Sale AS SaleReturned ON Consignment.Consignment_ReversalSaleID = SaleReturned.SaleID) INNER JOIN Sale AS saleComplete ON Consignment.Consignment_CompleteSaleID = saleComplete.SaleID WHERE (((Consignment.Consignment_DayEndID)=" & id & "));")
            If rsConsignment.RecordCount = 0 Then
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section11. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.ReportDefinition.Sections("Section11").SectionFormat.EnableSuppress = True
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section11. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.ReportDefinition.Sections("Section11").SectionFormat.EnableSuppress = False
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport8. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.OpenSubreport("Subreport8").Database.Tables(1).SetDataSource(rsConsignment)
            End If
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section11. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.ReportDefinition.Sections("Section11").SectionFormat.EnableSuppress = True
        End If

        'UPGRADE_WARNING: Couldn't resolve default property of object Report.VerifyOnEveryPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''Report.VerifyOnEveryPrint = True
        If bUploadReport = True Then
            Report.FileName = sPath
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.ExportOptions. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.RPTR, sPath)
            'Report.ExportOptions.DiskFileName = sPath
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.ExportOptions. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.HTML40, sPath)
            'Report.ExportOptions.HTMLFileName = sPath
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.ExportOptions. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'Report.ExportOptions.DestinationType = CRAXDRT.CRExportDestinationType.crEDTDiskFile
            'Report.ExportOptions.DestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.ExportOptions. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'Report.ExportOptions.FormatType = CRAXDRT.CRExportFormatType.crEFTExplorer32Extend
            'Report.ExportOptions.FormatType = CrystalDecisions.Shared.ExportFormatType.HTML40
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Export. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'Report.Export(False)
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = Report
            frmReportShow.mReport = Report : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
        End If
    End Sub

    Public Sub report_PurchaseOrder(ByRef id As Integer)
        Dim rs As ADODB.Recordset
        Dim rsItems As ADODB.Recordset
        Dim sql As String
        'UPGRADE_ISSUE: cryPurchaseOrder object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'Dim Report As New cryPurchaseOrder
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryPurchaseOrder")
        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT Supplier.*, PurchaseOrder.*, PurchaseOrderStatus.PurchaseOrderStatus_Name, PurchaseOrderStatus.PurchaseOrderStatus_Complete, Company.* FROM Company, (PurchaseOrder INNER JOIN Supplier ON PurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN PurchaseOrderStatus ON PurchaseOrder.PurchaseOrder_PurchaseOrderStatusID = PurchaseOrderStatus.PurchaseOrderStatusID WHERE (((PurchaseOrder.PurchaseOrderID)=" & id & "));")
        'UPGRADE_WARNING: Couldn't resolve default property of object Report.Database. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Report.Database.Tables(1).SetDataSource(rs)
        rsItems = getRS("SELECT PurchaseOrderItem.*, StockItem.* FROM PurchaseOrderItem INNER JOIN StockItem ON PurchaseOrderItem.PurchaseOrderItem_StockItemID = StockItem.StockItemID WHERE (((PurchaseOrderItem.PurchaseOrderItem_PurchaseOrderID)=" & id & ") AND ((PurchaseOrderItem.PurchaseOrderItem_Quantity)<>0));")
        'UPGRADE_WARNING: Couldn't resolve default property of object Report.Database. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Report.Database.Tables(2).SetDataSource(rsItems)

        'UPGRADE_WARNING: Couldn't resolve default property of object Report.VerifyOnEveryPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''Report.VerifyOnEveryPrint = True
        frmReportShow.Text = "Purchase Order"
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()

    End Sub

    Public Sub report_GRV(ByRef id As Integer)
        Dim rsItem1SQL As String
        Dim rs As ADODB.Recordset
        Dim rsPurch As ADODB.Recordset
        Dim rsCredit As ADODB.Recordset
        Dim rsPurchDeposit As ADODB.Recordset
        Dim rsCreditDeposit As ADODB.Recordset
        Dim rsItem0 As ADODB.Recordset
        Dim rsItem1 As ADODB.Recordset
        Dim rsDeposit0 As ADODB.Recordset
        Dim rsDeposit1 As ADODB.Recordset

        Dim rsData As ADODB.Recordset
        Dim sql As String
        'UPGRADE_ISSUE: cry object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'Dim Report As New cry
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryGRV")
        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rsData = getRS("SELECT GRV.*, [GRV_ContentExclusive]*([GRV_Ullage]/100) AS Ullage, PurchaseOrder.*, Supplier.*, Company.*, GRV.GRVID, Person.Person_FirstName & ' ' & Person.Person_LastName AS Name FROM Company, (GRV INNER JOIN (PurchaseOrder INNER JOIN Supplier ON PurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) ON GRV.GRV_PurchaseOrderID = PurchaseOrder.PurchaseOrderID) INNER JOIN Person ON GRV.GRV_PersonID = Person.PersonID WHERE (((GRV.GRVID)=" & id & "));")
        If rsData.RecordCount Then
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Database. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.Database.Tables(1).SetDataSource(rsData)
        Else
            rsData = getRS("SELECT GRV.*, [GRV_ContentExclusive]*([GRV_Ullage]/100) AS Ullage, PurchaseOrder.*, Supplier.*, Company.*, GRV.GRVID, 'Logged In User' AS Name FROM Company, GRV INNER JOIN (PurchaseOrder INNER JOIN Supplier ON PurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) ON GRV.GRV_PurchaseOrderID = PurchaseOrder.PurchaseOrderID WHERE (((GRV.GRVID)=" & id & "));")
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Database. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.Database.Tables(1).SetDataSource(rsData)
        End If
        rsPurch = getRS("SELECT Sum(((([GRVItem_PackSize]/[StockItem_Quantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])) AS exclusive, Sum(((([GRVItem_PackSize]/[StockItem_Quantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100)) AS inclusive, Sum(([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100)) AS depositIncl FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE (((GRVItem.GRVItem_Quantity)<>0) AND ((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_GRVID)=" & id & "));")
        'UPGRADE_WARNING: Couldn't resolve default property of object Report.Database. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Report.Database.Tables(2).SetDataSource(rsPurch)
        rsCredit = getRS("SELECT Sum(((([GRVItem_PackSize]/[StockItem_Quantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])) AS exclusiveCredit, Sum(((([GRVItem_PackSize]/[StockItem_Quantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100)) AS inclusiveCredit, Sum(([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100)) AS depositInclCredit FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE (((GRVItem.GRVItem_Quantity)<>0) AND ((GRVItem.GRVItem_Return)<>0) AND ((GRVItem.GRVItem_GRVID)=" & id & "));")
        'UPGRADE_WARNING: Couldn't resolve default property of object Report.Database. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Report.Database.Tables(3).SetDataSource(rsCredit)
        rsPurchDeposit = getRS("SELECT Sum((IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,[GRVDeposit_Quantity]*([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]*(1+[GRVDeposit_VatRate]/100)),0))+(IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,[GRVDeposit_quantity]*([GRVDeposit_CaseCost]*(1+[GRVDeposit_VatRate]/100)),0))) AS inclusiveDepositReturn From GRVDeposit WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & id & ") AND ((GRVDeposit.GRVDeposit_Return)=0));")
        'UPGRADE_WARNING: Couldn't resolve default property of object Report.Database. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Report.Database.Tables(4).SetDataSource(rsPurchDeposit)
        rsCreditDeposit = getRS("SELECT Sum((IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,[GRVDeposit_Quantity]*([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]*(1+[GRVDeposit_VatRate]/100)),0))+(IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,[GRVDeposit_quantity]*([GRVDeposit_CaseCost]*(1+[GRVDeposit_VatRate]/100)),0))) AS inclusiveDepositPurch From GRVDeposit WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & id & ") AND ((GRVDeposit.GRVDeposit_Return)<>0));")
        'UPGRADE_WARNING: Couldn't resolve default property of object Report.Database. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Report.Database.Tables(5).SetDataSource(rsCreditDeposit)

        ''Set rsItem0 = getRS("SELECT StockItem.StockItem_Name AS GRVItem_Name, GRVItem.GRVItem_Code, GRVItem.GRVItem_PackSize, GRVItem.GRVItem_Quantity, GRVItem.GRVItem_ContentCost, GRVItem.GRVItem_DepositCost, GRVItem.GRVItem_DiscountAmount, GRVItem.GRVItem_VatRate, ([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS depositInclusive, ((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity] AS contentExclusive, (((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS contentInclusive, (([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost]) AS contentCost FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE (((GRVItem.GRVItem_Quantity)<>0) AND ((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_GRVID)=" & id & "));")
        'Set rsItem0 = getRS("SELECT StockItem.StockItem_Name AS GRVItem_Name, GRVItem.GRVItem_Code, GRVItem.GRVItem_PackSize, GRVItem.GRVItem_Quantity, GRVItem.GRVItem_ContentCost, GRVItem.GRVItem_DepositCost, GRVItem.GRVItem_DiscountAmount, GRVItem.GRVItem_VatRate, ([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS depositInclusive, ((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity] AS contentExclusive, (((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS contentInclusive, (([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost]) AS contentCost FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE (((GRVItem.GRVItem_Quantity)<>0) AND ((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_GRVID)=" & id & "));")
        ' > Set rsItem0 = getRS("SELECT StockItem.StockItem_Name AS GRVItem_Name, GRVItem.GRVItem_Code, GRVItem.GRVItem_PackSize, GRVItem.GRVItem_Quantity, GRVItem.GRVItem_ContentCost, GRVItem.GRVItem_DepositCost, GRVItem.GRVItem_DiscountAmount, GRVItem.GRVItem_VatRate, ([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS depositInclusive, ([GRVItem_ContentCost]-[GRVItem_DiscountAmount])*[GRVItem_Quantity] AS contentExclusive, (([GRVItem_ContentCost]-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS contentInclusive, GRVItem.GRVItem_Quantity, PriceChannelLnk.PriceChannelLnk_Price, GRVItem.GRVItem_Price FROM (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) LEFT JOIN PriceChannelLnk ON GRVItem.GRVItem_StockItemID = PriceChannelLnk.PriceChannelLnk_StockItemID WHERE (((GRVItem.GRVItem_Quantity)<>0) AND ((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_GRVID)=" & id & "));")

        'commented lines to put    StockItem.StockItem_SupplierCode
        'rsItem1SQL = "SELECT GRVItem.GRVItem_Name, GRVItem.GRVItem_Code, GRVItem.GRVItem_PackSize, GRVItem.GRVItem_Quantity, GRVItem.GRVItem_ContentCost, GRVItem.GRVItem_DepositCost, GRVItem.GRVItem_DiscountAmount, GRVItem.GRVItem_VatRate, ([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS depositInclusive, ((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity] AS contentExclusive, (((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS contentInclusive, (([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost]) AS contentCost, " & _
        ''"GRVItem.GRVItem_Price FROM (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) WHERE (((GRVItem.GRVItem_Quantity)<>0) AND ((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_GRVID)=" & id & "));"
        'UPGRADE_WARNING: Couldn't resolve default property of object rsItem1SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        rsItem1SQL = "SELECT GRVItem.GRVItem_Name, StockItem.StockItem_SupplierCode, GRVItem.GRVItem_PackSize, GRVItem.GRVItem_Quantity, GRVItem.GRVItem_ContentCost, GRVItem.GRVItem_DepositCost, GRVItem.GRVItem_DiscountAmount, GRVItem.GRVItem_VatRate, ([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS depositInclusive, ((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity] AS contentExclusive, (((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS contentInclusive, (([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost]) AS contentCost, " & "GRVItem.GRVItem_Price FROM (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) WHERE (((GRVItem.GRVItem_Quantity)<>0) AND ((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_GRVID)=" & id & "));"
        'commented lines to put    StockItem.StockItem_SupplierCode

        'rsItem1SQL = "SELECT GRVItem.GRVItem_Name, GRVItem.GRVItem_Code, GRVItem.GRVItem_PackSize, GRVItem.GRVItem_Quantity, GRVItem.GRVItem_ContentCost, GRVItem.GRVItem_DepositCost, GRVItem.GRVItem_DiscountAmount, GRVItem.GRVItem_VatRate, ([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS depositInclusive, ((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity] AS contentExclusive, (((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS contentInclusive, (([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost]) AS contentCost, " & _
        '' "PriceChannelLnk.PriceChannelLnk_Price, GRVItem.GRVItem_Price FROM (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) LEFT JOIN PriceChannelLnk ON (GRVItem.GRVItem_StockItemID = PriceChannelLnk.PriceChannelLnk_StockItemID) AND (GRVItem.GRVItem_StockItemQuantity = PriceChannelLnk.PriceChannelLnk_Quantity) WHERE (((GRVItem.GRVItem_Quantity)<>0) AND ((GRVItem.GRVItem_Return)=0) AND ((GRVItem.GRVItem_GRVID)=" & id & "));"
        rsItem0 = getRS(rsItem1SQL)
        If rsItem0.RecordCount = 0 Then
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.ReportDefinition.Sections("Section2").SectionFormat.EnableSuppress = True
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.ReportDefinition.Sections("Section2").SectionFormat.EnableSuppress = False
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.OpenSubreport("Subreport1").Database.Tables(1).SetDataSource(rsItem0)
        End If

        rsDeposit0 = getRS("SELECT GRVDeposit.*, IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,([GRVDeposit_CaseCost]),0)+IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]),0) AS exclusive, IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,([GRVDeposit_CaseCost]*(1+[GRVDeposit_VatRate]/100)),0)+IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]*(1+[GRVDeposit_VatRate]/100)),0) AS inclusive From GRVDeposit WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & id & ") AND ((GRVDeposit.GRVDeposit_Return)<>0));")
        If rsDeposit0.RecordCount = 0 Then '
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section3. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.ReportDefinition.Sections("Section3").SectionFormat.EnableSuppress = True
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section3. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.ReportDefinition.Sections("Section3").SectionFormat.EnableSuppress = False
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.OpenSubreport("Subreport2").Database.Tables(1).SetDataSource(rsDeposit0)
        End If

        'Set rsItem1 = getRS("SELECT GRVItem.GRVItem_Name, GRVItem.GRVItem_Code, GRVItem.GRVItem_PackSize, GRVItem.GRVItem_Quantity, GRVItem.GRVItem_ContentCost, GRVItem.GRVItem_DepositCost, GRVItem.GRVItem_DiscountAmount, GRVItem.GRVItem_VatRate, ([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS depositInclusive, ((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity] AS contentExclusive, (((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS contentInclusive, (([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost]) AS contentCost FROM GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID WHERE (((GRVItem.GRVItem_Quantity)<>0) AND ((GRVItem.GRVItem_Return)<>0) AND ((GRVItem.GRVItem_GRVID)=" & id & "));")

        'commented lines to put    StockItem.StockItem_SupplierCode
        'rsItem1SQL = "SELECT GRVItem.GRVItem_Name, GRVItem.GRVItem_Code, GRVItem.GRVItem_PackSize, GRVItem.GRVItem_Quantity, GRVItem.GRVItem_ContentCost, GRVItem.GRVItem_DepositCost, GRVItem.GRVItem_DiscountAmount, GRVItem.GRVItem_VatRate, ([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS depositInclusive, ((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity] AS contentExclusive, (((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS contentInclusive, (([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost]) AS contentCost, " & _
        ''"GRVItem.GRVItem_Price FROM (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) WHERE (((GRVItem.GRVItem_Quantity)<>0) AND ((GRVItem.GRVItem_Return)<>0) AND ((GRVItem.GRVItem_GRVID)=" & id & "));"
        'UPGRADE_WARNING: Couldn't resolve default property of object rsItem1SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        rsItem1SQL = "SELECT GRVItem.GRVItem_Name, StockItem.StockItem_SupplierCode, GRVItem.GRVItem_PackSize, GRVItem.GRVItem_Quantity, GRVItem.GRVItem_ContentCost, GRVItem.GRVItem_DepositCost, GRVItem.GRVItem_DiscountAmount, GRVItem.GRVItem_VatRate, ([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS depositInclusive, ((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity] AS contentExclusive, (((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS contentInclusive, (([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost]) AS contentCost, " & "GRVItem.GRVItem_Price FROM (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) WHERE (((GRVItem.GRVItem_Quantity)<>0) AND ((GRVItem.GRVItem_Return)<>0) AND ((GRVItem.GRVItem_GRVID)=" & id & "));"
        'commented lines to put    StockItem.StockItem_SupplierCode

        'rsItem1SQL = "SELECT GRVItem.GRVItem_Name, GRVItem.GRVItem_Code, GRVItem.GRVItem_PackSize, GRVItem.GRVItem_Quantity, GRVItem.GRVItem_ContentCost, GRVItem.GRVItem_DepositCost, GRVItem.GRVItem_DiscountAmount, GRVItem.GRVItem_VatRate, ([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS depositInclusive, ((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity] AS contentExclusive, (((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS contentInclusive, (([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost]) AS contentCost, " & _
        ''"PriceChannelLnk.PriceChannelLnk_Price, GRVItem.GRVItem_Price FROM (GRVItem INNER JOIN StockItem ON GRVItem.GRVItem_StockItemID = StockItem.StockItemID) LEFT JOIN PriceChannelLnk ON (GRVItem.GRVItem_StockItemID = PriceChannelLnk.PriceChannelLnk_StockItemID) AND (GRVItem.GRVItem_StockItemQuantity = PriceChannelLnk.PriceChannelLnk_Quantity) WHERE (((GRVItem.GRVItem_Quantity)<>0) AND ((GRVItem.GRVItem_Return)<>0) AND ((GRVItem.GRVItem_GRVID)=" & id & "));"
        rsItem1 = getRS(rsItem1SQL)
        If rsItem1.RecordCount = 0 Then
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section4. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.ReportDefinition.Sections("Section4").SectionFormat.EnableSuppress = True
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section4. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.ReportDefinition.Sections("Section4").SectionFormat.EnableSuppress = False
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport3. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.OpenSubreport("Subreport3").Database.Tables(1).SetDataSource(rsItem1)
        End If

        rsDeposit1 = getRS("SELECT GRVDeposit.*, IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,([GRVDeposit_CaseCost]),0)+IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]),0) AS exclusive, IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,([GRVDeposit_CaseCost]*(1+[GRVDeposit_VatRate]/100)),0)+IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]*(1+[GRVDeposit_VatRate]/100)),0) AS inclusive From GRVDeposit WHERE (((GRVDeposit.GRVDeposit_GRVID)=" & id & ") AND ((GRVDeposit.GRVDeposit_Return)=0));")
        If rsDeposit1.RecordCount = 0 Then '
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section5. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.ReportDefinition.Sections("Section5").SectionFormat.EnableSuppress = True
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Section5. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.ReportDefinition.Sections("Section5").SectionFormat.EnableSuppress = False
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.Subreport4. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.OpenSubreport("Subreport4").Database.Tables(1).SetDataSource(rsDeposit1)
        End If

        'UPGRADE_WARNING: Couldn't resolve default property of object Report.VerifyOnEveryPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''Report.VerifyOnEveryPrint = True
        frmReportShow.Text = "Goods Receiving"
        'UPGRADE_WARNING: Couldn't resolve default property of object frmReportShow.CRViewer1.ReportSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object Report. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()

    End Sub


    Public Sub report_CustomerStatement(ByRef id As Integer)
        Dim rsInterest As ADODB.Recordset
        Dim rsTransaction As ADODB.Recordset
        Dim rsCompany As ADODB.Recordset
        Dim lNumber As String
        Dim lAddress As String
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim Address As String
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryCustomerStatement")
        'Dim Report As New cryCustomerStatement
        Dim lDate As Date

        Dim gMonth As Short
        Dim cnnDBStatement As New ADODB.Connection
        With cnnDBStatement
            .Provider = "MSDataShape"
            cnnDBStatement.Open("Data Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & serverPath & "pricing.mdb" & ";User Id=liquid;Password=lqd;Jet OLEDB:System Database=" & serverPath & "Secured.mdw")
        End With

        rs = getRS("SELECT Company_MonthendID FROM Company;")
        If rs.Fields("Company_MonthendID").Value <= 1 Then
            gMonth = 1
        Else
            gMonth = rs.Fields("Company_MonthendID").Value '- 1
        End If

        rs = getRS("SELECT MonthEnd.MonthEnd_Date From MonthEnd WHERE (((MonthEnd.MonthEndID)=" & gMonth & "));")
        'rs.Open "SELECT MonthEnd.MonthEnd_Date From MonthEnd WHERE (((MonthEnd.MonthEndID)=" & gMonth & "));", cnnDBStatement, adOpenStatic, adLockReadOnly, adCmdText
        If IsDbNull(rs.Fields("MonthEnd_Date").Value) = True Or rs.RecordCount = 0 Then
            gMonth = 1
            rs = getRS("SELECT MonthEnd.MonthEnd_Date From MonthEnd WHERE (((MonthEnd.MonthEndID)=" & gMonth & "));")
        End If

        Report.SetParameterValue("txtStatementDate", Format(Today, "dd mmm yyyy"))
        If rs.RecordCount Then
            'Report.txtStatementDate.SetText Format(rs("MonthEnd_Date"), "dd mmm yyyy")
            lDate = rs.Fields("MonthEnd_Date").Value
        Else

        End If
        rs.Close()
        rs = getRS("SELECT * FROM Company")
        lDate = System.Date.FromOADate(lDate.ToOADate + 10)
        lDate = DateSerial(Year(lDate), Month(lDate), 1)
        lDate = System.Date.FromOADate(lDate + rs.Fields("Company_PaymentDay").Value - 1)
        'Report.txtPaymentDate.SetText Format(lDate, "dd mmm yyyy")

        Address = Replace(rs.Fields("Company_PhysicalAddress").Value, vbCrLf, ", ")
        If Right(lAddress, 2) = ", " Then
            lAddress = Left(lAddress, Len(lAddress) - 2)
        End If
        Report.Database.Tables(1).SetDataSource(rs)
        Report.SetParameterValue("txtAddress", lAddress)
        lNumber = ""
        If rs.Fields("Company_Telephone").Value <> "" Then lNumber = lNumber & "Tel: " & rs.Fields("Company_Telephone").Value
        If rs.Fields("Company_Fax").Value <> "" Then
            If lNumber <> "" Then lNumber = lNumber & " / "
            lNumber = lNumber & "Fax: " & rs.Fields("Company_Fax").Value
        End If
        If rs.Fields("Company_Email").Value <> "" Then
            If lNumber <> "" Then lNumber = lNumber & " / "
            lNumber = lNumber & "Email: " & rs.Fields("Company_Email").Value
        End If
        Report.SetParameterValue("txtNumbers", lNumber)

        'New banking details
        If IsDbNull(rs.Fields("Company_BankName").Value) Then
        Else
            Report.SetParameterValue("txtBankName", rs.Fields("Company_BankName"))
        End If

        If IsDbNull(rs.Fields("Company_BranchName").Value) Then
        Else
            Report.SetParameterValue("txtBranchName", rs.Fields("Company_BranchName"))
        End If

        If IsDbNull(rs.Fields("Company_BranchCode").Value) Then
        Else
            Report.SetParameterValue("txtBranchCode", rs.Fields("Company_BranchCode"))
        End If

        If IsDbNull(rs.Fields("Company_AccountNumber").Value) Then
        Else
            Report.SetParameterValue("txtAccountNumber", rs.Fields("Company_AccountNumber"))
        End If
        '...................

        rsCompany = New ADODB.Recordset
        rsCompany.Open("SELECT * FROM Customer Where CustomerID = " & id, cnnDBStatement, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
        Report.Database.Tables(2).SetDataSource(rsCompany)

        rsTransaction = New ADODB.Recordset
        'changed for OPEN ITEM
        'rsTransaction.Open "SELECT CustomerTransaction.CustomerTransactionID, CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_Reference, CustomerTransaction.CustomerTransaction_PersonName," & _
        ''" TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" & id & "));", cnnDBStatement, adOpenStatic, adLockReadOnly, adCmdText
        rsTransaction.Open("SELECT CustomerTransaction.CustomerTransactionID, CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount-IIf(IsNull([CustomerTransaction.CustomerTransaction_Allocated]),0,[CustomerTransaction.CustomerTransaction_Allocated]), CustomerTransaction.CustomerTransaction_Reference & IIf([CustomerTransaction.CustomerTransaction_Allocated]<>[CustomerTransaction_Amount] AND [CustomerTransaction.CustomerTransaction_Allocated]<>0,'   (P)',Null), CustomerTransaction.CustomerTransaction_PersonName, TransactionType.TransactionType_Name," & " IIf(([CustomerTransaction_Amount]-IIf(IsNull([CustomerTransaction.CustomerTransaction_Allocated]),0,[CustomerTransaction.CustomerTransaction_Allocated]))>0,([CustomerTransaction_Amount]-IIf(IsNull([CustomerTransaction.CustomerTransaction_Allocated]),0,[CustomerTransaction.CustomerTransaction_Allocated])),Null) AS debit," & " IIf(([CustomerTransaction_Amount]-IIf(IsNull([CustomerTransaction.CustomerTransaction_Allocated]),0,[CustomerTransaction.CustomerTransaction_Allocated]))<0,([CustomerTransaction_Amount]-IIf(IsNull([CustomerTransaction.CustomerTransaction_Allocated]),0,[CustomerTransaction.CustomerTransaction_Allocated])),Null) AS credit, CustomerTransaction.CustomerTransaction_Main, CustomerTransaction.CustomerTransaction_Child, CustomerTransaction.CustomerTransaction_Allocated FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" & id & ") AND ((CustomerTransaction.CustomerTransaction_Amount-IIf(IsNull([CustomerTransaction.CustomerTransaction_Allocated]),0,[CustomerTransaction.CustomerTransaction_Allocated]))<>0)) ORDER BY CustomerTransaction.CustomerTransaction_Date;", cnnDBStatement, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)

        If rsTransaction.BOF Or rsTransaction.EOF Then
            rsTransaction = New ADODB.Recordset
            rsTransaction.Open("SELECT 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0," & " 0, 0 AS debit, 0 AS credit;", cnnDBStatement, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
            Report.Database.Tables(3).SetDataSource(rsTransaction)
            'Exit Sub
        Else
            Report.Database.Tables(3).SetDataSource(rsTransaction)

        End If
        'rs.Close

        rsInterest = New ADODB.Recordset
        'UPGRADE_WARNING: Couldn't resolve default property of object rsInterest.Open. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        rsInterest.Open("SELECT * FROM Interest WHERE (((CustomerID)=" & id & ")) and (Debit>0);", cnnDBStatement, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)

        'If rsInterest.BOF Or rsInterest.EOF Then
        If rsInterest.RecordCount > 0 Then
            'Report.Field20.Top = 280
            'Report.Field21.Top = 280
            'Report.Field22.Top = 280
            'Report.Field23.Top = 280

            Report.Database.Tables(4).SetDataSource(rsInterest)

        Else
            rsInterest = New ADODB.Recordset
            rsInterest.Open("SELECT 0 AS CustomerID, 0 AS CDate, 0 AS Description, 0 AS Debit, 0 AS Credit, 0 AS SumIntBal ;", cnnDBStatement, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
            'Report.Field20.Suppress = True
            'Report.Field21.Suppress = True
            'Report.Field22.Suppress = True
            'Report.Field23.Suppress = True
            Report.Database.Tables(4).SetDataSource(rsInterest)

            'Exit Sub
            'Set rsInterest = New Recordset
            'rsInterest.Open "SELECT * FROM Interest WHERE (((CustomerID)=" & id & "));", cnnDBStatement, adOpenStatic, adLockReadOnly, adCmdText
        End If
        ' rsInterest.Open ("SELECT Interest.*, Interest.Description,WHERE (((Interest.CustomerID)=" & id & "));"), cnnDBStatement, adOpenStatic, adLockReadOnly, adCmdText
        'Dim rsinte As String
        ' rsinte = rsInterest("Description")
        'If rsInterest.RecordCount > 0 Then
        '        Report.Database.Tables(4).SetDataSource rsInterest, 3
        'Else
        '   Set rsInterest = New Recordset
        '   rsInterest.Open "SELECT 0 AS CustomerID, 0 AS CDate, 0 AS Description, 0 AS Debit, 0 AS Credit, 0 AS SumIntBal ;", cnnDBStatement, adOpenStatic, adLockReadOnly, adCmdText
        '   Report.Database.Tables(4).SetDataSource rsInterest, 3
        'End If

        'Set rsTrans = New Recordset
        'Dim NewDateC As String
        'NewDateC = Format(Now)
        'rsTrans.Open ""
        'Report.Database.Tables(4).SetDataSource rsTrans, 3

        If rsTransaction.BOF Or rsTransaction.EOF Then
            Exit Sub
            'rsTransaction.Open "SELECT CustomerTransaction.CustomerTransactionID, CustomerTransaction.CustomerTransaction_CustomerID, CustomerTransaction.CustomerTransaction_TransactionTypeID, CustomerTransaction.CustomerTransaction_DayEndID, CustomerTransaction.CustomerTransaction_MonthEndID, CustomerTransaction.CustomerTransaction_ReferenceID, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_Description, CustomerTransaction.CustomerTransaction_Amount, CustomerTransaction.CustomerTransaction_Reference, CustomerTransaction.CustomerTransaction_PersonName," & _
            ''" TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" & id & "));", cnnDBStatement, adOpenStatic, adLockReadOnly, adCmdText
        End If

        If rs.Fields("Company_DebtorPrintBal").Value = True Then
            Dim textObject As CrystalDecisions.CrystalReports.Engine.TextObject = Report.ReportDefinition.ReportObjects("Text5")
            textObject.Color = Color.White
        End If
        'Report.PrintOut False, 1
        'Screen.MousePointer = vbDefault

        frmReportShow.Text = "Customer Statement"
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "1"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    'Public Sub report_CustomerStatement(id As Long)
    '    Dim rs As Recordset
    '    Dim rsCompany As Recordset
    '    Dim rsTransaction As Recordset
    '    Dim lAddress As String
    '    Dim lNumber As String
    '    Dim Report As New cryCustomerStatement
    '    Screen.MousePointer = vbHourglass
    '
    '    Set rs = getRS("SELECT * FROM Company")
    '
    '    If IsNull(rs("Company_PhysicalAddress")) Then
    '
    '    Else
    '        lAddress = Replace(rs("Company_PhysicalAddress"), vbCrLf, ", ")
    '        If Right(lAddress, 2) = ", " Then
    '          lAddress = Left(lAddress, Len(lAddress) - 2)
    '        End If
    '    End If
    '
    '    Report.Database.Tables(1).SetDataSource rs, 3
    '    Report.txtAddress.SetText lAddress
    '    lNumber = ""
    '    If rs("Company_Telephone") <> "" Then lNumber = lNumber & "Tel: " & rs("Company_Telephone")
    '    If rs("Company_Fax") <> "" Then
    '        If lNumber <> "" Then lNumber = lNumber & " / "
    '        lNumber = lNumber & "Fax: " & rs("Company_Fax")
    '    End If
    '    If rs("Company_Email") <> "" Then
    '        If lNumber <> "" Then lNumber = lNumber & " / "
    '        lNumber = lNumber & "Email: " & rs("Company_Email")
    '    End If
    '    Report.txtNumbers.SetText lNumber
    '
    '    'New banking details
    '      If IsNull(rs("Company_BankName")) Then Else Report.txtBankName.SetText rs("Company_BankName")
    '
    '       If IsNull(rs("Company_BranchName")) Then Else Report.txtBranchName.SetText rs("Company_BranchName")
    '
    '       If IsNull(rs("Company_BranchCode")) Then Else Report.txtBranchCode.SetText rs("Company_BranchCode")
    '
    '       If IsNull(rs("Company_AccountNumber")) Then Else Report.txtAccountNumber.SetText rs("Company_AccountNumber")
    '    '...................
    '
    '
    '    Set rsCompany = getRS("SELECT * FROM Customer Where CustomerID = " & id)
    '    Report.Database.Tables(2).SetDataSource rsCompany, 3
    '    Set rsTransaction = getRS("SELECT CustomerTransaction.*, TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" & id & "));")
    '    Report.Database.Tables(3).SetDataSource rsTransaction, 3

    '    If rsTransaction.BOF Or rsTransaction.EOF Then
    '        'ReportNone.Load("cryNoRecords.rpt")
    '        ReportNone.txtCompanyName.SetText rs("Company_Name")
    '        ReportNone.txtTitle.SetText "Statement"
    '        frmReportShow.Caption = ReportNone.txtTitle.Text
    '        frmReportShow.CRViewer1.ReportSource = ReportNone
    '        Set frmReportShow.mReport = ReportNone: frmReportShow.sMode = "0"
    '        frmReportShow.CRViewer1.ViewReport
    '        Screen.MousePointer = vbDefault
    '        frmReportShow.show 1
    '        Exit Sub
    '    End If
    '
    '    frmReportShow.Caption = "Customer Statement"
    '    frmReportShow.CRViewer1.ReportSource = Report
    '    Set frmReportShow.mReport = Report: frmReportShow.sMode = "0"
    '    frmReportShow.CRViewer1.ViewReport
    '    Screen.MousePointer = vbDefault
    '    frmReportShow.show 1
    '
    'End Sub

    Public Sub report_CustomerNotes(ByRef id As Integer, ByRef section As Object)
        Dim rs As ADODB.Recordset
        Dim rsCompany As ADODB.Recordset
        Dim rsTransaction As ADODB.Recordset
        Dim rsInterest As ADODB.Recordset
        Dim lAddress As String
        Dim lNumber As String
        'Dim Report As New cryCustomerStatement
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryCustomerStatement")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        Select Case section
            Case 3
                Report.SetParameterValue("Text1", " Debit Note ")
            Case 4
                Report.SetParameterValue("Text1", " Credit Note ")
        End Select

        rs = getRS("SELECT * FROM Company")

        If IsDbNull(rs.Fields("Company_PhysicalAddress").Value) Then

        Else
            lAddress = Replace(rs.Fields("Company_PhysicalAddress").Value, vbCrLf, ", ")
            If Right(lAddress, 2) = ", " Then
                lAddress = Left(lAddress, Len(lAddress) - 2)
            End If
        End If

        Report.Database.Tables(1).SetDataSource(rs)
        Report.SetParameterValue("txtAddress", lAddress)
        lNumber = ""
        If rs.Fields("Company_Telephone").Value <> "" Then lNumber = lNumber & "Tel: " & rs.Fields("Company_Telephone").Value
        If rs.Fields("Company_Fax").Value <> "" Then
            If lNumber <> "" Then lNumber = lNumber & " / "
            lNumber = lNumber & "Fax: " & rs.Fields("Company_Fax").Value
        End If
        If rs.Fields("Company_Email").Value <> "" Then
            If lNumber <> "" Then lNumber = lNumber & " / "
            lNumber = lNumber & "Email: " & rs.Fields("Company_Email").Value
        End If
        Report.SetParameterValue("txtNumbers", lNumber)

        'New banking details
        If IsDbNull(rs.Fields("Company_BankName").Value) Then
        Else
            Report.SetParameterValue("txtBankName", rs.Fields("Company_BankName"))
        End If

        If IsDbNull(rs.Fields("Company_BranchName").Value) Then
        Else
            Report.SetParameterValue("txtBranchName", rs.Fields("Company_BranchName"))
        End If

        If IsDbNull(rs.Fields("Company_BranchCode").Value) Then
        Else
            Report.SetParameterValue("txtBranchCode", rs.Fields("Company_BranchCode"))
        End If

        If IsDbNull(rs.Fields("Company_AccountNumber").Value) Then
        Else
            Report.SetParameterValue("txtAccountNumber", rs.Fields("Company_AccountNumber"))
        End If
        '...................

        rsCompany = getRS("SELECT * FROM Customer Where CustomerID = " & id)
        Report.Database.Tables(2).SetDataSource(rsCompany)
        rsTransaction = getRS("SELECT CustomerTransaction.*, TransactionType.TransactionType_Name, IIf([CustomerTransaction_Amount]>0,[CustomerTransaction_Amount],Null) AS debit, IIf([CustomerTransaction_Amount]<0,[CustomerTransaction_Amount],Null) AS credit FROM CustomerTransaction INNER JOIN TransactionType ON CustomerTransaction.CustomerTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((CustomerTransaction.CustomerTransaction_CustomerID)=" & id & "));")
        Report.Database.Tables(3).SetDataSource(rsTransaction)

        rsInterest = getRS("SELECT * FROM Interest where CustomerID=" & id)
        Report.Database.Tables(4).SetDataSource(rsInterest)

        ''ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords")
        If rsTransaction.BOF Or rsTransaction.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
            ReportNone.SetParameterValue("txtTitle", "Statement")
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        ''Report.VerifyOnEveryPrint = True
        frmReportShow.Text = "Customer Statement"
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0" : frmReportShow.sMode = "Cusmtomer"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Public Sub report_StockItemDuplicateCodes()
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryStockDuplicateCodes
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryStockDuplicateCodes")
        ReportNone.Load("cryNoRecords")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()
        rs = getRS("DISPLAY_StockDuplicateCodes")
        ''ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.SetDataSource(rs)
        Report.Database.Tables(1).SetDataSource(rs)
        ''Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub
    Public Sub report_Deposits()
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryDeposits
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryDeposits")
        ReportNone.Load("cryNoRecords")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()
        rs = getRS("SELECT * FROM Deposit")
        ''ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If
        Report.SetDataSource(rs)
        Report.Database.Tables(1).SetDataSource(rs)
        ''Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Public Sub report_Deposits_Query(ByRef sQuery As String)
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryDeposits
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryDeposits")
        ReportNone.Load("cryNoRecords")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()
        rs = getRS(sQuery)
        ''ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If
        Report.SetDataSource(rs)
        Report.Database.Tables(1).SetDataSource(rs)
        ''Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Public Sub report_PrintStockSerialsRPT()
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New crySerialList
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim showTotal As Boolean
        Report.Load("crySerialList")
        ReportNone.Load("cryNoRecords")
        showTotal = False
        If MsgBox("Do you wish to see only totals?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            showTotal = True
        End If
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()
        'Set rs = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_Name, SerialTracking.Serial_SerialNumber, SerialTracking.Serial_SupplierName, SerialTracking.Serial_DatePurchases, SerialTracking.Serial_Instock, SerialTracking.Serial_GRV_ID, SerialTracking.Serial_DateSold, GRV.GRV_Date, GRV.GRV_InvoiceNumber, GRV.GRV_InvoiceDate FROM (StockItem INNER JOIN SerialTracking ON StockItem.StockItemID = SerialTracking.Serial_StockItemID) INNER JOIN GRV ON SerialTracking.Serial_GRV_ID = GRV.GRVID WHERE (((SerialTracking.Serial_Instock)=False) AND ((StockItem.StockItem_SerialTracker)=True));")
        rs = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_Name, SerialTracking.Serial_SerialNumber, SerialTracking.Serial_SupplierName, SerialTracking.Serial_DatePurchases, SerialTracking.Serial_Instock, SerialTracking.Serial_GRV_ID, SerialTracking.Serial_DateSold, GRV.GRV_Date, GRV.GRV_InvoiceNumber, GRV.GRV_InvoiceDate FROM (StockItem INNER JOIN SerialTracking ON StockItem.StockItemID = SerialTracking.Serial_StockItemID) LEFT JOIN GRV ON SerialTracking.Serial_GRV_ID = GRV.GRVID WHERE (((SerialTracking.Serial_Instock)=False) AND ((StockItem.StockItem_SerialTracker)=True));")
        ''ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If
        Report.SetDataSource(rs)
        Report.Database.Tables(1).SetDataSource(rs)
        If showTotal = True Then
            Report.ReportDefinition.Sections("Section4").SectionFormat.EnableSuppress = True
        End If
        ''Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Public Sub report_BOM(Optional ByRef lcriteria As String = "")
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryBOM
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryBOM")
        ReportNone.Load("cryNoRecords")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()
        sql = "SELECT report_recipe.* FROM report_recipe "
        '    If lcriteria <> "" Then sql = sql & " WHERE " & lcriteria
        rs = getRS(sql & lcriteria)
        ''ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If
        Report.SetDataSource(rs)
        Report.Database.Tables(1).SetDataSource(rs)
        ''Report.VerifyOnEveryPrint = True
        '    With Report
        '        .ExportOptions.FormatType = crEFTExplorer32Extend
        '        .ExportOptions.DestinationType = crEDTDiskFile
        '        .ExportOptions.DiskFileName = App.Path + "\test.html"
        '        ' location & the file name
        '        .ExportOptions.HTMLFileName = App.Path + "\test.html" 'PDFExportAllPages = True
        '        .Export (False)
        '    End With
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Public Sub report_StockBreak()
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryStockBreak
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryStockBreak")
        ReportNone.Load("cryNoRecords")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()
        rs = getRS("SELECT StockItem.StockItem_Name, StockItem_1.StockItem_Name AS StockItemChild_Name, StockBreak.* FROM (StockItem INNER JOIN StockBreak ON StockItem.StockItemID = StockBreak.StockBreak_ParentID) INNER JOIN StockItem AS StockItem_1 ON StockBreak.StockBreak_ChildID = StockItem_1.StockItemID ORDER BY StockItem.StockItem_Name;")
        ''ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            'UPGRADE_WARNING: Couldn't resolve default property of object ReportNone.txtTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If
        'UPGRADE_WARNING: Couldn't resolve default property of object Report.Database. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Report.Database.Tables(0).SetDataSource(rs)
        'UPGRADE_WARNING: Couldn't resolve default property of object Report.Database. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Report.Database.Tables(1).SetDataSource(rs)
        'UPGRADE_WARNING: Couldn't resolve default property of object Report.VerifyOnEveryPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''Report.VerifyOnEveryPrint = True
        'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub
    Public Sub report_StockValue()
        Dim rs As ADODB.Recordset
        Dim sql As String
        'UPGRADE_ISSUE: cryStockValue object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'Dim Report As New cryStockValue
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryStockValue")
        ReportNone.Load("cryNoRecords")
        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtCompanyName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()

        sql = "SELECT StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID FROM (Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID GROUP BY StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, Warehouse.Warehouse_Saleable, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID "
        sql = sql & " Having (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity)) > 0) And ((Warehouse.Warehouse_Saleable) = True) And ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) = 2)) ORDER BY StockItem.StockItem_Name;"

        rs = getRS(sql)

        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            'UPGRADE_WARNING: Couldn't resolve default property of object ReportNone.txtTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.Database.Tables(0).SetDataSource(rs)
        'UPGRADE_WARNING: Couldn't resolve default property of object Report.VerifyOnEveryPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()

    End Sub
    Public Sub report_StockValuebyGS(ByRef grpID As String)
        Dim rsWH As ADODB.Recordset
        Dim rs As ADODB.Recordset
        Dim sql As String
        'UPGRADE_ISSUE: cryStockValuebyGS object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'Dim Report As New cryStockValuebyGS 'cryStockValue
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryStockValueByGS")
        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtCompanyName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()

        Dim lMWNo As Integer
        lMWNo = frmMWSelect.getMWNo
        If lMWNo > 1 Then
            rsWH = getRS("SELECT * FROM Warehouse WHERE WarehouseID=" & lMWNo & ";")
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtWH. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.SetParameterValue("txtWH", rsWH("Warehouse_Name"))
        End If

        If grpID <> "" Then
            'Multi Warehouse change
            'sql = "SELECT StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID FROM StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID GROUP BY StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, "
            'sql = sql & "WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID, Warehouse.Warehouse_Saleable HAVING (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity))>0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2) AND ((Warehouse.Warehouse_Saleable)=True)) AND (" & grpID & ") ORDER BY StockItem.StockItem_Name;"
            If MsgBox("Do you wish to see Retail Value instead of Cost Value?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.SetParameterValue("txtTitle", "Current Stock Retail Value By Group")
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.Text4. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.SetParameterValue("Text4", "Retail Value")
                'sql = "SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID FROM (StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID) INNER JOIN CatalogueChannelLnk ON (StockItem.StockItem_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) "
                'sql = sql & "GROUP BY StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID, Warehouse.Warehouse_Saleable, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID Having (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity)) > 0) And ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) =" & lMWNo & ") And ((Warehouse.Warehouse_Saleable) = True) And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1)) AND (" & grpID & ") ORDER BY StockItem.StockItem_Name;"
                'changed for Supplier QTY by markus
                sql = "SELECT StockItem.StockItem_Name, ([CatalogueChannelLnk.CatalogueChannelLnk_Price]/[StockItem.StockItem_Quantity]), Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID FROM (StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) LEFT JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID) INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID "
                sql = sql & "GROUP BY StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID, Warehouse.Warehouse_Saleable, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID Having (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity)) > 0) And ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) = " & lMWNo & ") And ((Warehouse.Warehouse_Saleable) = True) And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1)) AND (" & grpID & ") ORDER BY StockItem.StockItem_Name;"
            Else
                sql = "SELECT StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID FROM StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID GROUP BY StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, "
                sql = sql & "WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID, Warehouse.Warehouse_Saleable HAVING (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity))>0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=" & lMWNo & ") AND ((Warehouse.Warehouse_Saleable)=True)) AND (" & grpID & ") ORDER BY StockItem.StockItem_Name;"
            End If
            'sql = "SELECT StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID FROM StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID GROUP BY StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, "
            'sql = sql & "WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID, Warehouse.Warehouse_Saleable HAVING (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity))>0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=" & lMWNo & ") AND ((Warehouse.Warehouse_Saleable)=True)) AND (" & grpID & ") ORDER BY StockItem.StockItem_Name;"
            'Multi Warehouse change
        Else
            'Multi Warehouse change
            'sql = "SELECT StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name FROM StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID GROUP BY StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, "
            'sql = sql & "WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, Warehouse.Warehouse_Saleable, StockGroup.StockGroup_Name HAVING (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity))>0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2) AND ((Warehouse.Warehouse_Saleable)=True)) ORDER BY StockItem.StockItem_Name;"
            If MsgBox("Do you wish to see Retail Value instead of Cost Value?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Report.SetParameterValue("txtTitle", "Current Stock Retail Value By Group")
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.Text4. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.SetParameterValue("Text4", "Retail Value")
                'sql = "SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name FROM (StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID) INNER JOIN CatalogueChannelLnk ON (StockItem.StockItem_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) "
                'sql = sql & "GROUP BY StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, Warehouse.Warehouse_Saleable, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID Having (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity)) > 0) And ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) =" & lMWNo & ") And ((Warehouse.Warehouse_Saleable) = True) And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1)) ORDER BY StockItem.StockItem_Name;"
                'changed for Supplier QTY by markus
                sql = "SELECT StockItem.StockItem_Name, ([CatalogueChannelLnk.CatalogueChannelLnk_Price]/[StockItem.StockItem_Quantity]), Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID FROM (StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) LEFT JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID) INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID "
                sql = sql & "GROUP BY StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID, Warehouse.Warehouse_Saleable, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID Having (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity)) > 0) And ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) = " & lMWNo & ") And ((Warehouse.Warehouse_Saleable) = True) And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1)) ORDER BY StockItem.StockItem_Name;"
            Else
                sql = "SELECT StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name FROM StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID GROUP BY StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, "
                sql = sql & "WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, Warehouse.Warehouse_Saleable, StockGroup.StockGroup_Name HAVING (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity))>0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=" & lMWNo & ") AND ((Warehouse.Warehouse_Saleable)=True)) ORDER BY StockItem.StockItem_Name;"
            End If
            'sql = "SELECT StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name FROM StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID GROUP BY StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, "
            'sql = sql & "WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, Warehouse.Warehouse_Saleable, StockGroup.StockGroup_Name HAVING (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity))>0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=" & lMWNo & ") AND ((Warehouse.Warehouse_Saleable)=True)) ORDER BY StockItem.StockItem_Name;"
            'Multi Warehouse change
        End If

        rs = getRS(sql)

        ''ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.Database.Tables(0).SetDataSource(rs)
        ''Report.VerifyOnEveryPrint = True
        'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()

    End Sub

    Public Sub report_StockValuebyGX(ByRef grpID As String)
        Dim rsWH As ADODB.Recordset
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryStockValuebyGX
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryStockValuebyGX")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()

        Dim lMWNo As Integer
        lMWNo = frmMWSelect.getMWNo
        If lMWNo > 1 Then
            rsWH = getRS("SELECT * FROM Warehouse WHERE WarehouseID=" & lMWNo & ";")
            Report.SetParameterValue("txtWH", rsWH("Warehouse_Name"))
        End If

        If grpID <> "" Then
            'Multi Warehouse change
            'sql = "SELECT StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID FROM StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID GROUP BY StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, "
            'sql = sql & "WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID, Warehouse.Warehouse_Saleable HAVING (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity))>0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2) AND ((Warehouse.Warehouse_Saleable)=True)) AND (" & grpID & ") ORDER BY StockItem.StockItem_Name;"
            If MsgBox("Do you wish to see Retail Value instead of Cost Value?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Report.SetParameterValue("txtTitle", "Current Stock Retail Value By Group")
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.Text4. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.SetParameterValue("Text4", "Retail Value")
                'sql = "SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID FROM (StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID) INNER JOIN CatalogueChannelLnk ON (StockItem.StockItem_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) "
                'sql = sql & "AND (StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) GROUP BY StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID, Warehouse.Warehouse_Saleable, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID Having (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity)) > 0) And ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) =" & lMWNo & ") And ((Warehouse.Warehouse_Saleable) = True) And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1)) AND (" & grpID & ") ORDER BY StockItem.StockItem_Name;"
                'changed for Supplier QTY by markus
                sql = "SELECT StockItem.StockItem_Name, ([CatalogueChannelLnk.CatalogueChannelLnk_Price]/[StockItem.StockItem_Quantity]), Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID FROM (StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) LEFT JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID) INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID "
                sql = sql & "GROUP BY StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID, Warehouse.Warehouse_Saleable, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity Having (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity)) > 0) And ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) = " & lMWNo & ") And ((Warehouse.Warehouse_Saleable) = True) And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = 1)) AND (" & grpID & ") ORDER BY StockItem.StockItem_Name;"
            Else
                sql = "SELECT StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID FROM StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID GROUP BY StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, "
                sql = sql & "WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID, Warehouse.Warehouse_Saleable HAVING (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity))>0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=" & lMWNo & ") AND ((Warehouse.Warehouse_Saleable)=True)) AND (" & grpID & ") ORDER BY StockItem.StockItem_Name;"
            End If
            'Multi Warehouse change
        Else
            'Multi Warehouse change
            'sql = "SELECT StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name FROM StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID GROUP BY StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, "
            'sql = sql & "WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, Warehouse.Warehouse_Saleable, StockGroup.StockGroup_Name HAVING (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity))>0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2) AND ((Warehouse.Warehouse_Saleable)=True)) ORDER BY StockItem.StockItem_Name;"
            If MsgBox("Do you wish to see Retail Value instead of Cost Value?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Report.SetParameterValue("txtTitle", "Current Stock Retail Value By Group")
                Report.SetParameterValue("Text4", "Retail Value")
                'sql = "SELECT StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name FROM (StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID) INNER JOIN CatalogueChannelLnk ON (StockItem.StockItem_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) "
                'sql = sql & "GROUP BY StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, Warehouse.Warehouse_Saleable, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID Having (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity)) > 0) And ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) =" & lMWNo & ") And ((Warehouse.Warehouse_Saleable) = True) And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1)) ORDER BY StockItem.StockItem_Name;"
                'changed for Supplier QTY by markus
                sql = "SELECT StockItem.StockItem_Name, ([CatalogueChannelLnk.CatalogueChannelLnk_Price]/[StockItem.StockItem_Quantity]), Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID FROM (StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) LEFT JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID) INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID "
                sql = sql & "GROUP BY StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk.CatalogueChannelLnk_Price, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID, Warehouse.Warehouse_Saleable, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity Having (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity)) > 0) And ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) = " & lMWNo & ") And ((Warehouse.Warehouse_Saleable) = True) And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = 1)) ORDER BY StockItem.StockItem_Name;"
            Else
                sql = "SELECT StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name FROM StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID GROUP BY StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, "
                sql = sql & "WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, Warehouse.Warehouse_Saleable, StockGroup.StockGroup_Name HAVING (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity))>0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=" & lMWNo & ") AND ((Warehouse.Warehouse_Saleable)=True)) ORDER BY StockItem.StockItem_Name;"
            End If
            'Multi Warehouse change
        End If

        Debug.Print(sql)
        rs = getRS(sql)
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryReportNone")
        ''ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            'UPGRADE_WARNING: Couldn't resolve default property of object ReportNone.txtTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.Database.Tables(0).SetDataSource(rs)
        ''Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()

    End Sub

    Public Sub report_StockValuebyGX_RepDB(ByRef grpID As String)
        'Public Sub report_StockValuebyGX(grpID As String)
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryStockValuebyGX_RepDB
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryStockValuebyGX_RepDB")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()

        Report.SetParameterValue("txtTitle", "Stock Content Value By Group")

        If grpID <> "" Then
            'sql = "SELECT StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID FROM StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID GROUP BY StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, "
            'sql = sql & "WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, Warehouse.Warehouse_Saleable, StockGroup.StockGroupID HAVING (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity))>0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2) AND ((Warehouse.Warehouse_Saleable)=True) AND " & GrpID & ") ORDER BY StockItem.StockItem_Name;"
            sql = "SELECT StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID FROM StockGroup INNER JOIN ((Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON StockGroup.StockGroupID = StockItem.StockItem_StockGroupID GROUP BY StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, "
            sql = sql & "WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockGroup.StockGroup_Name, StockGroup.StockGroupID, Warehouse.Warehouse_Saleable HAVING (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity))>0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2) AND ((Warehouse.Warehouse_Saleable)=True)) AND (" & grpID & ") ORDER BY StockItem.StockItem_Name;"
        Else
            'sql = "SELECT aStockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk1.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, aStockItem.StockItem_ListCost, aStockItem.StockItem_Quantity, aDeposit.Deposit_UnitCost, WarehouseStockItemLnk1.WarehouseStockItemLnk_WarehouseID, aStockGroup.StockGroup_Name FROM aStockGroup INNER JOIN ((Warehouse1 INNER JOIN (WarehouseStockItemLnk1 INNER JOIN aStockItem ON WarehouseStockItemLnk1.WarehouseStockItemLnk_StockItemID = aStockItem.StockItemID) ON Warehouse1.WarehouseID = WarehouseStockItemLnk1.WarehouseStockItemLnk_WarehouseID) INNER JOIN aDeposit ON aStockItem.StockItem_DepositID = aDeposit.DepositID) ON aStockGroup.StockGroupID = aStockItem.StockItem_StockGroupID GROUP BY aStockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], aStockItem.StockItem_ListCost, aStockItem.StockItem_Quantity, aDeposit.Deposit_UnitCost, "
            'sql = sql & "WarehouseStockItemLnk1.WarehouseStockItemLnk_WarehouseID, Warehouse1.Warehouse_Saleable, aStockGroup.StockGroup_Name HAVING (((Sum(WarehouseStockItemLnk1.WarehouseStockItemLnk_Quantity))>0) AND ((WarehouseStockItemLnk1.WarehouseStockItemLnk_WarehouseID)=2) AND ((Warehouse1.Warehouse_Saleable)=True)) ORDER BY aStockItem.StockItem_Name;"
            sql = "SELECT aStockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, aStockItem.StockItem_ListCost, aStockItem.StockItem_Quantity, aDeposit.Deposit_UnitCost, 2 AS WarehouseStockItemLnk_WarehouseID, aStockGroup.StockGroup_Name FROM (aStockGroup INNER JOIN (aStockItem INNER JOIN aDeposit ON aStockItem.StockItem_DepositID = aDeposit.DepositID) ON aStockGroup.StockGroupID = aStockItem.StockItem_StockGroupID) INNER JOIN DayEndStockItemLnk ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID GROUP BY aStockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], aStockItem.StockItem_ListCost, aStockItem.StockItem_Quantity, aDeposit.Deposit_UnitCost, aStockGroup.StockGroup_Name Having (((Sum(DayEndStockItemLnk.DayEndStockItemLnk_Quantity)) > 0)) ORDER BY aStockItem.StockItem_Name;"

            sql = "SELECT aStockItem.StockItem_Name, ([StockItem_ListCost]/iif([DayEndStockItemLnk.DayEndStockItemLnk_Quantity]=0,1,[DayEndStockItemLnk.DayEndStockItemLnk_Quantity])) AS ListCost, Sum(DayEndStockItemLnk.DayEndStockItemLnk_Quantity-DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales-DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink+DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV) AS SumOfWarehouseStockItemLnk_Quantity, "
            'sql = sql & "aStockItem.StockItem_ListCost, aStockItem.StockItem_Quantity, aDeposit.Deposit_UnitCost, 2 AS WarehouseStockItemLnk_WarehouseID, aStockGroup.StockGroup_Name FROM (aStockGroup INNER JOIN (aStockItem INNER JOIN aDeposit ON aStockItem.StockItem_DepositID = aDeposit.DepositID) ON aStockGroup.StockGroupID = aStockItem.StockItem_StockGroupID) INNER JOIN DayEndStockItemLnk ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID GROUP BY aStockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], aStockItem.StockItem_ListCost, aStockItem.StockItem_Quantity, aDeposit.Deposit_UnitCost, aStockGroup.StockGroup_Name Having (((Sum(DayEndStockItemLnk.DayEndStockItemLnk_Quantity-DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales-DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink+DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV)) > 0)) ORDER BY aStockItem.StockItem_Name;"
            sql = sql & "aStockItem.StockItem_ListCost, aStockItem.StockItem_Quantity, aDeposit.Deposit_UnitCost, 2 AS WarehouseStockItemLnk_WarehouseID, aStockGroup.StockGroup_Name FROM (aStockGroup INNER JOIN (aStockItem INNER JOIN aDeposit ON aStockItem.StockItem_DepositID = aDeposit.DepositID) ON aStockGroup.StockGroupID = aStockItem.StockItem_StockGroupID) INNER JOIN DayEndStockItemLnk ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID GROUP BY aStockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], aStockItem.StockItem_ListCost, aStockItem.StockItem_Quantity, aDeposit.Deposit_UnitCost, aStockGroup.StockGroup_Name Having (((Sum(DayEndStockItemLnk.DayEndStockItemLnk_Quantity-DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales-DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink+DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV)) <> 0)) ORDER BY aStockItem.StockItem_Name;"

            sql = "SELECT aStockItem.StockItem_Name, [DayEndStockItemLnk_ListCost]/IIf([DayEndStockItemLnk_Quantity]=0,1,[DayEndStockItemLnk_Quantity]) AS ListCost, Sum(DayEndStockItemLnk.DayEndStockItemLnk_Quantity-DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales-DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink+DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV) AS SumOfWarehouseStockItemLnk_Quantity, "
            sql = sql & "DayEndStockItemLnk.DayEndStockItemLnk_ListCost AS StockItem_ListCost, DayEndStockItemLnk.DayEndStockItemLnk_Quantity AS StockItem_Quantity, aDeposit.Deposit_UnitCost, 2 AS WarehouseStockItemLnk_WarehouseID, aStockGroup.StockGroup_Name FROM (aStockGroup INNER JOIN (aStockItem INNER JOIN aDeposit ON aStockItem.StockItem_DepositID = aDeposit.DepositID) ON aStockGroup.StockGroupID = aStockItem.StockItem_StockGroupID) INNER JOIN DayEndStockItemLnk ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID GROUP BY aStockItem.StockItem_Name, [DayEndStockItemLnk_ListCost]/IIf([DayEndStockItemLnk_Quantity]=0,1,[DayEndStockItemLnk_Quantity]), DayEndStockItemLnk.DayEndStockItemLnk_ListCost, DayEndStockItemLnk.DayEndStockItemLnk_Quantity, aDeposit.Deposit_UnitCost, aStockGroup.StockGroup_Name "
            sql = sql & "Having (((Sum(DayEndStockItemLnk.DayEndStockItemLnk_Quantity-DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales-DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink+DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV)) <> 0)) ORDER BY aStockItem.StockItem_Name;"

            sql = "SELECT aStockItem.StockItem_Name, [DayEndStockItemLnk_ListCost]/IIf([DayEndStockItemLnk_Quantity]=0,1,[DayEndStockItemLnk_Quantity]) AS ListCost, Sum(DayEndStockItemLnk.DayEndStockItemLnk_Quantity-DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales-DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink+DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV) AS SumOfWarehouseStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_ListCost AS StockItem_ListCost, DayEndStockItemLnk.DayEndStockItemLnk_Quantity AS StockItem_Quantity, aDeposit.Deposit_UnitCost, 2 AS WarehouseStockItemLnk_WarehouseID, aStockGroup.StockGroup_Name "
            sql = sql & "FROM ((aStockGroup INNER JOIN (aStockItem INNER JOIN aDeposit ON aStockItem.StockItem_DepositID = aDeposit.DepositID) ON aStockGroup.StockGroupID = aStockItem.StockItem_StockGroupID) INNER JOIN DayEndStockItemLnk ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) INNER JOIN Report ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Report.Report_DayEndEndID GROUP BY aStockItem.StockItem_Name, [DayEndStockItemLnk_ListCost]/IIf([DayEndStockItemLnk_Quantity]=0,1,[DayEndStockItemLnk_Quantity]), DayEndStockItemLnk.DayEndStockItemLnk_ListCost, DayEndStockItemLnk.DayEndStockItemLnk_Quantity, aDeposit.Deposit_UnitCost, aStockGroup.StockGroup_Name "
            sql = sql & "HAVING (((Sum([DayEndStockItemLnk].[DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk].[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk].[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk].[DayEndStockItemLnk_QuantityGRV]))<>0)) ORDER BY aStockItem.StockItem_Name;"

            'query with Warehouse name for each item (changed on 08 Jan 2010)
            sql = "SELECT aStockItem.StockItem_Name, [DayEndStockItemLnk_ListCost]/IIf([DayEndStockItemLnk_Quantity]=0,1,[DayEndStockItemLnk_Quantity]) AS ListCost, Sum(DayEndStockItemLnk.DayEndStockItemLnk_Quantity-DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales-DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink+DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV+DayEndStockItemLnk.DayEndStockItemLnk_QuantityTransafer) AS SumOfWarehouseStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_ListCost AS StockItem_ListCost, DayEndStockItemLnk.DayEndStockItemLnk_Quantity AS StockItem_Quantity, aDeposit.Deposit_UnitCost, 2 AS WarehouseStockItemLnk_WarehouseID, aStockGroup.StockGroup_Name, Warehouse1.Warehouse_Name "
            sql = sql & "FROM (((aStockGroup INNER JOIN (aStockItem INNER JOIN aDeposit ON aStockItem.StockItem_DepositID = aDeposit.DepositID) ON aStockGroup.StockGroupID = aStockItem.StockItem_StockGroupID) INNER JOIN DayEndStockItemLnk ON aStockItem.StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID) INNER JOIN Report ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Report.Report_DayEndEndID) INNER JOIN Warehouse1 ON DayEndStockItemLnk.DayEndStockItemLnk_Warehouse = Warehouse1.WarehouseID GROUP BY aStockItem.StockItem_Name, [DayEndStockItemLnk_ListCost]/IIf([DayEndStockItemLnk_Quantity]=0,1,[DayEndStockItemLnk_Quantity]), DayEndStockItemLnk.DayEndStockItemLnk_ListCost, DayEndStockItemLnk.DayEndStockItemLnk_Quantity, aDeposit.Deposit_UnitCost, aStockGroup.StockGroup_Name, Warehouse1.Warehouse_Name "
            sql = sql & "Having (((Sum([DayEndStockItemLnk].[DayEndStockItemLnk_Quantity] - [DayEndStockItemLnk].[DayEndStockItemLnk_QuantitySales] - [DayEndStockItemLnk].[DayEndStockItemLnk_QuantityShrink] + [DayEndStockItemLnk].[DayEndStockItemLnk_QuantityGRV] + [DayEndStockItemLnk].[DayEndStockItemLnk_QuantityTransafer])) <> 0)) ORDER BY aStockItem.StockItem_Name;"

            'sql = "SELECT aStockItem.StockItem_Name, [DayEndStockItemLnk_ListCost]/IIf([DayEndStockItemLnk_Quantity]=0,1,[DayEndStockItemLnk_Quantity]) AS ListCost, Sum(DayEndStockItemLnk.DayEndStockItemLnk_Quantity-DayEndStockItemLnk.DayEndStockItemLnk_QuantitySales-DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink+DayEndStockItemLnk.DayEndStockItemLnk_QuantityGRV) AS SumOfWarehouseStockItemLnk_Quantity, DayEndStockItemLnk.DayEndStockItemLnk_ListCost AS StockItem_ListCost, DayEndStockItemLnk.DayEndStockItemLnk_Quantity AS StockItem_Quantity, aDeposit.Deposit_UnitCost, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse, aStockGroup.StockGroup_Name,  (SELECT Warehouse1.Warehouse_Name FROM Warehouse1 WHERE Warehouse1.WarehouseID = DayEndStockItemLnk.DayEndStockItemLnk_Warehouse) AS Expr1 "
            'sql = sql & "FROM (((Report INNER JOIN DayEndStockItemLnk ON Report.Report_DayEndEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) INNER JOIN aStockGroup ON aStockItem.StockItem_StockGroupID = aStockGroup.StockGroupID) INNER JOIN aDeposit ON aStockItem.StockItem_DepositID = aDeposit.DepositID GROUP BY aStockItem.StockItem_Name, [DayEndStockItemLnk_ListCost]/IIf([DayEndStockItemLnk_Quantity]=0,1,[DayEndStockItemLnk_Quantity]), DayEndStockItemLnk.DayEndStockItemLnk_ListCost, DayEndStockItemLnk.DayEndStockItemLnk_Quantity, aDeposit.Deposit_UnitCost, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse, aStockGroup.StockGroup_Name "
            'sql = sql & "Having (((DayEndStockItemLnk.DayEndStockItemLnk_Quantity)<>0) AND ((Sum([DayEndStockItemLnk].[DayEndStockItemLnk_Quantity] - [DayEndStockItemLnk].[DayEndStockItemLnk_QuantitySales] - [DayEndStockItemLnk].[DayEndStockItemLnk_QuantityShrink] + [DayEndStockItemLnk].[DayEndStockItemLnk_QuantityGRV])) <> 0)) ORDER BY aStockItem.StockItem_Name;"

        End If

        rs = getRSreport(sql)

        ''ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.Database.Tables(0).SetDataSource(rs)
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()

    End Sub


    Public Sub report_StockValueByDept(ByRef gID As Integer)
        Dim sql As String
        Dim rs As ADODB.Recordset
        Dim rj As ADODB.Recordset
        'Dim Report As New cryStockValue
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryStockValue.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()

        'Old StockTake Query
        sql = "SELECT StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity] AS ListCost, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS SumOfWarehouseStockItemLnk_Quantity, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID FROM (Warehouse INNER JOIN (WarehouseStockItemLnk INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID) ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID GROUP BY StockItem.StockItem_Name, [StockItem_ListCost]/[StockItem_Quantity], StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, Deposit.Deposit_UnitCost, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, Warehouse.Warehouse_Saleable, "
        sql = sql & "StockItem.StockItem_StockGroupID Having (((Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity)) > 0) And ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) = 2) And ((Warehouse.Warehouse_Saleable) = True) And ((StockItem.StockItem_StockGroupID) = " & gID & ")) ORDER BY StockItem.StockItem_Name;"

        rj = getRS("SELECT StockGroup.StockGroup_Name From StockGroup WHERE (((StockGroup.StockGroupID)=" & gID & "));")

        If IsDbNull(rj.Fields("StockGroup_Name").Value) Then
        Else
            Report.SetParameterValue("txtTitle", "Current Stock Content Value For " & rj.Fields("StockGroup_Name").Value)
        End If

        rs = getRS(sql)

        ''ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.SetDataSource(rs)
        ''Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Public Sub report_DepositValue_FromRepDB()
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryDepositValue
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryDepositValue.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()
        Report.SetParameterValue("txtTitle", "Deposit Value Report")
        'Set rs = getRS("SELECT Deposit.Deposit_Name, Deposit.Deposit_Quantity, IIf([WarehouseDepositItemLnk_DepositTypeID],'Crate','Bottle') AS depositType, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity AS quantity, IIf([WarehouseDepositItemLnk_DepositTypeID],[Deposit_CaseCost]*[WarehouseDepositItemLnk_Quantity],[Deposit_UnitCost]*[WarehouseDepositItemLnk_Quantity]) AS [value], IIf([WarehouseDepositItemLnk_DepositTypeID],[Deposit_CaseCost],[Deposit_UnitCost]) AS price FROM WarehouseDepositItemLnk INNER JOIN Deposit ON WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = Deposit.DepositID Where (((WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity) <> 0) And ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID) = 2)) ORDER BY Deposit.Deposit_Name, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID;")

        'Set rs = getRSreport("SELECT aDeposit.Deposit_Name, aDeposit.Deposit_Quantity, IIf([DayEndDeposittemLnk_DepositType],'Crate','Bottle') AS depositType, aDayEndDepositItemLnk.DayEndDepositItemLnk_Quantity AS quantity, IIf([DayEndDeposittemLnk_DepositType],[Deposit_CaseCost]*[DayEndDepositItemLnk_Quantity],[Deposit_UnitCost]*[DayEndDepositItemLnk_Quantity]) AS [value], IIf([DayEndDeposittemLnk_DepositType],[Deposit_CaseCost],[Deposit_UnitCost]) AS price FROM Report INNER JOIN (aDayEndDepositItemLnk INNER JOIN aDeposit ON aDayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = aDeposit.DepositID) ON Report.Report_DayEndStartID = aDayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID Where (((aDayEndDepositItemLnk.DayEndDepositItemLnk_Quantity) <> 0)) ORDER BY aDeposit.Deposit_Name, aDayEndDepositItemLnk.DayEndDeposittemLnk_DepositType;")

        'sql = "SELECT aDeposit.Deposit_Name, SUM(aDeposit.Deposit_Quantity), IIf([DayEndDeposittemLnk_DepositType],'Crate','Bottle') AS depositType, Sum(aDayEndDepositItemLnk.DayEndDepositItemLnk_Quantity) AS quantity, Sum(IIf([DayEndDeposittemLnk_DepositType]=0,[Deposit_UnitCost]*([DayEndDepositItemLnk_Quantity]-DayEndDepositItemLnk_QuantitySales-DayEndDepositItemLnk_QuantityShrink+DayEndDepositItemLnk_QuantityGRV),[Deposit_CaseCost]*([DayEndDepositItemLnk_Quantity]-DayEndDepositItemLnk_QuantitySales-DayEndDepositItemLnk_QuantityShrink+DayEndDepositItemLnk_QuantityGRV))) AS [value], IIf([DayEndDeposittemLnk_DepositType],[Deposit_CaseCost],[Deposit_UnitCost]) AS price FROM Report"
        'sql = sql & " INNER JOIN (aDayEndDepositItemLnk INNER JOIN aDeposit ON aDayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = aDeposit.DepositID) ON Report.Report_DayEndEndID = aDayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID Where (((aDayEndDepositItemLnk.DayEndDepositItemLnk_Quantity) <> 0)) GROUP BY Deposit_Name, DayEndDeposittemLnk_DepositType, IIf([DayEndDeposittemLnk_DepositType],'Crate','Bottle'), IIf([DayEndDeposittemLnk_DepositType],[Deposit_CaseCost],[Deposit_UnitCost]) ORDER BY aDeposit.Deposit_Name, aDayEndDepositItemLnk.DayEndDeposittemLnk_DepositType;"
        'Set rs = getRSreport(sql)
        sql = "SELECT aDeposit.Deposit_Name, aDeposit.Deposit_Quantity, IIf([DayEndDeposittemLnk_DepositType],'Crate','Bottle') AS depositType, DayEndDepositItemLnk.DayEndDepositItemLnk_Quantity AS quantity, IIf([DayEndDeposittemLnk_DepositType]=0,[DayEndDepositItemLnk_UnitCost]*([DayEndDepositItemLnk_Quantity]-DayEndDepositItemLnk_QuantitySales-DayEndDepositItemLnk_QuantityShrink+DayEndDepositItemLnk_QuantityGRV),[DayEndDepositItemLnk_CaseCost]*([DayEndDepositItemLnk_Quantity]-DayEndDepositItemLnk_QuantitySales-DayEndDepositItemLnk_QuantityShrink+DayEndDepositItemLnk_QuantityGRV)) AS [value], IIf([DayEndDeposittemLnk_DepositType],[Deposit_CaseCost],[Deposit_UnitCost]) AS price FROM Report"
        sql = sql & " INNER JOIN (DayEndDepositItemLnk INNER JOIN aDeposit ON DayEndDepositItemLnk.DayEndDeposittemLnk_DepositID = aDeposit.DepositID) ON Report.Report_DayEndEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID Where (((DayEndDepositItemLnk.DayEndDepositItemLnk_Quantity) <> 0)) ORDER BY aDeposit.Deposit_Name, DayEndDepositItemLnk.DayEndDeposittemLnk_DepositType;"
        rs = getRSreport(sql)

        ''ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If
        Report.SetDataSource(rs)
        ''Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub


    Public Sub report_DepositValue()
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryDepositValue
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryDepositValue.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()
        rs = getRS("SELECT Deposit.Deposit_Name, Deposit.Deposit_Quantity, IIf([WarehouseDepositItemLnk_DepositTypeID],'Crate','Bottle') AS depositType, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity AS quantity, IIf([WarehouseDepositItemLnk_DepositTypeID],[Deposit_CaseCost]*[WarehouseDepositItemLnk_Quantity],[Deposit_UnitCost]*[WarehouseDepositItemLnk_Quantity]) AS [value], IIf([WarehouseDepositItemLnk_DepositTypeID],[Deposit_CaseCost],[Deposit_UnitCost]) AS price FROM WarehouseDepositItemLnk INNER JOIN Deposit ON WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = Deposit.DepositID Where (((WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity) <> 0) And ((WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID) = 2)) ORDER BY Deposit.Deposit_Name, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID;")
        ''ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If
        Report.SetDataSource(rs)
        ''Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub
    Public Sub report_StockItemDisabled()
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryStockItemDisabled
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryStockItemDisabled.rpt")
        ReportNone.Load("cryNoRecords.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()
        rs = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_Disabled From StockItem Where (((StockItem.StockItem_Disabled) <> 0)) ORDER BY StockItem.StockItem_Name;")
        ''ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If
        Report.SetDataSource(rs)
        Report.Database.Tables(1).SetDataSource(rs)
        ''Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub
    Public Sub report_StockItemFixedActual()
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryStockItemFixedActual
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryStockItemFixedActual.rpt")
        ReportNone.Load("cryNoRecords.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()

        rs = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_ActualCostChange From StockItem Where (((StockItem.StockItem_ActualCostChange) <> 0)) ORDER BY StockItem.StockItem_Name;")

        ''ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.SetDataSource(rs)
        Report.Database.Tables(1).SetDataSource(rs)
        ''Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub
    Public Sub report_StockItemDiscontinued()
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryStockItemDiscontinued
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryStockItemDiscontinued.rpt")
        ReportNone.Load("cryNoRecords.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()
        rs = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_Discontinued From StockItem Where (((StockItem.StockItem_Discontinued) <> 0)) ORDER BY StockItem.StockItem_Name;")
        ''ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If
        Report.SetDataSource(rs)
        Report.Database.Tables(1).SetDataSource(rs)
        ''Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Public Sub report_StockItemBrokenPack()
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryStockItemBrokenPack
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryStockItemBrokenPack.rpt")
        ReportNone.Load("cryNoRecords.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()
        rs = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_OrderQuantity, StockItem.StockItem_Quantity From StockItem Where (((StockItem.StockItem_OrderQuantity) = 1) And ((StockItem.StockItem_Quantity) <> 1)) ORDER BY StockItem.StockItem_Name;")
        ''ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If
        Report.SetDataSource(rs)
        Report.Database.Tables(1).SetDataSource(rs)
        ''Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Public Sub report_StockItemActualCost(ByRef id As Integer)
        Dim rs As ADODB.Recordset
        Dim rsItems As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryStockItemActualCost
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryStockItemActualCost.rpt")
        ReportNone.Load("cryNoRecords.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()
        rs = getRS("SELECT StockItem.*, Supplier.Supplier_Name FROM Supplier INNER JOIN StockItem ON Supplier.SupplierID = StockItem.StockItem_SupplierID WHERE (((StockItem.StockItemID)=" & id & "));")
        ''ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If
        Report.Database.Tables(1).SetDataSource(rs)
        sql = "SELECT GRV.GRVID, GRV.GRV_InvoiceNumber, GRV.GRV_InvoiceDate, GRVItem.GRVItem_StockItemID, GRVItem.GRVItem_StockItemQuantity, GRVItem.GRVItem_ContentCost, GRVItem.GRVItem_DiscountAmount, [GRVItem_ContentCost]-[GRVItem_DiscountAmount]-[GRVItem_ActualCost] AS invoiceDiscount, GRVItem.GRVItem_OldActualCost AS oldPrice, GRVItem.GRVItem_WarehouseQuantity AS oldStockHolding, [GRVItem_OldActualCost]/[GRVItem_StockItemQuantity] AS oldUnitPrice, IIf([GRVItem_WarehouseQuantity]>0,[GRVItem_OldActualCost]/[GRVItem_StockItemQuantity]*[GRVItem_WarehouseQuantity],0) AS oldStockValue, GRVItem.GRVItem_ActualCost AS grvPrice, [GRVItem_PackSize]*[GRVItem_Quantity] AS grvStockHolding, [GRVItem_ActualCost]/[grvItem_StockItemQuantity] AS grvUnitPrice, ([GRVItem_PackSize]*[GRVItem_Quantity])*([GRVItem_ActualCost]/[grvItem_StockItemQuantity]) AS grvStockValue, GRVItem.GRVItem_PackSize, ([warehouseQuantity]+[grvStockHolding]) AS newStockHolding, IIf([oldStockHolding]+[grvStockHolding]=0,[grvUnitPrice], "
        sql = sql & "([oldStockValue]+[grvStockValue])) AS newStockValue, IIf([newStockHolding]=0,[grvUnitPrice],[newStockValue]/[newStockHolding]) AS newUnitPrice, IIf([GRVItem_WarehouseQuantity]>0,[GRVItem_WarehouseQuantity],0) AS warehouseQuantity, Supplier.Supplier_Name FROM ((GRVItem INNER JOIN GRV ON GRVItem.GRVItem_GRVID = GRV.GRVID) INNER JOIN PurchaseOrder ON GRV.GRV_PurchaseOrderID = PurchaseOrder.PurchaseOrderID) INNER JOIN Supplier ON PurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID Where (((GRVItem.GRVItem_StockItemID) = " & id & ") And ((GRVItem.GRVItem_Return) = 0)) ORDER BY GRV.GRVID DESC;"
        rsItems = getRS(sql)
        If rsItems.BOF Or rsItems.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If
        Report.Database.Tables(2).SetDataSource(rsItems)
        ''Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub
    Public Sub report_SupplierStatement(ByRef id As Integer)
        Dim rs As ADODB.Recordset
        Dim rsCompany As ADODB.Recordset
        Dim rsTransaction As ADODB.Recordset
        Dim lAddress As String
        Dim lNumber As String
        'Dim Report As New crySupplierStatement
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("crySupplierStatement.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))

        If IsDbNull(rs.Fields("Company_PhysicalAddress").Value) Then
        Else
            lAddress = Replace(rs.Fields("Company_PhysicalAddress").Value, vbCrLf, ", ")
            If Right(lAddress, 2) = ", " Then
                lAddress = Left(lAddress, Len(lAddress) - 2)
            End If
        End If


        Report.Database.Tables(1).SetDataSource(rs)
        Report.SetParameterValue("txtAddress", lAddress)
        lNumber = ""
        If rs.Fields("Company_Telephone").Value <> "" Then lNumber = lNumber & "Tel: " & rs.Fields("Company_Telephone").Value
        If rs.Fields("Company_Fax").Value <> "" Then
            If lNumber <> "" Then lNumber = lNumber & " / "
            lNumber = lNumber & "Fax: " & rs.Fields("Company_Fax").Value
        End If
        If rs.Fields("Company_Email").Value <> "" Then
            If lNumber <> "" Then lNumber = lNumber & " / "
            lNumber = lNumber & "Email: " & rs.Fields("Company_Email").Value
        End If
        Report.SetParameterValue("txtNumbers", lNumber)
        rsCompany = getRS("SELECT * FROM Supplier Where SupplierID = " & id)
        Report.Database.Tables(1).SetDataSource(rsCompany)
        rsTransaction = getRS("SELECT SupplierTransaction.SupplierTransaction_SupplierID, SupplierTransaction.SupplierTransaction_Date, SupplierTransaction.SupplierTransaction_Reference, TransactionType.TransactionType_Name, IIf([SupplierTransaction_Amount]<0,[SupplierTransaction_Amount],0) AS credit, IIf([SupplierTransaction_Amount]>=0,[SupplierTransaction_Amount],0) AS debit, SupplierTransaction.SupplierTransaction_Amount FROM SupplierTransaction INNER JOIN TransactionType ON SupplierTransaction.SupplierTransaction_TransactionTypeID = TransactionType.TransactionTypeID WHERE (((SupplierTransaction.SupplierTransaction_SupplierID)=" & id & "));")
        Report.Database.Tables(2).SetDataSource(rsTransaction)

        ''ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rsTransaction.BOF Or rsTransaction.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
            ReportNone.SetParameterValue("txtTitle", "Statement")
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        frmReportShow.Text = "Supplier Statement"
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()

    End Sub

    Public Sub report_StockTake(ByRef id As Integer, Optional ByRef MWH As Integer = 0)
        Dim sGroup As String
        If id Then
        Else
            Exit Sub
        End If
        If MWH = 0 Then frmStockTakeSnapshot.remoteSnapShot()
        System.Windows.Forms.Application.DoEvents()
        Dim rs As ADODB.Recordset
        Dim rsWH As ADODB.Recordset
        Dim ltype As Boolean
        Dim lStockQty As Boolean
        Dim bPrintBC_QK As Boolean
        'Dim Report As New cryStockTake
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryStockTake.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtDate", Format(rs.Fields("Company_StockTakeDate").Value, "dd mmm, yyyy hh:mm"))
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        ltype = rs.Fields("Company_StockTakeQuantity").Value
        lStockQty = rs.Fields("Company_StockTakeQuantityOnly").Value
        bPrintBC_QK = rs.Fields("Company_StockTakeBC").Value
        rs.Close()
        rs = getRS("SELECT StockGroup.StockGroupID, StockGroup.StockGroup_Name, Company.Company_StockTakeDate, Company.Company_StockTakeQuantity From Company, StockGroup WHERE (((StockGroup.StockGroupID)=" & id & "));")
        Report.SetParameterValue("txtTitle", "Stock Take Sheet For: " & rs.Fields("StockGroup_Name").Value)

        'Multi Warehouse change
        'If ltype Then
        '    If lStockQty Then
        '        Set rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;")
        '    Else
        '        'Set rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_Quantity) <> 0) And ((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) <> 0) And ((StockItem.StockItem_Discontinued) <> 0)) ORDER BY StockItem.StockItem_Name;")
        '        Set rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_Quantity) <> 0) And ((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;")
        '    End If
        '
        'Else
        '    If lStockQty Then
        '        Set rs = getRS("SELECT StockItem.StockItem_Name, Null AS StockTake_Quantity, StockItem.StockItem_QuickKey, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;")
        '    Else
        '        'Set rs = getRS("SELECT StockItem.StockItem_Name, Null AS StockTake_Quantity, StockItem.StockItem_QuickKey, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) <> 0) And ((StockItem.StockItem_Discontinued) <> 0) And ((StockTake.StockTake_Quantity) <> 0)) ORDER BY StockItem.StockItem_Name;")
        '        Set rs = getRS("SELECT StockItem.StockItem_Name, Null AS StockTake_Quantity, StockItem.StockItem_QuickKey, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0) And ((StockTake.StockTake_Quantity) <> 0)) ORDER BY StockItem.StockItem_Name;")
        '    End If
        'End If

        Dim lMWNo As Integer
        If MWH = 0 Then
            lMWNo = frmMWSelect.getMWNo
        Else
            lMWNo = MWH
        End If
        If lMWNo > 1 Then
            rsWH = getRS("SELECT * FROM Warehouse WHERE WarehouseID=" & lMWNo & ";")
            Report.SetParameterValue("txtWH", rsWH.Fields("Warehouse_Name"))
        End If

        If ltype Then
            'If lMWNo = 1 Then
            '    If lStockQty Then
            '        Set rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;")
            '    Else
            '        Set rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0) And ((StockTake.StockTake_Quantity) <> 0)) ORDER BY StockItem.StockItem_Name;")
            '    End If
            'Else
            If lStockQty Then
                If bPrintBC_QK Then
                    rs = getRS("SELECT StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM ((StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN Catalogue ON StockTake.StockTake_StockItemID = Catalogue.Catalogue_StockItemID Where (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) Or (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) ORDER BY StockItem.StockItem_Name;")
                Else
                    rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;")
                End If

            Else
                If bPrintBC_QK Then
                    sGroup = "SELECT StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity"
                    sGroup = sGroup & " FROM ((StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN Catalogue ON StockTake.StockTake_StockItemID = Catalogue.Catalogue_StockItemID Where (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) Or (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) Or (((StockTake.StockTake_Quantity) <> 0) And ((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) ORDER BY StockItem.StockItem_Name;"
                    rs = getRS(sGroup)
                Else
                    rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_Quantity) <> 0) And ((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;")
                End If
            End If
            'End If

        Else
            'If lMWNo = 1 Then
            '    sGroup = "GROUP BY StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity"
            '    If lStockQty Then
            '        Set rs = getRS("SELECT StockItem.StockItem_Name, Null AS StockTake_Quantity, StockItem.StockItem_QuickKey, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Discontinued) = 0)) " & sGroup & " ORDER BY StockItem.StockItem_Name;")
            '    Else
            '        Set rs = getRS("SELECT StockItem.StockItem_Name, Null AS StockTake_Quantity, StockItem.StockItem_QuickKey, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0) And ((StockTake.StockTake_Quantity) <> 0)) " & sGroup & " ORDER BY StockItem.StockItem_Name;")
            '    End If
            'Else
            If lStockQty Then
                If bPrintBC_QK Then
                    rs = getRS("SELECT StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Null AS StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM ((StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN Catalogue ON StockTake.StockTake_StockItemID = Catalogue.Catalogue_StockItemID Where (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Disabled) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) Or (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Discontinued) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) ORDER BY StockItem.StockItem_Name;")
                Else
                    rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, Null AS StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;")
                End If
            Else
                If bPrintBC_QK Then
                    sGroup = "SELECT StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Null AS StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity"
                    sGroup = sGroup & " FROM ((StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN Catalogue ON StockTake.StockTake_StockItemID = Catalogue.Catalogue_StockItemID Where (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) Or (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) Or (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0) And ((StockTake.StockTake_Quantity) <> 0) And ((Catalogue.Catalogue_Quantity) = 1)) ORDER BY StockItem.StockItem_Name;"
                    rs = getRS(sGroup)
                Else
                    rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, Null AS StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0) And ((StockTake.StockTake_Quantity) <> 0)) ORDER BY StockItem.StockItem_Name;")
                End If
            End If
            'End If
        End If
        'Multi Warehouse change

        ''ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.Database.Tables(1).SetDataSource(rs)
        Report.SetDataSource(rs)
        ''Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()

    End Sub

    Public Sub report_StockTakeDiff(ByRef id As Integer, Optional ByRef MWH As Integer = 0)
        Dim sGroup As String
        If id Then
        Else
            Exit Sub
        End If
        'frmStockTakeSnapshot.remoteSnapShot
        'DoEvents
        Dim rs As ADODB.Recordset
        Dim rsWH As ADODB.Recordset
        Dim ltype As Boolean
        Dim lStockQty As Boolean
        Dim bPrintBC_QK As Boolean
        'Dim Report As New cryStockTakeDiff
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtDate", Format(rs.Fields("Company_StockTakeDate").Value, "dd mmm, yyyy hh:mm"))
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        ltype = rs.Fields("Company_StockTakeQuantity").Value
        lStockQty = rs.Fields("Company_StockTakeQuantityOnly").Value
        bPrintBC_QK = rs.Fields("Company_StockTakeBC").Value
        rs.Close()
        rs = getRS("SELECT StockGroup.StockGroupID, StockGroup.StockGroup_Name, Company.Company_StockTakeDate, Company.Company_StockTakeQuantity From Company, StockGroup WHERE (((StockGroup.StockGroupID)=" & id & "));")
        Report.SetParameterValue("txtTitle", "Stock Take Difference Sheet For: " & rs.Fields("StockGroup_Name").Value)

        'Multi Warehouse change
        'If ltype Then
        '    If lStockQty Then
        '        Set rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;")
        '    Else
        '        'Set rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_Quantity) <> 0) And ((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) <> 0) And ((StockItem.StockItem_Discontinued) <> 0)) ORDER BY StockItem.StockItem_Name;")
        '        Set rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_Quantity) <> 0) And ((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;")
        '    End If
        '
        'Else
        '    If lStockQty Then
        '        Set rs = getRS("SELECT StockItem.StockItem_Name, Null AS StockTake_Quantity, StockItem.StockItem_QuickKey, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;")
        '    Else
        '        'Set rs = getRS("SELECT StockItem.StockItem_Name, Null AS StockTake_Quantity, StockItem.StockItem_QuickKey, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) <> 0) And ((StockItem.StockItem_Discontinued) <> 0) And ((StockTake.StockTake_Quantity) <> 0)) ORDER BY StockItem.StockItem_Name;")
        '        Set rs = getRS("SELECT StockItem.StockItem_Name, Null AS StockTake_Quantity, StockItem.StockItem_QuickKey, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_WarehouseID) = 2) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0) And ((StockTake.StockTake_Quantity) <> 0)) ORDER BY StockItem.StockItem_Name;")
        '    End If
        'End If

        Dim lMWNo As Integer
        If MWH = 0 Then
            lMWNo = frmMWSelect.getMWNo
        Else
            lMWNo = MWH
        End If
        If lMWNo > 1 Then
            rsWH = getRS("SELECT * FROM Warehouse WHERE WarehouseID=" & lMWNo & ";")
            'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtWH. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Report.SetParameterValue("txtWH", rsWH.Fields("Warehouse_Name"))
        End If

        'If ltype Then
        '    'If lMWNo = 1 Then
        '    '    If lStockQty Then
        '    '        Set rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;")
        '    '    Else
        '    '        Set rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0) And ((StockTake.StockTake_Quantity) <> 0)) ORDER BY StockItem.StockItem_Name;")
        '    '    End If
        '    'Else
        '        If lStockQty Then
        '            If bPrintBC_QK Then
        '                Set rs = getRS("SELECT StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity, StockTake_QuantityOrig FROM ((StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN Catalogue ON StockTake.StockTake_StockItemID = Catalogue.Catalogue_StockItemID Where (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) Or (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) ORDER BY StockItem.StockItem_Name;")
        '            Else
        '                Set rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity, StockTake_QuantityOrig FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_Quantity) > 0) And ((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;")
        '            End If
        '
        '        Else

        '+ - sign change
        Dim bSign As Boolean
        Dim rsSign As ADODB.Recordset
        rsSign = getRS("SELECT Company_ShrinkSign FROM Company;")
        If rsSign.RecordCount Then
            If rsSign.Fields("Company_ShrinkSign").Value Then bSign = True
        End If
        '+ - sign change
        'sql = "SELECT aStockItem.StockItem_Name, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS list, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actual, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse, CatalogueChannelLnk.CatalogueChannelLnk_Price"
        'sql = sql & " FROM (DayEndStockItemLnk LEFT JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) INNER JOIN CatalogueChannelLnk ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID Where (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0)) GROUP BY aStockItem.StockItem_Name, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price Having (((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse) = " & lMWNo & ") And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1)) ORDER BY aStockItem.StockItem_Name;"
        If bSign Then
            If bPrintBC_QK Then
                sGroup = "SELECT StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, (0 - StockTake.StockTake_Quantity), StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity, (0 - StockTake_QuantityOrig)"
                sGroup = sGroup & " FROM ((StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN Catalogue ON StockTake.StockTake_StockItemID = Catalogue.Catalogue_StockItemID"
                sGroup = sGroup & " Where (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockTake.StockTake_Quantity-StockTake.StockTake_QuantityOrig) <> 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) Or (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockTake.StockTake_Quantity-StockTake.StockTake_QuantityOrig) <> 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) Or (((StockTake.StockTake_Quantity) <> 0) And ((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockTake.StockTake_Quantity-StockTake.StockTake_QuantityOrig) <> 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) ORDER BY StockItem.StockItem_Name;"
                rs = getRS(sGroup)
            Else
                sGroup = "SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, (0 - StockTake.StockTake_Quantity), StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity, (0 - StockTake_QuantityOrig) FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID"
                sGroup = sGroup & " Where (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockTake.StockTake_Quantity-StockTake.StockTake_QuantityOrig) <> 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockTake.StockTake_Quantity-StockTake.StockTake_QuantityOrig) <> 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_Quantity) <> 0) And ((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockTake.StockTake_Quantity-StockTake.StockTake_QuantityOrig) <> 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;"
                rs = getRS(sGroup)
            End If
        Else
            If bPrintBC_QK Then
                sGroup = "SELECT StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity, StockTake_QuantityOrig"
                sGroup = sGroup & " FROM ((StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN Catalogue ON StockTake.StockTake_StockItemID = Catalogue.Catalogue_StockItemID"
                sGroup = sGroup & " Where (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockTake.StockTake_Quantity-StockTake.StockTake_QuantityOrig) <> 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) Or (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockTake.StockTake_Quantity-StockTake.StockTake_QuantityOrig) <> 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) Or (((StockTake.StockTake_Quantity) <> 0) And ((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockTake.StockTake_Quantity-StockTake.StockTake_QuantityOrig) <> 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) ORDER BY StockItem.StockItem_Name;"
                rs = getRS(sGroup)
            Else
                sGroup = "SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity, StockTake_QuantityOrig FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID"
                sGroup = sGroup & " Where (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockTake.StockTake_Quantity-StockTake.StockTake_QuantityOrig) <> 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockTake.StockTake_Quantity-StockTake.StockTake_QuantityOrig) <> 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_Quantity) <> 0) And ((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockTake.StockTake_Quantity-StockTake.StockTake_QuantityOrig) <> 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;"
                rs = getRS(sGroup)
            End If
        End If
        '        End If
        '    'End If
        '
        'Else
        '    'If lMWNo = 1 Then
        '    '    sGroup = "GROUP BY StockItem.StockItem_Name, StockItem.StockItem_QuickKey, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity"
        '    '    If lStockQty Then
        '    '        Set rs = getRS("SELECT StockItem.StockItem_Name, Null AS StockTake_Quantity, StockItem.StockItem_QuickKey, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Discontinued) = 0)) " & sGroup & " ORDER BY StockItem.StockItem_Name;")
        '    '    Else
        '    '        Set rs = getRS("SELECT StockItem.StockItem_Name, Null AS StockTake_Quantity, StockItem.StockItem_QuickKey, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_WarehouseID) > 0) And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0) And ((StockTake.StockTake_Quantity) <> 0)) " & sGroup & " ORDER BY StockItem.StockItem_Name;")
        '    '    End If
        '    'Else
        '        If lStockQty Then
        '            If bPrintBC_QK Then
        '                Set rs = getRS("SELECT StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Null AS StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity, StockTake_QuantityOrig FROM ((StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN Catalogue ON StockTake.StockTake_StockItemID = Catalogue.Catalogue_StockItemID Where (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Disabled) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) Or (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Discontinued) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) ORDER BY StockItem.StockItem_Name;")
        '            Else
        '                Set rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, Null AS StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity, StockTake_QuantityOrig FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockTake.StockTake_Quantity) > 0) And ((StockItem.StockItem_Discontinued) = 0)) ORDER BY StockItem.StockItem_Name;")
        '            End If
        '        Else
        '            If bPrintBC_QK Then
        '                sGroup = "SELECT StockItem.StockItem_Name, Catalogue.Catalogue_Barcode, Null AS StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity, StockTake_QuantityOrig"
        '                sGroup = sGroup & " FROM ((StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) INNER JOIN Catalogue ON StockTake.StockTake_StockItemID = Catalogue.Catalogue_StockItemID Where (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) Or (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0) And ((Catalogue.Catalogue_Quantity) = 1)) Or (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0) And ((StockTake.StockTake_Quantity) <> 0) And ((Catalogue.Catalogue_Quantity) = 1)) ORDER BY StockItem.StockItem_Name;"
        '                Set rs = getRS(sGroup)
        '            Else
        '                Set rs = getRS("SELECT StockItem.StockItem_Name, StockItem.StockItem_QuickKey, Null AS StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity, StockTake_QuantityOrig FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0)) Or (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Discontinued) = 0)) Or (((StockTake.StockTake_WarehouseID) = " & lMWNo & ") And ((StockGroup.StockGroupID) = " & id & ") And ((StockItem.StockItem_Disabled) = 0) And ((StockItem.StockItem_Discontinued) = 0) And ((StockTake.StockTake_Quantity) <> 0)) ORDER BY StockItem.StockItem_Name;")
        '            End If
        '        End If
        '    'End If
        'End If
        'Multi Warehouse change

        ''ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.Database.Tables(1).SetDataSource(rs)
        Report.SetDataSource(rs)
        ''Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()

    End Sub

    Public Sub report_StockTakeNotes()
        Dim rs As ADODB.Recordset
        Dim rsWH As ADODB.Recordset
        'Dim Report As New cryStockTakeNotes
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryStockTakeNotes.rpt")
        Dim lStockGroupID As Integer

        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        rs.Close()

        rsWH = getRS("SELECT * FROM Warehouse WHERE WarehouseID=2;")
        Report.SetParameterValue("txtWH", rsWH.Fields("Warehouse_Name"))
        rsWH.Close()

        'gSection = 0
        lStockGroupID = frmStockGroupListNotes.getItem
        rs = getRS("SELECT StockGroup.StockGroupID, StockGroup.StockGroup_Name FROM StockGroup WHERE (((StockGroup.StockGroupID)=" & lStockGroupID & "));")
        Report.SetParameterValue("txtTitle", "Stock Take Notes For : " & rs.Fields("StockGroup_Name").Value)
        rs.Close()

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT aStockTakeDetail.StockTake_StockItemID, aStockItem1.StockItem_Name, aStockTakeDetail.StockTake_WarehouseID, aStockTakeDetail.StockTake_Quantity, aStockTakeDetail.StockTake_Adjustment, aStockTakeDetail.StockTake_DayEndID, aStockTakeDetail.StockTake_Note, aStockTakeDetail.StockTake_DateTime, aDayEnd1.DayEnd_Date FROM ((aStockItem1 INNER JOIN aStockTakeDetail ON aStockItem1.StockItemID = aStockTakeDetail.StockTake_StockItemID) INNER JOIN aStockGroup1 ON aStockItem1.StockItem_StockGroupID = aStockGroup1.StockGroupID) INNER JOIN aDayEnd1 ON aStockTakeDetail.StockTake_DayEndID = aDayEnd1.DayEndID Where (((aStockGroup1.StockGroupID) = " & lStockGroupID & ")) ORDER BY aStockItem1.StockItem_Name, aDayEnd1.DayEnd_Date;")
        ''ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.Database.Tables(1).SetDataSource(rs)
        ''Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub


    Public Sub report_StockNegative()
        Dim rs As ADODB.Recordset
        Dim ltype As Boolean
        Dim lStockQty As Boolean
        'Dim Report As New cryStockNegative
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryStockNegative.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtDate", Format(rs.Fields("Company_StockTakeDate").Value, "dd mmm, yyyy hh:mm"))
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()

        rs = getRS("SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity, StockGroup.StockGroup_Name, StockItem.StockItem_Name FROM (StockItem INNER JOIN WarehouseStockItemLnk ON StockItem.StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) = 2) And ((WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) < 0)) ORDER BY StockGroup.StockGroup_Name, StockItem.StockItem_Name;")
        ''ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.Database.Tables(1).SetDataSource(rs)
        Report.SetDataSource(rs)
        ''Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()

    End Sub
    Public Sub report_StockQuantityData(ByRef id As Integer)
        If id Then
        Else
            Exit Sub
        End If
        Dim rs As ADODB.Recordset
        Dim ltype As Boolean
        'Dim Report As New cryStockQuantity
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryStockQuantity.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()
        rs = getRS("SELECT StockGroup.StockGroupID, StockGroup.StockGroup_Name, Company.Company_StockTakeDate, Company.Company_StockTakeQuantity From Company, StockGroup WHERE (((StockGroup.StockGroupID)=" & id & "));")
        Report.SetParameterValue("txtTitle", "Current Stock Holding For: " & rs.Fields("StockGroup_Name").Value)

        Dim lMWNo As Integer
        lMWNo = frmMWSelect.getMWNo
        If lMWNo > 1 Then
            'Set rsWH = getRS("SELECT * FROM Warehouse WHERE WarehouseID=" & lMWNo & ";")
            'Report.txtWH.SetText rsWH("Warehouse_Name")
        End If

        'Multi Warehouse change         Set rs = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_Quantity, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS StockTake_Quantity FROM (Warehouse INNER JOIN WarehouseStockItemLnk ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID Where (((StockItem.StockItem_StockGroupID) = " & id & ") And ((Warehouse.WarehouseID) = 2)) GROUP BY StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_Quantity, Warehouse.Warehouse_Saleable Having (((Warehouse.Warehouse_Saleable) <> 0)) ORDER BY StockItem.StockItem_Name;")
        rs = getRS("SELECT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_Quantity, Sum(WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity) AS StockTake_Quantity FROM (Warehouse INNER JOIN WarehouseStockItemLnk ON Warehouse.WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) INNER JOIN StockItem ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID Where (((StockItem.StockItem_StockGroupID) = " & id & ") And ((Warehouse.WarehouseID) = " & lMWNo & ")) GROUP BY StockItem.StockItemID, StockItem.StockItem_Name, StockItem.StockItem_Quantity, Warehouse.Warehouse_Saleable Having (((Warehouse.Warehouse_Saleable) <> 0)) ORDER BY StockItem.StockItem_Name;")
        ''ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.Database.Tables(1).SetDataSource(rs)
        Report.SetDataSource(rs)
        ''Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()

    End Sub
    Public Sub report_PriceSets()
        '    Dim rs As Recordset
        '    Dim RSitem As Recordset
        '    Dim ltype As Boolean
        '    Dim Report As New cryPriceSets
        '    Screen.MousePointer = vbHourglass
        '    Set rs = getRS("SELECT * FROM Company")
        '    Report.txtCompanyName.SetText rs("Company_Name")
        '    rs.Close
        '    Set rs = getRS("SELECT PriceSet.*, StockItem.*, Shrink.Shrink_Name, Deposit.Deposit_Name, Vat.Vat_Amount, PricingGroup.PricingGroup_Name FROM ((((PriceSet INNER JOIN StockItem ON PriceSet.PriceSet_StockItemID = StockItem.StockItemID) INNER JOIN Shrink ON StockItem.StockItem_ShrinkID = Shrink.ShrinkID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID ORDER BY PriceSet.PriceSet_Name;")
        '    If rs.BOF Or rs.EOF Then
        '        'ReportNone.Load("cryNoRecords.rpt")
        '        ReportNone.txtCompanyName.SetText Report.txtCompanyName.Text
        '        ReportNone.txtTitle.SetText Report.txtTitle.Text
        '        frmReportShow.Caption = ReportNone.txtTitle.Text
        '        frmReportShow.CRViewer1.ReportSource = ReportNone
        '        Set frmReportShow.mReport = ReportNone: frmReportShow.sMode = "0"
        '        frmReportShow.CRViewer1.ViewReport
        '        Screen.MousePointer = vbDefault
        '        frmReportShow.show 1
        '        Exit Sub
        '    End If
        '    Set RSitem = getRS("SELECT StockItem.* From StockItem ORDER BY StockItem.StockItem_Name;")
        '    Report.Database.Tables(1).SetDataSource rs, 3
        '   Report.Database.Tables(2).SetDataSource RSitem, 3
        '   'Report.VerifyOnEveryPrint = True
        '   frmReportShow.Caption = Report.txtTitle.Text
        '    frmReportShow.CRViewer1.ReportSource = Report
        '    Set frmReportShow.mReport = Report: frmReportShow.sMode = "0"
        '    frmReportShow.CRViewer1.ViewReport
        '    Screen.MousePointer = vbDefault
        '    frmReportShow.show 1
        Dim rs As ADODB.Recordset
        Dim RSitem As ADODB.Recordset
        Dim ltype As Boolean
        'Dim Report As New cryPriceSets
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryPriceSets.rpt")
        Dim gID As Integer

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()

        rs = getRS("SELECT PriceSet.*, StockItem.*, Shrink.Shrink_Name, Deposit.Deposit_Name, Vat.Vat_Amount, PricingGroup.PricingGroup_Name FROM ((((PriceSet INNER JOIN StockItem ON PriceSet.PriceSet_StockItemID = StockItem.StockItemID) INNER JOIN Shrink ON StockItem.StockItem_ShrinkID = Shrink.ShrinkID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID ORDER BY PriceSet.PriceSet_Name;")
        'Set rs = getRS("SELECT PriceSet.*, StockItem.*, Shrink.Shrink_Name, Deposit.Deposit_Name, Vat.Vat_Amount, PricingGroup.PricingGroup_Name, PriceSet.PriceSet_Name FROM ((((PriceSet INNER JOIN StockItem ON PriceSet.PriceSet_StockItemID = StockItem.StockItemID) INNER JOIN Shrink ON StockItem.StockItem_ShrinkID = Shrink.ShrinkID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID Where (((PriceSet.PriceSetID) = " & gID & "))ORDER BY PriceSet.PriceSet_Name, PriceSet.PriceSetID;")

        ''ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If
        RSitem = getRS("SELECT StockItem.* From StockItem ORDER BY StockItem.StockItem_Name;")
        Report.Database.Tables(1).SetDataSource(rs)
        Report.Database.Tables(2).SetDataSource(RSitem)
        ''Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
        'End If
    End Sub

    Public Sub report_SelectPriceSets()
        Dim rs As ADODB.Recordset
        Dim RSitem As ADODB.Recordset
        Dim ltype As Boolean
        'Dim Report As New cryPriceSets
        Dim gID As Integer
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryPriceSets.rpt")
        ReportNone.Load("cryNoRecords.rpt")
        gID = holdid
        ''ReportNone.Load("cryNoRecords.rpt")
        If gID Then
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            rs = getRS("SELECT * FROM Company")
            Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
            rs.Close()

            'Set rs = getRS("SELECT PriceSet.*, StockItem.*, Shrink.Shrink_Name, Deposit.Deposit_Name, Vat.Vat_Amount, PricingGroup.PricingGroup_Name FROM ((((PriceSet INNER JOIN StockItem ON PriceSet.PriceSet_StockItemID = StockItem.StockItemID) INNER JOIN Shrink ON StockItem.StockItem_ShrinkID = Shrink.ShrinkID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID ORDER BY PriceSet.PriceSet_Name;")
            rs = getRS("SELECT PriceSet.*, StockItem.*, Shrink.Shrink_Name, Deposit.Deposit_Name, Vat.Vat_Amount, PricingGroup.PricingGroup_Name, PriceSet.PriceSet_Name FROM ((((PriceSet INNER JOIN StockItem ON PriceSet.PriceSet_StockItemID = StockItem.StockItemID) INNER JOIN Shrink ON StockItem.StockItem_ShrinkID = Shrink.ShrinkID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID Where (((PriceSet.PriceSetID) = " & gID & "))ORDER BY PriceSet.PriceSet_Name, PriceSet.PriceSetID;")

            If rs.BOF Or rs.EOF Then
                ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
                ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
                frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
                frmReportShow.CRViewer1.ReportSource = ReportNone
                frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
                frmReportShow.CRViewer1.Refresh()
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                frmReportShow.ShowDialog()
                Exit Sub
            End If
            RSitem = getRS("SELECT StockItem.* From StockItem ORDER BY StockItem.StockItem_Name;")
            Report.Database.Tables(1).SetDataSource(rs)
            Report.Database.Tables(2).SetDataSource(RSitem)
            ''Report.VerifyOnEveryPrint = True
            frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = Report
            frmReportShow.mReport = Report : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
        End If
    End Sub

    Public Sub report_Promotion()
        Dim rs As ADODB.Recordset
        Dim RSitem As ADODB.Recordset
        Dim ltype As Boolean
        'Dim Report As New cryPromotion
        ''ReportNone.Load("cryNoRecords.rpt")
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryPromotion.rpt")
        ReportNone.Load("cryNoRecords.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()
        rs = getRS("SELECT Promotion.* From Promotion ORDER BY Promotion.Promotion_EndDate DESC , Promotion.Promotion_Name;")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If
        RSitem = getRS("SELECT PromotionItem.*, StockItem.StockItem_Name FROM PromotionItem INNER JOIN StockItem ON PromotionItem.PromotionItem_StockItemID = StockItem.StockItemID ORDER BY StockItem.StockItem_Name, PromotionItem.PromotionItem_Quantity;")
        If RSitem.BOF Or RSitem.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If
        Report.Database.Tables(1).SetDataSource(rs)
        Report.Database.Tables(2).SetDataSource(RSitem)
        ''Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()

    End Sub

    Public Sub report_PromotionGRV()
        Dim rs As ADODB.Recordset
        Dim RSitem As ADODB.Recordset
        Dim ltype As Boolean
        'Dim Report As New cryPromotion
        ''ReportNone.Load("cryNoRecords.rpt")
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryPromotion.rpt")
        ReportNone.Load("cryNoRecords.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()
        rs = getRS("SELECT GRVPromotion.* From GRVPromotion ORDER BY GRVPromotion.Promotion_EndDate DESC , GRVPromotion.Promotion_Name;")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If
        RSitem = getRS("SELECT GRVPromotionItem.*, StockItem.StockItem_Name FROM GRVPromotionItem INNER JOIN StockItem ON GRVPromotionItem.PromotionItem_StockItemID = StockItem.StockItemID ORDER BY StockItem.StockItem_Name, GRVPromotionItem.PromotionItem_Quantity;")
        If RSitem.BOF Or RSitem.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If
        Report.Database.Tables(1).SetDataSource(rs)
        Report.Database.Tables(2).SetDataSource(RSitem)
        ''Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Public Sub report_DepositTake()

        frmStockTakeSnapshot.remoteSnapShot()
        System.Windows.Forms.Application.DoEvents()

        Dim rs As ADODB.Recordset
        Dim ltype As Boolean
        'Dim Report As New cryDepositTake
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryDepositTake.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtDate", Format(rs.Fields("Company_StockTakeDate").Value, "dd mmm, yyyy hh:mm"))
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        ltype = rs.Fields("Company_StockTakeQuantity").Value
        rs.Close()
        If ltype Then
            'Set rs = getRS("SELECT Deposit.Deposit_Name, IIf([StockTakeDeposit_DepositTypeID]=0,'Bottle','Crate') AS depositType, StockTakeDeposit.StockTakeDeposit_Quantity, StockTakeDeposit.StockTakeDeposit_WarehouseID, StockTakeDeposit.StockTakeDeposit_DepositID, StockTakeDeposit.StockTakeDeposit_DepositTypeID FROM Deposit INNER JOIN StockTakeDeposit ON Deposit.DepositID = StockTakeDeposit.StockTakeDeposit_DepositID Where (((StockTakeDeposit.StockTakeDeposit_WarehouseID) = 2)) ORDER BY Deposit.Deposit_Name, StockTakeDeposit.StockTakeDeposit_DepositTypeID;")
            rs = getRS("SELECT Deposit.Deposit_Name, IIf([StockTakeDeposit_DepositTypeID]=0,'Bottle','Crate') AS depositType, StockTakeDeposit.StockTakeDeposit_Quantity, StockTakeDeposit.StockTakeDeposit_WarehouseID, StockTakeDeposit.StockTakeDeposit_DepositID, StockTakeDeposit.StockTakeDeposit_DepositTypeID FROM Deposit INNER JOIN StockTakeDeposit ON Deposit.DepositID = StockTakeDeposit.StockTakeDeposit_DepositID Where (((StockTakeDeposit.StockTakeDeposit_WarehouseID) = 2) AND ((Deposit.Deposit_Disabled)=False)) ORDER BY Deposit.Deposit_Name, StockTakeDeposit.StockTakeDeposit_DepositTypeID;")
        Else
            'Set rs = getRS("SELECT Deposit.Deposit_Name, IIf([StockTakeDeposit_DepositTypeID]=0,'Bottle','Crate') AS depositType, null AS StockTakeDeposit_Quantity, StockTakeDeposit.StockTakeDeposit_WarehouseID, StockTakeDeposit.StockTakeDeposit_DepositID, StockTakeDeposit.StockTakeDeposit_DepositTypeID FROM Deposit INNER JOIN StockTakeDeposit ON Deposit.DepositID = StockTakeDeposit.StockTakeDeposit_DepositID Where (((StockTakeDeposit.StockTakeDeposit_WarehouseID) = 2)) ORDER BY Deposit.Deposit_Name, StockTakeDeposit.StockTakeDeposit_DepositTypeID;")
            rs = getRS("SELECT Deposit.Deposit_Name, IIf([StockTakeDeposit_DepositTypeID]=0,'Bottle','Crate') AS depositType, null AS StockTakeDeposit_Quantity, StockTakeDeposit.StockTakeDeposit_WarehouseID, StockTakeDeposit.StockTakeDeposit_DepositID, StockTakeDeposit.StockTakeDeposit_DepositTypeID FROM Deposit INNER JOIN StockTakeDeposit ON Deposit.DepositID = StockTakeDeposit.StockTakeDeposit_DepositID Where (((StockTakeDeposit.StockTakeDeposit_WarehouseID) = 2) AND ((Deposit.Deposit_Disabled)=False)) ORDER BY Deposit.Deposit_Name, StockTakeDeposit.StockTakeDeposit_DepositTypeID;")
        End If
        ''ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.SetDataSource(rs)
        frmReportShow.Text = "Deposit Stock Take Sheets"
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Public Sub report_PricingMatrix(ByRef grpID As Integer)
        'Public Sub report_PricingMatrix()
        Dim rs As ADODB.Recordset
        Dim ltype As Boolean
        Dim lID As Integer
        Dim sql As String
        'Dim Report As New cryPricingMatrix
        'lID = frmPricingGroupList.getItem
        lID = grpID 'frmPricingGroupList.getItem
        ''ReportNone.Load("cryNoRecords.rpt")
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryPricingMatrix.rpt")
        ReportNone.Load("cryNoRecords.rpt")
        If lID Then
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            rs = getRS("SELECT * FROM Company")
            Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
            rs.Close()
            sql = "SELECT theJoin.*, PricingGroupChannelLnk.* FROM (SELECT DISTINCT PricingGroup.PricingGroupID, PricingGroup.PricingGroup_Name, PackSize.PackSizeID, PackSize.PackSize_Name, ShrinkItem.ShrinkItem_Quantity, Channel.ChannelID, Channel.Channel_Name, Channel.Channel_Code FROM Channel, ShrinkItem INNER JOIN ((StockItem INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN PackSize ON StockItem.StockItem_PackSizeID = PackSize.PackSizeID) ON ShrinkItem.ShrinkItem_ShrinkID = StockItem.StockItem_ShrinkID "
            sql = sql & "Where ((Channel.ChannelID <> 9) AND (PricingGroup.PricingGroupID = " & lID & ")) "
            sql = sql & "ORDER BY PricingGroup.PricingGroup_Name, PackSize.PackSize_Name, ShrinkItem.ShrinkItem_Quantity) AS theJoin LEFT JOIN PricingGroupChannelLnk ON (theJoin.ChannelID = PricingGroupChannelLnk.PricingGroupChannelLnk_ChannelID) AND (theJoin.ShrinkItem_Quantity = PricingGroupChannelLnk.PricingGroupChannelLnk_Quantity) AND (theJoin.PackSizeID = PricingGroupChannelLnk.PricingGroupChannelLnk_PackSizeID) AND (theJoin.PricingGroupID = PricingGroupChannelLnk.PricingGroupChannelLnk_PricingGroupID) ORDER BY theJoin.PricingGroupID, theJoin.PackSizeID, theJoin.ShrinkItem_Quantity, theJoin.ChannelID;"

            rs = getRS(sql)
            If rs.BOF Or rs.EOF Then
                ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
                ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
                frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
                frmReportShow.CRViewer1.ReportSource = ReportNone
                frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
                frmReportShow.CRViewer1.Refresh()
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                frmReportShow.ShowDialog()
                Exit Sub
            End If
            Report.SetDataSource(rs)
            Report.Database.Tables(1).SetDataSource(rs)
            ''Report.VerifyOnEveryPrint = True
            frmReportShow.CRViewer1.ReportSource = Report
            frmReportShow.mReport = Report : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
        End If
    End Sub


    Public Sub report_PricingMatrixNew(ByRef grpID As Integer)
        'Public Sub report_PricingMatrix()
        Dim rs As ADODB.Recordset
        Dim ltype As Boolean
        Dim lID As Integer
        Dim sql As String
        'Dim Report As New cryPricingMatrixNew
        'lID = frmPricingGroupList.getItem
        lID = grpID 'frmPricingGroupList.getItem
        ''ReportNone.Load("cryNoRecords.rpt")
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryPricingMatrixNew.rpt")
        ReportNone.Load("cryNoRecords.rpt")
        If lID Then
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            rs = getRS("SELECT * FROM Company")
            Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
            rs.Close()
            'sql = "SELECT theJoin.*, PricingGroupChannelLnk.* FROM (SELECT DISTINCT PricingGroup.PricingGroupID, PricingGroup.PricingGroup_Name, PackSize.PackSizeID, PackSize.PackSize_Name, ShrinkItem.ShrinkItem_Quantity, Channel.ChannelID, Channel.Channel_Name, Channel.Channel_Code FROM Channel, ShrinkItem INNER JOIN ((StockItem INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN PackSize ON StockItem.StockItem_PackSizeID = PackSize.PackSizeID) ON ShrinkItem.ShrinkItem_ShrinkID = StockItem.StockItem_ShrinkID "
            'sql = sql & "Where ((Channel.ChannelID <> 9) AND (PricingGroup.PricingGroupID = " & lID & ")) "
            'sql = sql & "ORDER BY PricingGroup.PricingGroup_Name, PackSize.PackSize_Name, ShrinkItem.ShrinkItem_Quantity) AS theJoin LEFT JOIN PricingGroupChannelLnk ON (theJoin.ChannelID = PricingGroupChannelLnk.PricingGroupChannelLnk_ChannelID) AND (theJoin.ShrinkItem_Quantity = PricingGroupChannelLnk.PricingGroupChannelLnk_Quantity) AND (theJoin.PackSizeID = PricingGroupChannelLnk.PricingGroupChannelLnk_PackSizeID) AND (theJoin.PricingGroupID = PricingGroupChannelLnk.PricingGroupChannelLnk_PricingGroupID) ORDER BY theJoin.PricingGroupID, theJoin.PackSizeID, theJoin.ShrinkItem_Quantity, theJoin.ChannelID;"
            sql = "SELECT theJoin.*, PricingGroupChannelLnk.* FROM (SELECT DISTINCT PricingGroup.PricingGroupID, PricingGroup.PricingGroup_Name, Shrink.ShrinkID, Shrink.Shrink_Name, ShrinkItem.ShrinkItem_Quantity, Channel.ChannelID, Channel.Channel_Name, Channel.Channel_Code FROM Channel, ShrinkItem INNER JOIN ((StockItem INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) INNER JOIN Shrink ON StockItem.StockItem_ShrinkID = Shrink.ShrinkID) ON ShrinkItem.ShrinkItem_ShrinkID = StockItem.StockItem_ShrinkID "
            sql = sql & "Where ((Channel.ChannelID <> 9) AND (PricingGroup.PricingGroupID = " & lID & ")) "
            sql = sql & "ORDER BY PricingGroup.PricingGroup_Name, Shrink.Shrink_Name, ShrinkItem.ShrinkItem_Quantity) AS theJoin LEFT JOIN PricingGroupChannelLnk ON (theJoin.ChannelID = PricingGroupChannelLnk.PricingGroupChannelLnk_ChannelID) AND (theJoin.ShrinkItem_Quantity = PricingGroupChannelLnk.PricingGroupChannelLnk_Quantity) AND (theJoin.PricingGroupID = PricingGroupChannelLnk.PricingGroupChannelLnk_PricingGroupID) ORDER BY theJoin.PricingGroupID, theJoin.ShrinkID, theJoin.ShrinkItem_Quantity, theJoin.ChannelID;"

            rs = getRS(sql)
            If rs.BOF Or rs.EOF Then
                ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
                ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
                frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
                frmReportShow.CRViewer1.ReportSource = ReportNone
                frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
                frmReportShow.CRViewer1.Refresh()
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                frmReportShow.ShowDialog()
                Exit Sub
            End If
            Report.SetDataSource(rs)
            Report.Database.Tables(1).SetDataSource(rs)
            ''Report.VerifyOnEveryPrint = True
            frmReportShow.CRViewer1.ReportSource = Report
            frmReportShow.mReport = Report : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
        End If
    End Sub

    Public Sub report_PricingGroup()
        Dim rs As ADODB.Recordset
        Dim ltype As Boolean
        'Dim Report As New cryPricingGroup
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryPricingGroup.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName.", rs.Fields("Company_Name"))
        rs.Close()

        rs = getRS("SELECT * FROM Channel WHERE ChannelID <> 9 ORDER BY ChannelID")
        Do Until rs.EOF
            Select Case rs.Fields("ChannelID").Value
                Case 1
                    Report.SetParameterValue("txtChannel1", rs.Fields("Channel_Code"))
                Case 2
                    Report.SetParameterValue("txtChannel2", rs.Fields("Channel_Code"))
                Case 3
                    Report.SetParameterValue("txtChannel3", rs.Fields("Channel_Code"))
                Case 4
                    Report.SetParameterValue("txtChannel4", rs.Fields("Channel_Code"))
                Case 5
                    Report.SetParameterValue("txtChannel5", rs.Fields("Channel_Code"))
                Case 6
                    Report.SetParameterValue("txtChannel6", rs.Fields("Channel_Code"))
                Case 7
                    Report.SetParameterValue("txtChannel7", rs.Fields("Channel_Code"))
                Case 8
                    Report.SetParameterValue("txtChannel8", rs.Fields("Channel_Code"))
            End Select
            rs.moveNext()
        Loop

        rs.Close()
        rs = getRS("SELECT * From PricingGroup ORDER BY PricingGroup_Name")
        ''ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.SetDataSource(rs)
        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()

    End Sub

    Public Sub report_Sets()
        Dim sql As String
        Dim rs As ADODB.Recordset
        Dim RSitem As ADODB.Recordset
        Dim ltype As Boolean
        'Dim Report As New crySets
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("crySets.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()

        rs = getRS("SELECT * FROM Channel WHERE ChannelID <> 9 ORDER BY ChannelID")
        Do Until rs.EOF
            Select Case rs.Fields("ChannelID").Value
                Case 1
                    Report.SetParameterValue("txtChannel1", rs.Fields("Channel_Code"))
                Case 2
                    Report.SetParameterValue("txtChannel2", rs.Fields("Channel_Code"))
                Case 3
                    Report.SetParameterValue("txtChannel3", rs.Fields("Channel_Code"))
                Case 4
                    Report.SetParameterValue("txtChannel4", rs.Fields("Channel_Code"))
                Case 5
                    Report.SetParameterValue("txtChannel5", rs.Fields("Channel_Code"))
                Case 6
                    Report.SetParameterValue("txtChannel6", rs.Fields("Channel_Code"))
                Case 7
                    Report.SetParameterValue("txtChannel7", rs.Fields("Channel_Code"))
                Case 8
                    Report.SetParameterValue("txtChannel8", rs.Fields("Channel_Code"))
            End Select
            rs.moveNext()
        Loop

        rs.Close()
        sql = "SELECT Set.*, Deposit.Deposit_Name FROM Deposit INNER JOIN [Set] ON Deposit.DepositID = Set.Set_DepositID;"
        rs = getRS(sql)
        ''ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If
        RSitem = getRS("SELECT SetItem.*, StockItem.* FROM StockItem INNER JOIN SetItem ON StockItem.StockItemID = SetItem.SetItem_StockItemID;")
        Report.Database.Tables(1).SetDataSource(rs)
        Report.Database.Tables(2).SetDataSource(RSitem)
        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()

    End Sub
    Public Sub report_StockItemPropped()
        Dim sql As String
        Dim rs As ADODB.Recordset
        Dim ltype As Boolean
        'Dim Report As New cryPricingPropped
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryPricingPropped.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()

        rs = getRS("SELECT * FROM Channel WHERE ChannelID <> 9 ORDER BY ChannelID")
        Do Until rs.EOF
            Select Case rs.Fields("ChannelID").Value
                Case 1
                    Report.SetParameterValue("txtChannel1", rs.Fields("Channel_Code"))
                Case 2
                    Report.SetParameterValue("txtChannel2", rs.Fields("Channel_Code"))
                Case 3
                    Report.SetParameterValue("txtChannel3", rs.Fields("Channel_Code"))
                Case 4
                    Report.SetParameterValue("txtChannel4", rs.Fields("Channel_Code"))
                Case 5
                    Report.SetParameterValue("txtChannel5", rs.Fields("Channel_Code"))
                Case 6
                    Report.SetParameterValue("txtChannel6", rs.Fields("Channel_Code"))
                Case 7
                    Report.SetParameterValue("txtChannel7", rs.Fields("Channel_Code"))
                Case 8
                    Report.SetParameterValue("txtChannel8", rs.Fields("Channel_Code"))
            End Select
            rs.moveNext()
        Loop

        rs.Close()
        sql = "TRANSFORM Sum(DISPLAY_PricingProp.PropChannelLnk_Markup) AS SumOfPropChannelLnk_Markup SELECT DISPLAY_PricingProp.StockItem_Name, DISPLAY_PricingProp.ShrinkItem_Quantity, Sum(DISPLAY_PricingProp.PropChannelLnk_Markup) AS [Total Of PropChannelLnk_Markup] FROM (SELECT DISTINCT TOP 100 PERCENT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.ShrinkItem_Quantity, StockItem.ChannelID, PropChannelLnk.PropChannelLnk_Markup FROM ([SELECT TOP 100 PERCENT StockItem.StockItemID, StockItem.StockItem_Name, Channel.ChannelID, ShrinkItem.ShrinkItem_Quantity FROM StockItem INNER JOIN ShrinkItem ON StockItem.StockItem_ShrinkID = ShrinkItem.ShrinkItem_ShrinkID ,Channel "
        sql = sql & " WHERE (Channel.ChannelID <> 9)]. AS StockItem LEFT JOIN PropChannelLnk ON (StockItem.ShrinkItem_Quantity = PropChannelLnk.PropChannelLnk_Quantity) AND (StockItem.ChannelID = PropChannelLnk.PropChannelLnk_ChannelID) AND (StockItem.StockItemID = PropChannelLnk.PropChannelLnk_StockItemID)) INNER JOIN PropChannelLnk AS PropChannelLnk_1 ON (PropChannelLnk_1.PropChannelLnk_Quantity = StockItem.ShrinkItem_Quantity) AND (StockItem.StockItemID = PropChannelLnk_1.PropChannelLnk_StockItemID) ORDER BY StockItem.StockItem_Name, StockItem.ShrinkItem_Quantity, StockItem.ChannelID) DISPLAY_PricingProp GROUP BY DISPLAY_PricingProp.StockItem_Name, DISPLAY_PricingProp.ShrinkItem_Quantity PIVOT DISPLAY_PricingProp.ChannelID;"

        rs = getRS(sql)
        ''ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If
        Report.SetDataSource(rs)
        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
       frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Public Sub report_StockItemOverride()
        Dim sql As String
        Dim rs As ADODB.Recordset
        Dim ltype As Boolean
        'Dim Report As New cryPricingOverrideRpt
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryPricingOverrideRpt.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()

        rs = getRS("SELECT * FROM Channel WHERE ChannelID <> 9 ORDER BY ChannelID")
        Do Until rs.EOF
            Select Case rs.Fields("ChannelID").Value
                Case 1
                    Report.SetParameterValue("txtChannel1", rs.Fields("Channel_Code"))
                Case 2
                    Report.SetParameterValue("txtChannel2", rs.Fields("Channel_Code"))
                Case 3
                    Report.SetParameterValue("txtChannel3", rs.Fields("Channel_Code"))
                Case 4
                    Report.SetParameterValue("txtChannel4", rs.Fields("Channel_Code"))
                Case 5
                    Report.SetParameterValue("txtChannel5", rs.Fields("Channel_Code"))
                Case 6
                    Report.SetParameterValue("txtChannel6", rs.Fields("Channel_Code"))
                Case 7
                    Report.SetParameterValue("txtChannel7", rs.Fields("Channel_Code"))
                Case 8
                    Report.SetParameterValue("txtChannel8", rs.Fields("Channel_Code"))
            End Select
            rs.moveNext()
        Loop

        rs.Close()
        sql = "TRANSFORM Sum(DISPLAY_PricingOverride.PriceChannelLnk_Price) AS SumOfPriceChannelLnk_Price SELECT DISPLAY_PricingOverride.StockItem_Name, DISPLAY_PricingOverride.ShrinkItem_Quantity, Sum(DISPLAY_PricingOverride.PriceChannelLnk_Price) AS [Total Of PriceChannelLnk_Price] FROM (SELECT DISTINCT TOP 100 PERCENT StockItem.StockItemID, StockItem.StockItem_Name, StockItem.ShrinkItem_Quantity, StockItem.ChannelID, PriceChannelLnk.PriceChannelLnk_Price FROM ([SELECT TOP 100 PERCENT StockItem.StockItemID, StockItem.StockItem_Name, Channel.ChannelID, ShrinkItem.ShrinkItem_Quantity FROM StockItem INNER JOIN ShrinkItem ON StockItem.StockItem_ShrinkID = ShrinkItem.ShrinkItem_ShrinkID ,Channel "
       sql = sql & " WHERE (Channel.ChannelID <> 9)]. AS StockItem LEFT JOIN PriceChannelLnk ON (StockItem.ShrinkItem_Quantity = PriceChannelLnk.PriceChannelLnk_Quantity) AND (StockItem.ChannelID = PriceChannelLnk.PriceChannelLnk_ChannelID) AND (StockItem.StockItemID = PriceChannelLnk.PriceChannelLnk_StockItemID)) INNER JOIN PriceChannelLnk AS PriceChannelLnk_1 ON (PriceChannelLnk_1.PriceChannelLnk_Quantity = StockItem.ShrinkItem_Quantity) AND (StockItem.StockItemID = PriceChannelLnk_1.PriceChannelLnk_StockItemID) ORDER BY StockItem.StockItem_Name, StockItem.ShrinkItem_Quantity, StockItem.ChannelID) DISPLAY_PricingOverride GROUP BY DISPLAY_PricingOverride.StockItem_Name, DISPLAY_PricingOverride.ShrinkItem_Quantity PIVOT DISPLAY_PricingOverride.ChannelID;"

        rs = getRS(sql)
        ''ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If
        Report.SetDataSource(rs)
        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub
    Public Sub updatePricingBySystem()
        Dim x As Short
        Dim sql As String

        cnnDB.Execute("DELETE Catalogue.*, StockItem.StockItemID FROM StockItem RIGHT JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID WHERE (((StockItem.StockItemID) Is Null));")

        cnnDB.Execute("INSERT INTO Catalogue ( Catalogue_StockItemID, Catalogue_Quantity, Catalogue_Barcode, Catalogue_Deposit, Catalogue_Content, Catalogue_Disabled ) SELECT theJoin.StockItemID, theJoin.ShrinkItem_Quantity, 'CODE' AS Expr1, 0 AS deposit, 0 AS content, 0 AS disabled FROM systemStockItemPricing INNER JOIN ([SELECT StockItem.StockItemID, ShrinkItem.ShrinkItem_Quantity FROM ShrinkItem INNER JOIN StockItem ON ShrinkItem.ShrinkItem_ShrinkID = StockItem.StockItem_ShrinkID]. AS theJoin LEFT JOIN Catalogue ON (theJoin.ShrinkItem_Quantity = Catalogue.Catalogue_Quantity) AND (theJoin.StockItemID = Catalogue.Catalogue_StockItemID)) ON systemStockItemPricing.systemStockItemPricing = theJoin.StockItemID WHERE (((Catalogue.Catalogue_StockItemID) Is Null));")
        cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (StockItem INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET Catalogue.Catalogue_Content = [Catalogue_Quantity]/[StockItem_Quantity]*[StockItem_ActualCost];")

        cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN ((Catalogue INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET Catalogue.Catalogue_Deposit = [Catalogue_Quantity]*[Deposit_UnitCost];")
        cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN ((Catalogue INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID) INNER JOIN Deposit ON StockItem.StockItem_DepositID = Deposit.DepositID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET Catalogue.Catalogue_Deposit = [Catalogue_Deposit]+[Deposit_CaseCost] WHERE (((Deposit.Deposit_CaseCost)<>0));")

        sql = "INSERT INTO CatalogueChannelLnk ( CatalogueChannelLnk_StockItemID, CatalogueChannelLnk_Quantity, CatalogueChannelLnk_ChannelID, CatalogueChannelLnk_Markup, CatalogueChannelLnk_Price, CatalogueChannelLnk_PriceOriginal, CatalogueChannelLnk_PriceSystem, CatalogueChannelLnk_Location ) "
        sql = sql & "SELECT catalogue.Catalogue_StockItemID, catalogue.Catalogue_Quantity, catalogue.ChannelID, 0 AS markup, 0 AS price, 0 AS original, 0 AS system, 0 AS location FROM ([SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, Channel.ChannelID FROM Catalogue ,Channel]. AS catalogue LEFT JOIN CatalogueChannelLnk ON (catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (catalogue.ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)) INNER JOIN systemStockItemPricing ON catalogue.Catalogue_StockItemID = systemStockItemPricing.systemStockItemPricing WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) Is Null));"
        cnnDB.Execute(sql)
        For x = 1 To 8
            cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (PricingGroup INNER JOIN (StockItem INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) ON PricingGroup.PricingGroupID = StockItem.StockItem_PricingGroupID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Markup = [PricingGroup]![PricingGroup_Unit" & x & "], CatalogueChannelLnk.CatalogueChannelLnk_Location = 1 WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)=1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=" & x & "));")
            cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (PricingGroup INNER JOIN (StockItem INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) ON PricingGroup.PricingGroupID = StockItem.StockItem_PricingGroupID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Markup = [PricingGroup]![PricingGroup_Case" & x & "], CatalogueChannelLnk.CatalogueChannelLnk_Location = 1 WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)<>1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=" & x & "));")
        Next
        cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN ((StockItem INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) INNER JOIN PricingGroupChannelLnk ON (CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = PricingGroupChannelLnk.PricingGroupChannelLnk_ChannelID) AND (StockItem.StockItem_PackSizeID = PricingGroupChannelLnk.PricingGroupChannelLnk_PackSizeID)) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Markup = [PricingGroupChannelLnk]![PricingGroupChannelLnk_Markup], CatalogueChannelLnk.CatalogueChannelLnk_Location = 2;")
        cnnDB.Execute("UPDATE PropChannelLnk INNER JOIN CatalogueChannelLnk ON (PropChannelLnk.PropChannelLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (PropChannelLnk.PropChannelLnk_ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) SET CatalogueChannelLnk.CatalogueChannelLnk_Markup = [PropChannelLnk]![PropChannelLnk_Markup], CatalogueChannelLnk.CatalogueChannelLnk_Location = 3;")
        cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (Catalogue INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)) ON systemStockItemPricing.systemStockItemPricing = Catalogue.Catalogue_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_PriceOriginal = [Catalogue_Content]*(1+[CatalogueChannelLnk_Markup]/100)+[Catalogue_Deposit];")
        'Add VAT
        cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN ((StockItem INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_PriceOriginal = [CatalogueChannelLnk_PriceOriginal]*(1+[Vat_Amount]/100);")
        'round cents Up
        cnnDB.Execute("UPDATE CatalogueChannelLnk INNER JOIN systemStockItemPricing ON CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = systemStockItemPricing.systemStockItemPricing SET CatalogueChannelLnk.CatalogueChannelLnk_Price = round([CatalogueChannelLnk_PriceOriginal]+0.0049,1);")
        'Do rouding
        cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN ((StockItem INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Price = round([CatalogueChannelLnk_PriceOriginal]+0.49,0)-([PricingGroup_RemoveCents]/100) WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_Price)>[PricingGroup]![PricingGroup_RoundAfter]) AND (([CatalogueChannelLnk_PriceOriginal]*100 Mod 100)>[PricingGroup]![PricingGroup_RoundAfter]));")
        cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN ((StockItem INNER JOIN CatalogueChannelLnk ON StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) INNER JOIN PricingGroup ON StockItem.StockItem_PricingGroupID = PricingGroup.PricingGroupID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Price = round([CatalogueChannelLnk_PriceOriginal]-0.49,0)-([PricingGroup_RemoveCents]/100) WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_Price)>[PricingGroup]![PricingGroup_RoundAfter]) AND (([CatalogueChannelLnk_PriceOriginal]*100 Mod 100)<=[PricingGroup]![PricingGroup_RoundAfter]));")
        'update system price
        cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN CatalogueChannelLnk ON systemStockItemPricing.systemStockItemPricing = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_PriceSystem = [CatalogueChannelLnk]![CatalogueChannelLnk_Price];")

        'do Price Override
        cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (PriceChannelLnk INNER JOIN CatalogueChannelLnk ON (PriceChannelLnk.PriceChannelLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (PriceChannelLnk.PriceChannelLnk_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity)) ON systemStockItemPricing.systemStockItemPricing = PriceChannelLnk.PriceChannelLnk_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Price = [PriceChannelLnk]![PriceChannelLnk_Price], CatalogueChannelLnk.CatalogueChannelLnk_Location = 4;")

        'Do Channel 9 Actual Cost
        cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (CatalogueChannelLnk INNER JOIN StockItem ON CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = StockItem.StockItemID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_PriceOriginal = [CatalogueChannelLnk_Quantity]/[StockItem_Quantity]*[StockItem_ActualCost] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=9));")
        cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (CatalogueChannelLnk INNER JOIN Catalogue ON CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = Catalogue.Catalogue_StockItemID) ON systemStockItemPricing.systemStockItemPricing = Catalogue.Catalogue_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_PriceOriginal = [CatalogueChannelLnk]![CatalogueChannelLnk_PriceOriginal]+[Catalogue]![Catalogue_Deposit] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=9));")
        cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN ((CatalogueChannelLnk INNER JOIN StockItem ON CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = StockItem.StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_PriceOriginal = [CatalogueChannelLnk_PriceOriginal]*(1+[Vat_Amount]/100) WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=9));")
        cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN ((CatalogueChannelLnk INNER JOIN StockItem ON CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = StockItem.StockItemID) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID) ON systemStockItemPricing.systemStockItemPricing = StockItem.StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Price = round([CatalogueChannelLnk_PriceOriginal]+0.049,1) WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=9));")
        cnnDB.Execute("UPDATE CatalogueChannelLnk INNER JOIN systemStockItemPricing ON CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = systemStockItemPricing.systemStockItemPricing SET CatalogueChannelLnk.CatalogueChannelLnk_PriceSystem = [CatalogueChannelLnk]![CatalogueChannelLnk_Price] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=9));")

        cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (Channel INNER JOIN CatalogueChannelLnk ON Channel.ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) ON systemStockItemPricing.systemStockItemPricing = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Price = round([CatalogueChannelLnk_PriceOriginal]+0.049,1) WHERE (((Channel.Channel_NoPricing)<>0) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)<>9));")

        'Shrink Increment
        cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (CatalogueChannelLnk AS CatalogueChannelLnk_1 INNER JOIN (Channel INNER JOIN CatalogueChannelLnk ON Channel.ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) ON (CatalogueChannelLnk_1.CatalogueChannelLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (CatalogueChannelLnk_1.CatalogueChannelLnk_ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)) ON systemStockItemPricing.systemStockItemPricing = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_PriceOriginal = [CatalogueChannelLnk_1]![CatalogueChannelLnk_Price]*[CatalogueChannelLnk]![CatalogueChannelLnk_Quantity] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)<>9) AND ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)<>1) AND ((CatalogueChannelLnk_1.CatalogueChannelLnk_Quantity)=1) AND ((Channel.Channel_ShrinkIncrement)<>0));")
        cnnDB.Execute("UPDATE systemStockItemPricing INNER JOIN (Channel INNER JOIN CatalogueChannelLnk ON Channel.ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) ON systemStockItemPricing.systemStockItemPricing = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID SET CatalogueChannelLnk.CatalogueChannelLnk_Price = [CatalogueChannelLnk]![CatalogueChannelLnk_PriceOriginal], CatalogueChannelLnk.CatalogueChannelLnk_PriceSystem = [CatalogueChannelLnk]![CatalogueChannelLnk_PriceOriginal] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)<>9) AND ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)<>1) AND ((Channel.Channel_ShrinkIncrement)<>0));")
    End Sub

    Public Sub buildBarcodes(Optional ByRef id As Integer = 0)
        Dim x As Short
        Dim rs As ADODB.Recordset
        Dim lCode As String
        Dim lID, lQuantity As String
        Dim changeCode As Boolean

        If id = 0 Then
            Exit Sub
            cnnDB.Execute("UPDATE Catalogue SET Catalogue.Catalogue_Barcode = ""0"" WHERE (((IsNumeric([Catalogue_Barcode]))='0'));")

            For x = 1 To 15
                cnnDB.Execute("UPDATE Catalogue SET Catalogue.Catalogue_Barcode = Mid([Catalogue_Barcode],2,999) WHERE (((Left([Catalogue_Barcode],1))=""0""));")
            Next x
            rs = getRS("SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, Catalogue.Catalogue_Barcode From Catalogue;")
            '        Set rs = getRS("SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, Catalogue.Catalogue_Barcode From Catalogue WHERE Catalogue.Catalogue_Barcode = '0';")
        Else
            rs = getRS("SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, Catalogue.Catalogue_Barcode From Catalogue WHERE (((Catalogue.Catalogue_StockItemID)=" & id & "));")
        End If
        If rs.RecordCount Then
            rs.MoveFirst()
            Do Until rs.EOF
                changeCode = True
                lCode = rs.Fields("Catalogue_Barcode").Value
                If doCheckSum(lCode) Then
                    If Len(lCode) > 5 Then
                        changeCode = False
                    End If
                End If
                If changeCode Then
                    lID = rs.Fields("Catalogue_StockItemID").Value
                    lQuantity = rs.Fields("Catalogue_Quantity").Value
                    lCode = lID & "0" & lQuantity
                    lCode = "888" & Right(New String("0", 9) & lCode & "0", 9)
                    lCode = addCheckSum(lCode)
                    cnnDB.Execute("UPDATE Catalogue SET Catalogue_Barcode = '" & Replace(lCode, "'", "''") & "' WHERE Catalogue_StockItemID = " & lID & " AND Catalogue_Quantity = " & lQuantity)
                End If
                rs.moveNext()
            Loop
        End If
    End Sub

    Public Function buildItemBarcode(ByRef id As Integer, ByRef quantity As Short) As String
        Dim lCode As String
        lCode = id & "0" & quantity
        lCode = "888" & Right(New String("0", 9) & lCode & "0", 9)
        lCode = addCheckSum(lCode)
        buildItemBarcode = lCode

    End Function

    Public Function addCheckSum(ByRef Value As String) As String
        Dim lAmount As Short
        Dim code As String
        Dim i As Short

        If IsNumeric(Value) Then
            lAmount = 0
            For i = 1 To Len(Value)
                code = Left(Value, i)
                code = Right(code, 1)
                If i Mod 2 Then
                    lAmount = lAmount + CShort(code)
                Else
                    lAmount = lAmount + CShort(code) * 3
                End If
            Next
            lAmount = 10 - (lAmount Mod 10)
            If lAmount = 10 Then lAmount = 0
            addCheckSum = Value & lAmount
        Else
            addCheckSum = Value
        End If
    End Function

    Private Function doCheckSum(ByRef Value As String) As String
        Dim lAmount As Short
        Dim code As String
        Dim i As Short

        If IsNumeric(Value) Then
            lAmount = 0
            For i = 1 To Len(Value) - 1
                code = Left(Value, i)
                code = Right(code, 1)
                If i Mod 2 Then
                    lAmount = lAmount + CShort(code)
                Else
                    lAmount = lAmount + CShort(code) * 3
                End If
            Next
            lAmount = 10 - (lAmount Mod 10)
            If lAmount = 10 Then lAmount = 0
            doCheckSum = lAmount = CShort(Right(Value, 1))
        Else
            doCheckSum = False
        End If
    End Function


    Private Sub report_SupplierTransactions()
        Dim rs As ADODB.Recordset
        Dim RSitem As ADODB.Recordset
        Dim sql As String
        'Dim Report As New crySupplierTransactions
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("crySupplierTransactions.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        rs.Close()
        rs = getRSreport("SELECT * FROM Supplier")

        RSitem = getRSreport("SELECT SupplierTransaction.* From SupplierTransaction Where (((SupplierTransaction.SupplierTransaction_TransactionTypeID) = 2)) ORDER BY SupplierTransaction.SupplierTransaction_DayEndID, SupplierTransaction.SupplierTransactionID;")
        'ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If RSitem.BOF Or RSitem.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If
        Report.Database.Tables(1).SetDataSource(rs)
        Report.Database.Tables(2).SetDataSource(RSitem)
        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Private Sub report_CustomerMovement()
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryCustomerMovement
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryCustomer.Movement.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        rs.Close()
        'Set rs = getRSreport("SELECT aCustomer.Customer_InvoiceName, CustomerTransaction.CustomerTransaction_PersonName, DayEnd.DayEnd_Date, Sale.Sale_DatePOS, CustomerTransaction.CustomerTransaction_TransactionTypeID, Sale.Sale_Total, IIf([CustomerTransaction_TransactionTypeID]=2,[Sale_Total],Null) AS purchase, IIf([CustomerTransaction_TransactionTypeID]<>2,0-[Sale_Total],Null) AS payment, IIf([CustomerTransaction_TransactionTypeID]=2,[Sale_Total],0-[Sale_Total]) AS total FROM ((aCustomer INNER JOIN CustomerTransaction ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) INNER JOIN DayEnd ON CustomerTransaction.CustomerTransaction_DayEndID = DayEnd.DayEndID ORDER BY aCustomer.Customer_InvoiceName, CustomerTransaction.CustomerTransactionID;")
        'changed to aCustomer1 from aCustomer cuz it was not loading all the data of customers   Set rs = getRSreport("SELECT aCustomer.Customer_InvoiceName, CustomerTransaction.CustomerTransaction_PersonName, DayEnd.DayEnd_Date, Sale.Sale_DatePOS, CustomerTransaction.CustomerTransaction_TransactionTypeID, IIf([CustomerTransaction_TransactionTypeID]=8,[CustomerTransaction_Amount],IIf([CustomerTransaction_TransactionTypeID]<>2,0-[Sale_Total],Null)) AS payment, IIf([CustomerTransaction_TransactionTypeID]=2,[Sale_Total],Null) AS purchase, IIf([CustomerTransaction_TransactionTypeID]=2,[Sale_Total],0-[Sale_Total]) AS total FROM ((aCustomer INNER JOIN CustomerTransaction ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) INNER JOIN DayEnd ON CustomerTransaction.CustomerTransaction_DayEndID = DayEnd.DayEndID ORDER BY aCustomer.Customer_InvoiceName, CustomerTransaction.CustomerTransactionID;")
        rs = getRSreport("SELECT aCustomer1.Customer_InvoiceName, CustomerTransaction.CustomerTransaction_PersonName, DayEnd.DayEnd_Date, Sale.Sale_DatePOS, CustomerTransaction.CustomerTransaction_TransactionTypeID, IIf([CustomerTransaction_TransactionTypeID]=8,[CustomerTransaction_Amount],IIf([CustomerTransaction_TransactionTypeID]<>2,0-[Sale_Total],Null)) AS payment, IIf([CustomerTransaction_TransactionTypeID]=2,[Sale_Total],Null) AS purchase, IIf([CustomerTransaction_TransactionTypeID]=2,[Sale_Total],0-[Sale_Total]) AS total FROM ((aCustomer1 INNER JOIN CustomerTransaction ON aCustomer1.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) INNER JOIN DayEnd ON CustomerTransaction.CustomerTransaction_DayEndID = DayEnd.DayEndID ORDER BY aCustomer1.Customer_InvoiceName, CustomerTransaction.CustomerTransactionID;")
        'Set rs = getRSreport("SELECT aCustomer1.Customer_InvoiceName,  aCustomerTransaction.CustomerTransaction_PersonName, DayEnd.DayEnd_Date, Sale.Sale_DatePOS, aCustomerTransaction.CustomerTransaction_TransactionTypeID, IIf([CustomerTransaction_TransactionTypeID]=8,[CustomerTransaction_Amount],IIf([CustomerTransaction_TransactionTypeID]<>2,0-[Sale_Total],Null)) AS payment, IIf([CustomerTransaction_TransactionTypeID]=2,[Sale_Total],Null) AS purchase, IIf([CustomerTransaction_TransactionTypeID]=2,[Sale_Total],0-[Sale_Total]) AS total FROM ((aCustomer1 INNER JOIN aCustomerTransaction ON aCustomer1.CustomerID = aCustomerTransaction.CustomerTransaction_CustomerID) INNER JOIN Sale ON aCustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) INNER JOIN DayEnd ON aCustomerTransaction.CustomerTransaction_DayEndID = DayEnd.DayEndID ORDER BY aCustomer1.Customer_InvoiceName, aCustomerTransaction.CustomerTransactionID;")
        'ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

       Report.Database.Tables(1).SetDataSource(rs)
        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Private Sub report_CustomerMovementCD()
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryCustomerMovementCD
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryCustomerMovementCD.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        rs.Close()
        'Set rs = getRSreport("SELECT aCustomer.Customer_InvoiceName, CustomerTransaction.CustomerTransaction_PersonName, DayEnd.DayEnd_Date, Sale.Sale_DatePOS, CustomerTransaction.CustomerTransaction_TransactionTypeID, Sale.Sale_Total, IIf([CustomerTransaction_TransactionTypeID]=2,[Sale_Total],Null) AS purchase, IIf([CustomerTransaction_TransactionTypeID]<>2,0-[Sale_Total],Null) AS payment, IIf([CustomerTransaction_TransactionTypeID]=2,[Sale_Total],0-[Sale_Total]) AS total FROM ((aCustomer INNER JOIN CustomerTransaction ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) INNER JOIN DayEnd ON CustomerTransaction.CustomerTransaction_DayEndID = DayEnd.DayEndID ORDER BY aCustomer.Customer_InvoiceName, CustomerTransaction.CustomerTransactionID;")
        'changed to aCustomer1 from aCustomer cuz it was not loading all the data of customers   Set rs = getRSreport("SELECT aCustomer.Customer_InvoiceName, CustomerTransaction.CustomerTransaction_PersonName, DayEnd.DayEnd_Date, Sale.Sale_DatePOS, CustomerTransaction.CustomerTransaction_TransactionTypeID, IIf([CustomerTransaction_TransactionTypeID]=8,[CustomerTransaction_Amount],IIf([CustomerTransaction_TransactionTypeID]<>2,0-[Sale_Total],Null)) AS payment, IIf([CustomerTransaction_TransactionTypeID]=2,[Sale_Total],Null) AS purchase, IIf([CustomerTransaction_TransactionTypeID]=2,[Sale_Total],0-[Sale_Total]) AS total FROM ((aCustomer INNER JOIN CustomerTransaction ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) INNER JOIN DayEnd ON CustomerTransaction.CustomerTransaction_DayEndID = DayEnd.DayEndID ORDER BY aCustomer.Customer_InvoiceName, CustomerTransaction.CustomerTransactionID;")
        sql = "SELECT aCustomer1.Customer_InvoiceName, CustomerTransaction.CustomerTransaction_PersonName, DayEnd.DayEnd_Date, CustomerTransaction.CustomerTransaction_Date, CustomerTransaction.CustomerTransaction_TransactionTypeID, IIf([CustomerTransaction_TransactionTypeID]=3,[CustomerTransaction_Amount],0) AS ePay, IIf([CustomerTransaction_TransactionTypeID]=4,[CustomerTransaction_Amount],0) AS Debit, IIf([CustomerTransaction_TransactionTypeID]=5,[CustomerTransaction_Amount],0) AS Credit, (ePay+Debit+Credit) AS total"
        sql = sql & " FROM (aCustomer1 INNER JOIN CustomerTransaction ON aCustomer1.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) INNER JOIN DayEnd ON CustomerTransaction.CustomerTransaction_DayEndID = DayEnd.DayEndID Where (((CustomerTransaction.CustomerTransaction_TransactionTypeID) = 3)) Or (((CustomerTransaction.CustomerTransaction_TransactionTypeID) = 4)) Or (((CustomerTransaction.CustomerTransaction_TransactionTypeID) = 5)) ORDER BY aCustomer1.Customer_InvoiceName, CustomerTransaction.CustomerTransactionID;"
        rs = getRSreport(sql)
        'ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
           ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.Database.Tables(1).SetDataSource(rs)
        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub


    Private Sub report_StockMovementByDay()
        Dim rs As ADODB.Recordset
        Dim rsChange As ADODB.Recordset

        Dim sql As String
        'Dim Report As New cryStockMovementByDay
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryStockMovementByDay.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        rs.Close()
        rs = getRSreport("SELECT DayEnd.DayEndID, DayEnd.DayEnd_Date, Sum([DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk_ListCost]-[DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost]-[DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]+[DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost]) AS total, Sum([DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk_ListCost]) AS opening, Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost]) AS sales, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS shrink, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost]) AS grv FROM DayEndStockItemLnk INNER JOIN DayEnd ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = DayEnd.DayEndID GROUP BY Dayend.DayEndID, DayEnd.DayEnd_Date ORDER BY DayEnd.DayEnd_Date;")
        'UPGRADE_ISSUE: cryNoRecords object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        '    Set rsChange = getRSreport("SELECT DayEndStockItemLnk.DayEndStockItemLnk_DayEndID, Sum(([DayEndStockItemLnk]![DayEndStockItemLnk_ListCost]-[DayEndStockItemLnkfrom]![DayEndStockItemLnk_ListCost])*[DayEndStockItemLnkfrom]![DayEndStockItemLnk_Quantity]) AS totalProfit FROM [SELECT DayEndStockItemLnkFirst.* From DayEndStockItemLnkFirst Union SELECT DayEndStockItemLnk.* From DayEndStockItemLnk ]. AS dayendStockItemLnkFrom INNER JOIN DayEndStockItemLnk ON dayendStockItemLnkFrom.DayEndStockItemLnk_StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID Where (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) = [DayEndStockItemLnkfrom]![DayEndStockItemLnk_DayEndID] + 1)) GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_DayEndID;")
        ' fixed err COLs IN UNION QRY DONOT MATCH  Set rsChange = getRSreport("SELECT dayendStockItemLnkFrom.DayEndStockItemLnk_DayEndID, Sum(([DayEndStockItemLnk]![DayEndStockItemLnk_ListCost]-[DayEndStockItemLnkfrom]![DayEndStockItemLnk_ListCost])*[DayEndStockItemLnk]![DayEndStockItemLnk_Quantity]) AS totalProfit FROM (SELECT * FROM DayEndStockITemLnk Union SELECT [Report_DayEndEndID]+1 AS Expr1, aStockItem.StockItemID, 0 AS opening, 0 AS sales, 0 AS shrink, 0 AS grv, 0 AS expr3, 0 AS expr2, 0 AS listCost,0 as actualCost FROM Report, aStockItem) AS dayendStockitemLnk INNER JOIN (SELECT DayEndStockItemLnkFirst.* From DayEndStockItemLnkFirst Union SELECT DayEndStockItemLnk.* From DayEndStockItemLnk ) AS dayendStockItemLnkFrom ON dayendStockitemLnk.DayEndStockItemLnk_StockItemID = dayendStockItemLnkFrom.DayEndStockItemLnk_StockItemID Where (((dayendStockitemLnk.DayEndStockItemLnk_DayEndID) = [dayendStockItemLnkFrom]![DayEndStockItemLnk_DayEndID] + 1)) GROUP BY dayendStockItemLnkFrom.DayEndStockItemLnk_DayEndID;")
        rsChange = getRSreport("SELECT dayendStockItemLnkFrom.DayEndStockItemLnk_DayEndID, Sum(([DayEndStockItemLnk]![DayEndStockItemLnk_ListCost]-[DayEndStockItemLnkfrom]![DayEndStockItemLnk_ListCost])*[DayEndStockItemLnk]![DayEndStockItemLnk_Quantity]) AS totalProfit FROM (SELECT * FROM DayEndStockITemLnk Union SELECT [Report_DayEndEndID]+1 AS Expr1, aStockItem.StockItemID, 0 AS opening, 0 AS sales, 0 AS shrink, 0 AS grv, 0 AS expr3, 0 AS expr2, 0 AS listCost,0 as actualCost, 2 as Warehouse FROM Report, aStockItem) AS dayendStockitemLnk INNER JOIN (SELECT DayEndStockItemLnkFirst.* From DayEndStockItemLnkFirst Union SELECT DayEndStockItemLnk.* From DayEndStockItemLnk ) AS dayendStockItemLnkFrom ON dayendStockitemLnk.DayEndStockItemLnk_StockItemID = dayendStockItemLnkFrom.DayEndStockItemLnk_StockItemID Where (((dayendStockitemLnk.DayEndStockItemLnk_DayEndID) = [dayendStockItemLnkFrom]![DayEndStockItemLnk_DayEndID] + 1)) GROUP BY dayendStockItemLnkFrom.DayEndStockItemLnk_DayEndID;")
        Report.Database.Tables(1).SetDataSource(rs)
        Report.Database.Tables(2).SetDataSource(rsChange)
        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Public Sub report_POS(ByRef id As Integer)
        Dim rs As ADODB.Recordset
        Dim rsData As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryPos
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryPos.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        'ReportNone.Load("cryNoRecords.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name, aPOS.POS_Name From aCompany, Report, aPOS WHERE (((aPOS.POSID)=" & id & "));")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        Report.SetParameterValue("txtTitle", "Point Of Sale Transactions for Device " & rs.Fields("POS_Name").Value)
        rs.Close()
        rs = getRSreport("SELECT Sale.*, aConsignment.*, aCustomer.Customer_InvoiceName, aChannel.Channel_Name FROM aChannel INNER JOIN (aCustomer RIGHT JOIN (CustomerTransaction RIGHT JOIN (aConsignment RIGHT JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID) ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) ON aChannel.ChannelID = Sale.Sale_ChannelID WHERE (((Sale.Sale_PosID)=" & id & "));")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        sql = "SELECT SaleItem.*, IIf([SaleItem_DepositType]=1,[Deposit_Name]+'-bottle',IIf([SaleItem_DepositType]=2,[Deposit_Name]+'-Crate',[Deposit_Name]+'-Case')) AS StockItem_Name FROM SaleItem INNER JOIN aDeposit ON SaleItem.SaleItem_StockItemID = aDeposit.DepositID Where (((SaleItem.SaleItem_DepositType) <> 0)) Union "
        sql = sql & "SELECT SaleItem.*, aStockItem.StockItem_Name FROM SaleItem INNER JOIN aStockItem ON SaleItem.SaleItem_StockItemID = aStockItem.StockItemID Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_Recipe) = 0)) Union "
        sql = sql & "SELECT SaleItem.*, aRecipe.Recipe_Name AS StockItem_Name FROM SaleItem INNER JOIN aRecipe ON SaleItem.SaleItem_StockItemID = aRecipe.RecipeID WHERE (((SaleItem.SaleItem_DepositType)=0) AND ((SaleItem.SaleItem_Recipe)<>0));"
        rsData = getRSreport(sql)

        If rsData.BOF Or rsData.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.Database.Tables(1).SetDataSource(rs)
        Report.Database.Tables(2).SetDataSource(rsData)

        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub
    Public Sub report_StockQuantity(Optional ByRef stockID As Integer = 0)
        Dim rs As ADODB.Recordset
        Dim rsOpen As ADODB.Recordset
        Dim rsWH As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryStockQuantityReport
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryStockQuantityReport.rpt")
        Dim lID As Integer
        If stockID = 0 Then
            lID = frmStockList.getItem()
        Else
            lID = stockID
        End If
        'Multi Warehouse change
        Dim lMWNo As Integer
        lMWNo = frmMWSelect.getMWNo
        If lMWNo > 1 Then
            rsWH = getRS("SELECT * FROM Warehouse WHERE WarehouseID=" & lMWNo & ";")
            Report.SetParameterValue("txtWH", rsWH.Fields("Warehouse_Name"))
        End If
        'Multi Warehouse change
        'ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If lID Then
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
            Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
            Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
            rs.Close()
            rs = getRSreport("SELECT * FROM aStockItem WHERE StockItemID=" & lID)
            Report.SetParameterValue("txtTitle", "Stock Movement for " & rs.Fields("StockItem_Name").Value)
            rs.Close()

            'sql = "SELECT DayEnd.DayEnd_Date, stockQuantity.* FROM DayEnd INNER JOIN (SELECT * FROM (SELECT Sale.Sale_DayEndID AS dayEnd, Sale.Sale_Date AS [date], 'Sale' AS type, [Sale_PosID] & '_' & [Sale_Reference] AS name, SaleItem.SaleItem_StockItemID AS stockItem, 0 AS grvQuantity, [SaleItem_ShrinkQuantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_Reversal) = 0) And ((SaleItem.SaleItem_Recipe) = 0)) Union "
            'sql = sql & "SELECT Sale.Sale_DayEndID AS dayEnd, Sale.Sale_Date AS [date], 'Sale' AS type, [Sale_PosID] & '_' & [Sale_Reference] & '*' AS name, aSaleItemReciept.SaleItemReciept_StockitemID AS stockItem, 0 AS grvQuantity, [SaleItemReciept_Quantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN aSaleItemReciept ON SaleItem.SaleItemID = aSaleItemReciept.SaleItemReciept_SaleItemID WHERE (((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)=0))) as movement Union "
            'sql = sql & "SELECT * FROM (SELECT Sale.Sale_DayEndID AS dayEnd, Sale.Sale_Date AS [date], 'Sale Return' AS type, [Sale_PosID] & '_' & [Sale_Reference] AS name, SaleItem.SaleItem_StockItemID AS stockItem, 0 AS grvQuantity, 0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_Reversal) <> 0) And ((SaleItem.SaleItem_Recipe) = 0)) Union "
            'sql = sql & "SELECT Sale.Sale_DayEndID AS dayEnd, Sale.Sale_Date AS [date], 'Sale Return' AS type, [Sale_PosID] & '_' & [Sale_Reference] & '*' AS name, aSaleItemReciept.SaleItemReciept_StockitemID AS stockItem, 0 AS grvQuantity, 0-[SaleItemReciept_Quantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN aSaleItemReciept ON SaleItem.SaleItemID = aSaleItemReciept.SaleItemReciept_SaleItemID WHERE (((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)<>0))) as movement Union "
            'sql = sql & "SELECT aGRV.GRV_DayEndID AS dayEnd, aGRV.GRV_Date AS [date], 'Purchase' AS type, Supplier.Supplier_Name AS name, aGRVItem.GRVItem_StockItemID AS stockItem, [GRVItem_PackSize]*[GRVItem_Quantity] AS grvQuantity, Null AS saleQuantity, Null AS shrinkQuantity FROM (aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID Where (((aGRVItem.GRVItem_Return) = 0) And ((aGRV.GRV_GRVStatusID) = 3)) Union "
            'sql = sql & "SELECT aGRV.GRV_DayEndID AS dayEnd, aGRV.GRV_Date AS [date], 'Purchase Return' AS type, Supplier.Supplier_Name AS name, aGRVItem.GRVItem_StockItemID AS stockItem, 0-([GRVItem_PackSize]*[GRVItem_Quantity]) AS grvQuantity, Null AS saleQuantity, Null AS shrinkQuantity FROM (aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID Where (((aGRVItem.GRVItem_Return) <> 0) And ((aGRV.GRV_GRVStatusID) = 3)) Union "
            'sql = sql & "SELECT DayEndStockItemLnk.DayEndStockItemLnk_DayEndID AS dayEnd, DayEnd.DayEnd_Date AS [date], 'Shrinkage' AS type, 'Shrinkage' AS name, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, Null AS grvQuantity, Null AS saleQuantity, DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink AS shrinkQuantity FROM DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID Where (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0)) ) AS stockQuantity ON DayEnd.DayEndID = stockQuantity.dayEnd Where (((stockQuantity.stockItem) = " & lID & ")) ORDER BY stockQuantity.date;"

            'aSaleItemReciept changed to aSaleItemReciept1
            'query was showing less/wrong info due to less rec in aSaleItemReciept
            sql = "SELECT DayEnd.DayEnd_Date, stockQuantity.* FROM DayEnd INNER JOIN (SELECT * FROM (SELECT Sale.Sale_DayEndID AS dayEnd, Sale.Sale_Date AS [date], 'Sale' AS type, [Sale_PosID] & '_' & [Sale_Reference] AS name, SaleItem.SaleItem_StockItemID AS stockItem, 0 AS grvQuantity, [SaleItem_ShrinkQuantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_Reversal) = 0) And ((SaleItem.SaleItem_Recipe) = 0)) Union "
            sql = sql & "SELECT Sale.Sale_DayEndID AS dayEnd, Sale.Sale_Date AS [date], 'Sale' AS type, [Sale_PosID] & '_' & [Sale_Reference] & '*' AS name, aSaleItemReciept1.SaleItemReciept_StockitemID AS stockItem, 0 AS grvQuantity, [SaleItemReciept_Quantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN aSaleItemReciept1 ON SaleItem.SaleItemID = aSaleItemReciept1.SaleItemReciept_SaleItemID WHERE (((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)=0))) as movement Union "
            sql = sql & "SELECT * FROM (SELECT Sale.Sale_DayEndID AS dayEnd, Sale.Sale_Date AS [date], 'Sale Return' AS type, [Sale_PosID] & '_' & [Sale_Reference] AS name, SaleItem.SaleItem_StockItemID AS stockItem, 0 AS grvQuantity, 0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_Reversal) <> 0) And ((SaleItem.SaleItem_Recipe) = 0)) Union "
            sql = sql & "SELECT Sale.Sale_DayEndID AS dayEnd, Sale.Sale_Date AS [date], 'Sale Return' AS type, [Sale_PosID] & '_' & [Sale_Reference] & '*' AS name, aSaleItemReciept1.SaleItemReciept_StockitemID AS stockItem, 0 AS grvQuantity, 0-[SaleItemReciept_Quantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity FROM (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN aSaleItemReciept1 ON SaleItem.SaleItemID = aSaleItemReciept1.SaleItemReciept_SaleItemID WHERE (((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)<>0))) as movement Union "
            sql = sql & "SELECT aGRV.GRV_DayEndID AS dayEnd, aGRV.GRV_Date AS [date], 'Purchase' AS type, Supplier.Supplier_Name AS name, aGRVItem.GRVItem_StockItemID AS stockItem, [GRVItem_PackSize]*[GRVItem_Quantity] AS grvQuantity, Null AS saleQuantity, Null AS shrinkQuantity FROM (aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID Where (((aGRVItem.GRVItem_Return) = 0) And ((aGRV.GRV_GRVStatusID) = 3)) Union "
            sql = sql & "SELECT aGRV.GRV_DayEndID AS dayEnd, aGRV.GRV_Date AS [date], 'Purchase Return' AS type, Supplier.Supplier_Name AS name, aGRVItem.GRVItem_StockItemID AS stockItem, 0-([GRVItem_PackSize]*[GRVItem_Quantity]) AS grvQuantity, Null AS saleQuantity, Null AS shrinkQuantity FROM (aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID Where (((aGRVItem.GRVItem_Return) <> 0) And ((aGRV.GRV_GRVStatusID) = 3)) Union "
            sql = sql & "SELECT DayEndStockItemLnk.DayEndStockItemLnk_DayEndID AS dayEnd, DayEnd.DayEnd_Date AS [date], 'Shrinkage' AS type, 'Shrinkage' AS name, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, Null AS grvQuantity, Null AS saleQuantity, DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink AS shrinkQuantity FROM DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID Where (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0)) ) AS stockQuantity ON DayEnd.DayEndID = stockQuantity.dayEnd Where (((stockQuantity.stockItem) = " & lID & ")) ORDER BY stockQuantity.date;"
            'adding query information in TEMP table, due to less info abt SALES QTY in RECIEPT
            sql = ""
            cnnDBreport.Execute("DELETE * FROM stockQuantityTemp;")

            '1
            sql = "SELECT DayEnd.DayEnd_Date AS dayEnddate, Sale.Sale_DayEndID AS dayEnd, Sale.Sale_Date AS [date], 'Sale' AS type, [Sale_PosID] & '_' & [Sale_Reference] AS name, SaleItem.SaleItem_StockItemID AS stockItem, 0 AS grvQuantity, [SaleItem_ShrinkQuantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity, Null AS xferQuantity "
            sql = sql & "FROM (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN DayEnd ON Sale.Sale_DayEndID = DayEnd.DayEndID "
            sql = sql & "WHERE (((SaleItem.SaleItem_StockItemID)=" & lID & ") AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)=0) AND ((SaleItem.SaleItem_Recipe)=0) AND ((SaleItem.SaleItem_WarehouseID)=" & lMWNo & "));"
            'Multi Warehouse change     sql = sql & "WHERE (((SaleItem.SaleItem_StockItemID)=" & lID & ") AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)=0) AND ((SaleItem.SaleItem_Recipe)=0));"
            cnnDBreport.Execute("INSERT INTO stockQuantityTemp " & sql)
            Debug.Print(sql)
            '2
            'sql = "SELECT DayEnd.DayEnd_Date AS dayEnddate, Sale.Sale_DayEndID AS dayEnd, Sale.Sale_Date AS [date], 'Sale' AS type, [Sale_PosID] & '_' & [Sale_Reference] & '*' AS name, aSaleItemReciept1.SaleItemReciept_StockitemID AS stockItem, 0 AS grvQuantity, [SaleItemReciept_Quantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity, Null AS xferQuantity "
            'changed on 11-12-2012 (if sell more then 1 it was multiplying 2 times) Hogshead
            sql = "SELECT DayEnd.DayEnd_Date AS dayEnddate, Sale.Sale_DayEndID AS dayEnd, Sale.Sale_Date AS [date], 'Sale' AS type, [Sale_PosID] & '_' & [Sale_Reference] & '*' AS name, aSaleItemReciept1.SaleItemReciept_StockitemID AS stockItem, 0 AS grvQuantity, [SaleItemReciept_Quantity] AS saleQuantity, 0 AS shrinkQuantity, Null AS xferQuantity "
            sql = sql & "FROM ((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN aSaleItemReciept1 ON SaleItem.SaleItemID = aSaleItemReciept1.SaleItemReciept_SaleItemID) INNER JOIN DayEnd ON Sale.Sale_DayEndID = DayEnd.DayEndID "
            sql = sql & "WHERE (((aSaleItemReciept1.SaleItemReciept_StockitemID)=" & lID & ") AND ((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)=0) AND ((SaleItem.SaleItem_WarehouseID)=" & lMWNo & "));"
            'Multi Warehouse change     sql = sql & "WHERE (((aSaleItemReciept1.SaleItemReciept_StockitemID)=" & lID & ") AND ((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)=0));"
            cnnDBreport.Execute("INSERT INTO stockQuantityTemp " & sql)
            Debug.Print(sql)
            '3
            sql = "SELECT DayEnd.DayEnd_Date AS dayEnddate, Sale.Sale_DayEndID AS dayEnd, Sale.Sale_Date AS [date], 'Sale Return' AS type, [Sale_PosID] & '_' & [Sale_Reference] AS name, SaleItem.SaleItem_StockItemID AS stockItem, 0 AS grvQuantity, 0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity, Null AS xferQuantity "
            sql = sql & "FROM (SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN DayEnd ON Sale.Sale_DayEndID = DayEnd.DayEndID "
            sql = sql & "WHERE (((SaleItem.SaleItem_StockItemID)=" & lID & ") AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)<>0) AND ((SaleItem.SaleItem_Recipe)=0) AND ((SaleItem.SaleItem_WarehouseID)=" & lMWNo & "));"
            'Multi Warehouse change     sql = sql & "WHERE (((SaleItem.SaleItem_StockItemID)=" & lID & ") AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)<>0) AND ((SaleItem.SaleItem_Recipe)=0));"
            cnnDBreport.Execute("INSERT INTO stockQuantityTemp " & sql)
            Debug.Print(sql)
            '4
            'sql = "SELECT DayEnd.DayEnd_Date AS dayEnddate, Sale.Sale_DayEndID AS dayEnd, Sale.Sale_Date AS [date], 'Sale Return' AS type, [Sale_PosID] & '_' & [Sale_Reference] & '*' AS name, aSaleItemReciept1.SaleItemReciept_StockitemID AS stockItem, 0 AS grvQuantity, 0-[SaleItemReciept_Quantity]*[SaleItem_Quantity] AS saleQuantity, 0 AS shrinkQuantity, Null AS xferQuantity "
            'changed on 11-12-2012 (if sell more then 1 it was multiplying 2 times) Hogshead
            sql = "SELECT DayEnd.DayEnd_Date AS dayEnddate, Sale.Sale_DayEndID AS dayEnd, Sale.Sale_Date AS [date], 'Sale Return' AS type, [Sale_PosID] & '_' & [Sale_Reference] & '*' AS name, aSaleItemReciept1.SaleItemReciept_StockitemID AS stockItem, 0 AS grvQuantity, 0-[SaleItemReciept_Quantity] AS saleQuantity, 0 AS shrinkQuantity, Null AS xferQuantity "
            sql = sql & "FROM ((SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID) INNER JOIN aSaleItemReciept1 ON SaleItem.SaleItemID = aSaleItemReciept1.SaleItemReciept_SaleItemID) INNER JOIN DayEnd ON Sale.Sale_DayEndID = DayEnd.DayEndID "
            sql = sql & "WHERE (((aSaleItemReciept1.SaleItemReciept_StockitemID)=" & lID & ") AND ((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)<>0) AND ((SaleItem.SaleItem_WarehouseID)=" & lMWNo & "));"
            'Multi Warehouse change     sql = sql & "WHERE (((aSaleItemReciept1.SaleItemReciept_StockitemID)=" & lID & ") AND ((SaleItem.SaleItem_Recipe)<>0) AND ((SaleItem.SaleItem_Revoke)=0) AND ((SaleItem.SaleItem_Reversal)<>0));"
            cnnDBreport.Execute("INSERT INTO stockQuantityTemp " & sql)
            Debug.Print(sql)

            If lMWNo = 2 Then
                '5
                sql = "SELECT DayEnd.DayEnd_Date AS dayEnddate, aGRV.GRV_DayEndID AS dayEnd, aGRV.GRV_Date AS [date], 'Purchase' AS type, Supplier.Supplier_Name AS name, aGRVItem.GRVItem_StockItemID AS stockItem, [GRVItem_PackSize]*[GRVItem_Quantity] AS grvQuantity, Null AS saleQuantity, Null AS shrinkQuantity, Null AS xferQuantity "
                sql = sql & "FROM (aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID "
                sql = sql & "WHERE (((aGRVItem.GRVItem_StockItemID)=" & lID & ") AND ((aGRVItem.GRVItem_Return)=0) AND ((aGRV.GRV_GRVStatusID)=3));"
                cnnDBreport.Execute("INSERT INTO stockQuantityTemp " & sql)
                Debug.Print(sql)
                '6
                sql = "SELECT DayEnd.DayEnd_Date AS dayEnddate, aGRV.GRV_DayEndID AS dayEnd, aGRV.GRV_Date AS [date], 'Purchase Return' AS type, Supplier.Supplier_Name AS name, aGRVItem.GRVItem_StockItemID AS stockItem, 0-([GRVItem_PackSize]*[GRVItem_Quantity]) AS grvQuantity, Null AS saleQuantity, Null AS shrinkQuantity, Null AS xferQuantity "
                sql = sql & "FROM (aGRVItem INNER JOIN ((aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) INNER JOIN aGRV ON aPurchaseOrder.PurchaseOrderID = aGRV.GRV_PurchaseOrderID) ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID "
                sql = sql & "WHERE (((aGRVItem.GRVItem_StockItemID)=" & lID & ") AND ((aGRVItem.GRVItem_Return)<>0) AND ((aGRV.GRV_GRVStatusID)=3));"
                cnnDBreport.Execute("INSERT INTO stockQuantityTemp " & sql)
                Debug.Print(sql)
            End If

            '7
            sql = "SELECT DayEnd.DayEnd_Date AS dayEnddate, DayEndStockItemLnk.DayEndStockItemLnk_DayEndID AS dayEnd, DayEnd.DayEnd_Date AS [date], 'Shrinkage' AS type, 'Shrinkage' AS name, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, Null AS grvQuantity, Null AS saleQuantity, DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink AS shrinkQuantity, Null AS xferQuantity "
            sql = sql & "FROM DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID "
            sql = sql & "WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & lID & ") AND ((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink)<>0) AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & lMWNo & "));"
            'Multi Warehouse change     sql = sql & "WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & lID & ") AND ((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink)<>0));"
            cnnDBreport.Execute("INSERT INTO stockQuantityTemp " & sql)
            Debug.Print(sql)

            'DayEndStockItemLnk_QuantityTransafer
            '8
            sql = "SELECT DayEnd.DayEnd_Date AS dayEnddate, DayEndStockItemLnk.DayEndStockItemLnk_DayEndID AS dayEnd, DayEnd.DayEnd_Date AS [date], 'Xfer' AS type, 'Xfer' AS name, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, Null AS grvQuantity, Null AS saleQuantity, Null AS shrinkQuantity, DayEndStockItemLnk.DayEndStockItemLnk_QuantityTransafer AS xferQuantity "
            sql = sql & "FROM DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID "
            sql = sql & "WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & lID & ") AND ((DayEndStockItemLnk.DayEndStockItemLnk_QuantityTransafer)<>0) AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & lMWNo & "));"
            cnnDBreport.Execute("INSERT INTO stockQuantityTemp " & sql)
            Debug.Print(sql)

            'adding query information in TEMP table, due to less info abt SALES QTY in RECIEPT
            sql = "SELECT * from stockQuantityTemp ORDER BY stockQuantityTemp.dayEnddate,stockQuantityTemp.date;"
            rs = getRSreport(sql)
            Debug.Print(sql)

            If rs.BOF Or rs.EOF Then
                '9
                sql = "SELECT DayEnd.DayEnd_Date AS dayEnddate, DayEndStockItemLnk.DayEndStockItemLnk_DayEndID AS dayEnd, DayEnd.DayEnd_Date AS [date], 'No Movement' AS type, 'No Movement' AS name, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID AS stockItem, 0 AS grvQuantity, 0 AS saleQuantity, 0 AS shrinkQuantity, 0 AS xferQuantity "
                sql = sql & "FROM DayEnd INNER JOIN DayEndStockItemLnk ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID "
                sql = sql & "WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & lID & ") AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & lMWNo & "));"
                cnnDBreport.Execute("INSERT INTO stockQuantityTemp " & sql)
                Debug.Print(sql)
                'adding query information in TEMP table, due to less info abt SALES QTY in RECIEPT
                sql = "SELECT * from stockQuantityTemp ORDER BY stockQuantityTemp.dayEnddate,stockQuantityTemp.date;"
                rs = getRSreport(sql)
                Debug.Print(sql)
            End If

            If rs.BOF Or rs.EOF Then
                ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
                ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
                frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
                frmReportShow.CRViewer1.ReportSource = ReportNone
                frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
                frmReportShow.CRViewer1.Refresh()
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                frmReportShow.ShowDialog()
                Exit Sub
            End If
            rsOpen = getRSreport("SELECT First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity From DayEndStockItemLnk GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse HAVING (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & lID & ") AND ((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse)=" & lMWNo & "));")
            'Multi Warehouse change     Set rsOpen = getRSreport("SELECT First(DayEndStockItemLnk.DayEndStockItemLnk_Quantity) AS FirstOfDayEndStockItemLnk_Quantity From DayEndStockItemLnk GROUP BY DayEndStockItemLnk.DayEndStockItemLnk_StockItemID HAVING (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & lID & "));")
            Report.Database.Tables(1).SetDataSource(rs)
            Report.Database.Tables(2).SetDataSource(rsOpen)

            'Report.VerifyOnEveryPrint = True
            frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = Report
            frmReportShow.mReport = Report : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
        End If
    End Sub


    Private Sub report_Deposit()
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryDeposit
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryDeposit.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        rs.Close()
        rs = getRSreport("SELECT aDeposit.Deposit_Name, aDeposit.Deposit_Quantity, Sum((IIf([SaleItem_DepositType]=3,[Deposit_Quantity],0)+IIf([SaleItem_DepositType]=1,1,0))*[SaleItem_Quantity]) AS bottle, Sum((IIf([SaleItem_DepositType]=3,1,0)+IIf([SaleItem_DepositType]=2,1,0))*[SaleItem_Quantity]) AS crate, Sum([SaleItem_Price]*[SaleItem_Quantity]) AS amount, aDeposit.Deposit_UnitCost, aDeposit.Deposit_CaseCost FROM SaleItem INNER JOIN aDeposit ON SaleItem.SaleItem_StockItemID = aDeposit.DepositID Where (((SaleItem.SaleItem_DepositType) <> 0) And ((SaleItem.SaleItem_Reversal) = False) And ((SaleItem.SaleItem_Revoke) = False)) GROUP BY aDeposit.Deposit_Name, aDeposit.Deposit_Quantity, aDeposit.Deposit_UnitCost, aDeposit.Deposit_CaseCost;")
        'ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
           ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.Database.Tables(1).SetDataSource(rs)

        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Private Sub report_StockCostVariance(ByRef ltype As Short)
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryStockCostVariance
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryStockCostVariance.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")

        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        rs.Close()
        If ltype Then
            sql = "SELECT dayendStockItemLnkFrom.DayEndStockItemLnk_DayEndID, DayEnd.DayEnd_Date, aStockItem.StockItem_Name, dayendStockItemLnkFrom.DayEndStockItemLnk_ActualCost AS DayEndStockItemLnkFrom_ListCost, DayEndStockItemLnk.DayEndStockItemLnk_ActualCost AS DayEndStockItemLnk_ListCost, [DayEndStockItemLnk]![DayEndStockItemLnk_ActualCost]-[DayEndStockItemLnkfrom]![DayEndStockItemLnk_ActualCost] AS unitProfit, DayEndStockItemLnk.DayEndStockItemLnk_Quantity, ([DayEndStockItemLnk]![DayEndStockItemLnk_ActualCost]-[DayEndStockItemLnkfrom]![DayEndStockItemLnk_ActualCost])*[DayEndStockItemLnk]![DayEndStockItemLnk_Quantity] AS totalProfit "
            sql = sql & "FROM ((DayEndStockItemLnk INNER JOIN [SELECT DayEndStockItemLnkFirst.* From DayEndStockItemLnkFirst Union SELECT DayEndStockItemLnk.* From DayEndStockItemLnk ]. AS dayendStockItemLnkFrom ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = dayendStockItemLnkFrom.DayEndStockItemLnk_StockItemID) INNER JOIN DayEnd ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = DayEnd.DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID Where (((DayEndStockItemLnk.DayEndStockItemLnk_ActualCost) <> [dayendStockItemLnkFrom]![DayEndStockItemLnk_ActualCost]) And ((DayEndStockItemLnk.DayEndStockItemLnk_Quantity) > 0) And ((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) = [dayendStockItemLnkFrom]![DayEndStockItemLnk_DayEndID] + 1)) ORDER BY dayendStockItemLnkFrom.DayEndStockItemLnk_DayEndID, aStockItem.StockItem_Name;"
            Report.SetParameterValue("txtTitle", "Profit or Loss due to Cost Variance - Actual")
        Else
            sql = "SELECT dayendStockItemLnkFrom.DayEndStockItemLnk_DayEndID, DayEnd.DayEnd_Date, aStockItem.StockItem_Name, dayendStockItemLnkFrom.DayEndStockItemLnk_ListCost AS DayEndStockItemLnkFrom_ListCost, DayEndStockItemLnk.DayEndStockItemLnk_ListCost, [DayEndStockItemLnk]![DayEndStockItemLnk_ListCost]-[DayEndStockItemLnkfrom]![DayEndStockItemLnk_ListCost] AS unitProfit, DayEndStockItemLnk.DayEndStockItemLnk_Quantity, ([DayEndStockItemLnk]![DayEndStockItemLnk_ListCost]-[DayEndStockItemLnkfrom]![DayEndStockItemLnk_ListCost])*[DayEndStockItemLnk]![DayEndStockItemLnk_Quantity] AS totalProfit FROM ((DayEndStockItemLnk INNER JOIN (SELECT DayEndStockItemLnkFirst.* From DayEndStockItemLnkFirst Union SELECT DayEndStockItemLnk.* From DayEndStockItemLnk "
            sql = sql & ") AS dayendStockItemLnkFrom ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = dayendStockItemLnkFrom.DayEndStockItemLnk_StockItemID) INNER JOIN DayEnd ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = DayEnd.DayEndID) INNER JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID Where (((DayEndStockItemLnk.DayEndStockItemLnk_ListCost) <> [dayendStockItemLnkFrom]![DayEndStockItemLnk_ListCost]) And ((DayEndStockItemLnk.DayEndStockItemLnk_Quantity) > 0) And ((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) = [dayendStockItemLnkFrom]![DayEndStockItemLnk_DayEndID] + 1)) ORDER BY dayendStockItemLnkFrom.DayEndStockItemLnk_DayEndID, aStockItem.StockItem_Name;"
            Report.SetParameterValue("txtTitle", "Profit or Loss due to Cost Variance - List")
        End If

        rs = getRSreport(sql)
        'ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.Database.Tables(1).SetDataSource(rs)

        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Private Sub report_StockBreakTransaction()
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryStockBreakTransaction
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryStockBreakTransaction.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        rs.Close()
        rs = getRSreport("SELECT DayEnd.DayEnd_Date, Format([DayEnd_Date],'dddd, dd mmm yyyy') AS theDate, DayEnd.DayEndID, aStockItem.StockItem_Name, aStockItem_1.StockItem_Name AS StockItemChild_Name, aStockBreakTransaction.* FROM ((aStockBreakTransaction INNER JOIN DayEnd ON aStockBreakTransaction.StockBreakTransaction_DayEndID = DayEnd.DayEndID) INNER JOIN aStockItem ON aStockBreakTransaction.StockBreakTransaction_ParentID = aStockItem.StockItemID) INNER JOIN aStockItem AS aStockItem_1 ON aStockBreakTransaction.StockBreakTransaction_ChildID = aStockItem_1.StockItemID ORDER BY DayEnd.DayEnd_Date, aStockItem.StockItem_Name;")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.Database.Tables(1).SetDataSource(rs)

        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
       frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    'report_SupplierBalance
    Private Sub report_SupplierBalance()
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New crySupplierBalances 'crySupplierBalance 'IIf(Supplier.Supplier_Current, Supplier.Supplier_Current,0)
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("crySupplierBalances.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()
        'Set rs = getRSreport("SELECT aCustomer.CustomerID, aCustomer.Customer_InvoiceName, [Customer_FirstName] & ' ' & [Customer_Surname] AS Customer_Name, aCustomer.Customer_CreditLimit, aCustomer.Customer_Current, aCustomer.Customer_30Days, aCustomer.Customer_60Days, aCustomer.Customer_90Days, aCustomer.Customer_120Days, aCustomer.Customer_150Days, [Customer_Current]+[Customer_30Days]+[Customer_60Days]+[Customer_90Days]+[Customer_120Days]+[Customer_150Days] AS outstanding From aCustomer WHERE ((([Customer_Current]+[Customer_30Days]+[Customer_60Days]+[Customer_90Days]+[Customer_120Days]+[Customer_150Days])<>0));")
        rs = getRS("SELECT Supplier.SupplierID, Supplier.Supplier_Name, IIf(IsNull([Supplier_Current]),0,[Supplier_Current]) AS Supplier_Currents, IIf(IsNull([Supplier_30Days]),0,[Supplier_30Days]) AS Supplier_30Dayss, IIf(IsNull([Supplier_60Days]),0,[Supplier_60Days]) AS Supplier_60Dayss, IIf(IsNull([Supplier_90Days]),0,[Supplier_90Days]) AS Supplier_90Dayss, IIf(IsNull([Supplier_120Days]),0,[Supplier_120Days]) AS Supplier_120Dayss, IIf(IsNull([Supplier_Current]),0,[Supplier_Current])+IIf(IsNull([Supplier_30Days]),0,[Supplier_30Days])+IIf(IsNull([Supplier_60Days]),0,[Supplier_60Days])+IIf(IsNull([Supplier_90Days]),0,[Supplier_90Days])+IIf(IsNull([Supplier_120Days]),0,[Supplier_120Days]) AS outstanding From Supplier WHERE (((IIf(IsNull([Supplier_Current]),0,[Supplier_Current])+IIf(IsNull([Supplier_30Days]),0,[Supplier_30Days])+IIf(IsNull([Supplier_60Days]),0,[Supplier_60Days])+IIf(IsNull([Supplier_90Days]),0,[Supplier_90Days])+IIf(IsNull([Supplier_120Days]),0,[Supplier_120Days]))<>0));")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.Database.Tables(1).SetDataSource(rs)

        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Private Sub report_CustomerBalance()
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryCustomerBalance
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryCustomerBalance.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        Dim showDetails As Boolean

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()
        'Set rs = getRSreport("SELECT aCustomer.CustomerID, aCustomer.Customer_InvoiceName, [Customer_FirstName] & ' ' & [Customer_Surname] AS Customer_Name, aCustomer.Customer_CreditLimit, aCustomer.Customer_Current, aCustomer.Customer_30Days, aCustomer.Customer_60Days, aCustomer.Customer_90Days, aCustomer.Customer_120Days, aCustomer.Customer_150Days, [Customer_Current]+[Customer_30Days]+[Customer_60Days]+[Customer_90Days]+[Customer_120Days]+[Customer_150Days] AS outstanding From aCustomer WHERE ((([Customer_Current]+[Customer_30Days]+[Customer_60Days]+[Customer_90Days]+[Customer_120Days]+[Customer_150Days])<>0));")
        If MsgBox("Do you wish to see Customer report only with Balances click 'Yes'?" & vbCrLf & vbCrLf & "click 'No' if you wish to see report for all Customers.", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1, "Customer Balances") = MsgBoxResult.Yes Then
            rs = getRSreport("SELECT aCustomer1.CustomerID, aCustomer1.Customer_InvoiceName, [Customer_FirstName] & ' ' & [Customer_Surname] AS Customer_Name, aCustomer1.Customer_Telephone, aCustomer1.Customer_Fax, aCustomer1.Customer_CreditLimit, aCustomer1.Customer_Current, aCustomer1.Customer_30Days, aCustomer1.Customer_60Days, aCustomer1.Customer_90Days, aCustomer1.Customer_120Days, aCustomer1.Customer_150Days, [Customer_Current]+[Customer_30Days]+[Customer_60Days]+[Customer_90Days]+[Customer_120Days]+[Customer_150Days] AS outstanding From aCustomer1 WHERE ((([Customer_Current]+[Customer_30Days]+[Customer_60Days]+[Customer_90Days]+[Customer_120Days]+[Customer_150Days])<>0));")
        Else
            rs = getRSreport("SELECT aCustomer1.CustomerID, aCustomer1.Customer_InvoiceName, [Customer_FirstName] & ' ' & [Customer_Surname] AS Customer_Name, aCustomer1.Customer_Telephone, aCustomer1.Customer_Fax, aCustomer1.Customer_CreditLimit, aCustomer1.Customer_Current, aCustomer1.Customer_30Days, aCustomer1.Customer_60Days, aCustomer1.Customer_90Days, aCustomer1.Customer_120Days, aCustomer1.Customer_150Days, [Customer_Current]+[Customer_30Days]+[Customer_60Days]+[Customer_90Days]+[Customer_120Days]+[Customer_150Days] AS outstanding From aCustomer1;")
        End If
        If MsgBox("Do you wish to see details of Customer, like Contact name, Phone and Fax numbers? click 'Yes'?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1, "Customer Balances") = MsgBoxResult.Yes Then
            Dim textObject As CrystalDecisions.CrystalReports.Engine.TextObject = Report.ReportDefinition.ReportObjects("Text1")
            textObject.Border.BackgroundColor = Color.White
            textObject.Border.LeftLineStyle = 1
            textObject.Border.RightLineStyle = 1
            'Report.Text1.BackColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            'Report.Text1.LeftLineStyle = 1
            'Report.Text1.RightLineStyle = 1
        Else
            Dim textObject As CrystalDecisions.CrystalReports.Engine.TextObject = Report.ReportDefinition.ReportObjects("Text15")
            textObject.Top = 0
            textObject.ObjectFormat.EnableSuppress = True
            textObject = Report.ReportDefinition.ReportObjects("Text2")
            textObject.ObjectFormat.EnableSuppress = True
            textObject.Top = 0
            textObject = Report.ReportDefinition.ReportObjects("Text14")
            textObject.ObjectFormat.EnableSuppress = True
            textObject.Top = 0
            textObject = Report.ReportDefinition.ReportObjects("Field19")
            textObject.ObjectFormat.EnableSuppress = True
            textObject.Top = 0
            textObject = Report.ReportDefinition.ReportObjects("Field21")
            textObject.ObjectFormat.EnableSuppress = True
            textObject.Top = 0
            textObject = Report.ReportDefinition.ReportObjects("Field20")
            textObject.ObjectFormat.EnableSuppress = True
            textObject.Top = 0
            textObject = Report.ReportDefinition.ReportObjects("Text1")
            textObject.Top = 0
           Report.ReportDefinition.Sections("Section3").Height = 210
        End If

        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.Database.Tables(1).SetDataSource(rs)

        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Private Sub report_Gratuity()
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryGratuity
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryGratuity.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        rs.Close()

        rs = getRSreport("SELECT [Person_FirstName]+' '+[Person_LastName] AS person_Name, aPOS.POS_Name, Sale.* FROM (Sale INNER JOIN aPerson ON Sale.Sale_PersonID = aPerson.PersonID) INNER JOIN aPOS ON Sale.Sale_PosID = aPOS.POSID Where (((Sale.Sale_Gratuity) <> 0)) ORDER BY Sale.Sale_Gratuity DESC;")
        'ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.Database.Tables(1).SetDataSource(rs)
        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Private Sub report_Discount()
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryDiscount
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryDiscount.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        rs.Close()
        rs = getRSreport("SELECT [Person_FirstName]+' '+[Person_LastName] AS person_Name, aPOS.POS_Name, Sale.* FROM (Sale INNER JOIN aPerson ON Sale.Sale_PersonID = aPerson.PersonID) INNER JOIN aPOS ON Sale.Sale_PosID = aPOS.POSID Where (((Sale.Sale_Discount) <> 0)) ORDER BY Sale.Sale_Discount DESC;")
        'ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.Database.Tables(1).SetDataSource(rs)
        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Private Sub report_RevokeTransactionlist()
        Dim sql As String
        Dim SumSales As Decimal
        Dim rs As ADODB.Recordset
        Dim rsData As ADODB.Recordset
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")

        ' to get getSQL
        Dim gl As Boolean
        Dim lWhere As String
        Dim x As Short
        Dim lString As String
        Dim getSQL As String

        lWhere = lWhere & " AND (SaleItem_Revoke=True)"
        'If chkReversal.value Then lWhere = lWhere & " AND (SaleItem_Reversal=True)"
        'If chkFC.value Then lWhere = lWhere & " AND (Sale_PaymentType=8)"

        'lString = ""
        'For x = 0 To Me.lstChannel.ListCount - 1
        '    If Me.lstChannel.Selected(x) Then
        '        lString = lString & " OR Sale_ChannelID=" & lstChannel.ItemData(x)
        '    End If
        'Next x
        'If lString <> "" Then
        '    lString = " AND (" & Mid(lString, 4) & ")"
        '    lWhere = lWhere & lString
        'End If

        'lString = ""
        'For x = 0 To Me.lstPerson.ListCount - 1
        '    If Me.lstPerson.Selected(x) Then
        '        lString = lString & " OR Sale_PersonID=" & lstPerson.ItemData(x)
        '    End If
        'Next x
        'If lString <> "" Then
        '    lString = " AND (" & Mid(lString, 4) & ")"
        '    lWhere = lWhere & lString
        'End If

        'lString = ""
        'For x = 0 To Me.lstPOS.ListCount - 1
        '    If Me.lstPOS.Selected(x) Then
        '        lString = lString & " OR Sale_POSID=" & lstPOS.ItemData(x)
        '    End If
        'Next x
        'If lString <> "" Then
        '    lString = " AND (" & Mid(lString, 4) & ")"
        '    lWhere = lWhere & lString
        'End If

        'lString = ""
        'gl = False
        'For x = 0 To Me.lstSaleref.ListCount - 1
        '    If Me.lstSaleref.Selected(x) Then
        '        If x = 0 Then
        '          lString = lString & " Sale_CardRef <>''"
        '          gl = True
        '        ElseIf x = 1 Then
        '          If gl = True Then
        '             lString = lString & " OR Sale_OrderRef <>''"
        '          Else
        '             lString = lString & " Sale_OrderRef <>''"
        '             gl = True
        '          End If
        '        ElseIf x = 2 Then
        '           If gl = True Then
        '            lString = lString & " OR Sale_SerialRef <>''"
        '           Else
        '            lString = lString & " Sale_SerialRef <>''"
        '           End If
        '        End If
        '    End If
        'Next x
        'If lString <> "" Then
        '    lString = " AND (" & Mid(lString, 2) & ")"
        '    lWhere = lWhere & lString
        'End If

        If lWhere <> "" Then lWhere = " WHERE " & Mid(lWhere, 6)

        sql = "SELECT DISTINCT Sale.*, aConsignment.*, aCustomer.Customer_InvoiceName, aChannel.Channel_Name, aPerson.Person_FirstName & ' ' & aPerson.Person_LastName AS PersonName, aPerson.Person_Comm, aPerson1.Person_FirstName & ' ' & aPerson1.Person_LastName AS MgrName FROM (SaleItem INNER JOIN ((aChannel INNER JOIN (aCustomer RIGHT JOIN (CustomerTransaction RIGHT JOIN (aConsignment RIGHT JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID) ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID) ON aChannel.ChannelID = Sale.Sale_ChannelID) INNER JOIN aPerson ON Sale.Sale_PersonID = aPerson.PersonID) ON SaleItem.SaleItem_SaleID = Sale.SaleID) LEFT JOIN aPerson1 ON Sale.Sale_ManagerID = aPerson1.PersonID "
        sql = sql & lWhere

        getSQL = sql
        ' to get getSQL

        'Report = New cryPOSreportRevoke
        Report.Load("cryPOSreportRevoke.rpt")

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name From aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        rs.Close()

        rs = getRSreport(getSQL)

        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        sql = "SELECT SaleItem.*, IIf([SaleItem_DepositType]=1,[Deposit_Name]+'-bottle',IIf([SaleItem_DepositType]=2,[Deposit_Name]+'-Crate',[Deposit_Name]+'-Case')) AS StockItem_Name FROM SaleItem INNER JOIN aDeposit ON SaleItem.SaleItem_StockItemID = aDeposit.DepositID Where (((SaleItem.SaleItem_DepositType) <> 0)) Union "
        sql = sql & "SELECT SaleItem.*, aStockItem.StockItem_Name FROM SaleItem INNER JOIN aStockItem ON SaleItem.SaleItem_StockItemID = aStockItem.StockItemID Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_Recipe) = 0)) Union "
        sql = sql & "SELECT SaleItem.*, aRecipe.Recipe_Name AS StockItem_Name FROM SaleItem INNER JOIN aRecipe ON SaleItem.SaleItem_StockItemID = aRecipe.RecipeID WHERE (((SaleItem.SaleItem_DepositType)=0) AND ((SaleItem.SaleItem_Recipe)<>0));"

        sql = "SELECT SaleItem.*, IIf([SaleItem_DepositType]=1,[Deposit_Name]+'-bottle',IIf([SaleItem_DepositType]=2,[Deposit_Name]+'-Crate',[Deposit_Name]+'-Case')) AS StockItem_Name FROM SaleItem INNER JOIN aDeposit ON SaleItem.SaleItem_StockItemID = aDeposit.DepositID Where (((SaleItem.SaleItem_DepositType) <> 0) AND ((SaleItem.SaleItem_Revoke) <> 0)) Union SELECT SaleItem.*, aStockItem.StockItem_Name FROM SaleItem INNER JOIN aStockItem ON SaleItem.SaleItem_StockItemID = aStockItem.StockItemID Where (((SaleItem.SaleItem_DepositType) = 0) AND ((SaleItem.SaleItem_Revoke) <> 0))"
        rsData = getRSreport(sql)

        If rsData.BOF Or rsData.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        'If emp_Clicked = True Then
        '   SumSales = 0
        '   Do While rs.EOF = False
        '      SumSales = SumSales + rs("Sale_Total")
        '      rs.moveNext
        '   Loop
        '      'Resise to excluding vat
        '      SumSales = SumSales - (SumSales * 0.14)
        '      rs.MoveFirst
        '      Report.txtComm.SetText rs("Person_Comm")
        '      Report.txtTotalCommision.SetText FormatNumber((SumSales * rs("Person_Comm")) / 100, 2)
        'End If

        Report.Database.Tables(1).SetDataSource(rs)
        Report.Database.Tables(2).SetDataSource(rsData)
        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtComm").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Private Sub report_ProductPerformanceGRVDeals()
        Dim rs As ADODB.Recordset
        Dim sql As String
        Dim rsData As ADODB.Recordset
        'Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        Dim lOrder As String
        'Dim CRXDatabaseField As CrystalDecisions.CrystalReports.Engine.DatabaseFieldDefinition
        Dim CRXDatabaseField As CrystalDecisions.CrystalReports.Engine.FieldDefinition

        '    Dim lEmpID As Long
        '
        '    lEmpID = 0
        '    If MsgBox("Do you wish to see report for all Customers?", vbInformation + vbYesNo) = vbYes Then
        '    Else
        '        lEmpID = frmCustomerList.getItem(8)
        '        If lEmpID = 0 Then Exit Sub
        '    End If

        lOrder = "StockItem_Name"
        lOrder = " ORDER BY " & lOrder

        Report = Nothing
        Report.Load("cryStockitemTopGroupGRVDeal")
        'Report = New cryStockitemTopGroupGRVDeal

        Do While Report.DataDefinition.SortFields.Count
            ''Report.RecordSortFields.delete(1)
        Loop

        'Screen.MousePointer = vbHourglass
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        rs.Close()

        '    sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockListCustomer.inclusiveSum) AS inclusive, Sum(StockListCustomer.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockListCustomer.quantitySum) AS quantity, Sum(StockListCustomer.listCostSum) AS listCost, Sum(StockListCustomer.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department, StockListCustomer.CustomerTransaction_CustomerID "
        '    sql = sql & "FROM StockListCustomer INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListCustomer.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, StockListCustomer.CustomerTransaction_CustomerID HAVING (((StockListCustomer.CustomerTransaction_CustomerID)=" & lEmpID & ")) "
        '
        '    sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockListCustomerByGroup.inclusiveSum AS inclusive, StockListCustomerByGroup.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockListCustomerByGroup.quantitySum AS quantity, StockListCustomerByGroup.listCostSum AS listCost, StockListCustomerByGroup.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department, StockListCustomerByGroup.CustomerTransaction_CustomerID, StockListCustomerByGroup.Customer_InvoiceName, StockListCustomerByGroup.DayEndID, StockListCustomerByGroup.DayEnd_Date " ', StockListCustomerByGroup.CustomerTransactionID "
        '    sql = sql & "FROM StockListCustomerByGroup INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListCustomerByGroup.SaleItem_StockItemID = aStockItem1.StockItemID "
        '    sql = sql & "WHERE (((StockListCustomerByGroup.quantitySum)<>" & 0 & ")) "
        '    If lEmpID > 0 Then sql = sql & "AND (((StockListCustomerByGroup.CustomerTransaction_CustomerID)=" & lEmpID & ")) "
        '
        '    sql = Replace(sql, "StockGroup", "PricingGroup")
        '    Report.txtTitle.SetText "Product Performance - by Pricing Group"
        '    sql = sql & lOrder

        Dim lStkID As Integer

        lStkID = 0
        If MsgBox("Do you wish to see report for all Stock Items?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        Else
            lStkID = frmStockList.getItem()
            If lStkID = 0 Then Exit Sub
        End If

        sql = "SELECT aGRVItem.GRVItem_GRVID, aGRVItem.GRVItem_StockItemID, aGRVItem.GRVItem_Name, aGRVItem.GRVItem_QuantityOrder, aGRVItem.GRVItem_Quantity, aGRVItem.GRVItem_ContentCost, aGRV.GRV_InvoiceDate, Supplier.Supplier_Name, aGRVItem.GRVItem_ContentCost*aGRVItem.GRVItem_Quantity AS Expr1,"
        sql = sql & " (SELECT aGRVPromotionItem1.PromotionItem_Price FROM aGRVPromotion1 INNER JOIN aGRVPromotionItem1 ON aGRVPromotion1.PromotionID = aGRVPromotionItem1.PromotionItem_PromotionID WHERE (((aGRVPromotionItem1.PromotionItem_StockItemID)=aGRVItem.GRVItem_StockItemID) AND ((aGRVPromotion1.Promotion_StartDate)<=aGRV.GRV_InvoiceDate) AND ((aGRVPromotion1.Promotion_EndDate)>=aGRV.GRV_InvoiceDate))) AS DealPrice,"
        sql = sql & " (SELECT aGRVPromotion1.Promotion_Name FROM aGRVPromotion1 INNER JOIN aGRVPromotionItem1 ON aGRVPromotion1.PromotionID = aGRVPromotionItem1.PromotionItem_PromotionID WHERE (((aGRVPromotionItem1.PromotionItem_StockItemID)=aGRVItem.GRVItem_StockItemID) AND ((aGRVPromotion1.Promotion_StartDate)<=aGRV.GRV_InvoiceDate) AND ((aGRVPromotion1.Promotion_EndDate)>=aGRV.GRV_InvoiceDate))) AS DealName,"
        sql = sql & " aPurchaseOrder.PurchaseOrder_DateCreated, aGRV.GRV_Date FROM Report, (aGRVItem INNER JOIN aGRV ON aGRVItem.GRVItem_GRVID = aGRV.GRVID) INNER JOIN (aPurchaseOrder INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID) ON aGRV.GRV_PurchaseOrderID = aPurchaseOrder.PurchaseOrderID"
        '    sql = sql & " Where (((aGRVItem.GRVItem_StockItemID) = 698))"
        If lStkID = 0 Then
            sql = sql & " WHERE (((aGRV.GRV_DayEndID)>=[Report]![Report_DayEndStartID] And (aGRV.GRV_DayEndID)<=[Report]![Report_DayEndEndID]))"
        Else
            sql = sql & " WHERE (((aGRVItem.GRVItem_StockItemID) = " & lStkID & ") AND ((aGRV.GRV_DayEndID)>=[Report]![Report_DayEndStartID] And (aGRV.GRV_DayEndID)<=[Report]![Report_DayEndEndID]))"
        End If
        sql = sql & " ORDER BY aGRVItem.GRVItem_ContentCost;"

        Debug.Print(sql)
        rs = getRSreport(sql)
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        'Report.VerifyOnEveryPrint = True
        Report.Database.Tables(1).SetDataSource(rs)
        Report.SetDataSource(rs)
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Private Sub report_ProductPerformanceCustomerByGroup()
        Dim rs As ADODB.Recordset
        Dim sql As String
        Dim rsData As ADODB.Recordset
        'Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        Dim lOrder As String
        Dim CRXDatabaseField As CrystalDecisions.CrystalReports.Engine.FieldDefinition
        'Dim CRXDatabaseField As CrystalDecisions.CrystalReports.Engine.DatabaseFieldDefinition

        Dim lEmpID As Integer

        lEmpID = 0
        If MsgBox("Do you wish to see report for all Customers?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        Else
            lEmpID = frmCustomerList.getItem(8)
            If lEmpID = 0 Then Exit Sub
        End If

        'Select Case Me.cmbSortField.ListIndex
        '        Case 0
        lOrder = "StockItem_Name"
        '        Case 1
        '            lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
        '        Case 2
        '            lOrder = "[exclusiveSum]-[depositSum]"
        '        Case 3
        '            lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
        '        Case 4
        '            lOrder = "IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum])"
        '        Case 5
        '            lOrder = "StockList.quantitySum"
        'End Select

        'If Me.cmbSort.ListIndex Then lOrder = lOrder & " DESC"
        lOrder = " ORDER BY " & lOrder

        'UPGRADE_NOTE: Object Report may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        Report = Nothing

        'If Me.optType(0).value Then
        '    Set Report = New cryStockitemTopCustomer
        'ElseIf Me.optType(1).value Then
        '    Set Report = New cryStockitemTopByGroup
        'Else
        'Report = New cryStockitemTopGroupCustomer
        Report.Load("cryStockitemTopGroupCustomer.rpt")
        'End If
        'Do While Report.DataDefinition.SortFields.Count
        ' 'Report.RecordSortFields.delete(1)
        ' Loop

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        rs.Close()

        'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtFilter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If lEmpID = 0 Then Report.SetParameterValue("txtFilter", "All Customers")
        If lEmpID > 0 Then
            rs = getRS("SELECT Customer.Customer_InvoiceName AS MgrName From Customer WHERE (((Customer.CustomerID)=" & lEmpID & "));")
            Report.SetParameterValue("txtFilter", IIf(lEmpID = 0, "All Customers", rs.Fields("MgrName").Value))
        End If
        'Set rs = getRSreport("SELECT * FROM Link Where LinkID=2 AND Link_SectionID=1")
        'Report.txtFilter.SetText Replace(rs("Link_Name"), "''", "'")

        'If Me.optType(0).value Then
        '    If rs("Link_SQL") <> "" Then
        '        sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
        '    Else
        '        Select Case Me.cmbSortField.ListIndex
        '            Case 0
        'sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        'sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
        sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockListCustomer.inclusiveSum) AS inclusive, Sum(StockListCustomer.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockListCustomer.quantitySum) AS quantity, Sum(StockListCustomer.listCostSum) AS listCost, Sum(StockListCustomer.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department, StockListCustomer.CustomerTransaction_CustomerID "
        sql = sql & "FROM StockListCustomer INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListCustomer.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, StockListCustomer.CustomerTransaction_CustomerID HAVING (((StockListCustomer.CustomerTransaction_CustomerID)=" & lEmpID & ")) "

        sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockListCustomerByGroup.inclusiveSum AS inclusive, StockListCustomerByGroup.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockListCustomerByGroup.quantitySum AS quantity, StockListCustomerByGroup.listCostSum AS listCost, StockListCustomerByGroup.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department, StockListCustomerByGroup.CustomerTransaction_CustomerID, StockListCustomerByGroup.Customer_InvoiceName, StockListCustomerByGroup.DayEndID, StockListCustomerByGroup.DayEnd_Date " ', StockListCustomerByGroup.CustomerTransactionID "
        sql = sql & "FROM StockListCustomerByGroup INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListCustomerByGroup.SaleItem_StockItemID = aStockItem1.StockItemID "
        sql = sql & "WHERE (((StockListCustomerByGroup.quantitySum)<>" & 0 & ")) "
        'sql = sql & "GROUP BY aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockListCustomerByGroup.inclusiveSum, StockListCustomerByGroup.exclusiveSum, [exclusiveSum]-[depositSum], [exclusiveSum]-[depositSum], [exclusiveSum]-[depositSum]-[listCostSum], [exclusiveSum]-[depositSum]-[actualCostSum], StockListCustomerByGroup.quantitySum, StockListCustomerByGroup.listCostSum, StockListCustomerByGroup.actualCostSum, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0), IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0), aPricingGroup.PricingGroup_Name, StockListCustomerByGroup.CustomerTransaction_CustomerID, StockListCustomerByGroup.Customer_InvoiceName, StockListCustomerByGroup.DayEndID, StockListCustomerByGroup.DayEnd_Date, StockListCustomerByGroup.CustomerTransactionID "
        If lEmpID > 0 Then sql = sql & "AND (((StockListCustomerByGroup.CustomerTransaction_CustomerID)=" & lEmpID & ")) "
        '            Case 1
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) "
        '                'lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
        '            Case 2
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]) "
        '                'lOrder = "[exclusiveSum]-[depositSum]"
        '            Case 3
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) "
        '                'lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
        '            Case 4
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]) "
        '                'lOrder = "IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum])"
        '            Case 5
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, StockList.quantitySum "
        '                'lOrder = "StockList.quantitySum"
        '        End Select
        '    End If
        '
        'ElseIf Me.optType(1).value Then
        '    If rs("Link_SQL") <> "" Then
        '        sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
        '    Else
        '        Select Case Me.cmbSortField.ListIndex
        '            Case 0
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
        '            Case 1
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) "
        '                'lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
        '            Case 2
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]) "
        '                'lOrder = "[exclusiveSum]-[depositSum]"
        '            Case 3
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) "
        '                'lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
        '            Case 4
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]) "
        '                'lOrder = "IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum])"
        '            Case 5
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, StockList.quantitySum "
        '                'lOrder = "StockList.quantitySum"
        '        End Select
        '        'sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '        'sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
        '    End If
        '    Select Case Me.cmbGroup.ListIndex
        '        Case 0
        sql = Replace(sql, "StockGroup", "PricingGroup")
        Report.SetParameterValue("txtTitle", "Product Performance - by Pricing Group")
        '        Case 1
        '            Report.txtTitle.SetText "Product Performance - by Stock Group"
        '        Case 2
        '            sql = Replace(sql, "StockGroup", "Supplier")
        '            sql = Replace(sql, "aSupplier", "Supplier")
        '            Report.txtTitle.SetText "Product Performance - by Supplier"
        '        Case 3
        '            sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aReportGroup1.ReportGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aReportGroup1 ON aStockItem1.StockItem_ReportID = aReportGroup1.ReportID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
        '            Report.txtTitle.SetText "Product Performance - by Report Group"
        '    End Select
        '
        '    If Me.chkPageBreak.value Then
        '        Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = True
        '    Else
        '        Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = False
        '    End If
        '
        'Else
        '    'If rs("Link_SQL") <> "" Then
        '        sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
        '    'Else
        '    '    sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '    '    sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
        '    'End If
        '    Select Case Me.cmbGroup.ListIndex
        '        Case 0
        '            sql = Replace(sql, "StockGroup", "PricingGroup")
        '            Report.txtTitle.SetText "Product Performance - by Pricing Group"
        '        Case 1
        '            Report.txtTitle.SetText "Product Performance - by Stock Group"
        '        Case 2
        '            sql = Replace(sql, "StockGroup", "Supplier")
        '            sql = Replace(sql, "aSupplier", "Supplier")
        '            Report.txtTitle.SetText "Product Performance - by Supplier"
        '        Case 3
        '            sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aReportGroup1.ReportGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aReportGroup1 ON aStockItem1.StockItem_ReportID = aReportGroup1.ReportID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
        '            Report.txtTitle.SetText "Product Performance - by Report Group"
        '    End Select

        '    If Me.chkPageBreak.value Then
        '        Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = True
        '    Else
        '        Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = False
        '    End If
        'End If

        'for customer
        'SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aCustomer.Customer_InvoiceName AS department
        'FROM aCustomer INNER JOIN (CustomerTransaction INNER JOIN (Sale INNER JOIN (SaleItem INNER JOIN (StockList INNER JOIN aStockItem1 ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID) ON SaleItem.SaleItem_StockItemID = StockList.SaleItem_StockItemID) ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID
        'WHERE (((aCustomer.CustomerID)=2) AND ((CustomerTransaction.CustomerTransaction_TransactionTypeID)=2)) OR (((CustomerTransaction.CustomerTransaction_TransactionTypeID)=3));

        'If rs("Link_SQL") = "" Then
        'Else
        '    sql = sql & rs("Link_SQL")
        'End If

        sql = sql & lOrder
        Debug.Print(sql)
        rs = getRSreport(sql)

        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        'Report.VerifyOnEveryPrint = True
        Report.Database.Tables(1).SetDataSource(rs)
        Report.SetDataSource(rs)
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Private Sub report_ProductPerformanceCustomer()
        Dim rs As ADODB.Recordset
        Dim sql As String
        Dim rsData As ADODB.Recordset
        'Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        Dim lOrder As String
        Dim CRXDatabaseField As CrystalDecisions.CrystalReports.Engine.FieldDefinition
        'Dim CRXDatabaseField As CrystalDecisions.CrystalReports.Engine.DatabaseFieldDefinition

        Dim lEmpID As Integer

        lEmpID = frmCustomerList.getItem(8)
        If lEmpID = 0 Then Exit Sub

        'Select Case Me.cmbSortField.ListIndex
        '        Case 0
        lOrder = "StockItem_Name"
        '        Case 1
        '            lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
        '        Case 2
        '            lOrder = "[exclusiveSum]-[depositSum]"
        '        Case 3
        '            lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
        '        Case 4
        '            lOrder = "IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum])"
        '        Case 5
        '            lOrder = "StockList.quantitySum"
        'End Select

        'If Me.cmbSort.ListIndex Then lOrder = lOrder & " DESC"
        lOrder = " ORDER BY " & lOrder

        'UPGRADE_NOTE: Object Report may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        Report = Nothing

        'If Me.optType(0).value Then
        Report.Load("cryStockitemTopCustomer.rpt")
        'ElseIf Me.optType(1).value Then
        '    Set Report = New cryStockitemTopByGroup
        'Else
        '    Set Report = New cryStockitemTopGroup
        'End If
        '[Do While Report.DataDefinition.SortFields.Count
        ' 'Report.RecordSortFields.delete(1)
        ' Loop

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        rs.Close()

        If lEmpID > 0 Then
            rs = getRS("SELECT Customer.Customer_InvoiceName AS MgrName From Customer WHERE (((Customer.CustomerID)=" & lEmpID & "));")
            Report.SetParameterValue("txtFilter", rs.Fields("MgrName"))
        End If
        'Set rs = getRSreport("SELECT * FROM Link Where LinkID=2 AND Link_SectionID=1")
        'Report.txtFilter.SetText Replace(rs("Link_Name"), "''", "'")

        'If Me.optType(0).value Then
        '    If rs("Link_SQL") <> "" Then
        '        sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
        '    Else
        '        Select Case Me.cmbSortField.ListIndex
        '            Case 0
        'sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        'sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
        sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockListCustomer.inclusiveSum) AS inclusive, Sum(StockListCustomer.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockListCustomer.quantitySum) AS quantity, Sum(StockListCustomer.listCostSum) AS listCost, Sum(StockListCustomer.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department, StockListCustomer.CustomerTransaction_CustomerID "
        sql = sql & "FROM StockListCustomer INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListCustomer.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, StockListCustomer.CustomerTransaction_CustomerID HAVING (((StockListCustomer.CustomerTransaction_CustomerID)=" & lEmpID & ")) "

        '            Case 1
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) "
        '                'lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
        '            Case 2
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]) "
        '                'lOrder = "[exclusiveSum]-[depositSum]"
        '            Case 3
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) "
        '                'lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
        '            Case 4
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]) "
        '                'lOrder = "IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum])"
        '            Case 5
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, StockList.quantitySum "
        '                'lOrder = "StockList.quantitySum"
        '        End Select
        '    End If
        '
        'ElseIf Me.optType(1).value Then
        '    If rs("Link_SQL") <> "" Then
        '        sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
        '    Else
        '        Select Case Me.cmbSortField.ListIndex
        '            Case 0
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
        '            Case 1
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) "
        '                'lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
        '            Case 2
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]) "
        '                'lOrder = "[exclusiveSum]-[depositSum]"
        '            Case 3
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) "
        '                'lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
        '            Case 4
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]) "
        '                'lOrder = "IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum])"
        '            Case 5
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, StockList.quantitySum "
        '                'lOrder = "StockList.quantitySum"
        '        End Select
        '        'sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '        'sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
        '    End If
        '    Select Case Me.cmbGroup.ListIndex
        '        Case 0
        '            sql = Replace(sql, "StockGroup", "PricingGroup")
        '            Report.txtTitle.SetText "Product Performance - by Pricing Group"
        '        Case 1
        '            Report.txtTitle.SetText "Product Performance - by Stock Group"
        '        Case 2
        '            sql = Replace(sql, "StockGroup", "Supplier")
        '            sql = Replace(sql, "aSupplier", "Supplier")
        '            Report.txtTitle.SetText "Product Performance - by Supplier"
        '        Case 3
        '            sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aReportGroup1.ReportGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aReportGroup1 ON aStockItem1.StockItem_ReportID = aReportGroup1.ReportID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
        '            Report.txtTitle.SetText "Product Performance - by Report Group"
        '    End Select
        '
        '    If Me.chkPageBreak.value Then
        '        Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = True
        '    Else
        '        Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = False
        '    End If
        '
        'Else
        '    'If rs("Link_SQL") <> "" Then
        '        sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
        '    'Else
        '    '    sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '    '    sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
        '    'End If
        '    Select Case Me.cmbGroup.ListIndex
        '        Case 0
        '            sql = Replace(sql, "StockGroup", "PricingGroup")
        '            Report.txtTitle.SetText "Product Performance - by Pricing Group"
        '        Case 1
        '            Report.txtTitle.SetText "Product Performance - by Stock Group"
        '        Case 2
        '            sql = Replace(sql, "StockGroup", "Supplier")
        '            sql = Replace(sql, "aSupplier", "Supplier")
        '            Report.txtTitle.SetText "Product Performance - by Supplier"
        '        Case 3
        '            sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aReportGroup1.ReportGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aReportGroup1 ON aStockItem1.StockItem_ReportID = aReportGroup1.ReportID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
        '            Report.txtTitle.SetText "Product Performance - by Report Group"
        '    End Select

        '    If Me.chkPageBreak.value Then
        '        Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = True
        '    Else
        '        Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = False
        '    End If
        'End If

        'for customer
        'SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aCustomer.Customer_InvoiceName AS department
        'FROM aCustomer INNER JOIN (CustomerTransaction INNER JOIN (Sale INNER JOIN (SaleItem INNER JOIN (StockList INNER JOIN aStockItem1 ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID) ON SaleItem.SaleItem_StockItemID = StockList.SaleItem_StockItemID) ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID
        'WHERE (((aCustomer.CustomerID)=2) AND ((CustomerTransaction.CustomerTransaction_TransactionTypeID)=2)) OR (((CustomerTransaction.CustomerTransaction_TransactionTypeID)=3));

        'If rs("Link_SQL") = "" Then
        'Else
        '    sql = sql & rs("Link_SQL")
        'End If

        sql = sql & lOrder
        Debug.Print(sql)
        rs = getRSreport(sql)

        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        'Report.VerifyOnEveryPrint = True
        Report.Database.Tables(1).SetDataSource(rs)
        Report.SetDataSource(rs)
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Private Sub report_ProductPerformanceEmployee()
        Dim rs As ADODB.Recordset
        Dim sql As String
        Dim rsData As ADODB.Recordset
        'Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        Dim lOrder As String
        'Dim CRXDatabaseField As CrystalDecisions.CrystalReports.Engine.DatabaseFieldDefinition

        Dim lEmpID As Integer

        lEmpID = frmPersonList.getItem
        If lEmpID = 0 Then Exit Sub

        'Select Case Me.cmbSortField.ListIndex
        '        Case 0
        lOrder = "StockItem_Name"
        '        Case 1
        '            lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
        '        Case 2
        '            lOrder = "[exclusiveSum]-[depositSum]"
        '        Case 3
        '            lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
        '        Case 4
        '            lOrder = "IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum])"
        '        Case 5
        '            lOrder = "StockList.quantitySum"
        'End Select

        'If Me.cmbSort.ListIndex Then lOrder = lOrder & " DESC"
        lOrder = " ORDER BY " & lOrder

        'UPGRADE_NOTE: Object Report may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        Report = Nothing

        'If Me.optType(0).value Then
        Report.Load("cryStockitemTopEmployee.rpt")
        'ElseIf Me.optType(1).value Then
        '    Set Report = New cryStockitemTopByGroup
        'Else
        '    Set Report = New cryStockitemTopGroup
        'End If
        'Do While Report.DataDefinition.SortFields.Count
        ''Report.RecordSortFields.delete(1)
        'Loop

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        rs.Close()

        If lEmpID > 0 Then
            rs = getRS("SELECT Person.Person_FirstName & ' ' & Person.Person_LastName AS MgrName From Person WHERE (((Person.PersonID)=" & lEmpID & "));")
            Report.SetParameterValue("txtFilter", rs.Fields("MgrName"))
        End If
        'Set rs = getRSreport("SELECT * FROM Link Where LinkID=2 AND Link_SectionID=1")
        'Report.txtFilter.SetText Replace(rs("Link_Name"), "''", "'")

        'If Me.optType(0).value Then
        '    If rs("Link_SQL") <> "" Then
        '        sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
        '    Else
        '        Select Case Me.cmbSortField.ListIndex
        '            Case 0
        'sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        'sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
        sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockListEmployee.inclusiveSum) AS inclusive, Sum(StockListEmployee.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockListEmployee.quantitySum) AS quantity, Sum(StockListEmployee.listCostSum) AS listCost, Sum(StockListEmployee.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department, StockListEmployee.Sale_PersonID "
        sql = sql & "FROM StockListEmployee INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockListEmployee.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, StockListEmployee.Sale_PersonID Having (((StockListEmployee.Sale_PersonID) = " & lEmpID & ")) "

        '            Case 1
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) "
        '                'lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
        '            Case 2
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]) "
        '                'lOrder = "[exclusiveSum]-[depositSum]"
        '            Case 3
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) "
        '                'lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
        '            Case 4
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]) "
        '                'lOrder = "IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum])"
        '            Case 5
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, StockList.quantitySum "
        '                'lOrder = "StockList.quantitySum"
        '        End Select
        '    End If
        '
        'ElseIf Me.optType(1).value Then
        '    If rs("Link_SQL") <> "" Then
        '        sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
        '    Else
        '        Select Case Me.cmbSortField.ListIndex
        '            Case 0
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
        '            Case 1
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) "
        '                'lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
        '            Case 2
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]) "
        '                'lOrder = "[exclusiveSum]-[depositSum]"
        '            Case 3
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, ([exclusiveSum]-[depositSum]-[listCostSum]) "
        '                'lOrder = "[exclusiveSum]-[depositSum]-[listCostSum]"
        '            Case 4
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]) "
        '                'lOrder = "IIf([exclusiveSum]=0,0,([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum])"
        '            Case 5
        '                sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '                sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name, StockList.quantitySum "
        '                'lOrder = "StockList.quantitySum"
        '        End Select
        '        'sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '        'sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
        '    End If
        '    Select Case Me.cmbGroup.ListIndex
        '        Case 0
        '            sql = Replace(sql, "StockGroup", "PricingGroup")
        '            Report.txtTitle.SetText "Product Performance - by Pricing Group"
        '        Case 1
        '            Report.txtTitle.SetText "Product Performance - by Stock Group"
        '        Case 2
        '            sql = Replace(sql, "StockGroup", "Supplier")
        '            sql = Replace(sql, "aSupplier", "Supplier")
        '            Report.txtTitle.SetText "Product Performance - by Supplier"
        '        Case 3
        '            sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aReportGroup1.ReportGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aReportGroup1 ON aStockItem1.StockItem_ReportID = aReportGroup1.ReportID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
        '            Report.txtTitle.SetText "Product Performance - by Report Group"
        '    End Select
        '
        '    If Me.chkPageBreak.value Then
        '        Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = True
        '    Else
        '        Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = False
        '    End If
        '
        'Else
        '    'If rs("Link_SQL") <> "" Then
        '        sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aStockGroup.StockGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
        '    'Else
        '    '    sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, Sum(StockList.inclusiveSum) AS inclusive, Sum(StockList.exclusiveSum) AS exclusive, Sum([exclusiveSum]-[depositSum]) AS price, Sum([exclusiveSum]-[depositSum]) AS content, Sum([exclusiveSum]-[depositSum]-[listCostSum]) AS listProfit, Sum([exclusiveSum]-[depositSum]-[actualCostSum]) AS actualProfit, Sum(StockList.quantitySum) AS quantity, Sum(StockList.listCostSum) AS listCost, Sum(StockList.actualCostSum) AS actualCost, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0)) AS gpActual, Sum(IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0)) AS gpList, aStockGroup.StockGroup_Name AS department "
        '    '    sql = sql & "FROM StockList INNER JOIN (aStockItem1 INNER JOIN aStockGroup ON aStockItem1.StockItem_StockGroupID = aStockGroup.StockGroupID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID GROUP BY  aStockItem1.StockItemID, aStockItem1.StockItem_Name, aStockGroup.StockGroup_Name "
        '    'End If
        '    Select Case Me.cmbGroup.ListIndex
        '        Case 0
        '            sql = Replace(sql, "StockGroup", "PricingGroup")
        '            Report.txtTitle.SetText "Product Performance - by Pricing Group"
        '        Case 1
        '            Report.txtTitle.SetText "Product Performance - by Stock Group"
        '        Case 2
        '            sql = Replace(sql, "StockGroup", "Supplier")
        '            sql = Replace(sql, "aSupplier", "Supplier")
        '            Report.txtTitle.SetText "Product Performance - by Supplier"
        '        Case 3
        '            sql = "SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aReportGroup1.ReportGroup_Name AS department FROM StockList INNER JOIN (aStockItem1 INNER JOIN aReportGroup1 ON aStockItem1.StockItem_ReportID = aReportGroup1.ReportID) ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID "
        '            Report.txtTitle.SetText "Product Performance - by Report Group"
        '    End Select

        '    If Me.chkPageBreak.value Then
        '        Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = True
        '    Else
        '        Report.ReportDefinition.Sections(5).SectionFormat.EnableNewPageAfter = False
        '    End If
        'End If

        'for customer
        'SELECT aStockItem1.StockItemID, aStockItem1.StockItem_Name, StockList.inclusiveSum AS inclusive, StockList.exclusiveSum AS exclusive, [exclusiveSum]-[depositSum] AS price, [exclusiveSum]-[depositSum] AS content, [exclusiveSum]-[depositSum]-[listCostSum] AS listProfit, [exclusiveSum]-[depositSum]-[actualCostSum] AS actualProfit, StockList.quantitySum AS quantity, StockList.listCostSum AS listCost, StockList.actualCostSum AS actualCost, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[actualCostSum])/[exclusiveSum]*100,0) AS gpActual, IIf([exclusiveSum],([exclusiveSum]-[depositSum]-[listCostSum])/[exclusiveSum]*100,0) AS gpList, aCustomer.Customer_InvoiceName AS department
        'FROM aCustomer INNER JOIN (CustomerTransaction INNER JOIN (Sale INNER JOIN (SaleItem INNER JOIN (StockList INNER JOIN aStockItem1 ON StockList.SaleItem_StockItemID = aStockItem1.StockItemID) ON SaleItem.SaleItem_StockItemID = StockList.SaleItem_StockItemID) ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aCustomer.CustomerID = CustomerTransaction.CustomerTransaction_CustomerID
        'WHERE (((aCustomer.CustomerID)=2) AND ((CustomerTransaction.CustomerTransaction_TransactionTypeID)=2)) OR (((CustomerTransaction.CustomerTransaction_TransactionTypeID)=3));

        'If rs("Link_SQL") = "" Then
        'Else
        '    sql = sql & rs("Link_SQL")
        'End If

        sql = sql & lOrder
        Debug.Print(sql)
        rs = getRSreport(sql)

        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        'Report.VerifyOnEveryPrint = True
        Report.Database.Tables(1).SetDataSource(rs)
        Report.SetDataSource(rs)
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Private Sub report_WaitronTotals()
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryWaitronTotals
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryWaitronTotals.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        rs.Close()
        'Set rs = getRSreport("SELECT Sum(Sale.Sale_Total) AS amount, Sum(Sale.Sale_Cash) AS amountSale_Cash, Sum(Sale.Sale_Card) AS amountSale_Card, Sum(Sale.Sale_Cheque) AS amountSale_Cheque, Sum(Sale.Sale_CDebit) AS amountSale_CDebit, Count(Sale.SaleID) AS [count], Sum(Sale.Sale_Tender) AS tender, [Person_FirstName] & ' ' & [Person_LastName] AS personName, Count(Sale.Sale_TableNumber) AS tableCount, Sum(Sale.Sale_GuestCount) AS guestCount FROM (aPOS INNER JOIN Sale ON aPOS.POSID = Sale.Sale_PosID) INNER JOIN aPerson ON Sale.Sale_PersonID = aPerson.PersonID Where (((Sale.Sale_PersonID) > 0)) GROUP BY [Person_FirstName] & ' ' & [Person_LastName];")

        sql = "SELECT (Sum(Sale.Sale_Cash-iif(Sale.Sale_Cash>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0))+Sum(Sale.Sale_Card-iif(Sale.Sale_Card>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0))+Sum(Sale.Sale_Cheque-iif(Sale.Sale_Cheque>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0))+Sum(Sale.Sale_CDebit-iif(Sale.Sale_CDebit>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0))) AS amount, Sum(Sale.Sale_Cash-iif(Sale.Sale_Cash>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0)) AS amountSale_Cash, Sum(Sale.Sale_Card-iif(Sale.Sale_Card>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0)) AS amountSale_Card, "
        sql = sql & "Sum(Sale.Sale_Cheque-iif(Sale.Sale_Cheque>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0)) AS amountSale_Cheque, Sum(Sale.Sale_CDebit-iif(Sale.Sale_CDebit>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0)) AS amountSale_CDebit, Count(Sale.SaleID) AS [count], Sum(Sale.Sale_Tender) AS tender, [Person_FirstName] & ' ' & [Person_LastName] AS personName, Count(Sale.Sale_TableNumber) AS tableCount, Sum(Sale.Sale_GuestCount) AS guestCount, Sum(Sale.Sale_Gratuity) AS amountSale_Gratuity, Sum(Sale.Sale_CDebit) AS amountTenderSale_CDebit, Sum(Sale.Sale_Total) AS amountTotal FROM (aPOS INNER JOIN Sale ON aPOS.POSID = Sale.Sale_PosID) INNER JOIN aPerson ON Sale.Sale_PersonID = aPerson.PersonID Where (((Sale.Sale_PersonID) > 0)) GROUP BY [Person_FirstName] & ' ' & [Person_LastName];"
        Debug.Print(sql)

        sql = "SELECT (Sum(Sale.Sale_Cash-IIf(Sale.Sale_Cash>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0))+Sum(Sale.Sale_Card-IIf(Sale.Sale_Card>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0))+Sum(Sale.Sale_Cheque-IIf(Sale.Sale_Cheque>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0))+Sum(Sale.Sale_CDebit-IIf(Sale.Sale_CDebit>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0))) AS amount, Sum(Sale.Sale_Cash-IIf(Sale.Sale_Cash>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0)) AS amountSale_Cash, Sum(Sale.Sale_Card-IIf(Sale.Sale_Card>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0)) AS amountSale_Card, Sum(Sale.Sale_Cheque-IIf(Sale.Sale_Cheque>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0)) AS amountSale_Cheque, Sum(Sale.Sale_CDebit-IIf(Sale.Sale_CDebit>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0)) AS amountSale_CDebit, "
        sql = sql & "Count(Sale.SaleID) AS [count], Sum(Sale.Sale_Tender) AS tender, [Person_FirstName] & ' ' & [Person_LastName] AS personName, Count(Sale.Sale_TableNumber) AS tableCount, Sum(Sale.Sale_GuestCount) AS guestCount, Sum(Sale.Sale_Gratuity) AS amountSale_Gratuity, Sum(Sale.Sale_CDebit) AS amountTenderSale_CDebit, Sum(Sale.Sale_Total) AS amountTotal, Sum(IIf(CustomerTransaction.CustomerTransaction_Amount<0,CustomerTransaction.CustomerTransaction_Amount,0)) AS AccSale, Sum(IIf(CustomerTransaction.CustomerTransaction_Amount > 0, CustomerTransaction.CustomerTransaction_Amount, 0)) As AccAmount FROM ((aPOS INNER JOIN Sale ON aPOS.POSID = Sale.Sale_PosID) INNER JOIN aPerson ON Sale.Sale_PersonID = aPerson.PersonID) LEFT JOIN CustomerTransaction ON Sale.SaleID = CustomerTransaction.CustomerTransaction_ReferenceID Where (((Sale.Sale_PersonID) > 0)) GROUP BY [Person_FirstName] & ' ' & [Person_LastName];"

        sql = "SELECT (Sum(Sale.Sale_Cash-IIf(Sale.Sale_Cash>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0))+Sum(Sale.Sale_Card-IIf(Sale.Sale_Card>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0))+Sum(Sale.Sale_Cheque-IIf(Sale.Sale_Cheque>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0))+Sum(Sale.Sale_CDebit-IIf(Sale.Sale_CDebit>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0)))+(Sum(IIf(CustomerTransaction.CustomerTransaction_Amount<0,CustomerTransaction.CustomerTransaction_Amount,0))) AS amount, Sum(Sale.Sale_Cash-IIf(Sale.Sale_Cash>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0))+(Sum(IIf(CustomerTransaction.CustomerTransaction_Amount<0,CustomerTransaction.CustomerTransaction_Amount,0))) AS amountSale_Cash, Sum(Sale.Sale_Card-IIf(Sale.Sale_Card>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0)) AS amountSale_Card, Sum(Sale.Sale_Cheque-IIf(Sale.Sale_Cheque>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0)) AS amountSale_Cheque, Sum(Sale.Sale_CDebit-IIf(Sale.Sale_CDebit>=Sale.Sale_Gratuity,Sale.Sale_Gratuity,0)) AS amountSale_CDebit, "
        sql = sql & "Count(Sale.SaleID) AS [count], Sum(Sale.Sale_Tender) AS tender, [Person_FirstName] & ' ' & [Person_LastName] AS personName, Count(Sale.Sale_TableNumber) AS tableCount, Sum(Sale.Sale_GuestCount) AS guestCount, Sum(Sale.Sale_Gratuity) AS amountSale_Gratuity, Sum(Sale.Sale_CDebit) AS amountTenderSale_CDebit, Sum(Sale.Sale_Total) AS amountTotal, Sum(IIf(CustomerTransaction.CustomerTransaction_Amount<0,CustomerTransaction.CustomerTransaction_Amount,0)) AS AccSale, Sum(IIf(CustomerTransaction.CustomerTransaction_Amount > 0, CustomerTransaction.CustomerTransaction_Amount, 0)) AS AccAmount FROM ((aPOS INNER JOIN Sale ON aPOS.POSID = Sale.Sale_PosID) INNER JOIN aPerson ON Sale.Sale_PersonID = aPerson.PersonID) LEFT JOIN CustomerTransaction ON Sale.SaleID = CustomerTransaction.CustomerTransaction_ReferenceID Where (((Sale.Sale_PersonID) > 0)) GROUP BY [Person_FirstName] & ' ' & [Person_LastName];"
        rs = getRSreport(sql)

        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.Database.Tables(1).SetDataSource(rs)
        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Private Sub report_ProfitByDayEnd()
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryProfitByDayEnd
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryProfitByDayEnd.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        rs.Close()
        sql = "SELECT DayEnd.DayEndID, DayEnd.DayEnd_Date, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ActualCost]*[SaleItem_Quantity],[SaleItem_ActualCost]*[SaleItem_Quantity])) AS actualExcl, Sum(((IIf([SaleItem_Reversal],0-[SaleItem_ActualCost]*[SaleItem_Quantity],[SaleItem_ActualCost]*[SaleItem_Quantity]))*(1+[SaleItem_Vat]/100))) AS actualIncl, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ListCost]*[SaleItem_Quantity],[SaleItem_ListCost]*[SaleItem_Quantity])) AS listExcl, Sum(((IIf([SaleItem_Reversal],0-[SaleItem_ListCost]*[SaleItem_Quantity],[SaleItem_ListCost]*[SaleItem_Quantity]))*(1+[SaleItem_Vat]/100))) AS listIncl, Sum(([SaleItem_Price]*[SaleItem_Quantity]/(1+[SaleItem_Vat]/100))) AS priceExcl, Sum(([SaleItem_Price]*[SaleItem_Quantity])) AS priceIncl, Sum(IIf([SaleItem_Reversal],0-[SaleItem_DepositCost]*[SaleItem_Quantity],[SaleItem_DepositCost]*[SaleItem_Quantity])) AS depositExcl, "
        sql = sql & "Sum((IIf([SaleItem_Reversal],0-[SaleItem_DepositCost]*[SaleItem_Quantity],[SaleItem_DepositCost]*[SaleItem_Quantity]))*(1+[SaleItem_Vat]/100)) AS depositIncl FROM (Sale INNER JOIN (aConsignment AS aConsignment_1 RIGHT JOIN (SaleItem LEFT JOIN aConsignment ON SaleItem.SaleItem_SaleID = aConsignment.Consignment_SaleID) ON aConsignment_1.Consignment_ReversalSaleID = SaleItem.SaleItem_SaleID) ON Sale.SaleID = SaleItem.SaleItem_SaleID) INNER JOIN DayEnd ON Sale.Sale_DayEndID = DayEnd.DayEndID Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY DayEnd.DayEndID, DayEnd.DayEnd_Date ORDER BY DayEnd.DayEndID;"
        rs = getRSreport(sql)

        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.Database.Tables(1).SetDataSource(rs)
        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub
    Private Sub report_Outage()
        Dim rs As ADODB.Recordset
        Dim rsDayEnd As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryOutage
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("crtOutage.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        rs.Close()

        sql = "SELECT Declaration.Declaration_DayEndID, aPOS.POSID, aPOS.POS_Name, Sum(Declaration.Declaration_Cash) AS SumOfDeclaration_Cash, Sum(Declaration.Declaration_CashServer) AS SumOfDeclaration_CashServer, Sum(Declaration.Declaration_CashCount) AS SumOfDeclaration_CashCount, Sum(Declaration.Declaration_Cheque) AS SumOfDeclaration_Cheque, Sum(Declaration.Declaration_ChequeServer) AS SumOfDeclaration_ChequeServer, Sum(Declaration.Declaration_ChequeCount) AS SumOfDeclaration_ChequeCount, Sum(Declaration.Declaration_Card) AS SumOfDeclaration_Card, Sum(Declaration.Declaration_CardServer) AS SumOfDeclaration_CardServer, Sum(Declaration.Declaration_CardCount) AS SumOfDeclaration_CardCount, Sum(Declaration.Declaration_Payout) AS SumOfDeclaration_Payout, Sum(Declaration.Declaration_PayoutServer) AS SumOfDeclaration_PayoutServer, Sum(Declaration.Declaration_PayoutCount) AS SumOfDeclaration_PayoutCount "
        sql = sql & "FROM Declaration INNER JOIN aPOS ON Declaration.Declaration_POSID = aPOS.POSID GROUP BY Declaration.Declaration_DayEndID, aPOS.POSID, aPOS.POS_Name;"

        rs = getRSreport(sql)
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If
        rsDayEnd = getRSreport("SELECT * FROM DayEnd")
        Report.Database.Tables(1).SetDataSource(rsDayEnd)

        Report.Database.Tables(2).SetDataSource(rs)

        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub
    Private Sub report_Payout()
        Dim rsDayEnd As ADODB.Recordset
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryPayout
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryPayout.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        rs.Close()
        sql = "SELECT * FROM Payout"
        rs = getRSreport(sql)
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If
        rsDayEnd = getRSreport("SELECT * FROM DayEnd")
        Report.Database.Tables(1).SetDataSource(rsDayEnd)

        Report.Database.Tables(2).SetDataSource(rs)

        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Private Sub report_PayoutReason()
        Dim rsDayEnd As ADODB.Recordset
        Dim lPGID As String
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryPayout
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryPayout.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        rs.Close()
        If MsgBox("Do you wish to see All Payouts?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            sql = "SELECT Payout.* From Payout ORDER BY Payout.PayoutID;"
        Else
            lPGID = frmPayoutGroupList.getItem
            sql = "SELECT Payout.* From aPayoutGroup1, Payout WHERE (((aPayoutGroup1.PayoutGroup_Name)=(Left([Payout].[Payout_Narrative],Len([aPayoutGroup1].[PayoutGroup_Name])))) AND ((aPayoutGroup1.PayoutGroupID)=" & lPGID & "));"
        End If
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport(sql)
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
             frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If
        rsDayEnd = getRSreport("SELECT * FROM DayEnd")
        Report.Database.Tables(1).SetDataSource(rsDayEnd)

        Report.Database.Tables(2).SetDataSource(rs)

        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Private Sub report_HourlyReport()
        Dim rsSale As ADODB.Recordset
        Dim SumSales As Decimal
        Dim sql2 As String
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryHourlyReport
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryHourlyReport.rpt")

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        rs.Close()
        sql = "SELECT * FROM Sale"
        rs = getRSreport(sql)
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        sql2 = "SELECT SaleItem.SaleItem_StockItemID, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ActualCost]*[SaleItem_Quantity],[SaleItem_ActualCost]*[SaleItem_Quantity])) AS actualCostSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ListCost]*[SaleItem_Quantity],[SaleItem_ListCost]*[SaleItem_Quantity])) AS listCostSum, Sum(([SaleItem_Price]*[SaleItem_Quantity]/(1+[SaleItem_Vat]/100))) AS exclusiveSum, Sum(([SaleItem_Price]*[SaleItem_Quantity])) AS inclusiveSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_DepositCost]*[SaleItem_Quantity],[SaleItem_DepositCost]*[SaleItem_Quantity])) AS depositSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) AS quantitySum FROM Sale INNER JOIN (aConsignment AS aConsignment_1 RIGHT JOIN (SaleItem LEFT JOIN aConsignment ON SaleItem.SaleItem_SaleID=aConsignment.Consignment_SaleID) ON aConsignment_1.Consignment_ReversalSaleID=SaleItem.SaleItem_SaleID) ON Sale.SaleID=SaleItem.SaleItem_SaleID" & " Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null))" & " GROUP BY SaleItem.SaleItem_StockItemID;"

        rsSale = getRSreport(sql2)
        Do While rsSale.EOF = False
            SumSales = SumSales + rsSale.Fields("inclusiveSum").Value

            rsSale.moveNext()
        Loop

        Report.Database.Tables(1).SetDataSource(rs)

        Report.SetParameterValue("txtSum", FormatNumber(SumSales, 2))

        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub
    Private Sub report_SalesVat()
        Dim rsDep As ADODB.Recordset
        Dim txtStockDepositReturn As Integer
        Dim txtStockDepositSold As Integer
        Dim sql2 As String
        Dim rs As ADODB.Recordset
        Dim vInSales As Decimal
        Dim vExSales As Decimal
        Dim vTaxSales As Decimal
        Dim vVatSales As Decimal
        Dim vNonTaxSales As Decimal
        Dim rsSales As ADODB.Recordset
        Dim rsSalesTotal As ADODB.Recordset
        Dim rsDiscount As ADODB.Recordset

        Dim sql As String
        'Dim Report As New CryVreporting
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("CryVreporting.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        rs.Close()

        sql2 = "SELECT SaleItem.SaleItem_StockItemID, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ActualCost]*[SaleItem_Quantity],[SaleItem_ActualCost]*[SaleItem_Quantity])) AS actualCostSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ListCost]*[SaleItem_Quantity],[SaleItem_ListCost]*[SaleItem_Quantity])) AS listCostSum, Sum(([SaleItem_Price]*[SaleItem_Quantity]/(1+[SaleItem_Vat]/100))) AS exclusiveSum, Sum(([SaleItem_Price]*[SaleItem_Quantity])) AS inclusiveSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_DepositCost]*[SaleItem_Quantity],[SaleItem_DepositCost]*[SaleItem_Quantity])) AS depositSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) AS quantitySum FROM Sale INNER JOIN (aConsignment AS aConsignment_1 RIGHT JOIN (SaleItem LEFT JOIN aConsignment ON SaleItem.SaleItem_SaleID=aConsignment.Consignment_SaleID) ON aConsignment_1.Consignment_ReversalSaleID=SaleItem.SaleItem_SaleID) ON Sale.SaleID=SaleItem.SaleItem_SaleID" & " Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null))" & " GROUP BY SaleItem.SaleItem_StockItemID;"

        rsSales = getRSreport(sql2)

        If rsSales.BOF Or rsSales.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        sql2 = "SELECT SaleItem.SaleItem_StockItemID, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ActualCost]*[SaleItem_Quantity],[SaleItem_ActualCost]*[SaleItem_Quantity])) AS actualCostSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ListCost]*[SaleItem_Quantity],[SaleItem_ListCost]*[SaleItem_Quantity])) AS listCostSum, Sum(([SaleItem_Price]*[SaleItem_Quantity]/(1+[SaleItem_Vat]/100))) AS exclusiveSum, Sum(([SaleItem_Price]*[SaleItem_Quantity])) AS inclusiveSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_DepositCost]*[SaleItem_Quantity],[SaleItem_DepositCost]*[SaleItem_Quantity])) AS depositSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) AS quantitySum FROM Sale INNER JOIN (aConsignment AS aConsignment_1 RIGHT JOIN (SaleItem LEFT JOIN aConsignment ON SaleItem.SaleItem_SaleID=aConsignment.Consignment_SaleID) ON aConsignment_1.Consignment_ReversalSaleID=SaleItem.SaleItem_SaleID) ON Sale.SaleID=SaleItem.SaleItem_SaleID" & " Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null))" & " GROUP BY SaleItem.SaleItem_StockItemID;"

        rsSalesTotal = getRSreport(sql2)

        Do While rsSalesTotal.EOF = False
            vInSales = vInSales + rsSalesTotal.Fields("inclusiveSum").Value

            vExSales = vExSales + rsSalesTotal.Fields("exclusiveSum").Value

            If rsSalesTotal.Fields("inclusiveSum").Value = rsSalesTotal.Fields("exclusiveSum").Value Then
                vNonTaxSales = vNonTaxSales + rsSalesTotal.Fields("inclusiveSum").Value
            Else
                vTaxSales = vTaxSales + rsSalesTotal.Fields("exclusiveSum").Value
            End If
            rsSalesTotal.moveNext()
        Loop

        txtStockDepositSold = 0
        'UPGRADE_WARNING: Couldn't resolve default property of object txtStockDepositReturn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        txtStockDepositReturn = 0
        rsDep = getRSreport("SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS content, CBool([SaleItem_DepositType]) AS depositType, SaleItem.SaleItem_Reversal, Sum(([SaleItem_DepositCost]*[SaleItem_Quantity])*(1+[SaleItem_Vat]/100)) AS deposit FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY CBool([SaleItem_DepositType]), SaleItem.SaleItem_Reversal;")
        Do Until rsDep.EOF
            If rsDep("depositType").Value Then
                If rsDep("SaleItem_Reversal").Value Then
                    txtStockDepositSold = rsDep("content").Value
                Else
                    txtStockDepositReturn = rsDep("content").Value
                End If
            Else
                '            If rsDep("SaleItem_Reversal") Then
                '                Report.txtStockCreditContent.SetText FormatNumber(rsDep("content"), 2)
                '                Report.txtStockCreditDeposit.SetText FormatNumber(0 - rsDep("deposit"), 2)
                '
                '            Else
                '                Report.txtStockSoldContent.SetText FormatNumber(rsDep("content"), 2)
                '                Report.txtStockSoldDeposit.SetText FormatNumber(rsDep("deposit"), 2)
                '            End If
            End If
            rsDep.moveNext()
        Loop
        rsDep.Close()
        vInSales = vInSales + (txtStockDepositSold + txtStockDepositReturn)
        vExSales = vExSales + (txtStockDepositSold + txtStockDepositReturn)
        vVatSales = vInSales - vExSales

        'do invoice discount
        rsDiscount = getRSreport("SELECT Sum(Sale.Sale_Discount) AS amount FROM aConsignment RIGHT JOIN (aConsignment AS aConsignment_1 RIGHT JOIN Sale ON aConsignment_1.Consignment_SaleID = Sale.SaleID) ON aConsignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null));")
        If IsDbNull(rsDiscount.Fields("amount").Value) Then
            Report.SetParameterValue("txtDiscountsGiven", "0.00")
        Else
            If rsDiscount.RecordCount Then
                Report.SetParameterValue("txtDiscountsGiven", FormatNumber(0 - rsDiscount.Fields("amount").Value, 2))
            Else
                Report.SetParameterValue("txtDiscountsGiven", "0.00")
            End If
        End If

        Report.Database.Tables(1).SetDataSource(rsSales)
        Report.SetParameterValue("txtInSales", FormatNumber(vInSales, 2))
        Report.SetParameterValue("txtExSales", FormatNumber(vExSales, 2))
        Report.SetParameterValue("txtTaxSales", FormatNumber(vTaxSales, 2))
        Report.SetParameterValue("txtVatSales", FormatNumber(vVatSales, 2))
        Report.SetParameterValue("txtNonTaxSales", FormatNumber(vNonTaxSales, 2))

        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub
    Private Sub report_VATrepporting()
        Dim rDepPurIVat As Integer
        Dim txtStockDepositReturn As Integer
        Dim txtStockDepositSold As Integer
        Dim sql2 As String
        Dim vl_Charged As Decimal
        Dim rs As ADODB.Recordset
        Dim vInSales As Decimal
        Dim vExSales As Decimal
        Dim vTaxSales As Decimal
        Dim vVatSales As Decimal
        Dim vNonTaxSales As Decimal
        Dim rNar As ADODB.Recordset 'Tax Narrative purpose
        Dim rsGRVItem As ADODB.Recordset
        Dim rsGRVMain As ADODB.Recordset
        Dim rsGRVDeposit As ADODB.Recordset
        Dim rsGRVPricing As ADODB.Recordset
        Dim rsGRVItemReturn As ADODB.Recordset
        Dim rsGRVDepositReturn As ADODB.Recordset
        Dim rsSalesTotal As ADODB.Recordset
        Dim rPurchases As ADODB.Recordset 'do purchases list
        Dim rDayEndPur As ADODB.Recordset '2 get the day ends
        Dim rPurEVat As Decimal
        Dim rPurIVat As Decimal
        Dim rsDiscount As ADODB.Recordset
        Dim sql As String
        'Dim Report As New Cryreporting
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("Cryreporting.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        rs.Close()

        rsGRVItem = getRSreport("SELECT aGRV.GRVID, Sum(IIf([GRVItem_Return],0,(((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])))) AS exclusive, Sum(IIf([GRVItem_Return],0,((((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100))))) AS inclusive, Sum(IIf([GRVItem_Return],0,[GRVItem_DepositCost]*[GRVItem_Quantity])) AS depositExcl, Sum(IIf([GRVItem_Return],0,([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100))) AS depositIncl FROM (aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) LEFT JOIN aGRVItem ON aGRV.GRVID = aGRVItem.GRVItem_GRVID Where (((aGRV.GRV_GRVStatusID) = 3) AND (GRVItem_StockItemQuantity <> 0)) GROUP BY aGRV.GRVID;")

        If rsGRVItem.BOF Or rsGRVItem.EOF Then
            report_SalesVat()
            Exit Sub
        End If

        rsGRVItemReturn = getRSreport("SELECT aGRV.GRVID, Sum(IIf([GRVItem_Return],(((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])),0)) AS exclusive, Sum(IIf([GRVItem_Return],((((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100))),0)) AS inclusive, Sum(IIf([GRVItem_Return],[GRVItem_DepositCost]*[GRVItem_Quantity],0)) AS depositExcl, Sum(IIf([GRVItem_Return],([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100),0)) AS depositIncl FROM (aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) LEFT JOIN aGRVItem ON aGRV.GRVID = aGRVItem.GRVItem_GRVID Where (((aGRV.GRV_GRVStatusID) = 3)) GROUP BY aGRV.GRVID;")
        rsGRVDeposit = getRSreport("SELECT aGRV.GRVID, Sum(IIf([GRVDeposit_Return],0,(IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,[GRVDeposit_Quantity]*([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]*(1+[GRVDeposit_VatRate]/100)),0))+(IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,[GRVDeposit_quantity]*([GRVDeposit_CaseCost]*(1+[GRVDeposit_VatRate]/100)),0)))) AS inclusiveDepositReturn, Sum(IIf([GRVDeposit_Return],0,(IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,[GRVDeposit_Quantity]*([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]),0))+(IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,[GRVDeposit_quantity]*([GRVDeposit_CaseCost]),0)))) AS exclusiveDepositReturn FROM (aGRV LEFT JOIN aGRVDeposit ON aGRV.GRVID = aGRVDeposit.GRVDeposit_GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID Where (((aGRV.GRV_GRVStatusID) = 3)) GROUP BY aGRV.GRVID;")
        rsGRVDepositReturn = getRSreport("SELECT aGRV.GRVID, Sum(IIf([GRVDeposit_Return],(IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,[GRVDeposit_Quantity]*([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]*(1+[GRVDeposit_VatRate]/100)),0))+(IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,[GRVDeposit_quantity]*([GRVDeposit_CaseCost]*(1+[GRVDeposit_VatRate]/100)),0)),0)) AS inclusiveDepositReturn, Sum(IIf([GRVDeposit_Return],(IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,[GRVDeposit_Quantity]*([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]),0))+(IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,[GRVDeposit_quantity]*([GRVDeposit_CaseCost]),0)),0)) AS exclusiveDepositReturn FROM (aGRV LEFT JOIN aGRVDeposit ON aGRV.GRVID = aGRVDeposit.GRVDeposit_GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID Where (((aGRV.GRV_GRVStatusID) = 3)) GROUP BY aGRV.GRVID;")
        'Set rsGRVMain = getRSreport("SELECT aGRV.GRVID, aGRV.GRV_InvoiceInclusive, aGRV.GRV_InvoiceVat, aGRV.GRV_InvoiceDiscount, aGRV.GRV_SundriesPlus, aGRV.GRV_SundriesMinus, aGRV.GRV_ContentExclusive, ([GRV_ContentExclusive]*(1+[GRV_Ullage]/100)-[GRV_ContentExclusive]) AS Ullage, (1+[GRV_InvoiceVat]/([GRV_InvoiceInclusive]-[GRV_InvoiceVat])) AS vat, Supplier.SupplierID, Supplier.Supplier_Name, aPurchaseOrder.PurchaseOrder_Reference, aGRV.GRV_InvoiceNumber, aGRV.GRV_InvoiceDate FROM ((aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aPurchaseOrder ON aGRV.GRV_PurchaseOrderID = aPurchaseOrder.PurchaseOrderID) INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID WHERE (((aGRV.GRV_GRVStatusID)=3) AND ((aGRV.GRV_InvoiceInclusive)<>0));")
        rsGRVMain = getRSreport("SELECT aGRV.GRVID, aGRV.GRV_InvoiceInclusive, aGRV.GRV_InvoiceVat, aGRV.GRV_InvoiceDiscount, aGRV.GRV_SundriesPlus, aGRV.GRV_SundriesMinus, aGRV.GRV_ContentExclusive, ([GRV_ContentExclusive]*(1+[GRV_Ullage]/100)-[GRV_ContentExclusive]) AS Ullage, (1+[GRV_InvoiceVat]/ IIf(([GRV_InvoiceInclusive]-[GRV_InvoiceVat])=0,1,([GRV_InvoiceInclusive]-[GRV_InvoiceVat]))) AS vat, Supplier.SupplierID, Supplier.Supplier_Name, aPurchaseOrder.PurchaseOrder_Reference, aGRV.GRV_InvoiceNumber, aGRV.GRV_InvoiceDate FROM ((aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aPurchaseOrder ON aGRV.GRV_PurchaseOrderID = aPurchaseOrder.PurchaseOrderID) INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID WHERE (((aGRV.GRV_GRVStatusID)=3) AND ((aGRV.GRV_InvoiceInclusive)<>0));")

        sql = "SELECT aGRV.GRVID, Sum((([GRVItem_PackSize]/[GRVItem_StockItemQuantity])*[GRVItem_ContentCost]-[GRVItem_DiscountAmount])*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))) AS exclusive, Sum((([GRVItem_PackSize]/[GRVItem_StockItemQuantity])*[GRVItem_ContentCost]-[GRVItem_DiscountAmount])*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))*(1+[GRVItem_VatRate]/100)) AS inclusive, Sum((([GRVItem_PackSize]/[GRVItem_StockItemQuantity])*[GRVItem_ContentCost])*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))) AS PriceExcl, Sum((([GRVItem_PackSize]/[GRVItem_StockItemQuantity])*[GRVItem_ContentCost])*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))*(1+[GRVItem_VatRate]/100)) AS PriceIncl, Sum([DayEndStockItemLnk_ListCost]*[GRVItem_PackSize]*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))) AS listExcl, Sum([DayEndStockItemLnk_ListCost]*[GRVItem_PackSize]*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))*(1+[GRVItem_VatRate]/100)) AS listIncl, "
        sql = sql & "Sum([DayEndStockItemLnk_ActualCost]*[GRVItem_PackSize]*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))*(1+[GRVItem_VatRate]/100)) AS actualIncl, Sum([DayEndStockItemLnk_ActualCost]*[GRVItem_PackSize]*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))) AS actualExcl FROM DayEndStockItemLnk INNER JOIN ((aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aGRVItem ON aGRV.GRVID = aGRVItem.GRVItem_GRVID) ON (DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aGRVItem.GRVItem_StockItemID) AND (DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aGRV.GRV_DayEndID) Where (((aGRV.GRV_GRVStatusID) = 3) AND (GRVItem_StockItemQuantity <> 0)) GROUP BY aGRV.GRVID;"

        rsGRVPricing = getRSreport(sql)

        If rsGRVPricing.BOF Or rsGRVPricing.EOF Then
            report_SalesVat()
            Exit Sub
        End If

        sql2 = "SELECT SaleItem.SaleItem_StockItemID, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ActualCost]*[SaleItem_Quantity],[SaleItem_ActualCost]*[SaleItem_Quantity])) AS actualCostSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ListCost]*[SaleItem_Quantity],[SaleItem_ListCost]*[SaleItem_Quantity])) AS listCostSum, Sum(([SaleItem_Price]*[SaleItem_Quantity]/(1+[SaleItem_Vat]/100))) AS exclusiveSum, Sum(([SaleItem_Price]*[SaleItem_Quantity])) AS inclusiveSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_DepositCost]*[SaleItem_Quantity],[SaleItem_DepositCost]*[SaleItem_Quantity])) AS depositSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) AS quantitySum FROM Sale INNER JOIN (aConsignment AS aConsignment_1 RIGHT JOIN (SaleItem LEFT JOIN aConsignment ON SaleItem.SaleItem_SaleID=aConsignment.Consignment_SaleID) ON aConsignment_1.Consignment_ReversalSaleID=SaleItem.SaleItem_SaleID) ON Sale.SaleID=SaleItem.SaleItem_SaleID" & " Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null))" & " GROUP BY SaleItem.SaleItem_StockItemID;"

        rsSalesTotal = getRSreport(sql2)

        Do While rsSalesTotal.EOF = False
            vInSales = vInSales + rsSalesTotal.Fields("inclusiveSum").Value

            vExSales = vExSales + rsSalesTotal.Fields("exclusiveSum").Value

            If rsSalesTotal.Fields("inclusiveSum").Value = rsSalesTotal.Fields("exclusiveSum").Value Then
                vNonTaxSales = vNonTaxSales + rsSalesTotal.Fields("inclusiveSum").Value
            Else
                vTaxSales = vTaxSales + rsSalesTotal.Fields("exclusiveSum").Value
            End If


            rsSalesTotal.moveNext()
        Loop

        'deposit calculation
        txtStockDepositSold = 0
        txtStockDepositReturn = 0
        Dim rsDep As ADODB.Recordset
        rsDep = getRSreport("SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS content, CBool([SaleItem_DepositType]) AS depositType, SaleItem.SaleItem_Reversal, Sum(([SaleItem_DepositCost]*[SaleItem_Quantity])*(1+[SaleItem_Vat]/100)) AS deposit FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY CBool([SaleItem_DepositType]), SaleItem.SaleItem_Reversal;")
        If rsDep.RecordCount Then
            Do Until rsDep.EOF
                If rsDep.Fields("depositType").Value Then
                    If rsDep.Fields("SaleItem_Reversal").Value Then
                        txtStockDepositSold = rsDep.Fields("content").Value
                    Else
                        txtStockDepositReturn = rsDep.Fields("content").Value
                    End If
                Else
                    '            If rsDep("SaleItem_Reversal") Then
                    '                Report.txtStockCreditContent.SetText FormatNumber(rsDep("content"), 2)
                    '                Report.txtStockCreditDeposit.SetText FormatNumber(0 - rsDep("deposit"), 2)
                    '
                    '            Else
                    '                Report.txtStockSoldContent.SetText FormatNumber(rsDep("content"), 2)
                    '                Report.txtStockSoldDeposit.SetText FormatNumber(rsDep("deposit"), 2)
                    '            End If
                End If
                rsDep.moveNext()
            Loop
            rsDep.Close()
        End If
        vInSales = vInSales + (txtStockDepositSold + txtStockDepositReturn)
        vExSales = vExSales + (txtStockDepositSold + txtStockDepositReturn)
        vVatSales = vInSales - vExSales

        rPurIVat = 0
        rPurEVat = 0

        'get ID's from DayEnd
        rDayEndPur = getRSreport("SELECT aGRV.GRVID,aGRV.GRV_DayEndID, aGRV.GRV_InvoiceInclusive, aGRV.GRV_InvoiceVat, aGRV.GRV_InvoiceDiscount, aGRV.GRV_SundriesPlus, aGRV.GRV_SundriesMinus, aGRV.GRV_ContentExclusive, ([GRV_ContentExclusive]*(1+[GRV_Ullage]/100)-[GRV_ContentExclusive]) AS Ullage, (1+[GRV_InvoiceVat]/ IIf(([GRV_InvoiceInclusive]-[GRV_InvoiceVat])=0,1,([GRV_InvoiceInclusive]-[GRV_InvoiceVat]))) AS vat, Supplier.SupplierID, Supplier.Supplier_Name, aPurchaseOrder.PurchaseOrder_Reference, aGRV.GRV_InvoiceNumber, aGRV.GRV_InvoiceDate FROM ((aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aPurchaseOrder ON aGRV.GRV_PurchaseOrderID = aPurchaseOrder.PurchaseOrderID) INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID WHERE (((aGRV.GRV_GRVStatusID)=3) AND ((aGRV.GRV_InvoiceInclusive)<>0));")

        'Do While rDayEndPur.EOF = False
        Do Until rDayEndPur.EOF

            rPurchases = getRSreport("SELECT aStockItem.StockItem_Name AS GRVItem_Name, aGRVItem.GRVItem_Code, aGRVItem.GRVItem_PackSize, aGRVItem.GRVItem_Quantity, aGRVItem.GRVItem_ContentCost, aGRVItem.GRVItem_DepositCost, aGRVItem.GRVItem_DiscountAmount, aGRVItem.GRVItem_VatRate, ([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS depositInclusive, ((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity] AS contentExclusive, (((([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100) AS contentInclusive, (([GRVItem_PackSize]/[StockItem_Quantity])*[GRVItem_ContentCost]) AS contentCost FROM aGRVItem INNER JOIN aStockItem ON aGRVItem.GRVItem_StockItemID = aStockItem.StockItemID WHERE (((aGRVItem.GRVItem_Quantity)<>0) AND ((aGRVItem.GRVItem_Return)=0) AND ((aGRVItem.GRVItem_GRVID)= " & rDayEndPur.Fields("GRVID").Value & "));")

            Do While rPurchases.EOF = False
                If rPurchases.Fields("contentInclusive").Value = rPurchases.Fields("contentExclusive").Value Then
                    rPurIVat = rPurIVat + rPurchases.Fields("contentExclusive").Value
                Else
                    rPurEVat = rPurEVat + rPurchases.Fields("contentExclusive").Value
                End If

                rPurchases.moveNext()
            Loop

            rDayEndPur.moveNext()
        Loop

        'purchase deposit calculation
        rDepPurIVat = 0
        Dim rsDepPurch As ADODB.Recordset
        rsDepPurch = getRSreport("SELECT Sum(IIf([DayEndDeposittemLnk_DepositType]=0,[DayEndDepositItemLnk_UnitCost],[DayEndDepositItemLnk_CaseCost])*[DayEndDepositItemLnk_QuantitySales]) AS Sales, Sum(IIf([DayEndDeposittemLnk_DepositType]=0,[DayEndDepositItemLnk_UnitCost],[DayEndDepositItemLnk_CaseCost])*[DayEndDepositItemLnk_QuantityShrink]) AS Shrink, Sum(IIf([DayEndDeposittemLnk_DepositType]=0,[DayEndDepositItemLnk_UnitCost],[DayEndDepositItemLnk_CaseCost])*[DayEndDepositItemLnk_QuantityGRV]) AS GRV From DayEndDepositItemLnk")
        If rsDepPurch.RecordCount Then rDepPurIVat = IIf(IsDbNull(rsDepPurch.Fields("GRV").Value), 0, rsDepPurch.Fields("GRV").Value)
        rPurIVat = rPurIVat + rDepPurIVat
        rPurEVat = rPurEVat + rDepPurIVat

        'do invoice discount
        rsDiscount = getRSreport("SELECT Sum(Sale.Sale_Discount) AS amount FROM aConsignment RIGHT JOIN (aConsignment AS aConsignment_1 RIGHT JOIN Sale ON aConsignment_1.Consignment_SaleID = Sale.SaleID) ON aConsignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null));")

        If IsDbNull(rsDiscount.Fields("amount").Value) Then
            Report.SetParameterValue("txtDiscountsGiven", "0.00")
        Else
            If rsDiscount.RecordCount Then
                Report.SetParameterValue("txtDiscountsGiven", FormatNumber(0 - rsDiscount.Fields("amount").Value, 2))
            Else
                Report.SetParameterValue("txtDiscountsGiven", "0.00")
            End If
        End If

        Report.SetParameterValue("txtInSales", FormatNumber(vInSales, 2))
        Report.SetParameterValue("txtExSales", FormatNumber(vExSales, 2))
        Report.SetParameterValue("txtTaxSales", FormatNumber(vTaxSales, 2))
        Report.SetParameterValue("txtVatSales", FormatNumber(vVatSales, 2))
        Report.SetParameterValue("txtNonTaxSales", FormatNumber(vNonTaxSales, 2))

        'Purchases
        Report.SetParameterValue("txtNonTaxable", FormatNumber(rPurIVat, 2))
        Report.SetParameterValue("txtPurExcluding", FormatNumber(rPurEVat, 2))

        Report.Database.Tables(1).SetDataSource(rsGRVItem)
        Report.Database.Tables(2).SetDataSource(rsGRVItemReturn)
        Report.Database.Tables(3).SetDataSource(rsGRVDeposit)
        Report.Database.Tables(4).SetDataSource(rsGRVDepositReturn)
        Report.Database.Tables(5).SetDataSource(rsGRVMain)
        Report.Database.Tables(6).SetDataSource(rsGRVPricing)

        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()

    End Sub
    Public Sub report_VATPASTEL()
        Dim rsSale As ADODB.Recordset
        Dim sql2 As String
        Dim intF As Short

        Dim lMode As Boolean

        Dim vInSales As Decimal
        Dim vExSales As Decimal
        Dim vTaxSales As Decimal
        Dim vVatSales As Decimal
        Dim vNonTaxSales As Decimal
        Dim lPasteCurr As Decimal
        Dim vl_Charged As Decimal
        Dim rPurEVat As Decimal
        Dim rPurIVat As Decimal
        Dim lTotal As Decimal
        Dim VatEx As Decimal
        Dim VatEp As Decimal
        Dim lCash As Decimal
        Dim lDebit As Decimal
        Dim lCheque As Decimal
        Dim lCredit As Decimal

        Dim rs As ADODB.Recordset
        Dim rNar As ADODB.Recordset 'Tax Narrative purpose
        Dim rsGRVItem As ADODB.Recordset
        Dim rsGRVMain As ADODB.Recordset
        Dim rsGRVDeposit As ADODB.Recordset
        Dim rsGRVPricing As ADODB.Recordset
        Dim rsGRVItemReturn As ADODB.Recordset
        Dim rsGRVDepositReturn As ADODB.Recordset
        Dim rsSalesTotal As ADODB.Recordset
        Dim rPurchases As ADODB.Recordset 'do purchases list
        Dim rDayEndPur As ADODB.Recordset '2 get the day ends
        Dim rDisplay_F As ADODB.Recordset
        Dim rsPTotals As ADODB.Recordset
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        Dim sql As String
        'Dim Report As New cryPastelAnalysisrep
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryPastenAnalysisrep.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        rs.Close()

        rsGRVItem = getRSreport("SELECT aGRV.GRVID, Sum(IIf([GRVItem_Return],0,(((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])))) AS exclusive, Sum(IIf([GRVItem_Return],0,((((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100))))) AS inclusive, Sum(IIf([GRVItem_Return],0,[GRVItem_DepositCost]*[GRVItem_Quantity])) AS depositExcl, Sum(IIf([GRVItem_Return],0,([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100))) AS depositIncl FROM (aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) LEFT JOIN aGRVItem ON aGRV.GRVID = aGRVItem.GRVItem_GRVID Where (((aGRV.GRV_GRVStatusID) = 3) AND (GRVItem_StockItemQuantity <> 0)) GROUP BY aGRV.GRVID;")

        If rsGRVItem.BOF Or rsGRVItem.EOF Then
            report_Salespastel()
            Exit Sub
        End If

        rsGRVItemReturn = getRSreport("SELECT aGRV.GRVID, Sum(IIf([GRVItem_Return],(((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])),0)) AS exclusive, Sum(IIf([GRVItem_Return],((((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100))),0)) AS inclusive, Sum(IIf([GRVItem_Return],[GRVItem_DepositCost]*[GRVItem_Quantity],0)) AS depositExcl, Sum(IIf([GRVItem_Return],([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100),0)) AS depositIncl FROM (aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) LEFT JOIN aGRVItem ON aGRV.GRVID = aGRVItem.GRVItem_GRVID Where (((aGRV.GRV_GRVStatusID) = 3)) GROUP BY aGRV.GRVID;")
        rsGRVDeposit = getRSreport("SELECT aGRV.GRVID, Sum(IIf([GRVDeposit_Return],0,(IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,[GRVDeposit_Quantity]*([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]*(1+[GRVDeposit_VatRate]/100)),0))+(IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,[GRVDeposit_quantity]*([GRVDeposit_CaseCost]*(1+[GRVDeposit_VatRate]/100)),0)))) AS inclusiveDepositReturn, Sum(IIf([GRVDeposit_Return],0,(IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,[GRVDeposit_Quantity]*([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]),0))+(IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,[GRVDeposit_quantity]*([GRVDeposit_CaseCost]),0)))) AS exclusiveDepositReturn FROM (aGRV LEFT JOIN aGRVDeposit ON aGRV.GRVID = aGRVDeposit.GRVDeposit_GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID Where (((aGRV.GRV_GRVStatusID) = 3)) GROUP BY aGRV.GRVID;")
        rsGRVDepositReturn = getRSreport("SELECT aGRV.GRVID, Sum(IIf([GRVDeposit_Return],(IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,[GRVDeposit_Quantity]*([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]*(1+[GRVDeposit_VatRate]/100)),0))+(IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,[GRVDeposit_quantity]*([GRVDeposit_CaseCost]*(1+[GRVDeposit_VatRate]/100)),0)),0)) AS inclusiveDepositReturn, Sum(IIf([GRVDeposit_Return],(IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,[GRVDeposit_Quantity]*([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]),0))+(IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,[GRVDeposit_quantity]*([GRVDeposit_CaseCost]),0)),0)) AS exclusiveDepositReturn FROM (aGRV LEFT JOIN aGRVDeposit ON aGRV.GRVID = aGRVDeposit.GRVDeposit_GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID Where (((aGRV.GRV_GRVStatusID) = 3)) GROUP BY aGRV.GRVID;")
        rsGRVMain = getRSreport("SELECT aGRV.GRVID, aGRV.GRV_InvoiceInclusive, aGRV.GRV_InvoiceVat, aGRV.GRV_InvoiceDiscount, aGRV.GRV_SundriesPlus, aGRV.GRV_SundriesMinus, aGRV.GRV_ContentExclusive, ([GRV_ContentExclusive]*(1+[GRV_Ullage]/100)-[GRV_ContentExclusive]) AS Ullage, (1+[GRV_InvoiceVat]/([GRV_InvoiceInclusive]-[GRV_InvoiceVat])) AS vat, Supplier.SupplierID, Supplier.Supplier_Name, aPurchaseOrder.PurchaseOrder_Reference, aGRV.GRV_InvoiceNumber, aGRV.GRV_InvoiceDate FROM ((aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aPurchaseOrder ON aGRV.GRV_PurchaseOrderID = aPurchaseOrder.PurchaseOrderID) INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID WHERE (((aGRV.GRV_GRVStatusID)=3) AND ((aGRV.GRV_InvoiceInclusive)<>0));")

        sql = "SELECT aGRV.GRVID, Sum((([GRVItem_PackSize]/[GRVItem_StockItemQuantity])*[GRVItem_ContentCost]-[GRVItem_DiscountAmount])*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))) AS exclusive, Sum((([GRVItem_PackSize]/[GRVItem_StockItemQuantity])*[GRVItem_ContentCost]-[GRVItem_DiscountAmount])*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))*(1+[GRVItem_VatRate]/100)) AS inclusive, Sum((([GRVItem_PackSize]/[GRVItem_StockItemQuantity])*[GRVItem_ContentCost])*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))) AS PriceExcl, Sum((([GRVItem_PackSize]/[GRVItem_StockItemQuantity])*[GRVItem_ContentCost])*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))*(1+[GRVItem_VatRate]/100)) AS PriceIncl, Sum([DayEndStockItemLnk_ListCost]*[GRVItem_PackSize]*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))) AS listExcl, Sum([DayEndStockItemLnk_ListCost]*[GRVItem_PackSize]*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))*(1+[GRVItem_VatRate]/100)) AS listIncl, "
        sql = sql & "Sum([DayEndStockItemLnk_ActualCost]*[GRVItem_PackSize]*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))*(1+[GRVItem_VatRate]/100)) AS actualIncl, Sum([DayEndStockItemLnk_ActualCost]*[GRVItem_PackSize]*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))) AS actualExcl FROM DayEndStockItemLnk INNER JOIN ((aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aGRVItem ON aGRV.GRVID = aGRVItem.GRVItem_GRVID) ON (DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aGRVItem.GRVItem_StockItemID) AND (DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aGRV.GRV_DayEndID) Where (((aGRV.GRV_GRVStatusID) = 3) AND (GRVItem_StockItemQuantity <> 0)) GROUP BY aGRV.GRVID;"

        rsGRVPricing = getRSreport(sql)

        If rsGRVPricing.BOF Or rsGRVPricing.EOF Then
            report_Salespastel()
            Exit Sub
        End If

        cnnDB.Execute("UPDATE PastelDescription SET Amount=0,HomeAmount=0,PastelDate=#" & CDate(Today) & "#, Reference = '4POS'")


        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        If openConnectionReport() Then
            rs = getRSreport("SELECT aCompany.Company_Name, Report.Report_Heading FROM aCompany, Report;")
            Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
            Report.SetParameterValue("txtFilter", rs.Fields("Report_Heading"))

            'get payoutTotal
            rs = getRSreport("SELECT Sum(Payout.Payout_Amount) AS [amount] FROM Payout;")
            If IsDbNull(rs.Fields("amount").Value) Then
                Report.SetParameterValue("txtPayout", "0.00")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 18")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 19")

                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 18")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 19")
            Else
                Report.SetParameterValue("txtPayout", FormatNumber(rs.Fields("amount").Value, 2))
                Report.SetParameterValue("txtPayout1", FormatNumber(rs.Fields("amount").Value, 2))
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 18")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 19")

                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 18")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 19")
            End If
            rs.Close()

            'get outages.................

            rs = getRSreport("SELECT Sum(([Declaration_Cash]+[Declaration_Cheque]+[Declaration_Card]-[Declaration_Payout])-([Declaration_CashServer]+[Declaration_ChequeServer]+[Declaration_CardServer]-[Declaration_PayoutServer])) AS amount FROM Declaration;")
            If IsDbNull(rs.Fields("amount").Value) Then
                Report.SetParameterValue("txtOutage", "0.00")
                Report.SetParameterValue("txtOutage1", "0.00")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 5")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 6")

                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 5")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 6")
            Else
                If rs.Fields("amount").Value < 0 Then
                    Report.SetParameterValue("txtOutage", FormatNumber(-1 * rs.Fields("amount").Value, 2))
                    Report.SetParameterValue("txtOutage1", FormatNumber(-1 * rs.Fields("amount").Value, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 5")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 6")

                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 5")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 6")
                Else
                    Report.SetParameterValue("txtOutage", FormatNumber(rs.Fields("amount").Value, 2))
                    Report.SetParameterValue("txtOutage1", FormatNumber(rs.Fields("amount").Value, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 5")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 6")

                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 5")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 6")
                End If
            End If
            rs.Close()

            'get account movement......................
            lTotal = 0
            lCash = 0
            lDebit = 0
            lCheque = 0
            lCredit = 0

            rs = getRSreport("SELECT Sum(Sale.Sale_Total) AS amount, Sale.Sale_PaymentType, Sum([Sale_Total]-[Sale_Discount]) AS Subtotal, Sum(Sale.Sale_Discount) AS discount, Sum(Sale.Sale_Cash) AS amountCash,Sum(Sale.Sale_Card) AS amountCard,Sum(Sale.Sale_CDebit) AS amountCredit,Sum(Sale.Sale_Cheque) AS amountCheque FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (CustomerTransaction INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((CustomerTransaction.CustomerTransaction_TransactionTypeID) = 2 Or (CustomerTransaction.CustomerTransaction_TransactionTypeID) = 3) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_PaymentType;")

            Do Until rs.EOF
                Select Case rs.Fields("Sale_PaymentType").Value
                    Case 5
                        Report.SetParameterValue("txtAccountSales", FormatNumber(rs.Fields("subtotal").Value, 2))
                        Report.SetParameterValue("txtAccountSales1", FormatNumber(rs.Fields("subtotal").Value, 2))
                        cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("subtotal").Value, 2)) & " WHERE IDDescription = 7")
                        cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rs.Fields("subtotal").Value, 2)) & " WHERE IDDescription = 8")

                        cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("subtotal").Value, 2)) & " WHERE IDDescription = 7")
                        cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rs.Fields("subtotal").Value, 2)) & " WHERE IDDescription")
                    Case 1
                        lCash = lCash + rs.Fields("amountCash").Value
                        lTotal = lTotal - rs.Fields("amount").Value
                    Case 2
                        lTotal = lTotal - rs.Fields("amount").Value
                        lCredit = lCredit + rs.Fields("amountCredit").Value

                    Case 3
                        lTotal = lTotal - rs.Fields("amount").Value
                        lDebit = lDebit + rs.Fields("amountCard").Value
                    Case 4
                        lCheque = lCheque + rs.Fields("amountCheque").Value
                        lTotal = lTotal - rs.Fields("amount").Value
                    Case 7
                        lTotal = lTotal - rs.Fields("amount").Value
                        lCash = lCash + rs.Fields("amountCash").Value
                        lDebit = lDebit + rs.Fields("amountCard").Value
                        lCredit = lCredit + rs.Fields("amountCredit").Value
                        lCheque = lCheque + rs.Fields("amountCheque").Value
                End Select
                rs.moveNext()
            Loop
            rs.Close()

            'Get Output Vat.......................

            sql2 = "SELECT SaleItem.SaleItem_StockItemID, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ActualCost]*[SaleItem_Quantity],[SaleItem_ActualCost]*[SaleItem_Quantity])) AS actualCostSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ListCost]*[SaleItem_Quantity],[SaleItem_ListCost]*[SaleItem_Quantity])) AS listCostSum, Sum(([SaleItem_Price]*[SaleItem_Quantity]/(1+[SaleItem_Vat]/100))) AS exclusiveSum, Sum(([SaleItem_Price]*[SaleItem_Quantity])) AS inclusiveSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_DepositCost]*[SaleItem_Quantity],[SaleItem_DepositCost]*[SaleItem_Quantity])) AS depositSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) AS quantitySum FROM Sale INNER JOIN (aConsignment AS aConsignment_1 RIGHT JOIN (SaleItem LEFT JOIN aConsignment ON SaleItem.SaleItem_SaleID=aConsignment.Consignment_SaleID) ON aConsignment_1.Consignment_ReversalSaleID=SaleItem.SaleItem_SaleID) ON Sale.SaleID=SaleItem.SaleItem_SaleID" & " Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null))" & " GROUP BY SaleItem.SaleItem_StockItemID;"

            rsSale = getRSreport(sql2)

            vInSales = 0
            If IsDbNull(rsSale("inclusiveSum")) Then
                'If rsSale.EOF Or rsSale.BOF Then
                Report.SetParameterValue("txtOutputVat", FormatNumber(vInSales, 2))
                Report.SetParameterValue("txtOutputVat1", FormatNumber(vInSales, 2))
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(vInSales, 2)) & " WHERE IDDescription = 26")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * vInSales, 2)) & " WHERE IDDescription = 27")

                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(vInSales, 2)) & " WHERE IDDescription = 26")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * vInSales, 2)) & " WHERE IDDescription = 27")
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object rsSale.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Do While rsSale.EOF = False
                    vInSales = vInSales + rsSale("inclusiveSum").Value
                    vExSales = vExSales + rsSale("exclusiveSum").Value
                    rsSale.moveNext()
                Loop
                vVatSales = vInSales - vExSales

                Report.SetParameterValue("txtOutputVat", FormatNumber(vVatSales, 2))
                Report.SetParameterValue("txtOutputVat1", FormatNumber(vVatSales, 2))
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(vVatSales, 2)) & " WHERE IDDescription = 26")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * vVatSales, 2)) & " WHERE IDDescription = 27")

                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(vVatSales, 2)) & " WHERE IDDescription = 26")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * vVatSales, 2)) & " WHERE IDDescription = 27")
            End If
            rsSale.Close()

            'get Settlement movement
            vInSales = 0
            rsSale = getRSreport("SELECT Sum([CustomerTransaction_Amount]) AS SttTotal From CustomerTransaction WHERE CustomerTransaction_TransactionTypeID=8;")

            If IsDBNull(rsSale("SttTotal")) Then
                Report.SetParameterValue("txtSettlement", FormatNumber(vInSales, 2))
                Report.SetParameterValue("txtSettlement1", FormatNumber(vInSales, 2))
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(vInSales, 2)) & " WHERE IDDescription = 11")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * vInSales, 2)) & " WHERE IDDescription = 12")

                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(vInSales, 2)) & " WHERE IDDescription = 11")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * vInSales, 2)) & " WHERE IDDescription = 12")
            Else
                If rsSale("SttTotal").Value < 0 Then
                    Report.SetParameterValue("txtSettlement", FormatNumber(-1 * rsSale("SttTotal").Value, 0))
                    Report.SetParameterValue("txtSettlement1", FormatNumber(-1 * rsSale("SttTotal").Value, 0))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rsSale("SttTotal").Value, 0)) & " WHERE IDDescription = 11")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rsSale("SttTotal").Value, 0)) & " WHERE IDDescription = 12")

                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rsSale("SttTotal").Value, 0)) & " WHERE IDDescription = 11")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rsSale("SttTotal"), 0)) & " WHERE IDDescription = 12")
                Else
                    Report.SetParameterValue("txtSettlement", FormatNumber(rsSale("SttTotal"), 0))
                    Report.SetParameterValue("txtSettlement1", FormatNumber(rsSale("SttTotal"), 0))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rsSale("SttTotal"), 0)) & " WHERE IDDescription = 11")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rsSale("SttTotal").Value, 0)) & " WHERE IDDescription = 12")

                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rsSale("SttTotal"), 0)) & " WHERE IDDescription = 11")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rsSale("SttTotal").Value, 0)) & " WHERE IDDescription = 12")
                End If
            End If

            rsSale.Close()

            rsSale = getRSreport("SELECT Sum(SupplierTransaction.SupplierTransaction_Amount) AS SttTotal FROM SupplierTransaction WHERE (((SupplierTransaction.SupplierTransaction_TransactionTypeID)=8));")
            vInSales = 0
            If IsDbNull(rsSale("SttTotal")) Then
                'If rsSale.EOF Or rsSale.BOF Then
                Report.SetParameterValue("txtSettlementD", FormatNumber(vInSales, 2))
                Report.SetParameterValue("txtSettlementD1", FormatNumber(vInSales, 2))
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(vInSales, 2)) & " WHERE IDDescription = 24")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * vInSales, 2)) & " WHERE IDDescription = 25")

                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(vInSales, 2)) & " WHERE IDDescription = 24")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * vInSales, 2)) & " WHERE IDDescription = 25")
            Else
                If rsSale("SttTotal").Value < 0 Then
                    Report.SetParameterValue("txtSettlementD", FormatNumber(-1 * rsSale("SttTotal").Value, 2))
                    Report.SetParameterValue("txtSettlementD1", FormatNumber(-1 * rsSale("SttTotal").Value, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rsSale("SttTotal").Value, 2)) & " WHERE IDDescription = 24")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rsSale("SttTotal"), 2)) & " WHERE IDDescription = 25")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rsSale("SttTotal").Value, 2)) & " WHERE IDDescription = 24")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rsSale("SttTotal"), 2)) & " WHERE IDDescription = 25")
                Else
                    Report.SetParameterValue("txtSettlementD", FormatNumber(rsSale("SttTotal"), 2))
                    Report.SetParameterValue("txtSettlementD1", FormatNumber(rsSale("SttTotal"), 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rsSale("SttTotal"), 2)) & " WHERE IDDescription = 24")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rsSale("SttTotal").Value, 2)) & " WHERE IDDescription = 25")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rsSale("SttTotal"), 2)) & " WHERE IDDescription = 24")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rsSale("SttTotal").Value, 2)) & " WHERE IDDescription = 25")
                End If
            End If

            rsSale.Close()

            rsSale = getRSreport("SELECT Sum(SupplierTransaction.SupplierTransaction_Amount) AS SttTotal FROM SupplierTransaction WHERE (((SupplierTransaction.SupplierTransaction_TransactionTypeID)=3));")
            vInSales = 0
            If IsDBNull(rsSale("SttTotal")) Then
                'If rsSale.EOF Or rsSale.BOF Then
                Report.SetParameterValue("txtCreditorPay", FormatNumber(vInSales, 2))
                Report.SetParameterValue("txtCreditorPay1", FormatNumber(vInSales, 2))
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(vInSales, 2)) & " WHERE IDDescription = 22")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * vInSales, 2)) & " WHERE IDDescription = 23")

                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(vInSales, 2)) & " WHERE IDDescription = 22")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * vInSales, 2)) & " WHERE IDDescription = 23")
            Else
                If rsSale("SttTotal").Value < 0 Then
                    Report.SetParameterValue("txtCreditorPay", FormatNumber(-1 * rsSale("SttTotal").Value, 2))
                    Report.SetParameterValue("txtCreditorPay1", FormatNumber(-1 * rsSale("SttTotal").Value, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rsSale("SttTotal").Value, 2)) & " WHERE IDDescription = 22")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rsSale("SttTotal"), 2)) & " WHERE IDDescription = 23")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rsSale("SttTotal").Value, 2)) & " WHERE IDDescription = 22")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rsSale("SttTotal"), 2)) & " WHERE IDDescription = 23")
                Else
                    Report.SetParameterValue("txtCreditorPay", FormatNumber(rsSale("SttTotal"), 2))
                    Report.SetParameterValue("txtCreditorPay1", FormatNumber(rsSale("SttTotal"), 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rsSale("SttTotal"), 2)) & " WHERE IDDescription = 22")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rsSale("SttTotal").Value, 2)) & " WHERE IDDescription = 23")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rsSale("SttTotal"), 2)) & " WHERE IDDescription = 22")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rsSale("SttTotal").Value, 2)) & " WHERE IDDescription = 23")
                End If
            End If

            'do money movement....................
            lCash = 0
            lDebit = 0
            lCheque = 0
            lCredit = 0
            lTotal = 0
            rs = getRSreport("SELECT Sale.Sale_PaymentType,Sum(Sale.Sale_Total) as AmountTotal, Sum(Sale.Sale_Cash) AS amountCash,Sum(Sale.Sale_Card) AS amountCard,Sum(Sale.Sale_Cheque) AS amountCheque,Sum(Sale.Sale_CDebit) AS amountCredit FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_PaymentType;")

            Do Until rs.EOF
                Select Case rs.Fields("Sale_PaymentType").Value
                    Case 1
                        lCash = lCash + rs.Fields("amountCash").Value
                        lTotal = lTotal + rs.Fields("AmountTotal").Value
                        Report.SetParameterValue("txtMoneyCash", FormatNumber(rs("amount"), 2))
                    Case 2
                        lCredit = lCredit + rs.Fields("amountCredit").Value
                        lTotal = lTotal + rs.Fields("AmountTotal").Value
                        Report.SetParameterValue("txtMoneyCRcard", FormatNumber(rs("amount"), 2))
                    Case 3
                        lDebit = lDebit + rs.Fields("amountCard").Value
                        lTotal = lTotal + rs.Fields("AmountTotal").Value
                        Report.SetParameterValue("txtMoneyDRcard", FormatNumber(rs("amount"), 2))
                    Case 4
                        lTotal = lTotal + rs.Fields("AmountTotal").Value
                        lCheque = lCheque + rs.Fields("amountCheque").Value
                        Report.SetParameterValue("txtMoneyCheque", FormatNumber(rs("amount"), 2))
                    Case 7
                        lTotal = lTotal + rs.Fields("AmountTotal").Value
                        lCash = lCash + rs.Fields("amountCash").Value
                        lDebit = lDebit + rs.Fields("amountCard").Value
                        lCredit = lCredit + rs.Fields("amountCredit").Value
                        lCheque = lCheque + rs.Fields("amountCheque").Value
                End Select
                rs.moveNext()
            Loop
            rs.Close()

            '1. Cash
            Report.SetParameterValue("txtMoneyCash", FormatNumber(lCash, 2))
            cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(lCash, 2)) & " WHERE IDDescription = 1")
            cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(lCash, 2)) & " WHERE IDDescription = 1")
            '2. Credit Card
            Report.SetParameterValue("txtMoneyCRcard", FormatNumber(lCredit, 2))
            cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(lCredit, 2)) & " WHERE IDDescription = 3")
            cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(lCredit, 2)) & " WHERE IDDescription = 3")
            '3. Debit Card.
            Report.SetParameterValue("txtMoneyDRcard", FormatNumber(lDebit, 2))
            cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(lDebit, 2)) & " WHERE IDDescription = 4")
            cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(lDebit, 2)) & " WHERE IDDescription = 4")
            '4. Cheque
            Report.SetParameterValue("txtMoneyCheque", FormatNumber(lCheque, 2))
            cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(lCheque, 2)) & " WHERE IDDescription = 2")
            cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(lCheque, 2)) & " WHERE IDDescription = 2")

            'Total Money movement
            Report.SetParameterValue("txtMoneyTotal", FormatNumber(lTotal, 2))
            cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * lTotal, 2)) & " WHERE IDDescription = 13")
            cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * lTotal, 2)) & " WHERE IDDescription = 13")
            lTotal = 0

            'do invoice discount...........
            rs = getRSreport("SELECT Sum(Sale.Sale_Discount) AS amount FROM aConsignment RIGHT JOIN (aConsignment AS aConsignment_1 RIGHT JOIN Sale ON aConsignment_1.Consignment_SaleID = Sale.SaleID) ON aConsignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null));")
            If IsDbNull(rs.Fields("amount").Value) Then
                Report.SetParameterValue("txtStockDiscount", "0.00")
            Else
                If rs.RecordCount Then
                    Report.SetParameterValue("txtStockDiscount", FormatNumber(0 - rs("amount").Value, 2))
                    Report.SetParameterValue("txtSCmDiscount", FormatNumber(0 - rs("amount").Value, 2))
                Else
                    Report.SetParameterValue("txtStockDiscount", "0.00")
                End If
            End If
            rs.Close()

            rs = getRSreport("SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS content, CBool([SaleItem_DepositType]) AS depositType, SaleItem.SaleItem_Reversal, Sum(([SaleItem_DepositCost]*[SaleItem_Quantity])*(1+[SaleItem_Vat]/100)) AS deposit FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY CBool([SaleItem_DepositType]), SaleItem.SaleItem_Reversal;")
            Do Until rs.EOF
                If rs.Fields("depositType").Value Then
                    If rs.Fields("SaleItem_Reversal").Value Then
                        Report.SetParameterValue("txtStockDepositSold", FormatNumber(rs("content"), 2))
                    Else
                        Report.SetParameterValue("txtStockDepositReturn", FormatNumber(rs("content"), 2))
                    End If
                Else
                    If rs.Fields("SaleItem_Reversal").Value Then
                        Report.SetParameterValue("txtStockCreditContent", FormatNumber(rs("content"), 2))
                        Report.SetParameterValue("txtStockCreditDeposit", FormatNumber(0 - rs("deposit").Value, 2))
                    Else
                        Report.SetParameterValue("txtStockSoldContent", FormatNumber(rs("content"), 2))
                        Report.SetParameterValue("txtStockSoldDeposit", FormatNumber(rs("deposit"), 2))
                    End If
                End If
                rs.moveNext()
            Loop
            rs.Close()
            On Error Resume Next
            rs = getRSreport("SELECT Sum(aCustomerTransaction.CustomerTransaction_Amount) AS SumOfCustomerTransaction_Amount FROM aCustomerTransaction INNER JOIN DayEnd ON aCustomerTransaction.CustomerTransaction_DayEndID = DayEnd.DayEndID WHERE (((aCustomerTransaction.CustomerTransaction_TransactionTypeID)=3 Or (aCustomerTransaction.CustomerTransaction_TransactionTypeID)=4 Or (aCustomerTransaction.CustomerTransaction_TransactionTypeID)=5) AND ((aCustomerTransaction.CustomerTransaction_ReferenceID)=0));")
            If rs.RecordCount Then
                If rs.Fields("SumOfCustomerTransaction_Amount").Value < 0 Then
                    Report.SetParameterValue("txtAccountEFT", FormatNumber(-1 * rs.Fields("SumOfCustomerTransaction_Amount").Value, 2))
                    Report.SetParameterValue("txtAccountEFT1", FormatNumber(-1 * rs.Fields("SumOfCustomerTransaction_Amount").Value, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) & " WHERE IDDescription = 9")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) & " WHERE IDDescription = 10")

                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) & " WHERE IDDescription = 9")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) & " WHERE IDDescription = 10")
                Else
                    Report.SetParameterValue("txtAccountEFT", FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2))
                    Report.SetParameterValue("txtAccountEFT1", FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) & " WHERE IDDescription = 9")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) & " WHERE IDDescription = 10")

                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) & " WHERE IDDescription = 9")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) & " WHERE IDDescription = 10")
                End If
            Else
                Report.SetParameterValue("txtAccountEFT", FormatNumber(0, 2))
                Report.SetParameterValue("txtAccountEFT1", FormatNumber(0, 2))
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 9")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 10")

                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 9")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 10")
            End If

            rDisplay_F = getRS("SELECT * FROM PastelDescription Order By IDDescription ASC")

            For intF = 1 To 29
                Report.SetParameterValue("txtDes1", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar1", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc1", rDisplay_F.Fields("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes2", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar2", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc2", rDisplay_F.Fields("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes3", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar3", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc3", rDisplay_F.Fields("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes4", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar4", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc4", rDisplay_F.Fields("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes5", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar5", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc5", rDisplay_F.Fields("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes6", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar6", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc6", rDisplay_F.Fields("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes7", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar7", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc7", rDisplay_F.Fields("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes8", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar8", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc8", rDisplay_F.Fields("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes9", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar9", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc9", rDisplay_F.Fields("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes10", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar10", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc10", rDisplay_F.Fields("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes11", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar11", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc11", rDisplay_F.Fields("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes12", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar12", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc12", rDisplay_F.Fields("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes13", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar13", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc13", rDisplay_F.Fields("AccountNumber"))
                rDisplay_F.moveNext()
                'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtDes14. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Report.SetParameterValue("txtDes14", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar14", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc14", rDisplay_F.Fields("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes15", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar15", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc15", rDisplay_F.Fields("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes16", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar16", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc16", rDisplay_F.Fields("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes17", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar17", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc17", rDisplay_F.Fields("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes18", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar18", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc18", rDisplay_F.Fields("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes19", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar19", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc19", rDisplay_F.Fields("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes20", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar20", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc20", rDisplay_F.Fields("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes21", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar21", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc21", rDisplay_F.Fields("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes22", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar22", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc22", rDisplay_F.Fields("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes23", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar23", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc23", rDisplay_F.Fields("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes24", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar24", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc24", rDisplay_F.Fields("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes25", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar25", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc25", rDisplay_F.Fields("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes26", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar26", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc26", rDisplay_F.Fields("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes27", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar27", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc27", rDisplay_F.Fields("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes28", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar28", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc28", rDisplay_F.Fields("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes29", rDisplay_F.Fields("Description"))
                Report.SetParameterValue("txtNar29", rDisplay_F.Fields("Decription1"))
                Report.SetParameterValue("txtAcc29", rDisplay_F.Fields("AccountNumber"))
                Exit For
            Next

            If lMode Then
            Else
                rs = getRSreport("SELECT Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost]) AS listSales, Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ActualCost]) AS actualSales, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS listShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actualShrink, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost]) AS listGRV, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ActualCost]) AS actualGRV FROM DayEndStockItemLnk;")
                If IsDbNull(rs.Fields("listShrink").Value) Then
                    Report.SetParameterValue("txtSHRL", FormatNumber(0, 2))
                    Report.SetParameterValue("txtSHRL1", FormatNumber(0, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 14")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 15")

                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 14")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 15")
                Else
                    If rs.Fields("listShrink").Value < 0 Then
                        Report.SetParameterValue("txtSHRL", FormatNumber(-1 * rs.Fields("listShrink").Value, 2))
                        Report.SetParameterValue("txtSHRL1", FormatNumber(-1 * rs.Fields("listShrink").Value, 2))
                    Else
                        Report.SetParameterValue("txtSHRL", FormatNumber(rs.Fields("listShrink").Value, 2))
                        Report.SetParameterValue("txtSHRL1", FormatNumber(rs.Fields("listShrink").Value, 2))
                    End If
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("listShrink").Value, 2)) & " WHERE IDDescription = 14")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rs.Fields("listShrink").Value, 2)) & " WHERE IDDescription = 15")

                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("listShrink").Value, 2)) & " WHERE IDDescription = 14")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rs.Fields("listShrink").Value, 2)) & " WHERE IDDescription = 15")
                End If

                'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                If IsDbNull(rs.Fields("listGRV").Value) Then
                    Report.SetParameterValue("txtGRVL1", FormatNumber(0, 2))
                    Report.SetParameterValue("txtGRVL", FormatNumber(0, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 20")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 21")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 28")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 29")

                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 20")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 21")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 28")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 29")
                Else
                    Report.SetParameterValue("txtGRVL1", FormatNumber(rs.Fields("listGRV").Value, 2))
                    Report.SetParameterValue("txtGRVL", FormatNumber(rs.Fields("listGRV").Value, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("listGRV").Value, 2)) & " WHERE IDDescription = 20")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rs.Fields("listGRV").Value, 2)) & " WHERE IDDescription = 21")

                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("listGRV").Value, 2)) & " WHERE IDDescription = 20")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rs.Fields("listGRV").Value, 2)) & " WHERE IDDescription = 21")
                    VatEx = (rs.Fields("listGRV").Value * 1.14) - rs.Fields("listGRV").Value
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(VatEx, 2)) & " WHERE IDDescription = 28")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * VatEx, 2)) & " WHERE IDDescription = 29")

                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(VatEx, 2)) & " WHERE IDDescription = 28")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * VatEx, 2)) & " WHERE IDDescription = 29")
                End If

                If IsDbNull(rs.Fields("listSales").Value) Then
                    Report.SetParameterValue("txtSaleL", FormatNumber(0, 2))
                    Report.SetParameterValue("txtSaleL1", FormatNumber(0, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 16")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 17")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 16")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 17")
                Else
                    Report.SetParameterValue("txtSaleL", FormatNumber(rs.Fields("listSales").Value, 2))
                    Report.SetParameterValue("txtSaleL1", FormatNumber(rs.Fields("listSales").Value, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rs.Fields("listSales").Value, 2)) & " WHERE IDDescription = 16")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("listSales").Value, 2)) & " WHERE IDDescription = 17")

                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rs.Fields("listSales").Value, 2)) & " WHERE IDDescription = 16")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("listSales").Value, 2)) & " WHERE IDDescription = 17")
                End If
            End If

            rs = getRSreport("SELECT Sum([Sale]![Sale_Total]+[Sale_1]![Sale_Total]) AS priceReturn, Sale.Sale_Total FROM Sale INNER JOIN (Sale AS Sale_1 INNER JOIN aConsignment ON Sale_1.SaleID = aConsignment.Consignment_ReversalSaleID) ON Sale.SaleID = aConsignment.Consignment_CompleteSaleID GROUP BY Sale.Sale_Total;")
            If rs.BOF Or rs.EOF Then
                Report.SetParameterValue("txtConsPPurchase", FormatNumber("0", 2))
                Report.SetParameterValue("txtConsPreturn", FormatNumber("0", 2))
            Else
                If IsDbNull(rs.Fields("Sale_Total").Value) Then
                    Report.SetParameterValue("txtConsPPurchase", FormatNumber("0", 2))
                    Report.SetParameterValue("txtConsPreturn", FormatNumber("0", 2))
                Else
                    Report.SetParameterValue("txtConsPPurchase", FormatNumber(rs("Sale_Total"), 2))
                    Report.SetParameterValue("txtConsPreturn", FormatNumber(rs("priceReturn"), 2))
                End If
            End If

        End If

        Dim rsPTotalss As ADODB.Recordset

        rsPTotals = getRS("SELECT SUM(Amount) As totDebit FROM PastelDescription WHERE Amount > 0")
        rsPTotalss = getRS("SELECT SUM(Amount) as totCredit FROM PastelDescription WHERE Amount < 0")

        If IsDbNull(rsPTotals.Fields("totDebit").Value) Then
            Report.SetParameterValue("txtDebit", FormatNumber(0, 2))
        Else
            Report.SetParameterValue("txtDebit", FormatNumber(rsPTotals.Fields("totDebit").Value))
        End If
        If IsDbNull(rsPTotalss.Fields("totCredit").Value) Then
            Report.SetParameterValue("txtCredit", FormatNumber(0, 2))
        Else
            Report.SetParameterValue("txtCredit", FormatNumber(rsPTotalss.Fields("totCredit").Value))
        End If

        If blpastel = True Then 'Pastel export file
            System.Windows.Forms.Cursor.Current = Cursors.Default
            Exit Sub
        End If

        Report.Database.Tables(1).SetDataSource(rsGRVItem)
        Report.Database.Tables(2).SetDataSource(rsGRVItemReturn)
        Report.Database.Tables(3).SetDataSource(rsGRVDeposit)
        Report.Database.Tables(4).SetDataSource(rsGRVDepositReturn)
        Report.Database.Tables(5).SetDataSource(rsGRVMain)
        Report.Database.Tables(6).SetDataSource(rsGRVPricing)

        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub
    Private Sub report_HourlyDayReport()
        Dim sql2 As String
        Dim rsSale As ADODB.Recordset
        Dim SumSales As Decimal
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New crydayhourlynew
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("crydayhourlynew.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        rs.Close()
        sql = "SELECT * FROM Sale"
        rs = getRSreport(sql)
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        sql2 = "SELECT SaleItem.SaleItem_StockItemID, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ActualCost]*[SaleItem_Quantity],[SaleItem_ActualCost]*[SaleItem_Quantity])) AS actualCostSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ListCost]*[SaleItem_Quantity],[SaleItem_ListCost]*[SaleItem_Quantity])) AS listCostSum, Sum(([SaleItem_Price]*[SaleItem_Quantity]/(1+[SaleItem_Vat]/100))) AS exclusiveSum, Sum(([SaleItem_Price]*[SaleItem_Quantity])) AS inclusiveSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_DepositCost]*[SaleItem_Quantity],[SaleItem_DepositCost]*[SaleItem_Quantity])) AS depositSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) AS quantitySum FROM Sale INNER JOIN (aConsignment AS aConsignment_1 RIGHT JOIN (SaleItem LEFT JOIN aConsignment ON SaleItem.SaleItem_SaleID=aConsignment.Consignment_SaleID) ON aConsignment_1.Consignment_ReversalSaleID=SaleItem.SaleItem_SaleID) ON Sale.SaleID=SaleItem.SaleItem_SaleID" & " Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null))" & " GROUP BY SaleItem.SaleItem_StockItemID;"

        rsSale = getRSreport(sql2)
        Do While rsSale.EOF = False
            SumSales = SumSales + rsSale.Fields("inclusiveSum").Value

            rsSale.moveNext()
        Loop

        Report.Database.Tables(1).SetDataSource(rs)

        Report.SetParameterValue("txtSum", FormatNumber(SumSales, 2))
        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub
    Public Sub report_HandHeldScanner()
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryHandHeld
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryHandHeld.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDateH", CDate(Today))

        rs.Close()

        sql = "SELECT " & stTableName & ".HandHeldID,StockItem.StockItem_Name," & stTableName & ".Quantity,StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID,StockItem.StockItem_Quantity,StockTake.StockTake_WarehouseID," & stTableName & ".HandHeldID FROM " & "(StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN " & stTableName & " ON StockItem.StockItemID = " & stTableName & ".HandHeldID WHERE StockTake.StockTake_WarehouseID = 2 AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ORDER BY StockItem.StockItem_Name;"

        rs = getRS(sql)

        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
           frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.Database.Tables(1).SetDataSource(rs)
        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub


    Private Sub report_Shrinkage()
        Dim rsWH As ADODB.Recordset
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryShrinkage
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryShrinkage.rpt")
       System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        rs.Close()

        'Multi Warehouse change
        Dim lMWNo As Integer
        lMWNo = frmMWSelect.getMWNo
        If lMWNo > 1 Then
            rsWH = getRS("SELECT * FROM Warehouse WHERE WarehouseID=" & lMWNo & ";")
            Report.SetParameterValue("txtWH", rsWH("Warehouse_Name"))
        End If
        'Multi Warehouse change


        'Multi Warehouse change     Set rs = getRSreport("SELECT aStockItem.StockItem_Name, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS list, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actual FROM DayEndStockItemLnk LEFT JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID Where (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0)) GROUP BY aStockItem.StockItem_Name ORDER BY aStockItem.StockItem_Name;")
        'Set rs = getRSreport("SELECT aStockItem.StockItem_Name, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS list, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actual, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse FROM DayEndStockItemLnk LEFT JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID Where (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0)) GROUP BY aStockItem.StockItem_Name, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse Having (((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse) = " & lMWNo & ")) ORDER BY aStockItem.StockItem_Name;")

        '+ - sign change
        Dim bSign As Boolean
        Dim rsSign As ADODB.Recordset
        rsSign = getRS("SELECT Company_ShrinkSign FROM Company;")
        If rsSign.RecordCount Then
            If rsSign.Fields("Company_ShrinkSign").Value Then bSign = True
        End If
        '+ - sign change
        'sql = "SELECT aStockItem.StockItem_Name, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS list, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actual, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse, CatalogueChannelLnk.CatalogueChannelLnk_Price"
        'sql = sql & " FROM (DayEndStockItemLnk LEFT JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) INNER JOIN CatalogueChannelLnk ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID Where (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0)) GROUP BY aStockItem.StockItem_Name, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price Having (((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse) = " & lMWNo & ") And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1)) ORDER BY aStockItem.StockItem_Name;"
        If bSign Then
            sql = "SELECT aStockItem.StockItem_Name, (0 - Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink)) AS SumOfDayEndStockItemLnk_QuantityShrink, (0 - Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost])) AS list, (0 - Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost])) AS actual, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse, CatalogueChannelLnk.CatalogueChannelLnk_Price"
            sql = sql & " FROM (DayEndStockItemLnk LEFT JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) INNER JOIN CatalogueChannelLnk ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID Where (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0)) GROUP BY aStockItem.StockItem_Name, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price Having (((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse) = " & lMWNo & ") And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1)) ORDER BY aStockItem.StockItem_Name;"
        Else
            sql = "SELECT aStockItem.StockItem_Name, Sum(DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) AS SumOfDayEndStockItemLnk_QuantityShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS list, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actual, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse, CatalogueChannelLnk.CatalogueChannelLnk_Price"
            sql = sql & " FROM (DayEndStockItemLnk LEFT JOIN aStockItem ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem.StockItemID) INNER JOIN CatalogueChannelLnk ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID Where (((DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink) <> 0)) GROUP BY aStockItem.StockItem_Name, DayEndStockItemLnk.DayEndStockItemLnk_Warehouse, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price Having (((DayEndStockItemLnk.DayEndStockItemLnk_Warehouse) = " & lMWNo & ") And ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity) = 1) And ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = 1)) ORDER BY aStockItem.StockItem_Name;"
        End If
        rs = getRSreport(sql)

        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If
        Report.Database.Tables(1).SetDataSource(rs)

        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Private Sub report_BasketValue()
        Dim rs As ADODB.Recordset
        Dim rsPayment As ADODB.Recordset
        Dim rsChannel As ADODB.Recordset
        Dim sql As String
        ' Dim Report As New cryBasketValue
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryBasketValue.rpt")

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        rs.Close()
        rs = getRSreport("SELECT * FROM Link Where LinkID=2 AND Link_SectionID=1")
        sql = "SELECT Count(theJoin.SaleID) AS CountOfSaleItemID, Sum(theJoin.quantity) AS quantity, Sum(theJoin.price) AS price, theJoin.Sale_PaymentType FROM (SELECT Sum(IIf([SaleItem_Reversal],0-[SaleItem_Quantity],[SaleItem_Quantity])) AS quantity, Sum(([SaleItem_Price]*[SaleItem_Quantity])) AS price, Sale.Sale_PaymentType, Sale.SaleID FROM SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_DepositType) = 0)) GROUP BY Sale.Sale_PaymentType, Sale.SaleID) AS theJoin GROUP BY theJoin.Sale_PaymentType;"
        rsPayment = getRSreport(sql)
        sql = "SELECT Count(theJoin.SaleID) AS CountOfSaleItemID, Sum(theJoin.quantity) AS quantity, Sum(theJoin.price) AS price, aChannel.ChannelID, aChannel.Channel_Name FROM aChannel INNER JOIN (SELECT Sum(IIf([SaleItem_Reversal],0-[SaleItem_Quantity],[SaleItem_Quantity])) AS quantity, Sum(([SaleItem_Price]*[SaleItem_Quantity])) AS price, Sale.Sale_ChannelID, Sale.SaleID FROM SaleItem INNER JOIN Sale ON SaleItem.SaleItem_SaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = 0) And ((SaleItem.SaleItem_DepositType) = 0)) GROUP BY Sale.Sale_ChannelID, Sale.SaleID) AS theJoin ON aChannel.ChannelID = theJoin.Sale_ChannelID GROUP BY aChannel.ChannelID, aChannel.Channel_Name;"
        rsChannel = getRSreport(sql)
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rsPayment.BOF Or rsPayment.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
             frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If
        Report.OpenSubreport("Subreport1").Database.Tables(1).SetDataSource(rsPayment)
        Report.OpenSubreport("Subreport2").Database.Tables(1).SetDataSource(rsChannel)
        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub
    Private Sub report_Banking()
        Dim rs As ADODB.Recordset
        Dim sql As String
        'Dim Report As New cryBanking
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryBanking.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        rs.Close()
        rs = getRSreport("SELECT aPOS.POSID, aPOS.POS_Name, Sum(Declaration.Declaration_Cash) AS SumOfDeclaration_Cash, Sum(Declaration.Declaration_CashServer) AS SumOfDeclaration_CashServer, Sum(Declaration.Declaration_CashCount) AS SumOfDeclaration_CashCount, Sum(Declaration.Declaration_Cheque) AS SumOfDeclaration_Cheque, Sum(Declaration.Declaration_ChequeServer) AS SumOfDeclaration_ChequeServer, Sum(Declaration.Declaration_ChequeCount) AS SumOfDeclaration_ChequeCount, Sum(Declaration.Declaration_Card) AS SumOfDeclaration_Card, Sum(Declaration.Declaration_CardServer) AS SumOfDeclaration_CardServer, Sum(Declaration.Declaration_CardCount) AS SumOfDeclaration_CardCount, Sum(Declaration.Declaration_Payout) AS SumOfDeclaration_Payout, Sum(Declaration.Declaration_PayoutServer) AS SumOfDeclaration_PayoutServer, Sum(Declaration.Declaration_PayoutCount) AS SumOfDeclaration_PayoutCount FROM Declaration INNER JOIN aPOS ON Declaration.Declaration_POSID = aPOS.POSID GROUP BY aPOS.POSID, aPOS.POS_Name;")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.OpenSubreport("Subreport1").Database.Tables(1).SetDataSource(rs)
        Report.OpenSubreport("Subreport2").Database.Tables(1).SetDataSource(rs)

        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub
    Private Sub report_GRVDetails()
        Dim rs As ADODB.Recordset
        Dim rsGRVItem As ADODB.Recordset
        Dim rsGRVItemReturn As ADODB.Recordset
        Dim rsGRVDeposit As ADODB.Recordset
        Dim rsGRVDepositReturn As ADODB.Recordset
        Dim rsGRVMain As ADODB.Recordset
        Dim rsGRVPricing As ADODB.Recordset

        Dim sql As String
        'Dim Report As New cryGRVDetails
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryGRVDetails.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayend", rs.Fields("Report_Heading"))
        rs.Close()

        'New sql
        'Set rsGRVItem = getRSreport("SELECT aGRV.GRVID,Sum(IIf([GRVItem_Return],0,[GRVItem_DepositCost]*[GRVItem_Quantity])) AS depositExcl, Sum(IIf([GRVItem_Return],0,((((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100))))) AS inclusive,Sum(IIf([GRVItem_Return],0,(((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])))) AS exclusive, Sum(IIf([GRVItem_Return],0,([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100))) AS depositIncl FROM (aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aGRVItem ON aGRV.GRVID = aGRVItem.GRVItem_GRVID Where (((aGRV.GRV_GRVStatusID) = 3)) AND (GRVItem_StockItemQuantity<>0) GROUP BY aGRV.GRVID;")
        'Old

        ' not showing Returned VAT   Set rsGRVItem = getRSreport("SELECT aGRV.GRVID, Sum(IIf([GRVItem_Return],0,(((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])))) AS exclusive, Sum(IIf([GRVItem_Return],0,((((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100))))) AS inclusive, Sum(IIf([GRVItem_Return],0,[GRVItem_DepositCost]*[GRVItem_Quantity])) AS depositExcl, Sum(IIf([GRVItem_Return],0,([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100))) AS depositIncl FROM (aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) LEFT JOIN aGRVItem ON aGRV.GRVID = aGRVItem.GRVItem_GRVID Where (((aGRV.GRV_GRVStatusID) = 3) AND (GRVItem_StockItemQuantity <> 0)) GROUP BY aGRV.GRVID;")
        sql = "SELECT aGRV.GRVID, Sum(IIf([GRVItem_Return],0-(((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])),(((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])))) AS exclusive, Sum(IIf([GRVItem_Return],0-((((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100))),((((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100))))) AS inclusive, Sum(IIf([GRVItem_Return],0-([GRVItem_DepositCost]*[GRVItem_Quantity]),[GRVItem_DepositCost]*[GRVItem_Quantity])) AS depositExcl, "
        sql = sql & "Sum(IIf([GRVItem_Return],0-(([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100)),([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100))) AS depositIncl FROM (aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) "
        sql = sql & "LEFT JOIN aGRVItem ON aGRV.GRVID = aGRVItem.GRVItem_GRVID Where (((aGRV.GRV_GRVStatusID) = 3) AND (GRVItem_StockItemQuantity <> 0)) GROUP BY aGRV.GRVID;"
        rsGRVItem = getRSreport(sql)
        If rsGRVItem.BOF Or rsGRVItem.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        rsGRVItemReturn = getRSreport("SELECT aGRV.GRVID, Sum(IIf([GRVItem_Return],(((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])),0)) AS exclusive, Sum(IIf([GRVItem_Return],((((([GRVItem_PackSize]/[GRVItem_StockItemQuantity]*[GRVItem_ContentCost])-[GRVItem_DiscountAmount])*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100))),0)) AS inclusive, Sum(IIf([GRVItem_Return],[GRVItem_DepositCost]*[GRVItem_Quantity],0)) AS depositExcl, Sum(IIf([GRVItem_Return],([GRVItem_DepositCost]*[GRVItem_Quantity])*(1+[GRVItem_VatRate]/100),0)) AS depositIncl FROM (aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) LEFT JOIN aGRVItem ON aGRV.GRVID = aGRVItem.GRVItem_GRVID Where (((aGRV.GRV_GRVStatusID) = 3)) GROUP BY aGRV.GRVID;")
        If rsGRVItemReturn.BOF Or rsGRVItemReturn.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        rsGRVDeposit = getRSreport("SELECT aGRV.GRVID, Sum(IIf([GRVDeposit_Return],0,(IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,[GRVDeposit_Quantity]*([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]*(1+[GRVDeposit_VatRate]/100)),0))+(IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,[GRVDeposit_quantity]*([GRVDeposit_CaseCost]*(1+[GRVDeposit_VatRate]/100)),0)))) AS inclusiveDepositReturn, Sum(IIf([GRVDeposit_Return],0,(IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,[GRVDeposit_Quantity]*([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]),0))+(IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,[GRVDeposit_quantity]*([GRVDeposit_CaseCost]),0)))) AS exclusiveDepositReturn FROM (aGRV LEFT JOIN aGRVDeposit ON aGRV.GRVID = aGRVDeposit.GRVDeposit_GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID Where (((aGRV.GRV_GRVStatusID) = 3)) GROUP BY aGRV.GRVID;")
        If rsGRVDeposit.BOF Or rsGRVDeposit.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        rsGRVDepositReturn = getRSreport("SELECT aGRV.GRVID, Sum(IIf([GRVDeposit_Return],(IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,[GRVDeposit_Quantity]*([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]*(1+[GRVDeposit_VatRate]/100)),0))+(IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,[GRVDeposit_quantity]*([GRVDeposit_CaseCost]*(1+[GRVDeposit_VatRate]/100)),0)),0)) AS inclusiveDepositReturn, Sum(IIf([GRVDeposit_Return],(IIf([GRVDeposit_Type]=1 Or [GRVDeposit_Type]=3,[GRVDeposit_Quantity]*([GRVDeposit_CaseQuantity]*[GRVDeposit_UnitCost]),0))+(IIf([GRVDeposit_Type]=2 Or [GRVDeposit_Type]=3,[GRVDeposit_quantity]*([GRVDeposit_CaseCost]),0)),0)) AS exclusiveDepositReturn FROM (aGRV LEFT JOIN aGRVDeposit ON aGRV.GRVID = aGRVDeposit.GRVDeposit_GRVID) INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID Where (((aGRV.GRV_GRVStatusID) = 3)) GROUP BY aGRV.GRVID;")
        If rsGRVDepositReturn.BOF Or rsGRVDepositReturn.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        rsGRVMain = getRSreport("SELECT aGRV.GRVID, aGRV.GRV_InvoiceInclusive, aGRV.GRV_InvoiceVat, aGRV.GRV_InvoiceDiscount, aGRV.GRV_SundriesPlus, aGRV.GRV_SundriesMinus, aGRV.GRV_ContentExclusive, ([GRV_ContentExclusive]*(1+[GRV_Ullage]/100)-[GRV_ContentExclusive]) AS Ullage, (1+[GRV_InvoiceVat]/([GRV_InvoiceInclusive]-[GRV_InvoiceVat])) AS vat, Supplier.SupplierID, Supplier.Supplier_Name, aPurchaseOrder.PurchaseOrder_Reference, aGRV.GRV_InvoiceNumber, aGRV.GRV_InvoiceDate FROM ((aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aPurchaseOrder ON aGRV.GRV_PurchaseOrderID = aPurchaseOrder.PurchaseOrderID) INNER JOIN Supplier ON aPurchaseOrder.PurchaseOrder_SupplierID = Supplier.SupplierID WHERE (((aGRV.GRV_GRVStatusID)=3) AND ((aGRV.GRV_InvoiceInclusive)<>0));")
        If rsGRVMain.BOF Or rsGRVMain.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        sql = "SELECT aGRV.GRVID, Sum((([GRVItem_PackSize]/[GRVItem_StockItemQuantity])*[GRVItem_ContentCost]-[GRVItem_DiscountAmount])*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))) AS exclusive, Sum((([GRVItem_PackSize]/[GRVItem_StockItemQuantity])*[GRVItem_ContentCost]-[GRVItem_DiscountAmount])*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))*(1+[GRVItem_VatRate]/100)) AS inclusive, Sum((([GRVItem_PackSize]/[GRVItem_StockItemQuantity])*[GRVItem_ContentCost])*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))) AS PriceExcl, Sum((([GRVItem_PackSize]/[GRVItem_StockItemQuantity])*[GRVItem_ContentCost])*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))*(1+[GRVItem_VatRate]/100)) AS PriceIncl, Sum([DayEndStockItemLnk_ListCost]*[GRVItem_PackSize]*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))) AS listExcl, Sum([DayEndStockItemLnk_ListCost]*[GRVItem_PackSize]*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))*(1+[GRVItem_VatRate]/100)) AS listIncl, "
        sql = sql & "Sum([DayEndStockItemLnk_ActualCost]*[GRVItem_PackSize]*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))*(1+[GRVItem_VatRate]/100)) AS actualIncl, Sum([DayEndStockItemLnk_ActualCost]*[GRVItem_PackSize]*[GRVItem_Quantity]*(IIf([GRVItem_Return],-1,1))) AS actualExcl FROM DayEndStockItemLnk INNER JOIN ((aGRV INNER JOIN DayEnd ON aGRV.GRV_DayEndID = DayEnd.DayEndID) INNER JOIN aGRVItem ON aGRV.GRVID = aGRVItem.GRVItem_GRVID) ON (DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aGRVItem.GRVItem_StockItemID) AND (DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = aGRV.GRV_DayEndID) Where (((aGRV.GRV_GRVStatusID) = 3) AND (GRVItem_StockItemQuantity <> 0)) GROUP BY aGRV.GRVID;"
        rsGRVPricing = getRSreport(sql)
        If rsGRVPricing.BOF Or rsGRVPricing.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.Database.Tables(1).SetDataSource(rsGRVItem)
        Report.Database.Tables(2).SetDataSource(rsGRVItemReturn)
        Report.Database.Tables(3).SetDataSource(rsGRVDeposit)
        Report.Database.Tables(4).SetDataSource(rsGRVDepositReturn)
        Report.Database.Tables(5).SetDataSource(rsGRVMain)
        Report.Database.Tables(6).SetDataSource(rsGRVPricing)

        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub

    Private Sub report_SalesCube()
        Dim sql As String
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim lMode As Boolean
        Dim rs As ADODB.Recordset
        Dim lTotal As Decimal
        Dim lSettDiscount As Decimal
        Dim OnlyAcclSettDiscount As Decimal

        Dim newDis As Decimal
        Dim oldDis As Decimal

        'For Split tender
        Dim lCash As Decimal
        Dim lDebit As Decimal
        Dim lCheque As Decimal
        Dim lCredit As Decimal

        If frmMenu.gSuper = True Then
            Report.Load("crySalesCubeSuper.rpt")
        Else
            'Set Report = New crySalesCube
            Report.Load("crySalesCubeTouch.rpt")
        End If

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        If openConnectionReport() Then
            rs = getRSreport("SELECT aCompany.Company_Name, Report.Report_Heading FROM aCompany, Report;")
            Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
            Report.SetParameterValue("txtFilter", rs.Fields("Report_Heading"))

            'change translation for report
            '
            rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1974
            If rsLang.RecordCount Then Report.SetParameterValue("Text41", Replace(rsLang.Fields("LanguageLayoutLnk_Description").Value, vbCrLf, " "))
            '
            rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1975
            If rsLang.RecordCount Then Report.SetParameterValue("Text42", Replace(rsLang.Fields("LanguageLayoutLnk_Description").Value, vbCrLf, " "))
            '
            rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1976
            If rsLang.RecordCount Then Report.SetParameterValue("Text43", Replace(rsLang.Fields("LanguageLayoutLnk_Description").Value, vbCrLf, " "))
            '
            rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1977
            If rsLang.RecordCount Then Report.SetParameterValue("Text44", Replace(rsLang.Fields("LanguageLayoutLnk_Description").Value, vbCrLf, " "))

            '
            rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1974
            If rsLang.RecordCount Then Report.SetParameterValue("Text57", Replace(rsLang.Fields("LanguageLayoutLnk_Description").Value, vbCrLf, " "))
            '
            rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1975
            If rsLang.RecordCount Then Report.SetParameterValue("Text58", Replace(rsLang.Fields("LanguageLayoutLnk_Description").Value, vbCrLf, " "))
            '
            rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1976
            If rsLang.RecordCount Then Report.SetParameterValue("Text59", Replace(rsLang.Fields("LanguageLayoutLnk_Description").Value, vbCrLf, " "))
            '
            rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1977
            If rsLang.RecordCount Then Report.SetParameterValue("Text60", Replace(rsLang.Fields("LanguageLayoutLnk_Description").Value, vbCrLf, " "))
            'change translation for report

            'get payoutTotal
            rs = getRSreport("SELECT Sum(Payout.Payout_Amount) AS [amount] FROM Payout;")
            If IsDbNull(rs.Fields("amount").Value) Then
                Report.SetParameterValue("txtPayout", "0.00")

            Else
                Report.SetParameterValue("txtPayout", FormatNumber(rs.Fields("amount").Value, 2))

            End If
            rs.Close()

            'get outages.............................

            rs = getRSreport("SELECT Sum(([Declaration_Cash]+[Declaration_Cheque]+[Declaration_Card]-[Declaration_Payout])-([Declaration_CashServer]+[Declaration_ChequeServer]+[Declaration_CardServer]-[Declaration_PayoutServer])) AS amount FROM Declaration;")
            If IsDbNull(rs.Fields("amount").Value) Then
                Report.SetParameterValue("txtOutage", "0.00")
            Else
                Report.SetParameterValue("txtOutage", FormatNumber(rs.Fields("amount").Value, 2))
            End If
            rs.Close()

            'get account movement.....................
            lCash = 0
            lDebit = 0
            lCheque = 0
            lCredit = 0

            lTotal = 0
            lSettDiscount = 0
            OnlyAcclSettDiscount = 0

            rs = getRSreport("SELECT Sum(Sale.Sale_Total) AS amount, Sale.Sale_PaymentType, Sum([Sale_Total]-[Sale_Discount]) AS Subtotal, Sum(Sale.Sale_Discount) AS discount, Sum(Sale.Sale_Cash) AS amountCash,Sum(Sale.Sale_Card) AS amountCard,Sum(Sale.Sale_CDebit) AS amountCredit,Sum(Sale.Sale_Cheque) AS amountCheque FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (CustomerTransaction INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((CustomerTransaction.CustomerTransaction_TransactionTypeID) = 2 Or (CustomerTransaction.CustomerTransaction_TransactionTypeID) = 3) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null) And ((Sale.Sale_SaleChk)=False)) GROUP BY Sale.Sale_PaymentType;")
            'Set rs = getRSreport("SELECT Sum(Sale.Sale_Total) AS amount, Sale.Sale_PaymentType, Sum([Sale_Total]-[Sale_Discount]) AS Subtotal, Sum(Sale.Sale_Discount) AS discount, Sum(Sale.Sale_Cash) AS amountCash,Sum(Sale.Sale_Card) AS amountCard,Sum(Sale.Sale_CDebit) AS amountCredit,Sum(Sale.Sale_Cheque) AS amountCheque FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (CustomerTransaction INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((CustomerTransaction.CustomerTransaction_TransactionTypeID) = 2 Or (CustomerTransaction.CustomerTransaction_TransactionTypeID) = 3) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_PaymentType;")
            Do Until rs.EOF
                Select Case rs.Fields("Sale_PaymentType").Value
                    Case 5
                        'Revise
                        Report.SetParameterValue("txtAccountSales", FormatNumber(rs.Fields("subtotal").Value, 2))
                        Report.SetParameterValue("txtCubeAccountSales", FormatNumber(rs.Fields("subtotal").Value, 2))
                        '05 March 2009 Fixed
                        'changed above both line cuz was showing wrong figures on discounts on Universal paints
                        Report.SetParameterValue("txtAccountSales", FormatNumber(rs.Fields("amount").Value, 2))
                        Report.SetParameterValue("txtCubeAccountSales", FormatNumber(rs.Fields("amount").Value, 2))
                        OnlyAcclSettDiscount = OnlyAcclSettDiscount + rs.Fields("discount").Value
                    Case 1
                        lTotal = lTotal - rs.Fields("amount").Value
                        lCash = lCash + rs.Fields("amountCash").Value

                    Case 2
                        lTotal = lTotal - rs.Fields("amount").Value
                        lCredit = lCredit + rs.Fields("amountCredit").Value

                    Case 3
                        lTotal = lTotal - rs.Fields("amount").Value
                        lDebit = lDebit + rs.Fields("amountCard").Value

                    Case 4
                        lTotal = lTotal - rs.Fields("amount").Value
                        lCheque = lCheque + rs.Fields("amountCheque").Value
                    Case 7
                        lTotal = lTotal - rs.Fields("amount").Value
                        lCash = lCash + rs.Fields("amountCash").Value
                        lDebit = lDebit + rs.Fields("amountCard").Value
                        lCredit = lCredit + rs.Fields("amountCredit").Value
                        lCheque = lCheque + rs.Fields("amountCheque").Value
                End Select

                lSettDiscount = lSettDiscount + rs.Fields("discount").Value
                rs.moveNext()
            Loop

            'Assign account payment......
            Report.SetParameterValue("txtAccountCash", FormatNumber(0 - lCash, 2))
            Report.SetParameterValue("txtAccountCRcard", FormatNumber(0 - lCredit, 2))
            Report.SetParameterValue("txtAccountDRcard", FormatNumber(0 - lDebit, 2))
            Report.SetParameterValue("txtAccountCheque", FormatNumber(0 - lCheque, 2))

            Report.SetParameterValue("txtAccountPayment", FormatNumber(lTotal, 2))
            Report.SetParameterValue("txtCubeAccountPayment", FormatNumber(lTotal, 2))

            '05 March 2009 Fixed
            'changed cuz was showing wrong figures on discounts
            'lTotal = lTotal + CCur(Report.txtAccountSales.Text) '
            lTotal = lTotal + CDec(Report.ParameterFields("txtCubeAccountSales").ToString)

            Report.SetParameterValue("txtCubeAccount", FormatNumber(lTotal, 2))
            Report.SetParameterValue("txtAccountTotal", FormatNumber(lTotal, 2))

            'Settlement Discount........

            rs = getRSreport("SELECT Sum(CustomerTransaction_Amount) AS lSettDiscount FROM CustomerTransaction WHERE CustomerTransaction_TransactionTypeID = 8;") ' AND CustomerTransaction_ReferenceID <> 0;")
            If IsDbNull(rs.Fields("lSettDiscount").Value) Then
                Report.SetParameterValue("txtSettlementDiscount", "0.00")
            Else
                Report.SetParameterValue("txtSettlementDiscount", FormatNumber(rs.Fields("lSettDiscount").Value, 2))
            End If
            rs.Close()

            '---------------------------
            'Do money movement...
            lCash = 0
            lDebit = 0
            lCheque = 0
            lCredit = 0

            lTotal = 0
            'Set rs = getRSreport("SELECT Sale.Sale_PaymentType,Sum(Sale.Sale_Total) as AmountTotal, Sum(Sale.Sale_Cash) AS amountCash,Sum(Sale.Sale_Card) AS amountCard,Sum(Sale.Sale_Cheque) AS amountCheque,Sum(Sale.Sale_CDebit) AS amountCredit FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null) And ((Sale.Sale_SaleChk)=False)) GROUP BY Sale.Sale_PaymentType;")
            rs = getRSreport("SELECT Sale.Sale_PaymentType,Sum(Sale.Sale_Total) as AmountTotal, Sum(Sale.Sale_Cash) AS amountCash,Sum(Sale.Sale_Card) AS amountCard,Sum(Sale.Sale_Cheque) AS amountCheque,Sum(Sale.Sale_CDebit) AS amountCredit FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_PaymentType;")
            Do Until rs.EOF
                Select Case rs.Fields("Sale_PaymentType").Value
                    Case 1
                        lCash = lCash + rs.Fields("amountCash").Value
                        lTotal = lTotal + rs.Fields("AmountTotal").Value
                    Case 2
                        lCredit = lCredit + rs.Fields("amountCredit").Value
                        lTotal = lTotal + rs.Fields("AmountTotal").Value
                    Case 3
                        lDebit = lDebit + rs.Fields("amountCard").Value
                        lTotal = lTotal + rs.Fields("AmountTotal").Value
                    Case 4
                        lTotal = lTotal + rs.Fields("AmountTotal").Value
                        lCheque = lCheque + rs.Fields("amountCheque").Value
                    Case 7
                        lTotal = lTotal + rs.Fields("AmountTotal").Value
                        lCash = lCash + rs.Fields("amountCash").Value
                        lDebit = lDebit + rs.Fields("amountCard").Value
                        lCredit = lCredit + rs.Fields("amountCredit").Value
                        lCheque = lCheque + rs.Fields("amountCheque").Value
                End Select
                rs.moveNext()
            Loop

            'Assign values....
            Report.SetParameterValue("txtMoneyCash", FormatNumber(lCash, 2))
            Report.SetParameterValue("txtMoneyCRcard", FormatNumber(lCredit, 2))
            Report.SetParameterValue("txtMoneyDRcard", FormatNumber(lDebit, 2))
            Report.SetParameterValue("txtMoneyCheque", FormatNumber(lCheque, 2))
            rs.Close()
            Report.SetParameterValue("txtCubeMoney", FormatNumber(lTotal, 2))
            Report.SetParameterValue("txtMoneyTotal", FormatNumber(lTotal, 2))
            'Report.txtMoneyTotal.SetText FormatNumber(lTotal - (CCur(Report.txtStockDiscount.Text) + newDis + CCur(Abs(IIf(Report.txtStockGratuity.Text = " ", "0", Report.txtStockGratuity.Text)))), 2)
            '-------------

            '------------- Discounts
            'Set rs = getRSreport("SELECT Sum(Sale.Sale_Discount) AS amount FROM aConsignment RIGHT JOIN (aConsignment AS aConsignment_1 RIGHT JOIN Sale ON aConsignment_1.Consignment_SaleID = Sale.SaleID) ON aConsignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null) And ((Sale.Sale_SaleChk)=False));")
            rs = getRSreport("SELECT Sum(Sale.Sale_Discount) AS amount FROM aConsignment RIGHT JOIN (aConsignment AS aConsignment_1 RIGHT JOIN Sale ON aConsignment_1.Consignment_SaleID = Sale.SaleID) ON aConsignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null));")
            If IsDbNull(rs.Fields("amount").Value) Then
                Report.SetParameterValue("txtStockDiscount", "0.00")
                oldDis = 0
            Else
                If rs.RecordCount Then
                    'Report.txtStockDiscount.SetText FormatNumber(0 - rs("amount"), 2)
                    Report.SetParameterValue("txtSCmDiscount", FormatNumber(0 - rs.Fields("amount").Value, 2))
                    oldDis = CDec(FormatNumber(0 - rs.Fields("amount").Value, 2))
                Else
                    Report.SetParameterValue("txtStockDiscount", "0.00")
                    oldDis = 0
                End If
            End If
            rs.Close()

            'Set rs = getRSreport("SELECT Sum(Sale.Sale_Discount) AS amount FROM aConsignment RIGHT JOIN (aConsignment AS aConsignment_1 RIGHT JOIN Sale ON aConsignment_1.Consignment_SaleID = Sale.SaleID) ON aConsignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null) AND ((Sale.Sale_DisChk) = False) And ((Sale.Sale_SaleChk)=False));")
            rs = getRSreport("SELECT Sum(Sale.Sale_Discount) AS amount FROM aConsignment RIGHT JOIN (aConsignment AS aConsignment_1 RIGHT JOIN Sale ON aConsignment_1.Consignment_SaleID = Sale.SaleID) ON aConsignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null) AND ((Sale.Sale_DisChk) = False));")
            If IsDbNull(rs.Fields("amount").Value) Then
                Report.SetParameterValue("txtStockDiscount", "0.00")
                oldDis = 0
            Else
                If rs.RecordCount Then
                    Report.SetParameterValue("txtStockDiscount", FormatNumber(0 - rs.Fields("amount").Value, 2))
                    'Report.txtSCmDiscount.SetText FormatNumber(0 - rs("amount"), 2)
                    oldDis = CDec(FormatNumber(0 - rs.Fields("amount").Value, 2))
                Else
                    Report.SetParameterValue("txtStockDiscount", "0.00")
                    oldDis = 0
                End If
            End If
            rs.Close()
            '------------- Discounts with New Chk

            'Set rs = getRSreport("SELECT Sum(Sale.Sale_Discount) AS amount FROM aConsignment RIGHT JOIN (aConsignment AS aConsignment_1 RIGHT JOIN Sale ON aConsignment_1.Consignment_SaleID = Sale.SaleID) ON aConsignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null) AND ((Sale.Sale_DisChk) = True) And ((Sale.Sale_SaleChk)=False));")
            rs = getRSreport("SELECT Sum(Sale.Sale_Discount) AS amount FROM aConsignment RIGHT JOIN (aConsignment AS aConsignment_1 RIGHT JOIN Sale ON aConsignment_1.Consignment_SaleID = Sale.SaleID) ON aConsignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null) AND ((Sale.Sale_DisChk) = True));")
            If IsDbNull(rs.Fields("amount").Value) Then
                Report.SetParameterValue("txtStockDiscount", "0.00")
            Else
                If rs.RecordCount Then
                    Report.SetParameterValue("txtStockDiscount", FormatNumber(0 - rs("amount").Value, 2))
                    newDis = CDec(FormatNumber(0 - rs.Fields("amount").Value, 2))
                    Report.SetParameterValue("txtSCmDiscount", FormatNumber(0 - rs("amount").Value, 2))
                Else
                    Report.SetParameterValue("txtStockDiscount", "0.00")
                End If
            End If
            rs.Close()


            '-------------Grutity
            'Set rs = getRSreport("SELECT Sum(Sale.Sale_Gratuity) AS amountGr FROM aConsignment RIGHT JOIN (aConsignment AS aConsignment_1 RIGHT JOIN Sale ON aConsignment_1.Consignment_SaleID = Sale.SaleID) ON aConsignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null) And ((Sale.Sale_SaleChk)=False));")
            rs = getRSreport("SELECT Sum(Sale.Sale_Gratuity) AS amountGr FROM aConsignment RIGHT JOIN (aConsignment AS aConsignment_1 RIGHT JOIN Sale ON aConsignment_1.Consignment_SaleID = Sale.SaleID) ON aConsignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null));")
            If IsDbNull(rs.Fields("amountGr").Value) Then
                Report.SetParameterValue("txtStockGratuity", "0.00")
                Report.SetParameterValue("txtStockGratuity", " ")
                Report.SetParameterValue("Text94", " ")
            Else
                If rs.RecordCount Then
                    Report.SetParameterValue("txtStockGratuity", FormatNumber(0 - rs.Fields("amountGr").Value, 2))
                    'Report.txtSCmDiscount.SetText FormatNumber(0 - rs("amount"), 2)
                Else
                    Report.SetParameterValue("txtStockGratuity", "0.00")
                    Report.SetParameterValue("txtStockGratuity", " ")
                    Report.SetParameterValue("Text94", " ")
                End If
            End If
            rs.Close()
            rs = getRSreport("SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS content, CBool([SaleItem_DepositType]) AS depositType, SaleItem.SaleItem_Reversal, Sum(([SaleItem_DepositCost]*[SaleItem_Quantity])*(1+[SaleItem_Vat]/100)) AS deposit FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY CBool([SaleItem_DepositType]), SaleItem.SaleItem_Reversal;")
            Do Until rs.EOF
                If rs.Fields("depositType").Value Then
                    If rs.Fields("SaleItem_Reversal").Value Then
                        Report.SetParameterValue("txtStockDepositSold", FormatNumber(rs.Fields("content").Value, 2))
                    Else
                        Report.SetParameterValue("txtStockDepositReturn", FormatNumber(rs.Fields("content").Value, 2))
                    End If
                Else
                    If rs.Fields("SaleItem_Reversal").Value Then
                        Report.SetParameterValue("txtStockCreditContent", FormatNumber(rs.Fields("content").Value, 2))
                        Report.SetParameterValue("txtStockCreditDeposit", FormatNumber(0 - rs.Fields("deposit").Value, 2))
                    Else
                        Report.SetParameterValue("txtStockSoldContent", FormatNumber(rs.Fields("content").Value, 2))
                        Report.SetParameterValue("txtStockSoldDeposit", FormatNumber(rs.Fields("deposit").Value, 2))
                    End If
                End If
                rs.moveNext()
            Loop
            rs.Close()

            Report.SetParameterValue("txtStockDepositReturn1", Report.ParameterFields("txtStockDepositReturn").ToString)
            Report.SetParameterValue("txtStockDepositSold1", Report.ParameterFields("txtStockDepositSold").ToString)
            Report.SetParameterValue("txtTotalDepositMove", FormatNumber(CDec(Report.ParameterFields("txtStockDepositReturn1").ToString) + CDec(Report.ParameterFields("txtStockDepositSold1").ToString), 2))

            On Error Resume Next
            Report.SetParameterValue("txtStockSoldContent", FormatNumber(CDec(Report.ParameterFields("txtStockSoldContent").ToString) - CDec(Report.ParameterFields("txtStockSoldDeposit").ToString), 2))
            Report.SetParameterValue("txtStockCreditContent", FormatNumber(CDec(Report.ParameterFields("txtStockCreditContent").ToString) - CDec(Report.ParameterFields("txtStockCreditDeposit").ToString), 2))
            Report.SetParameterValue("txtStockSold", FormatNumber(CDec(Report.ParameterFields("txtStockSoldContent").ToString) + CDec(Report.ParameterFields("txtStockSoldDeposit").ToString), 2))
            Report.SetParameterValue("txtStockCreditTotal", FormatNumber(CDec(Report.ParameterFields("txtStockCreditContent").ToString) + CDec(Report.ParameterFields("txtStockCreditDeposit").ToString), 2))
            Report.SetParameterValue("txtStockSold1", FormatNumber(CDec(Report.ParameterFields("txtStockSold").ToString) + (oldDis), 2))
            Report.SetParameterValue("txtStockCreditTotal1", Report.ParameterFields("txtStockCreditTotal").ToString)
            Report.SetParameterValue("txtTotalStockMove", FormatNumber(CDec(Report.ParameterFields("txtStockSold1").ToString) + CDec(Report.ParameterFields("txtStockCreditTotal1").ToString), 2))
            Report.SetParameterValue("txtMoneyTill", FormatNumber(CDec(Report.ParameterFields("txtMoneyTotal").ToString) + CDec(Report.ParameterFields("txtOutage").ToString) - CDec(Report.ParameterFields("txtPayout").ToString), 2))
            Report.SetParameterValue("txtCubeDirect", FormatNumber(CDec(Report.ParameterFields("txtCubeMoney").ToString) + CDec(Report.ParameterFields("txtCubeAccountPayment").ToString), 2))
            Report.SetParameterValue("txtCubeStock", FormatNumber(CDec(Report.ParameterFields("txtCubeDirect").ToString) + CDec(Report.ParameterFields("txtCubeAccountSales").ToString), 2))
            lTotal = CDec(Report.ParameterFields("txtStockCreditTotal").ToString) + CDec(Report.ParameterFields("txtStockDepositReturn").ToString) + CDec(Report.ParameterFields("txtStockDepositSold").ToString) + CDec(Report.ParameterFields("txtStockSold").ToString) + CDec(Report.ParameterFields("txtStockDiscount").ToString) + CDec(System.Math.Abs(IIf(Report.ParameterFields("txtStockGratuity").ToString = " ", "0", Report.ParameterFields("txtStockGratuity").ToString)))
            'lTotal = CCur(Report.txtStockCreditTotal.Text) + CCur(Report.txtStockDepositReturn.Text) + CCur(Report.txtStockDepositSold.Text) + CCur(Report.txtStockSold.Text) + CCur(Report.txtStockDiscount.Text) + newDis '+ CCur(Abs(IIf(Report.txtStockGratuity.Text = " ", "0", Report.txtStockGratuity.Text)))
            Report.SetParameterValue("txtStockTotal", FormatNumber(lTotal, 2))
            '------------- Discounts with New Chk
            Report.SetParameterValue("txtStockDiscount", FormatNumber(newDis + CDec(Report.ParameterFields("txtStockDiscount").ToString), 2))


            ' to change StockTotal, MoneyTotal, CubeStock, CubeMoney, CubeDirect
            Report.SetParameterValue("txtStockTotal", FormatNumber(CDec(Report.ParameterFields("txtStockTotal").ToString) - (CDec(System.Math.Abs(IIf(Report.ParameterFields("txtStockGratuity").ToString = " ", "0", Report.ParameterFields("txtStockGratuity").ToString)))), 2))
            Report.SetParameterValue("txtMoneyTotal", FormatNumber(CDec(Report.ParameterFields("txtMoneyTotal").ToString) - (CDec(System.Math.Abs(IIf(Report.ParameterFields("txtStockGratuity").ToString = " ", "0", Report.ParameterFields("txtStockGratuity").ToString)))), 2))
            Report.SetParameterValue("txtCubeStock", FormatNumber((CDec(Report.ParameterFields("txtCubeStock").ToString)) - (CDec(System.Math.Abs(IIf(Report.ParameterFields("txtStockGratuity").ToString = " ", "0", Report.ParameterFields("txtStockGratuity").ToString)))), 2)) '+ OnlyAcclSettDiscount
            Report.SetParameterValue("txtCubeMoney", FormatNumber(CDec(Report.ParameterFields("txtCubeMoney").ToString) - (CDec(System.Math.Abs(IIf(Report.ParameterFields("txtStockGratuity").ToString = " ", "0", Report.ParameterFields("txtStockGratuity").ToString)))), 2))
            Report.SetParameterValue("txtCubeDirect", FormatNumber(CDec(Report.ParameterFields("txtCubeDirect").ToString) - (CDec(System.Math.Abs(IIf(Report.ParameterFields("txtStockGratuity").ToString = " ", "0", Report.ParameterFields("txtStockGratuity").ToString)))), 2))

            'Old Account Journal Movement
            rs = getRSreport("SELECT Sum(aCustomerTransaction.CustomerTransaction_Amount) AS SumOfCustomerTransaction_Amount FROM aCustomerTransaction INNER JOIN DayEnd ON aCustomerTransaction.CustomerTransaction_DayEndID = DayEnd.DayEndID WHERE (((aCustomerTransaction.CustomerTransaction_TransactionTypeID)=3 Or (aCustomerTransaction.CustomerTransaction_TransactionTypeID)=4 Or (aCustomerTransaction.CustomerTransaction_TransactionTypeID)=5) AND ((aCustomerTransaction.CustomerTransaction_ReferenceID)=0));")
            'Set rs = getRSreport("SELECT Sum(aCustomerTransaction.CustomerTransaction_Amount) AS SumOfCustomerTransaction_Amount FROM aCustomerTransaction INNER JOIN DayEnd ON aCustomerTransaction.CustomerTransaction_DayEndID = DayEnd.DayEndID WHERE (((aCustomerTransaction.CustomerTransaction_TransactionTypeID)=3 Or (aCustomerTransaction.CustomerTransaction_TransactionTypeID)=4 Or (aCustomerTransaction.CustomerTransaction_TransactionTypeID)=5 Or (aCustomerTransaction.CustomerTransaction_TransactionTypeID)=8) AND ((aCustomerTransaction.CustomerTransaction_ReferenceID)=0));")
            If rs.RecordCount Then
                Report.SetParameterValue("txtAccountEFT", FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2))
            Else
                Report.SetParameterValue("txtAccountEFT", FormatNumber(0, 2))
            End If

            '**************************
            '*** Profit Summary ***
            '**************************
            '        Set rs = getRSreport("SELECT Sum(([SaleItem_ActualCost]*[SaleItem_Quantity])) AS actualExcl, Sum(([SaleItem_ActualCost]*[SaleItem_Quantity])*(1+[SaleItem_Vat]/100)) AS actualIncl, Sum(([SaleItem_ListCost]*[SaleItem_Quantity])) AS listExcl, Sum(([SaleItem_ListCost]*[SaleItem_Quantity])*(1+[SaleItem_Vat]/100)) AS listIncl, Sum([SaleItem_Price]*[SaleItem_Quantity]/(1+[SaleItem_Vat]/100)) AS priceExcl, Sum([SaleItem_Price]*[SaleItem_Quantity]) AS priceIncl, Sum(([SaleItem_DepositCost]*[SaleItem_Quantity])) AS depositExcl, Sum(([SaleItem_DepositCost]*[SaleItem_Quantity])*(1+[SaleItem_Vat]/100)) AS depositIncl FROM aConsignment AS aConsignment_1 RIGHT JOIN (SaleItem LEFT JOIN aConsignment ON SaleItem.SaleItem_SaleID = aConsignment.Consignment_SaleID) ON aConsignment_1.Consignment_ReversalSaleID = SaleItem.SaleItem_SaleID WHERE (((SaleItem.SaleItem_DepositType)=0) AND ((SaleItem.SaleItem_Revoke)=False) AND ((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null));")


            sql = "SELECT Sum(IIf([SaleItem_Reversal],0-[SaleItem_ActualCost]*[SaleItem_Quantity],[SaleItem_ActualCost]*[SaleItem_Quantity])) AS actualExcl, Sum(((IIf([SaleItem_Reversal],0-[SaleItem_ActualCost]*[SaleItem_Quantity],[SaleItem_ActualCost]*[SaleItem_Quantity]))*(1+[SaleItem_Vat]/100))) AS actualIncl, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ListCost]*[SaleItem_Quantity],[SaleItem_ListCost]*[SaleItem_Quantity])) AS listExcl, Sum(((IIf([SaleItem_Reversal],0-[SaleItem_ListCost]*[SaleItem_Quantity],[SaleItem_ListCost]*[SaleItem_Quantity]))*(1+[SaleItem_Vat]/100))) AS listIncl, Sum(([SaleItem_Price]*[SaleItem_Quantity]/(1+[SaleItem_Vat]/100))) AS priceExcl, Sum(([SaleItem_Price]*[SaleItem_Quantity])) AS priceIncl, Sum(IIf([SaleItem_Reversal],0-[SaleItem_DepositCost]*[SaleItem_Quantity],[SaleItem_DepositCost]*[SaleItem_Quantity])) AS depositExcl, Sum((IIf([SaleItem_Reversal],0-[SaleItem_DepositCost]*[SaleItem_Quantity],[SaleItem_DepositCost]*[SaleItem_Quantity]))*(1+[SaleItem_Vat]/100)) AS depositIncl "
            sql = sql & "FROM aConsignment AS aConsignment_1 RIGHT JOIN (SaleItem LEFT JOIN aConsignment ON SaleItem.SaleItem_SaleID = aConsignment.Consignment_SaleID) ON aConsignment_1.Consignment_ReversalSaleID = SaleItem.SaleItem_SaleID "
            sql = sql & "WHERE (((SaleItem.SaleItem_DepositType)=0) AND ((SaleItem.SaleItem_Revoke)=False) AND ((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null));"

            rs = getRSreport(sql)
            Report.SetParameterValue("txtLEcost", FormatNumber(rs.Fields("listExcl").Value, 0))
            Report.SetParameterValue("txtAEcost", FormatNumber(rs.Fields("actualExcl").Value, 0))
            Report.SetParameterValue("txtLIcost", FormatNumber(rs.Fields("listIncl").Value, 0))
            Report.SetParameterValue("txtAIcost", FormatNumber(rs.Fields("actualIncl").Value, 0))
            If Report.ParameterFields("txtLEcost").ToString = "" Then Report.SetParameterValue("txtLEcost", "0")
            If Report.ParameterFields("txtLIcost").ToString = "" Then Report.SetParameterValue("txtLIcost", "0")
            If Report.ParameterFields("txtAEcost").ToString = "" Then Report.SetParameterValue("txtAEcost", "0")
            If Report.ParameterFields("txtAIcost").ToString = "" Then Report.SetParameterValue("txtAIcost", "0")

            Report.SetParameterValue("txtLEdeposit", FormatNumber(rs.Fields("depositExcl").Value, 0))
            Report.SetParameterValue("txtLIdeposit", FormatNumber(rs.Fields("depositIncl").Value, 0))
            Report.SetParameterValue("txtAEdeposit", FormatNumber(rs.Fields("depositExcl").Value, 0))
            Report.SetParameterValue("txtAIdeposit", FormatNumber(rs.Fields("depositIncl").Value, 0))
            If Report.ParameterFields("txtLEdeposit").ToString = "" Then Report.SetParameterValue("txtLEdeposit", "0")
            If Report.ParameterFields("txtLIdeposit").ToString = "" Then Report.SetParameterValue("txtLIdeposit", "0")
            If Report.ParameterFields("txtAEdeposit").ToString = "" Then Report.SetParameterValue("txtAEdeposit", "0")
            If Report.ParameterFields("txtAIdeposit").ToString = "" Then Report.SetParameterValue("txtAIdeposit", "0")

            Report.SetParameterValue("txtLEcontent", FormatNumber(rs.Fields("priceExcl").Value - rs.Fields("depositExcl").Value + (oldDis), 0))
            Report.SetParameterValue("txtLIcontent", FormatNumber(rs.Fields("priceIncl").Value - rs.Fields("depositIncl").Value + (oldDis), 0))
            Report.SetParameterValue("txtAEcontent", FormatNumber(rs.Fields("priceExcl").Value - rs.Fields("depositExcl").Value + (oldDis), 0))
            Report.SetParameterValue("txtAIcontent", FormatNumber(rs.Fields("priceIncl").Value - rs.Fields("depositIncl").Value + (oldDis), 0))
            If Report.ParameterFields("txtLEcontent").ToString = "" Then Report.SetParameterValue("txtLEcontent", "0")
            If Report.ParameterFields("txtLIcontent").ToString = "" Then Report.SetParameterValue("txtLIcontent", "0")
            If Report.ParameterFields("txtAEcontent").ToString = "" Then Report.SetParameterValue("txtAEcontent", "0")
            If Report.ParameterFields("txtAIcontent").ToString = "" Then Report.SetParameterValue("txtAIcontent", "0")

            Report.SetParameterValue("txtLEProfit", FormatNumber((rs.Fields("priceExcl").Value - rs.Fields("depositExcl").Value) - (rs.Fields("listExcl")).Value, 0))
            Report.SetParameterValue("txtLIProfit", FormatNumber((rs.Fields("priceIncl").Value - rs.Fields("depositIncl").Value) - (rs.Fields("listIncl")).Value, 0))
            Report.SetParameterValue("txtAEProfit", FormatNumber((rs.Fields("priceExcl").Value - rs.Fields("depositExcl").Value) - (rs.Fields("actualExcl")).Value, 0))
            Report.SetParameterValue("txtAIProfit", FormatNumber((rs.Fields("priceIncl").Value - rs.Fields("depositIncl").Value) - (rs.Fields("actualIncl")).Value, 0))
            If CDec(Report.ParameterFields("txtLEcost").ToString) = 0 Then
                If Report.ParameterFields("txtLEProfit").ToString = "" Then Report.SetParameterValue("txtLEProfit", "0")
                If Report.ParameterFields("txtLIProfit").ToString = "" Then Report.SetParameterValue("txtLIProfit", "0")
                If Report.ParameterFields("txtAEProfit").ToString = "" Then Report.SetParameterValue("txtAEProfit", "0")
                If Report.ParameterFields("txtAIProfit").ToString = "" Then Report.SetParameterValue("txtAIProfit", "0")
            Else
                Report.SetParameterValue("txtLEPerc", FormatNumber(CDec(Report.ParameterFields("txtLEProfit").ToString) / CDec(Report.ParameterFields("txtLEcost").ToString) * 100, 2) & "%")
                Report.SetParameterValue("txtLIPerc", FormatNumber(CDec(Report.ParameterFields("txtLIProfit").ToString) / CDec(Report.ParameterFields("txtLIcost").ToString) * 100, 2) & "%")
                Report.SetParameterValue("txtAEPerc", FormatNumber(CDec(Report.ParameterFields("txtAEProfit").ToString) / CDec(Report.ParameterFields("txtAEcost").ToString) * 100, 2) & "%")
                Report.SetParameterValue("txtAIPerc", FormatNumber(CDec(Report.ParameterFields("txtAIProfit").ToString) / CDec(Report.ParameterFields("txtAIcost").ToString) * 100, 2) & "%")
            End If
            Report.SetParameterValue("txtLEtotalProfit", FormatNumber(rs.Fields("priceExcl").Value - rs.Fields("listExcl").Value - rs.Fields("depositExcl").Value + (oldDis), 0))
            Report.SetParameterValue("txtLItotalProfit", FormatNumber(rs.Fields("priceIncl").Value - rs.Fields("listIncl").Value - rs.Fields("depositIncl").Value + (oldDis), 0))

            Report.SetParameterValue("txtAEtotalProfit", FormatNumber(rs.Fields("priceExcl").Value - rs.Fields("actualExcl").Value - rs.Fields("depositExcl").Value + (oldDis), 0))
            Report.SetParameterValue("txtAItotalProfit", FormatNumber(rs.Fields("priceIncl").Value - rs.Fields("actualIncl").Value - rs.Fields("depositIncl").Value + (oldDis), 0))
            If Report.ParameterFields("txtLEtotalProfit").ToString = "" Then Report.SetParameterValue("txtLEtotalProfit", "0")
            If Report.ParameterFields("txtLItotalProfit").ToString = "" Then Report.SetParameterValue("txtLItotalProfit", "0")
            If Report.ParameterFields("txtAEtotalProfit").ToString = "" Then Report.SetParameterValue("txtAEtotalProfit", "0")
            If Report.ParameterFields("txtAItotalProfit").ToString = "" Then Report.SetParameterValue("txtAItotalProfit", "0")

            Report.SetParameterValue("txtLEtotal", FormatNumber(rs.Fields("priceExcl").Value + (oldDis), 0))
            Report.SetParameterValue("txtLItotal", FormatNumber(rs.Fields("priceIncl").Value + (oldDis), 0))
            Report.SetParameterValue("txtAEtotal", FormatNumber(rs.Fields("priceExcl").Value + (oldDis), 0))
            Report.SetParameterValue("txtAItotal", FormatNumber(rs.Fields("priceIncl").Value + (oldDis), 0))
            If Report.ParameterFields("txtLEtotal").ToString = "" Then Report.SetParameterValue("txtLEtotal", "0")
            If Report.ParameterFields("txtLItotal").ToString = "" Then Report.SetParameterValue("txtLItotal", "0")
            If Report.ParameterFields("txtAEtotal").ToString = "" Then Report.SetParameterValue("txtAEtotal", "0")
            If Report.ParameterFields("txtAItotal").ToString = "" Then Report.SetParameterValue("txtAItotal", "0")

            If CDec(Report.ParameterFields("txtLEcost").ToString) = 0 Then
            Else
                Report.SetParameterValue("txtLEtotalPerc", FormatNumber((1 - ((rs.Fields("listExcl").Value + oldDis) + rs.Fields("depositExcl").Value) / rs.Fields("priceExcl").Value) * 100, 2) & "%")
                Report.SetParameterValue("txtLItotalPerc", FormatNumber((1 - ((rs.Fields("listIncl").Value + oldDis) + rs.Fields("depositIncl").Value) / rs.Fields("priceIncl").Value) * 100, 2) & "%")
                Report.SetParameterValue("txtAEtotalPerc", FormatNumber((1 - ((rs.Fields("actualExcl").Value + oldDis) + rs.Fields("depositExcl").Value) / rs.Fields("priceExcl").Value) * 100, 2) & "%")
                Report.SetParameterValue("txtAItotalPerc", FormatNumber((1 - ((rs.Fields("actualIncl").Value + oldDis) + rs.Fields("depositIncl").Value) / rs.Fields("priceIncl").Value) * 100, 2) & "%")
            End If

            '***Stock Holding
            If lMode Then
            Else
                rs = getRSreport("SELECT Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost]) AS listSales, Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ActualCost]) AS actualSales, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS listShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actualShrink, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost]) AS listGRV, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ActualCost]) AS actualGRV FROM DayEndStockItemLnk;")
                If IsDbNull(rs.Fields("listShrink").Value) Then
                    Report.SetParameterValue("txtSHRL", FormatNumber(0, 2))
                Else
                    Report.SetParameterValue("txtSHRL", FormatNumber(rs.Fields("listShrink").Value, 2))
                End If
                If IsDbNull(rs.Fields("listGRV").Value) Then
                    Report.SetParameterValue("txtGRVL", FormatNumber(0, 2))
                Else
                    Report.SetParameterValue("txtGRVL", FormatNumber(rs.Fields("listGRV").Value, 2))
                End If
                If IsDbNull(rs.Fields("listSales").Value) Then
                    Report.SetParameterValue("txtSaleL", FormatNumber(0, 2))
                Else
                    Report.SetParameterValue("txtSaleL", FormatNumber(rs.Fields("listSales").Value, 2))
                End If

                'Report.txtSHRA.SetText FormatNumber(rs("actualShrink"), 2)
                'Report.txtGRVA.SetText FormatNumber(rs("actualGRV"), 2)
                'Report.txtSaleA.SetText FormatNumber(rs("actualSales"), 2)

                rs = getRSreport("SELECT Sum(([DayEndStockItemLnk]![DayEndStockItemLnk_ListCost]-[DayEndStockItemLnkfrom]![DayEndStockItemLnk_ListCost])*[DayEndStockItemLnk]![DayEndStockItemLnk_Quantity]) AS totalProfitList, Sum(([DayEndStockItemLnk]![DayEndStockItemLnk_ActualCost]-[DayEndStockItemLnkfrom]![DayEndStockItemLnk_ActualCost])*[DayEndStockItemLnk]![DayEndStockItemLnk_Quantity]) AS totalProfitActual FROM [SELECT DayEndStockItemLnkFirst.* From DayEndStockItemLnkFirst Union SELECT DayEndStockItemLnk.* From DayEndStockItemLnk ]. AS dayendStockItemLnkFrom INNER JOIN DayEndStockItemLnk ON dayendStockItemLnkFrom.DayEndStockItemLnk_StockItemID = DayEndStockItemLnk.DayEndStockItemLnk_StockItemID WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_DayEndID)=[DayEndStockItemLnkfrom]![DayEndStockItemLnk_DayEndID]+1));")
                If IsDbNull(rs.Fields("totalProfitList").Value) Then
                    Report.SetParameterValue("TxtSVarianceL", FormatNumber(0, 2))
                Else
                    Report.SetParameterValue("txtSVarianceL", FormatNumber(rs.Fields("totalProfitList").Value, 2))
                End If
                Report.SetParameterValue("txtSVarianceA", FormatNumber(0, 2))

                rs = getRSreport("SELECT Sum(([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_ListCost]) AS list, Sum(([DayEndStockItemLnk_Quantity]-[DayEndStockItemLnk_QuantitySales]-[DayEndStockItemLnk_QuantityShrink]+[DayEndStockItemLnk_QuantityGRV])*[DayEndStockItemLnk_actualCost]) AS actual FROM Report INNER JOIN DayEndStockItemLnk ON Report.Report_DayEndEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID;")
                Report.SetParameterValue("txtSHLclose", FormatNumber(rs.Fields("list").Value, 2))
                '        Report.txtSHAclose.SetText FormatNumber(rs("actual"), 2)

                rs = getRSreport("SELECT Sum(IIf([DayEndDeposittemLnk_DepositType]=0,[DayEndDepositItemLnk_UnitCost]*([DayEndDepositItemLnk_Quantity]-DayEndDepositItemLnk_QuantitySales-DayEndDepositItemLnk_QuantityShrink+DayEndDepositItemLnk_QuantityGRV),[DayEndDepositItemLnk_CaseCost]*([DayEndDepositItemLnk_Quantity]-DayEndDepositItemLnk_QuantitySales-DayEndDepositItemLnk_QuantityShrink+DayEndDepositItemLnk_QuantityGRV))) AS actual FROM Report INNER JOIN DayEndDepositItemLnk ON Report.Report_DayEndEndID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID;")
                Report.SetParameterValue("txtSHAclose", FormatNumber(rs.Fields("actual").Value, 2))

                rs = getRSreport("SELECT Sum([DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk_ListCost]) AS list, Sum([DayEndStockItemLnk_Quantity]*[DayEndStockItemLnk_actualCost]) AS actual FROM Report INNER JOIN DayEndStockItemLnk ON Report.Report_DayEndStartID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID;")
                If rs.RecordCount Then
                    Report.SetParameterValue("txtSHLopen", FormatNumber(rs.Fields("list").Value, 2))
                    Report.SetParameterValue("txtSHAopen", FormatNumber(rs.Fields("actual").Value, 2))
                Else
                    Report.SetParameterValue("txtSHLopen", FormatNumber(0, 2))
                    Report.SetParameterValue("txtSHAopen", FormatNumber(0, 2))
                End If

                rs = getRSreport("SELECT Sum((IIf([DayEndDeposittemLnk_DepositType]=0,[DayEndDepositItemLnk_UnitCost],[DayEndDepositItemLnk_CaseCost])*([DayEndDepositItemLnk_Quantity]))) AS Quantity FROM Report INNER JOIN DayEndDepositItemLnk ON Report.Report_DayEndStartID = DayEndDepositItemLnk.DayEndDepositItemLnk_DayEndID;")
                If rs.RecordCount Then
                    Report.SetParameterValue("txtSHAopen", FormatNumber(rs.Fields("quantity").Value, 2))
                Else
                    Report.SetParameterValue("txtSHAopen", FormatNumber(0, 2))
                End If

                'Set rs = getRSreport("SELECT Sum(IIf([DayEndDeposittemLnk_DepositType]=0,[DayEndDepositItemLnk_UnitCost],[DayEndDepositItemLnk_CaseCost])*[DayEndDepositItemLnk_QuantitySales]) AS Sales, Sum(IIf([DayEndDeposittemLnk_DepositType]=0,[DayEndDepositItemLnk_UnitCost],[DayEndDepositItemLnk_CaseCost])*[DayEndDepositItemLnk_QuantityShrink]) AS Shrink, Sum(IIf([DayEndDeposittemLnk_DepositType]=0,[DayEndDepositItemLnk_UnitCost],[DayEndDepositItemLnk_CaseCost])*[DayEndDepositItemLnk_QuantityGRV]) AS GRV From Report, DayEndDepositItemLnk")
                rs = getRSreport("SELECT Sum(IIf([DayEndDeposittemLnk_DepositType]=0,[DayEndDepositItemLnk_UnitCost],[DayEndDepositItemLnk_CaseCost])*[DayEndDepositItemLnk_QuantitySales]) AS Sales, Sum(IIf([DayEndDeposittemLnk_DepositType]=0,[DayEndDepositItemLnk_UnitCost],[DayEndDepositItemLnk_CaseCost])*[DayEndDepositItemLnk_QuantityShrink]) AS Shrink, Sum(IIf([DayEndDeposittemLnk_DepositType]=0,[DayEndDepositItemLnk_UnitCost],[DayEndDepositItemLnk_CaseCost])*[DayEndDepositItemLnk_QuantityGRV]) AS GRV From DayEndDepositItemLnk")
                Report.SetParameterValue("txtSHRA", FormatNumber(0 - rs.Fields("Shrink").Value, 2))
                Report.SetParameterValue("txtGRVA", FormatNumber(rs.Fields("GRV").Value, 2))
                Report.SetParameterValue("txtSaleA", FormatNumber(0 - rs.Fields("Sales").Value, 2))
                Report.SetParameterValue("txtSVarianceA", FormatNumber(0, 2))
                Report.SetParameterValue("txtSVarianceT", FormatNumber(CDec(Report.ParameterFields("txtSVarianceA").ToString) + CDec(Report.ParameterFields("txtSVarianceA").ToString), 2))
                Report.SetParameterValue("txtSaleT", FormatNumber(CDec(Report.ParameterFields("txtSaleA").ToString) + CDec(Report.ParameterFields("txtSaleL").ToString), 2))
                Report.SetParameterValue("txtGRVT", FormatNumber(CDec(Report.ParameterFields("txtGRVA").ToString) + CDec(Report.ParameterFields("txtGRVL").ToString), 2))
                Report.SetParameterValue("txtSHRT", FormatNumber(CDec(Report.ParameterFields("txtSHRA").ToString) + CDec(Report.ParameterFields("txtSHRL").ToString), 2))
                Report.SetParameterValue("txtSHTopen", FormatNumber(CDec(Report.ParameterFields("txtSHAopen").ToString) + CDec(Report.ParameterFields("txtSHLopen").ToString), 2))
                Report.SetParameterValue("txtSHTclose", FormatNumber(CDec(Report.ParameterFields("txtSHAclose").ToString) + CDec(Report.ParameterFields("txtSHLclose").ToString), 2))
            End If
            rs = getRSreport("SELECT Sum([SaleItem_ListCost]*[SaleItem_Quantity]) AS list, Sum([SaleItem_ActualCost]*[SaleItem_Quantity]) AS actual FROM aConsignment INNER JOIN SaleItem ON aConsignment.Consignment_SaleID = SaleItem.SaleItem_SaleID;")
            If IsDbNull(rs.Fields("list").Value) Then
                Report.SetParameterValue("txtConsLsales", FormatNumber("0", 2))
                Report.SetParameterValue("txtConsAsales", FormatNumber("0", 2))
            Else
                Report.SetParameterValue("txtConsLsales", FormatNumber(rs.Fields("list").Value, 2))
                Report.SetParameterValue("txtConsAsales", FormatNumber(rs.Fields("actual").Value, 2))
            End If
            rs = getRSreport("SELECT Sum(Sale.Sale_Total) AS [amount] FROM aConsignment INNER JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID;")
            If IsDbNull(rs.Fields("amount").Value) Then
                Report.SetParameterValue("txtConsPsales", FormatNumber("0", 2))
            Else
                Report.SetParameterValue("txtConsPsales", FormatNumber(rs.Fields("amount").Value, 2))
            End If

            rs = getRSreport("SELECT Sum([SaleItem_ListCost]*[SaleItem_Quantity]) AS list, Sum([SaleItem_ActualCost]*[SaleItem_Quantity]) AS actual FROM aConsignment INNER JOIN SaleItem ON aConsignment.Consignment_CompleteSaleID = SaleItem.SaleItem_SaleID;")
            If IsDbNull(rs.Fields("list").Value) Then
                Report.SetParameterValue("txtConsLPurchase", FormatNumber("0", 2))
                Report.SetParameterValue("txtConsAPurchase", FormatNumber("0", 2))
            Else
                Report.SetParameterValue("txtConsLPurchase", FormatNumber(rs.Fields("list").Value, 2))
                Report.SetParameterValue("txtConsAPurchase", FormatNumber(rs.Fields("actual").Value, 2))
            End If

            rs = getRSreport("SELECT Sum(theJoin.list) AS list, Sum(theJoin.actual) AS actual FROM (SELECT  1 AS sale, Sum([SaleItem_Quantity]*[SaleItem_ListCost]) AS list, Sum([SaleItem_Quantity]*[SaleItem_actualCost]) AS actual FROM SaleItem INNER JOIN aConsignment ON SaleItem.SaleItem_SaleID = aConsignment.Consignment_CompleteSaleID Union SELECT 0 AS sale, Sum(0-[SaleItem_Quantity]*[SaleItem_ListCost]) AS list, Sum(0-[SaleItem_Quantity]*[SaleItem_actualCost]) AS actual FROM aConsignment INNER JOIN SaleItem ON aConsignment.Consignment_SaleID = SaleItem.SaleItem_SaleID WHERE (((aConsignment.Consignment_CompleteSaleID) Is Not Null))) AS theJoin;")
            If IsDbNull(rs.Fields("list").Value) Then
                Report.SetParameterValue("txtConsLreturn", FormatNumber("0", 2))
                Report.SetParameterValue("txtConsAreturn", FormatNumber("0", 2))
            Else
                Report.SetParameterValue("txtConsLreturn", FormatNumber(rs.Fields("list").Value, 2))
                Report.SetParameterValue("txtConsAreturn", FormatNumber(rs.Fields("actual").Value, 2))
            End If

            rs = getRSreport("SELECT Sum([Sale]![Sale_Total]+[Sale_1]![Sale_Total]) AS priceReturn, Sale.Sale_Total FROM Sale INNER JOIN (Sale AS Sale_1 INNER JOIN aConsignment ON Sale_1.SaleID = aConsignment.Consignment_ReversalSaleID) ON Sale.SaleID = aConsignment.Consignment_CompleteSaleID GROUP BY Sale.Sale_Total;")
            If rs.BOF Or rs.EOF Then
                Report.SetParameterValue("txtConsPPurchase", FormatNumber("0", 2))
                Report.SetParameterValue("txtConsPreturn", FormatNumber("0", 2))
            Else
                If IsDbNull(rs.Fields("Sale_Total").Value) Then
                    Report.SetParameterValue("txtConsPPurchase", FormatNumber("0", 2))
                    Report.SetParameterValue("txtConsPreturn", FormatNumber("0", 2))
                Else
                    Report.SetParameterValue("txtConsPPurchase", FormatNumber(rs.Fields("Sale_Total").Value, 2))
                    Report.SetParameterValue("txtConsPreturn", FormatNumber(rs.Fields("priceReturn").Value, 2))
                End If
            End If
            rs = getRSreport("SELECT * FROM aChannel")
            Do Until rs.EOF

                Select Case rs.Fields("ChannelID").Value
                    Case 1
                        Report.SetParameterValue("txtSC1", rs.Fields("Channel_Code"))
                    Case 2
                        Report.SetParameterValue("txtSC2", rs.Fields("Channel_Code"))
                    Case 3
                        Report.SetParameterValue("txtSC3", rs.Fields("Channel_Code"))
                    Case 4
                        Report.SetParameterValue("txtSC4", rs.Fields("Channel_Code"))
                    Case 5
                        Report.SetParameterValue("txtSC5", rs.Fields("Channel_Code"))
                    Case 6
                        Report.SetParameterValue("txtSC6", rs.Fields("Channel_Code"))
                    Case 7
                        Report.SetParameterValue("txtSC7", rs.Fields("Channel_Code"))
                    Case 8
                        Report.SetParameterValue("txtSC8", rs.Fields("Channel_Code"))
                    Case 9
                        Report.SetParameterValue("txtSC9", rs.Fields("Channel_Code"))
                End Select
                rs.moveNext()
            Loop

            'Set rs = getRSreport("SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS SCTotal, Sale.Sale_ChannelID FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null) And ((Sale.Sale_SaleChk)=False)) GROUP BY Sale.Sale_ChannelID;")
            rs = getRSreport("SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS SCTotal, Sale.Sale_ChannelID FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_ChannelID;")
            'lTotal = CCur(Report.txtSCmDiscount.Text)
            lTotal = oldDis
            Do Until rs.EOF
                Select Case rs.Fields("Sale_ChannelID").Value
                    Case 1
                        Report.SetParameterValue("txtSCm1", FormatNumber(rs.Fields("SCTotal").Value, 2))
                    Case 2
                        Report.SetParameterValue("txtSCm2", FormatNumber(rs.Fields("SCTotal").Value, 2))
                    Case 3
                        Report.SetParameterValue("txtSCm3", FormatNumber(rs.Fields("SCTotal").Value, 2))
                    Case 4
                        Report.SetParameterValue("txtSCm4", FormatNumber(rs.Fields("SCTotal").Value, 2))
                    Case 5
                        Report.SetParameterValue("txtSCm5", FormatNumber(rs.Fields("SCTotal").Value, 2))
                    Case 6
                        Report.SetParameterValue("txtSCm6", FormatNumber(rs.Fields("SCTotal").Value, 2))
                    Case 7
                        Report.SetParameterValue("txtSCm7", FormatNumber(rs.Fields("SCTotal").Value, 2))
                    Case 8
                        Report.SetParameterValue("txtSCm8", FormatNumber(rs.Fields("SCTotal").Value, 2))
                    Case 9
                        Report.SetParameterValue("txtSCm9", FormatNumber(rs.Fields("SCTotal").Value, 2))
                End Select
                lTotal = lTotal + rs.Fields("SCTotal").Value
                rs.moveNext()
            Loop
            Report.SetParameterValue("txtSCmTotal", FormatNumber(lTotal, 2))

            rs = getRSreport("SELECT Sum(aCustomer.Customer_Current) AS SumOfCustomer_Current, Sum(aCustomer.Customer_30Days) AS SumOfCustomer_30Days, Sum(aCustomer.Customer_60Days) AS SumOfCustomer_60Days, Sum(aCustomer.Customer_90Days) AS SumOfCustomer_90Days, Sum(aCustomer.Customer_120Days) AS SumOfCustomer_120Days, Sum(aCustomer.Customer_150Days) AS SumOfCustomer_150Days FROM aCustomer;")
            lTotal = 0
            If rs.RecordCount Then
                Report.SetParameterValue("txtCA1", FormatNumber(rs.Fields("SumOfCustomer_Current").Value, 0))
                Report.SetParameterValue("txtCA2", FormatNumber(rs.Fields("SumOfCustomer_30Days").Value, 0))
                Report.SetParameterValue("txtCA3", FormatNumber(rs.Fields("SumOfCustomer_60Days").Value, 0))
                Report.SetParameterValue("txtCA4", FormatNumber(rs.Fields("SumOfCustomer_90Days").Value, 0))
                Report.SetParameterValue("txtCA5", FormatNumber(rs.Fields("SumOfCustomer_120Days").Value, 0))
                Report.SetParameterValue("txtCA6", FormatNumber(rs.Fields("SumOfCustomer_150Days").Value, 0))
                Report.SetParameterValue("txtCAtotal", FormatNumber(rs.Fields("SumOfCustomer_Current").Value + rs.Fields("SumOfCustomer_30Days").Value + rs.Fields("SumOfCustomer_60Days").Value + rs.Fields("SumOfCustomer_90Days").Value + rs.Fields("SumOfCustomer_120Days").Value + rs.Fields("SumOfCustomer_150Days").Value, 0))
            End If

            frmReportShow.Text = "Sale Dashboard"
            frmReportShow.CRViewer1.ReportSource = Report
            frmReportShow.mReport = Report : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
        End If
    End Sub

    Private Sub report_Salespastel()
        Dim intF As Integer
        Dim rDisplay_F As CrystalDecisions.CrystalReports.Engine.Groups
        Dim vVatSales As Decimal
        Dim sql2 As String
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim lMode As Boolean
        Dim lPasteCurr As Decimal
        Dim vInSales As Decimal
        Dim vExSales As Decimal
        Dim lTotal As Decimal
        Dim rs As ADODB.Recordset
        Dim rsSale As ADODB.Recordset
        Dim rsPTotals As ADODB.Recordset
        Report.Load("cryPastelCube.rpt")

        cnnDB.Execute("UPDATE PastelDescription SET Amount=0,HomeAmount=0,PastelDate=#" & CDate(Today) & "#, Reference = '4POS'")

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim rsPTotalss As ADODB.Recordset
        If openConnectionReport() Then
            rs = getRSreport("SELECT aCompany.Company_Name, Report.Report_Heading FROM aCompany, Report;")
            Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
            Report.SetParameterValue("txtFilter", rs.Fields("Report_Heading"))

            'get payoutTotal
            rs = getRSreport("SELECT Sum(Payout.Payout_Amount) AS [amount] FROM Payout;")
            If IsDbNull(rs.Fields("amount").Value) Then
                Report.SetParameterValue("txtPayout", "0.00")
                Report.SetParameterValue("txtPayout1", "0.00")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & ",HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 18")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & ",HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 19")

            Else
                Report.SetParameterValue("txtPayout", FormatNumber(rs.Fields("amount").Value, 2))
                Report.SetParameterValue("txtPayout1", FormatNumber(rs.Fields("amount").Value, 2))
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 18")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 19")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 18")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 19")
            End If
            rs.Close()
            'get outages
            rs = getRSreport("SELECT Sum(([Declaration_Cash]+[Declaration_Cheque]+[Declaration_Card]-[Declaration_Payout])-([Declaration_CashServer]+[Declaration_ChequeServer]+[Declaration_CardServer]-[Declaration_PayoutServer])) AS amount FROM Declaration;")
            If IsDbNull(rs.Fields("amount").Value) Then
                Report.SetParameterValue("txtOutage", "0.00")
                Report.SetParameterValue("txtOutage1", "0.00")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 5")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 6")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 5")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 6")
            Else
                If rs.Fields("amount").Value < 0 Then
                    Report.SetParameterValue("txtOutage", FormatNumber(-1 * rs.Fields("amount").Value, 2))
                    Report.SetParameterValue("txtOutage1", FormatNumber(-1 * rs.Fields("amount").Value, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 5")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 6")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 5")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 6")
                Else
                    Report.SetParameterValue("txtOutage", FormatNumber(rs.Fields("amount").Value, 2))
                    Report.SetParameterValue("txtOutage1", FormatNumber(rs.Fields("amount").Value, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 5")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 6")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 5")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 6")
                End If
            End If
            rs.Close()
            'get account movement
            lTotal = 0
            rs = getRSreport("SELECT Sum(Sale.Sale_Total) AS amount, Sale.Sale_PaymentType, Sum([Sale_Total]-[Sale_Discount]) AS Subtotal, Sum(Sale.Sale_Discount) AS discount FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (CustomerTransaction INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((CustomerTransaction.CustomerTransaction_TransactionTypeID) = 2 Or (CustomerTransaction.CustomerTransaction_TransactionTypeID) = 3) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_PaymentType;")
            Do Until rs.EOF
                Select Case rs.Fields("Sale_PaymentType").Value
                    Case 5
                        'Report.txtCubeAccountSales.SetText FormatNumber(rs("subtotal"), 2)
                        Report.SetParameterValue("txtAccountSales", FormatNumber(rs.Fields("subtotal").Value, 2))
                        Report.SetParameterValue("txtAccountSales1", FormatNumber(rs.Fields("subtotal").Value, 2))
                        cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("subtotal").Value, 2)) & " WHERE IDDescription = 7")
                        cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rs.Fields("subtotal").Value, 2)) & " WHERE IDDescription = 8")
                        cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("subtotal").Value, 2)) & " WHERE IDDescription = 7")
                        cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rs.Fields("subtotal").Value, 2)) & " WHERE IDDescription")
                    Case 1
                        'Report.txtAccountCash.SetText FormatNumber(0 - rs("amount"), 2)
                        lTotal = lTotal - rs.Fields("amount").Value
                    Case 2
                        'Report.txtAccountCRcard.SetText FormatNumber(0 - rs("amount"), 2)
                        lTotal = lTotal - rs.Fields("amount").Value
                    Case 3
                        'Report.txtAccountDRcard.SetText FormatNumber(0 - rs("amount"), 2)
                        lTotal = lTotal - rs.Fields("amount").Value
                    Case 4
                        'Report.txtAccountCheque.SetText FormatNumber(0 - rs("amount"), 2)
                        lTotal = lTotal - rs.Fields("amount").Value
                End Select
                rs.moveNext()
            Loop

            lTotal = lTotal + CDec(Report.ParameterFields("txtAccountSales").ToString)

            'Get Output Vat
            sql2 = "SELECT SaleItem.SaleItem_StockItemID, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ActualCost]*[SaleItem_Quantity],[SaleItem_ActualCost]*[SaleItem_Quantity])) AS actualCostSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ListCost]*[SaleItem_Quantity],[SaleItem_ListCost]*[SaleItem_Quantity])) AS listCostSum, Sum(([SaleItem_Price]*[SaleItem_Quantity]/(1+[SaleItem_Vat]/100))) AS exclusiveSum, Sum(([SaleItem_Price]*[SaleItem_Quantity])) AS inclusiveSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_DepositCost]*[SaleItem_Quantity],[SaleItem_DepositCost]*[SaleItem_Quantity])) AS depositSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) AS quantitySum FROM Sale INNER JOIN (aConsignment AS aConsignment_1 RIGHT JOIN (SaleItem LEFT JOIN aConsignment ON SaleItem.SaleItem_SaleID=aConsignment.Consignment_SaleID) ON aConsignment_1.Consignment_ReversalSaleID=SaleItem.SaleItem_SaleID) ON Sale.SaleID=SaleItem.SaleItem_SaleID" & " Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null))" & " GROUP BY SaleItem.SaleItem_StockItemID;"
            rsSale = getRSreport(sql2)
            vInSales = 0

            If rsSale.EOF Or rsSale.BOF Then
                Report.SetParameterValue("txtOutputVat", FormatNumber(vInSales, 2))
                Report.SetParameterValue("txtOutputVat1", FormatNumber(vInSales, 2))
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(vInSales, 2)) & " WHERE IDDescription = 26")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * vInSales, 2)) & " WHERE IDDescription = 27")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(vInSales, 2)) & " WHERE IDDescription = 26")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * vInSales, 2)) & " WHERE IDDescription = 27")
            Else
                Do While rsSale.EOF = False
                    vInSales = vInSales + rsSale.Fields("inclusiveSum").Value
                    vExSales = vExSales + rsSale.Fields("exclusiveSum").Value
                    rsSale.moveNext()
                Loop
                vVatSales = vInSales - vExSales
                Report.SetParameterValue("txtOutputVat", FormatNumber(vVatSales, 2))
                Report.SetParameterValue("txtOutputVat1", FormatNumber(vVatSales, 2))
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(vVatSales, 2)) & " WHERE IDDescription = 26")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * vVatSales, 2)) & " WHERE IDDescription = 27")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(vVatSales, 2)) & " WHERE IDDescription = 26")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * vVatSales, 2)) & " WHERE IDDescription = 27")
            End If
            rsSale.Close()
            'get Settlement movement
            vInSales = 0
            rsSale = getRSreport("SELECT Sum([CustomerTransaction_Amount]) AS SttTotal From CustomerTransaction WHERE CustomerTransaction_TransactionTypeID=8;")
            If IsDbNull(rsSale.Fields("SttTotal").Value) Then
                Report.SetParameterValue("txtSettlement", FormatNumber(vInSales, 0))
                Report.SetParameterValue("txtSettlement1", FormatNumber(vInSales, 0))
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(vInSales, 0)) & " WHERE IDDescription = 11")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * vInSales, 0)) & " WHERE IDDescription = 12")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(vInSales, 0)) & " WHERE IDDescription = 11")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * vInSales, 0)) & " WHERE IDDescription = 12")
            Else
                If rsSale.Fields("SttTotal").Value < 0 Then
                    Report.SetParameterValue("txtSettlement", FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 0))
                    Report.SetParameterValue("txtSettlement1", FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 0))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 0)) & " WHERE IDDescription = 11")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rsSale.Fields("SttTotal").Value, 0)) & " WHERE IDDescription = 12")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 0)) & " WHERE IDDescription = 11")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rsSale.Fields("SttTotal").Value, 0)) & " WHERE IDDescription = 12")
                Else
                    Report.SetParameterValue("txtSettlement", FormatNumber(rsSale.Fields("SttTotal").Value, 0))
                    Report.SetParameterValue("txtSettlement1", FormatNumber(rsSale.Fields("SttTotal").Value, 0))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rsSale.Fields("SttTotal").Value, 0)) & " WHERE IDDescription = 11")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 0)) & " WHERE IDDescription = 12")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rsSale.Fields("SttTotal").Value, 0)) & " WHERE IDDescription = 11")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 0)) & " WHERE IDDescription = 12")
                End If
            End If

            rsSale.Close()

            rsSale = getRSreport("SELECT Sum(SupplierTransaction.SupplierTransaction_Amount) AS SttTotal FROM SupplierTransaction WHERE (((SupplierTransaction.SupplierTransaction_TransactionTypeID)=8));")
            vInSales = 0
            If IsDbNull(rsSale.Fields("SttTotal").Value) Then
                Report.SetParameterValue("txtSettlementD", FormatNumber(vInSales, 2))
                Report.SetParameterValue("txtSettlementD1", FormatNumber(vInSales, 2))
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(vInSales, 2)) & " WHERE IDDescription = 24")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * vInSales, 2)) & " WHERE IDDescription = 25")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(vInSales, 2)) & " WHERE IDDescription = 24")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * vInSales, 2)) & " WHERE IDDescription = 25")
            Else
                If rsSale.Fields("SttTotal").Value < 0 Then
                    Report.SetParameterValue("txtSettlementD", FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2))
                    Report.SetParameterValue("txtSettlementD1", FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 24")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 25")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 24")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 25")
                Else
                    Report.SetParameterValue("txtSettlementD", FormatNumber(rsSale.Fields("SttTotal").Value, 2))
                    Report.SetParameterValue("txtSettlementD1", FormatNumber(rsSale.Fields("SttTotal").Value, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 24")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 25")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 24")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 25")
                End If
            End If

            rsSale.Close()
            rsSale = getRSreport("SELECT Sum(SupplierTransaction.SupplierTransaction_Amount) AS SttTotal FROM SupplierTransaction WHERE (((SupplierTransaction.SupplierTransaction_TransactionTypeID)=3));")
            vInSales = 0
            If IsDbNull(rsSale.Fields("SttTotal").Value) Then
                Report.SetParameterValue("txtCreditorPay", FormatNumber(vInSales, 2))
                Report.SetParameterValue("txtCreditorPay1", FormatNumber(vInSales, 2))
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(vInSales, 2)) & " WHERE IDDescription = 22")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * vInSales, 2)) & " WHERE IDDescription = 23")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(vInSales, 2)) & " WHERE IDDescription = 22")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * vInSales, 2)) & " WHERE IDDescription = 23")
            Else
                If rsSale.Fields("SttTotal").Value < 0 Then
                    Report.SetParameterValue("txtCreditorPay", FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2))
                    Report.SetParameterValue("txtCreditorPay1", FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 22")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 23")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 22")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 23")
                Else
                    Report.SetParameterValue("txtCreditorPay", FormatNumber(rsSale.Fields("SttTotal").Value, 2))
                    Report.SetParameterValue("txtCreditorPay1", FormatNumber(rsSale.Fields("SttTotal").Value, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 22")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 23")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 22")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 23")
                End If
            End If

            'do money movement
            lTotal = 0
            rs = getRSreport("SELECT Sale.Sale_PaymentType, Sum(Sale.Sale_Total) AS amount FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_PaymentType;")
            Do Until rs.EOF
                Select Case rs.Fields("Sale_PaymentType").Value
                    Case 1
                        Report.SetParameterValue("txtMoneyCash", FormatNumber(rs.Fields("amount").Value, 2))
                        lTotal = lTotal + rs.Fields("amount").Value
                        cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 1")
                        cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 1")
                    Case 2
                        Report.SetParameterValue("txtMoneyCRcard", FormatNumber(rs.Fields("amount").Value, 2))
                        lTotal = lTotal + rs.Fields("amount").Value
                        cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 3")
                        cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 3")
                    Case 3
                        Report.SetParameterValue("txtMoneyDRcard", FormatNumber(rs.Fields("amount").Value, 2))
                        lTotal = lTotal + rs.Fields("amount").Value
                        cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 4")
                        cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 4")
                    Case 4
                        Report.SetParameterValue("txtMoneyCheque", FormatNumber(rs.Fields("amount").Value, 2))
                        lTotal = lTotal + rs.Fields("amount").Value
                        cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 2")
                        cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 2")
                End Select
                rs.moveNext()
            Loop
            rs.Close()

            Report.SetParameterValue("txtMoneyTotal", FormatNumber(lTotal, 2))
            cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * lTotal, 2)) & " WHERE IDDescription = 13")
            cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * lTotal, 2)) & " WHERE IDDescription = 13")

            'do invoice discount
            rs = getRSreport("SELECT Sum(Sale.Sale_Discount) AS amount FROM aConsignment RIGHT JOIN (aConsignment AS aConsignment_1 RIGHT JOIN Sale ON aConsignment_1.Consignment_SaleID = Sale.SaleID) ON aConsignment.Consignment_ReversalSaleID = Sale.SaleID WHERE (((aConsignment.ConsignmentID) Is Null) AND ((aConsignment_1.ConsignmentID) Is Null));")
            If IsDbNull(rs.Fields("amount").Value) Then
                Report.SetParameterValue("txtStockDiscount", "0.00")
            Else
                If rs.RecordCount Then
                    Report.SetParameterValue("txtStockDiscount", FormatNumber(0 - rs("amount").Value, 2))
                    Report.SetParameterValue("txtSCmDiscount", FormatNumber(0 - rs("amount").Value, 2))
                Else
                    Report.SetParameterValue("txtStockDiscount", "0.00")
                End If
            End If
            rs.Close()

            rs = getRSreport("SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS content, CBool([SaleItem_DepositType]) AS depositType, SaleItem.SaleItem_Reversal, Sum(([SaleItem_DepositCost]*[SaleItem_Quantity])*(1+[SaleItem_Vat]/100)) AS deposit FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY CBool([SaleItem_DepositType]), SaleItem.SaleItem_Reversal;")
            Do Until rs.EOF
                If rs.Fields("depositType").Value Then
                    If rs.Fields("SaleItem_Reversal").Value Then
                        Report.SetParameterValue("txtStockDepositSold", FormatNumber(rs("content"), 2))
                    Else
                        Report.SetParameterValue("txtStockDepositReturn", FormatNumber(rs("content"), 2))
                    End If
                Else
                    If rs.Fields("SaleItem_Reversal").Value Then
                        Report.SetParameterValue("txtStockCreditContent", FormatNumber(rs("content"), 2))
                        Report.SetParameterValue("txtStockCreditDeposit", FormatNumber(0 - rs("deposit").Value, 2))
                    Else
                        Report.SetParameterValue("txtStockSoldContent", FormatNumber(rs("content"), 2))
                        Report.SetParameterValue("txtStockSoldDeposit", FormatNumber(rs("deposit"), 2))
                    End If
                End If
                rs.moveNext()
            Loop
            rs.Close()
            On Error Resume Next

            rs = getRSreport("SELECT Sum(aCustomerTransaction.CustomerTransaction_Amount) AS SumOfCustomerTransaction_Amount FROM aCustomerTransaction INNER JOIN DayEnd ON aCustomerTransaction.CustomerTransaction_DayEndID = DayEnd.DayEndID WHERE (((aCustomerTransaction.CustomerTransaction_TransactionTypeID)=3 Or (aCustomerTransaction.CustomerTransaction_TransactionTypeID)=4 Or (aCustomerTransaction.CustomerTransaction_TransactionTypeID)=5) AND ((aCustomerTransaction.CustomerTransaction_ReferenceID)=0));")
            If rs.RecordCount Then
                If rs.Fields("SumOfCustomerTransaction_Amount").Value < 0 Then
                    Report.SetParameterValue("txtAccountEFT", FormatNumber(0, 2))
                    Report.SetParameterValue("txtAccountEFT1", FormatNumber(0, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) & " WHERE IDDescription = 9")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) & " WHERE IDDescription = 10")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) & " WHERE IDDescription = 9")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) & " WHERE IDDescription = 10")
                Else
                    If IsDBNull(rs.Fields("SumOfCustomerTransaction_Amount").Value) Then
                        Report.SetParameterValue("txtAccountEFT", "0.00")
                        Report.SetParameterValue("txtAccountEFT1", "0.00")
                        cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(0) & " WHERE IDDescription = 9")
                        cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(0) & " WHERE IDDescription = 10")
                        cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(0) & " WHERE IDDescription = 9")
                        cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(0) & " WHERE IDDescription = 10")
                    Else
                        Report.SetParameterValue("txtAccountEFT", FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2))
                        Report.SetParameterValue("txtAccountEFT1", FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2))
                        cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) & " WHERE IDDescription = 9")
                        cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) & " WHERE IDDescription = 10")
                        cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) & " WHERE IDDescription = 9")
                        cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) & " WHERE IDDescription = 10")
                    End If
                End If
            Else
                Report.SetParameterValue("txtAccountEFT", FormatNumber(0, 2))
                Report.SetParameterValue("txtAccountEFT1", FormatNumber(0, 2))
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 9")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 10")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 9")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 10")
            End If
            'Set rs = getRSreport(sql)
            rDisplay_F = getRS("SELECT * FROM PastelDescription Order By IDDescription ASC")
            For intF = 1 To 29
                Report.SetParameterValue("txtDes1", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar1", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc1", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes2", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar2", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc2", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes3", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar3", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc3", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes4", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar4", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc4", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes5", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar5", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc5", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes6", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar6", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc6", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes7", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar7", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc7", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes8", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar8", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc8", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes9", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar9", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc9", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes10", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar10", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc10", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes11", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar11", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc11", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes12", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar12", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc12", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes13", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar13", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc13", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes14", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar14", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc14", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes15", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar15", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc15", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes16", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar16", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc16", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes17", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar17", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc17", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes18", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar18", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc18", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes19", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar19", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc19", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes20", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar20", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc20", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes21", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar21", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc21", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes22", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar22", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc22", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes23", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar23", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc23", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes24", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar24", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc24", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes25", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar25", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc25", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes26", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar26", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc26", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes27", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar27", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc27", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes28", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar28", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc28", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes29", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar29", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc29", rDisplay_F("AccountNumber"))
                Exit For
            Next

            If lMode Then
            Else
                rs = getRSreport("SELECT Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost]) AS listSales, Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ActualCost]) AS actualSales, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS listShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actualShrink, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost]) AS listGRV, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ActualCost]) AS actualGRV FROM DayEndStockItemLnk;")

                If IsDbNull(rs.Fields("listShrink").Value) Then
                    Report.SetParameterValue("txtSHRL", FormatNumber(0, 2))
                    Report.SetParameterValue("txtSHRL1", FormatNumber(0, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 14")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 15")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 14")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 15")
                Else
                    If rs.Fields("listShrink").Value < 0 Then
                        Report.SetParameterValue("txtSHRL", FormatNumber(-1 * rs.Fields("listShrink").Value, 2))
                        Report.SetParameterValue("txtSHRL1", FormatNumber(-1 * rs.Fields("listShrink").Value, 2))
                    Else
                        Report.SetParameterValue("txtSHRL", FormatNumber(rs.Fields("listShrink").Value, 2))
                        Report.SetParameterValue("txtSHRL1", FormatNumber(rs.Fields("listShrink").Value, 2))
                    End If

                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("listShrink").Value, 2)) & " WHERE IDDescription = 14")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rs.Fields("listShrink").Value, 2)) & " WHERE IDDescription = 15")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("listShrink").Value, 2)) & " WHERE IDDescription = 14")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rs.Fields("listShrink").Value, 2)) & " WHERE IDDescription = 15")
                End If

                If IsDbNull(rs.Fields("listGRV").Value) Then
                    Report.SetParameterValue("txtGRVL1", FormatNumber(0, 2))
                    Report.SetParameterValue("txtGRVL", FormatNumber(0, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 20")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 21")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 20")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 21")
                Else
                    Report.SetParameterValue("txtGRVL1", FormatNumber(rs.Fields("listGRV").Value, 2))
                    Report.SetParameterValue("txtGRVL", FormatNumber(rs.Fields("listGRV").Value, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("listGRV").Value, 2)) & " WHERE IDDescription = 20")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rs.Fields("listGRV").Value, 2)) & " WHERE IDDescription = 21")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("listGRV").Value, 2)) & " WHERE IDDescription = 20")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rs.Fields("listGRV").Value, 2)) & " WHERE IDDescription = 21")
                End If

                If IsDbNull(rs.Fields("listSales").Value) Then
                    Report.SetParameterValue("txtSaleL", FormatNumber(0, 2))
                    Report.SetParameterValue("txtSaleL1", FormatNumber(0, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 16")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 17")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 16")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 17")
                Else
                    Report.SetParameterValue("txtSaleL", FormatNumber(rs.Fields("listSales").Value, 2))
                    Report.SetParameterValue("txtSaleL1", FormatNumber(rs.Fields("listSales").Value, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("listSales").Value, 2)) & " WHERE IDDescription = 16")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rs.Fields("listSales").Value, 2)) & " WHERE IDDescription = 17")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("listSales").Value, 2)) & " WHERE IDDescription = 16")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rs.Fields("listSales").Value, 2)) & " WHERE IDDescription = 17")
                End If
            End If
            rs = getRSreport("SELECT Sum([SaleItem_ListCost]*[SaleItem_Quantity]) AS list, Sum([SaleItem_ActualCost]*[SaleItem_Quantity]) AS actual FROM aConsignment INNER JOIN SaleItem ON aConsignment.Consignment_SaleID = SaleItem.SaleItem_SaleID;")
            If IsDbNull(rs.Fields("list").Value) Then
                Report.SetParameterValue("txtConsLsales", FormatNumber("0", 2))
                Report.SetParameterValue("txtConsAsales", FormatNumber("0", 2))
            Else
                Report.SetParameterValue("txtConsLsales", FormatNumber(rs("list"), 2))
                Report.SetParameterValue("txtConsAsales", FormatNumber(rs("actual"), 2))
            End If
            rs = getRSreport("SELECT Sum(Sale.Sale_Total) AS [amount] FROM aConsignment INNER JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID;")
            If IsDBNull(rs.Fields("amount").Value) Then
                Report.SetParameterValue("txtConsPsales", FormatNumber("0", 2))
            Else
                Report.SetParameterValue("txtConsPsales", FormatNumber(rs("amount"), 2))
            End If

            rs = getRSreport("SELECT Sum([SaleItem_ListCost]*[SaleItem_Quantity]) AS list, Sum([SaleItem_ActualCost]*[SaleItem_Quantity]) AS actual FROM aConsignment INNER JOIN SaleItem ON aConsignment.Consignment_CompleteSaleID = SaleItem.SaleItem_SaleID;")
            If IsDbNull(rs.Fields("list").Value) Then
                Report.SetParameterValue("txtConsLPurchase", FormatNumber("0", 2))
                Report.SetParameterValue("txtConsAPurchase", FormatNumber("0", 2))
            Else
                Report.SetParameterValue("txtConsLPurchase", FormatNumber(rs("list"), 2))
                Report.SetParameterValue("txtConsAPurchase", FormatNumber(rs("actual"), 2))
            End If

            rs = getRSreport("SELECT Sum(theJoin.list) AS list, Sum(theJoin.actual) AS actual FROM (SELECT  1 AS sale, Sum([SaleItem_Quantity]*[SaleItem_ListCost]) AS list, Sum([SaleItem_Quantity]*[SaleItem_actualCost]) AS actual FROM SaleItem INNER JOIN aConsignment ON SaleItem.SaleItem_SaleID = aConsignment.Consignment_CompleteSaleID Union SELECT 0 AS sale, Sum(0-[SaleItem_Quantity]*[SaleItem_ListCost]) AS list, Sum(0-[SaleItem_Quantity]*[SaleItem_actualCost]) AS actual FROM aConsignment INNER JOIN SaleItem ON aConsignment.Consignment_SaleID = SaleItem.SaleItem_SaleID WHERE (((aConsignment.Consignment_CompleteSaleID) Is Not Null))) AS theJoin;")
            If IsDbNull(rs.Fields("list").Value) Then
                Report.SetParameterValue("txtConsLreturn", FormatNumber("0", 2))
                Report.SetParameterValue("txtConsAreturn", FormatNumber("0", 2))
            Else
                Report.SetParameterValue("txtConsLreturn", FormatNumber(rs("list"), 2))
                Report.SetParameterValue("txtConsAreturn", FormatNumber(rs("actual"), 2))
            End If

            rs = getRSreport("SELECT Sum([Sale]![Sale_Total]+[Sale_1]![Sale_Total]) AS priceReturn, Sale.Sale_Total FROM Sale INNER JOIN (Sale AS Sale_1 INNER JOIN aConsignment ON Sale_1.SaleID = aConsignment.Consignment_ReversalSaleID) ON Sale.SaleID = aConsignment.Consignment_CompleteSaleID GROUP BY Sale.Sale_Total;")
            If rs.BOF Or rs.EOF Then
                Report.SetParameterValue("txtConsPPurchase", FormatNumber("0", 2))
                Report.SetParameterValue("txtConsPreturn", FormatNumber("0", 2))
            Else
                If IsDbNull(rs.Fields("Sale_Total").Value) Then
                    Report.SetParameterValue("txtConsPPurchase", FormatNumber("0", 2))
                    Report.SetParameterValue("txtConsPreturn", FormatNumber("0", 2))
                Else
                    Report.SetParameterValue("txtConsPPurchase", FormatNumber(rs("Sale_Total"), 2))
                    Report.SetParameterValue("txtConsPreturn", FormatNumber(rs("priceReturn"), 2))
                End If
            End If

            rs = getRSreport("SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS SCTotal, Sale.Sale_ChannelID FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_ChannelID;")
            'lTotal = CCur(Report.txtSCmDiscount.Text)
            Do Until rs.EOF
                Select Case rs.Fields("Sale_ChannelID").Value
                End Select
                lTotal = lTotal + rs.Fields("SCTotal").Value
                rs.moveNext()
            Loop
            rsPTotals = getRS("SELECT SUM(Amount) As totDebit FROM PastelDescription WHERE Amount > 0")
            rsPTotalss = getRS("SELECT SUM(Amount) as totCredit FROM PastelDescription WHERE Amount < 0")

           If IsDbNull(rsPTotals.Fields("totDebit").Value) Then
                Report.SetParameterValue("txtDebit", FormatNumber(0, 2))
            Else
                Report.SetParameterValue("txtDebit", FormatNumber(rsPTotals.Fields("totDebit").Value))
            End If
            If IsDbNull(rsPTotalss.Fields("totCredit").Value) Then
                Report.SetParameterValue("txtCredit", FormatNumber(0, 2))
            Else
                Report.SetParameterValue("txtCredit", FormatNumber(rsPTotalss.Fields("totCredit").Value))
            End If


            If blpastel = True Then 'Pastel export file
                System.Windows.Forms.Cursor.Current = Cursors.Default
                Exit Sub
            End If
            frmReportShow.Text = "Pastel Report"
            frmReportShow.CRViewer1.ReportSource = Report
            frmReportShow.mReport = Report : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()

        End If

    End Sub

    Private Sub report_SalespastelXX()
        Dim intF As Integer
        Dim rDisplay_F As CrystalDecisions.CrystalReports.Engine.Groups
        Dim vVatSales As Decimal
        Dim sql2 As String
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim lMode As Boolean
        Dim lPasteCurr As Decimal
        Dim vInSales As Decimal
        Dim vExSales As Decimal
        Dim lTotal As Decimal
        Dim lCash As Decimal
        Dim lDebit As Decimal
        Dim lCheque As Decimal
        Dim lCredit As Decimal
        Dim rs As ADODB.Recordset
        Dim rsSale As ADODB.Recordset
        Dim rsPTotals As ADODB.Recordset

        Report.Load("cryPastelCube.rpt")

        cnnDB.Execute("UPDATE PastelDescription SET Amount=0,HomeAmount=0,PastelDate=#" & CDate(Today) & "#, Reference = '4POS'")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        Dim rsPTotalss As ADODB.Recordset
        If openConnectionReport() Then
            rs = getRSreport("SELECT aCompany.Company_Name, Report.Report_Heading FROM aCompany, Report;")
            Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
            Report.SetParameterValue("txtFilter", rs.Fields("Report_Heading"))

            'get payoutTotal
            rs = getRSreport("SELECT Sum(Payout.Payout_Amount) AS [amount] FROM Payout;")
            If IsDbNull(rs.Fields("amount").Value) Then
                Report.SetParameterValue("txtPayout", "0.00")
                Report.SetParameterValue("txtPayout1", "0.00")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & ",HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 18")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & ",HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 19")
            Else
                Report.SetParameterValue("txtPayout", FormatNumber(rs.Fields("amount").Value, 2))
                Report.SetParameterValue("txtPayout1", FormatNumber(rs.Fields("amount").Value, 2))
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 18")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 19")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 18")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 19")
            End If
            rs.Close()

            'get outages................
            rs = getRSreport("SELECT Sum(([Declaration_Cash]+[Declaration_Cheque]+[Declaration_Card]-[Declaration_Payout])-([Declaration_CashServer]+[Declaration_ChequeServer]+[Declaration_CardServer]-[Declaration_PayoutServer])) AS amount FROM Declaration;")
            If IsDbNull(rs.Fields("amount").Value) Then
                Report.SetParameterValue("txtOutage", "0.00")
                Report.SetParameterValue("txtOutage1", "0.00")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 5")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 6")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 5")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 6")
            Else
                If rs.Fields("amount").Value < 0 Then
                    Report.SetParameterValue("txtOutage", FormatNumber(-1 * rs.Fields("amount").Value, 2))
                    Report.SetParameterValue("txtOutage1", FormatNumber(-1 * rs.Fields("amount").Value, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 5")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 6")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 5")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 6")
                Else
                    Report.SetParameterValue("txtOutage", FormatNumber(rs.Fields("amount").Value, 2))
                    Report.SetParameterValue("txtOutage1", FormatNumber(rs.Fields("amount").Value, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 5")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 6")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 5")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rs.Fields("amount").Value, 2)) & " WHERE IDDescription = 6")
                End If
            End If
            rs.Close()

            'get account movement........................

            'lTotal = 0
            'lCash = 0
            'lDebit = 0
            'lCheque = 0
            'lCredit = 0

            'Dim sqlZ As String
            'sqlZ = "SELECT Sum(Sale.Sale_Total) AS amount, Sale.Sale_PaymentType, Sum([Sale_Total]-[Sale_Discount]) AS Subtotal, Sum(Sale.Sale_Discount) AS discount, Sum(Sale.Sale_Cash) AS amountCash, Sum(Sale.Sale_Card) AS amountCard, " & _
            ''                    "Sum(Sale.Sale_CDebit) AS amountCredit, Sum(Sale.Sale_Cheque) AS amountCheque FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (CustomerTransaction INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID " & _
            ''                    "Where (((CustomerTransaction.CustomerTransaction_TransactionTypeID) = 2 Or (CustomerTransaction.CustomerTransaction_TransactionTypeID) = 3) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_PaymentType;"
            'Debug.Print sqlZ
            'Set rs = getRSreport(sqlZ)
            '"SELECT Sum(Sale.Sale_Total) AS amount, Sale.Sale_PaymentType, Sum([Sale_Total]-[Sale_Discount]) AS Subtotal, Sum(Sale.Sale_Discount) AS discount, Sum(Sale.Sale_Cash) AS amountCash, Sum(Sale.Sale_Card) AS amountCard, Sum(Sale.Sale_CDebit) AS amountCreR"
            lTotal = 0
            rs = getRSreport("SELECT Sum(Sale.Sale_Total) AS amount, Sale.Sale_PaymentType, Sum([Sale_Total]-[Sale_Discount]) AS Subtotal, Sum(Sale.Sale_Discount) AS discount FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (CustomerTransaction INNER JOIN Sale ON CustomerTransaction.CustomerTransaction_ReferenceID = Sale.SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((CustomerTransaction.CustomerTransaction_TransactionTypeID) = 2 Or (CustomerTransaction.CustomerTransaction_TransactionTypeID) = 3) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_PaymentType;")

            Do Until rs.EOF
                Select Case rs.Fields("Sale_PaymentType").Value
                    Case 5
                        Report.SetParameterValue("txtAccountSales", FormatNumber(rs.Fields("subtotal").Value, 2))
                        Report.SetParameterValue("txtAccountSales1", FormatNumber(rs.Fields("subtotal").Value, 2))
                        cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("subtotal").Value, 2)) & " WHERE IDDescription = 7")
                        cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rs.Fields("subtotal").Value, 2)) & " WHERE IDDescription = 8")
                        cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("subtotal").Value, 2)) & " WHERE IDDescription = 7")
                        cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rs.Fields("subtotal").Value, 2)) & " WHERE IDDescription")
                    Case 1
                        lCash = lCash + rs.Fields("amountCash").Value
                        lTotal = lTotal - rs.Fields("amount").Value
                    Case 2
                        lTotal = lTotal - rs.Fields("amount").Value
                        lCredit = lCredit + rs.Fields("amountCredit").Value
                    Case 3
                        lTotal = lTotal - rs.Fields("amount").Value
                        lDebit = lDebit + rs.Fields("amountCard").Value
                    Case 4
                        lCheque = lCheque + rs.Fields("amountCheque").Value
                        lTotal = lTotal - rs.Fields("amount").Value
                    Case 7
                        lTotal = lTotal - rs.Fields("amount").Value
                        lCash = lCash + rs.Fields("amountCash").Value
                        lDebit = lDebit + rs.Fields("amountCard").Value
                        lCredit = lCredit + rs.Fields("amountCredit").Value
                        lCheque = lCheque + rs.Fields("amountCheque").Value
                End Select
                rs.moveNext()
            Loop
            rs.Close()

            'Get Output Vat.......................

            sql2 = "SELECT SaleItem.SaleItem_StockItemID, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ActualCost]*[SaleItem_Quantity],[SaleItem_ActualCost]*[SaleItem_Quantity])) AS actualCostSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ListCost]*[SaleItem_Quantity],[SaleItem_ListCost]*[SaleItem_Quantity])) AS listCostSum, Sum(([SaleItem_Price]*[SaleItem_Quantity]/(1+[SaleItem_Vat]/100))) AS exclusiveSum, Sum(([SaleItem_Price]*[SaleItem_Quantity])) AS inclusiveSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_DepositCost]*[SaleItem_Quantity],[SaleItem_DepositCost]*[SaleItem_Quantity])) AS depositSum, Sum(IIf([SaleItem_Reversal],0-[SaleItem_ShrinkQuantity]*[SaleItem_Quantity],[SaleItem_ShrinkQuantity]*[SaleItem_Quantity])) AS quantitySum FROM Sale INNER JOIN (aConsignment AS aConsignment_1 RIGHT JOIN (SaleItem LEFT JOIN aConsignment ON SaleItem.SaleItem_SaleID=aConsignment.Consignment_SaleID) ON aConsignment_1.Consignment_ReversalSaleID=SaleItem.SaleItem_SaleID) ON Sale.SaleID=SaleItem.SaleItem_SaleID" & " Where (((SaleItem.SaleItem_DepositType) = 0) And ((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null))" & " GROUP BY SaleItem.SaleItem_StockItemID;"
            rsSale = getRSreport(sql2)

            vInSales = 0

            If rsSale.EOF Or rsSale.BOF Then
                Report.SetParameterValue("txtOutputVat", FormatNumber(vInSales, 2))
                Report.SetParameterValue("txtOutputVat1", FormatNumber(vInSales, 2))
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(vInSales, 2)) & " WHERE IDDescription = 26")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * vInSales, 2)) & " WHERE IDDescription = 27")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(vInSales, 2)) & " WHERE IDDescription = 26")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * vInSales, 2)) & " WHERE IDDescription = 27")
            Else
                Do While rsSale.EOF = False
                    vInSales = vInSales + rsSale.Fields("inclusiveSum").Value
                    vExSales = vExSales + rsSale.Fields("exclusiveSum").Value
                    rsSale.moveNext()
                Loop
               vVatSales = vInSales - vExSales
                Report.SetParameterValue("txtOutputVat", FormatNumber(vVatSales, 2))
                Report.SetParameterValue("txtOutputVat1", FormatNumber(vVatSales, 2))
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(vVatSales, 2)) & " WHERE IDDescription = 26")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * vVatSales, 2)) & " WHERE IDDescription = 27")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(vVatSales, 2)) & " WHERE IDDescription = 26")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * vVatSales, 2)) & " WHERE IDDescription = 27")
            End If
            rsSale.Close()

            'get Settlement movement................

            vInSales = 0
            rsSale = getRSreport("SELECT Sum([CustomerTransaction_Amount]) AS SttTotal From CustomerTransaction WHERE CustomerTransaction_TransactionTypeID=8;")
            If IsDbNull(rsSale.Fields("SttTotal").Value) Then
                Report.SetParameterValue("txtSettlement", FormatNumber(vInSales, 0))
                Report.SetParameterValue("txtSettlement1", FormatNumber(vInSales, 0))
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(vInSales, 2)) & " WHERE IDDescription = 11")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * vInSales, 2)) & " WHERE IDDescription = 12")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(vInSales, 2)) & " WHERE IDDescription = 11")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * vInSales, 2)) & " WHERE IDDescription = 12")
            Else
                If rsSale.Fields("SttTotal").Value < 0 Then
                    Report.SetParameterValue("txtSettlement", FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2))
                    Report.SetParameterValue("txtSettlement1", FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 11")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 12")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 11")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 12")
                Else
                    Report.SetParameterValue("txtSettlement", FormatNumber(rsSale.Fields("SttTotal").Value, 2))
                    Report.SetParameterValue("txtSettlement1", FormatNumber(rsSale.Fields("SttTotal").Value, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 11")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 12")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 11")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 12")
                End If
            End If
            rsSale.Close()

            rsSale = getRSreport("SELECT Sum(SupplierTransaction.SupplierTransaction_Amount) AS SttTotal FROM SupplierTransaction WHERE (((SupplierTransaction.SupplierTransaction_TransactionTypeID)=8));")
            vInSales = 0
           If IsDbNull(rsSale.Fields("SttTotal").Value) Then
                Report.SetParameterValue("txtSettlementD", FormatNumber(vInSales, 2))
                Report.SetParameterValue("txtSettlementD1", FormatNumber(vInSales, 2))
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(vInSales, 2)) & " WHERE IDDescription = 24")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * vInSales, 2)) & " WHERE IDDescription = 25")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(vInSales, 2)) & " WHERE IDDescription = 24")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * vInSales, 2)) & " WHERE IDDescription = 25")
            Else
                If rsSale.Fields("SttTotal").Value < 0 Then
                    Report.SetParameterValue("txtSettlementD", FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2))
                    Report.SetParameterValue("txtSettlementD1", FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 24")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 25")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 24")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 25")
                Else
                    Report.SetParameterValue("txtSettlementD", FormatNumber(rsSale.Fields("SttTotal").Value, 2))
                    Report.SetParameterValue("txtSettlementD1", FormatNumber(rsSale.Fields("SttTotal").Value, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 24")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 25")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 24")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 25")
                End If
            End If

            rsSale.Close()

            rsSale = getRSreport("SELECT Sum(SupplierTransaction.SupplierTransaction_Amount) AS SttTotal FROM SupplierTransaction WHERE (((SupplierTransaction.SupplierTransaction_TransactionTypeID)=3));")
            vInSales = 0
            If IsDbNull(rsSale.Fields("SttTotal").Value) Then
                Report.SetParameterValue("txtCreditorPay", FormatNumber(vInSales, 2))
                Report.SetParameterValue("txtCreditorPay1", FormatNumber(vInSales, 2))
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(vInSales, 2)) & " WHERE IDDescription = 22")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * vInSales, 2)) & " WHERE IDDescription = 23")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(vInSales, 2)) & " WHERE IDDescription = 22")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * vInSales, 2)) & " WHERE IDDescription = 23")
            Else
                If rsSale.Fields("SttTotal").Value < 0 Then
                    Report.SetParameterValue("txtCreditorPay", FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2))
                    Report.SetParameterValue("txtCreditorPay1", FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 22")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 23")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 22")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 23")
                Else
                    Report.SetParameterValue("txtCreditorPay", FormatNumber(rsSale.Fields("SttTotal").Value, 2))
                    Report.SetParameterValue("txtCreditorPay1", FormatNumber(rsSale.Fields("SttTotal").Value, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 22")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 23")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 22")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rsSale.Fields("SttTotal").Value, 2)) & " WHERE IDDescription = 23")
                End If
            End If

            'do money movement....................
            lCash = 0
            lDebit = 0
            lCheque = 0
            lCredit = 0
            lTotal = 0
            rs = getRSreport("SELECT Sale.Sale_PaymentType,Sum(Sale.Sale_Total) as AmountTotal, Sum(Sale.Sale_Cash) AS amountCash,Sum(Sale.Sale_Card) AS amountCard,Sum(Sale.Sale_Cheque) AS amountCheque,Sum(Sale.Sale_CDebit) AS amountCredit FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_PaymentType;")

            Do Until rs.EOF
                Select Case rs.Fields("Sale_PaymentType").Value
                    Case 1
                        lCash = lCash + rs.Fields("amountCash").Value
                        lTotal = lTotal + rs.Fields("AmountTotal").Value
                        Report.SetParameterValue("txtMoneyCash", FormatNumber(rs("amount"), 2))
                    Case 2
                        lCredit = lCredit + rs.Fields("amountCredit").Value
                        lTotal = lTotal + rs.Fields("AmountTotal").Value
                        Report.SetParameterValue("txtMoneyCRcard", FormatNumber(rs("amount"), 2))
                    Case 3
                        lDebit = lDebit + rs.Fields("amountCard").Value
                        lTotal = lTotal + rs.Fields("AmountTotal").Value
                        Report.SetParameterValue("txtMoneyDRcard", FormatNumber(rs("amount"), 2))
                    Case 4
                        lTotal = lTotal + rs.Fields("AmountTotal").Value
                        lCheque = lCheque + rs.Fields("amountCheque").Value
                        Report.SetParameterValue("txtMoneyCheque", FormatNumber(rs("amount"), 2))
                    Case 7
                        lTotal = lTotal + rs.Fields("AmountTotal").Value
                        lCash = lCash + rs.Fields("amountCash").Value
                        lDebit = lDebit + rs.Fields("amountCard").Value
                        lCredit = lCredit + rs.Fields("amountCredit").Value
                        lCheque = lCheque + rs.Fields("amountCheque").Value
                End Select
                rs.moveNext()
            Loop
            rs.Close()

            '1. Cash
            Report.SetParameterValue("txtMoneyCash", FormatNumber(lCash, 2))
            cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(lCash, 2)) & " WHERE IDDescription = 1")
            cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(lCash, 2)) & " WHERE IDDescription = 1")
            '2. Credit Card
            Report.SetParameterValue("txtMoneyCRcard", FormatNumber(lCredit, 2))
            cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(lCredit, 2)) & " WHERE IDDescription = 3")
            cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(lCredit, 2)) & " WHERE IDDescription = 3")
            '3. Debit Card.
            Report.SetParameterValue("txtMoneyDRcard", FormatNumber(lDebit, 2))
            cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(lDebit, 2)) & " WHERE IDDescription = 4")
            cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(lDebit, 2)) & " WHERE IDDescription = 4")
            '4. Cheque
            Report.SetParameterValue("txtMoneyCheque", FormatNumber(lCheque, 2))
            cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(lCheque, 2)) & " WHERE IDDescription = 2")
            cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(lCheque, 2)) & " WHERE IDDescription = 2")

            'Total Money movement
            Report.SetParameterValue("txtMoneyTotal", FormatNumber(lTotal, 2))
            cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * lTotal, 2)) & " WHERE IDDescription = 13")
            cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * lTotal, 2)) & " WHERE IDDescription = 13")
            lTotal = 0
            'do invoice discount....................

            On Error Resume Next

            rs = getRSreport("SELECT Sum(aCustomerTransaction.CustomerTransaction_Amount) AS SumOfCustomerTransaction_Amount FROM aCustomerTransaction INNER JOIN DayEnd ON aCustomerTransaction.CustomerTransaction_DayEndID = DayEnd.DayEndID WHERE (((aCustomerTransaction.CustomerTransaction_TransactionTypeID)=3 Or (aCustomerTransaction.CustomerTransaction_TransactionTypeID)=4 Or (aCustomerTransaction.CustomerTransaction_TransactionTypeID)=5) AND ((aCustomerTransaction.CustomerTransaction_ReferenceID)=0));")
            If rs.RecordCount Then
                If rs.Fields("SumOfCustomerTransaction_Amount").Value < 0 Then
                    Report.SetParameterValue("txtAccountEFT", FormatNumber(0, 2))
                    Report.SetParameterValue("txtAccountEFT1", FormatNumber(0, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) & " WHERE IDDescription = 9")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) & " WHERE IDDescription = 10")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) & " WHERE IDDescription = 9")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) & " WHERE IDDescription = 10")
                Else
                    If IsDBNull(rs.Fields("SumOfCustomerTransaction_Amount").Value) Then
                        Report.SetParameterValue("txtAccountEFT", "0.00")
                        Report.SetParameterValue("txtAccountEFT1", "0.00")
                        cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(0) & " WHERE IDDescription = 9")
                        cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(0) & " WHERE IDDescription = 10")
                        cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(0) & " WHERE IDDescription = 9")
                        cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(0) & " WHERE IDDescription = 10")
                    Else
                        Report.SetParameterValue("txtAccountEFT", FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2))
                        Report.SetParameterValue("txtAccountEFT1", FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2))
                        cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) & " WHERE IDDescription = 9")
                        cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) & " WHERE IDDescription = 10")
                        cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) & " WHERE IDDescription = 9")
                        cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rs.Fields("SumOfCustomerTransaction_Amount").Value, 2)) & " WHERE IDDescription = 10")
                    End If
                End If
            Else
                Report.SetParameterValue("txtAccountEFT", FormatNumber(0, 2))
                Report.SetParameterValue("txtAccountEFT1", FormatNumber(0, 2))
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 9")
                cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 10")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 9")
                cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 10")
            End If
            'Set rs = getRSreport(sql)
            rDisplay_F = getRS("SELECT * FROM PastelDescription Order By IDDescription ASC")
            For intF = 1 To 29
                Report.SetParameterValue("txtDes1", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar1", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc1", rDisplay_F("AccountNumber"))
                rDisplay_F.MoveNext()
                Report.SetParameterValue("txtDes2", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar2", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc2", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes3", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar3", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc3", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes4", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar4", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc4", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes5", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar5", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc5", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes6", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar6", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc6", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes7", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar7", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc7", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes8", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar8", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc8", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes9", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar9", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc9", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes10", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar10", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc10", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes11", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar11", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc11", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes12", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar12", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc12", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes13", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar13", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc13", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes14", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar14", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc14", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes15", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar15", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc15", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes16", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar16", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc16", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes17", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar17", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc17", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes18", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar18", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc18", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes19", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar19", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc19", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes20", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar20", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc20", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes21", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar21", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc21", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes22", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar22", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc22", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes23", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar23", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc23", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes24", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar24", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc24", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes25", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar25", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc25", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes26", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar26", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc26", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes27", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar27", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc27", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes28", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar28", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc28", rDisplay_F("AccountNumber"))
                rDisplay_F.moveNext()
                Report.SetParameterValue("txtDes29", rDisplay_F("Description"))
                Report.SetParameterValue("txtNar29", rDisplay_F("Decription1"))
                Report.SetParameterValue("txtAcc29", rDisplay_F("AccountNumber"))
                Exit For
            Next
            If lMode Then
            Else
                rs = getRSreport("SELECT Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ListCost]) AS listSales, Sum([DayEndStockItemLnk_QuantitySales]*[DayEndStockItemLnk_ActualCost]) AS actualSales, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ListCost]) AS listShrink, Sum([DayEndStockItemLnk_QuantityShrink]*[DayEndStockItemLnk_ActualCost]) AS actualShrink, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ListCost]) AS listGRV, Sum([DayEndStockItemLnk_QuantityGRV]*[DayEndStockItemLnk_ActualCost]) AS actualGRV FROM DayEndStockItemLnk;")

                If IsDBNull(rs.Fields("listShrink").Value) Then
                    Report.SetParameterValue("txtSHRL", FormatNumber(0, 2))
                    Report.SetParameterValue("txtSHRL1", FormatNumber(0, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 14")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 15")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 14")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 15")
                Else
                    If rs.Fields("listShrink").Value < 0 Then
                        Report.SetParameterValue("txtSHRL", FormatNumber(-1 * rs.Fields("listShrink").Value, 2))
                        Report.SetParameterValue("txtSHRL1", FormatNumber(-1 * rs.Fields("listShrink").Value, 2))
                    Else
                        Report.SetParameterValue("txtSHRL", FormatNumber(rs.Fields("listShrink").Value, 2))
                        Report.SetParameterValue("txtSHRL1", FormatNumber(rs.Fields("listShrink").Value, 2))
                    End If

                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("listShrink").Value, 2)) & " WHERE IDDescription = 14")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rs.Fields("listShrink").Value, 2)) & " WHERE IDDescription = 15")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("listShrink").Value, 2)) & " WHERE IDDescription = 14")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rs.Fields("listShrink").Value, 2)) & " WHERE IDDescription = 15")
                End If

                If IsDBNull(rs.Fields("listGRV").Value) Then
                    Report.SetParameterValue("txtGRVL1", FormatNumber(0, 2))
                    Report.SetParameterValue("txtGRVL", FormatNumber(0, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 20")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 21")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 20")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 21")
                Else
                    Report.SetParameterValue("txtGRVL1", FormatNumber(rs.Fields("listGRV").Value, 2))
                    Report.SetParameterValue("txtGRVL", FormatNumber(rs.Fields("listGRV").Value, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("listGRV").Value, 2)) & " WHERE IDDescription = 20")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rs.Fields("listGRV").Value, 2)) & " WHERE IDDescription = 21")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("listGRV").Value, 2)) & " WHERE IDDescription = 20")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rs.Fields("listGRV").Value, 2)) & " WHERE IDDescription = 21")
                End If

                If IsDBNull(rs.Fields("listSales").Value) Then
                    Report.SetParameterValue("txtSaleL", FormatNumber(0, 2))
                    Report.SetParameterValue("txtSaleL1", FormatNumber(0, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 16")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 17")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 16")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(0, 2)) & " WHERE IDDescription = 17")
                Else
                    Report.SetParameterValue("txtSaleL", FormatNumber(rs.Fields("listSales").Value, 2))
                    Report.SetParameterValue("txtSaleL1", FormatNumber(rs.Fields("listSales").Value, 2))
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(rs.Fields("listSales").Value, 2)) & " WHERE IDDescription = 16")
                    cnnDB.Execute("UPDATE PastelDescription SET Amount = " & CDec(FormatNumber(-1 * rs.Fields("listSales").Value, 2)) & " WHERE IDDescription = 17")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(rs.Fields("listSales").Value, 2)) & " WHERE IDDescription = 16")
                    cnnDB.Execute("UPDATE PastelDescription SET HomeAmount = " & CDec(FormatNumber(-1 * rs.Fields("listSales").Value, 2)) & " WHERE IDDescription = 17")
                End If
            End If
            rs = getRSreport("SELECT Sum([SaleItem_ListCost]*[SaleItem_Quantity]) AS list, Sum([SaleItem_ActualCost]*[SaleItem_Quantity]) AS actual FROM aConsignment INNER JOIN SaleItem ON aConsignment.Consignment_SaleID = SaleItem.SaleItem_SaleID;")
            If IsDBNull(rs.Fields("list").Value) Then
                Report.SetParameterValue("txtConsLsales", FormatNumber("0", 2))
                Report.SetParameterValue("txtConsAsales", FormatNumber("0", 2))
            Else
                Report.SetParameterValue("txtConsLsales", FormatNumber(rs("list"), 2))
                Report.SetParameterValue("txtConsAsales", FormatNumber(rs("actual"), 2))
            End If
            rs = getRSreport("SELECT Sum(Sale.Sale_Total) AS [amount] FROM aConsignment INNER JOIN Sale ON aConsignment.Consignment_SaleID = Sale.SaleID;")
            If IsDBNull(rs.Fields("amount").Value) Then
                Report.SetParameterValue("txtConsPsales", FormatNumber("0", 2))
            Else
                Report.SetParameterValue("txtConsPsales", FormatNumber(rs("amount"), 2))
            End If

            rs = getRSreport("SELECT Sum([SaleItem_ListCost]*[SaleItem_Quantity]) AS list, Sum([SaleItem_ActualCost]*[SaleItem_Quantity]) AS actual FROM aConsignment INNER JOIN SaleItem ON aConsignment.Consignment_CompleteSaleID = SaleItem.SaleItem_SaleID;")
            If IsDBNull(rs.Fields("list").Value) Then
                Report.SetParameterValue("txtConsLPurchase", FormatNumber("0", 2))
                Report.SetParameterValue("txtConsAPurchase", FormatNumber("0", 2))
            Else
                Report.SetParameterValue("txtConsLPurchase", FormatNumber(rs("list"), 2))
                Report.SetParameterValue("txtConsAPurchase", FormatNumber(rs("actual"), 2))
            End If

            rs = getRSreport("SELECT Sum(theJoin.list) AS list, Sum(theJoin.actual) AS actual FROM (SELECT  1 AS sale, Sum([SaleItem_Quantity]*[SaleItem_ListCost]) AS list, Sum([SaleItem_Quantity]*[SaleItem_actualCost]) AS actual FROM SaleItem INNER JOIN aConsignment ON SaleItem.SaleItem_SaleID = aConsignment.Consignment_CompleteSaleID Union SELECT 0 AS sale, Sum(0-[SaleItem_Quantity]*[SaleItem_ListCost]) AS list, Sum(0-[SaleItem_Quantity]*[SaleItem_actualCost]) AS actual FROM aConsignment INNER JOIN SaleItem ON aConsignment.Consignment_SaleID = SaleItem.SaleItem_SaleID WHERE (((aConsignment.Consignment_CompleteSaleID) Is Not Null))) AS theJoin;")
            If IsDBNull(rs.Fields("list").Value) Then
                Report.SetParameterValue("txtConsLreturn", FormatNumber("0", 2))
                Report.SetParameterValue("txtConsAreturn", FormatNumber("0", 2))
            Else
                Report.SetParameterValue("txtConsLreturn", FormatNumber(rs("list"), 2))
                Report.SetParameterValue("txtConsAreturn", FormatNumber(rs("actual"), 2))
            End If

            rs = getRSreport("SELECT Sum([Sale]![Sale_Total]+[Sale_1]![Sale_Total]) AS priceReturn, Sale.Sale_Total FROM Sale INNER JOIN (Sale AS Sale_1 INNER JOIN aConsignment ON Sale_1.SaleID = aConsignment.Consignment_ReversalSaleID) ON Sale.SaleID = aConsignment.Consignment_CompleteSaleID GROUP BY Sale.Sale_Total;")
            If rs.BOF Or rs.EOF Then
                Report.SetParameterValue("txtConsPPurchase", FormatNumber("0", 2))
                Report.SetParameterValue("txtConsPreturn", FormatNumber("0", 2))
            Else
                If IsDBNull(rs.Fields("Sale_Total").Value) Then
                    Report.SetParameterValue("txtConsPPurchase", FormatNumber("0", 2))
                    Report.SetParameterValue("txtConsPreturn", FormatNumber("0", 2))
                Else
                    Report.SetParameterValue("txtConsPPurchase", FormatNumber(rs("Sale_Total"), 2))
                    Report.SetParameterValue("txtConsPreturn", FormatNumber(rs("priceReturn"), 2))
                End If
            End If

            rs = getRSreport("SELECT Sum([SaleItem_Price]*[SaleItem_Quantity]) AS SCTotal, Sale.Sale_ChannelID FROM aConsignment AS aConsignment_1 RIGHT JOIN (aConsignment RIGHT JOIN (Sale INNER JOIN SaleItem ON Sale.SaleID = SaleItem.SaleItem_SaleID) ON aConsignment.Consignment_SaleID = Sale.SaleID) ON aConsignment_1.Consignment_ReversalSaleID = Sale.SaleID Where (((SaleItem.SaleItem_Revoke) = False) And ((aConsignment.ConsignmentID) Is Null) And ((aConsignment_1.ConsignmentID) Is Null)) GROUP BY Sale.Sale_ChannelID;")
            'lTotal = CCur(Report.txtSCmDiscount.Text)
            Do Until rs.EOF
                Select Case rs.Fields("Sale_ChannelID").Value
                End Select
                lTotal = lTotal + rs.Fields("SCTotal").Value
                rs.MoveNext()
            Loop
            rsPTotals = getRS("SELECT SUM(Amount) As totDebit FROM PastelDescription WHERE Amount > 0")
            rsPTotalss = getRS("SELECT SUM(Amount) as totCredit FROM PastelDescription WHERE Amount < 0")

            If IsDBNull(rsPTotals.Fields("totDebit").Value) Then
                Report.SetParameterValue("txtDebit", FormatNumber(0, 2))
            Else
                Report.SetParameterValue("txtDebit", FormatNumber(rsPTotals.Fields("totDebit").Value))
            End If
            If IsDBNull(rsPTotalss.Fields("totCredit").Value) Then
                Report.SetParameterValue("txtCredit", FormatNumber(0, 2))
            Else
                Report.SetParameterValue("txtCredit", FormatNumber(rsPTotalss.Fields("totCredit").Value))
            End If
            If blpastel = True Then 'Pastel export file
                System.Windows.Forms.Cursor.Current = Cursors.Default
                Exit Sub
            End If

            frmReportShow.Text = "Pastel Report"
            frmReportShow.CRViewer1.ReportSource = Report
            frmReportShow.mReport = Report : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
        End If
    End Sub
    Public Sub ExportToCSVFile()
        Dim dbText As String
        Dim ptbl As String
        Dim lne As String
        Dim n As Short
        Dim StDate As String
        Dim t_Day As String
        Dim t_Mon As String
        Dim rs As ADODB.Recordset
        Dim fso As New Scripting.FileSystemObject

        If Len(Trim(Str(VB.Day(Today)))) = 1 Then t_Day = "0" & Trim(CStr(VB.Day(Today))) Else t_Day = CStr(VB.Day(Today))
        If Len(Trim(Str(Month(Today)))) = 1 Then t_Mon = "0" & Trim(CStr(Month(Today))) Else t_Mon = Str(Month(Today))

        ptbl = serverPath & "4POSPAS" & Trim(CStr(Year(Today))) & Trim(t_Mon) & Trim(t_Day)

        If fso.FileExists(ptbl & ".csv") Then fso.DeleteFile((ptbl & ".csv"))

       FileOpen(1, ptbl & ".csv", OpenMode.Output)

        rs = getRS("SELECT Period,PastelDate,GDC,AccountNumber,Reference,Decription1,Amount,[Tax Type],[Tax Amount],[OpenItemType],[CostCode],[ContractAccount],[Exchange Rate],[Bank ExchangeRate],[Batch ID],[Discount TaxType],[Discount Amount],[HomeAmount] FROM PastelDescription")
        If rs.RecordCount > 0 Then
            For n = 0 To rs.Fields.Count - 1 'First line as column headings
                lne = lne & Chr(34) & rs.Fields(n).Name & Chr(34) & ","
            Next n

            'Print #1, lne

            Do While Not rs.EOF
                lne = ""
                For n = 0 To rs.Fields.Count - 1

                    If n = 10 Then
                        If rs.Fields(n).Value = 0 Then lne = lne & " " & ","
                    Else
                        If rs.Fields(n).Type = dbText Then
                            lne = lne & Chr(34) & rs.Fields(n).Value & Chr(34) & ","
                        Else
                            If rs.Fields(n).Type = 135 Then 'Re-write date format...
                                lne = lne & Format(rs.Fields(n).Value, "dd/mm/yyyy") & ","
                            Else
                                lne = lne & rs.Fields(n).Value & ","
                            End If
                        End If
                    End If

                Next n

                lne = Left(lne, Len(lne) - 1) 'get rid of last comma
                PrintLine(1, lne)
                rs.moveNext()
            Loop
            FileClose(1)
        End If

        If blpastel = True Then MsgBox("Pastel CSV File, was succesfully exported to " & ptbl, MsgBoxStyle.ApplicationModal + MsgBoxStyle.OKOnly + MsgBoxStyle.Information, My.Application.Info.Title)


    End Sub
    Sub report_KitchenMonitor(ByRef Dt1 As Date, ByRef Dt2 As Date, ByRef Dt3 As Date, ByRef Dt4 As Date)
        'Dim sql     As String
        'Dim K_path  As String
        'Dim rs      As Recordset
        'Dim Report  As New cryKitchenMonitor

        'Screen.MousePointer = vbHourglass
        'Set rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        'Report.txtCompanyName.SetText rs("Company_Name")

        'sql = "SELECT OrderMonitor.OrderReferenceID,Sum(ItemMonitor.ItemMonitor_Quantity) AS quantitySum, OrderMonitor.OrderMonitor_TPlaced, OrderMonitor.OrderMonitor_TCompleted, DateDiff('s',[OrderMonitor_TPlaced],[OrderMonitor_TCompleted]) AS Elapsed, Sum([ItemMonitor_Quantity]*[ItemMonitor_Price]) AS rTurnOver,OrderMonitor.OrderMonitor_Date FROM OrderMonitor INNER JOIN ItemMonitor ON OrderMonitor.OrderReferenceID = ItemMonitor.ItemMonitor_OrderID  Where (((OrderMonitor.OrderMonitor_OrderStatus) = True) And ((OrderMonitor.OrderMoniotor_FPlaced) = True)) GROUP BY OrderMonitor.OrderReferenceID, OrderMonitor.OrderMonitor_TPlaced, OrderMonitor.OrderMonitor_TCompleted, OrderMonitor.OrderMonitor_Date ORDER BY Sum(ItemMonitor.ItemMonitor_Quantity);"
        'Set rs = getRS(sql)
        'rs.filter = "OrderMonitor_Date<=#" & Format(Dt1, "yyyy/MM/dd") & "# AND OrderMonitor_Date>=#" & Format(Dt2, "yyyy/MM/dd") & "#"

        'rs.filter = "OrderMonitor_TPlaced >=#" & Format(Dt3, "hh:mm:ss") & "# AND OrderMonitor_TCompleted <=#" & Format(Dt4, "hh:mm:ss") & "#"

        'If rs.BOF Or rs.EOF Then
        '        'ReportNone.Load("cryNoRecords.rpt")
        '        ReportNone.txtCompanyName.SetText Report.txtCompanyName.Text
        '        ReportNone.txtTitle.SetText Report.txtTitle.Text
        '        frmReportShow.Caption = ReportNone.txtTitle.Text
        '        frmReportShow.CRViewer1.ReportSource = ReportNone
        '        Set frmReportShow.mReport = ReportNone: frmReportShow.sMode = "0"
        '        frmReportShow.CRViewer1.ViewReport
        '        Screen.MousePointer = vbDefault
        '        frmReportShow.show 1
        '        Exit Sub
        'End If

        'Report.txtDate.SetText "This report covers order done From " & Format(Dt1, "yyyy/MM/dd") & " TO " & Format(Dt2, "yyyy/MM/dd")
        'Report.txtTime.SetText "Between " & Format(Dt3, "hh:mm:ss") & " To " & Format(Dt4, "hh:mm:ss")

        ''Report.VerifyOnEveryPrint = True
        'Report.Database.Tables(1).SetDataSource rs, 3
        'Report.Database.SetDataSource rs, 3
        ''Report.VerifyOnEveryPrint = True
        'frmReportShow.Caption = Report.txtTitle.Text
        'frmReportShow.CRViewer1.ReportSource = Report
        'Set frmReportShow.mReport = Report: frmReportShow.sMode = "0"
        'frmReportShow.CRViewer1.ViewReport
        'Screen.MousePointer = vbDefault
        'frmReportShow.show 1
    End Sub
    Public Sub EmulateSnapShot()
        Dim lQuantity As Decimal
        Dim adoPrimaryRS As ADODB.Recordset

        'Zerorise Stock Quantity...

        System.Windows.Forms.Application.DoEvents()
        cnnDB.Execute("UPDATE Company SET Company.Company_StockTakeDate = now();")
        cnnDB.Execute("DELETE FROM StockTake WHERE (StockTake_WarehouseID = 2)")
        cnnDB.Execute("INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment ) SELECT StockItem.StockItemID, 2 AS warehouse, 0 AS quantity, 0 AS adjustment FROM StockItem;")
        cnnDB.Execute("UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));")
        cnnDB.Execute("DELETE FROM StockTakeDeposit")
        cnnDB.Execute("INSERT INTO StockTakeDeposit ( StockTakeDeposit_WarehouseID, StockTakeDeposit_DepositID, StockTakeDeposit_DepositTypeID, StockTakeDeposit_Quantity, StockTakeDeposit_Adjustment ) SELECT WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity FROM WarehouseDepositItemLnk INNER JOIN DISPLAY_Deposits ON (DISPLAY_Deposits.type = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = DISPLAY_Deposits.DepositID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID = DISPLAY_Deposits.WarehouseID);")
        System.Windows.Forms.Application.DoEvents()
        System.Windows.Forms.Application.DoEvents()

        adoPrimaryRS = getRS("SELECT StockItem.StockItem_Name, StockTake.StockTake_Quantity, StockTake.StockTake_StockItemID, StockTake.StockTake_WarehouseID, StockItem.StockItem_Quantity FROM (StockTake INNER JOIN StockItem ON StockTake.StockTake_StockItemID = StockItem.StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID Where  StockTake.StockTake_WarehouseID = 2  AND StockItem.StockItem_Disabled=False AND StockItem.StockItem_Discontinued=False ORDER BY StockItem.StockItem_Name;")

        Do While adoPrimaryRS.EOF = False
            'lQuantity = 0 - adoPrimaryRS("StockTake_Quantity")
            lQuantity = -1 * adoPrimaryRS.Fields("StockTake_Quantity").Value
            cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN StockTake ON (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) AND (WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockTake.StockTake_StockItemID) SET WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity]+(" & lQuantity & ") WHERE (((StockTake.StockTake_StockItemID)=" & adoPrimaryRS.Fields("StockTake_StockItemID").Value & ") AND ((StockTake.StockTake_WarehouseID)=2));")
            cnnDB.Execute("UPDATE DayEndStockItemLnk INNER JOIN Company ON DayEndStockItemLnk.DayEndStockItemLnk_DayEndID = Company.Company_DayEndID SET DayEndStockItemLnk.DayEndStockItemLnk_QuantityShrink = [DayEndStockItemLnk]![DayEndStockItemLnk_QuantityShrink]-(" & lQuantity & ") WHERE (((DayEndStockItemLnk.DayEndStockItemLnk_StockItemID)=" & adoPrimaryRS.Fields("StockTake_StockItemID").Value & "));")
            adoPrimaryRS.moveNext()
        Loop

        System.Windows.Forms.Application.DoEvents()
        cnnDB.Execute("UPDATE Company SET Company.Company_StockTakeDate = now();")
        cnnDB.Execute("DELETE FROM StockTake WHERE (StockTake_WarehouseID = 2)")
        cnnDB.Execute("INSERT INTO StockTake ( StockTake_StockItemID, StockTake_WarehouseID, StockTake_Quantity, StockTake_Adjustment ) SELECT StockItem.StockItemID, 2 AS warehouse, 0 AS quantity, 0 AS adjustment FROM StockItem;")
        cnnDB.Execute("UPDATE StockTake INNER JOIN WarehouseStockItemLnk ON (StockTake.StockTake_StockItemID = WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID) AND (StockTake.StockTake_WarehouseID = WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID) SET StockTake.StockTake_Quantity = [WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));")
        cnnDB.Execute("DELETE FROM StockTakeDeposit")
        cnnDB.Execute("INSERT INTO StockTakeDeposit ( StockTakeDeposit_WarehouseID, StockTakeDeposit_DepositID, StockTakeDeposit_DepositTypeID, StockTakeDeposit_Quantity, StockTakeDeposit_Adjustment ) SELECT WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity, WarehouseDepositItemLnk.WarehouseDepositItemLnk_Quantity FROM WarehouseDepositItemLnk INNER JOIN DISPLAY_Deposits ON (DISPLAY_Deposits.type = WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositTypeID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_DepositID = DISPLAY_Deposits.DepositID) AND (WarehouseDepositItemLnk.WarehouseDepositItemLnk_WarehouseID = DISPLAY_Deposits.WarehouseID);")
        System.Windows.Forms.Application.DoEvents()
        System.Windows.Forms.Application.DoEvents()

    End Sub

    'changes from jonas for Price change report
    Public Sub report_NewPriceChange()
        Dim rs3 As ADODB.Recordset

        'On Local Error Resume Next
        'Dim Report As New crypricechange
        'Dim rs As ADODB.Recordset
        'Dim rs1 As ADODB.Recordset

        'Set rs = New ADODB.Recordset
        'Set rs1 = New ADODB.Recordset

        On Error Resume Next

        'Set rs = getRS("SELECT * FROM Company")
        'Report.txtCompanyName.SetText rs("Company_Name")

        'Set rsP = getRS("SELECT * FROM NewPriceChanges")
        'fsdss = rs1("OldPrice")

        'Report.Database.Tables(1).SetDataSource rsP, 3
        'Report.Database.SetDataSource rsP, 3

        ''Report.VerifyOnEveryPrint = True
        'frmReportShow.Caption = Report.txtCompanyName.Text

        'frmReportShow.CRViewer1.ReportSource = Report
        'Set frmReportShow.mReport = Report: frmReportShow.sMode = "0"
        'frmReportShow.CRViewer1.ViewReport
        'frmReportShow.show 1


        Dim rs As ADODB.Recordset
        Dim rs1 As ADODB.Recordset
        Dim rs2 As ADODB.Recordset
        Dim sql As String
        'Dim Report As New crypricechange
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("crypricechange.rpt")
        Dim HMyPrice As Decimal
        Dim MyMarkup As String

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rs = getRSreport("SELECT Report.Report_Heading, aCompany.Company_Name FROM aCompany, Report;")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
        Report.SetParameterValue("txtDayEnd", rs("Report_Heading"))
        rs.Close()

        'create table name
        Te_Names = "NewPricechanges"
        'In case the table was not dropped then drop it
        'Set rs = getRS("DROP TABLE " & Te_Names & "")
        cnnDBreport.Execute("DROP TABLE " & Te_Names & "")
        MyFTypess = "PriceChangesID_DayEndStockItemLnk Number,PriceChanges_StockItemName Text(50),OldPrice Currency,NewPrice Currency,SellingPrice Currency,Markup Number"
        cnnDBreport.Execute("CREATE TABLE " & Te_Names & " (" & MyFTypess & ")")

        rs1 = getRSreport("SELECT DayEnd.DayEndID, DayEnd.DayEnd_Date, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem1.StockItem_Name, DayEndStockItemLnk.DayEndStockItemLnk_ListCost, aStockItem1.StockItemID FROM Report INNER JOIN (DayEnd INNER JOIN (DayEndStockItemLnk INNER JOIN aStockItem1 ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem1.StockItemID) ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) ON Report.Report_DayEndEndID = DayEnd.DayEndID WHERE ((StockItem_Disabled=0) AND (StockItem_Discontinued=0)) ORDER BY aStockItem1.StockItemID;")
        If rs1.RecordCount Then
            Do Until rs1.EOF
                rs2 = getRSreport("SELECT DayEnd.DayEndID, DayEnd.DayEnd_Date, DayEndStockItemLnk.DayEndStockItemLnk_StockItemID, aStockItem1.StockItem_Name, DayEndStockItemLnk.DayEndStockItemLnk_ListCost, aStockItem1.StockItemID FROM Report INNER JOIN (DayEnd INNER JOIN (DayEndStockItemLnk INNER JOIN aStockItem1 ON DayEndStockItemLnk.DayEndStockItemLnk_StockItemID = aStockItem1.StockItemID) ON DayEnd.DayEndID = DayEndStockItemLnk.DayEndStockItemLnk_DayEndID) ON Report.Report_DayEndStartID = DayEnd.DayEndID WHERE (((aStockItem1.StockItemID)=" & rs1.Fields("DayEndStockItemLnk_StockItemID").Value & "));")
                If rs2.RecordCount Then
                    If rs1.Fields("DayEndStockItemLnk_ListCost").Value <> rs2.Fields("DayEndStockItemLnk_ListCost").Value Then
                        rs3 = getRSreport("SELECT CatalogueChannelLnk.CatalogueChannelLnk_Price, CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID From CatalogueChannelLnk WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)=" & rs1.Fields("DayEndStockItemLnk_StockItemID").Value & ") AND ((CatalogueChannelLnk.CatalogueChannelLnk_Quantity)=1) AND ((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1));")
                        If rs3.RecordCount Then
                            HMyPrice = rs3("CatalogueChannelLnk_Price").Value
                            MyMarkup = CStr(rs1.Fields("DayEndStockItemLnk_ListCost").Value / rs3("CatalogueChannelLnk_Price").Value * 100)
                            MyMarkup = CStr(100 - CDbl(MyMarkup))
                        Else
                            MyMarkup = CStr(0)
                            HMyPrice = 0
                        End If
                        'insert into Newpricechanges
                        cnnDBreport.Execute("INSERT INTO " & Te_Names & "(PriceChangesID_DayEndStockItemLnk,PriceChanges_StockItemName,OldPrice,NewPrice,SellingPrice,Markup)VALUES(" & rs1.Fields("DayEndStockItemLnk_StockItemID").Value & ",'" & rs1.Fields("StockItem_Name").Value & "', " & rs2.Fields("DayEndStockItemLnk_ListCost").Value & ", " & rs1.Fields("DayEndStockItemLnk_ListCost").Value & "," & HMyPrice & "," & MyMarkup & ")")
                        'delete duplicates
                        'Set rsk = getRS("DELETE * FROM " & Te_Names & " WHERE (NewPricechanges.PriceChangesID_DayEndStockItemLnk =" & rs2("DayEndStockItemLnk_StockItemID") & " and NewPricechanges.OldPrice = " & rs2("DayEndStockItemLnk_ListCost") & " and NewPricechanges.NewPrice = " & rs2("DayEndStockItemLnk_ListCost") & ")")
                    End If
                End If
                rs1.moveNext()
            Loop
        Else
            'MsgBox "There was No Price Changes of Items between " & Me.txtstartdate.Text & " And " & Me.txtenddate.Text, vbInformation, "4POS"
        End If

        rs = getRSreport("SELECT * FROM NewPriceChanges")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
        If rs.BOF Or rs.EOF Then
            ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
            frmReportShow.CRViewer1.ReportSource = ReportNone
            frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If

        Report.Database.Tables(1).SetDataSource(rs)
        'Report.VerifyOnEveryPrint = True
        'frmReportShow.Caption = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        frmReportShow.ShowDialog()
    End Sub
End Module