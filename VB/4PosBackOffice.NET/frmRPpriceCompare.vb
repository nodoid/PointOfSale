Option Strict Off
Option Explicit On
Friend Class frmRPpriceCompare
	Inherits System.Windows.Forms.Form
	Dim gFilter As String
	Dim gRS As ADODB.Recordset
	Dim gFilterSQL As String
	
	Private Sub loadLanguage()
		
		'frmRPpriceCompare = No Code    [Setup Price Comparison Report]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmRPpriceCompare.Caption = rsLang("LanguageLayoutLnk_Description"): frmRPpriceCompare.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblHeading = No Code           [Using the "Stock Item Selector"...]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblHeading.Caption = rsLang("LanguageLayoutLnk_Description"): lblHeading.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1006 'Filter|Checked
		If rsLang.RecordCount Then cmdNamespace.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdNamespace.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lbl_0 = No Code               [For which Sale Channel]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0
		'If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkDifferent = No Code         [Only show stock item where prices are different]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkDifferent.Caption = rsLang("LanguageLayoutLnk_Description"): chkDifferent.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkQuantity = No Code          [Show stock Items where quantity is exactly]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkQuantity.Caption = rsLang("LanguageLayoutLnk_Description"): chkQuantity.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkAbove = No Code             [Show stock Items where exit price is above]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkAbove.Caption = rsLang("LanguageLayoutLnk_Description"): chkAbove.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkBelow = No Code             [Show stock Items where exit price below]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkBelow.Caption = rsLang("LanguageLayoutLnk_Description"): chkBelow.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1085 'Print|Checked
		If rsLang.RecordCount Then cmdPrint.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrint.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdExit.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdExit.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmRPpriceCompare.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	
	Private Sub buildDataControls()
		doDataControl((Me.cmbChannel), "SELECT ChannelID, Channel_Name FROM Channel ORDER BY ChannelID", "ChannelID", "Channel_Name")
		doDataControl((Me.cmbShrink), "SELECT DISTINCT ShrinkItem.ShrinkItem_Quantity From ShrinkItem ORDER BY ShrinkItem.ShrinkItem_Quantity;", "ShrinkItem_Quantity", "ShrinkItem_Quantity")
		cmbChannel.BoundText = CStr(1)
		cmbShrink.BoundText = CStr(1)
	End Sub
	
    Private Sub doDataControl(ByRef dataControl As myDataGridView, ByRef sql As String, ByRef boundColumn As String, ByRef listField As String)
        Dim rs As ADODB.Recordset
        rs = getRS(sql)
        dataControl.DataSource = rs
        dataControl.boundColumn = boundColumn
        dataControl.listField = listField
    End Sub
	
	'UPGRADE_WARNING: Event chkQuantity.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkQuantity_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkQuantity.CheckStateChanged
		cmbShrink.Enabled = chkQuantity.CheckState
	End Sub
	
    Private Sub cmbChannel_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles cmbChannel.KeyPress
        frmRPpriceCompare_KeyPress(Me, New System.Windows.Forms.KeyPressEventArgs(eventArgs.KeyChar))
    End Sub

    Private Sub cmbShrink_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles cmbShrink.KeyPress
        frmRPpriceCompare_KeyPress(Me, New System.Windows.Forms.KeyPressEventArgs(eventArgs.KeyChar))
    End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		Me.Close()
	End Sub
	
	Private Sub cmdNamespace_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNamespace.Click
		frmFilter.loadFilter(gFilter)
		getNamespace()
	End Sub
	
	Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
		doSearch()
	End Sub
	
	Private Sub frmRPpriceCompare_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		gFilter = "stockitem"
		buildDataControls()
		
		loadLanguage()
		getNamespace()
	End Sub
	
	Private Sub frmRPpriceCompare_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub getNamespace()
		If gFilter = "" Then
			Me.lblHeading.Text = ""
		Else
			frmFilter.buildCriteria(gFilter)
			Me.lblHeading.Text = frmFilter.gHeading
		End If
		gFilterSQL = frmFilter.gCriteria
	End Sub
	
	
	Private Sub doSearch()
        Dim lString As String
        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
		Dim rs As ADODB.Recordset
		Dim sql As String
        Report.Load("cryPriceComparison.rpt")
		Dim lHeading As String
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		rs = getRS("SELECT * FROM Company")
		Report.SetParameterValue("txtCompanyName",rs.Fields("Company_Name"))
        Report.SetParameterValue("txtTitle", Me.Text)
        Report.SetParameterValue("txtFilter", Me.lblHeading.Text)
		rs.Close()
		lString = "((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) = " & Me.cmbChannel.BoundText & ") And (Catalogue.Catalogue_Disabled <> -1) AND ([Catalogue_Content]<>0)"
		If gFilterSQL = "" Then
			lString = " WHERE " & lString
		Else
			lString = gFilterSQL & " AND " & lString
		End If
		If cmbShrink.Enabled Then
			lString = lString & " AND (Catalogue.Catalogue_Quantity = " & Me.cmbShrink.BoundText & ") "
			lHeading = " and Quantity = " & Me.cmbShrink.BoundText
		End If
		If chkDifferent.CheckState Then
			lString = lString & " AND (([CatalogueChannelLnk_PriceSystem]-[CatalogueChannelLnk_Price])<>0) "
		End If
		If chkAbove.CheckState Then
			lString = lString & " AND (((1 - (([Catalogue_Content]) * (1 + [vat_amount] / 100)) / [CatalogueChannelLnk_Price]) * 100) > " & Me.txtAbove.Text & ") "
			lHeading = " and Markup > " & Me.txtAbove.Text
		End If
		If chkBelow.CheckState Then
			lString = lString & " AND (((1 - (([Catalogue_Content]) * (1 + [vat_amount] / 100)) / [CatalogueChannelLnk_Price]) * 100) < " & Me.txtAbove.Text & ") "
			lHeading = " and Markup < " & Me.txtAbove.Text
		End If
		
		sql = "SELECT StockItem.StockItem_Name, Catalogue.*, ([Catalogue_Content]+[Catalogue_Deposit])*(1+[vat_amount]/100) AS cost, CatalogueChannelLnk.CatalogueChannelLnk_Location, CatalogueChannelLnk.CatalogueChannelLnk_Markup, CatalogueChannelLnk.CatalogueChannelLnk_PriceOriginal, CatalogueChannelLnk.CatalogueChannelLnk_PriceSystem, CatalogueChannelLnk.CatalogueChannelLnk_Price, [CatalogueChannelLnk_Price]-[CatalogueChannelLnk_PriceSystem] AS difference, 100*(([CatalogueChannelLnk_Price]/(1+([Vat_Amount]/100))-[Catalogue_Deposit])/[Catalogue_Content]-1) AS MarkupPrice, 100*(([CatalogueChannelLnk_PriceSystem]/(1+([Vat_Amount]/100))-[Catalogue_Deposit])/[Catalogue_Content]-1) AS MarkupSystem, (1-(([Catalogue_Content])*(1+[vat_amount]/100))/[CatalogueChannelLnk_Price])*100 AS grossPercentage, ([CatalogueChannelLnk_Price]/([Catalogue_Content]*(1+[vat_amount]/100))-1)*100 AS markupPercentage "
		sql = sql & "FROM ((StockItem INNER JOIN Catalogue ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN CatalogueChannelLnk ON (Catalogue.Catalogue_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) AND (Catalogue.Catalogue_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity)) INNER JOIN Vat ON StockItem.StockItem_VatID = Vat.VatID "
		sql = sql & lString
		sql = sql & "ORDER BY StockItem.StockItem_Name, Catalogue.Catalogue_Quantity;"
		
        Report.SetParameterValue("txtTitle", "Where Sales Channel = " & cmbChannel.CtlText & lHeading)
		
		rs = getRS(sql)
		'Report.Database.SetDataSource(rs, 3)
		Report.Database.Tables(1).SetDataSource(rs)
		'Report.VerifyOnEveryPrint = True
		frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
		frmReportShow.CRViewer1.ReportSource = Report
		frmReportShow.mReport = Report : frmReportShow.sMode = "0"
		frmReportShow.CRViewer1.Refresh()
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		frmReportShow.ShowDialog()
		
	End Sub
	
	
	Private Sub txtAbove_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtAbove.Enter
        MyGotFocusNumeric(txtAbove.Text())
	End Sub
	
	Private Sub txtAbove_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtAbove.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        MyKeyPressNegative(txtAbove, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtAbove_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtAbove.Leave
        MyLostFocus(txtAbove, 0)
	End Sub
End Class