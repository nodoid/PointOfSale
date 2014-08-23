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
	partial class frmOrderSummary
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmOrderSummary() : base()
		{
			FormClosed += frmOrderSummary_FormClosed;
			Load += frmOrderSummary_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdNext;
		public System.Windows.Forms.Button cmdNext {
			get { return withEventsField_cmdNext; }
			set {
				if (withEventsField_cmdNext != null) {
					withEventsField_cmdNext.Click -= cmdNext_Click;
				}
				withEventsField_cmdNext = value;
				if (withEventsField_cmdNext != null) {
					withEventsField_cmdNext.Click += cmdNext_Click;
				}
			}
		}
		public System.Windows.Forms.TextBox _txtFields_1;
		public System.Windows.Forms.TextBox _txtFields_0;
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
		private System.Windows.Forms.Button withEventsField_cmdBack;
		public System.Windows.Forms.Button cmdBack {
			get { return withEventsField_cmdBack; }
			set {
				if (withEventsField_cmdBack != null) {
					withEventsField_cmdBack.Click -= cmdBack_Click;
				}
				withEventsField_cmdBack = value;
				if (withEventsField_cmdBack != null) {
					withEventsField_cmdBack.Click += cmdBack_Click;
				}
			}
		}
		public System.Windows.Forms.Panel picButtons;
		public System.Windows.Forms.Label _lbl_8;
		public System.Windows.Forms.Label _lbl_7;
		public System.Windows.Forms.Label _lbl_6;
		public System.Windows.Forms.Label _lbl_5;
		public System.Windows.Forms.Label lblTotal;
		public System.Windows.Forms.Label lblContentTotal;
		public System.Windows.Forms.Label lblDepositTotal;
		public System.Windows.Forms.Label _lbl_4;
		public System.Windows.Forms.Label _lbl_3;
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.Label _lblData_4;
		public System.Windows.Forms.Label _lblData_3;
		public System.Windows.Forms.Label _lblData_2;
		public System.Windows.Forms.Label _lblData_1;
		public System.Windows.Forms.Label _lblData_0;
		public System.Windows.Forms.Label _lblLabels_9;
		public System.Windows.Forms.Label _lblLabels_8;
		public System.Windows.Forms.Label _lblLabels_7;
		public System.Windows.Forms.Label _lblLabels_6;
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.Label _lbl_2;
		public System.Windows.Forms.Label _lblLabels_38;
		public System.Windows.Forms.Label _lblLabels_37;
		public System.Windows.Forms.Label _lblLabels_36;
		public System.Windows.Forms.Label _lblData_5;
		public System.Windows.Forms.Label _lblData_6;
		public System.Windows.Forms.Label _lblData_7;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_2;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_1;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_0;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_3;
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblData As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmOrderSummary));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.cmdNext = new System.Windows.Forms.Button();
			this._txtFields_1 = new System.Windows.Forms.TextBox();
			this._txtFields_0 = new System.Windows.Forms.TextBox();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdBack = new System.Windows.Forms.Button();
			this._lbl_8 = new System.Windows.Forms.Label();
			this._lbl_7 = new System.Windows.Forms.Label();
			this._lbl_6 = new System.Windows.Forms.Label();
			this._lbl_5 = new System.Windows.Forms.Label();
			this.lblTotal = new System.Windows.Forms.Label();
			this.lblContentTotal = new System.Windows.Forms.Label();
			this.lblDepositTotal = new System.Windows.Forms.Label();
			this._lbl_4 = new System.Windows.Forms.Label();
			this._lbl_3 = new System.Windows.Forms.Label();
			this._lbl_0 = new System.Windows.Forms.Label();
			this._lblData_4 = new System.Windows.Forms.Label();
			this._lblData_3 = new System.Windows.Forms.Label();
			this._lblData_2 = new System.Windows.Forms.Label();
			this._lblData_1 = new System.Windows.Forms.Label();
			this._lblData_0 = new System.Windows.Forms.Label();
			this._lblLabels_9 = new System.Windows.Forms.Label();
			this._lblLabels_8 = new System.Windows.Forms.Label();
			this._lblLabels_7 = new System.Windows.Forms.Label();
			this._lblLabels_6 = new System.Windows.Forms.Label();
			this._lbl_1 = new System.Windows.Forms.Label();
			this._lbl_2 = new System.Windows.Forms.Label();
			this._lblLabels_38 = new System.Windows.Forms.Label();
			this._lblLabels_37 = new System.Windows.Forms.Label();
			this._lblLabels_36 = new System.Windows.Forms.Label();
			this._lblData_5 = new System.Windows.Forms.Label();
			this._lblData_6 = new System.Windows.Forms.Label();
			this._lblData_7 = new System.Windows.Forms.Label();
			this._Shape1_2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Shape1_1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Shape1_0 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Shape1_3 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblData = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.txtFields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
			this.Shape1 = new RectangleShapeArray(components);
			this.picButtons.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblData, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.txtFields, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Complete Order";
			this.ClientSize = new System.Drawing.Size(612, 336);
			this.Location = new System.Drawing.Point(3, 22);
			this.ControlBox = false;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Enabled = true;
			this.KeyPreview = false;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmOrderSummary";
			this.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNext.Text = "P&rocess";
			this.cmdNext.Size = new System.Drawing.Size(97, 31);
			this.cmdNext.Location = new System.Drawing.Point(504, 282);
			this.cmdNext.TabIndex = 29;
			this.cmdNext.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNext.CausesValidation = true;
			this.cmdNext.Enabled = true;
			this.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNext.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNext.TabStop = true;
			this.cmdNext.Name = "cmdNext";
			this._txtFields_1.AutoSize = false;
			this._txtFields_1.Size = new System.Drawing.Size(142, 79);
			this._txtFields_1.Location = new System.Drawing.Point(459, 192);
			this._txtFields_1.Multiline = true;
			this._txtFields_1.TabIndex = 28;
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
			this._txtFields_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtFields_1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtFields_1.TabStop = true;
			this._txtFields_1.Visible = true;
			this._txtFields_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtFields_1.Name = "_txtFields_1";
			this._txtFields_0.AutoSize = false;
			this._txtFields_0.Size = new System.Drawing.Size(142, 19);
			this._txtFields_0.Location = new System.Drawing.Point(459, 168);
			this._txtFields_0.TabIndex = 27;
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
			this.picButtons.Size = new System.Drawing.Size(612, 38);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 23;
			this.picButtons.TabStop = false;
			this.picButtons.CausesValidation = true;
			this.picButtons.Enabled = true;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Visible = true;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Name = "picButtons";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Size = new System.Drawing.Size(73, 28);
			this.cmdExit.Location = new System.Drawing.Point(531, 3);
			this.cmdExit.TabIndex = 25;
			this.cmdExit.TabStop = false;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Name = "cmdExit";
			this.cmdBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdBack.Text = "<< &Back";
			this.cmdBack.Size = new System.Drawing.Size(73, 28);
			this.cmdBack.Location = new System.Drawing.Point(453, 3);
			this.cmdBack.TabIndex = 24;
			this.cmdBack.TabStop = false;
			this.cmdBack.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBack.CausesValidation = true;
			this.cmdBack.Enabled = true;
			this.cmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBack.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBack.Name = "cmdBack";
			this._lbl_8.BackColor = System.Drawing.Color.Transparent;
			this._lbl_8.Text = "&4.Process this Order";
			this._lbl_8.Size = new System.Drawing.Size(116, 13);
			this._lbl_8.Location = new System.Drawing.Point(342, 147);
			this._lbl_8.TabIndex = 32;
			this._lbl_8.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_8.Enabled = true;
			this._lbl_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_8.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_8.UseMnemonic = true;
			this._lbl_8.Visible = true;
			this._lbl_8.AutoSize = true;
			this._lbl_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_8.Name = "_lbl_8";
			this._lbl_7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_7.Text = "Order Attention Line:";
			this._lbl_7.Size = new System.Drawing.Size(133, 13);
			this._lbl_7.Location = new System.Drawing.Point(318, 192);
			this._lbl_7.TabIndex = 31;
			this._lbl_7.BackColor = System.Drawing.Color.Transparent;
			this._lbl_7.Enabled = true;
			this._lbl_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_7.UseMnemonic = true;
			this._lbl_7.Visible = true;
			this._lbl_7.AutoSize = false;
			this._lbl_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_7.Name = "_lbl_7";
			this._lbl_6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_6.Text = "Order Reference:";
			this._lbl_6.Size = new System.Drawing.Size(133, 13);
			this._lbl_6.Location = new System.Drawing.Point(318, 171);
			this._lbl_6.TabIndex = 30;
			this._lbl_6.BackColor = System.Drawing.Color.Transparent;
			this._lbl_6.Enabled = true;
			this._lbl_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_6.UseMnemonic = true;
			this._lbl_6.Visible = true;
			this._lbl_6.AutoSize = false;
			this._lbl_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_6.Name = "_lbl_6";
			this._lbl_5.BackColor = System.Drawing.Color.Transparent;
			this._lbl_5.Text = "&3. Order Totals";
			this._lbl_5.Size = new System.Drawing.Size(86, 13);
			this._lbl_5.Location = new System.Drawing.Point(342, 42);
			this._lbl_5.TabIndex = 26;
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
			this.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblTotal.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.lblTotal.Text = "lblTotal";
			this.lblTotal.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lblTotal.Size = new System.Drawing.Size(142, 16);
			this.lblTotal.Location = new System.Drawing.Point(459, 99);
			this.lblTotal.TabIndex = 22;
			this.lblTotal.Enabled = true;
			this.lblTotal.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblTotal.UseMnemonic = true;
			this.lblTotal.Visible = true;
			this.lblTotal.AutoSize = false;
			this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTotal.Name = "lblTotal";
			this.lblContentTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblContentTotal.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.lblContentTotal.Text = "lblContentTotal";
			this.lblContentTotal.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lblContentTotal.Size = new System.Drawing.Size(142, 16);
			this.lblContentTotal.Location = new System.Drawing.Point(459, 63);
			this.lblContentTotal.TabIndex = 21;
			this.lblContentTotal.Enabled = true;
			this.lblContentTotal.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblContentTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblContentTotal.UseMnemonic = true;
			this.lblContentTotal.Visible = true;
			this.lblContentTotal.AutoSize = false;
			this.lblContentTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblContentTotal.Name = "lblContentTotal";
			this.lblDepositTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblDepositTotal.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this.lblDepositTotal.Text = "lblDepositTotal";
			this.lblDepositTotal.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lblDepositTotal.Size = new System.Drawing.Size(142, 16);
			this.lblDepositTotal.Location = new System.Drawing.Point(459, 81);
			this.lblDepositTotal.TabIndex = 20;
			this.lblDepositTotal.Enabled = true;
			this.lblDepositTotal.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDepositTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDepositTotal.UseMnemonic = true;
			this.lblDepositTotal.Visible = true;
			this.lblDepositTotal.AutoSize = false;
			this.lblDepositTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDepositTotal.Name = "lblDepositTotal";
			this._lbl_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_4.Text = "Deposit Total:";
			this._lbl_4.Size = new System.Drawing.Size(133, 13);
			this._lbl_4.Location = new System.Drawing.Point(318, 81);
			this._lbl_4.TabIndex = 19;
			this._lbl_4.BackColor = System.Drawing.Color.Transparent;
			this._lbl_4.Enabled = true;
			this._lbl_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_4.UseMnemonic = true;
			this._lbl_4.Visible = true;
			this._lbl_4.AutoSize = false;
			this._lbl_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_4.Name = "_lbl_4";
			this._lbl_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_3.Text = "Content Total:";
			this._lbl_3.Size = new System.Drawing.Size(133, 13);
			this._lbl_3.Location = new System.Drawing.Point(318, 63);
			this._lbl_3.TabIndex = 18;
			this._lbl_3.BackColor = System.Drawing.Color.Transparent;
			this._lbl_3.Enabled = true;
			this._lbl_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_3.UseMnemonic = true;
			this._lbl_3.Visible = true;
			this._lbl_3.AutoSize = false;
			this._lbl_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_3.Name = "_lbl_3";
			this._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_0.Text = "Order Exclusive Total:";
			this._lbl_0.Size = new System.Drawing.Size(133, 13);
			this._lbl_0.Location = new System.Drawing.Point(318, 99);
			this._lbl_0.TabIndex = 17;
			this._lbl_0.BackColor = System.Drawing.Color.Transparent;
			this._lbl_0.Enabled = true;
			this._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_0.UseMnemonic = true;
			this._lbl_0.Visible = true;
			this._lbl_0.AutoSize = false;
			this._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_0.Name = "_lbl_0";
			this._lblData_4.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblData_4.Text = "Supplier_PostalAddress";
			this._lblData_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblData_4.Size = new System.Drawing.Size(226, 58);
			this._lblData_4.Location = new System.Drawing.Point(102, 165);
			this._lblData_4.TabIndex = 16;
			this._lblData_4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblData_4.Enabled = true;
			this._lblData_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblData_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblData_4.UseMnemonic = true;
			this._lblData_4.Visible = true;
			this._lblData_4.AutoSize = false;
			this._lblData_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblData_4.Name = "_lblData_4";
			this._lblData_3.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblData_3.Text = "Supplier_PhysicalAddress";
			this._lblData_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblData_3.Size = new System.Drawing.Size(226, 58);
			this._lblData_3.Location = new System.Drawing.Point(102, 102);
			this._lblData_3.TabIndex = 15;
			this._lblData_3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblData_3.Enabled = true;
			this._lblData_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblData_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblData_3.UseMnemonic = true;
			this._lblData_3.Visible = true;
			this._lblData_3.AutoSize = false;
			this._lblData_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblData_3.Name = "_lblData_3";
			this._lblData_2.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblData_2.Text = "Supplier_Facimile";
			this._lblData_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblData_2.Size = new System.Drawing.Size(94, 16);
			this._lblData_2.Location = new System.Drawing.Point(234, 81);
			this._lblData_2.TabIndex = 14;
			this._lblData_2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblData_2.Enabled = true;
			this._lblData_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblData_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblData_2.UseMnemonic = true;
			this._lblData_2.Visible = true;
			this._lblData_2.AutoSize = false;
			this._lblData_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblData_2.Name = "_lblData_2";
			this._lblData_1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblData_1.Text = "Supplier_Telephone";
			this._lblData_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblData_1.Size = new System.Drawing.Size(94, 16);
			this._lblData_1.Location = new System.Drawing.Point(102, 81);
			this._lblData_1.TabIndex = 13;
			this._lblData_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblData_1.Enabled = true;
			this._lblData_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblData_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblData_1.UseMnemonic = true;
			this._lblData_1.Visible = true;
			this._lblData_1.AutoSize = false;
			this._lblData_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblData_1.Name = "_lblData_1";
			this._lblData_0.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblData_0.Text = "Supplier_Name";
			this._lblData_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblData_0.Size = new System.Drawing.Size(226, 16);
			this._lblData_0.Location = new System.Drawing.Point(102, 63);
			this._lblData_0.TabIndex = 12;
			this._lblData_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblData_0.Enabled = true;
			this._lblData_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblData_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblData_0.UseMnemonic = true;
			this._lblData_0.Visible = true;
			this._lblData_0.AutoSize = false;
			this._lblData_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblData_0.Name = "_lblData_0";
			this._lblLabels_9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_9.Text = "Fax:";
			this._lblLabels_9.Size = new System.Drawing.Size(22, 13);
			this._lblLabels_9.Location = new System.Drawing.Point(207, 81);
			this._lblLabels_9.TabIndex = 11;
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
			this._lblLabels_8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_8.Text = "Telephone:";
			this._lblLabels_8.Size = new System.Drawing.Size(55, 13);
			this._lblLabels_8.Location = new System.Drawing.Point(39, 81);
			this._lblLabels_8.TabIndex = 10;
			this._lblLabels_8.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_8.Enabled = true;
			this._lblLabels_8.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_8.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_8.UseMnemonic = true;
			this._lblLabels_8.Visible = true;
			this._lblLabels_8.AutoSize = true;
			this._lblLabels_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_8.Name = "_lblLabels_8";
			this._lblLabels_7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_7.Text = "Postal Address:";
			this._lblLabels_7.Size = new System.Drawing.Size(76, 13);
			this._lblLabels_7.Location = new System.Drawing.Point(21, 162);
			this._lblLabels_7.TabIndex = 9;
			this._lblLabels_7.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_7.Enabled = true;
			this._lblLabels_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_7.UseMnemonic = true;
			this._lblLabels_7.Visible = true;
			this._lblLabels_7.AutoSize = true;
			this._lblLabels_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_7.Name = "_lblLabels_7";
			this._lblLabels_6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_6.Text = "Physical Address:";
			this._lblLabels_6.Size = new System.Drawing.Size(94, 13);
			this._lblLabels_6.Location = new System.Drawing.Point(3, 102);
			this._lblLabels_6.TabIndex = 8;
			this._lblLabels_6.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_6.Enabled = true;
			this._lblLabels_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_6.UseMnemonic = true;
			this._lblLabels_6.Visible = true;
			this._lblLabels_6.AutoSize = true;
			this._lblLabels_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_6.Name = "_lblLabels_6";
			this._lbl_1.BackColor = System.Drawing.Color.Transparent;
			this._lbl_1.Text = "&1. General";
			this._lbl_1.Size = new System.Drawing.Size(61, 13);
			this._lbl_1.Location = new System.Drawing.Point(6, 42);
			this._lbl_1.TabIndex = 7;
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
			this._lbl_2.BackColor = System.Drawing.Color.Transparent;
			this._lbl_2.Text = "&2. Ordering Details";
			this._lbl_2.Size = new System.Drawing.Size(107, 13);
			this._lbl_2.Location = new System.Drawing.Point(6, 234);
			this._lbl_2.TabIndex = 6;
			this._lbl_2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_2.Enabled = true;
			this._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_2.UseMnemonic = true;
			this._lbl_2.Visible = true;
			this._lbl_2.AutoSize = true;
			this._lbl_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_2.Name = "_lbl_2";
			this._lblLabels_38.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_38.Text = "Representative Name:";
			this._lblLabels_38.Size = new System.Drawing.Size(106, 13);
			this._lblLabels_38.Location = new System.Drawing.Point(24, 257);
			this._lblLabels_38.TabIndex = 5;
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
			this._lblLabels_37.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_37.Text = "Representative Number:";
			this._lblLabels_37.Size = new System.Drawing.Size(115, 13);
			this._lblLabels_37.Location = new System.Drawing.Point(15, 275);
			this._lblLabels_37.TabIndex = 4;
			this._lblLabels_37.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_37.Enabled = true;
			this._lblLabels_37.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_37.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_37.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_37.UseMnemonic = true;
			this._lblLabels_37.Visible = true;
			this._lblLabels_37.AutoSize = true;
			this._lblLabels_37.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_37.Name = "_lblLabels_37";
			this._lblLabels_36.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_36.Text = "Account Number:";
			this._lblLabels_36.Size = new System.Drawing.Size(83, 13);
			this._lblLabels_36.Location = new System.Drawing.Point(47, 294);
			this._lblLabels_36.TabIndex = 3;
			this._lblLabels_36.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_36.Enabled = true;
			this._lblLabels_36.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_36.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_36.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_36.UseMnemonic = true;
			this._lblLabels_36.Visible = true;
			this._lblLabels_36.AutoSize = true;
			this._lblLabels_36.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_36.Name = "_lblLabels_36";
			this._lblData_5.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblData_5.Text = "Supplier_RepresentativeName";
			this._lblData_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblData_5.Size = new System.Drawing.Size(190, 16);
			this._lblData_5.Location = new System.Drawing.Point(138, 258);
			this._lblData_5.TabIndex = 2;
			this._lblData_5.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblData_5.Enabled = true;
			this._lblData_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblData_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblData_5.UseMnemonic = true;
			this._lblData_5.Visible = true;
			this._lblData_5.AutoSize = false;
			this._lblData_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblData_5.Name = "_lblData_5";
			this._lblData_6.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblData_6.Text = "Supplier_RepresentativeNumber";
			this._lblData_6.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblData_6.Size = new System.Drawing.Size(190, 16);
			this._lblData_6.Location = new System.Drawing.Point(138, 276);
			this._lblData_6.TabIndex = 1;
			this._lblData_6.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblData_6.Enabled = true;
			this._lblData_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblData_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblData_6.UseMnemonic = true;
			this._lblData_6.Visible = true;
			this._lblData_6.AutoSize = false;
			this._lblData_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblData_6.Name = "_lblData_6";
			this._lblData_7.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblData_7.Text = "Supplier_ShippingCode";
			this._lblData_7.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblData_7.Size = new System.Drawing.Size(190, 16);
			this._lblData_7.Location = new System.Drawing.Point(138, 294);
			this._lblData_7.TabIndex = 0;
			this._lblData_7.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblData_7.Enabled = true;
			this._lblData_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblData_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblData_7.UseMnemonic = true;
			this._lblData_7.Visible = true;
			this._lblData_7.AutoSize = false;
			this._lblData_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblData_7.Name = "_lblData_7";
			this._Shape1_2.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_2.Size = new System.Drawing.Size(328, 70);
			this._Shape1_2.Location = new System.Drawing.Point(6, 249);
			this._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_2.BorderWidth = 1;
			this._Shape1_2.FillColor = System.Drawing.Color.Black;
			this._Shape1_2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_2.Visible = true;
			this._Shape1_2.Name = "_Shape1_2";
			this._Shape1_1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_1.Size = new System.Drawing.Size(328, 172);
			this._Shape1_1.Location = new System.Drawing.Point(6, 57);
			this._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_1.BorderWidth = 1;
			this._Shape1_1.FillColor = System.Drawing.Color.Black;
			this._Shape1_1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_1.Visible = true;
			this._Shape1_1.Name = "_Shape1_1";
			this._Shape1_0.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_0.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_0.Size = new System.Drawing.Size(265, 64);
			this._Shape1_0.Location = new System.Drawing.Point(342, 57);
			this._Shape1_0.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_0.BorderWidth = 1;
			this._Shape1_0.FillColor = System.Drawing.Color.Black;
			this._Shape1_0.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_0.Visible = true;
			this._Shape1_0.Name = "_Shape1_0";
			this._Shape1_3.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
			this._Shape1_3.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_3.Size = new System.Drawing.Size(265, 157);
			this._Shape1_3.Location = new System.Drawing.Point(342, 162);
			this._Shape1_3.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_3.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_3.BorderWidth = 1;
			this._Shape1_3.FillColor = System.Drawing.Color.Black;
			this._Shape1_3.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_3.Visible = true;
			this._Shape1_3.Name = "_Shape1_3";
			this.Controls.Add(cmdNext);
			this.Controls.Add(_txtFields_1);
			this.Controls.Add(_txtFields_0);
			this.Controls.Add(picButtons);
			this.Controls.Add(_lbl_8);
			this.Controls.Add(_lbl_7);
			this.Controls.Add(_lbl_6);
			this.Controls.Add(_lbl_5);
			this.Controls.Add(lblTotal);
			this.Controls.Add(lblContentTotal);
			this.Controls.Add(lblDepositTotal);
			this.Controls.Add(_lbl_4);
			this.Controls.Add(_lbl_3);
			this.Controls.Add(_lbl_0);
			this.Controls.Add(_lblData_4);
			this.Controls.Add(_lblData_3);
			this.Controls.Add(_lblData_2);
			this.Controls.Add(_lblData_1);
			this.Controls.Add(_lblData_0);
			this.Controls.Add(_lblLabels_9);
			this.Controls.Add(_lblLabels_8);
			this.Controls.Add(_lblLabels_7);
			this.Controls.Add(_lblLabels_6);
			this.Controls.Add(_lbl_1);
			this.Controls.Add(_lbl_2);
			this.Controls.Add(_lblLabels_38);
			this.Controls.Add(_lblLabels_37);
			this.Controls.Add(_lblLabels_36);
			this.Controls.Add(_lblData_5);
			this.Controls.Add(_lblData_6);
			this.Controls.Add(_lblData_7);
			this.ShapeContainer1.Shapes.Add(_Shape1_2);
			this.ShapeContainer1.Shapes.Add(_Shape1_1);
			this.ShapeContainer1.Shapes.Add(_Shape1_0);
			this.ShapeContainer1.Shapes.Add(_Shape1_3);
			this.Controls.Add(ShapeContainer1);
			this.picButtons.Controls.Add(cmdExit);
			this.picButtons.Controls.Add(cmdBack);
			//Me.lbl.SetIndex(_lbl_8, CType(8, Short))
			//Me.lbl.SetIndex(_lbl_7, CType(7, Short))
			//Me.lbl.SetIndex(_lbl_6, CType(6, Short))
			//Me.lbl.SetIndex(_lbl_5, CType(5, Short))
			//Me.lbl.SetIndex(_lbl_4, CType(4, Short))
			//Me.lbl.SetIndex(_lbl_3, CType(3, Short))
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//Me.lbl.SetIndex(_lbl_1, CType(1, Short))
			//Me.lbl.SetIndex(_lbl_2, CType(2, Short))
			//Me.lblData.SetIndex(_lblData_4, CType(4, Short))
			//Me.lblData.SetIndex(_lblData_3, CType(3, Short))
			//Me.lblData.SetIndex(_lblData_2, CType(2, Short))
			//Me.lblData.SetIndex(_lblData_1, CType(1, Short))
			//Me.lblData.SetIndex(_lblData_0, CType(0, Short))
			//Me.lblData.SetIndex(_lblData_5, CType(5, Short))
			//Me.lblData.SetIndex(_lblData_6, CType(6, Short))
			//M() ''e.lblData.SetIndex(_lblData_7, CType(7, Short))
			//M() 'e.lblLabels.SetIndex(_lblLabels_9, CType(9, Short))
			//Me.lblLabels.SetIndex(_lblLabels_8, CType(8, Short))
			//Me.lblLabels.SetIndex(_lblLabels_7, CType(7, Short))
			//Me.lblLabels.SetIndex(_lblLabels_6, CType(6, Short))
			//Me.lblLabels.SetIndex(_lblLabels_38, CType(38, Short))
			//Me.lblLabels.SetIndex(_lblLabels_37, CType(37, Short))
			//Me.lblLabels.SetIndex(_lblLabels_36, CType(36, Short))
			//Me.txtFields.SetIndex(_txtFields_1, CType(1, Short))
			//'Me.txtFields.SetIndex(_txtFields_0, CType(0, Short))
			this.Shape1.SetIndex(_Shape1_2, Convert.ToInt16(2));
			this.Shape1.SetIndex(_Shape1_1, Convert.ToInt16(1));
			this.Shape1.SetIndex(_Shape1_0, Convert.ToInt16(0));
			this.Shape1.SetIndex(_Shape1_3, Convert.ToInt16(3));
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			//CType(Me.txtFields, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblData, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			this.picButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
