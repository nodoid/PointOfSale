Option Strict Off
Option Explicit On
Friend Class frmPastelVariables
	Inherits System.Windows.Forms.Form
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
		
		'frmPastelVariables = No Code   [Edit Export Variable]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmPastelVariable.Caption = rsLang("LanguageLayoutLnk_Description"): frmPastelVariables.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'Label1 = No Code               [Note: Account Number.......]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmPastelVariables.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Sub loadItem(ByRef id As Integer)
		
		Dim rs As ADODB.Recordset
		gID = id
		getNamespace()
		
		mbDataChanged = False
		
		loadLanguage()
		ShowDialog()
	End Sub
	Private Sub getNamespace()
		Dim oText As System.Windows.Forms.TextBox
		Dim rs As ADODB.Recordset
		Dim rj As ADODB.Recordset
		
		adoPrimaryRS = getRS("SELECT IDDescription,GDC,Decription1,AccountNumber,Reference,Period FROM PastelDescription")
		
		'Display the list of Titles in the DataCombo
		grdDataGrid.DataSource = adoPrimaryRS
		
        grdDataGrid.Columns(0).HeaderText = "ID No"
        grdDataGrid.Columns(0).DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft
        grdDataGrid.Columns(0).Width = twipsToPixels(800, True)
        grdDataGrid.Columns(0).Frozen = True
		
        grdDataGrid.Columns(1).HeaderText = "GDC"
        grdDataGrid.Columns(1).DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft
        grdDataGrid.Columns(1).Width = twipsToPixels(800, True)
        grdDataGrid.Columns(1).Frozen = True
		
        grdDataGrid.Columns(2).HeaderText = "Decription"
        grdDataGrid.Columns(2).DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft
        grdDataGrid.Columns(2).Width = twipsToPixels(3890.124, True)
        grdDataGrid.Columns(2).Frozen = False
		
        grdDataGrid.Columns(3).HeaderText = "Account Number"
        grdDataGrid.Columns(3).DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft
        grdDataGrid.Columns(3).Width = twipsToPixels(1890.124, True)
        grdDataGrid.Columns(3).DefaultCellStyle.Format = 1
        grdDataGrid.Columns(3).Frozen = False
		
        grdDataGrid.Columns(4).HeaderText = "Reference"
        grdDataGrid.Columns(4).DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgRight
        grdDataGrid.Columns(4).Width = twipsToPixels(1000, True)
        grdDataGrid.Columns(4).DefaultCellStyle.Format = 1
        grdDataGrid.Columns(4).Frozen = False
		
		frmPastelVariables_Resize(Me, New System.EventArgs())
		mbDataChanged = False
		
	End Sub
	Private Sub frmPastelVariables_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ResizeForm(Me, pixelToTwips(Me.Width, True), pixelToTwips(Me.Height, False), 2)
		
	End Sub
	
	'UPGRADE_WARNING: Event frmPastelVariables.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmPastelVariables_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		On Error Resume Next
		'This will resize the grid when the form is resized
		System.Windows.Forms.Application.DoEvents()
        grdDataGrid.Height = twipsToPixels(pixelToTwips(Me.ClientRectangle.Height, False) - 30 - pixelToTwips(picButtons.Height, False), False)
		'grdDataGrid.Columns(1).Width = grdDataGrid.Width
		'grdDataGrid.Columns(1).Width = grdDataGrid.Width - 5000
		
	End Sub
	Private Sub frmPastelVariables_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub frmPastelVariables_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
	End Sub
	
	Private Sub adoPrimaryRS_MoveComplete(ByVal adReason As ADODB.EventReasonEnum, ByVal pError As ADODB.Error, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.MoveComplete
		'This will display the current record position for this recordset
	End Sub
	
	Private Sub adoPrimaryRS_WillChangeRecord(ByVal adReason As ADODB.EventReasonEnum, ByVal cRecords As Integer, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.WillChangeRecord
		Dim lQuantity As Integer
		
		If adoPrimaryRS.Fields("Reference").OriginalValue <> adoPrimaryRS.Fields("Reference").Value Then
			
			'cnndb.Execute "Update PastelDescription Set Narrative ='
		End If
		
		If adoPrimaryRS.Fields("AccountNumber").OriginalValue <> adoPrimaryRS.Fields("AccountNumber").Value Then
			'cnnDB.Execute "Update PastelDescription Set AccountNumber =' "
			
		End If
		
		
	End Sub
	'UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
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
		
		'On Error Resume Next
		'If Val(txtPeriod(0).Text) >= 1 And Val(txtPeriod(0).Text) <= 12 Then
		'   cnnDB.Execute "UPDATE PastelDescription Set Period = " & Val(txtPeriod(0).Text)
		update_Renamed()
		Me.Close()
		'Else
		'   MsgBox "Period Value must be in range of 1 - 12", vbApplicationModal + vbInformation + vbOKOnly, "Pastel Variables"
		'End If
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
	
    'Private Sub grdDataGrid_CellValueChanged(ByVal eventSender As System.Object, ByVal eventArgs As AxMSDataGridLib.DDataGridEvents_CellValueChangedEvent) Handles grdDataGrid.CellValueChanged
    '    If grdDataGrid.Columns(ColIndex).DataFormat.Format = "#,##0.00" Then
    '       grdDataGrid.Columns(ColIndex).DataFormat = 0
    '    End If

    'End Sub
End Class