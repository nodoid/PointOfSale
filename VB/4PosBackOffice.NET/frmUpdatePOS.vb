Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmUpdatePOS
	Inherits System.Windows.Forms.Form
	Private Sub loadLanguage()
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1169 'Update Point Of Sale|Checked
		If rsLang.RecordCount Then Me.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : Me.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'cmdPrintNew = No Code      [Print &New]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdPrintNew.Caption = rsLang("LanguageLayoutLnk_Description"): cmdPrintNew.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdPrintAmend = No Code    [Print &Amend]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdPrintAmend.Caption = rsLang("LanguageLayoutLnk_Description"): cmdPrintAmend.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Command1 = No Code         [Print &Barcodes]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Command1.Caption = rsLang("LanguageLayoutLnk_Description"): Command1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdUpdate = No Code        [&Update POS]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdUpdate.Caption = rsLang("LanguageLayoutLnk_Description"): cmdUpdate.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
        '_lbl_1 = No Code           [Number of Stock Items that will be effected by the Update]
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblLabels(34) = No Code    [Amend]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblLabels(34).Caption = rsLang("LanguageLayoutLnk_Description"): lblLabels(34).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1065 'New|Checked
        If rsLang.RecordCount Then _lblLabels_33.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_33.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lblCG(0) = No Code/Dynamic/NA?
		'lblCG(1) = No code/Dynamic/NA?
		'lblCG(2) = No Code/Dynamic/NA?
		'lblCG(3) = No Code/Dynamic/NA?
		'lblCG(4) = No Code/Dynamic/NA?
		'lblCG(5) = No Code/Dynamic/NA?
		'lblCG(6) = No Code/Dynamic/NA?
		'lblCG(7) = No Code/Dynamic/NA?
		
        '_lbl_0 = No Code           [The current POS update the new POS instruction number will be]
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
        '_lbl_2 = No Code           [After this update the number will be]
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdScale = No Code         [Force &Scale Update]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdScale.Caption = rsLang("LanguageLayoutLnk_Description"): cmdScale.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
        'UPGRADE_ISSUE: Form property frmUpdatePOS.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub setup()
		Dim rs As ADODB.Recordset
		rs = getRS("SELECT Channel_Code FROM Channel ORDER BY ChannelID")
		rs.MoveFirst()
        _lblCG_0.Text = _lblCG_1.Text = _lblCG_2.Text = _lblCG_3.Text = _
            _lblCG_4.Text = _lblCG_5.Text = _lblCG_6.Text = _lblCG_7.Text = rs.Fields("Channel_Code").Value

		rs = getRS("SELECT Company.Company_PosInstruction FROM Company;")
		lblInstruction.Text = rs.Fields("Company_PosInstruction").Value
		lblInstructionNew.Text = CStr(CDbl(lblInstruction.Text) + 1)
		
	End Sub
	
	Private Sub loadSummary()
		Dim rs As ADODB.Recordset
		Dim sql As String
		sql = "SELECT theJoin.CatalogueChannelLnk_ChannelID, Count(theJoin.CatalogueChannelLnk_StockItemID) AS noUnits FROM [SELECT POSUpdate_PriceChangeSummary.CatalogueChannelLnk_ChannelID, POSUpdate_PriceChangeSummary.CatalogueChannelLnk_StockItemID From POSUpdate_PriceChangeSummary GROUP BY POSUpdate_PriceChangeSummary.CatalogueChannelLnk_ChannelID, POSUpdate_PriceChangeSummary.CatalogueChannelLnk_StockItemID]. AS theJoin GROUP BY theJoin.CatalogueChannelLnk_ChannelID;"
		rs = getRS(sql)
		Do Until rs.EOF
            _txtAmend_1.Text = rs.Fields("noUnits").Value
			rs.moveNext()
		Loop 
		
		sql = "SELECT theJoin.CatalogueChannelLnk_ChannelID, Count(theJoin.CatalogueChannelLnk_StockItemID) AS noUnits FROM [SELECT POSUpdate_PriceNewSummary.CatalogueChannelLnk_ChannelID, POSUpdate_PriceNewSummary.CatalogueChannelLnk_StockItemID From POSUpdate_PriceNewSummary GROUP BY POSUpdate_PriceNewSummary.CatalogueChannelLnk_ChannelID, POSUpdate_PriceNewSummary.CatalogueChannelLnk_StockItemID]. AS theJoin GROUP BY theJoin.CatalogueChannelLnk_ChannelID;"
		rs = getRS(sql)
		Do Until rs.EOF
            _txtNew_1.Text = rs.Fields("noUnits").Value
			rs.moveNext()
		Loop 
	End Sub
	
	Private Sub txtFloatNegative_Change(ByRef Index As Short)
		
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		'For Auto UpdatePOS on MonthEnd
		If blMEndUpdatePOS = True Then
			blMEndUpdatePOS = False
		End If
		
		Me.Close()
	End Sub
	
	Private Sub cmdPrintAmend_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrintAmend.Click
        Dim sql As String
		
		Dim rs As ADODB.Recordset
        Dim ltype As Boolean
        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryPOSupdate.rpt")
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		rs = getRS("SELECT * FROM Company")
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
		rs.Close()
		
        Report.SetParameterValue("txtTitle", "Amended Catalogue Updates")
        Report.SetParameterValue("txtTitle1", _lbl_0.Text & " " & Me.lblInstruction.Text & ". the new POS update Instruction will be " & Me.lblInstructionNew.Text & ".")
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
		sql = "TRANSFORM Sum(Query2.POSCatalogueChannelLnk_Price) AS SumOfPOSCatalogueChannelLnk_Price SELECT Query2.StockItemID, Query2.StockItem_Name, Query2.CatalogueChannelLnk_Quantity FROM (SELECT StockItem.StockItemID, StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Price, POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price "
		sql = sql & "FROM ((POSUpdate_PriceChangeSummary INNER JOIN StockItem ON POSUpdate_PriceChangeSummary.CatalogueChannelLnk_StockItemID = StockItem.StockItemID) INNER JOIN CatalogueChannelLnk ON (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = POSUpdate_PriceChangeSummary.CatalogueChannelLnk_Quantity) AND (POSUpdate_PriceChangeSummary.CatalogueChannelLnk_ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) AND (StockItem.StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID)) INNER JOIN POSCatalogueChannelLnk ON (CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity = CatalogueChannelLnk.CatalogueChannelLnk_Quantity) AND (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID) ORDER BY StockItem.StockItem_Name, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) "
		sql = sql & "Query2 GROUP BY Query2.StockItemID, Query2.StockItem_Name, Query2.CatalogueChannelLnk_Quantity PIVOT Query2.CatalogueChannelLnk_ChannelID;"
		
		rs = getRS(sql)
		If rs.BOF Or rs.EOF Then
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			MsgBox("No items in report", MsgBoxStyle.Exclamation, My.Application.Info.Title)
			Exit Sub
		End If
		'Report.Database.SetDataSource(rs, 3)
		'Report.VerifyOnEveryPrint = True
		frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
		frmReportShow.CRViewer1.ReportSource = Report
		frmReportShow.mReport = Report : frmReportShow.sMode = "0"
		frmReportShow.CRViewer1.Refresh()
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		frmReportShow.ShowDialog()
		
		
	End Sub
	
	Private Sub cmdPrintNew_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrintNew.Click
        Dim sql As String
        Dim Report As CrystalDecisions.CrystalReports.Engine.ReportDocument
		Dim rs As ADODB.Recordset
		Dim ltype As Boolean
		Report.Load("cryPOSupdate.rpt")
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		rs = getRS("SELECT * FROM Company")
		'UPGRADE_WARNING: Couldn't resolve default property of object Report.txtCompanyName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Report.SetParameterValue("txtCompanyName", rs.Fields("Company_Name"))
		rs.Close()
		
        Report.SetParameterValue("txtTitle", "New Catalogue Updates")
        Report.SetParameterValue("txtTitle1", _lbl_0.Text & " " & Me.lblInstruction.Text & ". the new POS update Instruction will be " & Me.lblInstructionNew.Text & ".")
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
		sql = "TRANSFORM Sum(newItems.CatalogueChannelLnk_Price) AS SumOfCatalogueChannelLnk_Price SELECT newItems.StockItemID, newItems.StockItem_Name, newItems.CatalogueChannelLnk_Quantity FROM [SELECT StockItem.StockItemID, StockItem.StockItem_Name, POSUpdate_PriceNewSummary.CatalogueChannelLnk_ChannelID, POSUpdate_PriceNewSummary.CatalogueChannelLnk_Quantity, CatalogueChannelLnk.CatalogueChannelLnk_Price FROM CatalogueChannelLnk INNER JOIN (POSUpdate_PriceNewSummary INNER JOIN StockItem ON POSUpdate_PriceNewSummary.CatalogueChannelLnk_StockItemID = StockItem.StockItemID) ON (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = POSUpdate_PriceNewSummary.CatalogueChannelLnk_Quantity) AND (CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = POSUpdate_PriceNewSummary.CatalogueChannelLnk_ChannelID) AND (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = POSUpdate_PriceNewSummary.CatalogueChannelLnk_StockItemID) "
		sql = sql & "ORDER BY StockItem.StockItem_Name, POSUpdate_PriceNewSummary.CatalogueChannelLnk_ChannelID, POSUpdate_PriceNewSummary.CatalogueChannelLnk_Quantity]. AS newItems GROUP BY newItems.StockItemID, newItems.StockItem_Name, newItems.CatalogueChannelLnk_Quantity PIVOT newItems.CatalogueChannelLnk_ChannelID;"
		
		rs = getRS(sql)
		If rs.BOF Or rs.EOF Then
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			MsgBox("No items in report", MsgBoxStyle.Exclamation, My.Application.Info.Title)
			Exit Sub
		End If
		'Report.Database.SetDataSource(rs, 3)
		'Report.VerifyOnEveryPrint = True
		frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
		frmReportShow.CRViewer1.ReportSource = Report
		frmReportShow.mReport = Report : frmReportShow.sMode = "0"
		frmReportShow.CRViewer1.Refresh()
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		frmReportShow.ShowDialog()
		
		
		
		
	End Sub
	
	Private Sub cmdScale_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdScale.Click
        Dim mySQL As String
		Dim rsScale As ADODB.Recordset
		Dim rsData As ADODB.Recordset
        Dim lString As String = ""
		Dim lFormat As String
		Dim HeadingString1, HeadingString2 As String
		Dim lWeighted As String
		Dim FSO As New Scripting.FileSystemObject
		Dim lTextstreamC As Scripting.TextStream
		On Error Resume Next
		rsScale = getRS("SELECT Scale.* FROM Scale;")
		Do Until rsScale.EOF
			If frmUpdatePOScriteria.frmType(0).Visible = True Then
				mySQL = "SELECT Right('0000'+[Catalogue_Barcode],4) AS code, Format([CatalogueChannelLnk_Price],'Fixed') AS price, StockItem.StockItem_Name, StockGroup.StockGroup_Name, StockItem.StockItem_NonWeighted FROM POSUpdate_PriceChangeSummary INNER JOIN ((StockItem INNER JOIN (CatalogueChannelLnk INNER JOIN Catalogue ON (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = Catalogue.Catalogue_StockItemID) AND (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = Catalogue.Catalogue_Quantity)) ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) ON POSUpdate_PriceChangeSummary.CatalogueChannelLnk_StockItemID = StockItem.StockItemID WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((Catalogue.Catalogue_Quantity)=1) AND ((StockItem.StockItem_Disabled)=False) AND ((StockItem.StockItem_VariablePrice)=True));"
			Else
				mySQL = "SELECT Right('0000'+[Catalogue_Barcode],4) AS code, Format([CatalogueChannelLnk_Price],'Fixed') AS price, StockItem.StockItem_Name, StockGroup.StockGroup_Name, StockItem.StockItem_NonWeighted FROM (StockItem INNER JOIN (CatalogueChannelLnk INNER JOIN Catalogue ON (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = Catalogue.Catalogue_Quantity) AND (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = Catalogue.Catalogue_StockItemID)) ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((Catalogue.Catalogue_Quantity)=1) AND ((StockItem.StockItem_Disabled)=False) AND ((StockItem.StockItem_VariablePrice)=True));"
			End If
			rsData = getRS(mySQL)
			
			'        Select Case rsScale("Scale_format")
			'            Case 0
			'                rsData.MoveFirst
			'                Do Until rsData.EOF
			
			'                    HeadingString1 = Left(rsData("Stockitem_Name"), 16)
			'                    HeadingString2 = ""
			'                    If Len(rsData("Stockitem_Name")) > 16 Then
			'                        Do Until Right(HeadingString1, 1) = " "
			'                            HeadingString1 = Left(HeadingString1, Len(HeadingString1) - 1)
			'                        Loop
			'                        HeadingString2 = Mid(rsData("Stockitem_Name"), Len(HeadingString1) + 1)
			'                    End If
			'                    HeadingString1 = Left(HeadingString1 & String(16, " "), 16)
			'                    HeadingString2 = Left(HeadingString2 & String(16, " "), 16)
			'                    If rsData("StockItem_NonWeighted") Then lWeighted = "01" Else lWeighted = "00"
			'                    lstring = lstring & vbCrLf & "#" & rsData("code") & "$" & rsData("price") & "%#000%$" & lWeighted & "%(A" & HeadingString1 & "%)A" & HeadingString2 & "%[" & Left(rsData("StockGroup_Name") & String(15, " "), 15)
			'                    rsData.moveNext
			'                Loop
			'            Case 1
			
			rsData.MoveFirst()
			Do Until rsData.EOF
				
				HeadingString1 = VB.Left(rsData.Fields("Stockitem_Name").Value, 16) '16 was 22
				HeadingString2 = ""
				If Len(rsData.Fields("Stockitem_Name").Value) > 16 Then '16 was 22
					Do Until VB.Right(HeadingString1, 1) = " " Or HeadingString1 = ""
						HeadingString1 = VB.Left(HeadingString1, Len(HeadingString1) - 1)
					Loop 
					HeadingString2 = Mid(rsData.Fields("Stockitem_Name").Value, Len(HeadingString1) + 1)
				End If
				HeadingString1 = VB.Left(HeadingString1 & New String(" ", 16), 16) '16 was 22
				HeadingString2 = VB.Left(HeadingString2 & New String(" ", 22), 22) '16 was 22
				If rsData.Fields("StockItem_NonWeighted").Value Then lWeighted = "01" Else lWeighted = "00"
				'                    lstring = lstring & vbCrLf & "%*0 #" & rsData("code") & " $" & Right("00000" & Replace(rsData("price"), ".", ""), 5) & " %#000 %$" & lWeighted & "%&" & rsScale("ScaleID") & rsData("code") & " %(A" & HeadingString1 & " %)A" & HeadingString2 & " %[" & Left(rsData("StockGroup_Name") & String(15, " "), 15) & " %]" & String(15, " ") & " %~"
				'If lString = "" Then
				'    lString = "%*0 #" & rsData("code") & " $" & Right("00000" & FormatNumber(rsData("price"), 2), 6) & " %#000 %&       %(A" & HeadingString1 & " %)A" & HeadingString2 & " %$" & lWeighted
				'Else
				lString = lString & vbCrLf & "%*0 #" & rsData.Fields("code").Value & " $" & VB.Right("00000" & FormatNumber(rsData.Fields("price").Value, 2), 6) & " %#000 %&       %(A" & HeadingString1 & " %)A" & HeadingString2 & " %$" & lWeighted
				'End If
				rsData.moveNext()
			Loop 
			'        End Select
			'FOR NEW SCALE ITEMS
			If frmUpdatePOScriteria.frmType(0).Visible = True Then
				'UPGRADE_WARNING: Couldn't resolve default property of object mySQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mySQL = "SELECT Right('0000'+[Catalogue_Barcode],4) AS code, Format([CatalogueChannelLnk_Price],'Fixed') AS price, StockItem.StockItem_Name, StockGroup.StockGroup_Name, StockItem.StockItem_NonWeighted FROM POSUpdate_PriceNewSummary INNER JOIN ((StockItem INNER JOIN (CatalogueChannelLnk INNER JOIN Catalogue ON (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = Catalogue.Catalogue_StockItemID) AND (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = Catalogue.Catalogue_Quantity)) ON StockItem.StockItemID = Catalogue.Catalogue_StockItemID) INNER JOIN StockGroup ON StockItem.StockItem_StockGroupID = StockGroup.StockGroupID) ON POSUpdate_PriceNewSummary.CatalogueChannelLnk_StockItemID = StockItem.StockItemID WHERE (((CatalogueChannelLnk.CatalogueChannelLnk_ChannelID)=1) AND ((Catalogue.Catalogue_Quantity)=1) AND ((StockItem.StockItem_Disabled)=False) AND ((StockItem.StockItem_VariablePrice)=True));"
				rsData = getRS(mySQL)
				rsData.MoveFirst()
				Do Until rsData.EOF
					
					HeadingString1 = VB.Left(rsData.Fields("Stockitem_Name").Value, 16) '16 was 22
					HeadingString2 = ""
					If Len(rsData.Fields("Stockitem_Name").Value) > 16 Then '16 was 22
						Do Until VB.Right(HeadingString1, 1) = " " Or HeadingString1 = ""
							HeadingString1 = VB.Left(HeadingString1, Len(HeadingString1) - 1)
						Loop 
						HeadingString2 = Mid(rsData.Fields("Stockitem_Name").Value, Len(HeadingString1) + 1)
					End If
					HeadingString1 = VB.Left(HeadingString1 & New String(" ", 16), 16) '16 was 22
					HeadingString2 = VB.Left(HeadingString2 & New String(" ", 22), 22) '16 was 22
					If rsData.Fields("StockItem_NonWeighted").Value Then lWeighted = "01" Else lWeighted = "00"
					lString = lString & vbCrLf & "%*0 #" & rsData.Fields("code").Value & " $" & VB.Right("00000" & FormatNumber(rsData.Fields("price").Value, 2), 6) & " %#000 %&       %(A" & HeadingString1 & " %)A" & HeadingString2 & " %$" & lWeighted
					rsData.moveNext()
				Loop 
			End If
			
			If FSO.FileExists(rsScale.Fields("Scale_Path").Value) Then FSO.DeleteFile(rsScale.Fields("Scale_Path").Value)
			If Len(lString) Then
				
				
				lTextstreamC = FSO.CreateTextFile(rsScale.Fields("Scale_Path").Value, True)
				Debug.Print(Trim(VB.Left(lString, Len(lString) - 1)))
				lTextstreamC.Write(Mid(lString, 3))
				lTextstreamC.Close()
				
				'Open rsScale("Scale_Path") For Output As #7
				'Print #7, mID(lString, 3, Len(lString) - 5)
				'Close #7
				
				If FSO.FileExists(serverPath & "teraoka.bat") Then Shell(serverPath & "teraoka.bat", AppWinStyle.MinimizedNoFocus)
			End If
			rsScale.moveNext()
		Loop 
		cnnDB.Execute("UPDATE Scale SET Scale.Scale_Update = False;")
		
	End Sub
	
	Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
		Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
		Dim rs As ADODB.Recordset
		rs = getRS("SELECT * FROM Scale")
		If rs.RecordCount Then
			If rs.Fields("Scale_Update").Value Then
				cmdScale_Click(cmdScale, New System.EventArgs())
			End If
		End If
		
		cnnDB.Execute("INSERT INTO StockItemTalker ( StockItemID ) SELECT DISTINCT POSUpdate_PriceChangeSummary.CatalogueChannelLnk_StockItemID FROM StockItemTalker RIGHT JOIN POSUpdate_PriceChangeSummary ON StockItemTalker.StockItemID = POSUpdate_PriceChangeSummary.CatalogueChannelLnk_StockItemID WHERE (((StockItemTalker.StockItemID) Is Null) AND ((POSUpdate_PriceChangeSummary.CatalogueChannelLnk_ChannelID)=1));")
		cnnDB.Execute("INSERT INTO POSCatalogue ( POSCatalogue_StockItemID, POSCatalogue_Quantity, POSCatalogue_Barcode, POSCatalogue_Deposit, POSCatalogue_Content ) SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, Catalogue.Catalogue_Barcode, Catalogue.Catalogue_Deposit, Catalogue.Catalogue_Content FROM Catalogue LEFT JOIN POSCatalogue ON (Catalogue.Catalogue_StockItemID = POSCatalogue.POSCatalogue_StockItemID) AND (Catalogue.Catalogue_Quantity = POSCatalogue.POSCatalogue_Quantity) WHERE (((POSCatalogue.POSCatalogue_StockItemID) Is Null) AND ((Catalogue.Catalogue_Disabled)=0));")
		cnnDB.Execute("INSERT INTO POSCatalogueChannelLnk ( POSCatalogueChannelLnk_StockItemID, POSCatalogueChannelLnk_ChannelID, POSCatalogueChannelLnk_Quantity, POSCatalogueChannelLnk_Price ) SELECT CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price FROM CatalogueChannelLnk LEFT JOIN POSCatalogueChannelLnk ON (CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID) AND (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity) AND (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID) WHERE (((POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID) Is Null));")
		cnnDB.Execute("UPDATE POSCatalogueChannelLnk INNER JOIN (CatalogueChannelLnk INNER JOIN systemStockItemPricing ON CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = systemStockItemPricing.systemStockItemPricing) ON (POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) AND (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) SET POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price = [CatalogueChannelLnk]![CatalogueChannelLnk_Price];")
		cnnDB.Execute("DELETE tempStockItem.* FROM systemStockItemPricing INNER JOIN tempStockItem ON systemStockItemPricing.systemStockItemPricing = tempStockItem.tempStockItemID;")
		cnnDB.Execute("UPDATE Company SET Company.Company_PosUpdate = 1;")
		
		
		'For Auto UpdatePOS on MonthEnd
		If blMEndUpdatePOS = True Then
			blMEndUpdatePOS = False
		End If
		
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.Close()
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		On Error Resume Next '*Removes the error "Object was unloaded" on Security Access Barcoodes Submenu
		grvPrin = False
		frmBarcode.ShowDialog()
	End Sub
	
	Private Sub frmUpdatePOS_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		loadLanguage()
		
		setup()
		loadSummary()
		
		If blMEndUpdatePOS = True Then
			tmrMEndUpdatePOS.Enabled = True
		End If
	End Sub
	
	Private Sub frmUpdatePOS_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	Sub AutomaticPOSUpdate()
		setup()
		loadSummary()
		
		Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
		Dim rs As ADODB.Recordset
		rs = getRS("SELECT * FROM Scale")
		If rs.RecordCount Then
			If rs.Fields("Scale_Update").Value Then
				cmdScale_Click(cmdScale, New System.EventArgs())
			End If
		End If
		cnnDB.Execute("INSERT INTO StockItemTalker ( StockItemID ) SELECT DISTINCT POSUpdate_PriceChangeSummary.CatalogueChannelLnk_StockItemID FROM StockItemTalker RIGHT JOIN POSUpdate_PriceChangeSummary ON StockItemTalker.StockItemID = POSUpdate_PriceChangeSummary.CatalogueChannelLnk_StockItemID WHERE (((StockItemTalker.StockItemID) Is Null) AND ((POSUpdate_PriceChangeSummary.CatalogueChannelLnk_ChannelID)=1));")
		cnnDB.Execute("INSERT INTO POSCatalogue ( POSCatalogue_StockItemID, POSCatalogue_Quantity, POSCatalogue_Barcode, POSCatalogue_Deposit, POSCatalogue_Content ) SELECT Catalogue.Catalogue_StockItemID, Catalogue.Catalogue_Quantity, Catalogue.Catalogue_Barcode, Catalogue.Catalogue_Deposit, Catalogue.Catalogue_Content FROM Catalogue LEFT JOIN POSCatalogue ON (Catalogue.Catalogue_StockItemID = POSCatalogue.POSCatalogue_StockItemID) AND (Catalogue.Catalogue_Quantity = POSCatalogue.POSCatalogue_Quantity) WHERE (((POSCatalogue.POSCatalogue_StockItemID) Is Null) AND ((Catalogue.Catalogue_Disabled)=0));")
		cnnDB.Execute("INSERT INTO POSCatalogueChannelLnk ( POSCatalogueChannelLnk_StockItemID, POSCatalogueChannelLnk_ChannelID, POSCatalogueChannelLnk_Quantity, POSCatalogueChannelLnk_Price ) SELECT CatalogueChannelLnk.CatalogueChannelLnk_StockItemID, CatalogueChannelLnk.CatalogueChannelLnk_ChannelID, CatalogueChannelLnk.CatalogueChannelLnk_Quantity, POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price FROM CatalogueChannelLnk LEFT JOIN POSCatalogueChannelLnk ON (CatalogueChannelLnk.CatalogueChannelLnk_ChannelID = POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID) AND (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity) AND (CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID) WHERE (((POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID) Is Null));")
		cnnDB.Execute("UPDATE POSCatalogueChannelLnk INNER JOIN (CatalogueChannelLnk INNER JOIN systemStockItemPricing ON CatalogueChannelLnk.CatalogueChannelLnk_StockItemID = systemStockItemPricing.systemStockItemPricing) ON (POSCatalogueChannelLnk.POSCatalogueChannelLnk_ChannelID = CatalogueChannelLnk.CatalogueChannelLnk_ChannelID) AND (CatalogueChannelLnk.CatalogueChannelLnk_Quantity = POSCatalogueChannelLnk.POSCatalogueChannelLnk_Quantity) AND (POSCatalogueChannelLnk.POSCatalogueChannelLnk_StockItemID = CatalogueChannelLnk.CatalogueChannelLnk_StockItemID) SET POSCatalogueChannelLnk.POSCatalogueChannelLnk_Price = [CatalogueChannelLnk]![CatalogueChannelLnk_Price];")
		cnnDB.Execute("DELETE tempStockItem.* FROM systemStockItemPricing INNER JOIN tempStockItem ON systemStockItemPricing.systemStockItemPricing = tempStockItem.tempStockItemID;")
		cnnDB.Execute("UPDATE Company SET Company.Company_PosUpdate = 1;")
		
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.Close()
		
	End Sub
	
	Private Sub tmrMEndUpdatePOS_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrMEndUpdatePOS.Tick
		If blMEndUpdatePOS = True Then
			tmrMEndUpdatePOS.Enabled = False
			cmdUpdate_Click(cmdUpdate, New System.EventArgs())
		End If
	End Sub
End Class