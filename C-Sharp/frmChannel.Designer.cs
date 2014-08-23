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
	partial class frmChannel
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmChannel() : base()
		{
			FormClosed += frmChannel_FormClosed;
			KeyPress += frmChannel_KeyPress;
			Resize += frmChannel_Resize;
			Load += frmChannel_Load;
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
		public System.Windows.Forms.TextBox _txtFields_0;
		public System.Windows.Forms.RadioButton _optType_1;
		public System.Windows.Forms.RadioButton _optType_0;
		public System.Windows.Forms.ComboBox cmbChannelPrice;
		public System.Windows.Forms.CheckBox _chkFields_5;
		public System.Windows.Forms.CheckBox _chkFields_4;
		public System.Windows.Forms.CheckBox _chkFields_3;
		public System.Windows.Forms.TextBox _txtFields_2;
		public System.Windows.Forms.TextBox _txtFields_1;
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
		public System.Windows.Forms.Panel picButtons;
		public System.Windows.Forms.Label _Label1_1;
		public System.Windows.Forms.Label _Label1_0;
		public System.Windows.Forms.Label _lblLabels_2;
		public System.Windows.Forms.Label _lblLabels_1;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_2;
		public System.Windows.Forms.Label _lbl_5;
		//Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents chkFields As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents optType As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
		//Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		public RectangleShapeArray Shape1;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmChannel));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this._txtFields_0 = new System.Windows.Forms.TextBox();
			this._optType_1 = new System.Windows.Forms.RadioButton();
			this._optType_0 = new System.Windows.Forms.RadioButton();
			this.cmbChannelPrice = new System.Windows.Forms.ComboBox();
			this._chkFields_5 = new System.Windows.Forms.CheckBox();
			this._chkFields_4 = new System.Windows.Forms.CheckBox();
			this._chkFields_3 = new System.Windows.Forms.CheckBox();
			this._txtFields_2 = new System.Windows.Forms.TextBox();
			this._txtFields_1 = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this._Label1_1 = new System.Windows.Forms.Label();
			this._Label1_0 = new System.Windows.Forms.Label();
			this._lblLabels_2 = new System.Windows.Forms.Label();
			this._lblLabels_1 = new System.Windows.Forms.Label();
			this._Shape1_2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._lbl_5 = new System.Windows.Forms.Label();
			//Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.chkFields = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(components)
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.optType = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
			//Me.txtFields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			this.Shape1 = new RectangleShapeArray(components);
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.chkFields, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.optType, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtFields, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Edit Sale Channel Details";
			this.ClientSize = new System.Drawing.Size(432, 298);
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
			this.Name = "frmChannel";
			this._txtFields_0.AutoSize = false;
			this._txtFields_0.Size = new System.Drawing.Size(67, 19);
			this._txtFields_0.Location = new System.Drawing.Point(264, 234);
			this._txtFields_0.MaxLength = 5;
			this._txtFields_0.TabIndex = 16;
			this._txtFields_0.Visible = false;
			this._txtFields_0.AcceptsReturn = true;
			this._txtFields_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtFields_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_0.CausesValidation = true;
			this._txtFields_0.Enabled = true;
			this._txtFields_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_0.HideSelection = true;
			this._txtFields_0.ReadOnly = false;
			this._txtFields_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_0.Multiline = false;
			this._txtFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_0.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_0.TabStop = true;
			this._txtFields_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_0.Name = "_txtFields_0";
			this._optType_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._optType_1.Text = "Price of default sales channel plus pricing group percentage";
			this._optType_1.Size = new System.Drawing.Size(346, 16);
			this._optType_1.Location = new System.Drawing.Point(54, 252);
			this._optType_1.TabIndex = 15;
			this._optType_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_1.CausesValidation = true;
			this._optType_1.Enabled = true;
			this._optType_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optType_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._optType_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optType_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optType_1.TabStop = true;
			this._optType_1.Checked = false;
			this._optType_1.Visible = true;
			this._optType_1.Name = "_optType_1";
			this._optType_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_0.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._optType_0.Text = "Cost plus pricing group percentage";
			this._optType_0.Size = new System.Drawing.Size(346, 16);
			this._optType_0.Location = new System.Drawing.Point(54, 234);
			this._optType_0.TabIndex = 13;
			this._optType_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optType_0.CausesValidation = true;
			this._optType_0.Enabled = true;
			this._optType_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optType_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._optType_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optType_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optType_0.TabStop = true;
			this._optType_0.Checked = false;
			this._optType_0.Visible = true;
			this._optType_0.Name = "_optType_0";
			this.cmbChannelPrice.Size = new System.Drawing.Size(196, 21);
			this.cmbChannelPrice.Location = new System.Drawing.Point(78, 174);
			this.cmbChannelPrice.Items.AddRange(new object[] {
				"No relationship",
				"Always the same or cheaper",
				"Always the same or more expensive"
			});
			this.cmbChannelPrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbChannelPrice.TabIndex = 11;
			this.cmbChannelPrice.BackColor = System.Drawing.SystemColors.Window;
			this.cmbChannelPrice.CausesValidation = true;
			this.cmbChannelPrice.Enabled = true;
			this.cmbChannelPrice.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbChannelPrice.IntegralHeight = true;
			this.cmbChannelPrice.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbChannelPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbChannelPrice.Sorted = false;
			this.cmbChannelPrice.TabStop = true;
			this.cmbChannelPrice.Visible = true;
			this.cmbChannelPrice.Name = "cmbChannelPrice";
			this._chkFields_5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_5.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._chkFields_5.Text = "Treat a case/carton price as the unit price when doing the pricing update:";
			this._chkFields_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_5.Size = new System.Drawing.Size(373, 19);
			this._chkFields_5.Location = new System.Drawing.Point(33, 135);
			this._chkFields_5.TabIndex = 10;
			this._chkFields_5.CausesValidation = true;
			this._chkFields_5.Enabled = true;
			this._chkFields_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_5.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkFields_5.TabStop = true;
			this._chkFields_5.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkFields_5.Visible = true;
			this._chkFields_5.Name = "_chkFields_5";
			this._chkFields_4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_4.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._chkFields_4.Text = "Do not use Pricing Strategy when doing pricing update:";
			this._chkFields_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_4.Size = new System.Drawing.Size(283, 19);
			this._chkFields_4.Location = new System.Drawing.Point(123, 114);
			this._chkFields_4.TabIndex = 9;
			this._chkFields_4.CausesValidation = true;
			this._chkFields_4.Enabled = true;
			this._chkFields_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_4.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkFields_4.TabStop = true;
			this._chkFields_4.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkFields_4.Visible = true;
			this._chkFields_4.Name = "_chkFields_4";
			this._chkFields_3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_3.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._chkFields_3.Text = "Disable this sale channel on the POS:";
			this._chkFields_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_3.Size = new System.Drawing.Size(202, 19);
			this._chkFields_3.Location = new System.Drawing.Point(204, 93);
			this._chkFields_3.TabIndex = 8;
			this._chkFields_3.CausesValidation = true;
			this._chkFields_3.Enabled = true;
			this._chkFields_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_3.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkFields_3.TabStop = true;
			this._chkFields_3.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkFields_3.Visible = true;
			this._chkFields_3.Name = "_chkFields_3";
			this._txtFields_2.AutoSize = false;
			this._txtFields_2.Size = new System.Drawing.Size(49, 19);
			this._txtFields_2.Location = new System.Drawing.Point(357, 69);
			this._txtFields_2.MaxLength = 5;
			this._txtFields_2.TabIndex = 7;
			this._txtFields_2.AcceptsReturn = true;
			this._txtFields_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtFields_2.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_2.CausesValidation = true;
			this._txtFields_2.Enabled = true;
			this._txtFields_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_2.HideSelection = true;
			this._txtFields_2.ReadOnly = false;
			this._txtFields_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_2.Multiline = false;
			this._txtFields_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_2.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_2.TabStop = true;
			this._txtFields_2.Visible = true;
			this._txtFields_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_2.Name = "_txtFields_2";
			this._txtFields_1.AutoSize = false;
			this._txtFields_1.Size = new System.Drawing.Size(217, 19);
			this._txtFields_1.Location = new System.Drawing.Point(66, 69);
			this._txtFields_1.TabIndex = 5;
			this._txtFields_1.AcceptsReturn = true;
			this._txtFields_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtFields_1.BackColor = System.Drawing.SystemColors.Window;
			this._txtFields_1.CausesValidation = true;
			this._txtFields_1.Enabled = true;
			this._txtFields_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFields_1.HideSelection = true;
			this._txtFields_1.ReadOnly = false;
			this._txtFields_1.MaxLength = 0;
			this._txtFields_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFields_1.Multiline = false;
			this._txtFields_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_1.TabStop = true;
			this._txtFields_1.Visible = true;
			this._txtFields_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_1.Name = "_txtFields_1";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(432, 39);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 2;
			this.picButtons.TabStop = false;
			this.picButtons.CausesValidation = true;
			this.picButtons.Enabled = true;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Visible = true;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Name = "picButtons";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "&Undo";
			this.cmdCancel.Size = new System.Drawing.Size(73, 29);
			this.cmdCancel.Location = new System.Drawing.Point(5, 3);
			this.cmdCancel.TabIndex = 1;
			this.cmdCancel.TabStop = false;
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.Name = "cmdCancel";
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.Size = new System.Drawing.Size(73, 29);
			this.cmdClose.Location = new System.Drawing.Point(351, 3);
			this.cmdClose.TabIndex = 0;
			this.cmdClose.TabStop = false;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Name = "cmdClose";
			this._Label1_1.Text = "When calculating exit price percentages, prices are calculated as,";
			this._Label1_1.Size = new System.Drawing.Size(388, 16);
			this._Label1_1.Location = new System.Drawing.Point(21, 216);
			this._Label1_1.TabIndex = 14;
			this._Label1_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label1_1.BackColor = System.Drawing.Color.Transparent;
			this._Label1_1.Enabled = true;
			this._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_1.UseMnemonic = true;
			this._Label1_1.Visible = true;
			this._Label1_1.AutoSize = false;
			this._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_1.Name = "_Label1_1";
			this._Label1_0.Text = "When doing the pricing calculation this Sale Channel relationship to the First Sale Channel is,";
			this._Label1_0.Size = new System.Drawing.Size(388, 43);
			this._Label1_0.Location = new System.Drawing.Point(21, 159);
			this._Label1_0.TabIndex = 12;
			this._Label1_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label1_0.BackColor = System.Drawing.Color.Transparent;
			this._Label1_0.Enabled = true;
			this._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_0.UseMnemonic = true;
			this._Label1_0.Visible = true;
			this._Label1_0.AutoSize = false;
			this._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_0.Name = "_Label1_0";
			this._lblLabels_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_2.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_2.Text = "Short Name:";
			this._lblLabels_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblLabels_2.Size = new System.Drawing.Size(61, 13);
			this._lblLabels_2.Location = new System.Drawing.Point(291, 72);
			this._lblLabels_2.TabIndex = 6;
			this._lblLabels_2.Enabled = true;
			this._lblLabels_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_2.UseMnemonic = true;
			this._lblLabels_2.Visible = true;
			this._lblLabels_2.AutoSize = true;
			this._lblLabels_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_2.Name = "_lblLabels_2";
			this._lblLabels_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_1.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_1.Text = "Name:";
			this._lblLabels_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblLabels_1.Size = new System.Drawing.Size(31, 13);
			this._lblLabels_1.Location = new System.Drawing.Point(27, 72);
			this._lblLabels_1.TabIndex = 4;
			this._lblLabels_1.Enabled = true;
			this._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_1.UseMnemonic = true;
			this._lblLabels_1.Visible = true;
			this._lblLabels_1.AutoSize = true;
			this._lblLabels_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_1.Name = "_lblLabels_1";
			this._Shape1_2.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_2.Size = new System.Drawing.Size(403, 220);
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
			this._lbl_5.TabIndex = 3;
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
			this.Controls.Add(_txtFields_0);
			this.Controls.Add(_optType_1);
			this.Controls.Add(_optType_0);
			this.Controls.Add(cmbChannelPrice);
			this.Controls.Add(_chkFields_5);
			this.Controls.Add(_chkFields_4);
			this.Controls.Add(_chkFields_3);
			this.Controls.Add(_txtFields_2);
			this.Controls.Add(_txtFields_1);
			this.Controls.Add(picButtons);
			this.Controls.Add(_Label1_1);
			this.Controls.Add(_Label1_0);
			this.Controls.Add(_lblLabels_2);
			this.Controls.Add(_lblLabels_1);
			this.ShapeContainer1.Shapes.Add(_Shape1_2);
			this.Controls.Add(_lbl_5);
			this.Controls.Add(ShapeContainer1);
			this.picButtons.Controls.Add(cmdCancel);
			this.picButtons.Controls.Add(cmdClose);
			//Me.Label1.SetIndex(_Label1_1, CType(1, Short))
			//Me.Label1.SetIndex(_Label1_0, CType(0, Short))
			//Me.chkFields.SetIndex(_chkFields_5, CType(5, Short))
			//Me.chkFields.SetIndex(_chkFields_4, CType(4, Short))
			//Me.chkFields.SetIndex(_chkFields_3, CType(3, Short))
			//Me.lbl.SetIndex(_lbl_5, CType(5, Short))
			//Me.lblLabels.SetIndex(_lblLabels_2, CType(2, Short))
			//Me.lblLabels.SetIndex(_lblLabels_1, CType(1, Short))
			//Me.optType.SetIndex(_optType_1, CType(1, Short))
			//Me.optType.SetIndex(_optType_0, CType(0, Short))
			//Me.txtFields.SetIndex(_txtFields_0, CType(0, Short))
			//Me.txtFields.SetIndex(_txtFields_2, CType(2, Short))
			//Me.txtFields.SetIndex(_txtFields_1, CType(1, Short))
			//Me.Shape1.SetIndex(_Shape1_2, CType(2, Short))
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			//CType(Me.txtFields, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.optType, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.chkFields, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
