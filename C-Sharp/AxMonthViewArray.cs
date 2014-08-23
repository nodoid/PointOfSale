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

	[ProvideProperty("Index", typeof(System.Windows.Forms.MonthCalendar))]
	public class AxMonthViewArray : Microsoft.VisualBasic.Compatibility.VB6.BaseOcxArray, IExtenderProvider
	{

		public AxMonthViewArray() : base()
		{
		}

		public AxMonthViewArray(IContainer Container) : base(Container)
		{
		}

		public new event DateClickEventHandler DateClick;
		public new delegate void DateClickEventHandler(System.Object sender, AxMSComCtl2.DMonthViewEvents_DateClickEvent e);
		public new event DateDblClickEventHandler DateDblClick;
		public new delegate void DateDblClickEventHandler(System.Object sender, AxMSComCtl2.DMonthViewEvents_DateDblClickEvent e);
		public new event GetDayBoldEventHandler GetDayBold;
		public new delegate void GetDayBoldEventHandler(System.Object sender, AxMSComCtl2.DMonthViewEvents_GetDayBoldEvent e);
		public new event SelChangeEventHandler SelChange;
		public new delegate void SelChangeEventHandler(System.Object sender, AxMSComCtl2.DMonthViewEvents_SelChangeEvent e);
		public new event ClickEventEventHandler ClickEvent;
		public new delegate void ClickEventEventHandler(System.Object sender, System.EventArgs e);
		public new event DblClickEventHandler DblClick;
		public new delegate void DblClickEventHandler(System.Object sender, System.EventArgs e);
		public new event KeyDownEventHandler KeyDown;
		public new delegate void KeyDownEventHandler(System.Object sender, AxMSComCtl2.DMonthViewEvents_KeyDown e);
		public new event KeyUpEventEventHandler KeyUpEvent;
		public new delegate void KeyUpEventEventHandler(System.Object sender, AxMSComCtl2.DMonthViewEvents_KeyUpEvent e);
		public new event KeyPressEventHandler KeyPress;
		public new delegate void KeyPressEventHandler(System.Object sender, AxMSComCtl2.DMonthViewEvents_KeyPress e);
		public new event MouseDownEventHandler MouseDown;
		public new delegate void MouseDownEventHandler(System.Object sender, AxMSComCtl2.DMonthViewEvents_MouseDown e);
		public new event MouseMoveEventEventHandler MouseMoveEvent;
		public new delegate void MouseMoveEventEventHandler(System.Object sender, AxMSComCtl2.DMonthViewEvents_MouseMoveEvent e);
		public new event MouseUpEventEventHandler MouseUpEvent;
		public new delegate void MouseUpEventEventHandler(System.Object sender, AxMSComCtl2.DMonthViewEvents_MouseUpEvent e);
		public new event OLEStartDragEventHandler OLEStartDrag;
		public new delegate void OLEStartDragEventHandler(System.Object sender, AxMSComCtl2.DMonthViewEvents_OLEStartDragEvent e);
		public new event OLEGiveFeedbackEventHandler OLEGiveFeedback;
		public new delegate void OLEGiveFeedbackEventHandler(System.Object sender, AxMSComCtl2.DMonthViewEvents_OLEGiveFeedbackEvent e);
		public new event OLESetDataEventHandler OLESetData;
		public new delegate void OLESetDataEventHandler(System.Object sender, AxMSComCtl2.DMonthViewEvents_OLESetDataEvent e);
		public new event OLECompleteDragEventHandler OLECompleteDrag;
		public new delegate void OLECompleteDragEventHandler(System.Object sender, AxMSComCtl2.DMonthViewEvents_OLECompleteDragEvent e);
		public new event OLEDragOverEventHandler OLEDragOver;
		public new delegate void OLEDragOverEventHandler(System.Object sender, AxMSComCtl2.DMonthViewEvents_OLEDragOverEvent e);
		public new event OLEDragDropEventHandler OLEDragDrop;
		public new delegate void OLEDragDropEventHandler(System.Object sender, AxMSComCtl2.DMonthViewEvents_OLEDragDropEvent e);

		[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
		public bool CanExtend(object target)
		{
			if (target is System.Windows.Forms.MonthCalendar) {
				return BaseCanExtend(target);
			}
		}

		public short GetIndex(System.Windows.Forms.MonthCalendar o)
		{
			return BaseGetIndex(o);
		}

		[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
		public void SetIndex(System.Windows.Forms.MonthCalendar o, short Index)
		{
			BaseSetIndex(o, Index);
		}

		[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
		public bool ShouldSerializeIndex(System.Windows.Forms.MonthCalendar o)
		{
			return BaseShouldSerializeIndex(o);
		}

		[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
		public void ResetIndex(System.Windows.Forms.MonthCalendar o)
		{
			BaseResetIndex(o);
		}

		public System.Windows.Forms.MonthCalendar this[short Index] {
			get { return (System.Windows.Forms.MonthCalendar)BaseGetItem(Index); }
		}

		protected override System.Type GetControlInstanceType()
		{
			return typeof(System.Windows.Forms.MonthCalendar);
		}

		protected override void HookUpControlEvents(object o)
		{
			System.Windows.Forms.MonthCalendar ctl = (System.Windows.Forms.MonthCalendar)o;
			base.HookUpControlEvents(o);
			if ((DateClickEvent != null)) {
				ctl.DateClick += new AxMSComCtl2.DMonthViewEvents_DateClickEventHandler(HandleDateClick);
			}
			if ((DateDblClickEvent != null)) {
				ctl.DateDblClick += new AxMSComCtl2.DMonthViewEvents_DateDblClickEventHandler(HandleDateDblClick);
			}
			if ((GetDayBoldEvent != null)) {
				ctl.GetDayBold += new AxMSComCtl2.DMonthViewEvents_GetDayBoldEventHandler(HandleGetDayBold);
			}
			if ((SelChangeEvent != null)) {
				ctl.SelChange += new AxMSComCtl2.DMonthViewEvents_SelChangeEventHandler(HandleSelChange);
			}
			if ((ClickEventEvent != null)) {
				ctl.ClickEvent += new System.EventHandler(HandleClickEvent);
			}
			if ((DblClickEvent != null)) {
				ctl.DblClick += new System.EventHandler(HandleDblClick);
			}
			if ((KeyDownEvent != null)) {
				ctl.KeyDown += new AxMSComCtl2.DMonthViewEvents_KeyDownHandler(HandleKeyDown);
			}
			if ((KeyUpEventEvent != null)) {
				ctl.KeyUpEvent += new AxMSComCtl2.DMonthViewEvents_KeyUpEventHandler(HandleKeyUpEvent);
			}
			if ((KeyPressEvent != null)) {
				ctl.KeyPress += new AxMSComCtl2.DMonthViewEvents_KeyPressHandler(HandleKeyPress);
			}
			if ((MouseDownEvent != null)) {
				ctl.MouseDown += new AxMSComCtl2.DMonthViewEvents_MouseDownHandler(HandleMouseDown);
			}
			if ((MouseMoveEventEvent != null)) {
				ctl.MouseMoveEvent += new AxMSComCtl2.DMonthViewEvents_MouseMoveEventHandler(HandleMouseMoveEvent);
			}
			if ((MouseUpEventEvent != null)) {
				ctl.MouseUpEvent += new AxMSComCtl2.DMonthViewEvents_MouseUpEventHandler(HandleMouseUpEvent);
			}
			if ((OLEStartDragEvent != null)) {
				ctl.OLEStartDrag += new AxMSComCtl2.DMonthViewEvents_OLEStartDragEventHandler(HandleOLEStartDrag);
			}
			if ((OLEGiveFeedbackEvent != null)) {
				ctl.OLEGiveFeedback += new AxMSComCtl2.DMonthViewEvents_OLEGiveFeedbackEventHandler(HandleOLEGiveFeedback);
			}
			if ((OLESetDataEvent != null)) {
				ctl.OLESetData += new AxMSComCtl2.DMonthViewEvents_OLESetDataEventHandler(HandleOLESetData);
			}
			if ((OLECompleteDragEvent != null)) {
				ctl.OLECompleteDrag += new AxMSComCtl2.DMonthViewEvents_OLECompleteDragEventHandler(HandleOLECompleteDrag);
			}
			if ((OLEDragOverEvent != null)) {
				ctl.OLEDragOver += new AxMSComCtl2.DMonthViewEvents_OLEDragOverEventHandler(HandleOLEDragOver);
			}
			if ((OLEDragDropEvent != null)) {
				ctl.OLEDragDrop += new AxMSComCtl2.DMonthViewEvents_OLEDragDropEventHandler(HandleOLEDragDrop);
			}
		}

		private void HandleDateClick(System.Object sender, AxMSComCtl2.DMonthViewEvents_DateClickEvent e)
		{
			if (DateClick != null) {
				DateClick(sender, e);
			}
		}

		private void HandleDateDblClick(System.Object sender, AxMSComCtl2.DMonthViewEvents_DateDblClickEvent e)
		{
			if (DateDblClick != null) {
				DateDblClick(sender, e);
			}
		}

		private void HandleGetDayBold(System.Object sender, AxMSComCtl2.DMonthViewEvents_GetDayBoldEvent e)
		{
			if (GetDayBold != null) {
				GetDayBold(sender, e);
			}
		}

		private void HandleSelChange(System.Object sender, AxMSComCtl2.DMonthViewEvents_SelChangeEvent e)
		{
			if (SelChange != null) {
				SelChange(sender, e);
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

		private void HandleKeyDown(System.Object sender, AxMSComCtl2.DMonthViewEvents_KeyDown e)
		{
			if (KeyDown != null) {
				KeyDown(sender, e);
			}
		}

		private void HandleKeyUpEvent(System.Object sender, AxMSComCtl2.DMonthViewEvents_KeyUpEvent e)
		{
			if (KeyUpEvent != null) {
				KeyUpEvent(sender, e);
			}
		}

		private void HandleKeyPress(System.Object sender, AxMSComCtl2.DMonthViewEvents_KeyPress e)
		{
			if (KeyPress != null) {
				KeyPress(sender, e);
			}
		}

		private void HandleMouseDown(System.Object sender, AxMSComCtl2.DMonthViewEvents_MouseDown e)
		{
			if (MouseDown != null) {
				MouseDown(sender, e);
			}
		}

		private void HandleMouseMoveEvent(System.Object sender, AxMSComCtl2.DMonthViewEvents_MouseMoveEvent e)
		{
			if (MouseMoveEvent != null) {
				MouseMoveEvent(sender, e);
			}
		}

		private void HandleMouseUpEvent(System.Object sender, AxMSComCtl2.DMonthViewEvents_MouseUpEvent e)
		{
			if (MouseUpEvent != null) {
				MouseUpEvent(sender, e);
			}
		}

		private void HandleOLEStartDrag(System.Object sender, AxMSComCtl2.DMonthViewEvents_OLEStartDragEvent e)
		{
			if (OLEStartDrag != null) {
				OLEStartDrag(sender, e);
			}
		}

		private void HandleOLEGiveFeedback(System.Object sender, AxMSComCtl2.DMonthViewEvents_OLEGiveFeedbackEvent e)
		{
			if (OLEGiveFeedback != null) {
				OLEGiveFeedback(sender, e);
			}
		}

		private void HandleOLESetData(System.Object sender, AxMSComCtl2.DMonthViewEvents_OLESetDataEvent e)
		{
			if (OLESetData != null) {
				OLESetData(sender, e);
			}
		}

		private void HandleOLECompleteDrag(System.Object sender, AxMSComCtl2.DMonthViewEvents_OLECompleteDragEvent e)
		{
			if (OLECompleteDrag != null) {
				OLECompleteDrag(sender, e);
			}
		}

		private void HandleOLEDragOver(System.Object sender, AxMSComCtl2.DMonthViewEvents_OLEDragOverEvent e)
		{
			if (OLEDragOver != null) {
				OLEDragOver(sender, e);
			}
		}

		private void HandleOLEDragDrop(System.Object sender, AxMSComCtl2.DMonthViewEvents_OLEDragDropEvent e)
		{
			if (OLEDragDrop != null) {
				OLEDragDrop(sender, e);
			}
		}

	}
}

