Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmPOS
	Inherits System.Windows.Forms.Form
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim mbChangedByCode As Boolean
    Dim mvBookMark As Integer
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
	Dim gID As Integer
	Dim k_posID As Integer
	Dim k_posNew As Boolean
	Dim bolLoad As Boolean

    Dim txtFields As New List(Of TextBox)
    Dim txtFloat As New List(Of TextBox)
    Dim txtInteger As New List(Of TextBox)
    Dim chkFields As New List(Of CheckBox)
    Dim lblLic As New List(Of Label)
	Private Sub loadLanguage()
		
		'frmPOS = No Code               [Edit Point Of Sales]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmPOS.Caption = rsLang("LanguageLayoutLnk_Description"): frmPOS.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'lblLic(1) = No Code    -->BLANK!!!
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblLic(1).Caption = rsLang("LanguageLayoutLnk_Description"): lblLic(1).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'lblLic(0) = No Code            [Not Licenced]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then lblLic(0).Caption = rsLang("LanguageLayoutLnk_Description"): lblLic(0).RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1010 'General|Checked
		If rsLang.RecordCount Then _lbl_5.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lbl_5.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lblLabels_1 = No Code         [POS Name]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_1.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblLabels_3 = No Code         [POS IP Address]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_3.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1195 'Disable|Checked
		If rsLang.RecordCount Then _chkFields_2.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _chkFields_2.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lblLabels_5 = No code         [Float]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_5.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 2115 'Warehouse|Checked
		If rsLang.RecordCount Then _lblLabels_6.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : _lblLabels_6.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'_lblLabels_2 = No Code         [POS Number]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_2.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblLabels_4 = No Code         [Last Decleration]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_4.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'_lblLabels_0 = No Code         [Default Keyboard]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then _lblLabels_0.Caption = rsLang("LanguageLayoutLnk_Description"): _lblLabels_0.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Labels1 = No Code              [Kitchen Monitors]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'chkKitchenMonitors = No Code   [Setup this Terminal as a Kitchen Monitor (For Drive thru only)]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then chkKitchenMonitors.Caption = rsLang("LanguageLayoutLnk_Description"): chkKitchenMonitors.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmPOS.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub buildDataControls()
		doDataControl((Me.cmbKeyboard), "SELECT KeyboardLayout.KeyboardLayoutID, KeyboardLayout.KeyboardLayout_Name FROM KeyboardLayout ORDER BY KeyboardLayout_Name", "POS_Keyboard", "KeyboardLayoutID", "KeyboardLayout_Name")
		doDataControl((Me.cmbWH), "SELECT Warehouse.WarehouseID, Warehouse.Warehouse_Name FROM Warehouse ORDER BY WarehouseID", "POS_Warehouse", "WarehouseID", "Warehouse_Name")
	End Sub
	
    Private Sub doDataControl(ByRef dataControl As myDataGridView, ByRef sql As String, ByRef DataField As String, ByRef boundColumn As String, ByRef listField As String)
        Dim rs As ADODB.Recordset
        rs = getRS(sql)
       dataControl.DataSource = rs
        dataControl.DataSource = adoPrimaryRS
        dataControl.DataField = DataField
        dataControl.boundColumn = boundColumn
        dataControl.listField = listField
    End Sub
	Public Sub loadItem(ByRef id As Integer)
        Dim x As Integer
		Dim lCode As String
		Dim leCode As String
		Dim lPassword As String
		
		Dim oText As System.Windows.Forms.TextBox
		Dim oCheck As System.Windows.Forms.CheckBox
		On Error Resume Next
		
		If id Then
			k_posNew = False
			k_posID = id 'Get POS ID...
			adoPrimaryRS = getRS("select * from POS WHERE POSID = " & id)
			
			'new serialization check
			lPassword = LTrim(Replace(frmMenu.lblCompany.Text, "'", ""))
			lPassword = RTrim(Replace(lPassword, " ", ""))
			lPassword = Trim(Replace(lPassword, ".", ""))
			lPassword = LCase(lPassword)
			leCode = ""
			lCode = ""
            For x = 0 To Len(lPassword)
                lCode = Mid(lPassword, x, 1)
                lCode = CStr(Asc(lCode))
                If CDbl(lCode) > 96 And CDbl(lCode) < 123 Then
                    leCode = leCode & Mid(lPassword, x, 1)
                End If
            Next
			lPassword = leCode
			lCode = CStr(adoPrimaryRS.Fields("POS_CID").Value * 135792468)
			leCode = Encrypt(lCode, lPassword)
			For x = 1 To Len(leCode)
				If Asc(Mid(leCode, x, 1)) < 33 Then
					leCode = VB.Left(leCode, x - 1) & Chr(33) & Mid(leCode, x + 1)
				End If
			Next x
			If Split(adoPrimaryRS.Fields("POS_Code").Value, Chr(255))(0) <> leCode Then
				lblLic(1).Visible = True
				lblLic(0).Visible = True
			End If
			'new serialization check
		Else
			k_posNew = True
			adoPrimaryRS = getRS("select * from POS")
			adoPrimaryRS.AddNew()
			Me.Text = Me.Text & " [New record]"
			mbAddNewFlag = True
		End If
		
		setup()
		
        For Each oText In txtFields
            oText.DataBindings.Add(adoPrimaryRS)
            oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize
        Next oText
		If k_posNew = True Then _txtFields_10.Text = strCDKey
        For Each oText In txtInteger
            oText.DataBindings.Add(adoPrimaryRS)
            AddHandler oText.Leave, AddressOf txtInteger_Leave
            'txtInteger_Leave(txtInteger.Item((oText.Index)), New System.EventArgs())
        Next oText
        For Each oText In txtFloat
            oText.DataBindings.Add(adoPrimaryRS)
            If oText.Text = "" Then oText.Text = "0"
            oText.Text = CStr(CDbl(oText.Text) * 100)
            AddHandler oText.Leave, AddressOf txtFloat_Leave
            'txtFloat_Leave(txtFloat.Item((oText.Index)), New System.EventArgs())
        Next oText
		
		bolLoad = True
		If id Then
			If adoPrimaryRS.Fields("POS_KitchenMonitor").Value = True Then
				Me.chkKitchenMonitors.CheckState = System.Windows.Forms.CheckState.Checked : Me.chkKitchenMonitors.Tag = 1
			Else
				Me.chkKitchenMonitors.CheckState = System.Windows.Forms.CheckState.Unchecked : Me.chkKitchenMonitors.Tag = 0
			End If
		End If
		bolLoad = False
		
		'Bind the check boxes to the data provider
        For Each oCheck In chkFields
            oCheck.DataBindings.Add(adoPrimaryRS)
        Next oCheck
		buildDataControls()
		
		On Error Resume Next
		If id Then
		Else
			cmbKeyboard.BoundText = CStr(2)
			cmbWH.BoundText = CStr(2)
		End If
		mbDataChanged = False
		
		loadLanguage()
		ShowDialog()
	End Sub
	
	Private Sub setup()
	End Sub
	
	'UPGRADE_WARNING: Event chkKitchenMonitors.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub chkKitchenMonitors_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If bolLoad = True Then

        Else
            If chkKitchenMonitors.CheckState = 1 Then
                If MsgBox("Are you sure, you want to use this Terminal for Drive Thru OR as a Kitchen Monitor only?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Else
                    chkKitchenMonitors.CheckState = System.Windows.Forms.CheckState.Unchecked
                End If
            End If
        End If
    End Sub
	
    Private Sub cmdLocate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        CommonDialog1Open.FileName = ""
        CommonDialog1Open.ShowDialog()
        If CommonDialog1Open.FileName <> "" Then
            'If AddDSN("4POS", "4POS data", CommonDialog1.FileName, True) Then
            If openSComp(CommonDialog1Open.FileName) Is Nothing Then
                MsgBox("Waitron Database is not valid, Chooose correct database.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, My.Application.Info.Title)
            Else
                _txtInteger_1.Text = Split(LCase(CommonDialog1Open.FileName), "waitron.mdb")(0)
            End If
            'End If
        End If
    End Sub
	
	'UPGRADE_WARNING: Event frmPOS.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub frmPOS_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim cmdLast As New Button
        Dim cmdnext As New Button
        Dim lblStatus As New Label
        On Error Resume Next
        lblStatus.Width = pixelToTwips(Me.Width, True) - 1500
        cmdnext.Left = lblStatus.Width + 700
        cmdLast.Left = cmdnext.Left + 340
    End Sub
    Private Sub frmPOS_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.Escape
                KeyAscii = 0
                System.Windows.Forms.Application.DoEvents()
                '            adoPrimaryRS.Move 0
                cmdClose_Click(cmdClose, New System.EventArgs())
        End Select

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub frmPOS_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs)
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
	
	
    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim oText As New TextBox
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
            For Each oText In Me.txtFloat
                If oText.Text = "" Then oText.Text = "0"
                oText.Text = oText.Text * 100
                'txtFloat_Leave(txtFloat.Item(oText.SelectedIndex), New System.EventArgs())
            Next oText
            mbDataChanged = False
        End If
    End Sub
	
	'UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Function update_Renamed() As Boolean
		On Error GoTo UpdateErr
		Dim lDirty As Boolean
		Dim x As Short
		lDirty = False
		update_Renamed = True
		
		If mbAddNewFlag Then
			adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll)
			adoPrimaryRS.MoveLast() 'move to the new record
		Else
			adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll)
			adoPrimaryRS.MoveLast() 'move to the new record
		End If
		
		mbEditFlag = False
		mbAddNewFlag = False
		mbDataChanged = False
		
		Exit Function
UpdateErr: 
		If Err.Number = CDbl("-2147217900") Then
			MsgBox("POS Number [ " & Val(_txtInteger_0.Text) & " ] exist already, Chooose another number", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OKOnly, My.Application.Info.Title)
			update_Renamed = False
			_txtInteger_0.Focus()
		Else
			MsgBox(Err.Number & Err.Description)
			update_Renamed = False
		End If
	End Function
	
    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim x As Integer
        Dim rs As ADODB.Recordset
        Dim rj As ADODB.Recordset
        Dim lCode As String
        Dim leCode As String
        Dim lPassword As String

        If nwPOS = True Then
            rs = getRS("Select * FROM POS WHERE POS_Name = '" & Trim(_txtFields_1.Text) & "'")
            If rs.RecordCount > 0 Then
                MsgBox("POS Name [ " & _txtFields_1.Text & " ] exist already, Chooose another name", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, My.Application.Info.Title)
                Exit Sub
            End If
            '-------------------------
            rs = getRS("Select * FROM POS WHERE POSID = " & Val(_txtInteger_0.Text))
            If rs.RecordCount > 0 Then
                MsgBox("POS Number [ " & Val(_txtInteger_0.Text) & " ] exist already, Chooose another number", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, My.Application.Info.Title)
                Exit Sub
            End If

            rs = getRS("Select * FROM POS WHERE POS_IPAddress = '" & Trim(_txtFields_3.Text) & "'")
            If rs.RecordCount > 0 Then
                MsgBox("POS IP Address [ " & Trim(_txtFields_3.Text) & " ] exist already, Chooose another IP Address", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, My.Application.Info.Title)
                Exit Sub
            End If
            '-------------------------
        End If

        If _txtFields_1.Text = "" Then
            MsgBox("POS Name cannot be blank, enter Point Of Sale name", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, My.Application.Info.Title)
            Exit Sub
        End If
        If Val(_txtInteger_0.Text) = 0 Then
            MsgBox("Please enter another POS Number other than 0", MsgBoxStyle.Information + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly, My.Application.Info.Title)
            Exit Sub
        End If

        If _txtFields_3.Text = "" Then
            MsgBox("POS IP Address cannot be blank, enter POS IP Address", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.OkOnly, My.Application.Info.Title)
            Exit Sub
        End If


        cmdClose.Focus()
        System.Windows.Forms.Application.DoEvents()

        If update_Renamed() Then
            If k_posNew = False Then
                cnnDB.Execute("UPDATE POS SET POS_KitchenMonitor = " & Val(CStr(Me.chkKitchenMonitors.CheckState)) & " WHERE POSID = " & k_posID)
            Else
                cnnDB.Execute("UPDATE POS SET POS_KitchenMonitor = " & Val(CStr(Me.chkKitchenMonitors.CheckState)) & " WHERE POSID = " & Val(_txtInteger_0.Text))

                rj = getRS("Select Company_Name FROM Company;")
                If rj.RecordCount > 0 Then
                    lPassword = LTrim(Replace(rj.Fields("Company_Name").Value, "'", ""))
                    lPassword = RTrim(Replace(lPassword, " ", ""))
                    lPassword = Trim(Replace(lPassword, ".", ""))
                    lPassword = LCase(lPassword)
                    leCode = ""
                    lCode = ""
                    For x = 1 To Len(lPassword)
                        lCode = Mid(lPassword, x, 1)
                        lCode = CStr(Asc(lCode))
                        If CDbl(lCode) > 96 And CDbl(lCode) < 123 Then
                            leCode = leCode & Mid(lPassword, x, 1)
                        End If
                    Next
                    lPassword = leCode
                    rs = getRS("SELECT * FROM POS WHERE POSID = " & Val(_txtInteger_0.Text) & ";")
                    If rs.RecordCount Then
                        lCode = CStr(rs.Fields("POS_CID").Value * 135792468)
                        leCode = Encrypt(lCode, lPassword)
                        leCode = leCode & Chr(255) & _txtFields_10.Text
                        cnnDB.Execute("UPDATE POS SET POS.POS_Code = '" & Replace(leCode, "'", "''") & "' WHERE POS.POS_CID=" & rs.Fields("POS_CID").Value & ";")
                        'cnnDB.Execute "UPDATE POS SET POS.POS_Code = '" & Replace(leCode, "'", "''") & "' WHERE POSID = " & Val(_txtInteger_0.Text) & ";"
                    End If
                End If
            End If
            nwPOS = False
            Me.Close()
        End If
    End Sub
	
	Private Function getSerialNumber() As String
		Dim fso As New Scripting.FileSystemObject
		Dim fsoFolder As Scripting.Folder
		Dim fsoDrive As Scripting.Drive
		getSerialNumber = ""
		If fso.FolderExists(serverPath) Then
			fsoFolder = fso.GetFolder(serverPath)
			getSerialNumber = CStr(fsoFolder.Drive.SerialNumber)
		End If
	End Function
	
	Private Function Encrypt(ByVal secret As String, ByVal PassWord As String) As String
		Dim l As Integer
		Dim x As Short
		Dim Char_Renamed As String
		l = Len(PassWord)
		For x = 1 To Len(secret)
			Char_Renamed = CStr(Asc(Mid(PassWord, (x Mod l) - l * CShort((x Mod l) = 0), 1)))
			Mid(secret, x, 1) = Chr(Asc(Mid(secret, x, 1)) Xor Char_Renamed)
		Next 
		Encrypt = secret
	End Function
	
	Private Function checkSecurity() As Boolean
		Dim lCode As String
		Dim leCode As String
		Dim lPassword As String
		Dim rs As ADODB.Recordset
		Dim x As Short
		checkSecurity = False
		If openConnection() Then
			rs = getRS("SELECT * From Company")
			If rs.RecordCount Then
				If IsNumeric(rs.Fields("Company_Code").Value) Then
					gSecKey = rs.Fields("Company_Code").Value
					If Len(rs.Fields("Company_Code").Value) = 13 Then
						
						checkSecurity = True
						Exit Function
					End If
				End If
				lPassword = "pospospospos"
				lCode = getSerialNumber
				If lCode = "0" And LCase(VB.Left(serverPath, 3)) <> "c:\" And rs.Fields("Company_Code").Value <> "" Then
					checkSecurity = True
				Else
					leCode = Encrypt(lCode, lPassword)
					For x = 1 To Len(leCode)
						If Asc(Mid(leCode, x, 1)) < 33 Then
							leCode = VB.Left(leCode, x - 1) & Chr(33) & Mid(leCode, x + 1)
						End If
					Next x
					
					If rs.Fields("Company_Code").Value = leCode Then
						'If IsNull(rs("Company_TerminateDate")) Then
						checkSecurity = True
						'Else
						'    If Date > rs("Company_TerminateDate") Then
						'        cnnDB.Execute "UPDATE Company SET Company.Company_Code = '';"
						'        checkSecurity = False
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
	
    Private Sub lblLic_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles lblLic.Click
        Dim lbl As New Label
        lbl = DirectCast(eventSender, Label)
        Dim Index As Integer = GetIndexer(lbl, lblLic)
        Dim rs As ADODB.Recordset
        Dim x As Integer
        Dim rj As ADODB.Recordset
        Dim lCode As String
        Dim leCode As String
        Dim lPassword As String

        If checkSecurity() = True Then
            strCDKey = ""
            If frmPOSCode.setupCode = True Then
                '_txtFields_10.Text = strCDKey
                rj = getRS("Select Company_Name FROM Company;")
                If rj.RecordCount > 0 Then
                    lPassword = LTrim(Replace(rj.Fields("Company_Name").Value, "'", ""))
                    lPassword = RTrim(Replace(lPassword, " ", ""))
                    lPassword = Trim(Replace(lPassword, ".", ""))
                    lPassword = LCase(lPassword)
                    leCode = ""
                    lCode = ""
                    For x = 0 To Len(lPassword)
                        lCode = Mid(lPassword, x, 1)
                        lCode = CStr(Asc(lCode))
                        If CDbl(lCode) > 96 And CDbl(lCode) < 123 Then
                            leCode = leCode & Mid(lPassword, x, 1)
                        End If
                    Next
                    lPassword = leCode
                    rs = getRS("SELECT * FROM POS WHERE POSID = " & Val(_txtInteger_0.Text) & ";")
                    If rs.RecordCount Then
                        lCode = CStr(rs("POS_CID").Value * 135792468)
                        leCode = Encrypt(lCode, lPassword)
                        leCode = leCode & Chr(255) & strCDKey '_txtFields_10.Text
                        cnnDB.Execute("UPDATE POS SET POS.POS_Code = '" & Replace(leCode, "'", "''") & "' WHERE POS.POS_CID=" & rs("POS_CID").Value & ";")

                        strCDKey = ""
                        'cmdClose.SetFocus
                        'cmdClose_Click
                        lblLic(0).Visible = False
                        lblLic(1).Visible = False
                    End If
                End If
            End If
            strCDKey = ""
        Else
            MsgBox("POS units may only be licensed with registered versions of your 4POS system." & vbCrLf & "Please contact your 4POS representative or www.4pos.co.za.", MsgBoxStyle.Critical, "Software is not Registered")
        End If


    End Sub
	
    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) ' Handles txtFields.Enter
        Dim txtbox As New TextBox
        txtbox = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txtbox, txtFields)
        MyGotFocus(txtFields(Index))
    End Sub
    Private Sub txtInteger_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) ' Handles txtInteger.Enter
        Dim txtbox As New TextBox
        txtbox = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txtbox, txtInteger)
        MyGotFocusNumeric(txtInteger(Index))
    End Sub
    Private Sub txtInteger_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) 'Handles txtInteger.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'Dim Index As Short = txtInteger.GetIndex(eventSender)
        MyKeyPress(KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub txtInteger_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtInteger.Leave
        Dim txtbox As New TextBox
        txtbox = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txtbox, txtInteger)
        MyLostFocus(txtInteger(Index), 0)
    End Sub
    Private Sub txtFloat_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtFloat.Enter
        Dim txtbox As New TextBox
        txtbox = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txtbox, txtFloat)
        MyGotFocusNumeric(txtFloat(Index))
    End Sub
    Private Sub txtFloat_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) 'Handles txtFloat.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'Dim Index As Short = txtFloat.GetIndex(eventSender)
        MyKeyPress(KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub txtFloat_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) 'Handles txtFloat.Leave
        Dim txtbox As New TextBox
        txtbox = DirectCast(eventSender, TextBox)
        Dim Index As Integer = GetIndexer(txtbox, txtFloat)
        MyLostFocus(txtFloat(Index), 2)
    End Sub
    Private Sub txtFloatNegative_MyGotFocus(ByRef Index As Short)
        'MyGotFocusNumeric txtFloatNegative(Index)
    End Sub
	Private Sub txtFloatNegative_KeyPress(ByRef Index As Short, ByRef KeyAscii As Short)
		'KeyPressNegative txtFloatNegative(Index), KeyAscii
	End Sub
	Private Sub txtFloatNegative_MyLostFocus(ByRef Index As Short)
		'LostFocus txtFloatNegative(Index), 2
	End Sub

    Private Sub frmPOS_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtFloat.AddRange(New TextBox() {_txtFloat_5})
        AddHandler _txtFloat_5.Enter, AddressOf txtFloat_Enter
        AddHandler _txtFloat_5.KeyPress, AddressOf txtFloat_KeyPress
        txtInteger.AddRange(New TextBox() {_txtInteger_0, _txtInteger_1, _txtInteger_4})
        txtFields.AddRange(New TextBox() {_txtFields_1, _txtFields_3, _txtFields_10})
        chkFields.AddRange(New CheckBox() {_chkFields_2})
        lblLic.AddRange(New Label() {_lblLic_0, _lblLic_1})
        Dim tb As New TextBox
        Dim lb As New Label
        For Each tb In txtInteger
            AddHandler tb.Enter, AddressOf txtInteger_Enter
            AddHandler tb.KeyPress, AddressOf txtInteger_KeyPress
        Next
        For Each tb In txtFields
            AddHandler tb.Enter, AddressOf txtFields_Enter
        Next
        For Each lb In lblLic
            AddHandler lb.Click, AddressOf lblLic_Click
        Next
    End Sub
End Class