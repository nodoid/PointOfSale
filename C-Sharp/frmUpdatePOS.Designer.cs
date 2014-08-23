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
	partial class frmUpdatePOS
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmUpdatePOS() : base()
		{
			KeyPress += frmUpdatePOS_KeyPress;
			Load += frmUpdatePOS_Load;
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
		private System.Windows.Forms.Timer withEventsField_tmrMEndUpdatePOS;
		public System.Windows.Forms.Timer tmrMEndUpdatePOS {
			get { return withEventsField_tmrMEndUpdatePOS; }
			set {
				if (withEventsField_tmrMEndUpdatePOS != null) {
					withEventsField_tmrMEndUpdatePOS.Tick -= tmrMEndUpdatePOS_Tick;
				}
				withEventsField_tmrMEndUpdatePOS = value;
				if (withEventsField_tmrMEndUpdatePOS != null) {
					withEventsField_tmrMEndUpdatePOS.Tick += tmrMEndUpdatePOS_Tick;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdScale;
		public System.Windows.Forms.Button cmdScale {
			get { return withEventsField_cmdScale; }
			set {
				if (withEventsField_cmdScale != null) {
					withEventsField_cmdScale.Click -= cmdScale_Click;
				}
				withEventsField_cmdScale = value;
				if (withEventsField_cmdScale != null) {
					withEventsField_cmdScale.Click += cmdScale_Click;
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
		private System.Windows.Forms.Button withEventsField_cmdUpdate;
		public System.Windows.Forms.Button cmdUpdate {
			get { return withEventsField_cmdUpdate; }
			set {
				if (withEventsField_cmdUpdate != null) {
					withEventsField_cmdUpdate.Click -= cmdUpdate_Click;
				}
				withEventsField_cmdUpdate = value;
				if (withEventsField_cmdUpdate != null) {
					withEventsField_cmdUpdate.Click += cmdUpdate_Click;
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
		private System.Windows.Forms.Button withEventsField_cmdPrintNew;
		public System.Windows.Forms.Button cmdPrintNew {
			get { return withEventsField_cmdPrintNew; }
			set {
				if (withEventsField_cmdPrintNew != null) {
					withEventsField_cmdPrintNew.Click -= cmdPrintNew_Click;
				}
				withEventsField_cmdPrintNew = value;
				if (withEventsField_cmdPrintNew != null) {
					withEventsField_cmdPrintNew.Click += cmdPrintNew_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdPrintAmend;
		public System.Windows.Forms.Button cmdPrintAmend {
			get { return withEventsField_cmdPrintAmend; }
			set {
				if (withEventsField_cmdPrintAmend != null) {
					withEventsField_cmdPrintAmend.Click -= cmdPrintAmend_Click;
				}
				withEventsField_cmdPrintAmend = value;
				if (withEventsField_cmdPrintAmend != null) {
					withEventsField_cmdPrintAmend.Click += cmdPrintAmend_Click;
				}
			}
		}
		public System.Windows.Forms.Panel picButtons;
		public System.Windows.Forms.TextBox _txtNew_8;
		public System.Windows.Forms.TextBox _txtAmend_8;
		public System.Windows.Forms.TextBox _txtNew_7;
		public System.Windows.Forms.TextBox _txtAmend_7;
		public System.Windows.Forms.TextBox _txtNew_6;
		public System.Windows.Forms.TextBox _txtAmend_6;
		public System.Windows.Forms.TextBox _txtNew_5;
		public System.Windows.Forms.TextBox _txtAmend_5;
		public System.Windows.Forms.TextBox _txtNew_4;
		public System.Windows.Forms.TextBox _txtAmend_4;
		public System.Windows.Forms.TextBox _txtNew_3;
		public System.Windows.Forms.TextBox _txtAmend_3;
		public System.Windows.Forms.TextBox _txtNew_2;
		public System.Windows.Forms.TextBox _txtAmend_2;
		public System.Windows.Forms.TextBox _txtNew_1;
		public System.Windows.Forms.TextBox _txtAmend_1;
		public System.Windows.Forms.Label lblInstructionNew;
		public System.Windows.Forms.Label _lbl_2;
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.Label lblInstruction;
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.Label _lblCG_7;
		public System.Windows.Forms.Label _lblCG_6;
		public System.Windows.Forms.Label _lblCG_5;
		public System.Windows.Forms.Label _lblCG_4;
		public System.Windows.Forms.Label _lblCG_3;
		public System.Windows.Forms.Label _lblCG_2;
		public System.Windows.Forms.Label _lblCG_1;
		public System.Windows.Forms.Label _lblCG_0;
		public System.Windows.Forms.Label _lblLabels_33;
		public System.Windows.Forms.Label _lblLabels_34;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_1;
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblCG As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents txtAmend As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		//Public WithEvents txtNew As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
		public RectangleShapeArray Shape1;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmUpdatePOS));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.tmrMEndUpdatePOS = new System.Windows.Forms.Timer(components);
			this.cmdScale = new System.Windows.Forms.Button();
			this.picButtons = new System.Windows.Forms.Panel();
			this.Command1 = new System.Windows.Forms.Button();
			this.cmdUpdate = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this.cmdPrintNew = new System.Windows.Forms.Button();
			this.cmdPrintAmend = new System.Windows.Forms.Button();
			this._txtNew_8 = new System.Windows.Forms.TextBox();
			this._txtAmend_8 = new System.Windows.Forms.TextBox();
			this._txtNew_7 = new System.Windows.Forms.TextBox();
			this._txtAmend_7 = new System.Windows.Forms.TextBox();
			this._txtNew_6 = new System.Windows.Forms.TextBox();
			this._txtAmend_6 = new System.Windows.Forms.TextBox();
			this._txtNew_5 = new System.Windows.Forms.TextBox();
			this._txtAmend_5 = new System.Windows.Forms.TextBox();
			this._txtNew_4 = new System.Windows.Forms.TextBox();
			this._txtAmend_4 = new System.Windows.Forms.TextBox();
			this._txtNew_3 = new System.Windows.Forms.TextBox();
			this._txtAmend_3 = new System.Windows.Forms.TextBox();
			this._txtNew_2 = new System.Windows.Forms.TextBox();
			this._txtAmend_2 = new System.Windows.Forms.TextBox();
			this._txtNew_1 = new System.Windows.Forms.TextBox();
			this._txtAmend_1 = new System.Windows.Forms.TextBox();
			this.lblInstructionNew = new System.Windows.Forms.Label();
			this._lbl_2 = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this.lblInstruction = new System.Windows.Forms.Label();
			this._lbl_1 = new System.Windows.Forms.Label();
			this._lblCG_7 = new System.Windows.Forms.Label();
			this._lblCG_6 = new System.Windows.Forms.Label();
			this._lblCG_5 = new System.Windows.Forms.Label();
			this._lblCG_4 = new System.Windows.Forms.Label();
			this._lblCG_3 = new System.Windows.Forms.Label();
			this._lblCG_2 = new System.Windows.Forms.Label();
			this._lblCG_1 = new System.Windows.Forms.Label();
			this._lblCG_0 = new System.Windows.Forms.Label();
			this._lblLabels_33 = new System.Windows.Forms.Label();
			this._lblLabels_34 = new System.Windows.Forms.Label();
			this._Shape1_1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblCG = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.txtAmend = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			//Me.txtNew = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			this.Shape1 = new RectangleShapeArray(components);
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblCG, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtAmend, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtNew, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.Text = "Update Point Of Sale";
			this.ClientSize = new System.Drawing.Size(490, 229);
			this.Location = new System.Drawing.Point(4, 23);
			this.ControlBox = false;
			this.KeyPreview = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Enabled = true;
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmUpdatePOS";
			this.tmrMEndUpdatePOS.Enabled = false;
			this.tmrMEndUpdatePOS.Interval = 10;
			this.cmdScale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdScale.Text = "Force &Scale Update";
			this.cmdScale.Size = new System.Drawing.Size(127, 34);
			this.cmdScale.Location = new System.Drawing.Point(12, 186);
			this.cmdScale.TabIndex = 36;
			this.cmdScale.BackColor = System.Drawing.SystemColors.Control;
			this.cmdScale.CausesValidation = true;
			this.cmdScale.Enabled = true;
			this.cmdScale.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdScale.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdScale.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdScale.TabStop = true;
			this.cmdScale.Name = "cmdScale";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(490, 39);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 27;
			this.picButtons.TabStop = false;
			this.picButtons.CausesValidation = true;
			this.picButtons.Enabled = true;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Visible = true;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Name = "picButtons";
			this.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Command1.Text = "Print &Barcodes";
			this.Command1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Command1.Size = new System.Drawing.Size(105, 29);
			this.Command1.Location = new System.Drawing.Point(168, 3);
			this.Command1.TabIndex = 37;
			this.Command1.TabStop = false;
			this.Command1.BackColor = System.Drawing.SystemColors.Control;
			this.Command1.CausesValidation = true;
			this.Command1.Enabled = true;
			this.Command1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command1.Name = "Command1";
			this.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdUpdate.Text = "&Update POS";
			this.cmdUpdate.Size = new System.Drawing.Size(73, 29);
			this.cmdUpdate.Location = new System.Drawing.Point(328, 3);
			this.cmdUpdate.TabIndex = 35;
			this.cmdUpdate.TabStop = false;
			this.cmdUpdate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdUpdate.CausesValidation = true;
			this.cmdUpdate.Enabled = true;
			this.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdUpdate.Name = "cmdUpdate";
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.Size = new System.Drawing.Size(73, 29);
			this.cmdClose.Location = new System.Drawing.Point(408, 3);
			this.cmdClose.TabIndex = 30;
			this.cmdClose.TabStop = false;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Name = "cmdClose";
			this.cmdPrintNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPrintNew.Text = "Print &New";
			this.cmdPrintNew.Size = new System.Drawing.Size(73, 29);
			this.cmdPrintNew.Location = new System.Drawing.Point(5, 3);
			this.cmdPrintNew.TabIndex = 29;
			this.cmdPrintNew.TabStop = false;
			this.cmdPrintNew.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrintNew.CausesValidation = true;
			this.cmdPrintNew.Enabled = true;
			this.cmdPrintNew.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrintNew.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrintNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrintNew.Name = "cmdPrintNew";
			this.cmdPrintAmend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPrintAmend.Text = "Print &Amend";
			this.cmdPrintAmend.Size = new System.Drawing.Size(73, 29);
			this.cmdPrintAmend.Location = new System.Drawing.Point(88, 3);
			this.cmdPrintAmend.TabIndex = 28;
			this.cmdPrintAmend.TabStop = false;
			this.cmdPrintAmend.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrintAmend.CausesValidation = true;
			this.cmdPrintAmend.Enabled = true;
			this.cmdPrintAmend.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrintAmend.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrintAmend.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrintAmend.Name = "cmdPrintAmend";
			this._txtNew_8.AutoSize = false;
			this._txtNew_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtNew_8.Enabled = false;
			this._txtNew_8.Size = new System.Drawing.Size(49, 19);
			this._txtNew_8.Location = new System.Drawing.Point(423, 105);
			this._txtNew_8.TabIndex = 15;
			this._txtNew_8.Text = "0";
			this._txtNew_8.AcceptsReturn = true;
			this._txtNew_8.BackColor = System.Drawing.SystemColors.Window;
			this._txtNew_8.CausesValidation = true;
			this._txtNew_8.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtNew_8.HideSelection = true;
			this._txtNew_8.ReadOnly = false;
			this._txtNew_8.MaxLength = 0;
			this._txtNew_8.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtNew_8.Multiline = false;
			this._txtNew_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtNew_8.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtNew_8.TabStop = true;
			this._txtNew_8.Visible = true;
			this._txtNew_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtNew_8.Name = "_txtNew_8";
			this._txtAmend_8.AutoSize = false;
			this._txtAmend_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtAmend_8.Enabled = false;
			this._txtAmend_8.Size = new System.Drawing.Size(49, 19);
			this._txtAmend_8.Location = new System.Drawing.Point(423, 87);
			this._txtAmend_8.TabIndex = 14;
			this._txtAmend_8.Text = "0";
			this._txtAmend_8.AcceptsReturn = true;
			this._txtAmend_8.BackColor = System.Drawing.SystemColors.Window;
			this._txtAmend_8.CausesValidation = true;
			this._txtAmend_8.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtAmend_8.HideSelection = true;
			this._txtAmend_8.ReadOnly = false;
			this._txtAmend_8.MaxLength = 0;
			this._txtAmend_8.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtAmend_8.Multiline = false;
			this._txtAmend_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtAmend_8.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtAmend_8.TabStop = true;
			this._txtAmend_8.Visible = true;
			this._txtAmend_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtAmend_8.Name = "_txtAmend_8";
			this._txtNew_7.AutoSize = false;
			this._txtNew_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtNew_7.Enabled = false;
			this._txtNew_7.Size = new System.Drawing.Size(49, 19);
			this._txtNew_7.Location = new System.Drawing.Point(372, 105);
			this._txtNew_7.TabIndex = 13;
			this._txtNew_7.Text = "0";
			this._txtNew_7.AcceptsReturn = true;
			this._txtNew_7.BackColor = System.Drawing.SystemColors.Window;
			this._txtNew_7.CausesValidation = true;
			this._txtNew_7.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtNew_7.HideSelection = true;
			this._txtNew_7.ReadOnly = false;
			this._txtNew_7.MaxLength = 0;
			this._txtNew_7.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtNew_7.Multiline = false;
			this._txtNew_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtNew_7.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtNew_7.TabStop = true;
			this._txtNew_7.Visible = true;
			this._txtNew_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtNew_7.Name = "_txtNew_7";
			this._txtAmend_7.AutoSize = false;
			this._txtAmend_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtAmend_7.Enabled = false;
			this._txtAmend_7.Size = new System.Drawing.Size(49, 19);
			this._txtAmend_7.Location = new System.Drawing.Point(372, 87);
			this._txtAmend_7.TabIndex = 12;
			this._txtAmend_7.Text = "0";
			this._txtAmend_7.AcceptsReturn = true;
			this._txtAmend_7.BackColor = System.Drawing.SystemColors.Window;
			this._txtAmend_7.CausesValidation = true;
			this._txtAmend_7.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtAmend_7.HideSelection = true;
			this._txtAmend_7.ReadOnly = false;
			this._txtAmend_7.MaxLength = 0;
			this._txtAmend_7.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtAmend_7.Multiline = false;
			this._txtAmend_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtAmend_7.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtAmend_7.TabStop = true;
			this._txtAmend_7.Visible = true;
			this._txtAmend_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtAmend_7.Name = "_txtAmend_7";
			this._txtNew_6.AutoSize = false;
			this._txtNew_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtNew_6.Enabled = false;
			this._txtNew_6.Size = new System.Drawing.Size(49, 19);
			this._txtNew_6.Location = new System.Drawing.Point(321, 105);
			this._txtNew_6.TabIndex = 11;
			this._txtNew_6.Text = "0";
			this._txtNew_6.AcceptsReturn = true;
			this._txtNew_6.BackColor = System.Drawing.SystemColors.Window;
			this._txtNew_6.CausesValidation = true;
			this._txtNew_6.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtNew_6.HideSelection = true;
			this._txtNew_6.ReadOnly = false;
			this._txtNew_6.MaxLength = 0;
			this._txtNew_6.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtNew_6.Multiline = false;
			this._txtNew_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtNew_6.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtNew_6.TabStop = true;
			this._txtNew_6.Visible = true;
			this._txtNew_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtNew_6.Name = "_txtNew_6";
			this._txtAmend_6.AutoSize = false;
			this._txtAmend_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtAmend_6.Enabled = false;
			this._txtAmend_6.Size = new System.Drawing.Size(49, 19);
			this._txtAmend_6.Location = new System.Drawing.Point(321, 87);
			this._txtAmend_6.TabIndex = 10;
			this._txtAmend_6.Text = "0";
			this._txtAmend_6.AcceptsReturn = true;
			this._txtAmend_6.BackColor = System.Drawing.SystemColors.Window;
			this._txtAmend_6.CausesValidation = true;
			this._txtAmend_6.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtAmend_6.HideSelection = true;
			this._txtAmend_6.ReadOnly = false;
			this._txtAmend_6.MaxLength = 0;
			this._txtAmend_6.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtAmend_6.Multiline = false;
			this._txtAmend_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtAmend_6.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtAmend_6.TabStop = true;
			this._txtAmend_6.Visible = true;
			this._txtAmend_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtAmend_6.Name = "_txtAmend_6";
			this._txtNew_5.AutoSize = false;
			this._txtNew_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtNew_5.Enabled = false;
			this._txtNew_5.Size = new System.Drawing.Size(49, 19);
			this._txtNew_5.Location = new System.Drawing.Point(270, 105);
			this._txtNew_5.TabIndex = 9;
			this._txtNew_5.Text = "0";
			this._txtNew_5.AcceptsReturn = true;
			this._txtNew_5.BackColor = System.Drawing.SystemColors.Window;
			this._txtNew_5.CausesValidation = true;
			this._txtNew_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtNew_5.HideSelection = true;
			this._txtNew_5.ReadOnly = false;
			this._txtNew_5.MaxLength = 0;
			this._txtNew_5.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtNew_5.Multiline = false;
			this._txtNew_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtNew_5.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtNew_5.TabStop = true;
			this._txtNew_5.Visible = true;
			this._txtNew_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtNew_5.Name = "_txtNew_5";
			this._txtAmend_5.AutoSize = false;
			this._txtAmend_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtAmend_5.Enabled = false;
			this._txtAmend_5.Size = new System.Drawing.Size(49, 19);
			this._txtAmend_5.Location = new System.Drawing.Point(270, 87);
			this._txtAmend_5.TabIndex = 8;
			this._txtAmend_5.Text = "0";
			this._txtAmend_5.AcceptsReturn = true;
			this._txtAmend_5.BackColor = System.Drawing.SystemColors.Window;
			this._txtAmend_5.CausesValidation = true;
			this._txtAmend_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtAmend_5.HideSelection = true;
			this._txtAmend_5.ReadOnly = false;
			this._txtAmend_5.MaxLength = 0;
			this._txtAmend_5.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtAmend_5.Multiline = false;
			this._txtAmend_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtAmend_5.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtAmend_5.TabStop = true;
			this._txtAmend_5.Visible = true;
			this._txtAmend_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtAmend_5.Name = "_txtAmend_5";
			this._txtNew_4.AutoSize = false;
			this._txtNew_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtNew_4.Enabled = false;
			this._txtNew_4.Size = new System.Drawing.Size(49, 19);
			this._txtNew_4.Location = new System.Drawing.Point(219, 105);
			this._txtNew_4.TabIndex = 7;
			this._txtNew_4.Text = "0";
			this._txtNew_4.AcceptsReturn = true;
			this._txtNew_4.BackColor = System.Drawing.SystemColors.Window;
			this._txtNew_4.CausesValidation = true;
			this._txtNew_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtNew_4.HideSelection = true;
			this._txtNew_4.ReadOnly = false;
			this._txtNew_4.MaxLength = 0;
			this._txtNew_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtNew_4.Multiline = false;
			this._txtNew_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtNew_4.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtNew_4.TabStop = true;
			this._txtNew_4.Visible = true;
			this._txtNew_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtNew_4.Name = "_txtNew_4";
			this._txtAmend_4.AutoSize = false;
			this._txtAmend_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtAmend_4.Enabled = false;
			this._txtAmend_4.Size = new System.Drawing.Size(49, 19);
			this._txtAmend_4.Location = new System.Drawing.Point(219, 87);
			this._txtAmend_4.TabIndex = 6;
			this._txtAmend_4.Text = "0";
			this._txtAmend_4.AcceptsReturn = true;
			this._txtAmend_4.BackColor = System.Drawing.SystemColors.Window;
			this._txtAmend_4.CausesValidation = true;
			this._txtAmend_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtAmend_4.HideSelection = true;
			this._txtAmend_4.ReadOnly = false;
			this._txtAmend_4.MaxLength = 0;
			this._txtAmend_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtAmend_4.Multiline = false;
			this._txtAmend_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtAmend_4.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtAmend_4.TabStop = true;
			this._txtAmend_4.Visible = true;
			this._txtAmend_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtAmend_4.Name = "_txtAmend_4";
			this._txtNew_3.AutoSize = false;
			this._txtNew_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtNew_3.Enabled = false;
			this._txtNew_3.Size = new System.Drawing.Size(49, 19);
			this._txtNew_3.Location = new System.Drawing.Point(168, 105);
			this._txtNew_3.TabIndex = 5;
			this._txtNew_3.Text = "0";
			this._txtNew_3.AcceptsReturn = true;
			this._txtNew_3.BackColor = System.Drawing.SystemColors.Window;
			this._txtNew_3.CausesValidation = true;
			this._txtNew_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtNew_3.HideSelection = true;
			this._txtNew_3.ReadOnly = false;
			this._txtNew_3.MaxLength = 0;
			this._txtNew_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtNew_3.Multiline = false;
			this._txtNew_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtNew_3.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtNew_3.TabStop = true;
			this._txtNew_3.Visible = true;
			this._txtNew_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtNew_3.Name = "_txtNew_3";
			this._txtAmend_3.AutoSize = false;
			this._txtAmend_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtAmend_3.Enabled = false;
			this._txtAmend_3.Size = new System.Drawing.Size(49, 19);
			this._txtAmend_3.Location = new System.Drawing.Point(168, 87);
			this._txtAmend_3.TabIndex = 4;
			this._txtAmend_3.Text = "0";
			this._txtAmend_3.AcceptsReturn = true;
			this._txtAmend_3.BackColor = System.Drawing.SystemColors.Window;
			this._txtAmend_3.CausesValidation = true;
			this._txtAmend_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtAmend_3.HideSelection = true;
			this._txtAmend_3.ReadOnly = false;
			this._txtAmend_3.MaxLength = 0;
			this._txtAmend_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtAmend_3.Multiline = false;
			this._txtAmend_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtAmend_3.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtAmend_3.TabStop = true;
			this._txtAmend_3.Visible = true;
			this._txtAmend_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtAmend_3.Name = "_txtAmend_3";
			this._txtNew_2.AutoSize = false;
			this._txtNew_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtNew_2.Enabled = false;
			this._txtNew_2.Size = new System.Drawing.Size(49, 19);
			this._txtNew_2.Location = new System.Drawing.Point(117, 105);
			this._txtNew_2.TabIndex = 3;
			this._txtNew_2.Text = "0";
			this._txtNew_2.AcceptsReturn = true;
			this._txtNew_2.BackColor = System.Drawing.SystemColors.Window;
			this._txtNew_2.CausesValidation = true;
			this._txtNew_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtNew_2.HideSelection = true;
			this._txtNew_2.ReadOnly = false;
			this._txtNew_2.MaxLength = 0;
			this._txtNew_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtNew_2.Multiline = false;
			this._txtNew_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtNew_2.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtNew_2.TabStop = true;
			this._txtNew_2.Visible = true;
			this._txtNew_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtNew_2.Name = "_txtNew_2";
			this._txtAmend_2.AutoSize = false;
			this._txtAmend_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtAmend_2.Enabled = false;
			this._txtAmend_2.Size = new System.Drawing.Size(49, 19);
			this._txtAmend_2.Location = new System.Drawing.Point(117, 87);
			this._txtAmend_2.TabIndex = 2;
			this._txtAmend_2.Text = "0";
			this._txtAmend_2.AcceptsReturn = true;
			this._txtAmend_2.BackColor = System.Drawing.SystemColors.Window;
			this._txtAmend_2.CausesValidation = true;
			this._txtAmend_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtAmend_2.HideSelection = true;
			this._txtAmend_2.ReadOnly = false;
			this._txtAmend_2.MaxLength = 0;
			this._txtAmend_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtAmend_2.Multiline = false;
			this._txtAmend_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtAmend_2.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtAmend_2.TabStop = true;
			this._txtAmend_2.Visible = true;
			this._txtAmend_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtAmend_2.Name = "_txtAmend_2";
			this._txtNew_1.AutoSize = false;
			this._txtNew_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtNew_1.Enabled = false;
			this._txtNew_1.Size = new System.Drawing.Size(49, 19);
			this._txtNew_1.Location = new System.Drawing.Point(66, 105);
			this._txtNew_1.TabIndex = 1;
			this._txtNew_1.Text = "0";
			this._txtNew_1.AcceptsReturn = true;
			this._txtNew_1.BackColor = System.Drawing.SystemColors.Window;
			this._txtNew_1.CausesValidation = true;
			this._txtNew_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtNew_1.HideSelection = true;
			this._txtNew_1.ReadOnly = false;
			this._txtNew_1.MaxLength = 0;
			this._txtNew_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtNew_1.Multiline = false;
			this._txtNew_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtNew_1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtNew_1.TabStop = true;
			this._txtNew_1.Visible = true;
			this._txtNew_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtNew_1.Name = "_txtNew_1";
			this._txtAmend_1.AutoSize = false;
			this._txtAmend_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._txtAmend_1.Enabled = false;
			this._txtAmend_1.Size = new System.Drawing.Size(49, 19);
			this._txtAmend_1.Location = new System.Drawing.Point(66, 87);
			this._txtAmend_1.TabIndex = 0;
			this._txtAmend_1.Text = "0";
			this._txtAmend_1.AcceptsReturn = true;
			this._txtAmend_1.BackColor = System.Drawing.SystemColors.Window;
			this._txtAmend_1.CausesValidation = true;
			this._txtAmend_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtAmend_1.HideSelection = true;
			this._txtAmend_1.ReadOnly = false;
			this._txtAmend_1.MaxLength = 0;
			this._txtAmend_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtAmend_1.Multiline = false;
			this._txtAmend_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtAmend_1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtAmend_1.TabStop = true;
			this._txtAmend_1.Visible = true;
			this._txtAmend_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtAmend_1.Name = "_txtAmend_1";
			this.lblInstructionNew.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblInstructionNew.Text = "9999";
			this.lblInstructionNew.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblInstructionNew.Size = new System.Drawing.Size(31, 13);
			this.lblInstructionNew.Location = new System.Drawing.Point(450, 165);
			this.lblInstructionNew.TabIndex = 34;
			this.lblInstructionNew.BackColor = System.Drawing.Color.Transparent;
			this.lblInstructionNew.Enabled = true;
			this.lblInstructionNew.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblInstructionNew.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblInstructionNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblInstructionNew.UseMnemonic = true;
			this.lblInstructionNew.Visible = true;
			this.lblInstructionNew.AutoSize = false;
			this.lblInstructionNew.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblInstructionNew.Name = "lblInstructionNew";
			this._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_2.Text = "After this update the new POS instruction number will be";
			this._lbl_2.Size = new System.Drawing.Size(265, 13);
			this._lbl_2.Location = new System.Drawing.Point(183, 165);
			this._lbl_2.TabIndex = 33;
			this._lbl_2.BackColor = System.Drawing.Color.Transparent;
			this._lbl_2.Enabled = true;
			this._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_2.UseMnemonic = true;
			this._lbl_2.Visible = true;
			this._lbl_2.AutoSize = true;
			this._lbl_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_2.Name = "_lbl_2";
			this._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_0.Text = "The current POS update instruction number is ";
			this._lbl_0.Size = new System.Drawing.Size(220, 13);
			this._lbl_0.Location = new System.Drawing.Point(228, 147);
			this._lbl_0.TabIndex = 32;
			this._lbl_0.BackColor = System.Drawing.Color.Transparent;
			this._lbl_0.Enabled = true;
			this._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_0.UseMnemonic = true;
			this._lbl_0.Visible = true;
			this._lbl_0.AutoSize = true;
			this._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_0.Name = "_lbl_0";
			this.lblInstruction.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblInstruction.Text = "9999";
			this.lblInstruction.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lblInstruction.Size = new System.Drawing.Size(31, 13);
			this.lblInstruction.Location = new System.Drawing.Point(450, 147);
			this.lblInstruction.TabIndex = 31;
			this.lblInstruction.BackColor = System.Drawing.Color.Transparent;
			this.lblInstruction.Enabled = true;
			this.lblInstruction.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblInstruction.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblInstruction.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblInstruction.UseMnemonic = true;
			this.lblInstruction.Visible = true;
			this.lblInstruction.AutoSize = false;
			this.lblInstruction.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblInstruction.Name = "lblInstruction";
			this._lbl_1.BackColor = System.Drawing.Color.Transparent;
			this._lbl_1.Text = "Number of Stock Items that will be effected by the update.";
			this._lbl_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_1.Size = new System.Drawing.Size(333, 13);
			this._lbl_1.Location = new System.Drawing.Point(9, 54);
			this._lbl_1.TabIndex = 26;
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
			this._lblCG_7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lblCG_7.Text = "PricingGroup_Case6:";
			this._lblCG_7.Size = new System.Drawing.Size(49, 13);
			this._lblCG_7.Location = new System.Drawing.Point(423, 75);
			this._lblCG_7.TabIndex = 25;
			this._lblCG_7.BackColor = System.Drawing.Color.Transparent;
			this._lblCG_7.Enabled = true;
			this._lblCG_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblCG_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblCG_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblCG_7.UseMnemonic = true;
			this._lblCG_7.Visible = true;
			this._lblCG_7.AutoSize = false;
			this._lblCG_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblCG_7.Name = "_lblCG_7";
			this._lblCG_6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lblCG_6.Text = "PricingGroup_Unit6:";
			this._lblCG_6.Size = new System.Drawing.Size(49, 13);
			this._lblCG_6.Location = new System.Drawing.Point(372, 75);
			this._lblCG_6.TabIndex = 24;
			this._lblCG_6.BackColor = System.Drawing.Color.Transparent;
			this._lblCG_6.Enabled = true;
			this._lblCG_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblCG_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblCG_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblCG_6.UseMnemonic = true;
			this._lblCG_6.Visible = true;
			this._lblCG_6.AutoSize = false;
			this._lblCG_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblCG_6.Name = "_lblCG_6";
			this._lblCG_5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lblCG_5.Text = "PricingGroup_Case5:";
			this._lblCG_5.Size = new System.Drawing.Size(49, 13);
			this._lblCG_5.Location = new System.Drawing.Point(321, 75);
			this._lblCG_5.TabIndex = 23;
			this._lblCG_5.BackColor = System.Drawing.Color.Transparent;
			this._lblCG_5.Enabled = true;
			this._lblCG_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblCG_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblCG_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblCG_5.UseMnemonic = true;
			this._lblCG_5.Visible = true;
			this._lblCG_5.AutoSize = false;
			this._lblCG_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblCG_5.Name = "_lblCG_5";
			this._lblCG_4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lblCG_4.Text = "PricingGroup_Unit5:";
			this._lblCG_4.Size = new System.Drawing.Size(49, 13);
			this._lblCG_4.Location = new System.Drawing.Point(270, 75);
			this._lblCG_4.TabIndex = 22;
			this._lblCG_4.BackColor = System.Drawing.Color.Transparent;
			this._lblCG_4.Enabled = true;
			this._lblCG_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblCG_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblCG_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblCG_4.UseMnemonic = true;
			this._lblCG_4.Visible = true;
			this._lblCG_4.AutoSize = false;
			this._lblCG_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblCG_4.Name = "_lblCG_4";
			this._lblCG_3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lblCG_3.Text = "PricingGroup_Case4:";
			this._lblCG_3.Size = new System.Drawing.Size(49, 13);
			this._lblCG_3.Location = new System.Drawing.Point(219, 75);
			this._lblCG_3.TabIndex = 21;
			this._lblCG_3.BackColor = System.Drawing.Color.Transparent;
			this._lblCG_3.Enabled = true;
			this._lblCG_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblCG_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblCG_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblCG_3.UseMnemonic = true;
			this._lblCG_3.Visible = true;
			this._lblCG_3.AutoSize = false;
			this._lblCG_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblCG_3.Name = "_lblCG_3";
			this._lblCG_2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lblCG_2.Text = "PricingGroup_Unit4:";
			this._lblCG_2.Size = new System.Drawing.Size(49, 13);
			this._lblCG_2.Location = new System.Drawing.Point(168, 75);
			this._lblCG_2.TabIndex = 20;
			this._lblCG_2.BackColor = System.Drawing.Color.Transparent;
			this._lblCG_2.Enabled = true;
			this._lblCG_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblCG_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblCG_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblCG_2.UseMnemonic = true;
			this._lblCG_2.Visible = true;
			this._lblCG_2.AutoSize = false;
			this._lblCG_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblCG_2.Name = "_lblCG_2";
			this._lblCG_1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lblCG_1.Text = "PricingGroup_Case3:";
			this._lblCG_1.Size = new System.Drawing.Size(49, 13);
			this._lblCG_1.Location = new System.Drawing.Point(117, 75);
			this._lblCG_1.TabIndex = 19;
			this._lblCG_1.BackColor = System.Drawing.Color.Transparent;
			this._lblCG_1.Enabled = true;
			this._lblCG_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblCG_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblCG_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblCG_1.UseMnemonic = true;
			this._lblCG_1.Visible = true;
			this._lblCG_1.AutoSize = false;
			this._lblCG_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblCG_1.Name = "_lblCG_1";
			this._lblCG_0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._lblCG_0.Text = "PricingGroup_Unit3:";
			this._lblCG_0.Size = new System.Drawing.Size(49, 13);
			this._lblCG_0.Location = new System.Drawing.Point(66, 75);
			this._lblCG_0.TabIndex = 18;
			this._lblCG_0.BackColor = System.Drawing.Color.Transparent;
			this._lblCG_0.Enabled = true;
			this._lblCG_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblCG_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblCG_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblCG_0.UseMnemonic = true;
			this._lblCG_0.Visible = true;
			this._lblCG_0.AutoSize = false;
			this._lblCG_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblCG_0.Name = "_lblCG_0";
			this._lblLabels_33.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_33.Text = "New :";
			this._lblLabels_33.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblLabels_33.Size = new System.Drawing.Size(34, 13);
			this._lblLabels_33.Location = new System.Drawing.Point(27, 107);
			this._lblLabels_33.TabIndex = 17;
			this._lblLabels_33.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_33.Enabled = true;
			this._lblLabels_33.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_33.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_33.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_33.UseMnemonic = true;
			this._lblLabels_33.Visible = true;
			this._lblLabels_33.AutoSize = true;
			this._lblLabels_33.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_33.Name = "_lblLabels_33";
			this._lblLabels_34.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_34.Text = "Amend :";
			this._lblLabels_34.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblLabels_34.Size = new System.Drawing.Size(47, 13);
			this._lblLabels_34.Location = new System.Drawing.Point(14, 88);
			this._lblLabels_34.TabIndex = 16;
			this._lblLabels_34.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_34.Enabled = true;
			this._lblLabels_34.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_34.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_34.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_34.UseMnemonic = true;
			this._lblLabels_34.Visible = true;
			this._lblLabels_34.AutoSize = true;
			this._lblLabels_34.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_34.Name = "_lblLabels_34";
			this._Shape1_1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_1.Size = new System.Drawing.Size(472, 67);
			this._Shape1_1.Location = new System.Drawing.Point(9, 69);
			this._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_1.BorderWidth = 1;
			this._Shape1_1.FillColor = System.Drawing.Color.Black;
			this._Shape1_1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_1.Visible = true;
			this._Shape1_1.Name = "_Shape1_1";
			this.Controls.Add(cmdScale);
			this.Controls.Add(picButtons);
			this.Controls.Add(_txtNew_8);
			this.Controls.Add(_txtAmend_8);
			this.Controls.Add(_txtNew_7);
			this.Controls.Add(_txtAmend_7);
			this.Controls.Add(_txtNew_6);
			this.Controls.Add(_txtAmend_6);
			this.Controls.Add(_txtNew_5);
			this.Controls.Add(_txtAmend_5);
			this.Controls.Add(_txtNew_4);
			this.Controls.Add(_txtAmend_4);
			this.Controls.Add(_txtNew_3);
			this.Controls.Add(_txtAmend_3);
			this.Controls.Add(_txtNew_2);
			this.Controls.Add(_txtAmend_2);
			this.Controls.Add(_txtNew_1);
			this.Controls.Add(_txtAmend_1);
			this.Controls.Add(lblInstructionNew);
			this.Controls.Add(_lbl_2);
			this.Controls.Add(_lbl_0);
			this.Controls.Add(lblInstruction);
			this.Controls.Add(_lbl_1);
			this.Controls.Add(_lblCG_7);
			this.Controls.Add(_lblCG_6);
			this.Controls.Add(_lblCG_5);
			this.Controls.Add(_lblCG_4);
			this.Controls.Add(_lblCG_3);
			this.Controls.Add(_lblCG_2);
			this.Controls.Add(_lblCG_1);
			this.Controls.Add(_lblCG_0);
			this.Controls.Add(_lblLabels_33);
			this.Controls.Add(_lblLabels_34);
			this.ShapeContainer1.Shapes.Add(_Shape1_1);
			this.Controls.Add(ShapeContainer1);
			this.picButtons.Controls.Add(Command1);
			this.picButtons.Controls.Add(cmdUpdate);
			this.picButtons.Controls.Add(cmdClose);
			this.picButtons.Controls.Add(cmdPrintNew);
			this.picButtons.Controls.Add(cmdPrintAmend);
			//Me.lbl.SetIndex(_lbl_2, CType(2, Short))
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//Me.lbl.SetIndex(_lbl_1, CType(1, Short))
			//Me.lblCG.SetIndex(_lblCG_7, CType(7, Short))
			//Me.lblCG.SetIndex(_lblCG_6, CType(6, Short))
			//Me.lblCG.SetIndex(_lblCG_5, CType(5, Short))
			//Me.lblCG.SetIndex(_lblCG_4, CType(4, Short))
			//Me.lblCG.SetIndex(_lblCG_3, CType(3, Short))
			//Me.lblCG.SetIndex(_lblCG_2, CType(2, Short))
			//Me.lblCG.SetIndex(_lblCG_1, CType(1, Short))
			//Me.lblCG.SetIndex(_lblCG_0, CType(0, Short))
			//Me.lblLabels.SetIndex(_lblLabels_33, CType(33, Short))
			//Me.lblLabels.SetIndex(_lblLabels_34, CType(34, Short))
			//Me.txtAmend.SetIndex(_txtAmend_8, CType(8, Short))
			//Me.txtAmend.SetIndex(_txtAmend_7, CType(7, Short))
			//Me.txtAmend.SetIndex(_txtAmend_6, CType(6, Short))
			//Me.txtAmend.SetIndex(_txtAmend_5, CType(5, Short))
			//Me.txtAmend.SetIndex(_txtAmend_4, CType(4, Short))
			//Me.txtAmend.SetIndex(_txtAmend_3, CType(3, Short))
			//Me.txtAmend.SetIndex(_txtAmend_2, CType(2, Short))
			//Me.txtAmend.SetIndex(_txtAmend_1, CType(1, Short))
			//Me.txtNew.SetIndex(_txtNew_8, CType(8, Short))
			//Me.txtNew.SetIndex(_txtNew_7, CType(7, Short))
			//Me.txtNew.SetIndex(_txtNew_6, CType(6, Short))
			//Me.txtNew.SetIndex(_txtNew_5, CType(5, Short))
			//Me.txtNew.SetIndex(_txtNew_4, CType(4, Short))
			//Me.txtNew.SetIndex(_txtNew_3, CType(3, Short))
			//Me.txtNew.SetIndex(_txtNew_2, CType(2, Short))
			//Me.txtNew.SetIndex(_txtNew_1, CType(1, Short))
			this.Shape1.SetIndex(_Shape1_1, Convert.ToInt16(1));
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			//CType(Me.txtNew, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.txtAmend, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblCG, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
