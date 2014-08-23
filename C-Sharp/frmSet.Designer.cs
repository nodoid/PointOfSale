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
	partial class frmSet
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmSet() : base()
		{
			Load += frmSet_Load;
			FormClosed += frmSet_FormClosed;
			Resize += frmSet_Resize;
			KeyDown += frmSet_KeyDown;
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
		public System.Windows.Forms.TextBox _txtFields_1;
		private System.Windows.Forms.CheckBox withEventsField_chkStockItem;
		public System.Windows.Forms.CheckBox chkStockItem {
			get { return withEventsField_chkStockItem; }
			set {
				if (withEventsField_chkStockItem != null) {
					withEventsField_chkStockItem.CheckStateChanged -= chkStockItem_CheckStateChanged;
				}
				withEventsField_chkStockItem = value;
				if (withEventsField_chkStockItem != null) {
					withEventsField_chkStockItem.CheckStateChanged += chkStockItem_CheckStateChanged;
				}
			}
		}
		public System.Windows.Forms.TextBox _txtFloat_7;
		public System.Windows.Forms.TextBox _txtFloat_6;
		public System.Windows.Forms.TextBox _txtFloat_5;
		public System.Windows.Forms.TextBox _txtFloat_4;
		public System.Windows.Forms.TextBox _txtFloat_3;
		public System.Windows.Forms.TextBox _txtFloat_2;
		public System.Windows.Forms.TextBox _txtFloat_1;
		public System.Windows.Forms.TextBox _txtFloat_0;
		public System.Windows.Forms.CheckBox _chkFields_2;
		private System.Windows.Forms.TextBox withEventsField__txtInteger_0;
		public System.Windows.Forms.TextBox _txtInteger_0 {
			get { return withEventsField__txtInteger_0; }
			set {
				if (withEventsField__txtInteger_0 != null) {
					withEventsField__txtInteger_0.Enter -= txtInteger_Enter;
					withEventsField__txtInteger_0.KeyPress -= txtInteger_KeyPress;
					withEventsField__txtInteger_0.Leave -= txtInteger_Leave;
				}
				withEventsField__txtInteger_0 = value;
				if (withEventsField__txtInteger_0 != null) {
					withEventsField__txtInteger_0.Enter += txtInteger_Enter;
					withEventsField__txtInteger_0.KeyPress += txtInteger_KeyPress;
					withEventsField__txtInteger_0.Leave += txtInteger_Leave;
				}
			}
		}
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
		private System.Windows.Forms.Button withEventsField_cmdAllocate;
		public System.Windows.Forms.Button cmdAllocate {
			get { return withEventsField_cmdAllocate; }
			set {
				if (withEventsField_cmdAllocate != null) {
					withEventsField_cmdAllocate.Click -= cmdAllocate_Click;
				}
				withEventsField_cmdAllocate = value;
				if (withEventsField_cmdAllocate != null) {
					withEventsField_cmdAllocate.Click += cmdAllocate_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdEmulate;
		public System.Windows.Forms.Button cmdEmulate {
			get { return withEventsField_cmdEmulate; }
			set {
				if (withEventsField_cmdEmulate != null) {
					withEventsField_cmdEmulate.Click -= cmdEmulate_Click;
				}
				withEventsField_cmdEmulate = value;
				if (withEventsField_cmdEmulate != null) {
					withEventsField_cmdEmulate.Click += cmdEmulate_Click;
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
		private myDataGridView withEventsField_cmbDeposit;
		public myDataGridView cmbDeposit {
			get { return withEventsField_cmbDeposit; }
			set {
				if (withEventsField_cmbDeposit != null) {
					withEventsField_cmbDeposit.KeyDown -= cmbDeposit_KeyDown;
				}
				withEventsField_cmbDeposit = value;
				if (withEventsField_cmbDeposit != null) {
					withEventsField_cmbDeposit.KeyDown += cmbDeposit_KeyDown;
				}
			}
		}
		public Microsoft.VisualBasic.PowerPacks.LineShape Line1;
		public System.Windows.Forms.Label lblStockitem;
		public System.Windows.Forms.Label _lblLabels_11;
		public System.Windows.Forms.Label _lblCG_7;
		public System.Windows.Forms.Label _lblCG_6;
		public System.Windows.Forms.Label _lblCG_5;
		public System.Windows.Forms.Label _lblCG_4;
		public System.Windows.Forms.Label _lblCG_3;
		public System.Windows.Forms.Label _lblCG_2;
		public System.Windows.Forms.Label _lblCG_1;
		public System.Windows.Forms.Label _lblCG_0;
		public System.Windows.Forms.Label _lblLabels_1;
		public System.Windows.Forms.Label _lblLabels_0;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_2;
		public System.Windows.Forms.Label _lbl_5;
		public System.Windows.Forms.Label _lbl_0;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_0;
		//Public WithEvents chkFields As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblCG As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		//Public WithEvents txtFloat As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		//Public WithEvents txtInteger As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		public RectangleShapeArray Shape1;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSet));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this._txtFields_1 = new System.Windows.Forms.TextBox();
			this.chkStockItem = new System.Windows.Forms.CheckBox();
			this._txtFloat_7 = new System.Windows.Forms.TextBox();
			this._txtFloat_6 = new System.Windows.Forms.TextBox();
			this._txtFloat_5 = new System.Windows.Forms.TextBox();
			this._txtFloat_4 = new System.Windows.Forms.TextBox();
			this._txtFloat_3 = new System.Windows.Forms.TextBox();
			this._txtFloat_2 = new System.Windows.Forms.TextBox();
			this._txtFloat_1 = new System.Windows.Forms.TextBox();
			this._txtFloat_0 = new System.Windows.Forms.TextBox();
			this._chkFields_2 = new System.Windows.Forms.CheckBox();
			this._txtInteger_0 = new System.Windows.Forms.TextBox();
			this._txtFields_0 = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.cmdAllocate = new System.Windows.Forms.Button();
			this.cmdEmulate = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this.cmbDeposit = new myDataGridView();
			this.Line1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
			this.lblStockitem = new System.Windows.Forms.Label();
			this._lblLabels_11 = new System.Windows.Forms.Label();
			this._lblCG_7 = new System.Windows.Forms.Label();
			this._lblCG_6 = new System.Windows.Forms.Label();
			this._lblCG_5 = new System.Windows.Forms.Label();
			this._lblCG_4 = new System.Windows.Forms.Label();
			this._lblCG_3 = new System.Windows.Forms.Label();
			this._lblCG_2 = new System.Windows.Forms.Label();
			this._lblCG_1 = new System.Windows.Forms.Label();
			this._lblCG_0 = new System.Windows.Forms.Label();
			this._lblLabels_1 = new System.Windows.Forms.Label();
			this._lblLabels_0 = new System.Windows.Forms.Label();
			this._Shape1_2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._lbl_5 = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this._Shape1_0 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			//Me.chkFields = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(components)
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblCG = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//'Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//M() 'e.txtFields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			//M() 'e.txtFloat = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			//Me.txtInteger = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			this.Shape1 = new RectangleShapeArray(components);
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.cmbDeposit).BeginInit();
			//CType(Me.chkFields, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblCG, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtFields, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtFloat, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtInteger, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Edit Stock Set Details";
			this.ClientSize = new System.Drawing.Size(412, 357);
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
			this.Name = "frmSet";
			this._txtFields_1.AutoSize = false;
			this._txtFields_1.Size = new System.Drawing.Size(46, 19);
			this._txtFields_1.Location = new System.Drawing.Point(258, 210);
			this._txtFields_1.TabIndex = 11;
			this._txtFields_1.Visible = false;
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
			this._txtFields_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_1.Name = "_txtFields_1";
			this.chkStockItem.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.chkStockItem.Text = "This Stock Set is locked to the following Stock Item";
			this.chkStockItem.Size = new System.Drawing.Size(286, 19);
			this.chkStockItem.Location = new System.Drawing.Point(66, 192);
			this.chkStockItem.TabIndex = 9;
			this.chkStockItem.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkStockItem.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkStockItem.CausesValidation = true;
			this.chkStockItem.Enabled = true;
			this.chkStockItem.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkStockItem.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkStockItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkStockItem.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkStockItem.TabStop = true;
			this.chkStockItem.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkStockItem.Visible = true;
			this.chkStockItem.Name = "chkStockItem";
			this._txtFloat_7.AutoSize = false;
			this._txtFloat_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloat_7.Size = new System.Drawing.Size(67, 19);
			this._txtFloat_7.Location = new System.Drawing.Point(249, 309);
			this._txtFloat_7.TabIndex = 27;
			this._txtFloat_7.AcceptsReturn = true;
			this._txtFloat_7.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_7.CausesValidation = true;
			this._txtFloat_7.Enabled = true;
			this._txtFloat_7.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_7.HideSelection = true;
			this._txtFloat_7.ReadOnly = false;
			this._txtFloat_7.MaxLength = 0;
			this._txtFloat_7.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_7.Multiline = false;
			this._txtFloat_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_7.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloat_7.TabStop = true;
			this._txtFloat_7.Visible = true;
			this._txtFloat_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_7.Name = "_txtFloat_7";
			this._txtFloat_6.AutoSize = false;
			this._txtFloat_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloat_6.Size = new System.Drawing.Size(67, 19);
			this._txtFloat_6.Location = new System.Drawing.Point(249, 288);
			this._txtFloat_6.TabIndex = 25;
			this._txtFloat_6.AcceptsReturn = true;
			this._txtFloat_6.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_6.CausesValidation = true;
			this._txtFloat_6.Enabled = true;
			this._txtFloat_6.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_6.HideSelection = true;
			this._txtFloat_6.ReadOnly = false;
			this._txtFloat_6.MaxLength = 0;
			this._txtFloat_6.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_6.Multiline = false;
			this._txtFloat_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_6.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloat_6.TabStop = true;
			this._txtFloat_6.Visible = true;
			this._txtFloat_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_6.Name = "_txtFloat_6";
			this._txtFloat_5.AutoSize = false;
			this._txtFloat_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloat_5.Size = new System.Drawing.Size(67, 19);
			this._txtFloat_5.Location = new System.Drawing.Point(249, 267);
			this._txtFloat_5.TabIndex = 23;
			this._txtFloat_5.AcceptsReturn = true;
			this._txtFloat_5.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_5.CausesValidation = true;
			this._txtFloat_5.Enabled = true;
			this._txtFloat_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_5.HideSelection = true;
			this._txtFloat_5.ReadOnly = false;
			this._txtFloat_5.MaxLength = 0;
			this._txtFloat_5.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_5.Multiline = false;
			this._txtFloat_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_5.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloat_5.TabStop = true;
			this._txtFloat_5.Visible = true;
			this._txtFloat_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_5.Name = "_txtFloat_5";
			this._txtFloat_4.AutoSize = false;
			this._txtFloat_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloat_4.Size = new System.Drawing.Size(67, 19);
			this._txtFloat_4.Location = new System.Drawing.Point(249, 246);
			this._txtFloat_4.TabIndex = 21;
			this._txtFloat_4.AcceptsReturn = true;
			this._txtFloat_4.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_4.CausesValidation = true;
			this._txtFloat_4.Enabled = true;
			this._txtFloat_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_4.HideSelection = true;
			this._txtFloat_4.ReadOnly = false;
			this._txtFloat_4.MaxLength = 0;
			this._txtFloat_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_4.Multiline = false;
			this._txtFloat_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_4.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloat_4.TabStop = true;
			this._txtFloat_4.Visible = true;
			this._txtFloat_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_4.Name = "_txtFloat_4";
			this._txtFloat_3.AutoSize = false;
			this._txtFloat_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloat_3.Size = new System.Drawing.Size(67, 19);
			this._txtFloat_3.Location = new System.Drawing.Point(117, 309);
			this._txtFloat_3.TabIndex = 19;
			this._txtFloat_3.AcceptsReturn = true;
			this._txtFloat_3.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_3.CausesValidation = true;
			this._txtFloat_3.Enabled = true;
			this._txtFloat_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_3.HideSelection = true;
			this._txtFloat_3.ReadOnly = false;
			this._txtFloat_3.MaxLength = 0;
			this._txtFloat_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_3.Multiline = false;
			this._txtFloat_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_3.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloat_3.TabStop = true;
			this._txtFloat_3.Visible = true;
			this._txtFloat_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_3.Name = "_txtFloat_3";
			this._txtFloat_2.AutoSize = false;
			this._txtFloat_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloat_2.Size = new System.Drawing.Size(67, 19);
			this._txtFloat_2.Location = new System.Drawing.Point(117, 288);
			this._txtFloat_2.TabIndex = 17;
			this._txtFloat_2.AcceptsReturn = true;
			this._txtFloat_2.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_2.CausesValidation = true;
			this._txtFloat_2.Enabled = true;
			this._txtFloat_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_2.HideSelection = true;
			this._txtFloat_2.ReadOnly = false;
			this._txtFloat_2.MaxLength = 0;
			this._txtFloat_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_2.Multiline = false;
			this._txtFloat_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_2.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloat_2.TabStop = true;
			this._txtFloat_2.Visible = true;
			this._txtFloat_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_2.Name = "_txtFloat_2";
			this._txtFloat_1.AutoSize = false;
			this._txtFloat_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloat_1.Size = new System.Drawing.Size(67, 19);
			this._txtFloat_1.Location = new System.Drawing.Point(117, 267);
			this._txtFloat_1.TabIndex = 15;
			this._txtFloat_1.AcceptsReturn = true;
			this._txtFloat_1.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_1.CausesValidation = true;
			this._txtFloat_1.Enabled = true;
			this._txtFloat_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_1.HideSelection = true;
			this._txtFloat_1.ReadOnly = false;
			this._txtFloat_1.MaxLength = 0;
			this._txtFloat_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_1.Multiline = false;
			this._txtFloat_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloat_1.TabStop = true;
			this._txtFloat_1.Visible = true;
			this._txtFloat_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_1.Name = "_txtFloat_1";
			this._txtFloat_0.AutoSize = false;
			this._txtFloat_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtFloat_0.Size = new System.Drawing.Size(67, 19);
			this._txtFloat_0.Location = new System.Drawing.Point(117, 246);
			this._txtFloat_0.TabIndex = 13;
			this._txtFloat_0.AcceptsReturn = true;
			this._txtFloat_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtFloat_0.CausesValidation = true;
			this._txtFloat_0.Enabled = true;
			this._txtFloat_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtFloat_0.HideSelection = true;
			this._txtFloat_0.ReadOnly = false;
			this._txtFloat_0.MaxLength = 0;
			this._txtFloat_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtFloat_0.Multiline = false;
			this._txtFloat_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFloat_0.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFloat_0.TabStop = true;
			this._txtFloat_0.Visible = true;
			this._txtFloat_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFloat_0.Name = "_txtFloat_0";
			this._chkFields_2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._chkFields_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._chkFields_2.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._chkFields_2.Text = "Disable this Set:";
			this._chkFields_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._chkFields_2.Size = new System.Drawing.Size(97, 16);
			this._chkFields_2.Location = new System.Drawing.Point(252, 138);
			this._chkFields_2.TabIndex = 7;
			this._chkFields_2.CausesValidation = true;
			this._chkFields_2.Enabled = true;
			this._chkFields_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._chkFields_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._chkFields_2.Appearance = System.Windows.Forms.Appearance.Normal;
			this._chkFields_2.TabStop = true;
			this._chkFields_2.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this._chkFields_2.Visible = true;
			this._chkFields_2.Name = "_chkFields_2";
			this._txtInteger_0.AutoSize = false;
			this._txtInteger_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtInteger_0.Size = new System.Drawing.Size(40, 19);
			this._txtInteger_0.Location = new System.Drawing.Point(309, 114);
			this._txtInteger_0.TabIndex = 6;
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
			this._txtFields_0.AutoSize = false;
			this._txtFields_0.Size = new System.Drawing.Size(226, 19);
			this._txtFields_0.Location = new System.Drawing.Point(123, 66);
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
			this.picButtons.Size = new System.Drawing.Size(412, 39);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 30;
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
			this.cmdPrint.Location = new System.Drawing.Point(237, 3);
			this.cmdPrint.TabIndex = 33;
			this.cmdPrint.TabStop = false;
			this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrint.CausesValidation = true;
			this.cmdPrint.Enabled = true;
			this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdAllocate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAllocate.Text = "&Allocate Stock Items";
			this.cmdAllocate.Size = new System.Drawing.Size(73, 29);
			this.cmdAllocate.Location = new System.Drawing.Point(159, 3);
			this.cmdAllocate.TabIndex = 32;
			this.cmdAllocate.TabStop = false;
			this.cmdAllocate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAllocate.CausesValidation = true;
			this.cmdAllocate.Enabled = true;
			this.cmdAllocate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAllocate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAllocate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAllocate.Name = "cmdAllocate";
			this.cmdEmulate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdEmulate.Text = "&Emulate Pricing";
			this.cmdEmulate.Size = new System.Drawing.Size(73, 29);
			this.cmdEmulate.Location = new System.Drawing.Point(81, 3);
			this.cmdEmulate.TabIndex = 31;
			this.cmdEmulate.TabStop = false;
			this.cmdEmulate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdEmulate.CausesValidation = true;
			this.cmdEmulate.Enabled = true;
			this.cmdEmulate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdEmulate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdEmulate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdEmulate.Name = "cmdEmulate";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "&Undo";
			this.cmdCancel.Size = new System.Drawing.Size(73, 29);
			this.cmdCancel.Location = new System.Drawing.Point(5, 3);
			this.cmdCancel.TabIndex = 29;
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
			this.cmdClose.Location = new System.Drawing.Point(315, 3);
			this.cmdClose.TabIndex = 28;
			this.cmdClose.TabStop = false;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Name = "cmdClose";
			//cmbDeposit.OcxState = CType(resources.GetObject("cmbDeposit.OcxState"), System.Windows.Forms.AxHost.State)
			this.cmbDeposit.Size = new System.Drawing.Size(226, 21);
			this.cmbDeposit.Location = new System.Drawing.Point(123, 90);
			this.cmbDeposit.TabIndex = 4;
			this.cmbDeposit.Name = "cmbDeposit";
			this.Line1.X1 = 60;
			this.Line1.X2 = 351;
			this.Line1.Y1 = 237;
			this.Line1.Y2 = 237;
			this.Line1.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Line1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this.Line1.BorderWidth = 1;
			this.Line1.Visible = true;
			this.Line1.Name = "Line1";
			this.lblStockitem.Text = "[No stock Item ...]";
			this.lblStockitem.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblStockitem.Size = new System.Drawing.Size(267, 13);
			this.lblStockitem.Location = new System.Drawing.Point(66, 213);
			this.lblStockitem.TabIndex = 10;
			this.lblStockitem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblStockitem.BackColor = System.Drawing.Color.Transparent;
			this.lblStockitem.Enabled = true;
			this.lblStockitem.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblStockitem.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblStockitem.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblStockitem.UseMnemonic = true;
			this.lblStockitem.Visible = true;
			this.lblStockitem.AutoSize = false;
			this.lblStockitem.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblStockitem.Name = "lblStockitem";
			this._lblLabels_11.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_11.Text = "Deposit:";
			this._lblLabels_11.Size = new System.Drawing.Size(40, 13);
			this._lblLabels_11.Location = new System.Drawing.Point(78, 96);
			this._lblLabels_11.TabIndex = 3;
			this._lblLabels_11.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_11.Enabled = true;
			this._lblLabels_11.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_11.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_11.UseMnemonic = true;
			this._lblLabels_11.Visible = true;
			this._lblLabels_11.AutoSize = true;
			this._lblLabels_11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_11.Name = "_lblLabels_11";
			this._lblCG_7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblCG_7.Text = "Set_Amount8:";
			this._lblCG_7.Size = new System.Drawing.Size(67, 13);
			this._lblCG_7.Location = new System.Drawing.Point(174, 312);
			this._lblCG_7.TabIndex = 26;
			this._lblCG_7.BackColor = System.Drawing.Color.Transparent;
			this._lblCG_7.Enabled = true;
			this._lblCG_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblCG_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblCG_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblCG_7.UseMnemonic = true;
			this._lblCG_7.Visible = true;
			this._lblCG_7.AutoSize = true;
			this._lblCG_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblCG_7.Name = "_lblCG_7";
			this._lblCG_6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblCG_6.Text = "Set_Amount7:";
			this._lblCG_6.Size = new System.Drawing.Size(67, 13);
			this._lblCG_6.Location = new System.Drawing.Point(174, 291);
			this._lblCG_6.TabIndex = 24;
			this._lblCG_6.BackColor = System.Drawing.Color.Transparent;
			this._lblCG_6.Enabled = true;
			this._lblCG_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblCG_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblCG_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblCG_6.UseMnemonic = true;
			this._lblCG_6.Visible = true;
			this._lblCG_6.AutoSize = true;
			this._lblCG_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblCG_6.Name = "_lblCG_6";
			this._lblCG_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblCG_5.Text = "Set_Amount6:";
			this._lblCG_5.Size = new System.Drawing.Size(67, 13);
			this._lblCG_5.Location = new System.Drawing.Point(174, 270);
			this._lblCG_5.TabIndex = 22;
			this._lblCG_5.BackColor = System.Drawing.Color.Transparent;
			this._lblCG_5.Enabled = true;
			this._lblCG_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblCG_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblCG_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblCG_5.UseMnemonic = true;
			this._lblCG_5.Visible = true;
			this._lblCG_5.AutoSize = true;
			this._lblCG_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblCG_5.Name = "_lblCG_5";
			this._lblCG_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblCG_4.Text = "Set_Amount5:";
			this._lblCG_4.Size = new System.Drawing.Size(67, 13);
			this._lblCG_4.Location = new System.Drawing.Point(174, 249);
			this._lblCG_4.TabIndex = 20;
			this._lblCG_4.BackColor = System.Drawing.Color.Transparent;
			this._lblCG_4.Enabled = true;
			this._lblCG_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblCG_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblCG_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblCG_4.UseMnemonic = true;
			this._lblCG_4.Visible = true;
			this._lblCG_4.AutoSize = true;
			this._lblCG_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblCG_4.Name = "_lblCG_4";
			this._lblCG_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblCG_3.Text = "Set_Amount4:";
			this._lblCG_3.Size = new System.Drawing.Size(67, 13);
			this._lblCG_3.Location = new System.Drawing.Point(42, 312);
			this._lblCG_3.TabIndex = 18;
			this._lblCG_3.BackColor = System.Drawing.Color.Transparent;
			this._lblCG_3.Enabled = true;
			this._lblCG_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblCG_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblCG_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblCG_3.UseMnemonic = true;
			this._lblCG_3.Visible = true;
			this._lblCG_3.AutoSize = true;
			this._lblCG_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblCG_3.Name = "_lblCG_3";
			this._lblCG_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblCG_2.Text = "Set_Amount3:";
			this._lblCG_2.Size = new System.Drawing.Size(67, 13);
			this._lblCG_2.Location = new System.Drawing.Point(42, 291);
			this._lblCG_2.TabIndex = 16;
			this._lblCG_2.BackColor = System.Drawing.Color.Transparent;
			this._lblCG_2.Enabled = true;
			this._lblCG_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblCG_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblCG_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblCG_2.UseMnemonic = true;
			this._lblCG_2.Visible = true;
			this._lblCG_2.AutoSize = true;
			this._lblCG_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblCG_2.Name = "_lblCG_2";
			this._lblCG_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblCG_1.Text = "Set_Amount2:";
			this._lblCG_1.Size = new System.Drawing.Size(67, 13);
			this._lblCG_1.Location = new System.Drawing.Point(42, 270);
			this._lblCG_1.TabIndex = 14;
			this._lblCG_1.BackColor = System.Drawing.Color.Transparent;
			this._lblCG_1.Enabled = true;
			this._lblCG_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblCG_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblCG_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblCG_1.UseMnemonic = true;
			this._lblCG_1.Visible = true;
			this._lblCG_1.AutoSize = true;
			this._lblCG_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblCG_1.Name = "_lblCG_1";
			this._lblCG_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblCG_0.Text = "Set_Amout1:";
			this._lblCG_0.Size = new System.Drawing.Size(61, 13);
			this._lblCG_0.Location = new System.Drawing.Point(48, 249);
			this._lblCG_0.TabIndex = 12;
			this._lblCG_0.BackColor = System.Drawing.Color.Transparent;
			this._lblCG_0.Enabled = true;
			this._lblCG_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblCG_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblCG_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblCG_0.UseMnemonic = true;
			this._lblCG_0.Visible = true;
			this._lblCG_0.AutoSize = true;
			this._lblCG_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblCG_0.Name = "_lblCG_0";
			this._lblLabels_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_1.Text = "Number of Units in the Set:";
			this._lblLabels_1.Size = new System.Drawing.Size(127, 13);
			this._lblLabels_1.Location = new System.Drawing.Point(180, 117);
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
			this._lblLabels_0.Text = "Set Name:";
			this._lblLabels_0.Size = new System.Drawing.Size(52, 13);
			this._lblLabels_0.Location = new System.Drawing.Point(66, 69);
			this._lblLabels_0.TabIndex = 1;
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
			this._Shape1_2.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_2.Size = new System.Drawing.Size(304, 100);
			this._Shape1_2.Location = new System.Drawing.Point(54, 60);
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
			this._lbl_5.Size = new System.Drawing.Size(61, 13);
			this._lbl_5.Location = new System.Drawing.Point(54, 45);
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
			this._lbl_0.BackColor = System.Drawing.Color.Transparent;
			this._lbl_0.Text = "&2. Pricing Per Sale Channel";
			this._lbl_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_0.Size = new System.Drawing.Size(157, 13);
			this._lbl_0.Location = new System.Drawing.Point(57, 171);
			this._lbl_0.TabIndex = 8;
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
			this._Shape1_0.Size = new System.Drawing.Size(304, 151);
			this._Shape1_0.Location = new System.Drawing.Point(54, 186);
			this._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_0.BorderWidth = 1;
			this._Shape1_0.FillColor = System.Drawing.Color.Black;
			this._Shape1_0.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_0.Visible = true;
			this._Shape1_0.Name = "_Shape1_0";
			this.Controls.Add(_txtFields_1);
			this.Controls.Add(chkStockItem);
			this.Controls.Add(_txtFloat_7);
			this.Controls.Add(_txtFloat_6);
			this.Controls.Add(_txtFloat_5);
			this.Controls.Add(_txtFloat_4);
			this.Controls.Add(_txtFloat_3);
			this.Controls.Add(_txtFloat_2);
			this.Controls.Add(_txtFloat_1);
			this.Controls.Add(_txtFloat_0);
			this.Controls.Add(_chkFields_2);
			this.Controls.Add(_txtInteger_0);
			this.Controls.Add(_txtFields_0);
			this.Controls.Add(picButtons);
			this.Controls.Add(cmbDeposit);
			this.ShapeContainer1.Shapes.Add(Line1);
			this.Controls.Add(lblStockitem);
			this.Controls.Add(_lblLabels_11);
			this.Controls.Add(_lblCG_7);
			this.Controls.Add(_lblCG_6);
			this.Controls.Add(_lblCG_5);
			this.Controls.Add(_lblCG_4);
			this.Controls.Add(_lblCG_3);
			this.Controls.Add(_lblCG_2);
			this.Controls.Add(_lblCG_1);
			this.Controls.Add(_lblCG_0);
			this.Controls.Add(_lblLabels_1);
			this.Controls.Add(_lblLabels_0);
			this.ShapeContainer1.Shapes.Add(_Shape1_2);
			this.Controls.Add(_lbl_5);
			this.Controls.Add(_lbl_0);
			this.ShapeContainer1.Shapes.Add(_Shape1_0);
			this.Controls.Add(ShapeContainer1);
			this.picButtons.Controls.Add(cmdPrint);
			this.picButtons.Controls.Add(cmdAllocate);
			this.picButtons.Controls.Add(cmdEmulate);
			this.picButtons.Controls.Add(cmdCancel);
			this.picButtons.Controls.Add(cmdClose);
			//Me.chkFields.SetIndex(_chkFields_2, CType(2, Short))
			//Me.lbl.SetIndex(_lbl_5, CType(5, Short))
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//Me.lblCG.SetIndex(_lblCG_7, CType(7, Short))
			//Me.lblCG.SetIndex(_lblCG_6, CType(6, Short))
			//Me.lblCG.SetIndex(_lblCG_5, CType(5, Short))
			//Me.lblCG.SetIndex(_lblCG_4, CType(4, Short))
			//Me.lblCG.SetIndex(_lblCG_3, CType(3, Short))
			//Me.lblCG.SetIndex(_lblCG_2, CType(2, Short))
			//Me.lblCG.SetIndex(_lblCG_1, CType(1, Short))
			//Me.lblCG.SetIndex(_lblCG_0, CType(0, Short))
			//Me.lblLabels.SetIndex(_lblLabels_11, CType(11, Short))
			//Me.lblLabels.SetIndex(_lblLabels_1, CType(1, Short))
			//Me.lblLabels.SetIndex(_lblLabels_0, CType(0, Short))
			//Me.txtFields.SetIndex(_txtFields_1, CType(1, Short))
			//Me.txtFields.SetIndex(_txtFields_0, CType(0, Short))
			//Me.txtFloat.SetIndex(_txtFloat_7, CType(7, Short))
			//Me.txtFloat.SetIndex(_txtFloat_6, CType(6, Short))
			//Me.txtFloat.SetIndex(_txtFloat_5, CType(5, Short))
			//Me.txtFloat.SetIndex(_txtFloat_4, CType(4, Short))
			//Me.txtFloat.SetIndex(_txtFloat_3, CType(3, Short))
			//Me.txtFloat.SetIndex(_txtFloat_2, CType(2, Short))
			//Me.txtFloat.SetIndex(_txtFloat_1, CType(1, Short))
			//Me.txtFloat.SetIndex(_txtFloat_0, CType(0, Short))
			//Me.txtInteger.SetIndex(_txtInteger_0, CType(0, Short))
			this.Shape1.SetIndex(_Shape1_2, Convert.ToInt16(2));
			this.Shape1.SetIndex(_Shape1_0, Convert.ToInt16(0));
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			//CType(Me.txtInteger, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.txtFloat, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.txtFields, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblCG, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.chkFields, System.ComponentModel.ISupportInitialize).EndInit()
			((System.ComponentModel.ISupportInitialize)this.cmbDeposit).EndInit();
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
