using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using DpSdkEngLib;
using DPSDKOPSLib;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
//UPGRADE_WARNING: The entire project must be compiled once before a form with an ActiveX Control Array can be displayed

using System.ComponentModel;
namespace _4PosBackOffice.NET
{

	[ProvideProperty("Index", typeof(AxMSComCtl2.AxDTPicker))]
	public class AxDTPickerArray : Microsoft.VisualBasic.Compatibility.VB6.BaseOcxArray, IExtenderProvider
	{

		public AxDTPickerArray() : base()
		{
		}

		public AxDTPickerArray(IContainer Container) : base(Container)
		{
		}

		public new event CallbackKeyDownEventHandler CallbackKeyDown;
		public new delegate void CallbackKeyDownEventHandler(System.Object sender, AxMSComCtl2.DDTPickerEvents_CallbackKeyDown e);
		public new event ChangeEventHandler Change;
		public new delegate void ChangeEventHandler(System.Object sender, System.EventArgs e);
		public new event CloseUpEventHandler CloseUp;
		public new delegate void CloseUpEventHandler(System.Object sender, System.EventArgs e);
		public new event DropDownEventHandler DropDown;
		public new delegate void DropDownEventHandler(System.Object sender, System.EventArgs e);
		public new event FormatEventEventHandler FormatEvent;
		public new delegate void FormatEventEventHandler(System.Object sender, AxMSComCtl2.DDTPickerEvents_FormatEvent e);
		public new event FormatSizeEventHandler FormatSize;
		public new delegate void FormatSizeEventHandler(System.Object sender, AxMSComCtl2.DDTPickerEvents_FormatSizeEvent e);
		public new event ClickEventEventHandler ClickEvent;
		public new delegate void ClickEventEventHandler(System.Object sender, System.EventArgs e);
		public new event DblClickEventHandler DblClick;
		public new delegate void DblClickEventHandler(System.Object sender, System.EventArgs e);
		public new event KeyDownEventHandler KeyDown;
		public new delegate void KeyDownEventHandler(System.Object sender, AxMSComCtl2.DDTPickerEvents_KeyDown e);
		public new event KeyUpEventEventHandler KeyUpEvent;
		public new delegate void KeyUpEventEventHandler(System.Object sender, AxMSComCtl2.DDTPickerEvents_KeyUpEvent e);
		public new event KeyPressEventHandler KeyPress;
		public new delegate void KeyPressEventHandler(System.Object sender, AxMSComCtl2.DDTPickerEvents_KeyPress e);
		public new event MouseDownEventHandler MouseDown;
		public new delegate void MouseDownEventHandler(System.Object sender, AxMSComCtl2.DDTPickerEvents_MouseDown e);
		public new event MouseMoveEventEventHandler MouseMoveEvent;
		public new delegate void MouseMoveEventEventHandler(System.Object sender, AxMSComCtl2.DDTPickerEvents_MouseMoveEvent e);
		public new event MouseUpEventEventHandler MouseUpEvent;
		public new delegate void MouseUpEventEventHandler(System.Object sender, AxMSComCtl2.DDTPickerEvents_MouseUpEvent e);
		public new event OLEStartDragEventHandler OLEStartDrag;
		public new delegate void OLEStartDragEventHandler(System.Object sender, AxMSComCtl2.DDTPickerEvents_OLEStartDragEvent e);
		public new event OLEGiveFeedbackEventHandler OLEGiveFeedback;
		public new delegate void OLEGiveFeedbackEventHandler(System.Object sender, AxMSComCtl2.DDTPickerEvents_OLEGiveFeedbackEvent e);
		public new event OLESetDataEventHandler OLESetData;
		public new delegate void OLESetDataEventHandler(System.Object sender, AxMSComCtl2.DDTPickerEvents_OLESetDataEvent e);
		public new event OLECompleteDragEventHandler OLECompleteDrag;
		public new delegate void OLECompleteDragEventHandler(System.Object sender, AxMSComCtl2.DDTPickerEvents_OLECompleteDragEvent e);
		public new event OLEDragOverEventHandler OLEDragOver;
		public new delegate void OLEDragOverEventHandler(System.Object sender, AxMSComCtl2.DDTPickerEvents_OLEDragOverEvent e);
		public new event OLEDragDropEventHandler OLEDragDrop;
		public new delegate void OLEDragDropEventHandler(System.Object sender, AxMSComCtl2.DDTPickerEvents_OLEDragDropEvent e);

		[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
		public bool CanExtend(object target)
		{
			if (target is AxMSComCtl2.AxDTPicker) {
				return BaseCanExtend(target);
			}
		}

		public short GetIndex(AxMSComCtl2.AxDTPicker o)
		{
			return BaseGetIndex(o);
		}

		[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
		public void SetIndex(AxMSComCtl2.AxDTPicker o, short Index)
		{
			BaseSetIndex(o, Index);
		}

		[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
		public bool ShouldSerializeIndex(AxMSComCtl2.AxDTPicker o)
		{
			return BaseShouldSerializeIndex(o);
		}

		[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
		public void ResetIndex(AxMSComCtl2.AxDTPicker o)
		{
			BaseResetIndex(o);
		}

		public AxMSComCtl2.AxDTPicker this[short Index] {
			get { return (AxMSComCtl2.AxDTPicker)BaseGetItem(Index); }
		}

		protected override System.Type GetControlInstanceType()
		{
			return typeof(AxMSComCtl2.AxDTPicker);
		}

		protected override void HookUpControlEvents(object o)
		{
			AxMSComCtl2.AxDTPicker ctl = (AxMSComCtl2.AxDTPicker)o;
			base.HookUpControlEvents(o);
			if ((CallbackKeyDown != null)) {
				ctl.CallbackKeyDown += new AxMSComCtl2.DDTPickerEvents_CallbackKeyDownHandler(HandleCallbackKeyDown);
			}
			if ((ChangeEvent != null)) {
				ctl.Change += new System.EventHandler(HandleChange);
			}
			if ((CloseUpEvent != null)) {
				ctl.CloseUp += new System.EventHandler(HandleCloseUp);
			}
			if ((DropDownEvent != null)) {
				ctl.DropDown += new System.EventHandler(HandleDropDown);
			}
			if ((FormatEventEvent != null)) {
				ctl.FormatEvent += new AxMSComCtl2.DDTPickerEvents_FormatEventHandler(HandleFormatEvent);
			}
			if ((FormatSizeEvent != null)) {
				ctl.FormatSize += new AxMSComCtl2.DDTPickerEvents_FormatSizeEventHandler(HandleFormatSize);
			}
			if ((ClickEventEvent != null)) {
				ctl.ClickEvent += new System.EventHandler(HandleClickEvent);
			}
			if ((DblClickEvent != null)) {
				ctl.DblClick += new System.EventHandler(HandleDblClick);
			}
			if ((KeyDownEvent != null)) {
				ctl.KeyDown += new AxMSComCtl2.DDTPickerEvents_KeyDownHandler(HandleKeyDown);
			}
			if ((KeyUpEventEvent != null)) {
				ctl.KeyUpEvent += new AxMSComCtl2.DDTPickerEvents_KeyUpEventHandler(HandleKeyUpEvent);
			}
			if ((KeyPressEvent != null)) {
				ctl.KeyPress += new AxMSComCtl2.DDTPickerEvents_KeyPressHandler(HandleKeyPress);
			}
			if ((MouseDownEvent != null)) {
				ctl.MouseDown += new AxMSComCtl2.DDTPickerEvents_MouseDownHandler(HandleMouseDown);
			}
			if ((MouseMoveEventEvent != null)) {
				ctl.MouseMoveEvent += new AxMSComCtl2.DDTPickerEvents_MouseMoveEventHandler(HandleMouseMoveEvent);
			}
			if ((MouseUpEventEvent != null)) {
				ctl.MouseUpEvent += new AxMSComCtl2.DDTPickerEvents_MouseUpEventHandler(HandleMouseUpEvent);
			}
			if ((OLEStartDragEvent != null)) {
				ctl.OLEStartDrag += new AxMSComCtl2.DDTPickerEvents_OLEStartDragEventHandler(HandleOLEStartDrag);
			}
			if ((OLEGiveFeedbackEvent != null)) {
				ctl.OLEGiveFeedback += new AxMSComCtl2.DDTPickerEvents_OLEGiveFeedbackEventHandler(HandleOLEGiveFeedback);
			}
			if ((OLESetDataEvent != null)) {
				ctl.OLESetData += new AxMSComCtl2.DDTPickerEvents_OLESetDataEventHandler(HandleOLESetData);
			}
			if ((OLECompleteDragEvent != null)) {
				ctl.OLECompleteDrag += new AxMSComCtl2.DDTPickerEvents_OLECompleteDragEventHandler(HandleOLECompleteDrag);
			}
			if ((OLEDragOverEvent != null)) {
				ctl.OLEDragOver += new AxMSComCtl2.DDTPickerEvents_OLEDragOverEventHandler(HandleOLEDragOver);
			}
			if ((OLEDragDropEvent != null)) {
				ctl.OLEDragDrop += new AxMSComCtl2.DDTPickerEvents_OLEDragDropEventHandler(HandleOLEDragDrop);
			}
		}

		private void HandleCallbackKeyDown(System.Object sender, AxMSComCtl2.DDTPickerEvents_CallbackKeyDown e)
		{
			if (CallbackKeyDown != null) {
				CallbackKeyDown(sender, e);
			}
		}

		private void HandleChange(System.Object sender, System.EventArgs e)
		{
			if (Change != null) {
				Change(sender, e);
			}
		}

		private void HandleCloseUp(System.Object sender, System.EventArgs e)
		{
			if (CloseUp != null) {
				CloseUp(sender, e);
			}
		}

		private void HandleDropDown(System.Object sender, System.EventArgs e)
		{
			if (DropDown != null) {
				DropDown(sender, e);
			}
		}

		private void HandleFormatEvent(System.Object sender, AxMSComCtl2.DDTPickerEvents_FormatEvent e)
		{
			if (FormatEvent != null) {
				FormatEvent(sender, e);
			}
		}

		private void HandleFormatSize(System.Object sender, AxMSComCtl2.DDTPickerEvents_FormatSizeEvent e)
		{
			if (FormatSize != null) {
				FormatSize(sender, e);
			}
		}

		private void HandleClickEvent(System.Object sender, System.EventArgs e)
		{
			if (ClickEvent != null) {
				ClickEvent(sender, e);
			}
		}

		private void HandleDblClick(System.Object sender, System.EventArgs e)
		{
			if (DblClick != null) {
				DblClick(sender, e);
			}
		}

		private void HandleKeyDown(System.Object sender, AxMSComCtl2.DDTPickerEvents_KeyDown e)
		{
			if (KeyDown != null) {
				KeyDown(sender, e);
			}
		}

		private void HandleKeyUpEvent(System.Object sender, AxMSComCtl2.DDTPickerEvents_KeyUpEvent e)
		{
			if (KeyUpEvent != null) {
				KeyUpEvent(sender, e);
			}
		}

		private void HandleKeyPress(System.Object sender, AxMSComCtl2.DDTPickerEvents_KeyPress e)
		{
			if (KeyPress != null) {
				KeyPress(sender, e);
			}
		}

		private void HandleMouseDown(System.Object sender, AxMSComCtl2.DDTPickerEvents_MouseDown e)
		{
			if (MouseDown != null) {
				MouseDown(sender, e);
			}
		}

		private void HandleMouseMoveEvent(System.Object sender, AxMSComCtl2.DDTPickerEvents_MouseMoveEvent e)
		{
			if (MouseMoveEvent != null) {
				MouseMoveEvent(sender, e);
			}
		}

		private void HandleMouseUpEvent(System.Object sender, AxMSComCtl2.DDTPickerEvents_MouseUpEvent e)
		{
			if (MouseUpEvent != null) {
				MouseUpEvent(sender, e);
			}
		}

		private void HandleOLEStartDrag(System.Object sender, AxMSComCtl2.DDTPickerEvents_OLEStartDragEvent e)
		{
			if (OLEStartDrag != null) {
				OLEStartDrag(sender, e);
			}
		}

		private void HandleOLEGiveFeedback(System.Object sender, AxMSComCtl2.DDTPickerEvents_OLEGiveFeedbackEvent e)
		{
			if (OLEGiveFeedback != null) {
				OLEGiveFeedback(sender, e);
			}
		}

		private void HandleOLESetData(System.Object sender, AxMSComCtl2.DDTPickerEvents_OLESetDataEvent e)
		{
			if (OLESetData != null) {
				OLESetData(sender, e);
			}
		}

		private void HandleOLECompleteDrag(System.Object sender, AxMSComCtl2.DDTPickerEvents_OLECompleteDragEvent e)
		{
			if (OLECompleteDrag != null) {
				OLECompleteDrag(sender, e);
			}
		}

		private void HandleOLEDragOver(System.Object sender, AxMSComCtl2.DDTPickerEvents_OLEDragOverEvent e)
		{
			if (OLEDragOver != null) {
				OLEDragOver(sender, e);
			}
		}

		private void HandleOLEDragDrop(System.Object sender, AxMSComCtl2.DDTPickerEvents_OLEDragDropEvent e)
		{
			if (OLEDragDrop != null) {
				OLEDragDrop(sender, e);
			}
		}

	}
}

