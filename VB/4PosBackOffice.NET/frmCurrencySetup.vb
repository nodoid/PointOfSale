Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmCurrencySetup
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
		
		'frmCurrencySetup = No Code     [Currency Setup]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmCurrency.Caption = rsLang("LanguageLayoutLnk_Description"): frmCurrency.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'Label1 = No Code               [Available Currencies]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdNew = No Code               [Add New]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdNew.Caption = rsLang("LanguageLayoutLnk_Description"): cmdNew.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'cmdSave = No Code              [Save]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then cmdSave.Caption = rsLang("LanguageLayoutLnk_Description"): cmdSave.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1148 'Delete|Checked
		If rsLang.RecordCount Then cmdDelete.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdDelete.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmCurrencySetup.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Public Sub loadItem(ByRef id As Integer)
		'If id Then Else Exit Sub
		gID = id
		getNamespace()
		
		mbDataChanged = False
		
		loadLanguage()
		ShowDialog()
	End Sub
	Private Sub getNamespace()
		Dim rs As ADODB.Recordset
		Dim rj As ADODB.Recordset
		
		adoPrimaryRS = getRS("SELECT * FROM PresetCurrency")
		
		'Display the list of Titles in the DataCombo
		grdDataGrid.DataSource = adoPrimaryRS
		
        grdDataGrid.Columns(0).HeaderText = "ID"
        grdDataGrid.Columns(0).DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft
        grdDataGrid.Columns(0).Width = twipsToPixels(700, True)
        grdDataGrid.Columns(0).Frozen = True
		grdDataGrid.Columns(0).Visible = False
		
        grdDataGrid.Columns(1).HeaderText = "Curreny Name"
        grdDataGrid.Columns(1).DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft
        grdDataGrid.Columns(1).Width = twipsToPixels(1590.124, True)
        grdDataGrid.Columns(1).Frozen = True
		
		
        grdDataGrid.Columns(2).HeaderText = "Curreny Symbol"
        grdDataGrid.Columns(2).DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft
        grdDataGrid.Columns(2).Width = twipsToPixels(1590.124, True)
        grdDataGrid.Columns(2).DefaultCellStyle.Format = StdFormat.FormatType.fmtCustom
        grdDataGrid.Columns(2).Frozen = False

        grdDataGrid.Columns(3).HeaderText = "Exchange Rate"
        grdDataGrid.Columns(3).DefaultCellStyle.Alignment = MSDataGridLib.AlignmentConstants.dbgRight
        grdDataGrid.Columns(3).Width = twipsToPixels(1590.124, True)
        grdDataGrid.Columns(3).Frozen = False
		
		
		frmCurrencySetup_Resize(Me, New System.EventArgs())
		mbDataChanged = False
		
	End Sub
	
	Private Sub cmdDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDelete.Click
		Dim sqlD As String
		'a = grdDataGrid.Col
		'a = grdDataGrid.Columns(0).Text
        If MsgBox("Are you sure you want to delete " & grdDataGrid.Columns(1).HeaderText & " Currency Information?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            sqlD = "Delete FROM PresetCurrency where CurrencyID = " & grdDataGrid.Columns(0).HeaderText
            cnnDB.Execute(sqlD)

            getNamespace()
            grdDataGrid.CtlRefresh()
        End If
	End Sub
	
	Private Sub cmdNew_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNew.Click
		
		Dim rj As ADODB.Recordset
		rj = getRS("SELECT * FROM PresetCurrency")
		
		If rj.RecordCount >= 4 Then
			MsgBox(" You can only be able to Maintain 4 Currencies at a time, If you want to Add more please Delete one of the Currency you don't need at this time ")
		Else
			
            grdDataGrid.Columns(1).Frozen = False
			grdDataGrid.AllowAddNew = True
			grdDataGrid.Focus()
			'grdDataGrid.AddNewMode
			If rj.RecordCount <= 0 Then
				'grdDataGrid.row = -1 ' rj.RecordCount + 1
			Else
				grdDataGrid.row = rj.RecordCount + 1
			End If
			
			'grdDataGrid.Columns(0).Text = rj.RecordCount + 1
			
			cmdSave.Enabled = True
			
			cmdNew.Enabled = False
			cmdDelete.Enabled = False
			'grdDataGrid.SelStartCol = 1
			'grdDataGrid.SelEndCol = 1
		End If
		
	End Sub
	
	Private Sub cmdSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSave.Click
		update_Renamed()
		getNamespace()
		'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		grdDataGrid.CtlRefresh()
		
        grdDataGrid.Columns(1).Frozen = True
		grdDataGrid.AllowAddNew = False
		
		cmdSave.Enabled = False
		
		cmdNew.Enabled = True
		cmdDelete.Enabled = True
	End Sub
	
	Private Sub frmCurrencySetup_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		On Error Resume Next
		'This will resize the grid when the form is resized
		System.Windows.Forms.Application.DoEvents()
		'grdDataGrid.Height = 2685
		'grdDataGrid.Columns(1).Width = grdDataGrid.Width - 5000
		
	End Sub
    Private Sub frmCurrencySetup_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	
	Private Sub frmCurrencySetup_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
	End Sub
	
	Private Sub adoPrimaryRS_MoveComplete(ByVal adReason As ADODB.EventReasonEnum, ByVal pError As ADODB.Error, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.MoveComplete
		'This will display the current record position for this recordset
	End Sub
	
	Private Sub adoPrimaryRS_WillChangeRecord(ByVal adReason As ADODB.EventReasonEnum, ByVal cRecords As Integer, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.WillChangeRecord
    End Sub
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		On Error Resume Next
		
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
		update_Renamed()
		Me.Close()
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
	
    Private Sub grdDataGrid_CellValueChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles grdDataGrid.CurrentCellChanged
        '    If grdDataGrid.Columns(ColIndex).DataFormat.Format = "#,##0.00" Then
        '       grdDataGrid.Columns(ColIndex).DataFormat = 0
        '    End If

    End Sub
End Class