Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks

Imports CrystalDecisions.CrystalReports.Engine
Friend Class frmBrokenPack
	Inherits System.Windows.Forms.Form
	Private Sub loadLanguage()
		
		'frmBrokenPack = No Caption?
		
		'Recomend changing image text to lablels
		
		'WARNING: Label caption still contains old name "Liquid"!!!
		'_Label2_0 = No Code    [Some suppliers do not allow you to order.......]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _Label2_0.Caption = rsLang("LanguageLayoutLnk_Description"): _Label2_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1006 'Filter|Checked
		If rsLang.RecordCount Then cmdFilter.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdFilter.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_Label2_1 = No Code    [If you have not sold that proportion of a case.......]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _Label2_1.Caption = rsLang("LanguageLayoutLnk_Description"): _Label2_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1085 'Print
		If rsLang.RecordCount Then cmdPrint.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrint.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'cmdBuild = No Code     [Execute]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdBuild.Caption = rsLang("LanguageLayoutLnk_Description"): cmdBuild.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmBrokenPack.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub cmdBuild_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBuild.Click
        Dim gCriteria As String
		Dim sql As String
		Dim lValue As Decimal
		If MsgBox("By selecting 'Yes' you will alter the 'break pack' parameter of several stock items." & vbCrLf & vbCrLf & "Are you sure you wish to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "CONTINUE") = MsgBoxResult.Yes Then
			cnnDB.Execute("UPDATE StockItem SET StockItem.StockItem_OrderQuantity = [StockItem]![StockItem_Quantity];")
			If Me.cmbSize.SelectedIndex Then
				Select Case Me.cmbSize.SelectedIndex
					Case 1
						lValue = 1
					Case 2
						lValue = 0.75
					Case 3
						lValue = 0.666666
					Case 4
						lValue = 0.5
					Case 5
						lValue = 0.33333
					Case 6
						lValue = 0.25
					Case 7
				End Select
				
				frmFilterOrder.buildCriteria("order")
				sql = "UPDATE StockItem INNER JOIN StockitemHistory ON StockItem.StockItemID = StockitemHistory.StockitemHistory_StockItemID SET StockItem.StockItem_OrderQuantity = 1 WHERE ((([StockitemHistory_Day2]+[StockitemHistory_Day3]+[StockitemHistory_Day4]+[StockitemHistory_Day5]+[StockitemHistory_Day6]+[StockitemHistory_Day7]+[StockitemHistory_Day8]+[StockitemHistory_Day9]+[StockitemHistory_Day10]+[StockitemHistory_Day11])<cInt([StockItem]![StockItem_Quantity]*" & lValue & ")) AND ((StockItem.StockItem_Quantity)<>1))"
				'UPGRADE_WARNING: Couldn't resolve default property of object gCriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If gCriteria <> "" Then
					'UPGRADE_WARNING: Couldn't resolve default property of object gCriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sql = sql & gCriteria
				End If
				cnnDB.Execute(sql)
			End If
			Me.Close()
		End If
	End Sub
	
	Private Sub cmdFilter_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFilter.Click
		frmFilterOrder.loadFilter("order")
		frmFilterOrder.buildCriteria("order")
		Me.lblHeading.Text = frmFilterOrder.gHeading
	End Sub
	
	Private Sub Command1_Click()
		
	End Sub
	
	Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
		Dim sql As String
		Dim lValue As Decimal
		Dim rs As ADODB.Recordset
        'Dim Report As New cryBrokenPack
        Dim Report As ReportDocument
        Report.Load("cryBrokenPack.rpt")
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		rs = getRS("SELECT * FROM Company")
		'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtCompanyName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
		rs.Close()
		Select Case Me.cmbSize.SelectedIndex
			Case 0
				lValue = 1
			Case 1
				lValue = 1
			Case 2
				lValue = 0.75
			Case 3
				lValue = 0.666666
			Case 4
				lValue = 0.5
			Case 5
				lValue = 0.33333
			Case 6
				lValue = 0.25
			Case 7
		End Select
		
		frmFilterOrder.buildCriteria("order")
		sql = "SELECT StockItem.StockItem_Name, [StockitemHistory_Day2]+[StockitemHistory_Day3]+[StockitemHistory_Day4]+[StockitemHistory_Day5]+[StockitemHistory_Day6]+[StockitemHistory_Day7]+[StockitemHistory_Day8]+[StockitemHistory_Day9]+[StockitemHistory_Day10]+[StockitemHistory_Day11] AS HistoryQTY, StockItem.StockItem_Quantity, StockItem.StockItem_OrderDynamic, StockItem.StockItem_OrderRounding, StockItem.StockItem_OrderQuantity FROM StockItem INNER JOIN StockitemHistory ON StockItem.StockItemID = StockitemHistory.StockitemHistory_StockItemID Where ((([StockitemHistory_Day2] + [StockitemHistory_Day3] + [StockitemHistory_Day4] + [StockitemHistory_Day5] + [StockitemHistory_Day6] + [StockitemHistory_Day7] + [StockitemHistory_Day8] + [StockitemHistory_Day9] + [StockitemHistory_Day10] + [StockitemHistory_Day11]) < [StockItem]![StockItem_Quantity] * " & lValue & ") And ((StockItem.StockItem_Quantity) <> 1) And ((StockItem.StockItem_OrderQuantity) <> 1)) " & frmFilterOrder.gCriteria & " "
		sql = sql & "ORDER BY StockItem.StockItem_Name;"
		rs = getRS(sql)
        'ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As ReportDocument
        ReportNone.Load("cryNoRecords.rpt")
		If rs.BOF Or rs.EOF Then
			ReportNone.SetParameterValue("txtCompanyName", Report.ParameterFields("txtCompanyName").ToString)
            ReportNone.SetParameterValue("txtTitle", Report.ParameterFields("txtTitle").ToString)
			'UPGRADE_WARNING: Couldn't resolve default property of object ReportNone.txtTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            frmReportShow.Text = ReportNone.ParameterFields("txtTitle").ToString
			frmReportShow.CRViewer1.ReportSource = ReportNone
			frmReportShow.mReport = ReportNone : frmReportShow.sMode = "0"
			frmReportShow.CRViewer1.Refresh()
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			frmReportShow.ShowDialog()
			Exit Sub
		End If
		Report.SetDataSource(rs)
		Report.Database.Tables(1).SetDataSource(rs)
		'Report.VerifyOnEveryPrint = True
		frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
		frmReportShow.CRViewer1.ReportSource = Report
		frmReportShow.mReport = Report : frmReportShow.sMode = "0"
		frmReportShow.CRViewer1.Refresh()
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		frmReportShow.ShowDialog()
		
		
		
	End Sub
	
	Private Sub frmBrokenPack_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 27 Then
			KeyAscii = 0
			Me.Close()
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub frmBrokenPack_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		frmFilterOrder.buildCriteria("order")
		
		Me.lblHeading.Text = frmFilterOrder.gHeading
		Me.cmbSize.SelectedIndex = 0
		
		loadLanguage()
	End Sub
End Class