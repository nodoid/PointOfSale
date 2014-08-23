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
namespace _4PosBackOffice.NET
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	partial class frmIncrement
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmIncrement() : base()
		{
			FormClosed += frmIncrement_FormClosed;
			KeyPress += frmIncrement_KeyPress;
			Resize += frmIncrement_Resize;
			Load += frmIncrement_Load;
			//This call is required by the Windows Form Designer.
			InitializeComponent();
		}
//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool Disposing)
		{
			if (Disposing) {
				if ((components != null)) {
					components.Dispose();
				}
			}
			base.Dispose(Disposing);
		}
//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTip1;
		public System.Windows.Forms.CheckBox _chkFields_9;
		public System.Windows.Forms.CheckBox _chkFields_8;
		public System.Windows.Forms.CheckBox _chkFields_7;
		public System.Windows.Forms.CheckBox _chkFields_6;
		public System.Windows.Forms.CheckBox _chkFields_5;
		public System.Windows.Forms.CheckBox _chkFields_4;
		public System.Windows.Forms.CheckBox _chkFields_3;
		public System.Windows.Forms.CheckBox _chkFields_2;
		public System.Windows.Forms.CheckBox _chkFields_1;
		private System.Windows.Forms.Button withEventsField_cmdAddStock;
		public System.Windows.Forms.Button cmdAddStock {
			get { return withEventsField_cmdAddStock; }
			set {
				if (withEventsField_cmdAddStock != null) {
					withEventsField_cmdAddStock.Click -= cmdAddStock_Click;
				}
				withEventsField_cmdAddStock = value;
				if (withEventsField_cmdAddStock != null) {
					withEventsField_cmdAddStock.Click += cmdAddStock_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdDelStock;
		public System.Windows.Forms.Button cmdDelStock {
			get { return withEventsField_cmdDelStock; }
			set {
				if (withEventsField_cmdDelStock != null) {
					withEventsField_cmdDelStock.Click -= cmdDelStock_Click;
				}
				withEventsField_cmdDelStock = value;
				if (withEventsField_cmdDelStock != null) {
					withEventsField_cmdDelStock.Click += cmdDelStock_Click;
				}
			}
		}
		public System.Windows.Forms.TextBox _txtInteger_0;
		private System.Windows.Forms.Button withEventsField_cmdDelete;
		public System.Windows.Forms.Button cmdDelete {
			get { return withEventsField_cmdDelete; }
			set {
				if (withEventsField_cmdDelete != null) {
					withEventsField_cmdDelete.Click -= cmdDelete_Click;
				}
				withEventsField_cmdDelete = value;
				if (withEventsField_cmdDelete != null) {
					withEventsField_cmdDelete.Click += cmdDelete_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdAdd;
		public System.Windows.Forms.Button cmdAdd {
			get { return withEventsField_cmdAdd; }
			set {
				if (withEventsField_cmdAdd != null) {
					withEventsField_cmdAdd.Click -= cmdAdd_Click;
				}
				withEventsField_cmdAdd = value;
				if (withEventsField_cmdAdd != null) {
					withEventsField_cmdAdd.Click += cmdAdd_Click;
				}
			}
		}
		private System.Windows.Forms.ListView withEventsField_lvItem;
		public System.Windows.Forms.ListView lvItem {
			get { return withEventsField_lvItem; }
			set {
				if (withEventsField_lvItem != null) {
					withEventsField_lvItem.DoubleClick -= lvItem_DoubleClick;
					withEventsField_lvItem.KeyPress -= lvItem_KeyPress;
				}
				withEventsField_lvItem = value;
				if (withEventsField_lvItem != null) {
					withEventsField_lvItem.DoubleClick += lvItem_DoubleClick;
					withEventsField_lvItem.KeyPress += lvItem_KeyPress;
				}
			}
		}
		public System.Windows.Forms.CheckBox _chkFields_0;
		public System.Windows.Forms.TextBox _txtFields_0;
		private System.Windows.Forms.Button withEventsField_cmdPrint;
		public System.Windows.Forms.Button cmdPrint {
			get { return withEventsField_cmdPrint; }
			set {
				if (withEventsField_cmdPrint != null) {
					withEventsField_cmdPrint.Click -= cmdPrint_Click;
				}
				withEventsField_cmdPrint = value;
				if (withEventsField_cmdPrint != null) {
					withEventsField_cmdPrint.Click += cmdPrint_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdClose;
		public System.Windows.Forms.Button cmdClose {
			get { return withEventsField_cmdClose; }
			set {
				if (withEventsField_cmdClose != null) {
					withEventsField_cmdClose.Click -= cmdClose_Click;
				}
				withEventsField_cmdClose = value;
				if (withEventsField_cmdClose != null) {
					withEventsField_cmdClose.Click += cmdClose_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdCancel;
		public System.Windows.Forms.Button cmdCancel {
			get { return withEventsField_cmdCancel; }
			set {
				if (withEventsField_cmdCancel != null) {
					withEventsField_cmdCancel.Click -= cmdCancel_Click;
				}
				withEventsField_cmdCancel = value;
				if (withEventsField_cmdCancel != null) {
					withEventsField_cmdCancel.Click += cmdCancel_Click;
				}
			}
		}
		public System.Windows.Forms.Panel picButtons;
		public System.Windows.Forms.ListView lvStockItem;
		public System.Windows.Forms.Label _lbl_2;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_3;
		public System.Windows.Forms.Label _lbl_1;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_1;
		public System.Windows.Forms.Label _lbl_0;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_0;
		public System.Windows.Forms.Label _lblLabels_9;
		public System.Windows.Forms.Label _lblLabels_38;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_2;
		public System.Windows.Forms.Label _lbl_5;
		//Public WithEvents chkFields As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		//Public WithEvents txtInteger As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		public RectangleShapeArray Shape1;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmIncrement));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this._chkFields_9 = new System.Windows.Forms.CheckBox();
			this._chkFields_8 = new System.Windows.Forms.CheckBox();
			this._chkFields_7 = new System.Windows.Forms.CheckBox();
			this._chkFields_6 = new System.Windows.Forms.CheckBox();
			this._chkFields_5 = new System.Windows.Forms.CheckBox();
			this._chkFields_4 = new System.Windows.Forms.CheckBox();
			this._chkFields_3 = new System.Windows.Forms.CheckBox();
			this._chkFields_2 = new System.Windows.Forms.CheckBox();
			this._chkFields_1 = new System.Windows.Forms.CheckBox();
			this.cmdAddStock = new System.Windows.Forms.Button();
			this.cmdDelStock = new System.Windows.Forms.Button();
			this._txtInteger_0 = new System.Windows.Forms.TextBox();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.lvItem = new System.Windows.Forms.ListView();
			this._chkFields_0 = new System.Windows.Forms.CheckBox();
			this._txtFields_0 = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.lvStockItem = new System.Windows.Forms.ListView();
			this._lbl_2 = new System.Windows.Forms.Label();
			this._Shape1_3 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._lbl_1 = new System.Windows.Forms.Label();
			this._Shape1_1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._lbl_0 = new System.Windows.Forms.Label();
			this._Shape1_0 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._lblLabels_9 = new System.Windows.Forms.Label();
			this._lblLabels_38 = new System.Windows.Forms.Label();
			this._Shape1_2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._lbl_5 = new System.Windows.Forms.Label();
			//Me.chkFields = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(components)
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.txtFields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			//Me.txtInteger = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			this.Shape1 = new RectangleShapeArray(components);
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.chkFields, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtFields, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtInteger, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Edit Increment Details";
			this.ClientSize = new System.Drawing.Size(451, 511);
			this.Location = new System.Drawing.Point(73, 22);
			this.ControlBox = false;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Enabled = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmIncrement";
			this._chkFields_9.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._chkFields_9.Text = "1. POS";
			this._chkFields_9.Size = new System.Drawing.Size(73, 13);
			this._chkFields_9.Location = new System.Drawing.Point(321, 159);
			this._chkFields_9.TabIndex = 15;
			this._chkFields_9.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkFields_9.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this._chkFields_9.CausesValidation = true;
			this._chkFields_9.Enabled = true;
			this._chkFields_9.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkFields_9.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_9.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkFields_9.TabStop = true;
			this._chkFields_9.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkFields_9.Visible = true;
			this._chkFields_9.Name = "_chkFields_9";
			this._chkFields_8.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._chkFields_8.Text = "1. POS";
			this._chkFields_8.Size = new System.Drawing.Size(73, 13);
			this._chkFields_8.Location = new System.Drawing.Point(246, 159);
			this._chkFields_8.TabIndex = 14;
			this._chkFields_8.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkFields_8.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this._chkFields_8.CausesValidation = true;
			this._chkFields_8.Enabled = true;
			this._chkFields_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkFields_8.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_8.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkFields_8.TabStop = true;
			this._chkFields_8.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkFields_8.Visible = true;
			this._chkFields_8.Name = "_chkFields_8";
			this._chkFields_7.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._chkFields_7.Text = "1. POS";
			this._chkFields_7.Size = new System.Drawing.Size(73, 13);
			this._chkFields_7.Location = new System.Drawing.Point(171, 159);
			this._chkFields_7.TabIndex = 13;
			this._chkFields_7.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkFields_7.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this._chkFields_7.CausesValidation = true;
			this._chkFields_7.Enabled = true;
			this._chkFields_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkFields_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_7.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkFields_7.TabStop = true;
			this._chkFields_7.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkFields_7.Visible = true;
			this._chkFields_7.Name = "_chkFields_7";
			this._chkFields_6.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._chkFields_6.Text = "Increment_Channel6";
			this._chkFields_6.Size = new System.Drawing.Size(73, 13);
			this._chkFields_6.Location = new System.Drawing.Point(99, 159);
			this._chkFields_6.TabIndex = 12;
			this._chkFields_6.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkFields_6.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this._chkFields_6.CausesValidation = true;
			this._chkFields_6.Enabled = true;
			this._chkFields_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkFields_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_6.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkFields_6.TabStop = true;
			this._chkFields_6.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkFields_6.Visible = true;
			this._chkFields_6.Name = "_chkFields_6";
			this._chkFields_5.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._chkFields_5.Text = "Increment_Channel5";
			this._chkFields_5.Size = new System.Drawing.Size(73, 13);
			this._chkFields_5.Location = new System.Drawing.Point(30, 159);
			this._chkFields_5.TabIndex = 11;
			this._chkFields_5.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkFields_5.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this._chkFields_5.CausesValidation = true;
			this._chkFields_5.Enabled = true;
			this._chkFields_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkFields_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_5.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkFields_5.TabStop = true;
			this._chkFields_5.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkFields_5.Visible = true;
			this._chkFields_5.Name = "_chkFields_5";
			this._chkFields_4.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._chkFields_4.Text = "1. POS";
			this._chkFields_4.Size = new System.Drawing.Size(73, 13);
			this._chkFields_4.Location = new System.Drawing.Point(246, 141);
			this._chkFields_4.TabIndex = 10;
			this._chkFields_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkFields_4.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this._chkFields_4.CausesValidation = true;
			this._chkFields_4.Enabled = true;
			this._chkFields_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkFields_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_4.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkFields_4.TabStop = true;
			this._chkFields_4.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkFields_4.Visible = true;
			this._chkFields_4.Name = "_chkFields_4";
			this._chkFields_3.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._chkFields_3.Text = "1. POS";
			this._chkFields_3.Size = new System.Drawing.Size(73, 13);
			this._chkFields_3.Location = new System.Drawing.Point(171, 141);
			this._chkFields_3.TabIndex = 9;
			this._chkFields_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkFields_3.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this._chkFields_3.CausesValidation = true;
			this._chkFields_3.Enabled = true;
			this._chkFields_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkFields_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_3.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkFields_3.TabStop = true;
			this._chkFields_3.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkFields_3.Visible = true;
			this._chkFields_3.Name = "_chkFields_3";
			this._chkFields_2.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._chkFields_2.Text = "1. POS";
			this._chkFields_2.Size = new System.Drawing.Size(73, 13);
			this._chkFields_2.Location = new System.Drawing.Point(99, 141);
			this._chkFields_2.TabIndex = 8;
			this._chkFields_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkFields_2.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this._chkFields_2.CausesValidation = true;
			this._chkFields_2.Enabled = true;
			this._chkFields_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkFields_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_2.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkFields_2.TabStop = true;
			this._chkFields_2.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkFields_2.Visible = true;
			this._chkFields_2.Name = "_chkFields_2";
			this._chkFields_1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._chkFields_1.Text = "1. POS";
			this._chkFields_1.Size = new System.Drawing.Size(73, 13);
			this._chkFields_1.Location = new System.Drawing.Point(30, 141);
			this._chkFields_1.TabIndex = 7;
			this._chkFields_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._chkFields_1.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this._chkFields_1.CausesValidation = true;
			this._chkFields_1.Enabled = true;
			this._chkFields_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._chkFields_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkFields_1.TabStop = true;
			this._chkFields_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkFields_1.Visible = true;
			this._chkFields_1.Name = "_chkFields_1";
			this.cmdAddStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddStock.Text = "&Add";
			this.cmdAddStock.Size = new System.Drawing.Size(79, 25);
			this.cmdAddStock.Location = new System.Drawing.Point(204, 210);
			this.cmdAddStock.TabIndex = 21;
			this.cmdAddStock.TabStop = false;
			this.cmdAddStock.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddStock.CausesValidation = true;
			this.cmdAddStock.Enabled = true;
			this.cmdAddStock.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddStock.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddStock.Name = "cmdAddStock";
			this.cmdDelStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDelStock.Text = "&Delete";
			this.cmdDelStock.Size = new System.Drawing.Size(79, 25);
			this.cmdDelStock.Location = new System.Drawing.Point(342, 210);
			this.cmdDelStock.TabIndex = 22;
			this.cmdDelStock.TabStop = false;
			this.cmdDelStock.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDelStock.CausesValidation = true;
			this.cmdDelStock.Enabled = true;
			this.cmdDelStock.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDelStock.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDelStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDelStock.Name = "cmdDelStock";
			this._txtInteger_0.AutoSize = false;
			this._txtInteger_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtInteger_0.Size = new System.Drawing.Size(43, 19);
			this._txtInteger_0.Location = new System.Drawing.Point(105, 87);
			this._txtInteger_0.TabIndex = 4;
			this._txtInteger_0.Text = "999";
			this._txtInteger_0.AcceptsReturn = true;
			this._txtInteger_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtInteger_0.CausesValidation = true;
			this._txtInteger_0.Enabled = true;
			this._txtInteger_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtInteger_0.HideSelection = true;
			this._txtInteger_0.ReadOnly = false;
			this._txtInteger_0.MaxLength = 0;
			this._txtInteger_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtInteger_0.Multiline = false;
			this._txtInteger_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtInteger_0.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtInteger_0.TabStop = true;
			this._txtInteger_0.Visible = true;
			this._txtInteger_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtInteger_0.Name = "_txtInteger_0";
			this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDelete.Text = "&Delete";
			this.cmdDelete.Size = new System.Drawing.Size(79, 25);
			this.cmdDelete.Location = new System.Drawing.Point(105, 210);
			this.cmdDelete.TabIndex = 18;
			this.cmdDelete.TabStop = false;
			this.cmdDelete.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDelete.CausesValidation = true;
			this.cmdDelete.Enabled = true;
			this.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDelete.Name = "cmdDelete";
			this.cmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAdd.Text = "&Add";
			this.cmdAdd.Size = new System.Drawing.Size(79, 25);
			this.cmdAdd.Location = new System.Drawing.Point(21, 210);
			this.cmdAdd.TabIndex = 17;
			this.cmdAdd.TabStop = false;
			this.cmdAdd.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAdd.CausesValidation = true;
			this.cmdAdd.Enabled = true;
			this.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAdd.Name = "cmdAdd";
			this.lvItem.Size = new System.Drawing.Size(160, 250);
			this.lvItem.Location = new System.Drawing.Point(21, 237);
			this.lvItem.TabIndex = 19;
			this.lvItem.View = System.Windows.Forms.View.Details;
			this.lvItem.LabelWrap = true;
			this.lvItem.HideSelection = false;
			this.lvItem.FullRowSelect = true;
			this.lvItem.GridLines = true;
			this.lvItem.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lvItem.BackColor = System.Drawing.SystemColors.Window;
			this.lvItem.LabelEdit = true;
			this.lvItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lvItem.Name = "lvItem";
			this._chkFields_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_0.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._chkFields_0.Text = "Disabled:";
			this._chkFields_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_0.Size = new System.Drawing.Size(64, 13);
			this._chkFields_0.Location = new System.Drawing.Point(354, 93);
			this._chkFields_0.TabIndex = 5;
			this._chkFields_0.CausesValidation = true;
			this._chkFields_0.Enabled = true;
			this._chkFields_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkFields_0.TabStop = true;
			this._chkFields_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkFields_0.Visible = true;
			this._chkFields_0.Name = "_chkFields_0";
			this._txtFields_0.AutoSize = false;
			this._txtFields_0.Size = new System.Drawing.Size(315, 19);
			this._txtFields_0.Location = new System.Drawing.Point(105, 66);
			this._txtFields_0.TabIndex = 2;
			this._txtFields_0.AcceptsReturn = true;
			this._txtFields_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtFields_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_0.CausesValidation = true;
			this._txtFields_0.Enabled = true;
			this._txtFields_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_0.HideSelection = true;
			this._txtFields_0.ReadOnly = false;
			this._txtFields_0.MaxLength = 0;
			this._txtFields_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_0.Multiline = false;
			this._txtFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_0.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_0.TabStop = true;
			this._txtFields_0.Visible = true;
			this._txtFields_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_0.Name = "_txtFields_0";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(451, 39);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 25;
			this.picButtons.TabStop = false;
			this.picButtons.CausesValidation = true;
			this.picButtons.Enabled = true;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Visible = true;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Name = "picButtons";
			this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPrint.Text = "&Print";
			this.cmdPrint.Size = new System.Drawing.Size(73, 29);
			this.cmdPrint.Location = new System.Drawing.Point(192, 3);
			this.cmdPrint.TabIndex = 27;
			this.cmdPrint.TabStop = false;
			this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrint.CausesValidation = true;
			this.cmdPrint.Enabled = true;
			this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.Size = new System.Drawing.Size(73, 29);
			this.cmdClose.Location = new System.Drawing.Point(369, 3);
			this.cmdClose.TabIndex = 26;
			this.cmdClose.TabStop = false;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Name = "cmdClose";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "&Undo";
			this.cmdCancel.Size = new System.Drawing.Size(73, 29);
			this.cmdCancel.Location = new System.Drawing.Point(5, 3);
			this.cmdCancel.TabIndex = 24;
			this.cmdCancel.TabStop = false;
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.Name = "cmdCancel";
			this.lvStockItem.Size = new System.Drawing.Size(217, 250);
			this.lvStockItem.Location = new System.Drawing.Point(204, 237);
			this.lvStockItem.TabIndex = 23;
			this.lvStockItem.View = System.Windows.Forms.View.Details;
			this.lvStockItem.LabelWrap = true;
			this.lvStockItem.HideSelection = false;
			this.lvStockItem.FullRowSelect = true;
			this.lvStockItem.GridLines = true;
			this.lvStockItem.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lvStockItem.BackColor = System.Drawing.SystemColors.Window;
			this.lvStockItem.LabelEdit = true;
			this.lvStockItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lvStockItem.Name = "lvStockItem";
			this._lbl_2.BackColor = System.Drawing.Color.Transparent;
			this._lbl_2.Text = "&2. Disabled the following checked Sale Channels.";
			this._lbl_2.Size = new System.Drawing.Size(417, 19);
			this._lbl_2.Location = new System.Drawing.Point(18, 120);
			this._lbl_2.TabIndex = 6;
			this._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_2.Enabled = true;
			this._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_2.UseMnemonic = true;
			this._lbl_2.Visible = true;
			this._lbl_2.AutoSize = false;
			this._lbl_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_2.Name = "_lbl_2";
			this._Shape1_3.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_3.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_3.Size = new System.Drawing.Size(412, 43);
			this._Shape1_3.Location = new System.Drawing.Point(18, 135);
			this._Shape1_3.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_3.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_3.BorderWidth = 1;
			this._Shape1_3.FillColor = System.Drawing.Color.Black;
			this._Shape1_3.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_3.Visible = true;
			this._Shape1_3.Name = "_Shape1_3";
			this._lbl_1.BackColor = System.Drawing.Color.Transparent;
			this._lbl_1.Text = "&4. Stock Items";
			this._lbl_1.Size = new System.Drawing.Size(83, 13);
			this._lbl_1.Location = new System.Drawing.Point(201, 189);
			this._lbl_1.TabIndex = 20;
			this._lbl_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_1.Enabled = true;
			this._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_1.UseMnemonic = true;
			this._lbl_1.Visible = true;
			this._lbl_1.AutoSize = true;
			this._lbl_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_1.Name = "_lbl_1";
			this._Shape1_1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_1.Size = new System.Drawing.Size(232, 292);
			this._Shape1_1.Location = new System.Drawing.Point(198, 204);
			this._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_1.BorderWidth = 1;
			this._Shape1_1.FillColor = System.Drawing.Color.Black;
			this._Shape1_1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_1.Visible = true;
			this._Shape1_1.Name = "_Shape1_1";
			this._lbl_0.BackColor = System.Drawing.Color.Transparent;
			this._lbl_0.Text = "&3. Quantities and Price";
			this._lbl_0.Size = new System.Drawing.Size(131, 13);
			this._lbl_0.Location = new System.Drawing.Point(18, 189);
			this._lbl_0.TabIndex = 16;
			this._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_0.Enabled = true;
			this._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_0.UseMnemonic = true;
			this._lbl_0.Visible = true;
			this._lbl_0.AutoSize = true;
			this._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_0.Name = "_lbl_0";
			this._Shape1_0.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_0.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_0.Size = new System.Drawing.Size(175, 292);
			this._Shape1_0.Location = new System.Drawing.Point(15, 204);
			this._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_0.BorderWidth = 1;
			this._Shape1_0.FillColor = System.Drawing.Color.Black;
			this._Shape1_0.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_0.Visible = true;
			this._Shape1_0.Name = "_Shape1_0";
			this._lblLabels_9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_9.Text = "Shrink Size:";
			this._lblLabels_9.Size = new System.Drawing.Size(56, 13);
			this._lblLabels_9.Location = new System.Drawing.Point(44, 90);
			this._lblLabels_9.TabIndex = 3;
			this._lblLabels_9.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_9.Enabled = true;
			this._lblLabels_9.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_9.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_9.UseMnemonic = true;
			this._lblLabels_9.Visible = true;
			this._lblLabels_9.AutoSize = true;
			this._lblLabels_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_9.Name = "_lblLabels_9";
			this._lblLabels_38.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_38.Text = "Increment Name:";
			this._lblLabels_38.Size = new System.Drawing.Size(81, 13);
			this._lblLabels_38.Location = new System.Drawing.Point(19, 69);
			this._lblLabels_38.TabIndex = 1;
			this._lblLabels_38.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_38.Enabled = true;
			this._lblLabels_38.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_38.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_38.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_38.UseMnemonic = true;
			this._lblLabels_38.Visible = true;
			this._lblLabels_38.AutoSize = true;
			this._lblLabels_38.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_38.Name = "_lblLabels_38";
			this._Shape1_2.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_2.Size = new System.Drawing.Size(415, 55);
			this._Shape1_2.Location = new System.Drawing.Point(15, 60);
			this._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_2.BorderWidth = 1;
			this._Shape1_2.FillColor = System.Drawing.Color.Black;
			this._Shape1_2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_2.Visible = true;
			this._Shape1_2.Name = "_Shape1_2";
			this._lbl_5.BackColor = System.Drawing.Color.Transparent;
			this._lbl_5.Text = "&1. General";
			this._lbl_5.Size = new System.Drawing.Size(60, 13);
			this._lbl_5.Location = new System.Drawing.Point(15, 45);
			this._lbl_5.TabIndex = 0;
			this._lbl_5.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_5.Enabled = true;
			this._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_5.UseMnemonic = true;
			this._lbl_5.Visible = true;
			this._lbl_5.AutoSize = true;
			this._lbl_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_5.Name = "_lbl_5";
			this.Controls.Add(_chkFields_9);
			this.Controls.Add(_chkFields_8);
			this.Controls.Add(_chkFields_7);
			this.Controls.Add(_chkFields_6);
			this.Controls.Add(_chkFields_5);
			this.Controls.Add(_chkFields_4);
			this.Controls.Add(_chkFields_3);
			this.Controls.Add(_chkFields_2);
			this.Controls.Add(_chkFields_1);
			this.Controls.Add(cmdAddStock);
			this.Controls.Add(cmdDelStock);
			this.Controls.Add(_txtInteger_0);
			this.Controls.Add(cmdDelete);
			this.Controls.Add(cmdAdd);
			this.Controls.Add(lvItem);
			this.Controls.Add(_chkFields_0);
			this.Controls.Add(_txtFields_0);
			this.Controls.Add(picButtons);
			this.Controls.Add(lvStockItem);
			this.Controls.Add(_lbl_2);
			this.ShapeContainer1.Shapes.Add(_Shape1_3);
			this.Controls.Add(_lbl_1);
			this.ShapeContainer1.Shapes.Add(_Shape1_1);
			this.Controls.Add(_lbl_0);
			this.ShapeContainer1.Shapes.Add(_Shape1_0);
			this.Controls.Add(_lblLabels_9);
			this.Controls.Add(_lblLabels_38);
			this.ShapeContainer1.Shapes.Add(_Shape1_2);
			this.Controls.Add(_lbl_5);
			this.Controls.Add(ShapeContainer1);
			this.picButtons.Controls.Add(cmdPrint);
			this.picButtons.Controls.Add(cmdClose);
			this.picButtons.Controls.Add(cmdCancel);
			//Me.chkFields.SetIndex(_chkFields_9, CType(9, Short))
			//Me.chkFields.SetIndex(_chkFields_8, CType(8, Short))
			//Me.chkFields.SetIndex(_chkFields_7, CType(7, Short))
			//Me.chkFields.SetIndex(_chkFields_6, CType(6, Short))
			//Me.chkFields.SetIndex(_chkFields_5, CType(5, Short))
			//Me.chkFields.SetIndex(_chkFields_4, CType(4, Short))
			//Me.chkFields.SetIndex(_chkFields_3, CType(3, Short))
			//Me.chkFields.SetIndex(_chkFields_2, CType(2, Short))
			//Me.chkFields.SetIndex(_chkFields_1, CType(1, Short))
			//Me.chkFields.SetIndex(_chkFields_0, CType(0, Short))
			//Me.lbl.SetIndex(_lbl_2, CType(2, Short))
			//Me.lbl.SetIndex(_lbl_1, CType(1, Short))
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//Me.lbl.SetIndex(_lbl_5, CType(5, Short))
			//Me.lblLabels.SetIndex(_lblLabels_9, CType(9, Short))
			//Me.lblLabels.SetIndex(_lblLabels_38, CType(38, Short))
			//Me.txtFields.SetIndex(_txtFields_0, CType(0, Short))
			//Me.txtInteger.SetIndex(_txtInteger_0, CType(0, Short))
			this.Shape1.SetIndex(_Shape1_3, Convert.ToInt16(3));
			this.Shape1.SetIndex(_Shape1_1, Convert.ToInt16(1));
			this.Shape1.SetIndex(_Shape1_0, Convert.ToInt16(0));
			this.Shape1.SetIndex(_Shape1_2, Convert.ToInt16(2));
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			//CType(Me.txtInteger, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.txtFields, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.chkFields, System.ComponentModel.ISupportInitialize).EndInit()
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
