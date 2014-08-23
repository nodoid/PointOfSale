Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmOrder
	Inherits System.Windows.Forms.Form
	Public WithEvents adoPrimaryRS As ADODB.Recordset
	Dim gFilter As String
	Dim gRS As ADODB.Recordset
	Dim gFilterSQL As String
	Dim gMode As Short
    Dim cmdInformation As New List(Of Button)
    Dim frmMode As New List(Of GroupBox)
    Dim lblLabels As New List(Of Label)
    Dim lblData As New List(Of Label)
	Const mdSupplier As Short = 0
	Const mdProcess As Short = 1
	
	Private Sub loadLanguage()

		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1556 'Create / Amend an Order|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1557 'Order Information Report|Checked
		If rsLang.RecordCount Then cmdInformation(0).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdInformation(0).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'cmdInformation(1) = No Code    [Order Information Report (*)]
		'Note" Closest Match DB Entry 1557, but missing the "(*)" chars
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdInformation(1).Caption = rsLang("LanguageLayoutLnk_Description"): cmdInformation(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1559 'Select a Supplier to transact with|Checked
		If rsLang.RecordCount Then frmMode(1).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : frmMode(1).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1010 'General|Checked
        If rsLang.RecordCount Then _lbl_1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1442 'Supplier Name|Checked
        If rsLang.RecordCount Then _lblLabels_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1288 'Telephone|Checked
        If rsLang.RecordCount Then _lblLabels_8.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_8.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1289 'Fax|Checked
        If rsLang.RecordCount Then _lblLabels_9.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_9.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1291 'Physical Address|Checked
        If rsLang.RecordCount Then _lblLabels_6.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_6.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1292 'Postal Address|Checked
        If rsLang.RecordCount Then _lblLabels_7.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_7.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1454 'Ordering Details|Checked
        If rsLang.RecordCount Then _lbl_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'WARNING: DB Entry 1455 has a spelling mistake!
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1455 'Representative Name|Checked
		If rsLang.RecordCount Then lblLabels(38).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lblLabels(38).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1456 'Representative Number|Checked
		If rsLang.RecordCount Then lblLabels(37).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lblLabels(37).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1457 'Account Number|Checked
		If rsLang.RecordCount Then lblLabels(36).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : lblLabels(36).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1576 'Edit Current Order|Checked
		If rsLang.RecordCount Then cmdEdit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdEdit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1577 'Create a Blank Order|Checked
		If rsLang.RecordCount Then cmdBlank.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdBlank.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1578 'Create Recommended Order|Checked
		If rsLang.RecordCount Then cmdAuto.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdAuto.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdBack.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdBack.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1005 'Next|Checked
		If rsLang.RecordCount Then cmdNext.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdNext.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
        'UPGRADE_ISSUE: Form property frmOrder.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub cmdEdit_Enabled()
		Dim rs As ADODB.Recordset
		rs = getRS("SELECT * FROM TempOrder WHERE TempOrder_SupplierID = " & adoPrimaryRS.Fields("SupplierID").Value)
		If rs.BOF Or rs.EOF Then
			cmdEdit.Enabled = False
		Else
			cmdEdit.Enabled = True
		End If
	End Sub
    Private Sub doMode(ByRef mode As Short)
        Dim oLabel As System.Windows.Forms.Label
        Dim x As Short
        gMode = mode
        For x = 0 To frmMode.Count - 1
            frmMode(x).Visible = False
        Next
        frmMode(gMode).Left = frmMode(0).Left
        frmMode(gMode).Top = frmMode(0).Top
        frmMode(gMode).Visible = True
        System.Windows.Forms.Application.DoEvents()

        Select Case gMode
            Case mdSupplier
                doSearch()
                If Me.Visible Then txtSearch.Focus()
                cmdBack.Text = "E&xit"
                cmdNext.Text = "&Next"
            Case mdProcess
                adoPrimaryRS = getRS("select SupplierID,Supplier_Name,Supplier_PostalAddress,Supplier_PhysicalAddress,Supplier_Telephone,Supplier_Facimile,Supplier_RepresentativeName,Supplier_RepresentativeNumber,Supplier_ShippingCode,Supplier_OrderAttentionLine,Supplier_Ullage,Supplier_discountCOD,Supplier_discount15days,Supplier_discount30days,Supplier_discount60days,Supplier_discount90days,Supplier_discount120days,Supplier_discountSmartCard,Supplier_discountDefault,Supplier_Current,Supplier_30Days,Supplier_60Days,Supplier_90Days,Supplier_120Days from Supplier WHERE SupplierID = " & DataList1.BoundText)
                For Each oLabel In Me.lblData
                    oLabel.DataBindings.Add(adoPrimaryRS)
                Next oLabel
                cmdEdit_Enabled()

                cmdBack.Text = "&Back"
                cmdNext.Text = "E&xit"
        End Select
    End Sub
	
	
	Private Sub cmdExit_Click()
		Me.Close()
	End Sub
	
	
	Private Sub cmdAuto_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAuto.Click
		cnnDB.Execute("DELETE tempOrderGenerate.* From tempOrderGenerate WHERE (((tempOrderGenerate.tempGenerate_SupplierID)=" & adoPrimaryRS.Fields("SupplierID").Value & "));")
		cnnDB.Execute("INSERT INTO tempOrderGenerate ( tempGenerate_StockItemID, tempGenerate_SupplierID, tempGenerate_Quantity, tempGenerate_OnOrder, tempGenerate_Total ) SELECT StockItem.StockItemID, StockItem.StockItem_SupplierID, 0, 0, 0 From StockItem WHERE (((StockItem.StockItem_SupplierID)=" & adoPrimaryRS.Fields("SupplierID").Value & ") AND ((StockItem.StockItem_Discontinued)=0));")
		cnnDB.Execute("UPDATE WarehouseStockItemLnk INNER JOIN tempOrderGenerate ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = tempOrderGenerate.tempGenerate_StockItemID SET tempOrderGenerate.tempGenerate_Quantity = [tempOrderGenerate]![tempGenerate_Quantity]+[WarehouseStockItemLnk]![WarehouseStockItemLnk_Quantity] WHERE (((tempOrderGenerate.tempGenerate_SupplierID)=" & adoPrimaryRS.Fields("SupplierID").Value & ") AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity)>0) AND ((WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=1 Or (WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID)=2));")
		cnnDB.Execute("UPDATE ((PurchaseOrderItem INNER JOIN tempOrderGenerate ON PurchaseOrderItem.PurchaseOrderItem_StockItemID = tempOrderGenerate.tempGenerate_StockItemID) INNER JOIN PurchaseOrder ON (PurchaseOrderItem.PurchaseOrderItem_PurchaseOrderID = PurchaseOrder.PurchaseOrderID) AND (tempOrderGenerate.tempGenerate_SupplierID = PurchaseOrder.PurchaseOrder_SupplierID)) INNER JOIN PurchaseOrderStatus ON PurchaseOrder.PurchaseOrder_PurchaseOrderStatusID = PurchaseOrderStatus.PurchaseOrderStatusID SET tempOrderGenerate.tempGenerate_OnOrder = [tempGenerate_OnOrder]+([PurchaseOrderItem_Quantity]-[PurchaseOrderItem_QuantityDelivered])*[PurchaseOrderItem]![PurchaseOrderItem_PackSize] WHERE (((tempOrderGenerate.tempGenerate_SupplierID)=" & adoPrimaryRS.Fields("SupplierID").Value & ") AND ((PurchaseOrderStatus.PurchaseOrderStatus_Complete)=0));")
		cnnDB.Execute("UPDATE Company, tempOrderGenerate SET tempOrderGenerate.tempGenerate_OnOrder = 0 WHERE (((tempOrderGenerate.tempGenerate_SupplierID)=" & adoPrimaryRS.Fields("SupplierID").Value & "));")
		
		cnnDB.Execute("UPDATE tempOrderGenerate INNER JOIN StockItem ON (StockItem.StockItem_SupplierID = tempOrderGenerate.tempGenerate_SupplierID) AND (tempOrderGenerate.tempGenerate_StockItemID = StockItem.StockItemID) SET tempOrderGenerate.tempGenerate_Total = [StockItem_MinimumStock]-[tempGenerate_Quantity]-[tempGenerate_OnOrder] WHERE (((tempOrderGenerate.tempGenerate_SupplierID)=" & adoPrimaryRS.Fields("SupplierID").Value & "));")
		
		cnnDB.Execute("DELETE tempOrderGenerate.* From tempOrderGenerate WHERE (((tempOrderGenerate.tempGenerate_SupplierID)=" & adoPrimaryRS.Fields("SupplierID").Value & ") AND ((tempOrderGenerate.tempGenerate_Total)<1));")
		
		cnnDB.Execute("DELETE FROM TempOrderItem WHERE TempOrderItem_SupplierID = " & adoPrimaryRS.Fields("SupplierID").Value)
		cnnDB.Execute("DELETE FROM TempOrder WHERE  TempOrder_SupplierID = " & adoPrimaryRS.Fields("SupplierID").Value)
		
        cnnDB.Execute("INSERT INTO TempOrder ( TempOrder_SupplierID, TempOrder_DayEndID, TempOrder_DateCreated, TempOrder_Reference, TempOrder_AttentionLine ) SELECT Supplier.SupplierID, Company.Company_DayEndID, Now(), '" & Format(Now, "dd mmm"", ""yyyy") & "', Supplier.Supplier_OrderAttentionLine From Supplier, Company WHERE (((Supplier.SupplierID)=" & adoPrimaryRS.Fields("SupplierID").Value & "));")
		
		'cnnDB.Execute "INSERT INTO TempOrderItem ( TempOrderItem_SupplierID, TempOrderItem_StockItemID, TempOrderItem_PackSize, TempOrderItem_QuantityRequired, TempOrderItem_Quantity ) SELECT tempOrderGenerate.tempGenerate_SupplierID, tempOrderGenerate.tempGenerate_StockItemID, 1 AS Expr1, tempOrderGenerate.tempGenerate_Total, 0 AS Expr2 From tempOrderGenerate WHERE (((tempOrderGenerate.tempGenerate_SupplierID)=" & adoPrimaryRS("SupplierID") & "));"
		cnnDB.Execute("INSERT INTO TempOrderItem ( TempOrderItem_SupplierID, TempOrderItem_StockItemID, TempOrderItem_PackSize, TempOrderItem_QuantityRequired, TempOrderItem_Quantity, TempOrderItem_ContentCost ) SELECT tempOrderGenerate.tempGenerate_SupplierID, tempOrderGenerate.tempGenerate_StockItemID, 1 AS Expr1, tempOrderGenerate.tempGenerate_Total, 0 AS Expr2, StockItem.StockItem_ListCost FROM tempOrderGenerate INNER JOIN StockItem ON tempOrderGenerate.tempGenerate_StockItemID = StockItem.StockItemID WHERE (((tempOrderGenerate.tempGenerate_SupplierID)=" & adoPrimaryRS.Fields("SupplierID").Value & "));")
		cnnDB.Execute("DELETE TempOrderItem.* FROM TempOrderItem INNER JOIN StockItem ON TempOrderItem.TempOrderItem_StockItemID = StockItem.StockItemID WHERE (((TempOrderItem.TempOrderItem_SupplierID)=" & adoPrimaryRS.Fields("SupplierID").Value & ") AND ((StockItem.StockItem_OrderQuantity)=0)) OR (((TempOrderItem.TempOrderItem_SupplierID)=" & adoPrimaryRS.Fields("SupplierID").Value & ") AND ((StockItem.StockItem_OrderRounding)=0));")
		
		cnnDB.Execute("UPDATE TempOrderItem INNER JOIN StockItem ON TempOrderItem.TempOrderItem_StockItemID = StockItem.StockItemID SET TempOrderItem.TempOrderItem_QuantityRequired = CInt([TempOrderItem_QuantityRequired]/([StockItem_OrderQuantity]*[StockItem_OrderRounding])+0.49)*[StockItem_OrderQuantity]*[StockItem_OrderRounding] WHERE (((TempOrderItem.TempOrderItem_SupplierID)=" & adoPrimaryRS.Fields("SupplierID").Value & "));")
		cnnDB.Execute("UPDATE TempOrderItem INNER JOIN StockItem ON TempOrderItem.TempOrderItem_StockItemID = StockItem.StockItemID SET TempOrderItem.TempOrderItem_Quantity = CInt(([TempOrderItem_QuantityRequired]+([StockItem_OrderQuantity]-1)/2)/[StockItem_OrderQuantity]), TempOrderItem.TempOrderItem_PackSize = [StockItem]![StockItem_OrderQuantity] WHERE (((TempOrderItem.TempOrderItem_SupplierID)=" & adoPrimaryRS.Fields("SupplierID").Value & "));")
        Dim form As New frmOrderItem
        form.Show()
		If Me.Visible Then
			cmdEdit_Enabled()
		Else
			Me.Close()
		End If
		
	End Sub
	
	Private Sub cmdBack_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBack.Click
		Select Case gMode
			Case mdSupplier
				Me.Close()
			Case mdProcess
				doMode(mdSupplier)
		End Select
	End Sub
	
	Private Sub cmdBlank_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBlank.Click
		cnnDB.Execute("DELETE FROM TempOrderItem WHERE TempOrderItem_SupplierID = " & DataList1.BoundText)
		cnnDB.Execute("DELETE FROM TempOrder WHERE  TempOrder_SupplierID = " & DataList1.BoundText)
		
        cnnDB.Execute("INSERT INTO TempOrder ( TempOrder_SupplierID, TempOrder_DayEndID, TempOrder_DateCreated, TempOrder_Reference, TempOrder_AttentionLine ) SELECT Supplier.SupplierID, Company.Company_DayEndID, Now(), '" & Format(Now, "dd mmm"", ""yyyy") & "', Supplier.Supplier_OrderAttentionLine From Supplier, Company WHERE (((Supplier.SupplierID)=" & DataList1.BoundText & "));")
        Dim form2 As New frmOrderItem
        form2.Show()
		If Me.Visible Then
			cmdEdit_Enabled()
		Else
			Me.Close()
		End If
		
	End Sub
	
	Private Sub cmdEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEdit.Click
        Dim form As New frmOrderItem
        form.Show()
        If Me.Visible Then
			cmdEdit_Enabled()
		Else
			Me.Close()
		End If
	End Sub
	
	Private Sub InformationReport(ByRef ltype As Boolean)
        Dim sql As String
		Dim rs As ADODB.Recordset
		Dim lDays As Short
		Dim RSitem As ADODB.Recordset
        'Dim Report As New crySupplierOrderInformation
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("crySupplierOrderInformation.rpt")
		If Me.DataList1.BoundText = "" Then Exit Sub
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		lDays = 10
		cnnDB.Execute("UPDATE StockitemHistory SET StockitemHistory.StockitemHistory_Value = 0;")
		cnnDB.Execute("UPDATE StockitemHistory SET StockitemHistory.StockitemHistory_Value = [StockitemHistory]![StockitemHistory_Day11]+[StockitemHistory]![StockitemHistory_Day2]+[StockitemHistory]![StockitemHistory_Day3]+[StockitemHistory]![StockitemHistory_Day4]+[StockitemHistory]![StockitemHistory_Day5]+[StockitemHistory]![StockitemHistory_Day6]+[StockitemHistory]![StockitemHistory_Day7]+[StockitemHistory]![StockitemHistory_Day8]+[StockitemHistory]![StockitemHistory_Day9]+[StockitemHistory]![StockitemHistory_Day10];")
		
		cnnDB.Execute("UPDATE Company, StockBreakTransaction INNER JOIN StockitemHistory ON StockBreakTransaction.StockBreakTransaction_ParentID = StockitemHistory.StockitemHistory_StockItemID SET StockitemHistory.StockitemHistory_Value = [StockitemHistory_Value]+[StockBreakTransaction_MoveQuantity] WHERE ((([Company_DayEndID]-[StockBreakTransaction_DayEndID]+1)<=" & lDays & "));")
		cnnDB.Execute("UPDATE Company, StockBreakTransaction INNER JOIN StockitemHistory ON StockBreakTransaction.StockBreakTransaction_ChildID = StockitemHistory.StockitemHistory_StockItemID SET StockitemHistory.StockitemHistory_Value = [StockitemHistory_Value]-([StockBreakTransaction_MoveQuantity]*[StockBreakTransaction_Quantity]) WHERE ((([Company_DayEndID]-[StockBreakTransaction_DayEndID]+1)<=" & lDays & "));")
		rs = getRS("SELECT * FROM Company")
		Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
		rs.Close()
		If ltype Then
			sql = "SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockItem.StockItem_SupplierID, StockitemHistory.StockitemHistory_Value, StockItem.StockItem_Name, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, StockItem.StockItem_OrderQuantity, StockItem.StockItem_OrderRounding, WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity FROM WarehouseStockItemLnk INNER JOIN (StockitemHistory INNER JOIN StockItem ON StockitemHistory.StockitemHistory_StockItemID = StockItem.StockItemID) ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID Where WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID = 2 And StockItem.StockItem_SupplierID = " & Me.DataList1.BoundText & " AND StockItem.StockItem_Discontinued=0  And (WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity <= [StockitemHistory]![StockitemHistory_Value]) ORDER BY StockItem.StockItem_Name;"
		Else
			sql = "SELECT WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID, WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID, StockItem.StockItem_SupplierID, StockitemHistory.StockitemHistory_Value, StockItem.StockItem_Name, StockItem.StockItem_ListCost, StockItem.StockItem_Quantity, StockItem.StockItem_OrderQuantity, StockItem.StockItem_OrderRounding, WarehouseStockItemLnk.WarehouseStockItemLnk_Quantity FROM WarehouseStockItemLnk INNER JOIN (StockitemHistory INNER JOIN StockItem ON StockitemHistory.StockitemHistory_StockItemID = StockItem.StockItemID) ON WarehouseStockItemLnk.WarehouseStockItemLnk_StockItemID = StockItem.StockItemID Where WarehouseStockItemLnk.WarehouseStockItemLnk_WarehouseID = 2 And StockItem.StockItem_SupplierID = " & Me.DataList1.BoundText & " AND StockItem.StockItem_Discontinued=0 ORDER BY StockItem.StockItem_Name;"
		End If
		RSitem = getRS(sql)
        'ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
		If RSitem.BOF Or RSitem.EOF Then
            ReportNone.SetParameterValue("txtCompanyName.", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
			frmReportShow.CRViewer1.ReportSource = ReportNone
			frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
            frmReportShow.CRViewer1.Refresh()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            frmReportShow.ShowDialog()
            Exit Sub
        End If
        rs = getRS("SELECT * From Supplier WHERE SupplierID=" & Me.DataList1.BoundText)
        Report.Database.Tables(1).SetDataSource(RSitem)
        Report.Database.Tables(2).SetDataSource(rs)
        'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
        frmReportShow.CRViewer1.ReportSource = Report
        frmReportShow.mReport = Report : frmReportShow.sMode = "0"
        frmReportShow.CRViewer1.Refresh()
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		frmReportShow.ShowDialog()
		
	End Sub
	
	
    Private Sub cmdInformation_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'Dim Index As Short = cmdInformation.GetIndex(eventSender)
        Dim Index As Integer
        Dim n As New Button
        n = DirectCast(eventSender, Button)
        Index = GetIndexer(n, cmdInformation)
        InformationReport(CBool(Index))
    End Sub
	
	Private Sub cmdNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNext.Click
		Select Case gMode
			Case mdSupplier
				If DataList1.BoundText <> "" Then
					doMode(mdProcess)
				End If
			Case mdProcess
				Me.Close()
		End Select
	End Sub
	
    Private Sub DataList1_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As KeyEventArgs) Handles DataList1.DoubleClick
        cmdNext_Click(cmdNext, New System.EventArgs())
    End Sub
	
    Private Sub DataList1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles DataList1.KeyPress
        Select Case eventArgs.KeyChar
            Case ChrW(13)
                DataList1_DblClick(DataList1, New System.EventArgs())
                eventArgs.KeyChar = ChrW(0)
            Case ChrW(27)
                eventArgs.KeyChar = ChrW(0)
                cmdExit_Click()
        End Select

    End Sub
	
	Private Sub frmOrder_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 27 Then
			KeyAscii = 0
			cmdBack_Click(cmdBack, New System.EventArgs())
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub frmOrder_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        cmdInformation.AddRange(New Button() {_cmdInformation_0, _cmdInformation_1})
        frmMode.AddRange(New GroupBox() {_frmMode_0, _frmMode_1})
        lblLabels.AddRange(New Label() {_lblLabels_2, _lblLabels_36, _lblLabels_37, _
                                       _lblLabels_38, _lblLabels_6, _lblLabels_7, _
                                       _lblLabels_8, _lblLabels_9})
        lblData.AddRange(New Label() {_lblData_0, _lblData_1, _lblData_2, _
                                     _lblData_3, _lblData_4, _lblData_5, _
                                     _lblData_6, _lblData_7})
        Dim bt As New Button
        For Each bt In cmdInformation
            AddHandler bt.Click, AddressOf cmdInformation_Click
        Next
        loadLanguage()
		doMode(mdSupplier)
	End Sub
	
	Private Sub frmOrder_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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
			lString = "WHERE (Supplier_Name LIKE '%" & Replace(lString, " ", "%' AND Supplier_Name LIKE '%") & "%')"
		End If
		If lString = "" Then
			lString = " WHERE Supplier_Disabled = 0 "
		Else
			lString = lString & " AND Supplier_Disabled = 0 "
		End If
		gRS = getRS("SELECT DISTINCT SupplierID, Supplier_Name FROM Supplier " & lString & " ORDER BY Supplier_Name")
		'Display the list of Titles in the DataCombo
        DataList1.DataSource = gRS
        DataList1.Columns(0).DataPropertyName = "Supplier_Name"
		
		
		'Bind the DataCombo to the ADO Recordset
		'UPGRADE_ISSUE: VBControlExtender property DataList1.DataSource is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
		DataList1.DataSource = gRS
        DataList1.Columns(0).DataPropertyName = "SupplierID"
		
	End Sub
End Class