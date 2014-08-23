Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Imports CrystalDecisions
Friend Class frmIncrement
	Inherits System.Windows.Forms.Form
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim mbChangedByCode As Boolean
    Dim mvBookMark As Integer
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean

    Dim chkFields As New List(Of CheckBox)
    Dim txtFields As New List(Of TextBox)
    Dim txtInteger As New List(Of TextBox)

	Dim gID As Integer
	
	Private Sub loadLanguage()
		
		'frmIncrement = No Code     [Edit Increment Details]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmIncrement.Caption = rsLang("LanguageLayoutLnk_Description"): frmIncrement.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1085 'Print|Checked
		If rsLang.RecordCount Then cmdPrint.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdPrint.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1010 'General|Checked
        If rsLang.RecordCount Then _lbl_5.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_5.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lblLabels(38) = No Code    [Increment Name]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblLabels(38).Caption = rsLang("LanguageLayoutLnk_Description"): lblLabels(38).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2145 'Shrink Size|Checked
        If rsLang.RecordCount Then _lblLabels_9.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_9.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2463 'Disabled|Checked
        If rsLang.RecordCount Then _chkFields_0.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _chkFields_0.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
        '_lbl_2 = No Code
        'NOTE: Caption Grammar incorrect!
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then _lbl_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
        '_chkFields_1 = No Code/Dynamic!
        '_chkFields_2 = No Code/Dynamic!
        '_chkFields_3 = No Code/Dynamic!
        '_chkFields_4 = No Code/Dynamic!
        '_chkFields_5 = No Code/Dynamic!
        '_chkFields_6 = No Code/Dynamic!
        '_chkFields_7 = No Code/Dynamic!
        '_chkFields_8 = No Code/Dynamic!
        '_chkFields_9 = No Code/Dynamic!
		
        '_lbl_0 = No Code           [Quantities and Price]
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then _lbl_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1147 'Add|Checked
		If rsLang.RecordCount Then cmdAdd.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdAdd.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1148 'Delete|Checked
		If rsLang.RecordCount Then cmdDelete.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdDelete.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
        '_lbl_1 = No Code           [Stock Items]
        'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
        'If rsLang.RecordCount Then _lbl_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lbl_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1147 'Add|Checked
		If rsLang.RecordCount Then cmdAddStock.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdAddStock.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1148 'Delete|Checked
		If rsLang.RecordCount Then cmdDelStock.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdDelStock.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub buildDataControls()
		'    doDataControl Me.cmbChannel, "SELECT ChannelID, Channel_Name FROM Channel ORDER BY ChannelID", "Customer_ChannelID", "ChannelID", "Channel_Name"
	End Sub
	
    Private Sub doDataControl(ByRef dataControl As myDataGridView, ByRef sql As String, ByRef DataField As String, ByRef boundColumn As String, ByRef listField As String)
        'Dim rs As ADODB.Recordset
        'rs = getRS(sql)
        'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'dataControl.DataSource = rs
        'dataControl.DataSource = adoPrimaryRS
        'dataControl.DataField = DataField
        'dataControl.boundColumn = boundColumn
        'dataControl.listField = listField
    End Sub
	
	Public Sub loadItem(ByRef id As Integer)
		Dim oText As System.Windows.Forms.TextBox
        Dim oDate As New DateTimePicker
		Dim oCheck As System.Windows.Forms.CheckBox
		On Error Resume Next
		
		Dim rs As ADODB.Recordset
		rs = getRS("SELECT * FROM Channel")
		Do Until rs.EOF
            chkFields(rs.Fields("ChannelID").Value).Text = rs.Fields("ChannelID").Value & ". " & rs.Fields("Channel_Code").Value
			rs.moveNext()
		Loop 
		rs.Close()
		
		
		If id Then
			adoPrimaryRS = getRS("select Increment.* from Increment WHERE IncrementID = " & id)
		Else
			adoPrimaryRS = getRS("select * from Increment")
			adoPrimaryRS.AddNew()
			Me.Text = Me.Text & " [New record]"
			mbAddNewFlag = True
		End If
		setup()
		For	Each oText In Me.txtFields
			oText.DataBindings.Add(adoPrimaryRS)
			oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize
		Next oText
		
		For	Each oText In Me.txtInteger
            oText.DataBindings.Add(adoPrimaryRS)
            AddHandler oText.Leave, AddressOf txtInteger_Leave
			'txtInteger_Leave(txtInteger.Item((oText.TabIndex)), New System.EventArgs())
		Next oText
		'    For Each oText In Me.txtInteger
		'        Set oText.DataBindings.Add(adoPrimaryRS)
		'        txtInteger_LostFocus oText.Index
		'    Next
		'    For Each oText In Me.txtFloat
		'        Set oText.DataBindings.Add(adoPrimaryRS)
		'        If oText.Text = "" Then oText.Text = "0"
		'        oText.Text = oText.Text * 100
		'        txtFloat_LostFocus oText.Index
		'    Next
		'    For Each oText In Me.txtFloatNegative
		'        Set oText.DataBindings.Add(adoPrimaryRS)
		'        If oText.Text = "" Then oText.Text = "0"
		'        oText.Text = oText.Text * 100
		'        txtFloatNegative_LostFocus oText.Index
		'    Next
		'Bind the check boxes to the data provider
        For Each oCheck In chkFields
            oCheck.DataBindings.Add(adoPrimaryRS)
        Next oCheck
		buildDataControls()
		mbDataChanged = False
		gID = id
		If gID Then
			loadItems()
		End If
		
		loadLanguage()
		ShowDialog()
	End Sub
	
	Private Sub setup()
	End Sub
	
	Private Sub cmdAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAdd.Click
        update_Renamed()
        frmIncrementQuantity.loadItem(adoPrimaryRS.Fields("IncrementID").Value, 0)
        loadItems()
    End Sub
	
	Private Sub cmdAddStock_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAddStock.Click
		Dim lID As Integer
		
		lID = frmStockList.getItem
		If lID <> 0 Then
			cnnDB.Execute("DELETE IncrementStockItemLnk.* From IncrementStockItemLnk WHERE (((IncrementStockItemLnk.IncrementStockItemLnk_IncrementID)=" & adoPrimaryRS.Fields("IncrementID").Value & ") AND ((IncrementStockItemLnk.IncrementStockItemLnk_StockItemID)=" & lID & "));")
			cnnDB.Execute("INSERT INTO IncrementStockItemLnk ( IncrementStockItemLnk_IncrementID, IncrementStockItemLnk_StockItemID ) SELECT " & adoPrimaryRS.Fields("IncrementID").Value & ", " & lID & ";")
			loadItems()
		End If
		
	End Sub
	
	Private Sub cmdDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDelete.Click
        Dim lQty As String
		Dim lID As Integer
		If lvItem.FocusedItem Is Nothing Then
		Else
			If MsgBox("Are you sure you wish to remove the " & lvItem.FocusedItem.Text & " quantity from this Increment?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "DELETE") = MsgBoxResult.Yes Then
				lID = CInt(Split(lvItem.FocusedItem.Name, "_")(0))
				lQty = Split(lvItem.FocusedItem.Name, "_")(1)
				cnnDB.Execute("DELETE IncrementQuantity.* From IncrementQuantity WHERE (((IncrementQuantity.IncrementQuantity_IncrementID)=" & lID & ") AND ((IncrementQuantity.IncrementQuantity_Quantity)=" & lQty & "));")
				loadItems()
			End If
		End If
		
	End Sub
	
	Private Sub cmdDelStock_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDelStock.Click
        Dim lQty As Integer
        Dim lstock As Integer
		Dim lID As Integer
		If lvItem.FocusedItem Is Nothing Then
		Else
			If MsgBox("Are you sure you wish to remove '" & lvItem.FocusedItem.Text & "' from this Increment?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "DELETE") = MsgBoxResult.Yes Then
				lID = CInt(Split(lvItem.FocusedItem.Name, "_")(0))
				lstock = Split(lvItem.FocusedItem.Name, "_")(1)
				cnnDB.Execute("DELETE IncrementStockItemLnk.* From IncrementStockItemLnk WHERE (((IncrementStockItemLnk.IncrementStockItemLnk_IncrementID)=" & lID & ") AND ((IncrementStockItemLnk.IncrementStockItemLnk_StockItemID)=" & lstock & "));")
				
				cnnDB.Execute("DELETE IncrementQuantity.* From IncrementQuantity WHERE (((IncrementQuantity.IncrementQuantity_IncrementID)=" & lID & ") AND ((IncrementQuantity.IncrementQuantity_Quantity)=" & lQty & "));")
				loadItems()
			End If
		End If
		
	End Sub
	
	Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
		update_Renamed()
		Dim rs As ADODB.Recordset
		Dim rsQty As ADODB.Recordset
		Dim RSitem As ADODB.Recordset
		Dim ltype As Boolean
        'Dim Report As New cryIncrement
        Dim Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryIncrement.rpt")
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		rs = getRS("SELECT * FROM Company")
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
		rs = getRS("SELECT Increment.* FROM Increment;")
        'ReportNone.Load("cryNoRecords.rpt")
        Dim ReportNone As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Report.Load("cryNoRecords.rpt")
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
		rsQty = getRS("SELECT IncrementQuantity.* From IncrementQuantity ORDER BY IncrementQuantity.IncrementQuantity_Quantity;")
		RSitem = getRS("SELECT IncrementStockItemLnk.IncrementStockItemLnk_IncrementID, StockItem.StockItem_Name FROM IncrementStockItemLnk INNER JOIN StockItem ON IncrementStockItemLnk.IncrementStockItemLnk_StockItemID = StockItem.StockItemID ORDER BY StockItem.StockItem_Name;")
		
        Report.Database.Tables(1).SetDataSource(rs)
        Report.Database.Tables(2).SetDataSource(rsQty)
        Report.Database.Tables(3).SetDataSource(RSitem)
		'UPGRADE_WARNING: Couldn't resolve default property of object Report.VerifyOnEveryPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'Report.VerifyOnEveryPrint = True
        frmReportShow.Text = Report.ParameterFields("txtTitle").ToString
		frmReportShow.CRViewer1.ReportSource = Report
		frmReportShow.mReport = Report : frmReportShow.sMode = "0"
		frmReportShow.CRViewer1.Refresh()
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		frmReportShow.ShowDialog()
		
	End Sub
	
	Private Sub frmIncrement_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        txtFields.AddRange(New TextBox() {_txtFields_0})
        txtInteger.AddRange(New TextBox() {_txtInteger_0})
        chkFields.AddRange(New CheckBox() {_chkFields_0, _chkFields_1, _chkFields_2, _
                                          _chkFields_3, _chkFields_4, _chkFields_5, _
                                          _chkFields_6, _chkFields_7, _chkFields_8, _
                                          _chkFields_9})
        Dim tb As New TextBox
        Dim cb As New CheckBox
        For Each tb In txtFields
            AddHandler tb.Enter, AddressOf txtFields_Enter
        Next
        For Each tb In txtInteger
            AddHandler tb.Enter, AddressOf txtInteger_Enter
            AddHandler tb.KeyPress, AddressOf txtInteger_KeyPress
            AddHandler tb.Leave, AddressOf txtInteger_Leave
        Next
        lvItem.Columns.Clear()
        lvItem.Columns.Add("", "QTY", CInt(twipsToPixels(750, True)))
        lvItem.Columns.Add("Price", CInt(twipsToPixels(1240, True)), System.Windows.Forms.HorizontalAlignment.Right)
		
		lvStockItem.Columns.Clear()
        lvStockItem.Columns.Add("", "Stock Item", CInt(twipsToPixels(2900, True)))
	End Sub
	
	Private Sub loadItems()
		Dim listItem As System.Windows.Forms.ListViewItem
		Dim rs As ADODB.Recordset
		lvItem.Items.Clear()
		rs = getRS("SELECT IncrementQuantity.IncrementQuantity_IncrementID, IncrementQuantity.IncrementQuantity_Quantity, IncrementQuantity.IncrementQuantity_Price From IncrementQuantity Where (((IncrementQuantity.IncrementQuantity_IncrementID) = " & adoPrimaryRS.Fields("IncrementID").Value & ")) ORDER BY IncrementQuantity.IncrementQuantity_Quantity;")
		Do Until rs.EOF
			listItem = lvItem.Items.Add(rs.Fields("IncrementQuantity_IncrementID").Value & "_" & rs.Fields("IncrementQuantity_Quantity").Value, rs.Fields("IncrementQuantity_Quantity").Value, "")
			If listItem.SubItems.Count > 0 Then
                listItem.SubItems(0).Text = FormatNumber(rs.Fields("IncrementQuantity_Price").Value, 1)
            Else
                listItem.SubItems.Insert(0, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, FormatNumber(rs.Fields("IncrementQuantity_Price").Value, 1)))
            End If
			
			rs.moveNext()
		Loop 
		
		lvStockItem.Items.Clear()
		rs = getRS("SELECT IncrementStockItemLnk.IncrementStockItemLnk_IncrementID, IncrementStockItemLnk.IncrementStockItemLnk_StockItemID, StockItem.StockItem_Name FROM IncrementStockItemLnk INNER JOIN StockItem ON IncrementStockItemLnk.IncrementStockItemLnk_StockItemID = StockItem.StockItemID Where (((IncrementStockItemLnk.IncrementStockItemLnk_IncrementID) = " & adoPrimaryRS.Fields("IncrementID").Value & ")) ORDER BY StockItem.StockItem_Name;")
		Do Until rs.EOF
			listItem = lvStockItem.Items.Add(rs.Fields("IncrementStockItemLnk_IncrementID").Value & "_" & rs.Fields("IncrementStockItemLnk_StockItemID").Value, rs.Fields("StockItem_Name").Value, "")
			rs.moveNext()
		Loop 
		
	End Sub
	
	Private Sub frmIncrement_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        Dim cmdLast As System.Windows.Forms.Button = New System.Windows.Forms.Button
        Dim cmdNext As System.Windows.Forms.Button = New System.Windows.Forms.Button
        Dim lblStatus As System.Windows.Forms.Label = New System.Windows.Forms.Label
        On Error Resume Next
        lblStatus.Width = pixelToTwips(Me.Width, True) - 1500
        cmdNext.Left = lblStatus.Width + 700
        cmdLast.Left = cmdNext.Left + 340
    End Sub
	
	Private Sub frmIncrement_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If mbEditFlag Or mbAddNewFlag Then GoTo EventExitSub
		
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.Escape
				KeyAscii = 0
				adoPrimaryRS.Move(0)
				
				cmdClose.Focus()
				System.Windows.Forms.Application.DoEvents()
				cmdClose_Click(cmdClose, New System.EventArgs())
		End Select
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub frmIncrement_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
	End Sub
	
	Private Sub adoPrimaryRS_MoveComplete(ByVal adReason As ADODB.EventReasonEnum, ByVal pError As ADODB.Error, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.MoveComplete
		'This will display the current record position for this recordset
	End Sub
	
	Private Sub adoPrimaryRS_WillChangeRecord(ByVal adReason As ADODB.EventReasonEnum, ByVal cRecords As Integer, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.WillChangeRecord
		'This is where you put validation code
		'This event gets called when the following actions occur
		Dim bCancel As Boolean
		Select Case adReason
			Case ADODB.EventReasonEnum.adRsnAddNew
			Case ADODB.EventReasonEnum.adRsnClose
			Case ADODB.EventReasonEnum.adRsnDelete
			Case ADODB.EventReasonEnum.adRsnFirstChange
			Case ADODB.EventReasonEnum.adRsnMove
			Case ADODB.EventReasonEnum.adRsnRequery
			Case ADODB.EventReasonEnum.adRsnResynch
			Case ADODB.EventReasonEnum.adRsnUndoAddNew
			Case ADODB.EventReasonEnum.adRsnUndoDelete
			Case ADODB.EventReasonEnum.adRsnUndoUpdate
			Case ADODB.EventReasonEnum.adRsnUpdate
		End Select
		
		If bCancel Then adStatus = ADODB.EventStatusEnum.adStatusCancel
	End Sub
	
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		On Error Resume Next
		If mbAddNewFlag Then
			Me.Close()
		Else
			mbEditFlag = False
			mbAddNewFlag = False
			adoPrimaryRS.CancelUpdate()
			If mvBookMark > 0 Then
                adoPrimaryRS.Bookmark = mvBookMark
            Else
                adoPrimaryRS.MoveFirst()
            End If
			mbDataChanged = False
		End If
	End Sub
	
    Private Function update_Renamed() As Boolean
        On Error GoTo UpdateErr
        update_Renamed = True
        If mbAddNewFlag Then
            If Me._txtFields_0.Text = "" Then
                update_Renamed = True
                Exit Function
            End If
        End If
        adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll)
        If mbAddNewFlag Then
            adoPrimaryRS.MoveLast() 'move to the new record
        End If

        mbEditFlag = False
        mbAddNewFlag = False
        mbDataChanged = False

        Exit Function
UpdateErr:
        MsgBox(Err.Description)
        update_Renamed = False
    End Function

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        cmdClose.Focus()
        System.Windows.Forms.Application.DoEvents()
        If update_Renamed() Then
            Me.Close()
        End If
    End Sub

    Private Sub lvItem_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvItem.DoubleClick
        Dim lID As Integer
        Dim lQty As Short
        If lvItem.FocusedItem Is Nothing Then
        Else
            lID = CInt(Split(lvItem.FocusedItem.Name, "_")(0))
            lQty = CShort(Split(lvItem.FocusedItem.Name, "_")(1))

            frmIncrementQuantity.loadItem(lID, CShort(lQty))
            loadItems()
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

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'Dim Index As Short = txtFields.GetIndex(eventSender)
        Dim Index As Integer
        Dim m As New TextBox
        Dim n As New TextBox
        n = DirectCast(eventSender, TextBox)
        Index = GetIndexer(n, txtFields)
        MyGotFocus(txtFields(Index))
    End Sub

    Private Sub txtInteger_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'Dim Index As Short = txtInteger.GetIndex(eventSender)
        Dim Index As Integer
        Dim m As New TextBox
        Dim n As New TextBox
        n = DirectCast(eventSender, TextBox)
        Index = GetIndexer(n, txtInteger)
        MyGotFocusNumeric(txtInteger(Index))
    End Sub

    Private Sub txtInteger_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'Dim Index As Short = txtInteger.GetIndex(eventSender)
        MyKeyPress(KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtInteger_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'Dim Index As Short = txtInteger.GetIndex(eventSender)
        Dim Index As Integer
        Dim m As New TextBox
        Dim n As New TextBox
        n = DirectCast(eventSender, TextBox)
        Index = GetIndexer(n, txtInteger)
        MyLostFocus(txtInteger(Index), 0)
    End Sub

    Private Sub txtFloat_MyGotFocus(ByRef Index As Short)
        '    MyGotFocusNumeric txtFloat(Index)
    End Sub

    Private Sub txtFloat_KeyPress(ByRef Index As Short, ByRef KeyAscii As Short)
        '    KeyPress KeyAscii
    End Sub

    Private Sub txtFloat_MyLostFocus(ByRef Index As Short)
        '    MyGotFocusNumeric txtFloat(Index), 2
    End Sub

    Private Sub txtFloatNegative_MyGotFocus(ByRef Index As Short)
        '    MyGotFocusNumeric txtFloatNegative(Index)
    End Sub

    Private Sub txtFloatNegative_KeyPress(ByRef Index As Short, ByRef KeyAscii As Short)
        '    KeyPressNegative txtFloatNegative(Index), KeyAscii
    End Sub

    Private Sub txtFloatNegative_MyLostFocus(ByRef Index As Short)
        '    LostFocus txtFloatNegative(Index), 2
    End Sub
End Class