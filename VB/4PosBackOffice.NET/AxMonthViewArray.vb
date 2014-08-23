'UPGRADE_WARNING: The entire project must be compiled once before a form with an ActiveX Control Array can be displayed

Imports System.ComponentModel

<ProvideProperty("Index",GetType(System.Windows.Forms.MonthCalendar))> Public Class AxMonthViewArray
	Inherits Microsoft.VisualBasic.Compatibility.VB6.BaseOcxArray
	Implements IExtenderProvider

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(ByVal Container As IContainer)
		MyBase.New(Container)
	End Sub

	Public Shadows Event [DateClick] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_DateClickEvent)
	Public Shadows Event [DateDblClick] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_DateDblClickEvent)
	Public Shadows Event [GetDayBold] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_GetDayBoldEvent)
	Public Shadows Event [SelChange] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_SelChangeEvent)
	Public Shadows Event [ClickEvent] (ByVal sender As System.Object, ByVal e As System.EventArgs)
	Public Shadows Event [DblClick] (ByVal sender As System.Object, ByVal e As System.EventArgs)
	Public Shadows Event [KeyDown] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_KeyDown)
	Public Shadows Event [KeyUpEvent] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_KeyUpEvent)
	Public Shadows Event [KeyPress] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_KeyPress)
	Public Shadows Event [MouseDown] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_MouseDown)
	Public Shadows Event [MouseMoveEvent] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_MouseMoveEvent)
	Public Shadows Event [MouseUpEvent] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_MouseUpEvent)
	Public Shadows Event [OLEStartDrag] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_OLEStartDragEvent)
	Public Shadows Event [OLEGiveFeedback] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_OLEGiveFeedbackEvent)
	Public Shadows Event [OLESetData] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_OLESetDataEvent)
	Public Shadows Event [OLECompleteDrag] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_OLECompleteDragEvent)
	Public Shadows Event [OLEDragOver] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_OLEDragOverEvent)
	Public Shadows Event [OLEDragDrop] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_OLEDragDropEvent)

	<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Function CanExtend(ByVal target As Object) As Boolean Implements IExtenderProvider.CanExtend
		If TypeOf target Is System.Windows.Forms.MonthCalendar Then
			Return BaseCanExtend(target)
		End If
	End Function

	Public Function GetIndex(ByVal o As System.Windows.Forms.MonthCalendar) As Short
		Return BaseGetIndex(o)
	End Function

	<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Sub SetIndex(ByVal o As System.Windows.Forms.MonthCalendar, ByVal Index As Short)
		BaseSetIndex(o, Index)
	End Sub

	<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Function ShouldSerializeIndex(ByVal o As System.Windows.Forms.MonthCalendar) As Boolean
		Return BaseShouldSerializeIndex(o)
	End Function

	<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Sub ResetIndex(ByVal o As System.Windows.Forms.MonthCalendar)
		BaseResetIndex(o)
	End Sub

	Default Public ReadOnly Property Item(ByVal Index As Short) As System.Windows.Forms.MonthCalendar
		Get
			Item = CType(BaseGetItem(Index), System.Windows.Forms.MonthCalendar)
		End Get
	End Property

	Protected Overrides Function GetControlInstanceType() As System.Type
		Return GetType(System.Windows.Forms.MonthCalendar)
	End Function

	Protected Overrides Sub HookUpControlEvents(ByVal o As Object)
		Dim ctl As System.Windows.Forms.MonthCalendar = CType(o, System.Windows.Forms.MonthCalendar)
		MyBase.HookUpControlEvents(o)
		If Not DateClickEvent Is Nothing Then
			AddHandler ctl.DateClick, New AxMSComCtl2.DMonthViewEvents_DateClickEventHandler(AddressOf HandleDateClick)
		End If
		If Not DateDblClickEvent Is Nothing Then
			AddHandler ctl.DateDblClick, New AxMSComCtl2.DMonthViewEvents_DateDblClickEventHandler(AddressOf HandleDateDblClick)
		End If
		If Not GetDayBoldEvent Is Nothing Then
			AddHandler ctl.GetDayBold, New AxMSComCtl2.DMonthViewEvents_GetDayBoldEventHandler(AddressOf HandleGetDayBold)
		End If
		If Not SelChangeEvent Is Nothing Then
			AddHandler ctl.SelChange, New AxMSComCtl2.DMonthViewEvents_SelChangeEventHandler(AddressOf HandleSelChange)
		End If
		If Not ClickEventEvent Is Nothing Then
			AddHandler ctl.ClickEvent, New System.EventHandler(AddressOf HandleClickEvent)
		End If
		If Not DblClickEvent Is Nothing Then
			AddHandler ctl.DblClick, New System.EventHandler(AddressOf HandleDblClick)
		End If
		If Not KeyDownEvent Is Nothing Then
			AddHandler ctl.KeyDown, New AxMSComCtl2.DMonthViewEvents_KeyDownHandler(AddressOf HandleKeyDown)
		End If
		If Not KeyUpEventEvent Is Nothing Then
			AddHandler ctl.KeyUpEvent, New AxMSComCtl2.DMonthViewEvents_KeyUpEventHandler(AddressOf HandleKeyUpEvent)
		End If
		If Not KeyPressEvent Is Nothing Then
			AddHandler ctl.KeyPress, New AxMSComCtl2.DMonthViewEvents_KeyPressHandler(AddressOf HandleKeyPress)
		End If
		If Not MouseDownEvent Is Nothing Then
			AddHandler ctl.MouseDown, New AxMSComCtl2.DMonthViewEvents_MouseDownHandler(AddressOf HandleMouseDown)
		End If
		If Not MouseMoveEventEvent Is Nothing Then
			AddHandler ctl.MouseMoveEvent, New AxMSComCtl2.DMonthViewEvents_MouseMoveEventHandler(AddressOf HandleMouseMoveEvent)
		End If
		If Not MouseUpEventEvent Is Nothing Then
			AddHandler ctl.MouseUpEvent, New AxMSComCtl2.DMonthViewEvents_MouseUpEventHandler(AddressOf HandleMouseUpEvent)
		End If
		If Not OLEStartDragEvent Is Nothing Then
			AddHandler ctl.OLEStartDrag, New AxMSComCtl2.DMonthViewEvents_OLEStartDragEventHandler(AddressOf HandleOLEStartDrag)
		End If
		If Not OLEGiveFeedbackEvent Is Nothing Then
			AddHandler ctl.OLEGiveFeedback, New AxMSComCtl2.DMonthViewEvents_OLEGiveFeedbackEventHandler(AddressOf HandleOLEGiveFeedback)
		End If
		If Not OLESetDataEvent Is Nothing Then
			AddHandler ctl.OLESetData, New AxMSComCtl2.DMonthViewEvents_OLESetDataEventHandler(AddressOf HandleOLESetData)
		End If
		If Not OLECompleteDragEvent Is Nothing Then
			AddHandler ctl.OLECompleteDrag, New AxMSComCtl2.DMonthViewEvents_OLECompleteDragEventHandler(AddressOf HandleOLECompleteDrag)
		End If
		If Not OLEDragOverEvent Is Nothing Then
			AddHandler ctl.OLEDragOver, New AxMSComCtl2.DMonthViewEvents_OLEDragOverEventHandler(AddressOf HandleOLEDragOver)
		End If
		If Not OLEDragDropEvent Is Nothing Then
			AddHandler ctl.OLEDragDrop, New AxMSComCtl2.DMonthViewEvents_OLEDragDropEventHandler(AddressOf HandleOLEDragDrop)
		End If
	End Sub

	Private Sub HandleDateClick (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_DateClickEvent) 
		RaiseEvent [DateClick] (sender, e)
	End Sub

	Private Sub HandleDateDblClick (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_DateDblClickEvent) 
		RaiseEvent [DateDblClick] (sender, e)
	End Sub

	Private Sub HandleGetDayBold (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_GetDayBoldEvent) 
		RaiseEvent [GetDayBold] (sender, e)
	End Sub

	Private Sub HandleSelChange (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_SelChangeEvent) 
		RaiseEvent [SelChange] (sender, e)
	End Sub

	Private Sub HandleClickEvent (ByVal sender As System.Object, ByVal e As System.EventArgs) 
		RaiseEvent [ClickEvent] (sender, e)
	End Sub

	Private Sub HandleDblClick (ByVal sender As System.Object, ByVal e As System.EventArgs) 
		RaiseEvent [DblClick] (sender, e)
	End Sub

	Private Sub HandleKeyDown (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_KeyDown) 
		RaiseEvent [KeyDown] (sender, e)
	End Sub

	Private Sub HandleKeyUpEvent (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_KeyUpEvent) 
		RaiseEvent [KeyUpEvent] (sender, e)
	End Sub

	Private Sub HandleKeyPress (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_KeyPress) 
		RaiseEvent [KeyPress] (sender, e)
	End Sub

	Private Sub HandleMouseDown (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_MouseDown) 
		RaiseEvent [MouseDown] (sender, e)
	End Sub

	Private Sub HandleMouseMoveEvent (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_MouseMoveEvent) 
		RaiseEvent [MouseMoveEvent] (sender, e)
	End Sub

	Private Sub HandleMouseUpEvent (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_MouseUpEvent) 
		RaiseEvent [MouseUpEvent] (sender, e)
	End Sub

	Private Sub HandleOLEStartDrag (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_OLEStartDragEvent) 
		RaiseEvent [OLEStartDrag] (sender, e)
	End Sub

	Private Sub HandleOLEGiveFeedback (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_OLEGiveFeedbackEvent) 
		RaiseEvent [OLEGiveFeedback] (sender, e)
	End Sub

	Private Sub HandleOLESetData (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_OLESetDataEvent) 
		RaiseEvent [OLESetData] (sender, e)
	End Sub

	Private Sub HandleOLECompleteDrag (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_OLECompleteDragEvent) 
		RaiseEvent [OLECompleteDrag] (sender, e)
	End Sub

	Private Sub HandleOLEDragOver (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_OLEDragOverEvent) 
		RaiseEvent [OLEDragOver] (sender, e)
	End Sub

	Private Sub HandleOLEDragDrop (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DMonthViewEvents_OLEDragDropEvent) 
		RaiseEvent [OLEDragDrop] (sender, e)
	End Sub

End Class

