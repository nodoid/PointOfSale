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
	partial class frmPricingMatrix
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmPricingMatrix() : base()
		{
			Load += frmPricingMatrix_Load;
			KeyPress += frmPricingMatrix_KeyPress;
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
		private System.Windows.Forms.Button withEventsField_Command1;
		public System.Windows.Forms.Button Command1 {
			get { return withEventsField_Command1; }
			set {
				if (withEventsField_Command1 != null) {
					withEventsField_Command1.Click -= Command1_Click;
				}
				withEventsField_Command1 = value;
				if (withEventsField_Command1 != null) {
					withEventsField_Command1.Click += Command1_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdExit;
		public System.Windows.Forms.Button cmdExit {
			get { return withEventsField_cmdExit; }
			set {
				if (withEventsField_cmdExit != null) {
					withEventsField_cmdExit.Click -= cmdExit_Click;
				}
				withEventsField_cmdExit = value;
				if (withEventsField_cmdExit != null) {
					withEventsField_cmdExit.Click += cmdExit_Click;
				}
			}
		}
		public System.Windows.Forms.Panel picButtons;
		public System.Windows.Forms.TextBox _txtUnit_7;
		public System.Windows.Forms.TextBox _txtCase_7;
		public System.Windows.Forms.TextBox _txtUnit_8;
		public System.Windows.Forms.TextBox _txtCase_8;
		public System.Windows.Forms.TextBox _txtUnit_6;
		public System.Windows.Forms.TextBox _txtCase_6;
		public System.Windows.Forms.TextBox _txtUnit_5;
		public System.Windows.Forms.TextBox _txtCase_5;
		public System.Windows.Forms.TextBox _txtUnit_4;
		public System.Windows.Forms.TextBox _txtCase_4;
		public System.Windows.Forms.TextBox _txtUnit_3;
		public System.Windows.Forms.TextBox _txtCase_3;
		public System.Windows.Forms.TextBox _txtUnit_2;
		public System.Windows.Forms.TextBox _txtCase_2;
		public System.Windows.Forms.TextBox _txtCase_1;
		public System.Windows.Forms.TextBox _txtUnit_1;
		public System.Windows.Forms.Label _lblPricingGroup_8;
		public System.Windows.Forms.Label _lblPricingGroup_7;
		public System.Windows.Forms.Label _lblPricingGroup_6;
		public System.Windows.Forms.Label _lblPricingGroup_5;
		public System.Windows.Forms.Label _lblPricingGroup_4;
		public System.Windows.Forms.Label _lblPricingGroup_3;
		public System.Windows.Forms.Label _lblPricingGroup_2;
		public System.Windows.Forms.Label _lblPricingGroup_1;
		public System.Windows.Forms.Label _lbl_5;
		public System.Windows.Forms.Label _lbl_2;
		private System.Windows.Forms.Label withEventsField_lblHeading;
		public System.Windows.Forms.Label lblHeading {
			get { return withEventsField_lblHeading; }
			set {
				if (withEventsField_lblHeading != null) {
					withEventsField_lblHeading.Click -= lblHeading_Click;
				}
				withEventsField_lblHeading = value;
				if (withEventsField_lblHeading != null) {
					withEventsField_lblHeading.Click += lblHeading_Click;
				}
			}
		}
		public System.Windows.Forms.GroupBox _frmDetails_0;
		private System.Windows.Forms.TextBox withEventsField_txtEdit;
		public System.Windows.Forms.TextBox txtEdit {
			get { return withEventsField_txtEdit; }
			set {
				if (withEventsField_txtEdit != null) {
					withEventsField_txtEdit.Enter -= txtEdit_Enter;
					withEventsField_txtEdit.KeyDown -= txtEdit_KeyDown;
					withEventsField_txtEdit.KeyPress -= txtEdit_KeyPress;
				}
				withEventsField_txtEdit = value;
				if (withEventsField_txtEdit != null) {
					withEventsField_txtEdit.Enter += txtEdit_Enter;
					withEventsField_txtEdit.KeyDown += txtEdit_KeyDown;
					withEventsField_txtEdit.KeyPress += txtEdit_KeyPress;
				}
			}
		}
		private myDataGridView withEventsField_gridItem;
		public myDataGridView gridItem {
			get { return withEventsField_gridItem; }
			set {
				if (withEventsField_gridItem != null) {
					withEventsField_gridItem.Enter -= gridItem_Enter;
					withEventsField_gridItem.KeyPress -= gridItem_KeyPress;
				}
				withEventsField_gridItem = value;
				if (withEventsField_gridItem != null) {
					withEventsField_gridItem.Enter += gridItem_Enter;
					withEventsField_gridItem.KeyPress += gridItem_KeyPress;
				}
			}
		}
		public System.Windows.Forms.Label lblColorChanged;
		public System.Windows.Forms.Label _lblColorFixed_1;
		public System.Windows.Forms.Label _lblColorFixed_0;
		public System.Windows.Forms.Label _lblcolor_1;
		public System.Windows.Forms.Label _lblcolor_0;
		//Public WithEvents frmDetails As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblColorFixed As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblPricingGroup As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblcolor As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents txtCase As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		//Public WithEvents txtUnit As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPricingMatrix));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.Command1 = new System.Windows.Forms.Button();
			this.cmdExit = new System.Windows.Forms.Button();
			this._frmDetails_0 = new System.Windows.Forms.GroupBox();
			this._txtUnit_7 = new System.Windows.Forms.TextBox();
			this._txtCase_7 = new System.Windows.Forms.TextBox();
			this._txtUnit_8 = new System.Windows.Forms.TextBox();
			this._txtCase_8 = new System.Windows.Forms.TextBox();
			this._txtUnit_6 = new System.Windows.Forms.TextBox();
			this._txtCase_6 = new System.Windows.Forms.TextBox();
			this._txtUnit_5 = new System.Windows.Forms.TextBox();
			this._txtCase_5 = new System.Windows.Forms.TextBox();
			this._txtUnit_4 = new System.Windows.Forms.TextBox();
			this._txtCase_4 = new System.Windows.Forms.TextBox();
			this._txtUnit_3 = new System.Windows.Forms.TextBox();
			this._txtCase_3 = new System.Windows.Forms.TextBox();
			this._txtUnit_2 = new System.Windows.Forms.TextBox();
			this._txtCase_2 = new System.Windows.Forms.TextBox();
			this._txtCase_1 = new System.Windows.Forms.TextBox();
			this._txtUnit_1 = new System.Windows.Forms.TextBox();
			this._lblPricingGroup_8 = new System.Windows.Forms.Label();
			this._lblPricingGroup_7 = new System.Windows.Forms.Label();
			this._lblPricingGroup_6 = new System.Windows.Forms.Label();
			this._lblPricingGroup_5 = new System.Windows.Forms.Label();
			this._lblPricingGroup_4 = new System.Windows.Forms.Label();
			this._lblPricingGroup_3 = new System.Windows.Forms.Label();
			this._lblPricingGroup_2 = new System.Windows.Forms.Label();
			this._lblPricingGroup_1 = new System.Windows.Forms.Label();
			this._lbl_5 = new System.Windows.Forms.Label();
			this._lbl_2 = new System.Windows.Forms.Label();
			this.lblHeading = new System.Windows.Forms.Label();
			this.txtEdit = new System.Windows.Forms.TextBox();
			this.gridItem = new myDataGridView();
			this.lblColorChanged = new System.Windows.Forms.Label();
			this._lblColorFixed_1 = new System.Windows.Forms.Label();
			this._lblColorFixed_0 = new System.Windows.Forms.Label();
			this._lblcolor_1 = new System.Windows.Forms.Label();
			this._lblcolor_0 = new System.Windows.Forms.Label();
			//Me.frmDetails = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblColorFixed = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblPricingGroup = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblcolor = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.txtCase = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			//Me.txtUnit = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			this.picButtons.SuspendLayout();
			this._frmDetails_0.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.gridItem).BeginInit();
			//CType(Me.frmDetails, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblColorFixed, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblPricingGroup, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblcolor, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtCase, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtUnit, System.ComponentModel.ISupportInitialize).BeginInit()
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Text = "Detailed Pricing Matrices";
			this.ClientSize = new System.Drawing.Size(543, 525);
			this.Location = new System.Drawing.Point(3, 22);
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
			this.Name = "frmPricingMatrix";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(543, 39);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 35;
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
			this.cmdPrint.Location = new System.Drawing.Point(368, 3);
			this.cmdPrint.TabIndex = 38;
			this.cmdPrint.TabStop = false;
			this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrint.CausesValidation = true;
			this.cmdPrint.Enabled = true;
			this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrint.Name = "cmdPrint";
			this.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Command1.Text = "Command1";
			this.Command1.Size = new System.Drawing.Size(97, 25);
			this.Command1.Location = new System.Drawing.Point(16, 8);
			this.Command1.TabIndex = 37;
			this.Command1.Visible = false;
			this.Command1.BackColor = System.Drawing.SystemColors.Control;
			this.Command1.CausesValidation = true;
			this.Command1.Enabled = true;
			this.Command1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command1.TabStop = true;
			this.Command1.Name = "Command1";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Size = new System.Drawing.Size(73, 29);
			this.cmdExit.Location = new System.Drawing.Point(462, 3);
			this.cmdExit.TabIndex = 36;
			this.cmdExit.TabStop = false;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Name = "cmdExit";
			this._frmDetails_0.Text = "Frame1";
			this._frmDetails_0.Size = new System.Drawing.Size(532, 88);
			this._frmDetails_0.Location = new System.Drawing.Point(0, 48);
			this._frmDetails_0.TabIndex = 2;
			this._frmDetails_0.BackColor = System.Drawing.SystemColors.Control;
			this._frmDetails_0.Enabled = true;
			this._frmDetails_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmDetails_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._frmDetails_0.Visible = true;
			this._frmDetails_0.Padding = new System.Windows.Forms.Padding(0);
			this._frmDetails_0.Name = "_frmDetails_0";
			this._txtUnit_7.AutoSize = false;
			this._txtUnit_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtUnit_7.Enabled = false;
			this._txtUnit_7.Size = new System.Drawing.Size(46, 19);
			this._txtUnit_7.Location = new System.Drawing.Point(405, 39);
			this._txtUnit_7.TabIndex = 18;
			this._txtUnit_7.Text = "0.00";
			this._txtUnit_7.AcceptsReturn = true;
			this._txtUnit_7.BackColor = System.Drawing.SystemColors.Window;
			this._txtUnit_7.CausesValidation = true;
			this._txtUnit_7.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtUnit_7.HideSelection = true;
			this._txtUnit_7.ReadOnly = false;
			this._txtUnit_7.MaxLength = 0;
			this._txtUnit_7.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtUnit_7.Multiline = false;
			this._txtUnit_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtUnit_7.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtUnit_7.TabStop = true;
			this._txtUnit_7.Visible = true;
			this._txtUnit_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtUnit_7.Name = "_txtUnit_7";
			this._txtCase_7.AutoSize = false;
			this._txtCase_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCase_7.Enabled = false;
			this._txtCase_7.Size = new System.Drawing.Size(46, 19);
			this._txtCase_7.Location = new System.Drawing.Point(405, 57);
			this._txtCase_7.TabIndex = 17;
			this._txtCase_7.Text = "0.00";
			this._txtCase_7.AcceptsReturn = true;
			this._txtCase_7.BackColor = System.Drawing.SystemColors.Window;
			this._txtCase_7.CausesValidation = true;
			this._txtCase_7.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtCase_7.HideSelection = true;
			this._txtCase_7.ReadOnly = false;
			this._txtCase_7.MaxLength = 0;
			this._txtCase_7.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtCase_7.Multiline = false;
			this._txtCase_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtCase_7.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtCase_7.TabStop = true;
			this._txtCase_7.Visible = true;
			this._txtCase_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtCase_7.Name = "_txtCase_7";
			this._txtUnit_8.AutoSize = false;
			this._txtUnit_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtUnit_8.Enabled = false;
			this._txtUnit_8.Size = new System.Drawing.Size(46, 19);
			this._txtUnit_8.Location = new System.Drawing.Point(453, 39);
			this._txtUnit_8.TabIndex = 16;
			this._txtUnit_8.Text = "0.00";
			this._txtUnit_8.AcceptsReturn = true;
			this._txtUnit_8.BackColor = System.Drawing.SystemColors.Window;
			this._txtUnit_8.CausesValidation = true;
			this._txtUnit_8.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtUnit_8.HideSelection = true;
			this._txtUnit_8.ReadOnly = false;
			this._txtUnit_8.MaxLength = 0;
			this._txtUnit_8.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtUnit_8.Multiline = false;
			this._txtUnit_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtUnit_8.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtUnit_8.TabStop = true;
			this._txtUnit_8.Visible = true;
			this._txtUnit_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtUnit_8.Name = "_txtUnit_8";
			this._txtCase_8.AutoSize = false;
			this._txtCase_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCase_8.Enabled = false;
			this._txtCase_8.Size = new System.Drawing.Size(46, 19);
			this._txtCase_8.Location = new System.Drawing.Point(453, 57);
			this._txtCase_8.TabIndex = 15;
			this._txtCase_8.Text = "0.00";
			this._txtCase_8.AcceptsReturn = true;
			this._txtCase_8.BackColor = System.Drawing.SystemColors.Window;
			this._txtCase_8.CausesValidation = true;
			this._txtCase_8.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtCase_8.HideSelection = true;
			this._txtCase_8.ReadOnly = false;
			this._txtCase_8.MaxLength = 0;
			this._txtCase_8.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtCase_8.Multiline = false;
			this._txtCase_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtCase_8.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtCase_8.TabStop = true;
			this._txtCase_8.Visible = true;
			this._txtCase_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtCase_8.Name = "_txtCase_8";
			this._txtUnit_6.AutoSize = false;
			this._txtUnit_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtUnit_6.Enabled = false;
			this._txtUnit_6.Size = new System.Drawing.Size(46, 19);
			this._txtUnit_6.Location = new System.Drawing.Point(357, 39);
			this._txtUnit_6.TabIndex = 14;
			this._txtUnit_6.Text = "0.00";
			this._txtUnit_6.AcceptsReturn = true;
			this._txtUnit_6.BackColor = System.Drawing.SystemColors.Window;
			this._txtUnit_6.CausesValidation = true;
			this._txtUnit_6.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtUnit_6.HideSelection = true;
			this._txtUnit_6.ReadOnly = false;
			this._txtUnit_6.MaxLength = 0;
			this._txtUnit_6.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtUnit_6.Multiline = false;
			this._txtUnit_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtUnit_6.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtUnit_6.TabStop = true;
			this._txtUnit_6.Visible = true;
			this._txtUnit_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtUnit_6.Name = "_txtUnit_6";
			this._txtCase_6.AutoSize = false;
			this._txtCase_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCase_6.Enabled = false;
			this._txtCase_6.Size = new System.Drawing.Size(46, 19);
			this._txtCase_6.Location = new System.Drawing.Point(357, 57);
			this._txtCase_6.TabIndex = 13;
			this._txtCase_6.Text = "0.00";
			this._txtCase_6.AcceptsReturn = true;
			this._txtCase_6.BackColor = System.Drawing.SystemColors.Window;
			this._txtCase_6.CausesValidation = true;
			this._txtCase_6.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtCase_6.HideSelection = true;
			this._txtCase_6.ReadOnly = false;
			this._txtCase_6.MaxLength = 0;
			this._txtCase_6.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtCase_6.Multiline = false;
			this._txtCase_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtCase_6.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtCase_6.TabStop = true;
			this._txtCase_6.Visible = true;
			this._txtCase_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtCase_6.Name = "_txtCase_6";
			this._txtUnit_5.AutoSize = false;
			this._txtUnit_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtUnit_5.Enabled = false;
			this._txtUnit_5.Size = new System.Drawing.Size(46, 19);
			this._txtUnit_5.Location = new System.Drawing.Point(309, 39);
			this._txtUnit_5.TabIndex = 12;
			this._txtUnit_5.Text = "0.00";
			this._txtUnit_5.AcceptsReturn = true;
			this._txtUnit_5.BackColor = System.Drawing.SystemColors.Window;
			this._txtUnit_5.CausesValidation = true;
			this._txtUnit_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtUnit_5.HideSelection = true;
			this._txtUnit_5.ReadOnly = false;
			this._txtUnit_5.MaxLength = 0;
			this._txtUnit_5.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtUnit_5.Multiline = false;
			this._txtUnit_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtUnit_5.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtUnit_5.TabStop = true;
			this._txtUnit_5.Visible = true;
			this._txtUnit_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtUnit_5.Name = "_txtUnit_5";
			this._txtCase_5.AutoSize = false;
			this._txtCase_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCase_5.Enabled = false;
			this._txtCase_5.Size = new System.Drawing.Size(46, 19);
			this._txtCase_5.Location = new System.Drawing.Point(309, 57);
			this._txtCase_5.TabIndex = 11;
			this._txtCase_5.Text = "0.00";
			this._txtCase_5.AcceptsReturn = true;
			this._txtCase_5.BackColor = System.Drawing.SystemColors.Window;
			this._txtCase_5.CausesValidation = true;
			this._txtCase_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtCase_5.HideSelection = true;
			this._txtCase_5.ReadOnly = false;
			this._txtCase_5.MaxLength = 0;
			this._txtCase_5.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtCase_5.Multiline = false;
			this._txtCase_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtCase_5.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtCase_5.TabStop = true;
			this._txtCase_5.Visible = true;
			this._txtCase_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtCase_5.Name = "_txtCase_5";
			this._txtUnit_4.AutoSize = false;
			this._txtUnit_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtUnit_4.Enabled = false;
			this._txtUnit_4.Size = new System.Drawing.Size(46, 19);
			this._txtUnit_4.Location = new System.Drawing.Point(261, 39);
			this._txtUnit_4.TabIndex = 10;
			this._txtUnit_4.Text = "0.00";
			this._txtUnit_4.AcceptsReturn = true;
			this._txtUnit_4.BackColor = System.Drawing.SystemColors.Window;
			this._txtUnit_4.CausesValidation = true;
			this._txtUnit_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtUnit_4.HideSelection = true;
			this._txtUnit_4.ReadOnly = false;
			this._txtUnit_4.MaxLength = 0;
			this._txtUnit_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtUnit_4.Multiline = false;
			this._txtUnit_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtUnit_4.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtUnit_4.TabStop = true;
			this._txtUnit_4.Visible = true;
			this._txtUnit_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtUnit_4.Name = "_txtUnit_4";
			this._txtCase_4.AutoSize = false;
			this._txtCase_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCase_4.Enabled = false;
			this._txtCase_4.Size = new System.Drawing.Size(46, 19);
			this._txtCase_4.Location = new System.Drawing.Point(261, 57);
			this._txtCase_4.TabIndex = 9;
			this._txtCase_4.Text = "0.00";
			this._txtCase_4.AcceptsReturn = true;
			this._txtCase_4.BackColor = System.Drawing.SystemColors.Window;
			this._txtCase_4.CausesValidation = true;
			this._txtCase_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtCase_4.HideSelection = true;
			this._txtCase_4.ReadOnly = false;
			this._txtCase_4.MaxLength = 0;
			this._txtCase_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtCase_4.Multiline = false;
			this._txtCase_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtCase_4.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtCase_4.TabStop = true;
			this._txtCase_4.Visible = true;
			this._txtCase_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtCase_4.Name = "_txtCase_4";
			this._txtUnit_3.AutoSize = false;
			this._txtUnit_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtUnit_3.Enabled = false;
			this._txtUnit_3.Size = new System.Drawing.Size(46, 19);
			this._txtUnit_3.Location = new System.Drawing.Point(213, 39);
			this._txtUnit_3.TabIndex = 8;
			this._txtUnit_3.Text = "0.00";
			this._txtUnit_3.AcceptsReturn = true;
			this._txtUnit_3.BackColor = System.Drawing.SystemColors.Window;
			this._txtUnit_3.CausesValidation = true;
			this._txtUnit_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtUnit_3.HideSelection = true;
			this._txtUnit_3.ReadOnly = false;
			this._txtUnit_3.MaxLength = 0;
			this._txtUnit_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtUnit_3.Multiline = false;
			this._txtUnit_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtUnit_3.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtUnit_3.TabStop = true;
			this._txtUnit_3.Visible = true;
			this._txtUnit_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtUnit_3.Name = "_txtUnit_3";
			this._txtCase_3.AutoSize = false;
			this._txtCase_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCase_3.Enabled = false;
			this._txtCase_3.Size = new System.Drawing.Size(46, 19);
			this._txtCase_3.Location = new System.Drawing.Point(213, 57);
			this._txtCase_3.TabIndex = 7;
			this._txtCase_3.Text = "0.00";
			this._txtCase_3.AcceptsReturn = true;
			this._txtCase_3.BackColor = System.Drawing.SystemColors.Window;
			this._txtCase_3.CausesValidation = true;
			this._txtCase_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtCase_3.HideSelection = true;
			this._txtCase_3.ReadOnly = false;
			this._txtCase_3.MaxLength = 0;
			this._txtCase_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtCase_3.Multiline = false;
			this._txtCase_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtCase_3.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtCase_3.TabStop = true;
			this._txtCase_3.Visible = true;
			this._txtCase_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtCase_3.Name = "_txtCase_3";
			this._txtUnit_2.AutoSize = false;
			this._txtUnit_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtUnit_2.Enabled = false;
			this._txtUnit_2.Size = new System.Drawing.Size(46, 19);
			this._txtUnit_2.Location = new System.Drawing.Point(165, 39);
			this._txtUnit_2.TabIndex = 6;
			this._txtUnit_2.Text = "0.00";
			this._txtUnit_2.AcceptsReturn = true;
			this._txtUnit_2.BackColor = System.Drawing.SystemColors.Window;
			this._txtUnit_2.CausesValidation = true;
			this._txtUnit_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtUnit_2.HideSelection = true;
			this._txtUnit_2.ReadOnly = false;
			this._txtUnit_2.MaxLength = 0;
			this._txtUnit_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtUnit_2.Multiline = false;
			this._txtUnit_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtUnit_2.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtUnit_2.TabStop = true;
			this._txtUnit_2.Visible = true;
			this._txtUnit_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtUnit_2.Name = "_txtUnit_2";
			this._txtCase_2.AutoSize = false;
			this._txtCase_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCase_2.Enabled = false;
			this._txtCase_2.Size = new System.Drawing.Size(46, 19);
			this._txtCase_2.Location = new System.Drawing.Point(165, 57);
			this._txtCase_2.TabIndex = 5;
			this._txtCase_2.Text = "0.00";
			this._txtCase_2.AcceptsReturn = true;
			this._txtCase_2.BackColor = System.Drawing.SystemColors.Window;
			this._txtCase_2.CausesValidation = true;
			this._txtCase_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtCase_2.HideSelection = true;
			this._txtCase_2.ReadOnly = false;
			this._txtCase_2.MaxLength = 0;
			this._txtCase_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtCase_2.Multiline = false;
			this._txtCase_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtCase_2.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtCase_2.TabStop = true;
			this._txtCase_2.Visible = true;
			this._txtCase_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtCase_2.Name = "_txtCase_2";
			this._txtCase_1.AutoSize = false;
			this._txtCase_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtCase_1.Enabled = false;
			this._txtCase_1.Size = new System.Drawing.Size(46, 19);
			this._txtCase_1.Location = new System.Drawing.Point(117, 57);
			this._txtCase_1.TabIndex = 4;
			this._txtCase_1.Text = "0.00";
			this._txtCase_1.AcceptsReturn = true;
			this._txtCase_1.BackColor = System.Drawing.SystemColors.Window;
			this._txtCase_1.CausesValidation = true;
			this._txtCase_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtCase_1.HideSelection = true;
			this._txtCase_1.ReadOnly = false;
			this._txtCase_1.MaxLength = 0;
			this._txtCase_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtCase_1.Multiline = false;
			this._txtCase_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtCase_1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtCase_1.TabStop = true;
			this._txtCase_1.Visible = true;
			this._txtCase_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtCase_1.Name = "_txtCase_1";
			this._txtUnit_1.AutoSize = false;
			this._txtUnit_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtUnit_1.Enabled = false;
			this._txtUnit_1.Size = new System.Drawing.Size(46, 19);
			this._txtUnit_1.Location = new System.Drawing.Point(117, 39);
			this._txtUnit_1.TabIndex = 3;
			this._txtUnit_1.Text = "0.00";
			this._txtUnit_1.AcceptsReturn = true;
			this._txtUnit_1.BackColor = System.Drawing.SystemColors.Window;
			this._txtUnit_1.CausesValidation = true;
			this._txtUnit_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtUnit_1.HideSelection = true;
			this._txtUnit_1.ReadOnly = false;
			this._txtUnit_1.MaxLength = 0;
			this._txtUnit_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtUnit_1.Multiline = false;
			this._txtUnit_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtUnit_1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtUnit_1.TabStop = true;
			this._txtUnit_1.Visible = true;
			this._txtUnit_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtUnit_1.Name = "_txtUnit_1";
			this._lblPricingGroup_8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lblPricingGroup_8.BackColor = System.Drawing.Color.Transparent;
			this._lblPricingGroup_8.Text = "CG8";
			this._lblPricingGroup_8.Size = new System.Drawing.Size(46, 13);
			this._lblPricingGroup_8.Location = new System.Drawing.Point(451, 24);
			this._lblPricingGroup_8.TabIndex = 29;
			this._lblPricingGroup_8.Enabled = true;
			this._lblPricingGroup_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblPricingGroup_8.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblPricingGroup_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblPricingGroup_8.UseMnemonic = true;
			this._lblPricingGroup_8.Visible = true;
			this._lblPricingGroup_8.AutoSize = false;
			this._lblPricingGroup_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblPricingGroup_8.Name = "_lblPricingGroup_8";
			this._lblPricingGroup_7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lblPricingGroup_7.BackColor = System.Drawing.Color.Transparent;
			this._lblPricingGroup_7.Text = "CG7";
			this._lblPricingGroup_7.Size = new System.Drawing.Size(46, 13);
			this._lblPricingGroup_7.Location = new System.Drawing.Point(405, 24);
			this._lblPricingGroup_7.TabIndex = 28;
			this._lblPricingGroup_7.Enabled = true;
			this._lblPricingGroup_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblPricingGroup_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblPricingGroup_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblPricingGroup_7.UseMnemonic = true;
			this._lblPricingGroup_7.Visible = true;
			this._lblPricingGroup_7.AutoSize = false;
			this._lblPricingGroup_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblPricingGroup_7.Name = "_lblPricingGroup_7";
			this._lblPricingGroup_6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lblPricingGroup_6.BackColor = System.Drawing.Color.Transparent;
			this._lblPricingGroup_6.Text = "CG6";
			this._lblPricingGroup_6.Size = new System.Drawing.Size(46, 13);
			this._lblPricingGroup_6.Location = new System.Drawing.Point(356, 24);
			this._lblPricingGroup_6.TabIndex = 27;
			this._lblPricingGroup_6.Enabled = true;
			this._lblPricingGroup_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblPricingGroup_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblPricingGroup_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblPricingGroup_6.UseMnemonic = true;
			this._lblPricingGroup_6.Visible = true;
			this._lblPricingGroup_6.AutoSize = false;
			this._lblPricingGroup_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblPricingGroup_6.Name = "_lblPricingGroup_6";
			this._lblPricingGroup_5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lblPricingGroup_5.BackColor = System.Drawing.Color.Transparent;
			this._lblPricingGroup_5.Text = "CG5";
			this._lblPricingGroup_5.Size = new System.Drawing.Size(46, 13);
			this._lblPricingGroup_5.Location = new System.Drawing.Point(309, 24);
			this._lblPricingGroup_5.TabIndex = 26;
			this._lblPricingGroup_5.Enabled = true;
			this._lblPricingGroup_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblPricingGroup_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblPricingGroup_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblPricingGroup_5.UseMnemonic = true;
			this._lblPricingGroup_5.Visible = true;
			this._lblPricingGroup_5.AutoSize = false;
			this._lblPricingGroup_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblPricingGroup_5.Name = "_lblPricingGroup_5";
			this._lblPricingGroup_4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lblPricingGroup_4.BackColor = System.Drawing.Color.Transparent;
			this._lblPricingGroup_4.Text = "CG4";
			this._lblPricingGroup_4.Size = new System.Drawing.Size(46, 13);
			this._lblPricingGroup_4.Location = new System.Drawing.Point(261, 24);
			this._lblPricingGroup_4.TabIndex = 25;
			this._lblPricingGroup_4.Enabled = true;
			this._lblPricingGroup_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblPricingGroup_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblPricingGroup_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblPricingGroup_4.UseMnemonic = true;
			this._lblPricingGroup_4.Visible = true;
			this._lblPricingGroup_4.AutoSize = false;
			this._lblPricingGroup_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblPricingGroup_4.Name = "_lblPricingGroup_4";
			this._lblPricingGroup_3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lblPricingGroup_3.BackColor = System.Drawing.Color.Transparent;
			this._lblPricingGroup_3.Text = "CG3";
			this._lblPricingGroup_3.Size = new System.Drawing.Size(46, 13);
			this._lblPricingGroup_3.Location = new System.Drawing.Point(213, 24);
			this._lblPricingGroup_3.TabIndex = 24;
			this._lblPricingGroup_3.Enabled = true;
			this._lblPricingGroup_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblPricingGroup_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblPricingGroup_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblPricingGroup_3.UseMnemonic = true;
			this._lblPricingGroup_3.Visible = true;
			this._lblPricingGroup_3.AutoSize = false;
			this._lblPricingGroup_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblPricingGroup_3.Name = "_lblPricingGroup_3";
			this._lblPricingGroup_2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lblPricingGroup_2.BackColor = System.Drawing.Color.Transparent;
			this._lblPricingGroup_2.Text = "CG2";
			this._lblPricingGroup_2.Size = new System.Drawing.Size(46, 13);
			this._lblPricingGroup_2.Location = new System.Drawing.Point(165, 24);
			this._lblPricingGroup_2.TabIndex = 23;
			this._lblPricingGroup_2.Enabled = true;
			this._lblPricingGroup_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblPricingGroup_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblPricingGroup_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblPricingGroup_2.UseMnemonic = true;
			this._lblPricingGroup_2.Visible = true;
			this._lblPricingGroup_2.AutoSize = false;
			this._lblPricingGroup_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblPricingGroup_2.Name = "_lblPricingGroup_2";
			this._lblPricingGroup_1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lblPricingGroup_1.BackColor = System.Drawing.Color.Transparent;
			this._lblPricingGroup_1.Text = "CG1";
			this._lblPricingGroup_1.Size = new System.Drawing.Size(46, 13);
			this._lblPricingGroup_1.Location = new System.Drawing.Point(120, 24);
			this._lblPricingGroup_1.TabIndex = 22;
			this._lblPricingGroup_1.Enabled = true;
			this._lblPricingGroup_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblPricingGroup_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblPricingGroup_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblPricingGroup_1.UseMnemonic = true;
			this._lblPricingGroup_1.Visible = true;
			this._lblPricingGroup_1.AutoSize = false;
			this._lblPricingGroup_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblPricingGroup_1.Name = "_lblPricingGroup_1";
			this._lbl_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_5.Text = "Case/Carton Markup :";
			this._lbl_5.Size = new System.Drawing.Size(105, 13);
			this._lbl_5.Location = new System.Drawing.Point(7, 60);
			this._lbl_5.TabIndex = 21;
			this._lbl_5.BackColor = System.Drawing.SystemColors.Control;
			this._lbl_5.Enabled = true;
			this._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_5.UseMnemonic = true;
			this._lbl_5.Visible = true;
			this._lbl_5.AutoSize = true;
			this._lbl_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_5.Name = "_lbl_5";
			this._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_2.Text = "Unit Markup :";
			this._lbl_2.Size = new System.Drawing.Size(64, 13);
			this._lbl_2.Location = new System.Drawing.Point(48, 42);
			this._lbl_2.TabIndex = 20;
			this._lbl_2.BackColor = System.Drawing.SystemColors.Control;
			this._lbl_2.Enabled = true;
			this._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_2.UseMnemonic = true;
			this._lbl_2.Visible = true;
			this._lbl_2.AutoSize = true;
			this._lbl_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_2.Name = "_lbl_2";
			this.lblHeading.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
			this.lblHeading.Text = "Default Pricing Matrix for each Channel.";
			this.lblHeading.ForeColor = System.Drawing.Color.White;
			this.lblHeading.Size = new System.Drawing.Size(526, 15);
			this.lblHeading.Location = new System.Drawing.Point(3, 0);
			this.lblHeading.TabIndex = 19;
			this.lblHeading.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblHeading.Enabled = true;
			this.lblHeading.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblHeading.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblHeading.UseMnemonic = true;
			this.lblHeading.Visible = true;
			this.lblHeading.AutoSize = false;
			this.lblHeading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblHeading.Name = "lblHeading";
			this.txtEdit.AutoSize = false;
			this.txtEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this.txtEdit.Size = new System.Drawing.Size(55, 16);
			this.txtEdit.Location = new System.Drawing.Point(186, 321);
			this.txtEdit.TabIndex = 1;
			this.txtEdit.Tag = "0.00";
			this.txtEdit.Text = "0.00";
			this.txtEdit.AcceptsReturn = true;
			this.txtEdit.CausesValidation = true;
			this.txtEdit.Enabled = true;
			this.txtEdit.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtEdit.HideSelection = true;
			this.txtEdit.ReadOnly = false;
			this.txtEdit.MaxLength = 0;
			this.txtEdit.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtEdit.Multiline = false;
			this.txtEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtEdit.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtEdit.TabStop = true;
			this.txtEdit.Visible = true;
			this.txtEdit.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtEdit.Name = "txtEdit";
			//gridItem.OcxState = CType(resources.GetObject("gridItem.OcxState"), System.Windows.Forms.AxHost.State)
			this.gridItem.Size = new System.Drawing.Size(529, 354);
			this.gridItem.Location = new System.Drawing.Point(3, 144);
			this.gridItem.TabIndex = 0;
			this.gridItem.Name = "gridItem";
			this.lblColorChanged.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
			this.lblColorChanged.Text = "Label1";
			this.lblColorChanged.Size = new System.Drawing.Size(82, 34);
			this.lblColorChanged.Location = new System.Drawing.Point(561, 246);
			this.lblColorChanged.TabIndex = 34;
			this.lblColorChanged.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblColorChanged.Enabled = true;
			this.lblColorChanged.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblColorChanged.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblColorChanged.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblColorChanged.UseMnemonic = true;
			this.lblColorChanged.Visible = true;
			this.lblColorChanged.AutoSize = false;
			this.lblColorChanged.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblColorChanged.Name = "lblColorChanged";
			this._lblColorFixed_1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblColorFixed_1.Text = "Label1";
			this._lblColorFixed_1.Size = new System.Drawing.Size(67, 13);
			this._lblColorFixed_1.Location = new System.Drawing.Point(546, 156);
			this._lblColorFixed_1.TabIndex = 33;
			this._lblColorFixed_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblColorFixed_1.Enabled = true;
			this._lblColorFixed_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblColorFixed_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblColorFixed_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblColorFixed_1.UseMnemonic = true;
			this._lblColorFixed_1.Visible = true;
			this._lblColorFixed_1.AutoSize = false;
			this._lblColorFixed_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblColorFixed_1.Name = "_lblColorFixed_1";
			this._lblColorFixed_0.BackColor = System.Drawing.Color.FromArgb(192, 192, 192);
			this._lblColorFixed_0.Text = "Label1";
			this._lblColorFixed_0.Size = new System.Drawing.Size(67, 13);
			this._lblColorFixed_0.Location = new System.Drawing.Point(552, 138);
			this._lblColorFixed_0.TabIndex = 32;
			this._lblColorFixed_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblColorFixed_0.Enabled = true;
			this._lblColorFixed_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblColorFixed_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblColorFixed_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblColorFixed_0.UseMnemonic = true;
			this._lblColorFixed_0.Visible = true;
			this._lblColorFixed_0.AutoSize = false;
			this._lblColorFixed_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblColorFixed_0.Name = "_lblColorFixed_0";
			this._lblcolor_1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblcolor_1.Text = "Label1";
			this._lblcolor_1.Size = new System.Drawing.Size(70, 19);
			this._lblcolor_1.Location = new System.Drawing.Point(570, 204);
			this._lblcolor_1.TabIndex = 31;
			this._lblcolor_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblcolor_1.Enabled = true;
			this._lblcolor_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblcolor_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblcolor_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblcolor_1.UseMnemonic = true;
			this._lblcolor_1.Visible = true;
			this._lblcolor_1.AutoSize = false;
			this._lblcolor_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblcolor_1.Name = "_lblcolor_1";
			this._lblcolor_0.BackColor = System.Drawing.Color.FromArgb(192, 192, 192);
			this._lblcolor_0.Text = "Label1";
			this._lblcolor_0.Size = new System.Drawing.Size(70, 19);
			this._lblcolor_0.Location = new System.Drawing.Point(570, 186);
			this._lblcolor_0.TabIndex = 30;
			this._lblcolor_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblcolor_0.Enabled = true;
			this._lblcolor_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblcolor_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblcolor_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblcolor_0.UseMnemonic = true;
			this._lblcolor_0.Visible = true;
			this._lblcolor_0.AutoSize = false;
			this._lblcolor_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblcolor_0.Name = "_lblcolor_0";
			this.Controls.Add(picButtons);
			this.Controls.Add(_frmDetails_0);
			this.Controls.Add(txtEdit);
			this.Controls.Add(gridItem);
			this.Controls.Add(lblColorChanged);
			this.Controls.Add(_lblColorFixed_1);
			this.Controls.Add(_lblColorFixed_0);
			this.Controls.Add(_lblcolor_1);
			this.Controls.Add(_lblcolor_0);
			this.picButtons.Controls.Add(cmdPrint);
			this.picButtons.Controls.Add(Command1);
			this.picButtons.Controls.Add(cmdExit);
			this._frmDetails_0.Controls.Add(_txtUnit_7);
			this._frmDetails_0.Controls.Add(_txtCase_7);
			this._frmDetails_0.Controls.Add(_txtUnit_8);
			this._frmDetails_0.Controls.Add(_txtCase_8);
			this._frmDetails_0.Controls.Add(_txtUnit_6);
			this._frmDetails_0.Controls.Add(_txtCase_6);
			this._frmDetails_0.Controls.Add(_txtUnit_5);
			this._frmDetails_0.Controls.Add(_txtCase_5);
			this._frmDetails_0.Controls.Add(_txtUnit_4);
			this._frmDetails_0.Controls.Add(_txtCase_4);
			this._frmDetails_0.Controls.Add(_txtUnit_3);
			this._frmDetails_0.Controls.Add(_txtCase_3);
			this._frmDetails_0.Controls.Add(_txtUnit_2);
			this._frmDetails_0.Controls.Add(_txtCase_2);
			this._frmDetails_0.Controls.Add(_txtCase_1);
			this._frmDetails_0.Controls.Add(_txtUnit_1);
			this._frmDetails_0.Controls.Add(_lblPricingGroup_8);
			this._frmDetails_0.Controls.Add(_lblPricingGroup_7);
			this._frmDetails_0.Controls.Add(_lblPricingGroup_6);
			this._frmDetails_0.Controls.Add(_lblPricingGroup_5);
			this._frmDetails_0.Controls.Add(_lblPricingGroup_4);
			this._frmDetails_0.Controls.Add(_lblPricingGroup_3);
			this._frmDetails_0.Controls.Add(_lblPricingGroup_2);
			this._frmDetails_0.Controls.Add(_lblPricingGroup_1);
			this._frmDetails_0.Controls.Add(_lbl_5);
			this._frmDetails_0.Controls.Add(_lbl_2);
			this._frmDetails_0.Controls.Add(lblHeading);
			//Me.frmDetails.SetIndex(_frmDetails_0, CType(0, Short))
			//Me.lbl.SetIndex(_lbl_5, CType(5, Short))
			//Me.lbl.SetIndex(_lbl_2, CType(2, Short))
			//Me.lblColorFixed.SetIndex(_lblColorFixed_1, CType(1, Short))
			//Me.lblColorFixed.SetIndex(_lblColorFixed_0, CType(0, Short))
			//Me.lblPricingGroup.SetIndex(_lblPricingGroup_8, CType(8, Short))
			//Me.lblPricingGroup.SetIndex(_lblPricingGroup_7, CType(7, Short))
			//Me.lblPricingGroup.SetIndex(_lblPricingGroup_6, CType(6, Short))
			//Me.lblPricingGroup.SetIndex(_lblPricingGroup_5, CType(5, Short))
			//Me.lblPricingGroup.SetIndex(_lblPricingGroup_4, CType(4, Short))
			//Me.lblPricingGroup.SetIndex(_lblPricingGroup_3, CType(3, Short))
			//Me.lblPricingGroup.SetIndex(_lblPricingGroup_2, CType(2, Short))
			//Me.lblPricingGroup.SetIndex(_lblPricingGroup_1, CType(1, Short))
			//Me.lblcolor.SetIndex(_lblcolor_1, CType(1, Short))
			//Me.lblcolor.SetIndex(_lblcolor_0, CType(0, Short))
			//Me.txtCase.SetIndex(_txtCase_7, CType(7, Short))
			//Me.txtCase.SetIndex(_txtCase_8, CType(8, Short))
			//Me.txtCase.SetIndex(_txtCase_6, CType(6, Short))
			//Me.txtCase.SetIndex(_txtCase_5, CType(5, Short))
			//Me.txtCase.SetIndex(_txtCase_4, CType(4, Short))
			//Me.txtCase.SetIndex(_txtCase_3, CType(3, Short))
			//Me.txtCase.SetIndex(_txtCase_2, CType(2, Short))
			//Me.txtCase.SetIndex(_txtCase_1, CType(1, Short))
			//Me.txtUnit.SetIndex(_txtUnit_7, CType(7, Short))
			//Me.txtUnit.SetIndex(_txtUnit_8, CType(8, Short))
			//Me.txtUnit.SetIndex(_txtUnit_6, CType(6, Short))
			//Me.txtUnit.SetIndex(_txtUnit_5, CType(5, Short))
			//Me.txtUnit.SetIndex(_txtUnit_4, CType(4, Short))
			//Me.txtUnit.SetIndex(_txtUnit_3, CType(3, Short))
			//Me.txtUnit.SetIndex(_txtUnit_2, CType(2, Short))
			//Me.txtUnit.SetIndex(_txtUnit_1, CType(1, Short))
			//CType(Me.txtUnit, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.txtCase, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblcolor, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblPricingGroup, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblColorFixed, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.frmDetails, System.ComponentModel.ISupportInitialize).EndInit()
			((System.ComponentModel.ISupportInitialize)this.gridItem).EndInit();
			this.picButtons.ResumeLayout(false);
			this._frmDetails_0.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
