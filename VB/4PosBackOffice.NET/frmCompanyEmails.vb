Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmCompanyEmails
	Inherits System.Windows.Forms.Form
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim mbChangedByCode As Boolean
    Dim mvBookMark As Integer
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
	Dim loading As Boolean
	Dim gID As Integer
	
	Const bit_deposit1 As Short = 1
	Const bit_deposit2 As Short = 2
	Const bit_Sets As Short = 4
	Const bit_Shrink As Short = 8
	Const bit_Suppress As Short = 16

    Dim txtFields As New List(Of TextBox)

	Private Sub loadLanguage()
		
		'frmCompanyEmails = No Code [Edit Store Emails]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then frmCompanyEmails.Caption = rsLang("LanguageLayoutLnk_Description"): frmCompanyEmails.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1074 'Undo|Checked
		If rsLang.RecordCount Then cmdCancel.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdCancel.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 1004 'Exit|Checked
		If rsLang.RecordCount Then cmdClose.Text = rsLang.Fields("LanguageLayoutLnk_Description").Value : cmdClose.RightToLeft = rsLang.Fields("LanguageLayoutLnk_RightTL").Value
		
		'Label6 = No Code           [Email For Remote Office]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label6.Caption = rsLang("LanguageLayoutLnk_Description"): Label6.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label1 = No Code           [Email No 1]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label1.Caption = rsLang("LanguageLayoutLnk_Description"): Label1.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label2 = No Code           [Email No 2]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label2.Caption = rsLang("LanguageLayoutLnk_Description"): Label2.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label3 = No Code           [Email No 3]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label3.Caption = rsLang("LanguageLayoutLnk_Description"): Label3.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label4 = No Code           [Email No 4]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label4.Caption = rsLang("LanguageLayoutLnk_Description"): Label4.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label5 = No Code           [Email No 5]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label5.Caption = rsLang("LanguageLayoutLnk_Description"): Label5.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label7 = No Code           [Email No 6]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label7.Caption = rsLang("LanguageLayoutLnk_Description"): Label7.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label8 = No Code           [Email No 7]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label8.Caption = rsLang("LanguageLayoutLnk_Description"): Label8.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label9 = No Code           [Company Number]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label9.Caption = rsLang("LanguageLayoutLnk_Description"): Label9.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		'Label10 = No Code          [Company Number]
		'rsLang.filter = "LanguageLayoutLnk_LanguageID=" & 0000
		'If rsLang.RecordCount Then Label10.Caption = rsLang("LanguageLayoutLnk_Description"): Label10.RightToLeft = rsLang("LanguageLayoutLnk_RightTL")
		
		rsHelp.filter = "Help_Section=0 AND Help_Form='" & Me.Name & "'"
		'UPGRADE_ISSUE: Form property frmCompanyEmails.ToolTip1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If rsHelp.RecordCount Then Me.ToolTip1 = rsHelp.Fields("Help_ContextID").Value
		
	End Sub
	
	Private Sub updateBit()
	End Sub
	Private Sub buildDataControls()
	End Sub
    Private Sub doDataControl(ByRef dataControl As myDataGridView, ByRef sql As String, ByRef DataField As String, ByRef boundColumn As String, ByRef listField As String)
        'Dim rs As ADODB.Recordset
        'rs = getRS(sql)
        'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'dataControl.DataBindings.Add(rs)
        'UPGRADE_ISSUE: Control method dataControl.DataSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        'dataControl.DataSource = adoPrimaryRS
        'UPGRADE_ISSUE: Control method dataControl.DataField was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        'dataControl.DataField = DataField
        'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.boundColumn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'dataControl.boundColumn = boundColumn
        'UPGRADE_WARNING: Couldn't resolve default property of object dataControl.listField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'dataControl.listField = listField
    End Sub
	Public Sub loadItem(Optional ByRef bHOLink As Boolean = False)
		Dim rs As ADODB.Recordset
		Dim oText As System.Windows.Forms.TextBox
		Dim oCheck As System.Windows.Forms.CheckBox
		
		'Working 4 Now...
		'Check Data
		CheckEmailsData()
		
		adoPrimaryRS = getRS("SELECT * FROM CompanyEmails")
		
		setup()
		On Error Resume Next
		For	Each oText In Me.txtFields
			oText.DataBindings.Add(adoPrimaryRS)
			oText.MaxLength = adoPrimaryRS.Fields(oText.DataBindings).DefinedSize
		Next oText
		buildDataControls()
		mbDataChanged = False
		
		loadLanguage()
		
		If bHOLink = True Then
			Me.Text = "Edit Head Office link"
			Label6.Text = "1. Head Office link locations"
			
			Label1.Text = "H/Office No.:"
			Label2.Text = "Branch No.:"
			Label3.Text = "-" '"Down Link 2:"
			label4.Text = "-" '"Down Link 3:"
			Label5.Text = "-" '"Down Link 4:"
			Label7.Text = "-" '"Down Link 5:"
			Label8.Text = "-" '"Down Link 6:"
			
			Label9.Text = "2. Headoffice/Branch"
			Label10.Text = "Headoffice = 1    /    Branch = 0"
		End If
		ShowDialog()
	End Sub
	Sub CheckEmailsData()
		Dim rs As ADODB.Recordset
		
		rs = getRS("Select * From CompanyEmails")
		If rs.RecordCount = 0 Then
			cnnDB.Execute("INSERT INTO CompanyEmails (Comp_ID) VALUES (1)")
		End If
	End Sub
	Private Sub setup()
		
	End Sub
	Private Sub frmCompanyEmails_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.Escape
				KeyAscii = 0
				System.Windows.Forms.Application.DoEvents()
				adoPrimaryRS.Move(0)
				cmdClose_Click(cmdClose, New System.EventArgs())
		End Select
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub frmCompanyEmails_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
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
	'UPGRADE_NOTE: update was upgraded to update_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Function update_Renamed() As Boolean
		On Error GoTo UpdateErr
		Dim lDirty As Boolean
		Dim x As Short
		Dim lBit As Short
		lDirty = False
		update_Renamed = True
		
		If mbAddNewFlag Then
			adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll)
			adoPrimaryRS.MoveLast() 'move to the new record
		Else
			adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll)
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
    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Integer
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Index = GetIndexer(txtBox, txtFields)
        If Index = 7 Then MyGotFocusNumeric(txtFields(Index))
    End Sub
    Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Integer
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Index = GetIndexer(txtBox, txtFields)
        If Index = 7 Then MyKeyPress(KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    Private Sub txtFields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Index As Integer
        Dim txtBox As New TextBox
        txtBox = DirectCast(eventSender, TextBox)
        Index = GetIndexer(txtBox, txtFields)
        If Index = 7 Then MyLostFocus(txtFields(Index), 0)
    End Sub

    Private Sub frmCompanyEmails_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtFields.AddRange(New TextBox() {_txtFields_0, _txtFields_1, _txtFields_2, _
                                          _txtFields_3, _txtFields_4, _txtFields_5, _
                                          _txtFields_6, _txtFields_7})
        Dim tb As New TextBox
        For Each tb In txtFields
            AddHandler tb.Enter, AddressOf txtFields_Enter
            AddHandler tb.KeyPress, AddressOf txtFields_KeyPress
            AddHandler tb.Leave, AddressOf txtFields_Leave
        Next

    End Sub
End Class