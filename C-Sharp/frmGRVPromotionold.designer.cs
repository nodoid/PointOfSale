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
	partial class frmGRVPromotion
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmGRVPromotion() : base()
		{
			FormClosed += frmGRVPromotion_FormClosed;
			KeyPress += frmGRVPromotion_KeyPress;
			Resize += frmGRVPromotion_Resize;
			Load += frmGRVPromotion_Load;
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
		public System.Windows.Forms.DateTimePicker _DTFields_3;
		public System.Windows.Forms.DateTimePicker _DTFields_2;
		public System.Windows.Forms.CheckBox _chkFields_2;
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
		private System.Windows.Forms.ListView withEventsField_lvPromotion;
		public System.Windows.Forms.ListView lvPromotion {
			get { return withEventsField_lvPromotion; }
			set {
				if (withEventsField_lvPromotion != null) {
					withEventsField_lvPromotion.DoubleClick -= lvPromotion_DoubleClick;
					withEventsField_lvPromotion.KeyPress -= lvPromotion_KeyPress;
				}
				withEventsField_lvPromotion = value;
				if (withEventsField_lvPromotion != null) {
					withEventsField_lvPromotion.DoubleClick += lvPromotion_DoubleClick;
					withEventsField_lvPromotion.KeyPress += lvPromotion_KeyPress;
				}
			}
		}
		public System.Windows.Forms.CheckBox _chkFields_1;
		public System.Windows.Forms.CheckBox _chkFields_0;
		public System.Windows.Forms.DateTimePicker _DTFields_0;
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
		public System.Windows.Forms.DateTimePicker _DTFields_1;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label _lblLabels_1;
		public System.Windows.Forms.Label _lblLabels_0;
		public System.Windows.Forms.Label _lblLabels_38;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_2;
		public System.Windows.Forms.Label _lbl_5;
		//Public WithEvents DTFields As AxDTPickerArray
		//Public WithEvents chkFields As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		public RectangleShapeArray Shape1;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmGRVPromotion));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this._DTFields_3 = new System.Windows.Forms.DateTimePicker();
			this._DTFields_2 = new System.Windows.Forms.DateTimePicker();
			this._chkFields_2 = new System.Windows.Forms.CheckBox();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.lvPromotion = new System.Windows.Forms.ListView();
			this._chkFields_1 = new System.Windows.Forms.CheckBox();
			this._chkFields_0 = new System.Windows.Forms.CheckBox();
			this._DTFields_0 = new System.Windows.Forms.DateTimePicker();
			this._txtFields_0 = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this._DTFields_1 = new System.Windows.Forms.DateTimePicker();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this._lblLabels_1 = new System.Windows.Forms.Label();
			this._lblLabels_0 = new System.Windows.Forms.Label();
			this._lblLabels_38 = new System.Windows.Forms.Label();
			this._Shape1_2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._lbl_5 = new System.Windows.Forms.Label();
			//Me.DTFields = New AxDTPickerArray(components)
			//Me.chkFields = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(components)
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.txtFields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			this.Shape1 = new RectangleShapeArray(components);
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this._DTFields_3).BeginInit();
			((System.ComponentModel.ISupportInitialize)this._DTFields_2).BeginInit();
			((System.ComponentModel.ISupportInitialize)this._DTFields_0).BeginInit();
			((System.ComponentModel.ISupportInitialize)this._DTFields_1).BeginInit();
			//CType(Me.DTFields, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.chkFields, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtFields, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Edit GRV Deal Details";
			this.ClientSize = new System.Drawing.Size(455, 460);
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
			this.Name = "frmGRVPromotion";
			//_DTFields_3.OcxState = CType(resources.GetObject("_DTFields_3.OcxState"), System.Windows.Forms.AxHost.State)
			this._DTFields_3.Size = new System.Drawing.Size(130, 21);
			this._DTFields_3.Location = new System.Drawing.Point(291, 112);
			this._DTFields_3.TabIndex = 20;
			this._DTFields_3.Visible = false;
			this._DTFields_3.Name = "_DTFields_3";
			//_DTFields_2.OcxState = CType(resources.GetObject("_DTFields_2.OcxState"), System.Windows.Forms.AxHost.State)
			this._DTFields_2.Size = new System.Drawing.Size(130, 21);
			this._DTFields_2.Location = new System.Drawing.Point(104, 112);
			this._DTFields_2.TabIndex = 19;
			this._DTFields_2.Visible = false;
			this._DTFields_2.Name = "_DTFields_2";
			this._chkFields_2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_2.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._chkFields_2.Text = "Only for Specific Time";
			this._chkFields_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_2.Size = new System.Drawing.Size(151, 17);
			this._chkFields_2.Location = new System.Drawing.Point(270, 152);
			this._chkFields_2.TabIndex = 16;
			this._chkFields_2.Visible = false;
			this._chkFields_2.CausesValidation = true;
			this._chkFields_2.Enabled = true;
			this._chkFields_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_2.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkFields_2.TabStop = true;
			this._chkFields_2.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkFields_2.Name = "_chkFields_2";
			this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDelete.Text = "&Delete";
			this.cmdDelete.Size = new System.Drawing.Size(94, 25);
			this.cmdDelete.Location = new System.Drawing.Point(352, 176);
			this.cmdDelete.TabIndex = 14;
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
			this.cmdAdd.Size = new System.Drawing.Size(94, 25);
			this.cmdAdd.Location = new System.Drawing.Point(2, 176);
			this.cmdAdd.TabIndex = 13;
			this.cmdAdd.TabStop = false;
			this.cmdAdd.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAdd.CausesValidation = true;
			this.cmdAdd.Enabled = true;
			this.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAdd.Name = "cmdAdd";
			this.lvPromotion.Size = new System.Drawing.Size(445, 250);
			this.lvPromotion.Location = new System.Drawing.Point(2, 206);
			this.lvPromotion.TabIndex = 11;
			this.lvPromotion.View = System.Windows.Forms.View.Details;
			this.lvPromotion.LabelWrap = true;
			this.lvPromotion.HideSelection = false;
			this.lvPromotion.FullRowSelect = true;
			this.lvPromotion.GridLines = true;
			this.lvPromotion.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lvPromotion.BackColor = System.Drawing.SystemColors.Window;
			this.lvPromotion.LabelEdit = true;
			this.lvPromotion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lvPromotion.Name = "lvPromotion";
			this._chkFields_1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._chkFields_1.Text = "Disabled:";
			this._chkFields_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_1.Size = new System.Drawing.Size(64, 13);
			this._chkFields_1.Location = new System.Drawing.Point(54, 138);
			this._chkFields_1.TabIndex = 7;
			this._chkFields_1.CausesValidation = true;
			this._chkFields_1.Enabled = true;
			this._chkFields_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkFields_1.TabStop = true;
			this._chkFields_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkFields_1.Visible = true;
			this._chkFields_1.Name = "_chkFields_1";
			this._chkFields_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_0.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._chkFields_0.Text = "Apply Only to POS Channel";
			this._chkFields_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_0.Size = new System.Drawing.Size(151, 13);
			this._chkFields_0.Location = new System.Drawing.Point(270, 138);
			this._chkFields_0.TabIndex = 8;
			this._chkFields_0.Visible = false;
			this._chkFields_0.CausesValidation = true;
			this._chkFields_0.Enabled = true;
			this._chkFields_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkFields_0.TabStop = true;
			this._chkFields_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkFields_0.Name = "_chkFields_0";
			//_DTFields_0.OcxState = CType(resources.GetObject("_DTFields_0.OcxState"), System.Windows.Forms.AxHost.State)
			this._DTFields_0.Size = new System.Drawing.Size(130, 22);
			this._DTFields_0.Location = new System.Drawing.Point(105, 87);
			this._DTFields_0.TabIndex = 4;
			this._DTFields_0.Name = "_DTFields_0";
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
			this.picButtons.Size = new System.Drawing.Size(455, 39);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 10;
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
			this.cmdPrint.TabIndex = 15;
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
			this.cmdClose.TabIndex = 12;
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
			this.cmdCancel.TabIndex = 9;
			this.cmdCancel.TabStop = false;
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.Name = "cmdCancel";
			//_DTFields_1.OcxState = CType(resources.GetObject("_DTFields_1.OcxState"), System.Windows.Forms.AxHost.State)
			this._DTFields_1.Size = new System.Drawing.Size(130, 22);
			this._DTFields_1.Location = new System.Drawing.Point(291, 87);
			this._DTFields_1.TabIndex = 6;
			this._DTFields_1.Name = "_DTFields_1";
			this.Label2.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.Label2.Text = "To Time:";
			this.Label2.Size = new System.Drawing.Size(51, 15);
			this.Label2.Location = new System.Drawing.Point(238, 116);
			this.Label2.TabIndex = 18;
			this.Label2.Visible = false;
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label2.Enabled = true;
			this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.UseMnemonic = true;
			this.Label2.AutoSize = false;
			this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label2.Name = "Label2";
			this.Label1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.Label1.Text = "From Time:";
			this.Label1.Size = new System.Drawing.Size(57, 17);
			this.Label1.Location = new System.Drawing.Point(48, 116);
			this.Label1.TabIndex = 17;
			this.Label1.Visible = false;
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label1.Enabled = true;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.UseMnemonic = true;
			this.Label1.AutoSize = false;
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Name = "Label1";
			this._lblLabels_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_1.Text = "End Date:";
			this._lblLabels_1.Size = new System.Drawing.Size(48, 13);
			this._lblLabels_1.Location = new System.Drawing.Point(240, 90);
			this._lblLabels_1.TabIndex = 5;
			this._lblLabels_1.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_1.Enabled = true;
			this._lblLabels_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_1.UseMnemonic = true;
			this._lblLabels_1.Visible = true;
			this._lblLabels_1.AutoSize = true;
			this._lblLabels_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_1.Name = "_lblLabels_1";
			this._lblLabels_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_0.Text = "Start Date:";
			this._lblLabels_0.Size = new System.Drawing.Size(51, 13);
			this._lblLabels_0.Location = new System.Drawing.Point(52, 90);
			this._lblLabels_0.TabIndex = 3;
			this._lblLabels_0.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_0.Enabled = true;
			this._lblLabels_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_0.UseMnemonic = true;
			this._lblLabels_0.Visible = true;
			this._lblLabels_0.AutoSize = true;
			this._lblLabels_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_0.Name = "_lblLabels_0";
			this._lblLabels_38.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_38.Text = "Deal Name:";
			this._lblLabels_38.Size = new System.Drawing.Size(56, 13);
			this._lblLabels_38.Location = new System.Drawing.Point(44, 69);
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
			this._Shape1_2.Size = new System.Drawing.Size(415, 112);
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
			this._lbl_5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
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
			this.Controls.Add(_DTFields_3);
			this.Controls.Add(_DTFields_2);
			this.Controls.Add(_chkFields_2);
			this.Controls.Add(cmdDelete);
			this.Controls.Add(cmdAdd);
			this.Controls.Add(lvPromotion);
			this.Controls.Add(_chkFields_1);
			this.Controls.Add(_chkFields_0);
			this.Controls.Add(_DTFields_0);
			this.Controls.Add(_txtFields_0);
			this.Controls.Add(picButtons);
			this.Controls.Add(_DTFields_1);
			this.Controls.Add(Label2);
			this.Controls.Add(Label1);
			this.Controls.Add(_lblLabels_1);
			this.Controls.Add(_lblLabels_0);
			this.Controls.Add(_lblLabels_38);
			this.ShapeContainer1.Shapes.Add(_Shape1_2);
			this.Controls.Add(_lbl_5);
			this.Controls.Add(ShapeContainer1);
			this.picButtons.Controls.Add(cmdPrint);
			this.picButtons.Controls.Add(cmdClose);
			this.picButtons.Controls.Add(cmdCancel);
			//Me.DTFields.SetIndex(_DTFields_3, CType(3, Short))
			//Me.DTFields.SetIndex(_DTFields_2, CType(2, Short))
			//Me.DTFields.SetIndex(_DTFields_0, CType(0, Short))
			//Me.DTFields.SetIndex(_DTFields_1, CType(1, Short))
			//Me.chkFields.SetIndex(_chkFields_2, CType(2, Short))
			//Me.chkFields.SetIndex(_chkFields_1, CType(1, Short))
			//Me.chkFields.SetIndex(_chkFields_0, CType(0, Short))
			//Me.lbl.SetIndex(_lbl_5, CType(5, Short))
			//Me.lblLabels.SetIndex(_lblLabels_1, CType(1, Short))
			//Me.lblLabels.SetIndex(_lblLabels_0, CType(0, Short))
			//Me.lblLabels.SetIndex(_lblLabels_38, CType(38, Short))
			//Me.txtFields.SetIndex(_txtFields_0, CType(0, Short))
			this.Shape1.SetIndex(_Shape1_2, Convert.ToInt16(2));
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			//CType(Me.txtFields, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.chkFields, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.DTFields, System.ComponentModel.ISupportInitialize).EndInit()
			((System.ComponentModel.ISupportInitialize)this._DTFields_1).EndInit();
			((System.ComponentModel.ISupportInitialize)this._DTFields_0).EndInit();
			((System.ComponentModel.ISupportInitialize)this._DTFields_2).EndInit();
			((System.ComponentModel.ISupportInitialize)this._DTFields_3).EndInit();
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
