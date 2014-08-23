Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmMaintainWeight
	Inherits System.Windows.Forms.Form
	Dim bEditFlag As Short
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim mbChangedByCode As Boolean
    Dim mvBookMark As Integer
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
	Dim blHandHeld As Boolean
	Dim gFilter As String
	Dim gFilterSQL As String
	Dim gID As Integer
	
	Private Sub loadLanguage()
		
		'frmMaintainWeight = No Code    [Maintain Scale Weight Codes]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmMaintainWeight.Caption = rsLang("LanguageLayoutLnk_Description"): frmMaintainWeight.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1065 'New|Checked
		If rsLang.RecordCount Then cmdNew.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdNew.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'cmdCancel = No Code            [Cancel]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdCancel.Caption = rsLang("LanguageLayoutLnk_Description"): cmdCancel.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmMaintainWeight.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Sub loadItem(ByRef id As Integer)
		Dim oText As System.Windows.Forms.TextBox
		Dim rs As ADODB.Recordset
		
		gID = id
		If id Then
			'Set adoPrimaryRS = getRS("SELECT * FROM WeightCodes")
			'adoPrimaryRS.AddNew
			Me.Text = Me.Text & " [New record]"
			'mbAddNewFlag = True
			Frame1.Visible = False
			Exit Sub
			
		Else
			getNamespace()
			mbDataChanged = False
		End If
		
		loadLanguage()
		ShowDialog()
		
	End Sub
	Private Sub getNamespace()
		Dim rs As ADODB.Recordset
		Dim rj As ADODB.Recordset
		
		adoPrimaryRS = getRS("SELECT * FROM WeightCodes")
		'Display the list of Titles in the DataCombo
		grdDataGrid.DataSource = adoPrimaryRS
		
        grdDataGrid.Columns(0).HeaderText = "ScalePrefix"
        grdDataGrid.Columns(0).DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft
        grdDataGrid.Columns(0).Width = twipsToPixels(1000, True)
        grdDataGrid.Columns(0).Frozen = False
		
        grdDataGrid.Columns(1).HeaderText = "Barcode"
        grdDataGrid.Columns(1).DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft
        grdDataGrid.Columns(1).Width = twipsToPixels(1000, True)
        grdDataGrid.Columns(1).Frozen = False
		
        grdDataGrid.Columns(2).HeaderText = "Check Digit"
        grdDataGrid.Columns(2).DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft
        grdDataGrid.Columns(2).Width = twipsToPixels(1000, True)
        grdDataGrid.Columns(2).DefaultCellStyle.Format = 1
        grdDataGrid.Columns(2).Frozen = False
		
        grdDataGrid.Columns(3).HeaderText = "Price"
        grdDataGrid.Columns(3).DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgRight
        grdDataGrid.Columns(3).Width = twipsToPixels(1000, True)
        grdDataGrid.Columns(3).Frozen = False
		
        grdDataGrid.Columns(4).HeaderText = "Decimals"
        grdDataGrid.Columns(4).DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgRight
        grdDataGrid.Columns(4).Width = twipsToPixels(1000, True)
        grdDataGrid.Columns(4).Frozen = False
		
		frmMaintainWeight_Resize(Me, New System.EventArgs())
		mbDataChanged = False
		
	End Sub
	Private Sub cmdNew_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNew.Click
		Frame1.Visible = False
		cmdNew.Enabled = False
		loadItem(1)
		
	End Sub
	Private Sub frmMaintainWeight_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		On Error Resume Next
		'This will resize the grid when the form is resized
		System.Windows.Forms.Application.DoEvents()
        grdDataGrid.Height = twipsToPixels(2685, False)
		'grdDataGrid.Columns(1).Width = grdDataGrid.Width - 5000
		
	End Sub
	Private Sub frmMaintainWeight_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 27 Then
			KeyAscii = 0
			cmdClose_Click(cmdClose, New System.EventArgs())
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub frmMaintainWeight_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
	End Sub
	Private Sub adoPrimaryRS_MoveComplete(ByVal adReason As ADODB.EventReasonEnum, ByVal pError As ADODB.Error, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.MoveComplete
		'This will display the current record position for this recordset
	End Sub
	Private Sub adoPrimaryRS_WillChangeRecord(ByVal adReason As ADODB.EventReasonEnum, ByVal cRecords As Integer, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.WillChangeRecord
		Dim lQuantity As Integer
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
		cmdNew.Enabled = True
		
		mbEditFlag = False
		mbAddNewFlag = False
		adoPrimaryRS.CancelUpdate()
		If mvBookMark > 0 Then
			adoPrimaryRS.Bookmark = mvBookMark
		Else
			adoPrimaryRS.MoveFirst()
		End If
		mbDataChanged = False
		
	End Sub
	Private Sub update_Renamed()
		On Error GoTo UpdateErr
		
		adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll)
		If mbAddNewFlag Then
			adoPrimaryRS.MoveLast() 'Move to the new record
		End If
		mbEditFlag = False
		mbAddNewFlag = False
		mbDataChanged = False
		
		Exit Sub
UpdateErr: 
		MsgBox(Err.Description)
	End Sub
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Dim sql As String
		
		If gID = 1 Then 'Add new Record
			'Verify....
            If Val(Me._txtFields_4.Text) > 1 Then
                MsgBox("Check digit can only be 0 or 1", MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkOnly + MsgBoxStyle.Information, My.Application.Info.Title)

                Exit Sub
            End If
			sql = "INSERT INTO WeightCodes (ScalePrefix,barCode,CheckDigit,PriceLength,NrDecimals) VALUES ( '" & Me._txtFields_0.Text & "'," & Val(Me._txtFields_1.Text) & "," & Val(Me._txtFields_4.Text) & "," & Val(Me._txtFields_2.Text) & "," & Val(Me._txtFields_3.Text) & ")"
			cnnDB.Execute(sql)
			Me.Close()
		Else
			update_Renamed()
			Me.Close()
		End If
		
	End Sub
	Private Sub goFirst()
		On Error GoTo GoFirstError
		
		adoPrimaryRS.MoveFirst()
		mbDataChanged = False
		Exit Sub
		
GoFirstError: 
		MsgBox(Err.Description)
	End Sub
	Private Sub goLast()
		On Error GoTo GoLastError
		adoPrimaryRS.MoveLast()
		mbDataChanged = False
		Exit Sub
		
GoLastError: 
		MsgBox(Err.Description)
	End Sub
    Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) 'Handles txtFields.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'Dim Index As Short = txtFields.GetIndex(eventSender)

        If IsNumeric(Chr(KeyAscii)) Then

        Else
            If KeyAscii = 49 Or KeyAscii = 13 Or KeyAscii = 8 Then
            Else
                KeyAscii = 0
            End If
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
End Class