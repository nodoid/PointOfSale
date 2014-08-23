Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmUpdatePOScriteria
	Inherits System.Windows.Forms.Form
	Const gUpdateWarnin As Short = 512
	Dim gParameters As Integer
	Dim rsBitter As ADODB.Recordset
	Dim gFilter As String
	Dim gRS As ADODB.Recordset
	Dim gFilterSQL As String
	Dim gSection As Short
    Dim gID As Integer
    Public frmType As New List(Of GroupBox)
    Dim cmdType As New List(Of Button)
	Dim sLocalQuery As String
	
	Private Sub loadLanguage()
		
		'frmUpdatePOScriteria = No Code [Selection Criteria for Point Of Sale Update]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmUpdatePOScriteria.Caption = rsLang("LanguageLayoutLnk_Description"): frmUpdatePOScriteria.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label2 = No Code               [You may set the Point Of.......]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label2.Caption = rsLang("LanguageLayoutLnk_Description"): Label2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'frmType(0) = No Code           [Option One (Update POS Changes)]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmType(0).Caption = rsLang("LanguageLayoutLnk_Description"): frmType(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1(0) = No Code            [As you make changes to your.......]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1(0).Caption = rsLang("LanguageLayoutLnk_Description"): COMPONENT(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_Label3_0 = No Code            [Click on the "View Update Changes >>" button to continue.]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _Label3_0.Caption = rsLang("LanguageLayoutLnk_Description"): _Label3_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdBuildChanges = No Code      [View and Update Changes >>]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdBuildChanges.Caption = rsLang("LanguageLayoutLnk_Description"): cmdBuildChanges.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'frmType(1) = No Code           [Update POS by a filter]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmType(1).Caption = rsLang("LanguageLayoutLnk_Description"): frmType(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblHeading = No Code           [Using the "Stock Item Selector"...]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblHeading.Caption = rsLang("LanguageLayoutLnk_Description"): lblHeading.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1006 'Filter|Checked
		If rsLang.RecordCount Then cmdNamespace.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdNamespace.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'cmdBuildFilter = No Code       [View and Update Changes >>]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdBuildFilter.Caption = rsLang("LanguageLayoutLnk_Description"): cmdBuildFilter.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'frmType(2) = No Code           [Option Three (Check Data Integrity)]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmType(2).Caption = rsLang("LanguageLayoutLnk_Description"): frmType(2).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1(1) = No Code            [This option will check all your data.......]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1(1).Caption = rsLang("LanguageLayoutLnk_Description"): Label1(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_Label3_1 = No Code            [Click on the "View and Update Changes >>" button to continue.]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _Label3_1.Caption = rsLang("LanguageLayoutLnk_Description"): _Label3_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdBuildAll = No Code          [View and Update Changes >>]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdBuildAll.Caption = rsLang("LanguageLayoutLnk_Description"): CmdBuildAll.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdType(0) = No Code           [Changes Only]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdType(0).Caption = rsLang("LanguageLayoutLnk_Description"): cmdType(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdType(1) = No Code           [Update by Filter]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdType(1).Caption = rsLang("LanguageLayoutLnk_Description"): cmdType(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdType(2) = No Code           [Update All]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdType(2).Caption = rsLang("LanguageLayoutLnk_Description"): cmdType(2).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmUpdatePOScriteria.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
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
	
	Private Sub cmdBuildAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBuildAll.Click
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		System.Windows.Forms.Application.DoEvents()
		cnnDB.Execute("DELETE FROM systemStockItemPricing;")
		cnnDB.Execute("INSERT INTO systemStockItemPricing ( systemStockItemPricing ) SELECT StockItem.StockItemID FROM StockItem;")
		cnnDB.Execute("UPDATE POSCatalogueChannelLnk INNER JOIN CatalogueChannelLnk ON (POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) SET CatalogueChannelLnk.CatalogueChannelLnk_Price = [POSCatalogueChannelLnk]![POSCatalogueChannelLnk_Price] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_Price)<>[POSCatalogueChannelLnk]![POSCatalogueChannelLnk_Price]));")
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Dim formUpdate As frmUpdateCatalogue
        formUpdate.Show()
        Dim formUpdatePOS As frmUpdatePOS
        If gParameters And gUpdateWarnin = 512 Then
            formUpdatePOS.Show()
        Else
            If frmUpdateWarning.loadItem() Then
                formUpdatePOS.Show()
            End If
        End If
		Me.Close()
		'If frmUpdateWarning.loadItem() Then frmUpdatePOS.show 1, Me
	End Sub
	
	Private Sub cmdBuildChanges_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBuildChanges.Click
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		System.Windows.Forms.Application.DoEvents()
		cnnDB.Execute("DELETE FROM systemStockItemPricing;")
		cnnDB.Execute("INSERT INTO systemStockItemPricing ( systemStockItemPricing ) SELECT tempStockItem.tempStockItemID FROM tempStockItem;")
		cnnDB.Execute("UPDATE POSCatalogueChannelLnk INNER JOIN CatalogueChannelLnk ON (POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) SET CatalogueChannelLnk.CatalogueChannelLnk_Price = [POSCatalogueChannelLnk]![POSCatalogueChannelLnk_Price] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_Price)<>[POSCatalogueChannelLnk]![POSCatalogueChannelLnk_Price]));")
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Dim frmUpdate As frmUpdateCatalogue
        Dim frmPOS As frmUpdatePOS
        frmUpdate.Show()
		
		If gParameters And gUpdateWarnin = 512 Then
            frmPOS.Show()
		Else
            If frmUpdateWarning.loadItem() Then frmPOS.Show()
		End If
		Me.Close()
		'If frmUpdateWarning.loadItem() Then frmUpdatePOS.show 1, Me
	End Sub
	
	Private Sub cmdBuildFilter_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBuildFilter.Click
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		System.Windows.Forms.Application.DoEvents()
		cnnDB.Execute("DELETE FROM systemStockItemPricing;")
		cnnDB.Execute("INSERT INTO systemStockItemPricing ( systemStockItemPricing ) SELECT StockItem.StockItemID From StockItem " & gFilterSQL)
		cnnDB.Execute("UPDATE POSCatalogueChannelLnk INNER JOIN CatalogueChannelLnk ON (POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) SET CatalogueChannelLnk.CatalogueChannelLnk_Price = [POSCatalogueChannelLnk]![POSCatalogueChannelLnk_Price] WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_Price)<>[POSCatalogueChannelLnk]![POSCatalogueChannelLnk_Price]));")
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		'frmUpdateCatalogue.show 1, Me
        Dim frmPOS As frmUpdatePOS
		If gParameters And gUpdateWarnin = 512 Then
            frmPOS.Show()
		Else
            If frmUpdateWarning.loadItem() Then frmPOS.Show()
		End If
		Me.Close()
		'If frmUpdateWarning.loadItem() Then frmUpdatePOS.show 1, Me
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	
	Private Sub cmdNamespace_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNamespace.Click
		frmFilter.loadFilter(gFilter)
		getNamespace()
	End Sub
	
	
    Private Sub cmdType_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim btn As New Button
        btn = DirectCast(eventSender, Button)
        Dim Index As Integer = GetIndexer(btn, cmdType)
        Dim x As Integer
        For x = 0 To frmType.Count
            frmType(x).Visible = False
        Next
        frmType(Index).Visible = True

        If Index = 2 Then
            cmdBuildAll_Click(cmdBuildAll, New System.EventArgs())
            frmUpdatePOS.AutomaticPOSUpdate()
        End If

    End Sub
	Private Sub frmUpdatePOScriteria_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
    Public Sub frmUpdatePOScriteria_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim x As Short
        Dim rs As ADODB.Recordset
        frmType.AddRange(New GroupBox() {_frmType_0, _frmType_1, _frmType_2})
        cmdType.AddRange(New Button() {_cmdType_0, _cmdType_1, _cmdType_2})
        Dim bt As New Button
        For Each bt In cmdType
            AddHandler bt.Click, AddressOf cmdType_Click
        Next
        sLocalQuery = ""
        rsBitter = getRS("SELECT * FROM Company")
        gParameters = CInt(0 & rsBitter.Fields("Company_DayEndBit").Value)

        loadLanguage()

        For x = 0 To frmType.Count
            frmType(x).Top = frmType(0).Top
            frmType(x).Left = frmType(0).Left
            frmType(x).Visible = False
        Next
        rs = getRS("DISPLAY_StockDuplicateCodes")
        If rs.BOF Or rs.EOF Then

            gFilter = "stockitem"
            getNamespace()
        Else
            rs.Close()
            cmdBarcodes_Click()
            rs = getRS("DISPLAY_StockDuplicateCodes")
            If rs.BOF Or rs.EOF Then
                cmdBarcodes_Click()

                gFilter = "stockitem"
                getNamespace()
            Else
                tmrDuplicate.Enabled = True
            End If
        End If

        'deposit query changed by markus for 'The Liq Company' problem - 20 June 2012
        '    If rs.State Then rs.Close
        '    'Set rs = getRS("SELECT Deposit.DepositID, Deposit.Deposit_Name, Deposit.Deposit_ReceiptName, Deposit.Deposit_Key, Deposit.Deposit_Quantity, Deposit.Deposit_UnitPrice1, Deposit.Deposit_CasePrice1, Deposit.Deposit_UnitPrice2, Deposit.Deposit_CasePrice2, Vat.Vat_Amount, Deposit.Deposit_Key FROM Deposit INNER JOIN Vat ON Deposit.Deposit_VatID = Vat.VatID WHERE (((Deposit.Deposit_UnitPrice1)=0) AND ((Deposit.Deposit_Key)='') AND ((Deposit.Deposit_Disabled)<>True)) OR (((Deposit.Deposit_CasePrice1)=0) AND ((Deposit.Deposit_Key)='') AND ((Deposit.Deposit_Disabled)<>True)) OR (((Deposit.Deposit_UnitPrice1)=0) AND ((Deposit.Deposit_Key)Is Null) AND ((Deposit.Deposit_Disabled)<>True)) OR (((Deposit.Deposit_CasePrice1)=0) AND ((Deposit.Deposit_Key)Is Null) AND ((Deposit.Deposit_Disabled)<>True)) ORDER BY Deposit.Deposit_Key;")
        '    Set rs = getRS("SELECT Deposit.DepositID, Deposit.Deposit_Name, Deposit.Deposit_ReceiptName, Deposit.Deposit_Key, Deposit.Deposit_Quantity, Deposit.Deposit_UnitPrice1, Deposit.Deposit_CasePrice1, Deposit.Deposit_UnitPrice2, Deposit.Deposit_CasePrice2, Vat.Vat_Amount, Deposit.Deposit_Key FROM Deposit INNER JOIN Vat ON Deposit.Deposit_VatID = Vat.VatID WHERE ((LEFT((Deposit.Deposit_Name),3)<>'Non') AND ((Deposit.Deposit_Key)='') AND ((Deposit.Deposit_UnitPrice1)=0) AND ((Deposit.Deposit_Disabled)<>True)) OR ((LEFT((Deposit.Deposit_Name),3)<>'Non') AND ((Deposit.Deposit_Key)='') AND ((Deposit.Deposit_CasePrice1)=0) AND ((Deposit.Deposit_Disabled)<>True)) OR ((LEFT((Deposit.Deposit_Name),3)<>'Non') AND ((Deposit.Deposit_Key) Is Null) AND ((Deposit.Deposit_UnitPrice1)=0) AND ((Deposit.Deposit_Disabled)<>True)) OR ((LEFT((Deposit.Deposit_Name),3)<>'Non') AND ((Deposit.Deposit_Key) Is Null) AND ((Deposit.Deposit_CasePrice1)=0) AND ((Deposit.Deposit_Disabled)<>True)) ORDER BY Deposit.Deposit_Key;")
        '    If rs.RecordCount Then
        '        MsgBox "The following Deposit(s) cannot have '0.00' Inclusive Price OR does not have valid 'POS Quick Key'. Please assign a value to the deposit before an update will be allowed."
        '        sLocalQuery = "SELECT * FROM Deposit WHERE (((Deposit.Deposit_UnitPrice1)=0) AND ((Deposit.Deposit_Key)='') AND ((Deposit.Deposit_Disabled)<>True)) OR (((Deposit.Deposit_CasePrice1)=0) AND ((Deposit.Deposit_Key)='') AND ((Deposit.Deposit_Disabled)<>True)) OR (((Deposit.Deposit_UnitPrice1)=0) AND ((Deposit.Deposit_Key)Is Null) AND ((Deposit.Deposit_Disabled)<>True)) OR (((Deposit.Deposit_CasePrice1)=0) AND ((Deposit.Deposit_Key)Is Null) AND ((Deposit.Deposit_Disabled)<>True)) ORDER BY Deposit.Deposit_Key;"
        '        tmrDeposit.Enabled = True
        '        Exit Sub
        '    End If
        If rs.State Then rs.Close()
        rs = getRS("SELECT Deposit.DepositID, Deposit.Deposit_Name, Deposit.Deposit_ReceiptName, Deposit.Deposit_Key, Deposit.Deposit_Quantity, Deposit.Deposit_UnitPrice1, Deposit.Deposit_CasePrice1, Deposit.Deposit_UnitPrice2, Deposit.Deposit_CasePrice2, Vat.Vat_Amount, Deposit.Deposit_Key FROM Deposit INNER JOIN Vat ON Deposit.Deposit_VatID = Vat.VatID WHERE (((Deposit.Deposit_Key)='') AND ((Deposit.Deposit_Disabled)<>True)) OR (((Deposit.Deposit_Key)Is Null) AND ((Deposit.Deposit_Disabled)<>True)) ORDER BY Deposit.Deposit_Key;")
        If rs.RecordCount Then
            MsgBox("The following Deposit(s) does not have valid 'POS Quick Key'. Please assign a value to the deposit before an update will be allowed.")
            sLocalQuery = "SELECT * FROM Deposit WHERE (((Deposit.Deposit_Key)='') AND ((Deposit.Deposit_Disabled)<>True)) OR (((Deposit.Deposit_Key)Is Null) AND ((Deposit.Deposit_Disabled)<>True)) ORDER BY Deposit.Deposit_Key;"
            tmrDeposit.Enabled = True
            Exit Sub
        End If

        If rs.State Then rs.Close()
        rs = getRS("SELECT Deposit.* FROM Deposit INNER JOIN [Set] ON Deposit.DepositID = Set.Set_DepositID WHERE (((Deposit.Deposit_Disabled)=True) AND ((Set.Set_Disabled)=False));")
        If rs.RecordCount Then
            MsgBox("The following Deposit(s) are disabled but currently in use in a Stock Set(s). Please remove the deposit from the Stock Set(s) before an update will be allowed.")
            sLocalQuery = "SELECT Deposit.* FROM Deposit INNER JOIN [Set] ON Deposit.DepositID = Set.Set_DepositID WHERE (((Deposit.Deposit_Disabled)=True) AND ((Set.Set_Disabled)=False));"
            tmrDeposit.Enabled = True
            Exit Sub
        End If


        If blMEndUpdatePOS = True Then
            tmrMEndUpdatePOS.Enabled = True
            'cmdType_Click (2)
        End If

    End Sub
	
	Private Sub tmrDeposit_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrDeposit.Tick
		If sLocalQuery = "" Then
			tmrDeposit.Enabled = False
		Else
			tmrDeposit.Enabled = False
			report_Deposits_Query(sLocalQuery)
			Me.Close()
		End If
	End Sub
	
	
	Private Sub frmUpdatePOScriteria_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'    gRS.Close
	End Sub
	
	
	Private Sub doSearch()
        Dim DataList1 As ListControl
        Dim txtSearch As New TextBox
		Exit Sub
		Dim sql As String
		Dim lString As String
		lString = Trim(txtSearch.Text)
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		lString = Replace(lString, "  ", " ")
		
		
		'UPGRADE_WARNING: Couldn't resolve default property of object txtSearch.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
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
		gRS = getRS("SELECT DISTINCT StockItemID, StockItem_Name FROM StockItem " & lString & " ORDER BY StockItem_Name")
		'Display the list of Titles in the DataCombo
        DataList1.DataBindings.Add(gRS)
        'DataList1.listField = "StockItem_Name"

		'Bind the DataCombo to the ADO Recordset
		DataList1.DataSource = gRS
        'DataList1.boundColumn = "StockItemID"
		
	End Sub
	
	Private Sub tmrDuplicate_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrDuplicate.Tick
		report_StockItemDuplicateCodes()
		Me.Close()
	End Sub
	
    Private Function doCheckSum(ByRef Value As String) As Short
        Dim lAmount As Short
        Dim code As String
        Dim i As Short
       Value = Replace(Value, " ", "")
         Value = Replace(Value, " ", "")
        Value = Replace(Value, " ", "")
        Value = Replace(Value, " ", "")
        Value = Replace(Value, " ", "")
        Value = Replace(Value, " ", "")
        Value = Replace(Value, " ", "")
        If IsNumeric(Value) Then
            lAmount = 0
            For i = 0 To Len(Value) - 1
                code = VB.Left(Value, i)
                code = VB.Right(code, 1)
                If i Mod 2 Then
                    lAmount = lAmount + CShort(code)
                Else
                    lAmount = lAmount + CShort(code) * 3
                End If
            Next
            lAmount = 10 - (lAmount Mod 10)
            If lAmount = 10 Then lAmount = 0
            doCheckSum = lAmount = CShort(VB.Right(Value, 1))
        Else
            doCheckSum = False
        End If
    End Function
	
	
	Private Sub cmdBarcodes_Click()
        Dim x As Integer
		Dim rs As ADODB.Recordset
		Dim lCode As String
		Dim lID, lQuantity As String
		Dim changeCode As Boolean
		Exit Sub
		'    If id = 0 Then
		'        cnnDB.Execute "UPDATE Catalogue SET Catalogue.Catalogue_Barcode = ""0"" WHERE (((IsNumeric([Catalogue_Barcode]))<>0));"
		cnnDB.Execute("UPDATE Catalogue INNER JOIN StockItem ON Catalogue.Catalogue_StockItemID = StockItem.StockItemID SET Catalogue.Catalogue_Barcode = '0' WHERE (((Left([Catalogue_Barcode],3))='888') AND ((StockItem.StockItem_BrandItemID)>0));")
		
		For x = 1 To 15
			cnnDB.Execute("UPDATE Catalogue SET Catalogue.Catalogue_Barcode = Mid([Catalogue_Barcode],2,999) WHERE (((Left([Catalogue_Barcode],1))=""0""));")
		Next x
		rs = getRS("SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, Catalogue.Catalogue_Barcode From Catalogue;")
		'        Set rs = getRS("SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, Catalogue.Catalogue_Barcode From Catalogue WHERE Catalogue.Catalogue_Barcode = '0';")
		'    Else
		'        Set rs = getRS("SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, Catalogue.Catalogue_Barcode From Catalogue WHERE (((Catalogue.Catalogue_StockItemID)=" & id & "));")
		'    End If
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
					lCode = "888" & VB.Right(New String("0", 9) & lCode & "0", 9)
					lCode = addCheckSum(lCode)
					cnnDB.Execute("UPDATE Catalogue SET Catalogue_Barcode = '" & Replace(lCode, "'", "''") & "' WHERE Catalogue_StockItemID = " & lID & " AND Catalogue_Quantity = " & lQuantity)
				End If
				rs.moveNext()
			Loop 
		End If
	End Sub
	
	Private Sub tmrMEndUpdatePOS_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrMEndUpdatePOS.Tick
		If blMEndUpdatePOS = True Then
			tmrMEndUpdatePOS.Enabled = False
			If blChangeOnlyUpdatePOS = True Then
				cmdBuildChanges_Click(cmdBuildChanges, New System.EventArgs())
			Else
				cmdType_Click(cmdType.Item(2), New System.EventArgs())
			End If
		End If
	End Sub
End Class