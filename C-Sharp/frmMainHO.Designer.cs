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
	partial class frmMainHO
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public frmMainHO() : base()
		{
			Load += frmMainHO_Load;
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
		private System.Windows.Forms.Button withEventsField_Command3;
		public System.Windows.Forms.Button Command3 {
			get { return withEventsField_Command3; }
			set {
				if (withEventsField_Command3 != null) {
					withEventsField_Command3.Click -= Command3_Click;
				}
				withEventsField_Command3 = value;
				if (withEventsField_Command3 != null) {
					withEventsField_Command3.Click += Command3_Click;
				}
			}
		}
		public System.Windows.Forms.PictureBox picInner;
		public System.Windows.Forms.Panel picOuter;
		private System.Windows.Forms.Timer withEventsField_tmrAutoDE;
		public System.Windows.Forms.Timer tmrAutoDE {
			get { return withEventsField_tmrAutoDE; }
			set {
				if (withEventsField_tmrAutoDE != null) {
					withEventsField_tmrAutoDE.Tick -= tmrAutoDE_Tick;
				}
				withEventsField_tmrAutoDE = value;
				if (withEventsField_tmrAutoDE != null) {
					withEventsField_tmrAutoDE.Tick += tmrAutoDE_Tick;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdBookIN;
		public System.Windows.Forms.Button cmdBookIN {
			get { return withEventsField_cmdBookIN; }
			set {
				if (withEventsField_cmdBookIN != null) {
					withEventsField_cmdBookIN.Click -= cmdBookIN_Click;
				}
				withEventsField_cmdBookIN = value;
				if (withEventsField_cmdBookIN != null) {
					withEventsField_cmdBookIN.Click += cmdBookIN_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdBookOut;
		public System.Windows.Forms.Button cmdBookOut {
			get { return withEventsField_cmdBookOut; }
			set {
				if (withEventsField_cmdBookOut != null) {
					withEventsField_cmdBookOut.Click -= cmdBookOut_Click;
				}
				withEventsField_cmdBookOut = value;
				if (withEventsField_cmdBookOut != null) {
					withEventsField_cmdBookOut.Click += cmdBookOut_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdUpReport;
		public System.Windows.Forms.Button cmdUpReport {
			get { return withEventsField_cmdUpReport; }
			set {
				if (withEventsField_cmdUpReport != null) {
					withEventsField_cmdUpReport.Click -= cmdUpReport_Click;
				}
				withEventsField_cmdUpReport = value;
				if (withEventsField_cmdUpReport != null) {
					withEventsField_cmdUpReport.Click += cmdUpReport_Click;
				}
			}
		}
		public System.Windows.Forms.TextBox txtPrevOrder;
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
		private System.Windows.Forms.Button withEventsField_cmdToday;
		public System.Windows.Forms.Button cmdToday {
			get { return withEventsField_cmdToday; }
			set {
				if (withEventsField_cmdToday != null) {
					withEventsField_cmdToday.Click -= cmdToday_Click;
				}
				withEventsField_cmdToday = value;
				if (withEventsField_cmdToday != null) {
					withEventsField_cmdToday.Click += cmdToday_Click;
				}
			}
		}
		public DateTimePicker _DTPicker1_0;
		public DateTimePicker _DTPicker1_1;
		public System.Windows.Forms.Label _lbl_0;
		public System.Windows.Forms.Panel Picture1;
		public System.Windows.Forms.TextBox Text4;
		public System.Windows.Forms.TextBox Text3;
		public System.Windows.Forms.TextBox Text2;
		public System.Windows.Forms.Button _cmdPulsante_5;
		private System.Windows.Forms.Button withEventsField_cmdClearLock;
		public System.Windows.Forms.Button cmdClearLock {
			get { return withEventsField_cmdClearLock; }
			set {
				if (withEventsField_cmdClearLock != null) {
					withEventsField_cmdClearLock.Click -= cmdClearLock_Click;
				}
				withEventsField_cmdClearLock = value;
				if (withEventsField_cmdClearLock != null) {
					withEventsField_cmdClearLock.Click += cmdClearLock_Click;
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
		private System.Windows.Forms.Button withEventsField_Command2;
		public System.Windows.Forms.Button Command2 {
			get { return withEventsField_Command2; }
			set {
				if (withEventsField_Command2 != null) {
					withEventsField_Command2.Click -= Command2_Click;
				}
				withEventsField_Command2 = value;
				if (withEventsField_Command2 != null) {
					withEventsField_Command2.Click += Command2_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdCheckWOrder;
		public System.Windows.Forms.Button cmdCheckWOrder {
			get { return withEventsField_cmdCheckWOrder; }
			set {
				if (withEventsField_cmdCheckWOrder != null) {
					withEventsField_cmdCheckWOrder.Click -= cmdCheckWOrder_Click;
				}
				withEventsField_cmdCheckWOrder = value;
				if (withEventsField_cmdCheckWOrder != null) {
					withEventsField_cmdCheckWOrder.Click += cmdCheckWOrder_Click;
				}
			}
		}
		public System.Windows.Forms.Panel picButtons;
		public System.Windows.Forms.TextBox Text1;
		public System.Windows.Forms.Label _Label1_1;
		public System.Windows.Forms.GroupBox _Frame1_0;
		public System.Windows.Forms.Button _cmdPulsante_7;
		public System.Windows.Forms.Button _cmdPulsante_6;
		public System.Windows.Forms.GroupBox _Frame1_3;
		public System.Windows.Forms.Button _cmdPulsante_4;
		public System.Windows.Forms.GroupBox _Frame1_2;
		public System.Windows.Forms.Button _cmdPulsante_3;
		public System.Windows.Forms.Button _cmdPulsante_2;
		public System.Windows.Forms.Button _cmdPulsante_1;
		public System.Windows.Forms.Button _cmdPulsante_0;
		public System.Windows.Forms.GroupBox _Frame1_1;
		public System.Windows.Forms.Label lbl8;
		public System.Windows.Forms.Label lbl11;
		public System.Windows.Forms.Label lbl55;
		public System.Windows.Forms.Label lbl5;
		public System.Windows.Forms.Label lbl44;
		public System.Windows.Forms.Label lbl4;
		public System.Windows.Forms.Label lbl33;
		public System.Windows.Forms.Label lbl3;
		public System.Windows.Forms.Label lbl22;
		public System.Windows.Forms.Label lbl2;
		public System.Windows.Forms.Label lbl1;
		public System.Windows.Forms.Label lbl66;
		public System.Windows.Forms.Label lbl6;
		//Public WithEvents DTPicker1 As System.Windows.Forms.DateTimePicker
		//Public WithEvents Frame1 As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
		//Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
		//Public WithEvents cmdPulsante As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
		//Public WithEvents lbl As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMainHO));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.Command3 = new System.Windows.Forms.Button();
			this.picOuter = new System.Windows.Forms.Panel();
			this.picInner = new System.Windows.Forms.PictureBox();
			this.tmrAutoDE = new System.Windows.Forms.Timer(components);
			this.cmdBookIN = new System.Windows.Forms.Button();
			this.cmdBookOut = new System.Windows.Forms.Button();
			this.cmdUpReport = new System.Windows.Forms.Button();
			this.txtPrevOrder = new System.Windows.Forms.TextBox();
			this.Command1 = new System.Windows.Forms.Button();
			this.cmdExit = new System.Windows.Forms.Button();
			this.Picture1 = new System.Windows.Forms.Panel();
			this.cmdToday = new System.Windows.Forms.Button();
			this._DTPicker1_0 = new System.Windows.Forms.DateTimePicker();
			this._DTPicker1_1 = new System.Windows.Forms.DateTimePicker();
			this._lbl_0 = new System.Windows.Forms.Label();
			this.Text4 = new System.Windows.Forms.TextBox();
			this.Text3 = new System.Windows.Forms.TextBox();
			this.Text2 = new System.Windows.Forms.TextBox();
			this._cmdPulsante_5 = new System.Windows.Forms.Button();
			this.picButtons = new System.Windows.Forms.Panel();
			this.cmdClearLock = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this.Command2 = new System.Windows.Forms.Button();
			this.cmdCheckWOrder = new System.Windows.Forms.Button();
			this._Frame1_0 = new System.Windows.Forms.GroupBox();
			this.Text1 = new System.Windows.Forms.TextBox();
			this._Label1_1 = new System.Windows.Forms.Label();
			this._Frame1_3 = new System.Windows.Forms.GroupBox();
			this._cmdPulsante_7 = new System.Windows.Forms.Button();
			this._cmdPulsante_6 = new System.Windows.Forms.Button();
			this._Frame1_2 = new System.Windows.Forms.GroupBox();
			this._cmdPulsante_4 = new System.Windows.Forms.Button();
			this._Frame1_1 = new System.Windows.Forms.GroupBox();
			this._cmdPulsante_3 = new System.Windows.Forms.Button();
			this._cmdPulsante_2 = new System.Windows.Forms.Button();
			this._cmdPulsante_1 = new System.Windows.Forms.Button();
			this._cmdPulsante_0 = new System.Windows.Forms.Button();
			this.lbl8 = new System.Windows.Forms.Label();
			this.lbl11 = new System.Windows.Forms.Label();
			this.lbl55 = new System.Windows.Forms.Label();
			this.lbl5 = new System.Windows.Forms.Label();
			this.lbl44 = new System.Windows.Forms.Label();
			this.lbl4 = new System.Windows.Forms.Label();
			this.lbl33 = new System.Windows.Forms.Label();
			this.lbl3 = new System.Windows.Forms.Label();
			this.lbl22 = new System.Windows.Forms.Label();
			this.lbl2 = new System.Windows.Forms.Label();
			this.lbl1 = new System.Windows.Forms.Label();
			this.lbl66 = new System.Windows.Forms.Label();
			this.lbl6 = new System.Windows.Forms.Label();
			//Me.DTPicker1 = New System.Windows.Forms.DateTimePicker
			//Me.Frame1 = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(components)
			//Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			//Me.cmdPulsante = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components)
			//Me.lbl = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
			this.picOuter.SuspendLayout();
			this.Picture1.SuspendLayout();
			this.picButtons.SuspendLayout();
			this._Frame1_0.SuspendLayout();
			this._Frame1_3.SuspendLayout();
			this._Frame1_2.SuspendLayout();
			this._Frame1_1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this._DTPicker1_0).BeginInit();
			((System.ComponentModel.ISupportInitialize)this._DTPicker1_1).BeginInit();
			//CType(Me.DTPicker1, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.Frame1, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.cmdPulsante, System.ComponentModel.ISupportInitialize).BeginInit()
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).BeginInit()
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "4POS HeadOffice Sync Engine";
			this.ClientSize = new System.Drawing.Size(473, 602);
			this.Location = new System.Drawing.Point(3, 29);
			this.ControlBox = false;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Enabled = true;
			this.KeyPreview = false;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmMainHO";
			this.Command3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Command3.Text = " Prod perfor";
			this.Command3.Size = new System.Drawing.Size(97, 27);
			this.Command3.Location = new System.Drawing.Point(368, 232);
			this.Command3.TabIndex = 48;
			this.Command3.Visible = false;
			this.Command3.BackColor = System.Drawing.SystemColors.Control;
			this.Command3.CausesValidation = true;
			this.Command3.Enabled = true;
			this.Command3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command3.TabStop = true;
			this.Command3.Name = "Command3";
			this.picOuter.BackColor = System.Drawing.Color.White;
			this.picOuter.Size = new System.Drawing.Size(425, 33);
			this.picOuter.Location = new System.Drawing.Point(24, 392);
			this.picOuter.TabIndex = 46;
			this.picOuter.Visible = false;
			this.picOuter.Dock = System.Windows.Forms.DockStyle.None;
			this.picOuter.CausesValidation = true;
			this.picOuter.Enabled = true;
			this.picOuter.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picOuter.Cursor = System.Windows.Forms.Cursors.Default;
			this.picOuter.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picOuter.TabStop = true;
			this.picOuter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picOuter.Name = "picOuter";
			this.picInner.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
			this.picInner.ForeColor = System.Drawing.SystemColors.WindowText;
			this.picInner.Size = new System.Drawing.Size(58, 34);
			this.picInner.Location = new System.Drawing.Point(0, 0);
			this.picInner.TabIndex = 47;
			this.picInner.Dock = System.Windows.Forms.DockStyle.None;
			this.picInner.CausesValidation = true;
			this.picInner.Enabled = true;
			this.picInner.Cursor = System.Windows.Forms.Cursors.Default;
			this.picInner.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picInner.TabStop = true;
			this.picInner.Visible = true;
			this.picInner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this.picInner.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.picInner.Name = "picInner";
			this.tmrAutoDE.Enabled = false;
			this.tmrAutoDE.Interval = 10;
			this.cmdBookIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdBookIN.Text = "&Book In DB";
			this.cmdBookIN.Size = new System.Drawing.Size(97, 27);
			this.cmdBookIN.Location = new System.Drawing.Point(368, 112);
			this.cmdBookIN.TabIndex = 44;
			this.cmdBookIN.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBookIN.CausesValidation = true;
			this.cmdBookIN.Enabled = true;
			this.cmdBookIN.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBookIN.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdBookIN.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBookIN.TabStop = true;
			this.cmdBookIN.Name = "cmdBookIN";
			this.cmdBookOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdBookOut.Text = "&Book Out DB";
			this.cmdBookOut.Size = new System.Drawing.Size(97, 27);
			this.cmdBookOut.Location = new System.Drawing.Point(368, 80);
			this.cmdBookOut.TabIndex = 43;
			this.cmdBookOut.BackColor = System.Drawing.SystemColors.Control;
			this.cmdBookOut.CausesValidation = true;
			this.cmdBookOut.Enabled = true;
			this.cmdBookOut.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdBookOut.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdBookOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdBookOut.TabStop = true;
			this.cmdBookOut.Name = "cmdBookOut";
			this.cmdUpReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdUpReport.Text = "&Upload Reports";
			this.cmdUpReport.Size = new System.Drawing.Size(97, 27);
			this.cmdUpReport.Location = new System.Drawing.Point(368, 48);
			this.cmdUpReport.TabIndex = 42;
			this.cmdUpReport.BackColor = System.Drawing.SystemColors.Control;
			this.cmdUpReport.CausesValidation = true;
			this.cmdUpReport.Enabled = true;
			this.cmdUpReport.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdUpReport.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdUpReport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdUpReport.TabStop = true;
			this.cmdUpReport.Name = "cmdUpReport";
			this.txtPrevOrder.AutoSize = false;
			this.txtPrevOrder.Size = new System.Drawing.Size(129, 25);
			this.txtPrevOrder.Location = new System.Drawing.Point(504, 552);
			this.txtPrevOrder.TabIndex = 41;
			this.txtPrevOrder.Text = "response";
			this.txtPrevOrder.Visible = false;
			this.txtPrevOrder.AcceptsReturn = true;
			this.txtPrevOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtPrevOrder.BackColor = System.Drawing.SystemColors.Window;
			this.txtPrevOrder.CausesValidation = true;
			this.txtPrevOrder.Enabled = true;
			this.txtPrevOrder.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPrevOrder.HideSelection = true;
			this.txtPrevOrder.ReadOnly = false;
			this.txtPrevOrder.MaxLength = 0;
			this.txtPrevOrder.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtPrevOrder.Multiline = false;
			this.txtPrevOrder.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtPrevOrder.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtPrevOrder.TabStop = true;
			this.txtPrevOrder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtPrevOrder.Name = "txtPrevOrder";
			this.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Command1.Text = "-";
			this.Command1.Font = new System.Drawing.Font("Arial", 13.5f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.Command1.Size = new System.Drawing.Size(35, 27);
			this.Command1.Location = new System.Drawing.Point(488, 554);
			this.Command1.TabIndex = 40;
			this.Command1.BackColor = System.Drawing.SystemColors.Control;
			this.Command1.CausesValidation = true;
			this.Command1.Enabled = true;
			this.Command1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command1.TabStop = true;
			this.Command1.Name = "Command1";
			this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExit.Text = "X";
			this.cmdExit.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.cmdExit.Size = new System.Drawing.Size(35, 27);
			this.cmdExit.Location = new System.Drawing.Point(528, 554);
			this.cmdExit.TabIndex = 39;
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.CausesValidation = true;
			this.cmdExit.Enabled = true;
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.TabStop = true;
			this.cmdExit.Name = "cmdExit";
			this.Picture1.Size = new System.Drawing.Size(353, 33);
			this.Picture1.Location = new System.Drawing.Point(8, 40);
			this.Picture1.TabIndex = 34;
			this.Picture1.Dock = System.Windows.Forms.DockStyle.None;
			this.Picture1.BackColor = System.Drawing.SystemColors.Control;
			this.Picture1.CausesValidation = true;
			this.Picture1.Enabled = true;
			this.Picture1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Picture1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Picture1.TabStop = true;
			this.Picture1.Visible = true;
			this.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Picture1.Name = "Picture1";
			this.cmdToday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdToday.Text = "&1. Goto Yesterday";
			this.cmdToday.Size = new System.Drawing.Size(102, 19);
			this.cmdToday.Location = new System.Drawing.Point(248, 8);
			this.cmdToday.TabIndex = 37;
			this.cmdToday.TabStop = false;
			this.cmdToday.BackColor = System.Drawing.SystemColors.Control;
			this.cmdToday.CausesValidation = true;
			this.cmdToday.Enabled = true;
			this.cmdToday.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdToday.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdToday.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdToday.Name = "cmdToday";
			//_DTPicker1_0.OcxState = CType(resources.GetObject("_DTPicker1_0.OcxState"), System.Windows.Forms.AxHost.State)
			this._DTPicker1_0.Size = new System.Drawing.Size(94, 18);
			this._DTPicker1_0.Location = new System.Drawing.Point(56, 8);
			this._DTPicker1_0.TabIndex = 35;
			this._DTPicker1_0.Visible = false;
			this._DTPicker1_0.Name = "_DTPicker1_0";
			//_DTPicker1_1.OcxState = CType(resources.GetObject("_DTPicker1_1.OcxState"), System.Windows.Forms.AxHost.State)
			this._DTPicker1_1.Size = new System.Drawing.Size(86, 18);
			this._DTPicker1_1.Location = new System.Drawing.Point(160, 8);
			this._DTPicker1_1.TabIndex = 45;
			this._DTPicker1_1.Name = "_DTPicker1_1";
			this._lbl_0.Text = "Select Day to Upload Reports";
			this._lbl_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this._lbl_0.ForeColor = System.Drawing.Color.Black;
			this._lbl_0.Size = new System.Drawing.Size(157, 14);
			this._lbl_0.Location = new System.Drawing.Point(0, 8);
			this._lbl_0.TabIndex = 36;
			this._lbl_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lbl_0.BackColor = System.Drawing.Color.Transparent;
			this._lbl_0.Enabled = true;
			this._lbl_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lbl_0.UseMnemonic = true;
			this._lbl_0.Visible = true;
			this._lbl_0.AutoSize = true;
			this._lbl_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lbl_0.Name = "_lbl_0";
			this.Text4.AutoSize = false;
			this.Text4.BackColor = System.Drawing.Color.White;
			this.Text4.ForeColor = System.Drawing.Color.Black;
			this.Text4.Size = new System.Drawing.Size(249, 41);
			this.Text4.Location = new System.Drawing.Point(480, 176);
			this.Text4.ReadOnly = true;
			this.Text4.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.Text4.WordWrap = false;
			this.Text4.TabIndex = 32;
			this.Text4.Text = "Text1";
			this.Text4.AcceptsReturn = true;
			this.Text4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.Text4.CausesValidation = true;
			this.Text4.Enabled = true;
			this.Text4.HideSelection = true;
			this.Text4.MaxLength = 0;
			this.Text4.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.Text4.Multiline = false;
			this.Text4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Text4.TabStop = true;
			this.Text4.Visible = true;
			this.Text4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Text4.Name = "Text4";
			this.Text3.AutoSize = false;
			this.Text3.BackColor = System.Drawing.Color.White;
			this.Text3.ForeColor = System.Drawing.Color.Black;
			this.Text3.Size = new System.Drawing.Size(249, 41);
			this.Text3.Location = new System.Drawing.Point(480, 128);
			this.Text3.ReadOnly = true;
			this.Text3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.Text3.WordWrap = false;
			this.Text3.TabIndex = 31;
			this.Text3.Text = "Text1";
			this.Text3.AcceptsReturn = true;
			this.Text3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.Text3.CausesValidation = true;
			this.Text3.Enabled = true;
			this.Text3.HideSelection = true;
			this.Text3.MaxLength = 0;
			this.Text3.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.Text3.Multiline = false;
			this.Text3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Text3.TabStop = true;
			this.Text3.Visible = true;
			this.Text3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Text3.Name = "Text3";
			this.Text2.AutoSize = false;
			this.Text2.BackColor = System.Drawing.Color.White;
			this.Text2.ForeColor = System.Drawing.Color.Black;
			this.Text2.Size = new System.Drawing.Size(249, 41);
			this.Text2.Location = new System.Drawing.Point(480, 80);
			this.Text2.ReadOnly = true;
			this.Text2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.Text2.WordWrap = false;
			this.Text2.TabIndex = 30;
			this.Text2.Text = "Text1";
			this.Text2.AcceptsReturn = true;
			this.Text2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.Text2.CausesValidation = true;
			this.Text2.Enabled = true;
			this.Text2.HideSelection = true;
			this.Text2.MaxLength = 0;
			this.Text2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.Text2.Multiline = false;
			this.Text2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Text2.TabStop = true;
			this.Text2.Visible = true;
			this.Text2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Text2.Name = "Text2";
			this._cmdPulsante_5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this._cmdPulsante_5.Text = "&Log";
			this._cmdPulsante_5.Size = new System.Drawing.Size(97, 57);
			this._cmdPulsante_5.Location = new System.Drawing.Point(616, 216);
			this._cmdPulsante_5.Image = (System.Drawing.Image)resources.GetObject("_cmdPulsante_5.Image");
			this._cmdPulsante_5.TabIndex = 14;
			this._cmdPulsante_5.BackColor = System.Drawing.SystemColors.Control;
			this._cmdPulsante_5.CausesValidation = true;
			this._cmdPulsante_5.Enabled = true;
			this._cmdPulsante_5.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdPulsante_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdPulsante_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdPulsante_5.TabStop = true;
			this._cmdPulsante_5.Name = "_cmdPulsante_5";
			this.picButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.picButtons.BackColor = System.Drawing.Color.Blue;
			this.picButtons.Size = new System.Drawing.Size(473, 39);
			this.picButtons.Location = new System.Drawing.Point(0, 0);
			this.picButtons.TabIndex = 13;
			this.picButtons.TabStop = false;
			this.picButtons.CausesValidation = true;
			this.picButtons.Enabled = true;
			this.picButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			this.picButtons.Cursor = System.Windows.Forms.Cursors.Default;
			this.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.picButtons.Visible = true;
			this.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picButtons.Name = "picButtons";
			this.cmdClearLock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClearLock.Text = "Clear Log";
			this.cmdClearLock.Size = new System.Drawing.Size(73, 29);
			this.cmdClearLock.Location = new System.Drawing.Point(552, 4);
			this.cmdClearLock.TabIndex = 38;
			this.cmdClearLock.TabStop = false;
			this.cmdClearLock.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClearLock.CausesValidation = true;
			this.cmdClearLock.Enabled = true;
			this.cmdClearLock.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClearLock.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClearLock.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClearLock.Name = "cmdClearLock";
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClose.Text = "E&xit";
			this.cmdClose.Size = new System.Drawing.Size(73, 29);
			this.cmdClose.Location = new System.Drawing.Point(392, 4);
			this.cmdClose.TabIndex = 33;
			this.cmdClose.TabStop = false;
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.Name = "cmdClose";
			this.Command2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Command2.Text = "&Download Pricing";
			this.Command2.Size = new System.Drawing.Size(97, 27);
			this.Command2.Location = new System.Drawing.Point(112, 4);
			this.Command2.TabIndex = 29;
			this.Command2.BackColor = System.Drawing.SystemColors.Control;
			this.Command2.CausesValidation = true;
			this.Command2.Enabled = true;
			this.Command2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command2.TabStop = true;
			this.Command2.Name = "Command2";
			this.cmdCheckWOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCheckWOrder.Text = "&Upload Pricing";
			this.cmdCheckWOrder.Size = new System.Drawing.Size(97, 27);
			this.cmdCheckWOrder.Location = new System.Drawing.Point(8, 4);
			this.cmdCheckWOrder.TabIndex = 28;
			this.cmdCheckWOrder.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCheckWOrder.CausesValidation = true;
			this.cmdCheckWOrder.Enabled = true;
			this.cmdCheckWOrder.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCheckWOrder.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCheckWOrder.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCheckWOrder.TabStop = true;
			this.cmdCheckWOrder.Name = "cmdCheckWOrder";
			this._Frame1_0.Size = new System.Drawing.Size(457, 313);
			this._Frame1_0.Location = new System.Drawing.Point(8, 280);
			this._Frame1_0.TabIndex = 10;
			this._Frame1_0.BackColor = System.Drawing.SystemColors.Control;
			this._Frame1_0.Enabled = true;
			this._Frame1_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame1_0.Visible = true;
			this._Frame1_0.Padding = new System.Windows.Forms.Padding(0);
			this._Frame1_0.Name = "_Frame1_0";
			this.Text1.AutoSize = false;
			this.Text1.BackColor = System.Drawing.Color.White;
			this.Text1.ForeColor = System.Drawing.Color.Black;
			this.Text1.Size = new System.Drawing.Size(441, 257);
			this.Text1.Location = new System.Drawing.Point(8, 16);
			this.Text1.ReadOnly = true;
			this.Text1.Multiline = true;
			this.Text1.TabIndex = 11;
			this.Text1.Text = "Text1";
			this.Text1.AcceptsReturn = true;
			this.Text1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.Text1.CausesValidation = true;
			this.Text1.Enabled = true;
			this.Text1.HideSelection = true;
			this.Text1.MaxLength = 0;
			this.Text1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Text1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.Text1.TabStop = true;
			this.Text1.Visible = true;
			this.Text1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Text1.Name = "Text1";
			this._Label1_1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this._Label1_1.Text = "File Name";
			this._Label1_1.Size = new System.Drawing.Size(433, 25);
			this._Label1_1.Location = new System.Drawing.Point(8, 280);
			this._Label1_1.TabIndex = 12;
			this._Label1_1.BackColor = System.Drawing.SystemColors.Control;
			this._Label1_1.Enabled = true;
			this._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Label1_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label1_1.UseMnemonic = true;
			this._Label1_1.Visible = true;
			this._Label1_1.AutoSize = false;
			this._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label1_1.Name = "_Label1_1";
			this._Frame1_3.Size = new System.Drawing.Size(369, 81);
			this._Frame1_3.Location = new System.Drawing.Point(488, 464);
			this._Frame1_3.TabIndex = 7;
			this._Frame1_3.BackColor = System.Drawing.SystemColors.Control;
			this._Frame1_3.Enabled = true;
			this._Frame1_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame1_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame1_3.Visible = true;
			this._Frame1_3.Padding = new System.Windows.Forms.Padding(0);
			this._Frame1_3.Name = "_Frame1_3";
			this._cmdPulsante_7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this._cmdPulsante_7.Text = "&Download";
			this._cmdPulsante_7.Size = new System.Drawing.Size(145, 57);
			this._cmdPulsante_7.Location = new System.Drawing.Point(208, 16);
			this._cmdPulsante_7.Image = (System.Drawing.Image)resources.GetObject("_cmdPulsante_7.Image");
			this._cmdPulsante_7.TabIndex = 9;
			this._cmdPulsante_7.BackColor = System.Drawing.SystemColors.Control;
			this._cmdPulsante_7.CausesValidation = true;
			this._cmdPulsante_7.Enabled = true;
			this._cmdPulsante_7.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdPulsante_7.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdPulsante_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdPulsante_7.TabStop = true;
			this._cmdPulsante_7.Name = "_cmdPulsante_7";
			this._cmdPulsante_6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this._cmdPulsante_6.Text = "&Upload";
			this._cmdPulsante_6.Size = new System.Drawing.Size(97, 57);
			this._cmdPulsante_6.Location = new System.Drawing.Point(72, 16);
			this._cmdPulsante_6.Image = (System.Drawing.Image)resources.GetObject("_cmdPulsante_6.Image");
			this._cmdPulsante_6.TabIndex = 8;
			this._cmdPulsante_6.BackColor = System.Drawing.SystemColors.Control;
			this._cmdPulsante_6.CausesValidation = true;
			this._cmdPulsante_6.Enabled = true;
			this._cmdPulsante_6.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdPulsante_6.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdPulsante_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdPulsante_6.TabStop = true;
			this._cmdPulsante_6.Name = "_cmdPulsante_6";
			this._Frame1_2.Text = "Output";
			this._Frame1_2.Size = new System.Drawing.Size(193, 81);
			this._Frame1_2.Location = new System.Drawing.Point(504, 296);
			this._Frame1_2.TabIndex = 5;
			this._Frame1_2.BackColor = System.Drawing.SystemColors.Control;
			this._Frame1_2.Enabled = true;
			this._Frame1_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame1_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame1_2.Visible = true;
			this._Frame1_2.Padding = new System.Windows.Forms.Padding(0);
			this._Frame1_2.Name = "_Frame1_2";
			this._cmdPulsante_4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this._cmdPulsante_4.Text = "&Exit";
			this._cmdPulsante_4.Size = new System.Drawing.Size(177, 57);
			this._cmdPulsante_4.Location = new System.Drawing.Point(8, 16);
			this._cmdPulsante_4.Image = (System.Drawing.Image)resources.GetObject("_cmdPulsante_4.Image");
			this._cmdPulsante_4.TabIndex = 6;
			this._cmdPulsante_4.BackColor = System.Drawing.SystemColors.Control;
			this._cmdPulsante_4.CausesValidation = true;
			this._cmdPulsante_4.Enabled = true;
			this._cmdPulsante_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdPulsante_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdPulsante_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdPulsante_4.TabStop = true;
			this._cmdPulsante_4.Name = "_cmdPulsante_4";
			this._Frame1_1.Size = new System.Drawing.Size(561, 81);
			this._Frame1_1.Location = new System.Drawing.Point(472, 368);
			this._Frame1_1.TabIndex = 0;
			this._Frame1_1.BackColor = System.Drawing.SystemColors.Control;
			this._Frame1_1.Enabled = true;
			this._Frame1_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._Frame1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Frame1_1.Visible = true;
			this._Frame1_1.Padding = new System.Windows.Forms.Padding(0);
			this._Frame1_1.Name = "_Frame1_1";
			this._cmdPulsante_3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this._cmdPulsante_3.Text = "&Automatic";
			this._cmdPulsante_3.Size = new System.Drawing.Size(137, 57);
			this._cmdPulsante_3.Location = new System.Drawing.Point(416, 16);
			this._cmdPulsante_3.Image = (System.Drawing.Image)resources.GetObject("_cmdPulsante_3.Image");
			this._cmdPulsante_3.TabIndex = 4;
			this._cmdPulsante_3.BackColor = System.Drawing.SystemColors.Control;
			this._cmdPulsante_3.CausesValidation = true;
			this._cmdPulsante_3.Enabled = true;
			this._cmdPulsante_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdPulsante_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdPulsante_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdPulsante_3.TabStop = true;
			this._cmdPulsante_3.Name = "_cmdPulsante_3";
			this._cmdPulsante_2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this._cmdPulsante_2.Text = "&Setup";
			this._cmdPulsante_2.Size = new System.Drawing.Size(137, 57);
			this._cmdPulsante_2.Location = new System.Drawing.Point(272, 16);
			this._cmdPulsante_2.Image = (System.Drawing.Image)resources.GetObject("_cmdPulsante_2.Image");
			this._cmdPulsante_2.TabIndex = 3;
			this._cmdPulsante_2.BackColor = System.Drawing.SystemColors.Control;
			this._cmdPulsante_2.CausesValidation = true;
			this._cmdPulsante_2.Enabled = true;
			this._cmdPulsante_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdPulsante_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdPulsante_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdPulsante_2.TabStop = true;
			this._cmdPulsante_2.Name = "_cmdPulsante_2";
			this._cmdPulsante_1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this._cmdPulsante_1.Text = "&Disconnect";
			this._cmdPulsante_1.Size = new System.Drawing.Size(113, 57);
			this._cmdPulsante_1.Location = new System.Drawing.Point(152, 16);
			this._cmdPulsante_1.Image = (System.Drawing.Image)resources.GetObject("_cmdPulsante_1.Image");
			this._cmdPulsante_1.TabIndex = 2;
			this._cmdPulsante_1.BackColor = System.Drawing.SystemColors.Control;
			this._cmdPulsante_1.CausesValidation = true;
			this._cmdPulsante_1.Enabled = true;
			this._cmdPulsante_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdPulsante_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdPulsante_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdPulsante_1.TabStop = true;
			this._cmdPulsante_1.Name = "_cmdPulsante_1";
			this._cmdPulsante_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this._cmdPulsante_0.Text = "&Connect";
			this._cmdPulsante_0.Size = new System.Drawing.Size(137, 57);
			this._cmdPulsante_0.Location = new System.Drawing.Point(8, 16);
			this._cmdPulsante_0.Image = (System.Drawing.Image)resources.GetObject("_cmdPulsante_0.Image");
			this._cmdPulsante_0.TabIndex = 1;
			this._cmdPulsante_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdPulsante_0.CausesValidation = true;
			this._cmdPulsante_0.Enabled = true;
			this._cmdPulsante_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdPulsante_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdPulsante_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdPulsante_0.TabStop = true;
			this._cmdPulsante_0.Name = "_cmdPulsante_0";
			this.lbl8.Text = "server path";
			this.lbl8.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lbl8.Size = new System.Drawing.Size(64, 14);
			this.lbl8.Location = new System.Drawing.Point(8, 264);
			this.lbl8.TabIndex = 17;
			this.lbl8.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lbl8.BackColor = System.Drawing.Color.Transparent;
			this.lbl8.Enabled = true;
			this.lbl8.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbl8.Cursor = System.Windows.Forms.Cursors.Default;
			this.lbl8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lbl8.UseMnemonic = true;
			this.lbl8.Visible = true;
			this.lbl8.AutoSize = true;
			this.lbl8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lbl8.Name = "lbl8";
			this.lbl11.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lbl11.Text = "DONE";
			this.lbl11.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lbl11.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
			this.lbl11.Size = new System.Drawing.Size(36, 13);
			this.lbl11.Location = new System.Drawing.Point(320, 80);
			this.lbl11.TabIndex = 27;
			this.lbl11.BackColor = System.Drawing.Color.Transparent;
			this.lbl11.Enabled = true;
			this.lbl11.Cursor = System.Windows.Forms.Cursors.Default;
			this.lbl11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lbl11.UseMnemonic = true;
			this.lbl11.Visible = true;
			this.lbl11.AutoSize = true;
			this.lbl11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lbl11.Name = "lbl11";
			this.lbl55.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lbl55.Text = "DONE";
			this.lbl55.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lbl55.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
			this.lbl55.Size = new System.Drawing.Size(36, 13);
			this.lbl55.Location = new System.Drawing.Point(320, 205);
			this.lbl55.TabIndex = 26;
			this.lbl55.BackColor = System.Drawing.Color.Transparent;
			this.lbl55.Enabled = true;
			this.lbl55.Cursor = System.Windows.Forms.Cursors.Default;
			this.lbl55.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lbl55.UseMnemonic = true;
			this.lbl55.Visible = true;
			this.lbl55.AutoSize = true;
			this.lbl55.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lbl55.Name = "lbl55";
			this.lbl5.Text = "&5. Copying files to 4POS Server";
			this.lbl5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lbl5.Size = new System.Drawing.Size(169, 14);
			this.lbl5.Location = new System.Drawing.Point(8, 205);
			this.lbl5.TabIndex = 25;
			this.lbl5.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lbl5.BackColor = System.Drawing.Color.Transparent;
			this.lbl5.Enabled = true;
			this.lbl5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbl5.Cursor = System.Windows.Forms.Cursors.Default;
			this.lbl5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lbl5.UseMnemonic = true;
			this.lbl5.Visible = true;
			this.lbl5.AutoSize = true;
			this.lbl5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lbl5.Name = "lbl5";
			this.lbl44.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lbl44.Text = "DONE";
			this.lbl44.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lbl44.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
			this.lbl44.Size = new System.Drawing.Size(36, 13);
			this.lbl44.Location = new System.Drawing.Point(320, 173);
			this.lbl44.TabIndex = 24;
			this.lbl44.BackColor = System.Drawing.Color.Transparent;
			this.lbl44.Enabled = true;
			this.lbl44.Cursor = System.Windows.Forms.Cursors.Default;
			this.lbl44.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lbl44.UseMnemonic = true;
			this.lbl44.Visible = true;
			this.lbl44.AutoSize = true;
			this.lbl44.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lbl44.Name = "lbl44";
			this.lbl4.Text = "&4. Downloading";
			this.lbl4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lbl4.Size = new System.Drawing.Size(83, 14);
			this.lbl4.Location = new System.Drawing.Point(8, 173);
			this.lbl4.TabIndex = 23;
			this.lbl4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lbl4.BackColor = System.Drawing.Color.Transparent;
			this.lbl4.Enabled = true;
			this.lbl4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbl4.Cursor = System.Windows.Forms.Cursors.Default;
			this.lbl4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lbl4.UseMnemonic = true;
			this.lbl4.Visible = true;
			this.lbl4.AutoSize = true;
			this.lbl4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lbl4.Name = "lbl4";
			this.lbl33.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lbl33.Text = "DONE";
			this.lbl33.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lbl33.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
			this.lbl33.Size = new System.Drawing.Size(36, 13);
			this.lbl33.Location = new System.Drawing.Point(320, 141);
			this.lbl33.TabIndex = 22;
			this.lbl33.BackColor = System.Drawing.Color.Transparent;
			this.lbl33.Enabled = true;
			this.lbl33.Cursor = System.Windows.Forms.Cursors.Default;
			this.lbl33.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lbl33.UseMnemonic = true;
			this.lbl33.Visible = true;
			this.lbl33.AutoSize = true;
			this.lbl33.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lbl33.Name = "lbl33";
			this.lbl3.Text = "&3. Uploading ";
			this.lbl3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lbl3.Size = new System.Drawing.Size(69, 14);
			this.lbl3.Location = new System.Drawing.Point(8, 141);
			this.lbl3.TabIndex = 21;
			this.lbl3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lbl3.BackColor = System.Drawing.Color.Transparent;
			this.lbl3.Enabled = true;
			this.lbl3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbl3.Cursor = System.Windows.Forms.Cursors.Default;
			this.lbl3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lbl3.UseMnemonic = true;
			this.lbl3.Visible = true;
			this.lbl3.AutoSize = true;
			this.lbl3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lbl3.Name = "lbl3";
			this.lbl22.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lbl22.Text = "DONE";
			this.lbl22.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lbl22.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
			this.lbl22.Size = new System.Drawing.Size(36, 13);
			this.lbl22.Location = new System.Drawing.Point(320, 109);
			this.lbl22.TabIndex = 20;
			this.lbl22.BackColor = System.Drawing.Color.Transparent;
			this.lbl22.Enabled = true;
			this.lbl22.Cursor = System.Windows.Forms.Cursors.Default;
			this.lbl22.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lbl22.UseMnemonic = true;
			this.lbl22.Visible = true;
			this.lbl22.AutoSize = true;
			this.lbl22.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lbl22.Name = "lbl22";
			this.lbl2.Text = "&2. Connecting to File transfer engine";
			this.lbl2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lbl2.Size = new System.Drawing.Size(200, 14);
			this.lbl2.Location = new System.Drawing.Point(8, 109);
			this.lbl2.TabIndex = 19;
			this.lbl2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lbl2.BackColor = System.Drawing.Color.Transparent;
			this.lbl2.Enabled = true;
			this.lbl2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbl2.Cursor = System.Windows.Forms.Cursors.Default;
			this.lbl2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lbl2.UseMnemonic = true;
			this.lbl2.Visible = true;
			this.lbl2.AutoSize = true;
			this.lbl2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lbl2.Name = "lbl2";
			this.lbl1.Text = "&1. Checking Internet connection";
			this.lbl1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lbl1.Size = new System.Drawing.Size(175, 14);
			this.lbl1.Location = new System.Drawing.Point(8, 80);
			this.lbl1.TabIndex = 18;
			this.lbl1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lbl1.BackColor = System.Drawing.Color.Transparent;
			this.lbl1.Enabled = true;
			this.lbl1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbl1.Cursor = System.Windows.Forms.Cursors.Default;
			this.lbl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lbl1.UseMnemonic = true;
			this.lbl1.Visible = true;
			this.lbl1.AutoSize = true;
			this.lbl1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lbl1.Name = "lbl1";
			this.lbl66.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lbl66.Text = "DONE";
			this.lbl66.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lbl66.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
			this.lbl66.Size = new System.Drawing.Size(36, 13);
			this.lbl66.Location = new System.Drawing.Point(320, 232);
			this.lbl66.TabIndex = 16;
			this.lbl66.BackColor = System.Drawing.Color.Transparent;
			this.lbl66.Enabled = true;
			this.lbl66.Cursor = System.Windows.Forms.Cursors.Default;
			this.lbl66.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lbl66.UseMnemonic = true;
			this.lbl66.Visible = true;
			this.lbl66.AutoSize = true;
			this.lbl66.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lbl66.Name = "lbl66";
			this.lbl6.Text = "&6. Closing Connection";
			this.lbl6.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(178));
			this.lbl6.Size = new System.Drawing.Size(120, 14);
			this.lbl6.Location = new System.Drawing.Point(8, 232);
			this.lbl6.TabIndex = 15;
			this.lbl6.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lbl6.BackColor = System.Drawing.Color.Transparent;
			this.lbl6.Enabled = true;
			this.lbl6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbl6.Cursor = System.Windows.Forms.Cursors.Default;
			this.lbl6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lbl6.UseMnemonic = true;
			this.lbl6.Visible = true;
			this.lbl6.AutoSize = true;
			this.lbl6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lbl6.Name = "lbl6";
			this.Controls.Add(Command3);
			this.Controls.Add(picOuter);
			this.Controls.Add(cmdBookIN);
			this.Controls.Add(cmdBookOut);
			this.Controls.Add(cmdUpReport);
			this.Controls.Add(txtPrevOrder);
			this.Controls.Add(Command1);
			this.Controls.Add(cmdExit);
			this.Controls.Add(Picture1);
			this.Controls.Add(Text4);
			this.Controls.Add(Text3);
			this.Controls.Add(Text2);
			this.Controls.Add(_cmdPulsante_5);
			this.Controls.Add(picButtons);
			this.Controls.Add(_Frame1_0);
			this.Controls.Add(_Frame1_3);
			this.Controls.Add(_Frame1_2);
			this.Controls.Add(_Frame1_1);
			this.Controls.Add(lbl8);
			this.Controls.Add(lbl11);
			this.Controls.Add(lbl55);
			this.Controls.Add(lbl5);
			this.Controls.Add(lbl44);
			this.Controls.Add(lbl4);
			this.Controls.Add(lbl33);
			this.Controls.Add(lbl3);
			this.Controls.Add(lbl22);
			this.Controls.Add(lbl2);
			this.Controls.Add(lbl1);
			this.Controls.Add(lbl66);
			this.Controls.Add(lbl6);
			this.picOuter.Controls.Add(picInner);
			this.Picture1.Controls.Add(cmdToday);
			this.Picture1.Controls.Add(_DTPicker1_0);
			this.Picture1.Controls.Add(_DTPicker1_1);
			this.Picture1.Controls.Add(_lbl_0);
			this.picButtons.Controls.Add(cmdClearLock);
			this.picButtons.Controls.Add(cmdClose);
			this.picButtons.Controls.Add(Command2);
			this.picButtons.Controls.Add(cmdCheckWOrder);
			this._Frame1_0.Controls.Add(Text1);
			this._Frame1_0.Controls.Add(_Label1_1);
			this._Frame1_3.Controls.Add(_cmdPulsante_7);
			this._Frame1_3.Controls.Add(_cmdPulsante_6);
			this._Frame1_2.Controls.Add(_cmdPulsante_4);
			this._Frame1_1.Controls.Add(_cmdPulsante_3);
			this._Frame1_1.Controls.Add(_cmdPulsante_2);
			this._Frame1_1.Controls.Add(_cmdPulsante_1);
			this._Frame1_1.Controls.Add(_cmdPulsante_0);
			//Me.DTPicker1.SetIndex(_DTPicker1_0, CType(0, Short))
			//Me.DTPicker1.SetIndex(_DTPicker1_1, CType(1, Short))
			//Me.Frame1.SetIndex(_Frame1_0, CType(0, Short))
			//Me.Frame1.SetIndex(_Frame1_3, CType(3, Short))
			//Me.Frame1.SetIndex(_Frame1_2, CType(2, Short))
			//Me.Frame1.SetIndex(_Frame1_1, CType(1, Short))
			//Me.Label1.SetIndex(_Label1_1, CType(1, Short))
			//Me.cmdPulsante.SetIndex(_cmdPulsante_5, CType(5, Short))
			//Me.cmdPulsante.SetIndex(_cmdPulsante_7, CType(7, Short))
			//Me.cmdPulsante.SetIndex(_cmdPulsante_6, CType(6, Short))
			//Me.cmdPulsante.SetIndex(_cmdPulsante_4, CType(4, Short))
			//Me.cmdPulsante.SetIndex(_cmdPulsante_3, CType(3, Short))
			//Me.cmdPulsante.SetIndex(_cmdPulsante_2, CType(2, Short))
			//Me.cmdPulsante.SetIndex(_cmdPulsante_1, CType(1, Short))
			//Me.cmdPulsante.SetIndex(_cmdPulsante_0, CType(0, Short))
			//Me.lbl.SetIndex(_lbl_0, CType(0, Short))
			//CType(Me.lbl, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.cmdPulsante, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.Frame1, System.ComponentModel.ISupportInitialize).EndInit()
			//CType(Me.DTPicker1, System.ComponentModel.ISupportInitialize).EndInit()
			((System.ComponentModel.ISupportInitialize)this._DTPicker1_1).EndInit();
			((System.ComponentModel.ISupportInitialize)this._DTPicker1_0).EndInit();
			this.picOuter.ResumeLayout(false);
			this.Picture1.ResumeLayout(false);
			this.picButtons.ResumeLayout(false);
			this._Frame1_0.ResumeLayout(false);
			this._Frame1_3.ResumeLayout(false);
			this._Frame1_2.ResumeLayout(false);
			this._Frame1_1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
