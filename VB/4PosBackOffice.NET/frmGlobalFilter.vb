Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmGlobalFilter
	Inherits System.Windows.Forms.Form
	Dim gID As Integer
	Dim gFilter As String
	Dim gFilterSQL As String
	
	Dim gSection As Short
	Dim gRS As ADODB.Recordset
	
	Dim gSect As Integer
	Dim g_UpdateID As Integer
	Dim g_SectString As String
	
	'Update Sequence...
	Dim gAll As Boolean
	Dim gLoad As Boolean
	Dim c_Scale As Boolean
	Dim c_Barcode As Boolean
	Dim c_cmbUpPrint As Boolean
	Dim c_PosOveride As Boolean
	Dim c_NonWeighted As Boolean
	Dim c_chkDisabled As Boolean
	Dim c_chkDisconti As Boolean
	Dim c_cmbUpPricing As Boolean
	Dim c_cmbSupplier As Boolean
	Dim c_AllowFraction As Boolean
	Dim c_SerialTracing As Boolean
	Dim c_ReportGroups As Boolean
	Dim c_UndoPosOveride As Boolean

    Dim OprBarcode As New List(Of RadioButton)

	Private Sub loadLanguage()

		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2431 'Global Update|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2432 'Global Cost|Checked
		If rsLang.RecordCount Then Command1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Command1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1006 'Filter|Checked
		If rsLang.RecordCount Then Frame1.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Frame1.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lblHeading = No Code   [Using the "Stock Item Selector".....]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblHeading.Caption = rsLang("LanguageLayoutLnk_Description"): lblHeading.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1006 'Filter|Checked
		If rsLang.RecordCount Then Command3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Command3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2499 'Field(s) to Update|Checked
		If rsLang.RecordCount Then Frame2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Frame2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1032 'This is a scale product|Checked
		If rsLang.RecordCount Then chkScale.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : chkScale.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1033 'This is a scale item non-weight|Checked
		If rsLang.RecordCount Then chkNonWeigted.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : chkNonWeigted.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1034 'Allow fractions|Checked
		If rsLang.RecordCount Then chkAllowFractions.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : chkAllowFractions.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2453 'POS Price Override (SQ)|Checked
		If rsLang.RecordCount Then chkPosOveride.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : chkPosOveride.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1037 'Serial Tracking|Checked
		If rsLang.RecordCount Then chkSerialTracking.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : chkSerialTracking.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'NOTE: BD Entry 2455 needs a "&&" for correct display!
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2455 'Shelf & Barcode Printing|
		If rsLang.RecordCount Then Label4.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label4.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2456 'Shelf|Checked
		If rsLang.RecordCount Then OprBarcode(0).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : OprBarcode(0).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1838 'Barcode|Checked
		If rsLang.RecordCount Then OprBarcode(1).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : OprBarcode(1).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2458 'None|Checked
		If rsLang.RecordCount Then OprBarcode(2).Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : OprBarcode(2).RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2459 'New Supplier|Checked
		If rsLang.RecordCount Then Label6.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label6.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2460 'New Pricing group|Checked
		If rsLang.RecordCount Then Label5.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label5.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2461 'New Printing Location|Checked
		If rsLang.RecordCount Then Label3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Label3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'Label1 = No Code       [Report Groups]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2463 'Disabled|Checked
		If rsLang.RecordCount Then chkDisable.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : chkDisable.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2464 'Update|Checked
		If rsLang.RecordCount Then cmdUpdate.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdUpdate.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2465 'Discontinued|Checked
		If rsLang.RecordCount Then chkDiscontinued.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : chkDiscontinued.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2466 'Undo changes|Checked
		If rsLang.RecordCount Then Frame3.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Frame3.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2467 'Undo POS Price Overide|Checked
		If rsLang.RecordCount Then chkUndoPosOveride.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : chkUndoPosOveride.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2468 'Undo Update|Checked
		If rsLang.RecordCount Then cmdundo.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdundo.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmGlobalFilter.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value

	End Sub
	
    Private Sub chkAllowFractions_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkAllowFractions.CheckStateChanged
        If chkAllowFractions.CheckState = 1 Then c_AllowFraction = True
    End Sub
    Private Sub chkNonWeigted_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkNonWeigted.CheckStateChanged
        If chkNonWeigted.CheckState = 1 Then c_NonWeighted = True
    End Sub
    Private Sub chkPosOveride_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkPosOveride.CheckStateChanged
        If chkPosOveride.CheckState = 1 Then c_PosOveride = True
    End Sub
    Private Sub chkUndoPosOveride_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkUndoPosOveride.CheckStateChanged
        If chkUndoPosOveride.CheckState = 1 Then c_UndoPosOveride = True
    End Sub
    Private Sub chkScale_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkScale.CheckStateChanged
        If chkScale.CheckState = 1 Then c_Scale = True
    End Sub
    Private Sub chkSerialTracking_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkSerialTracking.CheckStateChanged
        If chkSerialTracking.CheckState = 1 Then c_SerialTracing = True
    End Sub

    Private Sub cmbReportGroups_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbReportGroups.CellValueChanged
        If cmbReportGroups.BoundText <> "" Then c_ReportGroups = True
    End Sub

    Private Sub cmbUpPricing_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbUpPricing.CellValueChanged
        If cmbUpPricing.BoundText <> "" Then c_cmbUpPricing = True

    End Sub

    Private Sub cmbUpPrinting_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbUpPrinting.CellValueChanged
        If cmbUpPrinting.Text <> "" Then c_cmbUpPrint = True
    End Sub

    Private Sub cmdUndo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUndo.Click
        If c_UndoPosOveride = True Then

            cnnDB.Execute("Delete StockitemOverwrite.* From StockitemOverwrite ")

        Else : MsgBox("Check the Undo POS Price Overide ", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Global Update")
            Exit Sub
        End If

        MsgBox("Update Completed Succesfully", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Global Update")

    End Sub

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
        Dim stString As String
        Dim rj As ADODB.Recordset

        If c_Scale = True Then cnnDB.Execute("UPDATE StockItem INNER JOIN gGlobalUpdate ON StockItem.StockItemID = gGlobalUpdate.gStockItemID SET StockItem_VariablePrice = " & Me.chkScale.CheckState & ";")

        If c_NonWeighted = True Then cnnDB.Execute("UPDATE StockItem INNER JOIN gGlobalUpdate ON StockItem.StockItemID = gGlobalUpdate.gStockItemID SET StockItem_NonWeighted = " & Me.chkNonWeigted.CheckState & ";")

        If c_AllowFraction = True Then cnnDB.Execute("UPDATE StockItem INNER JOIN gGlobalUpdate ON StockItem.StockItemID = gGlobalUpdate.gStockItemID SET StockItem_Fractions = " & Me.chkAllowFractions.CheckState & ";")

        If c_SerialTracing = True Then cnnDB.Execute("UPDATE StockItem INNER JOIN gGlobalUpdate ON StockItem.StockItemID = gGlobalUpdate.gStockItemID SET StockItem_SerialTracker = " & Me.chkSerialTracking.CheckState & ";")

        If c_ReportGroups = True Then cnnDB.Execute("UPDATE StockItem INNER JOIN gGlobalUpdate ON StockItem.StockItemID = gGlobalUpdate.gStockItemID SET StockItem_ReportID = " & Val(Me.cmbReportGroups.BoundText) & ";")

        If c_cmbUpPrint = True Then
            cnnDB.Execute("UPDATE StockItem INNER JOIN gGlobalUpdate ON StockItem.StockItemID = gGlobalUpdate.gStockItemID SET StockItem_PrintLocationID = " & Me.cmbUpPrinting.BoundText & ";")
            cmbUpPrinting.BoundText = ""
        End If

        If c_cmbUpPricing = True Then
            cnnDB.Execute("UPDATE StockItem INNER JOIN gGlobalUpdate ON StockItem.StockItemID = gGlobalUpdate.gStockItemID SET StockItem_PricingGroupID = " & Val(Me.cmbUpPricing.BoundText) & ";")
            cmbUpPricing.BoundText = ""
        End If

        If c_cmbSupplier = True Then
            cnnDB.Execute("UPDATE StockItem INNER JOIN gGlobalUpdate ON StockItem.StockItemID = gGlobalUpdate.gStockItemID SET StockItem_SupplierID = " & Me.cmpUpSupplier.BoundText & ";")
            Me.cmpUpSupplier.BoundText = ""
        End If

        If c_Barcode = True Then
            If OprBarcode(0).Checked = True Then
                stString = "Shelf"
                cnnDB.Execute("UPDATE StockItem INNER JOIN gGlobalUpdate ON StockItem.StockItemID = gGlobalUpdate.gStockItemID SET StockItem_SShelf = True;")
                'cnnDB.Execute "UPDATE StockItem INNER JOIN gGlobalUpdate ON StockItem.StockItemID = gGlobalUpdate.gStockItemID SET StockItem_SBarcode = 'Shelf';"
            ElseIf OprBarcode(1).Checked = True Then
                stString = "Barcode"
                cnnDB.Execute("UPDATE StockItem INNER JOIN gGlobalUpdate ON StockItem.StockItemID = gGlobalUpdate.gStockItemID SET StockItem_SBarcode = True;")
                'cnnDB.Execute "UPDATE StockItem INNER JOIN gGlobalUpdate ON StockItem.StockItemID = gGlobalUpdate.gStockItemID SET StockItem_SBarcode = 'Barcode';"
            ElseIf OprBarcode(2).Checked = True Then
                stString = ""
                cnnDB.Execute("UPDATE StockItem INNER JOIN gGlobalUpdate ON StockItem.StockItemID = gGlobalUpdate.gStockItemID SET StockItem.StockItem_SShelf=False, StockItem.StockItem_SBarcode=False ;")
                'cnnDB.Execute "UPDATE StockItem INNER JOIN gGlobalUpdate ON StockItem.StockItemID = gGlobalUpdate.gStockItemID SET StockItem_SBarcode = Null;"
            End If
        End If

        If c_PosOveride = True Then
            rj = getRS("SELECT * FROM gGlobalUpdate;")
            If rj.RecordCount Then
                rj.MoveFirst()
                Do While rj.EOF = False
                    cnnDB.Execute("Delete StockitemOverwrite.* From StockitemOverwrite WHERE (((StockitemOverwrite.StockitemOverwriteID)=" & rj.Fields("gStockItemID").Value & "));")
                    cnnDB.Execute("INSERT INTO StockitemOverwrite ( StockitemOverwriteID ) SELECT " & rj.Fields("gStockItemID").Value & ";")
                    rj.MoveNext()
                Loop
            End If
        End If


        c_Scale = False
        c_Barcode = False
        c_cmbUpPrint = False
        c_PosOveride = False
        c_UndoPosOveride = False 'As Boolean
        c_chkDisabled = False
        c_chkDisconti = False
        c_NonWeighted = False
        c_cmbUpPricing = False
        c_AllowFraction = False
        c_SerialTracing = False
        c_ReportGroups = False

        MsgBox("Update Completed Succesfully", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Global Update")
        Frame2.Enabled = False

    End Sub
    Private Sub cmpUpSupplier_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmpUpSupplier.CellValueChanged
        If Me.cmpUpSupplier.BoundText <> "" Then
            c_cmbSupplier = True
        End If

    End Sub
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        frmGlobalCost.ShowDialog()
    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        cnnDB.Execute("DELETE * FROM gGlobalUpdate;")
        Me.Close()
    End Sub
    Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
        g_Updatep = True
        frmFilter.loadFilter(gFilter)
        gLoad = True
        getNamespace()
    End Sub

    Private Sub Command4_Click()

    End Sub

    Private Sub frmGlobalFilter_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Escape
                KeyAscii = 0
                Me.Close()
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub buildDataControls()
        '4 Updating purposes...
        doDataControl((Me.cmbUpPricing), "SELECT PricingGroupID, PricingGroup_Name FROM PricingGroup ORDER BY PricingGroup_Name", "StockItem_PricingGroupID", "PricingGroupID", "PricingGroup_Name")
        doDataControl((Me.cmpUpSupplier), "SELECT SupplierID, Supplier_Name FROM Supplier WHERE Supplier_Disabled=False ORDER BY Supplier_Name", "StockItem_SupplierID", "SupplierID", "Supplier_Name")
        doDataControl((Me.cmbUpPrinting), "SELECT PrintLocation.* From PrintLocation WHERE (((PrintLocation.PrintLocation_Disabled)=False));", "StockItem_PrintLocationID", "PrintLocationID", "PrintLocation_Name")
        'New Report ID
        doDataControl((Me.cmbReportGroups), "SELECT ReportGroup.* From ReportGroup WHERE (((ReportGroup.ReportGroup_Disabled)=False));", "StockItem_ReportID", "ReportID", "ReportGroup_Name")

    End Sub
    Private Sub doDataControl(ByRef dataControl As myDataGridView, ByRef sql As String, ByRef DataField As String, ByRef boundColumn As String, ByRef listField As String)
        Dim rs As ADODB.Recordset
        rs = getRS(sql)
        dataControl.DataSource = rs
        dataControl.boundColumn = boundColumn
        dataControl.listField = listField
    End Sub

    Private Sub OprBarcode_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles OprBarcode.CheckedChanged
        If eventSender.Checked Then
            Dim rb As New RadioButton
            rb = DirectCast(eventSender, RadioButton)
            Dim Index As Integer = GetIndexer(rb, OprBarcode)
            c_Barcode = True

        End If
    End Sub

    Private Sub doSearch()
        Dim rj As ADODB.Recordset
        Dim sql As String
        Dim lString As String

        lString = gFilterSQL
        If gAll Then
        Else
            If lString = "" Then
                lString = " WHERE StockItem.StockItem_Disabled = 0 Or StockItem.StockItem_Discontinued = 0 "
            Else
                lString = lString & " AND (StockItem.StockItem_Disabled = 0 Or StockItem.StockItem_Discontinued = 0) "
            End If
        End If

        g_SectString = lString

        gRS = getRS("SELECT DISTINCT StockItemID, StockItem_Name FROM StockItem " & lString & " ORDER BY StockItem_Name")
        If gRS.RecordCount > 0 And gLoad = True Then
            frmStockItemByGroup.loadItem("SELECT DISTINCT StockItemID, StockItem_Name FROM StockItem " & lString & " ORDER BY StockItem_Name")
            Frame2.Enabled = True
        End If
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
    Public Sub editItem(ByRef lSection As Short)
        cnnDB.Execute("DELETE ftData.* From ftData")
        cnnDB.Execute("DELETE ftDataItem.* From ftDataItem")
        buildDataControls()
        gSection = lSection
        gFilter = "StockItem"
        gLoad = False
        getNamespace()

        loadLanguage()
        ShowDialog()
    End Sub

    Private Sub frmGlobalFilter_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        OprBarcode.AddRange(New RadioButton() {_OprBarcode_0, _OprBarcode_1, _OprBarcode_2})
        Dim rb As New RadioButton
        For Each rb In OprBarcode
            AddHandler rb.CheckedChanged, AddressOf OprBarcode_CheckedChanged
        Next
    End Sub
End Class