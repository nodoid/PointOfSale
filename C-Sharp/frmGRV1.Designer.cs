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
	partial class frmGRV
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmGRV() : base()
		{
			Load += frmGRV_Load;
			FormClosed += frmGRV_FormClosed;
			KeyPress += frmGRV_KeyPress;
			KeyDown += frmGRV_KeyDown;
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
		private System.Windows.Forms.Timer withEventsField_tmrAutoGRV;
		public System.Windows.Forms.Timer tmrAutoGRV {
			get { return withEventsField_tmrAutoGRV; }
			set {
				if (withEventsField_tmrAutoGRV != null) {
					withEventsField_tmrAutoGRV.Tick -= tmrAutoGRV_Tick;
				}
				withEventsField_tmrAutoGRV = value;
				if (withEventsField_tmrAutoGRV != null) {
					withEventsField_tmrAutoGRV.Tick += tmrAutoGRV_Tick;
				}
			}
		}
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
		private System.Windows.Forms.Button withEventsField_cmdNewGT;
		public System.Windows.Forms.Button cmdNewGT {
			get { return withEventsField_cmdNewGT; }
			set {
				if (withEventsField_cmdNewGT != null) {
					withEventsField_cmdNewGT.Click -= cmdNewGT_Click;
				}
				withEventsField_cmdNewGT = value;
				if (withEventsField_cmdNewGT != null) {
					withEventsField_cmdNewGT.Click += cmdNewGT_Click;
				}
			}
		}
		private System.Windows.Forms.MonthCalendar withEventsField_MonthView1;
		public System.Windows.Forms.MonthCalendar MonthView1 {
			get { return withEventsField_MonthView1; }
			set {
				if (withEventsField_MonthView1 != null) {
					withEventsField_MonthView1.Enter -= MonthView1_Enter;
					withEventsField_MonthView1.Leave -= MonthView1_Leave;
				}
				withEventsField_MonthView1 = value;
				if (withEventsField_MonthView1 != null) {
					withEventsField_MonthView1.Enter += MonthView1_Enter;
					withEventsField_MonthView1.Leave += MonthView1_Leave;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdLoad;
		public System.Windows.Forms.Button cmdLoad {
			get { return withEventsField_cmdLoad; }
			set {
				if (withEventsField_cmdLoad != null) {
					withEventsField_cmdLoad.Click -= cmdLoad_Click;
				}
				withEventsField_cmdLoad = value;
				if (withEventsField_cmdLoad != null) {
					withEventsField_cmdLoad.Click += cmdLoad_Click;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtInvoiceTotal;
		public System.Windows.Forms.TextBox txtInvoiceTotal {
			get { return withEventsField_txtInvoiceTotal; }
			set {
				if (withEventsField_txtInvoiceTotal != null) {
					withEventsField_txtInvoiceTotal.Enter -= txtInvoiceTotal_Enter;
					withEventsField_txtInvoiceTotal.KeyPress -= txtInvoiceTotal_KeyPress;
					withEventsField_txtInvoiceTotal.Leave -= txtInvoiceTotal_Leave;
				}
				withEventsField_txtInvoiceTotal = value;
				if (withEventsField_txtInvoiceTotal != null) {
					withEventsField_txtInvoiceTotal.Enter += txtInvoiceTotal_Enter;
					withEventsField_txtInvoiceTotal.KeyPress += txtInvoiceTotal_KeyPress;
					withEventsField_txtInvoiceTotal.Leave += txtInvoiceTotal_Leave;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtInvoiceNo;
		public System.Windows.Forms.TextBox txtInvoiceNo {
			get { return withEventsField_txtInvoiceNo; }
			set {
				if (withEventsField_txtInvoiceNo != null) {
					withEventsField_txtInvoiceNo.Enter -= txtInvoiceNo_Enter;
				}
				withEventsField_txtInvoiceNo = value;
				if (withEventsField_txtInvoiceNo != null) {
					withEventsField_txtInvoiceNo.Enter += txtInvoiceNo_Enter;
				}
			}
		}
		public myDataGridView cmbTemplate;
		public System.Windows.Forms.Label _lbl_4;
		public System.Windows.Forms.Label _lblLabels_0;
		public System.Windows.Forms.Label _lblData_3;
		public System.Windows.Forms.Label _lbl_5;
		public System.Windows.Forms.Label _lbl_6;
		public System.Windows.Forms.Label _lbl_7;
		public System.Windows.Forms.Label _lblData_7;
		public System.Windows.Forms.Label _lblLabels_36;
		public System.Windows.Forms.Label _lbl_2;
		public System.Windows.Forms.Label _lbl_1;
		public System.Windows.Forms.Label _lblLabels_2;
		public System.Windows.Forms.Label _lblLabels_8;
		public System.Windows.Forms.Label _lblLabels_9;
		public System.Windows.Forms.Label _lblData_0;
		public System.Windows.Forms.Label _lblData_1;
		public System.Windows.Forms.Label _lblData_2;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_1;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape _Shape1_2;
		public System.Windows.Forms.GroupBox _frmMode_1;
		//Public WithEvents frmMode As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblData As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		public OvalShapeArray Shape1;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmGRV));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.tmrAutoGRV = new System.Windows.Forms.Timer(components);
			this.cmdNext = new System.Windows.Forms.Button();
			this.cmdBack = new System.Windows.Forms.Button();
			this._frmMode_1 = new System.Windows.Forms.GroupBox();
			this.cmdNewGT = new System.Windows.Forms.Button();
			this.MonthView1 = new System.Windows.Forms.MonthCalendar();
			this.cmdLoad = new System.Windows.Forms.Button();
			this.txtInvoiceTotal = new System.Windows.Forms.TextBox();
			this.txtInvoiceNo = new System.Windows.Forms.TextBox();
			this.cmbTemplate = new myDataGridView();
			this._lbl_4 = new System.Windows.Forms.Label();
			this._lblLabels_0 = new System.Windows.Forms.Label();
			this._lblData_3 = new System.Windows.Forms.Label();
			this._lbl_5 = new System.Windows.Forms.Label();
			this._lbl_6 = new System.Windows.Forms.Label();
			this._lbl_7 = new System.Windows.Forms.Label();
			this._lblData_7 = new System.Windows.Forms.Label();
			this._lblLabels_36 = new System.Windows.Forms.Label();
			this._lbl_2 = new System.Windows.Forms.Label();
			this._lbl_1 = new System.Windows.Forms.Label();
			this._lblLabels_2 = new System.Windows.Forms.Label();
			this._lblLabels_8 = new System.Windows.Forms.Label();
			this._lblLabels_9 = new System.Windows.Forms.Label();
			this._lblData_0 = new System.Windows.Forms.Label();
			this._lblData_1 = new System.Windows.Forms.Label();
			this._lblData_2 = new System.Windows.Forms.Label();
			this._Shape1_1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this._Shape1_2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			//Me.frmMode = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblData = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.Shape1 = new OvalShapeArray(components);
			this._frmMode_1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.MonthView1).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmbTemplate).BeginInit();
			//CType(Me.frmMode, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblData, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
			((System.ComponentModel.ISupportInitialize)this.Shape1).BeginInit();
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Process a 'Good Receiving Voucher'";
			this.ClientSize = new System.Drawing.Size(360, 449);
			this.Location = new System.Drawing.Point(3, 22);
			this.ControlBox = false;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Enabled = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmGRV";
			this.tmrAutoGRV.Enabled = false;
			this.tmrAutoGRV.Interval = 10;
			this.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNext.Text = "&Next";
			this.cmdNext.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdNext.Size = new System.Drawing.Size(97, 34);
			this.cmdNext.Location = new System.Drawing.Point(246, 409);
			this.cmdNext.TabIndex = 9;
			this.cmdNext.TabStop = false;
			this.cmdNext.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNext.CausesValidation = true;
			this.cmdNext.Enabled = true;
			this.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNext.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNext.Name = "cmdNext";
			this.cmdBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdBack.Text = "E&xit";
			this.cmdBack.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdBack.Size = new System.Drawing.Size(97, 34);
			this.cmdBack.Location = new System.Drawing.Point(15, 409);
			this.cmdBack.TabIndex = 8;
			this.cmdBack.TabStop = false;
			this.cmdBack.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBack.CausesValidation = true;
			this.cmdBack.Enabled = true;
			this.cmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBack.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBack.Name = "cmdBack";
			this._frmMode_1.Text = "Select a supplier to transact with.";
			this._frmMode_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._frmMode_1.Size = new System.Drawing.Size(346, 395);
			this._frmMode_1.Location = new System.Drawing.Point(6, 6);
			this._frmMode_1.TabIndex = 10;
			this._frmMode_1.BackColor = System.Drawing.SystemColors.Control;
			this._frmMode_1.Enabled = true;
			this._frmMode_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmMode_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._frmMode_1.Visible = true;
			this._frmMode_1.Padding = new System.Windows.Forms.Padding(0);
			this._frmMode_1.Name = "_frmMode_1";
			this.cmdNewGT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNewGT.Text = "Maintain GRV Templates";
			this.AcceptButton = this.cmdNewGT;
			this.cmdNewGT.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdNewGT.Size = new System.Drawing.Size(169, 23);
			this.cmdNewGT.Location = new System.Drawing.Point(167, 144);
			this.cmdNewGT.TabIndex = 24;
			this.cmdNewGT.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNewGT.CausesValidation = true;
			this.cmdNewGT.Enabled = true;
			this.cmdNewGT.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNewGT.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNewGT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNewGT.TabStop = true;
			this.cmdNewGT.Name = "cmdNewGT";
			//MonthView1.OcxState = CType(resources.GetObject("MonthView1.OcxState"), System.Windows.Forms.AxHost.State)
			this.MonthView1.Size = new System.Drawing.Size(176, 154);
			this.MonthView1.Location = new System.Drawing.Point(72, 223);
			this.MonthView1.TabIndex = 6;
			this.MonthView1.Name = "MonthView1";
			this.cmdLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdLoad.Text = "Load GRV";
			this.cmdLoad.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdLoad.Size = new System.Drawing.Size(73, 52);
			this.cmdLoad.Location = new System.Drawing.Point(255, 322);
			this.cmdLoad.TabIndex = 7;
			this.cmdLoad.BackColor = System.Drawing.SystemColors.Control;
			this.cmdLoad.CausesValidation = true;
			this.cmdLoad.Enabled = true;
			this.cmdLoad.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdLoad.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdLoad.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdLoad.TabStop = true;
			this.cmdLoad.Name = "cmdLoad";
			this.txtInvoiceTotal.AutoSize = false;
			this.txtInvoiceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtInvoiceTotal.Size = new System.Drawing.Size(103, 19);
			this.txtInvoiceTotal.Location = new System.Drawing.Point(147, 199);
			this.txtInvoiceTotal.TabIndex = 4;
			this.txtInvoiceTotal.AcceptsReturn = true;
			this.txtInvoiceTotal.BackColor = System.Drawing.SystemColors.Window;
			this.txtInvoiceTotal.CausesValidation = true;
			this.txtInvoiceTotal.Enabled = true;
			this.txtInvoiceTotal.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtInvoiceTotal.HideSelection = true;
			this.txtInvoiceTotal.ReadOnly = false;
			this.txtInvoiceTotal.MaxLength = 0;
			this.txtInvoiceTotal.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtInvoiceTotal.Multiline = false;
			this.txtInvoiceTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtInvoiceTotal.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtInvoiceTotal.TabStop = true;
			this.txtInvoiceTotal.Visible = true;
			this.txtInvoiceTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtInvoiceTotal.Name = "txtInvoiceTotal";
			this.txtInvoiceNo.AutoSize = false;
			this.txtInvoiceNo.Size = new System.Drawing.Size(178, 19);
			this.txtInvoiceNo.Location = new System.Drawing.Point(72, 178);
			this.txtInvoiceNo.TabIndex = 2;
			this.txtInvoiceNo.AcceptsReturn = true;
			this.txtInvoiceNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtInvoiceNo.BackColor = System.Drawing.SystemColors.Window;
			this.txtInvoiceNo.CausesValidation = true;
			this.txtInvoiceNo.Enabled = true;
			this.txtInvoiceNo.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtInvoiceNo.HideSelection = true;
			this.txtInvoiceNo.ReadOnly = false;
			this.txtInvoiceNo.MaxLength = 0;
			this.txtInvoiceNo.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtInvoiceNo.Multiline = false;
			this.txtInvoiceNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtInvoiceNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtInvoiceNo.TabStop = true;
			this.txtInvoiceNo.Visible = true;
			this.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtInvoiceNo.Name = "txtInvoiceNo";
			//cmbTemplate.OcxState = CType(resources.GetObject("cmbTemplate.OcxState"), System.Windows.Forms.AxHost.State)
			this.cmbTemplate.Size = new System.Drawing.Size(228, 21);
			this.cmbTemplate.Location = new System.Drawing.Point(104, 117);
			this.cmbTemplate.TabIndex = 22;
			this.cmbTemplate.Name = "cmbTemplate";
			this._lbl_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_4.Text = "GRV Template :";
			this._lbl_4.Size = new System.Drawing.Size(76, 13);
			this._lbl_4.Location = new System.Drawing.Point(22, 120);
			this._lbl_4.TabIndex = 23;
			this._lbl_4.BackColor = System.Drawing.Color.Transparent;
			this._lbl_4.Enabled = true;
			this._lbl_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_4.UseMnemonic = true;
			this._lbl_4.Visible = true;
			this._lbl_4.AutoSize = true;
			this._lbl_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_4.Name = "_lbl_4";
			this._lblLabels_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_0.Text = "Order Reference:";
			this._lblLabels_0.Size = new System.Drawing.Size(82, 13);
			this._lblLabels_0.Location = new System.Drawing.Point(16, 96);
			this._lblLabels_0.TabIndex = 21;
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
			this._lblData_3.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblData_3.Text = "PurchaseOrder_Reference";
			this._lblData_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblData_3.Size = new System.Drawing.Size(226, 16);
			this._lblData_3.Location = new System.Drawing.Point(106, 96);
			this._lblData_3.TabIndex = 20;
			this._lblData_3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblData_3.Enabled = true;
			this._lblData_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblData_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblData_3.UseMnemonic = true;
			this._lblData_3.Visible = true;
			this._lblData_3.AutoSize = false;
			this._lblData_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblData_3.Name = "_lblData_3";
			this._lbl_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_5.Text = "Number :";
			this._lbl_5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_5.Size = new System.Drawing.Size(52, 13);
			this._lbl_5.Location = new System.Drawing.Point(14, 181);
			this._lbl_5.TabIndex = 1;
			this._lbl_5.BackColor = System.Drawing.Color.Transparent;
			this._lbl_5.Enabled = true;
			this._lbl_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_5.UseMnemonic = true;
			this._lbl_5.Visible = true;
			this._lbl_5.AutoSize = true;
			this._lbl_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_5.Name = "_lbl_5";
			this._lbl_6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_6.Text = "Total :";
			this._lbl_6.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_6.Size = new System.Drawing.Size(38, 13);
			this._lbl_6.Location = new System.Drawing.Point(103, 202);
			this._lbl_6.TabIndex = 3;
			this._lbl_6.BackColor = System.Drawing.Color.Transparent;
			this._lbl_6.Enabled = true;
			this._lbl_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_6.UseMnemonic = true;
			this._lbl_6.Visible = true;
			this._lbl_6.AutoSize = true;
			this._lbl_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_6.Name = "_lbl_6";
			this._lbl_7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lbl_7.Text = "Date :";
			this._lbl_7.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_7.Size = new System.Drawing.Size(36, 13);
			this._lbl_7.Location = new System.Drawing.Point(30, 220);
			this._lbl_7.TabIndex = 5;
			this._lbl_7.BackColor = System.Drawing.Color.Transparent;
			this._lbl_7.Enabled = true;
			this._lbl_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lbl_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_7.UseMnemonic = true;
			this._lbl_7.Visible = true;
			this._lbl_7.AutoSize = true;
			this._lbl_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_7.Name = "_lbl_7";
			this._lblData_7.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblData_7.Text = "Supplier_ShippingCode";
			this._lblData_7.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblData_7.Size = new System.Drawing.Size(226, 16);
			this._lblData_7.Location = new System.Drawing.Point(105, 75);
			this._lblData_7.TabIndex = 19;
			this._lblData_7.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblData_7.Enabled = true;
			this._lblData_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblData_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblData_7.UseMnemonic = true;
			this._lblData_7.Visible = true;
			this._lblData_7.AutoSize = false;
			this._lblData_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblData_7.Name = "_lblData_7";
			this._lblLabels_36.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_36.Text = "Account Number:";
			this._lblLabels_36.Size = new System.Drawing.Size(83, 13);
			this._lblLabels_36.Location = new System.Drawing.Point(14, 75);
			this._lblLabels_36.TabIndex = 18;
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
			this._lbl_2.BackColor = System.Drawing.Color.Transparent;
			this._lbl_2.Text = "&2. Invoice Details";
			this._lbl_2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_2.Size = new System.Drawing.Size(101, 13);
			this._lbl_2.Location = new System.Drawing.Point(9, 152);
			this._lbl_2.TabIndex = 0;
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
			this._lbl_1.BackColor = System.Drawing.Color.Transparent;
			this._lbl_1.Text = "&1. Supplier Details";
			this._lbl_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_1.Size = new System.Drawing.Size(105, 13);
			this._lbl_1.Location = new System.Drawing.Point(9, 18);
			this._lbl_1.TabIndex = 17;
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
			this._lblLabels_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_2.Text = "Supplier Name:";
			this._lblLabels_2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lblLabels_2.Size = new System.Drawing.Size(87, 13);
			this._lblLabels_2.Location = new System.Drawing.Point(13, 39);
			this._lblLabels_2.TabIndex = 16;
			this._lblLabels_2.BackColor = System.Drawing.Color.Transparent;
			this._lblLabels_2.Enabled = true;
			this._lblLabels_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblLabels_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblLabels_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblLabels_2.UseMnemonic = true;
			this._lblLabels_2.Visible = true;
			this._lblLabels_2.AutoSize = true;
			this._lblLabels_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblLabels_2.Name = "_lblLabels_2";
			this._lblLabels_8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_8.Text = "Telephone:";
			this._lblLabels_8.Size = new System.Drawing.Size(55, 13);
			this._lblLabels_8.Location = new System.Drawing.Point(42, 57);
			this._lblLabels_8.TabIndex = 15;
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
			this._lblLabels_9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this._lblLabels_9.Text = "Fax:";
			this._lblLabels_9.Size = new System.Drawing.Size(22, 13);
			this._lblLabels_9.Location = new System.Drawing.Point(210, 57);
			this._lblLabels_9.TabIndex = 14;
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
			this._lblData_0.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblData_0.Text = "Supplier_Name";
			this._lblData_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblData_0.Size = new System.Drawing.Size(226, 16);
			this._lblData_0.Location = new System.Drawing.Point(105, 39);
			this._lblData_0.TabIndex = 13;
			this._lblData_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblData_0.Enabled = true;
			this._lblData_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblData_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblData_0.UseMnemonic = true;
			this._lblData_0.Visible = true;
			this._lblData_0.AutoSize = false;
			this._lblData_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblData_0.Name = "_lblData_0";
			this._lblData_1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblData_1.Text = "Supplier_Telephone";
			this._lblData_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblData_1.Size = new System.Drawing.Size(94, 16);
			this._lblData_1.Location = new System.Drawing.Point(105, 57);
			this._lblData_1.TabIndex = 12;
			this._lblData_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblData_1.Enabled = true;
			this._lblData_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblData_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblData_1.UseMnemonic = true;
			this._lblData_1.Visible = true;
			this._lblData_1.AutoSize = false;
			this._lblData_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblData_1.Name = "_lblData_1";
			this._lblData_2.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			this._lblData_2.Text = "Supplier_Facimile";
			this._lblData_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lblData_2.Size = new System.Drawing.Size(94, 16);
			this._lblData_2.Location = new System.Drawing.Point(237, 57);
			this._lblData_2.TabIndex = 11;
			this._lblData_2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblData_2.Enabled = true;
			this._lblData_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblData_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblData_2.UseMnemonic = true;
			this._lblData_2.Visible = true;
			this._lblData_2.AutoSize = false;
			this._lblData_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._lblData_2.Name = "_lblData_2";
			this._Shape1_1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this._Shape1_1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_1.Size = new System.Drawing.Size(328, 112);
			this._Shape1_1.Location = new System.Drawing.Point(9, 20);
			this._Shape1_1.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_1.BorderWidth = 1;
			this._Shape1_1.FillColor = System.Drawing.Color.Black;
			this._Shape1_1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_1.Visible = true;
			this._Shape1_1.Name = "_Shape1_1";
			this._Shape1_2.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
			this._Shape1_2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
			this._Shape1_2.Size = new System.Drawing.Size(328, 214);
			this._Shape1_2.Location = new System.Drawing.Point(9, 156);
			this._Shape1_2.BorderColor = System.Drawing.SystemColors.WindowText;
			this._Shape1_2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this._Shape1_2.BorderWidth = 1;
			this._Shape1_2.FillColor = System.Drawing.Color.Black;
			this._Shape1_2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this._Shape1_2.Visible = true;
			this._Shape1_2.Name = "_Shape1_2";
			this.Controls.Add(cmdNext);
			this.Controls.Add(cmdBack);
			this.Controls.Add(_frmMode_1);
			this._frmMode_1.Controls.Add(cmdNewGT);
			this._frmMode_1.Controls.Add(MonthView1);
			this._frmMode_1.Controls.Add(cmdLoad);
			this._frmMode_1.Controls.Add(txtInvoiceTotal);
			this._frmMode_1.Controls.Add(txtInvoiceNo);
			this._frmMode_1.Controls.Add(cmbTemplate);
			this._frmMode_1.Controls.Add(_lbl_4);
			this._frmMode_1.Controls.Add(_lblLabels_0);
			this._frmMode_1.Controls.Add(_lblData_3);
			this._frmMode_1.Controls.Add(_lbl_5);
			this._frmMode_1.Controls.Add(_lbl_6);
			this._frmMode_1.Controls.Add(_lbl_7);
			this._frmMode_1.Controls.Add(_lblData_7);
			this._frmMode_1.Controls.Add(_lblLabels_36);
			this._frmMode_1.Controls.Add(_lbl_2);
			this._frmMode_1.Controls.Add(_lbl_1);
			this._frmMode_1.Controls.Add(_lblLabels_2);
			this._frmMode_1.Controls.Add(_lblLabels_8);
			this._frmMode_1.Controls.Add(_lblLabels_9);
			this._frmMode_1.Controls.Add(_lblData_0);
			this._frmMode_1.Controls.Add(_lblData_1);
			this._frmMode_1.Controls.Add(_lblData_2);
			this.ShapeContainer1.Shapes.Add(_Shape1_1);
			this.ShapeContainer1.Shapes.Add(_Shape1_2);
			this._frmMode_1.Controls.Add(ShapeContainer1);
			//Me.frmMode.SetIndex(_frmMode_1, CType(1, Short))
			//Me.lbl.SetIndex(_lbl_4, CType(4, Short))
			//Me.lbl.SetIndex(_lbl_5, CType(5, Short))
			//Me.lbl.SetIndex(_lbl_6, CType(6, Short))
			//Me.lbl.SetIndex(_lbl_7, CType(7, Short))
			//Me.lbl.SetIndex(_lbl_2, CType(2, Short))
			//Me.lbl.SetIndex(_lbl_1, CType(1, Short))
			//Me.lblData.SetIndex(_lblData_3, CType(3, Short))
			//Me.lblData.SetIndex(_lblData_7, CType(7, Short))
			//Me.lblData.SetIndex(_lblData_0, CType(0, Short))
			//Me.lblData.SetIndex(_lblData_1, CType(1, Short))
			//Me.lblData.SetIndex(_lblData_2, CType(2, Short))
			//Me.lblLabels.SetIndex(_lblLabels_0, CType(0, Short))
			//Me.lblLabels.SetIndex(_lblLabels_36, CType(36, Short))
			//Me.lblLabels.SetIndex(_lblLabels_2, CType(2, Short))
			//Me.lblLabels.SetIndex(_lblLabels_8, CType(8, Short))
			//Me.lblLabels.SetIndex(_lblLabels_9, CType(9, Short))
			//Me.Shape1.SetIndex(_Shape1_1, CType(1, Short))
			//Me.Shape1.SetIndex(_Shape1_2, CType(2, Short))
			((System.ComponentModel.ISupportInitialize)this.Shape1).EndInit();
			//CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lblData, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.frmMode, System.ComponentModel.ISupportInitialize).EndInit()
			((System.ComponentModel.ISupportInitialize)this.cmbTemplate).EndInit();
			((System.ComponentModel.ISupportInitialize)this.MonthView1).EndInit();
			this._frmMode_1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
