Option Strict Off
Option Explicit On
Friend Class frmCashTransaction
	Inherits System.Windows.Forms.Form
	Dim gRS As ADODB.Recordset
	Dim gID As Integer
	
	Private Sub loadLanguage()
		
		'frmCashTransacion = No Code    [Cash Transactions]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmCashTransaction.Caption = rsLang("LanguageLayoutLnk_Description"): frmCashTransaction.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1085 'Print|Checked
		If rsLang.RecordCount Then cmdPrint.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrint.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1147 'Add|Checked
		If rsLang.RecordCount Then cmdNew.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdNew.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1148 'Delete|Checked
		If rsLang.RecordCount Then cmdDelete.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdDelete.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmCashTransaction.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	
	Private Sub cmdDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDelete.Click
        Dim lQty As String
		Dim lID As Integer
		If lvItem.FocusedItem Is Nothing Then
		Else
			If MsgBox("Are you sure you wish to remove " & lvItem.FocusedItem.Text & " as a cash transaction?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "DELETE") = MsgBoxResult.Yes Then
				lID = CInt(Split(lvItem.FocusedItem.Name, "_")(0))
				'UPGRADE_WARNING: Couldn't resolve default property of object lQty. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lQty = Split(lvItem.FocusedItem.Name, "_")(1)
				'UPGRADE_WARNING: Couldn't resolve default property of object lQty. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				cnnDB.Execute("DELETE CashTransaction.* FROM CashTransaction WHERE (((CashTransaction.CashTransaction_StockItemID)=" & lID & ") AND ((CashTransaction.CashTransaction_Shrink)=" & lQty & "));")
				doSearch()
			End If
		End If
		
	End Sub
	
	Private Sub cmdExit_Click()
		Me.Close()
	End Sub
	
	Private Sub cmdNew_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNew.Click
		Dim lID As Integer
		Dim rs As ADODB.Recordset
		
		lID = frmStockList.getItem
		If lID <> 0 Then
			On Error Resume Next
			frmCashTransactionItem.loadItem(lID, 0)
			doSearch()
		End If
		
	End Sub
	
	Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
		Dim rs As ADODB.Recordset
		Dim rsQty As ADODB.Recordset
		Dim RSitem As ADODB.Recordset
		Dim ltype As Boolean
        'Dim Report As New cryCashTransaction
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryCashTransaction.rpt")
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		rs = getRS("SELECT * FROM Company")
		'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtCompanyName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
		rs.Close()
		
		rs = getRS("SELECT * FROM Channel ORDER BY ChannelID")
		Do Until rs.EOF
			Select Case rs.Fields("ChannelID").Value
				Case 1
                    Report.SetParameterValue("txtCS1", rs.Fields("Channel_Code"))
				Case 2
                    Report.SetParameterValue("txtCS2", rs.Fields("Channel_Code"))
				Case 3
                    Report.SetParameterValue("txtCS3", rs.Fields("Channel_Code"))
				Case 4
                    Report.SetParameterValue("txtCS4", rs.Fields("Channel_Code"))
				Case 5
                    Report.SetParameterValue("txtCS5", rs.Fields("Channel_Code"))
				Case 6
                    Report.SetParameterValue("txtCS6", rs.Fields("Channel_Code"))
				Case 7
                    Report.SetParameterValue("txtCS7", rs.Fields("Channel_Code"))
				Case 8
                    Report.SetParameterValue("txtCS8", rs.Fields("Channel_Code"))
			End Select
			rs.moveNext()
		Loop 
		rs.Close()
		
		rs = getRS("SELECT CashTransaction.*, StockItem.StockItem_Name FROM StockItem INNER JOIN CashTransaction ON StockItem.StockItemID = CashTransaction.CashTransaction_StockItemID;")
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
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		frmReportShow.ShowDialog()
		
		
	End Sub
	
	Private Sub frmCashTransaction_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.Escape
				KeyAscii = 0
				cmdExit_Click()
		End Select
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Public Sub loadItem()
		lvItem.Columns.Clear()
        lvItem.Columns.Add("", "Stock Item", CInt(twipsToPixels(4050, True)))
        lvItem.Columns.Add("QTY", CInt(twipsToPixels(800, True)), _
                           System.Windows.Forms.HorizontalAlignment.Right)
        lvItem.Columns.Add("Price", CInt(twipsToPixels(1440, True)), _
                           System.Windows.Forms.HorizontalAlignment.Right)
		doSearch()
		
		loadLanguage()
		Me.ShowDialog()
	End Sub
	
	Private Sub frmCashTransaction_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		gRS.Close()
	End Sub
	
	
	Private Sub txtSearch_KeyPress(ByRef KeyAscii As Short)
		Select Case KeyAscii
			Case 13
				doSearch()
				KeyAscii = 0
		End Select
	End Sub
	
	Private Sub doSearch()
		Dim sql As String
		Dim lString As String
		Dim lLI As System.Windows.Forms.ListViewItem
		gRS = getRS("SELECT StockItem.StockItem_Name, CashTransaction.CashTransaction_StockItemID, CashTransaction.CashTransaction_Shrink, StockItem.StockItem_PriceSetID, CashTransaction.CashTransaction_Type, CashTransaction_Amount FROM CashTransaction INNER JOIN StockItem ON CashTransaction.CashTransaction_StockItemID = StockItem.StockItemID ORDER BY StockItem.StockItem_Name;")
		
		'Display the list of Titles in the DataCombo
		lvItem.Items.Clear()
		Do Until gRS.EOF
			lLI = lvItem.Items.Add(gRS.Fields("CashTransaction_StockItemID").Value & "_" & gRS.Fields("CashTransaction_Shrink").Value, gRS.Fields("StockItem_Name").Value, "")
			'UPGRADE_WARNING: Lower bound of collection lLI has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lLI.SubItems.Count > 1 Then
				lLI.SubItems(1).Text = gRS.Fields("CashTransaction_Shrink").Value
			Else
				lLI.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, gRS.Fields("CashTransaction_Shrink").Value))
			End If
			'UPGRADE_WARNING: Lower bound of collection lLI has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			If lLI.SubItems.Count > 2 Then
				lLI.SubItems(2).Text = FormatNumber(gRS.Fields("CashTransaction_Amount").Value, 2)
			Else
				lLI.SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(gRS.Fields("CashTransaction_Amount").Value, 2)))
			End If
			gRS.moveNext()
		Loop 
		
	End Sub
	
	
	Private Sub lvItem_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvItem.DoubleClick
		Dim lID As Integer
		Dim lQty As Short
		If lvItem.FocusedItem Is Nothing Then
		Else
			lID = CInt(Split(lvItem.FocusedItem.Name, "_")(0))
			lQty = CShort(Split(lvItem.FocusedItem.Name, "_")(1))
			
			frmCashTransactionItem.loadItem(lID, CShort(lQty))
			doSearch()
		End If
		
	End Sub
	
	Private Sub lvItem_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles lvItem.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Then
			lvItem_DoubleClick(lvItem, New System.EventArgs())
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class