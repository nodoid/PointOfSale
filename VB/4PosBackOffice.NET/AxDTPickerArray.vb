'UPGRADE_WARNING: The entire project must be compiled once before a form with an ActiveX Control Array can be displayed

Imports System.ComponentModel

<ProvideProperty("Index",GetType(AxMSComCtl2.AxDTPicker))> Public Class AxDTPickerArray
	Inherits Microsoft.VisualBasic.Compatibility.VB6.BaseOcxArray
	Implements IExtenderProvider

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(ByVal Container As IContainer)
		MyBase.New(Container)
	End Sub

	Public Shadows Event [CallbackKeyDown] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_CallbackKeyDown)
	Public Shadows Event [Change] (ByVal sender As System.Object, ByVal e As System.EventArgs)
	Public Shadows Event [CloseUp] (ByVal sender As System.Object, ByVal e As System.EventArgs)
	Public Shadows Event [DropDown] (ByVal sender As System.Object, ByVal e As System.EventArgs)
	Public Shadows Event [FormatEvent] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_FormatEvent)
	Public Shadows Event [FormatSize] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_FormatSizeEvent)
	Public Shadows Event [ClickEvent] (ByVal sender As System.Object, ByVal e As System.EventArgs)
	Public Shadows Event [DblClick] (ByVal sender As System.Object, ByVal e As System.EventArgs)
	Public Shadows Event [KeyDown] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_KeyDown)
	Public Shadows Event [KeyUpEvent] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_KeyUpEvent)
	Public Shadows Event [KeyPress] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_KeyPress)
	Public Shadows Event [MouseDown] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_MouseDown)
	Public Shadows Event [MouseMoveEvent] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_MouseMoveEvent)
	Public Shadows Event [MouseUpEvent] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_MouseUpEvent)
	Public Shadows Event [OLEStartDrag] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_OLEStartDragEvent)
	Public Shadows Event [OLEGiveFeedback] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_OLEGiveFeedbackEvent)
	Public Shadows Event [OLESetData] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_OLESetDataEvent)
	Public Shadows Event [OLECompleteDrag] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_OLECompleteDragEvent)
	Public Shadows Event [OLEDragOver] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_OLEDragOverEvent)
	Public Shadows Event [OLEDragDrop] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_OLEDragDropEvent)

	<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Function CanExtend(ByVal target As Object) As Boolean Implements IExtenderProvider.CanExtend
		If TypeOf target Is AxMSComCtl2.AxDTPicker Then
			Return BaseCanExtend(target)
		End If
	End Function

	Public Function GetIndex(ByVal o As AxMSComCtl2.AxDTPicker) As Short
		Return BaseGetIndex(o)
	End Function

	<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Sub SetIndex(ByVal o As AxMSComCtl2.AxDTPicker, ByVal Index As Short)
		BaseSetIndex(o, Index)
	End Sub

	<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Function ShouldSerializeIndex(ByVal o As AxMSComCtl2.AxDTPicker) As Boolean
		Return BaseShouldSerializeIndex(o)
	End Function

	<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Sub ResetIndex(ByVal o As AxMSComCtl2.AxDTPicker)
		BaseResetIndex(o)
	End Sub

	Default Public ReadOnly Property Item(ByVal Index As Short) As AxMSComCtl2.AxDTPicker
		Get
			Item = CType(BaseGetItem(Index), AxMSComCtl2.AxDTPicker)
		End Get
	End Property

	Protected Overrides Function GetControlInstanceType() As System.Type
		Return GetType(AxMSComCtl2.AxDTPicker)
	End Function

	Protected Overrides Sub HookUpControlEvents(ByVal o As Object)
		Dim ctl As AxMSComCtl2.AxDTPicker = CType(o, AxMSComCtl2.AxDTPicker)
		MyBase.HookUpControlEvents(o)
		If Not CallbackKeyDown Is Nothing Then
			AddHandler ctl.CallbackKeyDown, New AxMSComCtl2.DDTPickerEvents_CallbackKeyDownHandler(AddressOf HandleCallbackKeyDown)
		End If
		If Not ChangeEvent Is Nothing Then
			AddHandler ctl.Change, New System.EventHandler(AddressOf HandleChange)
		End If
		If Not CloseUpEvent Is Nothing Then
			AddHandler ctl.CloseUp, New System.EventHandler(AddressOf HandleCloseUp)
		End If
		If Not DropDownEvent Is Nothing Then
			AddHandler ctl.DropDown, New System.EventHandler(AddressOf HandleDropDown)
		End If
		If Not FormatEventEvent Is Nothing Then
			AddHandler ctl.FormatEvent, New AxMSComCtl2.DDTPickerEvents_FormatEventHandler(AddressOf HandleFormatEvent)
		End If
		If Not FormatSizeEvent Is Nothing Then
			AddHandler ctl.FormatSize, New AxMSComCtl2.DDTPickerEvents_FormatSizeEventHandler(AddressOf HandleFormatSize)
		End If
		If Not ClickEventEvent Is Nothing Then
			AddHandler ctl.ClickEvent, New System.EventHandler(AddressOf HandleClickEvent)
		End If
		If Not DblClickEvent Is Nothing Then
			AddHandler ctl.DblClick, New System.EventHandler(AddressOf HandleDblClick)
		End If
		If Not KeyDownEvent Is Nothing Then
			AddHandler ctl.KeyDown, New AxMSComCtl2.DDTPickerEvents_KeyDownHandler(AddressOf HandleKeyDown)
		End If
		If Not KeyUpEventEvent Is Nothing Then
			AddHandler ctl.KeyUpEvent, New AxMSComCtl2.DDTPickerEvents_KeyUpEventHandler(AddressOf HandleKeyUpEvent)
		End If
		If Not KeyPressEvent Is Nothing Then
			AddHandler ctl.KeyPress, New AxMSComCtl2.DDTPickerEvents_KeyPressHandler(AddressOf HandleKeyPress)
		End If
		If Not MouseDownEvent Is Nothing Then
			AddHandler ctl.MouseDown, New AxMSComCtl2.DDTPickerEvents_MouseDownHandler(AddressOf HandleMouseDown)
		End If
		If Not MouseMoveEventEvent Is Nothing Then
			AddHandler ctl.MouseMoveEvent, New AxMSComCtl2.DDTPickerEvents_MouseMoveEventHandler(AddressOf HandleMouseMoveEvent)
		End If
		If Not MouseUpEventEvent Is Nothing Then
			AddHandler ctl.MouseUpEvent, New AxMSComCtl2.DDTPickerEvents_MouseUpEventHandler(AddressOf HandleMouseUpEvent)
		End If
		If Not OLEStartDragEvent Is Nothing Then
			AddHandler ctl.OLEStartDrag, New AxMSComCtl2.DDTPickerEvents_OLEStartDragEventHandler(AddressOf HandleOLEStartDrag)
		End If
		If Not OLEGiveFeedbackEvent Is Nothing Then
			AddHandler ctl.OLEGiveFeedback, New AxMSComCtl2.DDTPickerEvents_OLEGiveFeedbackEventHandler(AddressOf HandleOLEGiveFeedback)
		End If
		If Not OLESetDataEvent Is Nothing Then
			AddHandler ctl.OLESetData, New AxMSComCtl2.DDTPickerEvents_OLESetDataEventHandler(AddressOf HandleOLESetData)
		End If
		If Not OLECompleteDragEvent Is Nothing Then
			AddHandler ctl.OLECompleteDrag, New AxMSComCtl2.DDTPickerEvents_OLECompleteDragEventHandler(AddressOf HandleOLECompleteDrag)
		End If
		If Not OLEDragOverEvent Is Nothing Then
			AddHandler ctl.OLEDragOver, New AxMSComCtl2.DDTPickerEvents_OLEDragOverEventHandler(AddressOf HandleOLEDragOver)
		End If
		If Not OLEDragDropEvent Is Nothing Then
			AddHandler ctl.OLEDragDrop, New AxMSComCtl2.DDTPickerEvents_OLEDragDropEventHandler(AddressOf HandleOLEDragDrop)
		End If
	End Sub

	Private Sub HandleCallbackKeyDown (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_CallbackKeyDown) 
		RaiseEvent [CallbackKeyDown] (sender, e)
	End Sub

	Private Sub HandleChange (ByVal sender As System.Object, ByVal e As System.EventArgs) 
		RaiseEvent [Change] (sender, e)
	End Sub

	Private Sub HandleCloseUp (ByVal sender As System.Object, ByVal e As System.EventArgs) 
		RaiseEvent [CloseUp] (sender, e)
	End Sub

	Private Sub HandleDropDown (ByVal sender As System.Object, ByVal e As System.EventArgs) 
		RaiseEvent [DropDown] (sender, e)
	End Sub

	Private Sub HandleFormatEvent (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_FormatEvent) 
		RaiseEvent [FormatEvent] (sender, e)
	End Sub

	Private Sub HandleFormatSize (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_FormatSizeEvent) 
		RaiseEvent [FormatSize] (sender, e)
	End Sub

	Private Sub HandleClickEvent (ByVal sender As System.Object, ByVal e As System.EventArgs) 
		RaiseEvent [ClickEvent] (sender, e)
	End Sub

	Private Sub HandleDblClick (ByVal sender As System.Object, ByVal e As System.EventArgs) 
		RaiseEvent [DblClick] (sender, e)
	End Sub

	Private Sub HandleKeyDown (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_KeyDown) 
		RaiseEvent [KeyDown] (sender, e)
	End Sub

	Private Sub HandleKeyUpEvent (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_KeyUpEvent) 
		RaiseEvent [KeyUpEvent] (sender, e)
	End Sub

	Private Sub HandleKeyPress (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_KeyPress) 
		RaiseEvent [KeyPress] (sender, e)
	End Sub

	Private Sub HandleMouseDown (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_MouseDown) 
		RaiseEvent [MouseDown] (sender, e)
	End Sub

	Private Sub HandleMouseMoveEvent (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_MouseMoveEvent) 
		RaiseEvent [MouseMoveEvent] (sender, e)
	End Sub

	Private Sub HandleMouseUpEvent (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_MouseUpEvent) 
		RaiseEvent [MouseUpEvent] (sender, e)
	End Sub

	Private Sub HandleOLEStartDrag (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_OLEStartDragEvent) 
		RaiseEvent [OLEStartDrag] (sender, e)
	End Sub

	Private Sub HandleOLEGiveFeedback (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_OLEGiveFeedbackEvent) 
		RaiseEvent [OLEGiveFeedback] (sender, e)
	End Sub

	Private Sub HandleOLESetData (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_OLESetDataEvent) 
		RaiseEvent [OLESetData] (sender, e)
	End Sub

	Private Sub HandleOLECompleteDrag (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_OLECompleteDragEvent) 
		RaiseEvent [OLECompleteDrag] (sender, e)
	End Sub

	Private Sub HandleOLEDragOver (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_OLEDragOverEvent) 
		RaiseEvent [OLEDragOver] (sender, e)
	End Sub

	Private Sub HandleOLEDragDrop (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DDTPickerEvents_OLEDragDropEvent) 
		RaiseEvent [OLEDragDrop] (sender, e)
	End Sub

End Class

