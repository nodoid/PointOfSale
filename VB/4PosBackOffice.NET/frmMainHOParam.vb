Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmMainHOParam
	Inherits System.Windows.Forms.Form
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim gID As Integer
    Dim mvBookMark As Integer
	Dim mbChangedByCode As Boolean
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
	Dim loading As Boolean
	Dim g_Emails As Boolean
	
	
	Public Sub loadItem()
		Dim rj As ADODB.Recordset
		Dim oCheck As System.Windows.Forms.CheckBox
		
		adoPrimaryRS = getRS("SELECT Company_HOParamBit FROM Company")
		
		Const gReOrderLvl As Short = 1
		Const gEmployeePer As Short = 2
		Const gWaitronCount As Short = 4
		Const gActualCost As Short = 8
		Const gPromotion As Short = 16
		Const gRecipe As Short = 32
		
		On Error Resume Next
		'Bind the check boxes to the data provider
		Me._chkBit_1.CheckState = System.Math.Abs(CInt(CBool(adoPrimaryRS.Fields("Company_HOParamBit").Value And gReOrderLvl)))
		Me._chkBit_2.CheckState = System.Math.Abs(CInt(CBool(adoPrimaryRS.Fields("Company_HOParamBit").Value And gEmployeePer)))
		Me._chkBit_3.CheckState = System.Math.Abs(CInt(CBool(adoPrimaryRS.Fields("Company_HOParamBit").Value And gWaitronCount)))
		Me._chkBit_4.CheckState = System.Math.Abs(CInt(CBool(adoPrimaryRS.Fields("Company_HOParamBit").Value And gActualCost)))
		Me._chkBit_5.CheckState = System.Math.Abs(CInt(CBool(adoPrimaryRS.Fields("Company_HOParamBit").Value And gPromotion)))
		Me._chkBit_6.CheckState = System.Math.Abs(CInt(CBool(adoPrimaryRS.Fields("Company_HOParamBit").Value And gRecipe)))
		
		ShowDialog()
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		cmdClose.Focus()
		System.Windows.Forms.Application.DoEvents()
		
		If update_Renamed() Then
			Me.Close()
		End If
	End Sub
	
	Private Sub frmMainHOParam_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
	Private Sub frmMainHOParam_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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
		Dim lDirty As Boolean
		Dim x As Short
		Dim lBit As Short
		Const gReOrderLvl As Short = 1
		Const gEmployeePer As Short = 2
		Const gWaitronCount As Short = 4
		Const gActualCost As Short = 8
		Const gPromotion As Short = 16
		Const gRecipe As Short = 32
		
		lDirty = False
		update_Renamed = True
		
		If Me._chkBit_1.CheckState Then lBit = lBit + gReOrderLvl
		If Me._chkBit_2.CheckState Then lBit = lBit + gEmployeePer
		If Me._chkBit_3.CheckState Then lBit = lBit + gWaitronCount
		If Me._chkBit_4.CheckState Then lBit = lBit + gActualCost
		If Me._chkBit_5.CheckState Then lBit = lBit + gPromotion
		If Me._chkBit_6.CheckState Then lBit = lBit + gRecipe
		
		adoPrimaryRS.Fields("Company_HOParamBit").Value = lBit
		
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
End Class